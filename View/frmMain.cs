using Models;
using Business;
using Models.interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models.language;

namespace View
{
    public partial class frmMain : Form,ILanguageObserber
    {
        Form loginForm;

        SessionService sesionService;
        UserService userService;
        LanguageService languageService;

        private void languageChange_click(object sender, EventArgs e)
        {
            Language language =(Language)((ToolStripMenuItem)sender).Tag;
            //Le seteo por default ESP
            Session.GetInstance.language = languageService.GetLanguage(language.Name); //language.Name

            this.lblUsuario.Text = language.Name;
        }

        void ValidarPermisos()
        {
            if (Session.GetInstance.IsLoggedIn())
            {
            }
            else
            {
            }
        }

        public frmMain(Form parent)
        {
            InitializeComponent();
            
            loginForm = parent;
            sesionService = new SessionService();
            userService = new UserService();

            Session.GetInstance.addObserber(this);

            ValidarPermisos();
            cargarComboIdiomas();
        }
        public void cargarComboIdiomas()
        {
            languageService = new LanguageService();

            List<Language> languages = languageService.GetLanguagesForCombo();

            mnuSelectIdioma.DropDownItems.Clear();

            foreach (Language item in languages)
            {
                ToolStripMenuItem t = new ToolStripMenuItem(item.Name);
                t.Tag = item;

                t.Click += languageChange_click;
                mnuSelectIdioma.DropDownItems.Add(t);
            }
        }

        private void SeguridadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Session.GetInstance.IsInRole(PermissionsEnum.PatentesFamilias))
            {
                createForm(typeof(frmPatentesFamilias));
            }
            else
            {
                MessageBox.Show("No tiene permiso para ingresar a este fomrulario");
            }
        
        }
        private void UsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Session.GetInstance.IsInRole(PermissionsEnum.PatentesUsuarios))
            {
                createForm(typeof(frmUsuarios));
            }
            else
            {
                MessageBox.Show("No tiene permiso para ingresar a este fomrulario");
            }
        }

        private void FormNuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (Session.GetInstance.IsInRole(PermissionsEnum.PuedeHacerG))
            {
                //createForm(typeof(frmNuevo));
            }
            else
            {
                MessageBox.Show("no tiene permisos");
            }
        
        }

        private void VentasToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //try
            //{
            //    //VentasServiece ventasServiece = new VentasServiece();
            //    //ventasServiece.Facturar();
            //}
            //catch (Exception ex)
            ////{
            ////    MessageBox.Show(ex.Message);
                
            //}

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            updateLanguage(Session.GetInstance.language);
            label1.Text = Session.GetInstance.usuario.Name.ToString();

            if (label1.Text == "admin")
            {
                Form frm = new frmGerente();
                frm.MdiParent = this;
                frm.Show();
            }

          }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            

        }
        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Session.GetInstance.removeObserber(this);

            sesionService.Logout();
            Application.Exit();
        }

        private void createForm(Type formType)
        {
            foreach (Form f in (this.MdiChildren.ToList()))
            {
                if (f.GetType().Equals(formType))
                {
                    f.Focus();
                    return;
                }
            }
           
            Form frm = (Form) Activator.CreateInstance(formType);
            frm.MdiParent = this;
            frm.Show();
        }

        public void updateLanguage(Language language )
        {
           foreach(Control control in Controls)
           {
                control.Text = language.Translations.Find(
                        (translation) => translation.Key.Equals(control.Tag)
                    )?.Translate ?? control.Text;
                if (control.GetType().Equals(typeof(MenuStrip)) && ((MenuStrip)control).Items.Count != 0 )
                {
                    updateToolStrip(language, ((MenuStrip)control).Items);
                }
           }
        }
        public void updateToolStrip(Language language, ToolStripItemCollection parent)
        {
            foreach (ToolStripMenuItem control in parent)
            {
                control.Text = language.Translations.Find(
                        (translation) => translation.Key.Equals(control.Tag)
                    )?.Translate ?? control.Text;

                if (control.DropDownItems.Count != 0)
                {
                    updateToolStrip(language, control.DropDownItems);
                }
            }
        }

        private void fileMenu_Click(object sender, EventArgs e)
        {

        }

        private void ingresosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Session.GetInstance.IsInRole(PermissionsEnum.IngresarMaquina))
            {
                Form frm = new frmIngresos();
                frm.MdiParent = this;
                frm.Show();
            }
            else
            {
                MessageBox.Show("No tiene permiso para ingresar a este fomrulario");
            }
        }

        private void controlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Form frm = new frmReparaciones();
            //frm.MdiParent = this;
            //frm.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Session.GetInstance.removeObserber(this);
            sesionService.Logout();
            Application.Exit();
        }

        private void mnuEjemplo_Click(object sender, EventArgs e)
        {

        }

        private void mnuSelectIdioma_Click(object sender, EventArgs e)
        {

        }

        private void reparacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Session.GetInstance.IsInRole(PermissionsEnum.Presupuestar))
            {
                Form frm = new frmReparaciones();
                frm.MdiParent = this;
                frm.Show();
            }
            else
            {
                MessageBox.Show("No tiene permiso para ingresar a este fomrulario");
            }
        }

        private void aprobacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Session.GetInstance.IsInRole(PermissionsEnum.AprobarMaquina))
            {
                Form frm = new Approvals();
                frm.MdiParent = this;
                frm.Show();
            }
            else
            {
                MessageBox.Show("No tiene permiso para ingresar a este fomrulario");
            }
        }

        private void idiomasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Session.GetInstance.IsInRole(PermissionsEnum.ModificarIdiomas))
            {
                Form frm = new testLanguage();
                frm.MdiParent = this;
                frm.Show();
            }
            else
            {
                MessageBox.Show("No tiene permiso para ingresar a este fomrulario");
            }

        }
        private void maquinasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dAsignacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Session.GetInstance.IsInRole(PermissionsEnum.Asignacion)) //CAMBIAR EL ROL
            {
                Form frm = new Asignaciones();
                frm.MdiParent = this;
                frm.Show();
            }
            else
            {
                MessageBox.Show("No tiene permiso para ingresar a este fomrulario");
            }
        }

        private void crearUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
          

            if (Session.GetInstance.IsInRole(PermissionsEnum.CrearUsuario)) //CAMBIAR EL ROL
            {
                Form frm = new frmCreateUser();
                //Form frm = new testLanguage();
                frm.MdiParent = this;
                frm.Show();
            }
            else
            {
                MessageBox.Show("No tiene permiso para ingresar a este fomrulario");
            }
        }

        private void menuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void fCalculadoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmCalculadora();
            //Form frm = new testLanguage();
            frm.MdiParent = this;
            frm.Show();

        }

        private void eDashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmGerente();
            //Form frm = new testLanguage();
            frm.MdiParent = this;
            frm.Show();

        }
    }
} 

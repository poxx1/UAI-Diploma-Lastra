using Models;
using Business;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models.interfaces;
using Models.language;

namespace View
{
    public partial class frmUsuarios : Form, ILanguageObserber
    {
        PermissionsService permissionsService;
        //Family seleccion;
        UserService userService = new UserService();

        private User user;

        public frmUsuarios()
        {
            InitializeComponent();
            Session.GetInstance.addObserber(this);
            permissionsService = new PermissionsService();
        }

        void LlenarTreeView(TreeNode padre, Component c)
        {
            TreeNode hijo = new TreeNode(c.Nombre);
            hijo.Tag = c;
            padre.Nodes.Add(hijo);

            foreach (var item in c.Childs)
            {
                LlenarTreeView(hijo, item);
            }

        }

        void MostrarPermisos(User u)
        {
            this.treeView1.Nodes.Clear();
            TreeNode root = new TreeNode(u.Name);

            foreach (var item in u.Permissions)
            {
                LlenarTreeView(root, item);
            }   

            this.treeView1.Nodes.Add(root);
            this.treeView1.ExpandAll();
        }

        private void CmdConfigurar_Click(object sender, EventArgs e)
        {
            guardarPermisosBtn.Enabled = true;
            resetPasswordBtn.Enabled = true;

            /*user = new User();
            user.Id = ((User)this.cboUsuarios.SelectedItem).Id;
            user.Name = ((User)this.cboUsuarios.SelectedItem).Name;
            user.Password = ((User)this.cboUsuarios.SelectedItem).Password;*/

            user = ((User)this.cboUsuarios.SelectedItem);
            cboUsuarios.DisplayMember = "Name";
            permissionsService.FillUserComponents(user);

            MostrarPermisos(user);

            this.cboFamilias.DataSource = permissionsService.GetAllFamilies();
            this.cboPatentes.DataSource = permissionsService.GetAllPatentes();
        }

        private void AgregarPatente_Click(object sender, EventArgs e)
        {
            if (user != null)
            {
                var patente = (Patent)cboPatentes.SelectedItem;
                if (patente != null)
                {
                    if (user.Permissions.Where(permission => (permissionsService.Contains(permission, patente))).ToList().Count() > 0)
                        MessageBox.Show("El usuario ya tiene la patente indicada");
                    else
                    {
                        
                    user.Permissions.Add(patente);
                    MostrarPermisos(user);
                        
                    }
                }
            }
            else
                MessageBox.Show("Seleccione un usuario");
        }

        private void AgregarFamilia_Click(object sender, EventArgs e)
        {
            if (user != null)
            {
                Family family = (Family)cboFamilias.SelectedItem;
                if (family != null)
                {
                   
                    if (user.Permissions.Where(permission => (permissionsService.Contains(permission, family))).ToList().Count() > 0)
                        MessageBox.Show("El usuario ya tiene la familia indicada");
                    else
                    {
                        permissionsService.FillFamilyComponents(family);
                        user.Permissions.Add(family);
                        MostrarPermisos(user);
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione un usuario");
            }
                
        }

        private void CmdGuardarFamilia_Click(object sender, EventArgs e)
        {
            if (user == null)
            {
                MessageBox.Show("Seleccione un usuario");
                return;
            }

            try
            {
                userService.SavePermissions(user);
                MessageBox.Show("User guardado correctamente");
            }
            catch (Exception)
            {

                MessageBox.Show("Error al guardar el usuario");
            }
        }

        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            updateLanguage(Session.GetInstance.language);

            UserService userService = new UserService();
            permissionsService = new PermissionsService();
            this.cboUsuarios.DataSource = userService.GetAll();
            cboUsuarios.DisplayMember = "Name";

            eliminarFamiliaBtn.Enabled = false;
            agregarFamiliaBtn.Enabled = false;
            eliminarPatenteBtn.Enabled = false;
            agregarPatenteBtn.Enabled = false;

            guardarPermisosBtn.Enabled = false;
            resetPasswordBtn.Enabled = false;
        }

        private void cboPatentes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (user != null)
            {
                Patent patente = (Patent)cboPatentes.SelectedItem;
                if (patente != null)
                {
                   
                    if (user.Permissions.Where(permission => (permissionsService.Contains(permission, patente))).ToList().Count() > 0)
                    {
                        eliminarPatenteBtn.Enabled = true;
                        agregarPatenteBtn.Enabled = false;
                    }
                    else
                    {
                        eliminarPatenteBtn.Enabled = false;
                        agregarPatenteBtn.Enabled = true;
                    }
                }
            }
        }

        private void cboFamilias_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (user != null)
            {
                Family family = (Family)cboFamilias.SelectedItem;
                if (family != null)
                {

                    if (user.Permissions.Where(permission => (permissionsService.Contains(permission, family))).ToList().Count() > 0)
                    {
                        eliminarFamiliaBtn.Enabled = true;
                        agregarFamiliaBtn.Enabled = false;
                    }
                    else
                    {
                        eliminarFamiliaBtn.Enabled = false;
                        agregarFamiliaBtn.Enabled = true;
                    }
                }
            }
        }

        private void eliminarPatenteBtn_Click(object sender, EventArgs e)
        {
            if (user != null)
            {
                Patent patent = (Patent)cboPatentes.SelectedItem;
                if (patent != null)
                {
                    if (user.Permissions.Where(permission => (permissionsService.Contains(permission, patent))).ToList().Count() > 0)
                    {
                        user.Permissions.Remove(patent);
                        MostrarPermisos(user);
                    }
                }
            }
            else
                MessageBox.Show("Seleccione un usuario");
        }

        private void eliminarFamiliaBtn_Click(object sender, EventArgs e)
        {
            if (user != null)
            {
                Family family = (Family)cboFamilias.SelectedItem;
                if (family != null)
                { 
                    user.Permissions.Remove(user.Permissions.Where(component => family.Id == component.Id).FirstOrDefault());
                    MostrarPermisos(user);
                }
            }
        }

        private void resetPasswordBtn_Click(object sender, EventArgs e)
        {
            userService.ResetPassword(user);

            MessageBox.Show("La password solicitada fue reseteada!");
        }

        private void cboUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmUsuarios_FormClosed(object sender, FormClosedEventArgs e)
        {
            Session.GetInstance.removeObserber(this);
        }

        public void updateLanguage(Language language)
        {
            try
            {
                foreach (Control control in Controls)
                {
                    control.Text = language.Translations.Find(
                            (translation) => translation.Key.Equals(control.Tag)
                        )?.Translate ?? control.Text;
                    if (control.Controls.Count != 0)
                    {
                        updateLanguageRecursiveControls(language, control.Controls);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void updateLanguageRecursiveControls(Language language, Control.ControlCollection parent)
        {
            foreach (Control control in parent)
            {
                control.Text = language.Translations.Find(
                        (translation) => translation.Key.Equals(control.Tag)
                    )?.Translate ?? control.Text;

                if (control.Controls.Count != 0)
                {
                    updateLanguageRecursiveControls(language, control.Controls);
                }
            }
        }

        private void grpPatentes_Enter(object sender, EventArgs e)
        {

        }
    }
}

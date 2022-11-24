using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models;
using Utiles;

namespace Business
{
    public class MensajeBienvenidaService
    {
        public bool mostrarMensajes()
        {
            JsonWork jw = new JsonWork();

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            path = path + @"\Extras\jason.json"; //, "content.html"

            foreach (MensajeBienvenidaModel mensaje in jw.DeserializarMensaje(jw.ReadJson(path)))
            {
                MessageBox.Show(mensaje.mensaje); //Descomentar no seas boludo
            }
            return true;
        }
    }
}

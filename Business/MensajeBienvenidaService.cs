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

            foreach(MensajeBienvenidaModel mensaje in jw.DeserializarMensaje(jw.ReadJson(@"D:\Diploma-Lastra\Extras\jason.json")))
            {
                //MessageBox.Show(mensaje.mensaje); Descomentar no seas boludo
            }
            return true;
        }
    }
}

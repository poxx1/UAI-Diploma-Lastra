using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models;
using Newtonsoft.Json;

namespace Utiles
{
    public class JsonWork
    {
        public string ReadJson(string Path)
        {
            StreamReader sr = new StreamReader(Path);
            string jason = sr.ReadToEnd();
            sr.Dispose();
            sr.Close();
            return jason;
        }
        public bool SaveJson(string Path, string Json)
        {
            try
            {
                StreamWriter sr = new StreamWriter(Path);
                sr.Write(Json);
                return true;
            }
            catch (Exception ex) { MessageBox.Show("se pincho cuando queria escribir el archivo" + ex.Message); return false; }
        }

        public List<MensajeBienvenidaModel> DeserializarMensaje(string json)
        {
            try
            {
                List<MensajeBienvenidaModel> lista = JsonConvert.DeserializeObject<List<MensajeBienvenidaModel>>(json);
                return lista;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de lectura");
                return new List<MensajeBienvenidaModel>();
            }
          }

        public string SerializarMensaje(List<MensajeBienvenidaModel> lista)
        {
            string json = JsonConvert.SerializeObject(lista, Formatting.Indented);
            return json;
        }
    }
}

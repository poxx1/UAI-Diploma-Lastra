using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public static class NotificationService
    {
        public static void SendMail(String mailText , String mail)
        {
            //a modo ilustrativo, se genera un archivo de texto en el escritorio
            string DesktopPath = Environment.GetFolderPath(System.Environment.SpecialFolder.DesktopDirectory);
            FileStream fs = new FileStream(DesktopPath + @"\" + mail + @".txt", FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.BaseStream.Seek(0, SeekOrigin.End);
            sw.WriteLine(mailText);
            sw.Flush();
            sw.Close();
        }
    }
}

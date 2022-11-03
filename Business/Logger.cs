using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DataAccess;
using Utiles;

namespace Business
{
    public class Logger
    {
        public string getCurrentTime()
        {
            //Para no tener problemas con las fechas, le hardcodeo a la verga la cultura y siempre
            //me mantiene el mismo formato. Si en la bd lo guardo como date y no como string soy un tarado.
            CultureInfo.CurrentCulture = new CultureInfo("en-US",false);
            return DateTime.Now.ToString("HH:mm:ss");
        }
        public string getCurrentDate()
        {
            //Para no tener problemas con las fechas, le hardcodeo a la verga la cultura y siempre
            //me mantiene el mismo formato. Si en la bd lo guardo como date y no como string soy un tarado.
            CultureInfo.CurrentCulture = new CultureInfo("en-US", false);
            return DateTime.Now.ToString("dd/MM/yy");
        }
        public string getCurrentUser()
        {
            return Session.GetInstance.usuario.Name;
        }
        public int getCurrentUserID()
        {
            return Session.GetInstance.usuario.Id;
        }

        public bool LogData(string actividad, string informacion)
        {
            LogModel log = new LogModel();
            log.Usuario = getCurrentUser();
            log.UserID = getCurrentUserID(); 
            log.Hora = getCurrentTime();
            log.Fecha = getCurrentDate();
            log.Details = actividad;
            log.Info = informacion;

            LogRepository logRepo = new LogRepository();

            return logRepo.saveLog(log);
        }

        public List<LogModel> ListLogs()
        {
            LogRepository log = new LogRepository();
            return log.listLogs();
        }
    }
}

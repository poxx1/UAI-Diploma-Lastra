using DataAccess;
using Models.language;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class LanguageService
    {
        private LanguageRepository languageRepository;
        public LanguageService()
        {
            languageRepository = new LanguageRepository();
        }
        public List<Language> GetLanguagesForCombo()
        {
            return languageRepository.GetAllLanguagesWithoutTranslations();
        }   

        public Language GetLanguage(string key)
        {
            return languageRepository.GetLanguage(key);
        }
        public DataTable GetLanguageDataTable(int ID)
        {
            return languageRepository.GetLanguageDataTable(ID);
        }

        public void InsertNewLanguage(DataTable dt, string name)
        {
            languageRepository.InsertNewLanguage(dt,name);
        }

        public void saveLanguage(DataTable dt, int id)
        {
            languageRepository.saveLanguage(dt, id);
        }

        public int CreateLanguage(string name)
        {
           languageRepository.CreateLanguage(name);
            return GetLanguage(name).ID;
        }
    }
}

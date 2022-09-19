using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.language;

namespace Models.interfaces
{
    public interface ILanguageObserbable
    {
        List<ILanguageObserber> languageObserbers { get; set; }
        void addObserber(ILanguageObserber languageObserber);
        void removeObserber(ILanguageObserber languageObserber);
        void notifyObserbers(Language languaje);
    }
}

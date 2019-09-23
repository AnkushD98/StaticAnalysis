using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PredefinedAcceptedLevelsAbsoluteGating
{
    public class AcceptedLevels
    {
        public readonly Dictionary<string, int> dictionaryLevels = new Dictionary<string, int>(){
            { "Level1", 5 },
            { "Level2", 10 },
            {"Level3", 20 },
            {"Level4", 40 },
            { "Level5", 70 }
        };
    }    
        
}

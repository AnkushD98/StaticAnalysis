using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PredefinedAcceptedLevelsAbsoluteGating
{
    public class ValidityOfUserInput
    {
        public bool CheckValidityOfUserInput(string acceptableLevel)
        {
            AcceptedLevels acceptedLevels = new AcceptedLevels();
            if (acceptedLevels.dictionaryLevels.ContainsKey(acceptableLevel))
                return true;
            return false;
            
        }
    }
}

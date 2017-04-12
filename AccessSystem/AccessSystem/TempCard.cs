using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessSystem
{
    class TempCard : AccessCard
    {
        public readonly int PastIdentifier;
        public readonly DateTime dateOfEnd;

        public TempCard(int identifier, DateTime dateOfGetting, int pastIdentifier, DateTime dateOfEnd)
        {
            this.identifier = identifier;
            this.dateOfGetting = dateOfGetting;
            this.PastIdentifier = pastIdentifier;
            this.dateOfEnd = dateOfEnd;
        }


    }
}

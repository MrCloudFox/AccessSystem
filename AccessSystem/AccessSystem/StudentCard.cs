using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessSystem
{
    class StudentCard : AccessCard
    {
        public readonly DateTime dateOfEnd;

        public StudentCard(int identifier, DateTime dateOfGetting, DateTime dateOfEnd)
        {
            this.identifier = identifier;
            this.dateOfGetting = dateOfGetting;
            this.dateOfEnd = dateOfEnd;
        }
        

    }
}

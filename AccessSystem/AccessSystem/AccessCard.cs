using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessSystem
{
    class AccessCard
    {
        protected int identifier;
        protected DateTime dateOfGetting = new DateTime();


        public int Identifier
        {
            get { return identifier; }
        }

        public DateTime DateOfGetting
        {
            get { return dateOfGetting; }
        }
    }
}

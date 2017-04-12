using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessSystem
{
    class TeacherCard : AccessCard
    {
        public readonly String Speciality;

        public TeacherCard(int identifier, DateTime dateOfGetting, String Speciality)
        {
            this.identifier = identifier;
            this.dateOfGetting = dateOfGetting;
            this.Speciality = Speciality;
        }


    }
}

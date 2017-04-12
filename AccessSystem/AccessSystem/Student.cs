using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessSystem
{
    class Student
    {
        public readonly String fullName;
        private StudentCard studentCard;
        public readonly String speciality;
        public readonly String numberOfGroup;



        public Student(String fullName, StudentCard studentCard, String speciality, String numberOfGroup, User user)
        {
            this.fullName = fullName;
            this.studentCard = studentCard;
            this.speciality = speciality;
            this.numberOfGroup = numberOfGroup;
            
        }


        public StudentCard StudentCard
        {
            get
            {
                return studentCard;
            }
            set
            {
                studentCard = value;
            }
        }



    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessSystem
{
    class Teacher
    {
        public readonly String fullName;
        public readonly TeacherCard teacherCard;
        public readonly String Faculty;
        public readonly User user;

        public Teacher(String fullName, TeacherCard teacherCard, String Faculty, User user)
        {
            this.fullName = fullName;
            this.teacherCard = teacherCard;
            this.Faculty = Faculty;
            this.user = user;

        }


    }
}

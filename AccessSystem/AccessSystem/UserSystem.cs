using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AccessSystem
{
    class UserSystem
    {
         
        public void RegistrationOfStudent(String fullName, StudentCard studentCard, String speciality, String numberOfGroup, User user)
        {

            using (var sw = new StreamWriter("Students.csv", true, Encoding.UTF8))
            {
                //sw.WriteLine("Ячейка1;Ячейка2;Ячейка3");
                sw.WriteLine(fullName + ";" + speciality + ";" + numberOfGroup + ";" + studentCard.Identifier + ";" + studentCard.DateOfGetting + ";"
                    + studentCard.dateOfEnd + ";" + user.login + ";" + user.pass + ";" + user.isStudent);
            }
        }


        public void RegistrationOfTeacher(String fullName, TeacherCard teacherCard, String faculty, User user)
        {

            using (var sw = new StreamWriter("Teachers.csv", true, Encoding.UTF8))
            {
                //sw.WriteLine("Ячейка1;Ячейка2;Ячейка3");
                sw.WriteLine(fullName + ";" + faculty + ";" + teacherCard.Identifier + ";" + teacherCard.DateOfGetting + ";" +
                    teacherCard.Speciality + ";" + user.login + ";" + user.pass + ";" + user.isStudent);
            }
        }


        public static bool Autorisation(string login, string pass)
        {
            string[] csvUsers = File.ReadAllLines("Users.csv");
            
            for(int i = 0; i < csvUsers.Count(); i++)
            {
                if (csvUsers[i].Split(';')[0] == login &&
                    csvUsers[i].Split(';')[1] == pass)
                    return true;
            }

            return false;
        }


        public void MakeTempCard(User user)
        {

            TempCard CreatedTempCard = null;

            if (user.isStudent)
            {
                string[] student = File.ReadAllLines("Students.csv");
                for (int i = 0; i < student.Count(); i++)
                {
                    if (student[i].Split(';')[6] == user.login && student[i].Split(';')[7] == user.pass)
                        CreatedTempCard = new TempCard(Convert.ToInt32(student[student.Count() - 1].Split(';')[3]) + 1,
                            DateTime.Today, Convert.ToInt32(student[i].Split(';')[3]), DateTime.Today.AddMonths(1));
                }
            }
            else
            {
                string[] teacher = File.ReadAllLines("Teachers.csv");
                for (int i = 0; i < teacher.Count(); i++)
                {
                    if (teacher[i].Split(';')[5] == user.login && teacher[i].Split(';')[6] == user.pass)
                        CreatedTempCard = new TempCard(Convert.ToInt32(teacher[teacher.Count() - 1].Split(';')[2]) + 1,
                            DateTime.Today, Convert.ToInt32(teacher[i].Split(';')[2]), DateTime.Today.AddMonths(1));
                }
            }


            using (var sw = new StreamWriter("TempCards.csv", true, Encoding.UTF8))
            {
                //sw.WriteLine("Ячейка1;Ячейка2;Ячейка3");
                if (CreatedTempCard != null)
                {
                    sw.WriteLine(CreatedTempCard.Identifier + ";" +
                        CreatedTempCard.DateOfGetting + ";" + CreatedTempCard.PastIdentifier + ";" + CreatedTempCard.dateOfEnd);
                }
            }

        }


    }
}

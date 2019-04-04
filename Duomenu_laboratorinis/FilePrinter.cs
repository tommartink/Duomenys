using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Duomenu_laboratorinis
{
    class FilePrinter
    {
    public void generateFile(List<Student> students)
        {
            String fileName = "StudentList" + students.Count + ".txt";
            StreamWriter File = new StreamWriter(fileName);
            File.WriteLine("Vardas Pavardė ND1 ND2 ND3 ND4 ND5 Egzaminas");
            for(int i = 0; i < students.Count; i++)
            {
                List<double> homeworks = students[i].getHomework();
                File.Write(students[i].getName() + " " + students[i].getSurname() + " ");
                for (int j = 0; j < homeworks.Count; j++)
                {
                    File.Write(homeworks[j] + " ");
                }
                File.WriteLine(students[i].getEgzam());
            }
            File.Close();
        }
    }
}

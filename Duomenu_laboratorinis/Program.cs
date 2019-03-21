using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Duomenu_laboratorinis
{
    class Program
    {
        static void Main(string[] args)
        {
              class Program
        {
            static void Main(string[] args)
            {
                List<Student> students = new List<Student>();
                Student[] my_d = new Student[1];
                String check = "t";
                int counter = 0;
                while (check.Equals("t"))
                {
                    String name;
                    Console.WriteLine("Įveskite studento Vardą");
                    name = System.Console.ReadLine();
                    Console.WriteLine("Įveskite studento Pavardę");
                    students.Add(new Student(name, System.Console.ReadLine()));
                    Console.WriteLine("Įveskite studento namų darbų pažymius");
                    students[counter].setHomework(System.Console.ReadLine());
                    Console.WriteLine("Įveskite studento egzamino pažymį");
                    students[counter].setEgzam(Double.Parse(System.Console.ReadLine()));
                    counter++;
                    Console.WriteLine("Įveskite 't' jei norite ivesti dar viena studenta");
                    check = Console.ReadLine().ToLower();
                }
                Console.WriteLine("Vardas" + "\t\t" + "Pavarde" + "\t\t" + "Galutinis (vid.)/Galutinis (Med.)");
                Console.WriteLine("-----------------------------------------------------------------");

                for (int i = 0; i < students.Count; i++)
                {
                    students[i].WriteMyInfo();
                }

            }

            class Student
            {
                String name;
                String surname;
                double egzam;
                List<double> homework = new List<double>();
                double endmark;
                double endmarkMedian;

                public Student(String name, String surname)
                {
                    this.name = name;
                    this.surname = surname;
                }
                public void WriteMyInfo()
                {
                    countEndmark();
                    countEndmarkMedian();
                    // Console.WriteLine(name+ "\t\t"+ surname + "\t\t" + Math.Truncate(endmark * 100) / 100 + "\t" + Math.Truncate(endmarkMedian * 100) / 100);

                    Console.WriteLine("{0,0}{1,20}{2,40}{3,50}", name, surname, Math.Truncate(endmark * 100) / 100, Math.Truncate(endmarkMedian * 100) / 100);
                }
                private void countEndmark()
                {
                    double average = homework.Count > 0 ? homework.Average() : 0.0;
                    endmark = average * 0.3 + egzam * 0.7;
                }
                private void countEndmarkMedian()
                {
                    var ds = homework;
                    ds.Sort();
                    int count = 0;
                    foreach (double d in ds.ToList())
                    {
                        homework[count] = d;
                        count++;
                    }
                    double median;
                    if (homework.Count % 2 == 0)
                    {
                        double f = homework[homework.Count / 2 - 1];
                        double s = homework[homework.Count / 2];
                        median = (f + s) / 2.0;
                    }
                    else median = homework[homework.Count / 2];
                    endmarkMedian = median * 0.3 + egzam * 0.7;
                }
                public void setEgzam(double egzam) { this.egzam = egzam; }
                public void setHomework(String markline)
                {
                    string[] list = markline.Split();
                    for (int i = 0; i < list.Length; i++)
                    {
                        homework.Add(double.Parse(list[i]));
                    }
                }
            }

        }
    }
    }
}

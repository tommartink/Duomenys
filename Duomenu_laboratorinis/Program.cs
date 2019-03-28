using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Duomenu_laboratorinis
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();

            Console.WriteLine("Įveskite r jei norite duomenis vesti ranka arba f jei norite duomenis duoti iš failo");
            String input = System.Console.ReadLine();

            if (input.Equals("f"))
            {
                Console.WriteLine("Įrašykite pilną kelią iki failo ir jo pavadinimą.");
                String location = System.Console.ReadLine();
                StreamReader sr = new StreamReader(location, Encoding.GetEncoding(1257));
                string headercheck = sr.ReadLine();
                if (headercheck.Equals("Vardas Pavardė ND1 ND2 ND3 ND4 ND5 Egzaminas"))
                {
                    String eilute;
                    int counter = 0;
                    while ((eilute = sr.ReadLine()) != null)
                    {
                        String[] duomenys = eilute.Split(' ');
                        students.Add(new Student(duomenys[0],duomenys[1]));
                        String homework = ""; 
                        for(int i = 2; i < duomenys.Length - 1; i++)
                        {
                            homework += duomenys[i] + " ";
                        }
                        if(!homework.Equals(""))homework = homework.Substring(0,homework.Length - 1);
                        students[counter].setHomework(homework);
                        students[counter].setEgzam(Double.Parse(duomenys[duomenys.Length-1]));
                        counter++;
                    }
                }

            }
            if (input.Equals("r")) { 
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
        }
            if (input.Equals("f") || input.Equals("r"))
            {
                IEnumerable <Student> orderbyname = students.OrderBy(p => p.getName());
                Console.WriteLine("{0,-15}{1,-15}{2,-10}{3,-10}", "Vardas", "Pavarde", "Galutinis (vid.)","Galutinis (vid.)");

                
                Console.WriteLine("----------------------------------------------------------");

                foreach (Student studenchik in orderbyname)
                {
                    studenchik.WriteMyInfoAvg();
                }
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
            public String getName() { return name; }
                public void WriteMyInfoAvg()
            {
                countEndmark();
                countEndmarkMedian();
                Console.WriteLine("{0,-15}{1,-15}{2,-16}{3,-10}", name, surname, Math.Truncate(endmark * 100) / 100, Math.Truncate(endmarkMedian * 100) / 100);
            }

                private void countEndmark()
                {
                if (homework.Count == 1 && homework[0] == 0)
                {
                    endmark = 0;
                    return;
                }
                    double average = homework.Count > 0 ? homework.Average() : 0.0;
                    endmark = average * 0.3 + egzam * 0.7;
                }
                private void countEndmarkMedian()
                {
                if (homework.Count == 1 && homework[0] == 0)
                {
                    endmarkMedian = 0;
                    return;
                }
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
                public void generateGrades()
            {
                Random rnd = new Random();
                egzam = rnd.Next(2,11);
                int marks = rnd.Next(4, 8);
                for(int i = 0; i <marks; i++)
                {
                    homework.Add(rnd.Next(2,11));
                }
            }
                public void setHomework(String markline)
                {
                if (markline.Equals(""))
                {
                    homework.Add(0);
                    return;
                }
                    string[] list = markline.Split();
                    for (int i = 0; i < list.Length; i++)
                    {
                    var numb = double.Parse(list[i]);
                    homework.Add(numb);
                    }
                }
            }

        }

}

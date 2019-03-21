using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Duomenu_laboratorinis
{
    class ApdorojimasSuMasyvu
    {
        static void NotMain(string[] args)
        {
            Student[] students = new Student[1];

            String check = "t";
            int counter = 1;

            while (check.Equals("t"))
            {
                String name;
                Console.WriteLine("Įveskite studento Vardą");
                name = System.Console.ReadLine();
                Console.WriteLine("Įveskite studento Pavardę");
                students[counter] = (new Student(name, System.Console.ReadLine()));
                Console.WriteLine("Įveskite studento namų darbų pažymius");
                students[counter].setHomework(System.Console.ReadLine());
                Console.WriteLine("Įveskite studento egzamino pažymį");
                students[counter].setEgzam(Double.Parse(System.Console.ReadLine()));
                counter++;
                Console.WriteLine("Įveskite 't' jei norite ivesti dar viena studenta");
                check = Console.ReadLine().ToLower();
                if (check.Equals("t")) Array.Resize(ref students, counter + 1);
            }

            Console.WriteLine("Įveskite 'v' jei norite kad pazymis butu skaiciuojamas pagal vidurki, iveskite kita klavisa jeigu paga mediana");
            String taipne = Console.ReadLine();
            bool flag = taipne.Equals("v");
            if (flag) Console.WriteLine("{0,-15}{1,-15}{2,-10}", "Vardas", "Pavarde", "Galutinis (vid.)");

            else Console.WriteLine("{0,-15}{1,-15}{2,-10}", "Vardas", "Pavarde", "Galutinis (med.)");
            Console.WriteLine("----------------------------------------------");

            for (int i = 0; i < students.Length; i++)
            {
                if (students[i] == null) break;
                if (flag) students[i].WriteMyInfoAvg();
                else students[i].WriteMyInfoMed();
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
            public void WriteMyInfoAvg()
            {
                countEndmark();
                Console.WriteLine("{0,-15}{1,-15}{2,-10}", name, surname, Math.Truncate(endmark * 100) / 100);
            }
            public void WriteMyInfoMed()
            {

                countEndmarkMedian();
                Console.WriteLine("{0,-15}{1,-15}{2,-10}", name, surname, Math.Truncate(endmarkMedian * 100) / 100);

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
            public void generateGrades()
            {
                Random rnd = new Random();
                egzam = rnd.Next(2, 11);
                int marks = rnd.Next(4, 8);
                for (int i = 0; i < marks; i++)
                {
                    homework.Add(rnd.Next(2, 11));
                }
            }
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

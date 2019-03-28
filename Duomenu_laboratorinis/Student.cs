using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Duomenu_laboratorinis
{
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
        public void setEgzam(double egzam) {
            if (egzam > 10 || egzam < 0) throw new Exception("Netinkamas pažimys");
            this.egzam = egzam;
        }
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
            if (markline.Equals(""))
            {
                homework.Add(0);
                return;
            }
            string[] list = markline.Split();
            for (int i = 0; i < list.Length; i++)
            {
                var numb = double.Parse(list[i]);
                if (numb > 10 || numb < 0) throw new Exception("Netinkamas pažimys");
                homework.Add(numb);
            }
        }
    }
}

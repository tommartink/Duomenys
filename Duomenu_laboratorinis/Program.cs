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
        static List<Student> students = new List<Student>();
        static void Main(string[] args)
        {


            Console.WriteLine("Įveskite r jei norite duomenis vesti ranka arba f jei norite duomenis duoti iš failo");
            String input = System.Console.ReadLine();

            if (input.Equals("f"))
            {
                readFile();
            }
            if (input.Equals("r")) {
                readKeyboard();
            }
            if (input.Equals("f") || input.Equals("r"))
            {
                printData();
            }
            }

        static private void readFile()
        {
            Boolean end = true;
            while (end) { 
                try
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
                            students.Add(new Student(duomenys[0], duomenys[1]));
                            String homework = "";
                            for (int i = 2; i < duomenys.Length - 1; i++)
                            {
                                homework += duomenys[i] + " ";
                            }
                            if (!homework.Equals("")) homework = homework.Substring(0, homework.Length - 1);
                            students[counter].setHomework(homework);
                            students[counter].setEgzam(Double.Parse(duomenys[duomenys.Length - 1]));
                            counter++;
                        }
                    }
                    end = false;
                }
                catch (FileNotFoundException ex)
                {
                    Console.WriteLine("Pasirinktas blogas failas bandykite dar karta.");
                }
                catch(ArgumentException ex)
                {
                    Console.WriteLine("Pasirinktas blogas kelias iki failo bandykite dar karta.");
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Patikrinkite ar kelias iki failo yra teisingas ir bandykite dar karta.");
                }
                
        }
        }

        static private void readKeyboard()
        {
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

        static private void printData()
        {
            IEnumerable<Student> orderbyname = students.OrderBy(p => p.getName());
            Console.WriteLine("{0,-15}{1,-15}{2,-10}{3,-10}", "Vardas", "Pavarde", "Galutinis (vid.)", "Galutinis (vid.)");


            Console.WriteLine("----------------------------------------------------------");

            foreach (Student studenchik in orderbyname)
            {
                studenchik.WriteMyInfoAvg();
            }
        }

    }

}

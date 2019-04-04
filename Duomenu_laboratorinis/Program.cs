using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Text.RegularExpressions;

namespace Duomenu_laboratorinis
{
    class Program
    {
        static List<Student> students = new List<Student>();
        static void Main(string[] args)
        {


            Console.WriteLine("Įveskite r jei norite duomenis vesti ranka arba f jei norite duomenis duoti iš failo");
            Console.WriteLine("Įveskite rf jei norite prirašytu random reiksmių į failą");
            String input = System.Console.ReadLine();

            if (input.Equals("f"))
            {
                readFile();
            }
            if (input.Equals("r")) {
                readKeyboard();
            }
            if (input.Equals("rf"))
            {
                randomFile();
            }
            if (input.Equals("f") || input.Equals("r")||input.Equals("rf"))
            {
                printData();
                Console.WriteLine("Įveskite raidę t jei norite duomenis išsaugoti faile");
                if (System.Console.ReadLine().Equals("t"))
                {
                    FilePrinter print = new FilePrinter();
                    print.generateFile(students);
                }
            }
            }
        static private void randomFile()
        {
            Boolean checker = true;
            while (checker) { 
            try
            {
                Console.WriteLine("Įrašykite kiek studentų norite sugeneruoti");
                String line = System.Console.ReadLine();
                int countas = Int32.Parse(line);
                    for (int i = 1; i < countas+1 ;i++) {
                        Console.WriteLine(i);
                        students.Add(new Student(i));

                    }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Įvėdėte ne skaičių bandykite dar kartą");
                    continue;
            }
                checker = false;
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
                    sr.ReadLine();
                        String eilute;
                        int counter = 0;
                        while ((eilute = sr.ReadLine()) != null)
                        {
                            eilute = Regex.Replace(eilute, @"\s+", " ");
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
            Boolean end = true;
            while (end)
            {
                try
                {
                    while (check.Equals("t"))
                    {
                        Student candidate;
                        String name;
                        Console.WriteLine("Įveskite studento Vardą");
                        name = System.Console.ReadLine();
                        if (name.Equals(""))
                        {
                            Console.WriteLine("Studento vardas yra privalomas");
                            continue;
                        }
                        Console.WriteLine("Įveskite studento Pavardę");
                        String lastname = System.Console.ReadLine();
                        if (lastname.Equals(""))
                        {
                            Console.WriteLine("Studento pavardė yra privaloma");
                            continue;
                        }
                        candidate = new Student(name, lastname);
                        try
                        {
                            Console.WriteLine("Įveskite studento namų darbų pažymius.(Pažymius atskirkite tarpais)");
                            String homeworkline = System.Console.ReadLine();
                            if (homeworkline.Equals(""))
                            {
                                Console.WriteLine("Studentas privalo būti įvygdęs bent viena namų darbą bandykite dar kartą.");
                                continue;
                            }
                            candidate.setHomework(homeworkline);
                        }
                        catch (FormatException ex)
                        {
                            Console.WriteLine("Blogai įrašyti namų darbai bandykite dar kartą.");
                            continue;
                        }
                        Console.WriteLine("Įveskite studento egzamino pažymį");
                        try
                        {
                            string[] list = System.Console.ReadLine().Split();
                            candidate.setEgzam(Double.Parse(list[0]));
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Blogai įrašytas egzamino pažimys bandykite dar kartą");
                            continue;
                        }
                        students.Add(candidate);
                        Console.WriteLine("Įveskite 't' jei norite ivesti dar viena studenta");
                        check = Console.ReadLine().ToLower();
                    }
                    end = false;
                }
                catch (Exception ex) {
                    Console.WriteLine("Blogai įrašėte įraša bandykite dar kartą.");
                }
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

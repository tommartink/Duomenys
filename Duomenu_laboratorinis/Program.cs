using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Duomenu_laboratorinis
{
    class Program
    {
        static List<Student> students = new List<Student>();
        static List<Student> upper = new List<Student>();
        static List<Student> lower = new List<Student>();
        static LinkedList<Student> studentslinked = new LinkedList<Student>();
        static LinkedList<Student> upperlinked = new LinkedList<Student>();
        static LinkedList<Student> lowerlinked = new LinkedList<Student>();
        static Queue<Student> studentsqueue = new Queue<Student>();
        static Queue<Student> upperqueue = new Queue<Student>();
        static Queue<Student> lowerqueue = new Queue<Student>();
        static String testFile;
        static void Main(string[] args)
        {

            Console.WriteLine("Įveskite t jei norite išbandyti programos 2 strategijų palyginimus");
            Console.WriteLine("Įveskite bet ką kitą jei norite matyti kitus pasirinkimus");
            String strat = System.Console.ReadLine();
            if (strat.Equals("t"))
            {
                SpartosVeikimotestas(false);
              //  students = new List<Student>();
                AntraStategijaTest();
            }

            Console.WriteLine("Įveskite t jei norite išbandyti programos veikimo spartą");
            Console.WriteLine("Įveskite bet ką kitą jei norite matyti kitus pasirinkimus");
            String input = System.Console.ReadLine();
            if (input.Equals("t"))
            {
                SpartosVeikimotestas(true);
            }
            else Forthversionmenu();

        }

        static private void AntraStategijaTest()
        {
            Console.WriteLine("----------------------------------------------------------------------------------");
            ListTestSecond();
            students.Clear();
            lower.Clear();
        }
        static private void SpartosVeikimotestas(Boolean fifth)
        {
            ListTest(fifth); // testas
            students.Clear(); // nunulinami list sarasai
            upper.Clear();
            lower.Clear();
            LinkedListTest(fifth);//testas
            studentslinked = new LinkedList<Student>();//nunulinami linked sarasai
            upperlinked = new LinkedList<Student>();
            lowerlinked = new LinkedList<Student>();
            QueueTest(fifth);//testas
            studentsqueue = new Queue<Student>();//nunulinami queue sarasai
            upperqueue = new Queue<Student>();
            lowerqueue = new Queue<Student>();
        }
        static private void Forthversionmenu()
        {
            Console.WriteLine("Įveskite r jei norite duomenis vesti ranka arba f jei norite duomenis duoti iš failo");
            Console.WriteLine("Įveskite rf jei norite prirašytu random reiksmių į failą");
            String input = System.Console.ReadLine();
            bool yesno = false;
            Stopwatch timer = new Stopwatch();

            if (input.Equals("f"))
            {
                readFile();
            }
            if (input.Equals("r"))
            {
                readKeyboard();
            }
            if (input.Equals("rf"))
            {
                Console.WriteLine("Įveskite raidę t jei norite duomenis išsaugoti faile");
                yesno = System.Console.ReadLine().Equals("t");
                timer.Start();
                randomFile();
            }
            if (input.Equals("f") || input.Equals("r") || input.Equals("rf"))
            {
                printData();
                if (yesno)
                {
                    FilePrinter print = new FilePrinter();
                    //     print.generateFile(students);
                    print.generateNamedFile(upper, "kietaiakiai");
                    print.generateNamedFile(lower, "nuskriaustukai");
                    timer.Stop();
                    Console.WriteLine("Užduotis įvykdyta per: " + timer.ElapsedMilliseconds + "ms");
                }
            }
        }
        static private void randomFile()
        {
            Boolean checker = true;
            while (checker)
            {
                try
                {
                    Console.WriteLine("Įrašykite kiek studentų norite sugeneruoti");
                    String line = System.Console.ReadLine();
                    int countas = Int32.Parse(line);
                    Random rnd = new Random();
                    for (int i = 1; i < countas + 1; i++)
                    {
                        students.Add(new Student(i, rnd));

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
        static private void ListTest(Boolean Fifthtest)
        {
            Boolean end = true;
            while (end)
            {
                try
                {
                    Console.WriteLine("Įrašykite pilną kelią iki failo, kurį naudosite ir jo pavadinimą.");
                    String location = System.Console.ReadLine();
                    StreamReader sr = new StreamReader(location, Encoding.GetEncoding(1257));

                    sr.ReadLine();
                    String eilute;
                    int counter = 0;
                    Stopwatch stoper = new Stopwatch();
                   if(Fifthtest) stoper.Start();
                    long firstTime = GC.GetTotalMemory(true) / 1024;
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
                    if (Fifthtest) stoper.Stop();
                    testFile = location;
                    sr.Close();
                    if (Fifthtest) Console.WriteLine("Studentų duomenys iš failo buvo nuskaityti per: " + stoper.ElapsedMilliseconds + "ms naudojant List<Student>");
                    if (Fifthtest) stoper.Restart();
                    else stoper.Start();

                    end = false;

                   // IEnumerable<Student> orderbyname = students.OrderBy(p => p.getName());
                    foreach (Student studenchik in students)//nerusiuoja pagal varda
                    {
                        if (studenchik.getEndmark() < 5.0f) lower.Add(studenchik);
                        else upper.Add(studenchik);
                    }
                    stoper.Stop();
                    if(Fifthtest) Console.WriteLine("Studentai buvo išdalinti per: " + stoper.ElapsedMilliseconds + "ms naudojant List<Student>");
                    else{
                        Console.WriteLine("Studentai buvo išdalinti per: " + stoper.ElapsedMilliseconds + "ms naudojant List<Student> pirma strategija");
                        Console.WriteLine("Naudojant List<Student> pirma stategija atminties buvo užimta " + (GC.GetTotalMemory(true) / 1024 - firstTime) + "kb");
                    }
                }
                catch (FileNotFoundException ex)
                {
                    Console.WriteLine("Pasirinktas blogas failas bandykite dar karta.");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("Pasirinktas blogas kelias iki failo bandykite dar karta.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Patikrinkite ar kelias iki failo yra teisingas ir bandykite dar karta.");
                }

            }

        }
        static private void LinkedListTest(Boolean Fifthtest)
        {

            StreamReader sr = new StreamReader(testFile, Encoding.GetEncoding(1257));
            sr.ReadLine();
            String eilute;
            Stopwatch stoper = new Stopwatch();
            long firstTime = GC.GetTotalMemory(true) / 1024;
            if (Fifthtest) stoper.Start();
            while ((eilute = sr.ReadLine()) != null)
            {
                eilute = Regex.Replace(eilute, @"\s+", " ");
                String[] duomenys = eilute.Split(' ');
                Student NewStudent = new Student(duomenys[0], duomenys[1]);
                String homework = "";
                for (int i = 2; i < duomenys.Length - 1; i++)
                {
                    homework += duomenys[i] + " ";
                }
                if (!homework.Equals("")) homework = homework.Substring(0, homework.Length - 1);

                NewStudent.setHomework(homework);
                NewStudent.setEgzam(Double.Parse(duomenys[duomenys.Length - 1]));
                studentslinked.AddLast(NewStudent);
            }
            if(Fifthtest) stoper.Stop();
            sr.Close();
            if(Fifthtest) Console.WriteLine("Studentų duomenys iš failo buvo nuskaityti per: " + stoper.ElapsedMilliseconds + "ms naudojant LinkedList<Student>");
            if (Fifthtest) stoper.Restart();
            else stoper.Start();

           // IEnumerable<Student> orderbyname = studentslinked.OrderBy(p => p.getName());
            foreach (Student studenchik in studentslinked)//nerusiuoja pagal varda
            {
                if (studenchik.getEndmark() < 5.0f) lowerlinked.AddLast(studenchik);
                else upperlinked.AddLast(studenchik);
            }
            stoper.Stop();
            if(Fifthtest)Console.WriteLine("Studentai buvo išdalinti per: " + stoper.ElapsedMilliseconds + "ms naudojant LinkedList<Student>");
            {
                Console.WriteLine("Studentai buvo išdalinti per: " + stoper.ElapsedMilliseconds + "ms naudojant LinkedList<Student> pirma strategija");
                Console.WriteLine("Naudojant LinkedList<Student> pirma stategija atminties buvo užimta " + (GC.GetTotalMemory(true) / 1024 - firstTime) + "kb");
            }
        }

        static private void QueueTest(Boolean FifthTest)
        {
            StreamReader sr = new StreamReader(testFile, Encoding.GetEncoding(1257));
            sr.ReadLine();
            String eilute;
            Stopwatch stoper = new Stopwatch();
            if(FifthTest) stoper.Start();
            long firstTime = GC.GetTotalMemory(true) / 1024;
            while ((eilute = sr.ReadLine()) != null)
            {
                eilute = Regex.Replace(eilute, @"\s+", " ");
                String[] duomenys = eilute.Split(' ');
                Student NewStudent = new Student(duomenys[0], duomenys[1]);
                String homework = "";
                for (int i = 2; i < duomenys.Length - 1; i++)
                {
                    homework += duomenys[i] + " ";
                }
                if (!homework.Equals("")) homework = homework.Substring(0, homework.Length - 1);

                NewStudent.setHomework(homework);
                NewStudent.setEgzam(Double.Parse(duomenys[duomenys.Length - 1]));
                studentsqueue.Enqueue(NewStudent);
            }
            if(FifthTest) stoper.Stop();
            sr.Close();
            if(FifthTest) Console.WriteLine("Studentų duomenys iš failo buvo nuskaityti per: " + stoper.ElapsedMilliseconds + "ms naudojant Queue<Student>");
            if (FifthTest) stoper.Restart();
            else stoper.Start();
            // IEnumerable<Student> orderbyname = studentsqueue.OrderBy(p => p.getName());
            foreach (Student studenchik in studentsqueue)//nerusiuoja pagal varda
            {
                if (studenchik.getEndmark() < 5.0f) lowerqueue.Enqueue(studenchik);
                else upperqueue.Enqueue(studenchik);
            }
            stoper.Stop();
            if(FifthTest)Console.WriteLine("Studentai buvo išdalinti per: " + stoper.ElapsedMilliseconds + "ms naudojant Queue<Student>");
            else
            {
                Console.WriteLine("Studentai buvo išdalinti per: " + stoper.ElapsedMilliseconds + "ms naudojant Queue<Student> pirma strategija");
                Console.WriteLine("Naudojant Queue<Student> pirma stategija atminties buvo užimta " + (GC.GetTotalMemory(true)/1024 - firstTime) +"kb");
            }

        }
        static private void ListTestSecond()
        {
                    StreamReader sr = new StreamReader(testFile, Encoding.GetEncoding(1257));
                    sr.ReadLine();
                    String eilute;
                    int counter = 0;
                    Stopwatch stoper = new Stopwatch();
            long firstTime = GC.GetTotalMemory(true) / 1024;
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

                    sr.Close();
                    stoper.Start();

            // IEnumerable<Student> orderbyname = students.OrderBy(p => p.getName());
            for (int i = students.Count - 1; i >= 0; i--)
            {
                if (students[i].getEndmark() < 5.0f)
                {
                    lower.Add(students[i]);
                    students.RemoveAt(i);
                }
            }
                    stoper.Stop();
                    Console.WriteLine("Studentai buvo išdalinti per: " + stoper.ElapsedMilliseconds + "ms naudojant List<Student> antrą strategija");
                    Console.WriteLine("Naudojant List<Student> antrą stategija atminties buvo užimta " + (GC.GetTotalMemory(true) / 1024 -firstTime) + "kb");
                    
              

        }
        static private void readFile()
        {
            Boolean end = true;
            while (end)
            {
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
                catch (ArgumentException ex)
                {
                    Console.WriteLine("Pasirinktas blogas kelias iki failo bandykite dar karta.");
                }
                catch (Exception ex)
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
                catch (Exception ex)
                {
                    Console.WriteLine("Blogai įrašėte įraša bandykite dar kartą.");
                }
            }
        }

        static private void printData()
        {

            Console.WriteLine("{0,-15}{1,-15}{2,-10}{3,-10}", "Vardas", "Pavarde", "Galutinis (vid.)", "Galutinis (vid.)");


            Console.WriteLine("----------------------------------------------------------");
            IEnumerable<Student> orderbyname = students.OrderBy(p => p.getName());
            foreach (Student studenchik in orderbyname)
            {
                studenchik.WriteMyInfoAvg();
                if (studenchik.getEndmark() < 5.0f) lower.Add(studenchik);
                else upper.Add(studenchik);
            }
        }

    }

}

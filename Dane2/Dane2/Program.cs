using System.Net.NetworkInformation;

namespace Dane2
{
    public class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public long Pesel { get; set; }

        public Person(string name, string surname, long pesel)
        {
            Name = name;
            Surname = surname;
            Pesel = pesel;
        }
        public override string ToString()
        {
            return Name + " " + Surname + " " + Pesel;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            FileStream fs = new FileStream("C:\\Txt\\Dane.txt", FileMode.OpenOrCreate);

            StreamWriter s = new StreamWriter(fs);

            Console.WriteLine("Podaj imie: ");
            string name = Console.ReadLine();

            Console.WriteLine("Podaj nazwisko: ");
            string surname = Console.ReadLine();

            Console.WriteLine("Podaj PESEL: ");
            string pesel = Console.ReadLine();

            string[] pesel_ = new string[pesel.Length];
            int c = 0;
            for (int i = 0; i < pesel.Length; i++)
            {
                pesel_[i] = pesel.Substring(c, 1);
                c++;
            }

           /* int digitChar(const char c)
            {
                return c - '0';
            }*/
/*
            void gender(const char* pesel_)
            {
                Console.WriteLine((digitChar(pesel_[9]) % 2 == 0) ? "kobieta" : "mezczyzna");
            }*/

            //Console.WriteLine(string.Join(" ", pesel_));
            /*char v = pesel[2, 3];
            if (v == 25)
            {
                char pesel_month = pesel[2];
            }*/
            //Console.WriteLine(pesel_);

            s.WriteLine("Imie: " + name);
            s.WriteLine("Nazwisko: " + surname);
            s.WriteLine("PESEL: " + pesel);
            s.WriteLine("Data Ur.: "+ pesel_[3] + " ");
            //s.WriteLine(age);
            //s.WriteLine(gender);
            s.Close();
            fs.Close();
        }
    }
}
using System.Net.NetworkInformation;

namespace Dane2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FileStream fs = new FileStream("G:\\School-main\\School-main\\Imie_Nazwisko_PESEL_itd\\Dane2\\Dane.txt", FileMode.OpenOrCreate);

            StreamWriter s = new StreamWriter(fs);

            Console.WriteLine("Podaj imie: ");
            string name = Console.ReadLine();

            Console.WriteLine("Podaj nazwisko: ");
            string surname = Console.ReadLine();

            Console.WriteLine("Podaj PESEL: ");
            string pesel = Console.ReadLine();

            string[] pesel_ = new string[pesel.Length];
            

            int DigitChar(char c)
            {
                return c - '0';
            }

            string gender;

            void Gender()
            {
                if(pesel[9] % 2 == 0)
                {
                    gender = "Kobieta";
                }
                else
                {
                    gender = "Mężczyzna";
                }
            }

            
           
            s.WriteLine("Imie: " + name);
            s.WriteLine("Nazwisko: " + surname);
            s.WriteLine("PESEL: " + pesel);
            //s.WriteLine(age);
            s.WriteLine(gender);
            s.Close();
            fs.Close();
        }
    }
}
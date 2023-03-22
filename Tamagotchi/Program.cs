using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Tamagotchi
{

    class Tamagoch
    {
        public int live;
        string name { get; set; }
        public Tamagoch(string name, int live)
        {
            this.name = name;
            this.live = live;
        }
        public ref int health_plus(string action)
        {
            if (action == "покормить")
                live += 15;
            else if (action == "погулять")
                live += 20;
            else if (action == "поспать")
                live += 12;
            else if (action == "поиграть")
                live += 23;
            return ref live;
        }
        public ref int health_divid(string action)
        {
            if (action == "покормить")
                live -= 15;
            else if (action == "погулять")
                live -= 20;
            else if (action == "поспать")
                live -= 12;
            else if (action == "поиграть")
                live -= 23;
            return ref live;
        }
        public override string ToString()
        {
            return $"У {name} осталось {live} жизней";
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            string[] action = { "покормить", "погулять", "поспать", "поиграть" };
            string word, word_action;
            int live = 100;
            WriteLine("Введите имя тамагочи");
            string name_tam = Console.ReadLine();
            Tamagoch tm = new Tamagoch(name_tam, live);
            WriteLine(tm);
            do
            {
                int j = rnd.Next(0, 3);
                Write($"Вы хотите {action[j]}? (да или нет):");
                word_action = action[j];
                word = Console.ReadLine();
                if (word == "да")
                {
                    if (word_action == "покормить")
                        tm.health_plus("покормить");
                    else if (word_action == "погулять")
                        tm.health_plus("погулять");
                    else if (word_action == "поспать")
                        tm.health_plus("поспать");
                    else if (word_action == "поиграть")
                        tm.health_plus("поиграть");
                    WriteLine(tm);
                    ReadLine();
                }
                else if (word == "нет")
                {
                    if (word_action == "покормить")
                        tm.health_divid("покормить");
                    else if (word_action == "погулять") 
                        tm.health_divid("погулять");
                    else if (word_action == "поспать")
                        tm.health_divid("поспать");
                    else if (word_action == "поиграть")
                        tm.health_divid("поиграть");
                    WriteLine(tm);
                    ReadLine();
                }
            } while (tm.live > 0 && tm.live< 200);
            if (tm.live< 0)
                WriteLine("тамагочи ушел в мир иной");
            else
                WriteLine("Вы попедили");

        }
    }
}

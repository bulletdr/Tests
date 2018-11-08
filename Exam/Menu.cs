using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestSystemConsole
{
    public class Menu  //головне
    {
        string answer;
        int choice;

        public int Choice
        {
            get { return choice; }
        }

        public void Start()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t=================================================");
            Console.WriteLine("\t=========Автоматизована система тестування=======");
            Console.WriteLine("\t=================================================");
            Console.WriteLine("\t=   1 - Завантажити тест i запустити тестування.=");
            Console.WriteLine("\t=   2 - Меню редагування.                       ="); 
            Console.WriteLine("\t=   0 - Виxiд                                   =");
            Console.WriteLine("\t=================================================");

            Console.Write("\n>Виберiть потрiбну дiю: ");
            choice = Convert.ToInt32(Console.ReadLine());
        }

        public bool Allow()
        {
            Console.Write("\n> Продовжити (y/n)? - ");
            answer = Console.ReadLine();
            return (answer == "y");
        }

        public void Finish()
        {
            Console.WriteLine("\n\nПограма завершена");
        }
    }
}
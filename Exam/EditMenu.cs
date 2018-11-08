using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSystemConsole
{
    class EditMenu  //Меню редагування
    {
        int choice;
        public int Choice
        {
            get { return choice; }
        }

        public void Start()
        {
            Console.WriteLine();
            Console.WriteLine("\t=========================================");
            Console.WriteLine("\t==============Меню редагування===========");
            Console.WriteLine("\t=========================================");
            Console.WriteLine("\t=   1 - Завантажити тест.               =");
            Console.WriteLine("\t=   2 - Показати всi Запитання.         =");
            Console.WriteLine("\t=   3 - Добавити Запитання.             =");
            Console.WriteLine("\t=   4 - Видалити Запитання за номером.  =");
            Console.WriteLine("\t=   5 - Редагувати запитання за номером.=");
            Console.WriteLine("\t=   6 - Редагувати вiдповiдь за номером.=");
            Console.WriteLine("\t=   7 - Зберегти змiни.                 =");
            Console.WriteLine("\t=   8 - Протестувати змiни.             =");
            Console.WriteLine("\t=========================================");
            Console.WriteLine("\t=   9 - Добавити нового адмiнiстратора. =");
            Console.WriteLine("\t=   0 - Виxiд.                          =");
            Console.WriteLine("\t=========================================");

            Console.Write("\n>Виберiть потрiбну дiю: ");
            choice = Convert.ToInt32(Console.ReadLine());
        }
    }
}

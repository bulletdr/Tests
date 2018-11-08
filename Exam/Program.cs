using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSystemConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu m = new Menu();
            EditMenu editMenu = new EditMenu();
            DataManager dm = new DataManager();
            AdminUsersManager aus = new AdminUsersManager();
            int answer;
            do
            {
                m.Start();
                switch (m.Choice)
                {
                    case 1:   //1-ий пунк - ПОЧАТОК ТЕСТУВАННЯ
                        {
                            if(dm.LoadTest())
                            { 
                            Console.WriteLine("Розпочати тестування? \n\t1 - так; \n\t2 - нi;");
                            answer = Convert.ToInt32(Console.ReadLine());
                                switch (answer)
                                {
                                    case 1:
                                        dm.StartTesting();
                                        break;
                                    case 2:
                                        m.Finish();
                                        break;
                                    default:
                                        Console.WriteLine("\n\t>>Невiрний вибiр!!!<< ");
                                        break;
                                }
                            }
                        }
                        break;
                    case 2:    //2-гий пунк меню - РЕДАГУВАННЯ
                        {
                            string login;
                            string password;
                            Console.WriteLine(">>>Введiть логiн i пароль для отримання доступу до меню редагування<<<");
                            Console.Write("\t>>> логiн: ");
                            login = Console.ReadLine();
                            Console.Write("\t>>> пароль: ");
                            password = Console.ReadLine();
                            aus.Validation(login,password);


                            if (aus.Validation(login, password))
                            {
                                Console.Clear();
                                Console.WriteLine("\tАвторизацiя успiшна!!! ");

                                do
                                {
                                    editMenu.Start();

                                    switch (editMenu.Choice)
                                    {
                                        case 1:
                                            Console.Clear();
                                            dm.LoadTest();
                                            break;
                                        case 2:
                                            Console.Clear();
                                            dm.Display();
                                            break;
                                        case 3:
                                            Console.Clear();
                                            dm.AddQuestion();
                                            break;
                                        case 4:
                                            Console.Clear();
                                            dm.RemoveQuestion();
                                            break;
                                        case 5:
                                            Console.Clear();
                                            dm.EditQuestion();
                                            break;
                                        case 6:
                                            Console.Clear();
                                            dm.EditAnswer();
                                            break;
                                        case 7:
                                            Console.Clear();
                                            dm.WriteData();
                                            break;
                                        case 8:
                                            Console.Clear();
                                            dm.StartTesting();
                                            break;
                                        case 9:
                                            Console.Clear();
                                            aus.AddAdminUser();
                                            aus.WriteDataAdminUser();
                                            break;
                                        default:
                                            Console.Clear();
                                            if(editMenu.Choice != 0) Console.WriteLine("\n\t>>Невiрний вибiр!!!<< ");
                                            break;
                                    }
                                }
                                while (editMenu.Choice != 0);
                            }
                            else
                            {
                                Console.WriteLine("\tНевiрний логiн або пароль!!! ");
                            }
                        }      
                        break;
                    case 0:
                        m.Finish();
                        break;
                }
            }
            while (m.Allow());
        }
    }
}

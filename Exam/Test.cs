using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace TestSystemConsole
{
    public class Test
    {
        List<Question> listQuestion;   //Список запитань
        List<Question> listUncorectQuestion;  //Список неправельних відповідей

        public Test()
        {
            listQuestion = new List<Question>();
            listUncorectQuestion = new List<Question>();
        }

        public List<Question> Questions()  //Функція, що повертає список тестів
        {
            return listQuestion;
        }
        public void AddQuestion(Question x)
        {
            listQuestion.Add(x);
        }
        public void RemoveQuestions() //Очищення списку тестів і неправельних відповідей
        {
            listQuestion.Clear();
            listUncorectQuestion.Clear();
        }
        public void Display()
        {
            foreach (Question q in listQuestion)
                q.Display();
        }
        public void AddQuestionByHand()  //Додавання нового запитання за допомогою консолі
        {
            Console.WriteLine("Введiть запитання:");
            string question=Console.ReadLine();

            Console.WriteLine("Введiть номер правильної вiдповiдi:");
            int correctAns = Convert.ToInt32(Console.ReadLine());

            Question x = new Question(listQuestion.Count + 1, question, correctAns);
            listQuestion.Add(x);

            Console.WriteLine("Введiть 4 варiанти вiдповiдей:");
            string answer;
            for (int i=1;i<=4;i++)
            {
                Console.Write("{0}: ",i);
                answer = Console.ReadLine();
                Answer a = new Answer(i, answer);
                x.AddAnswer(a);
            }
        }

        public void RemoveQuestion()  //Видалення запитання (При видаленні Id Всіх тестів змінюється)
        {
            int perevirka = 0;
            Console.WriteLine("Введiть номер запитання яке потрібно видалити:");
            int questionNumb = Convert.ToInt32(Console.ReadLine());
            for(int i=0;i<listQuestion.Count;i++)
            {
                if(listQuestion[i].QuestionId== questionNumb)
                {
                    listQuestion.Remove(listQuestion[i]);
                    perevirka++;
                }   
            }

            if (perevirka != 0)
            {
                Console.WriteLine("Запитання видалено успiшно!");
                for (int i = 0; i < listQuestion.Count; i++)
                {
                    listQuestion[i].QuestionId = i + 1;
                }
            }
            else Console.WriteLine("Запитання з даним номером в списку вiдсутнє!");
        }

        public void EditAnswer()  // редагування відповіді у вибраному тесті
        {
            Console.WriteLine("Введiть номер запитання вiдповiдi в якому потрiбно змiнити:");
            int questionNumb = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < listQuestion.Count; i++)
            {
                if (listQuestion[i].QuestionId == questionNumb)
                {
                    listQuestion[i].EditAnswer();
                }
            }
        }

        public void EditQuestion()  // редагування формулювання запитання
        {
            int perevirka = 0;
            Console.WriteLine("Введiть номер запитання яке потрiбно змiнити:");
            int questionNumb = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < listQuestion.Count; i++)
            {
                if (listQuestion[i].QuestionId == questionNumb)
                {
                    string questionText = Console.ReadLine();
                    listQuestion[i].QuestionText = questionText;
                    perevirka++;
                }
            }
            if (perevirka != 0) Console.WriteLine("Запитання змiнено успiшно!");
            else Console.WriteLine("Запитання з даним номером вiдсутнє!");
        }

        public void Testing()  //Початок тестування
        {
            int countCorrect = 0;
            int countUncorrect = 0;
            listUncorectQuestion.Clear();
            string answer;
            for (int i=0;i<listQuestion.Count;i++)
            {
                Console.Clear();
                listQuestion[i].Display();
                Console.WriteLine("\t\t==>Правильнi вiдповiдi: {0}<== \n\t\t==>Неправильнi вiдповiдi: {1}<==", countCorrect, countUncorrect);
                Console.WriteLine(">Ваш вибiр: ");
                answer = Console.ReadLine();
                if (listQuestion[i].CorrectAnswer == Convert.ToInt32(answer))
                    {
                       countCorrect++;
                    }
                else
                    {
                        listUncorectQuestion.Add(listQuestion[i]);
                        countUncorrect++;
                    }
            }
            Console.Clear();
            Console.WriteLine("====================================");
            Console.WriteLine("==========Ваш результат============= ");
            Console.WriteLine("\t>Правильнi вiдповiдi: {0}", countCorrect);
            Console.WriteLine("\t>Неравильнi вiдповiдi: {0}", countUncorrect);
            Console.WriteLine("====================================");

            Console.WriteLine("\tЧи бажаєте переглянути неравильнi вiдповiдi?");
            Console.WriteLine("\t>1 - ТАК;\n\t>2 - Нi;");
            int choise = Convert.ToInt32(Console.ReadLine());
            switch(choise)
            {
                case 1: 
                    {
                        //Виводимо усі неправельні відповіді
                        foreach (Question q in listUncorectQuestion)
                            q.Display();
                    }
                    
                    break;
                case 2:
                    Console.WriteLine("=>Дякуємо, що пройшли тестування!");
                    break;
                default:
                    Console.WriteLine("=>Неправильний вибiр<=");
                    break;
            }
        }

    }
}
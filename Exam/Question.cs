using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestSystemConsole
{
    [Serializable]
    public class Question
    {
        public int QuestionId { get; set; }
        public string QuestionText { get; set; }
        public int CorrectAnswer { get; set; }

        List<Answer> listAnswer;
        public Question() {    }
        public Question(int QuestionId, string QuestionText, int CorrectAnswer)
        {
            this.QuestionId = QuestionId;
            this.QuestionText = QuestionText;
            this.CorrectAnswer = CorrectAnswer;
            listAnswer = new List<Answer>();
        }

        public void AddAnswer(Answer x)
        {
            listAnswer.Add(x);
        }
        public void EditAnswer()  //редагування відповіді
        {
            int perevirka = 0;
            Console.WriteLine("Введiть номер вiдповiдi яку потрiбно змiнити:");
            int answerNumb = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < listAnswer.Count; i++)
            {
                if (listAnswer[i].AnswerId == answerNumb)
                {
                    Console.WriteLine("Введiть коректну вiдповiдь:");
                    string correctAnswer = Console.ReadLine();
                    listAnswer[i].AnswerText = correctAnswer;
                    perevirka++;
                }
            }
            if(perevirka!=0) Console.WriteLine("Вiдповiдь змiнено успiшно!");
            else Console.WriteLine("Вiдповiдь з даним номером вiдсутня!");
        }

        public void Display()
        {
            Console.WriteLine("\n{0,2}. {1}: ", QuestionId,QuestionText);
            foreach (Answer x in listAnswer)
                Console.WriteLine(x);
        }


    }
}
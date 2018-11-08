using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace TestSystemConsole
{
    public class DataManager:Test
    {
        
        List<Question> listQuestion;
        XmlDocument doc;
        XmlNode root;
        string path;
        Test test;
        int choise;
        
        public DataManager()
        {
            doc = new XmlDocument();
            test = new Test();
            listQuestion = new List<Question>();
        }
        public bool LoadTest()  //Завантаження і запуск теста
        {
            Console.Clear();
            test.RemoveQuestions();  
            Console.WriteLine("****************************");
            Console.WriteLine("**                        **");
            Console.WriteLine("** 1 - Тест по основах C# **");
            Console.WriteLine("** 2 - Тест з соцiологiї  **");
            Console.WriteLine("**                        **");
            Console.WriteLine("****************************");

            choise = Convert.ToInt32(Console.ReadLine());
            switch (choise)
            {
                case 1:
                    {
                        path = @"..\..\test1.xml";
                        LoadData(path);
                        return true;
                    }
                case 2:
                    {
                        path = @"..\..\test2.xml";
                        LoadData(path);
                    }
                    return true;
                default:
                    Console.WriteLine("!!!Неправильний вибiр!!!");
                    return false;
            }
        }
        public void LoadData(string path)  //завантаження теста за вказаним шляхом
        {
            doc.Load(path);
            root = doc.DocumentElement;

            foreach (XmlNode q in root.ChildNodes)
            {
                Question x = new Question (
                     Convert.ToInt32(q.Attributes["questionId"].Value),
                     q.Attributes["questionText"].Value,
                     Convert.ToInt32(q.Attributes["correctAnswer"].Value));
                foreach (XmlNode a in q.ChildNodes)
                {
                    Answer y = new Answer(
                         Convert.ToInt32(a.Attributes["answerId"].Value),
                         a.Attributes["answerText"].Value);
                    x.AddAnswer(y);
                }
                test.AddQuestion(x);
            }

            Console.WriteLine(">==Тест успiшно завантажено==<");
        }

        public void WriteData()  //Збереження до поточного або ж нового файла
        {
            
            Console.Write("\n>1 - Для збереження в новий файл ");
            Console.Write("\n>2 - Для замiни поточного файла ");
            Console.Write("\n>Виберiть потрiбну дiю: ");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    {
                        Console.Write("Введiть назву файла: ");
                        string fileName = Console.ReadLine();
                        XmlSerializer xs = new XmlSerializer(typeof(List<Question>));
                        FileStream fs = new FileStream(@"..\..\" + fileName + ".xml", FileMode.Create, FileAccess.Write);
                        xs.Serialize(fs, test.Questions());
                        fs.Close();
                        Console.Write("\tДанi успiшно збережено у файл пiд назвою {0}.", fileName);
                    }
                    break;
                case 2:
                    {
                        XmlSerializer xs = new XmlSerializer(typeof(List<Question>));
                        FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Write);
                        xs.Serialize(fs, test.Questions());
                        fs.Close();
                        Console.Write("\tЗміни до поточного файлу успiшно збережено.");
                    }
                    break;
            }
        }

        public void StartTesting()
        {
            test.Testing();
        }
        public void AddQuestion()
        {
            test.AddQuestionByHand();
        }
        public void RemoveQuestion()
        {
            test.RemoveQuestion();
        }
        public void EditAnswer()
        {
            test.EditAnswer();
        }
        public void EditQuestion()
        {
            test.EditQuestion();
        }
    }
}
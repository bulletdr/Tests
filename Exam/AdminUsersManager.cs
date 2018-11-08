using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace TestSystemConsole
{
    public class AdminUsersManager
    {
        List<AdminUsers> listAdminUsers;  //список користувачів які мають доступ до редагування

        public AdminUsersManager()
        {
            listAdminUsers = new List<AdminUsers>();
            LoadData();
        }
        public void LoadData()  //Завантаження списку адміністраторів
        {
            using(var stream = new FileStream(@"..\..\adminUsers.xml", FileMode.Open))
            {
                var XML = new XmlSerializer(typeof(List<AdminUsers>));
                listAdminUsers = (List<AdminUsers>)XML.Deserialize(stream);
            }
        }

        public void WriteDataAdminUser()  //Запис логінів і паролів адміністраторів
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<AdminUsers>));
            FileStream fs = new FileStream(@"..\..\adminUsers.xml", FileMode.Open, FileAccess.Write);
            xs.Serialize(fs, listAdminUsers);
            fs.Close();
            Console.Write("\tДанi про новго адмiна успiшно збережено;");
        }
        public void AddAdminUser() //добавляэмо нового адмніна
        {
            Console.Write("=>Введiть логiн: ");
            string login = Console.ReadLine();
            Console.Write("=>Введiть пароль: ");
            string password = Console.ReadLine();
            listAdminUsers.Add(new AdminUsers(login, password));
        }
        public bool Validation (string login, string password) //Перевірка даних авторизації для отримання доступу до меню редагування
        {
            for(int i=0;i<listAdminUsers.Count;i++)
            {
                if (listAdminUsers[i].Login == login && listAdminUsers[i].Password == password)
                    return true;
            }
            return false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSystemConsole
{
    [Serializable]
    public class AdminUsers //Користувачі які мають доступ до меню редагування
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public AdminUsers() { }
        public AdminUsers(string Login, string Password)
        {
            this.Login = Login;
            this.Password = Password;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WpfApp15.Model;
using WpfApp15.Tools;

namespace WpfApp15.ViewModels
{
    class SettingsVM
    {
        PasswordBox passwordBox;

        public string Server { get; set; }
        public string User { get; set; }
        public string DB { get; set; }

        public CommandVM TestConnection { get; set; }
        public CommandVM SaveSettings { get; set; }

        public SettingsVM(PasswordBox passwordBox)
        {
            this.passwordBox = passwordBox;

            Server = Wpf1125student.Properties.Settings.Default.server;
            User = Wpf1125student.Properties.Settings.Default.user;
            DB = Wpf1125student.Properties.Settings.Default.db;
            passwordBox.Password = Wpf1125student.Properties.Settings.Default.pass;

            TestConnection = new CommandVM(() => {
                var db = MySqlDB.GetDB();
                db.InitConnection(Server, User, DB, passwordBox.Password);
                if (db.OpenConnection())
                {
                    db.CloseConnection();
                    System.Windows.MessageBox.Show("Соединение успешно!");
                }
            });

            SaveSettings = new CommandVM(() => {
                Wpf1125student.Properties.Settings.Default.user = User;
                Wpf1125student.Properties.Settings.Default.db = DB;
                Wpf1125student.Properties.Settings.Default.pass = passwordBox.Password;
                Wpf1125student.Properties.Settings.Default.server = Server;
                Wpf1125student.Properties.Settings.Default.Save();
                System.Windows.MessageBox.Show("Данные сохранены!");
            });
        }
    }
}

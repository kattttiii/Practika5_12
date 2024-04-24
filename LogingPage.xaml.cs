using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Practika5_12.BookStoreDataSetTableAdapters;

namespace Practika5_12
{
    /// <summary>
    /// Логика взаимодействия для LogingPage.xaml
    /// </summary>
    public partial class LogingPage : Page
    {
        LoginParolTableAdapter LoginParolTableAdapter = new LoginParolTableAdapter();
        public LogingPage()
        {
            InitializeComponent();

        }

        private void Login_button_Click(object sender, RoutedEventArgs e)
        {
            var Password = Password_box.Password;
            var Login = Login_text_box.Text;
            var rolis = LoginParolTableAdapter.GetData().Rows;


            for (int i = 0; i < rolis.Count; i++)
            {
                var login = rolis[i][1].ToString();
                var pas = rolis[i][2].ToString();
                if (login == Login && pas == Password)
                {
                    if (rolis[i][3].ToString() == "Админ")
                    {
                        (Application.Current.MainWindow as MainWindow).MainFrame.Content = new AdminPanel();
                        return;
                    }
                    else if (rolis[i][3].ToString() == "Покупатель")
                    {
                        ///App.Current.Resources["login_user_id"] = rolis[i][0].ToString();
                        ///NavigationService.GetNavigationService(this).Navigate(new Uri("UserPanel.xaml",UriKind.RelativeOrAbsolute));
                        (Application.Current.MainWindow as MainWindow).MainFrame.Content = new UserPanel();

                        return;
                    }
                    else
                    {
                        return;
                    }
                }


            }
        }

        private void Login_text_box_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }

}

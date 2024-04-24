using Practika5_12.BookStoreDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace Practika5_12
{
    /// <summary>
    /// Логика взаимодействия для Roli_paroli.xaml
    /// </summary>
    public partial class Roli_paroli : Page
    {
        LoginParolTableAdapter LoginParolTableAdapter = new LoginParolTableAdapter();
        public Roli_paroli()
        {
            InitializeComponent();
            grid_brend.ItemsSource = LoginParolTableAdapter.GetData();
        }

        private void create_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Login_user.Text != "" && Password.Text != "" && RoleName.Text != "")
                {
                    LoginParolTableAdapter.InsertQuery(Login1: Login_user.Text, Parol: Password.Text, RoleName: RoleName.Text);
                    grid_brend.ItemsSource = LoginParolTableAdapter.GetData();
                    exeptions.Content = "";
                }
                else
                {
                    exeptions.Content = "Вы не ввели одно из значений!!";
                }
            }
            catch
            {
                exeptions.Content = "Что то введено не правильно";
            }
        }

        private void update_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Login_user.Text != "" && Password.Text != "" && RoleName.Text != "")
                {
                    object id = (grid_brend.SelectedItem as DataRowView).Row[0];
                    LoginParolTableAdapter.UpdateQuery(Login_user.Text, Password.Text, RoleName.Text, Convert.ToInt32(id));
                    grid_brend.ItemsSource = LoginParolTableAdapter.GetData();
                }
                else
                {
                    exeptions.Content = "Введите значение";
                }
            }
            catch
            {
                exeptions.Content = "Что то введено не правильно";
            }

        }

        private void delate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                object id = (grid_brend.SelectedItem as DataRowView).Row[0];
                LoginParolTableAdapter.DeleteQuery(Convert.ToInt32(id));
                grid_brend.ItemsSource = LoginParolTableAdapter.GetData();
            }
            catch
            {
                exeptions.Content = "Выберите столбец";
            }
        }

        private void grid_brend_Selected(object sender, RoutedEventArgs e)
        {
            if (grid_brend.SelectedItems.Count > 0)
            {
                DataRowView rowView = grid_brend.SelectedItems[0] as DataRowView;

                if (rowView != null)
                {
                    string valueInColumn1 = rowView["Login1"].ToString();
                    string valueInColumn4 = rowView["Parol"].ToString();
                    string valueInColumn5 = rowView["RoleName"].ToString();



                    Login_user.Text = valueInColumn1;

                    Password.Text = valueInColumn4;
                    RoleName.Text = valueInColumn5;
                }
            }
        }

        private void Import_Click(object sender, RoutedEventArgs e)
        {
            //Class4 class3 = new Class4();
            //List<Class4.Rolis> class_Datas = Class1.Deseria<List<Class4.Rolis>>();
            //foreach (var items in class_Datas)
            //
            //{
            //
            //    LoginParolTableAdapter.InsertQuery(items.login, items.password, items.rol);
            //}
            //grid_brend.ItemsSource = LoginParolTableAdapter.GetData();
        }
    }
}

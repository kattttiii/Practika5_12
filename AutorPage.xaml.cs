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
using Practika5_12.BookStoreDataSetTableAdapters;
namespace Practika5_12
{
    /// <summary>
    /// Логика взаимодействия для AutorPage.xaml
    /// </summary>
    public partial class AutorPage : Page
    {
        AuthorsTableAdapter authorsTableAdapter = new AuthorsTableAdapter();
        
        public AutorPage()
        {
            InitializeComponent();
            grid_brend.ItemsSource = authorsTableAdapter.GetData();
        }

        private void create_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (name.Text != "" &&  secondname.Text != "")
                {
                    authorsTableAdapter.InsertQuery(secondname.Text,name.Text);
                    grid_brend.ItemsSource = authorsTableAdapter.GetData();
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
                if (name.Text != "" && secondname.Text != "")
                {
                    object id = (grid_brend.SelectedItem as DataRowView).Row[0];
                    authorsTableAdapter.UpdateQuery(secondname.Text,name.Text, Convert.ToInt32(id));
                    grid_brend.ItemsSource = authorsTableAdapter.GetData();
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
                authorsTableAdapter.DeleteQuery(Convert.ToInt32(id));
                grid_brend.ItemsSource = authorsTableAdapter.GetData();
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
                    string valueInColumn1 = rowView["Surname"].ToString();
                    string valueInColumn4 = rowView["Name2"].ToString();
                    
                    secondname.Text = valueInColumn1;
                    name.Text = valueInColumn4;
                   
                }
            }
        }
    }
}

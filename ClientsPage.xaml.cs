using Practika5_12.BookStoreDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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
    /// Логика взаимодействия для ClientsPage.xaml
    /// </summary>
    public partial class ClientsPage : Page
    {
        ClientTableAdapter ClientsTableAdapter = new ClientTableAdapter();
        public ClientsPage()
        {
            InitializeComponent();
            grid_brend.ItemsSource = ClientsTableAdapter.GetData();
        }

        private void grid_brend_Selected(object sender, RoutedEventArgs e)
        {
            if (grid_brend.SelectedItems.Count > 0)
            {
                DataRowView rowView = grid_brend.SelectedItems[0] as DataRowView;

                if (rowView != null)
                {
                    string valueInColumn1 = rowView["Surname"].ToString();
                    string valueInColumn2 = rowView["Name1"].ToString();
                    string valueInColumn3 = rowView["MiddleName"].ToString();
                    string valueInColumn4 = rowView["PhoneNumber"].ToString();


                    Secondname.Text = valueInColumn1;
                    Name.Text = valueInColumn2;
                    MiddleName.Text = valueInColumn3;
                    Phone.Text = valueInColumn4;
                }
            }
        }

        private void create_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Secondname.Text != "" && Name.Text != "" && MiddleName.Text != "" && Phone.Text != "")
                {
                    ClientsTableAdapter.InsertQuery(Secondname.Text,Name.Text,MiddleName.Text,Phone.Text);
                    grid_brend.ItemsSource = ClientsTableAdapter.GetData();
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
                if (Secondname.Text != "" && Name.Text != "" && MiddleName.Text != "" && Phone.Text != "")
                {
                    object id = (grid_brend.SelectedItem as DataRowView).Row[0];
                    ClientsTableAdapter.UpdateQuery(Secondname.Text, Name.Text, MiddleName.Text, Phone.Text, Convert.ToInt32(id));
                    grid_brend.ItemsSource = ClientsTableAdapter.GetData();
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
                ClientsTableAdapter.DeleteQuery(Convert.ToInt32(id));
                grid_brend.ItemsSource = ClientsTableAdapter.GetData();
            }
            catch
            {
                exeptions.Content = "Выберите столбец";
            }
        }
    }
}

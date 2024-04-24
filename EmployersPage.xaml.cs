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
    /// Логика взаимодействия для EmployersPage.xaml
    /// </summary>
    public partial class EmployersPage : Page
    {
        EmployersTableAdapter EmployersTableAdapter = new EmployersTableAdapter();
        public EmployersPage()
        {
            InitializeComponent();
            grid_brend.ItemsSource = EmployersTableAdapter.GetData();
        }

        private void grid_brend_Selected(object sender, RoutedEventArgs e)
        {
            if (grid_brend.SelectedItems.Count > 0)
            {
                DataRowView rowView = grid_brend.SelectedItems[0] as DataRowView;

                if (rowView != null)
                {
                    string valueInColumn1 = rowView["Surname"].ToString();
                    string valueInColumn2 = rowView["Name3"].ToString();
                    string valueInColumn3 = rowView["MiddleName"].ToString();
                    string valueInColumn4 = rowView["PhoneNumber"].ToString();
                    string valueInColumn5 = rowView["Salary"].ToString();
                    string valueInColumn6 = rowView["Store_ID"].ToString();
                    string valueInColumn7 = rowView["LoginParol_ID"].ToString();


                    Secondname.Text = valueInColumn1;
                    Name.Text = valueInColumn2;
                    MiddleName.Text = valueInColumn3;
                    Salary.Text = valueInColumn4;
                    Store_id.Text = valueInColumn5;
                    Login_id.Text = valueInColumn6; 

                }
            }
        }

        private void update_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Secondname.Text != "" && Name.Text != "" && MiddleName.Text != "" && Salary.Text != "" && Store_id.Text != "" && Login_id.Text != "")
                {
                    object id = (grid_brend.SelectedItem as DataRowView).Row[0];
                    EmployersTableAdapter.UpdateQuery(Secondname.Text, Name.Text, MiddleName.Text, Phone.Text, Convert.ToInt32(Salary.Text), Convert.ToInt32(Store_id.Text), Convert.ToInt32(Login_id.Text), Convert.ToInt32(id));
                    grid_brend.ItemsSource = EmployersTableAdapter.GetData();
                }
                else
                {
                    return;
                }
            }
            catch
            {
                return;
            }
        }

        private void delate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void create_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Secondname.Text != "" && Name.Text != "" && MiddleName.Text != "" && Salary.Text != "" && Store_id.Text != "" && Login_id.Text != "")
                {
                    EmployersTableAdapter.InsertQuery(Secondname.Text , Name.Text , MiddleName.Text ,Phone.Text, Convert.ToInt32(Salary.Text) ,Convert.ToInt32( Store_id.Text) ,Convert.ToInt32( Login_id.Text) );
                    grid_brend.ItemsSource = EmployersTableAdapter.GetData();
                    
                }
                else
                {
                    return;
                }
            }
            catch
            {
                return;
            }
        }
    }
}

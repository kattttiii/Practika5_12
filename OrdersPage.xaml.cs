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
using Practika5_12.BookStoreDataSetTableAdapters;
namespace Practika5_12
{
    /// <summary>
    /// Логика взаимодействия для OrdersPage.xaml
    /// </summary>
    public partial class OrdersPage : Page
    {
        OrdersTableAdapter OrdersTableAdapter = new OrdersTableAdapter();   
        public OrdersPage()
        {
            InitializeComponent();
            grid_brend.ItemsSource = OrdersTableAdapter.GetData();
        }

        private void grid_brend_Selected(object sender, RoutedEventArgs e)
        {
            if (grid_brend.SelectedItems.Count > 0)
            {
                DataRowView rowView = grid_brend.SelectedItems[0] as DataRowView;

                if (rowView != null)
                {
                    string valueInColumn1 = rowView["Data1"].ToString();
                    string valueInColumn2 = rowView["Client_ID"].ToString();
                    string valueInColumn3 = rowView["Employer_ID"].ToString();
                    


                    datety.Text = valueInColumn1;
                    Client_id.Text = valueInColumn2;
                    Id_emploer.Text = valueInColumn3;
                    
                }
            }
        }

        private void update_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (datety.Text != "" && Client_id.Text != "" && Id_emploer.Text != "" )
                {
                    object id = (grid_brend.SelectedItem as DataRowView).Row[0];
                    OrdersTableAdapter.UpdateQuery(datety.Text,Convert.ToInt32(Client_id.Text),Convert.ToInt32(Id_emploer.Text),Convert.ToInt32(id));
                    grid_brend.ItemsSource = OrdersTableAdapter.GetData();
                   
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
            try
            {
                object id = (grid_brend.SelectedItem as DataRowView).Row[0];
                OrdersTableAdapter.DeleteQuery(Convert.ToInt32(id));
                grid_brend.ItemsSource = OrdersTableAdapter.GetData();
            }
            catch
            {
                return;
            }
        }

        private void create_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (datety.Text != "" && Client_id.Text != "" && Id_emploer.Text != "")
                {
                    OrdersTableAdapter.InsertQuery(datety.Text, Convert.ToInt32(Client_id.Text), Convert.ToInt32(Id_emploer.Text));
                    grid_brend.ItemsSource = OrdersTableAdapter.GetData();
                    
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

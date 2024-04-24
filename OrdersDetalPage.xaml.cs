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
    /// Логика взаимодействия для OrdersDetalPage.xaml
    /// </summary>
    public partial class OrdersDetalPage : Page
    {
        OrderDetailsTableAdapter OrderDetailsTableAdapter = new OrderDetailsTableAdapter();
        public OrdersDetalPage()
        {
            InitializeComponent();
            grid_brend.ItemsSource = OrderDetailsTableAdapter.GetData();
        }

        private void grid_brend_Selected(object sender, RoutedEventArgs e)
        {
            if (grid_brend.SelectedItems.Count > 0)
            {
                DataRowView rowView = grid_brend.SelectedItems[0] as DataRowView;

                if (rowView != null)
                {
                    string valueInColumn1 = rowView["Quantity"].ToString();
                    string valueInColumn2 = rowView["Book_ID"].ToString();
                    string valueInColumn3 = rowView["Order_ID"].ToString();
                    


                    Quantity.Text = valueInColumn1;
                    Book_id.Text = valueInColumn2;
                    Id_orders.Text = valueInColumn3;
                    
                }
            }
        }

        private void update_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Quantity.Text != "" && Book_id.Text != "" && Id_orders.Text != "")
                {
                    object id = (grid_brend.SelectedItem as DataRowView).Row[0];
                    OrderDetailsTableAdapter.UpdateQuery(Convert.ToInt32(Quantity.Text), Convert.ToInt32(Book_id.Text), Convert.ToInt32(Id_orders.Text), Convert.ToInt32(id));
                    grid_brend.ItemsSource = OrderDetailsTableAdapter.GetData();
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
                OrderDetailsTableAdapter.DeleteQuery(Convert.ToInt32(id));
                grid_brend.ItemsSource = OrderDetailsTableAdapter.GetData();
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
                if (Quantity.Text != "" && Book_id.Text != "" && Id_orders.Text != "" )
                {
                    OrderDetailsTableAdapter.InsertQuery(Convert.ToInt32(Quantity.Text), Convert.ToInt32(Book_id.Text), Convert.ToInt32(Id_orders.Text));
                    grid_brend.ItemsSource = OrderDetailsTableAdapter.GetData();
                    
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

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
    /// Логика взаимодействия для ScladPage.xaml
    /// </summary>
    public partial class ScladPage : Page
    {
        SkladTableAdapter SkladTableAdapter = new SkladTableAdapter();
        public ScladPage()
        {
            InitializeComponent();
            grid_brend.ItemsSource = SkladTableAdapter.GetData();
        }

        private void grid_brend_Selected(object sender, RoutedEventArgs e)
        {
            if (grid_brend.SelectedItems.Count > 0)
            {
                DataRowView rowView = grid_brend.SelectedItems[0] as DataRowView;

                if (rowView != null)
                {
                    string valueInColumn1 = rowView["SkladName"].ToString();
                    string valueInColumn2 = rowView["SkladAddres"].ToString();
                   



                    Named.Text = valueInColumn1;
                    Adress.Text = valueInColumn2;
                    

                }
            }
        }

        private void update_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Named.Text != "" && Adress.Text != "")
                {
                    object id = (grid_brend.SelectedItem as DataRowView).Row[0];
                    SkladTableAdapter.UpdateQuery(Named.Text,Adress.Text, Convert.ToInt32(id));
                    grid_brend.ItemsSource = SkladTableAdapter.GetData();

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
                SkladTableAdapter.DeleteQuery(Convert.ToInt32(id));
                grid_brend.ItemsSource = SkladTableAdapter.GetData();
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
                if (Named.Text != "" && Adress.Text != "")
                {
                    SkladTableAdapter.InsertQuery(Named.Text, Adress.Text);
                    grid_brend.ItemsSource = SkladTableAdapter.GetData();

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

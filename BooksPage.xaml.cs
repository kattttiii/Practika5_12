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
using System.Xml.Linq;
using Practika5_12.BookStoreDataSetTableAdapters;
namespace Practika5_12
{
    /// <summary>
    /// Логика взаимодействия для BooksPage.xaml
    /// </summary>
    public partial class BooksPage : Page
    {
        BookTableAdapter BookTableAdapter = new BookTableAdapter(); 
        public BooksPage()
        {
            InitializeComponent();
            grid_brend.ItemsSource = BookTableAdapter.GetData();
        }

        private void grid_brend_Selected(object sender, RoutedEventArgs e)
        {
            if (grid_brend.SelectedItems.Count > 0)
            {
                DataRowView rowView = grid_brend.SelectedItems[0] as DataRowView;

                if (rowView != null)
                {
                    string valueInColumn1 = rowView["Title"].ToString();
                    string valueInColumn2 = rowView["Price"].ToString();
                    string valueInColumn3 = rowView["StockQuantity"].ToString();
                    string valueInColumn4 = rowView["Author_ID"].ToString();


                    Title.Text = valueInColumn1;
                    Price.Text = valueInColumn2;
                    StockQuantity.Text = valueInColumn3;
                    Autor_id.Text = valueInColumn4;
                }
            }
        }

        private void create_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Title.Text != "" && Price.Text != "" && StockQuantity.Text != "" && Autor_id.Text != "")
                {
                    BookTableAdapter.InsertQuery(Title.Text, Convert.ToInt32(Price.Text), Convert.ToInt32(StockQuantity.Text), Convert.ToInt32(Autor_id.Text));
                    grid_brend.ItemsSource = BookTableAdapter.GetData();
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
                if (Title.Text != "" && Price.Text != "" && StockQuantity.Text != "" && Autor_id.Text != "")
                {
                    object id = (grid_brend.SelectedItem as DataRowView).Row[0];
                    BookTableAdapter.UpdateQuery(Title.Text,Convert.ToInt32(Price.Text),Convert.ToInt32(StockQuantity.Text),Convert.ToInt32(Autor_id.Text), Convert.ToInt32(id));
                    grid_brend.ItemsSource = BookTableAdapter.GetData();
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
                BookTableAdapter.DeleteQuery(Convert.ToInt32(id));
                grid_brend.ItemsSource = BookTableAdapter.GetData();
            }
            catch
            {
                exeptions.Content = "Выберите столбец";
            }
        }
    }
}

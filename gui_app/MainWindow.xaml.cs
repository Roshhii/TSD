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
using HomeLibrary;

namespace gui_app
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private void AddButton_Click(object sender, RoutedEventArgs e){
            int id = (listBooks.ItemsSource as List<Book>).Last().Id;
            Book book = new Book(id+1);
            (listBooks.ItemsSource as List<Book>).Add(book);
            
            CollectionViewSource.GetDefaultView(listBooks.ItemsSource).Refresh();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if(listBooks.SelectedItem != null)
            {
                if (MessageBox.Show("Confirm to delete.", "Delete", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                {
                    Book book = listBooks.SelectedItem as Book;
                    (listBooks.ItemsSource as List<Book>).Remove(book);
                    CollectionViewSource.GetDefaultView(listBooks.ItemsSource).Refresh();
                }
            }

        }
        public MainWindow()
        {
            InitializeComponent();

            this.listBooks.ItemsSource = MyBookCollection.GetMyCollection();




        }
    }
}

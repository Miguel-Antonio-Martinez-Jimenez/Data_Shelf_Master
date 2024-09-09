using DataShelfMaster.Entities;
using DataShelfMaster.Services;
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
using System.Windows.Shapes;

namespace DataShelfMaster.ViewWindows
{
    /// <summary>
    /// Lógica de interacción para AddBooks.xaml
    /// </summary>
    public partial class AddBooks : Window
    {
        public AddBooks()
        {
            InitializeComponent();
            request.FkIdRole = request.FkIdRole;
        }
        BookService service1 = new BookService();
        Book book = new Book();
        ValidateRole request = new ValidateRole();

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if(TxtISBN.Text==""||TxtTitle.Text == ""||TxtAuthor.Text == ""||TxtEdition.Text == "")
            {
                MessageProblems.Content = "Fill all the fields";
            }
            else
            {
                book.ISBN = TxtISBN.Text;
                book.Title = TxtTitle.Text;
                book.Author = TxtAuthor.Text;
                book.Edition = TxtEdition.Text;
                book.Status = "Disposable";
                service1.CreateBooks(book);
                DataShelfMasterSistem view2 = new DataShelfMasterSistem(request);
                view2.Show();
                Close();
                MessageBox.Show("Book Added");
            }
            
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            DataShelfMasterSistem view1 = new DataShelfMasterSistem(request);
            view1.Show();
            Close();
        }
    }
}

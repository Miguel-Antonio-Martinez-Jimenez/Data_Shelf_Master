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
    /// Lógica de interacción para EditBooks.xaml
    /// </summary>
    public partial class EditBooks : Window
    {
        public EditBooks(Book request)
        {
            InitializeComponent();
            TxtISBN.Text = request.ISBN;
            TxtTitle.Text = request.Title;
            TxtAuthor.Text = request.Author;
            TxtEdition.Text = request.Edition;
            CbxStatus.Text = request.Status;
        }
        BookService service1 = new BookService();
        ValidateRole request = new ValidateRole();

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if(TxtISBN.Text==""||TxtTitle.Text == ""||TxtAuthor.Text == ""||TxtEdition.Text == ""||CbxStatus.Text == "")
            {
                MessageProblems.Content = "Fill all the fields";
            }
            else
            {
                Book books = new Book();
                books.ISBN = TxtISBN.Text;
                books.Title = TxtTitle.Text;
                books.Author = TxtAuthor.Text;
                books.Edition = TxtEdition.Text;
                if(CbxStatus.Text == "Disposable")
                {
                    books.Status = "Disposable";
                }
                else if(CbxStatus.Text== "Borrowed")
                {
                    books.Status = "Borrowed";
                }
                service1.UpdateBooks(books);
                DataShelfMasterSistem view2 = new DataShelfMasterSistem(request);
                view2.Show();
                Close();
                MessageBox.Show("Book Updated");
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

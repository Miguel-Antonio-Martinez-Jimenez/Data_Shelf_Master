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
using System.Xml.Linq;

namespace DataShelfMaster.ViewWindows
{
    /// <summary>
    /// Lógica de interacción para DataShelfMasterSistem.xaml
    /// </summary>
    public partial class DataShelfMasterSistem : Window
    {
        public DataShelfMasterSistem(ValidateRole request)
        {
            InitializeComponent();
            role = request.FkIdRole;
            LbName.Content = request.FkName;
            visualizacion();
            UpdateTables();
        }
        private int role;
        StudentService service1 = new StudentService();
        BookService service2 = new BookService();
        PersonnelService service3 = new PersonnelService();
        Solicitude solicitude = new Solicitude();
        Personnel personnel = new Personnel();
        Book book = new Book();
        MainWindow obj = new MainWindow();

        public void UpdateTables()
        {
            var request1 = service1.ReadStudents();
            StudentsTable.ItemsSource = request1;
            var request2 = service2.ReadBooks();
            BooksTable.ItemsSource = request2;
            var request3 = service3.ReadSolicitudes();
            SolicitudesTable.ItemsSource = request3;
            var request4 = service3.ReadPersonnel();
            UsersTable.ItemsSource = request4;
        }
        public void visualizacion()
        {

            if (role == 1)
            {
                OptionsSolicitude.Visibility = Visibility.Visible;
                OptionsSolicitudes.Visibility = Visibility.Collapsed;
            }
            else if(role == 2)
            {
                OptionsSolicitude.Visibility = Visibility.Collapsed;
                OptionsBook.Visibility = Visibility.Collapsed;
                OptionsStudent.Visibility = Visibility.Collapsed;
                TableUsers.Visibility = Visibility.Collapsed;
                BtnAddtudents.Visibility = Visibility.Collapsed;
                BtnAddBooks.Visibility = Visibility.Collapsed;
                LblMas1.Visibility = Visibility.Collapsed;
                LblMas2.Visibility = Visibility.Collapsed;
                OptionsSolicitudes.Visibility = Visibility.Visible;
            }
        }

        private void BtnSearchBooks_Click(object sender, RoutedEventArgs e)
        {
        }
        private void BtnSearchSolicitudes_Click(object sender, RoutedEventArgs e)
        {

        }
        private void BtnSearchStudent_Click(object sender, RoutedEventArgs e)
        {

        }
        private void BrnSearchUsers_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnAddSolicitudes_Click(object sender, RoutedEventArgs e)
        {
            ValidateRole request = new ValidateRole();
            request.FkIdRole = role;
            request.FkName = LbName.Name;
            AddSolicitudes view1 = new AddSolicitudes(request);
            view1.Show();
            Close();
        }
        private void BtnAddBooks_Click(object sender, RoutedEventArgs e)
        {
            AddBooks view2 = new AddBooks();
            view2.Show();
            Close();
        }
        private void BtnAddtudents_Click(object sender, RoutedEventArgs e)
        {
            AddStudent view3 = new AddStudent();
            view3.Show();
            Close();
        }
        private void BtnAddUsers_Click(object sender, RoutedEventArgs e)
        {
            AddUsers view4 = new AddUsers();
            view4.Show();
            Close();
        }

        private void BtnLogOut_Click(object sender, RoutedEventArgs e)
        {
            MainWindow viewClose = new MainWindow();
            viewClose.Show();
            Close();
        }

        private void BtnEditSolicitude_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var solicitudes = (Solicitude)button.DataContext;
            EditSolicitudes solicitudeEdit = new EditSolicitudes(solicitudes);
            solicitudeEdit.Show();
            Close();
        }
        private void BtnDeletetSolicitude_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult resultado = MessageBox.Show("Do you want to delete this solicitude permanently?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (resultado == MessageBoxResult.Yes)
            {
                var button = (Button)sender;
                var solicitudes = (Solicitude)button.DataContext;
                service3.DeleteSolicitudes(solicitudes);
                UpdateTables();
                MessageBox.Show("Solicitude Delete");
            }

        }
        private void BtnEditBook_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var books = (Book)button.DataContext;
            EditBooks bookEdit = new EditBooks(books);
            bookEdit.Show();
            Close();
        }
        private void BtnDeleteBook_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult resultado = MessageBox.Show("Do you want to delete this book permanently?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (resultado == MessageBoxResult.Yes)
            {
                var button = (Button)sender;
                var books = (Book)button.DataContext;
                service2.DeleteBooks(books);
                UpdateTables();
                MessageBox.Show("Solicitude Delete");
            }

        }
        private void BtnEditStudent_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var students = (Student)button.DataContext;
            EditStudents studentEdit = new EditStudents(students);
            studentEdit.Show();
            Close();
        }
        private void BtnDeleteStudent_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult resultado = MessageBox.Show("Do you want to delete this student permanently?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (resultado == MessageBoxResult.Yes)
            {
                var button = (Button)sender;
                var student = (Student)button.DataContext;
                service1.DeleteStudents(student);
                UpdateTables();
                MessageBox.Show("Solicitude Delete");
            }

        }
        private void BtnEditPersonnel_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var personnels = (Personnel)button.DataContext;
            EditUsers personneledit = new EditUsers(personnels);
            personneledit.Show();
            Close();
        }
        private void BtnDeletePersonnel_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult resultado = MessageBox.Show("Do you want to delete this user permanently?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (resultado == MessageBoxResult.Yes)
            {
                var button = (Button)sender;
                var student = (Student)button.DataContext;
                service1.DeleteStudents(student);
                UpdateTables();
                MessageBox.Show("Solicitude Delete");
            }

        }
    }
}

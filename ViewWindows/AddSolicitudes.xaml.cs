using DataShelfMaster.Entities;
using DataShelfMaster.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DataShelfMaster.ViewWindows
{
    /// <summary>
    /// Lógica de interacción para AddSolicitudes.xaml
    /// </summary>
    public partial class AddSolicitudes : Window
    {
        public AddSolicitudes(ValidateRole requests)
        {
            InitializeComponent();
            ComboBoxs();
            request.FkIdRole = requests.FkIdRole;
        }
        PersonnelService service1 = new PersonnelService();
        StudentService service2 = new StudentService();
        BookService service3 = new BookService();
        ValidateRole request = new ValidateRole();
        public void ComboBoxs()
        {
            var value = service2.ReadStudents();
            CbxMatric.DisplayMemberPath = "Matric";
            CbxMatric.SelectedValue = "Matric";
            CbxMatric.ItemsSource = value.ToList();

            CbxISBN.ItemsSource = service3.ReadBooks().Where(s=>s.Status== "Disposable");
            CbxISBN.DisplayMemberPath = "Title";
            CbxISBN.SelectedValuePath = "ISBN";
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            DataShelfMasterSistem view1 = new DataShelfMasterSistem(request);
            view1.Show();
            Close();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if(CbxMatric.Text==""|| CbxISBN.Text == "")
            {
                MessageProblems.Content = "Fill all the fields";
            }
            else
            {
                Book book = new Book();
                Solicitude solicitude = new Solicitude();
                string matric = Convert.ToString(CbxMatric.Text);
                solicitude.FkMatric = matric;
                solicitude.FkISBN = Convert.ToString(CbxISBN.SelectedValue.ToString());
                solicitude.DateSolicitude = DateTime.Now;
                solicitude.Observation = TxtObservation.Text;
                solicitude.Status = "Borrowed";
                book.ISBN = Convert.ToString(CbxISBN.SelectedValue.ToString());
                book.Status = "Borrowed";
                service1.CreateSolicitudes(solicitude);
                service3.UpdateBookStatus(book);
                DataShelfMasterSistem view2 = new DataShelfMasterSistem(request);
                view2.Show();
                Close();
                MessageBox.Show("Solicitude Added");
            }
            
        }
    }
}

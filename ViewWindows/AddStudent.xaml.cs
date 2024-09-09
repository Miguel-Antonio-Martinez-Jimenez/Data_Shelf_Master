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
    /// Lógica de interacción para AddStudent.xaml
    /// </summary>
    public partial class AddStudent : Window
    {
        public AddStudent()
        {
            InitializeComponent();
        }
        StudentService service1 = new StudentService();
        Student student = new Student();
        ValidateRole request = new ValidateRole();

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if(TxtMatric.Text==""||TxtName.Text == ""||TxtLastName.Text == ""||CbxTurn.Text == ""||CbxCareer.Text == ""||CbxSemester.Text == "")
            {
                MessageProblems.Content = "Fill all the fields";
            }
            else
            {
                string Turn = Convert.ToString(CbxTurn.Text);
                string Career = Convert.ToString(CbxCareer.Text);
                int Semester = Convert.ToInt32(CbxSemester.Text);
                student.Matric = TxtMatric.Text;
                student.Name = TxtName.Text;
                student.LastName = TxtLastName.Text;
                student.Turn = Turn;
                student.Career = Career;
                student.Semester = Semester;
                service1.CreateStudents(student);
                DataShelfMasterSistem view2 = new DataShelfMasterSistem(request);
                view2.Show();
                Close();
                MessageBox.Show("Student Added");
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

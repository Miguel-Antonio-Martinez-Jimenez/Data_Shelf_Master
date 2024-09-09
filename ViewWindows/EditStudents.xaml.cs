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
    /// Lógica de interacción para EditStudents.xaml
    /// </summary>
    public partial class EditStudents : Window
    {
        public EditStudents(Student request)
        {
            InitializeComponent();
            x = request.Matric;
            TxtMatric.Text = request.Matric;
            TxtName.Text = request.Name;
            TxtLastName.Text = request.LastName;
            CbxTurn.Text = request.Turn;
            CbxCareer.Text = request.Career;
            int y = Convert.ToInt32(request.Semester);
            CbxSemester.Text = Convert.ToString(request.Semester);
        }
        private string x;
        StudentService service1 = new StudentService();
        ValidateRole request = new ValidateRole();

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if(TxtMatric.Text==""||TxtName.Text == ""||TxtLastName.Text == ""||CbxTurn.Text == ""||CbxCareer.Text == ""||CbxSemester.Text == "")
            {
                MessageProblems.Content = "Fill all the fields";
            }
            else
            {
                Student student = new Student();
                string Turn = Convert.ToString(CbxTurn.Text);
                string Career = Convert.ToString(CbxCareer.Text);
                int Semester = Convert.ToInt32(CbxSemester.Text);
                student.Matric = TxtMatric.Text;
                student.Name = TxtName.Text;
                student.LastName = TxtLastName.Text;
                student.Turn = Turn;
                student.Career = Career;
                student.Semester = Semester;
                service1.UpdateStudents(student,x);
                DataShelfMasterSistem view2 = new DataShelfMasterSistem(request);
                view2.Show();
                Close();
                MessageBox.Show("Student Edited");
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

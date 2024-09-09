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
    /// Lógica de interacción para EditUsers.xaml
    /// </summary>
    public partial class EditUsers : Window
    {
        public EditUsers(Personnel request)
        {
            InitializeComponent();
            ComboBoxs();
            x = request.IdPersonnel;
            TxtName.Text = request.Name;
            TxtUsername.Text = request.Username;
            TxtPassword.Password = request.Password;
            if(request.FkRole == 2)
            {
                CbxRole.Text = "Receptionist";
            }
            else if(request.FkRole == 1)
            {
                CbxRole.Text = "Administrator";
            }
        }
        ValidateRole request = new ValidateRole();
        PersonnelService service1 = new PersonnelService();
        ValidateRole requests = new ValidateRole();
        private int x;
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Personnel personnel = new Personnel();
            if(TxtName.Text==""||TxtUsername.Text == ""||TxtPassword.Password==""||CbxRole.Text=="")
            {
                MessageProblems.Content = "Fill all the fields";
            }
            else
            {
                personnel.IdPersonnel = x;
                personnel.Name =TxtName.Text;
                personnel.Username =TxtUsername.Text;
                personnel.Password = TxtPassword.Password;
                personnel.FkRole = Convert.ToInt32(CbxRole.SelectedItem);
                service1.UpdatePersonnel(personnel);
                DataShelfMasterSistem view2 = new DataShelfMasterSistem(requests);
                view2.Show();
                Close();
                MessageBox.Show("Personnel Updated");
            }
        }

        public void ComboBoxs()
        {
            var value = service1.ReadRole();
            CbxRole.DisplayMemberPath = "NameRole";
            CbxRole.SelectedValue = "IdRole";
            CbxRole.ItemsSource = value.ToList();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            DataShelfMasterSistem view1 = new DataShelfMasterSistem(request);
            view1.Show();
            Close();
        }
    }
}

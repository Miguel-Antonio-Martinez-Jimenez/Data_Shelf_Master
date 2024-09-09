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
    /// Lógica de interacción para AddUsers.xaml
    /// </summary>
    public partial class AddUsers : Window
    {
        public AddUsers()
        {
            InitializeComponent();
            ComboBoxRole();
        }
        PersonnelService service1 = new PersonnelService();
        Personnel personnel = new Personnel();
        ValidateRole request = new ValidateRole();

        public void ComboBoxRole()
        {
            CbxRole.ItemsSource = service1.ReadRole();
            CbxRole.DisplayMemberPath = "NameRole";
            CbxRole.SelectedValuePath = "IdRole";
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if(TxtName.Text==""||TxtUserName.Text == ""||TxtPassword.Password==""||CbxRole.Text == "")
            {
                MessageProblems.Content = "Fill all the fields";
            }
            else
            {
                int Role = Convert.ToInt32(CbxRole.Text);
                personnel.Name = TxtName.Text;
                personnel.Username = TxtUserName.Text;
                personnel.Password = TxtPassword.Password;
                personnel.FkRole = Role;
                service1.CreatePersonnel(personnel);
                DataShelfMasterSistem view2 = new DataShelfMasterSistem(request);
                view2.Show();
                Close();
                MessageBox.Show("User Added");
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

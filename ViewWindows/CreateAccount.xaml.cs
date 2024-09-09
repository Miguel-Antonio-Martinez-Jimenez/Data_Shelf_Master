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
    /// Lógica de interacción para CreateAccount.xaml
    /// </summary>
    public partial class CreateAccount : Window
    {
        public CreateAccount()
        {
            InitializeComponent();
        }
        Personnel personnel = new Personnel();
        PersonnelService service1 = new PersonnelService();

        private void BtnCreateAccount_Click(object sender, RoutedEventArgs e)
        {
            if(TxtName.Text==""||TxtUsername.Text==""||TxtPassword.Password=="")
            {
                MessageProblems.Content = "Llena Todos Los Campos";
            }
            else
            {
                string num = service1.ValidatePersonnel(personnel);
                if(num == "1")
                {
                    TxtName.Clear();
                    TxtUsername.Clear();
                    TxtPassword.Clear();
                    MessageProblems.Content = "El usuario ya existe";
                }
                else
                {
                    personnel.Name = TxtName.Text;
                    personnel.Username = TxtUsername.Text;
                    personnel.Password = TxtPassword.Password;
                    personnel.FkRole = 2;
                    service1.CreatePersonnel(personnel);
                    TxtName.Clear();
                    TxtUsername.Clear();
                    TxtPassword.Clear();
                    MessageProblems.Content = "Cuenta Creada";
                }
            }
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            MainWindow view1 = new MainWindow();
            view1.Show();
            Close();
        }
    }
}

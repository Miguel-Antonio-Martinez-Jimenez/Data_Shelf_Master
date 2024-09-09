using DataShelfMaster.Entities;
using DataShelfMaster.Services;
using DataShelfMaster.ViewWindows;
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

namespace DataShelfMaster
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        Personnel personnel = new Personnel();
        PersonnelService service1 = new PersonnelService();
        ValidateRole validation = new ValidateRole();

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (TxtUsername.Text==""||TxtPassword.Password=="")
            {
                TxtUsername.Clear();
                TxtPassword.Clear();
                MessageProblems.Content = "Fill all the fields";
            }
            else
            {
                personnel.Username = TxtUsername.Text;
                personnel.Password = TxtPassword.Password;
                string num = service1.ValidateUser(personnel);
                if(num == "0")
                {
                    MessageProblems.Content = "Incorrect Data";
                }
                else
                {
                    var valide = service1.ValidateRole(TxtUsername.Text);
                    var x = valide.FkRole;
                    int xx = Convert.ToInt32(x);
                    validation.FkIdRole = xx;
                    validation.FkName = valide.Name;
                    DataShelfMasterSistem view2 = new DataShelfMasterSistem(validation);
                    view2.Show();
                    Close();
                }
            }
        }
        public int FkRol(int x)
        {
            int role = Convert.ToInt32(x);
            return role;
        }

        private void BtnCreateAccount_Click(object sender, RoutedEventArgs e)
        {
            CreateAccount view1 = new CreateAccount();
            view1.Show();
            Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
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

namespace PlanningTheEP
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            string login = Name.Text;
            string password = Password.Password;

            for (int i = login.Length; i < 100; i++)
            {
                login += " ";
            }
            for (int i = password.Length; i < 15; i++)
            {
                password += " ";
            }

            PlanningTheEPEntities db = new PlanningTheEPEntities();
            try
            {
                Worker user = db.Worker.Where((u) => u.FullName == login && u.Password == password).Single();
                SelectionWindow main = new SelectionWindow();
                main.Show();
                this.Close();
            }
            catch
            {
                MessageBox.Show("Проверьте правильность логина или пароля!");
            }
        }

    }
}

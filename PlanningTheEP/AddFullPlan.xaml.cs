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

namespace PlanningTheEP
{
    /// <summary>
    /// Логика взаимодействия для AddFullPlan.xaml
    /// </summary>
    public partial class AddFullPlan : Page
    {
        private FullPlan _currentPlan = new FullPlan();
        public AddFullPlan()
        {
            InitializeComponent();
            DataContext = _currentPlan;
            Types.ItemsSource = PlanningTheEPEntities.GetContext().Type.ToList();
        }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (Name.Text == "") MessageBox.Show("Введите название плана!");
            else if (Types.SelectedItem == null) MessageBox.Show("Выберите тип плана!");
            else
            {
                PlanningTheEPEntities.GetContext().FullPlan.Add(_currentPlan);
                PlanningTheEPEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена!");
                Manager.MainFrame.GoBack();
            }
        }
    }
}

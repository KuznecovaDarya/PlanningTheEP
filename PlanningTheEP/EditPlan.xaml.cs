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
    /// Логика взаимодействия для EditPlan.xaml
    /// </summary>
    public partial class EditPlan : Page
    {
        private FullAndFirst _currentPlan = new FullAndFirst();
        public EditPlan(FullAndFirst selectedPlan)
        {
            InitializeComponent();
            if (selectedPlan != null)
                _currentPlan = selectedPlan;

            DataContext = _currentPlan;
            SArea.ItemsSource = PlanningTheEPEntities.GetContext().SubjectArea.ToList();
            Subject.ItemsSource = PlanningTheEPEntities.GetContext().Subject.ToList();
            Grades.ItemsSource = PlanningTheEPEntities.GetContext().Grade.ToList();
        }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (NOH.Text == "") MessageBox.Show("Введите количество часов!");
            else
            {

                if (_currentPlan.Id == 0)
                {
                    PlanningTheEPEntities.GetContext().FullAndFirst.Add(_currentPlan);
                }

                try
                {
                    PlanningTheEPEntities.GetContext().SaveChanges();
                    MessageBox.Show("Информация сохранена!");
                    Manager.MainFrame.GoBack();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }

            }

        }
    }
}
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

namespace ESDAHRMSystem.View
{
    /// <summary>
    /// Interaction logic for IntegratedChildren.xaml
    /// </summary>
    public partial class IntegratedChildren : UserControl
    {
        private ESDAData.esdaEntities data;
        Object Eduvalue, GenderValue, JobValue;
        string value;
        private ESDAData.employee employee;
        private View.AddEmployee emplo;
        public delegate void MyDelegate(Object value);
        public event MyDelegate MyCustomEvent;
        ESDAData.esdaEntities dbContext;
        public IntegratedChildren()
        {
            InitializeComponent();
            this.dbContext = new ESDAData.esdaEntities();
            ESDAData.employee employee = new ESDAData.employee();
            
            var blog = dbContext.children.ToList();

           

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            var blog = dbContext.children
                     .Where(b => b.Status == "Not living");
            IntegratedItemControl.ItemsSource = blog.ToList();
        }
        private void EmployeeData_Loaded(object sender, RoutedEventArgs e)
        {
            IntegratedItemControl.ItemsSource = dbContext.employees.ToList();
        }

        private void ComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            FirstNameCombo.ItemsSource = dbContext.genders.ToList();
            FirstNameCombo.SelectedValue = "Name";
            FirstNameCombo.DisplayMemberPath = "Name";
        }

        public void MainWindowClear(string v)
        {
            MainWindow main = new MainWindow();
            main.clear("empPage");
        }

        private void MiddleNameCombo_Loaded(object sender, RoutedEventArgs e)
        {
            MiddleNameCombo.ItemsSource = dbContext.jobs.ToList();
            MiddleNameCombo.SelectedValue = "Name";
            MiddleNameCombo.DisplayMemberPath = "Name";
        }

       



      



        private void EducationCombo_Loaded(object sender, RoutedEventArgs e)
        {
            EducationCombo.ItemsSource = dbContext.educations.ToList();
            EducationCombo.SelectedValue = "Name";
            EducationCombo.DisplayMemberPath = "Name";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Eduvalue = EducationCombo.SelectedItem;
                GenderValue = EducationCombo.SelectedItem;
                JobValue = EducationCombo.SelectedItem;
                if (Eduvalue.ToString().Equals("ESDAData.education"))
                {
                    ESDAData.education education = (ESDAData.education)Eduvalue;
                    Name = education.Name;
                    var blog = data.employees
                         .Where(b => b.Education == Name);
                    IntegratedItemControl.ItemsSource = blog.ToList();
                }
                else if (JobValue.ToString().Equals("ESDAData.job"))
                {
                    ESDAData.job job = (ESDAData.job)JobValue;
                    Name = job.Name;
                    var blog = data.employees
                         .Where(b => b.Job == Name);
                    IntegratedItemControl.ItemsSource = blog.ToList();
                }
                else if (GenderValue.ToString().Equals("ESDAData.Gender"))
                {
                    ESDAData.employee employee = (ESDAData.employee)GenderValue;
                    Name = employee.Gender;
                    var blog = data.employees
                         .Where(b => b.Gender == Name);
                    IntegratedItemControl.ItemsSource = blog.ToList();
                }
            }
            catch (Exception ex)
            {

            }

        }
    }
}

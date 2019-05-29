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

namespace ESDAHRMSystem
{
    /// <summary>
    /// Interaction logic for Employee.xaml
    /// </summary>
    public partial class Employee : UserControl
    {
       private ESDAData.esdaEntities data;
        Object Eduvalue,GenderValue,JobValue;
        string value;
        private ESDAData.employee employee;
        private View.AddEmployee emplo;
        public delegate void MyDelegate(Object value);
        public event MyDelegate MyCustomEvent;
          
        public Employee()
        {
            emplo = new View.AddEmployee();
            InitializeComponent();
            data = new ESDAData.esdaEntities();
            
        }

        private void MyEventHandlerFunction_StatusUpdated(object sender, EventArgs e)
        {
            MessageBox.Show("Clicked");
        }

        private void EmployeeData_Loaded(object sender, RoutedEventArgs e)
        {
            EmployeeData.ItemsSource = data.employees.ToList();
        }

        private void ComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            FirstNameCombo.ItemsSource = data.genders.ToList();
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
            MiddleNameCombo.ItemsSource = data.jobs.ToList();
            MiddleNameCombo.SelectedValue = "Name";
            MiddleNameCombo.DisplayMemberPath = "Name";
        }

        private void EmployeeData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Object dataEmp = EmployeeData.SelectedItem;
            MessageBox.Show(dataEmp.ToString());
             employee = (ESDAData.employee)dataEmp;
            MessageBox.Show(employee.FirstName);

            View.SpecificEmployee specific = new View.SpecificEmployee(employee.FirstName);
            EmployeeStackPanel.Children.Clear();
            EmployeeStackPanel.Children.Add(specific);



        }

    

        private int GetRowData() {
            Object data = EmployeeData.SelectedItem;
            ESDAData.employee emp = (ESDAData.employee)data;
            
            return emp.ID;
        }

        

        private void EducationCombo_Loaded(object sender, RoutedEventArgs e)
        {
            EducationCombo.ItemsSource = data.educations.ToList();
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
                    EmployeeData.ItemsSource = blog.ToList();
                }
                else if (JobValue.ToString().Equals("ESDAData.job"))
                {
                    ESDAData.job job = (ESDAData.job)JobValue;
                    Name = job.Name;
                    var blog = data.employees
                         .Where(b => b.Job == Name);
                    EmployeeData.ItemsSource = blog.ToList();
                }
                else if (GenderValue.ToString().Equals("ESDAData.Gender"))
                {
                    ESDAData.employee employee = (ESDAData.employee)GenderValue;
                    Name = employee.Gender;
                    var blog = data.employees
                         .Where(b => b.Gender == Name);
                    EmployeeData.ItemsSource = blog.ToList();
                }
            }
            catch (Exception ex) {

            }

        }
    }
}

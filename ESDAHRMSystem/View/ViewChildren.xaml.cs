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
    /// Interaction logic for ViewChildren.xaml
    /// </summary>
    public partial class ViewChildren : UserControl
    {
        private ESDAData.esdaEntities data;
        Object Eduvalue, GenderValue, JobValue;
        List<string> comboList;
        private ESDAData.child childrenData;
        
        public delegate void MyDelegate(Object value);
        
        public ViewChildren()
        {
            
           
            InitializeComponent();
            data = new ESDAData.esdaEntities();
            comboList = new List<string>();
        }
        private void EmployeeData_Loaded(object sender, RoutedEventArgs e)
        {
            ESDAData.esdaEntities dc = new ESDAData.esdaEntities();

            var child = (from p in dc.children where p.Status!="Not living" select p);
            EmployeeData.ItemsSource = child.ToList();
        }
        private void Load() {
            ESDAData.esdaEntities dc = new ESDAData.esdaEntities();

            var child = (from p in dc.children where p.Status != "Not living" select p);
            EmployeeData.ItemsSource = child.ToList();
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
            MiddleNameCombo.ItemsSource = data.houses.ToList();
            MiddleNameCombo.SelectedValue = "Name";
            MiddleNameCombo.DisplayMemberPath = "Name";
        }

        private void EmployeeData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            



        }



        private int GetRowData()
        {
            Object data = EmployeeData.SelectedItem;
            ESDAData.child emp = (ESDAData.child)data;

            return emp.ID;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            
        }
        private void edit() {
            int ID = GetRowData();
            using (var db = new ESDAData.esdaEntities())

            {
                var result = db.children.SingleOrDefault(b => b.ID == ID);
                if (result != null)
                {
                    result.FirstName = "";
                }
            }
        }

        private void ChildrenView_Loaded(object sender, RoutedEventArgs e)
        {
           
        }

        private void EmployeeData_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //Object dataEmp = EmployeeData.SelectedItem;
            //MessageBox.Show(dataEmp.ToString());
            //childrenData = (ESDAData.child)dataEmp;
            //MessageBox.Show(childrenData.FirstName);

            //View.SpecificEmployee specific = new View.SpecificEmployee(childrenData.FirstName);
            //EmployeeStackPanel.Children.Clear();
            //EmployeeStackPanel.Children.Add(specific);
            //EmployeeStackPanel.Children.Add(specific);
        }

        private void EmployeeData_CurrentCellChanged(object sender, EventArgs e)
        {
            
        }

        private void EditButton_Click_1(object sender, RoutedEventArgs e)
        {
            ESDAData.esdaEntities dc = new ESDAData.esdaEntities();
            ESDAData.child c = EmployeeData.SelectedItem as ESDAData.child;
            int m = c.ID;
            ESDAData.child child = (from p in dc.children where p.ID == c.ID select p).Single();
            MessageBox.Show("removed successfully");
            Load();


        }

        private void DeleteButton_Click_1(object sender, RoutedEventArgs e)
        {

            ESDAData.esdaEntities dc = new ESDAData.esdaEntities();
            ESDAData.child c = EmployeeData.SelectedItem as ESDAData.child;
            int m = c.ID;
            ESDAData.child child = (from p in dc.children where p.ID == c.ID select p).Single();
            child.Status = "Not living";
            dc.SaveChanges();
            MessageBox.Show("removed successfully");
            Load();
        }

      

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
            GenderValue = FirstNameCombo.SelectedItem;
            JobValue = MiddleNameCombo.SelectedItem;
          
             if (JobValue.ToString().Equals("ESDAData.job"))
            {
                ESDAData.house job = (ESDAData.house)JobValue;
                Name = job.Name;
                var blog = data.employees
                     .Where(b => b.Job == Name);
                EmployeeData.ItemsSource = blog.ToList();
            }
            else if (GenderValue.ToString().Equals("ESDAData.Gender"))
            {
                ESDAData.gender employee = (ESDAData.gender)GenderValue;
                Name = employee.Name;
                var blog = data.employees
                     .Where(b => b.Gender == Name);
                EmployeeData.ItemsSource = blog.ToList();
            }

        }
    }
}

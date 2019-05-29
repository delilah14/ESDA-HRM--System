using System;
using System.Collections.Generic;
using System.IO;
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
using static System.Windows.Media.Imaging.BitmapCreateOptions;

using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Data.Entity;

namespace ESDAHRMSystem.View
{
    /// <summary>
    /// Interaction logic for SpecificEmployee.xaml
    /// </summary>
    public partial class SpecificEmployee : UserControl
    {
        private Employee emp;
        private ESDAData.esdaEntities dbcontext;
        private string name,editedName,editedLastName,empName,empLastName;
        IBindingList binding;
        public SpecificEmployee()
        {
            InitializeComponent();
             this.emp = new Employee();
            this.dbcontext = new ESDAData.esdaEntities();

        }
        public SpecificEmployee(string NAME) {
            InitializeComponent();
            this.dbcontext = new ESDAData.esdaEntities();
            ESDAData.employee employee = new ESDAData.employee();
            this.empName = NAME;
            var blog = dbcontext.employees
                 .Where(b => b.FirstName == NAME).ToList();
   
            foreach (var item in blog)
            {
                MessageBox.Show("this is the picture path"+item.PicturePath);
                EmployeeName.Text = item.FirstName + " " + item.MiddleName;
                FirstName.Text = item.FirstName;
                LastName.Text = item.MiddleName;
                this.empLastName = item.MiddleName;
                EmpImage.Source = LoadBitmapImage(item.PicturePath);
                House.Text = item.House;

            }
           
            AccountIcon.Visibility = Visibility.Collapsed;
            
            EmpImage.Visibility = Visibility.Visible;
            
           
        }
        public static BitmapImage LoadBitmapImage(byte[] bytes) {
            var image = new BitmapImage();
            using (var stream = new MemoryStream(bytes)) {
                stream.Seek(0, SeekOrigin.Begin);
                image.BeginInit();
                image.StreamSource = stream;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.CreateOptions = PreservePixelFormat;
                image.UriSource = null;
                image.EndInit();

            }
            return image;


        }

        private void PackIcon_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.addChild(this);
        }

        internal void AddChildControl(MainWindow mainWindow)
        {
            
            
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            



        }

        private void House_Loaded(object sender, RoutedEventArgs e)
        {
            
            var blog = dbcontext.children
                 .Where(b => b.FirstName == this.empName).ToList();

            foreach (var item in blog)
            {
                Gender.Text += "  "+ item.Gender;
                DOJ.Text += "  " + item.DateOfJoin.ToString();
                House.Text += "  " + item.House;
                Status.Text += "  " + item.Status;
                medicalPAth.Text += "  " + item.MedicalPath;
                



            }
        }

        private void Flipper_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
          
        }

        private void Flipper_Loaded(object sender, RoutedEventArgs e)
        {
            EmployeeNameFlip.Text = this.empName + this.empLastName;

            FirstName.Text = this.empName;
            LastName.Text = this.empLastName;
        }

        private void employee_MyCustomEvent(object value)
        {
            MessageBox.Show(value.ToString());
        }

        private void Flipper_IsFlippedChanged(object sender, RoutedPropertyChangedEventArgs<bool> e)
        {
            this.editedName = FirstName.Text.ToString();
            this.editedLastName = LastName.Text.ToString();
            EmployeeNameFlip.Text = editedName + " " + editedLastName;
        }
    }

      

    }



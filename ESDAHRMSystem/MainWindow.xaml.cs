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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private View.AddEmployee emp;
        private FrontPage fp;
        private string data;

        public MainWindow()
        {
            
            
            InitializeComponent();
            fp = new FrontPage();
            MainWindowTreeView.Visibility = Visibility.Collapsed;
            fp.DataAvailable += new EventHandler(child_DataAvailable);
            Grid.SetRow(fp, 0);
            Grid.SetColumn(fp, 0);
            Grid.SetColumnSpan(fp, 3);
            MainWindowGrid.Children.Add(fp);
            AddHandler(FrontPage.LoginEvent, new RoutedEventHandler(loginevent_eventhandler_method));
           

        }

        private void child_DataAvailable(object sender, EventArgs e)
        {
          this.data = fp.Data;
        }

        private void loginevent_eventhandler_method(object sender, RoutedEventArgs e)
        {
            MainWindowGrid.Children.Remove(fp);
            MainWindowTreeView.Visibility = Visibility.Visible;
            WelcomeTextBlock.Text = "Welcome " + fp.Data + "!";

        }

        private void MyEventHandlerFunction_StatusUpdated(object sender, EventArgs e)
        {
            MainStackPanel.Children.Clear();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            View.AddEmployee employee = new View.AddEmployee();
            MainWindow window = new MainWindow();
            MainStackPanel.Children.Clear();
            MainStackPanel.Children.Add(employee);
        }


        private void TreeViewItem_Selected(object sender, RoutedEventArgs e)
        {
            Employee employee = new Employee();
            MainStackPanel.Children.Clear();
            MainStackPanel.Children.Add(employee);
           
        }

        public void clear(string v)
        {

            MainWindowTreeView.Visibility = Visibility.Visible;


        }

        private void AttendanceTreeView_Selected(object sender, RoutedEventArgs e)
        {
            MainStackPanel.Children.Clear();
            View.Attendance attend = new View.Attendance();
            MainStackPanel.Children.Add(attend);
         
        }

        public void addChild(UserControl user) {
            MainStackPanel.Children.Clear();

            var usercontrol1 = new View.SpecificEmployee();
            usercontrol1.AddChildControl(this);
        }

        private void AddChildrenTreeView_Loaded(object sender, RoutedEventArgs e)
        {
            

        }

        private void AddChildrenTreeView_Selected(object sender, RoutedEventArgs e)
        {
            MainStackPanel.Children.Clear();
            View.AddChildren child = new View.AddChildren();
            MainStackPanel.Children.Add(child);
        }

        private void ChildrenTreeView_Selected(object sender, RoutedEventArgs e)
        {
            View.ViewChildren employee = new View.ViewChildren();
            MainStackPanel.Children.Clear();
            MainStackPanel.Children.Add(employee);

        }

        private void HOHTree_Selected(object sender, RoutedEventArgs e)
        {
            View.IntegratedChildren employee = new View.IntegratedChildren();
            MainStackPanel.Children.Clear();
            MainStackPanel.Children.Add(employee);

        }

        private void TreeViewItem_Selected_1(object sender, RoutedEventArgs e)
        {
            View.HOH employee = new View.HOH();
            MainStackPanel.Children.Clear();
            MainStackPanel.Children.Add(employee);
        }

        private void EBTree_Selected(object sender, RoutedEventArgs e)
        {
            View.EGCH employee = new View.EGCH();
            MainStackPanel.Children.Clear();
            MainStackPanel.Children.Add(employee);
        }

        private void LHTree_Selected(object sender, RoutedEventArgs e)
        {
            View.LH employee = new View.LH();
            MainStackPanel.Children.Clear();
            MainStackPanel.Children.Add(employee);
        }

        private void ImageButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddEmployeeTreeView_Selected(object sender, RoutedEventArgs e)
        {
            View.AddEmp employee = new View.AddEmp();
            MainStackPanel.Children.Clear();
            MainStackPanel.Children.Add(employee);
        }
    }
}

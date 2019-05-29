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
    /// Interaction logic for Attendance.xaml
    /// </summary>
    public partial class Attendance : UserControl
    {
        private ESDAData.esdaEntities dbContext;
        private int ID;
        public Attendance()
        {
            InitializeComponent();
            dbContext = new ESDAData.esdaEntities();
        }

        private void AttendanceItemControl_Loaded(object sender, RoutedEventArgs e)
        {


            var blog = dbContext.attendances;
            foreach (var item in blog)
            {
                ID = item.EmpID;
            }
            var newBlog = dbContext.employees
                    .Where(b => b.ID == ID);
            AttendanceItemControl.ItemsSource = newBlog.ToList();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

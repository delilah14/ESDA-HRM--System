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
    /// Interaction logic for LH.xaml
    /// </summary>
    public partial class LH : UserControl
    {
        private ESDAData.esdaEntities dbContext;
        public LH()
        {
            InitializeComponent();
            dbContext = new ESDAData.esdaEntities();
        }

        private void LHItemControl_Loaded(object sender, RoutedEventArgs e)
        {
            var blog = dbContext.children
                   .Where(b => b.House == "House of Hope");
            LHItemControl.ItemsSource = blog.ToList();
        }
    }
}

using Microsoft.Win32;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ESDAHRMSystem.View
{
    /// <summary>
    /// Interaction logic for AddChildren.xaml
    /// </summary>
    public partial class AddChildren : UserControl
    {
        private ESDAData.esdaEntities data;
        private Model.CRUD crud;
        private string picturePath,  medicalPath, house, gender;
        public AddChildren()
        {
            this.crud = new Model.CRUD();
            this.data = new ESDAData.esdaEntities();
            InitializeComponent();
        }

        private void GenderCombo_Loaded(object sender, RoutedEventArgs e)
        {
            GenderCombo.ItemsSource = data.genders.ToList();
            GenderCombo.SelectedValue = "Name";
            GenderCombo.DisplayMemberPath = "Name";
        }

        private void HouseCombo_Loaded(object sender, RoutedEventArgs e)
        {
            HouseCombo.ItemsSource = data.houses.ToList();
            HouseCombo.SelectedValue = "Name";
            HouseCombo.DisplayMemberPath = "Name";

        }

        private void pictureButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.ShowDialog();
                var sourceFile = openFileDialog.FileName;
                var newFileName = @"\" + openFileDialog.SafeFileName;

                var targetPath = @"C:\Users\Delilah Dessalegn\Documents\ESDAImages";
                this.picturePath = targetPath + newFileName;
                if (!Directory.Exists(targetPath) && (!targetPath.Equals("")))
                {
                    Directory.CreateDirectory(targetPath);
                }
                else
                {
                    File.Copy(sourceFile, this.picturePath);

                    MessageBox.Show(newFileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("File not saved");


            }

        }

        private void medicalButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.ShowDialog();
                var sourceFile = openFileDialog.FileName;
                var newFileName = @"\" + openFileDialog.SafeFileName;

                var targetPath = @"C:\Users\Delilah Dessalegn\Documents\ESDAMedicalReports";
                this.medicalPath = targetPath + newFileName;
                if (!Directory.Exists(targetPath) && (!targetPath.Equals("")))
                {
                    Directory.CreateDirectory(targetPath);
                }
                else
                {
                    File.Copy(sourceFile, this.medicalPath);
                    MessageBox.Show(newFileName);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("File not saved");

            }
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            getComboBoxValue();
            DateTime dateTime = new DateTime();
            
            string status = "living";
            try
            {
                this.crud.CreateChildren(Fname.Text, Mname.Text, Lname.Text, (DateTime)DOB.SelectedDate, this.house,
                    this.picturePath, this.medicalPath, this.gender, (DateTime)DOJ.SelectedDate, status, dateTime.Date);
                MessageBox.Show("Children Added");
                Fname.Text = "";
                Mname.Text = "";
                Lname.Text = "";

                DOB.Text = "";
                DOJ.Text = "";
                HouseCombo.Text = "";

                GenderCombo.Text = "";
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }


        }

        private void getComboBoxValue()
        {
            ESDAData.house h = (ESDAData.house)(HouseCombo.SelectedItem);
            
            this.house = h.Name;

            ESDAData.gender gender = (ESDAData.gender)(GenderCombo.SelectedItem);
            
            this.gender = gender.Name;

        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

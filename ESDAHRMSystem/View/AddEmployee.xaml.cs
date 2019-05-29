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
    /// Interaction logic for AddEmployee.xaml
    /// </summary>
    public partial class AddEmployee : UserControl
    {
        private ESDAData.esdaEntities data;
        private Model.CRUD crud;
        private string picturePath, resumePath, medicalPath, education, gender, job;
        public event EventHandler StatusUpdated;
        public AddEmployee()
        {
            this.crud = new Model.CRUD();
            this.data = new ESDAData.esdaEntities();
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.StatusUpdated != null)
                this.StatusUpdated(this, new EventArgs());

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
                if (!Directory.Exists(targetPath)&&(!targetPath.Equals("")))
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

        private void resumeButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.ShowDialog();
                var sourceFile = openFileDialog.FileName;
                var newFileName = @"\" + openFileDialog.SafeFileName;

                var targetPath = @"C:\Users\Delilah Dessalegn\Documents\ESDAResume";
                this.resumePath = targetPath + newFileName;
                if (!Directory.Exists(targetPath) && (!targetPath.Equals("")))
                {
                    Directory.CreateDirectory(targetPath);

                }
                else
                {
                    File.Copy(sourceFile, this.resumePath);
                    MessageBox.Show(newFileName);
                }
            }
            catch (Exception ex ) {
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
           
            Mname.Text = "";
            Fname.Text = "";
            Lname.Text = "";
            Salary.Text = "";
            DOB.Text = "";
            EducationCombo.Text = "";
            JobCombo.Text = "";
            GenderCombo.Text = "";
        }

        private void getComboBoxValue() {
           
                ESDAData.education education = (ESDAData.education)(EducationCombo.SelectedItem);
                Name = education.Name;
                this.education = Name;
           
            
                ESDAData.job job = (ESDAData.job)(JobCombo.SelectedItem);
                Name = job.Name;
                this.job = Name;
             
           
            
                ESDAData.gender gender = (ESDAData.gender)(GenderCombo.SelectedItem);
                Name = gender.Name;
                this.gender = Name;
           
        }
        private void ComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            GenderCombo.ItemsSource = data.genders.ToList();
            GenderCombo.SelectedValue = "Name";
            GenderCombo.DisplayMemberPath = "Name";
        }

        private void MiddleNameCombo_Loaded(object sender, RoutedEventArgs e)
        {
            JobCombo.ItemsSource = data.jobs.ToList();
            JobCombo.SelectedValue = "Name";
            JobCombo.DisplayMemberPath = "Name";
        }


        private void EducationCombo_Loaded(object sender, RoutedEventArgs e)
        {
            EducationCombo.ItemsSource = data.educations.ToList();
            EducationCombo.SelectedValue = "Name";
            EducationCombo.DisplayMemberPath = "Name";
        }
    }
}

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
using MaterialDesignThemes;
using MaterialDesignColors;

namespace ESDAHRMSystem
{
    /// <summary>
    /// Interaction logic for FrontPage.xaml
    /// </summary>
    public partial class FrontPage : UserControl
    {
        private ESDAData.esdaEntities data;
        public event EventHandler DataAvailable;
        System.Drawing.Image imageContent;
        private byte[] ImageContent;
        private Model.CRUD crud;
        private string picturePath, resumePath, medicalPath, education, gender, job, username, password, house,pictureSourceFile
            , sourceFile, targetPath, medicalFileName,resumeFileName,pictureFileName,pictureTargetPath,medicalTargetPath,resumeTargetPath;
        public static readonly RoutedEvent LoginEvent = EventManager.RegisterRoutedEvent("LoginEvent", RoutingStrategy.Bubble,
            typeof(RoutedEventHandler), typeof(FrontPage));

        public string Data
        {
            get { return Username.Text; }
            set { Username.Text = value; }
        }
        protected virtual void OnDataAvailable(EventArgs e)
        {
            EventHandler eh = DataAvailable;
            if (eh != null)
            {
                eh(this, e);
            }
        }
        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void ImageButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            this.pictureSourceFile = openFileDialog.FileName;
            this.pictureFileName = @"\" + this.username + openFileDialog.SafeFileName;

            this.pictureTargetPath = @"C:\Users\Delilah Dessalegn\Documents\ESDAImages";
            this.picturePath = this.pictureTargetPath + this.pictureFileName;

            try
            {
               
                Uri imageUri = new Uri(this.pictureSourceFile);
                BitmapImage imageBitmap = new BitmapImage(imageUri);
                ImageButtonImage.Source = imageBitmap;
            }
            catch (Exception ex)
            {

           
            }
          
        }

        private void AddmedicalChip_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            this.sourceFile = openFileDialog.FileName;
            this.medicalFileName = @"\"+this.username+ openFileDialog.SafeFileName;

            this.medicalTargetPath = @"C:\Users\Delilah Dessalegn\Documents\ESDAMedicalReports";
            this.medicalPath = medicalTargetPath + this.medicalFileName;
            AddMedicalChip.Content = medicalFileName;
            AddmedicalChip.Visibility = Visibility.Collapsed;
            AddMedicalChip.Visibility = Visibility.Visible;
            
        }
        private void getComboBoxValue()
        {
           
            ESDAData.education education = (ESDAData.education)(EduCombo.SelectedItem);
            
            this.education = education.Name;


            ESDAData.job job = (ESDAData.job)(JobCombo.SelectedItem);
           
            this.job = job.Name;



            ESDAData.gender gender = (ESDAData.gender)(GenderCombo.SelectedItem);
            
            this.gender = gender.Name;

            ESDAData.house house = (ESDAData.house)(HouseCombo.SelectedItem);
            
            this.house = house.Name;

        }

        private void Addresumechip_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg)|*.jpg|All Files (*.*)|*.*";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.ShowDialog();
            var sourceFile = openFileDialog.FileName;
           this.resumeFileName = @"\" + this.username + openFileDialog.SafeFileName;

            this.resumeTargetPath = @"C:\Users\Delilah Dessalegn\Documents\ESDAResume";
            this.resumePath = this.resumeTargetPath + this.resumeFileName;
            AddResumeChip.Content = resumeFileName;
            Addresumechip.Visibility = Visibility.Collapsed;
            AddResumeChip.Visibility = Visibility.Visible;

        }

       
        private void addPicture() {
            try
            {
               
                if (!Directory.Exists(this.pictureTargetPath) && (!this.pictureTargetPath.Equals("")))
                {
                    Directory.CreateDirectory(this.pictureTargetPath);
                }
                else
                {
            
                    imageContent = System.Drawing.Image.FromFile(this.pictureSourceFile);
                    ImageContent = ImageToByteArray(imageContent);
                    MessageBox.Show(this.pictureFileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Image error: "+ ex.Message);


            }
        }
        private void addResume() {
            try
            {
                
                if (!Directory.Exists(this.resumeTargetPath) && (!this.resumeTargetPath.Equals("")))
                {
                    Directory.CreateDirectory(this.resumeTargetPath);

                }
                else
                {
                    File.Copy(sourceFile, this.resumePath);
                    MessageBox.Show(this.resumeFileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Resume not saved");
            }
        }
        private void AddMedicalReport() {
            try
            {
                
                if (!Directory.Exists(this.medicalTargetPath) && (!this.medicalTargetPath.Equals("")))
                {
                    Directory.CreateDirectory(this.medicalTargetPath);
                }
                else
                {
                    File.Copy(sourceFile, this.medicalPath);
                    MessageBox.Show(this.resumeFileName);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Medical not saved");

            }
        }
      

        private void HouseCombo_Loaded(object sender, RoutedEventArgs e)
        {

            
            HouseCombo.ItemsSource = data.houses.ToList();
            HouseCombo.SelectedValue = "Name";
            HouseCombo.DisplayMemberPath = "Name";
        }
       

        private void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            bool isValid = IsValidEmail(email.Text);
            MessageBox.Show(isValid.ToString());
            getComboBoxValue();
            addPicture();
            crud.CreateEmployee(Fname.Text.ToString(), Mname.Text.ToString(),
                Lname.Text.ToString(), (DateTime)DOB.SelectedDate, email.Text.ToString(),
                phone.Text.ToString(), this.house.ToString(), int.Parse(Salary.Text.ToString()),
                this.resumePath.ToString(), this.ImageContent, this.medicalPath.ToString(), this.job.ToString(), this.gender.ToString(), this.education.ToString());

          


            int ID = crud.getEmpID(Fname.Text);
                
            crud.CreateAccount(user.Text,pass.Password,ID);
            
            addResume();
            AddMedicalReport();
           
            Fname.Text = "";
            Mname.Text = "";
            Lname.Text = "";
            Salary.Text = "";
            DOB.Text = "";
            email.Text = "";
            phone.Text = "";
            EduCombo.Text = "";
            JobCombo.Text = "";
            GenderCombo.Text = "";
            HouseCombo.Text = "";
            user.Text = "";
            pass.Password = "";
            MessageBox.Show("Account created");
         
        }

        private void SigninButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.username = Username.Text;
                this.password = Password.Password;
                int ID = crud.validateUsername(username, password);
                if (ID == 0)
                {

                    incorrect.Visibility = Visibility.Visible;
                }
                else
                {

                    RaiseEvent(new RoutedEventArgs(LoginEvent));
                    OnDataAvailable(null);

                }
            }
            catch (Exception ex) {

                MessageBox.Show("incorrect username or password");
            }

           
        }
        public byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, imageIn.RawFormat);
                return ms.ToArray();
            }
        }
        public System.Drawing.Image byteArrayToImage(byte[] byteArrrayIn) {
            MemoryStream ms = new MemoryStream(byteArrrayIn);
            System.Drawing.Image returnImage = System.Drawing.Image.FromStream(ms);
            return returnImage;
        }

        public FrontPage()
        {
            this.crud = new Model.CRUD();
            this.data = new ESDAData.esdaEntities();
            InitializeComponent();
        }

        private void ComboBox_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void JobCombo_Loaded(object sender, RoutedEventArgs e)
        {
            JobCombo.ItemsSource = data.jobs.ToList();
            JobCombo.SelectedValue = "Name";
            JobCombo.DisplayMemberPath = "Name";
        }

        private void GenderCombo_Loaded(object sender, RoutedEventArgs e)
        {
            GenderCombo.ItemsSource = data.genders.ToList();
            GenderCombo.SelectedValue = "Name";
            GenderCombo.DisplayMemberPath = "Name";

        }

        private void EduCombo_Loaded(object sender, RoutedEventArgs e)
        {
            EduCombo.ItemsSource = data.educations.ToList();
            EduCombo.SelectedValue = "Name";
            EduCombo.DisplayMemberPath = "Name";

        }
    }
}

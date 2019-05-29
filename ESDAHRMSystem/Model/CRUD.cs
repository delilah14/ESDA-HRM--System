using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESDAData;

namespace ESDAHRMSystem.Model
{
    class CRUD
    {
        private esdaEntities dataContext;
        private employee emp;
        private child c;
        private account acc;
        private int ID;
        public CRUD() {
             this.dataContext = new esdaEntities();
        }
        public void CreateEmployee(String FirstName, String MiddleName, String LastName, DateTime DOB,String email,String phone,String house, int Salary, 
            String ResumePath, byte[] PicturePath, String MedicalPath, String job, String Gender, String Education
            ) {
            this.emp = new employee();
            emp.FirstName = FirstName;
            emp.MiddleName = MiddleName;
            emp.LastName = LastName;
            emp.DOB = DOB;
            emp.email = email;
            emp.phonenumber = phone;
            emp.House = house;
            emp.Salary = Salary;
            emp.ResumePath = ResumePath;
            Console.WriteLine("Picture path:"+PicturePath);
            emp.PicturePath = PicturePath;
            emp.MedicalPath = MedicalPath;
            emp.Job = job;
            emp.Gender = Gender;
            emp.Education = Education;
            this.dataContext.employees.Add(emp);
            try
            {
                this.dataContext.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbex)
            {
                Exception raise = dbex;
                foreach (var validateError in dbex.EntityValidationErrors)
                {
                    foreach (var validate in validateError.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                        validateError.Entry.Entity.ToString(), validate.ErrorMessage);
                        raise = new InvalidOperationException(message,raise);
                    }
                }
                throw raise;
            }
            
               
            
           
                
            
        }
        public void CreateChildren(String FirstName, String MiddleName, String LastName, DateTime DOB, String House,
           String PicturePath, String MedicalPath, String gender, DateTime DOJ, String Status, DateTime DOL) {
            this.c = new child();
            c.FirstName = FirstName;
            c.MiddleName = MiddleName;
            c.LastName = LastName;
            c.DOB = DOB;
            c.House = House;
            c.PicturePath = PicturePath;
            c.MedicalPath = MedicalPath;
            c.Gender = gender;
            c.DateOfJoin = DOJ;
            c.Status = Status;
            c.DateOfLeave = DOL;
           
                this.dataContext.children.Add(c);
                this.dataContext.SaveChanges();
        }
        public void CreateAccount(String username, String password, int empID ) {
            this.acc = new account();
            acc.username = username;
            acc.password = password;
            acc.empID = empID;
                this.dataContext.accounts.Add(acc);
                this.dataContext.SaveChanges();
            }
        public int getEmpID(String firstName) {

            var blog = this.dataContext.employees
                    .Where(b => b.FirstName == firstName).Select(b => b.ID);
            foreach (var item in blog)
            {
                this.ID = item;
            }
            return ID;
        }
        public int validateUsername(String username,String password)
        {

            var blog = this.dataContext.accounts
                    .Where(b => b.username == username).Where(b=>b.password==password).Select(b => b.ID);
            foreach (var item in blog)
            {
                this.ID = item;
            }
            return ID;
        }
    }
}

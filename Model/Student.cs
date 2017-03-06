using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;


namespace Models
{
    [Serializable]
    public class Student : ViewModelBase , IDataErrorInfo
    {

        private string m_firstName;

       

        /// <summary>
        /// Gets or sets the Id of this Student
        /// </summary>
        public virtual int StudentId { get; set; }
                     
        /// <summary>
        /// Gets or sets this Student first name
        /// </summary>
         public virtual string FirstName
         {
            get { return m_firstName; }
            set { m_firstName = value;
            OnPropertyChanged("FirstName");
            }
         }

        /// <summary>
        /// Gets or sets this Student last name
        /// </summary>
        public virtual string LastName { get; set; }

        /// <summary>
        /// Gets or sets this Student last name
        /// </summary>
        public virtual DateTime  BirthDay { get; set; }

        /// <summary>
        /// Gets or sets this Student last name
        /// </summary>
        public virtual string Address { get; set; }

        /// <summary>
        /// Gets or sets this Student last name
        /// </summary>
        public virtual string City { get; set; }

        /// <summary>
        /// Gets or sets this Student last name
        /// </summary>
        public virtual string Phone1 { get; set; }

        /// <summary>
        /// Gets or sets this Student last name
        /// </summary>
        public virtual string Phone2 { get; set; }

        /// <summary>
        /// Gets or sets this Student last name
        /// </summary>
        public virtual string Phone3 { get; set; }

        /// <summary>
        /// Gets or sets this Student last name
        /// </summary>
        public virtual string MomName { get; set; }

        /// <summary>
        /// Gets or sets this Student last name
        /// </summary>
        public virtual string DadName { get; set; }

        public virtual string TZ { get; set; }

        /// <summary>
        /// Gets or sets StudentPicture
        /// </summary>       
        public virtual  string   pix { get; set; }

        public virtual int ClassID { get; set; }

        /// <summary>
        /// Returns true if this object has no validation errors.
        /// </summary>
        public bool IsValid
        {
            get
            {
                foreach (string property in ValidatedProperties)
                    if (GetValidationError(property) != null)
                        return false;

                return true;
            }
        }

        static readonly string[] ValidatedProperties = 
        { 
            "Address", 
            "FirstName", 
            "LastName",
        };

        #region IDataErrorInfo Members

        string IDataErrorInfo.Error { get { return null; } }

        string IDataErrorInfo.this[string propertyName]
        {
            get { return this.GetValidationError(propertyName); }
        }

        private string GetValidationError(string propertyName)
        {
            if (Array.IndexOf(ValidatedProperties, propertyName) < 0)
                return null;

            Type type = typeof(Student);
            System.Reflection.PropertyInfo pi= type.GetProperty(propertyName);
           string o=(string)  pi.GetValue(this,null);
            if (IsStringMissing(o))
                return propertyName + " - cannot be empty";
            else
                return null;
        }





        //string ValidateField()
        //{
        //    if (IsStringMissing(this.FirstName))
        //    {
        //        return Strings.Customer_Error_MissingFirstName;
        //    }
        //    return null;
        //}

        static bool IsStringMissing(string value)
        {
            return
                String.IsNullOrEmpty(value) ||
                value.Trim() == String.Empty;
        }

        #endregion // IDataErrorInfo Members
    }
}

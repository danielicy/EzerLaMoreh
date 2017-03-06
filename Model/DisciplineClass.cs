using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enums;

namespace Models
{
     [Serializable]
    public class DisciplineClass : ViewModelBase
    {
         private int m_studentId;
         private PresenceEnum M_presence;
         private ArrivalEnum m_arrival;
         private AttitudeEnum m_attitude;
         private AttitudeEnum m_socialBehave;
         private  string m_comments;


        /// <summary>
        /// Gets or sets the Id of this Student
        /// </summary>
        public int StudentId
        {
            get { return m_studentId; }
            set { 
                m_studentId = value;
                OnPropertyChanged("StudentId");
            }
        }
       
        /// <summary>
        /// Gets or sets this Student EntryDate
        /// </summary>
        public virtual DateTime EntryDate { get; set; }
        
        /// <summary>
        /// Gets or sets this Student Presence grade
        /// </summary>
        public virtual PresenceEnum Presence
        {
            get { return M_presence; }
            set { 
                M_presence = value;
                OnPropertyChanged("Presence");
            }
        }

        /// <summary>
        /// Gets or sets this Student Presence grade
        /// </summary>
        public virtual ArrivalEnum Arrival
        {
            get { return m_arrival; }
            set { 
                m_arrival = value;
                OnPropertyChanged("Arrival");
            }
        }

        /// <summary>
        /// Gets or sets this Student Attitude grade
        /// </summary>
        public virtual AttitudeEnum Attitude
        {
            get { return m_attitude; }
            set { m_attitude = value;
            OnPropertyChanged("Attitude");
            }
        }


        /// <summary>
        /// Gets or sets this Student Presence grade
        /// </summary>
        public virtual AttitudeEnum SocialBehave
        {
            get { return m_socialBehave; }
            set { m_socialBehave = value;
            OnPropertyChanged("SocialBehave");
            }
        }

        /// <summary>
        /// Gets or sets this comments on behavior
        /// </summary>
        public virtual string Comments
        {
            get { return m_comments; }
            set { m_comments = value;
            OnPropertyChanged("Comments");
            }
        }
                
    }
}




//namespace Models
//{
//     [Serializable]
//    public class DisciplineClass : ModelBase
//    {
//        private int m_studentId;

//        /// <summary>
//        /// Gets or sets the Id of this Student
//        /// </summary>
//        public int StudentId
//        {
//            get { return m_studentId; }
//            set { 
//                m_studentId = value;
//                OnPropertyChanged("StudentId");
//            }
//        }

       
//        /// <summary>
//        /// Gets or sets this Student EntryDate
//        /// </summary>
//        public virtual DateTime EntryDate { get; set; }
        
//        /// <summary>
//        /// Gets or sets this Student Presence grade
//        /// </summary>
//        public virtual PresenceEnum Presence { get; set; }

//        /// <summary>
//        /// Gets or sets this Student Presence grade
//        /// </summary>
//        public virtual ArrivalEnum Arrival { get; set; }

//        /// <summary>
//        /// Gets or sets this Student Attitude grade
//        /// </summary>
//        public virtual AttitudeEnum Attitude { get; set; }


//        /// <summary>
//        /// Gets or sets this Student Presence grade
//        /// </summary>
//        public virtual AttitudeEnum SocialBehave { get; set; }

//        /// <summary>
//        /// Gets or sets this comments on behavior
//        /// </summary>
//        public virtual string Comments { get; set; }  

                
//    }
//}

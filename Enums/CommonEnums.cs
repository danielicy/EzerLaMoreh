using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
using System.ComponentModel;
using System.Reflection;


namespace Enums
{

    #region Behave Enums

     [Description("נוכחות")]
    [TypeConverter(typeof(EnumTypeConverter))]
    public enum PresenceEnum 
    {
        [EnumDisplayName("נעדר")]
        absent=1,
        [EnumDisplayName("נעדר באישור")]
        authAbsent=2,
        [EnumDisplayName("נוכח")]
        present=3 
    }

     [Description("הגעה")]
     [TypeConverter(typeof(EnumTypeConverter))]
    public enum ArrivalEnum 
     {
         [EnumDisplayName("איחור")]
         Late = 1,
         [EnumDisplayName("איחור באישור")]
         authLate = 2,
         [EnumDisplayName("בזמן")]
         onTime = 3 
     }

     [Description("יחס")]
    [TypeConverter(typeof(EnumTypeConverter))]
    public enum AttitudeEnum 
    {
        [EnumDisplayName("גרוע")]
        irreverent = 1,
        [EnumDisplayName("בינוני")]
        mediocre = 2,
        [EnumDisplayName("מעולה")]
        excellent = 3
    }

    //[TypeConverter(typeof(EnumTypeConverter))]
    //public enum SocialBehaveEnum
    //{
    //    [EnumDisplayName("נעדר")]
    //    irreverent = 1,
    //    [EnumDisplayName("נעדר")]
    //    mediocre = 2,
    //    [EnumDisplayName("נעדר")]
    //    excellent = 3
    //}
    
    #endregion

    #region Behave Enums

    public enum QaEvalEnum { never = 1, sometimes = 2, always = 3 }
    
    #endregion

    #region Summary
    [Description("נוכחות")]
    [TypeConverter(typeof(EnumTypeConverter))]
    public enum PresenceTotEnum
    {
        [EnumDisplayName("נעדר באופן קבוע")]
        absent = 1,
        [EnumDisplayName("נעדר לעיתים קרובות")]
        oftenAbsent = 2,
        [EnumDisplayName("נעדר לעיתים רחוקות")]
        oftenPresent = 3,
          [EnumDisplayName("מגיע באופן קבוע")]
        alwaysPresent = 4
    }

    [Description("הגעה בזמן")]
    [TypeConverter(typeof(EnumTypeConverter))]
    public enum ArrivalTotEnum
    {

        [EnumDisplayName("אין מידע")]
        noData = 0,
        [EnumDisplayName("מאחר באופן קבוע")]
        alwaysLate = 1,
        [EnumDisplayName("מאחר לעיתים קרובות")]
        oftenLate = 2,
        [EnumDisplayName("מאחר לעיתים רחוקות")]
        oftenOnTime = 3,
         [EnumDisplayName("מדייק באופן קבוע")]
        alwaysOnTime = 4

    }

    [Description("יחס")]
    [TypeConverter(typeof(EnumTypeConverter))]
    public enum AttitudeTotEnum
    {
        [EnumDisplayName("מזלזל")]
        irreverent = 1,
        [EnumDisplayName("יוצא מידי חובה")]
        mediocre = 2,
        [EnumDisplayName("מתייחס ברצינות")]
        good = 3,
        [EnumDisplayName("יוצא מן הכלל")]
        excellent = 4
    }

    
    #endregion

    [TypeConverter(typeof(EnumTypeConverter))]
    public enum PeriodEnum
    {
        [EnumDisplayName("שבוע אחרון")]
        lastWeek = 1,
        [EnumDisplayName("חודש אחרון")]
        lastMonth = 2,
        [EnumDisplayName("מחצית נוכחית")]
        currentHalf = 3,
        [EnumDisplayName("מחצית קודמת")]
        previosHalf = 4,
        [EnumDisplayName("טווח תאריכים")]
        customPeriod = 5
    }

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class EnumDisplayNameAttribute : Attribute
    {
        public EnumDisplayNameAttribute(string displayName)
        {
            DisplayName = displayName;
        }

        public string DisplayName { get; set; }
    }
      
    
}

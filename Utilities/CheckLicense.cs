using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;

namespace Utilities
{
    public class CheckLicense
    {
        public CheckLicense()
        {

        }

        public bool Check()
        {
            return true  ;

        }

        private  string GetMotherBoardID()
        {
            string mbInfo = String.Empty;
            ManagementScope scope = new ManagementScope("\\\\" + Environment.MachineName + "\\root\\cimv2");
            
            scope.Connect();
            ManagementObject wmiClass = new ManagementObject(scope, new ManagementPath("Win32_BaseBoard.Tag=\"Base Board\""), new ObjectGetOptions());

            foreach (PropertyData propData in wmiClass.Properties)
            {
                if (propData.Name == "SerialNumber")
                    mbInfo = String.Format("{0,-25}{1}", propData.Name, Convert.ToString(propData.Value));
            }

            return mbInfo;
        }
    }
}

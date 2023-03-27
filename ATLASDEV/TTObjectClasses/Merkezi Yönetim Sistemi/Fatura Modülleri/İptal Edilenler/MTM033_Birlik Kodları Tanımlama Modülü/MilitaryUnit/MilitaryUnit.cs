
using System;
using System.Xml;
using System.Data;
using System.Text;
using System.Drawing;
using System.Reflection;
using System.Collections;
using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;

using TTUtils;
using TTObjectClasses;
using TTDataDictionary;
using TTCoreDefinitions;
using TTConnectionManager;
using TTInstanceManagement;
using TTDefinitionManagement;
using TTStorageManager.Security;



using TTStorageManager;
using System.Runtime.Versioning;


namespace TTObjectClasses
{
    /// <summary>
    /// Birlik Kodları Tanımları
    /// </summary>
    public  partial class MilitaryUnit : TerminologyManagerDef, IMilitaryUnit
    {
        public partial class GetMilitaryUnit_Class : TTReportNqlObject 
        {
        }

        public partial class OLAP_GetMilitaryUnit_WithDate_Class : TTReportNqlObject 
        {
        }

        public partial class OLAP_GetMilitaryUnit_Class : TTReportNqlObject 
        {
        }

        public partial class GetHCSenderChairMilitaryUnits_Class : TTReportNqlObject 
        {
        }

        public string ForcesCommandName
        {
            get
            {
                try
                {
#region ForcesCommandName_GetScript                    
                    if(ForcesCommand != null)
                return ForcesCommand.Name;
            else
                return String.Empty;
#endregion ForcesCommandName_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "ForcesCommandName") + " : " + ex.Message, ex);
                }
            }
        }

        #region Methods
        #region ITTCoreObject Members

        public TTObjectDef GetObjectDef()
        {
            return ObjectDef;
        }

        public Guid GetObjectID()
        {
            return ObjectID;
        }
        #endregion
        #region IMilitaryUnit Members
        public string GetCode()
        {
            return Code;
        }

        public string GetName()
        {
            return Name;
        }
        #endregion
        public override string ToString()
        {
            return Code + " " + Name;
        }
        
        public override SendDataTypesEnum?  GetMySendDataTypesEnum()
        {
            return SendDataTypesEnum.MilitaryUnitInfo;
        }
        
        public override bool IsActiveLocal()
        {
            return false;
        }
        
        public override List<string> GetMyLocalPropertyNamesList()
        {
            List<string> localPropertyNamesList = base.GetMyLocalPropertyNamesList();
            if(localPropertyNamesList == null)
                localPropertyNamesList = new List<string>();
            localPropertyNamesList.Add("IsHCSenderChair");
            return localPropertyNamesList;
        }
        
#endregion Methods

    }
}

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
    /// Tanı-Uzmanlık Dalı Eşleştirme Tanımları
    /// </summary>
    public  partial class DiagnoseSpecialityMatching : TerminologyManagerDef
    {
        public partial class GetDiagnoseSpecialityMatching_Class : TTReportNqlObject 
        {
        }

    /// <summary>
    /// Uzmanlık Dalı
    /// </summary>
        public string SpecialityName
        {
            get
            {
                try
                {
#region SpecialityName_GetScript                    
                    if(Speciality != null)
                return Speciality.Name;
            else
                return String.Empty;
#endregion SpecialityName_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "SpecialityName") + " : " + ex.Message, ex);
                }
            }
        }

        protected override void PreInsert()
        {
#region PreInsert
            base.PreInsert();
            
            IList matchingList = GetBySpeciality(ObjectContext,Speciality.ObjectID.ToString());
            
            if(matchingList.Count > 0)
            {
                if(matchingList.Count == 1)
                {
                    DiagnoseSpecialityMatching dsm = (DiagnoseSpecialityMatching)matchingList[0];
                    if(dsm.ObjectID.ToString() != ObjectID.ToString())
                        throw new Exception(SystemMessage.GetMessage(548));
                }
                else
                {
                    throw new Exception(SystemMessage.GetMessage(548));
                }
            }

#endregion PreInsert
        }

        protected override void PreUpdate()
        {
#region PreUpdate
            base.PreUpdate();
            
            IList matchingList = GetBySpeciality(ObjectContext,Speciality.ObjectID.ToString());
            
            if(matchingList.Count > 0)
            {
                if(matchingList.Count == 1)
                {
                    DiagnoseSpecialityMatching dsm = (DiagnoseSpecialityMatching)matchingList[0];
                    if(dsm.ObjectID.ToString() != ObjectID.ToString())
                        throw new Exception(SystemMessage.GetMessage(548));
                }
                else
                {
                    throw new Exception(SystemMessage.GetMessage(548));
                }
            }
#endregion PreUpdate
        }

#region Methods
        public override SendDataTypesEnum?  GetMySendDataTypesEnum()
        {
            return SendDataTypesEnum.DiagnoseSpecialityMatchingInfo;
        }
        
#endregion Methods

    }
}
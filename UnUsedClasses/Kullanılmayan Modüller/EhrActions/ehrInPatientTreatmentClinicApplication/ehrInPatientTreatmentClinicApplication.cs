
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
    /// Klinik İşlemleri
    /// </summary>
    public  partial class ehrInPatientTreatmentClinicApplication : ehrEpisodeAction, IOAInPatientApplication, IOAInPatientAdmission
    {
#region Methods
        //        protected override List<OldActionPropertyObject> OldActionPropertyList()
//        {
//            List<OldActionPropertyObject> propertyList;
//            if(base.OldActionPropertyList()==null)
//                propertyList = new List<OldActionPropertyObject>();
//            else
//                propertyList = base.OldActionPropertyList();
//            propertyList.Add(new OldActionPropertyObject("Yatış Sebebi",Common.ReturnObjectAsString(ehrBaseInpatientAdmission.ReasonForInpatientAdmission)));
//            propertyList.Add(new OldActionPropertyObject("Klinik Yatış Tarihi",Common.ReturnObjectAsString(ClinicInpatientDate)));
//            propertyList.Add(new OldActionPropertyObject("Klinik Çıkış Tarihi",Common.ReturnObjectAsString(ClinicDischargeDate)));
//            if(this.ProcedureSpeciality!=null)
//                propertyList.Add(new OldActionPropertyObject("Tedavi Gördüğü Uzmanlık Dalı",Common.ReturnObjectAsString(this.ProcedureSpeciality.Name)));
//            return propertyList;
//        }
        
#endregion Methods

    }
}
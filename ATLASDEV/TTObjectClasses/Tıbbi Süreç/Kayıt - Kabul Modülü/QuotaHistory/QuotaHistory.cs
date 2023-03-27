
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
    /// Sivil Kontenjan Bilgileri
    /// </summary>
    public  partial class QuotaHistory : TTObject
    {
        public partial class GetByStartEndDateAndPatient_Class : TTReportNqlObject 
        {
        }

#region Methods
        public static BindingList<TTObjectClasses.QuotaHistory> GetByDateOfQuota(TTObjectContext objectContext,DateTime date,ResSection resSection)
        {
            DateTime startDate = Convert.ToDateTime(date.ToShortDateString() + " " + "00:00:00");
            DateTime endDate = Convert.ToDateTime(date.ToShortDateString() + " " + "23:59:59");
            return QuotaHistory.GetByStartEndDate(objectContext,startDate,endDate,resSection.ObjectID);
        }
        
        public static BindingList<TTObjectClasses.QuotaHistory.GetByStartEndDateAndPatient_Class> GetByPatientDailyQuota(TTObjectContext objectContext,DateTime date,ResSection resSection,Patient patient)
        {
            DateTime startDate = Convert.ToDateTime(date.ToShortDateString() + " " + "00:00:00");
            DateTime endDate = Convert.ToDateTime(date.ToShortDateString() + " " + "23:59:59");
            if(patient!=null)
                return QuotaHistory.GetByStartEndDateAndPatient(objectContext,startDate,endDate,resSection.ObjectID,patient.ObjectID);
            else
                return new BindingList<TTObjectClasses.QuotaHistory.GetByStartEndDateAndPatient_Class>();
        }
        
#endregion Methods

    }
}
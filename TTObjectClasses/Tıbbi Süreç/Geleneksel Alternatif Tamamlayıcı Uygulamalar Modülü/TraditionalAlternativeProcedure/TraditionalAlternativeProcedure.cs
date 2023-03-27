
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
    /// Geleneksel Alternatif Tamamlayıcı Uygulama İşlemleri
    /// </summary>
    public  partial class TraditionalAlternativeProcedure : SubActionProcedure
    {
        public partial class GetTraditionalAlternativeReportNQL_Class : TTReportNqlObject 
        {
        }

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        override protected void RunSetMemberValueScript(string memberName, object newValue)
        {
            switch (memberName)
            {
                case "TRADITIONALALTERNATIVE":
                    {
                        TraditionalAlternative value = (TraditionalAlternative)newValue;
#region TRADITIONALALTERNATIVE_SetParentScript
                        EpisodeAction=(EpisodeAction)value;
#endregion TRADITIONALALTERNATIVE_SetParentScript
                    }
                    break;

                default:
                    base.RunSetMemberValueScript(memberName, newValue);
                    break;

            }
        }

        protected override void PostInsert()
        {
#region PostInsert
            base.PostInsert();
               CancelPatientAccTrxsIfHealthCommittee();
#endregion PostInsert
        }

        protected override void PostUpdate()
        {
#region PostUpdate
            base.PostUpdate();
               CancelPatientAccTrxsIfHealthCommittee();
#endregion PostUpdate
        }

#region Methods
        public TraditionalAlternativeProcedure(TraditionalAlternativeProcedure traditionalAlternativeProcedure):this(traditionalAlternativeProcedure.ObjectContext)
        {
            //YAPILACAKLAR// Appointment Yapıldığında Appointment zamanı atanacak
            Emergency=traditionalAlternativeProcedure.Emergency;
            ProcedureDepartment=traditionalAlternativeProcedure.ProcedureDepartment;
            ProcedureDoctor=traditionalAlternativeProcedure.ProcedureDoctor;
            ProcedureObject=traditionalAlternativeProcedure.ProcedureObject;
            Description=traditionalAlternativeProcedure.Description;
        }
      
        public override string GetDVOAciklama(AccountTransaction accTrx)
        {
            if (TraditionalAlternative != null && TraditionalAlternative.Report != null)
            {
                string rtfReport = Common.GetTextOfRTFString(TraditionalAlternative.Report.ToString());
                if (!string.IsNullOrEmpty(rtfReport))
                {
                    if (ProcedureObject.MedulaProcedureType == MedulaSUTGroupEnum.tetkikveRadyolojiBilgileri)
                    {
                        if (rtfReport.Length > 199) // açıklama max 200 karakter olabiliyor
                            return rtfReport.Substring(0, 199);
                    }
                    else if (ProcedureObject.MedulaProcedureType == MedulaSUTGroupEnum.ameliyatveGirisimBilgileri)
                    {
                        if (rtfReport.Length > 254) // açıklama max 254 karakter olabiliyor
                            return rtfReport.Substring(0, 254);
                    }

                    return rtfReport;
                }
            }

            return null;
        }

        #endregion Methods

    }
}
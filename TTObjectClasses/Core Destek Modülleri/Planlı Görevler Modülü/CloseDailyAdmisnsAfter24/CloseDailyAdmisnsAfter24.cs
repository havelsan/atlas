
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
    /// Kabülü izerinden 24 saat geçmiş günübirlik kabullerin kapatılması
    /// </summary>
    public  partial class CloseDailyAdmisnsAfter24 : BaseScheduledTask
    {
#region Methods
        public override void TaskScript()
        {

            TTObjectContext context = new TTObjectContext(false);
            int counter = 0;
            string log = string.Empty;
        
            BindingList<PatientAdmission> admissions = PatientAdmission.CloseDailyAdmisnsAfter24(context, TTObjectClasses.Common.RecTime().Date.AddDays(-7), TTObjectClasses.Common.RecTime().Date.AddDays(-1));
            foreach (PatientAdmission pa in admissions)
            {
                try
                {
                    if(pa.Episode.CurrentStateDefID == Episode.States.Open)
                    {
                        counter++;
                        pa.Episode.CurrentStateDefID = Episode.States.ClosedToNew;
                    }
                }
                catch(Exception ex)
                {
                    log += ex.Message;
                }
            }
            context.Save();
            if (!String.IsNullOrEmpty(log))
                AddLog(log);
            AddLog(counter.ToString() + " adet günübirlik kabülün episode'u kapatılmıştır.");
            
        }
        
#endregion Methods

    }
}
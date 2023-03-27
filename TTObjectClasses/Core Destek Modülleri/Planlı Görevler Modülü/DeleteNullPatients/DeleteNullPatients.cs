
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
    public  partial class DeleteNullPatients : BaseScheduledTask
    {
#region Methods
        public override  void TaskScript()
        {
            try
            {
                TTObjectContext context = new TTObjectContext(false);
                IList nullPatients = context.QueryObjects(typeof(Patient).Name, "UNIDENTIFIED = 0 AND UNIQUEREFNO IS NULL AND SURNAME IS NULL AND ROWNUM < 501");
                int totalNullPatientCount = 0;
                while(nullPatients.Count > 0)
                {
                    List<Patient> deleteList = new List<Patient>();
                    foreach(Patient p in nullPatients)
                    {
                        IList episodes = Episode.GetEpisodesByPatient(context, p.ObjectID.ToString(), string.Empty);
                        if(episodes.Count > 0)
                            AddLog("HATALI KAYIT BULUNDU.Patient=" + p.ObjectID.ToString());
                        else
                            ((ITTObject)p).Delete();
                    }
                    totalNullPatientCount += nullPatients.Count;
                    context.Save();
                    context.Dispose();
                    context = new TTObjectContext(false);
                    if(Common.RecTime().Hour > 6)
                    {
                        AddLog("Toplam " + totalNullPatientCount.ToString() + " adet boş hasta silindi.");
                        return;
                    }
                    else
                        nullPatients = context.QueryObjects(typeof(Patient).Name, "UNIDENTIFIED = 0 AND UNIQUEREFNO IS NULL AND SURNAME IS NULL AND ROWNUM < 100");
                }
                AddLog("Toplam " + totalNullPatientCount.ToString() + " adet boş hasta silindi.");
            }
            catch(Exception ex)
            {
                AddLog(ex.Message);
            }
        }
        
#endregion Methods

    }
}
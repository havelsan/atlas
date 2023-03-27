
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
    /// Laboratouvar Kan Alma iþleminin tanýmlanan zaman parametresinde baþlayýp baþlamadýðýný kontrol eder. Ýþleme baþlanmadýysa ilgili kullanýcýlara SMS gönderilir. 
    /// </summary>
    public  partial class CheckLaboratoryWorkListSecondTime : BaseScheduledTask
    {
        public override void TaskScript()
        {
            //Sistem parametresinde tanimli olan saatlerde henuz Kan Alma asamasina alinmis hasta yoksa ilgili Lab. sorumlusuna ve ilgili Bashekim Yard. mesaj gonderimi yapar.

            string log = string.Empty;
            try
            {
                LaboratoryProcedure.CheckSampleRequestWorkListStartTime(2);

            }
            catch (Exception ex)
            {
                log += ex.ToString();
            }
            finally
            {
                if (string.IsNullOrEmpty(log))
                    log = TTUtils.CultureService.GetText("M26698", "Planlý görev baþarýyla tamamlanmýþtýr.");
                AddLog(log);
            }

        }
    }
}
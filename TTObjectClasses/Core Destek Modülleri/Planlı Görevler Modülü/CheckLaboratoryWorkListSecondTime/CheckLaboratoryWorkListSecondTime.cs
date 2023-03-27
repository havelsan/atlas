
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
    /// Laboratouvar Kan Alma i�leminin tan�mlanan zaman parametresinde ba�lay�p ba�lamad���n� kontrol eder. ��leme ba�lanmad�ysa ilgili kullan�c�lara SMS g�nderilir. 
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
                    log = TTUtils.CultureService.GetText("M26698", "Planl� g�rev ba�ar�yla tamamlanm��t�r.");
                AddLog(log);
            }

        }
    }
}
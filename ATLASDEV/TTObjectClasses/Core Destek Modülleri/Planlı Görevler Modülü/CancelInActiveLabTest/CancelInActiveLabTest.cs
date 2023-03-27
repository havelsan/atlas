
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
    /// 10 günü geçen ve işlem görmemiş testleri iptal eder
    /// </summary>
    public partial class CancelInActiveLabTest : BaseScheduledTask
    {
        public override void TaskScript()
        {
            string logTxt = "ResendReqandReportTeletip Has Started : " + Common.RecTime();
            try
            {
                List <LaboratoryProcedure.GetLabProcedureByFilter_Class> labTestList = new List<LaboratoryProcedure.GetLabProcedureByFilter_Class> ();
                int dateLimit = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("CANCELINACTIVELABTESTXDAYS", "11"));

                //istek kabul ve numune alma aşamasında kalan 10 günden eski lab istemleri
                string _filter = " 	AND THIS.CURRENTSTATEDEFID IN ('5eaf4c46-c99e-491c-a880-37d07484437e','5b6b040c-cea8-4d4f-96d7-f394c9b28f87') " +
                        " AND THIS.REQUESTDATE < TODATE('" + Convert.ToDateTime(Common.RecTime().Date.AddDays(-dateLimit)).ToString("yyyy-MM-dd HH:mm:ss") + "') ";
                        //" AND THIS.OBJECTID IN('fd387bce-acc9-4913-a939-df62f8cdf6f8','c1be9362-99ac-4728-abac-2af0a334037a') ";

                labTestList = LaboratoryProcedure.GetLabProcedureByFilter(_filter).ToList();

                foreach (LaboratoryProcedure.GetLabProcedureByFilter_Class labTest in labTestList)
                {
                    try
                    {
                        using (TTObjectContext objectContext = new TTObjectContext(false))
                        {
                            LaboratoryProcedure lTest = (LaboratoryProcedure)objectContext.GetObject(labTest.ObjectID.Value, "LABORATORYPROCEDURE");

                            lTest.ReasonOfCancel = " 10 günden daha uzun süredir işlem yapılmadığı için sistem tarafından otomatik olarak iptal edilmiştir. Tarih:" + DateTime.Now.ToString("dd.MM.yyyy");
                            ((ITTObject)lTest).Cancel();
                            objectContext.Save();
                        }
                    }
                    catch (Exception ex)
                    {
                        AddLog(ex.Message);
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
            

        }
    }
}
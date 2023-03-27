
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
    public  partial class SendReportToTeletip : BaseScheduledTask
    {
        public override void TaskScript()
        {
            using (var objectContext = new TTObjectContext(false))
            {
               

                //Raporu yazýlmýþ, durumu Raporu Onaylandý aþamasýnda olan, AccessionNo deðeri dolu olan (US lerin accessionno deðeri null onlar gitmemeli) ve TELETIP a gönderimi yapýlmamýþ kayýtlarý listele.
                //Sistem parametresinde tanýmlý olan deðer göre son X güne kadar olan kayýtlarý listele.

                int dayInterval = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("SENDREPORTEDTESTSTOTELETIPLASTXDAYS", "2"));
                DateTime endDate = Common.RecTime();
                DateTime startDate = Common.RecTime().AddDays(-dayInterval);

                BindingList<RadiologyTest.GetAllRadiologyWithFilter_Class> list = RadiologyTest.GetAllRadiologyWithFilter(objectContext, " WHERE CURRENTSTATEDEFID ='" + RadiologyTest.States.Reported +
                    "' AND ACCESSIONNO IS NOT NULL AND REPORTDATE >= TODATE('" + startDate.Date.ToString("yyyy-MM-dd HH:mm:ss") + "') AND REPORTDATE < TODATE('" + endDate.Date.ToString("yyyy-MM-dd HH:mm:ss") + "')");
                foreach (var item in list)
                {

                    var objectID = item.ObjectID;
                    List<Guid> appIDs = new List<Guid>();
                    Guid objectIDGuid = new Guid(objectID.ToString());
                    appIDs.Add(objectIDGuid);
                    RadiologyTest rTest = (RadiologyTest)objectContext.GetObject(objectIDGuid, "RADIOLOGYTEST");

                    try
                    {
                        if (rTest.ExternalServiceRequests.Count <= 0)
                        {
                            var resultTeletip = HL7EngineManagerFactory.Instance.SendHospitalMessageToEngine(appIDs, "R01", "TELETIP");
                            rTest.IsMessageInTELETIP = resultTeletip.Item1;
                            rTest.ACKMessageTELETIP = resultTeletip.Item2;
                        }
                        else
                        {
                            var resultExternalHIS = HL7EngineManagerFactory.Instance.SendHospitalMessageToEngine(appIDs, "R01", "CUBUK");
                            rTest.IsMessageInExternalHIS = resultExternalHIS.Item1;
                            rTest.ACKMessageExternalHIS = resultExternalHIS.Item2;
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                    finally
                    {
                        objectContext.Save();
                    }
                }
            }

        }
    }
}
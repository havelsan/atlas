
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
    public  partial class DPQueryDaily : BaseScheduledTask
    {
        public override void TaskScript()
        {

            try
            {
                AddLog("DPExecuteDaily has started");
                using (var objectContext = new TTObjectContext(false))
                {
                    string dateNow = Convert.ToDateTime(DateTime.Now.ToShortDateString() + " 00:00:00").ToString("yyyy-MM-dd HH:mm:ss");
                    BindingList<DoctorPerformanceTerm> tempList = objectContext.QueryObjects<DoctorPerformanceTerm>(" CURRENTSTATEDEFID = '" + DoctorPerformanceTerm.States.Open + "' AND STARTDATE <= " +
                        "TODATE('" + dateNow + "') AND ENDDATE > TODATE('" + dateNow + "') ");
                    if (tempList.Count > 0)
                    {
                        Guid tempTermOID = tempList.FirstOrDefault().ObjectID;
                        BindingList<ResUser.GetAllDoctorForDP_Class> doctorList = ResUser.GetAllDoctorForDP("");
                        foreach (var item in doctorList)
                        {
                            try
                            {
                                DPMaster dpm = DPMaster.CreateDPMasterAndDetail(tempTermOID, item.ObjectID.Value, objectContext);
                            }
                            catch
                            { }
                        }
                    }
                    else
                        AddLog("DPExecuteDaily " + dateNow + " tarihinde uygun dönem bulunumadý.");

                }
                AddLog("DPExecuteDaily has finished succesfully");
            }
            catch (Exception ex)
            {
                AddLog("ERROR: " + ex.ToString());
            }
        }
    }
}
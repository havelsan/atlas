using System;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using Infrastructure.Filters;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Core.Security;
using System.Linq;
using System.ComponentModel;


namespace Core.Controllers
{
    public partial class LaboratoryProcedureServiceController
    {
        [HttpGet]
        public LaboratoryPanicNotificationViewModel LoadLaboratoryPanicNotificationViewModel()
        {
            LaboratoryPanicNotificationViewModel model = new LaboratoryPanicNotificationViewModel();
            using (var objectContext = new TTObjectContext(false))
            {

                model.PanicNotificationInfoList = new List<PanicNotificationInfo>();
                
                //Giriş yapan kullanıcı doktor mu?
                int[] doctorType = new int[3] { 0, 2, 17 };

                if (Common.CurrentResource.TakesPerformanceScore == true && doctorType.Contains((int)Common.CurrentResource.UserType))
                {
                    BindingList<LaboratoryResultNotificationInfo.GetPanicNotificationInfo_Class> panicInfoList = LaboratoryResultNotificationInfo.GetPanicNotificationInfo(Common.CurrentResource.ObjectID);
                    foreach(LaboratoryResultNotificationInfo.GetPanicNotificationInfo_Class info in panicInfoList)
                    {
                        PanicNotificationInfo i = new PanicNotificationInfo();
                        i.ObjectID = info.Infoobjectid.ToString();
                        i.PatientNameSurame = info.Patientname + " " + info.Patientsurname;
                        i.ProtocolNo = info.ProtocolNo;
                        i.Description = info.Description;
                        model.PanicNotificationInfoList.Add(i);
                    }

                }
            }
            return model;
        }

        [HttpPost]
        public void UpdateSeenNotification(PanicNotificationInfo data)
        {

            using (var objectContext = new TTObjectContext(false))
            {
                SendToENabiz sendToENabiz = new SendToENabiz();

                LaboratoryResultNotificationInfo info = objectContext.GetObject(new Guid(data.ObjectID), typeof(LaboratoryResultNotificationInfo)) as LaboratoryResultNotificationInfo;
                info.IsSeen = true;
                objectContext.Save();

                objectContext.Dispose();
            }

        }

        [HttpGet]
        public bool CheckPanicNotification()//Parametre true, giriş yapan kullanıcı doktor ve o doktorun panik bildirim listesinde hasta varsa ekran açılacak
        {
            bool result = false;

            string  paramPanicNotification = TTObjectClasses.SystemParameter.GetParameterValue("LABPANICNOTIFICATION", "FALSE");
       
            if (paramPanicNotification == "TRUE")
            {
                int[] doctorType = new int[3] { 0, 2, 17 };

                if (Common.CurrentResource.TakesPerformanceScore == true && doctorType.Contains((int)Common.CurrentResource.UserType)) 
                {
                    BindingList<LaboratoryResultNotificationInfo.GetPanicNotificationInfo_Class> panicInfoList = LaboratoryResultNotificationInfo.GetPanicNotificationInfo(Common.CurrentResource.ObjectID);
                    if (panicInfoList.Count > 0)
                        result = true;
                }
            }

            return result;
        }

    }
}
namespace Core.Models
{
    public class LaboratoryPanicNotificationViewModel
    {
        public List<PanicNotificationInfo> PanicNotificationInfoList { get; set; }
    }
    public class PanicNotificationInfo
    {
        public string ObjectID { get; set; }
        public string PatientNameSurame { get; set; }
        public string ProtocolNo { get; set; }
        public string Description { get; set; }
    }
}
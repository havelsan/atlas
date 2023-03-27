
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
    /// İş Sağlığı ve Güvenliği Muayenelerinin hatırlatma smslerinin gönderileceği planlı görev
    /// </summary>
    public partial class SendSMSWorkHealthSecWarn : BaseScheduledTask
    {
        public override void TaskScript()
        {

            AddLog("SendSMSWorkHealthSecWarn has started");
            BindingList<ResUser> userList = ResUser.GetAllUser(ObjectContext, "WHERE ISACTIVE=1");
            UserMessage userMessage = new UserMessage();
            DateTime tomorrowDate = Common.RecTime().Date.AddDays(1);
            foreach (var user in userList)
            {
                try
                {
                    bool hasExamination = false;
                    if (user.FirstWorkHealthExamDate != null && ((DateTime)user.FirstWorkHealthExamDate).Date == tomorrowDate)
                    {
                        hasExamination = true;
                    }
                    else if (user.SecondWorkHealthExamDate != null && ((DateTime)user.SecondWorkHealthExamDate).Date == tomorrowDate)
                    {
                        hasExamination = true;
                    }
                    else if (user.ThirdWorkHealthExamDate != null && ((DateTime)user.ThirdWorkHealthExamDate).Date == tomorrowDate)
                    {
                        hasExamination = true;
                    }
                    else if (user.FourthWorkHealthExamDate != null && ((DateTime)user.FourthWorkHealthExamDate).Date == tomorrowDate)
                    {
                        hasExamination = true;
                    }
                    if (hasExamination == true)
                    {
                        string messageText = "Sayın " + user.Name + ", " + tomorrowDate.ToString("dd.MM.yyyy") + " tarihinde iş sağlığı ve güvenliği kapsamında sağlık tarama randevunuz bulunmaktadır. İş Yeri Hekimliği Birimine başvurmanız önemle rica olunur.";
                        List<ResUser> users = new List<ResUser> { user };
                        userMessage.SendSMSPerson(users, messageText, SMSTypeEnum.WorkHealthSecWarnSMS);
                    }
                }
                catch (Exception ex)
                {
                    AddLog("ERROR: " + ex.ToString());
                }
            }
            AddLog("SendSMSWorkHealthSecWarn has finished succesfully");
        }
    }
}
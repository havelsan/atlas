using AtlasSmsManager;
using Core.Models;
using DevExpress.Utils.Extensions;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraRichEdit.Model;
using Infrastructure.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using TTDefinitionManagement;
using TTInstanceManagement;
using TTObjectClasses;
using TTReportClasses;
using TTStorageManager.Security;
using TTUtils;
using static TTObjectClasses.UTSServis;

namespace Core.Controllers.Logistic
{
    [Route("api/[controller]/[action]/{id?}")]
    [HvlResult]
    public class KioskGeneralController : Controller
    {
        [HttpPost]
        public Patient getPatientFromAtlas([FromBody]TCUniqueInput input)
        {
            using (var context = new TTObjectContext(false))
            {
                Patient patient = context.QueryObjects<Patient>(" UNIQUEREFNO ='" + input.TCUniqueNo.ToString() + "'").FirstOrDefault();
                return patient;
            }
        }

        [HttpGet]
        public string getNotificationFromAtlas()
        {
            List<NotificationList> notifications = KioskNotificationDef.GetKioskNotificationDefList(string.Empty).Select(p => new NotificationList
            {
                notification = p.Notification
            }).ToList();
            return string.Join(" *** ", notifications.Select(x => x.notification).ToList());
        }

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        [HttpPost]
        public string sendToSms([FromBody]SmsInput input)
        {
            string smsCode = RandomString(6);

            if (!input.mobilePhoneNumber.StartsWith("0"))
            {
                string newNumber = input.mobilePhoneNumber.Substring(1, input.mobilePhoneNumber.Length - 1);
                input.mobilePhoneNumber = newNumber;
            }

            var smsInstance = SmsManager.Instance;
            AtlasSMS sms = new AtlasSMS();
            sms.Number = input.mobilePhoneNumber;
            string message = smsCode + " şifresi ile onaylayabilirsiniz.";
            sms.Text = message;

            var result = smsInstance.SendSms(sms);

            if (result != null && result)
            {
                return smsCode;
            }
            else
            {
                return "-1";
            }


        }

        public class SmsInput
        {
            public string mobilePhoneNumber { get; set; }
        }

        public class TCUniqueInput
        {
            public long TCUniqueNo { get; set; }
        }

        public class NotificationList
        {
            public string notification { get; set; }
        }

    }
}

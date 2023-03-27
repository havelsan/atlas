
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
using System.Net.Mail;
using System.Net;

namespace TTObjectClasses
{
    /// <summary>
    /// Miadı Yaklaşan Malzeme / İlaçlar
    /// </summary>
    public partial class ExpirationDateApproachingTask : BaseScheduledTask
    {
        #region Methods
        public override void TaskScript()
        {
            Guid storeID = Guid.Empty;
            int expirationMonth = 6;

            if (Store != null)
                storeID = Store.ObjectID;
            if (ExpirationMonth.HasValue)
                expirationMonth = ExpirationMonth.Value;


            BindingList<StockTransaction.ExpirationDateApproachingTaskQuery_Class> expirationDateApproachingList = StockTransaction.ExpirationDateApproachingTaskQuery(DateTime.Now.AddMonths(expirationMonth), storeID);
            if (expirationDateApproachingList.Count > 0)
            {
                string msg = "Miadı yaklaşan ilaçlar bulundu.\r\nDetayları: \r\n";
                foreach (StockTransaction.ExpirationDateApproachingTaskQuery_Class item in expirationDateApproachingList)
                {
                    msg = msg + item.Storename + " deposunda " + item.Barcode + " - " + item.Materialname + "\r\n";
                }


                string smptdAddres = SystemParameter.GetParameterValue("MAILSMTPADDRES", "smtp.gmail.com");
                string mailUserName = SystemParameter.GetParameterValue("MAILUSERNAME", "XXXXXX");
                string mailPassword = SystemParameter.GetParameterValue("MAILPASSWORD", "XXXXXX");
                foreach (ExpirationDateApproachingTaskUser expirationDateApproachingTaskUser in ExpirationDateApproachingTaskUsers)
                {
                    if (string.IsNullOrEmpty(expirationDateApproachingTaskUser.User.EMail) == false)
                    {
                        MailMessage mail = new MailMessage();
                        mail.From = new MailAddress(mailUserName, "ATLASCare");
                        mail.To.Add(expirationDateApproachingTaskUser.User.EMail);
                        mail.Subject = "Miadı yaklaşan ilaçlar";
                        mail.Body = msg;

                        SmtpClient SmtpServer = new SmtpClient();
                        SmtpServer.Port = 587;
                        SmtpServer.Host = smptdAddres;
                        NetworkCredential credential = new NetworkCredential(mailUserName, mailPassword);
                        SmtpServer.Credentials = credential;
                        SmtpServer.EnableSsl = true;

                        SmtpServer.Send(mail);
                    }

                }
                AddLog(msg);
            }
        }
        public override void AddLog(string log)
        {
            base.AddLog(log);
        }

        #endregion Methods

    }
}
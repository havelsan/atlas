
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
    /// Do�um g�n� mesaj�
    /// </summary>
    public partial class SendBirthDayMessage : BaseScheduledTask
    {

        public override void TaskScript()
        {
            try
            {
                AddLog("SendSmsBirthDay has started");
                TTObjectContext objectcontext = new TTObjectContext(false);
                BindingList<ResUser> users = ResUser.GetAllUser(ObjectContext, "WHERE ISACTIVE=1");
                UserMessage um = new UserMessage();
                DateTime today = Common.RecTime();
                var filteredUserList = users.Where(t => t.Person.BirthDate != null && !String.IsNullOrEmpty(t.PhoneNumber)).ToList();

                foreach (var item in filteredUserList)
                {
                    try
                    {
                        List<ResUser> user = new List<ResUser>();
                        if (item.Person?.BirthDate.Value.Date.Day == today.Date.Day && item.Person?.BirthDate.Value.Date.Month == today.Date.Month)
                        {
                            string smsText = "Say�n " + item.Name + ", " + TTObjectClasses.SystemParameter.GetParameterValue("SENDSMSBIRTHDAY", "yeni ya��n�z�n sa�l�k, mutluluk ve ba�ar�lar�n�z�n devam�n� getirmesi dileklerimizle.");
                            user.Add(item);
                            um.SendSMSPerson(user, smsText, SMSTypeEnum.BirthDaySMS);
                        }
                        if (item.DateOfJoin.Value.Date == today.Date)
                            um.SendSMSPerson(user, TTObjectClasses.SystemParameter.GetParameterValue("SENDSMSJOIN", "Aram�za Ho� Geldiniz."), SMSTypeEnum.NewPersonnelJoinSMS);
                        if (item.DateOfLeave.Value.Date == today.Date)
                            um.SendSMSPerson(user, TTObjectClasses.SystemParameter.GetParameterValue("SENDSMSLEAVE", "Bundan Sonraki Hayat�n�zda ba�ar�lar diliyoruz."), SMSTypeEnum.LeaveJobPersonnelSMS);

                        objectcontext.Save();
                    }
                    catch (Exception e)
                    {
                        continue;
                    }
                }
                objectcontext.Dispose();
                AddLog("SendSmsBirthDay has finished succesfully");
            }
            catch (Exception ex)
            {
                AddLog("ERROR: " + ex.ToString());
            }


        }
    }
}
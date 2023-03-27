
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
    /// 6fedbc09-c34f-4189-88b7-6c6f4798fcfc
    /// </summary>
    public partial class SKRSOlayAfetBilgisi : BaseSKRSDefinition
    {
        public partial class GetSKRSOlayAfetBilgisi_Class : TTReportNqlObject
        {
        }

        protected override void PostInsert()
        {
            #region PostInsert
            base.PostInsert();
            if (SystemParameter.GetParameterValue("OLAYAFETSMSGONDERIM", "FALSE").ToUpper() == "TRUE")
            {
                SendSMSToUsers(this);
            }
            #endregion PostInsert
        }

        public void SendSMSToUsers(SKRSOlayAfetBilgisi olayAfetBilgisi)
        {

            string filterExpression = " AND this.SKRSILKodlari.KODU = " + olayAfetBilgisi.OLAYILKODU;
            var OlayAfetSMSGonderimList = OlayAfetSMSGonderim.GetOlayAfetSMSGonderim(filterExpression);

            string messageText = "\'" + this.TARIHSAAT + "\' Tarihinde \"" + this.LOKASYON + "\" Lokasyon Bilgisine Sahip \"" + this.OLAYISMI + "\" İsmi ile Olay Afet Bildirimi Yapılmıştır. Bu mesaj ATLAS HBYS tarafından bilgi amaçlı gönderilmiştir.";
            string filter = "RESUSER IS NOT NULL";
            filter = Common.CreateFilterExpressionOfGuidList(filter, "OBJECTID", OlayAfetSMSGonderimList.Where(x => x.ObjectID.HasValue).Select(x => x.ObjectID.Value).ToList());
            List<ResUser> smsUserListForOlayAfet = ObjectContext.QueryObjects<OlayAfetSMSGonderim>(filter).Where(x => x.ResUser != null && !string.IsNullOrEmpty(x.ResUser.PhoneNumber)).Select(x => x.ResUser).ToList();

            //foreach (var olayAfetGonderim in OlayAfetSMSGonderimList)
            //{
            //    OlayAfetSMSGonderim olayAfetSMSGonderim = this.ObjectContext.GetObject<OlayAfetSMSGonderim>((Guid)olayAfetGonderim.ObjectID);
            UserMessage userMessage = new UserMessage();
            if (!string.IsNullOrEmpty(messageText))
            {
                try
                {
                    userMessage.SendSMSPerson(smsUserListForOlayAfet, messageText, SMSTypeEnum.OlayAfetBilgisiSMS);
                }
                catch (Exception)
                {
                    //continue;
                }
            }
            //}
        }

    }
}
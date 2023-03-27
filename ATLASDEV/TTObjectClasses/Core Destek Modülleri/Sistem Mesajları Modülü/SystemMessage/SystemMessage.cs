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
    /// Sistem Mesajları Tanımı
    /// </summary>
    public partial class SystemMessage : TerminologyManagerDef
    {
        public partial class GetSystemMessagesDefinition_Class : TTReportNqlObject
        {
        }

        protected override void PreInsert()
        {
#region PreInsert
            base.PreInsert();
            FindSameMessage(Message, TTUtils.CultureService.GetText("M25582", "eklen"));
        //if (this.EnglishCultures.Count >1 || this.TurkishCultures.Count>1)
        //{
        //    throw new TTUtils.TTException("Her Culture için 1 Tane Mesaj girebilirsiniz !!!!");
        //}
#endregion PreInsert
        }

        protected override void PreUpdate()
        {
#region PreUpdate
            base.PreUpdate();
            FindSameMessage(Message, TTUtils.CultureService.GetText("M25398", "değiştiril"));
        //if (this.EnglishCultures.Count >1 || this.TurkishCultures.Count>1)
        //{
        //    throw new TTUtils.TTException("Her Culture için 1 Tane Mesaj girebilirsiniz !!!!");
        //}
#endregion PreUpdate
        }

#region Methods
        protected override void OnConstruct()
        {
            base.OnConstruct();
            if (((ITTObject)this).IsNew)
                MessageCode.GetNextValue();
        }

        private static Dictionary<int, SystemMessage> _allMessages;
        static SystemMessage()
        {
            TTObjectContext context = new TTObjectContext(true);
            _allMessages = new Dictionary<int, SystemMessage>();
            foreach (SystemMessage message in context.QueryObjects<SystemMessage>())
            {
                _allMessages.Add(Convert.ToInt32(message.MessageCode.Value), message);
            }
        }

        public static string GetMessage(int code)
        {
            return GetMessageInternal(code);
        }

        public static string GetMessageV2(int code, string sDefaultValue)
        {
            string sMessage = GetMessageInternal(code);
            if (string.IsNullOrEmpty(sMessage))
                return sDefaultValue;
            return sMessage;
        }

        [TTStorageManager.Attributes.TTRequiredRoles(TTRoleNames.Tasinir_Mal_Islemi_Giris_Kayit)]
        public static string GetMessageV3(int code, string[] parameters)
        {
            string sValue = GetMessage(code);
            sValue = string.Format(sValue, parameters);
            return sValue;
        }

        public static string GetMessageV4(int code, string sDefaultValue, string[] parameters)
        {
            string sValue = GetMessage(code);
            if (string.IsNullOrEmpty(sValue))
            {
                sDefaultValue = string.Format(sDefaultValue, parameters);
                return sDefaultValue;
            }

            sValue = string.Format(sValue, parameters);
            return sValue;
        }

        private static string GetMessageInternal(int code)
        {
            string sMessage = "";
            TTObjectContext context = new TTObjectContext(false);
            try
            {
                if (_allMessages.ContainsKey(code))
                {
                    string messageCode = "0000" + code.ToString();
                    sMessage = "SM" + messageCode.Substring(messageCode.Length - 4) + " - " + _allMessages[code].Message;
                //sMessage = _allMessages[code].Message;
                }
            //        if ( _allMessages[code].BaseCultures.Count>0)
            //        {
            //            foreach (BaseCulture  culture in _allMessages[code].BaseCultures)
            //            {
            //                if(culture.LCID == TTUtils.CultureService.Culture.LCID)
            //                {
            //                    sMessage = culture.Message;
            //                }
            //            }
            //        }
            }
            catch
            {
                throw;
            }
            finally
            {
                context.Dispose();
            }

            return sMessage;
        }

        public static string GetMessageType(int code)
        {
            TTObjectContext context = new TTObjectContext(false);
            string sMessageType = _allMessages[code].MessageType.Value.ToString();
            return sMessageType;
        }

        public override SendDataTypesEnum? GetMySendDataTypesEnum()
        {
            return SendDataTypesEnum.SystemMessageInfo;
        }

        private static void FindSameMessage(string message, string changeType)
        {
            TTObjectContext context = new TTObjectContext(true);
            string message1 = message.Replace("'", "\"");
            BindingList<SystemMessage.GetSystemMessagesDefinition_Class> messageList = SystemMessage.GetSystemMessagesDefinition("WHERE MESSAGE LIKE '%" + message1 + "%' ORDER BY MESSAGECODE");
            if (messageList.Count > 0)
            {
                int mlCount = messageList.Count;
                string showMessage = "";
                for (int i = 0; i < mlCount; i++)
                {
                    showMessage += messageList[i].MessageCode.Value.ToString();
                    if (i != (mlCount - 1))
                    {
                        showMessage += ", ";
                    }
                }
            //                if (TTVisual.S how Box.S how(S howBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", "Sistem Mesajı", "", "Yazdığınız sistem mesajı " + showMessage + " numaralı mesaj/mesajlar ile benzerlik göstermektedir.\nDevam etmek istediğinize emin misiniz?") == "H")
            //                    throw new Exception(SystemMessage.GetMessage(572, changeType.ToString()));
            }
        }
#endregion Methods
    }
}
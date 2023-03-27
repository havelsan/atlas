
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
    /// Bekleyen Tıbbi Cihaz İşleri
    /// </summary>
    public  partial class WaitingCMRActionTask : BaseScheduledTask
    {
#region Methods
        public override void TaskScript()
        {
            TTObjectContext objectContextReadOnly = new TTObjectContext(true);
            string message = string.Empty;
            Dictionary<ResUser, string> responsibleUserMessage = new Dictionary<ResUser, string>();

            IList waitingCMRActionList = CMRAction.ActiveCMRActionNQL(objectContextReadOnly);
            if (waitingCMRActionList.Count > 0)
            {
                foreach (CMRAction waitingAction in waitingCMRActionList)
                {
                    if (waitingAction.WorkListDate != null && waitingAction.WorkListDate < Common.RecTime())
                    {
                        int day = Common.RecTime().Subtract((DateTime)waitingAction.WorkListDate).Days;
                        if (day > ExpirationDay)
                        {
                            message = AddMessage(waitingAction, message);
                            if (waitingAction.ResponsibleUser != null)
                            {
                                if (responsibleUserMessage.ContainsKey(waitingAction.ResponsibleUser) == false)
                                    responsibleUserMessage[waitingAction.ResponsibleUser] = responsibleUserMessage[waitingAction.ResponsibleUser] + message;
                                else
                                    responsibleUserMessage.Add(waitingAction.ResponsibleUser, message);
                            }
                        }
                    }
                }

                List<ResUser> toUsers = new List<ResUser>();
                foreach (WaitingCMRActionTaskUser waitingCMRActionTaskUser in WaitingCMRActionTaskUsers.Select(string.Empty))
                    toUsers.Add(waitingCMRActionTaskUser.User);
                
                SendMessageAndAddLog(message, toUsers);

                foreach (KeyValuePair<ResUser, string> mes in responsibleUserMessage)
                {
                    List<ResUser> responsibleUsers = new List<ResUser>();
                    responsibleUsers.Add(mes.Key);
                    SendMessageAndAddLog(mes.Value, responsibleUsers);
                }

                objectContextReadOnly.Dispose();
            }
        }
        
        public string AddMessage(CMRAction waitingAction, string message)
        {
            string newMessage = message;
            if (waitingAction is Repair)
            {
                if (waitingAction.FixedAssetMaterialDefinition != null)
                {
                    string resourceFixedAssetMaterial = string.Empty;
                    if (waitingAction.SenderSection != null)
                        resourceFixedAssetMaterial = waitingAction.SenderSection.Name;
                    
                    string fixedAssetMaterialName = string.Empty;
                    if (waitingAction.FixedAssetMaterialDefinition.Description != null)
                        fixedAssetMaterialName = waitingAction.FixedAssetMaterialDefinition.Description;
                    else
                        fixedAssetMaterialName = waitingAction.FixedAssetMaterialDefinition.FixedAssetDefinition.Name;
                    
                    string fixedAssetMaterialSeriNo = string.Empty;
                    if (waitingAction.FixedAssetMaterialDefinition.SerialNumber != null)
                        fixedAssetMaterialSeriNo = waitingAction.FixedAssetMaterialDefinition.SerialNumber.ToString();
                    else
                        fixedAssetMaterialSeriNo = "-";
                    string requestID = ((Repair)waitingAction).RequestNo.ToString();
                    string responsableUser = string.Empty;
                    if (waitingAction.ResponsibleUser != null)
                        responsableUser = waitingAction.ResponsibleUser.Person.FullName;
                    newMessage = newMessage + "\r\n" + resourceFixedAssetMaterial + " bölümünün/servisinin " + fixedAssetMaterialSeriNo + " seri numaralı " + fixedAssetMaterialName + " isimli cihazının\r\n" + requestID + " işlem numaralı onarım işlemi " + ExpirationDay.ToString() + " günden fazla zamandır devam etmektedir. Personel :" + responsableUser;
                }
            }
            if (waitingAction is Maintenance)
            {
                if (waitingAction.FixedAssetMaterialDefinition != null)
                {
                    string resourceFixedAssetMaterial = string.Empty;
                    if (waitingAction.SenderSection != null)
                        resourceFixedAssetMaterial = waitingAction.SenderSection.Name;
                    string fixedAssetMaterialName = string.Empty;
                    if (waitingAction.FixedAssetMaterialDefinition.Description != null)
                        fixedAssetMaterialName = waitingAction.FixedAssetMaterialDefinition.Description;
                    else
                        fixedAssetMaterialName = waitingAction.FixedAssetMaterialDefinition.FixedAssetDefinition.Name;

                    string fixedAssetMaterialSeriNo = string.Empty;
                    if (waitingAction.FixedAssetMaterialDefinition.SerialNumber != null)
                        fixedAssetMaterialSeriNo = waitingAction.FixedAssetMaterialDefinition.SerialNumber.ToString();
                    else
                        fixedAssetMaterialSeriNo = "-";
                    string requestID = ((Maintenance)waitingAction).RequestNo.ToString();
                    string responsableUser = string.Empty;
                    if (waitingAction.ResponsibleUser != null)
                        responsableUser = waitingAction.ResponsibleUser.Person.FullName;
                    newMessage = newMessage + "\r\n" + resourceFixedAssetMaterial + " bölümünün/servisinin " + fixedAssetMaterialSeriNo + " seri numaralı " + fixedAssetMaterialName + " isimli cihazının\r\n" + requestID + " işlem numaralı bakım işlemi " + ExpirationDay.ToString() + " günden fazla zamandır devam etmektedir. Personel :" + responsableUser;
                }
            }
            if (waitingAction is Calibration)
            {
                if (waitingAction.FixedAssetMaterialDefinition != null)
                {
                    string resourceFixedAssetMaterial = string.Empty;
                    if (waitingAction.SenderSection != null)
                        resourceFixedAssetMaterial = waitingAction.SenderSection.Name;
                    string fixedAssetMaterialName = string.Empty;
                    if (waitingAction.FixedAssetMaterialDefinition.Description != null)
                        fixedAssetMaterialName = waitingAction.FixedAssetMaterialDefinition.Description;
                    else
                        fixedAssetMaterialName = waitingAction.FixedAssetMaterialDefinition.FixedAssetDefinition.Name;

                    string fixedAssetMaterialSeriNo = string.Empty;
                    if (waitingAction.FixedAssetMaterialDefinition.SerialNumber != null)
                        fixedAssetMaterialSeriNo = waitingAction.FixedAssetMaterialDefinition.SerialNumber.ToString();
                    else
                        fixedAssetMaterialSeriNo = "-";
                    string requestID = ((Calibration)waitingAction).RequestNo.ToString();
                    string responsableUser = string.Empty;
                    if (waitingAction.ResponsibleUser != null)
                        responsableUser = waitingAction.ResponsibleUser.Person.FullName;
                    newMessage = newMessage + "\r\n" + resourceFixedAssetMaterial + " bölümünün/servisinin " + fixedAssetMaterialSeriNo + " seri numaralı " + fixedAssetMaterialName + " isimli cihazının\r\n" + requestID + " işlem numaralı kalibrasyon işlemi " + ExpirationDay.ToString() + " günden fazla zamandır devam etmektedir. Personel :" + responsableUser;
                }
            }
            if (waitingAction is MaintenanceOrder)
            {
                if (waitingAction.FixedAssetMaterialDefinition != null)
                {
                    string resourceFixedAssetMaterial = string.Empty;
                    if (waitingAction.SenderSection != null)
                        resourceFixedAssetMaterial = waitingAction.SenderSection.Name;
                    string fixedAssetMaterialName = string.Empty;
                    if (waitingAction.FixedAssetMaterialDefinition.Description != null)
                        fixedAssetMaterialName = waitingAction.FixedAssetMaterialDefinition.Description;
                    else
                        fixedAssetMaterialName = waitingAction.FixedAssetMaterialDefinition.FixedAssetDefinition.Name;

                    string fixedAssetMaterialSeriNo = string.Empty;
                    if (waitingAction.FixedAssetMaterialDefinition.SerialNumber != null)
                        fixedAssetMaterialSeriNo = waitingAction.FixedAssetMaterialDefinition.SerialNumber.ToString();
                    else
                        fixedAssetMaterialSeriNo = "-";
                    string requestID = ((MaintenanceOrder)waitingAction).RequestNo.ToString();
                    string responsableUser = string.Empty;
                    if (waitingAction.ResponsibleUser != null)
                        responsableUser = waitingAction.ResponsibleUser.Person.FullName;
                    newMessage = newMessage + "\r\n" + resourceFixedAssetMaterial + " bölümünün/servisinin " + fixedAssetMaterialSeriNo + " seri numaralı " + fixedAssetMaterialName + " isimli cihazının\r\n" + requestID + " işlem numaralı sipariş işlemi " + ExpirationDay.ToString() + " günden fazla zamandır devam etmektedir. Personel :" + responsableUser;
                }
            }
            if (waitingAction is MaterialRepair)
            {
                if (((MaterialRepair)waitingAction).FixedAssetDefinition != null)
                {
                    string resourceFixedAssetMaterial = string.Empty;
                    if (waitingAction.SenderSection != null)
                        resourceFixedAssetMaterial = waitingAction.SenderSection.Name;
                    string fixedAssetMaterialName = ((MaterialRepair)waitingAction).FixedAssetDefinition.Name.ToString();
                    string requestID = ((MaterialRepair)waitingAction).RequestNo.ToString();
                    string responsableUser = string.Empty;
                    if (waitingAction.ResponsibleUser != null)
                        responsableUser = waitingAction.ResponsibleUser.Person.FullName;
                    newMessage = newMessage + "\r\n" + resourceFixedAssetMaterial + " bölümünün/servisinin " + fixedAssetMaterialName + " isimli stok numaralı malzemesinin\r\n" + requestID + " işlem numaralı onarım işlemi " + ExpirationDay.ToString() + " günden fazla zamandır devam etmektedir. Personel :" + responsableUser;
                }
            }
            if (waitingAction is MaterialMaintenance)
            {
                if (((MaterialMaintenance)waitingAction).FixedAssetDefinition != null)
                {
                    string resourceFixedAssetMaterial = string.Empty;
                    if (waitingAction.SenderSection != null)
                        resourceFixedAssetMaterial = waitingAction.SenderSection.Name;
                    string fixedAssetMaterialName = ((MaterialMaintenance)waitingAction).FixedAssetDefinition.Name;
                    string requestID = ((MaterialMaintenance)waitingAction).RequestNo.ToString();
                    string responsableUser = string.Empty;
                    if (waitingAction.ResponsibleUser != null)
                        responsableUser = waitingAction.ResponsibleUser.Person.FullName;
                    newMessage = newMessage + "\r\n" + resourceFixedAssetMaterial + " bölümünün/servisinin " + fixedAssetMaterialName + " isimli stok numaralı malzemesinin\r\n" + requestID + " işlem numaralı bakım işlemi " + ExpirationDay.ToString() + " günden fazla zamandır devam etmektedir. Personel :" + responsableUser;
                }
            }
            return newMessage;
        }

        public void SendMessageAndAddLog(string message, List<ResUser> toUsers)
        {
            TTObjectContext objectContext = new TTObjectContext(false);
            UserMessage.SendMessageInternalWithResUser(objectContext, toUsers, TTUtils.CultureService.GetText("M25269", "Bekleyen Tıbbi Cihaz İşleri"), Globals.StringToRTF(message));
            objectContext.Save();
            objectContext.Dispose();
            AddLog(message);

        }

        public override void AddLog(string log)
        {
            base.AddLog(log);
        }
        
#endregion Methods

    }
}
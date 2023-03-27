
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

using SmartCardWrapper;

using TTStorageManager;
using System.Runtime.Versioning;
using System.Windows.Forms;
using TTVisual;
namespace TTFormClasses
{
    public partial class DispatchToOtherHospResultForm : EpisodeActionForm
    {
        override protected void BindControlEvents()
        {
            ShowMessageStatus.Click += new TTControlEventDelegate(ShowMessageStatus_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            ShowMessageStatus.Click -= new TTControlEventDelegate(ShowMessageStatus_Click);
            base.UnBindControlEvents();
        }

        private void ShowMessageStatus_Click()
        {
#region DispatchToOtherHospResultForm_ShowMessageStatus_Click
   try
            {
                string s = null;
                if (String.IsNullOrEmpty(this._DispatchToOtherHospital.MessageID))
                {
                    InfoBox.Show("Mesaj numarası bulunamadı", MessageIconEnum.InformationMessage);
                    return;
                }
                TTMessage message = TTMessageFactory.GetMessage(new Guid(this._DispatchToOtherHospital.MessageID));
                if (message == null)
                {
                    InfoBox.Show("İlgili mesaj numarasına ait mesaj bulunamadı.",MessageIconEnum.InformationMessage);
                    return;
                }
                if (message.MessageStatus == TTMessageStatusEnum.Completed)
                {
                    if (message.ReturnValue != null)
                    {
                        Common.RemotingResultClass remotingResultClass = (Common.RemotingResultClass)message.ReturnValue;
                        s = remotingResultClass.resultMessage;
                        if (remotingResultClass.resultCode != "0")
                        {
                            string result = ShowBox.Show(ShowBoxTypeEnum.Message,"&Evet,&Hayır","E,H","Uyarı","XXXXXXler Arası Sevk","Diğer XXXXXXden gelen hata mesajı : \r\n" + s + "\r\n Tekrar gönderim yapılmasını ister misiniz?");
                            if(result == "E")
                            {
                                this._retrySendingDispatchToOtherHosp = true;
                                InfoBox.Show("Mesajın tekrar gönderilebilmesi için Kaydet butonuna basınız.");
                                return;
                            }
                            else
                            {
                                this._retrySendingDispatchToOtherHosp = false;
                                return;
                            }                            
                        }                        
                    }
                    InfoBox.Show("'" + message.MessageID + "' nolu mesaj başarılı olarak gönderildi." + s,MessageIconEnum.InformationMessage);
                }
                else if (message.MessageStatus == TTMessageStatusEnum.MessageNotFound)
                {
                    InfoBox.Show("'" + message.MessageID + "' nolu mesaj bulunamadı.",MessageIconEnum.InformationMessage);
                }
                else if (message.MessageStatus == TTMessageStatusEnum.Waiting)
                {
                    InfoBox.Show("'" + message.MessageID + "' nolu mesaj beklemede.",MessageIconEnum.InformationMessage);
                }
                else
                {
                    //if (message.MessageLog != null)
                    //    s = "Hata Bilgileri : " + message.MessageLog.LogText;
                    InfoBox.Show("Gönderim sırasında '" + message.MessageID + "' nolu mesaj ile ilgili hata alındı.", MessageIconEnum.InformationMessage);
                }
                
            }
            catch(Exception ex)
            {
                InfoBox.Show(ex);
            }
#endregion DispatchToOtherHospResultForm_ShowMessageStatus_Click
        }

        protected override void PreScript()
        {
#region DispatchToOtherHospResultForm_PreScript
    base.PreScript();
            
            
            if(String.IsNullOrEmpty(this._DispatchToOtherHospital.MessageID))
                this.ShowMessageStatus.Visible = false;
            if (this.RequestedReferableHospital.SelectedObject != null && this.RequestedReferableResource.SelectedObject != null)
            {
                this.DispatchedDoctorName.ReadOnly = true;
                if(String.IsNullOrEmpty(this._DispatchToOtherHospital.SourceObjectID))
                {
                    if(this._DispatchToOtherHospital.CurrentStateDefID == DispatchToOtherHospital.States.Dispatched)
                    {
                        this.DropStateButton (DispatchToOtherHospital.States.Completed);
                        //this.cmdOK.Visible=false;
                    }
                    
                    this.RestingStartDate.ReadOnly = true;
                    this.RestingEndDate.ReadOnly = true;
                    this.DispatchedDoctor.Visible = false;
                    this.DispatchedDoctorName.Visible = true;
                    this.CompanionStatus.ReadOnly = true;
                }
                else
                {
                    if (this.DispatchedDoctor.SelectedObject == null)
                    {
                        ResUser currentUser = (ResUser)TTStorageManager.Security.TTUser.CurrentUser.UserObject;
                        if (currentUser.UserType == UserTypeEnum.Doctor)
                        {
                            this.DispatchedDoctor.SelectedObject = (ResUser)TTStorageManager.Security.TTUser.CurrentUser.UserObject;
                            this._DispatchToOtherHospital.DispatchedDoctorName = this._DispatchToOtherHospital.DispatchedDoctor.Name;
                        }
                    }
                    this.DispatchedDoctor.Visible=true;
                    this.DispatchedDoctorName.Visible=false;
                }
            }
            else
            {
                this.DispatchedDoctor.Visible = false;
                this.DispatchedDoctorName.Visible = true;
                this.DispatchedDoctorName.ReadOnly = false;
            }
            
            this._retrySendingDispatchToOtherHosp = false;
#endregion DispatchToOtherHospResultForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region DispatchToOtherHospResultForm_PostScript
    base.PostScript(transDef);
            if (transDef != null)
            {
                if (transDef.ToStateDefID == DispatchToOtherHospital.States.Completed)
                {
                    this.StartPatientAdmissionCorrection();
                    ResUser currentUser = (ResUser)TTStorageManager.Security.TTUser.CurrentUser.UserObject;
                    if (currentUser.UserType == UserTypeEnum.Doctor)
                        _DispatchToOtherHospital.DispatchedDoctor = (ResUser)TTStorageManager.Security.TTUser.CurrentUser.UserObject;
                }
            }
            
            /*
            if (this._retrySendingDispatchToOtherHosp == true)
            {
                if (String.IsNullOrEmpty(this._DispatchToOtherHospital.SourceObjectID))
                    this._DispatchToOtherHospital.RunSendDispatchToOtherHospital();
                else
                    this._DispatchToOtherHospital.RunReturnDispatchToOtherHospital();
            }
            */
#endregion DispatchToOtherHospResultForm_PostScript

            }
            
#region DispatchToOtherHospResultForm_Methods
        private bool _retrySendingDispatchToOtherHosp = false;
        /*
        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
            base.AfterContextSavedScript(transDef);
            if (!String.IsNullOrEmpty(this._DispatchToOtherHospital.SourceObjectID))
            {
                bool callRemoteMethod = false;
                if(this._DispatchToOtherHospital.RequestedReferableHospital != null && this._DispatchToOtherHospital.RequestedReferableResource != null)
                {
                    if(transDef != null)
                    {
                        if (transDef.ToStateDefID == DispatchToOtherHospital.States.Completed)
                            callRemoteMethod = true;
                    }
                    else if(this._DispatchToOtherHospital.CurrentStateDefID == DispatchToOtherHospital.States.Completed)
                        callRemoteMethod = true;
                }

                if(callRemoteMethod == true)
                    this._DispatchToOtherHospital.RunReturnDispatchToOtherHospital();
            }
        }
        */
        
#endregion DispatchToOtherHospResultForm_Methods
    }
}
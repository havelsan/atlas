
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
    /// <summary>
    /// Diğer XXXXXXlerden Konsültasyon 
    /// </summary>
    public partial class ConsultationFromOtherHospitalForm : EpisodeActionForm
    {
        override protected void BindControlEvents()
        {
            btnPrescription.Click += new TTControlEventDelegate(btnPrescription_Click);
            ShowMessageStatus.Click += new TTControlEventDelegate(ShowMessageStatus_Click);
            ProcedureDoctor.SelectedObjectChanged += new TTControlEventDelegate(ProcedureDoctor_SelectedObjectChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            btnPrescription.Click -= new TTControlEventDelegate(btnPrescription_Click);
            ShowMessageStatus.Click -= new TTControlEventDelegate(ShowMessageStatus_Click);
            ProcedureDoctor.SelectedObjectChanged -= new TTControlEventDelegate(ProcedureDoctor_SelectedObjectChanged);
            base.UnBindControlEvents();
        }

        private void btnPrescription_Click()
        {
#region ConsultationFromOtherHospitalForm_btnPrescription_Click
   this.CreateNewOutPatientPrescriptionn();
            //CreateNewOutPatientPrescriptionn();
#endregion ConsultationFromOtherHospitalForm_btnPrescription_Click
        }

        private void ShowMessageStatus_Click()
        {
#region ConsultationFromOtherHospitalForm_ShowMessageStatus_Click
   try
            {
                string s = null;
                if (String.IsNullOrEmpty(this._ConsultationFromOtherHospital.MessageID))
                {
                    InfoBox.Show("Mesaj numarası bulunamadı", MessageIconEnum.InformationMessage);
                    return;
                }
                TTMessage message = TTMessageFactory.GetMessage(new Guid(this._ConsultationFromOtherHospital.MessageID));
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
                            string result = ShowBox.Show(ShowBoxTypeEnum.Message,"&Evet,&Hayır","E,H","Uyarı","Diğer XXXXXX Konsültasyon","Diğer XXXXXXden gelen hata mesajı : \r\n" + s + "\r\n Tekrar gönderim yapılmasını ister misiniz?");
                            if(result == "E")
                            {
                                this._retrySendingConsultation = true;
                                InfoBox.Show("Mesajın tekrar gönderilebilmesi için Kaydet butonuna basınız.");
                                return;
                            }
                            else
                            {
                                this._retrySendingConsultation = false;
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
                     //   s = "Hata Bilgileri : " + message.MessageLog.LogText;
                    InfoBox.Show("Gönderim sırasında '" + message.MessageID + "' nolu mesaj ile ilgili hata alındı." 
                                 , MessageIconEnum.InformationMessage);
                }
                
            }
            catch(Exception ex)
            {
                InfoBox.Show(ex);
            }
#endregion ConsultationFromOtherHospitalForm_ShowMessageStatus_Click
        }

        private void ProcedureDoctor_SelectedObjectChanged()
        {
#region ConsultationFromOtherHospitalForm_ProcedureDoctor_SelectedObjectChanged
   if(this._ConsultationFromOtherHospital.ProcedureDoctor!=null)
                this._ConsultationFromOtherHospital.ConsultedDoctorName=this._ConsultationFromOtherHospital.ProcedureDoctor.Name;
#endregion ConsultationFromOtherHospitalForm_ProcedureDoctor_SelectedObjectChanged
        }

        protected override void PreScript()
        {
#region ConsultationFromOtherHospitalForm_PreScript
    base.PreScript();
            
            if(String.IsNullOrEmpty(this._ConsultationFromOtherHospital.MessageID))
                this.ShowMessageStatus.Visible = false;
            if (this.RequestedHospital.SelectedObject != null || this.RequestedDepartment.SelectedObject != null)
            {
                if(String.IsNullOrEmpty(this._ConsultationFromOtherHospital.SourceObjectID))
                {
                    if(this._ConsultationFromOtherHospital.CurrentStateDefID == ConsultationFromOtherHospital.States.ConsultationInOtherHospital)
                    {
                        this.DropStateButton (ConsultationFromOtherHospital.States.ResultEntry);
                        this.DropStateButton (ConsultationFromOtherHospital.States.Cancelled);
                        this.DropStateButton(ConsultationFromOtherHospital.States.InsertedIntoQueue);
                        //this.cmdOK.Visible=false;
                    }
                    else if(this._ConsultationFromOtherHospital.CurrentStateDefID == ConsultationFromOtherHospital.States.ResultEntry)
                    {
                        this.DropStateButton (ConsultationFromOtherHospital.States.Completed);
                        this.DropStateButton (ConsultationFromOtherHospital.States.Cancelled);
                        this.cmdOK.Visible=false;
                    }
                    else if(this._ConsultationFromOtherHospital.CurrentStateDefID == ConsultationFromOtherHospital.States.Completed)
                    {
                        this.ShowMessageStatus.Visible = false;
                    }
                    this.ProcedureDoctor.Visible = false;
                    this.ProcedureDoctorName.Visible = true;
                    this.ConsultationResultAndOffers.ReadOnly = true;
                    this.SecDiagnosisGrid.ReadOnly = true;
                    this.btnPrescription.Visible =false;
                    this.tttabInfo.HideTabPage(TabTreatmentMaterial);
                    this.tttabInfo.ShowTabPage(TabTreatmentMaterialShadow);

                }
                else
                {
                    if (this.ProcedureDoctor.SelectedObject == null)
                    {
                        ResUser currentUser = (ResUser)TTStorageManager.Security.TTUser.CurrentUser.UserObject;
                        if (currentUser.UserType == UserTypeEnum.Doctor)
                        {
                            this.ProcedureDoctor.SelectedObject = (ResUser)TTStorageManager.Security.TTUser.CurrentUser.UserObject;
                            this._ConsultationFromOtherHospital.ConsultedDoctorName=this._ConsultationFromOtherHospital.ProcedureDoctor.Name;
                        }
                    }
                    base.PreScript();
                    if(!(this._ConsultationFromOtherHospital.MasterResource is ResPoliclinic && ((ResPoliclinic)this._ConsultationFromOtherHospital.MasterResource).PatientCallSystemInUse == true))
                    {
                        this.DropStateButton(ConsultationFromOtherHospital.States.InsertedIntoQueue);
                    }
                        
                    this.ProcedureDoctor.Visible=true;
                    this.ProcedureDoctorName.Visible=false;
                    this.btnPrescription.Visible =true;
                    this.tttabInfo.HideTabPage(TabTreatmentMaterialShadow);
                    this.tttabInfo.ShowTabPage(TabTreatmentMaterial);

                }
            }
            else if (this.RequestedExternalHospital.SelectedObject != null || this.RequestedExternalDepartment.SelectedObject != null)
            {
                this.ProcedureDoctor.Visible = false;
                this.ProcedureDoctorName.Visible = true;
                this.btnPrescription.Visible =false;
                this.tttabInfo.HideTabPage(TabTreatmentMaterial);
                this.tttabInfo.ShowTabPage(TabTreatmentMaterialShadow);

                if(this._ConsultationFromOtherHospital.CurrentStateDefID == ConsultationFromOtherHospital.States.ResultEntry)
                    this.ProcedureDoctorName.ReadOnly = false;
            }
            
            
            this._retrySendingConsultation = false;
            this.SetTreatmentMaterialListFilter((TTObjectDef)TTObjectDefManager.Instance.ObjectDefs["BaseTreatmentMaterial"],(ITTGridColumn)this.GridTreatmentMaterials.Columns["MaterialBaseTreatmentMaterial"]);
#endregion ConsultationFromOtherHospitalForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region ConsultationFromOtherHospitalForm_PostScript
    base.PostScript(transDef);
#endregion ConsultationFromOtherHospitalForm_PostScript

            }
            
        protected override void ClientSidePostScript(TTObjectStateTransitionDef transDef)
        {
#region ConsultationFromOtherHospitalForm_ClientSidePostScript
    base.ClientSidePostScript(transDef);
            
            if(transDef != null)
            {
                if(transDef.ToStateDefID == ConsultationFromOtherHospital.States.ResultEntry)
                    this.StartPatientAdmissionCorrection();
                
                if(transDef.ToStateDefID == ConsultationFromOtherHospital.States.Completed)
                {
                    string prescriptionText = string.Empty;

                    BindingList<OutPatientPrescription> outPatientPrescriptionList = OutPatientPrescription.GetOutpatientPrescriptionByEpisode(this._ConsultationFromOtherHospital.ObjectContext,this._ConsultationFromOtherHospital.Episode.ObjectID);
                    foreach (OutPatientPrescription outPatientPrescription in outPatientPrescriptionList)
                    {
                        if (outPatientPrescription.MasterAction != null &&  outPatientPrescription.MasterAction.ObjectID == this._ConsultationFromOtherHospital.ObjectID)
                        {
                            foreach (OutPatientDrugOrder outPatientDrugOrder in outPatientPrescription.OutPatientDrugOrders)
                            {
                                if(outPatientDrugOrder.PhysicianDrug.Name != null)
                                    prescriptionText += "İlaç Adı: " + (outPatientDrugOrder.PhysicianDrug.Name).ToString() + "  ";
                                if(outPatientDrugOrder.Frequency != null)
                                    prescriptionText += "Doz Aralığı: " + (outPatientDrugOrder.Frequency).ToString() + "  ";
                                if(outPatientDrugOrder.DoseAmount != null)
                                    prescriptionText += "Doz Miktarı: " + (outPatientDrugOrder.DoseAmount).ToString() + " ";
                                if(outPatientDrugOrder.Day != null)
                                    prescriptionText += "Gün: " + (outPatientDrugOrder.Day).ToString() + "\n";
                                this.OutPatientPrescriptionInfo.Text = prescriptionText;
                            }
                        }
                    }
                    
                }
            }
            
            if (this._retrySendingConsultation == true)
            {
                if (String.IsNullOrEmpty(this._ConsultationFromOtherHospital.SourceObjectID))
                    this._ConsultationFromOtherHospital.RunSendConsultationFromOtherHospital();
                else
                    this._ConsultationFromOtherHospital.RunReturnConsultationFromOtherHospital();
            }
            CreateQueueItem(transDef);
#endregion ConsultationFromOtherHospitalForm_ClientSidePostScript

        }

#region ConsultationFromOtherHospitalForm_Methods
        private bool _retrySendingConsultation = false;
        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
            base.AfterContextSavedScript(transDef);
            if (!String.IsNullOrEmpty(this._ConsultationFromOtherHospital.SourceObjectID))
                if(transDef != null)
                if (transDef.ToStateDefID == ConsultationFromOtherHospital.States.Completed || transDef.ToStateDefID == ConsultationFromOtherHospital.States.Cancelled)
                this._ConsultationFromOtherHospital.RunReturnConsultationFromOtherHospital();
        }
        
//        private void CreateQueueItem(TTObjectStateTransitionDef transDef)
//        {
//            if(transDef != null && transDef.ToStateDefID == ConsultationFromOtherHospital.States.InsertedIntoQueue)
//            {
//                if(this._ConsultationFromOtherHospital.MasterResource is ResPoliclinic && ((ResPoliclinic)this._ConsultationFromOtherHospital.MasterResource).PatientCallSystemInUse == true)
//                {
//                    ExaminationQueueDefinition queueDef = null;
//                    queueDef = this.SelectQueue(this._ConsultationFromOtherHospital.ObjectContext,this._ConsultationFromOtherHospital.MasterResource,false);
//                    
//                    if(queueDef == null)
//                        throw new Exception("Hastanın ekleneceği sıra seçilmedi.");
//                    else
//                    {
//                        ResUser queueUser = this.SelectQueueUser(this._ConsultationFromOtherHospital.ObjectContext,queueDef,false);
//                        if(queueUser != null)
//                        {
//                            this.SetAuthorizedUserByQueueUser(queueUser,(EpisodeAction)this._ConsultationFromOtherHospital);
//                            if(this._ConsultationFromOtherHospital.AuthorizedUsers.Count > 0)
//                            {
//                                AuthorizedUser authorizedUser = this._ConsultationFromOtherHospital.AuthorizedUsers[this._ConsultationFromOtherHospital.AuthorizedUsers.Count-1];
//                                this._ConsultationFromOtherHospital.ProcedureDoctor=authorizedUser.User;
//                            }
//                        }
//                        else
//                        {
//                            string uKey = ShowBox.Show(ShowBoxTypeEnum.Message,"Evet,Hayır","E,H","Uyarı","Doktor Atama","Doktor atama yapmadan devam etmek istediğinize emin misiniz?",2);
//                            if(String.IsNullOrEmpty(uKey) == true || uKey == "H")
//                                throw new Exception("İşlemden vazgeçildi.");
//                        }
//                        
//                        bool isEmergency = false;
//                        if(this._ConsultationFromOtherHospital.FromResource != null)
//                        {
//                            foreach(ResourceSpecialityGrid spg in this._ConsultationFromOtherHospital.FromResource.ResourceSpecialities)
//                            {
//                                if(spg.Speciality != null)
//                                    if(spg.Speciality.Code == TTObjectClasses.SystemParameter.GetParameterValue("EMERGENCYSPECIALITYDEFINITIONCODE","4400").ToString()) //Acil Tıp
//                                    isEmergency = true;
//                            }
//                        }
//                        
//                        ExaminationQueueItem queueItem = null;
//                        queueItem = this._ConsultationFromOtherHospital.CreateExaminationQueueItem(this._ConsultationFromOtherHospital.SubEpisode.PatientAdmission,queueDef,isEmergency);
//                        if(queueItem == null)
//                            throw new Exception("Hastanın " + queueDef.Name + " kuyruğunda aktif bir sırası zaten mevcut. Sıraya ekleme yapılamaz.");
//                    }
//                }
//            }
//        }
        
#endregion ConsultationFromOtherHospitalForm_Methods
    }
}

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
    /// Sağlık Kurulu
    /// </summary>
    public partial class HCCommitteeAcceptanceForm : EpisodeActionForm
    {
        override protected void BindControlEvents()
        {
            //btnPhotoAndSlipReport.Click += new TTControlEventDelegate(btnPhotoAndSlipReport_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
           // btnPhotoAndSlipReport.Click -= new TTControlEventDelegate(btnPhotoAndSlipReport_Click);
            base.UnBindControlEvents();
        }
        //TODO NE : Raporlar yapılırken düzeltilecek
        /*
        private void btnPhotoAndSlipReport_Click()
        {
#region HCCommitteeAcceptanceForm_btnPhotoAndSlipReport_Click
   if (!string.IsNullOrEmpty(TTObjectClasses.SystemParameter.GetParameterValue("HCPHOTOFOLDERPATH", "")))
            {
                if (this._HealthCommittee.Episode.Patient.UniqueRefNo != null)
                {
                    string folderPath = TTObjectClasses.SystemParameter.GetParameterValue("HCPHOTOFOLDERPATH", "");
                    string uniqueRefNo = this._HealthCommittee.Episode.Patient.UniqueRefNo.ToString();
                    bool photoAdded = false;

                    System.IO.DirectoryInfo directory = new System.IO.DirectoryInfo(folderPath);
                    if (directory.Exists)
                    {
                        System.IO.FileInfo[] photoFiles = directory.GetFiles(uniqueRefNo + ".jpg");
                        if (photoFiles.Length == 0)
                            photoFiles = directory.GetFiles(uniqueRefNo + ".jpeg");
                        if (photoFiles.Length == 0)
                            photoFiles = directory.GetFiles(uniqueRefNo + ".jpe");
                        if (photoFiles.Length == 0)
                            photoFiles = directory.GetFiles(uniqueRefNo + ".jfif");

                        if (photoFiles.Length > 0)
                        {
                            System.IO.FileInfo photoFile = photoFiles[0];
                            TTObjectContext context = new TTObjectContext(false);
                            HealthCommittee hc = (HealthCommittee)context.GetObject(this._HealthCommittee.ObjectID, typeof(HealthCommittee));
                            hc.Picture = Image.FromFile(photoFile.FullName);
                            hc.Episode.Patient.Photo = Image.FromFile(photoFile.FullName);
                            context.Save();
                            context.Dispose();
                            photoAdded = true;
                        }
                        else
                            TTVisual.InfoBox.Show(folderPath + " klasöründe " + uniqueRefNo + ".jpg/.jpeg/.jpe/.jfif isimli dosya bulunamadığı için fotoğraf eklenemedi.", MessageIconEnum.WarningMessage);
                    }
                    else
                        TTVisual.InfoBox.Show(folderPath + " isimli klasör bulunamadığı için fotoğraf eklenemedi.", MessageIconEnum.WarningMessage);

                    if (photoAdded)
                    {
                        Dictionary<string, TTReportTool.PropertyCache<object>> parameters = new Dictionary<string, TTReportTool.PropertyCache<object>>();
                        TTReportTool.PropertyCache<object> cache = new TTReportTool.PropertyCache<object>();
                        cache.Add("VALUE", this._HealthCommittee.ObjectID.ToString());
                        parameters.Add("TTOBJECTID", cache);

                        // Muayene Nedeni tanımındaki Raporları Direkt Yazdır işaretli ise raporlar direkt yazıcıya gönderilir
                        //if (this._HealthCommittee.ReasonForExamination != null && this._HealthCommittee.ReasonForExamination.DirectlyPrintReports == true)
                        //{
                        //    if (this._HealthCommittee.ReasonForExamination.HealthCommitteeType == HealthCommitteeTypeEnum.FlierCommittee)
                        //    {
                        //        if (this._HealthCommittee.ReasonForExamination.ExaminationType == ExaminationTypeEnum.FlierExaminationForFiveYear)
                        //            TTReportTool.TTReport.PrintReport(null, typeof(TTReportClasses.I_HCEFlierSlipReportForFiveYears), false, 1, true, parameters);
                        //        else
                        //            TTReportTool.TTReport.PrintReport(null, typeof(TTReportClasses.I_HealthCommitteeExaminationFlierSlipReport), false, 1, true, parameters);
                        //    }
                        //    else
                        //        TTReportTool.TTReport.PrintReport(null, typeof(TTReportClasses.I_HealthCommitteeExaminationSlipReport), false, 1, true, parameters);
                        //}
                        //else
                        //{
                            if (this._HealthCommittee.HCRequestReason.ReasonForExamination.HealthCommitteeType == HealthCommitteeTypeEnum.FlierCommittee)
                            {
                                if (this._HealthCommittee.HCRequestReason.ReasonForExamination.ExaminationType == ExaminationTypeEnum.FlierExaminationForFiveYear)
                                    TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_HCEFlierSlipReportForFiveYears), true, 1, parameters);
                                else
                                    TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_HealthCommitteeExaminationFlierSlipReport), true, 1, parameters);
                            }
                            else
                                TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_HealthCommitteeExaminationSlipReport), true, 1, parameters);
                        //}
                    }
                }
            }
#endregion HCCommitteeAcceptanceForm_btnPhotoAndSlipReport_Click
        }*/
        /*
        protected override void PreScript()
        {
#region HCCommitteeAcceptanceForm_PreScript
    base.PreScript();

            if (this._HealthCommittee.CheckIfAllCancelledOrNotExists())
            {
                //throw new Exception("Hastaya ait Sağlık Kurulu Muayenesi bulunmamaktadır!\r\nİşleme devam edilemez.");
                throw new TTUtils.TTException(SystemMessage.GetMessage(486));
            }

            //kabul sebebi periyodik muayene değil ise periyodik muayeneye al kaldırılacak
            //            if (this._HealthCommittee.Episode.ReasonForAdmission.Type != AdmissionTypeEnum.PeriodicExamination && this._HealthCommittee.Episode.ReasonForAdmission.Type != AdmissionTypeEnum.SpacialCareExamReport)
            //            {
            //this.DropStateButton(HealthCommittee.States.PeriodicExaminationResult);
            //            }

            if (!string.IsNullOrEmpty(this._HealthCommittee.ClinicalReturnDescription))
            {
                this.tttextboxBackReason.Visible = true;
                this.labelReasonForBackCommittee.Visible = true;
            }

            if (this._HealthCommittee.UnCompletedExaminationExists())
                this.ResultedLabel.Visible = false;

            if (string.IsNullOrEmpty(TTObjectClasses.SystemParameter.GetParameterValue("HCPHOTOFOLDERPATH", "")))
                this.btnPhotoAndSlipReport.Visible = false;
            else
                this.btnPhotoAndSlipReport.Visible = true;
#endregion HCCommitteeAcceptanceForm_PreScript

            }
            
        protected override void ClientSidePostScript(TTObjectStateTransitionDef transDef)
        {
#region HCCommitteeAcceptanceForm_ClientSidePostScript
    base.ClientSidePostScript(transDef);
            CreateQueueItem(transDef);
            
            if(transDef != null)
            {
                if (transDef.FromStateDefID.Equals(HealthCommittee.States.CommitteeAcceptance) && transDef.ToStateDefID.Equals(HealthCommittee.States.Cancelled))
                    CancelLinkedEpisodeActions();
            }
#endregion HCCommitteeAcceptanceForm_ClientSidePostScript

        }

#region HCCommitteeAcceptanceForm_ClientSideMethods
        protected override void CreateQueueItem(TTObjectStateTransitionDef transDef)
        {
            if (this._HealthCommittee.MasterResource is ResHealthCommittee && ((ResHealthCommittee)this._HealthCommittee.MasterResource).PCSInUse == true)
            {
                if (transDef != null && Common.IsTransitionAttributeExists(typeof(CreateQueueItemAttribute), transDef))
                {
                    ExaminationQueueDefinition queueDef = null;
                    queueDef = this.SelectQueue(this._HealthCommittee.ObjectContext, this._HealthCommittee.MasterResource, false);

                    if (queueDef == null)
                        throw new Exception(SystemMessage.GetMessage(1015));
                    else
                    {
                        ExaminationQueueItem queueItem = null;
                        queueItem = this._HealthCommittee.CreateMyExaminationQueueItem(this._HealthCommittee.SubEpisode.PatientAdmission, queueDef);
                        if (queueItem == null)
                            throw new Exception(SystemMessage.GetMessage(1016, queueDef.Name.ToString()));
                        else
                            InfoBox.Alert(this._HealthCommittee.Episode.Patient.RefNo + " " + this._EpisodeAction.Episode.Patient.FullName + " hastası," + queueDef.Name + " sırasına eklendi. Sıradaki Toplam Hasta Sayısı : " + queueDef.CurrentItemsCount.ToString(), MessageIconEnum.InformationMessage);
                    }
                }
            }
        }
        
        // Sağlık Kurulu işlemi iptal edilirse, kendisine bağlı işlemleri de iptal eden metod
        public void CancelLinkedEpisodeActions()
        {
            if (TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", "İptal", "İptal", "Sağlık Kurulu ile ilişkili işlemlerin de iptal edilmesini istiyor musunuz ?") == "E")
            {
                ArrayList linkedActionList = _HealthCommittee.GetLinkedEpisodeActions();
                foreach (EpisodeAction linkedAction in linkedActionList)
                {
                    if (linkedAction is HealthCommitteeExamination) // Sağlık Kurulu Muayenesi
                    {
                        if(linkedAction.CurrentStateDefID != HealthCommitteeExamination.States.New && linkedAction.CurrentStateDefID != HealthCommitteeExamination.States.Cancelled)
                            throw new TTUtils.TTException("İlerletilmiş bir Sağlık Kurulu Muayenesi olduğu için ilişkili işlemler iptal edilemiyor. Öncelikle bu işlemin iptal edilmesi veya Yeni durumuna alınması gerekmektedir.\r\nİşlem No : " + linkedAction.ID.ToString());
                        
                        if(linkedAction.CurrentStateDefID == HealthCommitteeExamination.States.New)
                        {
                            HealthCommitteeExamination hcExamination = (HealthCommitteeExamination)linkedAction;
                            hcExamination.CurrentStateDefID = HealthCommitteeExamination.States.Cancelled;
                        }
                    }
                    else if (linkedAction is HealthCommitteeExaminationFromOtherHospitals) // Diğer XXXXXX(ler)den Sağlık Kurulu Muayenesi
                    {
                        if(linkedAction.CurrentStateDefID != HealthCommitteeExaminationFromOtherHospitals.States.New && linkedAction.CurrentStateDefID != HealthCommitteeExaminationFromOtherHospitals.States.Cancelled)
                            throw new TTUtils.TTException("İlerletilmiş bir Diğer XXXXXX(ler)den Sağlık Kurulu Muayenesi olduğu için ilişkili işlemler iptal edilemiyor. Öncelikle bu işlemin iptal edilmesi veya Yeni durumuna alınması gerekmektedir.\r\nİşlem No : " + linkedAction.ID.ToString());
                        
                        if(linkedAction.CurrentStateDefID == HealthCommitteeExaminationFromOtherHospitals.States.New)
                        {
                            HealthCommitteeExaminationFromOtherHospitals hcExaminationFOH = (HealthCommitteeExaminationFromOtherHospitals)linkedAction;
                            hcExaminationFOH.CurrentStateDefID = HealthCommitteeExaminationFromOtherHospitals.States.Cancelled;
                        }
                    }
                    else if (linkedAction is LaboratoryRequest) // Laboratuvar
                    {
                        if(linkedAction.CurrentStateDefID != LaboratoryRequest.States.RequestAcception && linkedAction.CurrentStateDefID != LaboratoryRequest.States.Cancelled)
                            throw new TTUtils.TTException("İlerletilmiş bir Laboratuvar olduğu için ilişkili işlemler iptal edilemiyor. Öncelikle bu işlemin iptal edilmesi veya İstek Kabul durumuna alınması gerekmektedir.\r\nİşlem No : " + linkedAction.ID.ToString());
                        
                        if(linkedAction.CurrentStateDefID == LaboratoryRequest.States.RequestAcception)
                        {
                            LaboratoryRequest laboratoryRequest = (LaboratoryRequest)linkedAction;
                            laboratoryRequest.CurrentStateDefID = LaboratoryRequest.States.Cancelled;
                        }
                    }
                    else if (linkedAction is Radiology) // Radyoloji
                    {
                        Radiology radiology = (Radiology)linkedAction;
                        foreach(RadiologyTest radiologyTest in radiology.RadiologyTests)
                        {
                            if(radiologyTest.CurrentStateDefID != RadiologyTest.States.RequestAcception && radiologyTest.CurrentStateDefID != RadiologyTest.States.Cancelled && radiologyTest.CurrentStateDefID != RadiologyTest.States.Reject)
                                throw new TTUtils.TTException("İlerletilmiş bir Radyoloji Tetkik olduğu için ilişkili işlemler iptal edilemiyor. Öncelikle bu işlemin iptal edilmesi veya İstek Kabul durumuna alınması gerekmektedir.\r\nİşlem No : " + radiologyTest.ID.ToString());
                            
                            if(radiologyTest.CurrentStateDefID == RadiologyTest.States.RequestAcception)
                                radiologyTest.CurrentStateDefID = RadiologyTest.States.Cancelled;
                        }
                        
                        if(radiology.CurrentStateDefID != Radiology.States.Procedure && radiology.CurrentStateDefID != Radiology.States.Reject)
                            throw new TTUtils.TTException("İlerletilmiş bir Radyoloji olduğu için ilişkili işlemler iptal edilemiyor. Öncelikle bu işlemin iptal edilmesi veya İşlemde durumuna alınması gerekmektedir.\r\nİşlem No : " + radiology.ID.ToString());
                        
                        if(radiology.CurrentStateDefID == Radiology.States.Procedure)
                            radiology.CurrentStateDefID = Radiology.States.Reject;
                    }
                    else if (linkedAction is ManipulationRequest)
                    {
                        ManipulationRequest manipulationRequest = (ManipulationRequest)linkedAction;
                        foreach(Manipulation manipulation in manipulationRequest.Manipulations)
                        {
                            if(manipulation.CurrentStateDefID != Manipulation.States.RequestAcception && manipulation.CurrentStateDefID != Manipulation.States.Cancelled)
                                throw new TTUtils.TTException("İlerletilmiş bir Tıbbi/Cerrahi Uygulama olduğu için ilişkili işlemler iptal edilemiyor. Öncelikle bu işlemin iptal edilmesi veya İstek Kabulü durumuna alınması gerekmektedir.\r\nİşlem No : " + manipulation.ID.ToString());
                            
                            if(manipulation.CurrentStateDefID == Manipulation.States.RequestAcception)
                                manipulation.CurrentStateDefID = Manipulation.States.Cancelled;
                        }
                        
                        if(manipulationRequest.CurrentStateDefID == ManipulationRequest.States.Request || manipulationRequest.CurrentStateDefID == ManipulationRequest.States.Completed)
                            manipulationRequest.CurrentStateDefID = ManipulationRequest.States.Cancelled;
                    }
                }
            }
        }
        
#endregion HCCommitteeAcceptanceForm_ClientSideMethods
*/
    }
}
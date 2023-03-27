
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
    /// Sağlık Kurulu Muayenesi-İlgili Uzman
    /// </summary>
    public partial class HCEExaminationForm : EpisodeActionForm
    {
        override protected void BindControlEvents()
        {
          //  btnESignature.Click += new TTControlEventDelegate(btnESignature_Click);
            //IsHealthy.CheckedChanged += new TTControlEventDelegate(IsHealthy_CheckedChanged);
           // MatterSliceAnectodeGrid.CellValueChanged += new TTGridCellEventDelegate(MatterSliceAnectodeGrid_CellValueChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
           // btnESignature.Click -= new TTControlEventDelegate(btnESignature_Click);
          //  IsHealthy.CheckedChanged -= new TTControlEventDelegate(IsHealthy_CheckedChanged);
           // MatterSliceAnectodeGrid.CellValueChanged -= new TTGridCellEventDelegate(MatterSliceAnectodeGrid_CellValueChanged);
            base.UnBindControlEvents();
        }

//        private void btnESignature_Click()
//        {
//#region HCEExaminationForm_btnESignature_Click
//   _HealthCommitteeExamination.ShowSignedDocument();
//#endregion HCEExaminationForm_btnESignature_Click
//        }

//        private void IsHealthy_CheckedChanged()
//        {
//#region HCEExaminationForm_IsHealthy_CheckedChanged
//   if(this._HealthCommitteeExamination.IsHealthy == true)
//            {
//                if(this._HealthCommitteeExamination.Report == null || (this._HealthCommitteeExamination.Report != null && string.IsNullOrEmpty(Common.GetTextOfRTFString(this._HealthCommitteeExamination.Report.ToString()).Trim())))
//                    this.Report.Text = "SAĞLAM";
//                bool healthyDiagnoseExists = false;
//                foreach(DiagnosisGrid sdg in this._HealthCommitteeExamination.SecDiagnosis)
//                {
//                    if(sdg.DiagnoseCode.Trim() == "Z13.9")
//                    {
//                        healthyDiagnoseExists = true;
//                        break;
//                    }
//                }
//                if(!healthyDiagnoseExists)
//                {
//                    DiagnosisDefinition healthyDiagnosis = null;
//                    BindingList<DiagnosisDefinition> ddList = DiagnosisDefinition.GetDiagnosisDefinitionByCode(this._HealthCommitteeExamination.ObjectContext, "Z13.9", "");
//                    foreach(DiagnosisDefinition dd in ddList)
//                    {
//                        healthyDiagnosis = dd;
//                        break;
//                    }
//                    if(healthyDiagnosis != null)
//                    {
//                        DiagnosisGrid healthyDiagnosisGrid = new DiagnosisGrid(this._HealthCommitteeExamination.ObjectContext);
//                        healthyDiagnosisGrid.Diagnose = healthyDiagnosis;
//                        healthyDiagnosisGrid.DiagnosisType = DiagnosisTypeEnum.Seconder;
//                        this._HealthCommitteeExamination.Diagnosis.Add(healthyDiagnosisGrid);
//                    }
//                }
//            }
//            else
//            {
//                if(this._HealthCommitteeExamination.Report != null && (Common.GetTextOfRTFString(this._HealthCommitteeExamination.Report.ToString()).ToUpper()).Trim() == "SAĞLAM")
//                    this._HealthCommitteeExamination.Report = "";
//                List<DiagnosisGrid> sdgList = new List<DiagnosisGrid>();
//                foreach(DiagnosisGrid sdg in this._HealthCommitteeExamination.SecDiagnosis)
//                {
//                    if(sdg.DiagnoseCode.Trim() == "Z13.9")
//                        sdgList.Add(sdg);
//                }
                
//                foreach(DiagnosisGrid sdg in sdgList)
//                    ((ITTObject)sdg).Delete();
//            }
//#endregion HCEExaminationForm_IsHealthy_CheckedChanged
//        }

//        private void MatterSliceAnectodeGrid_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
//        {
//#region HCEExaminationForm_MatterSliceAnectodeGrid_CellValueChanged
//   if (rowIndex < MatterSliceAnectodeGrid.Rows.Count && rowIndex > -1)
//            {
//                /*
//                MatterSliceAnectodeGrid  matterSliceAnect = (MatterSliceAnectodeGrid)((ITTGridRow)ttgrid1.Rows[rowIndex]).TTObject;
//                if(matterSliceAnect.Matter != null && ((MatterSliceAnectodeGrid)matterSliceAnect).Slice != null && ((MatterSliceAnectodeGrid)matterSliceAnect).Anectode != null)
//                {
//                    string decisionStr = "";
//                    foreach(MatterSliceAnectodeGrid msaGrid in this._HealthCommitteeExamination.MatterSliceAnectodes)
//                    {
//                        IList decisionList = HCMatterSliceAnectodeDefinition.GetHCDecisionByMatterSliceAnectode(this._HealthCommitteeExamination.ObjectContext,(int)msaGrid.Matter,(SliceEnum)((MatterSliceAnectodeGrid)msaGrid).Slice,(int)((MatterSliceAnectodeGrid)msaGrid).Anectode);
//                        foreach(HCMatterSliceAnectodeDefinition decision in decisionList)
//                        {
//                            decisionStr += TTObjectClasses.Common.GetTextOfRTFString(decision.OfferOfDecision) + "\n\r" ;
//                        }
//                    }
                    
//                    this.Report.Text = decisionStr.ToString() ;

//                }
//                 */
//            }
//#endregion HCEExaminationForm_MatterSliceAnectodeGrid_CellValueChanged
//        }

        protected override void PreScript()
        {
#region HCEExaminationForm_PreScript
    base.PreScript();

            if (this._HealthCommitteeExamination.CurrentStateDefID == HealthCommitteeExamination.States.Examination )//|| this._HealthCommitteeExamination.CurrentStateDefID == HealthCommitteeExamination.States.ESignature)
                this.SetProcedureDoctorAsCurrentResource();
            
            //this.SetDiagnosisListFilter((ITTGridColumn)this.GridPreDiagnosis.Columns["PreDiagnose"], (ITTGridColumn)this.GridDiagnosis.Columns["Diagnose"]);
            
            if(!((ITTObject)this._HealthCommitteeExamination).IsReadOnly)
            {
                if (this._HealthCommitteeExamination.ReportDate == null)
                    this.ReportDate.ControlValue = Common.RecTime();
            }            
          
            // Elektronik İmzala butonu sadece Elektronik İmza Kullanır işaretli olan kullanıcılara görünecek
            if (this._HealthCommitteeExamination.CurrentStateDefID == HealthCommitteeExamination.States.Examination)
            {
//                if(Common.CurrentResource.UsesESignature != true)
//                    this.DropStateButton(HealthCommitteeExamination.States.ESignature);
            }
//            else if (this._HealthCommitteeExamination.CurrentStateDefID == HealthCommitteeExamination.States.ESignature)
//            {   // ESignature adımında bilgilerin değiştirilememesi gerekiyor
//                ReportDate.ReadOnly = true;
//                HealthCommitteeStartDate.ReadOnly = true;
//                NumberOfProcess.ReadOnly = true;
//                Height.ReadOnly = true;
//                Weight.ReadOnly = true;
//                IsHealthy.ReadOnly = true;
//                OfferOfDecision.ReadOnly = true;
//                Report.ReadOnly = true;
//                GridDiagnosis.Enabled = false;
//                GridEpisodeDiagnosis.Enabled = false;
//                TreatmentMaterialsGrid.Enabled = false;
//                MatterSliceAnectodeGrid.Enabled = false;
//                HCSummaryPrevious.Enabled = false;
//                this.cmdOK.Visible = false;
//                
//                _HealthCommitteeExamination.SignedData = null; // Elektronik İmza adımı açılırken önceden imzalanmış ve kaydedilmiş döküman varsa silinir ve tekrar elektronik imzalanması gerekir.
//            }
            
            
            //Malzeme listesi set ediliyor.
            this.SetTreatmentMaterialListFilter((TTObjectDef)TTObjectDefManager.Instance.ObjectDefs["BaseTreatmentMaterial"], (ITTGridColumn)this.TreatmentMaterialsGrid.Columns["Material"]);
#endregion HCEExaminationForm_PreScript

            }
            
        protected override void ClientSidePreScript()
        {
#region HCEExaminationForm_ClientSidePreScript
    base.ClientSidePreScript();
            //Engelli raporu içinse görünecek

            if (this._HealthCommitteeExamination.MasterAction is HealthCommittee)
            {
                if (((HealthCommittee)this._HealthCommitteeExamination.MasterAction).HCRequestReason != null && ((HealthCommittee)this._HealthCommitteeExamination.MasterAction).HCRequestReason.ReasonForExamination != null && ((HealthCommittee)this._HealthCommitteeExamination.MasterAction).HCRequestReason.ReasonForExamination.HCReportTypeDefinition != null)
                {
                    if (((HealthCommittee)this._HealthCommitteeExamination.MasterAction).HCRequestReason.ReasonForExamination.HCReportTypeDefinition.IsDisabled == true)
                    {
                        labelDisabledRatio.Visible = true;
                        DisabledRatio.Visible = true;
                    }
                    else
                    {
                        labelDisabledRatio.Visible = false;
                        DisabledRatio.Visible = false;
                    }
                }
            }

                //Sadece desteklenen Speciality ler için, (hızlandırma amaçlı)
                if (this.IsSupportedSpeciality(this._HealthCommitteeExamination.ProcedureSpeciality.ObjectID))
            {
                //Shows Laboratory Results in this form
                bool reportFound = false;
                if (this._HealthCommitteeExamination.CurrentStateDefID == HealthCommitteeExamination.States.Examination)
                {
                    // Tetkik sonuçları 2. kez yazılması diye rapor alanı boşaltılır, tetkik sonuçlarının sonuna elle yapılan eklemeler de
                    // silinecek, aynı alan olduğu için böyle yapmaya karar verdik
                    this.Report.Text = string.Empty;
                    if (this._HealthCommitteeExamination.MasterAction != null)
                    {
                        if (this._HealthCommitteeExamination.MasterAction is HealthCommittee)
                        {
                            foreach (BaseAction baseAction in this._HealthCommitteeExamination.MasterAction.LinkedActions)
                            {
                                if (IsSupportedObjectType(baseAction))
                                {
                                    EpisodeAction ea = baseAction as EpisodeAction;
                                    foreach (ResourceSpecialityGrid resourceSpeciality in ea.MasterResource.ResourceSpecialities)
                                    {
                                        if (this._HealthCommitteeExamination.ProcedureSpeciality.ObjectID == resourceSpeciality.Speciality.ObjectID)
                                        {
                                            if (baseAction.IsCancelled == false)
                                            {
                                                if (baseAction is LaboratoryRequest)
                                                {
                                                    LaboratoryRequest lab = baseAction as LaboratoryRequest;
                                                    GetReportFromLaboratoryAction(lab);
                                                    reportFound = true;
                                                    break; //Sadece bu for dan çıkmak için
                                                }
                                                if (baseAction is Radiology)
                                                {
                                                    Radiology rad = baseAction as Radiology;
                                                    GetReportFromRadiologyAction(rad);
                                                    reportFound = true;
                                                    break; //Sadece bu for dan çıkmak için
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    
                    // Episode daki sonradan istenen (HealthCommittee ye bağlı olmayan) tetkikleri de getirmek için
                    if (reportFound == true)
                    {
                        MultiSelectForm msitem = new MultiSelectForm();
                        string uncompletedInfo = "";
                        foreach (BaseAction baseAction in this._HealthCommitteeExamination.Episode.EpisodeActions)
                        {
                            if (IsSupportedObjectType(baseAction))
                            {
                                if (baseAction.IsCancelled == false && baseAction.IsUncompleted == false)
                                {
                                    // HealthCommittee nin LinkedAction larına yukarıda bakıldığı için tekrar bakılmamalı,
                                    // yoksa tekrar eder
                                    if(baseAction.MasterAction != this._HealthCommitteeExamination.MasterAction)
                                    {
                                        EpisodeAction ea = baseAction as EpisodeAction;
                                        foreach (ResourceSpecialityGrid resourceSpeciality in ea.MasterResource.ResourceSpecialities)
                                        {
                                            if (this._HealthCommitteeExamination.ProcedureSpeciality.ObjectID == resourceSpeciality.Speciality.ObjectID)
                                            {
                                                msitem.AddMSItem(baseAction.ObjectDef.Description + " " + baseAction.ActionDate.Value.ToString(), baseAction.ObjectID.ToString(), baseAction);
                                                break;
                                            }
                                        }
                                    }
                                }
                                if (baseAction.IsCancelled == false && baseAction.IsUncompleted == true)
                                {
                                    // HealthCommittee nin LinkedAction larına yukarıda bakıldığı için tekrar bakılmamalı,
                                    // yoksa tekrar eder
                                    if(baseAction.MasterAction != this._HealthCommitteeExamination.MasterAction)
                                    {
                                        EpisodeAction ea = baseAction as EpisodeAction;
                                        foreach (ResourceSpecialityGrid resourceSpeciality in ea.MasterResource.ResourceSpecialities)
                                        {
                                            if (this._HealthCommitteeExamination.ProcedureSpeciality.ObjectID == resourceSpeciality.Speciality.ObjectID)
                                            {
                                                if(ea.ActionType == ActionTypeEnum.LaboratoryRequest)
                                                    uncompletedInfo += ea.ID + " işlem numaralı Laboratuvar işlemi tamamlanmamıştır.\n";
                                                if(ea.ActionType == ActionTypeEnum.Radiology)
                                                    uncompletedInfo += ea.ID + " işlem numaralı Radyoloji işlemi tamamlanmamıştır.\n";
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        
                        if(!string.IsNullOrEmpty(uncompletedInfo))
                        {
                            uncompletedInfo += "Devam etmek istiyor musunuz?";
                            if(TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", "Uayrı", "Uyarı", uncompletedInfo) == "H")
                                throw new TTUtils.TTException("İşlemden vazgeçildi");
                        }
                        string k = msitem.GetMSItem(this, "İlgili Tetkikler",false,true,true);
                        if (k != "")
                        {
                            foreach (object a in msitem.MSSelectedItemObjects)
                            {
                                BaseAction baseAction = a as BaseAction;
                                if (baseAction is LaboratoryRequest)
                                {
                                    LaboratoryRequest lab = baseAction as LaboratoryRequest;
                                    GetReportFromLaboratoryAction(lab);
                                }
                                if (baseAction is Radiology)
                                {
                                    Radiology rad = baseAction as Radiology;
                                    GetReportFromRadiologyAction(rad);
                                }
                            }
                        }
                    }
                    else if (reportFound == false)
                    {
                        MultiSelectForm msitem = new MultiSelectForm();
                        string uncompletedInfo = "";
                        msitem.AddMSItem("<Tüm Vakaları>", "ALL");
                        foreach (BaseAction baseAction in this._HealthCommitteeExamination.Episode.EpisodeActions)
                        {
                            if (baseAction.IsCancelled == false && baseAction.IsUncompleted == false)
                            {
                                if (IsSupportedObjectType(baseAction))
                                {
                                    EpisodeAction ea = baseAction as EpisodeAction;
                                    foreach (ResourceSpecialityGrid resourceSpeciality in ea.MasterResource.ResourceSpecialities)
                                    {
                                        if (this._HealthCommitteeExamination.ProcedureSpeciality.ObjectID == resourceSpeciality.Speciality.ObjectID)
                                        {
                                            msitem.AddMSItem(baseAction.ObjectDef.Description + " " + baseAction.ActionDate.Value.ToString(), baseAction.ObjectID.ToString(), baseAction);
                                        }
                                    }
                                }
                            }
                            if (baseAction.IsCancelled == false && baseAction.IsUncompleted == true)
                            {
                                if (IsSupportedObjectType(baseAction))
                                {
                                    if(baseAction.MasterAction != this._HealthCommitteeExamination.MasterAction)
                                    {
                                        EpisodeAction ea = baseAction as EpisodeAction;
                                        foreach (ResourceSpecialityGrid resourceSpeciality in ea.MasterResource.ResourceSpecialities)
                                        {
                                            if (this._HealthCommitteeExamination.ProcedureSpeciality.ObjectID == resourceSpeciality.Speciality.ObjectID)
                                            {
                                                if(ea.ActionType == ActionTypeEnum.LaboratoryRequest)
                                                    uncompletedInfo += ea.ID + " işlem numaralı Laboratuvar işlemi tamamlanmamıştır.\n";
                                                if(ea.ActionType == ActionTypeEnum.Radiology)
                                                    uncompletedInfo += ea.ID + " işlem numaralı Radyoloji işlemi tamamlanmamıştır.\n";
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        if(!string.IsNullOrEmpty(uncompletedInfo))
                        {
                            uncompletedInfo += "Devam etmek istiyor musunuz?";
                            if(TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", "Uayrı", "Uyarı", uncompletedInfo) == "H")
                                throw new TTUtils.TTException("İşlemden vazgeçildi");
                        }
                        string k = msitem.GetMSItem(this, "İlgili Tetkikler",true,true,true);
                        if (k != "")
                        {
                            if (k == "ALL")
                            {
                                msitem = new MultiSelectForm();
                                foreach (Episode e in this._HealthCommitteeExamination.Episode.Patient.Episodes)
                                {
                                    foreach (BaseAction baseAction in e.EpisodeActions)
                                    {
                                        if (IsSupportedObjectType(baseAction))
                                        {
                                            if (baseAction.IsCancelled == false && baseAction.IsUncompleted == false)
                                            {
                                                EpisodeAction ea = baseAction as EpisodeAction;
                                                foreach (ResourceSpecialityGrid resourceSpeciality in ea.MasterResource.ResourceSpecialities)
                                                {
                                                    if (this._HealthCommitteeExamination.ProcedureSpeciality.ObjectID == resourceSpeciality.Speciality.ObjectID)
                                                    {
                                                        msitem.AddMSItem(baseAction.ObjectDef.Description + " " + baseAction.ActionDate.Value.ToString(), baseAction.ObjectID.ToString(), baseAction);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                k = msitem.GetMSItem(this, "İlgili Tetkikler",true,true,true);
                            }
                            if (k != "")
                            {
                                foreach (object a in msitem.MSSelectedItemObjects)
                                {
                                    BaseAction baseAction = a as BaseAction;
                                    if (baseAction is LaboratoryRequest)
                                    {
                                        LaboratoryRequest lab = baseAction as LaboratoryRequest;
                                        GetReportFromLaboratoryAction(lab);
                                    }
                                    if (baseAction is Radiology)
                                    {
                                        Radiology rad = baseAction as Radiology;
                                        GetReportFromRadiologyAction(rad);
                                    }
                                }
                            }
                        }
                    }
                    
                    if (this.Report.Text != string.Empty)
                    {
                        this.Report.Rtf = @"{\rtf1\ansi\ansicpg1254\deff0\deflang1055{\fonttbl{\f0\fnil\fcharset162 Tahoma;}}
\viewkind4\uc1\pard\f0\fs20 " + this.Report.Text + @"\par
}
";
                    }
                }
            }
#endregion HCEExaminationForm_ClientSidePreScript

        }

        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region HCEExaminationForm_PostScript
    base.PostScript(transDef);
            
            if(this._HealthCommitteeExamination.OriginalStateDef.StateDefID == HealthCommitteeExamination.States.Examination)// || this._HealthCommitteeExamination.OriginalStateDef.StateDefID == HealthCommitteeExamination.States.ESignature)
            {
                if(transDef == null || (transDef != null && transDef.ToStateDefID == HealthCommitteeExamination.States.Completed))
                    this.CompleteMyExaminationQueueItems();
            }
#endregion HCEExaminationForm_PostScript

            }
            
        protected override void ClientSidePostScript(TTObjectStateTransitionDef transDef)
        {
#region HCEExaminationForm_ClientSidePostScript
    /* Uyarının verilmemesi istendiği için kaldırıldı -- INC044946
            if(transDef != null)
            {
                if(transDef.FromStateDefID.Equals(HealthCommitteeExamination.States.Examination) && (transDef.ToStateDefID.Equals(HealthCommitteeExamination.States.ESignature) || transDef.ToStateDefID.Equals(HealthCommitteeExamination.States.Completed)))
                {
                    string res = ShowBox.Show(ShowBoxTypeEnum.Message,"&Evet,&Hayır", "E,H", "Uyarı", "Emin misiniz?","Bu işlemi yaptıktan sonra, hasta muayane bilgileri üzerinde herhangi bir değişiklik yapamazsınız. Emin misiniz? ", 1);
                    if(res == "H")
                        throw new Exception(SystemMessage.GetMessage(642));
                }
            }
             */
//            if(transDef.FromStateDefID == HealthCommitteeExamination.States.ESignature && transDef.ToStateDefID == HealthCommitteeExamination.States.Completed )
//            {
//                ESign();
//                if(_HealthCommitteeExamination.SignedData == null)
//                    throw new Exception("Sağlık Kurulu Bölüm Raporu elektronik olarak imzalanmadan işlem tamamlanamaz.");
//
//            }
#endregion HCEExaminationForm_ClientSidePostScript

        }

#region HCEExaminationForm_Methods
        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
            base.AfterContextSavedScript(transDef);
            ResSection resSection = (ResSection)this._HealthCommitteeExamination.MasterResource;
            if(resSection.DontShowHCDepartmentReport != true)
            {
                if (transDef != null && transDef.ToStateDefID == HealthCommitteeExamination.States.Completed)
                {
                    Dictionary<string, TTReportTool.PropertyCache<object>> parameters = new Dictionary<string, TTReportTool.PropertyCache<object>>();
                    TTReportTool.PropertyCache<object> cache = new TTReportTool.PropertyCache<object>();
                    cache.Add("VALUE", this._HealthCommitteeExamination.ObjectID.ToString());
                    parameters.Add("TTOBJECTID", cache);

                    TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_HealthCommitteeDepartmentReport), true, 1, parameters);
                }
            }
        }
        
        public override void SetProcedureDoctorAsCurrentResource()
        {
            if(Common.CurrentUser.IsSuperUser != true)
            {
                if(Common.CurrentResource.UserType == UserTypeEnum.Doctor || Common.CurrentResource.UserType == UserTypeEnum.Dentist)
                {
                    if(this._HealthCommitteeExamination.ProcedureDoctor == null)
                        this._HealthCommitteeExamination.ProcedureDoctor = Common.CurrentResource;
                    else
                    {
                        if(this._HealthCommitteeExamination.ProcedureDoctor.ObjectID != Common.CurrentResource.ObjectID)
                        {
                            string msg = "İşlemin sorumlu doktoru :  " + this._HealthCommitteeExamination.ProcedureDoctor.Name + " . \r\n \r\nİşlemi kaydettiğinizde sorumlu doktor olarak kaydedileceksiniz.";
                            InfoBox.Alert(msg,MessageIconEnum.InformationMessage);
                            this._HealthCommitteeExamination.ProcedureDoctor = Common.CurrentResource;
                        }
                    }
                }
            }
            
            if(((ITTObject)this._HealthCommitteeExamination).HasErrors == true)
                throw new Exception(((ITTObject)this._HealthCommitteeExamination).GetErrors());
        }
        
#endregion HCEExaminationForm_Methods

#region HCEExaminationForm_ClientSideMethods
        private bool IsSupportedObjectType(BaseAction baseAction)
        {
            if (baseAction is LaboratoryRequest || baseAction is Radiology)
                return true;
            else
                return false;
        }

        const string Biyokimya = "1571b12c-9157-493f-aa29-e3fb0af497f3";
        const string Mikrobiyoloji = "935b3e22-beb9-440b-945e-b0364365664a";
        const string Radyoloji = "71a529c8-8b9a-4916-8854-d327b9ac1bdb";
        const string Immunoloji = "9e62c503-90f6-4524-8fe7-cc7bd0cf2198";
        const string Hematoloji = "5f426430-a0c9-4f03-9788-e7f56658c11a";
        const string Farmakoloji = "d3f975c7-18ad-418c-9452-6985ccb6fc99";

        private bool IsSupportedSpeciality(Guid speciality)
        {
            string specialityID = speciality.ToString();
            if (specialityID == Biyokimya || specialityID == Mikrobiyoloji || specialityID == Radyoloji || specialityID == Immunoloji ||
                specialityID == Hematoloji || specialityID == Farmakoloji )
                return true;
            else
                return false;
        }
        
        private void GetReportFromRadiologyAction(Radiology rad)
        {
            if (rad.IsUncompleted)
                throw new Exception(SystemMessage.GetMessage(643));

            StringBuilder builder = new StringBuilder();
            foreach (RadiologyTest radProc in rad.RadiologyTests)
            {
                builder.Append(radProc.ProcedureObject.Name + ": ");
                if (radProc.Report != null)
                {
                    string report = Common.GetTextOfRTFString(radProc.Report.ToString());
                    report = report.Replace("  ", " ");
                    report = report.Replace("\r\n", "");
                    report = report.Replace("\r", "");
                    report = report.Replace("\n", "");
                    builder.Append(report);
                }
                builder.Append(" , ");
            }
            this.Report.Text = this.Report.Text + builder.ToString() + "\r\n";
        }
        
        //public void ESign()
        //{
        //    Dictionary<string, TTReportTool.PropertyCache<object>> parameters = new Dictionary<string, TTReportTool.PropertyCache<object>>();
        //    TTReportTool.PropertyCache<object> cache = new TTReportTool.PropertyCache<object>();
        //    cache.Add("VALUE", _HealthCommitteeExamination.ObjectID.ToString());
        //    parameters.Add("TTOBJECTID", cache);
        //    _HealthCommitteeExamination.SignedData = TTUtils.ESignatureManagerFactory.DocumentSigner.SignReport("Sağlık Kurulu Bölüm Raporu Elektronik İmzalama", typeof(TTReportClasses.I_HealthCommitteeDepartmentReport), parameters);
        //}

        private void GetReportFromLaboratoryAction(LaboratoryRequest lab)
        {
            if (lab.IsUncompleted)
                throw new Exception(SystemMessage.GetMessage(644));

            StringBuilder builder = new StringBuilder();
            
            if(!string.IsNullOrEmpty(this.Report.Text))
                builder.AppendLine(@"\line");
            
            builder.Append(lab.WorkListDate.Value.ToString("dd.MM.yyyy") + " tarihli sonuçlar:");
            builder.AppendLine(@"\line");
            foreach (LaboratoryProcedure labProc in lab.LaboratoryProcedures)
            {
                builder.Append("--");
                if(labProc.Warning == HighLowEnum.High || labProc.Warning == HighLowEnum.Low || labProc.Warning == HighLowEnum.Panic)
                    builder.Append("\\b ");
                
                builder.Append(labProc.ProcedureObject.Name + " ");
                if (labProc.Result != null && labProc.Result != "")
                {
                    builder.Append(labProc.Result + " ");
                    builder.Append(labProc.Unit + " ");
                    if (labProc.Warning != null)
                        builder.Append(TTObjectClasses.Common.GetDisplayTextOfDataTypeEnum(labProc.Warning.Value));
                }
                
                if(labProc.Warning == HighLowEnum.High || labProc.Warning == HighLowEnum.Low || labProc.Warning == HighLowEnum.Panic)
                    builder.Append("\\b0 ");
                
                if (labProc.LongReport != null && !string.IsNullOrEmpty(labProc.LongReport.ToString()))
                {
                    builder.Append(" ");
                    string report = Common.GetTextOfRTFString(labProc.LongReport.ToString());
                    report = report.Replace("  ", " ");
                    report = report.Replace("\r\n", "");
                    report = report.Replace("\r", "");
                    report = report.Replace("\n", "");
                    builder.Append(report);
                }

                if (labProc.LaboratorySubProcedures.Count > 0)
                {
                    builder.Append("\\b (\\b0 ");
                    foreach (LaboratorySubProcedure subLabProc in labProc.LaboratorySubProcedures)
                    {
                        if(subLabProc.Warning == HighLowEnum.High || subLabProc.Warning == HighLowEnum.Low || subLabProc.Warning == HighLowEnum.Panic)
                            builder.Append("\\b ");
                        
                        builder.Append(subLabProc.ProcedureObject.Name + " ");
                        if (subLabProc.Result != null && subLabProc.Result != "")
                        {
                            builder.Append(subLabProc.Result + " ");
                            builder.Append(subLabProc.Unit + " ");
                            if (subLabProc.Warning != null)
                                builder.Append(TTObjectClasses.Common.GetDisplayTextOfDataTypeEnum(subLabProc.Warning.Value));
                        }
                        
                        if(subLabProc.Warning == HighLowEnum.High || subLabProc.Warning == HighLowEnum.Low || subLabProc.Warning == HighLowEnum.Panic)
                            builder.Append("\\b0 ");
                        
                        if (subLabProc.LongReport != null && !string.IsNullOrEmpty(subLabProc.LongReport.ToString()))
                        {
                            builder.Append(" ");
                            string report = Common.GetTextOfRTFString(subLabProc.LongReport.ToString());
                            report = report.Replace("  ", " ");
                            report = report.Replace("\r\n", "");
                            report = report.Replace("\r", "");
                            report = report.Replace("\n", "");
                            builder.Append(report);
                        }
                        builder.Append(" / ");
                    }
                    builder.Remove((builder.Length -3),3);
                    builder.Append("\\b )\\b0 ");
                }
                builder.Append(" , ");
            }
            this.Report.Text = this.Report.Text + builder.ToString().Substring(0,(builder.ToString().Length-3));
        }
        
#endregion HCEExaminationForm_ClientSideMethods
    }
}
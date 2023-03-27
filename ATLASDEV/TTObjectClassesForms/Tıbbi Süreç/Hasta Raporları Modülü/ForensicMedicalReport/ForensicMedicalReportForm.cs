
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
    /// Adli Tıp Raporları
    /// </summary>
    public partial class ForensicMedicalReportForm : EpisodeActionForm
    {
        override protected void BindControlEvents()
        {
            OtherReasonExamination.TextChanged += new TTControlEventDelegate(OtherReasonExamination_TextChanged);
            PsychiatricConsultation.CheckedChanged += new TTControlEventDelegate(PsychiatricConsultation_CheckedChanged);
            PyschiatricExamination.CheckedChanged += new TTControlEventDelegate(PyschiatricExamination_CheckedChanged);
            NoEvidancePsycho.CheckedChanged += new TTControlEventDelegate(NoEvidancePsycho_CheckedChanged);
            Attaches4.CheckedChanged += new TTControlEventDelegate(Attaches4_CheckedChanged);
            Need.CheckedChanged += new TTControlEventDelegate(Need_CheckedChanged);
            NoNeed.CheckedChanged += new TTControlEventDelegate(NoNeed_CheckedChanged);
            ReasonExaminationReportType.SelectedIndexChanged += new TTControlEventDelegate(ReasonExaminationReportType_SelectedIndexChanged);
            //ForensicReportType.SelectedIndexChanged += new TTControlEventDelegate(ForensicReportType_SelectedIndexChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            OtherReasonExamination.TextChanged -= new TTControlEventDelegate(OtherReasonExamination_TextChanged);
            PsychiatricConsultation.CheckedChanged -= new TTControlEventDelegate(PsychiatricConsultation_CheckedChanged);
            PyschiatricExamination.CheckedChanged -= new TTControlEventDelegate(PyschiatricExamination_CheckedChanged);
            NoEvidancePsycho.CheckedChanged -= new TTControlEventDelegate(NoEvidancePsycho_CheckedChanged);
            Attaches4.CheckedChanged -= new TTControlEventDelegate(Attaches4_CheckedChanged);
            Need.CheckedChanged -= new TTControlEventDelegate(Need_CheckedChanged);
            NoNeed.CheckedChanged -= new TTControlEventDelegate(NoNeed_CheckedChanged);
            ReasonExaminationReportType.SelectedIndexChanged -= new TTControlEventDelegate(ReasonExaminationReportType_SelectedIndexChanged);
            //ForensicReportType.SelectedIndexChanged -= new TTControlEventDelegate(ForensicReportType_SelectedIndexChanged);
            base.UnBindControlEvents();
        }

        private void OtherReasonExamination_TextChanged()
        {
#region ForensicMedicalReportForm_OtherReasonExamination_TextChanged
   //if (ReasonExaminationReportType.Equals("Others"))
            //{
            //    OtherReasonExamination.Enabled = true;
            //}
#endregion ForensicMedicalReportForm_OtherReasonExamination_TextChanged
        }

        private void PsychiatricConsultation_CheckedChanged()
        {
#region ForensicMedicalReportForm_PsychiatricConsultation_CheckedChanged
   if(PsychiatricConsultation.Value==true)
            {
                NoEvidancePsycho.Value=false;
                PyschiatricExamination.Value=false;
            }
#endregion ForensicMedicalReportForm_PsychiatricConsultation_CheckedChanged
        }

        private void PyschiatricExamination_CheckedChanged()
        {
#region ForensicMedicalReportForm_PyschiatricExamination_CheckedChanged
   if(PyschiatricExamination.Value==true)
            {
                NoEvidancePsycho.Value=false;
                PsychiatricConsultation.Value=false;
            }
#endregion ForensicMedicalReportForm_PyschiatricExamination_CheckedChanged
        }

        private void NoEvidancePsycho_CheckedChanged()
        {
#region ForensicMedicalReportForm_NoEvidancePsycho_CheckedChanged
   if(NoEvidancePsycho.Value==true)
            {
                PyschiatricExamination.Value=false;
                PsychiatricConsultation.Value=false;
            }
#endregion ForensicMedicalReportForm_NoEvidancePsycho_CheckedChanged
        }

        private void Attaches4_CheckedChanged()
        {
#region ForensicMedicalReportForm_Attaches4_CheckedChanged
   if (Attaches4.Value == true)
            {
                Attaches5.Enabled=true;
                Attaches5.Required = true;
            }

       else
            {
                Attaches5.Text = null;
                Attaches5.Enabled = false;
                Attaches5.Required = false;

            }
#endregion ForensicMedicalReportForm_Attaches4_CheckedChanged
        }

        private void Need_CheckedChanged()
        {
#region ForensicMedicalReportForm_Need_CheckedChanged
   if (Need.Value == true)
                {
                    ResonOfDispatch.Enabled = true;
                    ResonOfDispatch.Required = true;
                    NoNeed.Value = false;
                }

                else
                {
                    ResonOfDispatch.Text = null;
                    ResonOfDispatch.Enabled = false;
                    ResonOfDispatch.Required = false;
                }
#endregion ForensicMedicalReportForm_Need_CheckedChanged
        }

        private void NoNeed_CheckedChanged()
        {
#region ForensicMedicalReportForm_NoNeed_CheckedChanged
   if (NoNeed.Value == true)
            {
                Need.Value = false;
            }
#endregion ForensicMedicalReportForm_NoNeed_CheckedChanged
        }

        private void ReasonExaminationReportType_SelectedIndexChanged()
        {
#region ForensicMedicalReportForm_ReasonExaminationReportType_SelectedIndexChanged
   if (this._ForensicMedicalReport.ReasonExaminationReportType.Value == ReasonExaminationTypeEnum.Others)
            {
                OtherReasonExamination.Enabled = true;
                OtherReasonExamination.Required = true;
            }
            else 
            {
                OtherReasonExamination.Text=null;
                OtherReasonExamination.Enabled = false;
                OtherReasonExamination.Required = false;
                
           }
#endregion ForensicMedicalReportForm_ReasonExaminationReportType_SelectedIndexChanged
        }

        private void ForensicReportType_SelectedIndexChanged()
        {
#region ForensicMedicalReportForm_ForensicReportType_SelectedIndexChanged
   this.InitializeStateButton();
#endregion ForensicMedicalReportForm_ForensicReportType_SelectedIndexChanged
        }

        protected override void PreScript()
        {
#region ForensicMedicalReportForm_PreScript
    base.PreScript();
    
    OtherReasonExamination.Enabled=false;
    ResonOfDispatch.Enabled=false;
    Attaches5.Enabled=false;
    
    this.InitializeStateButton();
    
            this.SetProcedureDoctorAsCurrentResource();
            if(this._ForensicMedicalReport.CurrentStateDefID != null && this._ForensicMedicalReport.CurrentStateDefID.Value.Equals(ForensicMedicalReport.States.ReportEntry))
            {
                //this.ProtocolNo.Visible = false;
                //this.labelProtocolNo.Visible = false;
                
                //this.labelReportNo.Visible = false;
                //this.ReportNo.Visible = false;
            }
            
//            if(this._ForensicMedicalReport.CurrentStateDefID != null && this._ForensicMedicalReport.CurrentStateDefID.Value.Equals(ForensicMedicalReport.States.Completed))
//            {
//                if(this._ForensicMedicalReport.ForensicMedicalReportType ==ForensicMedicalReportTypeEnum.Uncertain)
//                {
//                    this.DropCurrentStateReport(typeof(TTReportClasses.I_TemporaryForensicReport));
//                }
//                else if(this._ForensicMedicalReport.ForensicMedicalReportType == ForensicMedicalReportTypeEnum.Certain)
//                {
//                    this.DropCurrentStateReport(typeof(TTReportClasses.I_TemporaryForensicReport));
//                }
//                
//            }
            /******************bu kysym silinecek. test amaçly konuldu.******///o halde silindi...YY
            //            if (_ForensicMedicalReport.Episode == null)
            //            {
            //                TTObjectContext con = _ForensicMedicalReport.ObjectContext;
            //                IList episodes = con.QueryObjects("Episode");
            //                if (episodes.Count == 0)
            //                    throw new TTException("Episode bulunamady.");
            //                _ForensicMedicalReport.Episode = (Episode)episodes[0];
            //            }
            /***************************************************************/
            //CopyToE  Episodedaki Evrak Sayısı, Evrak Tarihi ve  Muayeneye Gönderen Makam Class propertylerine atılır
            if (_ForensicMedicalReport.DocumentDate == null)
            {
                _ForensicMedicalReport.DocumentDate = _ForensicMedicalReport.Episode.DocumentDate;
            }
            if ( String.IsNullOrEmpty(_ForensicMedicalReport.DocumentNumber))
            {
                _ForensicMedicalReport.DocumentNumber = _ForensicMedicalReport.Episode.DocumentNumber;
            }
//            if (_ForensicMedicalReport.SenderChair == null)
//            {
//                _ForensicMedicalReport.SenderChair = _ForensicMedicalReport.Episode.SenderChair;
//            }
//todo bg
/*
            if (this._ForensicMedicalReport.SubEpisode.PatientAdmission.AdmissionType.Value == AdmissionTypeEnum.MaterialAdmission)
            {
                this.Report.DisplayText="Materyal Sonuç";
                this.labelMaterialSendDate.Visible=true;
                this.MaterialSendDate.Visible=true;
                this.labelMaterialSender.Visible=true;
                this.MaterialSender.Visible=true;
            }
            else*/
            //{
            //    this.labelMaterialSendDate.Visible=false;
            //    this.MaterialSendDate.Visible=false;
            //    this.labelMaterialSender.Visible=false;
            //    this.MaterialSender.Visible=false;
            //}
            
            //Muayene Buluguları ve Muayene Özeti
            
            if(this._ForensicMedicalReport.Episode != null && this._ForensicMedicalReport.Episode.PhysicalExamination != null)
            {
                this.PropertiesOfLesions.Text = Common.GetTextOfRTFString( this._ForensicMedicalReport.Episode.PhysicalExamination.ToString())+ "\r\n";
            }
            if(this._ForensicMedicalReport.Episode != null && this._ForensicMedicalReport.Episode.ExaminationSummary != null)
            {
                this.PropertiesOfLesions.Text +=Common.GetTextOfRTFString(this._ForensicMedicalReport.Episode.ExaminationSummary.ToString()) +"\r\n";
            }
            
            
            //TETKİKLER
            TTObjectContext context = new TTObjectContext(true);
             Guid EPISODE = new Guid();
                 EPISODE = this._ForensicMedicalReport.Episode.ObjectID;
                 BindingList<TTObjectClasses.LaboratoryProcedure> labProcedureList = LaboratoryProcedure.GetLabProceduresByEpisode(context,EPISODE);
            
            
            if(labProcedureList.Count > 0)
            {
                StringBuilder builder = new StringBuilder();
                foreach (LaboratoryProcedure labProc in labProcedureList)
                {
                    builder.Append(Convert.ToDateTime(labProc.ActionDate).ToShortDateString() + " ");
                    builder.Append(labProc.ProcedureObject.Name + " ");
                    builder.Append("(" + labProc.ProcedureObject.SUTCode+ ") ");
                    if (labProc.Result != null && labProc.Result != "")
                    {
                        builder.Append(":" + labProc.Result + " ");
                        builder.Append(labProc.Unit + " ");
                        if (labProc.Warning != null)
                            builder.Append(TTObjectClasses.Common.GetDisplayTextOfDataTypeEnum(labProc.Warning.Value));
                    }
                    
                    if (labProc.LaboratorySubProcedures.Count > 0)
                    {
                        builder.Append("(");
                        foreach (LaboratorySubProcedure subLabProc in labProc.LaboratorySubProcedures)
                        {
                            builder.Append(subLabProc.ProcedureObject.Name + " ");
                            builder.Append("(" + subLabProc.ProcedureObject.SUTCode + ") ");
                            if (subLabProc.Result != null && subLabProc.Result != "")
                            {
                                builder.Append(":" + subLabProc.Result + " ");
                                builder.Append(subLabProc.Unit + " ");
                                if (subLabProc.Warning != null)
                                    builder.Append(TTObjectClasses.Common.GetDisplayTextOfDataTypeEnum(subLabProc.Warning.Value));
                                builder.Append(",");
                            }
                        }
                        builder.Append(")");
                    }

                    builder.Append(", ");
                }
                this.rtfProcedures.Text = "LABORATUVAR TETKİKLERİ:"+ "\r\n";
                this.rtfProcedures.Text += builder.ToString() + "\r\n";
                         
            }
            this.rtfProcedures.Text += "RADYOLOJİ TETKİKLERİ:" + "\r\n";
            /* BindingList<TTObjectClasses.RadiologyTest> radTestList = RadiologyTest.GetRadTestByEpisode(context,EPISODE);
           
             if(radTestList.Count > 0)
            {               
                StringBuilder builder2 = new StringBuilder();
                foreach (RadiologyTest radTest in radTestList)
                {
                    builder2.Append(Convert.ToDateTime(radTest.ActionDate).ToShortDateString() + " ");
                    builder2.Append(radTest.ProcedureObject.Name + " ");
                    builder2.Append("(" + radTest.ProcedureObject.SUTCode + ")");
                    builder2.Append(", ");
                }
               this.rtfProcedures.Text += builder2.ToString();
            } */
#endregion ForensicMedicalReportForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region ForensicMedicalReportForm_PostScript
    base.PostScript(transDef);
#endregion ForensicMedicalReportForm_PostScript

            }
            
#region ForensicMedicalReportForm_Methods
        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
            base.AfterContextSavedScript(transDef);
            if (transDef != null && transDef.ToStateDefID == ForensicMedicalReport.States.Completed)
            {
                Dictionary<string, TTReportTool.PropertyCache<object>> parameter = new Dictionary<string, TTReportTool.PropertyCache<object>>();
                TTReportTool.PropertyCache<object> objectID = new TTReportTool.PropertyCache<object>();
                objectID.Add("VALUE", this._ForensicMedicalReport.ObjectID.ToString());
                parameter.Add("TTOBJECTID", objectID);
               // if(this._ForensicMedicalReport.ForensicMedicalReportType == ForensicMedicalReportTypeEnum.Uncertain)
                   // TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_TemporaryForensicReport), true, 1, parameter);
               // else if (this._ForensicMedicalReport.ForensicMedicalReportType == ForensicMedicalReportTypeEnum.Certain)
                    //TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_TemporaryForensicReport), true, 1, parameter);
              
               
                   
               //hastanın var olan konsültasyon raporlarının da yazdırlması
                TTObjectContext context =new TTObjectContext(true);
                Guid episode =new Guid();
                episode = this._ForensicMedicalReport.Episode.ObjectID;
                IBindingList consultationProcedures = ConsultationProcedure.GetConsultationProcedureByEpisode(context,episode);
                foreach(ConsultationProcedure cp in consultationProcedures)
                {
                    Dictionary<string, TTReportTool.PropertyCache<object>> parameter2 = new Dictionary<string, TTReportTool.PropertyCache<object>>();
                    TTReportTool.PropertyCache<object> objectID2 = new TTReportTool.PropertyCache<object>();
                    objectID2.Add("VALUE", cp.ObjectID.ToString());
                    parameter2.Add("TTOBJECTID", objectID2);
                    TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_ConsultationProcedureReport),true ,1, parameter2);
                }
                
                
                }
        }
    //Kat-i raporlarda onay stateine, Geçici raporlarda ise tamamla stateine geçer  
    public void InitializeStateButton()
        {
            
            //if(this.ForensicReportType.SelectedItem == null)
            //{
            //    this.DropStateButton(ForensicMedicalReport.States.Completed);
            //        this.DropStateButton(ForensicMedicalReport.States.Approval);
            //}
            //else if (this.ForensicReportType.SelectedItem != null && (int)this.ForensicReportType.SelectedItem.Value == 0 && this._ForensicMedicalReport.CurrentStateDefID != ForensicMedicalReport.States.Approval)
            //{
            //    this.DropStateButton(ForensicMedicalReport.States.Completed);
            //    this.AddStateButton(ForensicMedicalReport.States.Approval);
               
            //}
            //else if(this.ForensicReportType.SelectedItem != null && (int)this.ForensicReportType.SelectedItem.Value == 1)
            //{
            //    this.DropStateButton(ForensicMedicalReport.States.Approval);
            //    this.AddStateButton(ForensicMedicalReport.States.Completed);
            //}
                
        }
        
#endregion ForensicMedicalReportForm_Methods
    }
}
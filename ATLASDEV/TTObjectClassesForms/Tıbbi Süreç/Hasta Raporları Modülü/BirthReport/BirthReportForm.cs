
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
    /// Doğum Raporu
    /// </summary>
    public partial class BirthReportForm : EpisodeActionForm
    {
        override protected void BindControlEvents()
        {
            BirthReportDoctorInfo.CellValueChanged += new TTGridCellEventDelegate(BirthReportDoctorInfo_CellValueChanged);
            ttbuttonSelectBaby.Click += new TTControlEventDelegate(ttbuttonSelectBaby_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            BirthReportDoctorInfo.CellValueChanged -= new TTGridCellEventDelegate(BirthReportDoctorInfo_CellValueChanged);
            ttbuttonSelectBaby.Click -= new TTControlEventDelegate(ttbuttonSelectBaby_Click);
            base.UnBindControlEvents();
        }

        private void BirthReportDoctorInfo_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region BirthReportForm_BirthReportDoctorInfo_CellValueChanged
   if(this.BirthReportDoctorInfo.Columns["Doctor"].Index==columnIndex)
            {
                BirthReportDoctorInfoGrid bRDG=((BirthReportDoctorInfoGrid)((ITTGridRow)BirthReportDoctorInfo.Rows[rowIndex]).TTObject);
                if(bRDG.Doctor!=null)
                {
                    if(bRDG.Doctor.ResourceSpecialities.Count==1)
                    {
                        bRDG.Speciality= bRDG.Doctor.ResourceSpecialities[0].Speciality;
                    }
                    else
                    {
                        foreach(ResourceSpecialityGrid rSpecialityGrid in bRDG.Doctor.ResourceSpecialities)
                        {
                            if(rSpecialityGrid.Speciality!=null && this._BirthReport.ProcedureSpeciality!=null)
                            {
                                if(rSpecialityGrid.Speciality.ObjectID==this._BirthReport.ProcedureSpeciality.ObjectID)
                                   bRDG.Speciality= rSpecialityGrid.Speciality;
                            }
                        }
                        
                    }
                }
                else
                {
                    bRDG.Speciality=null;
                }
            }
#endregion BirthReportForm_BirthReportDoctorInfo_CellValueChanged
        }

        private void ttbuttonSelectBaby_Click()
        {
#region BirthReportForm_ttbuttonSelectBaby_Click
   using(PatientSearchForm theForm = new PatientSearchForm())
            {
                Patient baby = (Patient)theForm.GetSelectedObject();
                this._BirthReport.Baby = baby;
                
                if(baby!=null)
                {
                    Patient p =(Patient)this._BirthReport.ObjectContext.GetObject(baby.ObjectID,typeof(Patient)) ;
                    p.Mother=this._BirthReport.Episode.Patient;
                    p.MotherName=this._BirthReport.Episode.Patient.FullName;
                    this.BabyName.Text = p.Name + " " + p.Surname;
                    //                    this.BirthEpisodeAction.ListFilterExpression = " EPISODE.PATIENT.OBJECTID = '"  + this._BirthReport.Episode.Patient.ObjectID.ToString() + "'";
                    //                    this.BirthEpisodeAction.Enabled=true;
                }
                else
                {
                    this.BabyName.Text = "";
                    //                   this.BirthEpisodeAction.ListFilterExpression = "";
                    //                    this._BirthReport.BirthEpisodeAction=null;
                    //                    this.BirthEpisodeAction.Enabled=false;
                }
                
                
            }
#endregion BirthReportForm_ttbuttonSelectBaby_Click
        }

        protected override void PreScript()
        {
#region BirthReportForm_PreScript
    base.PreScript();
            
            if(this._BirthReport.CurrentStateDefID == null)
                this.ttbuttonSelectBaby.Visible = true;
            
            if(this._BirthReport.CurrentStateDefID != null && this._BirthReport.CurrentStateDefID.Equals(BirthReport.States.ReportEntry))
                this.ttbuttonSelectBaby.Visible = true;
            
            this.SetProcedureDoctorAsCurrentResource();
            
            if(this._BirthReport.Baby!=null){
                //this.BirthEpisodeAction.ListFilterExpression = this.BirthEpisodeAction.ListFilterExpression + " EPISODE.PATIENT.OBJECTID = '"  + _EpisodeAction.Episode.Patient.Mother.ObjectID.ToString()+ "'";
                this.BabyName.Text =this._BirthReport.Baby.FullName;
            }
//            else{
//                this.BirthEpisodeAction.Enabled=false;
//            }
            
           
#endregion BirthReportForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region BirthReportForm_PostScript
    base.PostScript(transDef);
            
//            if(this._BirthReport.Height == null)
//                    throw new Exception("'Boy' alanını giriniz.");
#endregion BirthReportForm_PostScript

            }
            
        protected override void ClientSidePostScript(TTObjectStateTransitionDef transDef)
        {
#region BirthReportForm_ClientSidePostScript
    base.ClientSidePostScript(transDef);
            
            if(transDef != null)
            {
                if(transDef.FromStateDefID.Value.Equals(BirthReport.States.ReportEntry) &&
                   transDef.ToStateDefID.Equals(BirthReport.States.Completed))
                {
                    if(this._BirthReport.BabyStatus != null)
                    {
                        if(this._BirthReport.BabyStatus.Value == BirthReportBabyStatus.Dead)
                            this.FireMorgueAction();
                    }
                    this._BirthReport.IsPatientApprovalFormGiven= this.GetIfPatientApprovalFormIsGiven(this._BirthReport.IsPatientApprovalFormGiven);
                }
            }
#endregion BirthReportForm_ClientSidePostScript

        }

#region BirthReportForm_Methods
        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
            base.AfterContextSavedScript(transDef);
            // Doğum Raporu
            if(transDef != null && transDef.ToStateDefID == BirthReport.States.Completed)
            {
                Dictionary<string, TTReportTool.PropertyCache<object>> parameters = new Dictionary<string, TTReportTool.PropertyCache<object>>();           
                TTReportTool.PropertyCache<object> cache = new TTReportTool.PropertyCache<object>();
                cache.Add("VALUE", this._BirthReport.ObjectID.ToString());
                parameters.Add("TTOBJECTID",cache);
                TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_BirthReportReport), true, 1, parameters);
                
            }
        }
        
#endregion BirthReportForm_Methods

#region BirthReportForm_ClientSideMethods
        private void FireMorgueAction()
        {
            Guid savePointGuid= this._BirthReport.ObjectContext.BeginSavePoint();
            try
            {
                Morgue theAction = new Morgue(this._BirthReport.ObjectContext);
                theAction.StatisticalDeathReason=StatisticalDeathReason.DeadBirth;
                theAction.MasterResource = null;
                theAction.FromResource = this._BirthReport.MasterResource;
                theAction.Episode = this._BirthReport.Episode;
                theAction.CurrentStateDefID = Morgue.States.Request;
                theAction.MasterAction=this._BirthReport;
                theAction.SenderDoctor = this._BirthReport.ProcedureDoctor;
                
                
                TTForm theForm = TTForm.GetEditForm(theAction);
                DialogResult dialogResult=theForm.ShowEdit(this,theAction);
                if(dialogResult!= DialogResult.OK)
                {
                    throw new Exception("Bebeğin Durumu 'Ölü' olarak seçildiğinde Morg isteği yapılması zorunludur.");
                }
            }
            catch (Exception ex)
            {
                this._BirthReport.ObjectContext.RollbackSavePoint(savePointGuid);
                throw ex;
            }
        }
        
        private void FireInpatientAction()
        {
            Guid savePointGuid= this._BirthReport.ObjectContext.BeginSavePoint();
            try
            {
                InpatientAdmission theAction = new InpatientAdmission(this._BirthReport.ObjectContext);
                theAction.ActionDate = Common.RecTime();
                theAction.MasterResource = this._BirthReport.MasterResource;
                theAction.FromResource = this._BirthReport.FromResource;
                theAction.Episode = this._BirthReport.Episode;
                theAction.CurrentStateDefID = InpatientAdmission.States.Request;
                theAction.MasterAction=this._BirthReport;
                theAction.ProcedureDoctor = this._BirthReport.ProcedureDoctor;
                
                TTForm theForm = TTForm.GetEditForm(theAction);
                DialogResult dialogResult=theForm.ShowEdit(this,theAction);
                if(dialogResult!= DialogResult.OK)
                {
                    throw new Exception("Bebeğin Durumu 'Canlı' olarak seçildiğinde Hasta Yatış isteği yapılması zorunludur.");
                }
            }
            catch (Exception ex)
            {
                this._BirthReport.ObjectContext.RollbackSavePoint(savePointGuid);
                throw ex;
            }
        }
        
#endregion BirthReportForm_ClientSideMethods
    }
}
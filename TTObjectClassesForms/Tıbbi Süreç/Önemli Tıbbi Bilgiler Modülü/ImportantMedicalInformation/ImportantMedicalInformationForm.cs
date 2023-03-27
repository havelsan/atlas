
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
    /// Önemli Tıbbi Bilgiler
    /// </summary>
    public partial class ImportantMedicalInformationForm : EpisodeActionForm
    {
        override protected void BindControlEvents()
        {
            ttbutton1.Click += new TTControlEventDelegate(ttbutton1_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            ttbutton1.Click -= new TTControlEventDelegate(ttbutton1_Click);
            base.UnBindControlEvents();
        }

        private void ttbutton1_Click()
        {
        }

        protected override void PreScript()
        {
#region ImportantMedicalInformationForm_PreScript
    this.IfNullSelectFromResource();
            this.IfNullSelectMasterResource();
            if(this._ImportantMedicalInformation.CurrentStateDef != null && this._ImportantMedicalInformation.CurrentStateDef.Status!= StateStatusEnum.Cancelled){
                this.DropStateButton(ImportantMedicalInformation.States.InActive);
            }
//            this.cmdOK.Visible=false;
            
            
            //Hasta erkekse hamile olarak işaretlenmemeli. Ayıptır
            if (_EpisodeAction.Episode.Patient.Sex.ADI == "ERKEK")                
            {
                IsPregnant.ReadOnly = true;
                this._ImportantMedicalInformation.IsPregnant=false;
            }
            
            
            //this.IfNullSelectProcedureSpeciality();
            
            //YAPILACAKLAR//ilk stateler ok basılmadan diğer stepe geçirilebildiğinde kod açılacak.
            
            //            bool isNew;
            //            isNew=false;
//
            //            for (int i=0;i<(this.Controls.Count);i++)
            //            {
            //                if (this.Controls[i].Name.ToString()!="pnlButtons")
            //                {
            //                    for (int k=0; k < (this.Controls[i].Controls.Count);k++)
            //                    {
            //                        if(this.Controls[i].Controls[k].Name.ToString()!= "WarnAllMedicalPersonnel")
            //                        {
            //                            if (this.Controls[i].Controls[k]!=null)
            //                            {
            //                                isNew=false;
            //                            }
            //                        }
            //                    }
            //                }
            //            }
            //            if ( this._ImportantMedicalInformation.DiagnosisHistory.Count>0 ||  this._ImportantMedicalInformation.CancelledDiagnosis.Count>0)
            //            {
            //                isNew=false;
            //            }
//
            //            if (isNew==true;)
            //            {
            //                if (this.Episode.Patient.ImportantMedicalInformation!=null)
            //                {
            //                    this.WarnAllMedicalPersonnel= this.Episode.Patient.ImportantMedicalInformation.WarnAllMedicalPersonnel;
            //                    this.AllergyInformation = this.Episode.Patient.ImportantMedicalInformation.AllergyInformation;
            //                    this.BloodGroup = this.Episode.Patient.ImportantMedicalInformation.BloodGroup;
            //                    this.DrugInformation = this.Episode.Patient.ImportantMedicalInformation.DrugInformation;
            //                    this.IllnessAndOperation = this.Episode.Patient.ImportantMedicalInformation .IllnessAndOperation;
            //                    this.OtherInformation = this.Episode.Patient.ImportantMedicalInformation.OtherInformation;
            //                    lock(this.Episode.Patient.ImportantMedicalInformation.DiagnosisHistory)
            //                    {
            //                        while(this.Episode.Patient.ImportantMedicalInformation.DiagnosisHistory.Count>0)
            //                        {
            //                            this.DiagnosisHistory.Add(this.Episode.Patient.ImportantMedicalInformation.DiagnosisHistory[0]);
            //                        }
            //                    }
            //                    lock(this.Episode.Patient.ImportantMedicalInformation.CancelledDiagnosis)
            //                    {
            //                        while(this.Episode.Patient.ImportantMedicalInformation.CancelledDiagnosis.Count>0)
            //                        {
            //                            this.CancelledDiagnosis.Add(this.Episode.Patient.ImportantMedicalInformation.CancelledDiagnosis[0]);
            //                        }
            //                    }
            //                }
            //            }
#endregion ImportantMedicalInformationForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region ImportantMedicalInformationForm_PostScript
    base.PostScript(transDef);         
            foreach (DiagnosisGrid diagnosisGrid in this._ImportantMedicalInformation.DiagnosisHistory)
            {
                if (diagnosisGrid.AddToHistory==false)
                {
                    ImportantMedicalInformationCancelledDiagnosis cancelledDiagnosis=new ImportantMedicalInformationCancelledDiagnosis(this._ImportantMedicalInformation.ObjectContext);
                    cancelledDiagnosis.CancelledDiagnose=diagnosisGrid.Diagnose;
                    cancelledDiagnosis.CancelDiagnoseUser=Common.CurrentResource;
                    cancelledDiagnosis.CancelledDiagnoseDate=Common.RecTime();
                    cancelledDiagnosis.CancelledDiagnosisGrid=diagnosisGrid;
                    this._ImportantMedicalInformation.CancelledDiagnosis.Add(cancelledDiagnosis);
                }
            }
#endregion ImportantMedicalInformationForm_PostScript

            }
                }
}
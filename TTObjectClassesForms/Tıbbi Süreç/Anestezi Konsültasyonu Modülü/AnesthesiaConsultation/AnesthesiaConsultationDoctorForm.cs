
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
    /// Anestezi Konsültasyonu
    /// </summary>
    public partial class AnesthesiaConsultationDoctorForm : BaseDoctorExaminationForm
    {
        override protected void BindControlEvents()
        {
            btnGroupBox4.Click += new TTControlEventDelegate(btnGroupBox4_Click);
            btnGroupBox3.Click += new TTControlEventDelegate(btnGroupBox3_Click);
            btnGroupBox2.Click += new TTControlEventDelegate(btnGroupBox2_Click);
            btnGroupBox1.Click += new TTControlEventDelegate(btnGroupBox1_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            btnGroupBox4.Click -= new TTControlEventDelegate(btnGroupBox4_Click);
            btnGroupBox3.Click -= new TTControlEventDelegate(btnGroupBox3_Click);
            btnGroupBox2.Click -= new TTControlEventDelegate(btnGroupBox2_Click);
            btnGroupBox1.Click -= new TTControlEventDelegate(btnGroupBox1_Click);
            base.UnBindControlEvents();
        }

        private void btnGroupBox4_Click()
        {
#region AnesthesiaConsultationDoctorForm_btnGroupBox4_Click
   //if(this.GroupBox4.Dock == DockStyle.None)
   //         {
   //             //this.GroupBox4.Dock = DockStyle.Fill;
   //             this.GroupBox1.Visible = false;
   //             this.GroupBox2.Visible = false;
   //             this.GroupBox3.Visible = false;

          

   //             int manipulationGridSizeHeight = GroupBox4.Size.Height - 60 - btnManipulationNewRequest.Size.Height;
   //             ManipulationGrid.Size = new Size(ManipulationGrid.Size.Width, manipulationGridSizeHeight);
                
   //             /* if(this._EpisodeAction.Episode.PatientStatus!=PatientStatusEnum.Outpatient)
   //             {
   //                 int btnNewTreatmentDischargeSizeHeight = GroupBox4.Size.Height - 60  - btnNewForensicMedicalReport.Size.Height - 3;
   //                 btnNewTreatmentDischarge.Size = new Size(btnNewTreatmentDischarge.Size.Width,btnNewTreatmentDischargeSizeHeight);
   //             }*/
   //         }
   //         else if(this.GroupBox4.Dock == DockStyle.Fill)
   //         {
   //             this.GroupBox4.Dock = DockStyle.None;
   //             this.GroupBox1.Visible = true;
   //             this.GroupBox2.Visible = true;
   //             this.GroupBox3.Visible = true;
   //             //SetDefaultLocationAndSize();
   //         }
#endregion AnesthesiaConsultationDoctorForm_btnGroupBox4_Click
        }

        private void btnGroupBox3_Click()
        {
#region AnesthesiaConsultationDoctorForm_btnGroupBox3_Click
//   if(this.GroupBox3.Dock == DockStyle.None)
//            {
//                this.GroupBox3.Dock = DockStyle.Fill;
//                this.GroupBox1.Visible = false;
//                this.GroupBox2.Visible = false;
//                this.GroupBox4.Visible = false;
               

////                int laboratoryResultsGridSizeHeight = GroupBox3.Size.Height - 60 - LabStartDate.Location.Y - LabStartDate.Size.Height - btnLabNewRequest.Size.Height - 10;
////                int laboratoryResultsGridSizeWidth = GroupBox3.Size.Width - 14;
////                LaboratoryResultsGrid.Size = new Size(laboratoryResultsGridSizeWidth, laboratoryResultsGridSizeHeight);

//                int btnConsultationNewRequestLocationY = GroupBox3.Size.Height - 60 - btnConsultationNewRequest.Size.Height;
//                btnConsultationNewRequest.Location = new Point(btnConsultationNewRequest.Location.X, btnConsultationNewRequestLocationY);

//                int btnConsultationNewRequestSizeWidth = (GroupBox3.Size.Width - 14) / 2;
//                btnConsultationNewRequest.Size = new Size(btnConsultationNewRequestSizeWidth, btnConsultationNewRequest.Size.Height);

//                int btnNewConsultationFromOtherHospRequestSizeWidth = (GroupBox3.Size.Width - 14) / 2;
//                btnNewConsultationFromOtherHospRequest.Size = new Size(btnNewConsultationFromOtherHospRequestSizeWidth, btnNewConsultationFromOtherHospRequest.Size.Height);

//                int btnNewConsultationFromOtherHospRequestLocationX = btnConsultationNewRequest.Size.Width;
//                int btnNewConsultationFromOtherHospRequestLocationY = btnConsultationNewRequest.Location.Y;
//                btnNewConsultationFromOtherHospRequest.Location = new Point(btnNewConsultationFromOtherHospRequestLocationX, btnNewConsultationFromOtherHospRequestLocationY);

//                int consultationGridSizeHeight = GroupBox3.Size.Height - 60 - btnConsultationNewRequest.Size.Height;
//                ConsultationGrid.Size = new Size(ConsultationGrid.Size.Width, consultationGridSizeHeight);
                
//                int oldPhysicialExaminationsGridSizeHeight = (this.GroupBox3.Size.Height - 60) / 2 - 5;
//                OldPhysicialExaminationsGrid.Size = new Size(OldPhysicialExaminationsGrid.Size.Width, oldPhysicialExaminationsGridSizeHeight);

//                int consultationResultSizeHeight = (this.GroupBox3.Size.Height - 60) / 2 - 5;
//                ConsultationResult.Size = new Size(ConsultationResult.Size.Width, consultationResultSizeHeight);
                
//                int consultationRequestNote= (this.GroupBox3.Size.Height - this.AnesthesiaTechniqueGrid.Size.Height - this.AnesthesiaTechniqueGrid.Location.Y - 60) ;
//                ConsultationRequestNote.Size=new Size(ConsultationResult.Size.Width,consultationRequestNote);
//            }
//            else if(this.GroupBox3.Dock == DockStyle.Fill)
//            {
//                this.GroupBox3.Dock = DockStyle.None;
//                this.GroupBox1.Visible = true;
//                this.GroupBox2.Visible = true;
//                this.GroupBox4.Visible = true;
//                //SetDefaultLocationAndSize();
//            }
#endregion AnesthesiaConsultationDoctorForm_btnGroupBox3_Click
        }

        private void btnGroupBox2_Click()
        {
#region AnesthesiaConsultationDoctorForm_btnGroupBox2_Click
   //if(this.GroupBox2.Dock == DockStyle.None)
   //         {
   //             this.GroupBox2.Dock = DockStyle.Fill;
   //             this.GroupBox1.Visible = false;
   //             this.GroupBox3.Visible = false;
   //             this.GroupBox4.Visible = false;
   //         }
   //         else if(this.GroupBox2.Dock == DockStyle.Fill)
   //         {
   //             this.GroupBox2.Dock = DockStyle.None;
   //             this.GroupBox1.Visible = true;
   //             this.GroupBox3.Visible = true;
   //             this.GroupBox4.Visible = true;
   //         }
#endregion AnesthesiaConsultationDoctorForm_btnGroupBox2_Click
        }

        private void btnGroupBox1_Click()
        {
#region AnesthesiaConsultationDoctorForm_btnGroupBox1_Click
   //if(this.GroupBox1.Dock == DockStyle.None)
   //         {
   //             //this.GroupBox1.Dock = DockStyle.Fill;
   //             this.GroupBox2.Visible = false;
   //             this.GroupBox3.Visible = false;
   //             this.GroupBox4.Visible = false;
   //             int importantPatientInfoSizeWidth = GroupBox1.Size.Width - 10;
   //             int importantPatientInfoSizeHeight = GroupBox1.Size.Height - labelImportantInfo.Location.Y - labelImportantInfo.Size.Height - btnImportantMedicalInfo.Size.Height-10;
   //             ImportantPatientInfo.Size = new Size(importantPatientInfoSizeWidth, importantPatientInfoSizeHeight);
   //         }
   //         else if(this.GroupBox1.Dock == DockStyle.Fill)
   //         {
   //             this.GroupBox1.Dock = DockStyle.None;
   //             this.GroupBox2.Visible = true;
   //             this.GroupBox3.Visible = true;
   //             this.GroupBox4.Visible = true;
   //             //SetDefaultLocationAndSize();
   //         }
#endregion AnesthesiaConsultationDoctorForm_btnGroupBox1_Click
        }

        protected override void PreScript()
        {
#region AnesthesiaConsultationDoctorForm_PreScript
    base.PreScript();
            this.SetProcedureDoctorAsCurrentResource();
            //SetStaticValuesOfLocationAndSize();
            #endregion AnesthesiaConsultationDoctorForm_PreScript

        }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region AnesthesiaConsultationDoctorForm_PostScript
    base.PostScript(transDef);
            if(transDef!=null)
            {
                if(transDef.ToStateDef.Status!=StateStatusEnum.Cancelled)
                {
                    if (String.IsNullOrEmpty(this.ConsultationResult.Text))
                    {
                        string[] hataParamList = new string[] { "'Anestezi Konsültasyon Bulguları'" };
                        throw new TTUtils.TTException(SystemMessage.GetMessageV3(95, hataParamList));
                        //throw new Exception("'Anestezi Konsültasyon Bulguları' alanı boş geçilemez");
                    }
                    if (this._AnesthesiaConsultation.AnesthesiaTechniques.Count < 1)
                    {
                        string[] hataParamList = new string[] { "'Öngörülen Anestezi Teknikleri'" };
                        throw new TTUtils.TTException(SystemMessage.GetMessageV3(95, hataParamList));
                        //throw new Exception("'Öngörülen Anestezi Teknikleri' alanı boş geçilemez");
                    }
                    this._AnesthesiaConsultation.IsPatientApprovalFormGiven= this.GetIfPatientApprovalFormIsGiven(this._AnesthesiaConsultation.IsPatientApprovalFormGiven);
                    if (this._AnesthesiaConsultation.ProcessDate == null)
                        this._AnesthesiaConsultation.ProcessDate = Common.RecTime();
                    
                    if(this._AnesthesiaConsultation.ProcedureDoctor == null)
                    {
                        throw new Exception("Konsültasyonu Yapan Doktoru Seçmeniz Gerekmektedir!");
                    }
                }
            }
            
            if(transDef == null || (transDef != null && transDef.ToStateDefID != AnesthesiaConsultation.States.Cancelled))
            {
//                foreach(AnesthesiaConsultationProcedure anesthesiaConsultationProcedure in this._AnesthesiaConsultation.AnesthesiaConsultationProcedures)
//                {
//                    anesthesiaConsultationProcedure.SetPerformedDate();
//                }
            }
#endregion AnesthesiaConsultationDoctorForm_PostScript

            }
            
#region AnesthesiaConsultationDoctorForm_Methods
        //private static Size OldPhysicialExaminationsGridSize;
        //private static Size ConsultationResultSize;
        //private static Size ImportantPatientInfoSize;
        //private static Size LaboratoryResultsGridSize;
        //private static Point BtnConsultationNewRequestLocation;
        //private static Size BtnConsultationNewRequestSize;
        //private static Point BtnNewConsultationFromOtherHospRequestLocation;
        //private static Size BtnNewConsultationFromOtherHospRequestSize;
        //private static Size ConsultationGridSize;
        //private static Size ManipulationGridSize;
        ////private static Size btnNewTreatmentDischargeSize;
        //private static Size consultationRequestNoteSize;
        //private void SetStaticValuesOfLocationAndSize()
        //{
        //    OldPhysicialExaminationsGridSize = OldPhysicialExaminationsGrid.Size;
        //    ConsultationResultSize = ConsultationResult.Size;
        //    ImportantPatientInfoSize = ImportantPatientInfo.Size;
        //    LaboratoryResultsGridSize = LaboratoryResultsGrid.Size;
        //    BtnConsultationNewRequestLocation = btnConsultationNewRequest.Location;
        //    BtnConsultationNewRequestSize = btnConsultationNewRequest.Size;
        //    BtnNewConsultationFromOtherHospRequestLocation = btnNewConsultationFromOtherHospRequest.Location;
        //    BtnNewConsultationFromOtherHospRequestSize = btnNewConsultationFromOtherHospRequest.Size;
        //    ConsultationGridSize = ConsultationGrid.Size;
        //    ManipulationGridSize = ManipulationGrid.Size; 
        //    consultationRequestNoteSize = ConsultationRequestNote.Size;
        //}
        //private void SetDefaultLocationAndSize()
        //{
        //    OldPhysicialExaminationsGrid.Size = OldPhysicialExaminationsGridSize;
        //    ConsultationResult.Size = ConsultationResultSize;
        //    ImportantPatientInfo.Size = ImportantPatientInfoSize;
        //    LaboratoryResultsGrid.Size = LaboratoryResultsGridSize;
        //    btnConsultationNewRequest.Location = BtnConsultationNewRequestLocation;
        //    btnConsultationNewRequest.Size = BtnConsultationNewRequestSize;
        //    btnNewConsultationFromOtherHospRequest.Location = BtnNewConsultationFromOtherHospRequestLocation;
        //    btnNewConsultationFromOtherHospRequest.Size = BtnNewConsultationFromOtherHospRequestSize;
        //    ConsultationGrid.Size = ConsultationGridSize;
        //    ManipulationGrid.Size = ManipulationGridSize;
        //    ConsultationRequestNote.Size = consultationRequestNoteSize;
        //}
        
#endregion AnesthesiaConsultationDoctorForm_Methods
    }
}
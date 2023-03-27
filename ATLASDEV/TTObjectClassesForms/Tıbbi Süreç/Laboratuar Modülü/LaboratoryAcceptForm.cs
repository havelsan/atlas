
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
    /// Laboratuvar Kabul (Numune Alma)
    /// </summary>
    public partial class LaboratoryAcceptForm : TTUnboundForm
    {
        override protected void BindControlEvents()
        {
            ttbutton2.Click += new TTControlEventDelegate(ttbutton2_Click);
            ButtonAccept.Click += new TTControlEventDelegate(ButtonAccept_Click);
            LaboratoryAcceptTemplateList.SelectedObjectChanged += new TTControlEventDelegate(LaboratoryAcceptTemplateList_SelectedObjectChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            ttbutton2.Click -= new TTControlEventDelegate(ttbutton2_Click);
            ButtonAccept.Click -= new TTControlEventDelegate(ButtonAccept_Click);
            LaboratoryAcceptTemplateList.SelectedObjectChanged -= new TTControlEventDelegate(LaboratoryAcceptTemplateList_SelectedObjectChanged);
            base.UnBindControlEvents();
        }

        private void ttbutton2_Click()
        {
#region LaboratoryAcceptForm_ttbutton2_Click
   /*
             Barcode u girilen ya da okutulan testler icin XLABSubaction dan action ve episode a giderek hasta bilgileri ve calisan bolum 
             bilgilerini dolduruyor. XLABRequest (Laborativar Istek yaptiktan sonra doluyor bu tablo) tablosundan tetkigi isteyen birim cekiliyor.
             Sorgudan donen tetkigin subaction kaydi XLABAccept tablosunda varsa kabul butonu disable oluyor, yoksa True oluyor.
             
             Kabul butonuna basinca XLABAccept tablosunda kayit insert ediliyor.
             
             */
            /*
            if (this.Barcode.ControlValue ==  null)
                throw new Exception("Barcode numarası girmelisiniz!");
            if (this.LaboratoryResDepartment.SelectedObject == null)
                throw new Exception("Kullanıcı Bölüm Adı girmelisiniz!");
            if (this.TestTubeDefinition.SelectedObject == null)
                throw new Exception("Örnek Tüp Adı girmelisiniz!");
            
            int  i = 1;
            bool enableAcceptButon = false;
            ((TTButton)this.ButtonAccept).Enabled = false;
            ((TTGrid)this.GridRequestedTests).VirtualMode = false;
            ((TTGrid)this.GridRequestedTests).Rows.Clear();
           
            TTObjectContext myContext = new TTObjectContext(false);
            IList labSubActionList = LaboratoryProcedure.GetLaboratoryProcedureForLaboratoryAccept(myContext, Convert.ToInt64(this.Barcode.ControlValue), this.LaboratoryResDepartment.SelectedObjectID.ToString(), this.TestTubeDefinition.SelectedObjectID.ToString());
            foreach (LaboratoryProcedure labProc in labSubActionList)
            {
                this.PatientName.ControlValue = labProc.EpisodeAction.Episode.Patient.FullName;
                this.PatientUniqueRefNo.ControlValue = labProc.EpisodeAction.Episode.Patient.UniqueRefNo;
                this.PatientSex.ControlValue  = labProc.EpisodeAction.Episode.Patient.Sex.Value;
                this.PatientStatus.ControlValue = labProc.EpisodeAction.Episode.PatientStatus.Value;
                this.AgeYear.ControlValue = labProc.EpisodeAction.Episode.Patient.AgeByYearByMonthByDay();
                if (labProc.EpisodeAction.Episode.PatientStatus != PatientStatusEnum.Outpatient)
                {
                    this.PatientClinicPoliclinic.ControlValue = labProc.EpisodeAction.Episode.TreatmentClinic.Name;
                    this.PatientRoom.ControlValue = labProc.EpisodeAction.Episode.Room.Name;
                }
                else
                    this.PatientClinicPoliclinic.ControlValue = labProc.EpisodeAction.SubEpisode.PatientAdmission.ResourcesToBeReferred[0].Resource.Name;

                ((TTGrid)this.GridRequestedTests).Rows.Add( new object[] {i, labProc.EpisodeAction.MasterResource.Name, labProc.ProcedureObject, labProc.RequestResource.Name, labProc.ObjectID});
                i = i+1;
                if (labProc.AcceptDate == null && labProc.AcceptUser == null)
                    enableAcceptButon = true;
                else
                    enableAcceptButon = false;
            }
            
            if (enableAcceptButon == true)
                ((TTButton)this.ButtonAccept).Enabled = true;
            */
#endregion LaboratoryAcceptForm_ttbutton2_Click
        }

        private void ButtonAccept_Click()
        {
#region LaboratoryAcceptForm_ButtonAccept_Click
   TTObjectContext myContext = new TTObjectContext(false);
            for(int i = 0; i< ((TTGrid)this.GridRequestedTests).Rows.Count - 1; i++)
            {
                LaboratoryProcedure labProc = (LaboratoryProcedure)LaboratoryProcedure.GetByObjectID(myContext, ((TTGrid)this.GridRequestedTests).Rows[i].Cells[4].Value.ToString())[0];
                labProc.AcceptDate = Common.RecTime();
                labProc.AcceptResource = (Resource)this.LaboratoryResDepartment.SelectedObject;
                labProc.AcceptUser = Common.CurrentResource;
            }
            myContext.Update();
#endregion LaboratoryAcceptForm_ButtonAccept_Click
        }

        private void LaboratoryAcceptTemplateList_SelectedObjectChanged()
        {
#region LaboratoryAcceptForm_LaboratoryAcceptTemplateList_SelectedObjectChanged
   this.TestTubeDefinition.ControlValue = null;
            this.LaboratoryResDepartment.ControlValue = null;

            LaboratoryAcceptTemplateDefinition myTemplate = (LaboratoryAcceptTemplateDefinition)this.LaboratoryAcceptTemplateList.SelectedObject;
            if (myTemplate != null)
            {
                this.TestTubeDefinition.ControlValue  = myTemplate.LaboratoryTestTubeDefinition.ObjectID;
                foreach (LaboratoryAcceptTemplateDetail templateDetail in myTemplate.LaboratoryAcceptTemplateDetails)
                {
                    //Selected Resource bulup cıkacak
                    if (templateDetail.SelectResource == true)
                    {
                        this.LaboratoryResDepartment.ControlValue = templateDetail.LaboratoryUnit.ObjectID; 
                        break;
                    }
                }
            }
#endregion LaboratoryAcceptForm_LaboratoryAcceptTemplateList_SelectedObjectChanged
        }
    }
}
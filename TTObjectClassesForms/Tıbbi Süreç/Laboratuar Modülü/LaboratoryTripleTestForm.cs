
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
    /// Triple Test İstek Formu
    /// </summary>
    public partial class LaboratoryTripleTestForm : TTUnboundForm
    {
        override protected void BindControlEvents()
        {
            ttSave.Click += new TTControlEventDelegate(ttSave_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            ttSave.Click -= new TTControlEventDelegate(ttSave_Click);
            base.UnBindControlEvents();
        }

        private void ttSave_Click()
        {
#region LaboratoryTripleTestForm_ttSave_Click
   LaboratoryRequest labRequest = (LaboratoryRequest)this.Tag;
            LaboratoryTripleTestInfo tripleTestInfo = new LaboratoryTripleTestInfo(labRequest.ObjectContext);
            
            try
            {
                tripleTestInfo.PatientName = this.ttPatientName.Text;
                tripleTestInfo.PatientSurname = this.ttPatientSurname.Text;
                tripleTestInfo.PatientBirthPlace = this.ttPatientBirthPlace.Text;
                tripleTestInfo.PatientBirthDate = Convert.ToDateTime(this.ttPatientBirthDate.Text);
                tripleTestInfo.PatientPhoneNumber = this.ttPatientPhoneNumber.Text;
                tripleTestInfo.PatientWeight = Convert.ToInt32(this.ttPatientWeight.Text);
                
                if (((TTVisual.TTCheckBox)(this.ttIsHaveDiabetes)).Checked)
                {
                    tripleTestInfo.IsHaveDiabetes = true;
                }
                else
                {
                    tripleTestInfo.IsHaveDiabetes = false;
                }
                
                if (((TTVisual.TTCheckBox)(this.ttSmoking)).Checked)
                {
                    tripleTestInfo.Smoking = true;
                }
                else
                {
                    tripleTestInfo.Smoking = false;
                }
                
                if (((TTVisual.TTCheckBox)(this.ttSmoking)).Checked)
                {
                    tripleTestInfo.Smoking = true;
                }
                else
                {
                    tripleTestInfo.Smoking = false;
                }
                
                tripleTestInfo.SmokingNumberPerADay = Convert.ToInt32(this.ttSmokingNumberPerADay.Text);
                
                tripleTestInfo.LastMenstrualDate = Convert.ToDateTime(this.ttLastMenstrualDate.Text);
                
                tripleTestInfo.CycleLength = Convert.ToInt32(this.ttCycleLength.Text);
                
                tripleTestInfo.UltrasoundDate = Convert.ToDateTime(this.ttUltrasoundDate.Text);
                
                tripleTestInfo.GestationalAge = Convert.ToInt32(this.ttGestationalAge.Text);
                
                tripleTestInfo.BiparietalDiameter = Convert.ToInt32(this.ttBiparietalDiameter.Text);
                
                labRequest.LaboratoryTripleTestInfo = tripleTestInfo;
                
                this.Close();
                
            }
            catch(Exception ex)
            {
                throw new Exception("Bilgiler kaydedilirken bir hata oluştu! Eksik veya yanlış veri girişi yapılmadığından emin olduktan sonra tekrar deneyiniz.", ex);
            }
#endregion LaboratoryTripleTestForm_ttSave_Click
        }

#region LaboratoryTripleTestForm_Methods
        public LaboratoryTripleTestForm(LaboratoryRequest labRequest)
            : this()
        {
            this.Tag = labRequest;

            ttPatientName.Text = labRequest.Episode.Patient.Name;
            ttPatientSurname.Text = labRequest.Episode.Patient.Surname;
            ttPatientBirthDate.Text = labRequest.Episode.Patient.BirthDate.ToString();
         //   ttPatientBirthPlace.Text = labRequest.Episode.Patient.TownOfBirth.Name +" / "+ labRequest.Episode.Patient.CityOfBirth.Name;
        }
        

        public LaboratoryTripleTestForm(LaboratoryRequest labRequest,LaboratoryTripleTestInfo tripleTestInfo) : this()
        {
            this.Tag = labRequest;
            ttPatientName.Text = tripleTestInfo.PatientName;
            ttPatientSurname.Text = tripleTestInfo.PatientSurname;
            ttPatientBirthPlace.Text = tripleTestInfo.PatientBirthPlace;
            ttPatientBirthDate.Text = tripleTestInfo.PatientBirthDate.ToString();
            ttPatientPhoneNumber.Text = tripleTestInfo.PatientPhoneNumber;
            ttPatientWeight.Text = tripleTestInfo.PatientWeight.ToString();
            
            if((bool)tripleTestInfo.IsHaveDiabetes)
            {
               ((TTVisual.TTCheckBox)(this.ttIsHaveDiabetes)).Checked = true;
            }
            
            if((bool)tripleTestInfo.Smoking)
            {
               ((TTVisual.TTCheckBox)(this.ttSmoking)).Checked = true;
            }
            
            ttSmokingNumberPerADay.Text = tripleTestInfo.SmokingNumberPerADay.ToString();
            ttLastMenstrualDate.Text = tripleTestInfo.LastMenstrualDate.ToString();
            ttCycleLength.Text = tripleTestInfo.CycleLength.ToString();
            ttUltrasoundDate.Text = tripleTestInfo.UltrasoundDate.ToString();
            ttGestationalAge.Text = tripleTestInfo.GestationalAge.ToString();
            ttBiparietalDiameter.Text = tripleTestInfo.BiparietalDiameter.ToString();
        }
        
#endregion LaboratoryTripleTestForm_Methods
    }
}
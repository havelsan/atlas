
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
    /// İKİLİ TARAMA
    /// </summary>
    public partial class LaboratoryBinaryScanForm : TTUnboundForm
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
#region LaboratoryBinaryScanForm_ttSave_Click
   LaboratoryRequest labRequest = (LaboratoryRequest)this.Tag;
            
            LaboratoryBinaryScanInfo binaryScanInfo = new LaboratoryBinaryScanInfo(labRequest.ObjectContext);

            try
            {

                binaryScanInfo.PatientName = this.ttPatientName.Text;
                binaryScanInfo.PatientSurname = this.ttPatientSurname.Text;
                binaryScanInfo.PatientBirthDate = Convert.ToDateTime(this.ttPatientBirthDate.Text);
                binaryScanInfo.PatientPhoneNumber = this.ttPhoneNumber.Text;


                if (((TTVisual.TTCheckBox)(this.ttTwinPregnancy)).Checked)
                {
                    binaryScanInfo.TwinPregnancy = true;
                }
                else
                {
                    binaryScanInfo.TwinPregnancy = false;
                }


                if (((TTVisual.TTCheckBox)(this.ttIVF)).Checked)
                {
                    binaryScanInfo.Ivf = true;
                }
                else
                {
                    binaryScanInfo.Ivf = false;
                }

                if (((TTVisual.TTCheckBox)(this.ttNasalBone)).Checked)
                {
                    binaryScanInfo.NasalBone = true;
                }
                else
                {
                    binaryScanInfo.NasalBone = false;
                }

                if (((TTVisual.TTCheckBox)(this.ttAbnormalitiesOnUltrasound)).Checked)
                {
                    binaryScanInfo.AbnormalitiesOnUltrasound = true;
                }
                else
                {
                    binaryScanInfo.AbnormalitiesOnUltrasound = false;
                }

                if (((TTVisual.TTCheckBox)(this.ttSmoking)).Checked)
                {
                    binaryScanInfo.Smoking = true;
                }
                else
                {
                    binaryScanInfo.Smoking = false;
                }

                if (((TTVisual.TTCheckBox)(this.ttInsulinDependentDiabetes)).Checked)
                {
                    binaryScanInfo.InsulinDependentDiabetes = true;
                }
                else
                {
                    binaryScanInfo.InsulinDependentDiabetes = false;
                }


                binaryScanInfo.MaternalWeight = Convert.ToInt32(this.ttMaternalWeight.Text);
                binaryScanInfo.NuchalTranslucencyMeasurement = Convert.ToDouble(this.ttNuchalTranslucency.Text);
                binaryScanInfo.SerumReceiptDate = Convert.ToDateTime(this.ttSerumReceiptDate.Text);
                binaryScanInfo.LastMenstrualDate = Convert.ToDateTime(this.ttLastMenstrualDate.Text);
                binaryScanInfo.UltrasoundDate = Convert.ToDateTime(this.ttUltrasoundDate.Text);
                binaryScanInfo.CrlMeasurement = Convert.ToInt32(this.ttCrlMeasurement.Text);


                labRequest.LaboratoryBinaryScanInfo = binaryScanInfo;

                this.Close();

            }
            catch (Exception ex)
            {
                throw new Exception("Bilgiler kaydedilirken bir hata oluştu! Eksik veya yanlış veri girişi yapılmadığından emin olduktan sonra tekrar deneyiniz.", ex);
            }
#endregion LaboratoryBinaryScanForm_ttSave_Click
        }

#region LaboratoryBinaryScanForm_Methods
        public LaboratoryBinaryScanForm(LaboratoryRequest labRequest) : this()
        {
            this.Tag = labRequest;
            
            ttPatientName.Text = labRequest.Episode.Patient.Name;
            ttPatientSurname.Text = labRequest.Episode.Patient.Surname;
            ttPatientBirthDate.Text = labRequest.Episode.Patient.BirthDate.ToString();
        }
        
        public LaboratoryBinaryScanForm(LaboratoryRequest labRequest,LaboratoryBinaryScanInfo binaryScanInfo) : this()
        {
            this.Tag = labRequest;
            ttPatientName.Text = binaryScanInfo.PatientName;
            ttPatientSurname.Text = binaryScanInfo.PatientSurname;
            ttPatientBirthDate.Text = binaryScanInfo.PatientBirthDate.ToString();
            ttPhoneNumber.Text = binaryScanInfo.PatientPhoneNumber;
            ttSerumReceiptDate.Text = binaryScanInfo.SerumReceiptDate.ToString();
            ttLastMenstrualDate.Text = binaryScanInfo.LastMenstrualDate.ToString();
            ttUltrasoundDate.Text = binaryScanInfo.UltrasoundDate.ToString();
            ttCrlMeasurement.Text = binaryScanInfo.CrlMeasurement.ToString();
            ttNuchalTranslucency.Text = binaryScanInfo.NuchalTranslucencyMeasurement.ToString();
            
            ttMaternalWeight.Text = binaryScanInfo.MaternalWeight.ToString();
            
            if((bool)binaryScanInfo.AbnormalitiesOnUltrasound)
            {
               ((TTVisual.TTCheckBox)(this.ttAbnormalitiesOnUltrasound)).Checked = true;
            }
            
            if((bool)binaryScanInfo.NasalBone)
            {
                ((TTVisual.TTCheckBox)(this.ttNasalBone)).Checked = true;
            }
            
            
            if((bool)binaryScanInfo.Smoking)
            {
                ((TTVisual.TTCheckBox)(this.ttSmoking)).Checked = true;
            }
            
            if((bool)binaryScanInfo.InsulinDependentDiabetes)
            {
                ((TTVisual.TTCheckBox)(this.ttInsulinDependentDiabetes)).Checked = true;
            }
            
            if((bool)binaryScanInfo.Ivf)
            {
                ((TTVisual.TTCheckBox)(this.ttIVF)).Checked = true;
            }
            
            if((bool)binaryScanInfo.TwinPregnancy)
            {
                ((TTVisual.TTCheckBox)(this.ttTwinPregnancy)).Checked = true;
            }
        }
        
#endregion LaboratoryBinaryScanForm_Methods
    }
}
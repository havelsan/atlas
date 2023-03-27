
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
    /// E-İmzalı Reçete Detayı
    /// </summary>
    public partial class DigitalPrescriptionForm : TTUnboundForm
    {
        override protected void BindControlEvents()
        {
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            base.UnBindControlEvents();
        }

#region DigitalPrescriptionForm_Methods
        public DigitalPrescriptionForm(OutPatientPrescription outPatientPrescription)
            : this()
        {
            if (outPatientPrescription.SignedData != null)
            {
                Prescription.DigitalSignedPrescription digitalSignedPrescription = TTUtils.SerializationHelper.DeserializeObject((byte[])outPatientPrescription.SignedData) as Prescription.DigitalSignedPrescription;
                if (digitalSignedPrescription != null)
                {
                    Prescription.DigitalPrescription existDigitalPrescription = new Prescription.DigitalPrescription(outPatientPrescription);
                    ExistFillingDate.Text = existDigitalPrescription.FillingDate.Date.ToString();
                    ExistPrescriptionNO.Text = existDigitalPrescription.PrescriptionNO;
                    ExistPrescriptionType.SelectedItem = ExistPrescriptionType.Items[existDigitalPrescription.PrescriptionType];
                    ExistProcedureDoctor.SelectedObjectID = existDigitalPrescription.ProcedureDoctorID;

                    foreach (Prescription.DigitalPrescriptionDetail digitalPrescriptionDetail in existDigitalPrescription.DigitalPrescriptionDetails)
                    {
                        ITTGridRow newRow = ExistPrescriptionGrid.Rows.Add();
                        newRow.Cells[ExistDrug.Name].Value = digitalPrescriptionDetail.DrugID;
                        newRow.Cells[ExistFrequency.Name].Value = digitalPrescriptionDetail.Frequency;
                        newRow.Cells[ExistDoseAmount.Name].Value = digitalPrescriptionDetail.DoseAmount;
                        newRow.Cells[ExistDay.Name].Value = digitalPrescriptionDetail.Day;
                    }

                    Prescription.DigitalPrescription signedDigitalPrescription = digitalSignedPrescription.DigitalPrescription;
                    SignedFillingDate.Text = signedDigitalPrescription.FillingDate.Date.ToString();
                    SignedPrescriptionNO.Text = signedDigitalPrescription.PrescriptionNO;
                    SignedPrescriptionType.SelectedItem = SignedPrescriptionType.Items[signedDigitalPrescription.PrescriptionType];;
                    SignedProcedureDoctor.SelectedObjectID = signedDigitalPrescription.ProcedureDoctorID;

                    foreach (Prescription.DigitalPrescriptionDetail digitalPrescriptionDetail in signedDigitalPrescription.DigitalPrescriptionDetails)
                    {
                        ITTGridRow newRow = SignedPrescriptionGrid.Rows.Add();
                        newRow.Cells[SignedDrug.Name].Value = digitalPrescriptionDetail.DrugID;
                        newRow.Cells[SignedFrequency.Name].Value =  digitalPrescriptionDetail.Frequency;
                        newRow.Cells[SignedDoseAmount.Name].Value = digitalPrescriptionDetail.DoseAmount;
                        newRow.Cells[SignedDay.Name].Value = digitalPrescriptionDetail.Day;
                    }
                }
            }


        }
        
#endregion DigitalPrescriptionForm_Methods
    }
}

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
    /// Nükleer Tıp Hazırlık Formu
    /// </summary>
    public partial class NuclearMedicinePreparationForm : EpisodeActionForm
    {
        override protected void BindControlEvents()
        {
            cmdPrintBarcode.Click += new TTControlEventDelegate(cmdPrintBarcode_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            cmdPrintBarcode.Click -= new TTControlEventDelegate(cmdPrintBarcode_Click);
            base.UnBindControlEvents();
        }

        private void cmdPrintBarcode_Click()
        {
            /*
#region NuclearMedicinePreparationForm_cmdPrintBarcode_Click
            NuclearMedicine.PrintNuclearBarcode(this._NuclearMedicine);
#endregion NuclearMedicinePreparationForm_cmdPrintBarcode_Click */
        }

        protected override void PreScript()
        {
#region NuclearMedicinePreparationForm_PreScript
    base.PreScript();
            this.DropStateButton(NuclearMedicine.States.AdmissionAppointment);
            
            if (this._NuclearMedicine.NuclearMedicineTests.Count > 0)
            {
                if (this._NuclearMedicine.NuclearMedicineTests[0].ProcedureObject != null)
                {
                    nucMedSelectedTesttxt.Text = this._NuclearMedicine.NuclearMedicineTests[0].ProcedureObject.Name;
                }
            }
            this.SetTreatmentMaterialListFilter((TTObjectDef)TTObjectDefManager.Instance.ObjectDefs[typeof(NucMedTreatmentMat).Name], (ITTGridColumn)this.GridNuclearMedicineMaterial.Columns["Material"]);
            this.SetTreatmentMaterialListFilter((TTObjectDef)TTObjectDefManager.Instance.ObjectDefs[typeof(NucMedRadPharmMatGrid).Name], (ITTGridColumn)this.GridRadPharmMaterials.Columns["PharmMaterial"]);
#endregion NuclearMedicinePreparationForm_PreScript

            }
                }
}
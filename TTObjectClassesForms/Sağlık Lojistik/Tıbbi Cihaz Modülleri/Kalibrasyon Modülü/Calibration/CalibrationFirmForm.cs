
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
    /// Kalibrasyon (Firma)
    /// </summary>
    public partial class CalibrationFirmForm : CalibrationBaseForm
    {
        override protected void BindControlEvents()
        {
            NotCalibration.CheckedChanged += new TTControlEventDelegate(NotCalibration_CheckedChanged);
            cmdSupplierDef.Click += new TTControlEventDelegate(cmdSupplierDef_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            NotCalibration.CheckedChanged -= new TTControlEventDelegate(NotCalibration_CheckedChanged);
            cmdSupplierDef.Click -= new TTControlEventDelegate(cmdSupplierDef_Click);
            base.UnBindControlEvents();
        }

        private void NotCalibration_CheckedChanged()
        {
#region CalibrationFirmForm_NotCalibration_CheckedChanged
   if ((bool)this.NotCalibration.Value)
            {
                this.CalibrationTests.Required = false;
            }
#endregion CalibrationFirmForm_NotCalibration_CheckedChanged
        }

        private void cmdSupplierDef_Click()
        {
#region CalibrationFirmForm_cmdSupplierDef_Click
   if (_Calibration.Supplier != null)
            {
                Supplier sup = (Supplier)_Calibration.Supplier;
                TTListDef listDef = TTObjectDefManager.Instance.ListDefs["SupplierDefFormList"];
                TTDefinitionForm frm = TTDefinitionForm.GetEditForm(listDef);
                frm.ShowReadOnly(this.FindForm(), listDef, sup);

            }
            else
            {
                InfoBox.Show("Firma Seçmediniz");
            }
#endregion CalibrationFirmForm_cmdSupplierDef_Click
        }

        protected override void PreScript()
        {
#region CalibrationFirmForm_PreScript
    base.PreScript();
            this.txtLast.Text = "Kesilmedi.";
            bool comp = false;
            if (_Calibration.Demand != null)
            {
                this.txtDemandNo.Text = _Calibration.Demand.RequestNo.Value.ToString();
                this.txtDemand.Text = _Calibration.Demand.CurrentStateDef.DisplayText.ToString();
                if (_Calibration.Demand.DemandDetails[0].PurchaseProjectDetail != null)
                {
                    PurchaseProject pp = (PurchaseProject)_Calibration.Demand.DemandDetails[0].PurchaseProjectDetail.PurchaseProject;
                    if (pp != null)
                    {
                        this.txtProject.Text = pp.CurrentStateDef.DisplayText.ToString();

                        if(pp.PurchaseProjectDetails[0].ContractDetail != null)
                        {
                            if(pp.PurchaseProjectDetails[0].ContractDetail.Contract.ProcedureWorksAcceptNotices.Count > 0 )
                            {
                                this.txtLast.Text = "Kesildi.";
                                comp = true;
                            }
                        }
                    }
                }

            }
            if (comp == false)
            {
                this.DropStateButton(Calibration.States.ChiefApproval);
            }
#endregion CalibrationFirmForm_PreScript

            }
                }
}
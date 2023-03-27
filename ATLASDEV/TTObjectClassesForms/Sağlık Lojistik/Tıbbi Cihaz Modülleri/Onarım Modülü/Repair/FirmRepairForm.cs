
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
    /// Firma Onarımı
    /// </summary>
    public partial class FirmRepairForm : RepairBaseForm
    {
        override protected void BindControlEvents()
        {
            cmdSupplierDef.Click += new TTControlEventDelegate(cmdSupplierDef_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            cmdSupplierDef.Click -= new TTControlEventDelegate(cmdSupplierDef_Click);
            base.UnBindControlEvents();
        }

        private void cmdSupplierDef_Click()
        {
#region FirmRepairForm_cmdSupplierDef_Click
   if (_Repair.Supplier != null)
            {
                Supplier sup = (Supplier)_Repair.Supplier;
                TTListDef listDef = TTObjectDefManager.Instance.ListDefs["SupplierDefFormList"];
                TTDefinitionForm frm = TTDefinitionForm.GetEditForm(listDef);
                frm.ShowReadOnly(this.FindForm(), listDef, sup);

            }
            else
            {
                InfoBox.Show("Firma Seçmediniz");
            }
#endregion FirmRepairForm_cmdSupplierDef_Click
        }

        protected override void PreScript()
        {
#region FirmRepairForm_PreScript
    base.PreScript();
            this.txtLast.Text = "Kesilmedi.";
            bool comp = false;
            if (_Repair.Demand != null)
            {
                this.txtDemandNo.Text = _Repair.Demand.RequestNo.Value.ToString();
                this.txtDemand.Text = _Repair.Demand.CurrentStateDef.DisplayText.ToString();
                if (_Repair.Demand.DemandDetails[0].PurchaseProjectDetail != null)
                {
                    PurchaseProject pp = (PurchaseProject)_Repair.Demand.DemandDetails[0].PurchaseProjectDetail.PurchaseProject;
                    if (pp != null)
                    {
                        this.txtProject.Text = pp.CurrentStateDef.DisplayText.ToString();

                        if (pp.PurchaseProjectDetails[0].ContractDetail != null)
                        {
                            if (pp.PurchaseProjectDetails[0].ContractDetail.Contract.ProcedureWorksAcceptNotices.Count > 0)
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
                this.DropStateButton(Repair.States.LastControl);
                this.DropStateButton(Repair.States.Repair);
            }
#endregion FirmRepairForm_PreScript

            }
                }
}
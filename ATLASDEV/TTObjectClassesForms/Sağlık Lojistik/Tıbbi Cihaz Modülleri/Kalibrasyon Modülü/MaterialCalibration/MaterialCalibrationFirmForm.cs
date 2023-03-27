
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
    /// Kalibrasyon (Firma) [Stok Numaralı]
    /// </summary>
    public partial class MaterialCalibrationFirmForm : CalibrationBaseForm
    {
        override protected void BindControlEvents()
        {
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            base.UnBindControlEvents();
        }

        protected override void PreScript()
        {
#region MaterialCalibrationFirmForm_PreScript
    base.PreScript();
              this.txtLast.Text = "Kesilmedi.";
            bool comp = false;
            if (_MaterialCalibration.Demand != null)
            {
                this.txtDemandNo.Text = _MaterialCalibration.Demand.RequestNo.Value.ToString();
                this.txtDemand.Text = _MaterialCalibration.Demand.CurrentStateDef.DisplayText.ToString();
                if (_MaterialCalibration.Demand.DemandDetails[0].PurchaseProjectDetail != null)
                {
                    PurchaseProject pp = (PurchaseProject)_MaterialCalibration.Demand.DemandDetails[0].PurchaseProjectDetail.PurchaseProject;
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
                this.DropStateButton(MaterialCalibration.States.ChiefApproval);
            }
#endregion MaterialCalibrationFirmForm_PreScript

            }
                }
}
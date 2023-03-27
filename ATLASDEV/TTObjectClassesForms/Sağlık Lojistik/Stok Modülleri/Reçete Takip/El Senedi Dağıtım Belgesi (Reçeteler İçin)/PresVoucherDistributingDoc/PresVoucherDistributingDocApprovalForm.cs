
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
    /// El Senedi Dağıtım Belgesi (Reçeteler İçin)
    /// </summary>
    public partial class PresVoucherDistributingDocApprovalForm : BasePresVoucherDistributingDocForm
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
#region PresVoucherDistributingDocApprovalForm_PreScript
    base.PreScript();
            
            foreach (ITTGridRow stockActionOutDetailRow in PresVoucherDistDocMaterials.Rows)
                if (stockActionOutDetailRow.Cells[MaterialPresVoucherDistDocMaterial.Name].Value != null)
                stockActionOutDetailRow.Cells[AmountPresVoucherDistDocMaterial.Name].Value = stockActionOutDetailRow.Cells[RequireAmountPresVoucherDistDocMaterial.Name].Value;
#endregion PresVoucherDistributingDocApprovalForm_PreScript

            }
                }
}
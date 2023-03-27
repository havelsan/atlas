
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
    /// Kan Bankası Kan Ürünü İptal
    /// </summary>
    public partial class BloodProductRejectForm : EpisodeActionForm
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
#region BloodProductRejectForm_PreScript
    base.PreScript();
            
            this.cmdOK.Visible = false;
            this.cmdCancel.Visible = false;
            
            if(ttgrid1.Rows.Count > 0)
            {
                for(int i =0;i<ttgrid1.Rows.Count; i++)
                {
                    BloodBankBloodProducts bloodProduct = (BloodBankBloodProducts)ttgrid1.Rows[i].TTObject;
                    ttgrid1.Rows[i].Cells["txtBloodProductState"].Value = bloodProduct.CurrentStateDef.DisplayText;
                    if(bloodProduct.CurrentStateDefID == BloodBankBloodProducts.States.Cancelled)
                    {
                        ttgrid1.Rows[i].Cells["txtBloodProductState"].BackColor = Color.Silver;
                        ttgrid1.Rows[i].Cells["ttlistbox1"].BackColor = Color.Silver;
                        ttgrid1.Rows[i].Cells["ttlistbox1"].OwningRow.ReadOnly = true; 
                    }
                }
            }
#endregion BloodProductRejectForm_PreScript

            }
                }
}
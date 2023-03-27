
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
    /// Klinik Şefi Onay
    /// </summary>
    public partial class CMRActionClinicAppForm : CMRActionBaseForm
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
#region CMRActionClinicAppForm_PreScript
    base.PreScript();
            
            if (_CMRActionRequest.FixedAssetType == FixedAssetTypeEnum.SerialNO)
            {
                fixedAssetTypeTab.HideTabPage(StockTab);
                if ((bool)_CMRActionRequest.IsUnderGuaranty())
                {
                    GuaranyStatuslabel.Text = "GARANTİ KAPSAMINDA - Garanti Bitiş Tarihi:" + _CMRActionRequest.FixedAssetMaterialDefinition.GuarantyEndDate.Value.ToString();
                }
                else
                {
                    GuaranyStatuslabel.ForeColor = System.Drawing.Color.Red;
                    GuaranyStatuslabel.Text = "GARANTİ DIŞI";
                }
            }
            else
            {
                fixedAssetTypeTab.HideTabPage(SerialTab);
                this.GuaranyStatuslabel.Visible = false;
            }
#endregion CMRActionClinicAppForm_PreScript

            }
                }
}
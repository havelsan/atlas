
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
    /// Üst Kademeye Sevk
    /// </summary>
    public partial class UpperStageForm : RepairBaseForm
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
#region UpperStageForm_PreScript
    if ((bool)_Repair.IsUnderGuaranty())
            {
                GuaranyStatuslabel.Text = "GARANTİ KAPSAMINDA - Garanti Bitiş Tarihi:" + _Repair.FixedAssetMaterialDefinition.GuarantyEndDate.Value.ToString();
            }
            else
            {
                GuaranyStatuslabel.ForeColor = System.Drawing.Color.Red;
                GuaranyStatuslabel.Text = "GARANTİ DIŞI";
            }

            Guid rulid = new Guid(_Repair.RULObjectID.ToString());
            ReferToUpperLevel rul = (ReferToUpperLevel)this._ttObject.ObjectContext.GetObject(rulid, "REFERTOUPPERLEVEL");
            RulStatus.Text = rul.CurrentStateDef.DisplayText.ToString();
#endregion UpperStageForm_PreScript

            }
                }
}
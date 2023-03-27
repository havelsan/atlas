
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
    public partial class CalibrationBaseForm : BaseCMRActionForm
    {
        override protected void BindControlEvents()
        {
            tttoolstrip1.ItemClicked += new TTToolStripItemClicked(tttoolstrip1_ItemClicked);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            tttoolstrip1.ItemClicked -= new TTToolStripItemClicked(tttoolstrip1_ItemClicked);
            base.UnBindControlEvents();
        }

        private void tttoolstrip1_ItemClicked(ITTToolStripItem item)
        {
#region CalibrationBaseForm_tttoolstrip1_ItemClicked
   if (_Calibration.FixedAssetMaterialDefinition == null)
            {
                InfoBox.Show("Önce Tıbbi Cihazı Seçiniz.");
            }
            else
            {
                switch(item.Name)
                {
                    case "FixedAssetMaterialDefinition":

                        FixedAssetMaterialDefinition fmd = _Calibration.FixedAssetMaterialDefinition;
                        TTListDef listDef = TTObjectDefManager.Instance.ListDefs["FixedAssetMaterialDefFormList"];
                        TTDefinitionForm frm = TTDefinitionForm.GetEditForm(listDef);
                        frm.ShowReadOnly(this.FindForm(),listDef,fmd);
                        break;
                    case "FixedAssetDefinition":

                        FixedAssetDefinition fd = _Calibration.FixedAssetMaterialDefinition.FixedAssetDefinition;
                        TTListDef listDef2 = TTObjectDefManager.Instance.ListDefs["FixedAssetDefFormList"];
                        TTDefinitionForm frm2 = TTDefinitionForm.GetEditForm(listDef2);
                        frm2.ShowReadOnly(this.FindForm(),listDef2,fd);
                        break;
                    default:
                        break;
                }
            }
#endregion CalibrationBaseForm_tttoolstrip1_ItemClicked
        }
    }
}
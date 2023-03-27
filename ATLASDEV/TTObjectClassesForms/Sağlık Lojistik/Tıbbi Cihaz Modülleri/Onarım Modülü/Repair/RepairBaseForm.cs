
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
    public partial class RepairBaseForm : BaseCMRActionForm
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
#region RepairBaseForm_tttoolstrip1_ItemClicked
   if (_Repair.FixedAssetMaterialDefinition == null)
            {
                InfoBox.Show("Önce Demirbaşı Seçiniz.");
            }
            else
            {
                switch (item.Name)
                {
                    case "FixedAssetMaterialDefinition":

                        FixedAssetMaterialDefinition fmd = _Repair.FixedAssetMaterialDefinition;
                        TTListDef listDef = TTObjectDefManager.Instance.ListDefs["FixedAssetMaterialDefFormList"];
                        TTDefinitionForm frm = TTDefinitionForm.GetEditForm(listDef);
                        frm.ShowReadOnly(this.FindForm(), listDef, fmd);

                        break;
                    case "FixedAssetDefinition":

                        FixedAssetDefinition fd = _Repair.FixedAssetMaterialDefinition.FixedAssetDefinition;
                        TTListDef listDef2 = TTObjectDefManager.Instance.ListDefs["FixedAssetDefFormList"];
                        TTDefinitionForm frm2 = TTDefinitionForm.GetEditForm(listDef2);
                        frm2.ShowReadOnly(this.FindForm(), listDef2, fd);

                        break;
                    case "StockCardDef":


                        StockCard stockCard = _Repair.FixedAssetMaterialDefinition.FixedAssetDefinition.StockCard;
                        TTDefinitionForm frm3 = TTDefinitionForm.GetEditForm(TTObjectDefManager.Instance.ListDefs["StockCardDefinitionList"]);
                        frm3.ShowReadOnly(this.FindForm(), TTObjectDefManager.Instance.ListDefs["StockCardDefinitionList"], stockCard);
                        //StockCardForm scf = _Repair.FixedAssetMaterialDefinition.FixedAssetDefinition.StockCard;
                        //TTListDef listDef = TTObjectDefManager.Instance.ListDefs["StockCardList"];
                        //TTDefinitionForm frm = TTDefinitionForm.GetEditForm(listDef);
                        //frm.ShowReadOnly(this.FindForm(),listDef,scf);


                        break;
                    default:
                        break;
                }
            }
#endregion RepairBaseForm_tttoolstrip1_ItemClicked
        }
    }
}
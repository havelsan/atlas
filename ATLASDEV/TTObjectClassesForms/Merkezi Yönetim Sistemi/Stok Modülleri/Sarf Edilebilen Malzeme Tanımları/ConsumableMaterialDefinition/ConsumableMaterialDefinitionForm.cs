
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
    /// Sarf Edilebilen Malzeme Tanımları
    /// </summary>
    public partial class ConsumableMaterialDefinitionForm : TerminologyManagerDefForm
    {
        override protected void BindControlEvents()
        {
            cmdSendChanging.Click += new TTControlEventDelegate(cmdSendChanging_Click);
            cmdChangeTypeToFixedAsset.Click += new TTControlEventDelegate(cmdChangeTypeToFixedAsset_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            cmdSendChanging.Click -= new TTControlEventDelegate(cmdSendChanging_Click);
            cmdChangeTypeToFixedAsset.Click -= new TTControlEventDelegate(cmdChangeTypeToFixedAsset_Click);
            base.UnBindControlEvents();
        }

        private void cmdSendChanging_Click()
        {
            #region ConsumableMaterialDefinitionForm_cmdSendChanging_Click
            DataTable tbl = TTAuditRecord.GetObjectAuditRecords(_ConsumableMaterialDefinition.ObjectID, null, null, TTUser.CurrentUser.IsSuperUser);
            bool ChangedBefore = false;
            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                DataRow row = tbl.Rows[i];
                if (Convert.ToByte(row["OPERATIONTYPE"]) == 24)
                {
                    ChangedBefore = true;
                    break;
                }
            }

            if (ChangedBefore)
            {
                List<string> keys = new List<string>();
                List<object> values = new List<object>();
                foreach (KeyValuePair<Guid, Sites> kp in Sites.AllActiveSites)
                {
                    //FixedAssetDefinition.RemoteMethods.ChangeFixedAssetMaterialToConsumable(kp.Key, _ConsumableMaterialDefinition.ObjectID, keys, values);
                }
                InfoBox.Show("Değişiklik tüm aktif sahalara yollanmıştır", MessageIconEnum.InformationMessage);
            }
            else
                InfoBox.Show("Bu malzemeye ait eski tarihli bir sınıf değişikliği bulunamadı");
            #endregion ConsumableMaterialDefinitionForm_cmdSendChanging_Click
        }

        private void cmdChangeTypeToFixedAsset_Click()
        {
            #region ConsumableMaterialDefinitionForm_cmdChangeTypeToFixedAsset_Click
            //sahalarda güncel mi bakalım
            //ET 25.05.2012
            TTForm checkForm = new CheckSitesBeforeChangeToFixedAssetForm();
            checkForm.ShowEdit(this.FindForm(), _ConsumableMaterialDefinition, false);

            //   string result = ShowBox.Show(ShowBoxTypeEnum.Choice, "&Evet,&Hayır", "E,H", "Dikkat!!!", "Malzeme demirbaşa çevrilecek. Onaylıyor musunuz?");
            //            if (result == "E")
            //            {
            //                TTForm frm = new ChangeToFixedAssetFromConsumableForm();
            //                frm.ShowEdit(this.FindForm(), _ConsumableMaterialDefinition, false);
            //            }
            //            else
            //                InfoBox.Show("İşlemden vazgeçildi", MessageIconEnum.InformationMessage);
            //
            #endregion ConsumableMaterialDefinitionForm_cmdChangeTypeToFixedAsset_Click
        }

        protected override void PreScript()
        {
            #region ConsumableMaterialDefinitionForm_PreScript
            base.PreScript();
            //this.MalzelemeGetData.ListFilterExpression = " MALZEMETURID <> 'DM' ";

            if (TTObjectClasses.SystemParameter.GetSite() == null)
            {
                cmdChangeTypeToFixedAsset.Enabled = false;
                return;
            }

            Sites mySite = TTObjectClasses.SystemParameter.GetSite();

            if (mySite.ObjectID == Sites.SiteMerkezSagKom)
            {
                cmdChangeTypeToFixedAsset.Enabled = true;
                cmdSendChanging.Enabled = true;
                //this.IsExpendableMaterial.ReadOnly = false;
            }
            else
            {
                cmdChangeTypeToFixedAsset.Enabled = false;
                cmdSendChanging.Enabled = false;
                //this.IsExpendableMaterial.ReadOnly = true;
            }

            this.MaterialPriceGrid.Rows.Clear();
            foreach (MaterialPrice materialPrice in _ConsumableMaterialDefinition.MaterialPrices)
            {
                if (materialPrice.PricingDetail.DateEnd > Common.RecTime())
                {
                    ITTGridRow addedRow = this.MaterialPriceGrid.Rows.Add();
                    addedRow.Cells["PriceCode"].Value = materialPrice.PricingDetail.ExternalCode;
                    addedRow.Cells["Description"].Value = materialPrice.PricingDetail.Description;
                    addedRow.Cells["PricingList"].Value = materialPrice.PricingDetail.PricingList.ObjectID;
                    addedRow.Cells["Price"].Value = materialPrice.PricingDetail.Price;
                    addedRow.Cells["CurrencyType"].Value = materialPrice.PricingDetail.CurrencyType.ObjectID;
                }
            }
            #endregion ConsumableMaterialDefinitionForm_PreScript
        }

        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
            #region ConsumableMaterialDefinitionForm_PostScript
            base.PostScript(transDef);

            if (!_ConsumableMaterialDefinition.SUTAppendix.HasValue)
                throw new TTException("'SUT Eki' alanı boş geçilemez.");

            #endregion ConsumableMaterialDefinitionForm_PostScript
        }
    }
}
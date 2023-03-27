
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
    public partial class BaseDeleteRecordDocumentForm : StockActionBaseForm
    {
        override protected void BindControlEvents()
        {
            StockActionSignDetails.CellValueChanged += new TTGridCellEventDelegate(StockActionSignDetails_CellValueChanged);
            TTTeslimAlanButon.Click += new TTControlEventDelegate(TTTeslimAlanButon_Click);
            TTTeslimEdenButon.Click += new TTControlEventDelegate(TTTeslimEdenButon_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            StockActionSignDetails.CellValueChanged -= new TTGridCellEventDelegate(StockActionSignDetails_CellValueChanged);
            TTTeslimAlanButon.Click -= new TTControlEventDelegate(TTTeslimAlanButon_Click);
            TTTeslimEdenButon.Click -= new TTControlEventDelegate(TTTeslimEdenButon_Click);
            base.UnBindControlEvents();
        }

        private void TTTeslimAlanButon_Click()
        {
            #region TTTeslimAlanButon_Click
            TTObjectContext context = new TTObjectContext(false);
            BindingList<ResUser> resUser = ResUser.GetAllUser(context, "WHERE ISACTIVE = 1 ");
            ResUser selectedPersonel = null;

            MultiSelectForm multiSelectForm = new MultiSelectForm();
            foreach (ResUser user in resUser)
            {
                multiSelectForm.AddMSItem(user.Name, user.ObjectID.ToString(), user);
            }
            string key = multiSelectForm.GetMSItem(this.ParentForm, "Teslim Alan Personel Se�in");

            if (string.IsNullOrEmpty(key))
                InfoBox.Show("Herhangibir Personel Se�ilmedi.", MessageIconEnum.ErrorMessage);
            else
            {
                selectedPersonel = multiSelectForm.MSSelectedItemObject as ResUser;
                this.MKYS_TeslimAlan.Text = selectedPersonel.Name.ToString();
                this._StockAction.MKYS_TeslimAlanObjID = selectedPersonel.ObjectID;
            }
            #endregion TTTeslimAlanButon_Click
        }
        private void TTTeslimEdenButon_Click()
        {
            #region TTTeslimEdenButon_Click
            TTObjectContext context = new TTObjectContext(false);
            BindingList<ResUser> resUser = ResUser.GetAllUser(context, "WHERE ISACTIVE = 1 ");
            ResUser selectedPersonel = null;

            MultiSelectForm multiSelectForm = new MultiSelectForm();
            foreach (ResUser user in resUser)
            {
                multiSelectForm.AddMSItem(user.Name, user.ObjectID.ToString(), user);
            }
            string key = multiSelectForm.GetMSItem(this.ParentForm, "Teslim Eden Personeli Se�in");

            if (string.IsNullOrEmpty(key))
                InfoBox.Show("Herhangibir Personel Se�ilmedi.", MessageIconEnum.ErrorMessage);
            else
            {
                selectedPersonel = multiSelectForm.MSSelectedItemObject as ResUser;
                this.MKYS_TeslimEden.Text = selectedPersonel.Name.ToString();
                this._StockAction.MKYS_TeslimEdenObjID = selectedPersonel.ObjectID;
            }
            #endregion TTTeslimEdenButon_Click
        }


        private void StockActionSignDetails_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
            /*
            #region BaseDeleteRecordDocumentForm_StockActionSignDetails_CellValueChanged
            if (StockActionSignDetails.CurrentCell.OwningColumn.Name == "SignUser")
            {
                if (StockActionSignDetails.CurrentCell.Value != null)
                {
                    StockActionSignDetails.Rows[rowIndex].Cells["FreeTextSignUser"].ReadOnly = true;
                }
                else
                {
                    StockActionSignDetails.Rows[rowIndex].Cells["FreeTextSignUser"].ReadOnly = false;
                    StockActionSignDetails.Rows[rowIndex].Cells["FreeTextSignUser"].Value = string.Empty;
                }
            }
            #endregion BaseDeleteRecordDocumentForm_StockActionSignDetails_CellValueChanged
            */
        }

        protected override void PreScript()
        {
            #region BaseDeleteRecordDocumentForm_PreScript
            base.PreScript();
            /*
            if (_BaseDeleteRecordDocument.StockActionSignDetails.Count == 0)
            {
                StockActionSignDetail stockActionSignDetail = _BaseDeleteRecordDocument.StockActionSignDetails.AddNew();
                stockActionSignDetail.SignUserType = SignUserTypeEnum.MalSaymani;
                if (_BaseDeleteRecordDocument.Store is MainStoreDefinition)
                    stockActionSignDetail.SignUser = ((MainStoreDefinition)_BaseDeleteRecordDocument.Store).GoodsAccountant;

                stockActionSignDetail = _BaseDeleteRecordDocument.StockActionSignDetails.AddNew();
                stockActionSignDetail.SignUserType = SignUserTypeEnum.HesapSorumlusu;
                if (_BaseDeleteRecordDocument.Store is MainStoreDefinition)
                {
                    if (((MainStoreDefinition)_BaseDeleteRecordDocument.Store).AccountManager != null)
                    {
                        stockActionSignDetail.SignUser = ((MainStoreDefinition)_BaseDeleteRecordDocument.Store).AccountManager;
                    }
                    else
                    {
                        ResUser user = TTUser.CurrentUser.UserObject as ResUser;
                        if (user.SelectedSecMasterResource.ResourceUsers.Count > 0)
                            stockActionSignDetail.SignUser = user.SelectedSecMasterResource.ResourceUsers[0].User;
                    }
                }

                stockActionSignDetail = _BaseDeleteRecordDocument.StockActionSignDetails.AddNew();
                stockActionSignDetail.SignUserType = SignUserTypeEnum.MalSorumlusu;
                if (_BaseDeleteRecordDocument.Store is MainStoreDefinition)
                    stockActionSignDetail.SignUser = ((MainStoreDefinition)_BaseDeleteRecordDocument.Store).GoodsResponsible;

                stockActionSignDetail = _BaseDeleteRecordDocument.StockActionSignDetails.AddNew();
                stockActionSignDetail.SignUserType = SignUserTypeEnum.BirlikXXXXXXi;
                stockActionSignDetail.SignUser = null;

                stockActionSignDetail = _BaseDeleteRecordDocument.StockActionSignDetails.AddNew();
                stockActionSignDetail.SignUserType = SignUserTypeEnum.YetkiliMakam;
                stockActionSignDetail.SignUser = null;
            }

            foreach (ITTGridRow row in this.StockActionSignDetails.Rows)
            {
                if (((int)row.Cells["SignUserType"].Value) == 6)
                {
                    row.Cells["FreeTextSignUser"].Required = true;
                    //row.Cells["SignUser"].Required = false;
                }
                else
                {
                    row.Cells["FreeTextSignUser"].ReadOnly = true;
                    row.Cells["SignUser"].Required = true;
                }

                if ((SignUserTypeEnum)row.Cells["SignUserType"].Value == SignUserTypeEnum.BirlikXXXXXXi)
                {
                    row.Cells["SignUserType"].Required = true;
                }
                else
                {
                    row.Cells["SignUserType"].ReadOnly = true;
                    row.Cells["SignUserType"].Required = true;
                }

            }


            if (_BaseDeleteRecordDocument.StockActionInspection != null)
                DescriptionAndSignTabControl.ShowTabPage(InspectionTabpage);
            else
                DescriptionAndSignTabControl.HideTabPage(InspectionTabpage);
                 */
            #endregion BaseDeleteRecordDocumentForm_PreScript

        }
    }
}

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
    /// Sayım Düzeltme Belgesi
    /// </summary>
    public partial class BaseCensusFixedForm : StockActionBaseForm
    {
        override protected void BindControlEvents()
        {
            StockActionInDetails.CellDoubleClick += new TTGridCellEventDelegate(StockActionInDetails_CellDoubleClick);
            StockActionInDetails.CellValueChanged += new TTGridCellEventDelegate(StockActionInDetails_CellValueChanged);
            StockActionInDetails.CellContentClick += new TTGridCellEventDelegate(StockActionInDetails_CellContentClick);
            StockActionOutDetails.CellDoubleClick += new TTGridCellEventDelegate(StockActionOutDetails_CellDoubleClick);
            StockActionOutDetails.CellValueChanged += new TTGridCellEventDelegate(StockActionOutDetails_CellValueChanged);
            StockActionOutDetails.CellContentClick += new TTGridCellEventDelegate(StockActionOutDetails_CellContentClick);
            TTTeslimAlanButon.Click += new TTControlEventDelegate(TTTeslimAlanButon_Click);
            TTTeslimEdenButon.Click += new TTControlEventDelegate(TTTeslimEdenButon_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            StockActionInDetails.CellDoubleClick -= new TTGridCellEventDelegate(StockActionInDetails_CellDoubleClick);
            StockActionInDetails.CellValueChanged -= new TTGridCellEventDelegate(StockActionInDetails_CellValueChanged);
            StockActionInDetails.CellContentClick -= new TTGridCellEventDelegate(StockActionInDetails_CellContentClick);
            StockActionOutDetails.CellDoubleClick -= new TTGridCellEventDelegate(StockActionOutDetails_CellDoubleClick);
            StockActionOutDetails.CellValueChanged -= new TTGridCellEventDelegate(StockActionOutDetails_CellValueChanged);
            StockActionOutDetails.CellContentClick -= new TTGridCellEventDelegate(StockActionOutDetails_CellContentClick);
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
            string key = multiSelectForm.GetMSItem(this.ParentForm, "Teslim Alan Personel Seçin");

            if (string.IsNullOrEmpty(key))
                InfoBox.Show("Herhangibir Personel Seçilmedi.", MessageIconEnum.ErrorMessage);
            else
            {
                selectedPersonel = multiSelectForm.MSSelectedItemObject as ResUser;
                this.MKYS_TeslimAlan.Text = selectedPersonel.Name.ToString();
                _CensusFixed.MKYS_TeslimAlanObjID = selectedPersonel.ObjectID;
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
            string key = multiSelectForm.GetMSItem(this.ParentForm, "Teslim Eden Personeli Seçin");

            if (string.IsNullOrEmpty(key))
                InfoBox.Show("Herhangibir Personel Seçilmedi.", MessageIconEnum.ErrorMessage);
            else
            {
                selectedPersonel = multiSelectForm.MSSelectedItemObject as ResUser;
                this.MKYS_TeslimEden.Text = selectedPersonel.Name.ToString();
                _CensusFixed.MKYS_TeslimEdenObjID = selectedPersonel.ObjectID;
            }
            #endregion TTTeslimEdenButon_Click
        }


        private void StockActionInDetails_CellDoubleClick(Int32 rowIndex, Int32 columnIndex)
        {
#region BaseCensusFixedForm_StockActionInDetails_CellDoubleClick
   CheckWhetherTheInventoryOfMaterial(rowIndex, columnIndex, StockActionInDetails);
#endregion BaseCensusFixedForm_StockActionInDetails_CellDoubleClick
        }

        private void StockActionInDetails_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region BaseCensusFixedForm_StockActionInDetails_CellValueChanged
   if (this is CensusFixedNewForm)
            {
                ITTGridCell changedCell = StockActionInDetails.Rows[rowIndex].Cells[columnIndex];
                ITTGridRow changedRow = changedCell.OwningRow;
                if (changedCell.OwningColumn.Name == CardAmount.Name || changedCell.OwningColumn.Name == CensusAmount.Name)
                {
                    if (changedCell.Value != null)
                    {
                        CensusFixedMaterialIn censusFixedMaterialIn = changedRow.TTObject as CensusFixedMaterialIn;
                        if (censusFixedMaterialIn != null && censusFixedMaterialIn.CardAmount.HasValue && censusFixedMaterialIn.CensusAmount.HasValue)
                            censusFixedMaterialIn.Amount = censusFixedMaterialIn.CensusAmount - censusFixedMaterialIn.CardAmount;
                    }
                }
            }
#endregion BaseCensusFixedForm_StockActionInDetails_CellValueChanged
        }

        private void StockActionInDetails_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region BaseCensusFixedForm_StockActionInDetails_CellContentClick
   if(StockActionInDetails.CurrentCell.OwningColumn.Name =="Detail")
                this.ShowStockActionDetailForm((StockActionDetail)StockActionInDetails.CurrentCell.OwningRow.TTObject);
#endregion BaseCensusFixedForm_StockActionInDetails_CellContentClick
        }

        private void StockActionOutDetails_CellDoubleClick(Int32 rowIndex, Int32 columnIndex)
        {
#region BaseCensusFixedForm_StockActionOutDetails_CellDoubleClick
   CheckWhetherTheInventoryOfMaterial(rowIndex, columnIndex, StockActionOutDetails);
#endregion BaseCensusFixedForm_StockActionOutDetails_CellDoubleClick
        }

        private void StockActionOutDetails_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region BaseCensusFixedForm_StockActionOutDetails_CellValueChanged
   if (this is CensusFixedNewForm)
            {
                ITTGridCell changedCell = StockActionOutDetails.Rows[rowIndex].Cells[columnIndex];
                ITTGridRow changedRow = changedCell.OwningRow;
                if (changedCell.OwningColumn.Name == CardAmountOut.Name || changedCell.OwningColumn.Name == CensusAmountOut.Name)
                {
                    if (changedCell.Value != null)
                    {
                        CensusFixedMaterialOut censusFixedMaterialOut = changedRow.TTObject as CensusFixedMaterialOut;
                        if (censusFixedMaterialOut != null && censusFixedMaterialOut.CardAmount.HasValue && censusFixedMaterialOut.CensusAmount.HasValue)
                            censusFixedMaterialOut.Amount = censusFixedMaterialOut.CardAmount - censusFixedMaterialOut.CensusAmount;
                    }
                }
            }
#endregion BaseCensusFixedForm_StockActionOutDetails_CellValueChanged
        }

        private void StockActionOutDetails_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region BaseCensusFixedForm_StockActionOutDetails_CellContentClick
   if(StockActionOutDetails.CurrentCell.OwningColumn.Name =="DetailOut")
                this.ShowStockActionDetailForm((StockActionDetail)StockActionOutDetails.CurrentCell.OwningRow.TTObject);
#endregion BaseCensusFixedForm_StockActionOutDetails_CellContentClick
        }

        protected override void PreScript()
        {
#region BaseCensusFixedForm_PreScript
    base.PreScript();

            if (_CensusFixed.MasterAction != null)
            {
                StockActionInDetails.ReadOnly = true;
                StockActionOutDetails.ReadOnly = true;
            }
#endregion BaseCensusFixedForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region BaseCensusFixedForm_PostScript
    base.PostScript(transDef);
#endregion BaseCensusFixedForm_PostScript

            }
                }
}
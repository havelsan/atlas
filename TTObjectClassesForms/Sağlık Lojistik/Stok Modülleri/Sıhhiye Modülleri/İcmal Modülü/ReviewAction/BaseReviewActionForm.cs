
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
    public partial class BaseReviewActionForm : StockActionBaseForm
    {
        override protected void BindControlEvents()
        {
            base.BindControlEvents();
            TTTeslimAlanButon.Click += new TTControlEventDelegate(TTTeslimAlanButon_Click);
            TTTeslimEdenButon.Click += new TTControlEventDelegate(TTTeslimEdenButon_Click);
            TTGetDrugButton.Click += new TTControlEventDelegate(TTGetDrugButton_Click);
        }

        override protected void UnBindControlEvents()
        {
            base.UnBindControlEvents();
            TTTeslimAlanButon.Click -= new TTControlEventDelegate(TTTeslimAlanButon_Click);
            TTTeslimEdenButon.Click -= new TTControlEventDelegate(TTTeslimEdenButon_Click);
            TTGetDrugButton.Click -= new TTControlEventDelegate(TTGetDrugButton_Click);
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
                _ReviewAction.MKYS_TeslimAlanObjID = selectedPersonel.ObjectID;
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
                _ReviewAction.MKYS_TeslimEdenObjID = selectedPersonel.ObjectID;
            }
            #endregion TTTeslimEdenButon_Click
        }


        private void TTGetDrugButton_Click()
        {
            #region TTGetDrugButton_Click
            if (!(this.ReviewActionDetails.Rows.Count > 0))
            {
                ReviewAction.GetDrugOrder((DateTime)this._ReviewAction.StartDate, (DateTime)this._ReviewAction.EndDate,this._ReviewAction, new List<Store>(), new List<BudgetTypeDefinition>());
                if (this.ReviewActionDetails.Rows.Count > 0)
                {
                    this.StartDate.ReadOnly = true;
                    this.EndDate.ReadOnly = true;
                    this.TTGetDrugButton.ReadOnly = true;
                }
            }
            else
            {
                this.StartDate.ReadOnly = true;
                this.EndDate.ReadOnly = true;
                this.TTGetDrugButton.ReadOnly = true;
            }

            #endregion TTGetDrugButton_Click
        }
        protected override void PreScript()
        {
            #region BaseReviewActionForm_PreScript
            base.PreScript();
            _ReviewAction.MKYS_CikisIslemTuru = MKYS_ECikisIslemTuruEnum.cikis;
            _ReviewAction.MKYS_CikisStokHareketTuru = MKYS_ECikisStokHareketTurEnum.ckTuketimYatanHastaTedavisi;
            #endregion BaseReviewActionForm_PreScript
        }
    }
}
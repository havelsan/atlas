
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
    /// Ana Malzeme Detaylandırma
    /// </summary>
    public partial class FixedAssetDetailActionForm : TTForm
    {
        override protected void BindControlEvents()
        {
            cmdSelectStore.Click += new TTControlEventDelegate(cmdSelectStore_Click);
            cmdList.Click += new TTControlEventDelegate(cmdList_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            cmdSelectStore.Click -= new TTControlEventDelegate(cmdSelectStore_Click);
            cmdList.Click -= new TTControlEventDelegate(cmdList_Click);
            base.UnBindControlEvents();
        }

        private void cmdSelectStore_Click()
        {
#region FixedAssetDetailActionForm_cmdSelectStore_Click
   Store store = null;

            IList stores = this._FixedAssetDetailAction.ObjectContext.QueryObjects("STORE", "STATUS=1");
            if (stores.Count == 1)
            {
                store = (Store)stores[0];
            }
            else if (stores.Count > 1)
            {
                MultiSelectForm mAccSelectForm = new MultiSelectForm();
                foreach (Store s in stores)
                    mAccSelectForm.AddMSItem(s.Name, s.ObjectID.ToString(), s); //s.QREF  + " - " + 
                string mAcckey = mAccSelectForm.GetMSItem(this, "Depo Seçiniz", true);
                store = mAccSelectForm.MSSelectedItemObject as Store;
            }
            else
                throw new TTException("İşlemin yapılacağı depo seçilmeden işleme devam edemezsiniz.");

            this._FixedAssetDetailAction.StoreName = store.Name;
            this._FixedAssetDetailAction.StoreObjectID = store.ObjectID;
#endregion FixedAssetDetailActionForm_cmdSelectStore_Click
        }

        private void cmdList_Click()
        {
#region FixedAssetDetailActionForm_cmdList_Click
   List<FixedAssetMaterialDefinition> fads = new List<FixedAssetMaterialDefinition>();
            Accountancy siteAccountancy = null;


            IList mainstore = this._FixedAssetDetailAction.ObjectContext.QueryObjects("MAINSTOREDEFINITION", "STATUS=1");
            if (mainstore.Count == 1)
            {
                siteAccountancy = ((MainStoreDefinition)mainstore[0]).Accountancy;
            }
            else if (mainstore.Count > 1)
            {
                MultiSelectForm mAccSelectForm = new MultiSelectForm();
                foreach (MainStoreDefinition main in mainstore)
                    mAccSelectForm.AddMSItem(main.Accountancy.AccountancyNO + " - " + main.Accountancy.Name, main.Accountancy.ObjectID.ToString(), main.Accountancy);
                string mAcckey = mAccSelectForm.GetMSItem(this, "Saymanlık Seçiniz", true);
                siteAccountancy = mAccSelectForm.MSSelectedItemObject as Accountancy;
            }
            else
                throw new TTException("İşlemin yapılacağı ssaymanlık seçilmeden işleme devam edemezsiniz.");

            if(this.StoreName != null)
            {
                if(this.StockCard.SelectedValue != null)
                {
                    
                    foreach (Material material in _FixedAssetDetailAction.StockCard.Materials)
                    {
                        if (material is FixedAssetDefinition)
                        {
                            FixedAssetDefinition fa = material as FixedAssetDefinition;
                            foreach (Stock s in fa.Stocks.Select("INHELD > 0  AND STORE =" + ConnectionManager.GuidToString((Guid)this._FixedAssetDetailAction.StoreObjectID)))
                            {
                                List<FixedAssetMaterialDefinition> fadList = new List<FixedAssetMaterialDefinition>();
                                foreach (FixedAssetMaterialDefinition fad in fa.FixedAssetMaterialDefinitions.Select("FIXEDASSETMATERIALDEFDETAIL IS NULL AND STOCK=" + ConnectionManager.GuidToString(s.ObjectID)))
                                {
                                    if (fadList.Count <= (double)s.Inheld && fad.FixedAssetMaterialDefDetail == null)
                                        fadList.Add(fad);
                                }
                                
                                if (fa.FixedAssetMaterialDefinitions.Select("STOCK=" + ConnectionManager.GuidToString(s.ObjectID)).Count < (double)s.Inheld)
                                {
                                    double missingCount = (double)s.Inheld - fa.FixedAssetMaterialDefinitions.Select("STOCK=" + ConnectionManager.GuidToString(s.ObjectID)).Count;
                                    this._FixedAssetDetailAction.CreateFixedAssetMaterialAddList(s, missingCount, fadList, this._FixedAssetDetailAction.ObjectContext, siteAccountancy);
                                }
                                foreach (FixedAssetMaterialDefinition f in fadList)
                                    fads.Add(f);
                                
                                if(fads.Count == 0)
                                    throw new TTException("Bu Malzemenin Detaylandırması Yapılmıştır.");
                                
                                                                
                            }
                        }
                    }
                    foreach (FixedAssetMaterialDefinition f in fads)
                    {
                        FixedAssetDetailActionDet det = new FixedAssetDetailActionDet(this._FixedAssetDetailAction.ObjectContext);
                        det.FixedAssetMaterialDefinition = f;
                        FixedAssetMaterialDefinitionDetail fDet = new FixedAssetMaterialDefinitionDetail(this._FixedAssetDetailAction.ObjectContext);
                        f.FixedAssetMaterialDefDetail = fDet;
                        det.IsAccountancy = false;
                        det.IsBMM = false;
                        det.IsETKM = false;
                        det.FixedAssetDetailAction = this._FixedAssetDetailAction;
                    }

                    this.StockCard.ReadOnly = true;
                    this.cmdSelectStore.Enabled = false;
                }
                else
                    throw new TTException("Stok Kart Seçilmeden İşlem Yapılamaz.");
            }
            
            else
                throw new TTException("Depo Seçilmeden İşlem Yapılamaz.");
#endregion FixedAssetDetailActionForm_cmdList_Click
        }

        protected override void PreScript()
        {
#region FixedAssetDetailActionForm_PreScript
    base.PreScript();

            this.ETKMDesc.ReadOnly = true;
            this.BMMDesc.ReadOnly = true;

            if (this._FixedAssetDetailAction.CurrentStateDefID != FixedAssetDetailAction.States.StageOne)
                this.StockCard.ReadOnly = true;

            if (this._FixedAssetDetailAction.CurrentStateDefID == FixedAssetDetailAction.States.StageThree)
            {
                this.ETKMDesc.ReadOnly = false;
                this.DropStateButton(FixedAssetDetailAction.States.Cancelled);
                Guid siteIDGuid = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("SITEID", Guid.Empty.ToString()));
                if (Sites.SiteMerkezSagKom != siteIDGuid)
                    throw new TTException("Bu aşama sadece Sağlık XXXXXX Merkez sahasında açılabilir");

            }

            if (this._FixedAssetDetailAction.CurrentStateDefID == FixedAssetDetailAction.States.StageTwo)
                this.BMMDesc.ReadOnly = false;
#endregion FixedAssetDetailActionForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region FixedAssetDetailActionForm_PostScript
    base.PostScript(transDef);

            if (this._FixedAssetDetailAction.FixedAssetDetailActionDetails.Count == 0)
                throw new Exception("Demirbaş Detayı Yoktur.");
#endregion FixedAssetDetailActionForm_PostScript

            }
                }
}
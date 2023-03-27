
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
    public partial class ChattelDocumentWithPurchaseNewForm : BaseChattelDocumentWithPurchaseForm
    {
        override protected void BindControlEvents()
        {
            OrderedSuppliersGrid.CellContentClick += new TTGridCellEventDelegate(OrderedSuppliersGrid_CellContentClick);
            cmdTransfer.Click += new TTControlEventDelegate(cmdTransfer_Click);
            firmdef_ttbutton.Click += new TTControlEventDelegate(firmdef_ttbutton_Click);
            chkFreeEntry.CheckedChanged += new TTControlEventDelegate(chkFreeEntry_CheckedChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            OrderedSuppliersGrid.CellContentClick -= new TTGridCellEventDelegate(OrderedSuppliersGrid_CellContentClick);
            cmdTransfer.Click -= new TTControlEventDelegate(cmdTransfer_Click);
            firmdef_ttbutton.Click -= new TTControlEventDelegate(firmdef_ttbutton_Click);
            chkFreeEntry.CheckedChanged -= new TTControlEventDelegate(chkFreeEntry_CheckedChanged);
            base.UnBindControlEvents();
        }

        private void OrderedSuppliersGrid_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
            #region ChattelDocumentWithPurchaseNewForm_OrderedSuppliersGrid_CellContentClick
            if (OrderedSuppliersGrid.CurrentCell == null)
                return;

            TmpOrderedSupplier tos = (TmpOrderedSupplier)OrderedSuppliersGrid.CurrentCell.OwningRow.TTObject;

            _ChattelDocumentWithPurchase.TmpOrderedDetails.DeleteChildren();
            foreach (PurchaseOrderDetail pod in tos.PurchaseOrder.PurchaseOrderDetails)
            {
                if (pod.Status == OrderDetailStatusEnum.KurusluKesilecek)
                {
                    TmpOrderedDetail tod = new TmpOrderedDetail(_ChattelDocumentWithPurchase.ObjectContext);
                    tod.ChattelDocumentWithPurchase = _ChattelDocumentWithPurchase;
                    tod.PurchaseOrderDetail = pod;
                }
            }
            #endregion ChattelDocumentWithPurchaseNewForm_OrderedSuppliersGrid_CellContentClick
        }

        private void cmdTransfer_Click()
        {
            #region ChattelDocumentWithPurchaseNewForm_cmdTransfer_Click
            if (_ChattelDocumentWithPurchase.TmpOrderedDetails.Count == 0)
                return;

            Supplier supp = null;

            PurchaseOrder po = null;

            double totalPrice = 0;
            foreach (TmpOrderedDetail tod in _ChattelDocumentWithPurchase.TmpOrderedDetails)
            {
                if (po == null)
                    po = tod.PurchaseOrderDetail.PurchaseOrder;

                ChattelDocumentDetailWithPurchase cdm = new ChattelDocumentDetailWithPurchase(_ChattelDocumentWithPurchase.ObjectContext);
                cdm.StockAction = (StockAction)_ChattelDocumentWithPurchase;
                cdm.Amount = tod.PurchaseOrderDetail.Amount;
                cdm.Material = tod.PurchaseOrderDetail.ContractDetail.Material;
                cdm.UnitPrice = tod.PurchaseOrderDetail.ContractDetail.UnitPrice;
                supp = tod.PurchaseOrderDetail.PurchaseOrder.Supplier;
                totalPrice += Convert.ToDouble(cdm.Amount) * Convert.ToDouble(cdm.UnitPrice);

                foreach (PurchaseOrderDetail pod in po.PurchaseOrderDetails)
                {
                    foreach (DemandDetail dd in pod.PurchaseProjectDetail.DemandDetails)
                    {
                        ChattelDocumentDistribution cdd = new ChattelDocumentDistribution(_ChattelDocumentWithPurchase.ObjectContext);
                        cdd.ChattelDocumentWithPurchase = _ChattelDocumentWithPurchase;
                        cdd.DemandDetail = dd;
                        cdd.ChattelDocDetailWithPurchase = cdm;
                    }
                }
            }

            if (po == null)
                throw new TTUtils.TTException("Eksik Karar yada Sözleşme Numarası tespit edildi.");
            else
            {
                Supplier.SelectedObject = (TTObject)supp;
                _ChattelDocumentWithPurchase.ConclusionNumber = po.Contract.ConclusionNo;
                _ChattelDocumentWithPurchase.ConclusionDateTime = po.PurchaseProject.ConclusionApproveDate;
                _ChattelDocumentWithPurchase.ContractNumber = po.Contract.ContractNo;
                _ChattelDocumentWithPurchase.ContractDateTime = po.Contract.ContractDate;
            }

            _ChattelDocumentWithPurchase.TotalPrice = totalPrice;
            _ChattelDocumentWithPurchase.GrandTotal = totalPrice;

            cmdTransfer.Enabled = false;

            _ChattelDocumentWithPurchase.CalculateDistributionAmounts();
            #endregion ChattelDocumentWithPurchaseNewForm_cmdTransfer_Click
        }

        private void firmdef_ttbutton_Click()
        {
            #region ChattelDocumentWithPurchaseNewForm_firmdef_ttbutton_Click
            //
            //            TTObjectContext cn = new TTObjectContext(false);
            //            TTObjectClasses.FirmDefinitionAction _FirmDefinitionAction = new FirmDefinitionAction(cn);
            //            _FirmDefinitionAction.CurrentStateDefID = FirmDefinitionAction.States.New;
            //            TTVisual.TTForm selectfirmType = new TTFormClasses.BaseFirmDefinitonForm(); 
            //            selectfirmType.ObjectUpdated += new ObjectUpdatedDelegate(saveFormContext);
            //
            //            selectfirmType.ShowEdit(this, _FirmDefinitionAction, false);
            #endregion ChattelDocumentWithPurchaseNewForm_firmdef_ttbutton_Click
        }

        private void chkFreeEntry_CheckedChanged()
        {
            #region ChattelDocumentWithPurchaseNewForm_chkFreeEntry_CheckedChanged
            _ChattelDocumentWithPurchase.ChattelDocumentDetailsWithPurchase.DeleteChildren();
            if ((bool)chkFreeEntry.Value)
            {
                ChattelDocumentTabcontrol.HideTabPage(AvailableOrdersTab);
                //ContractNumber.ReadOnly = false;
                //ContractDateTime.ReadOnly = false;
               // ConclusionNumber.ReadOnly = false;
              //  ConclusionDateTime.ReadOnly = false;
                Supplier.ReadOnly = false;
                ChattelDocumentDetailsWithPurchase.Columns["MaterialStockActionDetailIn"].ReadOnly = false;
                ChattelDocumentDetailsWithPurchase.Columns["AmountStockActionDetailIn"].ReadOnly = false;
                ChattelDocumentDetailsWithPurchase.Columns["UnitPriceStockActionDetailIn"].ReadOnly = false;
                ChattelDocumentDetailsWithPurchase.Columns["ValueAddedTax"].ReadOnly = false;
            }
            else
            {
                ChattelDocumentTabcontrol.ShowTabPage(AvailableOrdersTab);
               // ContractNumber.ReadOnly = true;
               // ContractDateTime.ReadOnly = true;
               // ConclusionNumber.ReadOnly = true;
               // ConclusionDateTime.ReadOnly = true;
                Supplier.ReadOnly = true;
                ChattelDocumentDetailsWithPurchase.Columns["MaterialStockActionDetailIn"].ReadOnly = true;
                ChattelDocumentDetailsWithPurchase.Columns["AmountStockActionDetailIn"].ReadOnly = true;
                ChattelDocumentDetailsWithPurchase.Columns["UnitPriceStockActionDetailIn"].ReadOnly = true;
                ChattelDocumentDetailsWithPurchase.Columns["ValueAddedTax"].ReadOnly = true;
            }
            #endregion ChattelDocumentWithPurchaseNewForm_chkFreeEntry_CheckedChanged
        }

        protected override void PreScript()
        {
            #region ChattelDocumentWithPurchaseNewForm_PreScript
            base.PreScript();
            SelectStoreUsage(SelectStoreUsageEnum.UseMainStoreResources, SelectStoreUsageEnum.Nothing);

            if (((ITTObject)_ChattelDocumentWithPurchase).IsNew && _ChattelDocumentWithPurchase.CurrentStateDefID == ChattelDocumentWithPurchase.States.New)
            {
                IList list = PurchaseOrderDetail.GetByStatus(_ChattelDocumentWithPurchase.ObjectContext, (int)OrderDetailStatusEnum.KurusluKesilecek);
                ArrayList purchaseOrders = new ArrayList();

                foreach (PurchaseOrderDetail pod in list)
                {
                    if (pod.Status == OrderDetailStatusEnum.KurusluKesilecek)
                    {
                        if (!purchaseOrders.Contains(pod.PurchaseOrder))
                            purchaseOrders.Add(pod.PurchaseOrder);
                    }
                }

                _ChattelDocumentWithPurchase.TmpOrderedSuppliers.DeleteChildren();
                foreach (PurchaseOrder po in purchaseOrders)
                {
                    TmpOrderedSupplier tmpSupp = new TmpOrderedSupplier(_ChattelDocumentWithPurchase.ObjectContext);
                    tmpSupp.ChattelDocumentWithPurchase = _ChattelDocumentWithPurchase;
                    tmpSupp.PurchaseOrder = po;
                }
            }
            #endregion ChattelDocumentWithPurchaseNewForm_PreScript

        }

        protected override void ClientSidePreScript()
        {
            #region ChattelDocumentWithPurchaseNewForm_ClientSidePreScript
            base.ClientSidePreScript();

            _ChattelDocumentWithPurchase.MKYS_ETedarikTuru = MKYS_ETedarikTurEnum.satinalma;

            MultiSelectForm mSelectForm = new MultiSelectForm();
            mSelectForm.AddMSItem("Tıbbi Sarf", "Tıbbi Sarf", MKYS_EMalzemeGrupEnum.tibbiSarf);
            mSelectForm.AddMSItem("İlaç", "İlaç", MKYS_EMalzemeGrupEnum.ilac);
            mSelectForm.AddMSItem("Tıbbi Cihaz", "Tıbbi Cihaz", MKYS_EMalzemeGrupEnum.tibbiCihaz);
            mSelectForm.AddMSItem("Diğer", "Diğer", MKYS_EMalzemeGrupEnum.diger);

            string mkey = mSelectForm.GetMSItem(this, "Giriş Yapılacak Malzeme Grubunu Seçiniz", true);
            if (string.IsNullOrEmpty(mkey))
                throw new TTException(SystemMessage.GetMessageV2(369, "Malzeme grubu seçilmeden işleme devam edemezsiniz."));
            _ChattelDocumentWithPurchase.MKYS_EMalzemeGrup = (MKYS_EMalzemeGrupEnum)mSelectForm.MSSelectedItemObject;


            if (_ChattelDocumentWithPurchase.MKYS_EMalzemeGrup == MKYS_EMalzemeGrupEnum.tibbiSarf)
                MaterialStockActionDetailIn.ListFilterExpression = "OBJECTDEFID =" + ConnectionManager.GuidToString(new Guid("58d34696-808e-47de-87e0-1f001d0928a7"));

            if (_ChattelDocumentWithPurchase.MKYS_EMalzemeGrup == MKYS_EMalzemeGrupEnum.ilac)
                MaterialStockActionDetailIn.ListFilterExpression = "OBJECTDEFID =" + ConnectionManager.GuidToString(new Guid("65a2337c-bc3c-4c6b-9575-ad47fa7a9a89"));

            if (_ChattelDocumentWithPurchase.MKYS_EMalzemeGrup == MKYS_EMalzemeGrupEnum.tibbiCihaz)
                MaterialStockActionDetailIn.ListFilterExpression = "OBJECTDEFID =" + ConnectionManager.GuidToString(new Guid("f38f2111-0ee4-4b9f-9707-a63ac02d29f4"));


            List<double> priceCalc = new List<double>();
            double totalWithoutKDV = 0, totalWithKDV = 0, salesTotal = 0, totalPrice = 0;
            priceCalc.Add(totalWithoutKDV);
            priceCalc.Add(totalWithKDV);
            priceCalc.Add(salesTotal);
            priceCalc.Add(totalPrice);

            priceCalc = CalcFinalPriceWithKDV(priceCalc);

            txtNotKDV.Text = priceCalc[0].ToString("#.00");
            txtWithKDV.Text = priceCalc[1].ToString("#.00");
            txtDiscount.Text = priceCalc[2].ToString("#.00");
            txtTotalPrice.Text = priceCalc[3].ToString("#.00");
            #endregion ChattelDocumentWithPurchaseNewForm_ClientSidePreScript

        }

        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
            #region ChattelDocumentWithPurchaseNewForm_PostScript
            base.PostScript(transDef);

            int count = 20;
            _ChattelDocumentWithPurchase.CheckStockCardCardNofCount(count);
            #endregion ChattelDocumentWithPurchaseNewForm_PostScript

        }

        #region ChattelDocumentWithPurchaseNewForm_Methods
        private void saveFormContext(TTObject ttObject, ref bool isContextSaved)
        {
            if (ttObject == null)
                return;

            ttObject.ObjectContext.Save();
            isContextSaved = true;
        }

        #endregion ChattelDocumentWithPurchaseNewForm_Methods

        #region ChattelDocumentWithPurchaseNewForm_ClientSideMethods
        protected override void BarcodeRead(string value)
        {
          /*  base.BarcodeRead(value);
            Material material = null;
            IBindingList materials = _ChattelDocumentWithPurchase.ObjectContext.QueryObjects("MATERIAL", "BARCODE='" + value + "'");
            if (materials.Count == 0)
                InfoBox.Show(value + " UBB/Barkodlu malzeme bulunamadı.", MessageIconEnum.ErrorMessage);
            else if (materials.Count == 1)
                material = (Material)materials[0];
            else
            {
                MultiSelectForm multiSelectForm = new MultiSelectForm();
                foreach (Material m in materials)
                {
                    multiSelectForm.AddMSItem(m.Name, m.Name, m);
                }
                string key = multiSelectForm.GetMSItem(ParentForm, "Malzeme seçin");

                if (string.IsNullOrEmpty(key))
                    InfoBox.Show("Herhangibir malzeme seçilmedi.", MessageIconEnum.ErrorMessage);
                else
                    material = multiSelectForm.MSSelectedItemObject as Material;
            }

            if (material != null)
            {
                string retAmount = InputForm.GetText("Miktar Bilgisini Giriniz.");
                Currency? amount = 0;
                if (string.IsNullOrEmpty(retAmount) == false)
                {
                    if (CurrencyType.TryConvertFrom(retAmount, false, out amount) == false)
                        throw new TTException(SystemMessage.GetMessageV3(1192, new string[] { retAmount.ToString() }));
                }

                Currency? unitPrice = 0;
                string retUnitPrice = InputForm.GetText("Birim Maliyet Bedelini Giriniz");
                if (string.IsNullOrEmpty(retUnitPrice) == false)
                {
                    if (CurrencyType.TryConvertFrom(retUnitPrice, false, out unitPrice) == false)
                        throw new TTException(SystemMessage.GetMessageV3(1192, new string[] { retUnitPrice.ToString() }));
                }

                ChattelDocumentDetailWithPurchase returningDocument = _ChattelDocumentWithPurchase.ChattelDocumentDetailsWithPurchase.AddNew();
                returningDocument.Material = material;
                returningDocument.Amount = amount;
                returningDocument.UnitPrice = (Currency)unitPrice;

                switch ((StockMethodEnum)material.StockCard.StockMethod)
                {
                    case StockMethodEnum.ExpirationDated:
                        DateTime? retExpirationDate = InputForm.GetDateTime("Son Kullanma Tarihi Giriniz.", "mm/dd/yyyy", true);
                        returningDocument.ExpirationDate = Common.GetLastDayOfMounth((DateTime)retExpirationDate);
                        break;
                    case StockMethodEnum.LotUsed:
                        string retLotNo = InputForm.GetText("Lot Numarasını Giriniz.");
                        if (string.IsNullOrEmpty(retLotNo) == false)
                            returningDocument.LotNo = retLotNo;
                        break;
                    case StockMethodEnum.StockNumbered:
                    case StockMethodEnum.QRCodeUsed:
                    default:
                        break;
                }
            }*/
        }

        #endregion ChattelDocumentWithPurchaseNewForm_ClientSideMethods
    }
}
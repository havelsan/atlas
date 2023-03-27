
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
    public partial class ChattelDocumentInputWithAccountancyNewForm : BaseChattelDocumentInputWithAccountancyForm
    {
        protected override void PreScript()
        {
            #region ChattelDocumentInputWithAccountancyNewForm_PreScript
            base.PreScript();
            SelectStoreUsage(SelectStoreUsageEnum.UseMainStoreResources, SelectStoreUsageEnum.Nothing);
            // MaterialStockActionDetailIn.ListFilterExpression = "STOCKCARD.CREATEDSITE is null OR STOCKCARD.CREATEDSITE =" + ConnectionManager.GuidToString(Sites.SiteMerkezSagKom);

            if (_ChattelDocumentInputWithAccountancy.Store is MainStoreDefinition)
            {
               // _ChattelDocumentInputWithAccountancy.MKYS_TeslimAlan = ((MainStoreDefinition)_ChattelDocumentInputWithAccountancy.Store).GoodsAccountant.Name;
              //  _ChattelDocumentInputWithAccountancy.MKYS_TeslimAlanObjID = ((MainStoreDefinition)_ChattelDocumentInputWithAccountancy.Store).GoodsAccountant.ObjectID;
            }

            txtTotalPrice.Text = CalculateTotalPrice().ToString();

            #endregion ChattelDocumentInputWithAccountancyNewForm_PreScript

        }

        protected override void ClientSidePreScript()
        {
            #region ChattelDocumentInputWithAccountancyNewForm_ClientSidePreScript
            base.ClientSidePreScript();


            MultiSelectForm mSelectForm = new MultiSelectForm();
            mSelectForm.AddMSItem("Tıbbi Sarf", "Tıbbi Sarf", MKYS_EMalzemeGrupEnum.tibbiSarf);
            mSelectForm.AddMSItem("İlaç", "İlaç", MKYS_EMalzemeGrupEnum.ilac);
            mSelectForm.AddMSItem("Tıbbi Cihaz", "Tıbbi Cihaz", MKYS_EMalzemeGrupEnum.tibbiCihaz);
            mSelectForm.AddMSItem("Diğer", "Diğer", MKYS_EMalzemeGrupEnum.diger);

            string mkey = mSelectForm.GetMSItem(this, "Giriş Yapılacak Malzeme Grubunu Seçiniz", true);
            if (string.IsNullOrEmpty(mkey))
                throw new TTException(SystemMessage.GetMessageV2(369, "Malzeme grubu seçilmeden işleme devam edemezsiniz."));
            _ChattelDocumentInputWithAccountancy.MKYS_EMalzemeGrup = (MKYS_EMalzemeGrupEnum)mSelectForm.MSSelectedItemObject;


            if (_ChattelDocumentInputWithAccountancy.MKYS_EMalzemeGrup == MKYS_EMalzemeGrupEnum.tibbiSarf)
                MaterialStockActionDetailIn.ListFilterExpression = "OBJECTDEFID =" + ConnectionManager.GuidToString(new Guid("58d34696-808e-47de-87e0-1f001d0928a7"));

            if (_ChattelDocumentInputWithAccountancy.MKYS_EMalzemeGrup == MKYS_EMalzemeGrupEnum.ilac)
                MaterialStockActionDetailIn.ListFilterExpression = "OBJECTDEFID =" + ConnectionManager.GuidToString(new Guid("65a2337c-bc3c-4c6b-9575-ad47fa7a9a89"));

            if (_ChattelDocumentInputWithAccountancy.MKYS_EMalzemeGrup == MKYS_EMalzemeGrupEnum.tibbiCihaz)
                MaterialStockActionDetailIn.ListFilterExpression = "OBJECTDEFID =" + ConnectionManager.GuidToString(new Guid("f38f2111-0ee4-4b9f-9707-a63ac02d29f4"));



            List<double> priceCalc = new List<double>();
            double total = 0, salesTotal = 0, totalPrice = 0;
            priceCalc.Add(total);
            priceCalc.Add(salesTotal);
            priceCalc.Add(totalPrice);

            priceCalc = CalcFinalPrice(priceCalc);

            txtTotalNotDiscount.Text = priceCalc[0].ToString();
            txtSalesTotal.Text = priceCalc[1].ToString();
            txtTotalPrice.Text = priceCalc[2].ToString();
            #endregion ChattelDocumentInputWithAccountancyNewForm_ClientSidePreScript

        }

        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
            #region ChattelDocumentInputWithAccountancyNewForm_PostScript
            base.PostScript(transDef);

            foreach (ITTGridRow row in this.ChattelDocumentDetailsWithAccountancy.Rows)
            {
                ChattelDocumentInputDetailWithAccountancy chattelDocumentInputDetailWithAccountancy = this._ChattelDocumentInputWithAccountancy.ChattelDocumentInputDetailsWithAccountancy[row.Index];
                if (chattelDocumentInputDetailWithAccountancy.ConflictAmount.HasValue && chattelDocumentInputDetailWithAccountancy.ConflictAmount.Value != 0 && string.IsNullOrEmpty(chattelDocumentInputDetailWithAccountancy.ConflictSubject))
                {
                    ITTGridCell cell = row.Cells[ConflictSubjectChattelDocumentInputDetailWithAccountancy.Name];
                    cell.SetErrorText("Uyuşmazlık Miktarı sıfırdan farklı olduğundan Uyuşmazlık Konusu girilmesi zorunludur.");
                    cell.Required = true;
                }
            }
            int count = 20;
            // _ChattelDocumentInputWithAccountancy.CheckStockCardCardNofCount(count);
            #endregion ChattelDocumentInputWithAccountancyNewForm_PostScript

        }

        protected override void ClientSidePostScript(TTObjectStateTransitionDef transDef)
        {
            #region ChattelDocumentInputWithAccountancyNewForm_ClientSidePostScript
            base.ClientSidePostScript(transDef);


            #endregion ChattelDocumentInputWithAccountancyNewForm_ClientSidePostScript

        }

        #region ChattelDocumentInputWithAccountancyNewForm_ClientSideMethods
        protected override void BarcodeRead(string value)
        {
            base.BarcodeRead(value);
            Material material = null;
            IBindingList materials = _ChattelDocumentInputWithAccountancy.ObjectContext.QueryObjects("MATERIAL", "BARCODE='" + value + "'");
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
                Currency? getAmount = 0;
                string retGetAmount = InputForm.GetText("Gönderilen Miktarı Giriniz.");
                if (string.IsNullOrEmpty(retGetAmount) == false)
                {
                    if (CurrencyType.TryConvertFrom(retGetAmount, false, out getAmount) == false)
                        throw new TTException(SystemMessage.GetMessageV3(1192, new string[] { retGetAmount.ToString() }));
                }

                string retAmount = InputForm.GetText("Alınan Miktarı Giriniz.");
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

                ChattelDocumentInputDetailWithAccountancy chattelDocumentInputDetailWithAccountancy = _ChattelDocumentInputWithAccountancy.ChattelDocumentInputDetailsWithAccountancy.AddNew();
                chattelDocumentInputDetailWithAccountancy.Material = material;
                chattelDocumentInputDetailWithAccountancy.Amount = amount;
                chattelDocumentInputDetailWithAccountancy.SentAmount = getAmount;
                chattelDocumentInputDetailWithAccountancy.UnitPrice = (Currency)unitPrice;
                chattelDocumentInputDetailWithAccountancy.StockLevelType = TTObjectClasses.StockLevelType.NewStockLevel;

                switch ((StockMethodEnum)material.StockCard.StockMethod)
                {
                    case StockMethodEnum.ExpirationDated:
                        DateTime? retExpirationDate = InputForm.GetDateTime("Son Kullanma Tarihi Giriniz.", "mm/dd/yyyy", true);
                        chattelDocumentInputDetailWithAccountancy.ExpirationDate = Common.GetLastDayOfMounth((DateTime)retExpirationDate);
                        break;
                    case StockMethodEnum.LotUsed:
                        string retLotNo = InputForm.GetText("Lot Numarasını Giriniz.");
                        if (string.IsNullOrEmpty(retLotNo) == false)
                            chattelDocumentInputDetailWithAccountancy.LotNo = retLotNo;
                        break;
                    case StockMethodEnum.StockNumbered:
                    case StockMethodEnum.QRCodeUsed:
                    default:
                        break;
                }
            }
        }

        #endregion ChattelDocumentInputWithAccountancyNewForm_ClientSideMethods
    }
}
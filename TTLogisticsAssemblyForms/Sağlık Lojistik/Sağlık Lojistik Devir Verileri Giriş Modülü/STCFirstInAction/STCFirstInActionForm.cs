
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
    /// Sayım Tartı Çizelgelerinin İlk Girişi
    /// </summary>
    public partial class STCFirstInActionForm : TTForm
    {
        override protected void BindControlEvents()
        {
            cmdStock.Click += new TTControlEventDelegate(cmdStock_Click);
            cmdCreateCardDrawer.Click += new TTControlEventDelegate(cmdCreateCardDrawer_Click);
            cmdFirstTransfer.Click += new TTControlEventDelegate(cmdFirstTransfer_Click);
            cmdFirstTermOpen.Click += new TTControlEventDelegate(cmdFirstTermOpen_Click);
            cmdFirstIn.Click += new TTControlEventDelegate(cmdFirstIn_Click);
            cmdSTCCheck.Click += new TTControlEventDelegate(cmdSTCCheck_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            cmdStock.Click -= new TTControlEventDelegate(cmdStock_Click);
            cmdCreateCardDrawer.Click -= new TTControlEventDelegate(cmdCreateCardDrawer_Click);
            cmdFirstTransfer.Click -= new TTControlEventDelegate(cmdFirstTransfer_Click);
            cmdFirstTermOpen.Click -= new TTControlEventDelegate(cmdFirstTermOpen_Click);
            cmdFirstIn.Click -= new TTControlEventDelegate(cmdFirstIn_Click);
            cmdSTCCheck.Click -= new TTControlEventDelegate(cmdSTCCheck_Click);
            base.UnBindControlEvents();
        }

        private void cmdStock_Click()
        {
#region STCFirstInActionForm_cmdStock_Click
   this.cmdStock.Enabled = false;
            TTObjectContext context = new TTObjectContext(false);
            IList zeroStocks = context.QueryObjects("STCACTION","TOPLAM = 0");
            foreach(STCAction stc in zeroStocks)
            {
                if (stc.IsFirstIn.HasValue == false || stc.IsFirstIn == false)
                {
                    Stock stock = null;
                    if (stc.Material.Stocks.Count == 0)
                    {
                        stock = new Stock(context, _STCFirstInAction.MainStoreDefinition, stc.Material);
                        labelProgress.Text = stc.Material.StockCard.NATOStockNO.ToString() + " " + stc.Material.Name + " malzemenin stock 'u yaratılıyor";
                        //Application.DoEvents();
                        stc.IsFirstIn = true;
                    }
                }
            }
            try
            {
                context.Save();
                labelProgress.Text = " Sıfır Mevcutlu Stocklar Yaratılmıştır.";
                //Application.DoEvents();
                this.cmdFirstIn.Enabled = true;
            }
            catch (Exception ex)
            {
                InfoBox.Show(ex);
            }
            finally
            {
                context.Dispose();
            }
#endregion STCFirstInActionForm_cmdStock_Click
        }

        private void cmdCreateCardDrawer_Click()
        {
#region STCFirstInActionForm_cmdCreateCardDrawer_Click
   this.cmdCreateCardDrawer.Enabled = false;
            TTObjectContext context = new TTObjectContext(false);
            TTObjectContext readOnlyContext = new TTObjectContext(true);
            IBindingList allSayımTartı = readOnlyContext.QueryObjects<STCAction>("MAINSTOREDEFINITION =" + ConnectionManager.GuidToString(_STCFirstInAction.MainStoreDefinition.ObjectID));
            foreach (STCAction stc in allSayımTartı)
            {
                IList findAccountancy = stc.Material.StockCard.AccountancyStockCards.Select("ACCOUNTANCY = " + ConnectionManager.GuidToString(_STCFirstInAction.MainStoreDefinition.Accountancy.ObjectID));
                if (findAccountancy.Count == 0)
                {
                    AccountancyStockCard accountancyStockCard = new AccountancyStockCard(context);
                    accountancyStockCard.Accountancy = _STCFirstInAction.MainStoreDefinition.Accountancy ;
                    accountancyStockCard.CardAmount = 1;
                    accountancyStockCard.CardDrawer = stc.ResCardDrawer;
                    accountancyStockCard.CardOrderNO = stc.SiraNu;
                    accountancyStockCard.CreationDate = new DateTime(2011,12,31);
                    accountancyStockCard.Status = stc.Material.StockCard.Status;
                    accountancyStockCard.StockCard = stc.Material.StockCard ;
                    labelProgress.Text = stc.Material.StockCard.NATOStockNO.ToString() + " " + stc.Material.Name + " isimli malzemenin masa bilgileri yaratılıyor. ";
                    //Application.DoEvents();
                }
            }
            try
            {
                context.Save();
                labelProgress.Text = " Masa Bilgileri Yaratılmıştır.";
                //Application.DoEvents();
                this.cmdStock.Enabled = true;
            }
            catch (Exception ex)
            {
                InfoBox.Show(ex);
            }
            finally
            {
                context.Dispose();
            }
#endregion STCFirstInActionForm_cmdCreateCardDrawer_Click
        }

        private void cmdFirstTransfer_Click()
        {
#region STCFirstInActionForm_cmdFirstTransfer_Click
   this.cmdFirstTransfer.Enabled = false;
            TTObjectContext context = new TTObjectContext(false);
            IList mcStoresList = context.QueryObjects("MCACTION");
            Dictionary<Guid, Store> mcStores = new Dictionary<Guid, Store>();
            string errors = string.Empty;
            bool err = false;
            foreach (MCAction mc in mcStoresList)
            {
                if (mc.IsFirstTransfer.HasValue == false || mc.IsFirstTransfer == false)
                {
                    if (mcStores.ContainsKey(mc.Store.ObjectID) == false)
                        mcStores.Add(mc.Store.ObjectID, mc.Store);
                }
            }
            foreach (KeyValuePair<Guid, Store> mcbyStore in mcStores)
            {
                StockFirstTransfer stockFirstTransfer = new StockFirstTransfer(context);
                stockFirstTransfer.CurrentStateDefID = StockFirstTransfer.States.New;
                stockFirstTransfer.Store = _STCFirstInAction.MainStoreDefinition;
                stockFirstTransfer.TransactionDate = Common.RecTime();
                stockFirstTransfer.DestinationStore = mcbyStore.Value ;
                labelProgress.Text = "İlk Transfer İşlemi " + mcbyStore.Value.Name.ToString() + " deposu için hazırlanıyor.";
                //Application.DoEvents();
                IList mcs = context.QueryObjects("MCACTION", "STORE = " + ConnectionManager.GuidToString(mcbyStore.Value.ObjectID));
                foreach (MCAction mc in mcs)
                {
                    if (mc.IsFirstTransfer.HasValue == false || mc.IsFirstTransfer == false)
                    {
                        StockFirstTransferDetail stockFirstTransferDetail = new StockFirstTransferDetail(context);
                        stockFirstTransferDetail.Material = mc.STCAction.Material;
                        stockFirstTransferDetail.Amount = mc.MuvakkatenVerilen;
                        stockFirstTransferDetail.StockLevelType = StockLevelType.NewStockLevel;
                        stockFirstTransferDetail.Status = StockActionDetailStatusEnum.New;
                        stockFirstTransfer.StockFirstTransferDetails.Add(stockFirstTransferDetail);
                        if (mc.STCAction.Material.StockCard.StockMethod == StockMethodEnum.SerialNumbered)
                        {
                            if(mc.STCAction.Material is FixedAssetDefinition)
                            {
                                IList dcActions = mc.STCAction.DCActions.Select("STORE = " + ConnectionManager.GuidToString(mc.Store.ObjectID));
                                foreach (DCAction dcAction in dcActions)
                                {
                                    IList tdemirbaslar = ((FixedAssetDefinition)dcAction.STCAction.Material).FixedAssetMaterialDefinitions.Select("FIXEDASSETNO ='" + dcAction.FixedAssetNO + "'");
                                    if (tdemirbaslar.Count > 1)
                                    {
                                        errors += "\r\nHatalı demirbaş numarası. Birden Fazla" + dcAction.STCAction.Material.StockCard.NATOStockNO + " - " + dcAction.STCAction.Material.Name;
                                        err = true;
                                    }
                                    else if (tdemirbaslar.Count == 0)
                                    {
                                        errors += "\r\nHatalı demirbaş numarası. Sıfır" + dcAction.STCAction.Material.StockCard.NATOStockNO + " - " + dcAction.STCAction.Material.Name;
                                        err = true;
                                    }
                                    else
                                    {
                                        FixedAssetOutDetail fixedAssetOutDetail = new FixedAssetOutDetail(context);
                                        fixedAssetOutDetail.FixedAssetMaterialDefinition = (FixedAssetMaterialDefinition)tdemirbaslar[0];
                                        stockFirstTransferDetail.FixedAssetOutDetails.Add(fixedAssetOutDetail);
                                    }
                                }
                            }
                        }
                        
                        if (mc.STCAction.Material.StockCard.StockMethod == StockMethodEnum.ExpirationDated || mc.STCAction.Material.StockCard.StockMethod == StockMethodEnum.LotUsed)
                        {
                            OuttableLot outtableLot = new OuttableLot(context);
                            if (mc.STCAction.SKTarihi != null)
                                outtableLot.ExpirationDate = mc.STCAction.SKTarihi;
                            else
                                outtableLot.ExpirationDate =Common.GetLastDayOfMounth(Common.MinDateTime());
                            outtableLot.LotNo = "-";
                            outtableLot.Amount = mc.MuvakkatenVerilen;
                            outtableLot.isUse = true;
                            outtableLot.StockActionDetailOut = stockFirstTransferDetail;
                        }

                        labelProgress.Text = mc.STCAction.Material.StockCard.NATOStockNO + " " +mc.STCAction.Material.Name  + " için  İlk Transfer İşlemi hazırlanıyor.";
                        //Application.DoEvents();
                    }
                    mc.IsFirstTransfer = true;
                }
                stockFirstTransfer.Update();
                stockFirstTransfer.CurrentStateDefID = StockFirstTransfer.States.Completed;
            }
            if (err == false)
            {
                try
                {
                    context.Save();
                    labelProgress.Text = " İlk Transfer İşlemi tamamlanmıştır.";
                    //Application.DoEvents();
                    this.AddStateButton(STCFirstInAction.States.Completed);
                }
                catch (Exception ex)
                {
                    InfoBox.Show(ex);
                }
                finally
                {
                    context.Dispose();
                }
                labelProgress.Text = " İlk Transfer İşlemileri Tamamlanmıştır.";
                //Application.DoEvents();
            }
            else
            {
                throw new TTException(errors);
            }
#endregion STCFirstInActionForm_cmdFirstTransfer_Click
        }

        private void cmdFirstTermOpen_Click()
        {
#region STCFirstInActionForm_cmdFirstTermOpen_Click
   this.cmdFirstTermOpen.Enabled = false;
            TTObjectContext termContext = new TTObjectContext(false);
            AccountingTerm firstTerm = new AccountingTerm(termContext);
            firstTerm.Accountancy = _STCFirstInAction.MainStoreDefinition.Accountancy;
            firstTerm.CostingMethod = CostingMethodEnum.FIFO;
            firstTerm.IsFirstTerm = true;
            firstTerm.StartDate = Convert.ToDateTime("01.01.2011");
            firstTerm.EndDate = Convert.ToDateTime("31.12.2011");
            firstTerm.Status = AccountingTermStatusEnum.Open;
            firstTerm.Description = "İlk Devir Hesap Dönemi";
            try
            {
                termContext.Save();
                this.cmdSTCCheck.Enabled = true;
            }
            catch (Exception ex)
            {
                InfoBox.Show(ex);
            }
#endregion STCFirstInActionForm_cmdFirstTermOpen_Click
        }

        private void cmdFirstIn_Click()
        {
#region STCFirstInActionForm_cmdFirstIn_Click
   this.cmdFirstIn.Enabled = false;
            //TTObjectContext readOnlyContext = new TTObjectContext(true);
            TTObjectContext objectContext = new TTObjectContext(false);
            Dictionary<Guid, STCAction> consummedMaterials = new Dictionary<Guid, STCAction>();
            Dictionary<Guid, STCAction> drugs = new Dictionary<Guid, STCAction>();
            Dictionary<Guid, STCAction> fixedassetMaterials = new Dictionary<Guid, STCAction>();
            IBindingList allSayımTartı = objectContext.QueryObjects<STCAction>("MAINSTOREDEFINITION =" + ConnectionManager.GuidToString(_STCFirstInAction.MainStoreDefinition.ObjectID));
            labelProgress.Text = "Sayım Tartı Çizelgesi İlk Giriş işlemi için hazırlanıyor.";
            //Application.DoEvents();
            if (allSayımTartı.Count > 0)
            {
                foreach (STCAction stc in allSayımTartı)
                {
                    if (stc.IsFirstIn.HasValue == false || stc.IsFirstIn == false)
                    {
                        if (stc.Material is ConsumableMaterialDefinition)
                            consummedMaterials.Add(stc.ObjectID, stc);
                        if (stc.Material is DrugDefinition)
                            drugs.Add(stc.ObjectID, stc);
                        if (stc.Material is FixedAssetDefinition)
                            fixedassetMaterials.Add(stc.ObjectID, stc);
                    }
                }
            }
            if(consummedMaterials.Count > 0)
            {
                labelProgress.Text = "Sarf Malzemeler için İlk Giriş işlemi yapılıyor.";
                //Application.DoEvents();
                _STCFirstInAction.CreateStockFirstIn(objectContext, consummedMaterials, _STCFirstInAction.MainStoreDefinition);
            }
            if(drugs.Count>0)
            {
                labelProgress.Text = "İlaçlar için İlk Giriş işlemi yapılıyor.";
                //Application.DoEvents();
                _STCFirstInAction.CreateStockFirstIn(objectContext, drugs, _STCFirstInAction.MainStoreDefinition);
            }
            if(fixedassetMaterials.Count>0)
            {
                labelProgress.Text = "Demirbaşlar için İlk Giriş işlemi yapılıyor.";
                //Application.DoEvents();
                _STCFirstInAction.CreateStockFirstIn(objectContext, fixedassetMaterials, _STCFirstInAction.MainStoreDefinition);
            }
            labelProgress.Text = "İlk Giriş İşlemleri TAMAMLANDI.";
            //Application.DoEvents();
            this.cmdFirstTransfer.Enabled = true;
#endregion STCFirstInActionForm_cmdFirstIn_Click
        }

        private void cmdSTCCheck_Click()
        {
#region STCFirstInActionForm_cmdSTCCheck_Click
   bool err = false;
            string errmsg = string.Empty;
            this.cmdSTCCheck.Enabled = false;
            TTObjectContext readOnlyContext = new TTObjectContext(true);
            IBindingList allSayımTartı = readOnlyContext.QueryObjects<STCAction>("MAINSTOREDEFINITION =" + ConnectionManager.GuidToString(_STCFirstInAction.MainStoreDefinition.ObjectID));
            Dictionary<Guid, STCAction> materialList = new Dictionary<Guid, STCAction>();
            if (allSayımTartı.Count > 0)
            {
                foreach (STCAction stc in allSayımTartı)
                {
                    if(stc.Material.StockCard != null)
                    {
                        labelProgress.Text = stc.Material.StockCard.NATOStockNO + " " + stc.Material.Name + " için  Sayım Tartı Çizelgesi Kontrol Ediliyor.";
                        //Application.DoEvents();
                        
                        //Aynı Malzeme farklı sıra numarasıyla girilmişse
                        if (materialList.ContainsKey(stc.Material.ObjectID))
                        {
                            err = true;
                            errmsg += stc.SiraNu.ToString() + " sıra numaralı " + stc.Material.StockCard.NATOStockNO.ToString() + " " + stc.Material.Name + " malzeme daha önce " + materialList[stc.Material.ObjectID].SiraNu.ToString() + "sıra numarasıyla girilmiştir. \r\n İlk Girilen İşlem No = " + materialList[stc.Material.ObjectID].SLFAction.ID.ToString() + "\r\n Hatalı Girilen İşlem No :"+ stc.SLFAction.ID.ToString() + "\r\n";
                        }
                        else
                        {
                            materialList.Add(stc.Material.ObjectID, stc);
                        }
                        double mToplam = 0;
                        double dmToplam = 0;
                        Dictionary<Store, double> dmDetails = new Dictionary<Store, double>();
                        foreach (MCAction mcAction in stc.MCActions)
                        {
                            mToplam += (double)mcAction.MuvakkatenVerilen;
                            if (stc.Material.StockCard.StockMethod == StockMethodEnum.SerialNumbered)
                                dmDetails.Add(mcAction.Store, (double)mcAction.MuvakkatenVerilen);
                        }

                        // Muvakkat Sayısı Tutuyormu
                        if (stc.MuvakkatenVerilen != mToplam)
                        {
                            err = true;
                            errmsg += stc.SiraNu.ToString() + " sıra numaralı " +stc.Material.StockCard.NATOStockNO.ToString() +" "+ stc.Material.Name + " malzemenin muvakkat detayları yanlış. Olması Gereken : " + stc.MuvakkatenVerilen.ToString() + " Olan :" + mToplam.ToString() + "\r\n";
                        }

                        // Sarf Malzemeye Kullanılmış ve HEK mevcut girilmiş mi
                        if (stc.Material is ConsumableMaterialDefinition || stc.Material is DrugDefinition)
                        {
                            if (stc.KullanilmisMevcut > 0)
                            {
                                err = true;
                                errmsg += stc.SiraNu.ToString() + " sıra numaralı " + stc.Material.StockCard.NATOStockNO.ToString() + " " + stc.Material.Name + " malzemenin kullanılmış mevcut girilmiştir.\r\n";
                            }
                            if (stc.HEKMevcut > 0)
                            {
                                err = true;
                                errmsg += stc.SiraNu.ToString() + " sıra numaralı " + stc.Material.StockCard.NATOStockNO.ToString() + " " + stc.Material.Name + " malzemenin HEK mevcut girilmiştir.\r\n";
                            }
                        }
                        
                        if (stc.Material.StockCard.StockMethod == StockMethodEnum.SerialNumbered)
                        {
                            // Demirbaş Sayısı Tutuyormu
                            if (stc.Toplam != ((double)stc.DCActions.Count))
                            {
                                err = true;
                                errmsg += stc.SiraNu.ToString() + " sıra numaralı " + stc.Material.StockCard.NATOStockNO.ToString() + " " + stc.Material.Name + " malzemenin demirbaş detayları yanlış. Olması Gereken : " + stc.Toplam.ToString() + " Olan :" + stc.DCActions.Count.ToString() + "\r\n";
                            }

                            //Depolara Göre Demirbaş Sayısı Tutuyormu
                            foreach (KeyValuePair<Store, double> fixedassetCount in dmDetails)
                            {
                                IList dcActions = readOnlyContext.QueryObjects("DCACTION", "STCACTION =" + ConnectionManager.GuidToString(stc.ObjectID) + " AND STORE = " + ConnectionManager.GuidToString(fixedassetCount.Key.ObjectID));
                                if (dcActions.Count != fixedassetCount.Value)
                                {
                                    err = true;
                                    errmsg += stc.SiraNu.ToString() + " sıra numaralı " +stc.Material.StockCard.NATOStockNO.ToString() +" " +stc.Material.Name + " malzemenin " + fixedassetCount.Key.Name + " deposunda demirbaş detayları yanlış. Olması Gereken : " + fixedassetCount.Value.ToString() + " Olan :" + dcActions.Count.ToString() + "\r\n";
                                }
                            }
                        }
                    }
                    else
                    {
                        err = true;
                        errmsg += stc.SiraNu.ToString() + " sıra numaralı " +stc.Material.Name + " malzemenin stok kartı bulunmamaktadır.\r\n";
                    }

                }
                if (err)
                {
                    labelProgress.Text = "Sayım Tartı Çizelgesi İlk Giriş işlemi için UYGUN DEĞİLDİR.";
                    //Application.DoEvents();
                    throw new TTException(errmsg);
                }
                else
                {
                    labelProgress.Text = "Sayım Tartı Çizelgesi İlk Giriş işlemi için UYGUNDUR.";
                    //Application.DoEvents();
                    this.cmdCreateCardDrawer.Enabled = true;
                }

            }
#endregion STCFirstInActionForm_cmdSTCCheck_Click
        }

        protected override void PreScript()
        {
#region STCFirstInActionForm_PreScript
    base.PreScript();
#endregion STCFirstInActionForm_PreScript

            }
            
        protected override void ClientSidePreScript()
        {
#region STCFirstInActionForm_ClientSidePreScript
    base.ClientSidePreScript();
            
            this.cmdSTCCheck.Enabled = false;
            this.cmdFirstIn.Enabled = false;
            this.cmdFirstTransfer.Enabled = false ;
            this.cmdOK.Visible = false ;
            this.cmdCreateCardDrawer.Enabled = false;
            this.cmdStock.Enabled = false;
            this.DropStateButton(STCFirstInAction.States.Completed);
            
            TTObjectContext readOnlyObjectContext = new TTObjectContext(true);
            
            IList openFirstTerm = readOnlyObjectContext.QueryObjects("ACCOUNTINGTERM","ISFIRSTTERM = 1");
            if(openFirstTerm.Count > 0 )
            {
                this.cmdSTCCheck.Enabled = true;
                this.cmdFirstTermOpen.Enabled = false;
            }
            MainStoreDefinition mainStore = new MainStoreDefinition();
            IList mainStores = TTObjectClasses.MainStoreDefinition.GetAllMainStores(readOnlyObjectContext);
            if (mainStores.Count == 0)
            {
                throw new TTException("İşlemin yapılacağı ana depo bulunamadığından işleme devam edemezsiniz.");
            }
            if (mainStores.Count == 1)
            {
                mainStore = (MainStoreDefinition)mainStores[0];
            }
            else
            {
                MultiSelectForm mSelectForm = new MultiSelectForm();
                foreach (MainStoreDefinition allMainStore in mainStores)
                {
                    mSelectForm.AddMSItem(allMainStore.Name, allMainStore.ObjectID.ToString(), allMainStore);
                }

                string mkey = mSelectForm.GetMSItem(this, "İlgili Ana Depoyu Seçiniz", true);
                if (string.IsNullOrEmpty(mkey))
                {
                    throw new TTException("İşlemin yapılacağı ana depo seçilmeden işleme devam edemezsiniz.");
                }
                else
                {
                    mainStore = mSelectForm.MSSelectedItemObject as MainStoreDefinition;
                }
            }
            _STCFirstInAction.MainStoreDefinition = mainStore;
#endregion STCFirstInActionForm_ClientSidePreScript

        }
    }
}
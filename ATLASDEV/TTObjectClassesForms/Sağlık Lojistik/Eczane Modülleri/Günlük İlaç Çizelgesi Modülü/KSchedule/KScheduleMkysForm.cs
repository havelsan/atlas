
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
    /// K-Çizelgesi MKYS 
    /// </summary>
    public partial class KScheduleMkysForm : StockActionBaseForm
    {
        override protected void BindControlEvents()
        {
            btnMKYSGonder.Click += new TTControlEventDelegate(btnMKYSGonder_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            btnMKYSGonder.Click -= new TTControlEventDelegate(btnMKYSGonder_Click);
            base.UnBindControlEvents();
        }

        private void btnMKYSGonder_Click()
        {
#region KScheduleMkysForm_btnMKYSGonder_Click
 //  System.Windows.Forms.Cursor current = System.Windows.Forms.Cursor.Current;
       //     System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            
            try
            {
                MkysServis.makbuzInsertCikisItem cikisItem = new MkysServis.makbuzInsertCikisItem();
                cikisItem.islemTuru = (MkysServis.ECikisIslemTuru)(int)_KSchedule.MKYS_CikisIslemTuru.Value;
                cikisItem.butceTurID = (MkysServis.EButceTurID)(int)_KSchedule.MKYS_EButceTur;
                cikisItem.stokHareketTurID = (MkysServis.ECikisStokHareketTurID)(int)_KSchedule.MKYS_CikisStokHareketTuru;
                cikisItem.makbuzNo = _KSchedule.MKYS_MakbuzNo.Value;
                cikisItem.makbuzTarihi = _KSchedule.MKYS_MakbuzTarihi.Value;
                cikisItem.muayaneNo = _KSchedule.MKYS_MuayeneNo;
                cikisItem.muayeneTarihi = _KSchedule.MKYS_MuayeneTarihi;
                cikisItem.dayanagiBelgeNo = "1";  // Zorunlu alan, boş geçilirse hata alınıyor, şimdilik 1 gönderdik
                cikisItem.dayanagiBelgeTarihi = null;

                if(_KSchedule.MKYS_DepoKayitNo.HasValue)
                    cikisItem.depoKayitNo = _KSchedule.MKYS_DepoKayitNo.Value;

                cikisItem.teslimEden = _KSchedule.MKYS_TeslimEden;
                cikisItem.fisAciklama = _KSchedule.Description;
                cikisItem.teslimAlan = _KSchedule.MKYS_TeslimAlan;
                cikisItem.cikisYapilanDepoKayitNo = _KSchedule.MKYS_CikisYapilanDepoKayitNo; // Zorunlu alan değil, boş geçilse de başarılı kaydediyor
                
                if(_KSchedule.DestinationStore != null && _KSchedule.DestinationStore is SubStoreDefinition)
                {
                    //_KSchedule.MKYS_KarsiBirimKayitNo = ((SubStoreDefinition)_KSchedule.DestinationStore).SubStoreMKYS.birimKayitNo;
                    _KSchedule.MKYS_KarsiBirimKayitNo = ((SubStoreDefinition)_KSchedule.DestinationStore).UnitRegistryNo;
                    cikisItem.cikisBirimKayitNo = _KSchedule.MKYS_KarsiBirimKayitNo;
                }
                //cikisItem.cikisBirimKayitNo = _KSchedule.MKYS_KarsiBirimKayitNo;             // Zorunlu alan değil, boş geçilse de başarılı kaydediyor
                cikisItem.cikisYapilanKisiTCKimlikNo = _KSchedule.MKYS_CikisYapilanKisiTCNo; // Zorunlu alan değil, boş geçilse de başarılı kaydediyor
                //cikisItem.doktorTCKimlikNo = null;
                //cikisItem.digerBirimAdi = null;
                cikisItem.hbysID = "atlas";
                
                List<MkysServis.stokHareketCikisItem> cikisStokHareketList = new List<MkysServis.stokHareketCikisItem>();
                
                foreach(StockActionDetail stockActionDetail in _KSchedule.StockActionDetails)
                {
                    foreach(StockTransaction stockTransaction in stockActionDetail.StockTransactions.Select(""))
                    {
                        foreach(StockTransactionDetail stockTransactionDetail in stockTransaction.OutStockTransactionDetails)
                        {
                            MkysServis.stokHareketCikisItem stokHareketCikisItem = new MkysServis.stokHareketCikisItem();
                            stokHareketCikisItem.girisStokHareketID = stockTransactionDetail.InStockTransaction.StockActionDetail.MKYS_StokHareketID.Value;
                            stokHareketCikisItem.cikisMiktar = Convert.ToDecimal(stockTransactionDetail.Amount);
                            stokHareketCikisItem.hbysStokHareketID = stockActionDetail.ObjectID.ToString();
                            //stokHareketCikisItem.cikisTibbiCihazKunyeNo = null;
                            //stokHareketCikisItem.cikisDemirbasNo = 1;
                            //stokHareketCikisItem.cikisEdinmeYili = 1;
                            cikisStokHareketList.Add(stokHareketCikisItem);
                        }
                    }
                }
                
                if(cikisStokHareketList.Count > 0)
                    cikisItem.cikisStokHareketList = cikisStokHareketList.ToArray();

                _KSchedule.MKYS_GonderimTarihi = Common.RecTime();
                _KSchedule.MKYS_GidenVeri = TTUtils.SerializationHelper.XmlSerializeObject(cikisItem);
                MkysServis.makbuzInsertCikisSonuc makbuzInsertCikisSonuc = MkysServis.WebMethods.makbuzInsertCikisSync(Sites.SiteLocalHost,Common.CurrentResource.MkysUserName, Common.CurrentResource.MkysPassword, cikisItem);
                _KSchedule.MKYS_GelenVeri = TTUtils.SerializationHelper.XmlSerializeObject(makbuzInsertCikisSonuc);
                
                if (!makbuzInsertCikisSonuc.basariDurumu)
                {
                    InfoBox.Show(makbuzInsertCikisSonuc.mesaj);
                    return;
                }


                _KSchedule.MKYS_AyniyatMakbuzID = makbuzInsertCikisSonuc.islemKayitNo;
                
                foreach(MkysServis.sonucStokHareketItem sonucStokHareketItem in makbuzInsertCikisSonuc.sonucStokHareketList)
                {
                    StockActionDetail stockActionDetail = _KSchedule.ObjectContext.GetObject(Guid.Parse(sonucStokHareketItem.hbysStokHareketID), typeof(StockActionDetail)) as StockActionDetail;
                    stockActionDetail.MKYS_StokHareketID = sonucStokHareketItem.stokHareketID;
                }
                
                InfoBox.Show("Belge MKYS'ye başarılı bir şekilde kaydedildi. İşlem tamamlanacaktır.");
                this._KSchedule.MKYSControl = true;



                foreach (TTObjectStateTransitionDef transDef in _KSchedule.CurrentStateDef.OutgoingTransitions.Values)
                {
                    if (transDef.ToStateDef.StateDefID == DistributionDocument.States.Completed)
                    {
                        this.AdvanceState(transDef);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                InfoBox.Show(ex);
            }
            finally
            {
          //      System.Windows.Forms.Cursor.Current = current;
            }
#endregion KScheduleMkysForm_btnMKYSGonder_Click
        }

        protected override void PreScript()
        {
#region KScheduleMkysForm_PreScript
    base.PreScript();
            
            this._KSchedule.MKYSControl = false;
              _KSchedule.SetMKYSProperties();
            
            if ( _KSchedule is KScheduleDaily )
            {
                this.DropCurrentStateReport(typeof(TTReportClasses.I_KScheduleReport));
                this.DropCurrentStateReport(typeof(TTReportClasses.I_KScheduleBarcodeReport));
            }
            else
            {
                this.DropCurrentStateReport(typeof(TTReportClasses.I_KScheduleDailyReport));
            }
            
            KSchedule kSchedule = _KSchedule;
            Dictionary<Guid, object> drugsHashtable = new Dictionary<Guid, object>();
            foreach (KScheduleMaterial kScheduleMaterial in _KSchedule.StockActionOutDetails)
            {
                BindingList<Stock> stocks = Stock.GetStoreMaterial(kSchedule.ObjectContext, kSchedule.Store.ObjectID, kScheduleMaterial.Material.ObjectID);
                if (stocks.Count > 0)
                {
                    Stock stock = stocks[0];
                    kScheduleMaterial.StoreInheld = stock.Inheld;
                }
                if (drugsHashtable.ContainsKey(kScheduleMaterial.Material.ObjectID))
                {
                    KSchedule.KScheduleTotalMaterial material = ((KSchedule.KScheduleTotalMaterial)drugsHashtable[kScheduleMaterial.Material.ObjectID]);
                    material.QuarantinaNo = Convert.ToString(material.QuarantinaNo) + "," + Convert.ToString(kScheduleMaterial.QuarantinaNO);
                    material.TotalAmount = (double)material.TotalAmount + (double)kScheduleMaterial.Amount;
                    drugsHashtable[kScheduleMaterial.Material.ObjectID] = material;
                }
                else
                {
                    KSchedule.KScheduleTotalMaterial kScheludeTotalMaterial = new KSchedule.KScheduleTotalMaterial();
                    kScheludeTotalMaterial.QuarantinaNo = Convert.ToString(kScheduleMaterial.QuarantinaNO);
                    kScheludeTotalMaterial.TotalAmount = (double)kScheduleMaterial.Amount;
                    drugsHashtable.Add(kScheduleMaterial.Material.ObjectID, kScheludeTotalMaterial);
                }

            }

            bool infection = false;
            foreach (KeyValuePair<Guid, object> drugDetails in drugsHashtable)
            {
                Material material = (Material)kSchedule.ObjectContext.GetObject(new Guid(drugDetails.Key.ToString()), "MATERIAL");
                KSchedule.KScheduleTotalMaterial kScheduleTotalMaterial = ((KSchedule.KScheduleTotalMaterial)drugDetails.Value);
                ITTGridRow addedRow = Drugs.Rows.Add();
                addedRow.Cells[0].Value = material.ObjectID;
                addedRow.Cells[1].Value = kScheduleTotalMaterial.TotalAmount;
                addedRow.Cells[2].Value = Convert.ToString(kScheduleTotalMaterial.QuarantinaNo);
                if (((DrugDefinition)material).InfectionApproval.HasValue)
                {
                    if ((bool)((DrugDefinition)material).InfectionApproval)
                    {
                        infection = true;
                    }
                }
            }
            if (infection)
            {
                this.DropStateButton(KSchedule.States.RequestPreparation);
            }
            else
            {
                this.DropStateButton(KSchedule.States.InfectionApproval);
            }
#endregion KScheduleMkysForm_PreScript

            }
            
#region KScheduleMkysForm_Methods
        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
            base.AfterContextSavedScript(transDef);
            if (transDef != null)
            {
                if (transDef.ToStateDefID == KSchedule.States.RequestFulfilled)
                {
                    Dictionary<string, TTReportTool.PropertyCache<object>> parameter = new Dictionary<string, TTReportTool.PropertyCache<object>>();
                    TTReportTool.PropertyCache<object> objectID = new TTReportTool.PropertyCache<object>();
                    objectID.Add("VALUE", _KSchedule.ObjectID.ToString());
                    parameter.Add("TTOBJECTID", objectID);
                    TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_KScheduleReport), true, 1, parameter);
                    
                    
                    Dictionary<string, TTReportTool.PropertyCache<object>> parameterBarcode = new Dictionary<string, TTReportTool.PropertyCache<object>>();
                    TTReportTool.PropertyCache<object> objectIDBARCODE = new TTReportTool.PropertyCache<object>();
                    objectIDBARCODE.Add("VALUE", _KSchedule.ObjectID.ToString());
                    parameterBarcode.Add("TTOBJECTID", objectIDBARCODE);
                    TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_KScheduleBarcodeReport), true, 1, parameterBarcode);
                    
                    
                }
            }
        }
        
#endregion KScheduleMkysForm_Methods
    }
}
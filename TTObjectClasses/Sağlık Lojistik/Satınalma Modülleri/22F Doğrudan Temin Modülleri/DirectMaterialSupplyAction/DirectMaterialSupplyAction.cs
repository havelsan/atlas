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

using TTStorageManager;
using System.Runtime.Versioning;



namespace TTObjectClasses
{
    /// <summary>
    /// Doğrudan Malzeme Tedarik 22f
    /// </summary>
    public partial class DirectMaterialSupplyAction : EpisodeAction
    {
        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof (DirectMaterialSupplyAction).Name)
                return;
            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;
            if (fromState == DirectMaterialSupplyAction.States.Request && toState == DirectMaterialSupplyAction.States.Completed)
                PostTransition_Request2Completed();
        }

        protected void PostTransition_Request2Completed()
        {
            // From State : Request   To State : Completed
#region PostTransition_Request2Completed
            if (TransDef != null)
            {
                StockOutOperationForMyTreatmentMaterials();
            }
#endregion PostTransition_Request2Completed
        }

        public DirectMaterialSupplyAction(TTObjectContext objectContext, DateTime? DateOfSurgery, DirectPurchaseGrid DirectPurchaseGrid): this (objectContext)
        {
            SetMandatoryEpisodeActionProperties(DirectPurchaseGrid.EpisodeAction, DirectPurchaseGrid.EpisodeAction.FromResource, false);
            this.DateOfSurgery = DateOfSurgery;
            IsImmediate = DirectPurchaseGrid.IsImmediate;
            BaseTreatmentMaterial tmat = new BaseTreatmentMaterial(objectContext);
            tmat.Material = DirectPurchaseGrid.Material;
            tmat.Amount = DirectPurchaseGrid.Amount;
            tmat.Note = DirectPurchaseGrid.Note;
            tmat.EpisodeAction = this;
            DirectPurchaseGrid.DirectMaterialSupplyAction = this;
            RequestType = SupplyRequestTypeEnum.sarfMalzeme;
            Store = MasterResource.Store;
            CurrentStateDefID = DirectMaterialSupplyAction.States.New;
            ProcedureByUser = Common.CurrentResource;
        }

        public bool CheckSupplyPurchaseStatusByDirectPurchaseGrid(DirectPurchaseGrid DirectPurchaseGrid)
        {
            bool returnType = false;
            string BolumId = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXEHIPBOLUMID", "");
            string ehipWsUsername = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXEHIPKULLANICIADI", "");
            string ehipWsPassword = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXEHIPKULLANICISIFRESI", "");
            XXXXXXTasinirMal.IslemSonuc sonuc = XXXXXXTasinirMal.WebMethods.GetEhipWsEntegreKeyByBolumIdSync(Sites.SiteLocalHost, BolumId, ehipWsUsername, ehipWsPassword);
            if (DirectPurchaseGrid.DirectMaterialSupplyAction.XXXXXXKayitId != null)
            {
                XXXXXXTasinirMal.IslemSonuc talepSonuc = XXXXXXTasinirMal.WebMethods.TalepKontrolSync(Sites.SiteLocalHost, sonuc.Mesaj, DirectPurchaseGrid.DirectMaterialSupplyAction.XXXXXXKayitId.ToString());
                if (talepSonuc.IslemBasarili)
                    returnType = true;
            }

            return returnType;
        }

        public void StockOutOperationForMyTreatmentMaterials()
        {
            if (TTObjectClasses.SystemParameter.IsWorkWithOutStock == false)
            {
                foreach (BaseTreatmentMaterial treatmentMaterial in TreatmentMaterials)
                {
                    bool stockout = false;
                    SubActionMaterial.StockOutStores stockOutStores = new SubActionMaterial.StockOutStores();
                    stockOutStores.store = Store;
                    stockOutStores.subActionMaterials.Add(treatmentMaterial);
                    Store store = stockOutStores.store;
                    Stock stock = store.GetStock(treatmentMaterial.Material);
                    if (stock.Inheld != null)
                    {
                        if (stock.Inheld > 0 && stock.Inheld >= treatmentMaterial.Amount)
                        {
                            StockOut stockOut = new StockOut(ObjectContext);
                            stockOut.CurrentStateDefID = StockOut.States.New;
                            stockOut.Store = store;
                            StockActionDetailOut stockActionDetailOut = (StockActionDetailOut)stockOut.StockOutMaterials.AddNew();
                            stockActionDetailOut.Material = treatmentMaterial.Material;
                            stockActionDetailOut.Amount = treatmentMaterial.Amount;
                            stockActionDetailOut.StockLevelType = StockLevelType.NewStockLevel;
                            stockActionDetailOut.Status = StockActionDetailStatusEnum.New;
                            treatmentMaterial.StockActionDetail = stockActionDetailOut;
                            stockOut.Update();
                            stockOut.CurrentStateDefID = StockOut.States.Completed;
                        //this.ObjectContext.Update();
                        //this.CurrentStateDefID = SubActionMaterial.States.Completed;
                        }
                        else
                        {
                            string message = TTUtils.CultureService.GetText("M27254", "Yeterli Mevcut yoktur.")+ " Malzeme : " + treatmentMaterial.Material.Name.ToString() + " " + treatmentMaterial.Material.NATOStockNO.ToString() + " İşlem No :  " + treatmentMaterial.EpisodeAction.ID.ToString();
                            throw new TTException(message);
                        }
                    }
                }
            }
        }

        [TTStorageManager.Attributes.TTRequiredRoles()]
        public static string Send22F_SupplyRequestToXXXXXX_TS(DirectMaterialSupplyAction _DirectMaterialSupplyAction)
        {
            return _DirectMaterialSupplyAction.Send22F_SupplyRequestToXXXXXX(_DirectMaterialSupplyAction);
        }

        public string Send22F_SupplyRequestToXXXXXX(DirectMaterialSupplyAction _DirectMaterialSupplyAction)
        {
            string errorMessage = string.Empty;
            try
            {
                List<XXXXXXTasinirMal.TalepBildirimDetayInfoWS> detayList = new List<XXXXXXTasinirMal.TalepBildirimDetayInfoWS>();
                List<XXXXXXTasinirMal.VenStokInfo> infoReturnList;
                XXXXXXTasinirMal.VenStokAramaKriterInfo kr;
                XXXXXXTasinirMal.TalepBildirimInfoWS talep = new XXXXXXTasinirMal.TalepBildirimInfoWS();
                string BolumId = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXEHIPBOLUMID", "");
                string ehipWsUsername = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXEHIPKULLANICIADI", "");
                string ehipWsPassword = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXEHIPKULLANICISIFRESI", "");
                XXXXXXTasinirMal.IslemSonuc sonuc = XXXXXXTasinirMal.WebMethods.GetEhipWsEntegreKeyByBolumIdSync(Sites.SiteLocalHost, BolumId, ehipWsUsername, ehipWsPassword);
                foreach (BaseTreatmentMaterial treatmentMaterial in _DirectMaterialSupplyAction.TreatmentMaterials)
                {
                    kr = new XXXXXXTasinirMal.VenStokAramaKriterInfo();
                    kr.MalzemeKodu = treatmentMaterial.Material.StockCard.NATOStockNO;
                    infoReturnList = XXXXXXTasinirMal.WebMethods.GetStokListSync(Sites.SiteLocalHost, sonuc.Mesaj, kr).ToList();
                    if (infoReturnList.Count == 0)
                    {
                        errorMessage += treatmentMaterial.Material.Name + " , ";
                    }

                    if (infoReturnList.Count >= 1)
                    {
                        XXXXXXTasinirMal.TalepBildirimDetayInfoWS detay = new XXXXXXTasinirMal.TalepBildirimDetayInfoWS();
                        detay.Aciklama = treatmentMaterial.Note;
                        detay.MalzemeKayitId = infoReturnList[0].MalzemeKayitId;
                        detay.MkysOlcuBirimKodu = infoReturnList[0].OlcuBirimi;
                        detay.RedimoStokkartId = infoReturnList[0].RedimoStokkartId;
                        detay.TalepMiktar = (double)treatmentMaterial.Amount;
                        detay.SutKodu = infoReturnList[0].SutKodu;
                        detayList.Add(detay);
                        infoReturnList = null;
                    }
                //TODO: SERVER KONTROLÜ OLMASIMI GEREKİYOR YOKSA CLIENTDAMI
                }

                talep.Aciklama = _DirectMaterialSupplyAction.DescriptionForWorkList;
                talep.TalepTurId = (XXXXXXTasinirMal.ETalepTur)Enum.Parse(typeof (XXXXXXTasinirMal.ETalepTur), ((int)(SupplyRequestTypeEnum)RequestType).ToString());
                talep.TalepNedeni = _DirectMaterialSupplyAction.DescriptionForWorkList;
                talep.Acil = _DirectMaterialSupplyAction.IsImmediate == null || _DirectMaterialSupplyAction.IsImmediate.Value == false ? 0 : 1;
                talep.MkysDepoKayitNo = ((MainStoreDefinition)(_DirectMaterialSupplyAction.DestinationStore)).StoreRecordNo.Value;
                talep.TalepKullaniciTC = long.Parse("10000000000"); //long.Parse(_DirectMaterialSupplyAction.ProcedureByUser.UniqueNo);
                talep.TalepTarihi = (DateTime)_DirectMaterialSupplyAction.ActionDate;
                talep.KarsilanmaTarihi = (DateTime)_DirectMaterialSupplyAction.DateOfSupply;
                talep.TalepEdenBirimAdi = _DirectMaterialSupplyAction.MasterResource.Name;
                talep.TalepMalzemeListesi = detayList.ToArray();
                talep.HastaAdSoyad = _DirectMaterialSupplyAction.Episode.Patient.FullName;
                talep.HastaProtokolNo = _DirectMaterialSupplyAction.Episode.HospitalProtocolNo.Value.ToString();
                talep.HastaTC = (long)_DirectMaterialSupplyAction.Episode.Patient.UniqueRefNo;
                talep.Hastabasi = 1;
                if (DateOfSurgery != null)
                {
                    talep.AmeliyatTarihi = (DateTime)_DirectMaterialSupplyAction.DateOfSurgery;
                }

                if (!String.IsNullOrEmpty(errorMessage))
                {
                    return errorMessage + " için satınalma sisteminde stokKartı kaydı bulunamamıştır.\r\n";
                }

                XXXXXXTasinirMal.IslemSonuc islemSonucTalepBildirim = XXXXXXTasinirMal.WebMethods.TalepBildirSync(Sites.SiteLocalHost, sonuc.Mesaj, talep);
                _DirectMaterialSupplyAction.XXXXXXEtkilenenAdet = islemSonucTalepBildirim.EtkilenenAdet;
                _DirectMaterialSupplyAction.XXXXXXIslemBasarili = islemSonucTalepBildirim.IslemBasarili;
                _DirectMaterialSupplyAction.XXXXXXKayitId = islemSonucTalepBildirim.KayitID;
                _DirectMaterialSupplyAction.XXXXXXMesaj = islemSonucTalepBildirim.Mesaj;
                _DirectMaterialSupplyAction.ObjectContext.Save();
                return islemSonucTalepBildirim.Mesaj;
            }
            catch (Exception ex)
            {
                errorMessage += "\r\n" + ex.ToString();
                return errorMessage;
            }
        }
    }
}
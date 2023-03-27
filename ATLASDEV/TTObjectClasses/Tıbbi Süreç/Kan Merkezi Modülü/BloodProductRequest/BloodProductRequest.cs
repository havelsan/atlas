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
    /// Kan Ürünü İstek
    /// </summary>
    public partial class BloodProductRequest : EpisodeActionWithDiagnosis, IWorkListEpisodeAction
    {
        protected override void PostInsert()
        {
#region PostInsert
            base.PostInsert();
#endregion PostInsert
        }

        protected void PostTransition_BloodProductPreparation2Reject()
        {
            // From State : BloodProductPreparation   To State : Reject
#region PostTransition_BloodProductPreparation2Reject
            Cancel();
            CancelBloodBankRequest();
#endregion PostTransition_BloodProductPreparation2Reject
        }

        protected void PostTransition_BloodProductPreparation2Completed()
        {
            // From State : BloodProductPreparation   To State : Completed
#region PostTransition_BloodProductPreparation2Completed
            foreach (BloodBankBloodProducts product in BloodProducts)
            {
                if (product.ProductNumber != null)
                {
                    string sysparam = TTObjectClasses.SystemParameter.GetParameterValue("LABINTEGRATED", null);
                    if (sysparam == "TRUE")
                    {
                        try
                        {
                            TTMessageFactory.SyncCall(Sites.SiteLocalHost, "LATepe", "Main", "UrunKullanildi", product.ProductNumber);
                        }
                        catch (Exception ex)
                        {
                            throw;
                        }
                    }

                    product.CurrentStateDefID = BloodBankBloodProducts.States.Completed;
                }
            }
#endregion PostTransition_BloodProductPreparation2Completed
        }

        protected void UndoTransition_BloodProductPreparation2Completed(TTObjectStateTransitionDef transitionDef)
        {
            // From State : BloodProductPreparation   To State : Completed
#region UndoTransition_BloodProductPreparation2Completed
            NoBackStateBack();
#endregion UndoTransition_BloodProductPreparation2Completed
        }

        protected void UndoTransition_BloodProductRequest2BloodProductSupply(TTObjectStateTransitionDef transitionDef)
        {
            // From State : BloodProductRequest   To State : BloodProductSupply
#region UndoTransition_BloodProductRequest2BloodProductSupply
            if (Common.CurrentUser.IsSuperUser == false)
            {
                throw new Exception(TTUtils.CultureService.GetText("M26352", "Kullanıcınız işlemin geri alınmasında yetkili değildir.Lütfen bilgi işlem ile irtibata geçiniz!"));
            }
#endregion UndoTransition_BloodProductRequest2BloodProductSupply
        }

        protected void PostTransition_BloodProductRequest2BloodProductPreparation()
        {
            // From State : BloodProductRequest   To State : BloodProductPreparation
#region PostTransition_BloodProductRequest2BloodProductPreparation
            if (Episode.Diagnosis.Count == 0)
            {
                throw new Exception(TTUtils.CultureService.GetText("M25870", "Hastaya ait bir Ön Tanı bulunamadı. İstek yapabilmek için Ön Tanı giriniz."));
            }

            foreach (BloodBankBloodProducts product in BloodProducts)
            {
                BloodBankTestDefinition bloodBankTestDef = product.ProcedureObject as BloodBankTestDefinition;
                if (bloodBankTestDef != null)
                {
                    foreach (BloodBankGridMaterialDefinition defMaterialGrid in bloodBankTestDef.Materials)
                    {
                        BaseTreatmentMaterial material = new BaseTreatmentMaterial(ObjectContext);
                        material.Amount = 1;
                        material.Material = defMaterialGrid.Material;
                        material.EpisodeAction = this;
                        product.TreatmentMaterials.Add(material);
                    }

                    foreach (BloodBankGridProcedureDefinition procedureGridDef in bloodBankTestDef.SubProcedures)
                    {
                        BloodBankSubProduct subProcedure = new BloodBankSubProduct(ObjectContext);
                        subProcedure.ProcedureObject = procedureGridDef.SubProcedure;
                        subProcedure.MasterResource = MasterResource;
                        subProcedure.FromResource = FromResource;
                        subProcedure.EpisodeAction = this;
                        product.BloodBankSubProducts.Add(subProcedure);
                    }
                }
            }
#endregion PostTransition_BloodProductRequest2BloodProductPreparation
        }

        protected void UndoTransition_BloodProductRequest2BloodProductPreparation(TTObjectStateTransitionDef transitionDef)
        {
            // From State : BloodProductRequest   To State : BloodProductPreparation
#region UndoTransition_BloodProductRequest2BloodProductPreparation
            if (Common.CurrentUser.IsSuperUser == false)
            {
                throw new Exception(TTUtils.CultureService.GetText("M26352", "Kullanıcınız işlemin geri alınmasında yetkili değildir.Lütfen bilgi işlem ile irtibata geçiniz!"));
            }
#endregion UndoTransition_BloodProductRequest2BloodProductPreparation
        }

        protected void PostTransition_BloodProductUsage2Completed()
        {
            // From State : BloodProductUsage   To State : Completed
#region PostTransition_BloodProductUsage2Completed
            foreach (BloodBankBloodProducts product in BloodProducts)
            {
                if (product.Used == true)
                {
                    if (product.ProductNumber != null)
                    {
                        string sysparam = TTObjectClasses.SystemParameter.GetParameterValue("LABINTEGRATED", null);
                        if (sysparam == "TRUE")
                        {
                            try
                            {
                                TTMessageFactory.SyncCall(Sites.SiteLocalHost, "LATepe", "Main", "UrunKullanildi", product.ProductNumber);
                            }
                            catch (Exception ex)
                            {
                                throw;
                            }
                        }
                    }

                    product.CurrentStateDefID = BloodBankBloodProducts.States.Completed;
                }
                else
                {
                    if (product.ProductNumber != null)
                    {
                        string sysparam = TTObjectClasses.SystemParameter.GetParameterValue("LABINTEGRATED", null);
                        if (sysparam == "TRUE")
                        {
                            try
                            {
                                TTMessageFactory.SyncCall(Sites.SiteLocalHost, "LATepe", "Main", TTUtils.CultureService.GetText("M25984", "Iade"), product.ProductNumber);
                            }
                            catch (Exception ex)
                            {
                                throw;
                            }
                        }
                    }

                    product.Returned = true;
                    product.CurrentStateDefID = BloodBankBloodProducts.States.ReturnToBloodBank;
                }
            }
#endregion PostTransition_BloodProductUsage2Completed
        }

        protected void UndoTransition_BloodProductUsage2Completed(TTObjectStateTransitionDef transitionDef)
        {
            // From State : BloodProductUsage   To State : Completed
#region UndoTransition_BloodProductUsage2Completed
            foreach (BloodBankBloodProducts product in BloodProducts)
            {
                if (product.CurrentStateDefID == BloodBankBloodProducts.States.Completed || product.CurrentStateDefID == BloodBankBloodProducts.States.ReturnToBloodBank)
                {
                    //if (!(product is BloodBankSubProduct))
                    {
                        ((ITTObject)product).UndoLastTransition();
                    }
                }
            }
#endregion UndoTransition_BloodProductUsage2Completed
        }

#region Methods
        public BloodProductRequest(TTObjectContext objectContext, EpisodeAction episodeAction): this (objectContext)
        {
            ActionDate = DateTime.Now;
            MasterResource = episodeAction.MasterResource;
            FromResource = episodeAction.MasterResource;
            CurrentStateDefID = BloodProductRequest.States.BloodProductRequest;
            Episode = episodeAction.Episode;
            ProcedureSpeciality = episodeAction.ProcedureSpeciality;
            MasterAction = episodeAction;
        }

        public BloodProductRequest(TTObjectContext objectContext, SubactionProcedureFlowable subactionProcedureFlowable): this (objectContext)
        {
            ActionDate = DateTime.Now;
            MasterResource = subactionProcedureFlowable.MasterResource;
            FromResource = subactionProcedureFlowable.MasterResource;
            CurrentStateDefID = BloodProductRequest.States.BloodProductRequest;
            Episode = subactionProcedureFlowable.Episode;
            ProcedureSpeciality = subactionProcedureFlowable.ProcedureSpeciality;
            MasterAction = subactionProcedureFlowable.EpisodeAction;
        }

        protected override void BeforeSetSubEpisode(SubEpisode subEpisode)
        {
            base.BeforeSetSubEpisode(subEpisode);
            //todo bg
            //if ((subEpisode.Episode.PatientStatus == PatientStatusEnum.Discharge)
            //   || (subEpisode.Episode.PatientStatus == PatientStatusEnum.Outpatient
            //       && (subEpisode.PatientAdmission.AdmissionType.Value == AdmissionTypeEnum.Daily
            //           || subEpisode.PatientAdmission.AdmissionType.Value == AdmissionTypeEnum.Emergency)==false))
            /*if ((subEpisode.Episode.PatientStatus == PatientStatusEnum.Discharge) || (subEpisode.Episode.PatientStatus == PatientStatusEnum.Outpatient))
            {
                throw new TTException("Ayaktan durumundaki hastalara Kan Ürünü İsteği başlatılamaz. Günübirlik kabul başlatılmalıdır.");
            }*/
        }

        public override ActionTypeEnum ActionType
        {
            get
            {
                return ActionTypeEnum.BloodProductRequest;
            }
        }

        [LooselyTypeAttribute]
        [Serializable]
        public class KBHastaBilgileri
        {
            public Guid ID;
            public string PatientID;
            public string TCKimlikNo;
            public string Adi;
            public string Soyadi;
            public SexEnum Cinsiyeti;
            public DateTime DogumTarihi;
            public string DogumYeri;
            public string BabaAdi;
            public string AnneAdi;
        }

        [LooselyTypeAttribute]
        [Serializable]
        public class KBGelisBilgileri
        {
            public Guid ActionID;
            public Guid EpisodeID;
            public Guid PatientID;
            public int ActionNo;
            public DateTime IstekTarihi;
            public DateTime CalismaTarihi;
            public Guid DoktorID;
            public string DoktorAdi;
            public Guid BirimID;
            public string BirimAdi;
            public int HastaGrubuID;
            public string HastaGrubu;
            public int HastaKuvvetiID;
            public string HastaKuvveti;
            public string OnTani;
            public string Aciklama;
            public bool Ayaktan;
            public bool Acil;
            public bool KanBank = false;
        }

        [LooselyTypeAttribute]
        [Serializable]
        public class KBIstekBilgileri
        {
            public Guid SubActionID;
            public Guid ActionID;
            public Guid TestID;
            public Guid MasterTestID;
            public string KisaAdi;
            public string Adi;
            public bool OdemeFlag;
            public int Adet = 0;
            public bool KB = false;
            public List<BloodProductRequest.KBIslemTur> IslemTur = new List<BloodProductRequest.KBIslemTur>();
        }

        [LooselyTypeAttribute]
        [Serializable]
        public class KBIslemTur
        {
            public Guid TestID;
            public Guid IslemID;
            public string IslemAdi;
        }

        private void CreateIslemTur(ref BloodProductRequest.KBIstekBilgileri ib)
        {
            try
            {
                if (IsTransfused == true && TransfusedDate.HasValue)
                {
                    BloodProductRequest.KBIslemTur t = new BloodProductRequest.KBIslemTur();
                    t.IslemAdi = "Daha önce transfüzyon yapıldı mı : " + TransfusedDate.ToString();
                    ib.IslemTur.Add(t);
                }

                if (IsPregnancy == true && PregnancyDate.HasValue)
                {
                    BloodProductRequest.KBIslemTur t = new BloodProductRequest.KBIslemTur();
                    t.IslemAdi = "Gebelik Öyküsü (Önceki Gebelikler) : " + PregnancyDate.ToString();
                    ib.IslemTur.Add(t);
                }

                if (IsSurgery == true)
                {
                    BloodProductRequest.KBIslemTur t = new BloodProductRequest.KBIslemTur();
                    t.IslemAdi = "Kanın hangi amaçla istendiği : " + TTUtils.CultureService.GetText("M25149", "Ameliyat");
                    ib.IslemTur.Add(t);
                }
                else if (IsHB == true)
                {
                    BloodProductRequest.KBIslemTur t = new BloodProductRequest.KBIslemTur();
                    t.IslemAdi = "Kanın hangi amaçla istendiği : " + "Hb Yükseltme";
                    ib.IslemTur.Add(t);
                }
                else if (IsOtherReason == true)
                {
                    BloodProductRequest.KBIslemTur t = new BloodProductRequest.KBIslemTur();
                    t.IslemAdi = "Kanın hangi amaçla istendiği : " + TTUtils.CultureService.GetText("M12780", "Diğer");
                    ib.IslemTur.Add(t);
                }

                if (IsPrepared == true)
                {
                    BloodProductRequest.KBIslemTur t = new BloodProductRequest.KBIslemTur();
                    t.IslemAdi = "Kanın hazırlanma durumu : " + TTUtils.CultureService.GetText("M25909", "Hazırlanacak");
                    ib.IslemTur.Add(t);
                }
                else if (IsBlock == true)
                {
                    BloodProductRequest.KBIslemTur t = new BloodProductRequest.KBIslemTur();
                    t.IslemAdi = "Kanın hazırlanma durumu : " + TTUtils.CultureService.GetText("M25288", "Bloke Edilecek");
                    ib.IslemTur.Add(t);
                }

                if (RequirementDate.HasValue)
                {
                    BloodProductRequest.KBIslemTur t = new BloodProductRequest.KBIslemTur();
                    t.IslemAdi = "Gereksinim Tarihi : " + RequirementDate.ToString();
                    ib.IslemTur.Add(t);
                }

                if (IsUrgent == true)
                {
                    BloodProductRequest.KBIslemTur t = new BloodProductRequest.KBIslemTur();
                    t.IslemAdi = TTUtils.CultureService.GetText("M25093", "Acil");
                    ib.IslemTur.Add(t);
                }

                if (IsNormalCross == true)
                {
                    BloodProductRequest.KBIslemTur t = new BloodProductRequest.KBIslemTur();
                    t.IslemAdi = TTUtils.CultureService.GetText("M26584", "Normal Cross Yapılarak");
                    ib.IslemTur.Add(t);
                }
                else if (IsWithoutCross == true)
                {
                    BloodProductRequest.KBIslemTur t = new BloodProductRequest.KBIslemTur();
                    t.IslemAdi = TTUtils.CultureService.GetText("M25373", "Cross - Match Yapılmadan");
                    ib.IslemTur.Add(t);
                }
                else if (IsUrgentCross == true)
                {
                    BloodProductRequest.KBIslemTur t = new BloodProductRequest.KBIslemTur();
                    t.IslemAdi = TTUtils.CultureService.GetText("M25094", "Acil Cross - Match Yapılarak");
                    ib.IslemTur.Add(t);
                }

                if (IsWithoutTests == true)
                {
                    BloodProductRequest.KBIslemTur t = new BloodProductRequest.KBIslemTur();
                    t.IslemAdi = TTUtils.CultureService.GetText("M25913", "HbsAg, Anti HCV, Anti HIV, VDRL testleri tamamlanmadan");
                    ib.IslemTur.Add(t);
                }
                else if (IsWithTests == true)
                {
                    BloodProductRequest.KBIslemTur t = new BloodProductRequest.KBIslemTur();
                    t.IslemAdi = TTUtils.CultureService.GetText("M25912", "HbsAg, Anti HCV, Anti HIV, VDRL testleri hızlı tanı kitleri ile yapılarak");
                    ib.IslemTur.Add(t);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void CreateHastaBilgileri(ref BloodProductRequest.KBHastaBilgileri h)
        {
            try
            {
                Patient p = Episode.Patient;
                h.ID = p.ObjectID;
                if (p.ID.Value.HasValue)
                    h.PatientID = p.ID.Value.ToString();
                if (p.UniqueRefNo.HasValue)
                    h.TCKimlikNo = p.UniqueRefNo.Value.ToString();
                h.Adi = p.Name;
                h.Soyadi = p.Surname;
                //if (p.Sex != null)
                //    h.Cinsiyeti = p.Sex.Value;
                if (p.BirthDate.HasValue)
                    h.DogumTarihi = p.BirthDate.Value;
                //if (p.CityOfBirth != null)
                //    h.DogumYeri = p.CityOfBirth.Name;
                h.BabaAdi = p.FatherName;
                h.AnneAdi = p.MotherName;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void CreateGelisBilgileri(ref BloodProductRequest.KBGelisBilgileri g)
        {
            try
            {
                Patient p = Episode.Patient;
                g.ActionID = ObjectID;
                g.EpisodeID = Episode.ObjectID;
                g.PatientID = p.ObjectID;
                g.ActionNo = (int)ID.Value;
                if (RequestDate.HasValue)
                    g.IstekTarihi = RequestDate.Value;
                if (ActionDate.HasValue)
                    g.CalismaTarihi = ActionDate.Value;
                g.DoktorID = RequestDoctor.ObjectID;
                g.DoktorAdi = RequestDoctor.Name == null ? "" : RequestDoctor.Name;
                g.BirimID = FromResource.ObjectID;
                g.BirimAdi = FromResource.Name;
                //g.HastaKuvvetiID = (int)p.ForcesCommand.Code;
                //g.HastaKuvveti = p.ForcesCommand.Name;
                //g.OnTani = this.Prediagnosis;
                //g.Aciklama = this.Notes == null ? "" : this.Notes;
                TTDataDictionary.EnumValueDef statusEnum = Common.GetEnumValueDefOfEnumValue(Episode.PatientStatus);
                g.Ayaktan = statusEnum.Value == 0 ? true : false;
                //g.Acil = this.Urgent.Value == true ? true : false;
                g.KanBank = true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private List<BloodProductRequest.KBIstekBilgileri> CreateIstekBilgileri()
        {
            List<BloodProductRequest.KBIstekBilgileri> istekler = new List<BloodProductRequest.KBIstekBilgileri>();
            //foreach(SubActionProcedure subActionProcedure in this._SubactionProcedures)
            foreach (BloodBankBloodProducts bloodProcedure in BloodProducts)
            {
                //if(subActionProcedure is BloodBankBloodProducts)
                //{
                BloodProductRequest.KBIstekBilgileri i = new BloodProductRequest.KBIstekBilgileri();
                //BloodBankBloodProducts bloodProcedure = (BloodBankBloodProducts)subActionProcedure;
                i.SubActionID = bloodProcedure.ObjectID;
                i.ActionID = bloodProcedure.EpisodeAction.ObjectID;
                i.TestID = bloodProcedure.ProcedureObject.ObjectID;
                i.KisaAdi = bloodProcedure.ProcedureObject.Code;
                i.Adi = bloodProcedure.ProcedureObject.Name;
                i.OdemeFlag = ((SubactionProcedureFlowable)bloodProcedure).Paid();
                i.KB = true;
                i.Adet = (int)bloodProcedure.Amount;
                foreach (BloodBankSubProduct subProduct in bloodProcedure.BloodBankSubProducts)
                {
                    BloodProductRequest.KBIslemTur t = new BloodProductRequest.KBIslemTur();
                    t.IslemID = subProduct.ObjectID;
                    t.IslemAdi = subProduct.ProcedureObject.Name;
                    t.TestID = subProduct.ProcedureObject.ObjectID;
                    i.IslemTur.Add(t);
                }

                //CreateIslemTur(ref i);    //Burada gerçekleşen seçimler IslemTur nesnesi ile gönderilmemeli.Farklı bir nesne ile oluşturulmalı.Bu nedenle kapatıldı.
                istekler.Add(i);
            //}
            }

            return istekler;
        }

        [TTStorageManager.Attributes.TTRequiredRoles(TTRoleNames.Kan_Bankasi_Istek)]
        public static void SendToBloodBank(BloodProductRequest bloodProductRequest)
        {
            BloodProductRequest.KBHastaBilgileri hastaBilgileri = new BloodProductRequest.KBHastaBilgileri();
            BloodProductRequest.KBGelisBilgileri gelisBilgileri = new BloodProductRequest.KBGelisBilgileri();
            List<BloodProductRequest.KBIstekBilgileri> listIstekBilgileri = new List<BloodProductRequest.KBIstekBilgileri>();
            Patient p = bloodProductRequest.Episode.Patient;
            bloodProductRequest.CreateHastaBilgileri(ref hastaBilgileri);
            bloodProductRequest.CreateGelisBilgileri(ref gelisBilgileri);
            listIstekBilgileri = bloodProductRequest.CreateIstekBilgileri();
            try
            {
                //TTMessage message = TTMessageFactory.ASyncCall(Sites.SiteLocalHost, TTMessagePriorityEnum.HighPriority, "LATepe", "Main", "KBKaydet", null, hastaBilgileri, gelisBilgileri, listIstekBilgileri);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [LooselyTypeAttribute]
        public class BloodBankProduct
        {
            public Guid SubActionID;
            public Guid ActionID;
            public string TorbaNo;
            public string ISBTUnitNumber;
            public string ISBTElementCode;
            public string Notes;
            public List<BloodProductRequest.KBEkIslem> EkIslemler = new List<BloodProductRequest.KBEkIslem>();
            public bool IsLastProduct;
        }

        [LooselyTypeAttribute]
        public class KBEkIslem
        {
            public Guid IslemID;
            public Guid TestID;
            public string IslemAdi;
        }

        public void CancelBloodBankRequest()
        {
            BloodProductRequest.KBHastaBilgileri hastaBilgileri = new BloodProductRequest.KBHastaBilgileri();
            BloodProductRequest.KBGelisBilgileri gelisBilgileri = new BloodProductRequest.KBGelisBilgileri();
            List<BloodProductRequest.KBIstekBilgileri> listIstekBilgileri = new List<BloodProductRequest.KBIstekBilgileri>();
            Patient p = Episode.Patient;
            CreateHastaBilgileri(ref hastaBilgileri);
            CreateGelisBilgileri(ref gelisBilgileri);
            listIstekBilgileri = CreateIstekBilgileri();
            try
            {
                TTMessageFactory.SyncCall(Sites.SiteLocalHost, "LATepe", "Main", "KBIptal", listIstekBilgileri, gelisBilgileri);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static void SaveBloodBankProductToNebula(BloodProductRequest.BloodBankProduct product)
        {
            TTObjectContext context = new TTObjectContext(false);
            try
            {
                BloodProductRequest bloodRequest = (BloodProductRequest)context.GetObject(product.ActionID, "BLOODPRODUCTREQUEST");
                BloodBankBloodProducts bloodProduct = (BloodBankBloodProducts)context.GetObject(product.SubActionID, "BLOODBANKBLOODPRODUCTS");
                bloodProduct.ProductNumber = product.TorbaNo;
                //
                bloodProduct.ISBTUnitNumber = product.ISBTUnitNumber;
                bloodProduct.ISBTElementCode = product.ISBTElementCode;
                //
                bloodProduct.Notes = product.Notes;
                bloodProduct.ProductDate = Common.RecTime();
                if (product.EkIslemler != null)
                {
                    if (product.EkIslemler.Count > 0)
                    {
                        foreach (BloodProductRequest.KBEkIslem ekIslem in product.EkIslemler)
                        {
                            if (ekIslem.IslemID == Guid.Empty)
                            {
                                BloodBankSubProduct newSubProduct = new BloodBankSubProduct(context);
                                BloodBankTestDefinition testDef = (BloodBankTestDefinition)context.GetObject(ekIslem.TestID, "BLOODBANKTESTDEFINITION");
                                newSubProduct.MasterResource = bloodProduct.MasterResource;
                                newSubProduct.FromResource = bloodProduct.FromResource;
                                newSubProduct.ProcedureObject = testDef;
                                newSubProduct.EpisodeAction = bloodRequest;
                                newSubProduct.Amount = 1;
                                newSubProduct.CurrentStateDefID = BloodBankSubProduct.States.New;
                                context.Save();
                                newSubProduct.CurrentStateDefID = BloodBankSubProduct.States.Completed;
                                bloodProduct.BloodBankSubProducts.Add(newSubProduct);
                            //context.Save();
                            }
                            else
                            {
                                BloodBankSubProduct reqSubProduct = (BloodBankSubProduct)context.GetObject(ekIslem.IslemID, "BLOODBANKSUBPRODUCT");
                                reqSubProduct.CurrentStateDefID = BloodBankSubProduct.States.Completed;
                                context.Update();
                            }
                        }
                    }
                }

                if (product.IsLastProduct)
                    bloodRequest.CurrentStateDefID = BloodProductRequest.States.Completed;
                //bloodRequest.CurrentStateDefID = BloodProductRequest.States.BloodProductUsage;
                if (bloodProduct.CurrentStateDefID != BloodBankBloodProducts.States.Completed)
                    bloodProduct.CurrentStateDefID = BloodBankBloodProducts.States.Completed;
                context.Save();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        override public Guid ProcedureRequestStartedStateDefID()
        {
            return (Guid)BloodProductRequest.States.BloodProductPreparation;
        }

        override public void DoMyActionControlsForProcedureRequest()
        {
            List<BloodBankBloodProducts> liste = new List<BloodBankBloodProducts>();
            foreach (BloodBankBloodProducts productitem in BloodProducts)
            {
                liste.Add(productitem);
            }

            foreach (BloodBankBloodProducts product in liste)
            {
                if (product is BloodBankBloodProducts)
                {
                    int cloneCount = (int)product.Amount - 1;
                    product.Amount = 1;
                    for (int i = 0; i < cloneCount; i++)
                    {
                        BloodBankBloodProducts cloneProduct = null;
                        cloneProduct = (BloodBankBloodProducts)product.Clone();
                        //cloneProduct.EpisodeAction = product.EpisodeAction;
                        TTSequence.allowSetSequenceValue = true;
                        cloneProduct.ID.SetSequenceValue(0);
                        cloneProduct.ID.GetNextValue();
                        if (cloneProduct.IsIsinlama == true)
                        {
                            BloodBankSubProduct subProduct = new BloodBankSubProduct(ObjectContext);
                            BloodBankTestDefinition testDef = (BloodBankTestDefinition)ObjectContext.GetObject(new Guid("392b0f3c-157c-4871-a7c3-694132300206"), "BLOODBANKTESTDEFINITION");
                            subProduct.ProcedureObject = testDef;
                            subProduct.MasterResource = product.MasterResource;
                            subProduct.FromResource = product.FromResource;
                            subProduct.EpisodeAction = product.EpisodeAction;
                            cloneProduct.BloodBankSubProducts.Add(subProduct);
                        }

                        BloodProducts.Add(cloneProduct);
                    }

                    if (product.IsIsinlama == true)
                    {
                        BloodBankSubProduct subProduct = new BloodBankSubProduct(ObjectContext);
                        BloodBankTestDefinition testDef = (BloodBankTestDefinition)ObjectContext.GetObject(new Guid("392b0f3c-157c-4871-a7c3-694132300206"), "BLOODBANKTESTDEFINITION");
                        subProduct.ProcedureObject = testDef;
                        subProduct.MasterResource = product.MasterResource;
                        subProduct.FromResource = product.FromResource;
                        subProduct.EpisodeAction = product.EpisodeAction;
                        product.BloodBankSubProducts.Add(subProduct);
                    }
                }
            }
        }

        override public void SetMyActionMandatoryProperties()
        {
            RequestDoctor = Common.CurrentResource;
        }

        public static void UpdateBloodProductStatusFromBloodBank(string EpisodeID)
        {
            TTObjectContext objContext = new TTObjectContext(false);
            List<XXXXXXIHEWS.HastaKanIstem> hastaKanIstemList = new List<XXXXXXIHEWS.HastaKanIstem>();
            try
            {
                XXXXXXIHEWS.HastaKanIstemler hastaKanIstemler = new XXXXXXIHEWS.HastaKanIstemler();
                hastaKanIstemler = XXXXXXIHEWS.WebMethods.HastaKanIstemGetirSync(Sites.SiteLocalHost, "", "", EpisodeID, "P", "", "");
                foreach (XXXXXXIHEWS.HastaKanIstem kanIstem in hastaKanIstemler.HastaKanIstemArr)
                {
                    foreach (XXXXXXIHEWS.HastaUrun kanUrun in kanIstem.HastaUrunler)
                    {
                        BindingList<TTObjectClasses.BloodBankBloodProducts> kanUrunList = TTObjectClasses.BloodBankBloodProducts.GetBloodProductsByExternalID(objContext, kanUrun.HASTAURUNENTEG_ID);
                        if (kanUrunList.Count > 0)
                        {
                            BloodBankBloodProducts bloodProduct = kanUrunList[0];
                            if (kanUrun.STATU == "REZERVE")
                            {
                                if (bloodProduct.CurrentStateDefID == BloodBankBloodProducts.States.Waiting)
                                    bloodProduct.CurrentStateDefID = BloodBankBloodProducts.States.Reserved;
                            }

                            if (kanUrun.STATU == "CIKIS")
                            {
                                if (kanUrun.ISBT_BILESEN_KODU != null && kanUrun.ISBT_BILESEN_KODU != "")
                                    bloodProduct.ISBTElementCode = kanUrun.ISBT_BILESEN_KODU;
                                if (kanUrun.ISBT_UNITE_NO != null && kanUrun.ISBT_UNITE_NO != "")
                                    bloodProduct.ISBTUnitNumber = kanUrun.ISBT_UNITE_NO;
                                if (bloodProduct.CurrentStateDefID == BloodBankBloodProducts.States.Reserved)
                                    bloodProduct.CurrentStateDefID = BloodBankBloodProducts.States.Completed;
                            }

                            if (kanUrun.STATU == "IPTAL")
                            {
                                if (bloodProduct.CurrentStateDefID == BloodBankBloodProducts.States.Waiting || bloodProduct.CurrentStateDefID == BloodBankBloodProducts.States.Reserved)
                                    bloodProduct.CurrentStateDefID = BloodBankBloodProducts.States.Cancelled;
                            }

                            //TODO: Asagıdakı statu ler XXXXXX ıle kontrol edılecek.
                            if (kanUrun.STATU == "URUNKABUL")
                            {
                                if (bloodProduct.CurrentStateDefID == BloodBankBloodProducts.States.Completed)
                                    bloodProduct.CurrentStateDefID = BloodBankBloodProducts.States.Accepted;
                            }

                            if (kanUrun.STATU == "IADE")
                            {
                                if (bloodProduct.CurrentStateDefID == BloodBankBloodProducts.States.Accepted)
                                    bloodProduct.CurrentStateDefID = BloodBankBloodProducts.States.ReturnToBloodBank;
                            }

                            if (kanUrun.STATU == "TRANSFUZYON")
                            {
                                if (bloodProduct.CurrentStateDefID == BloodBankBloodProducts.States.Accepted)
                                    bloodProduct.CurrentStateDefID = BloodBankBloodProducts.States.TransfusionCompleted;
                            }

                            objContext.Save();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("XXXXXX Kan İstem Sorgulama servisinde hata oluştu : " + ex.Message.ToString());
            }
        }

     /*   public static List<XXXXXXIHEWS.HastaKanIstem> GetPatientBloodRequestFromLIS(string EpisodeActionObjectID)
        {
            TTObjectContext objContext = new TTObjectContext(false);
            EpisodeAction episodeAction = (EpisodeAction)objContext.GetObject(new Guid(EpisodeActionObjectID), "EpisodeAction");
            List<XXXXXXIHEWS.HastaKanIstem> hastaKanIstemList = new List<XXXXXXIHEWS.HastaKanIstem>();
            try
            {
                XXXXXXIHEWS.HastaKanIstemler hastaKanIstemler = new XXXXXXIHEWS.HastaKanIstemler();
                hastaKanIstemler = XXXXXXIHEWS.WebMethods.HastaKanIstemGetirSync(Sites.SiteLocalHost, "", "", episodeAction.Episode.ID.ToString(), "P", "", ""); // "18562088" 
                foreach (XXXXXXIHEWS.HastaKanIstem kanIstem in hastaKanIstemler.HastaKanIstemArr)
                {
                    hastaKanIstemList.Add(kanIstem);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("XXXXXX Kan İstem Sorgulama servisinde hata oluştu : " + ex.Message.ToString());
            }

            return hastaKanIstemList;
        }
        

        public static List<XXXXXXIHEWS.HastaKanIstem> GetPatientNewBloodRequestFromLIS(string EpisodeActionObjectID)
        {
            TTObjectContext objContext = new TTObjectContext(false);
            EpisodeAction episodeAction = (EpisodeAction)objContext.GetObject(new Guid(EpisodeActionObjectID), "EpisodeAction");
            List<XXXXXXIHEWS.HastaKanIstem> hastaKanIstemList = new List<XXXXXXIHEWS.HastaKanIstem>();
            try
            {
                XXXXXXIHEWS.HastaKanIstemler hastaKanIstemler = new XXXXXXIHEWS.HastaKanIstemler();
                hastaKanIstemler = XXXXXXIHEWS.WebMethods.HastaKanIstemGetirSync(Sites.SiteLocalHost, "", "", episodeAction.Episode.ID.ToString(), "P", "", ""); // "18562088" 
                //sorgulanan kan urun istemlerinin yeni istem oldugunu kontrol etmeli ve istemler ona gore listeye eklenmeli. 
                //HBYS tarafinda kan istemin istem_id sine ait action olup olmadigi kontrol ediliyor, yoksa listeye ekleniyor. 
                foreach (XXXXXXIHEWS.HastaKanIstem kanIstem in hastaKanIstemler.HastaKanIstemArr)
                {
                    BindingList<BloodProductRequest> bloodProductRequestList = BloodProductRequest.GetBloodProductRequestByExternalID(objContext, kanIstem.ISTEM_ID);
                    if (bloodProductRequestList.Count == 0)
                    {
                        hastaKanIstemList.Add(kanIstem);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("XXXXXX Kan İstem Sorgulama servisinde hata oluştu : " + ex.Message.ToString());
            }

            return hastaKanIstemList;
        }
        */

        public static List<XXXXXXIHEWS.HastaKanIstem> GetPatientBloodRequestFromLIS(string SubEpisodeObjectID)
        {

            TTObjectContext objContext = new TTObjectContext(false);
            SubEpisode subEpisode = (SubEpisode)objContext.GetObject(new Guid(SubEpisodeObjectID), "SubEpisode");
           
            try
            {
             
                List<XXXXXXIHEWS.HastaKanIstem> hastaKanIstemList = new List<XXXXXXIHEWS.HastaKanIstem>();
                try
                {
                    XXXXXXIHEWS.HastaKanIstemler KBHastaKanIstemler = new XXXXXXIHEWS.HastaKanIstemler();
                    KBHastaKanIstemler = XXXXXXIHEWS.WebMethods.HastaKanIstemGetirSync(Sites.SiteLocalHost, "", "", subEpisode.Episode.ID.ToString(), "P", "", "");
                    foreach (XXXXXXIHEWS.HastaKanIstem kanIstem in KBHastaKanIstemler.HastaKanIstemArr)
                    {
                        hastaKanIstemList.Add(kanIstem);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("XXXXXX Kan İstem Sorgulama servisinde hata oluştu : " + ex.Message.ToString());
                }

                return hastaKanIstemList;
            }
            catch (Exception ex)
            {
                return null;
                throw new Exception("XXXXXX Kan İstem Sorgulama servisinde hata oluştu : " + ex.Message.ToString());
            }
        }

        public void CreateorUpdateBloodBankRequestAction(List<XXXXXXIHEWS.HastaKanIstem> bloodProductRequests, string SubEpisodeObjectID,EpisodeAction episodeAction)
        {
            using (TTObjectContext ObjectContext = new TTObjectContext(false))
            {
                SubEpisode subEpisode = (SubEpisode)ObjectContext.GetObject(new Guid(SubEpisodeObjectID), "SubEpisode");
                string masterres = TTObjectClasses.SystemParameter.GetParameterValue("BLOODREQUESTMASTERRESID", "8da338ef-7712-4a13-925e-d6680126a791");
                ResObservationUnit masterRes = (ResObservationUnit)ObjectContext.GetObject(new Guid(masterres), "ResObservationUnit");

                foreach (XXXXXXIHEWS.HastaKanIstem bloodRequest in bloodProductRequests)
                {
                    //Kan istem daha önce ATLAS'ta oluşturulmuş mu kontrol ediliyor

                    BindingList<BloodProductRequest> bloodProductRequestList = BloodProductRequest.GetBloodProductRequestByExternalID(ObjectContext, bloodRequest.ISTEM_ID);

                    if (bloodProductRequestList.Count == 0)
                    {
                        BloodProductRequest bloodRequestAction = (BloodProductRequest)ObjectContext.CreateObject("BloodProductRequest");
                        bloodRequestAction.CurrentStateDefID = BloodProductRequest.States.BloodProductRequest;
                        bloodRequestAction.MasterResource = masterRes;
                        bloodRequestAction.FromResource = masterRes;
                        bloodRequestAction.SubEpisode = subEpisode;
                        bloodRequestAction.Episode = subEpisode.Episode;
                        bloodRequestAction.BloodBankRequestExternalID = bloodRequest.ISTEM_ID;
                        bloodRequestAction.RequestDoctor = Common.CurrentResource;
                        bloodRequestAction.MasterAction = episodeAction;
                        bloodRequestAction.Update();

                        foreach (XXXXXXIHEWS.HastaUrun bloodProduct in bloodRequest.HastaUrunler)
                        {

                            BloodBankBloodProducts bloodProductSubAction = (BloodBankBloodProducts)ObjectContext.CreateObject("BloodBankBloodProducts");
                            string bloodProductCode = bloodProduct.URUN_LOINC_KODU;

                            List<ProcedureDefinition> bloodBankTestDef = ProcedureDefinition.GetByCode(ObjectContext, bloodProductCode, null).ToList();
                            if (bloodBankTestDef != null && bloodBankTestDef.Count > 0)
                            {
                                SubactionProcedureFlowable.SetMandatorySubactionProcedureFlowableProperties(bloodRequestAction, masterRes, masterRes, bloodProductSubAction);
                                bloodProductSubAction.ProcedureObject = bloodBankTestDef[0];
                                bloodProductSubAction.EpisodeAction = bloodRequestAction;
                                bloodProductSubAction.CurrentStateDefID = BloodBankBloodProducts.States.New;  //KAYIT statusu
                                bloodRequestAction.SubactionProcedures.Add((SubActionProcedure)bloodProductSubAction);
                                ObjectContext.Update();

                                //STATU Degerleri
                                //'KAYIT'
                                //'REZERVE'
                                //'CIKIS'
                                //'IPTAL'
                                //'TRANSFUZYON'

                                bloodProductSubAction.BloodProductExternalID = bloodProduct.HASTAURUNENTEG_ID;
                                if (bloodProduct.STATU == "CIKIS")  //Tamamlandı
                                {
                                    bloodProductSubAction.CurrentStateDefID = BloodBankBloodProducts.States.Completed;
                                    bloodProductSubAction.PerformedDate = bloodProductSubAction.CreationDate;
                                    bloodProductSubAction.ISBTUnitNumber = bloodProduct.ISBT_UNITE_NO;
                                    bloodProductSubAction.ISBTElementCode = bloodProduct.ISBT_BILESEN_KODU;
                                }
                                else if (bloodProduct.STATU == "REZERVE")  //Rezerve
                                {
                                    bloodProductSubAction.CurrentStateDefID = BloodBankBloodProducts.States.Waiting;
                                    ObjectContext.Update();
                                    bloodProductSubAction.CurrentStateDefID = BloodBankBloodProducts.States.Reserved;
                                    bloodProductSubAction.PerformedDate = bloodProductSubAction.CreationDate;
                                    bloodProductSubAction.ISBTUnitNumber = bloodProduct.ISBT_UNITE_NO;
                                    bloodProductSubAction.ISBTElementCode = bloodProduct.ISBT_BILESEN_KODU;
                                }
                                else if (bloodProduct.STATU == "IPTAL")  //İptal
                                {
                                    bloodProductSubAction.CurrentStateDefID = BloodBankBloodProducts.States.Cancelled;

                                }
                                else if (bloodProduct.STATU == "TRANSFUZYON")  //Transfüzyon
                                {
                                    bloodProductSubAction.CurrentStateDefID = BloodBankBloodProducts.States.Accepted;
                                    ObjectContext.Update();
                                    bloodProductSubAction.CurrentStateDefID = BloodBankBloodProducts.States.TransfusionCompleted;
                                    bloodProductSubAction.PerformedDate = bloodProductSubAction.CreationDate;
                                    bloodProductSubAction.ISBTUnitNumber = bloodProduct.ISBT_UNITE_NO;
                                    bloodProductSubAction.ISBTElementCode = bloodProduct.ISBT_BILESEN_KODU;
                                }
                            }
                            else
                            {
                                TTUtils.Logger.WriteError("Kan ürün istem oluşturma sırasında hata oluştu. İlgili kan ürünü bulunamadı: " + bloodProductCode);
                            }
                        }
                    }
                    else
                    {
                        BloodProductRequest bloodRequestAction = bloodProductRequestList[0];
                        foreach (XXXXXXIHEWS.HastaUrun bloodProduct in bloodRequest.HastaUrunler)
                        {
                            foreach (BloodBankBloodProducts bloodProductSubAction in bloodRequestAction.SubactionProcedureFlowables)
                            {
                                if (bloodProduct.HASTAURUNENTEG_ID == bloodProductSubAction.BloodProductExternalID)
                                {
                                    if (bloodProduct.STATU == "CIKIS")  //Tamamlandı
                                    {
                                        if (bloodProductSubAction.CurrentStateDefID == BloodBankBloodProducts.States.New || bloodProductSubAction.CurrentStateDefID == BloodBankBloodProducts.States.Reserved)
                                            bloodProductSubAction.CurrentStateDefID = BloodBankBloodProducts.States.Completed;

                                        bloodProductSubAction.ISBTUnitNumber = bloodProduct.ISBT_UNITE_NO;
                                        bloodProductSubAction.ISBTElementCode = bloodProduct.ISBT_BILESEN_KODU;
                                    }
                                    else if (bloodProduct.STATU == "REZERVE")  //Rezerve
                                    {
                                        if (bloodProductSubAction.CurrentStateDefID == BloodBankBloodProducts.States.New)
                                        {
                                            bloodProductSubAction.CurrentStateDefID = BloodBankBloodProducts.States.Waiting;
                                            ObjectContext.Update();
                                            bloodProductSubAction.CurrentStateDefID = BloodBankBloodProducts.States.Reserved;
                                        }
                                        bloodProductSubAction.ISBTUnitNumber = bloodProduct.ISBT_UNITE_NO;
                                        bloodProductSubAction.ISBTElementCode = bloodProduct.ISBT_BILESEN_KODU;
                                    }
                                    else if (bloodProduct.STATU == "IPTAL")  //İptal
                                    {
                                        if (bloodProductSubAction.CurrentStateDefID == BloodBankBloodProducts.States.New || bloodProductSubAction.CurrentStateDefID == BloodBankBloodProducts.States.Reserved)
                                        {
                                            bloodProductSubAction.CurrentStateDefID = BloodBankBloodProducts.States.Cancelled;
                                        }

                                    }
                                    else if (bloodProduct.STATU == "TRANSFUZYON")  //Transfüzyon
                                    {
                                        if (bloodProductSubAction.CurrentStateDefID == BloodBankBloodProducts.States.New)
                                        {
                                            bloodProductSubAction.CurrentStateDefID = BloodBankBloodProducts.States.Accepted;
                                            ObjectContext.Update();
                                            bloodProductSubAction.CurrentStateDefID = BloodBankBloodProducts.States.TransfusionCompleted;
                                        }
                                        bloodProductSubAction.ISBTUnitNumber = bloodProduct.ISBT_UNITE_NO;
                                        bloodProductSubAction.ISBTElementCode = bloodProduct.ISBT_BILESEN_KODU;
                                        //TODO: REZERVE edilen ürün Transfuzyona geçerse ne yapılacak?
                                    }
                                }
                            }
                        }

                    }
                }
                ObjectContext.Save();
            }
        }

            #endregion Methods
            protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof (BloodProductRequest).Name)
                return;
            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;
            if (fromState == BloodProductRequest.States.BloodProductPreparation && toState == BloodProductRequest.States.Reject)
                PostTransition_BloodProductPreparation2Reject();
            else if (fromState == BloodProductRequest.States.BloodProductPreparation && toState == BloodProductRequest.States.Completed)
                PostTransition_BloodProductPreparation2Completed();
            else if (fromState == BloodProductRequest.States.BloodProductRequest && toState == BloodProductRequest.States.BloodProductPreparation)
                PostTransition_BloodProductRequest2BloodProductPreparation();
            else if (fromState == BloodProductRequest.States.BloodProductUsage && toState == BloodProductRequest.States.Completed)
                PostTransition_BloodProductUsage2Completed();
        }

        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof (BloodProductRequest).Name)
                return;
            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;
            if (fromState == BloodProductRequest.States.BloodProductPreparation && toState == BloodProductRequest.States.Completed)
                UndoTransition_BloodProductPreparation2Completed(transDef);
            else if (fromState == BloodProductRequest.States.BloodProductRequest && toState == BloodProductRequest.States.BloodProductSupply)
                UndoTransition_BloodProductRequest2BloodProductSupply(transDef);
            else if (fromState == BloodProductRequest.States.BloodProductRequest && toState == BloodProductRequest.States.BloodProductPreparation)
                UndoTransition_BloodProductRequest2BloodProductPreparation(transDef);
            else if (fromState == BloodProductRequest.States.BloodProductUsage && toState == BloodProductRequest.States.Completed)
                UndoTransition_BloodProductUsage2Completed(transDef);
        }
    }
}
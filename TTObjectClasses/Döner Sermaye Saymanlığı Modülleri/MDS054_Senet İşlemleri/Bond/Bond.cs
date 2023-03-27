
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
    public partial class Bond : EpisodeAccountAction
    {

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        override protected void RunSetMemberValueScript(string memberName, object newValue)
        {
            if (memberName != "SUBEPISODE")
                switch (memberName)
                {
                    case "BONDDOCUMENT":
                        {
                            BondDocument value = (BondDocument)newValue;
                            #region BONDDOCUMENT_SetParentScript
                            if (value != null)
                                value.EpisodeAccountAction = this;
                            #endregion BONDDOCUMENT_SetParentScript
                        }
                        break;

                    default:
                        base.RunSetMemberValueScript(memberName, newValue);
                        break;
                }
        }

        public void SetStateAfterPayment()
        {
            if (BondDetails.Count(x => x.CurrentStateDefID == BondDetail.States.New) == BondDetails.Count)
                CurrentStateDefID = Bond.States.UnPaid;
            else if (BondDetails.Count(x => x.CurrentStateDefID == BondDetail.States.Paid) == BondDetails.Count)
                CurrentStateDefID = Bond.States.Paid;
            else
                CurrentStateDefID = Bond.States.PartialPaid;
        }

        public void CheckBondPersons()
        {

            if (BondPayer.UniqueRefNo.HasValue == false || string.IsNullOrEmpty(BondPayer.IdentificationCardNo) || string.IsNullOrEmpty(BondPayer.Name) || string.IsNullOrEmpty(BondPayer.Surname) || string.IsNullOrEmpty(BondPayer.FatherName) || string.IsNullOrEmpty(BondPayer.MotherName) || string.IsNullOrEmpty(BondPayer.Address) || string.IsNullOrEmpty(BondPayer.Phone) || BondPayer.HomeCity == null || BondPayer.HomeTown == null || BondPayer.BirthPlace == null || !BondPayer.BirthDate.HasValue || BondPayer.CityOfRegistry == null || BondPayer.TownOfRegistrySKRS == null)
            {
                throw new TTException(TTUtils.CultureService.GetText("M26382", "Lütfen Borçlu bilgilerini eksiksiz doldurunuz!"));
            }

            if (FirstBondGuarantor != null && (FirstBondGuarantor.UniqueRefNo.HasValue || !string.IsNullOrEmpty(FirstBondGuarantor.IdentificationCardNo) || !string.IsNullOrEmpty(FirstBondGuarantor.Name) || !string.IsNullOrEmpty(FirstBondGuarantor.Surname) || !string.IsNullOrEmpty(FirstBondGuarantor.FatherName) || !string.IsNullOrEmpty(FirstBondGuarantor.MotherName) || !string.IsNullOrEmpty(FirstBondGuarantor.Address) || !string.IsNullOrEmpty(FirstBondGuarantor.Phone) || FirstBondGuarantor.HomeCity != null || FirstBondGuarantor.HomeTown != null || FirstBondGuarantor.BirthPlace != null || FirstBondGuarantor.BirthDate.HasValue) && (!FirstBondGuarantor.UniqueRefNo.HasValue && string.IsNullOrEmpty(FirstBondGuarantor.IdentificationCardNo) && string.IsNullOrEmpty(FirstBondGuarantor.Name) && string.IsNullOrEmpty(FirstBondGuarantor.Surname) && string.IsNullOrEmpty(FirstBondGuarantor.FatherName) && string.IsNullOrEmpty(FirstBondGuarantor.MotherName) && string.IsNullOrEmpty(FirstBondGuarantor.Address) && string.IsNullOrEmpty(FirstBondGuarantor.Phone) && FirstBondGuarantor.HomeCity == null && FirstBondGuarantor.HomeTown == null && FirstBondGuarantor.CityOfBirth == null && !FirstBondGuarantor.BirthDate.HasValue))
            {
                throw new TTException(TTUtils.CultureService.GetText("M26384", "Lütfen Kefil bilgilerini eksiksiz doldurunuz! Kefil belirtmek istemiyorsanız tüm alanları boş bırakınız."));
            }
            else
            {
                if (FirstBondGuarantor != null && FirstBondGuarantor.UniqueRefNo.HasValue == false)
                {
                    ITTObject firstGuarantor = FirstBondGuarantor;
                    firstGuarantor.Delete();
                    FirstBondGuarantor = null;
                }
            }
        }
        protected override void PreInsert()
        {

        }

        //public void SetBondDetailStates()
        //{
        //    foreach (BondDetail bondDetail in BondDetails)
        //    {
        //        if (bondDetail.CurrentStateDefID == BondDetail.States.Paid)
        //            bondDetail.CurrentStateDefID = BondDetail.States.Paid;
        //        else
        //            bondDetail.CurrentStateDefID = BondDetail.States.New;
        //    }
        //}

        public void PostTransition_UnPaid2PartialPaid()
        {
            //SetBondDetailStates();
            if (BondDetails.Where(x => x.CurrentStateDefID == BondDetail.States.Paid).Count() == 0)
                throw new TTException(TTUtils.CultureService.GetText("M26304", "Kısmen Ödendi adımına geçmek için en az bir vadenin ödenmiş durumunda olması gerekmektedir!"));

            if (BondDetails.Where(x => x.CurrentStateDefID == BondDetail.States.New).Count() == 0)
                throw new TTException(TTUtils.CultureService.GetText("M27129", "Tüm vadeler ödenmiş durumdadır. Ödendi adımına geçiniz."));
        }
        public void PostTransition_New2UnPaid()
        {
            if (FirstNotificationDate.HasValue || SecondNotificationDate.HasValue)
                throw new TTException(TTUtils.CultureService.GetText("M27241", "Yeni oluşturulan senet için İhbar girilemez! Senedi oluşturduktan sonra ihbar işlemlerini gerçekleştirebilirsiniz."));

            if (BondDetails.Count == 0)
                throw new TTException(TTUtils.CultureService.GetText("M27170", "Vade sayısı girilmedi!"));

            if (BondDetails.Sum(x => (double)x.Price) != TotalPrice.Value)
                throw new TTException(TTUtils.CultureService.GetText("M27171", "Vadelerin toplam tutarı Senet toplam tutarından fazla olamaz!"));

            // Yapılandırılmış senetlerde aşağıdaki bloğa giriilmemesi gerekiyor
            if (Type == BondTypeEnum.Normal && OriginalBond == null)
            {
                BondDocument.DocumentDate = Date;
                BondDocument.ResUser = Common.CurrentResource;

                if (BondProcedures.Count > 0)
                {
                    foreach (BondProcedure bp in BondProcedures)
                    {
                        Currency remainingPaymentOfRecProc = bp.RemainingPrice.Value;
                        foreach (AdvanceDocument advanceDoc in BondDocument.AdvanceDocuments)
                        {
                            Advance advance = advanceDoc.Advance[0];
                            if (advance.RemainingPrice > 0)
                            {
                                PatientPaymentDetail ppDetail = new PatientPaymentDetail(ObjectContext);
                                if (remainingPaymentOfRecProc <= advance.RemainingPrice)
                                {
                                    ppDetail.CreatePPDetail(bp.AccountTransaction, advance.AdvanceDocument, remainingPaymentOfRecProc, PaymentTypeEnum.Advance);
                                    remainingPaymentOfRecProc = 0;
                                    break;
                                }
                                else
                                {
                                    remainingPaymentOfRecProc -= advance.RemainingPrice;
                                    ppDetail.CreatePPDetail(bp.AccountTransaction, advance.AdvanceDocument, advance.RemainingPrice, PaymentTypeEnum.Advance);
                                }
                            }
                        }

                        if (remainingPaymentOfRecProc > 0)
                        {
                            PatientPaymentDetail ppDetail = new PatientPaymentDetail(ObjectContext);
                            ppDetail.CreatePPDetail(bp.AccountTransaction, BondDocument, remainingPaymentOfRecProc, PaymentTypeEnum.Bond);
                        }

                        bp.AccountTransaction.CurrentStateDefID = AccountTransaction.States.Paid;

                        if (bp.AccountTransaction.SubActionProcedure != null)
                        {
                            // Paketin içindeki AccTrx leri de Ödendi durumuna almak için (Paket Tanımı olan durumda)
                            if (bp.AccountTransaction.SubActionProcedure.PackageDefinition != null)
                            {
                                foreach (AccountTransaction accTrx in bp.AccountTransaction.SubEpisodeProtocol.GetTransactionsInsidePackage(bp.AccountTransaction.SubActionProcedure.PackageDefinition, Episode.Patient.MyAPR()))
                                {
                                    if (accTrx.CurrentStateDefID == AccountTransaction.States.New)
                                        accTrx.CurrentStateDefID = AccountTransaction.States.Paid;
                                }
                            } // Paket hizmet ise : SUbEpisodeProtocol deki InvoiceInclusion ı false ve Yeni durumundaki hizmetler Paket içi olduğu düşünülüp Ödendi durumuna alınır
                            else if (bp.AccountTransaction.SubActionProcedure.ProcedureObject is PackageProcedureDefinition)
                            {
                                foreach (AccountTransaction accTrx in bp.AccountTransaction.SubEpisodeProtocol.GetNotInvoiceIncludedTransactions(Episode.Patient.MyAPR()))
                                {
                                    if (accTrx.CurrentStateDefID == AccountTransaction.States.New)
                                        accTrx.CurrentStateDefID = AccountTransaction.States.Paid;
                                }
                            }
                        }
                    }
                }

                foreach (AdvanceDocument advanceDoc in BondDocument.AdvanceDocuments)
                {
                    advanceDoc.Used = true;
                }

                if (OriginalBond == null)
                {
                    foreach (SubEpisodeProtocol sep in Episode.AllSubEpisodeProtocols())
                    {
                        if (sep.CurrentStateDefID == SubEpisodeProtocol.States.Open && sep.Payer.Type.PayerType == PayerTypeEnum.Paid)
                        {
                            sep.CurrentStateDefID = SubEpisodeProtocol.States.Closed;
                            BondClosedSeps bcs = new BondClosedSeps(ObjectContext);
                            bcs.Bond = this;
                            bcs.SEP = sep;
                        }
                    }
                }
            }
        }
        public void PostTransition_2Paid()
        {
            //SetBondDetailStates();
            if (BondDetails.Where(x => x.CurrentStateDefID == BondDetail.States.Paid).Count() != BondDetails.Count)
                throw new TTException(TTUtils.CultureService.GetText("M26650", "Ödendi adımına geçmek için tüm vadelerin ödenmiş olması gerekmektedir!"));
        }

        public void NormalBond_2Cancelled()
        {
            foreach (BondProcedure bp in BondProcedures)
            {
                foreach (PatientPaymentDetail ppDetail in bp.AccountTransaction.PatientPaymentDetail.Where(x => x.AccountDocument == BondDocument))
                {
                    ppDetail.IsCancel = true;
                }

                bp.AccountTransaction.CurrentStateDefID = AccountTransaction.States.New;

                if (bp.AccountTransaction.SubActionProcedure != null)
                {
                    // Paketin içindeki AccTrx leri de Yeni durumuna almak için (Paket Tanımı olan durumda)
                    if (bp.AccountTransaction.SubActionProcedure.PackageDefinition != null)
                    {
                        foreach (AccountTransaction accTrx in bp.AccountTransaction.SubEpisodeProtocol.GetTransactionsInsidePackage(bp.AccountTransaction.SubActionProcedure.PackageDefinition, Episode.Patient.MyAPR()))
                        {
                            if (accTrx.CurrentStateDefID == AccountTransaction.States.Paid)
                                accTrx.CurrentStateDefID = AccountTransaction.States.New;
                        }
                    }// Paket hizmet ise : SUbEpisodeProtocol deki InvoiceInclusion ı false ve Ödendi durumundaki hizmetler Paket içi olduğu düşünülüp tekrar Yeni durumuna alınır
                    else if (bp.AccountTransaction.SubActionProcedure.ProcedureObject is PackageProcedureDefinition)
                    {
                        foreach (AccountTransaction accTrx in bp.AccountTransaction.SubEpisodeProtocol.GetNotInvoiceIncludedTransactions(Episode.Patient.MyAPR()))
                        {
                            if (accTrx.CurrentStateDefID == AccountTransaction.States.Paid)
                                accTrx.CurrentStateDefID = AccountTransaction.States.New;
                        }
                    }
                }
            }

            foreach (AdvanceDocument advanceDoc in BondDocument.AdvanceDocuments)
            {
                advanceDoc.Used = false;
                foreach (PatientPaymentDetail ppDetail in advanceDoc.PatientPaymentDetail.Where(x => x.AccountTransaction != null))
                {
                    ppDetail.IsCancel = true;
                }
            }
            foreach (BondClosedSeps bcs in BondClosedSeps)
            {
                bcs.SEP.CurrentStateDefID = SubEpisodeProtocol.States.Open;
            }
            BondDocument.CancelDate = Common.RecTime();
        }

        public void RestructuredBond_2Cancelled()
        {
            if (OriginalBond.BondDetails.Where(x => x.CurrentStateDefID == BondDetail.States.Paid).Count() > 0)
                OriginalBond.CurrentStateDefID = Bond.States.PartialPaid;
            else
                OriginalBond.CurrentStateDefID = Bond.States.UnPaid;
            BondDocument.CancelDate = Common.RecTime();
        }

        public void PostTransition_2Cancelled()
        {
            if (BondDetails.Where(x => x.CurrentStateDefID == BondDetail.States.Paid).Count() > 0)
                throw new TTException(TTUtils.CultureService.GetText("M26655", "Ödenmiş vadesi olan senet iptal edilemez!"));
            if (Type == BondTypeEnum.Normal)
                NormalBond_2Cancelled();
            else if (Type == BondTypeEnum.Restructured)
                RestructuredBond_2Cancelled();
        }

        public void PostTransition_2Restructured()
        {
            Bond resBond = Clone() as Bond;
            BondDocument resBondDocument = BondDocument.Clone() as BondDocument;
            BondPerson resBondPayer = BondPayer.Clone() as BondPerson;
            BondPerson resBondGuarantor = null;

            if (FirstBondGuarantor != null)
                resBondGuarantor = FirstBondGuarantor.Clone() as BondPerson;

            //resBond
            resBond.OriginalBond = this;
            resBond.Date = Common.RecTime();
            resBond.RequestDate = resBond.Date;
            resBond.ActionDate = resBond.Date;
            resBond.WorkListDate = resBond.Date;
            TTSequence.allowSetSequenceValue = true;
            resBond.ID.SetSequenceValue(0);
            resBond.ID.GetNextValue();
            resBond.CurrentStateDefID = Bond.States.New;
            resBond.Type = BondTypeEnum.Restructured;
            resBond.BondPayer = resBondPayer;
            resBond.FirstBondGuarantor = resBondGuarantor;
            resBond.BondDocument = resBondDocument;
            resBond.FirstNotificationDate = null;
            resBond.SecondNotificationDate = null;
            resBond.TotalPrice = BondDetails.Where(x => x.CurrentStateDefID == BondDetail.States.New).Sum(x => (decimal)x.Price);

            //ResBondDocument
            resBondDocument.DocumentDate = resBond.Date;
            resBondDocument.ResUser = Common.CurrentResource;
            resBondDocument.EpisodeAccountAction = resBond;
            resBondDocument.TotalPrice = resBond.TotalPrice;

            //ResBondProcedure
            foreach (BondProcedure proc in BondProcedures)
            {
                BondProcedure resBondProc = proc.Clone() as BondProcedure;
                resBondProc.Bond = resBond;
            }
        }
        public void PostTransition_2LegalProcess()
        {
            if (!(FirstNotificationDate.HasValue && SecondNotificationDate.HasValue))
                throw new TTException(TTUtils.CultureService.GetText("M25284", "Birinci ve ikinci ihbarname tarihleri girilmeden yasal işlem adımına geçilemez."));
        }
        public void PostTransition_2UnPaid()
        {
            if (BondDetails.Where(x => x.CurrentStateDefID == BondDetail.States.Paid).Count() > 0)
                throw new TTException(TTUtils.CultureService.GetText("M26656", "Ödenmiş vadesi olan senet ödenmedi durumuna alınamaz!"));
        }

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(Bond).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == Bond.States.New && toState == Bond.States.UnPaid)
                PostTransition_New2UnPaid();
            else if (fromState == Bond.States.UnPaid && toState == Bond.States.PartialPaid)
                PostTransition_UnPaid2PartialPaid();
            else if (toState == Bond.States.UnPaid)
                PostTransition_2UnPaid();
            else if (toState == Bond.States.Paid)
                PostTransition_2Paid();
            else if (toState == Bond.States.LegalProcess)
                PostTransition_2LegalProcess();
            else if (toState == Bond.States.Restructured)
                PostTransition_2Restructured();
            else if (toState == Bond.States.Cancelled)
                PostTransition_2Cancelled();
        }

        public void PrepareNewBond()
        {
            if (CurrentStateDefID == Bond.States.New)
            {
                Currency totalRemainingPrice = 0;
                BondPayer = new TTObjectClasses.BondPerson(ObjectContext);
                FirstBondGuarantor = new BondPerson(ObjectContext);
                Date = Common.RecTime();
                Type = BondTypeEnum.Normal;
                if (BondDocument == null)
                {
                    BondDocument = new BondDocument(ObjectContext);
                    foreach (AccountTransaction accTrx in Episode.GetTransactionsForReceipt())
                    {
                        if ((accTrx.SubActionProcedure != null || accTrx.SubActionMaterial != null) && accTrx.RemainingPrice > 0)
                        {
                            BondProcedure bp = new BondProcedure(ObjectContext);
                            bp.ActionDate = accTrx.TransactionDate.Value;
                            bp.ExternalCode = accTrx.ExternalCode;

                            if (accTrx.ExternalCode != null)
                            {
                                if (accTrx.ExternalCode == "520010" && accTrx.SubActionProcedure.ProcedureSpeciality != null)
                                {
                                    if (accTrx.Description.IndexOf(accTrx.SubActionProcedure.ProcedureSpeciality.Name) == -1)
                                        accTrx.Description += " (" + accTrx.SubActionProcedure.ProcedureSpeciality.Name + ")";
                                }
                            }

                            bp.Description = accTrx.Description;

                            //if (accTrx.SubActionProcedure.ProcedureObject.GetRevenueSubAccountCode() != null)
                            //rp.RevenueType = accTrx.SubActionProcedure.ProcedureObject.GetRevenueSubAccountCode().Description;

                            bp.Amount = (int)accTrx.Amount;
                            bp.UnitPrice = accTrx.UnitPrice;
                            bp.TotalPrice = (double)((int)accTrx.Amount * accTrx.UnitPrice);
                            bp.RemainingPrice = accTrx.RemainingPrice;
                            bp.AccountTransaction = accTrx;

                            totalRemainingPrice += bp.RemainingPrice.Value;
                            BondProcedures.Add(bp);
                        }
                    }

                    double totalAdvanceTaken = 0;


                    foreach (Advance advance in Episode.Advances)
                    {
                        if (advance.AdvanceDocument.CurrentStateDefID == AdvanceDocument.States.Paid && advance.AdvanceDocument.Used.Value == false)
                        {
                            totalAdvanceTaken += advance.TotalPrice.Value;
                            //advance.AdvanceDocument.Used = true;
                            BondDocument.AdvanceDocuments.Add(advance.AdvanceDocument);
                        }
                    }
                    AdvanceTaken = totalAdvanceTaken;
                    TotalPrice = totalRemainingPrice;
                    if (TotalPrice > Convert.ToDouble(AdvanceTaken))
                    {
                        TotalPrice -= AdvanceTaken.Value;
                    }
                    else
                    {
                        totalRemainingPrice = 0;
                        throw new TTException(TTUtils.CultureService.GetText("M25332", "Bu protokol numarası için Hastanın Borcu bulunmamaktadır. Senet yapılamaz!"));
                    }
                    BondDocument.TotalPrice = TotalPrice;
                    BondDocument.DocumentDate = Common.RecTime();
                    BondDocument.ResUser = Common.CurrentResource;

                    PatientIdentityAndAddress patientAddres = Episode.Patient.PatientAddress;
                    Patient patient = Episode.Patient;


                    BondPayer.UniqueRefNo = patient.UniqueRefNo;
                    BondPayer.IdentificationCardNo = patient.IdentificationCardNo + patient.IdentificationCardSerialNo;
                    BondPayer.Name = patient.Name;
                    BondPayer.Surname = patient.Surname;
                    BondPayer.FatherName = patient.FatherName;
                    BondPayer.MotherName = patient.MotherName;
                    BondPayer.BirthPlace = patient.BirthPlace;
                    BondPayer.BirthDate = patient.BirthDate;
                    BondPayer.CityOfRegistry = patient.CityOfRegistry;
                    BondPayer.TownOfRegistrySKRS = patient.TownOfRegistrySKRS;
                    BondPayer.HomeCity = patientAddres.SKRSILKodlari;
                    BondPayer.HomeTown = patientAddres.SKRSIlceKodlari;
                    BondPayer.Phone = patient.MobilePhone;
                    BondPayer.Address = patientAddres.HomeAddress;

                }
            }
        }
    }
}
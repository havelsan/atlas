
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
    public abstract partial class SubActionMaterial : TTObject, IAccountOperation, ISUTInstance, ISubActionMaterial, IMySubActionMaterial
    {
        public partial class OLAP_SGKStatisticQuery1_Class : TTReportNqlObject
        {
        }

        public partial class OLAP_SGKStatisticQuery1_SECount_Class : TTReportNqlObject
        {
        }

        public partial class GetMaterialByPatient_Class : TTReportNqlObject
        {
        }

        public partial class OLAP_SGKStatisticQuery1_PatientCount_Class : TTReportNqlObject
        {
        }

        public partial class GetNameByObjectID_Class : TTReportNqlObject
        {
        }

        #region IMySubActionMaterial Members
        public SubActionMaterial GetMySubActionMaterial()
        {
            return MySubActionMaterial;
        }
        public void SetMySubActionMaterial(SubActionMaterial value)
        {
            MySubActionMaterial = value;
        }
        #endregion

        /// <summary>
        /// Medulada majistral ilaçlar için ilaç içeriği bilgisi
        /// </summary>
        public string MedulaMagistralPreparationDescription
        {
            get
            {
                try
                {
                    #region MedulaMagistralPreparationDescription_GetScript                    
                    string description = string.Empty;

                    if (Material is MagistralPreparationDefinition)
                    {
                        foreach (MagistralDefUsedDrug usedDrug in ((MagistralPreparationDefinition)Material).MagistralDefUsedDrugs)
                        {
                            if (usedDrug.Drug != null)
                                description = description + usedDrug.Drug.Name + ",";
                        }
                        foreach (MagistralDefUsedChemical usedChemical in ((MagistralPreparationDefinition)Material).MagistralDefUsedChemicals)
                        {
                            if (usedChemical.MagistralChemicalDefinition != null)
                                description = description + usedChemical.MagistralChemicalDefinition.Name + ",";
                        }
                    }

                    if (description != string.Empty)
                    {
                        description = description.Substring(0, (description.Length - 1));

                        if (description.Length > 255)
                            description = description.Substring(0, 255);
                    }

                    return description;
                    #endregion MedulaMagistralPreparationDescription_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "MedulaMagistralPreparationDescription") + " : " + ex.Message, ex);
                }
            }
        }

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        override protected void RunSetMemberValueScript(string memberName, object newValue)
        {
            switch (memberName)
            {
                case "MASTERPACKGSUBACTIONPROCEDURE":
                    {
                        SubActionProcedure value = (SubActionProcedure)newValue;
                        #region MASTERPACKGSUBACTIONPROCEDURE_SetParentScript
                        if (value != null)
                            Episode = value.Episode;
                        #endregion MASTERPACKGSUBACTIONPROCEDURE_SetParentScript
                    }
                    break;
                case "MATERIAL":
                    {
                        Material value = (Material)newValue;
                        #region MATERIAL_SetParentScript
                        if (this is DrugOrder)
                        {
                            DrugOrder drugOrder = (DrugOrder)this;
                            DrugDefinition drugDefinition = ((DrugDefinition)value);
                            if (drugDefinition.Frequency != null && drugDefinition.RoutineDose != null && drugDefinition.RoutineDay != null)
                            {
                                drugOrder.Frequency = drugDefinition.Frequency;
                                drugOrder.DoseAmount = drugDefinition.RoutineDose;
                                drugOrder.Day = Convert.ToInt32(drugDefinition.RoutineDay);
                            }


                        }

                        if (value != null)
                        {
                            if (value.Barcode != null)
                            {
                                UBBCode = value.Barcode;
                            }

                            if (value is ConsumableMaterialDefinition)
                            {
                                Guid malzemeObjectID = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("22F_MALZEMEOBJECTID", Guid.Empty.ToString()));
                                if (value.ObjectID != malzemeObjectID)
                                {
                                    if (value.IsOldMaterial.HasValue && value.IsOldMaterial == true)
                                    {
                                        if (string.IsNullOrEmpty(UBBCode))
                                        {
                                            switch (value.GetOldMaterialType())
                                            {
                                                case OldMaterialTypeEnum.TITUBBMaterial:
                                                    SubActionMatPricingDet titubbPrice = new SubActionMatPricingDet(ObjectContext);
                                                    titubbPrice.PatientPrice = 0;
                                                    titubbPrice.SubActionMaterial = this;
                                                    if (value.MaterialProductLevels.Select("PRODUCT is not null").Count == 1)
                                                    {
                                                        ProductDefinition productDefinition = value.MaterialProductLevels.Select("PRODUCT is not null")[0].Product;
                                                        if (productDefinition.ProductSUTMatchs.Count > 0)
                                                        {
                                                            ProductSUTMatchDefinition sutMatch = productDefinition.GetProperSUTMatch();
                                                            titubbPrice.ExternalCode = sutMatch.SUTCode;
                                                            titubbPrice.Description = sutMatch.SUTName;
                                                            titubbPrice.PayerPrice = sutMatch.SUTPrice;
                                                        }
                                                        else
                                                        {
                                                            titubbPrice.ExternalCode = "KODSUZ";
                                                            titubbPrice.Description = productDefinition.Name;
                                                            titubbPrice.PayerPrice = 0;
                                                        }
                                                        titubbPrice.ProductDefinition = productDefinition;
                                                        UBBCode = productDefinition.ProductNumber;

                                                        //                                                    string retAmount = InputForm.GetText("Sarf Edilecek Miktarı Giriniz.");
                                                        //                                                    Currency? amount = 0;
                                                        //                                                    if (string.IsNullOrEmpty(retAmount) == false)
                                                        //                                                    {
                                                        //                                                        if (CurrencyType.TryConvertFrom(retAmount, false, out amount) == false)
                                                        //                                                            throw new TTException(SystemMessage.GetMessage(1192, new string[] { retAmount.ToString() }));
                                                        //                                                    }
                                                        //                                                    this.Amount = amount;
                                                        //                                                    titubbPrice.Amount = amount;
                                                    }
                                                    else if (value.MaterialProductLevels.Select("PRODUCT is not null").Count > 1)
                                                    {
                                                        //                                                        ProductDefinition productDefinition = null;
                                                        //                                                        MultiSelectForm mSelectForm = new MultiSelectForm();
                                                        //                                                        foreach (MaterialProductLevel product in value.MaterialProductLevels.Select("PRODUCT is not null"))
                                                        //                                                            mSelectForm.AddMSItem(product.Product.ProductNumber + " - " + product.Product.Name, product.ObjectID.ToString(), product.Product);
                                                        //
                                                        //                                                        string mkey = mSelectForm.GetMSItem(null, "TITUBB Malzemesini seçiniz.", false, false, false, false, true, true);
                                                        //                                                        if (string.IsNullOrEmpty(mkey))
                                                        //                                                            throw new Exception("TITUBB Malzeme seçmediniz");
                                                        //                                                        productDefinition = mSelectForm.MSSelectedItemObject as ProductDefinition;
                                                        //                                                        if (productDefinition.ProductSUTMatchs.Count > 0)
                                                        //                                                        {
                                                        //                                                            ProductSUTMatchDefinition sutMatch = productDefinition.GetProperSUTMatch();
                                                        //                                                            titubbPrice.ExternalCode = sutMatch.SUTCode;
                                                        //                                                            titubbPrice.Description = sutMatch.SUTName;
                                                        //                                                            titubbPrice.PayerPrice = sutMatch.SUTPrice;
                                                        //                                                        }
                                                        //                                                        else
                                                        //                                                        {
                                                        //                                                            titubbPrice.ExternalCode = "KODSUZ";
                                                        //                                                            titubbPrice.Description = productDefinition.Name;
                                                        //                                                            titubbPrice.PayerPrice = 0;
                                                        //                                                        }
                                                        //
                                                        //                                                        titubbPrice.ProductDefinition = productDefinition;
                                                        //                                                        this.UBBCode = productDefinition.ProductNumber;
                                                        //
                                                        //                                                        //                                                    string retAmount = InputForm.GetText("Sarf Edilecek Miktarı Giriniz.");
                                                        //                                                        //                                                    Currency? amount = 0;
                                                        //                                                        //                                                    if (string.IsNullOrEmpty(retAmount) == false)
                                                        //                                                        //                                                    {
                                                        //                                                        //                                                        if (CurrencyType.TryConvertFrom(retAmount, false, out amount) == false)
                                                        //                                                        //                                                            throw new TTException(SystemMessage.GetMessage(1192, new string[] { retAmount.ToString() }));
                                                        //                                                        //                                                    }
                                                        //                                                        //                                                    this.Amount = amount;
                                                        //                                                        //                                                    titubbPrice.Amount = amount;
                                                    }
                                                    break;
                                                case OldMaterialTypeEnum.MaterialWithBarcode:
                                                    SubActionMatPricingDet barcodePrice = new SubActionMatPricingDet(ObjectContext);
                                                    barcodePrice.PatientPrice = 0;
                                                    barcodePrice.PayerPrice = 0;
                                                    barcodePrice.ExternalCode = "KODSUZ";
                                                    barcodePrice.Description = value.Name;
                                                    barcodePrice.SubActionMaterial = this;

                                                    //                                                string barcodeAmount = InputForm.GetText("Sarf Edilecek Miktarı Giriniz.");
                                                    //                                                Currency? bAmount = 0;
                                                    //                                                if (string.IsNullOrEmpty(barcodeAmount) == false)
                                                    //                                                {
                                                    //                                                    if (CurrencyType.TryConvertFrom(barcodeAmount, false, out bAmount) == false)
                                                    //                                                        throw new TTException(SystemMessage.GetMessage(1192, new string[] { barcodeAmount.ToString() }));
                                                    //                                                }
                                                    //                                                this.Amount = bAmount;
                                                    //                                                barcodePrice.Amount = bAmount;
                                                    break;
                                                case OldMaterialTypeEnum.MaterialWithoutBarcode:
                                                case OldMaterialTypeEnum.NoMatchMaterial:
                                                    break;
                                            }
                                        }
                                    }

                                    //TODO: Daha sonra değerlendirilecek.
                                    //                                    //Allogreft malzemeler için yapılmıştır.
                                    //                                    ConsumableMaterialDefinition consumableMaterialDefinition = (ConsumableMaterialDefinition)value;
                                    //                                    if (consumableMaterialDefinition.IsAllogreft.HasValue && (bool)consumableMaterialDefinition.IsAllogreft)
                                    //                                    {
                                    //                                        string donorID = InputForm.GetText("Allogreft malzeme için Dönor ID giriniz.");
                                    //                                        if (string.IsNullOrEmpty(donorID) == false)
                                    //                                            this.DonorID = donorID;
                                    //                                        else
                                    //                                            throw new TTException("Allogreft malzemeler için Dönor ID girmelisiniz.");
                                    //                                    }
                                }
                            }
                        }
                        #endregion MATERIAL_SetParentScript
                    }
                    break;
                case "SUBEPISODE":
                    {
                        SubEpisode value = (SubEpisode)newValue;
                        if (SubEpisode != null && value != null)
                        {
                            SubEpisodeProtocol newSEP = value.OpenSubEpisodeProtocol;
                            if (newSEP == null)
                                throw new TTException(SystemMessage.GetMessage(663));

                            ChangeMyProtocol(newSEP);
                        }
                        //SubEpisode value = (SubEpisode)newValue;
                        //if (SubEpisode != null && value != null)
                        //{
                        //    SubEpisodeProtocol newSEP = value.ActiveSubEpisodeProtocol;
                        //    foreach (AccountTransaction at in this.AccountTransactions.Where(x => x.CurrentStateDefID == AccountTransaction.States.New ||
                        //                                                                     x.CurrentStateDefID == AccountTransaction.States.ToBeNew ||
                        //                                                                     x.CurrentStateDefID == AccountTransaction.States.MedulaDontSend ||
                        //                                                                     x.CurrentStateDefID == AccountTransaction.States.MedulaEntryUnsuccessful))
                        //    {
                        //        if (at.SubEpisodeProtocol.SubEpisode != value)
                        //        {
                        //            if (newSEP == null)
                        //                throw new TTException(SystemMessage.GetMessage(663));

                        //            at.SubEpisodeProtocol = newSEP;
                        //        }
                        //    }
                        //}
                    }
                    break;

            }
        }

        protected override void PreInsert()
        {
            #region PreInsert

            base.PreInsert();
            if (!IgnoreClinicDischargeDate())
            {
                if (SubEpisode != null)

                    if (SubEpisode.PatientStatus == SubEpisodeStatusEnum.Inpatient && SubEpisode.ClosingDate != null)
                    {

                        DateTime closingDate = Convert.ToDateTime(Convert.ToDateTime(SubEpisode.ClosingDate).ToString("yyyy-MM-dd"));
                        DateTime creationDate = Convert.ToDateTime(Convert.ToDateTime(CreationDate).ToString("yyyy-MM-dd"));

                        if (this is DrugOrderDetail)
                        {
                            if (closingDate < creationDate)
                                CreationDate = SubEpisode.ClosingDate;

                            if (SubEpisode.ClosingDate < ((DrugOrderDetail)this).OrderPlannedDate)
                                ((DrugOrderDetail)this).OrderPlannedDate = SubEpisode.ClosingDate;
                        }
                        else
                        {
                            if (PricingDate != null)
                            {
                                DateTime pricingDate = Convert.ToDateTime(Convert.ToDateTime(PricingDate).ToString("yyyy-MM-dd"));
                                if (pricingDate > closingDate)
                                    throw new Exception(TTUtils.CultureService.GetText("M25861", "Hastanın vakası kapatılmış olduğu için malzeme ya da ilaç girişi yapılamaz!"));

                            }
                            else
                            {
                                if (closingDate < creationDate)
                                    throw new Exception(TTUtils.CultureService.GetText("M25861", "Hastanın vakası kapatılmış olduğu için malzeme ya da ilaç girişi yapılamaz!"));
                            }
                        }
                    }
            }

            if (SubEpisode.IsSGK)
            {
                if (Material is ConsumableMaterialDefinition)
                {
                    double maxAmount = Convert.ToDouble(TTObjectClasses.SystemParameter.GetParameterValue("MAXIMUMSUBACTIONMATERIALAMOUNT", "48"));
                    if (Amount > maxAmount && !(this is OrthesisProthesisRequestTreatmentMaterial)) // Ortez protez işleminden girilen malzemeler için 48 limitine takılmasın istendi (TFS Id: 45583)
                        throw new Exception(Material.Name + " malzemesi için miktar olarak en fazla " + TTObjectClasses.SystemParameter.GetParameterValue("MAXIMUMSUBACTIONMATERIALAMOUNT", "48") + " girebilirsiniz.");
                }
            }

            // Yeşil Alan Muayenesi ise başka malzeme girilemesin kontrolü
            if (Episode != null && Eligible == true && Material != null && Material.Chargable == true)
            {
                foreach (EmergencyIntervention ei in Episode.EmergencyInterventions)
                {
                    if (!ei.IsCancelled && ei.IsGreenAreaExamination)
                    {
                        if (!(EpisodeAction is OutPatientPrescription))
                            throw new Exception(TTUtils.CultureService.GetText("M27249", "Yeşil Alan Muayenesi olan vakalarda başka hizmet/malzeme girişi yapılamaz!"));
                    }
                }
            }

            SetRequestedByUserAsCurrentResource();
            #endregion PreInsert
        }

        public virtual bool IgnoreClinicDischargeDate()
        {
            return false;
        }

        public void CreateENabizMaterial(AccountTransaction accountTransaction)
        {
            ENabizMaterial eNabizMaterial = new ENabizMaterial(ObjectContext);

            if (this is DrugOrderDetail)
            {
                eNabizMaterial.RequestDate = ((DrugOrderDetail)this).DrugOrder.PlannedStartTime.Value;
                eNabizMaterial.ApplicationDate = ((DrugOrderDetail)this).OrderPlannedDate.Value;
            }
            else
            {
                eNabizMaterial.RequestDate = accountTransaction.TransactionDate.Value.AddMinutes(-1);
                eNabizMaterial.ApplicationDate = accountTransaction.TransactionDate;
            }

            if (accountTransaction.AccountPayableReceivable.Type == APRTypeEnum.PAYER)
            {
                eNabizMaterial.PayerPrice = accountTransaction.UnitPrice;
                eNabizMaterial.PatientPrice = 0;
            }
            else
            {
                eNabizMaterial.PayerPrice = 0;
                eNabizMaterial.PatientPrice = accountTransaction.UnitPrice;
            }

            eNabizMaterial.AccountTransaction = accountTransaction;
            eNabizMaterial.SubActionMaterial = this;
            eNabizMaterial.CurrentStateDefID = ENabizMaterial.States.Completed;
        }

        protected override void PostInsert()
        {
            #region PostInsert

            base.PostInsert();
            AccountOperationAttribute();

            // Değiştirildi. SS
            //ENabiz a Islem bilgisi gondermek icin paket bilgisi yaziliyor.
            /*if (this.SubEpisode != null && this.SendToENabiz() && this.ObjectDef.Name != "ORTHESISPROTHESISREQUESTTREATMENTMATERIAL")//ortez protezden girilen sarf malzemeler nabza gitmesin
                new SendToENabiz(this.ObjectContext, this.SubEpisode, this.ObjectID, this.ObjectDef.Name, "102", Common.RecTime());
            else
            {
                if (this.Episode.SubEpisodes.Count > 0 && this.SendToENabiz() && this.ObjectDef.Name != "ORTHESISPROTHESISREQUESTTREATMENTMATERIAL")//ortez protezden girilen sarf malzemeler nabza gitmesin
                    new SendToENabiz(this.ObjectContext, this.Episode.SubEpisodes[0], this.ObjectID, this.ObjectDef.Name, "102", Common.RecTime());

            }*/

            if (this is DrugOrder == false && this is DrugOrderDetail == false && this is OrthesisProthesisRequestTreatmentMaterial == false)
            {
                if (Eligible == false || Material.Chargable == false)
                {
                    for (int i = 0; i < Amount; i++)
                    {
                        ENabizMaterial eNabizMaterial = new ENabizMaterial(ObjectContext);
                        eNabizMaterial.RequestDate = CreationDate;
                        eNabizMaterial.ApplicationDate = CreationDate;
                        eNabizMaterial.PayerPrice = 0;
                        eNabizMaterial.PatientPrice = 0;
                        eNabizMaterial.SubActionMaterial = this;
                        eNabizMaterial.CurrentStateDefID = ENabizMaterial.States.Completed;
                    }
                }
            }

            #endregion PostInsert
        }

        protected override void PreUpdate()
        {
            #region PreUpdate
            base.PreUpdate();

            #endregion PreUpdate
        }

        protected override void PostUpdate()
        {
            #region PostUpdate

            base.PostUpdate();
            AccountOperationAttribute();

            #endregion PostUpdate
        }

        protected override void PreDelete()
        {
            #region PreDelete

            base.PreDelete();

            if (StockActionDetail != null)
                throw new Exception("Malzemenin stok hareketi olduğundan silinemez. (" + Material.Barcode + " " + Material.Name + ")");

            if (AccountTransactions.Count > 0)
                throw new Exception("Malzeme ücretlendirildiğinden silinemez. (" + Material.Barcode + " " + Material.Name + ")");

            StockOutCancelOperation();
            CancelMyAccountTransactions();

            #endregion PreDelete
        }

        protected void PostTransition_New2Cancelled()
        {
            // From State : New   To State : Cancelled
            #region PostTransition_New2Cancelled
            Cancel();
            #endregion PostTransition_New2Cancelled
        }

        protected void PostTransition_Completed2Cancelled()
        {
            // From State : Completed   To State : Cancelled
            #region PostTransition_Completed2Cancelled
            Cancel();
            #endregion PostTransition_Completed2Cancelled
        }



        #region Methods
        #region ISubActionMaterial Members
        public double? GetAmount()
        {
            return Amount;
        }
        public void SetAmount(double? value)
        {
            Amount = value;
        }

        public Material GetMaterial()
        {
            return Material;
        }
        public void SetMaterial(Material value)
        {
            Material = value;
        }

        public Store GetStore()
        {
            return Store;
        }
        public void SetStore(Store value)
        {
            Store = value;
        }
        #endregion
        public virtual object GetDVO(AccountTransaction AccTrx)
        {
            return null;
        }

        // Medula Katkı Payı Bilgisi
        public string MedulaPatientShareExists(AccountTransaction AccTrx)
        {
            // Diş Tedavilerinde (Tedavi Tipi 9, 13, 20 olan takiplerde) malzemelerde Katkı Payı "E" olarak gönderilmelidir.
            // 9,  "Ağız Protez tedavisi"
            // 13, "Diş Tedavisi"
            // 20, ?Ortodontik Tedavi?
            if (AccTrx.SubEpisodeProtocol != null && AccTrx.SubEpisodeProtocol.MedulaTedaviTipi != null)
            {
                if (AccTrx.SubEpisodeProtocol.MedulaTedaviTipi.tedaviTipiKodu == "9" || AccTrx.SubEpisodeProtocol.MedulaTedaviTipi.tedaviTipiKodu == "13" || AccTrx.SubEpisodeProtocol.MedulaTedaviTipi.tedaviTipiKodu == "20")
                    return "E";
            }

            foreach (AccountTransaction at in AccountTransactions)
            {
                if (at.AccountPayableReceivable.Type == APRTypeEnum.PATIENT && at.CurrentStateDefID != AccountTransaction.States.Cancelled)
                    return "E";
            }

            return "H";
        }

        public SubActionMaterial MySubActionMaterial
        {
            get { return (SubActionMaterial)this; }
            set
            {

            }

        }

        public EpisodeAction EpisodeAction
        {
            get
            {
                if (this is BaseTreatmentMaterial)
                {
                    return ((BaseTreatmentMaterial)this).EpisodeAction;
                }
                else if (this is OutPatientDrugOrder)
                {
                    return ((OutPatientDrugOrder)this).OutPatientPrescription;
                }
                else if (this is InpatientDrugOrder)
                {
                    return ((InpatientDrugOrder)this).InpatientPrescription;
                }
                else if (this is DrugOrderDetail)
                {
                    return ((DrugOrderDetail)this).NursingApplication;
                }
                else if (this is DrugOrder)
                {
                    return ((DrugOrder)this).InPatientPhysicianApplication;
                }
                else
                {
                    throw new Exception(SystemMessage.GetMessageV3(661, new string[] { ObjectDef.Name.ToString() }));
                }
            }
            set
            {
                if (this is BaseTreatmentMaterial)
                {
                    ((BaseTreatmentMaterial)this).EpisodeAction = value;
                }
                else if (this is DrugOrderDetail)
                {
                    ((DrugOrderDetail)this).NursingApplication = (NursingApplication)value;
                }
                else if (this is OutPatientDrugOrder)
                {
                    ((OutPatientDrugOrder)this).OutPatientPrescription = (OutPatientPrescription)value;
                }
                else if (this is InpatientDrugOrder)
                {
                    ((InpatientDrugOrder)this).InpatientPrescription = (InpatientPrescription)value;
                }
                else if (this is DrugOrder)
                {
                    ((DrugOrder)this).InPatientPhysicianApplication = (InPatientPhysicianApplication)value;
                }
                else
                {
                    throw new Exception(SystemMessage.GetMessageV3(661, new string[] { ObjectDef.Name.ToString() }));
                }
            }
        }

        public SubactionProcedureFlowable SubactionProcedureFlowable
        {
            get
            {
                if (this is BaseTreatmentMaterial)
                    return ((BaseTreatmentMaterial)this).SubactionProcedureFlowable;
                else
                    return null;
            }
            set
            {
                if (this is BaseTreatmentMaterial)
                    ((BaseTreatmentMaterial)this).SubactionProcedureFlowable = value;
            }
        }

        override protected void OnConstruct()
        {
            base.OnConstruct();
            ITTObject ttObject = (ITTObject)this;
            if (((ITTObject)this).IsNew == true)
            {
                if (CreationDate == null)
                    CreationDate = Common.RecTime();
                if (EpisodeAction != null && Store == null)
                    SetStore(EpisodeAction);
            }
        }

        public virtual void Cancel()
        {
            StockOutCancelOperation();
            CancelMyAccountTransactions();
            var cancelENabizMaterialList = ENabizMaterials.Select("").Where(x => x.AccountTransaction == null && x.CurrentStateDefID == ENabizMaterial.States.Completed).ToList();
            if (cancelENabizMaterialList != null)
            {
                foreach (ENabizMaterial eNabizMaterial in cancelENabizMaterialList)
                {
                    eNabizMaterial.CurrentStateDefID = ENabizMaterial.States.Cancelled;
                }
            }
        }

        public List<AccountTransaction> CancelMyAccountTransactions(bool exceptPaidPatientShare = false)
        {
            List<AccountTransaction> returnList = new List<AccountTransaction>();

            foreach (AccountTransaction at in AccountTransactions)
            {
                if (at.CurrentStateDefID != AccountTransaction.States.Cancelled)
                {
                    if (at.IsAllowedToCancel == false)
                    {
                        if (!exceptPaidPatientShare || (exceptPaidPatientShare && !at.IsPaidPatientShare()))
                            throw new TTException(TTUtils.CultureService.GetText("M26178", "İşlem hareketi '") + at.CurrentStateDef.DisplayText + "' durumunda olduğu için iptal edilemez. Öncelikle ödeme/faturalama işleminin iptal edilmesi gerekmektedir!\r\n" + "Malzeme/İlaç : " + at.ExternalCode + " " + at.Description);
                    }

                    at.CurrentStateDefID = AccountTransaction.States.Cancelled;
                    returnList.Add(at);
                }
            }
            return returnList;
        }

        // Ödenmiş hasta payları için "Faturalanmış işlem iptal edilemez" hatası vermeden iptal eder
        //public void CancelMyAccountTransactionsExceptPaid()
        //{
        //    foreach (AccountTransaction at in this.AccountTransactions)
        //    {
        //        if (at.CurrentStateDefID != AccountTransaction.States.Cancelled)
        //        {
        //            if (at.IsAllowedToCancel == false)
        //            {
        //                if (at.IsPaidPatientShare())
        //                    InfoBox.Alert("Hastanın yapmış olduğu ödeme mevcuttur.\r\n" + "Malzeme/İlaç : " + at.ExternalCode + " " + at.Description);
        //                else
        //                    throw new TTException("İşlem hareketi '" + at.CurrentStateDef.DisplayText + "' durumunda olduğu için iptal edilemez. Öncelikle ödeme/faturalama işleminin iptal edilmesi gerekmektedir!\r\n" + "Malzeme/İlaç : " + at.ExternalCode + " " + at.Description);
        //            }
        //            else
        //                at.CurrentStateDefID = AccountTransaction.States.Cancelled;
        //        }
        //    }
        //}

        public bool IsPatientPaymentExists()
        {
            foreach (AccountTransaction at in AccountTransactions)
            {
                if (at.IsPaidPatientShare())
                    return true;
            }
            return false;
        }

        public virtual bool SendToENabiz()
        {
            if (IsOldAction == true)
                return false;
            return true;
        }

        public bool IsAllowedToCancel()
        {
            foreach (AccountTransaction at in AccountTransactions)
            {
                if (at.CurrentStateDefID != AccountTransaction.States.Cancelled && at.IsAllowedToCancel == false)
                    return false;
            }
            return true;
        }

        public bool IsAccountOperationDone()
        {
            return AccountTransactions.Any(x => x.CurrentStateDefID != AccountTransaction.States.Cancelled);
        }

        public void ChangeMyProtocol(SubEpisodeProtocol pSEP)
        {
            if (pSEP == null)
                throw new TTException(TTUtils.CultureService.GetText("M27247", "Yeniden fiyatlandırma yapılacak takip boş olamaz."));

            if (AccountTransactions.Count == 0) // Henüz ücretlenmemiş bir SubactionMaterial için metod çalışırsa ücretlendirme yapmasın diye eklendi
                return;

            List<AccountTransaction> cancelledAtList = CancelMyAccountTransactions();   // CancelMyAccountTransactionsExceptPaid();

            DateTime pricingDate = Common.RecTime();
            if (PricingDate.HasValue) // PricingDate dolu ise fiyat hesaplamada bu tarih kullanılır
                pricingDate = PricingDate.Value;
            else if (ActionDate.HasValue) // PricingDate boş ActionDate dolu ise fiyat hesaplamada bu tarih kullanılır
                pricingDate = ActionDate.Value;

            ArrayList col = new ArrayList();
            if (SubActionMatPricingDet.Count == 0)
                col = pSEP.Protocol.CalculatePrice(Material, Episode.PatientStatus, null, pricingDate, Episode.Patient.AgeCompleted);
            else
            {
                TTObjectContext context = new TTObjectContext(false);
                foreach (SubActionMatPricingDet subActMatPrices in SubActionMatPricingDet)
                {
                    double patientPrice = 0;
                    double payerPrice = 0;
                    ManipulatedPrice mypd = new ManipulatedPrice(context);
                    mypd.ExternalCode = subActMatPrices.ExternalCode;

                    if (!string.IsNullOrEmpty(subActMatPrices.Description))
                        mypd.Description = subActMatPrices.Description;
                    else
                        mypd.Description = "-";

                    if (subActMatPrices.PatientPrice != null)
                        patientPrice = (double)subActMatPrices.PatientPrice;

                    if (subActMatPrices.PayerPrice != null)
                        payerPrice = (double)subActMatPrices.PayerPrice;

                    mypd.Price = patientPrice + payerPrice;
                    mypd.PatientPrice = patientPrice;
                    mypd.PayerPrice = payerPrice;
                    col.Add(mypd);
                }
            }

            if (col.Count == 0)
                throw new TTException(SystemMessage.GetMessageV3(662, new string[] { Material.Name }));

            foreach (ManipulatedPrice mpd in col)
            {
                if (mpd.PatientPrice == 0 && mpd.PayerPrice == 0)
                    pSEP.AddAccountTransaction(AccountOwnerType.PAYER, this, mpd, null, AccountOperationTimeEnum.PRE);

                if (mpd.PayerPrice > 0)
                    pSEP.AddAccountTransaction(AccountOwnerType.PAYER, this, mpd, null, AccountOperationTimeEnum.PRE);

                if (mpd.PatientPrice > 0 && !IsPatientPaymentExists()) // Ödenmiş hasta payı yoksa oluşturulur
                    pSEP.AddAccountTransaction(AccountOwnerType.PATIENT, this, mpd, null, AccountOperationTimeEnum.PRE);
            }

            List<AccountTransaction> newAtList = AccountTransactions.Where(x => x.CurrentStateDefID != AccountTransaction.States.Cancelled).ToList();
            AccountTransaction.ControlAndCopyAfterChangeMyProtocol(cancelledAtList, newAtList); // İptal edilen AccTrx ler üzerindeki bilgileri, yeni oluşturulan AccTrx lere kopyalar
        }

        public void AccountOperation(AccountOperationTimeEnum pPreAccounting = AccountOperationTimeEnum.PREPOST, SubEpisodeProtocol outSEP = null)
        {
            // Sarf malzemeler stoktan düşmeden ücretlenmesin diye eklendi (alış fiyatı üzerinden ücretlenme gerekliliğinden dolayı, hem de stok ile paralel gitsin diye)
            if (this is BaseTreatmentMaterial)
            {
                if (StockActionDetail == null)
                    return;
                if (StockActionDetail.StockTransactions.Select(string.Empty).Count == 0)
                    return;
            }

            if (AccountTransactions.Any(x => x.CurrentStateDefID != AccountTransaction.States.Cancelled)) // İptalden farklı AccTrx i varsa çıkılır
                return;

            if (!Eligible.HasValue) // Eligible null ise true yapılır
                Eligible = true;

            // Ücretlenmemesi gereken durumlar
            if (IsOldAction == true || IsCancelled == true || Eligible != true || Material == null || Material.Chargable != true)
                return;

            if (SubEpisode == null)
                throw new TTException("Ücretlendirilecek malzemenin altvaka bilgisine ulaşılamıyor. (Malzeme: " + Material.Code + " " + Material.Name + ")");

            SubEpisodeProtocol sep = null;
            if (outSEP != null)
                sep = outSEP;
            else
                sep = SubEpisode.OpenSubEpisodeProtocol;

            //if (sep == null && AccountTransactions.Count == 0) // Açık takip olmasa da girilebilmesi gereken malzemeler için takip oluşturulur (Ortez_Protez den girilen malzemeler gibi)
            //    sep = CreateSEPForNewMaterial();               // Bu kod kapatıldı şimdilik, Ortez-Protez için yeni subepisode oluşturuluyor artık.

            if (sep == null)
                throw new TTException(SystemMessage.GetMessage(663));

            DateTime pricingDate = Common.RecTime();
            if (PricingDate.HasValue) // PricingDate dolu ise fiyat hesaplamada bu tarih kullanılır
                pricingDate = PricingDate.Value;
            else if (ActionDate.HasValue) // PricingDate boş ActionDate dolu ise fiyat hesaplamada bu tarih kullanılır
                pricingDate = ActionDate.Value;

            ArrayList col = new ArrayList();
            if (SubActionMatPricingDet.Count == 0)
                col = sep.Protocol.CalculatePrice(Material, Episode.PatientStatus, null, pricingDate, Episode.Patient.AgeCompleted);
            else
            {
                TTObjectContext context = new TTObjectContext(false);
                foreach (SubActionMatPricingDet subActMatPrices in SubActionMatPricingDet)
                {
                    double patientPrice = 0;
                    double payerPrice = 0;
                    ManipulatedPrice mypd = new ManipulatedPrice(context);
                    mypd.ExternalCode = subActMatPrices.ExternalCode;

                    if (!string.IsNullOrEmpty(subActMatPrices.Description))
                        mypd.Description = subActMatPrices.Description;
                    else
                        mypd.Description = "-";

                    if (subActMatPrices.PatientPrice != null)
                        patientPrice = (double)subActMatPrices.PatientPrice;

                    if (subActMatPrices.PayerPrice != null)
                        payerPrice = (double)subActMatPrices.PayerPrice;

                    mypd.Price = patientPrice + payerPrice;
                    mypd.PatientPrice = patientPrice;
                    mypd.PayerPrice = payerPrice;
                    col.Add(mypd);
                }
            }

            if (col.Count == 0)
                throw new TTException(SystemMessage.GetMessageV3(662, new string[] { Material.Name }));

            foreach (ManipulatedPrice mpd in col)
            {
                if (mpd.PatientPrice == 0 && mpd.PayerPrice == 0)
                    sep.AddAccountTransaction(AccountOwnerType.PAYER, this, mpd, null, AccountOperationTimeEnum.PRE);

                if (mpd.PayerPrice > 0)
                    sep.AddAccountTransaction(AccountOwnerType.PAYER, this, mpd, null, AccountOperationTimeEnum.PRE);

                if (mpd.PatientPrice > 0)
                    sep.AddAccountTransaction(AccountOwnerType.PATIENT, this, mpd, null, AccountOperationTimeEnum.PRE);
            }

            // Malzeme ücretlendikten sonra set içerisindeki bir malzeme ise ilgili Set Malzemesi oluşturulur ve ücretlendirilir
            ControlAndCreateSetMaterial();
        }

        public void AccountOperationAttribute()
        {
            if (Eligible == true && Material.Chargable == true && IsOldAction != true)
            {
                // Normal EpisodeAction a sahip SubActionMaterial lerin paralandirilmasinda alltaki if bloguna girecek.
                if (EpisodeAction != null)
                {
                    if (EpisodeAction.TransDef != null)
                    {
                        if (Common.IsTransitionAttributeExists(typeof(AccountOperationAttribute), EpisodeAction.TransDef))
                        {
                            if (CurrentStateDef.Status != StateStatusEnum.Cancelled)
                            {
                                // DrugOrder ve DrugOrderDetail in burada ücretlenmemesi için eklendi
                                if (!(this is DrugOrder || this is DrugOrderDetail))
                                {
                                    AccountOperationTimeEnum pPreAccounting = (AccountOperationTimeEnum)EpisodeAction.TransDef.AllAttributes["AccountOperationAttribute"].Parameters["PreAccounting"].Value;
                                    AccountOperation(pPreAccounting);
                                }
                            }
                        }
                    }
                    if (EpisodeAction.CurrentStateDef != null)
                    {
                        if (Common.IsStateAttributeExists(typeof(AccountOperationStateAttribute), EpisodeAction.CurrentStateDef))
                        {
                            if (CurrentStateDef.Status != StateStatusEnum.Cancelled)
                            {
                                // DrugOrder ve DrugOrderDetail in burada ücretlenmemesi için eklendi
                                if (!(this is DrugOrder || this is DrugOrderDetail))
                                {
                                    AccountOperationTimeEnum pPreAccounting = (AccountOperationTimeEnum)EpisodeAction.CurrentStateDef.AllAttributes["AccountOperationStateAttribute"].Parameters["PreAccounting"].Value;
                                    AccountOperation(pPreAccounting);
                                }
                            }
                        }
                    }
                }
                // SubActıonProcedureFlowable in ChildSubactionProcedure u paralandirtilmak istendiginde alltaki if bloguna girecek.
                if (SubactionProcedureFlowable != null)
                {
                    if (SubactionProcedureFlowable.TransDef != null)
                    {
                        if (Common.IsTransitionAttributeExists(typeof(AccountOperationAttribute), SubactionProcedureFlowable.TransDef))
                        {
                            if (CurrentStateDef.Status != StateStatusEnum.Cancelled)
                            {
                                AccountOperationTimeEnum pPreAccounting = (AccountOperationTimeEnum)SubactionProcedureFlowable.TransDef.AllAttributes["AccountOperationAttribute"].Parameters["PreAccounting"].Value;
                                AccountOperation(pPreAccounting);
                            }
                        }
                    }
                    if (SubactionProcedureFlowable.CurrentStateDef != null)
                    {
                        if (Common.IsStateAttributeExists(typeof(AccountOperationStateAttribute), SubactionProcedureFlowable.CurrentStateDef))
                        {
                            if (CurrentStateDef.Status != StateStatusEnum.Cancelled)
                            {
                                AccountOperationTimeEnum pPreAccounting = (AccountOperationTimeEnum)SubactionProcedureFlowable.CurrentStateDef.AllAttributes["AccountOperationStateAttribute"].Parameters["PreAccounting"].Value;
                                AccountOperation(pPreAccounting);
                            }
                        }
                    }
                }

                if (TransDef != null)
                {
                    if (Common.IsTransitionAttributeExists(typeof(AccountOperationAttribute), TransDef))
                    {

                        if (CurrentStateDef.Status != StateStatusEnum.Cancelled)
                        {
                            AccountOperationTimeEnum pPreAccounting = (AccountOperationTimeEnum)TransDef.AllAttributes["AccountOperationAttribute"].Parameters["PreAccounting"].Value;
                            AccountOperation(pPreAccounting);
                        }
                    }
                }
                else
                {
                    if (Common.IsStateAttributeExists(typeof(AccountOperationStateAttribute), CurrentStateDef))
                    {
                        if (CurrentStateDef.Status != StateStatusEnum.Cancelled)
                        {
                            AccountOperationTimeEnum pPreAccounting = (AccountOperationTimeEnum)CurrentStateDef.AllAttributes["AccountOperationStateAttribute"].Parameters["PreAccounting"].Value;
                            AccountOperation(pPreAccounting);
                        }
                    }
                }
            }
        }

        public class MaterialUnitPrice
        {
            public StockTransaction StockOutTransaction
            {
                get;
                set;
            }

            public BigCurrency UnitPrice
            {
                get;
                set;
            }
            public Double VatRate
            {
                get;
                set;
            }

            public UTSNotificationDetail UTSNotificationDetail
            {
                get;
                set;
            }
        }

        // Malzemenin alış fiyatını (alış fiyatı KDV li tutuluyor), KDV oranını ve StockTransactionID lerini döndüren metod
        public List<SubActionMaterial.MaterialUnitPrice> GetMaterialUnitPriceList()
        {
            List<SubActionMaterial.MaterialUnitPrice> unitPrices = new List<SubActionMaterial.MaterialUnitPrice>();

            if (StockActionDetail != null && StockActionDetail.StockTransactions.Select(string.Empty).Count > 0)
            {
                foreach (StockTransaction trx in StockActionDetail.StockTransactions.Select(string.Empty))
                {
                    if (trx.CurrentStateDefID == StockTransaction.States.Completed)
                    {
                        UTSNotificationDetail[] UTSNotificationDetailsArray = new UTSNotificationDetail[] { };
                        if (trx.UTSNotificationDetails != null && trx.UTSNotificationDetails.Count > 0)
                            UTSNotificationDetailsArray = trx.UTSNotificationDetails.ToArray<UTSNotificationDetail>();

                        for (int i = 0; i < trx.Amount; i++)
                        {
                            SubActionMaterial.MaterialUnitPrice unitPrice = new SubActionMaterial.MaterialUnitPrice();
                            unitPrice.StockOutTransaction = trx;
                            unitPrice.UnitPrice = trx.UnitPrice.Value; // KDV li fiyat
                            if (trx.VatRate.HasValue)
                                unitPrice.VatRate = trx.VatRate.Value;

                            if (UTSNotificationDetailsArray.Length > 0)
                                unitPrice.UTSNotificationDetail = UTSNotificationDetailsArray[i];

                            unitPrices.Add(unitPrice);
                        }
                    }
                }
            }
            return unitPrices;
        }

        // SubactionMaterial in UTSNotificationDetail i boş olan AccountTransaction larının sonradan UTSNotificationDetail larını set etmek için yazıldı.
        // İleride gerek olursa fatura ekranı hizmetler gridinin sağ klik menüsüne eklenecek )
        public void SetUTSNotificationDetailOfAccTrxs()
        {
            List<AccountTransaction> accTrxList = AccountTransactions.Where(x => x.CurrentStateDefID != AccountTransaction.States.Cancelled &&
                                                                                 x.AccountPayableReceivable.Type == APRTypeEnum.PAYER &&
                                                                                 x.StockOutTransaction != null).ToList();

            List<AccountTransaction> accTrxListNotHasUTSNotificationDetail = accTrxList.Where(x => x.UTSNotificationDetail == null).ToList();
            if (accTrxListNotHasUTSNotificationDetail.Count > 0)
            {
                List<SubActionMaterial.MaterialUnitPrice> purchasePriceList = GetMaterialUnitPriceList().Where(x => x.UTSNotificationDetail != null).ToList();
                if (purchasePriceList.Count > 0)
                {
                    List<AccountTransaction> accTrxListHasUTSNotificationDetail = accTrxList.Where(x => x.UTSNotificationDetail != null).ToList();

                    foreach (AccountTransaction accTrx in accTrxListNotHasUTSNotificationDetail)
                    {
                        foreach (SubActionMaterial.MaterialUnitPrice materialUnitPrice in purchasePriceList.Where(x => x.StockOutTransaction.ObjectID == accTrx.StockOutTransaction.ObjectID))
                        {
                            if (accTrxListHasUTSNotificationDetail.Any(x => x.StockOutTransaction.ObjectID == materialUnitPrice.StockOutTransaction.ObjectID &&
                                                                            x.UTSNotificationDetail.ObjectID == materialUnitPrice.UTSNotificationDetail.ObjectID) == false)
                            {
                                accTrx.UTSNotificationDetail = materialUnitPrice.UTSNotificationDetail;
                                accTrxListHasUTSNotificationDetail.Add(accTrx);
                                break;
                            }
                        }
                    }
                }
            }
        }

        // Toplu Faturaya Hazır veya Toplu Faturalandı durumunda Kurum Faturası varsa yeni bir malzeme/ilaç charge edilemesin kontrolü
        public void ControlSGKPayerInvoiceStatus(Episode episode)
        {
            if (episode != null)
            {
                if (!(this is PMAddingTreatmentMaterial))
                {
                    if (SystemParameter.GetParameterValue("INVOICEBYSUBEPISODE", "FALSE") == "TRUE")
                    {
                        if (SubEpisode != null)
                        {
                            if (PayerInvoice.GetReadyAndColInvByEpisodeAndPISubEpisode(ObjectContext, episode.ObjectID.ToString(), SubEpisode.ObjectID.ToString()).Count > 0)
                            {
                                string message = "İçinde bulunduğu altvaka Toplu Faturaya Hazır veya Toplu Faturalandı durumunda olduğu için malzeme/ilaç ücretlendirilemez.\r\nMalzeme/İlaç girişi yapmak istiyorsanız öncelikle Toplu Faturaya Hazır veya Toplu Faturalandı durumundaki kurum faturası işlemini iptal ediniz.\r\n(Altvaka: " + SubEpisode.ProtocolNo.ToString();
                                if (SubEpisode.ResSection != null)
                                    message += " " + SubEpisode.ResSection.Name;
                                message += ")";

                                throw new TTException(message);
                            }
                        }
                    }
                    else // Kurum Faturasını altvaka bazında kesmeyen XXXXXXlerde
                    {
                        // Ayaktan hasta ise, 1 yada daha fazla kurum faturası varsa hata verilir
                        if (episode.PatientStatus == PatientStatusEnum.Outpatient)
                        {
                            if (PayerInvoice.GetReadyAndColInvByEpisode(ObjectContext, episode.ObjectID.ToString()).Count > 0)
                                throw new TTException(SystemMessage.GetMessage(664));
                        }
                        else // Yatan hasta ise, 2 yada daha fazla kurum faturası varsa hata verilir
                        {
                            if (PayerInvoice.GetReadyAndColInvByEpisode(ObjectContext, episode.ObjectID.ToString()).Count > 1)
                                throw new TTException(SystemMessage.GetMessage(665));
                        }
                    }
                }
            }
        }

        // SP ile Paket SP nin AltVakası aynı mı kontrolü yapar
        public bool InSameSubEpisodeWithPackageSP(SubActionProcedure packageSP)
        {
            // Sadece Alt Vaka bazında fatura kesenlerde bu kontrol yapılacak
            if (SystemParameter.GetParameterValue("INVOICEBYSUBEPISODE", "FALSE") == "TRUE")
            {
                if (SubEpisode != null && packageSP.SubEpisode != null)
                {
                    if (!SubEpisode.ObjectID.Equals(packageSP.SubEpisode.ObjectID))
                        return false;
                }
            }
            return true;
        }

        public virtual List<SubActionProcedure> GetAccountableSubActionProcedures()
        {

            List<SubActionProcedure> myCol = new List<SubActionProcedure>();
            return myCol;

        }

        public virtual List<SubActionMaterial> GetAccountableSubActionMaterials()
        {
            List<SubActionMaterial> myCol = new List<SubActionMaterial>();
            return myCol;

        }

        public IEpisodeAction EpisodeActionObject
        {
            get
            {
                if (EpisodeAction != null)
                    return (IEpisodeAction)EpisodeAction;
                if (SubactionProcedureFlowable != null)
                    return (IEpisodeAction)SubactionProcedureFlowable;
                return null;
            }
            set
            {
                if (value is EpisodeAction)
                    EpisodeAction = (EpisodeAction)value;
                if (value is SubactionProcedureFlowable)
                    SubactionProcedureFlowable = (SubactionProcedureFlowable)value;
            }
        }

        /// <summary>
        /// Class'a bağlanan StoreUsageAttribute yoksa StoreUsageEnum.UseMasterResource, varda parametre değeri ne ise o döner.
        /// </summary>
        public StoreUsageEnum GetStoreUsage()
        {
            if (Common.IsAttributeExists(typeof(StoreUsageAttribute), (TTObject)this) == false)
            {
                return StoreUsageEnum.UseMasterResource;
            }
            else
            {
                string storeUsageEnum = ObjectDef.Attributes["STOREUSAGEATTRIBUTE"].Parameters["StoreUsage"].Value.ToString();
                switch (storeUsageEnum)
                {
                    case "0":
                        return StoreUsageEnum.Nothing;
                    //break;
                    case "1":
                        return StoreUsageEnum.UseMasterResource;
                    //break;
                    case "2":
                        return StoreUsageEnum.UseFromResource;
                    //break;
                    case "3":
                        return StoreUsageEnum.UseSecMasterResource;
                    //break;
                    case "4":
                        return StoreUsageEnum.UseUser;
                    //break;
                    case "5":
                        return StoreUsageEnum.UseSpecialResource;
                    default:
                        return StoreUsageEnum.UseMasterResource;
                        //break;
                }
            }
        }

        public void SetStore(IEpisodeActionResources episodeActionResources)
        {
            switch (GetStoreUsage())
            {
                case StoreUsageEnum.UseMasterResource:
                    Store = episodeActionResources.GetMasterResource().Store;
                    break;
                case StoreUsageEnum.UseFromResource:
                    Store = episodeActionResources.GetFromResource().Store;
                    break;
                case StoreUsageEnum.UseUser:
                    Store = Common.CurrentResource.Store;
                    break;
                case StoreUsageEnum.UseSecMasterResource:
                    Store = episodeActionResources.GetSecondaryMasterResource().Store;
                    break;
                case StoreUsageEnum.UseSpecialResource:
                    Store = episodeActionResources.SpecialResourceForStore().Store;
                    break;
            }
        }
        public class StockOutStores
        {
            public IList<SubActionMaterial> subActionMaterials = new List<SubActionMaterial>();
            public Store store;
        }

        public void StockOutOperation()
        {
            Guid malzemeObjectID = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("22F_MALZEMEOBJECTID", Guid.Empty.ToString()));
            Guid setMalzemeObjectID = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("SETMATERIALOBJECTID", Guid.Empty.ToString()));
            if (Material.ObjectID != malzemeObjectID && Material.ObjectID != setMalzemeObjectID)
            {
                if (TTObjectClasses.SystemParameter.IsWorkWithOutStock == false)
                {
                    if (StockActionDetail == null)
                    {
                        bool stockout = false;

                        if (Store == null)
                            SetStore(EpisodeAction);

                        SubActionMaterial.StockOutStores stockOutStores = new SubActionMaterial.StockOutStores();
                        stockOutStores.store = Store;
                        stockOutStores.subActionMaterials.Add(this);

                        Store store = stockOutStores.store;
                        Stock stock = store.GetStock(Material);

                        if (stock.Inheld != null)
                        {
                            if (stock.Inheld > 0 && stock.Inheld >= Amount)
                            {
                                StockOut stockOut = new StockOut(ObjectContext);
                                stockOut.CurrentStateDefID = StockOut.States.New;
                                stockOut.Store = store;
                                stockOut.TransactionDate = ActionDate;


                                StockActionDetailOut stockActionDetailOut = (StockActionDetailOut)stockOut.StockOutMaterials.AddNew();
                                stockActionDetailOut.Material = Material;
                                stockActionDetailOut.Amount = Amount;
                                stockActionDetailOut.StockLevelType = StockLevelType.NewStockLevel;
                                stockActionDetailOut.Status = StockActionDetailStatusEnum.New;
                                StockActionDetail = stockActionDetailOut;
                                stockOut.Update();
                                stockOut.CurrentStateDefID = StockOut.States.Completed;

                                //this.ObjectContext.Update();
                                //this.CurrentStateDefID = SubActionMaterial.States.Completed;


                                //UTS için eklendi
                                if (this is BaseTreatmentMaterial)
                                {
                                    stockActionDetailOut.Patient = ((BaseTreatmentMaterial)this).Patient;
                                }
                            }
                            else
                            {
                                string message = string.Empty;
                                if (EpisodeAction != null)
                                    message = TTUtils.CultureService.GetText("M27254", "Yeterli Mevcut yoktur.") + " Malzeme : " + Material.Name.ToString() + " " + Material.NATOStockNO.ToString() + " İşlem No :  " + EpisodeAction.ID.ToString();
                                else
                                    message = TTUtils.CultureService.GetText("M27254", "Yeterli Mevcut yoktur.") + " Malzeme : " + Material.Name.ToString() + " " + Material.NATOStockNO.ToString();
                                throw new TTException(message);
                            }
                        }
                    }
                }
            }
        }


        public void StockOutCancelOperation()
        {
            if (StockActionDetail != null)
            {
                StockOut stockOut = (StockOut)ObjectContext.GetObject(StockActionDetail.StockAction.ObjectID, typeof(StockOut));
                stockOut.CurrentStateDefID = StockOut.States.Cancelled;
            }
        }


        public void StockOutByEpisodeActionAttribute()
        {
            if (CurrentStateDefID != SubActionMaterial.States.Cancelled && CurrentStateDefID != BaseTreatmentMaterial.States.Cancelled)
            {
                if (IsOldAction != true)
                {
                    if (TTObjectClasses.SystemParameter.IsWorkWithOutStock == false)
                    {
                        if (StockActionDetail == null)
                        {
                            bool stockout = false;
                            if (EpisodeAction != null)
                            {
                                if (Common.IsStateAttributeExists(typeof(StockOutTreatmentMaterialOnSaveAttribute), EpisodeAction.OriginalStateDef))
                                {

                                    StockOutOperation();
                                    stockout = true;
                                }
                                if (EpisodeAction.TransDef != null && !stockout)
                                {
                                    if (Common.IsTransitionAttributeExists(typeof(StockOutTreatmentMaterialOnTransitionAttribute), EpisodeAction.TransDef))
                                    {
                                        StockOutOperation();
                                        stockout = true;
                                    }
                                }
                            }
                            if (SubactionProcedureFlowable != null && !stockout)
                            {
                                if (Common.IsStateAttributeExists(typeof(StockOutTreatmentMaterialOnSaveAttribute), SubactionProcedureFlowable.OriginalStateDef))
                                {
                                    StockOutOperation();
                                    stockout = true;
                                }
                                if (SubactionProcedureFlowable.TransDef != null && !stockout)
                                {
                                    if (Common.IsTransitionAttributeExists(typeof(StockOutTreatmentMaterialOnTransitionAttribute), SubactionProcedureFlowable.TransDef))
                                    {
                                        StockOutOperation();
                                        stockout = true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }


        public ISUTEpisodeAction GetSUTEpisodeAction()
        {
            return EpisodeAction;
        }

        public ISUTRulableObject GetSUTRulableObject()
        {
            return Material;
        }

        public DateTime? GetRuleDate()
        {
            return ActionDate;
        }

        public double? GetRuleAmount()
        {
            return Amount;
        }

        public long? GetDoctorSpecialityCode()
        {
            return null;
        }

        // Yeni paket içine alma metodu
        public void AddIntoPackage(PackageDefinition pPackageDefinition, SubActionPackageProcedure pMasterPackSubActProcedure)
        {
            if (!IsCancelled)
                MasterPackgSubActionProcedure = pMasterPackSubActProcedure;

            foreach (AccountTransaction accTrx in AccountTransactions)
            {
                if (accTrx.IsAllowedToCancel == true)
                    accTrx.PackageDefinition = pPackageDefinition;
            }
        }

        // Yeni paket dışına çıkarma metodu
        public void RemoveFromPackage()
        {
            if (!IsCancelled)
                MasterPackgSubActionProcedure = null;

            foreach (AccountTransaction accTrx in AccountTransactions)
            {
                if (accTrx.IsAllowedToCancel == true)
                    accTrx.PackageDefinition = null;
            }
        }

        // "Tahakkuk", "Yeni" ve "Medulaya Gönderilmeyecek" durumundaki "Kurum Payı" olan AccountTransaction ları
        // "Yeni" durumunda "Hasta Payı" na çevirir
        public void TurnMyAccountTransactionsToPatientShare(bool withMedulaDontSend)
        {
            if (Episode.Patient.APR.Count > 0)
            {
                foreach (AccountTransaction at in AccountTransactions)
                {
                    if (at.AccountPayableReceivable.Type == APRTypeEnum.PAYER)
                    {
                        if (at.CurrentStateDefID == AccountTransaction.States.ToBeNew || at.CurrentStateDefID == AccountTransaction.States.New || (withMedulaDontSend && at.CurrentStateDefID == AccountTransaction.States.MedulaDontSend))
                        {
                            at.CurrentStateDefID = AccountTransaction.States.New;
                            at.TurnToPatientShare();
                        }
                    }
                }
            }
        }

        // İşlem ücretinin (Hasta Payının) ödenip ödenmediği bilgisini döndürür
        public bool Paid()
        {
            // Yatan hastada ödeme kontrolü yapılmaz
            if (Episode.PatientStatus == PatientStatusEnum.Inpatient)
                return true;

            if (Episode.Patient.APR.Count > 0)
            {
                foreach (AccountTransaction at in AccountTransactions)
                {
                    if (at.SubEpisodeProtocol != null && at.SubEpisodeProtocol.CheckPaid == true)
                    {
                        if (at.InvoiceInclusion == true &&
                            at.CurrentStateDefID == AccountTransaction.States.New &&
                            at.UnitPrice > 0 &&
                            at.AccountPayableReceivable == Episode.Patient.MyAPR() &&
                            at.SubEpisodeProtocol.Brans.Code != "4400" && at.SubEpisodeProtocol.Brans.Code != "1596") // Acil branşları için ödeme kontrolü yapılmaz
                            return false;
                    }
                }
            }

            return true;
        }

        // Malzemeler ücretlendikten sonra set içerisinde ise ilgili Set Malzemesini oluşturan metod
        public void ControlAndCreateSetMaterial()
        {
            if (this is BaseTreatmentMaterial && AccountTransactions != null && AccountTransactions.Count > 0)
            {
                BaseTreatmentMaterial btm = (BaseTreatmentMaterial)this;
                string malzemeKodu = btm.GetMedulaMaterialCode(AccountTransactions[0]);
                if (!string.IsNullOrEmpty(malzemeKodu))
                {
                    BindingList<SetMaterialSubCodeDefinition.GetSetMaterialByMaterialCode_Class> setMaterialPricingDetailList = SetMaterialSubCodeDefinition.GetSetMaterialByMaterialCode(malzemeKodu);
                    if (setMaterialPricingDetailList.Count > 0)
                    {
                        if (((SetMaterialSubCodeDefinition.GetSetMaterialByMaterialCode_Class)setMaterialPricingDetailList[0]).SetMaterialPricingDetail.HasValue == false)
                            throw new TTUtils.TTException(malzemeKodu + " kodlu malzeme için Set Malzeme Tanım ekranındaki Set Malzeme bilgisi boş olamaz !");

                        PricingDetailDefinition pricingDetail = (PricingDetailDefinition)ObjectContext.GetObject(new Guid(setMaterialPricingDetailList[0].SetMaterialPricingDetail.ToString()), typeof(PricingDetailDefinition));

                        if (string.IsNullOrEmpty(pricingDetail.ExternalCode))
                            throw new TTUtils.TTException(malzemeKodu + " kodlu malzeme için Set Malzeme Tanım ekranındaki Set Malzemenin Fiyat Tanımındaki Kod bilgisi boş olamaz !");

                        SetMaterial setMaterial = null;

                        // Aynı EpisodeAction da oluşturulmuş aynı kodlu Set Malzeme zaten varsa tekrar oluşturulmaz
                        foreach (BaseTreatmentMaterial treatmentMaterial in btm.EpisodeAction.TreatmentMaterials)
                        {
                            if (treatmentMaterial is SetMaterial && treatmentMaterial.AccountTransactions != null && treatmentMaterial.AccountTransactions.Count > 0)
                            {
                                if (treatmentMaterial.AccountTransactions[0].ExternalCode.Equals(pricingDetail.ExternalCode) && treatmentMaterial.AccountTransactions[0].CurrentStateDefID != AccountTransaction.States.Cancelled)
                                {
                                    setMaterial = treatmentMaterial as SetMaterial;
                                    break;
                                }
                            }
                        }

                        if (setMaterial == null)
                        {
                            // Aynı SEP te aynı kodlu Set Malzeme zaten varsa tekrar oluşturulmaz
                            BindingList<AccountTransaction.GetMaterialTrxsBySEPAndCode_Class> setMaterialList = AccountTransaction.GetMaterialTrxsBySEPAndCode(AccountTransactions[0].SubEpisodeProtocol.ObjectID, pricingDetail.ExternalCode);
                            if (setMaterialList.Count > 0)
                                setMaterial = (SetMaterial)ObjectContext.GetObject(new Guid(setMaterialList[0].SubActionMaterial.ToString()), typeof(SetMaterial));
                            else
                            {
                                Guid setMaterialObjectID = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("SETMATERIALOBJECTID", Guid.Empty.ToString()));
                                if (setMaterialObjectID == Guid.Empty)
                                    throw new TTUtils.TTException("Oluşturulacak set malzeme tanımının okunacağı SETMATERIALOBJECTID isimli sistem parametresi bulunamadı veya değeri boş !");

                                setMaterial = new SetMaterial(ObjectContext);
                                setMaterial.Material = (Material)ObjectContext.GetObject(setMaterialObjectID, typeof(Material));
                                setMaterial.EpisodeAction = btm.EpisodeAction;
                                setMaterial.Amount = 1;

                                SubActionMatPricingDet subActionMatPricingDet = new SubActionMatPricingDet(ObjectContext);
                                subActionMatPricingDet.SubActionMaterial = setMaterial;
                                subActionMatPricingDet.ExternalCode = pricingDetail.ExternalCode;
                                subActionMatPricingDet.Description = pricingDetail.Description;
                                subActionMatPricingDet.Amount = 1;

                                if (AccountTransactions[0].AccountPayableReceivable.Type == APRTypeEnum.PAYER)
                                    subActionMatPricingDet.PayerPrice = (double)pricingDetail.Price;
                                else
                                    subActionMatPricingDet.PatientPrice = (double)pricingDetail.Price;

                                setMaterial.AccountOperation(AccountOperationTimeEnum.PREPOST);
                            }
                        }

                        btm.SetMaterial = setMaterial;
                    }
                }
            }
        }

        /*
        public void SetAmountAndDateListForAddAccountTransaction(ref List<EpisodeProtocol.AddAccountTransactionParameter> addAccountTransactionParameterList)
        {
            if (this is PMAddingPSMaterial)
                return;
            
            DrugDefinition drugDefinition = Material as DrugDefinition;
            if(drugDefinition != null)
            {
                if(drugDefinition.CreateInMedulaDontSendState == true || drugDefinition.IsArmyDrug == true) // Medulaya Gönderilmeyecek veya XXXXXX İlacı ise bölme işlemi yapılmaz
                    return;
                
                double packageAmount = 1;
                if (drugDefinition.AccTrxUnitPriceDivider.HasValue && drugDefinition.AccTrxAmountMultiplier.HasValue)
                    packageAmount = (double)((decimal)(drugDefinition.AccTrxUnitPriceDivider.Value / drugDefinition.AccTrxAmountMultiplier.Value));
                else if (drugDefinition.PackageAmount.HasValue && drugDefinition.PackageAmount.Value > 0)
                    packageAmount = drugDefinition.PackageAmount.Value;
                else
                    return;  // İlacın Ambalaj Miktarı boş veya sıfır ise miktara göre bölme işlemi yapılmaz
                
                if (Amount <= packageAmount) // İlacın Miktarı, Ambalaj Miktarından küçük veya eşitse bölme işlemi yapılmaz
                    return;

                double restAmount = Amount.Value;
                while (restAmount > 0)
                {
                    EpisodeProtocol.AddAccountTransactionParameter addAccountTransactionParameter = new EpisodeProtocol.AddAccountTransactionParameter();

                    if (restAmount >= packageAmount)
                        addAccountTransactionParameter.Amount = packageAmount;
                    else
                        addAccountTransactionParameter.Amount = restAmount;

                    addAccountTransactionParameterList.Add(addAccountTransactionParameter);
                    restAmount -= packageAmount;
                }
            }
        }
         */

        public void SetAmountAndDateListForSEPAddAccTrx(ref List<SubEpisodeProtocol.AddAccountTransactionParameter> addAccountTransactionParameterList)
        {
            if (Material is DrugDefinition) // İlaç
            {
                if (Amount <= 1)
                    return;

                DrugDefinition drugDefinition = Material as DrugDefinition;
                bool drugUsedType = DrugOrder.GetDrugUsedType(drugDefinition);

                // drugUsedType == false -> Şişe, şurup gibi ilaçlar için amount u 1 yapmak gerekiyor 
                // çünkü ilaç mesela 3 * 2 girildiğinde SubactionMaterial.Amount = 2 oluyor ama bizim bunu 1 şişe olarak ücretlendirmemiz gerekiyor
                if (this is DrugOrderDetail && drugUsedType == false)
                {
                    SubEpisodeProtocol.AddAccountTransactionParameter addAccountTransactionParameter = new SubEpisodeProtocol.AddAccountTransactionParameter();
                    addAccountTransactionParameterList.Add(addAccountTransactionParameter);
                }
                else
                {
                    double packageAmount = 1;
                    //if (drugDefinition.AccTrxUnitPriceDivider.HasValue && drugDefinition.AccTrxAmountMultiplier.HasValue)
                    //    packageAmount = (double)((decimal)(drugDefinition.AccTrxUnitPriceDivider.Value / drugDefinition.AccTrxAmountMultiplier.Value));
                    if (drugDefinition.PackageAmount.HasValue && drugDefinition.PackageAmount.Value > 0)
                        packageAmount = drugDefinition.PackageAmount.Value;
                    else
                        return;  // İlacın Ambalaj Miktarı boş veya sıfır ise miktara göre bölme işlemi yapılmaz

                    if (Amount <= packageAmount) // İlacın Miktarı, Ambalaj Miktarından küçük veya eşitse bölme işlemi yapılmaz
                        return;

                    double restAmount = Amount.Value;
                    while (restAmount > 0)
                    {
                        SubEpisodeProtocol.AddAccountTransactionParameter addAccountTransactionParameter = new SubEpisodeProtocol.AddAccountTransactionParameter();

                        if (restAmount >= packageAmount)
                            addAccountTransactionParameter.Amount = packageAmount;
                        else
                            addAccountTransactionParameter.Amount = restAmount;

                        addAccountTransactionParameterList.Add(addAccountTransactionParameter);
                        restAmount -= packageAmount;
                    }
                }
            }
            else // Sarf Malzeme
            {
                // Sarf malzemelerinde alış fiyatı + %15 + %1 + %1 + %1 hesabından dolayı amount 1 de olsa buradan geçmesi gerekiyor
                List<SubActionMaterial.MaterialUnitPrice> purchasePriceList = GetMaterialUnitPriceList();

                // Alış fiyat listesi boş ise, alış stok transationlarına ulaşılamamıştır bu durumda liste boş gelebilir ve hata verilmez
                // Fakat listede eleman varsa, eleman sayısı SubactionMaterial.Amount'un yukarı yuvarlanmışı kadar (küsüratlı değerler için) olmalıdır, eğer farklılık varsa hata verilir.
                if (purchasePriceList.Count > 0 && Amount.HasValue && purchasePriceList.Count != Math.Ceiling(Amount.Value))
                    throw new TTException("Sarf malzeme için alış fiyatı listesindeki kayıt sayısı ile miktar arasında uyumsuzluk var. (" + Material.Barcode + " " + Material.Name + ")");

                SubActionMaterial.MaterialUnitPrice[] purchasePriceArray = purchasePriceList.ToArray<SubActionMaterial.MaterialUnitPrice>();

                for (int i = 0; i < Amount; i++)
                {
                    SubEpisodeProtocol.AddAccountTransactionParameter addAccountTransactionParameter = new SubEpisodeProtocol.AddAccountTransactionParameter();
                    if ((Amount - i) < 1) // Küsüratlı miktarlar için güncelleme
                        addAccountTransactionParameter.Amount = (Amount - i);

                    if (purchasePriceArray.Length > 0)
                    {
                        addAccountTransactionParameter.StockOutTransaction = purchasePriceArray[i].StockOutTransaction;
                        addAccountTransactionParameter.PurchasePrice = purchasePriceArray[i].UnitPrice;
                        addAccountTransactionParameter.PurchaseVatRate = purchasePriceArray[i].VatRate;
                        addAccountTransactionParameter.UTSNotificationDetail = purchasePriceArray[i].UTSNotificationDetail;
                    }

                    addAccountTransactionParameterList.Add(addAccountTransactionParameter);
                }
            }
        }

        public void SetRequestedByUserAsCurrentResource()
        {
            if (CurrentStateDef.Status == StateStatusEnum.Uncompleted)
            {
                if (RequestedByUser == null)
                {
                    RequestedByUser = Common.CurrentResource;
                }
            }
        }

        #endregion Methods

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(SubActionMaterial).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == SubActionMaterial.States.New && toState == SubActionMaterial.States.Cancelled)
                PostTransition_New2Cancelled();
            else if (fromState == SubActionMaterial.States.Completed && toState == SubActionMaterial.States.Cancelled)
                PostTransition_Completed2Cancelled();
        }

        //public SubEpisodeProtocol CreateSEPForNewMaterial()
        //{
        //    SubEpisodeProtocol newSEP = null;

        //    // Ortez Protez işleminden, SGK takibi faturalanmış olsa da malzeme girilebilmesi istendiği için bir takip oluşturulur
        //    if (this is OrthesisProthesisRequestTreatmentMaterial)
        //    {
        //        SubEpisodeProtocol parentSEP = SubEpisode.LastActiveSubEpisodeProtocol;
        //        if (parentSEP != null && parentSEP.IsSGK && parentSEP.IsInvoiced)
        //        {
        //            string sgkOPPayerObjectID = SystemParameter.GetParameterValue("SGKORTHESISPROSTHESISPAYERDEFINITION", "6317ad68-9496-410a-b890-84da68d3f67c");
        //            PayerDefinition sgkOPPayer = this.ObjectContext.GetObject<PayerDefinition>(new Guid(sgkOPPayerObjectID));

        //            if (sgkOPPayer == null)
        //                throw new TTException(TTUtils.CultureService.GetText("M26872", "SGK Ortez Protez kurumu bulunamadı.Sistem parametrelerini kontrol ediniz.(Bknz: SGKORTHESISPROSTHESISPAYERDEFINITION)"));

        //            SubEpisodeProtocol.SEPProperty SEPProperty = new SubEpisodeProtocol.SEPProperty();
        //            SEPProperty.payer = sgkOPPayer;
        //            SEPProperty.protocol = sgkOPPayer.GetProtocol(SubEpisode.Episode.Patient, parentSEP.MedulaSigortaliTuru);

        //            newSEP = parentSEP.CloneForNewSEP(SEPCloneTypeEnum.OrthesisProsthesisMaterial, SEPProperty);
        //        }
        //    }

        //    return newSEP;
        //}
    }
}
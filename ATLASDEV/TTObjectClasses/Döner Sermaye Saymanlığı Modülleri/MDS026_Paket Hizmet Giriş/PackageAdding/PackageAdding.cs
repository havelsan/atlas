
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
    /// Paket Hizmet Girişi
    /// </summary>
    public  partial class PackageAdding : EpisodeAction, IWorkListEpisodeAction
    {
        protected void PostTransition_Completed2Cancelled()
        {
            // From State : Completed   To State : Cancelled
#region PostTransition_Completed2Cancelled
            base.Cancel();
            
            IList accTrxList = null;
            foreach(SubActionPackageProcedure SubPackProc in SubActionPackageProcedures)
            {
                //Paket tanımı PackageProcedureDefinition da var PackageDefinition da yoksa null olabiliyor, bu durumda hata alınmaması için
                if(SubPackProc.PackageDefinition != null)
                {
                    accTrxList = AccountTransaction.GetTransactionsBySEPAndPackageDef(ObjectContext, SubPackProc.AccountTransactions[0].SubEpisodeProtocol.ObjectID, SubPackProc.PackageDefinition.ObjectID);

                    foreach (AccountTransaction at in accTrxList)
                    {
                        if (at.SubActionProcedure != null)
                        {
                            if (at.SubActionProcedure.MasterPackgSubActionProcedure == SubPackProc)
                                at.SubActionProcedure.ChangeMyProtocol(at.SubEpisodeProtocol);
                        }
                        if (at.SubActionMaterial != null)
                        {
                            if (at.SubActionMaterial.MasterPackgSubActionProcedure == SubPackProc)
                                at.SubActionMaterial.ChangeMyProtocol(at.SubEpisodeProtocol);
                        }
                    }
                }
            }

#endregion PostTransition_Completed2Cancelled
        }

        protected void UndoTransition_Completed2Cancelled(TTObjectStateTransitionDef transitionDef)
        {
            // From State : Completed   To State : Cancelled
#region UndoTransition_Completed2Cancelled
            NoBackStateBack();
#endregion UndoTransition_Completed2Cancelled
        }

        protected void PostTransition_New2Completed()
        {
            // From State : New   To State : Completed
#region PostTransition_New2Completed
            
            ControlRequiredProperties();
            
            // Paketleri Ãœcretlendir ve İndirim/Artırım uygula
            double discountPercent = 0;
            foreach(SubActionPackageProcedure SubPackProc in SubActionPackageProcedures)
            {
                if(SubPackProc.StartDate != null && SubPackProc.EndDate != null)
                {
                    SubPackProc.StartDate = Convert.ToDateTime(Convert.ToDateTime(SubPackProc.StartDate).ToString("yyyy-MM-dd 00:00:00"));
                    SubPackProc.EndDate = Convert.ToDateTime(Convert.ToDateTime(SubPackProc.EndDate).ToString("yyyy-MM-dd 23:59:59"));
                    //SubPackProc.AccountOperation(AccountOperationTimeEnum.PREPOST, SubPackProc.StartDate, SubPackProc.EndDate);
                }
                else
                    SubPackProc.AccountOperation(AccountOperationTimeEnum.PREPOST);
                
                if(SubPackProc.DiscountPercent != null && SubPackProc.DiscountPercent != 0)
                {
                    foreach(AccountTransaction AccTrx in SubPackProc.AccountTransactions)
                    {
                        discountPercent = (double) SubPackProc.DiscountPercent;
                        if (discountPercent > 100)
                        {
                            AccTrx.UnitPrice = Math.Round((double) AccTrx.UnitPrice * (discountPercent / 100),8);
                            AccTrx.Description = AccTrx.Description + " (%" + (discountPercent - 100).ToString() + " ARTIRIM)";
                        }
                        else
                        {
                            AccTrx.UnitPrice = Math.Round((double) AccTrx.UnitPrice * (1 - (discountPercent / 100)),8);
                            AccTrx.Description = AccTrx.Description + " (%" + discountPercent.ToString() + " İNDİRİM)";
                        }
                    }
                }
            }

#endregion PostTransition_New2Completed
        }

        protected void UndoTransition_New2Completed(TTObjectStateTransitionDef transitionDef)
        {
            // From State : New   To State : Completed
#region UndoTransition_New2Completed
            NoBackStateBack();
#endregion UndoTransition_New2Completed
        }

#region Methods
        public override ActionTypeEnum ActionType
        {
            get {
                return ActionTypeEnum.EpisodeAccountAction;
            }
        }
       
        
        public override void Cancel()
        {
            NoCancel();
        }
        
        public void ControlRequiredProperties()
        {
            if(SubActionPackageProcedures.Count == 0)
                throw new TTUtils.TTException(SystemMessage.GetMessage(620));
            
            bool isMedulaEpisode = SubEpisode.IsSGK;
            
            foreach(SubActionPackageProcedure spp in SubActionPackageProcedures)
            {
                if (spp.StartDate != null && spp.EndDate == null)
                    throw new TTUtils.TTException(TTUtils.CultureService.GetText("M26681", "Paketin Başlangıç Tarihi girilmişse Bitiş Tarihi de girilmelidir."));

                if (spp.StartDate == null && spp.EndDate != null)
                    throw new TTUtils.TTException(TTUtils.CultureService.GetText("M26682", "Paketin Bitiş Tarihi girilmişse Başlangıç Tarihi de girilmelidir."));
                
                if(isMedulaEpisode)
                {
                    if(spp.Amount > 1)
                        throw new TTUtils.TTException("Adet birden çok olamaz. Birden çok paket girmek için yeni satır açınız veya İki Tarih Arası Paket Hizmet sekmesinden ekleyiniz. (Paket: " + spp.ProcedureObject.Code + " " + spp.ProcedureObject.Name  + ")");
                    
                    if(spp.Brans == null)
                        throw new TTUtils.TTException("Branş boş olamaz. (Paket: " + spp.ProcedureObject.Code + " " + spp.ProcedureObject.Name  + ")");
                    
                    if(spp.Doktor == null)
                        throw new TTUtils.TTException("Doktor boş olamaz. (Paket: " + spp.ProcedureObject.Code + " " + spp.ProcedureObject.Name  + ")");
                    
                    if(spp.ProcedureObject != null)
                    {
                        // Medula Hizmet Grubu 'Diğer İşlem Bilgisi' ise, Rapor Takip No kontrolü yapılır
                        if(spp.ProcedureObject.MedulaProcedureType == MedulaSUTGroupEnum.digerIslemBilgileri)
                        {
                            if(spp.ProcedureObject.MedulaReportNecessity != null && spp.MedulaReportNo == null)
                            {
                                bool isRequired = false;
                                
                                if(spp.ProcedureObject.MedulaReportNecessity == MedulaRaporZorunluluguEnum.Zorunlu)
                                    isRequired = true;
                                else if(spp.ProcedureObject.MedulaReportNecessity == MedulaRaporZorunluluguEnum.AyaktanHastayaZorunlu)
                                {
                                    if(Episode.PatientStatus == PatientStatusEnum.Outpatient)
                                        isRequired = true;
                                }
                                else if(spp.ProcedureObject.MedulaReportNecessity == MedulaRaporZorunluluguEnum.YatanHastayaZorunlu)
                                {
                                    if(Episode.PatientStatus != PatientStatusEnum.Outpatient )
                                        isRequired = true;
                                }
                                
                                if(isRequired)
                                    throw new TTUtils.TTException("Rapor Takip No boş olamaz. (Paket: " + spp.ProcedureObject.Code + " " + spp.ProcedureObject.Name  + ")");
                            }
                        }
                    }
                }
            }
        }
        
        public bool MedulaRequiredPropertiesOKToAdd()
        {
            if(SubEpisode.IsSGK)
            {
                if(Brans == null)
                {
                    TTUtils.InfoMessageService.Instance.ShowMessage(TTUtils.CultureService.GetText("M25297", "Branş seçiniz."));
                    return false;
                }
                if(Doktor == null)
                {
                    TTUtils.InfoMessageService.Instance.ShowMessage(TTUtils.CultureService.GetText("M25524", "Doktor seçiniz."));
                    return false;
                }
                // Medula Hizmet Grubu 'Diğer İşlem Bilgisi' ise, Rapor Takip No kontrolü yapılır
                if(PackageProcedureDefinition.MedulaProcedureType == MedulaSUTGroupEnum.digerIslemBilgileri)
                {
                    if(PackageProcedureDefinition.MedulaReportNecessity != null && string.IsNullOrEmpty(RaporTakipNo.Trim()))
                    {
                        bool isRequired = false;
                        
                        if(PackageProcedureDefinition.MedulaReportNecessity == MedulaRaporZorunluluguEnum.Zorunlu)
                            isRequired = true;
                        else if(PackageProcedureDefinition.MedulaReportNecessity == MedulaRaporZorunluluguEnum.AyaktanHastayaZorunlu)
                        {
                            if(Episode.PatientStatus == PatientStatusEnum.Outpatient)
                                isRequired = true;
                        }
                        else if(PackageProcedureDefinition.MedulaReportNecessity == MedulaRaporZorunluluguEnum.YatanHastayaZorunlu)
                        {
                            if(Episode.PatientStatus != PatientStatusEnum.Outpatient)
                                isRequired = true;
                        }
                        
                        if(isRequired)
                        {
                            TTUtils.InfoMessageService.Instance.ShowMessage(TTUtils.CultureService.GetText("M26750", "Rapor Takip No giriniz."));
                            return false;
                        }
                    }
                }
            }
            return true;
        }
        
        public void AddSubactionPackageProcedures()
        {

                        if(!MedulaRequiredPropertiesOKToAdd())
                            return;

                        // Önceden girilmiş paket hizmetlerinin tarihlerini list e dolduruyor
                        List<string> packageDates = new List<string>();
                        BindingList<AccountTransaction.GetPackageTrxsByEpisode_Class> packageTrxList = AccountTransaction.GetPackageTrxsByEpisode(ObjectContext, Episode.ObjectID);
                        foreach (AccountTransaction.GetPackageTrxsByEpisode_Class packageTrx in packageTrxList)
                        {
                            if (!packageDates.Contains(Convert.ToDateTime(packageTrx.TransactionDate).ToString("dd.MM.yyyy")))
                                packageDates.Add(Convert.ToDateTime(packageTrx.TransactionDate).ToString("dd.MM.yyyy"));
                        }

                        string existingDates = string.Empty;
                        // İki tarih arası paketleri ekle
                        DateTime endDate = Convert.ToDateTime(EndDate);
                        DateTime startDate = Convert.ToDateTime(StartDate);
                        int dateDifference = Common.DateDiffV2(0,endDate,startDate,false);
                        TTObjectContext objectContext = new TTObjectContext(false);
                        if (PackageProcedureDefinition.HolidaysIncluded == true)
                        {
                            for (int i = 0; i <= dateDifference; i++)
                            {
                                // O tarihli bir paket önceden girilmişse, paketi eklemiyor
                                if (!packageDates.Contains(Convert.ToDateTime(StartDate).AddDays((double)i).ToString("dd.MM.yyyy")))
                                {
                                    SubActionPackageProcedure packageProc = new SubActionPackageProcedure(ObjectContext);
                                    packageProc.ActionDate = Common.RecTime();
                                    packageProc.PricingDate = Convert.ToDateTime(StartDate).AddDays((double)i);
                                    packageProc.ProcedureObject = PackageProcedureDefinition;
                                    packageProc.Amount = 1;
                                    packageProc.CurrentStateDefID = SubActionPackageProcedure.States.Completed;

                                    if (DiscountPercent != null && DiscountPercent != 0)
                                        packageProc.DiscountPercent = DiscountPercent;

                                    // Medula bilgileri set edilir
                                    packageProc.SetMedulaPropertiesFromPackageAdding(this);
                                    SubActionPackageProcedures.Add(packageProc);
                                    // Paket Alt Vakası set edilir
                                    if (PackageSubEpisode != null)
                                        packageProc.SubEpisode = PackageSubEpisode;
                                }
                                else
                                    existingDates += Convert.ToDateTime(StartDate).AddDays((double)i).ToString("dd.MM.yyyy") + " , ";
                            }
                        }
                        else
                        {
                            for (int i = 0; i <= dateDifference; i++)
                            {
                                BindingList<WorkDayExceptionDef> holiday = WorkDayExceptionDef.GetWorkDayExceptions(objectContext, startDate.AddDays((double)i).Date);
                                //hasftasonu ve tatil kontrolü
                                if (startDate.AddDays((double)i).DayOfWeek != DayOfWeek.Saturday && startDate.AddDays((double)i).DayOfWeek != DayOfWeek.Sunday && holiday.Count == 0)
                                {
                                    // O tarihli bir paket önceden girilmişse, paketi eklemiyor
                                    if (!packageDates.Contains(Convert.ToDateTime(StartDate).AddDays((double)i).ToString("dd.MM.yyyy")))
                                    {
                                        SubActionPackageProcedure packageProc = new SubActionPackageProcedure(ObjectContext);
                                        packageProc.ActionDate = Common.RecTime();
                                        packageProc.PricingDate = Convert.ToDateTime(StartDate).AddDays((double)i);
                                        packageProc.ProcedureObject = PackageProcedureDefinition;
                                        packageProc.Amount = 1;
                                        packageProc.CurrentStateDefID = SubActionPackageProcedure.States.Completed;

                                        if (DiscountPercent != null && DiscountPercent != 0)
                                            packageProc.DiscountPercent = DiscountPercent;

                                        // Medula bilgileri set edilir
                                        packageProc.SetMedulaPropertiesFromPackageAdding(this);
                                        SubActionPackageProcedures.Add(packageProc);
                                        // Paket Alt Vakası set edilir
                                        if (PackageSubEpisode != null)
                                            packageProc.SubEpisode = PackageSubEpisode;
                                    }
                                    else
                                        existingDates += Convert.ToDateTime(StartDate).AddDays((double)i).ToString("dd.MM.yyyy") + " , ";
                                }
                            }
                        }
                        if (existingDates != string.Empty)
                        {
                            existingDates = existingDates.Substring(0, existingDates.Length - 3);
                             
                            TTUtils.InfoMessageService.Instance.ShowMessage("İki Tarih Arası Paket Hizmet Ekleme işleminde, ilgili tarihte zaten mevcut bir paket hizmeti olduğu için eklenmeyen tarihler bulunmaktadır.\n\rPaket Eklenmeyen Tarihler : " + existingDates);
                        }
         
        }
        
#endregion Methods

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(PackageAdding).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == PackageAdding.States.Completed && toState == PackageAdding.States.Cancelled)
                PostTransition_Completed2Cancelled();
            else if (fromState == PackageAdding.States.New && toState == PackageAdding.States.Completed)
                PostTransition_New2Completed();
        }

        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(PackageAdding).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == PackageAdding.States.Completed && toState == PackageAdding.States.Cancelled)
                UndoTransition_Completed2Cancelled(transDef);
            else if (fromState == PackageAdding.States.New && toState == PackageAdding.States.Completed)
                UndoTransition_New2Completed(transDef);
        }

    }
}
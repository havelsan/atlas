
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
    /// Döner Sermaye İnceleme ve Düzeltme
    /// </summary>
    public  partial class AccountingProcess : EpisodeAccountAction, IWorkListEpisodeAction
    {
        protected void PostTransition_New2Completed()
        {
            // From State : New   To State : Completed
#region PostTransition_New2Completed
            
            bool updateExists = false;

            foreach (AccountingProcessAction accAction in _AccountingProcessActions)
            {
                if (accAction.NewSubEpisode != null)
                {
                    TTObjectContext objectContext = new TTObjectContext(false);
                    EpisodeAction ea = (EpisodeAction)objectContext.GetObject(accAction.EpisodeAction.ObjectID, typeof(EpisodeAction).Name);
                    
                    ea.SubEpisode = accAction.NewSubEpisode;
                    
                    updateExists = true;
                    objectContext.Save();
                    objectContext.Dispose();
                }
            }
            
            foreach (AccountingProcessProcedure accProc in _AccountingProcessProcedures)
            {
                if (accProc.NewAmount != null || accProc.NewDate != null || accProc.NewStatus != null || accProc.NewUnitPrice != null || accProc.NewShare != null || accProc.NewExternalCode != null || accProc.NewDescription != null || accProc.NewSubEpisode != null)
                {
                    TTObjectContext objectContext = new TTObjectContext(false);
                    AccountTransaction acctrx = (AccountTransaction)objectContext.GetObject(accProc.AccountTransaction.ObjectID, typeof(AccountTransaction).Name);
                    
                    if (accProc.NewStatus != null)
                    {
                        if (accProc.NewStatus == AccountTrnsNewCancelStateEnum.New)
                        {
                            acctrx.CurrentStateDefID = AccountTransaction.States.New;
                            
                            /*
                            // SubationProcedure iptal state inde kalırsa, Paket Ekleme, Anlaşmalar Arası Aktarma gibi işlemlerde
                            // "İptal Edilen Nesneni Üst İlişkisi Güncellenemez" hatası alınıyor. Bu yüzden SubationProcedure
                            // iptalden farklı bir state e alınıyor.
                            
                            // Ama alamıyoruz çünkü cancel dan transactionları olmayabilir bir önceki state e
                            
                            if (acctrx.SubActionProcedure.CurrentStateDef.Status == StateStatusEnum.Cancelled)
                            {
                                if(acctrx.SubActionProcedure.PrevState != null)
                                {
                                    if(acctrx.SubActionProcedure.PrevState.StateDef.Status != StateStatusEnum.Cancelled)
                                        acctrx.SubActionProcedure.CurrentStateDefID = acctrx.SubActionProcedure.PrevState.StateDefID;
                                }
                                
                                // Previous state e set edilememişse, giriş state ine set ediliyor
                                if (acctrx.SubActionProcedure.CurrentStateDef.Status == StateStatusEnum.Cancelled)
                                {
                                    foreach (TTDefinitionManagement.TTObjectStateDef stateDef in acctrx.SubActionProcedure.CurrentStateDef.ObjectDef.StateDefs)
                                    {
                                        if (stateDef.IsEntry && stateDef.Status != StateStatusEnum.Cancelled)
                                        {
                                            acctrx.SubActionProcedure.CurrentStateDefID = stateDef.StateDefID;
                                            break;
                                        }
                                    }
                                }
                            }
                             */
                        }
                        else if (accProc.NewStatus == AccountTrnsNewCancelStateEnum.Cancelled)
                            acctrx.CurrentStateDefID =  AccountTransaction.States.Cancelled;
                        
                        // "İptal Edilen Nesnenin Üst İlişkisi Güncellenemez" hatası vermemesi için ayrı context te save güncelleniyor
                        objectContext.Save();
                    }
                    
                    if (accProc.NewAmount != null)
                    {
                        acctrx.Amount = Convert.ToDouble(accProc.NewAmount);
                        if(Convert.ToDouble(accProc.NewAmount) != Convert.ToDouble(accProc.OldAmount))
                            acctrx.MedulaInfoUpdated = true;
                    }
                    if (accProc.NewDate != null)
                    {
                        acctrx.TransactionDate = accProc.NewDate;
                        if(accProc.NewDate != accProc.OldDate)
                            acctrx.MedulaInfoUpdated = true;
                    }
                    
                    if (accProc.NewUnitPrice != null)
                    {
                        acctrx.UnitPrice = accProc.NewUnitPrice;
                        if(Convert.ToDouble(accProc.NewUnitPrice) != Convert.ToDouble(accProc.OldUnitPrice))
                            acctrx.MedulaInfoUpdated = true;
                    }
                    
                    if (accProc.NewShare != null)
                    {
                        if (accProc.NewShare == AccountTransactionShareEnum.Patient)
                            acctrx.TurnToPatientShare();
                        else if (accProc.NewShare == AccountTransactionShareEnum.Payer)
                            acctrx.TurnToPayerShare();
                    }
                    
                    if (accProc.NewExternalCode != null)
                    {
                        acctrx.ExternalCode = accProc.NewExternalCode;
                        if(accProc.NewExternalCode != accProc.ExternalCode)
                            acctrx.MedulaInfoUpdated = true;
                    }
                    
                    if (accProc.NewDescription != null)
                        acctrx.Description = accProc.NewDescription;
                    
                    //if (accProc.NewSubEpisode != null)
                    //    acctrx.SubEpisode = accProc.NewSubEpisode;
                    
                    updateExists = true;
                    objectContext.Save();
                    objectContext.Dispose();
                }
            }

            foreach (AccountingProcessMaterial accMat in _AccountingProcessMaterials)
            {
                if (accMat.NewAmount != null || accMat.NewDate != null || accMat.NewStatus != null || accMat.NewUnitPrice != null || accMat.NewShare != null  || accMat.NewExternalCode != null || accMat.NewDescription != null || accMat.NewSubEpisode != null)
                {
                    TTObjectContext objectContext = new TTObjectContext(false);
                    AccountTransaction acctrx = (AccountTransaction)objectContext.GetObject(accMat.AccountTransaction.ObjectID, typeof(AccountTransaction).Name);
                    
                    if (accMat.NewStatus != null)
                    {
                        if (accMat.NewStatus == AccountTrnsNewCancelStateEnum.New)
                            acctrx.CurrentStateDefID =  AccountTransaction.States.New;
                        else if (accMat.NewStatus == AccountTrnsNewCancelStateEnum.Cancelled)
                            acctrx.CurrentStateDefID =  AccountTransaction.States.Cancelled;
                        
                        // "İptal Edilen Nesneni Üst İlişkisi Güncellenemez" hatası vermemesi için ayrı context te save güncelleniyor
                        objectContext.Save();
                    }
                    
                    if (accMat.NewAmount != null)
                    {
                        acctrx.Amount = accMat.NewAmount;
                        if(Convert.ToDouble(accMat.NewAmount) != Convert.ToDouble(accMat.OldAmount))
                            acctrx.MedulaInfoUpdated = true;
                    }
                    
                    if (accMat.NewDate != null)
                    {
                        acctrx.TransactionDate = accMat.NewDate;
                        if(accMat.NewDate != accMat.OldDate)
                            acctrx.MedulaInfoUpdated = true;
                    }
                    
                    if (accMat.NewUnitPrice != null)
                    {
                        acctrx.UnitPrice = accMat.NewUnitPrice;
                        if(Convert.ToDouble(accMat.NewUnitPrice) != Convert.ToDouble(accMat.OldUnitPrice))
                            acctrx.MedulaInfoUpdated = true;
                    }
                    
                    if (accMat.NewShare != null)
                    {
                        if (accMat.NewShare == AccountTransactionShareEnum.Patient)
                            acctrx.TurnToPatientShare();
                        else if (accMat.NewShare == AccountTransactionShareEnum.Payer)
                            acctrx.TurnToPayerShare();
                    }
                    
                    if (accMat.NewExternalCode != null)
                    {
                        acctrx.ExternalCode = accMat.NewExternalCode;
                        if(accMat.NewExternalCode != accMat.ExternalCode)
                            acctrx.MedulaInfoUpdated = true;
                    }
                    
                    if (accMat.NewDescription != null)
                        acctrx.Description = accMat.NewDescription;
                    
                    //if (accMat.NewSubEpisode != null)
                    //    acctrx.SubEpisode = accMat.NewSubEpisode;
                    
                    updateExists = true;
                    objectContext.Save();
                    objectContext.Dispose();
                }
            }

            foreach (AccountingProcessPackage accPack in _AccountingProcessPackages)
            {
                if (accPack.NewAmount != null || accPack.NewDate != null || accPack.NewStatus != null || accPack.NewUnitPrice != null || accPack.NewShare != null  || accPack.NewExternalCode != null || accPack.NewDescription != null || accPack.NewSubEpisode != null)
                {
                    TTObjectContext objectContext = new TTObjectContext(false);
                    AccountTransaction acctrx = (AccountTransaction)objectContext.GetObject(accPack.AccountTransaction.ObjectID, typeof(AccountTransaction).Name);
                    
                    if (accPack.NewStatus != null)
                    {
                        if (accPack.NewStatus == AccountTrnsNewCancelStateEnum.New)
                            acctrx.CurrentStateDefID =  AccountTransaction.States.New;
                        else if (accPack.NewStatus == AccountTrnsNewCancelStateEnum.Cancelled)
                            acctrx.CurrentStateDefID =  AccountTransaction.States.Cancelled;

                        // "İptal Edilen Nesneni Üst İlişkisi Güncellenemez" hatası vermemesi için ayrı context te save güncelleniyor
                        objectContext.Save();
                    }
                    
                    if (accPack.NewAmount != null)
                    {
                        acctrx.Amount = Convert.ToDouble(accPack.NewAmount);
                        if(Convert.ToDouble(accPack.NewAmount) != Convert.ToDouble(accPack.OldAmount))
                            acctrx.MedulaInfoUpdated = true;
                    }
                    
                    if (accPack.NewDate != null)
                    {
                        acctrx.TransactionDate = accPack.NewDate;
                        if(accPack.NewDate != accPack.OldDate)
                            acctrx.MedulaInfoUpdated = true;
                    }
                    
                    if (accPack.NewUnitPrice != null)
                    {
                        acctrx.UnitPrice = accPack.NewUnitPrice;
                        if(Convert.ToDouble(accPack.NewUnitPrice) != Convert.ToDouble(accPack.OldUnitPrice))
                            acctrx.MedulaInfoUpdated = true;
                    }
                    
                    if (accPack.NewShare != null)
                    {
                        if (accPack.NewShare == AccountTransactionShareEnum.Patient)
                            acctrx.TurnToPatientShare();
                        else if (accPack.NewShare == AccountTransactionShareEnum.Payer)
                            acctrx.TurnToPayerShare();
                    }
                    
                    if (accPack.NewExternalCode != null)
                    {
                        acctrx.ExternalCode = accPack.NewExternalCode;
                        if(accPack.NewExternalCode != accPack.ExternalCode)
                            acctrx.MedulaInfoUpdated = true;
                    }
                    
                    if (accPack.NewDescription != null)
                        acctrx.Description = accPack.NewDescription;
                    
                    //if (accPack.NewSubEpisode != null)
                    //    acctrx.SubEpisode = accPack.NewSubEpisode;
                    
                    updateExists = true;
                    objectContext.Save();
                    objectContext.Dispose();
                }
            }
            
            // Yeni eklenen AltVakalar için MedulaProvision oluşturulur
            foreach(SubEpisode se in Episode.SubEpisodes)
            {
                if(se.StarterEpisodeAction == this && se.IsSGK)
                {
                    /*
                    MedulaProvision medulaProvision = new MedulaProvision(this.ObjectContext);
                    medulaProvision.CurrentStateDefID = MedulaProvision.States.New;
                    medulaProvision.SubEpisode = se;
                    medulaProvision.Episode = this.Episode;
                    medulaProvision.Status = MedulaSubEpisodeStatusEnum.ProvisionNoNotExists;
                    medulaProvision.GetAndSetNextOrderNo();
                    
                    if(se.PatientStatus != null)
                    {
                        if(se.PatientStatus == SubEpisodeStatusEnum.Outpatient) // Ayaktan
                            medulaProvision.TedaviTuru = TedaviTuru.GetTedaviTuru("A");
                        else if(se.PatientStatus == SubEpisodeStatusEnum.Daily) // Günübirlik
                            medulaProvision.TedaviTuru = TedaviTuru.GetTedaviTuru("G");
                        else
                            medulaProvision.TedaviTuru = TedaviTuru.GetTedaviTuru("Y");      // Yatan
                    }
                    
                    if(se.Speciality != null)
                        medulaProvision.Brans = SpecialityDefinition.GetBrans(se.Speciality.Code);
                        */
                }
            }
            
            // SuperUser herhangi bir anlaşmanın Açılış Tarihini değiştirmişse güncellenir
            if (Common.CurrentUser.IsSuperUser)
            {
                foreach(AccountingProcessProtocol apProtocol in AccountingProcessProtocols)
                {
                    if(!apProtocol.OPENINGDATE.HasValue)
                        throw new TTUtils.TTException(TTUtils.CultureService.GetText("M25184", "Anlaşmanın Açılış Tarihi boş olamaz !"));
                    else
                    {
                        EpisodeProtocol ep = (EpisodeProtocol)ObjectContext.GetObject(new Guid(apProtocol.EPOBJECTID), typeof(EpisodeProtocol));
                        if(apProtocol.OPENINGDATE != ep.OpeningDate)
                        {
                            ep.OpeningDate = apProtocol.OPENINGDATE;
                            updateExists = true;
                        }
                    }
                }
            }
            
            //if(!updateExists)
            //    throw new TTUtils.TTException("Hiç değiştirme/düzeltme yapılmadı!");

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
        public override void Cancel()
        {
            NoCancel();
        }
        
        public override ActionTypeEnum ActionType
        {
            get {
                return ActionTypeEnum.EpisodeAccountAction;
            }
        }
        
#endregion Methods

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(AccountingProcess).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == AccountingProcess.States.New && toState == AccountingProcess.States.Completed)
                PostTransition_New2Completed();
        }

        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(AccountingProcess).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == AccountingProcess.States.New && toState == AccountingProcess.States.Completed)
                UndoTransition_New2Completed(transDef);
        }

    }
}
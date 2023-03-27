
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
    /// Paket Dışına Hizmet/Malzeme Aktarma
    /// </summary>
    public  partial class TransferFromPackage : EpisodeAccountAction, IWorkListEpisodeAction
    {
        protected void PostTransition_New2Completed()
        {
            // From State : New   To State : Completed
#region PostTransition_New2Completed
            
            EpisodeProtocol targetEP;

            IList EPList = null; // EpisodeProtocol.GetByEpisodeAndPayerAndProtocol(this.ObjectContext, this.Episode.ObjectID.ToString(), this.Payer.ObjectID.ToString(), this.Protocol.ObjectID.ToString());
            if (EPList.Count >0 )
                targetEP = (EpisodeProtocol)EPList[0];
            else
                throw new TTException(SystemMessage.GetMessage(238));
            
            foreach (TransferFromPackSubActProcs tSubActProcs in _TransferFromPackSubActProcs)
            {
                if (tSubActProcs.TransferToProtocol == true)
                {
                    tSubActProcs.SubActionProcedure.RemoveFromPackage();
                    /*
                    AccountOperationTimeEnum accountOp = AccountOperationTimeEnum.PRE;

                    if (tSubActProcs.SubActionProcedure.MasterPackgSubActionProcedure != null)
                        tSubActProcs.SubActionProcedure.MasterPackgSubActionProcedure = null;
                    
                    // Önceki AccountTransaction lar iptal edilir
                    tSubActProcs.SubActionProcedure.CancelMyAccountTransactions();
                    
                    ArrayList col = targetEP.Protocol.CalculatePrice(tSubActProcs.SubActionProcedure.ProcedureObject, this.Episode.PatientStatus , null, (DateTime)tSubActProcs.SubActionProcedure.PricingDate, this.Episode.Patient.Age);
                    if (col.Count == 0)
                        throw new TTException(SystemMessage.GetMessage(468));
                    else
                    {
                        foreach (ManipulatedPrice mpd in col)
                        {
                            if (mpd.PatientPrice == 0 && mpd.PayerPrice == 0)
                                targetEP.AddAccountTransaction(AccountOwnerType.PAYER, tSubActProcs.SubActionProcedure, mpd, null, accountOp);
                            if (mpd.PayerPrice > 0)
                                targetEP.AddAccountTransaction(AccountOwnerType.PAYER, tSubActProcs.SubActionProcedure, mpd, null, accountOp);
                            if (mpd.PatientPrice > 0)
                                targetEP.AddAccountTransaction(AccountOwnerType.PATIENT, tSubActProcs.SubActionProcedure, mpd, null, accountOp);
                        }
                    }

                    foreach (AccountTransaction atx in tSubActProcs.SubActionProcedure.AccountTransactions)
                    {
                        if (atx.CurrentStateDefID == AccountTransaction.States.New || atx.CurrentStateDefID == AccountTransaction.States.ToBeNew)
                        {
                            atx.TransactionDate = tSubActProcs.SubActionProcedure.PricingDate;
                            atx.PackageOutReason = this.PackageOutReason;
                            
                            // ameliyat ve paket giriş action ındaki indirim ve bindirimi yeni acctrx lere yansıtmak için aşağıdaki kısım
                            if (tSubActProcs.SubActionProcedure.DiscountPercent != null && tSubActProcs.SubActionProcedure.DiscountPercent != 0)
                            {
                                if ((double)tSubActProcs.SubActionProcedure.DiscountPercent > 100)
                                {
                                    atx.UnitPrice = Math.Round((double)(atx.UnitPrice * (tSubActProcs.SubActionProcedure.DiscountPercent / 100)),8);
                                    atx.Description = atx.Description + " (%" + (tSubActProcs.SubActionProcedure.DiscountPercent - 100).ToString() + " ARTIRIM)";
                                }
                                else
                                {
                                    atx.UnitPrice = Math.Round((double)(atx.UnitPrice * (1 - (tSubActProcs.SubActionProcedure.DiscountPercent / 100))),8);
                                    atx.Description = atx.Description + " (%" + tSubActProcs.SubActionProcedure.DiscountPercent.ToString() + " İNDİRİM)";
                                }
                            }
                        }
                    }
                    */
                }
            }
            
            foreach (TransferFromPackSubActMats tSubActMats in _TransferFromPackSubActMats)
            {
                if (tSubActMats.TransferToProtocol == true)
                {
                    tSubActMats.SubActionMaterial.RemoveFromPackage();
                    /*
                    AccountOperationTimeEnum accountOp = AccountOperationTimeEnum.PRE;
                    
                    if (tSubActMats.SubActionMaterial.MasterPackgSubActionProcedure != null)
                        tSubActMats.SubActionMaterial.MasterPackgSubActionProcedure = null;
                    
                    // Önceki AccountTransaction lar iptal edilir
                    tSubActMats.SubActionMaterial.CancelMyAccountTransactions();
                    
                    ArrayList col = targetEP.Protocol.CalculatePrice(tSubActMats.SubActionMaterial.Material, this.Episode.PatientStatus, null ,(DateTime)tSubActMats.SubActionMaterial.PricingDate, this.Episode.Patient.Age);
                    if (col.Count == 0)
                        throw new TTException(SystemMessage.GetMessage(468));
                    else
                    {
                        foreach (ManipulatedPrice mpd in col)
                        {
                            if (mpd.PatientPrice == 0 && mpd.PayerPrice == 0)
                                targetEP.AddAccountTransaction(AccountOwnerType.PAYER, tSubActMats.SubActionMaterial, mpd, null, accountOp);
                            if (mpd.PayerPrice > 0)
                                targetEP.AddAccountTransaction(AccountOwnerType.PAYER, tSubActMats.SubActionMaterial, mpd, null, accountOp);
                            if (mpd.PatientPrice > 0)
                                targetEP.AddAccountTransaction(AccountOwnerType.PATIENT, tSubActMats.SubActionMaterial, mpd, null, accountOp);
                        }
                    }

                    foreach (AccountTransaction atx in tSubActMats.SubActionMaterial.AccountTransactions)
                    {
                        if (atx.CurrentStateDefID == AccountTransaction.States.New || atx.CurrentStateDefID == AccountTransaction.States.ToBeNew)
                        {
                            atx.TransactionDate = tSubActMats.SubActionMaterial.PricingDate ;
                            atx.PackageOutReason = this.PackageOutReason;
                        }
                    }
                    */
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
        
#endregion Methods

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(TransferFromPackage).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == TransferFromPackage.States.New && toState == TransferFromPackage.States.Completed)
                PostTransition_New2Completed();
        }

        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(TransferFromPackage).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == TransferFromPackage.States.New && toState == TransferFromPackage.States.Completed)
                UndoTransition_New2Completed(transDef);
        }

    }
}
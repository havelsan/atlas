
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
    /// Hasta Kurum Bilgisi Değiştirme
    /// </summary>
    public  partial class ProtocolAdding : EpisodeAccountAction, IWorkListEpisodeAction
    {
        protected override void PostInsert()
        {
#region PostInsert
            base.PostInsert();

#endregion PostInsert
        }

        protected void PostTransition_New2Completed()
        {
            // From State : New   To State : Completed
#region PostTransition_New2Completed
            

        bool closeOldSEPs = false;
        if (SystemParameter.GetParameterValue("CLOSEOLDEPISODEPROTOCOLS", "TRUE") == "TRUE")
            closeOldSEPs = true;
        if (ProtocolAddingSubEpisodes.Where(x => x.Add == true).Count() == 0)
            throw new TTException(TTUtils.CultureService.GetText("M25145", "Alt vaka bilgisi boş geçilemez. Lütfen en az bir alt vaka seçiniz."));

        foreach (ProtocolAddingSubEpisode prtAddingSE in ProtocolAddingSubEpisodes)
        {
            //if (prtAddingSE.Add == true)
            //    SubEpisode.AddSubEpisodeProtocol((PayerDefinition)this.Payer, (ProtocolDefinition)this.Protocol, true, closeOldSEPs);
        }

        //            ProtocolDefinition bulletinProtocol = null;
        //            try
        //            {
        //                Guid bulletinProtocolGuid = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("DEFAULTBULLETINPROTOCOL", ""));
        //                bulletinProtocol = (ProtocolDefinition)this.ObjectContext.GetObject(bulletinProtocolGuid,"ProtocolDefinition");
        //            }
        //            catch
        //            {
        //                throw new TTException(SystemMessage.GetMessage(229));
        //            }

        //            // CLOSEOLDEPISODEPROTOCOLS sistem parametresine göre önceki anlaşmalar kapatılır
        //            if (SystemParameter.GetParameterValue("CLOSEOLDEPISODEPROTOCOLS","TRUE") != "FALSE")
        //            {
        //                //Tebliğ anlaşmasının içindeki tebliğ hizmeti iptal edilir
        //                foreach (EpisodeProtocol ep in this.Episode.EpisodeProtocols)
        //                {
        //                    if (ep.Protocol.ObjectID.ToString().ToUpper() == SystemParameter.GetParameterValue("DEFAULTBULLETINPROTOCOL","").ToString().ToUpper())
        //                    {
        //                        IList myPAccountTransactions = ep.GetSubActionProcedureTransactions();
        //                        foreach (AccountTransaction at in myPAccountTransactions)
        //                        {
        //                            if (at.SubActionProcedure.ProcedureObject is BulletinProcedureDefinition)
        //                            {
        //                                at.SubActionProcedure.CancelMyAccountTransactions();
        //                                break;
        //                            }
        //                        }
        //                    }
        //                }
        //
        //                // Muayene Katılım Payını iptal eden kısım
        //                //this.Episode.CancelPatientParticipationProcedure();
        //
        //                // Eklenen anlaşma tebliğ anlaşması ise
        //                if (this.Protocol.ObjectID.ToString().ToUpper() == SystemParameter.GetParameterValue("DEFAULTBULLETINPROTOCOL","").ToString().ToUpper())
        //                {
        //                    //if (this.Episode.PatientStatus != PatientStatusEnum.Outpatient)
        //                    //    throw new TTUtils.TTException(SystemMessage.GetMessage(231)); // Yatan hastaya eklenmesin kontrolü kaldırıldı
        //                    //else
        //                    //{
        //                    PatientExamination pEx = null;
        //
        //                    foreach (PatientExamination pe in this.Episode.PatientExaminations)
        //                    {
        //                        if (pe.CurrentStateDefID != PatientExamination.States.Cancelled)
        //                        {
        //                            pEx = pe;
        //                            break;
        //                        }
        //                    }
        //
        //                    if (pEx == null)
        //                        throw new TTUtils.TTException(SystemMessage.GetMessage(232));
        //                    else
        //                    {
        //                        EpisodeProtocol myEP;
        //                        myEP = this.Episode.AddEpisodeProtocol((PayerDefinition) this.Payer, (ProtocolDefinition)this.Protocol, true, true);
        //
        //                        if(!this.Episode.IsInvoicedBulletinProcedureExists())
        //                        {
        //                            BulletinProcedureDefinition proc = this.Episode.getBulletinProcedure();
        //                            if (proc != null)
        //                            {
        //                                PatientExaminationProcedure bulletinprocedure = new PatientExaminationProcedure(this.ObjectContext);
        //                                bulletinprocedure.ProcedureObject = (ProcedureDefinition)proc;
        //                                bulletinprocedure.CurrentStateDefID = PatientExaminationProcedure.States.Completed;
        //
        //                                if(this.Episode.OpeningDate != null)
        //                                    bulletinprocedure.PricingDate = this.Episode.OpeningDate;
        //
        //                                pEx.SubactionProcedures.Add(bulletinprocedure);
        //                                bulletinprocedure.AccountOperation(AccountOperationTimeEnum.PREPOST);
        //                            }
        //                            else
        //                                throw new TTUtils.TTException(SystemMessage.GetMessage(234));
        //                        }
        //                    }
        //                    //}
        //                }
        //                else
        //                {
        //                    EpisodeProtocol myEP;
        //                    myEP = this.Episode.AddEpisodeProtocol((PayerDefinition) this.Payer, (ProtocolDefinition)this.Protocol, true, true);
        //                }
        //            }
        //            else  // CLOSEOLDEPISODEPROTOCOLS sistem parametresine göre önceki anlaşmalar kapatılmaz
        //            {
        //                // Muayene Katılım Payını iptal eden kısım
        //                //this.Episode.CancelPatientParticipationProcedure();
        //
        //                // Eklenen anlaşma tebliğ anlaşması ise
        //                if (this.Protocol.ObjectID.ToString().ToUpper() == SystemParameter.GetParameterValue("DEFAULTBULLETINPROTOCOL","").ToString().ToUpper())
        //                {
        //                    //if (this.Episode.PatientStatus != PatientStatusEnum.Outpatient)
        //                    //    throw new TTUtils.TTException(SystemMessage.GetMessage(231)); // Yatan hastaya eklenmesin kontrolü kaldırıldı
        //                    //else
        //                    //{
        //                    PatientExamination pEx = null;
        //
        //                    foreach (PatientExamination pe in this.Episode.PatientExaminations)
        //                    {
        //                        if (pe.CurrentStateDefID != PatientExamination.States.Cancelled)
        //                        {
        //                            pEx = pe;
        //                            break;
        //                        }
        //                    }
        //
        //                    if (pEx == null)
        //                        throw new TTUtils.TTException(SystemMessage.GetMessage(232));
        //                    else
        //                    {
        //                        EpisodeProtocol myEP;
        //                        myEP = this.Episode.AddEpisodeProtocol((PayerDefinition) this.Payer, (ProtocolDefinition)this.Protocol, true, false);
        //
        //                        // Episode daki son açık anlaşma tebliğ anlaşması olmayabilir, tekrar kontrol ediliyor
        //                        if (Episode.MyEpisodeProtocol().Protocol.ObjectID.ToString().ToUpper() == SystemParameter.GetParameterValue("DEFAULTBULLETINPROTOCOL","").ToString().ToUpper())
        //                        {
        //                            //Episode.MyEpisodeProtocol() nin içinde iptalden farklı VAKABAŞI hizmeti yoksa, yeni Vakabaşı hizmetini oluşturmak lazım
        //                            bool bulletinProcedureFound = false;
        //                            IList myPAccountTransactions = Episode.MyEpisodeProtocol().GetSubActionProcedureTransactions();
        //                            foreach (AccountTransaction at in myPAccountTransactions)
        //                            {
        //                                if (at.SubActionProcedure.ProcedureObject is BulletinProcedureDefinition)
        //                                {
        //                                    if(at.CurrentStateDefID != AccountTransaction.States.Cancelled)
        //                                    {
        //                                        bulletinProcedureFound = true;
        //                                        break;
        //                                    }
        //                                }
        //                            }
        //
        //                            // ADDEPISODEPROTOCOL(FALSE) DEĞİŞİKLİĞİNDEN SONRA EKLENDİ bulletinProcedureFound KONTROLÜ VE ÜSTTEKİ
        //                            // AddEpisodeProtocol DEN BURAYA KADAR OLAN KISIM
        //                            if(!bulletinProcedureFound)
        //                            {
        //                                if(!this.Episode.IsInvoicedBulletinProcedureExists())
        //                                {
        //                                    BulletinProcedureDefinition proc = this.Episode.getBulletinProcedure();
        //                                    if (proc != null)
        //                                    {
        //                                        PatientExaminationProcedure bulletinprocedure = new PatientExaminationProcedure(this.ObjectContext);
        //                                        bulletinprocedure.ProcedureObject = (ProcedureDefinition)proc;
        //                                        bulletinprocedure.CurrentStateDefID = PatientExaminationProcedure.States.Completed;
        //
        //                                        if(this.Episode.OpeningDate != null)
        //                                            bulletinprocedure.PricingDate = this.Episode.OpeningDate;
        //
        //                                        pEx.SubactionProcedures.Add(bulletinprocedure);
        //                                        bulletinprocedure.AccountOperation(AccountOperationTimeEnum.PREPOST);
        //                                    }
        //                                    else
        //                                        throw new TTUtils.TTException(SystemMessage.GetMessage(234));
        //                                }
        //                            }
        //                        }
        //                    }
        //                    //}
        //                }
        //                else
        //                {
        //                    EpisodeProtocol myEP;
        //                    myEP = this.Episode.AddEpisodeProtocol((PayerDefinition) this.Payer, (ProtocolDefinition)this.Protocol, true, false);
        //                }
        //            }

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
        get
        {
            return ActionTypeEnum.EpisodeAccountAction;
        }
    }
        
#endregion Methods

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(ProtocolAdding).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == ProtocolAdding.States.New && toState == ProtocolAdding.States.Completed)
                PostTransition_New2Completed();
        }

        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(ProtocolAdding).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == ProtocolAdding.States.New && toState == ProtocolAdding.States.Completed)
                UndoTransition_New2Completed(transDef);
        }

    }
}
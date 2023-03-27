
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
    /// Anlaşmalar Arası Aktarma
    /// </summary>
    public  partial class ProtocolTransfer : EpisodeAccountAction, IWorkListEpisodeAction
    {
        protected void PostTransition_New2Completed()
        {
            // From State : New   To State : Completed
#region PostTransition_New2Completed
            
            IList spList;
            SubActionProcedure sp = null;
            SubActionMaterial sm = null;
            int counter = 0;
            
            foreach (ProtocolTransferProtocolSubActions tSubActions in ProtocolTransferProtocolSubActions)
            {
                if (tSubActions.TRANSFERTARGETPROTOCOL == true)
                {
                    spList = SubActionProcedure.GetByObjectID(ObjectContext, tSubActions.SUBACTIONID);
                    if (spList.Count > 0)
                    {
                        sp = (SubActionProcedure) spList[0];
                        
                        if (TargetSEP.Protocol.ObjectID.ToString().ToUpper() != SystemParameter.GetParameterValue("DEFAULTBULLETINPROTOCOL", "").ToString())
                        {
                            if (sp.ProcedureObject is BulletinProcedureDefinition)
                                sp.CancelMyAccountTransactions();
                            else
                                sp.ChangeMyProtocol(TargetSEP);
                        }
                        else
                            sp.ChangeMyProtocol(TargetSEP);
                        
                        /*
                        if(this.TargetSubEpisode != null)
                        {
                            foreach(AccountTransaction at in sp.AccountTransactions)
                            {
                                if (at.CurrentStateDefID == AccountTransaction.States.New)
                                    at.SubEpisode = this.TargetSubEpisode;
                            }
                        }
                        */
                    }
                    else
                    {
                        spList = SubActionMaterial.GetByObjectID(ObjectContext, tSubActions.SUBACTIONID);
                        if (spList.Count > 0)
                        {
                            sm = (SubActionMaterial) spList[0];
                            sm.ChangeMyProtocol (TargetSEP);
                            /*
                            if(this.TargetSubEpisode != null)
                            {
                                foreach(AccountTransaction at in sm.AccountTransactions)
                                {
                                    if (at.CurrentStateDefID == AccountTransaction.States.New)
                                        at.SubEpisode = this.TargetSubEpisode;
                                }
                            }
                            */
                        }
                        else
                            throw new TTException(SystemMessage.GetMessage(239));
                    }
                    counter ++;
                }
            }
            
            if (counter == 0)
                throw new TTUtils.TTException(SystemMessage.GetMessage(509));

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
            if (transDef.ObjectDef.CodeName != typeof(ProtocolTransfer).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == ProtocolTransfer.States.New && toState == ProtocolTransfer.States.Completed)
                PostTransition_New2Completed();
        }

        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(ProtocolTransfer).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == ProtocolTransfer.States.New && toState == ProtocolTransfer.States.Completed)
                UndoTransition_New2Completed(transDef);
        }

    }
}
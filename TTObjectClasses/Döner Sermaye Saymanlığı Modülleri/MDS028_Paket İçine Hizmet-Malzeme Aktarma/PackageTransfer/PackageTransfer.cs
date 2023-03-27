
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
    /// Paket İçine Hizmet/Malzeme Aktarma
    /// </summary>
    public  partial class PackageTransfer : EpisodeAccountAction, IWorkListEpisodeAction
    {
        protected void PostTransition_New2Completed()
        {
            // From State : New   To State : Completed
#region PostTransition_New2Completed
            
            PackageDefinition targetPack = null;
            EpisodeProtocol targetEP = null;
            SubActionPackageProcedure packSubActionProc = null;
            SubActionMaterial sm;
            SubActionProcedure sp;
            
            foreach (PackageTransferProtocolSubActionPackages packageSubAct in PackageTransferProtocolSubActionPackages)
            {
                if (packageSubAct.TARGETPACKAGE == true)
                {
                    targetPack = (PackageDefinition) packageSubAct.SubActionProcedure.PackageDefinition;
                    packSubActionProc = (SubActionPackageProcedure) packageSubAct.SubActionProcedure;
                    break;
                }
            }
            
            foreach (PackageTransferProtocolDetail prt in PackageTransferProtocolDetails)
            {
                if(prt.TargetEpisodeProtocol == true)
                {
                    targetEP = (EpisodeProtocol) prt.EpisodeProtocol;
                    break;
                }
            }
            
            foreach (PackageTransferProtocolSubActionProcedures tSubActions in PackageTransferProtocolSubActionProcedures)
            {
                if (tSubActions.TRANSFERTARGETPACKAGE == true)
                {
                    tSubActions.SubActionProcedure.AddIntoPackage(targetPack, packSubActionProc);
                    //sp = (SubActionProcedure) tSubActions.SubActionProcedure ;
                    //targetPack.AddSubActionIntoPackage(sp, targetEP, AccountOperationTimeEnum.PRE, (Int16)sp.PricingDate.Value.Subtract(packSubActionProc.PricingDate.Value).Days, packSubActionProc);
                }
            }

            foreach (PackageTransferProtocolSubActionMaterials tSubActions in PackageTransferProtocolSubActionMaterials)
            {
                if (tSubActions.TRANSFERTARGETPACKAGE == true)
                {
                    tSubActions.SubActionMaterial.AddIntoPackage(targetPack, packSubActionProc);
                    //sm = (SubActionMaterial) tSubActions.SubActionMaterial ;
                    //targetPack.AddSubActionIntoPackage(sm, targetEP, AccountOperationTimeEnum.PRE, (Int16)sm.PricingDate.Value.Subtract(packSubActionProc.PricingDate.Value).Days, packSubActionProc);
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
            if (transDef.ObjectDef.CodeName != typeof(PackageTransfer).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == PackageTransfer.States.New && toState == PackageTransfer.States.Completed)
                PostTransition_New2Completed();
        }

        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(PackageTransfer).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == PackageTransfer.States.New && toState == PackageTransfer.States.Completed)
                UndoTransition_New2Completed(transDef);
        }

    }
}
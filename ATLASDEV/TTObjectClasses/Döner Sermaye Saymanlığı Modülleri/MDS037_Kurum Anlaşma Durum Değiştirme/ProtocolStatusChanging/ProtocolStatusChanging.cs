
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
    /// Kurum Anlaşma Durum Değiştirme
    /// </summary>
    public partial class ProtocolStatusChanging : EpisodeAccountAction, IWorkListEpisodeAction
    {
        protected void PostTransition_New2Completed()
        {
            #region PostTransition_New2Completed
            foreach (ProtocolStatusChangingDetail protStaChDet in ProtocolStatusChangingDetails)
            {
                if (protStaChDet.Status == SEPStateEnum.Open)
                    protStaChDet.SEP.CurrentStateDefID = SubEpisodeProtocol.States.Open;
                else if (protStaChDet.Status == SEPStateEnum.Closed)
                    protStaChDet.SEP.CurrentStateDefID = SubEpisodeProtocol.States.Closed;
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
            get
            {
                return ActionTypeEnum.EpisodeAccountAction;
            }
        }

        #endregion Methods

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(ProtocolStatusChanging).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == ProtocolStatusChanging.States.New && toState == ProtocolStatusChanging.States.Completed)
                PostTransition_New2Completed();
        }

        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(ProtocolStatusChanging).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == ProtocolStatusChanging.States.New && toState == ProtocolStatusChanging.States.Completed)
                UndoTransition_New2Completed(transDef);
        }

    }
}
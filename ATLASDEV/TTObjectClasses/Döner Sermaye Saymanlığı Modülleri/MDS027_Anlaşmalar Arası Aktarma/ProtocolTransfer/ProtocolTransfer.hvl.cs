
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ProtocolTransfer")] 

    /// <summary>
    /// Anlaşmalar Arası Aktarma
    /// </summary>
    public  partial class ProtocolTransfer : EpisodeAccountAction
    {
        public class ProtocolTransferList : TTObjectCollection<ProtocolTransfer> { }
                    
        public class ChildProtocolTransferCollection : TTObject.TTChildObjectCollection<ProtocolTransfer>
        {
            public ChildProtocolTransferCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildProtocolTransferCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid Completed { get { return new Guid("4ad1a8bf-5791-4482-a6f5-877e053806a7"); } }
            public static Guid New { get { return new Guid("8ca5ed24-1ad2-42f3-a197-72e0dcac129c"); } }
        }

    /// <summary>
    /// SubEpisodeProtocol
    /// </summary>
        public SubEpisodeProtocol TargetSEP
        {
            get { return (SubEpisodeProtocol)((ITTObject)this).GetParent("TARGETSEP"); }
            set { this["TARGETSEP"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// EpisodeProtocol ile ilişki
    /// </summary>
        public EpisodeProtocol TargetEpisodeProtocol
        {
            get { return (EpisodeProtocol)((ITTObject)this).GetParent("TARGETEPISODEPROTOCOL"); }
            set { this["TARGETEPISODEPROTOCOL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Episode ile ilişki
    /// </summary>
        public Episode TargetEpisode
        {
            get { return (Episode)((ITTObject)this).GetParent("TARGETEPISODE"); }
            set { this["TARGETEPISODE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// SubEpisode ile ilişki
    /// </summary>
        public SubEpisode TargetSubEpisode
        {
            get { return (SubEpisode)((ITTObject)this).GetParent("TARGETSUBEPISODE"); }
            set { this["TARGETSUBEPISODE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateProtocolTransferProtocolSubActionsCollection()
        {
            _ProtocolTransferProtocolSubActions = new ProtocolTransferProtocolSubActions.ChildProtocolTransferProtocolSubActionsCollection(this, new Guid("3231e744-fb83-4e8d-9081-2ec3a6acc0db"));
            ((ITTChildObjectCollection)_ProtocolTransferProtocolSubActions).GetChildren();
        }

        protected ProtocolTransferProtocolSubActions.ChildProtocolTransferProtocolSubActionsCollection _ProtocolTransferProtocolSubActions = null;
    /// <summary>
    /// Child collection for Anlaşmalar Arası Aktarma ile ilişki
    /// </summary>
        public ProtocolTransferProtocolSubActions.ChildProtocolTransferProtocolSubActionsCollection ProtocolTransferProtocolSubActions
        {
            get
            {
                if (_ProtocolTransferProtocolSubActions == null)
                    CreateProtocolTransferProtocolSubActionsCollection();
                return _ProtocolTransferProtocolSubActions;
            }
        }

        virtual protected void CreateProtocolTransferProtocolDetailsCollection()
        {
            _ProtocolTransferProtocolDetails = new ProtocolTransferProtocolDetail.ChildProtocolTransferProtocolDetailCollection(this, new Guid("a955d7f6-07b6-4ee9-b0be-a1737cd257f7"));
            ((ITTChildObjectCollection)_ProtocolTransferProtocolDetails).GetChildren();
        }

        protected ProtocolTransferProtocolDetail.ChildProtocolTransferProtocolDetailCollection _ProtocolTransferProtocolDetails = null;
    /// <summary>
    /// Child collection for Anlaşmalar Arası Aktarmayla ilişki
    /// </summary>
        public ProtocolTransferProtocolDetail.ChildProtocolTransferProtocolDetailCollection ProtocolTransferProtocolDetails
        {
            get
            {
                if (_ProtocolTransferProtocolDetails == null)
                    CreateProtocolTransferProtocolDetailsCollection();
                return _ProtocolTransferProtocolDetails;
            }
        }

        protected ProtocolTransfer(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ProtocolTransfer(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ProtocolTransfer(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ProtocolTransfer(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ProtocolTransfer(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PROTOCOLTRANSFER", dataRow) { }
        protected ProtocolTransfer(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PROTOCOLTRANSFER", dataRow, isImported) { }
        public ProtocolTransfer(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ProtocolTransfer(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ProtocolTransfer() : base() { }

        override protected void RunPreTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePreScript(transDef))
                base.RunPreTransition(transDef.BaseTransDef);
            this.PreTransition(transDef);
        }
        override protected void RunPostTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePostScript(transDef))
                base.RunPostTransition(transDef.BaseTransDef);
            this.PostTransition(transDef);
        }
        override protected void RunUndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBaseUndoScript(transDef))
                base.RunUndoTransition(transDef.BaseTransDef);
            this.UndoTransition(transDef);
        }
    }
}
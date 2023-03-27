
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ProtocolAdding")] 

    /// <summary>
    /// Hasta Kurum Bilgisi Değiştirme
    /// </summary>
    public  partial class ProtocolAdding : EpisodeAccountAction
    {
        public class ProtocolAddingList : TTObjectCollection<ProtocolAdding> { }
                    
        public class ChildProtocolAddingCollection : TTObject.TTChildObjectCollection<ProtocolAdding>
        {
            public ChildProtocolAddingCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildProtocolAddingCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("1752538e-61ee-478c-a87c-b6e10f2623d8"); } }
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("3a3d9bb3-2cf0-4138-8db7-963504969b84"); } }
        }

    /// <summary>
    /// Kurum
    /// </summary>
        public PayerDefinition Payer
        {
            get { return (PayerDefinition)((ITTObject)this).GetParent("PAYER"); }
            set { this["PAYER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Anlaşma
    /// </summary>
        public ProtocolDefinition Protocol
        {
            get { return (ProtocolDefinition)((ITTObject)this).GetParent("PROTOCOL"); }
            set { this["PROTOCOL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateProtocolAddingSubEpisodesCollection()
        {
            _ProtocolAddingSubEpisodes = new ProtocolAddingSubEpisode.ChildProtocolAddingSubEpisodeCollection(this, new Guid("247f1010-bb11-47e3-bd26-e5d8ee3f2522"));
            ((ITTChildObjectCollection)_ProtocolAddingSubEpisodes).GetChildren();
        }

        protected ProtocolAddingSubEpisode.ChildProtocolAddingSubEpisodeCollection _ProtocolAddingSubEpisodes = null;
    /// <summary>
    /// Child collection for Protokol ekleme SubEpisode arasındaki ilişki
    /// </summary>
        public ProtocolAddingSubEpisode.ChildProtocolAddingSubEpisodeCollection ProtocolAddingSubEpisodes
        {
            get
            {
                if (_ProtocolAddingSubEpisodes == null)
                    CreateProtocolAddingSubEpisodesCollection();
                return _ProtocolAddingSubEpisodes;
            }
        }

        virtual protected void CreateProtocolAddingDetailsCollection()
        {
            _ProtocolAddingDetails = new ProtocolAddingDetail.ChildProtocolAddingDetailCollection(this, new Guid("f8c1f560-bf10-4287-ad8b-9fd55af91f75"));
            ((ITTChildObjectCollection)_ProtocolAddingDetails).GetChildren();
        }

        protected ProtocolAddingDetail.ChildProtocolAddingDetailCollection _ProtocolAddingDetails = null;
    /// <summary>
    /// Child collection for Hasta Kurum Bilgisi Değiştirme ile ilişki
    /// </summary>
        public ProtocolAddingDetail.ChildProtocolAddingDetailCollection ProtocolAddingDetails
        {
            get
            {
                if (_ProtocolAddingDetails == null)
                    CreateProtocolAddingDetailsCollection();
                return _ProtocolAddingDetails;
            }
        }

        protected ProtocolAdding(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ProtocolAdding(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ProtocolAdding(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ProtocolAdding(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ProtocolAdding(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PROTOCOLADDING", dataRow) { }
        protected ProtocolAdding(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PROTOCOLADDING", dataRow, isImported) { }
        public ProtocolAdding(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ProtocolAdding(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ProtocolAdding() : base() { }

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
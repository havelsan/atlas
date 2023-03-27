
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="EpisodeProtocolDayLimitChange")] 

    /// <summary>
    /// Sevk Süresi Uzatma
    /// </summary>
    public  partial class EpisodeProtocolDayLimitChange : EpisodeAccountAction, IWorkListEpisodeAction
    {
        public class EpisodeProtocolDayLimitChangeList : TTObjectCollection<EpisodeProtocolDayLimitChange> { }
                    
        public class ChildEpisodeProtocolDayLimitChangeCollection : TTObject.TTChildObjectCollection<EpisodeProtocolDayLimitChange>
        {
            public ChildEpisodeProtocolDayLimitChangeCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildEpisodeProtocolDayLimitChangeCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("90a5340c-d701-4b4f-8976-a853cf0f72bf"); } }
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("fe397bb1-f14c-4d39-ae2f-bd7278291fad"); } }
        }

        virtual protected void CreateEpisodeProtocolDayLimitChangeDetailsCollection()
        {
            _EpisodeProtocolDayLimitChangeDetails = new EpisodeProtocolDayLimitChangeDetail.ChildEpisodeProtocolDayLimitChangeDetailCollection(this, new Guid("c6c4f485-91b7-4039-8294-585b22601801"));
            ((ITTChildObjectCollection)_EpisodeProtocolDayLimitChangeDetails).GetChildren();
        }

        protected EpisodeProtocolDayLimitChangeDetail.ChildEpisodeProtocolDayLimitChangeDetailCollection _EpisodeProtocolDayLimitChangeDetails = null;
    /// <summary>
    /// Child collection for Sevk Süresi Uzatma ile ilişki
    /// </summary>
        public EpisodeProtocolDayLimitChangeDetail.ChildEpisodeProtocolDayLimitChangeDetailCollection EpisodeProtocolDayLimitChangeDetails
        {
            get
            {
                if (_EpisodeProtocolDayLimitChangeDetails == null)
                    CreateEpisodeProtocolDayLimitChangeDetailsCollection();
                return _EpisodeProtocolDayLimitChangeDetails;
            }
        }

        protected EpisodeProtocolDayLimitChange(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected EpisodeProtocolDayLimitChange(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected EpisodeProtocolDayLimitChange(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected EpisodeProtocolDayLimitChange(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected EpisodeProtocolDayLimitChange(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EPISODEPROTOCOLDAYLIMITCHANGE", dataRow) { }
        protected EpisodeProtocolDayLimitChange(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EPISODEPROTOCOLDAYLIMITCHANGE", dataRow, isImported) { }
        public EpisodeProtocolDayLimitChange(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public EpisodeProtocolDayLimitChange(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public EpisodeProtocolDayLimitChange() : base() { }

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
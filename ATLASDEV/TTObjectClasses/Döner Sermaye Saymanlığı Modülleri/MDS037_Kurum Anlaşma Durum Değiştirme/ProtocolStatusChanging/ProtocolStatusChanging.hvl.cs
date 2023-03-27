
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ProtocolStatusChanging")] 

    /// <summary>
    /// Kurum Anlaşma Durum Değiştirme
    /// </summary>
    public  partial class ProtocolStatusChanging : EpisodeAccountAction
    {
        public class ProtocolStatusChangingList : TTObjectCollection<ProtocolStatusChanging> { }
                    
        public class ChildProtocolStatusChangingCollection : TTObject.TTChildObjectCollection<ProtocolStatusChanging>
        {
            public ChildProtocolStatusChangingCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildProtocolStatusChangingCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("9e8d0dba-0064-454b-852c-857d79567887"); } }
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("2ba99486-de72-40e4-9551-e0fbaa48050b"); } }
        }

        virtual protected void CreateProtocolStatusChangingDetailsCollection()
        {
            _ProtocolStatusChangingDetails = new ProtocolStatusChangingDetail.ChildProtocolStatusChangingDetailCollection(this, new Guid("438fbfad-5d88-4d9c-99e2-470fcf14e786"));
            ((ITTChildObjectCollection)_ProtocolStatusChangingDetails).GetChildren();
        }

        protected ProtocolStatusChangingDetail.ChildProtocolStatusChangingDetailCollection _ProtocolStatusChangingDetails = null;
    /// <summary>
    /// Child collection for Kurum Anlaşma Durum Değiştirme ile ilişki
    /// </summary>
        public ProtocolStatusChangingDetail.ChildProtocolStatusChangingDetailCollection ProtocolStatusChangingDetails
        {
            get
            {
                if (_ProtocolStatusChangingDetails == null)
                    CreateProtocolStatusChangingDetailsCollection();
                return _ProtocolStatusChangingDetails;
            }
        }

        protected ProtocolStatusChanging(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ProtocolStatusChanging(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ProtocolStatusChanging(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ProtocolStatusChanging(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ProtocolStatusChanging(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PROTOCOLSTATUSCHANGING", dataRow) { }
        protected ProtocolStatusChanging(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PROTOCOLSTATUSCHANGING", dataRow, isImported) { }
        public ProtocolStatusChanging(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ProtocolStatusChanging(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ProtocolStatusChanging() : base() { }

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
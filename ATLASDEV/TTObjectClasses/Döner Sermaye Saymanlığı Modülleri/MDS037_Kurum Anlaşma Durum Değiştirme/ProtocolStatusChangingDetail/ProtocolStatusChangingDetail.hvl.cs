
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ProtocolStatusChangingDetail")] 

    /// <summary>
    /// Kurum Anlaşma Durum Değiştirme Detayı
    /// </summary>
    public  partial class ProtocolStatusChangingDetail : TTObject
    {
        public class ProtocolStatusChangingDetailList : TTObjectCollection<ProtocolStatusChangingDetail> { }
                    
        public class ChildProtocolStatusChangingDetailCollection : TTObject.TTChildObjectCollection<ProtocolStatusChangingDetail>
        {
            public ChildProtocolStatusChangingDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildProtocolStatusChangingDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Durum
    /// </summary>
        public SEPStateEnum? Status
        {
            get { return (SEPStateEnum?)(int?)this["STATUS"]; }
            set { this["STATUS"] = value; }
        }

    /// <summary>
    /// Kurum Anlaşma Durum Değiştirme ile ilişki
    /// </summary>
        public ProtocolStatusChanging ProtocolStatusChanging
        {
            get { return (ProtocolStatusChanging)((ITTObject)this).GetParent("PROTOCOLSTATUSCHANGING"); }
            set { this["PROTOCOLSTATUSCHANGING"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// SEP ilişkisi
    /// </summary>
        public SubEpisodeProtocol SEP
        {
            get { return (SubEpisodeProtocol)((ITTObject)this).GetParent("SEP"); }
            set { this["SEP"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ProtocolStatusChangingDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ProtocolStatusChangingDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ProtocolStatusChangingDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ProtocolStatusChangingDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ProtocolStatusChangingDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PROTOCOLSTATUSCHANGINGDETAIL", dataRow) { }
        protected ProtocolStatusChangingDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PROTOCOLSTATUSCHANGINGDETAIL", dataRow, isImported) { }
        public ProtocolStatusChangingDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ProtocolStatusChangingDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ProtocolStatusChangingDetail() : base() { }

    }
}
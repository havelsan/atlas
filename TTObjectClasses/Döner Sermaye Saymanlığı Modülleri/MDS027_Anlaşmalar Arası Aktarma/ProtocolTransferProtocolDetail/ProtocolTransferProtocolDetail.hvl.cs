
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ProtocolTransferProtocolDetail")] 

    /// <summary>
    /// Anlaşmalar Arası Aktarma Detayları
    /// </summary>
    public  partial class ProtocolTransferProtocolDetail : TTObject
    {
        public class ProtocolTransferProtocolDetailList : TTObjectCollection<ProtocolTransferProtocolDetail> { }
                    
        public class ChildProtocolTransferProtocolDetailCollection : TTObject.TTChildObjectCollection<ProtocolTransferProtocolDetail>
        {
            public ChildProtocolTransferProtocolDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildProtocolTransferProtocolDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Anlaşma Adı
    /// </summary>
        public string PROTOCOLNAME
        {
            get { return (string)this["PROTOCOLNAME"]; }
            set { this["PROTOCOLNAME"] = value; }
        }

    /// <summary>
    /// Anlaşma ID si
    /// </summary>
        public string EPOBJECTID
        {
            get { return (string)this["EPOBJECTID"]; }
            set { this["EPOBJECTID"] = value; }
        }

    /// <summary>
    /// Kurum Adı
    /// </summary>
        public string PAYERNAME
        {
            get { return (string)this["PAYERNAME"]; }
            set { this["PAYERNAME"] = value; }
        }

    /// <summary>
    /// Anlaşma Durumu
    /// </summary>
        public string PROTOCOLSTATUS
        {
            get { return (string)this["PROTOCOLSTATUS"]; }
            set { this["PROTOCOLSTATUS"] = value; }
        }

    /// <summary>
    /// Açılış Tarihi
    /// </summary>
        public DateTime? OPENINGDATE
        {
            get { return (DateTime?)this["OPENINGDATE"]; }
            set { this["OPENINGDATE"] = value; }
        }

    /// <summary>
    /// Anlaşmalar Arası Aktarmayla ilişki
    /// </summary>
        public ProtocolTransfer ProtocolTransfer
        {
            get { return (ProtocolTransfer)((ITTObject)this).GetParent("PROTOCOLTRANSFER"); }
            set { this["PROTOCOLTRANSFER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ProtocolTransferProtocolDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ProtocolTransferProtocolDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ProtocolTransferProtocolDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ProtocolTransferProtocolDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ProtocolTransferProtocolDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PROTOCOLTRANSFERPROTOCOLDETAIL", dataRow) { }
        protected ProtocolTransferProtocolDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PROTOCOLTRANSFERPROTOCOLDETAIL", dataRow, isImported) { }
        public ProtocolTransferProtocolDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ProtocolTransferProtocolDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ProtocolTransferProtocolDetail() : base() { }

    }
}
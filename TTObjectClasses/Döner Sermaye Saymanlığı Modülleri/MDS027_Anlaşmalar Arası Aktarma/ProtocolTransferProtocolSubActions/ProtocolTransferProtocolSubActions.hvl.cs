
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ProtocolTransferProtocolSubActions")] 

    /// <summary>
    /// Anlaşmalar Arası Aktarma Hareketleri
    /// </summary>
    public  partial class ProtocolTransferProtocolSubActions : TTObject
    {
        public class ProtocolTransferProtocolSubActionsList : TTObjectCollection<ProtocolTransferProtocolSubActions> { }
                    
        public class ChildProtocolTransferProtocolSubActionsCollection : TTObject.TTChildObjectCollection<ProtocolTransferProtocolSubActions>
        {
            public ChildProtocolTransferProtocolSubActionsCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildProtocolTransferProtocolSubActionsCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Kod
    /// </summary>
        public string EXTERNALCODE
        {
            get { return (string)this["EXTERNALCODE"]; }
            set { this["EXTERNALCODE"] = value; }
        }

    /// <summary>
    /// Paket Hizmet
    /// </summary>
        public bool? ISPACKAGEPROCEDURE
        {
            get { return (bool?)this["ISPACKAGEPROCEDURE"]; }
            set { this["ISPACKAGEPROCEDURE"] = value; }
        }

    /// <summary>
    /// İşlem Tarihi
    /// </summary>
        public DateTime? TRXDATE
        {
            get { return (DateTime?)this["TRXDATE"]; }
            set { this["TRXDATE"] = value; }
        }

    /// <summary>
    /// Hareketin ID si
    /// </summary>
        public string SUBACTIONID
        {
            get { return (string)this["SUBACTIONID"]; }
            set { this["SUBACTIONID"] = value; }
        }

    /// <summary>
    /// Durum
    /// </summary>
        public string STATUS
        {
            get { return (string)this["STATUS"]; }
            set { this["STATUS"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string DESCRIPTION
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

    /// <summary>
    /// Bağlı Olduğu Paket
    /// </summary>
        public string PACKAGEINFO
        {
            get { return (string)this["PACKAGEINFO"]; }
            set { this["PACKAGEINFO"] = value; }
        }

    /// <summary>
    /// Hedef Anlaşmaya Aktar
    /// </summary>
        public bool? TRANSFERTARGETPROTOCOL
        {
            get { return (bool?)this["TRANSFERTARGETPROTOCOL"]; }
            set { this["TRANSFERTARGETPROTOCOL"] = value; }
        }

    /// <summary>
    /// Anlaşmalar Arası Aktarma ile ilişki
    /// </summary>
        public ProtocolTransfer ProtocolTransfer
        {
            get { return (ProtocolTransfer)((ITTObject)this).GetParent("PROTOCOLTRANSFER"); }
            set { this["PROTOCOLTRANSFER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ProtocolTransferProtocolSubActions(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ProtocolTransferProtocolSubActions(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ProtocolTransferProtocolSubActions(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ProtocolTransferProtocolSubActions(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ProtocolTransferProtocolSubActions(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PROTOCOLTRANSFERPROTOCOLSUBACTIONS", dataRow) { }
        protected ProtocolTransferProtocolSubActions(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PROTOCOLTRANSFERPROTOCOLSUBACTIONS", dataRow, isImported) { }
        public ProtocolTransferProtocolSubActions(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ProtocolTransferProtocolSubActions(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ProtocolTransferProtocolSubActions() : base() { }

    }
}
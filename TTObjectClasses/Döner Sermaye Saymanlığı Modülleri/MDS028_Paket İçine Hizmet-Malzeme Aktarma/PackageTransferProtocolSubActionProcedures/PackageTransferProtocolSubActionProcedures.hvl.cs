
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PackageTransferProtocolSubActionProcedures")] 

    /// <summary>
    /// Paket İçine Hizmet/Malzeme Aktarma Hizmet Hareketleri
    /// </summary>
    public  partial class PackageTransferProtocolSubActionProcedures : TTObject
    {
        public class PackageTransferProtocolSubActionProceduresList : TTObjectCollection<PackageTransferProtocolSubActionProcedures> { }
                    
        public class ChildPackageTransferProtocolSubActionProceduresCollection : TTObject.TTChildObjectCollection<PackageTransferProtocolSubActionProcedures>
        {
            public ChildPackageTransferProtocolSubActionProceduresCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPackageTransferProtocolSubActionProceduresCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Hedef Anlaşmaya Aktar
    /// </summary>
        public bool? TRANSFERTARGETPACKAGE
        {
            get { return (bool?)this["TRANSFERTARGETPACKAGE"]; }
            set { this["TRANSFERTARGETPACKAGE"] = value; }
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
    /// Durum
    /// </summary>
        public string STATUS
        {
            get { return (string)this["STATUS"]; }
            set { this["STATUS"] = value; }
        }

    /// <summary>
    /// Hizmet hareketi ile ilişki
    /// </summary>
        public SubActionProcedure SubActionProcedure
        {
            get { return (SubActionProcedure)((ITTObject)this).GetParent("SUBACTIONPROCEDURE"); }
            set { this["SUBACTIONPROCEDURE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Paket İçine Hizmet/Malzeme Aktarma ile ilişki
    /// </summary>
        public PackageTransfer PackageTransfer
        {
            get { return (PackageTransfer)((ITTObject)this).GetParent("PACKAGETRANSFER"); }
            set { this["PACKAGETRANSFER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected PackageTransferProtocolSubActionProcedures(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PackageTransferProtocolSubActionProcedures(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PackageTransferProtocolSubActionProcedures(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PackageTransferProtocolSubActionProcedures(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PackageTransferProtocolSubActionProcedures(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PACKAGETRANSFERPROTOCOLSUBACTIONPROCEDURES", dataRow) { }
        protected PackageTransferProtocolSubActionProcedures(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PACKAGETRANSFERPROTOCOLSUBACTIONPROCEDURES", dataRow, isImported) { }
        public PackageTransferProtocolSubActionProcedures(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PackageTransferProtocolSubActionProcedures(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PackageTransferProtocolSubActionProcedures() : base() { }

    }
}
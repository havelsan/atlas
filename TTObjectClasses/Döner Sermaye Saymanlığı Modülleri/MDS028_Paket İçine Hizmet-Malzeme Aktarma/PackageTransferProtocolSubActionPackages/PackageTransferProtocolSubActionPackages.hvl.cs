
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PackageTransferProtocolSubActionPackages")] 

    /// <summary>
    /// Paket İçine Hizmet/Malzeme Aktarma Paket Hareketleri
    /// </summary>
    public  partial class PackageTransferProtocolSubActionPackages : TTObject
    {
        public class PackageTransferProtocolSubActionPackagesList : TTObjectCollection<PackageTransferProtocolSubActionPackages> { }
                    
        public class ChildPackageTransferProtocolSubActionPackagesCollection : TTObject.TTChildObjectCollection<PackageTransferProtocolSubActionPackages>
        {
            public ChildPackageTransferProtocolSubActionPackagesCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPackageTransferProtocolSubActionPackagesCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Hedef Anlaşmaya Aktar
    /// </summary>
        public bool? TARGETPACKAGE
        {
            get { return (bool?)this["TARGETPACKAGE"]; }
            set { this["TARGETPACKAGE"] = value; }
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
    /// Paket İçine Hizmet/Malzeme Aktarma ile ilişki
    /// </summary>
        public PackageTransfer PackageTransfer
        {
            get { return (PackageTransfer)((ITTObject)this).GetParent("PACKAGETRANSFER"); }
            set { this["PACKAGETRANSFER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Paket Hareketi ile ilişki
    /// </summary>
        public SubActionProcedure SubActionProcedure
        {
            get { return (SubActionProcedure)((ITTObject)this).GetParent("SUBACTIONPROCEDURE"); }
            set { this["SUBACTIONPROCEDURE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected PackageTransferProtocolSubActionPackages(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PackageTransferProtocolSubActionPackages(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PackageTransferProtocolSubActionPackages(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PackageTransferProtocolSubActionPackages(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PackageTransferProtocolSubActionPackages(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PACKAGETRANSFERPROTOCOLSUBACTIONPACKAGES", dataRow) { }
        protected PackageTransferProtocolSubActionPackages(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PACKAGETRANSFERPROTOCOLSUBACTIONPACKAGES", dataRow, isImported) { }
        public PackageTransferProtocolSubActionPackages(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PackageTransferProtocolSubActionPackages(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PackageTransferProtocolSubActionPackages() : base() { }

    }
}
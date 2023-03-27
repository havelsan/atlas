
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PackageTransferProtocolSubActionMaterials")] 

    /// <summary>
    /// Paket İçine Hizmet/Malzeme Aktarma Malzeme Hareketleri
    /// </summary>
    public  partial class PackageTransferProtocolSubActionMaterials : TTObject
    {
        public class PackageTransferProtocolSubActionMaterialsList : TTObjectCollection<PackageTransferProtocolSubActionMaterials> { }
                    
        public class ChildPackageTransferProtocolSubActionMaterialsCollection : TTObject.TTChildObjectCollection<PackageTransferProtocolSubActionMaterials>
        {
            public ChildPackageTransferProtocolSubActionMaterialsCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPackageTransferProtocolSubActionMaterialsCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
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
    /// Paket İçine Hizmet/Malzeme Aktarma ile ilişki
    /// </summary>
        public PackageTransfer PackageTransfer
        {
            get { return (PackageTransfer)((ITTObject)this).GetParent("PACKAGETRANSFER"); }
            set { this["PACKAGETRANSFER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Malzeme Hareketi ile ilişki
    /// </summary>
        public SubActionMaterial SubActionMaterial
        {
            get { return (SubActionMaterial)((ITTObject)this).GetParent("SUBACTIONMATERIAL"); }
            set { this["SUBACTIONMATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected PackageTransferProtocolSubActionMaterials(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PackageTransferProtocolSubActionMaterials(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PackageTransferProtocolSubActionMaterials(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PackageTransferProtocolSubActionMaterials(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PackageTransferProtocolSubActionMaterials(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PACKAGETRANSFERPROTOCOLSUBACTIONMATERIALS", dataRow) { }
        protected PackageTransferProtocolSubActionMaterials(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PACKAGETRANSFERPROTOCOLSUBACTIONMATERIALS", dataRow, isImported) { }
        public PackageTransferProtocolSubActionMaterials(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PackageTransferProtocolSubActionMaterials(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PackageTransferProtocolSubActionMaterials() : base() { }

    }
}
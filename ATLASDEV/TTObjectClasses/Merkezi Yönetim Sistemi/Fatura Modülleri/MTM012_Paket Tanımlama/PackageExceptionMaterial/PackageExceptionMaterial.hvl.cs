
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PackageExceptionMaterial")] 

    /// <summary>
    /// Paket Malzeme İstisna
    /// </summary>
    public  partial class PackageExceptionMaterial : TerminologyManagerDef
    {
        public class PackageExceptionMaterialList : TTObjectCollection<PackageExceptionMaterial> { }
                    
        public class ChildPackageExceptionMaterialCollection : TTObject.TTChildObjectCollection<PackageExceptionMaterial>
        {
            public ChildPackageExceptionMaterialCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPackageExceptionMaterialCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Miktar
    /// </summary>
        public int? Amount
        {
            get { return (int?)this["AMOUNT"]; }
            set { this["AMOUNT"] = value; }
        }

    /// <summary>
    /// Kapsam
    /// </summary>
        public PackageInclusiveEnum? Inclusive
        {
            get { return (PackageInclusiveEnum?)(int?)this["INCLUSIVE"]; }
            set { this["INCLUSIVE"] = value; }
        }

    /// <summary>
    /// Malzeme/İlaç
    /// </summary>
        public Material Material
        {
            get { return (Material)((ITTObject)this).GetParent("MATERIAL"); }
            set { this["MATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Paket Tanımlama ile ilişkisi
    /// </summary>
        public PackageDefinition PackageDefinition
        {
            get { return (PackageDefinition)((ITTObject)this).GetParent("PACKAGEDEFINITION"); }
            set { this["PACKAGEDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Fiyat Listesi
    /// </summary>
        public PricingListDefinition PricingListDefinition
        {
            get { return (PricingListDefinition)((ITTObject)this).GetParent("PRICINGLISTDEFINITION"); }
            set { this["PRICINGLISTDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected PackageExceptionMaterial(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PackageExceptionMaterial(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PackageExceptionMaterial(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PackageExceptionMaterial(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PackageExceptionMaterial(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PACKAGEEXCEPTIONMATERIAL", dataRow) { }
        protected PackageExceptionMaterial(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PACKAGEEXCEPTIONMATERIAL", dataRow, isImported) { }
        public PackageExceptionMaterial(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PackageExceptionMaterial(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PackageExceptionMaterial() : base() { }

    }
}
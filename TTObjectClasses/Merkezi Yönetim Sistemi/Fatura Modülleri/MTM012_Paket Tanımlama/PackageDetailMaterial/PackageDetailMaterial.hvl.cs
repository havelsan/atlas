
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PackageDetailMaterial")] 

    /// <summary>
    /// Paket Malzeme Detayı
    /// </summary>
    public  partial class PackageDetailMaterial : TerminologyManagerDef
    {
        public class PackageDetailMaterialList : TTObjectCollection<PackageDetailMaterial> { }
                    
        public class ChildPackageDetailMaterialCollection : TTObject.TTChildObjectCollection<PackageDetailMaterial>
        {
            public ChildPackageDetailMaterialCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPackageDetailMaterialCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static BindingList<PackageDetailMaterial> GetByPackageAndMaterialTree(TTObjectContext objectContext, string PARAMMATERIALTREE, string PARAMPACKAGE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PACKAGEDETAILMATERIAL"].QueryDefs["GetByPackageAndMaterialTree"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMMATERIALTREE", PARAMMATERIALTREE);
            paramList.Add("PARAMPACKAGE", PARAMPACKAGE);

            return ((ITTQuery)objectContext).QueryObjects<PackageDetailMaterial>(queryDef, paramList);
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
    /// Malzeme/İlaç Grubu
    /// </summary>
        public MaterialTreeDefinition MaterialTree
        {
            get { return (MaterialTreeDefinition)((ITTObject)this).GetParent("MATERIALTREE"); }
            set { this["MATERIALTREE"] = (value==null ? null : (Guid?)value.ObjectID); }
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

        protected PackageDetailMaterial(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PackageDetailMaterial(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PackageDetailMaterial(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PackageDetailMaterial(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PackageDetailMaterial(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PACKAGEDETAILMATERIAL", dataRow) { }
        protected PackageDetailMaterial(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PACKAGEDETAILMATERIAL", dataRow, isImported) { }
        public PackageDetailMaterial(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PackageDetailMaterial(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PackageDetailMaterial() : base() { }

    }
}
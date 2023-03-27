
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PackageDetailProcedure")] 

    /// <summary>
    /// Paket Hizmet Detayı
    /// </summary>
    public  partial class PackageDetailProcedure : TerminologyManagerDef
    {
        public class PackageDetailProcedureList : TTObjectCollection<PackageDetailProcedure> { }
                    
        public class ChildPackageDetailProcedureCollection : TTObject.TTChildObjectCollection<PackageDetailProcedure>
        {
            public ChildPackageDetailProcedureCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPackageDetailProcedureCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static BindingList<PackageDetailProcedure> GetByPackageAndProcedureTree(TTObjectContext objectContext, string PARAMPACKAGE, string PARAMPROCEDURETREE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PACKAGEDETAILPROCEDURE"].QueryDefs["GetByPackageAndProcedureTree"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMPACKAGE", PARAMPACKAGE);
            paramList.Add("PARAMPROCEDURETREE", PARAMPROCEDURETREE);

            return ((ITTQuery)objectContext).QueryObjects<PackageDetailProcedure>(queryDef, paramList);
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
    /// Fiyat Listesi
    /// </summary>
        public PricingListDefinition PricingListDefinition
        {
            get { return (PricingListDefinition)((ITTObject)this).GetParent("PRICINGLISTDEFINITION"); }
            set { this["PRICINGLISTDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
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
    /// Hizmet Grubu
    /// </summary>
        public ProcedureTreeDefinition ProcedureTree
        {
            get { return (ProcedureTreeDefinition)((ITTObject)this).GetParent("PROCEDURETREE"); }
            set { this["PROCEDURETREE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Fiyat Listesi Çarpanı
    /// </summary>
        public PriceMultiplierDefinition PricingListMultiplier
        {
            get { return (PriceMultiplierDefinition)((ITTObject)this).GetParent("PRICINGLISTMULTIPLIER"); }
            set { this["PRICINGLISTMULTIPLIER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Alternatif Fiyat Listesi
    /// </summary>
        public PricingListDefinition SecondPricingList
        {
            get { return (PricingListDefinition)((ITTObject)this).GetParent("SECONDPRICINGLIST"); }
            set { this["SECONDPRICINGLIST"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Alternatif Fiyat Listesi Çarpanı
    /// </summary>
        public PriceMultiplierDefinition SecondPricingListMultiplier
        {
            get { return (PriceMultiplierDefinition)((ITTObject)this).GetParent("SECONDPRICINGLISTMULTIPLIER"); }
            set { this["SECONDPRICINGLISTMULTIPLIER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected PackageDetailProcedure(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PackageDetailProcedure(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PackageDetailProcedure(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PackageDetailProcedure(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PackageDetailProcedure(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PACKAGEDETAILPROCEDURE", dataRow) { }
        protected PackageDetailProcedure(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PACKAGEDETAILPROCEDURE", dataRow, isImported) { }
        public PackageDetailProcedure(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PackageDetailProcedure(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PackageDetailProcedure() : base() { }

    }
}
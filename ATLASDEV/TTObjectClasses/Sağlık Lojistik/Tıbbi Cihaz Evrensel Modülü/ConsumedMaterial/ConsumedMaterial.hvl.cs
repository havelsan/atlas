
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ConsumedMaterial")] 

    /// <summary>
    /// Onarımda Kullanılan Malzemeler
    /// </summary>
    public  partial class ConsumedMaterial : TTObject
    {
        public class ConsumedMaterialList : TTObjectCollection<ConsumedMaterial> { }
                    
        public class ChildConsumedMaterialCollection : TTObject.TTChildObjectCollection<ConsumedMaterial>
        {
            public ChildConsumedMaterialCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildConsumedMaterialCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Açıklama
    /// </summary>
        public string SparePartMaterialDescription
        {
            get { return (string)this["SPAREPARTMATERIALDESCRIPTION"]; }
            set { this["SPAREPARTMATERIALDESCRIPTION"] = value; }
        }

    /// <summary>
    /// İptal
    /// </summary>
        public bool? Cancelled
        {
            get { return (bool?)this["CANCELLED"]; }
            set { this["CANCELLED"] = value; }
        }

    /// <summary>
    /// Karşılanan Miktar
    /// </summary>
        public Currency? SuppliedAmount
        {
            get { return (Currency?)this["SUPPLIEDAMOUNT"]; }
            set { this["SUPPLIEDAMOUNT"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

    /// <summary>
    /// Kullanılan Miktar
    /// </summary>
        public Currency? UsedAmount
        {
            get { return (Currency?)this["USEDAMOUNT"]; }
            set { this["USEDAMOUNT"] = value; }
        }

    /// <summary>
    /// Miktar
    /// </summary>
        public Currency? RequestAmount
        {
            get { return (Currency?)this["REQUESTAMOUNT"]; }
            set { this["REQUESTAMOUNT"] = value; }
        }

    /// <summary>
    /// Depo Mevcudu
    /// </summary>
        public Currency? StoreInheld
        {
            get { return (Currency?)this["STOREINHELD"]; }
            set { this["STOREINHELD"] = value; }
        }

        public Material Material
        {
            get { return (Material)((ITTObject)this).GetParent("MATERIAL"); }
            set { this["MATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ConsumedMaterial(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ConsumedMaterial(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ConsumedMaterial(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ConsumedMaterial(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ConsumedMaterial(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "CONSUMEDMATERIAL", dataRow) { }
        protected ConsumedMaterial(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "CONSUMEDMATERIAL", dataRow, isImported) { }
        public ConsumedMaterial(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ConsumedMaterial(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ConsumedMaterial() : base() { }

    }
}
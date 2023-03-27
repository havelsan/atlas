
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SubActionMatPricingDet")] 

    public  partial class SubActionMatPricingDet : TTObject
    {
        public class SubActionMatPricingDetList : TTObjectCollection<SubActionMatPricingDet> { }
                    
        public class ChildSubActionMatPricingDetCollection : TTObject.TTChildObjectCollection<SubActionMatPricingDet>
        {
            public ChildSubActionMatPricingDetCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSubActionMatPricingDetCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Kurum Fiyatı
    /// </summary>
        public Currency? PayerPrice
        {
            get { return (Currency?)this["PAYERPRICE"]; }
            set { this["PAYERPRICE"] = value; }
        }

    /// <summary>
    /// Hasta Fiyatı
    /// </summary>
        public Currency? PatientPrice
        {
            get { return (Currency?)this["PATIENTPRICE"]; }
            set { this["PATIENTPRICE"] = value; }
        }

    /// <summary>
    /// Miktar
    /// </summary>
        public double? Amount
        {
            get { return (double?)this["AMOUNT"]; }
            set { this["AMOUNT"] = value; }
        }

    /// <summary>
    /// Kod
    /// </summary>
        public string ExternalCode
        {
            get { return (string)this["EXTERNALCODE"]; }
            set { this["EXTERNALCODE"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

        public SubActionMaterial SubActionMaterial
        {
            get { return (SubActionMaterial)((ITTObject)this).GetParent("SUBACTIONMATERIAL"); }
            set { this["SUBACTIONMATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ProductDefinition ProductDefinition
        {
            get { return (ProductDefinition)((ITTObject)this).GetParent("PRODUCTDEFINITION"); }
            set { this["PRODUCTDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected SubActionMatPricingDet(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SubActionMatPricingDet(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SubActionMatPricingDet(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SubActionMatPricingDet(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SubActionMatPricingDet(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SUBACTIONMATPRICINGDET", dataRow) { }
        protected SubActionMatPricingDet(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SUBACTIONMATPRICINGDET", dataRow, isImported) { }
        public SubActionMatPricingDet(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SubActionMatPricingDet(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SubActionMatPricingDet() : base() { }

    }
}
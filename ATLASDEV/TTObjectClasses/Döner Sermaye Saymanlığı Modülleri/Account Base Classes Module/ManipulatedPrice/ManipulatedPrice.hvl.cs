
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ManipulatedPrice")] 

    /// <summary>
    /// Hasta ve Kurum Payına Paylaştırılmış Fiyat
    /// </summary>
    public  partial class ManipulatedPrice : TTObject
    {
        public class ManipulatedPriceList : TTObjectCollection<ManipulatedPrice> { }
                    
        public class ChildManipulatedPriceCollection : TTObject.TTChildObjectCollection<ManipulatedPrice>
        {
            public ChildManipulatedPriceCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildManipulatedPriceCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Hesaplanan Fiyatın Kodu
    /// </summary>
        public string ExternalCode
        {
            get { return (string)this["EXTERNALCODE"]; }
            set { this["EXTERNALCODE"] = value; }
        }

    /// <summary>
    /// Hesaplanan Fiyatın Açıklaması
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

    /// <summary>
    /// Hasta Payına Düşen Fiyat Mikatarı
    /// </summary>
        public Currency? PatientPrice
        {
            get { return (Currency?)this["PATIENTPRICE"]; }
            set { this["PATIENTPRICE"] = value; }
        }

    /// <summary>
    /// Hesaplanan Toplam Fiyat
    /// </summary>
        public Currency? Price
        {
            get { return (Currency?)this["PRICE"]; }
            set { this["PRICE"] = value; }
        }

    /// <summary>
    /// Kurum Payına Düşen Fiyat Mikatarı
    /// </summary>
        public Currency? PayerPrice
        {
            get { return (Currency?)this["PAYERPRICE"]; }
            set { this["PAYERPRICE"] = value; }
        }

    /// <summary>
    /// Fiyata ilişki
    /// </summary>
        public PricingDetailDefinition PricingDetailDefinition
        {
            get { return (PricingDetailDefinition)((ITTObject)this).GetParent("PRICINGDETAILDEFINITION"); }
            set { this["PRICINGDETAILDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ManipulatedPrice(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ManipulatedPrice(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ManipulatedPrice(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ManipulatedPrice(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ManipulatedPrice(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MANIPULATEDPRICE", dataRow) { }
        protected ManipulatedPrice(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MANIPULATEDPRICE", dataRow, isImported) { }
        public ManipulatedPrice(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ManipulatedPrice(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ManipulatedPrice() : base() { }

    }
}
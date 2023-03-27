
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DiscountTypeMaterialExceptionDefinition")] 

    /// <summary>
    /// İndirim Tipi Tanımlama Malzeme İstisnaları
    /// </summary>
    public  partial class DiscountTypeMaterialExceptionDefinition : TerminologyManagerDef
    {
        public class DiscountTypeMaterialExceptionDefinitionList : TTObjectCollection<DiscountTypeMaterialExceptionDefinition> { }
                    
        public class ChildDiscountTypeMaterialExceptionDefinitionCollection : TTObject.TTChildObjectCollection<DiscountTypeMaterialExceptionDefinition>
        {
            public ChildDiscountTypeMaterialExceptionDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDiscountTypeMaterialExceptionDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Tutar İndirimi
    /// </summary>
        public bool? IsAmountDiscount
        {
            get { return (bool?)this["ISAMOUNTDISCOUNT"]; }
            set { this["ISAMOUNTDISCOUNT"] = value; }
        }

    /// <summary>
    /// İndirim Oranı
    /// </summary>
        public int? DiscountPercentage
        {
            get { return (int?)this["DISCOUNTPERCENTAGE"]; }
            set { this["DISCOUNTPERCENTAGE"] = value; }
        }

    /// <summary>
    /// Yüzde İndirimi
    /// </summary>
        public bool? IsPercentageDiscount
        {
            get { return (bool?)this["ISPERCENTAGEDISCOUNT"]; }
            set { this["ISPERCENTAGEDISCOUNT"] = value; }
        }

    /// <summary>
    /// Malzeme ile ilişki
    /// </summary>
        public Material Material
        {
            get { return (Material)((ITTObject)this).GetParent("MATERIAL"); }
            set { this["MATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// İndirim Tipi Tanımı ile ilişki
    /// </summary>
        public DiscountTypeDefinition DiscountTypeDefinition
        {
            get { return (DiscountTypeDefinition)((ITTObject)this).GetParent("DISCOUNTTYPEDEFINITION"); }
            set { this["DISCOUNTTYPEDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected DiscountTypeMaterialExceptionDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DiscountTypeMaterialExceptionDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DiscountTypeMaterialExceptionDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DiscountTypeMaterialExceptionDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DiscountTypeMaterialExceptionDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DISCOUNTTYPEMATERIALEXCEPTIONDEFINITION", dataRow) { }
        protected DiscountTypeMaterialExceptionDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DISCOUNTTYPEMATERIALEXCEPTIONDEFINITION", dataRow, isImported) { }
        public DiscountTypeMaterialExceptionDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DiscountTypeMaterialExceptionDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DiscountTypeMaterialExceptionDefinition() : base() { }

    }
}
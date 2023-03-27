
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DiscountTypeMaterialGroupDefinition")] 

    /// <summary>
    /// İndirim Tipi Tanımlama Malzeme Grupları
    /// </summary>
    public  partial class DiscountTypeMaterialGroupDefinition : TerminologyManagerDef
    {
        public class DiscountTypeMaterialGroupDefinitionList : TTObjectCollection<DiscountTypeMaterialGroupDefinition> { }
                    
        public class ChildDiscountTypeMaterialGroupDefinitionCollection : TTObject.TTChildObjectCollection<DiscountTypeMaterialGroupDefinition>
        {
            public ChildDiscountTypeMaterialGroupDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDiscountTypeMaterialGroupDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
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
    /// Tutar İndirimi
    /// </summary>
        public bool? IsAmountDiscount
        {
            get { return (bool?)this["ISAMOUNTDISCOUNT"]; }
            set { this["ISAMOUNTDISCOUNT"] = value; }
        }

    /// <summary>
    /// İndirim Tipi Tanımı ile ilişki
    /// </summary>
        public DiscountTypeDefinition DiscountTypeDefinition
        {
            get { return (DiscountTypeDefinition)((ITTObject)this).GetParent("DISCOUNTTYPEDEFINITION"); }
            set { this["DISCOUNTTYPEDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// MaterialTree ile DiscountType ilişkisi
    /// </summary>
        public MaterialTreeDefinition MaterialTree
        {
            get { return (MaterialTreeDefinition)((ITTObject)this).GetParent("MATERIALTREE"); }
            set { this["MATERIALTREE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected DiscountTypeMaterialGroupDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DiscountTypeMaterialGroupDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DiscountTypeMaterialGroupDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DiscountTypeMaterialGroupDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DiscountTypeMaterialGroupDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DISCOUNTTYPEMATERIALGROUPDEFINITION", dataRow) { }
        protected DiscountTypeMaterialGroupDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DISCOUNTTYPEMATERIALGROUPDEFINITION", dataRow, isImported) { }
        public DiscountTypeMaterialGroupDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DiscountTypeMaterialGroupDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DiscountTypeMaterialGroupDefinition() : base() { }

    }
}
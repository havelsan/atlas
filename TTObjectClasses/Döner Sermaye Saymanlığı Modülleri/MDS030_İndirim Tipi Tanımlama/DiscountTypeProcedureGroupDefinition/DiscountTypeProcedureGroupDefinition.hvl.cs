
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DiscountTypeProcedureGroupDefinition")] 

    /// <summary>
    /// İndirim Tipi Tanımlama Hizmet Grupları
    /// </summary>
    public  partial class DiscountTypeProcedureGroupDefinition : TerminologyManagerDef
    {
        public class DiscountTypeProcedureGroupDefinitionList : TTObjectCollection<DiscountTypeProcedureGroupDefinition> { }
                    
        public class ChildDiscountTypeProcedureGroupDefinitionCollection : TTObject.TTChildObjectCollection<DiscountTypeProcedureGroupDefinition>
        {
            public ChildDiscountTypeProcedureGroupDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDiscountTypeProcedureGroupDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
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
    /// Tutar İndirimi
    /// </summary>
        public bool? IsAmountDiscount
        {
            get { return (bool?)this["ISAMOUNTDISCOUNT"]; }
            set { this["ISAMOUNTDISCOUNT"] = value; }
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
    /// ProcedureTree ile DiscountType ilişkisi
    /// </summary>
        public ProcedureTreeDefinition ProcedureTree
        {
            get { return (ProcedureTreeDefinition)((ITTObject)this).GetParent("PROCEDURETREE"); }
            set { this["PROCEDURETREE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// İndirim Tipi Tanımı ile ilişki
    /// </summary>
        public DiscountTypeDefinition DiscountTypeDefinition
        {
            get { return (DiscountTypeDefinition)((ITTObject)this).GetParent("DISCOUNTTYPEDEFINITION"); }
            set { this["DISCOUNTTYPEDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected DiscountTypeProcedureGroupDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DiscountTypeProcedureGroupDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DiscountTypeProcedureGroupDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DiscountTypeProcedureGroupDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DiscountTypeProcedureGroupDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DISCOUNTTYPEPROCEDUREGROUPDEFINITION", dataRow) { }
        protected DiscountTypeProcedureGroupDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DISCOUNTTYPEPROCEDUREGROUPDEFINITION", dataRow, isImported) { }
        public DiscountTypeProcedureGroupDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DiscountTypeProcedureGroupDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DiscountTypeProcedureGroupDefinition() : base() { }

    }
}
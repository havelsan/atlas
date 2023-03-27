
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DiscountTypeProcedureExceptionDefinition")] 

    /// <summary>
    /// İndirim Tipi Tanımlama Hizmet İstisnaları
    /// </summary>
    public  partial class DiscountTypeProcedureExceptionDefinition : TerminologyManagerDef
    {
        public class DiscountTypeProcedureExceptionDefinitionList : TTObjectCollection<DiscountTypeProcedureExceptionDefinition> { }
                    
        public class ChildDiscountTypeProcedureExceptionDefinitionCollection : TTObject.TTChildObjectCollection<DiscountTypeProcedureExceptionDefinition>
        {
            public ChildDiscountTypeProcedureExceptionDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDiscountTypeProcedureExceptionDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
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
    /// İndirim Oranı
    /// </summary>
        public int? DiscountPercentage
        {
            get { return (int?)this["DISCOUNTPERCENTAGE"]; }
            set { this["DISCOUNTPERCENTAGE"] = value; }
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
    /// Hizmet ile ilişki
    /// </summary>
        public ProcedureDefinition ProcedureDefinion
        {
            get { return (ProcedureDefinition)((ITTObject)this).GetParent("PROCEDUREDEFINION"); }
            set { this["PROCEDUREDEFINION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected DiscountTypeProcedureExceptionDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DiscountTypeProcedureExceptionDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DiscountTypeProcedureExceptionDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DiscountTypeProcedureExceptionDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DiscountTypeProcedureExceptionDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DISCOUNTTYPEPROCEDUREEXCEPTIONDEFINITION", dataRow) { }
        protected DiscountTypeProcedureExceptionDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DISCOUNTTYPEPROCEDUREEXCEPTIONDEFINITION", dataRow, isImported) { }
        public DiscountTypeProcedureExceptionDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DiscountTypeProcedureExceptionDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DiscountTypeProcedureExceptionDefinition() : base() { }

    }
}
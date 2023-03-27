
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PriceFormulationCommisionMember")] 

    /// <summary>
    /// Fiyat Tespit Komisyonu Üyeleri İçin Kullanılan Sınıftır. Her Üye İçin Yeni Instance Yaratılır
    /// </summary>
    public  partial class PriceFormulationCommisionMember : CommisionMember
    {
        public class PriceFormulationCommisionMemberList : TTObjectCollection<PriceFormulationCommisionMember> { }
                    
        public class ChildPriceFormulationCommisionMemberCollection : TTObject.TTChildObjectCollection<PriceFormulationCommisionMember>
        {
            public ChildPriceFormulationCommisionMemberCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPriceFormulationCommisionMemberCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public PurchaseProject PurchaseProject
        {
            get { return (PurchaseProject)((ITTObject)this).GetParent("PURCHASEPROJECT"); }
            set { this["PURCHASEPROJECT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected PriceFormulationCommisionMember(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PriceFormulationCommisionMember(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PriceFormulationCommisionMember(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PriceFormulationCommisionMember(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PriceFormulationCommisionMember(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PRICEFORMULATIONCOMMISIONMEMBER", dataRow) { }
        protected PriceFormulationCommisionMember(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PRICEFORMULATIONCOMMISIONMEMBER", dataRow, isImported) { }
        public PriceFormulationCommisionMember(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PriceFormulationCommisionMember(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PriceFormulationCommisionMember() : base() { }

    }
}
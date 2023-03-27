
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ItemEquipment")] 

    /// <summary>
    /// Cihazla Beraber Gidecek Malzemeler
    /// </summary>
    public  partial class ItemEquipment : TTObject
    {
        public class ItemEquipmentList : TTObjectCollection<ItemEquipment> { }
                    
        public class ChildItemEquipmentCollection : TTObject.TTChildObjectCollection<ItemEquipment>
        {
            public ChildItemEquipmentCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildItemEquipmentCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Miktar
    /// </summary>
        public long? Amount
        {
            get { return (long?)this["AMOUNT"]; }
            set { this["AMOUNT"] = value; }
        }

    /// <summary>
    /// Malzeme Adı
    /// </summary>
        public string ItemName
        {
            get { return (string)this["ITEMNAME"]; }
            set { this["ITEMNAME"] = value; }
        }

        public DistributionTypeDefinition DistributionType
        {
            get { return (DistributionTypeDefinition)((ITTObject)this).GetParent("DISTRIBUTIONTYPE"); }
            set { this["DISTRIBUTIONTYPE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ItemEquipment(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ItemEquipment(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ItemEquipment(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ItemEquipment(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ItemEquipment(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ITEMEQUIPMENT", dataRow) { }
        protected ItemEquipment(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ITEMEQUIPMENT", dataRow, isImported) { }
        public ItemEquipment(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ItemEquipment(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ItemEquipment() : base() { }

    }
}
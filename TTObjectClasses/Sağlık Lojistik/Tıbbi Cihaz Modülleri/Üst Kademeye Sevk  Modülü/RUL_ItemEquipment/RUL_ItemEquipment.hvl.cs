
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="RUL_ItemEquipment")] 

    /// <summary>
    /// Üst Kademeye Sevk İşlemi Cihazla Gelen Malzeme Sekmesi
    /// </summary>
    public  partial class RUL_ItemEquipment : ItemEquipment
    {
        public class RUL_ItemEquipmentList : TTObjectCollection<RUL_ItemEquipment> { }
                    
        public class ChildRUL_ItemEquipmentCollection : TTObject.TTChildObjectCollection<RUL_ItemEquipment>
        {
            public ChildRUL_ItemEquipmentCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildRUL_ItemEquipmentCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Düşünceler
    /// </summary>
        public string Comments
        {
            get { return (string)this["COMMENTS"]; }
            set { this["COMMENTS"] = value; }
        }

    /// <summary>
    /// Değişik
    /// </summary>
        public bool? IsChanged
        {
            get { return (bool?)this["ISCHANGED"]; }
            set { this["ISCHANGED"] = value; }
        }

    /// <summary>
    /// Hasarlı
    /// </summary>
        public bool? IsDamaged
        {
            get { return (bool?)this["ISDAMAGED"]; }
            set { this["ISDAMAGED"] = value; }
        }

    /// <summary>
    /// Eksik
    /// </summary>
        public bool? IsMissing
        {
            get { return (bool?)this["ISMISSING"]; }
            set { this["ISMISSING"] = value; }
        }

    /// <summary>
    /// Tamam
    /// </summary>
        public bool? IsNormal
        {
            get { return (bool?)this["ISNORMAL"]; }
            set { this["ISNORMAL"] = value; }
        }

        public ReferToUpperLevel ReferToUpperLevel
        {
            get { return (ReferToUpperLevel)((ITTObject)this).GetParent("REFERTOUPPERLEVEL"); }
            set { this["REFERTOUPPERLEVEL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected RUL_ItemEquipment(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected RUL_ItemEquipment(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected RUL_ItemEquipment(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected RUL_ItemEquipment(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected RUL_ItemEquipment(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RUL_ITEMEQUIPMENT", dataRow) { }
        protected RUL_ItemEquipment(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RUL_ITEMEQUIPMENT", dataRow, isImported) { }
        public RUL_ItemEquipment(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public RUL_ItemEquipment(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public RUL_ItemEquipment() : base() { }

    }
}
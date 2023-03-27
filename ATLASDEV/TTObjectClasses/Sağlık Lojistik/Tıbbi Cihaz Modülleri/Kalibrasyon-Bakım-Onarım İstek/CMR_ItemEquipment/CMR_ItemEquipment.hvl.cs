
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="CMR_ItemEquipment")] 

    public  partial class CMR_ItemEquipment : ItemEquipment
    {
        public class CMR_ItemEquipmentList : TTObjectCollection<CMR_ItemEquipment> { }
                    
        public class ChildCMR_ItemEquipmentCollection : TTObject.TTChildObjectCollection<CMR_ItemEquipment>
        {
            public ChildCMR_ItemEquipmentCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildCMR_ItemEquipmentCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
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
    /// Tamam
    /// </summary>
        public bool? IsNormal
        {
            get { return (bool?)this["ISNORMAL"]; }
            set { this["ISNORMAL"] = value; }
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
    /// Hasarlı
    /// </summary>
        public bool? IsDamaged
        {
            get { return (bool?)this["ISDAMAGED"]; }
            set { this["ISDAMAGED"] = value; }
        }

        public CMRActionRequest CMRActionRequest
        {
            get { return (CMRActionRequest)((ITTObject)this).GetParent("CMRACTIONREQUEST"); }
            set { this["CMRACTIONREQUEST"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected CMR_ItemEquipment(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected CMR_ItemEquipment(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected CMR_ItemEquipment(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected CMR_ItemEquipment(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected CMR_ItemEquipment(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "CMR_ITEMEQUIPMENT", dataRow) { }
        protected CMR_ItemEquipment(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "CMR_ITEMEQUIPMENT", dataRow, isImported) { }
        public CMR_ItemEquipment(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public CMR_ItemEquipment(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public CMR_ItemEquipment() : base() { }

    }
}
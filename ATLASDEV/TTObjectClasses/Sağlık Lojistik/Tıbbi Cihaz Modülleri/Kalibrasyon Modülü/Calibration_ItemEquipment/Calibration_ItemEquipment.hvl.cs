
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="Calibration_ItemEquipment")] 

    /// <summary>
    /// Kalibrasyon İşleminde Cihazla Beraber Gelen Malzeme Sekmesi
    /// </summary>
    public  partial class Calibration_ItemEquipment : ItemEquipment
    {
        public class Calibration_ItemEquipmentList : TTObjectCollection<Calibration_ItemEquipment> { }
                    
        public class ChildCalibration_ItemEquipmentCollection : TTObject.TTChildObjectCollection<Calibration_ItemEquipment>
        {
            public ChildCalibration_ItemEquipmentCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildCalibration_ItemEquipmentCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public Calibration Calibration
        {
            get { return (Calibration)((ITTObject)this).GetParent("CALIBRATION"); }
            set { this["CALIBRATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected Calibration_ItemEquipment(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected Calibration_ItemEquipment(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected Calibration_ItemEquipment(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected Calibration_ItemEquipment(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected Calibration_ItemEquipment(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "CALIBRATION_ITEMEQUIPMENT", dataRow) { }
        protected Calibration_ItemEquipment(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "CALIBRATION_ITEMEQUIPMENT", dataRow, isImported) { }
        public Calibration_ItemEquipment(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public Calibration_ItemEquipment(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public Calibration_ItemEquipment() : base() { }

    }
}
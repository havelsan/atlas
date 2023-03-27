
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="CalibrationConsumedMat")] 

    public  partial class CalibrationConsumedMat : ConsumedMaterial
    {
        public class CalibrationConsumedMatList : TTObjectCollection<CalibrationConsumedMat> { }
                    
        public class ChildCalibrationConsumedMatCollection : TTObject.TTChildObjectCollection<CalibrationConsumedMat>
        {
            public ChildCalibrationConsumedMatCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildCalibrationConsumedMatCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public Calibration Calibration
        {
            get { return (Calibration)((ITTObject)this).GetParent("CALIBRATION"); }
            set { this["CALIBRATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected CalibrationConsumedMat(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected CalibrationConsumedMat(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected CalibrationConsumedMat(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected CalibrationConsumedMat(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected CalibrationConsumedMat(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "CALIBRATIONCONSUMEDMAT", dataRow) { }
        protected CalibrationConsumedMat(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "CALIBRATIONCONSUMEDMAT", dataRow, isImported) { }
        public CalibrationConsumedMat(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public CalibrationConsumedMat(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public CalibrationConsumedMat() : base() { }

    }
}
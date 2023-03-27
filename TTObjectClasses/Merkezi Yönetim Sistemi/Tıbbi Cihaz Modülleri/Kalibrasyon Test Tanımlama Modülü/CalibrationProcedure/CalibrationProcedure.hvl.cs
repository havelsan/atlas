
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="CalibrationProcedure")] 

    public  partial class CalibrationProcedure : TerminologyManagerDef
    {
        public class CalibrationProcedureList : TTObjectCollection<CalibrationProcedure> { }
                    
        public class ChildCalibrationProcedureCollection : TTObject.TTChildObjectCollection<CalibrationProcedure>
        {
            public ChildCalibrationProcedureCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildCalibrationProcedureCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public CalibrationTestDefinition CalibrationTestDefinition
        {
            get { return (CalibrationTestDefinition)((ITTObject)this).GetParent("CALIBRATIONTESTDEFINITION"); }
            set { this["CALIBRATIONTESTDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public FixedAssetDefinition FixedAssetDefinition
        {
            get { return (FixedAssetDefinition)((ITTObject)this).GetParent("FIXEDASSETDEFINITION"); }
            set { this["FIXEDASSETDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected CalibrationProcedure(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected CalibrationProcedure(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected CalibrationProcedure(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected CalibrationProcedure(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected CalibrationProcedure(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "CALIBRATIONPROCEDURE", dataRow) { }
        protected CalibrationProcedure(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "CALIBRATIONPROCEDURE", dataRow, isImported) { }
        public CalibrationProcedure(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public CalibrationProcedure(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public CalibrationProcedure() : base() { }

    }
}
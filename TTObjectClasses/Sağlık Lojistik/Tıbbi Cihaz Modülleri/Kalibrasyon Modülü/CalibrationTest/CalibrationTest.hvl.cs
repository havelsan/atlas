
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="CalibrationTest")] 

    /// <summary>
    /// Kalibrasyon Test Sekmesi
    /// </summary>
    public  partial class CalibrationTest : TTObject
    {
        public class CalibrationTestList : TTObjectCollection<CalibrationTest> { }
                    
        public class ChildCalibrationTestCollection : TTObject.TTChildObjectCollection<CalibrationTest>
        {
            public ChildCalibrationTestCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildCalibrationTestCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Uygulanan Test Sayısı
    /// </summary>
        public long? ExistingTestCount
        {
            get { return (long?)this["EXISTINGTESTCOUNT"]; }
            set { this["EXISTINGTESTCOUNT"] = value; }
        }

    /// <summary>
    /// Ölçüm Raporu
    /// </summary>
        public object MeasurementReport
        {
            get { return (object)this["MEASUREMENTREPORT"]; }
            set { this["MEASUREMENTREPORT"] = value; }
        }

        public Calibration Calibration
        {
            get { return (Calibration)((ITTObject)this).GetParent("CALIBRATION"); }
            set { this["CALIBRATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public CalibrationTestDefinition CalibrationTestDefinition
        {
            get { return (CalibrationTestDefinition)((ITTObject)this).GetParent("CALIBRATIONTESTDEFINITION"); }
            set { this["CALIBRATIONTESTDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected CalibrationTest(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected CalibrationTest(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected CalibrationTest(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected CalibrationTest(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected CalibrationTest(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "CALIBRATIONTEST", dataRow) { }
        protected CalibrationTest(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "CALIBRATIONTEST", dataRow, isImported) { }
        public CalibrationTest(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public CalibrationTest(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public CalibrationTest() : base() { }

    }
}
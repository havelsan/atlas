
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BloodPressureMeasurements")] 

    public  partial class BloodPressureMeasurements : BaseMultipleDataEntry
    {
        public class BloodPressureMeasurementsList : TTObjectCollection<BloodPressureMeasurements> { }
                    
        public class ChildBloodPressureMeasurementsCollection : TTObject.TTChildObjectCollection<BloodPressureMeasurements>
        {
            public ChildBloodPressureMeasurementsCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBloodPressureMeasurementsCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Sistolik Kan Basıncı
    /// </summary>
        public int? SBP
        {
            get { return (int?)this["SBP"]; }
            set { this["SBP"] = value; }
        }

    /// <summary>
    /// Diastolik Kan Basıncı
    /// </summary>
        public int? DBP
        {
            get { return (int?)this["DBP"]; }
            set { this["DBP"] = value; }
        }

    /// <summary>
    /// Tarih
    /// </summary>
        public DateTime? ProcessDate
        {
            get { return (DateTime?)this["PROCESSDATE"]; }
            set { this["PROCESSDATE"] = value; }
        }

    /// <summary>
    /// Ortalama Kan Basıncı
    /// </summary>
        public double? MAP
        {
            get { return (double?)this["MAP"]; }
            set { this["MAP"] = value; }
        }

    /// <summary>
    /// Ölçümü Yapan
    /// </summary>
        public string MeasuringPerson
        {
            get { return (string)this["MEASURINGPERSON"]; }
            set { this["MEASURINGPERSON"] = value; }
        }

        protected BloodPressureMeasurements(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BloodPressureMeasurements(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BloodPressureMeasurements(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BloodPressureMeasurements(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BloodPressureMeasurements(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BLOODPRESSUREMEASUREMENTS", dataRow) { }
        protected BloodPressureMeasurements(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BLOODPRESSUREMEASUREMENTS", dataRow, isImported) { }
        public BloodPressureMeasurements(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BloodPressureMeasurements(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BloodPressureMeasurements() : base() { }

    }
}
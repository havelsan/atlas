
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="RadiologyAdditionalReport")] 

    /// <summary>
    /// Radyoloji Test Ek Rapor
    /// </summary>
    public  partial class RadiologyAdditionalReport : TTObject
    {
        public class RadiologyAdditionalReportList : TTObjectCollection<RadiologyAdditionalReport> { }
                    
        public class ChildRadiologyAdditionalReportCollection : TTObject.TTChildObjectCollection<RadiologyAdditionalReport>
        {
            public ChildRadiologyAdditionalReportCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildRadiologyAdditionalReportCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Ek Rapor
    /// </summary>
        public object AdditionalReport
        {
            get { return (object)this["ADDITIONALREPORT"]; }
            set { this["ADDITIONALREPORT"] = value; }
        }

    /// <summary>
    /// Ek Rapor Tarihi
    /// </summary>
        public DateTime? ReportDate
        {
            get { return (DateTime?)this["REPORTDATE"]; }
            set { this["REPORTDATE"] = value; }
        }

    /// <summary>
    /// Bulgular
    /// </summary>
        public object AdditionalResults
        {
            get { return (object)this["ADDITIONALRESULTS"]; }
            set { this["ADDITIONALRESULTS"] = value; }
        }

        protected RadiologyAdditionalReport(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected RadiologyAdditionalReport(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected RadiologyAdditionalReport(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected RadiologyAdditionalReport(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected RadiologyAdditionalReport(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RADIOLOGYADDITIONALREPORT", dataRow) { }
        protected RadiologyAdditionalReport(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RADIOLOGYADDITIONALREPORT", dataRow, isImported) { }
        public RadiologyAdditionalReport(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public RadiologyAdditionalReport(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public RadiologyAdditionalReport() : base() { }

    }
}
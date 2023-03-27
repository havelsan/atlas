
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HBTReport")] 

    /// <summary>
    /// Hiperbarik Oksijen Tedavisi Raporu
    /// </summary>
    public  partial class HBTReport : TTObject
    {
        public class HBTReportList : TTObjectCollection<HBTReport> { }
                    
        public class ChildHBTReportCollection : TTObject.TTChildObjectCollection<HBTReport>
        {
            public ChildHBTReportCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHBTReportCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Seans Sayısı
    /// </summary>
        public int? NumberOfSessions
        {
            get { return (int?)this["NUMBEROFSESSIONS"]; }
            set { this["NUMBEROFSESSIONS"] = value; }
        }

    /// <summary>
    /// Tedavi Süresi
    /// </summary>
        public int? TreatmenDuration
        {
            get { return (int?)this["TREATMENDURATION"]; }
            set { this["TREATMENDURATION"] = value; }
        }

        protected HBTReport(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HBTReport(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HBTReport(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HBTReport(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HBTReport(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HBTREPORT", dataRow) { }
        protected HBTReport(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HBTREPORT", dataRow, isImported) { }
        public HBTReport(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HBTReport(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HBTReport() : base() { }

    }
}
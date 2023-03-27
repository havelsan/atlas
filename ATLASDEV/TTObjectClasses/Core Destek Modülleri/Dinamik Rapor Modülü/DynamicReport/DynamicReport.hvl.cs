
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DynamicReport")] 

    public  partial class DynamicReport : TTObject
    {
        public class DynamicReportList : TTObjectCollection<DynamicReport> { }
                    
        public class ChildDynamicReportCollection : TTObject.TTChildObjectCollection<DynamicReport>
        {
            public ChildDynamicReportCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDynamicReportCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public string Code
        {
            get { return (string)this["CODE"]; }
            set { this["CODE"] = value; }
        }

    /// <summary>
    /// Raporun Adi
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

    /// <summary>
    /// Raporun Cekilecegi Class in Adi
    /// </summary>
        public string ReportClassName
        {
            get { return (string)this["REPORTCLASSNAME"]; }
            set { this["REPORTCLASSNAME"] = value; }
        }

    /// <summary>
    /// Raporun Olusturulma Tarihi
    /// </summary>
        public DateTime? CreatedDate
        {
            get { return (DateTime?)this["CREATEDDATE"]; }
            set { this["CREATEDDATE"] = value; }
        }

    /// <summary>
    /// Raporun Kullanima Acik Olmasi
    /// </summary>
        public bool? Enabled
        {
            get { return (bool?)this["ENABLED"]; }
            set { this["ENABLED"] = value; }
        }

        protected DynamicReport(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DynamicReport(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DynamicReport(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DynamicReport(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DynamicReport(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DYNAMICREPORT", dataRow) { }
        protected DynamicReport(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DYNAMICREPORT", dataRow, isImported) { }
        public DynamicReport(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DynamicReport(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DynamicReport() : base() { }

    }
}
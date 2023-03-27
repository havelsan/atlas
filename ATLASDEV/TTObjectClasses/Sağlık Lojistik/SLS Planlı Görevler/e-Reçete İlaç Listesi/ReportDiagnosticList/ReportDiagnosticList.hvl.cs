
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ReportDiagnosticList")] 

    /// <summary>
    /// Rapor Teşhis Listesi
    /// </summary>
    public  partial class ReportDiagnosticList : BaseScheduledTask
    {
        public class ReportDiagnosticListList : TTObjectCollection<ReportDiagnosticList> { }
                    
        public class ChildReportDiagnosticListCollection : TTObject.TTChildObjectCollection<ReportDiagnosticList>
        {
            public ChildReportDiagnosticListCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildReportDiagnosticListCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Dosya Yolu
    /// </summary>
        public string FilePath
        {
            get { return (string)this["FILEPATH"]; }
            set { this["FILEPATH"] = value; }
        }

        protected ReportDiagnosticList(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ReportDiagnosticList(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ReportDiagnosticList(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ReportDiagnosticList(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ReportDiagnosticList(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "REPORTDIAGNOSTICLIST", dataRow) { }
        protected ReportDiagnosticList(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "REPORTDIAGNOSTICLIST", dataRow, isImported) { }
        public ReportDiagnosticList(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ReportDiagnosticList(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ReportDiagnosticList() : base() { }

    }
}
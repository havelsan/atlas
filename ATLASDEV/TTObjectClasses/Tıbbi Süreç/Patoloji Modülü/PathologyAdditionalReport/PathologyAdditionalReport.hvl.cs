
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PathologyAdditionalReport")] 

    /// <summary>
    /// Patoloji Ek Rapor
    /// </summary>
    public  partial class PathologyAdditionalReport : TTObject
    {
        public class PathologyAdditionalReportList : TTObjectCollection<PathologyAdditionalReport> { }
                    
        public class ChildPathologyAdditionalReportCollection : TTObject.TTChildObjectCollection<PathologyAdditionalReport>
        {
            public ChildPathologyAdditionalReportCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPathologyAdditionalReportCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("56caa1f9-3539-4bc1-a8f1-7f82c261868c"); } }
    /// <summary>
    /// Onaylı
    /// </summary>
            public static Guid Approved { get { return new Guid("ab4ad6d6-a5a8-4f66-9ef9-9a55c4ced6ab"); } }
        }

    /// <summary>
    /// Ek Rapor Onay Tarihi
    /// </summary>
        public DateTime? ApproveDate
        {
            get { return (DateTime?)this["APPROVEDATE"]; }
            set { this["APPROVEDATE"] = value; }
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
    /// Ek Rapor
    /// </summary>
        public object AdditionalReport
        {
            get { return (object)this["ADDITIONALREPORT"]; }
            set { this["ADDITIONALREPORT"] = value; }
        }

        protected PathologyAdditionalReport(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PathologyAdditionalReport(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PathologyAdditionalReport(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PathologyAdditionalReport(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PathologyAdditionalReport(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PATHOLOGYADDITIONALREPORT", dataRow) { }
        protected PathologyAdditionalReport(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PATHOLOGYADDITIONALREPORT", dataRow, isImported) { }
        public PathologyAdditionalReport(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PathologyAdditionalReport(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PathologyAdditionalReport() : base() { }

        override protected void RunPreTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePreScript(transDef))
                base.RunPreTransition(transDef.BaseTransDef);
            this.PreTransition(transDef);
        }
        override protected void RunPostTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePostScript(transDef))
                base.RunPostTransition(transDef.BaseTransDef);
            this.PostTransition(transDef);
        }
        override protected void RunUndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBaseUndoScript(transDef))
                base.RunUndoTransition(transDef.BaseTransDef);
            this.UndoTransition(transDef);
        }
    }
}
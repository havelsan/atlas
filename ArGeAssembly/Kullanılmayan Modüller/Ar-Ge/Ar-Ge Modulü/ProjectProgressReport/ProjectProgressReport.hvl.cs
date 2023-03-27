
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ProjectProgressReport")] 

    public  partial class ProjectProgressReport : BaseAction, IWorkListBaseAction
    {
        public class ProjectProgressReportList : TTObjectCollection<ProjectProgressReport> { }
                    
        public class ChildProjectProgressReportCollection : TTObject.TTChildObjectCollection<ProjectProgressReport>
        {
            public ChildProjectProgressReportCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildProjectProgressReportCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
    /// <summary>
    /// Rapor Kayıt
    /// </summary>
            public static Guid New { get { return new Guid("36cd028d-3bd2-46bf-927c-9660a1be9707"); } }
    /// <summary>
    /// Danışman Onayı
    /// </summary>
            public static Guid ReportApprove { get { return new Guid("8227b4ec-e140-47c9-99dd-e0e66c16b0ba"); } }
    /// <summary>
    /// Red
    /// </summary>
            public static Guid Rejected { get { return new Guid("3ff642b4-f35a-4147-8819-161e6c6e4a6e"); } }
        }

        public DateTime? ReportDate
        {
            get { return (DateTime?)this["REPORTDATE"]; }
            set { this["REPORTDATE"] = value; }
        }

        public TTSequence ReportNo
        {
            get { return GetSequence("REPORTNO"); }
        }

        public string ReportText
        {
            get { return (string)this["REPORTTEXT"]; }
            set { this["REPORTTEXT"] = value; }
        }

        public ArgeProject ProgressReport
        {
            get { return (ArgeProject)((ITTObject)this).GetParent("PROGRESSREPORT"); }
            set { this["PROGRESSREPORT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ProjectProgressReport(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ProjectProgressReport(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ProjectProgressReport(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ProjectProgressReport(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ProjectProgressReport(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PROJECTPROGRESSREPORT", dataRow) { }
        protected ProjectProgressReport(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PROJECTPROGRESSREPORT", dataRow, isImported) { }
        public ProjectProgressReport(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ProjectProgressReport(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ProjectProgressReport() : base() { }

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
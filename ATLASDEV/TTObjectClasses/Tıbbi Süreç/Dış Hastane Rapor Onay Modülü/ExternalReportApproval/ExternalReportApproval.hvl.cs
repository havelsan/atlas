
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ExternalReportApproval")] 

    /// <summary>
    /// Dış XXXXXX Rapor Onay
    /// </summary>
    public  partial class ExternalReportApproval : EpisodeAction
    {
        public class ExternalReportApprovalList : TTObjectCollection<ExternalReportApproval> { }
                    
        public class ChildExternalReportApprovalCollection : TTObject.TTChildObjectCollection<ExternalReportApproval>
        {
            public ChildExternalReportApprovalCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildExternalReportApprovalCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("18bb9bfe-dbe8-430c-9fa5-caa66044a267"); } }
            public static Guid Completed { get { return new Guid("9ee7a195-921e-476e-a0ec-d1dceaeee5c1"); } }
        }

        public string HospitalOfReport
        {
            get { return (string)this["HOSPITALOFREPORT"]; }
            set { this["HOSPITALOFREPORT"] = value; }
        }

        public DateTime? ReportDate
        {
            get { return (DateTime?)this["REPORTDATE"]; }
            set { this["REPORTDATE"] = value; }
        }

        public string ReportNo
        {
            get { return (string)this["REPORTNO"]; }
            set { this["REPORTNO"] = value; }
        }

        public string Decision
        {
            get { return (string)this["DECISION"]; }
            set { this["DECISION"] = value; }
        }

        public string DoctorOfReport
        {
            get { return (string)this["DOCTOROFREPORT"]; }
            set { this["DOCTOROFREPORT"] = value; }
        }

        public DateTime? ReportApprovalDate
        {
            get { return (DateTime?)this["REPORTAPPROVALDATE"]; }
            set { this["REPORTAPPROVALDATE"] = value; }
        }

        public ExternalReportTypeDefinition ReportType
        {
            get { return (ExternalReportTypeDefinition)((ITTObject)this).GetParent("REPORTTYPE"); }
            set { this["REPORTTYPE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ExternalReportApproval(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ExternalReportApproval(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ExternalReportApproval(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ExternalReportApproval(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ExternalReportApproval(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EXTERNALREPORTAPPROVAL", dataRow) { }
        protected ExternalReportApproval(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EXTERNALREPORTAPPROVAL", dataRow, isImported) { }
        public ExternalReportApproval(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ExternalReportApproval(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ExternalReportApproval() : base() { }

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
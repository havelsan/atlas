
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ExaminationApproval")] 

    /// <summary>
    /// Muayene Onay Modülü
    /// </summary>
    public  partial class ExaminationApproval : BaseHealthCommitteeExamination
    {
        public class ExaminationApprovalList : TTObjectCollection<ExaminationApproval> { }
                    
        public class ChildExaminationApprovalCollection : TTObject.TTChildObjectCollection<ExaminationApproval>
        {
            public ChildExaminationApprovalCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildExaminationApprovalCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid New { get { return new Guid("8f6815ef-82e2-4bc1-b535-b258da324f89"); } }
            public static Guid Completed { get { return new Guid("409eaa9d-6b0f-483c-8093-fb1535eb9ff7"); } }
            public static Guid Examination { get { return new Guid("76e5f2b1-6eb7-4845-abec-c7a5419f6fa8"); } }
        }

    /// <summary>
    /// İstek Açıklaması
    /// </summary>
        public string ExplanationOfRequest
        {
            get { return (string)this["EXPLANATIONOFREQUEST"]; }
            set { this["EXPLANATIONOFREQUEST"] = value; }
        }

    /// <summary>
    /// Rapor No
    /// </summary>
        public long? ReportNo
        {
            get { return (long?)this["REPORTNO"]; }
            set { this["REPORTNO"] = value; }
        }

    /// <summary>
    /// İstek Açıklaması
    /// </summary>
        public string RequestExplanation
        {
            get { return (string)this["REQUESTEXPLANATION"]; }
            set { this["REQUESTEXPLANATION"] = value; }
        }

    /// <summary>
    /// Rapor
    /// </summary>
        public object Report
        {
            get { return (object)this["REPORT"]; }
            set { this["REPORT"] = value; }
        }

    /// <summary>
    /// Varsa Karara Ek 
    /// </summary>
        public string AdditionalDecision
        {
            get { return (string)this["ADDITIONALDECISION"]; }
            set { this["ADDITIONALDECISION"] = value; }
        }

    /// <summary>
    /// Ne Maksatla Muayene Edildiği
    /// </summary>
        public ReasonForExaminationDefinition ReasonForExamination
        {
            get { return (ReasonForExaminationDefinition)((ITTObject)this).GetParent("REASONFOREXAMINATION"); }
            set { this["REASONFOREXAMINATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ExaminationApproval(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ExaminationApproval(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ExaminationApproval(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ExaminationApproval(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ExaminationApproval(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EXAMINATIONAPPROVAL", dataRow) { }
        protected ExaminationApproval(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EXAMINATIONAPPROVAL", dataRow, isImported) { }
        public ExaminationApproval(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ExaminationApproval(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ExaminationApproval() : base() { }

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
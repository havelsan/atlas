
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SituationReport")] 

    /// <summary>
    /// Akıbet Raporu
    /// </summary>
    public  partial class SituationReport : EpisodeAction
    {
        public class SituationReportList : TTObjectCollection<SituationReport> { }
                    
        public class ChildSituationReportCollection : TTObject.TTChildObjectCollection<SituationReport>
        {
            public ChildSituationReportCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSituationReportCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid ConstitutionofSituationReport { get { return new Guid("cf99a8df-de61-4df1-8b02-2104450288e2"); } }
            public static Guid Completed { get { return new Guid("1c9252f8-fe5c-4142-ae8b-a2fad3a1085e"); } }
        }

    /// <summary>
    /// Baştabip
    /// </summary>
        public string HeadDoctor
        {
            get { return (string)this["HEADDOCTOR"]; }
            set { this["HEADDOCTOR"] = value; }
        }

    /// <summary>
    /// Sağ No
    /// </summary>
        public string SNO
        {
            get { return (string)this["SNO"]; }
            set { this["SNO"] = value; }
        }

    /// <summary>
    /// XXXXXX Adı
    /// </summary>
        public string SiteName
        {
            get { return (string)this["SITENAME"]; }
            set { this["SITENAME"] = value; }
        }

    /// <summary>
    /// Akibet Raporu
    /// </summary>
        public object Report
        {
            get { return (object)this["REPORT"]; }
            set { this["REPORT"] = value; }
        }

    /// <summary>
    /// SK Madde/Dilim/Fıkra
    /// </summary>
        public string HealthCommitteeMatters
        {
            get { return (string)this["HEALTHCOMMITTEEMATTERS"]; }
            set { this["HEALTHCOMMITTEEMATTERS"] = value; }
        }

    /// <summary>
    /// SK Tanıları
    /// </summary>
        public string HealthCommitteeDiagnosis
        {
            get { return (string)this["HEALTHCOMMITTEEDIAGNOSIS"]; }
            set { this["HEALTHCOMMITTEEDIAGNOSIS"] = value; }
        }

    /// <summary>
    /// Raporun Alındığı Tarih
    /// </summary>
        public DateTime? Date
        {
            get { return (DateTime?)this["DATE"]; }
            set { this["DATE"] = value; }
        }

    /// <summary>
    /// İlgili Sağlık Kurulu
    /// </summary>
        public HealthCommittee HealthCommitteeAction
        {
            get { return (HealthCommittee)((ITTObject)this).GetParent("HEALTHCOMMITTEEACTION"); }
            set { this["HEALTHCOMMITTEEACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Durum
    /// </summary>
        public HealthCommitteeSituationDefinition SentInfo
        {
            get { return (HealthCommitteeSituationDefinition)((ITTObject)this).GetParent("SENTINFO"); }
            set { this["SENTINFO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected SituationReport(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SituationReport(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SituationReport(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SituationReport(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SituationReport(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SITUATIONREPORT", dataRow) { }
        protected SituationReport(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SITUATIONREPORT", dataRow, isImported) { }
        public SituationReport(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SituationReport(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SituationReport() : base() { }

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

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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="Redecision")] 

    /// <summary>
    /// Zeyil(İptal Edildi)
    /// </summary>
    public  partial class Redecision : EpisodeActionWithDiagnosis
    {
        public class RedecisionList : TTObjectCollection<Redecision> { }
                    
        public class ChildRedecisionCollection : TTObject.TTChildObjectCollection<Redecision>
        {
            public ChildRedecisionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildRedecisionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid Acceptance { get { return new Guid("7f1eedfb-597f-430f-97b0-39540d648c92"); } }
            public static Guid HealthCommittee { get { return new Guid("066416a2-a0da-4538-9181-55df76a07b16"); } }
            public static Guid Approval { get { return new Guid("1787a4bd-fb8d-4010-874a-28df39eee4d2"); } }
            public static Guid Result { get { return new Guid("02e1ad09-6e2c-4dc5-852b-c062ee3e9d71"); } }
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
    /// Rapor Tarihi
    /// </summary>
        public DateTime? ReportDate
        {
            get { return (DateTime?)this["REPORTDATE"]; }
            set { this["REPORTDATE"] = value; }
        }

    /// <summary>
    /// Ön Tanı
    /// </summary>
        public string PreDiagnosis
        {
            get { return (string)this["PREDIAGNOSIS"]; }
            set { this["PREDIAGNOSIS"] = value; }
        }

    /// <summary>
    /// Karar
    /// </summary>
        public string Decision
        {
            get { return (string)this["DECISION"]; }
            set { this["DECISION"] = value; }
        }

    /// <summary>
    /// Defter No
    /// </summary>
        public long? BookNo
        {
            get { return (long?)this["BOOKNO"]; }
            set { this["BOOKNO"] = value; }
        }

    /// <summary>
    /// Rapor
    /// </summary>
        public string Report
        {
            get { return (string)this["REPORT"]; }
            set { this["REPORT"] = value; }
        }

    /// <summary>
    /// Ne Maksatla Muayene Edildiği
    /// </summary>
        public ReasonForExaminationDefinition ReasonForExamination
        {
            get { return (ReasonForExaminationDefinition)((ITTObject)this).GetParent("REASONFOREXAMINATION"); }
            set { this["REASONFOREXAMINATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateOldReportsCollection()
        {
            _OldReports = new RedecisionOldReports.ChildRedecisionOldReportsCollection(this, new Guid("a5f03464-b683-42dc-bb5b-03ee5de38754"));
            ((ITTChildObjectCollection)_OldReports).GetChildren();
        }

        protected RedecisionOldReports.ChildRedecisionOldReportsCollection _OldReports = null;
    /// <summary>
    /// Child collection for Zeyil
    /// </summary>
        public RedecisionOldReports.ChildRedecisionOldReportsCollection OldReports
        {
            get
            {
                if (_OldReports == null)
                    CreateOldReportsCollection();
                return _OldReports;
            }
        }

        virtual protected void CreateMatterSliceAnectodesCollection()
        {
            _MatterSliceAnectodes = new RedecisionMatterSliceAnectodeGrid.ChildRedecisionMatterSliceAnectodeGridCollection(this, new Guid("f3245195-fca3-4443-be19-068cde628904"));
            ((ITTChildObjectCollection)_MatterSliceAnectodes).GetChildren();
        }

        protected RedecisionMatterSliceAnectodeGrid.ChildRedecisionMatterSliceAnectodeGridCollection _MatterSliceAnectodes = null;
    /// <summary>
    /// Child collection for Madde Dilim Fıkra
    /// </summary>
        public RedecisionMatterSliceAnectodeGrid.ChildRedecisionMatterSliceAnectodeGridCollection MatterSliceAnectodes
        {
            get
            {
                if (_MatterSliceAnectodes == null)
                    CreateMatterSliceAnectodesCollection();
                return _MatterSliceAnectodes;
            }
        }

        protected Redecision(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected Redecision(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected Redecision(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected Redecision(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected Redecision(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "REDECISION", dataRow) { }
        protected Redecision(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "REDECISION", dataRow, isImported) { }
        public Redecision(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public Redecision(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public Redecision() : base() { }

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
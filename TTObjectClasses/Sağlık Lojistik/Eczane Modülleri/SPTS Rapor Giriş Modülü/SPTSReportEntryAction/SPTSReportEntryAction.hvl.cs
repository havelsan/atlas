
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SPTSReportEntryAction")] 

    /// <summary>
    /// SPTS Rapor Giriş 
    /// </summary>
    public  partial class SPTSReportEntryAction : EpisodeAction
    {
        public class SPTSReportEntryActionList : TTObjectCollection<SPTSReportEntryAction> { }
                    
        public class ChildSPTSReportEntryActionCollection : TTObject.TTChildObjectCollection<SPTSReportEntryAction>
        {
            public ChildSPTSReportEntryActionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSPTSReportEntryActionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
    /// <summary>
    /// Rapor Kayıt
    /// </summary>
            public static Guid Request { get { return new Guid("854dade5-ec17-4ebc-8123-f410f1102aab"); } }
    /// <summary>
    /// SPTS Onay
    /// </summary>
            public static Guid Approval { get { return new Guid("e0a3c9a4-d691-4426-b34c-7abbc0f41ae2"); } }
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("f7e9c601-40fa-420e-a97f-7f18f4ba23ea"); } }
        }

        public Guid? SPTSMessageID
        {
            get { return (Guid?)this["SPTSMESSAGEID"]; }
            set { this["SPTSMESSAGEID"] = value; }
        }

    /// <summary>
    /// Çocuğun yaş ve fiziki boy uzunluğu var
    /// </summary>
        public bool? AgeAndSize
        {
            get { return (bool?)this["AGEANDSIZE"]; }
            set { this["AGEANDSIZE"] = value; }
        }

    /// <summary>
    /// Tedavi Şeması Var
    /// </summary>
        public bool? SchemeOfCure
        {
            get { return (bool?)this["SCHEMEOFCURE"]; }
            set { this["SCHEMEOFCURE"] = value; }
        }

    /// <summary>
    /// T değeri var ( osteopoz tanısı olanlar için )
    /// </summary>
        public bool? TValue
        {
            get { return (bool?)this["TVALUE"]; }
            set { this["TVALUE"] = value; }
        }

    /// <summary>
    /// Ekinde pataloji raporu var
    /// </summary>
        public bool? PathologyReport
        {
            get { return (bool?)this["PATHOLOGYREPORT"]; }
            set { this["PATHOLOGYREPORT"] = value; }
        }

    /// <summary>
    /// Ağızdan beslenememektedir ibaresi var 
    /// </summary>
        public bool? OralNutrition
        {
            get { return (bool?)this["ORALNUTRITION"]; }
            set { this["ORALNUTRITION"] = value; }
        }

    /// <summary>
    /// Kurum Türü
    /// </summary>
        public SPTSFoundationTypeEnum? FoundationType
        {
            get { return (SPTSFoundationTypeEnum?)(int?)this["FOUNDATIONTYPE"]; }
            set { this["FOUNDATIONTYPE"] = value; }
        }

    /// <summary>
    /// Rapor No
    /// </summary>
        public long? Report_No
        {
            get { return (long?)this["REPORT NO"]; }
            set { this["REPORT NO"] = value; }
        }

    /// <summary>
    /// Rapor Başlangıç Tarihi
    /// </summary>
        public DateTime? ReportStartDate
        {
            get { return (DateTime?)this["REPORTSTARTDATE"]; }
            set { this["REPORTSTARTDATE"] = value; }
        }

    /// <summary>
    /// Rapor Bitiş Tarihi
    /// </summary>
        public DateTime? ReportEndDate
        {
            get { return (DateTime?)this["REPORTENDDATE"]; }
            set { this["REPORTENDDATE"] = value; }
        }

        virtual protected void CreateDiagnosisForReportsCollection()
        {
            _DiagnosisForReports = new DiagnosisForReport.ChildDiagnosisForReportCollection(this, new Guid("7f72d4f2-0a4b-4960-b54f-a374b075f56a"));
            ((ITTChildObjectCollection)_DiagnosisForReports).GetChildren();
        }

        protected DiagnosisForReport.ChildDiagnosisForReportCollection _DiagnosisForReports = null;
        public DiagnosisForReport.ChildDiagnosisForReportCollection DiagnosisForReports
        {
            get
            {
                if (_DiagnosisForReports == null)
                    CreateDiagnosisForReportsCollection();
                return _DiagnosisForReports;
            }
        }

        virtual protected void CreateDrugOrderForReportsCollection()
        {
            _DrugOrderForReports = new DrugOrderForReport.ChildDrugOrderForReportCollection(this, new Guid("d0bb9dab-1a62-465c-bd11-6b7129589512"));
            ((ITTChildObjectCollection)_DrugOrderForReports).GetChildren();
        }

        protected DrugOrderForReport.ChildDrugOrderForReportCollection _DrugOrderForReports = null;
        public DrugOrderForReport.ChildDrugOrderForReportCollection DrugOrderForReports
        {
            get
            {
                if (_DrugOrderForReports == null)
                    CreateDrugOrderForReportsCollection();
                return _DrugOrderForReports;
            }
        }

        virtual protected void CreateSpecialityForReportsCollection()
        {
            _SpecialityForReports = new SpecialityForReport.ChildSpecialityForReportCollection(this, new Guid("8086dc4a-904e-4755-8bf7-190518a6c831"));
            ((ITTChildObjectCollection)_SpecialityForReports).GetChildren();
        }

        protected SpecialityForReport.ChildSpecialityForReportCollection _SpecialityForReports = null;
        public SpecialityForReport.ChildSpecialityForReportCollection SpecialityForReports
        {
            get
            {
                if (_SpecialityForReports == null)
                    CreateSpecialityForReportsCollection();
                return _SpecialityForReports;
            }
        }

        protected SPTSReportEntryAction(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SPTSReportEntryAction(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SPTSReportEntryAction(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SPTSReportEntryAction(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SPTSReportEntryAction(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SPTSREPORTENTRYACTION", dataRow) { }
        protected SPTSReportEntryAction(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SPTSREPORTENTRYACTION", dataRow, isImported) { }
        public SPTSReportEntryAction(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SPTSReportEntryAction(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SPTSReportEntryAction() : base() { }

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
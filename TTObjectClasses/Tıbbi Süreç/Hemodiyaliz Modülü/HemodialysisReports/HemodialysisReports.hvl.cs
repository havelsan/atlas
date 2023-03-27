
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HemodialysisReports")] 

    /// <summary>
    /// Hemodiyaliz Raporları
    /// </summary>
    public  partial class HemodialysisReports : TTObject
    {
        public class HemodialysisReportsList : TTObjectCollection<HemodialysisReports> { }
                    
        public class ChildHemodialysisReportsCollection : TTObject.TTChildObjectCollection<HemodialysisReports>
        {
            public ChildHemodialysisReportsCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHemodialysisReportsCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Tedavi Türü
    /// </summary>
        public TreatmentQueryReportTypeEnum? TreatmentType
        {
            get { return (TreatmentQueryReportTypeEnum?)(int?)this["TREATMENTTYPE"]; }
            set { this["TREATMENTTYPE"] = value; }
        }

    /// <summary>
    /// Seans Gün Sayısı
    /// </summary>
        public int? SessionDay
        {
            get { return (int?)this["SESSIONDAY"]; }
            set { this["SESSIONDAY"] = value; }
        }

    /// <summary>
    /// Tanı Grubu
    /// </summary>
        public string DiagnosisGroup
        {
            get { return (string)this["DIAGNOSISGROUP"]; }
            set { this["DIAGNOSISGROUP"] = value; }
        }

    /// <summary>
    /// Local Rapor Idsi
    /// </summary>
        public Guid? LocalReportId
        {
            get { return (Guid?)this["LOCALREPORTID"]; }
            set { this["LOCALREPORTID"] = value; }
        }

    /// <summary>
    /// Paket Numarası
    /// </summary>
        public string PackageProcedureInfo
        {
            get { return (string)this["PACKAGEPROCEDUREINFO"]; }
            set { this["PACKAGEPROCEDUREINFO"] = value; }
        }

    /// <summary>
    /// Medula Rapor Tarihi
    /// </summary>
        public DateTime? ReportDate
        {
            get { return (DateTime?)this["REPORTDATE"]; }
            set { this["REPORTDATE"] = value; }
        }

    /// <summary>
    /// Medula Rapor Bitiş Tarihi
    /// </summary>
        public DateTime? ReportEndDate
        {
            get { return (DateTime?)this["REPORTENDDATE"]; }
            set { this["REPORTENDDATE"] = value; }
        }

    /// <summary>
    /// Rapor Bilgisi
    /// </summary>
        public string ReportInfo
        {
            get { return (string)this["REPORTINFO"]; }
            set { this["REPORTINFO"] = value; }
        }

    /// <summary>
    /// Rapor Numarası
    /// </summary>
        public string ReportNo
        {
            get { return (string)this["REPORTNO"]; }
            set { this["REPORTNO"] = value; }
        }

    /// <summary>
    /// Medula Rapor Başlangıç Tarihi
    /// </summary>
        public DateTime? ReportStartDate
        {
            get { return (DateTime?)this["REPORTSTARTDATE"]; }
            set { this["REPORTSTARTDATE"] = value; }
        }

    /// <summary>
    /// Rapor Süresi
    /// </summary>
        public int? ReportTime
        {
            get { return (int?)this["REPORTTIME"]; }
            set { this["REPORTTIME"] = value; }
        }

    /// <summary>
    /// Rapor Türü : 1 ise Heyet Raporu, 0 ise Tek Hekim Raporu
    /// </summary>
        public bool? ReportType
        {
            get { return (bool?)this["REPORTTYPE"]; }
            set { this["REPORTTYPE"] = value; }
        }

    /// <summary>
    /// Seans Sayısı
    /// </summary>
        public int? SessionLimit
        {
            get { return (int?)this["SESSIONLIMIT"]; }
            set { this["SESSIONLIMIT"] = value; }
        }

        public DialysisReport DialysisReport
        {
            get { return (DialysisReport)((ITTObject)this).GetParent("DIALYSISREPORT"); }
            set { this["DIALYSISREPORT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateHemodialysisOrdersCollection()
        {
            _HemodialysisOrders = new HemodialysisOrder.ChildHemodialysisOrderCollection(this, new Guid("bc4d0405-63f6-40b5-bea3-6ca98c2ccefc"));
            ((ITTChildObjectCollection)_HemodialysisOrders).GetChildren();
        }

        protected HemodialysisOrder.ChildHemodialysisOrderCollection _HemodialysisOrders = null;
    /// <summary>
    /// Child collection for Hemodiyaliz Raporları
    /// </summary>
        public HemodialysisOrder.ChildHemodialysisOrderCollection HemodialysisOrders
        {
            get
            {
                if (_HemodialysisOrders == null)
                    CreateHemodialysisOrdersCollection();
                return _HemodialysisOrders;
            }
        }

        protected HemodialysisReports(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HemodialysisReports(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HemodialysisReports(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HemodialysisReports(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HemodialysisReports(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HEMODIALYSISREPORTS", dataRow) { }
        protected HemodialysisReports(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HEMODIALYSISREPORTS", dataRow, isImported) { }
        public HemodialysisReports(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HemodialysisReports(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HemodialysisReports() : base() { }

    }
}
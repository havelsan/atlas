
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PhysiotherapyReports")] 

    /// <summary>
    /// F.T.R. Raporları
    /// </summary>
    public  partial class PhysiotherapyReports : TTObject
    {
        public class PhysiotherapyReportsList : TTObjectCollection<PhysiotherapyReports> { }
                    
        public class ChildPhysiotherapyReportsCollection : TTObject.TTChildObjectCollection<PhysiotherapyReports>
        {
            public ChildPhysiotherapyReportsCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPhysiotherapyReportsCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
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
    /// Tedavi Türü; A:Ayaktan, Y:Yatarak
    /// </summary>
        public string TreatmentProcessType
        {
            get { return (string)this["TREATMENTPROCESSTYPE"]; }
            set { this["TREATMENTPROCESSTYPE"] = value; }
        }

    /// <summary>
    /// Seans Sayısı
    /// </summary>
        public int? SessionLimit
        {
            get { return (int?)this["SESSIONLIMIT"]; }
            set { this["SESSIONLIMIT"] = value; }
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
    /// Rapor Bilgisi
    /// </summary>
        public string ReportInfo
        {
            get { return (string)this["REPORTINFO"]; }
            set { this["REPORTINFO"] = value; }
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
    /// Medula Rapor Bitiş Tarihi
    /// </summary>
        public DateTime? ReportEndDate
        {
            get { return (DateTime?)this["REPORTENDDATE"]; }
            set { this["REPORTENDDATE"] = value; }
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
    /// Tedavi Türü
    /// </summary>
        public TreatmentQueryReportTypeEnum? TreatmentType
        {
            get { return (TreatmentQueryReportTypeEnum?)(int?)this["TREATMENTTYPE"]; }
            set { this["TREATMENTTYPE"] = value; }
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
    /// Medula Rapor Tarihi
    /// </summary>
        public DateTime? ReportDate
        {
            get { return (DateTime?)this["REPORTDATE"]; }
            set { this["REPORTDATE"] = value; }
        }

    /// <summary>
    /// FTR Vücut Bölgesi Tanımları
    /// </summary>
        public FTRVucutBolgesi FTRApplicationAreaDef
        {
            get { return (FTRVucutBolgesi)((ITTObject)this).GetParent("FTRAPPLICATIONAREADEF"); }
            set { this["FTRAPPLICATIONAREADEF"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreatePhysiotherapyOrdersCollection()
        {
            _PhysiotherapyOrders = new PhysiotherapyOrder.ChildPhysiotherapyOrderCollection(this, new Guid("61e6aced-7f92-4498-8901-5343f592db74"));
            ((ITTChildObjectCollection)_PhysiotherapyOrders).GetChildren();
        }

        protected PhysiotherapyOrder.ChildPhysiotherapyOrderCollection _PhysiotherapyOrders = null;
    /// <summary>
    /// Child collection for Fizyoterapi Raporları
    /// </summary>
        public PhysiotherapyOrder.ChildPhysiotherapyOrderCollection PhysiotherapyOrders
        {
            get
            {
                if (_PhysiotherapyOrders == null)
                    CreatePhysiotherapyOrdersCollection();
                return _PhysiotherapyOrders;
            }
        }

        protected PhysiotherapyReports(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PhysiotherapyReports(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PhysiotherapyReports(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PhysiotherapyReports(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PhysiotherapyReports(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PHYSIOTHERAPYREPORTS", dataRow) { }
        protected PhysiotherapyReports(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PHYSIOTHERAPYREPORTS", dataRow, isImported) { }
        public PhysiotherapyReports(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PhysiotherapyReports(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PhysiotherapyReports() : base() { }

    }
}
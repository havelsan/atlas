
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="IQIntelligenceTestReport")] 

    /// <summary>
    /// IQ Zeka Testi Raporu
    /// </summary>
    public  partial class IQIntelligenceTestReport : BasePsychologyForm
    {
        public class IQIntelligenceTestReportList : TTObjectCollection<IQIntelligenceTestReport> { }
                    
        public class ChildIQIntelligenceTestReportCollection : TTObject.TTChildObjectCollection<IQIntelligenceTestReport>
        {
            public ChildIQIntelligenceTestReportCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildIQIntelligenceTestReportCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class IQIntelligenceTestReportFormList_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public DateTime? AddedDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADDEDDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["IQINTELLIGENCETESTREPORT"].AllPropertyDefs["ADDEDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Addeduser
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADDEDUSER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Proceduredoctor
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDUREDOCTOR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public IQIntelligenceTestReportFormList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public IQIntelligenceTestReportFormList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected IQIntelligenceTestReportFormList_Class() : base() { }
        }

        public static BindingList<IQIntelligenceTestReport.IQIntelligenceTestReportFormList_Class> IQIntelligenceTestReportFormList(Guid EPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["IQINTELLIGENCETESTREPORT"].QueryDefs["IQIntelligenceTestReportFormList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<IQIntelligenceTestReport.IQIntelligenceTestReportFormList_Class>(queryDef, paramList, pi);
        }

        public static BindingList<IQIntelligenceTestReport.IQIntelligenceTestReportFormList_Class> IQIntelligenceTestReportFormList(TTObjectContext objectContext, Guid EPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["IQINTELLIGENCETESTREPORT"].QueryDefs["IQIntelligenceTestReportFormList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<IQIntelligenceTestReport.IQIntelligenceTestReportFormList_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Testi İsteyen Kişi yada Kurum
    /// </summary>
        public string TestXXXXXX
        {
            get { return (string)this["TESTXXXXXX"]; }
            set { this["TESTXXXXXX"] = value; }
        }

    /// <summary>
    /// Kritik Yaşam Olayı
    /// </summary>
        public string CriticalLifeEvent
        {
            get { return (string)this["CRITICALLIFEEVENT"]; }
            set { this["CRITICALLIFEEVENT"] = value; }
        }

    /// <summary>
    /// Teste Ne Amaçla Alındığı
    /// </summary>
        public string TestPurpose
        {
            get { return (string)this["TESTPURPOSE"]; }
            set { this["TESTPURPOSE"] = value; }
        }

    /// <summary>
    /// Performans Zeka
    /// </summary>
        public string PerformanceIntelligence
        {
            get { return (string)this["PERFORMANCEINTELLIGENCE"]; }
            set { this["PERFORMANCEINTELLIGENCE"] = value; }
        }

    /// <summary>
    /// Sözel Zeka
    /// </summary>
        public string VerbalIntelligence
        {
            get { return (string)this["VERBALINTELLIGENCE"]; }
            set { this["VERBALINTELLIGENCE"] = value; }
        }

    /// <summary>
    /// Toplam Zeka
    /// </summary>
        public string TotalIntelligence
        {
            get { return (string)this["TOTALINTELLIGENCE"]; }
            set { this["TOTALINTELLIGENCE"] = value; }
        }

    /// <summary>
    /// Yorum
    /// </summary>
        public string Comment
        {
            get { return (string)this["COMMENT"]; }
            set { this["COMMENT"] = value; }
        }

    /// <summary>
    /// Öğrenim Durumu
    /// </summary>
        public SKRSOgrenimDurumu EducationStatus
        {
            get { return (SKRSOgrenimDurumu)((ITTObject)this).GetParent("EDUCATIONSTATUS"); }
            set { this["EDUCATIONSTATUS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Mesleği
    /// </summary>
        public SKRSMeslekler PatientJob
        {
            get { return (SKRSMeslekler)((ITTObject)this).GetParent("PATIENTJOB"); }
            set { this["PATIENTJOB"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected IQIntelligenceTestReport(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected IQIntelligenceTestReport(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected IQIntelligenceTestReport(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected IQIntelligenceTestReport(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected IQIntelligenceTestReport(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "IQINTELLIGENCETESTREPORT", dataRow) { }
        protected IQIntelligenceTestReport(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "IQINTELLIGENCETESTREPORT", dataRow, isImported) { }
        public IQIntelligenceTestReport(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public IQIntelligenceTestReport(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public IQIntelligenceTestReport() : base() { }

    }
}
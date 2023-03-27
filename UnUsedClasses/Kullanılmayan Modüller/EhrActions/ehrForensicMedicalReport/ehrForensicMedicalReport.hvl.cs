
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ehrForensicMedicalReport")] 

    /// <summary>
    /// Adli Tıp Raporları
    /// </summary>
    public  partial class ehrForensicMedicalReport : ehrEpisodeAction
    {
        public class ehrForensicMedicalReportList : TTObjectCollection<ehrForensicMedicalReport> { }
                    
        public class ChildehrForensicMedicalReportCollection : TTObject.TTChildObjectCollection<ehrForensicMedicalReport>
        {
            public ChildehrForensicMedicalReportCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildehrForensicMedicalReportCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
            public static Guid Active { get { return new Guid("d82caca1-a08a-43fa-b009-be70b816c5ec"); } }
            public static Guid UnActive { get { return new Guid("8abe0000-7e19-46e0-a07f-e69109e6aa4c"); } }
        }

    /// <summary>
    /// Evrak Tarihi
    /// </summary>
        public DateTime? DocumentDate
        {
            get { return (DateTime?)this["DOCUMENTDATE"]; }
            set { this["DOCUMENTDATE"] = value; }
        }

    /// <summary>
    /// Evrak Sayısı
    /// </summary>
        public string DocumentNumber
        {
            get { return (string)this["DOCUMENTNUMBER"]; }
            set { this["DOCUMENTNUMBER"] = value; }
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
    /// Rapor Tipi
    /// </summary>
        public ForensicMedicalReportTypeEnum? ReportType
        {
            get { return (ForensicMedicalReportTypeEnum?)(int?)this["REPORTTYPE"]; }
            set { this["REPORTTYPE"] = value; }
        }

    /// <summary>
    /// Gönderen Makam
    /// </summary>
        public MilitaryUnit SenderChair
        {
            get { return (MilitaryUnit)((ITTObject)this).GetParent("SENDERCHAIR"); }
            set { this["SENDERCHAIR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ehrForensicMedicalReport(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ehrForensicMedicalReport(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ehrForensicMedicalReport(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ehrForensicMedicalReport(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ehrForensicMedicalReport(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EHRFORENSICMEDICALREPORT", dataRow) { }
        protected ehrForensicMedicalReport(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EHRFORENSICMEDICALREPORT", dataRow, isImported) { }
        public ehrForensicMedicalReport(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ehrForensicMedicalReport(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ehrForensicMedicalReport() : base() { }

    }
}
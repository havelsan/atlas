
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DrugOrderForReport")] 

    public  partial class DrugOrderForReport : TTObject
    {
        public class DrugOrderForReportList : TTObjectCollection<DrugOrderForReport> { }
                    
        public class ChildDrugOrderForReportCollection : TTObject.TTChildObjectCollection<DrugOrderForReport>
        {
            public ChildDrugOrderForReportCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDrugOrderForReportCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Raporlu
    /// </summary>
        public bool? HasReport
        {
            get { return (bool?)this["HASREPORT"]; }
            set { this["HASREPORT"] = value; }
        }

    /// <summary>
    /// Doz
    /// </summary>
        public int? Dosage
        {
            get { return (int?)this["DOSAGE"]; }
            set { this["DOSAGE"] = value; }
        }

    /// <summary>
    /// Doz Miktarı
    /// </summary>
        public int? DosageAmount
        {
            get { return (int?)this["DOSAGEAMOUNT"]; }
            set { this["DOSAGEAMOUNT"] = value; }
        }

    /// <summary>
    /// Haftalık / Aylık
    /// </summary>
        public int? WeeklyMonthly
        {
            get { return (int?)this["WEEKLYMONTHLY"]; }
            set { this["WEEKLYMONTHLY"] = value; }
        }

    /// <summary>
    /// 10 Günlük
    /// </summary>
        public bool? HasTenDays
        {
            get { return (bool?)this["HASTENDAYS"]; }
            set { this["HASTENDAYS"] = value; }
        }

        public DrugDefinition Drug
        {
            get { return (DrugDefinition)((ITTObject)this).GetParent("DRUG"); }
            set { this["DRUG"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SPTSReportEntryAction SPTSReportEntryAction
        {
            get { return (SPTSReportEntryAction)((ITTObject)this).GetParent("SPTSREPORTENTRYACTION"); }
            set { this["SPTSREPORTENTRYACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public MaterialBarcodeLevel BarcodeLevel
        {
            get { return (MaterialBarcodeLevel)((ITTObject)this).GetParent("BARCODELEVEL"); }
            set { this["BARCODELEVEL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected DrugOrderForReport(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DrugOrderForReport(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DrugOrderForReport(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DrugOrderForReport(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DrugOrderForReport(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DRUGORDERFORREPORT", dataRow) { }
        protected DrugOrderForReport(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DRUGORDERFORREPORT", dataRow, isImported) { }
        public DrugOrderForReport(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DrugOrderForReport(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DrugOrderForReport() : base() { }

    }
}
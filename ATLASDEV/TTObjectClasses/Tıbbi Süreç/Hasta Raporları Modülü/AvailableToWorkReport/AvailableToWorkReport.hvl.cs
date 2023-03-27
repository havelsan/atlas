
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="AvailableToWorkReport")] 

    /// <summary>
    /// Hizmet Akdiyle Çalışanlar İçin Çlışabilir Kağıdının Yazıldığı Temel Nesnedir 
    /// </summary>
    public  partial class AvailableToWorkReport : EpisodeAction
    {
        public class AvailableToWorkReportList : TTObjectCollection<AvailableToWorkReport> { }
                    
        public class ChildAvailableToWorkReportCollection : TTObject.TTChildObjectCollection<AvailableToWorkReport>
        {
            public ChildAvailableToWorkReportCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildAvailableToWorkReportCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetAvailableToWorkReport_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Analysis
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ANALYSIS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["AVAILABLETOWORKREPORT"].AllPropertyDefs["ANALYSIS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Dispatch
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISPATCH"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["AVAILABLETOWORKREPORT"].AllPropertyDefs["DISPATCH"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? No
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["AVAILABLETOWORKREPORT"].AllPropertyDefs["NO"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ProperWorkDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROPERWORKDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["AVAILABLETOWORKREPORT"].AllPropertyDefs["PROPERWORKDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Serial
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SERIAL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["AVAILABLETOWORKREPORT"].AllPropertyDefs["SERIAL"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Treatment
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TREATMENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["AVAILABLETOWORKREPORT"].AllPropertyDefs["TREATMENT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? TreatmentTerminationDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TREATMENTTERMINATIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["AVAILABLETOWORKREPORT"].AllPropertyDefs["TREATMENTTERMINATIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Doctor
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCTOR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Surname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SURNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["SURNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetAvailableToWorkReport_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetAvailableToWorkReport_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetAvailableToWorkReport_Class() : base() { }
        }

        public static class States
        {
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("464bdc74-1fde-4f0a-a9ea-8200de292ce9"); } }
            public static Guid Completed { get { return new Guid("89ec5f6a-0171-47c9-b2c4-1d9fe2c6feaf"); } }
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancelled { get { return new Guid("df42a9d4-7fc2-43dd-a9cb-32fc3ab5cada"); } }
        }

        public static BindingList<AvailableToWorkReport.GetAvailableToWorkReport_Class> GetAvailableToWorkReport(string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["AVAILABLETOWORKREPORT"].QueryDefs["GetAvailableToWorkReport"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<AvailableToWorkReport.GetAvailableToWorkReport_Class>(queryDef, paramList, pi);
        }

        public static BindingList<AvailableToWorkReport.GetAvailableToWorkReport_Class> GetAvailableToWorkReport(TTObjectContext objectContext, string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["AVAILABLETOWORKREPORT"].QueryDefs["GetAvailableToWorkReport"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<AvailableToWorkReport.GetAvailableToWorkReport_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Tedavi
    /// </summary>
        public string Treatment
        {
            get { return (string)this["TREATMENT"]; }
            set { this["TREATMENT"] = value; }
        }

    /// <summary>
    /// Tedavisinin Bittiği Tarih Ve Saat
    /// </summary>
        public DateTime? TreatmentTerminationDate
        {
            get { return (DateTime?)this["TREATMENTTERMINATIONDATE"]; }
            set { this["TREATMENTTERMINATIONDATE"] = value; }
        }

    /// <summary>
    /// Çalışabileceği Tarih
    /// </summary>
        public DateTime? ProperWorkDate
        {
            get { return (DateTime?)this["PROPERWORKDATE"]; }
            set { this["PROPERWORKDATE"] = value; }
        }

    /// <summary>
    /// Sevk
    /// </summary>
        public string Dispatch
        {
            get { return (string)this["DISPATCH"]; }
            set { this["DISPATCH"] = value; }
        }

    /// <summary>
    /// Seri
    /// </summary>
        public string Serial
        {
            get { return (string)this["SERIAL"]; }
            set { this["SERIAL"] = value; }
        }

    /// <summary>
    /// No
    /// </summary>
        public int? No
        {
            get { return (int?)this["NO"]; }
            set { this["NO"] = value; }
        }

    /// <summary>
    /// Tahlil
    /// </summary>
        public string Analysis
        {
            get { return (string)this["ANALYSIS"]; }
            set { this["ANALYSIS"] = value; }
        }

        protected AvailableToWorkReport(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected AvailableToWorkReport(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected AvailableToWorkReport(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected AvailableToWorkReport(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected AvailableToWorkReport(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "AVAILABLETOWORKREPORT", dataRow) { }
        protected AvailableToWorkReport(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "AVAILABLETOWORKREPORT", dataRow, isImported) { }
        public AvailableToWorkReport(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public AvailableToWorkReport(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public AvailableToWorkReport() : base() { }

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
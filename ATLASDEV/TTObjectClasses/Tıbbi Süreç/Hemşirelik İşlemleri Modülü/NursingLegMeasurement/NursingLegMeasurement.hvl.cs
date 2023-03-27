
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="NursingLegMeasurement")] 

    /// <summary>
    /// Bacak Ölçüm Takip Formu
    /// </summary>
    public  partial class NursingLegMeasurement : BaseNursingDataEntry
    {
        public class NursingLegMeasurementList : TTObjectCollection<NursingLegMeasurement> { }
                    
        public class ChildNursingLegMeasurementCollection : TTObject.TTChildObjectCollection<NursingLegMeasurement>
        {
            public ChildNursingLegMeasurementCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildNursingLegMeasurementCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetNursingLegMeasurements_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? ObjectDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTDEFID"]);
                }
            }

            public Guid? CurrentStateDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENTSTATEDEFID"]);
                }
            }

            public DateTime? LastUpdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LASTUPDATE"]);
                    if (val == null)
                        return null;
                    return (DateTime)Convert.ChangeType(val, typeof(DateTime)); 
                }
            }

            public DateTime? ApplicationDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["APPLICATIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGLEGMEASUREMENT"].AllPropertyDefs["APPLICATIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? EntryDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ENTRYDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGLEGMEASUREMENT"].AllPropertyDefs["ENTRYDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string LowerRightLeg
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LOWERRIGHTLEG"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGLEGMEASUREMENT"].AllPropertyDefs["LOWERRIGHTLEG"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string UpperRightLeg
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UPPERRIGHTLEG"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGLEGMEASUREMENT"].AllPropertyDefs["UPPERRIGHTLEG"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string LowerLeftLeg
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LOWERLEFTLEG"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGLEGMEASUREMENT"].AllPropertyDefs["LOWERLEFTLEG"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string UpperLeftLeg
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UPPERLEFTLEG"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGLEGMEASUREMENT"].AllPropertyDefs["UPPERLEFTLEG"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? ActionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGLEGMEASUREMENT"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetNursingLegMeasurements_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetNursingLegMeasurements_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetNursingLegMeasurements_Class() : base() { }
        }

        new public static class States
        {
            public static Guid Yeni { get { return new Guid("2f6b2d75-fb0e-43c9-a964-af59bb71f8b9"); } }
    /// <summary>
    /// Yanlış veriyi silmek için
    /// </summary>
            public static Guid Cancelled { get { return new Guid("c9a1ec5b-749a-4cff-9a32-d66e3b0d807b"); } }
        }

        public static BindingList<NursingLegMeasurement.GetNursingLegMeasurements_Class> GetNursingLegMeasurements(Guid NURSINGAPPLICATION, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NURSINGLEGMEASUREMENT"].QueryDefs["GetNursingLegMeasurements"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("NURSINGAPPLICATION", NURSINGAPPLICATION);

            return TTReportNqlObject.QueryObjects<NursingLegMeasurement.GetNursingLegMeasurements_Class>(queryDef, paramList, pi);
        }

        public static BindingList<NursingLegMeasurement.GetNursingLegMeasurements_Class> GetNursingLegMeasurements(TTObjectContext objectContext, Guid NURSINGAPPLICATION, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NURSINGLEGMEASUREMENT"].QueryDefs["GetNursingLegMeasurements"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("NURSINGAPPLICATION", NURSINGAPPLICATION);

            return TTReportNqlObject.QueryObjects<NursingLegMeasurement.GetNursingLegMeasurements_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Sağ Alt  Bacak Ölçümü
    /// </summary>
        public string LowerRightLeg
        {
            get { return (string)this["LOWERRIGHTLEG"]; }
            set { this["LOWERRIGHTLEG"] = value; }
        }

    /// <summary>
    /// Sağ Üst Bacak
    /// </summary>
        public string UpperRightLeg
        {
            get { return (string)this["UPPERRIGHTLEG"]; }
            set { this["UPPERRIGHTLEG"] = value; }
        }

    /// <summary>
    /// Sol Alt Bacak
    /// </summary>
        public string LowerLeftLeg
        {
            get { return (string)this["LOWERLEFTLEG"]; }
            set { this["LOWERLEFTLEG"] = value; }
        }

    /// <summary>
    /// Sol Üst Bacak
    /// </summary>
        public string UpperLeftLeg
        {
            get { return (string)this["UPPERLEFTLEG"]; }
            set { this["UPPERLEFTLEG"] = value; }
        }

    /// <summary>
    /// Tarih
    /// </summary>
        public DateTime? ActionDate
        {
            get { return (DateTime?)this["ACTIONDATE"]; }
            set { this["ACTIONDATE"] = value; }
        }

        protected NursingLegMeasurement(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected NursingLegMeasurement(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected NursingLegMeasurement(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected NursingLegMeasurement(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected NursingLegMeasurement(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "NURSINGLEGMEASUREMENT", dataRow) { }
        protected NursingLegMeasurement(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "NURSINGLEGMEASUREMENT", dataRow, isImported) { }
        public NursingLegMeasurement(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public NursingLegMeasurement(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public NursingLegMeasurement() : base() { }

    }
}
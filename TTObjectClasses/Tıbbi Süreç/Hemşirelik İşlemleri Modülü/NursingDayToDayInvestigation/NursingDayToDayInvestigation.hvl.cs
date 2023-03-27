
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="NursingDayToDayInvestigation")] 

    public  partial class NursingDayToDayInvestigation : TTObject
    {
        public class NursingDayToDayInvestigationList : TTObjectCollection<NursingDayToDayInvestigation> { }
                    
        public class ChildNursingDayToDayInvestigationCollection : TTObject.TTChildObjectCollection<NursingDayToDayInvestigation>
        {
            public ChildNursingDayToDayInvestigationCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildNursingDayToDayInvestigationCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetByNursingDayToDayInvestigation_Class : TTReportNqlObject 
        {
            public DateTime? ActionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGDAYTODAYINVESTIGATION"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string RrhythmOfPatient
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RRHYTHMOFPATIENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGDAYTODAYINVESTIGATION"].AllPropertyDefs["RRHYTHMOFPATIENT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string PlaceHarshnessTimeOfPain
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PLACEHARSHNESSTIMEOFPAIN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGDAYTODAYINVESTIGATION"].AllPropertyDefs["PLACEHARSHNESSTIMEOFPAIN"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string VentulatorMods
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["VENTULATORMODS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGDAYTODAYINVESTIGATION"].AllPropertyDefs["VENTULATORMODS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string EdemaTracing
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EDEMATRACING"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGDAYTODAYINVESTIGATION"].AllPropertyDefs["EDEMATRACING"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? Ventral
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["VENTRAL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGDAYTODAYINVESTIGATION"].AllPropertyDefs["VENTRAL"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? Crus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CRUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGDAYTODAYINVESTIGATION"].AllPropertyDefs["CRUS"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? Arm
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ARM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGDAYTODAYINVESTIGATION"].AllPropertyDefs["ARM"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? Brains
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BRAINS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGDAYTODAYINVESTIGATION"].AllPropertyDefs["BRAINS"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public GetByNursingDayToDayInvestigation_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetByNursingDayToDayInvestigation_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetByNursingDayToDayInvestigation_Class() : base() { }
        }

        public static BindingList<NursingDayToDayInvestigation.GetByNursingDayToDayInvestigation_Class> GetByNursingDayToDayInvestigation(Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NURSINGDAYTODAYINVESTIGATION"].QueryDefs["GetByNursingDayToDayInvestigation"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<NursingDayToDayInvestigation.GetByNursingDayToDayInvestigation_Class>(queryDef, paramList, pi);
        }

        public static BindingList<NursingDayToDayInvestigation.GetByNursingDayToDayInvestigation_Class> GetByNursingDayToDayInvestigation(TTObjectContext objectContext, Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NURSINGDAYTODAYINVESTIGATION"].QueryDefs["GetByNursingDayToDayInvestigation"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<NursingDayToDayInvestigation.GetByNursingDayToDayInvestigation_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Ödem Takibi
    /// </summary>
        public string EdemaTracing
        {
            get { return (string)this["EDEMATRACING"]; }
            set { this["EDEMATRACING"] = value; }
        }

    /// <summary>
    /// Hastanın Ritmi
    /// </summary>
        public string RrhythmOfPatient
        {
            get { return (string)this["RRHYTHMOFPATIENT"]; }
            set { this["RRHYTHMOFPATIENT"] = value; }
        }

    /// <summary>
    /// Kafa
    /// </summary>
        public int? Brains
        {
            get { return (int?)this["BRAINS"]; }
            set { this["BRAINS"] = value; }
        }

    /// <summary>
    /// Karın
    /// </summary>
        public int? Ventral
        {
            get { return (int?)this["VENTRAL"]; }
            set { this["VENTRAL"] = value; }
        }

    /// <summary>
    /// Ağrının Yeri-Şiddeti-Süresi
    /// </summary>
        public string PlaceHarshnessTimeOfPain
        {
            get { return (string)this["PLACEHARSHNESSTIMEOFPAIN"]; }
            set { this["PLACEHARSHNESSTIMEOFPAIN"] = value; }
        }

    /// <summary>
    /// Ventülatör Modları
    /// </summary>
        public string VentulatorMods
        {
            get { return (string)this["VENTULATORMODS"]; }
            set { this["VENTULATORMODS"] = value; }
        }

    /// <summary>
    /// Kol
    /// </summary>
        public int? Arm
        {
            get { return (int?)this["ARM"]; }
            set { this["ARM"] = value; }
        }

    /// <summary>
    /// Tarih
    /// </summary>
        public DateTime? ActionDate
        {
            get { return (DateTime?)this["ACTIONDATE"]; }
            set { this["ACTIONDATE"] = value; }
        }

    /// <summary>
    /// Bacak
    /// </summary>
        public int? Crus
        {
            get { return (int?)this["CRUS"]; }
            set { this["CRUS"] = value; }
        }

    /// <summary>
    /// Günlük Gözlem
    /// </summary>
        public NursingApplication NursingApplication
        {
            get { return (NursingApplication)((ITTObject)this).GetParent("NURSINGAPPLICATION"); }
            set { this["NURSINGAPPLICATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected NursingDayToDayInvestigation(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected NursingDayToDayInvestigation(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected NursingDayToDayInvestigation(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected NursingDayToDayInvestigation(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected NursingDayToDayInvestigation(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "NURSINGDAYTODAYINVESTIGATION", dataRow) { }
        protected NursingDayToDayInvestigation(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "NURSINGDAYTODAYINVESTIGATION", dataRow, isImported) { }
        public NursingDayToDayInvestigation(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public NursingDayToDayInvestigation(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public NursingDayToDayInvestigation() : base() { }

    }
}
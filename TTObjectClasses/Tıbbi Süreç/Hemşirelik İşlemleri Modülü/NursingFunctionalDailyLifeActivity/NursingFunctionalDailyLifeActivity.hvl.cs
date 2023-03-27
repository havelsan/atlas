
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="NursingFunctionalDailyLifeActivity")] 

    public  partial class NursingFunctionalDailyLifeActivity : TTObject
    {
        public class NursingFunctionalDailyLifeActivityList : TTObjectCollection<NursingFunctionalDailyLifeActivity> { }
                    
        public class ChildNursingFunctionalDailyLifeActivityCollection : TTObject.TTChildObjectCollection<NursingFunctionalDailyLifeActivity>
        {
            public ChildNursingFunctionalDailyLifeActivityCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildNursingFunctionalDailyLifeActivityCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetNursingFDLAListByNursingApp_Class : TTReportNqlObject 
        {
            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DAILYLIFEACTIVITYDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? Date
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGDAILYLIFEACTIVITY"].AllPropertyDefs["APPLICATIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

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

            public NursingDailyLifeActivityEnum? Status
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGFUNCTIONALDAILYLIFEACTIVITY"].AllPropertyDefs["STATUS"].DataType;
                    return (NursingDailyLifeActivityEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string DetailNote
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DETAILNOTE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGFUNCTIONALDAILYLIFEACTIVITY"].AllPropertyDefs["DETAILNOTE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? IsCheck
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISCHECK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGFUNCTIONALDAILYLIFEACTIVITY"].AllPropertyDefs["ISCHECK"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public GetNursingFDLAListByNursingApp_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetNursingFDLAListByNursingApp_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetNursingFDLAListByNursingApp_Class() : base() { }
        }

        public static BindingList<NursingFunctionalDailyLifeActivity> GetNursingFunctionalDailyLifeActivityList(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NURSINGFUNCTIONALDAILYLIFEACTIVITY"].QueryDefs["GetNursingFunctionalDailyLifeActivityList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<NursingFunctionalDailyLifeActivity>(queryDef, paramList);
        }

        public static BindingList<NursingFunctionalDailyLifeActivity.GetNursingFDLAListByNursingApp_Class> GetNursingFDLAListByNursingApp(DateTime STARTDATE, DateTime ENDDATE, Guid NURSINGAPP, Guid DailyLifeActivity, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NURSINGFUNCTIONALDAILYLIFEACTIVITY"].QueryDefs["GetNursingFDLAListByNursingApp"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("NURSINGAPP", NURSINGAPP);
            paramList.Add("DAILYLIFEACTIVITY", DailyLifeActivity);

            return TTReportNqlObject.QueryObjects<NursingFunctionalDailyLifeActivity.GetNursingFDLAListByNursingApp_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<NursingFunctionalDailyLifeActivity.GetNursingFDLAListByNursingApp_Class> GetNursingFDLAListByNursingApp(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, Guid NURSINGAPP, Guid DailyLifeActivity, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NURSINGFUNCTIONALDAILYLIFEACTIVITY"].QueryDefs["GetNursingFDLAListByNursingApp"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("NURSINGAPP", NURSINGAPP);
            paramList.Add("DAILYLIFEACTIVITY", DailyLifeActivity);

            return TTReportNqlObject.QueryObjects<NursingFunctionalDailyLifeActivity.GetNursingFDLAListByNursingApp_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Durumu
    /// </summary>
        public NursingDailyLifeActivityEnum? Status
        {
            get { return (NursingDailyLifeActivityEnum?)(int?)this["STATUS"]; }
            set { this["STATUS"] = value; }
        }

    /// <summary>
    /// Not
    /// </summary>
        public string DetailNote
        {
            get { return (string)this["DETAILNOTE"]; }
            set { this["DETAILNOTE"] = value; }
        }

    /// <summary>
    /// Var mı , Yok mu?
    /// </summary>
        public bool? IsCheck
        {
            get { return (bool?)this["ISCHECK"]; }
            set { this["ISCHECK"] = value; }
        }

        public NursingDailyLifeActivity NursingDailyLifeActivity
        {
            get { return (NursingDailyLifeActivity)((ITTObject)this).GetParent("NURSINGDAILYLIFEACTIVITY"); }
            set { this["NURSINGDAILYLIFEACTIVITY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public DailyLifeActivityDefinition DailyLifeActivity
        {
            get { return (DailyLifeActivityDefinition)((ITTObject)this).GetParent("DAILYLIFEACTIVITY"); }
            set { this["DAILYLIFEACTIVITY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected NursingFunctionalDailyLifeActivity(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected NursingFunctionalDailyLifeActivity(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected NursingFunctionalDailyLifeActivity(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected NursingFunctionalDailyLifeActivity(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected NursingFunctionalDailyLifeActivity(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "NURSINGFUNCTIONALDAILYLIFEACTIVITY", dataRow) { }
        protected NursingFunctionalDailyLifeActivity(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "NURSINGFUNCTIONALDAILYLIFEACTIVITY", dataRow, isImported) { }
        public NursingFunctionalDailyLifeActivity(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public NursingFunctionalDailyLifeActivity(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public NursingFunctionalDailyLifeActivity() : base() { }

    }
}
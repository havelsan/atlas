
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="NursingDailyLifeActivity")] 

    /// <summary>
    /// Hemşire Bakım İzlem Formu
    /// </summary>
    public  partial class NursingDailyLifeActivity : BaseNursingDataEntry
    {
        public class NursingDailyLifeActivityList : TTObjectCollection<NursingDailyLifeActivity> { }
                    
        public class ChildNursingDailyLifeActivityCollection : TTObject.TTChildObjectCollection<NursingDailyLifeActivity>
        {
            public ChildNursingDailyLifeActivityCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildNursingDailyLifeActivityCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetNursingDailyLifeActivity_Class : TTReportNqlObject 
        {
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

            public DateTime? ActionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGDAILYLIFEACTIVITY"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetNursingDailyLifeActivity_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetNursingDailyLifeActivity_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetNursingDailyLifeActivity_Class() : base() { }
        }

        new public static class States
        {
            public static Guid Yeni { get { return new Guid("2f6b2d75-fb0e-43c9-a964-af59bb71f8b9"); } }
    /// <summary>
    /// Yanlış veriyi silmek için
    /// </summary>
            public static Guid Cancelled { get { return new Guid("c9a1ec5b-749a-4cff-9a32-d66e3b0d807b"); } }
        }

        public static BindingList<NursingDailyLifeActivity.GetNursingDailyLifeActivity_Class> GetNursingDailyLifeActivity(Guid NURSINGAPPLICATION, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NURSINGDAILYLIFEACTIVITY"].QueryDefs["GetNursingDailyLifeActivity"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("NURSINGAPPLICATION", NURSINGAPPLICATION);

            return TTReportNqlObject.QueryObjects<NursingDailyLifeActivity.GetNursingDailyLifeActivity_Class>(queryDef, paramList, pi);
        }

        public static BindingList<NursingDailyLifeActivity.GetNursingDailyLifeActivity_Class> GetNursingDailyLifeActivity(TTObjectContext objectContext, Guid NURSINGAPPLICATION, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NURSINGDAILYLIFEACTIVITY"].QueryDefs["GetNursingDailyLifeActivity"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("NURSINGAPPLICATION", NURSINGAPPLICATION);

            return TTReportNqlObject.QueryObjects<NursingDailyLifeActivity.GetNursingDailyLifeActivity_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Genel Not
    /// </summary>
        public string Note
        {
            get { return (string)this["NOTE"]; }
            set { this["NOTE"] = value; }
        }

    /// <summary>
    /// Tarih/Saat
    /// </summary>
        public DateTime? ActionDate
        {
            get { return (DateTime?)this["ACTIONDATE"]; }
            set { this["ACTIONDATE"] = value; }
        }

        virtual protected void CreateNursingFunctionalDailyLifeActivitiesCollection()
        {
            _NursingFunctionalDailyLifeActivities = new NursingFunctionalDailyLifeActivity.ChildNursingFunctionalDailyLifeActivityCollection(this, new Guid("a5410b11-bd3b-4b3c-a1ac-8a6ba2535658"));
            ((ITTChildObjectCollection)_NursingFunctionalDailyLifeActivities).GetChildren();
        }

        protected NursingFunctionalDailyLifeActivity.ChildNursingFunctionalDailyLifeActivityCollection _NursingFunctionalDailyLifeActivities = null;
        public NursingFunctionalDailyLifeActivity.ChildNursingFunctionalDailyLifeActivityCollection NursingFunctionalDailyLifeActivities
        {
            get
            {
                if (_NursingFunctionalDailyLifeActivities == null)
                    CreateNursingFunctionalDailyLifeActivitiesCollection();
                return _NursingFunctionalDailyLifeActivities;
            }
        }

        protected NursingDailyLifeActivity(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected NursingDailyLifeActivity(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected NursingDailyLifeActivity(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected NursingDailyLifeActivity(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected NursingDailyLifeActivity(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "NURSINGDAILYLIFEACTIVITY", dataRow) { }
        protected NursingDailyLifeActivity(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "NURSINGDAILYLIFEACTIVITY", dataRow, isImported) { }
        public NursingDailyLifeActivity(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public NursingDailyLifeActivity(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public NursingDailyLifeActivity() : base() { }

    }
}
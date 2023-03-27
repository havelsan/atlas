
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BaseNursingOrder")] 

    public  partial class BaseNursingOrder : PeriodicOrder
    {
        public class BaseNursingOrderList : TTObjectCollection<BaseNursingOrder> { }
                    
        public class ChildBaseNursingOrderCollection : TTObject.TTChildObjectCollection<BaseNursingOrder>
        {
            public ChildBaseNursingOrderCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBaseNursingOrderCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetNOsByDateForTimeUpdate_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public FrequencyEnum? Frequency
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FREQUENCY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BASENURSINGORDER"].AllPropertyDefs["FREQUENCY"].DataType;
                    return (FrequencyEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public int? AmountForPeriod
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNTFORPERIOD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BASENURSINGORDER"].AllPropertyDefs["AMOUNTFORPERIOD"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? RecurrenceDayAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RECURRENCEDAYAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BASENURSINGORDER"].AllPropertyDefs["RECURRENCEDAYAMOUNT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public DateTime? PeriodStartTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PERIODSTARTTIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BASENURSINGORDER"].AllPropertyDefs["PERIODSTARTTIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public String DisplayText
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISPLAYTEXT"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public Guid? CurrentStateDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENTSTATEDEFID"]);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["VITALSIGNANDNURSINGDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetNOsByDateForTimeUpdate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetNOsByDateForTimeUpdate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetNOsByDateForTimeUpdate_Class() : base() { }
        }

        public static BindingList<BaseNursingOrder.GetNOsByDateForTimeUpdate_Class> GetNOsByDateForTimeUpdate(Guid EPISODE, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASENURSINGORDER"].QueryDefs["GetNOsByDateForTimeUpdate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<BaseNursingOrder.GetNOsByDateForTimeUpdate_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<BaseNursingOrder.GetNOsByDateForTimeUpdate_Class> GetNOsByDateForTimeUpdate(TTObjectContext objectContext, Guid EPISODE, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASENURSINGORDER"].QueryDefs["GetNOsByDateForTimeUpdate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<BaseNursingOrder.GetNOsByDateForTimeUpdate_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        protected BaseNursingOrder(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BaseNursingOrder(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BaseNursingOrder(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BaseNursingOrder(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BaseNursingOrder(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BASENURSINGORDER", dataRow) { }
        protected BaseNursingOrder(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BASENURSINGORDER", dataRow, isImported) { }
        public BaseNursingOrder(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BaseNursingOrder(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BaseNursingOrder() : base() { }

    }
}
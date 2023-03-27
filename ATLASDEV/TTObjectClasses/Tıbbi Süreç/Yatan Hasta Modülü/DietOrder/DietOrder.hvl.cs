
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DietOrder")] 

    /// <summary>
    /// Yatan Hasta Diyet Order
    /// </summary>
    public  partial class DietOrder : BaseDietOrder
    {
        public class DietOrderList : TTObjectCollection<DietOrder> { }
                    
        public class ChildDietOrderCollection : TTObject.TTChildObjectCollection<DietOrder>
        {
            public ChildDietOrderCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDietOrderCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetDietDirectives_Class : TTReportNqlObject 
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

            public DateTime? ActionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIETORDER"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string ReasonOfCancel
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REASONOFCANCEL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIETORDER"].AllPropertyDefs["REASONOFCANCEL"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? Active
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIVE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIETORDER"].AllPropertyDefs["ACTIVE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DateTime? WorkListDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WORKLISTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIETORDER"].AllPropertyDefs["WORKLISTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public object ReasonOfReject
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REASONOFREJECT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIETORDER"].AllPropertyDefs["REASONOFREJECT"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIETORDER"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? OlapLastUpdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLAPLASTUPDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIETORDER"].AllPropertyDefs["OLAPLASTUPDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? OlapDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLAPDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIETORDER"].AllPropertyDefs["OLAPDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? ClonedObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CLONEDOBJECTID"]);
                }
            }

            public string WorkListDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WORKLISTDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIETORDER"].AllPropertyDefs["WORKLISTDESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? IsOldAction
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISOLDACTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIETORDER"].AllPropertyDefs["ISOLDACTION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DateTime? RequestDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIETORDER"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? Emergency
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EMERGENCY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIETORDER"].AllPropertyDefs["EMERGENCY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? PatientPay
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTPAY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIETORDER"].AllPropertyDefs["PATIENTPAY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string OrderObject
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDEROBJECT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIETORDER"].AllPropertyDefs["ORDEROBJECT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string DescriptionForWorkList
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTIONFORWORKLIST"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIETORDER"].AllPropertyDefs["DESCRIPTIONFORWORKLIST"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? IgnoreEpisodeStateOnUpdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["IGNOREEPISODESTATEONUPDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIETORDER"].AllPropertyDefs["IGNOREEPISODESTATEONUPDATE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public long? AdmissionQueueNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADMISSIONQUEUENUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIETORDER"].AllPropertyDefs["ADMISSIONQUEUENUMBER"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public FrequencyEnum? Frequency
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FREQUENCY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIETORDER"].AllPropertyDefs["FREQUENCY"].DataType;
                    return (FrequencyEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public double? Weight
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WEIGHT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIETORDER"].AllPropertyDefs["WEIGHT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public int? RecurrenceDayAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RECURRENCEDAYAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIETORDER"].AllPropertyDefs["RECURRENCEDAYAMOUNT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? AmountForPeriod
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNTFORPERIOD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIETORDER"].AllPropertyDefs["AMOUNTFORPERIOD"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIETORDER"].AllPropertyDefs["PERIODSTARTTIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public double? Heigth
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HEIGTH"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIETORDER"].AllPropertyDefs["HEIGTH"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public DateTime? OrderDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDERDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIETORDER"].AllPropertyDefs["ORDERDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string OrderDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDERDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIETORDER"].AllPropertyDefs["ORDERDESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? PeriodEndTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PERIODENDTIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIETORDER"].AllPropertyDefs["PERIODENDTIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetDietDirectives_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDietDirectives_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDietDirectives_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDietMaterials_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string MaterialName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIETMATERIALDEFINITION"].AllPropertyDefs["MATERIALNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetDietMaterials_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDietMaterials_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDietMaterials_Class() : base() { }
        }

        [Serializable] 

        public partial class GetTotalCaloriByOrder_Class : TTReportNqlObject 
        {
            public Object Nqlcolumn
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["NQLCOLUMN"]);
                }
            }

            public GetTotalCaloriByOrder_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetTotalCaloriByOrder_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetTotalCaloriByOrder_Class() : base() { }
        }

        public static class States
        {
            public static Guid Cancelled { get { return new Guid("fa87b33b-267e-45a1-bfdb-345ea3478f77"); } }
            public static Guid Planned { get { return new Guid("e8466bb5-62a3-49ee-81ab-a0e4112ccd53"); } }
        }

        public static BindingList<DietOrder.GetDietDirectives_Class> GetDietDirectives(Guid episodeActionId, int MONTH, int YEAR, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIETORDER"].QueryDefs["GetDietDirectives"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODEACTIONID", episodeActionId);
            paramList.Add("MONTH", MONTH);
            paramList.Add("YEAR", YEAR);

            return TTReportNqlObject.QueryObjects<DietOrder.GetDietDirectives_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DietOrder.GetDietDirectives_Class> GetDietDirectives(TTObjectContext objectContext, Guid episodeActionId, int MONTH, int YEAR, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIETORDER"].QueryDefs["GetDietDirectives"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODEACTIONID", episodeActionId);
            paramList.Add("MONTH", MONTH);
            paramList.Add("YEAR", YEAR);

            return TTReportNqlObject.QueryObjects<DietOrder.GetDietDirectives_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DietOrder.GetDietMaterials_Class> GetDietMaterials(Guid EPISODE, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIETORDER"].QueryDefs["GetDietMaterials"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<DietOrder.GetDietMaterials_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DietOrder.GetDietMaterials_Class> GetDietMaterials(TTObjectContext objectContext, Guid EPISODE, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIETORDER"].QueryDefs["GetDietMaterials"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<DietOrder.GetDietMaterials_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DietOrder.GetTotalCaloriByOrder_Class> GetTotalCaloriByOrder(Guid OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIETORDER"].QueryDefs["GetTotalCaloriByOrder"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<DietOrder.GetTotalCaloriByOrder_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DietOrder.GetTotalCaloriByOrder_Class> GetTotalCaloriByOrder(TTObjectContext objectContext, Guid OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIETORDER"].QueryDefs["GetTotalCaloriByOrder"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<DietOrder.GetTotalCaloriByOrder_Class>(objectContext, queryDef, paramList, pi);
        }

        public InPatientPhysicianApplication InpatientPhysicianApplication
        {
            get { return (InPatientPhysicianApplication)((ITTObject)this).GetParent("INPATIENTPHYSICIANAPPLICATION"); }
            set { this["INPATIENTPHYSICIANAPPLICATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        override protected void CreateOrderDetailsCollection()
        {
            _OrderDetails = new PeriodicOrderDetail.ChildPeriodicOrderDetailCollection(this, new Guid("ba77d571-b53d-4c12-8594-edfe74d7645b"));
            CreateOrderDetailsCollectionViews();
            ((ITTChildObjectCollection)_OrderDetails).GetChildren();
        }

        protected DietOrder(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DietOrder(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DietOrder(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DietOrder(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DietOrder(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DIETORDER", dataRow) { }
        protected DietOrder(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DIETORDER", dataRow, isImported) { }
        public DietOrder(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DietOrder(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DietOrder() : base() { }

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
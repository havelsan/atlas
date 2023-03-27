
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="CMRAction")] 

    /// <summary>
    /// Tıbbi Cihaz İşlemleri Ana Sınıfı
    /// </summary>
    public  partial class CMRAction : BaseAction, ICMRActionWorkList
    {
        public class CMRActionList : TTObjectCollection<CMRAction> { }
                    
        public class ChildCMRActionCollection : TTObject.TTChildObjectCollection<CMRAction>
        {
            public ChildCMRActionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildCMRActionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetCMRRegistrationReportQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string NATOStockNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NATOSTOCKNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["NATOSTOCKNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Materialname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Sendersection
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SENDERSECTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Deliverer
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DELIVERER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Receiver
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RECEIVER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Section
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SECTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESDIVISIONSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? StartDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STARTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CMRACTION"].AllPropertyDefs["STARTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? EndDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ENDDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CMRACTION"].AllPropertyDefs["ENDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetCMRRegistrationReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetCMRRegistrationReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetCMRRegistrationReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetCMRActionQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Ownermilitaryunit
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OWNERMILITARYUNIT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MILITARYUNIT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string RequestNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CMRACTION"].AllPropertyDefs["REQUESTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string NATOStockNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NATOSTOCKNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["NATOSTOCKNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Fixedassetname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FIXEDASSETNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Mark
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MARK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].AllPropertyDefs["MARK"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string SerialNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SERIALNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].AllPropertyDefs["SERIALNUMBER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Model
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MODEL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].AllPropertyDefs["MODEL"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? ProductionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRODUCTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].AllPropertyDefs["PRODUCTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string DistributionType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISTRIBUTIONTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONTYPEDEFINITION"].AllPropertyDefs["DISTRIBUTIONTYPE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetCMRActionQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetCMRActionQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetCMRActionQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetRequestCMRActionQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? RequestCMRAction
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["REQUESTCMRACTION"]);
                }
            }

            public GetRequestCMRActionQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetRequestCMRActionQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetRequestCMRActionQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetCMRActionsCount_Class : TTReportNqlObject 
        {
            public Guid? ObjectDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTDEFID"]);
                }
            }

            public String ObjectDefName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OBJECTDEFNAME"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public Object Sayi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["SAYI"]);
                }
            }

            public GetCMRActionsCount_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetCMRActionsCount_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetCMRActionsCount_Class() : base() { }
        }

        [Serializable] 

        public partial class GetFailureRateRQ_Class : TTReportNqlObject 
        {
            public string Service
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SERVICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Serviceobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SERVICEOBJECTID"]);
                }
            }

            public GetFailureRateRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetFailureRateRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetFailureRateRQ_Class() : base() { }
        }

        [Serializable] 

        public partial class GetStockInheld_Class : TTReportNqlObject 
        {
            public Object Depomevcudu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["DEPOMEVCUDU"]);
                }
            }

            public GetStockInheld_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetStockInheld_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetStockInheld_Class() : base() { }
        }

        public static class States
        {
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancelled { get { return new Guid("2fc444f5-84d4-4e92-b1f8-1c874810da67"); } }
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("3a90cf0a-6b15-49f1-bd63-cf632b31e655"); } }
    /// <summary>
    /// Tamam
    /// </summary>
            public static Guid Completed { get { return new Guid("012125b5-dd40-4e10-99ad-dfcea71b374a"); } }
        }

        public static BindingList<CMRAction> CMRActionWorkListNQL(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CMRACTION"].QueryDefs["CMRActionWorkListNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<CMRAction>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<CMRAction.GetCMRRegistrationReportQuery_Class> GetCMRRegistrationReportQuery(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CMRACTION"].QueryDefs["GetCMRRegistrationReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<CMRAction.GetCMRRegistrationReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<CMRAction.GetCMRRegistrationReportQuery_Class> GetCMRRegistrationReportQuery(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CMRACTION"].QueryDefs["GetCMRRegistrationReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<CMRAction.GetCMRRegistrationReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<CMRAction.GetCMRActionQuery_Class> GetCMRActionQuery(Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CMRACTION"].QueryDefs["GetCMRActionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<CMRAction.GetCMRActionQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<CMRAction.GetCMRActionQuery_Class> GetCMRActionQuery(TTObjectContext objectContext, Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CMRACTION"].QueryDefs["GetCMRActionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<CMRAction.GetCMRActionQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<CMRAction.GetRequestCMRActionQuery_Class> GetRequestCMRActionQuery(Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CMRACTION"].QueryDefs["GetRequestCMRActionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<CMRAction.GetRequestCMRActionQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<CMRAction.GetRequestCMRActionQuery_Class> GetRequestCMRActionQuery(TTObjectContext objectContext, Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CMRACTION"].QueryDefs["GetRequestCMRActionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<CMRAction.GetRequestCMRActionQuery_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// İşlem Sayıları
    /// </summary>
        public static BindingList<CMRAction.GetCMRActionsCount_Class> GetCMRActionsCount(DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CMRACTION"].QueryDefs["GetCMRActionsCount"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<CMRAction.GetCMRActionsCount_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// İşlem Sayıları
    /// </summary>
        public static BindingList<CMRAction.GetCMRActionsCount_Class> GetCMRActionsCount(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CMRACTION"].QueryDefs["GetCMRActionsCount"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<CMRAction.GetCMRActionsCount_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<CMRAction> ActiveCMRActionNQL(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CMRACTION"].QueryDefs["ActiveCMRActionNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<CMRAction>(queryDef, paramList);
        }

        public static BindingList<CMRAction> ActiveCMRActionByRespUser(TTObjectContext objectContext, Guid RESUSER)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CMRACTION"].QueryDefs["ActiveCMRActionByRespUser"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("RESUSER", RESUSER);

            return ((ITTQuery)objectContext).QueryObjects<CMRAction>(queryDef, paramList);
        }

        public static BindingList<CMRAction> FailureRateReportOQ(TTObjectContext objectContext, DateTime ENDDATE, DateTime STARTDATE, Guid SENDERSECTION)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CMRACTION"].QueryDefs["FailureRateReportOQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("SENDERSECTION", SENDERSECTION);

            return ((ITTQuery)objectContext).QueryObjects<CMRAction>(queryDef, paramList);
        }

        public static BindingList<CMRAction> FailureRateReportOQ2(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, Guid SENDERSECTION)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CMRACTION"].QueryDefs["FailureRateReportOQ2"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("SENDERSECTION", SENDERSECTION);

            return ((ITTQuery)objectContext).QueryObjects<CMRAction>(queryDef, paramList);
        }

        public static BindingList<CMRAction> GetCMRActionByRequestNo(TTObjectContext objectContext, string REQUESTNO)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CMRACTION"].QueryDefs["GetCMRActionByRequestNo"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("REQUESTNO", REQUESTNO);

            return ((ITTQuery)objectContext).QueryObjects<CMRAction>(queryDef, paramList);
        }

        public static BindingList<CMRAction> FailureRateReportOQ3(TTObjectContext objectContext, DateTime ENDDATE, Guid SENDERSECTION, DateTime STARTDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CMRACTION"].QueryDefs["FailureRateReportOQ3"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("SENDERSECTION", SENDERSECTION);
            paramList.Add("STARTDATE", STARTDATE);

            return ((ITTQuery)objectContext).QueryObjects<CMRAction>(queryDef, paramList);
        }

        public static BindingList<CMRAction.GetFailureRateRQ_Class> GetFailureRateRQ(DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CMRACTION"].QueryDefs["GetFailureRateRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<CMRAction.GetFailureRateRQ_Class>(queryDef, paramList, pi);
        }

        public static BindingList<CMRAction.GetFailureRateRQ_Class> GetFailureRateRQ(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CMRACTION"].QueryDefs["GetFailureRateRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<CMRAction.GetFailureRateRQ_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<CMRAction> CMRActionWorkListNQLNoDate(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CMRACTION"].QueryDefs["CMRActionWorkListNQLNoDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<CMRAction>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<CMRAction.GetStockInheld_Class> GetStockInheld(Guid SENDERSECTION, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CMRACTION"].QueryDefs["GetStockInheld"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SENDERSECTION", SENDERSECTION);

            return TTReportNqlObject.QueryObjects<CMRAction.GetStockInheld_Class>(queryDef, paramList, pi);
        }

        public static BindingList<CMRAction.GetStockInheld_Class> GetStockInheld(TTObjectContext objectContext, Guid SENDERSECTION, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CMRACTION"].QueryDefs["GetStockInheld"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SENDERSECTION", SENDERSECTION);

            return TTReportNqlObject.QueryObjects<CMRAction.GetStockInheld_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<CMRAction> GetByFixedAssetMaterialDef(TTObjectContext objectContext, Guid FIXEDASSETMATERIALDEFOBJID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CMRACTION"].QueryDefs["GetByFixedAssetMaterialDef"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIXEDASSETMATERIALDEFOBJID", FIXEDASSETMATERIALDEFOBJID);

            return ((ITTQuery)objectContext).QueryObjects<CMRAction>(queryDef, paramList);
        }

    /// <summary>
    /// Sonuç
    /// </summary>
        public string Result
        {
            get { return (string)this["RESULT"]; }
            set { this["RESULT"] = value; }
        }

    /// <summary>
    /// Başlangıç Tarihi
    /// </summary>
        public DateTime? StartDate
        {
            get { return (DateTime?)this["STARTDATE"]; }
            set { this["STARTDATE"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

    /// <summary>
    /// Bitiş Tarihi
    /// </summary>
        public DateTime? EndDate
        {
            get { return (DateTime?)this["ENDDATE"]; }
            set { this["ENDDATE"] = value; }
        }

        public string RequestNo
        {
            get { return (string)this["REQUESTNO"]; }
            set { this["REQUESTNO"] = value; }
        }

        public TTSequence RequestNoSeq
        {
            get { return GetSequence("REQUESTNOSEQ"); }
        }

    /// <summary>
    /// Kademe
    /// </summary>
        public StageDefinition Stage
        {
            get { return (StageDefinition)((ITTObject)this).GetParent("STAGE"); }
            set { this["STAGE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Accountancy SenderAccountancy
        {
            get { return (Accountancy)((ITTObject)this).GetParent("SENDERACCOUNTANCY"); }
            set { this["SENDERACCOUNTANCY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Görevli Teknisyen
    /// </summary>
        public WorkShopUserDefinition ResponsibleWorkShopUser
        {
            get { return (WorkShopUserDefinition)((ITTObject)this).GetParent("RESPONSIBLEWORKSHOPUSER"); }
            set { this["RESPONSIBLEWORKSHOPUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Cihazın Bulunduğu Birlik
    /// </summary>
        public MilitaryUnit OwnerMilitaryUnit
        {
            get { return (MilitaryUnit)((ITTObject)this).GetParent("OWNERMILITARYUNIT"); }
            set { this["OWNERMILITARYUNIT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Demand Demand
        {
            get { return (Demand)((ITTObject)this).GetParent("DEMAND"); }
            set { this["DEMAND"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Atelye
    /// </summary>
        public ResDivisionSubSection WorkShop
        {
            get { return (ResDivisionSubSection)((ITTObject)this).GetParent("WORKSHOP"); }
            set { this["WORKSHOP"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Sorumlu Teknisyen
    /// </summary>
        public ResUser ResponsibleUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("RESPONSIBLEUSER"); }
            set { this["RESPONSIBLEUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Kısım
    /// </summary>
        public ResDivisionSection Section
        {
            get { return (ResDivisionSection)((ITTObject)this).GetParent("SECTION"); }
            set { this["SECTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Teslim Tesellüm - Teslim Eden Personel
    /// </summary>
        public ResUser DelivererUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("DELIVERERUSER"); }
            set { this["DELIVERERUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public CMRAction RequestCMRAction
        {
            get { return (CMRAction)((ITTObject)this).GetParent("REQUESTCMRACTION"); }
            set { this["REQUESTCMRACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Gönderen Kısım
    /// </summary>
        public ResSection SenderSection
        {
            get { return (ResSection)((ITTObject)this).GetParent("SENDERSECTION"); }
            set { this["SENDERSECTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ResDivision ResDivision
        {
            get { return (ResDivision)((ITTObject)this).GetParent("RESDIVISION"); }
            set { this["RESDIVISION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Cihaz/Malzeme
    /// </summary>
        public FixedAssetMaterialDefinition FixedAssetMaterialDefinition
        {
            get { return (FixedAssetMaterialDefinition)((ITTObject)this).GetParent("FIXEDASSETMATERIALDEFINITION"); }
            set { this["FIXEDASSETMATERIALDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public PurchaseItemDef PurchaseItemDef
        {
            get { return (PurchaseItemDef)((ITTObject)this).GetParent("PURCHASEITEMDEF"); }
            set { this["PURCHASEITEMDEF"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Cihazın Kullanıcısı
    /// </summary>
        public ResUser DeviceUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("DEVICEUSER"); }
            set { this["DEVICEUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateForkCMRActionCollection()
        {
            _ForkCMRAction = new CMRAction.ChildCMRActionCollection(this, new Guid("431ba2e1-4e32-411e-a033-d4d7b653ed5e"));
            ((ITTChildObjectCollection)_ForkCMRAction).GetChildren();
        }

        protected CMRAction.ChildCMRActionCollection _ForkCMRAction = null;
        public CMRAction.ChildCMRActionCollection ForkCMRAction
        {
            get
            {
                if (_ForkCMRAction == null)
                    CreateForkCMRActionCollection();
                return _ForkCMRAction;
            }
        }

        virtual protected void CreateUserMaintenancesCollection()
        {
            _UserMaintenances = new UserMaintenance.ChildUserMaintenanceCollection(this, new Guid("feefc16c-1b67-4f3c-9fe4-28e99d38ed2a"));
            ((ITTChildObjectCollection)_UserMaintenances).GetChildren();
        }

        protected UserMaintenance.ChildUserMaintenanceCollection _UserMaintenances = null;
    /// <summary>
    /// Child collection for Cihazın kullanıcı seviyesi bakım parametresi
    /// </summary>
        public UserMaintenance.ChildUserMaintenanceCollection UserMaintenances
        {
            get
            {
                if (_UserMaintenances == null)
                    CreateUserMaintenancesCollection();
                return _UserMaintenances;
            }
        }

        virtual protected void CreateSectionRequirementsCollection()
        {
            _SectionRequirements = new SectionRequirement.ChildSectionRequirementCollection(this, new Guid("c89d99ee-ee28-45c9-982e-43a86073846d"));
            ((ITTChildObjectCollection)_SectionRequirements).GetChildren();
        }

        protected SectionRequirement.ChildSectionRequirementCollection _SectionRequirements = null;
        public SectionRequirement.ChildSectionRequirementCollection SectionRequirements
        {
            get
            {
                if (_SectionRequirements == null)
                    CreateSectionRequirementsCollection();
                return _SectionRequirements;
            }
        }

        virtual protected void CreateUnitMaintenancesCollection()
        {
            _UnitMaintenances = new UnitMaintenance.ChildUnitMaintenanceCollection(this, new Guid("21da2a30-f674-425d-ab19-502e11120eb8"));
            ((ITTChildObjectCollection)_UnitMaintenances).GetChildren();
        }

        protected UnitMaintenance.ChildUnitMaintenanceCollection _UnitMaintenances = null;
    /// <summary>
    /// Child collection for Cihazin birlik seviyesi bakım parametresi
    /// </summary>
        public UnitMaintenance.ChildUnitMaintenanceCollection UnitMaintenances
        {
            get
            {
                if (_UnitMaintenances == null)
                    CreateUnitMaintenancesCollection();
                return _UnitMaintenances;
            }
        }

        protected CMRAction(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected CMRAction(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected CMRAction(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected CMRAction(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected CMRAction(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "CMRACTION", dataRow) { }
        protected CMRAction(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "CMRACTION", dataRow, isImported) { }
        public CMRAction(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public CMRAction(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public CMRAction() : base() { }

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
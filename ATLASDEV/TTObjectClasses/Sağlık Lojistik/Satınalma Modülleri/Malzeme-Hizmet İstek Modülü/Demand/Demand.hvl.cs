
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="Demand")] 

    /// <summary>
    /// Malzeme/Hizmet İstek modülü için ana sınıftır
    /// </summary>
    public  partial class Demand : BasePurchaseAction, IDemandWorkList
    {
        public class DemandList : TTObjectCollection<Demand> { }
                    
        public class ChildDemandCollection : TTObject.TTChildObjectCollection<Demand>
        {
            public ChildDemandCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDemandCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class SatınalmaIstek_DemandQuery_Class : TTReportNqlObject 
        {
            public DateTime? DemandDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DEMANDDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DEMAND"].AllPropertyDefs["DEMANDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DemandTypeEnum? DemandType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DEMANDTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DEMAND"].AllPropertyDefs["DEMANDTYPE"].DataType;
                    return (DemandTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DEMAND"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? RequestNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DEMAND"].AllPropertyDefs["REQUESTNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Masterresource
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MASTERRESOURCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public SatınalmaIstek_DemandQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public SatınalmaIstek_DemandQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected SatınalmaIstek_DemandQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPurchaseDecisionReportQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public long? PurchaseProjectNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PURCHASEPROJECTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].AllPropertyDefs["PURCHASEPROJECTNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public long? RequestNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DEMAND"].AllPropertyDefs["REQUESTNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DEMAND"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Masterresource
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MASTERRESOURCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ConfirmNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CONFIRMNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].AllPropertyDefs["CONFIRMNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? ConfirmDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CONFIRMDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].AllPropertyDefs["CONFIRMDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string ItemName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ITEMNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEITEMDEF"].AllPropertyDefs["ITEMNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Currency? RequestAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DEMANDDETAIL"].AllPropertyDefs["REQUESTAMOUNT"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Currency? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DEMANDDETAIL"].AllPropertyDefs["AMOUNT"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public GetPurchaseDecisionReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPurchaseDecisionReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPurchaseDecisionReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetAccountancyDemandEvaluationReportQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public long? RequestNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DEMAND"].AllPropertyDefs["REQUESTNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? DemandDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DEMANDDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DEMAND"].AllPropertyDefs["DEMANDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DemandTypeEnum? DemandType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DEMANDTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DEMAND"].AllPropertyDefs["DEMANDTYPE"].DataType;
                    return (DemandTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public long? PurchaseProjectNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PURCHASEPROJECTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].AllPropertyDefs["PURCHASEPROJECTNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Masterresource
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MASTERRESOURCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Accountancy
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACCOUNTANCY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTANCY"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ItemName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ITEMNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEITEMDEF"].AllPropertyDefs["ITEMNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Currency? RequestAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DEMANDDETAIL"].AllPropertyDefs["REQUESTAMOUNT"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Currency? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DEMANDDETAIL"].AllPropertyDefs["AMOUNT"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public string Typename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TYPENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONTYPEDEFINITION"].AllPropertyDefs["DISTRIBUTIONTYPE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetAccountancyDemandEvaluationReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetAccountancyDemandEvaluationReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetAccountancyDemandEvaluationReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDemandTechCommissionQuery_Class : TTReportNqlObject 
        {
            public CommisionMemberDutyEnum? Comfunc
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["COMFUNC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TECHNICALMEMBER"].AllPropertyDefs["MEMBERDUTY"].DataType;
                    return (CommisionMemberDutyEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Rank
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RANK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RANKDEFINITIONS"].AllPropertyDefs["SHORTNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Namesurname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAMESURNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public UserTitleEnum? Hospfunc
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HOSPFUNC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["TITLE"].DataType;
                    return (UserTitleEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public GetDemandTechCommissionQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDemandTechCommissionQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDemandTechCommissionQuery_Class() : base() { }
        }

        public static class States
        {
    /// <summary>
    /// Belge Kayıt
    /// </summary>
            public static Guid New { get { return new Guid("d6833df6-7bdb-4a4e-b0f9-133ea695cbfe"); } }
    /// <summary>
    /// Tamam
    /// </summary>
            public static Guid Completed { get { return new Guid("870f1088-24a1-4e42-abb9-7ac3e888b949"); } }
            public static Guid AccountancyApproval { get { return new Guid("4734ced4-4128-41f6-bf89-eefb2785d279"); } }
    /// <summary>
    /// Amir Onayına
    /// </summary>
            public static Guid Approval { get { return new Guid("305c10bb-77fb-4456-b356-ef81c6b827b0"); } }
    /// <summary>
    /// Red
    /// </summary>
            public static Guid Rejected { get { return new Guid("79b07199-e3b7-4fc3-9daa-daf63b6b4d08"); } }
    /// <summary>
    /// Lojistik Şube Onay
    /// </summary>
            public static Guid LogisticDepartmentApproval { get { return new Guid("5a2e7a0f-362f-4a06-8cf4-a6c7a388ef13"); } }
        }

        public static BindingList<Demand.SatınalmaIstek_DemandQuery_Class> SatınalmaIstek_DemandQuery(string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DEMAND"].QueryDefs["SatınalmaIstek_DemandQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<Demand.SatınalmaIstek_DemandQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Demand.SatınalmaIstek_DemandQuery_Class> SatınalmaIstek_DemandQuery(TTObjectContext objectContext, string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DEMAND"].QueryDefs["SatınalmaIstek_DemandQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<Demand.SatınalmaIstek_DemandQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Demand> GetAvailableDemands(TTObjectContext objectContext, IList<DemandTypeEnum> DEMANDTYPE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DEMAND"].QueryDefs["GetAvailableDemands"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DEMANDTYPE", Globals.EnumListToIntList((IList)DEMANDTYPE));

            return ((ITTQuery)objectContext).QueryObjects<Demand>(queryDef, paramList);
        }

        public static BindingList<Demand> WorkListNQL(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DEMAND"].QueryDefs["WorkListNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<Demand>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<Demand.GetPurchaseDecisionReportQuery_Class> GetPurchaseDecisionReportQuery(Guid PROJECTNO, long REQUESTNO, Guid MASTERID, Guid MATERIALID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DEMAND"].QueryDefs["GetPurchaseDecisionReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PROJECTNO", PROJECTNO);
            paramList.Add("REQUESTNO", REQUESTNO);
            paramList.Add("MASTERID", MASTERID);
            paramList.Add("MATERIALID", MATERIALID);

            return TTReportNqlObject.QueryObjects<Demand.GetPurchaseDecisionReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Demand.GetPurchaseDecisionReportQuery_Class> GetPurchaseDecisionReportQuery(TTObjectContext objectContext, Guid PROJECTNO, long REQUESTNO, Guid MASTERID, Guid MATERIALID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DEMAND"].QueryDefs["GetPurchaseDecisionReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PROJECTNO", PROJECTNO);
            paramList.Add("REQUESTNO", REQUESTNO);
            paramList.Add("MASTERID", MASTERID);
            paramList.Add("MATERIALID", MATERIALID);

            return TTReportNqlObject.QueryObjects<Demand.GetPurchaseDecisionReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Demand.GetAccountancyDemandEvaluationReportQuery_Class> GetAccountancyDemandEvaluationReportQuery(long REQUESTNO, Guid PROJECTNO, Guid MASTERID, Guid MATERIALID, DemandTypeEnum DEMANDTYPE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DEMAND"].QueryDefs["GetAccountancyDemandEvaluationReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("REQUESTNO", REQUESTNO);
            paramList.Add("PROJECTNO", PROJECTNO);
            paramList.Add("MASTERID", MASTERID);
            paramList.Add("MATERIALID", MATERIALID);
            paramList.Add("DEMANDTYPE", (int)DEMANDTYPE);

            return TTReportNqlObject.QueryObjects<Demand.GetAccountancyDemandEvaluationReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Demand.GetAccountancyDemandEvaluationReportQuery_Class> GetAccountancyDemandEvaluationReportQuery(TTObjectContext objectContext, long REQUESTNO, Guid PROJECTNO, Guid MASTERID, Guid MATERIALID, DemandTypeEnum DEMANDTYPE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DEMAND"].QueryDefs["GetAccountancyDemandEvaluationReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("REQUESTNO", REQUESTNO);
            paramList.Add("PROJECTNO", PROJECTNO);
            paramList.Add("MASTERID", MASTERID);
            paramList.Add("MATERIALID", MATERIALID);
            paramList.Add("DEMANDTYPE", (int)DEMANDTYPE);

            return TTReportNqlObject.QueryObjects<Demand.GetAccountancyDemandEvaluationReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Demand.GetDemandTechCommissionQuery_Class> GetDemandTechCommissionQuery(string TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DEMAND"].QueryDefs["GetDemandTechCommissionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<Demand.GetDemandTechCommissionQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Demand.GetDemandTechCommissionQuery_Class> GetDemandTechCommissionQuery(TTObjectContext objectContext, string TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DEMAND"].QueryDefs["GetDemandTechCommissionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<Demand.GetDemandTechCommissionQuery_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// İstek Tarihi
    /// </summary>
        public DateTime? DemandDate
        {
            get { return (DateTime?)this["DEMANDDATE"]; }
            set { this["DEMANDDATE"] = value; }
        }

    /// <summary>
    /// İstek No
    /// </summary>
        public TTSequence RequestNo
        {
            get { return GetSequence("REQUESTNO"); }
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
    /// İBF Yılı
    /// </summary>
        public int? IBFYear
        {
            get { return (int?)this["IBFYEAR"]; }
            set { this["IBFYEAR"] = value; }
        }

    /// <summary>
    /// Saymanlık Onayından Geçti
    /// </summary>
        public bool? PassedFromAccountancy
        {
            get { return (bool?)this["PASSEDFROMACCOUNTANCY"]; }
            set { this["PASSEDFROMACCOUNTANCY"] = value; }
        }

    /// <summary>
    /// Alım Türü
    /// </summary>
        public DemandTypeEnum? DemandType
        {
            get { return (DemandTypeEnum?)(int?)this["DEMANDTYPE"]; }
            set { this["DEMANDTYPE"] = value; }
        }

    /// <summary>
    /// İBF Türü
    /// </summary>
        public IBFTypeEnum? IBFType
        {
            get { return (IBFTypeEnum?)(int?)this["IBFTYPE"]; }
            set { this["IBFTYPE"] = value; }
        }

        virtual protected void CreateTransferForDemandsCollection()
        {
            _TransferForDemands = new TransferForDemand.ChildTransferForDemandCollection(this, new Guid("2293bb38-0328-480b-9b2a-ca71c6ed61e8"));
            ((ITTChildObjectCollection)_TransferForDemands).GetChildren();
        }

        protected TransferForDemand.ChildTransferForDemandCollection _TransferForDemands = null;
        public TransferForDemand.ChildTransferForDemandCollection TransferForDemands
        {
            get
            {
                if (_TransferForDemands == null)
                    CreateTransferForDemandsCollection();
                return _TransferForDemands;
            }
        }

        virtual protected void CreateDemandDetailsCollection()
        {
            _DemandDetails = new DemandDetail.ChildDemandDetailCollection(this, new Guid("fbfaee3a-ecb1-4097-af5f-765c751fd697"));
            ((ITTChildObjectCollection)_DemandDetails).GetChildren();
        }

        protected DemandDetail.ChildDemandDetailCollection _DemandDetails = null;
        public DemandDetail.ChildDemandDetailCollection DemandDetails
        {
            get
            {
                if (_DemandDetails == null)
                    CreateDemandDetailsCollection();
                return _DemandDetails;
            }
        }

        virtual protected void CreateMemberCollection()
        {
            _Member = new TechnicalMember.ChildTechnicalMemberCollection(this, new Guid("ffdee247-4e13-4b08-a65d-5b93c54dc333"));
            ((ITTChildObjectCollection)_Member).GetChildren();
        }

        protected TechnicalMember.ChildTechnicalMemberCollection _Member = null;
        public TechnicalMember.ChildTechnicalMemberCollection Member
        {
            get
            {
                if (_Member == null)
                    CreateMemberCollection();
                return _Member;
            }
        }

        protected Demand(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected Demand(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected Demand(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected Demand(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected Demand(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DEMAND", dataRow) { }
        protected Demand(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DEMAND", dataRow, isImported) { }
        public Demand(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public Demand(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public Demand() : base() { }

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
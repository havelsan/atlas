
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PurchaseProjectProposalFirm")] 

    /// <summary>
    /// Mahalli Satınalmada PurchaseProject Sınıfı İçin Proposal Sınıfını Barındıran Sınıftır.
    /// </summary>
    public  partial class PurchaseProjectProposalFirm : TTObject
    {
        public class PurchaseProjectProposalFirmList : TTObjectCollection<PurchaseProjectProposalFirm> { }
                    
        public class ChildPurchaseProjectProposalFirmCollection : TTObject.TTChildObjectCollection<PurchaseProjectProposalFirm>
        {
            public ChildPurchaseProjectProposalFirmCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPurchaseProjectProposalFirmCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetDocumentNamesForFirmsBySupplierIDQuery_Class : TTReportNqlObject 
        {
            public bool? Approved
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["APPROVED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASINGDOCUMENTSTATE"].AllPropertyDefs["APPROVED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string DocName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASINGDOCUMENTSTATE"].AllPropertyDefs["DOCNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetDocumentNamesForFirmsBySupplierIDQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDocumentNamesForFirmsBySupplierIDQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDocumentNamesForFirmsBySupplierIDQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetProposalFirmsByObjectID_Class : TTReportNqlObject 
        {
            public Guid? Supplierid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SUPPLIERID"]);
                }
            }

            public string Supplier
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUPPLIER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUPPLIER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Supplieraddress
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUPPLIERADDRESS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUPPLIER"].AllPropertyDefs["ADDRESS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? TenderDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TENDERDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].AllPropertyDefs["TENDERDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? SufficiencyDueDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUFFICIENCYDUEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].AllPropertyDefs["SUFFICIENCYDUEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Responsibleprocurementunitdef
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESPONSIBLEPROCUREMENTUNITDEF"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCUREMENTUNITDEF"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string KIKTenderRegisterNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KIKTENDERREGISTERNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].AllPropertyDefs["KIKTENDERREGISTERNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ActDefine
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTDEFINE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].AllPropertyDefs["ACTDEFINE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? OrderNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDERNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECTPROPOSALFIRM"].AllPropertyDefs["ORDERNO"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public GetProposalFirmsByObjectID_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetProposalFirmsByObjectID_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetProposalFirmsByObjectID_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDocumentNamesForFirmsQuery_Class : TTReportNqlObject 
        {
            public string DocName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASINGDOCUMENTSTATE"].AllPropertyDefs["DOCNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetDocumentNamesForFirmsQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDocumentNamesForFirmsQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDocumentNamesForFirmsQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetUnEligibleProposalFirms_Class : TTReportNqlObject 
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

            public int? OrderNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDERNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECTPROPOSALFIRM"].AllPropertyDefs["ORDERNO"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public bool? Deny
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DENY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECTPROPOSALFIRM"].AllPropertyDefs["DENY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string DenyDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DENYDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECTPROPOSALFIRM"].AllPropertyDefs["DENYDESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string FinalAnnounceDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FINALANNOUNCEDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECTPROPOSALFIRM"].AllPropertyDefs["FINALANNOUNCEDESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Supplier
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUPPLIER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUPPLIER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetUnEligibleProposalFirms_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetUnEligibleProposalFirms_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetUnEligibleProposalFirms_Class() : base() { }
        }

        [Serializable] 

        public partial class GetFirmOrderNOQuery_Class : TTReportNqlObject 
        {
            public Guid? Firmid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["FIRMID"]);
                }
            }

            public int? OrderNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDERNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECTPROPOSALFIRM"].AllPropertyDefs["ORDERNO"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string FinalAnnounceDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FINALANNOUNCEDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECTPROPOSALFIRM"].AllPropertyDefs["FINALANNOUNCEDESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetFirmOrderNOQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetFirmOrderNOQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetFirmOrderNOQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetAllFirmOrderNoQuery_Class : TTReportNqlObject 
        {
            public Guid? Firmid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["FIRMID"]);
                }
            }

            public string KIKTenderRegisterNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KIKTENDERREGISTERNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].AllPropertyDefs["KIKTENDERREGISTERNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? TenderDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TENDERDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].AllPropertyDefs["TENDERDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ConclusionApproveDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CONCLUSIONAPPROVEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].AllPropertyDefs["CONCLUSIONAPPROVEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Supplier
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUPPLIER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUPPLIER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Supplieraddress
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUPPLIERADDRESS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUPPLIER"].AllPropertyDefs["ADDRESS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Suppliertelephone
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUPPLIERTELEPHONE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUPPLIER"].AllPropertyDefs["TELEPHONE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? OrderNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDERNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECTPROPOSALFIRM"].AllPropertyDefs["ORDERNO"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string FinalAnnounceDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FINALANNOUNCEDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECTPROPOSALFIRM"].AllPropertyDefs["FINALANNOUNCEDESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetAllFirmOrderNoQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetAllFirmOrderNoQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetAllFirmOrderNoQuery_Class() : base() { }
        }

        public static class States
        {
            public static Guid New { get { return new Guid("c83cc8db-4aa5-4e93-95de-3c95ded4a2c0"); } }
            public static Guid Cancelled { get { return new Guid("36d711cd-9b19-4b88-824f-f0c67419bee8"); } }
        }

        public static BindingList<PurchaseProjectProposalFirm.GetDocumentNamesForFirmsBySupplierIDQuery_Class> GetDocumentNamesForFirmsBySupplierIDQuery(string TTOBJECTID, string SUPPLIERID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECTPROPOSALFIRM"].QueryDefs["GetDocumentNamesForFirmsBySupplierIDQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);
            paramList.Add("SUPPLIERID", SUPPLIERID);

            return TTReportNqlObject.QueryObjects<PurchaseProjectProposalFirm.GetDocumentNamesForFirmsBySupplierIDQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PurchaseProjectProposalFirm.GetDocumentNamesForFirmsBySupplierIDQuery_Class> GetDocumentNamesForFirmsBySupplierIDQuery(TTObjectContext objectContext, string TTOBJECTID, string SUPPLIERID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECTPROPOSALFIRM"].QueryDefs["GetDocumentNamesForFirmsBySupplierIDQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);
            paramList.Add("SUPPLIERID", SUPPLIERID);

            return TTReportNqlObject.QueryObjects<PurchaseProjectProposalFirm.GetDocumentNamesForFirmsBySupplierIDQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PurchaseProjectProposalFirm.GetProposalFirmsByObjectID_Class> GetProposalFirmsByObjectID(string TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECTPROPOSALFIRM"].QueryDefs["GetProposalFirmsByObjectID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<PurchaseProjectProposalFirm.GetProposalFirmsByObjectID_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PurchaseProjectProposalFirm.GetProposalFirmsByObjectID_Class> GetProposalFirmsByObjectID(TTObjectContext objectContext, string TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECTPROPOSALFIRM"].QueryDefs["GetProposalFirmsByObjectID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<PurchaseProjectProposalFirm.GetProposalFirmsByObjectID_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PurchaseProjectProposalFirm.GetDocumentNamesForFirmsQuery_Class> GetDocumentNamesForFirmsQuery(string TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECTPROPOSALFIRM"].QueryDefs["GetDocumentNamesForFirmsQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<PurchaseProjectProposalFirm.GetDocumentNamesForFirmsQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PurchaseProjectProposalFirm.GetDocumentNamesForFirmsQuery_Class> GetDocumentNamesForFirmsQuery(TTObjectContext objectContext, string TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECTPROPOSALFIRM"].QueryDefs["GetDocumentNamesForFirmsQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<PurchaseProjectProposalFirm.GetDocumentNamesForFirmsQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PurchaseProjectProposalFirm.GetUnEligibleProposalFirms_Class> GetUnEligibleProposalFirms(string TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECTPROPOSALFIRM"].QueryDefs["GetUnEligibleProposalFirms"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<PurchaseProjectProposalFirm.GetUnEligibleProposalFirms_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PurchaseProjectProposalFirm.GetUnEligibleProposalFirms_Class> GetUnEligibleProposalFirms(TTObjectContext objectContext, string TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECTPROPOSALFIRM"].QueryDefs["GetUnEligibleProposalFirms"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<PurchaseProjectProposalFirm.GetUnEligibleProposalFirms_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PurchaseProjectProposalFirm.GetFirmOrderNOQuery_Class> GetFirmOrderNOQuery(string TTOBJECTID, string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECTPROPOSALFIRM"].QueryDefs["GetFirmOrderNOQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<PurchaseProjectProposalFirm.GetFirmOrderNOQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PurchaseProjectProposalFirm.GetFirmOrderNOQuery_Class> GetFirmOrderNOQuery(TTObjectContext objectContext, string TTOBJECTID, string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECTPROPOSALFIRM"].QueryDefs["GetFirmOrderNOQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<PurchaseProjectProposalFirm.GetFirmOrderNOQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PurchaseProjectProposalFirm.GetAllFirmOrderNoQuery_Class> GetAllFirmOrderNoQuery(Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECTPROPOSALFIRM"].QueryDefs["GetAllFirmOrderNoQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<PurchaseProjectProposalFirm.GetAllFirmOrderNoQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PurchaseProjectProposalFirm.GetAllFirmOrderNoQuery_Class> GetAllFirmOrderNoQuery(TTObjectContext objectContext, Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECTPROPOSALFIRM"].QueryDefs["GetAllFirmOrderNoQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<PurchaseProjectProposalFirm.GetAllFirmOrderNoQuery_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Sıra No
    /// </summary>
        public int? OrderNo
        {
            get { return (int?)this["ORDERNO"]; }
            set { this["ORDERNO"] = value; }
        }

    /// <summary>
    /// Red
    /// </summary>
        public bool? Deny
        {
            get { return (bool?)this["DENY"]; }
            set { this["DENY"] = value; }
        }

    /// <summary>
    /// Red Açıklaması
    /// </summary>
        public string DenyDescription
        {
            get { return (string)this["DENYDESCRIPTION"]; }
            set { this["DENYDESCRIPTION"] = value; }
        }

    /// <summary>
    /// Sonuç Bildirim Açıklaması
    /// </summary>
        public string FinalAnnounceDescription
        {
            get { return (string)this["FINALANNOUNCEDESCRIPTION"]; }
            set { this["FINALANNOUNCEDESCRIPTION"] = value; }
        }

        public Supplier Supplier
        {
            get { return (Supplier)((ITTObject)this).GetParent("SUPPLIER"); }
            set { this["SUPPLIER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public PurchaseProject PurchaseProject
        {
            get { return (PurchaseProject)((ITTObject)this).GetParent("PURCHASEPROJECT"); }
            set { this["PURCHASEPROJECT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Proposal Proposal
        {
            get { return (Proposal)((ITTObject)this).GetParent("PROPOSAL"); }
            set { this["PROPOSAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreatePurchasingDocumentStatesCollection()
        {
            _PurchasingDocumentStates = new PurchasingDocumentState.ChildPurchasingDocumentStateCollection(this, new Guid("bace9703-9ed3-4ebd-93cc-c26bd7f4a22d"));
            ((ITTChildObjectCollection)_PurchasingDocumentStates).GetChildren();
        }

        protected PurchasingDocumentState.ChildPurchasingDocumentStateCollection _PurchasingDocumentStates = null;
        public PurchasingDocumentState.ChildPurchasingDocumentStateCollection PurchasingDocumentStates
        {
            get
            {
                if (_PurchasingDocumentStates == null)
                    CreatePurchasingDocumentStatesCollection();
                return _PurchasingDocumentStates;
            }
        }

        protected PurchaseProjectProposalFirm(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PurchaseProjectProposalFirm(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PurchaseProjectProposalFirm(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PurchaseProjectProposalFirm(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PurchaseProjectProposalFirm(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PURCHASEPROJECTPROPOSALFIRM", dataRow) { }
        protected PurchaseProjectProposalFirm(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PURCHASEPROJECTPROPOSALFIRM", dataRow, isImported) { }
        public PurchaseProjectProposalFirm(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PurchaseProjectProposalFirm(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PurchaseProjectProposalFirm() : base() { }

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
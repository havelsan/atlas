
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="CashOfficeClosing")] 

    /// <summary>
    /// Muh.Yet. Mutemetliği/Vezne/Fatura Servisi Kapama
    /// </summary>
    public  partial class CashOfficeClosing : BaseAction, IWorkListBaseAction
    {
        public class CashOfficeClosingList : TTObjectCollection<CashOfficeClosing> { }
                    
        public class ChildCashOfficeClosingCollection : TTObject.TTChildObjectCollection<CashOfficeClosing>
        {
            public ChildCashOfficeClosingCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildCashOfficeClosingCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class CashOfficeClosingCashReportQuery_Class : TTReportNqlObject 
        {
            public Guid? CashierLog
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CASHIERLOG"]);
                }
            }

            public DateTime? OpeningDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OPENINGDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CASHIERLOG"].AllPropertyDefs["OPENINGDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ClosingDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CLOSINGDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CASHIERLOG"].AllPropertyDefs["CLOSINGDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Cashofficeqref
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CASHOFFICEQREF"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CASHOFFICEDEFINITION"].AllPropertyDefs["QREF"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Cashofficename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CASHOFFICENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CASHOFFICEDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Cashiername
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CASHIERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Cashieremploymentrecordid
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CASHIEREMPLOYMENTRECORDID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["EMPLOYMENTRECORDID"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Userqref
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["USERQREF"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["QREF"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? ResUser
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["RESUSER"]);
                }
            }

            public UserTypeEnum? UserType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["USERTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["USERTYPE"].DataType;
                    return (UserTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public UserTitleEnum? Title
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TITLE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["TITLE"].DataType;
                    return (UserTitleEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public Currency? CashOfficeCashAnnual
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CASHOFFICECASHANNUAL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CASHOFFICECLOSING"].AllPropertyDefs["CASHOFFICECASHANNUAL"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Currency? SubmittedTotal
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUBMITTEDTOTAL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CASHOFFICECLOSING"].AllPropertyDefs["SUBMITTEDTOTAL"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Currency? CashOfficeCreditCardAnnual
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CASHOFFICECREDITCARDANNUAL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CASHOFFICECLOSING"].AllPropertyDefs["CASHOFFICECREDITCARDANNUAL"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Currency? RevenueTotal
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REVENUETOTAL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CASHOFFICECLOSING"].AllPropertyDefs["REVENUETOTAL"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Currency? Balance
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BALANCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CASHOFFICECLOSING"].AllPropertyDefs["BALANCE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Currency? RemainingTotal
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REMAININGTOTAL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CASHOFFICECLOSING"].AllPropertyDefs["REMAININGTOTAL"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Currency? TreatmentPriceBackTotal
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TREATMENTPRICEBACKTOTAL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CASHOFFICECLOSING"].AllPropertyDefs["TREATMENTPRICEBACKTOTAL"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Currency? CashRevenueTotal
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CASHREVENUETOTAL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CASHOFFICECLOSING"].AllPropertyDefs["CASHREVENUETOTAL"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Currency? OtherPriceBackTotal
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OTHERPRICEBACKTOTAL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CASHOFFICECLOSING"].AllPropertyDefs["OTHERPRICEBACKTOTAL"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Guid? BankAccount
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["BANKACCOUNT"]);
                }
            }

            public CashOfficeClosingCashReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public CashOfficeClosingCashReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected CashOfficeClosingCashReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class CashOfficeClosingCrdCardReportQuery_Class : TTReportNqlObject 
        {
            public Guid? CashierLog
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CASHIERLOG"]);
                }
            }

            public DateTime? OpeningDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OPENINGDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CASHIERLOG"].AllPropertyDefs["OPENINGDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ClosingDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CLOSINGDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CASHIERLOG"].AllPropertyDefs["CLOSINGDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Cashofficeqref
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CASHOFFICEQREF"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CASHOFFICEDEFINITION"].AllPropertyDefs["QREF"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Cashofficename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CASHOFFICENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CASHOFFICEDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Cashiername
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CASHIERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Cashieremploymentrecordid
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CASHIEREMPLOYMENTRECORDID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["EMPLOYMENTRECORDID"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Userqref
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["USERQREF"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["QREF"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? ResUser
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["RESUSER"]);
                }
            }

            public UserTypeEnum? UserType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["USERTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["USERTYPE"].DataType;
                    return (UserTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public UserTitleEnum? Title
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TITLE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["TITLE"].DataType;
                    return (UserTitleEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public Currency? CashOfficeCashAnnual
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CASHOFFICECASHANNUAL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CASHOFFICECLOSING"].AllPropertyDefs["CASHOFFICECASHANNUAL"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Currency? CashOfficeCreditCardAnnual
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CASHOFFICECREDITCARDANNUAL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CASHOFFICECLOSING"].AllPropertyDefs["CASHOFFICECREDITCARDANNUAL"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Currency? RevenueTotal
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REVENUETOTAL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CASHOFFICECLOSING"].AllPropertyDefs["REVENUETOTAL"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Currency? TreatmentPriceBackTotal
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TREATMENTPRICEBACKTOTAL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CASHOFFICECLOSING"].AllPropertyDefs["TREATMENTPRICEBACKTOTAL"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Currency? CreditCardRevenueTotal
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CREDITCARDREVENUETOTAL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CASHOFFICECLOSING"].AllPropertyDefs["CREDITCARDREVENUETOTAL"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Guid? BankAccount
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["BANKACCOUNT"]);
                }
            }

            public CashOfficeClosingCrdCardReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public CashOfficeClosingCrdCardReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected CashOfficeClosingCrdCardReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetSubCashOfficeClosingsByDate_Class : TTReportNqlObject 
        {
            public long? LogID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LOGID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CASHIERLOG"].AllPropertyDefs["LOGID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ClosingDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CLOSINGDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CASHIERLOG"].AllPropertyDefs["CLOSINGDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public long? Actionid
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CASHOFFICECLOSING"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Cashoffice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CASHOFFICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CASHOFFICEDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Cashier
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CASHIER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Currency? CashRevenueTotal
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CASHREVENUETOTAL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CASHOFFICECLOSING"].AllPropertyDefs["CASHREVENUETOTAL"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Currency? CreditCardRevenueTotal
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CREDITCARDREVENUETOTAL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CASHOFFICECLOSING"].AllPropertyDefs["CREDITCARDREVENUETOTAL"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public GetSubCashOfficeClosingsByDate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSubCashOfficeClosingsByDate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSubCashOfficeClosingsByDate_Class() : base() { }
        }

        [Serializable] 

        public partial class BankDeliveryReportQuery_Class : TTReportNqlObject 
        {
            public string DocumentNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCUMENTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CASHOFFICECLOSINGDOCUMENT"].AllPropertyDefs["DOCUMENTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? SpecialNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SPECIALNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CASHOFFICECLOSINGDOCUMENT"].AllPropertyDefs["SPECIALNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? DocumentDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCUMENTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CASHOFFICECLOSINGDOCUMENT"].AllPropertyDefs["DOCUMENTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string AccountNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACCOUNTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BANKACCOUNTDEFINITION"].AllPropertyDefs["ACCOUNTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Bankbranchname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BANKBRANCHNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BANKBRANCHDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Bankname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BANKNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BANKDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Cashiername
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["CASHIERNAME"]);
                }
            }

            public Currency? SubmittedTotal
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUBMITTEDTOTAL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CASHOFFICECLOSING"].AllPropertyDefs["SUBMITTEDTOTAL"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public BankDeliveryReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public BankDeliveryReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected BankDeliveryReportQuery_Class() : base() { }
        }

        public static class States
        {
            public static Guid New { get { return new Guid("2e47bfbd-902e-4ff9-ac3a-44947b6848f9"); } }
            public static Guid Completed { get { return new Guid("7c8cc21d-e1d5-44af-8785-c60d287e2ad4"); } }
        }

        public static BindingList<CashOfficeClosing.CashOfficeClosingCashReportQuery_Class> CashOfficeClosingCashReportQuery(string PARAMOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CASHOFFICECLOSING"].QueryDefs["CashOfficeClosingCashReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMOBJID", PARAMOBJID);

            return TTReportNqlObject.QueryObjects<CashOfficeClosing.CashOfficeClosingCashReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<CashOfficeClosing.CashOfficeClosingCashReportQuery_Class> CashOfficeClosingCashReportQuery(TTObjectContext objectContext, string PARAMOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CASHOFFICECLOSING"].QueryDefs["CashOfficeClosingCashReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMOBJID", PARAMOBJID);

            return TTReportNqlObject.QueryObjects<CashOfficeClosing.CashOfficeClosingCashReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<CashOfficeClosing.CashOfficeClosingCrdCardReportQuery_Class> CashOfficeClosingCrdCardReportQuery(string PARAMOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CASHOFFICECLOSING"].QueryDefs["CashOfficeClosingCrdCardReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMOBJID", PARAMOBJID);

            return TTReportNqlObject.QueryObjects<CashOfficeClosing.CashOfficeClosingCrdCardReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<CashOfficeClosing.CashOfficeClosingCrdCardReportQuery_Class> CashOfficeClosingCrdCardReportQuery(TTObjectContext objectContext, string PARAMOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CASHOFFICECLOSING"].QueryDefs["CashOfficeClosingCrdCardReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMOBJID", PARAMOBJID);

            return TTReportNqlObject.QueryObjects<CashOfficeClosing.CashOfficeClosingCrdCardReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<CashOfficeClosing> GetCashOfficeClosingsByDate(TTObjectContext objectContext, DateTime PARAMSTARTDATE, DateTime PARAMENDDATE, string PARAMCASHOFFICE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CASHOFFICECLOSING"].QueryDefs["GetCashOfficeClosingsByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMSTARTDATE", PARAMSTARTDATE);
            paramList.Add("PARAMENDDATE", PARAMENDDATE);
            paramList.Add("PARAMCASHOFFICE", PARAMCASHOFFICE);

            return ((ITTQuery)objectContext).QueryObjects<CashOfficeClosing>(queryDef, paramList);
        }

        public static BindingList<CashOfficeClosing.GetSubCashOfficeClosingsByDate_Class> GetSubCashOfficeClosingsByDate(DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CASHOFFICECLOSING"].QueryDefs["GetSubCashOfficeClosingsByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<CashOfficeClosing.GetSubCashOfficeClosingsByDate_Class>(queryDef, paramList, pi);
        }

        public static BindingList<CashOfficeClosing.GetSubCashOfficeClosingsByDate_Class> GetSubCashOfficeClosingsByDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CASHOFFICECLOSING"].QueryDefs["GetSubCashOfficeClosingsByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<CashOfficeClosing.GetSubCashOfficeClosingsByDate_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<CashOfficeClosing.BankDeliveryReportQuery_Class> BankDeliveryReportQuery(string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CASHOFFICECLOSING"].QueryDefs["BankDeliveryReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<CashOfficeClosing.BankDeliveryReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<CashOfficeClosing.BankDeliveryReportQuery_Class> BankDeliveryReportQuery(TTObjectContext objectContext, string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CASHOFFICECLOSING"].QueryDefs["BankDeliveryReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<CashOfficeClosing.BankDeliveryReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Nakit Tahsilat Tutarı
    /// </summary>
        public Currency? CashRevenueTotal
        {
            get { return (Currency?)this["CASHREVENUETOTAL"]; }
            set { this["CASHREVENUETOTAL"] = value; }
        }

    /// <summary>
    /// Toplam Tahsilat Tutarı
    /// </summary>
        public Currency? RevenueTotal
        {
            get { return (Currency?)this["REVENUETOTAL"]; }
            set { this["REVENUETOTAL"] = value; }
        }

    /// <summary>
    /// Kredi Kartı Tahsilat Tutarı
    /// </summary>
        public Currency? CreditCardRevenueTotal
        {
            get { return (Currency?)this["CREDITCARDREVENUETOTAL"]; }
            set { this["CREDITCARDREVENUETOTAL"] = value; }
        }

    /// <summary>
    /// Diğer İadeler
    /// </summary>
        public Currency? OtherPriceBackTotal
        {
            get { return (Currency?)this["OTHERPRICEBACKTOTAL"]; }
            set { this["OTHERPRICEBACKTOTAL"] = value; }
        }

    /// <summary>
    /// Yıllık Kasa Kredi kartı Nakli Yekünü
    /// </summary>
        public Currency? CashOfficeCreditCardAnnual
        {
            get { return (Currency?)this["CASHOFFICECREDITCARDANNUAL"]; }
            set { this["CASHOFFICECREDITCARDANNUAL"] = value; }
        }

    /// <summary>
    /// Tedavi Bedeli İadesi
    /// </summary>
        public Currency? TreatmentPriceBackTotal
        {
            get { return (Currency?)this["TREATMENTPRICEBACKTOTAL"]; }
            set { this["TREATMENTPRICEBACKTOTAL"] = value; }
        }

    /// <summary>
    /// Vezne Balans
    /// </summary>
        public Currency? Balance
        {
            get { return (Currency?)this["BALANCE"]; }
            set { this["BALANCE"] = value; }
        }

    /// <summary>
    /// Kalan Tutar
    /// </summary>
        public Currency? RemainingTotal
        {
            get { return (Currency?)this["REMAININGTOTAL"]; }
            set { this["REMAININGTOTAL"] = value; }
        }

    /// <summary>
    /// Banka Teslimat No
    /// </summary>
        public string BankPaymentNo
        {
            get { return (string)this["BANKPAYMENTNO"]; }
            set { this["BANKPAYMENTNO"] = value; }
        }

    /// <summary>
    /// Yıllık Kasa Nakit Nakli Yekünü
    /// </summary>
        public Currency? CashOfficeCashAnnual
        {
            get { return (Currency?)this["CASHOFFICECASHANNUAL"]; }
            set { this["CASHOFFICECASHANNUAL"] = value; }
        }

    /// <summary>
    /// Teslim Tutarı
    /// </summary>
        public Currency? SubmittedTotal
        {
            get { return (Currency?)this["SUBMITTEDTOTAL"]; }
            set { this["SUBMITTEDTOTAL"] = value; }
        }

    /// <summary>
    /// Vezne Kapama Dökümanı ile ilişki
    /// </summary>
        public CashOfficeClosingDocument CashOfficeClosingDocument
        {
            get { return (CashOfficeClosingDocument)((ITTObject)this).GetParent("CASHOFFICECLOSINGDOCUMENT"); }
            set { this["CASHOFFICECLOSINGDOCUMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Veznenin açılış kapanış izi  ilişkisi 
    /// </summary>
        public CashierLog CashierLog
        {
            get { return (CashierLog)((ITTObject)this).GetParent("CASHIERLOG"); }
            set { this["CASHIERLOG"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected CashOfficeClosing(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected CashOfficeClosing(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected CashOfficeClosing(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected CashOfficeClosing(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected CashOfficeClosing(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "CASHOFFICECLOSING", dataRow) { }
        protected CashOfficeClosing(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "CASHOFFICECLOSING", dataRow, isImported) { }
        protected CashOfficeClosing(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public CashOfficeClosing(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public CashOfficeClosing() : base() { }

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
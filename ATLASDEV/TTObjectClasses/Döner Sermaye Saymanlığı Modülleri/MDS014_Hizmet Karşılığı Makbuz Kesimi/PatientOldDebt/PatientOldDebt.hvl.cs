
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PatientOldDebt")] 

    /// <summary>
    /// Aktarım hastaları borç listesi
    /// </summary>
    public  partial class PatientOldDebt : TTObject
    {
        public class PatientOldDebtList : TTObjectCollection<PatientOldDebt> { }
                    
        public class ChildPatientOldDebtCollection : TTObject.TTChildObjectCollection<PatientOldDebt>
        {
            public ChildPatientOldDebtCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPatientOldDebtCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class OldDebtReceiptReportQuery_Class : TTReportNqlObject 
        {
            public string Payeename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PAYEENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTOLDDEBT"].AllPropertyDefs["OLDPATIENTNAMESURNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Uniquerefno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNIQUEREFNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTOLDDEBT"].AllPropertyDefs["OLDUNIQUEREFNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Currency? Totalpayment
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOTALPAYMENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OLDDEBTRECEIPTDOCUMENT"].AllPropertyDefs["TOTALPRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public string DocumentNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCUMENTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OLDDEBTRECEIPTDOCUMENT"].AllPropertyDefs["DOCUMENTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? DocumentDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCUMENTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OLDDEBTRECEIPTDOCUMENT"].AllPropertyDefs["DOCUMENTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public PaymentTypeEnum? PaymentType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PAYMENTTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OLDDEBTRECEIPTDOCUMENT"].AllPropertyDefs["PAYMENTTYPE"].DataType;
                    return (PaymentTypeEnum?)(int)dataType.ConvertValue(val);
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

            public string HomeAddress
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HOMEADDRESS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTIDENTITYANDADDRESS"].AllPropertyDefs["HOMEADDRESS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public OldDebtReceiptReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OldDebtReceiptReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OldDebtReceiptReportQuery_Class() : base() { }
        }

    /// <summary>
    /// Eski Borç Makbuz Raporu
    /// </summary>
        public static BindingList<PatientOldDebt.OldDebtReceiptReportQuery_Class> OldDebtReceiptReportQuery(Guid PatientObjectID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTOLDDEBT"].QueryDefs["OldDebtReceiptReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENTOBJECTID", PatientObjectID);

            return TTReportNqlObject.QueryObjects<PatientOldDebt.OldDebtReceiptReportQuery_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// Eski Borç Makbuz Raporu
    /// </summary>
        public static BindingList<PatientOldDebt.OldDebtReceiptReportQuery_Class> OldDebtReceiptReportQuery(TTObjectContext objectContext, Guid PatientObjectID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTOLDDEBT"].QueryDefs["OldDebtReceiptReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENTOBJECTID", PatientObjectID);

            return TTReportNqlObject.QueryObjects<PatientOldDebt.OldDebtReceiptReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public string OldID
        {
            get { return (string)this["OLDID"]; }
            set { this["OLDID"] = value; }
        }

        public Currency? TotalDebt
        {
            get { return (Currency?)this["TOTALDEBT"]; }
            set { this["TOTALDEBT"] = value; }
        }

        public string ProcedureType
        {
            get { return (string)this["PROCEDURETYPE"]; }
            set { this["PROCEDURETYPE"] = value; }
        }

        public string ProcedureCode
        {
            get { return (string)this["PROCEDURECODE"]; }
            set { this["PROCEDURECODE"] = value; }
        }

        public string ProcedureName
        {
            get { return (string)this["PROCEDURENAME"]; }
            set { this["PROCEDURENAME"] = value; }
        }

        public string PaymentType
        {
            get { return (string)this["PAYMENTTYPE"]; }
            set { this["PAYMENTTYPE"] = value; }
        }

        public Currency? TransactionDebt
        {
            get { return (Currency?)this["TRANSACTIONDEBT"]; }
            set { this["TRANSACTIONDEBT"] = value; }
        }

        public string OldPatientID
        {
            get { return (string)this["OLDPATIENTID"]; }
            set { this["OLDPATIENTID"] = value; }
        }

        public DateTime? OldPADate
        {
            get { return (DateTime?)this["OLDPADATE"]; }
            set { this["OLDPADATE"] = value; }
        }

        public string OldPANo
        {
            get { return (string)this["OLDPANO"]; }
            set { this["OLDPANO"] = value; }
        }

        public string OldPatientNameSurname
        {
            get { return (string)this["OLDPATIENTNAMESURNAME"]; }
            set { this["OLDPATIENTNAMESURNAME"] = value; }
        }

        public string OldUniqueRefNo
        {
            get { return (string)this["OLDUNIQUEREFNO"]; }
            set { this["OLDUNIQUEREFNO"] = value; }
        }

        public bool? IsRemoved
        {
            get { return (bool?)this["ISREMOVED"]; }
            set { this["ISREMOVED"] = value; }
        }

        public OldDebtReceiptDocument OldDebtReceiptDocument
        {
            get { return (OldDebtReceiptDocument)((ITTObject)this).GetParent("OLDDEBTRECEIPTDOCUMENT"); }
            set { this["OLDDEBTRECEIPTDOCUMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Patient Patient
        {
            get { return (Patient)((ITTObject)this).GetParent("PATIENT"); }
            set { this["PATIENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ProcedureDefinition ProcedureDefinition
        {
            get { return (ProcedureDefinition)((ITTObject)this).GetParent("PROCEDUREDEFINITION"); }
            set { this["PROCEDUREDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected PatientOldDebt(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PatientOldDebt(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PatientOldDebt(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PatientOldDebt(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PatientOldDebt(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PATIENTOLDDEBT", dataRow) { }
        protected PatientOldDebt(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PATIENTOLDDEBT", dataRow, isImported) { }
        public PatientOldDebt(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PatientOldDebt(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PatientOldDebt() : base() { }

    }
}
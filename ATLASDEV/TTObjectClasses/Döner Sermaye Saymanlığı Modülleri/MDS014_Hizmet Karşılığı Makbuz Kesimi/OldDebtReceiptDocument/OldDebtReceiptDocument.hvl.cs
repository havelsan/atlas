
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="OldDebtReceiptDocument")] 

    /// <summary>
    /// Eski Borç Tahsilatı
    /// </summary>
    public  partial class OldDebtReceiptDocument : AccountDocument
    {
        public class OldDebtReceiptDocumentList : TTObjectCollection<OldDebtReceiptDocument> { }
                    
        public class ChildOldDebtReceiptDocumentCollection : TTObject.TTChildObjectCollection<OldDebtReceiptDocument>
        {
            public ChildOldDebtReceiptDocumentCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildOldDebtReceiptDocumentCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class OldDebtCashOfficeWorkListNQL_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public long? UniqueRefNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNIQUEREFNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["UNIQUEREFNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string OldPatientNameSurname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLDPATIENTNAMESURNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTOLDDEBT"].AllPropertyDefs["OLDPATIENTNAMESURNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public String Objname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OBJNAME"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public String Objdisplaytext
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OBJDISPLAYTEXT"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public Object Documentno
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["DOCUMENTNO"]);
                }
            }

            public Object Documentdate
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["DOCUMENTDATE"]);
                }
            }

            public Currency? TotalPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOTALPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OLDDEBTRECEIPTDOCUMENT"].AllPropertyDefs["TOTALPRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
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

            public OldDebtCashOfficeWorkListNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OldDebtCashOfficeWorkListNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OldDebtCashOfficeWorkListNQL_Class() : base() { }
        }

        public static BindingList<OldDebtReceiptDocument.OldDebtCashOfficeWorkListNQL_Class> OldDebtCashOfficeWorkListNQL(DateTime STARTDATE, DateTime ENDDATE, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["OLDDEBTRECEIPTDOCUMENT"].QueryDefs["OldDebtCashOfficeWorkListNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<OldDebtReceiptDocument.OldDebtCashOfficeWorkListNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<OldDebtReceiptDocument.OldDebtCashOfficeWorkListNQL_Class> OldDebtCashOfficeWorkListNQL(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["OLDDEBTRECEIPTDOCUMENT"].QueryDefs["OldDebtCashOfficeWorkListNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<OldDebtReceiptDocument.OldDebtCashOfficeWorkListNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        virtual protected void CreatePatientOldDebtCollection()
        {
            _PatientOldDebt = new PatientOldDebt.ChildPatientOldDebtCollection(this, new Guid("40864e63-f5c2-4c40-8cc7-a54e185915a5"));
            ((ITTChildObjectCollection)_PatientOldDebt).GetChildren();
        }

        protected PatientOldDebt.ChildPatientOldDebtCollection _PatientOldDebt = null;
        public PatientOldDebt.ChildPatientOldDebtCollection PatientOldDebt
        {
            get
            {
                if (_PatientOldDebt == null)
                    CreatePatientOldDebtCollection();
                return _PatientOldDebt;
            }
        }

        protected OldDebtReceiptDocument(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected OldDebtReceiptDocument(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected OldDebtReceiptDocument(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected OldDebtReceiptDocument(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected OldDebtReceiptDocument(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "OLDDEBTRECEIPTDOCUMENT", dataRow) { }
        protected OldDebtReceiptDocument(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "OLDDEBTRECEIPTDOCUMENT", dataRow, isImported) { }
        public OldDebtReceiptDocument(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public OldDebtReceiptDocument(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public OldDebtReceiptDocument() : base() { }

    }
}
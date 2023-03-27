
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="AccountDocument")] 

    /// <summary>
    /// Finansal Döküman türlerinin ana sınıfıdır
    /// </summary>
    public  partial class AccountDocument : TTObject
    {
        public class AccountDocumentList : TTObjectCollection<AccountDocument> { }
                    
        public class ChildAccountDocumentCollection : TTObject.TTChildObjectCollection<AccountDocument>
        {
            public ChildAccountDocumentCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildAccountDocumentCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetUnpaidAccDocs_Class : TTReportNqlObject 
        {
            public long? Payercode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PAYERCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Payername
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PAYERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Payercity
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PAYERCITY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CITY"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? CurrentStateDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENTSTATEDEFID"]);
                }
            }

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public long? DocumentID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCUMENTID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEDOCUMENT"].AllPropertyDefs["DOCUMENTID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEDOCUMENT"].AllPropertyDefs["DOCUMENTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string DocumentNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCUMENTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEDOCUMENT"].AllPropertyDefs["DOCUMENTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEDOCUMENT"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Surname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SURNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["SURNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public Currency? GeneralTotalPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GENERALTOTALPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICE"].AllPropertyDefs["GENERALTOTALPRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public InvoicePostingInvoiceTypeEnum? Type
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEDOCUMENT"].AllPropertyDefs["INVOICEPOSTINGINVOICETYPE"].DataType;
                    return (InvoicePostingInvoiceTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public Object Isinvoice
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["ISINVOICE"]);
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

            public GetUnpaidAccDocs_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetUnpaidAccDocs_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetUnpaidAccDocs_Class() : base() { }
        }

        [Serializable] 

        public partial class GetAccDocsByCasLogAndCash_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public long? DocumentID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCUMENTID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTDOCUMENT"].AllPropertyDefs["DOCUMENTID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTDOCUMENT"].AllPropertyDefs["DOCUMENTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string DocumentNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCUMENTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTDOCUMENT"].AllPropertyDefs["DOCUMENTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTDOCUMENT"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Totalprice
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOTALPRICE"]);
                }
            }

            public Object Patientname
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PATIENTNAME"]);
                }
            }

            public GetAccDocsByCasLogAndCash_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetAccDocsByCasLogAndCash_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetAccDocsByCasLogAndCash_Class() : base() { }
        }

        [Serializable] 

        public partial class GetCancelledInvoices_Class : TTReportNqlObject 
        {
            public long? Patientid
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Patientname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Patientsurname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTSURNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["SURNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? HospitalProtocolNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HOSPITALPROTOCOLNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["HOSPITALPROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public long? Actionid
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTINVOICE"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string DocumentNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCUMENTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTINVOICEDOCUMENT"].AllPropertyDefs["DOCUMENTNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTINVOICEDOCUMENT"].AllPropertyDefs["DOCUMENTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Currency? Price
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTINVOICE"].AllPropertyDefs["TOTALPRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Object Payername
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PAYERNAME"]);
                }
            }

            public Object Invoicetype
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["INVOICETYPE"]);
                }
            }

            public Guid? Actionguid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["ACTIONGUID"]);
                }
            }

            public GetCancelledInvoices_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetCancelledInvoices_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetCancelledInvoices_Class() : base() { }
        }

        [Serializable] 

        public partial class GetCancelledReceipts_Class : TTReportNqlObject 
        {
            public long? Patientid
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Patientname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Patientsurname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTSURNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["SURNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? HospitalProtocolNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HOSPITALPROTOCOLNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["HOSPITALPROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public long? Actionid
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ADVANCE"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string DocumentNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCUMENTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ADVANCEDOCUMENT"].AllPropertyDefs["DOCUMENTNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ADVANCEDOCUMENT"].AllPropertyDefs["DOCUMENTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Object Receipttype
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["RECEIPTTYPE"]);
                }
            }

            public Guid? Actionguid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["ACTIONGUID"]);
                }
            }

            public Object Price
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PRICE"]);
                }
            }

            public Object Cardowner
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["CARDOWNER"]);
                }
            }

            public GetCancelledReceipts_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetCancelledReceipts_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetCancelledReceipts_Class() : base() { }
        }

        [Serializable] 

        public partial class DenemeUnıion_Class : TTReportNqlObject 
        {
            public long? Payercode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PAYERCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Payername
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PAYERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? CurrentStateDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENTSTATEDEFID"]);
                }
            }

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public long? DocumentID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCUMENTID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEDOCUMENT"].AllPropertyDefs["DOCUMENTID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEDOCUMENT"].AllPropertyDefs["DOCUMENTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string DocumentNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCUMENTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEDOCUMENT"].AllPropertyDefs["DOCUMENTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEDOCUMENT"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Surname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SURNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["SURNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public Currency? GeneralTotalPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GENERALTOTALPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICE"].AllPropertyDefs["GENERALTOTALPRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public DenemeUnıion_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public DenemeUnıion_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected DenemeUnıion_Class() : base() { }
        }

        [Serializable] 

        public partial class GetMainCashOfficeDocsByCasLog_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public long? DocumentID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCUMENTID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTDOCUMENT"].AllPropertyDefs["DOCUMENTID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTDOCUMENT"].AllPropertyDefs["DOCUMENTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string DocumentNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCUMENTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTDOCUMENT"].AllPropertyDefs["DOCUMENTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTDOCUMENT"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Totalprice
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOTALPRICE"]);
                }
            }

            public GetMainCashOfficeDocsByCasLog_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMainCashOfficeDocsByCasLog_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMainCashOfficeDocsByCasLog_Class() : base() { }
        }

        [Serializable] 

        public partial class GetAccDocsByCasLogAndCrdCard_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public long? DocumentID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCUMENTID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTDOCUMENT"].AllPropertyDefs["DOCUMENTID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTDOCUMENT"].AllPropertyDefs["DOCUMENTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTDOCUMENT"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Totalprice
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOTALPRICE"]);
                }
            }

            public Object Patientname
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PATIENTNAME"]);
                }
            }

            public Object Cardowner
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["CARDOWNER"]);
                }
            }

            public GetAccDocsByCasLogAndCrdCard_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetAccDocsByCasLogAndCrdCard_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetAccDocsByCasLogAndCrdCard_Class() : base() { }
        }

        [Serializable] 

        public partial class GetSubCashOfficeAccDocsByDate_Class : TTReportNqlObject 
        {
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

            public Object Tur
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TUR"]);
                }
            }

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public DateTime? DocumentDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCUMENTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTDOCUMENT"].AllPropertyDefs["DOCUMENTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string DocumentNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCUMENTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTDOCUMENT"].AllPropertyDefs["DOCUMENTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTDOCUMENT"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Price
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PRICE"]);
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

            public Object Name
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["NAME"]);
                }
            }

            public Object Cardowner
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["CARDOWNER"]);
                }
            }

            public GetSubCashOfficeAccDocsByDate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSubCashOfficeAccDocsByDate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSubCashOfficeAccDocsByDate_Class() : base() { }
        }

        [Serializable] 

        public partial class Deneme2GroupBy_Class : TTReportNqlObject 
        {
            public long? Payercode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PAYERCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Payername
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PAYERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Payercity
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PAYERCITY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CITY"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? CurrentStateDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENTSTATEDEFID"]);
                }
            }

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public long? DocumentID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCUMENTID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEDOCUMENT"].AllPropertyDefs["DOCUMENTID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEDOCUMENT"].AllPropertyDefs["DOCUMENTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string DocumentNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCUMENTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEDOCUMENT"].AllPropertyDefs["DOCUMENTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEDOCUMENT"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Surname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SURNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["SURNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public Currency? GeneralTotalPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GENERALTOTALPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICE"].AllPropertyDefs["GENERALTOTALPRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public InvoicePostingInvoiceTypeEnum? Type
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEDOCUMENT"].AllPropertyDefs["INVOICEPOSTINGINVOICETYPE"].DataType;
                    return (InvoicePostingInvoiceTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public Deneme2GroupBy_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public Deneme2GroupBy_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected Deneme2GroupBy_Class() : base() { }
        }

        [Serializable] 

        public partial class GetBackDocumentByDate_Class : TTReportNqlObject 
        {
            public DateTime? DocumentDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCUMENTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINCASHOFFICEBACKDOCUMENT"].AllPropertyDefs["DOCUMENTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Patientname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINCASHOFFICEBACKDOCUMENT"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Uniquerefno
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["UNIQUEREFNO"]);
                }
            }

            public string DocumentNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCUMENTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINCASHOFFICEBACKDOCUMENT"].AllPropertyDefs["DOCUMENTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINCASHOFFICEBACKTYPEDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Currency? TotalPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOTALPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINCASHOFFICEBACKDOCUMENT"].AllPropertyDefs["TOTALPRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public GetBackDocumentByDate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetBackDocumentByDate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetBackDocumentByDate_Class() : base() { }
        }

        [Serializable] 

        public partial class CashOfficeReportQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public long? DocumentID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCUMENTID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTDOCUMENT"].AllPropertyDefs["DOCUMENTID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTDOCUMENT"].AllPropertyDefs["DOCUMENTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string DocumentNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCUMENTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTDOCUMENT"].AllPropertyDefs["DOCUMENTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTDOCUMENT"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Currency? TotalPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOTALPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTDOCUMENT"].AllPropertyDefs["TOTALPRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Object Patientname
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PATIENTNAME"]);
                }
            }

            public CashOfficeReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public CashOfficeReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected CashOfficeReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class CheckForSameReceiptNumbers_Class : TTReportNqlObject 
        {
            public string ProtocolNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROTOCOLNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].AllPropertyDefs["PROTOCOLNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Surname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SURNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["SURNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? OpeningDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OPENINGDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].AllPropertyDefs["OPENINGDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
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

            public CheckForSameReceiptNumbers_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public CheckForSameReceiptNumbers_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected CheckForSameReceiptNumbers_Class() : base() { }
        }

        [Serializable] 

        public partial class CashOfficeRevenueReportQuery_Class : TTReportNqlObject 
        {
            public String Objectdef
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OBJECTDEF"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public long? DocumentID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCUMENTID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTDOCUMENT"].AllPropertyDefs["DOCUMENTID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTDOCUMENT"].AllPropertyDefs["DOCUMENTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string DocumentNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCUMENTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTDOCUMENT"].AllPropertyDefs["DOCUMENTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTDOCUMENT"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Currency? TotalPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOTALPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTDOCUMENT"].AllPropertyDefs["TOTALPRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public PaymentTypeEnum? PaymentType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PAYMENTTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTDOCUMENT"].AllPropertyDefs["PAYMENTTYPE"].DataType;
                    return (PaymentTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public Object Episodeid
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["EPISODEID"]);
                }
            }

            public Object Patientname
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PATIENTNAME"]);
                }
            }

            public Object Statestatus
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["STATESTATUS"]);
                }
            }

            public Object Accountcode
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["ACCOUNTCODE"]);
                }
            }

            public CashOfficeRevenueReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public CashOfficeRevenueReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected CashOfficeRevenueReportQuery_Class() : base() { }
        }

        public static BindingList<AccountDocument> GetSubCashierDocsByCashierLog(TTObjectContext objectContext, string PARAMCASHIERLOG)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTDOCUMENT"].QueryDefs["GetSubCashierDocsByCashierLog"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMCASHIERLOG", PARAMCASHIERLOG);

            return ((ITTQuery)objectContext).QueryObjects<AccountDocument>(queryDef, paramList);
        }

        public static BindingList<AccountDocument.GetUnpaidAccDocs_Class> GetUnpaidAccDocs(DateTime PARAMSDATE, DateTime PARAMEDATE, long PARAMSPAYERCODE, long PARAMEPAYERCODE, OutPatientInPatientBothEnum PARAMPATIENTSTATUS, OutPatientInPatientBothEnum PARAMOTHERPATIENTSTATUS, OutPatientInPatientBothEnum PARAMBOTHPATIENTSTATUS, IList<int> PARAMINVPOSTTYPE, int PARAMCOLINVPATSTATUS, int PARAMCOLINVPATSTATUSOTHER, int PARAMISINVOICE, int PARAMISCOLLECTEDINVOICE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTDOCUMENT"].QueryDefs["GetUnpaidAccDocs"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMSDATE", PARAMSDATE);
            paramList.Add("PARAMEDATE", PARAMEDATE);
            paramList.Add("PARAMSPAYERCODE", PARAMSPAYERCODE);
            paramList.Add("PARAMEPAYERCODE", PARAMEPAYERCODE);
            paramList.Add("PARAMPATIENTSTATUS", (int)PARAMPATIENTSTATUS);
            paramList.Add("PARAMOTHERPATIENTSTATUS", (int)PARAMOTHERPATIENTSTATUS);
            paramList.Add("PARAMBOTHPATIENTSTATUS", (int)PARAMBOTHPATIENTSTATUS);
            paramList.Add("PARAMINVPOSTTYPE", PARAMINVPOSTTYPE);
            paramList.Add("PARAMCOLINVPATSTATUS", PARAMCOLINVPATSTATUS);
            paramList.Add("PARAMCOLINVPATSTATUSOTHER", PARAMCOLINVPATSTATUSOTHER);
            paramList.Add("PARAMISINVOICE", PARAMISINVOICE);
            paramList.Add("PARAMISCOLLECTEDINVOICE", PARAMISCOLLECTEDINVOICE);

            return TTReportNqlObject.QueryObjects<AccountDocument.GetUnpaidAccDocs_Class>(queryDef, paramList, pi);
        }

        public static BindingList<AccountDocument.GetUnpaidAccDocs_Class> GetUnpaidAccDocs(TTObjectContext objectContext, DateTime PARAMSDATE, DateTime PARAMEDATE, long PARAMSPAYERCODE, long PARAMEPAYERCODE, OutPatientInPatientBothEnum PARAMPATIENTSTATUS, OutPatientInPatientBothEnum PARAMOTHERPATIENTSTATUS, OutPatientInPatientBothEnum PARAMBOTHPATIENTSTATUS, IList<int> PARAMINVPOSTTYPE, int PARAMCOLINVPATSTATUS, int PARAMCOLINVPATSTATUSOTHER, int PARAMISINVOICE, int PARAMISCOLLECTEDINVOICE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTDOCUMENT"].QueryDefs["GetUnpaidAccDocs"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMSDATE", PARAMSDATE);
            paramList.Add("PARAMEDATE", PARAMEDATE);
            paramList.Add("PARAMSPAYERCODE", PARAMSPAYERCODE);
            paramList.Add("PARAMEPAYERCODE", PARAMEPAYERCODE);
            paramList.Add("PARAMPATIENTSTATUS", (int)PARAMPATIENTSTATUS);
            paramList.Add("PARAMOTHERPATIENTSTATUS", (int)PARAMOTHERPATIENTSTATUS);
            paramList.Add("PARAMBOTHPATIENTSTATUS", (int)PARAMBOTHPATIENTSTATUS);
            paramList.Add("PARAMINVPOSTTYPE", PARAMINVPOSTTYPE);
            paramList.Add("PARAMCOLINVPATSTATUS", PARAMCOLINVPATSTATUS);
            paramList.Add("PARAMCOLINVPATSTATUSOTHER", PARAMCOLINVPATSTATUSOTHER);
            paramList.Add("PARAMISINVOICE", PARAMISINVOICE);
            paramList.Add("PARAMISCOLLECTEDINVOICE", PARAMISCOLLECTEDINVOICE);

            return TTReportNqlObject.QueryObjects<AccountDocument.GetUnpaidAccDocs_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Nakit ödenen Makbuz tipi dökümanları getirir
    /// </summary>
        public static BindingList<AccountDocument.GetAccDocsByCasLogAndCash_Class> GetAccDocsByCasLogAndCash(string PARAMCASHIERLOG, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTDOCUMENT"].QueryDefs["GetAccDocsByCasLogAndCash"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMCASHIERLOG", PARAMCASHIERLOG);

            return TTReportNqlObject.QueryObjects<AccountDocument.GetAccDocsByCasLogAndCash_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// Nakit ödenen Makbuz tipi dökümanları getirir
    /// </summary>
        public static BindingList<AccountDocument.GetAccDocsByCasLogAndCash_Class> GetAccDocsByCasLogAndCash(TTObjectContext objectContext, string PARAMCASHIERLOG, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTDOCUMENT"].QueryDefs["GetAccDocsByCasLogAndCash"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMCASHIERLOG", PARAMCASHIERLOG);

            return TTReportNqlObject.QueryObjects<AccountDocument.GetAccDocsByCasLogAndCash_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<AccountDocument> GetInvSrvCashierDocsByCashierLog(TTObjectContext objectContext, string PARAMCASHIERLOG)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTDOCUMENT"].QueryDefs["GetInvSrvCashierDocsByCashierLog"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMCASHIERLOG", PARAMCASHIERLOG);

            return ((ITTQuery)objectContext).QueryObjects<AccountDocument>(queryDef, paramList);
        }

        public static BindingList<AccountDocument.GetCancelledInvoices_Class> GetCancelledInvoices(DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTDOCUMENT"].QueryDefs["GetCancelledInvoices"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<AccountDocument.GetCancelledInvoices_Class>(queryDef, paramList, pi);
        }

        public static BindingList<AccountDocument.GetCancelledInvoices_Class> GetCancelledInvoices(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTDOCUMENT"].QueryDefs["GetCancelledInvoices"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<AccountDocument.GetCancelledInvoices_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<AccountDocument> GetByObjectID(TTObjectContext objectContext, string PARAMOBJECTID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTDOCUMENT"].QueryDefs["GetByObjectID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMOBJECTID", PARAMOBJECTID);

            return ((ITTQuery)objectContext).QueryObjects<AccountDocument>(queryDef, paramList);
        }

        public static BindingList<AccountDocument> GetBackDocsByCashierLog(TTObjectContext objectContext, string PARAMCASHIERLOG)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTDOCUMENT"].QueryDefs["GetBackDocsByCashierLog"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMCASHIERLOG", PARAMCASHIERLOG);

            return ((ITTQuery)objectContext).QueryObjects<AccountDocument>(queryDef, paramList);
        }

        public static BindingList<AccountDocument> GetMainCashierDocsByCashierLog(TTObjectContext objectContext, string PARAMCASHIERLOG)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTDOCUMENT"].QueryDefs["GetMainCashierDocsByCashierLog"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMCASHIERLOG", PARAMCASHIERLOG);

            return ((ITTQuery)objectContext).QueryObjects<AccountDocument>(queryDef, paramList);
        }

        public static BindingList<AccountDocument.GetCancelledReceipts_Class> GetCancelledReceipts(DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTDOCUMENT"].QueryDefs["GetCancelledReceipts"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<AccountDocument.GetCancelledReceipts_Class>(queryDef, paramList, pi);
        }

        public static BindingList<AccountDocument.GetCancelledReceipts_Class> GetCancelledReceipts(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTDOCUMENT"].QueryDefs["GetCancelledReceipts"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<AccountDocument.GetCancelledReceipts_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<AccountDocument.DenemeUnıion_Class> DenemeUnıion(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTDOCUMENT"].QueryDefs["DenemeUnıion"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<AccountDocument.DenemeUnıion_Class>(queryDef, paramList, pi);
        }

        public static BindingList<AccountDocument.DenemeUnıion_Class> DenemeUnıion(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTDOCUMENT"].QueryDefs["DenemeUnıion"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<AccountDocument.DenemeUnıion_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<AccountDocument.GetMainCashOfficeDocsByCasLog_Class> GetMainCashOfficeDocsByCasLog(string PARAMCASHIERLOG, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTDOCUMENT"].QueryDefs["GetMainCashOfficeDocsByCasLog"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMCASHIERLOG", PARAMCASHIERLOG);

            return TTReportNqlObject.QueryObjects<AccountDocument.GetMainCashOfficeDocsByCasLog_Class>(queryDef, paramList, pi);
        }

        public static BindingList<AccountDocument.GetMainCashOfficeDocsByCasLog_Class> GetMainCashOfficeDocsByCasLog(TTObjectContext objectContext, string PARAMCASHIERLOG, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTDOCUMENT"].QueryDefs["GetMainCashOfficeDocsByCasLog"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMCASHIERLOG", PARAMCASHIERLOG);

            return TTReportNqlObject.QueryObjects<AccountDocument.GetMainCashOfficeDocsByCasLog_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Kredi Kartı ödenen Makbuz tipi dökümanları getirir
    /// </summary>
        public static BindingList<AccountDocument.GetAccDocsByCasLogAndCrdCard_Class> GetAccDocsByCasLogAndCrdCard(string PARAMCASHIERLOG, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTDOCUMENT"].QueryDefs["GetAccDocsByCasLogAndCrdCard"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMCASHIERLOG", PARAMCASHIERLOG);

            return TTReportNqlObject.QueryObjects<AccountDocument.GetAccDocsByCasLogAndCrdCard_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// Kredi Kartı ödenen Makbuz tipi dökümanları getirir
    /// </summary>
        public static BindingList<AccountDocument.GetAccDocsByCasLogAndCrdCard_Class> GetAccDocsByCasLogAndCrdCard(TTObjectContext objectContext, string PARAMCASHIERLOG, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTDOCUMENT"].QueryDefs["GetAccDocsByCasLogAndCrdCard"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMCASHIERLOG", PARAMCASHIERLOG);

            return TTReportNqlObject.QueryObjects<AccountDocument.GetAccDocsByCasLogAndCrdCard_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<AccountDocument> GetAllAccDocsByCashierLog(TTObjectContext objectContext, string PARAMCASHIERLOG)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTDOCUMENT"].QueryDefs["GetAllAccDocsByCashierLog"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMCASHIERLOG", PARAMCASHIERLOG);

            return ((ITTQuery)objectContext).QueryObjects<AccountDocument>(queryDef, paramList);
        }

        public static BindingList<AccountDocument.GetSubCashOfficeAccDocsByDate_Class> GetSubCashOfficeAccDocsByDate(DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTDOCUMENT"].QueryDefs["GetSubCashOfficeAccDocsByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<AccountDocument.GetSubCashOfficeAccDocsByDate_Class>(queryDef, paramList, pi);
        }

        public static BindingList<AccountDocument.GetSubCashOfficeAccDocsByDate_Class> GetSubCashOfficeAccDocsByDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTDOCUMENT"].QueryDefs["GetSubCashOfficeAccDocsByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<AccountDocument.GetSubCashOfficeAccDocsByDate_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<AccountDocument.Deneme2GroupBy_Class> Deneme2GroupBy(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTDOCUMENT"].QueryDefs["Deneme2GroupBy"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<AccountDocument.Deneme2GroupBy_Class>(queryDef, paramList, pi);
        }

        public static BindingList<AccountDocument.Deneme2GroupBy_Class> Deneme2GroupBy(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTDOCUMENT"].QueryDefs["Deneme2GroupBy"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<AccountDocument.Deneme2GroupBy_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<AccountDocument.GetBackDocumentByDate_Class> GetBackDocumentByDate(DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTDOCUMENT"].QueryDefs["GetBackDocumentByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<AccountDocument.GetBackDocumentByDate_Class>(queryDef, paramList, pi);
        }

        public static BindingList<AccountDocument.GetBackDocumentByDate_Class> GetBackDocumentByDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTDOCUMENT"].QueryDefs["GetBackDocumentByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<AccountDocument.GetBackDocumentByDate_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<AccountDocument.CashOfficeReportQuery_Class> CashOfficeReportQuery(DateTime STARTDATE, DateTime ENDDATE, Guid CASHOFFICE, Guid CASHIER, PaymentTypeEnum PAYMENTTYPE, int PAYMENTTYPECONTROL, int CASHOFFICECONTROL, int CASHIERCONTROL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTDOCUMENT"].QueryDefs["CashOfficeReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("CASHOFFICE", CASHOFFICE);
            paramList.Add("CASHIER", CASHIER);
            paramList.Add("PAYMENTTYPE", (int)PAYMENTTYPE);
            paramList.Add("PAYMENTTYPECONTROL", PAYMENTTYPECONTROL);
            paramList.Add("CASHOFFICECONTROL", CASHOFFICECONTROL);
            paramList.Add("CASHIERCONTROL", CASHIERCONTROL);

            return TTReportNqlObject.QueryObjects<AccountDocument.CashOfficeReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<AccountDocument.CashOfficeReportQuery_Class> CashOfficeReportQuery(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, Guid CASHOFFICE, Guid CASHIER, PaymentTypeEnum PAYMENTTYPE, int PAYMENTTYPECONTROL, int CASHOFFICECONTROL, int CASHIERCONTROL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTDOCUMENT"].QueryDefs["CashOfficeReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("CASHOFFICE", CASHOFFICE);
            paramList.Add("CASHIER", CASHIER);
            paramList.Add("PAYMENTTYPE", (int)PAYMENTTYPE);
            paramList.Add("PAYMENTTYPECONTROL", PAYMENTTYPECONTROL);
            paramList.Add("CASHOFFICECONTROL", CASHOFFICECONTROL);
            paramList.Add("CASHIERCONTROL", CASHIERCONTROL);

            return TTReportNqlObject.QueryObjects<AccountDocument.CashOfficeReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<AccountDocument> GetBackDocsByCashierAndDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, Guid CASHOFFICE, Guid CASHIER)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTDOCUMENT"].QueryDefs["GetBackDocsByCashierAndDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("CASHOFFICE", CASHOFFICE);
            paramList.Add("CASHIER", CASHIER);

            return ((ITTQuery)objectContext).QueryObjects<AccountDocument>(queryDef, paramList);
        }

        public static BindingList<AccountDocument.CheckForSameReceiptNumbers_Class> CheckForSameReceiptNumbers(IList<Guid> EAAOBJECTIDS, IList<Guid> AAOBJECTIDS, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTDOCUMENT"].QueryDefs["CheckForSameReceiptNumbers"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EAAOBJECTIDS", EAAOBJECTIDS);
            paramList.Add("AAOBJECTIDS", AAOBJECTIDS);

            return TTReportNqlObject.QueryObjects<AccountDocument.CheckForSameReceiptNumbers_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<AccountDocument.CheckForSameReceiptNumbers_Class> CheckForSameReceiptNumbers(TTObjectContext objectContext, IList<Guid> EAAOBJECTIDS, IList<Guid> AAOBJECTIDS, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTDOCUMENT"].QueryDefs["CheckForSameReceiptNumbers"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EAAOBJECTIDS", EAAOBJECTIDS);
            paramList.Add("AAOBJECTIDS", AAOBJECTIDS);

            return TTReportNqlObject.QueryObjects<AccountDocument.CheckForSameReceiptNumbers_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<AccountDocument.CashOfficeRevenueReportQuery_Class> CashOfficeRevenueReportQuery(DateTime STARTDATE, DateTime ENDDATE, Guid CASHOFFICE, int CASHOFFICECONTROL, Guid CASHIER, int CASHIERCONTROL, PaymentTypeCashCCEnum PAYMENTTYPE, int PAYMENTTYPECONTROL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTDOCUMENT"].QueryDefs["CashOfficeRevenueReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("CASHOFFICE", CASHOFFICE);
            paramList.Add("CASHOFFICECONTROL", CASHOFFICECONTROL);
            paramList.Add("CASHIER", CASHIER);
            paramList.Add("CASHIERCONTROL", CASHIERCONTROL);
            paramList.Add("PAYMENTTYPE", (int)PAYMENTTYPE);
            paramList.Add("PAYMENTTYPECONTROL", PAYMENTTYPECONTROL);

            return TTReportNqlObject.QueryObjects<AccountDocument.CashOfficeRevenueReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<AccountDocument.CashOfficeRevenueReportQuery_Class> CashOfficeRevenueReportQuery(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, Guid CASHOFFICE, int CASHOFFICECONTROL, Guid CASHIER, int CASHIERCONTROL, PaymentTypeCashCCEnum PAYMENTTYPE, int PAYMENTTYPECONTROL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTDOCUMENT"].QueryDefs["CashOfficeRevenueReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("CASHOFFICE", CASHOFFICE);
            paramList.Add("CASHOFFICECONTROL", CASHOFFICECONTROL);
            paramList.Add("CASHIER", CASHIER);
            paramList.Add("CASHIERCONTROL", CASHIERCONTROL);
            paramList.Add("PAYMENTTYPE", (int)PAYMENTTYPE);
            paramList.Add("PAYMENTTYPECONTROL", PAYMENTTYPECONTROL);

            return TTReportNqlObject.QueryObjects<AccountDocument.CashOfficeRevenueReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Açıklama alanı
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

    /// <summary>
    /// Hasta Durumu (Ayaktan/Yatan/Hepsi)
    /// </summary>
        public OutPatientInPatientBothEnum? PatientStatus
        {
            get { return (OutPatientInPatientBothEnum?)(int?)this["PATIENTSTATUS"]; }
            set { this["PATIENTSTATUS"] = value; }
        }

    /// <summary>
    /// Finansal Dökümanın oluşturulduğu tarih
    /// </summary>
        public DateTime? DocumentDate
        {
            get { return (DateTime?)this["DOCUMENTDATE"]; }
            set { this["DOCUMENTDATE"] = value; }
        }

    /// <summary>
    /// Finansal Döküman Numarası
    /// </summary>
        public string DocumentNo
        {
            get { return (string)this["DOCUMENTNO"]; }
            set { this["DOCUMENTNO"] = value; }
        }

    /// <summary>
    /// Muhasebe programına gidip gitmediği bilgisi
    /// </summary>
        public bool? SendToAccounting
        {
            get { return (bool?)this["SENDTOACCOUNTING"]; }
            set { this["SENDTOACCOUNTING"] = value; }
        }

    /// <summary>
    /// Finansal Dökümanın Tanımlama Numarası
    /// </summary>
        public long? DocumentID
        {
            get { return (long?)this["DOCUMENTID"]; }
            set { this["DOCUMENTID"] = value; }
        }

    /// <summary>
    /// Finansal dökümanın toplam tutarı
    /// </summary>
        public Currency? TotalPrice
        {
            get { return (Currency?)this["TOTALPRICE"]; }
            set { this["TOTALPRICE"] = value; }
        }

    /// <summary>
    /// Ödeme Tipi
    /// </summary>
        public PaymentTypeEnum? PaymentType
        {
            get { return (PaymentTypeEnum?)(int?)this["PAYMENTTYPE"]; }
            set { this["PAYMENTTYPE"] = value; }
        }

    /// <summary>
    /// Oluşturulma zamanı
    /// </summary>
        public DateTime? CreateDate
        {
            get { return (DateTime?)this["CREATEDATE"]; }
            set { this["CREATEDATE"] = value; }
        }

    /// <summary>
    /// İptal Tarihi
    /// </summary>
        public DateTime? CancelDate
        {
            get { return (DateTime?)this["CANCELDATE"]; }
            set { this["CANCELDATE"] = value; }
        }

    /// <summary>
    /// Vezne kullanıcısı ilişkisi
    /// </summary>
        public ResUser ResUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("RESUSER"); }
            set { this["RESUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public CashOfficeDefinition CashOffice
        {
            get { return (CashOfficeDefinition)((ITTObject)this).GetParent("CASHOFFICE"); }
            set { this["CASHOFFICE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Veznenin açılış kapanış izi ile ilişki
    /// </summary>
        public CashierLog CashierLog
        {
            get { return (CashierLog)((ITTObject)this).GetParent("CASHIERLOG"); }
            set { this["CASHIERLOG"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Hasta bazlı finansal işlemle ilişki
    /// </summary>
        public EpisodeAccountAction EpisodeAccountAction
        {
            get { return (EpisodeAccountAction)((ITTObject)this).GetParent("EPISODEACCOUNTACTION"); }
            set { this["EPISODEACCOUNTACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Genel finansal işlemlerle ilişki
    /// </summary>
        public AccountAction AccountAction
        {
            get { return (AccountAction)((ITTObject)this).GetParent("ACCOUNTACTION"); }
            set { this["ACCOUNTACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreatePaymentsCollectionViews()
        {
            _ChequePayments = new Cheque.ChildChequeCollection(_Payments, "ChequePayments");
            _CashPayment = new Cash.ChildCashCollection(_Payments, "CashPayment");
            _CreditCardPayments = new CreditCard.ChildCreditCardCollection(_Payments, "CreditCardPayments");
            _DebenturePayments = new Debenture.ChildDebentureCollection(_Payments, "DebenturePayments");
            _BankDecountPayments = new BankDecount.ChildBankDecountCollection(_Payments, "BankDecountPayments");
            _ValuablePaperPayments = new ValuablePaper.ChildValuablePaperCollection(_Payments, "ValuablePaperPayments");
        }

        virtual protected void CreatePaymentsCollection()
        {
            _Payments = new Payment.ChildPaymentCollection(this, new Guid("11e3d194-7816-4d72-a78b-54c5aa28e746"));
            CreatePaymentsCollectionViews();
            ((ITTChildObjectCollection)_Payments).GetChildren();
        }

        protected Payment.ChildPaymentCollection _Payments = null;
    /// <summary>
    /// Child collection for AccountDocument ile relation
    /// </summary>
        public Payment.ChildPaymentCollection Payments
        {
            get
            {
                if (_Payments == null)
                    CreatePaymentsCollection();
                return _Payments;
            }
        }

        private Cheque.ChildChequeCollection _ChequePayments = null;
    /// <summary>
    /// AccountDocument
    /// </summary>
        public Cheque.ChildChequeCollection ChequePayments
        {
            get
            {
                if (_Payments == null)
                    CreatePaymentsCollection();
                return _ChequePayments;
            }            
        }

        private Cash.ChildCashCollection _CashPayment = null;
    /// <summary>
    /// AccountDocument
    /// </summary>
        public Cash.ChildCashCollection CashPayment
        {
            get
            {
                if (_Payments == null)
                    CreatePaymentsCollection();
                return _CashPayment;
            }            
        }

        private CreditCard.ChildCreditCardCollection _CreditCardPayments = null;
    /// <summary>
    /// AccountDocument
    /// </summary>
        public CreditCard.ChildCreditCardCollection CreditCardPayments
        {
            get
            {
                if (_Payments == null)
                    CreatePaymentsCollection();
                return _CreditCardPayments;
            }            
        }

        private Debenture.ChildDebentureCollection _DebenturePayments = null;
    /// <summary>
    /// AccountDocument
    /// </summary>
        public Debenture.ChildDebentureCollection DebenturePayments
        {
            get
            {
                if (_Payments == null)
                    CreatePaymentsCollection();
                return _DebenturePayments;
            }            
        }

        private BankDecount.ChildBankDecountCollection _BankDecountPayments = null;
    /// <summary>
    /// AccountDocument
    /// </summary>
        public BankDecount.ChildBankDecountCollection BankDecountPayments
        {
            get
            {
                if (_Payments == null)
                    CreatePaymentsCollection();
                return _BankDecountPayments;
            }            
        }

        private ValuablePaper.ChildValuablePaperCollection _ValuablePaperPayments = null;
    /// <summary>
    /// AccountDocument
    /// </summary>
        public ValuablePaper.ChildValuablePaperCollection ValuablePaperPayments
        {
            get
            {
                if (_Payments == null)
                    CreatePaymentsCollection();
                return _ValuablePaperPayments;
            }            
        }

        virtual protected void CreateAccountDocumentGroupsCollectionViews()
        {
            _CollectedInvoiceDocumentGroups = new CollectedInvoiceDocumentGroup.ChildCollectedInvoiceDocumentGroupCollection(_AccountDocumentGroups, "CollectedInvoiceDocumentGroups");
            _PayerAdvancePaymentDocumentGroups = new PayerAdvancePaymentDocumentGroup.ChildPayerAdvancePaymentDocumentGroupCollection(_AccountDocumentGroups, "PayerAdvancePaymentDocumentGroups");
            _GeneralInvoiceDocumentGroups = new GeneralInvoiceDocumentGroup.ChildGeneralInvoiceDocumentGroupCollection(_AccountDocumentGroups, "GeneralInvoiceDocumentGroups");
            _AdvanceBackDocumentGroups = new AdvanceBackDocumentGroup.ChildAdvanceBackDocumentGroupCollection(_AccountDocumentGroups, "AdvanceBackDocumentGroups");
            _MainCashOfficeBackDocumentGroups = new MainCashOfficeBackDocumentGroup.ChildMainCashOfficeBackDocumentGroupCollection(_AccountDocumentGroups, "MainCashOfficeBackDocumentGroups");
            _PatientInvoiceDocumentGroups = new PatientInvoiceDocumentGroup.ChildPatientInvoiceDocumentGroupCollection(_AccountDocumentGroups, "PatientInvoiceDocumentGroups");
            _PayerPaymentDocumentGroups = new PayerPaymentDocumentGroup.ChildPayerPaymentDocumentGroupCollection(_AccountDocumentGroups, "PayerPaymentDocumentGroups");
            _CashOfficeReceiptDocumentGroups = new CashOfficeReceiptDocumentGroup.ChildCashOfficeReceiptDocumentGroupCollection(_AccountDocumentGroups, "CashOfficeReceiptDocumentGroups");
            _AdvanceDocumentGroups = new AdvanceDocumentGroup.ChildAdvanceDocumentGroupCollection(_AccountDocumentGroups, "AdvanceDocumentGroups");
            _ReceiptDocumentGroups = new ReceiptDocumentGroup.ChildReceiptDocumentGroupCollection(_AccountDocumentGroups, "ReceiptDocumentGroups");
            _ReceiptBackDocumentGroups = new ReceiptBackDocumentGroup.ChildReceiptBackDocumentGroupCollection(_AccountDocumentGroups, "ReceiptBackDocumentGroups");
            _DebenturePaymentDocumentGroups = new DebenturePaymentDocumentGroup.ChildDebenturePaymentDocumentGroupCollection(_AccountDocumentGroups, "DebenturePaymentDocumentGroups");
            _CashOfficeClosingDocumentGroups = new CashOfficeClosingDocumentGroup.ChildCashOfficeClosingDocumentGroupCollection(_AccountDocumentGroups, "CashOfficeClosingDocumentGroups");
            _SubCashOfficeReceiptDocumentGroups = new SubCashOfficeReceiptDocGroup.ChildSubCashOfficeReceiptDocGroupCollection(_AccountDocumentGroups, "SubCashOfficeReceiptDocumentGroups");
            _GeneralReceiptDocumentGroups = new GeneralReceiptDocumentGroup.ChildGeneralReceiptDocumentGroupCollection(_AccountDocumentGroups, "GeneralReceiptDocumentGroups");
        }

        virtual protected void CreateAccountDocumentGroupsCollection()
        {
            _AccountDocumentGroups = new AccountDocumentGroup.ChildAccountDocumentGroupCollection(this, new Guid("8ef21296-a846-41dd-8878-4bafce879bff"));
            CreateAccountDocumentGroupsCollectionViews();
            ((ITTChildObjectCollection)_AccountDocumentGroups).GetChildren();
        }

        protected AccountDocumentGroup.ChildAccountDocumentGroupCollection _AccountDocumentGroups = null;
    /// <summary>
    /// Child collection for Finansal Döküman türleriyle ilişki
    /// </summary>
        public AccountDocumentGroup.ChildAccountDocumentGroupCollection AccountDocumentGroups
        {
            get
            {
                if (_AccountDocumentGroups == null)
                    CreateAccountDocumentGroupsCollection();
                return _AccountDocumentGroups;
            }
        }

        private CollectedInvoiceDocumentGroup.ChildCollectedInvoiceDocumentGroupCollection _CollectedInvoiceDocumentGroups = null;
        public CollectedInvoiceDocumentGroup.ChildCollectedInvoiceDocumentGroupCollection CollectedInvoiceDocumentGroups
        {
            get
            {
                if (_AccountDocumentGroups == null)
                    CreateAccountDocumentGroupsCollection();
                return _CollectedInvoiceDocumentGroups;
            }            
        }

        private PayerAdvancePaymentDocumentGroup.ChildPayerAdvancePaymentDocumentGroupCollection _PayerAdvancePaymentDocumentGroups = null;
        public PayerAdvancePaymentDocumentGroup.ChildPayerAdvancePaymentDocumentGroupCollection PayerAdvancePaymentDocumentGroups
        {
            get
            {
                if (_AccountDocumentGroups == null)
                    CreateAccountDocumentGroupsCollection();
                return _PayerAdvancePaymentDocumentGroups;
            }            
        }

        private GeneralInvoiceDocumentGroup.ChildGeneralInvoiceDocumentGroupCollection _GeneralInvoiceDocumentGroups = null;
        public GeneralInvoiceDocumentGroup.ChildGeneralInvoiceDocumentGroupCollection GeneralInvoiceDocumentGroups
        {
            get
            {
                if (_AccountDocumentGroups == null)
                    CreateAccountDocumentGroupsCollection();
                return _GeneralInvoiceDocumentGroups;
            }            
        }

        private AdvanceBackDocumentGroup.ChildAdvanceBackDocumentGroupCollection _AdvanceBackDocumentGroups = null;
        public AdvanceBackDocumentGroup.ChildAdvanceBackDocumentGroupCollection AdvanceBackDocumentGroups
        {
            get
            {
                if (_AccountDocumentGroups == null)
                    CreateAccountDocumentGroupsCollection();
                return _AdvanceBackDocumentGroups;
            }            
        }

        private MainCashOfficeBackDocumentGroup.ChildMainCashOfficeBackDocumentGroupCollection _MainCashOfficeBackDocumentGroups = null;
        public MainCashOfficeBackDocumentGroup.ChildMainCashOfficeBackDocumentGroupCollection MainCashOfficeBackDocumentGroups
        {
            get
            {
                if (_AccountDocumentGroups == null)
                    CreateAccountDocumentGroupsCollection();
                return _MainCashOfficeBackDocumentGroups;
            }            
        }

        private PatientInvoiceDocumentGroup.ChildPatientInvoiceDocumentGroupCollection _PatientInvoiceDocumentGroups = null;
        public PatientInvoiceDocumentGroup.ChildPatientInvoiceDocumentGroupCollection PatientInvoiceDocumentGroups
        {
            get
            {
                if (_AccountDocumentGroups == null)
                    CreateAccountDocumentGroupsCollection();
                return _PatientInvoiceDocumentGroups;
            }            
        }

        private PayerPaymentDocumentGroup.ChildPayerPaymentDocumentGroupCollection _PayerPaymentDocumentGroups = null;
        public PayerPaymentDocumentGroup.ChildPayerPaymentDocumentGroupCollection PayerPaymentDocumentGroups
        {
            get
            {
                if (_AccountDocumentGroups == null)
                    CreateAccountDocumentGroupsCollection();
                return _PayerPaymentDocumentGroups;
            }            
        }

        private CashOfficeReceiptDocumentGroup.ChildCashOfficeReceiptDocumentGroupCollection _CashOfficeReceiptDocumentGroups = null;
        public CashOfficeReceiptDocumentGroup.ChildCashOfficeReceiptDocumentGroupCollection CashOfficeReceiptDocumentGroups
        {
            get
            {
                if (_AccountDocumentGroups == null)
                    CreateAccountDocumentGroupsCollection();
                return _CashOfficeReceiptDocumentGroups;
            }            
        }

        private AdvanceDocumentGroup.ChildAdvanceDocumentGroupCollection _AdvanceDocumentGroups = null;
        public AdvanceDocumentGroup.ChildAdvanceDocumentGroupCollection AdvanceDocumentGroups
        {
            get
            {
                if (_AccountDocumentGroups == null)
                    CreateAccountDocumentGroupsCollection();
                return _AdvanceDocumentGroups;
            }            
        }

        private ReceiptDocumentGroup.ChildReceiptDocumentGroupCollection _ReceiptDocumentGroups = null;
        public ReceiptDocumentGroup.ChildReceiptDocumentGroupCollection ReceiptDocumentGroups
        {
            get
            {
                if (_AccountDocumentGroups == null)
                    CreateAccountDocumentGroupsCollection();
                return _ReceiptDocumentGroups;
            }            
        }

        private ReceiptBackDocumentGroup.ChildReceiptBackDocumentGroupCollection _ReceiptBackDocumentGroups = null;
        public ReceiptBackDocumentGroup.ChildReceiptBackDocumentGroupCollection ReceiptBackDocumentGroups
        {
            get
            {
                if (_AccountDocumentGroups == null)
                    CreateAccountDocumentGroupsCollection();
                return _ReceiptBackDocumentGroups;
            }            
        }

        private DebenturePaymentDocumentGroup.ChildDebenturePaymentDocumentGroupCollection _DebenturePaymentDocumentGroups = null;
        public DebenturePaymentDocumentGroup.ChildDebenturePaymentDocumentGroupCollection DebenturePaymentDocumentGroups
        {
            get
            {
                if (_AccountDocumentGroups == null)
                    CreateAccountDocumentGroupsCollection();
                return _DebenturePaymentDocumentGroups;
            }            
        }

        private CashOfficeClosingDocumentGroup.ChildCashOfficeClosingDocumentGroupCollection _CashOfficeClosingDocumentGroups = null;
        public CashOfficeClosingDocumentGroup.ChildCashOfficeClosingDocumentGroupCollection CashOfficeClosingDocumentGroups
        {
            get
            {
                if (_AccountDocumentGroups == null)
                    CreateAccountDocumentGroupsCollection();
                return _CashOfficeClosingDocumentGroups;
            }            
        }

        private SubCashOfficeReceiptDocGroup.ChildSubCashOfficeReceiptDocGroupCollection _SubCashOfficeReceiptDocumentGroups = null;
        public SubCashOfficeReceiptDocGroup.ChildSubCashOfficeReceiptDocGroupCollection SubCashOfficeReceiptDocumentGroups
        {
            get
            {
                if (_AccountDocumentGroups == null)
                    CreateAccountDocumentGroupsCollection();
                return _SubCashOfficeReceiptDocumentGroups;
            }            
        }

        private GeneralReceiptDocumentGroup.ChildGeneralReceiptDocumentGroupCollection _GeneralReceiptDocumentGroups = null;
        public GeneralReceiptDocumentGroup.ChildGeneralReceiptDocumentGroupCollection GeneralReceiptDocumentGroups
        {
            get
            {
                if (_AccountDocumentGroups == null)
                    CreateAccountDocumentGroupsCollection();
                return _GeneralReceiptDocumentGroups;
            }            
        }

        virtual protected void CreatePatientPaymentDetailCollection()
        {
            _PatientPaymentDetail = new PatientPaymentDetail.ChildPatientPaymentDetailCollection(this, new Guid("0af8ed4c-2877-4b9e-ae86-8d172f67ada1"));
            ((ITTChildObjectCollection)_PatientPaymentDetail).GetChildren();
        }

        protected PatientPaymentDetail.ChildPatientPaymentDetailCollection _PatientPaymentDetail = null;
        public PatientPaymentDetail.ChildPatientPaymentDetailCollection PatientPaymentDetail
        {
            get
            {
                if (_PatientPaymentDetail == null)
                    CreatePatientPaymentDetailCollection();
                return _PatientPaymentDetail;
            }
        }

        virtual protected void CreateAPRTrxCollection()
        {
            _APRTrx = new APRTrx.ChildAPRTrxCollection(this, new Guid("551827fa-b9dd-4129-8973-959a03b1ac96"));
            ((ITTChildObjectCollection)_APRTrx).GetChildren();
        }

        protected APRTrx.ChildAPRTrxCollection _APRTrx = null;
    /// <summary>
    /// Child collection for AccountDocument ile relation
    /// </summary>
        public APRTrx.ChildAPRTrxCollection APRTrx
        {
            get
            {
                if (_APRTrx == null)
                    CreateAPRTrxCollection();
                return _APRTrx;
            }
        }

        virtual protected void CreateAccountVoucherDetailsCollection()
        {
            _AccountVoucherDetails = new AccountVoucherDetail.ChildAccountVoucherDetailCollection(this, new Guid("8ac896c0-0760-489d-be57-2007ac3982d1"));
            ((ITTChildObjectCollection)_AccountVoucherDetails).GetChildren();
        }

        protected AccountVoucherDetail.ChildAccountVoucherDetailCollection _AccountVoucherDetails = null;
        public AccountVoucherDetail.ChildAccountVoucherDetailCollection AccountVoucherDetails
        {
            get
            {
                if (_AccountVoucherDetails == null)
                    CreateAccountVoucherDetailsCollection();
                return _AccountVoucherDetails;
            }
        }

        protected AccountDocument(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected AccountDocument(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected AccountDocument(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected AccountDocument(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected AccountDocument(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ACCOUNTDOCUMENT", dataRow) { }
        protected AccountDocument(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ACCOUNTDOCUMENT", dataRow, isImported) { }
        public AccountDocument(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public AccountDocument(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public AccountDocument() : base() { }

    }
}

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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="InvoiceCollectionDetail")] 

    /// <summary>
    /// İcmal Detayı
    /// </summary>
    public  partial class InvoiceCollectionDetail : TTObject
    {
        public class InvoiceCollectionDetailList : TTObjectCollection<InvoiceCollectionDetail> { }
                    
        public class ChildInvoiceCollectionDetailCollection : TTObject.TTChildObjectCollection<InvoiceCollectionDetail>
        {
            public ChildInvoiceCollectionDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildInvoiceCollectionDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetICDByInjection_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? CurrentStateDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENTSTATEDEFID"]);
                }
            }

            public long? Episodeid
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EPISODEID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? OpeningDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OPENINGDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["OPENINGDATE"].DataType;
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

            public Object Invoiceprice
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["INVOICEPRICE"]);
                }
            }

            public Object Payment
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PAYMENT"]);
                }
            }

            public Object Deduction
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["DEDUCTION"]);
                }
            }

            public Object Status
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["STATUS"]);
                }
            }

            public Guid? Payerobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PAYEROBJECTID"]);
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

            public string Termname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TERMNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INVOICETERM"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Termstate
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TERMSTATE"]);
                }
            }

            public GetICDByInjection_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetICDByInjection_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetICDByInjection_Class() : base() { }
        }

        [Serializable] 

        public partial class GetByInvoiceCollection_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public long? Episodeid
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EPISODEID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? OpeningDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OPENINGDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["OPENINGDATE"].DataType;
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

            public Object Patientfullname
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PATIENTFULLNAME"]);
                }
            }

            public DateTime? Invoicedate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INVOICEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEDOCUMENT"].AllPropertyDefs["DOCUMENTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Invoiceno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INVOICENO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEDOCUMENT"].AllPropertyDefs["DOCUMENTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Invoiceprice
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["INVOICEPRICE"]);
                }
            }

            public Object Paymentprice
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PAYMENTPRICE"]);
                }
            }

            public Object Deduction
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["DEDUCTION"]);
                }
            }

            public Object Status
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["STATUS"]);
                }
            }

            public Object Medulatakipno
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["MEDULATAKIPNO"]);
                }
            }

            public Object Maxsepobjectid
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["MAXSEPOBJECTID"]);
                }
            }

            public GetByInvoiceCollection_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetByInvoiceCollection_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetByInvoiceCollection_Class() : base() { }
        }

        [Serializable] 

        public partial class InvoiceCollectionPreReportNQL_Class : TTReportNqlObject 
        {
            public Guid? InvoiceCollection
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["INVOICECOLLECTION"]);
                }
            }

            public long? Invoicecollectionno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INVOICECOLLECTIONNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INVOICECOLLECTION"].AllPropertyDefs["NO"].DataType;
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

            public int? PaymentDayLimit
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PAYMENTDAYLIMIT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERDEFINITION"].AllPropertyDefs["PAYMENTDAYLIMIT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public Object Invoicecount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["INVOICECOUNT"]);
                }
            }

            public Object Invoiceprice
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["INVOICEPRICE"]);
                }
            }

            public InvoiceCollectionPreReportNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public InvoiceCollectionPreReportNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected InvoiceCollectionPreReportNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class InvoiceCollectionListReportNQL_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public long? Episodeid
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EPISODEID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Specialityname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SPECIALITYNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SPECIALITYDEFINITION"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["OPENINGDATE"].DataType;
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

            public Object Patientname
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PATIENTNAME"]);
                }
            }

            public Guid? Pidobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PIDOBJECTID"]);
                }
            }

            public string Invoiceno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INVOICENO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEDOCUMENT"].AllPropertyDefs["DOCUMENTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Currency? Invoiceprice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INVOICEPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEDOCUMENT"].AllPropertyDefs["TOTALPRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Object Payertype
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PAYERTYPE"]);
                }
            }

            public InvoiceCollectionListReportNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public InvoiceCollectionListReportNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected InvoiceCollectionListReportNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class ICProceduresReportQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? Episodeobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODEOBJECTID"]);
                }
            }

            public long? Episodeid
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EPISODEID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? OpeningDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OPENINGDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["OPENINGDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? Patientobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PATIENTOBJECTID"]);
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

            public Object Patientname
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PATIENTNAME"]);
                }
            }

            public DateTime? BirthDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BIRTHDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["BIRTHDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
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

            public Guid? HomeTown
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["HOMETOWN"]);
                }
            }

            public Guid? HomeCity
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["HOMECITY"]);
                }
            }

            public string HomePhone
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HOMEPHONE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTIDENTITYANDADDRESS"].AllPropertyDefs["HOMEPHONE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string MobilePhone
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MOBILEPHONE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTIDENTITYANDADDRESS"].AllPropertyDefs["MOBILEPHONE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string BusinessPhone
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BUSINESSPHONE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTIDENTITYANDADDRESS"].AllPropertyDefs["BUSINESSPHONE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Pidobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PIDOBJECTID"]);
                }
            }

            public string Invoiceno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INVOICENO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEDOCUMENT"].AllPropertyDefs["DOCUMENTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? Invoicedate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INVOICEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEDOCUMENT"].AllPropertyDefs["DOCUMENTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Currency? Invoiceprice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INVOICEPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEDOCUMENT"].AllPropertyDefs["TOTALPRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

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

            public Object Payertype
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PAYERTYPE"]);
                }
            }

            public Object Medulatakipno
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["MEDULATAKIPNO"]);
                }
            }

            public ICProceduresReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public ICProceduresReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected ICProceduresReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class UnInvoicedExistQuery_Class : TTReportNqlObject 
        {
            public Object Counter
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["COUNTER"]);
                }
            }

            public UnInvoicedExistQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public UnInvoicedExistQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected UnInvoicedExistQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class ICProceduresAlphabeticReportQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? Episodeobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODEOBJECTID"]);
                }
            }

            public long? Episodeid
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EPISODEID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? OpeningDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OPENINGDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["OPENINGDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? Patientobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PATIENTOBJECTID"]);
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

            public Object Patientname
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PATIENTNAME"]);
                }
            }

            public DateTime? BirthDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BIRTHDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["BIRTHDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
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

            public Guid? HomeTown
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["HOMETOWN"]);
                }
            }

            public Guid? HomeCity
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["HOMECITY"]);
                }
            }

            public string HomePhone
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HOMEPHONE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTIDENTITYANDADDRESS"].AllPropertyDefs["HOMEPHONE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string MobilePhone
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MOBILEPHONE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTIDENTITYANDADDRESS"].AllPropertyDefs["MOBILEPHONE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string BusinessPhone
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BUSINESSPHONE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTIDENTITYANDADDRESS"].AllPropertyDefs["BUSINESSPHONE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Pidobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PIDOBJECTID"]);
                }
            }

            public string Invoiceno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INVOICENO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEDOCUMENT"].AllPropertyDefs["DOCUMENTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? Invoicedate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INVOICEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEDOCUMENT"].AllPropertyDefs["DOCUMENTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Currency? Invoiceprice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INVOICEPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEDOCUMENT"].AllPropertyDefs["TOTALPRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

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

            public Object Payertype
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PAYERTYPE"]);
                }
            }

            public Object Medulatakipno
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["MEDULATAKIPNO"]);
                }
            }

            public ICProceduresAlphabeticReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public ICProceduresAlphabeticReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected ICProceduresAlphabeticReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class ICListAlphabeticReportNQL_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public long? Episodeid
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EPISODEID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Specialityname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SPECIALITYNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SPECIALITYDEFINITION"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["OPENINGDATE"].DataType;
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

            public Object Patientname
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PATIENTNAME"]);
                }
            }

            public Guid? Pidobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PIDOBJECTID"]);
                }
            }

            public string Invoiceno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INVOICENO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEDOCUMENT"].AllPropertyDefs["DOCUMENTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Currency? Invoiceprice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INVOICEPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEDOCUMENT"].AllPropertyDefs["TOTALPRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Object Payertype
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PAYERTYPE"]);
                }
            }

            public ICListAlphabeticReportNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public ICListAlphabeticReportNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected ICListAlphabeticReportNQL_Class() : base() { }
        }

        public static class States
        {
    /// <summary>
    /// Faturalandı
    /// </summary>
            public static Guid Invoiced { get { return new Guid("225d3844-0ea6-4c3f-a530-cddc203172db"); } }
    /// <summary>
    /// Kısmen Ödendi
    /// </summary>
            public static Guid PartialPaid { get { return new Guid("64f6614a-2f6d-4496-8744-9823514604f0"); } }
    /// <summary>
    /// Ödendi
    /// </summary>
            public static Guid Paid { get { return new Guid("cb9ce885-ec1a-4e45-b31d-f6cf99b28f00"); } }
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("4d60f957-5b22-4f06-ae53-680fd7bf622a"); } }
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancelled { get { return new Guid("883b6d4f-18cf-46ff-a5ef-0a58308b6e97"); } }
        }

        public static BindingList<InvoiceCollectionDetail> GetInvoiceCollectionDetailByInvoiceCollectionID(TTObjectContext objectContext, Guid INVOICECOLLECTION)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INVOICECOLLECTIONDETAIL"].QueryDefs["GetInvoiceCollectionDetailByInvoiceCollectionID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("INVOICECOLLECTION", INVOICECOLLECTION);

            return ((ITTQuery)objectContext).QueryObjects<InvoiceCollectionDetail>(queryDef, paramList);
        }

        public static BindingList<InvoiceCollectionDetail.GetICDByInjection_Class> GetICDByInjection(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INVOICECOLLECTIONDETAIL"].QueryDefs["GetICDByInjection"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<InvoiceCollectionDetail.GetICDByInjection_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<InvoiceCollectionDetail.GetICDByInjection_Class> GetICDByInjection(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INVOICECOLLECTIONDETAIL"].QueryDefs["GetICDByInjection"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<InvoiceCollectionDetail.GetICDByInjection_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<InvoiceCollectionDetail.GetByInvoiceCollection_Class> GetByInvoiceCollection(Guid INVOICECOLLECTION, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INVOICECOLLECTIONDETAIL"].QueryDefs["GetByInvoiceCollection"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("INVOICECOLLECTION", INVOICECOLLECTION);

            return TTReportNqlObject.QueryObjects<InvoiceCollectionDetail.GetByInvoiceCollection_Class>(queryDef, paramList, pi);
        }

        public static BindingList<InvoiceCollectionDetail.GetByInvoiceCollection_Class> GetByInvoiceCollection(TTObjectContext objectContext, Guid INVOICECOLLECTION, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INVOICECOLLECTIONDETAIL"].QueryDefs["GetByInvoiceCollection"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("INVOICECOLLECTION", INVOICECOLLECTION);

            return TTReportNqlObject.QueryObjects<InvoiceCollectionDetail.GetByInvoiceCollection_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<InvoiceCollectionDetail.InvoiceCollectionPreReportNQL_Class> InvoiceCollectionPreReportNQL(Guid ICOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INVOICECOLLECTIONDETAIL"].QueryDefs["InvoiceCollectionPreReportNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ICOBJECTID", ICOBJECTID);

            return TTReportNqlObject.QueryObjects<InvoiceCollectionDetail.InvoiceCollectionPreReportNQL_Class>(queryDef, paramList, pi);
        }

        public static BindingList<InvoiceCollectionDetail.InvoiceCollectionPreReportNQL_Class> InvoiceCollectionPreReportNQL(TTObjectContext objectContext, Guid ICOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INVOICECOLLECTIONDETAIL"].QueryDefs["InvoiceCollectionPreReportNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ICOBJECTID", ICOBJECTID);

            return TTReportNqlObject.QueryObjects<InvoiceCollectionDetail.InvoiceCollectionPreReportNQL_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<InvoiceCollectionDetail.InvoiceCollectionListReportNQL_Class> InvoiceCollectionListReportNQL(Guid ICOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INVOICECOLLECTIONDETAIL"].QueryDefs["InvoiceCollectionListReportNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ICOBJECTID", ICOBJECTID);

            return TTReportNqlObject.QueryObjects<InvoiceCollectionDetail.InvoiceCollectionListReportNQL_Class>(queryDef, paramList, pi);
        }

        public static BindingList<InvoiceCollectionDetail.InvoiceCollectionListReportNQL_Class> InvoiceCollectionListReportNQL(TTObjectContext objectContext, Guid ICOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INVOICECOLLECTIONDETAIL"].QueryDefs["InvoiceCollectionListReportNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ICOBJECTID", ICOBJECTID);

            return TTReportNqlObject.QueryObjects<InvoiceCollectionDetail.InvoiceCollectionListReportNQL_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<InvoiceCollectionDetail.ICProceduresReportQuery_Class> ICProceduresReportQuery(Guid ICOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INVOICECOLLECTIONDETAIL"].QueryDefs["ICProceduresReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ICOBJECTID", ICOBJECTID);

            return TTReportNqlObject.QueryObjects<InvoiceCollectionDetail.ICProceduresReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<InvoiceCollectionDetail.ICProceduresReportQuery_Class> ICProceduresReportQuery(TTObjectContext objectContext, Guid ICOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INVOICECOLLECTIONDETAIL"].QueryDefs["ICProceduresReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ICOBJECTID", ICOBJECTID);

            return TTReportNqlObject.QueryObjects<InvoiceCollectionDetail.ICProceduresReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<InvoiceCollectionDetail.UnInvoicedExistQuery_Class> UnInvoicedExistQuery(Guid ICOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INVOICECOLLECTIONDETAIL"].QueryDefs["UnInvoicedExistQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ICOBJECTID", ICOBJECTID);

            return TTReportNqlObject.QueryObjects<InvoiceCollectionDetail.UnInvoicedExistQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<InvoiceCollectionDetail.UnInvoicedExistQuery_Class> UnInvoicedExistQuery(TTObjectContext objectContext, Guid ICOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INVOICECOLLECTIONDETAIL"].QueryDefs["UnInvoicedExistQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ICOBJECTID", ICOBJECTID);

            return TTReportNqlObject.QueryObjects<InvoiceCollectionDetail.UnInvoicedExistQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<InvoiceCollectionDetail.ICProceduresAlphabeticReportQuery_Class> ICProceduresAlphabeticReportQuery(Guid ICOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INVOICECOLLECTIONDETAIL"].QueryDefs["ICProceduresAlphabeticReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ICOBJECTID", ICOBJECTID);

            return TTReportNqlObject.QueryObjects<InvoiceCollectionDetail.ICProceduresAlphabeticReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<InvoiceCollectionDetail.ICProceduresAlphabeticReportQuery_Class> ICProceduresAlphabeticReportQuery(TTObjectContext objectContext, Guid ICOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INVOICECOLLECTIONDETAIL"].QueryDefs["ICProceduresAlphabeticReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ICOBJECTID", ICOBJECTID);

            return TTReportNqlObject.QueryObjects<InvoiceCollectionDetail.ICProceduresAlphabeticReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<InvoiceCollectionDetail.ICListAlphabeticReportNQL_Class> ICListAlphabeticReportNQL(Guid ICOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INVOICECOLLECTIONDETAIL"].QueryDefs["ICListAlphabeticReportNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ICOBJECTID", ICOBJECTID);

            return TTReportNqlObject.QueryObjects<InvoiceCollectionDetail.ICListAlphabeticReportNQL_Class>(queryDef, paramList, pi);
        }

        public static BindingList<InvoiceCollectionDetail.ICListAlphabeticReportNQL_Class> ICListAlphabeticReportNQL(TTObjectContext objectContext, Guid ICOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INVOICECOLLECTIONDETAIL"].QueryDefs["ICListAlphabeticReportNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ICOBJECTID", ICOBJECTID);

            return TTReportNqlObject.QueryObjects<InvoiceCollectionDetail.ICListAlphabeticReportNQL_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// İcmale Atılma Tarihi
    /// </summary>
        public DateTime? CreateDate
        {
            get { return (DateTime?)this["CREATEDATE"]; }
            set { this["CREATEDATE"] = value; }
        }

    /// <summary>
    /// Ödeme Tutarı
    /// </summary>
        public Currency? Payment
        {
            get { return (Currency?)this["PAYMENT"]; }
            set { this["PAYMENT"] = value; }
        }

    /// <summary>
    /// Kesinti Tutarı
    /// </summary>
        public Currency? Deduction
        {
            get { return (Currency?)this["DEDUCTION"]; }
            set { this["DEDUCTION"] = value; }
        }

    /// <summary>
    /// Son state geçinini yapan kullanıcı
    /// </summary>
        public ResUser CreateUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("CREATEUSER"); }
            set { this["CREATEUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Fatura İcmal
    /// </summary>
        public InvoiceCollection InvoiceCollection
        {
            get { return (InvoiceCollection)((ITTObject)this).GetParent("INVOICECOLLECTION"); }
            set { this["INVOICECOLLECTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Episode Episode
        {
            get { return (Episode)((ITTObject)this).GetParent("EPISODE"); }
            set { this["EPISODE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public InvoiceCollectionDetail NewInvoiceCollectionDetail
        {
            get { return (InvoiceCollectionDetail)((ITTObject)this).GetParent("NEWINVOICECOLLECTIONDETAIL"); }
            set { this["NEWINVOICECOLLECTIONDETAIL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Fatura Dökümanı
    /// </summary>
        public PayerInvoiceDocument PayerInvoiceDocument
        {
            get { return (PayerInvoiceDocument)((ITTObject)this).GetParent("PAYERINVOICEDOCUMENT"); }
            set { this["PAYERINVOICEDOCUMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateSubEpisodeProtocolsCollection()
        {
            _SubEpisodeProtocols = new SubEpisodeProtocol.ChildSubEpisodeProtocolCollection(this, new Guid("26b74767-a357-4916-bf35-f5401ee313a0"));
            ((ITTChildObjectCollection)_SubEpisodeProtocols).GetChildren();
        }

        protected SubEpisodeProtocol.ChildSubEpisodeProtocolCollection _SubEpisodeProtocols = null;
    /// <summary>
    /// Child collection for İcmal Detay
    /// </summary>
        public SubEpisodeProtocol.ChildSubEpisodeProtocolCollection SubEpisodeProtocols
        {
            get
            {
                if (_SubEpisodeProtocols == null)
                    CreateSubEpisodeProtocolsCollection();
                return _SubEpisodeProtocols;
            }
        }

        virtual protected void CreateCancelledInvoicesCollection()
        {
            _CancelledInvoices = new CancelledInvoice.ChildCancelledInvoiceCollection(this, new Guid("f28d393d-ff4b-4b1f-8bf1-967e1d7f5a47"));
            ((ITTChildObjectCollection)_CancelledInvoices).GetChildren();
        }

        protected CancelledInvoice.ChildCancelledInvoiceCollection _CancelledInvoices = null;
        public CancelledInvoice.ChildCancelledInvoiceCollection CancelledInvoices
        {
            get
            {
                if (_CancelledInvoices == null)
                    CreateCancelledInvoicesCollection();
                return _CancelledInvoices;
            }
        }

        virtual protected void CreatePIPDetailsCollection()
        {
            _PIPDetails = new PayerInvoicePaymentDetail.ChildPayerInvoicePaymentDetailCollection(this, new Guid("616478ea-766b-4d94-b8d4-54430a4225b3"));
            ((ITTChildObjectCollection)_PIPDetails).GetChildren();
        }

        protected PayerInvoicePaymentDetail.ChildPayerInvoicePaymentDetailCollection _PIPDetails = null;
        public PayerInvoicePaymentDetail.ChildPayerInvoicePaymentDetailCollection PIPDetails
        {
            get
            {
                if (_PIPDetails == null)
                    CreatePIPDetailsCollection();
                return _PIPDetails;
            }
        }

        virtual protected void CreateOriginalInvoiceCollecitonCollection()
        {
            _OriginalInvoiceColleciton = new InvoiceCollectionDetail.ChildInvoiceCollectionDetailCollection(this, new Guid("970cc3ec-e8e4-44e4-a3a6-e45b259abd94"));
            ((ITTChildObjectCollection)_OriginalInvoiceColleciton).GetChildren();
        }

        protected InvoiceCollectionDetail.ChildInvoiceCollectionDetailCollection _OriginalInvoiceColleciton = null;
        public InvoiceCollectionDetail.ChildInvoiceCollectionDetailCollection OriginalInvoiceColleciton
        {
            get
            {
                if (_OriginalInvoiceColleciton == null)
                    CreateOriginalInvoiceCollecitonCollection();
                return _OriginalInvoiceColleciton;
            }
        }

        protected InvoiceCollectionDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected InvoiceCollectionDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected InvoiceCollectionDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected InvoiceCollectionDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected InvoiceCollectionDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "INVOICECOLLECTIONDETAIL", dataRow) { }
        protected InvoiceCollectionDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "INVOICECOLLECTIONDETAIL", dataRow, isImported) { }
        public InvoiceCollectionDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public InvoiceCollectionDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public InvoiceCollectionDetail() : base() { }

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
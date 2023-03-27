
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="AccountTransaction")] 

    /// <summary>
    /// İşlem Hareketi
    /// </summary>
    public  partial class AccountTransaction : TTObject
    {
        public class AccountTransactionList : TTObjectCollection<AccountTransaction> { }
                    
        public class ChildAccountTransactionCollection : TTObject.TTChildObjectCollection<AccountTransaction>
        {
            public ChildAccountTransactionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildAccountTransactionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class OLAP_GetSubactionAccTransaction_Class : TTReportNqlObject 
        {
            public Object Nqlcolumn
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["NQLCOLUMN"]);
                }
            }

            public OLAP_GetSubactionAccTransaction_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetSubactionAccTransaction_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetSubactionAccTransaction_Class() : base() { }
        }

        [Serializable] 

        public partial class GetToBeNewTrxsByEpisode_Class : TTReportNqlObject 
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

            public double? TotalDiscountPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOTALDISCOUNTPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["TOTALDISCOUNTPRICE"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public double? UnitPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNITPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["UNITPRICE"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public string ExternalCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXTERNALCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["EXTERNALCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public double? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["AMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public PackageOutReasonEnum? PackageOutReason
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PACKAGEOUTREASON"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["PACKAGEOUTREASON"].DataType;
                    return (PackageOutReasonEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? TransactionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TRANSACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["TRANSACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? InvoiceInclusion
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INVOICEINCLUSION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["INVOICEINCLUSION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? MedulaInfoChangedByUser
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULAINFOCHANGEDBYUSER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["MEDULAINFOCHANGEDBYUSER"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? MedulaInfoUpdated
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULAINFOUPDATED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["MEDULAINFOUPDATED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string UserNote
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["USERNOTE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["USERNOTE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string MedulaProcessNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULAPROCESSNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["MEDULAPROCESSNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? Id
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string MedulaResultCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULARESULTCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["MEDULARESULTCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string MedulaResultMessage
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULARESULTMESSAGE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["MEDULARESULTMESSAGE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Currency? MedulaPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULAPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["MEDULAPRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public double? UnitPriceOrg
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNITPRICEORG"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["UNITPRICEORG"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public string MedulaDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULADESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["MEDULADESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string MedulaBedNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULABEDNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["MEDULABEDNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? PurchaseDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PURCHASEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["PURCHASEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Barcode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BARCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["BARCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ProducerCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRODUCERCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["PRODUCERCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public SendToENabizEnum? Nabiz700Status
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NABIZ700STATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["NABIZ700STATUS"].DataType;
                    return (SendToENabizEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string NabizResultCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NABIZRESULTCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["NABIZRESULTCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string NabizResultMessage
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NABIZRESULTMESSAGE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["NABIZRESULTMESSAGE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? UTSUsageCommitment
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UTSUSAGECOMMITMENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["UTSUSAGECOMMITMENT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string MedulaAccessionNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULAACCESSIONNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["MEDULAACCESSIONNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string MedulaDealerNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULADEALERNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["MEDULADEALERNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public SurgeryLeftRight? Position
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["POSITION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["POSITION"].DataType;
                    return (SurgeryLeftRight?)(int)dataType.ConvertValue(val);
                }
            }

            public GetToBeNewTrxsByEpisode_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetToBeNewTrxsByEpisode_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetToBeNewTrxsByEpisode_Class() : base() { }
        }

        [Serializable] 

        public partial class GetIncomesFromDepartment_Class : TTReportNqlObject 
        {
            public string Department
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DEPARTMENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Patienttotalprice
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PATIENTTOTALPRICE"]);
                }
            }

            public Object Payertotalprice
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PAYERTOTALPRICE"]);
                }
            }

            public GetIncomesFromDepartment_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetIncomesFromDepartment_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetIncomesFromDepartment_Class() : base() { }
        }

        [Serializable] 

        public partial class DetailedRevenueListProcedureQuery_Class : TTReportNqlObject 
        {
            public Guid? Procedure
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PROCEDURE"]);
                }
            }

            public Object Patientprice
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PATIENTPRICE"]);
                }
            }

            public Object Payerprice
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PAYERPRICE"]);
                }
            }

            public DetailedRevenueListProcedureQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public DetailedRevenueListProcedureQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected DetailedRevenueListProcedureQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetMaterialListByDateAndDepartment_Class : TTReportNqlObject 
        {
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

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public double? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["AMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public Object Totalprice
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOTALPRICE"]);
                }
            }

            public string Department
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DEPARTMENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Smobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SMOBJECTID"]);
                }
            }

            public GetMaterialListByDateAndDepartment_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMaterialListByDateAndDepartment_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMaterialListByDateAndDepartment_Class() : base() { }
        }

        [Serializable] 

        public partial class GetNotInvoicedPatientListByPatientStatus_Class : TTReportNqlObject 
        {
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

            public string Resource
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESOURCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["ADMISSIONRESOURCE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Payer
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PAYER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetNotInvoicedPatientListByPatientStatus_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetNotInvoicedPatientListByPatientStatus_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetNotInvoicedPatientListByPatientStatus_Class() : base() { }
        }

        [Serializable] 

        public partial class DetailedRevenueListMaterialQuery_Class : TTReportNqlObject 
        {
            public Object Patientprice
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PATIENTPRICE"]);
                }
            }

            public Object Payerprice
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PAYERPRICE"]);
                }
            }

            public DetailedRevenueListMaterialQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public DetailedRevenueListMaterialQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected DetailedRevenueListMaterialQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetMaterialTrxsByHospitalProtocolNo_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public DateTime? TransactionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TRANSACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["TRANSACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public double? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["AMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public double? UnitPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNITPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["UNITPRICE"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ExternalCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXTERNALCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRICINGDETAILDEFINITION"].AllPropertyDefs["EXTERNALCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public String Status
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STATUS"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public GetMaterialTrxsByHospitalProtocolNo_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMaterialTrxsByHospitalProtocolNo_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMaterialTrxsByHospitalProtocolNo_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPatientParticipationTransactions_Class : TTReportNqlObject 
        {
            public Object Patientname
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PATIENTNAME"]);
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

            public DateTime? TransactionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TRANSACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["TRANSACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Object Price
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PRICE"]);
                }
            }

            public GetPatientParticipationTransactions_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPatientParticipationTransactions_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPatientParticipationTransactions_Class() : base() { }
        }

        [Serializable] 

        public partial class CollectedInvoiceProcedureDetailReportQueryCheck_Class : TTReportNqlObject 
        {
            public string Specialitycode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SPECIALITYCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SPECIALITYDEFINITION"].AllPropertyDefs["CODE"].DataType;
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

            public Object Year
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["YEAR"]);
                }
            }

            public Object Month
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["MONTH"]);
                }
            }

            public Object Day
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["DAY"]);
                }
            }

            public string ExternalCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXTERNALCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["EXTERNALCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public Object Patientname
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PATIENTNAME"]);
                }
            }

            public Guid? Sex
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SEX"]);
                }
            }

            public Object Homephone
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["HOMEPHONE"]);
                }
            }

            public Object Homeaddress
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["HOMEADDRESS"]);
                }
            }

            public Object Hometown
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["HOMETOWN"]);
                }
            }

            public Object Homecity
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["HOMECITY"]);
                }
            }

            public Guid? Pobjid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["POBJID"]);
                }
            }

            public Guid? Eobjid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EOBJID"]);
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

            public DateTime? HospitalInPatientDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HOSPITALINPATIENTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["HOSPITALINPATIENTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? HospitalDischargeDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HOSPITALDISCHARGEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["HOSPITALDISCHARGEDATE"].DataType;
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

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Amount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["AMOUNT"]);
                }
            }

            public double? UnitPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNITPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["UNITPRICE"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public Object Totalprice
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOTALPRICE"]);
                }
            }

            public string DocumentNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCUMENTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COLLECTEDINVOICEDOCUMENT"].AllPropertyDefs["DOCUMENTNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COLLECTEDINVOICEDOCUMENT"].AllPropertyDefs["DOCUMENTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public OutPatientInPatientEnum? PATIENTSTATUS
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTSTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COLLECTEDINVOICE"].AllPropertyDefs["PATIENTSTATUS"].DataType;
                    return (OutPatientInPatientEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public CollectedInvoiceProcedureDetailReportQueryCheck_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public CollectedInvoiceProcedureDetailReportQueryCheck_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected CollectedInvoiceProcedureDetailReportQueryCheck_Class() : base() { }
        }

        [Serializable] 

        public partial class GetProcedureTrxsByHospitalProtocolNo_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public DateTime? TransactionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TRANSACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["TRANSACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public double? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["AMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public double? UnitPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNITPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["UNITPRICE"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ExternalCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXTERNALCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRICINGDETAILDEFINITION"].AllPropertyDefs["EXTERNALCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public String Status
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STATUS"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public long? Actionid
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public GetProcedureTrxsByHospitalProtocolNo_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetProcedureTrxsByHospitalProtocolNo_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetProcedureTrxsByHospitalProtocolNo_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDrugTrxsByHospitalProtocolNo_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public DateTime? TransactionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TRANSACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["TRANSACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public double? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["AMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public double? UnitPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNITPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["UNITPRICE"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ExternalCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXTERNALCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRICINGDETAILDEFINITION"].AllPropertyDefs["EXTERNALCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public String Status
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STATUS"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public GetDrugTrxsByHospitalProtocolNo_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDrugTrxsByHospitalProtocolNo_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDrugTrxsByHospitalProtocolNo_Class() : base() { }
        }

        [Serializable] 

        public partial class GetProcedureIncomesByMasterResource_Class : TTReportNqlObject 
        {
            public Guid? Depobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DEPOBJECTID"]);
                }
            }

            public string Department
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DEPARTMENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
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

            public APRTypeEnum? Type
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTPAYABLERECEIVABLE"].AllPropertyDefs["TYPE"].DataType;
                    return (APRTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public GetProcedureIncomesByMasterResource_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetProcedureIncomesByMasterResource_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetProcedureIncomesByMasterResource_Class() : base() { }
        }

        [Serializable] 

        public partial class CollInvoiceDetailedRevenueListMaterialQuery_Class : TTReportNqlObject 
        {
            public Object Patientprice
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PATIENTPRICE"]);
                }
            }

            public Object Payerprice
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PAYERPRICE"]);
                }
            }

            public CollInvoiceDetailedRevenueListMaterialQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public CollInvoiceDetailedRevenueListMaterialQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected CollInvoiceDetailedRevenueListMaterialQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetMedulaDontSendDrugTrxsByDate_Class : TTReportNqlObject 
        {
            public double? Tutar
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TUTAR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["UNITPRICE"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public double? Adet
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADET"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["AMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public string Aciklama
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACIKLAMA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Kod
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KOD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["EXTERNALCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? Protocolno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROTOCOLNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["HOSPITALPROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public GetMedulaDontSendDrugTrxsByDate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMedulaDontSendDrugTrxsByDate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMedulaDontSendDrugTrxsByDate_Class() : base() { }
        }

        [Serializable] 

        public partial class GetMedulaDontSendProcedureTrxsByDate_Class : TTReportNqlObject 
        {
            public double? Tutar
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TUTAR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["UNITPRICE"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public double? Adet
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADET"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["AMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public string Aciklama
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACIKLAMA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Kod
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KOD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["EXTERNALCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? Protocolno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROTOCOLNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["HOSPITALPROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public GetMedulaDontSendProcedureTrxsByDate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMedulaDontSendProcedureTrxsByDate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMedulaDontSendProcedureTrxsByDate_Class() : base() { }
        }

        [Serializable] 

        public partial class GetMedulaDontSendMaterialTrxsByDate_Class : TTReportNqlObject 
        {
            public double? Tutar
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TUTAR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["UNITPRICE"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public double? Adet
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADET"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["AMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public string Aciklama
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACIKLAMA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Kod
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KOD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["EXTERNALCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? Protocolno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROTOCOLNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["HOSPITALPROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public GetMedulaDontSendMaterialTrxsByDate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMedulaDontSendMaterialTrxsByDate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMedulaDontSendMaterialTrxsByDate_Class() : base() { }
        }

        [Serializable] 

        public partial class GetTransactionsForInvoiceBySEP_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Object Basetype
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["BASETYPE"]);
                }
            }

            public Object Medulatype
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["MEDULATYPE"]);
                }
            }

            public Guid? SubEpisode
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SUBEPISODE"]);
                }
            }

            public long? Id
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public Guid? CurrentStateDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENTSTATEDEFID"]);
                }
            }

            public Object Statename
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["STATENAME"]);
                }
            }

            public Object Statetext
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["STATETEXT"]);
                }
            }

            public string ExternalCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXTERNALCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["EXTERNALCODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? TransactionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TRANSACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["TRANSACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Object Unitprice
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["UNITPRICE"]);
                }
            }

            public double? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["AMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public Object Totalprice
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOTALPRICE"]);
                }
            }

            public string MedulaProcessNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULAPROCESSNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["MEDULAPROCESSNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Currency? MedulaPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULAPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["MEDULAPRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Object Diffprice
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["DIFFPRICE"]);
                }
            }

            public string Packagedefinition
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PACKAGEDEFINITION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PACKAGEDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string MedulaResultCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULARESULTCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["MEDULARESULTCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string MedulaResultMessage
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULARESULTMESSAGE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["MEDULARESULTMESSAGE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? OzelDurum
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OZELDURUM"]);
                }
            }

            public Guid? AyniFarkliKesi
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["AYNIFARKLIKESI"]);
                }
            }

            public string UserNote
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["USERNOTE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["USERNOTE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? InvoiceInclusion
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INVOICEINCLUSION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["INVOICEINCLUSION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public Object Doctor
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["DOCTOR"]);
                }
            }

            public Object Totalpayment
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOTALPAYMENT"]);
                }
            }

            public string MedulaReportNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULAREPORTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].AllPropertyDefs["MEDULAREPORTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string MedulaBedNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULABEDNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["MEDULABEDNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Procedurestate
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PROCEDURESTATE"]);
                }
            }

            public Object Procedurestateid
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PROCEDURESTATEID"]);
                }
            }

            public Object Eastate
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["EASTATE"]);
                }
            }

            public Object Eastateid
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["EASTATEID"]);
                }
            }

            public Object Suttype
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["SUTTYPE"]);
                }
            }

            public Boolean? Blocking
            {
                get
                {
                    return Convert.ToBoolean(Globals.FromDBValue(_dataRow["BLOCKING"]));
                }
            }

            public bool? UTSUsageCommitment
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UTSUSAGECOMMITMENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["UTSUSAGECOMMITMENT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public Guid? Spobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SPOBJECTID"]);
                }
            }

            public Guid? Spobjectdefid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SPOBJECTDEFID"]);
                }
            }

            public SendToENabizEnum? Nabiz700Status
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NABIZ700STATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["NABIZ700STATUS"].DataType;
                    return (SendToENabizEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string NabizResultCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NABIZRESULTCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["NABIZRESULTCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string NabizResultMessage
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NABIZRESULTMESSAGE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["NABIZRESULTMESSAGE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public SurgeryLeftRight? Position
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["POSITION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["POSITION"].DataType;
                    return (SurgeryLeftRight?)(int)dataType.ConvertValue(val);
                }
            }

            public Object Appdate
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["APPDATE"]);
                }
            }

            public GetTransactionsForInvoiceBySEP_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetTransactionsForInvoiceBySEP_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetTransactionsForInvoiceBySEP_Class() : base() { }
        }

        [Serializable] 

        public partial class GetMaterialIncomesByMasterResource_Class : TTReportNqlObject 
        {
            public Guid? Depobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DEPOBJECTID"]);
                }
            }

            public string Department
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DEPARTMENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
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

            public APRTypeEnum? Type
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTPAYABLERECEIVABLE"].AllPropertyDefs["TYPE"].DataType;
                    return (APRTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public GetMaterialIncomesByMasterResource_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMaterialIncomesByMasterResource_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMaterialIncomesByMasterResource_Class() : base() { }
        }

        [Serializable] 

        public partial class GetMaterialIncomesByRessection_Class : TTReportNqlObject 
        {
            public Guid? Depobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DEPOBJECTID"]);
                }
            }

            public string Department
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DEPARTMENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
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

            public APRTypeEnum? Type
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTPAYABLERECEIVABLE"].AllPropertyDefs["TYPE"].DataType;
                    return (APRTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public GetMaterialIncomesByRessection_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMaterialIncomesByRessection_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMaterialIncomesByRessection_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDrugIncomesByRessection_Class : TTReportNqlObject 
        {
            public Object Depobjectid
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["DEPOBJECTID"]);
                }
            }

            public Object Department
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["DEPARTMENT"]);
                }
            }

            public Object Totalprice
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOTALPRICE"]);
                }
            }

            public APRTypeEnum? Type
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTPAYABLERECEIVABLE"].AllPropertyDefs["TYPE"].DataType;
                    return (APRTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public GetDrugIncomesByRessection_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDrugIncomesByRessection_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDrugIncomesByRessection_Class() : base() { }
        }

        [Serializable] 

        public partial class GetCountForMedulaBySEP_Class : TTReportNqlObject 
        {
            public Object Count
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["COUNT"]);
                }
            }

            public GetCountForMedulaBySEP_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetCountForMedulaBySEP_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetCountForMedulaBySEP_Class() : base() { }
        }

        [Serializable] 

        public partial class GetMaterialTrxsBySEPAndCode_Class : TTReportNqlObject 
        {
            public Guid? SubActionMaterial
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SUBACTIONMATERIAL"]);
                }
            }

            public GetMaterialTrxsBySEPAndCode_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMaterialTrxsBySEPAndCode_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMaterialTrxsBySEPAndCode_Class() : base() { }
        }

        [Serializable] 

        public partial class GetProcedureIncomesByRessection_Class : TTReportNqlObject 
        {
            public Guid? Depobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DEPOBJECTID"]);
                }
            }

            public string Department
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DEPARTMENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
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

            public APRTypeEnum? Type
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTPAYABLERECEIVABLE"].AllPropertyDefs["TYPE"].DataType;
                    return (APRTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public GetProcedureIncomesByRessection_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetProcedureIncomesByRessection_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetProcedureIncomesByRessection_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPatientTotalNotPaid_Class : TTReportNqlObject 
        {
            public Object Totalprice
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOTALPRICE"]);
                }
            }

            public GetPatientTotalNotPaid_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPatientTotalNotPaid_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPatientTotalNotPaid_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPayerTotalPriceBySubEpisode_Class : TTReportNqlObject 
        {
            public Object Totalprice
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOTALPRICE"]);
                }
            }

            public GetPayerTotalPriceBySubEpisode_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPayerTotalPriceBySubEpisode_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPayerTotalPriceBySubEpisode_Class() : base() { }
        }

        [Serializable] 

        public partial class GetMedulaEntryPriceBySEP_Class : TTReportNqlObject 
        {
            public Object Totalprice
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOTALPRICE"]);
                }
            }

            public GetMedulaEntryPriceBySEP_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMedulaEntryPriceBySEP_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMedulaEntryPriceBySEP_Class() : base() { }
        }

        [Serializable] 

        public partial class GetMedulaTransactionsBySEPAndState_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetMedulaTransactionsBySEPAndState_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMedulaTransactionsBySEPAndState_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMedulaTransactionsBySEPAndState_Class() : base() { }
        }

        [Serializable] 

        public partial class CollectedInvoiceProcDetPreviewReportQuery1_Class : TTReportNqlObject 
        {
            public string Specialitycode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SPECIALITYCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SPECIALITYDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public Object Patientname
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PATIENTNAME"]);
                }
            }

            public Guid? Sex
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SEX"]);
                }
            }

            public Object Homephone
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["HOMEPHONE"]);
                }
            }

            public Object Homeaddress
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["HOMEADDRESS"]);
                }
            }

            public Object Hometown
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["HOMETOWN"]);
                }
            }

            public Object Homecity
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["HOMECITY"]);
                }
            }

            public Guid? Pobjid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["POBJID"]);
                }
            }

            public Guid? Eobjid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EOBJID"]);
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

            public DateTime? HospitalInPatientDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HOSPITALINPATIENTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["HOSPITALINPATIENTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? HospitalDischargeDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HOSPITALDISCHARGEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["HOSPITALDISCHARGEDATE"].DataType;
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

            public PatientStatusEnum? PatientStatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTSTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["PATIENTSTATUS"].DataType;
                    return (PatientStatusEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Year
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["YEAR"]);
                }
            }

            public Object Month
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["MONTH"]);
                }
            }

            public Object Day
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["DAY"]);
                }
            }

            public string ExternalCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXTERNALCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["EXTERNALCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Amount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["AMOUNT"]);
                }
            }

            public double? UnitPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNITPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["UNITPRICE"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public Object Totalprice
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOTALPRICE"]);
                }
            }

            public CollectedInvoiceProcDetPreviewReportQuery1_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public CollectedInvoiceProcDetPreviewReportQuery1_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected CollectedInvoiceProcDetPreviewReportQuery1_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetInvoiceByResource_Class : TTReportNqlObject 
        {
            public Guid? Department
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DEPARTMENT"]);
                }
            }

            public Object Patienttotalprice
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PATIENTTOTALPRICE"]);
                }
            }

            public Object Payertotalprice
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PAYERTOTALPRICE"]);
                }
            }

            public Guid? Procedure
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PROCEDURE"]);
                }
            }

            public Object Year
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["YEAR"]);
                }
            }

            public Object Month
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["MONTH"]);
                }
            }

            public Object Day
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["DAY"]);
                }
            }

            public OLAP_GetInvoiceByResource_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetInvoiceByResource_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetInvoiceByResource_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetInvoiceByPharmacyResource_Class : TTReportNqlObject 
        {
            public Object Department
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["DEPARTMENT"]);
                }
            }

            public Object Patienttotalprice
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PATIENTTOTALPRICE"]);
                }
            }

            public Object Payertotalprice
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PAYERTOTALPRICE"]);
                }
            }

            public Guid? Procedure
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PROCEDURE"]);
                }
            }

            public Object Year
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["YEAR"]);
                }
            }

            public Object Month
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["MONTH"]);
                }
            }

            public Object Day
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["DAY"]);
                }
            }

            public OLAP_GetInvoiceByPharmacyResource_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetInvoiceByPharmacyResource_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetInvoiceByPharmacyResource_Class() : base() { }
        }

        [Serializable] 

        public partial class CollectedInvoiceProcDetPreviewReportQuery2_Class : TTReportNqlObject 
        {
            public string Specialitycode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SPECIALITYCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SPECIALITYDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public Object Patientname
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PATIENTNAME"]);
                }
            }

            public Guid? Sex
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SEX"]);
                }
            }

            public Object Homephone
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["HOMEPHONE"]);
                }
            }

            public Object Homeaddress
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["HOMEADDRESS"]);
                }
            }

            public Object Hometown
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["HOMETOWN"]);
                }
            }

            public Object Homecity
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["HOMECITY"]);
                }
            }

            public Guid? Pobjid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["POBJID"]);
                }
            }

            public Guid? Eobjid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EOBJID"]);
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

            public DateTime? HospitalInPatientDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HOSPITALINPATIENTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["HOSPITALINPATIENTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? HospitalDischargeDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HOSPITALDISCHARGEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["HOSPITALDISCHARGEDATE"].DataType;
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

            public PatientStatusEnum? PatientStatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTSTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["PATIENTSTATUS"].DataType;
                    return (PatientStatusEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Year
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["YEAR"]);
                }
            }

            public Object Month
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["MONTH"]);
                }
            }

            public Object Day
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["DAY"]);
                }
            }

            public string ExternalCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXTERNALCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["EXTERNALCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Amount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["AMOUNT"]);
                }
            }

            public double? UnitPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNITPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["UNITPRICE"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public Object Totalprice
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOTALPRICE"]);
                }
            }

            public CollectedInvoiceProcDetPreviewReportQuery2_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public CollectedInvoiceProcDetPreviewReportQuery2_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected CollectedInvoiceProcDetPreviewReportQuery2_Class() : base() { }
        }

        [Serializable] 

        public partial class GetOrthesisProsthesisByProtocolNoAndYear_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public DateTime? TransactionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TRANSACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["TRANSACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string ExternalCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXTERNALCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["EXTERNALCODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public double? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["AMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public double? UnitPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNITPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["UNITPRICE"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public Object Totalprice
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOTALPRICE"]);
                }
            }

            public GetOrthesisProsthesisByProtocolNoAndYear_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetOrthesisProsthesisByProtocolNoAndYear_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetOrthesisProsthesisByProtocolNoAndYear_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPackageTrxsByEpisode_Class : TTReportNqlObject 
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

            public double? TotalDiscountPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOTALDISCOUNTPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["TOTALDISCOUNTPRICE"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public double? UnitPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNITPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["UNITPRICE"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public string ExternalCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXTERNALCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["EXTERNALCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public double? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["AMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public PackageOutReasonEnum? PackageOutReason
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PACKAGEOUTREASON"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["PACKAGEOUTREASON"].DataType;
                    return (PackageOutReasonEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? TransactionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TRANSACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["TRANSACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? InvoiceInclusion
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INVOICEINCLUSION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["INVOICEINCLUSION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? MedulaInfoChangedByUser
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULAINFOCHANGEDBYUSER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["MEDULAINFOCHANGEDBYUSER"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? MedulaInfoUpdated
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULAINFOUPDATED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["MEDULAINFOUPDATED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string UserNote
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["USERNOTE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["USERNOTE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string MedulaProcessNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULAPROCESSNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["MEDULAPROCESSNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? Id
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string MedulaResultCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULARESULTCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["MEDULARESULTCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string MedulaResultMessage
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULARESULTMESSAGE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["MEDULARESULTMESSAGE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Currency? MedulaPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULAPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["MEDULAPRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public double? UnitPriceOrg
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNITPRICEORG"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["UNITPRICEORG"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public string MedulaDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULADESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["MEDULADESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string MedulaBedNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULABEDNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["MEDULABEDNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? PurchaseDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PURCHASEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["PURCHASEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Barcode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BARCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["BARCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ProducerCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRODUCERCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["PRODUCERCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public SendToENabizEnum? Nabiz700Status
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NABIZ700STATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["NABIZ700STATUS"].DataType;
                    return (SendToENabizEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string NabizResultCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NABIZRESULTCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["NABIZRESULTCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string NabizResultMessage
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NABIZRESULTMESSAGE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["NABIZRESULTMESSAGE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? UTSUsageCommitment
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UTSUSAGECOMMITMENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["UTSUSAGECOMMITMENT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string MedulaAccessionNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULAACCESSIONNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["MEDULAACCESSIONNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string MedulaDealerNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULADEALERNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["MEDULADEALERNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public SurgeryLeftRight? Position
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["POSITION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["POSITION"].DataType;
                    return (SurgeryLeftRight?)(int)dataType.ConvertValue(val);
                }
            }

            public GetPackageTrxsByEpisode_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPackageTrxsByEpisode_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPackageTrxsByEpisode_Class() : base() { }
        }

        [Serializable] 

        public partial class GetOrthesisProsthesisByProcedureAndDate_Class : TTReportNqlObject 
        {
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

            public DateTime? TransactionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TRANSACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["TRANSACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string ExternalCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXTERNALCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["EXTERNALCODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Amount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["AMOUNT"]);
                }
            }

            public Object Totalprice
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOTALPRICE"]);
                }
            }

            public GetOrthesisProsthesisByProcedureAndDate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetOrthesisProsthesisByProcedureAndDate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetOrthesisProsthesisByProcedureAndDate_Class() : base() { }
        }

        [Serializable] 

        public partial class CollInvoiceDetailedRevenueListProcedureQuery_Class : TTReportNqlObject 
        {
            public Guid? Procedure
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PROCEDURE"]);
                }
            }

            public Object Patientprice
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PATIENTPRICE"]);
                }
            }

            public Object Payerprice
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PAYERPRICE"]);
                }
            }

            public CollInvoiceDetailedRevenueListProcedureQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public CollInvoiceDetailedRevenueListProcedureQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected CollInvoiceDetailedRevenueListProcedureQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetMedulaTransactionCountBySEPAndState_Class : TTReportNqlObject 
        {
            public Object Acctrxcount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["ACCTRXCOUNT"]);
                }
            }

            public GetMedulaTransactionCountBySEPAndState_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMedulaTransactionCountBySEPAndState_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMedulaTransactionCountBySEPAndState_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPatientTotalPriceBySubEpisode_Class : TTReportNqlObject 
        {
            public Object Totalprice
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOTALPRICE"]);
                }
            }

            public GetPatientTotalPriceBySubEpisode_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPatientTotalPriceBySubEpisode_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPatientTotalPriceBySubEpisode_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPayerTotalPriceByEpisode_Class : TTReportNqlObject 
        {
            public Object Totalprice
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOTALPRICE"]);
                }
            }

            public GetPayerTotalPriceByEpisode_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPayerTotalPriceByEpisode_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPayerTotalPriceByEpisode_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPatientTotalPriceByEpisode_Class : TTReportNqlObject 
        {
            public Object Totalprice
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOTALPRICE"]);
                }
            }

            public GetPatientTotalPriceByEpisode_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPatientTotalPriceByEpisode_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPatientTotalPriceByEpisode_Class() : base() { }
        }

        [Serializable] 

        public partial class CollInvoiceDetailedRevenueListMaterialQuery_NP_Class : TTReportNqlObject 
        {
            public Object Patientprice
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PATIENTPRICE"]);
                }
            }

            public Object Payerprice
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PAYERPRICE"]);
                }
            }

            public CollInvoiceDetailedRevenueListMaterialQuery_NP_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public CollInvoiceDetailedRevenueListMaterialQuery_NP_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected CollInvoiceDetailedRevenueListMaterialQuery_NP_Class() : base() { }
        }

        [Serializable] 

        public partial class CollInvoiceDetailedRevenueListProcedureQuery_NP_Class : TTReportNqlObject 
        {
            public Guid? Procedure
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PROCEDURE"]);
                }
            }

            public Object Patientprice
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PATIENTPRICE"]);
                }
            }

            public Object Payerprice
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PAYERPRICE"]);
                }
            }

            public CollInvoiceDetailedRevenueListProcedureQuery_NP_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public CollInvoiceDetailedRevenueListProcedureQuery_NP_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected CollInvoiceDetailedRevenueListProcedureQuery_NP_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPricesForInvoiceCollection_Class : TTReportNqlObject 
        {
            public Guid? InvoiceCollection
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["INVOICECOLLECTION"]);
                }
            }

            public Object Proceduretotal
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PROCEDURETOTAL"]);
                }
            }

            public Object Materialtotal
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["MATERIALTOTAL"]);
                }
            }

            public Object Drugtotal
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["DRUGTOTAL"]);
                }
            }

            public GetPricesForInvoiceCollection_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPricesForInvoiceCollection_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPricesForInvoiceCollection_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPricesForInvoiceCollectionDetail_Class : TTReportNqlObject 
        {
            public Guid? InvoiceCollectionDetail
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["INVOICECOLLECTIONDETAIL"]);
                }
            }

            public Object Proceduretotal
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PROCEDURETOTAL"]);
                }
            }

            public Object Materialtotal
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["MATERIALTOTAL"]);
                }
            }

            public Object Drugtotal
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["DRUGTOTAL"]);
                }
            }

            public GetPricesForInvoiceCollectionDetail_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPricesForInvoiceCollectionDetail_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPricesForInvoiceCollectionDetail_Class() : base() { }
        }

        [Serializable] 

        public partial class GetTrxGroupedTrxs_Class : TTReportNqlObject 
        {
            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? ProcedureObject
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PROCEDUREOBJECT"]);
                }
            }

            public string ExternalCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXTERNALCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["EXTERNALCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public double? UnitPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNITPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["UNITPRICE"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public Object Totalprice
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOTALPRICE"]);
                }
            }

            public Object Totalamount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOTALAMOUNT"]);
                }
            }

            public GetTrxGroupedTrxs_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetTrxGroupedTrxs_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetTrxGroupedTrxs_Class() : base() { }
        }

        [Serializable] 

        public partial class GetBlockTransactionsCountBySEPs_Class : TTReportNqlObject 
        {
            public Object Blockingcount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["BLOCKINGCOUNT"]);
                }
            }

            public GetBlockTransactionsCountBySEPs_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetBlockTransactionsCountBySEPs_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetBlockTransactionsCountBySEPs_Class() : base() { }
        }

        [Serializable] 

        public partial class GetTrxForFTR_Class : TTReportNqlObject 
        {
            public Guid? Accobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["ACCOBJECTID"]);
                }
            }

            public Guid? Sepobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SEPOBJECTID"]);
                }
            }

            public Object Statetext
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["STATETEXT"]);
                }
            }

            public Guid? CurrentStateDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENTSTATEDEFID"]);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ExternalCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXTERNALCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["EXTERNALCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? Id
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? MedulaProvizyonTarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULAPROVIZYONTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODEPROTOCOL"].AllPropertyDefs["MEDULAPROVIZYONTARIHI"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string MedulaTakipNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULATAKIPNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODEPROTOCOL"].AllPropertyDefs["MEDULATAKIPNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? TransactionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TRANSACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["TRANSACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string MedulaReportNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULAREPORTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].AllPropertyDefs["MEDULAREPORTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetTrxForFTR_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetTrxForFTR_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetTrxForFTR_Class() : base() { }
        }

        [Serializable] 

        public partial class GetSEPTotalMedulaPriceByTerm_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string MedulaTakipNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULATAKIPNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODEPROTOCOL"].AllPropertyDefs["MEDULATAKIPNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Medulaprice
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["MEDULAPRICE"]);
                }
            }

            public GetSEPTotalMedulaPriceByTerm_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSEPTotalMedulaPriceByTerm_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSEPTotalMedulaPriceByTerm_Class() : base() { }
        }

        [Serializable] 

        public partial class GetHBYSPriceBySEP_Class : TTReportNqlObject 
        {
            public Object Hbystotalprice
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["HBYSTOTALPRICE"]);
                }
            }

            public Object Atcount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["ATCOUNT"]);
                }
            }

            public GetHBYSPriceBySEP_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetHBYSPriceBySEP_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetHBYSPriceBySEP_Class() : base() { }
        }

        [Serializable] 

        public partial class GetTotalMedulaPriceByTerm_Class : TTReportNqlObject 
        {
            public Object Medulainvoiceprice
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["MEDULAINVOICEPRICE"]);
                }
            }

            public GetTotalMedulaPriceByTerm_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetTotalMedulaPriceByTerm_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetTotalMedulaPriceByTerm_Class() : base() { }
        }

        [Serializable] 

        public partial class GetCountOfAccTrx_Class : TTReportNqlObject 
        {
            public Object Acctrxcount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["ACCTRXCOUNT"]);
                }
            }

            public GetCountOfAccTrx_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetCountOfAccTrx_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetCountOfAccTrx_Class() : base() { }
        }

        [Serializable] 

        public partial class InvoicedProceduresReportQuery_Class : TTReportNqlObject 
        {
            public Object Payertype
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PAYERTYPE"]);
                }
            }

            public Object Medulaproceduretype
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["MEDULAPROCEDURETYPE"]);
                }
            }

            public Object Year
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["YEAR"]);
                }
            }

            public Object Month
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["MONTH"]);
                }
            }

            public Object Day
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["DAY"]);
                }
            }

            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["EXTERNALCODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Amount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["AMOUNT"]);
                }
            }

            public Object Price
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PRICE"]);
                }
            }

            public InvoicedProceduresReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public InvoicedProceduresReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected InvoicedProceduresReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class ForeignParticipationStatQuery_Class : TTReportNqlObject 
        {
            public long? Hastatcno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HASTATCNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["UNIQUEREFNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Hastaadi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HASTAADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Hastasoyadi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HASTASOYADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["SURNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Kabulno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KABULNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].AllPropertyDefs["PROTOCOLNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? Kabultarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KABULTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].AllPropertyDefs["OPENINGDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Makbuzno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MAKBUZNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTDOCUMENT"].AllPropertyDefs["DOCUMENTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Currency? Odemetutari
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ODEMETUTARI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTDOCUMENT"].AllPropertyDefs["TOTALPRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public ForeignParticipationStatQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public ForeignParticipationStatQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected ForeignParticipationStatQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class PrepareSGKMIFQuery_Class : TTReportNqlObject 
        {
            public Object Basetype
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["BASETYPE"]);
                }
            }

            public Guid? Sepobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SEPOBJECTID"]);
                }
            }

            public string tedaviTuruKodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TEDAVITURUKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TEDAVITURU"].AllPropertyDefs["TEDAVITURUKODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string provizyonTipiKodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROVIZYONTIPIKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROVIZYONTIPI"].AllPropertyDefs["PROVIZYONTIPIKODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string tedaviTipiKodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TEDAVITIPIKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TEDAVITIPI"].AllPropertyDefs["TEDAVITIPIKODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Istisnaihalkodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISTISNAIHALKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ISTISNAIHAL"].AllPropertyDefs["KODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string devredilenKurumKodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DEVREDILENKURUMKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DEVREDILENKURUM"].AllPropertyDefs["DEVREDILENKURUMKODU"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public Object Accountcode
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["ACCOUNTCODE"]);
                }
            }

            public Object Medulaprice
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["MEDULAPRICE"]);
                }
            }

            public PrepareSGKMIFQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public PrepareSGKMIFQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected PrepareSGKMIFQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class PrepareOfficialMIFQuery_Class : TTReportNqlObject 
        {
            public Object Basetype
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["BASETYPE"]);
                }
            }

            public Guid? Payerobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PAYEROBJECTID"]);
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

            public string Payeraccountcode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PAYERACCOUNTCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REVENUESUBACCOUNTCODEDEFINITION"].AllPropertyDefs["ACCOUNTCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Sepobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SEPOBJECTID"]);
                }
            }

            public string tedaviTuruKodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TEDAVITURUKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TEDAVITURU"].AllPropertyDefs["TEDAVITURUKODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string provizyonTipiKodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROVIZYONTIPIKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROVIZYONTIPI"].AllPropertyDefs["PROVIZYONTIPIKODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string tedaviTipiKodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TEDAVITIPIKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TEDAVITIPI"].AllPropertyDefs["TEDAVITIPIKODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Istisnaihalkodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISTISNAIHALKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ISTISNAIHAL"].AllPropertyDefs["KODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string devredilenKurumKodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DEVREDILENKURUMKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DEVREDILENKURUM"].AllPropertyDefs["DEVREDILENKURUMKODU"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public Object Accountcode
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["ACCOUNTCODE"]);
                }
            }

            public Object Totalprice
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOTALPRICE"]);
                }
            }

            public PrepareOfficialMIFQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public PrepareOfficialMIFQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected PrepareOfficialMIFQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class UninvoicedProceduresReportQuery_Class : TTReportNqlObject 
        {
            public Object Payertype
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PAYERTYPE"]);
                }
            }

            public Object Medulaproceduretype
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["MEDULAPROCEDURETYPE"]);
                }
            }

            public Object Year
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["YEAR"]);
                }
            }

            public Object Month
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["MONTH"]);
                }
            }

            public Object Day
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["DAY"]);
                }
            }

            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["EXTERNALCODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Amount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["AMOUNT"]);
                }
            }

            public Object Price
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PRICE"]);
                }
            }

            public UninvoicedProceduresReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public UninvoicedProceduresReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected UninvoicedProceduresReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetAccountTrxDrugBySEPMat_Class : TTReportNqlObject 
        {
            public Object Dailymaterialamount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["DAILYMATERIALAMOUNT"]);
                }
            }

            public GetAccountTrxDrugBySEPMat_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetAccountTrxDrugBySEPMat_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetAccountTrxDrugBySEPMat_Class() : base() { }
        }

        [Serializable] 

        public partial class GetIncludedTrxsTotalPriceByEpisode_Class : TTReportNqlObject 
        {
            public Object Price
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PRICE"]);
                }
            }

            public GetIncludedTrxsTotalPriceByEpisode_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetIncludedTrxsTotalPriceByEpisode_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetIncludedTrxsTotalPriceByEpisode_Class() : base() { }
        }

        [Serializable] 

        public partial class GetTransactionsForReceiptByEpisodeRprtQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Object Totalprice
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOTALPRICE"]);
                }
            }

            public DateTime? TransactionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TRANSACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["TRANSACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string ExternalCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXTERNALCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["EXTERNALCODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public double? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["AMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public double? UnitPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNITPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["UNITPRICE"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public string Procedurespecialityname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDURESPECIALITYNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SPECIALITYDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Paymentprice
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PAYMENTPRICE"]);
                }
            }

            public GetTransactionsForReceiptByEpisodeRprtQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetTransactionsForReceiptByEpisodeRprtQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetTransactionsForReceiptByEpisodeRprtQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetProceduresForDashboard_Class : TTReportNqlObject 
        {
            public Object Type
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TYPE"]);
                }
            }

            public Object Code
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["CODE"]);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Amount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["AMOUNT"]);
                }
            }

            public Object Price
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PRICE"]);
                }
            }

            public GetProceduresForDashboard_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetProceduresForDashboard_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetProceduresForDashboard_Class() : base() { }
        }

        [Serializable] 

        public partial class GetInconsistentForDashboard_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Hbystutar
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["HBYSTUTAR"]);
                }
            }

            public Object Medulatutar
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["MEDULATUTAR"]);
                }
            }

            public Object Fark
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["FARK"]);
                }
            }

            public GetInconsistentForDashboard_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetInconsistentForDashboard_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetInconsistentForDashboard_Class() : base() { }
        }

        public static class States
        {
            public static Guid New { get { return new Guid("934b9f03-d262-428d-8cb8-5e8ab927e3d5"); } }
            public static Guid Cancelled { get { return new Guid("4aa5b60f-96cb-4d02-900a-1195b87e24a2"); } }
    /// <summary>
    /// Gönderildi
    /// </summary>
            public static Guid Send { get { return new Guid("19603fe9-1a60-4891-9a01-566c99eb3d84"); } }
            public static Guid Invoiced { get { return new Guid("d0260db4-5e26-4c68-80ec-569cdbf346e0"); } }
    /// <summary>
    /// Toplu Faturaya Hazır
    /// </summary>
            public static Guid Ready { get { return new Guid("5dc0a6e4-a49a-43bd-be2b-f06174cd7329"); } }
            public static Guid ToBeNew { get { return new Guid("01117d1d-0067-416e-b8a3-bfc3eba9def5"); } }
            public static Guid Paid { get { return new Guid("c768babf-2db6-422a-b06f-e1c5cc52c63b"); } }
    /// <summary>
    /// Medulaya Gönderilmeyecek
    /// </summary>
            public static Guid MedulaDontSend { get { return new Guid("33784c3f-d601-49c4-b8da-6fa502f6a9cf"); } }
    /// <summary>
    /// Sunucuya Gönderildi
    /// </summary>
            public static Guid MedulaSentServer { get { return new Guid("7ee560b9-f401-4326-b42e-64e86d8e59ef"); } }
    /// <summary>
    /// Hizmet Kaydı Başarısız
    /// </summary>
            public static Guid MedulaEntryUnsuccessful { get { return new Guid("6856675b-95fb-41cf-bade-6a1993626cc7"); } }
    /// <summary>
    /// Hizmet Kaydı Başarılı
    /// </summary>
            public static Guid MedulaEntrySuccessful { get { return new Guid("7f35b4ea-d668-4115-bb7b-b6ddef937920"); } }
        }

        public static BindingList<AccountTransaction> GetTransactionsForReceipt(TTObjectContext objectContext, Guid APR, Guid STATE, Guid SEP)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetTransactionsForReceipt"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("APR", APR);
            paramList.Add("STATE", STATE);
            paramList.Add("SEP", SEP);

            return ((ITTQuery)objectContext).QueryObjects<AccountTransaction>(queryDef, paramList);
        }

        public static BindingList<AccountTransaction> GetTransactionsForInvoice(TTObjectContext objectContext, Guid STATE, Guid APR, Guid SEP)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetTransactionsForInvoice"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STATE", STATE);
            paramList.Add("APR", APR);
            paramList.Add("SEP", SEP);

            return ((ITTQuery)objectContext).QueryObjects<AccountTransaction>(queryDef, paramList);
        }

        public static BindingList<AccountTransaction> GetTransactionsForCollectedInvoice(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, IList<Guid> PAYER, IList<int> PATIENTSTATUS)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetTransactionsForCollectedInvoice"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("PAYER", PAYER);
            paramList.Add("PATIENTSTATUS", PATIENTSTATUS);

            return ((ITTQuery)objectContext).QueryObjects<AccountTransaction>(queryDef, paramList);
        }

        public static BindingList<AccountTransaction> GetTransactionsExceptCancelledBySEP(TTObjectContext objectContext, Guid APR, Guid SEP)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetTransactionsExceptCancelledBySEP"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("APR", APR);
            paramList.Add("SEP", SEP);

            return ((ITTQuery)objectContext).QueryObjects<AccountTransaction>(queryDef, paramList);
        }

        public static BindingList<AccountTransaction> GetTransactionsForCollectedInvoiceByResource(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, IList<Guid> PAYER, IList<int> PATIENTSTATUS, IList<Guid> RESOURCE, int RESOURCEFLAG)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetTransactionsForCollectedInvoiceByResource"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("PAYER", PAYER);
            paramList.Add("PATIENTSTATUS", PATIENTSTATUS);
            paramList.Add("RESOURCE", RESOURCE);
            paramList.Add("RESOURCEFLAG", RESOURCEFLAG);

            return ((ITTQuery)objectContext).QueryObjects<AccountTransaction>(queryDef, paramList);
        }

        public static BindingList<AccountTransaction.OLAP_GetSubactionAccTransaction_Class> OLAP_GetSubactionAccTransaction(Guid SUBACTIONPROCEDURE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["OLAP_GetSubactionAccTransaction"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBACTIONPROCEDURE", SUBACTIONPROCEDURE);

            return TTReportNqlObject.QueryObjects<AccountTransaction.OLAP_GetSubactionAccTransaction_Class>(queryDef, paramList, pi);
        }

        public static BindingList<AccountTransaction.OLAP_GetSubactionAccTransaction_Class> OLAP_GetSubactionAccTransaction(TTObjectContext objectContext, Guid SUBACTIONPROCEDURE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["OLAP_GetSubactionAccTransaction"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBACTIONPROCEDURE", SUBACTIONPROCEDURE);

            return TTReportNqlObject.QueryObjects<AccountTransaction.OLAP_GetSubactionAccTransaction_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<AccountTransaction> GetProcTrxsByDateAndProc(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, Guid STATE, Guid PROCEDURE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetProcTrxsByDateAndProc"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STATE", STATE);
            paramList.Add("PROCEDURE", PROCEDURE);

            return ((ITTQuery)objectContext).QueryObjects<AccountTransaction>(queryDef, paramList);
        }

        public static BindingList<AccountTransaction> GetMatTrxsByDateAndMat(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, Guid STATE, Guid MATERIAL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetMatTrxsByDateAndMat"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STATE", STATE);
            paramList.Add("MATERIAL", MATERIAL);

            return ((ITTQuery)objectContext).QueryObjects<AccountTransaction>(queryDef, paramList);
        }

        public static BindingList<AccountTransaction> GetSubActionProcedureTrxsBySEP(TTObjectContext objectContext, Guid SEP, IList<Guid> STATES)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetSubActionProcedureTrxsBySEP"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SEP", SEP);
            paramList.Add("STATES", STATES);

            return ((ITTQuery)objectContext).QueryObjects<AccountTransaction>(queryDef, paramList);
        }

        public static BindingList<AccountTransaction> GetSubActionMaterialTrxsBySEP(TTObjectContext objectContext, Guid SEP, IList<Guid> STATES)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetSubActionMaterialTrxsBySEP"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SEP", SEP);
            paramList.Add("STATES", STATES);

            return ((ITTQuery)objectContext).QueryObjects<AccountTransaction>(queryDef, paramList);
        }

        public static BindingList<AccountTransaction> GetTransactionsBySEP(TTObjectContext objectContext, Guid SEP)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetTransactionsBySEP"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SEP", SEP);

            return ((ITTQuery)objectContext).QueryObjects<AccountTransaction>(queryDef, paramList);
        }

        public static BindingList<AccountTransaction> GetProcTrxsByDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, Guid STATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetProcTrxsByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STATE", STATE);

            return ((ITTQuery)objectContext).QueryObjects<AccountTransaction>(queryDef, paramList);
        }

        public static BindingList<AccountTransaction> GetMatTrxsByDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, Guid STATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetMatTrxsByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STATE", STATE);

            return ((ITTQuery)objectContext).QueryObjects<AccountTransaction>(queryDef, paramList);
        }

        public static BindingList<AccountTransaction.GetToBeNewTrxsByEpisode_Class> GetToBeNewTrxsByEpisode(Guid EPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetToBeNewTrxsByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<AccountTransaction.GetToBeNewTrxsByEpisode_Class>(queryDef, paramList, pi);
        }

        public static BindingList<AccountTransaction.GetToBeNewTrxsByEpisode_Class> GetToBeNewTrxsByEpisode(TTObjectContext objectContext, Guid EPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetToBeNewTrxsByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<AccountTransaction.GetToBeNewTrxsByEpisode_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<AccountTransaction> GetBulletinProcedureTrxsBySEP(TTObjectContext objectContext, Guid SEP, IList<Guid> STATES)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetBulletinProcedureTrxsBySEP"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SEP", SEP);
            paramList.Add("STATES", STATES);

            return ((ITTQuery)objectContext).QueryObjects<AccountTransaction>(queryDef, paramList);
        }

    /// <summary>
    /// Bolum Bazlı Gelirler Listesi
    /// </summary>
        public static BindingList<AccountTransaction.GetIncomesFromDepartment_Class> GetIncomesFromDepartment(DateTime STARTDATE, DateTime ENDDATE, IList<Guid> DEPARTMENT, int DEPARTMENTFLAG, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetIncomesFromDepartment"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("DEPARTMENT", DEPARTMENT);
            paramList.Add("DEPARTMENTFLAG", DEPARTMENTFLAG);

            return TTReportNqlObject.QueryObjects<AccountTransaction.GetIncomesFromDepartment_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// Bolum Bazlı Gelirler Listesi
    /// </summary>
        public static BindingList<AccountTransaction.GetIncomesFromDepartment_Class> GetIncomesFromDepartment(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, IList<Guid> DEPARTMENT, int DEPARTMENTFLAG, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetIncomesFromDepartment"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("DEPARTMENT", DEPARTMENT);
            paramList.Add("DEPARTMENTFLAG", DEPARTMENTFLAG);

            return TTReportNqlObject.QueryObjects<AccountTransaction.GetIncomesFromDepartment_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<AccountTransaction> GetNewAndCancelledPackageTrxsBySEP(TTObjectContext objectContext, Guid SEP, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetNewAndCancelledPackageTrxsBySEP"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SEP", SEP);

            return ((ITTQuery)objectContext).QueryObjects<AccountTransaction>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<AccountTransaction> GetNewAndCancelledProcedureTrxsBySEP(TTObjectContext objectContext, Guid SEP, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetNewAndCancelledProcedureTrxsBySEP"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SEP", SEP);

            return ((ITTQuery)objectContext).QueryObjects<AccountTransaction>(queryDef, paramList, injectionSQL);
        }

    /// <summary>
    /// Ayrıntılı Gelir Kalemleri Listesi Hizmet
    /// </summary>
        public static BindingList<AccountTransaction.DetailedRevenueListProcedureQuery_Class> DetailedRevenueListProcedureQuery(DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["DetailedRevenueListProcedureQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<AccountTransaction.DetailedRevenueListProcedureQuery_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// Ayrıntılı Gelir Kalemleri Listesi Hizmet
    /// </summary>
        public static BindingList<AccountTransaction.DetailedRevenueListProcedureQuery_Class> DetailedRevenueListProcedureQuery(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["DetailedRevenueListProcedureQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<AccountTransaction.DetailedRevenueListProcedureQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<AccountTransaction> GetTransactionsInsidePackageBySEP(TTObjectContext objectContext, Guid PACKAGE, Guid SEP, Guid APR)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetTransactionsInsidePackageBySEP"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PACKAGE", PACKAGE);
            paramList.Add("SEP", SEP);
            paramList.Add("APR", APR);

            return ((ITTQuery)objectContext).QueryObjects<AccountTransaction>(queryDef, paramList);
        }

        public static BindingList<AccountTransaction> GetTransactionsForCollectedInvoiceByResource_Tooth(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, IList<Guid> PAYER, IList<int> PATIENTSTATUS, IList<Guid> RESOURCE, int RESOURCEFLAG)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetTransactionsForCollectedInvoiceByResource_Tooth"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("PAYER", PAYER);
            paramList.Add("PATIENTSTATUS", PATIENTSTATUS);
            paramList.Add("RESOURCE", RESOURCE);
            paramList.Add("RESOURCEFLAG", RESOURCEFLAG);

            return ((ITTQuery)objectContext).QueryObjects<AccountTransaction>(queryDef, paramList);
        }

        public static BindingList<AccountTransaction> GetTransactionsForReceiptByEpisode(TTObjectContext objectContext, Guid CURRENTSTATEID, Guid EPISODE, Guid APR)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetTransactionsForReceiptByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("CURRENTSTATEID", CURRENTSTATEID);
            paramList.Add("EPISODE", EPISODE);
            paramList.Add("APR", APR);

            return ((ITTQuery)objectContext).QueryObjects<AccountTransaction>(queryDef, paramList);
        }

        public static BindingList<AccountTransaction> GetTransactionsBySEPAndPackageDef(TTObjectContext objectContext, Guid SEP, Guid PACKAGE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetTransactionsBySEPAndPackageDef"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SEP", SEP);
            paramList.Add("PACKAGE", PACKAGE);

            return ((ITTQuery)objectContext).QueryObjects<AccountTransaction>(queryDef, paramList);
        }

        public static BindingList<AccountTransaction.GetMaterialListByDateAndDepartment_Class> GetMaterialListByDateAndDepartment(DateTime STARTDATE, DateTime ENDDATE, int PATIENTSTATUS1, int PATIENTSTATUS2, int PATIENTSTATUS3, IList<Guid> RESOURCE, int RESOURCEFLAG, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetMaterialListByDateAndDepartment"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("PATIENTSTATUS1", PATIENTSTATUS1);
            paramList.Add("PATIENTSTATUS2", PATIENTSTATUS2);
            paramList.Add("PATIENTSTATUS3", PATIENTSTATUS3);
            paramList.Add("RESOURCE", RESOURCE);
            paramList.Add("RESOURCEFLAG", RESOURCEFLAG);

            return TTReportNqlObject.QueryObjects<AccountTransaction.GetMaterialListByDateAndDepartment_Class>(queryDef, paramList, pi);
        }

        public static BindingList<AccountTransaction.GetMaterialListByDateAndDepartment_Class> GetMaterialListByDateAndDepartment(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, int PATIENTSTATUS1, int PATIENTSTATUS2, int PATIENTSTATUS3, IList<Guid> RESOURCE, int RESOURCEFLAG, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetMaterialListByDateAndDepartment"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("PATIENTSTATUS1", PATIENTSTATUS1);
            paramList.Add("PATIENTSTATUS2", PATIENTSTATUS2);
            paramList.Add("PATIENTSTATUS3", PATIENTSTATUS3);
            paramList.Add("RESOURCE", RESOURCE);
            paramList.Add("RESOURCEFLAG", RESOURCEFLAG);

            return TTReportNqlObject.QueryObjects<AccountTransaction.GetMaterialListByDateAndDepartment_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<AccountTransaction.GetNotInvoicedPatientListByPatientStatus_Class> GetNotInvoicedPatientListByPatientStatus(DateTime STARTDATE, DateTime ENDDATE, int PATIENTSTATUS1, int PATIENTSTATUS2, int PATIENTSTATUS3, IList<Guid> PAYER, int PAYERFLAG, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetNotInvoicedPatientListByPatientStatus"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("PATIENTSTATUS1", PATIENTSTATUS1);
            paramList.Add("PATIENTSTATUS2", PATIENTSTATUS2);
            paramList.Add("PATIENTSTATUS3", PATIENTSTATUS3);
            paramList.Add("PAYER", PAYER);
            paramList.Add("PAYERFLAG", PAYERFLAG);

            return TTReportNqlObject.QueryObjects<AccountTransaction.GetNotInvoicedPatientListByPatientStatus_Class>(queryDef, paramList, pi);
        }

        public static BindingList<AccountTransaction.GetNotInvoicedPatientListByPatientStatus_Class> GetNotInvoicedPatientListByPatientStatus(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, int PATIENTSTATUS1, int PATIENTSTATUS2, int PATIENTSTATUS3, IList<Guid> PAYER, int PAYERFLAG, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetNotInvoicedPatientListByPatientStatus"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("PATIENTSTATUS1", PATIENTSTATUS1);
            paramList.Add("PATIENTSTATUS2", PATIENTSTATUS2);
            paramList.Add("PATIENTSTATUS3", PATIENTSTATUS3);
            paramList.Add("PAYER", PAYER);
            paramList.Add("PAYERFLAG", PAYERFLAG);

            return TTReportNqlObject.QueryObjects<AccountTransaction.GetNotInvoicedPatientListByPatientStatus_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Ayrıntılı Gelir Kalemleri Listesi Malzeme
    /// </summary>
        public static BindingList<AccountTransaction.DetailedRevenueListMaterialQuery_Class> DetailedRevenueListMaterialQuery(DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["DetailedRevenueListMaterialQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<AccountTransaction.DetailedRevenueListMaterialQuery_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// Ayrıntılı Gelir Kalemleri Listesi Malzeme
    /// </summary>
        public static BindingList<AccountTransaction.DetailedRevenueListMaterialQuery_Class> DetailedRevenueListMaterialQuery(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["DetailedRevenueListMaterialQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<AccountTransaction.DetailedRevenueListMaterialQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<AccountTransaction.GetMaterialTrxsByHospitalProtocolNo_Class> GetMaterialTrxsByHospitalProtocolNo(string HOSPITALPROTOCOLNO, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetMaterialTrxsByHospitalProtocolNo"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HOSPITALPROTOCOLNO", HOSPITALPROTOCOLNO);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<AccountTransaction.GetMaterialTrxsByHospitalProtocolNo_Class>(queryDef, paramList, pi);
        }

        public static BindingList<AccountTransaction.GetMaterialTrxsByHospitalProtocolNo_Class> GetMaterialTrxsByHospitalProtocolNo(TTObjectContext objectContext, string HOSPITALPROTOCOLNO, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetMaterialTrxsByHospitalProtocolNo"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HOSPITALPROTOCOLNO", HOSPITALPROTOCOLNO);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<AccountTransaction.GetMaterialTrxsByHospitalProtocolNo_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<AccountTransaction.GetPatientParticipationTransactions_Class> GetPatientParticipationTransactions(DateTime STARTDATE, DateTime ENDDATE, Guid PARTICIPATIONPROCEDURE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetPatientParticipationTransactions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("PARTICIPATIONPROCEDURE", PARTICIPATIONPROCEDURE);

            return TTReportNqlObject.QueryObjects<AccountTransaction.GetPatientParticipationTransactions_Class>(queryDef, paramList, pi);
        }

        public static BindingList<AccountTransaction.GetPatientParticipationTransactions_Class> GetPatientParticipationTransactions(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, Guid PARTICIPATIONPROCEDURE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetPatientParticipationTransactions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("PARTICIPATIONPROCEDURE", PARTICIPATIONPROCEDURE);

            return TTReportNqlObject.QueryObjects<AccountTransaction.GetPatientParticipationTransactions_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<AccountTransaction.CollectedInvoiceProcedureDetailReportQueryCheck_Class> CollectedInvoiceProcedureDetailReportQueryCheck(string COLLINVOICEOBJID, IList<string> RESOURCE, int RESOURCEFLAG, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["CollectedInvoiceProcedureDetailReportQueryCheck"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("COLLINVOICEOBJID", COLLINVOICEOBJID);
            paramList.Add("RESOURCE", RESOURCE);
            paramList.Add("RESOURCEFLAG", RESOURCEFLAG);

            return TTReportNqlObject.QueryObjects<AccountTransaction.CollectedInvoiceProcedureDetailReportQueryCheck_Class>(queryDef, paramList, pi);
        }

        public static BindingList<AccountTransaction.CollectedInvoiceProcedureDetailReportQueryCheck_Class> CollectedInvoiceProcedureDetailReportQueryCheck(TTObjectContext objectContext, string COLLINVOICEOBJID, IList<string> RESOURCE, int RESOURCEFLAG, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["CollectedInvoiceProcedureDetailReportQueryCheck"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("COLLINVOICEOBJID", COLLINVOICEOBJID);
            paramList.Add("RESOURCE", RESOURCE);
            paramList.Add("RESOURCEFLAG", RESOURCEFLAG);

            return TTReportNqlObject.QueryObjects<AccountTransaction.CollectedInvoiceProcedureDetailReportQueryCheck_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<AccountTransaction.GetProcedureTrxsByHospitalProtocolNo_Class> GetProcedureTrxsByHospitalProtocolNo(string HOSPITALPROTOCOLNO, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetProcedureTrxsByHospitalProtocolNo"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HOSPITALPROTOCOLNO", HOSPITALPROTOCOLNO);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<AccountTransaction.GetProcedureTrxsByHospitalProtocolNo_Class>(queryDef, paramList, pi);
        }

        public static BindingList<AccountTransaction.GetProcedureTrxsByHospitalProtocolNo_Class> GetProcedureTrxsByHospitalProtocolNo(TTObjectContext objectContext, string HOSPITALPROTOCOLNO, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetProcedureTrxsByHospitalProtocolNo"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HOSPITALPROTOCOLNO", HOSPITALPROTOCOLNO);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<AccountTransaction.GetProcedureTrxsByHospitalProtocolNo_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<AccountTransaction.GetDrugTrxsByHospitalProtocolNo_Class> GetDrugTrxsByHospitalProtocolNo(string HOSPITALPROTOCOLNO, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetDrugTrxsByHospitalProtocolNo"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HOSPITALPROTOCOLNO", HOSPITALPROTOCOLNO);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<AccountTransaction.GetDrugTrxsByHospitalProtocolNo_Class>(queryDef, paramList, pi);
        }

        public static BindingList<AccountTransaction.GetDrugTrxsByHospitalProtocolNo_Class> GetDrugTrxsByHospitalProtocolNo(TTObjectContext objectContext, string HOSPITALPROTOCOLNO, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetDrugTrxsByHospitalProtocolNo"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HOSPITALPROTOCOLNO", HOSPITALPROTOCOLNO);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<AccountTransaction.GetDrugTrxsByHospitalProtocolNo_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<AccountTransaction.GetProcedureIncomesByMasterResource_Class> GetProcedureIncomesByMasterResource(IList<Guid> DEPARTMENT, int DEPARTMENTFLAG, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetProcedureIncomesByMasterResource"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DEPARTMENT", DEPARTMENT);
            paramList.Add("DEPARTMENTFLAG", DEPARTMENTFLAG);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<AccountTransaction.GetProcedureIncomesByMasterResource_Class>(queryDef, paramList, pi);
        }

        public static BindingList<AccountTransaction.GetProcedureIncomesByMasterResource_Class> GetProcedureIncomesByMasterResource(TTObjectContext objectContext, IList<Guid> DEPARTMENT, int DEPARTMENTFLAG, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetProcedureIncomesByMasterResource"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DEPARTMENT", DEPARTMENT);
            paramList.Add("DEPARTMENTFLAG", DEPARTMENTFLAG);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<AccountTransaction.GetProcedureIncomesByMasterResource_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Toplu Fatura Bazlı Ayrıntılı Gelir Kalemleri Listesi Malzeme
    /// </summary>
        public static BindingList<AccountTransaction.CollInvoiceDetailedRevenueListMaterialQuery_Class> CollInvoiceDetailedRevenueListMaterialQuery(IList<string> ID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["CollInvoiceDetailedRevenueListMaterialQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ID", ID);

            return TTReportNqlObject.QueryObjects<AccountTransaction.CollInvoiceDetailedRevenueListMaterialQuery_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// Toplu Fatura Bazlı Ayrıntılı Gelir Kalemleri Listesi Malzeme
    /// </summary>
        public static BindingList<AccountTransaction.CollInvoiceDetailedRevenueListMaterialQuery_Class> CollInvoiceDetailedRevenueListMaterialQuery(TTObjectContext objectContext, IList<string> ID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["CollInvoiceDetailedRevenueListMaterialQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ID", ID);

            return TTReportNqlObject.QueryObjects<AccountTransaction.CollInvoiceDetailedRevenueListMaterialQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<AccountTransaction> GetNewAndCancelledTrxsBySEP(TTObjectContext objectContext, string SEP)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetNewAndCancelledTrxsBySEP"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SEP", SEP);

            return ((ITTQuery)objectContext).QueryObjects<AccountTransaction>(queryDef, paramList);
        }

        public static BindingList<AccountTransaction> GetForInvoiceInclusionBySEP(TTObjectContext objectContext, Guid SEP, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetForInvoiceInclusionBySEP"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SEP", SEP);

            return ((ITTQuery)objectContext).QueryObjects<AccountTransaction>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<AccountTransaction> GetTransactionsByPayerInvoice(TTObjectContext objectContext, Guid PAYERINVOICE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetTransactionsByPayerInvoice"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PAYERINVOICE", PAYERINVOICE);

            return ((ITTQuery)objectContext).QueryObjects<AccountTransaction>(queryDef, paramList);
        }

        public static BindingList<AccountTransaction.GetMedulaDontSendDrugTrxsByDate_Class> GetMedulaDontSendDrugTrxsByDate(DateTime STARTDATE, DateTime ENDDATE, IList<Guid> BRANCH, int BRANCHFLAG, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetMedulaDontSendDrugTrxsByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("BRANCH", BRANCH);
            paramList.Add("BRANCHFLAG", BRANCHFLAG);

            return TTReportNqlObject.QueryObjects<AccountTransaction.GetMedulaDontSendDrugTrxsByDate_Class>(queryDef, paramList, pi);
        }

        public static BindingList<AccountTransaction.GetMedulaDontSendDrugTrxsByDate_Class> GetMedulaDontSendDrugTrxsByDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, IList<Guid> BRANCH, int BRANCHFLAG, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetMedulaDontSendDrugTrxsByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("BRANCH", BRANCH);
            paramList.Add("BRANCHFLAG", BRANCHFLAG);

            return TTReportNqlObject.QueryObjects<AccountTransaction.GetMedulaDontSendDrugTrxsByDate_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<AccountTransaction.GetMedulaDontSendProcedureTrxsByDate_Class> GetMedulaDontSendProcedureTrxsByDate(DateTime STARTDATE, DateTime ENDDATE, IList<Guid> BRANCH, int BRANCHFLAG, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetMedulaDontSendProcedureTrxsByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("BRANCH", BRANCH);
            paramList.Add("BRANCHFLAG", BRANCHFLAG);

            return TTReportNqlObject.QueryObjects<AccountTransaction.GetMedulaDontSendProcedureTrxsByDate_Class>(queryDef, paramList, pi);
        }

        public static BindingList<AccountTransaction.GetMedulaDontSendProcedureTrxsByDate_Class> GetMedulaDontSendProcedureTrxsByDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, IList<Guid> BRANCH, int BRANCHFLAG, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetMedulaDontSendProcedureTrxsByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("BRANCH", BRANCH);
            paramList.Add("BRANCHFLAG", BRANCHFLAG);

            return TTReportNqlObject.QueryObjects<AccountTransaction.GetMedulaDontSendProcedureTrxsByDate_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<AccountTransaction.GetMedulaDontSendMaterialTrxsByDate_Class> GetMedulaDontSendMaterialTrxsByDate(DateTime STARTDATE, DateTime ENDDATE, IList<Guid> BRANCH, int BRANCHFLAG, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetMedulaDontSendMaterialTrxsByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("BRANCH", BRANCH);
            paramList.Add("BRANCHFLAG", BRANCHFLAG);

            return TTReportNqlObject.QueryObjects<AccountTransaction.GetMedulaDontSendMaterialTrxsByDate_Class>(queryDef, paramList, pi);
        }

        public static BindingList<AccountTransaction.GetMedulaDontSendMaterialTrxsByDate_Class> GetMedulaDontSendMaterialTrxsByDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, IList<Guid> BRANCH, int BRANCHFLAG, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetMedulaDontSendMaterialTrxsByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("BRANCH", BRANCH);
            paramList.Add("BRANCHFLAG", BRANCHFLAG);

            return TTReportNqlObject.QueryObjects<AccountTransaction.GetMedulaDontSendMaterialTrxsByDate_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<AccountTransaction> GetPackageTrxsForInvoice(TTObjectContext objectContext, Guid STATE, Guid APR, Guid SEP)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetPackageTrxsForInvoice"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STATE", STATE);
            paramList.Add("APR", APR);
            paramList.Add("SEP", SEP);

            return ((ITTQuery)objectContext).QueryObjects<AccountTransaction>(queryDef, paramList);
        }

        public static BindingList<AccountTransaction> GetProcedureTrxsForInvoice(TTObjectContext objectContext, Guid STATE, Guid APR, Guid SEP)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetProcedureTrxsForInvoice"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STATE", STATE);
            paramList.Add("APR", APR);
            paramList.Add("SEP", SEP);

            return ((ITTQuery)objectContext).QueryObjects<AccountTransaction>(queryDef, paramList);
        }

        public static BindingList<AccountTransaction> GetMaterialTrxsForInvoice(TTObjectContext objectContext, Guid STATE, Guid APR, Guid SEP)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetMaterialTrxsForInvoice"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STATE", STATE);
            paramList.Add("APR", APR);
            paramList.Add("SEP", SEP);

            return ((ITTQuery)objectContext).QueryObjects<AccountTransaction>(queryDef, paramList);
        }

        public static BindingList<AccountTransaction> GetTransactionsForCollInvByResource_OutPatient(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, IList<Guid> PAYER, IList<Guid> RESOURCE, int RESOURCEFLAG)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetTransactionsForCollInvByResource_OutPatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("PAYER", PAYER);
            paramList.Add("RESOURCE", RESOURCE);
            paramList.Add("RESOURCEFLAG", RESOURCEFLAG);

            return ((ITTQuery)objectContext).QueryObjects<AccountTransaction>(queryDef, paramList);
        }

        public static BindingList<AccountTransaction.GetTransactionsForInvoiceBySEP_Class> GetTransactionsForInvoiceBySEP(Guid SEP, int APRTYPE, IList<Guid> BLOCKSTATES, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetTransactionsForInvoiceBySEP"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SEP", SEP);
            paramList.Add("APRTYPE", APRTYPE);
            paramList.Add("BLOCKSTATES", BLOCKSTATES);

            return TTReportNqlObject.QueryObjects<AccountTransaction.GetTransactionsForInvoiceBySEP_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<AccountTransaction.GetTransactionsForInvoiceBySEP_Class> GetTransactionsForInvoiceBySEP(TTObjectContext objectContext, Guid SEP, int APRTYPE, IList<Guid> BLOCKSTATES, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetTransactionsForInvoiceBySEP"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SEP", SEP);
            paramList.Add("APRTYPE", APRTYPE);
            paramList.Add("BLOCKSTATES", BLOCKSTATES);

            return TTReportNqlObject.QueryObjects<AccountTransaction.GetTransactionsForInvoiceBySEP_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<AccountTransaction.GetMaterialIncomesByMasterResource_Class> GetMaterialIncomesByMasterResource(IList<Guid> DEPARTMENT, int DEPARTMENTFLAG, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetMaterialIncomesByMasterResource"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DEPARTMENT", DEPARTMENT);
            paramList.Add("DEPARTMENTFLAG", DEPARTMENTFLAG);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<AccountTransaction.GetMaterialIncomesByMasterResource_Class>(queryDef, paramList, pi);
        }

        public static BindingList<AccountTransaction.GetMaterialIncomesByMasterResource_Class> GetMaterialIncomesByMasterResource(TTObjectContext objectContext, IList<Guid> DEPARTMENT, int DEPARTMENTFLAG, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetMaterialIncomesByMasterResource"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DEPARTMENT", DEPARTMENT);
            paramList.Add("DEPARTMENTFLAG", DEPARTMENTFLAG);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<AccountTransaction.GetMaterialIncomesByMasterResource_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<AccountTransaction.GetMaterialIncomesByRessection_Class> GetMaterialIncomesByRessection(IList<Guid> DEPARTMENT, int DEPARTMENTFLAG, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetMaterialIncomesByRessection"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DEPARTMENT", DEPARTMENT);
            paramList.Add("DEPARTMENTFLAG", DEPARTMENTFLAG);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<AccountTransaction.GetMaterialIncomesByRessection_Class>(queryDef, paramList, pi);
        }

        public static BindingList<AccountTransaction.GetMaterialIncomesByRessection_Class> GetMaterialIncomesByRessection(TTObjectContext objectContext, IList<Guid> DEPARTMENT, int DEPARTMENTFLAG, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetMaterialIncomesByRessection"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DEPARTMENT", DEPARTMENT);
            paramList.Add("DEPARTMENTFLAG", DEPARTMENTFLAG);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<AccountTransaction.GetMaterialIncomesByRessection_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<AccountTransaction.GetDrugIncomesByRessection_Class> GetDrugIncomesByRessection(IList<Guid> DEPARTMENT, int DEPARTMENTFLAG, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetDrugIncomesByRessection"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DEPARTMENT", DEPARTMENT);
            paramList.Add("DEPARTMENTFLAG", DEPARTMENTFLAG);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<AccountTransaction.GetDrugIncomesByRessection_Class>(queryDef, paramList, pi);
        }

        public static BindingList<AccountTransaction.GetDrugIncomesByRessection_Class> GetDrugIncomesByRessection(TTObjectContext objectContext, IList<Guid> DEPARTMENT, int DEPARTMENTFLAG, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetDrugIncomesByRessection"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DEPARTMENT", DEPARTMENT);
            paramList.Add("DEPARTMENTFLAG", DEPARTMENTFLAG);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<AccountTransaction.GetDrugIncomesByRessection_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<AccountTransaction> GetTransactionsForCollInvByResource_InPatient(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, IList<Guid> PAYER, IList<Guid> RESOURCE, int RESOURCEFLAG)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetTransactionsForCollInvByResource_InPatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("PAYER", PAYER);
            paramList.Add("RESOURCE", RESOURCE);
            paramList.Add("RESOURCEFLAG", RESOURCEFLAG);

            return ((ITTQuery)objectContext).QueryObjects<AccountTransaction>(queryDef, paramList);
        }

        public static BindingList<AccountTransaction> GetMedulaProcessNoExistsAndWrongState(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetMedulaProcessNoExistsAndWrongState"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<AccountTransaction>(queryDef, paramList);
        }

        public static BindingList<AccountTransaction> GetMedulaTransactionsByProvisionNoAndState(TTObjectContext objectContext, string PROVISIONNO, IList<Guid> STATES)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetMedulaTransactionsByProvisionNoAndState"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PROVISIONNO", PROVISIONNO);
            paramList.Add("STATES", STATES);

            return ((ITTQuery)objectContext).QueryObjects<AccountTransaction>(queryDef, paramList);
        }

        public static BindingList<AccountTransaction.GetCountForMedulaBySEP_Class> GetCountForMedulaBySEP(Guid SEP, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetCountForMedulaBySEP"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SEP", SEP);

            return TTReportNqlObject.QueryObjects<AccountTransaction.GetCountForMedulaBySEP_Class>(queryDef, paramList, pi);
        }

        public static BindingList<AccountTransaction.GetCountForMedulaBySEP_Class> GetCountForMedulaBySEP(TTObjectContext objectContext, Guid SEP, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetCountForMedulaBySEP"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SEP", SEP);

            return TTReportNqlObject.QueryObjects<AccountTransaction.GetCountForMedulaBySEP_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<AccountTransaction> GetNewAndToBeNewPackageTrxsBySEP(TTObjectContext objectContext, Guid SEP, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetNewAndToBeNewPackageTrxsBySEP"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SEP", SEP);

            return ((ITTQuery)objectContext).QueryObjects<AccountTransaction>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<AccountTransaction.GetMaterialTrxsBySEPAndCode_Class> GetMaterialTrxsBySEPAndCode(Guid SEP, string EXTERNALCODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetMaterialTrxsBySEPAndCode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SEP", SEP);
            paramList.Add("EXTERNALCODE", EXTERNALCODE);

            return TTReportNqlObject.QueryObjects<AccountTransaction.GetMaterialTrxsBySEPAndCode_Class>(queryDef, paramList, pi);
        }

        public static BindingList<AccountTransaction.GetMaterialTrxsBySEPAndCode_Class> GetMaterialTrxsBySEPAndCode(TTObjectContext objectContext, Guid SEP, string EXTERNALCODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetMaterialTrxsBySEPAndCode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SEP", SEP);
            paramList.Add("EXTERNALCODE", EXTERNALCODE);

            return TTReportNqlObject.QueryObjects<AccountTransaction.GetMaterialTrxsBySEPAndCode_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<AccountTransaction> GetById(TTObjectContext objectContext, IList<int> ID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetById"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ID", ID);

            return ((ITTQuery)objectContext).QueryObjects<AccountTransaction>(queryDef, paramList);
        }

        public static BindingList<AccountTransaction.GetProcedureIncomesByRessection_Class> GetProcedureIncomesByRessection(IList<Guid> DEPARTMENT, int DEPARTMENTFLAG, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetProcedureIncomesByRessection"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DEPARTMENT", DEPARTMENT);
            paramList.Add("DEPARTMENTFLAG", DEPARTMENTFLAG);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<AccountTransaction.GetProcedureIncomesByRessection_Class>(queryDef, paramList, pi);
        }

        public static BindingList<AccountTransaction.GetProcedureIncomesByRessection_Class> GetProcedureIncomesByRessection(TTObjectContext objectContext, IList<Guid> DEPARTMENT, int DEPARTMENTFLAG, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetProcedureIncomesByRessection"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DEPARTMENT", DEPARTMENT);
            paramList.Add("DEPARTMENTFLAG", DEPARTMENTFLAG);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<AccountTransaction.GetProcedureIncomesByRessection_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<AccountTransaction.GetPatientTotalNotPaid_Class> GetPatientTotalNotPaid(Guid APR, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetPatientTotalNotPaid"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("APR", APR);

            return TTReportNqlObject.QueryObjects<AccountTransaction.GetPatientTotalNotPaid_Class>(queryDef, paramList, pi);
        }

        public static BindingList<AccountTransaction.GetPatientTotalNotPaid_Class> GetPatientTotalNotPaid(TTObjectContext objectContext, Guid APR, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetPatientTotalNotPaid"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("APR", APR);

            return TTReportNqlObject.QueryObjects<AccountTransaction.GetPatientTotalNotPaid_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<AccountTransaction.GetPayerTotalPriceBySubEpisode_Class> GetPayerTotalPriceBySubEpisode(Guid SUBEPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetPayerTotalPriceBySubEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODE", SUBEPISODE);

            return TTReportNqlObject.QueryObjects<AccountTransaction.GetPayerTotalPriceBySubEpisode_Class>(queryDef, paramList, pi);
        }

        public static BindingList<AccountTransaction.GetPayerTotalPriceBySubEpisode_Class> GetPayerTotalPriceBySubEpisode(TTObjectContext objectContext, Guid SUBEPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetPayerTotalPriceBySubEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODE", SUBEPISODE);

            return TTReportNqlObject.QueryObjects<AccountTransaction.GetPayerTotalPriceBySubEpisode_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<AccountTransaction.GetMedulaEntryPriceBySEP_Class> GetMedulaEntryPriceBySEP(Guid SEP, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetMedulaEntryPriceBySEP"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SEP", SEP);

            return TTReportNqlObject.QueryObjects<AccountTransaction.GetMedulaEntryPriceBySEP_Class>(queryDef, paramList, pi);
        }

        public static BindingList<AccountTransaction.GetMedulaEntryPriceBySEP_Class> GetMedulaEntryPriceBySEP(TTObjectContext objectContext, Guid SEP, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetMedulaEntryPriceBySEP"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SEP", SEP);

            return TTReportNqlObject.QueryObjects<AccountTransaction.GetMedulaEntryPriceBySEP_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<AccountTransaction.GetMedulaTransactionsBySEPAndState_Class> GetMedulaTransactionsBySEPAndState(Guid SEP, IList<Guid> STATES, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetMedulaTransactionsBySEPAndState"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SEP", SEP);
            paramList.Add("STATES", STATES);

            return TTReportNqlObject.QueryObjects<AccountTransaction.GetMedulaTransactionsBySEPAndState_Class>(queryDef, paramList, pi);
        }

        public static BindingList<AccountTransaction.GetMedulaTransactionsBySEPAndState_Class> GetMedulaTransactionsBySEPAndState(TTObjectContext objectContext, Guid SEP, IList<Guid> STATES, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetMedulaTransactionsBySEPAndState"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SEP", SEP);
            paramList.Add("STATES", STATES);

            return TTReportNqlObject.QueryObjects<AccountTransaction.GetMedulaTransactionsBySEPAndState_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<AccountTransaction> GetTransactionsToSendMedulaBySEP(TTObjectContext objectContext, Guid SEP, IList<Guid> STATES)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetTransactionsToSendMedulaBySEP"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SEP", SEP);
            paramList.Add("STATES", STATES);

            return ((ITTQuery)objectContext).QueryObjects<AccountTransaction>(queryDef, paramList);
        }

    /// <summary>
    /// Toplu Fatura Hizmet Detay Bilgisi Öndöküm Raporu Sorgusu
    /// </summary>
        public static BindingList<AccountTransaction.CollectedInvoiceProcDetPreviewReportQuery1_Class> CollectedInvoiceProcDetPreviewReportQuery1(IList<string> PARAMRESOURCE, int PARAMRESOURCEFLAG, IList<string> PARAMEPISODE, IList<string> PARAMPAYER, int PATIENTSTATUS, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["CollectedInvoiceProcDetPreviewReportQuery1"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMRESOURCE", PARAMRESOURCE);
            paramList.Add("PARAMRESOURCEFLAG", PARAMRESOURCEFLAG);
            paramList.Add("PARAMEPISODE", PARAMEPISODE);
            paramList.Add("PARAMPAYER", PARAMPAYER);
            paramList.Add("PATIENTSTATUS", PATIENTSTATUS);

            return TTReportNqlObject.QueryObjects<AccountTransaction.CollectedInvoiceProcDetPreviewReportQuery1_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// Toplu Fatura Hizmet Detay Bilgisi Öndöküm Raporu Sorgusu
    /// </summary>
        public static BindingList<AccountTransaction.CollectedInvoiceProcDetPreviewReportQuery1_Class> CollectedInvoiceProcDetPreviewReportQuery1(TTObjectContext objectContext, IList<string> PARAMRESOURCE, int PARAMRESOURCEFLAG, IList<string> PARAMEPISODE, IList<string> PARAMPAYER, int PATIENTSTATUS, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["CollectedInvoiceProcDetPreviewReportQuery1"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMRESOURCE", PARAMRESOURCE);
            paramList.Add("PARAMRESOURCEFLAG", PARAMRESOURCEFLAG);
            paramList.Add("PARAMEPISODE", PARAMEPISODE);
            paramList.Add("PARAMPAYER", PARAMPAYER);
            paramList.Add("PATIENTSTATUS", PATIENTSTATUS);

            return TTReportNqlObject.QueryObjects<AccountTransaction.CollectedInvoiceProcDetPreviewReportQuery1_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<AccountTransaction> GetNotInvoiceIncludedTrxsBySEP(TTObjectContext objectContext, Guid SEP, Guid APR)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetNotInvoiceIncludedTrxsBySEP"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SEP", SEP);
            paramList.Add("APR", APR);

            return ((ITTQuery)objectContext).QueryObjects<AccountTransaction>(queryDef, paramList);
        }

        public static BindingList<AccountTransaction> GetNewAndCancelledMaterialTrxsBySEP(TTObjectContext objectContext, Guid SEP, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetNewAndCancelledMaterialTrxsBySEP"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SEP", SEP);

            return ((ITTQuery)objectContext).QueryObjects<AccountTransaction>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<AccountTransaction.OLAP_GetInvoiceByResource_Class> OLAP_GetInvoiceByResource(DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["OLAP_GetInvoiceByResource"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<AccountTransaction.OLAP_GetInvoiceByResource_Class>(queryDef, paramList, pi);
        }

        public static BindingList<AccountTransaction.OLAP_GetInvoiceByResource_Class> OLAP_GetInvoiceByResource(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["OLAP_GetInvoiceByResource"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<AccountTransaction.OLAP_GetInvoiceByResource_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<AccountTransaction.OLAP_GetInvoiceByPharmacyResource_Class> OLAP_GetInvoiceByPharmacyResource(DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["OLAP_GetInvoiceByPharmacyResource"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<AccountTransaction.OLAP_GetInvoiceByPharmacyResource_Class>(queryDef, paramList, pi);
        }

        public static BindingList<AccountTransaction.OLAP_GetInvoiceByPharmacyResource_Class> OLAP_GetInvoiceByPharmacyResource(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["OLAP_GetInvoiceByPharmacyResource"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<AccountTransaction.OLAP_GetInvoiceByPharmacyResource_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<AccountTransaction> GetInvoicedSubActionProcedureTrxsBySEP(TTObjectContext objectContext, Guid SEP)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetInvoicedSubActionProcedureTrxsBySEP"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SEP", SEP);

            return ((ITTQuery)objectContext).QueryObjects<AccountTransaction>(queryDef, paramList);
        }

    /// <summary>
    /// Toplu Fatura Hizmet Detay Bilgisi Öndöküm Raporu Sorgusu
    /// </summary>
        public static BindingList<AccountTransaction.CollectedInvoiceProcDetPreviewReportQuery2_Class> CollectedInvoiceProcDetPreviewReportQuery2(IList<string> PARAMPAYER, IList<string> PARAMRESOURCE, IList<string> PARAMRESOURCE2, IList<string> PARAMEPISODE, int PATIENTSTATUS, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["CollectedInvoiceProcDetPreviewReportQuery2"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMPAYER", PARAMPAYER);
            paramList.Add("PARAMRESOURCE", PARAMRESOURCE);
            paramList.Add("PARAMRESOURCE2", PARAMRESOURCE2);
            paramList.Add("PARAMEPISODE", PARAMEPISODE);
            paramList.Add("PATIENTSTATUS", PATIENTSTATUS);

            return TTReportNqlObject.QueryObjects<AccountTransaction.CollectedInvoiceProcDetPreviewReportQuery2_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// Toplu Fatura Hizmet Detay Bilgisi Öndöküm Raporu Sorgusu
    /// </summary>
        public static BindingList<AccountTransaction.CollectedInvoiceProcDetPreviewReportQuery2_Class> CollectedInvoiceProcDetPreviewReportQuery2(TTObjectContext objectContext, IList<string> PARAMPAYER, IList<string> PARAMRESOURCE, IList<string> PARAMRESOURCE2, IList<string> PARAMEPISODE, int PATIENTSTATUS, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["CollectedInvoiceProcDetPreviewReportQuery2"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMPAYER", PARAMPAYER);
            paramList.Add("PARAMRESOURCE", PARAMRESOURCE);
            paramList.Add("PARAMRESOURCE2", PARAMRESOURCE2);
            paramList.Add("PARAMEPISODE", PARAMEPISODE);
            paramList.Add("PATIENTSTATUS", PATIENTSTATUS);

            return TTReportNqlObject.QueryObjects<AccountTransaction.CollectedInvoiceProcDetPreviewReportQuery2_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<AccountTransaction.GetOrthesisProsthesisByProtocolNoAndYear_Class> GetOrthesisProsthesisByProtocolNoAndYear(DateTime STARTDATE, DateTime ENDDATE, string PROTOCOLNO, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetOrthesisProsthesisByProtocolNoAndYear"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("PROTOCOLNO", PROTOCOLNO);

            return TTReportNqlObject.QueryObjects<AccountTransaction.GetOrthesisProsthesisByProtocolNoAndYear_Class>(queryDef, paramList, pi);
        }

        public static BindingList<AccountTransaction.GetOrthesisProsthesisByProtocolNoAndYear_Class> GetOrthesisProsthesisByProtocolNoAndYear(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, string PROTOCOLNO, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetOrthesisProsthesisByProtocolNoAndYear"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("PROTOCOLNO", PROTOCOLNO);

            return TTReportNqlObject.QueryObjects<AccountTransaction.GetOrthesisProsthesisByProtocolNoAndYear_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<AccountTransaction> GetProcedureTrxToSendMedulaByEpisode(TTObjectContext objectContext, Guid EPISODE, IList<Guid> STATES)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetProcedureTrxToSendMedulaByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);
            paramList.Add("STATES", STATES);

            return ((ITTQuery)objectContext).QueryObjects<AccountTransaction>(queryDef, paramList);
        }

        public static BindingList<AccountTransaction.GetPackageTrxsByEpisode_Class> GetPackageTrxsByEpisode(Guid EPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetPackageTrxsByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<AccountTransaction.GetPackageTrxsByEpisode_Class>(queryDef, paramList, pi);
        }

        public static BindingList<AccountTransaction.GetPackageTrxsByEpisode_Class> GetPackageTrxsByEpisode(TTObjectContext objectContext, Guid EPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetPackageTrxsByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<AccountTransaction.GetPackageTrxsByEpisode_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<AccountTransaction> GetTrxBySEPProcedureAndState(TTObjectContext objectContext, IList<Guid> SEP, Guid PROCEDURE, IList<Guid> STATES)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetTrxBySEPProcedureAndState"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SEP", SEP);
            paramList.Add("PROCEDURE", PROCEDURE);
            paramList.Add("STATES", STATES);

            return ((ITTQuery)objectContext).QueryObjects<AccountTransaction>(queryDef, paramList);
        }

        public static BindingList<AccountTransaction.GetOrthesisProsthesisByProcedureAndDate_Class> GetOrthesisProsthesisByProcedureAndDate(DateTime STARTDATE, DateTime ENDDATE, IList<string> PROCEDURE, int PROCEDUREFLAG, IList<string> STATEID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetOrthesisProsthesisByProcedureAndDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("PROCEDURE", PROCEDURE);
            paramList.Add("PROCEDUREFLAG", PROCEDUREFLAG);
            paramList.Add("STATEID", STATEID);

            return TTReportNqlObject.QueryObjects<AccountTransaction.GetOrthesisProsthesisByProcedureAndDate_Class>(queryDef, paramList, pi);
        }

        public static BindingList<AccountTransaction.GetOrthesisProsthesisByProcedureAndDate_Class> GetOrthesisProsthesisByProcedureAndDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, IList<string> PROCEDURE, int PROCEDUREFLAG, IList<string> STATEID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetOrthesisProsthesisByProcedureAndDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("PROCEDURE", PROCEDURE);
            paramList.Add("PROCEDUREFLAG", PROCEDUREFLAG);
            paramList.Add("STATEID", STATEID);

            return TTReportNqlObject.QueryObjects<AccountTransaction.GetOrthesisProsthesisByProcedureAndDate_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Toplu Fatura Bazlı Gelir Kalemleri Listesi Procedure
    /// </summary>
        public static BindingList<AccountTransaction.CollInvoiceDetailedRevenueListProcedureQuery_Class> CollInvoiceDetailedRevenueListProcedureQuery(IList<string> ID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["CollInvoiceDetailedRevenueListProcedureQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ID", ID);

            return TTReportNqlObject.QueryObjects<AccountTransaction.CollInvoiceDetailedRevenueListProcedureQuery_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// Toplu Fatura Bazlı Gelir Kalemleri Listesi Procedure
    /// </summary>
        public static BindingList<AccountTransaction.CollInvoiceDetailedRevenueListProcedureQuery_Class> CollInvoiceDetailedRevenueListProcedureQuery(TTObjectContext objectContext, IList<string> ID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["CollInvoiceDetailedRevenueListProcedureQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ID", ID);

            return TTReportNqlObject.QueryObjects<AccountTransaction.CollInvoiceDetailedRevenueListProcedureQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<AccountTransaction> GetOrthesisProsthesisTrxsForInvoice(TTObjectContext objectContext, Guid STATE, Guid APR, Guid SEP)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetOrthesisProsthesisTrxsForInvoice"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STATE", STATE);
            paramList.Add("APR", APR);
            paramList.Add("SEP", SEP);

            return ((ITTQuery)objectContext).QueryObjects<AccountTransaction>(queryDef, paramList);
        }

        public static BindingList<AccountTransaction> GetAllTransactionsBySEP(TTObjectContext objectContext, Guid SEP, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetAllTransactionsBySEP"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SEP", SEP);

            return ((ITTQuery)objectContext).QueryObjects<AccountTransaction>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<AccountTransaction.GetMedulaTransactionCountBySEPAndState_Class> GetMedulaTransactionCountBySEPAndState(Guid SEP, IList<Guid> STATES, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetMedulaTransactionCountBySEPAndState"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SEP", SEP);
            paramList.Add("STATES", STATES);

            return TTReportNqlObject.QueryObjects<AccountTransaction.GetMedulaTransactionCountBySEPAndState_Class>(queryDef, paramList, pi);
        }

        public static BindingList<AccountTransaction.GetMedulaTransactionCountBySEPAndState_Class> GetMedulaTransactionCountBySEPAndState(TTObjectContext objectContext, Guid SEP, IList<Guid> STATES, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetMedulaTransactionCountBySEPAndState"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SEP", SEP);
            paramList.Add("STATES", STATES);

            return TTReportNqlObject.QueryObjects<AccountTransaction.GetMedulaTransactionCountBySEPAndState_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<AccountTransaction.GetPatientTotalPriceBySubEpisode_Class> GetPatientTotalPriceBySubEpisode(Guid SUBEPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetPatientTotalPriceBySubEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODE", SUBEPISODE);

            return TTReportNqlObject.QueryObjects<AccountTransaction.GetPatientTotalPriceBySubEpisode_Class>(queryDef, paramList, pi);
        }

        public static BindingList<AccountTransaction.GetPatientTotalPriceBySubEpisode_Class> GetPatientTotalPriceBySubEpisode(TTObjectContext objectContext, Guid SUBEPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetPatientTotalPriceBySubEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODE", SUBEPISODE);

            return TTReportNqlObject.QueryObjects<AccountTransaction.GetPatientTotalPriceBySubEpisode_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<AccountTransaction.GetPayerTotalPriceByEpisode_Class> GetPayerTotalPriceByEpisode(Guid EPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetPayerTotalPriceByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<AccountTransaction.GetPayerTotalPriceByEpisode_Class>(queryDef, paramList, pi);
        }

        public static BindingList<AccountTransaction.GetPayerTotalPriceByEpisode_Class> GetPayerTotalPriceByEpisode(TTObjectContext objectContext, Guid EPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetPayerTotalPriceByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<AccountTransaction.GetPayerTotalPriceByEpisode_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<AccountTransaction.GetPatientTotalPriceByEpisode_Class> GetPatientTotalPriceByEpisode(Guid EPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetPatientTotalPriceByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<AccountTransaction.GetPatientTotalPriceByEpisode_Class>(queryDef, paramList, pi);
        }

        public static BindingList<AccountTransaction.GetPatientTotalPriceByEpisode_Class> GetPatientTotalPriceByEpisode(TTObjectContext objectContext, Guid EPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetPatientTotalPriceByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<AccountTransaction.GetPatientTotalPriceByEpisode_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<AccountTransaction> GetTransactionsWithMedulaProcessNoBySEP(TTObjectContext objectContext, IList<Guid> SEP)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetTransactionsWithMedulaProcessNoBySEP"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SEP", SEP);

            return ((ITTQuery)objectContext).QueryObjects<AccountTransaction>(queryDef, paramList);
        }

    /// <summary>
    /// Hazıra Getirilmeyen Toplu Fatura Bazlı Ayrıntılı Gelir kalemleri Listesi(Material)
    /// </summary>
        public static BindingList<AccountTransaction.CollInvoiceDetailedRevenueListMaterialQuery_NP_Class> CollInvoiceDetailedRevenueListMaterialQuery_NP(IList<string> ID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["CollInvoiceDetailedRevenueListMaterialQuery_NP"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ID", ID);

            return TTReportNqlObject.QueryObjects<AccountTransaction.CollInvoiceDetailedRevenueListMaterialQuery_NP_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// Hazıra Getirilmeyen Toplu Fatura Bazlı Ayrıntılı Gelir kalemleri Listesi(Material)
    /// </summary>
        public static BindingList<AccountTransaction.CollInvoiceDetailedRevenueListMaterialQuery_NP_Class> CollInvoiceDetailedRevenueListMaterialQuery_NP(TTObjectContext objectContext, IList<string> ID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["CollInvoiceDetailedRevenueListMaterialQuery_NP"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ID", ID);

            return TTReportNqlObject.QueryObjects<AccountTransaction.CollInvoiceDetailedRevenueListMaterialQuery_NP_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Hazıra Getirilmeyen Toplu Fatura Bazlı Ayrıntılı Gelir kalemleri Listesi(Procedure)
    /// </summary>
        public static BindingList<AccountTransaction.CollInvoiceDetailedRevenueListProcedureQuery_NP_Class> CollInvoiceDetailedRevenueListProcedureQuery_NP(IList<string> ID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["CollInvoiceDetailedRevenueListProcedureQuery_NP"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ID", ID);

            return TTReportNqlObject.QueryObjects<AccountTransaction.CollInvoiceDetailedRevenueListProcedureQuery_NP_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// Hazıra Getirilmeyen Toplu Fatura Bazlı Ayrıntılı Gelir kalemleri Listesi(Procedure)
    /// </summary>
        public static BindingList<AccountTransaction.CollInvoiceDetailedRevenueListProcedureQuery_NP_Class> CollInvoiceDetailedRevenueListProcedureQuery_NP(TTObjectContext objectContext, IList<string> ID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["CollInvoiceDetailedRevenueListProcedureQuery_NP"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ID", ID);

            return TTReportNqlObject.QueryObjects<AccountTransaction.CollInvoiceDetailedRevenueListProcedureQuery_NP_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<AccountTransaction> GetTrxForMedulaBySubActionProcedure(TTObjectContext objectContext, Guid SUBACTIONPROCEDURE, IList<Guid> STATES)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetTrxForMedulaBySubActionProcedure"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBACTIONPROCEDURE", SUBACTIONPROCEDURE);
            paramList.Add("STATES", STATES);

            return ((ITTQuery)objectContext).QueryObjects<AccountTransaction>(queryDef, paramList);
        }

        public static BindingList<AccountTransaction> GetIncludedTrxsExceptCancelledByEpisode(TTObjectContext objectContext, Guid APR, Guid EPISODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetIncludedTrxsExceptCancelledByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("APR", APR);
            paramList.Add("EPISODE", EPISODE);

            return ((ITTQuery)objectContext).QueryObjects<AccountTransaction>(queryDef, paramList);
        }

        public static BindingList<AccountTransaction.GetPricesForInvoiceCollection_Class> GetPricesForInvoiceCollection(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetPricesForInvoiceCollection"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<AccountTransaction.GetPricesForInvoiceCollection_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<AccountTransaction.GetPricesForInvoiceCollection_Class> GetPricesForInvoiceCollection(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetPricesForInvoiceCollection"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<AccountTransaction.GetPricesForInvoiceCollection_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<AccountTransaction> GetPackageTransactionsByEpisode(TTObjectContext objectContext, Guid EPISODE, Guid APR, IList<Guid> STATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetPackageTransactionsByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);
            paramList.Add("APR", APR);
            paramList.Add("STATE", STATE);

            return ((ITTQuery)objectContext).QueryObjects<AccountTransaction>(queryDef, paramList);
        }

        public static BindingList<AccountTransaction.GetPricesForInvoiceCollectionDetail_Class> GetPricesForInvoiceCollectionDetail(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetPricesForInvoiceCollectionDetail"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<AccountTransaction.GetPricesForInvoiceCollectionDetail_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<AccountTransaction.GetPricesForInvoiceCollectionDetail_Class> GetPricesForInvoiceCollectionDetail(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetPricesForInvoiceCollectionDetail"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<AccountTransaction.GetPricesForInvoiceCollectionDetail_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<AccountTransaction> GetTrxForProcedureEntry(TTObjectContext objectContext, Guid SEP, IList<Guid> OBJECTID, int OBJECTIDCONTROL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetTrxForProcedureEntry"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SEP", SEP);
            paramList.Add("OBJECTID", OBJECTID);
            paramList.Add("OBJECTIDCONTROL", OBJECTIDCONTROL);

            return ((ITTQuery)objectContext).QueryObjects<AccountTransaction>(queryDef, paramList);
        }

        public static BindingList<AccountTransaction.GetTrxGroupedTrxs_Class> GetTrxGroupedTrxs(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetTrxGroupedTrxs"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<AccountTransaction.GetTrxGroupedTrxs_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<AccountTransaction.GetTrxGroupedTrxs_Class> GetTrxGroupedTrxs(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetTrxGroupedTrxs"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<AccountTransaction.GetTrxGroupedTrxs_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<AccountTransaction.GetBlockTransactionsCountBySEPs_Class> GetBlockTransactionsCountBySEPs(IList<Guid> BLOCKSTATES, IList<Guid> SEPS, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetBlockTransactionsCountBySEPs"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("BLOCKSTATES", BLOCKSTATES);
            paramList.Add("SEPS", SEPS);

            return TTReportNqlObject.QueryObjects<AccountTransaction.GetBlockTransactionsCountBySEPs_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<AccountTransaction.GetBlockTransactionsCountBySEPs_Class> GetBlockTransactionsCountBySEPs(TTObjectContext objectContext, IList<Guid> BLOCKSTATES, IList<Guid> SEPS, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetBlockTransactionsCountBySEPs"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("BLOCKSTATES", BLOCKSTATES);
            paramList.Add("SEPS", SEPS);

            return TTReportNqlObject.QueryObjects<AccountTransaction.GetBlockTransactionsCountBySEPs_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<AccountTransaction> GetByProcedureAndEpisode(TTObjectContext objectContext, Guid PROCEDURE, Guid EPISODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetByProcedureAndEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PROCEDURE", PROCEDURE);
            paramList.Add("EPISODE", EPISODE);

            return ((ITTQuery)objectContext).QueryObjects<AccountTransaction>(queryDef, paramList);
        }

        public static BindingList<AccountTransaction.GetTrxForFTR_Class> GetTrxForFTR(Guid SEP, string EXTERNALCODE, DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetTrxForFTR"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SEP", SEP);
            paramList.Add("EXTERNALCODE", EXTERNALCODE);
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<AccountTransaction.GetTrxForFTR_Class>(queryDef, paramList, pi);
        }

        public static BindingList<AccountTransaction.GetTrxForFTR_Class> GetTrxForFTR(TTObjectContext objectContext, Guid SEP, string EXTERNALCODE, DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetTrxForFTR"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SEP", SEP);
            paramList.Add("EXTERNALCODE", EXTERNALCODE);
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<AccountTransaction.GetTrxForFTR_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<AccountTransaction> GetProcTrxsByDateAndSepMaster(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, Guid SEPMASTER)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetProcTrxsByDateAndSepMaster"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("SEPMASTER", SEPMASTER);

            return ((ITTQuery)objectContext).QueryObjects<AccountTransaction>(queryDef, paramList);
        }

        public static BindingList<AccountTransaction.GetSEPTotalMedulaPriceByTerm_Class> GetSEPTotalMedulaPriceByTerm(Guid TERM, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetSEPTotalMedulaPriceByTerm"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TERM", TERM);

            return TTReportNqlObject.QueryObjects<AccountTransaction.GetSEPTotalMedulaPriceByTerm_Class>(queryDef, paramList, pi);
        }

        public static BindingList<AccountTransaction.GetSEPTotalMedulaPriceByTerm_Class> GetSEPTotalMedulaPriceByTerm(TTObjectContext objectContext, Guid TERM, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetSEPTotalMedulaPriceByTerm"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TERM", TERM);

            return TTReportNqlObject.QueryObjects<AccountTransaction.GetSEPTotalMedulaPriceByTerm_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// ÜTS Kullanım Kesinleştirme
    /// </summary>
        public static BindingList<AccountTransaction> GetTrxsForUTSUsageCommitment(TTObjectContext objectContext, IList<Guid> SEPS, int UTSUSAGECOMMITMENT)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetTrxsForUTSUsageCommitment"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SEPS", SEPS);
            paramList.Add("UTSUSAGECOMMITMENT", UTSUSAGECOMMITMENT);

            return ((ITTQuery)objectContext).QueryObjects<AccountTransaction>(queryDef, paramList);
        }

        public static BindingList<AccountTransaction> GetTrxsForUTS(TTObjectContext objectContext, IList<Guid> SEPS)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetTrxsForUTS"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SEPS", SEPS);

            return ((ITTQuery)objectContext).QueryObjects<AccountTransaction>(queryDef, paramList);
        }

        public static BindingList<AccountTransaction.GetHBYSPriceBySEP_Class> GetHBYSPriceBySEP(IList<Guid> SEPOBJECTID, APRTypeEnum APRTYPE, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetHBYSPriceBySEP"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SEPOBJECTID", SEPOBJECTID);
            paramList.Add("APRTYPE", (int)APRTYPE);

            return TTReportNqlObject.QueryObjects<AccountTransaction.GetHBYSPriceBySEP_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<AccountTransaction.GetHBYSPriceBySEP_Class> GetHBYSPriceBySEP(TTObjectContext objectContext, IList<Guid> SEPOBJECTID, APRTypeEnum APRTYPE, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetHBYSPriceBySEP"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SEPOBJECTID", SEPOBJECTID);
            paramList.Add("APRTYPE", (int)APRTYPE);

            return TTReportNqlObject.QueryObjects<AccountTransaction.GetHBYSPriceBySEP_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<AccountTransaction.GetTotalMedulaPriceByTerm_Class> GetTotalMedulaPriceByTerm(Guid TERM, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetTotalMedulaPriceByTerm"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TERM", TERM);

            return TTReportNqlObject.QueryObjects<AccountTransaction.GetTotalMedulaPriceByTerm_Class>(queryDef, paramList, pi);
        }

        public static BindingList<AccountTransaction.GetTotalMedulaPriceByTerm_Class> GetTotalMedulaPriceByTerm(TTObjectContext objectContext, Guid TERM, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetTotalMedulaPriceByTerm"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TERM", TERM);

            return TTReportNqlObject.QueryObjects<AccountTransaction.GetTotalMedulaPriceByTerm_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<AccountTransaction.GetCountOfAccTrx_Class> GetCountOfAccTrx(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetCountOfAccTrx"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<AccountTransaction.GetCountOfAccTrx_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<AccountTransaction.GetCountOfAccTrx_Class> GetCountOfAccTrx(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetCountOfAccTrx"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<AccountTransaction.GetCountOfAccTrx_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<AccountTransaction.InvoicedProceduresReportQuery_Class> InvoicedProceduresReportQuery(DateTime STARTDATE, DateTime ENDDATE, int PAYERTYPE, int PAYERTYPECONTROL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["InvoicedProceduresReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("PAYERTYPE", PAYERTYPE);
            paramList.Add("PAYERTYPECONTROL", PAYERTYPECONTROL);

            return TTReportNqlObject.QueryObjects<AccountTransaction.InvoicedProceduresReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<AccountTransaction.InvoicedProceduresReportQuery_Class> InvoicedProceduresReportQuery(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, int PAYERTYPE, int PAYERTYPECONTROL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["InvoicedProceduresReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("PAYERTYPE", PAYERTYPE);
            paramList.Add("PAYERTYPECONTROL", PAYERTYPECONTROL);

            return TTReportNqlObject.QueryObjects<AccountTransaction.InvoicedProceduresReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<AccountTransaction.ForeignParticipationStatQuery_Class> ForeignParticipationStatQuery(DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["ForeignParticipationStatQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<AccountTransaction.ForeignParticipationStatQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<AccountTransaction.ForeignParticipationStatQuery_Class> ForeignParticipationStatQuery(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["ForeignParticipationStatQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<AccountTransaction.ForeignParticipationStatQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<AccountTransaction.PrepareSGKMIFQuery_Class> PrepareSGKMIFQuery(Guid TERM, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["PrepareSGKMIFQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TERM", TERM);

            return TTReportNqlObject.QueryObjects<AccountTransaction.PrepareSGKMIFQuery_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<AccountTransaction.PrepareSGKMIFQuery_Class> PrepareSGKMIFQuery(TTObjectContext objectContext, Guid TERM, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["PrepareSGKMIFQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TERM", TERM);

            return TTReportNqlObject.QueryObjects<AccountTransaction.PrepareSGKMIFQuery_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<AccountTransaction.PrepareOfficialMIFQuery_Class> PrepareOfficialMIFQuery(Guid TERM, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["PrepareOfficialMIFQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TERM", TERM);

            return TTReportNqlObject.QueryObjects<AccountTransaction.PrepareOfficialMIFQuery_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<AccountTransaction.PrepareOfficialMIFQuery_Class> PrepareOfficialMIFQuery(TTObjectContext objectContext, Guid TERM, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["PrepareOfficialMIFQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TERM", TERM);

            return TTReportNqlObject.QueryObjects<AccountTransaction.PrepareOfficialMIFQuery_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<AccountTransaction.UninvoicedProceduresReportQuery_Class> UninvoicedProceduresReportQuery(DateTime STARTDATE, DateTime ENDDATE, int PAYERTYPE, int PAYERTYPECONTROL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["UninvoicedProceduresReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("PAYERTYPE", PAYERTYPE);
            paramList.Add("PAYERTYPECONTROL", PAYERTYPECONTROL);

            return TTReportNqlObject.QueryObjects<AccountTransaction.UninvoicedProceduresReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<AccountTransaction.UninvoicedProceduresReportQuery_Class> UninvoicedProceduresReportQuery(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, int PAYERTYPE, int PAYERTYPECONTROL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["UninvoicedProceduresReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("PAYERTYPE", PAYERTYPE);
            paramList.Add("PAYERTYPECONTROL", PAYERTYPECONTROL);

            return TTReportNqlObject.QueryObjects<AccountTransaction.UninvoicedProceduresReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<AccountTransaction.GetAccountTrxDrugBySEPMat_Class> GetAccountTrxDrugBySEPMat(Guid EPISODE, DateTime ENDDATE, DateTime STARTDATE, Guid MATERIAL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetAccountTrxDrugBySEPMat"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("MATERIAL", MATERIAL);

            return TTReportNqlObject.QueryObjects<AccountTransaction.GetAccountTrxDrugBySEPMat_Class>(queryDef, paramList, pi);
        }

        public static BindingList<AccountTransaction.GetAccountTrxDrugBySEPMat_Class> GetAccountTrxDrugBySEPMat(TTObjectContext objectContext, Guid EPISODE, DateTime ENDDATE, DateTime STARTDATE, Guid MATERIAL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetAccountTrxDrugBySEPMat"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("MATERIAL", MATERIAL);

            return TTReportNqlObject.QueryObjects<AccountTransaction.GetAccountTrxDrugBySEPMat_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<AccountTransaction.GetIncludedTrxsTotalPriceByEpisode_Class> GetIncludedTrxsTotalPriceByEpisode(Guid APR, Guid EPISODE, IList<Guid> BLOCKINGSTATEDEFLIST, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetIncludedTrxsTotalPriceByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("APR", APR);
            paramList.Add("EPISODE", EPISODE);
            paramList.Add("BLOCKINGSTATEDEFLIST", BLOCKINGSTATEDEFLIST);

            return TTReportNqlObject.QueryObjects<AccountTransaction.GetIncludedTrxsTotalPriceByEpisode_Class>(queryDef, paramList, pi);
        }

        public static BindingList<AccountTransaction.GetIncludedTrxsTotalPriceByEpisode_Class> GetIncludedTrxsTotalPriceByEpisode(TTObjectContext objectContext, Guid APR, Guid EPISODE, IList<Guid> BLOCKINGSTATEDEFLIST, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetIncludedTrxsTotalPriceByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("APR", APR);
            paramList.Add("EPISODE", EPISODE);
            paramList.Add("BLOCKINGSTATEDEFLIST", BLOCKINGSTATEDEFLIST);

            return TTReportNqlObject.QueryObjects<AccountTransaction.GetIncludedTrxsTotalPriceByEpisode_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<AccountTransaction.GetTransactionsForReceiptByEpisodeRprtQuery_Class> GetTransactionsForReceiptByEpisodeRprtQuery(Guid APR, IList<Guid> BLOCKINGSTATEDEFLIST, Guid CURRENTSTATEID, Guid EPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetTransactionsForReceiptByEpisodeRprtQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("APR", APR);
            paramList.Add("BLOCKINGSTATEDEFLIST", BLOCKINGSTATEDEFLIST);
            paramList.Add("CURRENTSTATEID", CURRENTSTATEID);
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<AccountTransaction.GetTransactionsForReceiptByEpisodeRprtQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<AccountTransaction.GetTransactionsForReceiptByEpisodeRprtQuery_Class> GetTransactionsForReceiptByEpisodeRprtQuery(TTObjectContext objectContext, Guid APR, IList<Guid> BLOCKINGSTATEDEFLIST, Guid CURRENTSTATEID, Guid EPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetTransactionsForReceiptByEpisodeRprtQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("APR", APR);
            paramList.Add("BLOCKINGSTATEDEFLIST", BLOCKINGSTATEDEFLIST);
            paramList.Add("CURRENTSTATEID", CURRENTSTATEID);
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<AccountTransaction.GetTransactionsForReceiptByEpisodeRprtQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<AccountTransaction.GetProceduresForDashboard_Class> GetProceduresForDashboard(Guid TERM, Guid USER, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetProceduresForDashboard"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TERM", TERM);
            paramList.Add("USER", USER);

            return TTReportNqlObject.QueryObjects<AccountTransaction.GetProceduresForDashboard_Class>(queryDef, paramList, pi);
        }

        public static BindingList<AccountTransaction.GetProceduresForDashboard_Class> GetProceduresForDashboard(TTObjectContext objectContext, Guid TERM, Guid USER, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetProceduresForDashboard"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TERM", TERM);
            paramList.Add("USER", USER);

            return TTReportNqlObject.QueryObjects<AccountTransaction.GetProceduresForDashboard_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<AccountTransaction.GetInconsistentForDashboard_Class> GetInconsistentForDashboard(Guid TERM, Guid USER, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetInconsistentForDashboard"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TERM", TERM);
            paramList.Add("USER", USER);

            return TTReportNqlObject.QueryObjects<AccountTransaction.GetInconsistentForDashboard_Class>(queryDef, paramList, pi);
        }

        public static BindingList<AccountTransaction.GetInconsistentForDashboard_Class> GetInconsistentForDashboard(TTObjectContext objectContext, Guid TERM, Guid USER, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetInconsistentForDashboard"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TERM", TERM);
            paramList.Add("USER", USER);

            return TTReportNqlObject.QueryObjects<AccountTransaction.GetInconsistentForDashboard_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<AccountTransaction> GetTransactionsBySEPMaster(TTObjectContext objectContext, Guid SEPMASTER, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].QueryDefs["GetTransactionsBySEPMaster"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SEPMASTER", SEPMASTER);

            return ((ITTQuery)objectContext).QueryObjects<AccountTransaction>(queryDef, paramList, injectionSQL);
        }

    /// <summary>
    /// Toplam indirim tutarıdır
    /// </summary>
        public double? TotalDiscountPrice
        {
            get { return (double?)this["TOTALDISCOUNTPRICE"]; }
            set { this["TOTALDISCOUNTPRICE"] = value; }
        }

    /// <summary>
    /// Oluşan Kalemin Birim fiyatıdır
    /// </summary>
        public double? UnitPrice
        {
            get { return (double?)this["UNITPRICE"]; }
            set { this["UNITPRICE"] = value; }
        }

    /// <summary>
    /// Ücretleri Oluşmuş Hizmet ve Malzemelerin Ayrıntılı Kısa Kodlarıdır
    /// </summary>
        public string ExternalCode
        {
            get { return (string)this["EXTERNALCODE"]; }
            set { this["EXTERNALCODE"] = value; }
        }

    /// <summary>
    /// Ücretleri Oluşmuş Hizmet ve Malzemelerin Miktarıdır
    /// </summary>
        public double? Amount
        {
            get { return (double?)this["AMOUNT"]; }
            set { this["AMOUNT"] = value; }
        }

    /// <summary>
    /// Paket dışı aktarma nedenidir
    /// </summary>
        public PackageOutReasonEnum? PackageOutReason
        {
            get { return (PackageOutReasonEnum?)(int?)this["PACKAGEOUTREASON"]; }
            set { this["PACKAGEOUTREASON"] = value; }
        }

    /// <summary>
    /// Ücretleri Oluşmuş Hizmet ve Malzemelerin Ayrıntılı Adıdır
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

    /// <summary>
    /// Fiyatın Oluştuğu Tarihtir
    /// </summary>
        public DateTime? TransactionDate
        {
            get { return (DateTime?)this["TRANSACTIONDATE"]; }
            set { this["TRANSACTIONDATE"] = value; }
        }

    /// <summary>
    /// Faturaya Dahillik
    /// </summary>
        public bool? InvoiceInclusion
        {
            get { return (bool?)this["INVOICEINCLUSION"]; }
            set { this["INVOICEINCLUSION"] = value; }
        }

    /// <summary>
    /// Kullanıcı Birim Fiyat ya da Kod bilgisini değiştirdiğini gösterir
    /// </summary>
        public bool? MedulaInfoChangedByUser
        {
            get { return (bool?)this["MEDULAINFOCHANGEDBYUSER"]; }
            set { this["MEDULAINFOCHANGEDBYUSER"] = value; }
        }

    /// <summary>
    /// Tarih, Fiyat, Miktar gibi bilgileri güncellenmiş mi
    /// </summary>
        public bool? MedulaInfoUpdated
        {
            get { return (bool?)this["MEDULAINFOUPDATED"]; }
            set { this["MEDULAINFOUPDATED"] = value; }
        }

    /// <summary>
    /// Personel Notu
    /// </summary>
        public string UserNote
        {
            get { return (string)this["USERNOTE"]; }
            set { this["USERNOTE"] = value; }
        }

    /// <summary>
    /// Medula İşlem Sıra Numarası
    /// </summary>
        public string MedulaProcessNo
        {
            get { return (string)this["MEDULAPROCESSNO"]; }
            set { this["MEDULAPROCESSNO"] = value; }
        }

    /// <summary>
    /// Id
    /// </summary>
        public TTSequence Id
        {
            get { return GetSequence("ID"); }
        }

    /// <summary>
    /// Medula Sonuç Kodu
    /// </summary>
        public string MedulaResultCode
        {
            get { return (string)this["MEDULARESULTCODE"]; }
            set { this["MEDULARESULTCODE"] = value; }
        }

    /// <summary>
    /// Medula Sonuç Mesajı
    /// </summary>
        public string MedulaResultMessage
        {
            get { return (string)this["MEDULARESULTMESSAGE"]; }
            set { this["MEDULARESULTMESSAGE"] = value; }
        }

    /// <summary>
    /// Meduladan Dönen Fiyat
    /// </summary>
        public Currency? MedulaPrice
        {
            get { return (Currency?)this["MEDULAPRICE"]; }
            set { this["MEDULAPRICE"] = value; }
        }

    /// <summary>
    /// Oluşan Kalemin Birim fiyatıdır
    /// </summary>
        public double? UnitPriceOrg
        {
            get { return (double?)this["UNITPRICEORG"]; }
            set { this["UNITPRICEORG"] = value; }
        }

    /// <summary>
    /// Medulaya gidecek açıklama bilgisi eğer kullanıcı tarafından değiştirilmiş ise bu alanda tutuluyor
    /// </summary>
        public string MedulaDescription
        {
            get { return (string)this["MEDULADESCRIPTION"]; }
            set { this["MEDULADESCRIPTION"] = value; }
        }

    /// <summary>
    /// Medula Yatak Numarası
    /// </summary>
        public string MedulaBedNo
        {
            get { return (string)this["MEDULABEDNO"]; }
            set { this["MEDULABEDNO"] = value; }
        }

    /// <summary>
    /// Malzeme Satın Alış Tarihi
    /// </summary>
        public DateTime? PurchaseDate
        {
            get { return (DateTime?)this["PURCHASEDATE"]; }
            set { this["PURCHASEDATE"] = value; }
        }

    /// <summary>
    /// İlaç veya malzeme için barkod bilgisi
    /// </summary>
        public string Barcode
        {
            get { return (string)this["BARCODE"]; }
            set { this["BARCODE"] = value; }
        }

    /// <summary>
    /// Firma Tanımlayıcı Numarası
    /// </summary>
        public string ProducerCode
        {
            get { return (string)this["PRODUCERCODE"]; }
            set { this["PRODUCERCODE"] = value; }
        }

        public SendToENabizEnum? Nabiz700Status
        {
            get { return (SendToENabizEnum?)(int?)this["NABIZ700STATUS"]; }
            set { this["NABIZ700STATUS"] = value; }
        }

    /// <summary>
    /// Nabız Sonuç Kodu
    /// </summary>
        public string NabizResultCode
        {
            get { return (string)this["NABIZRESULTCODE"]; }
            set { this["NABIZRESULTCODE"] = value; }
        }

    /// <summary>
    /// Nabız Sonuç Mesajı
    /// </summary>
        public string NabizResultMessage
        {
            get { return (string)this["NABIZRESULTMESSAGE"]; }
            set { this["NABIZRESULTMESSAGE"] = value; }
        }

    /// <summary>
    /// UTS Kullanım Kesinleştirme Yapıldı
    /// </summary>
        public bool? UTSUsageCommitment
        {
            get { return (bool?)this["UTSUSAGECOMMITMENT"]; }
            set { this["UTSUSAGECOMMITMENT"] = value; }
        }

    /// <summary>
    /// Medula Accession No
    /// </summary>
        public string MedulaAccessionNo
        {
            get { return (string)this["MEDULAACCESSIONNO"]; }
            set { this["MEDULAACCESSIONNO"] = value; }
        }

    /// <summary>
    /// Medula Bayi No
    /// </summary>
        public string MedulaDealerNo
        {
            get { return (string)this["MEDULADEALERNO"]; }
            set { this["MEDULADEALERNO"] = value; }
        }

    /// <summary>
    /// Sağ Sol Bilgisi
    /// </summary>
        public SurgeryLeftRight? Position
        {
            get { return (SurgeryLeftRight?)(int?)this["POSITION"]; }
            set { this["POSITION"] = value; }
        }

    /// <summary>
    /// Muhasebe yetkilisi mutemedi alındısı malzeme bilgisine ilişki
    /// </summary>
        public ReceiptMaterial ReceiptMaterial
        {
            get { return (ReceiptMaterial)((ITTObject)this).GetParent("RECEIPTMATERIAL"); }
            set { this["RECEIPTMATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SubEpisodeProtocol SubEpisodeProtocol
        {
            get { return (SubEpisodeProtocol)((ITTObject)this).GetParent("SUBEPISODEPROTOCOL"); }
            set { this["SUBEPISODEPROTOCOL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// SubActionMaterial a ilişki
    /// </summary>
        public SubActionMaterial SubActionMaterial
        {
            get { return (SubActionMaterial)((ITTObject)this).GetParent("SUBACTIONMATERIAL"); }
            set { this["SUBACTIONMATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Hasta faturası malzeme bilgisine ilişki
    /// </summary>
        public PatientInvoiceMaterial PatientInvoiceMaterial
        {
            get { return (PatientInvoiceMaterial)((ITTObject)this).GetParent("PATIENTINVOICEMATERIAL"); }
            set { this["PATIENTINVOICEMATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Toplu fatura ile ilişki
    /// </summary>
        public CollectedPatientList CollectedPatientList
        {
            get { return (CollectedPatientList)((ITTObject)this).GetParent("COLLECTEDPATIENTLIST"); }
            set { this["COLLECTEDPATIENTLIST"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Kurum faturası paket bilgisine ilişki
    /// </summary>
        public PayerInvoicePackage PayerInvoicePackage
        {
            get { return (PayerInvoicePackage)((ITTObject)this).GetParent("PAYERINVOICEPACKAGE"); }
            set { this["PAYERINVOICEPACKAGE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Fiyat ile ilişki
    /// </summary>
        public PricingDetailDefinition PricingDetail
        {
            get { return (PricingDetailDefinition)((ITTObject)this).GetParent("PRICINGDETAIL"); }
            set { this["PRICINGDETAIL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// SubActionProcedure e ilişki
    /// </summary>
        public SubActionProcedure SubActionProcedure
        {
            get { return (SubActionProcedure)((ITTObject)this).GetParent("SUBACTIONPROCEDURE"); }
            set { this["SUBACTIONPROCEDURE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Muhasebe yetkilisi mutemedi alındısı iade işlemi ile ilişki
    /// </summary>
        public ReceiptBackDetail ReceiptBackDetail
        {
            get { return (ReceiptBackDetail)((ITTObject)this).GetParent("RECEIPTBACKDETAIL"); }
            set { this["RECEIPTBACKDETAIL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Kurum faturası malzeme bilgisine ilişki
    /// </summary>
        public PayerInvoiceMaterial PayerInvoiceMaterial
        {
            get { return (PayerInvoiceMaterial)((ITTObject)this).GetParent("PAYERINVOICEMATERIAL"); }
            set { this["PAYERINVOICEMATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Paket tanımına ilişki
    /// </summary>
        public PackageDefinition PackageDefinition
        {
            get { return (PackageDefinition)((ITTObject)this).GetParent("PACKAGEDEFINITION"); }
            set { this["PACKAGEDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Hasta faturası hizmet bilgisine ilişki
    /// </summary>
        public PatientInvoiceProcedure PatientInvoiceProcedure
        {
            get { return (PatientInvoiceProcedure)((ITTObject)this).GetParent("PATIENTINVOICEPROCEDURE"); }
            set { this["PATIENTINVOICEPROCEDURE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Muhasebe yetkilisi mutemedi alındısı hizmet bilgisine ilişki
    /// </summary>
        public ReceiptProcedure ReceiptProcedure
        {
            get { return (ReceiptProcedure)((ITTObject)this).GetParent("RECEIPTPROCEDURE"); }
            set { this["RECEIPTPROCEDURE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Hasta veya kurum balansı ile ilişki
    /// </summary>
        public AccountPayableReceivable AccountPayableReceivable
        {
            get { return (AccountPayableReceivable)((ITTObject)this).GetParent("ACCOUNTPAYABLERECEIVABLE"); }
            set { this["ACCOUNTPAYABLERECEIVABLE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Yatış action ında Ödendi durumuna alınanlar için
    /// </summary>
        public InpatientAdmission InpatientAdmission
        {
            get { return (InpatientAdmission)((ITTObject)this).GetParent("INPATIENTADMISSION"); }
            set { this["INPATIENTADMISSION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Kurum faturası hizmet bilgisine ilişki
    /// </summary>
        public PayerInvoiceProcedure PayerInvoiceProcedure
        {
            get { return (PayerInvoiceProcedure)((ITTObject)this).GetParent("PAYERINVOICEPROCEDURE"); }
            set { this["PAYERINVOICEPROCEDURE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// OzelDurum
    /// </summary>
        public OzelDurum OzelDurum
        {
            get { return (OzelDurum)((ITTObject)this).GetParent("OZELDURUM"); }
            set { this["OZELDURUM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public AyniFarkliKesi AyniFarkliKesi
        {
            get { return (AyniFarkliKesi)((ITTObject)this).GetParent("AYNIFARKLIKESI"); }
            set { this["AYNIFARKLIKESI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Transaction nun doktor bilgisi eğer değiştirilmiş ise bu alanda tutulacak
    /// </summary>
        public ResUser Doctor
        {
            get { return (ResUser)((ITTObject)this).GetParent("DOCTOR"); }
            set { this["DOCTOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public StockTransaction StockOutTransaction
        {
            get { return (StockTransaction)((ITTObject)this).GetParent("STOCKOUTTRANSACTION"); }
            set { this["STOCKOUTTRANSACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public UTSNotificationDetail UTSNotificationDetail
        {
            get { return (UTSNotificationDetail)((ITTObject)this).GetParent("UTSNOTIFICATIONDETAIL"); }
            set { this["UTSNOTIFICATIONDETAIL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateAccountTrxDocumentCollection()
        {
            _AccountTrxDocument = new AccountTrxDocument.ChildAccountTrxDocumentCollection(this, new Guid("dac017e3-d72d-4924-a8ee-40a7b1ce4820"));
            ((ITTChildObjectCollection)_AccountTrxDocument).GetChildren();
        }

        protected AccountTrxDocument.ChildAccountTrxDocumentCollection _AccountTrxDocument = null;
    /// <summary>
    /// Child collection for AccountTransaction a relation
    /// </summary>
        public AccountTrxDocument.ChildAccountTrxDocumentCollection AccountTrxDocument
        {
            get
            {
                if (_AccountTrxDocument == null)
                    CreateAccountTrxDocumentCollection();
                return _AccountTrxDocument;
            }
        }

        virtual protected void CreatePatientPaymentDetailCollection()
        {
            _PatientPaymentDetail = new PatientPaymentDetail.ChildPatientPaymentDetailCollection(this, new Guid("aa79d6a8-3662-4b9d-86c9-a79f0758d2cd"));
            ((ITTChildObjectCollection)_PatientPaymentDetail).GetChildren();
        }

        protected PatientPaymentDetail.ChildPatientPaymentDetailCollection _PatientPaymentDetail = null;
    /// <summary>
    /// Child collection for Ödeme detayı accounttransaction ilişkisi
    /// </summary>
        public PatientPaymentDetail.ChildPatientPaymentDetailCollection PatientPaymentDetail
        {
            get
            {
                if (_PatientPaymentDetail == null)
                    CreatePatientPaymentDetailCollection();
                return _PatientPaymentDetail;
            }
        }

        virtual protected void CreateAccountingProcessProceduresCollection()
        {
            _AccountingProcessProcedures = new AccountingProcessProcedure.ChildAccountingProcessProcedureCollection(this, new Guid("d7aa8cd0-1f42-4db0-a963-f3a47feb6a99"));
            ((ITTChildObjectCollection)_AccountingProcessProcedures).GetChildren();
        }

        protected AccountingProcessProcedure.ChildAccountingProcessProcedureCollection _AccountingProcessProcedures = null;
        public AccountingProcessProcedure.ChildAccountingProcessProcedureCollection AccountingProcessProcedures
        {
            get
            {
                if (_AccountingProcessProcedures == null)
                    CreateAccountingProcessProceduresCollection();
                return _AccountingProcessProcedures;
            }
        }

        virtual protected void CreateAccountingProcessMaterialsCollection()
        {
            _AccountingProcessMaterials = new AccountingProcessMaterial.ChildAccountingProcessMaterialCollection(this, new Guid("973ad935-81d8-4f96-8295-48567f5d7d55"));
            ((ITTChildObjectCollection)_AccountingProcessMaterials).GetChildren();
        }

        protected AccountingProcessMaterial.ChildAccountingProcessMaterialCollection _AccountingProcessMaterials = null;
        public AccountingProcessMaterial.ChildAccountingProcessMaterialCollection AccountingProcessMaterials
        {
            get
            {
                if (_AccountingProcessMaterials == null)
                    CreateAccountingProcessMaterialsCollection();
                return _AccountingProcessMaterials;
            }
        }

        virtual protected void CreateAccountingProcessPackagesCollection()
        {
            _AccountingProcessPackages = new AccountingProcessPackage.ChildAccountingProcessPackageCollection(this, new Guid("b51baf69-6f77-4639-afe4-7bae79a56dd0"));
            ((ITTChildObjectCollection)_AccountingProcessPackages).GetChildren();
        }

        protected AccountingProcessPackage.ChildAccountingProcessPackageCollection _AccountingProcessPackages = null;
        public AccountingProcessPackage.ChildAccountingProcessPackageCollection AccountingProcessPackages
        {
            get
            {
                if (_AccountingProcessPackages == null)
                    CreateAccountingProcessPackagesCollection();
                return _AccountingProcessPackages;
            }
        }

        virtual protected void CreateCokluOzelDurumCollection()
        {
            _CokluOzelDurum = new CokluOzelDurum.ChildCokluOzelDurumCollection(this, new Guid("3fb8330a-7e42-4eb4-bf5c-6fad34b40d37"));
            ((ITTChildObjectCollection)_CokluOzelDurum).GetChildren();
        }

        protected CokluOzelDurum.ChildCokluOzelDurumCollection _CokluOzelDurum = null;
        public CokluOzelDurum.ChildCokluOzelDurumCollection CokluOzelDurum
        {
            get
            {
                if (_CokluOzelDurum == null)
                    CreateCokluOzelDurumCollection();
                return _CokluOzelDurum;
            }
        }

        virtual protected void CreateBondProceduresCollection()
        {
            _BondProcedures = new BondProcedure.ChildBondProcedureCollection(this, new Guid("464ec02e-0f35-4c4e-a84e-29ef7ceb7f3a"));
            ((ITTChildObjectCollection)_BondProcedures).GetChildren();
        }

        protected BondProcedure.ChildBondProcedureCollection _BondProcedures = null;
        public BondProcedure.ChildBondProcedureCollection BondProcedures
        {
            get
            {
                if (_BondProcedures == null)
                    CreateBondProceduresCollection();
                return _BondProcedures;
            }
        }

        virtual protected void CreateENabizMaterialCollection()
        {
            _ENabizMaterial = new ENabizMaterial.ChildENabizMaterialCollection(this, new Guid("95613662-043c-4b7c-a675-7b5f96ebdfd0"));
            ((ITTChildObjectCollection)_ENabizMaterial).GetChildren();
        }

        protected ENabizMaterial.ChildENabizMaterialCollection _ENabizMaterial = null;
        public ENabizMaterial.ChildENabizMaterialCollection ENabizMaterial
        {
            get
            {
                if (_ENabizMaterial == null)
                    CreateENabizMaterialCollection();
                return _ENabizMaterial;
            }
        }

        virtual protected void CreateInvoiceLogsCollection()
        {
            _InvoiceLogs = new InvoiceLog.ChildInvoiceLogCollection(this, new Guid("9179343d-3d93-414c-9beb-c6a1ce118799"));
            ((ITTChildObjectCollection)_InvoiceLogs).GetChildren();
        }

        protected InvoiceLog.ChildInvoiceLogCollection _InvoiceLogs = null;
        public InvoiceLog.ChildInvoiceLogCollection InvoiceLogs
        {
            get
            {
                if (_InvoiceLogs == null)
                    CreateInvoiceLogsCollection();
                return _InvoiceLogs;
            }
        }

        protected AccountTransaction(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected AccountTransaction(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected AccountTransaction(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected AccountTransaction(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected AccountTransaction(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ACCOUNTTRANSACTION", dataRow) { }
        protected AccountTransaction(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ACCOUNTTRANSACTION", dataRow, isImported) { }
        public AccountTransaction(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public AccountTransaction(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public AccountTransaction() : base() { }

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
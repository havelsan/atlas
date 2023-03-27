
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PayerInvoice")] 

    /// <summary>
    /// Kurum Faturası İşlemi
    /// </summary>
    public  partial class PayerInvoice : EpisodeAccountAction
    {
        public class PayerInvoiceList : TTObjectCollection<PayerInvoice> { }
                    
        public class ChildPayerInvoiceCollection : TTObject.TTChildObjectCollection<PayerInvoice>
        {
            public ChildPayerInvoiceCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPayerInvoiceCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class CollectedInvoiceProcDetPreviewReportQuery1_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public PayerInvoicePatientStatusEnum? PATIENTSTATUS
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTSTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICE"].AllPropertyDefs["PATIENTSTATUS"].DataType;
                    return (PayerInvoicePatientStatusEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public CollectedInvoiceProcDetPreviewReportQuery1_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public CollectedInvoiceProcDetPreviewReportQuery1_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected CollectedInvoiceProcDetPreviewReportQuery1_Class() : base() { }
        }

        [Serializable] 

        public partial class CollectedInvoiceProcDetPreviewReportQuery3_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public PayerInvoicePatientStatusEnum? PATIENTSTATUS
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTSTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICE"].AllPropertyDefs["PATIENTSTATUS"].DataType;
                    return (PayerInvoicePatientStatusEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public CollectedInvoiceProcDetPreviewReportQuery3_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public CollectedInvoiceProcDetPreviewReportQuery3_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected CollectedInvoiceProcDetPreviewReportQuery3_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDetailsByPatientID_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
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

            public Guid? Objectid1
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID1"]);
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

            public Guid? Objectid2
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID2"]);
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

            public Guid? Invoiceobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["INVOICEOBJECTID"]);
                }
            }

            public string ExternalCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXTERNALCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEDOCUMENTDETAIL"].AllPropertyDefs["EXTERNALCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetDetailsByPatientID_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDetailsByPatientID_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDetailsByPatientID_Class() : base() { }
        }

        [Serializable] 

        public partial class PayerInvoiceReportInfoQuery_Class : TTReportNqlObject 
        {
            public Object Patientname
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PATIENTNAME"]);
                }
            }

            public long? Patientno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public Guid? Patient
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PATIENT"]);
                }
            }

            public Guid? Payer
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PAYER"]);
                }
            }

            public Guid? Episode
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODE"]);
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

            public long? Payerid
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PAYERID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERDEFINITION"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public long? Payercitycode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PAYERCITYCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CITY"].AllPropertyDefs["CODE"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Payercityname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PAYERCITYNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CITY"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Payeraddress
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PAYERADDRESS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERDEFINITION"].AllPropertyDefs["ADDRESS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Payertaxoffice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PAYERTAXOFFICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERDEFINITION"].AllPropertyDefs["TAXOFFICE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Payertaxnumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PAYERTAXNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERDEFINITION"].AllPropertyDefs["TAXNUMBER"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEDOCUMENT"].AllPropertyDefs["TOTALPRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Currency? GeneralTotalPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GENERALTOTALPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEDOCUMENT"].AllPropertyDefs["GENERALTOTALPRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Currency? TotalDiscountPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOTALDISCOUNTPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEDOCUMENT"].AllPropertyDefs["TOTALDISCOUNTPRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Guid? Episodeobjid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODEOBJID"]);
                }
            }

            public Object Specialitycode
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["SPECIALITYCODE"]);
                }
            }

            public string Evraksayisi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EVRAKSAYISI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["DOCUMENTNUMBER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? Evraktarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EVRAKTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["DOCUMENTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
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

            public Guid? Cashier
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CASHIER"]);
                }
            }

            public PayerInvoiceReportInfoQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public PayerInvoiceReportInfoQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected PayerInvoiceReportInfoQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class PayerInvoiceReportQuery_Class : TTReportNqlObject 
        {
            public string Pricinggroupdescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRICINGGROUPDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEDOCUMENTGROUP"].AllPropertyDefs["GROUPDESCRIPTION"].DataType;
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

            public string Trxexternalcode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TRXEXTERNALCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEDOCUMENTDETAIL"].AllPropertyDefs["EXTERNALCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Trxname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TRXNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEDOCUMENTDETAIL"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public Currency? UnitPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNITPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEDOCUMENTDETAIL"].AllPropertyDefs["UNITPRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Object Amount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["AMOUNT"]);
                }
            }

            public PayerInvoiceReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public PayerInvoiceReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected PayerInvoiceReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class CollectedInvoiceProcDetPreviewReportQuery2_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public PayerInvoicePatientStatusEnum? PATIENTSTATUS
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTSTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICE"].AllPropertyDefs["PATIENTSTATUS"].DataType;
                    return (PayerInvoicePatientStatusEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public CollectedInvoiceProcDetPreviewReportQuery2_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public CollectedInvoiceProcDetPreviewReportQuery2_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected CollectedInvoiceProcDetPreviewReportQuery2_Class() : base() { }
        }

        [Serializable] 

        public partial class CollectedInvoiceProcDetPreviewReportQuery4_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public PayerInvoicePatientStatusEnum? PATIENTSTATUS
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTSTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICE"].AllPropertyDefs["PATIENTSTATUS"].DataType;
                    return (PayerInvoicePatientStatusEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public CollectedInvoiceProcDetPreviewReportQuery4_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public CollectedInvoiceProcDetPreviewReportQuery4_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected CollectedInvoiceProcDetPreviewReportQuery4_Class() : base() { }
        }

        [Serializable] 

        public partial class GetReadyPayerInvoiceForCollectedInvoice_Tooth_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Currency? TotalPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOTALPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICE"].AllPropertyDefs["TOTALPRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Guid? Payer
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PAYER"]);
                }
            }

            public Guid? Episode
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODE"]);
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

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERDEFINITION"].AllPropertyDefs["NAME"].DataType;
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

            public string Name1
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME1"]);
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

            public GetReadyPayerInvoiceForCollectedInvoice_Tooth_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetReadyPayerInvoiceForCollectedInvoice_Tooth_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetReadyPayerInvoiceForCollectedInvoice_Tooth_Class() : base() { }
        }

        [Serializable] 

        public partial class PatientSummaryByDepartmentReportQuery_Class : TTReportNqlObject 
        {
            public Guid? Ressectionobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["RESSECTIONOBJECTID"]);
                }
            }

            public string Ressectionname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESSECTIONNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Subepisodeobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SUBEPISODEOBJECTID"]);
                }
            }

            public SubEpisodeStatusEnum? PatientStatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTSTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].AllPropertyDefs["PATIENTSTATUS"].DataType;
                    return (SubEpisodeStatusEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public Guid? CurrentStateDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENTSTATEDEFID"]);
                }
            }

            public Currency? Totalprice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOTALPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICE"].AllPropertyDefs["GENERALTOTALPRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public PatientSummaryByDepartmentReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public PatientSummaryByDepartmentReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected PatientSummaryByDepartmentReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetReadyPayerInvoiceForCollectedInvoice_SE_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Currency? TotalPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOTALPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICE"].AllPropertyDefs["TOTALPRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Guid? Payer
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PAYER"]);
                }
            }

            public Guid? Episode
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODE"]);
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

            public Guid? PISubEpisode
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PISUBEPISODE"]);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERDEFINITION"].AllPropertyDefs["NAME"].DataType;
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

            public string Name1
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME1"]);
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

            public GetReadyPayerInvoiceForCollectedInvoice_SE_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetReadyPayerInvoiceForCollectedInvoice_SE_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetReadyPayerInvoiceForCollectedInvoice_SE_Class() : base() { }
        }

        [Serializable] 

        public partial class GetReadyPayerInvoiceForCollectedInvoice_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Currency? TotalPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOTALPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICE"].AllPropertyDefs["TOTALPRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Guid? Payer
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PAYER"]);
                }
            }

            public Guid? Episode
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODE"]);
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

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERDEFINITION"].AllPropertyDefs["NAME"].DataType;
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

            public string Name1
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME1"]);
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

            public GetReadyPayerInvoiceForCollectedInvoice_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetReadyPayerInvoiceForCollectedInvoice_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetReadyPayerInvoiceForCollectedInvoice_Class() : base() { }
        }

        [Serializable] 

        public partial class PIReportQuery_Class : TTReportNqlObject 
        {
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

            public long? Actionid
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICE"].AllPropertyDefs["ID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEDOCUMENT"].AllPropertyDefs["DOCUMENTNO"].DataType;
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

            public Currency? Price
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICE"].AllPropertyDefs["GENERALTOTALPRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
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

            public Guid? CurrentStateDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENTSTATEDEFID"]);
                }
            }

            public PIReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public PIReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected PIReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetReadyToCollectedInvoicePatientListReportQuery_Class : TTReportNqlObject 
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

            public DateTime? RequestDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICE"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetReadyToCollectedInvoicePatientListReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetReadyToCollectedInvoicePatientListReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetReadyToCollectedInvoicePatientListReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetInvoicedProcsForItemizedRevenue_Class : TTReportNqlObject 
        {
            public Object Revenue
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["REVENUE"]);
                }
            }

            public Object Procedureprice
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PROCEDUREPRICE"]);
                }
            }

            public Object Packageprice
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PACKAGEPRICE"]);
                }
            }

            public GetInvoicedProcsForItemizedRevenue_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetInvoicedProcsForItemizedRevenue_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetInvoicedProcsForItemizedRevenue_Class() : base() { }
        }

        [Serializable] 

        public partial class GetInvoicedMatsForItemizedRevenue_Class : TTReportNqlObject 
        {
            public Object Drugprice
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["DRUGPRICE"]);
                }
            }

            public Object Materialprice
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["MATERIALPRICE"]);
                }
            }

            public GetInvoicedMatsForItemizedRevenue_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetInvoicedMatsForItemizedRevenue_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetInvoicedMatsForItemizedRevenue_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPayerInvoiceByPayer_Class : TTReportNqlObject 
        {
            public Guid? Payer
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PAYER"]);
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

            public Object Totalprice
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOTALPRICE"]);
                }
            }

            public Object Patientcount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PATIENTCOUNT"]);
                }
            }

            public GetPayerInvoiceByPayer_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPayerInvoiceByPayer_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPayerInvoiceByPayer_Class() : base() { }
        }

        [Serializable] 

        public partial class GetReadyAndColInvByEpisodeAndPISubEpisode_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICE"].AllPropertyDefs["ACTIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICE"].AllPropertyDefs["REASONOFCANCEL"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICE"].AllPropertyDefs["ACTIVE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICE"].AllPropertyDefs["WORKLISTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICE"].AllPropertyDefs["REASONOFREJECT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICE"].AllPropertyDefs["ID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICE"].AllPropertyDefs["OLAPLASTUPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICE"].AllPropertyDefs["OLAPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICE"].AllPropertyDefs["WORKLISTDESCRIPTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICE"].AllPropertyDefs["ISOLDACTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICE"].AllPropertyDefs["REQUESTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICE"].AllPropertyDefs["EMERGENCY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICE"].AllPropertyDefs["PATIENTPAY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICE"].AllPropertyDefs["ORDEROBJECT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICE"].AllPropertyDefs["DESCRIPTIONFORWORKLIST"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICE"].AllPropertyDefs["IGNOREEPISODESTATEONUPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICE"].AllPropertyDefs["ADMISSIONQUEUENUMBER"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public Currency? TotalDiscountPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOTALDISCOUNTPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICE"].AllPropertyDefs["TOTALDISCOUNTPRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICE"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string CashOfficeName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CASHOFFICENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICE"].AllPropertyDefs["CASHOFFICENAME"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public Currency? TotalPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOTALPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICE"].AllPropertyDefs["TOTALPRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public CollectedInvoiceProcedureGroupEnum? PROCEDUREGROUP
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDUREGROUP"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICE"].AllPropertyDefs["PROCEDUREGROUP"].DataType;
                    return (CollectedInvoiceProcedureGroupEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public Currency? TotalDiscountEntry
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOTALDISCOUNTENTRY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICE"].AllPropertyDefs["TOTALDISCOUNTENTRY"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public PayerInvoicePatientStatusEnum? PATIENTSTATUS
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTSTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICE"].AllPropertyDefs["PATIENTSTATUS"].DataType;
                    return (PayerInvoicePatientStatusEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public GetReadyAndColInvByEpisodeAndPISubEpisode_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetReadyAndColInvByEpisodeAndPISubEpisode_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetReadyAndColInvByEpisodeAndPISubEpisode_Class() : base() { }
        }

        [Serializable] 

        public partial class GetReadyAndColInvByEpisode_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICE"].AllPropertyDefs["ACTIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICE"].AllPropertyDefs["REASONOFCANCEL"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICE"].AllPropertyDefs["ACTIVE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICE"].AllPropertyDefs["WORKLISTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICE"].AllPropertyDefs["REASONOFREJECT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICE"].AllPropertyDefs["ID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICE"].AllPropertyDefs["OLAPLASTUPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICE"].AllPropertyDefs["OLAPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICE"].AllPropertyDefs["WORKLISTDESCRIPTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICE"].AllPropertyDefs["ISOLDACTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICE"].AllPropertyDefs["REQUESTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICE"].AllPropertyDefs["EMERGENCY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICE"].AllPropertyDefs["PATIENTPAY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICE"].AllPropertyDefs["ORDEROBJECT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICE"].AllPropertyDefs["DESCRIPTIONFORWORKLIST"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICE"].AllPropertyDefs["IGNOREEPISODESTATEONUPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICE"].AllPropertyDefs["ADMISSIONQUEUENUMBER"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public Currency? TotalDiscountPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOTALDISCOUNTPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICE"].AllPropertyDefs["TOTALDISCOUNTPRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICE"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string CashOfficeName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CASHOFFICENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICE"].AllPropertyDefs["CASHOFFICENAME"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public Currency? TotalPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOTALPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICE"].AllPropertyDefs["TOTALPRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public CollectedInvoiceProcedureGroupEnum? PROCEDUREGROUP
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDUREGROUP"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICE"].AllPropertyDefs["PROCEDUREGROUP"].DataType;
                    return (CollectedInvoiceProcedureGroupEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public Currency? TotalDiscountEntry
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOTALDISCOUNTENTRY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICE"].AllPropertyDefs["TOTALDISCOUNTENTRY"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public PayerInvoicePatientStatusEnum? PATIENTSTATUS
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTSTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICE"].AllPropertyDefs["PATIENTSTATUS"].DataType;
                    return (PayerInvoicePatientStatusEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public GetReadyAndColInvByEpisode_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetReadyAndColInvByEpisode_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetReadyAndColInvByEpisode_Class() : base() { }
        }

        public static class States
        {
            public static Guid New { get { return new Guid("c4351a82-69b0-403a-8211-5b116f894931"); } }
            public static Guid CollectedInvoiced { get { return new Guid("55b4969b-c263-4472-ae0d-5c79b7e6246c"); } }
            public static Guid ReadyToCollectedInvoice { get { return new Guid("8aca14eb-fb0d-470b-8b73-34a82c201958"); } }
    /// <summary>
    /// İptal Edildi
    /// </summary>
            public static Guid Cancelled { get { return new Guid("8cac931b-a2c7-4d83-96a9-897c7312c62e"); } }
            public static Guid Invoiced { get { return new Guid("7ff2efef-c2ad-42ea-bcd4-817dc90e0f8a"); } }
        }

    /// <summary>
    /// Toplu Fatura Hizmet Detay Bilgisi Öndöküm Raporu Sorgusu
    /// </summary>
        public static BindingList<PayerInvoice.CollectedInvoiceProcDetPreviewReportQuery1_Class> CollectedInvoiceProcDetPreviewReportQuery1(IList<string> PARAMRESOURCE, int PARAMRESOURCEFLAG, IList<string> PARAMPAYERINVOICE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICE"].QueryDefs["CollectedInvoiceProcDetPreviewReportQuery1"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMRESOURCE", PARAMRESOURCE);
            paramList.Add("PARAMRESOURCEFLAG", PARAMRESOURCEFLAG);
            paramList.Add("PARAMPAYERINVOICE", PARAMPAYERINVOICE);

            return TTReportNqlObject.QueryObjects<PayerInvoice.CollectedInvoiceProcDetPreviewReportQuery1_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// Toplu Fatura Hizmet Detay Bilgisi Öndöküm Raporu Sorgusu
    /// </summary>
        public static BindingList<PayerInvoice.CollectedInvoiceProcDetPreviewReportQuery1_Class> CollectedInvoiceProcDetPreviewReportQuery1(TTObjectContext objectContext, IList<string> PARAMRESOURCE, int PARAMRESOURCEFLAG, IList<string> PARAMPAYERINVOICE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICE"].QueryDefs["CollectedInvoiceProcDetPreviewReportQuery1"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMRESOURCE", PARAMRESOURCE);
            paramList.Add("PARAMRESOURCEFLAG", PARAMRESOURCEFLAG);
            paramList.Add("PARAMPAYERINVOICE", PARAMPAYERINVOICE);

            return TTReportNqlObject.QueryObjects<PayerInvoice.CollectedInvoiceProcDetPreviewReportQuery1_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Toplu Fatura Hizmet Detay Bilgisi Öndöküm Raporu Sorgusu
    /// </summary>
        public static BindingList<PayerInvoice.CollectedInvoiceProcDetPreviewReportQuery3_Class> CollectedInvoiceProcDetPreviewReportQuery3(int PARAMPROCEDUREGROUP, IList<string> PARAMRESOURCE, int PARAMRESOURCEFLAG, IList<string> PARAMPAYERINVOICE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICE"].QueryDefs["CollectedInvoiceProcDetPreviewReportQuery3"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMPROCEDUREGROUP", PARAMPROCEDUREGROUP);
            paramList.Add("PARAMRESOURCE", PARAMRESOURCE);
            paramList.Add("PARAMRESOURCEFLAG", PARAMRESOURCEFLAG);
            paramList.Add("PARAMPAYERINVOICE", PARAMPAYERINVOICE);

            return TTReportNqlObject.QueryObjects<PayerInvoice.CollectedInvoiceProcDetPreviewReportQuery3_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// Toplu Fatura Hizmet Detay Bilgisi Öndöküm Raporu Sorgusu
    /// </summary>
        public static BindingList<PayerInvoice.CollectedInvoiceProcDetPreviewReportQuery3_Class> CollectedInvoiceProcDetPreviewReportQuery3(TTObjectContext objectContext, int PARAMPROCEDUREGROUP, IList<string> PARAMRESOURCE, int PARAMRESOURCEFLAG, IList<string> PARAMPAYERINVOICE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICE"].QueryDefs["CollectedInvoiceProcDetPreviewReportQuery3"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMPROCEDUREGROUP", PARAMPROCEDUREGROUP);
            paramList.Add("PARAMRESOURCE", PARAMRESOURCE);
            paramList.Add("PARAMRESOURCEFLAG", PARAMRESOURCEFLAG);
            paramList.Add("PARAMPAYERINVOICE", PARAMPAYERINVOICE);

            return TTReportNqlObject.QueryObjects<PayerInvoice.CollectedInvoiceProcDetPreviewReportQuery3_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Filiz istedi bu NQL i, biz biyerde kullanmıyoruz !!!
    /// </summary>
        public static BindingList<PayerInvoice.GetDetailsByPatientID_Class> GetDetailsByPatientID(IList<string> PARAMPATIENTOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICE"].QueryDefs["GetDetailsByPatientID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMPATIENTOBJID", PARAMPATIENTOBJID);

            return TTReportNqlObject.QueryObjects<PayerInvoice.GetDetailsByPatientID_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// Filiz istedi bu NQL i, biz biyerde kullanmıyoruz !!!
    /// </summary>
        public static BindingList<PayerInvoice.GetDetailsByPatientID_Class> GetDetailsByPatientID(TTObjectContext objectContext, IList<string> PARAMPATIENTOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICE"].QueryDefs["GetDetailsByPatientID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMPATIENTOBJID", PARAMPATIENTOBJID);

            return TTReportNqlObject.QueryObjects<PayerInvoice.GetDetailsByPatientID_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PayerInvoice.PayerInvoiceReportInfoQuery_Class> PayerInvoiceReportInfoQuery(string PARAMINVOICEOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICE"].QueryDefs["PayerInvoiceReportInfoQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMINVOICEOBJID", PARAMINVOICEOBJID);

            return TTReportNqlObject.QueryObjects<PayerInvoice.PayerInvoiceReportInfoQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PayerInvoice.PayerInvoiceReportInfoQuery_Class> PayerInvoiceReportInfoQuery(TTObjectContext objectContext, string PARAMINVOICEOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICE"].QueryDefs["PayerInvoiceReportInfoQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMINVOICEOBJID", PARAMINVOICEOBJID);

            return TTReportNqlObject.QueryObjects<PayerInvoice.PayerInvoiceReportInfoQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PayerInvoice.PayerInvoiceReportQuery_Class> PayerInvoiceReportQuery(string PARAMINVOICEOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICE"].QueryDefs["PayerInvoiceReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMINVOICEOBJID", PARAMINVOICEOBJID);

            return TTReportNqlObject.QueryObjects<PayerInvoice.PayerInvoiceReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PayerInvoice.PayerInvoiceReportQuery_Class> PayerInvoiceReportQuery(TTObjectContext objectContext, string PARAMINVOICEOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICE"].QueryDefs["PayerInvoiceReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMINVOICEOBJID", PARAMINVOICEOBJID);

            return TTReportNqlObject.QueryObjects<PayerInvoice.PayerInvoiceReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PayerInvoice> GetReadyPayerInvoiceForCollInvByPG(TTObjectContext objectContext, CollectedInvoiceProcedureGroupEnum PARAMPROCEDUREGROUP, DateTime PARAMSTARTDATE, DateTime PARAMENDDATE, IList<string> PARAMPAYER, IList<int> PARAMPATIENTSTATUS)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICE"].QueryDefs["GetReadyPayerInvoiceForCollInvByPG"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMPROCEDUREGROUP", (int)PARAMPROCEDUREGROUP);
            paramList.Add("PARAMSTARTDATE", PARAMSTARTDATE);
            paramList.Add("PARAMENDDATE", PARAMENDDATE);
            paramList.Add("PARAMPAYER", PARAMPAYER);
            paramList.Add("PARAMPATIENTSTATUS", PARAMPATIENTSTATUS);

            return ((ITTQuery)objectContext).QueryObjects<PayerInvoice>(queryDef, paramList);
        }

        public static BindingList<PayerInvoice> GetReadyPayerInvoiceForCollInvByResourceAndPG(TTObjectContext objectContext, CollectedInvoiceProcedureGroupEnum PARAMPROCEDUREGROUP, DateTime PARAMSTARTDATE, DateTime PARAMENDDATE, IList<string> PARAMPAYER, IList<int> PARAMPATIENTSTATUS, IList<string> PARAMRESOURCE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICE"].QueryDefs["GetReadyPayerInvoiceForCollInvByResourceAndPG"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMPROCEDUREGROUP", (int)PARAMPROCEDUREGROUP);
            paramList.Add("PARAMSTARTDATE", PARAMSTARTDATE);
            paramList.Add("PARAMENDDATE", PARAMENDDATE);
            paramList.Add("PARAMPAYER", PARAMPAYER);
            paramList.Add("PARAMPATIENTSTATUS", PARAMPATIENTSTATUS);
            paramList.Add("PARAMRESOURCE", PARAMRESOURCE);

            return ((ITTQuery)objectContext).QueryObjects<PayerInvoice>(queryDef, paramList);
        }

        public static BindingList<PayerInvoice> GetReadyPayerInvoiceForCollInv(TTObjectContext objectContext, DateTime PARAMSTARTDATE, DateTime PARAMENDDATE, IList<string> PARAMPAYER, IList<int> PARAMPATIENTSTATUS)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICE"].QueryDefs["GetReadyPayerInvoiceForCollInv"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMSTARTDATE", PARAMSTARTDATE);
            paramList.Add("PARAMENDDATE", PARAMENDDATE);
            paramList.Add("PARAMPAYER", PARAMPAYER);
            paramList.Add("PARAMPATIENTSTATUS", PARAMPATIENTSTATUS);

            return ((ITTQuery)objectContext).QueryObjects<PayerInvoice>(queryDef, paramList);
        }

    /// <summary>
    /// Toplu Fatura Hizmet Detay Bilgisi Öndöküm Raporu Sorgusu
    /// </summary>
        public static BindingList<PayerInvoice.CollectedInvoiceProcDetPreviewReportQuery2_Class> CollectedInvoiceProcDetPreviewReportQuery2(IList<string> PARAMRESOURCE, IList<string> PARAMRESOURCE2, IList<string> PARAMPAYERINVOICE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICE"].QueryDefs["CollectedInvoiceProcDetPreviewReportQuery2"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMRESOURCE", PARAMRESOURCE);
            paramList.Add("PARAMRESOURCE2", PARAMRESOURCE2);
            paramList.Add("PARAMPAYERINVOICE", PARAMPAYERINVOICE);

            return TTReportNqlObject.QueryObjects<PayerInvoice.CollectedInvoiceProcDetPreviewReportQuery2_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// Toplu Fatura Hizmet Detay Bilgisi Öndöküm Raporu Sorgusu
    /// </summary>
        public static BindingList<PayerInvoice.CollectedInvoiceProcDetPreviewReportQuery2_Class> CollectedInvoiceProcDetPreviewReportQuery2(TTObjectContext objectContext, IList<string> PARAMRESOURCE, IList<string> PARAMRESOURCE2, IList<string> PARAMPAYERINVOICE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICE"].QueryDefs["CollectedInvoiceProcDetPreviewReportQuery2"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMRESOURCE", PARAMRESOURCE);
            paramList.Add("PARAMRESOURCE2", PARAMRESOURCE2);
            paramList.Add("PARAMPAYERINVOICE", PARAMPAYERINVOICE);

            return TTReportNqlObject.QueryObjects<PayerInvoice.CollectedInvoiceProcDetPreviewReportQuery2_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PayerInvoice> GetReadyPayerInvoiceForCollInvByResource(TTObjectContext objectContext, DateTime PARAMSTARTDATE, DateTime PARAMENDDATE, IList<string> PARAMPAYER, IList<int> PARAMPATIENTSTATUS, IList<string> PARAMRESOURCE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICE"].QueryDefs["GetReadyPayerInvoiceForCollInvByResource"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMSTARTDATE", PARAMSTARTDATE);
            paramList.Add("PARAMENDDATE", PARAMENDDATE);
            paramList.Add("PARAMPAYER", PARAMPAYER);
            paramList.Add("PARAMPATIENTSTATUS", PARAMPATIENTSTATUS);
            paramList.Add("PARAMRESOURCE", PARAMRESOURCE);

            return ((ITTQuery)objectContext).QueryObjects<PayerInvoice>(queryDef, paramList);
        }

        public static BindingList<PayerInvoice> GetByObjectID(TTObjectContext objectContext, string PARAMOBJECTID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICE"].QueryDefs["GetByObjectID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMOBJECTID", PARAMOBJECTID);

            return ((ITTQuery)objectContext).QueryObjects<PayerInvoice>(queryDef, paramList);
        }

    /// <summary>
    /// Toplu Fatura Hizmet Detay Bilgisi Öndöküm Raporu Sorgusu
    /// </summary>
        public static BindingList<PayerInvoice.CollectedInvoiceProcDetPreviewReportQuery4_Class> CollectedInvoiceProcDetPreviewReportQuery4(int PARAMPROCEDUREGROUP, IList<string> PARAMRESOURCE, IList<string> PARAMRESOURCE2, IList<string> PARAMPAYERINVOICE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICE"].QueryDefs["CollectedInvoiceProcDetPreviewReportQuery4"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMPROCEDUREGROUP", PARAMPROCEDUREGROUP);
            paramList.Add("PARAMRESOURCE", PARAMRESOURCE);
            paramList.Add("PARAMRESOURCE2", PARAMRESOURCE2);
            paramList.Add("PARAMPAYERINVOICE", PARAMPAYERINVOICE);

            return TTReportNqlObject.QueryObjects<PayerInvoice.CollectedInvoiceProcDetPreviewReportQuery4_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// Toplu Fatura Hizmet Detay Bilgisi Öndöküm Raporu Sorgusu
    /// </summary>
        public static BindingList<PayerInvoice.CollectedInvoiceProcDetPreviewReportQuery4_Class> CollectedInvoiceProcDetPreviewReportQuery4(TTObjectContext objectContext, int PARAMPROCEDUREGROUP, IList<string> PARAMRESOURCE, IList<string> PARAMRESOURCE2, IList<string> PARAMPAYERINVOICE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICE"].QueryDefs["CollectedInvoiceProcDetPreviewReportQuery4"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMPROCEDUREGROUP", PARAMPROCEDUREGROUP);
            paramList.Add("PARAMRESOURCE", PARAMRESOURCE);
            paramList.Add("PARAMRESOURCE2", PARAMRESOURCE2);
            paramList.Add("PARAMPAYERINVOICE", PARAMPAYERINVOICE);

            return TTReportNqlObject.QueryObjects<PayerInvoice.CollectedInvoiceProcDetPreviewReportQuery4_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PayerInvoice> GetCollectedInvoicedByEpisodeAndPG(TTObjectContext objectContext, string EPISODE, CollectedInvoiceProcedureGroupEnum PROCEDUREGROUP)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICE"].QueryDefs["GetCollectedInvoicedByEpisodeAndPG"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);
            paramList.Add("PROCEDUREGROUP", (int)PROCEDUREGROUP);

            return ((ITTQuery)objectContext).QueryObjects<PayerInvoice>(queryDef, paramList);
        }

        public static BindingList<PayerInvoice.GetReadyPayerInvoiceForCollectedInvoice_Tooth_Class> GetReadyPayerInvoiceForCollectedInvoice_Tooth(DateTime STARTDATE, DateTime ENDDATE, IList<string> PAYER, IList<int> PATIENTSTATUS, IList<string> RESOURCE, int RESOURCEFLAG, CollectedInvoiceProcedureGroupEnum PROCEDUREGROUP, int PROCEDUREGROUPFLAG, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICE"].QueryDefs["GetReadyPayerInvoiceForCollectedInvoice_Tooth"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("PAYER", PAYER);
            paramList.Add("PATIENTSTATUS", PATIENTSTATUS);
            paramList.Add("RESOURCE", RESOURCE);
            paramList.Add("RESOURCEFLAG", RESOURCEFLAG);
            paramList.Add("PROCEDUREGROUP", (int)PROCEDUREGROUP);
            paramList.Add("PROCEDUREGROUPFLAG", PROCEDUREGROUPFLAG);

            return TTReportNqlObject.QueryObjects<PayerInvoice.GetReadyPayerInvoiceForCollectedInvoice_Tooth_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PayerInvoice.GetReadyPayerInvoiceForCollectedInvoice_Tooth_Class> GetReadyPayerInvoiceForCollectedInvoice_Tooth(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, IList<string> PAYER, IList<int> PATIENTSTATUS, IList<string> RESOURCE, int RESOURCEFLAG, CollectedInvoiceProcedureGroupEnum PROCEDUREGROUP, int PROCEDUREGROUPFLAG, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICE"].QueryDefs["GetReadyPayerInvoiceForCollectedInvoice_Tooth"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("PAYER", PAYER);
            paramList.Add("PATIENTSTATUS", PATIENTSTATUS);
            paramList.Add("RESOURCE", RESOURCE);
            paramList.Add("RESOURCEFLAG", RESOURCEFLAG);
            paramList.Add("PROCEDUREGROUP", (int)PROCEDUREGROUP);
            paramList.Add("PROCEDUREGROUPFLAG", PROCEDUREGROUPFLAG);

            return TTReportNqlObject.QueryObjects<PayerInvoice.GetReadyPayerInvoiceForCollectedInvoice_Tooth_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PayerInvoice> GetCollectedInvoicedByPISubEpisode(TTObjectContext objectContext, string PISUBEPISODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICE"].QueryDefs["GetCollectedInvoicedByPISubEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PISUBEPISODE", PISUBEPISODE);

            return ((ITTQuery)objectContext).QueryObjects<PayerInvoice>(queryDef, paramList);
        }

        public static BindingList<PayerInvoice.PatientSummaryByDepartmentReportQuery_Class> PatientSummaryByDepartmentReportQuery(DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICE"].QueryDefs["PatientSummaryByDepartmentReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<PayerInvoice.PatientSummaryByDepartmentReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PayerInvoice.PatientSummaryByDepartmentReportQuery_Class> PatientSummaryByDepartmentReportQuery(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICE"].QueryDefs["PatientSummaryByDepartmentReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<PayerInvoice.PatientSummaryByDepartmentReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PayerInvoice.GetReadyPayerInvoiceForCollectedInvoice_SE_Class> GetReadyPayerInvoiceForCollectedInvoice_SE(DateTime STARTDATE, DateTime ENDDATE, IList<string> PAYER, IList<int> PATIENTSTATUS, IList<string> RESOURCE, int RESOURCEFLAG, CollectedInvoiceProcedureGroupEnum PROCEDUREGROUP, int PROCEDUREGROUPFLAG, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICE"].QueryDefs["GetReadyPayerInvoiceForCollectedInvoice_SE"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("PAYER", PAYER);
            paramList.Add("PATIENTSTATUS", PATIENTSTATUS);
            paramList.Add("RESOURCE", RESOURCE);
            paramList.Add("RESOURCEFLAG", RESOURCEFLAG);
            paramList.Add("PROCEDUREGROUP", (int)PROCEDUREGROUP);
            paramList.Add("PROCEDUREGROUPFLAG", PROCEDUREGROUPFLAG);

            return TTReportNqlObject.QueryObjects<PayerInvoice.GetReadyPayerInvoiceForCollectedInvoice_SE_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PayerInvoice.GetReadyPayerInvoiceForCollectedInvoice_SE_Class> GetReadyPayerInvoiceForCollectedInvoice_SE(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, IList<string> PAYER, IList<int> PATIENTSTATUS, IList<string> RESOURCE, int RESOURCEFLAG, CollectedInvoiceProcedureGroupEnum PROCEDUREGROUP, int PROCEDUREGROUPFLAG, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICE"].QueryDefs["GetReadyPayerInvoiceForCollectedInvoice_SE"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("PAYER", PAYER);
            paramList.Add("PATIENTSTATUS", PATIENTSTATUS);
            paramList.Add("RESOURCE", RESOURCE);
            paramList.Add("RESOURCEFLAG", RESOURCEFLAG);
            paramList.Add("PROCEDUREGROUP", (int)PROCEDUREGROUP);
            paramList.Add("PROCEDUREGROUPFLAG", PROCEDUREGROUPFLAG);

            return TTReportNqlObject.QueryObjects<PayerInvoice.GetReadyPayerInvoiceForCollectedInvoice_SE_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PayerInvoice> GetReadyPayerInvoiceForCollInv_SE(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, IList<string> PAYER, IList<int> PATIENTSTATUS, IList<string> RESOURCE, int RESOURCEFLAG, CollectedInvoiceProcedureGroupEnum PROCEDUREGROUP, int PROCEDUREGROUPFLAG)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICE"].QueryDefs["GetReadyPayerInvoiceForCollInv_SE"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("PAYER", PAYER);
            paramList.Add("PATIENTSTATUS", PATIENTSTATUS);
            paramList.Add("RESOURCE", RESOURCE);
            paramList.Add("RESOURCEFLAG", RESOURCEFLAG);
            paramList.Add("PROCEDUREGROUP", (int)PROCEDUREGROUP);
            paramList.Add("PROCEDUREGROUPFLAG", PROCEDUREGROUPFLAG);

            return ((ITTQuery)objectContext).QueryObjects<PayerInvoice>(queryDef, paramList);
        }

        public static BindingList<PayerInvoice.GetReadyPayerInvoiceForCollectedInvoice_Class> GetReadyPayerInvoiceForCollectedInvoice(DateTime STARTDATE, DateTime ENDDATE, IList<string> PAYER, IList<int> PATIENTSTATUS, IList<string> RESOURCE, int RESOURCEFLAG, CollectedInvoiceProcedureGroupEnum PROCEDUREGROUP, int PROCEDUREGROUPFLAG, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICE"].QueryDefs["GetReadyPayerInvoiceForCollectedInvoice"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("PAYER", PAYER);
            paramList.Add("PATIENTSTATUS", PATIENTSTATUS);
            paramList.Add("RESOURCE", RESOURCE);
            paramList.Add("RESOURCEFLAG", RESOURCEFLAG);
            paramList.Add("PROCEDUREGROUP", (int)PROCEDUREGROUP);
            paramList.Add("PROCEDUREGROUPFLAG", PROCEDUREGROUPFLAG);

            return TTReportNqlObject.QueryObjects<PayerInvoice.GetReadyPayerInvoiceForCollectedInvoice_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PayerInvoice.GetReadyPayerInvoiceForCollectedInvoice_Class> GetReadyPayerInvoiceForCollectedInvoice(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, IList<string> PAYER, IList<int> PATIENTSTATUS, IList<string> RESOURCE, int RESOURCEFLAG, CollectedInvoiceProcedureGroupEnum PROCEDUREGROUP, int PROCEDUREGROUPFLAG, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICE"].QueryDefs["GetReadyPayerInvoiceForCollectedInvoice"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("PAYER", PAYER);
            paramList.Add("PATIENTSTATUS", PATIENTSTATUS);
            paramList.Add("RESOURCE", RESOURCE);
            paramList.Add("RESOURCEFLAG", RESOURCEFLAG);
            paramList.Add("PROCEDUREGROUP", (int)PROCEDUREGROUP);
            paramList.Add("PROCEDUREGROUPFLAG", PROCEDUREGROUPFLAG);

            return TTReportNqlObject.QueryObjects<PayerInvoice.GetReadyPayerInvoiceForCollectedInvoice_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PayerInvoice.PIReportQuery_Class> PIReportQuery(DateTime STARTDATE, DateTime ENDDATE, IList<string> PAYER, int PAYERFLAG, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICE"].QueryDefs["PIReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("PAYER", PAYER);
            paramList.Add("PAYERFLAG", PAYERFLAG);

            return TTReportNqlObject.QueryObjects<PayerInvoice.PIReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PayerInvoice.PIReportQuery_Class> PIReportQuery(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, IList<string> PAYER, int PAYERFLAG, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICE"].QueryDefs["PIReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("PAYER", PAYER);
            paramList.Add("PAYERFLAG", PAYERFLAG);

            return TTReportNqlObject.QueryObjects<PayerInvoice.PIReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PayerInvoice.GetReadyToCollectedInvoicePatientListReportQuery_Class> GetReadyToCollectedInvoicePatientListReportQuery(DateTime STARTDATE, DateTime ENDDATE, int PATIENTSTATUS1, int PATIENTSTATUS2, int PATIENTSTATUS3, int PAYERFLAG, IList<string> PAYER, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICE"].QueryDefs["GetReadyToCollectedInvoicePatientListReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("PATIENTSTATUS1", PATIENTSTATUS1);
            paramList.Add("PATIENTSTATUS2", PATIENTSTATUS2);
            paramList.Add("PATIENTSTATUS3", PATIENTSTATUS3);
            paramList.Add("PAYERFLAG", PAYERFLAG);
            paramList.Add("PAYER", PAYER);

            return TTReportNqlObject.QueryObjects<PayerInvoice.GetReadyToCollectedInvoicePatientListReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PayerInvoice.GetReadyToCollectedInvoicePatientListReportQuery_Class> GetReadyToCollectedInvoicePatientListReportQuery(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, int PATIENTSTATUS1, int PATIENTSTATUS2, int PATIENTSTATUS3, int PAYERFLAG, IList<string> PAYER, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICE"].QueryDefs["GetReadyToCollectedInvoicePatientListReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("PATIENTSTATUS1", PATIENTSTATUS1);
            paramList.Add("PATIENTSTATUS2", PATIENTSTATUS2);
            paramList.Add("PATIENTSTATUS3", PATIENTSTATUS3);
            paramList.Add("PAYERFLAG", PAYERFLAG);
            paramList.Add("PAYER", PAYER);

            return TTReportNqlObject.QueryObjects<PayerInvoice.GetReadyToCollectedInvoicePatientListReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PayerInvoice.GetInvoicedProcsForItemizedRevenue_Class> GetInvoicedProcsForItemizedRevenue(DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICE"].QueryDefs["GetInvoicedProcsForItemizedRevenue"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<PayerInvoice.GetInvoicedProcsForItemizedRevenue_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PayerInvoice.GetInvoicedProcsForItemizedRevenue_Class> GetInvoicedProcsForItemizedRevenue(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICE"].QueryDefs["GetInvoicedProcsForItemizedRevenue"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<PayerInvoice.GetInvoicedProcsForItemizedRevenue_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PayerInvoice> GetReadyAndCollectedInvoicedByPISubEpisode(TTObjectContext objectContext, string PISUBEPISODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICE"].QueryDefs["GetReadyAndCollectedInvoicedByPISubEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PISUBEPISODE", PISUBEPISODE);

            return ((ITTQuery)objectContext).QueryObjects<PayerInvoice>(queryDef, paramList);
        }

        public static BindingList<PayerInvoice.GetInvoicedMatsForItemizedRevenue_Class> GetInvoicedMatsForItemizedRevenue(DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICE"].QueryDefs["GetInvoicedMatsForItemizedRevenue"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<PayerInvoice.GetInvoicedMatsForItemizedRevenue_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PayerInvoice.GetInvoicedMatsForItemizedRevenue_Class> GetInvoicedMatsForItemizedRevenue(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICE"].QueryDefs["GetInvoicedMatsForItemizedRevenue"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<PayerInvoice.GetInvoicedMatsForItemizedRevenue_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PayerInvoice.GetPayerInvoiceByPayer_Class> GetPayerInvoiceByPayer(DateTime STARTDATE, DateTime ENDDATE, IList<string> PAYER, int PAYERFLAG, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICE"].QueryDefs["GetPayerInvoiceByPayer"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("PAYER", PAYER);
            paramList.Add("PAYERFLAG", PAYERFLAG);

            return TTReportNqlObject.QueryObjects<PayerInvoice.GetPayerInvoiceByPayer_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PayerInvoice.GetPayerInvoiceByPayer_Class> GetPayerInvoiceByPayer(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, IList<string> PAYER, int PAYERFLAG, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICE"].QueryDefs["GetPayerInvoiceByPayer"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("PAYER", PAYER);
            paramList.Add("PAYERFLAG", PAYERFLAG);

            return TTReportNqlObject.QueryObjects<PayerInvoice.GetPayerInvoiceByPayer_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PayerInvoice.GetReadyAndColInvByEpisodeAndPISubEpisode_Class> GetReadyAndColInvByEpisodeAndPISubEpisode(string EPISODE, string PISUBEPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICE"].QueryDefs["GetReadyAndColInvByEpisodeAndPISubEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);
            paramList.Add("PISUBEPISODE", PISUBEPISODE);

            return TTReportNqlObject.QueryObjects<PayerInvoice.GetReadyAndColInvByEpisodeAndPISubEpisode_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PayerInvoice.GetReadyAndColInvByEpisodeAndPISubEpisode_Class> GetReadyAndColInvByEpisodeAndPISubEpisode(TTObjectContext objectContext, string EPISODE, string PISUBEPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICE"].QueryDefs["GetReadyAndColInvByEpisodeAndPISubEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);
            paramList.Add("PISUBEPISODE", PISUBEPISODE);

            return TTReportNqlObject.QueryObjects<PayerInvoice.GetReadyAndColInvByEpisodeAndPISubEpisode_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PayerInvoice.GetReadyAndColInvByEpisode_Class> GetReadyAndColInvByEpisode(string EPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICE"].QueryDefs["GetReadyAndColInvByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<PayerInvoice.GetReadyAndColInvByEpisode_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PayerInvoice.GetReadyAndColInvByEpisode_Class> GetReadyAndColInvByEpisode(TTObjectContext objectContext, string EPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICE"].QueryDefs["GetReadyAndColInvByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<PayerInvoice.GetReadyAndColInvByEpisode_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Hizmet Grubu
    /// </summary>
        public CollectedInvoiceProcedureGroupEnum? PROCEDUREGROUP
        {
            get { return (CollectedInvoiceProcedureGroupEnum?)(int?)this["PROCEDUREGROUP"]; }
            set { this["PROCEDUREGROUP"] = value; }
        }

    /// <summary>
    /// İndirilecek Tutar
    /// </summary>
        public Currency? TotalDiscountEntry
        {
            get { return (Currency?)this["TOTALDISCOUNTENTRY"]; }
            set { this["TOTALDISCOUNTENTRY"] = value; }
        }

    /// <summary>
    /// Hasta Durumu
    /// </summary>
        public PayerInvoicePatientStatusEnum? PATIENTSTATUS
        {
            get { return (PayerInvoicePatientStatusEnum?)(int?)this["PATIENTSTATUS"]; }
            set { this["PATIENTSTATUS"] = value; }
        }

    /// <summary>
    /// İndirim Tipi Tanımlarıyla İlişki
    /// </summary>
        public DiscountTypeDefinition DiscountTypeDefinition
        {
            get { return (DiscountTypeDefinition)((ITTObject)this).GetParent("DISCOUNTTYPEDEFINITION"); }
            set { this["DISCOUNTTYPEDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Kurum Faturasıyla İlişki
    /// </summary>
        public PayerInvoiceDocument PayerInvoiceDocument
        {
            get { return (PayerInvoiceDocument)((ITTObject)this).GetParent("PAYERINVOICEDOCUMENT"); }
            set { this["PAYERINVOICEDOCUMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Anlaşmalarla İlişki
    /// </summary>
        public ProtocolDefinition Protocol
        {
            get { return (ProtocolDefinition)((ITTObject)this).GetParent("PROTOCOL"); }
            set { this["PROTOCOL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Kurumla İlişki
    /// </summary>
        public PayerDefinition Payer
        {
            get { return (PayerDefinition)((ITTObject)this).GetParent("PAYER"); }
            set { this["PAYER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Alt Epizot la ilişki
    /// </summary>
        public SubEpisode PISubEpisode
        {
            get { return (SubEpisode)((ITTObject)this).GetParent("PISUBEPISODE"); }
            set { this["PISUBEPISODE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// İptal Nedeni İlişkisi
    /// </summary>
        public PayerInvoiceCancelReasonDefinition CancelReason
        {
            get { return (PayerInvoiceCancelReasonDefinition)((ITTObject)this).GetParent("CANCELREASON"); }
            set { this["CANCELREASON"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreatePayerInvoiceProceduresCollection()
        {
            _PayerInvoiceProcedures = new PayerInvoiceProcedure.ChildPayerInvoiceProcedureCollection(this, new Guid("96302e75-a58a-405e-9247-93cc8a5ad439"));
            ((ITTChildObjectCollection)_PayerInvoiceProcedures).GetChildren();
        }

        protected PayerInvoiceProcedure.ChildPayerInvoiceProcedureCollection _PayerInvoiceProcedures = null;
    /// <summary>
    /// Child collection for Kurum Faturası İşlemiyle İlişki
    /// </summary>
        public PayerInvoiceProcedure.ChildPayerInvoiceProcedureCollection PayerInvoiceProcedures
        {
            get
            {
                if (_PayerInvoiceProcedures == null)
                    CreatePayerInvoiceProceduresCollection();
                return _PayerInvoiceProcedures;
            }
        }

        virtual protected void CreateEpisodeProtocolsCollection()
        {
            _EpisodeProtocols = new EpisodeProtocol.ChildEpisodeProtocolCollection(this, new Guid("ca763c96-6b91-4a9d-ac63-a375f36f3af5"));
            ((ITTChildObjectCollection)_EpisodeProtocols).GetChildren();
        }

        protected EpisodeProtocol.ChildEpisodeProtocolCollection _EpisodeProtocols = null;
    /// <summary>
    /// Child collection for Kurum Faturası işlemine ilişki
    /// </summary>
        public EpisodeProtocol.ChildEpisodeProtocolCollection EpisodeProtocols
        {
            get
            {
                if (_EpisodeProtocols == null)
                    CreateEpisodeProtocolsCollection();
                return _EpisodeProtocols;
            }
        }

        override protected void CreateAccountDocumentsCollection()
        {
            _AccountDocuments = new AccountDocument.ChildAccountDocumentCollection(this, new Guid("a67b1df8-d16d-4c2e-b85e-7fe84ebb3623"));
            ((ITTChildObjectCollection)_AccountDocuments).GetChildren();
        }

        virtual protected void CreatePayerInvoiceMaterialsCollection()
        {
            _PayerInvoiceMaterials = new PayerInvoiceMaterial.ChildPayerInvoiceMaterialCollection(this, new Guid("fe052b70-4adf-4017-9841-86cceb98f8d3"));
            ((ITTChildObjectCollection)_PayerInvoiceMaterials).GetChildren();
        }

        protected PayerInvoiceMaterial.ChildPayerInvoiceMaterialCollection _PayerInvoiceMaterials = null;
    /// <summary>
    /// Child collection for Kurum Faturası İşlemiyle İlişki
    /// </summary>
        public PayerInvoiceMaterial.ChildPayerInvoiceMaterialCollection PayerInvoiceMaterials
        {
            get
            {
                if (_PayerInvoiceMaterials == null)
                    CreatePayerInvoiceMaterialsCollection();
                return _PayerInvoiceMaterials;
            }
        }

        virtual protected void CreateCollectedPatientListCollection()
        {
            _CollectedPatientList = new CollectedPatientList.ChildCollectedPatientListCollection(this, new Guid("439f0334-a8f6-4cc5-ab4b-f13bcf7c9be0"));
            ((ITTChildObjectCollection)_CollectedPatientList).GetChildren();
        }

        protected CollectedPatientList.ChildCollectedPatientListCollection _CollectedPatientList = null;
    /// <summary>
    /// Child collection for Kurum Faturası İşlemiyle İlişki
    /// </summary>
        public CollectedPatientList.ChildCollectedPatientListCollection CollectedPatientList
        {
            get
            {
                if (_CollectedPatientList == null)
                    CreateCollectedPatientListCollection();
                return _CollectedPatientList;
            }
        }

        virtual protected void CreatePayerInvoicePackagesCollection()
        {
            _PayerInvoicePackages = new PayerInvoicePackage.ChildPayerInvoicePackageCollection(this, new Guid("6808ac1b-6448-467c-8e9e-e48ed259849f"));
            ((ITTChildObjectCollection)_PayerInvoicePackages).GetChildren();
        }

        protected PayerInvoicePackage.ChildPayerInvoicePackageCollection _PayerInvoicePackages = null;
    /// <summary>
    /// Child collection for Kurum Faturası İşlemiyle İlişki
    /// </summary>
        public PayerInvoicePackage.ChildPayerInvoicePackageCollection PayerInvoicePackages
        {
            get
            {
                if (_PayerInvoicePackages == null)
                    CreatePayerInvoicePackagesCollection();
                return _PayerInvoicePackages;
            }
        }

        protected PayerInvoice(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PayerInvoice(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PayerInvoice(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PayerInvoice(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PayerInvoice(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PAYERINVOICE", dataRow) { }
        protected PayerInvoice(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PAYERINVOICE", dataRow, isImported) { }
        public PayerInvoice(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PayerInvoice(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PayerInvoice() : base() { }

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
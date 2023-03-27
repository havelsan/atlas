
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="CollectedInvoice")] 

    /// <summary>
    /// Toplu Fatura İşlemi
    /// </summary>
    public  partial class CollectedInvoice : AccountAction, IWorkListBaseAction
    {
        public class CollectedInvoiceList : TTObjectCollection<CollectedInvoice> { }
                    
        public class ChildCollectedInvoiceCollection : TTObject.TTChildObjectCollection<CollectedInvoice>
        {
            public ChildCollectedInvoiceCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildCollectedInvoiceCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class CollectedInvoiceProcedureDetailReportQuery_Class : TTReportNqlObject 
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

            public Currency? Totalpricebypatient
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOTALPRICEBYPATIENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COLLECTEDPATIENTLIST"].AllPropertyDefs["TOTALPRICE"].DataType;
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

            public CollectedInvoiceProcedureDetailReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public CollectedInvoiceProcedureDetailReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected CollectedInvoiceProcedureDetailReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class CollectedInvoicePreReportQuery_Class : TTReportNqlObject 
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

            public Object Episodecount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["EPISODECOUNT"]);
                }
            }

            public Object Totalprice
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOTALPRICE"]);
                }
            }

            public CollectedInvoicePreReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public CollectedInvoicePreReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected CollectedInvoicePreReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class CollectedInvoiceReportQuery_Class : TTReportNqlObject 
        {
            public DateTime? STARTDATE
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STARTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COLLECTEDINVOICE"].AllPropertyDefs["STARTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ENDDATE
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ENDDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COLLECTEDINVOICE"].AllPropertyDefs["ENDDATE"].DataType;
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

            public Guid? Payerobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PAYEROBJECTID"]);
                }
            }

            public Currency? TotalPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOTALPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COLLECTEDINVOICE"].AllPropertyDefs["TOTALPRICE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COLLECTEDINVOICE"].AllPropertyDefs["PROCEDUREGROUP"].DataType;
                    return (CollectedInvoiceProcedureGroupEnum?)(int)dataType.ConvertValue(val);
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

            public Guid? Cashier
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CASHIER"]);
                }
            }

            public double? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTDOCUMENTDETAIL"].AllPropertyDefs["AMOUNT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTDOCUMENTDETAIL"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Episodecount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["EPISODECOUNT"]);
                }
            }

            public CollectedInvoiceReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public CollectedInvoiceReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected CollectedInvoiceReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class CITotalPriceByDate_Class : TTReportNqlObject 
        {
            public Object Totalprice
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOTALPRICE"]);
                }
            }

            public CITotalPriceByDate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public CITotalPriceByDate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected CITotalPriceByDate_Class() : base() { }
        }

        [Serializable] 

        public partial class CICountByDate_Class : TTReportNqlObject 
        {
            public Object Invoicecount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["INVOICECOUNT"]);
                }
            }

            public CICountByDate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public CICountByDate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected CICountByDate_Class() : base() { }
        }

        [Serializable] 

        public partial class CollectedInvoiceListReportQuery_Class : TTReportNqlObject 
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

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTDOCUMENTDETAIL"].AllPropertyDefs["DESCRIPTION"].DataType;
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

            public Object Patientname
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PATIENTNAME"]);
                }
            }

            public Object Healtslipnumber
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["HEALTSLIPNUMBER"]);
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

            public Object Homephone
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["HOMEPHONE"]);
                }
            }

            public Currency? TotalPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOTALPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COLLECTEDPATIENTLIST"].AllPropertyDefs["TOTALPRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public CollectedInvoiceListReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public CollectedInvoiceListReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected CollectedInvoiceListReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class CIBranchCountByDate_Class : TTReportNqlObject 
        {
            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SPECIALITYDEFINITION"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SPECIALITYDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public CIBranchCountByDate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public CIBranchCountByDate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected CIBranchCountByDate_Class() : base() { }
        }

        [Serializable] 

        public partial class CIPatientListByDate_Class : TTReportNqlObject 
        {
            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COLLECTEDINVOICE"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
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

            public Object Patientname
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PATIENTNAME"]);
                }
            }

            public long? Patientuniquerefno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTUNIQUEREFNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["UNIQUEREFNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COLLECTEDINVOICEDOCUMENT"].AllPropertyDefs["DOCUMENTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COLLECTEDINVOICEDOCUMENT"].AllPropertyDefs["DOCUMENTNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COLLECTEDPATIENTLIST"].AllPropertyDefs["TOTALPRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
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

            public Guid? Episodeobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODEOBJECTID"]);
                }
            }

            public Guid? Patientadmission
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PATIENTADMISSION"]);
                }
            }

            public CIPatientListByDate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public CIPatientListByDate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected CIPatientListByDate_Class() : base() { }
        }

        [Serializable] 

        public partial class CIEpisodeCountByDate_Class : TTReportNqlObject 
        {
            public Object Episodecount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["EPISODECOUNT"]);
                }
            }

            public CIEpisodeCountByDate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public CIEpisodeCountByDate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected CIEpisodeCountByDate_Class() : base() { }
        }

        [Serializable] 

        public partial class CIReportQuery_Class : TTReportNqlObject 
        {
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

            public Currency? TotalPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOTALPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COLLECTEDINVOICE"].AllPropertyDefs["TOTALPRICE"].DataType;
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

            public CollectedInvoiceProcedureGroupEnum? PROCEDUREGROUP
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDUREGROUP"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COLLECTEDINVOICE"].AllPropertyDefs["PROCEDUREGROUP"].DataType;
                    return (CollectedInvoiceProcedureGroupEnum?)(int)dataType.ConvertValue(val);
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

            public Guid? CurrentStateDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENTSTATEDEFID"]);
                }
            }

            public Object Patientcount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PATIENTCOUNT"]);
                }
            }

            public CIReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public CIReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected CIReportQuery_Class() : base() { }
        }

        public static class States
        {
            public static Guid CollectedInvoiced { get { return new Guid("fbad677c-716a-4ea6-b1a5-06468cbd80ea"); } }
    /// <summary>
    /// İptal edildi
    /// </summary>
            public static Guid Cancelled { get { return new Guid("fe582ca6-0ba3-49f4-bc65-089ab9a29cac"); } }
            public static Guid New { get { return new Guid("6bb054b3-dcd9-42a2-be8d-52b0499541c1"); } }
        }

        public static BindingList<CollectedInvoice.CollectedInvoiceProcedureDetailReportQuery_Class> CollectedInvoiceProcedureDetailReportQuery(string PARAMCOLLINVOICEOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COLLECTEDINVOICE"].QueryDefs["CollectedInvoiceProcedureDetailReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMCOLLINVOICEOBJID", PARAMCOLLINVOICEOBJID);

            return TTReportNqlObject.QueryObjects<CollectedInvoice.CollectedInvoiceProcedureDetailReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<CollectedInvoice.CollectedInvoiceProcedureDetailReportQuery_Class> CollectedInvoiceProcedureDetailReportQuery(TTObjectContext objectContext, string PARAMCOLLINVOICEOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COLLECTEDINVOICE"].QueryDefs["CollectedInvoiceProcedureDetailReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMCOLLINVOICEOBJID", PARAMCOLLINVOICEOBJID);

            return TTReportNqlObject.QueryObjects<CollectedInvoice.CollectedInvoiceProcedureDetailReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<CollectedInvoice.CollectedInvoicePreReportQuery_Class> CollectedInvoicePreReportQuery(string PARAMCOLLINVOICEOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COLLECTEDINVOICE"].QueryDefs["CollectedInvoicePreReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMCOLLINVOICEOBJID", PARAMCOLLINVOICEOBJID);

            return TTReportNqlObject.QueryObjects<CollectedInvoice.CollectedInvoicePreReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<CollectedInvoice.CollectedInvoicePreReportQuery_Class> CollectedInvoicePreReportQuery(TTObjectContext objectContext, string PARAMCOLLINVOICEOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COLLECTEDINVOICE"].QueryDefs["CollectedInvoicePreReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMCOLLINVOICEOBJID", PARAMCOLLINVOICEOBJID);

            return TTReportNqlObject.QueryObjects<CollectedInvoice.CollectedInvoicePreReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<CollectedInvoice.CollectedInvoiceReportQuery_Class> CollectedInvoiceReportQuery(string PARAMCOLLINVOICEOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COLLECTEDINVOICE"].QueryDefs["CollectedInvoiceReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMCOLLINVOICEOBJID", PARAMCOLLINVOICEOBJID);

            return TTReportNqlObject.QueryObjects<CollectedInvoice.CollectedInvoiceReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<CollectedInvoice.CollectedInvoiceReportQuery_Class> CollectedInvoiceReportQuery(TTObjectContext objectContext, string PARAMCOLLINVOICEOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COLLECTEDINVOICE"].QueryDefs["CollectedInvoiceReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMCOLLINVOICEOBJID", PARAMCOLLINVOICEOBJID);

            return TTReportNqlObject.QueryObjects<CollectedInvoice.CollectedInvoiceReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<CollectedInvoice.CITotalPriceByDate_Class> CITotalPriceByDate(DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COLLECTEDINVOICE"].QueryDefs["CITotalPriceByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<CollectedInvoice.CITotalPriceByDate_Class>(queryDef, paramList, pi);
        }

        public static BindingList<CollectedInvoice.CITotalPriceByDate_Class> CITotalPriceByDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COLLECTEDINVOICE"].QueryDefs["CITotalPriceByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<CollectedInvoice.CITotalPriceByDate_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<CollectedInvoice.CICountByDate_Class> CICountByDate(DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COLLECTEDINVOICE"].QueryDefs["CICountByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<CollectedInvoice.CICountByDate_Class>(queryDef, paramList, pi);
        }

        public static BindingList<CollectedInvoice.CICountByDate_Class> CICountByDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COLLECTEDINVOICE"].QueryDefs["CICountByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<CollectedInvoice.CICountByDate_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<CollectedInvoice.CollectedInvoiceListReportQuery_Class> CollectedInvoiceListReportQuery(string PARAMCOLLINVOICEOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COLLECTEDINVOICE"].QueryDefs["CollectedInvoiceListReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMCOLLINVOICEOBJID", PARAMCOLLINVOICEOBJID);

            return TTReportNqlObject.QueryObjects<CollectedInvoice.CollectedInvoiceListReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<CollectedInvoice.CollectedInvoiceListReportQuery_Class> CollectedInvoiceListReportQuery(TTObjectContext objectContext, string PARAMCOLLINVOICEOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COLLECTEDINVOICE"].QueryDefs["CollectedInvoiceListReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMCOLLINVOICEOBJID", PARAMCOLLINVOICEOBJID);

            return TTReportNqlObject.QueryObjects<CollectedInvoice.CollectedInvoiceListReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<CollectedInvoice.CIBranchCountByDate_Class> CIBranchCountByDate(DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COLLECTEDINVOICE"].QueryDefs["CIBranchCountByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<CollectedInvoice.CIBranchCountByDate_Class>(queryDef, paramList, pi);
        }

        public static BindingList<CollectedInvoice.CIBranchCountByDate_Class> CIBranchCountByDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COLLECTEDINVOICE"].QueryDefs["CIBranchCountByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<CollectedInvoice.CIBranchCountByDate_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<CollectedInvoice.CIPatientListByDate_Class> CIPatientListByDate(DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COLLECTEDINVOICE"].QueryDefs["CIPatientListByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<CollectedInvoice.CIPatientListByDate_Class>(queryDef, paramList, pi);
        }

        public static BindingList<CollectedInvoice.CIPatientListByDate_Class> CIPatientListByDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COLLECTEDINVOICE"].QueryDefs["CIPatientListByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<CollectedInvoice.CIPatientListByDate_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<CollectedInvoice.CIEpisodeCountByDate_Class> CIEpisodeCountByDate(DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COLLECTEDINVOICE"].QueryDefs["CIEpisodeCountByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<CollectedInvoice.CIEpisodeCountByDate_Class>(queryDef, paramList, pi);
        }

        public static BindingList<CollectedInvoice.CIEpisodeCountByDate_Class> CIEpisodeCountByDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COLLECTEDINVOICE"].QueryDefs["CIEpisodeCountByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<CollectedInvoice.CIEpisodeCountByDate_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<CollectedInvoice.CIReportQuery_Class> CIReportQuery(DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COLLECTEDINVOICE"].QueryDefs["CIReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<CollectedInvoice.CIReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<CollectedInvoice.CIReportQuery_Class> CIReportQuery(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COLLECTEDINVOICE"].QueryDefs["CIReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<CollectedInvoice.CIReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Hastanın Durumu
    /// </summary>
        public OutPatientInPatientEnum? PATIENTSTATUS
        {
            get { return (OutPatientInPatientEnum?)(int?)this["PATIENTSTATUS"]; }
            set { this["PATIENTSTATUS"] = value; }
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
    /// Başlangıç Tarihi
    /// </summary>
        public DateTime? STARTDATE
        {
            get { return (DateTime?)this["STARTDATE"]; }
            set { this["STARTDATE"] = value; }
        }

    /// <summary>
    /// Bitiş Tarihi
    /// </summary>
        public DateTime? ENDDATE
        {
            get { return (DateTime?)this["ENDDATE"]; }
            set { this["ENDDATE"] = value; }
        }

    /// <summary>
    /// Listeleme Tipi
    /// </summary>
        public bool? LISTTYPE
        {
            get { return (bool?)this["LISTTYPE"]; }
            set { this["LISTTYPE"] = value; }
        }

    /// <summary>
    /// Diş Faturası
    /// </summary>
        public bool? TOOTHINVOICE
        {
            get { return (bool?)this["TOOTHINVOICE"]; }
            set { this["TOOTHINVOICE"] = value; }
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
    /// Toplu Fatura Dökümanıyla İlişki
    /// </summary>
        public CollectedInvoiceDocument CollectedInvoiceDocument
        {
            get { return (CollectedInvoiceDocument)((ITTObject)this).GetParent("COLLECTEDINVOICEDOCUMENT"); }
            set { this["COLLECTEDINVOICEDOCUMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateCollectedInvoicePayerListsCollection()
        {
            _CollectedInvoicePayerLists = new CollectedInvoicePayerList.ChildCollectedInvoicePayerListCollection(this, new Guid("7a2d80fb-84e5-4ac3-9da9-3f3d077bfe44"));
            ((ITTChildObjectCollection)_CollectedInvoicePayerLists).GetChildren();
        }

        protected CollectedInvoicePayerList.ChildCollectedInvoicePayerListCollection _CollectedInvoicePayerLists = null;
    /// <summary>
    /// Child collection for Toplu Fatura İşlemiyle İlişki
    /// </summary>
        public CollectedInvoicePayerList.ChildCollectedInvoicePayerListCollection CollectedInvoicePayerLists
        {
            get
            {
                if (_CollectedInvoicePayerLists == null)
                    CreateCollectedInvoicePayerListsCollection();
                return _CollectedInvoicePayerLists;
            }
        }

        virtual protected void CreateCollectedPatientsCollection()
        {
            _CollectedPatients = new CollectedPatientList.ChildCollectedPatientListCollection(this, new Guid("e8114823-8c50-49e8-bbf4-698927155454"));
            ((ITTChildObjectCollection)_CollectedPatients).GetChildren();
        }

        protected CollectedPatientList.ChildCollectedPatientListCollection _CollectedPatients = null;
    /// <summary>
    /// Child collection for Toplu Fatıura İşlemiyle İlişki
    /// </summary>
        public CollectedPatientList.ChildCollectedPatientListCollection CollectedPatients
        {
            get
            {
                if (_CollectedPatients == null)
                    CreateCollectedPatientsCollection();
                return _CollectedPatients;
            }
        }

        override protected void CreateAccountDocumentsCollection()
        {
            _AccountDocuments = new AccountDocument.ChildAccountDocumentCollection(this, new Guid("c7ecb493-a062-47a4-8f94-6602f01bc607"));
            ((ITTChildObjectCollection)_AccountDocuments).GetChildren();
        }

        virtual protected void CreateCollectedInvoiceResourceListsCollection()
        {
            _CollectedInvoiceResourceLists = new CollectedInvoiceResourceList.ChildCollectedInvoiceResourceListCollection(this, new Guid("517875c0-9a2f-4bd4-b513-e5bb1ee21e33"));
            ((ITTChildObjectCollection)_CollectedInvoiceResourceLists).GetChildren();
        }

        protected CollectedInvoiceResourceList.ChildCollectedInvoiceResourceListCollection _CollectedInvoiceResourceLists = null;
    /// <summary>
    /// Child collection for Toplu Fatura İşlemiyle İlişki
    /// </summary>
        public CollectedInvoiceResourceList.ChildCollectedInvoiceResourceListCollection CollectedInvoiceResourceLists
        {
            get
            {
                if (_CollectedInvoiceResourceLists == null)
                    CreateCollectedInvoiceResourceListsCollection();
                return _CollectedInvoiceResourceLists;
            }
        }

        protected CollectedInvoice(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected CollectedInvoice(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected CollectedInvoice(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected CollectedInvoice(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected CollectedInvoice(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "COLLECTEDINVOICE", dataRow) { }
        protected CollectedInvoice(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "COLLECTEDINVOICE", dataRow, isImported) { }
        public CollectedInvoice(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public CollectedInvoice(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public CollectedInvoice() : base() { }

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
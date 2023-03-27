
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="CollectedPatientList")] 

    /// <summary>
    /// Toplu Fatura Hasta Listesi
    /// </summary>
    public  partial class CollectedPatientList : TTObject
    {
        public class CollectedPatientListList : TTObjectCollection<CollectedPatientList> { }
                    
        public class ChildCollectedPatientListCollection : TTObject.TTChildObjectCollection<CollectedPatientList>
        {
            public ChildCollectedPatientListCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildCollectedPatientListCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class OLAP_GetCollectedPatientList_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? Docobjid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DOCOBJID"]);
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

            public Guid? Payer
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PAYER"]);
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

            public Guid? Episode
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODE"]);
                }
            }

            public Object Statestatus
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["STATESTATUS"]);
                }
            }

            public OLAP_GetCollectedPatientList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetCollectedPatientList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetCollectedPatientList_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetCollectedPatientListDetail2_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
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

            public Guid? ProcedureObject
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PROCEDUREOBJECT"]);
                }
            }

            public Object Ptype
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PTYPE"]);
                }
            }

            public OLAP_GetCollectedPatientListDetail2_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetCollectedPatientListDetail2_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetCollectedPatientListDetail2_Class() : base() { }
        }

        [Serializable] 

        public partial class CollectedInvoiceCoverPageQuery_SE_Class : TTReportNqlObject 
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

            public CollectedInvoiceCoverPageQuery_SE_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public CollectedInvoiceCoverPageQuery_SE_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected CollectedInvoiceCoverPageQuery_SE_Class() : base() { }
        }

        [Serializable] 

        public partial class CollectedInvoicePreReportQuery_SE_Class : TTReportNqlObject 
        {
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

            public Object Subepisodecount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["SUBEPISODECOUNT"]);
                }
            }

            public Object Totalprice
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOTALPRICE"]);
                }
            }

            public CollectedInvoicePreReportQuery_SE_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public CollectedInvoicePreReportQuery_SE_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected CollectedInvoicePreReportQuery_SE_Class() : base() { }
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

            public CollectedInvoiceProcedureDetailReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public CollectedInvoiceProcedureDetailReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected CollectedInvoiceProcedureDetailReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class CollectedInvoiceCoverPageQuery_Class : TTReportNqlObject 
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

            public CollectedInvoiceCoverPageQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public CollectedInvoiceCoverPageQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected CollectedInvoiceCoverPageQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class CollectedInvoiceProcedureDetailReportQuery_SE_Class : TTReportNqlObject 
        {
            public Guid? Subepisodeobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SUBEPISODEOBJECTID"]);
                }
            }

            public string Subepisodeprotocolno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUBEPISODEPROTOCOLNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].AllPropertyDefs["PROTOCOLNO"].DataType;
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

            public DateTime? ClosingDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CLOSINGDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].AllPropertyDefs["CLOSINGDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
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

            public DateTime? Episodeopeningdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EPISODEOPENINGDATE"]);
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

            public Guid? Sex
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SEX"]);
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

            public CollectedInvoiceProcedureDetailReportQuery_SE_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public CollectedInvoiceProcedureDetailReportQuery_SE_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected CollectedInvoiceProcedureDetailReportQuery_SE_Class() : base() { }
        }

        [Serializable] 

        public partial class CollectedInvoiceCoverPageQuery_Tooth_Class : TTReportNqlObject 
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

            public CollectedInvoiceCoverPageQuery_Tooth_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public CollectedInvoiceCoverPageQuery_Tooth_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected CollectedInvoiceCoverPageQuery_Tooth_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetCancelledCollectedPatientList_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Object Statestatus
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["STATESTATUS"]);
                }
            }

            public OLAP_GetCancelledCollectedPatientList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetCancelledCollectedPatientList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetCancelledCollectedPatientList_Class() : base() { }
        }

        [Serializable] 

        public partial class CollectedInvoiceListReportQuery_Tooth_Class : TTReportNqlObject 
        {
            public Object Specialityname
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["SPECIALITYNAME"]);
                }
            }

            public Object Specialitycode
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["SPECIALITYCODE"]);
                }
            }

            public Guid? Episodeobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODEOBJECTID"]);
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

            public Object Patientname
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PATIENTNAME"]);
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

            public CollectedInvoiceListReportQuery_Tooth_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public CollectedInvoiceListReportQuery_Tooth_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected CollectedInvoiceListReportQuery_Tooth_Class() : base() { }
        }

        [Serializable] 

        public partial class CollectedInvoiceListReportQuery_SE_Class : TTReportNqlObject 
        {
            public Guid? Subepisodeobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SUBEPISODEOBJECTID"]);
                }
            }

            public string Subepisodeprotocolno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUBEPISODEPROTOCOLNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].AllPropertyDefs["PROTOCOLNO"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public string Subepisoderesource
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUBEPISODERESOURCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
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

            public Guid? Episodeobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODEOBJECTID"]);
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

            public Object Patientname
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PATIENTNAME"]);
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

            public CollectedInvoiceListReportQuery_SE_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public CollectedInvoiceListReportQuery_SE_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected CollectedInvoiceListReportQuery_SE_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetCollectedPatientListDetail_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
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

            public Guid? ProcedureObject
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PROCEDUREOBJECT"]);
                }
            }

            public Object Ptype
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PTYPE"]);
                }
            }

            public OLAP_GetCollectedPatientListDetail_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetCollectedPatientListDetail_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetCollectedPatientListDetail_Class() : base() { }
        }

        public static BindingList<CollectedPatientList.OLAP_GetCollectedPatientList_Class> OLAP_GetCollectedPatientList(DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COLLECTEDPATIENTLIST"].QueryDefs["OLAP_GetCollectedPatientList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<CollectedPatientList.OLAP_GetCollectedPatientList_Class>(queryDef, paramList, pi);
        }

        public static BindingList<CollectedPatientList.OLAP_GetCollectedPatientList_Class> OLAP_GetCollectedPatientList(TTObjectContext objectContext, DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COLLECTEDPATIENTLIST"].QueryDefs["OLAP_GetCollectedPatientList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<CollectedPatientList.OLAP_GetCollectedPatientList_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// LISTTYPE False olarak kesilen faturalarda çalışır, Toplu Faturaya Hazır ların kesildiği faturalarda çalışmaz
    /// </summary>
        public static BindingList<CollectedPatientList.OLAP_GetCollectedPatientListDetail2_Class> OLAP_GetCollectedPatientListDetail2(string DOCUMENTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COLLECTEDPATIENTLIST"].QueryDefs["OLAP_GetCollectedPatientListDetail2"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DOCUMENTID", DOCUMENTID);

            return TTReportNqlObject.QueryObjects<CollectedPatientList.OLAP_GetCollectedPatientListDetail2_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// LISTTYPE False olarak kesilen faturalarda çalışır, Toplu Faturaya Hazır ların kesildiği faturalarda çalışmaz
    /// </summary>
        public static BindingList<CollectedPatientList.OLAP_GetCollectedPatientListDetail2_Class> OLAP_GetCollectedPatientListDetail2(TTObjectContext objectContext, string DOCUMENTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COLLECTEDPATIENTLIST"].QueryDefs["OLAP_GetCollectedPatientListDetail2"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DOCUMENTID", DOCUMENTID);

            return TTReportNqlObject.QueryObjects<CollectedPatientList.OLAP_GetCollectedPatientListDetail2_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<CollectedPatientList.CollectedInvoiceCoverPageQuery_SE_Class> CollectedInvoiceCoverPageQuery_SE(string COLLINVOICEOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COLLECTEDPATIENTLIST"].QueryDefs["CollectedInvoiceCoverPageQuery_SE"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("COLLINVOICEOBJID", COLLINVOICEOBJID);

            return TTReportNqlObject.QueryObjects<CollectedPatientList.CollectedInvoiceCoverPageQuery_SE_Class>(queryDef, paramList, pi);
        }

        public static BindingList<CollectedPatientList.CollectedInvoiceCoverPageQuery_SE_Class> CollectedInvoiceCoverPageQuery_SE(TTObjectContext objectContext, string COLLINVOICEOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COLLECTEDPATIENTLIST"].QueryDefs["CollectedInvoiceCoverPageQuery_SE"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("COLLINVOICEOBJID", COLLINVOICEOBJID);

            return TTReportNqlObject.QueryObjects<CollectedPatientList.CollectedInvoiceCoverPageQuery_SE_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<CollectedPatientList.CollectedInvoicePreReportQuery_SE_Class> CollectedInvoicePreReportQuery_SE(string COLLINVOICEOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COLLECTEDPATIENTLIST"].QueryDefs["CollectedInvoicePreReportQuery_SE"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("COLLINVOICEOBJID", COLLINVOICEOBJID);

            return TTReportNqlObject.QueryObjects<CollectedPatientList.CollectedInvoicePreReportQuery_SE_Class>(queryDef, paramList, pi);
        }

        public static BindingList<CollectedPatientList.CollectedInvoicePreReportQuery_SE_Class> CollectedInvoicePreReportQuery_SE(TTObjectContext objectContext, string COLLINVOICEOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COLLECTEDPATIENTLIST"].QueryDefs["CollectedInvoicePreReportQuery_SE"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("COLLINVOICEOBJID", COLLINVOICEOBJID);

            return TTReportNqlObject.QueryObjects<CollectedPatientList.CollectedInvoicePreReportQuery_SE_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<CollectedPatientList.CollectedInvoiceProcedureDetailReportQuery_Class> CollectedInvoiceProcedureDetailReportQuery(string PARAMCOLLINVOICEOBJID, IList<string> PARAMRESOURCE, int PARAMRESOURCEFLAG, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COLLECTEDPATIENTLIST"].QueryDefs["CollectedInvoiceProcedureDetailReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMCOLLINVOICEOBJID", PARAMCOLLINVOICEOBJID);
            paramList.Add("PARAMRESOURCE", PARAMRESOURCE);
            paramList.Add("PARAMRESOURCEFLAG", PARAMRESOURCEFLAG);

            return TTReportNqlObject.QueryObjects<CollectedPatientList.CollectedInvoiceProcedureDetailReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<CollectedPatientList.CollectedInvoiceProcedureDetailReportQuery_Class> CollectedInvoiceProcedureDetailReportQuery(TTObjectContext objectContext, string PARAMCOLLINVOICEOBJID, IList<string> PARAMRESOURCE, int PARAMRESOURCEFLAG, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COLLECTEDPATIENTLIST"].QueryDefs["CollectedInvoiceProcedureDetailReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMCOLLINVOICEOBJID", PARAMCOLLINVOICEOBJID);
            paramList.Add("PARAMRESOURCE", PARAMRESOURCE);
            paramList.Add("PARAMRESOURCEFLAG", PARAMRESOURCEFLAG);

            return TTReportNqlObject.QueryObjects<CollectedPatientList.CollectedInvoiceProcedureDetailReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<CollectedPatientList.CollectedInvoiceCoverPageQuery_Class> CollectedInvoiceCoverPageQuery(string COLLINVOICEOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COLLECTEDPATIENTLIST"].QueryDefs["CollectedInvoiceCoverPageQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("COLLINVOICEOBJID", COLLINVOICEOBJID);

            return TTReportNqlObject.QueryObjects<CollectedPatientList.CollectedInvoiceCoverPageQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<CollectedPatientList.CollectedInvoiceCoverPageQuery_Class> CollectedInvoiceCoverPageQuery(TTObjectContext objectContext, string COLLINVOICEOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COLLECTEDPATIENTLIST"].QueryDefs["CollectedInvoiceCoverPageQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("COLLINVOICEOBJID", COLLINVOICEOBJID);

            return TTReportNqlObject.QueryObjects<CollectedPatientList.CollectedInvoiceCoverPageQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<CollectedPatientList.CollectedInvoiceProcedureDetailReportQuery_SE_Class> CollectedInvoiceProcedureDetailReportQuery_SE(string COLLINVOICEOBJID, IList<string> RESOURCE, int RESOURCEFLAG, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COLLECTEDPATIENTLIST"].QueryDefs["CollectedInvoiceProcedureDetailReportQuery_SE"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("COLLINVOICEOBJID", COLLINVOICEOBJID);
            paramList.Add("RESOURCE", RESOURCE);
            paramList.Add("RESOURCEFLAG", RESOURCEFLAG);

            return TTReportNqlObject.QueryObjects<CollectedPatientList.CollectedInvoiceProcedureDetailReportQuery_SE_Class>(queryDef, paramList, pi);
        }

        public static BindingList<CollectedPatientList.CollectedInvoiceProcedureDetailReportQuery_SE_Class> CollectedInvoiceProcedureDetailReportQuery_SE(TTObjectContext objectContext, string COLLINVOICEOBJID, IList<string> RESOURCE, int RESOURCEFLAG, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COLLECTEDPATIENTLIST"].QueryDefs["CollectedInvoiceProcedureDetailReportQuery_SE"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("COLLINVOICEOBJID", COLLINVOICEOBJID);
            paramList.Add("RESOURCE", RESOURCE);
            paramList.Add("RESOURCEFLAG", RESOURCEFLAG);

            return TTReportNqlObject.QueryObjects<CollectedPatientList.CollectedInvoiceProcedureDetailReportQuery_SE_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<CollectedPatientList.CollectedInvoiceCoverPageQuery_Tooth_Class> CollectedInvoiceCoverPageQuery_Tooth(string COLLINVOICEOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COLLECTEDPATIENTLIST"].QueryDefs["CollectedInvoiceCoverPageQuery_Tooth"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("COLLINVOICEOBJID", COLLINVOICEOBJID);

            return TTReportNqlObject.QueryObjects<CollectedPatientList.CollectedInvoiceCoverPageQuery_Tooth_Class>(queryDef, paramList, pi);
        }

        public static BindingList<CollectedPatientList.CollectedInvoiceCoverPageQuery_Tooth_Class> CollectedInvoiceCoverPageQuery_Tooth(TTObjectContext objectContext, string COLLINVOICEOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COLLECTEDPATIENTLIST"].QueryDefs["CollectedInvoiceCoverPageQuery_Tooth"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("COLLINVOICEOBJID", COLLINVOICEOBJID);

            return TTReportNqlObject.QueryObjects<CollectedPatientList.CollectedInvoiceCoverPageQuery_Tooth_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<CollectedPatientList.OLAP_GetCancelledCollectedPatientList_Class> OLAP_GetCancelledCollectedPatientList(DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COLLECTEDPATIENTLIST"].QueryDefs["OLAP_GetCancelledCollectedPatientList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<CollectedPatientList.OLAP_GetCancelledCollectedPatientList_Class>(queryDef, paramList, pi);
        }

        public static BindingList<CollectedPatientList.OLAP_GetCancelledCollectedPatientList_Class> OLAP_GetCancelledCollectedPatientList(TTObjectContext objectContext, DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COLLECTEDPATIENTLIST"].QueryDefs["OLAP_GetCancelledCollectedPatientList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<CollectedPatientList.OLAP_GetCancelledCollectedPatientList_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<CollectedPatientList.CollectedInvoiceListReportQuery_Tooth_Class> CollectedInvoiceListReportQuery_Tooth(string COLLINVOICEOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COLLECTEDPATIENTLIST"].QueryDefs["CollectedInvoiceListReportQuery_Tooth"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("COLLINVOICEOBJID", COLLINVOICEOBJID);

            return TTReportNqlObject.QueryObjects<CollectedPatientList.CollectedInvoiceListReportQuery_Tooth_Class>(queryDef, paramList, pi);
        }

        public static BindingList<CollectedPatientList.CollectedInvoiceListReportQuery_Tooth_Class> CollectedInvoiceListReportQuery_Tooth(TTObjectContext objectContext, string COLLINVOICEOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COLLECTEDPATIENTLIST"].QueryDefs["CollectedInvoiceListReportQuery_Tooth"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("COLLINVOICEOBJID", COLLINVOICEOBJID);

            return TTReportNqlObject.QueryObjects<CollectedPatientList.CollectedInvoiceListReportQuery_Tooth_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<CollectedPatientList.CollectedInvoiceListReportQuery_SE_Class> CollectedInvoiceListReportQuery_SE(string COLLINVOICEOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COLLECTEDPATIENTLIST"].QueryDefs["CollectedInvoiceListReportQuery_SE"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("COLLINVOICEOBJID", COLLINVOICEOBJID);

            return TTReportNqlObject.QueryObjects<CollectedPatientList.CollectedInvoiceListReportQuery_SE_Class>(queryDef, paramList, pi);
        }

        public static BindingList<CollectedPatientList.CollectedInvoiceListReportQuery_SE_Class> CollectedInvoiceListReportQuery_SE(TTObjectContext objectContext, string COLLINVOICEOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COLLECTEDPATIENTLIST"].QueryDefs["CollectedInvoiceListReportQuery_SE"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("COLLINVOICEOBJID", COLLINVOICEOBJID);

            return TTReportNqlObject.QueryObjects<CollectedPatientList.CollectedInvoiceListReportQuery_SE_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<CollectedPatientList.OLAP_GetCollectedPatientListDetail_Class> OLAP_GetCollectedPatientListDetail(string DOCUMENTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COLLECTEDPATIENTLIST"].QueryDefs["OLAP_GetCollectedPatientListDetail"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DOCUMENTID", DOCUMENTID);

            return TTReportNqlObject.QueryObjects<CollectedPatientList.OLAP_GetCollectedPatientListDetail_Class>(queryDef, paramList, pi);
        }

        public static BindingList<CollectedPatientList.OLAP_GetCollectedPatientListDetail_Class> OLAP_GetCollectedPatientListDetail(TTObjectContext objectContext, string DOCUMENTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COLLECTEDPATIENTLIST"].QueryDefs["OLAP_GetCollectedPatientListDetail"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DOCUMENTID", DOCUMENTID);

            return TTReportNqlObject.QueryObjects<CollectedPatientList.OLAP_GetCollectedPatientListDetail_Class>(objectContext, queryDef, paramList, pi);
        }

        public string RetirementFundID
        {
            get { return (string)this["RETIREMENTFUNDID"]; }
            set { this["RETIREMENTFUNDID"] = value; }
        }

    /// <summary>
    /// Kurum Adı
    /// </summary>
        public string PayerName
        {
            get { return (string)this["PAYERNAME"]; }
            set { this["PAYERNAME"] = value; }
        }

        public long? UniqueRefNo
        {
            get { return (long?)this["UNIQUEREFNO"]; }
            set { this["UNIQUEREFNO"] = value; }
        }

    /// <summary>
    /// Toplam Tutar
    /// </summary>
        public Currency? TotalPrice
        {
            get { return (Currency?)this["TOTALPRICE"]; }
            set { this["TOTALPRICE"] = value; }
        }

        public string PatientName
        {
            get { return (string)this["PATIENTNAME"]; }
            set { this["PATIENTNAME"] = value; }
        }

        public string PatientSurname
        {
            get { return (string)this["PATIENTSURNAME"]; }
            set { this["PATIENTSURNAME"] = value; }
        }

        public long? HospitalProtocolNo
        {
            get { return (long?)this["HOSPITALPROTOCOLNO"]; }
            set { this["HOSPITALPROTOCOLNO"] = value; }
        }

    /// <summary>
    /// Faturaya dahil edilecek mi ?
    /// </summary>
        public bool? Invoiced
        {
            get { return (bool?)this["INVOICED"]; }
            set { this["INVOICED"] = value; }
        }

    /// <summary>
    /// Vaka Açılış Tarihi
    /// </summary>
        public DateTime? OpeningDate
        {
            get { return (DateTime?)this["OPENINGDATE"]; }
            set { this["OPENINGDATE"] = value; }
        }

    /// <summary>
    /// Hasta Dosyasıyla İlişki
    /// </summary>
        public Episode Episode
        {
            get { return (Episode)((ITTObject)this).GetParent("EPISODE"); }
            set { this["EPISODE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Toplu Fatıura İşlemiyle İlişki
    /// </summary>
        public CollectedInvoice CollectedInvoice
        {
            get { return (CollectedInvoice)((ITTObject)this).GetParent("COLLECTEDINVOICE"); }
            set { this["COLLECTEDINVOICE"] = (value==null ? null : (Guid?)value.ObjectID); }
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
    /// Kurum Faturası İşlemiyle İlişki
    /// </summary>
        public PayerInvoice PayerInvoice
        {
            get { return (PayerInvoice)((ITTObject)this).GetParent("PAYERINVOICE"); }
            set { this["PAYERINVOICE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Alt Vaka ile ilişki
    /// </summary>
        public SubEpisode SubEpisode
        {
            get { return (SubEpisode)((ITTObject)this).GetParent("SUBEPISODE"); }
            set { this["SUBEPISODE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateAccountTransactionsCollection()
        {
            _AccountTransactions = new AccountTransaction.ChildAccountTransactionCollection(this, new Guid("1a882d6a-af4b-4bbc-b233-657256410ecc"));
            ((ITTChildObjectCollection)_AccountTransactions).GetChildren();
        }

        protected AccountTransaction.ChildAccountTransactionCollection _AccountTransactions = null;
    /// <summary>
    /// Child collection for Toplu fatura ile ilişki
    /// </summary>
        public AccountTransaction.ChildAccountTransactionCollection AccountTransactions
        {
            get
            {
                if (_AccountTransactions == null)
                    CreateAccountTransactionsCollection();
                return _AccountTransactions;
            }
        }

        protected CollectedPatientList(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected CollectedPatientList(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected CollectedPatientList(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected CollectedPatientList(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected CollectedPatientList(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "COLLECTEDPATIENTLIST", dataRow) { }
        protected CollectedPatientList(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "COLLECTEDPATIENTLIST", dataRow, isImported) { }
        public CollectedPatientList(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public CollectedPatientList(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public CollectedPatientList() : base() { }

    }
}
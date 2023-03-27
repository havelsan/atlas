
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SubActionProcedure")] 

    public  partial class SubActionProcedure : TTObject, IMedulaChildOfEpisodeAction, ISUTInstance, ISetWorkListDate, ISubEpisodeStarter
    {
        public class SubActionProcedureList : TTObjectCollection<SubActionProcedure> { }
                    
        public class ChildSubActionProcedureCollection : TTObject.TTChildObjectCollection<SubActionProcedure>
        {
            public ChildSubActionProcedureCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSubActionProcedureCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetExaminationTestListNQL_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public DateTime? WorkListDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WORKLISTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].AllPropertyDefs["WORKLISTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Procedurename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDURENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetExaminationTestListNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetExaminationTestListNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetExaminationTestListNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_SGKStatisticQuery1_SECount_Class : TTReportNqlObject 
        {
            public Object Altvakasayisi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["ALTVAKASAYISI"]);
                }
            }

            public OLAP_SGKStatisticQuery1_SECount_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_SGKStatisticQuery1_SECount_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_SGKStatisticQuery1_SECount_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_SGKStatisticQuery1_PatientCount_Class : TTReportNqlObject 
        {
            public Object Tckimliknosayisi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TCKIMLIKNOSAYISI"]);
                }
            }

            public OLAP_SGKStatisticQuery1_PatientCount_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_SGKStatisticQuery1_PatientCount_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_SGKStatisticQuery1_PatientCount_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_SGKStatisticQuery2_PatientCount_Class : TTReportNqlObject 
        {
            public Object Tckimliknosayisi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TCKIMLIKNOSAYISI"]);
                }
            }

            public OLAP_SGKStatisticQuery2_PatientCount_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_SGKStatisticQuery2_PatientCount_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_SGKStatisticQuery2_PatientCount_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetDentalTreatments_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? Treatment
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["TREATMENT"]);
                }
            }

            public OLAP_GetDentalTreatments_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetDentalTreatments_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetDentalTreatments_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_SGKStatisticQuery2_SECount_Class : TTReportNqlObject 
        {
            public Object Altvakasayisi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["ALTVAKASAYISI"]);
                }
            }

            public OLAP_SGKStatisticQuery2_SECount_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_SGKStatisticQuery2_SECount_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_SGKStatisticQuery2_SECount_Class() : base() { }
        }

        [Serializable] 

        public partial class GetProcedureNameAndCode_Class : TTReportNqlObject 
        {
            public string Procedurename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDURENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Procedurecode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDURECODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetProcedureNameAndCode_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetProcedureNameAndCode_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetProcedureNameAndCode_Class() : base() { }
        }

        [Serializable] 

        public partial class GetOldInfoForRequestedProcedures_Class : TTReportNqlObject 
        {
            public Guid? Subactionprocedureobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SUBACTIONPROCEDUREOBJECTID"]);
                }
            }

            public string Procedurecode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDURECODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Procedurename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDURENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].AllPropertyDefs["AMOUNT"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Requestby
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTBY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? Requestdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].AllPropertyDefs["CREATIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Masterresource
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MASTERRESOURCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Procedureobjectdef
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PROCEDUREOBJECTDEF"]);
                }
            }

            public String DisplayText
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISPLAYTEXT"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public Guid? CurrentStateDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENTSTATEDEFID"]);
                }
            }

            public bool? Emergency
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EMERGENCY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].AllPropertyDefs["EMERGENCY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public String Defname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DEFNAME"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public GetOldInfoForRequestedProcedures_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetOldInfoForRequestedProcedures_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetOldInfoForRequestedProcedures_Class() : base() { }
        }

        [Serializable] 

        public partial class GetOldInfoCountForRequestedProcedures_Class : TTReportNqlObject 
        {
            public Object Nqlcolumn
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["NQLCOLUMN"]);
                }
            }

            public GetOldInfoCountForRequestedProcedures_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetOldInfoCountForRequestedProcedures_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetOldInfoCountForRequestedProcedures_Class() : base() { }
        }

        [Serializable] 

        public partial class GetSubActionProcedureByTimeInterval_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetSubActionProcedureByTimeInterval_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSubActionProcedureByTimeInterval_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSubActionProcedureByTimeInterval_Class() : base() { }
        }

        [Serializable] 

        public partial class DisTetkikIstemRaporTestsNQL2_Class : TTReportNqlObject 
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

            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public bool? Eligible
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ELIGIBLE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].AllPropertyDefs["ELIGIBLE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string ReasonOfCancel
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REASONOFCANCEL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].AllPropertyDefs["REASONOFCANCEL"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? WorkListDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WORKLISTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].AllPropertyDefs["WORKLISTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? PricingDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRICINGDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].AllPropertyDefs["PRICINGDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public long? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].AllPropertyDefs["AMOUNT"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ActionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].AllPropertyDefs["ACTIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].AllPropertyDefs["EMERGENCY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? Active
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIVE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].AllPropertyDefs["ACTIVE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DateTime? OlapDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLAPDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].AllPropertyDefs["OLAPDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? OlapLastUpdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLAPLASTUPDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].AllPropertyDefs["OLAPLASTUPDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? AccountOperationDone
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACCOUNTOPERATIONDONE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].AllPropertyDefs["ACCOUNTOPERATIONDONE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? AccTrxsMultipliedByAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACCTRXSMULTIPLIEDBYAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].AllPropertyDefs["ACCTRXSMULTIPLIEDBYAMOUNT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].AllPropertyDefs["PATIENTPAY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string ExtraDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXTRADESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].AllPropertyDefs["EXTRADESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public SutRuleEngineStatus? SUTRuleStatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUTRULESTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].AllPropertyDefs["SUTRULESTATUS"].DataType;
                    return (SutRuleEngineStatus?)(int)dataType.ConvertValue(val);
                }
            }

            public double? DiscountPercent
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISCOUNTPERCENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].AllPropertyDefs["DISCOUNTPERCENT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public DateTime? PerformedDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PERFORMEDDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].AllPropertyDefs["PERFORMEDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? CreationDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CREATIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].AllPropertyDefs["CREATIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? IsOldAction
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISOLDACTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].AllPropertyDefs["ISOLDACTION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
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

            public RightLeftEnum? RightLeftInformation
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RIGHTLEFTINFORMATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].AllPropertyDefs["RIGHTLEFTINFORMATION"].DataType;
                    return (RightLeftEnum?)(int)dataType.ConvertValue(val);
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

            public Guid? Sex
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SEX"]);
                }
            }

            public string FatherName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FATHERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["FATHERNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public Object Cityname
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["CITYNAME"]);
                }
            }

            public string Townname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOWNNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TOWNDEFINITIONS"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? Requestdate2
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDATE2"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
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

            public Object Reasonforadm
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["REASONFORADM"]);
                }
            }

            public DateTime? Actdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
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

            public long? Actionid
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Pcode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Pname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Requesteduser
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["REQUESTEDUSER"]);
                }
            }

            public DisTetkikIstemRaporTestsNQL2_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public DisTetkikIstemRaporTestsNQL2_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected DisTetkikIstemRaporTestsNQL2_Class() : base() { }
        }

        [Serializable] 

        public partial class GunSonu_HizmetSayisi_IslemZamani_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GunSonu_HizmetSayisi_IslemZamani_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GunSonu_HizmetSayisi_IslemZamani_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GunSonu_HizmetSayisi_IslemZamani_Class() : base() { }
        }

        [Serializable] 

        public partial class GetRequestedProceduresBySubEpisode_Class : TTReportNqlObject 
        {
            public Guid? Subactionprocedureobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SUBACTIONPROCEDUREOBJECTID"]);
                }
            }

            public string Procedurecode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDURECODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Procedurename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDURENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].AllPropertyDefs["AMOUNT"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Requestby
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTBY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? Requestdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].AllPropertyDefs["CREATIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? Requestbyid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["REQUESTBYID"]);
                }
            }

            public string Proceduredoctorname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDUREDOCTORNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Proceduredoctorid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PROCEDUREDOCTORID"]);
                }
            }

            public string Procedurebyusername
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDUREBYUSERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Procedurebyuserid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PROCEDUREBYUSERID"]);
                }
            }

            public Guid? MasterResource
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MASTERRESOURCE"]);
                }
            }

            public Guid? Procedureobjectdef
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PROCEDUREOBJECTDEF"]);
                }
            }

            public String DisplayText
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISPLAYTEXT"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public Guid? CurrentStateDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENTSTATEDEFID"]);
                }
            }

            public bool? Emergency
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EMERGENCY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].AllPropertyDefs["EMERGENCY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public String ObjectDefName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OBJECTDEFNAME"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public Guid? Procedureobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PROCEDUREOBJECTID"]);
                }
            }

            public Guid? Episodeactionobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODEACTIONOBJECTID"]);
                }
            }

            public Object Statestatus
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["STATESTATUS"]);
                }
            }

            public GetRequestedProceduresBySubEpisode_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetRequestedProceduresBySubEpisode_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetRequestedProceduresBySubEpisode_Class() : base() { }
        }

        [Serializable] 

        public partial class GunSonu_HizmetBasvuruSayisi_IslemZamani_Class : TTReportNqlObject 
        {
            public Object Count
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["COUNT"]);
                }
            }

            public GunSonu_HizmetBasvuruSayisi_IslemZamani_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GunSonu_HizmetBasvuruSayisi_IslemZamani_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GunSonu_HizmetBasvuruSayisi_IslemZamani_Class() : base() { }
        }

        [Serializable] 

        public partial class GunSonu_HizmetSayisi_GerceklesmeZamani_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GunSonu_HizmetSayisi_GerceklesmeZamani_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GunSonu_HizmetSayisi_GerceklesmeZamani_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GunSonu_HizmetSayisi_GerceklesmeZamani_Class() : base() { }
        }

        [Serializable] 

        public partial class GunSonu_HizmetSayisi_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GunSonu_HizmetSayisi_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GunSonu_HizmetSayisi_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GunSonu_HizmetSayisi_Class() : base() { }
        }

        [Serializable] 

        public partial class GetProcedureForDP_Class : TTReportNqlObject 
        {
            public Guid? Sapid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SAPID"]);
                }
            }

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

            public Guid? Procedureid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PROCEDUREID"]);
                }
            }

            public string GILCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GILCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["GILCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Procedurename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDURENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? GILPoint
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GILPOINT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["GILPOINT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string Doctorname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCTORNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Doctorid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DOCTORID"]);
                }
            }

            public long? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].AllPropertyDefs["AMOUNT"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? PerformedDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PERFORMEDDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].AllPropertyDefs["PERFORMEDDATE"].DataType;
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

            public Guid? Patientid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PATIENTID"]);
                }
            }

            public DateTime? Patientbirthdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTBIRTHDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["BIRTHDATE"].DataType;
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

            public string Ressection
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESSECTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Ismhrs
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["ISMHRS"]);
                }
            }

            public bool? IsPatientHistoryShown
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISPATIENTHISTORYSHOWN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].AllPropertyDefs["ISPATIENTHISTORYSHOWN"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string SurgeryGroup
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SURGERYGROUP"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["GILDEFINITION"].AllPropertyDefs["SURGERYGROUP"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetProcedureForDP_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetProcedureForDP_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetProcedureForDP_Class() : base() { }
        }

        [Serializable] 

        public partial class GetProcedureCountByDateTimeIntervalByPatient_Class : TTReportNqlObject 
        {
            public DateTime? Tarih
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TARIH"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].AllPropertyDefs["CREATIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Object Sayi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["SAYI"]);
                }
            }

            public GetProcedureCountByDateTimeIntervalByPatient_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetProcedureCountByDateTimeIntervalByPatient_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetProcedureCountByDateTimeIntervalByPatient_Class() : base() { }
        }

        [Serializable] 

        public partial class GunSonu_HizmetBasvuruSayisi_GerceklesmeZamani_Class : TTReportNqlObject 
        {
            public Object Count
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["COUNT"]);
                }
            }

            public GunSonu_HizmetBasvuruSayisi_GerceklesmeZamani_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GunSonu_HizmetBasvuruSayisi_GerceklesmeZamani_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GunSonu_HizmetBasvuruSayisi_GerceklesmeZamani_Class() : base() { }
        }

        [Serializable] 

        public partial class GetProceduresByDate_Class : TTReportNqlObject 
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

            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public bool? Eligible
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ELIGIBLE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].AllPropertyDefs["ELIGIBLE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string ReasonOfCancel
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REASONOFCANCEL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].AllPropertyDefs["REASONOFCANCEL"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? WorkListDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WORKLISTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].AllPropertyDefs["WORKLISTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? PricingDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRICINGDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].AllPropertyDefs["PRICINGDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public long? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].AllPropertyDefs["AMOUNT"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ActionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].AllPropertyDefs["ACTIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].AllPropertyDefs["EMERGENCY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? Active
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIVE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].AllPropertyDefs["ACTIVE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DateTime? OlapDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLAPDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].AllPropertyDefs["OLAPDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? OlapLastUpdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLAPLASTUPDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].AllPropertyDefs["OLAPLASTUPDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? AccountOperationDone
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACCOUNTOPERATIONDONE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].AllPropertyDefs["ACCOUNTOPERATIONDONE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? AccTrxsMultipliedByAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACCTRXSMULTIPLIEDBYAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].AllPropertyDefs["ACCTRXSMULTIPLIEDBYAMOUNT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].AllPropertyDefs["PATIENTPAY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string ExtraDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXTRADESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].AllPropertyDefs["EXTRADESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public SutRuleEngineStatus? SUTRuleStatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUTRULESTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].AllPropertyDefs["SUTRULESTATUS"].DataType;
                    return (SutRuleEngineStatus?)(int)dataType.ConvertValue(val);
                }
            }

            public double? DiscountPercent
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISCOUNTPERCENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].AllPropertyDefs["DISCOUNTPERCENT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public DateTime? PerformedDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PERFORMEDDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].AllPropertyDefs["PERFORMEDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? CreationDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CREATIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].AllPropertyDefs["CREATIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? IsOldAction
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISOLDACTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].AllPropertyDefs["ISOLDACTION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
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

            public RightLeftEnum? RightLeftInformation
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RIGHTLEFTINFORMATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].AllPropertyDefs["RIGHTLEFTINFORMATION"].DataType;
                    return (RightLeftEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public GetProceduresByDate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetProceduresByDate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetProceduresByDate_Class() : base() { }
        }

        [Serializable] 

        public partial class GetSubactionProceduresBySubepisode_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public DateTime? PerformedDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PERFORMEDDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].AllPropertyDefs["PERFORMEDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Procedurecode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDURECODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Procedurename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDURENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].AllPropertyDefs["AMOUNT"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Proceduredoctorname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDUREDOCTORNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
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

            public GetSubactionProceduresBySubepisode_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSubactionProceduresBySubepisode_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSubactionProceduresBySubepisode_Class() : base() { }
        }

        [Serializable] 

        public partial class GetRequestedProceduresByEpisode_Class : TTReportNqlObject 
        {
            public Guid? Subactionprocedureobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SUBACTIONPROCEDUREOBJECTID"]);
                }
            }

            public string Procedurecode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDURECODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Procedurename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDURENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].AllPropertyDefs["AMOUNT"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Requestby
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTBY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? Requestdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].AllPropertyDefs["CREATIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? Requestbyid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["REQUESTBYID"]);
                }
            }

            public string Proceduredoctorname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDUREDOCTORNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Proceduredoctorid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PROCEDUREDOCTORID"]);
                }
            }

            public string Procedurebyusername
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDUREBYUSERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Procedurebyuserid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PROCEDUREBYUSERID"]);
                }
            }

            public Guid? MasterResource
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MASTERRESOURCE"]);
                }
            }

            public Guid? Procedureobjectdef
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PROCEDUREOBJECTDEF"]);
                }
            }

            public String DisplayText
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISPLAYTEXT"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public Guid? CurrentStateDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENTSTATEDEFID"]);
                }
            }

            public bool? Emergency
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EMERGENCY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].AllPropertyDefs["EMERGENCY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public String ObjectDefName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OBJECTDEFNAME"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public Guid? Procedureobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PROCEDUREOBJECTID"]);
                }
            }

            public Guid? Episodeactionobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODEACTIONOBJECTID"]);
                }
            }

            public Object Statestatus
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["STATESTATUS"]);
                }
            }

            public Guid? MasterSubActionProcedure
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MASTERSUBACTIONPROCEDURE"]);
                }
            }

            public GetRequestedProceduresByEpisode_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetRequestedProceduresByEpisode_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetRequestedProceduresByEpisode_Class() : base() { }
        }

        [Serializable] 

        public partial class GetSubactionProceduresByMasterSP_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Procedurename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDURENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Procedurecode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDURECODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetSubactionProceduresByMasterSP_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSubactionProceduresByMasterSP_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSubactionProceduresByMasterSP_Class() : base() { }
        }

        [Serializable] 

        public partial class GetInjectionList_Class : TTReportNqlObject 
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

            public string Resource
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESOURCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Comingreason
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["COMINGREASON"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROVIZYONTIPI"].AllPropertyDefs["PROVIZYONTIPIADI"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public string Phonenumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PHONENUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["MOBILEPHONE"].DataType;
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

            public Guid? ProcedureDoctor
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PROCEDUREDOCTOR"]);
                }
            }

            public GetInjectionList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetInjectionList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetInjectionList_Class() : base() { }
        }

        public static class States
        {
            public static Guid New { get { return new Guid("1c28a828-4470-46a5-af69-701b5322df1f"); } }
            public static Guid Completed { get { return new Guid("35536bbc-e567-46c8-be88-3bc9d65bfd5f"); } }
            public static Guid Cancelled { get { return new Guid("d16bf872-a7d1-476c-806d-92fd1852dccc"); } }
        }

        public static BindingList<SubActionProcedure> GetAllConsultationProceduresOfPatient(TTObjectContext objectContext, Guid PATIENT)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].QueryDefs["GetAllConsultationProceduresOfPatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return ((ITTQuery)objectContext).QueryObjects<SubActionProcedure>(queryDef, paramList);
        }

        public static BindingList<SubActionProcedure> GetAllConsultationProcOfEpisode(TTObjectContext objectContext, string EPISODEOBJECTID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].QueryDefs["GetAllConsultationProcOfEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODEOBJECTID", EPISODEOBJECTID);

            return ((ITTQuery)objectContext).QueryObjects<SubActionProcedure>(queryDef, paramList);
        }

        public static BindingList<SubActionProcedure> GetAllConsultationProcOfPatient(TTObjectContext objectContext, string PATIENTOBJECTID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].QueryDefs["GetAllConsultationProcOfPatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENTOBJECTID", PATIENTOBJECTID);

            return ((ITTQuery)objectContext).QueryObjects<SubActionProcedure>(queryDef, paramList);
        }

        public static BindingList<SubActionProcedure> GetAllConsultationProcOfSubEpisode(TTObjectContext objectContext, string EPISODE, string SUBEPISODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].QueryDefs["GetAllConsultationProcOfSubEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);
            paramList.Add("SUBEPISODE", SUBEPISODE);

            return ((ITTQuery)objectContext).QueryObjects<SubActionProcedure>(queryDef, paramList);
        }

        public static BindingList<SubActionProcedure> GetByObjectID(TTObjectContext objectContext, string PARAMOBJECTID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].QueryDefs["GetByObjectID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMOBJECTID", PARAMOBJECTID);

            return ((ITTQuery)objectContext).QueryObjects<SubActionProcedure>(queryDef, paramList);
        }

        public static BindingList<SubActionProcedure> GetSubActionsByDate(TTObjectContext objectContext, DateTime PARAMSTARTDATE, DateTime PARAMENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].QueryDefs["GetSubActionsByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMSTARTDATE", PARAMSTARTDATE);
            paramList.Add("PARAMENDDATE", PARAMENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<SubActionProcedure>(queryDef, paramList);
        }

        public static BindingList<SubActionProcedure> GetTestsByPatient(TTObjectContext objectContext, string PATIENTID, DateTime MINDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].QueryDefs["GetTestsByPatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENTID", PATIENTID);
            paramList.Add("MINDATE", MINDATE);

            return ((ITTQuery)objectContext).QueryObjects<SubActionProcedure>(queryDef, paramList);
        }

        public static BindingList<SubActionProcedure> GetTestsByPatientByTestByDate(TTObjectContext objectContext, string PATIENTID, DateTime STARTDATE, DateTime ENDDATE, string TESTID, string OBJECTDEFNAME)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].QueryDefs["GetTestsByPatientByTestByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENTID", PATIENTID);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("TESTID", TESTID);
            paramList.Add("OBJECTDEFNAME", OBJECTDEFNAME);

            return ((ITTQuery)objectContext).QueryObjects<SubActionProcedure>(queryDef, paramList);
        }

        public static BindingList<SubActionProcedure> GetSubActionProcedureByPObject(TTObjectContext objectContext, string POBJECT)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].QueryDefs["GetSubActionProcedureByPObject"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("POBJECT", POBJECT);

            return ((ITTQuery)objectContext).QueryObjects<SubActionProcedure>(queryDef, paramList);
        }

        public static BindingList<SubActionProcedure.GetExaminationTestListNQL_Class> GetExaminationTestListNQL(IList<string> OBJECTIDS, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].QueryDefs["GetExaminationTestListNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTIDS", OBJECTIDS);

            return TTReportNqlObject.QueryObjects<SubActionProcedure.GetExaminationTestListNQL_Class>(queryDef, paramList, pi);
        }

        public static BindingList<SubActionProcedure.GetExaminationTestListNQL_Class> GetExaminationTestListNQL(TTObjectContext objectContext, IList<string> OBJECTIDS, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].QueryDefs["GetExaminationTestListNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTIDS", OBJECTIDS);

            return TTReportNqlObject.QueryObjects<SubActionProcedure.GetExaminationTestListNQL_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<SubActionProcedure> GetTestsByEpisode(TTObjectContext objectContext, string OBJECTDEFNAME, string TESTID, string EPISODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].QueryDefs["GetTestsByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTDEFNAME", OBJECTDEFNAME);
            paramList.Add("TESTID", TESTID);
            paramList.Add("EPISODE", EPISODE);

            return ((ITTQuery)objectContext).QueryObjects<SubActionProcedure>(queryDef, paramList);
        }

        public static BindingList<SubActionProcedure> GetAllTestsByEpisode(TTObjectContext objectContext, string EPISODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].QueryDefs["GetAllTestsByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return ((ITTQuery)objectContext).QueryObjects<SubActionProcedure>(queryDef, paramList);
        }

        public static BindingList<SubActionProcedure> GetByEpisodeAndSEP(TTObjectContext objectContext, Guid EPISODE, Guid SEP, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].QueryDefs["GetByEpisodeAndSEP"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);
            paramList.Add("SEP", SEP);

            return ((ITTQuery)objectContext).QueryObjects<SubActionProcedure>(queryDef, paramList, injectionSQL);
        }

    /// <summary>
    /// OLAP ta kullanılmıyor artık
    /// </summary>
        public static BindingList<SubActionProcedure.OLAP_SGKStatisticQuery1_SECount_Class> OLAP_SGKStatisticQuery1_SECount(DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].QueryDefs["OLAP_SGKStatisticQuery1_SECount"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<SubActionProcedure.OLAP_SGKStatisticQuery1_SECount_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// OLAP ta kullanılmıyor artık
    /// </summary>
        public static BindingList<SubActionProcedure.OLAP_SGKStatisticQuery1_SECount_Class> OLAP_SGKStatisticQuery1_SECount(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].QueryDefs["OLAP_SGKStatisticQuery1_SECount"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<SubActionProcedure.OLAP_SGKStatisticQuery1_SECount_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// OLAP ta kullanılmıyor artık
    /// </summary>
        public static BindingList<SubActionProcedure.OLAP_SGKStatisticQuery1_PatientCount_Class> OLAP_SGKStatisticQuery1_PatientCount(DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].QueryDefs["OLAP_SGKStatisticQuery1_PatientCount"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<SubActionProcedure.OLAP_SGKStatisticQuery1_PatientCount_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// OLAP ta kullanılmıyor artık
    /// </summary>
        public static BindingList<SubActionProcedure.OLAP_SGKStatisticQuery1_PatientCount_Class> OLAP_SGKStatisticQuery1_PatientCount(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].QueryDefs["OLAP_SGKStatisticQuery1_PatientCount"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<SubActionProcedure.OLAP_SGKStatisticQuery1_PatientCount_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// OLAP ta kullanılmıyor artık
    /// </summary>
        public static BindingList<SubActionProcedure.OLAP_SGKStatisticQuery2_PatientCount_Class> OLAP_SGKStatisticQuery2_PatientCount(DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].QueryDefs["OLAP_SGKStatisticQuery2_PatientCount"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<SubActionProcedure.OLAP_SGKStatisticQuery2_PatientCount_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// OLAP ta kullanılmıyor artık
    /// </summary>
        public static BindingList<SubActionProcedure.OLAP_SGKStatisticQuery2_PatientCount_Class> OLAP_SGKStatisticQuery2_PatientCount(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].QueryDefs["OLAP_SGKStatisticQuery2_PatientCount"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<SubActionProcedure.OLAP_SGKStatisticQuery2_PatientCount_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<SubActionProcedure> GetByEpisode(TTObjectContext objectContext, string EPISODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].QueryDefs["GetByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return ((ITTQuery)objectContext).QueryObjects<SubActionProcedure>(queryDef, paramList);
        }

    /// <summary>
    /// Diş Muayenesi Sırasında Yapılan Tedavi Sayıları
    /// </summary>
        public static BindingList<SubActionProcedure.OLAP_GetDentalTreatments_Class> OLAP_GetDentalTreatments(string EID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].QueryDefs["OLAP_GetDentalTreatments"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EID", EID);

            return TTReportNqlObject.QueryObjects<SubActionProcedure.OLAP_GetDentalTreatments_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// Diş Muayenesi Sırasında Yapılan Tedavi Sayıları
    /// </summary>
        public static BindingList<SubActionProcedure.OLAP_GetDentalTreatments_Class> OLAP_GetDentalTreatments(TTObjectContext objectContext, string EID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].QueryDefs["OLAP_GetDentalTreatments"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EID", EID);

            return TTReportNqlObject.QueryObjects<SubActionProcedure.OLAP_GetDentalTreatments_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// OLAP ta kullanılmıyor artık
    /// </summary>
        public static BindingList<SubActionProcedure.OLAP_SGKStatisticQuery2_SECount_Class> OLAP_SGKStatisticQuery2_SECount(DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].QueryDefs["OLAP_SGKStatisticQuery2_SECount"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<SubActionProcedure.OLAP_SGKStatisticQuery2_SECount_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// OLAP ta kullanılmıyor artık
    /// </summary>
        public static BindingList<SubActionProcedure.OLAP_SGKStatisticQuery2_SECount_Class> OLAP_SGKStatisticQuery2_SECount(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].QueryDefs["OLAP_SGKStatisticQuery2_SECount"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<SubActionProcedure.OLAP_SGKStatisticQuery2_SECount_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<SubActionProcedure> GetByEpisodeAndMasterPackage(TTObjectContext objectContext, string EPISODE, string MASTERPACKAGESP)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].QueryDefs["GetByEpisodeAndMasterPackage"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);
            paramList.Add("MASTERPACKAGESP", MASTERPACKAGESP);

            return ((ITTQuery)objectContext).QueryObjects<SubActionProcedure>(queryDef, paramList);
        }

        public static BindingList<SubActionProcedure.GetProcedureNameAndCode_Class> GetProcedureNameAndCode(Guid OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].QueryDefs["GetProcedureNameAndCode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<SubActionProcedure.GetProcedureNameAndCode_Class>(queryDef, paramList, pi);
        }

        public static BindingList<SubActionProcedure.GetProcedureNameAndCode_Class> GetProcedureNameAndCode(TTObjectContext objectContext, Guid OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].QueryDefs["GetProcedureNameAndCode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<SubActionProcedure.GetProcedureNameAndCode_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<SubActionProcedure> GetRequestedProceduresOfSubEpisode(TTObjectContext objectContext, DateTime ENDDATE, DateTime STARTDATE, string SUBEPISODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].QueryDefs["GetRequestedProceduresOfSubEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("SUBEPISODE", SUBEPISODE);

            return ((ITTQuery)objectContext).QueryObjects<SubActionProcedure>(queryDef, paramList);
        }

    /// <summary>
    /// Hasta Geçmişi Hizmet ve Tetkikler
    /// </summary>
        public static BindingList<SubActionProcedure.GetOldInfoForRequestedProcedures_Class> GetOldInfoForRequestedProcedures(Guid PATIENT, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].QueryDefs["GetOldInfoForRequestedProcedures"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return TTReportNqlObject.QueryObjects<SubActionProcedure.GetOldInfoForRequestedProcedures_Class>(queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Hasta Geçmişi Hizmet ve Tetkikler
    /// </summary>
        public static BindingList<SubActionProcedure.GetOldInfoForRequestedProcedures_Class> GetOldInfoForRequestedProcedures(TTObjectContext objectContext, Guid PATIENT, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].QueryDefs["GetOldInfoForRequestedProcedures"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return TTReportNqlObject.QueryObjects<SubActionProcedure.GetOldInfoForRequestedProcedures_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SubActionProcedure.GetOldInfoCountForRequestedProcedures_Class> GetOldInfoCountForRequestedProcedures(Guid PATIENT, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].QueryDefs["GetOldInfoCountForRequestedProcedures"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return TTReportNqlObject.QueryObjects<SubActionProcedure.GetOldInfoCountForRequestedProcedures_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SubActionProcedure.GetOldInfoCountForRequestedProcedures_Class> GetOldInfoCountForRequestedProcedures(TTObjectContext objectContext, Guid PATIENT, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].QueryDefs["GetOldInfoCountForRequestedProcedures"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return TTReportNqlObject.QueryObjects<SubActionProcedure.GetOldInfoCountForRequestedProcedures_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Hastaya son X gun kadar surede girilmis iptal durumu disindaki islemleri doner.
    /// </summary>
        public static BindingList<SubActionProcedure.GetSubActionProcedureByTimeInterval_Class> GetSubActionProcedureByTimeInterval(Guid PATIENTID, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].QueryDefs["GetSubActionProcedureByTimeInterval"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENTID", PATIENTID);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<SubActionProcedure.GetSubActionProcedureByTimeInterval_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// Hastaya son X gun kadar surede girilmis iptal durumu disindaki islemleri doner.
    /// </summary>
        public static BindingList<SubActionProcedure.GetSubActionProcedureByTimeInterval_Class> GetSubActionProcedureByTimeInterval(TTObjectContext objectContext, Guid PATIENTID, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].QueryDefs["GetSubActionProcedureByTimeInterval"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENTID", PATIENTID);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<SubActionProcedure.GetSubActionProcedureByTimeInterval_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<SubActionProcedure.DisTetkikIstemRaporTestsNQL2_Class> DisTetkikIstemRaporTestsNQL2(Guid PARAMOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].QueryDefs["DisTetkikIstemRaporTestsNQL2"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMOBJID", PARAMOBJID);

            return TTReportNqlObject.QueryObjects<SubActionProcedure.DisTetkikIstemRaporTestsNQL2_Class>(queryDef, paramList, pi);
        }

        public static BindingList<SubActionProcedure.DisTetkikIstemRaporTestsNQL2_Class> DisTetkikIstemRaporTestsNQL2(TTObjectContext objectContext, Guid PARAMOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].QueryDefs["DisTetkikIstemRaporTestsNQL2"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMOBJID", PARAMOBJID);

            return TTReportNqlObject.QueryObjects<SubActionProcedure.DisTetkikIstemRaporTestsNQL2_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// İstek yapıldığı anda hastaya eklenen işlemleri sayar
    /// </summary>
        public static BindingList<SubActionProcedure.GunSonu_HizmetSayisi_IslemZamani_Class> GunSonu_HizmetSayisi_IslemZamani(DateTime STARTDATE, DateTime ENDDATE, IList<string> SUTKODU, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].QueryDefs["GunSonu_HizmetSayisi_IslemZamani"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("SUTKODU", SUTKODU);

            return TTReportNqlObject.QueryObjects<SubActionProcedure.GunSonu_HizmetSayisi_IslemZamani_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// İstek yapıldığı anda hastaya eklenen işlemleri sayar
    /// </summary>
        public static BindingList<SubActionProcedure.GunSonu_HizmetSayisi_IslemZamani_Class> GunSonu_HizmetSayisi_IslemZamani(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, IList<string> SUTKODU, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].QueryDefs["GunSonu_HizmetSayisi_IslemZamani"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("SUTKODU", SUTKODU);

            return TTReportNqlObject.QueryObjects<SubActionProcedure.GunSonu_HizmetSayisi_IslemZamani_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<SubActionProcedure.GetRequestedProceduresBySubEpisode_Class> GetRequestedProceduresBySubEpisode(string SUBEPISODE, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].QueryDefs["GetRequestedProceduresBySubEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODE", SUBEPISODE);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<SubActionProcedure.GetRequestedProceduresBySubEpisode_Class>(queryDef, paramList, pi);
        }

        public static BindingList<SubActionProcedure.GetRequestedProceduresBySubEpisode_Class> GetRequestedProceduresBySubEpisode(TTObjectContext objectContext, string SUBEPISODE, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].QueryDefs["GetRequestedProceduresBySubEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODE", SUBEPISODE);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<SubActionProcedure.GetRequestedProceduresBySubEpisode_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<SubActionProcedure.GunSonu_HizmetBasvuruSayisi_IslemZamani_Class> GunSonu_HizmetBasvuruSayisi_IslemZamani(DateTime STARTDATE, DateTime ENDDATE, IList<string> SUTKODU, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].QueryDefs["GunSonu_HizmetBasvuruSayisi_IslemZamani"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("SUTKODU", SUTKODU);

            return TTReportNqlObject.QueryObjects<SubActionProcedure.GunSonu_HizmetBasvuruSayisi_IslemZamani_Class>(queryDef, paramList, pi);
        }

        public static BindingList<SubActionProcedure.GunSonu_HizmetBasvuruSayisi_IslemZamani_Class> GunSonu_HizmetBasvuruSayisi_IslemZamani(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, IList<string> SUTKODU, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].QueryDefs["GunSonu_HizmetBasvuruSayisi_IslemZamani"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("SUTKODU", SUTKODU);

            return TTReportNqlObject.QueryObjects<SubActionProcedure.GunSonu_HizmetBasvuruSayisi_IslemZamani_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Tamamlanmış işlemleri gün sonuna sayar
    /// </summary>
        public static BindingList<SubActionProcedure.GunSonu_HizmetSayisi_GerceklesmeZamani_Class> GunSonu_HizmetSayisi_GerceklesmeZamani(DateTime ENDDATE, DateTime STARTDATE, IList<string> SUTKODU, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].QueryDefs["GunSonu_HizmetSayisi_GerceklesmeZamani"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("SUTKODU", SUTKODU);

            return TTReportNqlObject.QueryObjects<SubActionProcedure.GunSonu_HizmetSayisi_GerceklesmeZamani_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// Tamamlanmış işlemleri gün sonuna sayar
    /// </summary>
        public static BindingList<SubActionProcedure.GunSonu_HizmetSayisi_GerceklesmeZamani_Class> GunSonu_HizmetSayisi_GerceklesmeZamani(TTObjectContext objectContext, DateTime ENDDATE, DateTime STARTDATE, IList<string> SUTKODU, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].QueryDefs["GunSonu_HizmetSayisi_GerceklesmeZamani"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("SUTKODU", SUTKODU);

            return TTReportNqlObject.QueryObjects<SubActionProcedure.GunSonu_HizmetSayisi_GerceklesmeZamani_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<SubActionProcedure.GunSonu_HizmetSayisi_Class> GunSonu_HizmetSayisi(DateTime ENDDATE, DateTime STARTDATE, IList<string> SUTKODU, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].QueryDefs["GunSonu_HizmetSayisi"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("SUTKODU", SUTKODU);

            return TTReportNqlObject.QueryObjects<SubActionProcedure.GunSonu_HizmetSayisi_Class>(queryDef, paramList, pi);
        }

        public static BindingList<SubActionProcedure.GunSonu_HizmetSayisi_Class> GunSonu_HizmetSayisi(TTObjectContext objectContext, DateTime ENDDATE, DateTime STARTDATE, IList<string> SUTKODU, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].QueryDefs["GunSonu_HizmetSayisi"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("SUTKODU", SUTKODU);

            return TTReportNqlObject.QueryObjects<SubActionProcedure.GunSonu_HizmetSayisi_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<SubActionProcedure> GetTestsByOutpatientEpisode(TTObjectContext objectContext, DateTime MINDATE, string PATIENTID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].QueryDefs["GetTestsByOutpatientEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MINDATE", MINDATE);
            paramList.Add("PATIENTID", PATIENTID);

            return ((ITTQuery)objectContext).QueryObjects<SubActionProcedure>(queryDef, paramList);
        }

        public static BindingList<SubActionProcedure.GetProcedureForDP_Class> GetProcedureForDP(DateTime FIRSTDATE, DateTime LASTDATE, Guid DOCTOR, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].QueryDefs["GetProcedureForDP"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);
            paramList.Add("DOCTOR", DOCTOR);

            return TTReportNqlObject.QueryObjects<SubActionProcedure.GetProcedureForDP_Class>(queryDef, paramList, pi);
        }

        public static BindingList<SubActionProcedure.GetProcedureForDP_Class> GetProcedureForDP(TTObjectContext objectContext, DateTime FIRSTDATE, DateTime LASTDATE, Guid DOCTOR, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].QueryDefs["GetProcedureForDP"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);
            paramList.Add("DOCTOR", DOCTOR);

            return TTReportNqlObject.QueryObjects<SubActionProcedure.GetProcedureForDP_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<SubActionProcedure.GetProcedureCountByDateTimeIntervalByPatient_Class> GetProcedureCountByDateTimeIntervalByPatient(DateTime STARTDATE, DateTime ENDDATE, string PATIENTID, string PROCEDUREOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].QueryDefs["GetProcedureCountByDateTimeIntervalByPatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("PATIENTID", PATIENTID);
            paramList.Add("PROCEDUREOBJECTID", PROCEDUREOBJECTID);

            return TTReportNqlObject.QueryObjects<SubActionProcedure.GetProcedureCountByDateTimeIntervalByPatient_Class>(queryDef, paramList, pi);
        }

        public static BindingList<SubActionProcedure.GetProcedureCountByDateTimeIntervalByPatient_Class> GetProcedureCountByDateTimeIntervalByPatient(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, string PATIENTID, string PROCEDUREOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].QueryDefs["GetProcedureCountByDateTimeIntervalByPatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("PATIENTID", PATIENTID);
            paramList.Add("PROCEDUREOBJECTID", PROCEDUREOBJECTID);

            return TTReportNqlObject.QueryObjects<SubActionProcedure.GetProcedureCountByDateTimeIntervalByPatient_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<SubActionProcedure> GetSAPForDP(TTObjectContext objectContext, Guid DOCTOR, DateTime FIRSTDATE, DateTime LASTDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].QueryDefs["GetSAPForDP"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DOCTOR", DOCTOR);
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return ((ITTQuery)objectContext).QueryObjects<SubActionProcedure>(queryDef, paramList);
        }

        public static BindingList<SubActionProcedure.GunSonu_HizmetBasvuruSayisi_GerceklesmeZamani_Class> GunSonu_HizmetBasvuruSayisi_GerceklesmeZamani(DateTime ENDDATE, DateTime STARTDATE, IList<string> SUTKODU, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].QueryDefs["GunSonu_HizmetBasvuruSayisi_GerceklesmeZamani"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("SUTKODU", SUTKODU);

            return TTReportNqlObject.QueryObjects<SubActionProcedure.GunSonu_HizmetBasvuruSayisi_GerceklesmeZamani_Class>(queryDef, paramList, pi);
        }

        public static BindingList<SubActionProcedure.GunSonu_HizmetBasvuruSayisi_GerceklesmeZamani_Class> GunSonu_HizmetBasvuruSayisi_GerceklesmeZamani(TTObjectContext objectContext, DateTime ENDDATE, DateTime STARTDATE, IList<string> SUTKODU, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].QueryDefs["GunSonu_HizmetBasvuruSayisi_GerceklesmeZamani"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("SUTKODU", SUTKODU);

            return TTReportNqlObject.QueryObjects<SubActionProcedure.GunSonu_HizmetBasvuruSayisi_GerceklesmeZamani_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<SubActionProcedure.GetProceduresByDate_Class> GetProceduresByDate(DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].QueryDefs["GetProceduresByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<SubActionProcedure.GetProceduresByDate_Class>(queryDef, paramList, pi);
        }

        public static BindingList<SubActionProcedure.GetProceduresByDate_Class> GetProceduresByDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].QueryDefs["GetProceduresByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<SubActionProcedure.GetProceduresByDate_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<SubActionProcedure.GetSubactionProceduresBySubepisode_Class> GetSubactionProceduresBySubepisode(Guid SUBEPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].QueryDefs["GetSubactionProceduresBySubepisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODE", SUBEPISODE);

            return TTReportNqlObject.QueryObjects<SubActionProcedure.GetSubactionProceduresBySubepisode_Class>(queryDef, paramList, pi);
        }

        public static BindingList<SubActionProcedure.GetSubactionProceduresBySubepisode_Class> GetSubactionProceduresBySubepisode(TTObjectContext objectContext, Guid SUBEPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].QueryDefs["GetSubactionProceduresBySubepisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODE", SUBEPISODE);

            return TTReportNqlObject.QueryObjects<SubActionProcedure.GetSubactionProceduresBySubepisode_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<SubActionProcedure.GetRequestedProceduresByEpisode_Class> GetRequestedProceduresByEpisode(string EPISODE, DateTime STARTDATE, DateTime ENDDATE, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].QueryDefs["GetRequestedProceduresByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<SubActionProcedure.GetRequestedProceduresByEpisode_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SubActionProcedure.GetRequestedProceduresByEpisode_Class> GetRequestedProceduresByEpisode(TTObjectContext objectContext, string EPISODE, DateTime STARTDATE, DateTime ENDDATE, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].QueryDefs["GetRequestedProceduresByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<SubActionProcedure.GetRequestedProceduresByEpisode_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SubActionProcedure> GetRequestedProceduresOfEpisode(TTObjectContext objectContext, string EPISODE, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].QueryDefs["GetRequestedProceduresOfEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<SubActionProcedure>(queryDef, paramList);
        }

        public static BindingList<SubActionProcedure.GetSubactionProceduresByMasterSP_Class> GetSubactionProceduresByMasterSP(Guid MASTERSUBACTIONPROCEDURE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].QueryDefs["GetSubactionProceduresByMasterSP"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MASTERSUBACTIONPROCEDURE", MASTERSUBACTIONPROCEDURE);

            return TTReportNqlObject.QueryObjects<SubActionProcedure.GetSubactionProceduresByMasterSP_Class>(queryDef, paramList, pi);
        }

        public static BindingList<SubActionProcedure.GetSubactionProceduresByMasterSP_Class> GetSubactionProceduresByMasterSP(TTObjectContext objectContext, Guid MASTERSUBACTIONPROCEDURE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].QueryDefs["GetSubactionProceduresByMasterSP"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MASTERSUBACTIONPROCEDURE", MASTERSUBACTIONPROCEDURE);

            return TTReportNqlObject.QueryObjects<SubActionProcedure.GetSubactionProceduresByMasterSP_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<SubActionProcedure.GetInjectionList_Class> GetInjectionList(DateTime STARTDATE, DateTime ENDDATE, IList<string> SUTCODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].QueryDefs["GetInjectionList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("SUTCODE", SUTCODE);

            return TTReportNqlObject.QueryObjects<SubActionProcedure.GetInjectionList_Class>(queryDef, paramList, pi);
        }

        public static BindingList<SubActionProcedure.GetInjectionList_Class> GetInjectionList(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, IList<string> SUTCODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].QueryDefs["GetInjectionList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("SUTCODE", SUTCODE);

            return TTReportNqlObject.QueryObjects<SubActionProcedure.GetInjectionList_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// İşlem No
    /// </summary>
        public TTSequence ID
        {
            get { return GetSequence("ID"); }
        }

    /// <summary>
    /// Ücret olusturup olusturmama flag ı
    /// </summary>
        public bool? Eligible
        {
            get { return (bool?)this["ELIGIBLE"]; }
            set { this["ELIGIBLE"] = value; }
        }

    /// <summary>
    /// İşlem İptal Sebebi
    /// </summary>
        public string ReasonOfCancel
        {
            get { return (string)this["REASONOFCANCEL"]; }
            set { this["REASONOFCANCEL"] = value; }
        }

    /// <summary>
    /// İş Listesi Tarihi
    /// </summary>
        public DateTime? WorkListDate
        {
            get { return (DateTime?)this["WORKLISTDATE"]; }
            set { this["WORKLISTDATE"] = value; }
        }

    /// <summary>
    /// Ücretlendirilme Tarihi
    /// </summary>
        public DateTime? PricingDate
        {
            get { return (DateTime?)this["PRICINGDATE"]; }
            set { this["PRICINGDATE"] = value; }
        }

    /// <summary>
    /// Miktar
    /// </summary>
        public long? Amount
        {
            get { return (long?)this["AMOUNT"]; }
            set { this["AMOUNT"] = value; }
        }

    /// <summary>
    /// İşlem Tarihi
    /// </summary>
        public DateTime? ActionDate
        {
            get { return (DateTime?)this["ACTIONDATE"]; }
            set { this["ACTIONDATE"] = value; }
        }

    /// <summary>
    /// Acil
    /// </summary>
        public bool? Emergency
        {
            get { return (bool?)this["EMERGENCY"]; }
            set { this["EMERGENCY"] = value; }
        }

    /// <summary>
    /// Aktif
    /// </summary>
        public bool? Active
        {
            get { return (bool?)this["ACTIVE"]; }
            set { this["ACTIVE"] = value; }
        }

    /// <summary>
    /// Olap İşlem Tarihi
    /// </summary>
        public DateTime? OlapDate
        {
            get { return (DateTime?)this["OLAPDATE"]; }
            set { this["OLAPDATE"] = value; }
        }

    /// <summary>
    /// Olap Güncelleme Tarihi
    /// </summary>
        public DateTime? OlapLastUpdate
        {
            get { return (DateTime?)this["OLAPLASTUPDATE"]; }
            set { this["OLAPLASTUPDATE"] = value; }
        }

    /// <summary>
    /// Ücretlendi mi
    /// </summary>
        public bool? AccountOperationDone
        {
            get { return (bool?)this["ACCOUNTOPERATIONDONE"]; }
            set { this["ACCOUNTOPERATIONDONE"] = value; }
        }

        public bool? AccTrxsMultipliedByAmount
        {
            get { return (bool?)this["ACCTRXSMULTIPLIEDBYAMOUNT"]; }
            set { this["ACCTRXSMULTIPLIEDBYAMOUNT"] = value; }
        }

        public bool? PatientPay
        {
            get { return (bool?)this["PATIENTPAY"]; }
            set { this["PATIENTPAY"] = value; }
        }

    /// <summary>
    /// Ek Açıklama
    /// </summary>
        public string ExtraDescription
        {
            get { return (string)this["EXTRADESCRIPTION"]; }
            set { this["EXTRADESCRIPTION"] = value; }
        }

    /// <summary>
    /// SUT Kural Kontrol Durumu
    /// </summary>
        public SutRuleEngineStatus? SUTRuleStatus
        {
            get { return (SutRuleEngineStatus?)(int?)this["SUTRULESTATUS"]; }
            set { this["SUTRULESTATUS"] = value; }
        }

    /// <summary>
    /// İndirim Oranı
    /// </summary>
        public double? DiscountPercent
        {
            get { return (double?)this["DISCOUNTPERCENT"]; }
            set { this["DISCOUNTPERCENT"] = value; }
        }

    /// <summary>
    /// İşlemin Gerçekleştiği Zaman
    /// </summary>
        public DateTime? PerformedDate
        {
            get { return (DateTime?)this["PERFORMEDDATE"]; }
            set { this["PERFORMEDDATE"] = value; }
        }

    /// <summary>
    /// Oluşturulma Tarihi
    /// </summary>
        public DateTime? CreationDate
        {
            get { return (DateTime?)this["CREATIONDATE"]; }
            set { this["CREATIONDATE"] = value; }
        }

    /// <summary>
    /// İşlemin aktarımla gelip gelmediğine bakar
    /// </summary>
        public bool? IsOldAction
        {
            get { return (bool?)this["ISOLDACTION"]; }
            set { this["ISOLDACTION"] = value; }
        }

    /// <summary>
    /// Medula Rapor Numarası
    /// </summary>
        public string MedulaReportNo
        {
            get { return (string)this["MEDULAREPORTNO"]; }
            set { this["MEDULAREPORTNO"] = value; }
        }

    /// <summary>
    /// Sag / Sol Bilgisi
    /// </summary>
        public RightLeftEnum? RightLeftInformation
        {
            get { return (RightLeftEnum?)(int?)this["RIGHTLEFTINFORMATION"]; }
            set { this["RIGHTLEFTINFORMATION"] = value; }
        }

        public Episode Episode
        {
            get { return (Episode)((ITTObject)this).GetParent("EPISODE"); }
            set { this["EPISODE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// İşlemin Yapıldığı Uzmanlık Dalı
    /// </summary>
        public SpecialityDefinition ProcedureSpeciality
        {
            get { return (SpecialityDefinition)((ITTObject)this).GetParent("PROCEDURESPECIALITY"); }
            set { this["PROCEDURESPECIALITY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public EpisodeAction EpisodeAction
        {
            get { return (EpisodeAction)((ITTObject)this).GetParent("EPISODEACTION"); }
            set { this["EPISODEACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public PackageDefinition PackageDefinition
        {
            get { return (PackageDefinition)((ITTObject)this).GetParent("PACKAGEDEFINITION"); }
            set { this["PACKAGEDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SubActionProcedure MasterSubActionProcedure
        {
            get { return (SubActionProcedure)((ITTObject)this).GetParent("MASTERSUBACTIONPROCEDURE"); }
            set { this["MASTERSUBACTIONPROCEDURE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SubActionProcedure MasterPackgSubActionProcedure
        {
            get { return (SubActionProcedure)((ITTObject)this).GetParent("MASTERPACKGSUBACTIONPROCEDURE"); }
            set { this["MASTERPACKGSUBACTIONPROCEDURE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Medula Hasta Kabul-Hizmetler
    /// </summary>
        public PatientMedulaHastaKabul MedulaHastaKabul
        {
            get { return (PatientMedulaHastaKabul)((ITTObject)this).GetParent("MEDULAHASTAKABUL"); }
            set { this["MEDULAHASTAKABUL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SubEpisode SubEpisode
        {
            get { return (SubEpisode)((ITTObject)this).GetParent("SUBEPISODE"); }
            set { this["SUBEPISODE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// İşlem
    /// </summary>
        public ProcedureDefinition ProcedureObject
        {
            get { return (ProcedureDefinition)((ITTObject)this).GetParent("PROCEDUREOBJECT"); }
            set { this["PROCEDUREOBJECT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// İşlemi Yapan Doktor
    /// </summary>
        public ResUser ProcedureDoctor
        {
            get { return (ResUser)((ITTObject)this).GetParent("PROCEDUREDOCTOR"); }
            set { this["PROCEDUREDOCTOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// İşlemi gerçekleştiren teknisyen, operator vs. ilişkisi.
    /// </summary>
        public ResUser ProcedureByUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("PROCEDUREBYUSER"); }
            set { this["PROCEDUREBYUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// İşlemi İsteyen Kullanıcı
    /// </summary>
        public ResUser RequestedByUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("REQUESTEDBYUSER"); }
            set { this["REQUESTEDBYUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSTekrarTetkikIstemGerekcesi ReasonForRepetition
        {
            get { return (SKRSTekrarTetkikIstemGerekcesi)((ITTObject)this).GetParent("REASONFORREPETITION"); }
            set { this["REASONFORREPETITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateAppointmentsCollection()
        {
            _Appointments = new Appointment.ChildAppointmentCollection(this, new Guid("345ab904-9d1d-4854-9067-106a7f3f88f6"));
            ((ITTChildObjectCollection)_Appointments).GetChildren();
        }

        protected Appointment.ChildAppointmentCollection _Appointments = null;
        public Appointment.ChildAppointmentCollection Appointments
        {
            get
            {
                if (_Appointments == null)
                    CreateAppointmentsCollection();
                return _Appointments;
            }
        }

        virtual protected void CreatePackageTransferCollection()
        {
            _PackageTransfer = new PackageTransfer.ChildPackageTransferCollection(this, new Guid("8032b599-9811-4c82-9e39-26a7314375f5"));
            ((ITTChildObjectCollection)_PackageTransfer).GetChildren();
        }

        protected PackageTransfer.ChildPackageTransferCollection _PackageTransfer = null;
    /// <summary>
    /// Child collection for Hizmet hareketine ilişki
    /// </summary>
        public PackageTransfer.ChildPackageTransferCollection PackageTransfer
        {
            get
            {
                if (_PackageTransfer == null)
                    CreatePackageTransferCollection();
                return _PackageTransfer;
            }
        }

        virtual protected void CreateChildSubActionProcedureCollectionViews()
        {
        }

        virtual protected void CreateChildSubActionProcedureCollection()
        {
            _ChildSubActionProcedure = new SubActionProcedure.ChildSubActionProcedureCollection(this, new Guid("0d2dd25a-d73a-449d-9401-690e43dfa763"));
            CreateChildSubActionProcedureCollectionViews();
            ((ITTChildObjectCollection)_ChildSubActionProcedure).GetChildren();
        }

        protected SubActionProcedure.ChildSubActionProcedureCollection _ChildSubActionProcedure = null;
        public SubActionProcedure.ChildSubActionProcedureCollection ChildSubActionProcedure
        {
            get
            {
                if (_ChildSubActionProcedure == null)
                    CreateChildSubActionProcedureCollection();
                return _ChildSubActionProcedure;
            }
        }

        virtual protected void CreateAccountTransactionsCollection()
        {
            _AccountTransactions = new AccountTransaction.ChildAccountTransactionCollection(this, new Guid("ca079765-4f78-4cc4-97d3-42da76e1763c"));
            ((ITTChildObjectCollection)_AccountTransactions).GetChildren();
        }

        protected AccountTransaction.ChildAccountTransactionCollection _AccountTransactions = null;
    /// <summary>
    /// Child collection for SubActionProcedure e ilişki
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

        virtual protected void CreateAppointmentWithoutResourcesCollection()
        {
            _AppointmentWithoutResources = new AppointmentWithoutResource.ChildAppointmentWithoutResourceCollection(this, new Guid("db697568-0f04-44fe-85c3-a2edee979ef7"));
            ((ITTChildObjectCollection)_AppointmentWithoutResources).GetChildren();
        }

        protected AppointmentWithoutResource.ChildAppointmentWithoutResourceCollection _AppointmentWithoutResources = null;
        public AppointmentWithoutResource.ChildAppointmentWithoutResourceCollection AppointmentWithoutResources
        {
            get
            {
                if (_AppointmentWithoutResources == null)
                    CreateAppointmentWithoutResourcesCollection();
                return _AppointmentWithoutResources;
            }
        }

        virtual protected void CreateSubActionMaterialCollectionViews()
        {
            _UsedMaterials = new BaseTreatmentMaterial.ChildBaseTreatmentMaterialCollection(_SubActionMaterial, "UsedMaterials");
        }

        virtual protected void CreateSubActionMaterialCollection()
        {
            _SubActionMaterial = new SubActionMaterial.ChildSubActionMaterialCollection(this, new Guid("c448105b-9e0f-478d-a716-ced70385755d"));
            CreateSubActionMaterialCollectionViews();
            ((ITTChildObjectCollection)_SubActionMaterial).GetChildren();
        }

        protected SubActionMaterial.ChildSubActionMaterialCollection _SubActionMaterial = null;
        public SubActionMaterial.ChildSubActionMaterialCollection SubActionMaterial
        {
            get
            {
                if (_SubActionMaterial == null)
                    CreateSubActionMaterialCollection();
                return _SubActionMaterial;
            }
        }

        private BaseTreatmentMaterial.ChildBaseTreatmentMaterialCollection _UsedMaterials = null;
        public BaseTreatmentMaterial.ChildBaseTreatmentMaterialCollection UsedMaterials
        {
            get
            {
                if (_SubActionMaterial == null)
                    CreateSubActionMaterialCollection();
                return _UsedMaterials;
            }            
        }

        virtual protected void CreateTransferFromPackSubActProcsCollection()
        {
            _TransferFromPackSubActProcs = new TransferFromPackSubActProcs.ChildTransferFromPackSubActProcsCollection(this, new Guid("074ab2a5-69c2-4c38-a38a-f0e34d14a363"));
            ((ITTChildObjectCollection)_TransferFromPackSubActProcs).GetChildren();
        }

        protected TransferFromPackSubActProcs.ChildTransferFromPackSubActProcsCollection _TransferFromPackSubActProcs = null;
    /// <summary>
    /// Child collection for Hizmet hareketi ile ilişki
    /// </summary>
        public TransferFromPackSubActProcs.ChildTransferFromPackSubActProcsCollection TransferFromPackSubActProcs
        {
            get
            {
                if (_TransferFromPackSubActProcs == null)
                    CreateTransferFromPackSubActProcsCollection();
                return _TransferFromPackSubActProcs;
            }
        }

        virtual protected void CreatePackageTransferProtocolSubActionPackagesCollection()
        {
            _PackageTransferProtocolSubActionPackages = new PackageTransferProtocolSubActionPackages.ChildPackageTransferProtocolSubActionPackagesCollection(this, new Guid("7eae6d17-6d7e-4c61-a9ee-717b5cab3c30"));
            ((ITTChildObjectCollection)_PackageTransferProtocolSubActionPackages).GetChildren();
        }

        protected PackageTransferProtocolSubActionPackages.ChildPackageTransferProtocolSubActionPackagesCollection _PackageTransferProtocolSubActionPackages = null;
    /// <summary>
    /// Child collection for Paket Hareketi ile ilişki
    /// </summary>
        public PackageTransferProtocolSubActionPackages.ChildPackageTransferProtocolSubActionPackagesCollection PackageTransferProtocolSubActionPackages
        {
            get
            {
                if (_PackageTransferProtocolSubActionPackages == null)
                    CreatePackageTransferProtocolSubActionPackagesCollection();
                return _PackageTransferProtocolSubActionPackages;
            }
        }

        virtual protected void CreatePackageTransferProtocolSubActionProceduresCollection()
        {
            _PackageTransferProtocolSubActionProcedures = new PackageTransferProtocolSubActionProcedures.ChildPackageTransferProtocolSubActionProceduresCollection(this, new Guid("8978176a-06b4-4d59-a5e2-ac5c23db9abd"));
            ((ITTChildObjectCollection)_PackageTransferProtocolSubActionProcedures).GetChildren();
        }

        protected PackageTransferProtocolSubActionProcedures.ChildPackageTransferProtocolSubActionProceduresCollection _PackageTransferProtocolSubActionProcedures = null;
    /// <summary>
    /// Child collection for Hizmet hareketi ile ilişki
    /// </summary>
        public PackageTransferProtocolSubActionProcedures.ChildPackageTransferProtocolSubActionProceduresCollection PackageTransferProtocolSubActionProcedures
        {
            get
            {
                if (_PackageTransferProtocolSubActionProcedures == null)
                    CreatePackageTransferProtocolSubActionProceduresCollection();
                return _PackageTransferProtocolSubActionProcedures;
            }
        }

        virtual protected void CreatePriceUpdatingProcedureCollection()
        {
            _PriceUpdatingProcedure = new PriceUpdatingSubActionProcedure.ChildPriceUpdatingSubActionProcedureCollection(this, new Guid("f4867939-bf3f-471e-8170-e132df294819"));
            ((ITTChildObjectCollection)_PriceUpdatingProcedure).GetChildren();
        }

        protected PriceUpdatingSubActionProcedure.ChildPriceUpdatingSubActionProcedureCollection _PriceUpdatingProcedure = null;
    /// <summary>
    /// Child collection for Hizmet hareketi ile ilişki
    /// </summary>
        public PriceUpdatingSubActionProcedure.ChildPriceUpdatingSubActionProcedureCollection PriceUpdatingProcedure
        {
            get
            {
                if (_PriceUpdatingProcedure == null)
                    CreatePriceUpdatingProcedureCollection();
                return _PriceUpdatingProcedure;
            }
        }

        virtual protected void CreateSubActionProcPricingDetCollection()
        {
            _SubActionProcPricingDet = new SubActionProcPricingDet.ChildSubActionProcPricingDetCollection(this, new Guid("4143d906-6f8c-4f26-892f-c36e94545f65"));
            ((ITTChildObjectCollection)_SubActionProcPricingDet).GetChildren();
        }

        protected SubActionProcPricingDet.ChildSubActionProcPricingDetCollection _SubActionProcPricingDet = null;
        public SubActionProcPricingDet.ChildSubActionProcPricingDetCollection SubActionProcPricingDet
        {
            get
            {
                if (_SubActionProcPricingDet == null)
                    CreateSubActionProcPricingDetCollection();
                return _SubActionProcPricingDet;
            }
        }

        virtual protected void CreateDPDetailsCollection()
        {
            _DPDetails = new DPDetail.ChildDPDetailCollection(this, new Guid("155d6000-00d3-4329-8443-c26b209f0652"));
            ((ITTChildObjectCollection)_DPDetails).GetChildren();
        }

        protected DPDetail.ChildDPDetailCollection _DPDetails = null;
        public DPDetail.ChildDPDetailCollection DPDetails
        {
            get
            {
                if (_DPDetails == null)
                    CreateDPDetailsCollection();
                return _DPDetails;
            }
        }

        virtual protected void CreateSubVitalSignsCollection()
        {
            _SubVitalSigns = new VitalSign.ChildVitalSignCollection(this, new Guid("cceb4636-e44c-4eb8-84bb-b50c304f2ead"));
            ((ITTChildObjectCollection)_SubVitalSigns).GetChildren();
        }

        protected VitalSign.ChildVitalSignCollection _SubVitalSigns = null;
        public VitalSign.ChildVitalSignCollection SubVitalSigns
        {
            get
            {
                if (_SubVitalSigns == null)
                    CreateSubVitalSignsCollection();
                return _SubVitalSigns;
            }
        }

        protected SubActionProcedure(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SubActionProcedure(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SubActionProcedure(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SubActionProcedure(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SubActionProcedure(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SUBACTIONPROCEDURE", dataRow) { }
        protected SubActionProcedure(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SUBACTIONPROCEDURE", dataRow, isImported) { }
        public SubActionProcedure(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SubActionProcedure(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SubActionProcedure() : base() { }

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
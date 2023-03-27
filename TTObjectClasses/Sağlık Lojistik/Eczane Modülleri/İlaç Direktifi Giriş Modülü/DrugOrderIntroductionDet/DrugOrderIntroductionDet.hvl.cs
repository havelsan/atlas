
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DrugOrderIntroductionDet")] 

    public  partial class DrugOrderIntroductionDet : TTObject
    {
        public class DrugOrderIntroductionDetList : TTObjectCollection<DrugOrderIntroductionDet> { }
                    
        public class ChildDrugOrderIntroductionDetCollection : TTObject.TTChildObjectCollection<DrugOrderIntroductionDet>
        {
            public ChildDrugOrderIntroductionDetCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDrugOrderIntroductionDetCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetDrugOrderIntroductionDetByPatientId_Class : TTReportNqlObject 
        {
            public DateTime? Date
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].AllPropertyDefs["PLANNEDSTARTTIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Material
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIAL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Materialid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MATERIALID"]);
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

            public string Doctor
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCTOR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DrugUsageTypeEnum? DrugUsageType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DRUGUSAGETYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERINTRODUCTIONDET"].AllPropertyDefs["DRUGUSAGETYPE"].DataType;
                    return (DrugUsageTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public double? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERINTRODUCTIONDET"].AllPropertyDefs["DOSEAMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ExpirationDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXPIRATIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].AllPropertyDefs["EXPIRATIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetDrugOrderIntroductionDetByPatientId_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDrugOrderIntroductionDetByPatientId_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDrugOrderIntroductionDetByPatientId_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDrugOrderIntroductionDetByEpisodeAndDate_Class : TTReportNqlObject 
        {
            public Guid? Drugorderintroductiondetid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DRUGORDERINTRODUCTIONDETID"]);
                }
            }

            public long? Drugorderintroductionid
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DRUGORDERINTRODUCTIONID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERINTRODUCTION"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public Guid? Drugorderid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DRUGORDERID"]);
                }
            }

            public Guid? Material
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MATERIAL"]);
                }
            }

            public FrequencyEnum? Frequency
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FREQUENCY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].AllPropertyDefs["FREQUENCY"].DataType;
                    return (FrequencyEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public double? DoseAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOSEAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].AllPropertyDefs["DOSEAMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public int? Drugorderday
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DRUGORDERDAY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].AllPropertyDefs["DAY"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public DateTime? Orderdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDERDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].AllPropertyDefs["PLANNEDSTARTTIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Drugordertype
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DRUGORDERTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].AllPropertyDefs["TYPE"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public Object Inpatientpresdetailcount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["INPATIENTPRESDETAILCOUNT"]);
                }
            }

            public bool? NextDayOrder
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NEXTDAYORDER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERINTRODUCTIONDET"].AllPropertyDefs["NEXTDAYORDER"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string UsageNote
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["USAGENOTE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].AllPropertyDefs["USAGENOTE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetDrugOrderIntroductionDetByEpisodeAndDate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDrugOrderIntroductionDetByEpisodeAndDate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDrugOrderIntroductionDetByEpisodeAndDate_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDrugOrderGridViewModelQuery_Class : TTReportNqlObject 
        {
            public Guid? Drugorderintroductiondetid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DRUGORDERINTRODUCTIONDETID"]);
                }
            }

            public long? Drugorderintroductionid
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DRUGORDERINTRODUCTIONID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERINTRODUCTION"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public Guid? Drugorderid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DRUGORDERID"]);
                }
            }

            public Guid? Material
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MATERIAL"]);
                }
            }

            public RefactoredFrequencyEnum? Frequency
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FREQUENCY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HOSPITALTIMESCHEDULE"].AllPropertyDefs["FREQUENCY"].DataType;
                    return (RefactoredFrequencyEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public Guid? Hospitaltimescheduleid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["HOSPITALTIMESCHEDULEID"]);
                }
            }

            public double? DoseAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOSEAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].AllPropertyDefs["DOSEAMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public int? Drugorderday
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DRUGORDERDAY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].AllPropertyDefs["DAY"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public DateTime? Orderdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDERDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].AllPropertyDefs["PLANNEDSTARTTIME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].AllPropertyDefs["CREATIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? CurrentStateDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENTSTATEDEFID"]);
                }
            }

            public string UsageNote
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["USAGENOTE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].AllPropertyDefs["USAGENOTE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? IsUpgraded
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISUPGRADED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].AllPropertyDefs["ISUPGRADED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? PatientOwnDrug
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTOWNDRUG"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERINTRODUCTIONDET"].AllPropertyDefs["PATIENTOWNDRUG"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DrugUsageTypeEnum? DrugUsageType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DRUGUSAGETYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERINTRODUCTIONDET"].AllPropertyDefs["DRUGUSAGETYPE"].DataType;
                    return (DrugUsageTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public DrugOrderTypeEnum? DrugOrderType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DRUGORDERTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERINTRODUCTIONDET"].AllPropertyDefs["DRUGORDERTYPE"].DataType;
                    return (DrugOrderTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public bool? CaseOfNeed
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CASEOFNEED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERINTRODUCTIONDET"].AllPropertyDefs["CASEOFNEED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public Guid? ParentDrugOrder
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PARENTDRUGORDER"]);
                }
            }

            public bool? IsImmediate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISIMMEDIATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERINTRODUCTIONDET"].AllPropertyDefs["ISIMMEDIATE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? IsCV
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISCV"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERINTRODUCTIONDET"].AllPropertyDefs["ISCV"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? IsTeleOrder
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISTELEORDER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERINTRODUCTIONDET"].AllPropertyDefs["ISTELEORDER"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public GetDrugOrderGridViewModelQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDrugOrderGridViewModelQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDrugOrderGridViewModelQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDrugOrderGridViewModelByPatient_Class : TTReportNqlObject 
        {
            public Guid? Drugorderintroductiondetid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DRUGORDERINTRODUCTIONDETID"]);
                }
            }

            public long? Drugorderintroductionid
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DRUGORDERINTRODUCTIONID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERINTRODUCTION"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public Guid? Drugorderid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DRUGORDERID"]);
                }
            }

            public Guid? Material
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MATERIAL"]);
                }
            }

            public RefactoredFrequencyEnum? Frequency
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FREQUENCY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HOSPITALTIMESCHEDULE"].AllPropertyDefs["FREQUENCY"].DataType;
                    return (RefactoredFrequencyEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public Guid? Hospitaltimescheduleid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["HOSPITALTIMESCHEDULEID"]);
                }
            }

            public string Hospitaltimeschedulename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HOSPITALTIMESCHEDULENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HOSPITALTIMESCHEDULE"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public double? DoseAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOSEAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].AllPropertyDefs["DOSEAMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public int? Drugorderday
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DRUGORDERDAY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].AllPropertyDefs["DAY"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public DateTime? Orderdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDERDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].AllPropertyDefs["PLANNEDSTARTTIME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].AllPropertyDefs["CREATIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? CurrentStateDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENTSTATEDEFID"]);
                }
            }

            public string UsageNote
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["USAGENOTE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].AllPropertyDefs["USAGENOTE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? IsUpgraded
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISUPGRADED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].AllPropertyDefs["ISUPGRADED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? PatientOwnDrug
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTOWNDRUG"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERINTRODUCTIONDET"].AllPropertyDefs["PATIENTOWNDRUG"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DrugUsageTypeEnum? DrugUsageType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DRUGUSAGETYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERINTRODUCTIONDET"].AllPropertyDefs["DRUGUSAGETYPE"].DataType;
                    return (DrugUsageTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public DrugOrderTypeEnum? DrugOrderType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DRUGORDERTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERINTRODUCTIONDET"].AllPropertyDefs["DRUGORDERTYPE"].DataType;
                    return (DrugOrderTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public bool? CaseOfNeed
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CASEOFNEED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERINTRODUCTIONDET"].AllPropertyDefs["CASEOFNEED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public Guid? ParentDrugOrder
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PARENTDRUGORDER"]);
                }
            }

            public bool? IsImmediate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISIMMEDIATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERINTRODUCTIONDET"].AllPropertyDefs["ISIMMEDIATE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string Clinik
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CLINIK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Doctor
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCTOR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public GetDrugOrderGridViewModelByPatient_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDrugOrderGridViewModelByPatient_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDrugOrderGridViewModelByPatient_Class() : base() { }
        }

        public static BindingList<DrugOrderIntroductionDet.GetDrugOrderIntroductionDetByPatientId_Class> GetDrugOrderIntroductionDetByPatientId(Guid PATIENT, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERINTRODUCTIONDET"].QueryDefs["GetDrugOrderIntroductionDetByPatientId"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return TTReportNqlObject.QueryObjects<DrugOrderIntroductionDet.GetDrugOrderIntroductionDetByPatientId_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DrugOrderIntroductionDet.GetDrugOrderIntroductionDetByPatientId_Class> GetDrugOrderIntroductionDetByPatientId(TTObjectContext objectContext, Guid PATIENT, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERINTRODUCTIONDET"].QueryDefs["GetDrugOrderIntroductionDetByPatientId"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return TTReportNqlObject.QueryObjects<DrugOrderIntroductionDet.GetDrugOrderIntroductionDetByPatientId_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DrugOrderIntroductionDet.GetDrugOrderIntroductionDetByEpisodeAndDate_Class> GetDrugOrderIntroductionDetByEpisodeAndDate(Guid EPISODE, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERINTRODUCTIONDET"].QueryDefs["GetDrugOrderIntroductionDetByEpisodeAndDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<DrugOrderIntroductionDet.GetDrugOrderIntroductionDetByEpisodeAndDate_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DrugOrderIntroductionDet.GetDrugOrderIntroductionDetByEpisodeAndDate_Class> GetDrugOrderIntroductionDetByEpisodeAndDate(TTObjectContext objectContext, Guid EPISODE, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERINTRODUCTIONDET"].QueryDefs["GetDrugOrderIntroductionDetByEpisodeAndDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<DrugOrderIntroductionDet.GetDrugOrderIntroductionDetByEpisodeAndDate_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Drug Order Ekranındaki tedavi planı
    /// </summary>
        public static BindingList<DrugOrderIntroductionDet.GetDrugOrderGridViewModelQuery_Class> GetDrugOrderGridViewModelQuery(Guid EPISODE, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERINTRODUCTIONDET"].QueryDefs["GetDrugOrderGridViewModelQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<DrugOrderIntroductionDet.GetDrugOrderGridViewModelQuery_Class>(queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Drug Order Ekranındaki tedavi planı
    /// </summary>
        public static BindingList<DrugOrderIntroductionDet.GetDrugOrderGridViewModelQuery_Class> GetDrugOrderGridViewModelQuery(TTObjectContext objectContext, Guid EPISODE, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERINTRODUCTIONDET"].QueryDefs["GetDrugOrderGridViewModelQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<DrugOrderIntroductionDet.GetDrugOrderGridViewModelQuery_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DrugOrderIntroductionDet.GetDrugOrderGridViewModelByPatient_Class> GetDrugOrderGridViewModelByPatient(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERINTRODUCTIONDET"].QueryDefs["GetDrugOrderGridViewModelByPatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DrugOrderIntroductionDet.GetDrugOrderGridViewModelByPatient_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DrugOrderIntroductionDet.GetDrugOrderGridViewModelByPatient_Class> GetDrugOrderGridViewModelByPatient(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERINTRODUCTIONDET"].QueryDefs["GetDrugOrderGridViewModelByPatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DrugOrderIntroductionDet.GetDrugOrderGridViewModelByPatient_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Gün
    /// </summary>
        public int? Day
        {
            get { return (int?)this["DAY"]; }
            set { this["DAY"] = value; }
        }

    /// <summary>
    /// Doz Miktarı
    /// </summary>
        public double? DoseAmount
        {
            get { return (double?)this["DOSEAMOUNT"]; }
            set { this["DOSEAMOUNT"] = value; }
        }

    /// <summary>
    /// Uygulama Başlangıç Zamanı
    /// </summary>
        public DateTime? PlannedStartTime
        {
            get { return (DateTime?)this["PLANNEDSTARTTIME"]; }
            set { this["PLANNEDSTARTTIME"] = value; }
        }

    /// <summary>
    /// Doz Aralığı
    /// </summary>
        public FrequencyEnum? Frequency
        {
            get { return (FrequencyEnum?)(int?)this["FREQUENCY"]; }
            set { this["FREQUENCY"] = value; }
        }

    /// <summary>
    /// Kullanma Açıklaması
    /// </summary>
        public string UsageNote
        {
            get { return (string)this["USAGENOTE"]; }
            set { this["USAGENOTE"] = value; }
        }

    /// <summary>
    /// Hasta Yanında Getirdi
    /// </summary>
        public bool? PatientOwnDrug
        {
            get { return (bool?)this["PATIENTOWNDRUG"]; }
            set { this["PATIENTOWNDRUG"] = value; }
        }

        public DrugOrderTypeEnum? DrugOrderType
        {
            get { return (DrugOrderTypeEnum?)(int?)this["DRUGORDERTYPE"]; }
            set { this["DRUGORDERTYPE"] = value; }
        }

    /// <summary>
    /// Reçete Açk.
    /// </summary>
        public string DrugDescription
        {
            get { return (string)this["DRUGDESCRIPTION"]; }
            set { this["DRUGDESCRIPTION"] = value; }
        }

    /// <summary>
    /// Reçete Açk. Türü
    /// </summary>
        public DescriptionTypeEnum? DrugDescriptionType
        {
            get { return (DescriptionTypeEnum?)(int?)this["DRUGDESCRIPTIONTYPE"]; }
            set { this["DRUGDESCRIPTIONTYPE"] = value; }
        }

    /// <summary>
    /// Kullanım Şekli
    /// </summary>
        public DrugUsageTypeEnum? DrugUsageType
        {
            get { return (DrugUsageTypeEnum?)(int?)this["DRUGUSAGETYPE"]; }
            set { this["DRUGUSAGETYPE"] = value; }
        }

    /// <summary>
    /// Acil İlaç
    /// </summary>
        public bool? IsImmediate
        {
            get { return (bool?)this["ISIMMEDIATE"]; }
            set { this["ISIMMEDIATE"] = value; }
        }

    /// <summary>
    /// Sonraki Gün Order (1x1 için)
    /// </summary>
        public bool? NextDayOrder
        {
            get { return (bool?)this["NEXTDAYORDER"]; }
            set { this["NEXTDAYORDER"] = value; }
        }

    /// <summary>
    /// Kullanım Periyot Birimi
    /// </summary>
        public PeriodUnitTypeEnum? PeriodUnitType
        {
            get { return (PeriodUnitTypeEnum?)(int?)this["PERIODUNITTYPE"]; }
            set { this["PERIODUNITTYPE"] = value; }
        }

    /// <summary>
    /// Paket Adedi
    /// </summary>
        public double? PackageAmount
        {
            get { return (double?)this["PACKAGEAMOUNT"]; }
            set { this["PACKAGEAMOUNT"] = value; }
        }

    /// <summary>
    /// Lüzum Halinde
    /// </summary>
        public bool? CaseOfNeed
        {
            get { return (bool?)this["CASEOFNEED"]; }
            set { this["CASEOFNEED"] = value; }
        }

    /// <summary>
    /// Kontravisit
    /// </summary>
        public bool? IsCV
        {
            get { return (bool?)this["ISCV"]; }
            set { this["ISCV"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string RepeatDayWarning
        {
            get { return (string)this["REPEATDAYWARNING"]; }
            set { this["REPEATDAYWARNING"] = value; }
        }

    /// <summary>
    /// Sözel Order
    /// </summary>
        public bool? IsTeleOrder
        {
            get { return (bool?)this["ISTELEORDER"]; }
            set { this["ISTELEORDER"] = value; }
        }

        public DrugOrder DrugOrder
        {
            get { return (DrugOrder)((ITTObject)this).GetParent("DRUGORDER"); }
            set { this["DRUGORDER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Material Material
        {
            get { return (Material)((ITTObject)this).GetParent("MATERIAL"); }
            set { this["MATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public DrugOrderIntroduction DrugOrderIntroduction
        {
            get { return (DrugOrderIntroduction)((ITTObject)this).GetParent("DRUGORDERINTRODUCTION"); }
            set { this["DRUGORDERINTRODUCTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ResUser ProcedureDoctor
        {
            get { return (ResUser)((ITTObject)this).GetParent("PROCEDUREDOCTOR"); }
            set { this["PROCEDUREDOCTOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected DrugOrderIntroductionDet(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DrugOrderIntroductionDet(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DrugOrderIntroductionDet(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DrugOrderIntroductionDet(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DrugOrderIntroductionDet(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DRUGORDERINTRODUCTIONDET", dataRow) { }
        protected DrugOrderIntroductionDet(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DRUGORDERINTRODUCTIONDET", dataRow, isImported) { }
        public DrugOrderIntroductionDet(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DrugOrderIntroductionDet(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DrugOrderIntroductionDet() : base() { }

    }
}
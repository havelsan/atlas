
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SubSurgery")] 

    /// <summary>
    /// Aynı Seansda Birden Fazla Bölüm Ameliyat Gerçekleştirdiğinde Diğer Bölümler İçin Kullanılan Nesnedir 
    /// </summary>
    public  partial class SubSurgery : EpisodeActionWithDiagnosis, IWorkListEpisodeAction
    {
        public class SubSurgeryList : TTObjectCollection<SubSurgery> { }
                    
        public class ChildSubSurgeryCollection : TTObject.TTChildObjectCollection<SubSurgery>
        {
            public ChildSubSurgeryCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSubSurgeryCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class SubSurgeryReportNQL_Class : TTReportNqlObject 
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

            public Guid? Sex
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SEX"]);
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

            public string Subfromres
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUBFROMRES"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public object Subsurgeryreport
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUBSURGERYREPORT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBSURGERY"].AllPropertyDefs["SURGERYREPORT"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public DateTime? Subsurgeryreportdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUBSURGERYREPORTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBSURGERY"].AllPropertyDefs["SURGERYREPORTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public long? Subsurgeryreportno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUBSURGERYREPORTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBSURGERY"].AllPropertyDefs["SURGERYREPORTNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string DiplomaNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIPLOMANO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["DIPLOMANO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string EmploymentRecordID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EMPLOYMENTRECORDID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["EMPLOYMENTRECORDID"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public UserTitleEnum? Title
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TITLE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["TITLE"].DataType;
                    return (UserTitleEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Rank
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RANK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RANKDEFINITIONS"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Militaryclass
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MILITARYCLASS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MILITARYCLASSDEFINITIONS"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Work
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WORK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["WORK"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public string Speciality
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SPECIALITY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SPECIALITYDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public SubSurgeryReportNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public SubSurgeryReportNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected SubSurgeryReportNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class SubSurgeryReportBySurgeryNQL_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Subfromres
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUBFROMRES"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public object Subsurgeryreport
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUBSURGERYREPORT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBSURGERY"].AllPropertyDefs["SURGERYREPORT"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public DateTime? Subsurgeryreportdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUBSURGERYREPORTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBSURGERY"].AllPropertyDefs["SURGERYREPORTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public long? Subsurgeryreportno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUBSURGERYREPORTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBSURGERY"].AllPropertyDefs["SURGERYREPORTNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string DiplomaNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIPLOMANO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["DIPLOMANO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string EmploymentRecordID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EMPLOYMENTRECORDID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["EMPLOYMENTRECORDID"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public UserTitleEnum? Title
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TITLE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["TITLE"].DataType;
                    return (UserTitleEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Rank
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RANK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RANKDEFINITIONS"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Militaryclass
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MILITARYCLASS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MILITARYCLASSDEFINITIONS"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Work
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WORK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["WORK"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public string Speciality
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SPECIALITY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SPECIALITYDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public SubSurgeryReportBySurgeryNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public SubSurgeryReportBySurgeryNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected SubSurgeryReportBySurgeryNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class GetSubSurgeryForWL_Class : TTReportNqlObject 
        {
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

            public Guid? ObjectDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTDEFID"]);
                }
            }

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Prioritystatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRIORITYSTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRIORITYSTATUSDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? SurgeryStartTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SURGERYSTARTTIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERY"].AllPropertyDefs["SURGERYSTARTTIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? SurgeryEndTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SURGERYENDTIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERY"].AllPropertyDefs["SURGERYENDTIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? PlannedSurgeryDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PLANNEDSURGERYDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERY"].AllPropertyDefs["PLANNEDSURGERYDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Object Patientnamesurname
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PATIENTNAMESURNAME"]);
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

            public Object Episodeactionname
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["EPISODEACTIONNAME"]);
                }
            }

            public String Statename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STATENAME"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public string Surgerydepartment
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SURGERYDEPARTMENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Inpatientclinic
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INPATIENTCLINIC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Surgeryroom
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SURGERYROOM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSURGERYROOM"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Surgerydesk
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SURGERYDESK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSURGERYDESK"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Operator
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OPERATOR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Anesthesist
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ANESTHESIST"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Admissiontype
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADMISSIONTYPE"]);
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

            public string Cinsiyet
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CINSIYET"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSCINSIYET"].AllPropertyDefs["ADI"].DataType;
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

            public string Telno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TELNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTIDENTITYANDADDRESS"].AllPropertyDefs["MOBILEPHONE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public PatientClassTypeEnum? Hastaturu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HASTATURU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSION"].AllPropertyDefs["PATIENTCLASSGROUP"].DataType;
                    return (PatientClassTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public ApplicationReasonEnum? Basvuruturu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BASVURUTURU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSION"].AllPropertyDefs["APPLICATIONREASON"].DataType;
                    return (ApplicationReasonEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Oncelikdurumu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ONCELIKDURUMU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRIORITYSTATUSDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetSubSurgeryForWL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSubSurgeryForWL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSubSurgeryForWL_Class() : base() { }
        }

        public static class States
        {
            public static Guid SubSurgeryReport { get { return new Guid("de622b90-9607-4e1b-9a5e-89230e2340b3"); } }
    /// <summary>
    /// İptal Edildi
    /// </summary>
            public static Guid Cancelled { get { return new Guid("47e645e6-404b-4ac7-85bd-6b1b304404c8"); } }
            public static Guid Completed { get { return new Guid("224d6706-8a3c-4ede-b7f0-d54bb6337360"); } }
        }

        public static BindingList<SubSurgery.SubSurgeryReportNQL_Class> SubSurgeryReportNQL(string SUBSURGERY, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBSURGERY"].QueryDefs["SubSurgeryReportNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBSURGERY", SUBSURGERY);

            return TTReportNqlObject.QueryObjects<SubSurgery.SubSurgeryReportNQL_Class>(queryDef, paramList, pi);
        }

        public static BindingList<SubSurgery.SubSurgeryReportNQL_Class> SubSurgeryReportNQL(TTObjectContext objectContext, string SUBSURGERY, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBSURGERY"].QueryDefs["SubSurgeryReportNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBSURGERY", SUBSURGERY);

            return TTReportNqlObject.QueryObjects<SubSurgery.SubSurgeryReportNQL_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<SubSurgery.SubSurgeryReportBySurgeryNQL_Class> SubSurgeryReportBySurgeryNQL(string SURGERY, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBSURGERY"].QueryDefs["SubSurgeryReportBySurgeryNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SURGERY", SURGERY);

            return TTReportNqlObject.QueryObjects<SubSurgery.SubSurgeryReportBySurgeryNQL_Class>(queryDef, paramList, pi);
        }

        public static BindingList<SubSurgery.SubSurgeryReportBySurgeryNQL_Class> SubSurgeryReportBySurgeryNQL(TTObjectContext objectContext, string SURGERY, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBSURGERY"].QueryDefs["SubSurgeryReportBySurgeryNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SURGERY", SURGERY);

            return TTReportNqlObject.QueryObjects<SubSurgery.SubSurgeryReportBySurgeryNQL_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<SubSurgery> GetByEpisode(TTObjectContext objectContext, Guid EPISODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBSURGERY"].QueryDefs["GetByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return ((ITTQuery)objectContext).QueryObjects<SubSurgery>(queryDef, paramList);
        }

        public static BindingList<SubSurgery.GetSubSurgeryForWL_Class> GetSubSurgeryForWL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBSURGERY"].QueryDefs["GetSubSurgeryForWL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SubSurgery.GetSubSurgeryForWL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SubSurgery.GetSubSurgeryForWL_Class> GetSubSurgeryForWL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBSURGERY"].QueryDefs["GetSubSurgeryForWL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SubSurgery.GetSubSurgeryForWL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Ek Ameliyat Raporu
    /// </summary>
        public object SurgeryReport
        {
            get { return (object)this["SURGERYREPORT"]; }
            set { this["SURGERYREPORT"] = value; }
        }

        public DateTime? SurgeryReportDate
        {
            get { return (DateTime?)this["SURGERYREPORTDATE"]; }
            set { this["SURGERYREPORTDATE"] = value; }
        }

    /// <summary>
    /// Ek Rapor No
    /// </summary>
        public TTSequence SurgeryReportNo
        {
            get { return GetSequence("SURGERYREPORTNO"); }
        }

    /// <summary>
    /// Mesai Durumu
    /// </summary>
        public SurgeryShiftEnum? SurgeryShift
        {
            get { return (SurgeryShiftEnum?)(int?)this["SURGERYSHIFT"]; }
            set { this["SURGERYSHIFT"] = value; }
        }

    /// <summary>
    /// Ameliyat Durumu
    /// </summary>
        public SurgeryStatusEnum? SurgeryStatus
        {
            get { return (SurgeryStatusEnum?)(int?)this["SURGERYSTATUS"]; }
            set { this["SURGERYSTATUS"] = value; }
        }

    /// <summary>
    /// Ameliyat Tipi
    /// </summary>
        public SurgeryPointGroupEnum? SurgeryPointGroup
        {
            get { return (SurgeryPointGroupEnum?)(int?)this["SURGERYPOINTGROUP"]; }
            set { this["SURGERYPOINTGROUP"] = value; }
        }

        public Surgery Surgery
        {
            get { return (Surgery)((ITTObject)this).GetParent("SURGERY"); }
            set { this["SURGERY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateSubSurgeryProceduresCollection()
        {
            _SubSurgeryProcedures = new SubSurgeryProcedure.ChildSubSurgeryProcedureCollection(this, new Guid("29e5d023-fd75-4ed8-8c03-7a0f965d044c"));
            ((ITTChildObjectCollection)_SubSurgeryProcedures).GetChildren();
        }

        protected SubSurgeryProcedure.ChildSubSurgeryProcedureCollection _SubSurgeryProcedures = null;
        public SubSurgeryProcedure.ChildSubSurgeryProcedureCollection SubSurgeryProcedures
        {
            get
            {
                if (_SubSurgeryProcedures == null)
                    CreateSubSurgeryProceduresCollection();
                return _SubSurgeryProcedures;
            }
        }

        virtual protected void CreateSurgeryParticipantDepartmentCollection()
        {
            _SurgeryParticipantDepartment = new SurgeryParticipantDepartment.ChildSurgeryParticipantDepartmentCollection(this, new Guid("1f5ccfe0-0270-475d-a6e7-e0f47b72d2aa"));
            ((ITTChildObjectCollection)_SurgeryParticipantDepartment).GetChildren();
        }

        protected SurgeryParticipantDepartment.ChildSurgeryParticipantDepartmentCollection _SurgeryParticipantDepartment = null;
    /// <summary>
    /// Child collection for Ek Ameliyat
    /// </summary>
        public SurgeryParticipantDepartment.ChildSurgeryParticipantDepartmentCollection SurgeryParticipantDepartment
        {
            get
            {
                if (_SurgeryParticipantDepartment == null)
                    CreateSurgeryParticipantDepartmentCollection();
                return _SurgeryParticipantDepartment;
            }
        }

        override protected void CreateTreatmentMaterialsCollectionViews()
        {
            base.CreateTreatmentMaterialsCollectionViews();
            _SubSurgeryExpends = new SurgeryExpend.ChildSurgeryExpendCollection(_TreatmentMaterials, "SubSurgeryExpends");
            _SubSurgeryDirectPurchaseGrids = new SurgeryDirectPurchaseGrid.ChildSurgeryDirectPurchaseGridCollection(_TreatmentMaterials, "SubSurgeryDirectPurchaseGrids");
            _SubSurgery_CodelessMaterialDirectPurchaseGrids = new CodelessMaterialDirectPurchaseGrid.ChildCodelessMaterialDirectPurchaseGridCollection(_TreatmentMaterials, "SubSurgery_CodelessMaterialDirectPurchaseGrids");
        }

        private SurgeryExpend.ChildSurgeryExpendCollection _SubSurgeryExpends = null;
        public SurgeryExpend.ChildSurgeryExpendCollection SubSurgeryExpends
        {
            get
            {
                if (_TreatmentMaterials == null)
                    CreateTreatmentMaterialsCollection();
                return _SubSurgeryExpends;
            }            
        }

        private SurgeryDirectPurchaseGrid.ChildSurgeryDirectPurchaseGridCollection _SubSurgeryDirectPurchaseGrids = null;
        public SurgeryDirectPurchaseGrid.ChildSurgeryDirectPurchaseGridCollection SubSurgeryDirectPurchaseGrids
        {
            get
            {
                if (_TreatmentMaterials == null)
                    CreateTreatmentMaterialsCollection();
                return _SubSurgeryDirectPurchaseGrids;
            }            
        }

        private CodelessMaterialDirectPurchaseGrid.ChildCodelessMaterialDirectPurchaseGridCollection _SubSurgery_CodelessMaterialDirectPurchaseGrids = null;
        public CodelessMaterialDirectPurchaseGrid.ChildCodelessMaterialDirectPurchaseGridCollection SubSurgery_CodelessMaterialDirectPurchaseGrids
        {
            get
            {
                if (_TreatmentMaterials == null)
                    CreateTreatmentMaterialsCollection();
                return _SubSurgery_CodelessMaterialDirectPurchaseGrids;
            }            
        }

        protected SubSurgery(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SubSurgery(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SubSurgery(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SubSurgery(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SubSurgery(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SUBSURGERY", dataRow) { }
        protected SubSurgery(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SUBSURGERY", dataRow, isImported) { }
        public SubSurgery(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SubSurgery(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SubSurgery() : base() { }

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
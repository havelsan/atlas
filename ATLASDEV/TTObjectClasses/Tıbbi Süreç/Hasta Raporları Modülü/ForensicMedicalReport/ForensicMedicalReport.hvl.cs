
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ForensicMedicalReport")] 

    /// <summary>
    /// Adli Tıp Raporlarının Girişinin Yapıldığı Temel Nesnedir
    /// </summary>
    public  partial class ForensicMedicalReport : EpisodeAction
    {
        public class ForensicMedicalReportList : TTObjectCollection<ForensicMedicalReport> { }
                    
        public class ChildForensicMedicalReportCollection : TTObject.TTChildObjectCollection<ForensicMedicalReport>
        {
            public ChildForensicMedicalReportCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildForensicMedicalReportCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetForensicMedicalReport_Class : TTReportNqlObject 
        {
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALREPORT"].AllPropertyDefs["DOCUMENTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string DocumentNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCUMENTNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALREPORT"].AllPropertyDefs["DOCUMENTNUMBER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? ProtocolNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROTOCOLNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALREPORT"].AllPropertyDefs["PROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public object Report
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALREPORT"].AllPropertyDefs["REPORT"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public long? ReportNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALREPORT"].AllPropertyDefs["REPORTNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public Guid? Episode
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODE"]);
                }
            }

            public Guid? Patientid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PATIENTID"]);
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

            public Guid? PatientAddress
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PATIENTADDRESS"]);
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

            public Guid? CityOfBirth
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CITYOFBIRTH"]);
                }
            }

            public string Sname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SERVICE"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SERVICE"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? ActionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALREPORT"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Birimadi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BIRIMADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? Actionid
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALREPORT"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Makam
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MAKAM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MILITARYUNIT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Cinsiyet
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CINSIYET"]);
                }
            }

            public Guid? ProcedureDoctor
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PROCEDUREDOCTOR"]);
                }
            }

            public ReasonExaminationTypeEnum? Muayenenedeni
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MUAYENENEDENI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALREPORT"].AllPropertyDefs["REASONEXAMINATIONREPORTTYPE"].DataType;
                    return (ReasonExaminationTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Aciklama1
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACIKLAMA1"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALREPORT"].AllPropertyDefs["OTHERREASONEXAMINATION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Tibbikimlik
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TIBBIKIMLIK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALREPORT"].AllPropertyDefs["PATIENTIDENTITY"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Olayinoykusu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLAYINOYKUSU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALREPORT"].AllPropertyDefs["HISTORYOFEVENT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GeneralConditionOfPatientEnum? Geneldurum
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GENELDURUM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALREPORT"].AllPropertyDefs["GENERALCONDITIONOFPATIENT"].DataType;
                    return (GeneralConditionOfPatientEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public AwarenessEnum? Bilinci
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BILINCI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALREPORT"].AllPropertyDefs["AWARENESS"].DataType;
                    return (AwarenessEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public RespitoryEnum? Solunum
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SOLUNUM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALREPORT"].AllPropertyDefs["RESPITORY"].DataType;
                    return (RespitoryEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public PupilPropertiesEnum? PupilProperties
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PUPILPROPERTIES"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALREPORT"].AllPropertyDefs["PUPILPROPERTIES"].DataType;
                    return (PupilPropertiesEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public LightReflexEnum? LightReflex
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LIGHTREFLEX"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALREPORT"].AllPropertyDefs["LIGHTREFLEX"].DataType;
                    return (LightReflexEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public TendonReflexesEnum? TendonReflexes
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TENDONREFLEXES"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALREPORT"].AllPropertyDefs["TENDONREFLEXES"].DataType;
                    return (TendonReflexesEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string ArterialBloodPresure
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ARTERIALBLOODPRESURE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALREPORT"].AllPropertyDefs["ARTERIALBLOODPRESURE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Pulse
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PULSE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALREPORT"].AllPropertyDefs["PULSE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Sevk
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SEVK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALREPORT"].AllPropertyDefs["RESONOFDISPATCH"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? Tc
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["UNIQUEREFNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Sistembulgulari
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SISTEMBULGULARI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALREPORT"].AllPropertyDefs["SYSTEMFINDINGS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Lezyonozellikleri
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LEZYONOZELLIKLERI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALREPORT"].AllPropertyDefs["PROPERTIESOFLESIONS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public PemissionDepartmentEnum? Kurm
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KURM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALREPORT"].AllPropertyDefs["PERMISSIONDEPARTMENT"].DataType;
                    return (PemissionDepartmentEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Ortamaciklamasi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORTAMACIKLAMASI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALREPORT"].AllPropertyDefs["EXPLANATION1"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Kiyafetaciklamasi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KIYAFETACIKLAMASI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALREPORT"].AllPropertyDefs["EXPLANATION2"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Konsultasyon
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KONSULTASYON"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Attaches5
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ATTACHES5"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALREPORT"].AllPropertyDefs["ATTACHES5"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public object Sikayetler
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SIKAYETLER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["COMPLAINT"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public object Ozgecmis
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OZGECMIS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["PATIENTHISTORY"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public string Dipno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIPNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["DIPLOMANO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Dipregno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIPREGNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["DIPLOMAREGISTERNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Sicilno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SICILNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["EMPLOYMENTRECORDID"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetForensicMedicalReport_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetForensicMedicalReport_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetForensicMedicalReport_Class() : base() { }
        }

        [Serializable] 

        public partial class GetForensicMedicalReportNew_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public DateTime? RequestDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALREPORT"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public long? ReportNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALREPORT"].AllPropertyDefs["REPORTNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public long? ProtocolNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROTOCOLNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALREPORT"].AllPropertyDefs["PROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public PemissionDepartmentEnum? Permdepartment
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PERMDEPARTMENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALREPORT"].AllPropertyDefs["PERMISSIONDEPARTMENT"].DataType;
                    return (PemissionDepartmentEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Senderchairname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SENDERCHAIRNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MILITARYUNIT"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALREPORT"].AllPropertyDefs["DOCUMENTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string DocumentNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCUMENTNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALREPORT"].AllPropertyDefs["DOCUMENTNUMBER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? ProcedureDoctor
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PROCEDUREDOCTOR"]);
                }
            }

            public string Dipno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIPNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["DIPLOMANO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Dipregno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIPREGNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["DIPLOMAREGISTERNO"].DataType;
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

            public ReasonExaminationTypeEnum? Examinationreason
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXAMINATIONREASON"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALREPORT"].AllPropertyDefs["REASONEXAMINATIONREPORTTYPE"].DataType;
                    return (ReasonExaminationTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string OtherReasonExamination
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OTHERREASONEXAMINATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALREPORT"].AllPropertyDefs["OTHERREASONEXAMINATION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string PatientIdentity
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTIDENTITY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALREPORT"].AllPropertyDefs["PATIENTIDENTITY"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? SuitableEnvironment1
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUITABLEENVIRONMENT1"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALREPORT"].AllPropertyDefs["SUITABLEENVIRONMENT1"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? SuitableEnvironment2
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUITABLEENVIRONMENT2"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALREPORT"].AllPropertyDefs["SUITABLEENVIRONMENT2"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string Suitableenvexplanation
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUITABLEENVEXPLANATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALREPORT"].AllPropertyDefs["EXPLANATION1"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? PeopleInExamination1
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PEOPLEINEXAMINATION1"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALREPORT"].AllPropertyDefs["PEOPLEINEXAMINATION1"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? PeopleInExamination2
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PEOPLEINEXAMINATION2"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALREPORT"].AllPropertyDefs["PEOPLEINEXAMINATION2"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? PeopleInExamination3
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PEOPLEINEXAMINATION3"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALREPORT"].AllPropertyDefs["PEOPLEINEXAMINATION3"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? PeopleInExamination4
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PEOPLEINEXAMINATION4"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALREPORT"].AllPropertyDefs["PEOPLEINEXAMINATION4"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? ClothesOfPatient1
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CLOTHESOFPATIENT1"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALREPORT"].AllPropertyDefs["CLOTHESOFPATIENT1"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? ClothesOfPatient2
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CLOTHESOFPATIENT2"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALREPORT"].AllPropertyDefs["CLOTHESOFPATIENT2"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? ClothesOfPatient3
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CLOTHESOFPATIENT3"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALREPORT"].AllPropertyDefs["CLOTHESOFPATIENT3"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string Clothesofpatientexplanation
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CLOTHESOFPATIENTEXPLANATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALREPORT"].AllPropertyDefs["EXPLANATION2"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string HistoryOfEvent
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HISTORYOFEVENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALREPORT"].AllPropertyDefs["HISTORYOFEVENT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public object Complaint
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["COMPLAINT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["COMPLAINT"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public object PatientHistory
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTHISTORY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["PATIENTHISTORY"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public DateTime? ExaminationDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXAMINATIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALREPORT"].AllPropertyDefs["EXAMINATIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? HeadNeck
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HEADNECK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALREPORT"].AllPropertyDefs["HEADNECK"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? Chest
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CHEST"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALREPORT"].AllPropertyDefs["CHEST"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? Abdominal
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ABDOMINAL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALREPORT"].AllPropertyDefs["ABDOMINAL"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? Back
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BACK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALREPORT"].AllPropertyDefs["BACK"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? UpperExtrimity
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UPPEREXTRIMITY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALREPORT"].AllPropertyDefs["UPPEREXTRIMITY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? LowerExtremity
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LOWEREXTREMITY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALREPORT"].AllPropertyDefs["LOWEREXTREMITY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? GenitalArea
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GENITALAREA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALREPORT"].AllPropertyDefs["GENITALAREA"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string PropertiesOfLesions
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROPERTIESOFLESIONS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALREPORT"].AllPropertyDefs["PROPERTIESOFLESIONS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? CentralNervousSystem
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CENTRALNERVOUSSYSTEM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALREPORT"].AllPropertyDefs["CENTRALNERVOUSSYSTEM"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? CardiovascularSystem
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CARDIOVASCULARSYSTEM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALREPORT"].AllPropertyDefs["CARDIOVASCULARSYSTEM"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? DigestiveSys
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIGESTIVESYS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALREPORT"].AllPropertyDefs["DIGESTIVESYS"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? RespiratorySys
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESPIRATORYSYS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALREPORT"].AllPropertyDefs["RESPIRATORYSYS"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? SkeletalSys
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SKELETALSYS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALREPORT"].AllPropertyDefs["SKELETALSYS"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? UrogenitalSys
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UROGENITALSYS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALREPORT"].AllPropertyDefs["UROGENITALSYS"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? SensoryOrgansSys
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SENSORYORGANSSYS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALREPORT"].AllPropertyDefs["SENSORYORGANSSYS"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public GeneralConditionOfPatientEnum? Generalconditionofpatienttext
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GENERALCONDITIONOFPATIENTTEXT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALREPORT"].AllPropertyDefs["GENERALCONDITIONOFPATIENT"].DataType;
                    return (GeneralConditionOfPatientEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public AwarenessEnum? Awarenesstext
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AWARENESSTEXT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALREPORT"].AllPropertyDefs["AWARENESS"].DataType;
                    return (AwarenessEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public RespitoryEnum? Respitorytext
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESPITORYTEXT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALREPORT"].AllPropertyDefs["RESPITORY"].DataType;
                    return (RespitoryEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public PupilPropertiesEnum? Pupilpropertiestext
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PUPILPROPERTIESTEXT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALREPORT"].AllPropertyDefs["PUPILPROPERTIES"].DataType;
                    return (PupilPropertiesEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public LightReflexEnum? Lightreflextext
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LIGHTREFLEXTEXT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALREPORT"].AllPropertyDefs["LIGHTREFLEX"].DataType;
                    return (LightReflexEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public TendonReflexesEnum? Tendonreflexestext
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TENDONREFLEXESTEXT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALREPORT"].AllPropertyDefs["TENDONREFLEXES"].DataType;
                    return (TendonReflexesEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string ArterialBloodPresure
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ARTERIALBLOODPRESURE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALREPORT"].AllPropertyDefs["ARTERIALBLOODPRESURE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Pulse
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PULSE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALREPORT"].AllPropertyDefs["PULSE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string SystemFindings
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SYSTEMFINDINGS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALREPORT"].AllPropertyDefs["SYSTEMFINDINGS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? NoEvidancePsycho
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NOEVIDANCEPSYCHO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALREPORT"].AllPropertyDefs["NOEVIDANCEPSYCHO"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? PyschiatricExamination
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PYSCHIATRICEXAMINATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALREPORT"].AllPropertyDefs["PYSCHIATRICEXAMINATION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? PsychiatricConsultation
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PSYCHIATRICCONSULTATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALREPORT"].AllPropertyDefs["PSYCHIATRICCONSULTATION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? ChkLabProcedures
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CHKLABPROCEDURES"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALREPORT"].AllPropertyDefs["CHKLABPROCEDURES"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? ChkDirectGraph
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CHKDIRECTGRAPH"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALREPORT"].AllPropertyDefs["CHKDIRECTGRAPH"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? ChkBTMR
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CHKBTMR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALREPORT"].AllPropertyDefs["CHKBTMR"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? ChkUltrasonography
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CHKULTRASONOGRAPHY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALREPORT"].AllPropertyDefs["CHKULTRASONOGRAPHY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? ChkBiopsy
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CHKBIOPSY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALREPORT"].AllPropertyDefs["CHKBIOPSY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? ChkOther
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CHKOTHER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALREPORT"].AllPropertyDefs["CHKOTHER"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public object LaboratoryProcedures
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LABORATORYPROCEDURES"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALREPORT"].AllPropertyDefs["LABORATORYPROCEDURES"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public bool? Attaches1
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ATTACHES1"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALREPORT"].AllPropertyDefs["ATTACHES1"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? Attaches2
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ATTACHES2"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALREPORT"].AllPropertyDefs["ATTACHES2"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string Attaches2Text
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ATTACHES2TEXT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALREPORT"].AllPropertyDefs["ATTACHES2TEXT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? Attaches3
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ATTACHES3"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALREPORT"].AllPropertyDefs["ATTACHES3"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string Attaches3Text1
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ATTACHES3TEXT1"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALREPORT"].AllPropertyDefs["ATTACHES3TEXT1"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Attaches3Text2
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ATTACHES3TEXT2"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALREPORT"].AllPropertyDefs["ATTACHES3TEXT2"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? Attaches4
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ATTACHES4"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALREPORT"].AllPropertyDefs["ATTACHES4"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string Attaches5
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ATTACHES5"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALREPORT"].AllPropertyDefs["ATTACHES5"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? NoNeed
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NONEED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALREPORT"].AllPropertyDefs["NONEED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? Need
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NEED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALREPORT"].AllPropertyDefs["NEED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? CertainReport
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CERTAINREPORT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALREPORT"].AllPropertyDefs["CERTAINREPORT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? UncertainReport
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNCERTAINREPORT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALREPORT"].AllPropertyDefs["UNCERTAINREPORT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string ResonOfDispatch
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESONOFDISPATCH"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALREPORT"].AllPropertyDefs["RESONOFDISPATCH"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public object Report
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALREPORT"].AllPropertyDefs["REPORT"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public Guid? Patientid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PATIENTID"]);
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

            public Guid? PatientAddress
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PATIENTADDRESS"]);
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

            public Guid? CityOfBirth
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CITYOFBIRTH"]);
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

            public string Cinsiyetkodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CINSIYETKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSCINSIYET"].AllPropertyDefs["KODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Occupation
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OCCUPATION"]);
                }
            }

            public DateTime? ActionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALREPORT"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Resusername
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESUSERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Resusersicilno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESUSERSICILNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["EMPLOYMENTRECORDID"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetForensicMedicalReportNew_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetForensicMedicalReportNew_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetForensicMedicalReportNew_Class() : base() { }
        }

        public static class States
        {
    /// <summary>
    /// Tamam
    /// </summary>
            public static Guid Completed { get { return new Guid("d4a3cfde-5ebc-4cb4-a057-9e3f93b5da0c"); } }
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancelled { get { return new Guid("e4611f6b-2823-40f3-ab90-b24b5941bc8a"); } }
    /// <summary>
    /// Rapor Giriş
    /// </summary>
            public static Guid ReportEntry { get { return new Guid("c9f3be98-f21a-4989-a25c-c0058f898dcd"); } }
        }

        public static BindingList<ForensicMedicalReport> GetForensicMedicalReportByID(TTObjectContext objectContext, string OBJECTID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALREPORT"].QueryDefs["GetForensicMedicalReportByID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return ((ITTQuery)objectContext).QueryObjects<ForensicMedicalReport>(queryDef, paramList);
        }

        public static BindingList<ForensicMedicalReport.GetForensicMedicalReport_Class> GetForensicMedicalReport(string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALREPORT"].QueryDefs["GetForensicMedicalReport"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<ForensicMedicalReport.GetForensicMedicalReport_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ForensicMedicalReport.GetForensicMedicalReport_Class> GetForensicMedicalReport(TTObjectContext objectContext, string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALREPORT"].QueryDefs["GetForensicMedicalReport"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<ForensicMedicalReport.GetForensicMedicalReport_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ForensicMedicalReport.GetForensicMedicalReportNew_Class> GetForensicMedicalReportNew(Guid OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALREPORT"].QueryDefs["GetForensicMedicalReportNew"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<ForensicMedicalReport.GetForensicMedicalReportNew_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ForensicMedicalReport.GetForensicMedicalReportNew_Class> GetForensicMedicalReportNew(TTObjectContext objectContext, Guid OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALREPORT"].QueryDefs["GetForensicMedicalReportNew"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<ForensicMedicalReport.GetForensicMedicalReportNew_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Adli Rapor No
    /// </summary>
        public TTSequence ReportNo
        {
            get { return GetSequence("REPORTNO"); }
        }

    /// <summary>
    /// Adli Rapor
    /// </summary>
        public object Report
        {
            get { return (object)this["REPORT"]; }
            set { this["REPORT"] = value; }
        }

    /// <summary>
    /// Evrak Tarihi
    /// </summary>
        public DateTime? DocumentDate
        {
            get { return (DateTime?)this["DOCUMENTDATE"]; }
            set { this["DOCUMENTDATE"] = value; }
        }

    /// <summary>
    /// Evrak Sayısı
    /// </summary>
        public string DocumentNumber
        {
            get { return (string)this["DOCUMENTNUMBER"]; }
            set { this["DOCUMENTNUMBER"] = value; }
        }

    /// <summary>
    /// Protokol No
    /// </summary>
        public TTSequence ProtocolNo
        {
            get { return GetSequence("PROTOCOLNO"); }
        }

    /// <summary>
    /// Diğer konsültasyon ve dökümalar
    /// </summary>
        public string Attaches5
        {
            get { return (string)this["ATTACHES5"]; }
            set { this["ATTACHES5"] = value; }
        }

    /// <summary>
    /// Eklenen Konsültasyon Raporu
    /// </summary>
        public bool? Attaches3
        {
            get { return (bool?)this["ATTACHES3"]; }
            set { this["ATTACHES3"] = value; }
        }

    /// <summary>
    /// Diğer eklenenler
    /// </summary>
        public bool? Attaches4
        {
            get { return (bool?)this["ATTACHES4"]; }
            set { this["ATTACHES4"] = value; }
        }

    /// <summary>
    /// Sevke gerek görülmedi
    /// </summary>
        public bool? NoNeed
        {
            get { return (bool?)this["NONEED"]; }
            set { this["NONEED"] = value; }
        }

    /// <summary>
    /// Sevke gerek görüldü
    /// </summary>
        public bool? Need
        {
            get { return (bool?)this["NEED"]; }
            set { this["NEED"] = value; }
        }

    /// <summary>
    /// Muayene Sebebi 
    /// </summary>
        public ReasonExaminationTypeEnum? ReasonExaminationReportType
        {
            get { return (ReasonExaminationTypeEnum?)(int?)this["REASONEXAMINATIONREPORTTYPE"]; }
            set { this["REASONEXAMINATIONREPORTTYPE"] = value; }
        }

    /// <summary>
    /// Psikiyatrik konsultasyon
    /// </summary>
        public bool? PsychiatricConsultation
        {
            get { return (bool?)this["PSYCHIATRICCONSULTATION"]; }
            set { this["PSYCHIATRICCONSULTATION"] = value; }
        }

    /// <summary>
    /// Eklenen Vücut Diyagramı
    /// </summary>
        public bool? Attaches1
        {
            get { return (bool?)this["ATTACHES1"]; }
            set { this["ATTACHES1"] = value; }
        }

    /// <summary>
    /// Eklenen psikiyatrik muayene
    /// </summary>
        public bool? Attaches2
        {
            get { return (bool?)this["ATTACHES2"]; }
            set { this["ATTACHES2"] = value; }
        }

    /// <summary>
    /// Tansiyon Arteryel
    /// </summary>
        public string ArterialBloodPresure
        {
            get { return (string)this["ARTERIALBLOODPRESURE"]; }
            set { this["ARTERIALBLOODPRESURE"] = value; }
        }

    /// <summary>
    /// Nabız
    /// </summary>
        public string Pulse
        {
            get { return (string)this["PULSE"]; }
            set { this["PULSE"] = value; }
        }

    /// <summary>
    /// Baş-Boyun
    /// </summary>
        public bool? HeadNeck
        {
            get { return (bool?)this["HEADNECK"]; }
            set { this["HEADNECK"] = value; }
        }

    /// <summary>
    /// Göğüs
    /// </summary>
        public bool? Chest
        {
            get { return (bool?)this["CHEST"]; }
            set { this["CHEST"] = value; }
        }

    /// <summary>
    /// Batın
    /// </summary>
        public bool? Abdominal
        {
            get { return (bool?)this["ABDOMINAL"]; }
            set { this["ABDOMINAL"] = value; }
        }

    /// <summary>
    /// Sırt-Bel
    /// </summary>
        public bool? Back
        {
            get { return (bool?)this["BACK"]; }
            set { this["BACK"] = value; }
        }

    /// <summary>
    /// Üst Ekstremite
    /// </summary>
        public bool? UpperExtrimity
        {
            get { return (bool?)this["UPPEREXTRIMITY"]; }
            set { this["UPPEREXTRIMITY"] = value; }
        }

    /// <summary>
    /// Alt Ekstremite
    /// </summary>
        public bool? LowerExtremity
        {
            get { return (bool?)this["LOWEREXTREMITY"]; }
            set { this["LOWEREXTREMITY"] = value; }
        }

    /// <summary>
    /// Genital Bölge
    /// </summary>
        public bool? GenitalArea
        {
            get { return (bool?)this["GENITALAREA"]; }
            set { this["GENITALAREA"] = value; }
        }

    /// <summary>
    /// Raporun İstendiği Makam
    /// </summary>
        public PemissionDepartmentEnum? PermissionDepartment
        {
            get { return (PemissionDepartmentEnum?)(int?)this["PERMISSIONDEPARTMENT"]; }
            set { this["PERMISSIONDEPARTMENT"] = value; }
        }

    /// <summary>
    /// Cinsiyeti
    /// </summary>
        public SexEnum? Sex
        {
            get { return (SexEnum?)(int?)this["SEX"]; }
            set { this["SEX"] = value; }
        }

    /// <summary>
    /// Sevk Sebebi
    /// </summary>
        public string ResonOfDispatch
        {
            get { return (string)this["RESONOFDISPATCH"]; }
            set { this["RESONOFDISPATCH"] = value; }
        }

    /// <summary>
    /// Açıklamalar
    /// </summary>
        public string Explanation1
        {
            get { return (string)this["EXPLANATION1"]; }
            set { this["EXPLANATION1"] = value; }
        }

    /// <summary>
    /// Açıklamalar
    /// </summary>
        public string Explanation2
        {
            get { return (string)this["EXPLANATION2"]; }
            set { this["EXPLANATION2"] = value; }
        }

    /// <summary>
    /// Lezyonların Özellikleri
    /// </summary>
        public string PropertiesOfLesions
        {
            get { return (string)this["PROPERTIESOFLESIONS"]; }
            set { this["PROPERTIESOFLESIONS"] = value; }
        }

    /// <summary>
    /// Sistem Bulguları
    /// </summary>
        public string SystemFindings
        {
            get { return (string)this["SYSTEMFINDINGS"]; }
            set { this["SYSTEMFINDINGS"] = value; }
        }

    /// <summary>
    /// Diğer Muayene Sebebei
    /// </summary>
        public string OtherReasonExamination
        {
            get { return (string)this["OTHERREASONEXAMINATION"]; }
            set { this["OTHERREASONEXAMINATION"] = value; }
        }

    /// <summary>
    /// Muayene Edilenin Tıbbi Kimliği
    /// </summary>
        public string PatientIdentity
        {
            get { return (string)this["PATIENTIDENTITY"]; }
            set { this["PATIENTIDENTITY"] = value; }
        }

    /// <summary>
    /// Olayın Öyküsü
    /// </summary>
        public string HistoryOfEvent
        {
            get { return (string)this["HISTORYOFEVENT"]; }
            set { this["HISTORYOFEVENT"] = value; }
        }

    /// <summary>
    /// Muayene Edilenin Şikayetleri
    /// </summary>
        public string PatientComplaints
        {
            get { return (string)this["PATIENTCOMPLAINTS"]; }
            set { this["PATIENTCOMPLAINTS"] = value; }
        }

    /// <summary>
    /// Hastanın Tıbbi Özgeçmişi
    /// </summary>
        public string MedicalHistory
        {
            get { return (string)this["MEDICALHISTORY"]; }
            set { this["MEDICALHISTORY"] = value; }
        }

    /// <summary>
    /// İstenilen Konsültasyonlar
    /// </summary>
        public string ConsultationRequested
        {
            get { return (string)this["CONSULTATIONREQUESTED"]; }
            set { this["CONSULTATIONREQUESTED"] = value; }
        }

    /// <summary>
    /// Rapor Şekilleri
    /// </summary>
        public object ReportImage
        {
            get { return (object)this["REPORTIMAGE"]; }
            set { this["REPORTIMAGE"] = value; }
        }

    /// <summary>
    /// Solunum
    /// </summary>
        public RespitoryEnum? Respitory
        {
            get { return (RespitoryEnum?)(int?)this["RESPITORY"]; }
            set { this["RESPITORY"] = value; }
        }

    /// <summary>
    /// Merkezi Siinir Sistemi
    /// </summary>
        public bool? CentralNervousSystem
        {
            get { return (bool?)this["CENTRALNERVOUSSYSTEM"]; }
            set { this["CENTRALNERVOUSSYSTEM"] = value; }
        }

    /// <summary>
    ///  Kalp Damar Sistemi
    /// </summary>
        public bool? CardiovascularSystem
        {
            get { return (bool?)this["CARDIOVASCULARSYSTEM"]; }
            set { this["CARDIOVASCULARSYSTEM"] = value; }
        }

    /// <summary>
    /// Solunum Sistemi
    /// </summary>
        public bool? RespiratorySys
        {
            get { return (bool?)this["RESPIRATORYSYS"]; }
            set { this["RESPIRATORYSYS"] = value; }
        }

    /// <summary>
    /// Ürogenital Sistem
    /// </summary>
        public bool? UrogenitalSys
        {
            get { return (bool?)this["UROGENITALSYS"]; }
            set { this["UROGENITALSYS"] = value; }
        }

    /// <summary>
    /// Kas İskelet Sistemi
    /// </summary>
        public bool? SkeletalSys
        {
            get { return (bool?)this["SKELETALSYS"]; }
            set { this["SKELETALSYS"] = value; }
        }

    /// <summary>
    /// Duyu Organları Sistemi
    /// </summary>
        public bool? SensoryOrgansSys
        {
            get { return (bool?)this["SENSORYORGANSSYS"]; }
            set { this["SENSORYORGANSSYS"] = value; }
        }

    /// <summary>
    /// Sindirim Sistemi
    /// </summary>
        public bool? DigestiveSys
        {
            get { return (bool?)this["DIGESTIVESYS"]; }
            set { this["DIGESTIVESYS"] = value; }
        }

    /// <summary>
    /// Hastanın Genel Durumu
    /// </summary>
        public GeneralConditionOfPatientEnum? GeneralConditionOfPatient
        {
            get { return (GeneralConditionOfPatientEnum?)(int?)this["GENERALCONDITIONOFPATIENT"]; }
            set { this["GENERALCONDITIONOFPATIENT"] = value; }
        }

        public object LaboratoryProcedures
        {
            get { return (object)this["LABORATORYPROCEDURES"]; }
            set { this["LABORATORYPROCEDURES"] = value; }
        }

    /// <summary>
    /// Bilinci
    /// </summary>
        public AwarenessEnum? Awareness
        {
            get { return (AwarenessEnum?)(int?)this["AWARENESS"]; }
            set { this["AWARENESS"] = value; }
        }

    /// <summary>
    /// Pupiller
    /// </summary>
        public PupilPropertiesEnum? PupilProperties
        {
            get { return (PupilPropertiesEnum?)(int?)this["PUPILPROPERTIES"]; }
            set { this["PUPILPROPERTIES"] = value; }
        }

    /// <summary>
    /// Işık Refleksi
    /// </summary>
        public LightReflexEnum? LightReflex
        {
            get { return (LightReflexEnum?)(int?)this["LIGHTREFLEX"]; }
            set { this["LIGHTREFLEX"] = value; }
        }

    /// <summary>
    /// Tendon Refleksi
    /// </summary>
        public TendonReflexesEnum? TendonReflexes
        {
            get { return (TendonReflexesEnum?)(int?)this["TENDONREFLEXES"]; }
            set { this["TENDONREFLEXES"] = value; }
        }

    /// <summary>
    /// Psikopatolojik bulgu bulunmadı
    /// </summary>
        public bool? NoEvidancePsycho
        {
            get { return (bool?)this["NOEVIDANCEPSYCHO"]; }
            set { this["NOEVIDANCEPSYCHO"] = value; }
        }

    /// <summary>
    /// Psikiyatrik muayene
    /// </summary>
        public bool? PyschiatricExamination
        {
            get { return (bool?)this["PYSCHIATRICEXAMINATION"]; }
            set { this["PYSCHIATRICEXAMINATION"] = value; }
        }

    /// <summary>
    /// Muayane Tarihi
    /// </summary>
        public DateTime? ExaminationDate
        {
            get { return (DateTime?)this["EXAMINATIONDATE"]; }
            set { this["EXAMINATIONDATE"] = value; }
        }

    /// <summary>
    /// Eşlik Eden Görevlinin Adı Soyadı
    /// </summary>
        public string AttendantNameSurname
        {
            get { return (string)this["ATTENDANTNAMESURNAME"]; }
            set { this["ATTENDANTNAMESURNAME"] = value; }
        }

    /// <summary>
    /// Uygun Ortam Sağlama evet
    /// </summary>
        public bool? SuitableEnvironment1
        {
            get { return (bool?)this["SUITABLEENVIRONMENT1"]; }
            set { this["SUITABLEENVIRONMENT1"] = value; }
        }

        public bool? SuitableEnvironment2
        {
            get { return (bool?)this["SUITABLEENVIRONMENT2"]; }
            set { this["SUITABLEENVIRONMENT2"] = value; }
        }

        public bool? PeopleInExamination1
        {
            get { return (bool?)this["PEOPLEINEXAMINATION1"]; }
            set { this["PEOPLEINEXAMINATION1"] = value; }
        }

        public bool? PeopleInExamination2
        {
            get { return (bool?)this["PEOPLEINEXAMINATION2"]; }
            set { this["PEOPLEINEXAMINATION2"] = value; }
        }

        public bool? PeopleInExamination3
        {
            get { return (bool?)this["PEOPLEINEXAMINATION3"]; }
            set { this["PEOPLEINEXAMINATION3"] = value; }
        }

        public bool? PeopleInExamination4
        {
            get { return (bool?)this["PEOPLEINEXAMINATION4"]; }
            set { this["PEOPLEINEXAMINATION4"] = value; }
        }

        public bool? ClothesOfPatient1
        {
            get { return (bool?)this["CLOTHESOFPATIENT1"]; }
            set { this["CLOTHESOFPATIENT1"] = value; }
        }

        public bool? ClothesOfPatient2
        {
            get { return (bool?)this["CLOTHESOFPATIENT2"]; }
            set { this["CLOTHESOFPATIENT2"] = value; }
        }

        public bool? ClothesOfPatient3
        {
            get { return (bool?)this["CLOTHESOFPATIENT3"]; }
            set { this["CLOTHESOFPATIENT3"] = value; }
        }

        public bool? ChkLabProcedures
        {
            get { return (bool?)this["CHKLABPROCEDURES"]; }
            set { this["CHKLABPROCEDURES"] = value; }
        }

        public bool? ChkDirectGraph
        {
            get { return (bool?)this["CHKDIRECTGRAPH"]; }
            set { this["CHKDIRECTGRAPH"] = value; }
        }

        public bool? ChkBTMR
        {
            get { return (bool?)this["CHKBTMR"]; }
            set { this["CHKBTMR"] = value; }
        }

        public bool? ChkUltrasonography
        {
            get { return (bool?)this["CHKULTRASONOGRAPHY"]; }
            set { this["CHKULTRASONOGRAPHY"] = value; }
        }

        public bool? ChkBiopsy
        {
            get { return (bool?)this["CHKBIOPSY"]; }
            set { this["CHKBIOPSY"] = value; }
        }

        public bool? ChkOther
        {
            get { return (bool?)this["CHKOTHER"]; }
            set { this["CHKOTHER"] = value; }
        }

        public string Attaches2Text
        {
            get { return (string)this["ATTACHES2TEXT"]; }
            set { this["ATTACHES2TEXT"] = value; }
        }

        public string Attaches3Text1
        {
            get { return (string)this["ATTACHES3TEXT1"]; }
            set { this["ATTACHES3TEXT1"] = value; }
        }

        public string Attaches3Text2
        {
            get { return (string)this["ATTACHES3TEXT2"]; }
            set { this["ATTACHES3TEXT2"] = value; }
        }

        public bool? UncertainReport
        {
            get { return (bool?)this["UNCERTAINREPORT"]; }
            set { this["UNCERTAINREPORT"] = value; }
        }

        public bool? CertainReport
        {
            get { return (bool?)this["CERTAINREPORT"]; }
            set { this["CERTAINREPORT"] = value; }
        }

        public MedicalReportTypeEnum? ReportType
        {
            get { return (MedicalReportTypeEnum?)(int?)this["REPORTTYPE"]; }
            set { this["REPORTTYPE"] = value; }
        }

    /// <summary>
    /// Gönderen  Makam
    /// </summary>
        public MilitaryUnit SenderChair
        {
            get { return (MilitaryUnit)((ITTObject)this).GetParent("SENDERCHAIR"); }
            set { this["SENDERCHAIR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Sorumlu Kisi
    /// </summary>
        public ResUser ResUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("RESUSER"); }
            set { this["RESUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateLabMenusCollection()
        {
            _LabMenus = new ForensicReportLabMenuGrid.ChildForensicReportLabMenuGridCollection(this, new Guid("aad5cf1b-5ec9-4538-b1f3-3dd22923e53e"));
            ((ITTChildObjectCollection)_LabMenus).GetChildren();
        }

        protected ForensicReportLabMenuGrid.ChildForensicReportLabMenuGridCollection _LabMenus = null;
        public ForensicReportLabMenuGrid.ChildForensicReportLabMenuGridCollection LabMenus
        {
            get
            {
                if (_LabMenus == null)
                    CreateLabMenusCollection();
                return _LabMenus;
            }
        }

        override protected void CreateSubactionProceduresCollectionViews()
        {
            base.CreateSubactionProceduresCollectionViews();
            _ForensicMedicalReportProcedures = new ForensicMedicalReportProcedure.ChildForensicMedicalReportProcedureCollection(_SubactionProcedures, "ForensicMedicalReportProcedures");
        }

        private ForensicMedicalReportProcedure.ChildForensicMedicalReportProcedureCollection _ForensicMedicalReportProcedures = null;
        public ForensicMedicalReportProcedure.ChildForensicMedicalReportProcedureCollection ForensicMedicalReportProcedures
        {
            get
            {
                if (_SubactionProcedures == null)
                    CreateSubactionProceduresCollection();
                return _ForensicMedicalReportProcedures;
            }            
        }

        protected ForensicMedicalReport(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ForensicMedicalReport(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ForensicMedicalReport(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ForensicMedicalReport(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ForensicMedicalReport(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "FORENSICMEDICALREPORT", dataRow) { }
        protected ForensicMedicalReport(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "FORENSICMEDICALREPORT", dataRow, isImported) { }
        public ForensicMedicalReport(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ForensicMedicalReport(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ForensicMedicalReport() : base() { }

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
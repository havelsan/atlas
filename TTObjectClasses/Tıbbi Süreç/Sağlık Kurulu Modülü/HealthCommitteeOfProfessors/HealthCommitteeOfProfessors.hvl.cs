
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HealthCommitteeOfProfessors")] 

    /// <summary>
    /// Profesörler Sağlık Kurulu İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
    public  partial class HealthCommitteeOfProfessors : BaseHealthCommittee, IPatientWorkList, IAppointmentDef
    {
        public class HealthCommitteeOfProfessorsList : TTObjectCollection<HealthCommitteeOfProfessors> { }
                    
        public class ChildHealthCommitteeOfProfessorsCollection : TTObject.TTChildObjectCollection<HealthCommitteeOfProfessors>
        {
            public ChildHealthCommitteeOfProfessorsCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHealthCommitteeOfProfessorsCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetHealthCommitteeOfProfessors_Class : TTReportNqlObject 
        {
            public string Makam
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MAKAM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CONFIRMATIONUNITDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? Islemno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISLEMNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEOFPROFESSORS"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public long? Pid
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Pname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["NAME"].DataType;
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

            public string Anaadi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ANAADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["MOTHERNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Dtarihi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["DTARIHI"]);
                }
            }

            public Object Dogumyeri
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["DOGUMYERI"]);
                }
            }

            public DateTime? Muayenetarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MUAYENETARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEOFPROFESSORS"].AllPropertyDefs["HEALTHCOMMITTEESTARTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public int? Muamelesayisi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MUAMELESAYISI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEOFPROFESSORS"].AllPropertyDefs["NUMBEROFPROCEDURE"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string Bolum
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BOLUM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? Boy
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BOY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEOFPROFESSORS"].AllPropertyDefs["HEIGHT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? Kilo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KILO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEOFPROFESSORS"].AllPropertyDefs["WEIGHT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public long? Raporno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RAPORNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEOFPROFESSORS"].AllPropertyDefs["REPORTNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? Raportarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RAPORTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEOFPROFESSORS"].AllPropertyDefs["REPORTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Psurname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PSURNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["SURNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? Tcno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TCNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["UNIQUEREFNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public long? Protokolno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROTOKOLNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEOFPROFESSORS"].AllPropertyDefs["PROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? Adate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEOFPROFESSORS"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Evraksayisi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EVRAKSAYISI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEOFPROFESSORS"].AllPropertyDefs["DOCUMENTNUMBER"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEOFPROFESSORS"].AllPropertyDefs["DOCUMENTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public object Karar
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KARAR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEOFPROFESSORS"].AllPropertyDefs["DECISION"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public Object Adres
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["ADRES"]);
                }
            }

            public long? Kprokolno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KPROKOLNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["QUARANTINEPROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? Hgtarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HGTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["OPENINGDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? Taburcutarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TABURCUTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["HOSPITALDISCHARGEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Fresource
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FRESOURCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetHealthCommitteeOfProfessors_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetHealthCommitteeOfProfessors_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetHealthCommitteeOfProfessors_Class() : base() { }
        }

        [Serializable] 

        public partial class GetAllHealthCommitteeOfProfessors_Class : TTReportNqlObject 
        {
            public string Makam
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MAKAM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CONFIRMATIONUNITDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? Islemno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISLEMNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEOFPROFESSORS"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public long? Pid
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Pname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Ttobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["TTOBJECTID"]);
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

            public string Anaadi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ANAADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["MOTHERNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Episode
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODE"]);
                }
            }

            public Object Dtarihi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["DTARIHI"]);
                }
            }

            public Object Dogumyeri
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["DOGUMYERI"]);
                }
            }

            public DateTime? Muayenetarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MUAYENETARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEOFPROFESSORS"].AllPropertyDefs["HEALTHCOMMITTEESTARTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public int? Muamelesayisi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MUAMELESAYISI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEOFPROFESSORS"].AllPropertyDefs["NUMBEROFPROCEDURE"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string Bolum
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BOLUM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? Boy
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BOY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEOFPROFESSORS"].AllPropertyDefs["HEIGHT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? Kilo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KILO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEOFPROFESSORS"].AllPropertyDefs["WEIGHT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public long? Raporno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RAPORNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEOFPROFESSORS"].AllPropertyDefs["REPORTNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? Raportarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RAPORTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEOFPROFESSORS"].AllPropertyDefs["REPORTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Psurname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PSURNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["SURNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? Tcno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TCNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["UNIQUEREFNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public long? Protokolno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROTOKOLNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEOFPROFESSORS"].AllPropertyDefs["PROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? Adate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEOFPROFESSORS"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Evraksayisi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EVRAKSAYISI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEOFPROFESSORS"].AllPropertyDefs["DOCUMENTNUMBER"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEOFPROFESSORS"].AllPropertyDefs["DOCUMENTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public object Karar
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KARAR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEOFPROFESSORS"].AllPropertyDefs["DECISION"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public Object Adres
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["ADRES"]);
                }
            }

            public long? Kprokolno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KPROKOLNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["QUARANTINEPROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? Hgtarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HGTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["OPENINGDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? Taburcutarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TABURCUTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["HOSPITALDISCHARGEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Fresource
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FRESOURCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetAllHealthCommitteeOfProfessors_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetAllHealthCommitteeOfProfessors_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetAllHealthCommitteeOfProfessors_Class() : base() { }
        }

        public static class States
        {
            public static Guid RequestApproval { get { return new Guid("cc95ea76-e219-410e-a0e8-1e1cf4f695c5"); } }
    /// <summary>
    /// Sekreterde
    /// </summary>
            public static Guid SecretaryRegistration { get { return new Guid("5b970079-12a4-4958-a31b-1c01b14fdf69"); } }
            public static Guid CommitteeExamination { get { return new Guid("f468833b-cf96-4812-9bec-375fdb28668b"); } }
            public static Guid ReportApproval { get { return new Guid("cb6848ce-7204-4c48-844c-a3ca6bb23306"); } }
            public static Guid Request { get { return new Guid("a33ebf3d-fcb1-4b85-93ef-9e2369cac43d"); } }
            public static Guid Completed { get { return new Guid("ad67dcdd-34e9-4cb8-a072-9fe070733ccd"); } }
    /// <summary>
    /// Heyet Kabul
    /// </summary>
            public static Guid PCommitteeAcceptance { get { return new Guid("92d689b6-77c8-4af2-bf69-61a9f901d9c5"); } }
    /// <summary>
    /// Dekan Onayı
    /// </summary>
            public static Guid DeanApproval { get { return new Guid("95f81afc-741e-44ee-a434-7f5814b72722"); } }
    /// <summary>
    /// Heyet Kabul Muayenede
    /// </summary>
            public static Guid ReportOutputForSignature { get { return new Guid("de046160-af19-4d00-97a9-720aac6af158"); } }
    /// <summary>
    /// Dekan Rapor Onayı
    /// </summary>
            public static Guid DeanReportApproval { get { return new Guid("4a50589d-ffda-4969-a3f7-92161581f8eb"); } }
    /// <summary>
    /// Reddedildi
    /// </summary>
            public static Guid Rejected { get { return new Guid("7332c701-e112-481b-ae07-b3813e5695fe"); } }
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancelled { get { return new Guid("465c7f5b-8387-4641-abc8-8661c023a840"); } }
    /// <summary>
    /// İmzada
    /// </summary>
            public static Guid WaitingForSignature { get { return new Guid("8143a7d6-96e6-4de4-ac58-c324b07309e7"); } }
        }

    /// <summary>
    /// Süreçteki HealthCommitteeOfProfessors objesini ID ile get eder.
    /// </summary>
        public static BindingList<HealthCommitteeOfProfessors.GetHealthCommitteeOfProfessors_Class> GetHealthCommitteeOfProfessors(string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEOFPROFESSORS"].QueryDefs["GetHealthCommitteeOfProfessors"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<HealthCommitteeOfProfessors.GetHealthCommitteeOfProfessors_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// Süreçteki HealthCommitteeOfProfessors objesini ID ile get eder.
    /// </summary>
        public static BindingList<HealthCommitteeOfProfessors.GetHealthCommitteeOfProfessors_Class> GetHealthCommitteeOfProfessors(TTObjectContext objectContext, string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEOFPROFESSORS"].QueryDefs["GetHealthCommitteeOfProfessors"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<HealthCommitteeOfProfessors.GetHealthCommitteeOfProfessors_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<HealthCommitteeOfProfessors.GetAllHealthCommitteeOfProfessors_Class> GetAllHealthCommitteeOfProfessors(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEOFPROFESSORS"].QueryDefs["GetAllHealthCommitteeOfProfessors"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<HealthCommitteeOfProfessors.GetAllHealthCommitteeOfProfessors_Class>(queryDef, paramList, pi);
        }

        public static BindingList<HealthCommitteeOfProfessors.GetAllHealthCommitteeOfProfessors_Class> GetAllHealthCommitteeOfProfessors(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEOFPROFESSORS"].QueryDefs["GetAllHealthCommitteeOfProfessors"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<HealthCommitteeOfProfessors.GetAllHealthCommitteeOfProfessors_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Muayene Başlama Tarihi
    /// </summary>
        public DateTime? HealthCommitteeStartDate
        {
            get { return (DateTime?)this["HEALTHCOMMITTEESTARTDATE"]; }
            set { this["HEALTHCOMMITTEESTARTDATE"] = value; }
        }

    /// <summary>
    /// Protokol No
    /// </summary>
        public TTSequence ProtocolNo
        {
            get { return GetSequence("PROTOCOLNO"); }
        }

    /// <summary>
    /// Ek Rapor
    /// </summary>
        public string AdditionalReport
        {
            get { return (string)this["ADDITIONALREPORT"]; }
            set { this["ADDITIONALREPORT"] = value; }
        }

    /// <summary>
    /// Diğer Ölçümler
    /// </summary>
        public string OtherMeasurements
        {
            get { return (string)this["OTHERMEASUREMENTS"]; }
            set { this["OTHERMEASUREMENTS"] = value; }
        }

    /// <summary>
    /// Randevu Bilgisi
    /// </summary>
        public string AppointmentInfo
        {
            get { return (string)this["APPOINTMENTINFO"]; }
            set { this["APPOINTMENTINFO"] = value; }
        }

        public string RedecisionPreDiagnosis
        {
            get { return (string)this["REDECISIONPREDIAGNOSIS"]; }
            set { this["REDECISIONPREDIAGNOSIS"] = value; }
        }

    /// <summary>
    /// Muamale Sayısı
    /// </summary>
        public int? NumberOfProcedure
        {
            get { return (int?)this["NUMBEROFPROCEDURE"]; }
            set { this["NUMBEROFPROCEDURE"] = value; }
        }

    /// <summary>
    /// Red Açıklaması
    /// </summary>
        public string ExplanationOfRejection
        {
            get { return (string)this["EXPLANATIONOFREJECTION"]; }
            set { this["EXPLANATIONOFREJECTION"] = value; }
        }

    /// <summary>
    /// Oybirliği
    /// </summary>
        public bool? Unanimity
        {
            get { return (bool?)this["UNANIMITY"]; }
            set { this["UNANIMITY"] = value; }
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
    /// Rapor Tarihi
    /// </summary>
        public DateTime? ReportDate
        {
            get { return (DateTime?)this["REPORTDATE"]; }
            set { this["REPORTDATE"] = value; }
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
    /// Boy
    /// </summary>
        public int? Height
        {
            get { return (int?)this["HEIGHT"]; }
            set { this["HEIGHT"] = value; }
        }

    /// <summary>
    /// Defter No
    /// </summary>
        public long? BookNumber
        {
            get { return (long?)this["BOOKNUMBER"]; }
            set { this["BOOKNUMBER"] = value; }
        }

    /// <summary>
    /// Zeyil Kararı
    /// </summary>
        public string Redecision
        {
            get { return (string)this["REDECISION"]; }
            set { this["REDECISION"] = value; }
        }

    /// <summary>
    /// Aile Reisinin Adı
    /// </summary>
        public string HeadOfFamilyName
        {
            get { return (string)this["HEADOFFAMILYNAME"]; }
            set { this["HEADOFFAMILYNAME"] = value; }
        }

    /// <summary>
    /// Ağırlık
    /// </summary>
        public int? Weight
        {
            get { return (int?)this["WEIGHT"]; }
            set { this["WEIGHT"] = value; }
        }

    /// <summary>
    /// Rapor Numarası 
    /// </summary>
        public TTSequence ReportNo
        {
            get { return GetSequence("REPORTNO"); }
        }

    /// <summary>
    /// Karar
    /// </summary>
        public object Decision
        {
            get { return (object)this["DECISION"]; }
            set { this["DECISION"] = value; }
        }

    /// <summary>
    /// Rapor
    /// </summary>
        public object Report
        {
            get { return (object)this["REPORT"]; }
            set { this["REPORT"] = value; }
        }

    /// <summary>
    /// İstek Sebebi
    /// </summary>
        public string ReasonForRequest
        {
            get { return (string)this["REASONFORREQUEST"]; }
            set { this["REASONFORREQUEST"] = value; }
        }

    /// <summary>
    /// Muayeneye Gön. Makam
    /// </summary>
        public ConfirmationUnitDefinition ChairSentFrom
        {
            get { return (ConfirmationUnitDefinition)((ITTObject)this).GetParent("CHAIRSENTFROM"); }
            set { this["CHAIRSENTFROM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Birim(ler)
    /// </summary>
        public ResSection Department
        {
            get { return (ResSection)((ITTObject)this).GetParent("DEPARTMENT"); }
            set { this["DEPARTMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Profesörler Sağlık Kurulu Heyet Teşkili
    /// </summary>
        public MemberOfHealthCommitteeDefinition MemberOfHealthCommitteeOfProf
        {
            get { return (MemberOfHealthCommitteeDefinition)((ITTObject)this).GetParent("MEMBEROFHEALTHCOMMITTEEOFPROF"); }
            set { this["MEMBEROFHEALTHCOMMITTEEOFPROF"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Doktor
    /// </summary>
        public MemberOfHealthCommitteeDefinition Committee
        {
            get { return (MemberOfHealthCommitteeDefinition)((ITTObject)this).GetParent("COMMITTEE"); }
            set { this["COMMITTEE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Birimler
    /// </summary>
        public ResClinic ExaminationUnitsHospitals
        {
            get { return (ResClinic)((ITTObject)this).GetParent("EXAMINATIONUNITSHOSPITALS"); }
            set { this["EXAMINATIONUNITSHOSPITALS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateMemberClinicsCollection()
        {
            _MemberClinics = new HCPMemberClinicsDefinition.ChildHCPMemberClinicsDefinitionCollection(this, new Guid("3273d6b5-a92c-44c9-979f-19d9cfe9299e"));
            ((ITTChildObjectCollection)_MemberClinics).GetChildren();
        }

        protected HCPMemberClinicsDefinition.ChildHCPMemberClinicsDefinitionCollection _MemberClinics = null;
        public HCPMemberClinicsDefinition.ChildHCPMemberClinicsDefinitionCollection MemberClinics
        {
            get
            {
                if (_MemberClinics == null)
                    CreateMemberClinicsCollection();
                return _MemberClinics;
            }
        }

        virtual protected void CreateRedecisionMatterSliceAnectodesCollection()
        {
            _RedecisionMatterSliceAnectodes = new HCProfessors_RedecisionMatterSliceAnectodeGrid.ChildHCProfessors_RedecisionMatterSliceAnectodeGridCollection(this, new Guid("af3bfb0f-27a3-445e-b9fb-27bc325dc56c"));
            ((ITTChildObjectCollection)_RedecisionMatterSliceAnectodes).GetChildren();
        }

        protected HCProfessors_RedecisionMatterSliceAnectodeGrid.ChildHCProfessors_RedecisionMatterSliceAnectodeGridCollection _RedecisionMatterSliceAnectodes = null;
        public HCProfessors_RedecisionMatterSliceAnectodeGrid.ChildHCProfessors_RedecisionMatterSliceAnectodeGridCollection RedecisionMatterSliceAnectodes
        {
            get
            {
                if (_RedecisionMatterSliceAnectodes == null)
                    CreateRedecisionMatterSliceAnectodesCollection();
                return _RedecisionMatterSliceAnectodes;
            }
        }

        virtual protected void CreateRedecisionDiagnosisCollection()
        {
            _RedecisionDiagnosis = new HealthCommitteeOfProfessors_RedecisionDiagnosisGrid.ChildHealthCommitteeOfProfessors_RedecisionDiagnosisGridCollection(this, new Guid("10f76bb7-3839-4a69-b5ca-671116a3a07a"));
            ((ITTChildObjectCollection)_RedecisionDiagnosis).GetChildren();
        }

        protected HealthCommitteeOfProfessors_RedecisionDiagnosisGrid.ChildHealthCommitteeOfProfessors_RedecisionDiagnosisGridCollection _RedecisionDiagnosis = null;
        public HealthCommitteeOfProfessors_RedecisionDiagnosisGrid.ChildHealthCommitteeOfProfessors_RedecisionDiagnosisGridCollection RedecisionDiagnosis
        {
            get
            {
                if (_RedecisionDiagnosis == null)
                    CreateRedecisionDiagnosisCollection();
                return _RedecisionDiagnosis;
            }
        }

        virtual protected void CreateExplanationsofRejectionCollection()
        {
            _ExplanationsofRejection = new HealthCommitteeOfProfessors_ExplanationOfRejectionGrid.ChildHealthCommitteeOfProfessors_ExplanationOfRejectionGridCollection(this, new Guid("55b25bc5-def3-414c-9ad3-7d172359b39a"));
            ((ITTChildObjectCollection)_ExplanationsofRejection).GetChildren();
        }

        protected HealthCommitteeOfProfessors_ExplanationOfRejectionGrid.ChildHealthCommitteeOfProfessors_ExplanationOfRejectionGridCollection _ExplanationsofRejection = null;
        public HealthCommitteeOfProfessors_ExplanationOfRejectionGrid.ChildHealthCommitteeOfProfessors_ExplanationOfRejectionGridCollection ExplanationsofRejection
        {
            get
            {
                if (_ExplanationsofRejection == null)
                    CreateExplanationsofRejectionCollection();
                return _ExplanationsofRejection;
            }
        }

        virtual protected void CreateMatterSliceAnectodesCollection()
        {
            _MatterSliceAnectodes = new HealthCommitteeOfProfessors_MatterSliceAnectodeGrid.ChildHealthCommitteeOfProfessors_MatterSliceAnectodeGridCollection(this, new Guid("1d15d76e-ba91-4b19-bf15-9195b0b2d946"));
            ((ITTChildObjectCollection)_MatterSliceAnectodes).GetChildren();
        }

        protected HealthCommitteeOfProfessors_MatterSliceAnectodeGrid.ChildHealthCommitteeOfProfessors_MatterSliceAnectodeGridCollection _MatterSliceAnectodes = null;
        public HealthCommitteeOfProfessors_MatterSliceAnectodeGrid.ChildHealthCommitteeOfProfessors_MatterSliceAnectodeGridCollection MatterSliceAnectodes
        {
            get
            {
                if (_MatterSliceAnectodes == null)
                    CreateMatterSliceAnectodesCollection();
                return _MatterSliceAnectodes;
            }
        }

        virtual protected void CreateReturnDescriptionsCollection()
        {
            _ReturnDescriptions = new HealthCommittee_ReturnDescriptionsGrid.ChildHealthCommittee_ReturnDescriptionsGridCollection(this, new Guid("8e3e2441-1761-493a-bcc7-70ed1d388b66"));
            ((ITTChildObjectCollection)_ReturnDescriptions).GetChildren();
        }

        protected HealthCommittee_ReturnDescriptionsGrid.ChildHealthCommittee_ReturnDescriptionsGridCollection _ReturnDescriptions = null;
        public HealthCommittee_ReturnDescriptionsGrid.ChildHealthCommittee_ReturnDescriptionsGridCollection ReturnDescriptions
        {
            get
            {
                if (_ReturnDescriptions == null)
                    CreateReturnDescriptionsCollection();
                return _ReturnDescriptions;
            }
        }

        virtual protected void CreateHCPMatterSliceAnectodesCollection()
        {
            _HCPMatterSliceAnectodes = new HCMatterSliceAnectodeDefinitionGrid.ChildHCMatterSliceAnectodeDefinitionGridCollection(this, new Guid("942c2b5b-3ecd-452c-9c77-defdf7f8723e"));
            ((ITTChildObjectCollection)_HCPMatterSliceAnectodes).GetChildren();
        }

        protected HCMatterSliceAnectodeDefinitionGrid.ChildHCMatterSliceAnectodeDefinitionGridCollection _HCPMatterSliceAnectodes = null;
        public HCMatterSliceAnectodeDefinitionGrid.ChildHCMatterSliceAnectodeDefinitionGridCollection HCPMatterSliceAnectodes
        {
            get
            {
                if (_HCPMatterSliceAnectodes == null)
                    CreateHCPMatterSliceAnectodesCollection();
                return _HCPMatterSliceAnectodes;
            }
        }

        protected HealthCommitteeOfProfessors(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HealthCommitteeOfProfessors(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HealthCommitteeOfProfessors(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HealthCommitteeOfProfessors(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HealthCommitteeOfProfessors(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HEALTHCOMMITTEEOFPROFESSORS", dataRow) { }
        protected HealthCommitteeOfProfessors(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HEALTHCOMMITTEEOFPROFESSORS", dataRow, isImported) { }
        public HealthCommitteeOfProfessors(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HealthCommitteeOfProfessors(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HealthCommitteeOfProfessors() : base() { }

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
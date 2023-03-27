
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HealthCommittee")] 

    /// <summary>
    /// Sağlık Kurulu İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
    public  partial class HealthCommittee : BaseHealthCommittee, IPatientWorkList, IWorkListHealthCommittee, IAppointmentDef, IOAHealthCommittee, ICreateSubEpisode
    {
        public class HealthCommitteeList : TTObjectCollection<HealthCommittee> { }
                    
        public class ChildHealthCommitteeCollection : TTObject.TTChildObjectCollection<HealthCommittee>
        {
            public ChildHealthCommitteeCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHealthCommitteeCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetCurrentHealthCommittee_Class : TTReportNqlObject 
        {
            public Guid? Healthcommitteeobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["HEALTHCOMMITTEEOBJECTID"]);
                }
            }

            public DateTime? NasbiTarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NASBITARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].AllPropertyDefs["NASBITARIHI"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public long? Islemno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISLEMNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].AllPropertyDefs["ID"].DataType;
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

            public double? ForeignUniqueRefNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FOREIGNUNIQUEREFNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["FOREIGNUNIQUEREFNO"].DataType;
                    return (double?)dataType.ConvertValue(val);
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

            public Object Dogumyeriilce
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["DOGUMYERIILCE"]);
                }
            }

            public Object Dogumyeriulke
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["DOGUMYERIULKE"]);
                }
            }

            public DateTime? Muayenetarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MUAYENETARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].AllPropertyDefs["HEALTHCOMMITTEESTARTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].AllPropertyDefs["NUMBEROFPROCEDURE"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string Sksebebi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SKSEBEBI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REASONFOREXAMINATIONDEFINITION"].AllPropertyDefs["REASON"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public double? Boy
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BOY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].AllPropertyDefs["CLINICHEIGHT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public int? Kilo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KILO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].AllPropertyDefs["CLINICWEIGHT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public double? Heyetboy
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HEYETBOY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].AllPropertyDefs["HCHEIGHT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public double? Heyetkilo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HEYETKILO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].AllPropertyDefs["HCWEIGHT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public long? Raporno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RAPORNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].AllPropertyDefs["REPORTNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].AllPropertyDefs["REPORTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].AllPropertyDefs["PROTOCOLNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].AllPropertyDefs["ACTIONDATE"].DataType;
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

            public Object Adres
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["ADRES"]);
                }
            }

            public Object Ilce
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["ILCE"]);
                }
            }

            public Object Il
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["IL"]);
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

            public Guid? Ucaktipi
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["UCAKTIPI"]);
                }
            }

            public Guid? Gorev
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["GOREV"]);
                }
            }

            public GetCurrentHealthCommittee_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetCurrentHealthCommittee_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetCurrentHealthCommittee_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetHealthCommitteeByEpisode_Class : TTReportNqlObject 
        {
            public Object Committeecount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["COMMITTEECOUNT"]);
                }
            }

            public OLAP_GetHealthCommitteeByEpisode_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetHealthCommitteeByEpisode_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetHealthCommitteeByEpisode_Class() : base() { }
        }

        [Serializable] 

        public partial class GetHealthCommittees_Class : TTReportNqlObject 
        {
            public Guid? Healthcommitteeobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["HEALTHCOMMITTEEOBJECTID"]);
                }
            }

            public long? Islemno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISLEMNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].AllPropertyDefs["ID"].DataType;
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

            public DateTime? Dtarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["BIRTHDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].AllPropertyDefs["HEALTHCOMMITTEESTARTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].AllPropertyDefs["NUMBEROFPROCEDURE"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string Sksebebi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SKSEBEBI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REASONFOREXAMINATIONDEFINITION"].AllPropertyDefs["REASON"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public double? Boy
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BOY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].AllPropertyDefs["CLINICHEIGHT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public int? Kilo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KILO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].AllPropertyDefs["CLINICWEIGHT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].AllPropertyDefs["REPORTNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].AllPropertyDefs["REPORTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].AllPropertyDefs["PROTOCOLNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].AllPropertyDefs["ACTIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].AllPropertyDefs["DOCUMENTNUMBER"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].AllPropertyDefs["DOCUMENTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
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

            public GetHealthCommittees_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetHealthCommittees_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetHealthCommittees_Class() : base() { }
        }

        [Serializable] 

        public partial class GetXXXXXXApprovalHCsByDate_Class : TTReportNqlObject 
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

            public long? ReportNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].AllPropertyDefs["REPORTNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ReportDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].AllPropertyDefs["REPORTDATE"].DataType;
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

            public Guid? Ttobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["TTOBJECTID"]);
                }
            }

            public Object Patientgroup
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PATIENTGROUP"]);
                }
            }

            public GetXXXXXXApprovalHCsByDate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetXXXXXXApprovalHCsByDate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetXXXXXXApprovalHCsByDate_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetCancelledHealthCommittees_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
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

            public DateTime? ReportDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].AllPropertyDefs["REPORTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public OLAP_GetCancelledHealthCommittees_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetCancelledHealthCommittees_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetCancelledHealthCommittees_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetHealthCommittesByDate_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public DateTime? ReportDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].AllPropertyDefs["REPORTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? RequestDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? Episode
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODE"]);
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

            public int? NumberOfProcedure
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NUMBEROFPROCEDURE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].AllPropertyDefs["NUMBEROFPROCEDURE"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public Guid? Reasonofhc
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["REASONOFHC"]);
                }
            }

            public Object Statestatus
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["STATESTATUS"]);
                }
            }

            public object HealthCommitteeDecision
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HEALTHCOMMITTEEDECISION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].AllPropertyDefs["HEALTHCOMMITTEEDECISION"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public OLAP_GetHealthCommittesByDate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetHealthCommittesByDate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetHealthCommittesByDate_Class() : base() { }
        }

        [Serializable] 

        public partial class GetHCsByDateAndUniqueRefNo_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].AllPropertyDefs["ID"].DataType;
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

            public long? ReportNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].AllPropertyDefs["REPORTNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ReportDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].AllPropertyDefs["REPORTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetHCsByDateAndUniqueRefNo_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetHCsByDateAndUniqueRefNo_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetHCsByDateAndUniqueRefNo_Class() : base() { }
        }

        [Serializable] 

        public partial class GetMSBApprovalHCsByDate_Class : TTReportNqlObject 
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

            public long? ReportNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].AllPropertyDefs["REPORTNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ReportDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].AllPropertyDefs["REPORTDATE"].DataType;
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

            public Guid? Ttobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["TTOBJECTID"]);
                }
            }

            public Object Patientgroup
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PATIENTGROUP"]);
                }
            }

            public GetMSBApprovalHCsByDate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMSBApprovalHCsByDate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMSBApprovalHCsByDate_Class() : base() { }
        }

        [Serializable] 

        public partial class GetHCReportGroupNameByPatient_Class : TTReportNqlObject 
        {
            public string ReportGroupName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTGROUPNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HCREPORTTYPEDEFINITION"].AllPropertyDefs["REPORTGROUPNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetHCReportGroupNameByPatient_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetHCReportGroupNameByPatient_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetHCReportGroupNameByPatient_Class() : base() { }
        }

        [Serializable] 

        public partial class GetHealthCommitteesByDate_Class : TTReportNqlObject 
        {
            public Guid? Healthcommitteeobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["HEALTHCOMMITTEEOBJECTID"]);
                }
            }

            public long? Islemno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISLEMNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].AllPropertyDefs["ID"].DataType;
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

            public DateTime? Dtarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["BIRTHDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].AllPropertyDefs["HEALTHCOMMITTEESTARTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].AllPropertyDefs["NUMBEROFPROCEDURE"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string Sksebebi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SKSEBEBI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REASONFOREXAMINATIONDEFINITION"].AllPropertyDefs["REASON"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public double? Boy
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BOY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].AllPropertyDefs["CLINICHEIGHT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public int? Kilo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KILO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].AllPropertyDefs["CLINICWEIGHT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].AllPropertyDefs["REPORTNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].AllPropertyDefs["REPORTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].AllPropertyDefs["PROTOCOLNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].AllPropertyDefs["ACTIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].AllPropertyDefs["DOCUMENTNUMBER"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].AllPropertyDefs["DOCUMENTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
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

            public Object Dogumyeriilce
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["DOGUMYERIILCE"]);
                }
            }

            public Object Dogumyeriulke
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["DOGUMYERIULKE"]);
                }
            }

            public GetHealthCommitteesByDate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetHealthCommitteesByDate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetHealthCommitteesByDate_Class() : base() { }
        }

        [Serializable] 

        public partial class GetHcBySlice_Class : TTReportNqlObject 
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

            public int? Matter
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATTER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE_MATTERSLICEANECTODEGRID"].AllPropertyDefs["MATTER"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public SliceEnum? Slice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SLICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE_MATTERSLICEANECTODEGRID"].AllPropertyDefs["SLICE"].DataType;
                    return (SliceEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public int? Anectode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ANECTODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE_MATTERSLICEANECTODEGRID"].AllPropertyDefs["ANECTODE"].DataType;
                    return (int?)dataType.ConvertValue(val);
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

            public DateTime? ReportDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].AllPropertyDefs["REPORTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].AllPropertyDefs["REPORTNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public GetHcBySlice_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetHcBySlice_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetHcBySlice_Class() : base() { }
        }

        [Serializable] 

        public partial class GetNotCollectedInvoicableHealthCommitteeRQ_Class : TTReportNqlObject 
        {
            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public GetNotCollectedInvoicableHealthCommitteeRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetNotCollectedInvoicableHealthCommitteeRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetNotCollectedInvoicableHealthCommitteeRQ_Class() : base() { }
        }

        [Serializable] 

        public partial class GetHealthCommitteesByType_Class : TTReportNqlObject 
        {
            public Guid? Healthcommitteeobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["HEALTHCOMMITTEEOBJECTID"]);
                }
            }

            public long? Islemno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISLEMNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].AllPropertyDefs["ID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].AllPropertyDefs["HEALTHCOMMITTEESTARTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].AllPropertyDefs["NUMBEROFPROCEDURE"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string Sksebebi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SKSEBEBI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REASONFOREXAMINATIONDEFINITION"].AllPropertyDefs["REASON"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public double? Boy
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BOY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].AllPropertyDefs["CLINICHEIGHT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public int? Kilo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KILO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].AllPropertyDefs["CLINICWEIGHT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].AllPropertyDefs["REPORTNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].AllPropertyDefs["REPORTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].AllPropertyDefs["PROTOCOLNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].AllPropertyDefs["ACTIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].AllPropertyDefs["DOCUMENTNUMBER"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].AllPropertyDefs["DOCUMENTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
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

            public string Dogumyeriilce
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOGUMYERIILCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TOWNDEFINITIONS"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Dogumyeriulke
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["DOGUMYERIULKE"]);
                }
            }

            public GetHealthCommitteesByType_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetHealthCommitteesByType_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetHealthCommitteesByType_Class() : base() { }
        }

        [Serializable] 

        public partial class GetHCsForPeriodicExaminationResultReport_Class : TTReportNqlObject 
        {
            public string Adi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Soyadi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SOYADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["SURNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? Raportarih
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RAPORTARIH"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].AllPropertyDefs["REPORTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public long? Raporno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RAPORNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].AllPropertyDefs["REPORTNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public Guid? Ttobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["TTOBJECTID"]);
                }
            }

            public GetHCsForPeriodicExaminationResultReport_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetHCsForPeriodicExaminationResultReport_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetHCsForPeriodicExaminationResultReport_Class() : base() { }
        }

        [Serializable] 

        public partial class GetHCsForAdditionalReport_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Reason
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REASON"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REASONFOREXAMINATIONDEFINITION"].AllPropertyDefs["REASON"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetHCsForAdditionalReport_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetHCsForAdditionalReport_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetHCsForAdditionalReport_Class() : base() { }
        }

        [Serializable] 

        public partial class GetSuccessfulHCsByDateTypePatientGroup_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
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

            public long? Hprotokolno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HPROTOKOLNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["HOSPITALPROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public HealthCommitteeTypeEnum? Sktipi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SKTIPI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REASONFOREXAMINATIONDEFINITION"].AllPropertyDefs["HEALTHCOMMITTEETYPE"].DataType;
                    return (HealthCommitteeTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public Object Hastagrubu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["HASTAGRUBU"]);
                }
            }

            public long? Raporno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RAPORNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].AllPropertyDefs["REPORTNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].AllPropertyDefs["REPORTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Object Basaridurumu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["BASARIDURUMU"]);
                }
            }

            public GetSuccessfulHCsByDateTypePatientGroup_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSuccessfulHCsByDateTypePatientGroup_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSuccessfulHCsByDateTypePatientGroup_Class() : base() { }
        }

        [Serializable] 

        public partial class GetUnsuccessfulHCsByDateTypePatientGroup_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
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

            public long? Hprotokolno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HPROTOKOLNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["HOSPITALPROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public HealthCommitteeTypeEnum? Sktipi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SKTIPI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REASONFOREXAMINATIONDEFINITION"].AllPropertyDefs["HEALTHCOMMITTEETYPE"].DataType;
                    return (HealthCommitteeTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public Object Hastagrubu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["HASTAGRUBU"]);
                }
            }

            public long? Raporno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RAPORNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].AllPropertyDefs["REPORTNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].AllPropertyDefs["REPORTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Object Basaridurumu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["BASARIDURUMU"]);
                }
            }

            public GetUnsuccessfulHCsByDateTypePatientGroup_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetUnsuccessfulHCsByDateTypePatientGroup_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetUnsuccessfulHCsByDateTypePatientGroup_Class() : base() { }
        }

        [Serializable] 

        public partial class GetHealthCommitteeByObjectID_Class : TTReportNqlObject 
        {
            public Guid? Healthcommitteeobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["HEALTHCOMMITTEEOBJECTID"]);
                }
            }

            public double? ForeignUniqueRefNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FOREIGNUNIQUEREFNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["FOREIGNUNIQUEREFNO"].DataType;
                    return (double?)dataType.ConvertValue(val);
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

            public object Foto
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FOTO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["PHOTO"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public DateTime? Dtarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["BIRTHDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? Dyeri
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DYERI"]);
                }
            }

            public string Ceptel
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CEPTEL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTIDENTITYANDADDRESS"].AllPropertyDefs["MOBILEPHONE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Adres
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADRES"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTIDENTITYANDADDRESS"].AllPropertyDefs["HOMEADDRESS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Kurum
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["KURUM"]);
                }
            }

            public DateTime? Muayenetarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MUAYENETARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].AllPropertyDefs["HEALTHCOMMITTEESTARTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].AllPropertyDefs["NUMBEROFPROCEDURE"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string Sksebebi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SKSEBEBI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REASONFOREXAMINATIONDEFINITION"].AllPropertyDefs["REASON"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public string Klinikbulgular
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KLINIKBULGULAR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].AllPropertyDefs["CLINICALFINDINGS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public object Tani
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TANI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].AllPropertyDefs["REPORTDIAGNOSE"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public object Karar
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KARAR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].AllPropertyDefs["HEALTHCOMMITTEEDECISION"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public SendExaminationEnum? Muayeneyegonderen
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MUAYENEYEGONDEREN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].AllPropertyDefs["SENDEXAMINATION"].DataType;
                    return (SendExaminationEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public long? Raporno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RAPORNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].AllPropertyDefs["REPORTNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public LargeMajorityUnanimityEnum? Oydurumu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OYDURUMU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].AllPropertyDefs["UNANIMITY"].DataType;
                    return (LargeMajorityUnanimityEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public double? Engelorani
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ENGELORANI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].AllPropertyDefs["FUNCTIONRATIO"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public bool? Agirengelli
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AGIRENGELLI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].AllPropertyDefs["ISHEAVYDISABLED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public int? Gecerliliksuresi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GECERLILIKSURESI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].AllPropertyDefs["HCDECISIONTIME"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public UnitOfTimeEnum? Gecerliliksuretipi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GECERLILIKSURETIPI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].AllPropertyDefs["HCDECISIONUNITOFTIME"].DataType;
                    return (UnitOfTimeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Calistirilamayacagiisniteligi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CALISTIRILAMAYACAGIISNITELIGI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].AllPropertyDefs["QULITYOFUNEMPLOYABLEWORKS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public double? Boy
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BOY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].AllPropertyDefs["CLINICHEIGHT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public int? Kilo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KILO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].AllPropertyDefs["CLINICWEIGHT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public double? Heyetboy
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HEYETBOY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].AllPropertyDefs["HCHEIGHT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public double? Heyetkilo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HEYETKILO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].AllPropertyDefs["HCWEIGHT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public DateTime? Raportarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RAPORTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].AllPropertyDefs["REPORTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].AllPropertyDefs["PROTOCOLNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].AllPropertyDefs["ACTIONDATE"].DataType;
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

            public DateTime? Yatistarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["YATISTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["HOSPITALINPATIENTDATE"].DataType;
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

            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public long? BookNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BOOKNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].AllPropertyDefs["BOOKNUMBER"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public GetHealthCommitteeByObjectID_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetHealthCommitteeByObjectID_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetHealthCommitteeByObjectID_Class() : base() { }
        }

        [Serializable] 

        public partial class HasSameHCExamForSameReason_Class : TTReportNqlObject 
        {
            public Object Recordcount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["RECORDCOUNT"]);
                }
            }

            public HasSameHCExamForSameReason_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public HasSameHCExamForSameReason_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected HasSameHCExamForSameReason_Class() : base() { }
        }

        [Serializable] 

        public partial class GetHealthCommitteeForWL_Class : TTReportNqlObject 
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

            public string ReasonOfCancel
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REASONOFCANCEL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].AllPropertyDefs["REASONOFCANCEL"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? Isemergency
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISEMERGENCY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].AllPropertyDefs["EMERGENCY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
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

            public DateTime? Date
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].AllPropertyDefs["REQUESTDATE"].DataType;
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

            public Guid? CurrentStateDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENTSTATEDEFID"]);
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

            public string Fromresource
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FROMRESOURCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public GetHealthCommitteeForWL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetHealthCommitteeForWL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetHealthCommitteeForWL_Class() : base() { }
        }

        public static class States
        {
            public static Guid New { get { return new Guid("c2b49309-ec10-4dae-96ef-45bd4eba3cdd"); } }
            public static Guid CommitteeAcceptance { get { return new Guid("5acdb0bb-008b-4f2d-a344-671b9d690bda"); } }
    /// <summary>
    /// Rapor
    /// </summary>
            public static Guid Report { get { return new Guid("ae75f465-c036-4456-a8e7-f761cf29c7f4"); } }
    /// <summary>
    /// İptal State i
    /// </summary>
            public static Guid Cancelled { get { return new Guid("bf880c74-c999-4dac-b1c8-d6e25fede66f"); } }
    /// <summary>
    /// Randevu
    /// </summary>
            public static Guid Appointment { get { return new Guid("e1fcaee9-a60e-4e2b-b951-b918312081be"); } }
            public static Guid Completed { get { return new Guid("7770d573-a09f-42c7-99fc-f955aa2e73ba"); } }
        }

        public static BindingList<HealthCommittee.GetCurrentHealthCommittee_Class> GetCurrentHealthCommittee(Guid OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].QueryDefs["GetCurrentHealthCommittee"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<HealthCommittee.GetCurrentHealthCommittee_Class>(queryDef, paramList, pi);
        }

        public static BindingList<HealthCommittee.GetCurrentHealthCommittee_Class> GetCurrentHealthCommittee(TTObjectContext objectContext, Guid OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].QueryDefs["GetCurrentHealthCommittee"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<HealthCommittee.GetCurrentHealthCommittee_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<HealthCommittee.OLAP_GetHealthCommitteeByEpisode_Class> OLAP_GetHealthCommitteeByEpisode(string EPISODEID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].QueryDefs["OLAP_GetHealthCommitteeByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODEID", EPISODEID);

            return TTReportNqlObject.QueryObjects<HealthCommittee.OLAP_GetHealthCommitteeByEpisode_Class>(queryDef, paramList, pi);
        }

        public static BindingList<HealthCommittee.OLAP_GetHealthCommitteeByEpisode_Class> OLAP_GetHealthCommitteeByEpisode(TTObjectContext objectContext, string EPISODEID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].QueryDefs["OLAP_GetHealthCommitteeByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODEID", EPISODEID);

            return TTReportNqlObject.QueryObjects<HealthCommittee.OLAP_GetHealthCommitteeByEpisode_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<HealthCommittee.GetHealthCommittees_Class> GetHealthCommittees(DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].QueryDefs["GetHealthCommittees"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<HealthCommittee.GetHealthCommittees_Class>(queryDef, paramList, pi);
        }

        public static BindingList<HealthCommittee.GetHealthCommittees_Class> GetHealthCommittees(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].QueryDefs["GetHealthCommittees"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<HealthCommittee.GetHealthCommittees_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<HealthCommittee> GetAllHealthCommiteesOfPatient(TTObjectContext objectContext, string PATIENTOBJECTID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].QueryDefs["GetAllHealthCommiteesOfPatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENTOBJECTID", PATIENTOBJECTID);

            return ((ITTQuery)objectContext).QueryObjects<HealthCommittee>(queryDef, paramList);
        }

        public static BindingList<HealthCommittee.GetXXXXXXApprovalHCsByDate_Class> GetXXXXXXApprovalHCsByDate(DateTime PARAMSTARTDATE, DateTime PARAMENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].QueryDefs["GetXXXXXXApprovalHCsByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMSTARTDATE", PARAMSTARTDATE);
            paramList.Add("PARAMENDDATE", PARAMENDDATE);

            return TTReportNqlObject.QueryObjects<HealthCommittee.GetXXXXXXApprovalHCsByDate_Class>(queryDef, paramList, pi);
        }

        public static BindingList<HealthCommittee.GetXXXXXXApprovalHCsByDate_Class> GetXXXXXXApprovalHCsByDate(TTObjectContext objectContext, DateTime PARAMSTARTDATE, DateTime PARAMENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].QueryDefs["GetXXXXXXApprovalHCsByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMSTARTDATE", PARAMSTARTDATE);
            paramList.Add("PARAMENDDATE", PARAMENDDATE);

            return TTReportNqlObject.QueryObjects<HealthCommittee.GetXXXXXXApprovalHCsByDate_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<HealthCommittee.OLAP_GetCancelledHealthCommittees_Class> OLAP_GetCancelledHealthCommittees(DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].QueryDefs["OLAP_GetCancelledHealthCommittees"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<HealthCommittee.OLAP_GetCancelledHealthCommittees_Class>(queryDef, paramList, pi);
        }

        public static BindingList<HealthCommittee.OLAP_GetCancelledHealthCommittees_Class> OLAP_GetCancelledHealthCommittees(TTObjectContext objectContext, DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].QueryDefs["OLAP_GetCancelledHealthCommittees"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<HealthCommittee.OLAP_GetCancelledHealthCommittees_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<HealthCommittee.OLAP_GetHealthCommittesByDate_Class> OLAP_GetHealthCommittesByDate(DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].QueryDefs["OLAP_GetHealthCommittesByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<HealthCommittee.OLAP_GetHealthCommittesByDate_Class>(queryDef, paramList, pi);
        }

        public static BindingList<HealthCommittee.OLAP_GetHealthCommittesByDate_Class> OLAP_GetHealthCommittesByDate(TTObjectContext objectContext, DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].QueryDefs["OLAP_GetHealthCommittesByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<HealthCommittee.OLAP_GetHealthCommittesByDate_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<HealthCommittee.GetHCsByDateAndUniqueRefNo_Class> GetHCsByDateAndUniqueRefNo(DateTime STARTDATE, DateTime ENDDATE, string UNIQUEREFNO, int UNIQUEREFNOFLAG, int HEALTHCOMITEETYPEFLAG, HealthCommitteeTypeEnum HEALTHCOMITEETYPE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].QueryDefs["GetHCsByDateAndUniqueRefNo"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("UNIQUEREFNO", UNIQUEREFNO);
            paramList.Add("UNIQUEREFNOFLAG", UNIQUEREFNOFLAG);
            paramList.Add("HEALTHCOMITEETYPEFLAG", HEALTHCOMITEETYPEFLAG);
            paramList.Add("HEALTHCOMITEETYPE", (int)HEALTHCOMITEETYPE);

            return TTReportNqlObject.QueryObjects<HealthCommittee.GetHCsByDateAndUniqueRefNo_Class>(queryDef, paramList, pi);
        }

        public static BindingList<HealthCommittee.GetHCsByDateAndUniqueRefNo_Class> GetHCsByDateAndUniqueRefNo(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, string UNIQUEREFNO, int UNIQUEREFNOFLAG, int HEALTHCOMITEETYPEFLAG, HealthCommitteeTypeEnum HEALTHCOMITEETYPE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].QueryDefs["GetHCsByDateAndUniqueRefNo"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("UNIQUEREFNO", UNIQUEREFNO);
            paramList.Add("UNIQUEREFNOFLAG", UNIQUEREFNOFLAG);
            paramList.Add("HEALTHCOMITEETYPEFLAG", HEALTHCOMITEETYPEFLAG);
            paramList.Add("HEALTHCOMITEETYPE", (int)HEALTHCOMITEETYPE);

            return TTReportNqlObject.QueryObjects<HealthCommittee.GetHCsByDateAndUniqueRefNo_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<HealthCommittee.GetMSBApprovalHCsByDate_Class> GetMSBApprovalHCsByDate(DateTime PARAMSTARTDATE, DateTime PARAMENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].QueryDefs["GetMSBApprovalHCsByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMSTARTDATE", PARAMSTARTDATE);
            paramList.Add("PARAMENDDATE", PARAMENDDATE);

            return TTReportNqlObject.QueryObjects<HealthCommittee.GetMSBApprovalHCsByDate_Class>(queryDef, paramList, pi);
        }

        public static BindingList<HealthCommittee.GetMSBApprovalHCsByDate_Class> GetMSBApprovalHCsByDate(TTObjectContext objectContext, DateTime PARAMSTARTDATE, DateTime PARAMENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].QueryDefs["GetMSBApprovalHCsByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMSTARTDATE", PARAMSTARTDATE);
            paramList.Add("PARAMENDDATE", PARAMENDDATE);

            return TTReportNqlObject.QueryObjects<HealthCommittee.GetMSBApprovalHCsByDate_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<HealthCommittee.GetHCReportGroupNameByPatient_Class> GetHCReportGroupNameByPatient(string PATIENT, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].QueryDefs["GetHCReportGroupNameByPatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return TTReportNqlObject.QueryObjects<HealthCommittee.GetHCReportGroupNameByPatient_Class>(queryDef, paramList, pi);
        }

        public static BindingList<HealthCommittee.GetHCReportGroupNameByPatient_Class> GetHCReportGroupNameByPatient(TTObjectContext objectContext, string PATIENT, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].QueryDefs["GetHCReportGroupNameByPatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return TTReportNqlObject.QueryObjects<HealthCommittee.GetHCReportGroupNameByPatient_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<HealthCommittee> GetByWLFilterExpression(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].QueryDefs["GetByWLFilterExpression"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<HealthCommittee>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<HealthCommittee> GetHealthCommitteeWL(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].QueryDefs["GetHealthCommitteeWL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<HealthCommittee>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<HealthCommittee.GetHealthCommitteesByDate_Class> GetHealthCommitteesByDate(DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].QueryDefs["GetHealthCommitteesByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<HealthCommittee.GetHealthCommitteesByDate_Class>(queryDef, paramList, pi);
        }

        public static BindingList<HealthCommittee.GetHealthCommitteesByDate_Class> GetHealthCommitteesByDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].QueryDefs["GetHealthCommitteesByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<HealthCommittee.GetHealthCommitteesByDate_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<HealthCommittee> GetHealthCommiteesOfEpisode(TTObjectContext objectContext, string EPISODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].QueryDefs["GetHealthCommiteesOfEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return ((ITTQuery)objectContext).QueryObjects<HealthCommittee>(queryDef, paramList);
        }

        public static BindingList<HealthCommittee.GetHcBySlice_Class> GetHcBySlice(DateTime STARTDATE, DateTime ENDDATE, int SLICEORDER, int SLICEFLAG, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].QueryDefs["GetHcBySlice"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("SLICEORDER", SLICEORDER);
            paramList.Add("SLICEFLAG", SLICEFLAG);

            return TTReportNqlObject.QueryObjects<HealthCommittee.GetHcBySlice_Class>(queryDef, paramList, pi);
        }

        public static BindingList<HealthCommittee.GetHcBySlice_Class> GetHcBySlice(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, int SLICEORDER, int SLICEFLAG, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].QueryDefs["GetHcBySlice"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("SLICEORDER", SLICEORDER);
            paramList.Add("SLICEFLAG", SLICEFLAG);

            return TTReportNqlObject.QueryObjects<HealthCommittee.GetHcBySlice_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<HealthCommittee.GetNotCollectedInvoicableHealthCommitteeRQ_Class> GetNotCollectedInvoicableHealthCommitteeRQ(Guid EPISODEID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].QueryDefs["GetNotCollectedInvoicableHealthCommitteeRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODEID", EPISODEID);

            return TTReportNqlObject.QueryObjects<HealthCommittee.GetNotCollectedInvoicableHealthCommitteeRQ_Class>(queryDef, paramList, pi);
        }

        public static BindingList<HealthCommittee.GetNotCollectedInvoicableHealthCommitteeRQ_Class> GetNotCollectedInvoicableHealthCommitteeRQ(TTObjectContext objectContext, Guid EPISODEID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].QueryDefs["GetNotCollectedInvoicableHealthCommitteeRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODEID", EPISODEID);

            return TTReportNqlObject.QueryObjects<HealthCommittee.GetNotCollectedInvoicableHealthCommitteeRQ_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<HealthCommittee> GetByPatientHProtNoAndActionID(TTObjectContext objectContext, Guid PATIENT, int EPISODEHOSPROTOCOLNO, int ACTIONID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].QueryDefs["GetByPatientHProtNoAndActionID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);
            paramList.Add("EPISODEHOSPROTOCOLNO", EPISODEHOSPROTOCOLNO);
            paramList.Add("ACTIONID", ACTIONID);

            return ((ITTQuery)objectContext).QueryObjects<HealthCommittee>(queryDef, paramList);
        }

        public static BindingList<HealthCommittee.GetHealthCommitteesByType_Class> GetHealthCommitteesByType(DateTime ENDDATE, HealthCommitteeTypeEnum HEALTHCOMITEETYPE, int HEALTHCOMITEETYPEFLAG, DateTime STARTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].QueryDefs["GetHealthCommitteesByType"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("HEALTHCOMITEETYPE", (int)HEALTHCOMITEETYPE);
            paramList.Add("HEALTHCOMITEETYPEFLAG", HEALTHCOMITEETYPEFLAG);
            paramList.Add("STARTDATE", STARTDATE);

            return TTReportNqlObject.QueryObjects<HealthCommittee.GetHealthCommitteesByType_Class>(queryDef, paramList, pi);
        }

        public static BindingList<HealthCommittee.GetHealthCommitteesByType_Class> GetHealthCommitteesByType(TTObjectContext objectContext, DateTime ENDDATE, HealthCommitteeTypeEnum HEALTHCOMITEETYPE, int HEALTHCOMITEETYPEFLAG, DateTime STARTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].QueryDefs["GetHealthCommitteesByType"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("HEALTHCOMITEETYPE", (int)HEALTHCOMITEETYPE);
            paramList.Add("HEALTHCOMITEETYPEFLAG", HEALTHCOMITEETYPEFLAG);
            paramList.Add("STARTDATE", STARTDATE);

            return TTReportNqlObject.QueryObjects<HealthCommittee.GetHealthCommitteesByType_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<HealthCommittee.GetHCsForPeriodicExaminationResultReport_Class> GetHCsForPeriodicExaminationResultReport(DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].QueryDefs["GetHCsForPeriodicExaminationResultReport"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<HealthCommittee.GetHCsForPeriodicExaminationResultReport_Class>(queryDef, paramList, pi);
        }

        public static BindingList<HealthCommittee.GetHCsForPeriodicExaminationResultReport_Class> GetHCsForPeriodicExaminationResultReport(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].QueryDefs["GetHCsForPeriodicExaminationResultReport"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<HealthCommittee.GetHCsForPeriodicExaminationResultReport_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<HealthCommittee.GetHCsForAdditionalReport_Class> GetHCsForAdditionalReport(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].QueryDefs["GetHCsForAdditionalReport"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<HealthCommittee.GetHCsForAdditionalReport_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<HealthCommittee.GetHCsForAdditionalReport_Class> GetHCsForAdditionalReport(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].QueryDefs["GetHCsForAdditionalReport"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<HealthCommittee.GetHCsForAdditionalReport_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<HealthCommittee.GetSuccessfulHCsByDateTypePatientGroup_Class> GetSuccessfulHCsByDateTypePatientGroup(DateTime STARTDATE, DateTime ENDDATE, HealthCommitteeTypeEnum HEALTHCOMITEETYPE, int HEALTHCOMITEETYPEFLAG, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].QueryDefs["GetSuccessfulHCsByDateTypePatientGroup"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("HEALTHCOMITEETYPE", (int)HEALTHCOMITEETYPE);
            paramList.Add("HEALTHCOMITEETYPEFLAG", HEALTHCOMITEETYPEFLAG);

            return TTReportNqlObject.QueryObjects<HealthCommittee.GetSuccessfulHCsByDateTypePatientGroup_Class>(queryDef, paramList, pi);
        }

        public static BindingList<HealthCommittee.GetSuccessfulHCsByDateTypePatientGroup_Class> GetSuccessfulHCsByDateTypePatientGroup(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, HealthCommitteeTypeEnum HEALTHCOMITEETYPE, int HEALTHCOMITEETYPEFLAG, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].QueryDefs["GetSuccessfulHCsByDateTypePatientGroup"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("HEALTHCOMITEETYPE", (int)HEALTHCOMITEETYPE);
            paramList.Add("HEALTHCOMITEETYPEFLAG", HEALTHCOMITEETYPEFLAG);

            return TTReportNqlObject.QueryObjects<HealthCommittee.GetSuccessfulHCsByDateTypePatientGroup_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<HealthCommittee> GetHCsToSendSummary(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].QueryDefs["GetHCsToSendSummary"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<HealthCommittee>(queryDef, paramList);
        }

        public static BindingList<HealthCommittee> GetUncompletedHCsToSend(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].QueryDefs["GetUncompletedHCsToSend"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<HealthCommittee>(queryDef, paramList);
        }

        public static BindingList<HealthCommittee.GetUnsuccessfulHCsByDateTypePatientGroup_Class> GetUnsuccessfulHCsByDateTypePatientGroup(DateTime STARTDATE, DateTime ENDDATE, HealthCommitteeTypeEnum HEALTHCOMITEETYPE, int HEALTHCOMITEETYPEFLAG, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].QueryDefs["GetUnsuccessfulHCsByDateTypePatientGroup"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("HEALTHCOMITEETYPE", (int)HEALTHCOMITEETYPE);
            paramList.Add("HEALTHCOMITEETYPEFLAG", HEALTHCOMITEETYPEFLAG);

            return TTReportNqlObject.QueryObjects<HealthCommittee.GetUnsuccessfulHCsByDateTypePatientGroup_Class>(queryDef, paramList, pi);
        }

        public static BindingList<HealthCommittee.GetUnsuccessfulHCsByDateTypePatientGroup_Class> GetUnsuccessfulHCsByDateTypePatientGroup(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, HealthCommitteeTypeEnum HEALTHCOMITEETYPE, int HEALTHCOMITEETYPEFLAG, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].QueryDefs["GetUnsuccessfulHCsByDateTypePatientGroup"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("HEALTHCOMITEETYPE", (int)HEALTHCOMITEETYPE);
            paramList.Add("HEALTHCOMITEETYPEFLAG", HEALTHCOMITEETYPEFLAG);

            return TTReportNqlObject.QueryObjects<HealthCommittee.GetUnsuccessfulHCsByDateTypePatientGroup_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<HealthCommittee.GetHealthCommitteeByObjectID_Class> GetHealthCommitteeByObjectID(Guid OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].QueryDefs["GetHealthCommitteeByObjectID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<HealthCommittee.GetHealthCommitteeByObjectID_Class>(queryDef, paramList, pi);
        }

        public static BindingList<HealthCommittee.GetHealthCommitteeByObjectID_Class> GetHealthCommitteeByObjectID(TTObjectContext objectContext, Guid OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].QueryDefs["GetHealthCommitteeByObjectID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<HealthCommittee.GetHealthCommitteeByObjectID_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<HealthCommittee.HasSameHCExamForSameReason_Class> HasSameHCExamForSameReason(Guid PatientID, Guid Reason, int DayLimit, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].QueryDefs["HasSameHCExamForSameReason"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENTID", PatientID);
            paramList.Add("REASON", Reason);
            paramList.Add("DAYLIMIT", DayLimit);

            return TTReportNqlObject.QueryObjects<HealthCommittee.HasSameHCExamForSameReason_Class>(queryDef, paramList, pi);
        }

        public static BindingList<HealthCommittee.HasSameHCExamForSameReason_Class> HasSameHCExamForSameReason(TTObjectContext objectContext, Guid PatientID, Guid Reason, int DayLimit, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].QueryDefs["HasSameHCExamForSameReason"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENTID", PatientID);
            paramList.Add("REASON", Reason);
            paramList.Add("DAYLIMIT", DayLimit);

            return TTReportNqlObject.QueryObjects<HealthCommittee.HasSameHCExamForSameReason_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<HealthCommittee.GetHealthCommitteeForWL_Class> GetHealthCommitteeForWL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].QueryDefs["GetHealthCommitteeForWL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<HealthCommittee.GetHealthCommitteeForWL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<HealthCommittee.GetHealthCommitteeForWL_Class> GetHealthCommitteeForWL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].QueryDefs["GetHealthCommitteeForWL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<HealthCommittee.GetHealthCommitteeForWL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<HealthCommittee> GetHCByAdmissionID(TTObjectContext objectContext, Guid PATIENTADMISSION)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].QueryDefs["GetHCByAdmissionID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENTADMISSION", PATIENTADMISSION);

            return ((ITTQuery)objectContext).QueryObjects<HealthCommittee>(queryDef, paramList);
        }

    /// <summary>
    /// Başlama Tarihi
    /// </summary>
        public DateTime? HealthCommitteeStartDate
        {
            get { return (DateTime?)this["HEALTHCOMMITTEESTARTDATE"]; }
            set { this["HEALTHCOMMITTEESTARTDATE"] = value; }
        }

    /// <summary>
    /// Otomatik Olarak Oluşmuş 
    /// </summary>
        public bool? AutomaticallyCreated
        {
            get { return (bool?)this["AUTOMATICALLYCREATED"]; }
            set { this["AUTOMATICALLYCREATED"] = value; }
        }

    /// <summary>
    /// Rapor No
    /// </summary>
        public TTSequence ReportNo
        {
            get { return GetSequence("REPORTNO"); }
        }

    /// <summary>
    /// Vücut Kitle İndeksi
    /// </summary>
        public string BodyMassIndex
        {
            get { return (string)this["BODYMASSINDEX"]; }
            set { this["BODYMASSINDEX"] = value; }
        }

    /// <summary>
    /// Protokol No
    /// </summary>
        public TTSequence ProtocolNo
        {
            get { return GetSequence("PROTOCOLNO"); }
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
    /// Ağırlık (Klinik Ölçüm)
    /// </summary>
        public int? ClinicWeight
        {
            get { return (int?)this["CLINICWEIGHT"]; }
            set { this["CLINICWEIGHT"] = value; }
        }

    /// <summary>
    /// Oy Durumu
    /// </summary>
        public LargeMajorityUnanimityEnum? Unanimity
        {
            get { return (LargeMajorityUnanimityEnum?)(int?)this["UNANIMITY"]; }
            set { this["UNANIMITY"] = value; }
        }

    /// <summary>
    /// Defter Kategori
    /// </summary>
        public string BookCategory
        {
            get { return (string)this["BOOKCATEGORY"]; }
            set { this["BOOKCATEGORY"] = value; }
        }

    /// <summary>
    /// Boy(Heyet Ölçümü)
    /// </summary>
        public double? HCHeight
        {
            get { return (double?)this["HCHEIGHT"]; }
            set { this["HCHEIGHT"] = value; }
        }

    /// <summary>
    /// Boy (Klinik Ölçüm)
    /// </summary>
        public double? ClinicHeight
        {
            get { return (double?)this["CLINICHEIGHT"]; }
            set { this["CLINICHEIGHT"] = value; }
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
    /// Evrak Sayısı
    /// </summary>
        public string DocumentNumber
        {
            get { return (string)this["DOCUMENTNUMBER"]; }
            set { this["DOCUMENTNUMBER"] = value; }
        }

    /// <summary>
    /// Muamele Sayısı
    /// </summary>
        public int? NumberOfProcedure
        {
            get { return (int?)this["NUMBEROFPROCEDURE"]; }
            set { this["NUMBEROFPROCEDURE"] = value; }
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
    /// Hedef Nesne IDsi
    /// </summary>
        public Guid? TargetObjectID
        {
            get { return (Guid?)this["TARGETOBJECTID"]; }
            set { this["TARGETOBJECTID"] = value; }
        }

    /// <summary>
    /// Kaynak Nesne IDsi
    /// </summary>
        public Guid? SourceObjectID
        {
            get { return (Guid?)this["SOURCEOBJECTID"]; }
            set { this["SOURCEOBJECTID"] = value; }
        }

        public string MessageID
        {
            get { return (string)this["MESSAGEID"]; }
            set { this["MESSAGEID"] = value; }
        }

    /// <summary>
    /// Randevu Bilgisi
    /// </summary>
        public string AppointmentInfo
        {
            get { return (string)this["APPOINTMENTINFO"]; }
            set { this["APPOINTMENTINFO"] = value; }
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
    /// Rapor Akıbeti
    /// </summary>
        public PositiveNegativeEnum? Ration
        {
            get { return (PositiveNegativeEnum?)(int?)this["RATION"]; }
            set { this["RATION"] = value; }
        }

    /// <summary>
    /// Ön Tanı
    /// </summary>
        public string PreDiagnosis
        {
            get { return (string)this["PREDIAGNOSIS"]; }
            set { this["PREDIAGNOSIS"] = value; }
        }

    /// <summary>
    /// Rütbe Yükselme Tarihi
    /// </summary>
        public DateTime? NasbiTarihi
        {
            get { return (DateTime?)this["NASBITARIHI"]; }
            set { this["NASBITARIHI"] = value; }
        }

    /// <summary>
    /// Ücreti Ödeyecek
    /// </summary>
        public WhoPaysEnum? WhoPays
        {
            get { return (WhoPaysEnum?)(int?)this["WHOPAYS"]; }
            set { this["WHOPAYS"] = value; }
        }

    /// <summary>
    /// Karar Süresi
    /// </summary>
        public int? HCDecisionTime
        {
            get { return (int?)this["HCDECISIONTIME"]; }
            set { this["HCDECISIONTIME"] = value; }
        }

    /// <summary>
    /// Karar Süresi Birimi
    /// </summary>
        public UnitOfTimeEnum? HCDecisionUnitOfTime
        {
            get { return (UnitOfTimeEnum?)(int?)this["HCDECISIONUNITOFTIME"]; }
            set { this["HCDECISIONUNITOFTIME"] = value; }
        }

    /// <summary>
    /// Karar Teklifi
    /// </summary>
        public object DecisionOffer
        {
            get { return (object)this["DECISIONOFFER"]; }
            set { this["DECISIONOFFER"] = value; }
        }

    /// <summary>
    /// Heyet Kabul Durumu
    /// </summary>
        public HCCommitteeAcceptanceStatus? CommitteeAcceptanceStatus
        {
            get { return (HCCommitteeAcceptanceStatus?)(int?)this["COMMITTEEACCEPTANCESTATUS"]; }
            set { this["COMMITTEEACCEPTANCESTATUS"] = value; }
        }

    /// <summary>
    /// Çıkış Tarihi
    /// </summary>
        public DateTime? DateOfExit
        {
            get { return (DateTime?)this["DATEOFEXIT"]; }
            set { this["DATEOFEXIT"] = value; }
        }

    /// <summary>
    /// Kilo(Heyet Ölçümü)
    /// </summary>
        public double? HCWeight
        {
            get { return (double?)this["HCWEIGHT"]; }
            set { this["HCWEIGHT"] = value; }
        }

    /// <summary>
    /// XXXXXXliğe elverişli değil
    /// </summary>
        public bool? UnsuitableForMilitaryService
        {
            get { return (bool?)this["UNSUITABLEFORMILITARYSERVICE"]; }
            set { this["UNSUITABLEFORMILITARYSERVICE"] = value; }
        }

    /// <summary>
    /// Vücut Fonksiyon Kayıp Oranı
    /// </summary>
        public double? FunctionRatio
        {
            get { return (double?)this["FUNCTIONRATIO"]; }
            set { this["FUNCTIONRATIO"] = value; }
        }

    /// <summary>
    /// Gelen Evrak Tarihi
    /// </summary>
        public DateTime? IncomingDocumentDate
        {
            get { return (DateTime?)this["INCOMINGDOCUMENTDATE"]; }
            set { this["INCOMINGDOCUMENTDATE"] = value; }
        }

    /// <summary>
    /// Gelen Evrak No
    /// </summary>
        public string IncomingDocumentNo
        {
            get { return (string)this["INCOMINGDOCUMENTNO"]; }
            set { this["INCOMINGDOCUMENTNO"] = value; }
        }

    /// <summary>
    /// Gelen Rapor No
    /// </summary>
        public string IncomingReportNo
        {
            get { return (string)this["INCOMINGREPORTNO"]; }
            set { this["INCOMINGREPORTNO"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Definition
        {
            get { return (string)this["DEFINITION"]; }
            set { this["DEFINITION"] = value; }
        }

    /// <summary>
    /// Çalışamayacağı Alan
    /// </summary>
        public string UnworkField
        {
            get { return (string)this["UNWORKFIELD"]; }
            set { this["UNWORKFIELD"] = value; }
        }

    /// <summary>
    /// Rapor Tanıları
    /// </summary>
        public object ReportDiagnose
        {
            get { return (object)this["REPORTDIAGNOSE"]; }
            set { this["REPORTDIAGNOSE"] = value; }
        }

    /// <summary>
    /// Çalıştırılamayacağı İşlerin Niteliği
    /// </summary>
        public string QulityOfUnemployableWorks
        {
            get { return (string)this["QULITYOFUNEMPLOYABLEWORKS"]; }
            set { this["QULITYOFUNEMPLOYABLEWORKS"] = value; }
        }

    /// <summary>
    /// Ağır Engelli
    /// </summary>
        public bool? IsHeavyDisabled
        {
            get { return (bool?)this["ISHEAVYDISABLED"]; }
            set { this["ISHEAVYDISABLED"] = value; }
        }

    /// <summary>
    /// Muayeneye Gönderen
    /// </summary>
        public SendExaminationEnum? SendExamination
        {
            get { return (SendExaminationEnum?)(int?)this["SENDEXAMINATION"]; }
            set { this["SENDEXAMINATION"] = value; }
        }

    /// <summary>
    /// Rapor Kararı
    /// </summary>
        public object HCReoprtDecision
        {
            get { return (object)this["HCREOPRTDECISION"]; }
            set { this["HCREOPRTDECISION"] = value; }
        }

    /// <summary>
    /// Sağlık Kurulu Kararı
    /// </summary>
        public object HealthCommitteeDecision
        {
            get { return (object)this["HEALTHCOMMITTEEDECISION"]; }
            set { this["HEALTHCOMMITTEEDECISION"] = value; }
        }

    /// <summary>
    /// Klinik Bulgular
    /// </summary>
        public string ClinicalFindings
        {
            get { return (string)this["CLINICALFINDINGS"]; }
            set { this["CLINICALFINDINGS"] = value; }
        }

    /// <summary>
    /// Yakınlık Derecesi
    /// </summary>
        public DegreeOfBloodRelativesEnum? DegreeOfBloodRelatives
        {
            get { return (DegreeOfBloodRelativesEnum?)(int?)this["DEGREEOFBLOODRELATIVES"]; }
            set { this["DEGREEOFBLOODRELATIVES"] = value; }
        }

    /// <summary>
    /// Raporu Teslim Alanın TC Kimlik No
    /// </summary>
        public long? UniqueRefReceiveReport
        {
            get { return (long?)this["UNIQUEREFRECEIVEREPORT"]; }
            set { this["UNIQUEREFRECEIVEREPORT"] = value; }
        }

    /// <summary>
    /// Raporu Teslim Alanın Adı Soyadı
    /// </summary>
        public string NameSurnameReceiveReport
        {
            get { return (string)this["NAMESURNAMERECEIVEREPORT"]; }
            set { this["NAMESURNAMERECEIVEREPORT"] = value; }
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
    /// Birimler
    /// </summary>
        public ResClinic ExaminationUnitsHospitals
        {
            get { return (ResClinic)((ITTObject)this).GetParent("EXAMINATIONUNITSHOSPITALS"); }
            set { this["EXAMINATIONUNITSHOSPITALS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Doktor
    /// </summary>
        public ResUser Doctor
        {
            get { return (ResUser)((ITTObject)this).GetParent("DOCTOR"); }
            set { this["DOCTOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Sağlık Kurulu No
    /// </summary>
        public MemberOfHealthCommitteeDefinition GroupNo
        {
            get { return (MemberOfHealthCommitteeDefinition)((ITTObject)this).GetParent("GROUPNO"); }
            set { this["GROUPNO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// İsteği yapan
    /// </summary>
        public ResUser Requester
        {
            get { return (ResUser)((ITTObject)this).GetParent("REQUESTER"); }
            set { this["REQUESTER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public IntendedUseOfDisabledReport IntendedUseOfDisabledReport
        {
            get { return (IntendedUseOfDisabledReport)((ITTObject)this).GetParent("INTENDEDUSEOFDISABLEDREPORT"); }
            set { this["INTENDEDUSEOFDISABLEDREPORT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Sağlık Kurulu Görev Tanımları
    /// </summary>
        public HCDutyTypeDef HCDutyType
        {
            get { return (HCDutyTypeDef)((ITTObject)this).GetParent("HCDUTYTYPE"); }
            set { this["HCDUTYTYPE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Uçtuğu Uçak Tipi
    /// </summary>
        public AircraftTypeDefinition AircraftType
        {
            get { return (AircraftTypeDefinition)((ITTObject)this).GetParent("AIRCRAFTTYPE"); }
            set { this["AIRCRAFTTYPE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public HCRequestReason HCRequestReason
        {
            get { return (HCRequestReason)((ITTObject)this).GetParent("HCREQUESTREASON"); }
            set { this["HCREQUESTREASON"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateHCMatterSliceAnectodesCollection()
        {
            _HCMatterSliceAnectodes = new HCMatterSliceAnectodeDefinitionGrid.ChildHCMatterSliceAnectodeDefinitionGridCollection(this, new Guid("5c02be85-7763-4cd7-9eaf-621bf1ccf91a"));
            ((ITTChildObjectCollection)_HCMatterSliceAnectodes).GetChildren();
        }

        protected HCMatterSliceAnectodeDefinitionGrid.ChildHCMatterSliceAnectodeDefinitionGridCollection _HCMatterSliceAnectodes = null;
        public HCMatterSliceAnectodeDefinitionGrid.ChildHCMatterSliceAnectodeDefinitionGridCollection HCMatterSliceAnectodes
        {
            get
            {
                if (_HCMatterSliceAnectodes == null)
                    CreateHCMatterSliceAnectodesCollection();
                return _HCMatterSliceAnectodes;
            }
        }

        virtual protected void CreateReturnDescriptionsCollection()
        {
            _ReturnDescriptions = new HealthCommittee_ReturnDescriptionsGrid.ChildHealthCommittee_ReturnDescriptionsGridCollection(this, new Guid("a519ee43-882b-4e53-adaa-8965076eb2e2"));
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

        virtual protected void CreateSystemForHealthCommitteeGridCollection()
        {
            _SystemForHealthCommitteeGrid = new SystemForHealthCommitteeGrid.ChildSystemForHealthCommitteeGridCollection(this, new Guid("560b4840-800d-4d41-9d4a-3f92c963b501"));
            ((ITTChildObjectCollection)_SystemForHealthCommitteeGrid).GetChildren();
        }

        protected SystemForHealthCommitteeGrid.ChildSystemForHealthCommitteeGridCollection _SystemForHealthCommitteeGrid = null;
        public SystemForHealthCommitteeGrid.ChildSystemForHealthCommitteeGridCollection SystemForHealthCommitteeGrid
        {
            get
            {
                if (_SystemForHealthCommitteeGrid == null)
                    CreateSystemForHealthCommitteeGridCollection();
                return _SystemForHealthCommitteeGrid;
            }
        }

        virtual protected void CreateClinicDiagnosisCollection()
        {
            _ClinicDiagnosis = new HealthCommittee_DiagnosisGridClinic.ChildHealthCommittee_DiagnosisGridClinicCollection(this, new Guid("5f49798c-ea2b-4039-8c4c-60e3bd3b394b"));
            ((ITTChildObjectCollection)_ClinicDiagnosis).GetChildren();
        }

        protected HealthCommittee_DiagnosisGridClinic.ChildHealthCommittee_DiagnosisGridClinicCollection _ClinicDiagnosis = null;
        public HealthCommittee_DiagnosisGridClinic.ChildHealthCommittee_DiagnosisGridClinicCollection ClinicDiagnosis
        {
            get
            {
                if (_ClinicDiagnosis == null)
                    CreateClinicDiagnosisCollection();
                return _ClinicDiagnosis;
            }
        }

        virtual protected void CreateRedecisionDiagnosisCollection()
        {
            _RedecisionDiagnosis = new HealthCommittee_RedecisionDiagnosisGrid.ChildHealthCommittee_RedecisionDiagnosisGridCollection(this, new Guid("5bf5e532-ad71-45ea-8fdc-d5fd0c47d225"));
            ((ITTChildObjectCollection)_RedecisionDiagnosis).GetChildren();
        }

        protected HealthCommittee_RedecisionDiagnosisGrid.ChildHealthCommittee_RedecisionDiagnosisGridCollection _RedecisionDiagnosis = null;
        public HealthCommittee_RedecisionDiagnosisGrid.ChildHealthCommittee_RedecisionDiagnosisGridCollection RedecisionDiagnosis
        {
            get
            {
                if (_RedecisionDiagnosis == null)
                    CreateRedecisionDiagnosisCollection();
                return _RedecisionDiagnosis;
            }
        }

        virtual protected void CreateMatterSliceAnectodesCollection()
        {
            _MatterSliceAnectodes = new HealthCommittee_MatterSliceAnectodeGrid.ChildHealthCommittee_MatterSliceAnectodeGridCollection(this, new Guid("9fa02ab7-8831-4872-a224-bf4a2feb4e23"));
            ((ITTChildObjectCollection)_MatterSliceAnectodes).GetChildren();
        }

        protected HealthCommittee_MatterSliceAnectodeGrid.ChildHealthCommittee_MatterSliceAnectodeGridCollection _MatterSliceAnectodes = null;
        public HealthCommittee_MatterSliceAnectodeGrid.ChildHealthCommittee_MatterSliceAnectodeGridCollection MatterSliceAnectodes
        {
            get
            {
                if (_MatterSliceAnectodes == null)
                    CreateMatterSliceAnectodesCollection();
                return _MatterSliceAnectodes;
            }
        }

        virtual protected void CreateRedecisionMatterSliceAnectodesCollection()
        {
            _RedecisionMatterSliceAnectodes = new HealthCommittee_RedecisionMatterSliceAnectodeGrid.ChildHealthCommittee_RedecisionMatterSliceAnectodeGridCollection(this, new Guid("31043e26-fc1c-4a0d-9e67-de448001a703"));
            ((ITTChildObjectCollection)_RedecisionMatterSliceAnectodes).GetChildren();
        }

        protected HealthCommittee_RedecisionMatterSliceAnectodeGrid.ChildHealthCommittee_RedecisionMatterSliceAnectodeGridCollection _RedecisionMatterSliceAnectodes = null;
        public HealthCommittee_RedecisionMatterSliceAnectodeGrid.ChildHealthCommittee_RedecisionMatterSliceAnectodeGridCollection RedecisionMatterSliceAnectodes
        {
            get
            {
                if (_RedecisionMatterSliceAnectodes == null)
                    CreateRedecisionMatterSliceAnectodesCollection();
                return _RedecisionMatterSliceAnectodes;
            }
        }

        virtual protected void CreateHCAddtionalReportsCollection()
        {
            _HCAddtionalReports = new HealthCommitteeAdditionalReport.ChildHealthCommitteeAdditionalReportCollection(this, new Guid("da92d848-e69c-4872-ba10-8911598403ee"));
            ((ITTChildObjectCollection)_HCAddtionalReports).GetChildren();
        }

        protected HealthCommitteeAdditionalReport.ChildHealthCommitteeAdditionalReportCollection _HCAddtionalReports = null;
    /// <summary>
    /// Child collection for Sağlık Kurulu İşlemi
    /// </summary>
        public HealthCommitteeAdditionalReport.ChildHealthCommitteeAdditionalReportCollection HCAddtionalReports
        {
            get
            {
                if (_HCAddtionalReports == null)
                    CreateHCAddtionalReportsCollection();
                return _HCAddtionalReports;
            }
        }

        virtual protected void CreateMembersCollection()
        {
            _Members = new MemberOfHealthCommiittee.ChildMemberOfHealthCommiitteeCollection(this, new Guid("5f86b7c8-de7e-4f36-a0ff-19281d4f69d6"));
            ((ITTChildObjectCollection)_Members).GetChildren();
        }

        protected MemberOfHealthCommiittee.ChildMemberOfHealthCommiitteeCollection _Members = null;
        public MemberOfHealthCommiittee.ChildMemberOfHealthCommiitteeCollection Members
        {
            get
            {
                if (_Members == null)
                    CreateMembersCollection();
                return _Members;
            }
        }

        override protected void CreateSubactionProceduresCollectionViews()
        {
            base.CreateSubactionProceduresCollectionViews();
            _HealthCommitteeProcedures = new HealthCommitteeProcedure.ChildHealthCommitteeProcedureCollection(_SubactionProcedures, "HealthCommitteeProcedures");
        }

        private HealthCommitteeProcedure.ChildHealthCommitteeProcedureCollection _HealthCommitteeProcedures = null;
        public HealthCommitteeProcedure.ChildHealthCommitteeProcedureCollection HealthCommitteeProcedures
        {
            get
            {
                if (_SubactionProcedures == null)
                    CreateSubactionProceduresCollection();
                return _HealthCommitteeProcedures;
            }            
        }

        override protected void CreateLinkedActionsCollectionViews()
        {
            base.CreateLinkedActionsCollectionViews();
        }

        protected HealthCommittee(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HealthCommittee(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HealthCommittee(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HealthCommittee(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HealthCommittee(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HEALTHCOMMITTEE", dataRow) { }
        protected HealthCommittee(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HEALTHCOMMITTEE", dataRow, isImported) { }
        public HealthCommittee(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HealthCommittee(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HealthCommittee() : base() { }

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
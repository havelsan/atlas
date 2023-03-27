
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HealthCommitteeWithThreeSpecialist")] 

    /// <summary>
    /// Üç Uzman Tabip İmzalı Rapor  İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
    public  partial class HealthCommitteeWithThreeSpecialist : BaseHealthCommittee, IWorkListEpisodeAction, IOAHealthCommittee
    {
        public class HealthCommitteeWithThreeSpecialistList : TTObjectCollection<HealthCommitteeWithThreeSpecialist> { }
                    
        public class ChildHealthCommitteeWithThreeSpecialistCollection : TTObject.TTChildObjectCollection<HealthCommitteeWithThreeSpecialist>
        {
            public ChildHealthCommitteeWithThreeSpecialistCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHealthCommitteeWithThreeSpecialistCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetHCWithThreeSpecialist_Class : TTReportNqlObject 
        {
            public Guid? Bolumid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["BOLUMID"]);
                }
            }

            public Guid? Istekyapanbolumid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["ISTEKYAPANBOLUMID"]);
                }
            }

            public long? Raporno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RAPORNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEWITHTHREESPECIALIST"].AllPropertyDefs["REPORTNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEWITHTHREESPECIALIST"].AllPropertyDefs["REPORTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public long? Skno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SKNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEWITHTHREESPECIALIST"].AllPropertyDefs["PROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public long? Karantinano
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KARANTINANO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["QUARANTINEPROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? Hgiristarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HGIRISTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["OPENINGDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? Hcikistarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HCIKISTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["HOSPITALDISCHARGEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
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

            public string Evrakno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EVRAKNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["DOCUMENTNUMBER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Maksat
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MAKSAT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HCTREASONFOREXAMINATIONDEFINITION"].AllPropertyDefs["EXAMINATIONREASON"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Patientid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PATIENTID"]);
                }
            }

            public int? Kilo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KILO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEWITHTHREESPECIALIST"].AllPropertyDefs["WEIGHT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? Boy
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BOY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEWITHTHREESPECIALIST"].AllPropertyDefs["HEIGHT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? Kacincimuayenesi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KACINCIMUAYENESI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEWITHTHREESPECIALIST"].AllPropertyDefs["NUMBEROFPROCESS"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string Karar
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KARAR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEWITHTHREESPECIALIST"].AllPropertyDefs["OFFEROFDECISION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public object Rapor
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RAPOR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEWITHTHREESPECIALIST"].AllPropertyDefs["REPORT"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public Object Hastagrubu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["HASTAGRUBU"]);
                }
            }

            public Object Adres
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["ADRES"]);
                }
            }

            public Object Dyeri
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["DYERI"]);
                }
            }

            public Object Dtarihi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["DTARIHI"]);
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

            public string MedulaRaporTakipNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULARAPORTAKIPNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEWITHTHREESPECIALIST"].AllPropertyDefs["MEDULARAPORTAKIPNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Episodeid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODEID"]);
                }
            }

            public Object Homephone
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["HOMEPHONE"]);
                }
            }

            public Object Mobilephone
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["MOBILEPHONE"]);
                }
            }

            public Guid? Sex
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SEX"]);
                }
            }

            public DateTime? ReportStartDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTSTARTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEWITHTHREESPECIALIST"].AllPropertyDefs["REPORTSTARTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ReportEndDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTENDDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEWITHTHREESPECIALIST"].AllPropertyDefs["REPORTENDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetHCWithThreeSpecialist_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetHCWithThreeSpecialist_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetHCWithThreeSpecialist_Class() : base() { }
        }

        [Serializable] 

        public partial class GetAllHCWithThreeSpecialist_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? Bolumid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["BOLUMID"]);
                }
            }

            public long? Raporno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RAPORNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEWITHTHREESPECIALIST"].AllPropertyDefs["REPORTNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEWITHTHREESPECIALIST"].AllPropertyDefs["REPORTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public long? Skno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SKNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEWITHTHREESPECIALIST"].AllPropertyDefs["PROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public long? Karantinano
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KARANTINANO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["QUARANTINEPROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? Hgiristarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HGIRISTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["OPENINGDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? Hcikistarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HCIKISTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["HOSPITALDISCHARGEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
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

            public string Evrakno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EVRAKNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["DOCUMENTNUMBER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Maksat
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MAKSAT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REASONFOREXAMINATIONDEFINITION"].AllPropertyDefs["REASON"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Patientid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PATIENTID"]);
                }
            }

            public int? Kilo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KILO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEWITHTHREESPECIALIST"].AllPropertyDefs["WEIGHT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? Boy
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BOY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEWITHTHREESPECIALIST"].AllPropertyDefs["HEIGHT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? Kacincimuayenesi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KACINCIMUAYENESI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEWITHTHREESPECIALIST"].AllPropertyDefs["NUMBEROFPROCESS"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string Karar
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KARAR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEWITHTHREESPECIALIST"].AllPropertyDefs["OFFEROFDECISION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public object Rapor
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RAPOR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEWITHTHREESPECIALIST"].AllPropertyDefs["REPORT"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public Object Hastagrubu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["HASTAGRUBU"]);
                }
            }

            public Object Adres
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["ADRES"]);
                }
            }

            public Object Dyeri
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["DYERI"]);
                }
            }

            public GetAllHCWithThreeSpecialist_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetAllHCWithThreeSpecialist_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetAllHCWithThreeSpecialist_Class() : base() { }
        }

        [Serializable] 

        public partial class GetHCWTSByDateAndUniqueRefNo_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEWITHTHREESPECIALIST"].AllPropertyDefs["ID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEWITHTHREESPECIALIST"].AllPropertyDefs["REPORTNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEWITHTHREESPECIALIST"].AllPropertyDefs["REPORTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetHCWTSByDateAndUniqueRefNo_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetHCWTSByDateAndUniqueRefNo_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetHCWTSByDateAndUniqueRefNo_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetCancelledHCWithThreeSpecialist_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEWITHTHREESPECIALIST"].AllPropertyDefs["REPORTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Decision
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DECISION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEWITHTHREESPECIALIST"].AllPropertyDefs["OFFEROFDECISION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public OLAP_GetCancelledHCWithThreeSpecialist_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetCancelledHCWithThreeSpecialist_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetCancelledHCWithThreeSpecialist_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetHCWithThreeSpecialistByDate_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEWITHTHREESPECIALIST"].AllPropertyDefs["REPORTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEWITHTHREESPECIALIST"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? Chairsentto
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CHAIRSENTTO"]);
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

            public int? NumberOfProcess
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NUMBEROFPROCESS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEWITHTHREESPECIALIST"].AllPropertyDefs["NUMBEROFPROCESS"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string Decision
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DECISION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEWITHTHREESPECIALIST"].AllPropertyDefs["OFFEROFDECISION"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public OLAP_GetHCWithThreeSpecialistByDate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetHCWithThreeSpecialistByDate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetHCWithThreeSpecialistByDate_Class() : base() { }
        }

        [Serializable] 

        public partial class GetHCWithThreeSpecialistsByDate_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? Bolumid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["BOLUMID"]);
                }
            }

            public long? Raporno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RAPORNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEWITHTHREESPECIALIST"].AllPropertyDefs["REPORTNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEWITHTHREESPECIALIST"].AllPropertyDefs["REPORTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public long? Skno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SKNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEWITHTHREESPECIALIST"].AllPropertyDefs["PROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public long? Karantinano
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KARANTINANO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["QUARANTINEPROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? Hgiristarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HGIRISTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["OPENINGDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? Hcikistarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HCIKISTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["HOSPITALDISCHARGEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
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

            public string Evrakno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EVRAKNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["DOCUMENTNUMBER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Maksat
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MAKSAT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REASONFOREXAMINATIONDEFINITION"].AllPropertyDefs["REASON"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Patientid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PATIENTID"]);
                }
            }

            public int? Kilo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KILO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEWITHTHREESPECIALIST"].AllPropertyDefs["WEIGHT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? Boy
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BOY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEWITHTHREESPECIALIST"].AllPropertyDefs["HEIGHT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? Kacincimuayenesi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KACINCIMUAYENESI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEWITHTHREESPECIALIST"].AllPropertyDefs["NUMBEROFPROCESS"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string Karar
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KARAR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEWITHTHREESPECIALIST"].AllPropertyDefs["OFFEROFDECISION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public object Rapor
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RAPOR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEWITHTHREESPECIALIST"].AllPropertyDefs["REPORT"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public Object Hastagrubu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["HASTAGRUBU"]);
                }
            }

            public Object Adres
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["ADRES"]);
                }
            }

            public Object Dyeri
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["DYERI"]);
                }
            }

            public GetHCWithThreeSpecialistsByDate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetHCWithThreeSpecialistsByDate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetHCWithThreeSpecialistsByDate_Class() : base() { }
        }

        public static class States
        {
            public static Guid Completed { get { return new Guid("43e91ef2-8233-475e-935b-1b0dfa809a08"); } }
    /// <summary>
    /// 1. Ek Birimde
    /// </summary>
            public static Guid FirstAdditionalUnit { get { return new Guid("b98ca233-fd4d-46aa-9c2a-745fa7d54cc0"); } }
    /// <summary>
    /// 3. Uzman Tabip Onay
    /// </summary>
            public static Guid ThirdSpecialistApproval { get { return new Guid("b7fe30d1-404b-437a-aaa6-9ddb485f53d3"); } }
            public static Guid Request { get { return new Guid("75cb042f-83e8-40c8-be46-3cb979f6f8db"); } }
            public static Guid New { get { return new Guid("55eec3f7-ef9b-4016-a9f6-79b856222a25"); } }
    /// <summary>
    /// 2. Uzman Tabip Onay
    /// </summary>
            public static Guid SecondSpecialistApproval { get { return new Guid("823ccc31-2b6e-41d9-8106-bfe433f0bb2c"); } }
    /// <summary>
    /// Başhekim Rapor Onayı
    /// </summary>
            public static Guid Report { get { return new Guid("b944d520-7aab-4a35-a390-d50ac8619d4d"); } }
    /// <summary>
    /// İptal State i
    /// </summary>
            public static Guid Cancelled { get { return new Guid("2914c090-f5e1-4c0e-a624-f2f73f4c1aa2"); } }
    /// <summary>
    /// 2. Ek Birimde
    /// </summary>
            public static Guid SecondAdditionalUnit { get { return new Guid("c9af5c3d-045e-4817-a54a-c46f94f155ee"); } }
        }

    /// <summary>
    /// objectID ile transition daki HealthCommitteeWithThreeSpecialist i get eder
    /// </summary>
        public static BindingList<HealthCommitteeWithThreeSpecialist.GetHCWithThreeSpecialist_Class> GetHCWithThreeSpecialist(string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEWITHTHREESPECIALIST"].QueryDefs["GetHCWithThreeSpecialist"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<HealthCommitteeWithThreeSpecialist.GetHCWithThreeSpecialist_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// objectID ile transition daki HealthCommitteeWithThreeSpecialist i get eder
    /// </summary>
        public static BindingList<HealthCommitteeWithThreeSpecialist.GetHCWithThreeSpecialist_Class> GetHCWithThreeSpecialist(TTObjectContext objectContext, string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEWITHTHREESPECIALIST"].QueryDefs["GetHCWithThreeSpecialist"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<HealthCommitteeWithThreeSpecialist.GetHCWithThreeSpecialist_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<HealthCommitteeWithThreeSpecialist.GetAllHCWithThreeSpecialist_Class> GetAllHCWithThreeSpecialist(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEWITHTHREESPECIALIST"].QueryDefs["GetAllHCWithThreeSpecialist"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<HealthCommitteeWithThreeSpecialist.GetAllHCWithThreeSpecialist_Class>(queryDef, paramList, pi);
        }

        public static BindingList<HealthCommitteeWithThreeSpecialist.GetAllHCWithThreeSpecialist_Class> GetAllHCWithThreeSpecialist(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEWITHTHREESPECIALIST"].QueryDefs["GetAllHCWithThreeSpecialist"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<HealthCommitteeWithThreeSpecialist.GetAllHCWithThreeSpecialist_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<HealthCommitteeWithThreeSpecialist.GetHCWTSByDateAndUniqueRefNo_Class> GetHCWTSByDateAndUniqueRefNo(DateTime STARTDATE, DateTime ENDDATE, string UNIQUEREFNO, int UNIQUEREFNOFLAG, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEWITHTHREESPECIALIST"].QueryDefs["GetHCWTSByDateAndUniqueRefNo"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("UNIQUEREFNO", UNIQUEREFNO);
            paramList.Add("UNIQUEREFNOFLAG", UNIQUEREFNOFLAG);

            return TTReportNqlObject.QueryObjects<HealthCommitteeWithThreeSpecialist.GetHCWTSByDateAndUniqueRefNo_Class>(queryDef, paramList, pi);
        }

        public static BindingList<HealthCommitteeWithThreeSpecialist.GetHCWTSByDateAndUniqueRefNo_Class> GetHCWTSByDateAndUniqueRefNo(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, string UNIQUEREFNO, int UNIQUEREFNOFLAG, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEWITHTHREESPECIALIST"].QueryDefs["GetHCWTSByDateAndUniqueRefNo"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("UNIQUEREFNO", UNIQUEREFNO);
            paramList.Add("UNIQUEREFNOFLAG", UNIQUEREFNOFLAG);

            return TTReportNqlObject.QueryObjects<HealthCommitteeWithThreeSpecialist.GetHCWTSByDateAndUniqueRefNo_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<HealthCommitteeWithThreeSpecialist.OLAP_GetCancelledHCWithThreeSpecialist_Class> OLAP_GetCancelledHCWithThreeSpecialist(DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEWITHTHREESPECIALIST"].QueryDefs["OLAP_GetCancelledHCWithThreeSpecialist"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<HealthCommitteeWithThreeSpecialist.OLAP_GetCancelledHCWithThreeSpecialist_Class>(queryDef, paramList, pi);
        }

        public static BindingList<HealthCommitteeWithThreeSpecialist.OLAP_GetCancelledHCWithThreeSpecialist_Class> OLAP_GetCancelledHCWithThreeSpecialist(TTObjectContext objectContext, DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEWITHTHREESPECIALIST"].QueryDefs["OLAP_GetCancelledHCWithThreeSpecialist"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<HealthCommitteeWithThreeSpecialist.OLAP_GetCancelledHCWithThreeSpecialist_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<HealthCommitteeWithThreeSpecialist.OLAP_GetHCWithThreeSpecialistByDate_Class> OLAP_GetHCWithThreeSpecialistByDate(DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEWITHTHREESPECIALIST"].QueryDefs["OLAP_GetHCWithThreeSpecialistByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<HealthCommitteeWithThreeSpecialist.OLAP_GetHCWithThreeSpecialistByDate_Class>(queryDef, paramList, pi);
        }

        public static BindingList<HealthCommitteeWithThreeSpecialist.OLAP_GetHCWithThreeSpecialistByDate_Class> OLAP_GetHCWithThreeSpecialistByDate(TTObjectContext objectContext, DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEWITHTHREESPECIALIST"].QueryDefs["OLAP_GetHCWithThreeSpecialistByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<HealthCommitteeWithThreeSpecialist.OLAP_GetHCWithThreeSpecialistByDate_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<HealthCommitteeWithThreeSpecialist.GetHCWithThreeSpecialistsByDate_Class> GetHCWithThreeSpecialistsByDate(DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEWITHTHREESPECIALIST"].QueryDefs["GetHCWithThreeSpecialistsByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<HealthCommitteeWithThreeSpecialist.GetHCWithThreeSpecialistsByDate_Class>(queryDef, paramList, pi);
        }

        public static BindingList<HealthCommitteeWithThreeSpecialist.GetHCWithThreeSpecialistsByDate_Class> GetHCWithThreeSpecialistsByDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEWITHTHREESPECIALIST"].QueryDefs["GetHCWithThreeSpecialistsByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<HealthCommitteeWithThreeSpecialist.GetHCWithThreeSpecialistsByDate_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<HealthCommitteeWithThreeSpecialist> GetBySubEpisode(TTObjectContext objectContext, Guid SUBEPISODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEWITHTHREESPECIALIST"].QueryDefs["GetBySubEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODE", SUBEPISODE);

            return ((ITTQuery)objectContext).QueryObjects<HealthCommitteeWithThreeSpecialist>(queryDef, paramList);
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
    /// Karar Teklifi
    /// </summary>
        public string OfferofDecision
        {
            get { return (string)this["OFFEROFDECISION"]; }
            set { this["OFFEROFDECISION"] = value; }
        }

    /// <summary>
    /// Kabul Sebebi
    /// </summary>
        public string ReasonForAdmission
        {
            get { return (string)this["REASONFORADMISSION"]; }
            set { this["REASONFORADMISSION"] = value; }
        }

    /// <summary>
    /// Kilo
    /// </summary>
        public int? Weight
        {
            get { return (int?)this["WEIGHT"]; }
            set { this["WEIGHT"] = value; }
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
    /// Protokol No
    /// </summary>
        public TTSequence ProtocolNo
        {
            get { return GetSequence("PROTOCOLNO"); }
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
    /// Ek Karar
    /// </summary>
        public string AdditionalDecision
        {
            get { return (string)this["ADDITIONALDECISION"]; }
            set { this["ADDITIONALDECISION"] = value; }
        }

    /// <summary>
    /// İstek Açıklaması
    /// </summary>
        public string ExplanationOfRequest
        {
            get { return (string)this["EXPLANATIONOFREQUEST"]; }
            set { this["EXPLANATIONOFREQUEST"] = value; }
        }

    /// <summary>
    /// Fotoğrafı
    /// </summary>
        public object Picture
        {
            get { return (object)this["PICTURE"]; }
            set { this["PICTURE"] = value; }
        }

    /// <summary>
    /// Klinik/Poliklinik Rapor No
    /// </summary>
        public TTSequence ClinicReportNo
        {
            get { return GetSequence("CLINICREPORTNO"); }
        }

    /// <summary>
    /// Rapor No
    /// </summary>
        public TTSequence ReportNo
        {
            get { return GetSequence("REPORTNO"); }
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
    /// Rapor Başlangıç Tarihi
    /// </summary>
        public DateTime? ReportStartDate
        {
            get { return (DateTime?)this["REPORTSTARTDATE"]; }
            set { this["REPORTSTARTDATE"] = value; }
        }

    /// <summary>
    /// Rapor Bitiş Tarihi
    /// </summary>
        public DateTime? ReportEndDate
        {
            get { return (DateTime?)this["REPORTENDDATE"]; }
            set { this["REPORTENDDATE"] = value; }
        }

    /// <summary>
    /// Rapor Karar Tarihi
    /// </summary>
        public DateTime? DecisionDate
        {
            get { return (DateTime?)this["DECISIONDATE"]; }
            set { this["DECISIONDATE"] = value; }
        }

    /// <summary>
    /// İstirahat Raporu Karar Türü
    /// </summary>
        public HCTRestReportDecisionTypeEnum? RestReportDecision
        {
            get { return (HCTRestReportDecisionTypeEnum?)(int?)this["RESTREPORTDECISION"]; }
            set { this["RESTREPORTDECISION"] = value; }
        }

    /// <summary>
    /// Durum Bildirir Tek Hekim Raporu Verilme Nedeni
    /// </summary>
        public HCTSituationInformODTypeEnum? SituationInformODReportType
        {
            get { return (HCTSituationInformODTypeEnum?)(int?)this["SITUATIONINFORMODREPORTTYPE"]; }
            set { this["SITUATIONINFORMODREPORTTYPE"] = value; }
        }

    /// <summary>
    /// Durum Bildirir Tek Hekim Raporu Karar Türü
    /// </summary>
        public HCTSituationInformODDecisionEnum? SituationInformODDecision
        {
            get { return (HCTSituationInformODDecisionEnum?)(int?)this["SITUATIONINFORMODDECISION"]; }
            set { this["SITUATIONINFORMODDECISION"] = value; }
        }

    /// <summary>
    /// Engeli Olmayan Durum
    /// </summary>
        public string NoObstacleDescription
        {
            get { return (string)this["NOOBSTACLEDESCRIPTION"]; }
            set { this["NOOBSTACLEDESCRIPTION"] = value; }
        }

    /// <summary>
    /// Medula Rapor Takip No
    /// </summary>
        public string MedulaRaporTakipNo
        {
            get { return (string)this["MEDULARAPORTAKIPNO"]; }
            set { this["MEDULARAPORTAKIPNO"] = value; }
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
    /// Muamele Sayısı
    /// </summary>
        public int? NumberOfProcess
        {
            get { return (int?)this["NUMBEROFPROCESS"]; }
            set { this["NUMBEROFPROCESS"] = value; }
        }

    /// <summary>
    /// Bulgular
    /// </summary>
        public object HCThreeSpecialistDescription
        {
            get { return (object)this["HCTHREESPECIALISTDESCRIPTION"]; }
            set { this["HCTHREESPECIALISTDESCRIPTION"] = value; }
        }

    /// <summary>
    /// Muayene Sebebi
    /// </summary>
        public HCTReasonForExaminationDefinition ExaminationReason
        {
            get { return (HCTReasonForExaminationDefinition)((ITTObject)this).GetParent("EXAMINATIONREASON"); }
            set { this["EXAMINATIONREASON"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// İstek Yapan Birim
    /// </summary>
        public ResSection Department
        {
            get { return (ResSection)((ITTObject)this).GetParent("DEPARTMENT"); }
            set { this["DEPARTMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// 2. Ek Birim Doktoru
    /// </summary>
        public ResUser AdditionalSpecialist2
        {
            get { return (ResUser)((ITTObject)this).GetParent("ADDITIONALSPECIALIST2"); }
            set { this["ADDITIONALSPECIALIST2"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// 2. Ek Birim
    /// </summary>
        public ResSection SecondAdditionalUnit
        {
            get { return (ResSection)((ITTObject)this).GetParent("SECONDADDITIONALUNIT"); }
            set { this["SECONDADDITIONALUNIT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Ne Maksatla Muayene Edildiği
    /// </summary>
        public ReasonForExaminationDefinition ReasonForExamination
        {
            get { return (ReasonForExaminationDefinition)((ITTObject)this).GetParent("REASONFOREXAMINATION"); }
            set { this["REASONFOREXAMINATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// 1. Ek Birim
    /// </summary>
        public ResSection FirstAdditionalUnit
        {
            get { return (ResSection)((ITTObject)this).GetParent("FIRSTADDITIONALUNIT"); }
            set { this["FIRSTADDITIONALUNIT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// 1. Ek Birim Doktoru
    /// </summary>
        public ResUser AdditionalSpecialist1
        {
            get { return (ResUser)((ITTObject)this).GetParent("ADDITIONALSPECIALIST1"); }
            set { this["ADDITIONALSPECIALIST1"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Sağlık Kurulu Kararı
    /// </summary>
        public HealthCommitteeDecisionDefinition HealthCommitteeDecision
        {
            get { return (HealthCommitteeDecisionDefinition)((ITTObject)this).GetParent("HEALTHCOMMITTEEDECISION"); }
            set { this["HEALTHCOMMITTEEDECISION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Sağlık Kurulu Karar Kategorisi
    /// </summary>
        public HealthCommitteeDecisionCategoryDefinition HCDecisionCategory
        {
            get { return (HealthCommitteeDecisionCategoryDefinition)((ITTObject)this).GetParent("HCDECISIONCATEGORY"); }
            set { this["HCDECISIONCATEGORY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateReturnDescriptionsCollection()
        {
            _ReturnDescriptions = new HealthCommittee_ReturnDescriptionsGrid.ChildHealthCommittee_ReturnDescriptionsGridCollection(this, new Guid("6bb0df43-59f2-4715-bb13-1bf60ab6a1fe"));
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

        virtual protected void CreateMatterSliceAnectodesCollection()
        {
            _MatterSliceAnectodes = new HCWithThreeSpecialist_MatterSliceAnectodeGrid.ChildHCWithThreeSpecialist_MatterSliceAnectodeGridCollection(this, new Guid("a5c578d7-1976-42f6-a423-221956ca48db"));
            ((ITTChildObjectCollection)_MatterSliceAnectodes).GetChildren();
        }

        protected HCWithThreeSpecialist_MatterSliceAnectodeGrid.ChildHCWithThreeSpecialist_MatterSliceAnectodeGridCollection _MatterSliceAnectodes = null;
    /// <summary>
    /// Child collection for Madde Dilim Fıkra
    /// </summary>
        public HCWithThreeSpecialist_MatterSliceAnectodeGrid.ChildHCWithThreeSpecialist_MatterSliceAnectodeGridCollection MatterSliceAnectodes
        {
            get
            {
                if (_MatterSliceAnectodes == null)
                    CreateMatterSliceAnectodesCollection();
                return _MatterSliceAnectodes;
            }
        }

        virtual protected void CreateHCWMatterSliceAnectodesCollection()
        {
            _HCWMatterSliceAnectodes = new HCMatterSliceAnectodeDefinitionGrid.ChildHCMatterSliceAnectodeDefinitionGridCollection(this, new Guid("cfa92766-2463-45e2-a45b-5b0a69e7d814"));
            ((ITTChildObjectCollection)_HCWMatterSliceAnectodes).GetChildren();
        }

        protected HCMatterSliceAnectodeDefinitionGrid.ChildHCMatterSliceAnectodeDefinitionGridCollection _HCWMatterSliceAnectodes = null;
        public HCMatterSliceAnectodeDefinitionGrid.ChildHCMatterSliceAnectodeDefinitionGridCollection HCWMatterSliceAnectodes
        {
            get
            {
                if (_HCWMatterSliceAnectodes == null)
                    CreateHCWMatterSliceAnectodesCollection();
                return _HCWMatterSliceAnectodes;
            }
        }

        virtual protected void CreateSpecialistsCollection()
        {
            _Specialists = new HealthCommitteeWithThreeSpecialist_ThreeSpecialistGrid.ChildHealthCommitteeWithThreeSpecialist_ThreeSpecialistGridCollection(this, new Guid("020aa26d-3715-4cd5-83b0-9ca064f608df"));
            ((ITTChildObjectCollection)_Specialists).GetChildren();
        }

        protected HealthCommitteeWithThreeSpecialist_ThreeSpecialistGrid.ChildHealthCommitteeWithThreeSpecialist_ThreeSpecialistGridCollection _Specialists = null;
        public HealthCommitteeWithThreeSpecialist_ThreeSpecialistGrid.ChildHealthCommitteeWithThreeSpecialist_ThreeSpecialistGridCollection Specialists
        {
            get
            {
                if (_Specialists == null)
                    CreateSpecialistsCollection();
                return _Specialists;
            }
        }

        override protected void CreateSubactionProceduresCollectionViews()
        {
            base.CreateSubactionProceduresCollectionViews();
            _HCWithThreeSpecialistProcedures = new HealthCommitteeProcedure.ChildHealthCommitteeProcedureCollection(_SubactionProcedures, "HCWithThreeSpecialistProcedures");
        }

        private HealthCommitteeProcedure.ChildHealthCommitteeProcedureCollection _HCWithThreeSpecialistProcedures = null;
        public HealthCommitteeProcedure.ChildHealthCommitteeProcedureCollection HCWithThreeSpecialistProcedures
        {
            get
            {
                if (_SubactionProcedures == null)
                    CreateSubactionProceduresCollection();
                return _HCWithThreeSpecialistProcedures;
            }            
        }

        protected HealthCommitteeWithThreeSpecialist(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HealthCommitteeWithThreeSpecialist(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HealthCommitteeWithThreeSpecialist(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HealthCommitteeWithThreeSpecialist(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HealthCommitteeWithThreeSpecialist(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HEALTHCOMMITTEEWITHTHREESPECIALIST", dataRow) { }
        protected HealthCommitteeWithThreeSpecialist(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HEALTHCOMMITTEEWITHTHREESPECIALIST", dataRow, isImported) { }
        public HealthCommitteeWithThreeSpecialist(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HealthCommitteeWithThreeSpecialist(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HealthCommitteeWithThreeSpecialist() : base() { }

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
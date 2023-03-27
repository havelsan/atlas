
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SubEpisodeProtocol")] 

    /// <summary>
    /// Alt vaka bazında kurum anlaşma takip bilgisini içerir
    /// </summary>
    public  partial class SubEpisodeProtocol : TTObject
    {
        public class SubEpisodeProtocolList : TTObjectCollection<SubEpisodeProtocol> { }
                    
        public class ChildSubEpisodeProtocolCollection : TTObject.TTChildObjectCollection<SubEpisodeProtocol>
        {
            public ChildSubEpisodeProtocolCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSubEpisodeProtocolCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetByObjectID_Class : TTReportNqlObject 
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

            public int? Patientyupassno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTYUPASSNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["YUPASSNO"].DataType;
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

            public string Basvuruno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BASVURUNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODEPROTOCOL"].AllPropertyDefs["MEDULABASVURUNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Takipno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TAKIPNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODEPROTOCOL"].AllPropertyDefs["MEDULATAKIPNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Baglitakipno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BAGLITAKIPNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODEPROTOCOL"].AllPropertyDefs["MEDULATAKIPNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? Yupassno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["YUPASSNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODEPROTOCOL"].AllPropertyDefs["MEDULAYUPASSNO"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public DateTime? Provizyontarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROVIZYONTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODEPROTOCOL"].AllPropertyDefs["MEDULAPROVIZYONTARIHI"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Devredilenkurum
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DEVREDILENKURUM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DEVREDILENKURUM"].AllPropertyDefs["DEVREDILENKURUMADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Provizyontipi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROVIZYONTIPI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROVIZYONTIPI"].AllPropertyDefs["PROVIZYONTIPIADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Sigortalituru
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SIGORTALITURU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SIGORTALITURU"].AllPropertyDefs["SIGORTALITURUADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Istisnaihal
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISTISNAIHAL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ISTISNAIHAL"].AllPropertyDefs["ADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Takiptipi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TAKIPTIPI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TAKIPTIPI"].AllPropertyDefs["TAKIPTIPIADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Tedavitipi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TEDAVITIPI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TEDAVITIPI"].AllPropertyDefs["TEDAVITIPIADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Tedavituru
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TEDAVITURU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TEDAVITURU"].AllPropertyDefs["TEDAVITURUADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Invoicestatus
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["INVOICESTATUS"]);
                }
            }

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? SubEpisode
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SUBEPISODE"]);
                }
            }

            public Guid? Episode
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODE"]);
                }
            }

            public GetByObjectID_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetByObjectID_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetByObjectID_Class() : base() { }
        }

        [Serializable] 

        public partial class GetBySEPMaster_Class : TTReportNqlObject 
        {
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

            public string MedulaBasvuruNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULABASVURUNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODEPROTOCOL"].AllPropertyDefs["MEDULABASVURUNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string MedulaTakipNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULATAKIPNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODEPROTOCOL"].AllPropertyDefs["MEDULATAKIPNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Baglitakipno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BAGLITAKIPNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODEPROTOCOL"].AllPropertyDefs["MEDULATAKIPNO"].DataType;
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

            public Guid? MedulaTedaviTuru
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MEDULATEDAVITURU"]);
                }
            }

            public Guid? Tedavituru
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["TEDAVITURU"]);
                }
            }

            public Guid? MedulaProvizyonTipi
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MEDULAPROVIZYONTIPI"]);
                }
            }

            public Guid? MedulaTedaviTipi
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MEDULATEDAVITIPI"]);
                }
            }

            public Guid? MedulaTakipTipi
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MEDULATAKIPTIPI"]);
                }
            }

            public DateTime? MedulaProvizyonTarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULAPROVIZYONTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODEPROTOCOL"].AllPropertyDefs["MEDULAPROVIZYONTARIHI"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Currency? MedulaFaturaTutari
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULAFATURATUTARI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODEPROTOCOL"].AllPropertyDefs["MEDULAFATURATUTARI"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Object Invoicestatus
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["INVOICESTATUS"]);
                }
            }

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public long? Id
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODEPROTOCOL"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODEPROTOCOL"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? SubEpisode
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SUBEPISODE"]);
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

            public Guid? Episode
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODE"]);
                }
            }

            public GetBySEPMaster_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetBySEPMaster_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetBySEPMaster_Class() : base() { }
        }

        [Serializable] 

        public partial class GetAllPatientInfoByDate_Class : TTReportNqlObject 
        {
            public Guid? Paid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PAID"]);
                }
            }

            public Guid? Patientid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PATIENTID"]);
                }
            }

            public Object Fullname
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["FULLNAME"]);
                }
            }

            public DateTime? ActionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSION"].AllPropertyDefs["ACTIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERTYPEDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string MedulaTakipNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULATAKIPNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODEPROTOCOL"].AllPropertyDefs["MEDULATAKIPNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Patientadmissionnumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTADMISSIONNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].AllPropertyDefs["PROTOCOLNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Policlinic
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["POLICLINIC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESPOLICLINIC"].AllPropertyDefs["NAME"].DataType;
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

            public string Forensiccasetype
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FORENSICCASETYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSADLIVAKAGELISSEKLI"].AllPropertyDefs["ADI"].DataType;
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

            public string Triage
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TRIAGE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSTRIAJKODU"].AllPropertyDefs["ADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Kabulkullanici
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KABULKULLANICI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetAllPatientInfoByDate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetAllPatientInfoByDate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetAllPatientInfoByDate_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPAInfoByDateWithProvision_Class : TTReportNqlObject 
        {
            public Guid? Paid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PAID"]);
                }
            }

            public Guid? Patientid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PATIENTID"]);
                }
            }

            public Object Fullname
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["FULLNAME"]);
                }
            }

            public DateTime? ActionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSION"].AllPropertyDefs["ACTIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERTYPEDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string MedulaTakipNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULATAKIPNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODEPROTOCOL"].AllPropertyDefs["MEDULATAKIPNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Patientadmissionnumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTADMISSIONNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].AllPropertyDefs["PROTOCOLNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Policlinic
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["POLICLINIC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESPOLICLINIC"].AllPropertyDefs["NAME"].DataType;
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

            public string Forensiccasetype
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FORENSICCASETYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSADLIVAKAGELISSEKLI"].AllPropertyDefs["ADI"].DataType;
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

            public string Triage
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TRIAGE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSTRIAJKODU"].AllPropertyDefs["ADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Kabulkullanici
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KABULKULLANICI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetPAInfoByDateWithProvision_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPAInfoByDateWithProvision_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPAInfoByDateWithProvision_Class() : base() { }
        }

        [Serializable] 

        public partial class GetSEPByInjection_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? SubEpisode
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SUBEPISODE"]);
                }
            }

            public DateTime? MedulaProvizyonTarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULAPROVIZYONTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODEPROTOCOL"].AllPropertyDefs["MEDULAPROVIZYONTARIHI"].DataType;
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

            public DateTime? Inpatientdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INPATIENTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["HOSPITALINPATIENTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? Dischargedate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISCHARGEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["HOSPITALDISCHARGEDATE"].DataType;
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

            public string MedulaBasvuruNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULABASVURUNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODEPROTOCOL"].AllPropertyDefs["MEDULABASVURUNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string MedulaTakipNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULATAKIPNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODEPROTOCOL"].AllPropertyDefs["MEDULATAKIPNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Baglitakipno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BAGLITAKIPNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODEPROTOCOL"].AllPropertyDefs["MEDULATAKIPNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Tedavituru
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TEDAVITURU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TEDAVITURU"].AllPropertyDefs["TEDAVITURUADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Status
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["STATUS"]);
                }
            }

            public MedulaSubEpisodeStatusEnum? Statusenum
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STATUSENUM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODEPROTOCOL"].AllPropertyDefs["INVOICESTATUS"].DataType;
                    return (MedulaSubEpisodeStatusEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public Object Medulafaturatutari
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["MEDULAFATURATUTARI"]);
                }
            }

            public Object Hbystutari
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["HBYSTUTARI"]);
                }
            }

            public long? Id
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODEPROTOCOL"].AllPropertyDefs["ID"].DataType;
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

            public PayerTypeEnum? PayerType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PAYERTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERTYPEDEFINITION"].AllPropertyDefs["PAYERTYPE"].DataType;
                    return (PayerTypeEnum?)(int)dataType.ConvertValue(val);
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

            public string Icname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ICNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INVOICECOLLECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? Icno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ICNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INVOICECOLLECTION"].AllPropertyDefs["NO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Subepisoderessection
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUBEPISODERESSECTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Izlemusername
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["IZLEMUSERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string MedulaSonucKodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULASONUCKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODEPROTOCOL"].AllPropertyDefs["MEDULASONUCKODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string MedulaSonucMesaji
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULASONUCMESAJI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODEPROTOCOL"].AllPropertyDefs["MEDULASONUCMESAJI"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public GetSEPByInjection_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSEPByInjection_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSEPByInjection_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPaBySearchPatientForTreatmentReport_Class : TTReportNqlObject 
        {
            public Guid? Pasobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PASOBJECTID"]);
                }
            }

            public Guid? Sepobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SEPOBJECTID"]);
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

            public string Takipno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TAKIPNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODEPROTOCOL"].AllPropertyDefs["MEDULATAKIPNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSION"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Tedavituru
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TEDAVITURU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TEDAVITURU"].AllPropertyDefs["TEDAVITURUADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Brans
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BRANS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SPECIALITYDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Bransno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BRANSNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SPECIALITYDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Baglitakipno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BAGLITAKIPNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODEPROTOCOL"].AllPropertyDefs["MEDULATAKIPNO"].DataType;
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

            public long? Hprotocolno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HPROTOCOLNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["HOSPITALPROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? Vakaacilistarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["VAKAACILISTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["OPENINGDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? StarterEpisodeAction
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STARTEREPISODEACTION"]);
                }
            }

            public GetPaBySearchPatientForTreatmentReport_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPaBySearchPatientForTreatmentReport_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPaBySearchPatientForTreatmentReport_Class() : base() { }
        }

        [Serializable] 

        public partial class GetAllPatientInfoByDateWithoutUser_Class : TTReportNqlObject 
        {
            public Guid? Paid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PAID"]);
                }
            }

            public Guid? Patientid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PATIENTID"]);
                }
            }

            public Object Fullname
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["FULLNAME"]);
                }
            }

            public DateTime? ActionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSION"].AllPropertyDefs["ACTIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERTYPEDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string MedulaTakipNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULATAKIPNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODEPROTOCOL"].AllPropertyDefs["MEDULATAKIPNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Patientadmissionnumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTADMISSIONNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].AllPropertyDefs["PROTOCOLNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Policlinic
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["POLICLINIC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESPOLICLINIC"].AllPropertyDefs["NAME"].DataType;
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

            public string Forensiccasetype
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FORENSICCASETYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSADLIVAKAGELISSEKLI"].AllPropertyDefs["ADI"].DataType;
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

            public string Triage
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TRIAGE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSTRIAJKODU"].AllPropertyDefs["ADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Kabulkullanici
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KABULKULLANICI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetAllPatientInfoByDateWithoutUser_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetAllPatientInfoByDateWithoutUser_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetAllPatientInfoByDateWithoutUser_Class() : base() { }
        }

        [Serializable] 

        public partial class GetEpisodeByInjection_Class : TTReportNqlObject 
        {
            public Object Sepobjectid
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["SEPOBJECTID"]);
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

            public DateTime? Inpatientdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INPATIENTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["HOSPITALINPATIENTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? Dischargedate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISCHARGEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["HOSPITALINPATIENTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
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

            public Object Tedavituru
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TEDAVITURU"]);
                }
            }

            public Object Icname
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["ICNAME"]);
                }
            }

            public Object Icno
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["ICNO"]);
                }
            }

            public Object Status
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["STATUS"]);
                }
            }

            public Object Faturatutari
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["FATURATUTARI"]);
                }
            }

            public Object Hbystutari
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["HBYSTUTARI"]);
                }
            }

            public Object Payername
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PAYERNAME"]);
                }
            }

            public Object Payertype
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PAYERTYPE"]);
                }
            }

            public GetEpisodeByInjection_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetEpisodeByInjection_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetEpisodeByInjection_Class() : base() { }
        }

        [Serializable] 

        public partial class GetSepCountByDate_Class : TTReportNqlObject 
        {
            public Object Totalcount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOTALCOUNT"]);
                }
            }

            public GetSepCountByDate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSepCountByDate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSepCountByDate_Class() : base() { }
        }

        [Serializable] 

        public partial class GetTigIBAG_Class : TTReportNqlObject 
        {
            public Object Procedurecount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PROCEDURECOUNT"]);
                }
            }

            public Object Externalcode
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["EXTERNALCODE"]);
                }
            }

            public Object Payertype
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PAYERTYPE"]);
                }
            }

            public GetTigIBAG_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetTigIBAG_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetTigIBAG_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPaBySearchPatient_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
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

            public string Admissiontypecode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADMISSIONTYPECODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROVIZYONTIPI"].AllPropertyDefs["PROVIZYONTIPIKODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Pastatus
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PASTATUS"]);
                }
            }

            public Object Admissionstatus
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["ADMISSIONSTATUS"]);
                }
            }

            public string Provisionno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROVISIONNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODEPROTOCOL"].AllPropertyDefs["MEDULATAKIPNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? Openingdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OPENINGDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSION"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
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

            public string Policlinicname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["POLICLINICNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESPOLICLINIC"].AllPropertyDefs["NAME"].DataType;
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

            public string Username
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["USERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Fromse
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["FROMSE"]);
                }
            }

            public GetPaBySearchPatient_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPaBySearchPatient_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPaBySearchPatient_Class() : base() { }
        }

        [Serializable] 

        public partial class GetTigBBAG_Class : TTReportNqlObject 
        {
            public Object Nqlcolumn
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["NQLCOLUMN"]);
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

            public Object Payertype
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PAYERTYPE"]);
                }
            }

            public GetTigBBAG_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetTigBBAG_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetTigBBAG_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPAInfoByDateWithoutProvision_Class : TTReportNqlObject 
        {
            public Guid? Paid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PAID"]);
                }
            }

            public Guid? Patientid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PATIENTID"]);
                }
            }

            public Object Fullname
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["FULLNAME"]);
                }
            }

            public DateTime? ActionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSION"].AllPropertyDefs["ACTIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERTYPEDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string MedulaTakipNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULATAKIPNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODEPROTOCOL"].AllPropertyDefs["MEDULATAKIPNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Patientadmissionnumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTADMISSIONNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].AllPropertyDefs["PROTOCOLNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Policlinic
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["POLICLINIC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESPOLICLINIC"].AllPropertyDefs["NAME"].DataType;
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

            public string Forensiccasetype
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FORENSICCASETYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSADLIVAKAGELISSEKLI"].AllPropertyDefs["ADI"].DataType;
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

            public string Triage
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TRIAGE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSTRIAJKODU"].AllPropertyDefs["ADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Kabulkullanici
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KABULKULLANICI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetPAInfoByDateWithoutProvision_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPAInfoByDateWithoutProvision_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPAInfoByDateWithoutProvision_Class() : base() { }
        }

        [Serializable] 

        public partial class GetInvoiceTotalPriceByTerm_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Object Invoiceprice
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["INVOICEPRICE"]);
                }
            }

            public GetInvoiceTotalPriceByTerm_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetInvoiceTotalPriceByTerm_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetInvoiceTotalPriceByTerm_Class() : base() { }
        }

        [Serializable] 

        public partial class GetMedulaSEPsByTerm_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
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

            public string MedulaBasvuruNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULABASVURUNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODEPROTOCOL"].AllPropertyDefs["MEDULABASVURUNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string MedulaTakipNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULATAKIPNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODEPROTOCOL"].AllPropertyDefs["MEDULATAKIPNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public MIFTypeEnum? MIFType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MIFTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERDEFINITION"].AllPropertyDefs["MIFTYPE"].DataType;
                    return (MIFTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string provizyonTipiKodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROVIZYONTIPIKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROVIZYONTIPI"].AllPropertyDefs["PROVIZYONTIPIKODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Istisnaihalkodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISTISNAIHALKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ISTISNAIHAL"].AllPropertyDefs["KODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Medulaprice
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["MEDULAPRICE"]);
                }
            }

            public GetMedulaSEPsByTerm_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMedulaSEPsByTerm_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMedulaSEPsByTerm_Class() : base() { }
        }

        [Serializable] 

        public partial class GetErrorByInjection_Class : TTReportNqlObject 
        {
            public string Sonuckodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SONUCKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODEPROTOCOL"].AllPropertyDefs["MEDULASONUCKODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Type
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TYPE"]);
                }
            }

            public Object Sayi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["SAYI"]);
                }
            }

            public GetErrorByInjection_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetErrorByInjection_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetErrorByInjection_Class() : base() { }
        }

        [Serializable] 

        public partial class GetErrorMessageByInjection_Class : TTReportNqlObject 
        {
            public string Sonucmesaji
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SONUCMESAJI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODEPROTOCOL"].AllPropertyDefs["MEDULASONUCMESAJI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Type
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TYPE"]);
                }
            }

            public Object Sayi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["SAYI"]);
                }
            }

            public GetErrorMessageByInjection_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetErrorMessageByInjection_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetErrorMessageByInjection_Class() : base() { }
        }

        [Serializable] 

        public partial class GetSEPObjectIDByInjection_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetSEPObjectIDByInjection_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSEPObjectIDByInjection_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSEPObjectIDByInjection_Class() : base() { }
        }

        [Serializable] 

        public partial class GetTrxCodeAndNameByInjection_Class : TTReportNqlObject 
        {
            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Sayi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["SAYI"]);
                }
            }

            public GetTrxCodeAndNameByInjection_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetTrxCodeAndNameByInjection_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetTrxCodeAndNameByInjection_Class() : base() { }
        }

        [Serializable] 

        public partial class InvoiceSEPDetailQuery_Class : TTReportNqlObject 
        {
            public Guid? Subepisodeobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SUBEPISODEOBJECTID"]);
                }
            }

            public Guid? Episodeobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODEOBJECTID"]);
                }
            }

            public Guid? Sepmasterobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SEPMASTEROBJECTID"]);
                }
            }

            public string Hospitalprotocolno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HOSPITALPROTOCOLNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].AllPropertyDefs["PROTOCOLNO"].DataType;
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

            public DateTime? Episodeclosingdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EPISODECLOSINGDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["CLOSINGDATE"].DataType;
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

            public DateTime? Subepisodeopeningdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUBEPISODEOPENINGDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].AllPropertyDefs["OPENINGDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? Subepisodeclosingdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUBEPISODECLOSINGDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].AllPropertyDefs["CLOSINGDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Medulatedaviturukodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULATEDAVITURUKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TEDAVITURU"].AllPropertyDefs["TEDAVITURUKODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Bransobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["BRANSOBJECTID"]);
                }
            }

            public Guid? Medulaistisnaihalobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MEDULAISTISNAIHALOBJECTID"]);
                }
            }

            public Guid? Triage
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["TRIAGE"]);
                }
            }

            public Guid? Medulasigortalituruobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MEDULASIGORTALITURUOBJECTID"]);
                }
            }

            public Guid? Pidobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PIDOBJECTID"]);
                }
            }

            public string Piddocumentno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PIDDOCUMENTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEDOCUMENT"].AllPropertyDefs["DOCUMENTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? Piddocumentdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PIDDOCUMENTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEDOCUMENT"].AllPropertyDefs["DOCUMENTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Piddescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PIDDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEDOCUMENT"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Invoicetermname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INVOICETERMNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INVOICETERM"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Icname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ICNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INVOICECOLLECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Icobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["ICOBJECTID"]);
                }
            }

            public long? Icno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ICNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INVOICECOLLECTION"].AllPropertyDefs["NO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public Object Invoicecancelcount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["INVOICECANCELCOUNT"]);
                }
            }

            public PayerTypeEnum? PayerType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PAYERTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERTYPEDEFINITION"].AllPropertyDefs["PAYERTYPE"].DataType;
                    return (PayerTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public Guid? Devredilenkurumobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DEVREDILENKURUMOBJECTID"]);
                }
            }

            public string MedulaSonucKodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULASONUCKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODEPROTOCOL"].AllPropertyDefs["MEDULASONUCKODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string MedulaSonucMesaji
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULASONUCMESAJI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODEPROTOCOL"].AllPropertyDefs["MEDULASONUCMESAJI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string MedulaBasvuruNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULABASVURUNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODEPROTOCOL"].AllPropertyDefs["MEDULABASVURUNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? MedulaProvizyonTarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULAPROVIZYONTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODEPROTOCOL"].AllPropertyDefs["MEDULAPROVIZYONTARIHI"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? DischargeDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISCHARGEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODEPROTOCOL"].AllPropertyDefs["DISCHARGEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public InvoiceSEPDetailQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public InvoiceSEPDetailQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected InvoiceSEPDetailQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetTotalMedulaPriceByTerm_Class : TTReportNqlObject 
        {
            public Object Medulainvoiceprice
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["MEDULAINVOICEPRICE"]);
                }
            }

            public GetTotalMedulaPriceByTerm_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetTotalMedulaPriceByTerm_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetTotalMedulaPriceByTerm_Class() : base() { }
        }

        [Serializable] 

        public partial class GetSEPByInjectionPrice_Class : TTReportNqlObject 
        {
            public Object Medulafaturatutari
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["MEDULAFATURATUTARI"]);
                }
            }

            public Object Hbystutari
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["HBYSTUTARI"]);
                }
            }

            public GetSEPByInjectionPrice_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSEPByInjectionPrice_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSEPByInjectionPrice_Class() : base() { }
        }

        [Serializable] 

        public partial class GetSEPSToCreateENabiz700_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetSEPSToCreateENabiz700_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSEPSToCreateENabiz700_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSEPSToCreateENabiz700_Class() : base() { }
        }

        [Serializable] 

        public partial class GetByInvoiceCollection_Class : TTReportNqlObject 
        {
            public Guid? Icdobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["ICDOBJECTID"]);
                }
            }

            public DateTime? Icdcreatedate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ICDCREATEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INVOICECOLLECTIONDETAIL"].AllPropertyDefs["CREATEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? Seobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SEOBJECTID"]);
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

            public Guid? Pidobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PIDOBJECTID"]);
                }
            }

            public string Invoiceno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INVOICENO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEDOCUMENT"].AllPropertyDefs["DOCUMENTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Currency? Invoiceprice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INVOICEPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEDOCUMENT"].AllPropertyDefs["TOTALPRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Object Payertype
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PAYERTYPE"]);
                }
            }

            public GetByInvoiceCollection_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetByInvoiceCollection_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetByInvoiceCollection_Class() : base() { }
        }

        [Serializable] 

        public partial class GetByInvoiceCollectionAlphabetic_Class : TTReportNqlObject 
        {
            public Guid? Icdobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["ICDOBJECTID"]);
                }
            }

            public Guid? Seobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SEOBJECTID"]);
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

            public Guid? Pidobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PIDOBJECTID"]);
                }
            }

            public string Invoiceno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INVOICENO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEDOCUMENT"].AllPropertyDefs["DOCUMENTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Currency? Invoiceprice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INVOICEPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEDOCUMENT"].AllPropertyDefs["TOTALPRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Object Payertype
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PAYERTYPE"]);
                }
            }

            public GetByInvoiceCollectionAlphabetic_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetByInvoiceCollectionAlphabetic_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetByInvoiceCollectionAlphabetic_Class() : base() { }
        }

        [Serializable] 

        public partial class SMSPatientListQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
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

            public string MobilePhone
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MOBILEPHONE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTIDENTITYANDADDRESS"].AllPropertyDefs["MOBILEPHONE"].DataType;
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

            public SMSPatientListQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public SMSPatientListQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected SMSPatientListQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetLast5InvoicesOfUser_Class : TTReportNqlObject 
        {
            public Guid? PayerInvoiceDocument
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PAYERINVOICEDOCUMENT"]);
                }
            }

            public DateTime? CreateDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CREATEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEDOCUMENT"].AllPropertyDefs["CREATEDATE"].DataType;
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

            public Object Protocolno
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PROTOCOLNO"]);
                }
            }

            public Object Faturatutari
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["FATURATUTARI"]);
                }
            }

            public GetLast5InvoicesOfUser_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetLast5InvoicesOfUser_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetLast5InvoicesOfUser_Class() : base() { }
        }

        [Serializable] 

        public partial class GetGroupedInvoicePricesByTerm_Class : TTReportNqlObject 
        {
            public Guid? Userobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["USEROBJECTID"]);
                }
            }

            public string Username
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["USERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Tedavituru
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TEDAVITURU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TEDAVITURU"].AllPropertyDefs["TEDAVITURUADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public PayerTypeEnum? PayerType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PAYERTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERTYPEDEFINITION"].AllPropertyDefs["PAYERTYPE"].DataType;
                    return (PayerTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public Object Faturatutari
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["FATURATUTARI"]);
                }
            }

            public GetGroupedInvoicePricesByTerm_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetGroupedInvoicePricesByTerm_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetGroupedInvoicePricesByTerm_Class() : base() { }
        }

        public static class States
        {
    /// <summary>
    /// Açık
    /// </summary>
            public static Guid Open { get { return new Guid("3d703a14-0b94-46ea-a581-7c6b825ecb47"); } }
    /// <summary>
    /// Kapalı
    /// </summary>
            public static Guid Closed { get { return new Guid("8ddb62d4-f0af-4a81-932a-676507459325"); } }
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancelled { get { return new Guid("1db8eac1-f94e-46e2-82c4-a3892a55339c"); } }
        }

        public static BindingList<SubEpisodeProtocol> GetSEPByEpisode(TTObjectContext objectContext, Guid EPISODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODEPROTOCOL"].QueryDefs["GetSEPByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return ((ITTQuery)objectContext).QueryObjects<SubEpisodeProtocol>(queryDef, paramList);
        }

        public static BindingList<SubEpisodeProtocol.GetByObjectID_Class> GetByObjectID(Guid OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODEPROTOCOL"].QueryDefs["GetByObjectID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<SubEpisodeProtocol.GetByObjectID_Class>(queryDef, paramList, pi);
        }

        public static BindingList<SubEpisodeProtocol.GetByObjectID_Class> GetByObjectID(TTObjectContext objectContext, Guid OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODEPROTOCOL"].QueryDefs["GetByObjectID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<SubEpisodeProtocol.GetByObjectID_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<SubEpisodeProtocol> GetSEPByPatient(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, Guid PATIENT, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODEPROTOCOL"].QueryDefs["GetSEPByPatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("PATIENT", PATIENT);

            return ((ITTQuery)objectContext).QueryObjects<SubEpisodeProtocol>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<SubEpisodeProtocol.GetBySEPMaster_Class> GetBySEPMaster(Guid SEPMASTER, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODEPROTOCOL"].QueryDefs["GetBySEPMaster"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SEPMASTER", SEPMASTER);

            return TTReportNqlObject.QueryObjects<SubEpisodeProtocol.GetBySEPMaster_Class>(queryDef, paramList, pi);
        }

        public static BindingList<SubEpisodeProtocol.GetBySEPMaster_Class> GetBySEPMaster(TTObjectContext objectContext, Guid SEPMASTER, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODEPROTOCOL"].QueryDefs["GetBySEPMaster"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SEPMASTER", SEPMASTER);

            return TTReportNqlObject.QueryObjects<SubEpisodeProtocol.GetBySEPMaster_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<SubEpisodeProtocol> GetSEPBySEPMaster(TTObjectContext objectContext, Guid SEPMASTER)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODEPROTOCOL"].QueryDefs["GetSEPBySEPMaster"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SEPMASTER", SEPMASTER);

            return ((ITTQuery)objectContext).QueryObjects<SubEpisodeProtocol>(queryDef, paramList);
        }

        public static BindingList<SubEpisodeProtocol.GetAllPatientInfoByDate_Class> GetAllPatientInfoByDate(DateTime STARTDATE, DateTime ENDDATE, Guid USERID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODEPROTOCOL"].QueryDefs["GetAllPatientInfoByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("USERID", USERID);

            return TTReportNqlObject.QueryObjects<SubEpisodeProtocol.GetAllPatientInfoByDate_Class>(queryDef, paramList, pi);
        }

        public static BindingList<SubEpisodeProtocol.GetAllPatientInfoByDate_Class> GetAllPatientInfoByDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, Guid USERID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODEPROTOCOL"].QueryDefs["GetAllPatientInfoByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("USERID", USERID);

            return TTReportNqlObject.QueryObjects<SubEpisodeProtocol.GetAllPatientInfoByDate_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<SubEpisodeProtocol.GetPAInfoByDateWithProvision_Class> GetPAInfoByDateWithProvision(DateTime STARTDATE, DateTime ENDDATE, Guid USERID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODEPROTOCOL"].QueryDefs["GetPAInfoByDateWithProvision"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("USERID", USERID);

            return TTReportNqlObject.QueryObjects<SubEpisodeProtocol.GetPAInfoByDateWithProvision_Class>(queryDef, paramList, pi);
        }

        public static BindingList<SubEpisodeProtocol.GetPAInfoByDateWithProvision_Class> GetPAInfoByDateWithProvision(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, Guid USERID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODEPROTOCOL"].QueryDefs["GetPAInfoByDateWithProvision"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("USERID", USERID);

            return TTReportNqlObject.QueryObjects<SubEpisodeProtocol.GetPAInfoByDateWithProvision_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<SubEpisodeProtocol.GetSEPByInjection_Class> GetSEPByInjection(int TYPE, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODEPROTOCOL"].QueryDefs["GetSEPByInjection"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TYPE", TYPE);

            return TTReportNqlObject.QueryObjects<SubEpisodeProtocol.GetSEPByInjection_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SubEpisodeProtocol.GetSEPByInjection_Class> GetSEPByInjection(TTObjectContext objectContext, int TYPE, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODEPROTOCOL"].QueryDefs["GetSEPByInjection"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TYPE", TYPE);

            return TTReportNqlObject.QueryObjects<SubEpisodeProtocol.GetSEPByInjection_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SubEpisodeProtocol.GetPaBySearchPatientForTreatmentReport_Class> GetPaBySearchPatientForTreatmentReport(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODEPROTOCOL"].QueryDefs["GetPaBySearchPatientForTreatmentReport"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SubEpisodeProtocol.GetPaBySearchPatientForTreatmentReport_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SubEpisodeProtocol.GetPaBySearchPatientForTreatmentReport_Class> GetPaBySearchPatientForTreatmentReport(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODEPROTOCOL"].QueryDefs["GetPaBySearchPatientForTreatmentReport"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SubEpisodeProtocol.GetPaBySearchPatientForTreatmentReport_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SubEpisodeProtocol> GetSEPByIzlemUser(TTObjectContext objectContext, Guid USER)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODEPROTOCOL"].QueryDefs["GetSEPByIzlemUser"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("USER", USER);

            return ((ITTQuery)objectContext).QueryObjects<SubEpisodeProtocol>(queryDef, paramList);
        }

        public static BindingList<SubEpisodeProtocol.GetAllPatientInfoByDateWithoutUser_Class> GetAllPatientInfoByDateWithoutUser(DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODEPROTOCOL"].QueryDefs["GetAllPatientInfoByDateWithoutUser"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<SubEpisodeProtocol.GetAllPatientInfoByDateWithoutUser_Class>(queryDef, paramList, pi);
        }

        public static BindingList<SubEpisodeProtocol.GetAllPatientInfoByDateWithoutUser_Class> GetAllPatientInfoByDateWithoutUser(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODEPROTOCOL"].QueryDefs["GetAllPatientInfoByDateWithoutUser"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<SubEpisodeProtocol.GetAllPatientInfoByDateWithoutUser_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<SubEpisodeProtocol.GetEpisodeByInjection_Class> GetEpisodeByInjection(int TYPE, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODEPROTOCOL"].QueryDefs["GetEpisodeByInjection"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TYPE", TYPE);

            return TTReportNqlObject.QueryObjects<SubEpisodeProtocol.GetEpisodeByInjection_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SubEpisodeProtocol.GetEpisodeByInjection_Class> GetEpisodeByInjection(TTObjectContext objectContext, int TYPE, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODEPROTOCOL"].QueryDefs["GetEpisodeByInjection"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TYPE", TYPE);

            return TTReportNqlObject.QueryObjects<SubEpisodeProtocol.GetEpisodeByInjection_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SubEpisodeProtocol.GetSepCountByDate_Class> GetSepCountByDate(DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODEPROTOCOL"].QueryDefs["GetSepCountByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<SubEpisodeProtocol.GetSepCountByDate_Class>(queryDef, paramList, pi);
        }

        public static BindingList<SubEpisodeProtocol.GetSepCountByDate_Class> GetSepCountByDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODEPROTOCOL"].QueryDefs["GetSepCountByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<SubEpisodeProtocol.GetSepCountByDate_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Tig Modülü İşlem Bazlı Ayaktan Gruplar
    /// </summary>
        public static BindingList<SubEpisodeProtocol.GetTigIBAG_Class> GetTigIBAG(DateTime OPENINGDATEBEGIN, DateTime OPENINGDATEEND, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODEPROTOCOL"].QueryDefs["GetTigIBAG"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OPENINGDATEBEGIN", OPENINGDATEBEGIN);
            paramList.Add("OPENINGDATEEND", OPENINGDATEEND);

            return TTReportNqlObject.QueryObjects<SubEpisodeProtocol.GetTigIBAG_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// Tig Modülü İşlem Bazlı Ayaktan Gruplar
    /// </summary>
        public static BindingList<SubEpisodeProtocol.GetTigIBAG_Class> GetTigIBAG(TTObjectContext objectContext, DateTime OPENINGDATEBEGIN, DateTime OPENINGDATEEND, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODEPROTOCOL"].QueryDefs["GetTigIBAG"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OPENINGDATEBEGIN", OPENINGDATEBEGIN);
            paramList.Add("OPENINGDATEEND", OPENINGDATEEND);

            return TTReportNqlObject.QueryObjects<SubEpisodeProtocol.GetTigIBAG_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<SubEpisodeProtocol.GetPaBySearchPatient_Class> GetPaBySearchPatient(Guid PATIENT, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODEPROTOCOL"].QueryDefs["GetPaBySearchPatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return TTReportNqlObject.QueryObjects<SubEpisodeProtocol.GetPaBySearchPatient_Class>(queryDef, paramList, pi);
        }

        public static BindingList<SubEpisodeProtocol.GetPaBySearchPatient_Class> GetPaBySearchPatient(TTObjectContext objectContext, Guid PATIENT, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODEPROTOCOL"].QueryDefs["GetPaBySearchPatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return TTReportNqlObject.QueryObjects<SubEpisodeProtocol.GetPaBySearchPatient_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<SubEpisodeProtocol.GetTigBBAG_Class> GetTigBBAG(DateTime OPENINGDATEBEGIN, DateTime OPENINGDATEEND, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODEPROTOCOL"].QueryDefs["GetTigBBAG"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OPENINGDATEBEGIN", OPENINGDATEBEGIN);
            paramList.Add("OPENINGDATEEND", OPENINGDATEEND);

            return TTReportNqlObject.QueryObjects<SubEpisodeProtocol.GetTigBBAG_Class>(queryDef, paramList, pi);
        }

        public static BindingList<SubEpisodeProtocol.GetTigBBAG_Class> GetTigBBAG(TTObjectContext objectContext, DateTime OPENINGDATEBEGIN, DateTime OPENINGDATEEND, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODEPROTOCOL"].QueryDefs["GetTigBBAG"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OPENINGDATEBEGIN", OPENINGDATEBEGIN);
            paramList.Add("OPENINGDATEEND", OPENINGDATEEND);

            return TTReportNqlObject.QueryObjects<SubEpisodeProtocol.GetTigBBAG_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<SubEpisodeProtocol.GetPAInfoByDateWithoutProvision_Class> GetPAInfoByDateWithoutProvision(DateTime STARTDATE, DateTime ENDDATE, Guid USERID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODEPROTOCOL"].QueryDefs["GetPAInfoByDateWithoutProvision"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("USERID", USERID);

            return TTReportNqlObject.QueryObjects<SubEpisodeProtocol.GetPAInfoByDateWithoutProvision_Class>(queryDef, paramList, pi);
        }

        public static BindingList<SubEpisodeProtocol.GetPAInfoByDateWithoutProvision_Class> GetPAInfoByDateWithoutProvision(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, Guid USERID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODEPROTOCOL"].QueryDefs["GetPAInfoByDateWithoutProvision"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("USERID", USERID);

            return TTReportNqlObject.QueryObjects<SubEpisodeProtocol.GetPAInfoByDateWithoutProvision_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<SubEpisodeProtocol> GetSEPByMedulaProvisionNo(TTObjectContext objectContext, string MEDULAPROVISIONNO)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODEPROTOCOL"].QueryDefs["GetSEPByMedulaProvisionNo"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MEDULAPROVISIONNO", MEDULAPROVISIONNO);

            return ((ITTQuery)objectContext).QueryObjects<SubEpisodeProtocol>(queryDef, paramList);
        }

        public static BindingList<SubEpisodeProtocol.GetInvoiceTotalPriceByTerm_Class> GetInvoiceTotalPriceByTerm(Guid TERM, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODEPROTOCOL"].QueryDefs["GetInvoiceTotalPriceByTerm"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TERM", TERM);

            return TTReportNqlObject.QueryObjects<SubEpisodeProtocol.GetInvoiceTotalPriceByTerm_Class>(queryDef, paramList, pi);
        }

        public static BindingList<SubEpisodeProtocol.GetInvoiceTotalPriceByTerm_Class> GetInvoiceTotalPriceByTerm(TTObjectContext objectContext, Guid TERM, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODEPROTOCOL"].QueryDefs["GetInvoiceTotalPriceByTerm"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TERM", TERM);

            return TTReportNqlObject.QueryObjects<SubEpisodeProtocol.GetInvoiceTotalPriceByTerm_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<SubEpisodeProtocol.GetMedulaSEPsByTerm_Class> GetMedulaSEPsByTerm(Guid TERM, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODEPROTOCOL"].QueryDefs["GetMedulaSEPsByTerm"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TERM", TERM);

            return TTReportNqlObject.QueryObjects<SubEpisodeProtocol.GetMedulaSEPsByTerm_Class>(queryDef, paramList, pi);
        }

        public static BindingList<SubEpisodeProtocol.GetMedulaSEPsByTerm_Class> GetMedulaSEPsByTerm(TTObjectContext objectContext, Guid TERM, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODEPROTOCOL"].QueryDefs["GetMedulaSEPsByTerm"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TERM", TERM);

            return TTReportNqlObject.QueryObjects<SubEpisodeProtocol.GetMedulaSEPsByTerm_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<SubEpisodeProtocol.GetErrorByInjection_Class> GetErrorByInjection(int ERRORTYPE, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODEPROTOCOL"].QueryDefs["GetErrorByInjection"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ERRORTYPE", ERRORTYPE);

            return TTReportNqlObject.QueryObjects<SubEpisodeProtocol.GetErrorByInjection_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SubEpisodeProtocol.GetErrorByInjection_Class> GetErrorByInjection(TTObjectContext objectContext, int ERRORTYPE, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODEPROTOCOL"].QueryDefs["GetErrorByInjection"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ERRORTYPE", ERRORTYPE);

            return TTReportNqlObject.QueryObjects<SubEpisodeProtocol.GetErrorByInjection_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SubEpisodeProtocol.GetErrorMessageByInjection_Class> GetErrorMessageByInjection(int ERRORTYPE, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODEPROTOCOL"].QueryDefs["GetErrorMessageByInjection"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ERRORTYPE", ERRORTYPE);

            return TTReportNqlObject.QueryObjects<SubEpisodeProtocol.GetErrorMessageByInjection_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SubEpisodeProtocol.GetErrorMessageByInjection_Class> GetErrorMessageByInjection(TTObjectContext objectContext, int ERRORTYPE, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODEPROTOCOL"].QueryDefs["GetErrorMessageByInjection"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ERRORTYPE", ERRORTYPE);

            return TTReportNqlObject.QueryObjects<SubEpisodeProtocol.GetErrorMessageByInjection_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SubEpisodeProtocol.GetSEPObjectIDByInjection_Class> GetSEPObjectIDByInjection(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODEPROTOCOL"].QueryDefs["GetSEPObjectIDByInjection"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SubEpisodeProtocol.GetSEPObjectIDByInjection_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SubEpisodeProtocol.GetSEPObjectIDByInjection_Class> GetSEPObjectIDByInjection(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODEPROTOCOL"].QueryDefs["GetSEPObjectIDByInjection"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SubEpisodeProtocol.GetSEPObjectIDByInjection_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SubEpisodeProtocol.GetTrxCodeAndNameByInjection_Class> GetTrxCodeAndNameByInjection(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODEPROTOCOL"].QueryDefs["GetTrxCodeAndNameByInjection"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SubEpisodeProtocol.GetTrxCodeAndNameByInjection_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SubEpisodeProtocol.GetTrxCodeAndNameByInjection_Class> GetTrxCodeAndNameByInjection(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODEPROTOCOL"].QueryDefs["GetTrxCodeAndNameByInjection"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SubEpisodeProtocol.GetTrxCodeAndNameByInjection_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SubEpisodeProtocol.InvoiceSEPDetailQuery_Class> InvoiceSEPDetailQuery(Guid OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODEPROTOCOL"].QueryDefs["InvoiceSEPDetailQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<SubEpisodeProtocol.InvoiceSEPDetailQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<SubEpisodeProtocol.InvoiceSEPDetailQuery_Class> InvoiceSEPDetailQuery(TTObjectContext objectContext, Guid OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODEPROTOCOL"].QueryDefs["InvoiceSEPDetailQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<SubEpisodeProtocol.InvoiceSEPDetailQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<SubEpisodeProtocol.GetTotalMedulaPriceByTerm_Class> GetTotalMedulaPriceByTerm(Guid TERM, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODEPROTOCOL"].QueryDefs["GetTotalMedulaPriceByTerm"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TERM", TERM);

            return TTReportNqlObject.QueryObjects<SubEpisodeProtocol.GetTotalMedulaPriceByTerm_Class>(queryDef, paramList, pi);
        }

        public static BindingList<SubEpisodeProtocol.GetTotalMedulaPriceByTerm_Class> GetTotalMedulaPriceByTerm(TTObjectContext objectContext, Guid TERM, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODEPROTOCOL"].QueryDefs["GetTotalMedulaPriceByTerm"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TERM", TERM);

            return TTReportNqlObject.QueryObjects<SubEpisodeProtocol.GetTotalMedulaPriceByTerm_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<SubEpisodeProtocol.GetSEPByInjectionPrice_Class> GetSEPByInjectionPrice(int TYPE, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODEPROTOCOL"].QueryDefs["GetSEPByInjectionPrice"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TYPE", TYPE);

            return TTReportNqlObject.QueryObjects<SubEpisodeProtocol.GetSEPByInjectionPrice_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SubEpisodeProtocol.GetSEPByInjectionPrice_Class> GetSEPByInjectionPrice(TTObjectContext objectContext, int TYPE, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODEPROTOCOL"].QueryDefs["GetSEPByInjectionPrice"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TYPE", TYPE);

            return TTReportNqlObject.QueryObjects<SubEpisodeProtocol.GetSEPByInjectionPrice_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SubEpisodeProtocol.GetSEPSToCreateENabiz700_Class> GetSEPSToCreateENabiz700(DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODEPROTOCOL"].QueryDefs["GetSEPSToCreateENabiz700"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<SubEpisodeProtocol.GetSEPSToCreateENabiz700_Class>(queryDef, paramList, pi);
        }

        public static BindingList<SubEpisodeProtocol.GetSEPSToCreateENabiz700_Class> GetSEPSToCreateENabiz700(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODEPROTOCOL"].QueryDefs["GetSEPSToCreateENabiz700"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<SubEpisodeProtocol.GetSEPSToCreateENabiz700_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<SubEpisodeProtocol.GetByInvoiceCollection_Class> GetByInvoiceCollection(Guid ICOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODEPROTOCOL"].QueryDefs["GetByInvoiceCollection"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ICOBJECTID", ICOBJECTID);

            return TTReportNqlObject.QueryObjects<SubEpisodeProtocol.GetByInvoiceCollection_Class>(queryDef, paramList, pi);
        }

        public static BindingList<SubEpisodeProtocol.GetByInvoiceCollection_Class> GetByInvoiceCollection(TTObjectContext objectContext, Guid ICOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODEPROTOCOL"].QueryDefs["GetByInvoiceCollection"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ICOBJECTID", ICOBJECTID);

            return TTReportNqlObject.QueryObjects<SubEpisodeProtocol.GetByInvoiceCollection_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<SubEpisodeProtocol.GetByInvoiceCollectionAlphabetic_Class> GetByInvoiceCollectionAlphabetic(Guid ICOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODEPROTOCOL"].QueryDefs["GetByInvoiceCollectionAlphabetic"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ICOBJECTID", ICOBJECTID);

            return TTReportNqlObject.QueryObjects<SubEpisodeProtocol.GetByInvoiceCollectionAlphabetic_Class>(queryDef, paramList, pi);
        }

        public static BindingList<SubEpisodeProtocol.GetByInvoiceCollectionAlphabetic_Class> GetByInvoiceCollectionAlphabetic(TTObjectContext objectContext, Guid ICOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODEPROTOCOL"].QueryDefs["GetByInvoiceCollectionAlphabetic"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ICOBJECTID", ICOBJECTID);

            return TTReportNqlObject.QueryObjects<SubEpisodeProtocol.GetByInvoiceCollectionAlphabetic_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// SMS Hasta Filtre
    /// </summary>
        public static BindingList<SubEpisodeProtocol.SMSPatientListQuery_Class> SMSPatientListQuery(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODEPROTOCOL"].QueryDefs["SMSPatientListQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SubEpisodeProtocol.SMSPatientListQuery_Class>(queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// SMS Hasta Filtre
    /// </summary>
        public static BindingList<SubEpisodeProtocol.SMSPatientListQuery_Class> SMSPatientListQuery(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODEPROTOCOL"].QueryDefs["SMSPatientListQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SubEpisodeProtocol.SMSPatientListQuery_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SubEpisodeProtocol.GetLast5InvoicesOfUser_Class> GetLast5InvoicesOfUser(Guid USER, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODEPROTOCOL"].QueryDefs["GetLast5InvoicesOfUser"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("USER", USER);

            return TTReportNqlObject.QueryObjects<SubEpisodeProtocol.GetLast5InvoicesOfUser_Class>(queryDef, paramList, pi);
        }

        public static BindingList<SubEpisodeProtocol.GetLast5InvoicesOfUser_Class> GetLast5InvoicesOfUser(TTObjectContext objectContext, Guid USER, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODEPROTOCOL"].QueryDefs["GetLast5InvoicesOfUser"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("USER", USER);

            return TTReportNqlObject.QueryObjects<SubEpisodeProtocol.GetLast5InvoicesOfUser_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<SubEpisodeProtocol.GetGroupedInvoicePricesByTerm_Class> GetGroupedInvoicePricesByTerm(Guid TERM, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODEPROTOCOL"].QueryDefs["GetGroupedInvoicePricesByTerm"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TERM", TERM);

            return TTReportNqlObject.QueryObjects<SubEpisodeProtocol.GetGroupedInvoicePricesByTerm_Class>(queryDef, paramList, pi);
        }

        public static BindingList<SubEpisodeProtocol.GetGroupedInvoicePricesByTerm_Class> GetGroupedInvoicePricesByTerm(TTObjectContext objectContext, Guid TERM, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODEPROTOCOL"].QueryDefs["GetGroupedInvoicePricesByTerm"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TERM", TERM);

            return TTReportNqlObject.QueryObjects<SubEpisodeProtocol.GetGroupedInvoicePricesByTerm_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Oluşturulma Zamanı
    /// </summary>
        public DateTime? CreationDate
        {
            get { return (DateTime?)this["CREATIONDATE"]; }
            set { this["CREATIONDATE"] = value; }
        }

    /// <summary>
    /// Medula Başvuru Numarası
    /// </summary>
        public string MedulaBasvuruNo
        {
            get { return (string)this["MEDULABASVURUNO"]; }
            set { this["MEDULABASVURUNO"] = value; }
        }

    /// <summary>
    /// Donör TCKimlikNo
    /// </summary>
        public long? MedulaDonorTCKimlikNo
        {
            get { return (long?)this["MEDULADONORTCKIMLIKNO"]; }
            set { this["MEDULADONORTCKIMLIKNO"] = value; }
        }

    /// <summary>
    /// Meduladan Dönen Fatura Tutarı
    /// </summary>
        public Currency? MedulaFaturaTutari
        {
            get { return (Currency?)this["MEDULAFATURATUTARI"]; }
            set { this["MEDULAFATURATUTARI"] = value; }
        }

    /// <summary>
    /// Plaka No
    /// </summary>
        public string MedulaPlakaNo
        {
            get { return (string)this["MEDULAPLAKANO"]; }
            set { this["MEDULAPLAKANO"] = value; }
        }

    /// <summary>
    /// Katılım Payından Muaf
    /// </summary>
        public string MedulaKatilimPayindanMuaf
        {
            get { return (string)this["MEDULAKATILIMPAYINDANMUAF"]; }
            set { this["MEDULAKATILIMPAYINDANMUAF"] = value; }
        }

    /// <summary>
    /// Takip Tarihi
    /// </summary>
        public DateTime? MedulaProvizyonTarihi
        {
            get { return (DateTime?)this["MEDULAPROVIZYONTARIHI"]; }
            set { this["MEDULAPROVIZYONTARIHI"] = value; }
        }

    /// <summary>
    /// YUPASS ID
    /// </summary>
        public int? MedulaYupassNo
        {
            get { return (int?)this["MEDULAYUPASSNO"]; }
            set { this["MEDULAYUPASSNO"] = value; }
        }

    /// <summary>
    /// Ödeme kontrolüne takılıp takılmayacağı
    /// </summary>
        public bool? CheckPaid
        {
            get { return (bool?)this["CHECKPAID"]; }
            set { this["CHECKPAID"] = value; }
        }

    /// <summary>
    /// Fatura Durumu
    /// </summary>
        public MedulaSubEpisodeStatusEnum? InvoiceStatus
        {
            get { return (MedulaSubEpisodeStatusEnum?)(int?)this["INVOICESTATUS"]; }
            set { this["INVOICESTATUS"] = value; }
        }

    /// <summary>
    /// Medula Takip No
    /// </summary>
        public string MedulaTakipNo
        {
            get { return (string)this["MEDULATAKIPNO"]; }
            set { this["MEDULATAKIPNO"] = value; }
        }

    /// <summary>
    /// Sonuç Kodu
    /// </summary>
        public string MedulaSonucKodu
        {
            get { return (string)this["MEDULASONUCKODU"]; }
            set { this["MEDULASONUCKODU"] = value; }
        }

    /// <summary>
    /// Sonuç Mesajı
    /// </summary>
        public string MedulaSonucMesaji
        {
            get { return (string)this["MEDULASONUCMESAJI"]; }
            set { this["MEDULASONUCMESAJI"] = value; }
        }

    /// <summary>
    /// Kapsam Adı
    /// </summary>
        public string MedulaKapsamAdi
        {
            get { return (string)this["MEDULAKAPSAMADI"]; }
            set { this["MEDULAKAPSAMADI"] = value; }
        }

    /// <summary>
    /// Klonlanma Tipi
    /// </summary>
        public SEPCloneTypeEnum? CloneType
        {
            get { return (SEPCloneTypeEnum?)(int?)this["CLONETYPE"]; }
            set { this["CLONETYPE"] = value; }
        }

    /// <summary>
    /// Id
    /// </summary>
        public TTSequence Id
        {
            get { return GetSequence("ID"); }
        }

    /// <summary>
    /// Yeşil Kart Sevk Eden Tesis Kodu
    /// </summary>
        public int? MedulaGreenCardFacilityCode
        {
            get { return (int?)this["MEDULAGREENCARDFACILITYCODE"]; }
            set { this["MEDULAGREENCARDFACILITYCODE"] = value; }
        }

    /// <summary>
    /// Çıkış Tarihi
    /// </summary>
        public DateTime? DischargeDate
        {
            get { return (DateTime?)this["DISCHARGEDATE"]; }
            set { this["DISCHARGEDATE"] = value; }
        }

    /// <summary>
    /// İncelendi
    /// </summary>
        public bool? Investigation
        {
            get { return (bool?)this["INVESTIGATION"]; }
            set { this["INVESTIGATION"] = value; }
        }

    /// <summary>
    /// Kontrol Edildi
    /// </summary>
        public bool? Checked
        {
            get { return (bool?)this["CHECKED"]; }
            set { this["CHECKED"] = value; }
        }

    /// <summary>
    /// Fatura Teslim No
    /// </summary>
        public string MedulaFaturaTeslimNo
        {
            get { return (string)this["MEDULAFATURATESLIMNO"]; }
            set { this["MEDULAFATURATESLIMNO"] = value; }
        }

    /// <summary>
    /// Fatura Tarihi
    /// </summary>
        public DateTime? MedulaFaturaTarihi
        {
            get { return (DateTime?)this["MEDULAFATURATARIHI"]; }
            set { this["MEDULAFATURATARIHI"] = value; }
        }

        public DateTime? MedulaVakaTarihi
        {
            get { return (DateTime?)this["MEDULAVAKATARIHI"]; }
            set { this["MEDULAVAKATARIHI"] = value; }
        }

    /// <summary>
    /// Faturacı açıklaması
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

        public int? InvoiceCancelCount
        {
            get { return (int?)this["INVOICECANCELCOUNT"]; }
            set { this["INVOICECANCELCOUNT"] = value; }
        }

    /// <summary>
    /// İcmal Detay
    /// </summary>
        public InvoiceCollectionDetail InvoiceCollectionDetail
        {
            get { return (InvoiceCollectionDetail)((ITTObject)this).GetParent("INVOICECOLLECTIONDETAIL"); }
            set { this["INVOICECOLLECTIONDETAIL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Bağlı takip bilgisi
    /// </summary>
        public SubEpisodeProtocol ParentSEP
        {
            get { return (SubEpisodeProtocol)((ITTObject)this).GetParent("PARENTSEP"); }
            set { this["PARENTSEP"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Takibin Branş bilgisi
    /// </summary>
        public SpecialityDefinition Brans
        {
            get { return (SpecialityDefinition)((ITTObject)this).GetParent("BRANS"); }
            set { this["BRANS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public DevredilenKurum MedulaDevredilenKurum
        {
            get { return (DevredilenKurum)((ITTObject)this).GetParent("MEDULADEVREDILENKURUM"); }
            set { this["MEDULADEVREDILENKURUM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public IstisnaiHal MedulaIstisnaiHal
        {
            get { return (IstisnaiHal)((ITTObject)this).GetParent("MEDULAISTISNAIHAL"); }
            set { this["MEDULAISTISNAIHAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SigortaliTuru MedulaSigortaliTuru
        {
            get { return (SigortaliTuru)((ITTObject)this).GetParent("MEDULASIGORTALITURU"); }
            set { this["MEDULASIGORTALITURU"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SEPMaster SEPMaster
        {
            get { return (SEPMaster)((ITTObject)this).GetParent("SEPMASTER"); }
            set { this["SEPMASTER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public InvoiceInclusionMaster LastIIM
        {
            get { return (InvoiceInclusionMaster)((ITTObject)this).GetParent("LASTIIM"); }
            set { this["LASTIIM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Hangi SEP ten clone edildiği bilgisi
    /// </summary>
        public SubEpisodeProtocol ClonedFrom
        {
            get { return (SubEpisodeProtocol)((ITTObject)this).GetParent("CLONEDFROM"); }
            set { this["CLONEDFROM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public PatientAdmission PatientAdmission
        {
            get { return (PatientAdmission)((ITTObject)this).GetParent("PATIENTADMISSION"); }
            set { this["PATIENTADMISSION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SubEpisode SubEpisode
        {
            get { return (SubEpisode)((ITTObject)this).GetParent("SUBEPISODE"); }
            set { this["SUBEPISODE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public PayerDefinition Payer
        {
            get { return (PayerDefinition)((ITTObject)this).GetParent("PAYER"); }
            set { this["PAYER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ProtocolDefinition Protocol
        {
            get { return (ProtocolDefinition)((ITTObject)this).GetParent("PROTOCOL"); }
            set { this["PROTOCOL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ProvizyonTipi MedulaProvizyonTipi
        {
            get { return (ProvizyonTipi)((ITTObject)this).GetParent("MEDULAPROVIZYONTIPI"); }
            set { this["MEDULAPROVIZYONTIPI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public TakipTipi MedulaTakipTipi
        {
            get { return (TakipTipi)((ITTObject)this).GetParent("MEDULATAKIPTIPI"); }
            set { this["MEDULATAKIPTIPI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public TedaviTipi MedulaTedaviTipi
        {
            get { return (TedaviTipi)((ITTObject)this).GetParent("MEDULATEDAVITIPI"); }
            set { this["MEDULATEDAVITIPI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public TedaviTuru MedulaTedaviTuru
        {
            get { return (TedaviTuru)((ITTObject)this).GetParent("MEDULATEDAVITURU"); }
            set { this["MEDULATEDAVITURU"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SEPEpicrisis Epicrisis
        {
            get { return (SEPEpicrisis)((ITTObject)this).GetParent("EPICRISIS"); }
            set { this["EPICRISIS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// İzlem Listem
    /// </summary>
        public ResUser IzlemUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("IZLEMUSER"); }
            set { this["IZLEMUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Acil Triaj
    /// </summary>
        public SKRSTRIAJKODU Triage
        {
            get { return (SKRSTRIAJKODU)((ITTObject)this).GetParent("TRIAGE"); }
            set { this["TRIAGE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Taburcu Kodu
    /// </summary>
        public TaburcuKodu DischargeType
        {
            get { return (TaburcuKodu)((ITTObject)this).GetParent("DISCHARGETYPE"); }
            set { this["DISCHARGETYPE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateSEPDiagnosesCollection()
        {
            _SEPDiagnoses = new SEPDiagnosis.ChildSEPDiagnosisCollection(this, new Guid("0234d781-a0ee-4671-af15-c02edce8c0b6"));
            ((ITTChildObjectCollection)_SEPDiagnoses).GetChildren();
        }

        protected SEPDiagnosis.ChildSEPDiagnosisCollection _SEPDiagnoses = null;
    /// <summary>
    /// Child collection for SEP
    /// </summary>
        public SEPDiagnosis.ChildSEPDiagnosisCollection SEPDiagnoses
        {
            get
            {
                if (_SEPDiagnoses == null)
                    CreateSEPDiagnosesCollection();
                return _SEPDiagnoses;
            }
        }

        virtual protected void CreateAccountTransactionsCollection()
        {
            _AccountTransactions = new AccountTransaction.ChildAccountTransactionCollection(this, new Guid("c017a376-4949-4f3f-b2c7-4f3763c0acd3"));
            ((ITTChildObjectCollection)_AccountTransactions).GetChildren();
        }

        protected AccountTransaction.ChildAccountTransactionCollection _AccountTransactions = null;
        public AccountTransaction.ChildAccountTransactionCollection AccountTransactions
        {
            get
            {
                if (_AccountTransactions == null)
                    CreateAccountTransactionsCollection();
                return _AccountTransactions;
            }
        }

        virtual protected void CreateChildSEPsCollection()
        {
            _ChildSEPs = new SubEpisodeProtocol.ChildSubEpisodeProtocolCollection(this, new Guid("f1152b9a-bafa-4f02-aaa4-10c3858496b4"));
            ((ITTChildObjectCollection)_ChildSEPs).GetChildren();
        }

        protected SubEpisodeProtocol.ChildSubEpisodeProtocolCollection _ChildSEPs = null;
    /// <summary>
    /// Child collection for Bağlı takip bilgisi
    /// </summary>
        public SubEpisodeProtocol.ChildSubEpisodeProtocolCollection ChildSEPs
        {
            get
            {
                if (_ChildSEPs == null)
                    CreateChildSEPsCollection();
                return _ChildSEPs;
            }
        }

        virtual protected void CreateProtocolStatusChangingDetailCollection()
        {
            _ProtocolStatusChangingDetail = new ProtocolStatusChangingDetail.ChildProtocolStatusChangingDetailCollection(this, new Guid("ba7b0ef7-ad55-4372-b1f3-13e760961c14"));
            ((ITTChildObjectCollection)_ProtocolStatusChangingDetail).GetChildren();
        }

        protected ProtocolStatusChangingDetail.ChildProtocolStatusChangingDetailCollection _ProtocolStatusChangingDetail = null;
    /// <summary>
    /// Child collection for SEP ilişkisi
    /// </summary>
        public ProtocolStatusChangingDetail.ChildProtocolStatusChangingDetailCollection ProtocolStatusChangingDetail
        {
            get
            {
                if (_ProtocolStatusChangingDetail == null)
                    CreateProtocolStatusChangingDetailCollection();
                return _ProtocolStatusChangingDetail;
            }
        }

        virtual protected void CreateClonedSEPsCollection()
        {
            _ClonedSEPs = new SubEpisodeProtocol.ChildSubEpisodeProtocolCollection(this, new Guid("cd6e2361-95a6-495c-aad2-053acdb86312"));
            ((ITTChildObjectCollection)_ClonedSEPs).GetChildren();
        }

        protected SubEpisodeProtocol.ChildSubEpisodeProtocolCollection _ClonedSEPs = null;
    /// <summary>
    /// Child collection for Hangi SEP ten clone edildiği bilgisi
    /// </summary>
        public SubEpisodeProtocol.ChildSubEpisodeProtocolCollection ClonedSEPs
        {
            get
            {
                if (_ClonedSEPs == null)
                    CreateClonedSEPsCollection();
                return _ClonedSEPs;
            }
        }

        virtual protected void CreateCancelledInvoicesCollection()
        {
            _CancelledInvoices = new CancelledInvoice.ChildCancelledInvoiceCollection(this, new Guid("247e25b5-e827-4abf-b2e5-cb1fe91e149c"));
            ((ITTChildObjectCollection)_CancelledInvoices).GetChildren();
        }

        protected CancelledInvoice.ChildCancelledInvoiceCollection _CancelledInvoices = null;
        public CancelledInvoice.ChildCancelledInvoiceCollection CancelledInvoices
        {
            get
            {
                if (_CancelledInvoices == null)
                    CreateCancelledInvoicesCollection();
                return _CancelledInvoices;
            }
        }

        virtual protected void CreateMedulaDocumentEntriesCollection()
        {
            _MedulaDocumentEntries = new MedulaDocumentEntry.ChildMedulaDocumentEntryCollection(this, new Guid("2abfb761-155c-414a-b95a-69abbccb7aba"));
            ((ITTChildObjectCollection)_MedulaDocumentEntries).GetChildren();
        }

        protected MedulaDocumentEntry.ChildMedulaDocumentEntryCollection _MedulaDocumentEntries = null;
        public MedulaDocumentEntry.ChildMedulaDocumentEntryCollection MedulaDocumentEntries
        {
            get
            {
                if (_MedulaDocumentEntries == null)
                    CreateMedulaDocumentEntriesCollection();
                return _MedulaDocumentEntries;
            }
        }

        virtual protected void CreateInvoiceLogsCollection()
        {
            _InvoiceLogs = new InvoiceLog.ChildInvoiceLogCollection(this, new Guid("30b46d9b-9f23-4375-8f35-70a1aca748bd"));
            ((ITTChildObjectCollection)_InvoiceLogs).GetChildren();
        }

        protected InvoiceLog.ChildInvoiceLogCollection _InvoiceLogs = null;
        public InvoiceLog.ChildInvoiceLogCollection InvoiceLogs
        {
            get
            {
                if (_InvoiceLogs == null)
                    CreateInvoiceLogsCollection();
                return _InvoiceLogs;
            }
        }

        protected SubEpisodeProtocol(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SubEpisodeProtocol(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SubEpisodeProtocol(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SubEpisodeProtocol(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SubEpisodeProtocol(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SUBEPISODEPROTOCOL", dataRow) { }
        protected SubEpisodeProtocol(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SUBEPISODEPROTOCOL", dataRow, isImported) { }
        public SubEpisodeProtocol(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SubEpisodeProtocol(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SubEpisodeProtocol() : base() { }

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
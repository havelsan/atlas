
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ResBed")] 

    /// <summary>
    /// Yatak
    /// </summary>
    public  partial class ResBed : ResSection
    {
        public class ResBedList : TTObjectCollection<ResBed> { }
                    
        public class ChildResBedCollection : TTObject.TTChildObjectCollection<ResBed>
        {
            public ChildResBedCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildResBedCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetEmptyBeds_Class : TTReportNqlObject 
        {
            public string Bed
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESBED"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Room
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ROOM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESROOM"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Roomgroup
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ROOMGROUP"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESROOMGROUP"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Clinic
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CLINIC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESWARD"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetEmptyBeds_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetEmptyBeds_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetEmptyBeds_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetUsedByRelation_Class : TTReportNqlObject 
        {
            public Guid? UsedByBedProcedure
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["USEDBYBEDPROCEDURE"]);
                }
            }

            public Guid? Ward
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["WARD"]);
                }
            }

            public Guid? EpisodeAction
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODEACTION"]);
                }
            }

            public Guid? Episode
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODE"]);
                }
            }

            public OLAP_GetUsedByRelation_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetUsedByRelation_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetUsedByRelation_Class() : base() { }
        }

        [Serializable] 

        public partial class GetEmptyBedsByClinic_Class : TTReportNqlObject 
        {
            public string Bed
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESBED"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Room
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ROOM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESROOM"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Roomgroup
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ROOMGROUP"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESROOMGROUP"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Clinic
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CLINIC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESWARD"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetEmptyBedsByClinic_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetEmptyBedsByClinic_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetEmptyBedsByClinic_Class() : base() { }
        }

        [Serializable] 

        public partial class GetBedDefinition_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Qref
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["QREF"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESBED"].AllPropertyDefs["QREF"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESBED"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Bedprocedurename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BEDPROCEDURENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BEDPROCEDUREDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Roomname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ROOMNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESROOM"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetBedDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetBedDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetBedDefinition_Class() : base() { }
        }

        [Serializable] 

        public partial class GetEmptyBedsWithoutIntensiveCare_Class : TTReportNqlObject 
        {
            public string Bed
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESBED"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Room
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ROOM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESROOM"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Roomgroup
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ROOMGROUP"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESROOMGROUP"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Clinic
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CLINIC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESWARD"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetEmptyBedsWithoutIntensiveCare_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetEmptyBedsWithoutIntensiveCare_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetEmptyBedsWithoutIntensiveCare_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetResBed_Class : TTReportNqlObject 
        {
            public Object Nqlcolumn
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["NQLCOLUMN"]);
                }
            }

            public Guid? Ward
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["WARD"]);
                }
            }

            public OLAP_GetResBed_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetResBed_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetResBed_Class() : base() { }
        }

        [Serializable] 

        public partial class GetEmptyBedCountByClinic_Class : TTReportNqlObject 
        {
            public Object Emptybedcount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["EMPTYBEDCOUNT"]);
                }
            }

            public GetEmptyBedCountByClinic_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetEmptyBedCountByClinic_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetEmptyBedCountByClinic_Class() : base() { }
        }

        [Serializable] 

        public partial class GetBedCountByClinic_Class : TTReportNqlObject 
        {
            public Object Bedcount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["BEDCOUNT"]);
                }
            }

            public GetBedCountByClinic_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetBedCountByClinic_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetBedCountByClinic_Class() : base() { }
        }

        [Serializable] 

        public partial class GetUsedBedCount_Class : TTReportNqlObject 
        {
            public Object Usedbedcount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["USEDBEDCOUNT"]);
                }
            }

            public GetUsedBedCount_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetUsedBedCount_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetUsedBedCount_Class() : base() { }
        }

        [Serializable] 

        public partial class GetBedsByClinic_Class : TTReportNqlObject 
        {
            public Guid? Bed
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["BED"]);
                }
            }

            public Guid? Room
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["ROOM"]);
                }
            }

            public Guid? RoomGroup
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["ROOMGROUP"]);
                }
            }

            public Guid? Clinic
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CLINIC"]);
                }
            }

            public Guid? UsedByBedProcedure
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["USEDBYBEDPROCEDURE"]);
                }
            }

            public Guid? Usedbyepisode
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["USEDBYEPISODE"]);
                }
            }

            public Guid? Usedbypatient
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["USEDBYPATIENT"]);
                }
            }

            public string Usedbypatientname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["USEDBYPATIENTNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Usedbypatientsurname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["USEDBYPATIENTSURNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["SURNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? Usedbypatientuniquerefno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["USEDBYPATIENTUNIQUEREFNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["UNIQUEREFNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public double? Usedbypatforeignuniquerefno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["USEDBYPATFOREIGNUNIQUEREFNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["FOREIGNUNIQUEREFNO"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public Guid? Usedbyepisodeaction
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["USEDBYEPISODEACTION"]);
                }
            }

            public GetBedsByClinic_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetBedsByClinic_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetBedsByClinic_Class() : base() { }
        }

        [Serializable] 

        public partial class GetEmptyBedCount_Class : TTReportNqlObject 
        {
            public Object Emptybedcount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["EMPTYBEDCOUNT"]);
                }
            }

            public GetEmptyBedCount_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetEmptyBedCount_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetEmptyBedCount_Class() : base() { }
        }

        [Serializable] 

        public partial class GetBedsPropertysByResWard_Class : TTReportNqlObject 
        {
            public string Bedname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BEDNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESBED"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Bedobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["BEDOBJECTID"]);
                }
            }

            public string Roomname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ROOMNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESROOM"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Roomobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["ROOMOBJECTID"]);
                }
            }

            public string Roomgroupname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ROOMGROUPNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESROOMGROUP"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Roomgroupobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["ROOMGROUPOBJECTID"]);
                }
            }

            public string Clinicname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CLINICNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESWARD"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Clinicobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CLINICOBJECTID"]);
                }
            }

            public Object Usedstatus
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["USEDSTATUS"]);
                }
            }

            public string Sex
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SEX"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSCINSIYET"].AllPropertyDefs["KODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? HasDropletIsolation
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HASDROPLETISOLATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BASEINPATIENTADMISSION"].AllPropertyDefs["HASDROPLETISOLATION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? HasAirborneContactIsolation
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HASAIRBORNECONTACTISOLATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BASEINPATIENTADMISSION"].AllPropertyDefs["HASAIRBORNECONTACTISOLATION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? HasContactIsolation
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HASCONTACTISOLATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BASEINPATIENTADMISSION"].AllPropertyDefs["HASCONTACTISOLATION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? HasTightContactIsolation
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HASTIGHTCONTACTISOLATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BASEINPATIENTADMISSION"].AllPropertyDefs["HASTIGHTCONTACTISOLATION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? HasFallingRisk
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HASFALLINGRISK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BASEINPATIENTADMISSION"].AllPropertyDefs["HASFALLINGRISK"].DataType;
                    return (bool?)dataType.ConvertValue(val);
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

            public bool? IsClean
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISCLEAN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESBED"].AllPropertyDefs["ISCLEAN"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public GetBedsPropertysByResWard_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetBedsPropertysByResWard_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetBedsPropertysByResWard_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_NewBedQuery_Class : TTReportNqlObject 
        {
            public Object Toplamyataksayisi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOPLAMYATAKSAYISI"]);
                }
            }

            public Object Bosyataksayisi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["BOSYATAKSAYISI"]);
                }
            }

            public Object Doluyougunbakim
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["DOLUYOUGUNBAKIM"]);
                }
            }

            public Object Bosyogunbakim
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["BOSYOGUNBAKIM"]);
                }
            }

            public OLAP_NewBedQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_NewBedQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_NewBedQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetAllClinicsEmptybedCounts_Class : TTReportNqlObject 
        {
            public string Clinic
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CLINIC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RES112CLINICDEF"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Yataksayisi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["YATAKSAYISI"]);
                }
            }

            public GetAllClinicsEmptybedCounts_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetAllClinicsEmptybedCounts_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetAllClinicsEmptybedCounts_Class() : base() { }
        }

        [Serializable] 

        public partial class GetAllClinicsBeds_Class : TTReportNqlObject 
        {
            public string Clinic
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CLINIC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RES112CLINICDEF"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Yataksayisi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["YATAKSAYISI"]);
                }
            }

            public int? PercentageOfEmptyBedFor112
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PERCENTAGEOFEMPTYBEDFOR112"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESWARD"].AllPropertyDefs["PERCENTAGEOFEMPTYBEDFOR112"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public GetAllClinicsBeds_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetAllClinicsBeds_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetAllClinicsBeds_Class() : base() { }
        }

        [Serializable] 

        public partial class GetEmptyBedsWithVentilator_Class : TTReportNqlObject 
        {
            public string Clinic
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CLINIC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RES112CLINICDEF"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Yataksayisi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["YATAKSAYISI"]);
                }
            }

            public GetEmptyBedsWithVentilator_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetEmptyBedsWithVentilator_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetEmptyBedsWithVentilator_Class() : base() { }
        }

        [Serializable] 

        public partial class GetAllBedsWithVentilator_Class : TTReportNqlObject 
        {
            public string Clinic
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CLINIC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RES112CLINICDEF"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Yataksayisi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["YATAKSAYISI"]);
                }
            }

            public GetAllBedsWithVentilator_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetAllBedsWithVentilator_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetAllBedsWithVentilator_Class() : base() { }
        }

        [Serializable] 

        public partial class GetAllBedsKuvez_Class : TTReportNqlObject 
        {
            public string Clinic
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CLINIC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RES112CLINICDEF"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Yataksayisi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["YATAKSAYISI"]);
                }
            }

            public GetAllBedsKuvez_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetAllBedsKuvez_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetAllBedsKuvez_Class() : base() { }
        }

        [Serializable] 

        public partial class GetEmptyBedsKuvez_Class : TTReportNqlObject 
        {
            public string Clinic
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CLINIC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RES112CLINICDEF"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Yataksayisi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["YATAKSAYISI"]);
                }
            }

            public GetEmptyBedsKuvez_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetEmptyBedsKuvez_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetEmptyBedsKuvez_Class() : base() { }
        }

        [Serializable] 

        public partial class GetAllResBeds_Class : TTReportNqlObject 
        {
            public Object Totalbed
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOTALBED"]);
                }
            }

            public GetAllResBeds_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetAllResBeds_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetAllResBeds_Class() : base() { }
        }

        [Serializable] 

        public partial class GetBedDef_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESBED"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Wardname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WARDNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESWARD"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Roomgroupname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ROOMGROUPNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESROOMGROUP"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Roomname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ROOMNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESROOM"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Bedprocedurename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BEDPROCEDURENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BEDPROCEDUREDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Boolean? IsActive
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISACTIVE"]);
                    if (val == null)
                        return null;
                    return (Boolean)Convert.ChangeType(val, typeof(Boolean)); 
                }
            }

            public GetBedDef_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetBedDef_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetBedDef_Class() : base() { }
        }

        [Serializable] 

        public partial class GetAllResBedByResWard_Class : TTReportNqlObject 
        {
            public Guid? Wardobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["WARDOBJECTID"]);
                }
            }

            public string Wardname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WARDNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESWARD"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Totalbed
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOTALBED"]);
                }
            }

            public GetAllResBedByResWard_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetAllResBedByResWard_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetAllResBedByResWard_Class() : base() { }
        }

        [Serializable] 

        public partial class GetEmptyBedsByResWard_Class : TTReportNqlObject 
        {
            public Guid? Wardobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["WARDOBJECTID"]);
                }
            }

            public string Wardname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WARDNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESWARD"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Totalbed
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOTALBED"]);
                }
            }

            public GetEmptyBedsByResWard_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetEmptyBedsByResWard_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetEmptyBedsByResWard_Class() : base() { }
        }

        [Serializable] 

        public partial class GetAllWardsEmptyBedCounts_Class : TTReportNqlObject 
        {
            public Guid? Clinic
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CLINIC"]);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESWARD"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Yataksayisi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["YATAKSAYISI"]);
                }
            }

            public GetAllWardsEmptyBedCounts_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetAllWardsEmptyBedCounts_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetAllWardsEmptyBedCounts_Class() : base() { }
        }

        [Serializable] 

        public partial class VEM_YATAK_Class : TTReportNqlObject 
        {
            public Guid? Yatak_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["YATAK_KODU"]);
                }
            }

            public Object Referans_tablo_adi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["REFERANS_TABLO_ADI"]);
                }
            }

            public string Yatak_adi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["YATAK_ADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESBED"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Oda_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["ODA_KODU"]);
                }
            }

            public Guid? Yatak_turu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["YATAK_TURU"]);
                }
            }

            public Object Ekleyen_kullanici_kodu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["EKLEYEN_KULLANICI_KODU"]);
                }
            }

            public Object Guncelleme_tarihi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["GUNCELLEME_TARIHI"]);
                }
            }

            public Object Guncelleyen_kullanici_kodu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["GUNCELLEYEN_KULLANICI_KODU"]);
                }
            }

            public VEM_YATAK_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public VEM_YATAK_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected VEM_YATAK_Class() : base() { }
        }

        [Serializable] 

        public partial class GetResWardListWithEmtyBedCount_Class : TTReportNqlObject 
        {
            public Guid? Wardobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["WARDOBJECTID"]);
                }
            }

            public Object Nqlcolumn
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["NQLCOLUMN"]);
                }
            }

            public GetResWardListWithEmtyBedCount_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetResWardListWithEmtyBedCount_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetResWardListWithEmtyBedCount_Class() : base() { }
        }

        [Serializable] 

        public partial class GetAllBedUsingInfo_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESBED"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Room
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ROOM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESROOM"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Roomgroup
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ROOMGROUP"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESROOMGROUP"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Clinic
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CLINIC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESWARD"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Clinicid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CLINICID"]);
                }
            }

            public string Islem
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISLEM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BEDPROCEDUREDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Procedureobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PROCEDUREOBJECTID"]);
                }
            }

            public bool? Solunumizolasyon
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SOLUNUMIZOLASYON"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BASEINPATIENTADMISSION"].AllPropertyDefs["HASAIRBORNECONTACTISOLATION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? Damlacikizolasyon
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DAMLACIKIZOLASYON"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BASEINPATIENTADMISSION"].AllPropertyDefs["HASDROPLETISOLATION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? Temasizolasyon
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TEMASIZOLASYON"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BASEINPATIENTADMISSION"].AllPropertyDefs["HASCONTACTISOLATION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? Sikitemasizolasyon
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SIKITEMASIZOLASYON"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BASEINPATIENTADMISSION"].AllPropertyDefs["HASTIGHTCONTACTISOLATION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public GetAllBedUsingInfo_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetAllBedUsingInfo_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetAllBedUsingInfo_Class() : base() { }
        }

        public static BindingList<ResBed.GetEmptyBeds_Class> GetEmptyBeds(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESBED"].QueryDefs["GetEmptyBeds"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResBed.GetEmptyBeds_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ResBed.GetEmptyBeds_Class> GetEmptyBeds(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESBED"].QueryDefs["GetEmptyBeds"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResBed.GetEmptyBeds_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ResBed> GetWithNullUsedByAndRoom(TTObjectContext objectContext, string ROOM)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESBED"].QueryDefs["GetWithNullUsedByAndRoom"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ROOM", ROOM);

            return ((ITTQuery)objectContext).QueryObjects<ResBed>(queryDef, paramList);
        }

        public static BindingList<ResBed> GetWithNullUsedByAndRoomGroup(TTObjectContext objectContext, string ROOMGROUP)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESBED"].QueryDefs["GetWithNullUsedByAndRoomGroup"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ROOMGROUP", ROOMGROUP);

            return ((ITTQuery)objectContext).QueryObjects<ResBed>(queryDef, paramList);
        }

        public static BindingList<ResBed.OLAP_GetUsedByRelation_Class> OLAP_GetUsedByRelation(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESBED"].QueryDefs["OLAP_GetUsedByRelation"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResBed.OLAP_GetUsedByRelation_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ResBed.OLAP_GetUsedByRelation_Class> OLAP_GetUsedByRelation(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESBED"].QueryDefs["OLAP_GetUsedByRelation"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResBed.OLAP_GetUsedByRelation_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ResBed.GetEmptyBedsByClinic_Class> GetEmptyBedsByClinic(string WARD, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESBED"].QueryDefs["GetEmptyBedsByClinic"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("WARD", WARD);

            return TTReportNqlObject.QueryObjects<ResBed.GetEmptyBedsByClinic_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ResBed.GetEmptyBedsByClinic_Class> GetEmptyBedsByClinic(TTObjectContext objectContext, string WARD, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESBED"].QueryDefs["GetEmptyBedsByClinic"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("WARD", WARD);

            return TTReportNqlObject.QueryObjects<ResBed.GetEmptyBedsByClinic_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ResBed> GetWithNullUsedByAndClinic(TTObjectContext objectContext, string WARD)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESBED"].QueryDefs["GetWithNullUsedByAndClinic"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("WARD", WARD);

            return ((ITTQuery)objectContext).QueryObjects<ResBed>(queryDef, paramList);
        }

        public static BindingList<ResBed.GetBedDefinition_Class> GetBedDefinition(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESBED"].QueryDefs["GetBedDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResBed.GetBedDefinition_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ResBed.GetBedDefinition_Class> GetBedDefinition(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESBED"].QueryDefs["GetBedDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResBed.GetBedDefinition_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ResBed.GetEmptyBedsWithoutIntensiveCare_Class> GetEmptyBedsWithoutIntensiveCare(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESBED"].QueryDefs["GetEmptyBedsWithoutIntensiveCare"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResBed.GetEmptyBedsWithoutIntensiveCare_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ResBed.GetEmptyBedsWithoutIntensiveCare_Class> GetEmptyBedsWithoutIntensiveCare(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESBED"].QueryDefs["GetEmptyBedsWithoutIntensiveCare"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResBed.GetEmptyBedsWithoutIntensiveCare_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ResBed.OLAP_GetResBed_Class> OLAP_GetResBed(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESBED"].QueryDefs["OLAP_GetResBed"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResBed.OLAP_GetResBed_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ResBed.OLAP_GetResBed_Class> OLAP_GetResBed(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESBED"].QueryDefs["OLAP_GetResBed"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResBed.OLAP_GetResBed_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ResBed> GetWithNullUsedBy(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESBED"].QueryDefs["GetWithNullUsedBy"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<ResBed>(queryDef, paramList);
        }

        public static BindingList<ResBed.GetEmptyBedCountByClinic_Class> GetEmptyBedCountByClinic(Guid WARD, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESBED"].QueryDefs["GetEmptyBedCountByClinic"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("WARD", WARD);

            return TTReportNqlObject.QueryObjects<ResBed.GetEmptyBedCountByClinic_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ResBed.GetEmptyBedCountByClinic_Class> GetEmptyBedCountByClinic(TTObjectContext objectContext, Guid WARD, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESBED"].QueryDefs["GetEmptyBedCountByClinic"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("WARD", WARD);

            return TTReportNqlObject.QueryObjects<ResBed.GetEmptyBedCountByClinic_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ResBed.GetBedCountByClinic_Class> GetBedCountByClinic(Guid WARD, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESBED"].QueryDefs["GetBedCountByClinic"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("WARD", WARD);

            return TTReportNqlObject.QueryObjects<ResBed.GetBedCountByClinic_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ResBed.GetBedCountByClinic_Class> GetBedCountByClinic(TTObjectContext objectContext, Guid WARD, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESBED"].QueryDefs["GetBedCountByClinic"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("WARD", WARD);

            return TTReportNqlObject.QueryObjects<ResBed.GetBedCountByClinic_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ResBed.GetUsedBedCount_Class> GetUsedBedCount(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESBED"].QueryDefs["GetUsedBedCount"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResBed.GetUsedBedCount_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ResBed.GetUsedBedCount_Class> GetUsedBedCount(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESBED"].QueryDefs["GetUsedBedCount"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResBed.GetUsedBedCount_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ResBed.GetBedsByClinic_Class> GetBedsByClinic(Guid WARD, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESBED"].QueryDefs["GetBedsByClinic"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("WARD", WARD);

            return TTReportNqlObject.QueryObjects<ResBed.GetBedsByClinic_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ResBed.GetBedsByClinic_Class> GetBedsByClinic(TTObjectContext objectContext, Guid WARD, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESBED"].QueryDefs["GetBedsByClinic"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("WARD", WARD);

            return TTReportNqlObject.QueryObjects<ResBed.GetBedsByClinic_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ResBed.GetEmptyBedCount_Class> GetEmptyBedCount(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESBED"].QueryDefs["GetEmptyBedCount"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResBed.GetEmptyBedCount_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ResBed.GetEmptyBedCount_Class> GetEmptyBedCount(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESBED"].QueryDefs["GetEmptyBedCount"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResBed.GetEmptyBedCount_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ResBed.GetBedsPropertysByResWard_Class> GetBedsPropertysByResWard(bool ONLYEMPTY, Guid SELECTEDWARD, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESBED"].QueryDefs["GetBedsPropertysByResWard"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ONLYEMPTY", ONLYEMPTY);
            paramList.Add("SELECTEDWARD", SELECTEDWARD);

            return TTReportNqlObject.QueryObjects<ResBed.GetBedsPropertysByResWard_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ResBed.GetBedsPropertysByResWard_Class> GetBedsPropertysByResWard(TTObjectContext objectContext, bool ONLYEMPTY, Guid SELECTEDWARD, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESBED"].QueryDefs["GetBedsPropertysByResWard"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ONLYEMPTY", ONLYEMPTY);
            paramList.Add("SELECTEDWARD", SELECTEDWARD);

            return TTReportNqlObject.QueryObjects<ResBed.GetBedsPropertysByResWard_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ResBed.OLAP_NewBedQuery_Class> OLAP_NewBedQuery(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESBED"].QueryDefs["OLAP_NewBedQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResBed.OLAP_NewBedQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ResBed.OLAP_NewBedQuery_Class> OLAP_NewBedQuery(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESBED"].QueryDefs["OLAP_NewBedQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResBed.OLAP_NewBedQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ResBed.GetAllClinicsEmptybedCounts_Class> GetAllClinicsEmptybedCounts(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESBED"].QueryDefs["GetAllClinicsEmptybedCounts"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResBed.GetAllClinicsEmptybedCounts_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ResBed.GetAllClinicsEmptybedCounts_Class> GetAllClinicsEmptybedCounts(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESBED"].QueryDefs["GetAllClinicsEmptybedCounts"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResBed.GetAllClinicsEmptybedCounts_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Kliniklerdeki Yataklar
    /// </summary>
        public static BindingList<ResBed.GetAllClinicsBeds_Class> GetAllClinicsBeds(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESBED"].QueryDefs["GetAllClinicsBeds"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResBed.GetAllClinicsBeds_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// Kliniklerdeki Yataklar
    /// </summary>
        public static BindingList<ResBed.GetAllClinicsBeds_Class> GetAllClinicsBeds(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESBED"].QueryDefs["GetAllClinicsBeds"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResBed.GetAllClinicsBeds_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Ventilatörlü Boş Yataklar
    /// </summary>
        public static BindingList<ResBed.GetEmptyBedsWithVentilator_Class> GetEmptyBedsWithVentilator(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESBED"].QueryDefs["GetEmptyBedsWithVentilator"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResBed.GetEmptyBedsWithVentilator_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// Ventilatörlü Boş Yataklar
    /// </summary>
        public static BindingList<ResBed.GetEmptyBedsWithVentilator_Class> GetEmptyBedsWithVentilator(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESBED"].QueryDefs["GetEmptyBedsWithVentilator"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResBed.GetEmptyBedsWithVentilator_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Ventilatorlü Tüm Yataklar
    /// </summary>
        public static BindingList<ResBed.GetAllBedsWithVentilator_Class> GetAllBedsWithVentilator(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESBED"].QueryDefs["GetAllBedsWithVentilator"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResBed.GetAllBedsWithVentilator_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// Ventilatorlü Tüm Yataklar
    /// </summary>
        public static BindingList<ResBed.GetAllBedsWithVentilator_Class> GetAllBedsWithVentilator(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESBED"].QueryDefs["GetAllBedsWithVentilator"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResBed.GetAllBedsWithVentilator_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Kuvezli Yataklar
    /// </summary>
        public static BindingList<ResBed.GetAllBedsKuvez_Class> GetAllBedsKuvez(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESBED"].QueryDefs["GetAllBedsKuvez"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResBed.GetAllBedsKuvez_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// Kuvezli Yataklar
    /// </summary>
        public static BindingList<ResBed.GetAllBedsKuvez_Class> GetAllBedsKuvez(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESBED"].QueryDefs["GetAllBedsKuvez"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResBed.GetAllBedsKuvez_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Boş Küvez Yataklar
    /// </summary>
        public static BindingList<ResBed.GetEmptyBedsKuvez_Class> GetEmptyBedsKuvez(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESBED"].QueryDefs["GetEmptyBedsKuvez"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResBed.GetEmptyBedsKuvez_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// Boş Küvez Yataklar
    /// </summary>
        public static BindingList<ResBed.GetEmptyBedsKuvez_Class> GetEmptyBedsKuvez(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESBED"].QueryDefs["GetEmptyBedsKuvez"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResBed.GetEmptyBedsKuvez_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ResBed.GetAllResBeds_Class> GetAllResBeds(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESBED"].QueryDefs["GetAllResBeds"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResBed.GetAllResBeds_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ResBed.GetAllResBeds_Class> GetAllResBeds(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESBED"].QueryDefs["GetAllResBeds"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResBed.GetAllResBeds_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ResBed.GetBedDef_Class> GetBedDef(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESBED"].QueryDefs["GetBedDef"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResBed.GetBedDef_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ResBed.GetBedDef_Class> GetBedDef(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESBED"].QueryDefs["GetBedDef"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResBed.GetBedDef_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ResBed.GetAllResBedByResWard_Class> GetAllResBedByResWard(Guid SELECTEDWARD, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESBED"].QueryDefs["GetAllResBedByResWard"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SELECTEDWARD", SELECTEDWARD);

            return TTReportNqlObject.QueryObjects<ResBed.GetAllResBedByResWard_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ResBed.GetAllResBedByResWard_Class> GetAllResBedByResWard(TTObjectContext objectContext, Guid SELECTEDWARD, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESBED"].QueryDefs["GetAllResBedByResWard"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SELECTEDWARD", SELECTEDWARD);

            return TTReportNqlObject.QueryObjects<ResBed.GetAllResBedByResWard_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ResBed.GetEmptyBedsByResWard_Class> GetEmptyBedsByResWard(Guid SELECTEDWARD, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESBED"].QueryDefs["GetEmptyBedsByResWard"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SELECTEDWARD", SELECTEDWARD);

            return TTReportNqlObject.QueryObjects<ResBed.GetEmptyBedsByResWard_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ResBed.GetEmptyBedsByResWard_Class> GetEmptyBedsByResWard(TTObjectContext objectContext, Guid SELECTEDWARD, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESBED"].QueryDefs["GetEmptyBedsByResWard"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SELECTEDWARD", SELECTEDWARD);

            return TTReportNqlObject.QueryObjects<ResBed.GetEmptyBedsByResWard_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ResBed> GetUsedBedsByClinic(TTObjectContext objectContext, Guid WARD)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESBED"].QueryDefs["GetUsedBedsByClinic"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("WARD", WARD);

            return ((ITTQuery)objectContext).QueryObjects<ResBed>(queryDef, paramList);
        }

        public static BindingList<ResBed.GetAllWardsEmptyBedCounts_Class> GetAllWardsEmptyBedCounts(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESBED"].QueryDefs["GetAllWardsEmptyBedCounts"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResBed.GetAllWardsEmptyBedCounts_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ResBed.GetAllWardsEmptyBedCounts_Class> GetAllWardsEmptyBedCounts(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESBED"].QueryDefs["GetAllWardsEmptyBedCounts"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResBed.GetAllWardsEmptyBedCounts_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ResBed.VEM_YATAK_Class> VEM_YATAK(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESBED"].QueryDefs["VEM_YATAK"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResBed.VEM_YATAK_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ResBed.VEM_YATAK_Class> VEM_YATAK(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESBED"].QueryDefs["VEM_YATAK"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResBed.VEM_YATAK_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ResBed.GetResWardListWithEmtyBedCount_Class> GetResWardListWithEmtyBedCount(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESBED"].QueryDefs["GetResWardListWithEmtyBedCount"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResBed.GetResWardListWithEmtyBedCount_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ResBed.GetResWardListWithEmtyBedCount_Class> GetResWardListWithEmtyBedCount(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESBED"].QueryDefs["GetResWardListWithEmtyBedCount"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResBed.GetResWardListWithEmtyBedCount_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ResBed> GetAllActiveBeds(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESBED"].QueryDefs["GetAllActiveBeds"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<ResBed>(queryDef, paramList);
        }

        public static BindingList<ResBed.GetAllBedUsingInfo_Class> GetAllBedUsingInfo(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESBED"].QueryDefs["GetAllBedUsingInfo"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResBed.GetAllBedUsingInfo_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ResBed.GetAllBedUsingInfo_Class> GetAllBedUsingInfo(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESBED"].QueryDefs["GetAllBedUsingInfo"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResBed.GetAllBedUsingInfo_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Medula Yatak Kodu
    /// </summary>
        public string BedCodeForMedula
        {
            get { return (string)this["BEDCODEFORMEDULA"]; }
            set { this["BEDCODEFORMEDULA"] = value; }
        }

        public bool? IsVentilator
        {
            get { return (bool?)this["ISVENTILATOR"]; }
            set { this["ISVENTILATOR"] = value; }
        }

        public int? OrderNo
        {
            get { return (int?)this["ORDERNO"]; }
            set { this["ORDERNO"] = value; }
        }

    /// <summary>
    /// Servis Yatak Tipi
    /// </summary>
        public BedProcedureTypeEnum? BedProcedureType
        {
            get { return (BedProcedureTypeEnum?)(int?)this["BEDPROCEDURETYPE"]; }
            set { this["BEDPROCEDURETYPE"] = value; }
        }

        public bool? IsClean
        {
            get { return (bool?)this["ISCLEAN"]; }
            set { this["ISCLEAN"] = value; }
        }

    /// <summary>
    /// Yatak Hizmeti
    /// </summary>
        public BedProcedureDefinition BedProcedure
        {
            get { return (BedProcedureDefinition)((ITTObject)this).GetParent("BEDPROCEDURE"); }
            set { this["BEDPROCEDURE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Kullanım Durumu
    /// </summary>
        public BaseBedProcedure UsedByBedProcedure
        {
            get { return (BaseBedProcedure)((ITTObject)this).GetParent("USEDBYBEDPROCEDURE"); }
            set { this["USEDBYBEDPROCEDURE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Oda
    /// </summary>
        public ResRoom Room
        {
            get { return (ResRoom)((ITTObject)this).GetParent("ROOM"); }
            set { this["ROOM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ResBed(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ResBed(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ResBed(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ResBed(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ResBed(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RESBED", dataRow) { }
        protected ResBed(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RESBED", dataRow, isImported) { }
        public ResBed(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ResBed(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ResBed() : base() { }

    }
}
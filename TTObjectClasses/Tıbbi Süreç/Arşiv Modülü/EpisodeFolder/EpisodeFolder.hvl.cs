
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="EpisodeFolder")] 

    /// <summary>
    /// Episode Dosyası (Cilt)
    /// </summary>
    public  partial class EpisodeFolder : TTObject
    {
        public class EpisodeFolderList : TTObjectCollection<EpisodeFolder> { }
                    
        public class ChildEpisodeFolderCollection : TTObject.TTChildObjectCollection<EpisodeFolder>
        {
            public ChildEpisodeFolderCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildEpisodeFolderCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class EpisodeFolderWorklistNQL_Class : TTReportNqlObject 
        {
            public Guid? FileCreationAndAnalysis
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["FILECREATIONANDANALYSIS"]);
                }
            }

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string EpisodeFolderID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EPISODEFOLDERID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEFOLDER"].AllPropertyDefs["EPISODEFOLDERID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
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

            public Object Ptname
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PTNAME"]);
                }
            }

            public string MotherName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MOTHERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["MOTHERNAME"].DataType;
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

            public string Shelf
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SHELF"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTFOLDER"].AllPropertyDefs["SHELF"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Row
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ROW"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTFOLDER"].AllPropertyDefs["ROW"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? PatientFolderID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTFOLDERID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTFOLDER"].AllPropertyDefs["PATIENTFOLDERID"].DataType;
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

            public bool? Active
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIVE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].AllPropertyDefs["ACTIVE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ClinicInpatientDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CLINICINPATIENTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].AllPropertyDefs["CLINICINPATIENTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ClinicDischargeDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CLINICDISCHARGEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].AllPropertyDefs["CLINICDISCHARGEDATE"].DataType;
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

            public string ManuelArchiveNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MANUELARCHIVENO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEFOLDER"].AllPropertyDefs["MANUELARCHIVENO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Cabinetname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CABINETNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESCABINET"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ShelfName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SHELFNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSHELF"].AllPropertyDefs["SHELFNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public EpisodeFolderWorklistNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public EpisodeFolderWorklistNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected EpisodeFolderWorklistNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class GetEpisodeFolderIDByPatientID_Class : TTReportNqlObject 
        {
            public string Folderid
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FOLDERID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEFOLDER"].AllPropertyDefs["EPISODEFOLDERID"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetEpisodeFolderIDByPatientID_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetEpisodeFolderIDByPatientID_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetEpisodeFolderIDByPatientID_Class() : base() { }
        }

        [Serializable] 

        public partial class GetFileCreationAndAnalyse_Class : TTReportNqlObject 
        {
            public Guid? FileCreationAndAnalysis
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["FILECREATIONANDANALYSIS"]);
                }
            }

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? EpisodeFolderLocation
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODEFOLDERLOCATION"]);
                }
            }

            public string EpisodeFolderID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EPISODEFOLDERID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEFOLDER"].AllPropertyDefs["EPISODEFOLDERID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
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

            public Object Ptname
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PTNAME"]);
                }
            }

            public string MotherName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MOTHERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["MOTHERNAME"].DataType;
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

            public DateTime? ClinicDischargeDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CLINICDISCHARGEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].AllPropertyDefs["CLINICDISCHARGEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ClinicInpatientDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CLINICINPATIENTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].AllPropertyDefs["CLINICINPATIENTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Shelf
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SHELF"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTFOLDER"].AllPropertyDefs["SHELF"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Row
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ROW"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTFOLDER"].AllPropertyDefs["ROW"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? PatientFolderID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTFOLDERID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTFOLDER"].AllPropertyDefs["PATIENTFOLDERID"].DataType;
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

            public string ManuelArchiveNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MANUELARCHIVENO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEFOLDER"].AllPropertyDefs["MANUELARCHIVENO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Cabinetname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CABINETNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESCABINET"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ShelfName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SHELFNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSHELF"].AllPropertyDefs["SHELFNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetFileCreationAndAnalyse_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetFileCreationAndAnalyse_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetFileCreationAndAnalyse_Class() : base() { }
        }

        [Serializable] 

        public partial class GetManuelArchiveNo_Class : TTReportNqlObject 
        {
            public Guid? FileCreationAndAnalysis
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["FILECREATIONANDANALYSIS"]);
                }
            }

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? EpisodeFolderLocation
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODEFOLDERLOCATION"]);
                }
            }

            public string EpisodeFolderID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EPISODEFOLDERID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEFOLDER"].AllPropertyDefs["EPISODEFOLDERID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
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

            public Object Ptname
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PTNAME"]);
                }
            }

            public string MotherName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MOTHERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["MOTHERNAME"].DataType;
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

            public string Shelf
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SHELF"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTFOLDER"].AllPropertyDefs["SHELF"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Row
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ROW"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTFOLDER"].AllPropertyDefs["ROW"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? PatientFolderID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTFOLDERID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTFOLDER"].AllPropertyDefs["PATIENTFOLDERID"].DataType;
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

            public string ManuelArchiveNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MANUELARCHIVENO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEFOLDER"].AllPropertyDefs["MANUELARCHIVENO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetManuelArchiveNo_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetManuelArchiveNo_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetManuelArchiveNo_Class() : base() { }
        }

        [Serializable] 

        public partial class GetEpisodeIDForTIG_Class : TTReportNqlObject 
        {
            public Guid? Episodeobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODEOBJECTID"]);
                }
            }

            public GetEpisodeIDForTIG_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetEpisodeIDForTIG_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetEpisodeIDForTIG_Class() : base() { }
        }

        [Serializable] 

        public partial class GetFCAAForTIG_Class : TTReportNqlObject 
        {
            public Guid? FileCreationAndAnalysis
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["FILECREATIONANDANALYSIS"]);
                }
            }

            public GetFCAAForTIG_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetFCAAForTIG_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetFCAAForTIG_Class() : base() { }
        }

        [Serializable] 

        public partial class EpisodeFolderDataForRequest_Class : TTReportNqlObject 
        {
            public Guid? FileCreationAndAnalysis
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["FILECREATIONANDANALYSIS"]);
                }
            }

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string EpisodeFolderID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EPISODEFOLDERID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEFOLDER"].AllPropertyDefs["EPISODEFOLDERID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
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

            public Object Ptname
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PTNAME"]);
                }
            }

            public string MotherName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MOTHERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["MOTHERNAME"].DataType;
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

            public string Shelf
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SHELF"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTFOLDER"].AllPropertyDefs["SHELF"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Row
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ROW"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTFOLDER"].AllPropertyDefs["ROW"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? PatientFolderID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTFOLDERID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTFOLDER"].AllPropertyDefs["PATIENTFOLDERID"].DataType;
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

            public string ManuelArchiveNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MANUELARCHIVENO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEFOLDER"].AllPropertyDefs["MANUELARCHIVENO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Location
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LOCATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Cabinetname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CABINETNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESCABINET"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ShelfName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SHELFNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSHELF"].AllPropertyDefs["SHELFNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public EpisodeFolderDataForRequest_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public EpisodeFolderDataForRequest_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected EpisodeFolderDataForRequest_Class() : base() { }
        }

        [Serializable] 

        public partial class GetFolderDetailByPatientID_Class : TTReportNqlObject 
        {
            public Guid? FileCreationAndAnalysis
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["FILECREATIONANDANALYSIS"]);
                }
            }

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string EpisodeFolderID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EPISODEFOLDERID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEFOLDER"].AllPropertyDefs["EPISODEFOLDERID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
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

            public Object Ptname
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PTNAME"]);
                }
            }

            public string MotherName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MOTHERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["MOTHERNAME"].DataType;
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

            public string Shelf
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SHELF"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTFOLDER"].AllPropertyDefs["SHELF"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Row
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ROW"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTFOLDER"].AllPropertyDefs["ROW"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? PatientFolderID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTFOLDERID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTFOLDER"].AllPropertyDefs["PATIENTFOLDERID"].DataType;
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

            public string ManuelArchiveNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MANUELARCHIVENO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEFOLDER"].AllPropertyDefs["MANUELARCHIVENO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Location
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LOCATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetFolderDetailByPatientID_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetFolderDetailByPatientID_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetFolderDetailByPatientID_Class() : base() { }
        }

        public static BindingList<EpisodeFolder.EpisodeFolderWorklistNQL_Class> EpisodeFolderWorklistNQL(PatientStatusEnum PATIENTSTATUS, DateTime STARTDATE, DateTime ENDDATE, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEFOLDER"].QueryDefs["EpisodeFolderWorklistNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENTSTATUS", (int)PATIENTSTATUS);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<EpisodeFolder.EpisodeFolderWorklistNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<EpisodeFolder.EpisodeFolderWorklistNQL_Class> EpisodeFolderWorklistNQL(TTObjectContext objectContext, PatientStatusEnum PATIENTSTATUS, DateTime STARTDATE, DateTime ENDDATE, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEFOLDER"].QueryDefs["EpisodeFolderWorklistNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENTSTATUS", (int)PATIENTSTATUS);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<EpisodeFolder.EpisodeFolderWorklistNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<EpisodeFolder.GetEpisodeFolderIDByPatientID_Class> GetEpisodeFolderIDByPatientID(string PATIENTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEFOLDER"].QueryDefs["GetEpisodeFolderIDByPatientID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENTOBJECTID", PATIENTOBJECTID);

            return TTReportNqlObject.QueryObjects<EpisodeFolder.GetEpisodeFolderIDByPatientID_Class>(queryDef, paramList, pi);
        }

        public static BindingList<EpisodeFolder.GetEpisodeFolderIDByPatientID_Class> GetEpisodeFolderIDByPatientID(TTObjectContext objectContext, string PATIENTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEFOLDER"].QueryDefs["GetEpisodeFolderIDByPatientID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENTOBJECTID", PATIENTOBJECTID);

            return TTReportNqlObject.QueryObjects<EpisodeFolder.GetEpisodeFolderIDByPatientID_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<EpisodeFolder.GetFileCreationAndAnalyse_Class> GetFileCreationAndAnalyse(Guid FCAAStatus, IList<Guid> EpisodeFolderLocationList, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEFOLDER"].QueryDefs["GetFileCreationAndAnalyse"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FCAASTATUS", FCAAStatus);
            paramList.Add("EPISODEFOLDERLOCATIONLIST", EpisodeFolderLocationList);

            return TTReportNqlObject.QueryObjects<EpisodeFolder.GetFileCreationAndAnalyse_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<EpisodeFolder.GetFileCreationAndAnalyse_Class> GetFileCreationAndAnalyse(TTObjectContext objectContext, Guid FCAAStatus, IList<Guid> EpisodeFolderLocationList, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEFOLDER"].QueryDefs["GetFileCreationAndAnalyse"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FCAASTATUS", FCAAStatus);
            paramList.Add("EPISODEFOLDERLOCATIONLIST", EpisodeFolderLocationList);

            return TTReportNqlObject.QueryObjects<EpisodeFolder.GetFileCreationAndAnalyse_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<EpisodeFolder.GetManuelArchiveNo_Class> GetManuelArchiveNo(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEFOLDER"].QueryDefs["GetManuelArchiveNo"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<EpisodeFolder.GetManuelArchiveNo_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<EpisodeFolder.GetManuelArchiveNo_Class> GetManuelArchiveNo(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEFOLDER"].QueryDefs["GetManuelArchiveNo"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<EpisodeFolder.GetManuelArchiveNo_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<EpisodeFolder.GetEpisodeIDForTIG_Class> GetEpisodeIDForTIG(string ARCHIVENO, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEFOLDER"].QueryDefs["GetEpisodeIDForTIG"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ARCHIVENO", ARCHIVENO);

            return TTReportNqlObject.QueryObjects<EpisodeFolder.GetEpisodeIDForTIG_Class>(queryDef, paramList, pi);
        }

        public static BindingList<EpisodeFolder.GetEpisodeIDForTIG_Class> GetEpisodeIDForTIG(TTObjectContext objectContext, string ARCHIVENO, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEFOLDER"].QueryDefs["GetEpisodeIDForTIG"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ARCHIVENO", ARCHIVENO);

            return TTReportNqlObject.QueryObjects<EpisodeFolder.GetEpisodeIDForTIG_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<EpisodeFolder.GetFCAAForTIG_Class> GetFCAAForTIG(Guid EPISODEID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEFOLDER"].QueryDefs["GetFCAAForTIG"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODEID", EPISODEID);

            return TTReportNqlObject.QueryObjects<EpisodeFolder.GetFCAAForTIG_Class>(queryDef, paramList, pi);
        }

        public static BindingList<EpisodeFolder.GetFCAAForTIG_Class> GetFCAAForTIG(TTObjectContext objectContext, Guid EPISODEID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEFOLDER"].QueryDefs["GetFCAAForTIG"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODEID", EPISODEID);

            return TTReportNqlObject.QueryObjects<EpisodeFolder.GetFCAAForTIG_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<EpisodeFolder.EpisodeFolderDataForRequest_Class> EpisodeFolderDataForRequest(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEFOLDER"].QueryDefs["EpisodeFolderDataForRequest"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<EpisodeFolder.EpisodeFolderDataForRequest_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<EpisodeFolder.EpisodeFolderDataForRequest_Class> EpisodeFolderDataForRequest(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEFOLDER"].QueryDefs["EpisodeFolderDataForRequest"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<EpisodeFolder.EpisodeFolderDataForRequest_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<EpisodeFolder.GetFolderDetailByPatientID_Class> GetFolderDetailByPatientID(Guid PATIENTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEFOLDER"].QueryDefs["GetFolderDetailByPatientID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENTOBJECTID", PATIENTOBJECTID);

            return TTReportNqlObject.QueryObjects<EpisodeFolder.GetFolderDetailByPatientID_Class>(queryDef, paramList, pi);
        }

        public static BindingList<EpisodeFolder.GetFolderDetailByPatientID_Class> GetFolderDetailByPatientID(TTObjectContext objectContext, Guid PATIENTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEFOLDER"].QueryDefs["GetFolderDetailByPatientID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENTOBJECTID", PATIENTOBJECTID);

            return TTReportNqlObject.QueryObjects<EpisodeFolder.GetFolderDetailByPatientID_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Vaka Dosyası Durumu
    /// </summary>
        public bool? FolderStatus
        {
            get { return (bool?)this["FOLDERSTATUS"]; }
            set { this["FOLDERSTATUS"] = value; }
        }

    /// <summary>
    /// Vaka Dosya Numarası
    /// </summary>
        public string EpisodeFolderID
        {
            get { return (string)this["EPISODEFOLDERID"]; }
            set { this["EPISODEFOLDERID"] = value; }
        }

    /// <summary>
    /// Dosya Bilgisi
    /// </summary>
        public string FolderInformation
        {
            get { return (string)this["FOLDERINFORMATION"]; }
            set { this["FOLDERINFORMATION"] = value; }
        }

    /// <summary>
    /// Elle girilecek olan arşiv numarası
    /// </summary>
        public string ManuelArchiveNo
        {
            get { return (string)this["MANUELARCHIVENO"]; }
            set { this["MANUELARCHIVENO"] = value; }
        }

    /// <summary>
    /// Hasta Dosyası Detayları
    /// </summary>
        public PatientFolder PatientFolder
        {
            get { return (PatientFolder)((ITTObject)this).GetParent("PATIENTFOLDER"); }
            set { this["PATIENTFOLDER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Dosyanın Yeri
    /// </summary>
        public ResSection EpisodeFolderLocation
        {
            get { return (ResSection)((ITTObject)this).GetParent("EPISODEFOLDERLOCATION"); }
            set { this["EPISODEFOLDERLOCATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Dosyanın Son İşlemi
    /// </summary>
        public EpisodeFolderTransaction LastEpisodeFolderTransaction
        {
            get { return (EpisodeFolderTransaction)((ITTObject)this).GetParent("LASTEPISODEFOLDERTRANSACTION"); }
            set { this["LASTEPISODEFOLDERTRANSACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public FileCreationAndAnalysis FileCreationAndAnalysis
        {
            get { return (FileCreationAndAnalysis)((ITTObject)this).GetParent("FILECREATIONANDANALYSIS"); }
            set { this["FILECREATIONANDANALYSIS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public InPatientTreatmentClinicApplication LastInPatientTreatment
        {
            get { return (InPatientTreatmentClinicApplication)((ITTObject)this).GetParent("LASTINPATIENTTREATMENT"); }
            set { this["LASTINPATIENTTREATMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Episode MyEpisode
        {
            get { return (Episode)((ITTObject)this).GetParent("MYEPISODE"); }
            set { this["MYEPISODE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateFolderContentsCollection()
        {
            _FolderContents = new EpisodeFolderContent.ChildEpisodeFolderContentCollection(this, new Guid("05308e8b-4ed4-4c71-b95c-850d0676286c"));
            ((ITTChildObjectCollection)_FolderContents).GetChildren();
        }

        protected EpisodeFolderContent.ChildEpisodeFolderContentCollection _FolderContents = null;
    /// <summary>
    /// Child collection for Dosya İçeriği
    /// </summary>
        public EpisodeFolderContent.ChildEpisodeFolderContentCollection FolderContents
        {
            get
            {
                if (_FolderContents == null)
                    CreateFolderContentsCollection();
                return _FolderContents;
            }
        }

        virtual protected void CreateTransactionsCollection()
        {
            _Transactions = new EpisodeFolderTransaction.ChildEpisodeFolderTransactionCollection(this, new Guid("84c3b125-c4dc-42ba-9fc2-a18da935f8e8"));
            ((ITTChildObjectCollection)_Transactions).GetChildren();
        }

        protected EpisodeFolderTransaction.ChildEpisodeFolderTransactionCollection _Transactions = null;
    /// <summary>
    /// Child collection for Vaka Dosyası Hareketleri
    /// </summary>
        public EpisodeFolderTransaction.ChildEpisodeFolderTransactionCollection Transactions
        {
            get
            {
                if (_Transactions == null)
                    CreateTransactionsCollection();
                return _Transactions;
            }
        }

        virtual protected void CreateBaseInpatientAdmissionCollection()
        {
            _BaseInpatientAdmission = new BaseInpatientAdmission.ChildBaseInpatientAdmissionCollection(this, new Guid("a6285fbf-ee6b-4743-a884-f640028e955b"));
            ((ITTChildObjectCollection)_BaseInpatientAdmission).GetChildren();
        }

        protected BaseInpatientAdmission.ChildBaseInpatientAdmissionCollection _BaseInpatientAdmission = null;
    /// <summary>
    /// Child collection for Episode Dosyası (Cilt)
    /// </summary>
        public BaseInpatientAdmission.ChildBaseInpatientAdmissionCollection BaseInpatientAdmission
        {
            get
            {
                if (_BaseInpatientAdmission == null)
                    CreateBaseInpatientAdmissionCollection();
                return _BaseInpatientAdmission;
            }
        }

        protected EpisodeFolder(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected EpisodeFolder(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected EpisodeFolder(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected EpisodeFolder(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected EpisodeFolder(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EPISODEFOLDER", dataRow) { }
        protected EpisodeFolder(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EPISODEFOLDER", dataRow, isImported) { }
        public EpisodeFolder(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public EpisodeFolder(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public EpisodeFolder() : base() { }

    }
}
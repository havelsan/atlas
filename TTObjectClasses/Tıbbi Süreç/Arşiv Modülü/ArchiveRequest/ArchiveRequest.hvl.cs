
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ArchiveRequest")] 

    /// <summary>
    /// Arşivden dosya isteyebilmek için oluşturuldu
    /// </summary>
    public  partial class ArchiveRequest : TTObject
    {
        public class ArchiveRequestList : TTObjectCollection<ArchiveRequest> { }
                    
        public class ChildArchiveRequestCollection : TTObject.TTChildObjectCollection<ArchiveRequest>
        {
            public ChildArchiveRequestCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildArchiveRequestCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetArchiveRequests_Class : TTReportNqlObject 
        {
            public string Requester
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Section
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SECTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Sectionid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SECTIONID"]);
                }
            }

            public DateTime? Date
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ARCHIVEREQUEST"].AllPropertyDefs["ARCHIVEREQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ARCHIVEREQUEST"].AllPropertyDefs["ARCHIVEREQUESTDESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Fcaaepisode
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["FCAAEPISODE"]);
                }
            }

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

            public Guid? Requestid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["REQUESTID"]);
                }
            }

            public GetArchiveRequests_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetArchiveRequests_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetArchiveRequests_Class() : base() { }
        }

        public static BindingList<ArchiveRequest.GetArchiveRequests_Class> GetArchiveRequests(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ARCHIVEREQUEST"].QueryDefs["GetArchiveRequests"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ArchiveRequest.GetArchiveRequests_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ArchiveRequest.GetArchiveRequests_Class> GetArchiveRequests(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ARCHIVEREQUEST"].QueryDefs["GetArchiveRequests"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ArchiveRequest.GetArchiveRequests_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public DateTime? ArchiveRequestDate
        {
            get { return (DateTime?)this["ARCHIVEREQUESTDATE"]; }
            set { this["ARCHIVEREQUESTDATE"] = value; }
        }

        public string ArchiveRequestDescription
        {
            get { return (string)this["ARCHIVEREQUESTDESCRIPTION"]; }
            set { this["ARCHIVEREQUESTDESCRIPTION"] = value; }
        }

        public bool? RequestCompleted
        {
            get { return (bool?)this["REQUESTCOMPLETED"]; }
            set { this["REQUESTCOMPLETED"] = value; }
        }

    /// <summary>
    /// İstek yapan kullanıcı
    /// </summary>
        public ResUser Requester
        {
            get { return (ResUser)((ITTObject)this).GetParent("REQUESTER"); }
            set { this["REQUESTER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// İstek yapan birim
    /// </summary>
        public ResSection RequesterSection
        {
            get { return (ResSection)((ITTObject)this).GetParent("REQUESTERSECTION"); }
            set { this["REQUESTERSECTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateEpisodeFolderRequestCollection()
        {
            _EpisodeFolderRequest = new EpisodeFolderRequest.ChildEpisodeFolderRequestCollection(this, new Guid("e689f7b0-bc89-4d3c-ad4a-d903375d501d"));
            ((ITTChildObjectCollection)_EpisodeFolderRequest).GetChildren();
        }

        protected EpisodeFolderRequest.ChildEpisodeFolderRequestCollection _EpisodeFolderRequest = null;
        public EpisodeFolderRequest.ChildEpisodeFolderRequestCollection EpisodeFolderRequest
        {
            get
            {
                if (_EpisodeFolderRequest == null)
                    CreateEpisodeFolderRequestCollection();
                return _EpisodeFolderRequest;
            }
        }

        protected ArchiveRequest(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ArchiveRequest(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ArchiveRequest(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ArchiveRequest(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ArchiveRequest(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ARCHIVEREQUEST", dataRow) { }
        protected ArchiveRequest(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ARCHIVEREQUEST", dataRow, isImported) { }
        public ArchiveRequest(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ArchiveRequest(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ArchiveRequest() : base() { }

    }
}
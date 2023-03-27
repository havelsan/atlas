
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="UploadedDocument")] 

    public  partial class UploadedDocument : TTObject
    {
        public class UploadedDocumentList : TTObjectCollection<UploadedDocument> { }
                    
        public class ChildUploadedDocumentCollection : TTObject.TTChildObjectCollection<UploadedDocument>
        {
            public ChildUploadedDocumentCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildUploadedDocumentCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetPatientDocumentCount_Class : TTReportNqlObject 
        {
            public Object Dokumansayisi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["DOKUMANSAYISI"]);
                }
            }

            public GetPatientDocumentCount_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPatientDocumentCount_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPatientDocumentCount_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPatientDocuments_Class : TTReportNqlObject 
        {
            public Guid? Documentid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DOCUMENTID"]);
                }
            }

            public string Dosyaadi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOSYAADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["UPLOADEDDOCUMENT"].AllPropertyDefs["FILENAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Ekleyenkullanici
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EKLEYENKULLANICI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public UploadedDocumentType? Dokumantipi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOKUMANTIPI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["UPLOADEDDOCUMENT"].AllPropertyDefs["DOCUMENTTYPE"].DataType;
                    return (UploadedDocumentType?)(int)dataType.ConvertValue(val);
                }
            }

            public string Aciklama
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACIKLAMA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["UPLOADEDDOCUMENT"].AllPropertyDefs["EXPLANATION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? Eklenmetarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EKLENMETARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["UPLOADEDDOCUMENT"].AllPropertyDefs["UPLOADDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
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

            public GetPatientDocuments_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPatientDocuments_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPatientDocuments_Class() : base() { }
        }

        [Serializable] 

        public partial class GetAllPatientDocuments_Class : TTReportNqlObject 
        {
            public Guid? Documentid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DOCUMENTID"]);
                }
            }

            public string Dosyaadi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOSYAADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["UPLOADEDDOCUMENT"].AllPropertyDefs["FILENAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Ekleyenkullanici
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EKLEYENKULLANICI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Dokumantipiadi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOKUMANTIPIADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOSYATURU"].AllPropertyDefs["DOSYATURUADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Dokumantipiid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DOKUMANTIPIID"]);
                }
            }

            public string Aciklama
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACIKLAMA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["UPLOADEDDOCUMENT"].AllPropertyDefs["EXPLANATION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? Eklenmetarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EKLENMETARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["UPLOADEDDOCUMENT"].AllPropertyDefs["UPLOADDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
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

            public object File
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FILE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["UPLOADEDDOCUMENT"].AllPropertyDefs["FILE"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public GetAllPatientDocuments_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetAllPatientDocuments_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetAllPatientDocuments_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPatientEpisodes_Class : TTReportNqlObject 
        {
            public Guid? Episodeid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODEID"]);
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

            public DateTime? Date
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["OPENINGDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetPatientEpisodes_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPatientEpisodes_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPatientEpisodes_Class() : base() { }
        }

        public static BindingList<UploadedDocument.GetPatientDocumentCount_Class> GetPatientDocumentCount(Guid PATIENT, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["UPLOADEDDOCUMENT"].QueryDefs["GetPatientDocumentCount"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return TTReportNqlObject.QueryObjects<UploadedDocument.GetPatientDocumentCount_Class>(queryDef, paramList, pi);
        }

        public static BindingList<UploadedDocument.GetPatientDocumentCount_Class> GetPatientDocumentCount(TTObjectContext objectContext, Guid PATIENT, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["UPLOADEDDOCUMENT"].QueryDefs["GetPatientDocumentCount"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return TTReportNqlObject.QueryObjects<UploadedDocument.GetPatientDocumentCount_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<UploadedDocument.GetPatientDocuments_Class> GetPatientDocuments(Guid EPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["UPLOADEDDOCUMENT"].QueryDefs["GetPatientDocuments"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<UploadedDocument.GetPatientDocuments_Class>(queryDef, paramList, pi);
        }

        public static BindingList<UploadedDocument.GetPatientDocuments_Class> GetPatientDocuments(TTObjectContext objectContext, Guid EPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["UPLOADEDDOCUMENT"].QueryDefs["GetPatientDocuments"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<UploadedDocument.GetPatientDocuments_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<UploadedDocument> GetPatientAllDocuments(TTObjectContext objectContext, Guid PATIENTID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["UPLOADEDDOCUMENT"].QueryDefs["GetPatientAllDocuments"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENTID", PATIENTID);

            return ((ITTQuery)objectContext).QueryObjects<UploadedDocument>(queryDef, paramList);
        }

        public static BindingList<UploadedDocument.GetAllPatientDocuments_Class> GetAllPatientDocuments(Guid EPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["UPLOADEDDOCUMENT"].QueryDefs["GetAllPatientDocuments"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<UploadedDocument.GetAllPatientDocuments_Class>(queryDef, paramList, pi);
        }

        public static BindingList<UploadedDocument.GetAllPatientDocuments_Class> GetAllPatientDocuments(TTObjectContext objectContext, Guid EPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["UPLOADEDDOCUMENT"].QueryDefs["GetAllPatientDocuments"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<UploadedDocument.GetAllPatientDocuments_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<UploadedDocument.GetPatientEpisodes_Class> GetPatientEpisodes(Guid PATIENT, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["UPLOADEDDOCUMENT"].QueryDefs["GetPatientEpisodes"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return TTReportNqlObject.QueryObjects<UploadedDocument.GetPatientEpisodes_Class>(queryDef, paramList, pi);
        }

        public static BindingList<UploadedDocument.GetPatientEpisodes_Class> GetPatientEpisodes(TTObjectContext objectContext, Guid PATIENT, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["UPLOADEDDOCUMENT"].QueryDefs["GetPatientEpisodes"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return TTReportNqlObject.QueryObjects<UploadedDocument.GetPatientEpisodes_Class>(objectContext, queryDef, paramList, pi);
        }

        public DateTime? UploadDate
        {
            get { return (DateTime?)this["UPLOADDATE"]; }
            set { this["UPLOADDATE"] = value; }
        }

        public string Explanation
        {
            get { return (string)this["EXPLANATION"]; }
            set { this["EXPLANATION"] = value; }
        }

        public UploadedDocumentType? DocumentType
        {
            get { return (UploadedDocumentType?)(int?)this["DOCUMENTTYPE"]; }
            set { this["DOCUMENTTYPE"] = value; }
        }

        public object File
        {
            get { return (object)this["FILE"]; }
            set { this["FILE"] = value; }
        }

        public string FileName
        {
            get { return (string)this["FILENAME"]; }
            set { this["FILENAME"] = value; }
        }

        public Episode Episode
        {
            get { return (Episode)((ITTObject)this).GetParent("EPISODE"); }
            set { this["EPISODE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ResUser Uploader
        {
            get { return (ResUser)((ITTObject)this).GetParent("UPLOADER"); }
            set { this["UPLOADER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public DosyaTuru DosyaTuru
        {
            get { return (DosyaTuru)((ITTObject)this).GetParent("DOSYATURU"); }
            set { this["DOSYATURU"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public BaseAction BaseAction
        {
            get { return (BaseAction)((ITTObject)this).GetParent("BASEACTION"); }
            set { this["BASEACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SubEpisode SubEpisode
        {
            get { return (SubEpisode)((ITTObject)this).GetParent("SUBEPISODE"); }
            set { this["SUBEPISODE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateMedulaDocumentEntriesCollection()
        {
            _MedulaDocumentEntries = new MedulaDocumentEntry.ChildMedulaDocumentEntryCollection(this, new Guid("175ea6cd-886c-4f25-a077-ee4f4b8afa27"));
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

        protected UploadedDocument(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected UploadedDocument(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected UploadedDocument(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected UploadedDocument(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected UploadedDocument(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "UPLOADEDDOCUMENT", dataRow) { }
        protected UploadedDocument(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "UPLOADEDDOCUMENT", dataRow, isImported) { }
        public UploadedDocument(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public UploadedDocument(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public UploadedDocument() : base() { }

    }
}
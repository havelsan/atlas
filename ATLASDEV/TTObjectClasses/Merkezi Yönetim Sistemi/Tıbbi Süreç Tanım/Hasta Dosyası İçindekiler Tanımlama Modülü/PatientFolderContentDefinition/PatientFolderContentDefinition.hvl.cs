
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PatientFolderContentDefinition")] 

    /// <summary>
    /// Hasta Dosyası İçindekiler Tanımlama
    /// </summary>
    public  partial class PatientFolderContentDefinition : TTDefinitionSet
    {
        public class PatientFolderContentDefinitionList : TTObjectCollection<PatientFolderContentDefinition> { }
                    
        public class ChildPatientFolderContentDefinitionCollection : TTObject.TTChildObjectCollection<PatientFolderContentDefinition>
        {
            public ChildPatientFolderContentDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPatientFolderContentDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetPatientFolderContent_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? ObjectDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTDEFID"]);
                }
            }

            public Guid? CurrentStateDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENTSTATEDEFID"]);
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

            public DateTime? LastUpdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LASTUPDATE"]);
                    if (val == null)
                        return null;
                    return (DateTime)Convert.ChangeType(val, typeof(DateTime)); 
                }
            }

            public string FileName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FILENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTFOLDERCONTENTDEFINITION"].AllPropertyDefs["FILENAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? Active
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIVE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTFOLDERCONTENTDEFINITION"].AllPropertyDefs["ACTIVE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public GetPatientFolderContent_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPatientFolderContent_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPatientFolderContent_Class() : base() { }
        }

        public static BindingList<PatientFolderContentDefinition.GetPatientFolderContent_Class> GetPatientFolderContent(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTFOLDERCONTENTDEFINITION"].QueryDefs["GetPatientFolderContent"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PatientFolderContentDefinition.GetPatientFolderContent_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PatientFolderContentDefinition.GetPatientFolderContent_Class> GetPatientFolderContent(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTFOLDERCONTENTDEFINITION"].QueryDefs["GetPatientFolderContent"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PatientFolderContentDefinition.GetPatientFolderContent_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Belgenin Adı
    /// </summary>
        public string FileName
        {
            get { return (string)this["FILENAME"]; }
            set { this["FILENAME"] = value; }
        }

    /// <summary>
    /// Aktif
    /// </summary>
        public bool? Active
        {
            get { return (bool?)this["ACTIVE"]; }
            set { this["ACTIVE"] = value; }
        }

        protected PatientFolderContentDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PatientFolderContentDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PatientFolderContentDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PatientFolderContentDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PatientFolderContentDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PATIENTFOLDERCONTENTDEFINITION", dataRow) { }
        protected PatientFolderContentDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PATIENTFOLDERCONTENTDEFINITION", dataRow, isImported) { }
        public PatientFolderContentDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PatientFolderContentDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PatientFolderContentDefinition() : base() { }

    }
}
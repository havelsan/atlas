
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="AudiologyDiagnosisDef")] 

    public  partial class AudiologyDiagnosisDef : TerminologyManagerDef
    {
        public class AudiologyDiagnosisDefList : TTObjectCollection<AudiologyDiagnosisDef> { }
                    
        public class ChildAudiologyDiagnosisDefCollection : TTObject.TTChildObjectCollection<AudiologyDiagnosisDef>
        {
            public ChildAudiologyDiagnosisDefCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildAudiologyDiagnosisDefCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetAudiologyDiagnosis_Class : TTReportNqlObject 
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

            public string DiagnosisName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIAGNOSISNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["AUDIOLOGYDIAGNOSISDEF"].AllPropertyDefs["DIAGNOSISNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Name_Shadow
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME_SHADOW"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["AUDIOLOGYDIAGNOSISDEF"].AllPropertyDefs["NAME_SHADOW"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetAudiologyDiagnosis_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetAudiologyDiagnosis_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetAudiologyDiagnosis_Class() : base() { }
        }

        public static BindingList<AudiologyDiagnosisDef.GetAudiologyDiagnosis_Class> GetAudiologyDiagnosis(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["AUDIOLOGYDIAGNOSISDEF"].QueryDefs["GetAudiologyDiagnosis"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<AudiologyDiagnosisDef.GetAudiologyDiagnosis_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<AudiologyDiagnosisDef.GetAudiologyDiagnosis_Class> GetAudiologyDiagnosis(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["AUDIOLOGYDIAGNOSISDEF"].QueryDefs["GetAudiologyDiagnosis"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<AudiologyDiagnosisDef.GetAudiologyDiagnosis_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public string DiagnosisName
        {
            get { return (string)this["DIAGNOSISNAME"]; }
            set { this["DIAGNOSISNAME"] = value; }
        }

    /// <summary>
    /// Tanı Adı
    /// </summary>
        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
        }

        protected AudiologyDiagnosisDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected AudiologyDiagnosisDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected AudiologyDiagnosisDef(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected AudiologyDiagnosisDef(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected AudiologyDiagnosisDef(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "AUDIOLOGYDIAGNOSISDEF", dataRow) { }
        protected AudiologyDiagnosisDef(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "AUDIOLOGYDIAGNOSISDEF", dataRow, isImported) { }
        public AudiologyDiagnosisDef(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public AudiologyDiagnosisDef(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public AudiologyDiagnosisDef() : base() { }

    }
}
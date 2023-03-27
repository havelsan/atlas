
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MedicalCommiteeDefinition")] 

    /// <summary>
    /// Tıbbi Kurullar Tanımlama
    /// </summary>
    public  partial class MedicalCommiteeDefinition : TTDefinitionSet
    {
        public class MedicalCommiteeDefinitionList : TTObjectCollection<MedicalCommiteeDefinition> { }
                    
        public class ChildMedicalCommiteeDefinitionCollection : TTObject.TTChildObjectCollection<MedicalCommiteeDefinition>
        {
            public ChildMedicalCommiteeDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMedicalCommiteeDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetMedicalCommiteeDefinition_Class : TTReportNqlObject 
        {
            public long? Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALCOMMITEEDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Type
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALCOMMITEEDEFINITION"].AllPropertyDefs["TYPE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetMedicalCommiteeDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMedicalCommiteeDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMedicalCommiteeDefinition_Class() : base() { }
        }

        public static BindingList<MedicalCommiteeDefinition.GetMedicalCommiteeDefinition_Class> GetMedicalCommiteeDefinition(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDICALCOMMITEEDEFINITION"].QueryDefs["GetMedicalCommiteeDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MedicalCommiteeDefinition.GetMedicalCommiteeDefinition_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<MedicalCommiteeDefinition.GetMedicalCommiteeDefinition_Class> GetMedicalCommiteeDefinition(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDICALCOMMITEEDEFINITION"].QueryDefs["GetMedicalCommiteeDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MedicalCommiteeDefinition.GetMedicalCommiteeDefinition_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Kurulun Tipi
    /// </summary>
        public string Type
        {
            get { return (string)this["TYPE"]; }
            set { this["TYPE"] = value; }
        }

        public string Type_Shadow
        {
            get { return (string)this["TYPE_SHADOW"]; }
        }

    /// <summary>
    /// Kodu
    /// </summary>
        public long? Code
        {
            get { return (long?)this["CODE"]; }
            set { this["CODE"] = value; }
        }

    /// <summary>
    /// Birim(ler)
    /// </summary>
        public ResSection Resource
        {
            get { return (ResSection)((ITTObject)this).GetParent("RESOURCE"); }
            set { this["RESOURCE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MedicalCommiteeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MedicalCommiteeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MedicalCommiteeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MedicalCommiteeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MedicalCommiteeDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MEDICALCOMMITEEDEFINITION", dataRow) { }
        protected MedicalCommiteeDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MEDICALCOMMITEEDEFINITION", dataRow, isImported) { }
        protected MedicalCommiteeDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MedicalCommiteeDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MedicalCommiteeDefinition() : base() { }

    }
}

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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MedulaICD10")] 

    /// <summary>
    /// Medula ICD10
    /// </summary>
    public  partial class MedulaICD10 : BaseMedulaDefinition
    {
        public class MedulaICD10List : TTObjectCollection<MedulaICD10> { }
                    
        public class ChildMedulaICD10Collection : TTObject.TTChildObjectCollection<MedulaICD10>
        {
            public ChildMedulaICD10Collection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMedulaICD10Collection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetMedulaICD10DefinitionQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string taniKodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TANIKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDULAICD10"].AllPropertyDefs["TANIKODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string taniAdi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TANIADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDULAICD10"].AllPropertyDefs["TANIADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetMedulaICD10DefinitionQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMedulaICD10DefinitionQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMedulaICD10DefinitionQuery_Class() : base() { }
        }

        public static BindingList<MedulaICD10.GetMedulaICD10DefinitionQuery_Class> GetMedulaICD10DefinitionQuery(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDULAICD10"].QueryDefs["GetMedulaICD10DefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MedulaICD10.GetMedulaICD10DefinitionQuery_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<MedulaICD10.GetMedulaICD10DefinitionQuery_Class> GetMedulaICD10DefinitionQuery(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDULAICD10"].QueryDefs["GetMedulaICD10DefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MedulaICD10.GetMedulaICD10DefinitionQuery_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// ICD10 Kodu
    /// </summary>
        public string taniKodu
        {
            get { return (string)this["TANIKODU"]; }
            set { this["TANIKODU"] = value; }
        }

    /// <summary>
    /// Tanı Adı
    /// </summary>
        public string taniAdi
        {
            get { return (string)this["TANIADI"]; }
            set { this["TANIADI"] = value; }
        }

        public string taniAdi_Shadow
        {
            get { return (string)this["TANIADI_SHADOW"]; }
        }

        public string taniKodu_Shadow
        {
            get { return (string)this["TANIKODU_SHADOW"]; }
        }

        protected MedulaICD10(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MedulaICD10(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MedulaICD10(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MedulaICD10(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MedulaICD10(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MEDULAICD10", dataRow) { }
        protected MedulaICD10(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MEDULAICD10", dataRow, isImported) { }
        public MedulaICD10(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MedulaICD10(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MedulaICD10() : base() { }

    }
}
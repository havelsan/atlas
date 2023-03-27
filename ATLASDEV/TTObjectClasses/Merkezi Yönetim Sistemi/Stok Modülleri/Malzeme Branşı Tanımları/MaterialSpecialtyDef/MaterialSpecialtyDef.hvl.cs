
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MaterialSpecialtyDef")] 

    /// <summary>
    /// Malzeme Branşı Tanımı
    /// </summary>
    public  partial class MaterialSpecialtyDef : TerminologyManagerDef
    {
        public class MaterialSpecialtyDefList : TTObjectCollection<MaterialSpecialtyDef> { }
                    
        public class ChildMaterialSpecialtyDefCollection : TTObject.TTChildObjectCollection<MaterialSpecialtyDef>
        {
            public ChildMaterialSpecialtyDefCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMaterialSpecialtyDefCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetMaterialSpecialtyDefList_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIALSPECIALTYDEF"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetMaterialSpecialtyDefList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMaterialSpecialtyDefList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMaterialSpecialtyDefList_Class() : base() { }
        }

        public static BindingList<MaterialSpecialtyDef.GetMaterialSpecialtyDefList_Class> GetMaterialSpecialtyDefList(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIALSPECIALTYDEF"].QueryDefs["GetMaterialSpecialtyDefList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MaterialSpecialtyDef.GetMaterialSpecialtyDefList_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<MaterialSpecialtyDef.GetMaterialSpecialtyDefList_Class> GetMaterialSpecialtyDefList(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIALSPECIALTYDEF"].QueryDefs["GetMaterialSpecialtyDefList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MaterialSpecialtyDef.GetMaterialSpecialtyDefList_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
        }

    /// <summary>
    /// Kodu
    /// </summary>
        public string Code
        {
            get { return (string)this["CODE"]; }
            set { this["CODE"] = value; }
        }

        protected MaterialSpecialtyDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MaterialSpecialtyDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MaterialSpecialtyDef(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MaterialSpecialtyDef(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MaterialSpecialtyDef(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MATERIALSPECIALTYDEF", dataRow) { }
        protected MaterialSpecialtyDef(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MATERIALSPECIALTYDEF", dataRow, isImported) { }
        public MaterialSpecialtyDef(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MaterialSpecialtyDef(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MaterialSpecialtyDef() : base() { }

    }
}
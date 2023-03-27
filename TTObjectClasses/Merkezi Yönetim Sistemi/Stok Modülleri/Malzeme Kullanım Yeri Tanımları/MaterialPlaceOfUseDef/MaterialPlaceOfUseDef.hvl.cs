
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MaterialPlaceOfUseDef")] 

    /// <summary>
    /// Malzeme Kullanım Yeri Tanımı
    /// </summary>
    public  partial class MaterialPlaceOfUseDef : TerminologyManagerDef
    {
        public class MaterialPlaceOfUseDefList : TTObjectCollection<MaterialPlaceOfUseDef> { }
                    
        public class ChildMaterialPlaceOfUseDefCollection : TTObject.TTChildObjectCollection<MaterialPlaceOfUseDef>
        {
            public ChildMaterialPlaceOfUseDefCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMaterialPlaceOfUseDefCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetMaterialPlaceOfUseDefList_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIALPLACEOFUSEDEF"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetMaterialPlaceOfUseDefList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMaterialPlaceOfUseDefList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMaterialPlaceOfUseDefList_Class() : base() { }
        }

        public static BindingList<MaterialPlaceOfUseDef.GetMaterialPlaceOfUseDefList_Class> GetMaterialPlaceOfUseDefList(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIALPLACEOFUSEDEF"].QueryDefs["GetMaterialPlaceOfUseDefList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MaterialPlaceOfUseDef.GetMaterialPlaceOfUseDefList_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<MaterialPlaceOfUseDef.GetMaterialPlaceOfUseDefList_Class> GetMaterialPlaceOfUseDefList(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIALPLACEOFUSEDEF"].QueryDefs["GetMaterialPlaceOfUseDefList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MaterialPlaceOfUseDef.GetMaterialPlaceOfUseDefList_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Kullanım Yeri
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
        }

        protected MaterialPlaceOfUseDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MaterialPlaceOfUseDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MaterialPlaceOfUseDef(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MaterialPlaceOfUseDef(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MaterialPlaceOfUseDef(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MATERIALPLACEOFUSEDEF", dataRow) { }
        protected MaterialPlaceOfUseDef(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MATERIALPLACEOFUSEDEF", dataRow, isImported) { }
        public MaterialPlaceOfUseDef(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MaterialPlaceOfUseDef(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MaterialPlaceOfUseDef() : base() { }

    }
}
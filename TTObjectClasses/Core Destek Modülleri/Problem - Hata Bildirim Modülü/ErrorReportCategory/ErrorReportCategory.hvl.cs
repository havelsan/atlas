
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ErrorReportCategory")] 

    public  partial class ErrorReportCategory : TTDefinitionSet
    {
        public class ErrorReportCategoryList : TTObjectCollection<ErrorReportCategory> { }
                    
        public class ChildErrorReportCategoryCollection : TTObject.TTChildObjectCollection<ErrorReportCategory>
        {
            public ChildErrorReportCategoryCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildErrorReportCategoryCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetErrorReportCategoryDefinitionQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Maincode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MAINCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ERRORREPORTMAINCATEGORY"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ERRORREPORTCATEGORY"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ERRORREPORTCATEGORY"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Toresourcename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TORESOURCENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESCOMMANDERSHIP"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Maincategoryname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MAINCATEGORYNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ERRORREPORTMAINCATEGORY"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetErrorReportCategoryDefinitionQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetErrorReportCategoryDefinitionQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetErrorReportCategoryDefinitionQuery_Class() : base() { }
        }

        public static BindingList<ErrorReportCategory.GetErrorReportCategoryDefinitionQuery_Class> GetErrorReportCategoryDefinitionQuery(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ERRORREPORTCATEGORY"].QueryDefs["GetErrorReportCategoryDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ErrorReportCategory.GetErrorReportCategoryDefinitionQuery_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ErrorReportCategory.GetErrorReportCategoryDefinitionQuery_Class> GetErrorReportCategoryDefinitionQuery(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ERRORREPORTCATEGORY"].QueryDefs["GetErrorReportCategoryDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ErrorReportCategory.GetErrorReportCategoryDefinitionQuery_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Kodu
    /// </summary>
        public string Code
        {
            get { return (string)this["CODE"]; }
            set { this["CODE"] = value; }
        }

    /// <summary>
    /// Kategori Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

    /// <summary>
    /// Kategori Önceliği
    /// </summary>
        public ErrorPriorityEnum? CategoryPriority
        {
            get { return (ErrorPriorityEnum?)(int?)this["CATEGORYPRIORITY"]; }
            set { this["CATEGORYPRIORITY"] = value; }
        }

    /// <summary>
    /// Envanter seçilmeli mi?
    /// </summary>
        public bool? InventoryRequired
        {
            get { return (bool?)this["INVENTORYREQUIRED"]; }
            set { this["INVENTORYREQUIRED"] = value; }
        }

    /// <summary>
    /// İşi Yönlendiren Birim
    /// </summary>
        public ResCommandership ToResource
        {
            get { return (ResCommandership)((ITTObject)this).GetParent("TORESOURCE"); }
            set { this["TORESOURCE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// İşi Yapacak Birim
    /// </summary>
        public ResCommandershipSubUnit OwnerResource
        {
            get { return (ResCommandershipSubUnit)((ITTObject)this).GetParent("OWNERRESOURCE"); }
            set { this["OWNERRESOURCE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ErrorReportMainCategory MainCategory
        {
            get { return (ErrorReportMainCategory)((ITTObject)this).GetParent("MAINCATEGORY"); }
            set { this["MAINCATEGORY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ErrorReportCategory(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ErrorReportCategory(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ErrorReportCategory(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ErrorReportCategory(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ErrorReportCategory(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ERRORREPORTCATEGORY", dataRow) { }
        protected ErrorReportCategory(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ERRORREPORTCATEGORY", dataRow, isImported) { }
        public ErrorReportCategory(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ErrorReportCategory(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ErrorReportCategory() : base() { }

    }
}
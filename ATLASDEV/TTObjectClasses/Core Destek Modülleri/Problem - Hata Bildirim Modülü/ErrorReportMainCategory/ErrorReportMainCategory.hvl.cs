
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ErrorReportMainCategory")] 

    /// <summary>
    /// Problem / Hata Ana Kategori
    /// </summary>
    public  partial class ErrorReportMainCategory : TTDefinitionSet
    {
        public class ErrorReportMainCategoryList : TTObjectCollection<ErrorReportMainCategory> { }
                    
        public class ChildErrorReportMainCategoryCollection : TTObject.TTChildObjectCollection<ErrorReportMainCategory>
        {
            public ChildErrorReportMainCategoryCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildErrorReportMainCategoryCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetErrorReportMainCategoryListDefinition_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ERRORREPORTMAINCATEGORY"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ERRORREPORTMAINCATEGORY"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetErrorReportMainCategoryListDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetErrorReportMainCategoryListDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetErrorReportMainCategoryListDefinition_Class() : base() { }
        }

        public static BindingList<ErrorReportMainCategory.GetErrorReportMainCategoryListDefinition_Class> GetErrorReportMainCategoryListDefinition(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ERRORREPORTMAINCATEGORY"].QueryDefs["GetErrorReportMainCategoryListDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ErrorReportMainCategory.GetErrorReportMainCategoryListDefinition_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ErrorReportMainCategory.GetErrorReportMainCategoryListDefinition_Class> GetErrorReportMainCategoryListDefinition(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ERRORREPORTMAINCATEGORY"].QueryDefs["GetErrorReportMainCategoryListDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ErrorReportMainCategory.GetErrorReportMainCategoryListDefinition_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Kodu
    /// </summary>
        public string Code
        {
            get { return (string)this["CODE"]; }
            set { this["CODE"] = value; }
        }

        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        virtual protected void CreateErrorReportCategoriesCollection()
        {
            _ErrorReportCategories = new ErrorReportCategory.ChildErrorReportCategoryCollection(this, new Guid("649263b5-7bbd-4f6d-820f-b54231b22afa"));
            ((ITTChildObjectCollection)_ErrorReportCategories).GetChildren();
        }

        protected ErrorReportCategory.ChildErrorReportCategoryCollection _ErrorReportCategories = null;
        public ErrorReportCategory.ChildErrorReportCategoryCollection ErrorReportCategories
        {
            get
            {
                if (_ErrorReportCategories == null)
                    CreateErrorReportCategoriesCollection();
                return _ErrorReportCategories;
            }
        }

        protected ErrorReportMainCategory(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ErrorReportMainCategory(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ErrorReportMainCategory(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ErrorReportMainCategory(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ErrorReportMainCategory(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ERRORREPORTMAINCATEGORY", dataRow) { }
        protected ErrorReportMainCategory(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ERRORREPORTMAINCATEGORY", dataRow, isImported) { }
        public ErrorReportMainCategory(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ErrorReportMainCategory(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ErrorReportMainCategory() : base() { }

    }
}
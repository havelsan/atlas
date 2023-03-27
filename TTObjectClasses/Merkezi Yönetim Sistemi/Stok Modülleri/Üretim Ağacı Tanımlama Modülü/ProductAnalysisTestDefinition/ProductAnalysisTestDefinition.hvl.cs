
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ProductAnalysisTestDefinition")] 

    /// <summary>
    /// Ürün Analiz Test Tanımı
    /// </summary>
    public  partial class ProductAnalysisTestDefinition : TTDefinitionSet
    {
        public class ProductAnalysisTestDefinitionList : TTObjectCollection<ProductAnalysisTestDefinition> { }
                    
        public class ChildProductAnalysisTestDefinitionCollection : TTObject.TTChildObjectCollection<ProductAnalysisTestDefinition>
        {
            public ChildProductAnalysisTestDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildProductAnalysisTestDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetProductAnalysisTestDefinitionQuery_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRODUCTANALYSISTESTDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetProductAnalysisTestDefinitionQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetProductAnalysisTestDefinitionQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetProductAnalysisTestDefinitionQuery_Class() : base() { }
        }

        public static BindingList<ProductAnalysisTestDefinition.GetProductAnalysisTestDefinitionQuery_Class> GetProductAnalysisTestDefinitionQuery(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRODUCTANALYSISTESTDEFINITION"].QueryDefs["GetProductAnalysisTestDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ProductAnalysisTestDefinition.GetProductAnalysisTestDefinitionQuery_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ProductAnalysisTestDefinition.GetProductAnalysisTestDefinitionQuery_Class> GetProductAnalysisTestDefinitionQuery(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRODUCTANALYSISTESTDEFINITION"].QueryDefs["GetProductAnalysisTestDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ProductAnalysisTestDefinition.GetProductAnalysisTestDefinitionQuery_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Test Adı
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

        protected ProductAnalysisTestDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ProductAnalysisTestDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ProductAnalysisTestDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ProductAnalysisTestDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ProductAnalysisTestDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PRODUCTANALYSISTESTDEFINITION", dataRow) { }
        protected ProductAnalysisTestDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PRODUCTANALYSISTESTDEFINITION", dataRow, isImported) { }
        public ProductAnalysisTestDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ProductAnalysisTestDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ProductAnalysisTestDefinition() : base() { }

    }
}

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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="TaburcuKodu")] 

    /// <summary>
    /// Taburcu Kodu
    /// </summary>
    public  partial class TaburcuKodu : BaseMedulaDefinition
    {
        public class TaburcuKoduList : TTObjectCollection<TaburcuKodu> { }
                    
        public class ChildTaburcuKoduCollection : TTObject.TTChildObjectCollection<TaburcuKodu>
        {
            public ChildTaburcuKoduCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildTaburcuKoduCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetTaburcuKoduDefinitionQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string taburcuKodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TABURCUKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TABURCUKODU"].AllPropertyDefs["TABURCUKODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string taburcuKoduAdi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TABURCUKODUADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TABURCUKODU"].AllPropertyDefs["TABURCUKODUADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetTaburcuKoduDefinitionQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetTaburcuKoduDefinitionQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetTaburcuKoduDefinitionQuery_Class() : base() { }
        }

        public static BindingList<TaburcuKodu.GetTaburcuKoduDefinitionQuery_Class> GetTaburcuKoduDefinitionQuery(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["TABURCUKODU"].QueryDefs["GetTaburcuKoduDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<TaburcuKodu.GetTaburcuKoduDefinitionQuery_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<TaburcuKodu.GetTaburcuKoduDefinitionQuery_Class> GetTaburcuKoduDefinitionQuery(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["TABURCUKODU"].QueryDefs["GetTaburcuKoduDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<TaburcuKodu.GetTaburcuKoduDefinitionQuery_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Taburcu Kodu
    /// </summary>
        public string taburcuKodu
        {
            get { return (string)this["TABURCUKODU"]; }
            set { this["TABURCUKODU"] = value; }
        }

    /// <summary>
    /// Taburcu Kodu Adı
    /// </summary>
        public string taburcuKoduAdi
        {
            get { return (string)this["TABURCUKODUADI"]; }
            set { this["TABURCUKODUADI"] = value; }
        }

        protected TaburcuKodu(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected TaburcuKodu(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected TaburcuKodu(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected TaburcuKodu(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected TaburcuKodu(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "TABURCUKODU", dataRow) { }
        protected TaburcuKodu(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "TABURCUKODU", dataRow, isImported) { }
        public TaburcuKodu(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public TaburcuKodu(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public TaburcuKodu() : base() { }

    }
}
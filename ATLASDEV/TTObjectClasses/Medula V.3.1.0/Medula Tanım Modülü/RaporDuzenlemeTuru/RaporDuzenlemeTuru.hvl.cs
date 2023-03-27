
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="RaporDuzenlemeTuru")] 

    public  partial class RaporDuzenlemeTuru : BaseMedulaDefinition
    {
        public class RaporDuzenlemeTuruList : TTObjectCollection<RaporDuzenlemeTuru> { }
                    
        public class ChildRaporDuzenlemeTuruCollection : TTObject.TTChildObjectCollection<RaporDuzenlemeTuru>
        {
            public ChildRaporDuzenlemeTuruCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildRaporDuzenlemeTuruCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetRaporDuzenlemeTuruDefinitionQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string raporDuzenlemeTuruKodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RAPORDUZENLEMETURUKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RAPORDUZENLEMETURU"].AllPropertyDefs["RAPORDUZENLEMETURUKODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string raporDuzenlemeTuruAdi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RAPORDUZENLEMETURUADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RAPORDUZENLEMETURU"].AllPropertyDefs["RAPORDUZENLEMETURUADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetRaporDuzenlemeTuruDefinitionQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetRaporDuzenlemeTuruDefinitionQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetRaporDuzenlemeTuruDefinitionQuery_Class() : base() { }
        }

        public static BindingList<RaporDuzenlemeTuru.GetRaporDuzenlemeTuruDefinitionQuery_Class> GetRaporDuzenlemeTuruDefinitionQuery(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RAPORDUZENLEMETURU"].QueryDefs["GetRaporDuzenlemeTuruDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<RaporDuzenlemeTuru.GetRaporDuzenlemeTuruDefinitionQuery_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<RaporDuzenlemeTuru.GetRaporDuzenlemeTuruDefinitionQuery_Class> GetRaporDuzenlemeTuruDefinitionQuery(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RAPORDUZENLEMETURU"].QueryDefs["GetRaporDuzenlemeTuruDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<RaporDuzenlemeTuru.GetRaporDuzenlemeTuruDefinitionQuery_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public string raporDuzenlemeTuruAdi
        {
            get { return (string)this["RAPORDUZENLEMETURUADI"]; }
            set { this["RAPORDUZENLEMETURUADI"] = value; }
        }

        public string raporDuzenlemeTuruAdi_Shadow
        {
            get { return (string)this["RAPORDUZENLEMETURUADI_SHADOW"]; }
        }

        public string raporDuzenlemeTuruKodu
        {
            get { return (string)this["RAPORDUZENLEMETURUKODU"]; }
            set { this["RAPORDUZENLEMETURUKODU"] = value; }
        }

        protected RaporDuzenlemeTuru(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected RaporDuzenlemeTuru(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected RaporDuzenlemeTuru(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected RaporDuzenlemeTuru(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected RaporDuzenlemeTuru(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RAPORDUZENLEMETURU", dataRow) { }
        protected RaporDuzenlemeTuru(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RAPORDUZENLEMETURU", dataRow, isImported) { }
        public RaporDuzenlemeTuru(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public RaporDuzenlemeTuru(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public RaporDuzenlemeTuru() : base() { }

    }
}
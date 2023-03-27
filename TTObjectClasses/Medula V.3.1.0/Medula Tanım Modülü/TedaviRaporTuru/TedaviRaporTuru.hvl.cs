
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="TedaviRaporTuru")] 

    public  partial class TedaviRaporTuru : BaseMedulaDefinition
    {
        public class TedaviRaporTuruList : TTObjectCollection<TedaviRaporTuru> { }
                    
        public class ChildTedaviRaporTuruCollection : TTObject.TTChildObjectCollection<TedaviRaporTuru>
        {
            public ChildTedaviRaporTuruCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildTedaviRaporTuruCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetTedaviRaporTuruDefinitionQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public int? tedaviRaporTuruKodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TEDAVIRAPORTURUKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TEDAVIRAPORTURU"].AllPropertyDefs["TEDAVIRAPORTURUKODU"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string tedaviRaporTuruAdi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TEDAVIRAPORTURUADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TEDAVIRAPORTURU"].AllPropertyDefs["TEDAVIRAPORTURUADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetTedaviRaporTuruDefinitionQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetTedaviRaporTuruDefinitionQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetTedaviRaporTuruDefinitionQuery_Class() : base() { }
        }

        public static BindingList<TedaviRaporTuru.GetTedaviRaporTuruDefinitionQuery_Class> GetTedaviRaporTuruDefinitionQuery(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["TEDAVIRAPORTURU"].QueryDefs["GetTedaviRaporTuruDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<TedaviRaporTuru.GetTedaviRaporTuruDefinitionQuery_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<TedaviRaporTuru.GetTedaviRaporTuruDefinitionQuery_Class> GetTedaviRaporTuruDefinitionQuery(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["TEDAVIRAPORTURU"].QueryDefs["GetTedaviRaporTuruDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<TedaviRaporTuru.GetTedaviRaporTuruDefinitionQuery_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public string tedaviRaporTuruAdi
        {
            get { return (string)this["TEDAVIRAPORTURUADI"]; }
            set { this["TEDAVIRAPORTURUADI"] = value; }
        }

        public string tedaviRaporTuruAdi_Shadow
        {
            get { return (string)this["TEDAVIRAPORTURUADI_SHADOW"]; }
            set { this["TEDAVIRAPORTURUADI_SHADOW"] = value; }
        }

        public int? tedaviRaporTuruKodu
        {
            get { return (int?)this["TEDAVIRAPORTURUKODU"]; }
            set { this["TEDAVIRAPORTURUKODU"] = value; }
        }

        protected TedaviRaporTuru(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected TedaviRaporTuru(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected TedaviRaporTuru(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected TedaviRaporTuru(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected TedaviRaporTuru(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "TEDAVIRAPORTURU", dataRow) { }
        protected TedaviRaporTuru(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "TEDAVIRAPORTURU", dataRow, isImported) { }
        public TedaviRaporTuru(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public TedaviRaporTuru(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public TedaviRaporTuru() : base() { }

    }
}
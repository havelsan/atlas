
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="RaporTuru")] 

    public  partial class RaporTuru : BaseMedulaDefinition
    {
        public class RaporTuruList : TTObjectCollection<RaporTuru> { }
                    
        public class ChildRaporTuruCollection : TTObject.TTChildObjectCollection<RaporTuru>
        {
            public ChildRaporTuruCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildRaporTuruCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetRaporTuruDefinitionQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string raporTuruKodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RAPORTURUKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RAPORTURU"].AllPropertyDefs["RAPORTURUKODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string raporTuruAdi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RAPORTURUADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RAPORTURU"].AllPropertyDefs["RAPORTURUADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetRaporTuruDefinitionQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetRaporTuruDefinitionQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetRaporTuruDefinitionQuery_Class() : base() { }
        }

        public static BindingList<RaporTuru.GetRaporTuruDefinitionQuery_Class> GetRaporTuruDefinitionQuery(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RAPORTURU"].QueryDefs["GetRaporTuruDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<RaporTuru.GetRaporTuruDefinitionQuery_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<RaporTuru.GetRaporTuruDefinitionQuery_Class> GetRaporTuruDefinitionQuery(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RAPORTURU"].QueryDefs["GetRaporTuruDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<RaporTuru.GetRaporTuruDefinitionQuery_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public string raporTuruAdi
        {
            get { return (string)this["RAPORTURUADI"]; }
            set { this["RAPORTURUADI"] = value; }
        }

        public string raporTuruAdi_Shadow
        {
            get { return (string)this["RAPORTURUADI_SHADOW"]; }
        }

        public string raporTuruKodu
        {
            get { return (string)this["RAPORTURUKODU"]; }
            set { this["RAPORTURUKODU"] = value; }
        }

        protected RaporTuru(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected RaporTuru(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected RaporTuru(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected RaporTuru(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected RaporTuru(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RAPORTURU", dataRow) { }
        protected RaporTuru(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RAPORTURU", dataRow, isImported) { }
        public RaporTuru(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public RaporTuru(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public RaporTuru() : base() { }

    }
}
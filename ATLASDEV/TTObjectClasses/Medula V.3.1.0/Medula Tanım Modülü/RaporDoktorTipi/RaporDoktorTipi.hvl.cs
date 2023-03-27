
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="RaporDoktorTipi")] 

    public  partial class RaporDoktorTipi : BaseMedulaDefinition
    {
        public class RaporDoktorTipiList : TTObjectCollection<RaporDoktorTipi> { }
                    
        public class ChildRaporDoktorTipiCollection : TTObject.TTChildObjectCollection<RaporDoktorTipi>
        {
            public ChildRaporDoktorTipiCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildRaporDoktorTipiCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetRaporDoktorTipiDefinitionQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string raporDoktorTipiKodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RAPORDOKTORTIPIKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RAPORDOKTORTIPI"].AllPropertyDefs["RAPORDOKTORTIPIKODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string raporDoktorTipiAdi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RAPORDOKTORTIPIADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RAPORDOKTORTIPI"].AllPropertyDefs["RAPORDOKTORTIPIADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetRaporDoktorTipiDefinitionQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetRaporDoktorTipiDefinitionQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetRaporDoktorTipiDefinitionQuery_Class() : base() { }
        }

        public static BindingList<RaporDoktorTipi.GetRaporDoktorTipiDefinitionQuery_Class> GetRaporDoktorTipiDefinitionQuery(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RAPORDOKTORTIPI"].QueryDefs["GetRaporDoktorTipiDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<RaporDoktorTipi.GetRaporDoktorTipiDefinitionQuery_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<RaporDoktorTipi.GetRaporDoktorTipiDefinitionQuery_Class> GetRaporDoktorTipiDefinitionQuery(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RAPORDOKTORTIPI"].QueryDefs["GetRaporDoktorTipiDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<RaporDoktorTipi.GetRaporDoktorTipiDefinitionQuery_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public string raporDoktorTipiAdi
        {
            get { return (string)this["RAPORDOKTORTIPIADI"]; }
            set { this["RAPORDOKTORTIPIADI"] = value; }
        }

        public string raporDoktorTipiAdi_Shadow
        {
            get { return (string)this["RAPORDOKTORTIPIADI_SHADOW"]; }
            set { this["RAPORDOKTORTIPIADI_SHADOW"] = value; }
        }

        public string raporDoktorTipiKodu
        {
            get { return (string)this["RAPORDOKTORTIPIKODU"]; }
            set { this["RAPORDOKTORTIPIKODU"] = value; }
        }

        protected RaporDoktorTipi(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected RaporDoktorTipi(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected RaporDoktorTipi(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected RaporDoktorTipi(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected RaporDoktorTipi(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RAPORDOKTORTIPI", dataRow) { }
        protected RaporDoktorTipi(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RAPORDOKTORTIPI", dataRow, isImported) { }
        public RaporDoktorTipi(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public RaporDoktorTipi(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public RaporDoktorTipi() : base() { }

    }
}
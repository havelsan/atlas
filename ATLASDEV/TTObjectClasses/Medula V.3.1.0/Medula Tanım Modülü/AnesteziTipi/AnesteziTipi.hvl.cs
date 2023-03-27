
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="AnesteziTipi")] 

    public  partial class AnesteziTipi : BaseMedulaDefinition
    {
        public class AnesteziTipiList : TTObjectCollection<AnesteziTipi> { }
                    
        public class ChildAnesteziTipiCollection : TTObject.TTChildObjectCollection<AnesteziTipi>
        {
            public ChildAnesteziTipiCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildAnesteziTipiCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetAnesteziTipiDefinitionQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string anesteziTipiKodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ANESTEZITIPIKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ANESTEZITIPI"].AllPropertyDefs["ANESTEZITIPIKODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string anesteziTipiAdi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ANESTEZITIPIADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ANESTEZITIPI"].AllPropertyDefs["ANESTEZITIPIADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetAnesteziTipiDefinitionQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetAnesteziTipiDefinitionQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetAnesteziTipiDefinitionQuery_Class() : base() { }
        }

        public static BindingList<AnesteziTipi.GetAnesteziTipiDefinitionQuery_Class> GetAnesteziTipiDefinitionQuery(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ANESTEZITIPI"].QueryDefs["GetAnesteziTipiDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<AnesteziTipi.GetAnesteziTipiDefinitionQuery_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<AnesteziTipi.GetAnesteziTipiDefinitionQuery_Class> GetAnesteziTipiDefinitionQuery(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ANESTEZITIPI"].QueryDefs["GetAnesteziTipiDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<AnesteziTipi.GetAnesteziTipiDefinitionQuery_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public string anesteziTipiAdi
        {
            get { return (string)this["ANESTEZITIPIADI"]; }
            set { this["ANESTEZITIPIADI"] = value; }
        }

        public string anesteziTipiAdi_Shadow
        {
            get { return (string)this["ANESTEZITIPIADI_SHADOW"]; }
            set { this["ANESTEZITIPIADI_SHADOW"] = value; }
        }

        public string anesteziTipiKodu
        {
            get { return (string)this["ANESTEZITIPIKODU"]; }
            set { this["ANESTEZITIPIKODU"] = value; }
        }

        protected AnesteziTipi(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected AnesteziTipi(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected AnesteziTipi(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected AnesteziTipi(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected AnesteziTipi(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ANESTEZITIPI", dataRow) { }
        protected AnesteziTipi(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ANESTEZITIPI", dataRow, isImported) { }
        public AnesteziTipi(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public AnesteziTipi(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public AnesteziTipi() : base() { }

    }
}
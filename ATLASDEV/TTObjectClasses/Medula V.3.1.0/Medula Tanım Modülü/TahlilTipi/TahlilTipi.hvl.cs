
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="TahlilTipi")] 

    /// <summary>
    /// Tahlil Tipi
    /// </summary>
    public  partial class TahlilTipi : BaseMedulaDefinition
    {
        public class TahlilTipiList : TTObjectCollection<TahlilTipi> { }
                    
        public class ChildTahlilTipiCollection : TTObject.TTChildObjectCollection<TahlilTipi>
        {
            public ChildTahlilTipiCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildTahlilTipiCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetTahlilTipiDefinitionQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string tahlilTipKodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TAHLILTIPKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TAHLILTIPI"].AllPropertyDefs["TAHLILTIPKODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetTahlilTipiDefinitionQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetTahlilTipiDefinitionQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetTahlilTipiDefinitionQuery_Class() : base() { }
        }

        public static BindingList<TahlilTipi.GetTahlilTipiDefinitionQuery_Class> GetTahlilTipiDefinitionQuery(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["TAHLILTIPI"].QueryDefs["GetTahlilTipiDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<TahlilTipi.GetTahlilTipiDefinitionQuery_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<TahlilTipi.GetTahlilTipiDefinitionQuery_Class> GetTahlilTipiDefinitionQuery(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["TAHLILTIPI"].QueryDefs["GetTahlilTipiDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<TahlilTipi.GetTahlilTipiDefinitionQuery_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Tahlil Tipi Kodu
    /// </summary>
        public string tahlilTipKodu
        {
            get { return (string)this["TAHLILTIPKODU"]; }
            set { this["TAHLILTIPKODU"] = value; }
        }

        protected TahlilTipi(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected TahlilTipi(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected TahlilTipi(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected TahlilTipi(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected TahlilTipi(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "TAHLILTIPI", dataRow) { }
        protected TahlilTipi(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "TAHLILTIPI", dataRow, isImported) { }
        public TahlilTipi(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public TahlilTipi(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public TahlilTipi() : base() { }

    }
}
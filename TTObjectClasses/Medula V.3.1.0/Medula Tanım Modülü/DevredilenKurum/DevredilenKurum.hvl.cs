
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DevredilenKurum")] 

    /// <summary>
    /// Devredilen Kurum
    /// </summary>
    public  partial class DevredilenKurum : BaseMedulaDefinition
    {
        public class DevredilenKurumList : TTObjectCollection<DevredilenKurum> { }
                    
        public class ChildDevredilenKurumCollection : TTObject.TTChildObjectCollection<DevredilenKurum>
        {
            public ChildDevredilenKurumCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDevredilenKurumCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetDevredilenKurumDefinitionQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string devredilenKurumKodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DEVREDILENKURUMKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DEVREDILENKURUM"].AllPropertyDefs["DEVREDILENKURUMKODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string devredilenKurumAdi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DEVREDILENKURUMADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DEVREDILENKURUM"].AllPropertyDefs["DEVREDILENKURUMADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetDevredilenKurumDefinitionQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDevredilenKurumDefinitionQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDevredilenKurumDefinitionQuery_Class() : base() { }
        }

        public static BindingList<DevredilenKurum.GetDevredilenKurumDefinitionQuery_Class> GetDevredilenKurumDefinitionQuery(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DEVREDILENKURUM"].QueryDefs["GetDevredilenKurumDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DevredilenKurum.GetDevredilenKurumDefinitionQuery_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DevredilenKurum.GetDevredilenKurumDefinitionQuery_Class> GetDevredilenKurumDefinitionQuery(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DEVREDILENKURUM"].QueryDefs["GetDevredilenKurumDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DevredilenKurum.GetDevredilenKurumDefinitionQuery_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public string devredilenKurumAdi_Shadow
        {
            get { return (string)this["DEVREDILENKURUMADI_SHADOW"]; }
        }

    /// <summary>
    /// Devredilen Kurum Adı
    /// </summary>
        public string devredilenKurumAdi
        {
            get { return (string)this["DEVREDILENKURUMADI"]; }
            set { this["DEVREDILENKURUMADI"] = value; }
        }

    /// <summary>
    /// Devredilen Kurum Kodu
    /// </summary>
        public string devredilenKurumKodu
        {
            get { return (string)this["DEVREDILENKURUMKODU"]; }
            set { this["DEVREDILENKURUMKODU"] = value; }
        }

        protected DevredilenKurum(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DevredilenKurum(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DevredilenKurum(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DevredilenKurum(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DevredilenKurum(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DEVREDILENKURUM", dataRow) { }
        protected DevredilenKurum(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DEVREDILENKURUM", dataRow, isImported) { }
        public DevredilenKurum(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DevredilenKurum(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DevredilenKurum() : base() { }

    }
}
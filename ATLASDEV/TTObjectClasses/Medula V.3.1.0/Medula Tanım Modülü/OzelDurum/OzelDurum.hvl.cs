
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="OzelDurum")] 

    public  partial class OzelDurum : BaseMedulaDefinition
    {
        public class OzelDurumList : TTObjectCollection<OzelDurum> { }
                    
        public class ChildOzelDurumCollection : TTObject.TTChildObjectCollection<OzelDurum>
        {
            public ChildOzelDurumCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildOzelDurumCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetOzelDurumDefinitionQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string ozelDurumKodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OZELDURUMKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OZELDURUM"].AllPropertyDefs["OZELDURUMKODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ozelDurumAdi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OZELDURUMADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OZELDURUM"].AllPropertyDefs["OZELDURUMADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetOzelDurumDefinitionQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetOzelDurumDefinitionQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetOzelDurumDefinitionQuery_Class() : base() { }
        }

        public static BindingList<OzelDurum.GetOzelDurumDefinitionQuery_Class> GetOzelDurumDefinitionQuery(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["OZELDURUM"].QueryDefs["GetOzelDurumDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<OzelDurum.GetOzelDurumDefinitionQuery_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<OzelDurum.GetOzelDurumDefinitionQuery_Class> GetOzelDurumDefinitionQuery(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["OZELDURUM"].QueryDefs["GetOzelDurumDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<OzelDurum.GetOzelDurumDefinitionQuery_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<OzelDurum> GetOzelDurumByKod(TTObjectContext objectContext, string KOD)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["OZELDURUM"].QueryDefs["GetOzelDurumByKod"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("KOD", KOD);

            return ((ITTQuery)objectContext).QueryObjects<OzelDurum>(queryDef, paramList);
        }

    /// <summary>
    /// Özel Durum Adı
    /// </summary>
        public string ozelDurumAdi
        {
            get { return (string)this["OZELDURUMADI"]; }
            set { this["OZELDURUMADI"] = value; }
        }

        public string ozelDurumAdi_Shadow
        {
            get { return (string)this["OZELDURUMADI_SHADOW"]; }
        }

    /// <summary>
    /// Özel Durum Kodu
    /// </summary>
        public string ozelDurumKodu
        {
            get { return (string)this["OZELDURUMKODU"]; }
            set { this["OZELDURUMKODU"] = value; }
        }

        protected OzelDurum(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected OzelDurum(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected OzelDurum(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected OzelDurum(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected OzelDurum(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "OZELDURUM", dataRow) { }
        protected OzelDurum(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "OZELDURUM", dataRow, isImported) { }
        public OzelDurum(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public OzelDurum(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public OzelDurum() : base() { }

    }
}
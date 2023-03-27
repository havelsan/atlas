
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MalzemeTuru")] 

    /// <summary>
    /// Malzeme Türü
    /// </summary>
    public  partial class MalzemeTuru : BaseMedulaDefinition
    {
        public class MalzemeTuruList : TTObjectCollection<MalzemeTuru> { }
                    
        public class ChildMalzemeTuruCollection : TTObject.TTChildObjectCollection<MalzemeTuru>
        {
            public ChildMalzemeTuruCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMalzemeTuruCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetMalzemeTuruDefinitionQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string malzemeTuruKodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MALZEMETURUKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MALZEMETURU"].AllPropertyDefs["MALZEMETURUKODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string malzemeTuruAdi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MALZEMETURUADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MALZEMETURU"].AllPropertyDefs["MALZEMETURUADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetMalzemeTuruDefinitionQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMalzemeTuruDefinitionQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMalzemeTuruDefinitionQuery_Class() : base() { }
        }

        public static BindingList<MalzemeTuru.GetMalzemeTuruDefinitionQuery_Class> GetMalzemeTuruDefinitionQuery(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MALZEMETURU"].QueryDefs["GetMalzemeTuruDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MalzemeTuru.GetMalzemeTuruDefinitionQuery_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<MalzemeTuru.GetMalzemeTuruDefinitionQuery_Class> GetMalzemeTuruDefinitionQuery(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MALZEMETURU"].QueryDefs["GetMalzemeTuruDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MalzemeTuru.GetMalzemeTuruDefinitionQuery_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Malzeme Türü Adı
    /// </summary>
        public string malzemeTuruAdi
        {
            get { return (string)this["MALZEMETURUADI"]; }
            set { this["MALZEMETURUADI"] = value; }
        }

        public string malzemeTuruAdi_Shadow
        {
            get { return (string)this["MALZEMETURUADI_SHADOW"]; }
        }

    /// <summary>
    /// Malzeme Türü Kodu
    /// </summary>
        public string malzemeTuruKodu
        {
            get { return (string)this["MALZEMETURUKODU"]; }
            set { this["MALZEMETURUKODU"] = value; }
        }

        protected MalzemeTuru(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MalzemeTuru(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MalzemeTuru(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MalzemeTuru(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MalzemeTuru(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MALZEMETURU", dataRow) { }
        protected MalzemeTuru(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MALZEMETURU", dataRow, isImported) { }
        public MalzemeTuru(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MalzemeTuru(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MalzemeTuru() : base() { }

    }
}

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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="KatkiPayi")] 

    /// <summary>
    /// Katkı Payı
    /// </summary>
    public  partial class KatkiPayi : BaseMedulaDefinition
    {
        public class KatkiPayiList : TTObjectCollection<KatkiPayi> { }
                    
        public class ChildKatkiPayiCollection : TTObject.TTChildObjectCollection<KatkiPayi>
        {
            public ChildKatkiPayiCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildKatkiPayiCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetKatkiPayiDefinitionQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string katkiPayiKodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KATKIPAYIKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["KATKIPAYI"].AllPropertyDefs["KATKIPAYIKODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string katkiPayiAdi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KATKIPAYIADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["KATKIPAYI"].AllPropertyDefs["KATKIPAYIADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetKatkiPayiDefinitionQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetKatkiPayiDefinitionQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetKatkiPayiDefinitionQuery_Class() : base() { }
        }

        public static BindingList<KatkiPayi.GetKatkiPayiDefinitionQuery_Class> GetKatkiPayiDefinitionQuery(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["KATKIPAYI"].QueryDefs["GetKatkiPayiDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<KatkiPayi.GetKatkiPayiDefinitionQuery_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<KatkiPayi.GetKatkiPayiDefinitionQuery_Class> GetKatkiPayiDefinitionQuery(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["KATKIPAYI"].QueryDefs["GetKatkiPayiDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<KatkiPayi.GetKatkiPayiDefinitionQuery_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Katkı Payı Adı
    /// </summary>
        public string katkiPayiAdi
        {
            get { return (string)this["KATKIPAYIADI"]; }
            set { this["KATKIPAYIADI"] = value; }
        }

    /// <summary>
    /// Katkı Payı Kodu
    /// </summary>
        public string katkiPayiKodu
        {
            get { return (string)this["KATKIPAYIKODU"]; }
            set { this["KATKIPAYIKODU"] = value; }
        }

        public string katkiPayiAdi_Shadow
        {
            get { return (string)this["KATKIPAYIADI_SHADOW"]; }
        }

        protected KatkiPayi(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected KatkiPayi(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected KatkiPayi(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected KatkiPayi(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected KatkiPayi(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "KATKIPAYI", dataRow) { }
        protected KatkiPayi(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "KATKIPAYI", dataRow, isImported) { }
        public KatkiPayi(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public KatkiPayi(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public KatkiPayi() : base() { }

    }
}
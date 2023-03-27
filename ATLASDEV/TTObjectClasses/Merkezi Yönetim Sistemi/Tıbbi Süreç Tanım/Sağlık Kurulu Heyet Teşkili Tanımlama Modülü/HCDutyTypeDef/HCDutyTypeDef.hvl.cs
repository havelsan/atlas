
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HCDutyTypeDef")] 

    /// <summary>
    /// Sağlık Kurulu Görev Tanımları
    /// </summary>
    public  partial class HCDutyTypeDef : TerminologyManagerDef
    {
        public class HCDutyTypeDefList : TTObjectCollection<HCDutyTypeDef> { }
                    
        public class ChildHCDutyTypeDefCollection : TTObject.TTChildObjectCollection<HCDutyTypeDef>
        {
            public ChildHCDutyTypeDefCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHCDutyTypeDefCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetHCDutyTypeDef_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public long? Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HCDUTYTYPEDEF"].AllPropertyDefs["CODE"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HCDUTYTYPEDEF"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetHCDutyTypeDef_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetHCDutyTypeDef_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetHCDutyTypeDef_Class() : base() { }
        }

        public static BindingList<HCDutyTypeDef.GetHCDutyTypeDef_Class> GetHCDutyTypeDef(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HCDUTYTYPEDEF"].QueryDefs["GetHCDutyTypeDef"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<HCDutyTypeDef.GetHCDutyTypeDef_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<HCDutyTypeDef.GetHCDutyTypeDef_Class> GetHCDutyTypeDef(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HCDUTYTYPEDEF"].QueryDefs["GetHCDutyTypeDef"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<HCDutyTypeDef.GetHCDutyTypeDef_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<HCDutyTypeDef> GetHCDutyType(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HCDUTYTYPEDEF"].QueryDefs["GetHCDutyType"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<HCDutyTypeDef>(queryDef, paramList);
        }

        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
        }

    /// <summary>
    /// Kodu
    /// </summary>
        public long? Code
        {
            get { return (long?)this["CODE"]; }
            set { this["CODE"] = value; }
        }

    /// <summary>
    /// Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        protected HCDutyTypeDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HCDutyTypeDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HCDutyTypeDef(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HCDutyTypeDef(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HCDutyTypeDef(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HCDUTYTYPEDEF", dataRow) { }
        protected HCDutyTypeDef(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HCDUTYTYPEDEF", dataRow, isImported) { }
        public HCDutyTypeDef(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HCDutyTypeDef(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HCDutyTypeDef() : base() { }

    }
}

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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HCResultTypeDef")] 

    /// <summary>
    /// Sağlık Kurulu Sonuç Tanımları
    /// </summary>
    public  partial class HCResultTypeDef : TerminologyManagerDef
    {
        public class HCResultTypeDefList : TTObjectCollection<HCResultTypeDef> { }
                    
        public class ChildHCResultTypeDefCollection : TTObject.TTChildObjectCollection<HCResultTypeDef>
        {
            public ChildHCResultTypeDefCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHCResultTypeDefCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetHCResultTypeDef_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HCRESULTTYPEDEF"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HCRESULTTYPEDEF"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetHCResultTypeDef_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetHCResultTypeDef_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetHCResultTypeDef_Class() : base() { }
        }

        public static BindingList<HCResultTypeDef.GetHCResultTypeDef_Class> GetHCResultTypeDef(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HCRESULTTYPEDEF"].QueryDefs["GetHCResultTypeDef"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<HCResultTypeDef.GetHCResultTypeDef_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<HCResultTypeDef.GetHCResultTypeDef_Class> GetHCResultTypeDef(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HCRESULTTYPEDEF"].QueryDefs["GetHCResultTypeDef"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<HCResultTypeDef.GetHCResultTypeDef_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<HCResultTypeDef> GetHCResultType(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HCRESULTTYPEDEF"].QueryDefs["GetHCResultType"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<HCResultTypeDef>(queryDef, paramList);
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

        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
        }

        protected HCResultTypeDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HCResultTypeDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HCResultTypeDef(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HCResultTypeDef(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HCResultTypeDef(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HCRESULTTYPEDEF", dataRow) { }
        protected HCResultTypeDef(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HCRESULTTYPEDEF", dataRow, isImported) { }
        public HCResultTypeDef(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HCResultTypeDef(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HCResultTypeDef() : base() { }

    }
}
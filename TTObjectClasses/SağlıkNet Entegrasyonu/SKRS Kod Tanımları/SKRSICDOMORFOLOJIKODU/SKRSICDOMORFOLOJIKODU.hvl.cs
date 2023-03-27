
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SKRSICDOMORFOLOJIKODU")] 

    /// <summary>
    /// 40220f50-1c9c-43c9-9bbd-45794d5cc7b2
    /// </summary>
    public  partial class SKRSICDOMORFOLOJIKODU : BaseSKRSDefinition
    {
        public class SKRSICDOMORFOLOJIKODUList : TTObjectCollection<SKRSICDOMORFOLOJIKODU> { }
                    
        public class ChildSKRSICDOMORFOLOJIKODUCollection : TTObject.TTChildObjectCollection<SKRSICDOMORFOLOJIKODU>
        {
            public ChildSKRSICDOMORFOLOJIKODUCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSKRSICDOMORFOLOJIKODUCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSKRSICDOMORFOLOJIKODU_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? ObjectDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTDEFID"]);
                }
            }

            public Guid? CurrentStateDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENTSTATEDEFID"]);
                }
            }

            public Boolean? IsActive
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISACTIVE"]);
                    if (val == null)
                        return null;
                    return (Boolean)Convert.ChangeType(val, typeof(Boolean)); 
                }
            }

            public DateTime? LastUpdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LASTUPDATE"]);
                    if (val == null)
                        return null;
                    return (DateTime)Convert.ChangeType(val, typeof(DateTime)); 
                }
            }

            public bool? Default
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DEFAULT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSICDOMORFOLOJIKODU"].AllPropertyDefs["DEFAULT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string AKTIF
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AKTIF"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSICDOMORFOLOJIKODU"].AllPropertyDefs["AKTIF"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? OLUSTURULMATARIHI
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLUSTURULMATARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSICDOMORFOLOJIKODU"].AllPropertyDefs["OLUSTURULMATARIHI"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? GUNCELLENMETARIHI
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GUNCELLENMETARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSICDOMORFOLOJIKODU"].AllPropertyDefs["GUNCELLENMETARIHI"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? PASIFEALINMATARIHI
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PASIFEALINMATARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSICDOMORFOLOJIKODU"].AllPropertyDefs["PASIFEALINMATARIHI"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? GUNCELLEMETARIHI
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GUNCELLEMETARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSICDOMORFOLOJIKODU"].AllPropertyDefs["GUNCELLEMETARIHI"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string MORFOLOJIKOD
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MORFOLOJIKOD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSICDOMORFOLOJIKODU"].AllPropertyDefs["MORFOLOJIKOD"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string MORFOLOJIKODTANIM
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MORFOLOJIKODTANIM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSICDOMORFOLOJIKODU"].AllPropertyDefs["MORFOLOJIKODTANIM"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string MORFOLOJIKODACIKLAMA
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MORFOLOJIKODACIKLAMA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSICDOMORFOLOJIKODU"].AllPropertyDefs["MORFOLOJIKODACIKLAMA"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Morfoloji_Shadow
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MORFOLOJI_SHADOW"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSICDOMORFOLOJIKODU"].AllPropertyDefs["MORFOLOJI_SHADOW"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetSKRSICDOMORFOLOJIKODU_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSKRSICDOMORFOLOJIKODU_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSKRSICDOMORFOLOJIKODU_Class() : base() { }
        }

        public static BindingList<SKRSICDOMORFOLOJIKODU.GetSKRSICDOMORFOLOJIKODU_Class> GetSKRSICDOMORFOLOJIKODU(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSICDOMORFOLOJIKODU"].QueryDefs["GetSKRSICDOMORFOLOJIKODU"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSICDOMORFOLOJIKODU.GetSKRSICDOMORFOLOJIKODU_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SKRSICDOMORFOLOJIKODU.GetSKRSICDOMORFOLOJIKODU_Class> GetSKRSICDOMORFOLOJIKODU(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSICDOMORFOLOJIKODU"].QueryDefs["GetSKRSICDOMORFOLOJIKODU"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSICDOMORFOLOJIKODU.GetSKRSICDOMORFOLOJIKODU_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public string MORFOLOJIKOD
        {
            get { return (string)this["MORFOLOJIKOD"]; }
            set { this["MORFOLOJIKOD"] = value; }
        }

        public string MORFOLOJIKODTANIM
        {
            get { return (string)this["MORFOLOJIKODTANIM"]; }
            set { this["MORFOLOJIKODTANIM"] = value; }
        }

        public string MORFOLOJIKODACIKLAMA
        {
            get { return (string)this["MORFOLOJIKODACIKLAMA"]; }
            set { this["MORFOLOJIKODACIKLAMA"] = value; }
        }

        public string Morfoloji_Shadow
        {
            get { return (string)this["MORFOLOJI_SHADOW"]; }
        }

        protected SKRSICDOMORFOLOJIKODU(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SKRSICDOMORFOLOJIKODU(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SKRSICDOMORFOLOJIKODU(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SKRSICDOMORFOLOJIKODU(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SKRSICDOMORFOLOJIKODU(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SKRSICDOMORFOLOJIKODU", dataRow) { }
        protected SKRSICDOMORFOLOJIKODU(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SKRSICDOMORFOLOJIKODU", dataRow, isImported) { }
        public SKRSICDOMORFOLOJIKODU(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SKRSICDOMORFOLOJIKODU(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SKRSICDOMORFOLOJIKODU() : base() { }

    }
}
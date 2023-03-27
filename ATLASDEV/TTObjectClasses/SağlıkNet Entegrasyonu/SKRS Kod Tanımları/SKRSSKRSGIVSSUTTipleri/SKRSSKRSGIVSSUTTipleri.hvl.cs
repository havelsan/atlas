
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SKRSSKRSGIVSSUTTipleri")] 

    /// <summary>
    /// 10d948ad-e71b-4454-8593-8d0535864e57
    /// </summary>
    public  partial class SKRSSKRSGIVSSUTTipleri : BaseSKRSDefinition
    {
        public class SKRSSKRSGIVSSUTTipleriList : TTObjectCollection<SKRSSKRSGIVSSUTTipleri> { }
                    
        public class ChildSKRSSKRSGIVSSUTTipleriCollection : TTObject.TTChildObjectCollection<SKRSSKRSGIVSSUTTipleri>
        {
            public ChildSKRSSKRSGIVSSUTTipleriCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSKRSSKRSGIVSSUTTipleriCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSKRSSKRSGIVSSUTTipleri_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSSKRSGIVSSUTTIPLERI"].AllPropertyDefs["DEFAULT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSSKRSGIVSSUTTIPLERI"].AllPropertyDefs["AKTIF"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSSKRSGIVSSUTTIPLERI"].AllPropertyDefs["OLUSTURULMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSSKRSGIVSSUTTIPLERI"].AllPropertyDefs["GUNCELLENMETARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSSKRSGIVSSUTTIPLERI"].AllPropertyDefs["PASIFEALINMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSSKRSGIVSSUTTIPLERI"].AllPropertyDefs["GUNCELLEMETARIHI"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string KODTIPIADI
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KODTIPIADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSSKRSGIVSSUTTIPLERI"].AllPropertyDefs["KODTIPIADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ADI
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSSKRSGIVSSUTTIPLERI"].AllPropertyDefs["ADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string KODU
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSSKRSGIVSSUTTIPLERI"].AllPropertyDefs["KODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetSKRSSKRSGIVSSUTTipleri_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSKRSSKRSGIVSSUTTipleri_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSKRSSKRSGIVSSUTTipleri_Class() : base() { }
        }

        public static BindingList<SKRSSKRSGIVSSUTTipleri.GetSKRSSKRSGIVSSUTTipleri_Class> GetSKRSSKRSGIVSSUTTipleri(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSSKRSGIVSSUTTIPLERI"].QueryDefs["GetSKRSSKRSGIVSSUTTipleri"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSSKRSGIVSSUTTipleri.GetSKRSSKRSGIVSSUTTipleri_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SKRSSKRSGIVSSUTTipleri.GetSKRSSKRSGIVSSUTTipleri_Class> GetSKRSSKRSGIVSSUTTipleri(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSSKRSGIVSSUTTIPLERI"].QueryDefs["GetSKRSSKRSGIVSSUTTipleri"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSSKRSGIVSSUTTipleri.GetSKRSSKRSGIVSSUTTipleri_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public string KODTIPIADI
        {
            get { return (string)this["KODTIPIADI"]; }
            set { this["KODTIPIADI"] = value; }
        }

        public string ADI
        {
            get { return (string)this["ADI"]; }
            set { this["ADI"] = value; }
        }

        public string KODU
        {
            get { return (string)this["KODU"]; }
            set { this["KODU"] = value; }
        }

        protected SKRSSKRSGIVSSUTTipleri(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SKRSSKRSGIVSSUTTipleri(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SKRSSKRSGIVSSUTTipleri(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SKRSSKRSGIVSSUTTipleri(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SKRSSKRSGIVSSUTTipleri(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SKRSSKRSGIVSSUTTIPLERI", dataRow) { }
        protected SKRSSKRSGIVSSUTTipleri(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SKRSSKRSGIVSSUTTIPLERI", dataRow, isImported) { }
        public SKRSSKRSGIVSSUTTipleri(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SKRSSKRSGIVSSUTTipleri(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SKRSSKRSGIVSSUTTipleri() : base() { }

    }
}
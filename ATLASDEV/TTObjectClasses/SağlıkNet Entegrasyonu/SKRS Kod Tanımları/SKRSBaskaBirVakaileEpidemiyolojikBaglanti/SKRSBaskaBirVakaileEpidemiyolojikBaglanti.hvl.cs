
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SKRSBaskaBirVakaileEpidemiyolojikBaglanti")] 

    /// <summary>
    /// 307be87b-3190-42f6-b8cb-a4b1306f267e
    /// </summary>
    public  partial class SKRSBaskaBirVakaileEpidemiyolojikBaglanti : BaseSKRSCommonDef
    {
        public class SKRSBaskaBirVakaileEpidemiyolojikBaglantiList : TTObjectCollection<SKRSBaskaBirVakaileEpidemiyolojikBaglanti> { }
                    
        public class ChildSKRSBaskaBirVakaileEpidemiyolojikBaglantiCollection : TTObject.TTChildObjectCollection<SKRSBaskaBirVakaileEpidemiyolojikBaglanti>
        {
            public ChildSKRSBaskaBirVakaileEpidemiyolojikBaglantiCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSKRSBaskaBirVakaileEpidemiyolojikBaglantiCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSKRSBaskaBirVakaileEpidemiyolojikBaglanti_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSBASKABIRVAKAILEEPIDEMIYOLOJIKBAGLANTI"].AllPropertyDefs["DEFAULT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSBASKABIRVAKAILEEPIDEMIYOLOJIKBAGLANTI"].AllPropertyDefs["AKTIF"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSBASKABIRVAKAILEEPIDEMIYOLOJIKBAGLANTI"].AllPropertyDefs["OLUSTURULMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSBASKABIRVAKAILEEPIDEMIYOLOJIKBAGLANTI"].AllPropertyDefs["GUNCELLENMETARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSBASKABIRVAKAILEEPIDEMIYOLOJIKBAGLANTI"].AllPropertyDefs["PASIFEALINMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSBASKABIRVAKAILEEPIDEMIYOLOJIKBAGLANTI"].AllPropertyDefs["GUNCELLEMETARIHI"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string ADI
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSBASKABIRVAKAILEEPIDEMIYOLOJIKBAGLANTI"].AllPropertyDefs["ADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string KODTIPIADI
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KODTIPIADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSBASKABIRVAKAILEEPIDEMIYOLOJIKBAGLANTI"].AllPropertyDefs["KODTIPIADI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSBASKABIRVAKAILEEPIDEMIYOLOJIKBAGLANTI"].AllPropertyDefs["KODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? OLUSTURULMATARIHI1
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLUSTURULMATARIHI1"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSBASKABIRVAKAILEEPIDEMIYOLOJIKBAGLANTI"].AllPropertyDefs["OLUSTURULMATARIHI1"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? GUNCELLENMETARIHI1
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GUNCELLENMETARIHI1"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSBASKABIRVAKAILEEPIDEMIYOLOJIKBAGLANTI"].AllPropertyDefs["GUNCELLENMETARIHI1"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetSKRSBaskaBirVakaileEpidemiyolojikBaglanti_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSKRSBaskaBirVakaileEpidemiyolojikBaglanti_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSKRSBaskaBirVakaileEpidemiyolojikBaglanti_Class() : base() { }
        }

        public static BindingList<SKRSBaskaBirVakaileEpidemiyolojikBaglanti.GetSKRSBaskaBirVakaileEpidemiyolojikBaglanti_Class> GetSKRSBaskaBirVakaileEpidemiyolojikBaglanti(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSBASKABIRVAKAILEEPIDEMIYOLOJIKBAGLANTI"].QueryDefs["GetSKRSBaskaBirVakaileEpidemiyolojikBaglanti"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSBaskaBirVakaileEpidemiyolojikBaglanti.GetSKRSBaskaBirVakaileEpidemiyolojikBaglanti_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SKRSBaskaBirVakaileEpidemiyolojikBaglanti.GetSKRSBaskaBirVakaileEpidemiyolojikBaglanti_Class> GetSKRSBaskaBirVakaileEpidemiyolojikBaglanti(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSBASKABIRVAKAILEEPIDEMIYOLOJIKBAGLANTI"].QueryDefs["GetSKRSBaskaBirVakaileEpidemiyolojikBaglanti"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSBaskaBirVakaileEpidemiyolojikBaglanti.GetSKRSBaskaBirVakaileEpidemiyolojikBaglanti_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        protected SKRSBaskaBirVakaileEpidemiyolojikBaglanti(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SKRSBaskaBirVakaileEpidemiyolojikBaglanti(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SKRSBaskaBirVakaileEpidemiyolojikBaglanti(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SKRSBaskaBirVakaileEpidemiyolojikBaglanti(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SKRSBaskaBirVakaileEpidemiyolojikBaglanti(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SKRSBASKABIRVAKAILEEPIDEMIYOLOJIKBAGLANTI", dataRow) { }
        protected SKRSBaskaBirVakaileEpidemiyolojikBaglanti(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SKRSBASKABIRVAKAILEEPIDEMIYOLOJIKBAGLANTI", dataRow, isImported) { }
        public SKRSBaskaBirVakaileEpidemiyolojikBaglanti(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SKRSBaskaBirVakaileEpidemiyolojikBaglanti(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SKRSBaskaBirVakaileEpidemiyolojikBaglanti() : base() { }

    }
}
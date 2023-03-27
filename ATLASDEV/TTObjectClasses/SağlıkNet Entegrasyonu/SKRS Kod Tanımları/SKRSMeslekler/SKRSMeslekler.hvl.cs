
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SKRSMeslekler")] 

    /// <summary>
    /// c3eaf407-b302-5fdd-e043-14031b0a2484
    /// </summary>
    public  partial class SKRSMeslekler : BaseSKRSDefinition
    {
        public class SKRSMesleklerList : TTObjectCollection<SKRSMeslekler> { }
                    
        public class ChildSKRSMesleklerCollection : TTObject.TTChildObjectCollection<SKRSMeslekler>
        {
            public ChildSKRSMesleklerCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSKRSMesleklerCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSKRSMeslekler_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSMESLEKLER"].AllPropertyDefs["DEFAULT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSMESLEKLER"].AllPropertyDefs["AKTIF"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSMESLEKLER"].AllPropertyDefs["OLUSTURULMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSMESLEKLER"].AllPropertyDefs["GUNCELLENMETARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSMESLEKLER"].AllPropertyDefs["PASIFEALINMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSMESLEKLER"].AllPropertyDefs["GUNCELLEMETARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSMESLEKLER"].AllPropertyDefs["ADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? KODU
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSMESLEKLER"].AllPropertyDefs["KODU"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? ISKURKODU
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISKURKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSMESLEKLER"].AllPropertyDefs["ISKURKODU"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? IDUSTNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["IDUSTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSMESLEKLER"].AllPropertyDefs["IDUSTNO"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public DateTime? OLUSTURULMATARIHI1
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLUSTURULMATARIHI1"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSMESLEKLER"].AllPropertyDefs["OLUSTURULMATARIHI1"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string GUNCELLENMETARIHI1
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GUNCELLENMETARIHI1"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSMESLEKLER"].AllPropertyDefs["GUNCELLENMETARIHI1"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetSKRSMeslekler_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSKRSMeslekler_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSKRSMeslekler_Class() : base() { }
        }

        public static BindingList<SKRSMeslekler.GetSKRSMeslekler_Class> GetSKRSMeslekler(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSMESLEKLER"].QueryDefs["GetSKRSMeslekler"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSMeslekler.GetSKRSMeslekler_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SKRSMeslekler.GetSKRSMeslekler_Class> GetSKRSMeslekler(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSMESLEKLER"].QueryDefs["GetSKRSMeslekler"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSMeslekler.GetSKRSMeslekler_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SKRSMeslekler> GetBySKRSKodu(TTObjectContext objectContext, int SKRSKodu)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSMESLEKLER"].QueryDefs["GetBySKRSKodu"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SKRSKODU", SKRSKodu);

            return ((ITTQuery)objectContext).QueryObjects<SKRSMeslekler>(queryDef, paramList);
        }

        public string ADI
        {
            get { return (string)this["ADI"]; }
            set { this["ADI"] = value; }
        }

        public int? KODU
        {
            get { return (int?)this["KODU"]; }
            set { this["KODU"] = value; }
        }

        public int? ISKURKODU
        {
            get { return (int?)this["ISKURKODU"]; }
            set { this["ISKURKODU"] = value; }
        }

        public int? IDUSTNO
        {
            get { return (int?)this["IDUSTNO"]; }
            set { this["IDUSTNO"] = value; }
        }

        public DateTime? OLUSTURULMATARIHI1
        {
            get { return (DateTime?)this["OLUSTURULMATARIHI1"]; }
            set { this["OLUSTURULMATARIHI1"] = value; }
        }

        public string GUNCELLENMETARIHI1
        {
            get { return (string)this["GUNCELLENMETARIHI1"]; }
            set { this["GUNCELLENMETARIHI1"] = value; }
        }

        protected SKRSMeslekler(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SKRSMeslekler(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SKRSMeslekler(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SKRSMeslekler(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SKRSMeslekler(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SKRSMESLEKLER", dataRow) { }
        protected SKRSMeslekler(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SKRSMESLEKLER", dataRow, isImported) { }
        public SKRSMeslekler(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SKRSMeslekler(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SKRSMeslekler() : base() { }

    }
}
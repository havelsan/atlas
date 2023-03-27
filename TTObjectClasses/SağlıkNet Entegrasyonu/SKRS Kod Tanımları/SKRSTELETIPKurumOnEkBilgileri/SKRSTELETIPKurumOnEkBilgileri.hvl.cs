
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SKRSTELETIPKurumOnEkBilgileri")] 

    /// <summary>
    /// eeb835d8-18ab-4f86-9720-32be86df1eff
    /// </summary>
    public  partial class SKRSTELETIPKurumOnEkBilgileri : BaseSKRSDefinition
    {
        public class SKRSTELETIPKurumOnEkBilgileriList : TTObjectCollection<SKRSTELETIPKurumOnEkBilgileri> { }
                    
        public class ChildSKRSTELETIPKurumOnEkBilgileriCollection : TTObject.TTChildObjectCollection<SKRSTELETIPKurumOnEkBilgileri>
        {
            public ChildSKRSTELETIPKurumOnEkBilgileriCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSKRSTELETIPKurumOnEkBilgileriCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSKRSTELETIPKurumOnEkBilgileri_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSTELETIPKURUMONEKBILGILERI"].AllPropertyDefs["DEFAULT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSTELETIPKURUMONEKBILGILERI"].AllPropertyDefs["AKTIF"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSTELETIPKURUMONEKBILGILERI"].AllPropertyDefs["OLUSTURULMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSTELETIPKURUMONEKBILGILERI"].AllPropertyDefs["GUNCELLENMETARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSTELETIPKURUMONEKBILGILERI"].AllPropertyDefs["PASIFEALINMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSTELETIPKURUMONEKBILGILERI"].AllPropertyDefs["GUNCELLEMETARIHI"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public int? KURUMKODU
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KURUMKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSTELETIPKURUMONEKBILGILERI"].AllPropertyDefs["KURUMKODU"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string KURUMADI
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KURUMADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSTELETIPKURUMONEKBILGILERI"].AllPropertyDefs["KURUMADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string TELETIPONEK
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TELETIPONEK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSTELETIPKURUMONEKBILGILERI"].AllPropertyDefs["TELETIPONEK"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? GUNCELLENMETARIHI1
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GUNCELLENMETARIHI1"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSTELETIPKURUMONEKBILGILERI"].AllPropertyDefs["GUNCELLENMETARIHI1"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetSKRSTELETIPKurumOnEkBilgileri_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSKRSTELETIPKurumOnEkBilgileri_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSKRSTELETIPKurumOnEkBilgileri_Class() : base() { }
        }

        public static BindingList<SKRSTELETIPKurumOnEkBilgileri.GetSKRSTELETIPKurumOnEkBilgileri_Class> GetSKRSTELETIPKurumOnEkBilgileri(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSTELETIPKURUMONEKBILGILERI"].QueryDefs["GetSKRSTELETIPKurumOnEkBilgileri"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSTELETIPKurumOnEkBilgileri.GetSKRSTELETIPKurumOnEkBilgileri_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SKRSTELETIPKurumOnEkBilgileri.GetSKRSTELETIPKurumOnEkBilgileri_Class> GetSKRSTELETIPKurumOnEkBilgileri(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSTELETIPKURUMONEKBILGILERI"].QueryDefs["GetSKRSTELETIPKurumOnEkBilgileri"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSTELETIPKurumOnEkBilgileri.GetSKRSTELETIPKurumOnEkBilgileri_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public int? KURUMKODU
        {
            get { return (int?)this["KURUMKODU"]; }
            set { this["KURUMKODU"] = value; }
        }

        public string KURUMADI
        {
            get { return (string)this["KURUMADI"]; }
            set { this["KURUMADI"] = value; }
        }

        public string TELETIPONEK
        {
            get { return (string)this["TELETIPONEK"]; }
            set { this["TELETIPONEK"] = value; }
        }

        public DateTime? GUNCELLENMETARIHI1
        {
            get { return (DateTime?)this["GUNCELLENMETARIHI1"]; }
            set { this["GUNCELLENMETARIHI1"] = value; }
        }

        protected SKRSTELETIPKurumOnEkBilgileri(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SKRSTELETIPKurumOnEkBilgileri(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SKRSTELETIPKurumOnEkBilgileri(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SKRSTELETIPKurumOnEkBilgileri(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SKRSTELETIPKurumOnEkBilgileri(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SKRSTELETIPKURUMONEKBILGILERI", dataRow) { }
        protected SKRSTELETIPKurumOnEkBilgileri(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SKRSTELETIPKURUMONEKBILGILERI", dataRow, isImported) { }
        public SKRSTELETIPKurumOnEkBilgileri(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SKRSTELETIPKurumOnEkBilgileri(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SKRSTELETIPKurumOnEkBilgileri() : base() { }

    }
}

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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SKRSTibbiIslemPuanBilgisi")] 

    /// <summary>
    /// 77ff0441-e162-4e7f-8719-ebf34bb5c345
    /// </summary>
    public  partial class SKRSTibbiIslemPuanBilgisi : BaseSKRSDefinition
    {
        public class SKRSTibbiIslemPuanBilgisiList : TTObjectCollection<SKRSTibbiIslemPuanBilgisi> { }
                    
        public class ChildSKRSTibbiIslemPuanBilgisiCollection : TTObject.TTChildObjectCollection<SKRSTibbiIslemPuanBilgisi>
        {
            public ChildSKRSTibbiIslemPuanBilgisiCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSKRSTibbiIslemPuanBilgisiCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSKRSTibbiIslemPuanBilgisi_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSTIBBIISLEMPUANBILGISI"].AllPropertyDefs["DEFAULT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSTIBBIISLEMPUANBILGISI"].AllPropertyDefs["AKTIF"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSTIBBIISLEMPUANBILGISI"].AllPropertyDefs["OLUSTURULMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSTIBBIISLEMPUANBILGISI"].AllPropertyDefs["GUNCELLENMETARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSTIBBIISLEMPUANBILGISI"].AllPropertyDefs["PASIFEALINMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSTIBBIISLEMPUANBILGISI"].AllPropertyDefs["GUNCELLEMETARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSTIBBIISLEMPUANBILGISI"].AllPropertyDefs["ADI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSTIBBIISLEMPUANBILGISI"].AllPropertyDefs["KODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ACIKLAMA
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACIKLAMA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSTIBBIISLEMPUANBILGISI"].AllPropertyDefs["ACIKLAMA"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? ISLEMPUANI
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISLEMPUANI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSTIBBIISLEMPUANBILGISI"].AllPropertyDefs["ISLEMPUANI"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string AMELIYATGRUPLARI
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMELIYATGRUPLARI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSTIBBIISLEMPUANBILGISI"].AllPropertyDefs["AMELIYATGRUPLARI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSTIBBIISLEMPUANBILGISI"].AllPropertyDefs["OLUSTURULMATARIHI1"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSTIBBIISLEMPUANBILGISI"].AllPropertyDefs["GUNCELLENMETARIHI1"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string OZELLIKLIISLEM
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OZELLIKLIISLEM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSTIBBIISLEMPUANBILGISI"].AllPropertyDefs["OZELLIKLIISLEM"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetSKRSTibbiIslemPuanBilgisi_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSKRSTibbiIslemPuanBilgisi_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSKRSTibbiIslemPuanBilgisi_Class() : base() { }
        }

        [Serializable] 

        public partial class GetSKRSTibbiIslemPuanBilgisiByKodu_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSTIBBIISLEMPUANBILGISI"].AllPropertyDefs["DEFAULT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSTIBBIISLEMPUANBILGISI"].AllPropertyDefs["AKTIF"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSTIBBIISLEMPUANBILGISI"].AllPropertyDefs["OLUSTURULMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSTIBBIISLEMPUANBILGISI"].AllPropertyDefs["GUNCELLENMETARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSTIBBIISLEMPUANBILGISI"].AllPropertyDefs["PASIFEALINMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSTIBBIISLEMPUANBILGISI"].AllPropertyDefs["GUNCELLEMETARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSTIBBIISLEMPUANBILGISI"].AllPropertyDefs["ADI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSTIBBIISLEMPUANBILGISI"].AllPropertyDefs["KODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ACIKLAMA
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACIKLAMA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSTIBBIISLEMPUANBILGISI"].AllPropertyDefs["ACIKLAMA"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? ISLEMPUANI
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISLEMPUANI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSTIBBIISLEMPUANBILGISI"].AllPropertyDefs["ISLEMPUANI"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string AMELIYATGRUPLARI
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMELIYATGRUPLARI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSTIBBIISLEMPUANBILGISI"].AllPropertyDefs["AMELIYATGRUPLARI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSTIBBIISLEMPUANBILGISI"].AllPropertyDefs["OLUSTURULMATARIHI1"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSTIBBIISLEMPUANBILGISI"].AllPropertyDefs["GUNCELLENMETARIHI1"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string OZELLIKLIISLEM
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OZELLIKLIISLEM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSTIBBIISLEMPUANBILGISI"].AllPropertyDefs["OZELLIKLIISLEM"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetSKRSTibbiIslemPuanBilgisiByKodu_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSKRSTibbiIslemPuanBilgisiByKodu_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSKRSTibbiIslemPuanBilgisiByKodu_Class() : base() { }
        }

        public static BindingList<SKRSTibbiIslemPuanBilgisi.GetSKRSTibbiIslemPuanBilgisi_Class> GetSKRSTibbiIslemPuanBilgisi(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSTIBBIISLEMPUANBILGISI"].QueryDefs["GetSKRSTibbiIslemPuanBilgisi"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSTibbiIslemPuanBilgisi.GetSKRSTibbiIslemPuanBilgisi_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SKRSTibbiIslemPuanBilgisi.GetSKRSTibbiIslemPuanBilgisi_Class> GetSKRSTibbiIslemPuanBilgisi(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSTIBBIISLEMPUANBILGISI"].QueryDefs["GetSKRSTibbiIslemPuanBilgisi"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSTibbiIslemPuanBilgisi.GetSKRSTibbiIslemPuanBilgisi_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SKRSTibbiIslemPuanBilgisi.GetSKRSTibbiIslemPuanBilgisiByKodu_Class> GetSKRSTibbiIslemPuanBilgisiByKodu(string KODU, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSTIBBIISLEMPUANBILGISI"].QueryDefs["GetSKRSTibbiIslemPuanBilgisiByKodu"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("KODU", KODU);

            return TTReportNqlObject.QueryObjects<SKRSTibbiIslemPuanBilgisi.GetSKRSTibbiIslemPuanBilgisiByKodu_Class>(queryDef, paramList, pi);
        }

        public static BindingList<SKRSTibbiIslemPuanBilgisi.GetSKRSTibbiIslemPuanBilgisiByKodu_Class> GetSKRSTibbiIslemPuanBilgisiByKodu(TTObjectContext objectContext, string KODU, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSTIBBIISLEMPUANBILGISI"].QueryDefs["GetSKRSTibbiIslemPuanBilgisiByKodu"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("KODU", KODU);

            return TTReportNqlObject.QueryObjects<SKRSTibbiIslemPuanBilgisi.GetSKRSTibbiIslemPuanBilgisiByKodu_Class>(objectContext, queryDef, paramList, pi);
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

        public string ACIKLAMA
        {
            get { return (string)this["ACIKLAMA"]; }
            set { this["ACIKLAMA"] = value; }
        }

        public int? ISLEMPUANI
        {
            get { return (int?)this["ISLEMPUANI"]; }
            set { this["ISLEMPUANI"] = value; }
        }

        public string AMELIYATGRUPLARI
        {
            get { return (string)this["AMELIYATGRUPLARI"]; }
            set { this["AMELIYATGRUPLARI"] = value; }
        }

        public DateTime? OLUSTURULMATARIHI1
        {
            get { return (DateTime?)this["OLUSTURULMATARIHI1"]; }
            set { this["OLUSTURULMATARIHI1"] = value; }
        }

        public DateTime? GUNCELLENMETARIHI1
        {
            get { return (DateTime?)this["GUNCELLENMETARIHI1"]; }
            set { this["GUNCELLENMETARIHI1"] = value; }
        }

        public string OZELLIKLIISLEM
        {
            get { return (string)this["OZELLIKLIISLEM"]; }
            set { this["OZELLIKLIISLEM"] = value; }
        }

        protected SKRSTibbiIslemPuanBilgisi(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SKRSTibbiIslemPuanBilgisi(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SKRSTibbiIslemPuanBilgisi(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SKRSTibbiIslemPuanBilgisi(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SKRSTibbiIslemPuanBilgisi(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SKRSTIBBIISLEMPUANBILGISI", dataRow) { }
        protected SKRSTibbiIslemPuanBilgisi(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SKRSTIBBIISLEMPUANBILGISI", dataRow, isImported) { }
        public SKRSTibbiIslemPuanBilgisi(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SKRSTibbiIslemPuanBilgisi(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SKRSTibbiIslemPuanBilgisi() : base() { }

    }
}
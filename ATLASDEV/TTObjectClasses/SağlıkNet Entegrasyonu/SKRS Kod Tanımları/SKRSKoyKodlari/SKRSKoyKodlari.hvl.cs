
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SKRSKoyKodlari")] 

    /// <summary>
    /// 186585bf-70b6-4db4-805e-22177714d12e
    /// </summary>
    public  partial class SKRSKoyKodlari : BaseSKRSDefinition
    {
        public class SKRSKoyKodlariList : TTObjectCollection<SKRSKoyKodlari> { }
                    
        public class ChildSKRSKoyKodlariCollection : TTObject.TTChildObjectCollection<SKRSKoyKodlari>
        {
            public ChildSKRSKoyKodlariCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSKRSKoyKodlariCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSKRSKoyKodlari_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSKOYKODLARI"].AllPropertyDefs["DEFAULT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSKOYKODLARI"].AllPropertyDefs["AKTIF"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSKOYKODLARI"].AllPropertyDefs["OLUSTURULMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSKOYKODLARI"].AllPropertyDefs["GUNCELLENMETARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSKOYKODLARI"].AllPropertyDefs["PASIFEALINMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSKOYKODLARI"].AllPropertyDefs["GUNCELLEMETARIHI"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public int? BUCAKKODU
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BUCAKKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSKOYKODLARI"].AllPropertyDefs["BUCAKKODU"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string ADI
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSKOYKODLARI"].AllPropertyDefs["ADI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSKOYKODLARI"].AllPropertyDefs["KODU"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? SIRANO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SIRANO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSKOYKODLARI"].AllPropertyDefs["SIRANO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSKOYKODLARI"].AllPropertyDefs["OLUSTURULMATARIHI1"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSKOYKODLARI"].AllPropertyDefs["GUNCELLENMETARIHI1"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetSKRSKoyKodlari_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSKRSKoyKodlari_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSKRSKoyKodlari_Class() : base() { }
        }

        public static BindingList<SKRSKoyKodlari.GetSKRSKoyKodlari_Class> GetSKRSKoyKodlari(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSKOYKODLARI"].QueryDefs["GetSKRSKoyKodlari"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSKoyKodlari.GetSKRSKoyKodlari_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SKRSKoyKodlari.GetSKRSKoyKodlari_Class> GetSKRSKoyKodlari(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSKOYKODLARI"].QueryDefs["GetSKRSKoyKodlari"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSKoyKodlari.GetSKRSKoyKodlari_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SKRSKoyKodlari> GetSKRSKoyKodlariByKodu(TTObjectContext objectContext, int KODU)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSKOYKODLARI"].QueryDefs["GetSKRSKoyKodlariByKodu"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("KODU", KODU);

            return ((ITTQuery)objectContext).QueryObjects<SKRSKoyKodlari>(queryDef, paramList);
        }

        public int? BUCAKKODU
        {
            get { return (int?)this["BUCAKKODU"]; }
            set { this["BUCAKKODU"] = value; }
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

        public int? SIRANO
        {
            get { return (int?)this["SIRANO"]; }
            set { this["SIRANO"] = value; }
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

        public SKRSBucakKodlari SKRSBucakKodlari
        {
            get { return (SKRSBucakKodlari)((ITTObject)this).GetParent("SKRSBUCAKKODLARI"); }
            set { this["SKRSBUCAKKODLARI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateSKRSMahalleKodlariCollection()
        {
            _SKRSMahalleKodlari = new SKRSMahalleKodlari.ChildSKRSMahalleKodlariCollection(this, new Guid("e7faf97c-d3f5-49d8-b2fe-421cce07d8b0"));
            ((ITTChildObjectCollection)_SKRSMahalleKodlari).GetChildren();
        }

        protected SKRSMahalleKodlari.ChildSKRSMahalleKodlariCollection _SKRSMahalleKodlari = null;
        public SKRSMahalleKodlari.ChildSKRSMahalleKodlariCollection SKRSMahalleKodlari
        {
            get
            {
                if (_SKRSMahalleKodlari == null)
                    CreateSKRSMahalleKodlariCollection();
                return _SKRSMahalleKodlari;
            }
        }

        protected SKRSKoyKodlari(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SKRSKoyKodlari(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SKRSKoyKodlari(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SKRSKoyKodlari(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SKRSKoyKodlari(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SKRSKOYKODLARI", dataRow) { }
        protected SKRSKoyKodlari(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SKRSKOYKODLARI", dataRow, isImported) { }
        public SKRSKoyKodlari(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SKRSKoyKodlari(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SKRSKoyKodlari() : base() { }

    }
}
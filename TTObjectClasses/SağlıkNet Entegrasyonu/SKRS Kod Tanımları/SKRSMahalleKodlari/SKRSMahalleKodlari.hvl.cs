
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SKRSMahalleKodlari")] 

    /// <summary>
    /// 8462635e-5253-4e7b-8010-6020fd1501df
    /// </summary>
    public  partial class SKRSMahalleKodlari : BaseSKRSDefinition
    {
        public class SKRSMahalleKodlariList : TTObjectCollection<SKRSMahalleKodlari> { }
                    
        public class ChildSKRSMahalleKodlariCollection : TTObject.TTChildObjectCollection<SKRSMahalleKodlari>
        {
            public ChildSKRSMahalleKodlariCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSKRSMahalleKodlariCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSKRSMahalleKodlari_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSMAHALLEKODLARI"].AllPropertyDefs["DEFAULT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSMAHALLEKODLARI"].AllPropertyDefs["AKTIF"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSMAHALLEKODLARI"].AllPropertyDefs["OLUSTURULMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSMAHALLEKODLARI"].AllPropertyDefs["GUNCELLENMETARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSMAHALLEKODLARI"].AllPropertyDefs["PASIFEALINMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSMAHALLEKODLARI"].AllPropertyDefs["GUNCELLEMETARIHI"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public int? KOYKODU
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KOYKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSMAHALLEKODLARI"].AllPropertyDefs["KOYKODU"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSMAHALLEKODLARI"].AllPropertyDefs["ADI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSMAHALLEKODLARI"].AllPropertyDefs["KODU"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? TANITIMKODU
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TANITIMKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSMAHALLEKODLARI"].AllPropertyDefs["TANITIMKODU"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? TIPI
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TIPI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSMAHALLEKODLARI"].AllPropertyDefs["TIPI"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? YETKILIIDAREKODU
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["YETKILIIDAREKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSMAHALLEKODLARI"].AllPropertyDefs["YETKILIIDAREKODU"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSMAHALLEKODLARI"].AllPropertyDefs["OLUSTURULMATARIHI1"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSMAHALLEKODLARI"].AllPropertyDefs["GUNCELLENMETARIHI1"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetSKRSMahalleKodlari_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSKRSMahalleKodlari_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSKRSMahalleKodlari_Class() : base() { }
        }

        public static BindingList<SKRSMahalleKodlari.GetSKRSMahalleKodlari_Class> GetSKRSMahalleKodlari(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSMAHALLEKODLARI"].QueryDefs["GetSKRSMahalleKodlari"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSMahalleKodlari.GetSKRSMahalleKodlari_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SKRSMahalleKodlari.GetSKRSMahalleKodlari_Class> GetSKRSMahalleKodlari(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSMAHALLEKODLARI"].QueryDefs["GetSKRSMahalleKodlari"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSMahalleKodlari.GetSKRSMahalleKodlari_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SKRSMahalleKodlari> GetSKRSMahalleKodlariByKodu(TTObjectContext objectContext, int KODU)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSMAHALLEKODLARI"].QueryDefs["GetSKRSMahalleKodlariByKodu"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("KODU", KODU);

            return ((ITTQuery)objectContext).QueryObjects<SKRSMahalleKodlari>(queryDef, paramList);
        }

        public int? KOYKODU
        {
            get { return (int?)this["KOYKODU"]; }
            set { this["KOYKODU"] = value; }
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

        public int? TANITIMKODU
        {
            get { return (int?)this["TANITIMKODU"]; }
            set { this["TANITIMKODU"] = value; }
        }

        public int? TIPI
        {
            get { return (int?)this["TIPI"]; }
            set { this["TIPI"] = value; }
        }

        public int? YETKILIIDAREKODU
        {
            get { return (int?)this["YETKILIIDAREKODU"]; }
            set { this["YETKILIIDAREKODU"] = value; }
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

        public SKRSKoyKodlari SKRSKoyKodlari
        {
            get { return (SKRSKoyKodlari)((ITTObject)this).GetParent("SKRSKOYKODLARI"); }
            set { this["SKRSKOYKODLARI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected SKRSMahalleKodlari(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SKRSMahalleKodlari(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SKRSMahalleKodlari(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SKRSMahalleKodlari(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SKRSMahalleKodlari(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SKRSMAHALLEKODLARI", dataRow) { }
        protected SKRSMahalleKodlari(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SKRSMAHALLEKODLARI", dataRow, isImported) { }
        public SKRSMahalleKodlari(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SKRSMahalleKodlari(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SKRSMahalleKodlari() : base() { }

    }
}
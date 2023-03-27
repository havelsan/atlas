
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SKRSOlayAfetBilgisi")] 

    /// <summary>
    /// 6fedbc09-c34f-4189-88b7-6c6f4798fcfc
    /// </summary>
    public  partial class SKRSOlayAfetBilgisi : BaseSKRSDefinition
    {
        public class SKRSOlayAfetBilgisiList : TTObjectCollection<SKRSOlayAfetBilgisi> { }
                    
        public class ChildSKRSOlayAfetBilgisiCollection : TTObject.TTChildObjectCollection<SKRSOlayAfetBilgisi>
        {
            public ChildSKRSOlayAfetBilgisiCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSKRSOlayAfetBilgisiCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSKRSOlayAfetBilgisi_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSOLAYAFETBILGISI"].AllPropertyDefs["DEFAULT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSOLAYAFETBILGISI"].AllPropertyDefs["AKTIF"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSOLAYAFETBILGISI"].AllPropertyDefs["OLUSTURULMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSOLAYAFETBILGISI"].AllPropertyDefs["GUNCELLENMETARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSOLAYAFETBILGISI"].AllPropertyDefs["PASIFEALINMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSOLAYAFETBILGISI"].AllPropertyDefs["GUNCELLEMETARIHI"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public int? OLAYNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLAYNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSOLAYAFETBILGISI"].AllPropertyDefs["OLAYNO"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string OLAYISMI
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLAYISMI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSOLAYAFETBILGISI"].AllPropertyDefs["OLAYISMI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? OLAYILKODU
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLAYILKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSOLAYAFETBILGISI"].AllPropertyDefs["OLAYILKODU"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string LOKASYON
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LOKASYON"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSOLAYAFETBILGISI"].AllPropertyDefs["LOKASYON"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string TARIHSAAT
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TARIHSAAT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSOLAYAFETBILGISI"].AllPropertyDefs["TARIHSAAT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string OLAYTIPI
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLAYTIPI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSOLAYAFETBILGISI"].AllPropertyDefs["OLAYTIPI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? BAGLIOLAYNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BAGLIOLAYNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSOLAYAFETBILGISI"].AllPropertyDefs["BAGLIOLAYNO"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string BILGINOTU
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BILGINOTU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSOLAYAFETBILGISI"].AllPropertyDefs["BILGINOTU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ETKILENENILLER
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ETKILENENILLER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSOLAYAFETBILGISI"].AllPropertyDefs["ETKILENENILLER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? KAPATILMATARIHI
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KAPATILMATARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSOLAYAFETBILGISI"].AllPropertyDefs["KAPATILMATARIHI"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetSKRSOlayAfetBilgisi_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSKRSOlayAfetBilgisi_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSKRSOlayAfetBilgisi_Class() : base() { }
        }

        public static BindingList<SKRSOlayAfetBilgisi.GetSKRSOlayAfetBilgisi_Class> GetSKRSOlayAfetBilgisi(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSOLAYAFETBILGISI"].QueryDefs["GetSKRSOlayAfetBilgisi"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSOlayAfetBilgisi.GetSKRSOlayAfetBilgisi_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SKRSOlayAfetBilgisi.GetSKRSOlayAfetBilgisi_Class> GetSKRSOlayAfetBilgisi(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSOLAYAFETBILGISI"].QueryDefs["GetSKRSOlayAfetBilgisi"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSOlayAfetBilgisi.GetSKRSOlayAfetBilgisi_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public int? OLAYNO
        {
            get { return (int?)this["OLAYNO"]; }
            set { this["OLAYNO"] = value; }
        }

        public string OLAYISMI
        {
            get { return (string)this["OLAYISMI"]; }
            set { this["OLAYISMI"] = value; }
        }

        public int? OLAYILKODU
        {
            get { return (int?)this["OLAYILKODU"]; }
            set { this["OLAYILKODU"] = value; }
        }

        public string LOKASYON
        {
            get { return (string)this["LOKASYON"]; }
            set { this["LOKASYON"] = value; }
        }

        public string TARIHSAAT
        {
            get { return (string)this["TARIHSAAT"]; }
            set { this["TARIHSAAT"] = value; }
        }

        public string OLAYTIPI
        {
            get { return (string)this["OLAYTIPI"]; }
            set { this["OLAYTIPI"] = value; }
        }

        public int? BAGLIOLAYNO
        {
            get { return (int?)this["BAGLIOLAYNO"]; }
            set { this["BAGLIOLAYNO"] = value; }
        }

        public string BILGINOTU
        {
            get { return (string)this["BILGINOTU"]; }
            set { this["BILGINOTU"] = value; }
        }

        public string ETKILENENILLER
        {
            get { return (string)this["ETKILENENILLER"]; }
            set { this["ETKILENENILLER"] = value; }
        }

        public DateTime? KAPATILMATARIHI
        {
            get { return (DateTime?)this["KAPATILMATARIHI"]; }
            set { this["KAPATILMATARIHI"] = value; }
        }

        protected SKRSOlayAfetBilgisi(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SKRSOlayAfetBilgisi(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SKRSOlayAfetBilgisi(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SKRSOlayAfetBilgisi(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SKRSOlayAfetBilgisi(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SKRSOLAYAFETBILGISI", dataRow) { }
        protected SKRSOlayAfetBilgisi(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SKRSOLAYAFETBILGISI", dataRow, isImported) { }
        public SKRSOlayAfetBilgisi(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SKRSOlayAfetBilgisi(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SKRSOlayAfetBilgisi() : base() { }

    }
}
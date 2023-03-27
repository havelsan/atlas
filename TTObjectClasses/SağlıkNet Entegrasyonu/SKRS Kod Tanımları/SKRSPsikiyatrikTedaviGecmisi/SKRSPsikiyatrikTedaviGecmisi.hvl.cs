
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SKRSPsikiyatrikTedaviGecmisi")] 

    /// <summary>
    /// 7cb4bcef-9998-4e0d-a442-8a83800bb614
    /// </summary>
    public  partial class SKRSPsikiyatrikTedaviGecmisi : BaseSKRSCommonDef
    {
        public class SKRSPsikiyatrikTedaviGecmisiList : TTObjectCollection<SKRSPsikiyatrikTedaviGecmisi> { }
                    
        public class ChildSKRSPsikiyatrikTedaviGecmisiCollection : TTObject.TTChildObjectCollection<SKRSPsikiyatrikTedaviGecmisi>
        {
            public ChildSKRSPsikiyatrikTedaviGecmisiCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSKRSPsikiyatrikTedaviGecmisiCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSKRSPsikiyatrikTedaviGecmisi_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSPSIKIYATRIKTEDAVIGECMISI"].AllPropertyDefs["DEFAULT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSPSIKIYATRIKTEDAVIGECMISI"].AllPropertyDefs["AKTIF"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSPSIKIYATRIKTEDAVIGECMISI"].AllPropertyDefs["OLUSTURULMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSPSIKIYATRIKTEDAVIGECMISI"].AllPropertyDefs["GUNCELLENMETARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSPSIKIYATRIKTEDAVIGECMISI"].AllPropertyDefs["PASIFEALINMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSPSIKIYATRIKTEDAVIGECMISI"].AllPropertyDefs["GUNCELLEMETARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSPSIKIYATRIKTEDAVIGECMISI"].AllPropertyDefs["ADI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSPSIKIYATRIKTEDAVIGECMISI"].AllPropertyDefs["KODTIPIADI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSPSIKIYATRIKTEDAVIGECMISI"].AllPropertyDefs["KODU"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSPSIKIYATRIKTEDAVIGECMISI"].AllPropertyDefs["OLUSTURULMATARIHI1"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSPSIKIYATRIKTEDAVIGECMISI"].AllPropertyDefs["GUNCELLENMETARIHI1"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetSKRSPsikiyatrikTedaviGecmisi_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSKRSPsikiyatrikTedaviGecmisi_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSKRSPsikiyatrikTedaviGecmisi_Class() : base() { }
        }

        public static BindingList<SKRSPsikiyatrikTedaviGecmisi.GetSKRSPsikiyatrikTedaviGecmisi_Class> GetSKRSPsikiyatrikTedaviGecmisi(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSPSIKIYATRIKTEDAVIGECMISI"].QueryDefs["GetSKRSPsikiyatrikTedaviGecmisi"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSPsikiyatrikTedaviGecmisi.GetSKRSPsikiyatrikTedaviGecmisi_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SKRSPsikiyatrikTedaviGecmisi.GetSKRSPsikiyatrikTedaviGecmisi_Class> GetSKRSPsikiyatrikTedaviGecmisi(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSPSIKIYATRIKTEDAVIGECMISI"].QueryDefs["GetSKRSPsikiyatrikTedaviGecmisi"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSPsikiyatrikTedaviGecmisi.GetSKRSPsikiyatrikTedaviGecmisi_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        protected SKRSPsikiyatrikTedaviGecmisi(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SKRSPsikiyatrikTedaviGecmisi(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SKRSPsikiyatrikTedaviGecmisi(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SKRSPsikiyatrikTedaviGecmisi(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SKRSPsikiyatrikTedaviGecmisi(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SKRSPSIKIYATRIKTEDAVIGECMISI", dataRow) { }
        protected SKRSPsikiyatrikTedaviGecmisi(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SKRSPSIKIYATRIKTEDAVIGECMISI", dataRow, isImported) { }
        public SKRSPsikiyatrikTedaviGecmisi(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SKRSPsikiyatrikTedaviGecmisi(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SKRSPsikiyatrikTedaviGecmisi() : base() { }

    }
}
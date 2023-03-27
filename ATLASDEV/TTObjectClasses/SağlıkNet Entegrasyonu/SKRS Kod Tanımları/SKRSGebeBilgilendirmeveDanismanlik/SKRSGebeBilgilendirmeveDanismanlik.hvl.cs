
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SKRSGebeBilgilendirmeveDanismanlik")] 

    /// <summary>
    /// d7d1283b-3440-5c76-e040-7c0a04161e8f
    /// </summary>
    public  partial class SKRSGebeBilgilendirmeveDanismanlik : BaseSKRSCommonDef
    {
        public class SKRSGebeBilgilendirmeveDanismanlikList : TTObjectCollection<SKRSGebeBilgilendirmeveDanismanlik> { }
                    
        public class ChildSKRSGebeBilgilendirmeveDanismanlikCollection : TTObject.TTChildObjectCollection<SKRSGebeBilgilendirmeveDanismanlik>
        {
            public ChildSKRSGebeBilgilendirmeveDanismanlikCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSKRSGebeBilgilendirmeveDanismanlikCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSKRSGebeBilgilendirmeveDanismanlik_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSGEBEBILGILENDIRMEVEDANISMANLIK"].AllPropertyDefs["DEFAULT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSGEBEBILGILENDIRMEVEDANISMANLIK"].AllPropertyDefs["AKTIF"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSGEBEBILGILENDIRMEVEDANISMANLIK"].AllPropertyDefs["OLUSTURULMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSGEBEBILGILENDIRMEVEDANISMANLIK"].AllPropertyDefs["GUNCELLENMETARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSGEBEBILGILENDIRMEVEDANISMANLIK"].AllPropertyDefs["PASIFEALINMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSGEBEBILGILENDIRMEVEDANISMANLIK"].AllPropertyDefs["GUNCELLEMETARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSGEBEBILGILENDIRMEVEDANISMANLIK"].AllPropertyDefs["ADI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSGEBEBILGILENDIRMEVEDANISMANLIK"].AllPropertyDefs["KODTIPIADI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSGEBEBILGILENDIRMEVEDANISMANLIK"].AllPropertyDefs["KODU"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSGEBEBILGILENDIRMEVEDANISMANLIK"].AllPropertyDefs["OLUSTURULMATARIHI1"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSGEBEBILGILENDIRMEVEDANISMANLIK"].AllPropertyDefs["GUNCELLENMETARIHI1"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetSKRSGebeBilgilendirmeveDanismanlik_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSKRSGebeBilgilendirmeveDanismanlik_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSKRSGebeBilgilendirmeveDanismanlik_Class() : base() { }
        }

        public static BindingList<SKRSGebeBilgilendirmeveDanismanlik.GetSKRSGebeBilgilendirmeveDanismanlik_Class> GetSKRSGebeBilgilendirmeveDanismanlik(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSGEBEBILGILENDIRMEVEDANISMANLIK"].QueryDefs["GetSKRSGebeBilgilendirmeveDanismanlik"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSGebeBilgilendirmeveDanismanlik.GetSKRSGebeBilgilendirmeveDanismanlik_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SKRSGebeBilgilendirmeveDanismanlik.GetSKRSGebeBilgilendirmeveDanismanlik_Class> GetSKRSGebeBilgilendirmeveDanismanlik(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSGEBEBILGILENDIRMEVEDANISMANLIK"].QueryDefs["GetSKRSGebeBilgilendirmeveDanismanlik"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSGebeBilgilendirmeveDanismanlik.GetSKRSGebeBilgilendirmeveDanismanlik_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        protected SKRSGebeBilgilendirmeveDanismanlik(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SKRSGebeBilgilendirmeveDanismanlik(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SKRSGebeBilgilendirmeveDanismanlik(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SKRSGebeBilgilendirmeveDanismanlik(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SKRSGebeBilgilendirmeveDanismanlik(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SKRSGEBEBILGILENDIRMEVEDANISMANLIK", dataRow) { }
        protected SKRSGebeBilgilendirmeveDanismanlik(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SKRSGEBEBILGILENDIRMEVEDANISMANLIK", dataRow, isImported) { }
        public SKRSGebeBilgilendirmeveDanismanlik(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SKRSGebeBilgilendirmeveDanismanlik(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SKRSGebeBilgilendirmeveDanismanlik() : base() { }

    }
}
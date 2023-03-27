
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SKRSKullandigiYardimciAraclar")] 

    /// <summary>
    /// 1435482c-1a3f-4f2d-b692-77c06f3827cd
    /// </summary>
    public  partial class SKRSKullandigiYardimciAraclar : BaseSKRSCommonDef
    {
        public class SKRSKullandigiYardimciAraclarList : TTObjectCollection<SKRSKullandigiYardimciAraclar> { }
                    
        public class ChildSKRSKullandigiYardimciAraclarCollection : TTObject.TTChildObjectCollection<SKRSKullandigiYardimciAraclar>
        {
            public ChildSKRSKullandigiYardimciAraclarCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSKRSKullandigiYardimciAraclarCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSKRSKullandigiYardimciAraclar_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSKULLANDIGIYARDIMCIARACLAR"].AllPropertyDefs["DEFAULT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSKULLANDIGIYARDIMCIARACLAR"].AllPropertyDefs["AKTIF"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSKULLANDIGIYARDIMCIARACLAR"].AllPropertyDefs["OLUSTURULMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSKULLANDIGIYARDIMCIARACLAR"].AllPropertyDefs["GUNCELLENMETARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSKULLANDIGIYARDIMCIARACLAR"].AllPropertyDefs["PASIFEALINMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSKULLANDIGIYARDIMCIARACLAR"].AllPropertyDefs["GUNCELLEMETARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSKULLANDIGIYARDIMCIARACLAR"].AllPropertyDefs["ADI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSKULLANDIGIYARDIMCIARACLAR"].AllPropertyDefs["KODTIPIADI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSKULLANDIGIYARDIMCIARACLAR"].AllPropertyDefs["KODU"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSKULLANDIGIYARDIMCIARACLAR"].AllPropertyDefs["OLUSTURULMATARIHI1"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSKULLANDIGIYARDIMCIARACLAR"].AllPropertyDefs["GUNCELLENMETARIHI1"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetSKRSKullandigiYardimciAraclar_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSKRSKullandigiYardimciAraclar_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSKRSKullandigiYardimciAraclar_Class() : base() { }
        }

        public static BindingList<SKRSKullandigiYardimciAraclar.GetSKRSKullandigiYardimciAraclar_Class> GetSKRSKullandigiYardimciAraclar(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSKULLANDIGIYARDIMCIARACLAR"].QueryDefs["GetSKRSKullandigiYardimciAraclar"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSKullandigiYardimciAraclar.GetSKRSKullandigiYardimciAraclar_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SKRSKullandigiYardimciAraclar.GetSKRSKullandigiYardimciAraclar_Class> GetSKRSKullandigiYardimciAraclar(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSKULLANDIGIYARDIMCIARACLAR"].QueryDefs["GetSKRSKullandigiYardimciAraclar"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSKullandigiYardimciAraclar.GetSKRSKullandigiYardimciAraclar_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        virtual protected void CreateKullandigiYardimciAraclarCollection()
        {
            _KullandigiYardimciAraclar = new KullandigiYardimciAraclar.ChildKullandigiYardimciAraclarCollection(this, new Guid("07687409-554e-4df4-a367-1d9d37faf30d"));
            ((ITTChildObjectCollection)_KullandigiYardimciAraclar).GetChildren();
        }

        protected KullandigiYardimciAraclar.ChildKullandigiYardimciAraclarCollection _KullandigiYardimciAraclar = null;
        public KullandigiYardimciAraclar.ChildKullandigiYardimciAraclarCollection KullandigiYardimciAraclar
        {
            get
            {
                if (_KullandigiYardimciAraclar == null)
                    CreateKullandigiYardimciAraclarCollection();
                return _KullandigiYardimciAraclar;
            }
        }

        protected SKRSKullandigiYardimciAraclar(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SKRSKullandigiYardimciAraclar(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SKRSKullandigiYardimciAraclar(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SKRSKullandigiYardimciAraclar(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SKRSKullandigiYardimciAraclar(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SKRSKULLANDIGIYARDIMCIARACLAR", dataRow) { }
        protected SKRSKullandigiYardimciAraclar(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SKRSKULLANDIGIYARDIMCIARACLAR", dataRow, isImported) { }
        public SKRSKullandigiYardimciAraclar(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SKRSKullandigiYardimciAraclar(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SKRSKullandigiYardimciAraclar() : base() { }

    }
}
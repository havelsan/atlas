
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SKRSEvdeSaglikHizmetininSonlandirilmasi")] 

    /// <summary>
    /// bb0d92ea-397f-4c8d-989c-f00aa9d5d7ff
    /// </summary>
    public  partial class SKRSEvdeSaglikHizmetininSonlandirilmasi : BaseSKRSCommonDef
    {
        public class SKRSEvdeSaglikHizmetininSonlandirilmasiList : TTObjectCollection<SKRSEvdeSaglikHizmetininSonlandirilmasi> { }
                    
        public class ChildSKRSEvdeSaglikHizmetininSonlandirilmasiCollection : TTObject.TTChildObjectCollection<SKRSEvdeSaglikHizmetininSonlandirilmasi>
        {
            public ChildSKRSEvdeSaglikHizmetininSonlandirilmasiCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSKRSEvdeSaglikHizmetininSonlandirilmasiCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSKRSEvdeSaglikHizmetininSonlandirilmasi_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSEVDESAGLIKHIZMETININSONLANDIRILMASI"].AllPropertyDefs["DEFAULT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSEVDESAGLIKHIZMETININSONLANDIRILMASI"].AllPropertyDefs["AKTIF"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSEVDESAGLIKHIZMETININSONLANDIRILMASI"].AllPropertyDefs["OLUSTURULMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSEVDESAGLIKHIZMETININSONLANDIRILMASI"].AllPropertyDefs["GUNCELLENMETARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSEVDESAGLIKHIZMETININSONLANDIRILMASI"].AllPropertyDefs["PASIFEALINMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSEVDESAGLIKHIZMETININSONLANDIRILMASI"].AllPropertyDefs["GUNCELLEMETARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSEVDESAGLIKHIZMETININSONLANDIRILMASI"].AllPropertyDefs["ADI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSEVDESAGLIKHIZMETININSONLANDIRILMASI"].AllPropertyDefs["KODTIPIADI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSEVDESAGLIKHIZMETININSONLANDIRILMASI"].AllPropertyDefs["KODU"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSEVDESAGLIKHIZMETININSONLANDIRILMASI"].AllPropertyDefs["OLUSTURULMATARIHI1"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSEVDESAGLIKHIZMETININSONLANDIRILMASI"].AllPropertyDefs["GUNCELLENMETARIHI1"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetSKRSEvdeSaglikHizmetininSonlandirilmasi_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSKRSEvdeSaglikHizmetininSonlandirilmasi_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSKRSEvdeSaglikHizmetininSonlandirilmasi_Class() : base() { }
        }

        public static BindingList<SKRSEvdeSaglikHizmetininSonlandirilmasi.GetSKRSEvdeSaglikHizmetininSonlandirilmasi_Class> GetSKRSEvdeSaglikHizmetininSonlandirilmasi(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSEVDESAGLIKHIZMETININSONLANDIRILMASI"].QueryDefs["GetSKRSEvdeSaglikHizmetininSonlandirilmasi"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSEvdeSaglikHizmetininSonlandirilmasi.GetSKRSEvdeSaglikHizmetininSonlandirilmasi_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SKRSEvdeSaglikHizmetininSonlandirilmasi.GetSKRSEvdeSaglikHizmetininSonlandirilmasi_Class> GetSKRSEvdeSaglikHizmetininSonlandirilmasi(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSEVDESAGLIKHIZMETININSONLANDIRILMASI"].QueryDefs["GetSKRSEvdeSaglikHizmetininSonlandirilmasi"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSEvdeSaglikHizmetininSonlandirilmasi.GetSKRSEvdeSaglikHizmetininSonlandirilmasi_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        virtual protected void CreateEvdeSaglikIzlemVeriSetiCollection()
        {
            _EvdeSaglikIzlemVeriSeti = new EvdeSaglikIzlemVeriSeti.ChildEvdeSaglikIzlemVeriSetiCollection(this, new Guid("892afe34-b1f5-4e0a-a49f-3f13e29574a6"));
            ((ITTChildObjectCollection)_EvdeSaglikIzlemVeriSeti).GetChildren();
        }

        protected EvdeSaglikIzlemVeriSeti.ChildEvdeSaglikIzlemVeriSetiCollection _EvdeSaglikIzlemVeriSeti = null;
        public EvdeSaglikIzlemVeriSeti.ChildEvdeSaglikIzlemVeriSetiCollection EvdeSaglikIzlemVeriSeti
        {
            get
            {
                if (_EvdeSaglikIzlemVeriSeti == null)
                    CreateEvdeSaglikIzlemVeriSetiCollection();
                return _EvdeSaglikIzlemVeriSeti;
            }
        }

        protected SKRSEvdeSaglikHizmetininSonlandirilmasi(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SKRSEvdeSaglikHizmetininSonlandirilmasi(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SKRSEvdeSaglikHizmetininSonlandirilmasi(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SKRSEvdeSaglikHizmetininSonlandirilmasi(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SKRSEvdeSaglikHizmetininSonlandirilmasi(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SKRSEVDESAGLIKHIZMETININSONLANDIRILMASI", dataRow) { }
        protected SKRSEvdeSaglikHizmetininSonlandirilmasi(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SKRSEVDESAGLIKHIZMETININSONLANDIRILMASI", dataRow, isImported) { }
        public SKRSEvdeSaglikHizmetininSonlandirilmasi(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SKRSEvdeSaglikHizmetininSonlandirilmasi(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SKRSEvdeSaglikHizmetininSonlandirilmasi() : base() { }

    }
}
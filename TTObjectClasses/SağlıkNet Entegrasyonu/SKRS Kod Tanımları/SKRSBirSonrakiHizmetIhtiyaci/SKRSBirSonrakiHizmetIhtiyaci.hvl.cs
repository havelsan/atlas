
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SKRSBirSonrakiHizmetIhtiyaci")] 

    /// <summary>
    /// 1ac7dc71-e09d-4ddd-bea5-179735d35246
    /// </summary>
    public  partial class SKRSBirSonrakiHizmetIhtiyaci : BaseSKRSCommonDef
    {
        public class SKRSBirSonrakiHizmetIhtiyaciList : TTObjectCollection<SKRSBirSonrakiHizmetIhtiyaci> { }
                    
        public class ChildSKRSBirSonrakiHizmetIhtiyaciCollection : TTObject.TTChildObjectCollection<SKRSBirSonrakiHizmetIhtiyaci>
        {
            public ChildSKRSBirSonrakiHizmetIhtiyaciCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSKRSBirSonrakiHizmetIhtiyaciCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSKRSBirSonrakiHizmetIhtiyaci_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSBIRSONRAKIHIZMETIHTIYACI"].AllPropertyDefs["DEFAULT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSBIRSONRAKIHIZMETIHTIYACI"].AllPropertyDefs["AKTIF"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSBIRSONRAKIHIZMETIHTIYACI"].AllPropertyDefs["OLUSTURULMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSBIRSONRAKIHIZMETIHTIYACI"].AllPropertyDefs["GUNCELLENMETARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSBIRSONRAKIHIZMETIHTIYACI"].AllPropertyDefs["PASIFEALINMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSBIRSONRAKIHIZMETIHTIYACI"].AllPropertyDefs["GUNCELLEMETARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSBIRSONRAKIHIZMETIHTIYACI"].AllPropertyDefs["ADI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSBIRSONRAKIHIZMETIHTIYACI"].AllPropertyDefs["KODTIPIADI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSBIRSONRAKIHIZMETIHTIYACI"].AllPropertyDefs["KODU"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSBIRSONRAKIHIZMETIHTIYACI"].AllPropertyDefs["OLUSTURULMATARIHI1"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSBIRSONRAKIHIZMETIHTIYACI"].AllPropertyDefs["GUNCELLENMETARIHI1"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetSKRSBirSonrakiHizmetIhtiyaci_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSKRSBirSonrakiHizmetIhtiyaci_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSKRSBirSonrakiHizmetIhtiyaci_Class() : base() { }
        }

        public static BindingList<SKRSBirSonrakiHizmetIhtiyaci.GetSKRSBirSonrakiHizmetIhtiyaci_Class> GetSKRSBirSonrakiHizmetIhtiyaci(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSBIRSONRAKIHIZMETIHTIYACI"].QueryDefs["GetSKRSBirSonrakiHizmetIhtiyaci"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSBirSonrakiHizmetIhtiyaci.GetSKRSBirSonrakiHizmetIhtiyaci_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SKRSBirSonrakiHizmetIhtiyaci.GetSKRSBirSonrakiHizmetIhtiyaci_Class> GetSKRSBirSonrakiHizmetIhtiyaci(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSBIRSONRAKIHIZMETIHTIYACI"].QueryDefs["GetSKRSBirSonrakiHizmetIhtiyaci"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSBirSonrakiHizmetIhtiyaci.GetSKRSBirSonrakiHizmetIhtiyaci_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        virtual protected void CreateEvdeSaglikIlkIzlemVeriSetiCollection()
        {
            _EvdeSaglikIlkIzlemVeriSeti = new EvdeSaglikIlkIzlemVeriSeti.ChildEvdeSaglikIlkIzlemVeriSetiCollection(this, new Guid("e0ff2ede-8c9b-4baa-bd27-0b59d1c263e1"));
            ((ITTChildObjectCollection)_EvdeSaglikIlkIzlemVeriSeti).GetChildren();
        }

        protected EvdeSaglikIlkIzlemVeriSeti.ChildEvdeSaglikIlkIzlemVeriSetiCollection _EvdeSaglikIlkIzlemVeriSeti = null;
        public EvdeSaglikIlkIzlemVeriSeti.ChildEvdeSaglikIlkIzlemVeriSetiCollection EvdeSaglikIlkIzlemVeriSeti
        {
            get
            {
                if (_EvdeSaglikIlkIzlemVeriSeti == null)
                    CreateEvdeSaglikIlkIzlemVeriSetiCollection();
                return _EvdeSaglikIlkIzlemVeriSeti;
            }
        }

        virtual protected void CreateBirSonrakiHizmetIhtiyaciCollection()
        {
            _BirSonrakiHizmetIhtiyaci = new BirSonrakiHizmetIhtiyaci.ChildBirSonrakiHizmetIhtiyaciCollection(this, new Guid("4c8dfacb-1efb-41e5-b064-923ef4c61705"));
            ((ITTChildObjectCollection)_BirSonrakiHizmetIhtiyaci).GetChildren();
        }

        protected BirSonrakiHizmetIhtiyaci.ChildBirSonrakiHizmetIhtiyaciCollection _BirSonrakiHizmetIhtiyaci = null;
        public BirSonrakiHizmetIhtiyaci.ChildBirSonrakiHizmetIhtiyaciCollection BirSonrakiHizmetIhtiyaci
        {
            get
            {
                if (_BirSonrakiHizmetIhtiyaci == null)
                    CreateBirSonrakiHizmetIhtiyaciCollection();
                return _BirSonrakiHizmetIhtiyaci;
            }
        }

        protected SKRSBirSonrakiHizmetIhtiyaci(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SKRSBirSonrakiHizmetIhtiyaci(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SKRSBirSonrakiHizmetIhtiyaci(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SKRSBirSonrakiHizmetIhtiyaci(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SKRSBirSonrakiHizmetIhtiyaci(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SKRSBIRSONRAKIHIZMETIHTIYACI", dataRow) { }
        protected SKRSBirSonrakiHizmetIhtiyaci(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SKRSBIRSONRAKIHIZMETIHTIYACI", dataRow, isImported) { }
        public SKRSBirSonrakiHizmetIhtiyaci(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SKRSBirSonrakiHizmetIhtiyaci(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SKRSBirSonrakiHizmetIhtiyaci() : base() { }

    }
}
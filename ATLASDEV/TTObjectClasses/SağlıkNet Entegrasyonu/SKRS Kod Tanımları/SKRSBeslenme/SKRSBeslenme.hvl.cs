
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SKRSBeslenme")] 

    /// <summary>
    /// 6a220e1d-3865-4cab-b98f-b7933d9aa1ba
    /// </summary>
    public  partial class SKRSBeslenme : BaseSKRSCommonDef
    {
        public class SKRSBeslenmeList : TTObjectCollection<SKRSBeslenme> { }
                    
        public class ChildSKRSBeslenmeCollection : TTObject.TTChildObjectCollection<SKRSBeslenme>
        {
            public ChildSKRSBeslenmeCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSKRSBeslenmeCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSKRSBeslenme_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSBESLENME"].AllPropertyDefs["DEFAULT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSBESLENME"].AllPropertyDefs["AKTIF"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSBESLENME"].AllPropertyDefs["OLUSTURULMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSBESLENME"].AllPropertyDefs["GUNCELLENMETARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSBESLENME"].AllPropertyDefs["PASIFEALINMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSBESLENME"].AllPropertyDefs["GUNCELLEMETARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSBESLENME"].AllPropertyDefs["ADI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSBESLENME"].AllPropertyDefs["KODTIPIADI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSBESLENME"].AllPropertyDefs["KODU"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSBESLENME"].AllPropertyDefs["OLUSTURULMATARIHI1"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSBESLENME"].AllPropertyDefs["GUNCELLENMETARIHI1"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetSKRSBeslenme_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSKRSBeslenme_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSKRSBeslenme_Class() : base() { }
        }

        public static BindingList<SKRSBeslenme.GetSKRSBeslenme_Class> GetSKRSBeslenme(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSBESLENME"].QueryDefs["GetSKRSBeslenme"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSBeslenme.GetSKRSBeslenme_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SKRSBeslenme.GetSKRSBeslenme_Class> GetSKRSBeslenme(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSBESLENME"].QueryDefs["GetSKRSBeslenme"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSBeslenme.GetSKRSBeslenme_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        virtual protected void CreateEvdeSaglikIlkIzlemVeriSetiCollection()
        {
            _EvdeSaglikIlkIzlemVeriSeti = new EvdeSaglikIlkIzlemVeriSeti.ChildEvdeSaglikIlkIzlemVeriSetiCollection(this, new Guid("0298b554-abd1-48bd-b62e-a3a414c1ccdb"));
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

        virtual protected void CreateEvdeSaglikIzlemVeriSetiCollection()
        {
            _EvdeSaglikIzlemVeriSeti = new EvdeSaglikIzlemVeriSeti.ChildEvdeSaglikIzlemVeriSetiCollection(this, new Guid("3d83cacb-2bb1-4d76-aac0-47782262917a"));
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

        protected SKRSBeslenme(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SKRSBeslenme(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SKRSBeslenme(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SKRSBeslenme(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SKRSBeslenme(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SKRSBESLENME", dataRow) { }
        protected SKRSBeslenme(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SKRSBESLENME", dataRow, isImported) { }
        public SKRSBeslenme(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SKRSBeslenme(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SKRSBeslenme() : base() { }

    }
}
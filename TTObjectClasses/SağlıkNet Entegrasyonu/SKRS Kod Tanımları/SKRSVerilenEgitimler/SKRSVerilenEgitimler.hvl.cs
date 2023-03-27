
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SKRSVerilenEgitimler")] 

    /// <summary>
    /// 79aaa967-1886-4d9d-a5d8-cdde552d94ad
    /// </summary>
    public  partial class SKRSVerilenEgitimler : BaseSKRSCommonDef
    {
        public class SKRSVerilenEgitimlerList : TTObjectCollection<SKRSVerilenEgitimler> { }
                    
        public class ChildSKRSVerilenEgitimlerCollection : TTObject.TTChildObjectCollection<SKRSVerilenEgitimler>
        {
            public ChildSKRSVerilenEgitimlerCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSKRSVerilenEgitimlerCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSKRSVerilenEgitimler_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSVERILENEGITIMLER"].AllPropertyDefs["DEFAULT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSVERILENEGITIMLER"].AllPropertyDefs["AKTIF"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSVERILENEGITIMLER"].AllPropertyDefs["OLUSTURULMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSVERILENEGITIMLER"].AllPropertyDefs["GUNCELLENMETARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSVERILENEGITIMLER"].AllPropertyDefs["PASIFEALINMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSVERILENEGITIMLER"].AllPropertyDefs["GUNCELLEMETARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSVERILENEGITIMLER"].AllPropertyDefs["ADI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSVERILENEGITIMLER"].AllPropertyDefs["KODTIPIADI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSVERILENEGITIMLER"].AllPropertyDefs["KODU"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSVERILENEGITIMLER"].AllPropertyDefs["OLUSTURULMATARIHI1"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSVERILENEGITIMLER"].AllPropertyDefs["GUNCELLENMETARIHI1"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetSKRSVerilenEgitimler_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSKRSVerilenEgitimler_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSKRSVerilenEgitimler_Class() : base() { }
        }

        public static BindingList<SKRSVerilenEgitimler.GetSKRSVerilenEgitimler_Class> GetSKRSVerilenEgitimler(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSVERILENEGITIMLER"].QueryDefs["GetSKRSVerilenEgitimler"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSVerilenEgitimler.GetSKRSVerilenEgitimler_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SKRSVerilenEgitimler.GetSKRSVerilenEgitimler_Class> GetSKRSVerilenEgitimler(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSVERILENEGITIMLER"].QueryDefs["GetSKRSVerilenEgitimler"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSVerilenEgitimler.GetSKRSVerilenEgitimler_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        virtual protected void CreateVerilenEgitimlerCollection()
        {
            _VerilenEgitimler = new VerilenEgitimler.ChildVerilenEgitimlerCollection(this, new Guid("75952172-91bc-4a0f-82bd-9403cf9ca723"));
            ((ITTChildObjectCollection)_VerilenEgitimler).GetChildren();
        }

        protected VerilenEgitimler.ChildVerilenEgitimlerCollection _VerilenEgitimler = null;
        public VerilenEgitimler.ChildVerilenEgitimlerCollection VerilenEgitimler
        {
            get
            {
                if (_VerilenEgitimler == null)
                    CreateVerilenEgitimlerCollection();
                return _VerilenEgitimler;
            }
        }

        protected SKRSVerilenEgitimler(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SKRSVerilenEgitimler(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SKRSVerilenEgitimler(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SKRSVerilenEgitimler(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SKRSVerilenEgitimler(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SKRSVERILENEGITIMLER", dataRow) { }
        protected SKRSVerilenEgitimler(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SKRSVERILENEGITIMLER", dataRow, isImported) { }
        public SKRSVerilenEgitimler(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SKRSVerilenEgitimler(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SKRSVerilenEgitimler() : base() { }

    }
}
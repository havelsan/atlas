
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SKRSKisiselBakim")] 

    /// <summary>
    /// 922fd54a-443f-4b47-9e82-53f9d7f96a0d
    /// </summary>
    public  partial class SKRSKisiselBakim : BaseSKRSCommonDef
    {
        public class SKRSKisiselBakimList : TTObjectCollection<SKRSKisiselBakim> { }
                    
        public class ChildSKRSKisiselBakimCollection : TTObject.TTChildObjectCollection<SKRSKisiselBakim>
        {
            public ChildSKRSKisiselBakimCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSKRSKisiselBakimCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSKRSKisiselBakim_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSKISISELBAKIM"].AllPropertyDefs["DEFAULT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSKISISELBAKIM"].AllPropertyDefs["AKTIF"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSKISISELBAKIM"].AllPropertyDefs["OLUSTURULMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSKISISELBAKIM"].AllPropertyDefs["GUNCELLENMETARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSKISISELBAKIM"].AllPropertyDefs["PASIFEALINMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSKISISELBAKIM"].AllPropertyDefs["GUNCELLEMETARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSKISISELBAKIM"].AllPropertyDefs["ADI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSKISISELBAKIM"].AllPropertyDefs["KODTIPIADI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSKISISELBAKIM"].AllPropertyDefs["KODU"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSKISISELBAKIM"].AllPropertyDefs["OLUSTURULMATARIHI1"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSKISISELBAKIM"].AllPropertyDefs["GUNCELLENMETARIHI1"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetSKRSKisiselBakim_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSKRSKisiselBakim_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSKRSKisiselBakim_Class() : base() { }
        }

        public static BindingList<SKRSKisiselBakim.GetSKRSKisiselBakim_Class> GetSKRSKisiselBakim(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSKISISELBAKIM"].QueryDefs["GetSKRSKisiselBakim"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSKisiselBakim.GetSKRSKisiselBakim_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SKRSKisiselBakim.GetSKRSKisiselBakim_Class> GetSKRSKisiselBakim(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSKISISELBAKIM"].QueryDefs["GetSKRSKisiselBakim"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSKisiselBakim.GetSKRSKisiselBakim_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        virtual protected void CreateEvdeSaglikIlkIzlemVeriSetiCollection()
        {
            _EvdeSaglikIlkIzlemVeriSeti = new EvdeSaglikIlkIzlemVeriSeti.ChildEvdeSaglikIlkIzlemVeriSetiCollection(this, new Guid("7a9401c9-ed67-4eb9-a005-ba97a36c0ec2"));
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

        protected SKRSKisiselBakim(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SKRSKisiselBakim(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SKRSKisiselBakim(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SKRSKisiselBakim(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SKRSKisiselBakim(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SKRSKISISELBAKIM", dataRow) { }
        protected SKRSKisiselBakim(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SKRSKISISELBAKIM", dataRow, isImported) { }
        public SKRSKisiselBakim(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SKRSKisiselBakim(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SKRSKisiselBakim() : base() { }

    }
}
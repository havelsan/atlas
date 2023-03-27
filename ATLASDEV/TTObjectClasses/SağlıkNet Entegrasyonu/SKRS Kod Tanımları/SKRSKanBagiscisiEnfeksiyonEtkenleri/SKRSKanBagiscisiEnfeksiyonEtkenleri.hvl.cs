
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SKRSKanBagiscisiEnfeksiyonEtkenleri")] 

    /// <summary>
    /// 8a73e2c0-a0f5-42bd-8b07-87793a302d9b
    /// </summary>
    public  partial class SKRSKanBagiscisiEnfeksiyonEtkenleri : BaseSKRSCommonDef
    {
        public class SKRSKanBagiscisiEnfeksiyonEtkenleriList : TTObjectCollection<SKRSKanBagiscisiEnfeksiyonEtkenleri> { }
                    
        public class ChildSKRSKanBagiscisiEnfeksiyonEtkenleriCollection : TTObject.TTChildObjectCollection<SKRSKanBagiscisiEnfeksiyonEtkenleri>
        {
            public ChildSKRSKanBagiscisiEnfeksiyonEtkenleriCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSKRSKanBagiscisiEnfeksiyonEtkenleriCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSKRSKanBagiscisiEnfeksiyonEtkenleri_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSKANBAGISCISIENFEKSIYONETKENLERI"].AllPropertyDefs["DEFAULT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSKANBAGISCISIENFEKSIYONETKENLERI"].AllPropertyDefs["AKTIF"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSKANBAGISCISIENFEKSIYONETKENLERI"].AllPropertyDefs["OLUSTURULMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSKANBAGISCISIENFEKSIYONETKENLERI"].AllPropertyDefs["GUNCELLENMETARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSKANBAGISCISIENFEKSIYONETKENLERI"].AllPropertyDefs["PASIFEALINMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSKANBAGISCISIENFEKSIYONETKENLERI"].AllPropertyDefs["GUNCELLEMETARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSKANBAGISCISIENFEKSIYONETKENLERI"].AllPropertyDefs["ADI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSKANBAGISCISIENFEKSIYONETKENLERI"].AllPropertyDefs["KODTIPIADI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSKANBAGISCISIENFEKSIYONETKENLERI"].AllPropertyDefs["KODU"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSKANBAGISCISIENFEKSIYONETKENLERI"].AllPropertyDefs["OLUSTURULMATARIHI1"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSKANBAGISCISIENFEKSIYONETKENLERI"].AllPropertyDefs["GUNCELLENMETARIHI1"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetSKRSKanBagiscisiEnfeksiyonEtkenleri_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSKRSKanBagiscisiEnfeksiyonEtkenleri_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSKRSKanBagiscisiEnfeksiyonEtkenleri_Class() : base() { }
        }

        public static BindingList<SKRSKanBagiscisiEnfeksiyonEtkenleri.GetSKRSKanBagiscisiEnfeksiyonEtkenleri_Class> GetSKRSKanBagiscisiEnfeksiyonEtkenleri(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSKANBAGISCISIENFEKSIYONETKENLERI"].QueryDefs["GetSKRSKanBagiscisiEnfeksiyonEtkenleri"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSKanBagiscisiEnfeksiyonEtkenleri.GetSKRSKanBagiscisiEnfeksiyonEtkenleri_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SKRSKanBagiscisiEnfeksiyonEtkenleri.GetSKRSKanBagiscisiEnfeksiyonEtkenleri_Class> GetSKRSKanBagiscisiEnfeksiyonEtkenleri(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSKANBAGISCISIENFEKSIYONETKENLERI"].QueryDefs["GetSKRSKanBagiscisiEnfeksiyonEtkenleri"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSKanBagiscisiEnfeksiyonEtkenleri.GetSKRSKanBagiscisiEnfeksiyonEtkenleri_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        protected SKRSKanBagiscisiEnfeksiyonEtkenleri(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SKRSKanBagiscisiEnfeksiyonEtkenleri(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SKRSKanBagiscisiEnfeksiyonEtkenleri(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SKRSKanBagiscisiEnfeksiyonEtkenleri(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SKRSKanBagiscisiEnfeksiyonEtkenleri(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SKRSKANBAGISCISIENFEKSIYONETKENLERI", dataRow) { }
        protected SKRSKanBagiscisiEnfeksiyonEtkenleri(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SKRSKANBAGISCISIENFEKSIYONETKENLERI", dataRow, isImported) { }
        public SKRSKanBagiscisiEnfeksiyonEtkenleri(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SKRSKanBagiscisiEnfeksiyonEtkenleri(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SKRSKanBagiscisiEnfeksiyonEtkenleri() : base() { }

    }
}

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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SKRSTutunDumaninaMaruzKalmaPasificicilik")] 

    /// <summary>
    /// c366b0b6-b15b-4819-920d-a9f465eed764
    /// </summary>
    public  partial class SKRSTutunDumaninaMaruzKalmaPasificicilik : BaseSKRSCommonDef
    {
        public class SKRSTutunDumaninaMaruzKalmaPasificicilikList : TTObjectCollection<SKRSTutunDumaninaMaruzKalmaPasificicilik> { }
                    
        public class ChildSKRSTutunDumaninaMaruzKalmaPasificicilikCollection : TTObject.TTChildObjectCollection<SKRSTutunDumaninaMaruzKalmaPasificicilik>
        {
            public ChildSKRSTutunDumaninaMaruzKalmaPasificicilikCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSKRSTutunDumaninaMaruzKalmaPasificicilikCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSKRSTutunDumaninaMaruzKalmaPasificicilik_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSTUTUNDUMANINAMARUZKALMAPASIFICICILIK"].AllPropertyDefs["DEFAULT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSTUTUNDUMANINAMARUZKALMAPASIFICICILIK"].AllPropertyDefs["AKTIF"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSTUTUNDUMANINAMARUZKALMAPASIFICICILIK"].AllPropertyDefs["OLUSTURULMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSTUTUNDUMANINAMARUZKALMAPASIFICICILIK"].AllPropertyDefs["GUNCELLENMETARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSTUTUNDUMANINAMARUZKALMAPASIFICICILIK"].AllPropertyDefs["PASIFEALINMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSTUTUNDUMANINAMARUZKALMAPASIFICICILIK"].AllPropertyDefs["GUNCELLEMETARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSTUTUNDUMANINAMARUZKALMAPASIFICICILIK"].AllPropertyDefs["ADI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSTUTUNDUMANINAMARUZKALMAPASIFICICILIK"].AllPropertyDefs["KODTIPIADI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSTUTUNDUMANINAMARUZKALMAPASIFICICILIK"].AllPropertyDefs["KODU"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSTUTUNDUMANINAMARUZKALMAPASIFICICILIK"].AllPropertyDefs["OLUSTURULMATARIHI1"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSTUTUNDUMANINAMARUZKALMAPASIFICICILIK"].AllPropertyDefs["GUNCELLENMETARIHI1"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetSKRSTutunDumaninaMaruzKalmaPasificicilik_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSKRSTutunDumaninaMaruzKalmaPasificicilik_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSKRSTutunDumaninaMaruzKalmaPasificicilik_Class() : base() { }
        }

        public static BindingList<SKRSTutunDumaninaMaruzKalmaPasificicilik.GetSKRSTutunDumaninaMaruzKalmaPasificicilik_Class> GetSKRSTutunDumaninaMaruzKalmaPasificicilik(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSTUTUNDUMANINAMARUZKALMAPASIFICICILIK"].QueryDefs["GetSKRSTutunDumaninaMaruzKalmaPasificicilik"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSTutunDumaninaMaruzKalmaPasificicilik.GetSKRSTutunDumaninaMaruzKalmaPasificicilik_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SKRSTutunDumaninaMaruzKalmaPasificicilik.GetSKRSTutunDumaninaMaruzKalmaPasificicilik_Class> GetSKRSTutunDumaninaMaruzKalmaPasificicilik(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSTUTUNDUMANINAMARUZKALMAPASIFICICILIK"].QueryDefs["GetSKRSTutunDumaninaMaruzKalmaPasificicilik"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSTutunDumaninaMaruzKalmaPasificicilik.GetSKRSTutunDumaninaMaruzKalmaPasificicilik_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        protected SKRSTutunDumaninaMaruzKalmaPasificicilik(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SKRSTutunDumaninaMaruzKalmaPasificicilik(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SKRSTutunDumaninaMaruzKalmaPasificicilik(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SKRSTutunDumaninaMaruzKalmaPasificicilik(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SKRSTutunDumaninaMaruzKalmaPasificicilik(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SKRSTUTUNDUMANINAMARUZKALMAPASIFICICILIK", dataRow) { }
        protected SKRSTutunDumaninaMaruzKalmaPasificicilik(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SKRSTUTUNDUMANINAMARUZKALMAPASIFICICILIK", dataRow, isImported) { }
        public SKRSTutunDumaninaMaruzKalmaPasificicilik(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SKRSTutunDumaninaMaruzKalmaPasificicilik(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SKRSTutunDumaninaMaruzKalmaPasificicilik() : base() { }

    }
}
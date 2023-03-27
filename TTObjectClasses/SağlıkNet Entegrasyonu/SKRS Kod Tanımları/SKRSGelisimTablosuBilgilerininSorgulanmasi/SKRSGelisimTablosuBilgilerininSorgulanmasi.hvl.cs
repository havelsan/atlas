
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SKRSGelisimTablosuBilgilerininSorgulanmasi")] 

    /// <summary>
    /// b0f8712e-a51b-427a-a554-a21574abb07b
    /// </summary>
    public  partial class SKRSGelisimTablosuBilgilerininSorgulanmasi : BaseSKRSCommonDef
    {
        public class SKRSGelisimTablosuBilgilerininSorgulanmasiList : TTObjectCollection<SKRSGelisimTablosuBilgilerininSorgulanmasi> { }
                    
        public class ChildSKRSGelisimTablosuBilgilerininSorgulanmasiCollection : TTObject.TTChildObjectCollection<SKRSGelisimTablosuBilgilerininSorgulanmasi>
        {
            public ChildSKRSGelisimTablosuBilgilerininSorgulanmasiCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSKRSGelisimTablosuBilgilerininSorgulanmasiCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSKRSGelisimTablosuBilgilerininSorgulanmasi_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSGELISIMTABLOSUBILGILERININSORGULANMASI"].AllPropertyDefs["DEFAULT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSGELISIMTABLOSUBILGILERININSORGULANMASI"].AllPropertyDefs["AKTIF"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSGELISIMTABLOSUBILGILERININSORGULANMASI"].AllPropertyDefs["OLUSTURULMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSGELISIMTABLOSUBILGILERININSORGULANMASI"].AllPropertyDefs["GUNCELLENMETARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSGELISIMTABLOSUBILGILERININSORGULANMASI"].AllPropertyDefs["PASIFEALINMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSGELISIMTABLOSUBILGILERININSORGULANMASI"].AllPropertyDefs["GUNCELLEMETARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSGELISIMTABLOSUBILGILERININSORGULANMASI"].AllPropertyDefs["ADI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSGELISIMTABLOSUBILGILERININSORGULANMASI"].AllPropertyDefs["KODTIPIADI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSGELISIMTABLOSUBILGILERININSORGULANMASI"].AllPropertyDefs["KODU"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSGELISIMTABLOSUBILGILERININSORGULANMASI"].AllPropertyDefs["OLUSTURULMATARIHI1"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSGELISIMTABLOSUBILGILERININSORGULANMASI"].AllPropertyDefs["GUNCELLENMETARIHI1"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetSKRSGelisimTablosuBilgilerininSorgulanmasi_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSKRSGelisimTablosuBilgilerininSorgulanmasi_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSKRSGelisimTablosuBilgilerininSorgulanmasi_Class() : base() { }
        }

        public static BindingList<SKRSGelisimTablosuBilgilerininSorgulanmasi.GetSKRSGelisimTablosuBilgilerininSorgulanmasi_Class> GetSKRSGelisimTablosuBilgilerininSorgulanmasi(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSGELISIMTABLOSUBILGILERININSORGULANMASI"].QueryDefs["GetSKRSGelisimTablosuBilgilerininSorgulanmasi"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSGelisimTablosuBilgilerininSorgulanmasi.GetSKRSGelisimTablosuBilgilerininSorgulanmasi_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SKRSGelisimTablosuBilgilerininSorgulanmasi.GetSKRSGelisimTablosuBilgilerininSorgulanmasi_Class> GetSKRSGelisimTablosuBilgilerininSorgulanmasi(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSGELISIMTABLOSUBILGILERININSORGULANMASI"].QueryDefs["GetSKRSGelisimTablosuBilgilerininSorgulanmasi"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSGelisimTablosuBilgilerininSorgulanmasi.GetSKRSGelisimTablosuBilgilerininSorgulanmasi_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        protected SKRSGelisimTablosuBilgilerininSorgulanmasi(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SKRSGelisimTablosuBilgilerininSorgulanmasi(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SKRSGelisimTablosuBilgilerininSorgulanmasi(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SKRSGelisimTablosuBilgilerininSorgulanmasi(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SKRSGelisimTablosuBilgilerininSorgulanmasi(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SKRSGELISIMTABLOSUBILGILERININSORGULANMASI", dataRow) { }
        protected SKRSGelisimTablosuBilgilerininSorgulanmasi(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SKRSGELISIMTABLOSUBILGILERININSORGULANMASI", dataRow, isImported) { }
        public SKRSGelisimTablosuBilgilerininSorgulanmasi(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SKRSGelisimTablosuBilgilerininSorgulanmasi(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SKRSGelisimTablosuBilgilerininSorgulanmasi() : base() { }

    }
}

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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SKRSAdresKoduSeviyesi")] 

    /// <summary>
    /// aa0e83ba-e9db-4817-80da-577fd6a17373
    /// </summary>
    public  partial class SKRSAdresKoduSeviyesi : BaseSKRSCommonDef
    {
        public class SKRSAdresKoduSeviyesiList : TTObjectCollection<SKRSAdresKoduSeviyesi> { }
                    
        public class ChildSKRSAdresKoduSeviyesiCollection : TTObject.TTChildObjectCollection<SKRSAdresKoduSeviyesi>
        {
            public ChildSKRSAdresKoduSeviyesiCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSKRSAdresKoduSeviyesiCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSKRSAdresKoduSeviyesi_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSADRESKODUSEVIYESI"].AllPropertyDefs["DEFAULT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSADRESKODUSEVIYESI"].AllPropertyDefs["AKTIF"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSADRESKODUSEVIYESI"].AllPropertyDefs["OLUSTURULMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSADRESKODUSEVIYESI"].AllPropertyDefs["GUNCELLENMETARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSADRESKODUSEVIYESI"].AllPropertyDefs["PASIFEALINMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSADRESKODUSEVIYESI"].AllPropertyDefs["GUNCELLEMETARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSADRESKODUSEVIYESI"].AllPropertyDefs["ADI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSADRESKODUSEVIYESI"].AllPropertyDefs["KODTIPIADI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSADRESKODUSEVIYESI"].AllPropertyDefs["KODU"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSADRESKODUSEVIYESI"].AllPropertyDefs["OLUSTURULMATARIHI1"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSADRESKODUSEVIYESI"].AllPropertyDefs["GUNCELLENMETARIHI1"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetSKRSAdresKoduSeviyesi_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSKRSAdresKoduSeviyesi_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSKRSAdresKoduSeviyesi_Class() : base() { }
        }

    /// <summary>
    /// Adres Kodu Seviyesi
    /// </summary>
        public static BindingList<SKRSAdresKoduSeviyesi> GetByKodu(TTObjectContext objectContext, string KODU, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSADRESKODUSEVIYESI"].QueryDefs["GetByKodu"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("KODU", KODU);

            return ((ITTQuery)objectContext).QueryObjects<SKRSAdresKoduSeviyesi>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<SKRSAdresKoduSeviyesi> GetSKRSAdresKoduSByKodu(TTObjectContext objectContext, string KODU)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSADRESKODUSEVIYESI"].QueryDefs["GetSKRSAdresKoduSByKodu"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("KODU", KODU);

            return ((ITTQuery)objectContext).QueryObjects<SKRSAdresKoduSeviyesi>(queryDef, paramList);
        }

        public static BindingList<SKRSAdresKoduSeviyesi.GetSKRSAdresKoduSeviyesi_Class> GetSKRSAdresKoduSeviyesi(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSADRESKODUSEVIYESI"].QueryDefs["GetSKRSAdresKoduSeviyesi"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSAdresKoduSeviyesi.GetSKRSAdresKoduSeviyesi_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SKRSAdresKoduSeviyesi.GetSKRSAdresKoduSeviyesi_Class> GetSKRSAdresKoduSeviyesi(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSADRESKODUSEVIYESI"].QueryDefs["GetSKRSAdresKoduSeviyesi"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSAdresKoduSeviyesi.GetSKRSAdresKoduSeviyesi_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        protected SKRSAdresKoduSeviyesi(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SKRSAdresKoduSeviyesi(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SKRSAdresKoduSeviyesi(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SKRSAdresKoduSeviyesi(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SKRSAdresKoduSeviyesi(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SKRSADRESKODUSEVIYESI", dataRow) { }
        protected SKRSAdresKoduSeviyesi(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SKRSADRESKODUSEVIYESI", dataRow, isImported) { }
        public SKRSAdresKoduSeviyesi(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SKRSAdresKoduSeviyesi(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SKRSAdresKoduSeviyesi() : base() { }

    }
}
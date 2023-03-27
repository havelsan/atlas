
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SKRSGUNSONUOZETREFERANS")] 

    /// <summary>
    /// efff2f6f-5b5f-4ed3-b034-5b6336ee87c8
    /// </summary>
    public  partial class SKRSGUNSONUOZETREFERANS : BaseSKRSDefinition
    {
        public class SKRSGUNSONUOZETREFERANSList : TTObjectCollection<SKRSGUNSONUOZETREFERANS> { }
                    
        public class ChildSKRSGUNSONUOZETREFERANSCollection : TTObject.TTChildObjectCollection<SKRSGUNSONUOZETREFERANS>
        {
            public ChildSKRSGUNSONUOZETREFERANSCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSKRSGUNSONUOZETREFERANSCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSKRSGUNSONUOZETREFERANS_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSGUNSONUOZETREFERANS"].AllPropertyDefs["DEFAULT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSGUNSONUOZETREFERANS"].AllPropertyDefs["AKTIF"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSGUNSONUOZETREFERANS"].AllPropertyDefs["OLUSTURULMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSGUNSONUOZETREFERANS"].AllPropertyDefs["GUNCELLENMETARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSGUNSONUOZETREFERANS"].AllPropertyDefs["PASIFEALINMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSGUNSONUOZETREFERANS"].AllPropertyDefs["GUNCELLEMETARIHI"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public int? KODU
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSGUNSONUOZETREFERANS"].AllPropertyDefs["KODU"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? GUNSONUID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GUNSONUID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSGUNSONUOZETREFERANS"].AllPropertyDefs["GUNSONUID"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string REFERANSKOD
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REFERANSKOD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSGUNSONUOZETREFERANS"].AllPropertyDefs["REFERANSKOD"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string REFERANSTUR
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REFERANSTUR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSGUNSONUOZETREFERANS"].AllPropertyDefs["REFERANSTUR"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSGUNSONUOZETREFERANS"].AllPropertyDefs["OLUSTURULMATARIHI1"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string GUNCELLENMETARIHI1
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GUNCELLENMETARIHI1"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSGUNSONUOZETREFERANS"].AllPropertyDefs["GUNCELLENMETARIHI1"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetSKRSGUNSONUOZETREFERANS_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSKRSGUNSONUOZETREFERANS_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSKRSGUNSONUOZETREFERANS_Class() : base() { }
        }

        [Serializable] 

        public partial class GetSKRSGUNSONUREFERANSByGunSonuID_Class : TTReportNqlObject 
        {
            public string REFERANSKOD
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REFERANSKOD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSGUNSONUOZETREFERANS"].AllPropertyDefs["REFERANSKOD"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string REFERANSTUR
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REFERANSTUR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSGUNSONUOZETREFERANS"].AllPropertyDefs["REFERANSTUR"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetSKRSGUNSONUREFERANSByGunSonuID_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSKRSGUNSONUREFERANSByGunSonuID_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSKRSGUNSONUREFERANSByGunSonuID_Class() : base() { }
        }

        public static BindingList<SKRSGUNSONUOZETREFERANS.GetSKRSGUNSONUOZETREFERANS_Class> GetSKRSGUNSONUOZETREFERANS(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSGUNSONUOZETREFERANS"].QueryDefs["GetSKRSGUNSONUOZETREFERANS"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSGUNSONUOZETREFERANS.GetSKRSGUNSONUOZETREFERANS_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SKRSGUNSONUOZETREFERANS.GetSKRSGUNSONUOZETREFERANS_Class> GetSKRSGUNSONUOZETREFERANS(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSGUNSONUOZETREFERANS"].QueryDefs["GetSKRSGUNSONUOZETREFERANS"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSGUNSONUOZETREFERANS.GetSKRSGUNSONUOZETREFERANS_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SKRSGUNSONUOZETREFERANS.GetSKRSGUNSONUREFERANSByGunSonuID_Class> GetSKRSGUNSONUREFERANSByGunSonuID(int GUNSONU_ID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSGUNSONUOZETREFERANS"].QueryDefs["GetSKRSGUNSONUREFERANSByGunSonuID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("GUNSONU_ID", GUNSONU_ID);

            return TTReportNqlObject.QueryObjects<SKRSGUNSONUOZETREFERANS.GetSKRSGUNSONUREFERANSByGunSonuID_Class>(queryDef, paramList, pi);
        }

        public static BindingList<SKRSGUNSONUOZETREFERANS.GetSKRSGUNSONUREFERANSByGunSonuID_Class> GetSKRSGUNSONUREFERANSByGunSonuID(TTObjectContext objectContext, int GUNSONU_ID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSGUNSONUOZETREFERANS"].QueryDefs["GetSKRSGUNSONUREFERANSByGunSonuID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("GUNSONU_ID", GUNSONU_ID);

            return TTReportNqlObject.QueryObjects<SKRSGUNSONUOZETREFERANS.GetSKRSGUNSONUREFERANSByGunSonuID_Class>(objectContext, queryDef, paramList, pi);
        }

        public int? KODU
        {
            get { return (int?)this["KODU"]; }
            set { this["KODU"] = value; }
        }

        public int? GUNSONUID
        {
            get { return (int?)this["GUNSONUID"]; }
            set { this["GUNSONUID"] = value; }
        }

        public string REFERANSKOD
        {
            get { return (string)this["REFERANSKOD"]; }
            set { this["REFERANSKOD"] = value; }
        }

        public string REFERANSTUR
        {
            get { return (string)this["REFERANSTUR"]; }
            set { this["REFERANSTUR"] = value; }
        }

        public DateTime? OLUSTURULMATARIHI1
        {
            get { return (DateTime?)this["OLUSTURULMATARIHI1"]; }
            set { this["OLUSTURULMATARIHI1"] = value; }
        }

        public string GUNCELLENMETARIHI1
        {
            get { return (string)this["GUNCELLENMETARIHI1"]; }
            set { this["GUNCELLENMETARIHI1"] = value; }
        }

        protected SKRSGUNSONUOZETREFERANS(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SKRSGUNSONUOZETREFERANS(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SKRSGUNSONUOZETREFERANS(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SKRSGUNSONUOZETREFERANS(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SKRSGUNSONUOZETREFERANS(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SKRSGUNSONUOZETREFERANS", dataRow) { }
        protected SKRSGUNSONUOZETREFERANS(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SKRSGUNSONUOZETREFERANS", dataRow, isImported) { }
        public SKRSGUNSONUOZETREFERANS(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SKRSGUNSONUOZETREFERANS(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SKRSGUNSONUOZETREFERANS() : base() { }

    }
}
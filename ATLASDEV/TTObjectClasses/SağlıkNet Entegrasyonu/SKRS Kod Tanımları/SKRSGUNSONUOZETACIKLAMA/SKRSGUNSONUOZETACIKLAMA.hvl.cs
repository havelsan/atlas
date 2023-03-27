
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SKRSGUNSONUOZETACIKLAMA")] 

    /// <summary>
    /// a0c4e5ed-0aca-4300-9978-df92d2974cb4
    /// </summary>
    public  partial class SKRSGUNSONUOZETACIKLAMA : BaseSKRSDefinition
    {
        public class SKRSGUNSONUOZETACIKLAMAList : TTObjectCollection<SKRSGUNSONUOZETACIKLAMA> { }
                    
        public class ChildSKRSGUNSONUOZETACIKLAMACollection : TTObject.TTChildObjectCollection<SKRSGUNSONUOZETACIKLAMA>
        {
            public ChildSKRSGUNSONUOZETACIKLAMACollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSKRSGUNSONUOZETACIKLAMACollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSKRSGUNSONUOZETACIKLAMA_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSGUNSONUOZETACIKLAMA"].AllPropertyDefs["DEFAULT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSGUNSONUOZETACIKLAMA"].AllPropertyDefs["AKTIF"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSGUNSONUOZETACIKLAMA"].AllPropertyDefs["OLUSTURULMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSGUNSONUOZETACIKLAMA"].AllPropertyDefs["GUNCELLENMETARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSGUNSONUOZETACIKLAMA"].AllPropertyDefs["PASIFEALINMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSGUNSONUOZETACIKLAMA"].AllPropertyDefs["GUNCELLEMETARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSGUNSONUOZETACIKLAMA"].AllPropertyDefs["ADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? KODU
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSGUNSONUOZETACIKLAMA"].AllPropertyDefs["KODU"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string REFERANSVERI
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REFERANSVERI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSGUNSONUOZETACIKLAMA"].AllPropertyDefs["REFERANSVERI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSGUNSONUOZETACIKLAMA"].AllPropertyDefs["OLUSTURULMATARIHI1"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSGUNSONUOZETACIKLAMA"].AllPropertyDefs["GUNCELLENMETARIHI1"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetSKRSGUNSONUOZETACIKLAMA_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSKRSGUNSONUOZETACIKLAMA_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSKRSGUNSONUOZETACIKLAMA_Class() : base() { }
        }

        public static BindingList<SKRSGUNSONUOZETACIKLAMA.GetSKRSGUNSONUOZETACIKLAMA_Class> GetSKRSGUNSONUOZETACIKLAMA(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSGUNSONUOZETACIKLAMA"].QueryDefs["GetSKRSGUNSONUOZETACIKLAMA"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSGUNSONUOZETACIKLAMA.GetSKRSGUNSONUOZETACIKLAMA_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SKRSGUNSONUOZETACIKLAMA.GetSKRSGUNSONUOZETACIKLAMA_Class> GetSKRSGUNSONUOZETACIKLAMA(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSGUNSONUOZETACIKLAMA"].QueryDefs["GetSKRSGUNSONUOZETACIKLAMA"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSGUNSONUOZETACIKLAMA.GetSKRSGUNSONUOZETACIKLAMA_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public string ADI
        {
            get { return (string)this["ADI"]; }
            set { this["ADI"] = value; }
        }

        public int? KODU
        {
            get { return (int?)this["KODU"]; }
            set { this["KODU"] = value; }
        }

        public string REFERANSVERI
        {
            get { return (string)this["REFERANSVERI"]; }
            set { this["REFERANSVERI"] = value; }
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

        protected SKRSGUNSONUOZETACIKLAMA(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SKRSGUNSONUOZETACIKLAMA(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SKRSGUNSONUOZETACIKLAMA(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SKRSGUNSONUOZETACIKLAMA(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SKRSGUNSONUOZETACIKLAMA(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SKRSGUNSONUOZETACIKLAMA", dataRow) { }
        protected SKRSGUNSONUOZETACIKLAMA(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SKRSGUNSONUOZETACIKLAMA", dataRow, isImported) { }
        public SKRSGUNSONUOZETACIKLAMA(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SKRSGUNSONUOZETACIKLAMA(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SKRSGUNSONUOZETACIKLAMA() : base() { }

    }
}
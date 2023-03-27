
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SKRSCocukIzlemTakvimi")] 

    /// <summary>
    /// c3ea9144-3629-5377-e043-14031b0ae574
    /// </summary>
    public  partial class SKRSCocukIzlemTakvimi : BaseSKRSDefinition
    {
        public class SKRSCocukIzlemTakvimiList : TTObjectCollection<SKRSCocukIzlemTakvimi> { }
                    
        public class ChildSKRSCocukIzlemTakvimiCollection : TTObject.TTChildObjectCollection<SKRSCocukIzlemTakvimi>
        {
            public ChildSKRSCocukIzlemTakvimiCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSKRSCocukIzlemTakvimiCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSKRSCocukIzlemTakvimi_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSCOCUKIZLEMTAKVIMI"].AllPropertyDefs["DEFAULT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSCOCUKIZLEMTAKVIMI"].AllPropertyDefs["AKTIF"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSCOCUKIZLEMTAKVIMI"].AllPropertyDefs["OLUSTURULMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSCOCUKIZLEMTAKVIMI"].AllPropertyDefs["GUNCELLENMETARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSCOCUKIZLEMTAKVIMI"].AllPropertyDefs["PASIFEALINMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSCOCUKIZLEMTAKVIMI"].AllPropertyDefs["GUNCELLEMETARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSCOCUKIZLEMTAKVIMI"].AllPropertyDefs["ADI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSCOCUKIZLEMTAKVIMI"].AllPropertyDefs["KODU"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? ILKUYGULANMATARIHI
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ILKUYGULANMATARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSCOCUKIZLEMTAKVIMI"].AllPropertyDefs["ILKUYGULANMATARIHI"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? SONUYGULANMATARIHI
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SONUYGULANMATARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSCOCUKIZLEMTAKVIMI"].AllPropertyDefs["SONUYGULANMATARIHI"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? PERFDAHILMI
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PERFDAHILMI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSCOCUKIZLEMTAKVIMI"].AllPropertyDefs["PERFDAHILMI"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public DateTime? OLUSTURULMATARIHI1
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLUSTURULMATARIHI1"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSCOCUKIZLEMTAKVIMI"].AllPropertyDefs["OLUSTURULMATARIHI1"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSCOCUKIZLEMTAKVIMI"].AllPropertyDefs["GUNCELLENMETARIHI1"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetSKRSCocukIzlemTakvimi_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSKRSCocukIzlemTakvimi_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSKRSCocukIzlemTakvimi_Class() : base() { }
        }

        public static BindingList<SKRSCocukIzlemTakvimi.GetSKRSCocukIzlemTakvimi_Class> GetSKRSCocukIzlemTakvimi(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSCOCUKIZLEMTAKVIMI"].QueryDefs["GetSKRSCocukIzlemTakvimi"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSCocukIzlemTakvimi.GetSKRSCocukIzlemTakvimi_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SKRSCocukIzlemTakvimi.GetSKRSCocukIzlemTakvimi_Class> GetSKRSCocukIzlemTakvimi(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSCOCUKIZLEMTAKVIMI"].QueryDefs["GetSKRSCocukIzlemTakvimi"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSCocukIzlemTakvimi.GetSKRSCocukIzlemTakvimi_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
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

        public int? ILKUYGULANMATARIHI
        {
            get { return (int?)this["ILKUYGULANMATARIHI"]; }
            set { this["ILKUYGULANMATARIHI"] = value; }
        }

        public int? SONUYGULANMATARIHI
        {
            get { return (int?)this["SONUYGULANMATARIHI"]; }
            set { this["SONUYGULANMATARIHI"] = value; }
        }

        public int? PERFDAHILMI
        {
            get { return (int?)this["PERFDAHILMI"]; }
            set { this["PERFDAHILMI"] = value; }
        }

        public DateTime? OLUSTURULMATARIHI1
        {
            get { return (DateTime?)this["OLUSTURULMATARIHI1"]; }
            set { this["OLUSTURULMATARIHI1"] = value; }
        }

        public DateTime? GUNCELLENMETARIHI1
        {
            get { return (DateTime?)this["GUNCELLENMETARIHI1"]; }
            set { this["GUNCELLENMETARIHI1"] = value; }
        }

        protected SKRSCocukIzlemTakvimi(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SKRSCocukIzlemTakvimi(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SKRSCocukIzlemTakvimi(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SKRSCocukIzlemTakvimi(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SKRSCocukIzlemTakvimi(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SKRSCOCUKIZLEMTAKVIMI", dataRow) { }
        protected SKRSCocukIzlemTakvimi(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SKRSCOCUKIZLEMTAKVIMI", dataRow, isImported) { }
        public SKRSCocukIzlemTakvimi(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SKRSCocukIzlemTakvimi(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SKRSCocukIzlemTakvimi() : base() { }

    }
}

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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SKRSAsiTakvimi")] 

    /// <summary>
    /// c3ea7995-3959-50f5-e043-14031b0aa6d4
    /// </summary>
    public  partial class SKRSAsiTakvimi : BaseSKRSDefinition
    {
        public class SKRSAsiTakvimiList : TTObjectCollection<SKRSAsiTakvimi> { }
                    
        public class ChildSKRSAsiTakvimiCollection : TTObject.TTChildObjectCollection<SKRSAsiTakvimi>
        {
            public ChildSKRSAsiTakvimiCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSKRSAsiTakvimiCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSKRSAsiTakvimi_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSASITAKVIMI"].AllPropertyDefs["DEFAULT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSASITAKVIMI"].AllPropertyDefs["AKTIF"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSASITAKVIMI"].AllPropertyDefs["OLUSTURULMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSASITAKVIMI"].AllPropertyDefs["GUNCELLENMETARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSASITAKVIMI"].AllPropertyDefs["PASIFEALINMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSASITAKVIMI"].AllPropertyDefs["GUNCELLEMETARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSASITAKVIMI"].AllPropertyDefs["ADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? ASITURUKODU
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ASITURUKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSASITAKVIMI"].AllPropertyDefs["ASITURUKODU"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? DOZKODU
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOZKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSASITAKVIMI"].AllPropertyDefs["DOZKODU"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSASITAKVIMI"].AllPropertyDefs["ILKUYGULANMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSASITAKVIMI"].AllPropertyDefs["SONUYGULANMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSASITAKVIMI"].AllPropertyDefs["PERFDAHILMI"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? TAKVIMTIPI
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TAKVIMTIPI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSASITAKVIMI"].AllPropertyDefs["TAKVIMTIPI"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public GetSKRSAsiTakvimi_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSKRSAsiTakvimi_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSKRSAsiTakvimi_Class() : base() { }
        }

        public static BindingList<SKRSAsiTakvimi.GetSKRSAsiTakvimi_Class> GetSKRSAsiTakvimi(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSASITAKVIMI"].QueryDefs["GetSKRSAsiTakvimi"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSAsiTakvimi.GetSKRSAsiTakvimi_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SKRSAsiTakvimi.GetSKRSAsiTakvimi_Class> GetSKRSAsiTakvimi(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSASITAKVIMI"].QueryDefs["GetSKRSAsiTakvimi"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSAsiTakvimi.GetSKRSAsiTakvimi_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public string ADI
        {
            get { return (string)this["ADI"]; }
            set { this["ADI"] = value; }
        }

        public int? ASITURUKODU
        {
            get { return (int?)this["ASITURUKODU"]; }
            set { this["ASITURUKODU"] = value; }
        }

        public int? DOZKODU
        {
            get { return (int?)this["DOZKODU"]; }
            set { this["DOZKODU"] = value; }
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

        public int? TAKVIMTIPI
        {
            get { return (int?)this["TAKVIMTIPI"]; }
            set { this["TAKVIMTIPI"] = value; }
        }

        protected SKRSAsiTakvimi(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SKRSAsiTakvimi(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SKRSAsiTakvimi(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SKRSAsiTakvimi(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SKRSAsiTakvimi(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SKRSASITAKVIMI", dataRow) { }
        protected SKRSAsiTakvimi(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SKRSASITAKVIMI", dataRow, isImported) { }
        public SKRSAsiTakvimi(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SKRSAsiTakvimi(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SKRSAsiTakvimi() : base() { }

    }
}
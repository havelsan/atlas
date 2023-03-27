
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SKRSPersentil")] 

    /// <summary>
    /// c3eb0815-fe11-6223-e043-14031b0aef1e
    /// </summary>
    public  partial class SKRSPersentil : BaseSKRSDefinition
    {
        public class SKRSPersentilList : TTObjectCollection<SKRSPersentil> { }
                    
        public class ChildSKRSPersentilCollection : TTObject.TTChildObjectCollection<SKRSPersentil>
        {
            public ChildSKRSPersentilCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSKRSPersentilCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSKRSPersentil_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSPERSENTIL"].AllPropertyDefs["DEFAULT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSPERSENTIL"].AllPropertyDefs["AKTIF"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSPERSENTIL"].AllPropertyDefs["OLUSTURULMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSPERSENTIL"].AllPropertyDefs["GUNCELLENMETARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSPERSENTIL"].AllPropertyDefs["PASIFEALINMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSPERSENTIL"].AllPropertyDefs["GUNCELLEMETARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSPERSENTIL"].AllPropertyDefs["ADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? KODU
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSPERSENTIL"].AllPropertyDefs["KODU"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public int? ALTSINIR
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ALTSINIR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSPERSENTIL"].AllPropertyDefs["ALTSINIR"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public long? AY
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSPERSENTIL"].AllPropertyDefs["AY"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string BIRIM
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BIRIM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSPERSENTIL"].AllPropertyDefs["BIRIM"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? SEVIYE
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SEVIYE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSPERSENTIL"].AllPropertyDefs["SEVIYE"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? USTBOLUMKODU
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["USTBOLUMKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSPERSENTIL"].AllPropertyDefs["USTBOLUMKODU"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSPERSENTIL"].AllPropertyDefs["OLUSTURULMATARIHI1"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSPERSENTIL"].AllPropertyDefs["GUNCELLENMETARIHI1"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetSKRSPersentil_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSKRSPersentil_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSKRSPersentil_Class() : base() { }
        }

        public static BindingList<SKRSPersentil.GetSKRSPersentil_Class> GetSKRSPersentil(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSPERSENTIL"].QueryDefs["GetSKRSPersentil"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSPersentil.GetSKRSPersentil_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SKRSPersentil.GetSKRSPersentil_Class> GetSKRSPersentil(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSPERSENTIL"].QueryDefs["GetSKRSPersentil"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSPersentil.GetSKRSPersentil_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public string ADI
        {
            get { return (string)this["ADI"]; }
            set { this["ADI"] = value; }
        }

        public long? KODU
        {
            get { return (long?)this["KODU"]; }
            set { this["KODU"] = value; }
        }

        public int? ALTSINIR
        {
            get { return (int?)this["ALTSINIR"]; }
            set { this["ALTSINIR"] = value; }
        }

        public long? AY
        {
            get { return (long?)this["AY"]; }
            set { this["AY"] = value; }
        }

        public string BIRIM
        {
            get { return (string)this["BIRIM"]; }
            set { this["BIRIM"] = value; }
        }

        public int? SEVIYE
        {
            get { return (int?)this["SEVIYE"]; }
            set { this["SEVIYE"] = value; }
        }

        public int? USTBOLUMKODU
        {
            get { return (int?)this["USTBOLUMKODU"]; }
            set { this["USTBOLUMKODU"] = value; }
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

        protected SKRSPersentil(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SKRSPersentil(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SKRSPersentil(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SKRSPersentil(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SKRSPersentil(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SKRSPERSENTIL", dataRow) { }
        protected SKRSPersentil(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SKRSPERSENTIL", dataRow, isImported) { }
        public SKRSPersentil(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SKRSPersentil(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SKRSPersentil() : base() { }

    }
}
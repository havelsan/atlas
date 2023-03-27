
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SKRSGETATUygulandigiDurumlar")] 

    /// <summary>
    /// f74b3dc6-d1dc-46d6-90b8-1a1f93e4fcaa
    /// </summary>
    public  partial class SKRSGETATUygulandigiDurumlar : BaseSKRSDefinition
    {
        public class SKRSGETATUygulandigiDurumlarList : TTObjectCollection<SKRSGETATUygulandigiDurumlar> { }
                    
        public class ChildSKRSGETATUygulandigiDurumlarCollection : TTObject.TTChildObjectCollection<SKRSGETATUygulandigiDurumlar>
        {
            public ChildSKRSGETATUygulandigiDurumlarCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSKRSGETATUygulandigiDurumlarCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSKRSGETATUygulandigiDurumlar_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSGETATUYGULANDIGIDURUMLAR"].AllPropertyDefs["DEFAULT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSGETATUYGULANDIGIDURUMLAR"].AllPropertyDefs["AKTIF"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSGETATUYGULANDIGIDURUMLAR"].AllPropertyDefs["OLUSTURULMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSGETATUYGULANDIGIDURUMLAR"].AllPropertyDefs["GUNCELLENMETARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSGETATUYGULANDIGIDURUMLAR"].AllPropertyDefs["PASIFEALINMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSGETATUYGULANDIGIDURUMLAR"].AllPropertyDefs["GUNCELLEMETARIHI"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string UYGULANACAKDURUMLAR
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UYGULANACAKDURUMLAR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSGETATUYGULANDIGIDURUMLAR"].AllPropertyDefs["UYGULANACAKDURUMLAR"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSGETATUYGULANDIGIDURUMLAR"].AllPropertyDefs["KODU"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? MERKEZDEUYGULANABILMESI
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MERKEZDEUYGULANABILMESI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSGETATUYGULANDIGIDURUMLAR"].AllPropertyDefs["MERKEZDEUYGULANABILMESI"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? UNITEDEUYGULANABILMESI
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNITEDEUYGULANABILMESI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSGETATUYGULANDIGIDURUMLAR"].AllPropertyDefs["UNITEDEUYGULANABILMESI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSGETATUYGULANDIGIDURUMLAR"].AllPropertyDefs["OLUSTURULMATARIHI1"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSGETATUYGULANDIGIDURUMLAR"].AllPropertyDefs["GUNCELLENMETARIHI1"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetSKRSGETATUygulandigiDurumlar_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSKRSGETATUygulandigiDurumlar_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSKRSGETATUygulandigiDurumlar_Class() : base() { }
        }

        public static BindingList<SKRSGETATUygulandigiDurumlar.GetSKRSGETATUygulandigiDurumlar_Class> GetSKRSGETATUygulandigiDurumlar(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSGETATUYGULANDIGIDURUMLAR"].QueryDefs["GetSKRSGETATUygulandigiDurumlar"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSGETATUygulandigiDurumlar.GetSKRSGETATUygulandigiDurumlar_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SKRSGETATUygulandigiDurumlar.GetSKRSGETATUygulandigiDurumlar_Class> GetSKRSGETATUygulandigiDurumlar(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSGETATUYGULANDIGIDURUMLAR"].QueryDefs["GetSKRSGETATUygulandigiDurumlar"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSGETATUygulandigiDurumlar.GetSKRSGETATUygulandigiDurumlar_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public string UYGULANACAKDURUMLAR
        {
            get { return (string)this["UYGULANACAKDURUMLAR"]; }
            set { this["UYGULANACAKDURUMLAR"] = value; }
        }

        public int? KODU
        {
            get { return (int?)this["KODU"]; }
            set { this["KODU"] = value; }
        }

        public int? MERKEZDEUYGULANABILMESI
        {
            get { return (int?)this["MERKEZDEUYGULANABILMESI"]; }
            set { this["MERKEZDEUYGULANABILMESI"] = value; }
        }

        public int? UNITEDEUYGULANABILMESI
        {
            get { return (int?)this["UNITEDEUYGULANABILMESI"]; }
            set { this["UNITEDEUYGULANABILMESI"] = value; }
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

        protected SKRSGETATUygulandigiDurumlar(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SKRSGETATUygulandigiDurumlar(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SKRSGETATUygulandigiDurumlar(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SKRSGETATUygulandigiDurumlar(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SKRSGETATUygulandigiDurumlar(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SKRSGETATUYGULANDIGIDURUMLAR", dataRow) { }
        protected SKRSGETATUygulandigiDurumlar(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SKRSGETATUYGULANDIGIDURUMLAR", dataRow, isImported) { }
        public SKRSGETATUygulandigiDurumlar(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SKRSGETATUygulandigiDurumlar(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SKRSGETATUygulandigiDurumlar() : base() { }

    }
}
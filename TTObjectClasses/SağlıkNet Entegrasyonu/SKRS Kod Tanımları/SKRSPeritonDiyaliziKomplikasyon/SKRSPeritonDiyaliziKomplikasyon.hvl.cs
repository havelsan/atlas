
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SKRSPeritonDiyaliziKomplikasyon")] 

    /// <summary>
    /// feb54346-61ae-4c83-ae69-3c3fd159f47d
    /// </summary>
    public  partial class SKRSPeritonDiyaliziKomplikasyon : BaseSKRSCommonDef
    {
        public class SKRSPeritonDiyaliziKomplikasyonList : TTObjectCollection<SKRSPeritonDiyaliziKomplikasyon> { }
                    
        public class ChildSKRSPeritonDiyaliziKomplikasyonCollection : TTObject.TTChildObjectCollection<SKRSPeritonDiyaliziKomplikasyon>
        {
            public ChildSKRSPeritonDiyaliziKomplikasyonCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSKRSPeritonDiyaliziKomplikasyonCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSKRSPeritonDiyaliziKomplikasyon_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSPERITONDIYALIZIKOMPLIKASYON"].AllPropertyDefs["DEFAULT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSPERITONDIYALIZIKOMPLIKASYON"].AllPropertyDefs["AKTIF"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSPERITONDIYALIZIKOMPLIKASYON"].AllPropertyDefs["OLUSTURULMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSPERITONDIYALIZIKOMPLIKASYON"].AllPropertyDefs["GUNCELLENMETARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSPERITONDIYALIZIKOMPLIKASYON"].AllPropertyDefs["PASIFEALINMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSPERITONDIYALIZIKOMPLIKASYON"].AllPropertyDefs["GUNCELLEMETARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSPERITONDIYALIZIKOMPLIKASYON"].AllPropertyDefs["ADI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSPERITONDIYALIZIKOMPLIKASYON"].AllPropertyDefs["KODTIPIADI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSPERITONDIYALIZIKOMPLIKASYON"].AllPropertyDefs["KODU"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSPERITONDIYALIZIKOMPLIKASYON"].AllPropertyDefs["OLUSTURULMATARIHI1"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSPERITONDIYALIZIKOMPLIKASYON"].AllPropertyDefs["GUNCELLENMETARIHI1"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetSKRSPeritonDiyaliziKomplikasyon_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSKRSPeritonDiyaliziKomplikasyon_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSKRSPeritonDiyaliziKomplikasyon_Class() : base() { }
        }

        public static BindingList<SKRSPeritonDiyaliziKomplikasyon.GetSKRSPeritonDiyaliziKomplikasyon_Class> GetSKRSPeritonDiyaliziKomplikasyon(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSPERITONDIYALIZIKOMPLIKASYON"].QueryDefs["GetSKRSPeritonDiyaliziKomplikasyon"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSPeritonDiyaliziKomplikasyon.GetSKRSPeritonDiyaliziKomplikasyon_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SKRSPeritonDiyaliziKomplikasyon.GetSKRSPeritonDiyaliziKomplikasyon_Class> GetSKRSPeritonDiyaliziKomplikasyon(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSPERITONDIYALIZIKOMPLIKASYON"].QueryDefs["GetSKRSPeritonDiyaliziKomplikasyon"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSPeritonDiyaliziKomplikasyon.GetSKRSPeritonDiyaliziKomplikasyon_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        protected SKRSPeritonDiyaliziKomplikasyon(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SKRSPeritonDiyaliziKomplikasyon(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SKRSPeritonDiyaliziKomplikasyon(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SKRSPeritonDiyaliziKomplikasyon(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SKRSPeritonDiyaliziKomplikasyon(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SKRSPERITONDIYALIZIKOMPLIKASYON", dataRow) { }
        protected SKRSPeritonDiyaliziKomplikasyon(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SKRSPERITONDIYALIZIKOMPLIKASYON", dataRow, isImported) { }
        public SKRSPeritonDiyaliziKomplikasyon(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SKRSPeritonDiyaliziKomplikasyon(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SKRSPeritonDiyaliziKomplikasyon() : base() { }

    }
}
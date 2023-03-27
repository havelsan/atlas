
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SKRSDamarErisimYolu")] 

    /// <summary>
    /// 74c60a72-ef10-450a-9e95-0cdae6fe8490
    /// </summary>
    public  partial class SKRSDamarErisimYolu : BaseSKRSCommonDef
    {
        public class SKRSDamarErisimYoluList : TTObjectCollection<SKRSDamarErisimYolu> { }
                    
        public class ChildSKRSDamarErisimYoluCollection : TTObject.TTChildObjectCollection<SKRSDamarErisimYolu>
        {
            public ChildSKRSDamarErisimYoluCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSKRSDamarErisimYoluCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSKRSDamarErisimYolu_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSDAMARERISIMYOLU"].AllPropertyDefs["DEFAULT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSDAMARERISIMYOLU"].AllPropertyDefs["AKTIF"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSDAMARERISIMYOLU"].AllPropertyDefs["OLUSTURULMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSDAMARERISIMYOLU"].AllPropertyDefs["GUNCELLENMETARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSDAMARERISIMYOLU"].AllPropertyDefs["PASIFEALINMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSDAMARERISIMYOLU"].AllPropertyDefs["GUNCELLEMETARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSDAMARERISIMYOLU"].AllPropertyDefs["ADI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSDAMARERISIMYOLU"].AllPropertyDefs["KODTIPIADI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSDAMARERISIMYOLU"].AllPropertyDefs["KODU"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSDAMARERISIMYOLU"].AllPropertyDefs["OLUSTURULMATARIHI1"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSDAMARERISIMYOLU"].AllPropertyDefs["GUNCELLENMETARIHI1"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetSKRSDamarErisimYolu_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSKRSDamarErisimYolu_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSKRSDamarErisimYolu_Class() : base() { }
        }

        public static BindingList<SKRSDamarErisimYolu.GetSKRSDamarErisimYolu_Class> GetSKRSDamarErisimYolu(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSDAMARERISIMYOLU"].QueryDefs["GetSKRSDamarErisimYolu"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSDamarErisimYolu.GetSKRSDamarErisimYolu_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SKRSDamarErisimYolu.GetSKRSDamarErisimYolu_Class> GetSKRSDamarErisimYolu(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSDAMARERISIMYOLU"].QueryDefs["GetSKRSDamarErisimYolu"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSDamarErisimYolu.GetSKRSDamarErisimYolu_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        protected SKRSDamarErisimYolu(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SKRSDamarErisimYolu(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SKRSDamarErisimYolu(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SKRSDamarErisimYolu(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SKRSDamarErisimYolu(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SKRSDAMARERISIMYOLU", dataRow) { }
        protected SKRSDamarErisimYolu(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SKRSDAMARERISIMYOLU", dataRow, isImported) { }
        public SKRSDamarErisimYolu(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SKRSDamarErisimYolu(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SKRSDamarErisimYolu() : base() { }

    }
}
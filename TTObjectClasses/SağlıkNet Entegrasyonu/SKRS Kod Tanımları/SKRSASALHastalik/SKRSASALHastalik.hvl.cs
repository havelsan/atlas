
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SKRSASALHastalik")] 

    /// <summary>
    /// 94f19f91-41ed-4bf7-beed-de14090172d9
    /// </summary>
    public  partial class SKRSASALHastalik : BaseSKRSDefinition
    {
        public class SKRSASALHastalikList : TTObjectCollection<SKRSASALHastalik> { }
                    
        public class ChildSKRSASALHastalikCollection : TTObject.TTChildObjectCollection<SKRSASALHastalik>
        {
            public ChildSKRSASALHastalikCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSKRSASALHastalikCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSKRSASALHastalik_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSASALHASTALIK"].AllPropertyDefs["DEFAULT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSASALHASTALIK"].AllPropertyDefs["AKTIF"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSASALHASTALIK"].AllPropertyDefs["OLUSTURULMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSASALHASTALIK"].AllPropertyDefs["GUNCELLENMETARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSASALHASTALIK"].AllPropertyDefs["PASIFEALINMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSASALHASTALIK"].AllPropertyDefs["GUNCELLEMETARIHI"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public int? KOD
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KOD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSASALHASTALIK"].AllPropertyDefs["KOD"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string ASALKOD
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ASALKOD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSASALHASTALIK"].AllPropertyDefs["ASALKOD"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ASALKODADI
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ASALKODADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSASALHASTALIK"].AllPropertyDefs["ASALKODADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetSKRSASALHastalik_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSKRSASALHastalik_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSKRSASALHastalik_Class() : base() { }
        }

        public static BindingList<SKRSASALHastalik.GetSKRSASALHastalik_Class> GetSKRSASALHastalik(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSASALHASTALIK"].QueryDefs["GetSKRSASALHastalik"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSASALHastalik.GetSKRSASALHastalik_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SKRSASALHastalik.GetSKRSASALHastalik_Class> GetSKRSASALHastalik(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSASALHASTALIK"].QueryDefs["GetSKRSASALHastalik"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSASALHastalik.GetSKRSASALHastalik_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public int? KOD
        {
            get { return (int?)this["KOD"]; }
            set { this["KOD"] = value; }
        }

        public string ASALKOD
        {
            get { return (string)this["ASALKOD"]; }
            set { this["ASALKOD"] = value; }
        }

        public string ASALKODADI
        {
            get { return (string)this["ASALKODADI"]; }
            set { this["ASALKODADI"] = value; }
        }

        protected SKRSASALHastalik(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SKRSASALHastalik(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SKRSASALHastalik(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SKRSASALHastalik(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SKRSASALHastalik(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SKRSASALHASTALIK", dataRow) { }
        protected SKRSASALHastalik(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SKRSASALHASTALIK", dataRow, isImported) { }
        public SKRSASALHastalik(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SKRSASALHastalik(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SKRSASALHastalik() : base() { }

    }
}
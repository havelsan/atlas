
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SKRSIlac")] 

    /// <summary>
    /// c3eab581-ae56-5807-e043-14031b0acb40
    /// </summary>
    public  partial class SKRSIlac : BaseSKRSDefinition
    {
        public class SKRSIlacList : TTObjectCollection<SKRSIlac> { }
                    
        public class ChildSKRSIlacCollection : TTObject.TTChildObjectCollection<SKRSIlac>
        {
            public ChildSKRSIlacCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSKRSIlacCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSKRSIlac_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSILAC"].AllPropertyDefs["DEFAULT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSILAC"].AllPropertyDefs["AKTIF"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSILAC"].AllPropertyDefs["OLUSTURULMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSILAC"].AllPropertyDefs["GUNCELLENMETARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSILAC"].AllPropertyDefs["PASIFEALINMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSILAC"].AllPropertyDefs["GUNCELLEMETARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSILAC"].AllPropertyDefs["ADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string BARKODU
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BARKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSILAC"].AllPropertyDefs["BARKODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? FIYAT
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FIYAT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSILAC"].AllPropertyDefs["FIYAT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? GERIODEME
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GERIODEME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSILAC"].AllPropertyDefs["GERIODEME"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? RECETETURU
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RECETETURU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSILAC"].AllPropertyDefs["RECETETURU"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string FIRMAADI
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FIRMAADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSILAC"].AllPropertyDefs["FIRMAADI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSILAC"].AllPropertyDefs["OLUSTURULMATARIHI1"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSILAC"].AllPropertyDefs["GUNCELLENMETARIHI1"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string ATCKODU
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ATCKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSILAC"].AllPropertyDefs["ATCKODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ATCADI
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ATCADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSILAC"].AllPropertyDefs["ATCADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetSKRSIlac_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSKRSIlac_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSKRSIlac_Class() : base() { }
        }

        public static BindingList<SKRSIlac.GetSKRSIlac_Class> GetSKRSIlac(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSILAC"].QueryDefs["GetSKRSIlac"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSIlac.GetSKRSIlac_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SKRSIlac.GetSKRSIlac_Class> GetSKRSIlac(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSILAC"].QueryDefs["GetSKRSIlac"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSIlac.GetSKRSIlac_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SKRSIlac> GetByBarkodu(TTObjectContext objectContext, string BARKODU)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSILAC"].QueryDefs["GetByBarkodu"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("BARKODU", BARKODU);

            return ((ITTQuery)objectContext).QueryObjects<SKRSIlac>(queryDef, paramList);
        }

        public string ADI
        {
            get { return (string)this["ADI"]; }
            set { this["ADI"] = value; }
        }

        public string BARKODU
        {
            get { return (string)this["BARKODU"]; }
            set { this["BARKODU"] = value; }
        }

        public int? FIYAT
        {
            get { return (int?)this["FIYAT"]; }
            set { this["FIYAT"] = value; }
        }

        public int? GERIODEME
        {
            get { return (int?)this["GERIODEME"]; }
            set { this["GERIODEME"] = value; }
        }

        public int? RECETETURU
        {
            get { return (int?)this["RECETETURU"]; }
            set { this["RECETETURU"] = value; }
        }

        public string FIRMAADI
        {
            get { return (string)this["FIRMAADI"]; }
            set { this["FIRMAADI"] = value; }
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

        public string ATCKODU
        {
            get { return (string)this["ATCKODU"]; }
            set { this["ATCKODU"] = value; }
        }

        public string ATCADI
        {
            get { return (string)this["ATCADI"]; }
            set { this["ATCADI"] = value; }
        }

        protected SKRSIlac(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SKRSIlac(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SKRSIlac(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SKRSIlac(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SKRSIlac(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SKRSILAC", dataRow) { }
        protected SKRSIlac(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SKRSILAC", dataRow, isImported) { }
        public SKRSIlac(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SKRSIlac(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SKRSIlac() : base() { }

    }
}
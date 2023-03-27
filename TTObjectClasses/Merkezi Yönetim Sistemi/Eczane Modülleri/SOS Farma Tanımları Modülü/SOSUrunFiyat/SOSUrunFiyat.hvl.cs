
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SOSUrunFiyat")] 

    public  partial class SOSUrunFiyat : TerminologyManagerDef
    {
        public class SOSUrunFiyatList : TTObjectCollection<SOSUrunFiyat> { }
                    
        public class ChildSOSUrunFiyatCollection : TTObject.TTChildObjectCollection<SOSUrunFiyat>
        {
            public ChildSOSUrunFiyatCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSOSUrunFiyatCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetLastPriceNQL_Class : TTReportNqlObject 
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

            public DateTime? StartDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STARTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOSURUNFIYAT"].AllPropertyDefs["STARTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? EndDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ENDDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOSURUNFIYAT"].AllPropertyDefs["ENDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? DealDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DEALDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOSURUNFIYAT"].AllPropertyDefs["DEALDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Currency? Price
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOSURUNFIYAT"].AllPropertyDefs["PRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public SOSFiyatTurEnum? PriceType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRICETYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOSURUNFIYAT"].AllPropertyDefs["PRICETYPE"].DataType;
                    return (SOSFiyatTurEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public long? SOSID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SOSID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOSURUNFIYAT"].AllPropertyDefs["SOSID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public GetLastPriceNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetLastPriceNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetLastPriceNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class GetLastKDVNQL_Class : TTReportNqlObject 
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

            public DateTime? StartDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STARTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOSURUNFIYAT"].AllPropertyDefs["STARTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? EndDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ENDDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOSURUNFIYAT"].AllPropertyDefs["ENDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? DealDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DEALDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOSURUNFIYAT"].AllPropertyDefs["DEALDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Currency? Price
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOSURUNFIYAT"].AllPropertyDefs["PRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public SOSFiyatTurEnum? PriceType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRICETYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOSURUNFIYAT"].AllPropertyDefs["PRICETYPE"].DataType;
                    return (SOSFiyatTurEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public long? SOSID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SOSID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOSURUNFIYAT"].AllPropertyDefs["SOSID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public GetLastKDVNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetLastKDVNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetLastKDVNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class GetLasDiscountNQL_Class : TTReportNqlObject 
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

            public DateTime? StartDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STARTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOSURUNFIYAT"].AllPropertyDefs["STARTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? EndDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ENDDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOSURUNFIYAT"].AllPropertyDefs["ENDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? DealDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DEALDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOSURUNFIYAT"].AllPropertyDefs["DEALDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Currency? Price
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOSURUNFIYAT"].AllPropertyDefs["PRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public SOSFiyatTurEnum? PriceType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRICETYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOSURUNFIYAT"].AllPropertyDefs["PRICETYPE"].DataType;
                    return (SOSFiyatTurEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public long? SOSID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SOSID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOSURUNFIYAT"].AllPropertyDefs["SOSID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public GetLasDiscountNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetLasDiscountNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetLasDiscountNQL_Class() : base() { }
        }

        public static BindingList<SOSUrunFiyat.GetLastPriceNQL_Class> GetLastPriceNQL(Guid SOSURUNID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SOSURUNFIYAT"].QueryDefs["GetLastPriceNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SOSURUNID", SOSURUNID);

            return TTReportNqlObject.QueryObjects<SOSUrunFiyat.GetLastPriceNQL_Class>(queryDef, paramList, pi);
        }

        public static BindingList<SOSUrunFiyat.GetLastPriceNQL_Class> GetLastPriceNQL(TTObjectContext objectContext, Guid SOSURUNID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SOSURUNFIYAT"].QueryDefs["GetLastPriceNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SOSURUNID", SOSURUNID);

            return TTReportNqlObject.QueryObjects<SOSUrunFiyat.GetLastPriceNQL_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<SOSUrunFiyat.GetLastKDVNQL_Class> GetLastKDVNQL(Guid SOSURUNID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SOSURUNFIYAT"].QueryDefs["GetLastKDVNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SOSURUNID", SOSURUNID);

            return TTReportNqlObject.QueryObjects<SOSUrunFiyat.GetLastKDVNQL_Class>(queryDef, paramList, pi);
        }

        public static BindingList<SOSUrunFiyat.GetLastKDVNQL_Class> GetLastKDVNQL(TTObjectContext objectContext, Guid SOSURUNID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SOSURUNFIYAT"].QueryDefs["GetLastKDVNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SOSURUNID", SOSURUNID);

            return TTReportNqlObject.QueryObjects<SOSUrunFiyat.GetLastKDVNQL_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<SOSUrunFiyat.GetLasDiscountNQL_Class> GetLasDiscountNQL(Guid SOSURUNID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SOSURUNFIYAT"].QueryDefs["GetLasDiscountNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SOSURUNID", SOSURUNID);

            return TTReportNqlObject.QueryObjects<SOSUrunFiyat.GetLasDiscountNQL_Class>(queryDef, paramList, pi);
        }

        public static BindingList<SOSUrunFiyat.GetLasDiscountNQL_Class> GetLasDiscountNQL(TTObjectContext objectContext, Guid SOSURUNID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SOSURUNFIYAT"].QueryDefs["GetLasDiscountNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SOSURUNID", SOSURUNID);

            return TTReportNqlObject.QueryObjects<SOSUrunFiyat.GetLasDiscountNQL_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Başlangıç Tarihi
    /// </summary>
        public DateTime? StartDate
        {
            get { return (DateTime?)this["STARTDATE"]; }
            set { this["STARTDATE"] = value; }
        }

    /// <summary>
    /// Bitiş Tarihi
    /// </summary>
        public DateTime? EndDate
        {
            get { return (DateTime?)this["ENDDATE"]; }
            set { this["ENDDATE"] = value; }
        }

    /// <summary>
    /// Anlaşma Tarihi
    /// </summary>
        public DateTime? DealDate
        {
            get { return (DateTime?)this["DEALDATE"]; }
            set { this["DEALDATE"] = value; }
        }

    /// <summary>
    /// Fiyat
    /// </summary>
        public Currency? Price
        {
            get { return (Currency?)this["PRICE"]; }
            set { this["PRICE"] = value; }
        }

    /// <summary>
    /// Fiyat Türü
    /// </summary>
        public SOSFiyatTurEnum? PriceType
        {
            get { return (SOSFiyatTurEnum?)(int?)this["PRICETYPE"]; }
            set { this["PRICETYPE"] = value; }
        }

        public long? SOSID
        {
            get { return (long?)this["SOSID"]; }
            set { this["SOSID"] = value; }
        }

        public SOSUrunBilgisi SOSUrunBilgisi
        {
            get { return (SOSUrunBilgisi)((ITTObject)this).GetParent("SOSURUNBILGISI"); }
            set { this["SOSURUNBILGISI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected SOSUrunFiyat(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SOSUrunFiyat(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SOSUrunFiyat(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SOSUrunFiyat(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SOSUrunFiyat(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SOSURUNFIYAT", dataRow) { }
        protected SOSUrunFiyat(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SOSURUNFIYAT", dataRow, isImported) { }
        public SOSUrunFiyat(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SOSUrunFiyat(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SOSUrunFiyat() : base() { }

    }
}

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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="OldPurchase")] 

    /// <summary>
    /// Yaklaşık Maliyet Hesabı İçin Kullanılan Eski Alımların Bilgilerini Tutan Sınıftır
    /// </summary>
    public  partial class OldPurchase : TTObject
    {
        public class OldPurchaseList : TTObjectCollection<OldPurchase> { }
                    
        public class ChildOldPurchaseCollection : TTObject.TTChildObjectCollection<OldPurchase>
        {
            public ChildOldPurchaseCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildOldPurchaseCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetOldPurchases_Class : TTReportNqlObject 
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

            public double? CurrentPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CURRENTPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OLDPURCHASE"].AllPropertyDefs["CURRENTPRICE"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public double? UnitPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNITPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OLDPURCHASE"].AllPropertyDefs["UNITPRICE"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public bool? IncludeFormulation
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INCLUDEFORMULATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OLDPURCHASE"].AllPropertyDefs["INCLUDEFORMULATION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public double? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OLDPURCHASE"].AllPropertyDefs["AMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public DateTime? PurchaseDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PURCHASEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OLDPURCHASE"].AllPropertyDefs["PURCHASEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Suplliername
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUPLLIERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUPPLIER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetOldPurchases_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetOldPurchases_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetOldPurchases_Class() : base() { }
        }

        public static class States
        {
            public static Guid Cancelled { get { return new Guid("1220bf10-9a31-4eeb-8637-207109a607ca"); } }
            public static Guid New { get { return new Guid("f73d93da-ab32-4570-9d69-5601c62f4c61"); } }
        }

        public static BindingList<OldPurchase.GetOldPurchases_Class> GetOldPurchases(string PURCHASEITEMDEF, string TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["OLDPURCHASE"].QueryDefs["GetOldPurchases"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PURCHASEITEMDEF", PURCHASEITEMDEF);
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<OldPurchase.GetOldPurchases_Class>(queryDef, paramList, pi);
        }

        public static BindingList<OldPurchase.GetOldPurchases_Class> GetOldPurchases(TTObjectContext objectContext, string PURCHASEITEMDEF, string TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["OLDPURCHASE"].QueryDefs["GetOldPurchases"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PURCHASEITEMDEF", PURCHASEITEMDEF);
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<OldPurchase.GetOldPurchases_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Güncel Fiyat
    /// </summary>
        public double? CurrentPrice
        {
            get { return (double?)this["CURRENTPRICE"]; }
            set { this["CURRENTPRICE"] = value; }
        }

    /// <summary>
    /// Birim Fiyatı
    /// </summary>
        public double? UnitPrice
        {
            get { return (double?)this["UNITPRICE"]; }
            set { this["UNITPRICE"] = value; }
        }

    /// <summary>
    /// Ort.Dahil
    /// </summary>
        public bool? IncludeFormulation
        {
            get { return (bool?)this["INCLUDEFORMULATION"]; }
            set { this["INCLUDEFORMULATION"] = value; }
        }

    /// <summary>
    /// Miktar
    /// </summary>
        public double? Amount
        {
            get { return (double?)this["AMOUNT"]; }
            set { this["AMOUNT"] = value; }
        }

    /// <summary>
    /// Alım Tarihi
    /// </summary>
        public DateTime? PurchaseDate
        {
            get { return (DateTime?)this["PURCHASEDATE"]; }
            set { this["PURCHASEDATE"] = value; }
        }

        public Supplier Supplier
        {
            get { return (Supplier)((ITTObject)this).GetParent("SUPPLIER"); }
            set { this["SUPPLIER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public PurchaseProjectDetail PurchaseProjectDetail
        {
            get { return (PurchaseProjectDetail)((ITTObject)this).GetParent("PURCHASEPROJECTDETAIL"); }
            set { this["PURCHASEPROJECTDETAIL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Alımı Yapan Birim
    /// </summary>
        public ProcurementUnitDef ProcurementUnitDef
        {
            get { return (ProcurementUnitDef)((ITTObject)this).GetParent("PROCUREMENTUNITDEF"); }
            set { this["PROCUREMENTUNITDEF"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected OldPurchase(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected OldPurchase(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected OldPurchase(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected OldPurchase(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected OldPurchase(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "OLDPURCHASE", dataRow) { }
        protected OldPurchase(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "OLDPURCHASE", dataRow, isImported) { }
        public OldPurchase(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public OldPurchase(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public OldPurchase() : base() { }

        override protected void RunPreTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePreScript(transDef))
                base.RunPreTransition(transDef.BaseTransDef);
            this.PreTransition(transDef);
        }
        override protected void RunPostTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePostScript(transDef))
                base.RunPostTransition(transDef.BaseTransDef);
            this.PostTransition(transDef);
        }
        override protected void RunUndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBaseUndoScript(transDef))
                base.RunUndoTransition(transDef.BaseTransDef);
            this.UndoTransition(transDef);
        }
    }
}
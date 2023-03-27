
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PublicPurchasesForFormulation")] 

    /// <summary>
    /// Mahalli Satınalmada Fiyat Tespiti İçin Kullanılan "Kamu Kurum Alımları" İçin Kullanılan Sınıftır
    /// </summary>
    public  partial class PublicPurchasesForFormulation : TTObject
    {
        public class PublicPurchasesForFormulationList : TTObjectCollection<PublicPurchasesForFormulation> { }
                    
        public class ChildPublicPurchasesForFormulationCollection : TTObject.TTChildObjectCollection<PublicPurchasesForFormulation>
        {
            public ChildPublicPurchasesForFormulationCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPublicPurchasesForFormulationCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetPublicPurchasesByProjectID_Class : TTReportNqlObject 
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

            public bool? IncludeFormulation
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INCLUDEFORMULATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PUBLICPURCHASESFORFORMULATION"].AllPropertyDefs["INCLUDEFORMULATION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public double? CurrentPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CURRENTPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PUBLICPURCHASESFORFORMULATION"].AllPropertyDefs["CURRENTPRICE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EXTERNALPURCHASEDEFINITION"].AllPropertyDefs["PURCHASEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Currency? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EXTERNALPURCHASEDEFINITION"].AllPropertyDefs["AMOUNT"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public BigCurrency? UnitPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNITPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EXTERNALPURCHASEDEFINITION"].AllPropertyDefs["UNITPRICE"].DataType;
                    return (BigCurrency?)dataType.ConvertValue(val);
                }
            }

            public string PurchasedBy
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PURCHASEDBY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EXTERNALPURCHASEDEFINITION"].AllPropertyDefs["PURCHASEDBY"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Supplier
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUPPLIER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUPPLIER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetPublicPurchasesByProjectID_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPublicPurchasesByProjectID_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPublicPurchasesByProjectID_Class() : base() { }
        }

        public static BindingList<PublicPurchasesForFormulation.GetPublicPurchasesByProjectID_Class> GetPublicPurchasesByProjectID(string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PUBLICPURCHASESFORFORMULATION"].QueryDefs["GetPublicPurchasesByProjectID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<PublicPurchasesForFormulation.GetPublicPurchasesByProjectID_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PublicPurchasesForFormulation.GetPublicPurchasesByProjectID_Class> GetPublicPurchasesByProjectID(TTObjectContext objectContext, string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PUBLICPURCHASESFORFORMULATION"].QueryDefs["GetPublicPurchasesByProjectID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<PublicPurchasesForFormulation.GetPublicPurchasesByProjectID_Class>(objectContext, queryDef, paramList, pi);
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
    /// Güncel Fiyat
    /// </summary>
        public double? CurrentPrice
        {
            get { return (double?)this["CURRENTPRICE"]; }
            set { this["CURRENTPRICE"] = value; }
        }

        public PurchaseProjectDetail PurchaseProjectDetail
        {
            get { return (PurchaseProjectDetail)((ITTObject)this).GetParent("PURCHASEPROJECTDETAIL"); }
            set { this["PURCHASEPROJECTDETAIL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ExternalPurchaseDefinition ExternalPurchaseDefinition
        {
            get { return (ExternalPurchaseDefinition)((ITTObject)this).GetParent("EXTERNALPURCHASEDEFINITION"); }
            set { this["EXTERNALPURCHASEDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected PublicPurchasesForFormulation(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PublicPurchasesForFormulation(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PublicPurchasesForFormulation(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PublicPurchasesForFormulation(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PublicPurchasesForFormulation(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PUBLICPURCHASESFORFORMULATION", dataRow) { }
        protected PublicPurchasesForFormulation(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PUBLICPURCHASESFORFORMULATION", dataRow, isImported) { }
        public PublicPurchasesForFormulation(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PublicPurchasesForFormulation(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PublicPurchasesForFormulation() : base() { }

    }
}
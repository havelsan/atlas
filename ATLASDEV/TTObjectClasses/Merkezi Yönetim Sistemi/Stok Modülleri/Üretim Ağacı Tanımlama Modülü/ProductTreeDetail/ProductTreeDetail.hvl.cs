
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ProductTreeDetail")] 

    public  partial class ProductTreeDetail : TTObject
    {
        public class ProductTreeDetailList : TTObjectCollection<ProductTreeDetail> { }
                    
        public class ChildProductTreeDetailCollection : TTObject.TTChildObjectCollection<ProductTreeDetail>
        {
            public ChildProductTreeDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildProductTreeDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetIBFAmountReportQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public double? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRODUCTTREEDETAIL"].AllPropertyDefs["AMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public Object Inheld
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["INHELD"]);
                }
            }

            public GetIBFAmountReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetIBFAmountReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetIBFAmountReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetProdutTreeDetailByID_Class : TTReportNqlObject 
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

            public double? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRODUCTTREEDETAIL"].AllPropertyDefs["AMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public Currency? Inheld
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INHELD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCK"].AllPropertyDefs["INHELD"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public GetProdutTreeDetailByID_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetProdutTreeDetailByID_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetProdutTreeDetailByID_Class() : base() { }
        }

        public static BindingList<ProductTreeDetail.GetIBFAmountReportQuery_Class> GetIBFAmountReportQuery(string TTOBJECTID, string MAINSTOREID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRODUCTTREEDETAIL"].QueryDefs["GetIBFAmountReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);
            paramList.Add("MAINSTOREID", MAINSTOREID);

            return TTReportNqlObject.QueryObjects<ProductTreeDetail.GetIBFAmountReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ProductTreeDetail.GetIBFAmountReportQuery_Class> GetIBFAmountReportQuery(TTObjectContext objectContext, string TTOBJECTID, string MAINSTOREID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRODUCTTREEDETAIL"].QueryDefs["GetIBFAmountReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);
            paramList.Add("MAINSTOREID", MAINSTOREID);

            return TTReportNqlObject.QueryObjects<ProductTreeDetail.GetIBFAmountReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ProductTreeDetail.GetProdutTreeDetailByID_Class> GetProdutTreeDetailByID(Guid OBJECTID, string MAINSTOREID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRODUCTTREEDETAIL"].QueryDefs["GetProdutTreeDetailByID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);
            paramList.Add("MAINSTOREID", MAINSTOREID);

            return TTReportNqlObject.QueryObjects<ProductTreeDetail.GetProdutTreeDetailByID_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ProductTreeDetail.GetProdutTreeDetailByID_Class> GetProdutTreeDetailByID(TTObjectContext objectContext, Guid OBJECTID, string MAINSTOREID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRODUCTTREEDETAIL"].QueryDefs["GetProdutTreeDetailByID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);
            paramList.Add("MAINSTOREID", MAINSTOREID);

            return TTReportNqlObject.QueryObjects<ProductTreeDetail.GetProdutTreeDetailByID_Class>(objectContext, queryDef, paramList, pi);
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
    /// Sarf Edilebilir Malzeme
    /// </summary>
        public ConsumableMaterialDefinition ConsumableMaterial
        {
            get { return (ConsumableMaterialDefinition)((ITTObject)this).GetParent("CONSUMABLEMATERIAL"); }
            set { this["CONSUMABLEMATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Ürün Ağacı Detayları
    /// </summary>
        public ProductTreeDefinition ProductTreeDefinition
        {
            get { return (ProductTreeDefinition)((ITTObject)this).GetParent("PRODUCTTREEDEFINITION"); }
            set { this["PRODUCTTREEDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ProductTreeDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ProductTreeDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ProductTreeDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ProductTreeDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ProductTreeDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PRODUCTTREEDETAIL", dataRow) { }
        protected ProductTreeDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PRODUCTTREEDETAIL", dataRow, isImported) { }
        public ProductTreeDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ProductTreeDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ProductTreeDetail() : base() { }

    }
}

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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="StockGuideCard")] 

    /// <summary>
    /// Stok Bilgi (Kılavuz) Kartı Tanımları
    /// </summary>
    public  partial class StockGuideCard : TTDefinitionSet
    {
        public class StockGuideCardList : TTObjectCollection<StockGuideCard> { }
                    
        public class ChildStockGuideCardCollection : TTObject.TTChildObjectCollection<StockGuideCard>
        {
            public ChildStockGuideCardCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildStockGuideCardCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetStockGuideCard_Class : TTReportNqlObject 
        {
            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKGUIDECARD"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKGUIDECARD"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetStockGuideCard_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetStockGuideCard_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetStockGuideCard_Class() : base() { }
        }

        [Serializable] 

        public partial class GetAllStockGuideCard_Class : TTReportNqlObject 
        {
            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKGUIDECARD"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKGUIDECARD"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? StockCard
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STOCKCARD"]);
                }
            }

            public GetAllStockGuideCard_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetAllStockGuideCard_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetAllStockGuideCard_Class() : base() { }
        }

        [Serializable] 

        public partial class GetStockGuideCardDetails_Class : TTReportNqlObject 
        {
            public string Stockcardname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STOCKCARDNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string NATOStockNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NATOSTOCKNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["NATOSTOCKNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public double? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKGUIDECARDDETAIL"].AllPropertyDefs["AMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public GetStockGuideCardDetails_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetStockGuideCardDetails_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetStockGuideCardDetails_Class() : base() { }
        }

        [Serializable] 

        public partial class GetStockGuideCardDetailsRpt_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Nsnno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NSNNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["NATOSTOCKNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Materialname
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MATERIALNAME"]);
                }
            }

            public Currency? Toplammiktar
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOPLAMMIKTAR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCK"].AllPropertyDefs["INHELD"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public GetStockGuideCardDetailsRpt_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetStockGuideCardDetailsRpt_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetStockGuideCardDetailsRpt_Class() : base() { }
        }

        public static BindingList<StockGuideCard.GetStockGuideCard_Class> GetStockGuideCard(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKGUIDECARD"].QueryDefs["GetStockGuideCard"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<StockGuideCard.GetStockGuideCard_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<StockGuideCard.GetStockGuideCard_Class> GetStockGuideCard(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKGUIDECARD"].QueryDefs["GetStockGuideCard"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<StockGuideCard.GetStockGuideCard_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<StockGuideCard.GetAllStockGuideCard_Class> GetAllStockGuideCard(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKGUIDECARD"].QueryDefs["GetAllStockGuideCard"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<StockGuideCard.GetAllStockGuideCard_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockGuideCard.GetAllStockGuideCard_Class> GetAllStockGuideCard(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKGUIDECARD"].QueryDefs["GetAllStockGuideCard"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<StockGuideCard.GetAllStockGuideCard_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<StockGuideCard.GetStockGuideCardDetails_Class> GetStockGuideCardDetails(Guid OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKGUIDECARD"].QueryDefs["GetStockGuideCardDetails"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<StockGuideCard.GetStockGuideCardDetails_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockGuideCard.GetStockGuideCardDetails_Class> GetStockGuideCardDetails(TTObjectContext objectContext, Guid OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKGUIDECARD"].QueryDefs["GetStockGuideCardDetails"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<StockGuideCard.GetStockGuideCardDetails_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<StockGuideCard.GetStockGuideCardDetailsRpt_Class> GetStockGuideCardDetailsRpt(Guid STORE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKGUIDECARD"].QueryDefs["GetStockGuideCardDetailsRpt"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STORE", STORE);

            return TTReportNqlObject.QueryObjects<StockGuideCard.GetStockGuideCardDetailsRpt_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockGuideCard.GetStockGuideCardDetailsRpt_Class> GetStockGuideCardDetailsRpt(TTObjectContext objectContext, Guid STORE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKGUIDECARD"].QueryDefs["GetStockGuideCardDetailsRpt"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STORE", STORE);

            return TTReportNqlObject.QueryObjects<StockGuideCard.GetStockGuideCardDetailsRpt_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Kısa Açıklama
    /// </summary>
        public string ShortDescription
        {
            get { return (string)this["SHORTDESCRIPTION"]; }
            set { this["SHORTDESCRIPTION"] = value; }
        }

    /// <summary>
    /// Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

        public string Description_Shadow
        {
            get { return (string)this["DESCRIPTION_SHADOW"]; }
        }

        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
        }

        public StockCard StockCard
        {
            get { return (StockCard)((ITTObject)this).GetParent("STOCKCARD"); }
            set { this["STOCKCARD"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateStockGuideCardDetailsCollection()
        {
            _StockGuideCardDetails = new StockGuideCardDetail.ChildStockGuideCardDetailCollection(this, new Guid("01e75bc0-627b-4936-ac09-e686fc425ba7"));
            ((ITTChildObjectCollection)_StockGuideCardDetails).GetChildren();
        }

        protected StockGuideCardDetail.ChildStockGuideCardDetailCollection _StockGuideCardDetails = null;
        public StockGuideCardDetail.ChildStockGuideCardDetailCollection StockGuideCardDetails
        {
            get
            {
                if (_StockGuideCardDetails == null)
                    CreateStockGuideCardDetailsCollection();
                return _StockGuideCardDetails;
            }
        }

        protected StockGuideCard(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected StockGuideCard(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected StockGuideCard(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected StockGuideCard(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected StockGuideCard(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "STOCKGUIDECARD", dataRow) { }
        protected StockGuideCard(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "STOCKGUIDECARD", dataRow, isImported) { }
        public StockGuideCard(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public StockGuideCard(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public StockGuideCard() : base() { }

    }
}
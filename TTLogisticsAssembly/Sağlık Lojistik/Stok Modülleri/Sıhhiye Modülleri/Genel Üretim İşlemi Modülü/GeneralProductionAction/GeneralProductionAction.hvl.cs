
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="GeneralProductionAction")] 

    /// <summary>
    /// Genel Üretim İşlemi
    /// </summary>
    public  partial class GeneralProductionAction : StockAction, IGeneralProductionAction, IStockOutTransaction, ICheckStockActionOutDetail, IAutoDocumentRecordLog, IStockInTransaction
    {
        public class GeneralProductionActionList : TTObjectCollection<GeneralProductionAction> { }
                    
        public class ChildGeneralProductionActionCollection : TTObject.TTChildObjectCollection<GeneralProductionAction>
        {
            public ChildGeneralProductionActionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildGeneralProductionActionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GeneralProductionReportQuery_Class : TTReportNqlObject 
        {
            public string Consumptionmaterialname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CONSUMPTIONMATERIALNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Consumptionmaterialnsn
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CONSUMPTIONMATERIALNSN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["NATOSTOCKNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Currency? Consumptionmaterialamount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CONSUMPTIONMATERIALAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["GENERALPRODUCTIONOUTDET"].AllPropertyDefs["AMOUNT"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Guid? Conmaterialdistributiontype
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CONMATERIALDISTRIBUTIONTYPE"]);
                }
            }

            public GeneralProductionReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GeneralProductionReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GeneralProductionReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GeneralProductionReportQuery2_Class : TTReportNqlObject 
        {
            public long? StockActionID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STOCKACTIONID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["GENERALPRODUCTIONACTION"].AllPropertyDefs["STOCKACTIONID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Nsn
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NSN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["NATOSTOCKNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Currency? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["GENERALPRODUCTIONACTION"].AllPropertyDefs["AMOUNT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["GENERALPRODUCTIONACTION"].AllPropertyDefs["UNITPRICE"].DataType;
                    return (BigCurrency?)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["GENERALPRODUCTIONACTION"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? TransactionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TRANSACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["GENERALPRODUCTIONACTION"].AllPropertyDefs["TRANSACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? Disttype
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DISTTYPE"]);
                }
            }

            public GeneralProductionReportQuery2_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GeneralProductionReportQuery2_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GeneralProductionReportQuery2_Class() : base() { }
        }

        new public static class States
        {
    /// <summary>
    /// İptal Edildi
    /// </summary>
            public static Guid Cancelled { get { return new Guid("018ab12f-3f8b-4d37-9177-8e1472b1d557"); } }
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("eb1e625a-77ec-48ac-abc1-0f4213e1360a"); } }
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("ecd22b93-95c9-44e1-adcd-392f0442e2e7"); } }
    /// <summary>
    /// Onay
    /// </summary>
            public static Guid Approval { get { return new Guid("4b2bbe34-892a-41ed-9aaa-3abe99562a3f"); } }
        }

        public static BindingList<GeneralProductionAction.GeneralProductionReportQuery_Class> GeneralProductionReportQuery(Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["GENERALPRODUCTIONACTION"].QueryDefs["GeneralProductionReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<GeneralProductionAction.GeneralProductionReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<GeneralProductionAction.GeneralProductionReportQuery_Class> GeneralProductionReportQuery(TTObjectContext objectContext, Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["GENERALPRODUCTIONACTION"].QueryDefs["GeneralProductionReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<GeneralProductionAction.GeneralProductionReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<GeneralProductionAction.GeneralProductionReportQuery2_Class> GeneralProductionReportQuery2(Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["GENERALPRODUCTIONACTION"].QueryDefs["GeneralProductionReportQuery2"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<GeneralProductionAction.GeneralProductionReportQuery2_Class>(queryDef, paramList, pi);
        }

        public static BindingList<GeneralProductionAction.GeneralProductionReportQuery2_Class> GeneralProductionReportQuery2(TTObjectContext objectContext, Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["GENERALPRODUCTIONACTION"].QueryDefs["GeneralProductionReportQuery2"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<GeneralProductionAction.GeneralProductionReportQuery2_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Birim Fiyatı
    /// </summary>
        public BigCurrency? UnitPrice
        {
            get { return (BigCurrency?)this["UNITPRICE"]; }
            set { this["UNITPRICE"] = value; }
        }

    /// <summary>
    /// Miktar
    /// </summary>
        public Currency? Amount
        {
            get { return (Currency?)this["AMOUNT"]; }
            set { this["AMOUNT"] = value; }
        }

    /// <summary>
    /// MKYS Giriş Kontrol 
    /// </summary>
        public bool? InMkysControl
        {
            get { return (bool?)this["INMKYSCONTROL"]; }
            set { this["INMKYSCONTROL"] = value; }
        }

    /// <summary>
    /// MKYS Çıkış Kontrol 
    /// </summary>
        public bool? OutMkysControl
        {
            get { return (bool?)this["OUTMKYSCONTROL"]; }
            set { this["OUTMKYSCONTROL"] = value; }
        }

        public int? MKYS_AyniyatMakbuzIDGiris
        {
            get { return (int?)this["MKYS_AYNIYATMAKBUZIDGIRIS"]; }
            set { this["MKYS_AYNIYATMAKBUZIDGIRIS"] = value; }
        }

        public Material Material
        {
            get { return (Material)((ITTObject)this).GetParent("MATERIAL"); }
            set { this["MATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        override protected void CreateStockActionDetailsCollectionViews()
        {
            base.CreateStockActionDetailsCollectionViews();
            _GeneralProductionInDets = new GeneralProductionInDet.ChildGeneralProductionInDetCollection(_StockActionDetails, "GeneralProductionInDets");
            _GeneralProductionOutDets = new GeneralProductionOutDet.ChildGeneralProductionOutDetCollection(_StockActionDetails, "GeneralProductionOutDets");
        }

        private GeneralProductionInDet.ChildGeneralProductionInDetCollection _GeneralProductionInDets = null;
    /// <summary>
    /// Alt İşlemler
    /// </summary>
        public GeneralProductionInDet.ChildGeneralProductionInDetCollection GeneralProductionInDets
        {
            get
            {
                if (_StockActionDetails == null)
                    CreateStockActionDetailsCollection();
                return _GeneralProductionInDets;
            }            
        }

        private GeneralProductionOutDet.ChildGeneralProductionOutDetCollection _GeneralProductionOutDets = null;
    /// <summary>
    /// Alt İşlemler
    /// </summary>
        public GeneralProductionOutDet.ChildGeneralProductionOutDetCollection GeneralProductionOutDets
        {
            get
            {
                if (_StockActionDetails == null)
                    CreateStockActionDetailsCollection();
                return _GeneralProductionOutDets;
            }            
        }

        protected GeneralProductionAction(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected GeneralProductionAction(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected GeneralProductionAction(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected GeneralProductionAction(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected GeneralProductionAction(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "GENERALPRODUCTIONACTION", dataRow) { }
        protected GeneralProductionAction(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "GENERALPRODUCTIONACTION", dataRow, isImported) { }
        public GeneralProductionAction(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public GeneralProductionAction(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public GeneralProductionAction() : base() { }

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
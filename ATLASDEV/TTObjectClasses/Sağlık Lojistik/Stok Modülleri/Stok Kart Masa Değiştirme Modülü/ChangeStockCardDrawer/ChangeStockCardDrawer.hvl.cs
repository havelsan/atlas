
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ChangeStockCardDrawer")] 

    /// <summary>
    /// Stok Kart Masa Değiştirme
    /// </summary>
    public  partial class ChangeStockCardDrawer : BaseAction, IWorkListBaseAction
    {
        public class ChangeStockCardDrawerList : TTObjectCollection<ChangeStockCardDrawer> { }
                    
        public class ChildChangeStockCardDrawerCollection : TTObject.TTChildObjectCollection<ChangeStockCardDrawer>
        {
            public ChildChangeStockCardDrawerCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildChangeStockCardDrawerCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetChangeStockCardDrawerReportQuery_Class : TTReportNqlObject 
        {
            public DateTime? ActionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CHANGESTOCKCARDDRAWER"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
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

            public string Stockcard
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STOCKCARD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Oldrescarddrawer
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLDRESCARDDRAWER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESCARDDRAWER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Newrescarddrawer
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NEWRESCARDDRAWER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESCARDDRAWER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetChangeStockCardDrawerReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetChangeStockCardDrawerReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetChangeStockCardDrawerReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetChangeStockCardDrawerByNewCardDrawer_Class : TTReportNqlObject 
        {
            public Object Nqlcolumn
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["NQLCOLUMN"]);
                }
            }

            public GetChangeStockCardDrawerByNewCardDrawer_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetChangeStockCardDrawerByNewCardDrawer_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetChangeStockCardDrawerByNewCardDrawer_Class() : base() { }
        }

        [Serializable] 

        public partial class GetChangeStockCardDrawerByOldCardDrawer_Class : TTReportNqlObject 
        {
            public Object Nqlcolumn
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["NQLCOLUMN"]);
                }
            }

            public GetChangeStockCardDrawerByOldCardDrawer_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetChangeStockCardDrawerByOldCardDrawer_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetChangeStockCardDrawerByOldCardDrawer_Class() : base() { }
        }

        public static class States
        {
            public static Guid Completed { get { return new Guid("94f29c92-ba96-40af-8f52-1b2468573a7d"); } }
            public static Guid Cancelled { get { return new Guid("e03baa1c-0bce-494d-9813-7832106e3a7f"); } }
            public static Guid New { get { return new Guid("3769fd64-506a-44f0-8887-3bc60014d595"); } }
            public static Guid Approved { get { return new Guid("4bb7fe57-514f-426f-a18a-087e1f0d35c6"); } }
        }

        public static BindingList<ChangeStockCardDrawer.GetChangeStockCardDrawerReportQuery_Class> GetChangeStockCardDrawerReportQuery(Guid TERMID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CHANGESTOCKCARDDRAWER"].QueryDefs["GetChangeStockCardDrawerReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TERMID", TERMID);

            return TTReportNqlObject.QueryObjects<ChangeStockCardDrawer.GetChangeStockCardDrawerReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ChangeStockCardDrawer.GetChangeStockCardDrawerReportQuery_Class> GetChangeStockCardDrawerReportQuery(TTObjectContext objectContext, Guid TERMID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CHANGESTOCKCARDDRAWER"].QueryDefs["GetChangeStockCardDrawerReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TERMID", TERMID);

            return TTReportNqlObject.QueryObjects<ChangeStockCardDrawer.GetChangeStockCardDrawerReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ChangeStockCardDrawer.GetChangeStockCardDrawerByNewCardDrawer_Class> GetChangeStockCardDrawerByNewCardDrawer(Guid TERM, Guid CARDDRAWER, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CHANGESTOCKCARDDRAWER"].QueryDefs["GetChangeStockCardDrawerByNewCardDrawer"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TERM", TERM);
            paramList.Add("CARDDRAWER", CARDDRAWER);

            return TTReportNqlObject.QueryObjects<ChangeStockCardDrawer.GetChangeStockCardDrawerByNewCardDrawer_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ChangeStockCardDrawer.GetChangeStockCardDrawerByNewCardDrawer_Class> GetChangeStockCardDrawerByNewCardDrawer(TTObjectContext objectContext, Guid TERM, Guid CARDDRAWER, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CHANGESTOCKCARDDRAWER"].QueryDefs["GetChangeStockCardDrawerByNewCardDrawer"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TERM", TERM);
            paramList.Add("CARDDRAWER", CARDDRAWER);

            return TTReportNqlObject.QueryObjects<ChangeStockCardDrawer.GetChangeStockCardDrawerByNewCardDrawer_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ChangeStockCardDrawer.GetChangeStockCardDrawerByOldCardDrawer_Class> GetChangeStockCardDrawerByOldCardDrawer(Guid CARDDRAWER, Guid TERM, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CHANGESTOCKCARDDRAWER"].QueryDefs["GetChangeStockCardDrawerByOldCardDrawer"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("CARDDRAWER", CARDDRAWER);
            paramList.Add("TERM", TERM);

            return TTReportNqlObject.QueryObjects<ChangeStockCardDrawer.GetChangeStockCardDrawerByOldCardDrawer_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ChangeStockCardDrawer.GetChangeStockCardDrawerByOldCardDrawer_Class> GetChangeStockCardDrawerByOldCardDrawer(TTObjectContext objectContext, Guid CARDDRAWER, Guid TERM, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CHANGESTOCKCARDDRAWER"].QueryDefs["GetChangeStockCardDrawerByOldCardDrawer"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("CARDDRAWER", CARDDRAWER);
            paramList.Add("TERM", TERM);

            return TTReportNqlObject.QueryObjects<ChangeStockCardDrawer.GetChangeStockCardDrawerByOldCardDrawer_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Yeni Masa
    /// </summary>
        public ResCardDrawer NewResCardDrawer
        {
            get { return (ResCardDrawer)((ITTObject)this).GetParent("NEWRESCARDDRAWER"); }
            set { this["NEWRESCARDDRAWER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Eski Masa
    /// </summary>
        public ResCardDrawer OldResCardDrawer
        {
            get { return (ResCardDrawer)((ITTObject)this).GetParent("OLDRESCARDDRAWER"); }
            set { this["OLDRESCARDDRAWER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Stok Kartı
    /// </summary>
        public StockCard StockCard
        {
            get { return (StockCard)((ITTObject)this).GetParent("STOCKCARD"); }
            set { this["STOCKCARD"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Hesap Dönemi - Stok Kart Masa Değiştirme
    /// </summary>
        public AccountingTerm AccountingTerm
        {
            get { return (AccountingTerm)((ITTObject)this).GetParent("ACCOUNTINGTERM"); }
            set { this["ACCOUNTINGTERM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ChangeStockCardDrawer(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ChangeStockCardDrawer(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ChangeStockCardDrawer(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ChangeStockCardDrawer(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ChangeStockCardDrawer(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "CHANGESTOCKCARDDRAWER", dataRow) { }
        protected ChangeStockCardDrawer(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "CHANGESTOCKCARDDRAWER", dataRow, isImported) { }
        public ChangeStockCardDrawer(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ChangeStockCardDrawer(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ChangeStockCardDrawer() : base() { }

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

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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="CheckStockCensusAction")] 

    /// <summary>
    /// Yılsonu / Çift Sıfırlı Kart Devir İşlemi
    /// </summary>
    public  partial class CheckStockCensusAction : BaseAction, IWorkListBaseAction
    {
        public class CheckStockCensusActionList : TTObjectCollection<CheckStockCensusAction> { }
                    
        public class ChildCheckStockCensusActionCollection : TTObject.TTChildObjectCollection<CheckStockCensusAction>
        {
            public ChildCheckStockCensusActionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildCheckStockCensusActionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("2bdcd845-d4cc-4242-b185-a2953f7ef9e0"); } }
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("10463e0b-e610-49a1-a2d1-eaf56621e0bf"); } }
        }

    /// <summary>
    /// Kontrol Yapıldı
    /// </summary>
        public bool? IsChecked
        {
            get { return (bool?)this["ISCHECKED"]; }
            set { this["ISCHECKED"] = value; }
        }

    /// <summary>
    /// Kontrol Yapıldı
    /// </summary>
        public bool? IsUpdateCreationDate
        {
            get { return (bool?)this["ISUPDATECREATIONDATE"]; }
            set { this["ISUPDATECREATIONDATE"] = value; }
        }

        public MainStoreDefinition MainStoreDefinition
        {
            get { return (MainStoreDefinition)((ITTObject)this).GetParent("MAINSTOREDEFINITION"); }
            set { this["MAINSTOREDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public AccountingTerm AccountingTerm
        {
            get { return (AccountingTerm)((ITTObject)this).GetParent("ACCOUNTINGTERM"); }
            set { this["ACCOUNTINGTERM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateWrongStockCollection()
        {
            _WrongStock = new WrongStock.ChildWrongStockCollection(this, new Guid("f3c249ea-f735-4752-ac8a-3e3f459eda0a"));
            ((ITTChildObjectCollection)_WrongStock).GetChildren();
        }

        protected WrongStock.ChildWrongStockCollection _WrongStock = null;
        public WrongStock.ChildWrongStockCollection WrongStock
        {
            get
            {
                if (_WrongStock == null)
                    CreateWrongStockCollection();
                return _WrongStock;
            }
        }

        virtual protected void CreateStockCensusCardDrawersCollection()
        {
            _StockCensusCardDrawers = new StockCensusCardDrawer.ChildStockCensusCardDrawerCollection(this, new Guid("37c5b65f-35a9-4153-95c9-e79c9680acda"));
            ((ITTChildObjectCollection)_StockCensusCardDrawers).GetChildren();
        }

        protected StockCensusCardDrawer.ChildStockCensusCardDrawerCollection _StockCensusCardDrawers = null;
        public StockCensusCardDrawer.ChildStockCensusCardDrawerCollection StockCensusCardDrawers
        {
            get
            {
                if (_StockCensusCardDrawers == null)
                    CreateStockCensusCardDrawersCollection();
                return _StockCensusCardDrawers;
            }
        }

        virtual protected void CreateCensusSignUserDetailsCollection()
        {
            _CensusSignUserDetails = new CensusSignUser.ChildCensusSignUserCollection(this, new Guid("23a5c423-2358-48ba-bc58-2f030a66f3b0"));
            ((ITTChildObjectCollection)_CensusSignUserDetails).GetChildren();
        }

        protected CensusSignUser.ChildCensusSignUserCollection _CensusSignUserDetails = null;
        public CensusSignUser.ChildCensusSignUserCollection CensusSignUserDetails
        {
            get
            {
                if (_CensusSignUserDetails == null)
                    CreateCensusSignUserDetailsCollection();
                return _CensusSignUserDetails;
            }
        }

        virtual protected void CreateStockActionSignDetailsCollection()
        {
            _StockActionSignDetails = new StockActionSignDetail.ChildStockActionSignDetailCollection(this, new Guid("5569a23f-a5fd-40ee-b30b-cd2ee92fbd9c"));
            ((ITTChildObjectCollection)_StockActionSignDetails).GetChildren();
        }

        protected StockActionSignDetail.ChildStockActionSignDetailCollection _StockActionSignDetails = null;
        public StockActionSignDetail.ChildStockActionSignDetailCollection StockActionSignDetails
        {
            get
            {
                if (_StockActionSignDetails == null)
                    CreateStockActionSignDetailsCollection();
                return _StockActionSignDetails;
            }
        }

        protected CheckStockCensusAction(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected CheckStockCensusAction(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected CheckStockCensusAction(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected CheckStockCensusAction(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected CheckStockCensusAction(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "CHECKSTOCKCENSUSACTION", dataRow) { }
        protected CheckStockCensusAction(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "CHECKSTOCKCENSUSACTION", dataRow, isImported) { }
        public CheckStockCensusAction(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public CheckStockCensusAction(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public CheckStockCensusAction() : base() { }

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
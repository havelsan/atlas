
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="FirstInStockAction")] 

    public  partial class FirstInStockAction : TTObject
    {
        public class FirstInStockActionList : TTObjectCollection<FirstInStockAction> { }
                    
        public class ChildFirstInStockActionCollection : TTObject.TTChildObjectCollection<FirstInStockAction>
        {
            public ChildFirstInStockActionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildFirstInStockActionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Seç
    /// </summary>
        public bool? SelectedStockAction
        {
            get { return (bool?)this["SELECTEDSTOCKACTION"]; }
            set { this["SELECTEDSTOCKACTION"] = value; }
        }

    /// <summary>
    /// Eski Son Kullanma Tarihi
    /// </summary>
        public DateTime? ExpirationDate
        {
            get { return (DateTime?)this["EXPIRATIONDATE"]; }
            set { this["EXPIRATIONDATE"] = value; }
        }

    /// <summary>
    /// StockTransactionObjectID
    /// </summary>
        public Guid? StockTransactionObjectID
        {
            get { return (Guid?)this["STOCKTRANSACTIONOBJECTID"]; }
            set { this["STOCKTRANSACTIONOBJECTID"] = value; }
        }

    /// <summary>
    /// İşlem Adı
    /// </summary>
        public string StockActionDescription
        {
            get { return (string)this["STOCKACTIONDESCRIPTION"]; }
            set { this["STOCKACTIONDESCRIPTION"] = value; }
        }

        public StockAction StockAction
        {
            get { return (StockAction)((ITTObject)this).GetParent("STOCKACTION"); }
            set { this["STOCKACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ExpirationDateCorrectionAction ExpireDateCorrectionAction
        {
            get { return (ExpirationDateCorrectionAction)((ITTObject)this).GetParent("EXPIREDATECORRECTIONACTION"); }
            set { this["EXPIREDATECORRECTIONACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateInStockActionsCollection()
        {
            _InStockActions = new InStockAction.ChildInStockActionCollection(this, new Guid("2c1a1b4e-d05a-4634-bea5-aa3c79d6bffa"));
            ((ITTChildObjectCollection)_InStockActions).GetChildren();
        }

        protected InStockAction.ChildInStockActionCollection _InStockActions = null;
        public InStockAction.ChildInStockActionCollection InStockActions
        {
            get
            {
                if (_InStockActions == null)
                    CreateInStockActionsCollection();
                return _InStockActions;
            }
        }

        protected FirstInStockAction(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected FirstInStockAction(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected FirstInStockAction(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected FirstInStockAction(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected FirstInStockAction(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "FIRSTINSTOCKACTION", dataRow) { }
        protected FirstInStockAction(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "FIRSTINSTOCKACTION", dataRow, isImported) { }
        public FirstInStockAction(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public FirstInStockAction(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public FirstInStockAction() : base() { }

    }
}

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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BasePurchaseAction")] 

    /// <summary>
    /// Tüm Tedarik Modüllerinin Ana Sınıflarının Temelidir.
    /// </summary>
    public  abstract  partial class BasePurchaseAction : BaseAction
    {
        public class BasePurchaseActionList : TTObjectCollection<BasePurchaseAction> { }
                    
        public class ChildBasePurchaseActionCollection : TTObject.TTChildObjectCollection<BasePurchaseAction>
        {
            public ChildBasePurchaseActionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBasePurchaseActionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static BindingList<BasePurchaseAction> PurchaseActionWorkListNQL(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASEPURCHASEACTION"].QueryDefs["PurchaseActionWorkListNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<BasePurchaseAction>(queryDef, paramList, injectionSQL);
        }

        public ResSection MasterResource
        {
            get { return (ResSection)((ITTObject)this).GetParent("MASTERRESOURCE"); }
            set { this["MASTERRESOURCE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected BasePurchaseAction(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BasePurchaseAction(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BasePurchaseAction(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BasePurchaseAction(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BasePurchaseAction(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BASEPURCHASEACTION", dataRow) { }
        protected BasePurchaseAction(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BASEPURCHASEACTION", dataRow, isImported) { }
        protected BasePurchaseAction(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BasePurchaseAction(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BasePurchaseAction() : base() { }

    }
}
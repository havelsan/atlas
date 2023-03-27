
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="AccountancyAddingAction")] 

    public  partial class AccountancyAddingAction : BaseAction
    {
        public class AccountancyAddingActionList : TTObjectCollection<AccountancyAddingAction> { }
                    
        public class ChildAccountancyAddingActionCollection : TTObject.TTChildObjectCollection<AccountancyAddingAction>
        {
            public ChildAccountancyAddingActionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildAccountancyAddingActionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid New { get { return new Guid("1d7284c0-c208-493a-a698-44274cbfc3d0"); } }
            public static Guid Completed { get { return new Guid("35db08bc-217f-49aa-af99-b5ec06f1c1ba"); } }
        }

        virtual protected void CreateAccountVouchersCollection()
        {
            _AccountVouchers = new AccountVoucher.ChildAccountVoucherCollection(this, new Guid("cda9770a-ca2d-4121-9254-820523c58d3a"));
            ((ITTChildObjectCollection)_AccountVouchers).GetChildren();
        }

        protected AccountVoucher.ChildAccountVoucherCollection _AccountVouchers = null;
        public AccountVoucher.ChildAccountVoucherCollection AccountVouchers
        {
            get
            {
                if (_AccountVouchers == null)
                    CreateAccountVouchersCollection();
                return _AccountVouchers;
            }
        }

        protected AccountancyAddingAction(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected AccountancyAddingAction(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected AccountancyAddingAction(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected AccountancyAddingAction(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected AccountancyAddingAction(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ACCOUNTANCYADDINGACTION", dataRow) { }
        protected AccountancyAddingAction(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ACCOUNTANCYADDINGACTION", dataRow, isImported) { }
        public AccountancyAddingAction(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public AccountancyAddingAction(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public AccountancyAddingAction() : base() { }

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
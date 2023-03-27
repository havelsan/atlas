
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BloodBankSubProduct")] 

    /// <summary>
    /// Kan Ürün Ek İşlem
    /// </summary>
    public  partial class BloodBankSubProduct : SubactionProcedureFlowable
    {
        public class BloodBankSubProductList : TTObjectCollection<BloodBankSubProduct> { }
                    
        public class ChildBloodBankSubProductCollection : TTObject.TTChildObjectCollection<BloodBankSubProduct>
        {
            public ChildBloodBankSubProductCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBloodBankSubProductCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
            public static Guid Cancelled { get { return new Guid("ec78eac4-6af9-4a46-b58d-162213ad22e4"); } }
            public static Guid Completed { get { return new Guid("02ac1ebf-6100-45e4-b5ba-c8404aa8529b"); } }
            public static Guid New { get { return new Guid("7aaa3c65-59a3-475e-b847-fc0ff6bde30b"); } }
        }

        public BloodBankBloodProducts BloodBankBloodProducts
        {
            get 
            {   
                if (MasterSubActionProcedure is BloodBankBloodProducts)
                    return (BloodBankBloodProducts)MasterSubActionProcedure; 
                return null;
            }            
            set { MasterSubActionProcedure = value; }
        }

        protected BloodBankSubProduct(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BloodBankSubProduct(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BloodBankSubProduct(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BloodBankSubProduct(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BloodBankSubProduct(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BLOODBANKSUBPRODUCT", dataRow) { }
        protected BloodBankSubProduct(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BLOODBANKSUBPRODUCT", dataRow, isImported) { }
        public BloodBankSubProduct(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BloodBankSubProduct(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BloodBankSubProduct() : base() { }

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
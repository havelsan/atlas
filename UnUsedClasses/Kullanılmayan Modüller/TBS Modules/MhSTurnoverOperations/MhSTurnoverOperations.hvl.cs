
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MhSTurnoverOperations")] 

    /// <summary>
    /// Devir İşlemleri
    /// </summary>
    public  partial class MhSTurnoverOperations : MhSSlip
    {
        public class MhSTurnoverOperationsList : TTObjectCollection<MhSTurnoverOperations> { }
                    
        public class ChildMhSTurnoverOperationsCollection : TTObject.TTChildObjectCollection<MhSTurnoverOperations>
        {
            public ChildMhSTurnoverOperationsCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMhSTurnoverOperationsCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
            public static Guid ClosingSlipEdit { get { return new Guid("cdfa873f-abd9-4aee-a0ac-19426139f48a"); } }
            public static Guid New { get { return new Guid("3d8a9e7e-f3f4-4bc1-8121-35fdba9f9e61"); } }
            public static Guid Complete { get { return new Guid("4e2dd14d-7ef0-43c0-aa3d-b96810570888"); } }
        }

        protected MhSTurnoverOperations(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MhSTurnoverOperations(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MhSTurnoverOperations(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MhSTurnoverOperations(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MhSTurnoverOperations(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MHSTURNOVEROPERATIONS", dataRow) { }
        protected MhSTurnoverOperations(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MHSTURNOVEROPERATIONS", dataRow, isImported) { }
        public MhSTurnoverOperations(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MhSTurnoverOperations(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MhSTurnoverOperations() : base() { }

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

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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="NursingOrderRequest")] 

    /// <summary>
    /// Hemşire Hizmetleri İstek
    /// </summary>
    public  partial class NursingOrderRequest : TTObject
    {
        public class NursingOrderRequestList : TTObjectCollection<NursingOrderRequest> { }
                    
        public class ChildNursingOrderRequestCollection : TTObject.TTChildObjectCollection<NursingOrderRequest>
        {
            public ChildNursingOrderRequestCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildNursingOrderRequestCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
    /// <summary>
    /// Doktor Emri
    /// </summary>
            public static Guid Order { get { return new Guid("5f651a9f-71b9-4ebf-8e1a-1c7f56a46abe"); } }
            public static Guid Completed { get { return new Guid("2ae27456-bda6-4a1b-a741-2ba3be8c1ec6"); } }
        }

        protected NursingOrderRequest(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected NursingOrderRequest(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected NursingOrderRequest(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected NursingOrderRequest(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected NursingOrderRequest(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "NURSINGORDERREQUEST", dataRow) { }
        protected NursingOrderRequest(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "NURSINGORDERREQUEST", dataRow, isImported) { }
        public NursingOrderRequest(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public NursingOrderRequest(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public NursingOrderRequest() : base() { }

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
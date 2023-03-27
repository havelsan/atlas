
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MPBSOutgoingDocument")] 

    /// <summary>
    /// Giden Evrak
    /// </summary>
    public  partial class MPBSOutgoingDocument : MPBSDocument
    {
        public class MPBSOutgoingDocumentList : TTObjectCollection<MPBSOutgoingDocument> { }
                    
        public class ChildMPBSOutgoingDocumentCollection : TTObject.TTChildObjectCollection<MPBSOutgoingDocument>
        {
            public ChildMPBSOutgoingDocumentCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMPBSOutgoingDocumentCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid New { get { return new Guid("1dfde685-5da7-4967-ab38-5e2d9705de4d"); } }
            public static Guid Completed { get { return new Guid("167f0ee7-c617-4573-b71f-86958d4db8f3"); } }
        }

    /// <summary>
    /// Nereye
    /// </summary>
        public string To
        {
            get { return (string)this["TO"]; }
            set { this["TO"] = value; }
        }

        protected MPBSOutgoingDocument(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MPBSOutgoingDocument(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MPBSOutgoingDocument(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MPBSOutgoingDocument(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MPBSOutgoingDocument(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MPBSOUTGOINGDOCUMENT", dataRow) { }
        protected MPBSOutgoingDocument(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MPBSOUTGOINGDOCUMENT", dataRow, isImported) { }
        public MPBSOutgoingDocument(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MPBSOutgoingDocument(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MPBSOutgoingDocument() : base() { }

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
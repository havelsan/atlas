
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MPBSIncomingDocument")] 

    /// <summary>
    /// Gelen Evrak
    /// </summary>
    public  partial class MPBSIncomingDocument : MPBSDocument
    {
        public class MPBSIncomingDocumentList : TTObjectCollection<MPBSIncomingDocument> { }
                    
        public class ChildMPBSIncomingDocumentCollection : TTObject.TTChildObjectCollection<MPBSIncomingDocument>
        {
            public ChildMPBSIncomingDocumentCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMPBSIncomingDocumentCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid Completed { get { return new Guid("a04d3cac-2412-4719-a825-27752db1f093"); } }
            public static Guid New { get { return new Guid("196f793c-5e23-4b4d-893d-d615c0cbd796"); } }
        }

    /// <summary>
    /// Nereden
    /// </summary>
        public string From
        {
            get { return (string)this["FROM"]; }
            set { this["FROM"] = value; }
        }

        protected MPBSIncomingDocument(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MPBSIncomingDocument(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MPBSIncomingDocument(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MPBSIncomingDocument(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MPBSIncomingDocument(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MPBSINCOMINGDOCUMENT", dataRow) { }
        protected MPBSIncomingDocument(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MPBSINCOMINGDOCUMENT", dataRow, isImported) { }
        public MPBSIncomingDocument(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MPBSIncomingDocument(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MPBSIncomingDocument() : base() { }

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

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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ProjectDocument")] 

    public  partial class ProjectDocument : TTObject
    {
        public class ProjectDocumentList : TTObjectCollection<ProjectDocument> { }
                    
        public class ChildProjectDocumentCollection : TTObject.TTChildObjectCollection<ProjectDocument>
        {
            public ChildProjectDocumentCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildProjectDocumentCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public object Content
        {
            get { return (object)this["CONTENT"]; }
            set { this["CONTENT"] = value; }
        }

        public string Title
        {
            get { return (string)this["TITLE"]; }
            set { this["TITLE"] = value; }
        }

        public ArgeProject ProjectDoc
        {
            get { return (ArgeProject)((ITTObject)this).GetParent("PROJECTDOC"); }
            set { this["PROJECTDOC"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ProjectDocument(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ProjectDocument(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ProjectDocument(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ProjectDocument(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ProjectDocument(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PROJECTDOCUMENT", dataRow) { }
        protected ProjectDocument(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PROJECTDOCUMENT", dataRow, isImported) { }
        public ProjectDocument(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ProjectDocument(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ProjectDocument() : base() { }

    }
}
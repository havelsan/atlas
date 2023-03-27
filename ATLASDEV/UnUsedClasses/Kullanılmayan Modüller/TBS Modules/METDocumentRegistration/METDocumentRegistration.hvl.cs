
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="METDocumentRegistration")] 

    public  partial class METDocumentRegistration : METDocument
    {
        public class METDocumentRegistrationList : TTObjectCollection<METDocumentRegistration> { }
                    
        public class ChildMETDocumentRegistrationCollection : TTObject.TTChildObjectCollection<METDocumentRegistration>
        {
            public ChildMETDocumentRegistrationCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMETDocumentRegistrationCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Evrak
    /// </summary>
        public METDocument Document
        {
            get { return (METDocument)((ITTObject)this).GetParent("DOCUMENT"); }
            set { this["DOCUMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected METDocumentRegistration(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected METDocumentRegistration(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected METDocumentRegistration(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected METDocumentRegistration(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected METDocumentRegistration(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "METDOCUMENTREGISTRATION", dataRow) { }
        protected METDocumentRegistration(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "METDOCUMENTREGISTRATION", dataRow, isImported) { }
        public METDocumentRegistration(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public METDocumentRegistration(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public METDocumentRegistration() : base() { }

    }
}
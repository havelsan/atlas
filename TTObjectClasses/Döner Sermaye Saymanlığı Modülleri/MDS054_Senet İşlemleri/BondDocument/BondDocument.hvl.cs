
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BondDocument")] 

    public  partial class BondDocument : AccountDocument
    {
        public class BondDocumentList : TTObjectCollection<BondDocument> { }
                    
        public class ChildBondDocumentCollection : TTObject.TTChildObjectCollection<BondDocument>
        {
            public ChildBondDocumentCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBondDocumentCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        virtual protected void CreateBondCollection()
        {
            _Bond = new Bond.ChildBondCollection(this, new Guid("5900906e-ad49-4a3e-a395-e3c1fa3f0359"));
            ((ITTChildObjectCollection)_Bond).GetChildren();
        }

        protected Bond.ChildBondCollection _Bond = null;
        public Bond.ChildBondCollection Bond
        {
            get
            {
                if (_Bond == null)
                    CreateBondCollection();
                return _Bond;
            }
        }

        virtual protected void CreateAdvanceDocumentsCollection()
        {
            _AdvanceDocuments = new AdvanceDocument.ChildAdvanceDocumentCollection(this, new Guid("e11b8689-fe1f-4d32-903c-a7e0701b940e"));
            ((ITTChildObjectCollection)_AdvanceDocuments).GetChildren();
        }

        protected AdvanceDocument.ChildAdvanceDocumentCollection _AdvanceDocuments = null;
        public AdvanceDocument.ChildAdvanceDocumentCollection AdvanceDocuments
        {
            get
            {
                if (_AdvanceDocuments == null)
                    CreateAdvanceDocumentsCollection();
                return _AdvanceDocuments;
            }
        }

        protected BondDocument(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BondDocument(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BondDocument(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BondDocument(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BondDocument(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BONDDOCUMENT", dataRow) { }
        protected BondDocument(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BONDDOCUMENT", dataRow, isImported) { }
        public BondDocument(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BondDocument(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BondDocument() : base() { }

    }
}

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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="AdvanceBackDocumentDetail")] 

    /// <summary>
    /// Avans İade Döküman Detayı
    /// </summary>
    public  partial class AdvanceBackDocumentDetail : AccountDocumentDetail
    {
        public class AdvanceBackDocumentDetailList : TTObjectCollection<AdvanceBackDocumentDetail> { }
                    
        public class ChildAdvanceBackDocumentDetailCollection : TTObject.TTChildObjectCollection<AdvanceBackDocumentDetail>
        {
            public ChildAdvanceBackDocumentDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildAdvanceBackDocumentDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected AdvanceBackDocumentDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected AdvanceBackDocumentDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected AdvanceBackDocumentDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected AdvanceBackDocumentDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected AdvanceBackDocumentDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ADVANCEBACKDOCUMENTDETAIL", dataRow) { }
        protected AdvanceBackDocumentDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ADVANCEBACKDOCUMENTDETAIL", dataRow, isImported) { }
        public AdvanceBackDocumentDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public AdvanceBackDocumentDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public AdvanceBackDocumentDetail() : base() { }

    }
}
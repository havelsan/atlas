
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BaseDeleteRecordDocument")] 

    public  abstract  partial class BaseDeleteRecordDocument : StockAction
    {
        public class BaseDeleteRecordDocumentList : TTObjectCollection<BaseDeleteRecordDocument> { }
                    
        public class ChildBaseDeleteRecordDocumentCollection : TTObject.TTChildObjectCollection<BaseDeleteRecordDocument>
        {
            public ChildBaseDeleteRecordDocumentCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBaseDeleteRecordDocumentCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
            public static Guid Cancelled { get { return new Guid("887b7ee9-ebfa-43df-8145-aac2f3c4a1a7"); } }
            public static Guid New { get { return new Guid("96777208-ca89-40f7-b71d-6affa44acc11"); } }
            public static Guid Completed { get { return new Guid("b959800b-5382-4411-beb9-acdea28be1fa"); } }
        }

        public AuthorityClassStatusEnum? AuthorityClass
        {
            get { return (AuthorityClassStatusEnum?)(int?)this["AUTHORITYCLASS"]; }
            set { this["AUTHORITYCLASS"] = value; }
        }

    /// <summary>
    /// Teknik Rapor
    /// </summary>
        public object TechnicalReport
        {
            get { return (object)this["TECHNICALREPORT"]; }
            set { this["TECHNICALREPORT"] = value; }
        }

        public ReturningDocument ReturningDocument
        {
            get { return (ReturningDocument)((ITTObject)this).GetParent("RETURNINGDOCUMENT"); }
            set { this["RETURNINGDOCUMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected BaseDeleteRecordDocument(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BaseDeleteRecordDocument(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BaseDeleteRecordDocument(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BaseDeleteRecordDocument(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BaseDeleteRecordDocument(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BASEDELETERECORDDOCUMENT", dataRow) { }
        protected BaseDeleteRecordDocument(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BASEDELETERECORDDOCUMENT", dataRow, isImported) { }
        public BaseDeleteRecordDocument(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BaseDeleteRecordDocument(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BaseDeleteRecordDocument() : base() { }

    }
}
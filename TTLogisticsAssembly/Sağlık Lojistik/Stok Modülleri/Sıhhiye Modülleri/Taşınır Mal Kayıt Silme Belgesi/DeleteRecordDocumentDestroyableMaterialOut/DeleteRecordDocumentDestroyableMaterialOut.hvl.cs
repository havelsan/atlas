
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DeleteRecordDocumentDestroyableMaterialOut")] 

    /// <summary>
    /// Kayıt Silme Belgesi Yok Edilen malzeme detaylarını tutan sınıftır
    /// </summary>
    public  partial class DeleteRecordDocumentDestroyableMaterialOut : BaseDeleteRecordDocumentDetail
    {
        public class DeleteRecordDocumentDestroyableMaterialOutList : TTObjectCollection<DeleteRecordDocumentDestroyableMaterialOut> { }
                    
        public class ChildDeleteRecordDocumentDestroyableMaterialOutCollection : TTObject.TTChildObjectCollection<DeleteRecordDocumentDestroyableMaterialOut>
        {
            public ChildDeleteRecordDocumentDestroyableMaterialOutCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDeleteRecordDocumentDestroyableMaterialOutCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public string DestroyLocation
        {
            get { return (string)this["DESTROYLOCATION"]; }
            set { this["DESTROYLOCATION"] = value; }
        }

        protected DeleteRecordDocumentDestroyableMaterialOut(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DeleteRecordDocumentDestroyableMaterialOut(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DeleteRecordDocumentDestroyableMaterialOut(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DeleteRecordDocumentDestroyableMaterialOut(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DeleteRecordDocumentDestroyableMaterialOut(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DELETERECORDDOCUMENTDESTROYABLEMATERIALOUT", dataRow) { }
        protected DeleteRecordDocumentDestroyableMaterialOut(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DELETERECORDDOCUMENTDESTROYABLEMATERIALOUT", dataRow, isImported) { }
        public DeleteRecordDocumentDestroyableMaterialOut(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DeleteRecordDocumentDestroyableMaterialOut(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DeleteRecordDocumentDestroyableMaterialOut() : base() { }

    }
}
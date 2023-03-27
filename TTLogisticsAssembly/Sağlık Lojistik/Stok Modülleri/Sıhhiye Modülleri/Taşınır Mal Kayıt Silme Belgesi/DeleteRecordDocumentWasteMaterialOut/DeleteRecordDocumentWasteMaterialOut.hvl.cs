
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DeleteRecordDocumentWasteMaterialOut")] 

    /// <summary>
    /// Kayıt Silme Belgesi-Hek Edilen Malzeme Sekmesi Çıkış detaylarını tutan sınıftır
    /// </summary>
    public  partial class DeleteRecordDocumentWasteMaterialOut : BaseDeleteRecordDocumentDetail
    {
        public class DeleteRecordDocumentWasteMaterialOutList : TTObjectCollection<DeleteRecordDocumentWasteMaterialOut> { }
                    
        public class ChildDeleteRecordDocumentWasteMaterialOutCollection : TTObject.TTChildObjectCollection<DeleteRecordDocumentWasteMaterialOut>
        {
            public ChildDeleteRecordDocumentWasteMaterialOutCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDeleteRecordDocumentWasteMaterialOutCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected DeleteRecordDocumentWasteMaterialOut(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DeleteRecordDocumentWasteMaterialOut(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DeleteRecordDocumentWasteMaterialOut(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DeleteRecordDocumentWasteMaterialOut(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DeleteRecordDocumentWasteMaterialOut(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DELETERECORDDOCUMENTWASTEMATERIALOUT", dataRow) { }
        protected DeleteRecordDocumentWasteMaterialOut(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DELETERECORDDOCUMENTWASTEMATERIALOUT", dataRow, isImported) { }
        public DeleteRecordDocumentWasteMaterialOut(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DeleteRecordDocumentWasteMaterialOut(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DeleteRecordDocumentWasteMaterialOut() : base() { }

    }
}
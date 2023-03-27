
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="LBD_PrintedDocumentOut")] 

    /// <summary>
    /// Lojistik İkmal Faaliyetleri Detay kalemi - Basılı evrak malzemeleri için kullanılan sınıftır. (Lojistik İkmal Faaliyetleri listesi harici)
    /// </summary>
    public  partial class LBD_PrintedDocumentOut : LBPurchaseProjectDetailOutOfList
    {
        public class LBD_PrintedDocumentOutList : TTObjectCollection<LBD_PrintedDocumentOut> { }
                    
        public class ChildLBD_PrintedDocumentOutCollection : TTObject.TTChildObjectCollection<LBD_PrintedDocumentOut>
        {
            public ChildLBD_PrintedDocumentOutCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildLBD_PrintedDocumentOutCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
    /// <summary>
    /// Tamam
    /// </summary>
            public static Guid Completed { get { return new Guid("222ab4a0-5000-455c-9023-3630b0c02766"); } }
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("fcfa3d5d-5780-4b74-8f6e-7b3188e52e8a"); } }
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancelled { get { return new Guid("cccf7119-49f4-4a37-9b44-de0b674ac4ff"); } }
        }

        protected LBD_PrintedDocumentOut(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected LBD_PrintedDocumentOut(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected LBD_PrintedDocumentOut(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected LBD_PrintedDocumentOut(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected LBD_PrintedDocumentOut(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "LBD_PRINTEDDOCUMENTOUT", dataRow) { }
        protected LBD_PrintedDocumentOut(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "LBD_PRINTEDDOCUMENTOUT", dataRow, isImported) { }
        public LBD_PrintedDocumentOut(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public LBD_PrintedDocumentOut(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public LBD_PrintedDocumentOut() : base() { }

    }
}
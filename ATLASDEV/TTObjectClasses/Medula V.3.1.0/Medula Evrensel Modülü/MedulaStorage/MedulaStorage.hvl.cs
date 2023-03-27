
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MedulaStorage")] 

    /// <summary>
    /// Medula Depolama Birimi
    /// </summary>
    public  partial class MedulaStorage : TTObject
    {
        public class MedulaStorageList : TTObjectCollection<MedulaStorage> { }
                    
        public class ChildMedulaStorageCollection : TTObject.TTChildObjectCollection<MedulaStorage>
        {
            public ChildMedulaStorageCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMedulaStorageCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Depolama Birimi Numarası
    /// </summary>
        public int? StorageNumber
        {
            get { return (int?)this["STORAGENUMBER"]; }
            set { this["STORAGENUMBER"] = value; }
        }

    /// <summary>
    /// Dosya Adı
    /// </summary>
        public string FileName
        {
            get { return (string)this["FILENAME"]; }
            set { this["FILENAME"] = value; }
        }

    /// <summary>
    /// Dosya Adresi
    /// </summary>
        public string FilePath
        {
            get { return (string)this["FILEPATH"]; }
            set { this["FILEPATH"] = value; }
        }

        virtual protected void CreateMedulaStorageDetailsCollection()
        {
            _MedulaStorageDetails = new MedulaStorageDetail.ChildMedulaStorageDetailCollection(this, new Guid("673ebca0-8796-44b3-a2a0-312a61dd9f76"));
            ((ITTChildObjectCollection)_MedulaStorageDetails).GetChildren();
        }

        protected MedulaStorageDetail.ChildMedulaStorageDetailCollection _MedulaStorageDetails = null;
    /// <summary>
    /// Child collection for Medula Depolama Birimi-Medula Depolama Birimi Detayları
    /// </summary>
        public MedulaStorageDetail.ChildMedulaStorageDetailCollection MedulaStorageDetails
        {
            get
            {
                if (_MedulaStorageDetails == null)
                    CreateMedulaStorageDetailsCollection();
                return _MedulaStorageDetails;
            }
        }

        protected MedulaStorage(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MedulaStorage(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MedulaStorage(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MedulaStorage(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MedulaStorage(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MEDULASTORAGE", dataRow) { }
        protected MedulaStorage(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MEDULASTORAGE", dataRow, isImported) { }
        public MedulaStorage(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MedulaStorage(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MedulaStorage() : base() { }

    }
}
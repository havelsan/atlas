
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="EpisodeFolderTransaction")] 

    /// <summary>
    /// Vaka bazlı dosya hareketleri
    /// </summary>
    public  partial class EpisodeFolderTransaction : TTObject
    {
        public class EpisodeFolderTransactionList : TTObjectCollection<EpisodeFolderTransaction> { }
                    
        public class ChildEpisodeFolderTransactionCollection : TTObject.TTChildObjectCollection<EpisodeFolderTransaction>
        {
            public ChildEpisodeFolderTransactionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildEpisodeFolderTransactionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// İşlem Tarihi
    /// </summary>
        public DateTime? TransactionDate
        {
            get { return (DateTime?)this["TRANSACTIONDATE"]; }
            set { this["TRANSACTIONDATE"] = value; }
        }

    /// <summary>
    /// İşlem No
    /// </summary>
        public long? TransactionID
        {
            get { return (long?)this["TRANSACTIONID"]; }
            set { this["TRANSACTIONID"] = value; }
        }

    /// <summary>
    /// İşlem Tipi
    /// </summary>
        public FolderTransactionTypeEnum? TransactionType
        {
            get { return (FolderTransactionTypeEnum?)(int?)this["TRANSACTIONTYPE"]; }
            set { this["TRANSACTIONTYPE"] = value; }
        }

    /// <summary>
    /// Dosyanın Yeri
    /// </summary>
        public ResSection EpisodeFolderLocation
        {
            get { return (ResSection)((ITTObject)this).GetParent("EPISODEFOLDERLOCATION"); }
            set { this["EPISODEFOLDERLOCATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Vaka Dosyası Hareketleri
    /// </summary>
        public EpisodeFolder EpisodeFolder
        {
            get { return (EpisodeFolder)((ITTObject)this).GetParent("EPISODEFOLDER"); }
            set { this["EPISODEFOLDER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// İşlemi Yapan Kullanıcı
    /// </summary>
        public ResUser TransactionUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("TRANSACTIONUSER"); }
            set { this["TRANSACTIONUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected EpisodeFolderTransaction(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected EpisodeFolderTransaction(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected EpisodeFolderTransaction(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected EpisodeFolderTransaction(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected EpisodeFolderTransaction(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EPISODEFOLDERTRANSACTION", dataRow) { }
        protected EpisodeFolderTransaction(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EPISODEFOLDERTRANSACTION", dataRow, isImported) { }
        public EpisodeFolderTransaction(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public EpisodeFolderTransaction(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public EpisodeFolderTransaction() : base() { }

    }
}
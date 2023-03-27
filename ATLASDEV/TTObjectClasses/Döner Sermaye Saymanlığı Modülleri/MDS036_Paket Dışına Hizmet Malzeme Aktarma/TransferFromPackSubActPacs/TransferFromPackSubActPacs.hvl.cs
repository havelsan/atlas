
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="TransferFromPackSubActPacs")] 

    /// <summary>
    /// Paket Dışına Hizmet/Malzeme Aktarma Paket Detayı
    /// </summary>
    public  partial class TransferFromPackSubActPacs : TTObject
    {
        public class TransferFromPackSubActPacsList : TTObjectCollection<TransferFromPackSubActPacs> { }
                    
        public class ChildTransferFromPackSubActPacsCollection : TTObject.TTChildObjectCollection<TransferFromPackSubActPacs>
        {
            public ChildTransferFromPackSubActPacsCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildTransferFromPackSubActPacsCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Durum
    /// </summary>
        public string Status
        {
            get { return (string)this["STATUS"]; }
            set { this["STATUS"] = value; }
        }

    /// <summary>
    /// Paket Dışına Hizmet/Malzeme Aktarma ile ilişki
    /// </summary>
        public TransferFromPackage TransferFromPackage
        {
            get { return (TransferFromPackage)((ITTObject)this).GetParent("TRANSFERFROMPACKAGE"); }
            set { this["TRANSFERFROMPACKAGE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Paket hizmet hareketi ile ilişki
    /// </summary>
        public SubActionPackageProcedure SubActionPackageProcedure
        {
            get { return (SubActionPackageProcedure)((ITTObject)this).GetParent("SUBACTIONPACKAGEPROCEDURE"); }
            set { this["SUBACTIONPACKAGEPROCEDURE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Anlaşma ile ilişki
    /// </summary>
        public EpisodeProtocol EpisodeProtocol
        {
            get { return (EpisodeProtocol)((ITTObject)this).GetParent("EPISODEPROTOCOL"); }
            set { this["EPISODEPROTOCOL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected TransferFromPackSubActPacs(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected TransferFromPackSubActPacs(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected TransferFromPackSubActPacs(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected TransferFromPackSubActPacs(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected TransferFromPackSubActPacs(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "TRANSFERFROMPACKSUBACTPACS", dataRow) { }
        protected TransferFromPackSubActPacs(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "TRANSFERFROMPACKSUBACTPACS", dataRow, isImported) { }
        public TransferFromPackSubActPacs(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public TransferFromPackSubActPacs(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public TransferFromPackSubActPacs() : base() { }

    }
}
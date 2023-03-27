
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PackageTransferProtocolDetail")] 

    /// <summary>
    /// Paket İçine Hizmet/Malzeme Aktarma Detayları
    /// </summary>
    public  partial class PackageTransferProtocolDetail : TTObject
    {
        public class PackageTransferProtocolDetailList : TTObjectCollection<PackageTransferProtocolDetail> { }
                    
        public class ChildPackageTransferProtocolDetailCollection : TTObject.TTChildObjectCollection<PackageTransferProtocolDetail>
        {
            public ChildPackageTransferProtocolDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPackageTransferProtocolDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Hedef Anlaşma
    /// </summary>
        public bool? TargetEpisodeProtocol
        {
            get { return (bool?)this["TARGETEPISODEPROTOCOL"]; }
            set { this["TARGETEPISODEPROTOCOL"] = value; }
        }

    /// <summary>
    /// Anlaşma Durumu
    /// </summary>
        public string PROTOCOLSTATUS
        {
            get { return (string)this["PROTOCOLSTATUS"]; }
            set { this["PROTOCOLSTATUS"] = value; }
        }

    /// <summary>
    /// Paket İçine Hizmet/Malzeme Aktarma ile ilişki
    /// </summary>
        public PackageTransfer PackageTransfer
        {
            get { return (PackageTransfer)((ITTObject)this).GetParent("PACKAGETRANSFER"); }
            set { this["PACKAGETRANSFER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Anlaşma ile ilişki
    /// </summary>
        public EpisodeProtocol EpisodeProtocol
        {
            get { return (EpisodeProtocol)((ITTObject)this).GetParent("EPISODEPROTOCOL"); }
            set { this["EPISODEPROTOCOL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected PackageTransferProtocolDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PackageTransferProtocolDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PackageTransferProtocolDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PackageTransferProtocolDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PackageTransferProtocolDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PACKAGETRANSFERPROTOCOLDETAIL", dataRow) { }
        protected PackageTransferProtocolDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PACKAGETRANSFERPROTOCOLDETAIL", dataRow, isImported) { }
        public PackageTransferProtocolDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PackageTransferProtocolDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PackageTransferProtocolDetail() : base() { }

    }
}
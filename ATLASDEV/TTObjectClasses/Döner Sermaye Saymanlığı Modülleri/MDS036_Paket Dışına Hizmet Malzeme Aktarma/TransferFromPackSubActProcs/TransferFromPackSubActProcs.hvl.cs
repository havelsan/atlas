
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="TransferFromPackSubActProcs")] 

    /// <summary>
    /// Paket Dışına Hizmet/Malzeme Aktarma Hizmet Detayı
    /// </summary>
    public  partial class TransferFromPackSubActProcs : TTObject
    {
        public class TransferFromPackSubActProcsList : TTObjectCollection<TransferFromPackSubActProcs> { }
                    
        public class ChildTransferFromPackSubActProcsCollection : TTObject.TTChildObjectCollection<TransferFromPackSubActProcs>
        {
            public ChildTransferFromPackSubActProcsCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildTransferFromPackSubActProcsCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
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
    /// Anlaşmaya transfer et
    /// </summary>
        public bool? TransferToProtocol
        {
            get { return (bool?)this["TRANSFERTOPROTOCOL"]; }
            set { this["TRANSFERTOPROTOCOL"] = value; }
        }

    /// <summary>
    /// Paket Bilgisi
    /// </summary>
        public string PackageInfo
        {
            get { return (string)this["PACKAGEINFO"]; }
            set { this["PACKAGEINFO"] = value; }
        }

    /// <summary>
    /// Hizmet hareketi ile ilişki
    /// </summary>
        public SubActionProcedure SubActionProcedure
        {
            get { return (SubActionProcedure)((ITTObject)this).GetParent("SUBACTIONPROCEDURE"); }
            set { this["SUBACTIONPROCEDURE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Paket Dışına Hizmet/Malzeme Aktarma ile ilişki
    /// </summary>
        public TransferFromPackage TransferFromPackage
        {
            get { return (TransferFromPackage)((ITTObject)this).GetParent("TRANSFERFROMPACKAGE"); }
            set { this["TRANSFERFROMPACKAGE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected TransferFromPackSubActProcs(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected TransferFromPackSubActProcs(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected TransferFromPackSubActProcs(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected TransferFromPackSubActProcs(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected TransferFromPackSubActProcs(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "TRANSFERFROMPACKSUBACTPROCS", dataRow) { }
        protected TransferFromPackSubActProcs(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "TRANSFERFROMPACKSUBACTPROCS", dataRow, isImported) { }
        public TransferFromPackSubActProcs(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public TransferFromPackSubActProcs(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public TransferFromPackSubActProcs() : base() { }

    }
}
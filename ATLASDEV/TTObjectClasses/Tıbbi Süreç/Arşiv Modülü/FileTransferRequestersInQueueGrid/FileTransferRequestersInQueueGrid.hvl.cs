
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="FileTransferRequestersInQueueGrid")] 

    public  partial class FileTransferRequestersInQueueGrid : TTObject
    {
        public class FileTransferRequestersInQueueGridList : TTObjectCollection<FileTransferRequestersInQueueGrid> { }
                    
        public class ChildFileTransferRequestersInQueueGridCollection : TTObject.TTChildObjectCollection<FileTransferRequestersInQueueGrid>
        {
            public ChildFileTransferRequestersInQueueGridCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildFileTransferRequestersInQueueGridCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid Cancelled { get { return new Guid("ed962d69-0909-426f-8652-4b85aec4f3ec"); } }
            public static Guid Fullfilled { get { return new Guid("37b2412c-c6a9-4bc3-9eb0-6b45eb58e68c"); } }
            public static Guid Request { get { return new Guid("5174972a-4e8d-407d-b1c2-c0c8b6f47ce2"); } }
        }

    /// <summary>
    /// Karşılandı
    /// </summary>
        public bool? Fullfilled
        {
            get { return (bool?)this["FULLFILLED"]; }
            set { this["FULLFILLED"] = value; }
        }

    /// <summary>
    /// Kuyruktaki Sırası
    /// </summary>
        public int? NoInQueue
        {
            get { return (int?)this["NOINQUEUE"]; }
            set { this["NOINQUEUE"] = value; }
        }

    /// <summary>
    /// Durumu
    /// </summary>
        public string RequestState
        {
            get { return (string)this["REQUESTSTATE"]; }
            set { this["REQUESTSTATE"] = value; }
        }

    /// <summary>
    /// Bölüme Gönder
    /// </summary>
        public bool? SendDepartment
        {
            get { return (bool?)this["SENDDEPARTMENT"]; }
            set { this["SENDDEPARTMENT"] = value; }
        }

    /// <summary>
    /// İstek Yapan Kullanıcı
    /// </summary>
        public ResUser Requester
        {
            get { return (ResUser)((ITTObject)this).GetParent("REQUESTER"); }
            set { this["REQUESTER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Patient Patient
        {
            get { return (Patient)((ITTObject)this).GetParent("PATIENT"); }
            set { this["PATIENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public FileTransfer FileTransfer
        {
            get { return (FileTransfer)((ITTObject)this).GetParent("FILETRANSFER"); }
            set { this["FILETRANSFER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// İstek Yapan Birim
    /// </summary>
        public ResSection RequesterUnit
        {
            get { return (ResSection)((ITTObject)this).GetParent("REQUESTERUNIT"); }
            set { this["REQUESTERUNIT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected FileTransferRequestersInQueueGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected FileTransferRequestersInQueueGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected FileTransferRequestersInQueueGrid(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected FileTransferRequestersInQueueGrid(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected FileTransferRequestersInQueueGrid(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "FILETRANSFERREQUESTERSINQUEUEGRID", dataRow) { }
        protected FileTransferRequestersInQueueGrid(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "FILETRANSFERREQUESTERSINQUEUEGRID", dataRow, isImported) { }
        public FileTransferRequestersInQueueGrid(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public FileTransferRequestersInQueueGrid(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public FileTransferRequestersInQueueGrid() : base() { }

        override protected void RunPreTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePreScript(transDef))
                base.RunPreTransition(transDef.BaseTransDef);
            this.PreTransition(transDef);
        }
        override protected void RunPostTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePostScript(transDef))
                base.RunPostTransition(transDef.BaseTransDef);
            this.PostTransition(transDef);
        }
        override protected void RunUndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBaseUndoScript(transDef))
                base.RunUndoTransition(transDef.BaseTransDef);
            this.UndoTransition(transDef);
        }
    }
}
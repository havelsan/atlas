
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="FileTransfer")] 

    /// <summary>
    /// Dosya Transfer (Arşiv Karşılama) İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
    public  partial class FileTransfer : EpisodeAction, IWorkListEpisodeAction
    {
        public class FileTransferList : TTObjectCollection<FileTransfer> { }
                    
        public class ChildFileTransferCollection : TTObject.TTChildObjectCollection<FileTransfer>
        {
            public ChildFileTransferCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildFileTransferCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid FullfilmentFromDepartment { get { return new Guid("0a0e0cda-0327-424e-a0ec-0be97744e417"); } }
            public static Guid WaitingForFullfilment { get { return new Guid("554c90ed-0890-4db9-8dcf-0cf5196556b3"); } }
            public static Guid AcknowledgementReceipt { get { return new Guid("8b0b25c4-5a8d-4e53-b52e-4be39461527a"); } }
            public static Guid FullfilmentFromMR { get { return new Guid("e3e34b0e-63dd-42ff-83d4-0752c5c26b03"); } }
            public static Guid MissingFile { get { return new Guid("c92bace2-243a-4229-900f-a40409f9ae8f"); } }
            public static Guid Cancelled { get { return new Guid("17c47fa1-8d85-4eb7-ba78-348201e86e02"); } }
            public static Guid FileAcceptanceByMR { get { return new Guid("eac8447c-a6fe-4d72-a464-74033558061b"); } }
            public static Guid FileRequest { get { return new Guid("efe78481-c0d7-448d-96c6-8a0b216ef560"); } }
            public static Guid FileIsMissing { get { return new Guid("5c2626cd-712b-4107-b23d-bde68bae02fa"); } }
            public static Guid Accept { get { return new Guid("2211e9b0-9b8c-4d4d-80a3-6b128503e041"); } }
            public static Guid SendChart { get { return new Guid("829719f6-0272-4681-9a88-bbd5958d5b51"); } }
        }

    /// <summary>
    /// İstek Sebebi
    /// </summary>
        public string ReasonForRequest
        {
            get { return (string)this["REASONFORREQUEST"]; }
            set { this["REASONFORREQUEST"] = value; }
        }

    /// <summary>
    /// NoInQueue
    /// </summary>
        public int? NoInQueue
        {
            get { return (int?)this["NOINQUEUE"]; }
            set { this["NOINQUEUE"] = value; }
        }

    /// <summary>
    /// Sıra
    /// </summary>
        public string Row
        {
            get { return (string)this["ROW"]; }
            set { this["ROW"] = value; }
        }

    /// <summary>
    /// Arşiv Notu
    /// </summary>
        public string ArchiveNote
        {
            get { return (string)this["ARCHIVENOTE"]; }
            set { this["ARCHIVENOTE"] = value; }
        }

    /// <summary>
    /// Raf
    /// </summary>
        public string Shelf
        {
            get { return (string)this["SHELF"]; }
            set { this["SHELF"] = value; }
        }

    /// <summary>
    /// İstek Yapan Kullanıcı
    /// </summary>
        public ResUser Requester
        {
            get { return (ResUser)((ITTObject)this).GetParent("REQUESTER"); }
            set { this["REQUESTER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// İstek Yapan Bölüm
    /// </summary>
        public ResSection RequesterDepartment
        {
            get { return (ResSection)((ITTObject)this).GetParent("REQUESTERDEPARTMENT"); }
            set { this["REQUESTERDEPARTMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Dosyanın Yeri
    /// </summary>
        public ResSection FileLocation
        {
            get { return (ResSection)((ITTObject)this).GetParent("FILELOCATION"); }
            set { this["FILELOCATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateRequestersInQueueCollection()
        {
            _RequestersInQueue = new FileTransferRequestersInQueueGrid.ChildFileTransferRequestersInQueueGridCollection(this, new Guid("9f1e3937-0979-46b5-a34f-214025f13d00"));
            ((ITTChildObjectCollection)_RequestersInQueue).GetChildren();
        }

        protected FileTransferRequestersInQueueGrid.ChildFileTransferRequestersInQueueGridCollection _RequestersInQueue = null;
        public FileTransferRequestersInQueueGrid.ChildFileTransferRequestersInQueueGridCollection RequestersInQueue
        {
            get
            {
                if (_RequestersInQueue == null)
                    CreateRequestersInQueueCollection();
                return _RequestersInQueue;
            }
        }

        virtual protected void CreatePatientEpisodeDetailsCollection()
        {
            _PatientEpisodeDetails = new FileTransferPatientEpisodeDetailGrid.ChildFileTransferPatientEpisodeDetailGridCollection(this, new Guid("0b328673-5262-426d-a197-bc6f526077c3"));
            ((ITTChildObjectCollection)_PatientEpisodeDetails).GetChildren();
        }

        protected FileTransferPatientEpisodeDetailGrid.ChildFileTransferPatientEpisodeDetailGridCollection _PatientEpisodeDetails = null;
    /// <summary>
    /// Child collection for Hasta Episode Bilgileri
    /// </summary>
        public FileTransferPatientEpisodeDetailGrid.ChildFileTransferPatientEpisodeDetailGridCollection PatientEpisodeDetails
        {
            get
            {
                if (_PatientEpisodeDetails == null)
                    CreatePatientEpisodeDetailsCollection();
                return _PatientEpisodeDetails;
            }
        }

        protected FileTransfer(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected FileTransfer(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected FileTransfer(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected FileTransfer(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected FileTransfer(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "FILETRANSFER", dataRow) { }
        protected FileTransfer(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "FILETRANSFER", dataRow, isImported) { }
        public FileTransfer(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public FileTransfer(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public FileTransfer() : base() { }

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
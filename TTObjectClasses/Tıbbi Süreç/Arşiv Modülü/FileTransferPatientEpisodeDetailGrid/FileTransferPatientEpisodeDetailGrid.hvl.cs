
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="FileTransferPatientEpisodeDetailGrid")] 

    public  partial class FileTransferPatientEpisodeDetailGrid : TTObject
    {
        public class FileTransferPatientEpisodeDetailGridList : TTObjectCollection<FileTransferPatientEpisodeDetailGrid> { }
                    
        public class ChildFileTransferPatientEpisodeDetailGridCollection : TTObject.TTChildObjectCollection<FileTransferPatientEpisodeDetailGrid>
        {
            public ChildFileTransferPatientEpisodeDetailGridCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildFileTransferPatientEpisodeDetailGridCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Seç
    /// </summary>
        public bool? Selection
        {
            get { return (bool?)this["SELECTION"]; }
            set { this["SELECTION"] = value; }
        }

    /// <summary>
    /// Vaka Tarihi
    /// </summary>
        public DateTime? EpisodeOpeningDate
        {
            get { return (DateTime?)this["EPISODEOPENINGDATE"]; }
            set { this["EPISODEOPENINGDATE"] = value; }
        }

    /// <summary>
    /// Vaka Numarası
    /// </summary>
        public long? EpisodeID
        {
            get { return (long?)this["EPISODEID"]; }
            set { this["EPISODEID"] = value; }
        }

    /// <summary>
    /// Kabul Sebebi
    /// </summary>
        public string ReasonForAdmission
        {
            get { return (string)this["REASONFORADMISSION"]; }
            set { this["REASONFORADMISSION"] = value; }
        }

    /// <summary>
    /// Cilt No
    /// </summary>
        public long? VolumeNo
        {
            get { return (long?)this["VOLUMENO"]; }
            set { this["VOLUMENO"] = value; }
        }

    /// <summary>
    /// Hasta Episode Bilgileri
    /// </summary>
        public FileTransfer EpisodeAction
        {
            get { return (FileTransfer)((ITTObject)this).GetParent("EPISODEACTION"); }
            set { this["EPISODEACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Tanı
    /// </summary>
        public DiagnosisDefinition Diagnosis
        {
            get { return (DiagnosisDefinition)((ITTObject)this).GetParent("DIAGNOSIS"); }
            set { this["DIAGNOSIS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected FileTransferPatientEpisodeDetailGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected FileTransferPatientEpisodeDetailGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected FileTransferPatientEpisodeDetailGrid(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected FileTransferPatientEpisodeDetailGrid(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected FileTransferPatientEpisodeDetailGrid(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "FILETRANSFERPATIENTEPISODEDETAILGRID", dataRow) { }
        protected FileTransferPatientEpisodeDetailGrid(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "FILETRANSFERPATIENTEPISODEDETAILGRID", dataRow, isImported) { }
        public FileTransferPatientEpisodeDetailGrid(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public FileTransferPatientEpisodeDetailGrid(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public FileTransferPatientEpisodeDetailGrid() : base() { }

    }
}
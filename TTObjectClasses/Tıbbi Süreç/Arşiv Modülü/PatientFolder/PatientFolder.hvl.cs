
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PatientFolder")] 

    /// <summary>
    /// Hasta Dosyası
    /// </summary>
    public  partial class PatientFolder : TTObject
    {
        public class PatientFolderList : TTObjectCollection<PatientFolder> { }
                    
        public class ChildPatientFolderCollection : TTObject.TTChildObjectCollection<PatientFolder>
        {
            public ChildPatientFolderCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPatientFolderCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Hasta Dosyası No
    /// </summary>
        public TTSequence PatientFolderID
        {
            get { return GetSequence("PATIENTFOLDERID"); }
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
    /// Dosyanın Durumu
    /// </summary>
        public FolderStatusEnum? FolderStatus
        {
            get { return (FolderStatusEnum?)(int?)this["FOLDERSTATUS"]; }
            set { this["FOLDERSTATUS"] = value; }
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
    /// Dosyanın Son İşlemi
    /// </summary>
        public PatientFolderTransaction LastPatientFolderTransaction
        {
            get { return (PatientFolderTransaction)((ITTObject)this).GetParent("LASTPATIENTFOLDERTRANSACTION"); }
            set { this["LASTPATIENTFOLDERTRANSACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Dosyanın Yeri
    /// </summary>
        public ResSection FolderLocation
        {
            get { return (ResSection)((ITTObject)this).GetParent("FOLDERLOCATION"); }
            set { this["FOLDERLOCATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ResBuilding Building
        {
            get { return (ResBuilding)((ITTObject)this).GetParent("BUILDING"); }
            set { this["BUILDING"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Raf
    /// </summary>
        public ResShelf ResShelf
        {
            get { return (ResShelf)((ITTObject)this).GetParent("RESSHELF"); }
            set { this["RESSHELF"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Dolap
    /// </summary>
        public ResCabinet ResCabinet
        {
            get { return (ResCabinet)((ITTObject)this).GetParent("RESCABINET"); }
            set { this["RESCABINET"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateEpisodeFoldersCollection()
        {
            _EpisodeFolders = new EpisodeFolder.ChildEpisodeFolderCollection(this, new Guid("075c3ad1-0c90-46bf-bd6e-c4f53672cbdb"));
            ((ITTChildObjectCollection)_EpisodeFolders).GetChildren();
        }

        protected EpisodeFolder.ChildEpisodeFolderCollection _EpisodeFolders = null;
    /// <summary>
    /// Child collection for Hasta Dosyası Detayları
    /// </summary>
        public EpisodeFolder.ChildEpisodeFolderCollection EpisodeFolders
        {
            get
            {
                if (_EpisodeFolders == null)
                    CreateEpisodeFoldersCollection();
                return _EpisodeFolders;
            }
        }

        virtual protected void CreateTransactionsCollection()
        {
            _Transactions = new PatientFolderTransaction.ChildPatientFolderTransactionCollection(this, new Guid("7abe1752-4796-4d79-b62e-b42a98f07831"));
            ((ITTChildObjectCollection)_Transactions).GetChildren();
        }

        protected PatientFolderTransaction.ChildPatientFolderTransactionCollection _Transactions = null;
    /// <summary>
    /// Child collection for Hasta Dosyası Hareketleri
    /// </summary>
        public PatientFolderTransaction.ChildPatientFolderTransactionCollection Transactions
        {
            get
            {
                if (_Transactions == null)
                    CreateTransactionsCollection();
                return _Transactions;
            }
        }

        protected PatientFolder(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PatientFolder(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PatientFolder(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PatientFolder(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PatientFolder(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PATIENTFOLDER", dataRow) { }
        protected PatientFolder(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PATIENTFOLDER", dataRow, isImported) { }
        public PatientFolder(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PatientFolder(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PatientFolder() : base() { }

    }
}
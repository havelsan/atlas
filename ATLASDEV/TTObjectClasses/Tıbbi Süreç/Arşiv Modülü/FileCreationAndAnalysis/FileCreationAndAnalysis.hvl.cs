
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="FileCreationAndAnalysis")] 

    /// <summary>
    /// Dosya Oluşturma ve Analiz (Arşiv Oluşturma) İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
    public  partial class FileCreationAndAnalysis : EpisodeAction, IWorkListEpisodeAction
    {
        public class FileCreationAndAnalysisList : TTObjectCollection<FileCreationAndAnalysis> { }
                    
        public class ChildFileCreationAndAnalysisCollection : TTObject.TTChildObjectCollection<FileCreationAndAnalysis>
        {
            public ChildFileCreationAndAnalysisCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildFileCreationAndAnalysisCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid Incomplete { get { return new Guid("385691da-525d-40ed-9f72-9d0efa20d300"); } }
            public static Guid NewRecord { get { return new Guid("2a894dd3-31e2-4730-b7f1-35333067a156"); } }
            public static Guid Archive { get { return new Guid("4d0f9aa5-5ccd-4ad3-bc0c-b36367ed87e3"); } }
            public static Guid Request { get { return new Guid("98948f30-d50e-4f63-80f2-d64412aef173"); } }
        }

    /// <summary>
    /// Eksik Dosyalarda
    /// </summary>
        public bool? InIncompleteArea
        {
            get { return (bool?)this["ININCOMPLETEAREA"]; }
            set { this["ININCOMPLETEAREA"] = value; }
        }

    /// <summary>
    /// Arşivde
    /// </summary>
        public bool? InArchive
        {
            get { return (bool?)this["INARCHIVE"]; }
            set { this["INARCHIVE"] = value; }
        }

    /// <summary>
    /// Yıl Bilgisi
    /// </summary>
        public string OnlyYear
        {
            get { return (string)this["ONLYYEAR"]; }
            set { this["ONLYYEAR"] = value; }
        }

    /// <summary>
    /// Hasta ve Yakınının Bölüm Uyum Eğitimi
    /// </summary>
        public bool? HMHASTAYAKINI
        {
            get { return (bool?)this["HMHASTAYAKINI"]; }
            set { this["HMHASTAYAKINI"] = value; }
        }

    /// <summary>
    /// Oda 
    /// </summary>
        public string Room
        {
            get { return (string)this["ROOM"]; }
            set { this["ROOM"] = value; }
        }

    /// <summary>
    /// Adli Vaka
    /// </summary>
        public bool? AdliVaka
        {
            get { return (bool?)this["ADLIVAKA"]; }
            set { this["ADLIVAKA"] = value; }
        }

    /// <summary>
    /// Hemşirelik Hizmetleri Eğitim Formu
    /// </summary>
        public bool? HMHEMSHIZ
        {
            get { return (bool?)this["HMHEMSHIZ"]; }
            set { this["HMHEMSHIZ"] = value; }
        }

    /// <summary>
    /// Hasta ve Hasta Yakını Bilgilendirme Formu
    /// </summary>
        public bool? HMHASTYAKFORM
        {
            get { return (bool?)this["HMHASTYAKFORM"]; }
            set { this["HMHASTYAKFORM"] = value; }
        }

    /// <summary>
    /// Hemşirelik Bakım Planı
    /// </summary>
        public bool? HMHEMSBAKPL
        {
            get { return (bool?)this["HMHEMSBAKPL"]; }
            set { this["HMHEMSBAKPL"] = value; }
        }

    /// <summary>
    /// Hemşire Gözlem Formu
    /// </summary>
        public bool? HMSIVIZFORM
        {
            get { return (bool?)this["HMSIVIZFORM"]; }
            set { this["HMSIVIZFORM"] = value; }
        }

    /// <summary>
    /// Giğer
    /// </summary>
        public bool? HMDIGER
        {
            get { return (bool?)this["HMDIGER"]; }
            set { this["HMDIGER"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string HMACIKLAMA
        {
            get { return (string)this["HMACIKLAMA"]; }
            set { this["HMACIKLAMA"] = value; }
        }

    /// <summary>
    /// Meslek Anamnez Formu
    /// </summary>
        public bool? HKMESANFORM
        {
            get { return (bool?)this["HKMESANFORM"]; }
            set { this["HKMESANFORM"] = value; }
        }

    /// <summary>
    /// Günlük Müşahede ve Müdahele Kağıdı
    /// </summary>
        public bool? HKGUNMUSKAG
        {
            get { return (bool?)this["HKGUNMUSKAG"]; }
            set { this["HKGUNMUSKAG"] = value; }
        }

    /// <summary>
    /// Anestezi Formları
    /// </summary>
        public bool? HKANESTEZI
        {
            get { return (bool?)this["HKANESTEZI"]; }
            set { this["HKANESTEZI"] = value; }
        }

    /// <summary>
    /// Onam Formları
    /// </summary>
        public bool? HKONAM
        {
            get { return (bool?)this["HKONAM"]; }
            set { this["HKONAM"] = value; }
        }

    /// <summary>
    /// Cerrahi Taraf Onam Formu
    /// </summary>
        public bool? HKCERTARONFORM
        {
            get { return (bool?)this["HKCERTARONFORM"]; }
            set { this["HKCERTARONFORM"] = value; }
        }

    /// <summary>
    /// Taburcu Olan Hastaları Bilgilendirme Formu
    /// </summary>
        public bool? HKTABHASTBIL
        {
            get { return (bool?)this["HKTABHASTBIL"]; }
            set { this["HKTABHASTBIL"] = value; }
        }

    /// <summary>
    /// Sağlık Kurulu Raporu
    /// </summary>
        public bool? HKSAGKURRAP
        {
            get { return (bool?)this["HKSAGKURRAP"]; }
            set { this["HKSAGKURRAP"] = value; }
        }

    /// <summary>
    /// Epikriz
    /// </summary>
        public bool? HKEPIKRIZ
        {
            get { return (bool?)this["HKEPIKRIZ"]; }
            set { this["HKEPIKRIZ"] = value; }
        }

    /// <summary>
    /// Hasta Tabelası
    /// </summary>
        public bool? HKHASTTAB
        {
            get { return (bool?)this["HKHASTTAB"]; }
            set { this["HKHASTTAB"] = value; }
        }

    /// <summary>
    /// Düşme Riski Ölçeği
    /// </summary>
        public bool? HKDUSRISOL
        {
            get { return (bool?)this["HKDUSRISOL"]; }
            set { this["HKDUSRISOL"] = value; }
        }

    /// <summary>
    /// Güvenli Cerrahi Kontrol Listesi
    /// </summary>
        public bool? HKGUCCERKONT
        {
            get { return (bool?)this["HKGUCCERKONT"]; }
            set { this["HKGUCCERKONT"] = value; }
        }

    /// <summary>
    /// Diğer
    /// </summary>
        public bool? HKDIGER
        {
            get { return (bool?)this["HKDIGER"]; }
            set { this["HKDIGER"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string HKACIKLAMA
        {
            get { return (string)this["HKACIKLAMA"]; }
            set { this["HKACIKLAMA"] = value; }
        }

    /// <summary>
    /// Hasta Giriş Kağıdı
    /// </summary>
        public bool? SEKHASGIRKAG
        {
            get { return (bool?)this["SEKHASGIRKAG"]; }
            set { this["SEKHASGIRKAG"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string SEKACIKLAMA
        {
            get { return (string)this["SEKACIKLAMA"]; }
            set { this["SEKACIKLAMA"] = value; }
        }

    /// <summary>
    /// Hemşire Gözlem Formu
    /// </summary>
        public bool? HMHEMGOZFORM
        {
            get { return (bool?)this["HMHEMGOZFORM"]; }
            set { this["HMHEMGOZFORM"] = value; }
        }

    /// <summary>
    /// FileLocation
    /// </summary>
        public ResSection FileLocation
        {
            get { return (ResSection)((ITTObject)this).GetParent("FILELOCATION"); }
            set { this["FILELOCATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Oda
    /// </summary>
        public ResArchiveRoom ResArchiveRoom
        {
            get { return (ResArchiveRoom)((ITTObject)this).GetParent("RESARCHIVEROOM"); }
            set { this["RESARCHIVEROOM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateStarterEpisodeFolderCollection()
        {
            _StarterEpisodeFolder = new EpisodeFolder.ChildEpisodeFolderCollection(this, new Guid("914993c3-597e-466b-bfd3-cbfb57551c35"));
            ((ITTChildObjectCollection)_StarterEpisodeFolder).GetChildren();
        }

        protected EpisodeFolder.ChildEpisodeFolderCollection _StarterEpisodeFolder = null;
        public EpisodeFolder.ChildEpisodeFolderCollection StarterEpisodeFolder
        {
            get
            {
                if (_StarterEpisodeFolder == null)
                    CreateStarterEpisodeFolderCollection();
                return _StarterEpisodeFolder;
            }
        }

        protected FileCreationAndAnalysis(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected FileCreationAndAnalysis(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected FileCreationAndAnalysis(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected FileCreationAndAnalysis(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected FileCreationAndAnalysis(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "FILECREATIONANDANALYSIS", dataRow) { }
        protected FileCreationAndAnalysis(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "FILECREATIONANDANALYSIS", dataRow, isImported) { }
        public FileCreationAndAnalysis(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public FileCreationAndAnalysis(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public FileCreationAndAnalysis() : base() { }

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
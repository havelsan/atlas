
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DefLaboratoryTestX")] 

    /// <summary>
    /// Laboratuvar Tetkik Tanımları
    /// </summary>
    public  partial class DefLaboratoryTestX : ProcedureDefinition
    {
        public class DefLaboratoryTestXList : TTObjectCollection<DefLaboratoryTestX> { }
                    
        public class ChildDefLaboratoryTestXCollection : TTObject.TTChildObjectCollection<DefLaboratoryTestX>
        {
            public ChildDefLaboratoryTestXCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDefLaboratoryTestXCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// S.A.T Testi
    /// </summary>
        public bool? IsSat
        {
            get { return (bool?)this["ISSAT"]; }
            set { this["ISSAT"] = value; }
        }

    /// <summary>
    /// Zaman Kontrollü
    /// </summary>
        public bool? IsTimeLimit
        {
            get { return (bool?)this["ISTIMELIMIT"]; }
            set { this["ISTIMELIMIT"] = value; }
        }

    /// <summary>
    /// Saklama Koşulları
    /// </summary>
        public string SampleStorage
        {
            get { return (string)this["SAMPLESTORAGE"]; }
            set { this["SAMPLESTORAGE"] = value; }
        }

    /// <summary>
    /// Kullanım Alanı
    /// </summary>
        public string Usage
        {
            get { return (string)this["USAGE"]; }
            set { this["USAGE"] = value; }
        }

    /// <summary>
    /// Cinsiyet Kontrollü
    /// </summary>
        public bool? IsSexControl
        {
            get { return (bool?)this["ISSEXCONTROL"]; }
            set { this["ISSEXCONTROL"] = value; }
        }

    /// <summary>
    /// Başlık Testi
    /// </summary>
        public bool? IsHeader
        {
            get { return (bool?)this["ISHEADER"]; }
            set { this["ISHEADER"] = value; }
        }

    /// <summary>
    /// Bağımlı Test
    /// </summary>
        public bool? IsBounded
        {
            get { return (bool?)this["ISBOUNDED"]; }
            set { this["ISBOUNDED"] = value; }
        }

    /// <summary>
    /// Tab Sırası
    /// </summary>
        public int? TabOrder
        {
            get { return (int?)this["TABORDER"]; }
            set { this["TABORDER"] = value; }
        }

    /// <summary>
    /// Yuvarlama Basamağı
    /// </summary>
        public string RoundDigit
        {
            get { return (string)this["ROUNDDIGIT"]; }
            set { this["ROUNDDIGIT"] = value; }
        }

    /// <summary>
    /// Çalışma Süresi
    /// </summary>
        public int? RunTime
        {
            get { return (int?)this["RUNTIME"]; }
            set { this["RUNTIME"] = value; }
        }

    /// <summary>
    /// Acil İstenemez
    /// </summary>
        public bool? IsNotUrgent
        {
            get { return (bool?)this["ISNOTURGENT"]; }
            set { this["ISNOTURGENT"] = value; }
        }

    /// <summary>
    /// Zaman Kontrolü
    /// </summary>
        public string TimeLimit
        {
            get { return (string)this["TIMELIMIT"]; }
            set { this["TIMELIMIT"] = value; }
        }

    /// <summary>
    /// Yorum
    /// </summary>
        public string Comment
        {
            get { return (string)this["COMMENT"]; }
            set { this["COMMENT"] = value; }
        }

    /// <summary>
    /// Alt Test
    /// </summary>
        public bool? IsSub
        {
            get { return (bool?)this["ISSUB"]; }
            set { this["ISSUB"] = value; }
        }

    /// <summary>
    /// Tetkik Bilgisi
    /// </summary>
        public string Info
        {
            get { return (string)this["INFO"]; }
            set { this["INFO"] = value; }
        }

    /// <summary>
    /// Tab Açıklaması
    /// </summary>
        public string TabDescription
        {
            get { return (string)this["TABDESCRIPTION"]; }
            set { this["TABDESCRIPTION"] = value; }
        }

    /// <summary>
    /// Yükleme Testi
    /// </summary>
        public bool? IsLoad
        {
            get { return (bool?)this["ISLOAD"]; }
            set { this["ISLOAD"] = value; }
        }

    /// <summary>
    /// En Az Örnek Miktarı
    /// </summary>
        public string LeastVolume
        {
            get { return (string)this["LEASTVOLUME"]; }
            set { this["LEASTVOLUME"] = value; }
        }

    /// <summary>
    /// Kısıtlı Teskik
    /// </summary>
        public bool? IsRestricted
        {
            get { return (bool?)this["ISRESTRICTED"]; }
            set { this["ISRESTRICTED"] = value; }
        }

    /// <summary>
    /// Cinsiyet Kontrolü
    /// </summary>
        public SexEnum? SexControl
        {
            get { return (SexEnum?)(int?)this["SEXCONTROL"]; }
            set { this["SEXCONTROL"] = value; }
        }

    /// <summary>
    /// Uyarı
    /// </summary>
        public string Warn
        {
            get { return (string)this["WARN"]; }
            set { this["WARN"] = value; }
        }

    /// <summary>
    /// Çok Referanslı
    /// </summary>
        public bool? IsMultiReference
        {
            get { return (bool?)this["ISMULTIREFERENCE"]; }
            set { this["ISMULTIREFERENCE"] = value; }
        }

    /// <summary>
    /// Pazartesi
    /// </summary>
        public bool? ResultDay1
        {
            get { return (bool?)this["RESULTDAY1"]; }
            set { this["RESULTDAY1"] = value; }
        }

        protected DefLaboratoryTestX(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DefLaboratoryTestX(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DefLaboratoryTestX(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DefLaboratoryTestX(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DefLaboratoryTestX(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DEFLABORATORYTESTX", dataRow) { }
        protected DefLaboratoryTestX(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DEFLABORATORYTESTX", dataRow, isImported) { }
        public DefLaboratoryTestX(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DefLaboratoryTestX(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DefLaboratoryTestX() : base() { }

    }
}
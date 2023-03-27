
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="Person")] 

    /// <summary>
    /// KULLANILMIYOR
    /// </summary>
    public  partial class Person : TTObject
    {
        public class PersonList : TTObjectCollection<Person> { }
                    
        public class ChildPersonCollection : TTObject.TTChildObjectCollection<Person>
        {
            public ChildPersonCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPersonCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Nüfus Cüzdanı Sıra No
    /// </summary>
        public string IdentificationSeriesNo
        {
            get { return (string)this["IDENTIFICATIONSERIESNO"]; }
            set { this["IDENTIFICATIONSERIESNO"] = value; }
        }

    /// <summary>
    /// Anne Adı
    /// </summary>
        public string MotherName
        {
            get { return (string)this["MOTHERNAME"]; }
            set { this["MOTHERNAME"] = value; }
        }

    /// <summary>
    /// Aile No
    /// </summary>
        public string FamilyNo
        {
            get { return (string)this["FAMILYNO"]; }
            set { this["FAMILYNO"] = value; }
        }

    /// <summary>
    /// Doğum Yeri(Diğer)
    /// </summary>
        public string OtherBirthPlace
        {
            get { return (string)this["OTHERBIRTHPLACE"]; }
            set { this["OTHERBIRTHPLACE"] = value; }
        }

    /// <summary>
    /// Soyadı
    /// </summary>
        public string Surname
        {
            get { return (string)this["SURNAME"]; }
            set { this["SURNAME"] = value; }
        }

    /// <summary>
    /// Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

    /// <summary>
    /// Baba Adı
    /// </summary>
        public string FatherName
        {
            get { return (string)this["FATHERNAME"]; }
            set { this["FATHERNAME"] = value; }
        }

    /// <summary>
    /// Kayıtlı Olduğu Mahalle/Köy
    /// </summary>
        public string VillageOfRegistry
        {
            get { return (string)this["VILLAGEOFREGISTRY"]; }
            set { this["VILLAGEOFREGISTRY"] = value; }
        }

    /// <summary>
    /// Nüfus Cüzdanı No
    /// </summary>
        public string IdentificationCardNo
        {
            get { return (string)this["IDENTIFICATIONCARDNO"]; }
            set { this["IDENTIFICATIONCARDNO"] = value; }
        }

    /// <summary>
    /// İsim property si update edildiğinde true yapılır. Tokenların update edilmesi için kullanılır.
    /// </summary>
        public bool? NameIsUpdated
        {
            get { return (bool?)this["NAMEISUPDATED"]; }
            set { this["NAMEISUPDATED"] = value; }
        }

    /// <summary>
    /// Nüfuz Cüzdanı Cilt No
    /// </summary>
        public string IdentificationVolumeNo
        {
            get { return (string)this["IDENTIFICATIONVOLUMENO"]; }
            set { this["IDENTIFICATIONVOLUMENO"] = value; }
        }

    /// <summary>
    /// Soyisim property si update edildiğinde true yapılır. Tokenların update edilmesi için kullanılır.
    /// </summary>
        public bool? SurnameIsUpdated
        {
            get { return (bool?)this["SURNAMEISUPDATED"]; }
            set { this["SURNAMEISUPDATED"] = value; }
        }

    /// <summary>
    /// Sadece Yıl
    /// </summary>
        public bool? BDYearOnly
        {
            get { return (bool?)this["BDYEARONLY"]; }
            set { this["BDYEARONLY"] = value; }
        }

    /// <summary>
    /// Nüfus Cüzdanı Seri No
    /// </summary>
        public string IdentificationCardSerialNo
        {
            get { return (string)this["IDENTIFICATIONCARDSERIALNO"]; }
            set { this["IDENTIFICATIONCARDSERIALNO"] = value; }
        }

    /// <summary>
    /// Kimlik/Sigorta No (Yabancı Hastalar)
    /// </summary>
        public double? ForeignUniqueRefNo
        {
            get { return (double?)this["FOREIGNUNIQUEREFNO"]; }
            set { this["FOREIGNUNIQUEREFNO"] = value; }
        }

    /// <summary>
    /// Doğum Tarihi
    /// </summary>
        public DateTime? BirthDate
        {
            get { return (DateTime?)this["BIRTHDATE"]; }
            set { this["BIRTHDATE"] = value; }
        }

    /// <summary>
    /// Vefat Tarihi
    /// </summary>
        public DateTime? ExDate
        {
            get { return (DateTime?)this["EXDATE"]; }
            set { this["EXDATE"] = value; }
        }

    /// <summary>
    /// T.C. Kimlik No
    /// </summary>
        public long? UniqueRefNo
        {
            get { return (long?)this["UNIQUEREFNO"]; }
            set { this["UNIQUEREFNO"] = value; }
        }

    /// <summary>
    /// Pasaport No
    /// </summary>
        public string PassportNo
        {
            get { return (string)this["PASSPORTNO"]; }
            set { this["PASSPORTNO"] = value; }
        }

    /// <summary>
    /// Verildiği Yer
    /// </summary>
        public string IdentificationGivenTown
        {
            get { return (string)this["IDENTIFICATIONGIVENTOWN"]; }
            set { this["IDENTIFICATIONGIVENTOWN"] = value; }
        }

    /// <summary>
    /// Verilme Nedeni
    /// </summary>
        public string IdentificationGivenReason
        {
            get { return (string)this["IDENTIFICATIONGIVENREASON"]; }
            set { this["IDENTIFICATIONGIVENREASON"] = value; }
        }

    /// <summary>
    /// Verilme Tarihi
    /// </summary>
        public DateTime? IdentificationGivenDate
        {
            get { return (DateTime?)this["IDENTIFICATIONGIVENDATE"]; }
            set { this["IDENTIFICATIONGIVENDATE"] = value; }
        }

    /// <summary>
    /// Doğum Yeri(Diğer)
    /// </summary>
        public string BirthPlace
        {
            get { return (string)this["BIRTHPLACE"]; }
            set { this["BIRTHPLACE"] = value; }
        }

    /// <summary>
    /// Hastanın 'Cep Telefonu' Bilgisini Taşıyan Alandır
    /// </summary>
        public string MobilePhone
        {
            get { return (string)this["MOBILEPHONE"]; }
            set { this["MOBILEPHONE"] = value; }
        }

    /// <summary>
    /// Ölüm Raporunun Numarası
    /// </summary>
        public int? DeathReportNo
        {
            get { return (int?)this["DEATHREPORTNO"]; }
            set { this["DEATHREPORTNO"] = value; }
        }

    /// <summary>
    /// Gizli T.C. Kimlik No
    /// </summary>
        public long? PrivacyUniqueRefNo
        {
            get { return (long?)this["PRIVACYUNIQUEREFNO"]; }
            set { this["PRIVACYUNIQUEREFNO"] = value; }
        }

    /// <summary>
    /// Kişinin Ev telefonu alanını taşıyan alandır
    /// </summary>
        public string HomePhone
        {
            get { return (string)this["HOMEPHONE"]; }
            set { this["HOMEPHONE"] = value; }
        }

    /// <summary>
    /// Yeni eklendi bu kullanılmalı.
    /// </summary>
        public SKRSIlceKodlari TownOfBirthSKRS
        {
            get { return (SKRSIlceKodlari)((ITTObject)this).GetParent("TOWNOFBIRTHSKRS"); }
            set { this["TOWNOFBIRTHSKRS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Doğum ili
    /// </summary>
        public SKRSILKodlari CityOfBirth
        {
            get { return (SKRSILKodlari)((ITTObject)this).GetParent("CITYOFBIRTH"); }
            set { this["CITYOFBIRTH"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Ülke
    /// </summary>
        public SKRSUlkeKodlari CountryOfBirth
        {
            get { return (SKRSUlkeKodlari)((ITTObject)this).GetParent("COUNTRYOFBIRTH"); }
            set { this["COUNTRYOFBIRTH"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Doğum İlçesi
    /// </summary>
        public TownDefinitions TownOfBirth
        {
            get { return (TownDefinitions)((ITTObject)this).GetParent("TOWNOFBIRTH"); }
            set { this["TOWNOFBIRTH"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Nüfusa Kayıtlı Olduğu İlçe
    /// </summary>
        public TownDefinitions TownOfRegistry
        {
            get { return (TownDefinitions)((ITTObject)this).GetParent("TOWNOFREGISTRY"); }
            set { this["TOWNOFREGISTRY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Nüfusa Kayıtlı olduğu İl
    /// </summary>
        public SKRSILKodlari CityOfRegistry
        {
            get { return (SKRSILKodlari)((ITTObject)this).GetParent("CITYOFREGISTRY"); }
            set { this["CITYOFREGISTRY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Nationality
    /// </summary>
        public SKRSUlkeKodlari Nationality
        {
            get { return (SKRSUlkeKodlari)((ITTObject)this).GetParent("NATIONALITY"); }
            set { this["NATIONALITY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Yeni eklendi bu kullanılmalı.
    /// </summary>
        public SKRSIlceKodlari TownOfRegistrySKRS
        {
            get { return (SKRSIlceKodlari)((ITTObject)this).GetParent("TOWNOFREGISTRYSKRS"); }
            set { this["TOWNOFREGISTRYSKRS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Sex
    /// </summary>
        public SKRSCinsiyet Sex
        {
            get { return (SKRSCinsiyet)((ITTObject)this).GetParent("SEX"); }
            set { this["SEX"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSMedeniHali SKRSMaritalStatus
        {
            get { return (SKRSMedeniHali)((ITTObject)this).GetParent("SKRSMARITALSTATUS"); }
            set { this["SKRSMARITALSTATUS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateResUsersCollection()
        {
            _ResUsers = new ResUser.ChildResUserCollection(this, new Guid("982bed6a-c9e7-495e-a244-3672ae678297"));
            ((ITTChildObjectCollection)_ResUsers).GetChildren();
        }

        protected ResUser.ChildResUserCollection _ResUsers = null;
    /// <summary>
    /// Child collection for Kişi
    /// </summary>
        public ResUser.ChildResUserCollection ResUsers
        {
            get
            {
                if (_ResUsers == null)
                    CreateResUsersCollection();
                return _ResUsers;
            }
        }

        protected Person(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected Person(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected Person(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected Person(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected Person(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PERSON", dataRow) { }
        protected Person(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PERSON", dataRow, isImported) { }
        public Person(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public Person(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public Person() : base() { }

    }
}
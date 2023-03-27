
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MPBSTurkishPersonnel")] 

    /// <summary>
    /// Türk Personel
    /// </summary>
    public  partial class MPBSTurkishPersonnel : MPBSPersonnel
    {
        public class MPBSTurkishPersonnelList : TTObjectCollection<MPBSTurkishPersonnel> { }
                    
        public class ChildMPBSTurkishPersonnelCollection : TTObject.TTChildObjectCollection<MPBSTurkishPersonnel>
        {
            public ChildMPBSTurkishPersonnelCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMPBSTurkishPersonnelCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Mahalle-Köy
    /// </summary>
        public string DistrictVillage
        {
            get { return (string)this["DISTRICTVILLAGE"]; }
            set { this["DISTRICTVILLAGE"] = value; }
        }

    /// <summary>
    /// Dini
    /// </summary>
        public string Religion
        {
            get { return (string)this["RELIGION"]; }
            set { this["RELIGION"] = value; }
        }

    /// <summary>
    /// Cilt No
    /// </summary>
        public string TomeNo
        {
            get { return (string)this["TOMENO"]; }
            set { this["TOMENO"] = value; }
        }

    /// <summary>
    /// Nüfus Cüzdan Kayıt No
    /// </summary>
        public string BCRegistrationNo
        {
            get { return (string)this["BCREGISTRATIONNO"]; }
            set { this["BCREGISTRATIONNO"] = value; }
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
    /// Ana Adı
    /// </summary>
        public string MotherName
        {
            get { return (string)this["MOTHERNAME"]; }
            set { this["MOTHERNAME"] = value; }
        }

    /// <summary>
    /// Nüfus Cüzdan No
    /// </summary>
        public string BCSerialNo
        {
            get { return (string)this["BCSERIALNO"]; }
            set { this["BCSERIALNO"] = value; }
        }

    /// <summary>
    /// Aile Sıra No
    /// </summary>
        public string FamilyNo
        {
            get { return (string)this["FAMILYNO"]; }
            set { this["FAMILYNO"] = value; }
        }

    /// <summary>
    /// Nüfus Cüzdanının Verildiği Tarih
    /// </summary>
        public DateTime? BCGivenDate
        {
            get { return (DateTime?)this["BCGIVENDATE"]; }
            set { this["BCGIVENDATE"] = value; }
        }

    /// <summary>
    /// Evlilik Tarihi
    /// </summary>
        public DateTime? MarriageDate
        {
            get { return (DateTime?)this["MARRIAGEDATE"]; }
            set { this["MARRIAGEDATE"] = value; }
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
    /// Doğum Yeri
    /// </summary>
        public string BirthPlace
        {
            get { return (string)this["BIRTHPLACE"]; }
            set { this["BIRTHPLACE"] = value; }
        }

    /// <summary>
    /// Nüfus Cüzdanının Verildiği Yer
    /// </summary>
        public string BCGivenPlace
        {
            get { return (string)this["BCGIVENPLACE"]; }
            set { this["BCGIVENPLACE"] = value; }
        }

    /// <summary>
    /// Cinsiyet
    /// </summary>
        public SexEnum? Sex
        {
            get { return (SexEnum?)(int?)this["SEX"]; }
            set { this["SEX"] = value; }
        }

    /// <summary>
    /// Sıra No
    /// </summary>
        public string OrdinalNo
        {
            get { return (string)this["ORDINALNO"]; }
            set { this["ORDINALNO"] = value; }
        }

    /// <summary>
    /// Kan Grubu
    /// </summary>
        public BloodGroupEnum? BloodGroup
        {
            get { return (BloodGroupEnum?)(int?)this["BLOODGROUP"]; }
            set { this["BLOODGROUP"] = value; }
        }

    /// <summary>
    /// Medeni Hali
    /// </summary>
        public MaritalStatusEnum? MaritalStatus
        {
            get { return (MaritalStatusEnum?)(int?)this["MARITALSTATUS"]; }
            set { this["MARITALSTATUS"] = value; }
        }

    /// <summary>
    /// Ehliyet No
    /// </summary>
        public string DrivingLicenseNo
        {
            get { return (string)this["DRIVINGLICENSENO"]; }
            set { this["DRIVINGLICENSENO"] = value; }
        }

    /// <summary>
    /// Vergi No
    /// </summary>
        public string TaxNo
        {
            get { return (string)this["TAXNO"]; }
            set { this["TAXNO"] = value; }
        }

    /// <summary>
    /// TC Kimlik No
    /// </summary>
        public double? IdentityNumber
        {
            get { return (double?)this["IDENTITYNUMBER"]; }
            set { this["IDENTITYNUMBER"] = value; }
        }

    /// <summary>
    /// İlçe
    /// </summary>
        public TownDefinitions Town
        {
            get { return (TownDefinitions)((ITTObject)this).GetParent("TOWN"); }
            set { this["TOWN"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// İl
    /// </summary>
        public City City
        {
            get { return (City)((ITTObject)this).GetParent("CITY"); }
            set { this["CITY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MPBSTurkishPersonnel(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MPBSTurkishPersonnel(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MPBSTurkishPersonnel(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MPBSTurkishPersonnel(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MPBSTurkishPersonnel(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MPBSTURKISHPERSONNEL", dataRow) { }
        protected MPBSTurkishPersonnel(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MPBSTURKISHPERSONNEL", dataRow, isImported) { }
        public MPBSTurkishPersonnel(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MPBSTurkishPersonnel(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MPBSTurkishPersonnel() : base() { }

    }
}
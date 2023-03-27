
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PatientIdentityAndAddress")] 

    /// <summary>
    /// Hasta adres bilgisi
    /// </summary>
    public  partial class PatientIdentityAndAddress : TTObject
    {
        public class PatientIdentityAndAddressList : TTObjectCollection<PatientIdentityAndAddress> { }
                    
        public class ChildPatientIdentityAndAddressCollection : TTObject.TTChildObjectCollection<PatientIdentityAndAddress>
        {
            public ChildPatientIdentityAndAddressCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPatientIdentityAndAddressCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static BindingList<PatientIdentityAndAddress> GetPatientAddressByVemHastaIletisimKodu(TTObjectContext objectContext, string HASTA_ILETISIM_KODU)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTIDENTITYANDADDRESS"].QueryDefs["GetPatientAddressByVemHastaIletisimKodu"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HASTA_ILETISIM_KODU", HASTA_ILETISIM_KODU);

            return ((ITTQuery)objectContext).QueryObjects<PatientIdentityAndAddress>(queryDef, paramList);
        }

    /// <summary>
    /// İş Posta Kodu
    /// </summary>
        public string BusinessPostcode
        {
            get { return (string)this["BUSINESSPOSTCODE"]; }
            set { this["BUSINESSPOSTCODE"] = value; }
        }

    /// <summary>
    /// İş Telefonu
    /// </summary>
        public string BusinessPhone
        {
            get { return (string)this["BUSINESSPHONE"]; }
            set { this["BUSINESSPHONE"] = value; }
        }

    /// <summary>
    /// İş Adresi
    /// </summary>
        public string BusinessAddress
        {
            get { return (string)this["BUSINESSADDRESS"]; }
            set { this["BUSINESSADDRESS"] = value; }
        }

        public string ForeignAddress
        {
            get { return (string)this["FOREIGNADDRESS"]; }
            set { this["FOREIGNADDRESS"] = value; }
        }

        public string ForeignCity
        {
            get { return (string)this["FOREIGNCITY"]; }
            set { this["FOREIGNCITY"] = value; }
        }

        public string ForeignCountry
        {
            get { return (string)this["FOREIGNCOUNTRY"]; }
            set { this["FOREIGNCOUNTRY"] = value; }
        }

    /// <summary>
    /// Bina pafta
    /// </summary>
        public string BuildingSheet
        {
            get { return (string)this["BUILDINGSHEET"]; }
            set { this["BUILDINGSHEET"] = value; }
        }

    /// <summary>
    /// Bina parsel
    /// </summary>
        public string BuildingParcel
        {
            get { return (string)this["BUILDINGPARCEL"]; }
            set { this["BUILDINGPARCEL"] = value; }
        }

        public string BuildingNo
        {
            get { return (string)this["BUILDINGNO"]; }
            set { this["BUILDINGNO"] = value; }
        }

        public string BuildingCode
        {
            get { return (string)this["BUILDINGCODE"]; }
            set { this["BUILDINGCODE"] = value; }
        }

        public string BuildingBlockName
        {
            get { return (string)this["BUILDINGBLOCKNAME"]; }
            set { this["BUILDINGBLOCKNAME"] = value; }
        }

    /// <summary>
    /// Bina Ada
    /// </summary>
        public string BuildingSquare
        {
            get { return (string)this["BUILDINGSQUARE"]; }
            set { this["BUILDINGSQUARE"] = value; }
        }

        public string AddressNo
        {
            get { return (string)this["ADDRESSNO"]; }
            set { this["ADDRESSNO"] = value; }
        }

        public string SiteName
        {
            get { return (string)this["SITENAME"]; }
            set { this["SITENAME"] = value; }
        }

    /// <summary>
    /// Hastanın 'Ev Adresi' Bilgisini Taşıyan Alandır
    /// </summary>
        public string HomeAddress
        {
            get { return (string)this["HOMEADDRESS"]; }
            set { this["HOMEADDRESS"] = value; }
        }

        public string DisKapi
        {
            get { return (string)this["DISKAPI"]; }
            set { this["DISKAPI"] = value; }
        }

    /// <summary>
    /// Hastanın  'Ev Telefonu' Bilgisini Taşıyan Alandır
    /// </summary>
        public string HomePhone
        {
            get { return (string)this["HOMEPHONE"]; }
            set { this["HOMEPHONE"] = value; }
        }

    /// <summary>
    /// Hastanın Aile Resisinin  Güncel 'Posta Kodu' Bilgisini Taşıyan Alandır
    /// </summary>
        public string HomePostcode
        {
            get { return (string)this["HOMEPOSTCODE"]; }
            set { this["HOMEPOSTCODE"] = value; }
        }

        public string IcKapi
        {
            get { return (string)this["ICKAPI"]; }
            set { this["ICKAPI"] = value; }
        }

    /// <summary>
    /// Hastanın 'Cep Telefonu' Bilgisini Taşıyan Alandır
    /// </summary>
        public string MobilePhone
        {
            get { return (string)this["MOBILEPHONE"]; }
            set { this["MOBILEPHONE"] = value; }
        }

        public string SKRSAcikAdresIlce
        {
            get { return (string)this["SKRSACIKADRESILCE"]; }
            set { this["SKRSACIKADRESILCE"] = value; }
        }

        public string SKRSAdresKodu
        {
            get { return (string)this["SKRSADRESKODU"]; }
            set { this["SKRSADRESKODU"] = value; }
        }

    /// <summary>
    /// Yakınının cep telefonu numarası
    /// </summary>
        public string RelativeMobilePhone
        {
            get { return (string)this["RELATIVEMOBILEPHONE"]; }
            set { this["RELATIVEMOBILEPHONE"] = value; }
        }

    /// <summary>
    /// Hastanın yakınının 'Ev Adresi' Bilgisini Taşıyan Alandır
    /// </summary>
        public string RelativeHomeAddress
        {
            get { return (string)this["RELATIVEHOMEADDRESS"]; }
            set { this["RELATIVEHOMEADDRESS"] = value; }
        }

    /// <summary>
    /// Yakınının ad ve soyad bilgisi
    /// </summary>
        public string RelativeFullName
        {
            get { return (string)this["RELATIVEFULLNAME"]; }
            set { this["RELATIVEFULLNAME"] = value; }
        }

    /// <summary>
    /// Vem import için , import edildiği tablonun nesne kodu
    /// </summary>
        public string VemHastaIletisimKodu
        {
            get { return (string)this["VEMHASTAILETISIMKODU"]; }
            set { this["VEMHASTAILETISIMKODU"] = value; }
        }

    /// <summary>
    /// Hastanın Güncel İkamet Ettiği İl Bilgisini Taşıyan Alandır
    /// </summary>
        public City HomeCity
        {
            get { return (City)((ITTObject)this).GetParent("HOMECITY"); }
            set { this["HOMECITY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Hastanın Güncel İkamet Ettiği Ülke Bilgisini Taşıyan Alandır
    /// </summary>
        public Country HomeCountry
        {
            get { return (Country)((ITTObject)this).GetParent("HOMECOUNTRY"); }
            set { this["HOMECOUNTRY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSAdresKoduSeviyesi SKRSAdresKoduSeviyesi
        {
            get { return (SKRSAdresKoduSeviyesi)((ITTObject)this).GetParent("SKRSADRESKODUSEVIYESI"); }
            set { this["SKRSADRESKODUSEVIYESI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSAdresTipi SKRSAdresTipi
        {
            get { return (SKRSAdresTipi)((ITTObject)this).GetParent("SKRSADRESTIPI"); }
            set { this["SKRSADRESTIPI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSIlceKodlari SKRSIlceKodlari
        {
            get { return (SKRSIlceKodlari)((ITTObject)this).GetParent("SKRSILCEKODLARI"); }
            set { this["SKRSILCEKODLARI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSILKodlari SKRSILKodlari
        {
            get { return (SKRSILKodlari)((ITTObject)this).GetParent("SKRSILKODLARI"); }
            set { this["SKRSILKODLARI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSKoyKodlari SKRSKoyKodlari
        {
            get { return (SKRSKoyKodlari)((ITTObject)this).GetParent("SKRSKOYKODLARI"); }
            set { this["SKRSKOYKODLARI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSMahalleKodlari SKRSMahalleKodlari
        {
            get { return (SKRSMahalleKodlari)((ITTObject)this).GetParent("SKRSMAHALLEKODLARI"); }
            set { this["SKRSMAHALLEKODLARI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// İl
    /// </summary>
        public City BusinessCity
        {
            get { return (City)((ITTObject)this).GetParent("BUSINESSCITY"); }
            set { this["BUSINESSCITY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Ülke
    /// </summary>
        public Country BusinessCountry
        {
            get { return (Country)((ITTObject)this).GetParent("BUSINESSCOUNTRY"); }
            set { this["BUSINESSCOUNTRY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Bucak
    /// </summary>
        public SKRSBucakKodlari SKRSBucakKodu
        {
            get { return (SKRSBucakKodlari)((ITTObject)this).GetParent("SKRSBUCAKKODU"); }
            set { this["SKRSBUCAKKODU"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Csbm
    /// </summary>
        public SKRSCSBMTipi SKRSCsbmKodu
        {
            get { return (SKRSCSBMTipi)((ITTObject)this).GetParent("SKRSCSBMKODU"); }
            set { this["SKRSCSBMKODU"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSIlceKodlari BusinessTown
        {
            get { return (SKRSIlceKodlari)((ITTObject)this).GetParent("BUSINESSTOWN"); }
            set { this["BUSINESSTOWN"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSIlceKodlari HomeTown
        {
            get { return (SKRSIlceKodlari)((ITTObject)this).GetParent("HOMETOWN"); }
            set { this["HOMETOWN"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateAdditionalAdressesCollection()
        {
            _AdditionalAdresses = new AdditionalAdress.ChildAdditionalAdressCollection(this, new Guid("95fcd56b-fc82-4c6d-bc4f-150f96a20565"));
            ((ITTChildObjectCollection)_AdditionalAdresses).GetChildren();
        }

        protected AdditionalAdress.ChildAdditionalAdressCollection _AdditionalAdresses = null;
        public AdditionalAdress.ChildAdditionalAdressCollection AdditionalAdresses
        {
            get
            {
                if (_AdditionalAdresses == null)
                    CreateAdditionalAdressesCollection();
                return _AdditionalAdresses;
            }
        }

        virtual protected void CreateAdditionalPhoneCollection()
        {
            _AdditionalPhone = new AdditionalPhone.ChildAdditionalPhoneCollection(this, new Guid("c8a0ae2c-b86d-439f-b221-5ae10aaf026a"));
            ((ITTChildObjectCollection)_AdditionalPhone).GetChildren();
        }

        protected AdditionalPhone.ChildAdditionalPhoneCollection _AdditionalPhone = null;
        public AdditionalPhone.ChildAdditionalPhoneCollection AdditionalPhone
        {
            get
            {
                if (_AdditionalPhone == null)
                    CreateAdditionalPhoneCollection();
                return _AdditionalPhone;
            }
        }

        protected PatientIdentityAndAddress(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PatientIdentityAndAddress(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PatientIdentityAndAddress(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PatientIdentityAndAddress(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PatientIdentityAndAddress(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PATIENTIDENTITYANDADDRESS", dataRow) { }
        protected PatientIdentityAndAddress(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PATIENTIDENTITYANDADDRESS", dataRow, isImported) { }
        public PatientIdentityAndAddress(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PatientIdentityAndAddress(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PatientIdentityAndAddress() : base() { }

    }
}
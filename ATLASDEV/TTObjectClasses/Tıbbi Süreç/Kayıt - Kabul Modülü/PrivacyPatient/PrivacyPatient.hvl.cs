
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PrivacyPatient")] 

    /// <summary>
    /// İzole Hasta
    /// </summary>
    public  partial class PrivacyPatient : TTObject
    {
        public class PrivacyPatientList : TTObjectCollection<PrivacyPatient> { }
                    
        public class ChildPrivacyPatientCollection : TTObject.TTChildObjectCollection<PrivacyPatient>
        {
            public ChildPrivacyPatientCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPrivacyPatientCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public string Email
        {
            get { return (string)this["EMAIL"]; }
            set { this["EMAIL"] = value; }
        }

        public string FatherName
        {
            get { return (string)this["FATHERNAME"]; }
            set { this["FATHERNAME"] = value; }
        }

    /// <summary>
    /// Sigorta No(YH)
    /// </summary>
        public double? ForeignUniqueRefNo
        {
            get { return (double?)this["FOREIGNUNIQUEREFNO"]; }
            set { this["FOREIGNUNIQUEREFNO"] = value; }
        }

    /// <summary>
    /// Hastanın 'Ev Adresi' Bilgisini Taşıyan Alandır
    /// </summary>
        public string HomeAddress
        {
            get { return (string)this["HOMEADDRESS"]; }
            set { this["HOMEADDRESS"] = value; }
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
    /// Hastanın 'Cep Telefonu' Bilgisini Taşıyan Alandır
    /// </summary>
        public string MobilePhone
        {
            get { return (string)this["MOBILEPHONE"]; }
            set { this["MOBILEPHONE"] = value; }
        }

        public string MotherName
        {
            get { return (string)this["MOTHERNAME"]; }
            set { this["MOTHERNAME"] = value; }
        }

        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

    /// <summary>
    /// Hastanın Fotografının Bulunduğu Alan
    /// </summary>
        public object Photo
        {
            get { return (object)this["PHOTO"]; }
            set { this["PHOTO"] = value; }
        }

        public string Surname
        {
            get { return (string)this["SURNAME"]; }
            set { this["SURNAME"] = value; }
        }

        public long? UniqueRefNo
        {
            get { return (long?)this["UNIQUEREFNO"]; }
            set { this["UNIQUEREFNO"] = value; }
        }

        public int? YUPASSNO
        {
            get { return (int?)this["YUPASSNO"]; }
            set { this["YUPASSNO"] = value; }
        }

    /// <summary>
    /// Doğum İli
    /// </summary>
        public City PrivacyCityOfBirth
        {
            get { return (City)((ITTObject)this).GetParent("PRIVACYCITYOFBIRTH"); }
            set { this["PRIVACYCITYOFBIRTH"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Nüfusa Kayıtlı Olduğu İl
    /// </summary>
        public City PrivacyCityOfRegistry
        {
            get { return (City)((ITTObject)this).GetParent("PRIVACYCITYOFREGISTRY"); }
            set { this["PRIVACYCITYOFREGISTRY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Ülke
    /// </summary>
        public Country PrivacyCountryOfBirth
        {
            get { return (Country)((ITTObject)this).GetParent("PRIVACYCOUNTRYOFBIRTH"); }
            set { this["PRIVACYCOUNTRYOFBIRTH"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Hastanın Güncel İkamet Ettiği İl Bilgisini Taşıyan Alandı
    /// </summary>
        public City PrivacyHomeCity
        {
            get { return (City)((ITTObject)this).GetParent("PRIVACYHOMECITY"); }
            set { this["PRIVACYHOMECITY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Ülke
    /// </summary>
        public Country PrivacyHomeCountry
        {
            get { return (Country)((ITTObject)this).GetParent("PRIVACYHOMECOUNTRY"); }
            set { this["PRIVACYHOMECOUNTRY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Hastanın Güncel İkamet Ettiği İlçe Bilgisini Taşıyan Alandır
    /// </summary>
        public TownDefinitions PrivacyHomeTown
        {
            get { return (TownDefinitions)((ITTObject)this).GetParent("PRIVACYHOMETOWN"); }
            set { this["PRIVACYHOMETOWN"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Doğum İlçesi
    /// </summary>
        public TownDefinitions PrivacyTownOfBirth
        {
            get { return (TownDefinitions)((ITTObject)this).GetParent("PRIVACYTOWNOFBIRTH"); }
            set { this["PRIVACYTOWNOFBIRTH"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Nüfusa Kayıtlı Olduğu İlçe
    /// </summary>
        public TownDefinitions PrivacyTownOfRegistry
        {
            get { return (TownDefinitions)((ITTObject)this).GetParent("PRIVACYTOWNOFREGISTRY"); }
            set { this["PRIVACYTOWNOFREGISTRY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected PrivacyPatient(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PrivacyPatient(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PrivacyPatient(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PrivacyPatient(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PrivacyPatient(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PRIVACYPATIENT", dataRow) { }
        protected PrivacyPatient(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PRIVACYPATIENT", dataRow, isImported) { }
        public PrivacyPatient(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PrivacyPatient(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PrivacyPatient() : base() { }

    }
}
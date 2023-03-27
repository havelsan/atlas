
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MARPerson")] 

    /// <summary>
    /// DE_Kişi
    /// </summary>
    public  partial class MARPerson : TTObject
    {
        public class MARPersonList : TTObjectCollection<MARPerson> { }
                    
        public class ChildMARPersonCollection : TTObject.TTChildObjectCollection<MARPerson>
        {
            public ChildMARPersonCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMARPersonCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
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
    /// Cep Telefonu
    /// </summary>
        public string CellPhone
        {
            get { return (string)this["CELLPHONE"]; }
            set { this["CELLPHONE"] = value; }
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
    /// Ev Telefonu
    /// </summary>
        public string HomePhone
        {
            get { return (string)this["HOMEPHONE"]; }
            set { this["HOMEPHONE"] = value; }
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
    /// Doğum Tarihi
    /// </summary>
        public DateTime? DateOfBirth
        {
            get { return (DateTime?)this["DATEOFBIRTH"]; }
            set { this["DATEOFBIRTH"] = value; }
        }

    /// <summary>
    /// TC Kimlik No
    /// </summary>
        public string NationalID
        {
            get { return (string)this["NATIONALID"]; }
            set { this["NATIONALID"] = value; }
        }

    /// <summary>
    /// Doğduğu İlçe
    /// </summary>
        public TownDefinitions TownOfBirth
        {
            get { return (TownDefinitions)((ITTObject)this).GetParent("TOWNOFBIRTH"); }
            set { this["TOWNOFBIRTH"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Doğduğu Şehir
    /// </summary>
        public City CityOfBirth
        {
            get { return (City)((ITTObject)this).GetParent("CITYOFBIRTH"); }
            set { this["CITYOFBIRTH"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MARPerson(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MARPerson(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MARPerson(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MARPerson(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MARPerson(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MARPERSON", dataRow) { }
        protected MARPerson(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MARPERSON", dataRow, isImported) { }
        public MARPerson(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MARPerson(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MARPerson() : base() { }

    }
}
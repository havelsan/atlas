
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MNZPerson")] 

    /// <summary>
    /// DE_Kişi
    /// </summary>
    public  partial class MNZPerson : MNZActor
    {
        public class MNZPersonList : TTObjectCollection<MNZPerson> { }
                    
        public class ChildMNZPersonCollection : TTObject.TTChildObjectCollection<MNZPerson>
        {
            public ChildMNZPersonCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMNZPersonCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static BindingList<MNZPerson> GelAllPerson(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MNZPERSON"].QueryDefs["GelAllPerson"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<MNZPerson>(queryDef, paramList);
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
    /// Kişi Adı
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
    /// Tc Kimlik No
    /// </summary>
        public string NationalIdentity
        {
            get { return (string)this["NATIONALIDENTITY"]; }
            set { this["NATIONALIDENTITY"] = value; }
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
    /// Kişi Soyadı
    /// </summary>
        public string Surname
        {
            get { return (string)this["SURNAME"]; }
            set { this["SURNAME"] = value; }
        }

    /// <summary>
    /// Doğum Günü
    /// </summary>
        public DateTime? BirthDate
        {
            get { return (DateTime?)this["BIRTHDATE"]; }
            set { this["BIRTHDATE"] = value; }
        }

    /// <summary>
    /// Ev Telefonu
    /// </summary>
        public string HomePhone
        {
            get { return (string)this["HOMEPHONE"]; }
            set { this["HOMEPHONE"] = value; }
        }

        protected MNZPerson(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MNZPerson(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MNZPerson(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MNZPerson(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MNZPerson(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MNZPERSON", dataRow) { }
        protected MNZPerson(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MNZPERSON", dataRow, isImported) { }
        public MNZPerson(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MNZPerson(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MNZPerson() : base() { }

    }
}
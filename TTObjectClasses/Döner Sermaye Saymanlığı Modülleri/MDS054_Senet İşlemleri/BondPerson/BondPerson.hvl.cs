
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BondPerson")] 

    public  partial class BondPerson : Person
    {
        public class BondPersonList : TTObjectCollection<BondPerson> { }
                    
        public class ChildBondPersonCollection : TTObject.TTChildObjectCollection<BondPerson>
        {
            public ChildBondPersonCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBondPersonCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Adres
    /// </summary>
        public string Address
        {
            get { return (string)this["ADDRESS"]; }
            set { this["ADDRESS"] = value; }
        }

    /// <summary>
    /// Telefon
    /// </summary>
        public string Phone
        {
            get { return (string)this["PHONE"]; }
            set { this["PHONE"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

        public SKRSILKodlari HomeCity
        {
            get { return (SKRSILKodlari)((ITTObject)this).GetParent("HOMECITY"); }
            set { this["HOMECITY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSIlceKodlari HomeTown
        {
            get { return (SKRSIlceKodlari)((ITTObject)this).GetParent("HOMETOWN"); }
            set { this["HOMETOWN"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateBondCollection()
        {
            _Bond = new Bond.ChildBondCollection(this, new Guid("57187ff5-9e6b-4933-92a8-fe7950665937"));
            ((ITTChildObjectCollection)_Bond).GetChildren();
        }

        protected Bond.ChildBondCollection _Bond = null;
    /// <summary>
    /// Child collection for Birinci kefil
    /// </summary>
        public Bond.ChildBondCollection Bond
        {
            get
            {
                if (_Bond == null)
                    CreateBondCollection();
                return _Bond;
            }
        }

        virtual protected void CreateBondsCollection()
        {
            _Bonds = new Bond.ChildBondCollection(this, new Guid("6ec0b910-163a-46de-8cf0-ee8b6a2ef926"));
            ((ITTChildObjectCollection)_Bonds).GetChildren();
        }

        protected Bond.ChildBondCollection _Bonds = null;
        public Bond.ChildBondCollection Bonds
        {
            get
            {
                if (_Bonds == null)
                    CreateBondsCollection();
                return _Bonds;
            }
        }

        protected BondPerson(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BondPerson(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BondPerson(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BondPerson(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BondPerson(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BONDPERSON", dataRow) { }
        protected BondPerson(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BONDPERSON", dataRow, isImported) { }
        public BondPerson(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BondPerson(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BondPerson() : base() { }

    }
}
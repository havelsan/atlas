
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PA_RetiredCivilian")] 

    /// <summary>
    /// Sivil Emekli Kabul 
    /// </summary>
    public  partial class PA_RetiredCivilian : PatientAdmission
    {
        public class PA_RetiredCivilianList : TTObjectCollection<PA_RetiredCivilian> { }
                    
        public class ChildPA_RetiredCivilianCollection : TTObject.TTChildObjectCollection<PA_RetiredCivilian>
        {
            public ChildPA_RetiredCivilianCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPA_RetiredCivilianCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
    /// <summary>
    /// Açık
    /// </summary>
            public static Guid Open { get { return new Guid("2a43b5c5-e070-4e5f-a792-63e6cdf9e97c"); } }
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancelled { get { return new Guid("fe3624fd-600f-44e6-a59b-87ff7a9d2532"); } }
        }

    /// <summary>
    /// XXXXXX Yakını
    /// </summary>
        public bool? IsRelativeOfSoldier
        {
            get { return (bool?)this["ISRELATIVEOFSOLDIER"]; }
            set { this["ISRELATIVEOFSOLDIER"] = value; }
        }

    /// <summary>
    /// Sağlık Fişi No
    /// </summary>
        public string HealtSlipNumber
        {
            get { return (string)this["HEALTSLIPNUMBER"]; }
            set { this["HEALTSLIPNUMBER"] = value; }
        }

    /// <summary>
    /// Emekli Sandığı Sicil No
    /// </summary>
        public string RetirementFundID
        {
            get { return (string)this["RETIREMENTFUNDID"]; }
            set { this["RETIREMENTFUNDID"] = value; }
        }

        public bool? IsSGKPatient
        {
            get { return (bool?)this["ISSGKPATIENT"]; }
            set { this["ISSGKPATIENT"] = value; }
        }

    /// <summary>
    /// Aile Reisinin Adı
    /// </summary>
        public string HeadOfFamilyName
        {
            get { return (string)this["HEADOFFAMILYNAME"]; }
            set { this["HEADOFFAMILYNAME"] = value; }
        }

    /// <summary>
    /// Yakınlık Derecesi
    /// </summary>
        public RelationshipDefinition Relationship
        {
            get { return (RelationshipDefinition)((ITTObject)this).GetParent("RELATIONSHIP"); }
            set { this["RELATIONSHIP"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Kurum İli
    /// </summary>
        public City PayerCity
        {
            get { return (City)((ITTObject)this).GetParent("PAYERCITY"); }
            set { this["PAYERCITY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected PA_RetiredCivilian(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PA_RetiredCivilian(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PA_RetiredCivilian(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PA_RetiredCivilian(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PA_RetiredCivilian(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PA_RETIREDCIVILIAN", dataRow) { }
        protected PA_RetiredCivilian(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PA_RETIREDCIVILIAN", dataRow, isImported) { }
        public PA_RetiredCivilian(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PA_RetiredCivilian(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PA_RetiredCivilian() : base() { }

    }
}
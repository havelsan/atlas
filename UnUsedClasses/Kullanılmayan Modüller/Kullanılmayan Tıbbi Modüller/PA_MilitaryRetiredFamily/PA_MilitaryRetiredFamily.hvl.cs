
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PA_MilitaryRetiredFamily")] 

    /// <summary>
    /// Emekli XXXXXX Aliesi
    /// </summary>
    public  abstract  partial class PA_MilitaryRetiredFamily : PatientAdmission
    {
        public class PA_MilitaryRetiredFamilyList : TTObjectCollection<PA_MilitaryRetiredFamily> { }
                    
        public class ChildPA_MilitaryRetiredFamilyCollection : TTObject.TTChildObjectCollection<PA_MilitaryRetiredFamily>
        {
            public ChildPA_MilitaryRetiredFamilyCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPA_MilitaryRetiredFamilyCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
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
    /// Emekli Sandığı Sicil No
    /// </summary>
        public string HOFRetirementFundID
        {
            get { return (string)this["HOFRETIREMENTFUNDID"]; }
            set { this["HOFRETIREMENTFUNDID"] = value; }
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
    /// Sicil No
    /// </summary>
        public string HOFEmploymentRecordID
        {
            get { return (string)this["HOFEMPLOYMENTRECORDID"]; }
            set { this["HOFEMPLOYMENTRECORDID"] = value; }
        }

    /// <summary>
    /// Aile Reisinin TC Kimlik Numarası
    /// </summary>
        public string HeadOfFamilyUniqueRefNo
        {
            get { return (string)this["HEADOFFAMILYUNIQUEREFNO"]; }
            set { this["HEADOFFAMILYUNIQUEREFNO"] = value; }
        }

    /// <summary>
    /// Kuvvet
    /// </summary>
        public ForcesCommand HOFForcesCommand
        {
            get { return (ForcesCommand)((ITTObject)this).GetParent("HOFFORCESCOMMAND"); }
            set { this["HOFFORCESCOMMAND"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Sınıf
    /// </summary>
        public MilitaryClassDefinitions HOFMilitaryClass
        {
            get { return (MilitaryClassDefinitions)((ITTObject)this).GetParent("HOFMILITARYCLASS"); }
            set { this["HOFMILITARYCLASS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Rütbe
    /// </summary>
        public RankDefinitions HOFRank
        {
            get { return (RankDefinitions)((ITTObject)this).GetParent("HOFRANK"); }
            set { this["HOFRANK"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Kurum ili
    /// </summary>
        public City PayerCity
        {
            get { return (City)((ITTObject)this).GetParent("PAYERCITY"); }
            set { this["PAYERCITY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Yakınlık Derecesi
    /// </summary>
        public RelationshipDefinition Relationship
        {
            get { return (RelationshipDefinition)((ITTObject)this).GetParent("RELATIONSHIP"); }
            set { this["RELATIONSHIP"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected PA_MilitaryRetiredFamily(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PA_MilitaryRetiredFamily(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PA_MilitaryRetiredFamily(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PA_MilitaryRetiredFamily(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PA_MilitaryRetiredFamily(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PA_MILITARYRETIREDFAMILY", dataRow) { }
        protected PA_MilitaryRetiredFamily(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PA_MILITARYRETIREDFAMILY", dataRow, isImported) { }
        public PA_MilitaryRetiredFamily(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PA_MilitaryRetiredFamily(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PA_MilitaryRetiredFamily() : base() { }

    }
}
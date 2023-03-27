
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PA_VisitorMilitaryFamiliy")] 

    /// <summary>
    /// Misafir XXXXXX Personel Ailesi
    /// </summary>
    public  abstract  partial class PA_VisitorMilitaryFamiliy : PatientAdmission
    {
        public class PA_VisitorMilitaryFamiliyList : TTObjectCollection<PA_VisitorMilitaryFamiliy> { }
                    
        public class ChildPA_VisitorMilitaryFamiliyCollection : TTObject.TTChildObjectCollection<PA_VisitorMilitaryFamiliy>
        {
            public ChildPA_VisitorMilitaryFamiliyCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPA_VisitorMilitaryFamiliyCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
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
    /// Aile Reisinin Adı
    /// </summary>
        public string HeadOfFamilyName
        {
            get { return (string)this["HEADOFFAMILYNAME"]; }
            set { this["HEADOFFAMILYNAME"] = value; }
        }

    /// <summary>
    /// Geliş Amacı
    /// </summary>
        public VisitingReasonEnum? HeadOfFamilyVisitingReason
        {
            get { return (VisitingReasonEnum?)(int?)this["HEADOFFAMILYVISITINGREASON"]; }
            set { this["HEADOFFAMILYVISITINGREASON"] = value; }
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
    /// Aile Reisinin Geçici Sağlık No
    /// </summary>
        public string HeadOfFTemporaryHealtNo
        {
            get { return (string)this["HEADOFFTEMPORARYHEALTNO"]; }
            set { this["HEADOFFTEMPORARYHEALTNO"] = value; }
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
    /// Ülke
    /// </summary>
        public Country HeadOfFamilyCountry
        {
            get { return (Country)((ITTObject)this).GetParent("HEADOFFAMILYCOUNTRY"); }
            set { this["HEADOFFAMILYCOUNTRY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Birlik
    /// </summary>
        public MilitaryUnit HOFMilitaryUnit
        {
            get { return (MilitaryUnit)((ITTObject)this).GetParent("HOFMILITARYUNIT"); }
            set { this["HOFMILITARYUNIT"] = (value==null ? null : (Guid?)value.ObjectID); }
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
    /// Muayeneye Gönderen Makam
    /// </summary>
        public MilitaryUnit SenderChair
        {
            get { return (MilitaryUnit)((ITTObject)this).GetParent("SENDERCHAIR"); }
            set { this["SENDERCHAIR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected PA_VisitorMilitaryFamiliy(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PA_VisitorMilitaryFamiliy(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PA_VisitorMilitaryFamiliy(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PA_VisitorMilitaryFamiliy(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PA_VisitorMilitaryFamiliy(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PA_VISITORMILITARYFAMILIY", dataRow) { }
        protected PA_VisitorMilitaryFamiliy(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PA_VISITORMILITARYFAMILIY", dataRow, isImported) { }
        public PA_VisitorMilitaryFamiliy(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PA_VisitorMilitaryFamiliy(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PA_VisitorMilitaryFamiliy() : base() { }

    }
}
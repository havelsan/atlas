
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ChildBrainDevelopmentRiskFactors")] 

    /// <summary>
    /// Bebeğin / Çocuğun Beyin Gelişimini Etkileyebilecek Riskler
    /// </summary>
    public  partial class ChildBrainDevelopmentRiskFactors : TTObject
    {
        public class ChildBrainDevelopmentRiskFactorsList : TTObjectCollection<ChildBrainDevelopmentRiskFactors> { }
                    
        public class ChildChildBrainDevelopmentRiskFactorsCollection : TTObject.TTChildObjectCollection<ChildBrainDevelopmentRiskFactors>
        {
            public ChildChildBrainDevelopmentRiskFactorsCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildChildBrainDevelopmentRiskFactorsCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Ailede alkol kullanımı
    /// </summary>
        public bool? AlcoholUseInFamily
        {
            get { return (bool?)this["ALCOHOLUSEINFAMILY"]; }
            set { this["ALCOHOLUSEINFAMILY"] = value; }
        }

    /// <summary>
    /// Ailede Down Sendromu
    /// </summary>
        public bool? DownSyndromeInFamily
        {
            get { return (bool?)this["DOWNSYNDROMEINFAMILY"]; }
            set { this["DOWNSYNDROMEINFAMILY"] = value; }
        }

    /// <summary>
    /// Ailede sigara kullanımı
    /// </summary>
        public bool? SmokingInFamily
        {
            get { return (bool?)this["SMOKINGINFAMILY"]; }
            set { this["SMOKINGINFAMILY"] = value; }
        }

    /// <summary>
    /// Ailenin düzenli gelirinin bulunmaması
    /// </summary>
        public bool? IrregularHouseholdIncome
        {
            get { return (bool?)this["IRREGULARHOUSEHOLDINCOME"]; }
            set { this["IRREGULARHOUSEHOLDINCOME"] = value; }
        }

    /// <summary>
    /// Ailenin sağlık güvencesinin bulunmaması
    /// </summary>
        public bool? NoHealthInsurance
        {
            get { return (bool?)this["NOHEALTHINSURANCE"]; }
            set { this["NOHEALTHINSURANCE"] = value; }
        }

    /// <summary>
    /// Ailenin temel ihtiyaçlarını karşılayamaması
    /// </summary>
        public bool? Poverty
        {
            get { return (bool?)this["POVERTY"]; }
            set { this["POVERTY"] = value; }
        }

    /// <summary>
    /// Anemi (Beslenme yetersizliği bulgusu olarak)
    /// </summary>
        public bool? Anemia
        {
            get { return (bool?)this["ANEMIA"]; }
            set { this["ANEMIA"] = value; }
        }

    /// <summary>
    /// Annede psikolojik bozukluk (şizofreni vb.) şüphesi
    /// </summary>
        public bool? MotherMentalDisorder
        {
            get { return (bool?)this["MOTHERMENTALDISORDER"]; }
            set { this["MOTHERMENTALDISORDER"] = value; }
        }

    /// <summary>
    /// Annede zeka geriliği şüphesi
    /// </summary>
        public bool? MotherMentalDeficiency
        {
            get { return (bool?)this["MOTHERMENTALDEFICIENCY"]; }
            set { this["MOTHERMENTALDEFICIENCY"] = value; }
        }

    /// <summary>
    /// Annede anksiyete bozukluğu şüphesi
    /// </summary>
        public bool? MotherAnxietyDisorder
        {
            get { return (bool?)this["MOTHERANXIETYDISORDER"]; }
            set { this["MOTHERANXIETYDISORDER"] = value; }
        }

    /// <summary>
    /// Annede depresyon şüphesi
    /// </summary>
        public bool? MotherDepression
        {
            get { return (bool?)this["MOTHERDEPRESSION"]; }
            set { this["MOTHERDEPRESSION"] = value; }
        }

    /// <summary>
    /// Annenin alkol kullanımı
    /// </summary>
        public bool? MotherAlcoholUse
        {
            get { return (bool?)this["MOTHERALCOHOLUSE"]; }
            set { this["MOTHERALCOHOLUSE"] = value; }
        }

    /// <summary>
    /// Annede madde bağımlılığı
    /// </summary>
        public bool? MotherDrugAddiction
        {
            get { return (bool?)this["MOTHERDRUGADDICTION"]; }
            set { this["MOTHERDRUGADDICTION"] = value; }
        }

    /// <summary>
    /// Babanın alkol kullanımı
    /// </summary>
        public bool? FatherAlcoholUse
        {
            get { return (bool?)this["FATHERALCOHOLUSE"]; }
            set { this["FATHERALCOHOLUSE"] = value; }
        }

    /// <summary>
    /// Babada anksiyete bozukluğu şüphesi
    /// </summary>
        public bool? FatherAnxietyDisorder
        {
            get { return (bool?)this["FATHERANXIETYDISORDER"]; }
            set { this["FATHERANXIETYDISORDER"] = value; }
        }

    /// <summary>
    /// Babada depresyon şüphesi
    /// </summary>
        public bool? FatherDepression
        {
            get { return (bool?)this["FATHERDEPRESSION"]; }
            set { this["FATHERDEPRESSION"] = value; }
        }

    /// <summary>
    /// Babada madde bağımlılığı
    /// </summary>
        public bool? FatherDrugAddiction
        {
            get { return (bool?)this["FATHERDRUGADDICTION"]; }
            set { this["FATHERDRUGADDICTION"] = value; }
        }

    /// <summary>
    /// Babada zeka geriliği şüphesi
    /// </summary>
        public bool? FatherMentalDeficiency
        {
            get { return (bool?)this["FATHERMENTALDEFICIENCY"]; }
            set { this["FATHERMENTALDEFICIENCY"] = value; }
        }

    /// <summary>
    /// Babada psikolojik bozukluk (şizofreni vb.) şüphesi
    /// </summary>
        public bool? FatherMentalDisorder
        {
            get { return (bool?)this["FATHERMENTALDISORDER"]; }
            set { this["FATHERMENTALDISORDER"] = value; }
        }

    /// <summary>
    /// Çocuğun uygun kilo alamaması
    /// </summary>
        public bool? PoorWeightGain
        {
            get { return (bool?)this["POORWEIGHTGAIN"]; }
            set { this["POORWEIGHTGAIN"] = value; }
        }

    /// <summary>
    /// Çocuğun vücudunda fiziksel istismar ya da ihmal belirtisi
    /// </summary>
        public bool? ChildAbuseSuspicion
        {
            get { return (bool?)this["CHILDABUSESUSPICION"]; }
            set { this["CHILDABUSESUSPICION"] = value; }
        }

    /// <summary>
    /// Diğer beslenme yetersizliği bulguları
    /// </summary>
        public bool? OtherPoorFeedingSigns
        {
            get { return (bool?)this["OTHERPOORFEEDINGSIGNS"]; }
            set { this["OTHERPOORFEEDINGSIGNS"] = value; }
        }

    /// <summary>
    /// Gebe / Annenin sigara kullanımı
    /// </summary>
        public bool? MaternalSmoking
        {
            get { return (bool?)this["MATERNALSMOKING"]; }
            set { this["MATERNALSMOKING"] = value; }
        }

    /// <summary>
    /// Gebelikte, annede fiziksel istismar bulgusu
    /// </summary>
        public bool? MotherAbuseSuspicion
        {
            get { return (bool?)this["MOTHERABUSESUSPICION"]; }
            set { this["MOTHERABUSESUSPICION"] = value; }
        }

    /// <summary>
    /// Gebelikte, annenin uygun kilo alamaması
    /// </summary>
        public bool? PoorMaternalWeightGain
        {
            get { return (bool?)this["POORMATERNALWEIGHTGAIN"]; }
            set { this["POORMATERNALWEIGHTGAIN"] = value; }
        }

    /// <summary>
    /// İstenmeyen gebelik / çocuk
    /// </summary>
        public bool? UndesiredPregnancy
        {
            get { return (bool?)this["UNDESIREDPREGNANCY"]; }
            set { this["UNDESIREDPREGNANCY"] = value; }
        }

        public ChildGrowthVisits ChildGrowthVisits
        {
            get { return (ChildGrowthVisits)((ITTObject)this).GetParent("CHILDGROWTHVISITS"); }
            set { this["CHILDGROWTHVISITS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSBebeginCocugunBeyinGelisiminiEtkileyebilecekRiskler SKRSBebeginBeyinGlsEtkRiskler
        {
            get { return (SKRSBebeginCocugunBeyinGelisiminiEtkileyebilecekRiskler)((ITTObject)this).GetParent("SKRSBEBEGINBEYINGLSETKRISKLER"); }
            set { this["SKRSBEBEGINBEYINGLSETKRISKLER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ChildBrainDevelopmentRiskFactors(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ChildBrainDevelopmentRiskFactors(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ChildBrainDevelopmentRiskFactors(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ChildBrainDevelopmentRiskFactors(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ChildBrainDevelopmentRiskFactors(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "CHILDBRAINDEVELOPMENTRISKFACTORS", dataRow) { }
        protected ChildBrainDevelopmentRiskFactors(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "CHILDBRAINDEVELOPMENTRISKFACTORS", dataRow, isImported) { }
        public ChildBrainDevelopmentRiskFactors(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ChildBrainDevelopmentRiskFactors(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ChildBrainDevelopmentRiskFactors() : base() { }

    }
}

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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="InfantRiskFactors")] 

    /// <summary>
    /// Bebekte Risk Faktörleri
    /// </summary>
    public  partial class InfantRiskFactors : TTObject
    {
        public class InfantRiskFactorsList : TTObjectCollection<InfantRiskFactors> { }
                    
        public class ChildInfantRiskFactorsCollection : TTObject.TTChildObjectCollection<InfantRiskFactors>
        {
            public ChildInfantRiskFactorsCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildInfantRiskFactorsCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Ailede Kalıtsal İşitme Kaybı Öyküsü
    /// </summary>
        public bool? HereditaryHearingLoss
        {
            get { return (bool?)this["HEREDITARYHEARINGLOSS"]; }
            set { this["HEREDITARYHEARINGLOSS"] = value; }
        }

    /// <summary>
    /// Ailede ve 1. derece akrabalarda GKD öyküsü
    /// </summary>
        public bool? GKD
        {
            get { return (bool?)this["GKD"]; }
            set { this["GKD"] = value; }
        }

    /// <summary>
    /// Akraba evliliği
    /// </summary>
        public bool? ConsanguineousMarriage
        {
            get { return (bool?)this["CONSANGUINEOUSMARRIAGE"]; }
            set { this["CONSANGUINEOUSMARRIAGE"] = value; }
        }

    /// <summary>
    /// Amniyon sıvı anormallikleri
    /// </summary>
        public bool? AmnioticFluidAbnormalities
        {
            get { return (bool?)this["AMNIOTICFLUIDABNORMALITIES"]; }
            set { this["AMNIOTICFLUIDABNORMALITIES"] = value; }
        }

    /// <summary>
    /// Anne hemoglobinopati taşıyıcısı
    /// </summary>
        public bool? MotherHemoglobinopathyCarrier
        {
            get { return (bool?)this["MOTHERHEMOGLOBINOPATHYCARRIER"]; }
            set { this["MOTHERHEMOGLOBINOPATHYCARRIER"] = value; }
        }

    /// <summary>
    /// Annede genetik geçiş gösteren hastalık varlığı
    /// </summary>
        public bool? MotherHasHereditaryIllness
        {
            get { return (bool?)this["MOTHERHASHEREDITARYILLNESS"]; }
            set { this["MOTHERHASHEREDITARYILLNESS"] = value; }
        }

    /// <summary>
    /// Annenin maruz kaldığı X-ray
    /// </summary>
        public bool? MotherXRayExposure
        {
            get { return (bool?)this["MOTHERXRAYEXPOSURE"]; }
            set { this["MOTHERXRAYEXPOSURE"] = value; }
        }

    /// <summary>
    /// Ayak deformiteleri
    /// </summary>
        public bool? FeetDeformities
        {
            get { return (bool?)this["FEETDEFORMITIES"]; }
            set { this["FEETDEFORMITIES"] = value; }
        }

    /// <summary>
    /// Babada genetik geçiş gösteren hastalık varlığı
    /// </summary>
        public bool? FatherHasHereditaryIllness
        {
            get { return (bool?)this["FATHERHASHEREDITARYILLNESS"]; }
            set { this["FATHERHASHEREDITARYILLNESS"] = value; }
        }

    /// <summary>
    /// Baba hemoglobinopati taşıyıcısı
    /// </summary>
        public bool? FatherHemoglobinopathyCarrier
        {
            get { return (bool?)this["FATHERHEMOGLOBINOPATHYCARRIER"]; }
            set { this["FATHERHEMOGLOBINOPATHYCARRIER"] = value; }
        }

        public ChildGrowthVisits ChildGrowthVisits
        {
            get { return (ChildGrowthVisits)((ITTObject)this).GetParent("CHILDGROWTHVISITS"); }
            set { this["CHILDGROWTHVISITS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSBebekteRiskFaktorleri SKRSBebekteRiskFaktorleri
        {
            get { return (SKRSBebekteRiskFaktorleri)((ITTObject)this).GetParent("SKRSBEBEKTERISKFAKTORLERI"); }
            set { this["SKRSBEBEKTERISKFAKTORLERI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected InfantRiskFactors(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected InfantRiskFactors(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected InfantRiskFactors(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected InfantRiskFactors(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected InfantRiskFactors(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "INFANTRISKFACTORS", dataRow) { }
        protected InfantRiskFactors(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "INFANTRISKFACTORS", dataRow, isImported) { }
        public InfantRiskFactors(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public InfantRiskFactors(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public InfantRiskFactors() : base() { }

    }
}
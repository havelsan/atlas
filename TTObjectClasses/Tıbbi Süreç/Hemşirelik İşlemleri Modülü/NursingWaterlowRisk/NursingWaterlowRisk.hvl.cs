
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="NursingWaterlowRisk")] 

    public  partial class NursingWaterlowRisk : TTObject
    {
        public class NursingWaterlowRiskList : TTObjectCollection<NursingWaterlowRisk> { }
                    
        public class ChildNursingWaterlowRiskCollection : TTObject.TTChildObjectCollection<NursingWaterlowRisk>
        {
            public ChildNursingWaterlowRiskCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildNursingWaterlowRiskCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Risk  Puanı
    /// </summary>
        public WaterlowScoreEnum? RiskScore
        {
            get { return (WaterlowScoreEnum?)(int?)this["RISKSCORE"]; }
            set { this["RISKSCORE"] = value; }
        }

    /// <summary>
    /// Tarih
    /// </summary>
        public DateTime? ActionDate
        {
            get { return (DateTime?)this["ACTIONDATE"]; }
            set { this["ACTIONDATE"] = value; }
        }

    /// <summary>
    /// Nörülüjik Bozukluk
    /// </summary>
        public WaterlowRiskDefinition NeurologicalProblem
        {
            get { return (WaterlowRiskDefinition)((ITTObject)this).GetParent("NEUROLOGICALPROBLEM"); }
            set { this["NEUROLOGICALPROBLEM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// İştah
    /// </summary>
        public WaterlowRiskDefinition Appetite
        {
            get { return (WaterlowRiskDefinition)((ITTObject)this).GetParent("APPETITE"); }
            set { this["APPETITE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Yaş
    /// </summary>
        public WaterlowRiskDefinition Age
        {
            get { return (WaterlowRiskDefinition)((ITTObject)this).GetParent("AGE"); }
            set { this["AGE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Mobilite
    /// </summary>
        public WaterlowRiskDefinition Mobilite
        {
            get { return (WaterlowRiskDefinition)((ITTObject)this).GetParent("MOBILITE"); }
            set { this["MOBILITE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Doku malnütrüsyonu
    /// </summary>
        public WaterlowRiskDefinition TextureMalnutrusyon
        {
            get { return (WaterlowRiskDefinition)((ITTObject)this).GetParent("TEXTUREMALNUTRUSYON"); }
            set { this["TEXTUREMALNUTRUSYON"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Büyük Ameliyat/Travma
    /// </summary>
        public WaterlowRiskDefinition SurgerAndTrauma
        {
            get { return (WaterlowRiskDefinition)((ITTObject)this).GetParent("SURGERANDTRAUMA"); }
            set { this["SURGERANDTRAUMA"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Kontinans
    /// </summary>
        public WaterlowRiskDefinition Kontinans
        {
            get { return (WaterlowRiskDefinition)((ITTObject)this).GetParent("KONTINANS"); }
            set { this["KONTINANS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Boyuna Oranla Vücut Yapısı
    /// </summary>
        public WaterlowRiskDefinition HeightSizeRate
        {
            get { return (WaterlowRiskDefinition)((ITTObject)this).GetParent("HEIGHTSIZERATE"); }
            set { this["HEIGHTSIZERATE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Cinsiyet
    /// </summary>
        public WaterlowRiskDefinition Sex
        {
            get { return (WaterlowRiskDefinition)((ITTObject)this).GetParent("SEX"); }
            set { this["SEX"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Waterlow Bası Riski
    /// </summary>
        public NursingApplication NursingApplication
        {
            get { return (NursingApplication)((ITTObject)this).GetParent("NURSINGAPPLICATION"); }
            set { this["NURSINGAPPLICATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// İlaçlar
    /// </summary>
        public WaterlowRiskDefinition Drugs
        {
            get { return (WaterlowRiskDefinition)((ITTObject)this).GetParent("DRUGS"); }
            set { this["DRUGS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// CiltTipi
    /// </summary>
        public WaterlowRiskDefinition SkinType
        {
            get { return (WaterlowRiskDefinition)((ITTObject)this).GetParent("SKINTYPE"); }
            set { this["SKINTYPE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected NursingWaterlowRisk(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected NursingWaterlowRisk(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected NursingWaterlowRisk(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected NursingWaterlowRisk(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected NursingWaterlowRisk(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "NURSINGWATERLOWRISK", dataRow) { }
        protected NursingWaterlowRisk(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "NURSINGWATERLOWRISK", dataRow, isImported) { }
        public NursingWaterlowRisk(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public NursingWaterlowRisk(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public NursingWaterlowRisk() : base() { }

    }
}
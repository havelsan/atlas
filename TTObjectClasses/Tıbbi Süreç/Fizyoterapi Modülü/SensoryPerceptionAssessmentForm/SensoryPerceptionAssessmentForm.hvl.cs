
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SensoryPerceptionAssessmentForm")] 

    /// <summary>
    /// Duyu-Algı-Motor Değerlendirmesi
    /// </summary>
    public  partial class SensoryPerceptionAssessmentForm : BaseAdditionalInfo
    {
        public class SensoryPerceptionAssessmentFormList : TTObjectCollection<SensoryPerceptionAssessmentForm> { }
                    
        public class ChildSensoryPerceptionAssessmentFormCollection : TTObject.TTChildObjectCollection<SensoryPerceptionAssessmentForm>
        {
            public ChildSensoryPerceptionAssessmentFormCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSensoryPerceptionAssessmentFormCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// ASIA Bozukluk Skalası
    /// </summary>
        public string ASIAImpairmentScale
        {
            get { return (string)this["ASIAIMPAIRMENTSCALE"]; }
            set { this["ASIAIMPAIRMENTSCALE"] = value; }
        }

    /// <summary>
    /// Kurtzke Expanded Disability Status Scale
    /// </summary>
        public string KurtzkeScale
        {
            get { return (string)this["KURTZKESCALE"]; }
            set { this["KURTZKESCALE"] = value; }
        }

    /// <summary>
    /// Fugl Meyer Testi
    /// </summary>
        public string FuglMeyerTest
        {
            get { return (string)this["FUGLMEYERTEST"]; }
            set { this["FUGLMEYERTEST"] = value; }
        }

    /// <summary>
    /// Rivemead Mibilite İndeksi
    /// </summary>
        public string RivemeadIndex
        {
            get { return (string)this["RIVEMEADINDEX"]; }
            set { this["RIVEMEADINDEX"] = value; }
        }

    /// <summary>
    /// Mini Mental Test
    /// </summary>
        public string MiniMentalStateExamination
        {
            get { return (string)this["MINIMENTALSTATEEXAMINATION"]; }
            set { this["MINIMENTALSTATEEXAMINATION"] = value; }
        }

    /// <summary>
    /// Yıldız Testi
    /// </summary>
        public string StarCancellationTest
        {
            get { return (string)this["STARCANCELLATIONTEST"]; }
            set { this["STARCANCELLATIONTEST"] = value; }
        }

        protected SensoryPerceptionAssessmentForm(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SensoryPerceptionAssessmentForm(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SensoryPerceptionAssessmentForm(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SensoryPerceptionAssessmentForm(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SensoryPerceptionAssessmentForm(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SENSORYPERCEPTIONASSESSMENTFORM", dataRow) { }
        protected SensoryPerceptionAssessmentForm(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SENSORYPERCEPTIONASSESSMENTFORM", dataRow, isImported) { }
        public SensoryPerceptionAssessmentForm(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SensoryPerceptionAssessmentForm(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SensoryPerceptionAssessmentForm() : base() { }

    }
}
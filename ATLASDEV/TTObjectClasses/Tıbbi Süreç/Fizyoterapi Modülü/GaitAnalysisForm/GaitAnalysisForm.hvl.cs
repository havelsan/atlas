
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="GaitAnalysisForm")] 

    /// <summary>
    /// Yürüme Analizi 
    /// </summary>
    public  partial class GaitAnalysisForm : BaseAdditionalInfo
    {
        public class GaitAnalysisFormList : TTObjectCollection<GaitAnalysisForm> { }
                    
        public class ChildGaitAnalysisFormCollection : TTObject.TTChildObjectCollection<GaitAnalysisForm>
        {
            public ChildGaitAnalysisFormCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildGaitAnalysisFormCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// FIM
    /// </summary>
        public string FIM
        {
            get { return (string)this["FIM"]; }
            set { this["FIM"] = value; }
        }

    /// <summary>
    /// Fonksiyonel Ambulasyon Sınıflanması (FAC)
    /// </summary>
        public string FAC
        {
            get { return (string)this["FAC"]; }
            set { this["FAC"] = value; }
        }

    /// <summary>
    /// Rivermead Görsel Yürüme Değerlendirmesi
    /// </summary>
        public string RivermeadAssessment
        {
            get { return (string)this["RIVERMEADASSESSMENT"]; }
            set { this["RIVERMEADASSESSMENT"] = value; }
        }

    /// <summary>
    /// Barthel İndeksi
    /// </summary>
        public string BarthelIndex
        {
            get { return (string)this["BARTHELINDEX"]; }
            set { this["BARTHELINDEX"] = value; }
        }

    /// <summary>
    /// PULSES Profili
    /// </summary>
        public string PULSESProfile
        {
            get { return (string)this["PULSESPROFILE"]; }
            set { this["PULSESPROFILE"] = value; }
        }

    /// <summary>
    /// Gross Motor Function Classiflcation System (GMFCS)
    /// </summary>
        public string GMFCS
        {
            get { return (string)this["GMFCS"]; }
            set { this["GMFCS"] = value; }
        }

        protected GaitAnalysisForm(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected GaitAnalysisForm(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected GaitAnalysisForm(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected GaitAnalysisForm(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected GaitAnalysisForm(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "GAITANALYSISFORM", dataRow) { }
        protected GaitAnalysisForm(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "GAITANALYSISFORM", dataRow, isImported) { }
        public GaitAnalysisForm(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public GaitAnalysisForm(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public GaitAnalysisForm() : base() { }

    }
}
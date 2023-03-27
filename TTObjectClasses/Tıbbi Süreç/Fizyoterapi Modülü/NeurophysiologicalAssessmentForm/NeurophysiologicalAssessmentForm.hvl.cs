
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="NeurophysiologicalAssessmentForm")] 

    /// <summary>
    /// Nörofizyolojik Değerlendirme
    /// </summary>
    public  partial class NeurophysiologicalAssessmentForm : BaseAdditionalInfo
    {
        public class NeurophysiologicalAssessmentFormList : TTObjectCollection<NeurophysiologicalAssessmentForm> { }
                    
        public class ChildNeurophysiologicalAssessmentFormCollection : TTObject.TTChildObjectCollection<NeurophysiologicalAssessmentForm>
        {
            public ChildNeurophysiologicalAssessmentFormCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildNeurophysiologicalAssessmentFormCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Bobath, Brunstrum Evreleme Cetveli
    /// </summary>
        public string BobathBrunstrum
        {
            get { return (string)this["BOBATHBRUNSTRUM"]; }
            set { this["BOBATHBRUNSTRUM"] = value; }
        }

    /// <summary>
    /// Chedoke Mc Master Stroke Assessment Scale
    /// </summary>
        public string ChedokeStrokeAssessmentScale
        {
            get { return (string)this["CHEDOKESTROKEASSESSMENTSCALE"]; }
            set { this["CHEDOKESTROKEASSESSMENTSCALE"] = value; }
        }

    /// <summary>
    /// Rood
    /// </summary>
        public string Rood
        {
            get { return (string)this["ROOD"]; }
            set { this["ROOD"] = value; }
        }

    /// <summary>
    /// Kabat
    /// </summary>
        public string Kabat
        {
            get { return (string)this["KABAT"]; }
            set { this["KABAT"] = value; }
        }

    /// <summary>
    /// Vojta
    /// </summary>
        public string Vojta
        {
            get { return (string)this["VOJTA"]; }
            set { this["VOJTA"] = value; }
        }

        protected NeurophysiologicalAssessmentForm(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected NeurophysiologicalAssessmentForm(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected NeurophysiologicalAssessmentForm(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected NeurophysiologicalAssessmentForm(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected NeurophysiologicalAssessmentForm(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "NEUROPHYSIOLOGICALASSESSMENTFORM", dataRow) { }
        protected NeurophysiologicalAssessmentForm(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "NEUROPHYSIOLOGICALASSESSMENTFORM", dataRow, isImported) { }
        public NeurophysiologicalAssessmentForm(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public NeurophysiologicalAssessmentForm(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public NeurophysiologicalAssessmentForm() : base() { }

    }
}
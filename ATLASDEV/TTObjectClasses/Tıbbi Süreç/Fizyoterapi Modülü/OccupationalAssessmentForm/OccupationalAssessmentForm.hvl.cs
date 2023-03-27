
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="OccupationalAssessmentForm")] 

    /// <summary>
    /// Mesleki Değerlendirme
    /// </summary>
    public  partial class OccupationalAssessmentForm : BaseAdditionalInfo
    {
        public class OccupationalAssessmentFormList : TTObjectCollection<OccupationalAssessmentForm> { }
                    
        public class ChildOccupationalAssessmentFormCollection : TTObject.TTChildObjectCollection<OccupationalAssessmentForm>
        {
            public ChildOccupationalAssessmentFormCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildOccupationalAssessmentFormCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Craig handicap and Reporting technique 
    /// </summary>
        public string CHART
        {
            get { return (string)this["CHART"]; }
            set { this["CHART"] = value; }
        }

    /// <summary>
    /// Functional Capacity Evaluation (FCE)
    /// </summary>
        public string FCE
        {
            get { return (string)this["FCE"]; }
            set { this["FCE"] = value; }
        }

    /// <summary>
    /// QUICK ? DASH (Disease Arm ? Shoulder - Hand)
    /// </summary>
        public string DASH
        {
            get { return (string)this["DASH"]; }
            set { this["DASH"] = value; }
        }

    /// <summary>
    /// Assessment of Pain and Occupational Performance (POP)
    /// </summary>
        public string POP
        {
            get { return (string)this["POP"]; }
            set { this["POP"] = value; }
        }

        protected OccupationalAssessmentForm(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected OccupationalAssessmentForm(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected OccupationalAssessmentForm(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected OccupationalAssessmentForm(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected OccupationalAssessmentForm(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "OCCUPATIONALASSESSMENTFORM", dataRow) { }
        protected OccupationalAssessmentForm(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "OCCUPATIONALASSESSMENTFORM", dataRow, isImported) { }
        public OccupationalAssessmentForm(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public OccupationalAssessmentForm(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public OccupationalAssessmentForm() : base() { }

    }
}
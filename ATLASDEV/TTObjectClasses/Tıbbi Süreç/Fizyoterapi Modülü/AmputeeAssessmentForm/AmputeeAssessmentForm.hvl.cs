
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="AmputeeAssessmentForm")] 

    /// <summary>
    /// Ampute değerlendirmesi
    /// </summary>
    public  partial class AmputeeAssessmentForm : BaseAdditionalInfo
    {
        public class AmputeeAssessmentFormList : TTObjectCollection<AmputeeAssessmentForm> { }
                    
        public class ChildAmputeeAssessmentFormCollection : TTObject.TTChildObjectCollection<AmputeeAssessmentForm>
        {
            public ChildAmputeeAssessmentFormCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildAmputeeAssessmentFormCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Trinity Amputation and Prostheesis Experience Scales
    /// </summary>
        public string TrinityExperienceScale
        {
            get { return (string)this["TRINITYEXPERIENCESCALE"]; }
            set { this["TRINITYEXPERIENCESCALE"] = value; }
        }

    /// <summary>
    /// Prosthetic Ipper Extremity Functional Index
    /// </summary>
        public string ProstheticIpperExtremityIndex
        {
            get { return (string)this["PROSTHETICIPPEREXTREMITYINDEX"]; }
            set { this["PROSTHETICIPPEREXTREMITYINDEX"] = value; }
        }

    /// <summary>
    /// The Sickness Impact Profile
    /// </summary>
        public string TheSicknessImpactProfile
        {
            get { return (string)this["THESICKNESSIMPACTPROFILE"]; }
            set { this["THESICKNESSIMPACTPROFILE"] = value; }
        }

    /// <summary>
    /// Groningen Activity Restriction Scale
    /// </summary>
        public string GroningenScale
        {
            get { return (string)this["GRONINGENSCALE"]; }
            set { this["GRONINGENSCALE"] = value; }
        }

    /// <summary>
    /// Medicare Guidelines For Function Classificarin Scale
    /// </summary>
        public string MGFCScale
        {
            get { return (string)this["MGFCSCALE"]; }
            set { this["MGFCSCALE"] = value; }
        }

        protected AmputeeAssessmentForm(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected AmputeeAssessmentForm(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected AmputeeAssessmentForm(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected AmputeeAssessmentForm(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected AmputeeAssessmentForm(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "AMPUTEEASSESSMENTFORM", dataRow) { }
        protected AmputeeAssessmentForm(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "AMPUTEEASSESSMENTFORM", dataRow, isImported) { }
        public AmputeeAssessmentForm(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public AmputeeAssessmentForm(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public AmputeeAssessmentForm() : base() { }

    }
}
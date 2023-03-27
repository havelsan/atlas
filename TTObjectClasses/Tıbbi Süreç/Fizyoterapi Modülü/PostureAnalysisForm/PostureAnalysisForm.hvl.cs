
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PostureAnalysisForm")] 

    /// <summary>
    /// Postur Analizi
    /// </summary>
    public  partial class PostureAnalysisForm : BaseAdditionalInfo
    {
        public class PostureAnalysisFormList : TTObjectCollection<PostureAnalysisForm> { }
                    
        public class ChildPostureAnalysisFormCollection : TTObject.TTChildObjectCollection<PostureAnalysisForm>
        {
            public ChildPostureAnalysisFormCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPostureAnalysisFormCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Baş
    /// </summary>
        public HeadPostureEnum? HeadPosture
        {
            get { return (HeadPostureEnum?)(int?)this["HEADPOSTURE"]; }
            set { this["HEADPOSTURE"] = value; }
        }

    /// <summary>
    /// Göğüs
    /// </summary>
        public ChestPostureEnum? ChestPosture
        {
            get { return (ChestPostureEnum?)(int?)this["CHESTPOSTURE"]; }
            set { this["CHESTPOSTURE"] = value; }
        }

    /// <summary>
    /// Omuz
    /// </summary>
        public ShoulderPostureEnum? ShoulderPosture
        {
            get { return (ShoulderPostureEnum?)(int?)this["SHOULDERPOSTURE"]; }
            set { this["SHOULDERPOSTURE"] = value; }
        }

    /// <summary>
    /// Skapula
    /// </summary>
        public ScapulaPostureEnum? ScapulaPosture
        {
            get { return (ScapulaPostureEnum?)(int?)this["SCAPULAPOSTURE"]; }
            set { this["SCAPULAPOSTURE"] = value; }
        }

    /// <summary>
    /// Omurga
    /// </summary>
        public SpinePostureEnum? SpinePosture
        {
            get { return (SpinePostureEnum?)(int?)this["SPINEPOSTURE"]; }
            set { this["SPINEPOSTURE"] = value; }
        }

    /// <summary>
    /// Bacaklar
    /// </summary>
        public LegPostureEnum? LegPosture
        {
            get { return (LegPostureEnum?)(int?)this["LEGPOSTURE"]; }
            set { this["LEGPOSTURE"] = value; }
        }

    /// <summary>
    /// Ayaklar
    /// </summary>
        public FeetPostureEnum? FeetPosture
        {
            get { return (FeetPostureEnum?)(int?)this["FEETPOSTURE"]; }
            set { this["FEETPOSTURE"] = value; }
        }

    /// <summary>
    /// Bacak Uzunlukları
    /// </summary>
        public LegsLengthEnum? LegsLength
        {
            get { return (LegsLengthEnum?)(int?)this["LEGSLENGTH"]; }
            set { this["LEGSLENGTH"] = value; }
        }

        protected PostureAnalysisForm(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PostureAnalysisForm(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PostureAnalysisForm(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PostureAnalysisForm(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PostureAnalysisForm(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "POSTUREANALYSISFORM", dataRow) { }
        protected PostureAnalysisForm(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "POSTUREANALYSISFORM", dataRow, isImported) { }
        public PostureAnalysisForm(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PostureAnalysisForm(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PostureAnalysisForm() : base() { }

    }
}
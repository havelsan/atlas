
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MPBSAbroadTraining")] 

    public  partial class MPBSAbroadTraining : MPBSActivity
    {
        public class MPBSAbroadTrainingList : TTObjectCollection<MPBSAbroadTraining> { }
                    
        public class ChildMPBSAbroadTrainingCollection : TTObject.TTChildObjectCollection<MPBSAbroadTraining>
        {
            public ChildMPBSAbroadTrainingCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMPBSAbroadTrainingCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Subay Sayısı
    /// </summary>
        public int? OfficerQuota
        {
            get { return (int?)this["OFFICERQUOTA"]; }
            set { this["OFFICERQUOTA"] = value; }
        }

    /// <summary>
    /// Öncelik Sırası
    /// </summary>
        public int? Priority
        {
            get { return (int?)this["PRIORITY"]; }
            set { this["PRIORITY"] = value; }
        }

    /// <summary>
    /// Hedef
    /// </summary>
        public string Aim
        {
            get { return (string)this["AIM"]; }
            set { this["AIM"] = value; }
        }

    /// <summary>
    /// Süre
    /// </summary>
        public int? Duration
        {
            get { return (int?)this["DURATION"]; }
            set { this["DURATION"] = value; }
        }

    /// <summary>
    /// Eğitim Grekçesi
    /// </summary>
        public string ReasonOfTraining
        {
            get { return (string)this["REASONOFTRAINING"]; }
            set { this["REASONOFTRAINING"] = value; }
        }

        protected MPBSAbroadTraining(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MPBSAbroadTraining(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MPBSAbroadTraining(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MPBSAbroadTraining(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MPBSAbroadTraining(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MPBSABROADTRAINING", dataRow) { }
        protected MPBSAbroadTraining(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MPBSABROADTRAINING", dataRow, isImported) { }
        public MPBSAbroadTraining(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MPBSAbroadTraining(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MPBSAbroadTraining() : base() { }

    }
}

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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ehrMedicalCommittee")] 

    /// <summary>
    /// Tıbbi Kurullar
    /// </summary>
    public  partial class ehrMedicalCommittee : ehrEpisodeAction
    {
        public class ehrMedicalCommitteeList : TTObjectCollection<ehrMedicalCommittee> { }
                    
        public class ChildehrMedicalCommitteeCollection : TTObject.TTChildObjectCollection<ehrMedicalCommittee>
        {
            public ChildehrMedicalCommitteeCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildehrMedicalCommitteeCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
            public static Guid Active { get { return new Guid("d82caca1-a08a-43fa-b009-be70b816c5ec"); } }
            public static Guid UnActive { get { return new Guid("8abe0000-7e19-46e0-a07f-e69109e6aa4c"); } }
        }

    /// <summary>
    /// Konu
    /// </summary>
        public object Subject
        {
            get { return (object)this["SUBJECT"]; }
            set { this["SUBJECT"] = value; }
        }

    /// <summary>
    /// Tıbbi Kurullar
    /// </summary>
        public object TreatmentPlan
        {
            get { return (object)this["TREATMENTPLAN"]; }
            set { this["TREATMENTPLAN"] = value; }
        }

        protected ehrMedicalCommittee(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ehrMedicalCommittee(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ehrMedicalCommittee(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ehrMedicalCommittee(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ehrMedicalCommittee(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EHRMEDICALCOMMITTEE", dataRow) { }
        protected ehrMedicalCommittee(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EHRMEDICALCOMMITTEE", dataRow, isImported) { }
        public ehrMedicalCommittee(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ehrMedicalCommittee(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ehrMedicalCommittee() : base() { }

    }
}

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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PatientAdmissionCancellation")] 

    /// <summary>
    /// Hasta Kabul Iptal
    /// </summary>
    public  partial class PatientAdmissionCancellation : EpisodeAction
    {
        public class PatientAdmissionCancellationList : TTObjectCollection<PatientAdmissionCancellation> { }
                    
        public class ChildPatientAdmissionCancellationCollection : TTObject.TTChildObjectCollection<PatientAdmissionCancellation>
        {
            public ChildPatientAdmissionCancellationCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPatientAdmissionCancellationCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid New { get { return new Guid("9c69c888-8709-4411-af9f-262d6a02428c"); } }
            public static Guid Completed { get { return new Guid("658c5cb8-5c7b-47ce-bc0f-7da79310bbd1"); } }
        }

        protected PatientAdmissionCancellation(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PatientAdmissionCancellation(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PatientAdmissionCancellation(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PatientAdmissionCancellation(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PatientAdmissionCancellation(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PATIENTADMISSIONCANCELLATION", dataRow) { }
        protected PatientAdmissionCancellation(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PATIENTADMISSIONCANCELLATION", dataRow, isImported) { }
        public PatientAdmissionCancellation(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PatientAdmissionCancellation(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PatientAdmissionCancellation() : base() { }

        override protected void RunPreTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePreScript(transDef))
                base.RunPreTransition(transDef.BaseTransDef);
            this.PreTransition(transDef);
        }
        override protected void RunPostTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePostScript(transDef))
                base.RunPostTransition(transDef.BaseTransDef);
            this.PostTransition(transDef);
        }
        override protected void RunUndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBaseUndoScript(transDef))
                base.RunUndoTransition(transDef.BaseTransDef);
            this.UndoTransition(transDef);
        }
    }
}
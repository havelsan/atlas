
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MPBSCivilTraineeStudent")] 

    /// <summary>
    /// Sivil Stajyer Öğrenci
    /// </summary>
    public  partial class MPBSCivilTraineeStudent : MPBSPerson
    {
        public class MPBSCivilTraineeStudentList : TTObjectCollection<MPBSCivilTraineeStudent> { }
                    
        public class ChildMPBSCivilTraineeStudentCollection : TTObject.TTChildObjectCollection<MPBSCivilTraineeStudent>
        {
            public ChildMPBSCivilTraineeStudentCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMPBSCivilTraineeStudentCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid Completed { get { return new Guid("8fcc0186-0153-473c-82a8-818ceea2b2e7"); } }
            public static Guid New { get { return new Guid("7696dce8-c383-4702-895e-d92d449eb1a8"); } }
        }

    /// <summary>
    /// Bitiş Tarihi
    /// </summary>
        public DateTime? EndDate
        {
            get { return (DateTime?)this["ENDDATE"]; }
            set { this["ENDDATE"] = value; }
        }

    /// <summary>
    /// TC Kimlik No
    /// </summary>
        public double? IdentityNumber
        {
            get { return (double?)this["IDENTITYNUMBER"]; }
            set { this["IDENTITYNUMBER"] = value; }
        }

    /// <summary>
    /// Başlangıç Tarihi
    /// </summary>
        public DateTime? StartDate
        {
            get { return (DateTime?)this["STARTDATE"]; }
            set { this["STARTDATE"] = value; }
        }

    /// <summary>
    /// Staj birimi
    /// </summary>
        public MPBSTrainingUnitDefinition TrainingUnit
        {
            get { return (MPBSTrainingUnitDefinition)((ITTObject)this).GetParent("TRAININGUNIT"); }
            set { this["TRAININGUNIT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MPBSCivilTraineeStudent(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MPBSCivilTraineeStudent(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MPBSCivilTraineeStudent(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MPBSCivilTraineeStudent(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MPBSCivilTraineeStudent(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MPBSCIVILTRAINEESTUDENT", dataRow) { }
        protected MPBSCivilTraineeStudent(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MPBSCIVILTRAINEESTUDENT", dataRow, isImported) { }
        public MPBSCivilTraineeStudent(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MPBSCivilTraineeStudent(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MPBSCivilTraineeStudent() : base() { }

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
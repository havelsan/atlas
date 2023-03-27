
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PsychologicExamination")] 

    public  partial class PsychologicExamination : EpisodeAction, IWorkListEpisodeAction
    {
        public class PsychologicExaminationList : TTObjectCollection<PsychologicExamination> { }
                    
        public class ChildPsychologicExaminationCollection : TTObject.TTChildObjectCollection<PsychologicExamination>
        {
            public ChildPsychologicExaminationCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPsychologicExaminationCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid Therapy { get { return new Guid("4aa94ab4-8370-4350-ad57-24c2bb751ec9"); } }
            public static Guid Request { get { return new Guid("ec7a621a-52d8-495e-a508-dea58d40b4d1"); } }
            public static Guid Cancelled { get { return new Guid("aee60695-0182-4e4c-9efd-4554457d27a0"); } }
            public static Guid Completed { get { return new Guid("040be0be-5a87-4f25-a2ab-41ef30c366b8"); } }
        }

    /// <summary>
    /// Konsültasyon İstek Açıklaması
    /// </summary>
        public string ConsultationRequestStatement
        {
            get { return (string)this["CONSULTATIONREQUESTSTATEMENT"]; }
            set { this["CONSULTATIONREQUESTSTATEMENT"] = value; }
        }

    /// <summary>
    /// Konsültasyon Sonucu
    /// </summary>
        public string ConsultationResult
        {
            get { return (string)this["CONSULTATIONRESULT"]; }
            set { this["CONSULTATIONRESULT"] = value; }
        }

        virtual protected void CreatePsychologyBasedObjectsCollection()
        {
            _PsychologyBasedObjects = new PsychologyBasedObject.ChildPsychologyBasedObjectCollection(this, new Guid("913ee33e-0585-4567-b843-adfc3aad8ac5"));
            ((ITTChildObjectCollection)_PsychologyBasedObjects).GetChildren();
        }

        protected PsychologyBasedObject.ChildPsychologyBasedObjectCollection _PsychologyBasedObjects = null;
        public PsychologyBasedObject.ChildPsychologyBasedObjectCollection PsychologyBasedObjects
        {
            get
            {
                if (_PsychologyBasedObjects == null)
                    CreatePsychologyBasedObjectsCollection();
                return _PsychologyBasedObjects;
            }
        }

        override protected void CreateSubactionProceduresCollectionViews()
        {
            base.CreateSubactionProceduresCollectionViews();
            _PsychologyTests = new PsychologyTest.ChildPsychologyTestCollection(_SubactionProcedures, "PsychologyTests");
        }

        private PsychologyTest.ChildPsychologyTestCollection _PsychologyTests = null;
        public PsychologyTest.ChildPsychologyTestCollection PsychologyTests
        {
            get
            {
                if (_SubactionProcedures == null)
                    CreateSubactionProceduresCollection();
                return _PsychologyTests;
            }            
        }

        protected PsychologicExamination(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PsychologicExamination(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PsychologicExamination(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PsychologicExamination(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PsychologicExamination(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PSYCHOLOGICEXAMINATION", dataRow) { }
        protected PsychologicExamination(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PSYCHOLOGICEXAMINATION", dataRow, isImported) { }
        public PsychologicExamination(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PsychologicExamination(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PsychologicExamination() : base() { }

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
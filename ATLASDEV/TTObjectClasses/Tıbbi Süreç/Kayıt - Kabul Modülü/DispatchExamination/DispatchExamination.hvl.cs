
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DispatchExamination")] 

    /// <summary>
    /// HİZMET PROTOKOL KABUL NESNESİ
    /// </summary>
    public  partial class DispatchExamination : PhysicianApplication
    {
        public class DispatchExaminationList : TTObjectCollection<DispatchExamination> { }
                    
        public class ChildDispatchExaminationCollection : TTObject.TTChildObjectCollection<DispatchExamination>
        {
            public ChildDispatchExaminationCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDispatchExaminationCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid Cancelled { get { return new Guid("705ed11f-0931-4eb5-81c3-46c0026d2818"); } }
            public static Guid Completed { get { return new Guid("9725d1c0-f8a7-41f7-80bc-b6443b933e55"); } }
    /// <summary>
    ///  Tetkik istendi ve sonucu bekleniyor
    /// </summary>
            public static Guid ProcedureRequested { get { return new Guid("2656f57d-1812-43dd-9d19-59826d1b2a0a"); } }
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("7973275f-30bb-47fb-9511-9078320902a0"); } }
        }

        override protected void CreateSubactionProceduresCollectionViews()
        {
            base.CreateSubactionProceduresCollectionViews();
            _DispatchExaminationAdditionalApplications = new DispatchExaminationAdditionalApplication.ChildDispatchExaminationAdditionalApplicationCollection(_SubactionProcedures, "DispatchExaminationAdditionalApplications");
        }

        private DispatchExaminationAdditionalApplication.ChildDispatchExaminationAdditionalApplicationCollection _DispatchExaminationAdditionalApplications = null;
        public DispatchExaminationAdditionalApplication.ChildDispatchExaminationAdditionalApplicationCollection DispatchExaminationAdditionalApplications
        {
            get
            {
                if (_SubactionProcedures == null)
                    CreateSubactionProceduresCollection();
                return _DispatchExaminationAdditionalApplications;
            }            
        }

        protected DispatchExamination(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DispatchExamination(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DispatchExamination(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DispatchExamination(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DispatchExamination(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DISPATCHEXAMINATION", dataRow) { }
        protected DispatchExamination(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DISPATCHEXAMINATION", dataRow, isImported) { }
        public DispatchExamination(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DispatchExamination(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DispatchExamination() : base() { }

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
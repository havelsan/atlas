
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="EmergencyInterventionNursingDetail")] 

    /// <summary>
    /// Acil Hemşirelik Hizmetleri
    /// </summary>
    public  partial class EmergencyInterventionNursingDetail : EpisodeActionWithDiagnosis, IWorkListEpisodeAction
    {
        public class EmergencyInterventionNursingDetailList : TTObjectCollection<EmergencyInterventionNursingDetail> { }
                    
        public class ChildEmergencyInterventionNursingDetailCollection : TTObject.TTChildObjectCollection<EmergencyInterventionNursingDetail>
        {
            public ChildEmergencyInterventionNursingDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildEmergencyInterventionNursingDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("d7d366f9-aeb3-421d-ae4d-bab70ae3e63b"); } }
            public static Guid Complete { get { return new Guid("39d5c826-8206-444c-99af-0cf38d7e39ab"); } }
        }

        public EmergencyIntervention EmergencyIntervention
        {
            get { return (EmergencyIntervention)((ITTObject)this).GetParent("EMERGENCYINTERVENTION"); }
            set { this["EMERGENCYINTERVENTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        override protected void CreateSubactionProceduresCollectionViews()
        {
            base.CreateSubactionProceduresCollectionViews();
            _EmergencyInterventionAdditionalApplication = new EmergencyInterventionAdditionalApplication.ChildEmergencyInterventionAdditionalApplicationCollection(_SubactionProcedures, "EmergencyInterventionAdditionalApplication");
        }

        private EmergencyInterventionAdditionalApplication.ChildEmergencyInterventionAdditionalApplicationCollection _EmergencyInterventionAdditionalApplication = null;
        public EmergencyInterventionAdditionalApplication.ChildEmergencyInterventionAdditionalApplicationCollection EmergencyInterventionAdditionalApplication
        {
            get
            {
                if (_SubactionProcedures == null)
                    CreateSubactionProceduresCollection();
                return _EmergencyInterventionAdditionalApplication;
            }            
        }

        protected EmergencyInterventionNursingDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected EmergencyInterventionNursingDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected EmergencyInterventionNursingDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected EmergencyInterventionNursingDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected EmergencyInterventionNursingDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EMERGENCYINTERVENTIONNURSINGDETAIL", dataRow) { }
        protected EmergencyInterventionNursingDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EMERGENCYINTERVENTIONNURSINGDETAIL", dataRow, isImported) { }
        public EmergencyInterventionNursingDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public EmergencyInterventionNursingDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public EmergencyInterventionNursingDetail() : base() { }

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

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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PatientMedulaHastaKabul")] 

    public  partial class PatientMedulaHastaKabul : TTObject
    {
        public class PatientMedulaHastaKabulList : TTObjectCollection<PatientMedulaHastaKabul> { }
                    
        public class ChildPatientMedulaHastaKabulCollection : TTObject.TTChildObjectCollection<PatientMedulaHastaKabul>
        {
            public ChildPatientMedulaHastaKabulCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPatientMedulaHastaKabulCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid Valid { get { return new Guid("27e3db00-0204-45b5-a92a-f9b84b230141"); } }
            public static Guid Cancelled { get { return new Guid("27a2fb93-67e6-4245-b5cf-bf543f62a085"); } }
            public static Guid Invalid { get { return new Guid("cc6e4a04-0ba0-4f3e-a2e3-1a1a9b68e843"); } }
        }

        public static BindingList<PatientMedulaHastaKabul> GetByTakipNo(TTObjectContext objectContext, string TAKIPNO)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTMEDULAHASTAKABUL"].QueryDefs["GetByTakipNo"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TAKIPNO", TAKIPNO);

            return ((ITTQuery)objectContext).QueryObjects<PatientMedulaHastaKabul>(queryDef, paramList);
        }

    /// <summary>
    /// Hizmet Kayıt yapılabilecekleri döndürür
    /// </summary>
        public static BindingList<PatientMedulaHastaKabul> GetOnValidState(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTMEDULAHASTAKABUL"].QueryDefs["GetOnValidState"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<PatientMedulaHastaKabul>(queryDef, paramList);
        }

    /// <summary>
    /// Hasta-Medula Hasta Kabulleri
    /// </summary>
        public Patient Patient
        {
            get { return (Patient)((ITTObject)this).GetParent("PATIENT"); }
            set { this["PATIENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Episode Episode
        {
            get { return (Episode)((ITTObject)this).GetParent("EPISODE"); }
            set { this["EPISODE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public BaseHastaKabul BaseHastaKabul
        {
            get { return (BaseHastaKabul)((ITTObject)this).GetParent("BASEHASTAKABUL"); }
            set { this["BASEHASTAKABUL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateSubActionMaterialsCollection()
        {
            _SubActionMaterials = new SubActionMaterial.ChildSubActionMaterialCollection(this, new Guid("499f5fc8-691b-4c10-8b93-dc53936807b3"));
            ((ITTChildObjectCollection)_SubActionMaterials).GetChildren();
        }

        protected SubActionMaterial.ChildSubActionMaterialCollection _SubActionMaterials = null;
    /// <summary>
    /// Child collection for Medula Hasta Kabul-Malzemeler
    /// </summary>
        public SubActionMaterial.ChildSubActionMaterialCollection SubActionMaterials
        {
            get
            {
                if (_SubActionMaterials == null)
                    CreateSubActionMaterialsCollection();
                return _SubActionMaterials;
            }
        }

        virtual protected void CreateEpisodeActionsCollection()
        {
            _EpisodeActions = new EpisodeAction.ChildEpisodeActionCollection(this, new Guid("48baad19-8383-4179-97e2-2211cb7b0487"));
            ((ITTChildObjectCollection)_EpisodeActions).GetChildren();
        }

        protected EpisodeAction.ChildEpisodeActionCollection _EpisodeActions = null;
    /// <summary>
    /// Child collection for İşleme Bağlı Medula Hasta Kabul Nesnesi
    /// </summary>
        public EpisodeAction.ChildEpisodeActionCollection EpisodeActions
        {
            get
            {
                if (_EpisodeActions == null)
                    CreateEpisodeActionsCollection();
                return _EpisodeActions;
            }
        }

        virtual protected void CreateSubActionProceduresCollection()
        {
            _SubActionProcedures = new SubActionProcedure.ChildSubActionProcedureCollection(this, new Guid("cd14677b-70a1-4582-87cb-e582a4f7b8dd"));
            ((ITTChildObjectCollection)_SubActionProcedures).GetChildren();
        }

        protected SubActionProcedure.ChildSubActionProcedureCollection _SubActionProcedures = null;
    /// <summary>
    /// Child collection for Medula Hasta Kabul-Hizmetler
    /// </summary>
        public SubActionProcedure.ChildSubActionProcedureCollection SubActionProcedures
        {
            get
            {
                if (_SubActionProcedures == null)
                    CreateSubActionProceduresCollection();
                return _SubActionProcedures;
            }
        }

        protected PatientMedulaHastaKabul(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PatientMedulaHastaKabul(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PatientMedulaHastaKabul(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PatientMedulaHastaKabul(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PatientMedulaHastaKabul(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PATIENTMEDULAHASTAKABUL", dataRow) { }
        protected PatientMedulaHastaKabul(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PATIENTMEDULAHASTAKABUL", dataRow, isImported) { }
        public PatientMedulaHastaKabul(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PatientMedulaHastaKabul(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PatientMedulaHastaKabul() : base() { }

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
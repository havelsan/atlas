
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="TraditionalAlternative")] 

    /// <summary>
    /// Geleneksel Alternatif Tamamlayıcı Uygulama İşlemleri
    /// </summary>
    public  partial class TraditionalAlternative : EpisodeActionWithDiagnosis, IReasonOfReject
    {
        public class TraditionalAlternativeList : TTObjectCollection<TraditionalAlternative> { }
                    
        public class ChildTraditionalAlternativeCollection : TTObject.TTChildObjectCollection<TraditionalAlternative>
        {
            public ChildTraditionalAlternativeCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildTraditionalAlternativeCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid Request { get { return new Guid("1dab7607-e311-4897-98e5-643c2fefb4ba"); } }
            public static Guid Procedure { get { return new Guid("5e440a33-06f0-4466-86ff-6ed514d7001d"); } }
            public static Guid Completed { get { return new Guid("7ea9e0e0-2cd8-4ece-884a-791b5181b7a8"); } }
            public static Guid Cancelled { get { return new Guid("86416fb4-4f53-4e82-b718-25550312e94d"); } }
        }

    /// <summary>
    /// Ön Bilgi
    /// </summary>
        public object PreInformation
        {
            get { return (object)this["PREINFORMATION"]; }
            set { this["PREINFORMATION"] = value; }
        }

    /// <summary>
    /// Protokol No
    /// </summary>
        public long? ProtocolNo
        {
            get { return (long?)this["PROTOCOLNO"]; }
            set { this["PROTOCOLNO"] = value; }
        }

    /// <summary>
    /// Rapor
    /// </summary>
        public object Report
        {
            get { return (object)this["REPORT"]; }
            set { this["REPORT"] = value; }
        }

    /// <summary>
    /// Altvaka oluşsun mu
    /// </summary>
        public bool? CreateSubEpisode
        {
            get { return (bool?)this["CREATESUBEPISODE"]; }
            set { this["CREATESUBEPISODE"] = value; }
        }

        virtual protected void CreateTraditionalAlternativeProceduresCollection()
        {
            _TraditionalAlternativeProcedures = new TraditionalAlternativeProcedure.ChildTraditionalAlternativeProcedureCollection(this, new Guid("6cd90722-93db-456b-beff-e7dda8a34df9"));
            ((ITTChildObjectCollection)_TraditionalAlternativeProcedures).GetChildren();
        }

        protected TraditionalAlternativeProcedure.ChildTraditionalAlternativeProcedureCollection _TraditionalAlternativeProcedures = null;
        public TraditionalAlternativeProcedure.ChildTraditionalAlternativeProcedureCollection TraditionalAlternativeProcedures
        {
            get
            {
                if (_TraditionalAlternativeProcedures == null)
                    CreateTraditionalAlternativeProceduresCollection();
                return _TraditionalAlternativeProcedures;
            }
        }

        override protected void CreateSubactionProceduresCollectionViews()
        {
            base.CreateSubactionProceduresCollectionViews();
            _TraditionalAlternativeAdditionalApplications = new TraditionalAlternativeAdditionalApplication.ChildTraditionalAlternativeAdditionalApplicationCollection(_SubactionProcedures, "TraditionalAlternativeAdditionalApplications");
        }

        private TraditionalAlternativeAdditionalApplication.ChildTraditionalAlternativeAdditionalApplicationCollection _TraditionalAlternativeAdditionalApplications = null;
        public TraditionalAlternativeAdditionalApplication.ChildTraditionalAlternativeAdditionalApplicationCollection TraditionalAlternativeAdditionalApplications
        {
            get
            {
                if (_SubactionProcedures == null)
                    CreateSubactionProceduresCollection();
                return _TraditionalAlternativeAdditionalApplications;
            }            
        }

        override protected void CreateTreatmentMaterialsCollectionViews()
        {
            base.CreateTreatmentMaterialsCollectionViews();
            _TraditionalAlternativeTreatmentMaterials = new TraditionalAlternativeTreatmentMaterial.ChildTraditionalAlternativeTreatmentMaterialCollection(_TreatmentMaterials, "TraditionalAlternativeTreatmentMaterials");
        }

        private TraditionalAlternativeTreatmentMaterial.ChildTraditionalAlternativeTreatmentMaterialCollection _TraditionalAlternativeTreatmentMaterials = null;
        public TraditionalAlternativeTreatmentMaterial.ChildTraditionalAlternativeTreatmentMaterialCollection TraditionalAlternativeTreatmentMaterials
        {
            get
            {
                if (_TreatmentMaterials == null)
                    CreateTreatmentMaterialsCollection();
                return _TraditionalAlternativeTreatmentMaterials;
            }            
        }

        protected TraditionalAlternative(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected TraditionalAlternative(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected TraditionalAlternative(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected TraditionalAlternative(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected TraditionalAlternative(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "TRADITIONALALTERNATIVE", dataRow) { }
        protected TraditionalAlternative(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "TRADITIONALALTERNATIVE", dataRow, isImported) { }
        public TraditionalAlternative(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public TraditionalAlternative(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public TraditionalAlternative() : base() { }

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
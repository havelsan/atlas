
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="IntensiveCareAfterSurgery")] 

    /// <summary>
    /// Ameliyat Sonrası  Derlenme İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
    public  partial class IntensiveCareAfterSurgery : BaseInpatientAdmission, ITreatmentMaterialCollection, IStockOutCancel
    {
        public class IntensiveCareAfterSurgeryList : TTObjectCollection<IntensiveCareAfterSurgery> { }
                    
        public class ChildIntensiveCareAfterSurgeryCollection : TTObject.TTChildObjectCollection<IntensiveCareAfterSurgery>
        {
            public ChildIntensiveCareAfterSurgeryCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildIntensiveCareAfterSurgeryCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid PostOp { get { return new Guid("35b72248-e29e-4079-b4e2-14be293585e1"); } }
            public static Guid Procedure { get { return new Guid("4f597dc3-5a06-4fde-b3ca-2d5720ce1617"); } }
            public static Guid Discharged { get { return new Guid("043ea52d-a410-496b-941f-731fb6d2b141"); } }
            public static Guid DischargedWithoutProcedure { get { return new Guid("868f7c81-4864-4036-aede-c7510147c0eb"); } }
            public static Guid Cancelled { get { return new Guid("3beee544-cb33-44af-abbe-2f0c0cc3a3bb"); } }
        }

        public static BindingList<IntensiveCareAfterSurgery> GetByEpisode(TTObjectContext objectContext, Guid EPISODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INTENSIVECAREAFTERSURGERY"].QueryDefs["GetByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return ((ITTQuery)objectContext).QueryObjects<IntensiveCareAfterSurgery>(queryDef, paramList);
        }

    /// <summary>
    /// Derleme Açıklamaları
    /// </summary>
        public object PostOpDescription
        {
            get { return (object)this["POSTOPDESCRIPTION"]; }
            set { this["POSTOPDESCRIPTION"] = value; }
        }

    /// <summary>
    /// Protokol No
    /// </summary>
        public TTSequence ProtocolNo
        {
            get { return GetSequence("PROTOCOLNO"); }
        }

    /// <summary>
    /// Derlenme Giriş Tarih/Saati
    /// </summary>
        public DateTime? PostOpStartTime
        {
            get { return (DateTime?)this["POSTOPSTARTTIME"]; }
            set { this["POSTOPSTARTTIME"] = value; }
        }

    /// <summary>
    /// Derlenme Giriş Tarih/Saati
    /// </summary>
        public DateTime? PostOpEndTime
        {
            get { return (DateTime?)this["POSTOPENDTIME"]; }
            set { this["POSTOPENDTIME"] = value; }
        }

        public Surgery Surgery
        {
            get { return (Surgery)((ITTObject)this).GetParent("SURGERY"); }
            set { this["SURGERY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public AnesthesiaAndReanimation AnesthesiaAndReanimation
        {
            get { return (AnesthesiaAndReanimation)((ITTObject)this).GetParent("ANESTHESIAANDREANIMATION"); }
            set { this["ANESTHESIAANDREANIMATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateResponsiblePersonnelsCollection()
        {
            _ResponsiblePersonnels = new IntensiveCareAfterSurgeryResponsiblePersonnel.ChildIntensiveCareAfterSurgeryResponsiblePersonnelCollection(this, new Guid("b0d0c90f-ed5b-4447-bd54-1528ff850f55"));
            ((ITTChildObjectCollection)_ResponsiblePersonnels).GetChildren();
        }

        protected IntensiveCareAfterSurgeryResponsiblePersonnel.ChildIntensiveCareAfterSurgeryResponsiblePersonnelCollection _ResponsiblePersonnels = null;
    /// <summary>
    /// Child collection for Sorumlu Personel
    /// </summary>
        public IntensiveCareAfterSurgeryResponsiblePersonnel.ChildIntensiveCareAfterSurgeryResponsiblePersonnelCollection ResponsiblePersonnels
        {
            get
            {
                if (_ResponsiblePersonnels == null)
                    CreateResponsiblePersonnelsCollection();
                return _ResponsiblePersonnels;
            }
        }

        virtual protected void CreateProgressesCollection()
        {
            _Progresses = new IntensiveCareAfterSurgeryProgresses.ChildIntensiveCareAfterSurgeryProgressesCollection(this, new Guid("30501aef-9775-4ea1-84f2-3c22b4d52967"));
            ((ITTChildObjectCollection)_Progresses).GetChildren();
        }

        protected IntensiveCareAfterSurgeryProgresses.ChildIntensiveCareAfterSurgeryProgressesCollection _Progresses = null;
    /// <summary>
    /// Child collection for Hastanın Güncesi
    /// </summary>
        public IntensiveCareAfterSurgeryProgresses.ChildIntensiveCareAfterSurgeryProgressesCollection Progresses
        {
            get
            {
                if (_Progresses == null)
                    CreateProgressesCollection();
                return _Progresses;
            }
        }

        virtual protected void CreateIntensiveCareEstimatingsCollection()
        {
            _IntensiveCareEstimatings = new IntensiveCareEstimatingGrid.ChildIntensiveCareEstimatingGridCollection(this, new Guid("eea47b5f-464b-49fb-b590-e8895b31c0ec"));
            ((ITTChildObjectCollection)_IntensiveCareEstimatings).GetChildren();
        }

        protected IntensiveCareEstimatingGrid.ChildIntensiveCareEstimatingGridCollection _IntensiveCareEstimatings = null;
    /// <summary>
    /// Child collection for Anestezi Derleme-Anestezi Sonrası Değerlendirme
    /// </summary>
        public IntensiveCareEstimatingGrid.ChildIntensiveCareEstimatingGridCollection IntensiveCareEstimatings
        {
            get
            {
                if (_IntensiveCareEstimatings == null)
                    CreateIntensiveCareEstimatingsCollection();
                return _IntensiveCareEstimatings;
            }
        }

        override protected void CreateSubactionProceduresCollectionViews()
        {
            base.CreateSubactionProceduresCollectionViews();
            _IntensiveCareBedProcedures = new BaseBedProcedure.ChildBaseBedProcedureCollection(_SubactionProcedures, "IntensiveCareBedProcedures");
            _IntensiveCareNursingProcedures = new IntensiveCareNursingProcedure.ChildIntensiveCareNursingProcedureCollection(_SubactionProcedures, "IntensiveCareNursingProcedures");
        }

        private BaseBedProcedure.ChildBaseBedProcedureCollection _IntensiveCareBedProcedures = null;
        public BaseBedProcedure.ChildBaseBedProcedureCollection IntensiveCareBedProcedures
        {
            get
            {
                if (_SubactionProcedures == null)
                    CreateSubactionProceduresCollection();
                return _IntensiveCareBedProcedures;
            }            
        }

        private IntensiveCareNursingProcedure.ChildIntensiveCareNursingProcedureCollection _IntensiveCareNursingProcedures = null;
        public IntensiveCareNursingProcedure.ChildIntensiveCareNursingProcedureCollection IntensiveCareNursingProcedures
        {
            get
            {
                if (_SubactionProcedures == null)
                    CreateSubactionProceduresCollection();
                return _IntensiveCareNursingProcedures;
            }            
        }

        protected IntensiveCareAfterSurgery(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected IntensiveCareAfterSurgery(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected IntensiveCareAfterSurgery(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected IntensiveCareAfterSurgery(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected IntensiveCareAfterSurgery(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "INTENSIVECAREAFTERSURGERY", dataRow) { }
        protected IntensiveCareAfterSurgery(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "INTENSIVECAREAFTERSURGERY", dataRow, isImported) { }
        public IntensiveCareAfterSurgery(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public IntensiveCareAfterSurgery(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public IntensiveCareAfterSurgery() : base() { }

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

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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="Dispensary")] 

    /// <summary>
    /// Bakımevi İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
    public  partial class Dispensary : EpisodeAction, IReasonOfReject
    {
        public class DispensaryList : TTObjectCollection<Dispensary> { }
                    
        public class ChildDispensaryCollection : TTObject.TTChildObjectCollection<Dispensary>
        {
            public ChildDispensaryCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDispensaryCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid RequestAcception { get { return new Guid("d4a21e1d-9503-4fa3-9458-604668953099"); } }
    /// <summary>
    /// İptal Edildi
    /// </summary>
            public static Guid Cancelled { get { return new Guid("50c17596-c2c3-4988-a843-02dbf54499c1"); } }
            public static Guid Request { get { return new Guid("cef97da0-0551-4933-928f-07df48a2d8a4"); } }
            public static Guid DispansaryCheckIn { get { return new Guid("175bec7c-3379-4ea8-92e0-bc60504880bd"); } }
            public static Guid Dispansary { get { return new Guid("fe0aaecb-695a-4ab3-97be-f12109fa4395"); } }
            public static Guid DispansaryCheckOut { get { return new Guid("f2af1ede-3582-42e9-8847-c49f30e54916"); } }
            public static Guid Approval { get { return new Guid("91efe06e-d3d7-451a-a728-936d4d3a4605"); } }
            public static Guid Rejected { get { return new Guid("725f5860-77bf-4d76-81f8-ff75c4bc6ac5"); } }
        }

    /// <summary>
    /// Protokol No
    /// </summary>
        public TTSequence ProtocolNo
        {
            get { return GetSequence("PROTOCOLNO"); }
        }

    /// <summary>
    /// Çıkış Nedeni
    /// </summary>
        public object ReasonForDeparture
        {
            get { return (object)this["REASONFORDEPARTURE"]; }
            set { this["REASONFORDEPARTURE"] = value; }
        }

    /// <summary>
    /// Sosyal Not
    /// </summary>
        public object SocialNote
        {
            get { return (object)this["SOCIALNOTE"]; }
            set { this["SOCIALNOTE"] = value; }
        }

    /// <summary>
    /// Hemşire Notu
    /// </summary>
        public string NurseNote
        {
            get { return (string)this["NURSENOTE"]; }
            set { this["NURSENOTE"] = value; }
        }

    /// <summary>
    /// Geçmişte Kalınan Gün Sayısı
    /// </summary>
        public int? NumberOfLastStayDays
        {
            get { return (int?)this["NUMBEROFLASTSTAYDAYS"]; }
            set { this["NUMBEROFLASTSTAYDAYS"] = value; }
        }

    /// <summary>
    /// Kalış Bilgisi
    /// </summary>
        public string StayingInfo
        {
            get { return (string)this["STAYINGINFO"]; }
            set { this["STAYINGINFO"] = value; }
        }

    /// <summary>
    /// Refakatçi İhtiyacı
    /// </summary>
        public bool? IsCompanionNeeded
        {
            get { return (bool?)this["ISCOMPANIONNEEDED"]; }
            set { this["ISCOMPANIONNEEDED"] = value; }
        }

    /// <summary>
    /// Geçmiş Vukuatlar
    /// </summary>
        public object LastEvents
        {
            get { return (object)this["LASTEVENTS"]; }
            set { this["LASTEVENTS"] = value; }
        }

    /// <summary>
    /// Kalış Sebebi
    /// </summary>
        public string ReasonForStay
        {
            get { return (string)this["REASONFORSTAY"]; }
            set { this["REASONFORSTAY"] = value; }
        }

    /// <summary>
    /// Kalış Gün Sayısı
    /// </summary>
        public int? NumberOfStayDays
        {
            get { return (int?)this["NUMBEROFSTAYDAYS"]; }
            set { this["NUMBEROFSTAYDAYS"] = value; }
        }

    /// <summary>
    /// Gazilik Tanı
    /// </summary>
        public string GhaziDiagnosis
        {
            get { return (string)this["GHAZIDIAGNOSIS"]; }
            set { this["GHAZIDIAGNOSIS"] = value; }
        }

    /// <summary>
    /// Vukuat
    /// </summary>
        public object Events
        {
            get { return (object)this["EVENTS"]; }
            set { this["EVENTS"] = value; }
        }

    /// <summary>
    /// Doktor Notu
    /// </summary>
        public object DoctorNote
        {
            get { return (object)this["DOCTORNOTE"]; }
            set { this["DOCTORNOTE"] = value; }
        }

    /// <summary>
    /// Çıkış Tarihi
    /// </summary>
        public DateTime? DepartureDate
        {
            get { return (DateTime?)this["DEPARTUREDATE"]; }
            set { this["DEPARTUREDATE"] = value; }
        }

    /// <summary>
    /// Yatış Tarihi
    /// </summary>
        public DateTime? StayingDate
        {
            get { return (DateTime?)this["STAYINGDATE"]; }
            set { this["STAYINGDATE"] = value; }
        }

        public ResRoom Room
        {
            get { return (ResRoom)((ITTObject)this).GetParent("ROOM"); }
            set { this["ROOM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateDispensaryDrugsCollection()
        {
            _DispensaryDrugs = new DispensaryDrugs.ChildDispensaryDrugsCollection(this, new Guid("5e50a143-e8b4-4d49-a40c-0f8988e6149a"));
            ((ITTChildObjectCollection)_DispensaryDrugs).GetChildren();
        }

        protected DispensaryDrugs.ChildDispensaryDrugsCollection _DispensaryDrugs = null;
    /// <summary>
    /// Child collection for İlaçlar
    /// </summary>
        public DispensaryDrugs.ChildDispensaryDrugsCollection DispensaryDrugs
        {
            get
            {
                if (_DispensaryDrugs == null)
                    CreateDispensaryDrugsCollection();
                return _DispensaryDrugs;
            }
        }

        virtual protected void CreateDispensaryGhaziBehaviorsCollection()
        {
            _DispensaryGhaziBehaviors = new DispensaryGhaziBehavior.ChildDispensaryGhaziBehaviorCollection(this, new Guid("131059d6-3226-4f02-b49b-6128e7d08cdb"));
            ((ITTChildObjectCollection)_DispensaryGhaziBehaviors).GetChildren();
        }

        protected DispensaryGhaziBehavior.ChildDispensaryGhaziBehaviorCollection _DispensaryGhaziBehaviors = null;
    /// <summary>
    /// Child collection for Gazi Durum
    /// </summary>
        public DispensaryGhaziBehavior.ChildDispensaryGhaziBehaviorCollection DispensaryGhaziBehaviors
        {
            get
            {
                if (_DispensaryGhaziBehaviors == null)
                    CreateDispensaryGhaziBehaviorsCollection();
                return _DispensaryGhaziBehaviors;
            }
        }

        virtual protected void CreateDispensaryDebitsCollection()
        {
            _DispensaryDebits = new DispensaryDebit.ChildDispensaryDebitCollection(this, new Guid("30f50799-f37c-4efd-87ca-809aba03dd1f"));
            ((ITTChildObjectCollection)_DispensaryDebits).GetChildren();
        }

        protected DispensaryDebit.ChildDispensaryDebitCollection _DispensaryDebits = null;
    /// <summary>
    /// Child collection for Zimmet
    /// </summary>
        public DispensaryDebit.ChildDispensaryDebitCollection DispensaryDebits
        {
            get
            {
                if (_DispensaryDebits == null)
                    CreateDispensaryDebitsCollection();
                return _DispensaryDebits;
            }
        }

        protected Dispensary(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected Dispensary(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected Dispensary(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected Dispensary(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected Dispensary(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DISPENSARY", dataRow) { }
        protected Dispensary(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DISPENSARY", dataRow, isImported) { }
        public Dispensary(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public Dispensary(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public Dispensary() : base() { }

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
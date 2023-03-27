
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="RegularObstetric")] 

    /// <summary>
    /// Normal Doğum
    /// </summary>
    public  partial class RegularObstetric : EpisodeActionWithDiagnosis
    {
        public class RegularObstetricList : TTObjectCollection<RegularObstetric> { }
                    
        public class ChildRegularObstetricCollection : TTObject.TTChildObjectCollection<RegularObstetric>
        {
            public ChildRegularObstetricCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildRegularObstetricCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("c7dba6dd-d8be-473f-9566-9a43dbdc8690"); } }
    /// <summary>
    /// Doğum İşlemleri
    /// </summary>
            public static Guid ObstetricProcedures { get { return new Guid("835c5222-a3c6-4c60-b968-ba6967f15161"); } }
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("449ae978-06d3-4fa4-84d0-079d23d853c5"); } }
    /// <summary>
    /// İşlem İptal Edildi
    /// </summary>
            public static Guid Cancelled { get { return new Guid("cebd93f6-75b1-49da-80f4-b9333f5a858e"); } }
        }

    /// <summary>
    /// Aydınlatılmış Onam Formu Verildi
    /// </summary>
        public bool? IsPatientApprovalFormGiven
        {
            get { return (bool?)this["ISPATIENTAPPROVALFORMGIVEN"]; }
            set { this["ISPATIENTAPPROVALFORMGIVEN"] = value; }
        }

    /// <summary>
    /// Not
    /// </summary>
        public object Note
        {
            get { return (object)this["NOTE"]; }
            set { this["NOTE"] = value; }
        }

    /// <summary>
    /// Anne Yaşı
    /// </summary>
        public int? MotherAge
        {
            get { return (int?)this["MOTHERAGE"]; }
            set { this["MOTHERAGE"] = value; }
        }

    /// <summary>
    /// Annenin Gebelikte Geçirdiği Sağlık Riskleri
    /// </summary>
        public string PregnancyRiskInfo
        {
            get { return (string)this["PREGNANCYRISKINFO"]; }
            set { this["PREGNANCYRISKINFO"] = value; }
        }

    /// <summary>
    /// Kaçıncı Gebelik
    /// </summary>
        public int? WhichPregnancy
        {
            get { return (int?)this["WHICHPREGNANCY"]; }
            set { this["WHICHPREGNANCY"] = value; }
        }

    /// <summary>
    /// Yaşayan Çocuk Sayısı
    /// </summary>
        public int? LiveBirthsNumber
        {
            get { return (int?)this["LIVEBIRTHSNUMBER"]; }
            set { this["LIVEBIRTHSNUMBER"] = value; }
        }

    /// <summary>
    /// Yeni doğan bebek sayısı
    /// </summary>
        public int? NewbornsNumber
        {
            get { return (int?)this["NEWBORNSNUMBER"]; }
            set { this["NEWBORNSNUMBER"] = value; }
        }

    /// <summary>
    /// Gebelik Sonucu
    /// </summary>
        public SKRSGebelikSonucu BirthResult
        {
            get { return (SKRSGebelikSonucu)((ITTObject)this).GetParent("BIRTHRESULT"); }
            set { this["BIRTHRESULT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Hangi Gebeliğin Doğumu Olduğu Bilgisi
    /// </summary>
        public Pregnancy Pregnancy
        {
            get { return (Pregnancy)((ITTObject)this).GetParent("PREGNANCY"); }
            set { this["PREGNANCY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Gebelik Aralığı
    /// </summary>
        public SKRSGebelikAraligi PregnancyRange
        {
            get { return (SKRSGebelikAraligi)((ITTObject)this).GetParent("PREGNANCYRANGE"); }
            set { this["PREGNANCYRANGE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Annenin Hangi Hasta Olduğu Bilgisi
    /// </summary>
        public Patient Patient
        {
            get { return (Patient)((ITTObject)this).GetParent("PATIENT"); }
            set { this["PATIENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Sayısal verileri tutar
    /// </summary>
        public PregnantInformation PregnantInformation
        {
            get { return (PregnantInformation)((ITTObject)this).GetParent("PREGNANTINFORMATION"); }
            set { this["PREGNANTINFORMATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateRegularObstetricPersonelCollection()
        {
            _RegularObstetricPersonel = new RegularObstetricPersonel.ChildRegularObstetricPersonelCollection(this, new Guid("321e4c2c-35fe-4e53-9f5d-e3aa599c4374"));
            ((ITTChildObjectCollection)_RegularObstetricPersonel).GetChildren();
        }

        protected RegularObstetricPersonel.ChildRegularObstetricPersonelCollection _RegularObstetricPersonel = null;
        public RegularObstetricPersonel.ChildRegularObstetricPersonelCollection RegularObstetricPersonel
        {
            get
            {
                if (_RegularObstetricPersonel == null)
                    CreateRegularObstetricPersonelCollection();
                return _RegularObstetricPersonel;
            }
        }

        virtual protected void CreateBabyObstetricInformationCollection()
        {
            _BabyObstetricInformation = new BabyObstetricInformation.ChildBabyObstetricInformationCollection(this, new Guid("ab97679f-c0aa-4685-82c7-ff2cff47c3ca"));
            ((ITTChildObjectCollection)_BabyObstetricInformation).GetChildren();
        }

        protected BabyObstetricInformation.ChildBabyObstetricInformationCollection _BabyObstetricInformation = null;
    /// <summary>
    /// Child collection for bebek bilgisinin hangi doğuma ait olduğu bilgisi
    /// </summary>
        public BabyObstetricInformation.ChildBabyObstetricInformationCollection BabyObstetricInformation
        {
            get
            {
                if (_BabyObstetricInformation == null)
                    CreateBabyObstetricInformationCollection();
                return _BabyObstetricInformation;
            }
        }

        virtual protected void CreateIndicationReasonsCollection()
        {
            _IndicationReasons = new IndicationReason.ChildIndicationReasonCollection(this, new Guid("6530d0ba-1acf-4dd9-85cf-38e0217a92a1"));
            ((ITTChildObjectCollection)_IndicationReasons).GetChildren();
        }

        protected IndicationReason.ChildIndicationReasonCollection _IndicationReasons = null;
        public IndicationReason.ChildIndicationReasonCollection IndicationReasons
        {
            get
            {
                if (_IndicationReasons == null)
                    CreateIndicationReasonsCollection();
                return _IndicationReasons;
            }
        }

        override protected void CreateSubactionProceduresCollectionViews()
        {
            base.CreateSubactionProceduresCollectionViews();
            _RegularObstetricProcedures = new ManipulationProcedure.ChildManipulationProcedureCollection(_SubactionProcedures, "RegularObstetricProcedures");
        }

        private ManipulationProcedure.ChildManipulationProcedureCollection _RegularObstetricProcedures = null;
        public ManipulationProcedure.ChildManipulationProcedureCollection RegularObstetricProcedures
        {
            get
            {
                if (_SubactionProcedures == null)
                    CreateSubactionProceduresCollection();
                return _RegularObstetricProcedures;
            }            
        }

        protected RegularObstetric(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected RegularObstetric(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected RegularObstetric(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected RegularObstetric(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected RegularObstetric(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "REGULAROBSTETRIC", dataRow) { }
        protected RegularObstetric(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "REGULAROBSTETRIC", dataRow, isImported) { }
        public RegularObstetric(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public RegularObstetric(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public RegularObstetric() : base() { }

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
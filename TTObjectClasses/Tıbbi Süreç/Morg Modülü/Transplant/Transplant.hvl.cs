
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="Transplant")] 

    public  partial class Transplant : EpisodeAction
    {
        public class TransplantList : TTObjectCollection<Transplant> { }
                    
        public class ChildTransplantCollection : TTObject.TTChildObjectCollection<Transplant>
        {
            public ChildTransplantCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildTransplantCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("5356dc8e-2feb-4e21-8a3a-0bacfdf668f0"); } }
    /// <summary>
    /// İptal Et
    /// </summary>
            public static Guid Cancelled { get { return new Guid("c423aebb-f97b-41c7-856c-f220187c45a9"); } }
    /// <summary>
    /// İstek
    /// </summary>
            public static Guid Request { get { return new Guid("4fe9db50-651b-4ceb-ac05-a6ea2b335c70"); } }
    /// <summary>
    /// İşlemde
    /// </summary>
            public static Guid Procedure { get { return new Guid("42bb0960-29a6-489e-a359-e01552e4fb95"); } }
        }

    /// <summary>
    /// Ölüm Tarihi ve Saati
    /// </summary>
        public DateTime? DateTimeOfDeath
        {
            get { return (DateTime?)this["DATETIMEOFDEATH"]; }
            set { this["DATETIMEOFDEATH"] = value; }
        }

    /// <summary>
    /// İstatiksel Ölüm Sebebi
    /// </summary>
        public StatisticalDeathReason? StatisticalDeathReason
        {
            get { return (StatisticalDeathReason?)(int?)this["STATISTICALDEATHREASON"]; }
            set { this["STATISTICALDEATHREASON"] = value; }
        }

    /// <summary>
    /// Hastanın Üzerinden Çıkanlar
    /// </summary>
        public string ObjectsFromPatient
        {
            get { return (string)this["OBJECTSFROMPATIENT"]; }
            set { this["OBJECTSFROMPATIENT"] = value; }
        }

    /// <summary>
    /// Morg Hasta Nakil
    /// </summary>
        public Morgue Morgue
        {
            get { return (Morgue)((ITTObject)this).GetParent("MORGUE"); }
            set { this["MORGUE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Ölümü Tespit Eden Doktor
    /// </summary>
        public ResUser DoctorFixed
        {
            get { return (ResUser)((ITTObject)this).GetParent("DOCTORFIXED"); }
            set { this["DOCTORFIXED"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Morga Gönderen Doktor
    /// </summary>
        public ResUser SenderDoctor
        {
            get { return (ResUser)((ITTObject)this).GetParent("SENDERDOCTOR"); }
            set { this["SENDERDOCTOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Hemşire
    /// </summary>
        public ResUser Nurse
        {
            get { return (ResUser)((ITTObject)this).GetParent("NURSE"); }
            set { this["NURSE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Mernis Ölüm Sebepleri
    /// </summary>
        public MernisDeathReasonDefinition MernisDeathReasons
        {
            get { return (MernisDeathReasonDefinition)((ITTObject)this).GetParent("MERNISDEATHREASONS"); }
            set { this["MERNISDEATHREASONS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected Transplant(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected Transplant(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected Transplant(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected Transplant(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected Transplant(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "TRANSPLANT", dataRow) { }
        protected Transplant(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "TRANSPLANT", dataRow, isImported) { }
        public Transplant(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public Transplant(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public Transplant() : base() { }

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

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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MNZVisitor")] 

    /// <summary>
    /// Ziyaretçi
    /// </summary>
    public  partial class MNZVisitor : MNZPerson
    {
        public class MNZVisitorList : TTObjectCollection<MNZVisitor> { }
                    
        public class ChildMNZVisitorCollection : TTObject.TTChildObjectCollection<MNZVisitor>
        {
            public ChildMNZVisitorCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMNZVisitorCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Complete { get { return new Guid("dbd02554-baa2-4c8a-b385-48408c176f61"); } }
    /// <summary>
    /// Yeni Ziyaretçi Giriş Formu
    /// </summary>
            public static Guid New { get { return new Guid("a3f93b20-0e92-4258-8119-32def3f6c7c9"); } }
    /// <summary>
    /// Ziyaretçi Çıkışı
    /// </summary>
            public static Guid Exit { get { return new Guid("0c0a8df4-1179-46e0-9c8d-347dcf9fb8e0"); } }
        }

    /// <summary>
    /// Ziyaret Günü
    /// </summary>
        public DateTime? VisitDate
        {
            get { return (DateTime?)this["VISITDATE"]; }
            set { this["VISITDATE"] = value; }
        }

    /// <summary>
    /// Plaka No
    /// </summary>
        public string LisencePlate
        {
            get { return (string)this["LISENCEPLATE"]; }
            set { this["LISENCEPLATE"] = value; }
        }

    /// <summary>
    /// Çıkış Saati
    /// </summary>
        public DateTime? ExitTime
        {
            get { return (DateTime?)this["EXITTIME"]; }
            set { this["EXITTIME"] = value; }
        }

    /// <summary>
    /// ZiyaretSaati
    /// </summary>
        public DateTime? VisitTime
        {
            get { return (DateTime?)this["VISITTIME"]; }
            set { this["VISITTIME"] = value; }
        }

    /// <summary>
    /// Ziyaret Edilecek Hasta
    /// </summary>
        public Patient Patient
        {
            get { return (Patient)((ITTObject)this).GetParent("PATIENT"); }
            set { this["PATIENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Ziyaretçi Türü
    /// </summary>
        public XXXVisitorType VisitorType
        {
            get { return (XXXVisitorType)((ITTObject)this).GetParent("VISITORTYPE"); }
            set { this["VISITORTYPE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Ziyaret Sebebi
    /// </summary>
        public VisitReason VisitReason
        {
            get { return (VisitReason)((ITTObject)this).GetParent("VISITREASON"); }
            set { this["VISITREASON"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MNZVisitor(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MNZVisitor(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MNZVisitor(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MNZVisitor(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MNZVisitor(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MNZVISITOR", dataRow) { }
        protected MNZVisitor(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MNZVISITOR", dataRow, isImported) { }
        public MNZVisitor(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MNZVisitor(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MNZVisitor() : base() { }

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
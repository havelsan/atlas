
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MNZExpectedVisitor")] 

    /// <summary>
    /// Beklenen Ziyaretçi
    /// </summary>
    public  partial class MNZExpectedVisitor : MNZPerson
    {
        public class MNZExpectedVisitorList : TTObjectCollection<MNZExpectedVisitor> { }
                    
        public class ChildMNZExpectedVisitorCollection : TTObject.TTChildObjectCollection<MNZExpectedVisitor>
        {
            public ChildMNZExpectedVisitorCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMNZExpectedVisitorCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
    /// <summary>
    /// Onaylandı
    /// </summary>
            public static Guid Approved { get { return new Guid("bb3706cf-4e3e-40a3-a02f-500b19a5ed04"); } }
    /// <summary>
    /// Reddedildi
    /// </summary>
            public static Guid Denied { get { return new Guid("e3924957-2ae5-4a87-ab44-7d08a8e52809"); } }
            public static Guid Check { get { return new Guid("3c1d6e7b-8a62-44ad-9973-bfd295cdb9c9"); } }
            public static Guid New { get { return new Guid("26b97d92-e675-47d7-80ef-cb34bf93fb9a"); } }
        }

    /// <summary>
    /// Giriş Saati
    /// </summary>
        public DateTime? EntranceTime
        {
            get { return (DateTime?)this["ENTRANCETIME"]; }
            set { this["ENTRANCETIME"] = value; }
        }

    /// <summary>
    /// Onaylandımı
    /// </summary>
        public bool? IsConfirmed
        {
            get { return (bool?)this["ISCONFIRMED"]; }
            set { this["ISCONFIRMED"] = value; }
        }

    /// <summary>
    /// Ziyaret Saati
    /// </summary>
        public DateTime? VisitTime
        {
            get { return (DateTime?)this["VISITTIME"]; }
            set { this["VISITTIME"] = value; }
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
    /// Personel Beklenen Ziyaretçi
    /// </summary>
        public MNZPersonnel Personnel
        {
            get { return (MNZPersonnel)((ITTObject)this).GetParent("PERSONNEL"); }
            set { this["PERSONNEL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Ziyaret Sebebi
    /// </summary>
        public VisitReason VisitReason
        {
            get { return (VisitReason)((ITTObject)this).GetParent("VISITREASON"); }
            set { this["VISITREASON"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MNZExpectedVisitor(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MNZExpectedVisitor(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MNZExpectedVisitor(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MNZExpectedVisitor(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MNZExpectedVisitor(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MNZEXPECTEDVISITOR", dataRow) { }
        protected MNZExpectedVisitor(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MNZEXPECTEDVISITOR", dataRow, isImported) { }
        public MNZExpectedVisitor(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MNZExpectedVisitor(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MNZExpectedVisitor() : base() { }

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
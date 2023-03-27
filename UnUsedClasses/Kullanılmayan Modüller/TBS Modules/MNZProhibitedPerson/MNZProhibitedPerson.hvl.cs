
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MNZProhibitedPerson")] 

    /// <summary>
    /// Yasaklı Ziyaretçi
    /// </summary>
    public  partial class MNZProhibitedPerson : MNZPerson
    {
        public class MNZProhibitedPersonList : TTObjectCollection<MNZProhibitedPerson> { }
                    
        public class ChildMNZProhibitedPersonCollection : TTObject.TTChildObjectCollection<MNZProhibitedPerson>
        {
            public ChildMNZProhibitedPersonCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMNZProhibitedPersonCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
    /// <summary>
    /// Yeni Yasaklı Kişi kaydı
    /// </summary>
            public static Guid New { get { return new Guid("3f594524-0e01-4fed-9245-a06c3585400e"); } }
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Complete { get { return new Guid("9b0f8a6c-b964-4410-bba0-f9ce47aaf803"); } }
        }

    /// <summary>
    /// Yasaklanma Zamanı
    /// </summary>
        public DateTime? BannedDate
        {
            get { return (DateTime?)this["BANNEDDATE"]; }
            set { this["BANNEDDATE"] = value; }
        }

        protected MNZProhibitedPerson(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MNZProhibitedPerson(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MNZProhibitedPerson(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MNZProhibitedPerson(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MNZProhibitedPerson(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MNZPROHIBITEDPERSON", dataRow) { }
        protected MNZProhibitedPerson(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MNZPROHIBITEDPERSON", dataRow, isImported) { }
        public MNZProhibitedPerson(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MNZProhibitedPerson(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MNZProhibitedPerson() : base() { }

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
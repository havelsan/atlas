
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DiyabetTakip")] 

    /// <summary>
    /// Hastaya Ait Diyabet Takip Formları
    /// </summary>
    public  partial class DiyabetTakip : EpisodeAction
    {
        public class DiyabetTakipList : TTObjectCollection<DiyabetTakip> { }
                    
        public class ChildDiyabetTakipCollection : TTObject.TTChildObjectCollection<DiyabetTakip>
        {
            public ChildDiyabetTakipCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDiyabetTakipCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("d75c08fa-a778-4cd4-9af2-f4ef7d343895"); } }
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("9b713f45-f784-42fa-a4c6-7a3a14975383"); } }
        }

        public DiabetesMellitusPursuit DiabetesMellitusPursuit
        {
            get { return (DiabetesMellitusPursuit)((ITTObject)this).GetParent("DIABETESMELLITUSPURSUIT"); }
            set { this["DIABETESMELLITUSPURSUIT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected DiyabetTakip(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DiyabetTakip(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DiyabetTakip(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DiyabetTakip(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DiyabetTakip(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DIYABETTAKIP", dataRow) { }
        protected DiyabetTakip(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DIYABETTAKIP", dataRow, isImported) { }
        public DiyabetTakip(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DiyabetTakip(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DiyabetTakip() : base() { }

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
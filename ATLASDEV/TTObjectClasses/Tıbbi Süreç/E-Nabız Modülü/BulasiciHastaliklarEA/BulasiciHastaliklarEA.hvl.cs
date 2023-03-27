
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BulasiciHastaliklarEA")] 

    /// <summary>
    /// Bildirimi Zorunlu Bulaşıcı Hastalıklar
    /// </summary>
    public  partial class BulasiciHastaliklarEA : EpisodeAction, IWorkListEpisodeAction
    {
        public class BulasiciHastaliklarEAList : TTObjectCollection<BulasiciHastaliklarEA> { }
                    
        public class ChildBulasiciHastaliklarEACollection : TTObject.TTChildObjectCollection<BulasiciHastaliklarEA>
        {
            public ChildBulasiciHastaliklarEACollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBulasiciHastaliklarEACollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid Approved { get { return new Guid("701dc682-3a9e-4620-83f4-e855eeab4ed5"); } }
            public static Guid New { get { return new Guid("1cd4c112-dec9-42b0-968e-db4ef94da338"); } }
            public static Guid Cancelled { get { return new Guid("db1b6c3b-c755-493d-9569-8b1a61412337"); } }
        }

        public BulasiciHastalikVeriSeti BulasiciHastalikVeriSeti
        {
            get { return (BulasiciHastalikVeriSeti)((ITTObject)this).GetParent("BULASICIHASTALIKVERISETI"); }
            set { this["BULASICIHASTALIKVERISETI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected BulasiciHastaliklarEA(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BulasiciHastaliklarEA(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BulasiciHastaliklarEA(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BulasiciHastaliklarEA(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BulasiciHastaliklarEA(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BULASICIHASTALIKLAREA", dataRow) { }
        protected BulasiciHastaliklarEA(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BULASICIHASTALIKLAREA", dataRow, isImported) { }
        public BulasiciHastaliklarEA(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BulasiciHastaliklarEA(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BulasiciHastaliklarEA() : base() { }

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
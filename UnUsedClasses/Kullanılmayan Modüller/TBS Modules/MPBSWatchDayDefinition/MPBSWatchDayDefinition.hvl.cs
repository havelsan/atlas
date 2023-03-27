
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MPBSWatchDayDefinition")] 

    /// <summary>
    /// Nöbet Günü Tanımlama
    /// </summary>
    public  partial class MPBSWatchDayDefinition : TTDefinitionSet
    {
        public class MPBSWatchDayDefinitionList : TTObjectCollection<MPBSWatchDayDefinition> { }
                    
        public class ChildMPBSWatchDayDefinitionCollection : TTObject.TTChildObjectCollection<MPBSWatchDayDefinition>
        {
            public ChildMPBSWatchDayDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMPBSWatchDayDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid Completed { get { return new Guid("a165feab-6a52-4ab4-b3a8-061660e2bb55"); } }
            public static Guid New { get { return new Guid("67d046b1-3c9f-433c-8352-e16a00d1e129"); } }
        }

    /// <summary>
    /// Nöbet Gün Türü
    /// </summary>
        public MPBSWatchDayTypeEnum? Type
        {
            get { return (MPBSWatchDayTypeEnum?)(int?)this["TYPE"]; }
            set { this["TYPE"] = value; }
        }

    /// <summary>
    /// İki Nöbet Arası Minimum Süre
    /// </summary>
        public int? MinimumOffset
        {
            get { return (int?)this["MINIMUMOFFSET"]; }
            set { this["MINIMUMOFFSET"] = value; }
        }

    /// <summary>
    /// Kontrol Edilecek Gün Sayısı
    /// </summary>
        public int? DaysToBeChecked
        {
            get { return (int?)this["DAYSTOBECHECKED"]; }
            set { this["DAYSTOBECHECKED"] = value; }
        }

        protected MPBSWatchDayDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MPBSWatchDayDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MPBSWatchDayDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MPBSWatchDayDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MPBSWatchDayDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MPBSWATCHDAYDEFINITION", dataRow) { }
        protected MPBSWatchDayDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MPBSWATCHDAYDEFINITION", dataRow, isImported) { }
        public MPBSWatchDayDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MPBSWatchDayDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MPBSWatchDayDefinition() : base() { }

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
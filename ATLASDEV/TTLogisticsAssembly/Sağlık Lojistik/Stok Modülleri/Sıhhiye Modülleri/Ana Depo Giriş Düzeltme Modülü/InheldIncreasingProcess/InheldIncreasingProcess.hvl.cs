
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="InheldIncreasingProcess")] 

    /// <summary>
    /// Satınalma Mevcut Arttırma İşlemi
    /// </summary>
    public  partial class InheldIncreasingProcess : EntryCorrectionProcess
    {
        public class InheldIncreasingProcessList : TTObjectCollection<InheldIncreasingProcess> { }
                    
        public class ChildInheldIncreasingProcessCollection : TTObject.TTChildObjectCollection<InheldIncreasingProcess>
        {
            public ChildInheldIncreasingProcessCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildInheldIncreasingProcessCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancelled { get { return new Guid("07af649f-0738-4748-9035-ec15c7a82c65"); } }
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("6c67aca2-9b25-463b-98aa-18a7cf9b6c26"); } }
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("4719aa6f-900a-4ba8-9700-1e1ad0b27049"); } }
        }

        override protected void CreateStockActionDetailsCollectionViews()
        {
            base.CreateStockActionDetailsCollectionViews();
            _InheldIncreasingProcessDets = new InheldIncreasingProcessDet.ChildInheldIncreasingProcessDetCollection(_StockActionDetails, "InheldIncreasingProcessDets");
        }

        private InheldIncreasingProcessDet.ChildInheldIncreasingProcessDetCollection _InheldIncreasingProcessDets = null;
    /// <summary>
    /// Alt İşlemler
    /// </summary>
        public InheldIncreasingProcessDet.ChildInheldIncreasingProcessDetCollection InheldIncreasingProcessDets
        {
            get
            {
                if (_StockActionDetails == null)
                    CreateStockActionDetailsCollection();
                return _InheldIncreasingProcessDets;
            }            
        }

        protected InheldIncreasingProcess(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected InheldIncreasingProcess(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected InheldIncreasingProcess(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected InheldIncreasingProcess(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected InheldIncreasingProcess(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "INHELDINCREASINGPROCESS", dataRow) { }
        protected InheldIncreasingProcess(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "INHELDINCREASINGPROCESS", dataRow, isImported) { }
        public InheldIncreasingProcess(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public InheldIncreasingProcess(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public InheldIncreasingProcess() : base() { }

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
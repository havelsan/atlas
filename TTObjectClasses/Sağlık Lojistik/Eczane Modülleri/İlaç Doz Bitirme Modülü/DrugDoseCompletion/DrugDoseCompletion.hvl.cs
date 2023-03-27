
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DrugDoseCompletion")] 

    /// <summary>
    /// İlaç Doz Bitirme
    /// </summary>
    public  partial class DrugDoseCompletion : EpisodeAction
    {
        public class DrugDoseCompletionList : TTObjectCollection<DrugDoseCompletion> { }
                    
        public class ChildDrugDoseCompletionCollection : TTObject.TTChildObjectCollection<DrugDoseCompletion>
        {
            public ChildDrugDoseCompletionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDrugDoseCompletionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
    /// <summary>
    /// Tamam
    /// </summary>
            public static Guid Completed { get { return new Guid("3d022ff8-eae7-425b-801f-889c24ffe087"); } }
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("15211637-18c2-4eb5-90e4-6aa9240a5b20"); } }
        }

        virtual protected void CreateDrugDoseCompletionDetailsCollection()
        {
            _DrugDoseCompletionDetails = new DrugDoseCompletionDetail.ChildDrugDoseCompletionDetailCollection(this, new Guid("b484c367-b3a4-4307-ad59-2c789dec316e"));
            ((ITTChildObjectCollection)_DrugDoseCompletionDetails).GetChildren();
        }

        protected DrugDoseCompletionDetail.ChildDrugDoseCompletionDetailCollection _DrugDoseCompletionDetails = null;
        public DrugDoseCompletionDetail.ChildDrugDoseCompletionDetailCollection DrugDoseCompletionDetails
        {
            get
            {
                if (_DrugDoseCompletionDetails == null)
                    CreateDrugDoseCompletionDetailsCollection();
                return _DrugDoseCompletionDetails;
            }
        }

        protected DrugDoseCompletion(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DrugDoseCompletion(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DrugDoseCompletion(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DrugDoseCompletion(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DrugDoseCompletion(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DRUGDOSECOMPLETION", dataRow) { }
        protected DrugDoseCompletion(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DRUGDOSECOMPLETION", dataRow, isImported) { }
        public DrugDoseCompletion(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DrugDoseCompletion(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DrugDoseCompletion() : base() { }

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
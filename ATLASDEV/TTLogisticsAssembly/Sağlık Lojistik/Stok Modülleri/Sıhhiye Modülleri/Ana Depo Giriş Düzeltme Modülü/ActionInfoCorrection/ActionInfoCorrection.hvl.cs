
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ActionInfoCorrection")] 

    /// <summary>
    /// Fatura İşlem Düzeltme Belgesi
    /// </summary>
    public  partial class ActionInfoCorrection : EntryCorrectionProcess
    {
        public class ActionInfoCorrectionList : TTObjectCollection<ActionInfoCorrection> { }
                    
        public class ChildActionInfoCorrectionCollection : TTObject.TTChildObjectCollection<ActionInfoCorrection>
        {
            public ChildActionInfoCorrectionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildActionInfoCorrectionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancelled { get { return new Guid("c9bd1b69-8de3-4319-a11e-b7c08cb4d60b"); } }
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("8c378971-2ac1-4a84-88ac-fb3bff43f5ed"); } }
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("3fb1ad9a-7f3a-4628-ae1b-9d2d04286d39"); } }
        }

        override protected void CreateStockActionDetailsCollectionViews()
        {
            base.CreateStockActionDetailsCollectionViews();
            _ActionInfoCorrectionDets = new ActionInfoCorrectionDet.ChildActionInfoCorrectionDetCollection(_StockActionDetails, "ActionInfoCorrectionDets");
        }

        private ActionInfoCorrectionDet.ChildActionInfoCorrectionDetCollection _ActionInfoCorrectionDets = null;
    /// <summary>
    /// Alt İşlemler
    /// </summary>
        public ActionInfoCorrectionDet.ChildActionInfoCorrectionDetCollection ActionInfoCorrectionDets
        {
            get
            {
                if (_StockActionDetails == null)
                    CreateStockActionDetailsCollection();
                return _ActionInfoCorrectionDets;
            }            
        }

        protected ActionInfoCorrection(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ActionInfoCorrection(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ActionInfoCorrection(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ActionInfoCorrection(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ActionInfoCorrection(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ACTIONINFOCORRECTION", dataRow) { }
        protected ActionInfoCorrection(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ACTIONINFOCORRECTION", dataRow, isImported) { }
        public ActionInfoCorrection(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ActionInfoCorrection(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ActionInfoCorrection() : base() { }

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
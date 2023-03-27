
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PresDistributeUpdate")] 

    /// <summary>
    /// Reçete Dağıtım Düzeltme
    /// </summary>
    public  partial class PresDistributeUpdate : BaseAction, IWorkListBaseAction
    {
        public class PresDistributeUpdateList : TTObjectCollection<PresDistributeUpdate> { }
                    
        public class ChildPresDistributeUpdateCollection : TTObject.TTChildObjectCollection<PresDistributeUpdate>
        {
            public ChildPresDistributeUpdateCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPresDistributeUpdateCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("ca6fe5b4-34fb-4602-a05c-a30a067d0d96"); } }
    /// <summary>
    /// Onay
    /// </summary>
            public static Guid Approval { get { return new Guid("dd43eda8-069a-4e88-a96f-28dd8fdee404"); } }
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("25e1396b-3b03-48a7-8a62-cef38de3b6a4"); } }
    /// <summary>
    /// İptal Edildi
    /// </summary>
            public static Guid Cancel { get { return new Guid("688160a8-48bd-412f-9d30-90a503399481"); } }
        }

    /// <summary>
    /// Reçete Dağıtım Numarası 
    /// </summary>
        public int? DistributeID
        {
            get { return (int?)this["DISTRIBUTEID"]; }
            set { this["DISTRIBUTEID"] = value; }
        }

        public PrescriptionDistribute PrescriptionDistribute
        {
            get { return (PrescriptionDistribute)((ITTObject)this).GetParent("PRESCRIPTIONDISTRIBUTE"); }
            set { this["PRESCRIPTIONDISTRIBUTE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreatePresDistributeUpdateDetailsCollection()
        {
            _PresDistributeUpdateDetails = new PresDistributeUpdateDetail.ChildPresDistributeUpdateDetailCollection(this, new Guid("1b1e492e-9525-4d36-a4ad-cefdff22603b"));
            ((ITTChildObjectCollection)_PresDistributeUpdateDetails).GetChildren();
        }

        protected PresDistributeUpdateDetail.ChildPresDistributeUpdateDetailCollection _PresDistributeUpdateDetails = null;
        public PresDistributeUpdateDetail.ChildPresDistributeUpdateDetailCollection PresDistributeUpdateDetails
        {
            get
            {
                if (_PresDistributeUpdateDetails == null)
                    CreatePresDistributeUpdateDetailsCollection();
                return _PresDistributeUpdateDetails;
            }
        }

        protected PresDistributeUpdate(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PresDistributeUpdate(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PresDistributeUpdate(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PresDistributeUpdate(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PresDistributeUpdate(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PRESDISTRIBUTEUPDATE", dataRow) { }
        protected PresDistributeUpdate(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PRESDISTRIBUTEUPDATE", dataRow, isImported) { }
        public PresDistributeUpdate(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PresDistributeUpdate(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PresDistributeUpdate() : base() { }

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
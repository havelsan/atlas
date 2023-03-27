
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="CreatePresDetailAction")] 

    public  partial class CreatePresDetailAction : BaseAction, IWorkListBaseAction
    {
        public class CreatePresDetailActionList : TTObjectCollection<CreatePresDetailAction> { }
                    
        public class ChildCreatePresDetailActionCollection : TTObject.TTChildObjectCollection<CreatePresDetailAction>
        {
            public ChildCreatePresDetailActionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildCreatePresDetailActionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("63d7b4d2-39bf-4fcb-a18e-33ecfe2b8be7"); } }
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("56e2b46c-2d75-49a5-9262-fae99e49a6fd"); } }
        }

    /// <summary>
    /// Miktar
    /// </summary>
        public Currency? Amount
        {
            get { return (Currency?)this["AMOUNT"]; }
            set { this["AMOUNT"] = value; }
        }

        public MainStoreDefinition MainStoreDefinition
        {
            get { return (MainStoreDefinition)((ITTObject)this).GetParent("MAINSTOREDEFINITION"); }
            set { this["MAINSTOREDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Material Material
        {
            get { return (Material)((ITTObject)this).GetParent("MATERIAL"); }
            set { this["MATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreatePrescriptionPaperInDetailsCollection()
        {
            _PrescriptionPaperInDetails = new PrescriptionPaperInDetail.ChildPrescriptionPaperInDetailCollection(this, new Guid("d4fe7163-3eed-419c-a8ca-b9d094d74f3c"));
            ((ITTChildObjectCollection)_PrescriptionPaperInDetails).GetChildren();
        }

        protected PrescriptionPaperInDetail.ChildPrescriptionPaperInDetailCollection _PrescriptionPaperInDetails = null;
        public PrescriptionPaperInDetail.ChildPrescriptionPaperInDetailCollection PrescriptionPaperInDetails
        {
            get
            {
                if (_PrescriptionPaperInDetails == null)
                    CreatePrescriptionPaperInDetailsCollection();
                return _PrescriptionPaperInDetails;
            }
        }

        virtual protected void CreatePresActionDetailsCollection()
        {
            _PresActionDetails = new PresActionDetail.ChildPresActionDetailCollection(this, new Guid("20cf12cd-d303-4037-afd0-7d4a448590f7"));
            ((ITTChildObjectCollection)_PresActionDetails).GetChildren();
        }

        protected PresActionDetail.ChildPresActionDetailCollection _PresActionDetails = null;
        public PresActionDetail.ChildPresActionDetailCollection PresActionDetails
        {
            get
            {
                if (_PresActionDetails == null)
                    CreatePresActionDetailsCollection();
                return _PresActionDetails;
            }
        }

        protected CreatePresDetailAction(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected CreatePresDetailAction(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected CreatePresDetailAction(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected CreatePresDetailAction(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected CreatePresDetailAction(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "CREATEPRESDETAILACTION", dataRow) { }
        protected CreatePresDetailAction(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "CREATEPRESDETAILACTION", dataRow, isImported) { }
        public CreatePresDetailAction(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public CreatePresDetailAction(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public CreatePresDetailAction() : base() { }

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
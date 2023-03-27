
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="UpdateRespUserAction")] 

    /// <summary>
    /// Personel Güncelleme
    /// </summary>
    public  partial class UpdateRespUserAction : BaseAction, IWorkListBaseAction
    {
        public class UpdateRespUserActionList : TTObjectCollection<UpdateRespUserAction> { }
                    
        public class ChildUpdateRespUserActionCollection : TTObject.TTChildObjectCollection<UpdateRespUserAction>
        {
            public ChildUpdateRespUserActionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildUpdateRespUserActionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("492745f4-1a8d-4c43-8795-71c8790f906f"); } }
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("0f46ed8a-16fa-4e82-9627-a1b9e0588e42"); } }
        }

        public ResUser ResponsibleUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("RESPONSIBLEUSER"); }
            set { this["RESPONSIBLEUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ResUser UpdateUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("UPDATEUSER"); }
            set { this["UPDATEUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateUpdateRespUserActionDetailsCollection()
        {
            _UpdateRespUserActionDetails = new UpdateRespUserActionDetail.ChildUpdateRespUserActionDetailCollection(this, new Guid("2f0ef0e0-c00c-4032-826a-90f5140662fd"));
            ((ITTChildObjectCollection)_UpdateRespUserActionDetails).GetChildren();
        }

        protected UpdateRespUserActionDetail.ChildUpdateRespUserActionDetailCollection _UpdateRespUserActionDetails = null;
        public UpdateRespUserActionDetail.ChildUpdateRespUserActionDetailCollection UpdateRespUserActionDetails
        {
            get
            {
                if (_UpdateRespUserActionDetails == null)
                    CreateUpdateRespUserActionDetailsCollection();
                return _UpdateRespUserActionDetails;
            }
        }

        protected UpdateRespUserAction(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected UpdateRespUserAction(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected UpdateRespUserAction(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected UpdateRespUserAction(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected UpdateRespUserAction(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "UPDATERESPUSERACTION", dataRow) { }
        protected UpdateRespUserAction(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "UPDATERESPUSERACTION", dataRow, isImported) { }
        public UpdateRespUserAction(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public UpdateRespUserAction(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public UpdateRespUserAction() : base() { }

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

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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="CMRActionConsCancel")] 

    /// <summary>
    /// Onarım Sarf Girişi İptali
    /// </summary>
    public  partial class CMRActionConsCancel : BaseAction, IWorkListBaseAction
    {
        public class CMRActionConsCancelList : TTObjectCollection<CMRActionConsCancel> { }
                    
        public class ChildCMRActionConsCancelCollection : TTObject.TTChildObjectCollection<CMRActionConsCancel>
        {
            public ChildCMRActionConsCancelCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildCMRActionConsCancelCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("f7dc7053-fc2a-4e9f-bcb8-8dce607fb323"); } }
    /// <summary>
    /// Tamalandı
    /// </summary>
            public static Guid Completed { get { return new Guid("2bb75665-2f4e-490e-92d8-127e3dd1eef0"); } }
    /// <summary>
    /// İptal Edildi
    /// </summary>
            public static Guid Cancelled { get { return new Guid("02be2b38-eb9a-4c29-acf5-647f440b44bd"); } }
        }

    /// <summary>
    /// İşlem No
    /// </summary>
        public string CMRActionRequestNo
        {
            get { return (string)this["CMRACTIONREQUESTNO"]; }
            set { this["CMRACTIONREQUESTNO"] = value; }
        }

    /// <summary>
    /// İşlem Açıklaması
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

        public CMRAction CMRAction
        {
            get { return (CMRAction)((ITTObject)this).GetParent("CMRACTION"); }
            set { this["CMRACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateCMRActionConsCancelDetailsCollection()
        {
            _CMRActionConsCancelDetails = new CMRActionConsCancelDetail.ChildCMRActionConsCancelDetailCollection(this, new Guid("6b474319-537d-4ad2-9584-66aee0d41361"));
            ((ITTChildObjectCollection)_CMRActionConsCancelDetails).GetChildren();
        }

        protected CMRActionConsCancelDetail.ChildCMRActionConsCancelDetailCollection _CMRActionConsCancelDetails = null;
        public CMRActionConsCancelDetail.ChildCMRActionConsCancelDetailCollection CMRActionConsCancelDetails
        {
            get
            {
                if (_CMRActionConsCancelDetails == null)
                    CreateCMRActionConsCancelDetailsCollection();
                return _CMRActionConsCancelDetails;
            }
        }

        protected CMRActionConsCancel(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected CMRActionConsCancel(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected CMRActionConsCancel(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected CMRActionConsCancel(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected CMRActionConsCancel(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "CMRACTIONCONSCANCEL", dataRow) { }
        protected CMRActionConsCancel(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "CMRACTIONCONSCANCEL", dataRow, isImported) { }
        public CMRActionConsCancel(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public CMRActionConsCancel(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public CMRActionConsCancel() : base() { }

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
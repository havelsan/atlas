
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SterilizationRequest")] 

    /// <summary>
    /// Sterilizasyon İstek
    /// </summary>
    public  partial class SterilizationRequest : BaseAction
    {
        public class SterilizationRequestList : TTObjectCollection<SterilizationRequest> { }
                    
        public class ChildSterilizationRequestCollection : TTObject.TTChildObjectCollection<SterilizationRequest>
        {
            public ChildSterilizationRequestCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSterilizationRequestCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid New { get { return new Guid("9a9d0d72-e1e9-4613-92ed-309300aa9b01"); } }
            public static Guid Complated { get { return new Guid("60ee13a5-c0b2-4947-a406-342042832e22"); } }
        }

    /// <summary>
    /// İstek Tarihi
    /// </summary>
        public DateTime? RequestDate
        {
            get { return (DateTime?)this["REQUESTDATE"]; }
            set { this["REQUESTDATE"] = value; }
        }

        public ResSection RequestResource
        {
            get { return (ResSection)((ITTObject)this).GetParent("REQUESTRESOURCE"); }
            set { this["REQUESTRESOURCE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ResSection SterilizationUnit
        {
            get { return (ResSection)((ITTObject)this).GetParent("STERILIZATIONUNIT"); }
            set { this["STERILIZATIONUNIT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ResUser RequestUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("REQUESTUSER"); }
            set { this["REQUESTUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateSterilizationHistoriesCollection()
        {
            _SterilizationHistories = new SterilizationHistory.ChildSterilizationHistoryCollection(this, new Guid("0aa0c204-006c-40e6-8964-88ebfcd17dc2"));
            ((ITTChildObjectCollection)_SterilizationHistories).GetChildren();
        }

        protected SterilizationHistory.ChildSterilizationHistoryCollection _SterilizationHistories = null;
        public SterilizationHistory.ChildSterilizationHistoryCollection SterilizationHistories
        {
            get
            {
                if (_SterilizationHistories == null)
                    CreateSterilizationHistoriesCollection();
                return _SterilizationHistories;
            }
        }

        protected SterilizationRequest(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SterilizationRequest(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SterilizationRequest(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SterilizationRequest(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SterilizationRequest(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "STERILIZATIONREQUEST", dataRow) { }
        protected SterilizationRequest(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "STERILIZATIONREQUEST", dataRow, isImported) { }
        public SterilizationRequest(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SterilizationRequest(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SterilizationRequest() : base() { }

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
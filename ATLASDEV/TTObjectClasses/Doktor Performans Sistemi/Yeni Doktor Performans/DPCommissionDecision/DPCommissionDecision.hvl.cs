
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DPCommissionDecision")] 

    public  partial class DPCommissionDecision : TTObject
    {
        public class DPCommissionDecisionList : TTObjectCollection<DPCommissionDecision> { }
                    
        public class ChildDPCommissionDecisionCollection : TTObject.TTChildObjectCollection<DPCommissionDecision>
        {
            public ChildDPCommissionDecisionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDPCommissionDecisionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("2ad88966-9340-40fa-a452-e251e3d6a00c"); } }
    /// <summary>
    /// Onaylı
    /// </summary>
            public static Guid Approval { get { return new Guid("e467b6cb-d0f3-4dfa-96f6-3b43d5b7eb52"); } }
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancel { get { return new Guid("424eeb49-742c-4c5a-ac1e-f6795aa90a64"); } }
        }

        public DateTime? Date
        {
            get { return (DateTime?)this["DATE"]; }
            set { this["DATE"] = value; }
        }

        public object Decision
        {
            get { return (object)this["DECISION"]; }
            set { this["DECISION"] = value; }
        }

        public DateTime? CreateDate
        {
            get { return (DateTime?)this["CREATEDATE"]; }
            set { this["CREATEDATE"] = value; }
        }

        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        public ResUser CreateUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("CREATEUSER"); }
            set { this["CREATEUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public DoctorPerformanceTerm Term
        {
            get { return (DoctorPerformanceTerm)((ITTObject)this).GetParent("TERM"); }
            set { this["TERM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateDPCommissionMembersCollection()
        {
            _DPCommissionMembers = new DPCommissionMember.ChildDPCommissionMemberCollection(this, new Guid("5276971e-3df3-4958-ba72-5020912430bb"));
            ((ITTChildObjectCollection)_DPCommissionMembers).GetChildren();
        }

        protected DPCommissionMember.ChildDPCommissionMemberCollection _DPCommissionMembers = null;
        public DPCommissionMember.ChildDPCommissionMemberCollection DPCommissionMembers
        {
            get
            {
                if (_DPCommissionMembers == null)
                    CreateDPCommissionMembersCollection();
                return _DPCommissionMembers;
            }
        }

        protected DPCommissionDecision(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DPCommissionDecision(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DPCommissionDecision(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DPCommissionDecision(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DPCommissionDecision(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DPCOMMISSIONDECISION", dataRow) { }
        protected DPCommissionDecision(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DPCOMMISSIONDECISION", dataRow, isImported) { }
        public DPCommissionDecision(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DPCommissionDecision(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DPCommissionDecision() : base() { }

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
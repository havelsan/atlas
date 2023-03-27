
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="GroupSumProposal")] 

    /// <summary>
    /// İhaledeki Her Grup İçin O Gruba Firmanın Verdiği Grup Toplam Tekliflerinin Tutulduğu Sınıftır
    /// </summary>
    public  partial class GroupSumProposal : TTObject
    {
        public class GroupSumProposalList : TTObjectCollection<GroupSumProposal> { }
                    
        public class ChildGroupSumProposalCollection : TTObject.TTChildObjectCollection<GroupSumProposal>
        {
            public ChildGroupSumProposalCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildGroupSumProposalCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancelled { get { return new Guid("82ea6900-cbec-407e-8b70-0f6ffcfa5a33"); } }
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("eb4a24db-b0a8-44f1-ab43-87f40eca567d"); } }
        }

    /// <summary>
    /// Durumu
    /// </summary>
        public ProposalDetailStatusEnum? Status
        {
            get { return (ProposalDetailStatusEnum?)(int?)this["STATUS"]; }
            set { this["STATUS"] = value; }
        }

    /// <summary>
    /// Toplam Teklif
    /// </summary>
        public double? TotalProposalPrice
        {
            get { return (double?)this["TOTALPROPOSALPRICE"]; }
            set { this["TOTALPROPOSALPRICE"] = value; }
        }

        public PurchaseProjectGroup PurchaseProjectGroup
        {
            get { return (PurchaseProjectGroup)((ITTObject)this).GetParent("PURCHASEPROJECTGROUP"); }
            set { this["PURCHASEPROJECTGROUP"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Supplier Supplier
        {
            get { return (Supplier)((ITTObject)this).GetParent("SUPPLIER"); }
            set { this["SUPPLIER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected GroupSumProposal(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected GroupSumProposal(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected GroupSumProposal(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected GroupSumProposal(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected GroupSumProposal(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "GROUPSUMPROPOSAL", dataRow) { }
        protected GroupSumProposal(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "GROUPSUMPROPOSAL", dataRow, isImported) { }
        public GroupSumProposal(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public GroupSumProposal(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public GroupSumProposal() : base() { }

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
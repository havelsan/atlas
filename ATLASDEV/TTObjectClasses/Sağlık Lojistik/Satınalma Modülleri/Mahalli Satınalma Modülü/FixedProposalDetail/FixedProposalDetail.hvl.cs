
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="FixedProposalDetail")] 

    /// <summary>
    /// Karar Düzeltme Yapılmış İhale Kalemlerinde, Düzeltme Bilgilerinin Tutulduğu Sınıftır
    /// </summary>
    public  partial class FixedProposalDetail : TTObject
    {
        public class FixedProposalDetailList : TTObjectCollection<FixedProposalDetail> { }
                    
        public class ChildFixedProposalDetailCollection : TTObject.TTChildObjectCollection<FixedProposalDetail>
        {
            public ChildFixedProposalDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildFixedProposalDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("67994333-4f30-44a6-88e9-63c2e98cf9a7"); } }
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancelled { get { return new Guid("103cd4db-9bde-4d81-a5aa-71c023bd1e3c"); } }
        }

    /// <summary>
    /// Yeni Fiyat
    /// </summary>
        public double? FixedPrice
        {
            get { return (double?)this["FIXEDPRICE"]; }
            set { this["FIXEDPRICE"] = value; }
        }

    /// <summary>
    /// Eski Fiyat
    /// </summary>
        public double? OldPrice
        {
            get { return (double?)this["OLDPRICE"]; }
            set { this["OLDPRICE"] = value; }
        }

    /// <summary>
    /// İptal
    /// </summary>
        public bool? Deny
        {
            get { return (bool?)this["DENY"]; }
            set { this["DENY"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

        public PurchaseProject PurchaseProject
        {
            get { return (PurchaseProject)((ITTObject)this).GetParent("PURCHASEPROJECT"); }
            set { this["PURCHASEPROJECT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ProposalDetail ProposalDetail
        {
            get { return (ProposalDetail)((ITTObject)this).GetParent("PROPOSALDETAIL"); }
            set { this["PROPOSALDETAIL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected FixedProposalDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected FixedProposalDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected FixedProposalDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected FixedProposalDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected FixedProposalDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "FIXEDPROPOSALDETAIL", dataRow) { }
        protected FixedProposalDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "FIXEDPROPOSALDETAIL", dataRow, isImported) { }
        public FixedProposalDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public FixedProposalDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public FixedProposalDetail() : base() { }

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
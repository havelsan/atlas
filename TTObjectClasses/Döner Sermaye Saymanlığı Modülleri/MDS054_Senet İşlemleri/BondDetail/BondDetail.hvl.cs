
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BondDetail")] 

    public  partial class BondDetail : TTObject
    {
        public class BondDetailList : TTObjectCollection<BondDetail> { }
                    
        public class ChildBondDetailCollection : TTObject.TTChildObjectCollection<BondDetail>
        {
            public ChildBondDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBondDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
    /// <summary>
    /// Ödenmedi
    /// </summary>
            public static Guid New { get { return new Guid("35cc5a53-b74b-48e0-90b5-b815bf8bf199"); } }
    /// <summary>
    /// Ödendi
    /// </summary>
            public static Guid Paid { get { return new Guid("5f6bdcae-52e0-4902-8572-2d771f4e9247"); } }
        }

    /// <summary>
    /// Vade Tarihi
    /// </summary>
        public DateTime? Date
        {
            get { return (DateTime?)this["DATE"]; }
            set { this["DATE"] = value; }
        }

    /// <summary>
    /// Vade Tutarı
    /// </summary>
        public Currency? Price
        {
            get { return (Currency?)this["PRICE"]; }
            set { this["PRICE"] = value; }
        }

    /// <summary>
    /// Ödeme Tarihi
    /// </summary>
        public DateTime? PaymentDate
        {
            get { return (DateTime?)this["PAYMENTDATE"]; }
            set { this["PAYMENTDATE"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

        public Bond Bond
        {
            get { return (Bond)((ITTObject)this).GetParent("BOND"); }
            set { this["BOND"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateBondPaymentDetailsCollection()
        {
            _BondPaymentDetails = new BondPaymentDetail.ChildBondPaymentDetailCollection(this, new Guid("4eff7a02-0e56-4970-aef1-1b50f6dc320e"));
            ((ITTChildObjectCollection)_BondPaymentDetails).GetChildren();
        }

        protected BondPaymentDetail.ChildBondPaymentDetailCollection _BondPaymentDetails = null;
        public BondPaymentDetail.ChildBondPaymentDetailCollection BondPaymentDetails
        {
            get
            {
                if (_BondPaymentDetails == null)
                    CreateBondPaymentDetailsCollection();
                return _BondPaymentDetails;
            }
        }

        protected BondDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BondDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BondDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BondDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BondDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BONDDETAIL", dataRow) { }
        protected BondDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BONDDETAIL", dataRow, isImported) { }
        public BondDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BondDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BondDetail() : base() { }

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
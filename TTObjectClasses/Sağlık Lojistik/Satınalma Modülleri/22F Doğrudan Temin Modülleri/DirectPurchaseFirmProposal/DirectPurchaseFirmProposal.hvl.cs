
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DirectPurchaseFirmProposal")] 

    /// <summary>
    /// Doğrudan Temin Teklifi Veren Firma
    /// </summary>
    public  partial class DirectPurchaseFirmProposal : TTObject
    {
        public class DirectPurchaseFirmProposalList : TTObjectCollection<DirectPurchaseFirmProposal> { }
                    
        public class ChildDirectPurchaseFirmProposalCollection : TTObject.TTChildObjectCollection<DirectPurchaseFirmProposal>
        {
            public ChildDirectPurchaseFirmProposalCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDirectPurchaseFirmProposalCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Firma Adresi
    /// </summary>
        public string FirmAddress
        {
            get { return (string)this["FIRMADDRESS"]; }
            set { this["FIRMADDRESS"] = value; }
        }

    /// <summary>
    /// Fatura Tarihi
    /// </summary>
        public DateTime? InvoiceDate
        {
            get { return (DateTime?)this["INVOICEDATE"]; }
            set { this["INVOICEDATE"] = value; }
        }

    /// <summary>
    /// Fatura Sayısı
    /// </summary>
        public string InvoiceNumber
        {
            get { return (string)this["INVOICENUMBER"]; }
            set { this["INVOICENUMBER"] = value; }
        }

    /// <summary>
    /// İrsaliye Tarihi
    /// </summary>
        public DateTime? DeliveryDate
        {
            get { return (DateTime?)this["DELIVERYDATE"]; }
            set { this["DELIVERYDATE"] = value; }
        }

    /// <summary>
    /// İrsaliye No
    /// </summary>
        public string DeliveryNumber
        {
            get { return (string)this["DELIVERYNUMBER"]; }
            set { this["DELIVERYNUMBER"] = value; }
        }

        public FirmDefinition Firm
        {
            get { return (FirmDefinition)((ITTObject)this).GetParent("FIRM"); }
            set { this["FIRM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public DirectPurchaseAction DirectPurchaseAction
        {
            get { return (DirectPurchaseAction)((ITTObject)this).GetParent("DIRECTPURCHASEACTION"); }
            set { this["DIRECTPURCHASEACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateDPADetailFirmPriceOffersCollection()
        {
            _DPADetailFirmPriceOffers = new DPADetailFirmPriceOffer.ChildDPADetailFirmPriceOfferCollection(this, new Guid("bf648301-900a-430e-bde8-77f45c92e071"));
            ((ITTChildObjectCollection)_DPADetailFirmPriceOffers).GetChildren();
        }

        protected DPADetailFirmPriceOffer.ChildDPADetailFirmPriceOfferCollection _DPADetailFirmPriceOffers = null;
        public DPADetailFirmPriceOffer.ChildDPADetailFirmPriceOfferCollection DPADetailFirmPriceOffers
        {
            get
            {
                if (_DPADetailFirmPriceOffers == null)
                    CreateDPADetailFirmPriceOffersCollection();
                return _DPADetailFirmPriceOffers;
            }
        }

        protected DirectPurchaseFirmProposal(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DirectPurchaseFirmProposal(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DirectPurchaseFirmProposal(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DirectPurchaseFirmProposal(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DirectPurchaseFirmProposal(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DIRECTPURCHASEFIRMPROPOSAL", dataRow) { }
        protected DirectPurchaseFirmProposal(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DIRECTPURCHASEFIRMPROPOSAL", dataRow, isImported) { }
        public DirectPurchaseFirmProposal(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DirectPurchaseFirmProposal(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DirectPurchaseFirmProposal() : base() { }

    }
}
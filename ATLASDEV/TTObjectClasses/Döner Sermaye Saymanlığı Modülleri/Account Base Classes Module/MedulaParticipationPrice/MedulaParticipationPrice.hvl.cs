
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MedulaParticipationPrice")] 

    /// <summary>
    /// Medula Katılım Payı Ücreti
    /// </summary>
    public  partial class MedulaParticipationPrice : TTObject
    {
        public class MedulaParticipationPriceList : TTObjectCollection<MedulaParticipationPrice> { }
                    
        public class ChildMedulaParticipationPriceCollection : TTObject.TTChildObjectCollection<MedulaParticipationPrice>
        {
            public ChildMedulaParticipationPriceCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMedulaParticipationPriceCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// İşlem Tarihi
    /// </summary>
        public DateTime? ActionDate
        {
            get { return (DateTime?)this["ACTIONDATE"]; }
            set { this["ACTIONDATE"] = value; }
        }

    /// <summary>
    /// Sonuç Kodu
    /// </summary>
        public string ResultCode
        {
            get { return (string)this["RESULTCODE"]; }
            set { this["RESULTCODE"] = value; }
        }

    /// <summary>
    /// Sonuç Mesajı
    /// </summary>
        public string ResultMessage
        {
            get { return (string)this["RESULTMESSAGE"]; }
            set { this["RESULTMESSAGE"] = value; }
        }

    /// <summary>
    /// Medula Fatura Dönemi
    /// </summary>
        public MedulaInvoiceTermDefinition MedulaInvoiceTerm
        {
            get { return (MedulaInvoiceTermDefinition)((ITTObject)this).GetParent("MEDULAINVOICETERM"); }
            set { this["MEDULAINVOICETERM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateMedulaParticipationPriceDetailsCollection()
        {
            _MedulaParticipationPriceDetails = new MedulaParticipationPriceDetail.ChildMedulaParticipationPriceDetailCollection(this, new Guid("21d7c2c4-7031-420e-ba33-b89a1ec9f92f"));
            ((ITTChildObjectCollection)_MedulaParticipationPriceDetails).GetChildren();
        }

        protected MedulaParticipationPriceDetail.ChildMedulaParticipationPriceDetailCollection _MedulaParticipationPriceDetails = null;
    /// <summary>
    /// Child collection for Medula Katılım Payı Ücreti
    /// </summary>
        public MedulaParticipationPriceDetail.ChildMedulaParticipationPriceDetailCollection MedulaParticipationPriceDetails
        {
            get
            {
                if (_MedulaParticipationPriceDetails == null)
                    CreateMedulaParticipationPriceDetailsCollection();
                return _MedulaParticipationPriceDetails;
            }
        }

        protected MedulaParticipationPrice(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MedulaParticipationPrice(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MedulaParticipationPrice(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MedulaParticipationPrice(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MedulaParticipationPrice(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MEDULAPARTICIPATIONPRICE", dataRow) { }
        protected MedulaParticipationPrice(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MEDULAPARTICIPATIONPRICE", dataRow, isImported) { }
        public MedulaParticipationPrice(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MedulaParticipationPrice(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MedulaParticipationPrice() : base() { }

    }
}
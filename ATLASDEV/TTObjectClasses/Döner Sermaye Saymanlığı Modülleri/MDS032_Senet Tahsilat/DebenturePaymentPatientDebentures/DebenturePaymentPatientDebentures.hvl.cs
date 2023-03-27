
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DebenturePaymentPatientDebentures")] 

    /// <summary>
    /// Hasta Ait Senetler
    /// </summary>
    public  partial class DebenturePaymentPatientDebentures : TTObject
    {
        public class DebenturePaymentPatientDebenturesList : TTObjectCollection<DebenturePaymentPatientDebentures> { }
                    
        public class ChildDebenturePaymentPatientDebenturesCollection : TTObject.TTChildObjectCollection<DebenturePaymentPatientDebentures>
        {
            public ChildDebenturePaymentPatientDebenturesCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDebenturePaymentPatientDebenturesCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Senet Durumu
    /// </summary>
        public string Status
        {
            get { return (string)this["STATUS"]; }
            set { this["STATUS"] = value; }
        }

    /// <summary>
    /// Ödendi
    /// </summary>
        public bool? Paid
        {
            get { return (bool?)this["PAID"]; }
            set { this["PAID"] = value; }
        }

    /// <summary>
    /// Senet Tahsilat Dökümanıyla İlişki
    /// </summary>
        public DebenturePaymentDocument DebenturePaymentDocument
        {
            get { return (DebenturePaymentDocument)((ITTObject)this).GetParent("DEBENTUREPAYMENTDOCUMENT"); }
            set { this["DEBENTUREPAYMENTDOCUMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Senet Tahsilat İşlemiyle İlişki
    /// </summary>
        public DebenturePayment DebenturePayment
        {
            get { return (DebenturePayment)((ITTObject)this).GetParent("DEBENTUREPAYMENT"); }
            set { this["DEBENTUREPAYMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Senetle İlişki
    /// </summary>
        public Debenture Debenture
        {
            get { return (Debenture)((ITTObject)this).GetParent("DEBENTURE"); }
            set { this["DEBENTURE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected DebenturePaymentPatientDebentures(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DebenturePaymentPatientDebentures(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DebenturePaymentPatientDebentures(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DebenturePaymentPatientDebentures(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DebenturePaymentPatientDebentures(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DEBENTUREPAYMENTPATIENTDEBENTURES", dataRow) { }
        protected DebenturePaymentPatientDebentures(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DEBENTUREPAYMENTPATIENTDEBENTURES", dataRow, isImported) { }
        public DebenturePaymentPatientDebentures(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DebenturePaymentPatientDebentures(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DebenturePaymentPatientDebentures() : base() { }

    }
}
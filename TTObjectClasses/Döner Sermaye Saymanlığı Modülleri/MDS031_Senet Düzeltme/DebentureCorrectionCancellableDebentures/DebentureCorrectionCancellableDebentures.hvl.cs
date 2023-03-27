
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DebentureCorrectionCancellableDebentures")] 

    /// <summary>
    /// Hastanın İptal Edilebilir Senetleri
    /// </summary>
    public  partial class DebentureCorrectionCancellableDebentures : TTObject
    {
        public class DebentureCorrectionCancellableDebenturesList : TTObjectCollection<DebentureCorrectionCancellableDebentures> { }
                    
        public class ChildDebentureCorrectionCancellableDebenturesCollection : TTObject.TTChildObjectCollection<DebentureCorrectionCancellableDebentures>
        {
            public ChildDebentureCorrectionCancellableDebenturesCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDebentureCorrectionCancellableDebenturesCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Muhasebe Alındısı ObjectID
    /// </summary>
        public string ReceiptDocumentObjectID
        {
            get { return (string)this["RECEIPTDOCUMENTOBJECTID"]; }
            set { this["RECEIPTDOCUMENTOBJECTID"] = value; }
        }

    /// <summary>
    /// Senet ObjectID
    /// </summary>
        public string DebentureObjectID
        {
            get { return (string)this["DEBENTUREOBJECTID"]; }
            set { this["DEBENTUREOBJECTID"] = value; }
        }

    /// <summary>
    /// Durum
    /// </summary>
        public string Status
        {
            get { return (string)this["STATUS"]; }
            set { this["STATUS"] = value; }
        }

    /// <summary>
    /// Fiyat
    /// </summary>
        public Currency? Price
        {
            get { return (Currency?)this["PRICE"]; }
            set { this["PRICE"] = value; }
        }

    /// <summary>
    /// Senet No
    /// </summary>
        public string No
        {
            get { return (string)this["NO"]; }
            set { this["NO"] = value; }
        }

    /// <summary>
    /// Avans Alındısı ObjectID
    /// </summary>
        public string AdvanceDocumentObjectID
        {
            get { return (string)this["ADVANCEDOCUMENTOBJECTID"]; }
            set { this["ADVANCEDOCUMENTOBJECTID"] = value; }
        }

    /// <summary>
    /// Vade Tarihi
    /// </summary>
        public DateTime? DueDate
        {
            get { return (DateTime?)this["DUEDATE"]; }
            set { this["DUEDATE"] = value; }
        }

    /// <summary>
    /// İptal Et
    /// </summary>
        public bool? Cancelled
        {
            get { return (bool?)this["CANCELLED"]; }
            set { this["CANCELLED"] = value; }
        }

        public DebentureCorrection DebentureCorrection
        {
            get { return (DebentureCorrection)((ITTObject)this).GetParent("DEBENTURECORRECTION"); }
            set { this["DEBENTURECORRECTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected DebentureCorrectionCancellableDebentures(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DebentureCorrectionCancellableDebentures(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DebentureCorrectionCancellableDebentures(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DebentureCorrectionCancellableDebentures(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DebentureCorrectionCancellableDebentures(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DEBENTURECORRECTIONCANCELLABLEDEBENTURES", dataRow) { }
        protected DebentureCorrectionCancellableDebentures(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DEBENTURECORRECTIONCANCELLABLEDEBENTURES", dataRow, isImported) { }
        public DebentureCorrectionCancellableDebentures(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DebentureCorrectionCancellableDebentures(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DebentureCorrectionCancellableDebentures() : base() { }

    }
}
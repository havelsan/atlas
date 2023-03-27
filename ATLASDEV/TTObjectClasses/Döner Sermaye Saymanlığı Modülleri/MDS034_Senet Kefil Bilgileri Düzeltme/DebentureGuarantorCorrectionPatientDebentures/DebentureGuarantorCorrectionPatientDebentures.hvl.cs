
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DebentureGuarantorCorrectionPatientDebentures")] 

    /// <summary>
    /// Kefil Bilgileri Düzeltme İşlemi Hasta Senetleri
    /// </summary>
    public  partial class DebentureGuarantorCorrectionPatientDebentures : TTObject
    {
        public class DebentureGuarantorCorrectionPatientDebenturesList : TTObjectCollection<DebentureGuarantorCorrectionPatientDebentures> { }
                    
        public class ChildDebentureGuarantorCorrectionPatientDebenturesCollection : TTObject.TTChildObjectCollection<DebentureGuarantorCorrectionPatientDebentures>
        {
            public ChildDebentureGuarantorCorrectionPatientDebenturesCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDebentureGuarantorCorrectionPatientDebenturesCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Değiştir
    /// </summary>
        public bool? Changed
        {
            get { return (bool?)this["CHANGED"]; }
            set { this["CHANGED"] = value; }
        }

    /// <summary>
    /// Senet ID si
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
    /// Tutar
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
    /// Vade Tarihi
    /// </summary>
        public DateTime? DueDate
        {
            get { return (DateTime?)this["DUEDATE"]; }
            set { this["DUEDATE"] = value; }
        }

    /// <summary>
    /// Senet ile ilişki
    /// </summary>
        public Debenture Debenture
        {
            get { return (Debenture)((ITTObject)this).GetParent("DEBENTURE"); }
            set { this["DEBENTURE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Senet Düzeltme ile ilişki
    /// </summary>
        public DebentureGuarantorCorrection DebentureCorrection
        {
            get { return (DebentureGuarantorCorrection)((ITTObject)this).GetParent("DEBENTURECORRECTION"); }
            set { this["DEBENTURECORRECTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected DebentureGuarantorCorrectionPatientDebentures(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DebentureGuarantorCorrectionPatientDebentures(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DebentureGuarantorCorrectionPatientDebentures(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DebentureGuarantorCorrectionPatientDebentures(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DebentureGuarantorCorrectionPatientDebentures(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DEBENTUREGUARANTORCORRECTIONPATIENTDEBENTURES", dataRow) { }
        protected DebentureGuarantorCorrectionPatientDebentures(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DEBENTUREGUARANTORCORRECTIONPATIENTDEBENTURES", dataRow, isImported) { }
        public DebentureGuarantorCorrectionPatientDebentures(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DebentureGuarantorCorrectionPatientDebentures(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DebentureGuarantorCorrectionPatientDebentures() : base() { }

    }
}
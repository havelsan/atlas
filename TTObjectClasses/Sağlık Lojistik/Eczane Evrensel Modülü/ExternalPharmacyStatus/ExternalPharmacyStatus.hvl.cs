
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ExternalPharmacyStatus")] 

    /// <summary>
    /// Dış Eczane Durumları
    /// </summary>
    public  partial class ExternalPharmacyStatus : TTObject
    {
        public class ExternalPharmacyStatusList : TTObjectCollection<ExternalPharmacyStatus> { }
                    
        public class ChildExternalPharmacyStatusCollection : TTObject.TTChildObjectCollection<ExternalPharmacyStatus>
        {
            public ChildExternalPharmacyStatusCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildExternalPharmacyStatusCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Açıklama
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

    /// <summary>
    /// Durum
    /// </summary>
        public ExternalPharmacyStatusEnum? Status
        {
            get { return (ExternalPharmacyStatusEnum?)(int?)this["STATUS"]; }
            set { this["STATUS"] = value; }
        }

    /// <summary>
    /// Bitiş Zamanı
    /// </summary>
        public DateTime? EndDate
        {
            get { return (DateTime?)this["ENDDATE"]; }
            set { this["ENDDATE"] = value; }
        }

    /// <summary>
    /// Başlama Zamanı
    /// </summary>
        public DateTime? StartDate
        {
            get { return (DateTime?)this["STARTDATE"]; }
            set { this["STARTDATE"] = value; }
        }

        public ExternalPharmacy ExternalPharmacy
        {
            get { return (ExternalPharmacy)((ITTObject)this).GetParent("EXTERNALPHARMACY"); }
            set { this["EXTERNALPHARMACY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ExternalPharmacyStatus(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ExternalPharmacyStatus(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ExternalPharmacyStatus(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ExternalPharmacyStatus(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ExternalPharmacyStatus(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EXTERNALPHARMACYSTATUS", dataRow) { }
        protected ExternalPharmacyStatus(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EXTERNALPHARMACYSTATUS", dataRow, isImported) { }
        public ExternalPharmacyStatus(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ExternalPharmacyStatus(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ExternalPharmacyStatus() : base() { }

    }
}

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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ExternalPharmacyDistributionTerm")] 

    /// <summary>
    /// Diş Eczane Reçete Dağıtım Dönemleri
    /// </summary>
    public  partial class ExternalPharmacyDistributionTerm : TTObject
    {
        public class ExternalPharmacyDistributionTermList : TTObjectCollection<ExternalPharmacyDistributionTerm> { }
                    
        public class ChildExternalPharmacyDistributionTermCollection : TTObject.TTChildObjectCollection<ExternalPharmacyDistributionTerm>
        {
            public ChildExternalPharmacyDistributionTermCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildExternalPharmacyDistributionTermCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static BindingList<ExternalPharmacyDistributionTerm> GetOpenDistributionTerm(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EXTERNALPHARMACYDISTRIBUTIONTERM"].QueryDefs["GetOpenDistributionTerm"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<ExternalPharmacyDistributionTerm>(queryDef, paramList);
        }

    /// <summary>
    /// Başlangıç Tarihi
    /// </summary>
        public DateTime? StartDate
        {
            get { return (DateTime?)this["STARTDATE"]; }
            set { this["STARTDATE"] = value; }
        }

    /// <summary>
    /// Durum
    /// </summary>
        public AccountingTermStatusEnum? Status
        {
            get { return (AccountingTermStatusEnum?)(int?)this["STATUS"]; }
            set { this["STATUS"] = value; }
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
    /// Bitiş Tarihi
    /// </summary>
        public DateTime? EndDate
        {
            get { return (DateTime?)this["ENDDATE"]; }
            set { this["ENDDATE"] = value; }
        }

        protected ExternalPharmacyDistributionTerm(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ExternalPharmacyDistributionTerm(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ExternalPharmacyDistributionTerm(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ExternalPharmacyDistributionTerm(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ExternalPharmacyDistributionTerm(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EXTERNALPHARMACYDISTRIBUTIONTERM", dataRow) { }
        protected ExternalPharmacyDistributionTerm(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EXTERNALPHARMACYDISTRIBUTIONTERM", dataRow, isImported) { }
        public ExternalPharmacyDistributionTerm(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ExternalPharmacyDistributionTerm(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ExternalPharmacyDistributionTerm() : base() { }

    }
}
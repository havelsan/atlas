
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BloodBankExternalBloodProductEntryPlaceDefinition")] 

    /// <summary>
    /// Hastaya Dışarıdan Kan Girişi Yapılacak Yerler
    /// </summary>
    public  partial class BloodBankExternalBloodProductEntryPlaceDefinition : ProcedureDefinition
    {
        public class BloodBankExternalBloodProductEntryPlaceDefinitionList : TTObjectCollection<BloodBankExternalBloodProductEntryPlaceDefinition> { }
                    
        public class ChildBloodBankExternalBloodProductEntryPlaceDefinitionCollection : TTObject.TTChildObjectCollection<BloodBankExternalBloodProductEntryPlaceDefinition>
        {
            public ChildBloodBankExternalBloodProductEntryPlaceDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBloodBankExternalBloodProductEntryPlaceDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected BloodBankExternalBloodProductEntryPlaceDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BloodBankExternalBloodProductEntryPlaceDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BloodBankExternalBloodProductEntryPlaceDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BloodBankExternalBloodProductEntryPlaceDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BloodBankExternalBloodProductEntryPlaceDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BLOODBANKEXTERNALBLOODPRODUCTENTRYPLACEDEFINITION", dataRow) { }
        protected BloodBankExternalBloodProductEntryPlaceDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BLOODBANKEXTERNALBLOODPRODUCTENTRYPLACEDEFINITION", dataRow, isImported) { }
        public BloodBankExternalBloodProductEntryPlaceDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BloodBankExternalBloodProductEntryPlaceDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BloodBankExternalBloodProductEntryPlaceDefinition() : base() { }

    }
}

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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ARD_AccountancyAmount")] 

    public  partial class ARD_AccountancyAmount : TTObject
    {
        public class ARD_AccountancyAmountList : TTObjectCollection<ARD_AccountancyAmount> { }
                    
        public class ChildARD_AccountancyAmountCollection : TTObject.TTChildObjectCollection<ARD_AccountancyAmount>
        {
            public ChildARD_AccountancyAmountCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildARD_AccountancyAmountCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Miktar
    /// </summary>
        public Currency? Amount
        {
            get { return (Currency?)this["AMOUNT"]; }
            set { this["AMOUNT"] = value; }
        }

    /// <summary>
    /// İhtiyaç Fazlası
    /// </summary>
        public Currency? SurplusAmount
        {
            get { return (Currency?)this["SURPLUSAMOUNT"]; }
            set { this["SURPLUSAMOUNT"] = value; }
        }

        public AnnualRequirementDetail AnnualRequirementDetail
        {
            get { return (AnnualRequirementDetail)((ITTObject)this).GetParent("ANNUALREQUIREMENTDETAIL"); }
            set { this["ANNUALREQUIREMENTDETAIL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Accountancy Accountancy
        {
            get { return (Accountancy)((ITTObject)this).GetParent("ACCOUNTANCY"); }
            set { this["ACCOUNTANCY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ARD_AccountancyAmount(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ARD_AccountancyAmount(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ARD_AccountancyAmount(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ARD_AccountancyAmount(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ARD_AccountancyAmount(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ARD_ACCOUNTANCYAMOUNT", dataRow) { }
        protected ARD_AccountancyAmount(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ARD_ACCOUNTANCYAMOUNT", dataRow, isImported) { }
        public ARD_AccountancyAmount(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ARD_AccountancyAmount(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ARD_AccountancyAmount() : base() { }

    }
}
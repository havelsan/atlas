
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MhSPaymentUnit")] 

    /// <summary>
    /// Ödeme Birim
    /// </summary>
    public  partial class MhSPaymentUnit : TTObject
    {
        public class MhSPaymentUnitList : TTObjectCollection<MhSPaymentUnit> { }
                    
        public class ChildMhSPaymentUnitCollection : TTObject.TTChildObjectCollection<MhSPaymentUnit>
        {
            public ChildMhSPaymentUnitCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMhSPaymentUnitCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Ad
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

    /// <summary>
    /// TmkId
    /// </summary>
        public string TMK
        {
            get { return (string)this["TMK"]; }
            set { this["TMK"] = value; }
        }

        protected MhSPaymentUnit(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MhSPaymentUnit(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MhSPaymentUnit(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MhSPaymentUnit(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MhSPaymentUnit(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MHSPAYMENTUNIT", dataRow) { }
        protected MhSPaymentUnit(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MHSPAYMENTUNIT", dataRow, isImported) { }
        public MhSPaymentUnit(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MhSPaymentUnit(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MhSPaymentUnit() : base() { }

    }
}

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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MBSCOBDeath")] 

    public  partial class MBSCOBDeath : MBSCOBBirth
    {
        public class MBSCOBDeathList : TTObjectCollection<MBSCOBDeath> { }
                    
        public class ChildMBSCOBDeathCollection : TTObject.TTChildObjectCollection<MBSCOBDeath>
        {
            public ChildMBSCOBDeathCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMBSCOBDeathCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Mali yılbaşından ödenen miktar
    /// </summary>
        public double? TotalPaymentFinancialYear
        {
            get { return (double?)this["TOTALPAYMENTFINANCIALYEAR"]; }
            set { this["TOTALPAYMENTFINANCIALYEAR"] = value; }
        }

    /// <summary>
    /// Ölen ad
    /// </summary>
        public string DeathName
        {
            get { return (string)this["DEATHNAME"]; }
            set { this["DEATHNAME"] = value; }
        }

    /// <summary>
    /// Ölen Soyad
    /// </summary>
        public string DeathSurname
        {
            get { return (string)this["DEATHSURNAME"]; }
            set { this["DEATHSURNAME"] = value; }
        }

        protected MBSCOBDeath(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MBSCOBDeath(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MBSCOBDeath(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MBSCOBDeath(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MBSCOBDeath(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MBSCOBDEATH", dataRow) { }
        protected MBSCOBDeath(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MBSCOBDEATH", dataRow, isImported) { }
        public MBSCOBDeath(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MBSCOBDeath(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MBSCOBDeath() : base() { }

    }
}
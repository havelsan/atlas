
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ClearCovidInfoFromPatient")] 

    /// <summary>
    /// 15 gün içinde Covid Tanısı Girilmemiş Hastaların Pandemi bilgisini siler
    /// </summary>
    public  partial class ClearCovidInfoFromPatient : BaseScheduledTask
    {
        public class ClearCovidInfoFromPatientList : TTObjectCollection<ClearCovidInfoFromPatient> { }
                    
        public class ChildClearCovidInfoFromPatientCollection : TTObject.TTChildObjectCollection<ClearCovidInfoFromPatient>
        {
            public ChildClearCovidInfoFromPatientCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildClearCovidInfoFromPatientCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected ClearCovidInfoFromPatient(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ClearCovidInfoFromPatient(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ClearCovidInfoFromPatient(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ClearCovidInfoFromPatient(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ClearCovidInfoFromPatient(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "CLEARCOVIDINFOFROMPATIENT", dataRow) { }
        protected ClearCovidInfoFromPatient(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "CLEARCOVIDINFOFROMPATIENT", dataRow, isImported) { }
        public ClearCovidInfoFromPatient(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ClearCovidInfoFromPatient(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ClearCovidInfoFromPatient() : base() { }

    }
}
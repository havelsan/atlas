
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MedulaSPASError")] 

    public  partial class MedulaSPASError : TTObject
    {
        public class MedulaSPASErrorList : TTObjectCollection<MedulaSPASError> { }
                    
        public class ChildMedulaSPASErrorCollection : TTObject.TTChildObjectCollection<MedulaSPASError>
        {
            public ChildMedulaSPASErrorCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMedulaSPASErrorCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Hata Tarihi
    /// </summary>
        public DateTime? ErrorDate
        {
            get { return (DateTime?)this["ERRORDATE"]; }
            set { this["ERRORDATE"] = value; }
        }

    /// <summary>
    /// Hata Mesajı
    /// </summary>
        public string ErrorMessage
        {
            get { return (string)this["ERRORMESSAGE"]; }
            set { this["ERRORMESSAGE"] = value; }
        }

        public PatientAdmission PatientAdmission
        {
            get { return (PatientAdmission)((ITTObject)this).GetParent("PATIENTADMISSION"); }
            set { this["PATIENTADMISSION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MedulaSPASError(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MedulaSPASError(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MedulaSPASError(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MedulaSPASError(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MedulaSPASError(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MEDULASPASERROR", dataRow) { }
        protected MedulaSPASError(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MEDULASPASERROR", dataRow, isImported) { }
        public MedulaSPASError(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MedulaSPASError(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MedulaSPASError() : base() { }

    }
}
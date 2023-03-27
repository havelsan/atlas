
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MPBSDisciplineRegistration")] 

    /// <summary>
    /// Disiplin Kaydı
    /// </summary>
    public  partial class MPBSDisciplineRegistration : TTObject
    {
        public class MPBSDisciplineRegistrationList : TTObjectCollection<MPBSDisciplineRegistration> { }
                    
        public class ChildMPBSDisciplineRegistrationCollection : TTObject.TTChildObjectCollection<MPBSDisciplineRegistration>
        {
            public ChildMPBSDisciplineRegistrationCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMPBSDisciplineRegistrationCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Veren Makam
    /// </summary>
        public string GiverPosition
        {
            get { return (string)this["GIVERPOSITION"]; }
            set { this["GIVERPOSITION"] = value; }
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
    /// Veriliş Nedeni
    /// </summary>
        public string GivenReason
        {
            get { return (string)this["GIVENREASON"]; }
            set { this["GIVENREASON"] = value; }
        }

    /// <summary>
    /// Konu
    /// </summary>
        public string Subject
        {
            get { return (string)this["SUBJECT"]; }
            set { this["SUBJECT"] = value; }
        }

    /// <summary>
    /// Veriliş Tarihi
    /// </summary>
        public DateTime? GivenDate
        {
            get { return (DateTime?)this["GIVENDATE"]; }
            set { this["GIVENDATE"] = value; }
        }

        protected MPBSDisciplineRegistration(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MPBSDisciplineRegistration(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MPBSDisciplineRegistration(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MPBSDisciplineRegistration(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MPBSDisciplineRegistration(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MPBSDISCIPLINEREGISTRATION", dataRow) { }
        protected MPBSDisciplineRegistration(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MPBSDISCIPLINEREGISTRATION", dataRow, isImported) { }
        public MPBSDisciplineRegistration(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MPBSDisciplineRegistration(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MPBSDisciplineRegistration() : base() { }

    }
}
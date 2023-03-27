
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MPBSPersonnel")] 

    public  partial class MPBSPersonnel : MPBSPerson
    {
        public class MPBSPersonnelList : TTObjectCollection<MPBSPersonnel> { }
                    
        public class ChildMPBSPersonnelCollection : TTObject.TTChildObjectCollection<MPBSPersonnel>
        {
            public ChildMPBSPersonnelCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMPBSPersonnelCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Ayrılış Tarihi
    /// </summary>
        public DateTime? DepartureDate
        {
            get { return (DateTime?)this["DEPARTUREDATE"]; }
            set { this["DEPARTUREDATE"] = value; }
        }

    /// <summary>
    /// Daimi Adresi
    /// </summary>
        public string PermanentAddress
        {
            get { return (string)this["PERMANENTADDRESS"]; }
            set { this["PERMANENTADDRESS"] = value; }
        }

    /// <summary>
    /// Cep Telefon No
    /// </summary>
        public string MobilPhone
        {
            get { return (string)this["MOBILPHONE"]; }
            set { this["MOBILPHONE"] = value; }
        }

    /// <summary>
    /// Muadil Adresi
    /// </summary>
        public string EquivalentAddress
        {
            get { return (string)this["EQUIVALENTADDRESS"]; }
            set { this["EQUIVALENTADDRESS"] = value; }
        }

    /// <summary>
    /// Ev Adresi
    /// </summary>
        public string HomeAddress
        {
            get { return (string)this["HOMEADDRESS"]; }
            set { this["HOMEADDRESS"] = value; }
        }

    /// <summary>
    /// Ev Telefon No
    /// </summary>
        public string HomePhone
        {
            get { return (string)this["HOMEPHONE"]; }
            set { this["HOMEPHONE"] = value; }
        }

    /// <summary>
    /// Katılış Tarihi
    /// </summary>
        public DateTime? RegistrationDate
        {
            get { return (DateTime?)this["REGISTRATIONDATE"]; }
            set { this["REGISTRATIONDATE"] = value; }
        }

    /// <summary>
    /// Muadil Telefon No
    /// </summary>
        public string EquivalentPhone
        {
            get { return (string)this["EQUIVALENTPHONE"]; }
            set { this["EQUIVALENTPHONE"] = value; }
        }

    /// <summary>
    /// E-Posta
    /// </summary>
        public string EMail
        {
            get { return (string)this["EMAIL"]; }
            set { this["EMAIL"] = value; }
        }

    /// <summary>
    /// İş Telefon No
    /// </summary>
        public string WorkPhone
        {
            get { return (string)this["WORKPHONE"]; }
            set { this["WORKPHONE"] = value; }
        }

        protected MPBSPersonnel(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MPBSPersonnel(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MPBSPersonnel(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MPBSPersonnel(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MPBSPersonnel(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MPBSPERSONNEL", dataRow) { }
        protected MPBSPersonnel(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MPBSPERSONNEL", dataRow, isImported) { }
        public MPBSPersonnel(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MPBSPersonnel(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MPBSPersonnel() : base() { }

    }
}
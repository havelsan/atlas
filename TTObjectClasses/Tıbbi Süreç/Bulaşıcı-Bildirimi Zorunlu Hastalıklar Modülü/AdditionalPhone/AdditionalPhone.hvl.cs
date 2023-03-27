
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="AdditionalPhone")] 

    /// <summary>
    /// Bulaşıcı Hastalık Bildirim Telefon Bilgisi
    /// </summary>
    public  partial class AdditionalPhone : TTObject
    {
        public class AdditionalPhoneList : TTObjectCollection<AdditionalPhone> { }
                    
        public class ChildAdditionalPhoneCollection : TTObject.TTChildObjectCollection<AdditionalPhone>
        {
            public ChildAdditionalPhoneCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildAdditionalPhoneCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Telefon
    /// </summary>
        public string PhoneNumber
        {
            get { return (string)this["PHONENUMBER"]; }
            set { this["PHONENUMBER"] = value; }
        }

        public PatientIdentityAndAddress Patient
        {
            get { return (PatientIdentityAndAddress)((ITTObject)this).GetParent("PATIENT"); }
            set { this["PATIENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSTelefonTipi SKRSTelefonTipi
        {
            get { return (SKRSTelefonTipi)((ITTObject)this).GetParent("SKRSTELEFONTIPI"); }
            set { this["SKRSTELEFONTIPI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected AdditionalPhone(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected AdditionalPhone(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected AdditionalPhone(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected AdditionalPhone(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected AdditionalPhone(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ADDITIONALPHONE", dataRow) { }
        protected AdditionalPhone(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ADDITIONALPHONE", dataRow, isImported) { }
        public AdditionalPhone(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public AdditionalPhone(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public AdditionalPhone() : base() { }

    }
}
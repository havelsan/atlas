
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BasePsychologyForm")] 

    public  partial class BasePsychologyForm : TTObject
    {
        public class BasePsychologyFormList : TTObjectCollection<BasePsychologyForm> { }
                    
        public class ChildBasePsychologyFormCollection : TTObject.TTChildObjectCollection<BasePsychologyForm>
        {
            public ChildBasePsychologyFormCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBasePsychologyFormCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Eklenme Tarihi
    /// </summary>
        public DateTime? AddedDate
        {
            get { return (DateTime?)this["ADDEDDATE"]; }
            set { this["ADDEDDATE"] = value; }
        }

    /// <summary>
    /// Form Yetkisi
    /// </summary>
        public PsychologyFormAuthorityTypesEnum? FormAuthority
        {
            get { return (PsychologyFormAuthorityTypesEnum?)(int?)this["FORMAUTHORITY"]; }
            set { this["FORMAUTHORITY"] = value; }
        }

    /// <summary>
    /// Ekleyen Kullanıcı
    /// </summary>
        public ResUser AddedUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("ADDEDUSER"); }
            set { this["ADDEDUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Testi Uygulayan Doktor
    /// </summary>
        public ResUser ProcedureDoctor
        {
            get { return (ResUser)((ITTObject)this).GetParent("PROCEDUREDOCTOR"); }
            set { this["PROCEDUREDOCTOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public PsychologyBasedObject PsychologyBasedObject
        {
            get { return (PsychologyBasedObject)((ITTObject)this).GetParent("PSYCHOLOGYBASEDOBJECT"); }
            set { this["PSYCHOLOGYBASEDOBJECT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected BasePsychologyForm(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BasePsychologyForm(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BasePsychologyForm(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BasePsychologyForm(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BasePsychologyForm(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BASEPSYCHOLOGYFORM", dataRow) { }
        protected BasePsychologyForm(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BASEPSYCHOLOGYFORM", dataRow, isImported) { }
        public BasePsychologyForm(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BasePsychologyForm(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BasePsychologyForm() : base() { }

    }
}
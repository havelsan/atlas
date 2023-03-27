
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PatientFolderDefinition")] 

    public  partial class PatientFolderDefinition : TTDefinitionSet
    {
        public class PatientFolderDefinitionList : TTObjectCollection<PatientFolderDefinition> { }
                    
        public class ChildPatientFolderDefinitionCollection : TTObject.TTChildObjectCollection<PatientFolderDefinition>
        {
            public ChildPatientFolderDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPatientFolderDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public string PropertyName
        {
            get { return (string)this["PROPERTYNAME"]; }
            set { this["PROPERTYNAME"] = value; }
        }

        public HeaderTypeEnum? HeaderType
        {
            get { return (HeaderTypeEnum?)(int?)this["HEADERTYPE"]; }
            set { this["HEADERTYPE"] = value; }
        }

        public int? InitialWidth
        {
            get { return (int?)this["INITIALWIDTH"]; }
            set { this["INITIALWIDTH"] = value; }
        }

        public int? OrderNo
        {
            get { return (int?)this["ORDERNO"]; }
            set { this["ORDERNO"] = value; }
        }

        public string Caption
        {
            get { return (string)this["CAPTION"]; }
            set { this["CAPTION"] = value; }
        }

        protected PatientFolderDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PatientFolderDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PatientFolderDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PatientFolderDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PatientFolderDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PATIENTFOLDERDEFINITION", dataRow) { }
        protected PatientFolderDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PATIENTFOLDERDEFINITION", dataRow, isImported) { }
        public PatientFolderDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PatientFolderDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PatientFolderDefinition() : base() { }

    }
}
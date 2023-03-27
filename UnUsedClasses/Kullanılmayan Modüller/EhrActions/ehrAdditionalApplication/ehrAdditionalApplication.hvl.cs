
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ehrAdditionalApplication")] 

    /// <summary>
    /// Ek Uygulamalar
    /// </summary>
    public  partial class ehrAdditionalApplication : ehrSubactionProcedure
    {
        public class ehrAdditionalApplicationList : TTObjectCollection<ehrAdditionalApplication> { }
                    
        public class ChildehrAdditionalApplicationCollection : TTObject.TTChildObjectCollection<ehrAdditionalApplication>
        {
            public ChildehrAdditionalApplicationCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildehrAdditionalApplicationCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
            public static Guid Active { get { return new Guid("b86c3e17-bf34-414c-b60c-182925abc911"); } }
            public static Guid Inactive { get { return new Guid("749387be-ff99-45ed-b18a-fb2b6a7a1190"); } }
        }

    /// <summary>
    /// Sonuç
    /// </summary>
        public string Result
        {
            get { return (string)this["RESULT"]; }
            set { this["RESULT"] = value; }
        }

        protected ehrAdditionalApplication(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ehrAdditionalApplication(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ehrAdditionalApplication(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ehrAdditionalApplication(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ehrAdditionalApplication(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EHRADDITIONALAPPLICATION", dataRow) { }
        protected ehrAdditionalApplication(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EHRADDITIONALAPPLICATION", dataRow, isImported) { }
        public ehrAdditionalApplication(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ehrAdditionalApplication(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ehrAdditionalApplication() : base() { }

    }
}
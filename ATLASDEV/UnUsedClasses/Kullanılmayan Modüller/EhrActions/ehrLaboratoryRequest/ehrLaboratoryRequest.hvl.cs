
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ehrLaboratoryRequest")] 

    /// <summary>
    /// Laboratuvar İstek
    /// </summary>
    public  partial class ehrLaboratoryRequest : ehrEpisodeAction
    {
        public class ehrLaboratoryRequestList : TTObjectCollection<ehrLaboratoryRequest> { }
                    
        public class ChildehrLaboratoryRequestCollection : TTObject.TTChildObjectCollection<ehrLaboratoryRequest>
        {
            public ChildehrLaboratoryRequestCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildehrLaboratoryRequestCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
            public static Guid Active { get { return new Guid("d82caca1-a08a-43fa-b009-be70b816c5ec"); } }
            public static Guid UnActive { get { return new Guid("8abe0000-7e19-46e0-a07f-e69109e6aa4c"); } }
        }

    /// <summary>
    /// Kısa Anamnez ve Klinik Bulgular
    /// </summary>
        public string Prediagnosis
        {
            get { return (string)this["PREDIAGNOSIS"]; }
            set { this["PREDIAGNOSIS"] = value; }
        }

    /// <summary>
    /// Notlar
    /// </summary>
        public string Notes
        {
            get { return (string)this["NOTES"]; }
            set { this["NOTES"] = value; }
        }

        protected ehrLaboratoryRequest(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ehrLaboratoryRequest(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ehrLaboratoryRequest(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ehrLaboratoryRequest(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ehrLaboratoryRequest(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EHRLABORATORYREQUEST", dataRow) { }
        protected ehrLaboratoryRequest(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EHRLABORATORYREQUEST", dataRow, isImported) { }
        public ehrLaboratoryRequest(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ehrLaboratoryRequest(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ehrLaboratoryRequest() : base() { }

    }
}
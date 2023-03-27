
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ehrLaboratoryProcedure")] 

    /// <summary>
    /// Laboratuvar Test
    /// </summary>
    public  partial class ehrLaboratoryProcedure : ehrSubactionFlowable
    {
        public class ehrLaboratoryProcedureList : TTObjectCollection<ehrLaboratoryProcedure> { }
                    
        public class ChildehrLaboratoryProcedureCollection : TTObject.TTChildObjectCollection<ehrLaboratoryProcedure>
        {
            public ChildehrLaboratoryProcedureCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildehrLaboratoryProcedureCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
            public static Guid Active { get { return new Guid("d82caca1-a08a-43fa-b009-be70b816c5ec"); } }
            public static Guid UnActive { get { return new Guid("8abe0000-7e19-46e0-a07f-e69109e6aa4c"); } }
        }

    /// <summary>
    /// Referans
    /// </summary>
        public string Reference
        {
            get { return (string)this["REFERENCE"]; }
            set { this["REFERENCE"] = value; }
        }

    /// <summary>
    /// Sonuç
    /// </summary>
        public string Result
        {
            get { return (string)this["RESULT"]; }
            set { this["RESULT"] = value; }
        }

    /// <summary>
    /// Sapma
    /// </summary>
        public HighLowEnum? Warning
        {
            get { return (HighLowEnum?)(int?)this["WARNING"]; }
            set { this["WARNING"] = value; }
        }

    /// <summary>
    /// Birim
    /// </summary>
        public string Unit
        {
            get { return (string)this["UNIT"]; }
            set { this["UNIT"] = value; }
        }

        protected ehrLaboratoryProcedure(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ehrLaboratoryProcedure(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ehrLaboratoryProcedure(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ehrLaboratoryProcedure(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ehrLaboratoryProcedure(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EHRLABORATORYPROCEDURE", dataRow) { }
        protected ehrLaboratoryProcedure(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EHRLABORATORYPROCEDURE", dataRow, isImported) { }
        public ehrLaboratoryProcedure(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ehrLaboratoryProcedure(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ehrLaboratoryProcedure() : base() { }

    }
}

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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BaseAnesthesiaProcedure")] 

    /// <summary>
    /// Anestezi Prosedür Ana Objesi
    /// </summary>
    public  partial class BaseAnesthesiaProcedure : SubActionProcedure
    {
        public class BaseAnesthesiaProcedureList : TTObjectCollection<BaseAnesthesiaProcedure> { }
                    
        public class ChildBaseAnesthesiaProcedureCollection : TTObject.TTChildObjectCollection<BaseAnesthesiaProcedure>
        {
            public ChildBaseAnesthesiaProcedureCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBaseAnesthesiaProcedureCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
            public static Guid New { get { return new Guid("1c28a828-4470-46a5-af69-701b5322df1f"); } }
            public static Guid Completed { get { return new Guid("35536bbc-e567-46c8-be88-3bc9d65bfd5f"); } }
            public static Guid Cancelled { get { return new Guid("d16bf872-a7d1-476c-806d-92fd1852dccc"); } }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Note
        {
            get { return (string)this["NOTE"]; }
            set { this["NOTE"] = value; }
        }

    /// <summary>
    /// İşlemi Yapan 2. Doktor
    /// </summary>
        public ResUser ProcedureDoctor2
        {
            get { return (ResUser)((ITTObject)this).GetParent("PROCEDUREDOCTOR2"); }
            set { this["PROCEDUREDOCTOR2"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected BaseAnesthesiaProcedure(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BaseAnesthesiaProcedure(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BaseAnesthesiaProcedure(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BaseAnesthesiaProcedure(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BaseAnesthesiaProcedure(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BASEANESTHESIAPROCEDURE", dataRow) { }
        protected BaseAnesthesiaProcedure(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BASEANESTHESIAPROCEDURE", dataRow, isImported) { }
        public BaseAnesthesiaProcedure(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BaseAnesthesiaProcedure(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BaseAnesthesiaProcedure() : base() { }

    }
}
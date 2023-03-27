
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ehrManipulation")] 

    /// <summary>
    /// Tıbbi/Cerrahi Uygulama
    /// </summary>
    public  partial class ehrManipulation : ehrEpisodeAction
    {
        public class ehrManipulationList : TTObjectCollection<ehrManipulation> { }
                    
        public class ChildehrManipulationCollection : TTObject.TTChildObjectCollection<ehrManipulation>
        {
            public ChildehrManipulationCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildehrManipulationCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
            public static Guid Active { get { return new Guid("d82caca1-a08a-43fa-b009-be70b816c5ec"); } }
            public static Guid UnActive { get { return new Guid("8abe0000-7e19-46e0-a07f-e69109e6aa4c"); } }
        }

    /// <summary>
    /// Ön Bilgi
    /// </summary>
        public object PreInformation
        {
            get { return (object)this["PREINFORMATION"]; }
            set { this["PREINFORMATION"] = value; }
        }

    /// <summary>
    /// Prosedür Raporu
    /// </summary>
        public object ProcedureReport
        {
            get { return (object)this["PROCEDUREREPORT"]; }
            set { this["PROCEDUREREPORT"] = value; }
        }

    /// <summary>
    /// Rapor
    /// </summary>
        public object Report
        {
            get { return (object)this["REPORT"]; }
            set { this["REPORT"] = value; }
        }

    /// <summary>
    /// Teknisyen Notu
    /// </summary>
        public object TechnicianNote
        {
            get { return (object)this["TECHNICIANNOTE"]; }
            set { this["TECHNICIANNOTE"] = value; }
        }

        protected ehrManipulation(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ehrManipulation(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ehrManipulation(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ehrManipulation(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ehrManipulation(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EHRMANIPULATION", dataRow) { }
        protected ehrManipulation(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EHRMANIPULATION", dataRow, isImported) { }
        public ehrManipulation(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ehrManipulation(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ehrManipulation() : base() { }

    }
}
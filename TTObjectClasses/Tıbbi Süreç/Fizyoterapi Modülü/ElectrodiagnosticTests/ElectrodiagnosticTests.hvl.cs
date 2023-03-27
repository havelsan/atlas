
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ElectrodiagnosticTests")] 

    /// <summary>
    /// Elektrodiagnostik Testler
    /// </summary>
    public  partial class ElectrodiagnosticTests : BaseAdditionalInfo
    {
        public class ElectrodiagnosticTestsList : TTObjectCollection<ElectrodiagnosticTests> { }
                    
        public class ChildElectrodiagnosticTestsCollection : TTObject.TTChildObjectCollection<ElectrodiagnosticTests>
        {
            public ChildElectrodiagnosticTestsCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildElectrodiagnosticTestsCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Açık Frekanslı Akımlarla Reobaz ve Kronaksi Ölçümü
    /// </summary>
        public string RheobaseAndChronaxie
        {
            get { return (string)this["RHEOBASEANDCHRONAXIE"]; }
            set { this["RHEOBASEANDCHRONAXIE"] = value; }
        }

        protected ElectrodiagnosticTests(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ElectrodiagnosticTests(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ElectrodiagnosticTests(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ElectrodiagnosticTests(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ElectrodiagnosticTests(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ELECTRODIAGNOSTICTESTS", dataRow) { }
        protected ElectrodiagnosticTests(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ELECTRODIAGNOSTICTESTS", dataRow, isImported) { }
        public ElectrodiagnosticTests(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ElectrodiagnosticTests(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ElectrodiagnosticTests() : base() { }

    }
}
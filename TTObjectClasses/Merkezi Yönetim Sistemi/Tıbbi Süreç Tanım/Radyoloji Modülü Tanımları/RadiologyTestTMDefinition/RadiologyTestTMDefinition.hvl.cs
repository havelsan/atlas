
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="RadiologyTestTMDefinition")] 

    /// <summary>
    /// Radyoloji Tetkik Tanımları (TM)
    /// </summary>
    public  partial class RadiologyTestTMDefinition : ProcedureDefinition
    {
        public class RadiologyTestTMDefinitionList : TTObjectCollection<RadiologyTestTMDefinition> { }
                    
        public class ChildRadiologyTestTMDefinitionCollection : TTObject.TTChildObjectCollection<RadiologyTestTMDefinition>
        {
            public ChildRadiologyTestTMDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildRadiologyTestTMDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        virtual protected void CreateLocRadTestCollection()
        {
            _LocRadTest = new RadiologyTestDefinition.ChildRadiologyTestDefinitionCollection(this, new Guid("655b0403-2d89-4014-95f6-0f8be4d610e1"));
            ((ITTChildObjectCollection)_LocRadTest).GetChildren();
        }

        protected RadiologyTestDefinition.ChildRadiologyTestDefinitionCollection _LocRadTest = null;
        public RadiologyTestDefinition.ChildRadiologyTestDefinitionCollection LocRadTest
        {
            get
            {
                if (_LocRadTest == null)
                    CreateLocRadTestCollection();
                return _LocRadTest;
            }
        }

        protected RadiologyTestTMDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected RadiologyTestTMDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected RadiologyTestTMDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected RadiologyTestTMDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected RadiologyTestTMDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RADIOLOGYTESTTMDEFINITION", dataRow) { }
        protected RadiologyTestTMDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RADIOLOGYTESTTMDEFINITION", dataRow, isImported) { }
        public RadiologyTestTMDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public RadiologyTestTMDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public RadiologyTestTMDefinition() : base() { }

    }
}
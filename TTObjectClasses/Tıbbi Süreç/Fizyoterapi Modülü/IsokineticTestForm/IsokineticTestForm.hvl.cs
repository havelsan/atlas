
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="IsokineticTestForm")] 

    /// <summary>
    /// Bilgisayarlı İzokinetik Testi
    /// </summary>
    public  partial class IsokineticTestForm : BaseAdditionalInfo
    {
        public class IsokineticTestFormList : TTObjectCollection<IsokineticTestForm> { }
                    
        public class ChildIsokineticTestFormCollection : TTObject.TTChildObjectCollection<IsokineticTestForm>
        {
            public ChildIsokineticTestFormCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildIsokineticTestFormCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Bilgisayarlı İzokinetik Test
    /// </summary>
        public string ComputerBasedIsokineticTest
        {
            get { return (string)this["COMPUTERBASEDISOKINETICTEST"]; }
            set { this["COMPUTERBASEDISOKINETICTEST"] = value; }
        }

        protected IsokineticTestForm(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected IsokineticTestForm(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected IsokineticTestForm(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected IsokineticTestForm(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected IsokineticTestForm(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ISOKINETICTESTFORM", dataRow) { }
        protected IsokineticTestForm(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ISOKINETICTESTFORM", dataRow, isImported) { }
        public IsokineticTestForm(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public IsokineticTestForm(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public IsokineticTestForm() : base() { }

    }
}
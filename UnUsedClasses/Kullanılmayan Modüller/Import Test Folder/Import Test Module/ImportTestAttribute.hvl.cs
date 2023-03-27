
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
    public partial class ImportTestAttribute : TTAttributeInstance
    {
        public string Param2
        {
            get {return (string)this["Param2"];}
        }

        public int Param1
        {
            get {return (int)this["Param1"];}
        }

        public ImportTestAttribute(TTObjectContext objectContext, TTAttributeDef attributeDef, Dictionary<string, object> parameterValues) : base(objectContext, attributeDef, parameterValues)
        {
        }

    }
}
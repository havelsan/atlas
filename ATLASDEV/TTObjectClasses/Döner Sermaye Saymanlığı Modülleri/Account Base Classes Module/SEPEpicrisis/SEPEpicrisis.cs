
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
    public  partial class SEPEpicrisis : TTObject
    {
        public SEPEpicrisis(TTObjectContext objectContext, string description) : this(objectContext)
        {
            CreateDate = DateTime.Now;
            if (description.Length > 2000)
                description = description.Substring(0, 2000);
            Description = description;
            ResUser = Common.CurrentResource;
        }
    }
}
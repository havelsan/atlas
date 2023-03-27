
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
    public  abstract  partial class MedulaGlobals : TTObject
    {
#region Methods
        private static bool _isAcrobatReaderInstalled = false;
        public static bool IsAcrobatReaderInstalled
        {
            get
            {
                // Atlas için web sunucuda Acrobat Reader kurulumuş mu bakmak gereksiz
                // Sunucuda bu çaağrı hiç yapılmamalı. A.Ş. 17.12.2019
                throw new NotSupportedException();
            }
        }
        
#endregion Methods

    }
}
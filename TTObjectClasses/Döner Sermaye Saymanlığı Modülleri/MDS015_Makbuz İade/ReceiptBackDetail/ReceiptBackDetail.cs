
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


using TTStorageManager.Attributes;

namespace TTObjectClasses
{
    /// <summary>
    /// Muhasebe Yetkilisi Mutemedi Alındısı İade Detayı
    /// </summary>
    public  partial class ReceiptBackDetail : TTObject
    {
        [TTSerializeProperty]
        public bool Editable { get; set; }
        public partial class ReceiptBackReportDetailsQuery_Class : TTReportNqlObject 
        {
        }

    }
}
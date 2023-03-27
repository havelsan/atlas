
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
    /// <summary>
    /// İhalede Firmalardan İstenilen Gerekli Belgelerin Bilgilerini Tutan Sınıftır
    /// </summary>
    public  partial class NeededDocument : TTObject
    {
#region Methods
        override protected void OnConstruct()
        {
            if (Mandatory == null)
                Mandatory = true;
            if (CurrentStateDefID == null)
                CurrentStateDefID = NeededDocument.States.New;
        }
        
#endregion Methods

    }
}
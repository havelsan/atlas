
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
    /// Firma
    /// </summary>
    public  partial class MhSFirm : TTObject
    {
#region Methods
        public static MhSFirm GetActiveFirm(TTObjectContext context){
            MhSFirm firm;
            firm = (MhSFirm)context.QueryObjects("MhSFirm")[0];
            return firm;
        }
        
#endregion Methods

    }
}
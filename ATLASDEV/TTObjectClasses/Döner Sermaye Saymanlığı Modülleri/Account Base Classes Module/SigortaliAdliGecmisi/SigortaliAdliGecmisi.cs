
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
    /// Sigortalı Adli Geçmişi
    /// </summary>
    public  partial class SigortaliAdliGecmisi : TTObject
    {
#region Methods
        public SigortaliAdliGecmisi(TTObjectContext _objectContext, Patient _patient,string _provTarihi,string _provTipi,string _tckNo):this(_objectContext)
        {
            Patient = _patient;
            provTarihi = _provTarihi ;
            provTipi = _provTipi;
            tckNo = _tckNo;
        }
        
#endregion Methods

    }
}
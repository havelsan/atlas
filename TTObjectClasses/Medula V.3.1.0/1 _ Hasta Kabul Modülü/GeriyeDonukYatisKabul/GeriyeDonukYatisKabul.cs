
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
    /// Geriye Dönük Yatış Kabul
    /// </summary>
    public  partial class GeriyeDonukYatisKabul : BaseHastaKabul
    {
        public partial class GetGeriyeDonukYatisKabulWillBeSentToMedulaRQ_Class : TTReportNqlObject 
        {
        }

    }
}
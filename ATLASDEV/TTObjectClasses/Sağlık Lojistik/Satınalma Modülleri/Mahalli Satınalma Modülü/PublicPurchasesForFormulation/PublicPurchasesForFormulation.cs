
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
    /// Mahalli Satınalmada Fiyat Tespiti İçin Kullanılan "Kamu Kurum Alımları" İçin Kullanılan Sınıftır
    /// </summary>
    public  partial class PublicPurchasesForFormulation : TTObject
    {
        public partial class GetPublicPurchasesByProjectID_Class : TTReportNqlObject 
        {
        }

    }
}
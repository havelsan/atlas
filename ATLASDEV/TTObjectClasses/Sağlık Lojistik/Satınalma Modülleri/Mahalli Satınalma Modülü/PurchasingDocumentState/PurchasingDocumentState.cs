
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
    /// Mahalli Satınalmada İhale İçin Gerekli Olup Firmaların Getirmesi Gereken Belgeler İçin Kullanılan Sınıftır. Her Firmanın Getirmesi Gereken Her Belge İçin Ayrı Bir Instance Yaratılarak Durumları Bu Sınıf Ãœzerinden Takip Edilir
    /// </summary>
    public  partial class PurchasingDocumentState : TTObject
    {
        public partial class GetUnEligibleDocuments_Class : TTReportNqlObject 
        {
        }

    }
}
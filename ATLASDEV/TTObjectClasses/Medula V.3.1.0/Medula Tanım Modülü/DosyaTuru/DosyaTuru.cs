
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
    public  partial class DosyaTuru : BaseMedulaDefinition
    {
        public partial class New_Report_Definition_Class : TTReportNqlObject 
        {
        }

        protected override void PostUpdate()
        {
            #region PostUpdate
          if(dosyaTuruAdi != null)
            {
                dosyaTuruAdi_Shadow = dosyaTuruAdi.ToUpperInvariant();
            }
            #endregion PostUpdate
        }

        protected override void PostInsert()
        {
            #region PostInsert
            if (dosyaTuruAdi != null)
            {
                dosyaTuruAdi_Shadow = dosyaTuruAdi.ToUpperInvariant();
            }
            #endregion PostInsert
        }
    }
}
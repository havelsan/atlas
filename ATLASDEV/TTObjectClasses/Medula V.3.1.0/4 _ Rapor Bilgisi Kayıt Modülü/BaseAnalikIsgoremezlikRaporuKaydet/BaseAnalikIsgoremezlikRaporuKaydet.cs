
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
    public  abstract  partial class BaseAnalikIsgoremezlikRaporuKaydet : BaseRaporBilgisiKaydet
    {
#region Methods
        protected override void OnConstruct()
        {
            base.OnConstruct();

            if (((ITTObject)this).IsNew)
            {
                raporGirisDVO.analikRapor = new AnalikIsgoremezlikRaporDVO(ObjectContext);
                raporGirisDVO.analikRapor.raporDVO = new RaporDVO(ObjectContext);
                raporGirisDVO.analikRapor.raporDVO.turu = "6";
                raporGirisDVO.analikRapor.raporDVO.raporBilgisi = new RaporBilgisiDVO(ObjectContext);
            }
        }
        
#endregion Methods

    }
}
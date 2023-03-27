
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
    public  abstract  partial class BaseDogumRaporuKaydet : BaseRaporBilgisiKaydet
    {
#region Methods
        protected override void OnConstruct()
        {
            base.OnConstruct();

            if (((ITTObject)this).IsNew)
            {
                raporGirisDVO.dogumRapor = new DogumRaporDVO(ObjectContext);
                raporGirisDVO.dogumRapor.raporDVO = new RaporDVO(ObjectContext);
                raporGirisDVO.dogumRapor.raporDVO.turu = "7";
                raporGirisDVO.dogumRapor.raporDVO.raporBilgisi = new RaporBilgisiDVO(ObjectContext);
            }
        }
        
#endregion Methods

    }
}
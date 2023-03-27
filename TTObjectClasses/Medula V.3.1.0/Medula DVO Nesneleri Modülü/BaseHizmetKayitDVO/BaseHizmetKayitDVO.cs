
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
    public  abstract  partial class BaseHizmetKayitDVO : BaseMedulaObject
    {
#region Methods
        public void CreateHizmetSunucuRefNo()
        {
            if (((ITTObject)this).IsNew)
            {
                TTObjectContext objectContext = new TTObjectContext(false);
                HizmetSunucuRefNoGenerator hizmetSunucuRefNoGenerator = new HizmetSunucuRefNoGenerator(objectContext);
                hizmetSunucuRefNoGenerator.HizmetSunucuRefNo.GetNextValue();
                objectContext.Save();
                if (hizmetSunucuRefNoGenerator.HizmetSunucuRefNo.Value.HasValue == false)
                    throw new TTException(TTUtils.CultureService.GetText("M25960", "Hizmet Sunucu Referans Numarası alınamamıştır."));
                hizmetSunucuRefNo = hizmetSunucuRefNoGenerator.HizmetSunucuRefNo.Value.ToString();
            }
        }
        
#endregion Methods

    }
}
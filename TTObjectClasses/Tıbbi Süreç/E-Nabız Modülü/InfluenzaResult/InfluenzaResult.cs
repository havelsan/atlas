
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
    /// Influenza Sonuş Ekranı
    /// </summary>
    public  partial class InfluenzaResult : TTObject
    {
        public void SaveInfluenzaTani(InfluenzaServis.WebMethods.InfluenzaTaniBilgisi i, TTObjectContext objectContext)
        {
        }

        public void ControlReturnResult(InfluenzaServis.WebMethods.ServisSonucDurumu state,string message)
        {
            if (state == InfluenzaServis.WebMethods.ServisSonucDurumu.HATA)
                InfoMessageService.Instance.ShowMessage("Influenza bilgisi kaydetme işlemi sırasında bir hata oluştu. Lütfen işlemi manuel olarak daha sonra tekrar deneyiniz.\n Hata mesajı:" + message);
            else if (state == InfluenzaServis.WebMethods.ServisSonucDurumu.UYARI)
                InfoMessageService.Instance.ShowMessage("Influenza bilgisi kaydetme işlemi sırasında bir uyarı bilgisi gönderildi.\n Uyarı mesajı:" + message);
        }
    }
}
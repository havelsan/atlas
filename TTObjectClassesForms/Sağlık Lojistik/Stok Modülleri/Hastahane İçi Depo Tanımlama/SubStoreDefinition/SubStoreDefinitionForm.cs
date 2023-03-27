
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

using SmartCardWrapper;

using TTStorageManager;
using System.Runtime.Versioning;
using System.Windows.Forms;
using TTVisual;
namespace TTFormClasses
{
    /// <summary>
    /// Hastahane İçi Depo Tanımları
    /// </summary>
    public partial class SubStoreDefinitionForm : TTDefinitionForm
    {
        override protected void BindControlEvents()
        {
            MKYS_SendStore.Click += new TTControlEventDelegate(MKYS_SendStore_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            MKYS_SendStore.Click -= new TTControlEventDelegate(MKYS_SendStore_Click);
            base.UnBindControlEvents();
        }

        private void MKYS_SendStore_Click()
        {
#region SubStoreDefinitionForm_MKYS_SendStore_Click
   if(!((ITTObject)_SubStoreDefinition).IsNew)
            {
                MkysServis.birimInsertItem item = new MkysServis.birimInsertItem();
                item.birimKisaAdi = _SubStoreDefinition.Name;

                var hospitalSite = TTObjectClasses.SystemParameter.GetParameterValue("SITEID", "");

                MkysServis.birimKayitIslemleriSonuc t =  MkysServis.WebMethods.birimInsertSync(new Guid(hospitalSite), item);
                if (t.basariDurumu == true)
                {
                    MKYS_ServisDepo.AddMKYSServisDepo();
                    InfoBox.Show("Kayıt Tamamlandı.");
                    
                    TTObjectContext cont = new TTObjectContext(false);
                    BindingList<MKYS_ServisDepo> servisDepo = cont.QueryObjects<MKYS_ServisDepo>(" birimKayitNo = '"+ t.birimKayitNo +"'");
                    if (servisDepo.Count > 0)
                    {
                        _SubStoreDefinition.SubStoreMKYS = servisDepo[0];
                        this._SubStoreDefinition.DependantUnitID = servisDepo[0].bagliBirimID;
                        this._SubStoreDefinition.UnitRegistryNo = servisDepo[0].birimKayitNo;
                        this._SubStoreDefinition.UnitCode = servisDepo[0].birimKodu;
                    }
                }
                else
                    InfoBox.Show("MKYS Birim Kayıt Yapılamadı.");
            }
            else
            {
                throw new TTException("Önce Sisteme Kaydediniz.!");
            }
#endregion SubStoreDefinitionForm_MKYS_SendStore_Click
        }
    }
}
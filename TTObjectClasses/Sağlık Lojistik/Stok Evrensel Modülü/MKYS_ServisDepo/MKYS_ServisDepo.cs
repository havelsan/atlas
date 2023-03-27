
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
    public  partial class MKYS_ServisDepo : TerminologyManagerDef
    {
        public partial class GetMKYS_ServisDepoList_Class : TTReportNqlObject 
        {
        }

#region Methods
        public static void AddMKYSServisDepo()
        {
            MkysServis.birimItem[] birimItems = MkysServis.WebMethods.birimGetDataSync(Sites.SiteLocalHost);
            
            for (int i =0; i < birimItems.Length; i++)
            {
                TTObjectContext objectContext = new TTObjectContext(false);
                string filter = "(BIRIMKAYITNO = " + birimItems[i].birimKayitNo.ToString() + " )";
                MKYS_ServisDepo foundRec = null;

                BindingList <MKYS_ServisDepo> bindingList = objectContext.QueryObjects<MKYS_ServisDepo>(filter);
                if(bindingList != null  && bindingList.Count > 0 )
                    foundRec = bindingList[0];

                if ( foundRec == null )
                {
                    MKYS_ServisDepo servisDepo = new MKYS_ServisDepo(objectContext);

                    servisDepo.bagliBirimID = birimItems[i].bagliBirimID;
                    servisDepo.birimAdi = birimItems[i].birimAdi;
                    servisDepo.birimKayitNo = birimItems[i].birimKayitNo;
                    servisDepo.birimKisaAdi = birimItems[i].birimKisaAdi;
                    servisDepo.birimKodu = birimItems[i].birimKodu;
                    servisDepo.faaliyetDurumu = birimItems[i].faaliyetDurumu;
                    servisDepo.tur = birimItems[i].tur;
                }
                else
                {
                    foundRec.bagliBirimID = birimItems[i].bagliBirimID;
                    foundRec.birimAdi = birimItems[i].birimAdi;
                    foundRec.birimKayitNo = birimItems[i].birimKayitNo;
                    foundRec.birimKisaAdi = birimItems[i].birimKisaAdi;
                    foundRec.birimKodu = birimItems[i].birimKodu;
                    foundRec.faaliyetDurumu = birimItems[i].faaliyetDurumu;
                    foundRec.tur = birimItems[i].tur;
                }
                objectContext.Save();
                objectContext.Dispose();
            }
        }
        
#endregion Methods

    }
}
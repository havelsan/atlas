
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
    public partial class EmergencyWatchDefForm : TTDefinitionForm
    {
        override protected void BindControlEvents()
        {
            ttbutton1.Click += new TTControlEventDelegate(ttbutton1_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            ttbutton1.Click -= new TTControlEventDelegate(ttbutton1_Click);
            base.UnBindControlEvents();
        }

        private void ttbutton1_Click()
        {
#region EmergencyWatchDefForm_ttbutton1_Click
   TTObjectContext context = new TTObjectContext(true);
         string ipAddr = TTObjectClasses.SystemParameter.GetParameterValue("ACIL112IP", null);
         TTUtils.TTWebServiceUri  uri= new TTUtils.TTWebServiceUri(ipAddr);
       string userName112 = TTObjectClasses.SystemParameter.GetParameterValue("ACIL112USERNAME", null);
       string password112 = TTObjectClasses.SystemParameter.GetParameterValue("ACIL112PASSWORD", null);


       List<Acil112Servis.PersonelBilgileri> nobetciListesi = new List<Acil112Servis.PersonelBilgileri>();
        int i = 0;
        foreach (EmergencyWatchPersonelDef item in _EmergencyWatchDef.EmergencyWatchPersonelDefs)
        {
            if ( item.ResUser.EmploymentRecordID != null)
            {

                TTObjectClasses.Acil112Servis.PersonelBilgileri personelBilgileri = new TTObjectClasses.Acil112Servis.PersonelBilgileri();
                if(item.ResUser.UserResources.Count>0)
                {
                     personelBilgileri.bolum = item.ResUser.UserResources[0].Resource.Name != null ? item.ResUser.UserResources[0].Resource.Name.ToString() : null;
                }
                if( item.ResUser.ResourceSpecialities.Count>0)
                {
                    personelBilgileri.brans = item.ResUser.ResourceSpecialities[0].Speciality.Name != null ? item.ResUser.ResourceSpecialities[0].Speciality.Name.ToString() : null;
                }
                personelBilgileri.gorev = item.ResUser.UserType != null ? item.ResUser.UserType.ToString() : null;
                personelBilgileri.personelSicilNo = item.ResUser.EmploymentRecordID != null ? item.ResUser.EmploymentRecordID.ToString() : null;
                personelBilgileri.nobetTarihiBaslangic = item.BaslangicTarihi != null ? Convert.ToDateTime(item.BaslangicTarihi).ToString("yyyy-MM-dd HH:mm:ss") : null;
                personelBilgileri.nobetTarihiBitis = item.BitisTarih != null ? Convert.ToDateTime(item.BitisTarih).ToString("yyyy-MM-dd HH:mm:ss") : null;
                personelBilgileri.personelAdi = item.ResUser.Person.Name;
                personelBilgileri.personelSoyadi = item.ResUser.Person.Surname;
                personelBilgileri.telefon = item.ResUser.PhoneNumber != null ? item.ResUser.PhoneNumber.ToString() : null;
               // personelBilgileri.icap = item.Icapci != null ? item.Icapci.Value : false;
                nobetciListesi.Add(personelBilgileri);
               // personelBilgileriListesi[i] = (personelBilgileri);
                i++;
            }
        }
        Acil112Servis.PersonelBilgileri[] personelBilgileriListesi = new Acil112Servis.PersonelBilgileri[_EmergencyWatchDef.EmergencyWatchPersonelDefs.Count];

           //  Acil112Servis.NobetciPersonelBilgileri[] personelBilgileriListesi = new Acil112Servis.NobetciPersonelBilgileri[_EmergencyWatchDef.EmergencyWatchPersonelDefs.Count];
            personelBilgileriListesi = nobetciListesi.ToArray();
        //int sonucPersonelListesi = Acil112Servis.WebMethods.XXXXXXPersoneliniDonderSync(Sites.SiteLocalHost,uri,userName112, password112,personelBilgileriListesi);
        //if (sonucPersonelListesi > 0)
        //{

            int sonuc = TTObjectClasses.Acil112Servis.WebMethods.NobetciPersonelGonder_ArraySync(Sites.SiteLocalHost, uri, userName112, password112, personelBilgileriListesi);
       // int sonuc = TTObjectClasses.Acil112Servis.WebMethods.NobetciPersonelGondermeMetodu_ArraySync(Sites.SiteLocalHost, uri, userName112, password112, personelBilgileriListesi);
            if (sonuc > 0)
            {
                foreach (EmergencyWatchPersonelDef item in _EmergencyWatchDef.EmergencyWatchPersonelDefs)
                {
                    item.Bildirildi = true;
                }
            }
       // }
#endregion EmergencyWatchDefForm_ttbutton1_Click
        }
    }
}
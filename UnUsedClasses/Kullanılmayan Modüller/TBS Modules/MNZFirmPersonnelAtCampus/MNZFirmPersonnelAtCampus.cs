
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
    public  partial class MNZFirmPersonnelAtCampus : TTObject
    {
        protected override void PreInsert()
        {
#region PreInsert
            procedureToBeCalledIn_PreInsert();
#endregion PreInsert
        }

        protected override void PreUpdate()
        {
#region PreUpdate
            procedureToBeCalledIn_PreUpdate();
#endregion PreUpdate
        }

#region Methods
        public MNZFirmPersonnel getSelectedFirmPersonnel(Guid? guid)
        {
            if(guid.HasValue)
                return (MNZFirmPersonnel)ObjectContext.GetObject(guid.Value,"MNZFirmPersonnel");
            return null;
        }
        
        public void  checkForFirmPersonnelsAuthorizationStatus()
        {
            MNZFirmPersonnel fp;
            
            if((fp = FirmPersonnel) != null)
            { 
                if(fp.CurrentStateDefID.Value.Equals(MNZFirmPersonnel.States.Prohobited))
                {
                    throw new TTException("Seçilen Firma Personeli şu anda yasaklı durumdadır. İçeri giriş yapamaz.");
                }
                if(fp.CurrentStateDefID.Value.Equals(MNZFirmPersonnel.States.New))
                {
                    throw new TTException("Seçilmiş Firma Personelinin Kayıt İşleri hala devam etmektedit.");
                }
                Console.WriteLine("mati-->> Firma Pesoneli yasaklı deil.");
                return;
            }
            throw new TTException("Seçilen Firma Personeliylen ilgili kayıt bulunamadı.");
        }
        
        public string OrganizeDateTimeValue(char selection, DateTime? time)
        {
            if(selection == 'D')
            {
                return  ""+time.Value.Day+"."+time.Value.Month+"."+time.Value.Year;
            }
            return ""+time.Value.Hour+":"+time.Value.Minute+":"+time.Value.Second;
        }
        
        public void controlFirmPersonnelAuthorizationTimes()
        {
            bool hasAuthorization = false;
            MNZFirmPersonnel fp;
            IList allowedPersonnelVisitTimeList;
            
            if((fp = FirmPersonnel) != null)
            {
                allowedPersonnelVisitTimeList = fp.PersonnelVisit;
                foreach(MNZPersonnelVisit pv in allowedPersonnelVisitTimeList )
                {
                    if(pv.VisitDate.Value.Date.CompareTo(VisitDate.Value.Date) == 0)
                    {
                        Console.WriteLine("mati --> Firma Personeli İçeriye Girebilir");
                        hasAuthorization = true;
                        break;
                    }
                }
                Console.WriteLine("mati --> New version Counting ... "+allowedPersonnelVisitTimeList.Count);
                if(hasAuthorization == false)
                    throw new TTException("Lütfen Tarihleri Kontrol ediniz. Personelin içeriye girme izni yoktur");
                //throw new TTException("Olesine bi excception yaw silecm sonra :S");
            }
            else
                throw new TTException("Personel Seçmediniz");
            
        }
        
        public void procedureToBeCalledIn_PreInsert()
        {
            controlFirmPersonnelAuthorizationTimes();
            if(MNZProhibitedPerson.searchForProhobitedPerson(FirmPersonnel))
                throw new TTException("Firma personeli yasaklı kişiler listesinde bulunuyor. İçeri giremez");
            else
                Console.WriteLine("mati-->> Personelin yasaklı kişiler listesinde kaydı yok. İçeri girsin");
            if(LisencePlate != null)
            {
                if(MNZVehicle.checkForProhobitedVehicle(LisencePlate,FirmPersonnel))
                    throw new TTException("Personelin kullandığı araç yasaklı araçlar listesinde bulunuyor. Giriş yapamaz. ");
                else
                    Console.WriteLine("Araç da temiz. o da geçsin bakalım");
            }
        }
       
        public void procedureToBeCalledIn_PreUpdate()
        {
            controlFirmPersonnelAuthorizationTimes();
            if(MNZProhibitedPerson.searchForProhobitedPerson(FirmPersonnel))
                throw new TTException("Firma personeli yasaklı kişiler listesinde bulunuyor. İçeri giremez");
            else
                Console.WriteLine("mati-->> Personelin yasaklı kişiler listesinde kaydı yok. İçeri girsin");
            if(LisencePlate != null)
            {
                if(MNZVehicle.checkForProhobitedVehicle(LisencePlate,FirmPersonnel))
                    throw new TTException("Personelin kullandığı araç yasaklı araçlar listesinde bulunuyor. Giriş yapamaz. ");
                else
                    Console.WriteLine("Araç da temiz. o da geçsin bakalım");
            }
        }
        
        public Guid? getCurrentState()
        {
            return CurrentStateDefID;
        }
        
#endregion Methods

    }
}

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
    /// Firma Personeli
    /// </summary>
    public  partial class MNZFirmPersonnel : MNZPerson
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
        public void procedureToBeCalledIn_PreInsert()
        {
            controlFirmPersonelProperties();          
        }
        
        public void procedureToBeCalledIn_PreUpdate()
        {
            controlFirmPersonelProperties();
        }
        
        public void controlFirmPersonelProperties()
        {
            if(NationalIdentity != null && NationalIdentity.Length != 11)
                throw new TTException("\"Tc Kimlik No \"11 hane olmalıdır");
            if(BirthDate.HasValue && BirthDate.Value >= DateTime.Today)
                throw new TTException("\"Doğum Günü\" bugunden sonraki bir tarih olamaz");
            if(LisencePlate != null){
                if(MNZVehicle.checkForProhobitedVehicle(LisencePlate,this)) 
                    throw new TTException("Girilmiş olan plaka yasaklı araçlar listesinde bulunmaktadır\n");
                else
                    Console.WriteLine("mati -->> Firma personelinin aracı yasaklı deil");
            }
            if(NationalIdentity != null )
            {
                if(MNZProhibitedPerson.searchForProhobitedPerson(this))
                    throw new TTException("Firma personeli yasaklılar listesinde bulunmaktadır\n");
                else
                    Console.WriteLine("mati -->> Bu persoel yasaklılar listesinde deildir");
            }
        }
        
#endregion Methods

    }
}
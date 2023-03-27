
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
    /// Ziyaretçi
    /// </summary>
    public  partial class MNZVisitor : MNZPerson
    {
        protected override void PreInsert()
        {
#region PreInsert
            
            procedureToBeCalledIn_PreInsert();

#endregion PreInsert
        }

        protected override void PostUpdate()
        {
#region PostUpdate
            
            procedureToBeCalledIn_PreUpdate();

#endregion PostUpdate
        }

#region Methods
        public void procedureToBeCalledIn_PreInsert()
        {
            controlNewVisitorProperties();
            if(LisencePlate != null)
            {
                if(MNZVehicle.checkForProhobitedVehicle(LisencePlate,this))
                {
                    throw new TTException("Plakası sorgulanan aracın  giriş-çıkışı yasaklanmıştır.");   
                }
                Console.WriteLine("mati -->> al abicim arabayı içeriye");
            }
            if(NationalIdentity != null)
            {
                if(MNZProhibitedPerson.searchForProhobitedPerson(this))
                {  
                    throw new TTException("Tc Kimlik Nosu sorgulanan zyaretçinin giriş-çıkışı yasaklanmıştır.");
                }
                Console.WriteLine("mati -->> adam temiz yaw al içeri ");
            }
        }
        
        public void procedureToBeCalledIn_PreUpdate()
        {
            controlNewVisitorProperties();
            if(LisencePlate != null)
            {
                if(MNZVehicle.checkForProhobitedVehicle(LisencePlate,this))
                {
                    throw new TTException("Plakası sorgulanan aracın  giriş-çıkışı yasaklanmıştır.");   
                }
                Console.WriteLine("mati -->> al abicim arabayı içeriye");
            }
            if(NationalIdentity != null)
            {
                if(MNZProhibitedPerson.searchForProhobitedPerson(this))
                {
                    throw new TTException("Tc Kimlik Nosu sorgulanan zyaretçinin giriş-çıkışı yasaklanmıştır.");
                }
                Console.WriteLine("mati -->> adam temiz yaw al içeri ");
            }
        }
        
        public void controlNewVisitorProperties()
        {
            string errorString = "";
            if(CurrentStateDefID.Value.Equals(MNZVisitor.States.Exit))
            {
                if(ExitTime == null)
                {
                    errorString = "\"Çıkış Saati\" alanı boş bırakılamaz.\n";
                    throw new TTException(errorString);
                }
                return;
            }
            Console.WriteLine("Abicim değişmiyomu yaw kanser olcam");
            if(NationalIdentity.Length != 11)
                errorString += "TC Kimlik No 11 haneden oluşmalıdır.";
            if(!BirthDate.HasValue || (BirthDate.HasValue && BirthDate >= DateTime.Today))
                errorString += "\"Doğum Günü\" alanı boş bırakılamaz veya bugunden sonraki bir tarih olamaz.\n";
            if(errorString != "")
                throw new Exception(errorString);
        }
        
        public Guid? getCurrentState()
        {
            return CurrentStateDefID;
        }
        
        public IList getVisitorList()
        {
            return ObjectContext.QueryObjects("MNZVISITOR");
        }
        
#endregion Methods

    }
}

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
    /// Araç
    /// </summary>
    public  partial class MNZVehicle : MNZActor
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

        protected void PostTransition_New2Complete()
        {
            // From State : New   To State : Complete
#region PostTransition_New2Complete
            checkVehicleProperties();
#endregion PostTransition_New2Complete
        }

#region Methods
        public void checkVehicleProperties()
        {
            string errorString = "";
            IList vehicleList;
            
            if(LicencePlate != null){
                if(checkForProhobitedVehicle(LicencePlate,this))
                    throw new TTException("Bu araç zaten yasaklı araçlar da tanımlıdır");
                Console.WriteLine("mati -->> taam yaw araa temiz kaydet");
            }
        }
        
        public static bool checkForProhobitedVehicle(string licencePlate,MNZActor actor)
        {
            string MNZVEHICLE = "MNZVEHICLE";
            IList vehicleList;
            
            vehicleList = actor.ObjectContext.QueryObjects(MNZVEHICLE);
            
            foreach(MNZVehicle vehicle in vehicleList)
            {
                Console.WriteLine("mati -- > Plaka no : "+vehicle.LicencePlate);
                if(!actor.ObjectID.Equals(vehicle.ObjectID) && arrangeLicencePlate(licencePlate).CompareTo(arrangeLicencePlate(vehicle.LicencePlate)) == 0)
                    return true;
            }
            return false;            
        }
        
        public static string arrangeLicencePlate(string licencePlate)
        {
            return licencePlate.Replace(" ","").ToUpper();
        }
        public void giveDefaultValue()
        {
            if(!BannedDate.HasValue)
                BannedDate = DateTime.Today;
        }
        public void procedureToBeCalledIn_PreInsert()
        {
             checkVehicleProperties();
        }
        public void procedureToBeCalledIn_PreUpdate()
        {
            checkVehicleProperties();
        }
        
#endregion Methods

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(MNZVehicle).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == States.New && toState == States.Complete)
                PostTransition_New2Complete();
        }

    }
}
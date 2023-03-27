
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
    /// Yasaklı Ziyaretçi
    /// </summary>
    public  partial class MNZProhibitedPerson : MNZPerson
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
            Console.WriteLine("mati -->> yaw neden çalışmıyosun");
            procedureToBeCalledIn_PreUpdate();
#endregion PreUpdate
        }

#region Methods
        public void procedureToBeCalledIn_PreInsert()
        {
            Console.WriteLine("mati -->> Inside pre ınsert");
            checkProhobitedPersonsProperties();
            if(NationalIdentity != null)
                if(MNZProhibitedPerson.searchForProhobitedPerson(this))
                    throw new TTException("Verileri girilen kişi daha sistemde tanımlı bir kişidir");
                Console.WriteLine("mati -->> Bunun sapıkası yokmuş yaw");
        }
        
        public void procedureToBeCalledIn_PreUpdate()
        {
            Console.WriteLine("mati -->> Inside pre update");
            checkProhobitedPersonsProperties();
            if(NationalIdentity != null)
                if(MNZProhibitedPerson.searchForProhobitedPerson(this))
                    throw new TTException("Verileri girilen kişi daha sistemde tanımlı bir kişidir");
                Console.WriteLine("mati -->> Bunun sapıkası yokmuş yaw");
        }
        
        public void checkProhobitedPersonsProperties()
        {
            string errorString = "";
            
            if(NationalIdentity != null && NationalIdentity.Length != 11)
                errorString += "\"Tc Kimlik No\" 11 hane olmalıdır\n";
            if((!BirthDate.HasValue ) || (BirthDate.HasValue && BirthDate >= DateTime.Today))
                errorString += "\"Doğum Günü\" alanını kontrol ediniz.\n";
            if(errorString != "")
                throw new TTException(errorString);
        }
        
        public static bool searchForProhobitedPerson(MNZPerson personToSearch)
        {
            IList prohibitedPersonList;
            string MNZPROHIBITEDPERSON  = "MNZPROHIBITEDPERSON",query;
            MNZProhibitedPerson pPerson;
            
            query = "NATIONALIDENTITY = '"+personToSearch.NationalIdentity+"'";
            
            prohibitedPersonList = personToSearch.ObjectContext.QueryObjects(MNZPROHIBITEDPERSON,query);
            Console.WriteLine("mati -->> "+prohibitedPersonList.Count);
            Console.WriteLine("mati -->> type           <"+personToSearch.GetType()+">");
            Console.WriteLine("mati -->> type to string <"+personToSearch.GetType().ToString()+">");
            
           
            if(prohibitedPersonList.Count != 0 && !personToSearch.ObjectID.Equals(((MNZProhibitedPerson)prohibitedPersonList[0]).ObjectID))
            {
                return true;
            }
            
            return false;
        }
        
        public void giveDefaultValue()
        {
            if(!BannedDate.HasValue)
                BannedDate = DateTime.Today;
        }
        
#endregion Methods

    }
}
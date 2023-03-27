
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
    /// Beklenen Ziyaretçi
    /// </summary>
    public  partial class MNZExpectedVisitor : MNZPerson
    {
#region Methods
        public  void checkValues(string name, string surName, string nationalIdentity,DateTime? visitDate,DateTime? visitTime,VisitReason visitReason)
         {
               string exceptionString = "";
            
            if(name == null)
            {
                exceptionString = "Lütfen \"Adı\" alanını boş bırakmayınız\n";
                //throw new TTException("Lütfen \"Adı\" alanını boş bırakmayınız");
            }
            if(surName == null)
            {
               exceptionString += "Lütfen \"Soyadı\" alanını boş bırakmayınız\n";
            }
            if(nationalIdentity == null)
            {
                exceptionString += "Lütfen \"Tc Kimlik No\" alanını boş bırakmayınız\n";
            }
            if(nationalIdentity != null && nationalIdentity.Length != 11)
            {
                exceptionString += "Tc Kimlik No 11 Haneden oluşmak zorundadır. Lütfen Kontrol ediniz.\n";
            }
            if((!visitDate.HasValue ) || (visitDate.HasValue && visitDate > DateTime.Today))
            {
                exceptionString += "Lütfen \"Doğum Günü\" alanını kontrol ediniz.\n";
            }
            if(visitReason == null){
                 exceptionString += "Lütfen \"Ziyaret Sebebi\"' ni seçiniz.\n";    
            }
            if(exceptionString != "")
            {
                throw new TTException(exceptionString);
            }
         }
        
#endregion Methods

    }
}

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
    /// Sağlık Net Protokol
    /// </summary>
    public  partial class SaglikNetProtokol : TTObject
    {
#region Methods
        /* asagıdakı kod hatalı oldugu ıcın commentlendı    
        void deneme()
        {
            List<string> l = new List<string>();
            l.Where(x => x == "a");

            TTObjectContext o = new TTObjectContext(false);
            var lst = Patient.GetAllPatients(o).Where(x => x.Age > 10); // Dikkat , önce tüm hastaları veritabanından yükler , sonra memory den foreach gibi yapar , haberiniz ola.
        }
        */
        
#endregion Methods

    }
}
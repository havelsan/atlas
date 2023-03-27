
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
    /// DLR001_Malzeme
    /// </summary>
    public  partial class MLRSupply : TTObject
    {
        protected override void PreInsert()
        {
#region PreInsert
            checkValues(Unit1,Unit2,Unit3,Coefficient12,Coefficient23);
#endregion PreInsert
        }

#region Methods
        public static MLRSupply getMLRSupply(Guid g)
        {
            return null;
        }
        
        
        public void checkValues(SupplyUnit unit1, SupplyUnit unit2, SupplyUnit unit3, double? coefficient12, double? coefficient23)
        {
            string warning = "";
            if(unit1 == null && (unit2 != null || unit3 != null) )
            {
                warning = "Birim 1' i boş bırakılamaz.\n";
            }
            else if(unit1 != null && unit2 == null && unit3 != null)
            {
                 warning = "Birim 2 boş bırakılammaz\n";
            }
            else if(unit1 != null && unit2 != null && coefficient12 == null)
            {
                warning = "Katsayı12 boş bırakılamaz.\n";
            }
            else if(unit1 != null && unit2 != null && unit3 != null && coefficient23 == null)
            {
                warning = "Katsayı23 boş bırakılamaz.\n";
            }
            if(warning != "")
                throw new Exception(warning);
        }
        
#endregion Methods

    }
}
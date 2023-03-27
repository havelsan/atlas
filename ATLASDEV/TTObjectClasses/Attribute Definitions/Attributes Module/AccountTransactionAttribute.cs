
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
    public partial class AccountTransactionAttribute : TTAttributeInstance
    {
        public override void Run(AttributeWhenEnum when)
        {
#region Body
            int i =0 ;
            //i= i/i;
           // throw new TTException("attribute test" + i);
#endregion Body
        }

#region Methods
        //test interface 
       int i= 0;
       //i=i/i;
     //  if (this.yapayimmi)
     //  {
   //        throw new TTException("attribute test.." + i);
   //throw new TTException("Vaka " + this.Episode.CurrentStateDef.DisplayText + " durumda. Yeni işlem başlatılamaz.");        
     //  }
#endregion Methods

        public override void Check(TTAttribute attribute)
        {
#region CheckBody
        
#endregion CheckBody
        }
    }
}
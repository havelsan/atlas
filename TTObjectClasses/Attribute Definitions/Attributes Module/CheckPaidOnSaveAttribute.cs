
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
    public partial class CheckPaidOnSaveAttribute : TTAttributeInstance
    {
        public override void Run(AttributeWhenEnum when)
        {
            #region Body
            /*     if (Interface.GetCurrentAction() != null)
                {  
                    if (Interface.GetCurrentAction().Paid() == false)
                    {
                        throw new TTException("Parası Ödenmemiş");
                        // odenmemis kalemlerin listelenmesi yapilacak
                    }
                }
           */
            #endregion Body
        }

        public override void Check(TTAttribute attribute)
        {
#region CheckBody
        
#endregion CheckBody
        }
    }
}
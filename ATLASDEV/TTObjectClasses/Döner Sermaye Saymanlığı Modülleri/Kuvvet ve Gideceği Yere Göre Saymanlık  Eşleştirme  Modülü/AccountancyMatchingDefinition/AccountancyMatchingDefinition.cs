
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
    public  partial class AccountancyMatchingDefinition : TTDefinitionSet
    {
        public partial class AccountancyMatchingDefinitionNQL_Class : TTReportNqlObject 
        {
        }

#region Methods
        public static Accountancy GetAccountancy(TTObjectContext context,ForcesCommand forcesCommand,ResSection sendToResource){
            if(forcesCommand!=null){
                IList definitionList=null;
                if(sendToResource==null){
                    definitionList = AccountancyMatchingDefinition.GetAccountancyMatchingDefinitionByForcesCommand(context,forcesCommand.ObjectID.ToString());
                }else{
                    definitionList = AccountancyMatchingDefinition.GetAccountancyMatchingDefinitionByForcesCSendTo(context,sendToResource.ObjectID.ToString(),forcesCommand.ObjectID.ToString());
                }
                foreach(AccountancyMatchingDefinition definition in definitionList){
                    return  definition.Accountancy;
                }
            }
            return null;
        }
        
#endregion Methods

    }
}
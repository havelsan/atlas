
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
    public partial class AutoDocumentNumberAttribute : TTAttributeInstance
    {
        public override void Run(AttributeWhenEnum when)
        {
#region Body
            TTSequence seqRegistrationNumber = Interface.GetRegistrationNumberSeq();
            TTSequence seqNumberSequence = Interface.GetSequenceNumberSeq();

            if (seqRegistrationNumber.Value == null && seqNumberSequence.Value == null)
            {
                DateTime transactionDate;
                if (Interface.GetTransactionDate().HasValue)
                    transactionDate = (DateTime)Interface.GetTransactionDate();
                else
                    throw new TTException(SystemMessage.GetMessage(519));

                TTObjectDef objectDef = Interface.GetObjectDef();

                MainStoreDefinition mainStore = null;
                if (Interface.GetStore() is MainStoreDefinition)
                    mainStore = (MainStoreDefinition)Interface.GetStore();
                if (Interface.GetDestinationStore() is MainStoreDefinition)
                    mainStore = (MainStoreDefinition)Interface.GetDestinationStore();

                if (mainStore == null)
                    throw new TTException(SystemMessage.GetMessage(520));

                seqRegistrationNumber.GetNextValue(mainStore.ObjectID.ToString(), transactionDate.Year);
                seqNumberSequence.GetNextValue(objectDef.CodeName, transactionDate.Year);
            }
#endregion Body
        }

        public override void Check(TTAttribute attribute)
        {
#region CheckBody
        
#endregion CheckBody
        }
    }
}
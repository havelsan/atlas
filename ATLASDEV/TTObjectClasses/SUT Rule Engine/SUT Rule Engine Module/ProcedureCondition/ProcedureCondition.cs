
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
    public  partial class ProcedureCondition : RuleConditionBase
    {
#region Methods
        public bool IsSuitable(List<ISUTInstance> subactionProcedures)
        {
            switch ((int)OperatorType)
            {
                case (int)OperatorTypeEnum.Equal:
                    return ExistProcedure(subactionProcedures);
                case (int)OperatorTypeEnum.NotEqual:
                    return !ExistProcedure(subactionProcedures);
                default:
                    return false;
            }
        }

        private bool ExistProcedure(List<ISUTInstance> subactionProcedures)
        {
            foreach (ISUTInstance subactionProcedure in subactionProcedures)
                if (ProcedureObject.ObjectID == subactionProcedure.GetSUTRulableObject().GetObjectID())
                    return true;
            return false;
        }
        
#endregion Methods

    }
}

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
    public partial class AccountOperationStateAttribute : TTAttributeInstance
    {
        private IAccountOperation Interface;

        public AccountOperationConditionEnum Condition
        {
            get {return (AccountOperationConditionEnum)this["Condition"];}
        }

        public AccountOperationTimeEnum PreAccounting
        {
            get {return (AccountOperationTimeEnum)this["PreAccounting"];}
        }

        public AccountOperationStateAttribute(TTObjectContext objectContext, TTAttributeDef attributeDef, IAccountOperation Interface, Dictionary<string, object> parameterValues) : base(objectContext, attributeDef, parameterValues)
        {
            this.Interface = Interface;
        }

    }
}
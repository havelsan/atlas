
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
    public partial class ActiveIngredientDefinition : TerminologyManagerDef
    {
        public partial class GetActiveIngredientDefinitions_Class : TTReportNqlObject
        {
            public override bool Equals(object obj)
            {
                var item = obj as GetActiveIngredientDefinitions_Class;
                if (item == null)
                {
                    return false;
                }
                return ObjectID.Equals(item.ObjectID);
            }

            public override int GetHashCode()
            {
                return ObjectID.GetHashCode();
            }
        }

        public partial class GetActiveIngredientListReportQuery_Class : TTReportNqlObject
        {

        }

        #region Methods
        public override SendDataTypesEnum? GetMySendDataTypesEnum()
        {
            return SendDataTypesEnum.ActiveIngredientDefinitionInfo;
        }
        #endregion Methods

    }
}
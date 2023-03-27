
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
    /// Sağ Sol
    /// </summary>
    public partial class SagSol : BaseMedulaDefinition
    {
        public partial class GetSagSolDefinitionQuery_Class : TTReportNqlObject
        {
        }

        #region Methods
        public string getSagSol_LR()
        {
            if (sagSolKodu == "1")
                return "R";
            else if (sagSolKodu == "2")
                return "L";

            return null;
        }



        #endregion Methods

    }
}
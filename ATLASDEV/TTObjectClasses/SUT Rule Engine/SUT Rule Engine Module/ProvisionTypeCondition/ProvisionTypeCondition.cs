
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
    public  partial class ProvisionTypeCondition : RuleConditionBase
    {
#region Methods
        public bool IsSuitable(ISUTEpisodeAction episodeAction)
        {
            switch ((int)OperatorType)
            {
                case (int)OperatorTypeEnum.Equal:
                    return ProvisionType.provizyonTipiKodu == episodeAction.GetMedulaHastaKabul().BaseHastaKabul.provizyonGirisDVO.provizyonTipi;
                case (int)OperatorTypeEnum.NotEqual:
                    return !(ProvisionType.provizyonTipiKodu == episodeAction.GetMedulaHastaKabul().BaseHastaKabul.provizyonGirisDVO.provizyonTipi);
                default:
                    return false;
            }
            //return false;
        }
        
#endregion Methods

    }
}
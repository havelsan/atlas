
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
    public  partial class SocialSecurityTypeCondition : RuleConditionBase
    {
#region Methods
        public bool IsSuitable(ISUTEpisodeAction episodeAction)
        {
            switch ((int)OperatorType)
            {
                case (int)OperatorTypeEnum.Equal:
                    return SocialSecurityType.devredilenKurumKodu== episodeAction.GetMedulaHastaKabul().BaseHastaKabul.provizyonGirisDVO.devredilenKurum;
                case (int)OperatorTypeEnum.NotEqual:
                    return !(SocialSecurityType.devredilenKurumKodu == episodeAction.GetMedulaHastaKabul().BaseHastaKabul.provizyonGirisDVO.devredilenKurum);
                default:
                    return false;
            }
            //return false;
        }
        
#endregion Methods

    }
}
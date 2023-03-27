
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
    public  partial class TherapyKindCondition : RuleConditionBase
    {
#region Methods
        public bool IsSuitable(ISUTEpisodeAction episodeAction)
        {
            switch ((int)OperatorType)
            {
                case (int)OperatorTypeEnum.Equal:
                    return TherapyKind.tedaviTuruKodu == episodeAction.GetMedulaHastaKabul().BaseHastaKabul.provizyonGirisDVO.tedaviTuru;
                case (int)OperatorTypeEnum.NotEqual:
                    return !(TherapyKind.tedaviTuruKodu == episodeAction.GetMedulaHastaKabul().BaseHastaKabul.provizyonGirisDVO.tedaviTuru);
                default:
                    return false;
            }
            //return false;
        }
        
#endregion Methods

    }
}

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
    public partial interface IStartFromNewActionInPatientFolder : IAttributeInterface
    {
#region Methods
          bool IsEpisodeStatesIgnored();
    IList<Episode> LimiteEpisodesOfPatientToStartFromNewActionInPatientFolder( IList<Episode> episodes);
    void SetPropertiesWhenStartFromNewActionInPatientFolder(Episode episode);//Yeni süreçden işlem başlatılırken  Objeye özel extra alanlar set edilmek isteniyorsa

        Episode GetEpisode();

        void SetEpisode(Episode value);

        MenuDefinition GetMenuDefinition();

        void SetMenuDefinition(MenuDefinition value);

        ActionTypeEnum GetActionType();
        #endregion Methods
    }
}
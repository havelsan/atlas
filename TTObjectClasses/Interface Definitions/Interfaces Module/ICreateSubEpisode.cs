
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
    public partial interface ICreateSubEpisode : IAttributeInterface
    {
        #region Methods

        bool IsNewSubEpisodeNeeded();

        DateTime SubEpisodeOpeningDate();

        DiagnosisCopyEnum GetDiagnosisCopyEnum();

        bool Sent101Package();

        void FillLocalSEPProperties(ref SubEpisodeProtocol sep);

        ISubEpisodeStarter GetSubEpisodeStarter();

        void SetSubEpisodeStarter(ISubEpisodeStarter value);

        SubEpisode GetSubEpisodeCreatedByMe();

        void SetSubEpisodeCreatedByMe(SubEpisode value);

        SubEpisodeStatusEnum GetSubEpisodePatientStatus();

        void SetSubEpisodePatientStatus(SubEpisodeStatusEnum value);

        ResSection GetSubEpisodeResSection();

        void SetSubEpisodeResSection(ResSection value);

        SpecialityDefinition GetSubEpisodeSpeciality();

        void SetSubEpisodeSpeciality(SpecialityDefinition value);

        Episode GetEpisode();

        void SetEpisode(Episode value);

        List<EpisodeAction> GetLinkedEpisodeActionsForSubEpisode();

        void SetLinkedEpisodeActionsForSubEpisode(List<EpisodeAction> value);

        #endregion Methods
    }
}

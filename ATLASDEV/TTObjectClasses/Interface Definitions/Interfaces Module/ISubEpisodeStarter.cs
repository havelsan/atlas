
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
    public partial interface ISubEpisodeStarter : IAttributeInterface
    {
        DateTime SubEpisodeOpeningDate();
        DateTime SubEpisodeClosingDate();

        SubEpisode GetSubEpisode();

        void SetSubEpisode(SubEpisode value);

        Episode GetEpisode();

        void SetEpisode(Episode value);

        TTObjectStateDef GetCurrentStateDef();

        void SetCurrentStateDef(TTObjectStateDef value);

        SpecialityDefinition GetProcedureSpeciality();

        void SetProcedureSpeciality(SpecialityDefinition value);

        Guid GetObjectID();
    }
}
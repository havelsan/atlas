
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
    public partial interface IEpisodeActionPermission : IAttributeInterface, ITTBaseObject
    {
        ResUser GetProcedureDoctor();

        void GetProcedureDoctor(ResUser value);

        AuthorizedUser.ChildAuthorizedUserCollection GetAuthorizedUsers();

        Episode GetEpisode();

        void SetEpisode(Episode value);

        ResSection GetFromResource();

        void SetFromResource(ResSection value);

        ResSection GetMasterResource();

        void SetMasterResource(ResSection value);

        ResSection GetSecondaryMasterResource();

        void SetSecondaryMasterResource(ResSection value);

        TTObjectStateDef GetCurrentStateDef();

        void SetCurrentStateDef(TTObjectStateDef value);
    }
}

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
    public partial interface ISUTEpisodeAction : IAttributeInterface
    {
        #region Methods

        List<ISUTInstance> SUTDiagnosisGrid();

        ISUTMaterialTotalAmount SUTMaterialTotalAmount(ISUTEpisodeAction episodeAction, Guid materialID);

        ISUTProcedureTotalAmount SUTProcedureTotalAmount(ISUTEpisodeAction episodeAction, Guid procedureID);

        ISUTMaterialTotalAmount NewSUTMaterialTotalAmount(Guid materialID);

        ISUTProcedureTotalAmount NewSUTProcedureTotalAmount(Guid procedureID);

        ISUTEpisode SUTEpisode { get; }

        List<ISUTInstance> SUTSubactionProcedures(Guid procedureID);

        PatientMedulaHastaKabul GetMedulaHastaKabul();


        #endregion Methods
    }
}
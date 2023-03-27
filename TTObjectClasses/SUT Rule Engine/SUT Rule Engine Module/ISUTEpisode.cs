
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
    public partial interface ISUTEpisode : IAttributeInterface
    {
#region Methods
     


        List<ISUTInstance> SUTDiagnosisGrid();

        ISUTMaterialTotalAmount SUTMaterialTotalAmount(ISUTEpisodeAction episodeAction, Guid materialID);

        ISUTProcedureTotalAmount SUTProcedureTotalAmount(ISUTEpisodeAction episodeAction, Guid procedureID);

        List<ISUTInstance> SUTSubactionProcedures(Guid procedureID);

        ISUTPatient SUTPatient { get; }

        PatientMedulaHastaKabul.ChildPatientMedulaHastaKabulCollection GetEpisodeMedulaHastaKabulleri();


        #endregion Methods
    }
}
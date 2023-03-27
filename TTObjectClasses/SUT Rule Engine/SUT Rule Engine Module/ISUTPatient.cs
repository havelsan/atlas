
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
    public partial interface ISUTPatient : IAttributeInterface
    {
#region Methods

        List<ISUTInstance> SUTDiagnosisGrid();

        List<ISUTInstance> SUTSubactionProcedures(Guid procedureID);

        List<ISUTInstance> SUTSubactionProcedures(Guid procedureID, DateTime startDate, DateTime endDate);

        ISUTMaterialTotalAmount SUTMaterialTotalAmount(ISUTEpisodeAction episodeAction, Guid materialID, DateTime startDate, DateTime endDate);

        ISUTProcedureTotalAmount SUTProcedureTotalAmount(ISUTEpisodeAction episodeAction, Guid procedureID, DateTime startDate, DateTime endDate);

        PatientMedulaHastaKabul.ChildPatientMedulaHastaKabulCollection GetPatientMedulaHastaKabulleri();

        SKRSCinsiyet GetSex();

        int? GetAge();

        int? GetAgeDay();

        int? GetAgeMonth();

        #endregion Methods
    }
}
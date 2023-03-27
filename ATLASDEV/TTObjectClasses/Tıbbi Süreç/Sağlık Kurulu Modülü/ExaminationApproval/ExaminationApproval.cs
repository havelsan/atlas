
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
    /// <summary>
    /// Muayene Onay Modülü
    /// </summary>
    public  partial class ExaminationApproval : BaseHealthCommitteeExamination, IWorkListEpisodeAction
    {
#region Methods
        /// <summary>
        /// Fork işlemleri için kullanılır. 
        /// </summary>
        /// <param name="episodeAction"></param>
        /// <param name="masterResource"></param>
       public ExaminationApproval(EpisodeAction masterAction, HospitalsUnitsGrid hospitalsUnits ):this(masterAction.ObjectContext)
        {

            CurrentStateDefID = ExaminationApproval.States.New;
            RequestExplanation= hospitalsUnits.Explanation;
            SetMandatoryEpisodeActionProperties(masterAction, (ResSection)hospitalsUnits.Unit,true);
        }
        
#endregion Methods

    }
}
﻿
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
    /// Muayene Katılım Payından Muaf Olan Birimler
    /// </summary>
    public  partial class PatientExamParticipUnit : TTDefinitionSet
    {
        protected override void PreDelete()
        {
#region PreDelete
            base.PreDelete();
            
            // PatientExamParticipationDef in update kontrolünün çalışması için
            if(PatientExamParticipationDef != null)
            {
                string temp = PatientExamParticipationDef.ExternalCode;
                PatientExamParticipationDef.ExternalCode = "-1";
                PatientExamParticipationDef.ExternalCode = temp;
            }

#endregion PreDelete
        }

    }
}
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
    public  partial class PatientExaminationForensicProcedure : SubActionProcedure
    {
        #region Methods
        public override void SetPerformedDate()
        {
            if (PerformedDate == null && CreationDate != null)
                PerformedDate = CreationDate.Value.AddMinutes(1);
            if (PerformedDate != null && CreationDate != null && CreationDate >= PerformedDate)
                PerformedDate = CreationDate.Value.AddMinutes(1);
        }
        protected override void PostInsert()
        {
            SetPerformedDate();
            base.PostInsert();
        }

        protected override void PostUpdate()
        {
            SetPerformedDate();
            base.PostUpdate();
        }

        #endregion Methods

    }
}
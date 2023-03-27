
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
    public  partial class Weight : VitalSign
    {
        public Weight(BaseNursingOrderDetails baseNursingOrderDetails) : this(baseNursingOrderDetails.ObjectContext)
        {
            if (baseNursingOrderDetails.Result != null && !string.IsNullOrEmpty(baseNursingOrderDetails.Result))
                Value = Convert.ToInt32(baseNursingOrderDetails.Result);

            SetDefaultVitalSignProperties(baseNursingOrderDetails);
        }
        override public string GetResult()
        {
            return Value == null ? string.Empty : Value.ToString();
        }

        protected override void PostInsert()
        {
            #region PostInsert
            EpisodeAction.Episode.Patient.Weight = Value;
            base.PostInsert();
            #endregion PostInsert
        }


      
    }
}
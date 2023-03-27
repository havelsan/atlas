
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
    /// Acil Kabul
    /// </summary>
    public  partial class PA_Emergency : PatientAdmission
    {
#region Methods
        protected override void OnConstruct()
        {
            base.OnConstruct();
            if (((ITTObject)this).IsNew == true)
            {/*
                IList list =ReasonForAdmission.GetByReasonAdmissionType(this.ObjectContext,AdmissionTypeEnum.Emergency);
                if (list.Count<1 )
                {
                    throw new Exception (SystemMessage.GetMessage(928));
                }
                else
                {
                    this.ReasonForAdmission=(ReasonForAdmission)list[0];
                }*/
            }
        }
         protected override void SetPatientGroup()
        {
          
        }
        
#endregion Methods

    }
}

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
    /// Hasta Yatış Alınan Eşyalar Sekmesi
    /// </summary>
    public  partial class InpatientAdmissionTakenMaterial : TTObject
    {
        public partial class GetInpatientAdmissionTakenMaterials_Class : TTReportNqlObject 
        {
        }

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        override protected void RunSetMemberValueScript(string memberName, object newValue)
        {
            switch (memberName)
            {
                case "EPISODE":
                    {
                        Episode value = (Episode)newValue;
#region EPISODE_SetParentScript
                        if(value!=null)
            {
                if(string.IsNullOrEmpty(PersonWhoGiveMaterials))
                {
                    PersonWhoGiveMaterials=value.Patient.FullName.ToString();
                }
                if(string.IsNullOrEmpty(PersonWhoTakeMaterials))
                {
                    PersonWhoTakeMaterials=Common.CurrentResource.Name.ToString();
                }
            }
#endregion EPISODE_SetParentScript
                    }
                    break;

            }
        }

#region Methods
        override public bool IsParentRelationReadonly(TTObjectRelationDef relDef)
        {
            if(((ITTObject)this).IsNew==true)
                return false;
            return true;
        }

        override public bool IsPropertyReadonly(TTObjectPropertyDef propDef)
        {
            if(((ITTObject)this).IsNew==true)
                return false;
            return true;
        }
        
#endregion Methods

    }
}
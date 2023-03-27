
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
    /// Değerli Eşyalar
    /// </summary>
    public  partial class BaseQuarantineValuableMaterial : TTObject
    {
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        override protected void RunSetMemberValueScript(string memberName, object newValue)
        {
            switch (memberName)
            {
                case "QUARANTINEPROCESSTYPE":
                    {
                        QuarantineProcessTypeEnum? value = (QuarantineProcessTypeEnum?)(int?)newValue;
#region QUARANTINEPROCESSTYPE_SetScript
                        if(value==QuarantineProcessTypeEnum.TakedFromPatient)
            {
                if(string.IsNullOrEmpty(PersonWhoGiveMaterials))
                {
                    PersonWhoGiveMaterials=Episode.Patient.FullName.ToString();
                }
                if(string.IsNullOrEmpty(PersonWhoTakeMaterials))
                {
                    PersonWhoTakeMaterials=Common.CurrentResource.Name.ToString();
                }
            }
            else if(value==QuarantineProcessTypeEnum.GivedToPatient)
            {
                    if(string.IsNullOrEmpty(PersonWhoGiveMaterials))
                    {
                        PersonWhoGiveMaterials=Common.CurrentResource.Name.ToString();
                    }
                    if(string.IsNullOrEmpty(PersonWhoTakeMaterials))
                    {
                        PersonWhoTakeMaterials=Episode.Patient.FullName.ToString();
                        
                    }
            }
#endregion QUARANTINEPROCESSTYPE_SetScript
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
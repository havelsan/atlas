
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
    public  partial class PathologyLabMaterial : BaseTreatmentMaterial
    {
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        override protected void RunSetMemberValueScript(string memberName, object newValue)
        {
            switch (memberName)
            {
                case "PATHOLOGY":
                    {
                        PathologyRequest value = (PathologyRequest)newValue;
#region PATHOLOGY_SetParentScript
                        Episode = value.Episode;
#endregion PATHOLOGY_SetParentScript
                    }
                    break;

                default:
                    base.RunSetMemberValueScript(memberName, newValue);
                    break;

            }
        }

        protected override void PreInsert()
        {
#region PreInsert
            base.PreInsert();

#endregion PreInsert
        }

#region Methods
        override public object GetDVO(AccountTransaction AccTrx)
        {
            return base.GetDVO(AccTrx);
        }
        
#endregion Methods

    }
}
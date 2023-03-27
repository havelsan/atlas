
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
    /// Devir İmza Alanı
    /// </summary>
    public  partial class CensusSignUser : TTObject
    {
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        override protected void RunSetMemberValueScript(string memberName, object newValue)
        {
            switch (memberName)
            {
                case "CENSUSSIGNUSERS":
                    {
                        ResUser value = (ResUser)newValue;
#region CENSUSSIGNUSERS_SetParentScript
                        if(value != null)
            {
                if (value.MilitaryClass != null)
                    ShortMilitaryClass = value.MilitaryClass.ShortName;
                else
                    ShortMilitaryClass = "-";

                if (value.Rank != null)
                    ShortRank = value.Rank.ShortName;
                else
                    ShortRank = "-";

                EmploymentRecordID = value.EmploymentRecordID;
                NameString = value.Name;
            }
#endregion CENSUSSIGNUSERS_SetParentScript
                    }
                    break;

            }
        }

    }
}
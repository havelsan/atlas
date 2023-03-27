
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
    public  partial class NursingCare : BaseNursingDataEntry
    {
        #region Methods
        //protected override bool IsReadOnly()
        //{
        //    if(((ITTObject)this).IsNew!=true)
        //        return true;

        //    return false;
        //}
        public override string GetApplicationSummary()
        {
            string tempString = String.Empty;

            if (NursingProblem != null && NursingProblem.ObjectID != null)
                tempString += " Problem: " + NursingProblem.Name + ",";

 
            int count = 0;
            foreach (var nr in NursingReasonGrids)
            {
                if (nr.NursingReason != null && nr.NursingReason.ObjectID != null)
                {
                    if (count > 1)
                    {
                        tempString += "...";
                        break;
                    }
                   
                    if (count == 0)
                        tempString += " Neden: ";
                    else
                        tempString += "-";
                   
                    tempString += (nr.NursingReason.Name.Length > 20 ?  nr.NursingReason.Name.Substring(0, 19) +".." : nr.NursingReason.Name) + ",";
                    count++;

                }
            }

            count = 0;
            foreach (var nc in NursingCareGrids)
            {
                if (nc.NursingCare != null && nc.NursingCare.ObjectID != null)
                {
                    if (count > 1)
                    {
                        tempString += "...";
                        break;
                    }
                    if (count == 0)
                        tempString += " Girşim: ";
                    else
                        tempString += "-";
                    tempString += (nc.NursingCare.Name.Length > 20 ? nc.NursingCare.Name.Substring(0, 19) + ".." : nc.NursingCare.Name) + ",";
                    count++;
                }
            }


            count = 0;
            foreach (var nt in NursingTargetGrids)
            {
                if (nt.NursingTarget != null && nt.NursingTarget.ObjectID != null)
                {
                    if (count > 1)
                    {
                        tempString += "...";
                        break;
                    }
                    if (count == 0)
                        tempString += " Hedef: ";
                    else
                        tempString += "-";
                    tempString += (nt.NursingTarget.Name.Length > 20 ? nt.NursingTarget.Name.Substring(0, 19) + ".." : nt.NursingTarget.Name)  + ",";
                    count++;
                }
            }

            if (Note != String.Empty)
                tempString += " Açıklama: " + Note;

            if (NursingResult != null)
            {
                tempString += " Sonuç: " + Common.GetDisplayTextOfDataTypeEnum(NursingResult);
            }

            return tempString;
        }

        #endregion Methods

    }
}
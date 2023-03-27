
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
    public  partial class NursingPupilSymptoms : BaseNursingDataEntry
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

            if (RightPupil != null)
            {
                tempString += " Sağ Pupil: " + Common.GetDisplayTextOfDataTypeEnum(RightPupil.Value) + ",";
            }

            if (LeftPupil != null )
            {
                tempString += " Sol Pupil: " + Common.GetDisplayTextOfDataTypeEnum(LeftPupil.Value) + ",";
            }

            if (RightPupilWideness != null)
            {
                tempString += " Sağ Pupil G.: " + Common.GetDisplayTextOfDataTypeEnum(RightPupilWideness.Value) + ",";
            }

            if (LeftPupilWideness != null)
            {
                tempString += " Sol Pupil G.: " + Common.GetDisplayTextOfDataTypeEnum(LeftPupilWideness.Value) + ",";
            }

            if (RightGleamRef != null)
            {
                tempString += " Sağ Ref: " + Common.GetDisplayTextOfDataTypeEnum(RightGleamRef.Value) + ",";
            }

            if (LeftGleamRef != null)
            {
                tempString += " Sol Ref: " + Common.GetDisplayTextOfDataTypeEnum(LeftGleamRef.Value) + ",";
            }

            return tempString;
        }

        public override string GetRowColor()
        {
            return string.Empty;
        }

        #endregion Methods

    }
}

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
    public  partial class BaseNursingPatientAndFamilyInstruction : BaseNursingDataEntry
    {
        public override string GetApplicationSummary()
        {
            string tempString = String.Empty;
            int _patientInstructionCount = 0, _companierInstructionCount = 0;

            foreach (var patientAndFamilyInstruction in NursingPatientAndFamilyInstructions)
            {
                if (patientAndFamilyInstruction.PatientGetInstruction.HasValue && patientAndFamilyInstruction.PatientGetInstruction.Value)
                    _patientInstructionCount++;
                if (patientAndFamilyInstruction.CompanionGetInstruction.HasValue && patientAndFamilyInstruction.CompanionGetInstruction.Value)
                    _companierInstructionCount++;

                if (_patientInstructionCount > 0 && _companierInstructionCount > 0)// ikisindende checklenen eğitimler varsa devamına bakmaya gerek yok boşuna dönmesin
                {
                    tempString = TTUtils.CultureService.GetText("M25805", "Hasta ve Yakınına eğitim verildi");
                    break;
                }
            }

            if (tempString == String.Empty)
            {
                if (_patientInstructionCount > 0)
                    tempString = TTUtils.CultureService.GetText("M25882", "Hastaya eğitim verildi");
                else if (_companierInstructionCount > 0)
                    tempString = TTUtils.CultureService.GetText("M25806", "Hasta yakınına eğitim verildi");
            }
            return tempString;
        }

        public override string GetRowColor()
        {
            return string.Empty;
        }
    }
}
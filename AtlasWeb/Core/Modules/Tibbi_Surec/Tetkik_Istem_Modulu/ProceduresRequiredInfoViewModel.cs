using System;
using System.Collections.Generic;
using System.Linq;
using TTObjectClasses;

namespace Core.Modules.Tibbi_Surec.Tetkik_Istem_Modulu
{
    public class ProceduresRequiredInfoViewModel
    {
        public List<RadiologyTest> RadiologyTestList = new List<RadiologyTest>();
        public List<LaboratoryProcedure> LaboratoryTestList = new List<LaboratoryProcedure>();
        public List<ProcedureDefinition> ProcedureObjectList = new List<ProcedureDefinition>();
        public List<PsychologyTest> PsychologyProcedureList = new List<PsychologyTest>();
        public List<PathologyTestProcedure> PathologyProcedureList = new List<PathologyTestProcedure>();
        public List<NuclearMedicineTest> NuclearMedicineTestList = new List<NuclearMedicineTest>();
        public List<ManipulationProcedure> ManipulationProcedureList = new List<ManipulationProcedure>();
        public List<RadiologyTestTypeDefinition> RadiologyTestTypeDefinitions = new List<RadiologyTestTypeDefinition>();
        public string ClinicAnemnesis;
        public Boolean copyDescription;
        public string textDescription;
    }
}
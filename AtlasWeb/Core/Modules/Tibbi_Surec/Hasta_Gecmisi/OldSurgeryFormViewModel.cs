//$9627515F
using System;
using System.Linq;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using System.Collections.Generic;

namespace Core.Controllers
{
    public partial class SurgeryServiceController
    {
        partial void PreScript_OldSurgeryForm(OldSurgeryFormViewModel viewModel, Surgery surgery, TTObjectContext objectContext)
        {
            if (surgery.SubEpisode != null)
            {
                viewModel.AdmissionNumber = isNullOrEmpty(surgery.SubEpisode.ProtocolNo);
            }

            viewModel.SurgeryDate = surgery.SurgeryStartTime;
            if (surgery.ProtocolNo != null)
            {
                viewModel.ProtocoNo = isNullOrEmpty(surgery.ProtocolNo.ToString());
            }

            if (surgery.ProcedureDoctor != null)
            {
                viewModel.ProcedureDoctor = isNullOrEmpty(surgery.ProcedureDoctor.Name);
            }

            if (surgery.SurgeryReport != null)
            {
                viewModel.SurgeryReport = isNullOrEmpty(surgery.SurgeryReport.ToString());
            }

            viewModel.SurgeryPersonnels = new List<OldSurgeryPersonnel>(); //Ameliyat Ekibi
            foreach (var item in surgery.AllSurgeryPersonnels)
            {
                OldSurgeryPersonnel personnel = new OldSurgeryPersonnel { Personnel = item.Personnel.Name, Role = Common.GetDisplayTextOfDataTypeEnum(item.Role) };
                viewModel.SurgeryPersonnels.Add(personnel);
            }

            viewModel.MainSurgeryProcedures = new List<OldSurgeryProcedure>(); //MainSurgeryler
            foreach (var item in surgery.MainSurgeryProcedures.Where(c => c.CurrentStateDefID != MainSurgeryProcedure.States.Cancelled))
            {
                OldSurgeryProcedure procedure = new OldSurgeryProcedure { IncisionType = item.IncisionType != null ? Common.GetDisplayTextOfDataTypeEnum(item.IncisionType) : "", Position = item.Position != null ? Common.GetDisplayTextOfDataTypeEnum(item.Position) : "", ProcedureSpeciality = item.Surgery.ProcedureSpeciality.Name, SurgeryName = item.ProcedureObject.Name };
                viewModel.MainSurgeryProcedures.Add(procedure);
            }

            viewModel.SubSurgeries = new List<OldSubSurgery>();
            foreach (var item in surgery.SubSurgeries) //SubSurgeryler
            {
                List<OldSurgeryPersonnel> subPersonnelList = new List<OldSurgeryPersonnel>();//KALDIRILMALI
                //foreach (var subPersonnel in item.SurgeryPersonnels) //SubSurgery Personelleri
                //{
                //    OldSurgeryPersonnel personnel = new OldSurgeryPersonnel{Personnel = subPersonnel.Personnel.Name, Role = Common.GetDisplayTextOfDataTypeEnum(subPersonnel.Role)};
                //    subPersonnelList.Add(personnel);
                //}

                List<OldSurgeryProcedure> subProcedureList = new List<OldSurgeryProcedure>();
                foreach (var subProcedures in item.SubSurgeryProcedures) //SubSurgery Procedureleri
                {
                    OldSurgeryProcedure procedure = new OldSurgeryProcedure { IncisionType = Common.GetDisplayTextOfDataTypeEnum(subProcedures.IncisionType), Position = Common.GetDisplayTextOfDataTypeEnum(subProcedures.Position), ProcedureSpeciality = subProcedures.ProcedureSpeciality.Name, SurgeryName = subProcedures.ProcedureObject.Name };
                    subProcedureList.Add(procedure);
                }

                OldSubSurgery subSurgery = new OldSubSurgery
                {
                    SubSurgeryReport = item.SurgeryReport != null ? item.SurgeryReport.ToString() : "",
                    SubSurgeryPersonnels = subPersonnelList,
                    SubSurgeryProcedures = subProcedureList
                };
            }

            if (surgery.AnesthesiaAndReanimation != null)
            {
                viewModel.AnesthesiaNote = isObjectNullOrEmpty(surgery.AnesthesiaAndReanimation.AnesthesiaNote);
                viewModel.AnesthesiaReport = isObjectNullOrEmpty(surgery.AnesthesiaAndReanimation.AnesthesiaReport);
                if (surgery.AnesthesiaAndReanimation.AnesthesiaTechnique != null)
                {
                    viewModel.AnesthesiaTechnique = Common.GetDisplayTextOfDataTypeEnum(surgery.AnesthesiaAndReanimation.AnesthesiaTechnique);
                }

                viewModel.AnesthesiaProtocolNo = surgery.AnesthesiaAndReanimation.ProtocolNo.ToString();
                if (surgery.AnesthesiaAndReanimation.ProcedureDoctor != null)
                {
                    viewModel.AnesthesiaProcedureDoctor = surgery.AnesthesiaAndReanimation.ProcedureDoctor.Name;
                }
            }
        }

        private string isNullOrEmpty(string input)
        {
            if (String.IsNullOrEmpty(input))
            {
                return "";
            }
            else
            {
                return input;
            }
        }

        private string isObjectNullOrEmpty(object input)
        {
            if (input == null)
            {
                return null;
            }
            else
            {
                return input.ToString();
            }
        }
    }
}

namespace Core.Models
{
    public partial class OldSurgeryFormViewModel
    {
        public string AdmissionNumber
        {
            get;
            set;
        } //Kabul Numarası

        public DateTime? SurgeryDate
        {
            get;
            set;
        } //Ameliyat Tarihi

        public string ProtocoNo
        {
            get;
            set;
        } //Ameliyat Kodu

        public string ProcedureDoctor
        {
            get;
            set;
        } //Sorumlu Cerrah

        public string SurgeryReport
        {
            get;
            set;
        } //Ameliyat Notu

        public List<OldSurgeryPersonnel> SurgeryPersonnels
        {
            get;
            set;
        }

        public List<OldSurgeryProcedure> MainSurgeryProcedures
        {
            get;
            set;
        }

        public List<OldSubSurgery> SubSurgeries
        {
            get;
            set;
        }

        //Anestezi
        public string AnesthesiaNote
        {
            get;
            set;
        } //Anestezi Notu

        public string AnesthesiaReport
        {
            get;
            set;
        } //Anestezi Raporu

        public string AnesthesiaTechnique
        {
            get;
            set;
        } //Anestezi Tekniği

        public string AnesthesiaProtocolNo
        {
            get;
            set;
        } //Anestezi Protokol No

        public string AnesthesiaProcedureDoctor
        {
            get;
            set;
        } //Anestezi Sorumlu Uzman
    }

    public class OldSubSurgery
    {
        public string SubSurgeryReport
        {
            get;
            set;
        } //Ameliyat Notu

        public List<OldSurgeryPersonnel> SubSurgeryPersonnels
        {
            get;
            set;
        }

        public List<OldSurgeryProcedure> SubSurgeryProcedures
        {
            get;
            set;
        }
    }

    public class OldSurgeryPersonnel
    {
        public string Personnel
        {
            get;
            set;
        }

        public string Role
        {
            get;
            set;
        }
    }

    public class OldSurgeryProcedure
    {
        public string SurgeryName
        {
            get;
            set;
        } //Ameliyat Adı

        public string IncisionType
        {
            get;
            set;
        } //Kesi Oranı

        public string Position
        {
            get;
            set;
        } //Kesi Tarafı

        public string ProcedureSpeciality
        {
            get;
            set;
        } //Birimi
    }
}
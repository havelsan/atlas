//$7A1A3901
using System;
using System.Linq;
using Core.Models;
using Infrastructure.Filters;
using Infrastructure.Models;
using TTInstanceManagement;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using System.ComponentModel;
using System.Text;
using System.Collections.Generic;
using Infrastructure.Helpers;

namespace Core.Controllers
{
    public partial class PregnancyFollowServiceController
    {
        partial void PreScript_PregnancyFollowForm(PregnancyFollowFormViewModel viewModel, PregnancyFollow pregnancyFollow, TTObjectContext objectContext)
        {
            viewModel.FetusFollowDefList = new List<FetusFollowDefinitionDVO>();
            if (viewModel._PregnancyFollow.Pregnancy == null)
            {
                Guid? activePatientObjectID = viewModel.GetSelectedPatientID();
                if (activePatientObjectID.HasValue)
                {
                    Patient patient = objectContext.GetObject<Patient>(activePatientObjectID.Value);
                    viewModel._PregnancyFollow.Pregnancy = patient.ActivePregnancy;
                }
            }

            if (viewModel._PregnancyFollow.Pregnancy.LastMenstrualPeriod != null)
            {
                viewModel.LastMenstrualPeriod = viewModel._PregnancyFollow.Pregnancy.LastMenstrualPeriod;
                foreach (var item in FetusGrowingDefinition.GetFetusGrowingByWeekNQL(objectContext, GetPregnancyWeek(viewModel._PregnancyFollow.Pregnancy.LastMenstrualPeriod), ""))
                {
                    FetusFollowDefinitionDVO fetus = new FetusFollowDefinitionDVO { AbdominalCircumference = item.AbdominalCircumference, BiparietalDiameter = item.BiparietalDiameter, FemurLength = item.FemurLength, HeadCircumference = item.HeadCircumference, Length = item.Length, PregnancyWeek = item.PregnancyWeek, Weight = item.Weight };
                    viewModel.FetusFollowDefList.Add(fetus);
                }
            }
            else
            {
                var definitionNQL = FetusGrowingDefinition.FetusGrowingDefinitionNQL("").FirstOrDefault();
                FetusFollowDefinitionDVO fetus = new FetusFollowDefinitionDVO { AbdominalCircumference = definitionNQL.AbdominalCircumference, BiparietalDiameter = definitionNQL.BiparietalDiameter, FemurLength = definitionNQL.FemurLength, HeadCircumference = definitionNQL.HeadCircumference, Length = definitionNQL.Length, PregnancyWeek = definitionNQL.PregnancyWeek, Weight = definitionNQL.Weight };
                viewModel.FetusFollowDefList.Add(fetus);
            }

            BindingList<PregnancyFollow.GetPregnancyFollowByPregnancy_Class> pregnancyFollowList = PregnancyFollow.GetPregnancyFollowByPregnancy(viewModel._PregnancyFollow.Pregnancy.ObjectID);
            viewModel.OldPregnancyFollowGridList = new List<PregnancyFollowGrid>();
            foreach (var pregFollow in pregnancyFollowList.GroupBy(c => c.ObjectID))
            {
                var selectedFollow = pregnancyFollowList.Where(x => x.ObjectID == pregFollow.Key);
                StringBuilder _fka = new StringBuilder();
                StringBuilder _babyWeight = new StringBuilder();
                for (int i = 0; i < selectedFollow.Count(); i++)
                {
                    _fka.Append(selectedFollow.ElementAt(i).FKA);
                    _babyWeight.Append(selectedFollow.ElementAt(i).BabyWeight);
                    _babyWeight.Append(TTUtils.CultureService.GetText("M25741", "gr."));
                    if ((i + 1) != selectedFollow.Count())
                    {
                        _fka.Append(" / ");
                        _babyWeight.Append(" / ");
                    }
                }

                PregnancyFollowGrid follow = new PregnancyFollowGrid { BabyWeight = _babyWeight.ToString(), Defname = pregFollow.FirstOrDefault().Defname, Doctor = pregFollow.FirstOrDefault().Doctor, FKA = _fka.ToString(), MoherWeight = pregFollow.FirstOrDefault().MotherWeight != null ? pregFollow.FirstOrDefault().MotherWeight.Value.ToString() : "", ObjectId = pregFollow.FirstOrDefault().ObjectID.Value, PretibialEdema = pregFollow.FirstOrDefault().PretibialEdema != null ? pregFollow.FirstOrDefault().PretibialEdema : "", RequestDate = pregFollow.FirstOrDefault().RequestDate.Value.ToString("yyyy/MM/dd HH:mm") };
                viewModel.OldPregnancyFollowGridList.Add(follow);
            }
        }

        partial void PostScript_PregnancyFollowForm(PregnancyFollowFormViewModel viewModel, PregnancyFollow pregnancyFollow, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            if (viewModel._PregnancyFollow.Pregnancy == null)
            {
                viewModel._PregnancyFollow.Pregnancy = pregnancyFollow.WomanSpecialityObject.FirstOrDefault().PhysicianApplication.Episode.Patient.ActivePregnancy;
            }
        }

        private int GetPregnancyWeek(DateTime? lastMenstrualPeriod)
        {
            DateTime today = DateTime.Now;
            TimeSpan sub = today - Convert.ToDateTime(lastMenstrualPeriod);
            int week = sub.Days / 7;
            return week;
        }
    }
}

namespace Core.Models
{
    public partial class PregnancyFollowFormViewModel
    {
        public List<FetusFollowDefinitionDVO> FetusFollowDefList
        {
            get;
            set;
        }

        public List<PregnancyFollowGrid> OldPregnancyFollowGridList
        {
            get;
            set;
        }

        public DateTime? LastMenstrualPeriod { get; set; }
        
        public string InformerName { get; set; }
        public string InformerPhone { get; set; }
    }

    public class FetusFollowDefinitionDVO
    {
        public int? PregnancyWeek
        {
            get;
            set;
        }

        public int? Length
        {
            get;
            set;
        }

        public double? Weight
        {
            get;
            set;
        }

        public int? BiparietalDiameter
        {
            get;
            set;
        }

        public int? HeadCircumference
        {
            get;
            set;
        }

        public int? AbdominalCircumference
        {
            get;
            set;
        }

        public int? FemurLength
        {
            get;
            set;
        }
    }

    public class PregnancyFollowGrid
    {
        public Guid ObjectId
        {
            get;
            set;
        }

        public string Defname
        {
            get;
            set;
        }

        public string RequestDate
        {
            get;
            set;
        }

        public string Doctor
        {
            get;
            set;
        }

        public string PretibialEdema
        {
            get;
            set;
        }

        public string MoherWeight
        {
            get;
            set;
        }

        public string BabyWeight
        {
            get;
            set;
        }

        public string FKA
        {
            get;
            set;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using TTDataDictionary;
using TTObjectClasses;

namespace Core.Models
{
    public class DoctorPerformanceTermModel
    {
        public Guid ObjectID { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid CurrentState { get; set; }
        public int TotalPoint { get; set; }
    }

    public class BarChartModel
    {
        public string ColumnName { get; set; }
        public string Description { get; set; }
        public int Value { get; set; }
    }
    public class DoctorPerformanceDecisionModel
    {
        public Guid? ObjectID { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public DateTime CreateDate { get; set; }
        public Guid? TermID { get; set; }
        public List<DPCommissionMemberModel >  MemberList { get; set; }
        public Guid? CurrentState { get; set; }

        public DoctorPerformanceDecisionModel()
        {
            this.MemberList = new List<DPCommissionMemberModel>();
        }

    }

    public class DPCommissionMemberModel:RelatedUserModel
    {
        public DPACommisionMemberDutyEnum Duty { get; set; }
    }


    public class DoctorPerformanceTermOperationViewModel
    {
        public List<DoctorPerformanceTermModel> TermList { get; set; }
        DoctorPerformanceTermOperationViewModel()
        {
            this.TermList = new List<DoctorPerformanceTermModel>();
        }
    }
    public class BransGridModel
    {
        public Guid ObjectID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
    }
    public class DoctorGridModel
    {
        public Guid ObjectID { get; set; }
        public string Name { get; set; }
        public long? UniqueRefNo { get; set; }
        public string Title { get; set; }
        public double? B1Point { get; set; }
        public double? B2Point { get; set; }
        public double? B3Point { get; set; }
        public DateTime? LastExecDate { get; set; }

    }
    public class ServiceResultModel
    {
        public List<DetailModel> DetailList { get; set; }
        public double? B1Point { get; set; }
        public double? B2Point { get; set; }
        public double? B3Point { get; set; }
        public DateTime? LastExecDate { get; set; }

        public ServiceResultModel()
        {
            this.DetailList = new List<DetailModel>();
        }

    }

    public class DoctorPerformanceTermBasedOperationViewModel
    {
        public List<BransGridModel> BransList { get; set; }
        public  List<DoctorGridModel> DoctorList { get; set; }
        public  List<DetailModel> DetailList { get; set; }
        DoctorPerformanceTermBasedOperationViewModel()
        {
            this.BransList = new List<BransGridModel>();
            this.DoctorList = new List<DoctorGridModel>();
            this.DetailList = new List<DetailModel>();
        }
    }

    public class DetailModel
    {
        public Guid ObjectID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string DoctorName { get; set; }
        public string PatientName { get; set; }
        public string ProtocolNo { get; set; }
        public DateTime PerformedDate { get; set; }
        public double? Point { get; set; }
        public double? CalcPoint { get; set; } 
        public string RuleName { get; set; }
        public string RuleDescription { get; set; }
        public string UniqueReFno { get; set; }
        public bool IsModified { get; set; }
        public string PatientStatus { get; set; }
        public string RessectionName { get; set; }
    }
    
    public class LogGridModel
    {
        public Guid ObjectID { get; set; }
        public DateTime ExecDate { get; set; }
        public double? TotalCalcPoint { get; set; }

    }

    public class GILDefinitionDTO
    {
        public Guid ObjectID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int Point { get; set; }
        public string Description { get; set; }
        public bool HasRule { get; set; }
        public string SurgeryGroup { get; set; }
    }

    public class DoctorPerformanceRuleOperationDetailViewModel
    {
        public List<ProcedureModelForRule> ProcedureList { get; set; }
        public List<SpecialityModelForRule> SpecialityList { get; set; }
        public List<DiagnosisModelForRule> DiagnosisList { get; set; }
        public List<QueryScriptModelForRule> QueryList { get; set; }
        public int? AgeType { get; set; }
        public int? Age { get; set; }
        public string TedaviTuru { get; set; }
        public int? PeriodScope { get; set; }
        public int? Period { get; set; }
        public int? PeriodTimeType { get; set; }
        public int? PeriodAmount { get; set; }
        public int? Sex { get; set; }
        public int? Kesi { get; set; }
        public int? Hospital { get; set; }
        public DoctorPerformanceRuleOperationDetailViewModel()
        {

            this.ProcedureList = new List<ProcedureModelForRule>();
            this.SpecialityList = new List<SpecialityModelForRule>();
            this.DiagnosisList = new List<DiagnosisModelForRule>();
            this.QueryList = new List<QueryScriptModelForRule>();
        }
    }

    public class DoctorPerformanceRuleOperationViewModel
    {
        public List<GILDefinitionDTO> GILDefinitionList { get; set; }
        public DoctorPerformanceRuleOperationDetailViewModel SelectedRule { get; set; }
        public GILDefinitionDTO SelectedItem { get; set; }
        public DoctorPerformanceRuleOperationViewModel()
        {
            this.SelectedItem = new GILDefinitionDTO();
            this.GILDefinitionList = new List<GILDefinitionDTO>();
            this.SelectedRule = new DoctorPerformanceRuleOperationDetailViewModel();
        }
    }

    public class ProcedureModelForRule
    {
        public Guid? ObjectID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int BannOrMustType { get; set; }
        public int TimeType { get; set; }
        //public ProcedureModelForRule(string _code, string _name, int _bannOrMustType,int _timeType)
        //{
        //    this.Code = _code;
        //    this.Name = _name;
        //    this.BannOrMustType = _bannOrMustType;
        //    this.TimeType = _timeType;
        //}
    }
    public class SpecialityModelForRule
    {
        public Guid? ObjectID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int BannOrMustType { get; set; }
        //public SpecialityModelForRule(string _code, string _name, int _bannOrMustType)
        //{
        //    this.Code = _code;
        //    this.Name = _name;
        //    this.BannOrMustType = _bannOrMustType;
        //}
    }
    public class DiagnosisModelForRule
    {
        public Guid? ObjectID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        //public DiagnosisModelForRule(string _code,string _name)
        //{
        //    this.Code = _code;
        //    this.Name = _name;
        //}
    }
    public class QueryScriptModelForRule
    {
        public string Script { get; set; }
        public string RuleName { get; set; }
        public int PointPercentage { get; set; }
        public string ResultMessage { get; set; }
    }
    public class UnitManagerModel
    {
        public Guid ObjectID { get; set; }
        public string Name {get;set;}
    }
    public class RelatedUserModel
    {
        public Guid ObjectID { get; set; }
        public string Name { get; set; }
        public string SpecialtyName { get; set; }

    }
    public class HasDPRolesModel
    {
        public bool hasDPGrafikGenelRole { get; set; }
        public bool hasDPGrafikOzelRole { get; set; }
        public bool hasDPYonetimPaneliRole { get; set; }
        public bool hasDPPerfomansRole { get; set; }
        public HasDPRolesModel()
        {
            this.hasDPGrafikGenelRole = false;
            this.hasDPGrafikOzelRole = false;
            this.hasDPYonetimPaneliRole = false;
            this.hasDPPerfomansRole = true;
        }
    }

    public class saveUnitManagerAndRelatedDoctors
    {
        public Guid UnitManagerObjectID { get; set; }
        public List<Guid> ResUserObjectIDList { get; set; }
        public saveUnitManagerAndRelatedDoctors()
        {
            this.ResUserObjectIDList = new List<Guid>();
        }
    }
}
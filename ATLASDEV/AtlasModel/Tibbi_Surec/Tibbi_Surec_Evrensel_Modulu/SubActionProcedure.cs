using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class SubActionProcedure
    {
        public Guid ObjectId { get; set; }
        public long? ID { get; set; }
        public bool? Eligible { get; set; }
        public string ReasonOfCancel { get; set; }
        public DateTime? WorkListDate { get; set; }
        public DateTime? PricingDate { get; set; }
        public long? Amount { get; set; }
        public DateTime? ActionDate { get; set; }
        public bool? Emergency { get; set; }
        public bool? Active { get; set; }
        public DateTime? OlapDate { get; set; }
        public DateTime? OlapLastUpdate { get; set; }
        public bool? AccountOperationDone { get; set; }
        public bool? AccTrxsMultipliedByAmount { get; set; }
        public bool? PatientPay { get; set; }
        public string ExtraDescription { get; set; }
        public SutRuleEngineStatus? SUTRuleStatus { get; set; }
        public double? DiscountPercent { get; set; }
        public DateTime? PerformedDate { get; set; }
        public DateTime? CreationDate { get; set; }
        public bool? IsOldAction { get; set; }
        public string MedulaReportNo { get; set; }
        public RightLeftEnum? RightLeftInformation { get; set; }
        public Guid? EpisodeRef { get; set; }
        public Guid? ProcedureSpecialityRef { get; set; }
        public Guid? EpisodeActionRef { get; set; }
        public Guid? PackageDefinitionRef { get; set; }
        public Guid? MasterSubActionProcedureRef { get; set; }
        public Guid? MasterPackgSubActionProcedureRef { get; set; }
        public Guid? MedulaHastaKabulRef { get; set; }
        public Guid? SubEpisodeRef { get; set; }
        public Guid? ProcedureObjectRef { get; set; }
        public Guid? ProcedureDoctorRef { get; set; }
        public Guid? ProcedureByUserRef { get; set; }
        public Guid? RequestedByUserRef { get; set; }
        public Guid? ReasonForRepetitionRef { get; set; }

        #region Parent Relations
        public virtual Episode Episode { get; set; }
        public virtual EpisodeAction EpisodeAction { get; set; }
        public virtual SubActionProcedure MasterSubActionProcedure { get; set; }
        public virtual SubActionProcedure MasterPackgSubActionProcedure { get; set; }
        public virtual SubEpisode SubEpisode { get; set; }
        public virtual ProcedureDefinition ProcedureObject { get; set; }
        public virtual ResUser ProcedureDoctor { get; set; }
        public virtual ResUser ProcedureByUser { get; set; }
        public virtual ResUser RequestedByUser { get; set; }
        public virtual SKRSTekrarTetkikIstemGerekcesi ReasonForRepetition { get; set; }
        #endregion Parent Relations
    }
}
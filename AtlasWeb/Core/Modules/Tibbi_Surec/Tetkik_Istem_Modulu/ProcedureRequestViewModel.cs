using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using TTObjectClasses;

namespace Core.Modules.Tibbi_Surec.Tetkik_Istem_Modulu
{
    public class ProcedureRequestViewModel
    {
        public List<vmProcedureRequestFormDefinition> FormDefinitions = new List<vmProcedureRequestFormDefinition>();
        public List<vmProcedureRequestFormDefinition> UserMostUsedFormDefinitions = new List<vmProcedureRequestFormDefinition>();
        public List<vmRequestedProcedure> RequestedProcedures = new List<vmRequestedProcedure>();
        public object _selectedValue
        {
            get;
            set;
        }

        public object _selectedDoctorValue
        {
            get;
            set;
        }

        public object _selectedPackageValue
        {
            get;
            set;
        }

        public bool isEmergency
        {
            get;
            set;
        }

        public DateTime requestDate
        {
            get;
            set;
        }

        public DateTime startDate
        {
            get;
            set;
        }

        public DateTime endDate
        {
            get;
            set;
        }

        public string TestTypesCheckedParam { get; set; } //geçmiş tetkikleri kontrol edilecek radyoloji tiplerini tutar
        public bool IgnoreMukerrerException { get; set; }//mükerrerlik sorgusunda alınan hatayı göz ardı etve devam et

        public DailyProvisionInputModel DailyProvisionModel
        {
            get;
            set;
        }

        public int countForDailyOperations {get; set;}


    }

    public class vmProcedureRequestFormDefinition
    {
        public Guid Id;
        public string Name;
        public List<vmProcedureRequestCategoryDefinition> FormCategories = new List<vmProcedureRequestCategoryDefinition>();
    }

    public class vmProcedureRequestCategoryDefinition
    {
        public Guid Id;
        public string Name;
        public bool? IsPassiveNow;
        public string ReasonForPassive;
        public List<vmProcedureRequestDetailDefinition> FormDetails = new List<vmProcedureRequestDetailDefinition>();
        //istem panelini 3 gride bolme calismasi
        public List<vmProcedureRequestDetailDefinition> Grid1FormDetails = new List<vmProcedureRequestDetailDefinition>();
        public List<vmProcedureRequestDetailDefinition> Grid2FormDetails = new List<vmProcedureRequestDetailDefinition>();
        public List<vmProcedureRequestDetailDefinition> Grid3FormDetails = new List<vmProcedureRequestDetailDefinition>();
    }

    public class vmProcedureRequestDetailDefinition
    {
        public Guid Id;
        public string Code;
        public string Name;
        public Guid ProcedureObjectDefID;
        public bool Checked;
        public bool IsActive;
        public List<vmProcedureRequestDetailDefinition> BoundedProcedureRequestDetails = new List<vmProcedureRequestDetailDefinition>();
        public bool IsWorkingDay;
        public bool IsPassiveNow; //Lab ve Rad testleri icin Calisilmayan Tetkik  check degerini tasir
        public Guid ResObservationUnitId;
        public List<vmProcedureRequestDetailDefinition> GroupProcedureRequestDetails = new List<vmProcedureRequestDetailDefinition>();
        public bool IsAdditionalApplication;
        public bool IsSexControl;
        public SKRSCinsiyet Sex;
        public bool IsDurationControl;
        public int DurationValue;
        public string TestType { get; set; }//Şimdilik Radyoloji tiplerini tutuyor,MR,BT vs...
        public bool isReportRequired;
        public bool isRISIntegrated;
        public bool? isPathologyRequired;
        public bool? isResultNeeded;
        public bool? isSkinPrickTest;
        public bool? RepetitionQueryNeeded { get; set; }
    }

    public class vmRequestedProcedure
    {
        public Guid Id;
        public Guid SubActionProcedureObjectId;
        public Guid ProcedureObjectId;
        public string ProcedureCode;
        public string ProcedureName;
        public int Amount;
        public double UnitPrice;
        public DateTime RequestDate;
        public string RequestedByResUser;
        public Guid RequestedById;
        public Guid ProcedureUserId;
        public string ProcedureResUser;
        public string MasterResource;
        public Guid MasterResourceObjectId;
        public DateTime EstimatedResultDate;
        public string ActionStatus;
        public Guid CurrentStateDefID;
        public int StateStatus;
        public string ProcedureResultLink;
        public string ProcedureReportLink;
        public bool isResultShown;
        public bool canAnalyzeWithAI = false;
        public bool isReportShown;
        public bool isResultSeen;
        public bool isAdditionalApplication;
        public string ProcedureType;
        public bool isEmergency;
        public string ExternalProcedureId; //ThirdParty entegrasyonu olan hizmetler icin dis sistemdeki ID tutmak icin. 
        public Guid ProcedureObjectDefId;
        public bool hasProcedureInstruction;
        public string ProcedureInstructions;
        public string ProcedureInstructionReportName;
        public Boolean isExternalProcedureRequest;
        public Guid EpisodeActionObjectId;
        public bool hasPanicValue;
        public string PanicValue;
        public bool isProcedureRejected;
        public string RejectReason;
        public string ResultValue;
        public string AlertMessage;
        public List<Guid> BaseAdditionalInfoFormGuids;
        public string Description;
        public bool isAddedToMostUsedRequest;
        public bool isGroupTest; //Laboratuvar testlerinde group test ise istem panelinden isaretlendiginde tetkigin kendisi eklenmemei icin. Altında tanımlı tetkıklerın eklenecek
        public bool isDateChanged;
        public bool isAmountChanged;
        public bool isProcedureUserChanged;
        public bool isProcedureReadOnly;
        public bool isNew;
        public bool isPanelTest;
        public List<vmProcedureRequestDetailDefinition> BoundedProcedureRequestDetails = new List<vmProcedureRequestDetailDefinition>();
        public bool? DailyMedulaProvisionNecessity;
        public bool? isReportRequired;//Hizmet giridinden rapor yazılabilen işlemler için eklendi
        public bool? isRISIntegrated;
        public bool? isRadiologyProcedure;
        public string ProtocolNo;
        public ActionTypeEnum ActionType;
        public bool? isPathologyRequired;//Patoloji istemi gerektiren işlemler
        public bool? isResultNeeded;//Sonuç değeri gerektirir
        public bool? isSkinPrickTest;
        public List<BaseAdditionalInfoFormViewModel> BaseAdditionalInfoFormViewModels = new List<BaseAdditionalInfoFormViewModel>();
        public bool? isObserved; //Musahede islemini kontrol etmek icin
        public bool? RightLeftInfoNeeded;
        public RightLeftEnum? RightLeftInformation;
        public SKRSTekrarTetkikIstemGerekcesi ReasonForRepetition;
        public bool? isMikrobiyolojiTest { get; set; }
        public string mikrobiyolojiResult { get; set; }
    }

    public class vmAdditionalProcedureInfo
    {
        public Guid ProcedureObjectId;
        public int Amount;
        public DateTime RequestDate;
        public Guid ProcedureUserId;
        public List<BaseAdditionalInfoFormViewModel> BaseAdditionalInfoFormViewModels;
    }

    public class vmRequestedBloodBankProcedureInfo
    {
        public Guid procedureRequestFormDetailDefinitionID;
        public string externalSystemBloodProductID; //Kan urun ID
        public Guid procedureDefinitionID;
    }

    public class vmPackageProcedure
    {
        public Guid Id;
        public string ProcedureCode;
        public string ProcedureName;
        public bool isSelected;
        public bool isAdditionalApplication;
    }

    public class vmPackageTemplateDefinition
    {
        public string Code;
        public string Name;
        public Guid ObjectId;
        public List<Guid> PackageICDs = new List<Guid>();
        public List<Guid> PackageRequestedProcedures = new List<Guid>();
    }

    public class vmPackageTemplateICD
    {
        public Guid DiagnoseObjectId;
        public string DiagnoseCode;
        public string DiagnoseName;
        public DiagnosisDefinition Diagnose;
        public DiagnosisTypeEnum DiagnoseType;
        public bool isSelected;
    }

    public class vmPackageTemplate
    {
        public List<vmPackageProcedure> PackageProcedures = new List<vmPackageProcedure>();
        public List<vmPackageTemplateICD> PackageICDs = new List<vmPackageTemplateICD>();
    }

    public class vmRequiredInfoFormProcedure
    {
        public Guid SubActionProcedureObjectId;
        public string ProcedureCode;
        public string ProcedureName;
        public string ProcedureType;
    }

    public class QueryInputDVO
    {
        public Guid EpisodeActionObjectID;
        public DateTime StartDate;
        public DateTime EndDate;
        public Boolean PhysicianSuggestionsIsActive;
        public Boolean IsCancelledIncluded;
    }

    public class ProcedureReqInfoInputDVO
    {
        public string EpisodeActionObjectId;
        public string CheckedFormDetailObjectId;
        public string ProcedureByUserId;
        public bool? IsAdditionalApplication;
    }

    public class AdditionalAppInfoInputDVO
    {
        public string EpisodeActionObjectId;
        public string ProcedureDefObjectId;
    }
    public class TestResultQueryInputDVO
    {
        public string ViewType;
        public string EpisodeID;
        public string PatientTCKN;
    }

    public class ProcedureSuggestionInputDVO
    {
        public string Message;
        public ActionTypeEnum? ActionType;
        public ResSection MasterResource;
        public List<Guid> MasterResourceGuidList = new List<Guid>();

    }


    public class vmRequestedProcedureForm
    {
        public List<vmRequestedProcedure> RequestedProcedureList;
        public List<vmRequestedProcedure> ExaminationsRequestedProcedureList;
        public List<vmRequestedProcedure> ControlRequestedProcedureList;
        public List<vmRequestedProcedure> InpatientRequestedProcedureList;
        public List<ProcedureSuggestionInputDVO> ProcedureSuggestionInputDVOList;
        public DateTime? SubEpisodeOpeningDate;
        public DateTime? SubEpisodeClosingDate;
        public DateTime? RequestDate;
        public string LastSpecimenId;
        public Boolean IsSGKPatient;
        public string PatientTCNo;
        public string PatientObjectId;
        public int countForDailyOperations = 0;
        public string ProtocolNo;
        public DateTime? ClosingDate;
    }

    public class UserOptionInputDVO
    {
        public UserOptionType UserOptionType;
        public string OptionValue;
    }


    public class RepeatedProceduresQueryInputDVO
    {
        public string PatientID;
        public List<string> RequestedProceduresObjectIDList;
    }

    public class ProcedureUserObj
    {
        public Guid? ObjectID
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }

    }

    public class DoctorListResultModel
    {
        public string Name {get; set; }
        public Guid ObjectId { get; set; }

    }

    public class DoctorListInputModel
    {
        public Guid ObjectId { get; set; }
        public RequestedProceduresFormViewModel ViewModel { get; set; }
    }

    public class DailyProvisionInputModel
    {
        public string Epicrisis {get; set;}
        public Guid TreatmentClinic{get;set;}
        public EpisodeAction EpisodeAction { get; set; }
        public Guid ProcedureDoctorID { get; set; }
        public bool DailyInpatientControl { get; set; }
        public DateTime InpatientDate { get; set; }
        public bool NormalInpatientControl { get; set; }
    }

    public class DailyProcedureModel
    {
        public DailyProvisionInputModel provisionModel { get; set; }
        public SubActionProcedure procedure { get; set; }

    }

    public class QuickProcedureEntryViewModel
    {
        public ResUser ProcedureDoctor { get; set; }
    }
}
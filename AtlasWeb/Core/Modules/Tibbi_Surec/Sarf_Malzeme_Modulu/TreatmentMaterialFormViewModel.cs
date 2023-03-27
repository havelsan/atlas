using System;
using System.Collections.Generic;
using System.Linq;
using TTObjectClasses;

namespace Core.Models
{
    public class TreatmentMaterialFormViewModel
    {
        public object _selectedMaterialValue
        {
            get;
            set;
        }

        public TTObjectClasses.Store _selectedStoreValue
        {
            get;
            set;
        }

        //public TTObjectClasses.BaseTreatmentMaterial AddedTreatmentMaterial { get; set; }
        //public TTObjectClasses.Material material { get; set; }
        //public string Barcode { get; set; }
        //public TTObjectClasses.StockCard StockCard { get;set;}
        //public TTObjectClasses.DistributionTypeDefinition DistributionTypeDef { get; set; }
        //public string DistributionType { get; set; }
        public List<AddedTreatmentMaterialsViewModel> AddedTreatmentMaterials
        {
            get;
            set;
        }

        public DateTime ActionDate
        {
            get;
            set;
        }

        public int countForDailyOperations {get; set;}

        public string ProtocolNo { get; set; }
    }

    public class GetTreatmentMaterialDetail_Input
    {
        public TTObjectClasses.BaseTreatmentMaterial Material { get;set;}
    }

public class AddedTreatmentMaterialsViewModel
{
    public TTObjectClasses.BaseTreatmentMaterial AddedTreatmentMaterial
    {
        get;
        set;
    }

    public TTObjectClasses.Material material
    {
        get;
        set;
    }

    public string Barcode
    {
        get;
        set;
    }
        
        public TTObjectClasses.StockCard StockCard
    {
        get;
        set;
    }

    public TTObjectClasses.DistributionTypeDefinition DistributionTypeDef
    {
        get;
        set;
    }

    public string DistributionType
    {
        get;
        set;
    }
        public string drugSpecification
        {
            get;
            set;
        }
        public DrugReportType DrugReportType
    {
        get;
        set;
    }

        public List<MaterialProcedureViewModel> MaterialProcedureViewModelList
        {
            get;
            set;
        }


        public SubEpisode subEpisode { get; set; } //Gridde protokol no'yu gosterebilmek icin
        public EpisodeAction episodeAction { get; set; } //Gridde action type'ı gosterebilmek icin
}

    public class AddedTreatmentMaterialInputDVO
    {
        public List<TreatmentMaterialInputDVODetail> AddedTreatmentMaterials
        {
            get;
            set;
        }

        public string EpisodeActionObjectDefID
        {
            get;
            set;
        }

        public DateTime ActionDate
        {
            get;
            set;
        }

        public Guid SubEpisodeGuid
        {
            get;
            set;
        }

        public string TreatmentMaterialTypeName
        {
            get;
            set;
        }
        public Guid EpisodeActionMasterResourceId
        {
            get;
            set;
        }

    }

public class TreatmentMaterialInputDVODetail
{
    public string MaterialObjectID
    {
        get;
        set;
    }
    public double Amount
    {
        get;
        set;
    }
    public DateTime? TransactionDate
    {
        get;
        set;
    }
}

public class TreatmentMaterialStartUpViewModel
{
    public DateTime? MaxDate
    {
        get;
        set;
    }
    public DateTime? MinDate
    {
        get;
        set;
    }
    public DateTime DefaultDate
    {
        get;
        set;
    }

    public string ProtocolNo 
        {
            get;
            set;
        }


}
    public class MaterialProcedureViewModel
    {
        public string ProcedureName;
        public System.Guid ProcedureObjectId;
        public System.Guid? ProcedureRequestFormDetailObjectId;
        public bool IsAdditionalApplication;
    }
}
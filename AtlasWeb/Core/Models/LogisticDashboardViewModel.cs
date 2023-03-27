using System;
using System.Collections.Generic;
using TTDataDictionary;
using TTObjectClasses;

namespace Core.Models
{
    public class LogisticDashboardViewModel
    {
        public bool hasRoleDashboardMaterialStatus { get; set; }
        public bool hasRoleDashboardCostAction { get; set; }
        public bool hasRoleDashboardMinMax { get; set; }
        public bool hasRoleSubStoreExpDateUpdate { get; set; }
        public bool hasRoleSubStoreWaitingWorks {get;set;}

        public bool hasRoleOpenCloseTerm { get; set; }

        public List<DashboardGridItemModel> dashboardGridItemModel
        {
            get;
            set;
        }

        public List<CostActionSelectBox> costActionSelectBox
        {
            get;
            set;
        }

        public List<ArchitectureInfo> architectureInfo
        {
            get;
            set;
        }

        public object Material
        {
            get;
            set;
        }
        public object MinMaxMaterial
        {
            get;
            set;
        }

        public List<MaterialDetail> materialDetail
        {
            get;
            set;
        }

        public List<StockCikis> stockCikis
        {
            get;
            set;
        }

        public List<StockGiris> stockGiris
        {
            get;
            set;
        }

        public List<StockActionWorkListDashboardItemModel> stockactionlist
        {
            get;
            set;
        }

        public List<CostActionAccountingTerm> costActionAccountingTerm
        {
            get;
            set;
        }

        public bool IsMainStoreFlag
        {
            get;
            set;
        }

        public List<MaterialInheldMaxMin> MaterialInheldMaxMin
        {
            get;
            set;
        }

        public List<MinMaxCalcTypeEnum> MinMaxCalcTypes
        {
            get;
            set;
        }

        public MinMaxCalcTypeEnum selectedMinMaxCalc
        {
            get;
            set;
        }

        public List<MinMaxCalculetedItem> MinMaxCalculetedItems
        {
            get;
            set;
        }

        public List<BudgetTypeSource> budgetTypeSources
        {
            get;
            set;
        }

        public BudgetTypeSource defaultBudgetType
        {
            get;
            set;
        }

        public CostActionAccountingTerm activeCostActionAccountingTerm
        {
            get;
            set;
        }
    }





    public class StockActionWorkListDashboardItemModel
    {
        public string ObjectID
        {
            get;
            set;
        }

        public Int32 StockActionID
        {
            get;
            set;
        }

        public TTObjectClasses.TransactionTypeEnum StockActionType
        {
            get;
            set;
        }

        public string DestinationStore
        {
            get;
            set;
        }

        public string StockactionName
        {
            get;
            set;
        }

        public string PatientName
        {
            get;
            set;
        }

        public DateTime TransactionDate
        {
            get;
            set;
        }

        public string StateName
        {
            get;
            set;
        }

        public string StateFormName
        {
            get;
            set;
        }

        public double Amount
        {
            get;
            set;
        }
    }

    public class DashboardGridItemModel
    {
        public string ObjectID
        {
            get;
            set;
        }

        public string Material
        {
            get;
            set;
        }

        public string MaterialName
        {
            get;
            set;
        }

        public Double AvarageUnitePrice
        {
            get;
            set;
        }

        public Double DifAvarageUnitePrice
        {
            get;
            set;
        }

        public Double MaterialPrice
        {
            get;
            set;
        }

        public Double PreviousMonthPrice
        {
            get;
            set;
        }

        public Double PreviousMothInheld
        {
            get;
            set;
        }

        public Double ProfitAndLoss
        {
            get;
            set;
        }

        public Double TotalAmount
        {
            get;
            set;
        }

        public Double TotalOutAmunt
        {
            get;
            set;
        }

        public Double TotalPrice
        {
            get;
            set;
        }

        public Double TransferredAmount
        {
            get;
            set;
        }
    }

    public class CostActionSelectBox
    {
        public string Objetid
        {
            get;
            set;
        }

        public string costActionDesciption
        {
            get;
            set;
        }
    }

    public class BudgetTypeSource
    {
        public string objectID
        {
            get;
            set;
        }

        public string name
        {
            get;
            set;
        }
    }

    public class CostActionAccountingTerm
    {
        public string ObjId
        {
            get;
            set;
        }

        public string Desciption
        {
            get;
            set;
        }

        public DateTime StartDate
        {
            get;
            set;
        }

        public AccountingTermStatusEnum? Status
        {
            get;
            set;
        }
    }

    public class ArchitectureInfo
    {
        public string yearKey
        {
            get;
            set;
        }

        public string year
        {
            get;
            set;
        }

        public Double cluster
        {
            get;
            set;
        }

        public string ObjId
        {
            get;
            set;
        }

        public string MaterialName
        {
            get;
            set;
        }
    }

    public class MaterialDetail
    {
        public string ObjectID
        {
            get;
            set;
        }

        public Int32 Inheld
        {
            get;
            set;
        }

        public Double totalIn
        {
            get;
            set;
        }

        public Double totalOut
        {
            get;
            set;
        }

        public string totalInPrice
        {
            get;
            set;
        }

        public string totalOutPrice
        {
            get;
            set;
        }

        public string materialName
        {
            get;
            set;
        }

        public string barcode
        {
            get;
            set;
        }

        public string distibutiontype
        {
            get;
            set;
        }

        public string materialClasses
        {
            get;
            set;
        }

        public byte[] materialPicture
        {
            get;
            set;
        }

        public string materialMKYSCod
        {
            get;
            set;
        }

        public string storageConditions
        {
            get;
            set;
        }

        public string estimatedTimeOfCheck
        {
            get;
            set;
        }

        public Double StockInheldMaxLevel
        {
            get;
            set;
        }

        public Double StockInheldMinLevel
        {
            get;
            set;
        }

        public List<StockDataInformation> StockDataInformation
        {
            get;
            set;
        }

        public List<MaterialInheldMaxMin> MaterialInheldMaxMin
        {
            get;
            set;
        }

        public List<StockDataLevelType> StockDataLevelType
        {
            get;
            set;
        }

        public List<StockBudgetType> StockBudgetType
        {
            get;
            set;
        }
    }

    public class MaterialInheldMaxMin
    {
        public double maxInheld
        {
            get;
            set;
        }

        public double minInheld
        {
            get;
            set;
        }

        public double inheld
        {
            get;
            set;
        }
    }

    public class StockBudgetType
    {
        public string BudgetType
        {
            get;
            set;
        }

        public double Amount
        {
            get;
            set;
        }
    }

    public class StockDataInformation
    {
        public string LotNo
        {
            get;
            set;
        }

        public DateTime ExpirationDate
        {
            get;
            set;
        }

        public Currency ResAmount
        {
            get;
            set;
        }
    }

    public class StockDataLevelType
    {
        public TTObjectClasses.StockLevelTypeEnum StockLevelType
        {
            get;
            set;
        }

        public double Amount
        {
            get;
            set;
        }
    }

    public class StockGiris
    {
        public string Description
        {
            get;
            set;
        }

        public double Amount
        {
            get;
            set;
        }

        public List<StockGirisDetay> stockGirisDetayList
        {
            get;
            set;
        }
    }

    public class StockCikis
    {
        public string Description
        {
            get;
            set;
        }

        public double Amount
        {
            get;
            set;
        }

        public List<StockCikisDetay> stockCikisDetayList
        {
            get;
            set;
        }
    }

    public class StockCikisDetay
    {
        public string description
        {
            get;
            set;
        }

        public double amount
        {
            get;
            set;
        }
    }

    public class StockGirisDetay
    {
        public string description
        {
            get;
            set;
        }

        public double amount
        {
            get;
            set;
        }
    }

    public class MinMaxCalculetedItem
    {
        public string StockObjectID
        {
            get;
            set;
        }

        public string MaterialName
        {
            get;
            set;
        }

        public string DistributionTypeName
        {
            get;
            set;
        }

        public double Inheld
        {
            get;
            set;
        }

        public double OutAmount
        {
            get;
            set;
        }

        public double MinLevel
        {
            get;
            set;
        }
        public double CriticalLevel { get; set; }
        public double MaxLevel
        {
            get;
            set;
        }

        public double CalcMinLevel
        {
            get;
            set;
        }

        public double CalcMaxLevel
        {
            get;
            set;
        }
        public double CalcCriticalLevel { get; set; }
    }


}
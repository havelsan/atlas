//$47B735E8
using System;
using System.Linq;
using System.Net.Http;
using System.ComponentModel;
using System.Collections.Generic;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;

using Infrastructure.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public partial class AccountTransactionServiceController : Controller
    {
        public class GetByIdv2_Input
        {
            public System.Collections.Generic.List<int> IdList
            {
                get;
                set;
            }
        }

        [HttpPost]
        public System.ComponentModel.BindingList<TTObjectClasses.AccountTransaction> GetByIdv2(GetByIdv2_Input input)
        {
            var ret = AccountTransaction.GetByIdv2(input.IdList);
            return ret;
        }

        public class GetTransactionsForReceipt_Input
        {
            public Guid APR
            {
                get;
                set;
            }

            public Guid STATE
            {
                get;
                set;
            }

            public Guid SEP
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<AccountTransaction> GetTransactionsForReceipt(GetTransactionsForReceipt_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = AccountTransaction.GetTransactionsForReceipt(objectContext, input.APR, input.STATE, input.SEP);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetTransactionsForInvoice_Input
        {
            public Guid STATE
            {
                get;
                set;
            }

            public Guid APR
            {
                get;
                set;
            }

            public Guid SEP
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<AccountTransaction> GetTransactionsForInvoice(GetTransactionsForInvoice_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = AccountTransaction.GetTransactionsForInvoice(objectContext, input.STATE, input.APR, input.SEP);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetTransactionsForCollectedInvoice_Input
        {
            public DateTime STARTDATE
            {
                get;
                set;
            }

            public DateTime ENDDATE
            {
                get;
                set;
            }

            public IList<Guid> PAYER
            {
                get;
                set;
            }

            public IList<int> PATIENTSTATUS
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<AccountTransaction> GetTransactionsForCollectedInvoice(GetTransactionsForCollectedInvoice_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = AccountTransaction.GetTransactionsForCollectedInvoice(objectContext, input.STARTDATE, input.ENDDATE, input.PAYER, input.PATIENTSTATUS);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetTransactionsExceptCancelledBySEP_Input
        {
            public Guid APR
            {
                get;
                set;
            }

            public Guid SEP
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<AccountTransaction> GetTransactionsExceptCancelledBySEP(GetTransactionsExceptCancelledBySEP_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = AccountTransaction.GetTransactionsExceptCancelledBySEP(objectContext, input.APR, input.SEP);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetTransactionsForCollectedInvoiceByResource_Input
        {
            public DateTime STARTDATE
            {
                get;
                set;
            }

            public DateTime ENDDATE
            {
                get;
                set;
            }

            public IList<Guid> PAYER
            {
                get;
                set;
            }

            public IList<int> PATIENTSTATUS
            {
                get;
                set;
            }

            public IList<Guid> RESOURCE
            {
                get;
                set;
            }

            public int RESOURCEFLAG
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<AccountTransaction> GetTransactionsForCollectedInvoiceByResource(GetTransactionsForCollectedInvoiceByResource_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = AccountTransaction.GetTransactionsForCollectedInvoiceByResource(objectContext, input.STARTDATE, input.ENDDATE, input.PAYER, input.PATIENTSTATUS, input.RESOURCE, input.RESOURCEFLAG);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class OLAP_GetSubactionAccTransaction_Input
        {
            public Guid SUBACTIONPROCEDURE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<AccountTransaction.OLAP_GetSubactionAccTransaction_Class> OLAP_GetSubactionAccTransaction(OLAP_GetSubactionAccTransaction_Input input)
        {
            var ret = AccountTransaction.OLAP_GetSubactionAccTransaction(input.SUBACTIONPROCEDURE);
            return ret;
        }

        public class GetProcTrxsByDateAndProc_Input
        {
            public DateTime STARTDATE
            {
                get;
                set;
            }

            public DateTime ENDDATE
            {
                get;
                set;
            }

            public Guid STATE
            {
                get;
                set;
            }

            public Guid PROCEDURE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<AccountTransaction> GetProcTrxsByDateAndProc(GetProcTrxsByDateAndProc_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = AccountTransaction.GetProcTrxsByDateAndProc(objectContext, input.STARTDATE, input.ENDDATE, input.STATE, input.PROCEDURE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetMatTrxsByDateAndMat_Input
        {
            public DateTime STARTDATE
            {
                get;
                set;
            }

            public DateTime ENDDATE
            {
                get;
                set;
            }

            public Guid STATE
            {
                get;
                set;
            }

            public Guid MATERIAL
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<AccountTransaction> GetMatTrxsByDateAndMat(GetMatTrxsByDateAndMat_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = AccountTransaction.GetMatTrxsByDateAndMat(objectContext, input.STARTDATE, input.ENDDATE, input.STATE, input.MATERIAL);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetSubActionProcedureTrxsBySEP_Input
        {
            public Guid SEP
            {
                get;
                set;
            }

            public IList<Guid> STATES
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<AccountTransaction> GetSubActionProcedureTrxsBySEP(GetSubActionProcedureTrxsBySEP_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = AccountTransaction.GetSubActionProcedureTrxsBySEP(objectContext, input.SEP, input.STATES);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetSubActionMaterialTrxsBySEP_Input
        {
            public Guid SEP
            {
                get;
                set;
            }

            public IList<Guid> STATES
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<AccountTransaction> GetSubActionMaterialTrxsBySEP(GetSubActionMaterialTrxsBySEP_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = AccountTransaction.GetSubActionMaterialTrxsBySEP(objectContext, input.SEP, input.STATES);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetTransactionsBySEP_Input
        {
            public Guid SEP
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<AccountTransaction> GetTransactionsBySEP(GetTransactionsBySEP_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = AccountTransaction.GetTransactionsBySEP(objectContext, input.SEP);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetProcTrxsByDate_Input
        {
            public DateTime STARTDATE
            {
                get;
                set;
            }

            public DateTime ENDDATE
            {
                get;
                set;
            }

            public Guid STATE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<AccountTransaction> GetProcTrxsByDate(GetProcTrxsByDate_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = AccountTransaction.GetProcTrxsByDate(objectContext, input.STARTDATE, input.ENDDATE, input.STATE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetMatTrxsByDate_Input
        {
            public DateTime STARTDATE
            {
                get;
                set;
            }

            public DateTime ENDDATE
            {
                get;
                set;
            }

            public Guid STATE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<AccountTransaction> GetMatTrxsByDate(GetMatTrxsByDate_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = AccountTransaction.GetMatTrxsByDate(objectContext, input.STARTDATE, input.ENDDATE, input.STATE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetToBeNewTrxsByEpisode_Input
        {
            public Guid EPISODE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<AccountTransaction.GetToBeNewTrxsByEpisode_Class> GetToBeNewTrxsByEpisode(GetToBeNewTrxsByEpisode_Input input)
        {
            var ret = AccountTransaction.GetToBeNewTrxsByEpisode(input.EPISODE);
            return ret;
        }

        public class GetIncomesFromDepartment_Input
        {
            public DateTime STARTDATE
            {
                get;
                set;
            }

            public DateTime ENDDATE
            {
                get;
                set;
            }

            public IList<Guid> DEPARTMENT
            {
                get;
                set;
            }

            public int DEPARTMENTFLAG
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<AccountTransaction.GetIncomesFromDepartment_Class> GetIncomesFromDepartment(GetIncomesFromDepartment_Input input)
        {
            var ret = AccountTransaction.GetIncomesFromDepartment(input.STARTDATE, input.ENDDATE, input.DEPARTMENT, input.DEPARTMENTFLAG);
            return ret;
        }

        public class GetNewAndCancelledPackageTrxsBySEP_Input
        {
            public Guid SEP
            {
                get;
                set;
            }

            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<AccountTransaction> GetNewAndCancelledPackageTrxsBySEP(GetNewAndCancelledPackageTrxsBySEP_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = AccountTransaction.GetNewAndCancelledPackageTrxsBySEP(objectContext, input.SEP, input.injectionSQL);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetNewAndCancelledProcedureTrxsBySEP_Input
        {
            public Guid SEP
            {
                get;
                set;
            }

            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<AccountTransaction> GetNewAndCancelledProcedureTrxsBySEP(GetNewAndCancelledProcedureTrxsBySEP_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = AccountTransaction.GetNewAndCancelledProcedureTrxsBySEP(objectContext, input.SEP, input.injectionSQL);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class DetailedRevenueListProcedureQuery_Input
        {
            public DateTime STARTDATE
            {
                get;
                set;
            }

            public DateTime ENDDATE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<AccountTransaction.DetailedRevenueListProcedureQuery_Class> DetailedRevenueListProcedureQuery(DetailedRevenueListProcedureQuery_Input input)
        {
            var ret = AccountTransaction.DetailedRevenueListProcedureQuery(input.STARTDATE, input.ENDDATE);
            return ret;
        }

        public class GetTransactionsInsidePackageBySEP_Input
        {
            public Guid PACKAGE
            {
                get;
                set;
            }

            public Guid SEP
            {
                get;
                set;
            }

            public Guid APR
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<AccountTransaction> GetTransactionsInsidePackageBySEP(GetTransactionsInsidePackageBySEP_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = AccountTransaction.GetTransactionsInsidePackageBySEP(objectContext, input.PACKAGE, input.SEP, input.APR);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetTransactionsForCollectedInvoiceByResource_Tooth_Input
        {
            public DateTime STARTDATE
            {
                get;
                set;
            }

            public DateTime ENDDATE
            {
                get;
                set;
            }

            public IList<Guid> PAYER
            {
                get;
                set;
            }

            public IList<int> PATIENTSTATUS
            {
                get;
                set;
            }

            public IList<Guid> RESOURCE
            {
                get;
                set;
            }

            public int RESOURCEFLAG
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<AccountTransaction> GetTransactionsForCollectedInvoiceByResource_Tooth(GetTransactionsForCollectedInvoiceByResource_Tooth_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = AccountTransaction.GetTransactionsForCollectedInvoiceByResource_Tooth(objectContext, input.STARTDATE, input.ENDDATE, input.PAYER, input.PATIENTSTATUS, input.RESOURCE, input.RESOURCEFLAG);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetTransactionsForReceiptByEpisode_Input
        {
            public Guid CURRENTSTATEID
            {
                get;
                set;
            }

            public Guid EPISODE
            {
                get;
                set;
            }

            public Guid APR
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<AccountTransaction> GetTransactionsForReceiptByEpisode(GetTransactionsForReceiptByEpisode_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = AccountTransaction.GetTransactionsForReceiptByEpisode(objectContext, input.CURRENTSTATEID, input.EPISODE, input.APR);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetTransactionsBySEPAndPackageDef_Input
        {
            public Guid SEP
            {
                get;
                set;
            }

            public Guid PACKAGE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<AccountTransaction> GetTransactionsBySEPAndPackageDef(GetTransactionsBySEPAndPackageDef_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = AccountTransaction.GetTransactionsBySEPAndPackageDef(objectContext, input.SEP, input.PACKAGE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetMaterialListByDateAndDepartment_Input
        {
            public DateTime STARTDATE
            {
                get;
                set;
            }

            public DateTime ENDDATE
            {
                get;
                set;
            }

            public int PATIENTSTATUS1
            {
                get;
                set;
            }

            public int PATIENTSTATUS2
            {
                get;
                set;
            }

            public int PATIENTSTATUS3
            {
                get;
                set;
            }

            public IList<Guid> RESOURCE
            {
                get;
                set;
            }

            public int RESOURCEFLAG
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<AccountTransaction.GetMaterialListByDateAndDepartment_Class> GetMaterialListByDateAndDepartment(GetMaterialListByDateAndDepartment_Input input)
        {
            var ret = AccountTransaction.GetMaterialListByDateAndDepartment(input.STARTDATE, input.ENDDATE, input.PATIENTSTATUS1, input.PATIENTSTATUS2, input.PATIENTSTATUS3, input.RESOURCE, input.RESOURCEFLAG);
            return ret;
        }

        public class GetNotInvoicedPatientListByPatientStatus_Input
        {
            public DateTime STARTDATE
            {
                get;
                set;
            }

            public DateTime ENDDATE
            {
                get;
                set;
            }

            public int PATIENTSTATUS1
            {
                get;
                set;
            }

            public int PATIENTSTATUS2
            {
                get;
                set;
            }

            public int PATIENTSTATUS3
            {
                get;
                set;
            }

            public IList<Guid> PAYER
            {
                get;
                set;
            }

            public int PAYERFLAG
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<AccountTransaction.GetNotInvoicedPatientListByPatientStatus_Class> GetNotInvoicedPatientListByPatientStatus(GetNotInvoicedPatientListByPatientStatus_Input input)
        {
            var ret = AccountTransaction.GetNotInvoicedPatientListByPatientStatus(input.STARTDATE, input.ENDDATE, input.PATIENTSTATUS1, input.PATIENTSTATUS2, input.PATIENTSTATUS3, input.PAYER, input.PAYERFLAG);
            return ret;
        }

        public class DetailedRevenueListMaterialQuery_Input
        {
            public DateTime STARTDATE
            {
                get;
                set;
            }

            public DateTime ENDDATE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<AccountTransaction.DetailedRevenueListMaterialQuery_Class> DetailedRevenueListMaterialQuery(DetailedRevenueListMaterialQuery_Input input)
        {
            var ret = AccountTransaction.DetailedRevenueListMaterialQuery(input.STARTDATE, input.ENDDATE);
            return ret;
        }

        public class GetMaterialTrxsByHospitalProtocolNo_Input
        {
            public string HOSPITALPROTOCOLNO
            {
                get;
                set;
            }

            public DateTime STARTDATE
            {
                get;
                set;
            }

            public DateTime ENDDATE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<AccountTransaction.GetMaterialTrxsByHospitalProtocolNo_Class> GetMaterialTrxsByHospitalProtocolNo(GetMaterialTrxsByHospitalProtocolNo_Input input)
        {
            var ret = AccountTransaction.GetMaterialTrxsByHospitalProtocolNo(input.HOSPITALPROTOCOLNO, input.STARTDATE, input.ENDDATE);
            return ret;
        }

        public class GetPatientParticipationTransactions_Input
        {
            public DateTime STARTDATE
            {
                get;
                set;
            }

            public DateTime ENDDATE
            {
                get;
                set;
            }

            public Guid PARTICIPATIONPROCEDURE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<AccountTransaction.GetPatientParticipationTransactions_Class> GetPatientParticipationTransactions(GetPatientParticipationTransactions_Input input)
        {
            var ret = AccountTransaction.GetPatientParticipationTransactions(input.STARTDATE, input.ENDDATE, input.PARTICIPATIONPROCEDURE);
            return ret;
        }

        public class CollectedInvoiceProcedureDetailReportQueryCheck_Input
        {
            public string COLLINVOICEOBJID
            {
                get;
                set;
            }

            public IList<string> RESOURCE
            {
                get;
                set;
            }

            public int RESOURCEFLAG
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<AccountTransaction.CollectedInvoiceProcedureDetailReportQueryCheck_Class> CollectedInvoiceProcedureDetailReportQueryCheck(CollectedInvoiceProcedureDetailReportQueryCheck_Input input)
        {
            var ret = AccountTransaction.CollectedInvoiceProcedureDetailReportQueryCheck(input.COLLINVOICEOBJID, input.RESOURCE, input.RESOURCEFLAG);
            return ret;
        }

        public class GetProcedureTrxsByHospitalProtocolNo_Input
        {
            public string HOSPITALPROTOCOLNO
            {
                get;
                set;
            }

            public DateTime STARTDATE
            {
                get;
                set;
            }

            public DateTime ENDDATE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<AccountTransaction.GetProcedureTrxsByHospitalProtocolNo_Class> GetProcedureTrxsByHospitalProtocolNo(GetProcedureTrxsByHospitalProtocolNo_Input input)
        {
            var ret = AccountTransaction.GetProcedureTrxsByHospitalProtocolNo(input.HOSPITALPROTOCOLNO, input.STARTDATE, input.ENDDATE);
            return ret;
        }

        public class GetDrugTrxsByHospitalProtocolNo_Input
        {
            public string HOSPITALPROTOCOLNO
            {
                get;
                set;
            }

            public DateTime STARTDATE
            {
                get;
                set;
            }

            public DateTime ENDDATE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<AccountTransaction.GetDrugTrxsByHospitalProtocolNo_Class> GetDrugTrxsByHospitalProtocolNo(GetDrugTrxsByHospitalProtocolNo_Input input)
        {
            var ret = AccountTransaction.GetDrugTrxsByHospitalProtocolNo(input.HOSPITALPROTOCOLNO, input.STARTDATE, input.ENDDATE);
            return ret;
        }

        public class GetProcedureIncomesByMasterResource_Input
        {
            public IList<Guid> DEPARTMENT
            {
                get;
                set;
            }

            public int DEPARTMENTFLAG
            {
                get;
                set;
            }

            public DateTime STARTDATE
            {
                get;
                set;
            }

            public DateTime ENDDATE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<AccountTransaction.GetProcedureIncomesByMasterResource_Class> GetProcedureIncomesByMasterResource(GetProcedureIncomesByMasterResource_Input input)
        {
            var ret = AccountTransaction.GetProcedureIncomesByMasterResource(input.DEPARTMENT, input.DEPARTMENTFLAG, input.STARTDATE, input.ENDDATE);
            return ret;
        }

        public class CollInvoiceDetailedRevenueListMaterialQuery_Input
        {
            public IList<string> ID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<AccountTransaction.CollInvoiceDetailedRevenueListMaterialQuery_Class> CollInvoiceDetailedRevenueListMaterialQuery(CollInvoiceDetailedRevenueListMaterialQuery_Input input)
        {
            var ret = AccountTransaction.CollInvoiceDetailedRevenueListMaterialQuery(input.ID);
            return ret;
        }

        public class GetNewAndCancelledTrxsBySEP_Input
        {
            public string SEP
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<AccountTransaction> GetNewAndCancelledTrxsBySEP(GetNewAndCancelledTrxsBySEP_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = AccountTransaction.GetNewAndCancelledTrxsBySEP(objectContext, input.SEP);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetForInvoiceInclusionBySEP_Input
        {
            public Guid SEP
            {
                get;
                set;
            }

            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<AccountTransaction> GetForInvoiceInclusionBySEP(GetForInvoiceInclusionBySEP_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = AccountTransaction.GetForInvoiceInclusionBySEP(objectContext, input.SEP, input.injectionSQL);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetTransactionsByPayerInvoice_Input
        {
            public Guid PAYERINVOICE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<AccountTransaction> GetTransactionsByPayerInvoice(GetTransactionsByPayerInvoice_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = AccountTransaction.GetTransactionsByPayerInvoice(objectContext, input.PAYERINVOICE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetMedulaDontSendDrugTrxsByDate_Input
        {
            public DateTime STARTDATE
            {
                get;
                set;
            }

            public DateTime ENDDATE
            {
                get;
                set;
            }

            public IList<Guid> BRANCH
            {
                get;
                set;
            }

            public int BRANCHFLAG
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<AccountTransaction.GetMedulaDontSendDrugTrxsByDate_Class> GetMedulaDontSendDrugTrxsByDate(GetMedulaDontSendDrugTrxsByDate_Input input)
        {
            var ret = AccountTransaction.GetMedulaDontSendDrugTrxsByDate(input.STARTDATE, input.ENDDATE, input.BRANCH, input.BRANCHFLAG);
            return ret;
        }

        public class GetMedulaDontSendProcedureTrxsByDate_Input
        {
            public DateTime STARTDATE
            {
                get;
                set;
            }

            public DateTime ENDDATE
            {
                get;
                set;
            }

            public IList<Guid> BRANCH
            {
                get;
                set;
            }

            public int BRANCHFLAG
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<AccountTransaction.GetMedulaDontSendProcedureTrxsByDate_Class> GetMedulaDontSendProcedureTrxsByDate(GetMedulaDontSendProcedureTrxsByDate_Input input)
        {
            var ret = AccountTransaction.GetMedulaDontSendProcedureTrxsByDate(input.STARTDATE, input.ENDDATE, input.BRANCH, input.BRANCHFLAG);
            return ret;
        }

        public class GetMedulaDontSendMaterialTrxsByDate_Input
        {
            public DateTime STARTDATE
            {
                get;
                set;
            }

            public DateTime ENDDATE
            {
                get;
                set;
            }

            public IList<Guid> BRANCH
            {
                get;
                set;
            }

            public int BRANCHFLAG
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<AccountTransaction.GetMedulaDontSendMaterialTrxsByDate_Class> GetMedulaDontSendMaterialTrxsByDate(GetMedulaDontSendMaterialTrxsByDate_Input input)
        {
            var ret = AccountTransaction.GetMedulaDontSendMaterialTrxsByDate(input.STARTDATE, input.ENDDATE, input.BRANCH, input.BRANCHFLAG);
            return ret;
        }

        public class GetPackageTrxsForInvoice_Input
        {
            public Guid STATE
            {
                get;
                set;
            }

            public Guid APR
            {
                get;
                set;
            }

            public Guid SEP
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<AccountTransaction> GetPackageTrxsForInvoice(GetPackageTrxsForInvoice_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = AccountTransaction.GetPackageTrxsForInvoice(objectContext, input.STATE, input.APR, input.SEP);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetProcedureTrxsForInvoice_Input
        {
            public Guid STATE
            {
                get;
                set;
            }

            public Guid APR
            {
                get;
                set;
            }

            public Guid SEP
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<AccountTransaction> GetProcedureTrxsForInvoice(GetProcedureTrxsForInvoice_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = AccountTransaction.GetProcedureTrxsForInvoice(objectContext, input.STATE, input.APR, input.SEP);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetMaterialTrxsForInvoice_Input
        {
            public Guid STATE
            {
                get;
                set;
            }

            public Guid APR
            {
                get;
                set;
            }

            public Guid SEP
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<AccountTransaction> GetMaterialTrxsForInvoice(GetMaterialTrxsForInvoice_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = AccountTransaction.GetMaterialTrxsForInvoice(objectContext, input.STATE, input.APR, input.SEP);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetTransactionsForCollInvByResource_OutPatient_Input
        {
            public DateTime STARTDATE
            {
                get;
                set;
            }

            public DateTime ENDDATE
            {
                get;
                set;
            }

            public IList<Guid> PAYER
            {
                get;
                set;
            }

            public IList<Guid> RESOURCE
            {
                get;
                set;
            }

            public int RESOURCEFLAG
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<AccountTransaction> GetTransactionsForCollInvByResource_OutPatient(GetTransactionsForCollInvByResource_OutPatient_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = AccountTransaction.GetTransactionsForCollInvByResource_OutPatient(objectContext, input.STARTDATE, input.ENDDATE, input.PAYER, input.RESOURCE, input.RESOURCEFLAG);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetTransactionsForInvoiceBySEP_Input
        {
            public Guid SEP
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<AccountTransaction.GetTransactionsForInvoiceBySEP_Class> GetTransactionsForInvoiceBySEP(GetTransactionsForInvoiceBySEP_Input input)
        {
            List<Guid> blockStates = new List<Guid>();
            var ret = AccountTransaction.GetTransactionsForInvoiceBySEP(input.SEP, 1, blockStates); //1 geçici olarak verildi. PAYER
            return ret;
        }

        public class GetMaterialIncomesByMasterResource_Input
        {
            public IList<Guid> DEPARTMENT
            {
                get;
                set;
            }

            public int DEPARTMENTFLAG
            {
                get;
                set;
            }

            public DateTime STARTDATE
            {
                get;
                set;
            }

            public DateTime ENDDATE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<AccountTransaction.GetMaterialIncomesByMasterResource_Class> GetMaterialIncomesByMasterResource(GetMaterialIncomesByMasterResource_Input input)
        {
            var ret = AccountTransaction.GetMaterialIncomesByMasterResource(input.DEPARTMENT, input.DEPARTMENTFLAG, input.STARTDATE, input.ENDDATE);
            return ret;
        }

        public class GetMaterialIncomesByRessection_Input
        {
            public IList<Guid> DEPARTMENT
            {
                get;
                set;
            }

            public int DEPARTMENTFLAG
            {
                get;
                set;
            }

            public DateTime STARTDATE
            {
                get;
                set;
            }

            public DateTime ENDDATE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<AccountTransaction.GetMaterialIncomesByRessection_Class> GetMaterialIncomesByRessection(GetMaterialIncomesByRessection_Input input)
        {
            var ret = AccountTransaction.GetMaterialIncomesByRessection(input.DEPARTMENT, input.DEPARTMENTFLAG, input.STARTDATE, input.ENDDATE);
            return ret;
        }

        public class GetDrugIncomesByRessection_Input
        {
            public IList<Guid> DEPARTMENT
            {
                get;
                set;
            }

            public int DEPARTMENTFLAG
            {
                get;
                set;
            }

            public DateTime STARTDATE
            {
                get;
                set;
            }

            public DateTime ENDDATE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<AccountTransaction.GetDrugIncomesByRessection_Class> GetDrugIncomesByRessection(GetDrugIncomesByRessection_Input input)
        {
            var ret = AccountTransaction.GetDrugIncomesByRessection(input.DEPARTMENT, input.DEPARTMENTFLAG, input.STARTDATE, input.ENDDATE);
            return ret;
        }

        public class GetTransactionsForCollInvByResource_InPatient_Input
        {
            public DateTime STARTDATE
            {
                get;
                set;
            }

            public DateTime ENDDATE
            {
                get;
                set;
            }

            public IList<Guid> PAYER
            {
                get;
                set;
            }

            public IList<Guid> RESOURCE
            {
                get;
                set;
            }

            public int RESOURCEFLAG
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<AccountTransaction> GetTransactionsForCollInvByResource_InPatient(GetTransactionsForCollInvByResource_InPatient_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = AccountTransaction.GetTransactionsForCollInvByResource_InPatient(objectContext, input.STARTDATE, input.ENDDATE, input.PAYER, input.RESOURCE, input.RESOURCEFLAG);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        [HttpPost]
        public BindingList<AccountTransaction> GetMedulaProcessNoExistsAndWrongState()
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = AccountTransaction.GetMedulaProcessNoExistsAndWrongState(objectContext);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetMedulaTransactionsByProvisionNoAndState_Input
        {
            public string PROVISIONNO
            {
                get;
                set;
            }

            public IList<Guid> STATES
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<AccountTransaction> GetMedulaTransactionsByProvisionNoAndState(GetMedulaTransactionsByProvisionNoAndState_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = AccountTransaction.GetMedulaTransactionsByProvisionNoAndState(objectContext, input.PROVISIONNO, input.STATES);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetCountForMedulaBySEP_Input
        {
            public Guid SEP
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<AccountTransaction.GetCountForMedulaBySEP_Class> GetCountForMedulaBySEP(GetCountForMedulaBySEP_Input input)
        {
            var ret = AccountTransaction.GetCountForMedulaBySEP(input.SEP);
            return ret;
        }

        public class GetNewAndToBeNewPackageTrxsBySEP_Input
        {
            public Guid SEP
            {
                get;
                set;
            }

            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<AccountTransaction> GetNewAndToBeNewPackageTrxsBySEP(GetNewAndToBeNewPackageTrxsBySEP_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = AccountTransaction.GetNewAndToBeNewPackageTrxsBySEP(objectContext, input.SEP, input.injectionSQL);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetMaterialTrxsBySEPAndCode_Input
        {
            public Guid SEP
            {
                get;
                set;
            }

            public string EXTERNALCODE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<AccountTransaction.GetMaterialTrxsBySEPAndCode_Class> GetMaterialTrxsBySEPAndCode(GetMaterialTrxsBySEPAndCode_Input input)
        {
            var ret = AccountTransaction.GetMaterialTrxsBySEPAndCode(input.SEP, input.EXTERNALCODE);
            return ret;
        }

        public class GetById_Input
        {
            public IList<int> ID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<AccountTransaction> GetById(GetById_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = AccountTransaction.GetById(objectContext, input.ID);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetProcedureIncomesByRessection_Input
        {
            public IList<Guid> DEPARTMENT
            {
                get;
                set;
            }

            public int DEPARTMENTFLAG
            {
                get;
                set;
            }

            public DateTime STARTDATE
            {
                get;
                set;
            }

            public DateTime ENDDATE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<AccountTransaction.GetProcedureIncomesByRessection_Class> GetProcedureIncomesByRessection(GetProcedureIncomesByRessection_Input input)
        {
            var ret = AccountTransaction.GetProcedureIncomesByRessection(input.DEPARTMENT, input.DEPARTMENTFLAG, input.STARTDATE, input.ENDDATE);
            return ret;
        }

        public class GetPatientTotalNotPaid_Input
        {
            public Guid APR
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<AccountTransaction.GetPatientTotalNotPaid_Class> GetPatientTotalNotPaid(GetPatientTotalNotPaid_Input input)
        {
            var ret = AccountTransaction.GetPatientTotalNotPaid(input.APR);
            return ret;
        }

        public class GetPayerTotalPriceBySubEpisode_Input
        {
            public Guid SUBEPISODE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<AccountTransaction.GetPayerTotalPriceBySubEpisode_Class> GetPayerTotalPriceBySubEpisode(GetPayerTotalPriceBySubEpisode_Input input)
        {
            var ret = AccountTransaction.GetPayerTotalPriceBySubEpisode(input.SUBEPISODE);
            return ret;
        }

        public class GetMedulaEntryPriceBySEP_Input
        {
            public Guid SEP
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<AccountTransaction.GetMedulaEntryPriceBySEP_Class> GetMedulaEntryPriceBySEP(GetMedulaEntryPriceBySEP_Input input)
        {
            var ret = AccountTransaction.GetMedulaEntryPriceBySEP(input.SEP);
            return ret;
        }

        public class GetMedulaTransactionsBySEPAndState_Input
        {
            public Guid SEP
            {
                get;
                set;
            }

            public IList<Guid> STATES
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<AccountTransaction.GetMedulaTransactionsBySEPAndState_Class> GetMedulaTransactionsBySEPAndState(GetMedulaTransactionsBySEPAndState_Input input)
        {
            var ret = AccountTransaction.GetMedulaTransactionsBySEPAndState(input.SEP, input.STATES);
            return ret;
        }

        public class GetTransactionsToSendMedulaBySEP_Input
        {
            public Guid SEP
            {
                get;
                set;
            }

            public IList<Guid> STATES
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<AccountTransaction> GetTransactionsToSendMedulaBySEP(GetTransactionsToSendMedulaBySEP_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = AccountTransaction.GetTransactionsToSendMedulaBySEP(objectContext, input.SEP, input.STATES);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class CollectedInvoiceProcDetPreviewReportQuery1_Input
        {
            public IList<string> PARAMRESOURCE
            {
                get;
                set;
            }

            public int PARAMRESOURCEFLAG
            {
                get;
                set;
            }

            public IList<string> PARAMEPISODE
            {
                get;
                set;
            }

            public IList<string> PARAMPAYER
            {
                get;
                set;
            }

            public int PATIENTSTATUS
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<AccountTransaction.CollectedInvoiceProcDetPreviewReportQuery1_Class> CollectedInvoiceProcDetPreviewReportQuery1(CollectedInvoiceProcDetPreviewReportQuery1_Input input)
        {
            var ret = AccountTransaction.CollectedInvoiceProcDetPreviewReportQuery1(input.PARAMRESOURCE, input.PARAMRESOURCEFLAG, input.PARAMEPISODE, input.PARAMPAYER, input.PATIENTSTATUS);
            return ret;
        }

        public class GetNewAndCancelledMaterialTrxsBySEP_Input
        {
            public Guid SEP
            {
                get;
                set;
            }

            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<AccountTransaction> GetNewAndCancelledMaterialTrxsBySEP(GetNewAndCancelledMaterialTrxsBySEP_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = AccountTransaction.GetNewAndCancelledMaterialTrxsBySEP(objectContext, input.SEP, input.injectionSQL);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class OLAP_GetInvoiceByResource_Input
        {
            public DateTime STARTDATE
            {
                get;
                set;
            }

            public DateTime ENDDATE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<AccountTransaction.OLAP_GetInvoiceByResource_Class> OLAP_GetInvoiceByResource(OLAP_GetInvoiceByResource_Input input)
        {
            var ret = AccountTransaction.OLAP_GetInvoiceByResource(input.STARTDATE, input.ENDDATE);
            return ret;
        }

        public class OLAP_GetInvoiceByPharmacyResource_Input
        {
            public DateTime STARTDATE
            {
                get;
                set;
            }

            public DateTime ENDDATE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<AccountTransaction.OLAP_GetInvoiceByPharmacyResource_Class> OLAP_GetInvoiceByPharmacyResource(OLAP_GetInvoiceByPharmacyResource_Input input)
        {
            var ret = AccountTransaction.OLAP_GetInvoiceByPharmacyResource(input.STARTDATE, input.ENDDATE);
            return ret;
        }

        public class GetInvoicedSubActionProcedureTrxsBySEP_Input
        {
            public Guid SEP
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<AccountTransaction> GetInvoicedSubActionProcedureTrxsBySEP(GetInvoicedSubActionProcedureTrxsBySEP_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = AccountTransaction.GetInvoicedSubActionProcedureTrxsBySEP(objectContext, input.SEP);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class CollectedInvoiceProcDetPreviewReportQuery2_Input
        {
            public IList<string> PARAMPAYER
            {
                get;
                set;
            }

            public IList<string> PARAMRESOURCE
            {
                get;
                set;
            }

            public IList<string> PARAMRESOURCE2
            {
                get;
                set;
            }

            public IList<string> PARAMEPISODE
            {
                get;
                set;
            }

            public int PATIENTSTATUS
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<AccountTransaction.CollectedInvoiceProcDetPreviewReportQuery2_Class> CollectedInvoiceProcDetPreviewReportQuery2(CollectedInvoiceProcDetPreviewReportQuery2_Input input)
        {
            var ret = AccountTransaction.CollectedInvoiceProcDetPreviewReportQuery2(input.PARAMPAYER, input.PARAMRESOURCE, input.PARAMRESOURCE2, input.PARAMEPISODE, input.PATIENTSTATUS);
            return ret;
        }

        public class GetOrthesisProsthesisByProtocolNoAndYear_Input
        {
            public DateTime STARTDATE
            {
                get;
                set;
            }

            public DateTime ENDDATE
            {
                get;
                set;
            }

            public string PROTOCOLNO
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<AccountTransaction.GetOrthesisProsthesisByProtocolNoAndYear_Class> GetOrthesisProsthesisByProtocolNoAndYear(GetOrthesisProsthesisByProtocolNoAndYear_Input input)
        {
            var ret = AccountTransaction.GetOrthesisProsthesisByProtocolNoAndYear(input.STARTDATE, input.ENDDATE, input.PROTOCOLNO);
            return ret;
        }

        public class GetProcedureTrxToSendMedulaByEpisode_Input
        {
            public Guid EPISODE
            {
                get;
                set;
            }

            public IList<Guid> STATES
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<AccountTransaction> GetProcedureTrxToSendMedulaByEpisode(GetProcedureTrxToSendMedulaByEpisode_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = AccountTransaction.GetProcedureTrxToSendMedulaByEpisode(objectContext, input.EPISODE, input.STATES);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetPackageTrxsByEpisode_Input
        {
            public Guid EPISODE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<AccountTransaction.GetPackageTrxsByEpisode_Class> GetPackageTrxsByEpisode(GetPackageTrxsByEpisode_Input input)
        {
            var ret = AccountTransaction.GetPackageTrxsByEpisode(input.EPISODE);
            return ret;
        }

        public class GetTrxBySEPProcedureAndState_Input
        {
            public IList<Guid> SEP
            {
                get;
                set;
            }

            public Guid PROCEDURE
            {
                get;
                set;
            }

            public IList<Guid> STATES
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<AccountTransaction> GetTrxBySEPProcedureAndState(GetTrxBySEPProcedureAndState_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = AccountTransaction.GetTrxBySEPProcedureAndState(objectContext, input.SEP, input.PROCEDURE, input.STATES);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetOrthesisProsthesisByProcedureAndDate_Input
        {
            public DateTime STARTDATE
            {
                get;
                set;
            }

            public DateTime ENDDATE
            {
                get;
                set;
            }

            public IList<string> PROCEDURE
            {
                get;
                set;
            }

            public int PROCEDUREFLAG
            {
                get;
                set;
            }

            public IList<string> STATEID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<AccountTransaction.GetOrthesisProsthesisByProcedureAndDate_Class> GetOrthesisProsthesisByProcedureAndDate(GetOrthesisProsthesisByProcedureAndDate_Input input)
        {
            var ret = AccountTransaction.GetOrthesisProsthesisByProcedureAndDate(input.STARTDATE, input.ENDDATE, input.PROCEDURE, input.PROCEDUREFLAG, input.STATEID);
            return ret;
        }

        public class CollInvoiceDetailedRevenueListProcedureQuery_Input
        {
            public IList<string> ID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<AccountTransaction.CollInvoiceDetailedRevenueListProcedureQuery_Class> CollInvoiceDetailedRevenueListProcedureQuery(CollInvoiceDetailedRevenueListProcedureQuery_Input input)
        {
            var ret = AccountTransaction.CollInvoiceDetailedRevenueListProcedureQuery(input.ID);
            return ret;
        }

        public class GetOrthesisProsthesisTrxsForInvoice_Input
        {
            public Guid STATE
            {
                get;
                set;
            }

            public Guid APR
            {
                get;
                set;
            }

            public Guid SEP
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<AccountTransaction> GetOrthesisProsthesisTrxsForInvoice(GetOrthesisProsthesisTrxsForInvoice_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = AccountTransaction.GetOrthesisProsthesisTrxsForInvoice(objectContext, input.STATE, input.APR, input.SEP);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetAllTransactionsBySEP_Input
        {
            public Guid SEP
            {
                get;
                set;
            }

            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<AccountTransaction> GetAllTransactionsBySEP(GetAllTransactionsBySEP_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = AccountTransaction.GetAllTransactionsBySEP(objectContext, input.SEP, input.injectionSQL);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetMedulaTransactionCountBySEPAndState_Input
        {
            public Guid SEP
            {
                get;
                set;
            }

            public IList<Guid> STATES
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<AccountTransaction.GetMedulaTransactionCountBySEPAndState_Class> GetMedulaTransactionCountBySEPAndState(GetMedulaTransactionCountBySEPAndState_Input input)
        {
            var ret = AccountTransaction.GetMedulaTransactionCountBySEPAndState(input.SEP, input.STATES);
            return ret;
        }

        public class GetPatientTotalPriceBySubEpisode_Input
        {
            public Guid SUBEPISODE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<AccountTransaction.GetPatientTotalPriceBySubEpisode_Class> GetPatientTotalPriceBySubEpisode(GetPatientTotalPriceBySubEpisode_Input input)
        {
            var ret = AccountTransaction.GetPatientTotalPriceBySubEpisode(input.SUBEPISODE);
            return ret;
        }

        public class GetPayerTotalPriceByEpisode_Input
        {
            public Guid EPISODE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<AccountTransaction.GetPayerTotalPriceByEpisode_Class> GetPayerTotalPriceByEpisode(GetPayerTotalPriceByEpisode_Input input)
        {
            var ret = AccountTransaction.GetPayerTotalPriceByEpisode(input.EPISODE);
            return ret;
        }

        public class GetPatientTotalPriceByEpisode_Input
        {
            public Guid EPISODE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<AccountTransaction.GetPatientTotalPriceByEpisode_Class> GetPatientTotalPriceByEpisode(GetPatientTotalPriceByEpisode_Input input)
        {
            var ret = AccountTransaction.GetPatientTotalPriceByEpisode(input.EPISODE);
            return ret;
        }

        public class GetTransactionsWithMedulaProcessNoBySEP_Input
        {
            public IList<Guid> SEP
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<AccountTransaction> GetTransactionsWithMedulaProcessNoBySEP(GetTransactionsWithMedulaProcessNoBySEP_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = AccountTransaction.GetTransactionsWithMedulaProcessNoBySEP(objectContext, input.SEP);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class CollInvoiceDetailedRevenueListMaterialQuery_NP_Input
        {
            public IList<string> ID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<AccountTransaction.CollInvoiceDetailedRevenueListMaterialQuery_NP_Class> CollInvoiceDetailedRevenueListMaterialQuery_NP(CollInvoiceDetailedRevenueListMaterialQuery_NP_Input input)
        {
            var ret = AccountTransaction.CollInvoiceDetailedRevenueListMaterialQuery_NP(input.ID);
            return ret;
        }

        public class CollInvoiceDetailedRevenueListProcedureQuery_NP_Input
        {
            public IList<string> ID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<AccountTransaction.CollInvoiceDetailedRevenueListProcedureQuery_NP_Class> CollInvoiceDetailedRevenueListProcedureQuery_NP(CollInvoiceDetailedRevenueListProcedureQuery_NP_Input input)
        {
            var ret = AccountTransaction.CollInvoiceDetailedRevenueListProcedureQuery_NP(input.ID);
            return ret;
        }

        public class GetTrxForMedulaBySubActionProcedure_Input
        {
            public Guid SUBACTIONPROCEDURE
            {
                get;
                set;
            }

            public IList<Guid> STATES
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<AccountTransaction> GetTrxForMedulaBySubActionProcedure(GetTrxForMedulaBySubActionProcedure_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = AccountTransaction.GetTrxForMedulaBySubActionProcedure(objectContext, input.SUBACTIONPROCEDURE, input.STATES);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetTransactionsExceptCancelledByEpisode_Input
        {
            public Guid APR
            {
                get;
                set;
            }

            public Guid EPISODE
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public BindingList<AccountTransaction> GetIncludedTrxsExceptCancelledByEpisode(GetTransactionsExceptCancelledByEpisode_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = AccountTransaction.GetIncludedTrxsExceptCancelledByEpisode(objectContext, input.APR, input.EPISODE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }
    }
}
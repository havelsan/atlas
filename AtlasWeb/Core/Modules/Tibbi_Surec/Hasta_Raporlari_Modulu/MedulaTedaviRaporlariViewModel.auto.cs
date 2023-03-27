//$17A46A22
using System;
using System.Linq;
using Core.Models;
using Infrastructure.Helpers;
using Infrastructure.Filters;
using Infrastructure.Models;
using TTInstanceManagement;
using TTObjectClasses;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    public partial class MedulaTreatmentReportServiceController : Controller
{
    [HttpGet]
    public MedulaTedaviRaporlariViewModel MedulaTedaviRaporlari(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return MedulaTedaviRaporlariLoadInternal(input);
    }

    [HttpPost]
    public MedulaTedaviRaporlariViewModel MedulaTedaviRaporlariLoad(FormLoadInput input)
    {
        return MedulaTedaviRaporlariLoadInternal(input);
    }

    private MedulaTedaviRaporlariViewModel MedulaTedaviRaporlariLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("122e4177-adec-4e2d-af68-7cfaef9780b1");
        var objectDefID = Guid.Parse("6042e3e7-271a-4c63-b3d1-877c5a37e92c");
        var viewModel = new MedulaTedaviRaporlariViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._MedulaTreatmentReport = objectContext.GetObject(id.Value, objectDefID) as MedulaTreatmentReport;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._MedulaTreatmentReport, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._MedulaTreatmentReport, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._MedulaTreatmentReport);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._MedulaTreatmentReport);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_MedulaTedaviRaporlari(viewModel, viewModel._MedulaTreatmentReport, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._MedulaTreatmentReport = new MedulaTreatmentReport(objectContext);
                var entryStateID = Guid.Parse("2c0e43f4-b22a-4d79-b152-4ccfb197231c");
                viewModel._MedulaTreatmentReport.CurrentStateDefID = entryStateID;
                viewModel.gridFizyoTerapiIslemleriGridList = new TTObjectClasses.FTRReportDetailGrid[]{};
                viewModel.gridEswtIslemiGridList = new TTObjectClasses.ESWTReportDetailGrid[]{};
                viewModel.gridTasBilgisiGridList = new TTObjectClasses.ESWLReportDetailGrid[]{};
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._MedulaTreatmentReport, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._MedulaTreatmentReport, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._MedulaTreatmentReport);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._MedulaTreatmentReport);
                PreScript_MedulaTedaviRaporlari(viewModel, viewModel._MedulaTreatmentReport, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel MedulaTedaviRaporlari(MedulaTedaviRaporlariViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("122e4177-adec-4e2d-af68-7cfaef9780b1");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.FTRReports);
            objectContext.AddToRawObjectList(viewModel.TedaviRaporiIslemKodlaris);
            objectContext.AddToRawObjectList(viewModel.FTRVucutBolgesis);
            objectContext.AddToRawObjectList(viewModel.TedaviTurus);
            objectContext.AddToRawObjectList(viewModel.ESWTReports);
            objectContext.AddToRawObjectList(viewModel.ESWLReports);
            objectContext.AddToRawObjectList(viewModel.Bobreks);
            objectContext.AddToRawObjectList(viewModel.TasLokalizasyons);
            objectContext.AddToRawObjectList(viewModel.DialysisReports);
            objectContext.AddToRawObjectList(viewModel.HomeHemodialysisReports);
            objectContext.AddToRawObjectList(viewModel.HBTReports);
            objectContext.AddToRawObjectList(viewModel.TubeBabyReports);
            objectContext.AddToRawObjectList(viewModel.ResUsers);
            objectContext.AddToRawObjectList(viewModel.gridFizyoTerapiIslemleriGridList);
            objectContext.AddToRawObjectList(viewModel.gridEswtIslemiGridList);
            objectContext.AddToRawObjectList(viewModel.gridTasBilgisiGridList);
            var entryStateID = Guid.Parse("2c0e43f4-b22a-4d79-b152-4ccfb197231c");
            objectContext.AddToRawObjectList(viewModel._MedulaTreatmentReport, entryStateID);
            objectContext.ProcessRawObjects(false);
            var medulaTreatmentReport = (MedulaTreatmentReport)objectContext.GetLoadedObject(viewModel._MedulaTreatmentReport.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(medulaTreatmentReport, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._MedulaTreatmentReport, formDefID);
            var fTRReportImported = medulaTreatmentReport.FTRReport;
            if (fTRReportImported != null)
            {
                if (viewModel.gridFizyoTerapiIslemleriGridList != null)
                {
                    foreach (var item in viewModel.gridFizyoTerapiIslemleriGridList)
                    {
                        var fTRReportDetailGridImported = (FTRReportDetailGrid)objectContext.GetLoadedObject(item.ObjectID);
                        if (((ITTObject)fTRReportDetailGridImported).IsDeleted)
                            continue;
                        fTRReportDetailGridImported.FTRReport = fTRReportImported;
                    }
                }
            }

            var eSWTReportImported = medulaTreatmentReport.ESWTReport;
            if (eSWTReportImported != null)
            {
                if (viewModel.gridEswtIslemiGridList != null)
                {
                    foreach (var item in viewModel.gridEswtIslemiGridList)
                    {
                        var eSWTReportDetailGridImported = (ESWTReportDetailGrid)objectContext.GetLoadedObject(item.ObjectID);
                        if (((ITTObject)eSWTReportDetailGridImported).IsDeleted)
                            continue;
                        eSWTReportDetailGridImported.ESWTReport = eSWTReportImported;
                    }
                }
            }

            var eSWLReportImported = medulaTreatmentReport.ESWLReport;
            if (eSWLReportImported != null)
            {
                if (viewModel.gridTasBilgisiGridList != null)
                {
                    foreach (var item in viewModel.gridTasBilgisiGridList)
                    {
                        var eSWLReportDetailGridImported = (ESWLReportDetailGrid)objectContext.GetLoadedObject(item.ObjectID);
                        if (((ITTObject)eSWLReportDetailGridImported).IsDeleted)
                            continue;
                        eSWLReportDetailGridImported.ESWLReport = eSWLReportImported;
                    }
                }
            }

            var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(medulaTreatmentReport);
            PostScript_MedulaTedaviRaporlari(viewModel, medulaTreatmentReport, transDef, objectContext);
            objectContext.AdvanceStateForNewObjects();
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(medulaTreatmentReport);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(medulaTreatmentReport);
            AfterContextSaveScript_MedulaTedaviRaporlari(viewModel, medulaTreatmentReport, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_MedulaTedaviRaporlari(MedulaTedaviRaporlariViewModel viewModel, MedulaTreatmentReport medulaTreatmentReport, TTObjectContext objectContext);
    partial void PostScript_MedulaTedaviRaporlari(MedulaTedaviRaporlariViewModel viewModel, MedulaTreatmentReport medulaTreatmentReport, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_MedulaTedaviRaporlari(MedulaTedaviRaporlariViewModel viewModel, MedulaTreatmentReport medulaTreatmentReport, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(MedulaTedaviRaporlariViewModel viewModel, TTObjectContext objectContext)
    {
        var fTRReport = viewModel._MedulaTreatmentReport.FTRReport;
        if (fTRReport != null)
        {
            viewModel.gridFizyoTerapiIslemleriGridList = fTRReport.FTRReportDetailGrid.OfType<FTRReportDetailGrid>().ToArray();
        }

        var eSWTReport = viewModel._MedulaTreatmentReport.ESWTReport;
        if (eSWTReport != null)
        {
            viewModel.gridEswtIslemiGridList = eSWTReport.ESWTReportDetailGrid.OfType<ESWTReportDetailGrid>().ToArray();
        }

        var eSWLReport = viewModel._MedulaTreatmentReport.ESWLReport;
        if (eSWLReport != null)
        {
            viewModel.gridTasBilgisiGridList = eSWLReport.ESWLReportDetailGrid.OfType<ESWLReportDetailGrid>().ToArray();
        }

        viewModel.FTRReports = objectContext.LocalQuery<FTRReport>().ToArray();
        viewModel.TedaviRaporiIslemKodlaris = objectContext.LocalQuery<TedaviRaporiIslemKodlari>().ToArray();
        viewModel.FTRVucutBolgesis = objectContext.LocalQuery<FTRVucutBolgesi>().ToArray();
        viewModel.TedaviTurus = objectContext.LocalQuery<TedaviTuru>().ToArray();
        viewModel.ESWTReports = objectContext.LocalQuery<ESWTReport>().ToArray();
        viewModel.ESWLReports = objectContext.LocalQuery<ESWLReport>().ToArray();
        viewModel.Bobreks = objectContext.LocalQuery<Bobrek>().ToArray();
        viewModel.TasLokalizasyons = objectContext.LocalQuery<TasLokalizasyon>().ToArray();
        viewModel.DialysisReports = objectContext.LocalQuery<DialysisReport>().ToArray();
        viewModel.HomeHemodialysisReports = objectContext.LocalQuery<HomeHemodialysisReport>().ToArray();
        viewModel.HBTReports = objectContext.LocalQuery<HBTReport>().ToArray();
        viewModel.TubeBabyReports = objectContext.LocalQuery<TubeBabyReport>().ToArray();
        viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "TedaviRaporlariIslemListDefinition", viewModel.TedaviRaporiIslemKodlaris);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "FTRVucutBolgesiTTObjectListDefinition", viewModel.FTRVucutBolgesis);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "TedaviTuruListDefinition", viewModel.TedaviTurus);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "BobrekListDefinition", viewModel.Bobreks);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "TasLokalizasyonListDefinition", viewModel.TasLokalizasyons);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "DoctorListDefinition", viewModel.ResUsers);
    }
}
}


namespace Core.Models
{
    public partial class MedulaTedaviRaporlariViewModel : BaseViewModel
    {
        public TTObjectClasses.MedulaTreatmentReport _MedulaTreatmentReport { get; set; }
        public TTObjectClasses.FTRReportDetailGrid[] gridFizyoTerapiIslemleriGridList { get; set; }
        public TTObjectClasses.ESWTReportDetailGrid[] gridEswtIslemiGridList { get; set; }
        public TTObjectClasses.ESWLReportDetailGrid[] gridTasBilgisiGridList { get; set; }
        public TTObjectClasses.FTRReport[] FTRReports { get; set; }
        public TTObjectClasses.TedaviRaporiIslemKodlari[] TedaviRaporiIslemKodlaris { get; set; }
        public TTObjectClasses.FTRVucutBolgesi[] FTRVucutBolgesis { get; set; }
        public TTObjectClasses.TedaviTuru[] TedaviTurus { get; set; }
        public TTObjectClasses.ESWTReport[] ESWTReports { get; set; }
        public TTObjectClasses.ESWLReport[] ESWLReports { get; set; }
        public TTObjectClasses.Bobrek[] Bobreks { get; set; }
        public TTObjectClasses.TasLokalizasyon[] TasLokalizasyons { get; set; }
        public TTObjectClasses.DialysisReport[] DialysisReports { get; set; }
        public TTObjectClasses.HomeHemodialysisReport[] HomeHemodialysisReports { get; set; }
        public TTObjectClasses.HBTReport[] HBTReports { get; set; }
        public TTObjectClasses.TubeBabyReport[] TubeBabyReports { get; set; }
        public TTObjectClasses.ResUser[] ResUsers { get; set; }
    }
}

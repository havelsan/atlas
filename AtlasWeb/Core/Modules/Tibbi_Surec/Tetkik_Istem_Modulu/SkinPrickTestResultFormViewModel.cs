//$12B27E90
using System;
using System.Linq;
using Core.Models;
using Infrastructure.Filters;
using Infrastructure.Models;
using TTInstanceManagement;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using System.Collections.Generic;
using Core.Controllers;

namespace Core.Controllers
{
    public partial class SkinPrickTestResultServiceController
    {
        partial void PreScript_SkinPrickTestResultForm(SkinPrickTestResultFormViewModel viewModel, SkinPrickTestResult skinPrickTestResult, TTObjectContext objectContext)
        {
         
            viewModel._SkinPrickList = new List<SkinPrickTest>();
            //viewModel.ActiveIDsModel.EpisodeActionId //SubactionProcedureun ObjectIDsini taþýyor

            if (skinPrickTestResult.SkinPrickTestDetail.Count > 0)
            {
                foreach(SkinPrickTestDetail item in skinPrickTestResult.SkinPrickTestDetail )
                {
                    SkinPrickTest s = new SkinPrickTest();
                    s.ObjectID = (Guid)item.BaseAdditionalApplication.ObjectID;
                    s.ProcedureCode = item.BaseAdditionalApplication.ProcedureObject.Code;
                    s.ProcedureName = item.BaseAdditionalApplication.ProcedureObject.Name;
                    s.Negative = (bool)item.Negative;
                    s.Positive = (bool)item.Positive;
                    s.Description = item.Description == null ? "": item.Description.ToString();

                    viewModel._SkinPrickList.Add(s);
                }
            }
            else
            {

                List<SubActionProcedure.GetSubactionProceduresByMasterSP_Class> procedureList = SubActionProcedure.GetSubactionProceduresByMasterSP((Guid)viewModel.ActiveIDsModel.EpisodeActionId, null).ToList();

                BaseAdditionalApplication baseAdditionalApplication = (BaseAdditionalApplication)objectContext.GetObject((Guid)viewModel.ActiveIDsModel.EpisodeActionId, "BaseAdditionalApplication");

                //Kendisi
                SkinPrickTest s = new SkinPrickTest();
                s.ObjectID = (Guid)baseAdditionalApplication.ObjectID;
                s.ProcedureCode = baseAdditionalApplication.ProcedureObject.Code;
                s.ProcedureName = baseAdditionalApplication.ProcedureObject.Name;
                s.Negative = true;
                s.Positive = false;
                s.Description = "";
                viewModel._SkinPrickList.Add(s);

                foreach (SubActionProcedure.GetSubactionProceduresByMasterSP_Class procedure in procedureList)
                {
                    //Türetilmiþler
                    s = new SkinPrickTest();
                    s.ObjectID = (Guid)procedure.ObjectID;
                    s.ProcedureCode = procedure.Procedurecode;
                    s.ProcedureName = procedure.Procedurename;
                    s.Negative = true;
                    s.Positive = false;
                    s.Description = "";
                    viewModel._SkinPrickList.Add(s);

                }
            }

        }
        partial void PostScript_SkinPrickTestResultForm(SkinPrickTestResultFormViewModel viewModel, SkinPrickTestResult skinPrickTestResult, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            if (viewModel.SkinPrickTestDetailGridList.Length > 0)
            {
               

                foreach (var item in viewModel.SkinPrickTestDetailGridList)
                {
                    var skinPrickTestDetailImported = (SkinPrickTestDetail)objectContext.GetLoadedObject(item.ObjectID);

                    foreach (SkinPrickTest detail in viewModel._SkinPrickList)
                    {
                        if (skinPrickTestDetailImported.BaseAdditionalApplication.ObjectID.ToString() == detail.ObjectID.ToString())
                        {
                            skinPrickTestDetailImported.Negative = detail.Negative;
                            skinPrickTestDetailImported.Positive = detail.Positive;
                            skinPrickTestDetailImported.Description = detail.Description;
                            skinPrickTestDetailImported.SkinPrickTestResult = skinPrickTestResult;
                        }
                    }


                   
                }

            }
            else
            {

                foreach (SkinPrickTest item in viewModel._SkinPrickList)
                {
                    SkinPrickTestDetail detail = new SkinPrickTestDetail(objectContext);
                    detail.Negative = item.Negative;
                    detail.Positive = item.Positive;
                    detail.Description = item.Description;
                    detail.BaseAdditionalApplication = objectContext.GetObject<BaseAdditionalApplication>(item.ObjectID);
                    detail.SkinPrickTestResult = viewModel._SkinPrickTestResult;
                }
            }


        }
    }
}

namespace Core.Models
{
    public partial class SkinPrickTestResultFormViewModel: BaseAdditionalInfoFormViewModel
    {
        public override BaseAdditionalInfo AddViewModelToContext(TTObjectContext objectContext)
        {
            var skinPrickTestService = new SkinPrickTestResultServiceController();
            skinPrickTestService.SkinPrickTestResultFormInternal(this, objectContext);
            return (SkinPrickTestResult)objectContext.GetObject(this._SkinPrickTestResult.ObjectID, "SkinPrickTestResult");
        }

        public List<SkinPrickTest> _SkinPrickList { get; set; }
    }

    public class SkinPrickTest
    {
        public Guid ObjectID
        {
            get;
            set;
        }

        public string ProcedureCode
        {
            get;
            set;
        }
        public string ProcedureName
        {
            get;
            set;
        }

        public bool Negative
        {
            get;
            set;
        }

        public bool Positive
        {
            get;
            set;
        }
        public string Description
        {
            get;
            set;
        }
    }
}

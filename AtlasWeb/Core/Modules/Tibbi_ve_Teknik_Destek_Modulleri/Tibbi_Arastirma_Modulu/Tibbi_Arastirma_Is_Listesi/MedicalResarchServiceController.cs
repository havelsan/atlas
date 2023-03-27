//$E47E06B5
using System;
using System.Linq;
using System.Collections.Generic;
using Core.Models;
using Infrastructure.Models;
using Infrastructure.Filters;
using TTObjectClasses;
using TTInstanceManagement;
using Microsoft.AspNetCore.Mvc;
using Core.Services;
using TTDefinitionManagement;
using System.ComponentModel;

namespace Core.Controllers
{
    [Route("api/[controller]/[action]/{id?}")]
    [HvlResult]
    public partial class MedicalResarchServiceController : Controller
    {

        [HttpPost]
        public string saveMedicalResarch(MedicalResarchViewModel medicalResarchInput)
        {
            using (var context = new TTObjectContext(false))
            {
                string returnMessage = "";
                BindingList<MedicalResarch.MedicalResarhCalcBudget_Class> getTermButget = MedicalResarch.MedicalResarhCalcBudget(medicalResarchInput.MedicalResarchTermDef.ObjectID);
                if (getTermButget.Count > 0)
                {
                    if (Convert.ToDouble(medicalResarchInput.MedicalResarchDTO.BudgetTotalPrice) > Convert.ToDouble(getTermButget[0].Totalspent))
                    {
                        returnMessage= "Araþtýrma Tutarý Dönem Harcama Limitini Geçmiþtir. Ýþlem Devam Ettirilemez.";
                    }
                    else
                    {
                        try
                        {
                            MedicalResarch medicalResarch = new MedicalResarch(context);
                            medicalResarch.BudgetTotalPrice = medicalResarchInput.MedicalResarchDTO.BudgetTotalPrice;
                            medicalResarch.Code = medicalResarchInput.MedicalResarchDTO.Code;
                            medicalResarch.Desciption = medicalResarchInput.MedicalResarchDTO.Desciption;
                            medicalResarch.StartDate = medicalResarchInput.MedicalResarchDTO.StartDate;
                            medicalResarch.EndDate = medicalResarchInput.MedicalResarchDTO.EndDate;
                            medicalResarch.MedicalResarchTermDef = medicalResarchInput.MedicalResarchTermDef;
                            medicalResarch.PatientCount = medicalResarchInput.MedicalResarchDTO.PatientCount;
                            medicalResarch.Name = medicalResarchInput.MedicalResarchDTO.Name;
                            foreach (MedicalResarchDoctor item in medicalResarchInput.MedicalResarchDoctorList)
                            {
                                ResUser resuser = context.GetObject<ResUser>(item.ObjectID);
                                MedicalResarchDoctor medicalResarchDoctor = new MedicalResarchDoctor(context);
                                medicalResarchDoctor.ResUser = resuser;
                                medicalResarchDoctor.MedicalResarch = medicalResarch;
                            }

                            foreach (MedicalResarchProcedur item in medicalResarchInput.MedicalResarchProcedurList)
                            {
                                ProcedureDefinition procedureDefinition = context.GetObject<ProcedureDefinition>(item.ObjectID);
                                MedicalResarchProcedur medicalResarchProcedur = new MedicalResarchProcedur(context);
                                medicalResarchProcedur.ProcedureDefinition = procedureDefinition;
                                medicalResarchProcedur.MedicalResarch = medicalResarch;
                            }
                            medicalResarch.CurrentStateDefID = MedicalResarch.States.New;
                            medicalResarch.PatientCount = 0;
                            context.Save();
                            returnMessage= "Araþtýrma Dönemi Kaydý Açýlmýþtýr.";
                        }
                        catch
                        {
                            returnMessage= "Hatalý iþlem";
                        }
                    }
                }
                else
                {
                    try
                    {
                        MedicalResarch medicalResarch = new MedicalResarch(context);
                        medicalResarch.BudgetTotalPrice = medicalResarchInput.MedicalResarchDTO.BudgetTotalPrice;
                        medicalResarch.Code = medicalResarchInput.MedicalResarchDTO.Code;
                        medicalResarch.Desciption = medicalResarchInput.MedicalResarchDTO.Desciption;
                        medicalResarch.StartDate = medicalResarchInput.MedicalResarchDTO.StartDate;
                        medicalResarch.EndDate = medicalResarchInput.MedicalResarchDTO.EndDate;
                        medicalResarch.MedicalResarchTermDef = medicalResarchInput.MedicalResarchTermDef;
                        medicalResarch.PatientCount = medicalResarchInput.MedicalResarchDTO.PatientCount;
                        medicalResarch.Name = medicalResarchInput.MedicalResarchDTO.Name;
                        foreach (MedicalResarchDoctor item in medicalResarchInput.MedicalResarchDoctorList)
                        {
                            ResUser resuser = context.GetObject<ResUser>(item.ObjectID);
                            MedicalResarchDoctor medicalResarchDoctor = new MedicalResarchDoctor(context);
                            medicalResarchDoctor.ResUser = resuser;
                            medicalResarchDoctor.MedicalResarch = medicalResarch;
                        }

                        foreach (MedicalResarchProcedur item in medicalResarchInput.MedicalResarchProcedurList)
                        {
                            ProcedureDefinition procedureDefinition = context.GetObject<ProcedureDefinition>(item.ObjectID);
                            MedicalResarchProcedur medicalResarchProcedur = new MedicalResarchProcedur(context);
                            medicalResarchProcedur.ProcedureDefinition = procedureDefinition;
                            medicalResarchProcedur.MedicalResarch = medicalResarch;
                        }
                        medicalResarch.CurrentStateDefID = MedicalResarch.States.New;
                        context.Save();
                        returnMessage = "Araþtýrma Dönemi Kaydý Açýlmýþtýr.";
                    }
                    catch
                    {
                        returnMessage = "Hatalý iþlem";
                    }
                }
                return returnMessage;
            }
        }

        [HttpPost]
        public string cancelMedicalResarch(MedicalResarchViewModel medicalResarchInput)
        {
            using (var context = new TTObjectContext(false))
            {
                try
                {
                    MedicalResarch medicalResarch = context.GetObject<MedicalResarch>(medicalResarchInput.MedicalResarchDTO.ObjectId);
                    medicalResarch.CurrentStateDefID = MedicalResarch.States.Cancel;
                    context.Save();
                    return "Araþtýrma Dönemi Kaydý Ýptal Edilmiþtir.";
                }
                catch
                {
                    return "Ýptal Sýrasýnda Hata Alunmýþtýr.";
                }
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]

        public LoadResult GetMedicalResarchDefList([FromBody] DataSourceLoadOptions loadOptions)
        {
            LoadResult result = null;
            using (var objectContext = new TTObjectContext(false))
            {
                TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDICALRESARCHTERMDEF"].QueryDefs["GetMedicalResarchTermDefList"];

                var paramList = new Dictionary<string, object>();
                var injection = " ISACTIVE = 1";
                //paramList = GetFilter(paramList, materialGroup, ref injection);
                result = DevexpressLoader.Load(objectContext, queryDef, loadOptions, paramList, injection);
            }
            return result;
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]

        public LoadResult GetMedicalResarchDoctorList([FromBody] DataSourceLoadOptions loadOptions)
        {
            LoadResult result = null;
            using (var objectContext = new TTObjectContext(false))
            {
                TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].QueryDefs["DoctorListNQL"];

                var paramList = new Dictionary<string, object>();
                var injection = string.Empty;
                //paramList = GetFilter(paramList, materialGroup, ref injection);
                result = DevexpressLoader.Load(objectContext, queryDef, loadOptions, paramList, injection);
            }
            return result;
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]

        public LoadResult GetMedicalResarchProcedureList([FromBody] DataSourceLoadOptions loadOptions)
        {
            LoadResult result = null;
            using (var objectContext = new TTObjectContext(false))
            {
                TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ProcedureDefinition"].QueryDefs["GetProcedureDefinitionListDefinition"];

                var paramList = new Dictionary<string, object>();
                var injection = string.Empty;
                //paramList = GetFilter(paramList, materialGroup, ref injection);
                result = DevexpressLoader.Load(objectContext, queryDef, loadOptions, paramList, injection);
            }
            return result;
        }

        [HttpPost]
        public MedicalResarchViewModel createDynemicDataSource(InputDTO input)
        {
            using (var context = new TTObjectContext(false))
            {

                MedicalResarchViewModel viewModel = new MedicalResarchViewModel();
                MedicalResarch medicalResarch = context.GetObject<MedicalResarch>(new Guid(input.MedicalResarchObjectID));

                MedicalResarchDTO _MedicalResarchDTO = new MedicalResarchDTO();
                _MedicalResarchDTO.Name = medicalResarch.Name;
                _MedicalResarchDTO.BudgetTotalPrice = medicalResarch.BudgetTotalPrice;
                _MedicalResarchDTO.Code = medicalResarch.Code;
                _MedicalResarchDTO.Desciption = medicalResarch.Desciption;
                _MedicalResarchDTO.EndDate = medicalResarch.EndDate;
                _MedicalResarchDTO.PatientCount = medicalResarch.PatientCount;
                _MedicalResarchDTO.StartDate = medicalResarch.StartDate;
                _MedicalResarchDTO.ObjectId = medicalResarch.ObjectID;

                MedicalResarchTermDef _MedicalResarchTermDef = medicalResarch.MedicalResarchTermDef;

                List<ResUser> _DoctorResUserList = new List<ResUser>();
                List<MedicalResarchDoctor> _MedicalResarchDoctorList = new List<MedicalResarchDoctor>();
                foreach (MedicalResarchDoctor item in medicalResarch.MedicalResarchDoctors.Select(""))
                {
                    _DoctorResUserList.Add(item.ResUser);
                    _MedicalResarchDoctorList.Add(item);
                }

                List<ProcedureDefinitionDTO> _ProcedureDefList = new List<ProcedureDefinitionDTO>();
                List<MedicalResarchProcedur> _MedicalResarchProcedurList = new List<MedicalResarchProcedur>();
                foreach (MedicalResarchProcedur item in medicalResarch.MedicalResarchProcedurs.Select(""))
                {
                    ProcedureDefinitionDTO definitionDTO = new ProcedureDefinitionDTO();
                    definitionDTO.Name = item.ProcedureDefinition.Name;
                    definitionDTO.Code = item.ProcedureDefinition.Code;
                    definitionDTO.ObjectId = item.ProcedureDefinition.ObjectID;
                    _ProcedureDefList.Add(definitionDTO);
                    _MedicalResarchProcedurList.Add(item);
                }

                viewModel.MedicalResarchDTO = _MedicalResarchDTO;
                viewModel.MedicalResarchTermDef = _MedicalResarchTermDef;
                viewModel.MedicalResarchDoctorList = _MedicalResarchDoctorList;
                viewModel.MedicalResarchProcedurList = _MedicalResarchProcedurList;
                viewModel.DoctorResUserList = _DoctorResUserList;
                viewModel.ProcedureDefList = _ProcedureDefList;

                if (medicalResarch.CurrentStateDefID != MedicalResarch.States.New)
                    viewModel.formIsReadOnly = true;
                else
                    viewModel.formIsReadOnly = false;

                viewModel.formName = "TIBBI ARAÞTIRMA ÝÞLEMÝ (" + medicalResarch.CurrentStateDef.DisplayText + ")";


                return viewModel;
            }
        }

        [HttpPost]
        public string updateMedicalResarch(MedicalResarchViewModel medicalResarchInput)
        {
            using (var context = new TTObjectContext(false))
            {
                string returnMessage = "";
                BindingList<MedicalResarch.MedicalResarhCalcBudget_Class> getTermButget = MedicalResarch.MedicalResarhCalcBudget(medicalResarchInput.MedicalResarchTermDef.ObjectID);
                if (getTermButget.Count > 0)
                {
                    if (Convert.ToDouble(medicalResarchInput.MedicalResarchDTO.BudgetTotalPrice) > Convert.ToDouble(getTermButget[0].Totalspent))
                    {
                        returnMessage = "Araþtýrma Tutarý Dönem Harcama Limitini Geçmiþtir. Ýþlem Devam Ettirilemez.";
                    }
                    else
                    {
                        try
                        {
                            MedicalResarch medicalResarch = context.GetObject<MedicalResarch>(medicalResarchInput.MedicalResarchDTO.ObjectId);
                            medicalResarch.BudgetTotalPrice = medicalResarchInput.MedicalResarchDTO.BudgetTotalPrice;
                            medicalResarch.Code = medicalResarchInput.MedicalResarchDTO.Code;
                            medicalResarch.Desciption = medicalResarchInput.MedicalResarchDTO.Desciption;
                            medicalResarch.StartDate = medicalResarchInput.MedicalResarchDTO.StartDate;
                            medicalResarch.EndDate = medicalResarchInput.MedicalResarchDTO.EndDate;
                            medicalResarch.MedicalResarchTermDef = medicalResarchInput.MedicalResarchTermDef;
                            medicalResarch.PatientCount = medicalResarchInput.MedicalResarchDTO.PatientCount;
                            medicalResarch.Name = medicalResarchInput.MedicalResarchDTO.Name;
                         
                            foreach (MedicalResarchDoctor item in medicalResarch.MedicalResarchDoctors.Select(""))
                            {
                                ((ITTObject)item).Delete();
                            }
                            foreach (MedicalResarchProcedur item in medicalResarch.MedicalResarchProcedurs.Select(""))
                            {
                                ((ITTObject)item).Delete();
                            }

                            foreach (MedicalResarchDoctor item in medicalResarchInput.MedicalResarchDoctorList)
                            {

                                ResUser resuser = context.GetObject<ResUser>(item.ObjectID);
                                MedicalResarchDoctor medicalResarchDoctor = new MedicalResarchDoctor(context);
                                medicalResarchDoctor.ResUser = resuser;
                                medicalResarchDoctor.MedicalResarch = medicalResarch;
                            }

                            foreach (MedicalResarchProcedur item in medicalResarchInput.MedicalResarchProcedurList)
                            {
                                ProcedureDefinition procedureDefinition = context.GetObject<ProcedureDefinition>(item.ObjectID);
                                MedicalResarchProcedur medicalResarchProcedur = new MedicalResarchProcedur(context);
                                medicalResarchProcedur.ProcedureDefinition = procedureDefinition;
                                medicalResarchProcedur.MedicalResarch = medicalResarch;
                            }
                            medicalResarch.CurrentStateDefID = MedicalResarch.States.New;
                            context.Save();
                            returnMessage = "Araþtýrma Güncellenmiþtir.";
                        }
                        catch
                        {
                            returnMessage = "Hatalý iþlem";
                        }
                    }
                }
                return returnMessage;
            }
        }

        [HttpPost]
        public string complatedMedicalResarch(MedicalResarchViewModel medicalResarchInput)
        {
            using (var context = new TTObjectContext(false))
            {
                string returnMessage = "";
                BindingList<MedicalResarch.MedicalResarhCalcBudget_Class> getTermButget = MedicalResarch.MedicalResarhCalcBudget(medicalResarchInput.MedicalResarchTermDef.ObjectID);
                if (getTermButget.Count > 0)
                {
                    if (Convert.ToDouble(medicalResarchInput.MedicalResarchDTO.BudgetTotalPrice) > Convert.ToDouble(getTermButget[0].Totalspent))
                    {
                        returnMessage = "Araþtýrma Tutarý Dönem Harcama Limitini Geçmiþtir. Ýþlem Devam Ettirilemez.";
                    }
                    else
                    {
                        try
                        {
                            MedicalResarch medicalResarch = context.GetObject<MedicalResarch>(medicalResarchInput.MedicalResarchDTO.ObjectId);
                            medicalResarch.BudgetTotalPrice = medicalResarchInput.MedicalResarchDTO.BudgetTotalPrice;
                            medicalResarch.Code = medicalResarchInput.MedicalResarchDTO.Code;
                            medicalResarch.Desciption = medicalResarchInput.MedicalResarchDTO.Desciption;
                            medicalResarch.StartDate = medicalResarchInput.MedicalResarchDTO.StartDate;
                            medicalResarch.EndDate = medicalResarchInput.MedicalResarchDTO.EndDate;
                            medicalResarch.MedicalResarchTermDef = medicalResarchInput.MedicalResarchTermDef;
                            medicalResarch.PatientCount = medicalResarchInput.MedicalResarchDTO.PatientCount;
                            medicalResarch.Name = medicalResarchInput.MedicalResarchDTO.Name;

                            foreach (MedicalResarchDoctor item in medicalResarch.MedicalResarchDoctors.Select(""))
                            {
                                ((ITTObject)item).Delete();
                            }
                            foreach (MedicalResarchProcedur item in medicalResarch.MedicalResarchProcedurs.Select(""))
                            {
                                ((ITTObject)item).Delete();
                            }

                            foreach (MedicalResarchDoctor item in medicalResarchInput.MedicalResarchDoctorList)
                            {

                                ResUser resuser = context.GetObject<ResUser>(item.ObjectID);
                                MedicalResarchDoctor medicalResarchDoctor = new MedicalResarchDoctor(context);
                                medicalResarchDoctor.ResUser = resuser;
                                medicalResarchDoctor.MedicalResarch = medicalResarch;
                            }

                            foreach (MedicalResarchProcedur item in medicalResarchInput.MedicalResarchProcedurList)
                            {
                                ProcedureDefinition procedureDefinition = context.GetObject<ProcedureDefinition>(item.ObjectID);
                                MedicalResarchProcedur medicalResarchProcedur = new MedicalResarchProcedur(context);
                                medicalResarchProcedur.ProcedureDefinition = procedureDefinition;
                                medicalResarchProcedur.MedicalResarch = medicalResarch;
                            }
                            medicalResarch.CurrentStateDefID = MedicalResarch.States.Complete;
                            context.Save();
                            returnMessage = "Araþtýrma Tamamlanmýþtýr.";
                        }
                        catch
                        {
                            returnMessage = "Hatalý iþlem";
                        }
                    }
                }
                return returnMessage;
            }
        }

    }
}

namespace Core.Models
{
    public class InputDTO
    {
        public string MedicalResarchObjectID { get; set; }
    }
    public class MedicalResarchDTO
    {
        public Guid ObjectId { get; set; }
        public int? Code { get; set; }
        public int? PatientCount { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Desciption { get; set; }
        public decimal? BudgetTotalPrice { get; set; }
        public string Name { get; set; }
    }

    public class ProcedureDefinitionDTO
    {
        public string Name { get; set; }
        public Guid ObjectId { get; set; }
        public string Code { get; set; }
    }

    public class MedicalResarchViewModel
    {
        public MedicalResarchDTO MedicalResarchDTO { get; set; }
        public MedicalResarchTermDef MedicalResarchTermDef { get; set; }
        public List<MedicalResarchDoctor> MedicalResarchDoctorList { get; set; }
        public List<MedicalResarchProcedur> MedicalResarchProcedurList { get; set; }
        public List<ProcedureDefinitionDTO> ProcedureDefList { get; set; }
        public List<ResUser> DoctorResUserList { get; set; }

        public bool formIsReadOnly { get; set; }
        public string formName { get; set; }
    }
}


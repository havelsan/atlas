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
using System.ComponentModel;

namespace Core.Controllers
{
    [Route("api/[controller]/[action]/{id?}")]
    [HvlResult]
    public partial class MedicalResarchTermDefServiceController : Controller
    {
        [HttpGet]
        public List<MedicalResarchTermDefDTO> getMedicalResarchTermList()
        {
            using (var context = AtlasContextFactory.Instance.CreateContext())
            {
                List<MedicalResarchTermDefDTO> MedicalResarchTermDefs = null;
                MedicalResarchTermDefs = context.MedicalResarchTermDef.Select(x => new MedicalResarchTermDefDTO() { 
                    TermBudgetPrice = x.TermBudgetPrice,
                    Desciption = x.Desciption,
                    EndDate = x.EndDate,
                    ObjectId = x.ObjectId,
                    StartDate = x.StartDate,
                    TermCode = x.TermCode,
                    TermName = x.TermName
                    //Status þaun çekilemiyor.

                }).ToList();
                return MedicalResarchTermDefs;
            }
        }

        [HttpPost]
        public string saveMedicalResarchTerm(MedicalResarchTermDefDTO termDef)
        {
            using (var context = new TTObjectContext(false))
            {
                string returnMessage = "";
                try
                {
                    MedicalResarchTermDef medicalResarchTerm = null;
                    if (termDef.ObjectId == Guid.Empty)
                    {
                        medicalResarchTerm = new MedicalResarchTermDef(context);
                        returnMessage = "Araþtýrma Dönemi Kaydý Açýlmýþtýr.";
                    }
                    else
                    {
                        medicalResarchTerm = context.GetObject<MedicalResarchTermDef>(termDef.ObjectId);
                        returnMessage = "Araþtýrma Dönemi Güncellenmiþtir.";
                    }
                    medicalResarchTerm.TermBudgetPrice = termDef.TermBudgetPrice;
                    medicalResarchTerm.Desciption = termDef.Desciption;
                    medicalResarchTerm.StartDate = termDef.StartDate;
                    medicalResarchTerm.EndDate = termDef.EndDate;
                    medicalResarchTerm.TermCode = termDef.TermCode.ToString();
                    medicalResarchTerm.TermName = termDef.TermName;
                    medicalResarchTerm.IsActive = termDef.Status;

                    if(termDef.Status == false)
                    {
                        string medicalReaschCode = "";
                        BindingList<MedicalResarch.MedicalResarchRQ_Class> medicalResarchUnComplated = MedicalResarch.MedicalResarchRQ(context, " WHERE  CURRENTSTATEDEFID = '" + MedicalResarch.States.New + "'");
                        returnMessage = "Tamamlanmamýþ Araþtýrmalar Mevcuttur. Önce Araþtýrmalarý Tamamlamanýz Gerekiyor. Araþtýrma Kodlarý : ";
                        foreach (MedicalResarch.MedicalResarchRQ_Class item in medicalResarchUnComplated)
                        {
                            medicalReaschCode += item.Code + ","; 
                        }
                        returnMessage += medicalReaschCode;
                        return returnMessage;
                    }

                    context.Save();
                    return returnMessage;
                }
                catch
                {
                    return "Hatalý iþlem";
                }

            }
        }
    }
}

namespace Core.Models
{
    public class MedicalResarchTermDefDTO
    {
        public Guid ObjectId { get; set; }
        public string TermName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string TermCode { get; set; }
        public decimal? TermBudgetPrice { get; set; }
        public string Desciption { get; set; }
        public bool Status { get; set; }
    }

    public class MedicalResarchTermDefViewModel
    {
        public Guid objectID { get; set; }
        public int termCode { get; set; }
        public string termName { get; set; }
        public bool status { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public double termButget { get; set; }
        public string desciption { get; set; }
        public bool isNew { get; set; }
    }

}


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
                    //Status �aun �ekilemiyor.

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
                        returnMessage = "Ara�t�rma D�nemi Kayd� A��lm��t�r.";
                    }
                    else
                    {
                        medicalResarchTerm = context.GetObject<MedicalResarchTermDef>(termDef.ObjectId);
                        returnMessage = "Ara�t�rma D�nemi G�ncellenmi�tir.";
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
                        returnMessage = "Tamamlanmam�� Ara�t�rmalar Mevcuttur. �nce Ara�t�rmalar� Tamamlaman�z Gerekiyor. Ara�t�rma Kodlar� : ";
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
                    return "Hatal� i�lem";
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


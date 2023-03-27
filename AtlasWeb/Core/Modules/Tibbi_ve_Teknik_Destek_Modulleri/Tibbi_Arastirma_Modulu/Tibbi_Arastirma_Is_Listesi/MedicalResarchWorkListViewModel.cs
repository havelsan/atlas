using System;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using Infrastructure.Filters;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Core.Security;
using System.Linq;
using static TTObjectClasses.TreatmentDischarge;
using System.ComponentModel;
using TTUtils;
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

namespace Core.Controllers
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public class MedicalResarchWorkListServiceController
    {

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]

        public LoadResult GetMedicalResarchDefList([FromBody] DataSourceLoadOptions loadOptions, [FromQuery] bool medicalResarchTermStatus)
        {
            LoadResult result = null;
            using (var objectContext = new TTObjectContext(false))
            {
                TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDICALRESARCHTERMDEF"].QueryDefs["GetMedicalResarchTermDefList"];

                var paramList = new Dictionary<string, object>();
                var injection = " ISACTIVE = 1";
                if (medicalResarchTermStatus == false)
                {
                    injection = string.Empty;
                }
                result = DevexpressLoader.Load(objectContext, queryDef, loadOptions, paramList, injection);
            }
            return result;
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]

        public LoadResult GetMedicalResarchList([FromBody] DataSourceLoadOptions loadOptions)
        {
            LoadResult result = null;
            using (var objectContext = new TTObjectContext(false))
            {
                TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDICALRESARCH"].QueryDefs["MedicalResarchRQ"];

                var paramList = new Dictionary<string, object>();
                var injection = string.Empty;
                result = DevexpressLoader.Load(objectContext, queryDef, loadOptions, paramList, injection);
            }
            return result;
        }


        [HttpPost]
        public List<MedicalResarchActionListDTO> getMedicalResarch(ResarchWorkList_Input termDef)
        {
            using (var context = new TTObjectContext(false))
            {
                if (termDef.MedicalResarchTermDef != null)
                {
                    string injectionSQL = "WHERE MEDICALRESARCHTERMDEF.OBJECTID =" + TTConnectionManager.ConnectionManager.GuidToString(termDef.MedicalResarchTermDef.ObjectID);
                    List<MedicalResarchActionListDTO> medicalResarchActionListDTOs = new List<MedicalResarchActionListDTO>();

                    if (String.IsNullOrEmpty(termDef.MedicalResarchCode) == false)
                        injectionSQL += " AND CODE = '" + termDef.MedicalResarchCode + "'";

                    BindingList<MedicalResarch.MedicalResarchRQ_Class> medicalResarches = MedicalResarch.MedicalResarchRQ(injectionSQL);
                    foreach (MedicalResarch.MedicalResarchRQ_Class item in medicalResarches)
                    {
                        MedicalResarchActionListDTO medicalResarch = new MedicalResarchActionListDTO();
                        medicalResarch.BudgetTotalPrice = Convert.ToDouble(item.BudgetTotalPrice);
                        medicalResarch.Code = item.Code.ToString();
                        medicalResarch.Name = item.Name;
                        medicalResarch.PatientCount = item.PatientCount.Value;
                        medicalResarch.Status = item.DisplayText;
                        medicalResarch.TermName = item.TermName;
                        medicalResarch.ObjectID = item.ObjectID.Value;
                        medicalResarchActionListDTOs.Add(medicalResarch);
                    }
                    return medicalResarchActionListDTOs;
                }
                else
                {
                    return null;
                }
            }
        }

        internal static IEnumerable<string> GetParentFolders(TTModuleDef moduleDef)
        {
            yield return TTUtils.Globals.GetModuleName(moduleDef.Name);
            Guid? folderDefId = moduleDef.FolderDefID;
            while (folderDefId != null)
            {
                TTFolderDef folderDef = null;
                if (TTObjectDefManager.Instance.FolderDefs.ContainsKey(folderDefId))
                {
                    folderDef = TTObjectDefManager.Instance.FolderDefs[folderDefId];
                    yield return TTUtils.Globals.GetModuleName(folderDef.CodeName);
                    folderDefId = folderDef.ParentFolderDefID;
                }

                if (!folderDefId.HasValue)
                    yield break;
            }
        }

        [HttpGet]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public DynamicComponentInfoDVO GetDynamicComponentInfo([FromQuery] string ObjectId)
        {
            DynamicComponentInfoDVO dynamicComponentInfo = new DynamicComponentInfoDVO();
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                TTObject obj = objectContext.GetObject(new Guid(ObjectId), typeof(MedicalResarch));
                var subFolders = GetParentFolders(obj.ObjectDef.ModuleDef);
                var folderPath = string.Join("/", subFolders.Reverse());
                var moduleName = obj.ObjectDef.ModuleDef.Name.GetTsModuleName();
                var modulePath = string.Format("/Modules/{0}/{1}", folderPath, moduleName);
                dynamicComponentInfo.ComponentName = "MedicalResarchComponent";
                dynamicComponentInfo.ModuleName = moduleName;
                dynamicComponentInfo.ModulePath = modulePath;
                dynamicComponentInfo.objectID = ObjectId;
                objectContext.FullPartialllyLoadedObjects();
                return dynamicComponentInfo;
            }
        }


        [HttpPost]
        public List<MedicalResarchActionPatientWorkListDTO> getMedicalResarchForPatientWorkList(ResarchPatientWorkList_Input inputDTO)
        {
            using (var context = new TTObjectContext(false))
            {
               
                if (inputDTO.MedicalResarchTermDef != null)
                {
                    string injectionSQL = "WHERE MEDICALRESARCH.MEDICALRESARCHTERMDEF.OBJECTID =" + TTConnectionManager.ConnectionManager.GuidToString(inputDTO.MedicalResarchTermDef.ObjectID);
                    List<MedicalResarchActionPatientWorkListDTO> medicalResarchActionPatientWorkListDTOs = new List<MedicalResarchActionPatientWorkListDTO>();

                    if (String.IsNullOrEmpty(inputDTO.MedicalResarchCode) == false)
                        injectionSQL += " AND MEDICALRESARCH.CODE = '" + inputDTO.MedicalResarchCode + "'";

                    if(inputDTO.SelectedPatient != null)
                    {
                        injectionSQL += " AND EPISODE.PATIENT.OBJECTID = '" + inputDTO.SelectedPatient.ObjectID + "'";
                    }


                   
                    BindingList<MedicalResarchPatientEx.MedicalResarchPatientExRQ_Class> medicalResarchPatientes = MedicalResarchPatientEx.MedicalResarchPatientExRQ(injectionSQL);
                    foreach (MedicalResarchPatientEx.MedicalResarchPatientExRQ_Class item in medicalResarchPatientes)
                    {
                        double price = 0;
                        MedicalResarchActionPatientWorkListDTO medicalResarchPatient = new MedicalResarchActionPatientWorkListDTO();
                        medicalResarchPatient.MedicalResarchCode = item.Donemkodu.ToString();
                        medicalResarchPatient.TermName = item.Donem;
                        medicalResarchPatient.MedicalResarchName = item.Donemadi;
                        medicalResarchPatient.ObjectID = item.ObjectID.Value;
                        medicalResarchPatient.PatientNameSurname = item.Hastaadi + " " + item.Hastasoyadi;
                        medicalResarchPatient.PatientProtocolNo = item.Kabulno.ToString();
                        medicalResarchPatient.PatientStatus = item.Durumu;

                        MedicalResarchPatientEx patientEx = context.GetObject<MedicalResarchPatientEx>(item.ObjectID.Value);
                        foreach (var expro in patientEx.MedicalResarchPatientExProcedurs.Select(string.Empty))
                        {
                            foreach (var procedurePrice in expro.ProcedureObject.ProcedurePrice)
                            {
                                if (procedurePrice.PricingDetail.PricingList.ObjectID == new Guid("47466669-d190-4d13-af74-21a23d8a5ddb"))
                                {
                                    if(Common.RecTime() < procedurePrice.PricingDetail.DateEnd )
                                    price += Convert.ToDouble(procedurePrice.PricingDetail.Price);
                                }
                            }
                        }
                        medicalResarchPatient.PatientBudgetPrice = price.ToString();

                        medicalResarchActionPatientWorkListDTOs.Add(medicalResarchPatient);
                    }
                    return medicalResarchActionPatientWorkListDTOs;
                }
                else
                {
                    return null;
                }
            }
        }


        [HttpGet]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public DynamicComponentInfoDVO GetDynamicComponentPatientInfo([FromQuery] string ObjectId)
        {
            DynamicComponentInfoDVO dynamicComponentInfo = new DynamicComponentInfoDVO();
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                TTObject obj = objectContext.GetObject(new Guid(ObjectId), typeof(MedicalResarchPatientEx));
                var subFolders = GetParentFolders(obj.ObjectDef.ModuleDef);
                var folderPath = string.Join("/", subFolders.Reverse());
                var moduleName = obj.ObjectDef.ModuleDef.Name.GetTsModuleName();
                var modulePath = string.Format("/Modules/{0}/{1}", folderPath, moduleName);
                dynamicComponentInfo.ComponentName = "MedicalResarchPatientComponent";
                dynamicComponentInfo.ModuleName = moduleName;
                dynamicComponentInfo.ModulePath = modulePath;
                dynamicComponentInfo.objectID = ObjectId;
                objectContext.FullPartialllyLoadedObjects();
                return dynamicComponentInfo;
            }
        }


    }
}
namespace Core.Models
{
    public class MedicalResarchWorkListViewModel
    {

    }
    public class ResarchWorkList_Input
    {
        public string MedicalResarchCode { get; set; }
        public MedicalResarchTermDef MedicalResarchTermDef { get; set; }
    }

    public class MedicalResarchActionListDTO
    {
        public Guid ObjectID { get; set; }
        public string Code { get; set; }
        public double BudgetTotalPrice { get; set; }
        public string Name { get; set; }
        public int PatientCount { get; set; }
        public string TermName { get; set; }
        public string Status { get; set; }
    }

    public class ResarchPatientWorkList_Input
    {
        public string MedicalResarchCode { get; set; }
        public MedicalResarchTermDef MedicalResarchTermDef { get; set; }
        public Patient SelectedPatient { get; set; }
    }

    public class MedicalResarchActionPatientWorkListDTO
    {
        public Guid ObjectID { get; set; }
        public string TermName { get; set; }
        public string MedicalResarchCode { get; set; }
        public string MedicalResarchName { get; set; }
        public string PatientNameSurname { get; set; }
        public string PatientProtocolNo { get; set; }
        public string PatientBudgetPrice { get; set; }
        public string PatientStatus { get; set; }
    }

}

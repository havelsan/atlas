using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

using Core.Models;
using System.ComponentModel;
using TTObjectClasses;
using Infrastructure.Filters;
using TTInstanceManagement;
using Core.Modules.Tibbi_Surec.Tetkik_Istem_Modulu;
using System.Net;
using Oracle.ManagedDataAccess.Client;
using TTUtils;
using System.Net.Http;
using System.IO;
using System.Text;
using System.Net.Http.Headers;

namespace Core.Modules.Tibbi_Surec.Tetkik_Istem_Modulu
{
    public class RequestedProceduresFormViewModel
    {
        public TTObjectClasses.SubActionProcedure.GetRequestedProceduresBySubEpisode_Class[] MyRequestedProcedures
        {
            get;
            set;
        }
    }

    public class InputModelForDoctorList
    {
        public TTObjectClasses.EpisodeAction EpisodeAction { get; set; }
        public Guid SelectedObjectID { get; set; }
        public string filter { get; set; }
    }

    public class DoctorModel
    {
        public string Name { get; set; }
        public Guid? ObjectID { get; set; }
        public UserTitleEnum? Title { get; set; }
    }

    public class PackageModel
    {
        public string Name { get; set; }
        public Guid? ObjectID { get; set; }
    }

    public class AdditionalAppModel
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public Guid? ObjectID { get; set; }
        public bool? DailyMedulaProvisionNecessity { get; set; }
    }

    public class ClinicResultModel
    {
        public List<ResClinic> ClinicList { get; set; }
        public ResClinic DefaultClinic { get; set; }
    }

}

namespace Core.Controllers
{
    [Route("api/[controller]/[action]/{id?}")]
    [HvlResult]
    public class RequestedProceduresServiceController : Controller
    {
        [HttpPost]
        public List<DoctorModel> FillDataSources(InputModelForDoctorList input)
        {
            List<ResUser.DoctorListNQL_Class> DoctorListFromQuery = ResUser.DoctorListNQL(input.filter).ToList();

            List<DoctorModel> DoctorList = new List<DoctorModel>();
            //(o.Title == null ? "" : (Common.GetDescriptionOfDataTypeEnum(o.Title.Value) + " ")) + o.Name

            foreach (ResUser.DoctorListNQL_Class doctor in DoctorListFromQuery)
            {
                DoctorModel doctorModel = new DoctorModel();
                if (doctor.Title != null)
                {
                    doctorModel.Title = doctor.Title;
                    doctorModel.Name = Common.GetDescriptionOfDataTypeEnum(doctor.Title.Value) + " " + doctor.Name;
                }

                else
                    doctorModel.Name = doctor.Name;
                doctorModel.ObjectID = doctor.ObjectID;

                DoctorList.Add(doctorModel);
            }

            return DoctorList;
        }

        [HttpPost]
        public List<PackageModel> FillDataSourceForPackage(InputModelForQueries input)
        {
            List<PackageTemplateDefinition.GetPackageTemplate_Class> PackageListFromQuery = PackageTemplateDefinition.GetPackageTemplate(Common.CurrentResource.ObjectID).ToList();

            List<PackageModel> PackageList = new List<PackageModel>();
            //(o.Title == null ? "" : (Common.GetDescriptionOfDataTypeEnum(o.Title.Value) + " ")) + o.Name

            foreach (PackageTemplateDefinition.GetPackageTemplate_Class pack in PackageListFromQuery)
            {
                PackageModel packModel = new PackageModel();

                packModel.Name = pack.Name;
                packModel.ObjectID = pack.ObjectID;
                PackageList.Add(packModel);
            }

            return PackageList;
        }

        [HttpPost]
        public List<AdditionalAppModel> FillDataSourceForAdditionalApplication()
        {
            List<SurgeryDefinition.GetAdditionalApplication_Class> HizmetFromQuery = SurgeryDefinition.GetAdditionalApplication().ToList();

            List<AdditionalAppModel> HizmetList = new List<AdditionalAppModel>();
            //(o.Title == null ? "" : (Common.GetDescriptionOfDataTypeEnum(o.Title.Value) + " ")) + o.Name

            foreach (SurgeryDefinition.GetAdditionalApplication_Class app in HizmetFromQuery)
            {
                AdditionalAppModel appModel = new AdditionalAppModel();

                appModel.ObjectID = app.ObjectID;
                appModel.Name = app.Name;
                appModel.Code = app.Code;
                appModel.DailyMedulaProvisionNecessity = app.DailyMedulaProvisionNecessity;

                appModel.Name = appModel.Code + " - " + appModel.Name;

                HizmetList.Add(appModel);
            }

            return HizmetList;
        }

        [HttpPost]
        public ClinicResultModel FillClinicList(EpisodeAction input)
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                ClinicResultModel result = new ClinicResultModel();
                EpisodeAction ea = objectContext.GetObject<EpisodeAction>(input.ObjectID) as EpisodeAction;

                List<ResClinic> ClinicList = ResClinic.GetClinicForDailyOperation(objectContext).OrderBy(T => T.Name).ToList();
                ResClinic clinic = ClinicList.Where(x => x.Department == ((ResPoliclinic)ea.MasterResource).Department && x.TedaviTuru.tedaviTuruKodu.Equals("G")).FirstOrDefault();
                result.ClinicList = ClinicList;
                result.DefaultClinic = clinic;

                return result;

            }
        }

        [HttpGet]
        public Guid GetMasterAction(string MasterActionID)
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                EpisodeAction ea = objectContext.GetObject<EpisodeAction>(new Guid(MasterActionID));
                objectContext.FullPartialllyLoadedObjects();
                return ea.MasterResource.ObjectID;
            }
        }

        //[HttpPost]
        //public List<ResClinic> FillClinicList()
        //{
        //    //  List<ResClinic> ClinicList = new List <ResClinic>();
        //    // return ClinicList;
        //    using (TTObjectContext objectContext = new TTObjectContext(false))
        //    {

        //        List<ResClinic> ClinicList = ResClinic.GetClinicForDailyOperation(objectContext).OrderBy(T => T.Name).ToList();
        //        return ClinicList;

        //    }
        //}
        public void DeleteSelectedPackage(string PackageId)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                string objectDefId = "81e35a8d-1635-4310-9875-c6c2def8fe63";
                PackageTemplateDefinition package = objectContext.GetObject(new Guid(PackageId), new Guid(objectDefId)) as PackageTemplateDefinition;
                ((ITTObject)package).Delete();
                objectContext.Save();
            }
        }

        
        public async System.Threading.Tasks.Task<List<string>> AnalyzeAI(ObjectIDForAI carrier)
        {
            List<string> analyzeList = new List<string>();
            var connectionAddress = TTObjectClasses.SystemParameter.GetParameterValue("YAPAYZEKAPACSERISIMADRESI", "https://X.X.X.X:35006/");

            var AIProcedureTypes = TTObjectClasses.SystemParameter.GetParameterValue("YAPAYZEKACALISACAKTESTTURLERI", "");
            var AIProcedureTypeList = AIProcedureTypes.Split(',').ToList();

            using (var objectContext = new TTObjectContext(true))
            {
                var radiologyTestObj = objectContext.GetObject<RadiologyTest>(carrier.objectId);
                ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

                string conStr = "USER ID=ATLAS;PASSWORD=XXXXXXX;DATA SOURCE='(DESCRIPTION=(ADDRESS=(PROTOCOL=tcp) (HOST=X.X.X.X)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=pdhrac)))'";
                Dictionary<string, string> errorDict = new Dictionary<string, string>();
                string qry = "select * from PACSULUS.V_WADO @hbys where ACCESSIONNUMBER='" + radiologyTestObj.AccessionNo + "'";
                using (OracleConnection con = new OracleConnection(conStr))
                {

                    OracleCommand cmd = new OracleCommand(qry, con);
                    con.Open();
                    int i = 0;
                    using (OracleDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                var StudyUid = rdr.ConvertValue<string>("STUDYUID");
                                var SeriesUid = rdr.ConvertValue<string>("SERIESUID");
                                var ImageUid = rdr.ConvertValue<string>("IMAGEUID");
                                var ImageType = rdr.ConvertValue<string>("IMAGETYPE");
                                if (AIProcedureTypeList.Contains(ImageType))
                                {
                                    HttpClient httpClient = new HttpClient();
                                    httpClient.DefaultRequestHeaders.Accept.Clear();
                                    httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/dicom"));

                                    var response = httpClient.GetAsync(connectionAddress + "?requestType=WADO&contentType=jpeg&studyUID=" + StudyUid + "&seriesUID=" + SeriesUid + "&objectUID=" + ImageUid).GetAwaiter().GetResult();
                                    var imageName = "image" + Common.RecTime().ToString("-dd-MM-yyyy-HH-mm-ss-fff-") + radiologyTestObj.AccessionNo + ".jpeg";
                                    using (Stream output = System.IO.File.OpenWrite(imageName))
                                    using (Stream input = await response.Content.ReadAsStreamAsync())
                                    {
                                        input.CopyTo(output);
                                    }

                                    HttpClient httpClient2 = new HttpClient();
                                    httpClient2.DefaultRequestHeaders.Accept.Clear();
                                    httpClient2.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                                    ImageContainer container = new ImageContainer();
                                    var readedFile = System.IO.File.ReadAllBytes(imageName);

                                    container.Base64Image = "data:image/jpeg;base64," + Convert.ToBase64String(readedFile);

                                    var currentObject = Newtonsoft.Json.JsonConvert.SerializeObject(container);

                                    HttpContent httpContent = new StringContent(currentObject, Encoding.UTF8, "application/json");
                                    var responseFromAI = httpClient2.PostAsync("http://195.214.160.86:7000/api/Image", httpContent).GetAwaiter().GetResult();
                                    var responseStringFromAI = responseFromAI.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                                    responseStringFromAI = responseStringFromAI.Replace("\\n", "<br>");
                                    if (!analyzeList.Contains(responseStringFromAI))
                                        analyzeList.Add(responseStringFromAI);
                                    System.IO.File.Delete(imageName);
                                }

                            }
                        }
                    }
                }

            }

            return analyzeList;
        }

        [HttpPost]
        public List<string> GetAIComments(ObjectIDForAI carrier)
        {
            var list = AnalyzeAI(carrier).Result;

            return list;
        }
    }

}

namespace Core.Models
{
    public class ImageContainer
    {
        public string Base64Image { get; set; }
    }

    public class ObjectIDForAI
    {
        public Guid objectId { get; set; }
    }
}
using Core.Models;
using Core.Models.DataSourceOptionsParser;
using Core.Security;
using Core.Services;
using Hangfire;
using Infrastructure.Filters;
using Infrastructure.Helpers;
using Infrastructure.Models;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using TTDefinitionManagement;
using TTInstanceManagement;
using TTObjectClasses;

namespace Core.Controllers
{

    [Route("api/[controller]/[action]/{id?}")]
    [HvlResult]
    public class TestController : Controller
    {
        private readonly IBackgroundJobClient _backgroundJobs;
        private readonly ILogger<TestController> _logger;
        private readonly ProcedureService _procedureService;
        private readonly ResourceService _resourceService;
        private readonly EpisodeService _episodeService;


        public TestController(IBackgroundJobClient backgroundJobs
            , ILogger<TestController> logger
            , ProcedureService procedureService
            , ResourceService resourceService
            , EpisodeService episodeService)
        {
            _logger = logger;
            _procedureService = procedureService;
            _resourceService = resourceService;
            _episodeService = episodeService;
            _backgroundJobs = backgroundJobs;
        }

        public class EchoInput
        {
            public string Message { get; set; }
        }

        Guid testRole = Guid.Empty;

        [HttpPost]
        [AtlasRequiredRoles("Everyone", "Tabip")]
        public string Echo([FromBody]EchoInput input)
        {


            return input.Message;
        }

        public class TestPatientViewModel : BaseViewModel
        {
            public Patient _Patient { get; set; }
            public List<Episode> Episodes { get; set; }
        }

        [HttpGet]
        [AllowAnonymous]
        public object ExceptionTest()
        {
            string a = null;
            return a.ToString();
        }

        public static void BackgroundJobAction()
        {
            foreach (var index in Enumerable.Range(1, 10))
            {
                Task.Delay(2000);

                System.Diagnostics.Trace.WriteLine($"{index * 10} completed");

            }
        }

        public class PersonDto
        {
            public Guid ObjectId { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
        }

        [HttpGet]
        [AllowAnonymous]
        public object GetPersonList()
        {
            using (var context = AtlasContextFactory.Instance.CreateContext())
            {
                var query = from p in context.Person
                            select new PersonDto
                            {
                                ObjectId = p.ObjectId,
                                Name = p.Name,
                                Surname = p.Surname
                            };

                var result = query.Take(10).ToList();

                return Ok(result);
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public void BatchUpdateSample()
        {
            using (var context = AtlasContextFactory.Instance.CreateContext())
            {
                //var targetDate = DateTime.Now.Date - TimeSpan.FromDays(10);
                //var rowsAffected = context.Person
                //    .Where(p => p.BirthDate >= targetDate)
                //    //.UpdateFromQuery(x => new Person() { HomePhone = "999 999 99 99" });
                //System.Diagnostics.Trace.WriteLine(rowsAffected);
            }
        }


        [HttpGet]
        [AllowAnonymous]
        public void BackgroundJobTest()
        {

            // Hemen çalışrtırmak için 
            BackgroundJob.Enqueue(() => BackgroundJobAction());

            // 2 sn sonra çalıştırmak için
            BackgroundJob.Schedule(() => System.Diagnostics.Trace.WriteLine("Fire-and-forget!"), TimeSpan.FromSeconds(2));
        }


        [HttpGet]
        public TestPatientViewModel LoadPatient([FromQuery] Guid objectID)
        {
            var viewModel = new TestPatientViewModel();
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._Patient = objectContext.GetObject<Patient>(objectID);
                //viewModel._Patient = new Patient(objectContext);
                // viewModel._Patient.Name = "UFUK2";
                // viewModel._Patient.FatherName = "BABA";
                viewModel.Episodes = viewModel._Patient.Episodes.ToList();
                objectContext.FullPartialllyLoadedObjects();
            }

            return viewModel;
        }

        public class EpisodeInfoDto
        {
            public Guid ObjectID { get; set; }
            public DateTime? OpeningDate { get; set; }
            public string MainSpeciality { get; set; }
            public long? ID { get; set; }
            public DateTime? ClosingDate { get; set; }
        }

        public class TestComponentViewModel
        {
            public Patient _Patient { get; set; }
            public IEnumerable<EpisodeInfoDto> Episodes { get; set; }
        }

        [HttpGet]
        public TestComponentViewModel GetPatient([FromQuery] Guid objectID)
        {
            var viewModel = new TestComponentViewModel();
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._Patient = objectContext.GetObject<Patient>(objectID);
                var query = from e in viewModel._Patient.Episodes.ToList()
                            select new EpisodeInfoDto
                            {
                                ObjectID = e.ObjectID,
                                OpeningDate = e.OpeningDate,
                                ClosingDate = e.ClosingDate,
                                ID = e.ID.Value,
                                MainSpeciality = e.MainSpeciality.Name
                            };

                viewModel.Episodes = query.ToArray();
                objectContext.FullPartialllyLoadedObjects();
            }

            return viewModel;
        }


        public class EpisodeList
        {
            public IEnumerable<EpisodeInfoDto> Episodes { get; set; }
        }


        public EpisodeList GetEpisodeList([FromQuery] Guid patientID)
        {
            var viewModel = new EpisodeList();
            using (var objectContext = new TTObjectContext(false))
            {
                var patient = objectContext.GetObject<Patient>(patientID);
                if (patient == null)
                    return viewModel;

                var query = from e in patient.Episodes.ToList()
                            orderby e.OpeningDate descending
                            select new EpisodeInfoDto
                            {
                                ObjectID = e.ObjectID,
                                OpeningDate = e.OpeningDate,
                                ClosingDate = e.ClosingDate,
                                ID = e.ID.Value,
                                MainSpeciality = e.MainSpeciality?.Name ?? e.AdmissionResource
                            };

                viewModel.Episodes = query.ToArray();
            }

            return viewModel;
        }

        [HttpGet]
        public ProcedureList GetProcedureList([FromQuery]string procedureCode)
        {
            var procedureList = _procedureService.GetProcedureList(procedureCode);
            return procedureList;
        }

        [HttpGet]
        public DoctorList GetDoctorList()
        {
            var doctorList = _resourceService.GetDoctorList();
            return doctorList;
        }

        [HttpGet]
        public SpecialityList GetSpecialityList()
        {
            var specialityList = _resourceService.GetSpecialityList();
            return specialityList;
        }

        [HttpPost]
        public ProcedureList GetProcedureListForLookup([FromBody]DataSourceParams dataSourceParams)
        {
            if (dataSourceParams != null && string.IsNullOrWhiteSpace(dataSourceParams.SearchValue))
            {
                var emptyProcedureList = new ProcedureList();
                emptyProcedureList.Procedures = new List<ProcedureDto>();
                emptyProcedureList.TotalCount = 0;
                return emptyProcedureList;
            }

            var procedureList = _procedureService.GetProcedureList(dataSourceParams);
            return procedureList;
        }


        [HttpPost]
        public object Query(DataSourceLoadOptions loadOptions)
        {
            LoadResult result = null;

            string definitionName = loadOptions.Params.definitionName;
            string searchText = loadOptions.Params.searchText;

            using (var objectContext = new TTObjectContext(true))
            {
                TTListDef listDef = TTObjectDefManager.Instance.ListDefs[definitionName.Trim()];
                TTList ttList = TTList.NewList(objectContext, listDef, string.Empty);

                result = DevexpressLoader.Load(objectContext, ttList, loadOptions, new Dictionary<string, object>(), searchText);




            }
            return result;
            //if (loadOptions.Filter != null && loadOptions.Filter.Count > 0)
            //{
            //    return result.data;
            //}
            //else
            //{

            //}

        }

        [HttpPost]
        public LoadResult Query2(DataSourceLoadOptions loadOptions)
        {
            LoadResult result = null;

            string definitionName = loadOptions.Params.definitionName;
            string searchText = loadOptions.Params.searchText;

            using (var objectContext = new TTObjectContext(true))
            {
                TTListDef listDef = TTObjectDefManager.Instance.ListDefs[definitionName.Trim()];
                TTList ttList = TTList.NewList(objectContext, listDef, string.Empty);

                result = DevexpressLoader.Load(objectContext, ttList, loadOptions, new Dictionary<string, object>(), searchText);


                //var reportQuery = result.GetData < "" > ();
            }
            return result;
        }

        [HttpPost]
        public LoadResult PagingTest([FromBody] DataSourceLoadOptions loadOptions)
        {
            LoadResult result = null;
            using (var objectContext = new TTObjectContext(true))
            {
                TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CONSULTATION"].QueryDefs["GetOutPatientConsultationForWL"];
                Dictionary<string, object> paramList = new Dictionary<string, object>();
                //paramList.Add("STARTDATE", DateTime.Now.AddMonths(-2));
                //paramList.Add("ENDDATE", DateTime.Now);
                //paramList.Add("MINDATE", DateTime.MinValue);


                TTQueryDef queryDef2 = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].QueryDefs["GetPatientExaminationForWL"];
                Dictionary<string, object> paramList2 = new Dictionary<string, object>();
                //paramList2.Add("STARTDATE", DateTime.Now.AddMonths(-2));
                //paramList2.Add("ENDDATE", DateTime.Now);
                //paramList2.Add("MINDATE", DateTime.MinValue);

                var multipleQuery = new List<MultipleQueryDto>();
                multipleQuery.Add(new MultipleQueryDto() { QueryDef = queryDef, ParamList = paramList, Injection = string.Empty });
                multipleQuery.Add(new MultipleQueryDto() { QueryDef = queryDef2, ParamList = paramList2, Injection = string.Empty });

                result = DevexpressLoader.Load(objectContext, multipleQuery, loadOptions);

            }
            return result;
        }

        [HttpPost]
        public ProcedureList GetProcedureListWithParams([FromBody]DataSourceParams dataSourceParams)
        {
            var procedureList = _procedureService.GetProcedureList(dataSourceParams);
            return procedureList;
        }

        [HttpPost]
        public void WriteEpisodeRequest([FromBody]EpisodeRequestInfo request)
        {
            _episodeService.WriteEpisodeRequest(request);
        }

        [HttpPost]
        public BaseViewModel UpdatePatient(TestPatientViewModel viewModel)
        {
            var retViewModel = new BaseViewModel();

            using (var objectContext = new TTObjectContext(false))
            {
                var patient = objectContext.AddObject(viewModel._Patient) as Patient;
                System.Diagnostics.Trace.WriteLine(patient.Name);
                var digitChar = patient.FatherName.ToCharArray().LastOrDefault();
                var digit = 0;
                if (Char.IsDigit(digitChar))
                {
                    digit = Convert.ToInt32(digitChar);
                }
                patient.FatherName = $"{patient.FatherName}{++digit}";
                var ep1 = objectContext.AddObject(viewModel.Episodes.FirstOrDefault()) as Episode;
                var ep2 = objectContext.AddObject(viewModel.Episodes.LastOrDefault()) as Episode;
                ep1.AdmissionResource = $"{ep1.AdmissionResource}{++digit}";
                var dirtyObjects = objectContext.GetDirtyObjects();
                objectContext.Save();
                ep2.AdmissionResource = $"{ep2.AdmissionResource}{++digit}";
                retViewModel.UpdatedObjects = dirtyObjects;
                return retViewModel;
            }
        }

        public class TestInPatientViewModel
        {
            public InpatientAdmission _InpatientAdmission { get; set; }
        }

        [HttpPost]
        [Route("LoadInPatient/{objectID}")]
        public TestInPatientViewModel LoadInPatient(Guid objectID)
        {
            var viewModel = new TestInPatientViewModel();
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._InpatientAdmission = objectContext.GetObject<InpatientAdmission>(objectID);
                objectContext.FullPartialllyLoadedObjects();
            }

            return viewModel;
        }

        [HttpGet]
        public PatientInfoDto GetPatientInfo([FromQuery]long uniqueRefNo)
        {
            var patientInfo = new PatientInfoDto();
            using (var objectContext = new TTObjectContext(false))
            {
                var patient = objectContext.QueryObjects<Patient>($"UNIQUEREFNO = {uniqueRefNo}").FirstOrDefault();
                if (patient != null)
                {
                    patientInfo.ObjectID = patient.ObjectID;
                    patientInfo.UniqueIdentifier = patient.UniqueRefNo ?? 0;
                    patientInfo.FirstName = patient.Name;
                    patientInfo.LastName = patient.Surname;
                    patientInfo.Gender = patient.Sex?.ADI;
                    patientInfo.DateOfBirth = patient.BirthDate;
                    patientInfo.EMail = patient.EMail;
                    patientInfo.Phone = patient.MobilePhone;
                    patientInfo.Address = patient.PatientAddress?.HomeAddress;
                    patientInfo.BloodGroup = patient.BloodGroupType?.ADI;
                    patientInfo.Age = patient.AgeByYearByMonthByDay();

                }
            }

            return patientInfo;
        }

        [HttpGet]
        public bool IsFormRender()
        {
            //using (var objectContext = new TTObjectContext(false))
            //{
            //    Guid? selectedEpisodeActionObjectID = Request.Headers.GetSelectedEpisodeActionID();
            //    if (selectedEpisodeActionObjectID.HasValue)
            //    {
            //        var episodeAction = objectContext.GetObject<EpisodeAction>(selectedEpisodeActionObjectID.Value);
            //    }
            //}

            return false;
        }

        [HttpGet]
        public bool CheckFormRender()
        {

            _logger.LogError("CheckFormRender throowing Exception");

            var a = 1;
            if (a == 1)
                throw new Exception("aa");
            return true;
        }

        [HttpGet]
        public IDictionary<string, string> GetDictionary()
        {
            var sampleDictionary = new Dictionary<string, string>();
            sampleDictionary.Add("1", "Item1");
            sampleDictionary.Add("2", "Item2");
            sampleDictionary.Add("3", "Item3");
            return sampleDictionary;
        }

        public class DateSerializationSampleDto
        {
            public long ID { get; set; }
            public string Name { get; set; }
            public DateTime BirthDate { get; set; }
        }

        [HttpGet]
        public DateSerializationSampleDto LoadDateSample()
        {
            var viewModel = new DateSerializationSampleDto();
            viewModel.ID = 12098301;
            viewModel.Name = "Test Name";
            viewModel.BirthDate = DateTime.Now;
            return viewModel;
        }

        [HttpPost]
        public void TestObjectDictionary(IDictionary<string, IQueryParam> queryParams)
        {
            var targetDictionary = queryParams.ToDictionary(d => d.Key, d => d.Value.paramValue);
            Console.WriteLine(targetDictionary.Count);
            Console.WriteLine(queryParams.ToString());
        }

        [HttpPost]
        public void TestStatePost(TTObjectStateDef stateDef)
        {
            Console.WriteLine(stateDef);
        }

        public class DateTimeTestInput
        {
            public DateTime dateValue { get; set; }
        }

        [HttpGet]
        public DateTimeTestInput DateTimeTestGet()
        {
            var retval = new DateTimeTestInput()
            { dateValue = new DateTime(2017, 04, 22, 14, 25, 0), };
            return retval;
        }

        [HttpPost]
        public void DateTimeTestPost(DateTimeTestInput input)
        {
            System.Diagnostics.Trace.WriteLine(input.ToString());
        }

        public class UploadViewModel
        {
            public string firstName { get; set; }
            public string lastName { get; set; }
            public IList<FormFile> Attachments { get; set; }
        }

        [HttpGet]
        public MemberOfHealthCommiittee[] GetHCMembers()
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var memberList = objectContext.QueryObjects<MemberOfHealthCommiittee>("HEALTHCOMMITTEE = 'ba79f307-e65f-42e0-addc-a7e200f450b3'");
                objectContext.FullPartialllyLoadedObjects();

                var doctorList = ResUser.OLAP_GetResDoctor();

                return memberList.ToArray();
            }
        }


        [HttpPost]
        [DisableFormValueModelBinding]
        public async Task<ActionResult> Upload()
        {
            var result = await MultipartRequestHelper.BindMultiPartFormDataToViewModel<UploadViewModel>(this);
            var objectResult = result as ObjectResult;
            var viewModel = objectResult.Value as UploadViewModel;
            if (viewModel.Attachments != null && viewModel.Attachments.Count > 0)
            {
                var formFile = viewModel.Attachments.FirstOrDefault();
                var content = StreamHelpers.ToByteArray(formFile.OpenReadStream());
            }
            System.Diagnostics.Trace.WriteLine($"{viewModel.firstName}-{viewModel.lastName}");
            return new EmptyResult();
        }

        [HttpPost]
        public ActionResult UploadWithExtraInfo(string firstName, string lastName, IFormFile attachment)
        {
            // Learn to use the entire functionality of the dxFileUploader widget.
            // http://xxxxxx.com/Documentation/Guide/UI_Widgets/UI_Widgets_-_Deep_Dive/dxFileUploader/

            System.Diagnostics.Trace.WriteLine($"{firstName}-{lastName}-{attachment.Name}");

            return new EmptyResult();
        }

        public class SendBinaryInput
        {
            public int Id { get; set; }
            public string FileName { get; set; }
            public IList<FormFile> Attachments { get; set; }
        }

        [HttpPost]
        [DisableFormValueModelBinding]
        public async Task<IActionResult> SendBinary()
        {

            var result = await MultipartRequestHelper.BindMultiPartFormDataToViewModel<SendBinaryInput>(this);
            var objectResult = result as ObjectResult;
            var viewModel = objectResult.Value as SendBinaryInput;

            if (viewModel != null)
            {
                Console.WriteLine(viewModel.FileName);
                if (viewModel.Attachments != null)
                {
                    var formFile = viewModel.Attachments.FirstOrDefault();
                    var content = StreamHelpers.ToByteArray(formFile.OpenReadStream());
                    Console.WriteLine(content.Length);
                }
            }

            return Ok();
        }
        [AllowAnonymous]
        [HttpGet]
        [EnableQuery]
        public IQueryable<AtlasModel.Patient> GetPatient1()
        {
            var gg = "Patient";

            return AtlasContextFactory.Instance.CreateContext().Patient;

        }


    }
}
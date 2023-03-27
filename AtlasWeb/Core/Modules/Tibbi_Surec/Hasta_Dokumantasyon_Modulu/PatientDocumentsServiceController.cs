//$91FFD0C5
using System;
using System.Linq;
using System.Net.Http;
using System.ComponentModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models;
using Infrastructure.Models;
using Infrastructure.Filters;
using TTObjectClasses;
using TTInstanceManagement;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Infrastructure.Helpers;

namespace Core.Controllers
{
    [Route("api/[controller]/[action]/{id?}")]
    [HvlResult]
    public partial class PatientDocumentsServiceController : Controller
    {

        public class GetPatientEpisodes_Input
        {
            public Guid PatientID
            {
                get; set;
            }
        }

        [HttpPost]
        public IList<UploadedDocument.GetPatientEpisodes_Class> GetPatientEpisodes(GetPatientEpisodes_Input input)
        {
            var ret = UploadedDocument.GetPatientEpisodes(input.PatientID).ToArray();
            return ret;
        }

        public class GetPatientDocuments_Input
        {
            public Guid EpisodeID
            {
                get; set;
            }
        }

        [HttpPost]
        public IList<UploadedDocument.GetPatientDocuments_Class> GetPatientDocuments(GetPatientDocuments_Input input)
        {
            var ret = UploadedDocument.GetPatientDocuments(input.EpisodeID).ToArray();
            return ret;
        }
        public class GetPatientDocsCount_Input
        {
            public Guid PatientID
            {
                get; set;
            }
        }
        [HttpPost]
        public int GetPatientDocumentCount(GetPatientDocsCount_Input input)
        {
            var ret = UploadedDocument.GetPatientDocumentCount(input.PatientID);
            return int.Parse(ret[0].Dokumansayisi.ToString());
        }

        public class DocumentUpload_Input
        {
            public string EpisodeID
            {
                get; set;
            }

            public IList<FormFile> File
            {
                get; set;
            }
            public string FileName
            {
                get; set;
            }
            public string Explanation
            {
                get; set;
            }

            public UploadedDocumentType DocumentType
            {
                get; set;
            }
            public Guid DocumentTypeID
            {
                get; set;
            }

            public string EpisodeActionID
            {
                get; set;
            }
            public string SubEpisodeID
            {
                get;set;
            }

        }

        public class DataInputModel
        {
            public string EpisodeID { get; set; }
            public string EpisodeActionID { get; set; }
            public string PatientID { get; set; }

        }
        public class DataResultModel
        {
            public List<DocumentGridModel> PatientDocuments { get; set; }
            public List<DosyaTuru> DocumentTypes { get; set; }
            public SubEpisode SubEpisode { get; set; }
        }

        public class DocumentGridModel
        {
            public Guid? ObjectID { get; set; }
            public string FileName { get; set; }
            public string Explanation { get; set; }
            public string DocumentTypeName { get; set; }
            public Guid? DocumentTypeID { get; set; }
            public string ProtocolNo { get; set; }
            public bool IsNew { get; set; }
            public object File { get; set; }
            public DosyaTuru DocumentType { get; set; }
            public Guid SubEpisodeID { get; set; }
            public SubEpisode SubEpisode { get; set; }

        }


        [HttpPost]
        [DisableFormValueModelBinding]
        public async Task<IActionResult> Upload()
        {
            var result = await MultipartRequestHelper.BindMultiPartFormDataToViewModel<DocumentUpload_Input>(this);
            var objectResult = result as ObjectResult;
            var viewModel = objectResult.Value as DocumentUpload_Input;

            using (var context = new TTObjectContext(false))
            {
                Guid savePoint = context.BeginSavePoint();
                if (viewModel != null)
                {
                    validateFields(viewModel);
                    Episode theEpisode = context.GetObject<Episode>(new Guid(viewModel.EpisodeID));
                    EpisodeAction episodeAction = context.GetObject<EpisodeAction>(new Guid(viewModel.EpisodeActionID));
                    SubEpisode subEpisode = context.GetObject<SubEpisode>(new Guid(viewModel.SubEpisodeID));
                    if (viewModel.File != null)
                    {
                        UploadedDocument doc = new UploadedDocument(context);
                        var formFile = viewModel.File.FirstOrDefault();
                        if (StreamHelpers.ToByteArray(formFile.OpenReadStream()).Length <= 10000000)
                        {

                            if (FileTypeCheck.fileTypeCheck(StreamHelpers.ToByteArray(formFile.OpenReadStream()), viewModel.FileName))
                            {
                                doc.File = StreamHelpers.ToByteArray(formFile.OpenReadStream());
                                doc.FileName = viewModel.FileName;
                                doc.UploadDate = DateTime.Now;
                                doc.Explanation = viewModel.Explanation;
                             //   doc.DocumentType = viewModel.DocumentType;
                                doc.Uploader = Common.CurrentResource;
                                doc.Episode = theEpisode;
                                doc.DosyaTuru = context.GetObject<DosyaTuru>(viewModel.DocumentTypeID);
                                doc.SubEpisode = subEpisode; 
                                context.Save();
                            }
                            else
                                throw new TTUtils.TTException(TTUtils.CultureService.GetText("M25690", "Geçersiz dosya tipi!"));
                        }
                        else
                        {
                            throw new TTUtils.TTException(TTUtils.CultureService.GetText("M25077", "10 Mb'dan büyük dosya yükleyemezsiniz!"));
                        }
                    }
                }
            }

            return Ok();
        }
        [HttpPost]
        public DataResultModel LoadDataSources(DataInputModel input)
        {
            using (TTObjectContext objectContext = new TTObjectContext(true))
            {
                DataResultModel result = new DataResultModel();

                //Dosya Turu listesi icin
                List<DosyaTuru> DocumentTypes = DosyaTuru.GetDocumentTypes(objectContext, "").ToList();
                objectContext.FullPartialllyLoadedObjects();
                result.DocumentTypes = DocumentTypes;



                List<UploadedDocument> PatientDocuments = UploadedDocument.GetPatientAllDocuments(objectContext, new Guid(input.PatientID)).ToList();
             //   List<UploadedDocument.GetAllPatientDocuments_Class> PatientDocuments = UploadedDocument.GetAllPatientDocuments(objectContext, new Guid(input.EpisodeID)).ToList();
                List<DocumentGridModel> DocumentList = new List<DocumentGridModel>();
                objectContext.FullPartialllyLoadedObjects();

                foreach(UploadedDocument doc in PatientDocuments)
                {
                    DocumentGridModel model = new DocumentGridModel();
                    model.DocumentTypeName = doc.DosyaTuru.dosyaTuruAdi;
                    model.DocumentTypeID = doc.DosyaTuru.ObjectID;
                    model.Explanation = doc.Explanation;
                    model.FileName = doc.FileName;
                    model.ObjectID = doc.ObjectID;
                    model.ProtocolNo = doc.SubEpisode.ProtocolNo;
                    model.IsNew = ((ITTObject)doc).IsNew;
                    model.File = doc.File;
                    model.DocumentType = doc.DosyaTuru;
                    model.SubEpisode = doc.SubEpisode;

                    DocumentList.Add(model);
                }
                result.PatientDocuments = DocumentList;
                
                
                 
                //Protocolno'ya erismek icin
                EpisodeAction episodeAction = objectContext.GetObject<EpisodeAction>(new Guid(input.EpisodeActionID));
                var subEpisode = episodeAction.SubEpisode;
                result.SubEpisode = subEpisode;

                return result;
            }
        }

        public List<UploadedDocument> LoadPatientDocuments(string EpisodeID)
        {
            using (TTObjectContext objectContext = new TTObjectContext(true))
            {
              
                //Hastanin yuklenen dokumanlarına ulasmak icin
                List<UploadedDocument> PatientDocuments = UploadedDocument.GetPatientAllDocuments(objectContext, new Guid(EpisodeID)).ToList();
                objectContext.FullPartialllyLoadedObjects();
                return PatientDocuments;

            }

        }

                private void validateFields(DocumentUpload_Input input)
        {
            if (input.Explanation == null)
                throw new TTUtils.TTException(TTUtils.CultureService.GetText("M26381", "Lütfen Açıklama Giriniz!"));
        }

        public class DeleteDocument_Input
        {
            public Guid documentid
            {
                get; set;
            }
        }

        [HttpPost]
        public void DeleteDocument(DeleteDocument_Input input)
        {
            using (var context = new TTObjectContext(false))
            {
                UploadedDocument doc = context.GetObject<UploadedDocument>(input.documentid);
                if (doc.Uploader.ObjectID == Common.CurrentResource.ObjectID)
                {
                    ((ITTObject)doc).Delete();
                    context.Save();
                }
                else
                    throw new TTUtils.TTException(TTUtils.CultureService.GetText("M25304", "Bu dosyayı silme yetkiniz yoktur!"));
            }

        }




    }

    [Route("api/[controller]/[action]/{id?}")]
    public partial class DocumentDownloadServiceController : Controller
    {

        public class DownloadFileInput
        {
            public Guid id { get; set; }
        }

        [HttpPost]
        public IActionResult DownloadFile(DownloadFileInput input)
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                UploadedDocument doc = (UploadedDocument)objectContext.GetObject(input.id, typeof(UploadedDocument));
                Byte[] memoryStream = (byte[])doc.File;
                System.IO.Stream myInputStream = new System.IO.MemoryStream(memoryStream);
                myInputStream.Position = 0;
                var contentType = "";
                if (doc.FileName.Substring(doc.FileName.LastIndexOf('.')).ToUpper() == ".DOCX")
                {
                    contentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                }
                else if (doc.FileName.Substring(doc.FileName.LastIndexOf('.')).ToUpper() == ".PNG")
                {
                    contentType = "image/png";
                }
                else if (doc.FileName.Substring(doc.FileName.LastIndexOf('.')).ToUpper() == ".JPG"
                    || doc.FileName.Substring(doc.FileName.LastIndexOf('.')).ToUpper() == ".JPEG")
                {
                    contentType = "image/jpeg";
                }
                else if (doc.FileName.Substring(doc.FileName.LastIndexOf('.')).ToUpper() == ".DOC")
                {
                    contentType = "application/msword";
                }
                else if (doc.FileName.Substring(doc.FileName.LastIndexOf('.')).ToUpper() == ".PPT")
                {
                    contentType = "application/vnd.ms-powerpoint";
                }
                else if (doc.FileName.Substring(doc.FileName.LastIndexOf('.')).ToUpper() == ".PPTX")
                {
                    contentType = " application/vnd.openxmlformats-officedocument.presentationml.presentation";
                }
                else if (doc.FileName.Substring(doc.FileName.LastIndexOf('.')).ToUpper() == ".PDF")
                {
                    contentType = "application/pdf";
                }
                else if (doc.FileName.Substring(doc.FileName.LastIndexOf('.')).ToUpper() == ".XLS")
                {
                    contentType = "application/vnd.ms-excel";
                }
                else if (doc.FileName.Substring(doc.FileName.LastIndexOf('.')).ToUpper() == ".XLSX")
                {
                    contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                }
                else if (doc.FileName.Substring(doc.FileName.LastIndexOf('.')).ToUpper() == ".XLSM")
                {
                    contentType = "application/vnd.ms-excel.sheet.macroEnabled.12";
                }
                else if (doc.FileName.Substring(doc.FileName.LastIndexOf('.')).ToUpper() == ".MP3")
                {
                    contentType = "audio/mpeg";
                }
                else if (doc.FileName.Substring(doc.FileName.LastIndexOf('.')).ToUpper() == ".MP4")
                {
                    contentType = "video/mp4";
                }
                else if (doc.FileName.Substring(doc.FileName.LastIndexOf('.')).ToUpper() == ".AVI")
                {
                    contentType = "video/avi";
                }
                else if (doc.FileName.Substring(doc.FileName.LastIndexOf('.')).ToUpper() == ".WMA")
                {
                    contentType = "audio/x-ms-wma";
                }
                else if (doc.FileName.Substring(doc.FileName.LastIndexOf('.')).ToUpperInvariant() == ".TIF" || doc.FileName.Substring(doc.FileName.LastIndexOf('.')).ToUpperInvariant() == ".TIFF")
                {
                    contentType = "image/tiff";
                }
                else
                    return null;
                var response = new FileStreamResult(myInputStream, contentType);

                objectContext.FullPartialllyLoadedObjects();
                return response;
            }
        }
    }
}
 
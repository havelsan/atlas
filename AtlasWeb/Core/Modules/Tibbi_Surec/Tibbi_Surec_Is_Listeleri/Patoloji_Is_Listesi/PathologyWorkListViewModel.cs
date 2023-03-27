using System;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using Infrastructure.Filters;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Core.Security;
using System.Linq;
using System.ComponentModel;
using System.Text;

namespace Core.Controllers
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public class PathologyWorkListServiceController : BaseEpisodeActionWorkListServiceController
    {
        public PathologyWorkListViewModel LoadPathologyWorkListViewModel()
        {
            PathologyWorkListViewModel viewModel = new PathologyWorkListViewModel();
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel.WorkList = new List<PathologyWorkListItem>();
                viewModel._SearchCriteria = new PathologyWorkListSearchCriteria();
                viewModel._SearchCriteria.WorkListStartDate = Convert.ToDateTime(Common.RecTime().ToShortDateString() + " " + "00:00:00");
                viewModel._SearchCriteria.WorkListEndDate = Convert.ToDateTime(Common.RecTime().ToShortDateString() + " " + "23:59:59");

                #region Birim Listesi
                viewModel.ResourceList = new List<ResSection>();


                var resources = ResSection.GetResSections(objectContext, " WHERE ISACTIVE = 1 AND OBJECTDEFNAME IN ('RESPOLICLINIC','RESCLINIC','RESDEPARTMENT','RESOBSERVATIONUNIT') ORDER BY NAME");
            
                foreach (var resource in resources)
                {
                    viewModel.ResourceList.Add(resource);
                }


                //foreach (var useResource in Common.CurrentResource.UserResources)
                //{
                //    if (useResource.Resource is ResPoliclinic)
                //    {
                //        var resource = viewModel.ResourceList.Where(t => t.ObjectID == useResource.Resource.ObjectID).FirstOrDefault();
                //        if (resource == null)
                //            viewModel.ResourceList.Add(useResource.Resource);
                //    }
                //}

                viewModel.ResourceList = viewModel.ResourceList.OrderBy(x => x.Name).ToList<ResSection>();
                var CurrentResource = Common.CurrentResource;
                viewModel._SearchCriteria.Resources = new List<ResSection>();
                viewModel._SearchCriteria.Morphologies = new List<MorphologyObject>();


                viewModel.MorphologyList = new List<MorphologyObject>();
                var morphologies = SKRSICDOMORFOLOJIKODU.GetSKRSICDOMORFOLOJIKODU(objectContext, " WHERE AKTIF = 1  ORDER BY MORFOLOJIKOD");

                foreach (var morphology in morphologies)
                {
                    MorphologyObject o = new MorphologyObject();
                    o.ObjectID = morphology.ObjectID.ToString();
                    o.Name = morphology.MORFOLOJIKOD + " " + morphology.MORFOLOJIKODTANIM;
                    o.MorfolojiKod = morphology.MORFOLOJIKOD;
                    o.MorfolojiTanim = morphology.MORFOLOJIKODTANIM;
                    viewModel.MorphologyList.Add(o);
                }

                viewModel.MorphologyList = viewModel.MorphologyList.OrderBy(x => x.MorfolojiKod).ToList<MorphologyObject>();
                //var selectedOutPatientResource = CurrentResource.SelectedOutPatientResource;
                //if (selectedOutPatientResource != null && selectedOutPatientResource is ResPoliclinic)
                //{
                //    viewModel._SearchCriteria.Resources.Add(selectedOutPatientResource);
                //}
                //else if (selectedOutPatientResource != null && selectedOutPatientResource is ResDepartment)
                //{

                //    ResDepartment resDepartment = (ResDepartment)objectContext.GetObject(selectedOutPatientResource.ObjectID, "ResDepartment");
                //    foreach (var sResource in resDepartment.Policlinics)
                //    {
                //        viewModel._SearchCriteria.Resources.Add(sResource);
                //    }
                //}

                #endregion

                objectContext.FullPartialllyLoadedObjects();
            }
            return viewModel;
        }

        public PathologyWorkListViewModel GetPathologyWorkList(PathologyWorkListSearchCriteria sc)
        {
            if (sc == null)
            {
                throw new Exception("Arama kriterleri girilmeden sorgulama yapılamaz.");
            }

            var viewModel = new PathologyWorkListViewModel();
            viewModel.WorkList = new List<PathologyWorkListItem>();
   
            var CurrentUser = Common.CurrentResource;
            string _filter = string.Empty;
            using (TTObjectContext objectContext = new TTObjectContext(true))
            {
                if (!string.IsNullOrEmpty(sc.PatientObjectID) || !String.IsNullOrEmpty(sc.ProtocolNo))
                {
                    //Hasta seçildi ise başka kritere bakılmayacak
                    if (!string.IsNullOrEmpty(sc.PatientObjectID))
                    {
                        _filter = " AND this.Subepisode.Episode.Patient.OBJECTID = '" + sc.PatientObjectID + "' ";

                    }
                    //Kabul numarası girildi ise başka kritere bakılmayacak 
                    if (!String.IsNullOrEmpty(sc.ProtocolNo))
                    {
                        if (sc.ProtocolNo.Contains("-"))
                            _filter = " AND THIS.SUBEPISODE.PROTOCOLNO = '" + sc.ProtocolNo.Trim() + "'";
                        else
                        {
                            _filter = " AND THIS.SUBEPISODE.PROTOCOLNO LIKE '" + sc.ProtocolNo.Trim() + "%'";
                        }
                    }

                    var pathologyList = Pathology.GetPathologyForWL(objectContext, _filter);
                    foreach (var pathologyFWL in pathologyList)
                    {
                        PathologyWorkListItem item = new PathologyWorkListItem();
                        item.ObjectDefID = pathologyFWL.ObjectDefID.ToString();
                        item.ObjectDefName = pathologyFWL.ObjectDefName;
                        item.ObjectID = (Guid)pathologyFWL.ObjectID;
                        item.RequestDate = pathologyFWL.RequestDate.Value;
                        item.AdmissionResource = pathologyFWL.Admissionresource;
                        item.PatientType = Common.GetDisplayTextOfDataTypeEnum(pathologyFWL.PatientStatus.Value);
                        item.PatientNameSurname = pathologyFWL.Patientname + " " + pathologyFWL.Patientsurname;
                        item.PatientTRID = pathologyFWL.UniqueRefNo == null ? "" : pathologyFWL.UniqueRefNo.ToString();
                        item.AdmissionProtocolNo = pathologyFWL.Admissionprotocolno == null ? "" : pathologyFWL.Admissionprotocolno.ToString();
                        item.ActionType = "Patoloji";
                        item.ActionState = pathologyFWL.DisplayText;
                        item.RequestResource = pathologyFWL.Fromresource;
                        item.HasFrozen = pathologyFWL.HasFrozen == null?false: Convert.ToBoolean(pathologyFWL.HasFrozen);
                        viewModel.WorkList.Add(item);

                    }

                    var pathologyRequestList = PathologyRequest.GetPathologyRequestForWL(objectContext, _filter);
                    foreach (var pathologyRequestFWL in pathologyRequestList)
                    {
                        PathologyWorkListItem item = new PathologyWorkListItem();
                        item.ObjectDefID = pathologyRequestFWL.ObjectDefID.ToString();
                        item.ObjectDefName = pathologyRequestFWL.ObjectDefName;
                        item.ObjectID = (Guid)pathologyRequestFWL.ObjectID;
                        item.RequestDate = pathologyRequestFWL.RequestDate.Value;
                        item.AdmissionResource = pathologyRequestFWL.Admissionresource;
                        item.PatientType = Common.GetDisplayTextOfDataTypeEnum(pathologyRequestFWL.PatientStatus.Value);
                        item.PatientNameSurname = pathologyRequestFWL.Patientname + " " + pathologyRequestFWL.Patientsurname;
                        item.PatientTRID = pathologyRequestFWL.UniqueRefNo == null ? "" : pathologyRequestFWL.UniqueRefNo.ToString();
                        item.AdmissionProtocolNo = pathologyRequestFWL.Admissionprotocolno == null ? "" : pathologyRequestFWL.Admissionprotocolno.ToString();
                        item.ActionType = "Patoloji İstek";
                        item.ActionState = pathologyRequestFWL.DisplayText;
                        item.RequestResource = pathologyRequestFWL.Fromresource;
                        item.HasFrozen = pathologyRequestFWL.HasFrozen == null ? false : Convert.ToBoolean(pathologyRequestFWL.HasFrozen);
                        viewModel.WorkList.Add(item);

                    }

                }
                else
                {
                    if (sc.pathology_EA)
                    {
                        string _filterPathology = String.Empty;

                        string _filterResource = string.Empty;
                        foreach (var resource in sc.Resources)
                        {
                            if (string.IsNullOrEmpty(_filterResource))
                                _filterResource = " AND this.PATHOLOGYREQUEST.FROMRESOURCE IN (''";
                            _filterResource += ",'" + resource.ObjectID + "'";

                        }

                        if (!string.IsNullOrEmpty(_filterResource))
                        {
                            _filter += _filterResource + ")";
                        }

                        string filterMorphology = string.Empty;
                        foreach(var morfoloji in sc.Morphologies)
                        {
                            if (string.IsNullOrEmpty(filterMorphology))
                                filterMorphology = " AND this.PathologyMaterial.MorfolojiKodu IN (''";
                            filterMorphology += ",'" + morfoloji.ObjectID + "'";
                        }

                        if (!string.IsNullOrEmpty(filterMorphology))
                        {
                            _filter += filterMorphology + ")";
                        }


                        _filterPathology = _filter;
                        if (String.IsNullOrEmpty(sc.ProtocolNo) && string.IsNullOrEmpty(sc.PatientObjectID))
                        {
                            _filterPathology += " AND this.PathologyRequest.REQUESTDATE BETWEEN " + GetDateAsString(sc.WorkListStartDate.Value.Date) + " AND " + GetDateAsString(sc.WorkListEndDate);

                            if (sc.PatientType == 1)
                                _filterPathology += " AND this.ProcedureDoctor = '" + CurrentUser.ObjectID + "'";

                            string pathology_States = string.Empty;
                            if (sc.procedure)
                            {
                                if (!string.IsNullOrEmpty(pathology_States))
                                    pathology_States += ",";
                                pathology_States += "'" + Pathology.States.Procedure.ToString() + "'";
                            }
                            if (sc.senttoapprovement)
                            {
                                if (!string.IsNullOrEmpty(pathology_States))
                                    pathology_States += ",";
                                pathology_States += "'" + Pathology.States.SentToApprovement.ToString() + "'";
                            }
                            if (sc.approvement)
                            {
                                if (!string.IsNullOrEmpty(pathology_States))
                                    pathology_States += ",";
                                pathology_States += "'" + Pathology.States.Approvement.ToString() + "'";
                            }
                            if (sc.report)
                            {
                                if (!string.IsNullOrEmpty(pathology_States))
                                    pathology_States += ",";
                                pathology_States += "'" + Pathology.States.Report.ToString() + "'";
                            }
                            if (sc.cancel)
                            {
                                if (!string.IsNullOrEmpty(pathology_States))
                                    pathology_States += ",";
                                pathology_States += "'" + Pathology.States.Cancelled.ToString() + "'";
                            }

                            if (!string.IsNullOrEmpty(pathology_States))
                            {
                                _filterPathology += " AND this.CURRENTSTATEDEFID IN(" + pathology_States + ")";
                            }

                            if (!string.IsNullOrEmpty(sc.MaterialProtocolNo))
                            {
                                _filterPathology += " AND THIS.MatPrtNoString = '" + sc.MaterialProtocolNo + "'";
                            }

                            if (!string.IsNullOrEmpty(sc.Macroskopi))
                            {
                                _filterPathology += " AND THIS.PathologyMaterial.Macroscopy LIKE '%"+sc.Macroskopi+"%'";
                            }
                            if (!string.IsNullOrEmpty(sc.Microskopi))
                            {
                                _filterPathology += " AND THIS.PathologyMaterial.Microscopy LIKE '%" + sc.Microskopi + "%'";
                            }
                            if (!string.IsNullOrEmpty(sc.PathologyDiagnosis))
                            {
                                _filterPathology += " AND THIS.PathologyMaterial.PathologicDiagnosis LIKE '%" + sc.PathologyDiagnosis + "%'";
                            }
                        }

                        var pathologyList = Pathology.GetPathologyForWL(objectContext, _filterPathology);
                        foreach (var pathologyFWL in pathologyList)
                        {
                            PathologyWorkListItem item = new PathologyWorkListItem();
                            item.ObjectDefID = pathologyFWL.ObjectDefID.ToString();
                            item.ObjectDefName = pathologyFWL.ObjectDefName;
                            item.ObjectID = (Guid)pathologyFWL.ObjectID;
                            item.RequestDate = pathologyFWL.RequestDate.Value;
                            item.AdmissionResource = pathologyFWL.Admissionresource;
                            item.PatientType = Common.GetDisplayTextOfDataTypeEnum(pathologyFWL.PatientStatus.Value);
                            item.PatientNameSurname = pathologyFWL.Patientname + " " + pathologyFWL.Patientsurname;
                            item.PatientTRID = pathologyFWL.UniqueRefNo == null ? "" : pathologyFWL.UniqueRefNo.ToString();
                            item.AdmissionProtocolNo = pathologyFWL.Admissionprotocolno == null ? "" : pathologyFWL.Admissionprotocolno.ToString();
                            item.ActionType = "Patoloji";
                            item.ActionState = pathologyFWL.DisplayText;
                            item.RequestResource = pathologyFWL.Fromresource;
                            item.HasFrozen = pathologyFWL.HasFrozen == null ? false : Convert.ToBoolean(pathologyFWL.HasFrozen);
                            viewModel.WorkList.Add(item);

                        }

                    }

                    if (sc.pathologyRequest_EA)
                    {

                        string _filterResource = string.Empty;
                        foreach (var resource in sc.Resources)
                        {
                            if (string.IsNullOrEmpty(_filterResource))
                                _filterResource = " AND this.FROMRESOURCE IN (''";
                            _filterResource += ",'" + resource.ObjectID + "'";

                        }

                        if (!string.IsNullOrEmpty(_filterResource))
                        {
                            _filter += _filterResource + ")";
                        }




                        string _filterPathologyRequest = String.Empty;
                        _filterPathologyRequest = _filter;
                        if (String.IsNullOrEmpty(sc.ProtocolNo) && string.IsNullOrEmpty(sc.PatientObjectID))
                        {
                            _filterPathologyRequest += " AND this.REQUESTDATE BETWEEN " + GetDateAsString(sc.WorkListStartDate.Value.Date) + " AND " + GetDateAsString(sc.WorkListEndDate);

                            string pathologyRequest_States = string.Empty;
                            if (sc.accept)
                            {
                                if (!string.IsNullOrEmpty(pathologyRequest_States))
                                    pathologyRequest_States += ",";
                                pathologyRequest_States += "'" + PathologyRequest.States.Accept.ToString() + "'";
                            }

                            if (sc.request_procedure)
                            {
                                if (!string.IsNullOrEmpty(pathologyRequest_States))
                                    pathologyRequest_States += ",";
                                pathologyRequest_States += "'" + PathologyRequest.States.Procedure.ToString() + "'";
                            }

                            if (sc.request_cancel)
                            {
                                if (!string.IsNullOrEmpty(pathologyRequest_States))
                                    pathologyRequest_States += ",";
                                pathologyRequest_States += "'" + PathologyRequest.States.Cancelled.ToString() + "'";
                            }


                            if (!string.IsNullOrEmpty(pathologyRequest_States))
                            {
                                _filterPathologyRequest += " AND this.CURRENTSTATEDEFID IN(" + pathologyRequest_States + ")";
                            }

                            var pathologyRequestList = PathologyRequest.GetPathologyRequestForWL(objectContext, _filterPathologyRequest);
                            foreach (var pathologyRequestFWL in pathologyRequestList)
                            {
                                PathologyWorkListItem item = new PathologyWorkListItem();
                                item.ObjectDefID = pathologyRequestFWL.ObjectDefID.ToString();
                                item.ObjectDefName = pathologyRequestFWL.ObjectDefName;
                                item.ObjectID = (Guid)pathologyRequestFWL.ObjectID;
                                item.RequestDate = pathologyRequestFWL.RequestDate.Value;
                                item.AdmissionResource = pathologyRequestFWL.Admissionresource;
                                item.PatientType = Common.GetDisplayTextOfDataTypeEnum(pathologyRequestFWL.PatientStatus.Value);
                                item.PatientNameSurname = pathologyRequestFWL.Patientname + " " + pathologyRequestFWL.Patientsurname;
                                item.PatientTRID = pathologyRequestFWL.UniqueRefNo == null ? "" : pathologyRequestFWL.UniqueRefNo.ToString();
                                item.AdmissionProtocolNo = pathologyRequestFWL.Admissionprotocolno == null ? "" : pathologyRequestFWL.Admissionprotocolno.ToString();
                                item.ActionType = "Patoloji İstek";
                                item.ActionState = pathologyRequestFWL.DisplayText;
                                item.RequestResource = pathologyRequestFWL.Fromresource;
                                item.HasFrozen = pathologyRequestFWL.HasFrozen == null ? false : Convert.ToBoolean(pathologyRequestFWL.HasFrozen);
                                viewModel.WorkList.Add(item);

                            }

                        }

                    }

                }
            }

            return viewModel;

        }

    }
}

namespace Core.Models
{
    public partial class PathologyWorkListViewModel : BaseEpisodeActionWorkListFormViewModel
    {
        public List<PathologyWorkListItem> WorkList;
        public PathologyWorkListSearchCriteria _SearchCriteria
        {
            get;
            set;
        }
        public List<ResSection> ResourceList { get; set; }

        public List<MorphologyObject> MorphologyList { get; set; }

        public PathologyWorkListViewModel()
        {
            this._SearchCriteria = new PathologyWorkListSearchCriteria();
            this.WorkList = new List<PathologyWorkListItem>();
         
        }
    }

    public class PathologyWorkListItem: BaseEpisodeActionWorkListItem
    {
        public DateTime RequestDate
        {
            get;
            set;
        }

        public string AdmissionResource
        {
            get;
            set;
        }

        public string PatientType
        {
            get;
            set;
        }
        public string PatientNameSurname
        {
            get;
            set;
        }
        public string PatientTRID
        {
            get;
            set;
        }
        public string AdmissionProtocolNo
        {
            get;
            set;
        }
        public string ActionType
        {
            get;
            set;
        }
        public string ActionState
        {
            get;
            set;
        }
        public string RequestResource
        {
            get;
            set;
        }

        public bool HasFrozen
        {
            get;
            set;
        }
    }

    public class MorphologyObject
    {
        public string ObjectID { get; set; }
        public string Name { get; set; }
        public string MorfolojiKod { get; set; }
        public string MorfolojiTanim { get; set; }
    }

    [Serializable]
    public class PathologyWorkListSearchCriteria: BaseEpisodeActionWorkListSearchCriteria
    {
        public List<ResSection> Resources { get; set; }
        public List<MorphologyObject> Morphologies { get; set; }

        public string ProtocolNo { get; set; }

        public int PatientType { get; set; }
        public List<ListObject> ActionTypes { get; set; }
        public bool pathology_EA { get; set; }
        public bool pathologyRequest_EA { get; set; }

        //Patoloji Stateleri

        public bool procedure { get; set; } //İşlemde
        public bool approvement { get; set; } //Onaylı
        public bool senttoapprovement { get; set; } //Onay Bekliyor
        public bool report { get; set; } //Rapor Basıldı/Tamamlandı
        public bool cancel { get; set; }//İptal Edildi

        //Patoloji İstek Stateleri
        public bool accept { get; set; } //İstek Kabul
        public bool request_procedure { get; set; } //İşlemde
        public bool request_cancel { get; set; }//İptal Edildi

        //Detaylı Arama
        public string MaterialProtocolNo { get; set; }
        public string Macroskopi { get; set; }
        public string Microskopi { get; set; }
        public string PathologyDiagnosis { get; set; }
    }
}
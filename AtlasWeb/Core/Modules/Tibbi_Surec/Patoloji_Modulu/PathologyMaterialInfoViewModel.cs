//$430E55D4
using System;
using System.Linq;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    public partial class PathologyMaterialServiceController
    {
        [HttpGet]
        public MaterialDefinitionsViewModel GetDefinitions()
        {
            MaterialDefinitionsViewModel result = new MaterialDefinitionsViewModel();
            var objectContext = new TTObjectContext(false);
            result.SKRSICDOYERLESIMYERIs = objectContext.QueryObjects<SKRSICDOYERLESIMYERI>().ToArray();
            result.SKRSPatolojiPreparatiDurumus = objectContext.QueryObjects<SKRSPatolojiPreparatiDurumu>().ToArray();
            result.SKRSNumuneAlinmaSeklis = objectContext.QueryObjects<SKRSNumuneAlinmaSekli>().ToArray();
            result.SKRSICDOMORFOLOJIKODUs = objectContext.QueryObjects<SKRSICDOMORFOLOJIKODU>().ToArray();
            result.SKRSNumuneAlindigiDokununTemelOzelligis = objectContext.QueryObjects<SKRSNumuneAlindigiDokununTemelOzelligi>().ToArray();
            result.ProcedureDefinitions = objectContext.QueryObjects<PathologyTestDefinition>().ToArray();
            return result;
        }

        [HttpGet]
        public vmRequestedPathologyProcedure[] GetRequestedPathologyProcedures(Guid materialObjectID)
        {
            List<vmRequestedPathologyProcedure> procedureList = new List<vmRequestedPathologyProcedure>();
            TTObjectContext objContext = new TTObjectContext(false);
            BindingList<PathologyTestProcedure.GetPathologyProceduresByMaterialObjectID_Class> requestProceduresList = TTObjectClasses.PathologyTestProcedure.GetPathologyProceduresByMaterialObjectID(objContext, materialObjectID);
            foreach (PathologyTestProcedure.GetPathologyProceduresByMaterialObjectID_Class subActionProc in requestProceduresList.ToList())
            {
                if (subActionProc.CurrentStateDefID != PathologyTestProcedure.States.Cancelled)
                {
                    vmRequestedPathologyProcedure reqProc = new vmRequestedPathologyProcedure();
                    reqProc.MaterialObjectID = materialObjectID;
                    reqProc.SubActionProcedureObjectId = (Guid)subActionProc.Subactionprocedureobjectid;
                    reqProc.ProcedureCode = subActionProc.Procedurecode;
                    reqProc.ProcedureName = subActionProc.Procedurename;
                    reqProc.RequestDate = (DateTime)subActionProc.Requestdate;
                    if (subActionProc.Requestby != null)
                        reqProc.RequestBy = subActionProc.Requestby;
                    else
                        reqProc.RequestBy = "";
                    reqProc.MasterResource = subActionProc.Masterresource;
                    reqProc.Amount = Convert.ToInt32(subActionProc.Amount);
                    if (subActionProc.Proceduredoctor != null)
                        reqProc.ProcedureUser = subActionProc.Proceduredoctor;
                    else
                        reqProc.ProcedureUser = "";
                    reqProc.ProcedureDefObjectID = (Guid)subActionProc.Procedureobjectdef;
                    SubActionProcedure sp = (SubActionProcedure)objContext.GetObject((Guid)subActionProc.Subactionprocedureobjectid, "SubActionProcedure");
                    if (sp != null)
                    {
                        if (sp.GetProcedurePrice() != null)
                        {
                            reqProc.UnitPrice = (double)sp.GetProcedurePrice();
                        }
                    }

                    reqProc.CurrentStateDefID = (Guid)subActionProc.CurrentStateDefID;
                    procedureList.Add(reqProc);
                }
            }

            return procedureList.ToArray();
        }

        [HttpGet]
        public vmRequestedPathologyProcedure AddNewPathologyProcedure([FromQuery] string ProcedureDefObjectId, [FromQuery] string EpisodeActionObjectId)
        {
            TTObjectContext objContext = new TTObjectContext(true);
            ProcedureDefinition ttProcedureDefinition = (ProcedureDefinition)objContext.GetObject(new Guid(ProcedureDefObjectId), "ProcedureDefinition");
            vmRequestedPathologyProcedure vmRequestedProcedure = new vmRequestedPathologyProcedure();
            vmRequestedProcedure.ProcedureCode = ttProcedureDefinition.Code;
            vmRequestedProcedure.ProcedureName = ttProcedureDefinition.Name;
            vmRequestedProcedure.RequestDate = Common.RecTime();
            vmRequestedProcedure.RequestBy = Common.CurrentUser.Name;
            vmRequestedProcedure.Amount = 1;
            vmRequestedProcedure.ProcedureUser = ""; // patolojinin işlemi yapan doktoru gelecek
            vmRequestedProcedure.ProcedureDefObjectID = new Guid(ProcedureDefObjectId);
            EpisodeAction ea = (EpisodeAction)objContext.GetObject(new Guid(EpisodeActionObjectId), "EpisodeAction");
            vmRequestedProcedure.MasterResource = ea.MasterResource.Name; //patolojinin resourceu olacak
            if (ea.SubEpisode != null)
            {
                if (ea.SubEpisode.OpenSubEpisodeProtocol != null)
                {
                    if (ttProcedureDefinition.GetProcedurePrice(ea.SubEpisode.OpenSubEpisodeProtocol, DateTime.Now) != null)
                    {
                        vmRequestedProcedure.UnitPrice = (double)ttProcedureDefinition.GetProcedurePrice(ea.SubEpisode.OpenSubEpisodeProtocol, DateTime.Now);
                    }
                }
            }
            DateTime? requestdate = null;
            foreach(EpisodeAction action in  ea.SubEpisode.EpisodeActions)
            {
                if (action is InPatientTreatmentClinicApplication)
                    if (((InPatientTreatmentClinicApplication)action).ClinicDischargeDate != null)
                        requestdate = ((InPatientTreatmentClinicApplication)action).ClinicDischargeDate.Value;
            }

            if (requestdate != null)
                vmRequestedProcedure.RequestDate = Convert.ToDateTime(requestdate);
            else if (ea.SubEpisode.ClosingDate.HasValue && ea.SubEpisode.ClosingDate < Common.RecTime())
                vmRequestedProcedure.RequestDate = Convert.ToDateTime(ea.SubEpisode.ClosingDate);

            return vmRequestedProcedure;
        }

        [HttpGet]
        public bool DeletePathologyProcedure(string SubActionProcedureObjectId)
        {
            TTObjectContext objContext = new TTObjectContext(false);
            SubActionProcedure subActionProcedure = (SubActionProcedure)objContext.GetObject(new Guid(SubActionProcedureObjectId), "SubActionProcedure");

            ((PathologyTestProcedure)subActionProcedure).CurrentStateDefID = PathologyTestProcedure.States.Cancelled;
            objContext.Save();
            return true;

        }


    }
}

namespace Core.Models
{
    public partial class PathologyMaterialInfoViewModel
    {
        public object _selectedProcedureObject
        {
            get;
            set;
        }
    }

    public class MaterialDefinitionsViewModel
    {
        public TTObjectClasses.SKRSICDOYERLESIMYERI[] SKRSICDOYERLESIMYERIs
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSPatolojiPreparatiDurumu[] SKRSPatolojiPreparatiDurumus
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSNumuneAlinmaSekli[] SKRSNumuneAlinmaSeklis
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSICDOMORFOLOJIKODU[] SKRSICDOMORFOLOJIKODUs
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSNumuneAlindigiDokununTemelOzelligi[] SKRSNumuneAlindigiDokununTemelOzelligis
        {
            get;
            set;
        }

        public TTObjectClasses.ProcedureDefinition[] ProcedureDefinitions
        {
            get;
            set;
        }
    }

    public class vmRequestedPathologyProcedure
    {
        public Guid MaterialObjectID;
        public Guid SubActionProcedureObjectId;
        public string ProcedureCode;
        public string ProcedureName;
        public int Amount;
        public double UnitPrice;
        public DateTime RequestDate;
        public string RequestBy;
        public string ProcedureUser;
        public string MasterResource;
        public Guid CurrentStateDefID;
        public Guid ProcedureDefObjectID;
        public bool IsPaid;
        public bool? FromClinic;
    }
}
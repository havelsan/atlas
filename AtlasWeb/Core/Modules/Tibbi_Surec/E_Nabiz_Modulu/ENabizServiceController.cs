//$5BEE607A
using System;
using System.Linq;
using System.Net.Http;
using System.ComponentModel;
using System.Collections.Generic;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;

using Infrastructure.Filters;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Models;
using Core.Security;
using Infrastructure.Helpers;

namespace Core.Controllers
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public partial class ENabizServiceController : Controller
    {

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public void SaveDataSets(IENabizViewModel[] ENabizViewModels)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (ENabizViewModels != null)
                {
                    foreach (var enabizViewModel in ENabizViewModels)
                    {
                        enabizViewModel.AddENabizObjectViewModelToContext(objectContext);
                    }
                }

                objectContext.Save();
            }

        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public ENabizDataSets[] GetDatasetObjectIDs(EnabizInputObject inputObject)
        {

            using (var objectContext = new TTObjectContext(false))
            {
                
                EpisodeAction episodeAction = objectContext.GetObject<EpisodeAction>(inputObject.EpisodeActionID);
                if (inputObject.ENabizDataSets != null)
                {
                    foreach (ENabizDataSets dataSet in inputObject.ENabizDataSets)
                    {
                        foreach (ENabiz item in episodeAction.SubEpisode.ENabiz)
                        {
                            if (item is TutunKullanimiVeriSeti && dataSet.PackageID == 248)
                            {
                                dataSet.ObjectID = ((Guid)item.ObjectID);
                                break;
                            }
                            else if (item is KuduzProfilaksiVeriSeti && dataSet.PackageID == 236)
                            {
                                dataSet.ObjectID = ((Guid)item.ObjectID);
                                break;
                            }
                            else if (item is KuduzRiskliTemasVeriSeti && dataSet.PackageID == 237)
                            {
                                dataSet.ObjectID = ((Guid)item.ObjectID);
                                break;
                            }
                            else if (item is MaddeBagimliligiVeriSeti && dataSet.PackageID == 239)
                            {
                                dataSet.ObjectID = ((Guid)item.ObjectID);
                                break;
                            }
                            else if (item is KronikHastaliklarVeriSeti && dataSet.PackageID == 235)
                            {
                                dataSet.ObjectID = ((Guid)item.ObjectID);
                                break;
                            }
                            else if (item is VeremVeriSeti && dataSet.PackageID == 250)
                            {
                                dataSet.ObjectID = ((Guid)item.ObjectID);
                                break;
                            }
                            else if (item is EvdeSaglikIlkIzlemVeriSeti && dataSet.PackageID == 219)
                            {
                                dataSet.ObjectID = ((Guid)item.ObjectID);
                                break;
                            }
                            else if (item is EvdeSaglikIzlemVeriSeti && dataSet.PackageID == 220)
                            {
                                dataSet.ObjectID = ((Guid)item.ObjectID);
                                break;
                            }
                            else if (item is DiyabetVeriSeti && dataSet.PackageID == 215)//
                            {
                                dataSet.ObjectID = ((Guid)item.ObjectID);
                                break;
                            }
                            else if (item is ObeziteIzlemVeriSeti && dataSet.PackageID == 240)
                            {
                                dataSet.ObjectID = ((Guid)item.ObjectID);
                                break;
                            }
                            else if (item is IntiharIzlemVeriSeti && dataSet.PackageID == 229)
                            {
                                dataSet.ObjectID = ((Guid)item.ObjectID);
                                break;
                            }
                            else if (item is IntiharGirisimKrizVeriSeti && dataSet.PackageID == 230)
                            {
                                dataSet.ObjectID = ((Guid)item.ObjectID);
                                break;
                            }
                            else if (item is KadinaYonelikSiddetVeriSet && dataSet.PackageID == 231)
                            {
                                dataSet.ObjectID = ((Guid)item.ObjectID);
                                break;
                            }

                        }
                    }


                }
                
            }
            return inputObject.ENabizDataSets.ToArray();
        }
    }
}

namespace Core.Models
{
    public class EnabizInputObject
    {
        public List<ENabizDataSets> ENabizDataSets = new List<ENabizDataSets>();
        public Guid EpisodeActionID;
    }
    public class ENabizDataSets
    {
        public int PackageID
        {
            get;
            set;
        }
        public string PackageName
        {
            get;
            set;
        }
        public Guid DiagnosisObjectID
        {
            get;
            set;
        }

        public Guid? ObjectID
        {
            get;
            set;
        }
    }




}
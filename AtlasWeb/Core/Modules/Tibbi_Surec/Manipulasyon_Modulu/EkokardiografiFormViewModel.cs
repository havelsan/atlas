//$20BA1889
using System;
using System.Linq;
using Core.Models;
using Infrastructure.Filters;
using Infrastructure.Models;
using TTInstanceManagement;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;

namespace Core.Controllers
{
    public partial class EkokardiografiFormObjectServiceController
    {
    }
}

namespace Core.Models
{
    public partial class EkokardiografiFormViewModel: BaseViewModel,IManipulationFormBaseObjectViewModel
    {
        public void AddManipulationFormBaseObjectViewModelToContext(TTObjectContext objectContext)
        {

            objectContext.AddToRawObjectList(this.EkokardiografiBulgularGridList);
            objectContext.AddToRawObjectList(this.PulmonerKapakBulgularGridList);
            objectContext.AddToRawObjectList(this.TrikuspitKapakBulgularGridList);
            objectContext.AddToRawObjectList(this.AortKapakBulgularGridList);
            objectContext.AddToRawObjectList(this.MitralKapakBulgularGridList);
            objectContext.AddToRawObjectList(this._EkokardiografiFormObject);
            objectContext.ProcessRawObjects();

            //var ekokardiografiFormObject = (EkokardiografiFormObject)objectContext.GetLoadedObject(this._EkokardiografiFormObject.ObjectID);

            //if (this.EkokardiografiBulgularGridList != null)
            //{
            //    foreach (var item in this.EkokardiografiBulgularGridList)
            //    {
            //        var ekokardiografiBulgularImported = (EkokardiografiBulgu)objectContext.GetLoadedObject(item.ObjectID);
            //        if (((ITTObject)ekokardiografiBulgularImported).IsDeleted)
            //            continue;
            //        ekokardiografiBulgularImported.EkokardiografiFormObject = ekokardiografiFormObject;
            //    }
            //}

            //if (this.PulmonerKapakBulgularGridList != null)
            //{
            //    foreach (var item in this.PulmonerKapakBulgularGridList)
            //    {
            //        var pulmonerKapakBulgularImported = (PulmonerKapakBulgu)objectContext.GetLoadedObject(item.ObjectID);
            //        if (((ITTObject)pulmonerKapakBulgularImported).IsDeleted)
            //            continue;
            //        pulmonerKapakBulgularImported.EkokardiografiFormObject = ekokardiografiFormObject;
            //    }
            //}

            //if (this.TrikuspitKapakBulgularGridList != null)
            //{
            //    foreach (var item in this.TrikuspitKapakBulgularGridList)
            //    {
            //        var trikuspitKapakBulgularImported = (TrikuspitKapakBulgu)objectContext.GetLoadedObject(item.ObjectID);
            //        if (((ITTObject)trikuspitKapakBulgularImported).IsDeleted)
            //            continue;
            //        trikuspitKapakBulgularImported.EkokardiografiFormObject = ekokardiografiFormObject;
            //    }
            //}

            //if (this.AortKapakBulgularGridList != null)
            //{
            //    foreach (var item in this.AortKapakBulgularGridList)
            //    {
            //        var aortKapakBulgularImported = (AortKapakBulgu)objectContext.GetLoadedObject(item.ObjectID);
            //        if (((ITTObject)aortKapakBulgularImported).IsDeleted)
            //            continue;
            //        aortKapakBulgularImported.EkokardiografiFormObject = ekokardiografiFormObject;
            //    }
            //}

            //if (this.MitralKapakBulgularGridList != null)
            //{
            //    foreach (var item in this.MitralKapakBulgularGridList)
            //    {
            //        var mitralKapakBulgularImported = (MitralKapakBulgu)objectContext.GetLoadedObject(item.ObjectID);
            //        if (((ITTObject)mitralKapakBulgularImported).IsDeleted)
            //            continue;
            //        mitralKapakBulgularImported.EkokardiografiFormObject = ekokardiografiFormObject;
            //    }
            //}
        }

        public void SetManipulationReport(Manipulation manipulation)
        {
            manipulation.Report = this._EkokardiografiFormObject.EkoSonuc;
        }
    }
}

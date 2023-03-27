//$D8F51927
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

namespace Core.Controllers
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public partial class ResPoliclinicServiceController : Controller
    {
        public class SendResPoliclinicToMainGateOperation_Input
        {
            public TTObjectClasses.ResPoliclinic resPoliclinic
            {
                get;
                set;
            }
        }

        [HttpPost]
        public void SendResPoliclinicToMainGateOperation(SendResPoliclinicToMainGateOperation_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.resPoliclinic != null)
                    input.resPoliclinic = (TTObjectClasses.ResPoliclinic)objectContext.AddObject(input.resPoliclinic);
                ResPoliclinic.SendResPoliclinicToMainGateOperation(input.resPoliclinic);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        [HttpPost]
        public System.ComponentModel.BindingList<TTObjectClasses.ResPoliclinic> GetHCPoliclinicList()
        {
            var ret = ResPoliclinic.GetHCPoliclinicList();
            return ret;
        }

        [HttpPost]
        public BindingList<ResPoliclinic.OLAP_GetResPoliclinicCount_Class> OLAP_GetResPoliclinicCount()
        {
            var ret = ResPoliclinic.OLAP_GetResPoliclinicCount();
            return ret;
        }

        public class GetByRelation_Input
        {
            public string RELATIONPARENTNAME
            {
                get;
                set;
            }

            public string PARENTOBJECTID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<ResPoliclinic> GetByRelation(GetByRelation_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = ResPoliclinic.GetByRelation(objectContext, input.RELATIONPARENTNAME, input.PARENTOBJECTID);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetPoliclinicDefinition_Input
        {
            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<ResPoliclinic.GetPoliclinicDefinition_Class> GetPoliclinicDefinition(GetPoliclinicDefinition_Input input)
        {
            var ret = ResPoliclinic.GetPoliclinicDefinition(input.injectionSQL);
            return ret;
        }

        public class GetPoliclinicListDefinition_Input
        {
            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<ResPoliclinic.GetPoliclinicListDefinition_Class> GetPoliclinicListDefinition(GetPoliclinicListDefinition_Input input)
        {
            var ret = ResPoliclinic.GetPoliclinicListDefinition(input.injectionSQL);
            return ret;
        }

        public class GetPoliclinicByMHRSCode_Input
        {
            public int MHRSCODE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<ResPoliclinic> GetPoliclinicByMHRSCode(GetPoliclinicByMHRSCode_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = ResPoliclinic.GetPoliclinicByMHRSCode(objectContext, input.MHRSCODE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetPoliclinicByMedulaBrans_Input
        {
            public string BRANS
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<ResPoliclinic> GetPoliclinicByMedulaBrans(GetPoliclinicByMedulaBrans_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = ResPoliclinic.GetPoliclinicByMedulaBrans(objectContext, input.BRANS);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        [HttpPost]
        public BindingList<ResPoliclinic> GetDentalPoliclinic()
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = ResPoliclinic.GetDentalPoliclinic(objectContext);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetPoliclinicByAsalCode_Input
        {
            public int ASALCODE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<ResPoliclinic> GetPoliclinicByAsalCode(GetPoliclinicByAsalCode_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = ResPoliclinic.GetPoliclinicByAsalCode(objectContext, input.ASALCODE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetByMHRSKlinikVeAltKlinikKodu_Input
        {
            public int MHRSKLINIKKODU
            {
                get;
                set;
            }

            public int MHRSALTKLINIKKODU
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<ResPoliclinic> GetByMHRSKlinikVeAltKlinikKodu(GetByMHRSKlinikVeAltKlinikKodu_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = ResPoliclinic.GetByMHRSKlinikVeAltKlinikKodu(objectContext, input.MHRSKLINIKKODU, input.MHRSALTKLINIKKODU);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        [HttpPost]
        public BindingList<ResPoliclinic> GetMHRSPoliclinics()
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = ResPoliclinic.GetMHRSPoliclinics(objectContext);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetMHRSPoliclinicDefinition_Input
        {
            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<ResPoliclinic.GetMHRSPoliclinicDefinition_Class> GetMHRSPoliclinicDefinition(GetMHRSPoliclinicDefinition_Input input)
        {
            var ret = ResPoliclinic.GetMHRSPoliclinicDefinition(input.injectionSQL);
            return ret;
        }

        [HttpPost]
        public BindingList<ResPoliclinic> GetHCPoliclinic()
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = ResPoliclinic.GetHCPoliclinic(objectContext);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public BindingList<ResPoliclinic> GetAllPoliclinics()
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = ResPoliclinic.GetAllPoliclinics(objectContext);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }
    }
}
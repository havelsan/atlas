//$FBBEC751
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
    public partial class ResBedServiceController : Controller
    {
        [HttpPost]
        public BindingList<ResBed.GetEmptyBeds_Class> GetEmptyBeds()
        {
            var ret = ResBed.GetEmptyBeds();
            return ret;
        }

        public class GetWithNullUsedByAndRoom_Input
        {
            public string ROOM
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<ResBed> GetWithNullUsedByAndRoom(GetWithNullUsedByAndRoom_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = ResBed.GetWithNullUsedByAndRoom(objectContext, input.ROOM);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetWithNullUsedByAndRoomGroup_Input
        {
            public string ROOMGROUP
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<ResBed> GetWithNullUsedByAndRoomGroup(GetWithNullUsedByAndRoomGroup_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = ResBed.GetWithNullUsedByAndRoomGroup(objectContext, input.ROOMGROUP);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        [HttpPost]
        public BindingList<ResBed.OLAP_GetUsedByRelation_Class> OLAP_GetUsedByRelation()
        {
            var ret = ResBed.OLAP_GetUsedByRelation();
            return ret;
        }

        public class GetEmptyBedsByClinic_Input
        {
            public string WARD
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<ResBed.GetEmptyBedsByClinic_Class> GetEmptyBedsByClinic(GetEmptyBedsByClinic_Input input)
        {
            var ret = ResBed.GetEmptyBedsByClinic(input.WARD);
            return ret;
        }

        public class GetWithNullUsedByAndClinic_Input
        {
            public string WARD
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<ResBed> GetWithNullUsedByAndClinic(GetWithNullUsedByAndClinic_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = ResBed.GetWithNullUsedByAndClinic(objectContext, input.WARD);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetBedDefinition_Input
        {
            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<ResBed.GetBedDefinition_Class> GetBedDefinition(GetBedDefinition_Input input)
        {
            var ret = ResBed.GetBedDefinition(input.injectionSQL);
            return ret;
        }

        [HttpPost]
        public BindingList<ResBed.GetEmptyBedsWithoutIntensiveCare_Class> GetEmptyBedsWithoutIntensiveCare()
        {
            var ret = ResBed.GetEmptyBedsWithoutIntensiveCare();
            return ret;
        }

        [HttpPost]
        public BindingList<ResBed.OLAP_GetResBed_Class> OLAP_GetResBed()
        {
            var ret = ResBed.OLAP_GetResBed();
            return ret;
        }

        [HttpPost]
        public BindingList<ResBed> GetWithNullUsedBy()
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = ResBed.GetWithNullUsedBy(objectContext);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetEmptyBedCountByClinic_Input
        {
            public Guid WARD
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<ResBed.GetEmptyBedCountByClinic_Class> GetEmptyBedCountByClinic(GetEmptyBedCountByClinic_Input input)
        {
            var ret = ResBed.GetEmptyBedCountByClinic(input.WARD);
            return ret;
        }

        public class GetBedCountByClinic_Input
        {
            public Guid WARD
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<ResBed.GetBedCountByClinic_Class> GetBedCountByClinic(GetBedCountByClinic_Input input)
        {
            var ret = ResBed.GetBedCountByClinic(input.WARD);
            return ret;
        }

        [HttpPost]
        public BindingList<ResBed.GetUsedBedCount_Class> GetUsedBedCount()
        {
            var ret = ResBed.GetUsedBedCount();
            return ret;
        }

        public class GetBedsByClinic_Input
        {
            public Guid WARD
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<ResBed.GetBedsByClinic_Class> GetBedsByClinic(GetBedsByClinic_Input input)
        {
            var ret = ResBed.GetBedsByClinic(input.WARD);
            return ret;
        }

        [HttpPost]
        public BindingList<ResBed.GetEmptyBedCount_Class> GetEmptyBedCount()
        {
            var ret = ResBed.GetEmptyBedCount();
            return ret;
        }

        public class GetBedsPropertysByResWard_Input
        {
            public bool ONLYEMPTY
            {
                get;
                set;
            }

            public Guid SELECTEDWARD
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<ResBed.GetBedsPropertysByResWard_Class> GetBedsPropertysByResWard(GetBedsPropertysByResWard_Input input)
        {
            var ret = ResBed.GetBedsPropertysByResWard(input.ONLYEMPTY, input.SELECTEDWARD);
            return ret;
        }

        [HttpPost]
        public BindingList<ResBed.OLAP_NewBedQuery_Class> OLAP_NewBedQuery()
        {
            var ret = ResBed.OLAP_NewBedQuery();
            return ret;
        }

        [HttpPost]
        public BindingList<ResBed.GetAllClinicsEmptybedCounts_Class> GetAllClinicsEmptybedCounts()
        {
            var ret = ResBed.GetAllClinicsEmptybedCounts();
            return ret;
        }

        [HttpPost]
        public BindingList<ResBed.GetAllClinicsBeds_Class> GetAllClinicsBeds()
        {
            var ret = ResBed.GetAllClinicsBeds();
            return ret;
        }

        [HttpPost]
        public BindingList<ResBed.GetEmptyBedsWithVentilator_Class> GetEmptyBedsWithVentilator()
        {
            var ret = ResBed.GetEmptyBedsWithVentilator();
            return ret;
        }

        [HttpPost]
        public BindingList<ResBed.GetAllBedsWithVentilator_Class> GetAllBedsWithVentilator()
        {
            var ret = ResBed.GetAllBedsWithVentilator();
            return ret;
        }

        [HttpPost]
        public BindingList<ResBed.GetAllBedsKuvez_Class> GetAllBedsKuvez()
        {
            var ret = ResBed.GetAllBedsKuvez();
            return ret;
        }

        [HttpPost]
        public BindingList<ResBed.GetEmptyBedsKuvez_Class> GetEmptyBedsKuvez()
        {
            var ret = ResBed.GetEmptyBedsKuvez();
            return ret;
        }

        [HttpPost]
        public BindingList<ResBed.GetAllResBeds_Class> GetAllResBeds()
        {
            var ret = ResBed.GetAllResBeds();
            return ret;
        }

        public class GetBedDef_Input
        {
            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<ResBed.GetBedDef_Class> GetBedDef(GetBedDef_Input input)
        {
            var ret = ResBed.GetBedDef(input.injectionSQL);
            return ret;
        }

        public class GetAllResBedByResWard_Input
        {
            public Guid SELECTEDWARD
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<ResBed.GetAllResBedByResWard_Class> GetAllResBedByResWard(GetAllResBedByResWard_Input input)
        {
            var ret = ResBed.GetAllResBedByResWard(input.SELECTEDWARD);
            return ret;
        }

        public class GetEmptyBedsByResWard_Input
        {
            public Guid SELECTEDWARD
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<ResBed.GetEmptyBedsByResWard_Class> GetEmptyBedsByResWard(GetEmptyBedsByResWard_Input input)
        {
            var ret = ResBed.GetEmptyBedsByResWard(input.SELECTEDWARD);
            return ret;
        }

        public class GetUsedBedsByClinic_Input
        {
            public Guid WARD
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<ResBed> GetUsedBedsByClinic(GetUsedBedsByClinic_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = ResBed.GetUsedBedsByClinic(objectContext, input.WARD);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        [HttpPost]
        public BindingList<ResBed.GetAllWardsEmptyBedCounts_Class> GetAllWardsEmptyBedCounts()
        {
            var ret = ResBed.GetAllWardsEmptyBedCounts();
            return ret;
        }

        [HttpPost]
        public BindingList<ResBed.VEM_YATAK_Class> VEM_YATAK()
        {
            var ret = ResBed.VEM_YATAK();
            return ret;
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Yatak_Secimi)]
        public BindingList<ResBed.GetResWardListWithEmtyBedCount_Class> GetResWardListWithEmtyBedCount()
        {
            var ret = ResBed.GetResWardListWithEmtyBedCount();
            return ret;
        }
    }
}
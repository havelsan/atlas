using Core.Models;
using Infrastructure.Constants;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using TTObjectClasses;

namespace Core.Services
{
    public class ResourceService
    {
        private readonly IMemoryCache _memoryCache;

        public ResourceService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        private DoctorList GetDoctorListInternal()
        {
            var resDoctorList = ResUser.OLAP_GetResDoctor().Select(r => new DoctorDto()
            {
                ObjectID = r.ObjectID ?? Guid.Empty,
                ID = r.ID ?? 0,
                Name = r.Name
            }).OrderBy(r => r.Name);

            var doctorList = new DoctorList(resDoctorList);
            return doctorList;
        }

        public DoctorList GetDoctorList()
        {
            if (_memoryCache.TryGetValue(CacheKeys.DoctorList, out DoctorList cachedDoctorList))
            {
                return cachedDoctorList;
            }

            var doctorList = GetDoctorListInternal();

            _memoryCache.Set(CacheKeys.DoctorList, doctorList, TimeSpan.FromMinutes(10));
            return doctorList;
        }

        public DoctorList GetDoctorList(DataSourceParams dataSourceParams)
        {
            var fullDoctorList = GetDoctorList();
            var searchValue = dataSourceParams.SearchValue;
            if (string.IsNullOrWhiteSpace(searchValue))
                return fullDoctorList;
            var query = from p in fullDoctorList.Doctors
                        where p.Name.StartsWith(searchValue)
                        select p;

            IEnumerable<DoctorDto> filteredList = query;
            if (dataSourceParams.Skip.HasValue && dataSourceParams.Take.HasValue)
            {
                filteredList = query.Skip(dataSourceParams.Skip.Value).Take(dataSourceParams.Take.Value);
            }

            if (string.IsNullOrWhiteSpace(dataSourceParams.Sort) == false)
            {
                Func<DoctorDto, string> orderByFunc = null;
                if (dataSourceParams.Sort == nameof(DoctorDto.Name))
                    orderByFunc = item => item.Name;
                if (orderByFunc != null)
                {
                    filteredList = filteredList.OrderBy(orderByFunc);
                }
            }
            var procedureList = new DoctorList(filteredList);
            return procedureList;
        }


        private SpecialityList GetSpecialityListInternal()
        {
            var resDcotorList = SpecialityDefinition.GetAllSpecialityDefinition(string.Empty).Select(r => new SpecialityDto()
            {
                ObjectID = r.ObjectID ?? Guid.Empty,
                Code = r.Code,
                Name = r.Name
            }).OrderBy(r => r.Name);

            var SpecialityList = new SpecialityList(resDcotorList);
            return SpecialityList;
        }

        public SpecialityList GetSpecialityList()
        {
            if (_memoryCache.TryGetValue(CacheKeys.SpecialityList, out SpecialityList cachedSpecialityList))
            {
                return cachedSpecialityList;
            }

            var SpecialityList = GetSpecialityListInternal();

            _memoryCache.Set(CacheKeys.SpecialityList, SpecialityList, TimeSpan.FromMinutes(10));
            return SpecialityList;
        }

        public SpecialityList GetSpecialityList(DataSourceParams dataSourceParams)
        {
            var fullSpecialityList = GetSpecialityList();
            var searchValue = dataSourceParams.SearchValue;
            if (string.IsNullOrWhiteSpace(searchValue))
                return fullSpecialityList;
            var query = from p in fullSpecialityList.Specialities
                        where p.Name.StartsWith(searchValue)
                        select p;

            IEnumerable<SpecialityDto> filteredList = query;
            if (dataSourceParams.Skip.HasValue && dataSourceParams.Take.HasValue)
            {
                filteredList = query.Skip(dataSourceParams.Skip.Value).Take(dataSourceParams.Take.Value);
            }

            if (string.IsNullOrWhiteSpace(dataSourceParams.Sort) == false)
            {
                Func<SpecialityDto, string> orderByFunc = null;
                if (dataSourceParams.Sort == nameof(SpecialityDto.Name))
                    orderByFunc = item => item.Name;
                if (orderByFunc != null)
                {
                    filteredList = filteredList.OrderBy(orderByFunc);
                }
            }
            var procedureList = new SpecialityList(filteredList);
            return procedureList;
        }


        /////////////////////////////////////
    }
}

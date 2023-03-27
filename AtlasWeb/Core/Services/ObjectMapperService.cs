using AutoMapper;
using System;


namespace Core.Services
{
    public class ObjectMapperService
    {
        private MapperConfiguration _config;
        private MapperConfiguration MapperConfig
        {
            get
            {
                if (_config == null)
                    _config = new MapperConfiguration(cfg =>
                    {
                    }

                    );
                return _config;
            }
        }

        public TDestination Map<TSource, TDestination>(TSource sourceObject)
        {
            var mapResult = Map(sourceObject, typeof (TSource), typeof (TDestination));
            return (TDestination)mapResult;
        }

        public object Map(object sourceObject, object destinationObject)
        {
            var sourceType = sourceObject.GetType();
            var destinationType = destinationObject.GetType();
            var mapResult = Map(sourceObject, sourceType, destinationType);
            return mapResult;
        }

        public object Map(object sourceObject, Type sourceType, Type destinationType)
        {
            var typeMap = MapperConfig.ResolveTypeMap(sourceType, destinationType);
            var mapper = MapperConfig.CreateMapper();
            var mapResult = mapper.Map(sourceObject, sourceType, destinationType);
            return mapResult;
        }
    }
}
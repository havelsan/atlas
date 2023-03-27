using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Infrastructure.Helpers
{
    public sealed class DependencyResolver
    {
        private static readonly Lazy<DependencyResolver> lazy = new Lazy<DependencyResolver>(() => new DependencyResolver());
        public static DependencyResolver Current
        {
            get
            {
                return lazy.Value;
            }
        }

        private DependencyResolver()
        {
        }

        public void SetHttpContextAccessor(IHttpContextAccessor httpContextAccessor)
        {
            this._httpContextAccessor = httpContextAccessor;
        }

        private IHttpContextAccessor _httpContextAccessor;
        public IHttpContextAccessor HttpContextAccessor
        {
            get
            {
                return this._httpContextAccessor;
            }
        }

        private IServiceCollection _services;
        public IServiceCollection Services
        {
            get
            {
                return this._services;
            }

            set
            {
                this._services = value;
            }
        }

        public TService GetService<TService>() where TService : class
        {
            var query =
                from service in this._services
                where service.ServiceType == typeof(TService)
                select service;
            return query.FirstOrDefault() as TService;
        }
    }
}
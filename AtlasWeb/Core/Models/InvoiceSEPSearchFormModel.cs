using System;
using System.Collections.Generic;
using System.Linq;
using TTDataDictionary;
using TTObjectClasses;
using Core.Models;

namespace Core.Models
{
    public class InvoiceSEPSearchFormModel
    {
        public SubEpisodeProtocol.InvoiceSEPSearchCriteria InvoiceSEPSearchCriteria
        {
            get;
            set;
        }

        public InvoiceSEPSearchFormModel()
        {
            this.InvoiceSEPSearchCriteria = new SubEpisodeProtocol.InvoiceSEPSearchCriteria();
        }
    }

    public class InvoiceSearchResultModel
    {
        public LoadResult EpisodeResultList
        {
            get;
            set;
        }

        public LoadResult SEPResultList
        {
            get;
            set;
        }
    }

}
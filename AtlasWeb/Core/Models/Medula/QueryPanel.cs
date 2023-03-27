using System;
using System.Collections.Generic;

namespace Core.Models.Medula
{
    public class QueryPanel : BaseModel
    {
        public DateTime? subEpisodeFDate
        {
            get;
            set;
        }

        public DateTime? subEpisodeLDate
        {
            get;
            set;
        }

        public DateTime? entranceFDate
        {
            get;
            set;
        }

        public DateTime? entranceLDate
        {
            get;
            set;
        }

        public DateTime? leaveFDate
        {
            get;
            set;
        }

        public DateTime? leaveLDate
        {
            get;
            set;
        }

        public int ? episodeState
        {
            get;
            set;
        }
    }
}
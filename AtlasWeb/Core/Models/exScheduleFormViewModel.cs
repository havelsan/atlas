using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace Core.Models
{
    public class exScheduleFormViewModel
    {
        public DateTime dtDate
        {
            get;
            set;
        }

        public DateTime dtStartTime
        {
            get;
            set;
        }

        public DateTime dtEndTime
        {
            get;
            set;
        }

        public Int32 timePeriod
        {
            get;
            set;
        }

        public Int32 Number
        {
            get;
            set;
        }

        public string Note
        {
            get;
            set;
        }

        public bool weeklyPlan
        {
            get;
            set;
        }

        public bool weekendIncluded
        {
            get;
            set;
        }

        public DateTime dtStartDate
        {
            get;
            set;
        }

        public DateTime dtEndDate
        {
            get;
            set;
        }

        public string RepeatNote
        {
            get;
            set;
        }

        public List<AppoitmentDVO> Appoitmentlist
        {
            get;
            set;
        }

        public List<MHRSActionTypeDefinition> MHRSActionlist
        {
            get;
            set;
        }
    }

    public class AppoitmentDVO
    {
        public AppointmentDefinition appointmentDefinition
        {
            get;
            set;
        }

        public List<exAppointmentCarrierDVO> AppointmentCarrieries
        {
            get;
            set;
        }
    }

    public class exAppointmentCarrierDVO
    {
        public AppointmentCarrier appointmentCarrier
        {
            get;
            set;
        }

        public List<exCarrierMasterResourceDVO> MasterResource
        {
            get;
            set;
        }
    }

    public class exCarrierMasterResourceDVO
    {
        public ResSection MasterResource
        {
            get;
            set;
        }

        public List<Resource> resource
        {
            get;
            set;
        }
    }

    public class exScheduleInputDVO
    {
        public AppoitmentDVO AppoitmentDVO
        {
            get;
            set;
        }

        public AppointmentCarrierDVO AppointmentCarrierDVO
        {
            get;
            set;
        }

        public exCarrierMasterResourceDVO CarrierMasterResourceDVO
        {
            get;
            set;
        }

        public Resource res
        {
            get;
            set;
        }

        public DateTime dtDate
        {
            get;
            set;
        }

        public DateTime dtStartTime
        {
            get;
            set;
        }

        public DateTime dtEndTime
        {
            get;
            set;
        }

        public Int32 timePeriod
        {
            get;
            set;
        }

        public Int32 Number
        {
            get;
            set;
        }

        public string Note
        {
            get;
            set;
        }

        public bool weeklyPlan
        {
            get;
            set;
        }

        public bool weekendIncluded
        {
            get;
            set;
        }

        public DateTime dtStartDate
        {
            get;
            set;
        }

        public DateTime dtEndDate
        {
            get;
            set;
        }

        public string RepeatNote
        {
            get;
            set;
        }
    }
}
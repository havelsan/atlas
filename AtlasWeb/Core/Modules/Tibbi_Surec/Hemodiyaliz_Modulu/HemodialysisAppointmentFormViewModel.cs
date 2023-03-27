//$FD74F936
using System;
using System.Linq;
using Core.Models;
using Infrastructure.Filters;
using Infrastructure.Models;
using TTInstanceManagement;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace Core.Controllers
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public partial class HemodialysisAppointmentServiceController
    {
        [HttpGet]
        public HemodialysisAppointmentFormViewModel HemodialysisAppointmentForm()
        {
            var viewModel = new HemodialysisAppointmentFormViewModel();
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._hemodialysisSearchCriteria = new HemodialysisSearchCriteria();
                viewModel._hemodialysisSearchCriteria.HemodialysisState = new List<EpisodeActionWorkListStateItem>();

                viewModel.SKRSDiyalizeGirmeSikligiList = SKRSDiyalizeGirmeSikligi.GetSKRSDiyalizeGirmeSikligiObj(objectContext, "WHERE AKTIF=1").ToList();
                viewModel.PackageProcedureList = PackageProcedureDefinition.GetDialysisPackageProcedureObj(objectContext, "").ToList();

                viewModel.TreatmentEquipmentList = new List<ResEquipment>();
                var equipmentList = ResEquipment.GetHemodialysisResEquipment(objectContext);
                foreach (var equipment in equipmentList)
                {
                    ResEquipment resEquipment = objectContext.GetObject(equipment.ObjectID.Value, equipment.ObjectDefID.Value) as ResEquipment;
                    viewModel.TreatmentEquipmentList.Add(resEquipment);
                }

                objectContext.FullPartialllyLoadedObjects();

                return viewModel;
            }
        }

        [HttpPost]
        public List<HemodialysisAppointmentItem> GetHemodialysisAppointmentItem(HemodialysisSearchCriteria criteria)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                List<HemodialysisAppointmentItem> _HemodialysisAppointmentItemList = new List<HemodialysisAppointmentItem>();
                string whereCriteria = "";
                if (criteria != null)
                {
                    if (criteria.HemodialysisState.Count() > 0)
                    {
                        System.Text.StringBuilder _tempString = new System.Text.StringBuilder();
                        _tempString.Append(" AND CURRENTSTATEDEFID IN (");
                        string comma = "";
                        foreach (var state in criteria.HemodialysisState)
                        {
                            _tempString.Append(comma);
                            _tempString.Append("'" + state.StateDefID + "'");
                            comma = ",";
                        }
                        _tempString.Append(") ");
                        whereCriteria += _tempString.ToString();
                    }
                }

                BindingList<HemodialysisOrder.GetHemodialysisOrderList_Class> orderList = HemodialysisOrder.GetHemodialysisOrderList(whereCriteria);
                foreach (var orderItem in orderList)
                {
                    HemodialysisAppointmentItem _hemodialysisAppointmentItem = new HemodialysisAppointmentItem
                    {
                        ObjectID = orderItem.ObjectID.Value,
                        ObjectDefID = orderItem.ObjectDefID.Value,
                        ObjectDefName = orderItem.ObjectDefName,
                        PatientNameSurname = orderItem.Patientname + " " + orderItem.Patientsurname,
                        AdmissionNumber = orderItem.ProtocolNo,
                        HemodialysisStateName = orderItem.Currentstate,
                        TreatmentStartDateTime = orderItem.TreatmentStartDateTime.Value
                    };
                    _HemodialysisAppointmentItemList.Add(_hemodialysisAppointmentItem);
                }
                return _HemodialysisAppointmentItemList;
            }
        }

        public HemodialysisAppointmentFormViewModel GetHemodialysisObject(Guid ObjectID, Guid ObjectDefID)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                HemodialysisOrder hemodialysisOrder = objectContext.GetObject(ObjectID, ObjectDefID) as HemodialysisOrder;

                HemodialysisAppointmentFormViewModel viewModel = new HemodialysisAppointmentFormViewModel();
                viewModel._HemodialysisOrder = hemodialysisOrder;

                viewModel._Appointment = new Appointment(objectContext);

                viewModel._Appointment.AppDate = hemodialysisOrder.TreatmentStartDateTime;
                viewModel._Appointment.Resource = hemodialysisOrder.TreatmentEquipment;
                viewModel._Appointment.MasterResource = hemodialysisOrder.MasterResource;

                return viewModel;
            }
        }


        public void CreateOrderDetailAndAppointment(HemodialysisAppointmentFormViewModel viewModel)
        {

            try
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    var hemodialysisOrder = objectContext.GetObject(viewModel._HemodialysisOrder.ObjectID, viewModel._HemodialysisOrder.ObjectDef) as HemodialysisOrder;
                    if (hemodialysisOrder.IsOldAction != true)
                    {
                        int j = 1;// Convert.ToInt32(hemodialysisOrder.Amount);
                        int i = 0;
                        int k = 0;


                        while (i < j)
                        {
                            DateTime treatmentStartDateTime = viewModel._Appointment.AppDate.Value.Date.AddHours(viewModel._Appointment.StartTime.Value.Hour); //hemodialysisOrder.TreatmentStartDateTime.Value;
                            DateTime workListDate = treatmentStartDateTime.AddDays(k);
                            bool bayramMi = false;
                            if (workListDate.DayOfWeek != DayOfWeek.Saturday && workListDate.DayOfWeek != DayOfWeek.Sunday)
                            {
                                BindingList<WorkDayExceptionDef.GetWorkDayExcesptionsQuery_Class> holidayList = TTObjectClasses.WorkDayExceptionDef.GetWorkDayExcesptionsQuery();
                                foreach (WorkDayExceptionDef.GetWorkDayExcesptionsQuery_Class item in holidayList)
                                {
                                    if (item.Date != null)
                                    {
                                        if (item.Date.Value.Date == workListDate.Date)
                                            bayramMi = true;
                                    }
                                }
                                if (!bayramMi)
                                {
                                    SubactionProcedureFlowable orderDetail = hemodialysisOrder.CreateOrderDetail();
                                    orderDetail.ActionDate = Common.RecTime();
                                    orderDetail.MasterResource = (ResSection)hemodialysisOrder.MasterResource;
                                    orderDetail.FromResource = (ResSection)hemodialysisOrder.FromResource;
                                    orderDetail.Episode = hemodialysisOrder.Episode;
                                    orderDetail.ProcedureObject = hemodialysisOrder.ProcedureObject;
                                    orderDetail.Amount = 1;
                                    BindingList<TTObjectStateDef> states = (BindingList<TTObjectStateDef>)((ITTObject)orderDetail).GetNextStateDefs();
                                    if (states.Count > 0)
                                    {
                                        orderDetail.CurrentStateDef = (TTObjectStateDef)states[0];
                                    }
                                    orderDetail.OrderObject = hemodialysisOrder;
                                    orderDetail.EpisodeAction = (EpisodeAction)hemodialysisOrder.MasterAction;
                                    orderDetail.WorkListDate = workListDate;
                                    orderDetail.PricingDate = orderDetail.WorkListDate;
                                    hemodialysisOrder.CreateAppointmentForOrderDetail(orderDetail);
                                    i++;
                                }
                            }
                            k++;
                        }
                        objectContext.Save();
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public GivenHemodialysisAppointmentDVO GetGivenHemodialysisAppointmentDVO(GivenAppointment givenAppointment)
        {
            try
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    Appointment appointment = objectContext.GetObject(new Guid(givenAppointment.objectID), new Guid(givenAppointment.objectDefID)) as Appointment;
                    HemodialysisOrderDetail orderDetail = objectContext.GetObject(appointment.SubActionProcedure.ObjectID, appointment.SubActionProcedure.ObjectDef) as HemodialysisOrderDetail;
                    //HemodialysisOrder order = orderDetail.HemodialysisOrder; //objectContext.get(orderDetail.HemodialysisOrder.ObjectID, orderDetail.HemodialysisOrder.ObjectDef) as HemodialysisOrder;

                    GivenHemodialysisAppointmentDVO _GivenHemodialysisAppointmentDVO = new GivenHemodialysisAppointmentDVO();
                    _GivenHemodialysisAppointmentDVO.hemodialysisOrderObjectId = orderDetail.HemodialysisOrder.ObjectID;
                    _GivenHemodialysisAppointmentDVO._Appointment = appointment;

                    return _GivenHemodialysisAppointmentDVO;
                }
            }
            catch
            {
                throw;
            }
        }

        public void UpdateOrderDetailAndAppointment(GivenHemodialysisAppointmentDVO givenHemodialysisAppointmentDVO)
        {
            try
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    Appointment appointment = objectContext.GetObject(givenHemodialysisAppointmentDVO._Appointment.ObjectID, givenHemodialysisAppointmentDVO._Appointment.ObjectDef) as Appointment;
                    HemodialysisOrderDetail orderDetail = objectContext.GetObject(appointment.SubActionProcedure.ObjectID, appointment.SubActionProcedure.ObjectDef) as HemodialysisOrderDetail;

                    appointment.AppDate = givenHemodialysisAppointmentDVO._Appointment.AppDate;
                    appointment.StartTime = givenHemodialysisAppointmentDVO._Appointment.StartTime;
                    appointment.EndTime = givenHemodialysisAppointmentDVO._Appointment.EndTime;
                    orderDetail.PricingDate = givenHemodialysisAppointmentDVO._Appointment.AppDate;
                    orderDetail.SessionDate = givenHemodialysisAppointmentDVO._Appointment.AppDate;
                    orderDetail.SessionStartTime = appointment.StartTime;
                    orderDetail.SessionFinishTime = appointment.EndTime;
                    objectContext.Save();
                }
            }
            catch
            {
                throw;
            }
        }

        public void CancelOrderDetailAndAppointment(GivenAppointment givenAppointment)
        {
            try
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    Appointment appointment = objectContext.GetObject(new Guid(givenAppointment.objectID), new Guid(givenAppointment.objectDefID)) as Appointment;
                    appointment.CurrentStateDefID = Appointment.States.Cancelled;
                    HemodialysisOrderDetail orderDetail = objectContext.GetObject(appointment.SubActionProcedure.ObjectID, appointment.SubActionProcedure.ObjectDef) as HemodialysisOrderDetail;
                    orderDetail.CurrentStateDefID = HemodialysisOrderDetail.States.Cancelled;

                    objectContext.Save();
                }
            }
            catch
            {
                throw;
            }
        }
    }
}

namespace Core.Models
{
    public partial class HemodialysisAppointmentFormViewModel : BaseViewModel
    {
        public List<EpisodeActionWorkListStateItem> HemodialysisStateItems { get; set; }
        public List<HemodialysisAppointmentItem> HemodialysisAppointmentItemList { get; set; }
        public HemodialysisSearchCriteria _hemodialysisSearchCriteria { get; set; }

        public HemodialysisOrder _HemodialysisOrder { get; set; }

        public Appointment _Appointment { get; set; }

        public GivenHemodialysisAppointmentDVO _GivenHemodialysisAppointmentDVO { get; set; }

        public GivenAppointment selectedAppointmentSchedule { get; set; }

        public GivenAppointment _myOldAppointment { get; set; }

        public List<SKRSDiyalizeGirmeSikligi> SKRSDiyalizeGirmeSikligiList { get; set; }
        public List<PackageProcedureDefinition> PackageProcedureList { get; set; }
        public List<ResEquipment> TreatmentEquipmentList { get; set; }
    }

    public class HemodialysisSearchCriteria
    {
        public List<EpisodeActionWorkListStateItem> HemodialysisState { get; set; }
    }
    public class HemodialysisAppointmentItem
    {
        public Guid ObjectID { get; set; }
        public Guid ObjectDefID { get; set; }
        public string ObjectDefName { get; set; }


        public string PatientNameSurname { get; set; }//Hasta Adý Soyadý
        public string AdmissionNumber { get; set; }//Kabul No
        public string HemodialysisStateName { get; set; }

        public DateTime TreatmentStartDateTime { get; set; }

        //public SKRSDiyalizeGirmeSikligi DialysisFrequency { get; set; }
        //public int Duration { get; set; }
        //public bool Emergency { get; set; }
        //public string Information { get; set; }
        //public bool IsWeekendInclude { get; set; }
        //public PackageProcedureDefinition PackageProcedure { get; set; }
        //public int SessionCount { get; set; }
        //public int SessionDayRange { get; set; }
        //public PeriodUnitTypeEnum SessionDayRangeType { get; set; }
        //public ResEquipment TreatmentEquipment { get; set; }
    }

    public class GivenHemodialysisAppointmentDVO
    {
        public Guid hemodialysisOrderObjectId { get; set; }
        public Appointment _Appointment { get; set; }
    }
}

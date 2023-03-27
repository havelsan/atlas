
using System;
using System.Xml;
using System.Data;
using System.Text;
using System.Drawing;
using System.Reflection;
using System.Collections;
using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;

using TTUtils;
using TTObjectClasses;
using TTDataDictionary;
using TTCoreDefinitions;
using TTConnectionManager;
using TTInstanceManagement;
using TTDefinitionManagement;
using TTStorageManager.Security;



using TTStorageManager;
using System.Runtime.Versioning;


namespace TTObjectClasses
{
    /// <summary>
    /// Fizyoterapi Tatil Günleri OrderDetail Tarihi Değiştirme
    /// </summary>
    public partial class UpdatePhyOrderDetailDate : BaseScheduledTask
    {
        public override void TaskScript()
        {
            TTObjectContext roObjectContext = new TTObjectContext(true);

            BindingList<WorkDayExceptionDef.GetWorkDayExceptionDefs_Class> workDayExceptionList = WorkDayExceptionDef.GetWorkDayExceptionDefs("");//GetActiveWorkDayExceptionDefs
            if (workDayExceptionList.Count > 0)
            {
                foreach (var workDayException in workDayExceptionList)
                {
                    if (workDayException.Date != null)
                    {
                        BindingList<PhysiotherapyOrderDetail.GetPhysiotherapyOrderDetailByDate_Class> physiotherapyOrderDetailList = PhysiotherapyOrderDetail.GetPhysiotherapyOrderDetailByDate(roObjectContext, workDayException.Date.Value);

                        TTObjectContext objectContext = new TTObjectContext(false);

                        if (physiotherapyOrderDetailList.Count > 0)
                        {
                            foreach (var physiotherapyOrderDetail in physiotherapyOrderDetailList)
                            {
                                try
                                {
                                    #region Hesaplama

                                    PhysiotherapyRequest request = objectContext.GetObject(physiotherapyOrderDetail.ObjectID.Value, typeof(PhysiotherapyRequest)) as PhysiotherapyRequest;

                                    DateTime _plannedDate = new DateTime();

                                    foreach (var orderDetail in request.PhysiotherapyOrderDetails.Where(c => c.PlannedDate.Value.Date == workDayException.Date.Value.Date && c.CurrentStateDefID != PhysiotherapyOrderDetail.States.Cancelled))
                                    {
                                        if (orderDetail.PhysiotherapyOrder != null)
                                        {

                                            var lastOrderDetail = orderDetail.PhysiotherapyOrder.PhysiotherapyOrderDetails.Where(x => x.CurrentStateDefID != PhysiotherapyOrderDetail.States.Cancelled).OrderByDescending(c => c.PlannedDate).FirstOrDefault();//iptal olmamış seanslar arasında en son planlanan seans

                                            _plannedDate = lastOrderDetail.PlannedDate.Value;
                                            if (orderDetail.PhysiotherapyOrder.SeansGunSayisi != null && orderDetail.PhysiotherapyOrder.SeansGunSayisi > 0)
                                            {
                                                _plannedDate = _plannedDate.AddDays(orderDetail.PhysiotherapyOrder.SeansGunSayisi.Value);
                                            }
                                            else
                                            {
                                                _plannedDate = _plannedDate.AddDays(1);
                                            }


                                            if (orderDetail.PhysiotherapyOrder.SeansGunSayisi != 0)//Gün seçimi olmadan seans gün aralığı kullanarak planlama
                                            {
                                                if (orderDetail.PhysiotherapyOrder.IncludeSaturday != true && orderDetail.PhysiotherapyOrder.IncludeSunday != true)//Haftasonu (Cts-Pazar) Dahil Değil 
                                                {
                                                    if (_plannedDate.DayOfWeek == DayOfWeek.Saturday)//planlanan gün cts ise
                                                    {
                                                        _plannedDate = _plannedDate.AddDays(1);
                                                    }
                                                    if (_plannedDate.DayOfWeek == DayOfWeek.Sunday)//planlanan gün pazar ise
                                                    {
                                                        _plannedDate = _plannedDate.AddDays(1);
                                                    }
                                                    orderDetail.PlannedDate = _plannedDate;
                                                    //_plannedDate = _plannedDate.AddDays(orderDetail.PhysiotherapyOrder.SeansGunSayisi.Value);
                                                }
                                                else
                                                {
                                                    if (orderDetail.PhysiotherapyOrder.IncludeSaturday != true)//Cumartesi Dahil Değil ise
                                                    {
                                                        if (_plannedDate.DayOfWeek == DayOfWeek.Saturday)//planlanan gün cts ise
                                                        {
                                                            _plannedDate = _plannedDate.AddDays(1);
                                                        }
                                                        orderDetail.PlannedDate = _plannedDate;
                                                        //_plannedDate = _plannedDate.AddDays(orderDetail.PhysiotherapyOrder.SeansGunSayisi.Value);
                                                    }
                                                    else if (orderDetail.PhysiotherapyOrder.IncludeSunday != true)//Pazar Dahil Değil ise
                                                    {
                                                        if (_plannedDate.DayOfWeek == DayOfWeek.Sunday)//planlanan gün pazar ise
                                                        {
                                                            _plannedDate = _plannedDate.AddDays(1);
                                                        }
                                                        orderDetail.PlannedDate = _plannedDate;
                                                        //_plannedDate = _plannedDate.AddDays(orderDetail.PhysiotherapyOrder.SeansGunSayisi.Value);
                                                    }
                                                    else//Haftasonu Dahil
                                                    {
                                                        orderDetail.PlannedDate = _plannedDate;
                                                        //_plannedDate = _plannedDate.AddDays(orderDetail.PhysiotherapyOrder.SeansGunSayisi.Value);
                                                    }
                                                }
                                            }
                                            else//Gün seçimi kullanarak planlama
                                            {
                                                bool isDateConflict = false;//gün eşleşmesi sağlanana kadar bir sonraki güne geçiliyor.
                                                while (!isDateConflict)
                                                {
                                                    if (orderDetail.PhysiotherapyOrder.IncludeMonday == true)//Pazartesi
                                                    {
                                                        if (_plannedDate.DayOfWeek == DayOfWeek.Monday)
                                                        {
                                                            orderDetail.PlannedDate = _plannedDate;
                                                            isDateConflict = true;
                                                        }
                                                    }
                                                    if (orderDetail.PhysiotherapyOrder.IncludeTuesday == true)//Salı
                                                    {
                                                        if (_plannedDate.DayOfWeek == DayOfWeek.Tuesday)
                                                        {
                                                            orderDetail.PlannedDate = _plannedDate;
                                                            isDateConflict = true;
                                                        }
                                                    }
                                                    if (orderDetail.PhysiotherapyOrder.IncludeWednesday == true)//Çarşamba
                                                    {
                                                        if (_plannedDate.DayOfWeek == DayOfWeek.Wednesday)
                                                        {
                                                            orderDetail.PlannedDate = _plannedDate;
                                                            isDateConflict = true;
                                                        }
                                                    }
                                                    if (orderDetail.PhysiotherapyOrder.IncludeThursday == true)//Perşembe
                                                    {
                                                        if (_plannedDate.DayOfWeek == DayOfWeek.Thursday)
                                                        {
                                                            orderDetail.PlannedDate = _plannedDate;
                                                            isDateConflict = true;
                                                        }
                                                    }
                                                    if (orderDetail.PhysiotherapyOrder.IncludeFriday == true)//Cuma
                                                    {
                                                        if (_plannedDate.DayOfWeek == DayOfWeek.Friday)
                                                        {
                                                            orderDetail.PlannedDate = _plannedDate;
                                                            isDateConflict = true;
                                                        }
                                                    }
                                                    if (orderDetail.PhysiotherapyOrder.IncludeSaturday == true)//Cumartesi
                                                    {
                                                        if (_plannedDate.DayOfWeek == DayOfWeek.Saturday)
                                                        {
                                                            orderDetail.PlannedDate = _plannedDate;
                                                            isDateConflict = true;
                                                        }
                                                    }
                                                    if (orderDetail.PhysiotherapyOrder.IncludeSunday == true)//Pazar
                                                    {
                                                        if (_plannedDate.DayOfWeek == DayOfWeek.Sunday)
                                                        {
                                                            orderDetail.PlannedDate = _plannedDate;
                                                            isDateConflict = true;
                                                        }
                                                    }
                                                    _plannedDate = _plannedDate.AddDays(1);
                                                }
                                            }

                                        }
                                    }

                                    #endregion


                                    #region Seans Numaraları tekrar düzenleniyor.
                                    //Ek tedavi olmayan OrderDetail
                                    var groupedOrderDetailList = request.PhysiotherapyOrderDetails.Where(c => c.CurrentStateDefID != PhysiotherapyOrderDetail.States.Cancelled && c.PhysiotherapyOrder != null && c.PhysiotherapyOrder.IsAdditionalTreatment != true);
                                    int count = 1;
                                    foreach (var item in groupedOrderDetailList.OrderBy(c => c.PlannedDate).GroupBy(c => c.PlannedDate.Value.Date))
                                    {
                                        var selectedOrderDetailList = groupedOrderDetailList.Where(x => x.PlannedDate.Value.Date == item.Key.Date);
                                        foreach (var selectedOrderDetail in selectedOrderDetailList)
                                        {
                                            selectedOrderDetail.SessionNumber = count;
                                        }

                                        count++;
                                    }

                                    //Ek tedavi olan OrderDetail
                                    var groupedAdditionalOrderDetailList = request.PhysiotherapyOrderDetails.Where(c => c.CurrentStateDefID != PhysiotherapyOrderDetail.States.Cancelled && c.PhysiotherapyOrder != null && c.PhysiotherapyOrder.IsAdditionalTreatment == true);
                                    int countAdditional = 1;
                                    foreach (var item in groupedAdditionalOrderDetailList.OrderBy(c => c.PlannedDate).GroupBy(c => c.PlannedDate.Value.Date))
                                    {
                                        var selectedOrderDetailList = groupedAdditionalOrderDetailList.Where(x => x.PlannedDate.Value.Date == item.Key.Date);
                                        foreach (var selectedOrderDetail in selectedOrderDetailList)
                                        {
                                            selectedOrderDetail.SessionNumber = countAdditional;
                                        }

                                        countAdditional++;
                                    }
                                    #endregion

                                    objectContext.Save();

                                }
                                catch (Exception)
                                {

                                    throw;
                                }
                            }

                            objectContext.Dispose();
                        }
                    }
                }
            }

            AddLog("Fizyoterapi tatil günlerine denk gelen seansların tarihini değiştirme metodu başarılı tamamlandı. " + Common.RecTime().ToString());
        }

    }
}
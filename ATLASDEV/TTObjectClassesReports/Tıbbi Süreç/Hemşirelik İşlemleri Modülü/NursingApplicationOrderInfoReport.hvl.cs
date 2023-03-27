
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

using TTReportTool;
using TTVisual;
namespace TTReportClasses
{
    public partial class NursingApplicationOrderInfoReport : TTReport
    {
#region Methods
   public class OrderDetail {
            public string orderTupu;
            public string tedavi;
            public string orderTarihi;
            public string durum;
            public string aciklama;
            public string uygulamaSekli;
            public string doz;
            public string T1;
            public string T2;
            public string T3;
            public string T4;
            public string T5;
            public string T6;
            public string T7;
            public string T8;
//            public string T9;
//            public string T10;
//            public string T11;
//            public string T12;
//            public string T13;
//            public string T14;
//            public string T15;

        }
        public int mainCounter = 0;
        public int dateCounter=0;
        public DateTime currentDateTime ;
        Dictionary<DateTime,  List<OrderDetail>> orderDetailsListByDate = new  Dictionary<DateTime,  List<OrderDetail>>();
   
#endregion Methods

        public class ReportRuntimeParameters 
        {
            public Guid? TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
            public DateTime? STARTTIME = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDTIME = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
        }

        public partial class PAGECOUNTHESAPLAGroup : TTReportGroup
        {
            public NursingApplicationOrderInfoReport MyParentReport
            {
                get { return (NursingApplicationOrderInfoReport)ParentReport; }
            }

            new public PAGECOUNTHESAPLAGroupHeader Header()
            {
                return (PAGECOUNTHESAPLAGroupHeader)_header;
            }

            new public PAGECOUNTHESAPLAGroupFooter Footer()
            {
                return (PAGECOUNTHESAPLAGroupFooter)_footer;
            }

            public TTReportField pageCount { get {return Footer().pageCount;} }
            public TTReportField NewField1 { get {return Footer().NewField1;} }
            public TTReportField Date { get {return Footer().Date;} }
            public PAGECOUNTHESAPLAGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PAGECOUNTHESAPLAGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PAGECOUNTHESAPLAGroupHeader(this);
                _footer = new PAGECOUNTHESAPLAGroupFooter(this);

            }

            public partial class PAGECOUNTHESAPLAGroupHeader : TTReportSection
            {
                public NursingApplicationOrderInfoReport MyParentReport
                {
                    get { return (NursingApplicationOrderInfoReport)ParentReport; }
                }
                 
                public PAGECOUNTHESAPLAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 1;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                }
                

                public override void RunScript()
                {
#region PAGECOUNTHESAPLA HEADER_Script
                    DateTime StartTime = (DateTime)MyParentReport.RuntimeParameters.STARTTIME;
                    DateTime EndTime = (DateTime)MyParentReport.RuntimeParameters.ENDTIME;
                    int repeatCount = (int)(EndTime.Date - StartTime.Date).TotalDays + 1;
                    MyParentReport.HASTAINFO.RepeatCount = repeatCount;
#endregion PAGECOUNTHESAPLA HEADER_Script
                }
            }
            public partial class PAGECOUNTHESAPLAGroupFooter : TTReportSection
            {
                public NursingApplicationOrderInfoReport MyParentReport
                {
                    get { return (NursingApplicationOrderInfoReport)ParentReport; }
                }
                
                public TTReportField pageCount;
                public TTReportField NewField1;
                public TTReportField Date; 
                public PAGECOUNTHESAPLAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 7;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    pageCount = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 187, 1, 203, 5, false);
                    pageCount.Name = "pageCount";
                    pageCount.FieldType = ReportFieldTypeEnum.ftVariable;
                    pageCount.TextFormat = @"Short Date";
                    pageCount.TextFont.Size = 9;
                    pageCount.TextFont.CharSet = 162;
                    pageCount.Value = @"{@pagenumber@}";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 1, 35, 5, false);
                    NewField1.Name = "NewField1";
                    NewField1.Visible = EvetHayirEnum.ehHayir;
                    NewField1.TextFont.Size = 9;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"Rapor Basılma Tarihi:";

                    Date = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 1, 61, 5, false);
                    Date.Name = "Date";
                    Date.Visible = EvetHayirEnum.ehHayir;
                    Date.FieldType = ReportFieldTypeEnum.ftExpression;
                    Date.TextFont.Size = 9;
                    Date.TextFont.CharSet = 162;
                    Date.Value = @"DateTime.Now.ToShortDateString() + "" "" + DateTime.Now.ToShortTimeString()";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    pageCount.CalcValue = ParentReport.CurrentPageNumber.ToString();
                    NewField1.CalcValue = NewField1.Value;
                    Date.CalcValue = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
                    return new TTReportObject[] { pageCount,NewField1,Date};
                }
            }

        }

        public PAGECOUNTHESAPLAGroup PAGECOUNTHESAPLA;

        public partial class HASTAINFOGroup : TTReportGroup
        {
            public NursingApplicationOrderInfoReport MyParentReport
            {
                get { return (NursingApplicationOrderInfoReport)ParentReport; }
            }

            new public HASTAINFOGroupHeader Header()
            {
                return (HASTAINFOGroupHeader)_header;
            }

            new public HASTAINFOGroupFooter Footer()
            {
                return (HASTAINFOGroupFooter)_footer;
            }

            public TTReportField ADSOYAD { get {return Header().ADSOYAD;} }
            public TTReportField PROTOKOLNO { get {return Header().PROTOKOLNO;} }
            public TTReportField TARIH { get {return Header().TARIH;} }
            public TTReportField ODAYATAK { get {return Header().ODAYATAK;} }
            public TTReportField SERVIS { get {return Header().SERVIS;} }
            public TTReportField TEDAVISERVIS { get {return Header().TEDAVISERVIS;} }
            public TTReportField DOCTOR { get {return Header().DOCTOR;} }
            public TTReportField LISTCOUNT11 { get {return Header().LISTCOUNT11;} }
            public TTReportField ALLER { get {return Header().ALLER;} }
            public TTReportField LISTCOUNT1 { get {return Footer().LISTCOUNT1;} }
            public TTReportField İmza { get {return Footer().İmza;} }
            public TTReportField İmza1 { get {return Footer().İmza1;} }
            public TTReportField TEDAVİ11 { get {return Footer().TEDAVİ11;} }
            public HASTAINFOGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public HASTAINFOGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new HASTAINFOGroupHeader(this);
                _footer = new HASTAINFOGroupFooter(this);

            }

            public partial class HASTAINFOGroupHeader : TTReportSection
            {
                public NursingApplicationOrderInfoReport MyParentReport
                {
                    get { return (NursingApplicationOrderInfoReport)ParentReport; }
                }
                
                public TTReportField ADSOYAD;
                public TTReportField PROTOKOLNO;
                public TTReportField TARIH;
                public TTReportField ODAYATAK;
                public TTReportField SERVIS;
                public TTReportField TEDAVISERVIS;
                public TTReportField DOCTOR;
                public TTReportField LISTCOUNT11;
                public TTReportField ALLER; 
                public HASTAINFOGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 5;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    ADSOYAD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 7, 97, 12, false);
                    ADSOYAD.Name = "ADSOYAD";
                    ADSOYAD.Visible = EvetHayirEnum.ehHayir;
                    ADSOYAD.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADSOYAD.TextFont.Size = 9;
                    ADSOYAD.TextFont.CharSet = 162;
                    ADSOYAD.Value = @"";

                    PROTOKOLNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 1, 76, 5, false);
                    PROTOKOLNO.Name = "PROTOKOLNO";
                    PROTOKOLNO.Visible = EvetHayirEnum.ehHayir;
                    PROTOKOLNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROTOKOLNO.TextFont.Size = 9;
                    PROTOKOLNO.TextFont.CharSet = 162;
                    PROTOKOLNO.Value = @"";

                    TARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 18, 96, 22, false);
                    TARIH.Name = "TARIH";
                    TARIH.Visible = EvetHayirEnum.ehHayir;
                    TARIH.FieldType = ReportFieldTypeEnum.ftVariable;
                    TARIH.TextFormat = @"dd/MM/yyyy";
                    TARIH.TextFont.Size = 9;
                    TARIH.TextFont.CharSet = 162;
                    TARIH.Value = @"";

                    ODAYATAK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 12, 199, 16, false);
                    ODAYATAK.Name = "ODAYATAK";
                    ODAYATAK.Visible = EvetHayirEnum.ehHayir;
                    ODAYATAK.FieldType = ReportFieldTypeEnum.ftVariable;
                    ODAYATAK.TextFont.Size = 9;
                    ODAYATAK.TextFont.CharSet = 162;
                    ODAYATAK.Value = @"";

                    SERVIS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 7, 199, 11, false);
                    SERVIS.Name = "SERVIS";
                    SERVIS.Visible = EvetHayirEnum.ehHayir;
                    SERVIS.FieldType = ReportFieldTypeEnum.ftVariable;
                    SERVIS.TextFont.Size = 9;
                    SERVIS.TextFont.CharSet = 162;
                    SERVIS.Value = @"";

                    TEDAVISERVIS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 13, 97, 17, false);
                    TEDAVISERVIS.Name = "TEDAVISERVIS";
                    TEDAVISERVIS.Visible = EvetHayirEnum.ehHayir;
                    TEDAVISERVIS.FieldType = ReportFieldTypeEnum.ftVariable;
                    TEDAVISERVIS.TextFont.Size = 9;
                    TEDAVISERVIS.TextFont.CharSet = 162;
                    TEDAVISERVIS.Value = @"";

                    DOCTOR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 17, 199, 21, false);
                    DOCTOR.Name = "DOCTOR";
                    DOCTOR.Visible = EvetHayirEnum.ehHayir;
                    DOCTOR.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOCTOR.TextFormat = @"Short Date";
                    DOCTOR.TextFont.Size = 9;
                    DOCTOR.TextFont.CharSet = 162;
                    DOCTOR.Value = @"";

                    LISTCOUNT11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 1, 30, 5, false);
                    LISTCOUNT11.Name = "LISTCOUNT11";
                    LISTCOUNT11.TextFormat = @"Short Date";
                    LISTCOUNT11.TextFont.Size = 9;
                    LISTCOUNT11.TextFont.CharSet = 162;
                    LISTCOUNT11.Value = @"";

                    ALLER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 46, 29, 105, 33, false);
                    ALLER.Name = "ALLER";
                    ALLER.Visible = EvetHayirEnum.ehHayir;
                    ALLER.FieldType = ReportFieldTypeEnum.ftVariable;
                    ALLER.TextFormat = @"dd/MM/yyyy";
                    ALLER.TextFont.Size = 9;
                    ALLER.TextFont.CharSet = 162;
                    ALLER.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ADSOYAD.CalcValue = @"";
                    PROTOKOLNO.CalcValue = @"";
                    TARIH.CalcValue = @"";
                    ODAYATAK.CalcValue = @"";
                    SERVIS.CalcValue = @"";
                    TEDAVISERVIS.CalcValue = @"";
                    DOCTOR.CalcValue = @"";
                    LISTCOUNT11.CalcValue = LISTCOUNT11.Value;
                    ALLER.CalcValue = @"";
                    return new TTReportObject[] { ADSOYAD,PROTOKOLNO,TARIH,ODAYATAK,SERVIS,TEDAVISERVIS,DOCTOR,LISTCOUNT11,ALLER};
                }
#region HASTAINFO HEADER_Methods
            public static int CreateOrderPeriods(Type t, int count, OrderDetail newOrderDetail, DrugOrderDetail.GetDrugOrderDetailByNursingApp_Class drugOrderDetail)
        {
            DateTime saat = drugOrderDetail.Uygulama_tarihi.Value;
            if (saat != null)
            {
                var saatMinute = saat.Minute.ToString();
                if (saat.Minute < 10)
                    saatMinute = "0" + saatMinute;
                var saatHour = saat.Hour.ToString();
                if (saat.Hour < 10)
                    saatHour = "0" + saatHour;
                var fi = t.GetField("T" + count);
                fi.SetValue(newOrderDetail, saatHour + ":" + saatMinute);
                count++;
            }

            return count;
        }
        
        public bool CreateDrugOrderPeriods(Type t, OrderDetail newOrderDetail, Guid drugOrderID, int startDetailNo, int endDetailNo)
        {
            TTObjectContext context = new TTObjectContext(true);
            DrugOrder drugOrder = ((DrugOrder)context.GetObject((Guid)(drugOrderID), "DrugOrder"));
            int tCount = 1;
            bool find = false;
            foreach (DrugOrderDetail detail in drugOrder.DrugOrderDetails.OrderBy(x=>x.DetailNo))
            {
                if (detail.DetailNo >= startDetailNo && detail.DetailNo <= endDetailNo)
                {
                    DateTime saat = detail.OrderPlannedDate.Value;
                    if (saat != null)
                    {
                        var saatMinute = saat.Minute.ToString();
                        if (saat.Minute < 10)
                            saatMinute = "0" + saatMinute;
                        var saatHour = saat.Hour.ToString();
                        if (saat.Hour < 10)
                            saatHour = "0" + saatHour;
                        var fi = t.GetField("T" + tCount.ToString());
                        if(fi != null)
                            fi.SetValue(newOrderDetail, saatHour + ":" + saatMinute);
                    }
                    tCount++;
                    find = true;
                }
            }
            return find;
        }
#endregion HASTAINFO HEADER_Methods

                public override void RunScript()
                {
#region HASTAINFO HEADER_Script
                    TTObjectContext context = new TTObjectContext(true);

            string sObjectID = ((NursingApplicationOrderInfoReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            NursingApplication nursingApplication = (NursingApplication)context.GetObject(new Guid(sObjectID), "NursingApplication");

            DateTime startTimeParam = (DateTime)((NursingApplicationOrderInfoReport)ParentReport).RuntimeParameters.STARTTIME;
            startTimeParam = new DateTime(startTimeParam.Year, startTimeParam.Month, startTimeParam.Day);

            DateTime endTimeParam = (DateTime)((NursingApplicationOrderInfoReport)ParentReport).RuntimeParameters.ENDTIME;
            endTimeParam = new DateTime(endTimeParam.Year, endTimeParam.Month, endTimeParam.Day, 23, 59, 59);

            List<string> allergy = new List<string>();
            if (nursingApplication.SubEpisode.Episode.Patient.MedicalInformation != null)
            {
                if(nursingApplication.SubEpisode.Episode.Patient.MedicalInformation.MedicalInfoAllergies != null){
                    foreach (var item in nursingApplication.SubEpisode.Episode.Patient.MedicalInformation.MedicalInfoAllergies.MedicalInfoDrugAllergies)
                    {
                        if (item.ActiveIngredient != null)
                            allergy.Add(item.ActiveIngredient.Name);
                    }
                }
                //allergy = nursingApplication.SubEpisode.Episode.Patient.MedicalInformation.MedicalInfoAllergies.MedicalInfoDrugAllergies.Select(x => x.ActiveIngredient.Name).ToList();
            }
            string aller = string.Empty;
            foreach(string al in allergy)
            {
                if (string.IsNullOrEmpty(aller))
                    aller = al;
                else
                    aller = aller + "," + al ;
            }
            aller = " Hastanın " + aller + " etken maddesine(lerine) allerjisi vardır";
            this.ALLER.CalcValue = aller;
            this.PROTOKOLNO.CalcValue = nursingApplication.SubEpisode.ProtocolNo;
            this.ADSOYAD.CalcValue = nursingApplication.Episode.Patient.FullName;
            if (nursingApplication.InPatientTreatmentClinicApp != null)
            {
                this.SERVIS.CalcValue = nursingApplication.InPatientTreatmentClinicApp.BaseInpatientAdmission.PhysicalStateClinic.Name + "/" + nursingApplication.InPatientTreatmentClinicApp.BaseInpatientAdmission.RoomGroup.Name;
                this.ODAYATAK.CalcValue = nursingApplication.InPatientTreatmentClinicApp.BaseInpatientAdmission.Room.Name + "/" + nursingApplication.InPatientTreatmentClinicApp.BaseInpatientAdmission.Bed.Name; ;
                this.TEDAVISERVIS.CalcValue = nursingApplication.InPatientTreatmentClinicApp.MasterResource.Name;
                if (nursingApplication.InPatientTreatmentClinicApp.ProcedureDoctor != null)
                    this.DOCTOR.CalcValue = nursingApplication.InPatientTreatmentClinicApp.ProcedureDoctor.Name;
            }

            MyParentReport.currentDateTime = startTimeParam.Date.AddDays(MyParentReport.dateCounter);

            this.TARIH.CalcValue = MyParentReport.currentDateTime.ToString();
            DateTime currentEndDateTime = MyParentReport.currentDateTime.AddDays(1);
            currentEndDateTime = new DateTime(currentEndDateTime.Year, currentEndDateTime.Month, currentEndDateTime.Day, 23, 59, 59);

            List<OrderDetail> orderDetailList = new List<OrderDetail>();

            Type t = typeof(OrderDetail);
            Guid lastOrderGuid = Guid.Empty;
            int count = 1;
            OrderDetail newOrderDetail = new OrderDetail();
            
            DateTime reportDate = new DateTime(MyParentReport.currentDateTime.Year, MyParentReport.currentDateTime.Month, MyParentReport.currentDateTime.Day);

            var drugOrders = DrugOrder.GetDrugOrderForOrderInfoReport(nursingApplication.ObjectID.ToString(), MyParentReport.currentDateTime, currentEndDateTime);
            Guid doctorGuid = Guid.Empty;
            foreach (var order in drugOrders)
            {
                DateTime orderDate = new DateTime(order.Uygulama_tarihi.Value.Year, order.Uygulama_tarihi.Value.Month, order.Uygulama_tarihi.Value.Day);
                if (orderDate == reportDate)
                {
                    int detailCount = (int)DrugOrder.GetDetailCount(order.Doz_araligi);
                    newOrderDetail = new OrderDetail();
                    newOrderDetail.orderTupu = order.Orderturu == true ? "Kendi İlaçı" : "İlaç";
                    newOrderDetail.tedavi = order.Tedavi;
                    newOrderDetail.durum = order.Durumu;
                    newOrderDetail.aciklama = order.Aciklama;
                    newOrderDetail.doz = detailCount.ToString() + "X" + order.Doz_miktari;

                    newOrderDetail.orderTarihi = order.Olusturma_tarihi.Value.ToShortDateString() + " " + order.Olusturma_tarihi.Value.ToShortTimeString();
                    newOrderDetail.uygulamaSekli = TTObjectClasses.Common.GetDisplayTextOfDataTypeEnum(order.DrugUsageType.Value);

                    if (CreateDrugOrderPeriods(t, newOrderDetail, order.Orderobjectid.Value, 1, detailCount))
                    {
                        orderDetailList.Add(newOrderDetail);
                        doctorGuid = order.Orderobjectid.Value;
                    }
                }
                else if (orderDate < reportDate && order.Orderday > 1)
                {
                    int difDays = (reportDate - orderDate).Days;
                    int detailCount = (int)DrugOrder.GetDetailCount(order.Doz_araligi);
                    int startDetail = (detailCount * difDays) + 1;
                    int endDetail = (detailCount * difDays) + detailCount;
                    newOrderDetail = new OrderDetail();
                    newOrderDetail.orderTupu = order.Orderturu == true ? "Kendi İlaçı" : "İlaç";
                    newOrderDetail.tedavi = order.Tedavi;
                    newOrderDetail.durum = order.Durumu;
                    newOrderDetail.aciklama = order.Aciklama;
                    newOrderDetail.doz = detailCount.ToString() + "X" + order.Doz_miktari;

                    newOrderDetail.orderTarihi = order.Olusturma_tarihi.Value.ToShortDateString() + " " + order.Olusturma_tarihi.Value.ToShortTimeString();
                    newOrderDetail.uygulamaSekli = TTObjectClasses.Common.GetDisplayTextOfDataTypeEnum(order.DrugUsageType.Value);

                    if (CreateDrugOrderPeriods(t, newOrderDetail, order.Orderobjectid.Value, startDetail, endDetail))
                    {
                        orderDetailList.Add(newOrderDetail);
                        doctorGuid = order.Orderobjectid.Value;
                    }
                }
            }

            /*var drugOrderDetails = DrugOrderDetail.GetDrugOrderDetailByNursingApp(nursingApplication.ObjectID.ToString(), MyParentReport.currentDateTime, currentEndDateTime);
            foreach (var drugOrderDetail in drugOrderDetails)
            {
                var dozAralıgı = DrugOrder.GetDetailCount(drugOrderDetail.Doz_araligi);
                var drugOrder = ((DrugOrder)context.GetObject((Guid)(drugOrderDetail.Orderobjectid), "DrugOrder"));
                if (lastOrderGuid != drugOrderDetail.Tedavi_objectid) // Aynı İlaç için farklı orderlar yazıldı ise aynı satırda gelsin diye
                {
                    count = 1;

                    newOrderDetail = new OrderDetail();
                    newOrderDetail.orderTupu = drugOrderDetail.Orderturu == true ? "Kendi İlaçı" : "İlaç";
                    newOrderDetail.tedavi = drugOrderDetail.Tedavi;
                    newOrderDetail.durum = drugOrderDetail.Durumu;
                    newOrderDetail.aciklama = drugOrderDetail.Aciklama;
                    newOrderDetail.doz = dozAralıgı + "X" + drugOrderDetail.Doz_miktari;

                    if (drugOrder != null)
                    {
                        newOrderDetail.orderTarihi = drugOrder.CreationDate.Value.ToShortDateString() + " " + drugOrder.CreationDate.Value.ToShortTimeString();
                        newOrderDetail.uygulamaSekli = TTObjectClasses.Common.GetDisplayTextOfDataTypeEnum(drugOrder.DrugUsageType.Value);
                    }

                }

                DateTime orderFilterTime = new DateTime(MyParentReport.currentDateTime.Year, MyParentReport.currentDateTime.Month, MyParentReport.currentDateTime.Day, drugOrder.CreationDate.Value.Hour, drugOrder.CreationDate.Value.Minute, drugOrder.CreationDate.Value.Second);
                if (count < 9 && count <= dozAralıgı && dozAralıgı != 1 && drugOrderDetail.Uygulama_tarihi > orderFilterTime)
                {
                    if (drugOrderDetail.Uygulama_tarihi.Value.Day == orderFilterTime.Day)
                    {
                        count = CreateOrderPeriods(t, count, newOrderDetail, drugOrderDetail);
                    }
                    else if(drugOrderDetail.Uygulama_tarihi.Value.Hour < orderFilterTime.Hour)
                    {
                        count = CreateOrderPeriods(t, count, newOrderDetail, drugOrderDetail);
                    }
                    else if (drugOrderDetail.Uygulama_tarihi.Value.Hour == orderFilterTime.Hour && drugOrderDetail.Uygulama_tarihi.Value.Minute <= orderFilterTime.Minute)
                    {
                        count = CreateOrderPeriods(t, count, newOrderDetail, drugOrderDetail);
                    }
                }
                else if (dozAralıgı == 1 && drugOrderDetail.Uygulama_tarihi.Value.Day == orderFilterTime.Day && drugOrderDetail.Uygulama_tarihi.Value.Month == orderFilterTime.Month)
                {
                    count = CreateOrderPeriods(t, count, newOrderDetail, drugOrderDetail);
                }

                if (count > 1 && lastOrderGuid != drugOrderDetail.Tedavi_objectid)
                {
                    orderDetailList.Add(newOrderDetail);
                    lastOrderGuid = (Guid)drugOrderDetail.Tedavi_objectid;
                }
            }*/

            
            if (doctorGuid != Guid.Empty)
            {
                TTObjectContext rdContext = new TTObjectContext(true);
                DrugOrder order = rdContext.GetObject<DrugOrder>(doctorGuid);
                this.DOCTOR.CalcValue = order.RequestedByUser.Name;
            }

            lastOrderGuid = Guid.Empty;
            var nursingOrderDetails = NursingOrderDetail.GetNursingOrderDetailByNursingApp(nursingApplication.ObjectID.ToString(), MyParentReport.currentDateTime, currentEndDateTime);
            foreach (var nursingOrderDetail in nursingOrderDetails)
            {

                if (nursingOrderDetail.Orderobjectid != null)
                {
                    var dozAralıgı = DrugOrder.GetDetailCount(nursingOrderDetail.Doz_araligi);
                    var nursingOrder = ((NursingOrder)context.GetObject((Guid)(nursingOrderDetail.Orderobjectid), "NursingOrder"));
                    if (lastOrderGuid != nursingOrderDetail.Tedavi_objectid)
                    {
                        count = 1;

                        newOrderDetail = new OrderDetail();
                        newOrderDetail.orderTupu = "Takip";
                        newOrderDetail.tedavi = nursingOrderDetail.Tedavi;
                        newOrderDetail.durum = nursingOrderDetail.Durumu;
                        newOrderDetail.aciklama = nursingOrderDetail.Aciklama;
                        newOrderDetail.uygulamaSekli = "";
                        newOrderDetail.orderTarihi = nursingOrderDetail.Olusturma_tarihi.Value.ToShortDateString() + " " + nursingOrderDetail.Olusturma_tarihi.Value.ToShortTimeString();

                        newOrderDetail.doz = dozAralıgı + "X" + nursingOrderDetail.Doz_miktari;

                    }

                    DateTime orderFilterTime = new DateTime(MyParentReport.currentDateTime.Year, MyParentReport.currentDateTime.Month, MyParentReport.currentDateTime.Day, nursingOrder.PeriodStartTime.Value.Hour, nursingOrder.PeriodStartTime.Value.Minute, nursingOrder.PeriodStartTime.Value.Second);
                    if (count < 9 && count <= dozAralıgı && nursingOrderDetail.Uygulama_tarihi >= orderFilterTime)
                    {
                        DateTime saat = nursingOrderDetail.Uygulama_tarihi.Value;
                        if (saat != null)
                        {
                            var saatMinute = saat.Minute.ToString();
                            if (saat.Minute < 10)
                                saatMinute = "0" + saatMinute;
                            var saatHour = saat.Hour.ToString();
                            if (saat.Hour < 10)
                                saatHour = "0" + saatHour;
                            var fi = t.GetField("T" + count);
                            fi.SetValue(newOrderDetail, saatHour + ":" + saatMinute);
                            count++;
                        }
                    }

                    if (count > 1 && lastOrderGuid != nursingOrderDetail.Tedavi_objectid) // 1 tane bile atsa
                    {
                        orderDetailList.Add(newOrderDetail);
                        lastOrderGuid = (Guid)nursingOrderDetail.Tedavi_objectid;
                    }
                }
            }
            
            lastOrderGuid = Guid.Empty;
            DateTime dateTime = new DateTime(currentEndDateTime.Year, currentEndDateTime.Month, currentEndDateTime.Day);
            var nursingDietDetails = DietOrderDetail.GetDODByNursingApp(nursingApplication.ObjectID.ToString(), MyParentReport.currentDateTime, dateTime);
            foreach (var nursingOrderDetail in nursingDietDetails)
            {

                if (nursingOrderDetail.Orderobjectid != null)
                {
                    var dozAralıgı = DrugOrder.GetDetailCount(nursingOrderDetail.Doz_araligi);
                    var nursingOrder = ((DietOrder)context.GetObject((Guid)(nursingOrderDetail.Orderobjectid), "DietOrder"));
                    if (lastOrderGuid != nursingOrderDetail.Tedavi_objectid)
                    {
                        count = 1;

                        newOrderDetail = new OrderDetail();
                        newOrderDetail.orderTupu = "Diyet";
                        newOrderDetail.tedavi = nursingOrderDetail.Tedavi;
                        newOrderDetail.durum = nursingOrderDetail.Durumu;
                        newOrderDetail.aciklama = nursingOrderDetail.Aciklama;
                        newOrderDetail.uygulamaSekli = "";
                        newOrderDetail.orderTarihi = nursingOrderDetail.Olusturma_tarihi.Value.ToShortDateString() + " " + nursingOrderDetail.Olusturma_tarihi.Value.ToShortTimeString();

                        newOrderDetail.doz = dozAralıgı + "X" + nursingOrderDetail.Doz_miktari;

                    }

                    DateTime orderFilterTime = new DateTime(MyParentReport.currentDateTime.Year, MyParentReport.currentDateTime.Month, MyParentReport.currentDateTime.Day, nursingOrder.PeriodStartTime.Value.Hour, nursingOrder.PeriodStartTime.Value.Minute, nursingOrder.PeriodStartTime.Value.Second);
                    if (count < 9 && count <= dozAralıgı && nursingOrderDetail.Uygulama_tarihi >= orderFilterTime)
                    {
                        DateTime saat = nursingOrderDetail.Uygulama_tarihi.Value;
                        if (saat != null)
                        {
                            //var saatMinute = saat.Minute.ToString();
                            //if (saat.Minute < 10)
                            //    saatMinute = "0" + saatMinute;
                            //var saatHour = saat.Hour.ToString();
                            //if (saat.Hour < 10)
                            //    saatHour = "0" + saatHour;
                            //var fi = t.GetField("T" + count);
                            //fi.SetValue(newOrderDetail, saatHour + ":" + saatMinute);
                            count++;
                        }
                    }

                    if (count > 1 && lastOrderGuid != nursingOrderDetail.Tedavi_objectid) // 1 tane bile atsa
                    {
                        orderDetailList.Add(newOrderDetail);
                        lastOrderGuid = (Guid)nursingOrderDetail.Tedavi_objectid;
                    }
                }
            }


            MyParentReport.orderDetailsListByDate.Add(MyParentReport.currentDateTime, orderDetailList);

            MyParentReport.mainCounter = 0;
            MyParentReport.MAIN.RepeatCount = orderDetailList.Count();

            MyParentReport.dateCounter++;
#endregion HASTAINFO HEADER_Script
                }
            }
            public partial class HASTAINFOGroupFooter : TTReportSection
            {
                public NursingApplicationOrderInfoReport MyParentReport
                {
                    get { return (NursingApplicationOrderInfoReport)ParentReport; }
                }
                
                public TTReportField LISTCOUNT1;
                public TTReportField İmza;
                public TTReportField İmza1;
                public TTReportField TEDAVİ11; 
                public HASTAINFOGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 47;
                    ForceNewPage = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    LISTCOUNT1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 158, 33, 180, 37, false);
                    LISTCOUNT1.Name = "LISTCOUNT1";
                    LISTCOUNT1.Visible = EvetHayirEnum.ehHayir;
                    LISTCOUNT1.TextFormat = @"Short Date";
                    LISTCOUNT1.TextFont.Size = 9;
                    LISTCOUNT1.TextFont.CharSet = 162;
                    LISTCOUNT1.Value = @"";

                    İmza = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 25, 126, 29, false);
                    İmza.Name = "İmza";
                    İmza.TextFormat = @"Short Date";
                    İmza.TextFont.Name = "Arial";
                    İmza.TextFont.Size = 9;
                    İmza.TextFont.Bold = true;
                    İmza.TextFont.CharSet = 162;
                    İmza.Value = @".......................................... Tarafımdan teslim alınmıştır";

                    İmza1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 40, 126, 44, false);
                    İmza1.Name = "İmza1";
                    İmza1.TextFormat = @"Short Date";
                    İmza1.TextFont.Name = "Arial";
                    İmza1.TextFont.Size = 9;
                    İmza1.TextFont.Bold = true;
                    İmza1.TextFont.CharSet = 162;
                    İmza1.Value = @".......................................... Tarafımdan teslim alınmıştır";

                    TEDAVİ11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 0, 204, 17, false);
                    TEDAVİ11.Name = "TEDAVİ11";
                    TEDAVİ11.DrawStyle = DrawStyleConstants.vbSolid;
                    TEDAVİ11.TextFormat = @"dd/MM/yyyy";
                    TEDAVİ11.TextFont.Bold = true;
                    TEDAVİ11.TextFont.CharSet = 162;
                    TEDAVİ11.Value = @"Hemşire Notu";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    LISTCOUNT1.CalcValue = LISTCOUNT1.Value;
                    İmza.CalcValue = İmza.Value;
                    İmza1.CalcValue = İmza1.Value;
                    TEDAVİ11.CalcValue = TEDAVİ11.Value;
                    return new TTReportObject[] { LISTCOUNT1,İmza,İmza1,TEDAVİ11};
                }
            }

        }

        public HASTAINFOGroup HASTAINFO;

        public partial class HEADERGroup : TTReportGroup
        {
            public NursingApplicationOrderInfoReport MyParentReport
            {
                get { return (NursingApplicationOrderInfoReport)ParentReport; }
            }

            new public HEADERGroupHeader Header()
            {
                return (HEADERGroupHeader)_header;
            }

            new public HEADERGroupFooter Footer()
            {
                return (HEADERGroupFooter)_footer;
            }

            public TTReportField ADSOYAD1 { get {return Header().ADSOYAD1;} }
            public TTReportField NewField11211 { get {return Header().NewField11211;} }
            public TTReportField NewField11411 { get {return Header().NewField11411;} }
            public TTReportField PROTOKOLNO1 { get {return Header().PROTOKOLNO1;} }
            public TTReportField NewField112211 { get {return Header().NewField112211;} }
            public TTReportField TARIH1 { get {return Header().TARIH1;} }
            public TTReportField NewField112711 { get {return Header().NewField112711;} }
            public TTReportField NewField111411 { get {return Header().NewField111411;} }
            public TTReportField NewField1114111 { get {return Header().NewField1114111;} }
            public TTReportField ODAYATAK1 { get {return Header().ODAYATAK1;} }
            public TTReportField NewField1117211 { get {return Header().NewField1117211;} }
            public TTReportField NewField11114111 { get {return Header().NewField11114111;} }
            public TTReportField SERVIS1 { get {return Header().SERVIS1;} }
            public TTReportField NewField11127111 { get {return Header().NewField11127111;} }
            public TTReportField NewField111141111 { get {return Header().NewField111141111;} }
            public TTReportField TEDAVISERVIS1 { get {return Header().TEDAVISERVIS1;} }
            public TTReportField NewField111172111 { get {return Header().NewField111172111;} }
            public TTReportField NewField1111141111 { get {return Header().NewField1111141111;} }
            public TTReportField BASLIK1111 { get {return Header().BASLIK1111;} }
            public TTReportField XXXXXXBASLIK11 { get {return Header().XXXXXXBASLIK11;} }
            public TTReportField ORDERTURU11 { get {return Header().ORDERTURU11;} }
            public TTReportField DURUMU11 { get {return Header().DURUMU11;} }
            public TTReportField TEDAVİ11 { get {return Header().TEDAVİ11;} }
            public TTReportField ACIKLAMA11 { get {return Header().ACIKLAMA11;} }
            public TTReportField UYGULAMASEK11 { get {return Header().UYGULAMASEK11;} }
            public TTReportField DOZ11 { get {return Header().DOZ11;} }
            public TTReportField T111 { get {return Header().T111;} }
            public TTReportField T121 { get {return Header().T121;} }
            public TTReportField T131 { get {return Header().T131;} }
            public TTReportField T141 { get {return Header().T141;} }
            public TTReportField T151 { get {return Header().T151;} }
            public TTReportField T16 { get {return Header().T16;} }
            public TTReportField T171 { get {return Header().T171;} }
            public TTReportField T18 { get {return Header().T18;} }
            public TTReportField DOCTOR1 { get {return Header().DOCTOR1;} }
            public TTReportField Doktoru1 { get {return Header().Doktoru1;} }
            public TTReportField NewField12114111 { get {return Header().NewField12114111;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField BASLIK11111 { get {return Header().BASLIK11111;} }
            public HEADERGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public HEADERGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new HEADERGroupHeader(this);
                _footer = new HEADERGroupFooter(this);

            }

            public partial class HEADERGroupHeader : TTReportSection
            {
                public NursingApplicationOrderInfoReport MyParentReport
                {
                    get { return (NursingApplicationOrderInfoReport)ParentReport; }
                }
                
                public TTReportField ADSOYAD1;
                public TTReportField NewField11211;
                public TTReportField NewField11411;
                public TTReportField PROTOKOLNO1;
                public TTReportField NewField112211;
                public TTReportField TARIH1;
                public TTReportField NewField112711;
                public TTReportField NewField111411;
                public TTReportField NewField1114111;
                public TTReportField ODAYATAK1;
                public TTReportField NewField1117211;
                public TTReportField NewField11114111;
                public TTReportField SERVIS1;
                public TTReportField NewField11127111;
                public TTReportField NewField111141111;
                public TTReportField TEDAVISERVIS1;
                public TTReportField NewField111172111;
                public TTReportField NewField1111141111;
                public TTReportField BASLIK1111;
                public TTReportField XXXXXXBASLIK11;
                public TTReportField ORDERTURU11;
                public TTReportField DURUMU11;
                public TTReportField TEDAVİ11;
                public TTReportField ACIKLAMA11;
                public TTReportField UYGULAMASEK11;
                public TTReportField DOZ11;
                public TTReportField T111;
                public TTReportField T121;
                public TTReportField T131;
                public TTReportField T141;
                public TTReportField T151;
                public TTReportField T16;
                public TTReportField T171;
                public TTReportField T18;
                public TTReportField DOCTOR1;
                public TTReportField Doktoru1;
                public TTReportField NewField12114111;
                public TTReportField NewField1;
                public TTReportField BASLIK11111; 
                public HEADERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 92;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    ADSOYAD1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 43, 60, 102, 65, false);
                    ADSOYAD1.Name = "ADSOYAD1";
                    ADSOYAD1.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADSOYAD1.TextFont.Size = 9;
                    ADSOYAD1.TextFont.CharSet = 162;
                    ADSOYAD1.Value = @"{%HASTAINFO.ADSOYAD%}";

                    NewField11211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 60, 36, 65, false);
                    NewField11211.Name = "NewField11211";
                    NewField11211.TextFont.Bold = true;
                    NewField11211.TextFont.CharSet = 162;
                    NewField11211.Value = @"Adı Soyadı";

                    NewField11411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 61, 42, 65, false);
                    NewField11411.Name = "NewField11411";
                    NewField11411.TextFont.Name = "Courier New";
                    NewField11411.TextFont.CharSet = 162;
                    NewField11411.Value = @":";

                    PROTOKOLNO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 43, 55, 80, 59, false);
                    PROTOKOLNO1.Name = "PROTOKOLNO1";
                    PROTOKOLNO1.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROTOKOLNO1.TextFont.Size = 9;
                    PROTOKOLNO1.TextFont.CharSet = 162;
                    PROTOKOLNO1.Value = @"{%HASTAINFO.PROTOKOLNO%}";

                    NewField112211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 55, 36, 59, false);
                    NewField112211.Name = "NewField112211";
                    NewField112211.TextFont.Size = 9;
                    NewField112211.TextFont.Bold = true;
                    NewField112211.TextFont.CharSet = 162;
                    NewField112211.Value = @"Kabul No";

                    TARIH1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 43, 71, 102, 75, false);
                    TARIH1.Name = "TARIH1";
                    TARIH1.FieldType = ReportFieldTypeEnum.ftVariable;
                    TARIH1.TextFormat = @"dd/MM/yyyy";
                    TARIH1.TextFont.Size = 9;
                    TARIH1.TextFont.CharSet = 162;
                    TARIH1.Value = @"{%HASTAINFO.TARIH%}";

                    NewField112711 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 71, 36, 75, false);
                    NewField112711.Name = "NewField112711";
                    NewField112711.TextFont.Size = 9;
                    NewField112711.TextFont.Bold = true;
                    NewField112711.TextFont.CharSet = 162;
                    NewField112711.Value = @"Tarih";

                    NewField111411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 55, 42, 59, false);
                    NewField111411.Name = "NewField111411";
                    NewField111411.TextFont.Name = "Courier New";
                    NewField111411.TextFont.CharSet = 162;
                    NewField111411.Value = @":";

                    NewField1114111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 71, 42, 75, false);
                    NewField1114111.Name = "NewField1114111";
                    NewField1114111.TextFont.Name = "Courier New";
                    NewField1114111.TextFont.CharSet = 162;
                    NewField1114111.Value = @":";

                    ODAYATAK1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 65, 204, 69, false);
                    ODAYATAK1.Name = "ODAYATAK1";
                    ODAYATAK1.FieldType = ReportFieldTypeEnum.ftVariable;
                    ODAYATAK1.TextFont.Size = 9;
                    ODAYATAK1.TextFont.CharSet = 162;
                    ODAYATAK1.Value = @"{%HASTAINFO.ODAYATAK%}";

                    NewField1117211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 65, 138, 69, false);
                    NewField1117211.Name = "NewField1117211";
                    NewField1117211.TextFont.Size = 9;
                    NewField1117211.TextFont.Bold = true;
                    NewField1117211.TextFont.CharSet = 162;
                    NewField1117211.Value = @"Oda/Yatak";

                    NewField11114111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 65, 144, 69, false);
                    NewField11114111.Name = "NewField11114111";
                    NewField11114111.TextFont.Name = "Courier New";
                    NewField11114111.TextFont.CharSet = 162;
                    NewField11114111.Value = @":";

                    SERVIS1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 60, 204, 64, false);
                    SERVIS1.Name = "SERVIS1";
                    SERVIS1.FieldType = ReportFieldTypeEnum.ftVariable;
                    SERVIS1.TextFont.Size = 9;
                    SERVIS1.TextFont.CharSet = 162;
                    SERVIS1.Value = @"{%HASTAINFO.SERVIS%}";

                    NewField11127111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 60, 138, 64, false);
                    NewField11127111.Name = "NewField11127111";
                    NewField11127111.TextFont.Size = 9;
                    NewField11127111.TextFont.Bold = true;
                    NewField11127111.TextFont.CharSet = 162;
                    NewField11127111.Value = @"Servis/Oda Grubu";

                    NewField111141111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 60, 144, 64, false);
                    NewField111141111.Name = "NewField111141111";
                    NewField111141111.TextFont.Name = "Courier New";
                    NewField111141111.TextFont.CharSet = 162;
                    NewField111141111.Value = @":";

                    TEDAVISERVIS1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 43, 66, 102, 70, false);
                    TEDAVISERVIS1.Name = "TEDAVISERVIS1";
                    TEDAVISERVIS1.FieldType = ReportFieldTypeEnum.ftVariable;
                    TEDAVISERVIS1.TextFont.Size = 9;
                    TEDAVISERVIS1.TextFont.CharSet = 162;
                    TEDAVISERVIS1.Value = @"{%HASTAINFO.TEDAVISERVIS%}";

                    NewField111172111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 66, 39, 70, false);
                    NewField111172111.Name = "NewField111172111";
                    NewField111172111.TextFont.Size = 9;
                    NewField111172111.TextFont.Bold = true;
                    NewField111172111.TextFont.CharSet = 162;
                    NewField111172111.Value = @"Tedavi Gördüğü Servis";

                    NewField1111141111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 66, 42, 70, false);
                    NewField1111141111.Name = "NewField1111141111";
                    NewField1111141111.TextFont.Name = "Courier New";
                    NewField1111141111.TextFont.CharSet = 162;
                    NewField1111141111.Value = @":";

                    BASLIK1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 47, 206, 53, false);
                    BASLIK1111.Name = "BASLIK1111";
                    BASLIK1111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BASLIK1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BASLIK1111.TextFont.Name = "Calibri";
                    BASLIK1111.TextFont.Size = 12;
                    BASLIK1111.TextFont.Bold = true;
                    BASLIK1111.TextFont.CharSet = 162;
                    BASLIK1111.Value = @"HASTA ORDERLARI";

                    XXXXXXBASLIK11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 9, 206, 44, false);
                    XXXXXXBASLIK11.Name = "XXXXXXBASLIK11";
                    XXXXXXBASLIK11.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXBASLIK11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    XXXXXXBASLIK11.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK11.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK11.TextFont.Name = "Calibri";
                    XXXXXXBASLIK11.TextFont.Size = 12;
                    XXXXXXBASLIK11.TextFont.Bold = true;
                    XXXXXXBASLIK11.TextFont.CharSet = 162;
                    XXXXXXBASLIK11.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + ""\r\n"" + TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    ORDERTURU11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 84, 23, 91, false);
                    ORDERTURU11.Name = "ORDERTURU11";
                    ORDERTURU11.DrawStyle = DrawStyleConstants.vbSolid;
                    ORDERTURU11.TextFormat = @"dd/MM/yyyy";
                    ORDERTURU11.TextFont.Size = 8;
                    ORDERTURU11.TextFont.Bold = true;
                    ORDERTURU11.TextFont.CharSet = 162;
                    ORDERTURU11.Value = @"Order Türü";

                    DURUMU11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 69, 84, 85, 91, false);
                    DURUMU11.Name = "DURUMU11";
                    DURUMU11.DrawStyle = DrawStyleConstants.vbSolid;
                    DURUMU11.TextFormat = @"dd/MM/yyyy";
                    DURUMU11.TextFont.Bold = true;
                    DURUMU11.TextFont.CharSet = 162;
                    DURUMU11.Value = @"Durumu";

                    TEDAVİ11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 84, 69, 91, false);
                    TEDAVİ11.Name = "TEDAVİ11";
                    TEDAVİ11.DrawStyle = DrawStyleConstants.vbSolid;
                    TEDAVİ11.TextFormat = @"dd/MM/yyyy";
                    TEDAVİ11.TextFont.Bold = true;
                    TEDAVİ11.TextFont.CharSet = 162;
                    TEDAVİ11.Value = @"Tedavi";

                    ACIKLAMA11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 85, 84, 109, 91, false);
                    ACIKLAMA11.Name = "ACIKLAMA11";
                    ACIKLAMA11.DrawStyle = DrawStyleConstants.vbSolid;
                    ACIKLAMA11.TextFormat = @"dd/MM/yyyy";
                    ACIKLAMA11.TextFont.Bold = true;
                    ACIKLAMA11.TextFont.CharSet = 162;
                    ACIKLAMA11.Value = @"Açıklama";

                    UYGULAMASEK11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 109, 84, 130, 91, false);
                    UYGULAMASEK11.Name = "UYGULAMASEK11";
                    UYGULAMASEK11.DrawStyle = DrawStyleConstants.vbSolid;
                    UYGULAMASEK11.TextFormat = @"dd/MM/yyyy";
                    UYGULAMASEK11.TextFont.Size = 8;
                    UYGULAMASEK11.TextFont.Bold = true;
                    UYGULAMASEK11.TextFont.CharSet = 162;
                    UYGULAMASEK11.Value = @"Uygulama Şekli";

                    DOZ11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 130, 84, 140, 91, false);
                    DOZ11.Name = "DOZ11";
                    DOZ11.DrawStyle = DrawStyleConstants.vbSolid;
                    DOZ11.TextFormat = @"dd/MM/yyyy";
                    DOZ11.TextFont.Bold = true;
                    DOZ11.TextFont.CharSet = 162;
                    DOZ11.Value = @"Doz";

                    T111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 84, 148, 91, false);
                    T111.Name = "T111";
                    T111.DrawStyle = DrawStyleConstants.vbSolid;
                    T111.TextFormat = @"dd/MM/yyyy";
                    T111.TextFont.Bold = true;
                    T111.TextFont.CharSet = 162;
                    T111.Value = @"T1";

                    T121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 148, 84, 156, 91, false);
                    T121.Name = "T121";
                    T121.DrawStyle = DrawStyleConstants.vbSolid;
                    T121.TextFormat = @"dd/MM/yyyy";
                    T121.TextFont.Bold = true;
                    T121.TextFont.CharSet = 162;
                    T121.Value = @"T2";

                    T131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 156, 84, 164, 91, false);
                    T131.Name = "T131";
                    T131.DrawStyle = DrawStyleConstants.vbSolid;
                    T131.TextFormat = @"dd/MM/yyyy";
                    T131.TextFont.Bold = true;
                    T131.TextFont.CharSet = 162;
                    T131.Value = @"T3";

                    T141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 164, 84, 172, 91, false);
                    T141.Name = "T141";
                    T141.DrawStyle = DrawStyleConstants.vbSolid;
                    T141.TextFormat = @"dd/MM/yyyy";
                    T141.TextFont.Bold = true;
                    T141.TextFont.CharSet = 162;
                    T141.Value = @"T4";

                    T151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 172, 84, 180, 91, false);
                    T151.Name = "T151";
                    T151.DrawStyle = DrawStyleConstants.vbSolid;
                    T151.TextFormat = @"dd/MM/yyyy";
                    T151.TextFont.Bold = true;
                    T151.TextFont.CharSet = 162;
                    T151.Value = @"T5";

                    T16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 180, 84, 188, 91, false);
                    T16.Name = "T16";
                    T16.DrawStyle = DrawStyleConstants.vbSolid;
                    T16.TextFormat = @"dd/MM/yyyy";
                    T16.TextFont.Bold = true;
                    T16.TextFont.CharSet = 162;
                    T16.Value = @"T6";

                    T171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 188, 84, 196, 91, false);
                    T171.Name = "T171";
                    T171.DrawStyle = DrawStyleConstants.vbSolid;
                    T171.TextFormat = @"dd/MM/yyyy";
                    T171.TextFont.Bold = true;
                    T171.TextFont.CharSet = 162;
                    T171.Value = @"T7";

                    T18 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 196, 84, 204, 91, false);
                    T18.Name = "T18";
                    T18.DrawStyle = DrawStyleConstants.vbSolid;
                    T18.TextFormat = @"dd/MM/yyyy";
                    T18.TextFont.Bold = true;
                    T18.TextFont.CharSet = 162;
                    T18.Value = @"T8";

                    DOCTOR1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 70, 204, 74, false);
                    DOCTOR1.Name = "DOCTOR1";
                    DOCTOR1.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOCTOR1.TextFormat = @"Short Date";
                    DOCTOR1.TextFont.Size = 9;
                    DOCTOR1.TextFont.CharSet = 162;
                    DOCTOR1.Value = @"{%HASTAINFO.DOCTOR%}";

                    Doktoru1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 70, 138, 74, false);
                    Doktoru1.Name = "Doktoru1";
                    Doktoru1.TextFont.Size = 9;
                    Doktoru1.TextFont.Bold = true;
                    Doktoru1.TextFont.CharSet = 162;
                    Doktoru1.Value = @"Doktoru";

                    NewField12114111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 70, 144, 74, false);
                    NewField12114111.Name = "NewField12114111";
                    NewField12114111.TextFont.Name = "Courier New";
                    NewField12114111.TextFont.CharSet = 162;
                    NewField12114111.Value = @":";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 23, 84, 35, 91, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1.TextFont.Size = 8;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"Verilme Tarihi";

                    BASLIK11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 77, 206, 83, false);
                    BASLIK11111.Name = "BASLIK11111";
                    BASLIK11111.FieldType = ReportFieldTypeEnum.ftVariable;
                    BASLIK11111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BASLIK11111.TextFont.Name = "Calibri";
                    BASLIK11111.TextFont.Bold = true;
                    BASLIK11111.TextFont.CharSet = 162;
                    BASLIK11111.Value = @"{%HASTAINFO.ALLER%}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ADSOYAD1.CalcValue = MyParentReport.HASTAINFO.ADSOYAD.CalcValue;
                    NewField11211.CalcValue = NewField11211.Value;
                    NewField11411.CalcValue = NewField11411.Value;
                    PROTOKOLNO1.CalcValue = MyParentReport.HASTAINFO.PROTOKOLNO.CalcValue;
                    NewField112211.CalcValue = NewField112211.Value;
                    TARIH1.CalcValue = MyParentReport.HASTAINFO.TARIH.FormattedValue;
                    NewField112711.CalcValue = NewField112711.Value;
                    NewField111411.CalcValue = NewField111411.Value;
                    NewField1114111.CalcValue = NewField1114111.Value;
                    ODAYATAK1.CalcValue = MyParentReport.HASTAINFO.ODAYATAK.CalcValue;
                    NewField1117211.CalcValue = NewField1117211.Value;
                    NewField11114111.CalcValue = NewField11114111.Value;
                    SERVIS1.CalcValue = MyParentReport.HASTAINFO.SERVIS.CalcValue;
                    NewField11127111.CalcValue = NewField11127111.Value;
                    NewField111141111.CalcValue = NewField111141111.Value;
                    TEDAVISERVIS1.CalcValue = MyParentReport.HASTAINFO.TEDAVISERVIS.CalcValue;
                    NewField111172111.CalcValue = NewField111172111.Value;
                    NewField1111141111.CalcValue = NewField1111141111.Value;
                    BASLIK1111.CalcValue = BASLIK1111.Value;
                    ORDERTURU11.CalcValue = ORDERTURU11.Value;
                    DURUMU11.CalcValue = DURUMU11.Value;
                    TEDAVİ11.CalcValue = TEDAVİ11.Value;
                    ACIKLAMA11.CalcValue = ACIKLAMA11.Value;
                    UYGULAMASEK11.CalcValue = UYGULAMASEK11.Value;
                    DOZ11.CalcValue = DOZ11.Value;
                    T111.CalcValue = T111.Value;
                    T121.CalcValue = T121.Value;
                    T131.CalcValue = T131.Value;
                    T141.CalcValue = T141.Value;
                    T151.CalcValue = T151.Value;
                    T16.CalcValue = T16.Value;
                    T171.CalcValue = T171.Value;
                    T18.CalcValue = T18.Value;
                    DOCTOR1.CalcValue = MyParentReport.HASTAINFO.DOCTOR.FormattedValue;
                    Doktoru1.CalcValue = Doktoru1.Value;
                    NewField12114111.CalcValue = NewField12114111.Value;
                    NewField1.CalcValue = NewField1.Value;
                    BASLIK11111.CalcValue = MyParentReport.HASTAINFO.ALLER.FormattedValue;
                    XXXXXXBASLIK11.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { ADSOYAD1,NewField11211,NewField11411,PROTOKOLNO1,NewField112211,TARIH1,NewField112711,NewField111411,NewField1114111,ODAYATAK1,NewField1117211,NewField11114111,SERVIS1,NewField11127111,NewField111141111,TEDAVISERVIS1,NewField111172111,NewField1111141111,BASLIK1111,ORDERTURU11,DURUMU11,TEDAVİ11,ACIKLAMA11,UYGULAMASEK11,DOZ11,T111,T121,T131,T141,T151,T16,T171,T18,DOCTOR1,Doktoru1,NewField12114111,NewField1,BASLIK11111,XXXXXXBASLIK11};
                }
            }
            public partial class HEADERGroupFooter : TTReportSection
            {
                public NursingApplicationOrderInfoReport MyParentReport
                {
                    get { return (NursingApplicationOrderInfoReport)ParentReport; }
                }
                 
                public HEADERGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public HEADERGroup HEADER;

        public partial class MAINGroup : TTReportGroup
        {
            public NursingApplicationOrderInfoReport MyParentReport
            {
                get { return (NursingApplicationOrderInfoReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField ORDERTURU { get {return Body().ORDERTURU;} }
            public TTReportField DURUMU { get {return Body().DURUMU;} }
            public TTReportField TEDAVİ { get {return Body().TEDAVİ;} }
            public TTReportField UYGULAMASEK { get {return Body().UYGULAMASEK;} }
            public TTReportField DOZ { get {return Body().DOZ;} }
            public TTReportField T1 { get {return Body().T1;} }
            public TTReportField T2 { get {return Body().T2;} }
            public TTReportField T3 { get {return Body().T3;} }
            public TTReportField T4 { get {return Body().T4;} }
            public TTReportField T5 { get {return Body().T5;} }
            public TTReportField T6 { get {return Body().T6;} }
            public TTReportField T7 { get {return Body().T7;} }
            public TTReportField T8 { get {return Body().T8;} }
            public TTReportField P1 { get {return Body().P1;} }
            public TTReportField P2 { get {return Body().P2;} }
            public TTReportField P3 { get {return Body().P3;} }
            public TTReportField P4 { get {return Body().P4;} }
            public TTReportField P5 { get {return Body().P5;} }
            public TTReportField P6 { get {return Body().P6;} }
            public TTReportField P7 { get {return Body().P7;} }
            public TTReportField P8 { get {return Body().P8;} }
            public TTReportField ORDERTARIHI { get {return Body().ORDERTARIHI;} }
            public TTReportField ACIKLAMA { get {return Body().ACIKLAMA;} }
            public MAINGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public MAINGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new MAINGroupBody(this);
            }

            public partial class MAINGroupBody : TTReportSection
            {
                public NursingApplicationOrderInfoReport MyParentReport
                {
                    get { return (NursingApplicationOrderInfoReport)ParentReport; }
                }
                
                public TTReportField ORDERTURU;
                public TTReportField DURUMU;
                public TTReportField TEDAVİ;
                public TTReportField UYGULAMASEK;
                public TTReportField DOZ;
                public TTReportField T1;
                public TTReportField T2;
                public TTReportField T3;
                public TTReportField T4;
                public TTReportField T5;
                public TTReportField T6;
                public TTReportField T7;
                public TTReportField T8;
                public TTReportField P1;
                public TTReportField P2;
                public TTReportField P3;
                public TTReportField P4;
                public TTReportField P5;
                public TTReportField P6;
                public TTReportField P7;
                public TTReportField P8;
                public TTReportField ORDERTARIHI;
                public TTReportField ACIKLAMA; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 16;
                    RepeatCount = 0;
                    
                    ORDERTURU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 0, 23, 16, false);
                    ORDERTURU.Name = "ORDERTURU";
                    ORDERTURU.DrawStyle = DrawStyleConstants.vbSolid;
                    ORDERTURU.FieldType = ReportFieldTypeEnum.ftVariable;
                    ORDERTURU.TextFormat = @"Standard";
                    ORDERTURU.Value = @"";

                    DURUMU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 69, 0, 85, 16, false);
                    DURUMU.Name = "DURUMU";
                    DURUMU.DrawStyle = DrawStyleConstants.vbSolid;
                    DURUMU.FieldType = ReportFieldTypeEnum.ftVariable;
                    DURUMU.TextFormat = @"Standard";
                    DURUMU.TextFont.Size = 9;
                    DURUMU.TextFont.CharSet = 162;
                    DURUMU.Value = @"";

                    TEDAVİ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 0, 69, 16, false);
                    TEDAVİ.Name = "TEDAVİ";
                    TEDAVİ.DrawStyle = DrawStyleConstants.vbSolid;
                    TEDAVİ.FieldType = ReportFieldTypeEnum.ftVariable;
                    TEDAVİ.TextFormat = @"Standard";
                    TEDAVİ.TextFont.Size = 8;
                    TEDAVİ.TextFont.CharSet = 162;
                    TEDAVİ.Value = @"";

                    UYGULAMASEK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 109, 0, 130, 16, false);
                    UYGULAMASEK.Name = "UYGULAMASEK";
                    UYGULAMASEK.DrawStyle = DrawStyleConstants.vbSolid;
                    UYGULAMASEK.FieldType = ReportFieldTypeEnum.ftVariable;
                    UYGULAMASEK.TextFormat = @"Standard";
                    UYGULAMASEK.Value = @"";

                    DOZ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 130, 0, 140, 16, false);
                    DOZ.Name = "DOZ";
                    DOZ.DrawStyle = DrawStyleConstants.vbSolid;
                    DOZ.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOZ.Value = @"";

                    T1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 0, 148, 8, false);
                    T1.Name = "T1";
                    T1.DrawStyle = DrawStyleConstants.vbSolid;
                    T1.FieldType = ReportFieldTypeEnum.ftVariable;
                    T1.Value = @"";

                    T2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 148, 0, 156, 8, false);
                    T2.Name = "T2";
                    T2.DrawStyle = DrawStyleConstants.vbSolid;
                    T2.FieldType = ReportFieldTypeEnum.ftVariable;
                    T2.Value = @"";

                    T3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 156, 0, 164, 8, false);
                    T3.Name = "T3";
                    T3.DrawStyle = DrawStyleConstants.vbSolid;
                    T3.FieldType = ReportFieldTypeEnum.ftVariable;
                    T3.Value = @"";

                    T4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 164, 0, 172, 8, false);
                    T4.Name = "T4";
                    T4.DrawStyle = DrawStyleConstants.vbSolid;
                    T4.FieldType = ReportFieldTypeEnum.ftVariable;
                    T4.Value = @"";

                    T5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 172, 0, 180, 8, false);
                    T5.Name = "T5";
                    T5.DrawStyle = DrawStyleConstants.vbSolid;
                    T5.FieldType = ReportFieldTypeEnum.ftVariable;
                    T5.Value = @"";

                    T6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 180, 0, 188, 8, false);
                    T6.Name = "T6";
                    T6.DrawStyle = DrawStyleConstants.vbSolid;
                    T6.FieldType = ReportFieldTypeEnum.ftVariable;
                    T6.Value = @"";

                    T7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 188, 0, 196, 8, false);
                    T7.Name = "T7";
                    T7.DrawStyle = DrawStyleConstants.vbSolid;
                    T7.FieldType = ReportFieldTypeEnum.ftVariable;
                    T7.Value = @"";

                    T8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 196, 0, 204, 8, false);
                    T8.Name = "T8";
                    T8.DrawStyle = DrawStyleConstants.vbSolid;
                    T8.FieldType = ReportFieldTypeEnum.ftVariable;
                    T8.Value = @"";

                    P1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 8, 148, 16, false);
                    P1.Name = "P1";
                    P1.DrawStyle = DrawStyleConstants.vbSolid;
                    P1.FieldType = ReportFieldTypeEnum.ftVariable;
                    P1.Value = @"";

                    P2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 148, 8, 156, 16, false);
                    P2.Name = "P2";
                    P2.DrawStyle = DrawStyleConstants.vbSolid;
                    P2.FieldType = ReportFieldTypeEnum.ftVariable;
                    P2.Value = @"";

                    P3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 156, 8, 164, 16, false);
                    P3.Name = "P3";
                    P3.DrawStyle = DrawStyleConstants.vbSolid;
                    P3.FieldType = ReportFieldTypeEnum.ftVariable;
                    P3.Value = @"";

                    P4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 164, 8, 172, 16, false);
                    P4.Name = "P4";
                    P4.DrawStyle = DrawStyleConstants.vbSolid;
                    P4.FieldType = ReportFieldTypeEnum.ftVariable;
                    P4.Value = @"";

                    P5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 172, 8, 180, 16, false);
                    P5.Name = "P5";
                    P5.DrawStyle = DrawStyleConstants.vbSolid;
                    P5.FieldType = ReportFieldTypeEnum.ftVariable;
                    P5.Value = @"";

                    P6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 180, 8, 188, 16, false);
                    P6.Name = "P6";
                    P6.DrawStyle = DrawStyleConstants.vbSolid;
                    P6.FieldType = ReportFieldTypeEnum.ftVariable;
                    P6.Value = @"";

                    P7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 188, 8, 196, 16, false);
                    P7.Name = "P7";
                    P7.DrawStyle = DrawStyleConstants.vbSolid;
                    P7.FieldType = ReportFieldTypeEnum.ftVariable;
                    P7.Value = @"";

                    P8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 196, 8, 204, 16, false);
                    P8.Name = "P8";
                    P8.DrawStyle = DrawStyleConstants.vbSolid;
                    P8.FieldType = ReportFieldTypeEnum.ftVariable;
                    P8.Value = @"";

                    ORDERTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 23, 0, 35, 16, false);
                    ORDERTARIHI.Name = "ORDERTARIHI";
                    ORDERTARIHI.DrawStyle = DrawStyleConstants.vbSolid;
                    ORDERTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    ORDERTARIHI.TextFormat = @"dd/MM/yyyy HH:mm";
                    ORDERTARIHI.TextFont.Size = 8;
                    ORDERTARIHI.TextFont.CharSet = 162;
                    ORDERTARIHI.Value = @"";

                    ACIKLAMA = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 85, 0, 109, 16, false);
                    ACIKLAMA.Name = "ACIKLAMA";
                    ACIKLAMA.DrawStyle = DrawStyleConstants.vbSolid;
                    ACIKLAMA.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACIKLAMA.TextFormat = @"Standard";
                    ACIKLAMA.WordBreak = EvetHayirEnum.ehEvet;
                    ACIKLAMA.TextFont.Size = 8;
                    ACIKLAMA.TextFont.CharSet = 162;
                    ACIKLAMA.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ORDERTURU.CalcValue = @"";
                    DURUMU.CalcValue = @"";
                    TEDAVİ.CalcValue = @"";
                    UYGULAMASEK.CalcValue = @"";
                    DOZ.CalcValue = @"";
                    T1.CalcValue = @"";
                    T2.CalcValue = @"";
                    T3.CalcValue = @"";
                    T4.CalcValue = @"";
                    T5.CalcValue = @"";
                    T6.CalcValue = @"";
                    T7.CalcValue = @"";
                    T8.CalcValue = @"";
                    P1.CalcValue = @"";
                    P2.CalcValue = @"";
                    P3.CalcValue = @"";
                    P4.CalcValue = @"";
                    P5.CalcValue = @"";
                    P6.CalcValue = @"";
                    P7.CalcValue = @"";
                    P8.CalcValue = @"";
                    ORDERTARIHI.CalcValue = @"";
                    ACIKLAMA.CalcValue = @"";
                    return new TTReportObject[] { ORDERTURU,DURUMU,TEDAVİ,UYGULAMASEK,DOZ,T1,T2,T3,T4,T5,T6,T7,T8,P1,P2,P3,P4,P5,P6,P7,P8,ORDERTARIHI,ACIKLAMA};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    if (MyParentReport.MAIN.RepeatCount > 0)
                    {
                       List<OrderDetail> orderDetailList;
                    MyParentReport.orderDetailsListByDate.TryGetValue(MyParentReport.currentDateTime, out orderDetailList);
                    var obj = orderDetailList[MyParentReport.mainCounter];
                    this.ORDERTURU.CalcValue = obj.orderTupu;
                    this.TEDAVİ.CalcValue = obj.tedavi;
                    this.DURUMU.CalcValue = obj.durum;
                    this.ACIKLAMA.CalcValue = obj.aciklama;
                    this.UYGULAMASEK.CalcValue = obj.uygulamaSekli;
                    this.ORDERTARIHI.CalcValue = obj.orderTarihi;
                    this.DOZ.CalcValue = obj.doz;
                    this.T1.CalcValue = obj.T1;
                    this.T2.CalcValue = obj.T2;
                    this.T3.CalcValue = obj.T3;
                    this.T4.CalcValue = obj.T4;
                    this.T5.CalcValue = obj.T5;
                    this.T6.CalcValue = obj.T6;
                    this.T7.CalcValue = obj.T7;
                    this.T8.CalcValue = obj.T8;
//                    this.T9.CalcValue = obj.T9;
//                    this.T10.CalcValue = obj.T10;
//                    this.T11.CalcValue = obj.T11;
//                    this.T12.CalcValue = obj.T12;
//                    this.T13.CalcValue = obj.T13;
//                    this.T14.CalcValue = obj.T14;
//                    this.T15.CalcValue = obj.T15;
                    MyParentReport.mainCounter += 1;
                        this.Visible = EvetHayirEnum.ehEvet;
                    }
                    else
                    {
                        this.Visible = EvetHayirEnum.ehHayir;
                    }
#endregion MAIN BODY_Script
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public NursingApplicationOrderInfoReport()
        {
            PAGECOUNTHESAPLA = new PAGECOUNTHESAPLAGroup(this,"PAGECOUNTHESAPLA");
            HASTAINFO = new HASTAINFOGroup(PAGECOUNTHESAPLA,"HASTAINFO");
            HEADER = new HEADERGroup(HASTAINFO,"HEADER");
            MAIN = new MAINGroup(HEADER,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "00000000-0000-0000-0000-000000000000", "Hemşirelik İşlemi Id", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter = Parameters.Add("STARTTIME", "", "Başlançış Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENDTIME", "", "Bitiş Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["TTOBJECTID"]);
            if (parameters.ContainsKey("STARTTIME"))
                _runtimeParameters.STARTTIME = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTTIME"]);
            if (parameters.ContainsKey("ENDTIME"))
                _runtimeParameters.ENDTIME = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ENDTIME"]);
            Name = "NURSINGAPPLICATIONORDERINFOREPORT";
            Caption = "Hasta Tedavi Defteri ";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oePortrait;
        }

        protected TTReportField SetFieldDefaultProperties()
        {
            TTReportField fd = new TTReportField();

            fd.Visible = EvetHayirEnum.ehEvet;
            fd.ForeColor = System.Drawing.Color.Black;
            fd.FillColor = System.Drawing.Color.White;
            fd.DrawStyle = DrawStyleConstants.vbInvisible;
            fd.FillStyle = FillStyleConstants.vbFSSolid;
            fd.DrawWidth = 1;

            fd.FieldType = ReportFieldTypeEnum.ftConstant;
            fd.CaseFormat = CaseFormatEnum.fcNoChange;
            fd.TextFormat = "";
            fd.TextColor = System.Drawing.Color.Black;
            fd.FontAngle = 0;
            fd.HorzAlign = HorizontalAlignmentEnum.haleft;
            fd.VertAlign = VerticalAlignmentEnum.vaTop;
            fd.MultiLine = EvetHayirEnum.ehHayir;
            fd.NoClip = EvetHayirEnum.ehHayir;
            fd.WordBreak = EvetHayirEnum.ehHayir;
            fd.ExpandTabs = EvetHayirEnum.ehHayir;
            fd.CrossTabRole = CrosstabRoleEnum.ctrNone;
            fd.CrossTabValues = "";
            fd.ExcelCol = 0;
            fd.ObjectDefName = "";
            fd.DataMember = "";
            fd.TextFont.Name = "Arial Narrow";
            fd.TextFont.Size = 10;
            fd.TextFont.Bold = false;
            fd.TextFont.Italic = false;
            fd.TextFont.Underline = false;
            fd.TextFont.Strikethrough = false;
            fd.TextFont.CharSet = 1;
            return fd;
        }

        protected TTReportRTF SetRTFDefaultProperties()
        {
            TTReportRTF fd = new TTReportRTF();

            fd.Visible = EvetHayirEnum.ehEvet;
            fd.ForeColor = System.Drawing.Color.Black;
            fd.FillColor = System.Drawing.Color.White;
            fd.DrawStyle = DrawStyleConstants.vbInvisible;
            fd.FillStyle = FillStyleConstants.vbFSSolid;
            fd.DrawWidth = 1;

            fd.CanExpand = EvetHayirEnum.ehEvet;
            fd.CanShrink = EvetHayirEnum.ehEvet;
            fd.CanSplit = EvetHayirEnum.ehEvet;
            fd.EvaluateValue = EvetHayirEnum.ehHayir;
            return fd;
        }

        protected TTReportHTML SetHTMLDefaultProperties()
        {
            TTReportHTML fd = new TTReportHTML();

            fd.Visible = EvetHayirEnum.ehEvet;
            fd.ForeColor = System.Drawing.Color.Black;
            fd.FillColor = System.Drawing.Color.White;
            fd.DrawStyle = DrawStyleConstants.vbInvisible;
            fd.FillStyle = FillStyleConstants.vbFSSolid;
            fd.DrawWidth = 1;

            fd.CanExpand = EvetHayirEnum.ehEvet;
            fd.CanShrink = EvetHayirEnum.ehEvet;
            fd.CanSplit = EvetHayirEnum.ehEvet;
            fd.EvaluateValue = EvetHayirEnum.ehHayir;
            return fd;
        }

        protected TTReportShape SetShapeDefaultProperties()
        {
            TTReportShape fd = new TTReportShape();

            fd.Visible = EvetHayirEnum.ehEvet;
            fd.ForeColor = System.Drawing.Color.Black;
            fd.FillColor = System.Drawing.Color.White;
            fd.DrawStyle = DrawStyleConstants.vbSolid;
            fd.FillStyle = FillStyleConstants.vbFSSolid;
            fd.DrawWidth = 1;
            return fd;
        }

    }
}
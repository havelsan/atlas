
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
    /// <summary>
    /// HEMŞİRELİK HİZMETLERİ HASTA İZLEM FORMU
    /// </summary>
    public partial class NursingApplicationDailyOrderDetailReport : TTReport
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
        }
        public int mainCounter = 0;
        public int dateCounter=0;
        public DateTime currentDateTime ;
        Dictionary<DateTime,  List<OrderDetail>> drugOrderDetailsListByDate = new  Dictionary<DateTime,  List<OrderDetail>>();
        Dictionary<DateTime,  List<OrderDetail>> nursingOrderDetailsListByDate = new  Dictionary<DateTime,  List<OrderDetail>>();
   
#endregion Methods

        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
            public DateTime? STARTTIME = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
        }

        public partial class PAGECOUNTHESAPLAGroup : TTReportGroup
        {
            public NursingApplicationDailyOrderDetailReport MyParentReport
            {
                get { return (NursingApplicationDailyOrderDetailReport)ParentReport; }
            }

            new public PAGECOUNTHESAPLAGroupHeader Header()
            {
                return (PAGECOUNTHESAPLAGroupHeader)_header;
            }

            new public PAGECOUNTHESAPLAGroupFooter Footer()
            {
                return (PAGECOUNTHESAPLAGroupFooter)_footer;
            }

            public TTReportField pageCount1 { get {return Footer().pageCount1;} }
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
                public NursingApplicationDailyOrderDetailReport MyParentReport
                {
                    get { return (NursingApplicationDailyOrderDetailReport)ParentReport; }
                }
                 
                public PAGECOUNTHESAPLAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 2;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                }
                

                public override void RunScript()
                {
#region PAGECOUNTHESAPLA HEADER_Script
                    DateTime StartTime = (DateTime)MyParentReport.RuntimeParameters.STARTTIME;
            DateTime EndTime = (DateTime)MyParentReport.RuntimeParameters.ENDDATE;
            int repeatCount = (int)(EndTime.Date - StartTime.Date).TotalDays + 1;
            MyParentReport.HASTAINFO.RepeatCount = repeatCount;
#endregion PAGECOUNTHESAPLA HEADER_Script
                }
            }
            public partial class PAGECOUNTHESAPLAGroupFooter : TTReportSection
            {
                public NursingApplicationDailyOrderDetailReport MyParentReport
                {
                    get { return (NursingApplicationDailyOrderDetailReport)ParentReport; }
                }
                
                public TTReportField pageCount1; 
                public PAGECOUNTHESAPLAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 6;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    pageCount1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 1, 22, 5, false);
                    pageCount1.Name = "pageCount1";
                    pageCount1.Visible = EvetHayirEnum.ehHayir;
                    pageCount1.FieldType = ReportFieldTypeEnum.ftVariable;
                    pageCount1.TextFormat = @"Short Date";
                    pageCount1.TextFont.Size = 9;
                    pageCount1.Value = @"{@pagecount@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    pageCount1.CalcValue = ParentReport.ReportTotalPageCount;
                    return new TTReportObject[] { pageCount1};
                }
            }

        }

        public PAGECOUNTHESAPLAGroup PAGECOUNTHESAPLA;

        public partial class HASTAINFOGroup : TTReportGroup
        {
            public NursingApplicationDailyOrderDetailReport MyParentReport
            {
                get { return (NursingApplicationDailyOrderDetailReport)ParentReport; }
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
            public TTReportField LISTCOUNT111 { get {return Header().LISTCOUNT111;} }
            public TTReportField DIAGNOSIS { get {return Header().DIAGNOSIS;} }
            public TTReportField YATISTARIHI { get {return Header().YATISTARIHI;} }
            public TTReportField NewField11324111 { get {return Footer().NewField11324111;} }
            public TTReportField NewField122152111 { get {return Footer().NewField122152111;} }
            public TTReportField NewField1111251221 { get {return Footer().NewField1111251221;} }
            public TTReportField NewField1211 { get {return Footer().NewField1211;} }
            public TTReportField NewField12121 { get {return Footer().NewField12121;} }
            public TTReportField NewField112121 { get {return Footer().NewField112121;} }
            public TTReportField NewField12114231 { get {return Footer().NewField12114231;} }
            public TTReportField NewField1111111 { get {return Footer().NewField1111111;} }
            public TTReportField NewField121125122 { get {return Footer().NewField121125122;} }
            public TTReportField NewField11111111 { get {return Footer().NewField11111111;} }
            public TTReportField NewField1221521121 { get {return Footer().NewField1221521121;} }
            public TTReportField NewField113241121 { get {return Footer().NewField113241121;} }
            public TTReportField NewField1221521122 { get {return Footer().NewField1221521122;} }
            public TTReportField NewField12215 { get {return Footer().NewField12215;} }
            public TTReportField NewField151221 { get {return Footer().NewField151221;} }
            public TTReportField NewField151222 { get {return Footer().NewField151222;} }
            public TTReportField NewField1222151 { get {return Footer().NewField1222151;} }
            public TTReportField SAYFANO { get {return Footer().SAYFANO;} }
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
                public NursingApplicationDailyOrderDetailReport MyParentReport
                {
                    get { return (NursingApplicationDailyOrderDetailReport)ParentReport; }
                }
                
                public TTReportField ADSOYAD;
                public TTReportField PROTOKOLNO;
                public TTReportField TARIH;
                public TTReportField ODAYATAK;
                public TTReportField SERVIS;
                public TTReportField TEDAVISERVIS;
                public TTReportField DOCTOR;
                public TTReportField LISTCOUNT111;
                public TTReportField DIAGNOSIS;
                public TTReportField YATISTARIHI; 
                public HASTAINFOGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 6;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    ADSOYAD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 8, 92, 13, false);
                    ADSOYAD.Name = "ADSOYAD";
                    ADSOYAD.Visible = EvetHayirEnum.ehHayir;
                    ADSOYAD.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADSOYAD.TextFont.Size = 9;
                    ADSOYAD.Value = @"";

                    PROTOKOLNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 2, 71, 6, false);
                    PROTOKOLNO.Name = "PROTOKOLNO";
                    PROTOKOLNO.Visible = EvetHayirEnum.ehHayir;
                    PROTOKOLNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROTOKOLNO.TextFont.Size = 9;
                    PROTOKOLNO.Value = @"";

                    TARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 19, 92, 23, false);
                    TARIH.Name = "TARIH";
                    TARIH.Visible = EvetHayirEnum.ehHayir;
                    TARIH.FieldType = ReportFieldTypeEnum.ftVariable;
                    TARIH.TextFormat = @"dd/MM/yyyy";
                    TARIH.TextFont.Size = 9;
                    TARIH.Value = @"";

                    ODAYATAK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 135, 13, 194, 17, false);
                    ODAYATAK.Name = "ODAYATAK";
                    ODAYATAK.Visible = EvetHayirEnum.ehHayir;
                    ODAYATAK.FieldType = ReportFieldTypeEnum.ftVariable;
                    ODAYATAK.TextFont.Size = 9;
                    ODAYATAK.Value = @"";

                    SERVIS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 135, 8, 194, 12, false);
                    SERVIS.Name = "SERVIS";
                    SERVIS.Visible = EvetHayirEnum.ehHayir;
                    SERVIS.FieldType = ReportFieldTypeEnum.ftVariable;
                    SERVIS.TextFont.Size = 9;
                    SERVIS.Value = @"";

                    TEDAVISERVIS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 14, 92, 18, false);
                    TEDAVISERVIS.Name = "TEDAVISERVIS";
                    TEDAVISERVIS.Visible = EvetHayirEnum.ehHayir;
                    TEDAVISERVIS.FieldType = ReportFieldTypeEnum.ftVariable;
                    TEDAVISERVIS.TextFont.Size = 9;
                    TEDAVISERVIS.Value = @"";

                    DOCTOR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 135, 18, 194, 22, false);
                    DOCTOR.Name = "DOCTOR";
                    DOCTOR.Visible = EvetHayirEnum.ehHayir;
                    DOCTOR.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOCTOR.TextFormat = @"Short Date";
                    DOCTOR.TextFont.Size = 9;
                    DOCTOR.Value = @"";

                    LISTCOUNT111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 3, 2, 25, 6, false);
                    LISTCOUNT111.Name = "LISTCOUNT111";
                    LISTCOUNT111.TextFormat = @"Short Date";
                    LISTCOUNT111.TextFont.Size = 9;
                    LISTCOUNT111.Value = @"";

                    DIAGNOSIS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 32, 25, 93, 30, false);
                    DIAGNOSIS.Name = "DIAGNOSIS";
                    DIAGNOSIS.Visible = EvetHayirEnum.ehHayir;
                    DIAGNOSIS.DrawStyle = DrawStyleConstants.vbSolid;
                    DIAGNOSIS.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSIS.TextFont.Name = "Arial";
                    DIAGNOSIS.TextFont.Size = 9;
                    DIAGNOSIS.TextFont.Bold = true;
                    DIAGNOSIS.Value = @"";

                    YATISTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 135, 24, 170, 29, false);
                    YATISTARIHI.Name = "YATISTARIHI";
                    YATISTARIHI.Visible = EvetHayirEnum.ehHayir;
                    YATISTARIHI.DrawStyle = DrawStyleConstants.vbSolid;
                    YATISTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    YATISTARIHI.TextFormat = @"dd/MM/yyyy";
                    YATISTARIHI.Value = @"";

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
                    LISTCOUNT111.CalcValue = LISTCOUNT111.Value;
                    DIAGNOSIS.CalcValue = @"";
                    YATISTARIHI.CalcValue = @"";
                    return new TTReportObject[] { ADSOYAD,PROTOKOLNO,TARIH,ODAYATAK,SERVIS,TEDAVISERVIS,DOCTOR,LISTCOUNT111,DIAGNOSIS,YATISTARIHI};
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
            foreach (DrugOrderDetail detail in drugOrder.DrugOrderDetails)
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
                        //  var fi = t.GetField("T" + tCount.ToString());
                        //   if(fi != null)
                        //       fi.SetValue(newOrderDetail, saatHour + ":" + saatMinute);
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

            string sObjectID = ((NursingApplicationDailyOrderDetailReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            NursingApplication nursingApplication = (NursingApplication)context.GetObject(new Guid(sObjectID), "NursingApplication");

            DateTime startTimeParam = (DateTime)((NursingApplicationDailyOrderDetailReport)ParentReport).RuntimeParameters.STARTTIME;
            startTimeParam = new DateTime(startTimeParam.Year, startTimeParam.Month, startTimeParam.Day);

            DateTime endTimeParam = (DateTime)((NursingApplicationDailyOrderDetailReport)ParentReport).RuntimeParameters.ENDDATE;
            endTimeParam = new DateTime(endTimeParam.Year, endTimeParam.Month, endTimeParam.Day, 23, 59, 59);
            
            this.YATISTARIHI.CalcValue = nursingApplication.InPatientTreatmentClinicApp.ClinicInpatientDate.ToString();
            string alldiag = "";
            foreach(DiagnosisGrid diagnosis in nursingApplication.SubEpisode.Diagnosis)
            {
                alldiag += diagnosis.Diagnose + ",";
            }
            this.DIAGNOSIS.CalcValue = alldiag;

            this.PROTOKOLNO.CalcValue = nursingApplication.SubEpisode.ProtocolNo;
            this.ADSOYAD.CalcValue = nursingApplication.Episode.Patient.FullName;
            if (nursingApplication.InPatientTreatmentClinicApp != null)
            {
                string PhysicalStateClinic = string.Empty;
                if(nursingApplication.InPatientTreatmentClinicApp.BaseInpatientAdmission.PhysicalStateClinic != null)
                    PhysicalStateClinic = nursingApplication.InPatientTreatmentClinicApp.BaseInpatientAdmission.PhysicalStateClinic.Name;
                
                string RoomGroup = string.Empty;
                if(nursingApplication.InPatientTreatmentClinicApp.BaseInpatientAdmission.RoomGroup != null)
                    RoomGroup = nursingApplication.InPatientTreatmentClinicApp.BaseInpatientAdmission.RoomGroup.Name;
                
                this.SERVIS.CalcValue = PhysicalStateClinic + "/" + RoomGroup;
                this.TEDAVISERVIS.CalcValue = nursingApplication.InPatientTreatmentClinicApp.MasterResource.Name;
                if(nursingApplication.InPatientTreatmentClinicApp.ProcedureDoctor != null)
                    this.DOCTOR.CalcValue = nursingApplication.InPatientTreatmentClinicApp.ProcedureDoctor.Name;
            }
            
            DateTime dateTime = (DateTime)((NursingApplicationDailyOrderDetailReport)ParentReport).RuntimeParameters.STARTTIME;
            MyParentReport.currentDateTime = startTimeParam.Date.AddDays(MyParentReport.dateCounter);

            this.TARIH.CalcValue = MyParentReport.currentDateTime.ToString();
            DateTime currentEndDateTime = MyParentReport.currentDateTime.AddDays(1);
            currentEndDateTime = new DateTime(currentEndDateTime.Year, currentEndDateTime.Month, currentEndDateTime.Day, 23, 59, 59);

            List<OrderDetail> orderDetailList = new List<OrderDetail>();
            List<OrderDetail> nursingDetailList = new List<OrderDetail>();

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
                            //var fi = t.GetField("T" + count);
                            //fi.SetValue(newOrderDetail, saatHour + ":" + saatMinute);
                            count++;
                        }
                    }

                    if (count > 1 && lastOrderGuid != nursingOrderDetail.Tedavi_objectid) // 1 tane bile atsa
                    {
                        nursingDetailList.Add(newOrderDetail);
                        lastOrderGuid = (Guid)nursingOrderDetail.Tedavi_objectid;
                    }
                }
            }
            
            lastOrderGuid = Guid.Empty;
            //DateTime dateTime = new DateTime(currentEndDateTime.Year, currentEndDateTime.Month, currentEndDateTime.Day);
            var nursingDietDetails = DietOrderDetail.GetDODByNursingApp(nursingApplication.ObjectID.ToString(), MyParentReport.currentDateTime, reportDate);
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
                        nursingDetailList.Add(newOrderDetail);
                        lastOrderGuid = (Guid)nursingOrderDetail.Tedavi_objectid;
                    }
                }
            }


            MyParentReport.drugOrderDetailsListByDate.Add(MyParentReport.currentDateTime, orderDetailList);
            MyParentReport.nursingOrderDetailsListByDate.Add(MyParentReport.currentDateTime, nursingDetailList);

            MyParentReport.mainCounter = 0;
            MyParentReport.MAIN.RepeatCount = orderDetailList.Count();
            MyParentReport.PARTC.RepeatCount = nursingDetailList.Count();
            MyParentReport.dateCounter++;
#endregion HASTAINFO HEADER_Script
                }
            }
            public partial class HASTAINFOGroupFooter : TTReportSection
            {
                public NursingApplicationDailyOrderDetailReport MyParentReport
                {
                    get { return (NursingApplicationDailyOrderDetailReport)ParentReport; }
                }
                
                public TTReportField NewField11324111;
                public TTReportField NewField122152111;
                public TTReportField NewField1111251221;
                public TTReportField NewField1211;
                public TTReportField NewField12121;
                public TTReportField NewField112121;
                public TTReportField NewField12114231;
                public TTReportField NewField1111111;
                public TTReportField NewField121125122;
                public TTReportField NewField11111111;
                public TTReportField NewField1221521121;
                public TTReportField NewField113241121;
                public TTReportField NewField1221521122;
                public TTReportField NewField12215;
                public TTReportField NewField151221;
                public TTReportField NewField151222;
                public TTReportField NewField1222151;
                public TTReportField SAYFANO; 
                public HASTAINFOGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 58;
                    ForceNewPage = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField11324111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 65, 0, 101, 14, false);
                    NewField11324111.Name = "NewField11324111";
                    NewField11324111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11324111.Value = @"";

                    NewField122152111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 0, 17, 14, false);
                    NewField122152111.Name = "NewField122152111";
                    NewField122152111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField122152111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField122152111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField122152111.TextFont.Name = "Arial";
                    NewField122152111.TextFont.Size = 8;
                    NewField122152111.TextFont.Bold = true;
                    NewField122152111.Value = @"SAAT";

                    NewField1111251221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 0, 65, 14, false);
                    NewField1111251221.Name = "NewField1111251221";
                    NewField1111251221.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111251221.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111251221.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111251221.TextFont.Name = "Arial";
                    NewField1111251221.TextFont.Size = 8;
                    NewField1111251221.TextFont.Bold = true;
                    NewField1111251221.Value = @"DİYETİ";

                    NewField1211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 101, 0, 209, 14, false);
                    NewField1211.Name = "NewField1211";
                    NewField1211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1211.TextFont.Name = "Arial";
                    NewField1211.TextFont.Size = 8;
                    NewField1211.TextFont.Bold = true;
                    NewField1211.Value = @" İnvaziv Girişim Yeri :";

                    NewField12121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 101, 14, 209, 28, false);
                    NewField12121.Name = "NewField12121";
                    NewField12121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12121.TextFont.Name = "Arial";
                    NewField12121.TextFont.Size = 8;
                    NewField12121.TextFont.Bold = true;
                    NewField12121.Value = @" Damar Yolu Açılması :";

                    NewField112121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 101, 28, 209, 42, false);
                    NewField112121.Name = "NewField112121";
                    NewField112121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112121.TextFont.Name = "Arial";
                    NewField112121.TextFont.Size = 8;
                    NewField112121.TextFont.Bold = true;
                    NewField112121.Value = @" İdrar Sondası :";

                    NewField12114231 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 65, 14, 101, 28, false);
                    NewField12114231.Name = "NewField12114231";
                    NewField12114231.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12114231.Value = @"";

                    NewField1111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 14, 65, 28, false);
                    NewField1111111.Name = "NewField1111111";
                    NewField1111111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111111.Value = @"";

                    NewField121125122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 14, 17, 28, false);
                    NewField121125122.Name = "NewField121125122";
                    NewField121125122.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField121125122.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField121125122.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121125122.TextFont.Name = "Arial";
                    NewField121125122.TextFont.Size = 8;
                    NewField121125122.TextFont.Bold = true;
                    NewField121125122.Value = @"";

                    NewField11111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 28, 65, 42, false);
                    NewField11111111.Name = "NewField11111111";
                    NewField11111111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11111111.Value = @"";

                    NewField1221521121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 28, 17, 42, false);
                    NewField1221521121.Name = "NewField1221521121";
                    NewField1221521121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1221521121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1221521121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1221521121.TextFont.Name = "Arial";
                    NewField1221521121.TextFont.Size = 8;
                    NewField1221521121.TextFont.Bold = true;
                    NewField1221521121.Value = @"";

                    NewField113241121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 65, 28, 101, 42, false);
                    NewField113241121.Name = "NewField113241121";
                    NewField113241121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField113241121.Value = @"";

                    NewField1221521122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 42, 209, 51, false);
                    NewField1221521122.Name = "NewField1221521122";
                    NewField1221521122.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1221521122.TextFont.Name = "Arial";
                    NewField1221521122.TextFont.Size = 8;
                    NewField1221521122.TextFont.Bold = true;
                    NewField1221521122.Value = @"NOTLAR :";

                    NewField12215 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 51, 25, 58, false);
                    NewField12215.Name = "NewField12215";
                    NewField12215.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12215.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12215.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12215.TextFont.Name = "Arial";
                    NewField12215.TextFont.Size = 8;
                    NewField12215.TextFont.Bold = true;
                    NewField12215.Value = @"KLN-FR-05";

                    NewField151221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 51, 65, 58, false);
                    NewField151221.Name = "NewField151221";
                    NewField151221.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField151221.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField151221.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField151221.TextFont.Name = "Arial";
                    NewField151221.TextFont.Size = 8;
                    NewField151221.TextFont.Bold = true;
                    NewField151221.Value = @"Y.T.:04.12.2018";

                    NewField151222 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 65, 51, 102, 58, false);
                    NewField151222.Name = "NewField151222";
                    NewField151222.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField151222.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField151222.TextFont.Name = "Arial";
                    NewField151222.TextFont.Size = 8;
                    NewField151222.TextFont.Bold = true;
                    NewField151222.Value = @"REV.TAR.:";

                    NewField1222151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 102, 51, 139, 58, false);
                    NewField1222151.Name = "NewField1222151";
                    NewField1222151.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1222151.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1222151.TextFont.Name = "Arial";
                    NewField1222151.TextFont.Size = 8;
                    NewField1222151.TextFont.Bold = true;
                    NewField1222151.Value = @"REV.NO:";

                    SAYFANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 139, 51, 209, 58, false);
                    SAYFANO.Name = "SAYFANO";
                    SAYFANO.DrawStyle = DrawStyleConstants.vbSolid;
                    SAYFANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SAYFANO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SAYFANO.TextFont.Name = "Arial";
                    SAYFANO.TextFont.Size = 8;
                    SAYFANO.TextFont.Bold = true;
                    SAYFANO.Value = @"S.NO: {@pagenumber@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField11324111.CalcValue = NewField11324111.Value;
                    NewField122152111.CalcValue = NewField122152111.Value;
                    NewField1111251221.CalcValue = NewField1111251221.Value;
                    NewField1211.CalcValue = NewField1211.Value;
                    NewField12121.CalcValue = NewField12121.Value;
                    NewField112121.CalcValue = NewField112121.Value;
                    NewField12114231.CalcValue = NewField12114231.Value;
                    NewField1111111.CalcValue = NewField1111111.Value;
                    NewField121125122.CalcValue = NewField121125122.Value;
                    NewField11111111.CalcValue = NewField11111111.Value;
                    NewField1221521121.CalcValue = NewField1221521121.Value;
                    NewField113241121.CalcValue = NewField113241121.Value;
                    NewField1221521122.CalcValue = NewField1221521122.Value;
                    NewField12215.CalcValue = NewField12215.Value;
                    NewField151221.CalcValue = NewField151221.Value;
                    NewField151222.CalcValue = NewField151222.Value;
                    NewField1222151.CalcValue = NewField1222151.Value;
                    SAYFANO.CalcValue = @"S.NO: " + ParentReport.CurrentPageNumber.ToString();
                    return new TTReportObject[] { NewField11324111,NewField122152111,NewField1111251221,NewField1211,NewField12121,NewField112121,NewField12114231,NewField1111111,NewField121125122,NewField11111111,NewField1221521121,NewField113241121,NewField1221521122,NewField12215,NewField151221,NewField151222,NewField1222151,SAYFANO};
                }
            }

        }

        public HASTAINFOGroup HASTAINFO;

        public partial class PARTAGroup : TTReportGroup
        {
            public NursingApplicationDailyOrderDetailReport MyParentReport
            {
                get { return (NursingApplicationDailyOrderDetailReport)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField XXXXXXBASLIK111 { get {return Header().XXXXXXBASLIK111;} }
            public TTReportField LOGO1 { get {return Header().LOGO1;} }
            public TTReportField LOGO11 { get {return Header().LOGO11;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportField NewField1111 { get {return Header().NewField1111;} }
            public TTReportField NewField131 { get {return Header().NewField131;} }
            public TTReportField NewField1211 { get {return Header().NewField1211;} }
            public TTReportField NewField141 { get {return Header().NewField141;} }
            public TTReportField NewField1311 { get {return Header().NewField1311;} }
            public TTReportField ADSOYAD1 { get {return Header().ADSOYAD1;} }
            public TTReportField PROTOKOLNO1 { get {return Header().PROTOKOLNO1;} }
            public TTReportField NewField1141 { get {return Header().NewField1141;} }
            public TTReportField NewField11131 { get {return Header().NewField11131;} }
            public TTReportField YATISTARIHI1 { get {return Header().YATISTARIHI1;} }
            public TTReportField DIAGNOSIS1 { get {return Header().DIAGNOSIS1;} }
            public TTReportField TEDAVISERVIS1 { get {return Header().TEDAVISERVIS1;} }
            public TTReportField NewField11411 { get {return Header().NewField11411;} }
            public TTReportField NewField111411 { get {return Header().NewField111411;} }
            public TTReportField NewField11412 { get {return Header().NewField11412;} }
            public TTReportField NewField113111 { get {return Header().NewField113111;} }
            public TTReportField DOCTOR1 { get {return Header().DOCTOR1;} }
            public TTReportField NewField1142 { get {return Header().NewField1142;} }
            public TTReportField NewField11132 { get {return Header().NewField11132;} }
            public TTReportField TARIH1 { get {return Header().TARIH1;} }
            public TTReportField SERVIS1 { get {return Header().SERVIS1;} }
            public TTReportField NewField11413 { get {return Header().NewField11413;} }
            public TTReportField NewField113112 { get {return Header().NewField113112;} }
            public TTReportField NewField131411 { get {return Header().NewField131411;} }
            public TTReportField NewField1114131 { get {return Header().NewField1114131;} }
            public TTReportField NewField11314111 { get {return Header().NewField11314111;} }
            public TTReportField NewField112512 { get {return Header().NewField112512;} }
            public TTReportField NewField1215211 { get {return Header().NewField1215211;} }
            public TTReportField NewField11125121 { get {return Header().NewField11125121;} }
            public TTReportField NewField112152111 { get {return Header().NewField112152111;} }
            public TTReportField NewField1111251211 { get {return Header().NewField1111251211;} }
            public TTReportField NewField1111251212 { get {return Header().NewField1111251212;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportField NewField3 { get {return Header().NewField3;} }
            public TTReportField NewField13 { get {return Header().NewField13;} }
            public TTReportField NewField14 { get {return Header().NewField14;} }
            public TTReportField NewField15 { get {return Header().NewField15;} }
            public TTReportField NewField16 { get {return Header().NewField16;} }
            public TTReportField NewField142 { get {return Header().NewField142;} }
            public TTReportField NewField152 { get {return Header().NewField152;} }
            public TTReportField NewField161 { get {return Header().NewField161;} }
            public TTReportField NewField1241 { get {return Header().NewField1241;} }
            public TTReportField NewField1252 { get {return Header().NewField1252;} }
            public TTReportField TARIH2 { get {return Header().TARIH2;} }
            public PARTAGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTAGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTAGroupHeader(this);
                _footer = new PARTAGroupFooter(this);

            }

            public partial class PARTAGroupHeader : TTReportSection
            {
                public NursingApplicationDailyOrderDetailReport MyParentReport
                {
                    get { return (NursingApplicationDailyOrderDetailReport)ParentReport; }
                }
                
                public TTReportField XXXXXXBASLIK111;
                public TTReportField LOGO1;
                public TTReportField LOGO11;
                public TTReportField NewField11;
                public TTReportField NewField111;
                public TTReportField NewField121;
                public TTReportField NewField1111;
                public TTReportField NewField131;
                public TTReportField NewField1211;
                public TTReportField NewField141;
                public TTReportField NewField1311;
                public TTReportField ADSOYAD1;
                public TTReportField PROTOKOLNO1;
                public TTReportField NewField1141;
                public TTReportField NewField11131;
                public TTReportField YATISTARIHI1;
                public TTReportField DIAGNOSIS1;
                public TTReportField TEDAVISERVIS1;
                public TTReportField NewField11411;
                public TTReportField NewField111411;
                public TTReportField NewField11412;
                public TTReportField NewField113111;
                public TTReportField DOCTOR1;
                public TTReportField NewField1142;
                public TTReportField NewField11132;
                public TTReportField TARIH1;
                public TTReportField SERVIS1;
                public TTReportField NewField11413;
                public TTReportField NewField113112;
                public TTReportField NewField131411;
                public TTReportField NewField1114131;
                public TTReportField NewField11314111;
                public TTReportField NewField112512;
                public TTReportField NewField1215211;
                public TTReportField NewField11125121;
                public TTReportField NewField112152111;
                public TTReportField NewField1111251211;
                public TTReportField NewField1111251212;
                public TTReportField NewField1;
                public TTReportField NewField2;
                public TTReportField NewField3;
                public TTReportField NewField13;
                public TTReportField NewField14;
                public TTReportField NewField15;
                public TTReportField NewField16;
                public TTReportField NewField142;
                public TTReportField NewField152;
                public TTReportField NewField161;
                public TTReportField NewField1241;
                public TTReportField NewField1252;
                public TTReportField TARIH2; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 66;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    XXXXXXBASLIK111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 28, 7, 187, 26, false);
                    XXXXXXBASLIK111.Name = "XXXXXXBASLIK111";
                    XXXXXXBASLIK111.DrawStyle = DrawStyleConstants.vbSolid;
                    XXXXXXBASLIK111.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXBASLIK111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    XXXXXXBASLIK111.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK111.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK111.TextFont.Name = "Calibri";
                    XXXXXXBASLIK111.TextFont.Size = 12;
                    XXXXXXBASLIK111.TextFont.Bold = true;
                    XXXXXXBASLIK111.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + ""\r\n"" + TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    LOGO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 7, 28, 26, false);
                    LOGO1.Name = "LOGO1";
                    LOGO1.DrawStyle = DrawStyleConstants.vbSolid;
                    LOGO1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    LOGO1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LOGO1.TextFont.CharSet = 1;
                    LOGO1.Value = @"";

                    LOGO11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 187, 7, 209, 26, false);
                    LOGO11.Name = "LOGO11";
                    LOGO11.DrawStyle = DrawStyleConstants.vbSolid;
                    LOGO11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    LOGO11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LOGO11.TextFont.CharSet = 1;
                    LOGO11.Value = @"";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 26, 26, 31, false);
                    NewField11.Name = "NewField11";
                    NewField11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Name = "Arial";
                    NewField11.TextFont.Size = 8;
                    NewField11.TextFont.Bold = true;
                    NewField11.Value = @"AD SOYAD";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 26, 26, 28, 31, false);
                    NewField111.Name = "NewField111";
                    NewField111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111.TextFont.Name = "Arial";
                    NewField111.TextFont.Size = 8;
                    NewField111.TextFont.Bold = true;
                    NewField111.Value = @":";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 31, 26, 36, false);
                    NewField121.Name = "NewField121";
                    NewField121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121.TextFont.Name = "Arial";
                    NewField121.TextFont.Size = 8;
                    NewField121.TextFont.Bold = true;
                    NewField121.Value = @"PROT.NO";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 26, 31, 28, 36, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111.TextFont.Name = "Arial";
                    NewField1111.TextFont.Size = 8;
                    NewField1111.TextFont.Bold = true;
                    NewField1111.Value = @":";

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 36, 26, 41, false);
                    NewField131.Name = "NewField131";
                    NewField131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField131.TextFont.Name = "Arial";
                    NewField131.TextFont.Size = 8;
                    NewField131.TextFont.Bold = true;
                    NewField131.Value = @"TANI";

                    NewField1211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 26, 36, 28, 41, false);
                    NewField1211.Name = "NewField1211";
                    NewField1211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1211.TextFont.Name = "Arial";
                    NewField1211.TextFont.Size = 8;
                    NewField1211.TextFont.Bold = true;
                    NewField1211.Value = @":";

                    NewField141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 74, 31, 101, 36, false);
                    NewField141.Name = "NewField141";
                    NewField141.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField141.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField141.TextFont.Name = "Arial";
                    NewField141.TextFont.Size = 8;
                    NewField141.TextFont.Bold = true;
                    NewField141.Value = @"YATIŞ TARİHİ";

                    NewField1311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 101, 31, 103, 36, false);
                    NewField1311.Name = "NewField1311";
                    NewField1311.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1311.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1311.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1311.TextFont.Name = "Arial";
                    NewField1311.TextFont.Size = 8;
                    NewField1311.TextFont.Bold = true;
                    NewField1311.Value = @":";

                    ADSOYAD1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 28, 26, 138, 31, false);
                    ADSOYAD1.Name = "ADSOYAD1";
                    ADSOYAD1.DrawStyle = DrawStyleConstants.vbSolid;
                    ADSOYAD1.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADSOYAD1.Value = @"{%HASTAINFO.ADSOYAD%}";

                    PROTOKOLNO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 28, 31, 74, 36, false);
                    PROTOKOLNO1.Name = "PROTOKOLNO1";
                    PROTOKOLNO1.DrawStyle = DrawStyleConstants.vbSolid;
                    PROTOKOLNO1.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROTOKOLNO1.Value = @"{%HASTAINFO.PROTOKOLNO%}";

                    NewField1141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 41, 26, 46, false);
                    NewField1141.Name = "NewField1141";
                    NewField1141.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1141.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1141.TextFont.Name = "Arial";
                    NewField1141.TextFont.Size = 8;
                    NewField1141.TextFont.Bold = true;
                    NewField1141.Value = @"BÖLÜM";

                    NewField11131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 26, 41, 28, 46, false);
                    NewField11131.Name = "NewField11131";
                    NewField11131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11131.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11131.TextFont.Name = "Arial";
                    NewField11131.TextFont.Size = 8;
                    NewField11131.TextFont.Bold = true;
                    NewField11131.Value = @":";

                    YATISTARIHI1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 103, 31, 138, 36, false);
                    YATISTARIHI1.Name = "YATISTARIHI1";
                    YATISTARIHI1.DrawStyle = DrawStyleConstants.vbSolid;
                    YATISTARIHI1.FieldType = ReportFieldTypeEnum.ftVariable;
                    YATISTARIHI1.TextFormat = @"dd/MM/yyyy";
                    YATISTARIHI1.Value = @"{%HASTAINFO.YATISTARIHI%}";

                    DIAGNOSIS1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 28, 36, 138, 41, false);
                    DIAGNOSIS1.Name = "DIAGNOSIS1";
                    DIAGNOSIS1.DrawStyle = DrawStyleConstants.vbSolid;
                    DIAGNOSIS1.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSIS1.TextFont.Name = "Arial";
                    DIAGNOSIS1.TextFont.Size = 9;
                    DIAGNOSIS1.TextFont.Bold = true;
                    DIAGNOSIS1.Value = @"{%HASTAINFO.DIAGNOSIS%}";

                    TEDAVISERVIS1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 28, 41, 138, 46, false);
                    TEDAVISERVIS1.Name = "TEDAVISERVIS1";
                    TEDAVISERVIS1.DrawStyle = DrawStyleConstants.vbSolid;
                    TEDAVISERVIS1.FieldType = ReportFieldTypeEnum.ftVariable;
                    TEDAVISERVIS1.Value = @"{%HASTAINFO.TEDAVISERVIS%}";

                    NewField11411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 138, 36, 209, 41, false);
                    NewField11411.Name = "NewField11411";
                    NewField11411.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11411.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11411.TextFont.Name = "Arial";
                    NewField11411.TextFont.Size = 8;
                    NewField11411.TextFont.Bold = true;
                    NewField11411.Value = @"Alerjik Durum .............................................................";

                    NewField111411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 138, 31, 209, 36, false);
                    NewField111411.Name = "NewField111411";
                    NewField111411.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111411.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111411.TextFont.Name = "Arial";
                    NewField111411.TextFont.Size = 8;
                    NewField111411.TextFont.Bold = true;
                    NewField111411.Value = @"Eliza test sonucu kontrol edildi mi  Evet... Hayır...";

                    NewField11412 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 138, 41, 158, 46, false);
                    NewField11412.Name = "NewField11412";
                    NewField11412.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11412.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11412.TextFont.Name = "Arial";
                    NewField11412.TextFont.Size = 8;
                    NewField11412.TextFont.Bold = true;
                    NewField11412.Value = @"DOKTOR";

                    NewField113111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 158, 41, 160, 46, false);
                    NewField113111.Name = "NewField113111";
                    NewField113111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField113111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField113111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField113111.TextFont.Name = "Arial";
                    NewField113111.TextFont.Size = 8;
                    NewField113111.TextFont.Bold = true;
                    NewField113111.Value = @":";

                    DOCTOR1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 41, 209, 46, false);
                    DOCTOR1.Name = "DOCTOR1";
                    DOCTOR1.DrawStyle = DrawStyleConstants.vbSolid;
                    DOCTOR1.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOCTOR1.Value = @"{%HASTAINFO.DOCTOR%}";

                    NewField1142 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 178, 26, 187, 31, false);
                    NewField1142.Name = "NewField1142";
                    NewField1142.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1142.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1142.TextFont.Name = "Arial";
                    NewField1142.TextFont.Size = 8;
                    NewField1142.TextFont.Bold = true;
                    NewField1142.Value = @"TARİH";

                    NewField11132 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 187, 26, 189, 31, false);
                    NewField11132.Name = "NewField11132";
                    NewField11132.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11132.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11132.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11132.TextFont.Name = "Arial";
                    NewField11132.TextFont.Size = 8;
                    NewField11132.TextFont.Bold = true;
                    NewField11132.Value = @":";

                    TARIH1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 189, 26, 209, 31, false);
                    TARIH1.Name = "TARIH1";
                    TARIH1.DrawStyle = DrawStyleConstants.vbSolid;
                    TARIH1.FieldType = ReportFieldTypeEnum.ftVariable;
                    TARIH1.Value = @"{%HASTAINFO.TARIH%}";

                    SERVIS1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 138, 26, 178, 31, false);
                    SERVIS1.Name = "SERVIS1";
                    SERVIS1.DrawStyle = DrawStyleConstants.vbSolid;
                    SERVIS1.FieldType = ReportFieldTypeEnum.ftVariable;
                    SERVIS1.Value = @"{%HASTAINFO.SERVIS%}";

                    NewField11413 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 46, 45, 51, false);
                    NewField11413.Name = "NewField11413";
                    NewField11413.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11413.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11413.TextFont.Name = "Arial";
                    NewField11413.TextFont.Size = 8;
                    NewField11413.TextFont.Bold = true;
                    NewField11413.Value = @"Hemşire Çalışma Saatleri";

                    NewField113112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 46, 47, 51, false);
                    NewField113112.Name = "NewField113112";
                    NewField113112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField113112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField113112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField113112.TextFont.Name = "Arial";
                    NewField113112.TextFont.Size = 8;
                    NewField113112.TextFont.Bold = true;
                    NewField113112.Value = @":";

                    NewField131411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 46, 101, 56, false);
                    NewField131411.Name = "NewField131411";
                    NewField131411.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField131411.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField131411.TextFont.Name = "Arial";
                    NewField131411.TextFont.Size = 8;
                    NewField131411.TextFont.Bold = true;
                    NewField131411.Value = @"08:00 - 16:00";

                    NewField1114131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 101, 46, 155, 56, false);
                    NewField1114131.Name = "NewField1114131";
                    NewField1114131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1114131.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1114131.TextFont.Name = "Arial";
                    NewField1114131.TextFont.Size = 8;
                    NewField1114131.TextFont.Bold = true;
                    NewField1114131.Value = @"16:00 - 08:00";

                    NewField11314111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 46, 209, 56, false);
                    NewField11314111.Name = "NewField11314111";
                    NewField11314111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11314111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11314111.TextFont.Name = "Arial";
                    NewField11314111.TextFont.Size = 8;
                    NewField11314111.TextFont.Bold = true;
                    NewField11314111.Value = @"08:00 - 08:00";

                    NewField112512 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 51, 47, 56, false);
                    NewField112512.Name = "NewField112512";
                    NewField112512.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112512.TextFont.Name = "Arial";
                    NewField112512.TextFont.Size = 8;
                    NewField112512.TextFont.Bold = true;
                    NewField112512.Value = @"YAŞAM BULGULARI";

                    NewField1215211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 56, 17, 61, false);
                    NewField1215211.Name = "NewField1215211";
                    NewField1215211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1215211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1215211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1215211.TextFont.Name = "Arial";
                    NewField1215211.TextFont.Size = 8;
                    NewField1215211.TextFont.Bold = true;
                    NewField1215211.Value = @"SAAT";

                    NewField11125121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 56, 29, 61, false);
                    NewField11125121.Name = "NewField11125121";
                    NewField11125121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11125121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11125121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11125121.TextFont.Name = "Arial";
                    NewField11125121.TextFont.Size = 8;
                    NewField11125121.TextFont.Bold = true;
                    NewField11125121.Value = @"ATEŞ";

                    NewField112152111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 29, 56, 41, 61, false);
                    NewField112152111.Name = "NewField112152111";
                    NewField112152111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112152111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112152111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112152111.TextFont.Name = "Arial";
                    NewField112152111.TextFont.Size = 8;
                    NewField112152111.TextFont.Bold = true;
                    NewField112152111.Value = @"NABIZ";

                    NewField1111251211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 56, 53, 61, false);
                    NewField1111251211.Name = "NewField1111251211";
                    NewField1111251211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111251211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111251211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111251211.TextFont.Name = "Arial";
                    NewField1111251211.TextFont.Size = 8;
                    NewField1111251211.TextFont.Bold = true;
                    NewField1111251211.Value = @"KAN B.";

                    NewField1111251212 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 56, 65, 61, false);
                    NewField1111251212.Name = "NewField1111251212";
                    NewField1111251212.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111251212.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111251212.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111251212.TextFont.Name = "Arial";
                    NewField1111251212.TextFont.Size = 8;
                    NewField1111251212.TextFont.Bold = true;
                    NewField1111251212.Value = @"SLM";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 77, 56, 89, 61, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1.Value = @"";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 65, 56, 77, 61, false);
                    NewField2.Name = "NewField2";
                    NewField2.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField2.Value = @"";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 89, 56, 101, 61, false);
                    NewField3.Name = "NewField3";
                    NewField3.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField3.Value = @"";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 101, 56, 209, 61, false);
                    NewField13.Name = "NewField13";
                    NewField13.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField13.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField13.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField13.TextFont.Name = "Arial";
                    NewField13.TextFont.Size = 9;
                    NewField13.TextFont.Bold = true;
                    NewField13.Value = @"TEDAVİ VE İLAÇLAR";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 77, 61, 89, 66, false);
                    NewField14.Name = "NewField14";
                    NewField14.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField14.Value = @"";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 65, 61, 77, 66, false);
                    NewField15.Name = "NewField15";
                    NewField15.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField15.Value = @"";

                    NewField16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 89, 61, 101, 66, false);
                    NewField16.Name = "NewField16";
                    NewField16.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField16.Value = @"";

                    NewField142 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 61, 53, 66, false);
                    NewField142.Name = "NewField142";
                    NewField142.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField142.Value = @"";

                    NewField152 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 29, 61, 41, 66, false);
                    NewField152.Name = "NewField152";
                    NewField152.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField152.Value = @"";

                    NewField161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 61, 65, 66, false);
                    NewField161.Name = "NewField161";
                    NewField161.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField161.Value = @"";

                    NewField1241 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 61, 29, 66, false);
                    NewField1241.Name = "NewField1241";
                    NewField1241.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1241.Value = @"";

                    NewField1252 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 61, 17, 66, false);
                    NewField1252.Name = "NewField1252";
                    NewField1252.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1252.Value = @"";

                    TARIH2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 101, 61, 209, 66, false);
                    TARIH2.Name = "TARIH2";
                    TARIH2.ForeColor = System.Drawing.Color.FromArgb(255,64,0,64);
                    TARIH2.FillColor = System.Drawing.Color.Silver;
                    TARIH2.DrawStyle = DrawStyleConstants.vbSolid;
                    TARIH2.FillStyle = FillStyleConstants.vbFSTransparent;
                    TARIH2.FieldType = ReportFieldTypeEnum.ftVariable;
                    TARIH2.TextFormat = @"dd/MM/yyyy";
                    TARIH2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TARIH2.Value = @"{%HASTAINFO.TARIH%}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    LOGO1.CalcValue = LOGO1.Value;
                    LOGO11.CalcValue = LOGO11.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField111.CalcValue = NewField111.Value;
                    NewField121.CalcValue = NewField121.Value;
                    NewField1111.CalcValue = NewField1111.Value;
                    NewField131.CalcValue = NewField131.Value;
                    NewField1211.CalcValue = NewField1211.Value;
                    NewField141.CalcValue = NewField141.Value;
                    NewField1311.CalcValue = NewField1311.Value;
                    ADSOYAD1.CalcValue = MyParentReport.HASTAINFO.ADSOYAD.CalcValue;
                    PROTOKOLNO1.CalcValue = MyParentReport.HASTAINFO.PROTOKOLNO.CalcValue;
                    NewField1141.CalcValue = NewField1141.Value;
                    NewField11131.CalcValue = NewField11131.Value;
                    YATISTARIHI1.CalcValue = MyParentReport.HASTAINFO.YATISTARIHI.FormattedValue;
                    DIAGNOSIS1.CalcValue = MyParentReport.HASTAINFO.DIAGNOSIS.CalcValue;
                    TEDAVISERVIS1.CalcValue = MyParentReport.HASTAINFO.TEDAVISERVIS.CalcValue;
                    NewField11411.CalcValue = NewField11411.Value;
                    NewField111411.CalcValue = NewField111411.Value;
                    NewField11412.CalcValue = NewField11412.Value;
                    NewField113111.CalcValue = NewField113111.Value;
                    DOCTOR1.CalcValue = MyParentReport.HASTAINFO.DOCTOR.FormattedValue;
                    NewField1142.CalcValue = NewField1142.Value;
                    NewField11132.CalcValue = NewField11132.Value;
                    TARIH1.CalcValue = MyParentReport.HASTAINFO.TARIH.FormattedValue;
                    SERVIS1.CalcValue = MyParentReport.HASTAINFO.SERVIS.CalcValue;
                    NewField11413.CalcValue = NewField11413.Value;
                    NewField113112.CalcValue = NewField113112.Value;
                    NewField131411.CalcValue = NewField131411.Value;
                    NewField1114131.CalcValue = NewField1114131.Value;
                    NewField11314111.CalcValue = NewField11314111.Value;
                    NewField112512.CalcValue = NewField112512.Value;
                    NewField1215211.CalcValue = NewField1215211.Value;
                    NewField11125121.CalcValue = NewField11125121.Value;
                    NewField112152111.CalcValue = NewField112152111.Value;
                    NewField1111251211.CalcValue = NewField1111251211.Value;
                    NewField1111251212.CalcValue = NewField1111251212.Value;
                    NewField1.CalcValue = NewField1.Value;
                    NewField2.CalcValue = NewField2.Value;
                    NewField3.CalcValue = NewField3.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField14.CalcValue = NewField14.Value;
                    NewField15.CalcValue = NewField15.Value;
                    NewField16.CalcValue = NewField16.Value;
                    NewField142.CalcValue = NewField142.Value;
                    NewField152.CalcValue = NewField152.Value;
                    NewField161.CalcValue = NewField161.Value;
                    NewField1241.CalcValue = NewField1241.Value;
                    NewField1252.CalcValue = NewField1252.Value;
                    TARIH2.CalcValue = MyParentReport.HASTAINFO.TARIH.FormattedValue;
                    XXXXXXBASLIK111.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { LOGO1,LOGO11,NewField11,NewField111,NewField121,NewField1111,NewField131,NewField1211,NewField141,NewField1311,ADSOYAD1,PROTOKOLNO1,NewField1141,NewField11131,YATISTARIHI1,DIAGNOSIS1,TEDAVISERVIS1,NewField11411,NewField111411,NewField11412,NewField113111,DOCTOR1,NewField1142,NewField11132,TARIH1,SERVIS1,NewField11413,NewField113112,NewField131411,NewField1114131,NewField11314111,NewField112512,NewField1215211,NewField11125121,NewField112152111,NewField1111251211,NewField1111251212,NewField1,NewField2,NewField3,NewField13,NewField14,NewField15,NewField16,NewField142,NewField152,NewField161,NewField1241,NewField1252,TARIH2,XXXXXXBASLIK111};
                }
                public override void RunPreScript()
                {
#region PARTA HEADER_PreScript
                    /*DateTime STARTdate = (DateTime)((NursingApplicationDailyOrderDetailReport)ParentReport).RuntimeParameters.STARTTIME;
            DateTime ENDdate = (DateTime)((NursingApplicationDailyOrderDetailReport)ParentReport).RuntimeParameters.ENDDATE;
            DateTime sdate = new DateTime(STARTdate.Year, STARTdate.Month, STARTdate.Day, 0, 0, 0, 0);
            DateTime edate = new DateTime(ENDdate.Year, ENDdate.Month, ENDdate.Day, 23, 59, 59, 0);

            ((NursingApplicationDailyOrderDetailReport)ParentReport).RuntimeParameters.STARTTIME = sdate;
            ((NursingApplicationDailyOrderDetailReport)ParentReport).RuntimeParameters.ENDDATE = edate;*/
#endregion PARTA HEADER_PreScript
                }

                public override void RunScript()
                {
#region PARTA HEADER_Script
                    /* TTObjectContext context = new TTObjectContext(true);

            string sObjectID = ((NursingApplicationDailyOrderDetailReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            NursingApplication nursingApplication = (NursingApplication)context.GetObject(new Guid(sObjectID), "NursingApplication");

            this.YATISTARIHI.CalcValue = nursingApplication.InPatientTreatmentClinicApp.ClinicInpatientDate.ToString();
            string alldiag = "";
            foreach(DiagnosisGrid diagnosis in nursingApplication.SubEpisode.Diagnosis)
            {
                alldiag += diagnosis.Diagnose + ",";
            }
            this.DIAGNOSIS.CalcValue = alldiag;

            this.PROTOKOLNO.CalcValue = nursingApplication.SubEpisode.ProtocolNo;
            this.ADSOYAD.CalcValue = nursingApplication.Episode.Patient.FullName;
            if (nursingApplication.InPatientTreatmentClinicApp != null)
            {
                string PhysicalStateClinic = string.Empty;
                if(nursingApplication.InPatientTreatmentClinicApp.BaseInpatientAdmission.PhysicalStateClinic != null)
                    PhysicalStateClinic = nursingApplication.InPatientTreatmentClinicApp.BaseInpatientAdmission.PhysicalStateClinic.Name;
                
                string RoomGroup = string.Empty;
                if(nursingApplication.InPatientTreatmentClinicApp.BaseInpatientAdmission.RoomGroup != null)
                    RoomGroup = nursingApplication.InPatientTreatmentClinicApp.BaseInpatientAdmission.RoomGroup.Name;
                
                this.SERVIS.CalcValue = PhysicalStateClinic + "/" + RoomGroup;
                this.TEDAVISERVIS.CalcValue = nursingApplication.InPatientTreatmentClinicApp.MasterResource.Name;
                if(nursingApplication.InPatientTreatmentClinicApp.ProcedureDoctor != null)
                    this.DOCTOR.CalcValue = nursingApplication.InPatientTreatmentClinicApp.ProcedureDoctor.Name;
            }
            
            DateTime dateTime = (DateTime)((NursingApplicationDailyOrderDetailReport)ParentReport).RuntimeParameters.STARTTIME;
            
            
            this.TARIH.CalcValue = dateTime.ToString();
            this.TARIH1.CalcValue = dateTime.ToString();*/
#endregion PARTA HEADER_Script
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public NursingApplicationDailyOrderDetailReport MyParentReport
                {
                    get { return (NursingApplicationDailyOrderDetailReport)ParentReport; }
                }
                 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTAGroup PARTA;

        public partial class PARTBGroup : TTReportGroup
        {
            public NursingApplicationDailyOrderDetailReport MyParentReport
            {
                get { return (NursingApplicationDailyOrderDetailReport)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField NewField1111252121 { get {return Footer().NewField1111252121;} }
            public PARTBGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTBGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTBGroupHeader(this);
                _footer = new PARTBGroupFooter(this);

            }

            public partial class PARTBGroupHeader : TTReportSection
            {
                public NursingApplicationDailyOrderDetailReport MyParentReport
                {
                    get { return (NursingApplicationDailyOrderDetailReport)ParentReport; }
                }
                 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 1;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                }
                
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public NursingApplicationDailyOrderDetailReport MyParentReport
                {
                    get { return (NursingApplicationDailyOrderDetailReport)ParentReport; }
                }
                
                public TTReportField NewField1111252121; 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 4;
                    RepeatCount = 0;
                    
                    NewField1111252121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 101, 0, 209, 5, false);
                    NewField1111252121.Name = "NewField1111252121";
                    NewField1111252121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111252121.TextColor = System.Drawing.Color.Red;
                    NewField1111252121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111252121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111252121.TextFont.Name = "Arial";
                    NewField1111252121.TextFont.Bold = true;
                    NewField1111252121.Value = @"Tedavi Planları";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1111252121.CalcValue = NewField1111252121.Value;
                    return new TTReportObject[] { NewField1111252121};
                }
            }

        }

        public PARTBGroup PARTB;

        public partial class MAINGroup : TTReportGroup
        {
            public NursingApplicationDailyOrderDetailReport MyParentReport
            {
                get { return (NursingApplicationDailyOrderDetailReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField NewField112521 { get {return Body().NewField112521;} }
            public TTReportField NewField1125211 { get {return Body().NewField1125211;} }
            public TTReportField NewField1225211 { get {return Body().NewField1225211;} }
            public TTReportField NewField1141 { get {return Body().NewField1141;} }
            public TTReportField NewField1151 { get {return Body().NewField1151;} }
            public TTReportField NewField1161 { get {return Body().NewField1161;} }
            public TTReportField NewField11421 { get {return Body().NewField11421;} }
            public TTReportField NewField11521 { get {return Body().NewField11521;} }
            public TTReportField NewField11611 { get {return Body().NewField11611;} }
            public TTReportField NewField112411 { get {return Body().NewField112411;} }
            public TTReportField NewField11411 { get {return Body().NewField11411;} }
            public TTReportField NewField11511 { get {return Body().NewField11511;} }
            public TTReportField NewField12611 { get {return Body().NewField12611;} }
            public TTReportField NewField122411 { get {return Body().NewField122411;} }
            public TTReportField NewField112511 { get {return Body().NewField112511;} }
            public TTReportField NewField111611 { get {return Body().NewField111611;} }
            public TTReportField NewField1114211 { get {return Body().NewField1114211;} }
            public TTReportField NewField12411 { get {return Body().NewField12411;} }
            public TTReportField NewField12511 { get {return Body().NewField12511;} }
            public TTReportField NewField13611 { get {return Body().NewField13611;} }
            public TTReportField NewField132411 { get {return Body().NewField132411;} }
            public TTReportField NewField122511 { get {return Body().NewField122511;} }
            public TTReportField NewField121611 { get {return Body().NewField121611;} }
            public TTReportField NewField1214211 { get {return Body().NewField1214211;} }
            public TTReportField TEDAVITXT { get {return Body().TEDAVITXT;} }
            public TTReportField TEDAVI { get {return Body().TEDAVI;} }
            public TTReportField DOZ { get {return Body().DOZ;} }
            public TTReportField NewField11 { get {return Body().NewField11;} }
            public TTReportField ACIKLAMA { get {return Body().ACIKLAMA;} }
            public TTReportField NewField111 { get {return Body().NewField111;} }
            public TTReportField UYGULAMA { get {return Body().UYGULAMA;} }
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
                public NursingApplicationDailyOrderDetailReport MyParentReport
                {
                    get { return (NursingApplicationDailyOrderDetailReport)ParentReport; }
                }
                
                public TTReportField NewField112521;
                public TTReportField NewField1125211;
                public TTReportField NewField1225211;
                public TTReportField NewField1141;
                public TTReportField NewField1151;
                public TTReportField NewField1161;
                public TTReportField NewField11421;
                public TTReportField NewField11521;
                public TTReportField NewField11611;
                public TTReportField NewField112411;
                public TTReportField NewField11411;
                public TTReportField NewField11511;
                public TTReportField NewField12611;
                public TTReportField NewField122411;
                public TTReportField NewField112511;
                public TTReportField NewField111611;
                public TTReportField NewField1114211;
                public TTReportField NewField12411;
                public TTReportField NewField12511;
                public TTReportField NewField13611;
                public TTReportField NewField132411;
                public TTReportField NewField122511;
                public TTReportField NewField121611;
                public TTReportField NewField1214211;
                public TTReportField TEDAVITXT;
                public TTReportField TEDAVI;
                public TTReportField DOZ;
                public TTReportField NewField11;
                public TTReportField ACIKLAMA;
                public TTReportField NewField111;
                public TTReportField UYGULAMA; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 21;
                    RepeatCount = 0;
                    
                    NewField112521 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 0, 17, 7, false);
                    NewField112521.Name = "NewField112521";
                    NewField112521.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112521.Value = @"";

                    NewField1125211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 7, 17, 14, false);
                    NewField1125211.Name = "NewField1125211";
                    NewField1125211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1125211.Value = @"";

                    NewField1225211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 14, 17, 21, false);
                    NewField1225211.Name = "NewField1225211";
                    NewField1225211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1225211.Value = @"";

                    NewField1141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 77, 0, 89, 7, false);
                    NewField1141.Name = "NewField1141";
                    NewField1141.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1141.Value = @"";

                    NewField1151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 65, 0, 77, 7, false);
                    NewField1151.Name = "NewField1151";
                    NewField1151.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1151.Value = @"";

                    NewField1161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 89, 0, 101, 7, false);
                    NewField1161.Name = "NewField1161";
                    NewField1161.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1161.Value = @"";

                    NewField11421 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 0, 53, 7, false);
                    NewField11421.Name = "NewField11421";
                    NewField11421.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11421.Value = @"";

                    NewField11521 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 29, 0, 41, 7, false);
                    NewField11521.Name = "NewField11521";
                    NewField11521.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11521.Value = @"";

                    NewField11611 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 0, 65, 7, false);
                    NewField11611.Name = "NewField11611";
                    NewField11611.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11611.Value = @"";

                    NewField112411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 0, 29, 7, false);
                    NewField112411.Name = "NewField112411";
                    NewField112411.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112411.Value = @"";

                    NewField11411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 77, 7, 89, 14, false);
                    NewField11411.Name = "NewField11411";
                    NewField11411.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11411.Value = @"";

                    NewField11511 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 65, 7, 77, 14, false);
                    NewField11511.Name = "NewField11511";
                    NewField11511.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11511.Value = @"";

                    NewField12611 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 89, 7, 101, 14, false);
                    NewField12611.Name = "NewField12611";
                    NewField12611.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12611.Value = @"";

                    NewField122411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 7, 53, 14, false);
                    NewField122411.Name = "NewField122411";
                    NewField122411.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField122411.Value = @"";

                    NewField112511 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 29, 7, 41, 14, false);
                    NewField112511.Name = "NewField112511";
                    NewField112511.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112511.Value = @"";

                    NewField111611 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 7, 65, 14, false);
                    NewField111611.Name = "NewField111611";
                    NewField111611.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111611.Value = @"";

                    NewField1114211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 7, 29, 14, false);
                    NewField1114211.Name = "NewField1114211";
                    NewField1114211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1114211.Value = @"";

                    NewField12411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 77, 14, 89, 21, false);
                    NewField12411.Name = "NewField12411";
                    NewField12411.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12411.Value = @"";

                    NewField12511 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 65, 14, 77, 21, false);
                    NewField12511.Name = "NewField12511";
                    NewField12511.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12511.Value = @"";

                    NewField13611 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 89, 14, 101, 21, false);
                    NewField13611.Name = "NewField13611";
                    NewField13611.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField13611.Value = @"";

                    NewField132411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 14, 53, 21, false);
                    NewField132411.Name = "NewField132411";
                    NewField132411.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField132411.Value = @"";

                    NewField122511 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 29, 14, 41, 21, false);
                    NewField122511.Name = "NewField122511";
                    NewField122511.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField122511.Value = @"";

                    NewField121611 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 14, 65, 21, false);
                    NewField121611.Name = "NewField121611";
                    NewField121611.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField121611.Value = @"";

                    NewField1214211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 14, 29, 21, false);
                    NewField1214211.Name = "NewField1214211";
                    NewField1214211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1214211.Value = @"";

                    TEDAVITXT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 101, 0, 209, 21, false);
                    TEDAVITXT.Name = "TEDAVITXT";
                    TEDAVITXT.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    TEDAVITXT.DrawWidth = 2;
                    TEDAVITXT.Value = @"";

                    TEDAVI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 103, 1, 181, 9, false);
                    TEDAVI.Name = "TEDAVI";
                    TEDAVI.FieldType = ReportFieldTypeEnum.ftVariable;
                    TEDAVI.MultiLine = EvetHayirEnum.ehEvet;
                    TEDAVI.TextFont.Size = 8;
                    TEDAVI.Value = @"";

                    DOZ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 190, 1, 208, 6, false);
                    DOZ.Name = "DOZ";
                    DOZ.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOZ.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DOZ.TextFont.Size = 8;
                    DOZ.Value = @"";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 102, 10, 115, 15, false);
                    NewField11.Name = "NewField11";
                    NewField11.TextColor = System.Drawing.Color.Blue;
                    NewField11.TextFont.Size = 8;
                    NewField11.Value = @"Açıklama :";

                    ACIKLAMA = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 115, 10, 188, 14, false);
                    ACIKLAMA.Name = "ACIKLAMA";
                    ACIKLAMA.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACIKLAMA.MultiLine = EvetHayirEnum.ehEvet;
                    ACIKLAMA.TextFont.Size = 8;
                    ACIKLAMA.Value = @"";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 102, 15, 123, 20, false);
                    NewField111.Name = "NewField111";
                    NewField111.TextColor = System.Drawing.Color.Blue;
                    NewField111.TextFont.Size = 8;
                    NewField111.Value = @"Uygulama Şekli :";

                    UYGULAMA = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 124, 15, 175, 19, false);
                    UYGULAMA.Name = "UYGULAMA";
                    UYGULAMA.FieldType = ReportFieldTypeEnum.ftVariable;
                    UYGULAMA.MultiLine = EvetHayirEnum.ehEvet;
                    UYGULAMA.TextFont.Size = 8;
                    UYGULAMA.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField112521.CalcValue = NewField112521.Value;
                    NewField1125211.CalcValue = NewField1125211.Value;
                    NewField1225211.CalcValue = NewField1225211.Value;
                    NewField1141.CalcValue = NewField1141.Value;
                    NewField1151.CalcValue = NewField1151.Value;
                    NewField1161.CalcValue = NewField1161.Value;
                    NewField11421.CalcValue = NewField11421.Value;
                    NewField11521.CalcValue = NewField11521.Value;
                    NewField11611.CalcValue = NewField11611.Value;
                    NewField112411.CalcValue = NewField112411.Value;
                    NewField11411.CalcValue = NewField11411.Value;
                    NewField11511.CalcValue = NewField11511.Value;
                    NewField12611.CalcValue = NewField12611.Value;
                    NewField122411.CalcValue = NewField122411.Value;
                    NewField112511.CalcValue = NewField112511.Value;
                    NewField111611.CalcValue = NewField111611.Value;
                    NewField1114211.CalcValue = NewField1114211.Value;
                    NewField12411.CalcValue = NewField12411.Value;
                    NewField12511.CalcValue = NewField12511.Value;
                    NewField13611.CalcValue = NewField13611.Value;
                    NewField132411.CalcValue = NewField132411.Value;
                    NewField122511.CalcValue = NewField122511.Value;
                    NewField121611.CalcValue = NewField121611.Value;
                    NewField1214211.CalcValue = NewField1214211.Value;
                    TEDAVITXT.CalcValue = TEDAVITXT.Value;
                    TEDAVI.CalcValue = @"";
                    DOZ.CalcValue = @"";
                    NewField11.CalcValue = NewField11.Value;
                    ACIKLAMA.CalcValue = @"";
                    NewField111.CalcValue = NewField111.Value;
                    UYGULAMA.CalcValue = @"";
                    return new TTReportObject[] { NewField112521,NewField1125211,NewField1225211,NewField1141,NewField1151,NewField1161,NewField11421,NewField11521,NewField11611,NewField112411,NewField11411,NewField11511,NewField12611,NewField122411,NewField112511,NewField111611,NewField1114211,NewField12411,NewField12511,NewField13611,NewField132411,NewField122511,NewField121611,NewField1214211,TEDAVITXT,TEDAVI,DOZ,NewField11,ACIKLAMA,NewField111,UYGULAMA};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    if (MyParentReport.MAIN.RepeatCount > 0)
            {
                List<OrderDetail> orderDetailList;
                MyParentReport.drugOrderDetailsListByDate.TryGetValue(MyParentReport.currentDateTime, out orderDetailList);
                var obj = orderDetailList[MyParentReport.mainCounter];
                this.TEDAVI.CalcValue = obj.tedavi;
                this.DOZ.CalcValue = obj.doz;
                this.ACIKLAMA.CalcValue = obj.aciklama;
                this.UYGULAMA.CalcValue = obj.uygulamaSekli;
                MyParentReport.mainCounter += 1;
                this.Visible = EvetHayirEnum.ehEvet;
            }
#endregion MAIN BODY_Script
                }
            }

        }

        public MAINGroup MAIN;

        public partial class PARTCGroup : TTReportGroup
        {
            public NursingApplicationDailyOrderDetailReport MyParentReport
            {
                get { return (NursingApplicationDailyOrderDetailReport)ParentReport; }
            }

            new public PARTCGroupBody Body()
            {
                return (PARTCGroupBody)_body;
            }
            public TTReportField NewField1146111 { get {return Body().NewField1146111;} }
            public TTReportField NewField11125211 { get {return Body().NewField11125211;} }
            public TTReportField NewField111252111 { get {return Body().NewField111252111;} }
            public TTReportField NewField112252111 { get {return Body().NewField112252111;} }
            public TTReportField NewField111411 { get {return Body().NewField111411;} }
            public TTReportField NewField111511 { get {return Body().NewField111511;} }
            public TTReportField NewField111611 { get {return Body().NewField111611;} }
            public TTReportField NewField1114211 { get {return Body().NewField1114211;} }
            public TTReportField NewField1115211 { get {return Body().NewField1115211;} }
            public TTReportField NewField1116111 { get {return Body().NewField1116111;} }
            public TTReportField NewField11124111 { get {return Body().NewField11124111;} }
            public TTReportField NewField1114111 { get {return Body().NewField1114111;} }
            public TTReportField NewField1115111 { get {return Body().NewField1115111;} }
            public TTReportField NewField1126111 { get {return Body().NewField1126111;} }
            public TTReportField NewField11224111 { get {return Body().NewField11224111;} }
            public TTReportField NewField11125111 { get {return Body().NewField11125111;} }
            public TTReportField NewField11116111 { get {return Body().NewField11116111;} }
            public TTReportField NewField111142111 { get {return Body().NewField111142111;} }
            public TTReportField NewField1124111 { get {return Body().NewField1124111;} }
            public TTReportField NewField1125111 { get {return Body().NewField1125111;} }
            public TTReportField NewField1136111 { get {return Body().NewField1136111;} }
            public TTReportField NewField11324111 { get {return Body().NewField11324111;} }
            public TTReportField NewField11225111 { get {return Body().NewField11225111;} }
            public TTReportField NewField11216111 { get {return Body().NewField11216111;} }
            public TTReportField NewField112142111 { get {return Body().NewField112142111;} }
            public TTReportField TEDAVI { get {return Body().TEDAVI;} }
            public TTReportField DOZ_ARALIGI { get {return Body().DOZ_ARALIGI;} }
            public TTReportField DOZ { get {return Body().DOZ;} }
            public TTReportField NewField1 { get {return Body().NewField1;} }
            public PARTCGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTCGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new PARTCGroupBody(this);
            }

            public partial class PARTCGroupBody : TTReportSection
            {
                public NursingApplicationDailyOrderDetailReport MyParentReport
                {
                    get { return (NursingApplicationDailyOrderDetailReport)ParentReport; }
                }
                
                public TTReportField NewField1146111;
                public TTReportField NewField11125211;
                public TTReportField NewField111252111;
                public TTReportField NewField112252111;
                public TTReportField NewField111411;
                public TTReportField NewField111511;
                public TTReportField NewField111611;
                public TTReportField NewField1114211;
                public TTReportField NewField1115211;
                public TTReportField NewField1116111;
                public TTReportField NewField11124111;
                public TTReportField NewField1114111;
                public TTReportField NewField1115111;
                public TTReportField NewField1126111;
                public TTReportField NewField11224111;
                public TTReportField NewField11125111;
                public TTReportField NewField11116111;
                public TTReportField NewField111142111;
                public TTReportField NewField1124111;
                public TTReportField NewField1125111;
                public TTReportField NewField1136111;
                public TTReportField NewField11324111;
                public TTReportField NewField11225111;
                public TTReportField NewField11216111;
                public TTReportField NewField112142111;
                public TTReportField TEDAVI;
                public TTReportField DOZ_ARALIGI;
                public TTReportField DOZ;
                public TTReportField NewField1; 
                public PARTCGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 21;
                    RepeatCount = 0;
                    
                    NewField1146111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 101, 0, 209, 21, false);
                    NewField1146111.Name = "NewField1146111";
                    NewField1146111.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    NewField1146111.DrawWidth = 2;
                    NewField1146111.Value = @"";

                    NewField11125211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 0, 17, 7, false);
                    NewField11125211.Name = "NewField11125211";
                    NewField11125211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11125211.Value = @"";

                    NewField111252111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 7, 17, 14, false);
                    NewField111252111.Name = "NewField111252111";
                    NewField111252111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111252111.Value = @"";

                    NewField112252111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 14, 17, 21, false);
                    NewField112252111.Name = "NewField112252111";
                    NewField112252111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112252111.Value = @"";

                    NewField111411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 77, 0, 89, 7, false);
                    NewField111411.Name = "NewField111411";
                    NewField111411.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111411.Value = @"";

                    NewField111511 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 65, 0, 77, 7, false);
                    NewField111511.Name = "NewField111511";
                    NewField111511.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111511.Value = @"";

                    NewField111611 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 89, 0, 101, 7, false);
                    NewField111611.Name = "NewField111611";
                    NewField111611.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111611.Value = @"";

                    NewField1114211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 0, 53, 7, false);
                    NewField1114211.Name = "NewField1114211";
                    NewField1114211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1114211.Value = @"";

                    NewField1115211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 29, 0, 41, 7, false);
                    NewField1115211.Name = "NewField1115211";
                    NewField1115211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1115211.Value = @"";

                    NewField1116111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 0, 65, 7, false);
                    NewField1116111.Name = "NewField1116111";
                    NewField1116111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1116111.Value = @"";

                    NewField11124111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 0, 29, 7, false);
                    NewField11124111.Name = "NewField11124111";
                    NewField11124111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11124111.Value = @"";

                    NewField1114111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 77, 7, 89, 14, false);
                    NewField1114111.Name = "NewField1114111";
                    NewField1114111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1114111.Value = @"";

                    NewField1115111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 65, 7, 77, 14, false);
                    NewField1115111.Name = "NewField1115111";
                    NewField1115111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1115111.Value = @"";

                    NewField1126111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 89, 7, 101, 14, false);
                    NewField1126111.Name = "NewField1126111";
                    NewField1126111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1126111.Value = @"";

                    NewField11224111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 7, 53, 14, false);
                    NewField11224111.Name = "NewField11224111";
                    NewField11224111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11224111.Value = @"";

                    NewField11125111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 29, 7, 41, 14, false);
                    NewField11125111.Name = "NewField11125111";
                    NewField11125111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11125111.Value = @"";

                    NewField11116111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 7, 65, 14, false);
                    NewField11116111.Name = "NewField11116111";
                    NewField11116111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11116111.Value = @"";

                    NewField111142111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 7, 29, 14, false);
                    NewField111142111.Name = "NewField111142111";
                    NewField111142111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111142111.Value = @"";

                    NewField1124111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 77, 14, 89, 21, false);
                    NewField1124111.Name = "NewField1124111";
                    NewField1124111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1124111.Value = @"";

                    NewField1125111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 65, 14, 77, 21, false);
                    NewField1125111.Name = "NewField1125111";
                    NewField1125111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1125111.Value = @"";

                    NewField1136111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 89, 14, 101, 21, false);
                    NewField1136111.Name = "NewField1136111";
                    NewField1136111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1136111.Value = @"";

                    NewField11324111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 14, 53, 21, false);
                    NewField11324111.Name = "NewField11324111";
                    NewField11324111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11324111.Value = @"";

                    NewField11225111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 29, 14, 41, 21, false);
                    NewField11225111.Name = "NewField11225111";
                    NewField11225111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11225111.Value = @"";

                    NewField11216111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 14, 65, 21, false);
                    NewField11216111.Name = "NewField11216111";
                    NewField11216111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11216111.Value = @"";

                    NewField112142111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 14, 29, 21, false);
                    NewField112142111.Name = "NewField112142111";
                    NewField112142111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112142111.Value = @"";

                    TEDAVI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 103, 2, 180, 11, false);
                    TEDAVI.Name = "TEDAVI";
                    TEDAVI.FieldType = ReportFieldTypeEnum.ftVariable;
                    TEDAVI.MultiLine = EvetHayirEnum.ehEvet;
                    TEDAVI.TextFont.Size = 8;
                    TEDAVI.Value = @"";

                    DOZ_ARALIGI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 228, 1, 237, 6, false);
                    DOZ_ARALIGI.Name = "DOZ_ARALIGI";
                    DOZ_ARALIGI.Visible = EvetHayirEnum.ehHayir;
                    DOZ_ARALIGI.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOZ_ARALIGI.HorzAlign = HorizontalAlignmentEnum.haRight;
                    DOZ_ARALIGI.TextFont.Size = 8;
                    DOZ_ARALIGI.Value = @"";

                    DOZ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 195, 1, 204, 6, false);
                    DOZ.Name = "DOZ";
                    DOZ.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOZ.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DOZ.TextFont.Size = 8;
                    DOZ.Value = @"";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 103, 13, 189, 18, false);
                    NewField1.Name = "NewField1";
                    NewField1.TextColor = System.Drawing.Color.Blue;
                    NewField1.TextFont.Size = 8;
                    NewField1.Value = @"Açıklama :";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1146111.CalcValue = NewField1146111.Value;
                    NewField11125211.CalcValue = NewField11125211.Value;
                    NewField111252111.CalcValue = NewField111252111.Value;
                    NewField112252111.CalcValue = NewField112252111.Value;
                    NewField111411.CalcValue = NewField111411.Value;
                    NewField111511.CalcValue = NewField111511.Value;
                    NewField111611.CalcValue = NewField111611.Value;
                    NewField1114211.CalcValue = NewField1114211.Value;
                    NewField1115211.CalcValue = NewField1115211.Value;
                    NewField1116111.CalcValue = NewField1116111.Value;
                    NewField11124111.CalcValue = NewField11124111.Value;
                    NewField1114111.CalcValue = NewField1114111.Value;
                    NewField1115111.CalcValue = NewField1115111.Value;
                    NewField1126111.CalcValue = NewField1126111.Value;
                    NewField11224111.CalcValue = NewField11224111.Value;
                    NewField11125111.CalcValue = NewField11125111.Value;
                    NewField11116111.CalcValue = NewField11116111.Value;
                    NewField111142111.CalcValue = NewField111142111.Value;
                    NewField1124111.CalcValue = NewField1124111.Value;
                    NewField1125111.CalcValue = NewField1125111.Value;
                    NewField1136111.CalcValue = NewField1136111.Value;
                    NewField11324111.CalcValue = NewField11324111.Value;
                    NewField11225111.CalcValue = NewField11225111.Value;
                    NewField11216111.CalcValue = NewField11216111.Value;
                    NewField112142111.CalcValue = NewField112142111.Value;
                    TEDAVI.CalcValue = @"";
                    DOZ_ARALIGI.CalcValue = @"";
                    DOZ.CalcValue = @"";
                    NewField1.CalcValue = NewField1.Value;
                    return new TTReportObject[] { NewField1146111,NewField11125211,NewField111252111,NewField112252111,NewField111411,NewField111511,NewField111611,NewField1114211,NewField1115211,NewField1116111,NewField11124111,NewField1114111,NewField1115111,NewField1126111,NewField11224111,NewField11125111,NewField11116111,NewField111142111,NewField1124111,NewField1125111,NewField1136111,NewField11324111,NewField11225111,NewField11216111,NewField112142111,TEDAVI,DOZ_ARALIGI,DOZ,NewField1};
                }

                public override void RunScript()
                {
#region PARTC BODY_Script
                    if (MyParentReport.PARTC.RepeatCount > 0)
            {
                List<OrderDetail> orderDetailList;
                MyParentReport.nursingOrderDetailsListByDate.TryGetValue(MyParentReport.currentDateTime, out orderDetailList);
                var obj = orderDetailList[MyParentReport.mainCounter - MyParentReport.drugOrderDetailsListByDate[MyParentReport.currentDateTime].Count];
                this.TEDAVI.CalcValue = obj.tedavi;
                this.DOZ.CalcValue = obj.doz;
                MyParentReport.mainCounter += 1;
                this.Visible = EvetHayirEnum.ehEvet;
            }
#endregion PARTC BODY_Script
                }
            }

        }

        public PARTCGroup PARTC;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public NursingApplicationDailyOrderDetailReport()
        {
            PAGECOUNTHESAPLA = new PAGECOUNTHESAPLAGroup(this,"PAGECOUNTHESAPLA");
            HASTAINFO = new HASTAINFOGroup(PAGECOUNTHESAPLA,"HASTAINFO");
            PARTA = new PARTAGroup(HASTAINFO,"PARTA");
            PARTB = new PARTBGroup(PARTA,"PARTB");
            MAIN = new MAINGroup(PARTB,"MAIN");
            PARTC = new PARTCGroup(PARTA,"PARTC");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "Hemşirelik İşlemleri ID", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter = Parameters.Add("STARTTIME", "", "Başlangıç Zamanı", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENDDATE", "", "Bitiş Zamanı", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            if (parameters.ContainsKey("STARTTIME"))
                _runtimeParameters.STARTTIME = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTTIME"]);
            if (parameters.ContainsKey("ENDDATE"))
                _runtimeParameters.ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ENDDATE"]);
            Name = "NURSINGAPPLICATIONDAILYORDERDETAILREPORT";
            Caption = "HEMŞİRELİK HİZMETLERİ HASTA İZLEM FORMU";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
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
            fd.TextFont.CharSet = 162;
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
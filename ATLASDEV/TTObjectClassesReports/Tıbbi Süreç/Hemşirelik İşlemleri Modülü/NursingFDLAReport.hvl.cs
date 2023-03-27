
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
    public partial class NursingFDLAReport : TTReport
    {
#region Methods
   public class FunctionDetail{
        public string functionName;
            public string D1;
            public string D2;
            public string D3;
            public string D4;
            public string D5;
            public string D6;
            public string D7;
            public string D8;
            public string D9;
            public string D10;
            public string D11;
            public string D12;
            public string D13;
            public string D14;
            public string D15;
            public string D16;
            public string D17;
            public string D18;
            public string D19;
            public string D20;
            public string D21;
            public string D22;
            public string D23;
            public string D24;
            public string D25;
            public string D26;
            public string D27;
            public string D28;
            public string D29;
            public string D30;
        }
        public int mainCounter = 0;
        public DateTime currentDateTime;
        List<FunctionDetail> functionDetailList = new List<FunctionDetail>();
   
#endregion Methods

        public class ReportRuntimeParameters 
        {
            public Guid? TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
            public DateTime? STARTTIME = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
        }

        public partial class HASTAINFOGroup : TTReportGroup
        {
            public NursingFDLAReport MyParentReport
            {
                get { return (NursingFDLAReport)ParentReport; }
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
            public TTReportField LISTCOUNT1 { get {return Footer().LISTCOUNT1;} }
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
                public NursingFDLAReport MyParentReport
                {
                    get { return (NursingFDLAReport)ParentReport; }
                }
                
                public TTReportField ADSOYAD;
                public TTReportField PROTOKOLNO;
                public TTReportField TARIH;
                public TTReportField ODAYATAK;
                public TTReportField SERVIS;
                public TTReportField TEDAVISERVIS;
                public TTReportField DOCTOR;
                public TTReportField LISTCOUNT11; 
                public HASTAINFOGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 6;
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

                    TARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 18, 97, 22, false);
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
                    return new TTReportObject[] { ADSOYAD,PROTOKOLNO,TARIH,ODAYATAK,SERVIS,TEDAVISERVIS,DOCTOR,LISTCOUNT11};
                }

                public override void RunScript()
                {
#region HASTAINFO HEADER_Script
                    TTObjectContext context = new TTObjectContext(true);
                    string sObjectID = ((NursingFDLAReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
                    NursingApplication nursingApplication = (NursingApplication)context.GetObject(new Guid(sObjectID), "NursingApplication");

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



                    List<FunctionDetail> functionDetailList = new List<FunctionDetail>();


                    DateTime startDate = (DateTime)MyParentReport.RuntimeParameters.STARTTIME.Value.Date;

                    var dailyLifeActivities = DailyLifeActivityDefinition.GetDailyLifeActivityDefinition("WHERE ACTIVITYGROUP = 1");
                    foreach (var dailyLifeActivity in dailyLifeActivities)
                    {
                        FunctionDetail newFunctionDetail = new FunctionDetail();
                        List<NursingFunctionalDailyLifeActivity.GetNursingFDLAListByNursingApp_Class> nursingDailyLifeActivities = NursingFunctionalDailyLifeActivity.GetNursingFDLAListByNursingApp(startDate, startDate.AddDays(30), nursingApplication.ObjectID, new Guid(dailyLifeActivity?.ObjectID?.ToString()), "AND THIS.NursingDailyLifeActivity.CURRENTSTATEDEFID <> '" + NursingDailyLifeActivity.States.Cancelled + "'").ToList();
                        newFunctionDetail.functionName = dailyLifeActivity.Name;
                        if (nursingDailyLifeActivities.Exists(x => x.Date.Value.Date == startDate.AddDays(0)))
                            newFunctionDetail.D1 = "X";
                        if (nursingDailyLifeActivities.Exists(x => x.Date.Value.Date == startDate.AddDays(1)))
                            newFunctionDetail.D2 = "X";
                        if (nursingDailyLifeActivities.Exists(x => x.Date.Value.Date == startDate.AddDays(2)))
                            newFunctionDetail.D3 = "X";
                        if (nursingDailyLifeActivities.Exists(x => x.Date.Value.Date == startDate.AddDays(3)))
                            newFunctionDetail.D4 = "X";
                        if (nursingDailyLifeActivities.Exists(x => x.Date.Value.Date == startDate.AddDays(4)))
                            newFunctionDetail.D5 = "X";
                        if (nursingDailyLifeActivities.Exists(x => x.Date.Value.Date == startDate.AddDays(5)))
                            newFunctionDetail.D6 = "X";
                        if (nursingDailyLifeActivities.Exists(x => x.Date.Value.Date == startDate.AddDays(6)))
                            newFunctionDetail.D7 = "X";
                        if (nursingDailyLifeActivities.Exists(x => x.Date.Value.Date == startDate.AddDays(7)))
                            newFunctionDetail.D8 = "X";
                        if (nursingDailyLifeActivities.Exists(x => x.Date.Value.Date == startDate.AddDays(8)))
                            newFunctionDetail.D9 = "X";
                        if (nursingDailyLifeActivities.Exists(x => x.Date.Value.Date == startDate.AddDays(9)))
                            newFunctionDetail.D10 = "X";
                        if (nursingDailyLifeActivities.Exists(x => x.Date.Value.Date == startDate.AddDays(10)))
                            newFunctionDetail.D11 = "X";
                        if (nursingDailyLifeActivities.Exists(x => x.Date.Value.Date == startDate.AddDays(11)))
                            newFunctionDetail.D12 = "X";
                        if (nursingDailyLifeActivities.Exists(x => x.Date.Value.Date == startDate.AddDays(12)))
                            newFunctionDetail.D13 = "X";
                        if (nursingDailyLifeActivities.Exists(x => x.Date.Value.Date == startDate.AddDays(13)))
                            newFunctionDetail.D14 = "X";
                        if (nursingDailyLifeActivities.Exists(x => x.Date.Value.Date == startDate.AddDays(14)))
                            newFunctionDetail.D15 = "X";
                        if (nursingDailyLifeActivities.Exists(x => x.Date.Value.Date == startDate.AddDays(15)))
                            newFunctionDetail.D16 = "X";
                        if (nursingDailyLifeActivities.Exists(x => x.Date.Value.Date == startDate.AddDays(16)))
                            newFunctionDetail.D17 = "X";
                        if (nursingDailyLifeActivities.Exists(x => x.Date.Value.Date == startDate.AddDays(17)))
                            newFunctionDetail.D18 = "X";
                        if (nursingDailyLifeActivities.Exists(x => x.Date.Value.Date == startDate.AddDays(18)))
                            newFunctionDetail.D19 = "X";
                        if (nursingDailyLifeActivities.Exists(x => x.Date.Value.Date == startDate.AddDays(19)))
                            newFunctionDetail.D20 = "X";
                        if (nursingDailyLifeActivities.Exists(x => x.Date.Value.Date == startDate.AddDays(20)))
                            newFunctionDetail.D21 = "X";
                        if (nursingDailyLifeActivities.Exists(x => x.Date.Value.Date == startDate.AddDays(21)))
                            newFunctionDetail.D22 = "X";
                        if (nursingDailyLifeActivities.Exists(x => x.Date.Value.Date == startDate.AddDays(22)))
                            newFunctionDetail.D23 = "X";
                        if (nursingDailyLifeActivities.Exists(x => x.Date.Value.Date == startDate.AddDays(23)))
                            newFunctionDetail.D24 = "X";
                        if (nursingDailyLifeActivities.Exists(x => x.Date.Value.Date == startDate.AddDays(24)))
                            newFunctionDetail.D25 = "X";
                        if (nursingDailyLifeActivities.Exists(x => x.Date.Value.Date == startDate.AddDays(25)))
                            newFunctionDetail.D26 = "X";
                        if (nursingDailyLifeActivities.Exists(x => x.Date.Value.Date == startDate.AddDays(26)))
                            newFunctionDetail.D27 = "X";
                        if (nursingDailyLifeActivities.Exists(x => x.Date.Value.Date == startDate.AddDays(27)))
                            newFunctionDetail.D28 = "X";
                        if (nursingDailyLifeActivities.Exists(x => x.Date.Value.Date == startDate.AddDays(28)))
                            newFunctionDetail.D29 = "X";
                        if (nursingDailyLifeActivities.Exists(x => x.Date.Value.Date == startDate.AddDays(29)))
                            newFunctionDetail.D30 = "X";
                        MyParentReport.functionDetailList.Add(newFunctionDetail);
                    }

                    MyParentReport.mainCounter = 0;
                    MyParentReport.MAIN.RepeatCount = MyParentReport.functionDetailList.Count();
#endregion HASTAINFO HEADER_Script
                }
            }
            public partial class HASTAINFOGroupFooter : TTReportSection
            {
                public NursingFDLAReport MyParentReport
                {
                    get { return (NursingFDLAReport)ParentReport; }
                }
                
                public TTReportField LISTCOUNT1; 
                public HASTAINFOGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 8;
                    ForceNewPage = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    LISTCOUNT1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 149, 1, 171, 5, false);
                    LISTCOUNT1.Name = "LISTCOUNT1";
                    LISTCOUNT1.Visible = EvetHayirEnum.ehHayir;
                    LISTCOUNT1.TextFormat = @"Short Date";
                    LISTCOUNT1.TextFont.Size = 9;
                    LISTCOUNT1.TextFont.CharSet = 162;
                    LISTCOUNT1.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    LISTCOUNT1.CalcValue = LISTCOUNT1.Value;
                    return new TTReportObject[] { LISTCOUNT1};
                }
            }

        }

        public HASTAINFOGroup HASTAINFO;

        public partial class HEADERGroup : TTReportGroup
        {
            public NursingFDLAReport MyParentReport
            {
                get { return (NursingFDLAReport)ParentReport; }
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
            public TTReportField UYGULAMATARIHLERI { get {return Header().UYGULAMATARIHLERI;} }
            public TTReportField D1 { get {return Header().D1;} }
            public TTReportField D2 { get {return Header().D2;} }
            public TTReportField D3 { get {return Header().D3;} }
            public TTReportField D4 { get {return Header().D4;} }
            public TTReportField D5 { get {return Header().D5;} }
            public TTReportField D6 { get {return Header().D6;} }
            public TTReportField D7 { get {return Header().D7;} }
            public TTReportField D8 { get {return Header().D8;} }
            public TTReportField DOCTOR1 { get {return Header().DOCTOR1;} }
            public TTReportField Doktoru1 { get {return Header().Doktoru1;} }
            public TTReportField NewField12114111 { get {return Header().NewField12114111;} }
            public TTReportField D9 { get {return Header().D9;} }
            public TTReportField D10 { get {return Header().D10;} }
            public TTReportField D11 { get {return Header().D11;} }
            public TTReportField D12 { get {return Header().D12;} }
            public TTReportField D13 { get {return Header().D13;} }
            public TTReportField D14 { get {return Header().D14;} }
            public TTReportField D15 { get {return Header().D15;} }
            public TTReportField D16 { get {return Header().D16;} }
            public TTReportField D17 { get {return Header().D17;} }
            public TTReportField D18 { get {return Header().D18;} }
            public TTReportField D19 { get {return Header().D19;} }
            public TTReportField D20 { get {return Header().D20;} }
            public TTReportField D21 { get {return Header().D21;} }
            public TTReportField D22 { get {return Header().D22;} }
            public TTReportField D23 { get {return Header().D23;} }
            public TTReportField D24 { get {return Header().D24;} }
            public TTReportField D25 { get {return Header().D25;} }
            public TTReportField D26 { get {return Header().D26;} }
            public TTReportField D27 { get {return Header().D27;} }
            public TTReportField D28 { get {return Header().D28;} }
            public TTReportField D29 { get {return Header().D29;} }
            public TTReportField D30 { get {return Header().D30;} }
            public TTReportField LOGO { get {return Header().LOGO;} }
            public TTReportField HEMSIRELABEL { get {return Footer().HEMSIRELABEL;} }
            public TTReportField H1 { get {return Footer().H1;} }
            public TTReportField H2 { get {return Footer().H2;} }
            public TTReportField H3 { get {return Footer().H3;} }
            public TTReportField H4 { get {return Footer().H4;} }
            public TTReportField H5 { get {return Footer().H5;} }
            public TTReportField H6 { get {return Footer().H6;} }
            public TTReportField H7 { get {return Footer().H7;} }
            public TTReportField H8 { get {return Footer().H8;} }
            public TTReportField H11 { get {return Footer().H11;} }
            public TTReportField H12 { get {return Footer().H12;} }
            public TTReportField H13 { get {return Footer().H13;} }
            public TTReportField H14 { get {return Footer().H14;} }
            public TTReportField H15 { get {return Footer().H15;} }
            public TTReportField H17 { get {return Footer().H17;} }
            public TTReportField H18 { get {return Footer().H18;} }
            public TTReportField H16 { get {return Footer().H16;} }
            public TTReportField H19 { get {return Footer().H19;} }
            public TTReportField H20 { get {return Footer().H20;} }
            public TTReportField H21 { get {return Footer().H21;} }
            public TTReportField H22 { get {return Footer().H22;} }
            public TTReportField H23 { get {return Footer().H23;} }
            public TTReportField H24 { get {return Footer().H24;} }
            public TTReportField H25 { get {return Footer().H25;} }
            public TTReportField H26 { get {return Footer().H26;} }
            public TTReportField H27 { get {return Footer().H27;} }
            public TTReportField H28 { get {return Footer().H28;} }
            public TTReportField H29 { get {return Footer().H29;} }
            public TTReportField H30 { get {return Footer().H30;} }
            public TTReportField H9 { get {return Footer().H9;} }
            public TTReportField H10 { get {return Footer().H10;} }
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
                public NursingFDLAReport MyParentReport
                {
                    get { return (NursingFDLAReport)ParentReport; }
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
                public TTReportField UYGULAMATARIHLERI;
                public TTReportField D1;
                public TTReportField D2;
                public TTReportField D3;
                public TTReportField D4;
                public TTReportField D5;
                public TTReportField D6;
                public TTReportField D7;
                public TTReportField D8;
                public TTReportField DOCTOR1;
                public TTReportField Doktoru1;
                public TTReportField NewField12114111;
                public TTReportField D9;
                public TTReportField D10;
                public TTReportField D11;
                public TTReportField D12;
                public TTReportField D13;
                public TTReportField D14;
                public TTReportField D15;
                public TTReportField D16;
                public TTReportField D17;
                public TTReportField D18;
                public TTReportField D19;
                public TTReportField D20;
                public TTReportField D21;
                public TTReportField D22;
                public TTReportField D23;
                public TTReportField D24;
                public TTReportField D25;
                public TTReportField D26;
                public TTReportField D27;
                public TTReportField D28;
                public TTReportField D29;
                public TTReportField D30;
                public TTReportField LOGO; 
                public HEADERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 89;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    ADSOYAD1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 97, 54, 156, 59, false);
                    ADSOYAD1.Name = "ADSOYAD1";
                    ADSOYAD1.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADSOYAD1.TextFont.Size = 9;
                    ADSOYAD1.TextFont.CharSet = 162;
                    ADSOYAD1.Value = @"{%HASTAINFO.ADSOYAD%}";

                    NewField11211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 54, 90, 59, false);
                    NewField11211.Name = "NewField11211";
                    NewField11211.TextFont.Bold = true;
                    NewField11211.TextFont.CharSet = 162;
                    NewField11211.Value = @"Adı Soyadı";

                    NewField11411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 94, 55, 96, 59, false);
                    NewField11411.Name = "NewField11411";
                    NewField11411.TextFont.Name = "Courier New";
                    NewField11411.TextFont.CharSet = 162;
                    NewField11411.Value = @":";

                    PROTOKOLNO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 97, 49, 134, 53, false);
                    PROTOKOLNO1.Name = "PROTOKOLNO1";
                    PROTOKOLNO1.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROTOKOLNO1.TextFont.Size = 9;
                    PROTOKOLNO1.TextFont.CharSet = 162;
                    PROTOKOLNO1.Value = @"{%HASTAINFO.PROTOKOLNO%}";

                    NewField112211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 49, 90, 53, false);
                    NewField112211.Name = "NewField112211";
                    NewField112211.TextFont.Size = 9;
                    NewField112211.TextFont.Bold = true;
                    NewField112211.TextFont.CharSet = 162;
                    NewField112211.Value = @"Kabul No";

                    TARIH1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 97, 65, 156, 69, false);
                    TARIH1.Name = "TARIH1";
                    TARIH1.FieldType = ReportFieldTypeEnum.ftExpression;
                    TARIH1.TextFormat = @"dd/MM/yyyy";
                    TARIH1.TextFont.Size = 9;
                    TARIH1.TextFont.CharSet = 162;
                    TARIH1.Value = @"DateTime.Now.ToShortDateString()";

                    NewField112711 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 65, 90, 69, false);
                    NewField112711.Name = "NewField112711";
                    NewField112711.TextFont.Size = 9;
                    NewField112711.TextFont.Bold = true;
                    NewField112711.TextFont.CharSet = 162;
                    NewField112711.Value = @"Tarih";

                    NewField111411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 94, 49, 96, 53, false);
                    NewField111411.Name = "NewField111411";
                    NewField111411.TextFont.Name = "Courier New";
                    NewField111411.TextFont.CharSet = 162;
                    NewField111411.Value = @":";

                    NewField1114111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 94, 65, 96, 69, false);
                    NewField1114111.Name = "NewField1114111";
                    NewField1114111.TextFont.Name = "Courier New";
                    NewField1114111.TextFont.CharSet = 162;
                    NewField1114111.Value = @":";

                    ODAYATAK1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 199, 59, 258, 63, false);
                    ODAYATAK1.Name = "ODAYATAK1";
                    ODAYATAK1.FieldType = ReportFieldTypeEnum.ftVariable;
                    ODAYATAK1.TextFont.Size = 9;
                    ODAYATAK1.TextFont.CharSet = 162;
                    ODAYATAK1.Value = @"{%HASTAINFO.ODAYATAK%}";

                    NewField1117211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 164, 59, 192, 63, false);
                    NewField1117211.Name = "NewField1117211";
                    NewField1117211.TextFont.Size = 9;
                    NewField1117211.TextFont.Bold = true;
                    NewField1117211.TextFont.CharSet = 162;
                    NewField1117211.Value = @"Oda/Yatak";

                    NewField11114111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 196, 59, 198, 63, false);
                    NewField11114111.Name = "NewField11114111";
                    NewField11114111.TextFont.Name = "Courier New";
                    NewField11114111.TextFont.CharSet = 162;
                    NewField11114111.Value = @":";

                    SERVIS1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 199, 54, 258, 58, false);
                    SERVIS1.Name = "SERVIS1";
                    SERVIS1.FieldType = ReportFieldTypeEnum.ftVariable;
                    SERVIS1.TextFont.Size = 9;
                    SERVIS1.TextFont.CharSet = 162;
                    SERVIS1.Value = @"{%HASTAINFO.SERVIS%}";

                    NewField11127111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 164, 54, 192, 58, false);
                    NewField11127111.Name = "NewField11127111";
                    NewField11127111.TextFont.Size = 9;
                    NewField11127111.TextFont.Bold = true;
                    NewField11127111.TextFont.CharSet = 162;
                    NewField11127111.Value = @"Servis/Oda Grubu";

                    NewField111141111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 196, 54, 198, 58, false);
                    NewField111141111.Name = "NewField111141111";
                    NewField111141111.TextFont.Name = "Courier New";
                    NewField111141111.TextFont.CharSet = 162;
                    NewField111141111.Value = @":";

                    TEDAVISERVIS1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 97, 60, 156, 64, false);
                    TEDAVISERVIS1.Name = "TEDAVISERVIS1";
                    TEDAVISERVIS1.FieldType = ReportFieldTypeEnum.ftVariable;
                    TEDAVISERVIS1.TextFont.Size = 9;
                    TEDAVISERVIS1.TextFont.CharSet = 162;
                    TEDAVISERVIS1.Value = @"{%HASTAINFO.TEDAVISERVIS%}";

                    NewField111172111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 60, 93, 64, false);
                    NewField111172111.Name = "NewField111172111";
                    NewField111172111.TextFont.Size = 9;
                    NewField111172111.TextFont.Bold = true;
                    NewField111172111.TextFont.CharSet = 162;
                    NewField111172111.Value = @"Tedavi Gördüğü Servis";

                    NewField1111141111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 94, 60, 96, 64, false);
                    NewField1111141111.Name = "NewField1111141111";
                    NewField1111141111.TextFont.Name = "Courier New";
                    NewField1111141111.TextFont.CharSet = 162;
                    NewField1111141111.Value = @":";

                    BASLIK1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 41, 260, 47, false);
                    BASLIK1111.Name = "BASLIK1111";
                    BASLIK1111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BASLIK1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BASLIK1111.TextFont.Name = "Calibri";
                    BASLIK1111.TextFont.Size = 12;
                    BASLIK1111.TextFont.Bold = true;
                    BASLIK1111.TextFont.CharSet = 162;
                    BASLIK1111.Value = @"HEMŞİRELİK BAKIM İZLEM FORMU";

                    XXXXXXBASLIK11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 3, 260, 38, false);
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

                    UYGULAMATARIHLERI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 79, 56, 89, false);
                    UYGULAMATARIHLERI.Name = "UYGULAMATARIHLERI";
                    UYGULAMATARIHLERI.DrawStyle = DrawStyleConstants.vbSolid;
                    UYGULAMATARIHLERI.TextFormat = @"dd/MM/yyyy";
                    UYGULAMATARIHLERI.MultiLine = EvetHayirEnum.ehEvet;
                    UYGULAMATARIHLERI.WordBreak = EvetHayirEnum.ehEvet;
                    UYGULAMATARIHLERI.TextFont.Bold = true;
                    UYGULAMATARIHLERI.TextFont.CharSet = 162;
                    UYGULAMATARIHLERI.Value = @"Uygulama Tarihleri";

                    D1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 56, 79, 64, 89, false);
                    D1.Name = "D1";
                    D1.DrawStyle = DrawStyleConstants.vbSolid;
                    D1.FieldType = ReportFieldTypeEnum.ftExpression;
                    D1.MultiLine = EvetHayirEnum.ehEvet;
                    D1.WordBreak = EvetHayirEnum.ehEvet;
                    D1.TextFont.Size = 9;
                    D1.TextFont.Bold = true;
                    D1.TextFont.CharSet = 162;
                    D1.Value = @"MyParentReport.RuntimeParameters.STARTTIME.Value.Day + ""."" + MyParentReport.RuntimeParameters.STARTTIME.Value.Month + "".\r\n"" + MyParentReport.RuntimeParameters.STARTTIME.Value.Year";

                    D2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 64, 79, 72, 89, false);
                    D2.Name = "D2";
                    D2.DrawStyle = DrawStyleConstants.vbSolid;
                    D2.FieldType = ReportFieldTypeEnum.ftExpression;
                    D2.MultiLine = EvetHayirEnum.ehEvet;
                    D2.WordBreak = EvetHayirEnum.ehEvet;
                    D2.TextFont.Size = 9;
                    D2.TextFont.Bold = true;
                    D2.TextFont.CharSet = 162;
                    D2.Value = @"MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(1).Day + ""."" + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(1).Month + "".\r\n"" + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(1).Year";

                    D3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 72, 79, 80, 89, false);
                    D3.Name = "D3";
                    D3.DrawStyle = DrawStyleConstants.vbSolid;
                    D3.FieldType = ReportFieldTypeEnum.ftExpression;
                    D3.MultiLine = EvetHayirEnum.ehEvet;
                    D3.WordBreak = EvetHayirEnum.ehEvet;
                    D3.TextFont.Size = 9;
                    D3.TextFont.Bold = true;
                    D3.TextFont.CharSet = 162;
                    D3.Value = @"MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(2).Day + ""."" + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(2).Month + "".\r\n"" + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(2).Year";

                    D4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 80, 79, 88, 89, false);
                    D4.Name = "D4";
                    D4.DrawStyle = DrawStyleConstants.vbSolid;
                    D4.FieldType = ReportFieldTypeEnum.ftExpression;
                    D4.MultiLine = EvetHayirEnum.ehEvet;
                    D4.WordBreak = EvetHayirEnum.ehEvet;
                    D4.TextFont.Size = 9;
                    D4.TextFont.Bold = true;
                    D4.TextFont.CharSet = 162;
                    D4.Value = @"MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(3).Day + ""."" + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(3).Month + "".\r\n"" + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(3).Year";

                    D5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 88, 79, 96, 89, false);
                    D5.Name = "D5";
                    D5.DrawStyle = DrawStyleConstants.vbSolid;
                    D5.FieldType = ReportFieldTypeEnum.ftExpression;
                    D5.MultiLine = EvetHayirEnum.ehEvet;
                    D5.WordBreak = EvetHayirEnum.ehEvet;
                    D5.TextFont.Size = 9;
                    D5.TextFont.Bold = true;
                    D5.TextFont.CharSet = 162;
                    D5.Value = @"MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(4).Day + ""."" + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(4).Month + "".\r\n"" + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(4).Year";

                    D6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 96, 79, 104, 89, false);
                    D6.Name = "D6";
                    D6.DrawStyle = DrawStyleConstants.vbSolid;
                    D6.FieldType = ReportFieldTypeEnum.ftExpression;
                    D6.MultiLine = EvetHayirEnum.ehEvet;
                    D6.WordBreak = EvetHayirEnum.ehEvet;
                    D6.TextFont.Size = 9;
                    D6.TextFont.Bold = true;
                    D6.TextFont.CharSet = 162;
                    D6.Value = @"MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(5).Day + ""."" + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(5).Month + "".\r\n"" + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(5).Year";

                    D7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 104, 79, 112, 89, false);
                    D7.Name = "D7";
                    D7.DrawStyle = DrawStyleConstants.vbSolid;
                    D7.FieldType = ReportFieldTypeEnum.ftExpression;
                    D7.MultiLine = EvetHayirEnum.ehEvet;
                    D7.WordBreak = EvetHayirEnum.ehEvet;
                    D7.TextFont.Size = 9;
                    D7.TextFont.Bold = true;
                    D7.TextFont.CharSet = 162;
                    D7.Value = @"MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(6).Day + ""."" + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(6).Month + "".\r\n"" + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(6).Year";

                    D8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 112, 79, 120, 89, false);
                    D8.Name = "D8";
                    D8.DrawStyle = DrawStyleConstants.vbSolid;
                    D8.FieldType = ReportFieldTypeEnum.ftExpression;
                    D8.MultiLine = EvetHayirEnum.ehEvet;
                    D8.WordBreak = EvetHayirEnum.ehEvet;
                    D8.TextFont.Size = 9;
                    D8.TextFont.Bold = true;
                    D8.TextFont.CharSet = 162;
                    D8.Value = @"MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(7).Day + ""."" + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(7).Month + "".\r\n"" + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(7).Year";

                    DOCTOR1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 199, 64, 258, 68, false);
                    DOCTOR1.Name = "DOCTOR1";
                    DOCTOR1.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOCTOR1.TextFormat = @"Short Date";
                    DOCTOR1.TextFont.Size = 9;
                    DOCTOR1.TextFont.CharSet = 162;
                    DOCTOR1.Value = @"{%HASTAINFO.DOCTOR%}";

                    Doktoru1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 164, 64, 192, 68, false);
                    Doktoru1.Name = "Doktoru1";
                    Doktoru1.TextFont.Size = 9;
                    Doktoru1.TextFont.Bold = true;
                    Doktoru1.TextFont.CharSet = 162;
                    Doktoru1.Value = @"Doktoru";

                    NewField12114111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 196, 64, 198, 68, false);
                    NewField12114111.Name = "NewField12114111";
                    NewField12114111.TextFont.Name = "Courier New";
                    NewField12114111.TextFont.CharSet = 162;
                    NewField12114111.Value = @":";

                    D9 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 120, 79, 128, 89, false);
                    D9.Name = "D9";
                    D9.DrawStyle = DrawStyleConstants.vbSolid;
                    D9.FieldType = ReportFieldTypeEnum.ftExpression;
                    D9.MultiLine = EvetHayirEnum.ehEvet;
                    D9.WordBreak = EvetHayirEnum.ehEvet;
                    D9.TextFont.Size = 9;
                    D9.TextFont.Bold = true;
                    D9.TextFont.CharSet = 162;
                    D9.Value = @"MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(8).Day + ""."" + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(8).Month + "".\r\n"" + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(8).Year";

                    D10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 128, 79, 136, 89, false);
                    D10.Name = "D10";
                    D10.DrawStyle = DrawStyleConstants.vbSolid;
                    D10.FieldType = ReportFieldTypeEnum.ftExpression;
                    D10.MultiLine = EvetHayirEnum.ehEvet;
                    D10.WordBreak = EvetHayirEnum.ehEvet;
                    D10.TextFont.Size = 9;
                    D10.TextFont.Bold = true;
                    D10.TextFont.CharSet = 162;
                    D10.Value = @"MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(9).Day + ""."" + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(9).Month + "".\r\n"" + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(9).Year";

                    D11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 136, 79, 144, 89, false);
                    D11.Name = "D11";
                    D11.DrawStyle = DrawStyleConstants.vbSolid;
                    D11.FieldType = ReportFieldTypeEnum.ftExpression;
                    D11.MultiLine = EvetHayirEnum.ehEvet;
                    D11.WordBreak = EvetHayirEnum.ehEvet;
                    D11.TextFont.Size = 9;
                    D11.TextFont.Bold = true;
                    D11.TextFont.CharSet = 162;
                    D11.Value = @"MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(10).Day + ""."" + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(10).Month + "".\r\n"" + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(10).Year";

                    D12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 144, 79, 152, 89, false);
                    D12.Name = "D12";
                    D12.DrawStyle = DrawStyleConstants.vbSolid;
                    D12.FieldType = ReportFieldTypeEnum.ftExpression;
                    D12.MultiLine = EvetHayirEnum.ehEvet;
                    D12.WordBreak = EvetHayirEnum.ehEvet;
                    D12.TextFont.Size = 9;
                    D12.TextFont.Bold = true;
                    D12.TextFont.CharSet = 162;
                    D12.Value = @"MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(11).Day + ""."" + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(11).Month + "".\r\n"" + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(11).Year";

                    D13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 79, 160, 89, false);
                    D13.Name = "D13";
                    D13.DrawStyle = DrawStyleConstants.vbSolid;
                    D13.FieldType = ReportFieldTypeEnum.ftExpression;
                    D13.MultiLine = EvetHayirEnum.ehEvet;
                    D13.WordBreak = EvetHayirEnum.ehEvet;
                    D13.TextFont.Size = 9;
                    D13.TextFont.Bold = true;
                    D13.TextFont.CharSet = 162;
                    D13.Value = @"MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(12).Day + ""."" + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(12).Month + "".\r\n"" + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(12).Year";

                    D14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 79, 168, 89, false);
                    D14.Name = "D14";
                    D14.DrawStyle = DrawStyleConstants.vbSolid;
                    D14.FieldType = ReportFieldTypeEnum.ftExpression;
                    D14.MultiLine = EvetHayirEnum.ehEvet;
                    D14.WordBreak = EvetHayirEnum.ehEvet;
                    D14.TextFont.Size = 9;
                    D14.TextFont.Bold = true;
                    D14.TextFont.CharSet = 162;
                    D14.Value = @"MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(13).Day + ""."" + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(13).Month + "".\r\n"" + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(13).Year";

                    D15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 168, 79, 176, 89, false);
                    D15.Name = "D15";
                    D15.DrawStyle = DrawStyleConstants.vbSolid;
                    D15.FieldType = ReportFieldTypeEnum.ftExpression;
                    D15.MultiLine = EvetHayirEnum.ehEvet;
                    D15.WordBreak = EvetHayirEnum.ehEvet;
                    D15.TextFont.Size = 9;
                    D15.TextFont.Bold = true;
                    D15.TextFont.CharSet = 162;
                    D15.Value = @"MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(14).Day + ""."" + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(14).Month + "".\r\n"" + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(14).Year";

                    D16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 176, 79, 184, 89, false);
                    D16.Name = "D16";
                    D16.DrawStyle = DrawStyleConstants.vbSolid;
                    D16.FieldType = ReportFieldTypeEnum.ftExpression;
                    D16.MultiLine = EvetHayirEnum.ehEvet;
                    D16.WordBreak = EvetHayirEnum.ehEvet;
                    D16.TextFont.Size = 9;
                    D16.TextFont.Bold = true;
                    D16.TextFont.CharSet = 162;
                    D16.Value = @"MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(15).Day + ""."" + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(15).Month + "".\r\n"" + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(15).Year";

                    D17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 184, 79, 192, 89, false);
                    D17.Name = "D17";
                    D17.DrawStyle = DrawStyleConstants.vbSolid;
                    D17.FieldType = ReportFieldTypeEnum.ftExpression;
                    D17.MultiLine = EvetHayirEnum.ehEvet;
                    D17.WordBreak = EvetHayirEnum.ehEvet;
                    D17.TextFont.Size = 9;
                    D17.TextFont.Bold = true;
                    D17.TextFont.CharSet = 162;
                    D17.Value = @"MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(16).Day + ""."" + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(16).Month + "".\r\n"" + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(16).Year";

                    D18 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 192, 79, 200, 89, false);
                    D18.Name = "D18";
                    D18.DrawStyle = DrawStyleConstants.vbSolid;
                    D18.FieldType = ReportFieldTypeEnum.ftExpression;
                    D18.MultiLine = EvetHayirEnum.ehEvet;
                    D18.WordBreak = EvetHayirEnum.ehEvet;
                    D18.TextFont.Size = 9;
                    D18.TextFont.Bold = true;
                    D18.TextFont.CharSet = 162;
                    D18.Value = @"MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(17).Day + ""."" + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(17).Month + "".\r\n"" + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(17).Year";

                    D19 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 200, 79, 208, 89, false);
                    D19.Name = "D19";
                    D19.DrawStyle = DrawStyleConstants.vbSolid;
                    D19.FieldType = ReportFieldTypeEnum.ftExpression;
                    D19.MultiLine = EvetHayirEnum.ehEvet;
                    D19.WordBreak = EvetHayirEnum.ehEvet;
                    D19.TextFont.Size = 9;
                    D19.TextFont.Bold = true;
                    D19.TextFont.CharSet = 162;
                    D19.Value = @"MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(18).Day + ""."" + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(18).Month + "".\r\n"" + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(18).Year";

                    D20 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 208, 79, 216, 89, false);
                    D20.Name = "D20";
                    D20.DrawStyle = DrawStyleConstants.vbSolid;
                    D20.FieldType = ReportFieldTypeEnum.ftExpression;
                    D20.MultiLine = EvetHayirEnum.ehEvet;
                    D20.WordBreak = EvetHayirEnum.ehEvet;
                    D20.TextFont.Size = 9;
                    D20.TextFont.Bold = true;
                    D20.TextFont.CharSet = 162;
                    D20.Value = @"MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(19).Day + ""."" + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(19).Month + "".\r\n"" + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(19).Year";

                    D21 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 216, 79, 224, 89, false);
                    D21.Name = "D21";
                    D21.DrawStyle = DrawStyleConstants.vbSolid;
                    D21.FieldType = ReportFieldTypeEnum.ftExpression;
                    D21.MultiLine = EvetHayirEnum.ehEvet;
                    D21.WordBreak = EvetHayirEnum.ehEvet;
                    D21.TextFont.Size = 9;
                    D21.TextFont.Bold = true;
                    D21.TextFont.CharSet = 162;
                    D21.Value = @"MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(20).Day + ""."" + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(20).Month + "".\r\n"" + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(20).Year";

                    D22 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 224, 79, 232, 89, false);
                    D22.Name = "D22";
                    D22.DrawStyle = DrawStyleConstants.vbSolid;
                    D22.FieldType = ReportFieldTypeEnum.ftExpression;
                    D22.MultiLine = EvetHayirEnum.ehEvet;
                    D22.WordBreak = EvetHayirEnum.ehEvet;
                    D22.TextFont.Size = 9;
                    D22.TextFont.Bold = true;
                    D22.TextFont.CharSet = 162;
                    D22.Value = @"MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(21).Day + ""."" + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(21).Month + "".\r\n"" + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(21).Year";

                    D23 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 232, 79, 240, 89, false);
                    D23.Name = "D23";
                    D23.DrawStyle = DrawStyleConstants.vbSolid;
                    D23.FieldType = ReportFieldTypeEnum.ftExpression;
                    D23.MultiLine = EvetHayirEnum.ehEvet;
                    D23.WordBreak = EvetHayirEnum.ehEvet;
                    D23.TextFont.Size = 9;
                    D23.TextFont.Bold = true;
                    D23.TextFont.CharSet = 162;
                    D23.Value = @"MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(22).Day + ""."" + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(22).Month + "".\r\n"" + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(22).Year";

                    D24 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 240, 79, 248, 89, false);
                    D24.Name = "D24";
                    D24.DrawStyle = DrawStyleConstants.vbSolid;
                    D24.FieldType = ReportFieldTypeEnum.ftExpression;
                    D24.MultiLine = EvetHayirEnum.ehEvet;
                    D24.WordBreak = EvetHayirEnum.ehEvet;
                    D24.TextFont.Size = 9;
                    D24.TextFont.Bold = true;
                    D24.TextFont.CharSet = 162;
                    D24.Value = @"MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(23).Day + ""."" + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(23).Month + "".\r\n"" + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(23).Year";

                    D25 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 248, 79, 256, 89, false);
                    D25.Name = "D25";
                    D25.DrawStyle = DrawStyleConstants.vbSolid;
                    D25.FieldType = ReportFieldTypeEnum.ftExpression;
                    D25.MultiLine = EvetHayirEnum.ehEvet;
                    D25.WordBreak = EvetHayirEnum.ehEvet;
                    D25.TextFont.Size = 9;
                    D25.TextFont.Bold = true;
                    D25.TextFont.CharSet = 162;
                    D25.Value = @"MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(24).Day + ""."" + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(24).Month + "".\r\n"" + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(24).Year";

                    D26 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 256, 79, 264, 89, false);
                    D26.Name = "D26";
                    D26.DrawStyle = DrawStyleConstants.vbSolid;
                    D26.FieldType = ReportFieldTypeEnum.ftExpression;
                    D26.MultiLine = EvetHayirEnum.ehEvet;
                    D26.WordBreak = EvetHayirEnum.ehEvet;
                    D26.TextFont.Size = 9;
                    D26.TextFont.Bold = true;
                    D26.TextFont.CharSet = 162;
                    D26.Value = @"MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(25).Day + ""."" + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(25).Month + "".\r\n"" + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(25).Year";

                    D27 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 264, 79, 272, 89, false);
                    D27.Name = "D27";
                    D27.DrawStyle = DrawStyleConstants.vbSolid;
                    D27.FieldType = ReportFieldTypeEnum.ftExpression;
                    D27.MultiLine = EvetHayirEnum.ehEvet;
                    D27.WordBreak = EvetHayirEnum.ehEvet;
                    D27.TextFont.Size = 9;
                    D27.TextFont.Bold = true;
                    D27.TextFont.CharSet = 162;
                    D27.Value = @"MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(26).Day + ""."" + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(26).Month + "".\r\n"" + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(26).Year";

                    D28 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 272, 79, 280, 89, false);
                    D28.Name = "D28";
                    D28.DrawStyle = DrawStyleConstants.vbSolid;
                    D28.FieldType = ReportFieldTypeEnum.ftExpression;
                    D28.MultiLine = EvetHayirEnum.ehEvet;
                    D28.WordBreak = EvetHayirEnum.ehEvet;
                    D28.TextFont.Size = 9;
                    D28.TextFont.Bold = true;
                    D28.TextFont.CharSet = 162;
                    D28.Value = @"MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(27).Day + ""."" + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(27).Month + "".\r\n"" + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(27).Year";

                    D29 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 280, 79, 288, 89, false);
                    D29.Name = "D29";
                    D29.DrawStyle = DrawStyleConstants.vbSolid;
                    D29.FieldType = ReportFieldTypeEnum.ftExpression;
                    D29.MultiLine = EvetHayirEnum.ehEvet;
                    D29.WordBreak = EvetHayirEnum.ehEvet;
                    D29.TextFont.Size = 9;
                    D29.TextFont.Bold = true;
                    D29.TextFont.CharSet = 162;
                    D29.Value = @"MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(28).Day + ""."" + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(28).Month + "".\r\n"" + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(28).Year";

                    D30 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 288, 79, 296, 89, false);
                    D30.Name = "D30";
                    D30.DrawStyle = DrawStyleConstants.vbSolid;
                    D30.FieldType = ReportFieldTypeEnum.ftExpression;
                    D30.MultiLine = EvetHayirEnum.ehEvet;
                    D30.WordBreak = EvetHayirEnum.ehEvet;
                    D30.TextFont.Size = 9;
                    D30.TextFont.Bold = true;
                    D30.TextFont.CharSet = 162;
                    D30.Value = @"MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(29).Day + ""."" + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(29).Month + "".\r\n"" + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(29).Year";

                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 26, 4, 56, 27, false);
                    LOGO.Name = "LOGO";
                    LOGO.FieldType = ReportFieldTypeEnum.ftOLE;
                    LOGO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    LOGO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LOGO.ExpandTabs = EvetHayirEnum.ehEvet;
                    LOGO.ObjectDefName = "HospitalEmblemDefinition";
                    LOGO.DataMember = "EMBLEM";
                    LOGO.TextFont.Name = "Courier New";
                    LOGO.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ADSOYAD1.CalcValue = MyParentReport.HASTAINFO.ADSOYAD.CalcValue;
                    NewField11211.CalcValue = NewField11211.Value;
                    NewField11411.CalcValue = NewField11411.Value;
                    PROTOKOLNO1.CalcValue = MyParentReport.HASTAINFO.PROTOKOLNO.CalcValue;
                    NewField112211.CalcValue = NewField112211.Value;
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
                    UYGULAMATARIHLERI.CalcValue = UYGULAMATARIHLERI.Value;
                    DOCTOR1.CalcValue = MyParentReport.HASTAINFO.DOCTOR.FormattedValue;
                    Doktoru1.CalcValue = Doktoru1.Value;
                    NewField12114111.CalcValue = NewField12114111.Value;
                    LOGO.CalcValue = @"";
                    TARIH1.CalcValue = DateTime.Now.ToShortDateString();
                    XXXXXXBASLIK11.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    D1.CalcValue = MyParentReport.RuntimeParameters.STARTTIME.Value.Day + "." + MyParentReport.RuntimeParameters.STARTTIME.Value.Month + ".\r\n" + MyParentReport.RuntimeParameters.STARTTIME.Value.Year;
                    D2.CalcValue = MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(1).Day + "." + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(1).Month + ".\r\n" + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(1).Year;
                    D3.CalcValue = MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(2).Day + "." + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(2).Month + ".\r\n" + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(2).Year;
                    D4.CalcValue = MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(3).Day + "." + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(3).Month + ".\r\n" + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(3).Year;
                    D5.CalcValue = MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(4).Day + "." + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(4).Month + ".\r\n" + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(4).Year;
                    D6.CalcValue = MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(5).Day + "." + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(5).Month + ".\r\n" + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(5).Year;
                    D7.CalcValue = MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(6).Day + "." + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(6).Month + ".\r\n" + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(6).Year;
                    D8.CalcValue = MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(7).Day + "." + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(7).Month + ".\r\n" + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(7).Year;
                    D9.CalcValue = MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(8).Day + "." + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(8).Month + ".\r\n" + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(8).Year;
                    D10.CalcValue = MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(9).Day + "." + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(9).Month + ".\r\n" + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(9).Year;
                    D11.CalcValue = MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(10).Day + "." + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(10).Month + ".\r\n" + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(10).Year;
                    D12.CalcValue = MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(11).Day + "." + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(11).Month + ".\r\n" + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(11).Year;
                    D13.CalcValue = MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(12).Day + "." + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(12).Month + ".\r\n" + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(12).Year;
                    D14.CalcValue = MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(13).Day + "." + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(13).Month + ".\r\n" + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(13).Year;
                    D15.CalcValue = MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(14).Day + "." + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(14).Month + ".\r\n" + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(14).Year;
                    D16.CalcValue = MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(15).Day + "." + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(15).Month + ".\r\n" + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(15).Year;
                    D17.CalcValue = MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(16).Day + "." + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(16).Month + ".\r\n" + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(16).Year;
                    D18.CalcValue = MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(17).Day + "." + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(17).Month + ".\r\n" + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(17).Year;
                    D19.CalcValue = MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(18).Day + "." + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(18).Month + ".\r\n" + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(18).Year;
                    D20.CalcValue = MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(19).Day + "." + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(19).Month + ".\r\n" + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(19).Year;
                    D21.CalcValue = MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(20).Day + "." + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(20).Month + ".\r\n" + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(20).Year;
                    D22.CalcValue = MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(21).Day + "." + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(21).Month + ".\r\n" + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(21).Year;
                    D23.CalcValue = MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(22).Day + "." + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(22).Month + ".\r\n" + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(22).Year;
                    D24.CalcValue = MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(23).Day + "." + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(23).Month + ".\r\n" + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(23).Year;
                    D25.CalcValue = MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(24).Day + "." + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(24).Month + ".\r\n" + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(24).Year;
                    D26.CalcValue = MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(25).Day + "." + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(25).Month + ".\r\n" + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(25).Year;
                    D27.CalcValue = MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(26).Day + "." + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(26).Month + ".\r\n" + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(26).Year;
                    D28.CalcValue = MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(27).Day + "." + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(27).Month + ".\r\n" + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(27).Year;
                    D29.CalcValue = MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(28).Day + "." + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(28).Month + ".\r\n" + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(28).Year;
                    D30.CalcValue = MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(29).Day + "." + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(29).Month + ".\r\n" + MyParentReport.RuntimeParameters.STARTTIME.Value.AddDays(29).Year;
                    return new TTReportObject[] { ADSOYAD1,NewField11211,NewField11411,PROTOKOLNO1,NewField112211,NewField112711,NewField111411,NewField1114111,ODAYATAK1,NewField1117211,NewField11114111,SERVIS1,NewField11127111,NewField111141111,TEDAVISERVIS1,NewField111172111,NewField1111141111,BASLIK1111,UYGULAMATARIHLERI,DOCTOR1,Doktoru1,NewField12114111,LOGO,TARIH1,XXXXXXBASLIK11,D1,D2,D3,D4,D5,D6,D7,D8,D9,D10,D11,D12,D13,D14,D15,D16,D17,D18,D19,D20,D21,D22,D23,D24,D25,D26,D27,D28,D29,D30};
                }

                public override void RunScript()
                {
#region HEADER HEADER_Script
                    this.LOGO.CalcValue = TTObjectClasses.Common.GetCurrentHospitalLogo();
#endregion HEADER HEADER_Script
                }
            }
            public partial class HEADERGroupFooter : TTReportSection
            {
                public NursingFDLAReport MyParentReport
                {
                    get { return (NursingFDLAReport)ParentReport; }
                }
                
                public TTReportField HEMSIRELABEL;
                public TTReportField H1;
                public TTReportField H2;
                public TTReportField H3;
                public TTReportField H4;
                public TTReportField H5;
                public TTReportField H6;
                public TTReportField H7;
                public TTReportField H8;
                public TTReportField H11;
                public TTReportField H12;
                public TTReportField H13;
                public TTReportField H14;
                public TTReportField H15;
                public TTReportField H17;
                public TTReportField H18;
                public TTReportField H16;
                public TTReportField H19;
                public TTReportField H20;
                public TTReportField H21;
                public TTReportField H22;
                public TTReportField H23;
                public TTReportField H24;
                public TTReportField H25;
                public TTReportField H26;
                public TTReportField H27;
                public TTReportField H28;
                public TTReportField H29;
                public TTReportField H30;
                public TTReportField H9;
                public TTReportField H10; 
                public HEADERGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 6;
                    RepeatCount = 0;
                    
                    HEMSIRELABEL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 0, 56, 5, false);
                    HEMSIRELABEL.Name = "HEMSIRELABEL";
                    HEMSIRELABEL.DrawStyle = DrawStyleConstants.vbSolid;
                    HEMSIRELABEL.TextFormat = @"Standard";
                    HEMSIRELABEL.Value = @"Uygulayan Hemşire";

                    H1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 56, 0, 64, 5, false);
                    H1.Name = "H1";
                    H1.DrawStyle = DrawStyleConstants.vbSolid;
                    H1.FieldType = ReportFieldTypeEnum.ftVariable;
                    H1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    H1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    H1.TextFont.Size = 8;
                    H1.TextFont.CharSet = 162;
                    H1.Value = @"";

                    H2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 64, 0, 72, 5, false);
                    H2.Name = "H2";
                    H2.DrawStyle = DrawStyleConstants.vbSolid;
                    H2.FieldType = ReportFieldTypeEnum.ftVariable;
                    H2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    H2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    H2.TextFont.Size = 8;
                    H2.TextFont.CharSet = 162;
                    H2.Value = @"";

                    H3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 72, 0, 80, 5, false);
                    H3.Name = "H3";
                    H3.DrawStyle = DrawStyleConstants.vbSolid;
                    H3.FieldType = ReportFieldTypeEnum.ftVariable;
                    H3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    H3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    H3.TextFont.Size = 8;
                    H3.TextFont.CharSet = 162;
                    H3.Value = @"";

                    H4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 80, 0, 88, 5, false);
                    H4.Name = "H4";
                    H4.DrawStyle = DrawStyleConstants.vbSolid;
                    H4.FieldType = ReportFieldTypeEnum.ftVariable;
                    H4.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    H4.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    H4.TextFont.Size = 8;
                    H4.TextFont.CharSet = 162;
                    H4.Value = @"";

                    H5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 88, 0, 96, 5, false);
                    H5.Name = "H5";
                    H5.DrawStyle = DrawStyleConstants.vbSolid;
                    H5.FieldType = ReportFieldTypeEnum.ftVariable;
                    H5.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    H5.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    H5.TextFont.Size = 8;
                    H5.TextFont.CharSet = 162;
                    H5.Value = @"";

                    H6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 96, 0, 104, 5, false);
                    H6.Name = "H6";
                    H6.DrawStyle = DrawStyleConstants.vbSolid;
                    H6.FieldType = ReportFieldTypeEnum.ftVariable;
                    H6.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    H6.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    H6.TextFont.Size = 8;
                    H6.TextFont.CharSet = 162;
                    H6.Value = @"";

                    H7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 104, 0, 112, 5, false);
                    H7.Name = "H7";
                    H7.DrawStyle = DrawStyleConstants.vbSolid;
                    H7.FieldType = ReportFieldTypeEnum.ftVariable;
                    H7.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    H7.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    H7.TextFont.Size = 8;
                    H7.TextFont.CharSet = 162;
                    H7.Value = @"";

                    H8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 112, 0, 120, 5, false);
                    H8.Name = "H8";
                    H8.DrawStyle = DrawStyleConstants.vbSolid;
                    H8.FieldType = ReportFieldTypeEnum.ftVariable;
                    H8.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    H8.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    H8.TextFont.Size = 8;
                    H8.TextFont.CharSet = 162;
                    H8.Value = @"";

                    H11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 136, 0, 144, 5, false);
                    H11.Name = "H11";
                    H11.DrawStyle = DrawStyleConstants.vbSolid;
                    H11.FieldType = ReportFieldTypeEnum.ftVariable;
                    H11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    H11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    H11.TextFont.Size = 8;
                    H11.TextFont.CharSet = 162;
                    H11.Value = @"";

                    H12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 144, 0, 152, 5, false);
                    H12.Name = "H12";
                    H12.DrawStyle = DrawStyleConstants.vbSolid;
                    H12.FieldType = ReportFieldTypeEnum.ftVariable;
                    H12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    H12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    H12.TextFont.Size = 8;
                    H12.TextFont.CharSet = 162;
                    H12.Value = @"";

                    H13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 0, 160, 5, false);
                    H13.Name = "H13";
                    H13.DrawStyle = DrawStyleConstants.vbSolid;
                    H13.FieldType = ReportFieldTypeEnum.ftVariable;
                    H13.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    H13.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    H13.TextFont.Size = 8;
                    H13.TextFont.CharSet = 162;
                    H13.Value = @"";

                    H14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 0, 168, 5, false);
                    H14.Name = "H14";
                    H14.DrawStyle = DrawStyleConstants.vbSolid;
                    H14.FieldType = ReportFieldTypeEnum.ftVariable;
                    H14.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    H14.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    H14.TextFont.Size = 8;
                    H14.TextFont.CharSet = 162;
                    H14.Value = @"";

                    H15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 168, 0, 176, 5, false);
                    H15.Name = "H15";
                    H15.DrawStyle = DrawStyleConstants.vbSolid;
                    H15.FieldType = ReportFieldTypeEnum.ftVariable;
                    H15.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    H15.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    H15.TextFont.Size = 8;
                    H15.TextFont.CharSet = 162;
                    H15.Value = @"";

                    H17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 184, 0, 192, 5, false);
                    H17.Name = "H17";
                    H17.DrawStyle = DrawStyleConstants.vbSolid;
                    H17.FieldType = ReportFieldTypeEnum.ftVariable;
                    H17.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    H17.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    H17.TextFont.Size = 8;
                    H17.TextFont.CharSet = 162;
                    H17.Value = @"";

                    H18 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 192, 0, 200, 5, false);
                    H18.Name = "H18";
                    H18.DrawStyle = DrawStyleConstants.vbSolid;
                    H18.FieldType = ReportFieldTypeEnum.ftVariable;
                    H18.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    H18.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    H18.TextFont.Size = 8;
                    H18.TextFont.CharSet = 162;
                    H18.Value = @"";

                    H16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 176, 0, 184, 5, false);
                    H16.Name = "H16";
                    H16.DrawStyle = DrawStyleConstants.vbSolid;
                    H16.FieldType = ReportFieldTypeEnum.ftVariable;
                    H16.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    H16.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    H16.TextFont.Size = 8;
                    H16.TextFont.CharSet = 162;
                    H16.Value = @"";

                    H19 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 200, 0, 208, 5, false);
                    H19.Name = "H19";
                    H19.DrawStyle = DrawStyleConstants.vbSolid;
                    H19.FieldType = ReportFieldTypeEnum.ftVariable;
                    H19.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    H19.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    H19.TextFont.Size = 8;
                    H19.TextFont.CharSet = 162;
                    H19.Value = @"";

                    H20 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 208, 0, 216, 5, false);
                    H20.Name = "H20";
                    H20.DrawStyle = DrawStyleConstants.vbSolid;
                    H20.FieldType = ReportFieldTypeEnum.ftVariable;
                    H20.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    H20.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    H20.TextFont.Size = 8;
                    H20.TextFont.CharSet = 162;
                    H20.Value = @"";

                    H21 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 216, 0, 224, 5, false);
                    H21.Name = "H21";
                    H21.DrawStyle = DrawStyleConstants.vbSolid;
                    H21.FieldType = ReportFieldTypeEnum.ftVariable;
                    H21.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    H21.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    H21.TextFont.Size = 8;
                    H21.TextFont.CharSet = 162;
                    H21.Value = @"";

                    H22 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 224, 0, 232, 5, false);
                    H22.Name = "H22";
                    H22.DrawStyle = DrawStyleConstants.vbSolid;
                    H22.FieldType = ReportFieldTypeEnum.ftVariable;
                    H22.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    H22.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    H22.TextFont.Size = 8;
                    H22.TextFont.CharSet = 162;
                    H22.Value = @"";

                    H23 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 232, 0, 240, 5, false);
                    H23.Name = "H23";
                    H23.DrawStyle = DrawStyleConstants.vbSolid;
                    H23.FieldType = ReportFieldTypeEnum.ftVariable;
                    H23.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    H23.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    H23.TextFont.Size = 8;
                    H23.TextFont.CharSet = 162;
                    H23.Value = @"";

                    H24 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 240, 0, 248, 5, false);
                    H24.Name = "H24";
                    H24.DrawStyle = DrawStyleConstants.vbSolid;
                    H24.FieldType = ReportFieldTypeEnum.ftVariable;
                    H24.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    H24.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    H24.TextFont.Size = 8;
                    H24.TextFont.CharSet = 162;
                    H24.Value = @"";

                    H25 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 248, 0, 256, 5, false);
                    H25.Name = "H25";
                    H25.DrawStyle = DrawStyleConstants.vbSolid;
                    H25.FieldType = ReportFieldTypeEnum.ftVariable;
                    H25.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    H25.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    H25.TextFont.Size = 8;
                    H25.TextFont.CharSet = 162;
                    H25.Value = @"";

                    H26 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 256, 0, 264, 5, false);
                    H26.Name = "H26";
                    H26.DrawStyle = DrawStyleConstants.vbSolid;
                    H26.FieldType = ReportFieldTypeEnum.ftVariable;
                    H26.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    H26.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    H26.TextFont.Size = 8;
                    H26.TextFont.CharSet = 162;
                    H26.Value = @"";

                    H27 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 264, 0, 272, 5, false);
                    H27.Name = "H27";
                    H27.DrawStyle = DrawStyleConstants.vbSolid;
                    H27.FieldType = ReportFieldTypeEnum.ftVariable;
                    H27.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    H27.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    H27.TextFont.Size = 8;
                    H27.TextFont.CharSet = 162;
                    H27.Value = @"";

                    H28 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 272, 0, 280, 5, false);
                    H28.Name = "H28";
                    H28.DrawStyle = DrawStyleConstants.vbSolid;
                    H28.FieldType = ReportFieldTypeEnum.ftVariable;
                    H28.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    H28.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    H28.TextFont.Size = 8;
                    H28.TextFont.CharSet = 162;
                    H28.Value = @"";

                    H29 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 280, 0, 288, 5, false);
                    H29.Name = "H29";
                    H29.DrawStyle = DrawStyleConstants.vbSolid;
                    H29.FieldType = ReportFieldTypeEnum.ftVariable;
                    H29.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    H29.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    H29.TextFont.Size = 8;
                    H29.TextFont.CharSet = 162;
                    H29.Value = @"";

                    H30 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 288, 0, 296, 5, false);
                    H30.Name = "H30";
                    H30.DrawStyle = DrawStyleConstants.vbSolid;
                    H30.FieldType = ReportFieldTypeEnum.ftVariable;
                    H30.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    H30.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    H30.TextFont.Size = 8;
                    H30.TextFont.CharSet = 162;
                    H30.Value = @"";

                    H9 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 120, 0, 128, 5, false);
                    H9.Name = "H9";
                    H9.DrawStyle = DrawStyleConstants.vbSolid;
                    H9.FieldType = ReportFieldTypeEnum.ftVariable;
                    H9.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    H9.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    H9.TextFont.Size = 8;
                    H9.TextFont.CharSet = 162;
                    H9.Value = @"";

                    H10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 128, 0, 136, 5, false);
                    H10.Name = "H10";
                    H10.DrawStyle = DrawStyleConstants.vbSolid;
                    H10.FieldType = ReportFieldTypeEnum.ftVariable;
                    H10.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    H10.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    H10.TextFont.Size = 8;
                    H10.TextFont.CharSet = 162;
                    H10.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    HEMSIRELABEL.CalcValue = HEMSIRELABEL.Value;
                    H1.CalcValue = @"";
                    H2.CalcValue = @"";
                    H3.CalcValue = @"";
                    H4.CalcValue = @"";
                    H5.CalcValue = @"";
                    H6.CalcValue = @"";
                    H7.CalcValue = @"";
                    H8.CalcValue = @"";
                    H11.CalcValue = @"";
                    H12.CalcValue = @"";
                    H13.CalcValue = @"";
                    H14.CalcValue = @"";
                    H15.CalcValue = @"";
                    H17.CalcValue = @"";
                    H18.CalcValue = @"";
                    H16.CalcValue = @"";
                    H19.CalcValue = @"";
                    H20.CalcValue = @"";
                    H21.CalcValue = @"";
                    H22.CalcValue = @"";
                    H23.CalcValue = @"";
                    H24.CalcValue = @"";
                    H25.CalcValue = @"";
                    H26.CalcValue = @"";
                    H27.CalcValue = @"";
                    H28.CalcValue = @"";
                    H29.CalcValue = @"";
                    H30.CalcValue = @"";
                    H9.CalcValue = @"";
                    H10.CalcValue = @"";
                    return new TTReportObject[] { HEMSIRELABEL,H1,H2,H3,H4,H5,H6,H7,H8,H11,H12,H13,H14,H15,H17,H18,H16,H19,H20,H21,H22,H23,H24,H25,H26,H27,H28,H29,H30,H9,H10};
                }

                public override void RunScript()
                {
#region HEADER FOOTER_Script
                    TTObjectContext context = new TTObjectContext(true);
                    string sObjectID = ((NursingFDLAReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
                    NursingApplication nursingApplication = (NursingApplication)context.GetObject(new Guid(sObjectID), "NursingApplication");
                    DateTime startDate = (DateTime)MyParentReport.RuntimeParameters.STARTTIME.Value.Date;
                    string H1 = nursingApplication.DailyLifeActivities.ToList().Find(x => x.CurrentStateDefID != NursingDailyLifeActivity.States.Cancelled && x.ApplicationDate.Value.Date == startDate.AddDays(0))?.ApplicationUser?.Name;
                    this.H1.CalcValue = H1?.Substring(0, 3) + H1?.Substring(H1.LastIndexOf(" "), 2);
                    string H2 = nursingApplication.DailyLifeActivities.ToList().Find(x => x.CurrentStateDefID != NursingDailyLifeActivity.States.Cancelled && x.ApplicationDate.Value.Date == startDate.AddDays(1))?.ApplicationUser?.Name;
                    this.H2.CalcValue = H2?.Substring(0, 3) + H2?.Substring(H2.LastIndexOf(" "), 2);
                    string H3 = nursingApplication.DailyLifeActivities.ToList().Find(x => x.CurrentStateDefID != NursingDailyLifeActivity.States.Cancelled && x.ApplicationDate.Value.Date == startDate.AddDays(2))?.ApplicationUser?.Name;
                    this.H3.CalcValue = H3?.Substring(0, 3) + H3?.Substring(H3.LastIndexOf(" "), 2);
                    string H4 = nursingApplication.DailyLifeActivities.ToList().Find(x => x.CurrentStateDefID != NursingDailyLifeActivity.States.Cancelled && x.ApplicationDate.Value.Date == startDate.AddDays(3))?.ApplicationUser?.Name;
                    this.H4.CalcValue = H4?.Substring(0, 3) + H4?.Substring(H4.LastIndexOf(" "), 2);
                    string H5 = nursingApplication.DailyLifeActivities.ToList().Find(x => x.CurrentStateDefID != NursingDailyLifeActivity.States.Cancelled && x.ApplicationDate.Value.Date == startDate.AddDays(4))?.ApplicationUser?.Name;
                    this.H5.CalcValue = H5?.Substring(0, 3) + H5?.Substring(H5.LastIndexOf(" "), 2);
                    string H6 = nursingApplication.DailyLifeActivities.ToList().Find(x => x.CurrentStateDefID != NursingDailyLifeActivity.States.Cancelled && x.ApplicationDate.Value.Date == startDate.AddDays(5))?.ApplicationUser?.Name;
                    this.H6.CalcValue = H6?.Substring(0, 3) + H6?.Substring(H6.LastIndexOf(" "), 2);
                    string H7 = nursingApplication.DailyLifeActivities.ToList().Find(x => x.CurrentStateDefID != NursingDailyLifeActivity.States.Cancelled && x.ApplicationDate.Value.Date == startDate.AddDays(6))?.ApplicationUser?.Name;
                    this.H7.CalcValue = H7?.Substring(0, 3) + H7?.Substring(H7.LastIndexOf(" "), 2);
                    string H8 = nursingApplication.DailyLifeActivities.ToList().Find(x => x.CurrentStateDefID != NursingDailyLifeActivity.States.Cancelled && x.ApplicationDate.Value.Date == startDate.AddDays(7))?.ApplicationUser?.Name;
                    this.H8.CalcValue = H8?.Substring(0, 3) + H8?.Substring(H8.LastIndexOf(" "), 2);
                    string H9 = nursingApplication.DailyLifeActivities.ToList().Find(x => x.CurrentStateDefID != NursingDailyLifeActivity.States.Cancelled && x.ApplicationDate.Value.Date == startDate.AddDays(8))?.ApplicationUser?.Name;
                    this.H9.CalcValue = H9?.Substring(0, 3) + H9?.Substring(H9.LastIndexOf(" "), 2);
                    string H10 = nursingApplication.DailyLifeActivities.ToList().Find(x => x.CurrentStateDefID != NursingDailyLifeActivity.States.Cancelled && x.ApplicationDate.Value.Date == startDate.AddDays(9))?.ApplicationUser?.Name;
                    this.H10.CalcValue = H10?.Substring(0, 3) + H10?.Substring(H10.LastIndexOf(" "), 2);
                    string H11 = nursingApplication.DailyLifeActivities.ToList().Find(x => x.CurrentStateDefID != NursingDailyLifeActivity.States.Cancelled && x.ApplicationDate.Value.Date == startDate.AddDays(10))?.ApplicationUser?.Name;
                    this.H11.CalcValue = H11?.Substring(0, 3) + H11?.Substring(H11.LastIndexOf(" "), 2);
                    string H12  = nursingApplication.DailyLifeActivities.ToList().Find(x => x.CurrentStateDefID != NursingDailyLifeActivity.States.Cancelled && x.ApplicationDate.Value.Date == startDate.AddDays(11))?.ApplicationUser?.Name;
                    this.H12.CalcValue = H12?.Substring(0, 3) + H12?.Substring(H12.LastIndexOf(" "), 2);
                    string H13 = nursingApplication.DailyLifeActivities.ToList().Find(x => x.CurrentStateDefID != NursingDailyLifeActivity.States.Cancelled && x.ApplicationDate.Value.Date == startDate.AddDays(12))?.ApplicationUser?.Name;
                    this.H13.CalcValue = H13?.Substring(0, 3) + H13?.Substring(H13.LastIndexOf(" "), 2);
                    string H14 = nursingApplication.DailyLifeActivities.ToList().Find(x => x.CurrentStateDefID != NursingDailyLifeActivity.States.Cancelled && x.ApplicationDate.Value.Date == startDate.AddDays(13))?.ApplicationUser?.Name;
                    this.H14.CalcValue = H14?.Substring(0, 3) + H14?.Substring(H14.LastIndexOf(" "), 2);
                    string H15 = nursingApplication.DailyLifeActivities.ToList().Find(x => x.CurrentStateDefID != NursingDailyLifeActivity.States.Cancelled && x.ApplicationDate.Value.Date == startDate.AddDays(14))?.ApplicationUser?.Name;
                    this.H15.CalcValue = H15?.Substring(0, 3) + H15?.Substring(H15.LastIndexOf(" "), 2);
                    string H16 = nursingApplication.DailyLifeActivities.ToList().Find(x => x.CurrentStateDefID != NursingDailyLifeActivity.States.Cancelled && x.ApplicationDate.Value.Date == startDate.AddDays(15))?.ApplicationUser?.Name;
                    this.H16.CalcValue = H16?.Substring(0, 3) + H16?.Substring(H16.LastIndexOf(" "), 2);
                    string H17 = nursingApplication.DailyLifeActivities.ToList().Find(x => x.CurrentStateDefID != NursingDailyLifeActivity.States.Cancelled && x.ApplicationDate.Value.Date == startDate.AddDays(16))?.ApplicationUser?.Name;
                    this.H17.CalcValue = H17?.Substring(0, 3) + H17?.Substring(H17.LastIndexOf(" "), 2);
                    string H18 = nursingApplication.DailyLifeActivities.ToList().Find(x => x.CurrentStateDefID != NursingDailyLifeActivity.States.Cancelled && x.ApplicationDate.Value.Date == startDate.AddDays(17))?.ApplicationUser?.Name;
                    this.H18.CalcValue = H18?.Substring(0, 3) + H18?.Substring(H18.LastIndexOf(" "), 2);
                    string H19 = nursingApplication.DailyLifeActivities.ToList().Find(x => x.CurrentStateDefID != NursingDailyLifeActivity.States.Cancelled && x.ApplicationDate.Value.Date == startDate.AddDays(18))?.ApplicationUser?.Name;
                    this.H19.CalcValue = H19?.Substring(0, 3) + H19?.Substring(H19.LastIndexOf(" "), 2);
                    string H20 = nursingApplication.DailyLifeActivities.ToList().Find(x => x.CurrentStateDefID != NursingDailyLifeActivity.States.Cancelled && x.ApplicationDate.Value.Date == startDate.AddDays(19))?.ApplicationUser?.Name;
                    this.H20.CalcValue = H20?.Substring(0, 3) + H20?.Substring(H20.LastIndexOf(" "), 2);
                    string H21 = nursingApplication.DailyLifeActivities.ToList().Find(x => x.CurrentStateDefID != NursingDailyLifeActivity.States.Cancelled && x.ApplicationDate.Value.Date == startDate.AddDays(20))?.ApplicationUser?.Name;
                    this.H21.CalcValue = H21?.Substring(0, 3) + H21?.Substring(H21.LastIndexOf(" "), 2);
                    string H22 = nursingApplication.DailyLifeActivities.ToList().Find(x => x.CurrentStateDefID != NursingDailyLifeActivity.States.Cancelled && x.ApplicationDate.Value.Date == startDate.AddDays(21))?.ApplicationUser?.Name;
                    this.H22.CalcValue = H22?.Substring(0, 3) + H22?.Substring(H22.LastIndexOf(" "), 2);
                    string H23 = nursingApplication.DailyLifeActivities.ToList().Find(x => x.CurrentStateDefID != NursingDailyLifeActivity.States.Cancelled && x.ApplicationDate.Value.Date == startDate.AddDays(22))?.ApplicationUser?.Name;
                    this.H23.CalcValue = H23?.Substring(0, 3) + H23?.Substring(H23.LastIndexOf(" "), 2);
                    string H24 = nursingApplication.DailyLifeActivities.ToList().Find(x => x.CurrentStateDefID != NursingDailyLifeActivity.States.Cancelled && x.ApplicationDate.Value.Date == startDate.AddDays(23))?.ApplicationUser?.Name;
                    this.H24.CalcValue = H24?.Substring(0, 3) + H24?.Substring(H24.LastIndexOf(" "), 2);
                    string H25 = nursingApplication.DailyLifeActivities.ToList().Find(x => x.CurrentStateDefID != NursingDailyLifeActivity.States.Cancelled && x.ApplicationDate.Value.Date == startDate.AddDays(24))?.ApplicationUser?.Name;
                    this.H25.CalcValue = H25?.Substring(0, 3) + H25?.Substring(H25.LastIndexOf(" "), 2);
                    string H26 = nursingApplication.DailyLifeActivities.ToList().Find(x => x.CurrentStateDefID != NursingDailyLifeActivity.States.Cancelled && x.ApplicationDate.Value.Date == startDate.AddDays(25))?.ApplicationUser?.Name;
                    this.H26.CalcValue = H26?.Substring(0, 3) + H26?.Substring(H26.LastIndexOf(" "), 2);
                    string H27 = nursingApplication.DailyLifeActivities.ToList().Find(x => x.CurrentStateDefID != NursingDailyLifeActivity.States.Cancelled && x.ApplicationDate.Value.Date == startDate.AddDays(26))?.ApplicationUser?.Name;
                    this.H27.CalcValue = H27?.Substring(0, 3) + H27?.Substring(H27.LastIndexOf(" "), 2);
                    string H28 = nursingApplication.DailyLifeActivities.ToList().Find(x => x.CurrentStateDefID != NursingDailyLifeActivity.States.Cancelled && x.ApplicationDate.Value.Date == startDate.AddDays(27))?.ApplicationUser?.Name;
                    this.H28.CalcValue = H28?.Substring(0, 3) + H28?.Substring(H28.LastIndexOf(" "), 2);
                    string H29 = nursingApplication.DailyLifeActivities.ToList().Find(x => x.CurrentStateDefID != NursingDailyLifeActivity.States.Cancelled && x.ApplicationDate.Value.Date == startDate.AddDays(28))?.ApplicationUser?.Name;
                    this.H29.CalcValue = H29?.Substring(0, 3) + H29?.Substring(H29.LastIndexOf(" "), 2);
                    string H30 = nursingApplication.DailyLifeActivities.ToList().Find(x => x.CurrentStateDefID != NursingDailyLifeActivity.States.Cancelled && x.ApplicationDate.Value.Date == startDate.AddDays(29))?.ApplicationUser?.Name;
                    this.H30.CalcValue = H30?.Substring(0, 3) + H30?.Substring(H30.LastIndexOf(" "), 2);
#endregion HEADER FOOTER_Script
                }
            }

        }

        public HEADERGroup HEADER;

        public partial class MAINGroup : TTReportGroup
        {
            public NursingFDLAReport MyParentReport
            {
                get { return (NursingFDLAReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField UYGULAMA { get {return Body().UYGULAMA;} }
            public TTReportField D1 { get {return Body().D1;} }
            public TTReportField D2 { get {return Body().D2;} }
            public TTReportField D3 { get {return Body().D3;} }
            public TTReportField D4 { get {return Body().D4;} }
            public TTReportField D5 { get {return Body().D5;} }
            public TTReportField D6 { get {return Body().D6;} }
            public TTReportField D7 { get {return Body().D7;} }
            public TTReportField D8 { get {return Body().D8;} }
            public TTReportField D11 { get {return Body().D11;} }
            public TTReportField D12 { get {return Body().D12;} }
            public TTReportField D13 { get {return Body().D13;} }
            public TTReportField D14 { get {return Body().D14;} }
            public TTReportField D15 { get {return Body().D15;} }
            public TTReportField D17 { get {return Body().D17;} }
            public TTReportField D18 { get {return Body().D18;} }
            public TTReportField D16 { get {return Body().D16;} }
            public TTReportField D19 { get {return Body().D19;} }
            public TTReportField D20 { get {return Body().D20;} }
            public TTReportField D21 { get {return Body().D21;} }
            public TTReportField D22 { get {return Body().D22;} }
            public TTReportField D23 { get {return Body().D23;} }
            public TTReportField D24 { get {return Body().D24;} }
            public TTReportField D25 { get {return Body().D25;} }
            public TTReportField D26 { get {return Body().D26;} }
            public TTReportField D27 { get {return Body().D27;} }
            public TTReportField D28 { get {return Body().D28;} }
            public TTReportField D29 { get {return Body().D29;} }
            public TTReportField D30 { get {return Body().D30;} }
            public TTReportField D9 { get {return Body().D9;} }
            public TTReportField D10 { get {return Body().D10;} }
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
                public NursingFDLAReport MyParentReport
                {
                    get { return (NursingFDLAReport)ParentReport; }
                }
                
                public TTReportField UYGULAMA;
                public TTReportField D1;
                public TTReportField D2;
                public TTReportField D3;
                public TTReportField D4;
                public TTReportField D5;
                public TTReportField D6;
                public TTReportField D7;
                public TTReportField D8;
                public TTReportField D11;
                public TTReportField D12;
                public TTReportField D13;
                public TTReportField D14;
                public TTReportField D15;
                public TTReportField D17;
                public TTReportField D18;
                public TTReportField D16;
                public TTReportField D19;
                public TTReportField D20;
                public TTReportField D21;
                public TTReportField D22;
                public TTReportField D23;
                public TTReportField D24;
                public TTReportField D25;
                public TTReportField D26;
                public TTReportField D27;
                public TTReportField D28;
                public TTReportField D29;
                public TTReportField D30;
                public TTReportField D9;
                public TTReportField D10; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 4;
                    RepeatCount = 0;
                    
                    UYGULAMA = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 0, 56, 5, false);
                    UYGULAMA.Name = "UYGULAMA";
                    UYGULAMA.DrawStyle = DrawStyleConstants.vbSolid;
                    UYGULAMA.FieldType = ReportFieldTypeEnum.ftVariable;
                    UYGULAMA.TextFormat = @"Standard";
                    UYGULAMA.Value = @"";

                    D1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 56, 0, 64, 5, false);
                    D1.Name = "D1";
                    D1.DrawStyle = DrawStyleConstants.vbSolid;
                    D1.FieldType = ReportFieldTypeEnum.ftVariable;
                    D1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    D1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    D1.Value = @"";

                    D2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 64, 0, 72, 5, false);
                    D2.Name = "D2";
                    D2.DrawStyle = DrawStyleConstants.vbSolid;
                    D2.FieldType = ReportFieldTypeEnum.ftVariable;
                    D2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    D2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    D2.Value = @"";

                    D3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 72, 0, 80, 5, false);
                    D3.Name = "D3";
                    D3.DrawStyle = DrawStyleConstants.vbSolid;
                    D3.FieldType = ReportFieldTypeEnum.ftVariable;
                    D3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    D3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    D3.Value = @"";

                    D4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 80, 0, 88, 5, false);
                    D4.Name = "D4";
                    D4.DrawStyle = DrawStyleConstants.vbSolid;
                    D4.FieldType = ReportFieldTypeEnum.ftVariable;
                    D4.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    D4.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    D4.Value = @"";

                    D5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 88, 0, 96, 5, false);
                    D5.Name = "D5";
                    D5.DrawStyle = DrawStyleConstants.vbSolid;
                    D5.FieldType = ReportFieldTypeEnum.ftVariable;
                    D5.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    D5.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    D5.Value = @"";

                    D6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 96, 0, 104, 5, false);
                    D6.Name = "D6";
                    D6.DrawStyle = DrawStyleConstants.vbSolid;
                    D6.FieldType = ReportFieldTypeEnum.ftVariable;
                    D6.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    D6.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    D6.Value = @"";

                    D7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 104, 0, 112, 5, false);
                    D7.Name = "D7";
                    D7.DrawStyle = DrawStyleConstants.vbSolid;
                    D7.FieldType = ReportFieldTypeEnum.ftVariable;
                    D7.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    D7.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    D7.Value = @"";

                    D8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 112, 0, 120, 5, false);
                    D8.Name = "D8";
                    D8.DrawStyle = DrawStyleConstants.vbSolid;
                    D8.FieldType = ReportFieldTypeEnum.ftVariable;
                    D8.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    D8.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    D8.Value = @"";

                    D11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 136, 0, 144, 5, false);
                    D11.Name = "D11";
                    D11.DrawStyle = DrawStyleConstants.vbSolid;
                    D11.FieldType = ReportFieldTypeEnum.ftVariable;
                    D11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    D11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    D11.Value = @"";

                    D12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 144, 0, 152, 5, false);
                    D12.Name = "D12";
                    D12.DrawStyle = DrawStyleConstants.vbSolid;
                    D12.FieldType = ReportFieldTypeEnum.ftVariable;
                    D12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    D12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    D12.Value = @"";

                    D13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 0, 160, 5, false);
                    D13.Name = "D13";
                    D13.DrawStyle = DrawStyleConstants.vbSolid;
                    D13.FieldType = ReportFieldTypeEnum.ftVariable;
                    D13.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    D13.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    D13.Value = @"";

                    D14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 0, 168, 5, false);
                    D14.Name = "D14";
                    D14.DrawStyle = DrawStyleConstants.vbSolid;
                    D14.FieldType = ReportFieldTypeEnum.ftVariable;
                    D14.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    D14.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    D14.Value = @"";

                    D15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 168, 0, 176, 5, false);
                    D15.Name = "D15";
                    D15.DrawStyle = DrawStyleConstants.vbSolid;
                    D15.FieldType = ReportFieldTypeEnum.ftVariable;
                    D15.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    D15.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    D15.Value = @"";

                    D17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 184, 0, 192, 5, false);
                    D17.Name = "D17";
                    D17.DrawStyle = DrawStyleConstants.vbSolid;
                    D17.FieldType = ReportFieldTypeEnum.ftVariable;
                    D17.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    D17.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    D17.Value = @"";

                    D18 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 192, 0, 200, 5, false);
                    D18.Name = "D18";
                    D18.DrawStyle = DrawStyleConstants.vbSolid;
                    D18.FieldType = ReportFieldTypeEnum.ftVariable;
                    D18.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    D18.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    D18.Value = @"";

                    D16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 176, 0, 184, 5, false);
                    D16.Name = "D16";
                    D16.DrawStyle = DrawStyleConstants.vbSolid;
                    D16.FieldType = ReportFieldTypeEnum.ftVariable;
                    D16.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    D16.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    D16.Value = @"";

                    D19 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 200, 0, 208, 5, false);
                    D19.Name = "D19";
                    D19.DrawStyle = DrawStyleConstants.vbSolid;
                    D19.FieldType = ReportFieldTypeEnum.ftVariable;
                    D19.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    D19.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    D19.Value = @"";

                    D20 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 208, 0, 216, 5, false);
                    D20.Name = "D20";
                    D20.DrawStyle = DrawStyleConstants.vbSolid;
                    D20.FieldType = ReportFieldTypeEnum.ftVariable;
                    D20.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    D20.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    D20.Value = @"";

                    D21 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 216, 0, 224, 5, false);
                    D21.Name = "D21";
                    D21.DrawStyle = DrawStyleConstants.vbSolid;
                    D21.FieldType = ReportFieldTypeEnum.ftVariable;
                    D21.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    D21.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    D21.Value = @"";

                    D22 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 224, 0, 232, 5, false);
                    D22.Name = "D22";
                    D22.DrawStyle = DrawStyleConstants.vbSolid;
                    D22.FieldType = ReportFieldTypeEnum.ftVariable;
                    D22.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    D22.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    D22.Value = @"";

                    D23 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 232, 0, 240, 5, false);
                    D23.Name = "D23";
                    D23.DrawStyle = DrawStyleConstants.vbSolid;
                    D23.FieldType = ReportFieldTypeEnum.ftVariable;
                    D23.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    D23.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    D23.Value = @"";

                    D24 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 240, 0, 248, 5, false);
                    D24.Name = "D24";
                    D24.DrawStyle = DrawStyleConstants.vbSolid;
                    D24.FieldType = ReportFieldTypeEnum.ftVariable;
                    D24.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    D24.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    D24.Value = @"";

                    D25 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 248, 0, 256, 5, false);
                    D25.Name = "D25";
                    D25.DrawStyle = DrawStyleConstants.vbSolid;
                    D25.FieldType = ReportFieldTypeEnum.ftVariable;
                    D25.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    D25.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    D25.Value = @"";

                    D26 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 256, 0, 264, 5, false);
                    D26.Name = "D26";
                    D26.DrawStyle = DrawStyleConstants.vbSolid;
                    D26.FieldType = ReportFieldTypeEnum.ftVariable;
                    D26.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    D26.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    D26.Value = @"";

                    D27 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 264, 0, 272, 5, false);
                    D27.Name = "D27";
                    D27.DrawStyle = DrawStyleConstants.vbSolid;
                    D27.FieldType = ReportFieldTypeEnum.ftVariable;
                    D27.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    D27.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    D27.Value = @"";

                    D28 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 272, 0, 280, 5, false);
                    D28.Name = "D28";
                    D28.DrawStyle = DrawStyleConstants.vbSolid;
                    D28.FieldType = ReportFieldTypeEnum.ftVariable;
                    D28.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    D28.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    D28.Value = @"";

                    D29 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 280, 0, 288, 5, false);
                    D29.Name = "D29";
                    D29.DrawStyle = DrawStyleConstants.vbSolid;
                    D29.FieldType = ReportFieldTypeEnum.ftVariable;
                    D29.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    D29.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    D29.Value = @"";

                    D30 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 288, 0, 296, 5, false);
                    D30.Name = "D30";
                    D30.DrawStyle = DrawStyleConstants.vbSolid;
                    D30.FieldType = ReportFieldTypeEnum.ftVariable;
                    D30.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    D30.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    D30.Value = @"";

                    D9 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 120, 0, 128, 5, false);
                    D9.Name = "D9";
                    D9.DrawStyle = DrawStyleConstants.vbSolid;
                    D9.FieldType = ReportFieldTypeEnum.ftVariable;
                    D9.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    D9.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    D9.Value = @"";

                    D10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 128, 0, 136, 5, false);
                    D10.Name = "D10";
                    D10.DrawStyle = DrawStyleConstants.vbSolid;
                    D10.FieldType = ReportFieldTypeEnum.ftVariable;
                    D10.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    D10.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    D10.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    UYGULAMA.CalcValue = @"";
                    D1.CalcValue = @"";
                    D2.CalcValue = @"";
                    D3.CalcValue = @"";
                    D4.CalcValue = @"";
                    D5.CalcValue = @"";
                    D6.CalcValue = @"";
                    D7.CalcValue = @"";
                    D8.CalcValue = @"";
                    D11.CalcValue = @"";
                    D12.CalcValue = @"";
                    D13.CalcValue = @"";
                    D14.CalcValue = @"";
                    D15.CalcValue = @"";
                    D17.CalcValue = @"";
                    D18.CalcValue = @"";
                    D16.CalcValue = @"";
                    D19.CalcValue = @"";
                    D20.CalcValue = @"";
                    D21.CalcValue = @"";
                    D22.CalcValue = @"";
                    D23.CalcValue = @"";
                    D24.CalcValue = @"";
                    D25.CalcValue = @"";
                    D26.CalcValue = @"";
                    D27.CalcValue = @"";
                    D28.CalcValue = @"";
                    D29.CalcValue = @"";
                    D30.CalcValue = @"";
                    D9.CalcValue = @"";
                    D10.CalcValue = @"";
                    return new TTReportObject[] { UYGULAMA,D1,D2,D3,D4,D5,D6,D7,D8,D11,D12,D13,D14,D15,D17,D18,D16,D19,D20,D21,D22,D23,D24,D25,D26,D27,D28,D29,D30,D9,D10};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    if (MyParentReport.MAIN.RepeatCount > 0)
                    {
                        List<FunctionDetail> functionDetailList = MyParentReport.functionDetailList;
                        var obj = functionDetailList[MyParentReport.mainCounter];
                        this.UYGULAMA.CalcValue = obj.functionName;
                        this.D1.CalcValue = obj.D1;
                        this.D2.CalcValue = obj.D2;
                        this.D3.CalcValue = obj.D3;
                        this.D4.CalcValue = obj.D4;
                        this.D5.CalcValue = obj.D5;
                        this.D6.CalcValue = obj.D6;
                        this.D7.CalcValue = obj.D7;
                        this.D8.CalcValue = obj.D8;
                        this.D9.CalcValue = obj.D9;
                        this.D10.CalcValue = obj.D10;
                        this.D11.CalcValue = obj.D11;
                        this.D12.CalcValue = obj.D12;
                        this.D13.CalcValue = obj.D13;
                        this.D14.CalcValue = obj.D14;
                        this.D15.CalcValue = obj.D15;
                        this.D16.CalcValue = obj.D16;
                        this.D17.CalcValue = obj.D17;
                        this.D18.CalcValue = obj.D18;
                        this.D19.CalcValue = obj.D19;
                        this.D20.CalcValue = obj.D20;
                        this.D21.CalcValue = obj.D21;
                        this.D22.CalcValue = obj.D22;
                        this.D23.CalcValue = obj.D23;
                        this.D24.CalcValue = obj.D24;
                        this.D25.CalcValue = obj.D25;
                        this.D26.CalcValue = obj.D26;
                        this.D27.CalcValue = obj.D27;
                        this.D28.CalcValue = obj.D28;
                        this.D29.CalcValue = obj.D29;
                        this.D30.CalcValue = obj.D30;
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

        public NursingFDLAReport()
        {
            HASTAINFO = new HASTAINFOGroup(this,"HASTAINFO");
            HEADER = new HEADERGroup(HASTAINFO,"HEADER");
            MAIN = new MAINGroup(HEADER,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "00000000-0000-0000-0000-000000000000", "Hemşirelik İşlemi Id", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter = Parameters.Add("STARTTIME", "", "Başlançış Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["TTOBJECTID"]);
            if (parameters.ContainsKey("STARTTIME"))
                _runtimeParameters.STARTTIME = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTTIME"]);
            Name = "NURSINGFDLAREPORT";
            Caption = "Bakım İzlem Raporu";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oeLandscape;
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
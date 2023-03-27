
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
    /// Randevu Süresi Geçmiş Hastalar
    /// </summary>
    public partial class MHRSAppointmentTimeIsPastReport : TTReport
    {
#region Methods
   public class AppointmentCounts {
            public string patientName;
            public string masterresourceName;
            public string appointmentTime;
            public string examinationTime;
            
            public AppointmentCounts(string patientName,string masterresourceName, string appointmentTime, string examinationTime){
                this.patientName = patientName;
                this.masterresourceName = masterresourceName;
                this.appointmentTime = appointmentTime;
                this.examinationTime = examinationTime;
            }
        }
        public int rowCounter=0;
        List<AppointmentCounts> appointmentList = new List<AppointmentCounts>();
   
#endregion Methods

        public class ReportRuntimeParameters 
        {
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public AdmissionMinuteTypeEnum? MINUTE = (AdmissionMinuteTypeEnum?)(int?)TTObjectDefManager.Instance.DataTypes["AdmissionMinuteTypeEnum"].ConvertValue("");
        }

        public partial class QUERYGroup : TTReportGroup
        {
            public MHRSAppointmentTimeIsPastReport MyParentReport
            {
                get { return (MHRSAppointmentTimeIsPastReport)ParentReport; }
            }

            new public QUERYGroupHeader Header()
            {
                return (QUERYGroupHeader)_header;
            }

            new public QUERYGroupFooter Footer()
            {
                return (QUERYGroupFooter)_footer;
            }

            public QUERYGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public QUERYGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new QUERYGroupHeader(this);
                _footer = new QUERYGroupFooter(this);

            }

            public partial class QUERYGroupHeader : TTReportSection
            {
                public MHRSAppointmentTimeIsPastReport MyParentReport
                {
                    get { return (MHRSAppointmentTimeIsPastReport)ParentReport; }
                }
                 
                public QUERYGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 12;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                }
                

                public override void RunScript()
                {
#region QUERY HEADER_Script
                    BindingList<Appointment.GetMHRSAppointmentTimeIsPast_Class> AppointmenQueryList = Appointment.GetMHRSAppointmentTimeIsPast(MyParentReport.RuntimeParameters.STARTDATE.Value, MyParentReport.RuntimeParameters.ENDDATE.Value);
            
            TTObjectContext context = new TTObjectContext(true);
            int sgk = 0, paid = 0, other = 0;
            for (int i = 0; i < AppointmenQueryList.Count; i++)
                    {
                        int minuteType = Convert.ToInt16(MyParentReport.RuntimeParameters.MINUTE.Value);
                        AdmissionAppointment admissionAppointment = (AdmissionAppointment)context.GetObject(new Guid(AppointmenQueryList[i].Action.ToString()), "AdmissionAppointment");
                        if (admissionAppointment != null && admissionAppointment.PatientAdmission != null && admissionAppointment.PatientAdmission.Count > 0)
                        {
                            foreach (PatientAdmission pa in admissionAppointment.PatientAdmission)
                            {
                                if (pa.PAStatus != PAStatusEnum.IptalEdildi && pa.PAStatus != PAStatusEnum.KabulSilindi && pa.PAStatus != PAStatusEnum.MuayeneyeGelmedi)
                                {
                                    foreach (EpisodeAction eAction in pa.FiredEpisodeActions)
                                    {
                                        if (eAction is PatientExamination && ((PatientExamination)eAction).ProcessDate != null)
                                        {
                                            DateTime addedAdetTime = DateTime.MaxValue;
                                            string processDate = ((DateTime)((PatientExamination)eAction).ProcessDate).ToShortDateString() + " " + ((DateTime)((PatientExamination)eAction).ProcessDate).ToShortTimeString();
                                            if (minuteType == 0)
                                                addedAdetTime = ((DateTime)AppointmenQueryList[i].StartTime).AddMinutes(15);
                                            else if (minuteType == 1)
                                                addedAdetTime = ((DateTime)AppointmenQueryList[i].StartTime).AddMinutes(30);
                                            else if (minuteType == 2)
                                                addedAdetTime = ((DateTime)AppointmenQueryList[i].StartTime).AddMinutes(30);

                                            if (((PatientExamination)eAction).ProcessDate > addedAdetTime)
                                                MyParentReport.appointmentList.Add(new AppointmentCounts(AppointmenQueryList[i].Patientname + " " + AppointmenQueryList[i].Patientsurname, AppointmenQueryList[i].Masterresource, ((DateTime)AppointmenQueryList[i].StartTime).ToShortDateString() + " " + ((DateTime)AppointmenQueryList[i].StartTime).ToShortTimeString() + "-" + ((DateTime)AppointmenQueryList[i].EndTime).ToShortTimeString(), processDate));
                                        }
                                    }
                                }
                            }
                        }
                    }
            MyParentReport.MAIN.RepeatCount = MyParentReport.appointmentList.Count();
#endregion QUERY HEADER_Script
                }
            }
            public partial class QUERYGroupFooter : TTReportSection
            {
                public MHRSAppointmentTimeIsPastReport MyParentReport
                {
                    get { return (MHRSAppointmentTimeIsPastReport)ParentReport; }
                }
                 
                public QUERYGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 4;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public QUERYGroup QUERY;

        public partial class HEADERGroup : TTReportGroup
        {
            public MHRSAppointmentTimeIsPastReport MyParentReport
            {
                get { return (MHRSAppointmentTimeIsPastReport)ParentReport; }
            }

            new public HEADERGroupHeader Header()
            {
                return (HEADERGroupHeader)_header;
            }

            new public HEADERGroupFooter Footer()
            {
                return (HEADERGroupFooter)_footer;
            }

            public TTReportField XXXXXXBASLIK { get {return Header().XXXXXXBASLIK;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
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
                public MHRSAppointmentTimeIsPastReport MyParentReport
                {
                    get { return (MHRSAppointmentTimeIsPastReport)ParentReport; }
                }
                
                public TTReportField XXXXXXBASLIK;
                public TTReportField NewField11; 
                public HEADERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 46;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    XXXXXXBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 9, 170, 31, false);
                    XXXXXXBASLIK.Name = "XXXXXXBASLIK";
                    XXXXXXBASLIK.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXBASLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.TextFont.Size = 11;
                    XXXXXXBASLIK.TextFont.Bold = true;
                    XXXXXXBASLIK.TextFont.CharSet = 162;
                    XXXXXXBASLIK.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + ""\r\n"" + TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 33, 170, 42, false);
                    NewField11.Name = "NewField11";
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11.TextFont.Size = 15;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"MHRS Randevu Saati Geçmiş Randevular Listesi";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField11.CalcValue = NewField11.Value;
                    XXXXXXBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { NewField11,XXXXXXBASLIK};
                }
            }
            public partial class HEADERGroupFooter : TTReportSection
            {
                public MHRSAppointmentTimeIsPastReport MyParentReport
                {
                    get { return (MHRSAppointmentTimeIsPastReport)ParentReport; }
                }
                 
                public HEADERGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 7;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public HEADERGroup HEADER;

        public partial class REPORTGroup : TTReportGroup
        {
            public MHRSAppointmentTimeIsPastReport MyParentReport
            {
                get { return (MHRSAppointmentTimeIsPastReport)ParentReport; }
            }

            new public REPORTGroupHeader Header()
            {
                return (REPORTGroupHeader)_header;
            }

            new public REPORTGroupFooter Footer()
            {
                return (REPORTGroupFooter)_footer;
            }

            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField NewField13 { get {return Header().NewField13;} }
            public TTReportField NewField131 { get {return Header().NewField131;} }
            public TTReportShape NewLine111 { get {return Footer().NewLine111;} }
            public TTReportShape NewLine11511 { get {return Footer().NewLine11511;} }
            public TTReportShape NewLine12511 { get {return Footer().NewLine12511;} }
            public TTReportShape NewLine13511 { get {return Footer().NewLine13511;} }
            public TTReportShape NewLine14511 { get {return Footer().NewLine14511;} }
            public TTReportShape NewLine111541 { get {return Footer().NewLine111541;} }
            public REPORTGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public REPORTGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new REPORTGroupHeader(this);
                _footer = new REPORTGroupFooter(this);

            }

            public partial class REPORTGroupHeader : TTReportSection
            {
                public MHRSAppointmentTimeIsPastReport MyParentReport
                {
                    get { return (MHRSAppointmentTimeIsPastReport)ParentReport; }
                }
                
                public TTReportField NewField11;
                public TTReportField NewField12;
                public TTReportField NewField13;
                public TTReportField NewField131; 
                public REPORTGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 10;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 5, 52, 10, false);
                    NewField11.Name = "NewField11";
                    NewField11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"Adı Soyadı";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 52, 5, 134, 10, false);
                    NewField12.Name = "NewField12";
                    NewField12.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 0;
                    NewField12.Value = @"Bölüm";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 134, 5, 177, 10, false);
                    NewField13.Name = "NewField13";
                    NewField13.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField13.TextFont.Bold = true;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @"Randevu Saati";

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 177, 5, 204, 10, false);
                    NewField131.Name = "NewField131";
                    NewField131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField131.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField131.TextFont.Bold = true;
                    NewField131.TextFont.CharSet = 162;
                    NewField131.Value = @"Muayene Saati";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField11.CalcValue = NewField11.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField131.CalcValue = NewField131.Value;
                    return new TTReportObject[] { NewField11,NewField12,NewField13,NewField131};
                }
            }
            public partial class REPORTGroupFooter : TTReportSection
            {
                public MHRSAppointmentTimeIsPastReport MyParentReport
                {
                    get { return (MHRSAppointmentTimeIsPastReport)ParentReport; }
                }
                
                public TTReportShape NewLine111;
                public TTReportShape NewLine11511;
                public TTReportShape NewLine12511;
                public TTReportShape NewLine13511;
                public TTReportShape NewLine14511;
                public TTReportShape NewLine111541; 
                public REPORTGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 6;
                    RepeatCount = 0;
                    
                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 2, 204, 2, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine11511 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, -4, 7, 2, false);
                    NewLine11511.Name = "NewLine11511";
                    NewLine11511.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine12511 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 52, -4, 52, 2, false);
                    NewLine12511.Name = "NewLine12511";
                    NewLine12511.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine13511 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 134, -4, 134, 2, false);
                    NewLine13511.Name = "NewLine13511";
                    NewLine13511.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine14511 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 177, -4, 177, 2, false);
                    NewLine14511.Name = "NewLine14511";
                    NewLine14511.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine111541 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 204, -4, 204, 2, false);
                    NewLine111541.Name = "NewLine111541";
                    NewLine111541.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    return new TTReportObject[] { };
                }
            }

        }

        public REPORTGroup REPORT;

        public partial class MAINGroup : TTReportGroup
        {
            public MHRSAppointmentTimeIsPastReport MyParentReport
            {
                get { return (MHRSAppointmentTimeIsPastReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField PATIENTNAME { get {return Body().PATIENTNAME;} }
            public TTReportShape NewLine151 { get {return Body().NewLine151;} }
            public TTReportField BOLUM { get {return Body().BOLUM;} }
            public TTReportField RANDEVUSAATI { get {return Body().RANDEVUSAATI;} }
            public TTReportShape NewLine131 { get {return Body().NewLine131;} }
            public TTReportShape NewLine1131 { get {return Body().NewLine1131;} }
            public TTReportShape NewLine1231 { get {return Body().NewLine1231;} }
            public TTReportField MUAYENESAATI { get {return Body().MUAYENESAATI;} }
            public TTReportShape NewLine1151 { get {return Body().NewLine1151;} }
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
                public MHRSAppointmentTimeIsPastReport MyParentReport
                {
                    get { return (MHRSAppointmentTimeIsPastReport)ParentReport; }
                }
                
                public TTReportField PATIENTNAME;
                public TTReportShape NewLine151;
                public TTReportField BOLUM;
                public TTReportField RANDEVUSAATI;
                public TTReportShape NewLine131;
                public TTReportShape NewLine1131;
                public TTReportShape NewLine1231;
                public TTReportField MUAYENESAATI;
                public TTReportShape NewLine1151; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 7;
                    RepeatCount = 0;
                    
                    PATIENTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 1, 52, 6, false);
                    PATIENTNAME.Name = "PATIENTNAME";
                    PATIENTNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATIENTNAME.Value = @"";

                    NewLine151 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 177, -2, 177, 13, false);
                    NewLine151.Name = "NewLine151";
                    NewLine151.DrawStyle = DrawStyleConstants.vbSolid;

                    BOLUM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 1, 134, 6, false);
                    BOLUM.Name = "BOLUM";
                    BOLUM.FieldType = ReportFieldTypeEnum.ftVariable;
                    BOLUM.Value = @"";

                    RANDEVUSAATI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 135, 1, 176, 6, false);
                    RANDEVUSAATI.Name = "RANDEVUSAATI";
                    RANDEVUSAATI.FieldType = ReportFieldTypeEnum.ftVariable;
                    RANDEVUSAATI.Value = @"";

                    NewLine131 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 52, -1, 52, 12, false);
                    NewLine131.Name = "NewLine131";
                    NewLine131.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1131 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, -1, 7, 12, false);
                    NewLine1131.Name = "NewLine1131";
                    NewLine1131.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1231 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 134, 0, 134, 13, false);
                    NewLine1231.Name = "NewLine1231";
                    NewLine1231.DrawStyle = DrawStyleConstants.vbSolid;

                    MUAYENESAATI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 178, 1, 204, 6, false);
                    MUAYENESAATI.Name = "MUAYENESAATI";
                    MUAYENESAATI.FieldType = ReportFieldTypeEnum.ftVariable;
                    MUAYENESAATI.Value = @"";

                    NewLine1151 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 204, -3, 204, 12, false);
                    NewLine1151.Name = "NewLine1151";
                    NewLine1151.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PATIENTNAME.CalcValue = @"";
                    BOLUM.CalcValue = @"";
                    RANDEVUSAATI.CalcValue = @"";
                    MUAYENESAATI.CalcValue = @"";
                    return new TTReportObject[] { PATIENTNAME,BOLUM,RANDEVUSAATI,MUAYENESAATI};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    if (MyParentReport.appointmentList.Count > 0)
             {                   
                   AppointmentCounts obj = MyParentReport.appointmentList[MyParentReport.rowCounter];
                    this.PATIENTNAME.CalcValue = obj.patientName;
                    this.BOLUM.CalcValue = obj.masterresourceName;
                    this.RANDEVUSAATI.CalcValue = obj.appointmentTime;
                    this.MUAYENESAATI.CalcValue = obj.examinationTime;
                    MyParentReport.rowCounter += 1;
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

        public MHRSAppointmentTimeIsPastReport()
        {
            QUERY = new QUERYGroup(this,"QUERY");
            HEADER = new HEADERGroup(QUERY,"HEADER");
            REPORT = new REPORTGroup(HEADER,"REPORT");
            MAIN = new MAINGroup(REPORT,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STARTDATE", "", "Başlangıç Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENDDATE", "", "Bitiş Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("MINUTE", "", "Süre", @"", true, true, false, new Guid("c222bab3-87b1-4f07-b473-5e128896e942"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STARTDATE"))
                _runtimeParameters.STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTDATE"]);
            if (parameters.ContainsKey("ENDDATE"))
                _runtimeParameters.ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ENDDATE"]);
            if (parameters.ContainsKey("MINUTE"))
                _runtimeParameters.MINUTE = (AdmissionMinuteTypeEnum?)(int?)TTObjectDefManager.Instance.DataTypes["AdmissionMinuteTypeEnum"].ConvertValue(parameters["MINUTE"]);
            Name = "MHRSAPPOINTMENTTIMEISPASTREPORT";
            Caption = "Randevu Süresi Geçmiş Hastalar";
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
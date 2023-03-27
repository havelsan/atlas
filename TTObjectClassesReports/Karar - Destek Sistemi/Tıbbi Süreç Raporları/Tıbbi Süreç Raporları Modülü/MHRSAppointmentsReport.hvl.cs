
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
    public partial class MHRSAppointmentsReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? MASTERRESOURCE = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid_"].ConvertValue("00000000-0000-0000-0000-000000000000");
            public Guid? RESOURCE = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid_"].ConvertValue("00000000-0000-0000-0000-000000000000");
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
        }

        public partial class HEADERGroup : TTReportGroup
        {
            public MHRSAppointmentsReport MyParentReport
            {
                get { return (MHRSAppointmentsReport)ParentReport; }
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
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField RDATE { get {return Header().RDATE;} }
            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportField NewField3 { get {return Header().NewField3;} }
            public TTReportField NewField4 { get {return Footer().NewField4;} }
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
                public MHRSAppointmentsReport MyParentReport
                {
                    get { return (MHRSAppointmentsReport)ParentReport; }
                }
                
                public TTReportField XXXXXXBASLIK;
                public TTReportField NewField1;
                public TTReportField RDATE;
                public TTReportField NewField2;
                public TTReportField NewField3; 
                public HEADERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 41;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    XXXXXXBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 46, 7, 172, 29, false);
                    XXXXXXBASLIK.Name = "XXXXXXBASLIK";
                    XXXXXXBASLIK.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXBASLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.TextFont.Size = 11;
                    XXXXXXBASLIK.TextFont.Bold = true;
                    XXXXXXBASLIK.TextFont.CharSet = 162;
                    XXXXXXBASLIK.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + ""\r\n"" + TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 30, 154, 39, false);
                    NewField1.Name = "NewField1";
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.TextFont.Size = 15;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"MHRS RANDEVU PLANI RAPORU";

                    RDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 187, 31, 206, 36, false);
                    RDATE.Name = "RDATE";
                    RDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    RDATE.TextFormat = @"dd/MM/yyyy";
                    RDATE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    RDATE.TextFont.Size = 9;
                    RDATE.TextFont.CharSet = 162;
                    RDATE.Value = @"{@printdate@}";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 177, 31, 185, 36, false);
                    NewField2.Name = "NewField2";
                    NewField2.TextFont.Size = 9;
                    NewField2.TextFont.Bold = true;
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @"Tarih";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 185, 31, 186, 36, false);
                    NewField3.Name = "NewField3";
                    NewField3.TextFont.Size = 9;
                    NewField3.TextFont.Bold = true;
                    NewField3.TextFont.CharSet = 162;
                    NewField3.Value = @":";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1.CalcValue = NewField1.Value;
                    RDATE.CalcValue = DateTime.Now.ToShortDateString();
                    NewField2.CalcValue = NewField2.Value;
                    NewField3.CalcValue = NewField3.Value;
                    XXXXXXBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { NewField1,RDATE,NewField2,NewField3,XXXXXXBASLIK};
                }
            }
            public partial class HEADERGroupFooter : TTReportSection
            {
                public MHRSAppointmentsReport MyParentReport
                {
                    get { return (MHRSAppointmentsReport)ParentReport; }
                }
                
                public TTReportField NewField4; 
                public HEADERGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 7;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 89, 2, 114, 7, false);
                    NewField4.Name = "NewField4";
                    NewField4.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField4.TextFont.Size = 8;
                    NewField4.TextFont.CharSet = 162;
                    NewField4.Value = @"{@pagenumber@}/{@pagecount@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField4.CalcValue = ParentReport.CurrentPageNumber.ToString() + @"/" + ParentReport.ReportTotalPageCount;
                    return new TTReportObject[] { NewField4};
                }
            }

        }

        public HEADERGroup HEADER;

        public partial class POLICLINICGroup : TTReportGroup
        {
            public MHRSAppointmentsReport MyParentReport
            {
                get { return (MHRSAppointmentsReport)ParentReport; }
            }

            new public POLICLINICGroupHeader Header()
            {
                return (POLICLINICGroupHeader)_header;
            }

            new public POLICLINICGroupFooter Footer()
            {
                return (POLICLINICGroupFooter)_footer;
            }

            public TTReportField MASTERRESOURCE { get {return Header().MASTERRESOURCE;} }
            public POLICLINICGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public POLICLINICGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<Appointment.GetMHRSAppointment_Class>("GetMHRSAppointment", Appointment.GetMHRSAppointment((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE),(Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.RESOURCE),(Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.MASTERRESOURCE)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new POLICLINICGroupHeader(this);
                _footer = new POLICLINICGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class POLICLINICGroupHeader : TTReportSection
            {
                public MHRSAppointmentsReport MyParentReport
                {
                    get { return (MHRSAppointmentsReport)ParentReport; }
                }
                
                public TTReportField MASTERRESOURCE; 
                public POLICLINICGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 10;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    MASTERRESOURCE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 3, 203, 8, false);
                    MASTERRESOURCE.Name = "MASTERRESOURCE";
                    MASTERRESOURCE.FieldType = ReportFieldTypeEnum.ftVariable;
                    MASTERRESOURCE.ObjectDefName = "Resource";
                    MASTERRESOURCE.DataMember = "NAME";
                    MASTERRESOURCE.TextFont.Size = 12;
                    MASTERRESOURCE.TextFont.Bold = true;
                    MASTERRESOURCE.TextFont.CharSet = 162;
                    MASTERRESOURCE.Value = @"{#MASTERRESOURCE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Appointment.GetMHRSAppointment_Class dataset_GetMHRSAppointment = ParentGroup.rsGroup.GetCurrentRecord<Appointment.GetMHRSAppointment_Class>(0);
                    MASTERRESOURCE.CalcValue = (dataset_GetMHRSAppointment != null ? Globals.ToStringCore(dataset_GetMHRSAppointment.MasterResource) : "");
                    MASTERRESOURCE.PostFieldValueCalculation();
                    return new TTReportObject[] { MASTERRESOURCE};
                }
            }
            public partial class POLICLINICGroupFooter : TTReportSection
            {
                public MHRSAppointmentsReport MyParentReport
                {
                    get { return (MHRSAppointmentsReport)ParentReport; }
                }
                 
                public POLICLINICGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 2;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public POLICLINICGroup POLICLINIC;

        public partial class DOCTORGroup : TTReportGroup
        {
            public MHRSAppointmentsReport MyParentReport
            {
                get { return (MHRSAppointmentsReport)ParentReport; }
            }

            new public DOCTORGroupHeader Header()
            {
                return (DOCTORGroupHeader)_header;
            }

            new public DOCTORGroupFooter Footer()
            {
                return (DOCTORGroupFooter)_footer;
            }

            public TTReportField RECOURCE { get {return Header().RECOURCE;} }
            public TTReportField aaaaaaaa { get {return Header().aaaaaaaa;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportField NewField3 { get {return Header().NewField3;} }
            public TTReportShape NewLine11 { get {return Footer().NewLine11;} }
            public TTReportShape NewLine151 { get {return Footer().NewLine151;} }
            public TTReportShape NewLine1151 { get {return Footer().NewLine1151;} }
            public TTReportShape NewLine1152 { get {return Footer().NewLine1152;} }
            public TTReportShape NewLine1153 { get {return Footer().NewLine1153;} }
            public TTReportShape NewLine1154 { get {return Footer().NewLine1154;} }
            public TTReportField NewField4 { get {return Footer().NewField4;} }
            public TTReportField NewField5 { get {return Footer().NewField5;} }
            public DOCTORGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public DOCTORGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override object[] GetGroupByValues()
            {

                Appointment.GetMHRSAppointment_Class dataSet_GetMHRSAppointment = ParentGroup.rsGroup.GetCurrentRecord<Appointment.GetMHRSAppointment_Class>(0);    
                return new object[] {(dataSet_GetMHRSAppointment==null ? null : dataSet_GetMHRSAppointment.MasterResource)};
            }
            private void onConstruct()
            {
                _body = null;
                _header = new DOCTORGroupHeader(this);
                _footer = new DOCTORGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstParentRS;
            }

            public partial class DOCTORGroupHeader : TTReportSection
            {
                public MHRSAppointmentsReport MyParentReport
                {
                    get { return (MHRSAppointmentsReport)ParentReport; }
                }
                
                public TTReportField RECOURCE;
                public TTReportField aaaaaaaa;
                public TTReportField NewField1;
                public TTReportField NewField2;
                public TTReportField NewField3; 
                public DOCTORGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 19;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    RECOURCE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 7, 202, 12, false);
                    RECOURCE.Name = "RECOURCE";
                    RECOURCE.FieldType = ReportFieldTypeEnum.ftVariable;
                    RECOURCE.ObjectDefName = "Resource";
                    RECOURCE.DataMember = "NAME";
                    RECOURCE.TextFont.Bold = true;
                    RECOURCE.TextFont.CharSet = 162;
                    RECOURCE.Value = @"{#POLICLINIC.RESOURCE#}";

                    aaaaaaaa = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 26, 14, 51, 19, false);
                    aaaaaaaa.Name = "aaaaaaaa";
                    aaaaaaaa.DrawStyle = DrawStyleConstants.vbSolid;
                    aaaaaaaa.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    aaaaaaaa.TextFont.Bold = true;
                    aaaaaaaa.TextFont.CharSet = 162;
                    aaaaaaaa.Value = @"TC Kimlik Nu.";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 14, 102, 19, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"Adı Soyadı";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 102, 14, 161, 19, false);
                    NewField2.Name = "NewField2";
                    NewField2.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField2.TextFont.Bold = true;
                    NewField2.TextFont.CharSet = 0;
                    NewField2.Value = @"Randevu Saati";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 161, 14, 186, 19, false);
                    NewField3.Name = "NewField3";
                    NewField3.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField3.TextFont.Bold = true;
                    NewField3.TextFont.CharSet = 162;
                    NewField3.Value = @"Geldi/Gelmedi";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Appointment.GetMHRSAppointment_Class dataset_GetMHRSAppointment = MyParentReport.POLICLINIC.rsGroup.GetCurrentRecord<Appointment.GetMHRSAppointment_Class>(0);
                    RECOURCE.CalcValue = (dataset_GetMHRSAppointment != null ? Globals.ToStringCore(dataset_GetMHRSAppointment.Resource) : "");
                    RECOURCE.PostFieldValueCalculation();
                    aaaaaaaa.CalcValue = aaaaaaaa.Value;
                    NewField1.CalcValue = NewField1.Value;
                    NewField2.CalcValue = NewField2.Value;
                    NewField3.CalcValue = NewField3.Value;
                    return new TTReportObject[] { RECOURCE,aaaaaaaa,NewField1,NewField2,NewField3};
                }
            }
            public partial class DOCTORGroupFooter : TTReportSection
            {
                public MHRSAppointmentsReport MyParentReport
                {
                    get { return (MHRSAppointmentsReport)ParentReport; }
                }
                
                public TTReportShape NewLine11;
                public TTReportShape NewLine151;
                public TTReportShape NewLine1151;
                public TTReportShape NewLine1152;
                public TTReportShape NewLine1153;
                public TTReportShape NewLine1154;
                public TTReportField NewField4;
                public TTReportField NewField5; 
                public DOCTORGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 21;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 26, 2, 186, 2, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine151 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 26, -4, 26, 2, false);
                    NewLine151.Name = "NewLine151";
                    NewLine151.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1151 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 51, -4, 51, 2, false);
                    NewLine1151.Name = "NewLine1151";
                    NewLine1151.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1152 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 102, -4, 102, 2, false);
                    NewLine1152.Name = "NewLine1152";
                    NewLine1152.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1153 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 161, -4, 161, 2, false);
                    NewLine1153.Name = "NewLine1153";
                    NewLine1153.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1154 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 186, -4, 186, 2, false);
                    NewLine1154.Name = "NewLine1154";
                    NewLine1154.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 26, 6, 51, 11, false);
                    NewField4.Name = "NewField4";
                    NewField4.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField4.Value = @"Hasta Sayısı : {@subgroupcount@}";

                    NewField5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 22, 14, 191, 19, false);
                    NewField5.Name = "NewField5";
                    NewField5.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Appointment.GetMHRSAppointment_Class dataset_GetMHRSAppointment = MyParentReport.POLICLINIC.rsGroup.GetCurrentRecord<Appointment.GetMHRSAppointment_Class>(0);
                    NewField4.CalcValue = @"Hasta Sayısı : " + (ParentGroup.SubGroupCount - 1).ToString();
                    NewField5.CalcValue = NewField5.Value;
                    return new TTReportObject[] { NewField4,NewField5};
                }
            }

        }

        public DOCTORGroup DOCTOR;

        public partial class MAINGroup : TTReportGroup
        {
            public MHRSAppointmentsReport MyParentReport
            {
                get { return (MHRSAppointmentsReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField PATIENTNAME { get {return Body().PATIENTNAME;} }
            public TTReportField ACTION { get {return Body().ACTION;} }
            public TTReportField PATIENT { get {return Body().PATIENT;} }
            public TTReportShape NewLine1 { get {return Body().NewLine1;} }
            public TTReportShape NewLine15 { get {return Body().NewLine15;} }
            public TTReportField TCNO { get {return Body().TCNO;} }
            public TTReportField RANDEVUSAATI { get {return Body().RANDEVUSAATI;} }
            public TTReportField DURUMU { get {return Body().DURUMU;} }
            public TTReportField STARTTIME { get {return Body().STARTTIME;} }
            public TTReportField ENDTIME { get {return Body().ENDTIME;} }
            public TTReportField CANCELLEDBYISTISNA { get {return Body().CANCELLEDBYISTISNA;} }
            public TTReportField GELMEDURUMU { get {return Body().GELMEDURUMU;} }
            public TTReportField CANCELLED { get {return Body().CANCELLED;} }
            public TTReportShape NewLine13 { get {return Body().NewLine13;} }
            public TTReportShape NewLine131 { get {return Body().NewLine131;} }
            public TTReportShape NewLine132 { get {return Body().NewLine132;} }
            public TTReportShape NewLine133 { get {return Body().NewLine133;} }
            public MAINGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public MAINGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override object[] GetGroupByValues()
            {

                Appointment.GetMHRSAppointment_Class dataSet_GetMHRSAppointment = ParentGroup.rsGroup.GetCurrentRecord<Appointment.GetMHRSAppointment_Class>(0);    
                return new object[] {(dataSet_GetMHRSAppointment==null ? null : dataSet_GetMHRSAppointment.MasterResource), (dataSet_GetMHRSAppointment==null ? null : dataSet_GetMHRSAppointment.Resource)};
            }
            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new MAINGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstParentRS;
            }

            public partial class MAINGroupBody : TTReportSection
            {
                public MHRSAppointmentsReport MyParentReport
                {
                    get { return (MHRSAppointmentsReport)ParentReport; }
                }
                
                public TTReportField PATIENTNAME;
                public TTReportField ACTION;
                public TTReportField PATIENT;
                public TTReportShape NewLine1;
                public TTReportShape NewLine15;
                public TTReportField TCNO;
                public TTReportField RANDEVUSAATI;
                public TTReportField DURUMU;
                public TTReportField STARTTIME;
                public TTReportField ENDTIME;
                public TTReportField CANCELLEDBYISTISNA;
                public TTReportField GELMEDURUMU;
                public TTReportField CANCELLED;
                public TTReportShape NewLine13;
                public TTReportShape NewLine131;
                public TTReportShape NewLine132;
                public TTReportShape NewLine133; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 6;
                    RepeatCount = 0;
                    
                    PATIENTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 52, 1, 102, 6, false);
                    PATIENTNAME.Name = "PATIENTNAME";
                    PATIENTNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATIENTNAME.Value = @"";

                    ACTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 279, 1, 293, 6, false);
                    ACTION.Name = "ACTION";
                    ACTION.Visible = EvetHayirEnum.ehHayir;
                    ACTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACTION.Value = @"{#POLICLINIC.ACTION#}";

                    PATIENT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 295, 1, 311, 6, false);
                    PATIENT.Name = "PATIENT";
                    PATIENT.Visible = EvetHayirEnum.ehHayir;
                    PATIENT.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATIENT.Value = @"{#POLICLINIC.PATIENT#}";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 26, 0, 186, 0, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine15 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 186, -2, 186, 11, false);
                    NewLine15.Name = "NewLine15";
                    NewLine15.DrawStyle = DrawStyleConstants.vbSolid;

                    TCNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 27, 1, 50, 6, false);
                    TCNO.Name = "TCNO";
                    TCNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    TCNO.Value = @"";

                    RANDEVUSAATI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 103, 1, 159, 6, false);
                    RANDEVUSAATI.Name = "RANDEVUSAATI";
                    RANDEVUSAATI.FieldType = ReportFieldTypeEnum.ftVariable;
                    RANDEVUSAATI.Value = @"{%STARTTIME%} - {%ENDTIME%}";

                    DURUMU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 162, 1, 186, 6, false);
                    DURUMU.Name = "DURUMU";
                    DURUMU.FieldType = ReportFieldTypeEnum.ftVariable;
                    DURUMU.Value = @"";

                    STARTTIME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 262, 1, 277, 6, false);
                    STARTTIME.Name = "STARTTIME";
                    STARTTIME.Visible = EvetHayirEnum.ehHayir;
                    STARTTIME.FieldType = ReportFieldTypeEnum.ftVariable;
                    STARTTIME.TextFormat = @"dd/MM/yyyy HH:mm";
                    STARTTIME.Value = @"{#POLICLINIC.STARTTIME#}";

                    ENDTIME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 248, 1, 261, 6, false);
                    ENDTIME.Name = "ENDTIME";
                    ENDTIME.Visible = EvetHayirEnum.ehHayir;
                    ENDTIME.FieldType = ReportFieldTypeEnum.ftVariable;
                    ENDTIME.TextFormat = @"dd/MM/yyyy HH:mm";
                    ENDTIME.Value = @"{#POLICLINIC.ENDTIME#}";

                    CANCELLEDBYISTISNA = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 237, 2, 247, 7, false);
                    CANCELLEDBYISTISNA.Name = "CANCELLEDBYISTISNA";
                    CANCELLEDBYISTISNA.Visible = EvetHayirEnum.ehHayir;
                    CANCELLEDBYISTISNA.FieldType = ReportFieldTypeEnum.ftVariable;
                    CANCELLEDBYISTISNA.Value = @"{#POLICLINIC.ISCANCELLEDBYMHRSISTISNA#}";

                    GELMEDURUMU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 1, 235, 6, false);
                    GELMEDURUMU.Name = "GELMEDURUMU";
                    GELMEDURUMU.Visible = EvetHayirEnum.ehHayir;
                    GELMEDURUMU.FieldType = ReportFieldTypeEnum.ftVariable;
                    GELMEDURUMU.Value = @"{#POLICLINIC.CURRENTSTATEDEFID#}";

                    CANCELLED = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 206, 1, 222, 6, false);
                    CANCELLED.Name = "CANCELLED";
                    CANCELLED.Visible = EvetHayirEnum.ehHayir;
                    CANCELLED.FieldType = ReportFieldTypeEnum.ftVariable;
                    CANCELLED.Value = @"{#POLICLINIC.CANCELLEDMHRS#}";

                    NewLine13 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 102, -1, 102, 12, false);
                    NewLine13.Name = "NewLine13";
                    NewLine13.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine131 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 51, -1, 51, 12, false);
                    NewLine131.Name = "NewLine131";
                    NewLine131.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine132 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 161, 0, 161, 13, false);
                    NewLine132.Name = "NewLine132";
                    NewLine132.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine133 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 26, 0, 26, 13, false);
                    NewLine133.Name = "NewLine133";
                    NewLine133.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Appointment.GetMHRSAppointment_Class dataset_GetMHRSAppointment = MyParentReport.POLICLINIC.rsGroup.GetCurrentRecord<Appointment.GetMHRSAppointment_Class>(0);
                    PATIENTNAME.CalcValue = @"";
                    ACTION.CalcValue = (dataset_GetMHRSAppointment != null ? Globals.ToStringCore(dataset_GetMHRSAppointment.Action) : "");
                    PATIENT.CalcValue = (dataset_GetMHRSAppointment != null ? Globals.ToStringCore(dataset_GetMHRSAppointment.Patient) : "");
                    TCNO.CalcValue = @"";
                    STARTTIME.CalcValue = (dataset_GetMHRSAppointment != null ? Globals.ToStringCore(dataset_GetMHRSAppointment.StartTime) : "");
                    ENDTIME.CalcValue = (dataset_GetMHRSAppointment != null ? Globals.ToStringCore(dataset_GetMHRSAppointment.EndTime) : "");
                    RANDEVUSAATI.CalcValue = MyParentReport.MAIN.STARTTIME.FormattedValue + @" - " + MyParentReport.MAIN.ENDTIME.FormattedValue;
                    DURUMU.CalcValue = @"";
                    CANCELLEDBYISTISNA.CalcValue = (dataset_GetMHRSAppointment != null ? Globals.ToStringCore(dataset_GetMHRSAppointment.IsCancelledByMHRSIstisna) : "");
                    GELMEDURUMU.CalcValue = (dataset_GetMHRSAppointment != null ? Globals.ToStringCore(dataset_GetMHRSAppointment.CurrentStateDefID) : "");
                    CANCELLED.CalcValue = (dataset_GetMHRSAppointment != null ? Globals.ToStringCore(dataset_GetMHRSAppointment.CancelledMHRS) : "");
                    return new TTReportObject[] { PATIENTNAME,ACTION,PATIENT,TCNO,STARTTIME,ENDTIME,RANDEVUSAATI,DURUMU,CANCELLEDBYISTISNA,GELMEDURUMU,CANCELLED};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    TTObjectContext objectContext = new TTObjectContext(false);
            if(string.IsNullOrEmpty(this.PATIENT.CalcValue))
            {
                if( !string.IsNullOrEmpty(this.ACTION.CalcValue))
                {
                    Guid AdmissionAppointmentID = new Guid(this.ACTION.CalcValue);
                    AdmissionAppointment admissionAppointment = (AdmissionAppointment)objectContext.GetObject(AdmissionAppointmentID, "AdmissionAppointment");
                    
                    this.PATIENTNAME.CalcValue = admissionAppointment.PatientNameSurname;
                    this.TCNO.CalcValue = admissionAppointment.PatientUniqueRefNo != null ? admissionAppointment.PatientUniqueRefNo.ToString() : null;
                }
                
            }
            else
            {
                Guid PatientID = new Guid(this.PATIENT.CalcValue);
                Patient patient = (Patient)objectContext.GetObject(PatientID, "Patient");
                
                this.PATIENTNAME.CalcValue = patient.FullName;
                this.TCNO.CalcValue = patient.UniqueRefNo != null ? patient.UniqueRefNo.ToString() : null;
                
            }
            
            if(this.CANCELLEDBYISTISNA.CalcValue == "True")
                this.DURUMU.CalcValue = "İptal(İstisna)";
            else if(this.CANCELLED.CalcValue == "True")
                this.DURUMU.CalcValue = "İptal";
            else if(this.GELMEDURUMU.CalcValue == Appointment.States.Completed.ToString())
                this.DURUMU.CalcValue = "Geldi";
            else if(this.GELMEDURUMU.CalcValue != Appointment.States.Completed.ToString())
                this.DURUMU.CalcValue = "Gelmedi";
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

        public MHRSAppointmentsReport()
        {
            HEADER = new HEADERGroup(this,"HEADER");
            POLICLINIC = new POLICLINICGroup(HEADER,"POLICLINIC");
            DOCTOR = new DOCTORGroup(POLICLINIC,"DOCTOR");
            MAIN = new MAINGroup(DOCTOR,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("MASTERRESOURCE", "00000000-0000-0000-0000-000000000000", "Poliklinik", @"", false, true, false, new Guid("c0ae1e86-7d0f-412f-9366-d0199baae614"));
            reportParameter.ListDefID = new Guid("cf0f9ec0-906f-4eab-8752-4c8f8e1aec48");
            reportParameter.ListFilterExpression = "MHRSCODE IS NOT NULL AND MHRSALTKLINIKKODU IS NOT NULL";
            reportParameter = Parameters.Add("RESOURCE", "00000000-0000-0000-0000-000000000000", "Doktor", @"", false, true, false, new Guid("c0ae1e86-7d0f-412f-9366-d0199baae614"));
            reportParameter.ListDefID = new Guid("d6efe0cb-c3fd-430f-91fe-b4c7dae415b6");
            reportParameter.ListFilterExpression = "SENTTOMHRS='1'";
            reportParameter = Parameters.Add("STARTDATE", "", "Başlangıç Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENDDATE", "", "Bitiş Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("MASTERRESOURCE"))
                _runtimeParameters.MASTERRESOURCE = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid_"].ConvertValue(parameters["MASTERRESOURCE"]);
            if (parameters.ContainsKey("RESOURCE"))
                _runtimeParameters.RESOURCE = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid_"].ConvertValue(parameters["RESOURCE"]);
            if (parameters.ContainsKey("STARTDATE"))
                _runtimeParameters.STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTDATE"]);
            if (parameters.ContainsKey("ENDDATE"))
                _runtimeParameters.ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ENDDATE"]);
            Name = "MHRSAPPOINTMENTSREPORT";
            Caption = "MHRS Randevuları Raporu";
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
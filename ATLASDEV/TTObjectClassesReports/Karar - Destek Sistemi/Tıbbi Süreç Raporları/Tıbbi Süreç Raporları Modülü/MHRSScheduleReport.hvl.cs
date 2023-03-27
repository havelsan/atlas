
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
    public partial class MHRSScheduleReport : TTReport
    {
#region Methods
   public  Dictionary<Guid, double> MHRSActionTypes ;
   
#endregion Methods

        public class ReportRuntimeParameters 
        {
            public Guid? MASTERRESOURCE = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid_"].ConvertValue("00000000-0000-0000-0000-000000000000");
            public Guid? RESOURCE = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid_"].ConvertValue("00000000-0000-0000-0000-000000000000");
            public DateTime? STRATDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
        }

        public partial class HEADERGroup : TTReportGroup
        {
            public MHRSScheduleReport MyParentReport
            {
                get { return (MHRSScheduleReport)ParentReport; }
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
                public MHRSScheduleReport MyParentReport
                {
                    get { return (MHRSScheduleReport)ParentReport; }
                }
                
                public TTReportField XXXXXXBASLIK;
                public TTReportField NewField1;
                public TTReportField RDATE;
                public TTReportField NewField2;
                public TTReportField NewField3; 
                public HEADERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 40;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    XXXXXXBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 43, 5, 192, 23, false);
                    XXXXXXBASLIK.Name = "XXXXXXBASLIK";
                    XXXXXXBASLIK.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXBASLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.TextFont.Size = 11;
                    XXXXXXBASLIK.TextFont.Bold = true;
                    XXXXXXBASLIK.TextFont.CharSet = 162;
                    XXXXXXBASLIK.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + ""\r\n"" + TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 63, 27, 152, 38, false);
                    NewField1.Name = "NewField1";
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.TextFont.Size = 15;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"MHRS RANDEVU PLANI RAPORU";

                    RDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 188, 34, 205, 39, false);
                    RDATE.Name = "RDATE";
                    RDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    RDATE.TextFormat = @"dd/MM/yyyy";
                    RDATE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    RDATE.TextFont.Size = 9;
                    RDATE.TextFont.CharSet = 162;
                    RDATE.Value = @"{@printdate@}";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 178, 34, 186, 39, false);
                    NewField2.Name = "NewField2";
                    NewField2.TextFont.Size = 9;
                    NewField2.TextFont.Bold = true;
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @"Tarih";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 186, 34, 188, 39, false);
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
                public MHRSScheduleReport MyParentReport
                {
                    get { return (MHRSScheduleReport)ParentReport; }
                }
                
                public TTReportField NewField4; 
                public HEADERGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 11;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 91, 6, 116, 11, false);
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
            public MHRSScheduleReport MyParentReport
            {
                get { return (MHRSScheduleReport)ParentReport; }
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
                list[0] = new TTReportNqlData<Schedule.GetMHRSSchedules_Class>("GetMHRSSchedules", Schedule.GetMHRSSchedules((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.MASTERRESOURCE),(Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.RESOURCE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STRATDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE)));
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
                public MHRSScheduleReport MyParentReport
                {
                    get { return (MHRSScheduleReport)ParentReport; }
                }
                
                public TTReportField MASTERRESOURCE; 
                public POLICLINICGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 11;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    MASTERRESOURCE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 4, 4, 205, 9, false);
                    MASTERRESOURCE.Name = "MASTERRESOURCE";
                    MASTERRESOURCE.FieldType = ReportFieldTypeEnum.ftVariable;
                    MASTERRESOURCE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MASTERRESOURCE.ObjectDefName = "Resource";
                    MASTERRESOURCE.DataMember = "NAME";
                    MASTERRESOURCE.TextFont.Size = 12;
                    MASTERRESOURCE.TextFont.Bold = true;
                    MASTERRESOURCE.TextFont.CharSet = 162;
                    MASTERRESOURCE.Value = @"{#MASTERRESOURCE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Schedule.GetMHRSSchedules_Class dataset_GetMHRSSchedules = ParentGroup.rsGroup.GetCurrentRecord<Schedule.GetMHRSSchedules_Class>(0);
                    MASTERRESOURCE.CalcValue = (dataset_GetMHRSSchedules != null ? Globals.ToStringCore(dataset_GetMHRSSchedules.MasterResource) : "");
                    MASTERRESOURCE.PostFieldValueCalculation();
                    return new TTReportObject[] { MASTERRESOURCE};
                }
            }
            public partial class POLICLINICGroupFooter : TTReportSection
            {
                public MHRSScheduleReport MyParentReport
                {
                    get { return (MHRSScheduleReport)ParentReport; }
                }
                 
                public POLICLINICGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public POLICLINICGroup POLICLINIC;

        public partial class DOCTORGroup : TTReportGroup
        {
            public MHRSScheduleReport MyParentReport
            {
                get { return (MHRSScheduleReport)ParentReport; }
            }

            new public DOCTORGroupHeader Header()
            {
                return (DOCTORGroupHeader)_header;
            }

            new public DOCTORGroupFooter Footer()
            {
                return (DOCTORGroupFooter)_footer;
            }

            public TTReportField RESOURCE { get {return Header().RESOURCE;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportShape NewLine111 { get {return Header().NewLine111;} }
            public TTReportShape NewLine124 { get {return Header().NewLine124;} }
            public TTReportShape NewLine1421 { get {return Header().NewLine1421;} }
            public TTReportShape NewLine1422 { get {return Header().NewLine1422;} }
            public TTReportShape NewLine1423 { get {return Header().NewLine1423;} }
            public TTReportShape NewLine11 { get {return Footer().NewLine11;} }
            public TTReportShape NewLine12 { get {return Footer().NewLine12;} }
            public TTReportShape NewLine121 { get {return Footer().NewLine121;} }
            public TTReportShape NewLine122 { get {return Footer().NewLine122;} }
            public TTReportShape NewLine123 { get {return Footer().NewLine123;} }
            public TTReportRTF MHRSACTIONHOURS { get {return Footer().MHRSACTIONHOURS;} }
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

                Schedule.GetMHRSSchedules_Class dataSet_GetMHRSSchedules = ParentGroup.rsGroup.GetCurrentRecord<Schedule.GetMHRSSchedules_Class>(0);    
                return new object[] {(dataSet_GetMHRSSchedules==null ? null : dataSet_GetMHRSSchedules.MasterResource)};
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
                public MHRSScheduleReport MyParentReport
                {
                    get { return (MHRSScheduleReport)ParentReport; }
                }
                
                public TTReportField RESOURCE;
                public TTReportField NewField11;
                public TTReportField NewField12;
                public TTReportField NewField121;
                public TTReportShape NewLine111;
                public TTReportShape NewLine124;
                public TTReportShape NewLine1421;
                public TTReportShape NewLine1422;
                public TTReportShape NewLine1423; 
                public DOCTORGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 16;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    RESOURCE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 3, 202, 8, false);
                    RESOURCE.Name = "RESOURCE";
                    RESOURCE.FieldType = ReportFieldTypeEnum.ftVariable;
                    RESOURCE.ObjectDefName = "Resource";
                    RESOURCE.DataMember = "NAME";
                    RESOURCE.TextFont.Bold = true;
                    RESOURCE.TextFont.CharSet = 162;
                    RESOURCE.Value = @"{#POLICLINIC.RESOURCE#}";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 11, 80, 16, false);
                    NewField11.Name = "NewField11";
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"Başlangıç - Bitiş Tarihi";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 82, 11, 165, 16, false);
                    NewField12.Name = "NewField12";
                    NewField12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"Aksiyon Tipi";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 167, 11, 200, 16, false);
                    NewField121.Name = "NewField121";
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"MHRA Randevu Durumu";

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 17, 10, 201, 10, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine124 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 17, 10, 17, 19, false);
                    NewLine124.Name = "NewLine124";
                    NewLine124.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1421 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 81, 10, 81, 19, false);
                    NewLine1421.Name = "NewLine1421";
                    NewLine1421.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1422 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 166, 10, 166, 19, false);
                    NewLine1422.Name = "NewLine1422";
                    NewLine1422.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1423 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 201, 10, 201, 19, false);
                    NewLine1423.Name = "NewLine1423";
                    NewLine1423.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Schedule.GetMHRSSchedules_Class dataset_GetMHRSSchedules = MyParentReport.POLICLINIC.rsGroup.GetCurrentRecord<Schedule.GetMHRSSchedules_Class>(0);
                    RESOURCE.CalcValue = (dataset_GetMHRSSchedules != null ? Globals.ToStringCore(dataset_GetMHRSSchedules.Resource) : "");
                    RESOURCE.PostFieldValueCalculation();
                    NewField11.CalcValue = NewField11.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField121.CalcValue = NewField121.Value;
                    return new TTReportObject[] { RESOURCE,NewField11,NewField12,NewField121};
                }
            }
            public partial class DOCTORGroupFooter : TTReportSection
            {
                public MHRSScheduleReport MyParentReport
                {
                    get { return (MHRSScheduleReport)ParentReport; }
                }
                
                public TTReportShape NewLine11;
                public TTReportShape NewLine12;
                public TTReportShape NewLine121;
                public TTReportShape NewLine122;
                public TTReportShape NewLine123;
                public TTReportRTF MHRSACTIONHOURS; 
                public DOCTORGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 24;
                    RepeatCount = 0;
                    
                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 17, 2, 201, 2, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 17, -2, 17, 2, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 81, -2, 81, 2, false);
                    NewLine121.Name = "NewLine121";
                    NewLine121.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine122 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 166, -2, 166, 2, false);
                    NewLine122.Name = "NewLine122";
                    NewLine122.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine123 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 201, -2, 201, 2, false);
                    NewLine123.Name = "NewLine123";
                    NewLine123.DrawStyle = DrawStyleConstants.vbSolid;

                    MHRSACTIONHOURS = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 17, 6, 201, 19, false);
                    MHRSACTIONHOURS.Name = "MHRSACTIONHOURS";
                    MHRSACTIONHOURS.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Schedule.GetMHRSSchedules_Class dataset_GetMHRSSchedules = MyParentReport.POLICLINIC.rsGroup.GetCurrentRecord<Schedule.GetMHRSSchedules_Class>(0);
                    MHRSACTIONHOURS.CalcValue = MHRSACTIONHOURS.Value;
                    return new TTReportObject[] { MHRSACTIONHOURS};
                }
                public override void RunPreScript()
                {
#region DOCTOR FOOTER_PreScript
                    string actionInfo = string.Empty ;
            foreach(var pair in this.MyParentReport.MHRSActionTypes)
            {
                TTObjectContext objectContext = new TTObjectContext(false);
                MHRSActionTypeDefinition MHRSActionType = (MHRSActionTypeDefinition)objectContext.GetObject(pair.Key, "MHRSActionTypeDefinition");                
                actionInfo = "Aksiyon Tipi =  " + MHRSActionType.ActionName + " Toplam Saat = " + pair.Value + "\r\n";
                this.MHRSACTIONHOURS.Value += Globals.StringToRTF(actionInfo);
            }
#endregion DOCTOR FOOTER_PreScript
                }
            }

        }

        public DOCTORGroup DOCTOR;

        public partial class MAINGroup : TTReportGroup
        {
            public MHRSScheduleReport MyParentReport
            {
                get { return (MHRSScheduleReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField txtStartEndTime { get {return Body().txtStartEndTime;} }
            public TTReportField txtMHRSActionType { get {return Body().txtMHRSActionType;} }
            public TTReportField OPENMHRS { get {return Body().OPENMHRS;} }
            public TTReportField MHRSISTISNAID { get {return Body().MHRSISTISNAID;} }
            public TTReportField MHRSDURUMU { get {return Body().MHRSDURUMU;} }
            public TTReportShape NewLine1 { get {return Body().NewLine1;} }
            public TTReportShape NewLine2 { get {return Body().NewLine2;} }
            public TTReportShape NewLine12 { get {return Body().NewLine12;} }
            public TTReportShape NewLine121 { get {return Body().NewLine121;} }
            public TTReportShape NewLine1121 { get {return Body().NewLine1121;} }
            public TTReportField OBJECTID { get {return Body().OBJECTID;} }
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

                Schedule.GetMHRSSchedules_Class dataSet_GetMHRSSchedules = ParentGroup.rsGroup.GetCurrentRecord<Schedule.GetMHRSSchedules_Class>(0);    
                return new object[] {(dataSet_GetMHRSSchedules==null ? null : dataSet_GetMHRSSchedules.MasterResource), (dataSet_GetMHRSSchedules==null ? null : dataSet_GetMHRSSchedules.Resource)};
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
                public MHRSScheduleReport MyParentReport
                {
                    get { return (MHRSScheduleReport)ParentReport; }
                }
                
                public TTReportField txtStartEndTime;
                public TTReportField txtMHRSActionType;
                public TTReportField OPENMHRS;
                public TTReportField MHRSISTISNAID;
                public TTReportField MHRSDURUMU;
                public TTReportShape NewLine1;
                public TTReportShape NewLine2;
                public TTReportShape NewLine12;
                public TTReportShape NewLine121;
                public TTReportShape NewLine1121;
                public TTReportField OBJECTID; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 7;
                    RepeatCount = 0;
                    
                    txtStartEndTime = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 2, 80, 7, false);
                    txtStartEndTime.Name = "txtStartEndTime";
                    txtStartEndTime.FieldType = ReportFieldTypeEnum.ftVariable;
                    txtStartEndTime.Value = @"{#POLICLINIC.STARTTIME#} - {#POLICLINIC.ENDTIME#}";

                    txtMHRSActionType = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 82, 2, 166, 7, false);
                    txtMHRSActionType.Name = "txtMHRSActionType";
                    txtMHRSActionType.FieldType = ReportFieldTypeEnum.ftVariable;
                    txtMHRSActionType.ObjectDefName = "MHRSActionTypeDefinition";
                    txtMHRSActionType.DataMember = "ACTIONNAME";
                    txtMHRSActionType.Value = @"{#POLICLINIC.MHRSACTIONTYPEDEFINITION#}";

                    OPENMHRS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 2, 231, 7, false);
                    OPENMHRS.Name = "OPENMHRS";
                    OPENMHRS.Visible = EvetHayirEnum.ehHayir;
                    OPENMHRS.FieldType = ReportFieldTypeEnum.ftVariable;
                    OPENMHRS.Value = @"{#POLICLINIC.OPENMHRS#}";

                    MHRSISTISNAID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 233, 2, 258, 7, false);
                    MHRSISTISNAID.Name = "MHRSISTISNAID";
                    MHRSISTISNAID.Visible = EvetHayirEnum.ehHayir;
                    MHRSISTISNAID.FieldType = ReportFieldTypeEnum.ftVariable;
                    MHRSISTISNAID.Value = @"{#POLICLINIC.MHRSISTISNAID#}";

                    MHRSDURUMU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 167, 2, 200, 7, false);
                    MHRSDURUMU.Name = "MHRSDURUMU";
                    MHRSDURUMU.Value = @"";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 17, 1, 201, 1, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 17, -1, 17, 10, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 81, -1, 81, 10, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 166, -1, 166, 10, false);
                    NewLine121.Name = "NewLine121";
                    NewLine121.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 201, 0, 201, 9, false);
                    NewLine1121.Name = "NewLine1121";
                    NewLine1121.DrawStyle = DrawStyleConstants.vbSolid;

                    OBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 259, 2, 284, 7, false);
                    OBJECTID.Name = "OBJECTID";
                    OBJECTID.Visible = EvetHayirEnum.ehHayir;
                    OBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBJECTID.Value = @"{#POLICLINIC.OBJECTID#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Schedule.GetMHRSSchedules_Class dataset_GetMHRSSchedules = MyParentReport.POLICLINIC.rsGroup.GetCurrentRecord<Schedule.GetMHRSSchedules_Class>(0);
                    txtStartEndTime.CalcValue = (dataset_GetMHRSSchedules != null ? Globals.ToStringCore(dataset_GetMHRSSchedules.StartTime) : "") + @" - " + (dataset_GetMHRSSchedules != null ? Globals.ToStringCore(dataset_GetMHRSSchedules.EndTime) : "");
                    txtMHRSActionType.CalcValue = (dataset_GetMHRSSchedules != null ? Globals.ToStringCore(dataset_GetMHRSSchedules.MHRSActionTypeDefinition) : "");
                    txtMHRSActionType.PostFieldValueCalculation();
                    OPENMHRS.CalcValue = (dataset_GetMHRSSchedules != null ? Globals.ToStringCore(dataset_GetMHRSSchedules.OpenMHRS) : "");
                    MHRSISTISNAID.CalcValue = (dataset_GetMHRSSchedules != null ? Globals.ToStringCore(dataset_GetMHRSSchedules.MHRSIstisnaID) : "");
                    MHRSDURUMU.CalcValue = MHRSDURUMU.Value;
                    OBJECTID.CalcValue = (dataset_GetMHRSSchedules != null ? Globals.ToStringCore(dataset_GetMHRSSchedules.ObjectID) : "");
                    return new TTReportObject[] { txtStartEndTime,txtMHRSActionType,OPENMHRS,MHRSISTISNAID,MHRSDURUMU,OBJECTID};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    if(this.OPENMHRS.CalcValue == "True")
                this.MHRSDURUMU.CalcValue = "Açık";
            else
                this.MHRSDURUMU.CalcValue = "Kapalı";
            
            if(!string.IsNullOrEmpty(this.MHRSISTISNAID.CalcValue))
                this.MHRSDURUMU.CalcValue += "(İstisna)";
            
            
            TTObjectContext objectContext = new TTObjectContext(false);
            Guid ScheduleID = new Guid(this.OBJECTID.CalcValue);
            
            Schedule schedule = (Schedule)objectContext.GetObject(ScheduleID, "Schedule");

            TimeSpan hour = schedule.EndTime.Value.Subtract(schedule.StartTime.Value);
            


            if (schedule != null && schedule.MHRSActionTypeDefinition != null)
            {
                if (!this.MyParentReport.MHRSActionTypes.ContainsKey(schedule.MHRSActionTypeDefinition.ObjectID))
                {
                    this.MyParentReport.MHRSActionTypes.Add(schedule.MHRSActionTypeDefinition.ObjectID, hour.TotalHours);
                }
                else
                    this.MyParentReport.MHRSActionTypes[schedule.MHRSActionTypeDefinition.ObjectID] += hour.TotalHours;
                
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

        public MHRSScheduleReport()
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
            reportParameter = Parameters.Add("STRATDATE", "", "Başlangıç Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENDDATE", "", "Bitiş Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("MASTERRESOURCE"))
                _runtimeParameters.MASTERRESOURCE = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid_"].ConvertValue(parameters["MASTERRESOURCE"]);
            if (parameters.ContainsKey("RESOURCE"))
                _runtimeParameters.RESOURCE = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid_"].ConvertValue(parameters["RESOURCE"]);
            if (parameters.ContainsKey("STRATDATE"))
                _runtimeParameters.STRATDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STRATDATE"]);
            if (parameters.ContainsKey("ENDDATE"))
                _runtimeParameters.ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ENDDATE"]);
            Name = "MHRSSCHEDULEREPORT";
            Caption = "MHRS Doktor Randevu Planları Raporu";
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


        protected override void RunPreScript()
        {
#region MHRSSCHEDULEREPORT_PreScript
            MHRSActionTypes = new Dictionary<Guid, double>();
#endregion MHRSSCHEDULEREPORT_PreScript
        }
    }
}
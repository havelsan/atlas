
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
    /// Hek Raporu Düzenlenen Tibbi Cihazlar Raporu
    /// </summary>
    public partial class HEKRaporuDuzenlenenCihazlarRaporu : TTReport
    {
#region Methods
   public int counter=0;
   
#endregion Methods

        public class ReportRuntimeParameters 
        {
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public Guid? SENDERSECTION = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
            public Guid? PERSONNEL = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
            public int? STOREFLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue("");
            public int? PERSONFLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue("");
        }

        public partial class HEADERGroup : TTReportGroup
        {
            public HEKRaporuDuzenlenenCihazlarRaporu MyParentReport
            {
                get { return (HEKRaporuDuzenlenenCihazlarRaporu)ParentReport; }
            }

            new public HEADERGroupHeader Header()
            {
                return (HEADERGroupHeader)_header;
            }

            new public HEADERGroupFooter Footer()
            {
                return (HEADERGroupFooter)_footer;
            }

            public TTReportField REPORTHEADER { get {return Header().REPORTHEADER;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField NewField1111 { get {return Header().NewField1111;} }
            public TTReportField NewField11111 { get {return Header().NewField11111;} }
            public TTReportField NewField111111 { get {return Header().NewField111111;} }
            public TTReportField NewField112 { get {return Header().NewField112;} }
            public TTReportField NewField1211 { get {return Header().NewField1211;} }
            public TTReportField NewField11121 { get {return Header().NewField11121;} }
            public TTReportField HOSPITAL111 { get {return Header().HOSPITAL111;} }
            public TTReportField NewField151 { get {return Header().NewField151;} }
            public TTReportField NewField161 { get {return Header().NewField161;} }
            public TTReportField NewField171 { get {return Header().NewField171;} }
            public TTReportField NewField1111111 { get {return Header().NewField1111111;} }
            public TTReportField NewField2 { get {return Footer().NewField2;} }
            public TTReportField SUM { get {return Footer().SUM;} }
            public TTReportField NewField121 { get {return Footer().NewField121;} }
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
                public HEKRaporuDuzenlenenCihazlarRaporu MyParentReport
                {
                    get { return (HEKRaporuDuzenlenenCihazlarRaporu)ParentReport; }
                }
                
                public TTReportField REPORTHEADER;
                public TTReportField NewField1;
                public TTReportField NewField11;
                public TTReportField NewField111;
                public TTReportField NewField1111;
                public TTReportField NewField11111;
                public TTReportField NewField111111;
                public TTReportField NewField112;
                public TTReportField NewField1211;
                public TTReportField NewField11121;
                public TTReportField HOSPITAL111;
                public TTReportField NewField151;
                public TTReportField NewField161;
                public TTReportField NewField171;
                public TTReportField NewField1111111; 
                public HEADERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 63;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    REPORTHEADER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 25, 222, 41, false);
                    REPORTHEADER.Name = "REPORTHEADER";
                    REPORTHEADER.FieldType = ReportFieldTypeEnum.ftVariable;
                    REPORTHEADER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REPORTHEADER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REPORTHEADER.MultiLine = EvetHayirEnum.ehEvet;
                    REPORTHEADER.NoClip = EvetHayirEnum.ehEvet;
                    REPORTHEADER.WordBreak = EvetHayirEnum.ehEvet;
                    REPORTHEADER.ExpandTabs = EvetHayirEnum.ehEvet;
                    REPORTHEADER.TextFont.Size = 14;
                    REPORTHEADER.TextFont.Bold = true;
                    REPORTHEADER.TextFont.CharSet = 162;
                    REPORTHEADER.Value = @"";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 51, 28, 63, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"S.NU.";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 28, 51, 49, 63, false);
                    NewField11.Name = "NewField11";
                    NewField11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"İŞ İSTEK  NU.";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 49, 51, 179, 57, false);
                    NewField111.Name = "NewField111";
                    NewField111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"CİHAZIN";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 49, 57, 88, 63, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111.TextFont.Bold = true;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @"ADI";

                    NewField11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 88, 57, 122, 63, false);
                    NewField11111.Name = "NewField11111";
                    NewField11111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11111.TextFont.Bold = true;
                    NewField11111.TextFont.CharSet = 162;
                    NewField11111.Value = @"MARKA/MODELİ";

                    NewField111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 57, 179, 63, false);
                    NewField111111.Name = "NewField111111";
                    NewField111111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111111.TextFont.Bold = true;
                    NewField111111.TextFont.CharSet = 162;
                    NewField111111.Value = @"KLİNİĞİ";

                    NewField112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 179, 51, 216, 63, false);
                    NewField112.Name = "NewField112";
                    NewField112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112.MultiLine = EvetHayirEnum.ehEvet;
                    NewField112.WordBreak = EvetHayirEnum.ehEvet;
                    NewField112.TextFont.Bold = true;
                    NewField112.TextFont.CharSet = 162;
                    NewField112.Value = @"ONARIMI YAPAN TEKNİSYEN";

                    NewField1211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 216, 51, 246, 63, false);
                    NewField1211.Name = "NewField1211";
                    NewField1211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1211.TextFont.Bold = true;
                    NewField1211.TextFont.CharSet = 162;
                    NewField1211.Value = @"HEK TARİHİ";

                    NewField11121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 246, 51, 279, 63, false);
                    NewField11121.Name = "NewField11121";
                    NewField11121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11121.TextFont.Bold = true;
                    NewField11121.TextFont.CharSet = 162;
                    NewField11121.Value = @"RAPOR NUMARASI";

                    HOSPITAL111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 6, 236, 23, false);
                    HOSPITAL111.Name = "HOSPITAL111";
                    HOSPITAL111.FieldType = ReportFieldTypeEnum.ftExpression;
                    HOSPITAL111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HOSPITAL111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HOSPITAL111.TextFont.Name = "Arial";
                    HOSPITAL111.TextFont.Size = 12;
                    HOSPITAL111.TextFont.Bold = true;
                    HOSPITAL111.TextFont.CharSet = 162;
                    HOSPITAL111.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """")";

                    NewField151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 97, 41, 132, 46, false);
                    NewField151.Name = "NewField151";
                    NewField151.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField151.TextFormat = @"Short Date";
                    NewField151.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField151.TextFont.Size = 11;
                    NewField151.TextFont.Bold = true;
                    NewField151.TextFont.CharSet = 162;
                    NewField151.Value = @"{@STARTDATE@}";

                    NewField161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 134, 41, 141, 46, false);
                    NewField161.Name = "NewField161";
                    NewField161.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField161.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField161.TextFont.Size = 11;
                    NewField161.TextFont.Bold = true;
                    NewField161.TextFont.CharSet = 162;
                    NewField161.Value = @"-";

                    NewField171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 144, 41, 178, 46, false);
                    NewField171.Name = "NewField171";
                    NewField171.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField171.TextFormat = @"Short Date";
                    NewField171.TextFont.Size = 11;
                    NewField171.TextFont.Bold = true;
                    NewField171.TextFont.CharSet = 162;
                    NewField171.Value = @"{@ENDDATE@}";

                    NewField1111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 122, 57, 143, 63, false);
                    NewField1111111.Name = "NewField1111111";
                    NewField1111111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111111.TextFont.Bold = true;
                    NewField1111111.TextFont.CharSet = 162;
                    NewField1111111.Value = @"MİKTARI";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    REPORTHEADER.CalcValue = @"";
                    NewField1.CalcValue = NewField1.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField111.CalcValue = NewField111.Value;
                    NewField1111.CalcValue = NewField1111.Value;
                    NewField11111.CalcValue = NewField11111.Value;
                    NewField111111.CalcValue = NewField111111.Value;
                    NewField112.CalcValue = NewField112.Value;
                    NewField1211.CalcValue = NewField1211.Value;
                    NewField11121.CalcValue = NewField11121.Value;
                    NewField151.CalcValue = MyParentReport.RuntimeParameters.STARTDATE.ToString();
                    NewField161.CalcValue = NewField161.Value;
                    NewField171.CalcValue = MyParentReport.RuntimeParameters.ENDDATE.ToString();
                    NewField1111111.CalcValue = NewField1111111.Value;
                    HOSPITAL111.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "");
                    return new TTReportObject[] { REPORTHEADER,NewField1,NewField11,NewField111,NewField1111,NewField11111,NewField111111,NewField112,NewField1211,NewField11121,NewField151,NewField161,NewField171,NewField1111111,HOSPITAL111};
                }

                public override void RunScript()
                {
#region HEADER HEADER_Script
                    if(((HEKRaporuDuzenlenenCihazlarRaporu)ParentReport).RuntimeParameters.PERSONNEL == Guid.Empty)
                ((HEKRaporuDuzenlenenCihazlarRaporu)ParentReport).RuntimeParameters.PERSONFLAG = 1;
            else
                ((HEKRaporuDuzenlenenCihazlarRaporu)ParentReport).RuntimeParameters.PERSONFLAG = 0;
            
             if(((HEKRaporuDuzenlenenCihazlarRaporu)ParentReport).RuntimeParameters.SENDERSECTION == Guid.Empty)
                ((HEKRaporuDuzenlenenCihazlarRaporu)ParentReport).RuntimeParameters.STOREFLAG = 1;
            else
                ((HEKRaporuDuzenlenenCihazlarRaporu)ParentReport).RuntimeParameters.STOREFLAG = 0;
            
            
            
            Guid siteIDGuid = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("SITEID", Guid.Empty.ToString()));
            if (Sites.SiteXXXXXX06XXXXXX == siteIDGuid || Sites.SiteXXXXXX04 == siteIDGuid)
                REPORTHEADER.CalcValue = " XXXXXX BİYOMEDİKAL MÜHENDİSLİK MERKEZİ \n HEK RAPORU DÜZENLENEN TIBBİ CİHAZLAR RAPORU";
            else
                REPORTHEADER.CalcValue = "\n HEK RAPORU DÜZENLENEN TIBBİ CİHAZLAR RAPORU";
#endregion HEADER HEADER_Script
                }
            }
            public partial class HEADERGroupFooter : TTReportSection
            {
                public HEKRaporuDuzenlenenCihazlarRaporu MyParentReport
                {
                    get { return (HEKRaporuDuzenlenenCihazlarRaporu)ParentReport; }
                }
                
                public TTReportField NewField2;
                public TTReportField SUM;
                public TTReportField NewField121; 
                public HEADERGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 12;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 5, 129, 10, false);
                    NewField2.Name = "NewField2";
                    NewField2.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField2.Value = @"Bu rapor  {@printdate@} Tarihinde alınmıştır.";

                    SUM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 122, 0, 143, 5, false);
                    SUM.Name = "SUM";
                    SUM.FieldType = ReportFieldTypeEnum.ftVariable;
                    SUM.HorzAlign = HorizontalAlignmentEnum.haRight;
                    SUM.Value = @"";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 101, 0, 122, 5, false);
                    NewField121.Name = "NewField121";
                    NewField121.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField121.Value = @"TOPLAM : ";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField2.CalcValue = @"Bu rapor  " + DateTime.Now.ToShortDateString() + @" Tarihinde alınmıştır.";
                    SUM.CalcValue = @"";
                    NewField121.CalcValue = NewField121.Value;
                    return new TTReportObject[] { NewField2,SUM,NewField121};
                }

                public override void RunScript()
                {
#region HEADER FOOTER_Script
                    SUM.CalcValue = (((HEKRaporuDuzenlenenCihazlarRaporu)ParentReport).counter).ToString();
            ((HEKRaporuDuzenlenenCihazlarRaporu)ParentReport).counter = 0;
#endregion HEADER FOOTER_Script
                }
            }

        }

        public HEADERGroup HEADER;

        public partial class MAINGroup : TTReportGroup
        {
            public HEKRaporuDuzenlenenCihazlarRaporu MyParentReport
            {
                get { return (HEKRaporuDuzenlenenCihazlarRaporu)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField NewField1 { get {return Body().NewField1;} }
            public TTReportField REQUESTNO { get {return Body().REQUESTNO;} }
            public TTReportField SENDERSECTION { get {return Body().SENDERSECTION;} }
            public TTReportField HEKREPORTNO { get {return Body().HEKREPORTNO;} }
            public TTReportField FAMNAME { get {return Body().FAMNAME;} }
            public TTReportField DEVICEUSER { get {return Body().DEVICEUSER;} }
            public TTReportField ENDDATE { get {return Body().ENDDATE;} }
            public TTReportField MARKMODEL { get {return Body().MARKMODEL;} }
            public TTReportField OBJECTID { get {return Body().OBJECTID;} }
            public TTReportField RULOBJECTID { get {return Body().RULOBJECTID;} }
            public TTReportField RUL { get {return Body().RUL;} }
            public MAINGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public MAINGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<Repair.GetHEKReportQuery_Class>("GetHEKReportQuery", Repair.GetHEKReportQuery((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE),(Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.SENDERSECTION),(Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.PERSONNEL),(int)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(MyParentReport.RuntimeParameters.PERSONFLAG),(int)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(MyParentReport.RuntimeParameters.STOREFLAG)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new MAINGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class MAINGroupBody : TTReportSection
            {
                public HEKRaporuDuzenlenenCihazlarRaporu MyParentReport
                {
                    get { return (HEKRaporuDuzenlenenCihazlarRaporu)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportField REQUESTNO;
                public TTReportField SENDERSECTION;
                public TTReportField HEKREPORTNO;
                public TTReportField FAMNAME;
                public TTReportField DEVICEUSER;
                public TTReportField ENDDATE;
                public TTReportField MARKMODEL;
                public TTReportField OBJECTID;
                public TTReportField RULOBJECTID;
                public TTReportField RUL; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 12;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 0, 28, 12, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1.Value = @"{@counter@}";

                    REQUESTNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 28, 0, 49, 12, false);
                    REQUESTNO.Name = "REQUESTNO";
                    REQUESTNO.DrawStyle = DrawStyleConstants.vbSolid;
                    REQUESTNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    REQUESTNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REQUESTNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REQUESTNO.MultiLine = EvetHayirEnum.ehEvet;
                    REQUESTNO.WordBreak = EvetHayirEnum.ehEvet;
                    REQUESTNO.TextFont.Size = 9;
                    REQUESTNO.TextFont.CharSet = 162;
                    REQUESTNO.Value = @"{#REQUESTNO#}";

                    SENDERSECTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 0, 179, 12, false);
                    SENDERSECTION.Name = "SENDERSECTION";
                    SENDERSECTION.DrawStyle = DrawStyleConstants.vbSolid;
                    SENDERSECTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    SENDERSECTION.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SENDERSECTION.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SENDERSECTION.MultiLine = EvetHayirEnum.ehEvet;
                    SENDERSECTION.WordBreak = EvetHayirEnum.ehEvet;
                    SENDERSECTION.TextFont.Size = 9;
                    SENDERSECTION.TextFont.CharSet = 162;
                    SENDERSECTION.Value = @"{#SENDERSECTION#}";

                    HEKREPORTNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 246, 0, 279, 12, false);
                    HEKREPORTNO.Name = "HEKREPORTNO";
                    HEKREPORTNO.DrawStyle = DrawStyleConstants.vbSolid;
                    HEKREPORTNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    HEKREPORTNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HEKREPORTNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HEKREPORTNO.MultiLine = EvetHayirEnum.ehEvet;
                    HEKREPORTNO.WordBreak = EvetHayirEnum.ehEvet;
                    HEKREPORTNO.TextFont.Size = 9;
                    HEKREPORTNO.TextFont.CharSet = 162;
                    HEKREPORTNO.Value = @"{#HEKREPORTNO#}";

                    FAMNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 49, 0, 88, 12, false);
                    FAMNAME.Name = "FAMNAME";
                    FAMNAME.DrawStyle = DrawStyleConstants.vbSolid;
                    FAMNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    FAMNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    FAMNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FAMNAME.MultiLine = EvetHayirEnum.ehEvet;
                    FAMNAME.WordBreak = EvetHayirEnum.ehEvet;
                    FAMNAME.TextFont.Size = 9;
                    FAMNAME.TextFont.CharSet = 162;
                    FAMNAME.Value = @"{#FAMNAME#}";

                    DEVICEUSER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 179, 0, 216, 12, false);
                    DEVICEUSER.Name = "DEVICEUSER";
                    DEVICEUSER.DrawStyle = DrawStyleConstants.vbSolid;
                    DEVICEUSER.FieldType = ReportFieldTypeEnum.ftVariable;
                    DEVICEUSER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DEVICEUSER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DEVICEUSER.MultiLine = EvetHayirEnum.ehEvet;
                    DEVICEUSER.WordBreak = EvetHayirEnum.ehEvet;
                    DEVICEUSER.TextFont.Size = 9;
                    DEVICEUSER.TextFont.CharSet = 162;
                    DEVICEUSER.Value = @"{#DEVICEUSER#}";

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 216, 0, 246, 12, false);
                    ENDDATE.Name = "ENDDATE";
                    ENDDATE.DrawStyle = DrawStyleConstants.vbSolid;
                    ENDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ENDDATE.TextFormat = @"Short Date";
                    ENDDATE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ENDDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ENDDATE.MultiLine = EvetHayirEnum.ehEvet;
                    ENDDATE.WordBreak = EvetHayirEnum.ehEvet;
                    ENDDATE.TextFont.Size = 9;
                    ENDDATE.TextFont.CharSet = 162;
                    ENDDATE.Value = @"";

                    MARKMODEL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 88, 0, 122, 12, false);
                    MARKMODEL.Name = "MARKMODEL";
                    MARKMODEL.DrawStyle = DrawStyleConstants.vbSolid;
                    MARKMODEL.FieldType = ReportFieldTypeEnum.ftVariable;
                    MARKMODEL.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MARKMODEL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MARKMODEL.MultiLine = EvetHayirEnum.ehEvet;
                    MARKMODEL.WordBreak = EvetHayirEnum.ehEvet;
                    MARKMODEL.Value = @"{#MARK#} - {#MODEL#}";

                    OBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 306, 3, 331, 8, false);
                    OBJECTID.Name = "OBJECTID";
                    OBJECTID.Visible = EvetHayirEnum.ehHayir;
                    OBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBJECTID.Value = @"{#OBJECTID#}";

                    RULOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 335, 2, 360, 7, false);
                    RULOBJECTID.Name = "RULOBJECTID";
                    RULOBJECTID.Visible = EvetHayirEnum.ehHayir;
                    RULOBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    RULOBJECTID.Value = @"{#RULOBJECTID#}";

                    RUL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 122, 0, 143, 12, false);
                    RUL.Name = "RUL";
                    RUL.DrawStyle = DrawStyleConstants.vbSolid;
                    RUL.FieldType = ReportFieldTypeEnum.ftVariable;
                    RUL.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    RUL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    RUL.MultiLine = EvetHayirEnum.ehEvet;
                    RUL.WordBreak = EvetHayirEnum.ehEvet;
                    RUL.TextFont.Size = 9;
                    RUL.TextFont.CharSet = 162;
                    RUL.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Repair.GetHEKReportQuery_Class dataset_GetHEKReportQuery = ParentGroup.rsGroup.GetCurrentRecord<Repair.GetHEKReportQuery_Class>(0);
                    NewField1.CalcValue = ParentGroup.Counter.ToString();
                    REQUESTNO.CalcValue = (dataset_GetHEKReportQuery != null ? Globals.ToStringCore(dataset_GetHEKReportQuery.RequestNo) : "");
                    SENDERSECTION.CalcValue = (dataset_GetHEKReportQuery != null ? Globals.ToStringCore(dataset_GetHEKReportQuery.Sendersection) : "");
                    HEKREPORTNO.CalcValue = (dataset_GetHEKReportQuery != null ? Globals.ToStringCore(dataset_GetHEKReportQuery.HEKReportNo) : "");
                    FAMNAME.CalcValue = (dataset_GetHEKReportQuery != null ? Globals.ToStringCore(dataset_GetHEKReportQuery.Famname) : "");
                    DEVICEUSER.CalcValue = (dataset_GetHEKReportQuery != null ? Globals.ToStringCore(dataset_GetHEKReportQuery.Deviceuser) : "");
                    ENDDATE.CalcValue = @"";
                    MARKMODEL.CalcValue = (dataset_GetHEKReportQuery != null ? Globals.ToStringCore(dataset_GetHEKReportQuery.Mark) : "") + @" - " + (dataset_GetHEKReportQuery != null ? Globals.ToStringCore(dataset_GetHEKReportQuery.Model) : "");
                    OBJECTID.CalcValue = (dataset_GetHEKReportQuery != null ? Globals.ToStringCore(dataset_GetHEKReportQuery.ObjectID) : "");
                    RULOBJECTID.CalcValue = (dataset_GetHEKReportQuery != null ? Globals.ToStringCore(dataset_GetHEKReportQuery.RULObjectID) : "");
                    RUL.CalcValue = @"";
                    return new TTReportObject[] { NewField1,REQUESTNO,SENDERSECTION,HEKREPORTNO,FAMNAME,DEVICEUSER,ENDDATE,MARKMODEL,OBJECTID,RULOBJECTID,RUL};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    TTObjectContext cont = new TTObjectContext(true);
            string requestno = this.REQUESTNO.CalcValue;
            BindingList<Repair.GetActualDeliveryDate_Class> list = Repair.GetActualDeliveryDate(cont, requestno);
            foreach (Repair.GetActualDeliveryDate_Class lst in list)
            {
                if(lst.RequestNo == requestno)
                    this.ENDDATE.CalcValue = lst.ActualDeliveryDate.ToString();
            }
            
            if (string.IsNullOrEmpty(this.FAMNAME.CalcValue))
            {
                Repair rep = (Repair)MyParentReport.ReportObjectContext.GetObject(new Guid(this.OBJECTID.CalcValue), typeof(Repair));
                if (rep is MaterialRepair)
                {
                    MaterialRepair mp = (MaterialRepair)rep;
                    this.FAMNAME.CalcValue = mp.FixedAssetDefinition.Name;
                }
                else
                    if(rep.FixedAssetMaterialDefinition != null)
                    if(rep.FixedAssetMaterialDefinition.FixedAssetDefinition != null)
                    this.FAMNAME.CalcValue= rep.FixedAssetMaterialDefinition.FixedAssetDefinition.Name;
            }
            
            if (!string.IsNullOrEmpty(this.RULOBJECTID.CalcValue))
            {
                ReferToUpperLevel rul = (ReferToUpperLevel)cont.GetObject(new Guid(this.RULOBJECTID.CalcValue),"ReferToUpperLevel");
                RUL.CalcValue = rul.Amount != null ? rul.Amount.ToString():"1";
                
                ((HEKRaporuDuzenlenenCihazlarRaporu)ParentReport).counter +=  rul.Amount != null ? (int)rul.Amount:1;
                
            }
            else
            {
                RUL.CalcValue = "1";
                ((HEKRaporuDuzenlenenCihazlarRaporu)ParentReport).counter +=  1 ;
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

        public HEKRaporuDuzenlenenCihazlarRaporu()
        {
            HEADER = new HEADERGroup(this,"HEADER");
            MAIN = new MAINGroup(HEADER,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STARTDATE", "", "Başlangıç Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENDDATE", "", "Bitiş Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("SENDERSECTION", "00000000-0000-0000-0000-000000000000", "Bölümü ", @"", false, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("44d92ee9-95ea-42f3-8a1a-07fce625510c");
            reportParameter = Parameters.Add("PERSONNEL", "00000000-0000-0000-0000-000000000000", "Onarımı Yapan Teknisyen", @"", false, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("49d34251-525d-4d43-9c79-938d4facd154");
            reportParameter = Parameters.Add("STOREFLAG", "", "", @"", false, false, false, new Guid("e23a630a-eb08-4621-bc97-1fc8fc93ba28"));
            reportParameter = Parameters.Add("PERSONFLAG", "", "", @"", false, false, false, new Guid("e23a630a-eb08-4621-bc97-1fc8fc93ba28"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STARTDATE"))
                _runtimeParameters.STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTDATE"]);
            if (parameters.ContainsKey("ENDDATE"))
                _runtimeParameters.ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ENDDATE"]);
            if (parameters.ContainsKey("SENDERSECTION"))
                _runtimeParameters.SENDERSECTION = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["SENDERSECTION"]);
            if (parameters.ContainsKey("PERSONNEL"))
                _runtimeParameters.PERSONNEL = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["PERSONNEL"]);
            if (parameters.ContainsKey("STOREFLAG"))
                _runtimeParameters.STOREFLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(parameters["STOREFLAG"]);
            if (parameters.ContainsKey("PERSONFLAG"))
                _runtimeParameters.PERSONFLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(parameters["PERSONFLAG"]);
            Name = "HEKRAPORUDUZENLENENCIHAZLARRAPORU";
            Caption = "Hek Raporu Düzenlenen Tibbi Cihazlar Raporu";
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
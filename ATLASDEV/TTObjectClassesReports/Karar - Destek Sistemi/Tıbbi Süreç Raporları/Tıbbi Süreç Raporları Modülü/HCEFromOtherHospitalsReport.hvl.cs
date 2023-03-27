
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
    /// Diğer XXXXXXlerden Sağlık Kurulu Muayenesi Raporu
    /// </summary>
    public partial class HCEFromOtherHospitalsReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public SendingSituationEnum? SENDINGSITUATION = (SendingSituationEnum?)(int?)TTObjectDefManager.Instance.DataTypes["SendingSituationEnum"].ConvertValue("");
            public string HOSPITALOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["String50"].ConvertValue("");
            public int? SENDINGSITUATIONFLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue("");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public HCEFromOtherHospitalsReport MyParentReport
            {
                get { return (HCEFromOtherHospitalsReport)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField STARTDATE { get {return Header().STARTDATE;} }
            public TTReportField ENDDATE { get {return Header().ENDDATE;} }
            public TTReportField SITEID { get {return Header().SITEID;} }
            public TTReportField CURRENTUSER { get {return Footer().CURRENTUSER;} }
            public TTReportField PrintDate { get {return Footer().PrintDate;} }
            public TTReportField PageNumber { get {return Footer().PageNumber;} }
            public TTReportShape NewLine11111111 { get {return Footer().NewLine11111111;} }
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
                public HCEFromOtherHospitalsReport MyParentReport
                {
                    get { return (HCEFromOtherHospitalsReport)ParentReport; }
                }
                
                public TTReportField STARTDATE;
                public TTReportField ENDDATE;
                public TTReportField SITEID; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 7;
                    IsVisible = EvetHayirEnum.ehHayir;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    STARTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 4, 1, 29, 6, false);
                    STARTDATE.Name = "STARTDATE";
                    STARTDATE.Visible = EvetHayirEnum.ehHayir;
                    STARTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STARTDATE.TextFormat = @"dd/MM/yyyy";
                    STARTDATE.Value = @"{@STARTDATE@}";

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 1, 56, 6, false);
                    ENDDATE.Name = "ENDDATE";
                    ENDDATE.Visible = EvetHayirEnum.ehHayir;
                    ENDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ENDDATE.TextFormat = @"dd/MM/yyyy";
                    ENDDATE.Value = @"{@ENDDATE@}";

                    SITEID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 57, 1, 82, 6, false);
                    SITEID.Name = "SITEID";
                    SITEID.Visible = EvetHayirEnum.ehHayir;
                    SITEID.FieldType = ReportFieldTypeEnum.ftExpression;
                    SITEID.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""SITEID"", """")";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    STARTDATE.CalcValue = MyParentReport.RuntimeParameters.STARTDATE.ToString();
                    ENDDATE.CalcValue = MyParentReport.RuntimeParameters.ENDDATE.ToString();
                    SITEID.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("SITEID", "");
                    return new TTReportObject[] { STARTDATE,ENDDATE,SITEID};
                }

                public override void RunScript()
                {
#region PARTA HEADER_Script
                    BindingList<ResOtherHospital> roh = ResOtherHospital.GetBySite(((HCEFromOtherHospitalsReport)ParentReport).ReportObjectContext, new Guid(SITEID.CalcValue.ToString()));
            if (roh.Count > 0)
                ((HCEFromOtherHospitalsReport)ParentReport).RuntimeParameters.HOSPITALOBJECTID = (roh[0].ObjectID).ToString();
            
            if (((HCEFromOtherHospitalsReport)ParentReport).RuntimeParameters.SENDINGSITUATION == SendingSituationEnum.Incoming)
                ((HCEFromOtherHospitalsReport)ParentReport).RuntimeParameters.SENDINGSITUATIONFLAG = 1;

            if (((HCEFromOtherHospitalsReport)ParentReport).RuntimeParameters.SENDINGSITUATION == SendingSituationEnum.Sending)
                ((HCEFromOtherHospitalsReport)ParentReport).RuntimeParameters.SENDINGSITUATIONFLAG = 0;
#endregion PARTA HEADER_Script
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public HCEFromOtherHospitalsReport MyParentReport
                {
                    get { return (HCEFromOtherHospitalsReport)ParentReport; }
                }
                
                public TTReportField CURRENTUSER;
                public TTReportField PrintDate;
                public TTReportField PageNumber;
                public TTReportShape NewLine11111111; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 15;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    CURRENTUSER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 100, 2, 120, 7, false);
                    CURRENTUSER.Name = "CURRENTUSER";
                    CURRENTUSER.FieldType = ReportFieldTypeEnum.ftExpression;
                    CURRENTUSER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CURRENTUSER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CURRENTUSER.TextFont.Name = "Arial";
                    CURRENTUSER.TextFont.Size = 8;
                    CURRENTUSER.TextFont.CharSet = 162;
                    CURRENTUSER.Value = @"TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : """"";

                    PrintDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 2, 38, 7, false);
                    PrintDate.Name = "PrintDate";
                    PrintDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate.TextFormat = @"Short Date";
                    PrintDate.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PrintDate.TextFont.Name = "Arial";
                    PrintDate.TextFont.Size = 8;
                    PrintDate.TextFont.CharSet = 162;
                    PrintDate.Value = @"{@printdatetime@}";

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 181, 2, 206, 7, false);
                    PageNumber.Name = "PageNumber";
                    PageNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PageNumber.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PageNumber.TextFont.Name = "Arial";
                    PageNumber.TextFont.Size = 8;
                    PageNumber.TextFont.CharSet = 162;
                    PageNumber.Value = @"Sayfa Nu:{@pagenumber@}/{@pagecount@}";

                    NewLine11111111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 1, 206, 1, false);
                    NewLine11111111.Name = "NewLine11111111";
                    NewLine11111111.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PrintDate.CalcValue = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
                    PageNumber.CalcValue = @"Sayfa Nu:" + ParentReport.CurrentPageNumber.ToString() + @"/" + ParentReport.ReportTotalPageCount;
                    CURRENTUSER.CalcValue = TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : "";
                    return new TTReportObject[] { PrintDate,PageNumber,CURRENTUSER};
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class PARTBGroup : TTReportGroup
        {
            public HCEFromOtherHospitalsReport MyParentReport
            {
                get { return (HCEFromOtherHospitalsReport)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField NewField1111 { get {return Header().NewField1111;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField STARTDATE { get {return Header().STARTDATE;} }
            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportField ENDDATE { get {return Header().ENDDATE;} }
            public TTReportField NewField1112 { get {return Header().NewField1112;} }
            public TTReportField NewField1121 { get {return Header().NewField1121;} }
            public TTReportField GONDERIMDURUMU { get {return Header().GONDERIMDURUMU;} }
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
                public HCEFromOtherHospitalsReport MyParentReport
                {
                    get { return (HCEFromOtherHospitalsReport)ParentReport; }
                }
                
                public TTReportField NewField1111;
                public TTReportField NewField11;
                public TTReportField NewField12;
                public TTReportField STARTDATE;
                public TTReportField NewField111;
                public TTReportField NewField121;
                public TTReportField ENDDATE;
                public TTReportField NewField1112;
                public TTReportField NewField1121;
                public TTReportField GONDERIMDURUMU; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 40;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 15, 206, 20, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111.TextFont.Size = 12;
                    NewField1111.TextFont.Bold = true;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @"DİĞER XXXXXXLERDEN SAĞLIK KURULU MUAYENESİ SEVK İŞLEMLERİ RAPORU";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 22, 34, 27, false);
                    NewField11.Name = "NewField11";
                    NewField11.TextFont.Size = 8;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"Başlangıç Tarihi";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 22, 37, 27, false);
                    NewField12.Name = "NewField12";
                    NewField12.TextFont.Size = 8;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @":";

                    STARTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 22, 63, 27, false);
                    STARTDATE.Name = "STARTDATE";
                    STARTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STARTDATE.TextFormat = @"dd/MM/yyyy";
                    STARTDATE.TextFont.Size = 8;
                    STARTDATE.TextFont.CharSet = 162;
                    STARTDATE.Value = @"{@STARTDATE@}";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 28, 34, 33, false);
                    NewField111.Name = "NewField111";
                    NewField111.TextFont.Size = 8;
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"Bitiş Tarihi";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 28, 37, 33, false);
                    NewField121.Name = "NewField121";
                    NewField121.TextFont.Size = 8;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @":";

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 28, 63, 33, false);
                    ENDDATE.Name = "ENDDATE";
                    ENDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ENDDATE.TextFormat = @"dd/MM/yyyy";
                    ENDDATE.TextFont.Size = 8;
                    ENDDATE.TextFont.CharSet = 162;
                    ENDDATE.Value = @"{@ENDDATE@}";

                    NewField1112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 34, 34, 39, false);
                    NewField1112.Name = "NewField1112";
                    NewField1112.TextFont.Size = 8;
                    NewField1112.TextFont.Bold = true;
                    NewField1112.TextFont.CharSet = 162;
                    NewField1112.Value = @"Gönderim Durumu";

                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 34, 37, 39, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.TextFont.Size = 8;
                    NewField1121.TextFont.CharSet = 162;
                    NewField1121.Value = @":";

                    GONDERIMDURUMU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 34, 63, 39, false);
                    GONDERIMDURUMU.Name = "GONDERIMDURUMU";
                    GONDERIMDURUMU.FieldType = ReportFieldTypeEnum.ftVariable;
                    GONDERIMDURUMU.ObjectDefName = "SendingSituationEnum";
                    GONDERIMDURUMU.DataMember = "DISPLAYTEXT";
                    GONDERIMDURUMU.TextFont.Size = 8;
                    GONDERIMDURUMU.TextFont.CharSet = 162;
                    GONDERIMDURUMU.Value = @"{@SENDINGSITUATION@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1111.CalcValue = NewField1111.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField12.CalcValue = NewField12.Value;
                    STARTDATE.CalcValue = MyParentReport.RuntimeParameters.STARTDATE.ToString();
                    NewField111.CalcValue = NewField111.Value;
                    NewField121.CalcValue = NewField121.Value;
                    ENDDATE.CalcValue = MyParentReport.RuntimeParameters.ENDDATE.ToString();
                    NewField1112.CalcValue = NewField1112.Value;
                    NewField1121.CalcValue = NewField1121.Value;
                    GONDERIMDURUMU.CalcValue = MyParentReport.RuntimeParameters.SENDINGSITUATION.ToString();
                    GONDERIMDURUMU.PostFieldValueCalculation();
                    return new TTReportObject[] { NewField1111,NewField11,NewField12,STARTDATE,NewField111,NewField121,ENDDATE,NewField1112,NewField1121,GONDERIMDURUMU};
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public HCEFromOtherHospitalsReport MyParentReport
                {
                    get { return (HCEFromOtherHospitalsReport)ParentReport; }
                }
                 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 6;
                    IsVisible = EvetHayirEnum.ehHayir;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTBGroup PARTB;

        public partial class PARTCGroup : TTReportGroup
        {
            public HCEFromOtherHospitalsReport MyParentReport
            {
                get { return (HCEFromOtherHospitalsReport)ParentReport; }
            }

            new public PARTCGroupHeader Header()
            {
                return (PARTCGroupHeader)_header;
            }

            new public PARTCGroupFooter Footer()
            {
                return (PARTCGroupFooter)_footer;
            }

            public TTReportField asd1 { get {return Header().asd1;} }
            public TTReportField NewField1112311 { get {return Header().NewField1112311;} }
            public TTReportField NewField111222111 { get {return Header().NewField111222111;} }
            public TTReportField NewField1111222111 { get {return Header().NewField1111222111;} }
            public TTReportShape NewLine11111 { get {return Header().NewLine11111;} }
            public TTReportField asd11 { get {return Header().asd11;} }
            public TTReportField asd111 { get {return Header().asd111;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField NewField1121 { get {return Header().NewField1121;} }
            public TTReportField DURUM { get {return Header().DURUM;} }
            public TTReportField CURRENTSTATE { get {return Header().CURRENTSTATE;} }
            public PARTCGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTCGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<HealthCommitteeExaminationFromOtherHospitals.GetHCEFOHByDate_Class>("GetHCEFOHByDate", HealthCommitteeExaminationFromOtherHospitals.GetHCEFOHByDate((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE),(int)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(MyParentReport.RuntimeParameters.SENDINGSITUATIONFLAG),(string)TTObjectDefManager.Instance.DataTypes["String50"].ConvertValue(MyParentReport.RuntimeParameters.HOSPITALOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTCGroupHeader(this);
                _footer = new PARTCGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class PARTCGroupHeader : TTReportSection
            {
                public HCEFromOtherHospitalsReport MyParentReport
                {
                    get { return (HCEFromOtherHospitalsReport)ParentReport; }
                }
                
                public TTReportField asd1;
                public TTReportField NewField1112311;
                public TTReportField NewField111222111;
                public TTReportField NewField1111222111;
                public TTReportShape NewLine11111;
                public TTReportField asd11;
                public TTReportField asd111;
                public TTReportField NewField11;
                public TTReportField NewField111;
                public TTReportField NewField1121;
                public TTReportField DURUM;
                public TTReportField CURRENTSTATE; 
                public PARTCGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 16;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    asd1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 7, 66, 15, false);
                    asd1.Name = "asd1";
                    asd1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    asd1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    asd1.TextFont.Size = 8;
                    asd1.TextFont.Bold = true;
                    asd1.TextFont.CharSet = 162;
                    asd1.Value = @"XXXXXX Adı";

                    NewField1112311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 7, 15, 15, false);
                    NewField1112311.Name = "NewField1112311";
                    NewField1112311.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1112311.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1112311.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1112311.NoClip = EvetHayirEnum.ehEvet;
                    NewField1112311.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1112311.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1112311.TextFont.Size = 8;
                    NewField1112311.TextFont.Bold = true;
                    NewField1112311.TextFont.CharSet = 162;
                    NewField1112311.Value = @"Sıra
No";

                    NewField111222111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 127, 7, 142, 15, false);
                    NewField111222111.Name = "NewField111222111";
                    NewField111222111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111222111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111222111.NoClip = EvetHayirEnum.ehEvet;
                    NewField111222111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111222111.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField111222111.TextFont.Size = 8;
                    NewField111222111.TextFont.Bold = true;
                    NewField111222111.TextFont.CharSet = 162;
                    NewField111222111.Value = @"H.Protokol
No";

                    NewField1111222111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 7, 206, 15, false);
                    NewField1111222111.Name = "NewField1111222111";
                    NewField1111222111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111222111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111222111.TextFont.Size = 8;
                    NewField1111222111.TextFont.Bold = true;
                    NewField1111222111.TextFont.CharSet = 162;
                    NewField1111222111.Value = @"Bölüm";

                    NewLine11111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 16, 206, 16, false);
                    NewLine11111.Name = "NewLine11111";
                    NewLine11111.DrawStyle = DrawStyleConstants.vbSolid;

                    asd11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 7, 85, 15, false);
                    asd11.Name = "asd11";
                    asd11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    asd11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    asd11.TextFont.Size = 8;
                    asd11.TextFont.Bold = true;
                    asd11.TextFont.CharSet = 162;
                    asd11.Value = @"TC Kimlik No";

                    asd111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 101, 7, 126, 15, false);
                    asd111.Name = "asd111";
                    asd111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    asd111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    asd111.TextFont.Size = 8;
                    asd111.TextFont.Bold = true;
                    asd111.TextFont.CharSet = 162;
                    asd111.Value = @"Hasta Adı";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 86, 7, 100, 15, false);
                    NewField11.Name = "NewField11";
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Size = 8;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"Tarih";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 1, 34, 6, false);
                    NewField111.Name = "NewField111";
                    NewField111.TextFont.Size = 8;
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"İşlem Durumu";

                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 1, 37, 6, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.TextFont.Size = 8;
                    NewField1121.TextFont.CharSet = 162;
                    NewField1121.Value = @":";

                    DURUM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 1, 206, 6, false);
                    DURUM.Name = "DURUM";
                    DURUM.FieldType = ReportFieldTypeEnum.ftVariable;
                    DURUM.TextFont.Size = 8;
                    DURUM.TextFont.CharSet = 162;
                    DURUM.Value = @"";

                    CURRENTSTATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 213, 10, 238, 15, false);
                    CURRENTSTATE.Name = "CURRENTSTATE";
                    CURRENTSTATE.Visible = EvetHayirEnum.ehHayir;
                    CURRENTSTATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    CURRENTSTATE.Value = @"{#CURRENTSTATEDEFID#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    HealthCommitteeExaminationFromOtherHospitals.GetHCEFOHByDate_Class dataset_GetHCEFOHByDate = ParentGroup.rsGroup.GetCurrentRecord<HealthCommitteeExaminationFromOtherHospitals.GetHCEFOHByDate_Class>(0);
                    asd1.CalcValue = asd1.Value;
                    NewField1112311.CalcValue = NewField1112311.Value;
                    NewField111222111.CalcValue = NewField111222111.Value;
                    NewField1111222111.CalcValue = NewField1111222111.Value;
                    asd11.CalcValue = asd11.Value;
                    asd111.CalcValue = asd111.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField111.CalcValue = NewField111.Value;
                    NewField1121.CalcValue = NewField1121.Value;
                    DURUM.CalcValue = @"";
                    CURRENTSTATE.CalcValue = (dataset_GetHCEFOHByDate != null ? Globals.ToStringCore(dataset_GetHCEFOHByDate.CurrentStateDefID) : "");
                    return new TTReportObject[] { asd1,NewField1112311,NewField111222111,NewField1111222111,asd11,asd111,NewField11,NewField111,NewField1121,DURUM,CURRENTSTATE};
                }

                public override void RunScript()
                {
#region PARTC HEADER_Script
                    if(CURRENTSTATE.CalcValue == "0169c61f-e6e5-434a-962c-6e591f2eb495")
                DURUM.CalcValue = "Sonuçlandı";
            if(CURRENTSTATE.CalcValue == "98776f09-2af3-40bc-8b53-c5ecdc85d924")
                DURUM.CalcValue = "Karar Kayıt";
            if(CURRENTSTATE.CalcValue == "5f89f965-67de-4b2c-9c48-f963dc4ad8fd")
                DURUM.CalcValue = "Dış XXXXXX Karar Kayıt";
#endregion PARTC HEADER_Script
                }
            }
            public partial class PARTCGroupFooter : TTReportSection
            {
                public HCEFromOtherHospitalsReport MyParentReport
                {
                    get { return (HCEFromOtherHospitalsReport)ParentReport; }
                }
                 
                public PARTCGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 6;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTCGroup PARTC;

        public partial class MAINGroup : TTReportGroup
        {
            public HCEFromOtherHospitalsReport MyParentReport
            {
                get { return (HCEFromOtherHospitalsReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField SIRANO { get {return Body().SIRANO;} }
            public TTReportField XXXXXXADI { get {return Body().XXXXXXADI;} }
            public TTReportField UNIQUEREFNO { get {return Body().UNIQUEREFNO;} }
            public TTReportField NAME { get {return Body().NAME;} }
            public TTReportField PROTOCOLNO { get {return Body().PROTOCOLNO;} }
            public TTReportField RESOURCEINFO { get {return Body().RESOURCEINFO;} }
            public TTReportField RESOURCE { get {return Body().RESOURCE;} }
            public TTReportField SPECIALITY { get {return Body().SPECIALITY;} }
            public TTReportField DATE { get {return Body().DATE;} }
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

                HealthCommitteeExaminationFromOtherHospitals.GetHCEFOHByDate_Class dataSet_GetHCEFOHByDate = ParentGroup.rsGroup.GetCurrentRecord<HealthCommitteeExaminationFromOtherHospitals.GetHCEFOHByDate_Class>(0);    
                return new object[] {(dataSet_GetHCEFOHByDate==null ? null : dataSet_GetHCEFOHByDate.CurrentStateDefID)};
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
                public HCEFromOtherHospitalsReport MyParentReport
                {
                    get { return (HCEFromOtherHospitalsReport)ParentReport; }
                }
                
                public TTReportField SIRANO;
                public TTReportField XXXXXXADI;
                public TTReportField UNIQUEREFNO;
                public TTReportField NAME;
                public TTReportField PROTOCOLNO;
                public TTReportField RESOURCEINFO;
                public TTReportField RESOURCE;
                public TTReportField SPECIALITY;
                public TTReportField DATE; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 5;
                    RepeatCount = 0;
                    
                    SIRANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 1, 15, 5, false);
                    SIRANO.Name = "SIRANO";
                    SIRANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SIRANO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SIRANO.MultiLine = EvetHayirEnum.ehEvet;
                    SIRANO.NoClip = EvetHayirEnum.ehEvet;
                    SIRANO.WordBreak = EvetHayirEnum.ehEvet;
                    SIRANO.ExpandTabs = EvetHayirEnum.ehEvet;
                    SIRANO.TextFont.Size = 8;
                    SIRANO.TextFont.CharSet = 162;
                    SIRANO.Value = @"{@groupcounter@}";

                    XXXXXXADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 1, 66, 5, false);
                    XXXXXXADI.Name = "XXXXXXADI";
                    XXXXXXADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    XXXXXXADI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXADI.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXADI.NoClip = EvetHayirEnum.ehEvet;
                    XXXXXXADI.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXADI.ExpandTabs = EvetHayirEnum.ehEvet;
                    XXXXXXADI.TextFont.Size = 8;
                    XXXXXXADI.TextFont.CharSet = 162;
                    XXXXXXADI.Value = @"{#PARTC.REFERABLEHOSPITAL#}";

                    UNIQUEREFNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 1, 85, 5, false);
                    UNIQUEREFNO.Name = "UNIQUEREFNO";
                    UNIQUEREFNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNIQUEREFNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    UNIQUEREFNO.MultiLine = EvetHayirEnum.ehEvet;
                    UNIQUEREFNO.NoClip = EvetHayirEnum.ehEvet;
                    UNIQUEREFNO.WordBreak = EvetHayirEnum.ehEvet;
                    UNIQUEREFNO.ExpandTabs = EvetHayirEnum.ehEvet;
                    UNIQUEREFNO.TextFont.Size = 8;
                    UNIQUEREFNO.TextFont.CharSet = 162;
                    UNIQUEREFNO.Value = @"{#PARTC.UNIQUEREFNO#}";

                    NAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 101, 1, 126, 5, false);
                    NAME.Name = "NAME";
                    NAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NAME.MultiLine = EvetHayirEnum.ehEvet;
                    NAME.NoClip = EvetHayirEnum.ehEvet;
                    NAME.WordBreak = EvetHayirEnum.ehEvet;
                    NAME.ExpandTabs = EvetHayirEnum.ehEvet;
                    NAME.TextFont.Size = 8;
                    NAME.TextFont.CharSet = 162;
                    NAME.Value = @"{#PARTC.NAME#}";

                    PROTOCOLNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 127, 1, 142, 5, false);
                    PROTOCOLNO.Name = "PROTOCOLNO";
                    PROTOCOLNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROTOCOLNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PROTOCOLNO.MultiLine = EvetHayirEnum.ehEvet;
                    PROTOCOLNO.NoClip = EvetHayirEnum.ehEvet;
                    PROTOCOLNO.WordBreak = EvetHayirEnum.ehEvet;
                    PROTOCOLNO.ExpandTabs = EvetHayirEnum.ehEvet;
                    PROTOCOLNO.TextFont.Size = 8;
                    PROTOCOLNO.TextFont.CharSet = 162;
                    PROTOCOLNO.Value = @"{#PARTC.PROTOCOLNO#}";

                    RESOURCEINFO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 1, 206, 5, false);
                    RESOURCEINFO.Name = "RESOURCEINFO";
                    RESOURCEINFO.FieldType = ReportFieldTypeEnum.ftVariable;
                    RESOURCEINFO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    RESOURCEINFO.MultiLine = EvetHayirEnum.ehEvet;
                    RESOURCEINFO.NoClip = EvetHayirEnum.ehEvet;
                    RESOURCEINFO.WordBreak = EvetHayirEnum.ehEvet;
                    RESOURCEINFO.ExpandTabs = EvetHayirEnum.ehEvet;
                    RESOURCEINFO.TextFont.Size = 8;
                    RESOURCEINFO.TextFont.CharSet = 162;
                    RESOURCEINFO.Value = @"";

                    RESOURCE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 1, 237, 6, false);
                    RESOURCE.Name = "RESOURCE";
                    RESOURCE.Visible = EvetHayirEnum.ehHayir;
                    RESOURCE.FieldType = ReportFieldTypeEnum.ftVariable;
                    RESOURCE.Value = @"{#PARTC.REFERABLERESOURCE#}";

                    SPECIALITY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 239, 1, 264, 6, false);
                    SPECIALITY.Name = "SPECIALITY";
                    SPECIALITY.Visible = EvetHayirEnum.ehHayir;
                    SPECIALITY.FieldType = ReportFieldTypeEnum.ftVariable;
                    SPECIALITY.Value = @"{#PARTC.SPECIALITY#}";

                    DATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 86, 1, 100, 5, false);
                    DATE.Name = "DATE";
                    DATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DATE.TextFormat = @"dd/MM/yyyy";
                    DATE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DATE.MultiLine = EvetHayirEnum.ehEvet;
                    DATE.NoClip = EvetHayirEnum.ehEvet;
                    DATE.WordBreak = EvetHayirEnum.ehEvet;
                    DATE.ExpandTabs = EvetHayirEnum.ehEvet;
                    DATE.TextFont.Size = 8;
                    DATE.TextFont.CharSet = 162;
                    DATE.Value = @"{#PARTC.ACTIONDATE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    HealthCommitteeExaminationFromOtherHospitals.GetHCEFOHByDate_Class dataset_GetHCEFOHByDate = MyParentReport.PARTC.rsGroup.GetCurrentRecord<HealthCommitteeExaminationFromOtherHospitals.GetHCEFOHByDate_Class>(0);
                    SIRANO.CalcValue = ParentGroup.GroupCounter.ToString();
                    XXXXXXADI.CalcValue = (dataset_GetHCEFOHByDate != null ? Globals.ToStringCore(dataset_GetHCEFOHByDate.Referablehospital) : "");
                    UNIQUEREFNO.CalcValue = (dataset_GetHCEFOHByDate != null ? Globals.ToStringCore(dataset_GetHCEFOHByDate.UniqueRefNo) : "");
                    NAME.CalcValue = (dataset_GetHCEFOHByDate != null ? Globals.ToStringCore(dataset_GetHCEFOHByDate.Name) : "");
                    PROTOCOLNO.CalcValue = (dataset_GetHCEFOHByDate != null ? Globals.ToStringCore(dataset_GetHCEFOHByDate.Protocolno) : "");
                    RESOURCEINFO.CalcValue = @"";
                    RESOURCE.CalcValue = (dataset_GetHCEFOHByDate != null ? Globals.ToStringCore(dataset_GetHCEFOHByDate.Referableresource) : "");
                    SPECIALITY.CalcValue = (dataset_GetHCEFOHByDate != null ? Globals.ToStringCore(dataset_GetHCEFOHByDate.Speciality) : "");
                    DATE.CalcValue = (dataset_GetHCEFOHByDate != null ? Globals.ToStringCore(dataset_GetHCEFOHByDate.ActionDate) : "");
                    return new TTReportObject[] { SIRANO,XXXXXXADI,UNIQUEREFNO,NAME,PROTOCOLNO,RESOURCEINFO,RESOURCE,SPECIALITY,DATE};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    if(!string.IsNullOrEmpty(this.RESOURCE.CalcValue))
                this.RESOURCEINFO.CalcValue = this.RESOURCE.CalcValue;
            else if(!string.IsNullOrEmpty(this.SPECIALITY.CalcValue))
                this.RESOURCEINFO.CalcValue = this.SPECIALITY.CalcValue;
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

        public HCEFromOtherHospitalsReport()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            PARTB = new PARTBGroup(PARTA,"PARTB");
            PARTC = new PARTCGroup(PARTB,"PARTC");
            MAIN = new MAINGroup(PARTC,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STARTDATE", "", "Başlangıç Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENDDATE", "", "Bitiş Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("SENDINGSITUATION", "", "Gönderim Durumu", @"", true, true, false, new Guid("8ed8fe53-465f-4483-b3a2-b9c48f461979"));
            reportParameter = Parameters.Add("HOSPITALOBJECTID", "", "", @"", false, false, false, new Guid("53c9e989-dad5-4f3f-b973-d0bda68f0942"));
            reportParameter = Parameters.Add("SENDINGSITUATIONFLAG", "", "Gönderim Durumu Kontrol", @"", false, false, false, new Guid("e23a630a-eb08-4621-bc97-1fc8fc93ba28"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STARTDATE"))
                _runtimeParameters.STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTDATE"]);
            if (parameters.ContainsKey("ENDDATE"))
                _runtimeParameters.ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ENDDATE"]);
            if (parameters.ContainsKey("SENDINGSITUATION"))
                _runtimeParameters.SENDINGSITUATION = (SendingSituationEnum?)(int?)TTObjectDefManager.Instance.DataTypes["SendingSituationEnum"].ConvertValue(parameters["SENDINGSITUATION"]);
            if (parameters.ContainsKey("HOSPITALOBJECTID"))
                _runtimeParameters.HOSPITALOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["String50"].ConvertValue(parameters["HOSPITALOBJECTID"]);
            if (parameters.ContainsKey("SENDINGSITUATIONFLAG"))
                _runtimeParameters.SENDINGSITUATIONFLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(parameters["SENDINGSITUATIONFLAG"]);
            Name = "HCEFROMOTHERHOSPITALSREPORT";
            Caption = "Diğer XXXXXXlerden Sağlık Kurulu Muayenesi Raporu";
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
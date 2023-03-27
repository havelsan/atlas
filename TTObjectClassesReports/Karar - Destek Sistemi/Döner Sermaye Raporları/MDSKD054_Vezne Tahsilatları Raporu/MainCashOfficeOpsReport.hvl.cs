
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
    public partial class MainCashOfficeOpsReport : TTReport
    {
#region Methods
   string tahsilatTuru = string.Empty;
        public double toplamTahsilatTutari = 0;
   
#endregion Methods

        public class ReportRuntimeParameters 
        {
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public List<string> TYPE = new List<string>();
            public int? TYPECONTROL = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue("");
        }

        public partial class PARTEGroup : TTReportGroup
        {
            public MainCashOfficeOpsReport MyParentReport
            {
                get { return (MainCashOfficeOpsReport)ParentReport; }
            }

            new public PARTEGroupHeader Header()
            {
                return (PARTEGroupHeader)_header;
            }

            new public PARTEGroupFooter Footer()
            {
                return (PARTEGroupFooter)_footer;
            }

            public TTReportField STARTDATE { get {return Header().STARTDATE;} }
            public TTReportField ENDDATE { get {return Header().ENDDATE;} }
            public TTReportShape NewLine111 { get {return Footer().NewLine111;} }
            public TTReportField CURRENTUSER { get {return Footer().CURRENTUSER;} }
            public TTReportField PrintDate { get {return Footer().PrintDate;} }
            public TTReportField PageNumber { get {return Footer().PageNumber;} }
            public PARTEGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTEGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTEGroupHeader(this);
                _footer = new PARTEGroupFooter(this);

            }

            public partial class PARTEGroupHeader : TTReportSection
            {
                public MainCashOfficeOpsReport MyParentReport
                {
                    get { return (MainCashOfficeOpsReport)ParentReport; }
                }
                
                public TTReportField STARTDATE;
                public TTReportField ENDDATE; 
                public PARTEGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 10;
                    IsVisible = EvetHayirEnum.ehHayir;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    STARTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 4, 27, 9, false);
                    STARTDATE.Name = "STARTDATE";
                    STARTDATE.Visible = EvetHayirEnum.ehHayir;
                    STARTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STARTDATE.TextFormat = @"Short Date";
                    STARTDATE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    STARTDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    STARTDATE.MultiLine = EvetHayirEnum.ehEvet;
                    STARTDATE.WordBreak = EvetHayirEnum.ehEvet;
                    STARTDATE.ExpandTabs = EvetHayirEnum.ehEvet;
                    STARTDATE.TextFont.CharSet = 162;
                    STARTDATE.Value = @"{@STARTDATE@}";

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 4, 51, 9, false);
                    ENDDATE.Name = "ENDDATE";
                    ENDDATE.Visible = EvetHayirEnum.ehHayir;
                    ENDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ENDDATE.TextFormat = @"Short Date";
                    ENDDATE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    ENDDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ENDDATE.MultiLine = EvetHayirEnum.ehEvet;
                    ENDDATE.WordBreak = EvetHayirEnum.ehEvet;
                    ENDDATE.ExpandTabs = EvetHayirEnum.ehEvet;
                    ENDDATE.TextFont.CharSet = 162;
                    ENDDATE.Value = @"{@ENDDATE@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    STARTDATE.CalcValue = MyParentReport.RuntimeParameters.STARTDATE.ToString();
                    ENDDATE.CalcValue = MyParentReport.RuntimeParameters.ENDDATE.ToString();
                    return new TTReportObject[] { STARTDATE,ENDDATE};
                }

                public override void RunScript()
                {
#region PARTE HEADER_Script
                    ((MainCashOfficeOpsReport)ParentReport).RuntimeParameters.STARTDATE = Convert.ToDateTime(STARTDATE.FormattedValue + " 00:00:00");
            ((MainCashOfficeOpsReport)ParentReport).RuntimeParameters.ENDDATE = Convert.ToDateTime(ENDDATE.FormattedValue + " 23:59:59");
            
            if(((MainCashOfficeOpsReport)ParentReport).RuntimeParameters.TYPE == null)
                ((MainCashOfficeOpsReport)ParentReport).RuntimeParameters.TYPECONTROL = 0;
            else{
                ((MainCashOfficeOpsReport)ParentReport).RuntimeParameters.TYPECONTROL = 1;
                
                foreach(string objectId in ((MainCashOfficeOpsReport)ParentReport).RuntimeParameters.TYPE)
                {
                    MainCashOfficePaymentTypeDefinition mcoptd = (MainCashOfficePaymentTypeDefinition) MyParentReport.ReportObjectContext.GetObject(new Guid(objectId),"MainCashOfficePaymentTypeDefinition");
                    if(mcoptd != null)
                        ((MainCashOfficeOpsReport)ParentReport).tahsilatTuru += mcoptd.Code + " " + mcoptd.Name + ", ";
                }
                
                if(((MainCashOfficeOpsReport)ParentReport).tahsilatTuru != string.Empty)
                    ((MainCashOfficeOpsReport)ParentReport).tahsilatTuru = ((MainCashOfficeOpsReport)ParentReport).tahsilatTuru.Substring(0, ((MainCashOfficeOpsReport)ParentReport).tahsilatTuru.Length - 2);
            }
            
            ((MainCashOfficeOpsReport)ParentReport).toplamTahsilatTutari = 0;
#endregion PARTE HEADER_Script
                }
            }
            public partial class PARTEGroupFooter : TTReportSection
            {
                public MainCashOfficeOpsReport MyParentReport
                {
                    get { return (MainCashOfficeOpsReport)ParentReport; }
                }
                
                public TTReportShape NewLine111;
                public TTReportField CURRENTUSER;
                public TTReportField PrintDate;
                public TTReportField PageNumber; 
                public PARTEGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 13;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 1, 202, 1, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;

                    CURRENTUSER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 96, 3, 116, 8, false);
                    CURRENTUSER.Name = "CURRENTUSER";
                    CURRENTUSER.FieldType = ReportFieldTypeEnum.ftExpression;
                    CURRENTUSER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CURRENTUSER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CURRENTUSER.TextFont.Name = "Arial";
                    CURRENTUSER.TextFont.Size = 8;
                    CURRENTUSER.TextFont.CharSet = 162;
                    CURRENTUSER.Value = @"TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : """"";

                    PrintDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 3, 39, 8, false);
                    PrintDate.Name = "PrintDate";
                    PrintDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate.TextFormat = @"Short Date";
                    PrintDate.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PrintDate.TextFont.Name = "Arial";
                    PrintDate.TextFont.Size = 8;
                    PrintDate.TextFont.CharSet = 162;
                    PrintDate.Value = @"{@printdatetime@}";

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 177, 3, 202, 8, false);
                    PageNumber.Name = "PageNumber";
                    PageNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PageNumber.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PageNumber.TextFont.Name = "Arial";
                    PageNumber.TextFont.Size = 8;
                    PageNumber.TextFont.CharSet = 162;
                    PageNumber.Value = @"Sayfa Nu:{@pagenumber@}/{@pagecount@}";

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

        public PARTEGroup PARTE;

        public partial class PARTBGroup : TTReportGroup
        {
            public MainCashOfficeOpsReport MyParentReport
            {
                get { return (MainCashOfficeOpsReport)ParentReport; }
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
            public TTReportField NewField1121 { get {return Header().NewField1121;} }
            public TTReportField NewField1131 { get {return Header().NewField1131;} }
            public TTReportField NewField1141 { get {return Header().NewField1141;} }
            public TTReportField NewField16 { get {return Header().NewField16;} }
            public TTReportField NewField161 { get {return Header().NewField161;} }
            public TTReportField NewField171 { get {return Header().NewField171;} }
            public TTReportField STARTDATE { get {return Header().STARTDATE;} }
            public TTReportField TYPE { get {return Header().TYPE;} }
            public TTReportField ENDDATE { get {return Header().ENDDATE;} }
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
                public MainCashOfficeOpsReport MyParentReport
                {
                    get { return (MainCashOfficeOpsReport)ParentReport; }
                }
                
                public TTReportField NewField1111;
                public TTReportField NewField1121;
                public TTReportField NewField1131;
                public TTReportField NewField1141;
                public TTReportField NewField16;
                public TTReportField NewField161;
                public TTReportField NewField171;
                public TTReportField STARTDATE;
                public TTReportField TYPE;
                public TTReportField ENDDATE; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 39;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 12, 202, 17, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111.TextFont.Name = "Arial";
                    NewField1111.TextFont.Size = 12;
                    NewField1111.TextFont.Bold = true;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @"VEZNE TAHSİLATLARI RAPORU";

                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 19, 37, 24, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.TextFont.Name = "Arial";
                    NewField1121.TextFont.Size = 8;
                    NewField1121.TextFont.Bold = true;
                    NewField1121.TextFont.CharSet = 162;
                    NewField1121.Value = @"Başlangıç Tarihi";

                    NewField1131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 25, 37, 30, false);
                    NewField1131.Name = "NewField1131";
                    NewField1131.TextFont.Name = "Arial";
                    NewField1131.TextFont.Size = 8;
                    NewField1131.TextFont.Bold = true;
                    NewField1131.TextFont.CharSet = 162;
                    NewField1131.Value = @"Bitiş Tarihi";

                    NewField1141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 31, 37, 36, false);
                    NewField1141.Name = "NewField1141";
                    NewField1141.TextFont.Name = "Arial";
                    NewField1141.TextFont.Size = 8;
                    NewField1141.TextFont.Bold = true;
                    NewField1141.TextFont.CharSet = 162;
                    NewField1141.Value = @"Tahsilat Türü";

                    NewField16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 19, 40, 24, false);
                    NewField16.Name = "NewField16";
                    NewField16.TextFont.Name = "Arial";
                    NewField16.TextFont.Size = 8;
                    NewField16.TextFont.Bold = true;
                    NewField16.TextFont.CharSet = 162;
                    NewField16.Value = @":";

                    NewField161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 25, 40, 30, false);
                    NewField161.Name = "NewField161";
                    NewField161.TextFont.Name = "Arial";
                    NewField161.TextFont.Size = 8;
                    NewField161.TextFont.Bold = true;
                    NewField161.TextFont.CharSet = 162;
                    NewField161.Value = @":";

                    NewField171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 31, 40, 36, false);
                    NewField171.Name = "NewField171";
                    NewField171.TextFont.Name = "Arial";
                    NewField171.TextFont.Size = 8;
                    NewField171.TextFont.Bold = true;
                    NewField171.TextFont.CharSet = 162;
                    NewField171.Value = @":";

                    STARTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 19, 66, 24, false);
                    STARTDATE.Name = "STARTDATE";
                    STARTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STARTDATE.TextFormat = @"dd/MM/yyyy";
                    STARTDATE.TextFont.Size = 8;
                    STARTDATE.TextFont.CharSet = 162;
                    STARTDATE.Value = @"{@STARTDATE@}";

                    TYPE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 31, 202, 39, false);
                    TYPE.Name = "TYPE";
                    TYPE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TYPE.MultiLine = EvetHayirEnum.ehEvet;
                    TYPE.NoClip = EvetHayirEnum.ehEvet;
                    TYPE.WordBreak = EvetHayirEnum.ehEvet;
                    TYPE.ExpandTabs = EvetHayirEnum.ehEvet;
                    TYPE.TextFont.Size = 8;
                    TYPE.TextFont.CharSet = 162;
                    TYPE.Value = @"";

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 25, 66, 30, false);
                    ENDDATE.Name = "ENDDATE";
                    ENDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ENDDATE.TextFormat = @"dd/MM/yyyy";
                    ENDDATE.TextFont.Size = 8;
                    ENDDATE.TextFont.CharSet = 162;
                    ENDDATE.Value = @"{@ENDDATE@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1111.CalcValue = NewField1111.Value;
                    NewField1121.CalcValue = NewField1121.Value;
                    NewField1131.CalcValue = NewField1131.Value;
                    NewField1141.CalcValue = NewField1141.Value;
                    NewField16.CalcValue = NewField16.Value;
                    NewField161.CalcValue = NewField161.Value;
                    NewField171.CalcValue = NewField171.Value;
                    STARTDATE.CalcValue = MyParentReport.RuntimeParameters.STARTDATE.ToString();
                    TYPE.CalcValue = @"";
                    ENDDATE.CalcValue = MyParentReport.RuntimeParameters.ENDDATE.ToString();
                    return new TTReportObject[] { NewField1111,NewField1121,NewField1131,NewField1141,NewField16,NewField161,NewField171,STARTDATE,TYPE,ENDDATE};
                }

                public override void RunScript()
                {
#region PARTB HEADER_Script
                    if(string.IsNullOrEmpty(((MainCashOfficeOpsReport)ParentReport).tahsilatTuru))
                this.TYPE.CalcValue = "Hepsi";
            else 
                this.TYPE.CalcValue = ((MainCashOfficeOpsReport)ParentReport).tahsilatTuru ;
#endregion PARTB HEADER_Script
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public MainCashOfficeOpsReport MyParentReport
                {
                    get { return (MainCashOfficeOpsReport)ParentReport; }
                }
                 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 3;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTBGroup PARTB;

        public partial class PARTAGroup : TTReportGroup
        {
            public MainCashOfficeOpsReport MyParentReport
            {
                get { return (MainCashOfficeOpsReport)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportField NewField3 { get {return Header().NewField3;} }
            public TTReportField NewField4 { get {return Header().NewField4;} }
            public TTReportField NewField5 { get {return Header().NewField5;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public TTReportField NewField14 { get {return Header().NewField14;} }
            public TTReportField NewField142 { get {return Header().NewField142;} }
            public TTReportField NewField6 { get {return Header().NewField6;} }
            public TTReportField NewField213 { get {return Footer().NewField213;} }
            public TTReportField TOPLAMTAHSILATTUTARI { get {return Footer().TOPLAMTAHSILATTUTARI;} }
            public TTReportShape NewLine2 { get {return Footer().NewLine2;} }
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
                public MainCashOfficeOpsReport MyParentReport
                {
                    get { return (MainCashOfficeOpsReport)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportField NewField2;
                public TTReportField NewField3;
                public TTReportField NewField4;
                public TTReportField NewField5;
                public TTReportShape NewLine1;
                public TTReportField NewField14;
                public TTReportField NewField142;
                public TTReportField NewField6; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 15;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 8, 19, 13, false);
                    NewField1.Name = "NewField1";
                    NewField1.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1.NoClip = EvetHayirEnum.ehEvet;
                    NewField1.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.Size = 8;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"Sıra No";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 8, 38, 13, false);
                    NewField2.Name = "NewField2";
                    NewField2.TextFont.Name = "Arial";
                    NewField2.TextFont.Size = 8;
                    NewField2.TextFont.Bold = true;
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @"Alındı Tarihi";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 8, 179, 13, false);
                    NewField3.Name = "NewField3";
                    NewField3.TextFont.Name = "Arial";
                    NewField3.TextFont.Size = 8;
                    NewField3.TextFont.Bold = true;
                    NewField3.TextFont.CharSet = 162;
                    NewField3.Value = @"Tahsilat Türü";

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 8, 54, 13, false);
                    NewField4.Name = "NewField4";
                    NewField4.TextFont.Name = "Arial";
                    NewField4.TextFont.Size = 8;
                    NewField4.TextFont.Bold = true;
                    NewField4.TextFont.CharSet = 162;
                    NewField4.Value = @"Alındı No";

                    NewField5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 180, 8, 202, 13, false);
                    NewField5.Name = "NewField5";
                    NewField5.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField5.TextFont.Name = "Arial";
                    NewField5.TextFont.Size = 8;
                    NewField5.TextFont.Bold = true;
                    NewField5.TextFont.CharSet = 162;
                    NewField5.Value = @"Tahsilat Tutarı";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 14, 202, 14, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 86, 8, 105, 13, false);
                    NewField14.Name = "NewField14";
                    NewField14.TextFont.Name = "Arial";
                    NewField14.TextFont.Size = 8;
                    NewField14.TextFont.Bold = true;
                    NewField14.TextFont.CharSet = 162;
                    NewField14.Value = @"TC Kimlik No";

                    NewField142 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 55, 8, 85, 13, false);
                    NewField142.Name = "NewField142";
                    NewField142.TextFont.Name = "Arial";
                    NewField142.TextFont.Size = 8;
                    NewField142.TextFont.Bold = true;
                    NewField142.TextFont.CharSet = 162;
                    NewField142.Value = @"Hastanın Adı Soyadı";

                    NewField6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 2, 54, 7, false);
                    NewField6.Name = "NewField6";
                    NewField6.TextFont.Bold = true;
                    NewField6.TextFont.CharSet = 162;
                    NewField6.Value = @"Tahsilat Bilgileri";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1.CalcValue = NewField1.Value;
                    NewField2.CalcValue = NewField2.Value;
                    NewField3.CalcValue = NewField3.Value;
                    NewField4.CalcValue = NewField4.Value;
                    NewField5.CalcValue = NewField5.Value;
                    NewField14.CalcValue = NewField14.Value;
                    NewField142.CalcValue = NewField142.Value;
                    NewField6.CalcValue = NewField6.Value;
                    return new TTReportObject[] { NewField1,NewField2,NewField3,NewField4,NewField5,NewField14,NewField142,NewField6};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public MainCashOfficeOpsReport MyParentReport
                {
                    get { return (MainCashOfficeOpsReport)ParentReport; }
                }
                
                public TTReportField NewField213;
                public TTReportField TOPLAMTAHSILATTUTARI;
                public TTReportShape NewLine2; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 18;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField213 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 127, 3, 168, 8, false);
                    NewField213.Name = "NewField213";
                    NewField213.TextFont.Name = "Arial";
                    NewField213.TextFont.Size = 8;
                    NewField213.TextFont.Bold = true;
                    NewField213.TextFont.CharSet = 162;
                    NewField213.Value = @"Toplam Tahsilat Tutarı :";

                    TOPLAMTAHSILATTUTARI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 3, 202, 8, false);
                    TOPLAMTAHSILATTUTARI.Name = "TOPLAMTAHSILATTUTARI";
                    TOPLAMTAHSILATTUTARI.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOPLAMTAHSILATTUTARI.TextFormat = @"#,##0.#0";
                    TOPLAMTAHSILATTUTARI.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOPLAMTAHSILATTUTARI.TextFont.Size = 8;
                    TOPLAMTAHSILATTUTARI.TextFont.CharSet = 162;
                    TOPLAMTAHSILATTUTARI.Value = @"{@sumof(TAHSILATTUTARI)@}";

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 126, 1, 202, 1, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField213.CalcValue = NewField213.Value;
                    TOPLAMTAHSILATTUTARI.CalcValue = ParentGroup.FieldSums["TAHSILATTUTARI"].Value.ToString();;
                    return new TTReportObject[] { NewField213,TOPLAMTAHSILATTUTARI};
                }

                public override void RunScript()
                {
#region PARTA FOOTER_Script
                    ((MainCashOfficeOpsReport)ParentReport).toplamTahsilatTutari = Convert.ToDouble(this.TOPLAMTAHSILATTUTARI.CalcValue);
#endregion PARTA FOOTER_Script
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class MAINGroup : TTReportGroup
        {
            public MainCashOfficeOpsReport MyParentReport
            {
                get { return (MainCashOfficeOpsReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField SIRANO { get {return Body().SIRANO;} }
            public TTReportField VEZNEALINDITARIHI { get {return Body().VEZNEALINDITARIHI;} }
            public TTReportField TAHSILATTURU { get {return Body().TAHSILATTURU;} }
            public TTReportField ALINDINO { get {return Body().ALINDINO;} }
            public TTReportField TAHSILATTUTARI { get {return Body().TAHSILATTUTARI;} }
            public TTReportField TCKIMLIKNO { get {return Body().TCKIMLIKNO;} }
            public TTReportField ADISOYADI { get {return Body().ADISOYADI;} }
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
                list[0] = new TTReportNqlData<MainCashOfficeOperation.GetCashOfficeOpsByDateAndType_Class>("GetCashOfficeOpsByDateAndType", MainCashOfficeOperation.GetCashOfficeOpsByDateAndType((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE),(List<string>) MyParentReport.RuntimeParameters.TYPE,(int)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(MyParentReport.RuntimeParameters.TYPECONTROL)));
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
                public MainCashOfficeOpsReport MyParentReport
                {
                    get { return (MainCashOfficeOpsReport)ParentReport; }
                }
                
                public TTReportField SIRANO;
                public TTReportField VEZNEALINDITARIHI;
                public TTReportField TAHSILATTURU;
                public TTReportField ALINDINO;
                public TTReportField TAHSILATTUTARI;
                public TTReportField TCKIMLIKNO;
                public TTReportField ADISOYADI; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 7;
                    RepeatCount = 0;
                    
                    SIRANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 1, 19, 6, false);
                    SIRANO.Name = "SIRANO";
                    SIRANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SIRANO.MultiLine = EvetHayirEnum.ehEvet;
                    SIRANO.NoClip = EvetHayirEnum.ehEvet;
                    SIRANO.WordBreak = EvetHayirEnum.ehEvet;
                    SIRANO.ExpandTabs = EvetHayirEnum.ehEvet;
                    SIRANO.TextFont.Size = 8;
                    SIRANO.TextFont.CharSet = 162;
                    SIRANO.Value = @"{@groupcounter@}";

                    VEZNEALINDITARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 1, 38, 6, false);
                    VEZNEALINDITARIHI.Name = "VEZNEALINDITARIHI";
                    VEZNEALINDITARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    VEZNEALINDITARIHI.TextFormat = @"dd/MM/yyyy";
                    VEZNEALINDITARIHI.MultiLine = EvetHayirEnum.ehEvet;
                    VEZNEALINDITARIHI.NoClip = EvetHayirEnum.ehEvet;
                    VEZNEALINDITARIHI.WordBreak = EvetHayirEnum.ehEvet;
                    VEZNEALINDITARIHI.ExpandTabs = EvetHayirEnum.ehEvet;
                    VEZNEALINDITARIHI.TextFont.Size = 8;
                    VEZNEALINDITARIHI.TextFont.CharSet = 162;
                    VEZNEALINDITARIHI.Value = @"{#VEZNEALINDITARIHI#}";

                    TAHSILATTURU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 1, 179, 6, false);
                    TAHSILATTURU.Name = "TAHSILATTURU";
                    TAHSILATTURU.FieldType = ReportFieldTypeEnum.ftVariable;
                    TAHSILATTURU.MultiLine = EvetHayirEnum.ehEvet;
                    TAHSILATTURU.NoClip = EvetHayirEnum.ehEvet;
                    TAHSILATTURU.WordBreak = EvetHayirEnum.ehEvet;
                    TAHSILATTURU.ExpandTabs = EvetHayirEnum.ehEvet;
                    TAHSILATTURU.TextFont.Size = 8;
                    TAHSILATTURU.TextFont.CharSet = 162;
                    TAHSILATTURU.Value = @"{#TAHSILATTURU#}";

                    ALINDINO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 1, 54, 6, false);
                    ALINDINO.Name = "ALINDINO";
                    ALINDINO.FieldType = ReportFieldTypeEnum.ftVariable;
                    ALINDINO.MultiLine = EvetHayirEnum.ehEvet;
                    ALINDINO.NoClip = EvetHayirEnum.ehEvet;
                    ALINDINO.WordBreak = EvetHayirEnum.ehEvet;
                    ALINDINO.ExpandTabs = EvetHayirEnum.ehEvet;
                    ALINDINO.TextFont.Size = 8;
                    ALINDINO.TextFont.CharSet = 162;
                    ALINDINO.Value = @"{#ALINDINO#}";

                    TAHSILATTUTARI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 180, 1, 202, 6, false);
                    TAHSILATTUTARI.Name = "TAHSILATTUTARI";
                    TAHSILATTUTARI.FieldType = ReportFieldTypeEnum.ftVariable;
                    TAHSILATTUTARI.TextFormat = @"#,##0.#0";
                    TAHSILATTUTARI.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TAHSILATTUTARI.TextFont.Size = 8;
                    TAHSILATTUTARI.TextFont.CharSet = 162;
                    TAHSILATTUTARI.Value = @"{#TAHSILATTUTARI#}";

                    TCKIMLIKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 86, 1, 105, 6, false);
                    TCKIMLIKNO.Name = "TCKIMLIKNO";
                    TCKIMLIKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    TCKIMLIKNO.MultiLine = EvetHayirEnum.ehEvet;
                    TCKIMLIKNO.NoClip = EvetHayirEnum.ehEvet;
                    TCKIMLIKNO.WordBreak = EvetHayirEnum.ehEvet;
                    TCKIMLIKNO.ExpandTabs = EvetHayirEnum.ehEvet;
                    TCKIMLIKNO.TextFont.Size = 8;
                    TCKIMLIKNO.TextFont.CharSet = 162;
                    TCKIMLIKNO.Value = @"{#UNIQUEREFNO#}";

                    ADISOYADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 55, 1, 85, 6, false);
                    ADISOYADI.Name = "ADISOYADI";
                    ADISOYADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADISOYADI.MultiLine = EvetHayirEnum.ehEvet;
                    ADISOYADI.NoClip = EvetHayirEnum.ehEvet;
                    ADISOYADI.WordBreak = EvetHayirEnum.ehEvet;
                    ADISOYADI.ExpandTabs = EvetHayirEnum.ehEvet;
                    ADISOYADI.TextFont.Size = 8;
                    ADISOYADI.TextFont.CharSet = 162;
                    ADISOYADI.Value = @"{#PATIENTNAME#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    MainCashOfficeOperation.GetCashOfficeOpsByDateAndType_Class dataset_GetCashOfficeOpsByDateAndType = ParentGroup.rsGroup.GetCurrentRecord<MainCashOfficeOperation.GetCashOfficeOpsByDateAndType_Class>(0);
                    SIRANO.CalcValue = ParentGroup.GroupCounter.ToString();
                    VEZNEALINDITARIHI.CalcValue = (dataset_GetCashOfficeOpsByDateAndType != null ? Globals.ToStringCore(dataset_GetCashOfficeOpsByDateAndType.Veznealinditarihi) : "");
                    TAHSILATTURU.CalcValue = (dataset_GetCashOfficeOpsByDateAndType != null ? Globals.ToStringCore(dataset_GetCashOfficeOpsByDateAndType.Tahsilatturu) : "");
                    ALINDINO.CalcValue = (dataset_GetCashOfficeOpsByDateAndType != null ? Globals.ToStringCore(dataset_GetCashOfficeOpsByDateAndType.Alindino) : "");
                    TAHSILATTUTARI.CalcValue = (dataset_GetCashOfficeOpsByDateAndType != null ? Globals.ToStringCore(dataset_GetCashOfficeOpsByDateAndType.Tahsilattutari) : "");
                    TCKIMLIKNO.CalcValue = (dataset_GetCashOfficeOpsByDateAndType != null ? Globals.ToStringCore(dataset_GetCashOfficeOpsByDateAndType.Uniquerefno) : "");
                    ADISOYADI.CalcValue = (dataset_GetCashOfficeOpsByDateAndType != null ? Globals.ToStringCore(dataset_GetCashOfficeOpsByDateAndType.Patientname) : "");
                    return new TTReportObject[] { SIRANO,VEZNEALINDITARIHI,TAHSILATTURU,ALINDINO,TAHSILATTUTARI,TCKIMLIKNO,ADISOYADI};
                }
            }

        }

        public MAINGroup MAIN;

        public partial class PARTDGroup : TTReportGroup
        {
            public MainCashOfficeOpsReport MyParentReport
            {
                get { return (MainCashOfficeOpsReport)ParentReport; }
            }

            new public PARTDGroupHeader Header()
            {
                return (PARTDGroupHeader)_header;
            }

            new public PARTDGroupFooter Footer()
            {
                return (PARTDGroupFooter)_footer;
            }

            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField NewField13 { get {return Header().NewField13;} }
            public TTReportField NewField14 { get {return Header().NewField14;} }
            public TTReportField NewField15 { get {return Header().NewField15;} }
            public TTReportShape NewLine11 { get {return Header().NewLine11;} }
            public TTReportField NewField141 { get {return Header().NewField141;} }
            public TTReportField NewField1241 { get {return Header().NewField1241;} }
            public TTReportField NewField16 { get {return Header().NewField16;} }
            public TTReportField NewField1312 { get {return Footer().NewField1312;} }
            public TTReportField TOPLAMIADETUTARI { get {return Footer().TOPLAMIADETUTARI;} }
            public TTReportShape NewLine12 { get {return Footer().NewLine12;} }
            public TTReportField NewField12131 { get {return Footer().NewField12131;} }
            public TTReportField TOPLAMTUTAR { get {return Footer().TOPLAMTUTAR;} }
            public TTReportShape NewLine121 { get {return Footer().NewLine121;} }
            public PARTDGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTDGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTDGroupHeader(this);
                _footer = new PARTDGroupFooter(this);

            }

            public partial class PARTDGroupHeader : TTReportSection
            {
                public MainCashOfficeOpsReport MyParentReport
                {
                    get { return (MainCashOfficeOpsReport)ParentReport; }
                }
                
                public TTReportField NewField11;
                public TTReportField NewField12;
                public TTReportField NewField13;
                public TTReportField NewField14;
                public TTReportField NewField15;
                public TTReportShape NewLine11;
                public TTReportField NewField141;
                public TTReportField NewField1241;
                public TTReportField NewField16; 
                public PARTDGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 15;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 8, 19, 13, false);
                    NewField11.Name = "NewField11";
                    NewField11.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11.NoClip = EvetHayirEnum.ehEvet;
                    NewField11.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField11.TextFont.Name = "Arial";
                    NewField11.TextFont.Size = 8;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"Sıra No";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 8, 38, 13, false);
                    NewField12.Name = "NewField12";
                    NewField12.TextFont.Name = "Arial";
                    NewField12.TextFont.Size = 8;
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"Alındı Tarihi";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 8, 179, 13, false);
                    NewField13.Name = "NewField13";
                    NewField13.TextFont.Name = "Arial";
                    NewField13.TextFont.Size = 8;
                    NewField13.TextFont.Bold = true;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @"İade Türü";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 8, 54, 13, false);
                    NewField14.Name = "NewField14";
                    NewField14.TextFont.Name = "Arial";
                    NewField14.TextFont.Size = 8;
                    NewField14.TextFont.Bold = true;
                    NewField14.TextFont.CharSet = 162;
                    NewField14.Value = @"Alındı No";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 180, 8, 202, 13, false);
                    NewField15.Name = "NewField15";
                    NewField15.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField15.TextFont.Name = "Arial";
                    NewField15.TextFont.Size = 8;
                    NewField15.TextFont.Bold = true;
                    NewField15.TextFont.CharSet = 162;
                    NewField15.Value = @"İade Tutarı";

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 14, 202, 14, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 86, 8, 105, 13, false);
                    NewField141.Name = "NewField141";
                    NewField141.TextFont.Name = "Arial";
                    NewField141.TextFont.Size = 8;
                    NewField141.TextFont.Bold = true;
                    NewField141.TextFont.CharSet = 162;
                    NewField141.Value = @"TC Kimlik No";

                    NewField1241 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 55, 8, 85, 13, false);
                    NewField1241.Name = "NewField1241";
                    NewField1241.TextFont.Name = "Arial";
                    NewField1241.TextFont.Size = 8;
                    NewField1241.TextFont.Bold = true;
                    NewField1241.TextFont.CharSet = 162;
                    NewField1241.Value = @"Hastanın Adı Soyadı";

                    NewField16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 2, 54, 7, false);
                    NewField16.Name = "NewField16";
                    NewField16.TextFont.Bold = true;
                    NewField16.TextFont.CharSet = 162;
                    NewField16.Value = @"İade Bilgileri";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField11.CalcValue = NewField11.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField14.CalcValue = NewField14.Value;
                    NewField15.CalcValue = NewField15.Value;
                    NewField141.CalcValue = NewField141.Value;
                    NewField1241.CalcValue = NewField1241.Value;
                    NewField16.CalcValue = NewField16.Value;
                    return new TTReportObject[] { NewField11,NewField12,NewField13,NewField14,NewField15,NewField141,NewField1241,NewField16};
                }

                public override void RunScript()
                {
#region PARTD HEADER_Script
                    if(!string.IsNullOrEmpty(((MainCashOfficeOpsReport)ParentReport).tahsilatTuru))
                this.Visible = EvetHayirEnum.ehHayir;
#endregion PARTD HEADER_Script
                }
            }
            public partial class PARTDGroupFooter : TTReportSection
            {
                public MainCashOfficeOpsReport MyParentReport
                {
                    get { return (MainCashOfficeOpsReport)ParentReport; }
                }
                
                public TTReportField NewField1312;
                public TTReportField TOPLAMIADETUTARI;
                public TTReportShape NewLine12;
                public TTReportField NewField12131;
                public TTReportField TOPLAMTUTAR;
                public TTReportShape NewLine121; 
                public PARTDGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 24;
                    RepeatCount = 0;
                    
                    NewField1312 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 127, 5, 168, 10, false);
                    NewField1312.Name = "NewField1312";
                    NewField1312.TextFont.Name = "Arial";
                    NewField1312.TextFont.Size = 8;
                    NewField1312.TextFont.Bold = true;
                    NewField1312.TextFont.CharSet = 162;
                    NewField1312.Value = @"Toplam İade Tutarı :";

                    TOPLAMIADETUTARI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 5, 202, 10, false);
                    TOPLAMIADETUTARI.Name = "TOPLAMIADETUTARI";
                    TOPLAMIADETUTARI.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOPLAMIADETUTARI.TextFormat = @"#,##0.#0";
                    TOPLAMIADETUTARI.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOPLAMIADETUTARI.TextFont.Size = 8;
                    TOPLAMIADETUTARI.TextFont.CharSet = 162;
                    TOPLAMIADETUTARI.Value = @"{@sumof(IADETUTARI)@}";

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 126, 3, 202, 3, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField12131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 127, 18, 168, 23, false);
                    NewField12131.Name = "NewField12131";
                    NewField12131.TextFont.Name = "Arial";
                    NewField12131.TextFont.Size = 8;
                    NewField12131.TextFont.Bold = true;
                    NewField12131.TextFont.CharSet = 162;
                    NewField12131.Value = @"Toplam Tutar :";

                    TOPLAMTUTAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 18, 202, 23, false);
                    TOPLAMTUTAR.Name = "TOPLAMTUTAR";
                    TOPLAMTUTAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOPLAMTUTAR.TextFormat = @"#,##0.#0";
                    TOPLAMTUTAR.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOPLAMTUTAR.TextFont.Size = 8;
                    TOPLAMTUTAR.TextFont.CharSet = 162;
                    TOPLAMTUTAR.Value = @"";

                    NewLine121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 126, 16, 202, 16, false);
                    NewLine121.Name = "NewLine121";
                    NewLine121.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1312.CalcValue = NewField1312.Value;
                    TOPLAMIADETUTARI.CalcValue = ParentGroup.FieldSums["IADETUTARI"].Value.ToString();;
                    NewField12131.CalcValue = NewField12131.Value;
                    TOPLAMTUTAR.CalcValue = @"";
                    return new TTReportObject[] { NewField1312,TOPLAMIADETUTARI,NewField12131,TOPLAMTUTAR};
                }

                public override void RunScript()
                {
#region PARTD FOOTER_Script
                    this.TOPLAMTUTAR.CalcValue = (((MainCashOfficeOpsReport)ParentReport).toplamTahsilatTutari - Convert.ToDouble(this.TOPLAMIADETUTARI.CalcValue)).ToString();
            if(!string.IsNullOrEmpty(((MainCashOfficeOpsReport)ParentReport).tahsilatTuru))
                this.Visible = EvetHayirEnum.ehHayir;
#endregion PARTD FOOTER_Script
                }
            }

        }

        public PARTDGroup PARTD;

        public partial class PARTCGroup : TTReportGroup
        {
            public MainCashOfficeOpsReport MyParentReport
            {
                get { return (MainCashOfficeOpsReport)ParentReport; }
            }

            new public PARTCGroupBody Body()
            {
                return (PARTCGroupBody)_body;
            }
            public TTReportField SIRANO { get {return Body().SIRANO;} }
            public TTReportField VEZNEALINDITARIHI { get {return Body().VEZNEALINDITARIHI;} }
            public TTReportField IADETURU { get {return Body().IADETURU;} }
            public TTReportField ALINDINO { get {return Body().ALINDINO;} }
            public TTReportField IADETUTARI { get {return Body().IADETUTARI;} }
            public TTReportField TCKIMLIKNO { get {return Body().TCKIMLIKNO;} }
            public TTReportField ADISOYADI { get {return Body().ADISOYADI;} }
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
                list[0] = new TTReportNqlData<AccountDocument.GetBackDocumentByDate_Class>("GetBackDocumentByDate", AccountDocument.GetBackDocumentByDate((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new PARTCGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class PARTCGroupBody : TTReportSection
            {
                public MainCashOfficeOpsReport MyParentReport
                {
                    get { return (MainCashOfficeOpsReport)ParentReport; }
                }
                
                public TTReportField SIRANO;
                public TTReportField VEZNEALINDITARIHI;
                public TTReportField IADETURU;
                public TTReportField ALINDINO;
                public TTReportField IADETUTARI;
                public TTReportField TCKIMLIKNO;
                public TTReportField ADISOYADI; 
                public PARTCGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 7;
                    RepeatCount = 0;
                    
                    SIRANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 1, 19, 6, false);
                    SIRANO.Name = "SIRANO";
                    SIRANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SIRANO.MultiLine = EvetHayirEnum.ehEvet;
                    SIRANO.NoClip = EvetHayirEnum.ehEvet;
                    SIRANO.WordBreak = EvetHayirEnum.ehEvet;
                    SIRANO.ExpandTabs = EvetHayirEnum.ehEvet;
                    SIRANO.TextFont.Size = 8;
                    SIRANO.TextFont.CharSet = 162;
                    SIRANO.Value = @"{@groupcounter@}";

                    VEZNEALINDITARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 1, 38, 6, false);
                    VEZNEALINDITARIHI.Name = "VEZNEALINDITARIHI";
                    VEZNEALINDITARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    VEZNEALINDITARIHI.TextFormat = @"dd/MM/yyyy";
                    VEZNEALINDITARIHI.MultiLine = EvetHayirEnum.ehEvet;
                    VEZNEALINDITARIHI.NoClip = EvetHayirEnum.ehEvet;
                    VEZNEALINDITARIHI.WordBreak = EvetHayirEnum.ehEvet;
                    VEZNEALINDITARIHI.ExpandTabs = EvetHayirEnum.ehEvet;
                    VEZNEALINDITARIHI.TextFont.Size = 8;
                    VEZNEALINDITARIHI.TextFont.CharSet = 162;
                    VEZNEALINDITARIHI.Value = @"{#DOCUMENTDATE#}";

                    IADETURU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 1, 179, 6, false);
                    IADETURU.Name = "IADETURU";
                    IADETURU.FieldType = ReportFieldTypeEnum.ftVariable;
                    IADETURU.MultiLine = EvetHayirEnum.ehEvet;
                    IADETURU.NoClip = EvetHayirEnum.ehEvet;
                    IADETURU.WordBreak = EvetHayirEnum.ehEvet;
                    IADETURU.ExpandTabs = EvetHayirEnum.ehEvet;
                    IADETURU.TextFont.Size = 8;
                    IADETURU.TextFont.CharSet = 162;
                    IADETURU.Value = @"{#NAME#}";

                    ALINDINO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 1, 54, 6, false);
                    ALINDINO.Name = "ALINDINO";
                    ALINDINO.FieldType = ReportFieldTypeEnum.ftVariable;
                    ALINDINO.MultiLine = EvetHayirEnum.ehEvet;
                    ALINDINO.NoClip = EvetHayirEnum.ehEvet;
                    ALINDINO.WordBreak = EvetHayirEnum.ehEvet;
                    ALINDINO.ExpandTabs = EvetHayirEnum.ehEvet;
                    ALINDINO.TextFont.Size = 8;
                    ALINDINO.TextFont.CharSet = 162;
                    ALINDINO.Value = @"{#DOCUMENTNO#}";

                    IADETUTARI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 180, 1, 202, 6, false);
                    IADETUTARI.Name = "IADETUTARI";
                    IADETUTARI.FieldType = ReportFieldTypeEnum.ftVariable;
                    IADETUTARI.TextFormat = @"#,##0.#0";
                    IADETUTARI.HorzAlign = HorizontalAlignmentEnum.haRight;
                    IADETUTARI.TextFont.Size = 8;
                    IADETUTARI.TextFont.CharSet = 162;
                    IADETUTARI.Value = @"{#TOTALPRICE#}";

                    TCKIMLIKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 86, 1, 105, 6, false);
                    TCKIMLIKNO.Name = "TCKIMLIKNO";
                    TCKIMLIKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    TCKIMLIKNO.MultiLine = EvetHayirEnum.ehEvet;
                    TCKIMLIKNO.NoClip = EvetHayirEnum.ehEvet;
                    TCKIMLIKNO.WordBreak = EvetHayirEnum.ehEvet;
                    TCKIMLIKNO.ExpandTabs = EvetHayirEnum.ehEvet;
                    TCKIMLIKNO.TextFont.Size = 8;
                    TCKIMLIKNO.TextFont.CharSet = 162;
                    TCKIMLIKNO.Value = @"{#UNIQUEREFNO#}";

                    ADISOYADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 55, 1, 85, 6, false);
                    ADISOYADI.Name = "ADISOYADI";
                    ADISOYADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADISOYADI.MultiLine = EvetHayirEnum.ehEvet;
                    ADISOYADI.NoClip = EvetHayirEnum.ehEvet;
                    ADISOYADI.WordBreak = EvetHayirEnum.ehEvet;
                    ADISOYADI.ExpandTabs = EvetHayirEnum.ehEvet;
                    ADISOYADI.TextFont.Size = 8;
                    ADISOYADI.TextFont.CharSet = 162;
                    ADISOYADI.Value = @"{#PATIENTNAME#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    AccountDocument.GetBackDocumentByDate_Class dataset_GetBackDocumentByDate = ParentGroup.rsGroup.GetCurrentRecord<AccountDocument.GetBackDocumentByDate_Class>(0);
                    SIRANO.CalcValue = ParentGroup.GroupCounter.ToString();
                    VEZNEALINDITARIHI.CalcValue = (dataset_GetBackDocumentByDate != null ? Globals.ToStringCore(dataset_GetBackDocumentByDate.DocumentDate) : "");
                    IADETURU.CalcValue = (dataset_GetBackDocumentByDate != null ? Globals.ToStringCore(dataset_GetBackDocumentByDate.Name) : "");
                    ALINDINO.CalcValue = (dataset_GetBackDocumentByDate != null ? Globals.ToStringCore(dataset_GetBackDocumentByDate.DocumentNo) : "");
                    IADETUTARI.CalcValue = (dataset_GetBackDocumentByDate != null ? Globals.ToStringCore(dataset_GetBackDocumentByDate.TotalPrice) : "");
                    TCKIMLIKNO.CalcValue = (dataset_GetBackDocumentByDate != null ? Globals.ToStringCore(dataset_GetBackDocumentByDate.Uniquerefno) : "");
                    ADISOYADI.CalcValue = (dataset_GetBackDocumentByDate != null ? Globals.ToStringCore(dataset_GetBackDocumentByDate.Patientname) : "");
                    return new TTReportObject[] { SIRANO,VEZNEALINDITARIHI,IADETURU,ALINDINO,IADETUTARI,TCKIMLIKNO,ADISOYADI};
                }

                public override void RunScript()
                {
#region PARTC BODY_Script
                    if(!string.IsNullOrEmpty(((MainCashOfficeOpsReport)ParentReport).tahsilatTuru))
                this.Visible = EvetHayirEnum.ehHayir;
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

        public MainCashOfficeOpsReport()
        {
            PARTE = new PARTEGroup(this,"PARTE");
            PARTB = new PARTBGroup(PARTE,"PARTB");
            PARTA = new PARTAGroup(PARTB,"PARTA");
            MAIN = new MAINGroup(PARTA,"MAIN");
            PARTD = new PARTDGroup(PARTB,"PARTD");
            PARTC = new PARTCGroup(PARTD,"PARTC");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STARTDATE", "", "Başlangıç Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENDDATE", "", "Bitiş Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("TYPE", "", "Tahsilat Türü", @"", false, true, true, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("2b5dfbce-031e-4525-aec6-3857bfaf29bb");
            reportParameter = Parameters.Add("TYPECONTROL", "", "", @"", false, false, false, new Guid("e23a630a-eb08-4621-bc97-1fc8fc93ba28"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STARTDATE"))
                _runtimeParameters.STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTDATE"]);
            if (parameters.ContainsKey("ENDDATE"))
                _runtimeParameters.ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ENDDATE"]);
            if (parameters.ContainsKey("TYPE"))
                _runtimeParameters.TYPE = (List<string>)parameters["TYPE"];
            if (parameters.ContainsKey("TYPECONTROL"))
                _runtimeParameters.TYPECONTROL = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(parameters["TYPECONTROL"]);
            Name = "MAINCASHOFFICEOPSREPORT";
            Caption = "Vezne Tahsilatları Raporu";
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
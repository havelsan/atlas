
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
    /// Sağlık Kurulu XXXXXX Okul TC Kimlik No Eşleştirme
    /// </summary>
    public partial class HCMilitaryUnitTCNoMatchReport : TTReport
    {
#region Methods
   public string readTcKimlikNo = "";
        public string unReadTcKimlikNo = "";
   
#endregion Methods

        public class ReportRuntimeParameters 
        {
            public int? YEAR = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue("");
            public string MILTARYUNIT = (string)TTObjectDefManager.Instance.DataTypes["String255"].ConvertValue("");
            public int? ISREADFLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue("");
        }

        public partial class PARTBGroup : TTReportGroup
        {
            public HCMilitaryUnitTCNoMatchReport MyParentReport
            {
                get { return (HCMilitaryUnitTCNoMatchReport)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField NewField11111 { get {return Header().NewField11111;} }
            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportField MILITARYUNIT { get {return Header().MILITARYUNIT;} }
            public TTReportField NewField1111 { get {return Header().NewField1111;} }
            public TTReportField NewField1121 { get {return Header().NewField1121;} }
            public TTReportField YEAR { get {return Header().YEAR;} }
            public TTReportField CURRENTUSER { get {return Footer().CURRENTUSER;} }
            public TTReportField PrintDate { get {return Footer().PrintDate;} }
            public TTReportField PageNumber { get {return Footer().PageNumber;} }
            public TTReportShape NewLine111111111 { get {return Footer().NewLine111111111;} }
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
                public HCMilitaryUnitTCNoMatchReport MyParentReport
                {
                    get { return (HCMilitaryUnitTCNoMatchReport)ParentReport; }
                }
                
                public TTReportField NewField11111;
                public TTReportField NewField111;
                public TTReportField NewField121;
                public TTReportField MILITARYUNIT;
                public TTReportField NewField1111;
                public TTReportField NewField1121;
                public TTReportField YEAR; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 38;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 18, 204, 23, false);
                    NewField11111.Name = "NewField11111";
                    NewField11111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11111.TextFont.Size = 12;
                    NewField11111.TextFont.Bold = true;
                    NewField11111.TextFont.CharSet = 162;
                    NewField11111.Value = @"SAĞLIK KURULU XXXXXXİ OKUL TC KIMLIK NO EŞLEŞTİRME BİLGİ RAPORU";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 25, 32, 30, false);
                    NewField111.Name = "NewField111";
                    NewField111.TextFont.Size = 8;
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"XXXXXX Okul";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 25, 35, 30, false);
                    NewField121.Name = "NewField121";
                    NewField121.TextFont.Size = 8;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @":";

                    MILITARYUNIT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 25, 204, 30, false);
                    MILITARYUNIT.Name = "MILITARYUNIT";
                    MILITARYUNIT.FieldType = ReportFieldTypeEnum.ftVariable;
                    MILITARYUNIT.ObjectDefName = "MilitaryUnit";
                    MILITARYUNIT.DataMember = "NAME";
                    MILITARYUNIT.TextFont.Size = 8;
                    MILITARYUNIT.TextFont.CharSet = 162;
                    MILITARYUNIT.Value = @"{@MILTARYUNIT@}";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 31, 32, 36, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.TextFont.Size = 8;
                    NewField1111.TextFont.Bold = true;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @"Yıl";

                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 31, 35, 36, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.TextFont.Size = 8;
                    NewField1121.TextFont.CharSet = 162;
                    NewField1121.Value = @":";

                    YEAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 31, 61, 36, false);
                    YEAR.Name = "YEAR";
                    YEAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    YEAR.TextFont.Size = 8;
                    YEAR.TextFont.CharSet = 162;
                    YEAR.Value = @"{@YEAR@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField11111.CalcValue = NewField11111.Value;
                    NewField111.CalcValue = NewField111.Value;
                    NewField121.CalcValue = NewField121.Value;
                    MILITARYUNIT.CalcValue = MyParentReport.RuntimeParameters.MILTARYUNIT.ToString();
                    MILITARYUNIT.PostFieldValueCalculation();
                    NewField1111.CalcValue = NewField1111.Value;
                    NewField1121.CalcValue = NewField1121.Value;
                    YEAR.CalcValue = MyParentReport.RuntimeParameters.YEAR.ToString();
                    return new TTReportObject[] { NewField11111,NewField111,NewField121,MILITARYUNIT,NewField1111,NewField1121,YEAR};
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public HCMilitaryUnitTCNoMatchReport MyParentReport
                {
                    get { return (HCMilitaryUnitTCNoMatchReport)ParentReport; }
                }
                
                public TTReportField CURRENTUSER;
                public TTReportField PrintDate;
                public TTReportField PageNumber;
                public TTReportShape NewLine111111111; 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 12;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    CURRENTUSER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 98, 3, 118, 8, false);
                    CURRENTUSER.Name = "CURRENTUSER";
                    CURRENTUSER.FieldType = ReportFieldTypeEnum.ftExpression;
                    CURRENTUSER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CURRENTUSER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CURRENTUSER.TextFont.Name = "Arial";
                    CURRENTUSER.TextFont.Size = 8;
                    CURRENTUSER.TextFont.CharSet = 162;
                    CURRENTUSER.Value = @"TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : """"";

                    PrintDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 3, 36, 8, false);
                    PrintDate.Name = "PrintDate";
                    PrintDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate.TextFormat = @"Short Date";
                    PrintDate.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PrintDate.TextFont.Name = "Arial";
                    PrintDate.TextFont.Size = 8;
                    PrintDate.TextFont.CharSet = 162;
                    PrintDate.Value = @"{@printdatetime@}";

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 179, 3, 204, 8, false);
                    PageNumber.Name = "PageNumber";
                    PageNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PageNumber.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PageNumber.TextFont.Name = "Arial";
                    PageNumber.TextFont.Size = 8;
                    PageNumber.TextFont.CharSet = 162;
                    PageNumber.Value = @"Sayfa Nu:{@pagenumber@}/{@pagecount@}";

                    NewLine111111111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 5, 2, 204, 2, false);
                    NewLine111111111.Name = "NewLine111111111";
                    NewLine111111111.DrawStyle = DrawStyleConstants.vbSolid;

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

        public PARTBGroup PARTB;

        public partial class PARTAGroup : TTReportGroup
        {
            public HCMilitaryUnitTCNoMatchReport MyParentReport
            {
                get { return (HCMilitaryUnitTCNoMatchReport)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField NewField11111 { get {return Header().NewField11111;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public TTReportField READTCKIMLIKNO { get {return Footer().READTCKIMLIKNO;} }
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
                public HCMilitaryUnitTCNoMatchReport MyParentReport
                {
                    get { return (HCMilitaryUnitTCNoMatchReport)ParentReport; }
                }
                
                public TTReportField NewField11111;
                public TTReportShape NewLine1; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 7;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 1, 32, 6, false);
                    NewField11111.Name = "NewField11111";
                    NewField11111.TextFont.Size = 8;
                    NewField11111.TextFont.Bold = true;
                    NewField11111.TextFont.CharSet = 162;
                    NewField11111.Value = @"Okunanlar";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 5, 6, 32, 6, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField11111.CalcValue = NewField11111.Value;
                    return new TTReportObject[] { NewField11111};
                }

                public override void RunScript()
                {
#region PARTA HEADER_Script
                    ((HCMilitaryUnitTCNoMatchReport)ParentReport).RuntimeParameters.ISREADFLAG = 1;
#endregion PARTA HEADER_Script
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public HCMilitaryUnitTCNoMatchReport MyParentReport
                {
                    get { return (HCMilitaryUnitTCNoMatchReport)ParentReport; }
                }
                
                public TTReportField READTCKIMLIKNO; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 6;
                    RepeatCount = 0;
                    
                    READTCKIMLIKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 1, 204, 6, false);
                    READTCKIMLIKNO.Name = "READTCKIMLIKNO";
                    READTCKIMLIKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    READTCKIMLIKNO.MultiLine = EvetHayirEnum.ehEvet;
                    READTCKIMLIKNO.NoClip = EvetHayirEnum.ehEvet;
                    READTCKIMLIKNO.WordBreak = EvetHayirEnum.ehEvet;
                    READTCKIMLIKNO.ExpandTabs = EvetHayirEnum.ehEvet;
                    READTCKIMLIKNO.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    READTCKIMLIKNO.CalcValue = @"";
                    return new TTReportObject[] { READTCKIMLIKNO};
                }

                public override void RunScript()
                {
#region PARTA FOOTER_Script
                    this.READTCKIMLIKNO.CalcValue = (((HCMilitaryUnitTCNoMatchReport)ParentReport).readTcKimlikNo).Substring(0,(((HCMilitaryUnitTCNoMatchReport)ParentReport).readTcKimlikNo).Length -2);
#endregion PARTA FOOTER_Script
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class MAINGroup : TTReportGroup
        {
            public HCMilitaryUnitTCNoMatchReport MyParentReport
            {
                get { return (HCMilitaryUnitTCNoMatchReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField TCNO { get {return Body().TCNO;} }
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
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[2];
                list[0] = new TTReportNqlData<HCMilitaryUnitTCNoMatch.GetReadHCMilitaryUnitTCNoMatch_Class>("GetReadHCMilitaryUnitTCNoMatch", HCMilitaryUnitTCNoMatch.GetReadHCMilitaryUnitTCNoMatch((int)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(MyParentReport.RuntimeParameters.YEAR),(string)TTObjectDefManager.Instance.DataTypes["String255"].ConvertValue(MyParentReport.RuntimeParameters.MILTARYUNIT),(int)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(MyParentReport.RuntimeParameters.ISREADFLAG)));
                list[1] = new TTReportNqlData<HCMilitaryUnitTCNoMatch.GetReadHCMilitaryUnitTCNoMatch_Class>("GetReadHCMilitaryUnitTCNoMatch2", HCMilitaryUnitTCNoMatch.GetReadHCMilitaryUnitTCNoMatch((int)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(MyParentReport.RuntimeParameters.YEAR),(string)TTObjectDefManager.Instance.DataTypes["String255"].ConvertValue(MyParentReport.RuntimeParameters.MILTARYUNIT),(int)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(MyParentReport.RuntimeParameters.ISREADFLAG)));
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
                public HCMilitaryUnitTCNoMatchReport MyParentReport
                {
                    get { return (HCMilitaryUnitTCNoMatchReport)ParentReport; }
                }
                
                public TTReportField TCNO; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 6;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    TCNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 1, 237, 6, false);
                    TCNO.Name = "TCNO";
                    TCNO.Visible = EvetHayirEnum.ehHayir;
                    TCNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    TCNO.Value = @"{#TCNO#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    HCMilitaryUnitTCNoMatch.GetReadHCMilitaryUnitTCNoMatch_Class dataset_GetReadHCMilitaryUnitTCNoMatch = ParentGroup.rsGroup.GetCurrentRecord<HCMilitaryUnitTCNoMatch.GetReadHCMilitaryUnitTCNoMatch_Class>(0);
                    HCMilitaryUnitTCNoMatch.GetReadHCMilitaryUnitTCNoMatch_Class dataset_GetReadHCMilitaryUnitTCNoMatch2 = ParentGroup.rsGroup.GetCurrentRecord<HCMilitaryUnitTCNoMatch.GetReadHCMilitaryUnitTCNoMatch_Class>(1);
                    TCNO.CalcValue = (dataset_GetReadHCMilitaryUnitTCNoMatch != null ? Globals.ToStringCore(dataset_GetReadHCMilitaryUnitTCNoMatch.TCNo) : "");
                    return new TTReportObject[] { TCNO};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    ((HCMilitaryUnitTCNoMatchReport)ParentReport).readTcKimlikNo += this.TCNO.CalcValue + ", ";
#endregion MAIN BODY_Script
                }
            }

        }

        public MAINGroup MAIN;

        public partial class PARTCGroup : TTReportGroup
        {
            public HCMilitaryUnitTCNoMatchReport MyParentReport
            {
                get { return (HCMilitaryUnitTCNoMatchReport)ParentReport; }
            }

            new public PARTCGroupHeader Header()
            {
                return (PARTCGroupHeader)_header;
            }

            new public PARTCGroupFooter Footer()
            {
                return (PARTCGroupFooter)_footer;
            }

            public TTReportField NewField111111 { get {return Header().NewField111111;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public TTReportField UNREADTCKIMLIKNO { get {return Footer().UNREADTCKIMLIKNO;} }
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
                _body = null;
                _header = new PARTCGroupHeader(this);
                _footer = new PARTCGroupFooter(this);

            }

            public partial class PARTCGroupHeader : TTReportSection
            {
                public HCMilitaryUnitTCNoMatchReport MyParentReport
                {
                    get { return (HCMilitaryUnitTCNoMatchReport)ParentReport; }
                }
                
                public TTReportField NewField111111;
                public TTReportShape NewLine1; 
                public PARTCGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 7;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 1, 32, 6, false);
                    NewField111111.Name = "NewField111111";
                    NewField111111.TextFont.Size = 8;
                    NewField111111.TextFont.Bold = true;
                    NewField111111.TextFont.CharSet = 162;
                    NewField111111.Value = @"Okunmayanlar";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 5, 6, 32, 6, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField111111.CalcValue = NewField111111.Value;
                    return new TTReportObject[] { NewField111111};
                }

                public override void RunScript()
                {
#region PARTC HEADER_Script
                    ((HCMilitaryUnitTCNoMatchReport)ParentReport).RuntimeParameters.ISREADFLAG = 0;
#endregion PARTC HEADER_Script
                }
            }
            public partial class PARTCGroupFooter : TTReportSection
            {
                public HCMilitaryUnitTCNoMatchReport MyParentReport
                {
                    get { return (HCMilitaryUnitTCNoMatchReport)ParentReport; }
                }
                
                public TTReportField UNREADTCKIMLIKNO; 
                public PARTCGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 5;
                    RepeatCount = 0;
                    
                    UNREADTCKIMLIKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 0, 204, 5, false);
                    UNREADTCKIMLIKNO.Name = "UNREADTCKIMLIKNO";
                    UNREADTCKIMLIKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNREADTCKIMLIKNO.MultiLine = EvetHayirEnum.ehEvet;
                    UNREADTCKIMLIKNO.NoClip = EvetHayirEnum.ehEvet;
                    UNREADTCKIMLIKNO.WordBreak = EvetHayirEnum.ehEvet;
                    UNREADTCKIMLIKNO.ExpandTabs = EvetHayirEnum.ehEvet;
                    UNREADTCKIMLIKNO.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    UNREADTCKIMLIKNO.CalcValue = @"";
                    return new TTReportObject[] { UNREADTCKIMLIKNO};
                }

                public override void RunScript()
                {
#region PARTC FOOTER_Script
                    this.UNREADTCKIMLIKNO.CalcValue = (((HCMilitaryUnitTCNoMatchReport)ParentReport).unReadTcKimlikNo).Substring(0,(((HCMilitaryUnitTCNoMatchReport)ParentReport).unReadTcKimlikNo).Length -2);            
            ((HCMilitaryUnitTCNoMatchReport)ParentReport).readTcKimlikNo = "";
            ((HCMilitaryUnitTCNoMatchReport)ParentReport).unReadTcKimlikNo = "";
#endregion PARTC FOOTER_Script
                }
            }

        }

        public PARTCGroup PARTC;

        public partial class PARTDGroup : TTReportGroup
        {
            public HCMilitaryUnitTCNoMatchReport MyParentReport
            {
                get { return (HCMilitaryUnitTCNoMatchReport)ParentReport; }
            }

            new public PARTDGroupBody Body()
            {
                return (PARTDGroupBody)_body;
            }
            public TTReportField TCNO { get {return Body().TCNO;} }
            public PARTDGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTDGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[2];
                list[0] = new TTReportNqlData<HCMilitaryUnitTCNoMatch.GetReadHCMilitaryUnitTCNoMatch_Class>("GetReadHCMilitaryUnitTCNoMatch", HCMilitaryUnitTCNoMatch.GetReadHCMilitaryUnitTCNoMatch((int)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(MyParentReport.RuntimeParameters.YEAR),(string)TTObjectDefManager.Instance.DataTypes["String255"].ConvertValue(MyParentReport.RuntimeParameters.MILTARYUNIT),(int)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(MyParentReport.RuntimeParameters.ISREADFLAG)));
                list[1] = new TTReportNqlData<HCMilitaryUnitTCNoMatch.GetReadHCMilitaryUnitTCNoMatch_Class>("GetReadHCMilitaryUnitTCNoMatch2", HCMilitaryUnitTCNoMatch.GetReadHCMilitaryUnitTCNoMatch((int)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(MyParentReport.RuntimeParameters.YEAR),(string)TTObjectDefManager.Instance.DataTypes["String255"].ConvertValue(MyParentReport.RuntimeParameters.MILTARYUNIT),(int)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(MyParentReport.RuntimeParameters.ISREADFLAG)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new PARTDGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class PARTDGroupBody : TTReportSection
            {
                public HCMilitaryUnitTCNoMatchReport MyParentReport
                {
                    get { return (HCMilitaryUnitTCNoMatchReport)ParentReport; }
                }
                
                public TTReportField TCNO; 
                public PARTDGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 8;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    TCNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 1, 237, 6, false);
                    TCNO.Name = "TCNO";
                    TCNO.Visible = EvetHayirEnum.ehHayir;
                    TCNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    TCNO.Value = @"{#TCNO#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    HCMilitaryUnitTCNoMatch.GetReadHCMilitaryUnitTCNoMatch_Class dataset_GetReadHCMilitaryUnitTCNoMatch = ParentGroup.rsGroup.GetCurrentRecord<HCMilitaryUnitTCNoMatch.GetReadHCMilitaryUnitTCNoMatch_Class>(0);
                    HCMilitaryUnitTCNoMatch.GetReadHCMilitaryUnitTCNoMatch_Class dataset_GetReadHCMilitaryUnitTCNoMatch2 = ParentGroup.rsGroup.GetCurrentRecord<HCMilitaryUnitTCNoMatch.GetReadHCMilitaryUnitTCNoMatch_Class>(1);
                    TCNO.CalcValue = (dataset_GetReadHCMilitaryUnitTCNoMatch != null ? Globals.ToStringCore(dataset_GetReadHCMilitaryUnitTCNoMatch.TCNo) : "");
                    return new TTReportObject[] { TCNO};
                }

                public override void RunScript()
                {
#region PARTD BODY_Script
                    ((HCMilitaryUnitTCNoMatchReport)ParentReport).unReadTcKimlikNo += this.TCNO.CalcValue + ", ";
#endregion PARTD BODY_Script
                }
            }

        }

        public PARTDGroup PARTD;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public HCMilitaryUnitTCNoMatchReport()
        {
            PARTB = new PARTBGroup(this,"PARTB");
            PARTA = new PARTAGroup(PARTB,"PARTA");
            MAIN = new MAINGroup(PARTA,"MAIN");
            PARTC = new PARTCGroup(PARTB,"PARTC");
            PARTD = new PARTDGroup(PARTC,"PARTD");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("YEAR", "", "Yıl", @"", true, true, false, new Guid("e23a630a-eb08-4621-bc97-1fc8fc93ba28"));
            reportParameter = Parameters.Add("MILTARYUNIT", "", "XXXXXX Okul", @"", true, true, false, new Guid("ea658106-fa2f-4da3-a702-db9139c4e63f"));
            reportParameter.ListDefID = new Guid("5ddce28b-ad8b-458a-a4f8-8c3ba610474c");
            reportParameter = Parameters.Add("ISREADFLAG", "", "", @"", false, false, false, new Guid("e23a630a-eb08-4621-bc97-1fc8fc93ba28"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("YEAR"))
                _runtimeParameters.YEAR = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(parameters["YEAR"]);
            if (parameters.ContainsKey("MILTARYUNIT"))
                _runtimeParameters.MILTARYUNIT = (string)TTObjectDefManager.Instance.DataTypes["String255"].ConvertValue(parameters["MILTARYUNIT"]);
            if (parameters.ContainsKey("ISREADFLAG"))
                _runtimeParameters.ISREADFLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(parameters["ISREADFLAG"]);
            Name = "HCMILITARYUNITTCNOMATCHREPORT";
            Caption = "Sağlık Kurulu XXXXXX Okul TC Kimlik No Eşleştirme";
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

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
    public partial class MaterialLotDetailsReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? STOCKCARDID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
            public Guid? STOREID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public MaterialLotDetailsReport MyParentReport
            {
                get { return (MaterialLotDetailsReport)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField NewField1111 { get {return Header().NewField1111;} }
            public TTReportField PrintDate1 { get {return Footer().PrintDate1;} }
            public TTReportField PageNumber1 { get {return Footer().PageNumber1;} }
            public TTReportField CurrentUser1 { get {return Footer().CurrentUser1;} }
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
                public MaterialLotDetailsReport MyParentReport
                {
                    get { return (MaterialLotDetailsReport)ParentReport; }
                }
                
                public TTReportField NewField1111; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 23;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 7, 240, 16, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111.TextFont.Size = 14;
                    NewField1111.TextFont.Bold = true;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @"MALZEME DETAY RAPORU";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1111.CalcValue = NewField1111.Value;
                    return new TTReportObject[] { NewField1111};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public MaterialLotDetailsReport MyParentReport
                {
                    get { return (MaterialLotDetailsReport)ParentReport; }
                }
                
                public TTReportField PrintDate1;
                public TTReportField PageNumber1;
                public TTReportField CurrentUser1; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 18;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    PrintDate1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 4, 0, 29, 5, false);
                    PrintDate1.Name = "PrintDate1";
                    PrintDate1.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PrintDate1.TextFont.Size = 8;
                    PrintDate1.TextFont.CharSet = 162;
                    PrintDate1.Value = @"{@printdate@}";

                    PageNumber1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 255, 1, 280, 6, false);
                    PageNumber1.Name = "PageNumber1";
                    PageNumber1.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber1.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PageNumber1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PageNumber1.TextFont.Size = 8;
                    PageNumber1.TextFont.CharSet = 162;
                    PageNumber1.Value = @"Sayfa Nu.{@pagenumber@}/{@pagecount@}";

                    CurrentUser1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 127, 1, 157, 6, false);
                    CurrentUser1.Name = "CurrentUser1";
                    CurrentUser1.FieldType = ReportFieldTypeEnum.ftExpression;
                    CurrentUser1.CaseFormat = CaseFormatEnum.fcNameSurname;
                    CurrentUser1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CurrentUser1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CurrentUser1.TextFont.Size = 8;
                    CurrentUser1.TextFont.CharSet = 162;
                    CurrentUser1.Value = @"TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : """"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PrintDate1.CalcValue = DateTime.Now.ToShortDateString();
                    PageNumber1.CalcValue = @"Sayfa Nu." + ParentReport.CurrentPageNumber.ToString() + @"/" + ParentReport.ReportTotalPageCount;
                    CurrentUser1.CalcValue = TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : "";
                    return new TTReportObject[] { PrintDate1,PageNumber1,CurrentUser1};
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class PARTBGroup : TTReportGroup
        {
            public MaterialLotDetailsReport MyParentReport
            {
                get { return (MaterialLotDetailsReport)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportRTF NewRTF1 { get {return Header().NewRTF1;} }
            public TTReportRTF NewRTF12 { get {return Header().NewRTF12;} }
            public TTReportRTF NewRTF13 { get {return Header().NewRTF13;} }
            public TTReportRTF NewRTF14 { get {return Header().NewRTF14;} }
            public TTReportRTF NewRTF15 { get {return Header().NewRTF15;} }
            public TTReportRTF NewRTF16 { get {return Header().NewRTF16;} }
            public TTReportRTF NewRTF11 { get {return Header().NewRTF11;} }
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
                public MaterialLotDetailsReport MyParentReport
                {
                    get { return (MaterialLotDetailsReport)ParentReport; }
                }
                
                public TTReportRTF NewRTF1;
                public TTReportRTF NewRTF12;
                public TTReportRTF NewRTF13;
                public TTReportRTF NewRTF14;
                public TTReportRTF NewRTF15;
                public TTReportRTF NewRTF16;
                public TTReportRTF NewRTF11; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 15;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewRTF1 = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 13, 0, 41, 15, false);
                    NewRTF1.Name = "NewRTF1";
                    NewRTF1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewRTF1.Value = @"{\rtf1\ansi\ansicpg1254\deff0\deflang1055{\fonttbl{\f0\fnil\fcharset162{\*\fname Arial;}Arial TUR;}{\f1\fnil\fcharset162{\*\fname Courier New;}Courier New TUR;}}
\viewkind4\uc1\pard\qc\b\f0\fs20\par
NATO STOK \par
NUMARASI\b0\f1\par
}
";

                    NewRTF12 = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 41, 0, 113, 15, false);
                    NewRTF12.Name = "NewRTF12";
                    NewRTF12.DrawStyle = DrawStyleConstants.vbSolid;
                    NewRTF12.Value = @"{\rtf1\ansi\ansicpg1254\deff0\deflang1055{\fonttbl{\f0\fnil\fcharset162{\*\fname Arial;}Arial TUR;}{\f1\fnil\fcharset162{\*\fname Courier New;}Courier New TUR;}}
\viewkind4\uc1\pard\qc\b\f0\fs20\par
\par
MALZEMEN\'ddN \'ddSM\'dd\b0\f1\par
}
";

                    NewRTF13 = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 113, 0, 196, 15, false);
                    NewRTF13.Name = "NewRTF13";
                    NewRTF13.DrawStyle = DrawStyleConstants.vbSolid;
                    NewRTF13.Value = @"{\rtf1\ansi\ansicpg1254\deff0\deflang1055{\fonttbl{\f0\fnil\fcharset162{\*\fname Arial;}Arial TUR;}{\f1\fnil\fcharset162{\*\fname Courier New;}Courier New TUR;}}
\viewkind4\uc1\pard\qc\b\f0\fs20\par
\par
BULUNDU\'d0U B\'ddR\'ddM\b0\f1\par
}
";

                    NewRTF14 = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 196, 0, 234, 15, false);
                    NewRTF14.Name = "NewRTF14";
                    NewRTF14.DrawStyle = DrawStyleConstants.vbSolid;
                    NewRTF14.Value = @"{\rtf1\ansi\ansicpg1254\deff0\deflang1055{\fonttbl{\f0\fnil\fcharset162{\*\fname Arial;}Arial TUR;}{\f1\fnil\fcharset162{\*\fname Courier New;}Courier New TUR;}}
\viewkind4\uc1\pard\qc\b\f0\fs20\par
\par
LOT NUMARASI\b0\f1\par
}
";

                    NewRTF15 = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 234, 0, 256, 15, false);
                    NewRTF15.Name = "NewRTF15";
                    NewRTF15.DrawStyle = DrawStyleConstants.vbSolid;
                    NewRTF15.Value = @"{\rtf1\ansi\ansicpg1254\deff0\deflang1055{\fonttbl{\f0\fnil\fcharset162{\*\fname Arial;}Arial TUR;}{\f1\fnil\fcharset162{\*\fname Courier New;}Courier New TUR;}}
\viewkind4\uc1\pard\qc\b\f0\fs20 SON KULLANMA TAR\'ddH\'dd\b0\f1\par
}
";

                    NewRTF16 = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 256, 0, 280, 15, false);
                    NewRTF16.Name = "NewRTF16";
                    NewRTF16.DrawStyle = DrawStyleConstants.vbSolid;
                    NewRTF16.Value = @"{\rtf1\ansi\ansicpg1254\deff0\deflang1055{\fonttbl{\f0\fnil\fcharset162{\*\fname Arial;}Arial TUR;}{\f1\fnil\fcharset162{\*\fname Courier New;}Courier New TUR;}}
\viewkind4\uc1\pard\qc\b\f0\fs20\par
KALAN M\'ddKTAR\b0\f1\par
}
";

                    NewRTF11 = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 2, 0, 13, 15, false);
                    NewRTF11.Name = "NewRTF11";
                    NewRTF11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewRTF11.Value = @"{\rtf1\ansi\ansicpg1254\deff0\deflang1055{\fonttbl{\f0\fnil\fcharset162{\*\fname Arial;}Arial TUR;}{\f1\fnil\fcharset162{\*\fname Courier New;}Courier New TUR;}}
\viewkind4\uc1\pard\qc\b\f0\fs20\par
SIRA\par
NU.\b0\f1\par
}
";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewRTF1.CalcValue = NewRTF1.Value;
                    NewRTF12.CalcValue = NewRTF12.Value;
                    NewRTF13.CalcValue = NewRTF13.Value;
                    NewRTF14.CalcValue = NewRTF14.Value;
                    NewRTF15.CalcValue = NewRTF15.Value;
                    NewRTF16.CalcValue = NewRTF16.Value;
                    NewRTF11.CalcValue = NewRTF11.Value;
                    return new TTReportObject[] { NewRTF1,NewRTF12,NewRTF13,NewRTF14,NewRTF15,NewRTF16,NewRTF11};
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public MaterialLotDetailsReport MyParentReport
                {
                    get { return (MaterialLotDetailsReport)ParentReport; }
                }
                 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTBGroup PARTB;

        public partial class MAINGroup : TTReportGroup
        {
            public MaterialLotDetailsReport MyParentReport
            {
                get { return (MaterialLotDetailsReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField STORENAME { get {return Body().STORENAME;} }
            public TTReportField MATERIALNAME { get {return Body().MATERIALNAME;} }
            public TTReportField NATOSTOCKNO { get {return Body().NATOSTOCKNO;} }
            public TTReportField LOTNO { get {return Body().LOTNO;} }
            public TTReportField EXPIRATIONDATE { get {return Body().EXPIRATIONDATE;} }
            public TTReportField RESTAMOUNT { get {return Body().RESTAMOUNT;} }
            public TTReportField NewField1 { get {return Body().NewField1;} }
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
                list[0] = new TTReportNqlData<StockTransaction.MaterialLotDetailRQ_Class>("MaterialLotDetailRQ", StockTransaction.MaterialLotDetailRQ((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.STOREID),(Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.STOCKCARDID)));
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
                public MaterialLotDetailsReport MyParentReport
                {
                    get { return (MaterialLotDetailsReport)ParentReport; }
                }
                
                public TTReportField STORENAME;
                public TTReportField MATERIALNAME;
                public TTReportField NATOSTOCKNO;
                public TTReportField LOTNO;
                public TTReportField EXPIRATIONDATE;
                public TTReportField RESTAMOUNT;
                public TTReportField NewField1; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 5;
                    RepeatCount = 0;
                    
                    STORENAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 113, 0, 196, 5, false);
                    STORENAME.Name = "STORENAME";
                    STORENAME.DrawStyle = DrawStyleConstants.vbSolid;
                    STORENAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    STORENAME.MultiLine = EvetHayirEnum.ehEvet;
                    STORENAME.Value = @"{#STORENAME#}";

                    MATERIALNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 0, 113, 5, false);
                    MATERIALNAME.Name = "MATERIALNAME";
                    MATERIALNAME.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIALNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALNAME.Value = @"{#MATERIALNAME#}";

                    NATOSTOCKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 0, 41, 5, false);
                    NATOSTOCKNO.Name = "NATOSTOCKNO";
                    NATOSTOCKNO.DrawStyle = DrawStyleConstants.vbSolid;
                    NATOSTOCKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    NATOSTOCKNO.Value = @"{#NATOSTOCKNO#}";

                    LOTNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 196, 0, 234, 5, false);
                    LOTNO.Name = "LOTNO";
                    LOTNO.DrawStyle = DrawStyleConstants.vbSolid;
                    LOTNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    LOTNO.Value = @"{#LOTNO#}";

                    EXPIRATIONDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 234, 0, 256, 5, false);
                    EXPIRATIONDATE.Name = "EXPIRATIONDATE";
                    EXPIRATIONDATE.DrawStyle = DrawStyleConstants.vbSolid;
                    EXPIRATIONDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    EXPIRATIONDATE.TextFormat = @"dd/MM/yyyy";
                    EXPIRATIONDATE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    EXPIRATIONDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    EXPIRATIONDATE.Value = @"{#EXPIRATIONDATE#}";

                    RESTAMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 256, 0, 280, 5, false);
                    RESTAMOUNT.Name = "RESTAMOUNT";
                    RESTAMOUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    RESTAMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    RESTAMOUNT.TextFormat = @"#,###";
                    RESTAMOUNT.HorzAlign = HorizontalAlignmentEnum.haRight;
                    RESTAMOUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    RESTAMOUNT.Value = @"{#RESTAMOUNT#}";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 2, 0, 13, 5, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.Value = @"{@groupcounter@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    StockTransaction.MaterialLotDetailRQ_Class dataset_MaterialLotDetailRQ = ParentGroup.rsGroup.GetCurrentRecord<StockTransaction.MaterialLotDetailRQ_Class>(0);
                    STORENAME.CalcValue = (dataset_MaterialLotDetailRQ != null ? Globals.ToStringCore(dataset_MaterialLotDetailRQ.Storename) : "");
                    MATERIALNAME.CalcValue = (dataset_MaterialLotDetailRQ != null ? Globals.ToStringCore(dataset_MaterialLotDetailRQ.Materialname) : "");
                    NATOSTOCKNO.CalcValue = (dataset_MaterialLotDetailRQ != null ? Globals.ToStringCore(dataset_MaterialLotDetailRQ.NATOStockNO) : "");
                    LOTNO.CalcValue = (dataset_MaterialLotDetailRQ != null ? Globals.ToStringCore(dataset_MaterialLotDetailRQ.LotNo) : "");
                    EXPIRATIONDATE.CalcValue = (dataset_MaterialLotDetailRQ != null ? Globals.ToStringCore(dataset_MaterialLotDetailRQ.ExpirationDate) : "");
                    RESTAMOUNT.CalcValue = (dataset_MaterialLotDetailRQ != null ? Globals.ToStringCore(dataset_MaterialLotDetailRQ.Restamount) : "");
                    NewField1.CalcValue = ParentGroup.GroupCounter.ToString();
                    return new TTReportObject[] { STORENAME,MATERIALNAME,NATOSTOCKNO,LOTNO,EXPIRATIONDATE,RESTAMOUNT,NewField1};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public MaterialLotDetailsReport()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            PARTB = new PARTBGroup(PARTA,"PARTB");
            MAIN = new MAINGroup(PARTB,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STOCKCARDID", "00000000-0000-0000-0000-000000000000", "Malzeme", @"", false, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("e8c3b02e-4a08-4c98-bfd0-15d84fafb295");
            reportParameter = Parameters.Add("STOREID", "00000000-0000-0000-0000-000000000000", "Bulunduğu Birim", @"", false, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("65405b70-5e35-4486-b140-c95af3d8bf5d");
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STOCKCARDID"))
                _runtimeParameters.STOCKCARDID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["STOCKCARDID"]);
            if (parameters.ContainsKey("STOREID"))
                _runtimeParameters.STOREID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["STOREID"]);
            Name = "MATERIALLOTDETAILSREPORT";
            Caption = "Malzeme Lot Detayları Raporu";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oeLandscape;
            UserMarginLeft = 15;
            UserMarginTop = 15;
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
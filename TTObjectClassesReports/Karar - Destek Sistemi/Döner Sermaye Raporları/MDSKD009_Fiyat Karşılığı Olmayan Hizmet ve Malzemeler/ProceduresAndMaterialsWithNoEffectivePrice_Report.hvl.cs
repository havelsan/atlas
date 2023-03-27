
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
    /// Fiyat Karşılığı Olmayan Hizmet ve Malzemeler
    /// </summary>
    public partial class ProceduresAndMaterialsWithNoEffectivePrice : TTReport
    {
        public class ReportRuntimeParameters 
        {
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public ProceduresAndMaterialsWithNoEffectivePrice MyParentReport
            {
                get { return (ProceduresAndMaterialsWithNoEffectivePrice)ParentReport; }
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
            public TTReportField LOGO { get {return Header().LOGO;} }
            public TTReportField CURRENTUSER { get {return Footer().CURRENTUSER;} }
            public TTReportField PageNumber { get {return Footer().PageNumber;} }
            public TTReportField PrintDate { get {return Footer().PrintDate;} }
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
                public ProceduresAndMaterialsWithNoEffectivePrice MyParentReport
                {
                    get { return (ProceduresAndMaterialsWithNoEffectivePrice)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportField NewField2;
                public TTReportField LOGO; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 35;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 48, 7, 163, 27, false);
                    NewField1.Name = "NewField1";
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Size = 11;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"FİYAT KARŞILIĞI OLMAYAN HİZMET VE MALZEMELER";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 29, 29, 34, false);
                    NewField2.Name = "NewField2";
                    NewField2.TextFont.Size = 11;
                    NewField2.TextFont.Bold = true;
                    NewField2.TextFont.Underline = true;
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @"HİZMETLER";

                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 7, 47, 27, false);
                    LOGO.Name = "LOGO";
                    LOGO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    LOGO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LOGO.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1.CalcValue = NewField1.Value;
                    NewField2.CalcValue = NewField2.Value;
                    LOGO.CalcValue = LOGO.Value;
                    return new TTReportObject[] { NewField1,NewField2,LOGO};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public ProceduresAndMaterialsWithNoEffectivePrice MyParentReport
                {
                    get { return (ProceduresAndMaterialsWithNoEffectivePrice)ParentReport; }
                }
                
                public TTReportField CURRENTUSER;
                public TTReportField PageNumber;
                public TTReportField PrintDate; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 6;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    CURRENTUSER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 94, 1, 114, 6, false);
                    CURRENTUSER.Name = "CURRENTUSER";
                    CURRENTUSER.FieldType = ReportFieldTypeEnum.ftExpression;
                    CURRENTUSER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CURRENTUSER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CURRENTUSER.TextFont.Name = "Arial";
                    CURRENTUSER.TextFont.Size = 8;
                    CURRENTUSER.TextFont.CharSet = 162;
                    CURRENTUSER.Value = @"TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : """"";

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 185, 1, 210, 6, false);
                    PageNumber.Name = "PageNumber";
                    PageNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PageNumber.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PageNumber.TextFont.Name = "Arial";
                    PageNumber.TextFont.Size = 8;
                    PageNumber.TextFont.CharSet = 162;
                    PageNumber.Value = @"Sayfa Nu:{@pagenumber@}/{@pagecount@}";

                    PrintDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 1, 38, 6, false);
                    PrintDate.Name = "PrintDate";
                    PrintDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate.TextFormat = @"dd/MM/yyyy HH:mm:ss";
                    PrintDate.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PrintDate.TextFont.Name = "Arial";
                    PrintDate.TextFont.Size = 8;
                    PrintDate.TextFont.CharSet = 162;
                    PrintDate.Value = @"{@printdatetime@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PageNumber.CalcValue = @"Sayfa Nu:" + ParentReport.CurrentPageNumber.ToString() + @"/" + ParentReport.ReportTotalPageCount;
                    PrintDate.CalcValue = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
                    CURRENTUSER.CalcValue = TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : "";
                    return new TTReportObject[] { PageNumber,PrintDate,CURRENTUSER};
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class PROCGroup : TTReportGroup
        {
            public ProceduresAndMaterialsWithNoEffectivePrice MyParentReport
            {
                get { return (ProceduresAndMaterialsWithNoEffectivePrice)ParentReport; }
            }

            new public PROCGroupHeader Header()
            {
                return (PROCGroupHeader)_header;
            }

            new public PROCGroupFooter Footer()
            {
                return (PROCGroupFooter)_footer;
            }

            public TTReportField NewField11211 { get {return Header().NewField11211;} }
            public TTReportField NewField11221 { get {return Header().NewField11221;} }
            public TTReportField NewField1112111 { get {return Header().NewField1112111;} }
            public TTReportShape NewLine111 { get {return Header().NewLine111;} }
            public TTReportField NewField1121 { get {return Header().NewField1121;} }
            public TTReportField NewField11231 { get {return Header().NewField11231;} }
            public TTReportField NewField121 { get {return Footer().NewField121;} }
            public TTReportShape NewLine11111 { get {return Footer().NewLine11111;} }
            public PROCGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PROCGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PROCGroupHeader(this);
                _footer = new PROCGroupFooter(this);

            }

            public partial class PROCGroupHeader : TTReportSection
            {
                public ProceduresAndMaterialsWithNoEffectivePrice MyParentReport
                {
                    get { return (ProceduresAndMaterialsWithNoEffectivePrice)ParentReport; }
                }
                
                public TTReportField NewField11211;
                public TTReportField NewField11221;
                public TTReportField NewField1112111;
                public TTReportShape NewLine111;
                public TTReportField NewField1121;
                public TTReportField NewField11231; 
                public PROCGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 15;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField11211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 8, 128, 13, false);
                    NewField11211.Name = "NewField11211";
                    NewField11211.TextFont.Bold = true;
                    NewField11211.TextFont.CharSet = 162;
                    NewField11211.Value = @"Adı";

                    NewField11221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 195, 8, 210, 13, false);
                    NewField11221.Name = "NewField11221";
                    NewField11221.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11221.NoClip = EvetHayirEnum.ehEvet;
                    NewField11221.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11221.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField11221.TextFont.Bold = true;
                    NewField11221.TextFont.CharSet = 162;
                    NewField11221.Value = @"Aktif/Pasif";

                    NewField1112111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 130, 8, 194, 13, false);
                    NewField1112111.Name = "NewField1112111";
                    NewField1112111.TextFont.Bold = true;
                    NewField1112111.TextFont.CharSet = 162;
                    NewField1112111.Value = @"Grubu";

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 14, 210, 14, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine111.DrawWidth = 2;

                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 19, 8, 36, 13, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.TextFont.Bold = true;
                    NewField1121.TextFont.CharSet = 162;
                    NewField1121.Value = @"Kodu";

                    NewField11231 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 8, 18, 13, false);
                    NewField11231.Name = "NewField11231";
                    NewField11231.TextFont.Bold = true;
                    NewField11231.TextFont.CharSet = 162;
                    NewField11231.Value = @"Sıra No";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField11211.CalcValue = NewField11211.Value;
                    NewField11221.CalcValue = NewField11221.Value;
                    NewField1112111.CalcValue = NewField1112111.Value;
                    NewField1121.CalcValue = NewField1121.Value;
                    NewField11231.CalcValue = NewField11231.Value;
                    return new TTReportObject[] { NewField11211,NewField11221,NewField1112111,NewField1121,NewField11231};
                }
            }
            public partial class PROCGroupFooter : TTReportSection
            {
                public ProceduresAndMaterialsWithNoEffectivePrice MyParentReport
                {
                    get { return (ProceduresAndMaterialsWithNoEffectivePrice)ParentReport; }
                }
                
                public TTReportField NewField121;
                public TTReportShape NewLine11111; 
                public PROCGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 12;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 6, 58, 11, false);
                    NewField121.Name = "NewField121";
                    NewField121.TextFont.Size = 11;
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.Underline = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"MALZEMELER VE İLAÇLAR";

                    NewLine11111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 4, 210, 4, false);
                    NewLine11111.Name = "NewLine11111";
                    NewLine11111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11111.DrawWidth = 2;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField121.CalcValue = NewField121.Value;
                    return new TTReportObject[] { NewField121};
                }
            }

        }

        public PROCGroup PROC;

        public partial class MAINGroup : TTReportGroup
        {
            public ProceduresAndMaterialsWithNoEffectivePrice MyParentReport
            {
                get { return (ProceduresAndMaterialsWithNoEffectivePrice)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField SIRANO { get {return Body().SIRANO;} }
            public TTReportField CODE { get {return Body().CODE;} }
            public TTReportField NAME { get {return Body().NAME;} }
            public TTReportField GROUP { get {return Body().GROUP;} }
            public TTReportField ACTIVEPASSIVE { get {return Body().ACTIVEPASSIVE;} }
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
                list[0] = new TTReportNqlData<ProcedureDefinition.GetProcedureWithNoEffectivePrice_Class>("GetProcWithNoEffectivePrice", ProcedureDefinition.GetProcedureWithNoEffectivePrice());
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
                public ProceduresAndMaterialsWithNoEffectivePrice MyParentReport
                {
                    get { return (ProceduresAndMaterialsWithNoEffectivePrice)ParentReport; }
                }
                
                public TTReportField SIRANO;
                public TTReportField CODE;
                public TTReportField NAME;
                public TTReportField GROUP;
                public TTReportField ACTIVEPASSIVE; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 5;
                    RepeatCount = 0;
                    
                    SIRANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 0, 18, 5, false);
                    SIRANO.Name = "SIRANO";
                    SIRANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SIRANO.TextFont.CharSet = 162;
                    SIRANO.Value = @"{@groupcounter@}";

                    CODE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 19, 0, 36, 5, false);
                    CODE.Name = "CODE";
                    CODE.FieldType = ReportFieldTypeEnum.ftVariable;
                    CODE.TextFont.CharSet = 162;
                    CODE.Value = @"{#CODE#}";

                    NAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 0, 128, 5, false);
                    NAME.Name = "NAME";
                    NAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAME.MultiLine = EvetHayirEnum.ehEvet;
                    NAME.NoClip = EvetHayirEnum.ehEvet;
                    NAME.WordBreak = EvetHayirEnum.ehEvet;
                    NAME.ExpandTabs = EvetHayirEnum.ehEvet;
                    NAME.TextFont.CharSet = 162;
                    NAME.Value = @"{#NAME#}";

                    GROUP = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 130, 0, 194, 5, false);
                    GROUP.Name = "GROUP";
                    GROUP.FieldType = ReportFieldTypeEnum.ftVariable;
                    GROUP.MultiLine = EvetHayirEnum.ehEvet;
                    GROUP.NoClip = EvetHayirEnum.ehEvet;
                    GROUP.WordBreak = EvetHayirEnum.ehEvet;
                    GROUP.ExpandTabs = EvetHayirEnum.ehEvet;
                    GROUP.TextFont.CharSet = 162;
                    GROUP.Value = @"{#PROCTREEDESC#}";

                    ACTIVEPASSIVE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 195, 0, 210, 5, false);
                    ACTIVEPASSIVE.Name = "ACTIVEPASSIVE";
                    ACTIVEPASSIVE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACTIVEPASSIVE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ACTIVEPASSIVE.TextFont.CharSet = 162;
                    ACTIVEPASSIVE.Value = @"{#ISACTIVE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ProcedureDefinition.GetProcedureWithNoEffectivePrice_Class dataset_GetProcWithNoEffectivePrice = ParentGroup.rsGroup.GetCurrentRecord<ProcedureDefinition.GetProcedureWithNoEffectivePrice_Class>(0);
                    SIRANO.CalcValue = ParentGroup.GroupCounter.ToString();
                    CODE.CalcValue = (dataset_GetProcWithNoEffectivePrice != null ? Globals.ToStringCore(dataset_GetProcWithNoEffectivePrice.Code) : "");
                    NAME.CalcValue = (dataset_GetProcWithNoEffectivePrice != null ? Globals.ToStringCore(dataset_GetProcWithNoEffectivePrice.Name) : "");
                    GROUP.CalcValue = (dataset_GetProcWithNoEffectivePrice != null ? Globals.ToStringCore(dataset_GetProcWithNoEffectivePrice.Proctreedesc) : "");
                    ACTIVEPASSIVE.CalcValue = (dataset_GetProcWithNoEffectivePrice != null ? Globals.ToStringCore(dataset_GetProcWithNoEffectivePrice.IsActive) : "");
                    return new TTReportObject[] { SIRANO,CODE,NAME,GROUP,ACTIVEPASSIVE};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    if (this.ACTIVEPASSIVE.CalcValue == "True" || this.ACTIVEPASSIVE.CalcValue == "TRUE")
                this.ACTIVEPASSIVE.CalcValue = "Aktif";
            else if (this.ACTIVEPASSIVE.CalcValue == "False" || this.ACTIVEPASSIVE.CalcValue == "FALSE")
                this.ACTIVEPASSIVE.CalcValue = "Pasif";
#endregion MAIN BODY_Script
                }
            }

        }

        public MAINGroup MAIN;

        public partial class MATPARENTGroup : TTReportGroup
        {
            public ProceduresAndMaterialsWithNoEffectivePrice MyParentReport
            {
                get { return (ProceduresAndMaterialsWithNoEffectivePrice)ParentReport; }
            }

            new public MATPARENTGroupHeader Header()
            {
                return (MATPARENTGroupHeader)_header;
            }

            new public MATPARENTGroupFooter Footer()
            {
                return (MATPARENTGroupFooter)_footer;
            }

            public TTReportField NewField111211 { get {return Header().NewField111211;} }
            public TTReportField NewField112211 { get {return Header().NewField112211;} }
            public TTReportField NewField11112111 { get {return Header().NewField11112111;} }
            public TTReportShape NewLine1111 { get {return Header().NewLine1111;} }
            public TTReportField NewField11211 { get {return Header().NewField11211;} }
            public TTReportField NewField113211 { get {return Header().NewField113211;} }
            public MATPARENTGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public MATPARENTGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new MATPARENTGroupHeader(this);
                _footer = new MATPARENTGroupFooter(this);

            }

            public partial class MATPARENTGroupHeader : TTReportSection
            {
                public ProceduresAndMaterialsWithNoEffectivePrice MyParentReport
                {
                    get { return (ProceduresAndMaterialsWithNoEffectivePrice)ParentReport; }
                }
                
                public TTReportField NewField111211;
                public TTReportField NewField112211;
                public TTReportField NewField11112111;
                public TTReportShape NewLine1111;
                public TTReportField NewField11211;
                public TTReportField NewField113211; 
                public MATPARENTGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 15;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField111211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 8, 128, 13, false);
                    NewField111211.Name = "NewField111211";
                    NewField111211.TextFont.Bold = true;
                    NewField111211.TextFont.CharSet = 162;
                    NewField111211.Value = @"Adı";

                    NewField112211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 195, 8, 210, 13, false);
                    NewField112211.Name = "NewField112211";
                    NewField112211.MultiLine = EvetHayirEnum.ehEvet;
                    NewField112211.NoClip = EvetHayirEnum.ehEvet;
                    NewField112211.WordBreak = EvetHayirEnum.ehEvet;
                    NewField112211.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField112211.TextFont.Bold = true;
                    NewField112211.TextFont.CharSet = 162;
                    NewField112211.Value = @"Aktif/Pasif";

                    NewField11112111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 130, 8, 194, 13, false);
                    NewField11112111.Name = "NewField11112111";
                    NewField11112111.TextFont.Bold = true;
                    NewField11112111.TextFont.CharSet = 162;
                    NewField11112111.Value = @"Grubu";

                    NewLine1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 14, 210, 14, false);
                    NewLine1111.Name = "NewLine1111";
                    NewLine1111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1111.DrawWidth = 2;

                    NewField11211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 19, 8, 36, 13, false);
                    NewField11211.Name = "NewField11211";
                    NewField11211.TextFont.Bold = true;
                    NewField11211.TextFont.CharSet = 162;
                    NewField11211.Value = @"Kodu";

                    NewField113211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 8, 18, 13, false);
                    NewField113211.Name = "NewField113211";
                    NewField113211.TextFont.Bold = true;
                    NewField113211.TextFont.CharSet = 162;
                    NewField113211.Value = @"Sıra No";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField111211.CalcValue = NewField111211.Value;
                    NewField112211.CalcValue = NewField112211.Value;
                    NewField11112111.CalcValue = NewField11112111.Value;
                    NewField11211.CalcValue = NewField11211.Value;
                    NewField113211.CalcValue = NewField113211.Value;
                    return new TTReportObject[] { NewField111211,NewField112211,NewField11112111,NewField11211,NewField113211};
                }
            }
            public partial class MATPARENTGroupFooter : TTReportSection
            {
                public ProceduresAndMaterialsWithNoEffectivePrice MyParentReport
                {
                    get { return (ProceduresAndMaterialsWithNoEffectivePrice)ParentReport; }
                }
                 
                public MATPARENTGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public MATPARENTGroup MATPARENT;

        public partial class MATGroup : TTReportGroup
        {
            public ProceduresAndMaterialsWithNoEffectivePrice MyParentReport
            {
                get { return (ProceduresAndMaterialsWithNoEffectivePrice)ParentReport; }
            }

            new public MATGroupBody Body()
            {
                return (MATGroupBody)_body;
            }
            public TTReportField SIRANO { get {return Body().SIRANO;} }
            public TTReportField CODE { get {return Body().CODE;} }
            public TTReportField NAME { get {return Body().NAME;} }
            public TTReportField GROUP { get {return Body().GROUP;} }
            public TTReportField ACTIVEPASSIVE { get {return Body().ACTIVEPASSIVE;} }
            public MATGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public MATGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<Material.GetMaterialWithNoEffectivePrice_Class>("GetMaterialWithNoEffectivePrice", Material.GetMaterialWithNoEffectivePrice());
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new MATGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class MATGroupBody : TTReportSection
            {
                public ProceduresAndMaterialsWithNoEffectivePrice MyParentReport
                {
                    get { return (ProceduresAndMaterialsWithNoEffectivePrice)ParentReport; }
                }
                
                public TTReportField SIRANO;
                public TTReportField CODE;
                public TTReportField NAME;
                public TTReportField GROUP;
                public TTReportField ACTIVEPASSIVE; 
                public MATGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 5;
                    RepeatCount = 0;
                    
                    SIRANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 0, 18, 5, false);
                    SIRANO.Name = "SIRANO";
                    SIRANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SIRANO.TextFont.CharSet = 162;
                    SIRANO.Value = @"{@groupcounter@}";

                    CODE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 19, 0, 36, 5, false);
                    CODE.Name = "CODE";
                    CODE.FieldType = ReportFieldTypeEnum.ftVariable;
                    CODE.TextFont.CharSet = 162;
                    CODE.Value = @"{#CODE#}";

                    NAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 0, 128, 5, false);
                    NAME.Name = "NAME";
                    NAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAME.MultiLine = EvetHayirEnum.ehEvet;
                    NAME.NoClip = EvetHayirEnum.ehEvet;
                    NAME.WordBreak = EvetHayirEnum.ehEvet;
                    NAME.ExpandTabs = EvetHayirEnum.ehEvet;
                    NAME.TextFont.CharSet = 162;
                    NAME.Value = @"{#NAME#}";

                    GROUP = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 130, 0, 194, 5, false);
                    GROUP.Name = "GROUP";
                    GROUP.FieldType = ReportFieldTypeEnum.ftVariable;
                    GROUP.MultiLine = EvetHayirEnum.ehEvet;
                    GROUP.NoClip = EvetHayirEnum.ehEvet;
                    GROUP.WordBreak = EvetHayirEnum.ehEvet;
                    GROUP.ExpandTabs = EvetHayirEnum.ehEvet;
                    GROUP.TextFont.CharSet = 162;
                    GROUP.Value = @"{#MATTREEDESC#}";

                    ACTIVEPASSIVE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 195, 0, 210, 5, false);
                    ACTIVEPASSIVE.Name = "ACTIVEPASSIVE";
                    ACTIVEPASSIVE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACTIVEPASSIVE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ACTIVEPASSIVE.TextFont.CharSet = 162;
                    ACTIVEPASSIVE.Value = @"{#ISACTIVE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Material.GetMaterialWithNoEffectivePrice_Class dataset_GetMaterialWithNoEffectivePrice = ParentGroup.rsGroup.GetCurrentRecord<Material.GetMaterialWithNoEffectivePrice_Class>(0);
                    SIRANO.CalcValue = ParentGroup.GroupCounter.ToString();
                    CODE.CalcValue = (dataset_GetMaterialWithNoEffectivePrice != null ? Globals.ToStringCore(dataset_GetMaterialWithNoEffectivePrice.Code) : "");
                    NAME.CalcValue = (dataset_GetMaterialWithNoEffectivePrice != null ? Globals.ToStringCore(dataset_GetMaterialWithNoEffectivePrice.Name) : "");
                    GROUP.CalcValue = (dataset_GetMaterialWithNoEffectivePrice != null ? Globals.ToStringCore(dataset_GetMaterialWithNoEffectivePrice.Mattreedesc) : "");
                    ACTIVEPASSIVE.CalcValue = (dataset_GetMaterialWithNoEffectivePrice != null ? Globals.ToStringCore(dataset_GetMaterialWithNoEffectivePrice.IsActive) : "");
                    return new TTReportObject[] { SIRANO,CODE,NAME,GROUP,ACTIVEPASSIVE};
                }

                public override void RunScript()
                {
#region MAT BODY_Script
                    if (this.ACTIVEPASSIVE.CalcValue == "True" || this.ACTIVEPASSIVE.CalcValue == "TRUE")
                this.ACTIVEPASSIVE.CalcValue = "Aktif";
            else if (this.ACTIVEPASSIVE.CalcValue == "False" || this.ACTIVEPASSIVE.CalcValue == "FALSE")
                this.ACTIVEPASSIVE.CalcValue = "Pasif";
#endregion MAT BODY_Script
                }
            }

        }

        public MATGroup MAT;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public ProceduresAndMaterialsWithNoEffectivePrice()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            PROC = new PROCGroup(PARTA,"PROC");
            MAIN = new MAINGroup(PROC,"MAIN");
            MATPARENT = new MATPARENTGroup(PARTA,"MATPARENT");
            MAT = new MATGroup(MATPARENT,"MAT");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            Name = "PROCEDURESANDMATERIALSWITHNOEFFECTIVEPRICE";
            Caption = "Fiyat Karşılığı Olmayan Hizmet ve Malzemeler";
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
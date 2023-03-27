
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
    /// İlaç Etkileşim Raporu
    /// </summary>
    public partial class DrugInteractionReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public DrugInteractionReport MyParentReport
            {
                get { return (DrugInteractionReport)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField REPORTNAME { get {return Header().REPORTNAME;} }
            public TTReportField LOGO { get {return Header().LOGO;} }
            public TTReportField PrintDate { get {return Footer().PrintDate;} }
            public TTReportField CURRENTUSER { get {return Footer().CURRENTUSER;} }
            public TTReportField PAGENUMBER { get {return Footer().PAGENUMBER;} }
            public TTReportShape NewLine1111 { get {return Footer().NewLine1111;} }
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
                public DrugInteractionReport MyParentReport
                {
                    get { return (DrugInteractionReport)ParentReport; }
                }
                
                public TTReportField REPORTNAME;
                public TTReportField LOGO; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 36;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    REPORTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 10, 289, 22, false);
                    REPORTNAME.Name = "REPORTNAME";
                    REPORTNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REPORTNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REPORTNAME.TextFont.Size = 15;
                    REPORTNAME.TextFont.Bold = true;
                    REPORTNAME.Value = @"İLAÇ ETKİLEŞİM RAPORU";

                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 314, 9, 354, 29, false);
                    LOGO.Name = "LOGO";
                    LOGO.Visible = EvetHayirEnum.ehHayir;
                    LOGO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    LOGO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LOGO.TextFont.CharSet = 1;
                    LOGO.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    REPORTNAME.CalcValue = REPORTNAME.Value;
                    LOGO.CalcValue = LOGO.Value;
                    return new TTReportObject[] { REPORTNAME,LOGO};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public DrugInteractionReport MyParentReport
                {
                    get { return (DrugInteractionReport)ParentReport; }
                }
                
                public TTReportField PrintDate;
                public TTReportField CURRENTUSER;
                public TTReportField PAGENUMBER;
                public TTReportShape NewLine1111; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 27;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    PrintDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 1, 34, 6, false);
                    PrintDate.Name = "PrintDate";
                    PrintDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate.TextFormat = @"dd/MM/yyyy";
                    PrintDate.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PrintDate.TextFont.Size = 8;
                    PrintDate.Value = @"{@printdate@}";

                    CURRENTUSER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 133, 1, 158, 6, false);
                    CURRENTUSER.Name = "CURRENTUSER";
                    CURRENTUSER.FieldType = ReportFieldTypeEnum.ftExpression;
                    CURRENTUSER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CURRENTUSER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CURRENTUSER.TextFont.Size = 8;
                    CURRENTUSER.Value = @"TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : """"";

                    PAGENUMBER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 264, 2, 289, 7, false);
                    PAGENUMBER.Name = "PAGENUMBER";
                    PAGENUMBER.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAGENUMBER.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PAGENUMBER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PAGENUMBER.TextFont.Size = 8;
                    PAGENUMBER.Value = @"Sayfa Nu:{@pagenumber@}/{@pagecount@}";

                    NewLine1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 1, 289, 1, false);
                    NewLine1111.Name = "NewLine1111";
                    NewLine1111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1111.DrawWidth = 2;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PrintDate.CalcValue = DateTime.Now.ToShortDateString();
                    PAGENUMBER.CalcValue = @"Sayfa Nu:" + ParentReport.CurrentPageNumber.ToString() + @"/" + ParentReport.ReportTotalPageCount;
                    CURRENTUSER.CalcValue = TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : "";
                    return new TTReportObject[] { PrintDate,PAGENUMBER,CURRENTUSER};
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class PARTBGroup : TTReportGroup
        {
            public DrugInteractionReport MyParentReport
            {
                get { return (DrugInteractionReport)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField BARCODE { get {return Header().BARCODE;} }
            public TTReportField DRUGNAME { get {return Header().DRUGNAME;} }
            public TTReportShape NewLine11111 { get {return Header().NewLine11111;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportField NewField1111 { get {return Header().NewField1111;} }
            public TTReportField NewField131 { get {return Header().NewField131;} }
            public TTReportField NewField11211 { get {return Header().NewField11211;} }
            public TTReportField NewField111211 { get {return Header().NewField111211;} }
            public TTReportField NewField1131 { get {return Header().NewField1131;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public TTReportShape NewLine111111 { get {return Header().NewLine111111;} }
            public TTReportShape NewLine11 { get {return Header().NewLine11;} }
            public TTReportShape NewLine1111111 { get {return Header().NewLine1111111;} }
            public TTReportShape NewLine111 { get {return Header().NewLine111;} }
            public TTReportShape NewLine111113 { get {return Footer().NewLine111113;} }
            public PARTBGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTBGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<DrugDefinition.GetInteractionRQ_Class>("GetInteractionRQ", DrugDefinition.GetInteractionRQ());
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTBGroupHeader(this);
                _footer = new PARTBGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class PARTBGroupHeader : TTReportSection
            {
                public DrugInteractionReport MyParentReport
                {
                    get { return (DrugInteractionReport)ParentReport; }
                }
                
                public TTReportField BARCODE;
                public TTReportField DRUGNAME;
                public TTReportShape NewLine11111;
                public TTReportField NewField11;
                public TTReportField NewField111;
                public TTReportField NewField121;
                public TTReportField NewField1111;
                public TTReportField NewField131;
                public TTReportField NewField11211;
                public TTReportField NewField111211;
                public TTReportField NewField1131;
                public TTReportShape NewLine1;
                public TTReportShape NewLine111111;
                public TTReportShape NewLine11;
                public TTReportShape NewLine1111111;
                public TTReportShape NewLine111; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 35;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    BARCODE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 9, 50, 15, false);
                    BARCODE.Name = "BARCODE";
                    BARCODE.FieldType = ReportFieldTypeEnum.ftVariable;
                    BARCODE.TextFont.Size = 11;
                    BARCODE.TextFont.Bold = true;
                    BARCODE.Value = @"{#BARCODE#}";

                    DRUGNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 56, 9, 283, 15, false);
                    DRUGNAME.Name = "DRUGNAME";
                    DRUGNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    DRUGNAME.MultiLine = EvetHayirEnum.ehEvet;
                    DRUGNAME.WordBreak = EvetHayirEnum.ehEvet;
                    DRUGNAME.ExpandTabs = EvetHayirEnum.ehEvet;
                    DRUGNAME.TextFont.Size = 11;
                    DRUGNAME.TextFont.Bold = true;
                    DRUGNAME.Value = @"{#NAME#}";

                    NewLine11111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 20, 289, 20, false);
                    NewLine11111.Name = "NewLine11111";
                    NewLine11111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11111.DrawWidth = 2;

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 125, 29, 147, 35, false);
                    NewField11.Name = "NewField11";
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Bold = true;
                    NewField11.Value = @"Seviye";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 309, 17, 378, 22, false);
                    NewField111.Name = "NewField111";
                    NewField111.Visible = EvetHayirEnum.ehHayir;
                    NewField111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111.TextFont.Bold = true;
                    NewField111.Value = @"Mesaj";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 149, 29, 263, 35, false);
                    NewField121.Name = "NewField121";
                    NewField121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121.MultiLine = EvetHayirEnum.ehEvet;
                    NewField121.WordBreak = EvetHayirEnum.ehEvet;
                    NewField121.TextFont.Bold = true;
                    NewField121.Value = @"Besin";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 21, 147, 28, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111.TextFont.Bold = true;
                    NewField1111.Value = @"İlaç İlaç Etkileşimleri";

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 148, 21, 289, 28, false);
                    NewField131.Name = "NewField131";
                    NewField131.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField131.TextFont.Bold = true;
                    NewField131.Value = @"İlaç Besin Etkileşimleri";

                    NewField11211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 266, 29, 288, 36, false);
                    NewField11211.Name = "NewField11211";
                    NewField11211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11211.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11211.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11211.TextFont.Bold = true;
                    NewField11211.Value = @"Seviye";

                    NewField111211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 304, 29, 373, 34, false);
                    NewField111211.Name = "NewField111211";
                    NewField111211.Visible = EvetHayirEnum.ehHayir;
                    NewField111211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111211.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111211.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111211.TextFont.Bold = true;
                    NewField111211.Value = @"Mesaj";

                    NewField1131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 29, 124, 35, false);
                    NewField1131.Name = "NewField1131";
                    NewField1131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1131.TextFont.Bold = true;
                    NewField1131.Value = @"İlaç";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 147, 20, 147, 36, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1.DrawWidth = 2;

                    NewLine111111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 29, 289, 29, false);
                    NewLine111111.Name = "NewLine111111";
                    NewLine111111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine111111.DrawWidth = 2;

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 20, 8, 36, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11.DrawWidth = 2;

                    NewLine1111111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 36, 289, 36, false);
                    NewLine1111111.Name = "NewLine1111111";
                    NewLine1111111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1111111.DrawWidth = 2;

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 289, 20, 289, 36, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine111.DrawWidth = 2;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DrugDefinition.GetInteractionRQ_Class dataset_GetInteractionRQ = ParentGroup.rsGroup.GetCurrentRecord<DrugDefinition.GetInteractionRQ_Class>(0);
                    BARCODE.CalcValue = (dataset_GetInteractionRQ != null ? Globals.ToStringCore(dataset_GetInteractionRQ.Barcode) : "");
                    DRUGNAME.CalcValue = (dataset_GetInteractionRQ != null ? Globals.ToStringCore(dataset_GetInteractionRQ.Name) : "");
                    NewField11.CalcValue = NewField11.Value;
                    NewField111.CalcValue = NewField111.Value;
                    NewField121.CalcValue = NewField121.Value;
                    NewField1111.CalcValue = NewField1111.Value;
                    NewField131.CalcValue = NewField131.Value;
                    NewField11211.CalcValue = NewField11211.Value;
                    NewField111211.CalcValue = NewField111211.Value;
                    NewField1131.CalcValue = NewField1131.Value;
                    return new TTReportObject[] { BARCODE,DRUGNAME,NewField11,NewField111,NewField121,NewField1111,NewField131,NewField11211,NewField111211,NewField1131};
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public DrugInteractionReport MyParentReport
                {
                    get { return (DrugInteractionReport)ParentReport; }
                }
                
                public TTReportShape NewLine111113; 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 6;
                    RepeatCount = 0;
                    
                    NewLine111113 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 0, 289, 0, false);
                    NewLine111113.Name = "NewLine111113";
                    NewLine111113.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine111113.DrawWidth = 2;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DrugDefinition.GetInteractionRQ_Class dataset_GetInteractionRQ = ParentGroup.rsGroup.GetCurrentRecord<DrugDefinition.GetInteractionRQ_Class>(0);
                    return new TTReportObject[] { };
                }
            }

        }

        public PARTBGroup PARTB;

        public partial class MAINGroup : TTReportGroup
        {
            public DrugInteractionReport MyParentReport
            {
                get { return (DrugInteractionReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField INTERACTIONDRUG { get {return Body().INTERACTIONDRUG;} }
            public TTReportField DRUGDRUGLEVEL { get {return Body().DRUGDRUGLEVEL;} }
            public TTReportField DRUGDRUGMESSAGE { get {return Body().DRUGDRUGMESSAGE;} }
            public TTReportField INTERACTIONFOOD { get {return Body().INTERACTIONFOOD;} }
            public TTReportField DRUGFOODLEVEL { get {return Body().DRUGFOODLEVEL;} }
            public TTReportField DRUGFOODMESSAGE { get {return Body().DRUGFOODMESSAGE;} }
            public TTReportShape NewLine112 { get {return Body().NewLine112;} }
            public TTReportShape NewLine1211 { get {return Body().NewLine1211;} }
            public TTReportShape NewLine1212 { get {return Body().NewLine1212;} }
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

                DrugDefinition.GetInteractionRQ_Class dataSet_GetInteractionRQ = ParentGroup.rsGroup.GetCurrentRecord<DrugDefinition.GetInteractionRQ_Class>(0);    
                return new object[] {(dataSet_GetInteractionRQ==null ? null : dataSet_GetInteractionRQ.Barcode), (dataSet_GetInteractionRQ==null ? null : dataSet_GetInteractionRQ.Name)};
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
                public DrugInteractionReport MyParentReport
                {
                    get { return (DrugInteractionReport)ParentReport; }
                }
                
                public TTReportField INTERACTIONDRUG;
                public TTReportField DRUGDRUGLEVEL;
                public TTReportField DRUGDRUGMESSAGE;
                public TTReportField INTERACTIONFOOD;
                public TTReportField DRUGFOODLEVEL;
                public TTReportField DRUGFOODMESSAGE;
                public TTReportShape NewLine112;
                public TTReportShape NewLine1211;
                public TTReportShape NewLine1212; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 7;
                    RepeatCount = 0;
                    
                    INTERACTIONDRUG = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 2, 124, 7, false);
                    INTERACTIONDRUG.Name = "INTERACTIONDRUG";
                    INTERACTIONDRUG.FieldType = ReportFieldTypeEnum.ftVariable;
                    INTERACTIONDRUG.Value = @"{#PARTB.INTERACTIONDRUG#}";

                    DRUGDRUGLEVEL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 125, 2, 147, 7, false);
                    DRUGDRUGLEVEL.Name = "DRUGDRUGLEVEL";
                    DRUGDRUGLEVEL.FieldType = ReportFieldTypeEnum.ftVariable;
                    DRUGDRUGLEVEL.ObjectDefName = "InteractionLevelTypeEnum";
                    DRUGDRUGLEVEL.DataMember = "DISPLAYTEXT";
                    DRUGDRUGLEVEL.Value = @"{#PARTB.DRUGDRUGLEVEL#}";

                    DRUGDRUGMESSAGE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 308, 37, 377, 42, false);
                    DRUGDRUGMESSAGE.Name = "DRUGDRUGMESSAGE";
                    DRUGDRUGMESSAGE.Visible = EvetHayirEnum.ehHayir;
                    DRUGDRUGMESSAGE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DRUGDRUGMESSAGE.Value = @"{#PARTB.DRUGDRUGMESSAGE#}";

                    INTERACTIONFOOD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 149, 2, 265, 7, false);
                    INTERACTIONFOOD.Name = "INTERACTIONFOOD";
                    INTERACTIONFOOD.FieldType = ReportFieldTypeEnum.ftVariable;
                    INTERACTIONFOOD.Value = @"{#PARTB.INTERACTIONFOOD#}";

                    DRUGFOODLEVEL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 266, 2, 288, 7, false);
                    DRUGFOODLEVEL.Name = "DRUGFOODLEVEL";
                    DRUGFOODLEVEL.FieldType = ReportFieldTypeEnum.ftVariable;
                    DRUGFOODLEVEL.ObjectDefName = "InteractionLevelTypeEnum";
                    DRUGFOODLEVEL.DataMember = "DISPLAYTEXT";
                    DRUGFOODLEVEL.Value = @"{#PARTB.DRUGFOODLEVEL#}";

                    DRUGFOODMESSAGE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 317, 20, 386, 25, false);
                    DRUGFOODMESSAGE.Name = "DRUGFOODMESSAGE";
                    DRUGFOODMESSAGE.Visible = EvetHayirEnum.ehHayir;
                    DRUGFOODMESSAGE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DRUGFOODMESSAGE.Value = @"{#PARTB.DRUGFOODMESSAGE#}";

                    NewLine112 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 289, 0, 289, 8, false);
                    NewLine112.Name = "NewLine112";
                    NewLine112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine112.DrawWidth = 2;

                    NewLine1211 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 0, 8, 8, false);
                    NewLine1211.Name = "NewLine1211";
                    NewLine1211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1211.DrawWidth = 2;

                    NewLine1212 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 147, 0, 147, 8, false);
                    NewLine1212.Name = "NewLine1212";
                    NewLine1212.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1212.DrawWidth = 2;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DrugDefinition.GetInteractionRQ_Class dataset_GetInteractionRQ = MyParentReport.PARTB.rsGroup.GetCurrentRecord<DrugDefinition.GetInteractionRQ_Class>(0);
                    INTERACTIONDRUG.CalcValue = (dataset_GetInteractionRQ != null ? Globals.ToStringCore(dataset_GetInteractionRQ.Interactiondrug) : "");
                    DRUGDRUGLEVEL.CalcValue = (dataset_GetInteractionRQ != null ? Globals.ToStringCore(dataset_GetInteractionRQ.Drugdruglevel) : "");
                    DRUGDRUGLEVEL.PostFieldValueCalculation();
                    DRUGDRUGMESSAGE.CalcValue = (dataset_GetInteractionRQ != null ? Globals.ToStringCore(dataset_GetInteractionRQ.Drugdrugmessage) : "");
                    INTERACTIONFOOD.CalcValue = (dataset_GetInteractionRQ != null ? Globals.ToStringCore(dataset_GetInteractionRQ.Interactionfood) : "");
                    DRUGFOODLEVEL.CalcValue = (dataset_GetInteractionRQ != null ? Globals.ToStringCore(dataset_GetInteractionRQ.Drugfoodlevel) : "");
                    DRUGFOODLEVEL.PostFieldValueCalculation();
                    DRUGFOODMESSAGE.CalcValue = (dataset_GetInteractionRQ != null ? Globals.ToStringCore(dataset_GetInteractionRQ.Drugfoodmessage) : "");
                    return new TTReportObject[] { INTERACTIONDRUG,DRUGDRUGLEVEL,DRUGDRUGMESSAGE,INTERACTIONFOOD,DRUGFOODLEVEL,DRUGFOODMESSAGE};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public DrugInteractionReport()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            PARTB = new PARTBGroup(PARTA,"PARTB");
            MAIN = new MAINGroup(PARTB,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            Name = "DRUGINTERACTIONREPORT";
            Caption = "İlaç Etkileşim Raporu";
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
            fd.TextFont.CharSet = 162;
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
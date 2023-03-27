
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
    /// 22F Onay Formu
    /// </summary>
    public partial class DirectPurchaseApprovalFormReport : TTReport
    {
#region Methods
   public int counter = 0;
   
#endregion Methods

        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class PARTHGroup : TTReportGroup
        {
            public DirectPurchaseApprovalFormReport MyParentReport
            {
                get { return (DirectPurchaseApprovalFormReport)ParentReport; }
            }

            new public PARTHGroupBody Body()
            {
                return (PARTHGroupBody)_body;
            }
            public PARTHGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTHGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<DirectPurchaseAction.DirectPurchaseApprovalFormInfotNQL_Class>("DirectPurchaseApprovalFormInfotNQL", DirectPurchaseAction.DirectPurchaseApprovalFormInfotNQL((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new PARTHGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class PARTHGroupBody : TTReportSection
            {
                public DirectPurchaseApprovalFormReport MyParentReport
                {
                    get { return (DirectPurchaseApprovalFormReport)ParentReport; }
                }
                 
                public PARTHGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 5;
                    RepeatCount = 0;
                    
                }
                

                public override void RunScript()
                {
#region PARTH BODY_Script
                    ((DirectPurchaseApprovalFormReport)ParentReport).counter++;
#endregion PARTH BODY_Script
                }
            }

        }

        public PARTHGroup PARTH;

        public partial class PARTDGroup : TTReportGroup
        {
            public DirectPurchaseApprovalFormReport MyParentReport
            {
                get { return (DirectPurchaseApprovalFormReport)ParentReport; }
            }

            new public PARTDGroupHeader Header()
            {
                return (PARTDGroupHeader)_header;
            }

            new public PARTDGroupFooter Footer()
            {
                return (PARTDGroupFooter)_footer;
            }

            public TTReportField KOORDINEAMIRI1 { get {return Footer().KOORDINEAMIRI1;} }
            public TTReportField KOORDINEAMIRIUNVAN { get {return Footer().KOORDINEAMIRIUNVAN;} }
            public TTReportField KOORDINEAMIRIRUTBE { get {return Footer().KOORDINEAMIRIRUTBE;} }
            public TTReportField LOJSMUDUNVAN1 { get {return Footer().LOJSMUDUNVAN1;} }
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
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<DirectPurchaseAction.DirectPurchaseApprovalCoordinatorInfoNQL_Class>("DirectPurchaseApprovalCoordinatorInfoNQL", DirectPurchaseAction.DirectPurchaseApprovalCoordinatorInfoNQL((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTDGroupHeader(this);
                _footer = new PARTDGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class PARTDGroupHeader : TTReportSection
            {
                public DirectPurchaseApprovalFormReport MyParentReport
                {
                    get { return (DirectPurchaseApprovalFormReport)ParentReport; }
                }
                 
                public PARTDGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 7;
                    IsVisible = EvetHayirEnum.ehHayir;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }
            public partial class PARTDGroupFooter : TTReportSection
            {
                public DirectPurchaseApprovalFormReport MyParentReport
                {
                    get { return (DirectPurchaseApprovalFormReport)ParentReport; }
                }
                
                public TTReportField KOORDINEAMIRI1;
                public TTReportField KOORDINEAMIRIUNVAN;
                public TTReportField KOORDINEAMIRIRUTBE;
                public TTReportField LOJSMUDUNVAN1; 
                public PARTDGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 31;
                    RepeatCount = 0;
                    
                    KOORDINEAMIRI1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 247, 20, 296, 25, false);
                    KOORDINEAMIRI1.Name = "KOORDINEAMIRI1";
                    KOORDINEAMIRI1.FieldType = ReportFieldTypeEnum.ftVariable;
                    KOORDINEAMIRI1.ObjectDefName = "ResUser";
                    KOORDINEAMIRI1.DataMember = "NAME";
                    KOORDINEAMIRI1.TextFont.Name = "Arial";
                    KOORDINEAMIRI1.TextFont.CharSet = 162;
                    KOORDINEAMIRI1.Value = @"{#KOORDINEAMIRI#}";

                    KOORDINEAMIRIUNVAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 299, 1, 314, 6, false);
                    KOORDINEAMIRIUNVAN.Name = "KOORDINEAMIRIUNVAN";
                    KOORDINEAMIRIUNVAN.Visible = EvetHayirEnum.ehHayir;
                    KOORDINEAMIRIUNVAN.FieldType = ReportFieldTypeEnum.ftVariable;
                    KOORDINEAMIRIUNVAN.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    KOORDINEAMIRIUNVAN.ExpandTabs = EvetHayirEnum.ehEvet;
                    KOORDINEAMIRIUNVAN.ObjectDefName = "UserTitleEnum";
                    KOORDINEAMIRIUNVAN.DataMember = "DISPLAYTEXT";
                    KOORDINEAMIRIUNVAN.TextFont.Name = "Arial";
                    KOORDINEAMIRIUNVAN.TextFont.Size = 8;
                    KOORDINEAMIRIUNVAN.TextFont.CharSet = 162;
                    KOORDINEAMIRIUNVAN.Value = @"{#KOORDINEAMIRIUNVAN#}";

                    KOORDINEAMIRIRUTBE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 299, 6, 314, 11, false);
                    KOORDINEAMIRIRUTBE.Name = "KOORDINEAMIRIRUTBE";
                    KOORDINEAMIRIRUTBE.Visible = EvetHayirEnum.ehHayir;
                    KOORDINEAMIRIRUTBE.FieldType = ReportFieldTypeEnum.ftVariable;
                    KOORDINEAMIRIRUTBE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    KOORDINEAMIRIRUTBE.ExpandTabs = EvetHayirEnum.ehEvet;
                    KOORDINEAMIRIRUTBE.ObjectDefName = "RankDefinitions";
                    KOORDINEAMIRIRUTBE.DataMember = "SHORTNAME";
                    KOORDINEAMIRIRUTBE.TextFont.Name = "Arial";
                    KOORDINEAMIRIRUTBE.TextFont.Size = 8;
                    KOORDINEAMIRIRUTBE.TextFont.CharSet = 162;
                    KOORDINEAMIRIRUTBE.Value = @"{#KOORDINEAMIRIRUTBE#}";

                    LOJSMUDUNVAN1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 247, 26, 296, 30, false);
                    LOJSMUDUNVAN1.Name = "LOJSMUDUNVAN1";
                    LOJSMUDUNVAN1.FieldType = ReportFieldTypeEnum.ftVariable;
                    LOJSMUDUNVAN1.TextFont.Name = "Arial";
                    LOJSMUDUNVAN1.TextFont.CharSet = 162;
                    LOJSMUDUNVAN1.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DirectPurchaseAction.DirectPurchaseApprovalCoordinatorInfoNQL_Class dataset_DirectPurchaseApprovalCoordinatorInfoNQL = ParentGroup.rsGroup.GetCurrentRecord<DirectPurchaseAction.DirectPurchaseApprovalCoordinatorInfoNQL_Class>(0);
                    KOORDINEAMIRI1.CalcValue = (dataset_DirectPurchaseApprovalCoordinatorInfoNQL != null ? Globals.ToStringCore(dataset_DirectPurchaseApprovalCoordinatorInfoNQL.Koordineamiri) : "");
                    KOORDINEAMIRI1.PostFieldValueCalculation();
                    KOORDINEAMIRIUNVAN.CalcValue = (dataset_DirectPurchaseApprovalCoordinatorInfoNQL != null ? Globals.ToStringCore(dataset_DirectPurchaseApprovalCoordinatorInfoNQL.Koordineamiriunvan) : "");
                    KOORDINEAMIRIUNVAN.PostFieldValueCalculation();
                    KOORDINEAMIRIRUTBE.CalcValue = (dataset_DirectPurchaseApprovalCoordinatorInfoNQL != null ? Globals.ToStringCore(dataset_DirectPurchaseApprovalCoordinatorInfoNQL.Koordineamirirutbe) : "");
                    KOORDINEAMIRIRUTBE.PostFieldValueCalculation();
                    LOJSMUDUNVAN1.CalcValue = @"";
                    return new TTReportObject[] { KOORDINEAMIRI1,KOORDINEAMIRIUNVAN,KOORDINEAMIRIRUTBE,LOJSMUDUNVAN1};
                }

                public override void RunScript()
                {
#region PARTD FOOTER_Script
                    string d = ""+ this.KOORDINEAMIRIUNVAN.CalcValue + " " + this.KOORDINEAMIRIRUTBE.CalcValue + "";
            this.LOJSMUDUNVAN1.CalcValue = d;
#endregion PARTD FOOTER_Script
                }
            }

        }

        public PARTDGroup PARTD;

        public partial class PARTAGroup : TTReportGroup
        {
            public DirectPurchaseApprovalFormReport MyParentReport
            {
                get { return (DirectPurchaseApprovalFormReport)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField ReportName11 { get {return Footer().ReportName11;} }
            public TTReportField NewField12 { get {return Footer().NewField12;} }
            public TTReportField NewField11211 { get {return Footer().NewField11211;} }
            public TTReportField NewField1221 { get {return Footer().NewField1221;} }
            public TTReportField NewField11221 { get {return Footer().NewField11221;} }
            public TTReportField NewField1111 { get {return Footer().NewField1111;} }
            public TTReportField BELGETARIHSAYI1 { get {return Footer().BELGETARIHSAYI1;} }
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
                public DirectPurchaseApprovalFormReport MyParentReport
                {
                    get { return (DirectPurchaseApprovalFormReport)ParentReport; }
                }
                 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 3;
                    IsVisible = EvetHayirEnum.ehHayir;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public DirectPurchaseApprovalFormReport MyParentReport
                {
                    get { return (DirectPurchaseApprovalFormReport)ParentReport; }
                }
                
                public TTReportField ReportName11;
                public TTReportField NewField12;
                public TTReportField NewField11211;
                public TTReportField NewField1221;
                public TTReportField NewField11221;
                public TTReportField NewField1111;
                public TTReportField BELGETARIHSAYI1; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 40;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    ReportName11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 24, 287, 30, false);
                    ReportName11.Name = "ReportName11";
                    ReportName11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ReportName11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ReportName11.TextFont.Name = "Arial";
                    ReportName11.TextFont.Bold = true;
                    ReportName11.TextFont.CharSet = 162;
                    ReportName11.Value = @"ONAY BELGESİ MALZEME LİSTESİ";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 31, 19, 40, false);
                    NewField12.Name = "NewField12";
                    NewField12.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12.MultiLine = EvetHayirEnum.ehEvet;
                    NewField12.WordBreak = EvetHayirEnum.ehEvet;
                    NewField12.TextFont.Name = "Arial";
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"Sıra No";

                    NewField11211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 19, 31, 248, 40, false);
                    NewField11211.Name = "NewField11211";
                    NewField11211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11211.TextFont.Name = "Arial";
                    NewField11211.TextFont.Bold = true;
                    NewField11211.TextFont.CharSet = 162;
                    NewField11211.Value = @"Malzemenin Adı";

                    NewField1221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 248, 31, 262, 40, false);
                    NewField1221.Name = "NewField1221";
                    NewField1221.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1221.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1221.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1221.TextFont.Name = "Arial";
                    NewField1221.TextFont.Bold = true;
                    NewField1221.TextFont.CharSet = 162;
                    NewField1221.Value = @"Miktar";

                    NewField11221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 262, 31, 287, 40, false);
                    NewField11221.Name = "NewField11221";
                    NewField11221.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11221.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11221.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11221.TextFont.Name = "Arial";
                    NewField11221.TextFont.Bold = true;
                    NewField11221.TextFont.CharSet = 162;
                    NewField11221.Value = @"Ölçü Birimi";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 269, 17, 287, 21, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111.TextFont.Name = "Arial";
                    NewField1111.TextFont.Size = 8;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @"EK-B";

                    BELGETARIHSAYI1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 17, 269, 21, false);
                    BELGETARIHSAYI1.Name = "BELGETARIHSAYI1";
                    BELGETARIHSAYI1.TextFormat = @"Short Date";
                    BELGETARIHSAYI1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BELGETARIHSAYI1.MultiLine = EvetHayirEnum.ehEvet;
                    BELGETARIHSAYI1.TextFont.Name = "Arial";
                    BELGETARIHSAYI1.TextFont.Size = 8;
                    BELGETARIHSAYI1.TextFont.CharSet = 162;
                    BELGETARIHSAYI1.Value = @" ......../......../20......          4590 - .......... - ....../...... sayılı onay belgesinin EK-B'sidir.";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ReportName11.CalcValue = ReportName11.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField11211.CalcValue = NewField11211.Value;
                    NewField1221.CalcValue = NewField1221.Value;
                    NewField11221.CalcValue = NewField11221.Value;
                    NewField1111.CalcValue = NewField1111.Value;
                    BELGETARIHSAYI1.CalcValue = BELGETARIHSAYI1.Value;
                    return new TTReportObject[] { ReportName11,NewField12,NewField11211,NewField1221,NewField11221,NewField1111,BELGETARIHSAYI1};
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class PARTBGroup : TTReportGroup
        {
            public DirectPurchaseApprovalFormReport MyParentReport
            {
                get { return (DirectPurchaseApprovalFormReport)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField NewField151 { get {return Header().NewField151;} }
            public TTReportField Onay11 { get {return Header().Onay11;} }
            public TTReportField ReportName1 { get {return Header().ReportName1;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportField XXXXXXBASLIK2 { get {return Header().XXXXXXBASLIK2;} }
            public TTReportField NewField131 { get {return Header().NewField131;} }
            public TTReportField NewField141 { get {return Header().NewField141;} }
            public TTReportField NewField1141 { get {return Header().NewField1141;} }
            public TTReportField NewField1131 { get {return Header().NewField1131;} }
            public TTReportField NewField1241 { get {return Header().NewField1241;} }
            public TTReportField NewField1121 { get {return Header().NewField1121;} }
            public TTReportField NewField11211 { get {return Header().NewField11211;} }
            public TTReportField NewField12211 { get {return Header().NewField12211;} }
            public TTReportField NewField111221 { get {return Header().NewField111221;} }
            public TTReportField NewField121221 { get {return Header().NewField121221;} }
            public TTReportField NewField1122121 { get {return Header().NewField1122121;} }
            public TTReportField NewField1222121 { get {return Header().NewField1222121;} }
            public TTReportField NewField11212221 { get {return Header().NewField11212221;} }
            public TTReportField NewField1341 { get {return Header().NewField1341;} }
            public TTReportField NewField112221211 { get {return Header().NewField112221211;} }
            public TTReportField NewField122221211 { get {return Header().NewField122221211;} }
            public TTReportField NewField132221211 { get {return Header().NewField132221211;} }
            public TTReportField NewField142221211 { get {return Header().NewField142221211;} }
            public TTReportField NewField152221211 { get {return Header().NewField152221211;} }
            public TTReportField NewField1231 { get {return Header().NewField1231;} }
            public TTReportField NewField1331 { get {return Header().NewField1331;} }
            public TTReportShape NewLine11 { get {return Header().NewLine11;} }
            public TTReportShape NewLine111 { get {return Header().NewLine111;} }
            public TTReportShape NewLine1111 { get {return Header().NewLine1111;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField13 { get {return Header().NewField13;} }
            public TTReportField NewField133 { get {return Header().NewField133;} }
            public TTReportField NewField1332 { get {return Header().NewField1332;} }
            public TTReportField NewField1333 { get {return Header().NewField1333;} }
            public TTReportField NewField1334 { get {return Header().NewField1334;} }
            public TTReportField NewField1335 { get {return Header().NewField1335;} }
            public TTReportField NewField14331 { get {return Header().NewField14331;} }
            public TTReportField TEXT { get {return Header().TEXT;} }
            public TTReportField XXXXXXBASLIK { get {return Header().XXXXXXBASLIK;} }
            public TTReportField BELGETARIHSAYI { get {return Header().BELGETARIHSAYI;} }
            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportField NewField15 { get {return Header().NewField15;} }
            public TTReportField NewField16 { get {return Header().NewField16;} }
            public TTReportField NewField17 { get {return Header().NewField17;} }
            public TTReportField NewField18 { get {return Header().NewField18;} }
            public TTReportField NewField19 { get {return Header().NewField19;} }
            public TTReportField NewField20 { get {return Header().NewField20;} }
            public TTReportField OBJECTID { get {return Header().OBJECTID;} }
            public TTReportField HASTAISIM { get {return Header().HASTAISIM;} }
            public TTReportField HASTATCNO { get {return Header().HASTATCNO;} }
            public TTReportField PATIENTSTATUS { get {return Header().PATIENTSTATUS;} }
            public TTReportField UZMANLIK { get {return Header().UZMANLIK;} }
            public TTReportField MALIYIL { get {return Header().MALIYIL;} }
            public TTReportField HASTAPROTNO { get {return Header().HASTAPROTNO;} }
            public TTReportField IHALETARIHI { get {return Header().IHALETARIHI;} }
            public TTReportField IHALENO { get {return Header().IHALENO;} }
            public TTReportField SAYMANLIK { get {return Header().SAYMANLIK;} }
            public TTReportField BUTCEHARCAMAKALEMI { get {return Header().BUTCEHARCAMAKALEMI;} }
            public TTReportField ADBILIMDALIBASKSERVISSORUM { get {return Header().ADBILIMDALIBASKSERVISSORUM;} }
            public TTReportField KOORDINEEDEN { get {return Header().KOORDINEEDEN;} }
            public TTReportField HARCAMAYETKILISI { get {return Header().HARCAMAYETKILISI;} }
            public TTReportField HASTA { get {return Header().HASTA;} }
            public TTReportField BUTCEMIDOSEMI { get {return Header().BUTCEMIDOSEMI;} }
            public TTReportField GOREVLIPERSONEL { get {return Header().GOREVLIPERSONEL;} }
            public TTReportField BUTCEDOSE { get {return Header().BUTCEDOSE;} }
            public TTReportField BUTDOS { get {return Header().BUTDOS;} }
            public TTReportField ISINTANIMI { get {return Header().ISINTANIMI;} }
            public TTReportField ISINNITELIGI { get {return Header().ISINNITELIGI;} }
            public TTReportField NewField111211 { get {return Header().NewField111211;} }
            public TTReportField NewField21 { get {return Header().NewField21;} }
            public TTReportField BUTCE { get {return Header().BUTCE;} }
            public TTReportField KOMISYON { get {return Header().KOMISYON;} }
            public TTReportField ASILBASKAN { get {return Header().ASILBASKAN;} }
            public TTReportField ASILUYE1 { get {return Header().ASILUYE1;} }
            public TTReportField ASILUYE2 { get {return Header().ASILUYE2;} }
            public TTReportField YEDEKBASKAN { get {return Header().YEDEKBASKAN;} }
            public TTReportField YEDEKUYE1 { get {return Header().YEDEKUYE1;} }
            public TTReportField YEDEKUYE2 { get {return Header().YEDEKUYE2;} }
            public TTReportField BUTDOS1 { get {return Header().BUTDOS1;} }
            public TTReportField NewField1151 { get {return Footer().NewField1151;} }
            public TTReportField Onay111 { get {return Footer().Onay111;} }
            public TTReportField NewField11321 { get {return Footer().NewField11321;} }
            public TTReportField NewField132 { get {return Footer().NewField132;} }
            public TTReportField NewField1162 { get {return Footer().NewField1162;} }
            public TTReportField NewField11612 { get {return Footer().NewField11612;} }
            public TTReportField NewField11622 { get {return Footer().NewField11622;} }
            public TTReportField NewField112612 { get {return Footer().NewField112612;} }
            public TTReportField NewField112622 { get {return Footer().NewField112622;} }
            public TTReportField NewField1171 { get {return Footer().NewField1171;} }
            public TTReportField NewField11631 { get {return Footer().NewField11631;} }
            public TTReportField NewField111611 { get {return Footer().NewField111611;} }
            public TTReportField NewField112631 { get {return Footer().NewField112631;} }
            public TTReportField NewField1116211 { get {return Footer().NewField1116211;} }
            public TTReportField NewField1126211 { get {return Footer().NewField1126211;} }
            public TTReportShape NewLine12 { get {return Footer().NewLine12;} }
            public TTReportShape NewLine13 { get {return Footer().NewLine13;} }
            public TTReportShape NewLine121 { get {return Footer().NewLine121;} }
            public TTReportField NewField3 { get {return Footer().NewField3;} }
            public TTReportField NewField14 { get {return Footer().NewField14;} }
            public TTReportField NewField122321 { get {return Footer().NewField122321;} }
            public TTReportField NewField1226111 { get {return Footer().NewField1226111;} }
            public TTReportField NewField12216111 { get {return Footer().NewField12216111;} }
            public TTReportField NewField12226111 { get {return Footer().NewField12226111;} }
            public TTReportField NewField122162111 { get {return Footer().NewField122162111;} }
            public TTReportField NewField122262111 { get {return Footer().NewField122262111;} }
            public TTReportField NewField1123211 { get {return Footer().NewField1123211;} }
            public TTReportField NewField11116211 { get {return Footer().NewField11116211;} }
            public TTReportField NewField111161211 { get {return Footer().NewField111161211;} }
            public TTReportField NewField111162211 { get {return Footer().NewField111162211;} }
            public TTReportField NewField1111261211 { get {return Footer().NewField1111261211;} }
            public TTReportField NewField1111262211 { get {return Footer().NewField1111262211;} }
            public TTReportField HARCAMAYET { get {return Footer().HARCAMAYET;} }
            public TTReportField KOORDINEAMIRI { get {return Footer().KOORDINEAMIRI;} }
            public TTReportField KOORDINEAMIRIUNVAN { get {return Footer().KOORDINEAMIRIUNVAN;} }
            public TTReportField KOORDINEAMIRIRUTBE { get {return Footer().KOORDINEAMIRIRUTBE;} }
            public TTReportField LOJSMUDUNVAN { get {return Footer().LOJSMUDUNVAN;} }
            public TTReportField HARCAMAYETUNVAN { get {return Footer().HARCAMAYETUNVAN;} }
            public TTReportField HARCAMAYETRUTBEIS { get {return Footer().HARCAMAYETRUTBEIS;} }
            public TTReportField HARCAMAYETKILISIUNVAN { get {return Footer().HARCAMAYETKILISIUNVAN;} }
            public TTReportField HARCAMAYETKILISIRUTBE { get {return Footer().HARCAMAYETKILISIRUTBE;} }
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
                list[0] = new TTReportNqlData<DirectPurchaseAction.DirectPurchaseApprovalFormReportNQL_Class>("DirectPurchaseApprovalFormReportNQL", DirectPurchaseAction.DirectPurchaseApprovalFormReportNQL((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public DirectPurchaseApprovalFormReport MyParentReport
                {
                    get { return (DirectPurchaseApprovalFormReport)ParentReport; }
                }
                
                public TTReportField NewField151;
                public TTReportField Onay11;
                public TTReportField ReportName1;
                public TTReportField NewField12;
                public TTReportField NewField121;
                public TTReportField XXXXXXBASLIK2;
                public TTReportField NewField131;
                public TTReportField NewField141;
                public TTReportField NewField1141;
                public TTReportField NewField1131;
                public TTReportField NewField1241;
                public TTReportField NewField1121;
                public TTReportField NewField11211;
                public TTReportField NewField12211;
                public TTReportField NewField111221;
                public TTReportField NewField121221;
                public TTReportField NewField1122121;
                public TTReportField NewField1222121;
                public TTReportField NewField11212221;
                public TTReportField NewField1341;
                public TTReportField NewField112221211;
                public TTReportField NewField122221211;
                public TTReportField NewField132221211;
                public TTReportField NewField142221211;
                public TTReportField NewField152221211;
                public TTReportField NewField1231;
                public TTReportField NewField1331;
                public TTReportShape NewLine11;
                public TTReportShape NewLine111;
                public TTReportShape NewLine1111;
                public TTReportField NewField1;
                public TTReportField NewField13;
                public TTReportField NewField133;
                public TTReportField NewField1332;
                public TTReportField NewField1333;
                public TTReportField NewField1334;
                public TTReportField NewField1335;
                public TTReportField NewField14331;
                public TTReportField TEXT;
                public TTReportField XXXXXXBASLIK;
                public TTReportField BELGETARIHSAYI;
                public TTReportField NewField2;
                public TTReportField NewField15;
                public TTReportField NewField16;
                public TTReportField NewField17;
                public TTReportField NewField18;
                public TTReportField NewField19;
                public TTReportField NewField20;
                public TTReportField OBJECTID;
                public TTReportField HASTAISIM;
                public TTReportField HASTATCNO;
                public TTReportField PATIENTSTATUS;
                public TTReportField UZMANLIK;
                public TTReportField MALIYIL;
                public TTReportField HASTAPROTNO;
                public TTReportField IHALETARIHI;
                public TTReportField IHALENO;
                public TTReportField SAYMANLIK;
                public TTReportField BUTCEHARCAMAKALEMI;
                public TTReportField ADBILIMDALIBASKSERVISSORUM;
                public TTReportField KOORDINEEDEN;
                public TTReportField HARCAMAYETKILISI;
                public TTReportField HASTA;
                public TTReportField BUTCEMIDOSEMI;
                public TTReportField GOREVLIPERSONEL;
                public TTReportField BUTCEDOSE;
                public TTReportField BUTDOS;
                public TTReportField ISINTANIMI;
                public TTReportField ISINNITELIGI;
                public TTReportField NewField111211;
                public TTReportField NewField21;
                public TTReportField BUTCE;
                public TTReportField KOMISYON;
                public TTReportField ASILBASKAN;
                public TTReportField ASILUYE1;
                public TTReportField ASILUYE2;
                public TTReportField YEDEKBASKAN;
                public TTReportField YEDEKUYE1;
                public TTReportField YEDEKUYE2;
                public TTReportField BUTDOS1; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 157;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 87, 110, 157, false);
                    NewField151.Name = "NewField151";
                    NewField151.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField151.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField151.MultiLine = EvetHayirEnum.ehEvet;
                    NewField151.WordBreak = EvetHayirEnum.ehEvet;
                    NewField151.TextFont.Name = "Arial";
                    NewField151.TextFont.Size = 8;
                    NewField151.TextFont.CharSet = 162;
                    NewField151.Value = @"Uygundur.

İhale Yetkilisi";

                    Onay11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 87, 60, 157, false);
                    Onay11.Name = "Onay11";
                    Onay11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    Onay11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Onay11.MultiLine = EvetHayirEnum.ehEvet;
                    Onay11.WordBreak = EvetHayirEnum.ehEvet;
                    Onay11.TextFont.Name = "Arial";
                    Onay11.TextFont.Size = 8;
                    Onay11.TextFont.CharSet = 162;
                    Onay11.Value = @"Yukarıda belirtilen malın alınması
için ihaleye çıkılması hususunu
Onaylarınıza arz ederim.
";

                    ReportName1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 5, 287, 11, false);
                    ReportName1.Name = "ReportName1";
                    ReportName1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ReportName1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ReportName1.TextFont.Name = "Arial";
                    ReportName1.TextFont.Bold = true;
                    ReportName1.TextFont.CharSet = 162;
                    ReportName1.Value = @"ONAY BELGESİ";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 11, 60, 19, false);
                    NewField12.Name = "NewField12";
                    NewField12.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12.TextFont.Name = "Arial";
                    NewField12.TextFont.Size = 8;
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"DOĞRUDAN TEMİN";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 19, 60, 27, false);
                    NewField121.Name = "NewField121";
                    NewField121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121.TextFont.Name = "Arial";
                    NewField121.TextFont.Size = 8;
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"Belge Tarih ve Sayısı";

                    XXXXXXBASLIK2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 27, 287, 31, false);
                    XXXXXXBASLIK2.Name = "XXXXXXBASLIK2";
                    XXXXXXBASLIK2.DrawStyle = DrawStyleConstants.vbSolid;
                    XXXXXXBASLIK2.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXBASLIK2.CaseFormat = CaseFormatEnum.fcUpperCase;
                    XXXXXXBASLIK2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    XXXXXXBASLIK2.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK2.TextFont.Name = "Arial";
                    XXXXXXBASLIK2.TextFont.Size = 8;
                    XXXXXXBASLIK2.TextFont.Bold = true;
                    XXXXXXBASLIK2.TextFont.CharSet = 162;
                    XXXXXXBASLIK2.Value = @"XXXXXXBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """"); ";

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 31, 110, 35, false);
                    NewField131.Name = "NewField131";
                    NewField131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField131.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField131.TextFont.Name = "Arial";
                    NewField131.TextFont.Size = 8;
                    NewField131.TextFont.Bold = true;
                    NewField131.TextFont.CharSet = 162;
                    NewField131.Value = @"DOĞRUDAN TEMİN İLE İLGİLİ BELGELER (Ön İlan Aşaması)";

                    NewField141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 35, 60, 43, false);
                    NewField141.Name = "NewField141";
                    NewField141.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField141.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField141.MultiLine = EvetHayirEnum.ehEvet;
                    NewField141.TextFont.Name = "Arial";
                    NewField141.TextFont.Size = 8;
                    NewField141.TextFont.Bold = true;
                    NewField141.TextFont.CharSet = 162;
                    NewField141.Value = @"İşin Adı, Tanımı, Niteliği";

                    NewField1141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 35, 160, 43, false);
                    NewField1141.Name = "NewField1141";
                    NewField1141.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1141.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1141.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1141.TextFont.Name = "Arial";
                    NewField1141.TextFont.Size = 8;
                    NewField1141.TextFont.Bold = true;
                    NewField1141.TextFont.CharSet = 162;
                    NewField1141.Value = @"İşin Adı, Tanımı, Niteliği";

                    NewField1131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 31, 287, 35, false);
                    NewField1131.Name = "NewField1131";
                    NewField1131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1131.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1131.TextFont.Name = "Arial";
                    NewField1131.TextFont.Size = 8;
                    NewField1131.TextFont.Bold = true;
                    NewField1131.TextFont.CharSet = 162;
                    NewField1131.Value = @"DOĞRUDAN TEMİN İLE İLGİLİ BELGELER (Ön İlan Aşaması)";

                    NewField1241 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 43, 60, 59, false);
                    NewField1241.Name = "NewField1241";
                    NewField1241.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1241.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1241.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1241.TextFont.Name = "Arial";
                    NewField1241.TextFont.Size = 8;
                    NewField1241.TextFont.Bold = true;
                    NewField1241.TextFont.CharSet = 162;
                    NewField1241.Value = @"İşin Tahmini Miktarı";

                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 59, 60, 63, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1121.TextFont.Name = "Arial";
                    NewField1121.TextFont.Size = 8;
                    NewField1121.TextFont.Bold = true;
                    NewField1121.TextFont.CharSet = 162;
                    NewField1121.Value = @"Yaklaşık Maliyeti";

                    NewField11211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 47, 160, 51, false);
                    NewField11211.Name = "NewField11211";
                    NewField11211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11211.TextFont.Name = "Arial";
                    NewField11211.TextFont.Size = 8;
                    NewField11211.TextFont.Bold = true;
                    NewField11211.TextFont.CharSet = 162;
                    NewField11211.Value = @"Yaklaşık Maliyeti";

                    NewField12211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 63, 60, 67, false);
                    NewField12211.Name = "NewField12211";
                    NewField12211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12211.TextFont.Name = "Arial";
                    NewField12211.TextFont.Size = 8;
                    NewField12211.TextFont.Bold = true;
                    NewField12211.TextFont.CharSet = 162;
                    NewField12211.Value = @"Kullanılabilir Ödenek Tutarı";

                    NewField111221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 51, 160, 55, false);
                    NewField111221.Name = "NewField111221";
                    NewField111221.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111221.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111221.TextFont.Name = "Arial";
                    NewField111221.TextFont.Size = 8;
                    NewField111221.TextFont.Bold = true;
                    NewField111221.TextFont.CharSet = 162;
                    NewField111221.Value = @"Kullanılabilir Ödenek Tutarı";

                    NewField121221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 67, 60, 71, false);
                    NewField121221.Name = "NewField121221";
                    NewField121221.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField121221.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121221.TextFont.Name = "Arial";
                    NewField121221.TextFont.Size = 8;
                    NewField121221.TextFont.Bold = true;
                    NewField121221.TextFont.CharSet = 162;
                    NewField121221.Value = @"Yatırım Proje Numarası (Varsa)";

                    NewField1122121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 55, 160, 59, false);
                    NewField1122121.Name = "NewField1122121";
                    NewField1122121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1122121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1122121.TextFont.Name = "Arial";
                    NewField1122121.TextFont.Size = 8;
                    NewField1122121.TextFont.Bold = true;
                    NewField1122121.TextFont.CharSet = 162;
                    NewField1122121.Value = @"Yatırım Proje Numarası (Varsa)";

                    NewField1222121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 71, 60, 75, false);
                    NewField1222121.Name = "NewField1222121";
                    NewField1222121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1222121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1222121.TextFont.Name = "Arial";
                    NewField1222121.TextFont.Size = 8;
                    NewField1222121.TextFont.Bold = true;
                    NewField1222121.TextFont.CharSet = 162;
                    NewField1222121.Value = @"Bütçe Tertibi (Varsa)";

                    NewField11212221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 59, 160, 63, false);
                    NewField11212221.Name = "NewField11212221";
                    NewField11212221.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11212221.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11212221.TextFont.Name = "Arial";
                    NewField11212221.TextFont.Size = 8;
                    NewField11212221.TextFont.Bold = true;
                    NewField11212221.TextFont.CharSet = 162;
                    NewField11212221.Value = @"Bütçe Tertibi (Varsa)";

                    NewField1341 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 75, 60, 83, false);
                    NewField1341.Name = "NewField1341";
                    NewField1341.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1341.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1341.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1341.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1341.TextFont.Name = "Arial";
                    NewField1341.TextFont.Size = 8;
                    NewField1341.TextFont.Bold = true;
                    NewField1341.TextFont.CharSet = 162;
                    NewField1341.Value = @"İhale Usulü ve İlanın Yılın Hangi Çeyreğinde Yayınlanacağı";

                    NewField112221211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 63, 160, 67, false);
                    NewField112221211.Name = "NewField112221211";
                    NewField112221211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112221211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112221211.TextFont.Name = "Arial";
                    NewField112221211.TextFont.Size = 8;
                    NewField112221211.TextFont.Bold = true;
                    NewField112221211.TextFont.CharSet = 162;
                    NewField112221211.Value = @"Avans Verilecekse Şartları";

                    NewField122221211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 67, 160, 71, false);
                    NewField122221211.Name = "NewField122221211";
                    NewField122221211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField122221211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField122221211.TextFont.Name = "Arial";
                    NewField122221211.TextFont.Size = 8;
                    NewField122221211.TextFont.Bold = true;
                    NewField122221211.TextFont.CharSet = 162;
                    NewField122221211.Value = @"İhale Usulü";

                    NewField132221211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 71, 160, 75, false);
                    NewField132221211.Name = "NewField132221211";
                    NewField132221211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField132221211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField132221211.TextFont.Name = "Arial";
                    NewField132221211.TextFont.Size = 8;
                    NewField132221211.TextFont.Bold = true;
                    NewField132221211.TextFont.CharSet = 162;
                    NewField132221211.Value = @"İlanın Şekli ve Adedi";

                    NewField142221211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 75, 160, 79, false);
                    NewField142221211.Name = "NewField142221211";
                    NewField142221211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField142221211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField142221211.TextFont.Name = "Arial";
                    NewField142221211.TextFont.Size = 8;
                    NewField142221211.TextFont.Bold = true;
                    NewField142221211.TextFont.CharSet = 162;
                    NewField142221211.Value = @"İhale Dökümanı Satış Bedeli";

                    NewField152221211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 79, 160, 87, false);
                    NewField152221211.Name = "NewField152221211";
                    NewField152221211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField152221211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField152221211.MultiLine = EvetHayirEnum.ehEvet;
                    NewField152221211.TextFont.Name = "Arial";
                    NewField152221211.TextFont.Size = 8;
                    NewField152221211.TextFont.Bold = true;
                    NewField152221211.TextFont.CharSet = 162;
                    NewField152221211.Value = @"Fiyat Farkı Ödenecekse Dayanağı
Bakanlar Kurulu Kararı";

                    NewField1231 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 83, 110, 87, false);
                    NewField1231.Name = "NewField1231";
                    NewField1231.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1231.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1231.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1231.TextFont.Name = "Arial";
                    NewField1231.TextFont.Size = 8;
                    NewField1231.TextFont.Bold = true;
                    NewField1231.TextFont.CharSet = 162;
                    NewField1231.Value = @"O   N   A   Y";

                    NewField1331 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 87, 287, 91, false);
                    NewField1331.Name = "NewField1331";
                    NewField1331.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1331.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1331.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1331.TextFont.Name = "Arial";
                    NewField1331.TextFont.Size = 8;
                    NewField1331.TextFont.Bold = true;
                    NewField1331.TextFont.CharSet = 162;
                    NewField1331.Value = @"DOĞRUDAN TEMİN İLE İLGİLİ DİĞER AÇIKLAMALAR";

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 87, 10, 157, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 60, 87, 60, 157, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine111.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 110, 107, 110, 153, false);
                    NewLine1111.Name = "NewLine1111";
                    NewLine1111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1111.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 47, 287, 51, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.Size = 8;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"Maliyet tespiti yapılmamıştır.";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 51, 287, 55, false);
                    NewField13.Name = "NewField13";
                    NewField13.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField13.TextFont.Name = "Arial";
                    NewField13.TextFont.Size = 8;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @"Ödeneği mevcuttur.";

                    NewField133 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 55, 287, 59, false);
                    NewField133.Name = "NewField133";
                    NewField133.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField133.TextFont.Name = "Arial";
                    NewField133.TextFont.Size = 8;
                    NewField133.TextFont.CharSet = 162;
                    NewField133.Value = @"(-)";

                    NewField1332 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 63, 287, 67, false);
                    NewField1332.Name = "NewField1332";
                    NewField1332.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1332.TextFont.Name = "Arial";
                    NewField1332.TextFont.Size = 8;
                    NewField1332.TextFont.CharSet = 162;
                    NewField1332.Value = @"Avans verilmeyecektir.";

                    NewField1333 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 67, 287, 71, false);
                    NewField1333.Name = "NewField1333";
                    NewField1333.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1333.TextFont.Name = "Arial";
                    NewField1333.TextFont.Size = 8;
                    NewField1333.TextFont.CharSet = 162;
                    NewField1333.Value = @"4734 Sayılı Kamu İhale Kanunu 22/F maddesi Doğrudan Temin Usulü.";

                    NewField1334 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 71, 287, 75, false);
                    NewField1334.Name = "NewField1334";
                    NewField1334.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1334.TextFont.Name = "Arial";
                    NewField1334.TextFont.Size = 8;
                    NewField1334.TextFont.CharSet = 162;
                    NewField1334.Value = @"İlan verilmeyecektir.";

                    NewField1335 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 75, 287, 79, false);
                    NewField1335.Name = "NewField1335";
                    NewField1335.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1335.TextFont.Name = "Arial";
                    NewField1335.TextFont.Size = 8;
                    NewField1335.TextFont.CharSet = 162;
                    NewField1335.Value = @"(-)";

                    NewField14331 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 79, 287, 87, false);
                    NewField14331.Name = "NewField14331";
                    NewField14331.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField14331.TextFont.Name = "Arial";
                    NewField14331.TextFont.Size = 8;
                    NewField14331.TextFont.CharSet = 162;
                    NewField14331.Value = @"Fiyat farkı verilmeyecektir.";

                    TEXT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 91, 287, 157, false);
                    TEXT.Name = "TEXT";
                    TEXT.DrawStyle = DrawStyleConstants.vbSolid;
                    TEXT.FieldType = ReportFieldTypeEnum.ftVariable;
                    TEXT.MultiLine = EvetHayirEnum.ehEvet;
                    TEXT.WordBreak = EvetHayirEnum.ehEvet;
                    TEXT.ExpandTabs = EvetHayirEnum.ehEvet;
                    TEXT.TextFont.Name = "Arial";
                    TEXT.TextFont.Size = 6;
                    TEXT.TextFont.CharSet = 162;
                    TEXT.Value = @"";

                    XXXXXXBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 11, 287, 19, false);
                    XXXXXXBASLIK.Name = "XXXXXXBASLIK";
                    XXXXXXBASLIK.DrawStyle = DrawStyleConstants.vbSolid;
                    XXXXXXBASLIK.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXBASLIK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    XXXXXXBASLIK.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.ExpandTabs = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.TextFont.Name = "Arial";
                    XXXXXXBASLIK.TextFont.Size = 7;
                    XXXXXXBASLIK.TextFont.Bold = true;
                    XXXXXXBASLIK.TextFont.CharSet = 162;
                    XXXXXXBASLIK.Value = @"XXXXXXBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """")+ "" BAŞTABİPLİĞİ "" + "" "" + this.UZMANLIK.CalcValue + "" "" + "" HASTAYA ÖZGÜ / ACİL MALZEME"";";

                    BELGETARIHSAYI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 19, 287, 23, false);
                    BELGETARIHSAYI.Name = "BELGETARIHSAYI";
                    BELGETARIHSAYI.DrawStyle = DrawStyleConstants.vbSolid;
                    BELGETARIHSAYI.TextFormat = @"Short Date";
                    BELGETARIHSAYI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BELGETARIHSAYI.MultiLine = EvetHayirEnum.ehEvet;
                    BELGETARIHSAYI.TextFont.Name = "Arial";
                    BELGETARIHSAYI.TextFont.Size = 8;
                    BELGETARIHSAYI.TextFont.CharSet = 162;
                    BELGETARIHSAYI.Value = @" ......../......../20......          4590 - .......... - ....../......";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 35, 110, 43, false);
                    NewField2.Name = "NewField2";
                    NewField2.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField2.TextFont.Name = "Arial";
                    NewField2.TextFont.Size = 8;
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @"";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 43, 110, 59, false);
                    NewField15.Name = "NewField15";
                    NewField15.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField15.TextFont.Name = "Arial";
                    NewField15.TextFont.Size = 8;
                    NewField15.TextFont.CharSet = 162;
                    NewField15.Value = @"";

                    NewField16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 59, 110, 63, false);
                    NewField16.Name = "NewField16";
                    NewField16.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField16.TextFont.Name = "Arial";
                    NewField16.TextFont.Size = 8;
                    NewField16.TextFont.CharSet = 162;
                    NewField16.Value = @"";

                    NewField17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 63, 110, 67, false);
                    NewField17.Name = "NewField17";
                    NewField17.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField17.TextFont.Name = "Arial";
                    NewField17.TextFont.Size = 8;
                    NewField17.TextFont.CharSet = 162;
                    NewField17.Value = @"";

                    NewField18 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 67, 110, 71, false);
                    NewField18.Name = "NewField18";
                    NewField18.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField18.TextFont.Name = "Arial";
                    NewField18.TextFont.Size = 8;
                    NewField18.TextFont.CharSet = 162;
                    NewField18.Value = @"";

                    NewField19 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 71, 110, 75, false);
                    NewField19.Name = "NewField19";
                    NewField19.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField19.TextFont.Name = "Arial";
                    NewField19.TextFont.Size = 8;
                    NewField19.TextFont.CharSet = 162;
                    NewField19.Value = @"";

                    NewField20 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 75, 110, 83, false);
                    NewField20.Name = "NewField20";
                    NewField20.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField20.TextFont.Name = "Arial";
                    NewField20.TextFont.Size = 8;
                    NewField20.TextFont.CharSet = 162;
                    NewField20.Value = @"";

                    OBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 298, 1, 323, 6, false);
                    OBJECTID.Name = "OBJECTID";
                    OBJECTID.Visible = EvetHayirEnum.ehHayir;
                    OBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBJECTID.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    OBJECTID.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OBJECTID.TextFont.Name = "Arial";
                    OBJECTID.TextFont.Size = 8;
                    OBJECTID.TextFont.CharSet = 162;
                    OBJECTID.Value = @"{#OBJECTID#}";

                    HASTAISIM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 298, 7, 323, 12, false);
                    HASTAISIM.Name = "HASTAISIM";
                    HASTAISIM.Visible = EvetHayirEnum.ehHayir;
                    HASTAISIM.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTAISIM.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HASTAISIM.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HASTAISIM.TextFont.Name = "Arial";
                    HASTAISIM.TextFont.Size = 8;
                    HASTAISIM.TextFont.CharSet = 162;
                    HASTAISIM.Value = @"{#HASTAADI#} {#HASTASOYADI#}";

                    HASTATCNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 298, 13, 323, 18, false);
                    HASTATCNO.Name = "HASTATCNO";
                    HASTATCNO.Visible = EvetHayirEnum.ehHayir;
                    HASTATCNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTATCNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HASTATCNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HASTATCNO.TextFont.Name = "Arial";
                    HASTATCNO.TextFont.Size = 8;
                    HASTATCNO.TextFont.CharSet = 162;
                    HASTATCNO.Value = @"{#HASTATCNO#}";

                    PATIENTSTATUS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 298, 19, 323, 24, false);
                    PATIENTSTATUS.Name = "PATIENTSTATUS";
                    PATIENTSTATUS.Visible = EvetHayirEnum.ehHayir;
                    PATIENTSTATUS.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATIENTSTATUS.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PATIENTSTATUS.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PATIENTSTATUS.ObjectDefName = "PatientGroupEnum";
                    PATIENTSTATUS.DataMember = "DISPLAYTEXT";
                    PATIENTSTATUS.TextFont.Name = "Arial";
                    PATIENTSTATUS.TextFont.Size = 8;
                    PATIENTSTATUS.TextFont.CharSet = 162;
                    PATIENTSTATUS.Value = @"{#PATIENTSTATUS#}";

                    UZMANLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 298, 25, 323, 30, false);
                    UZMANLIK.Name = "UZMANLIK";
                    UZMANLIK.Visible = EvetHayirEnum.ehHayir;
                    UZMANLIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    UZMANLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    UZMANLIK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    UZMANLIK.TextFont.Name = "Arial";
                    UZMANLIK.TextFont.Size = 8;
                    UZMANLIK.TextFont.CharSet = 162;
                    UZMANLIK.Value = @"{#UZMANLIK#}";

                    MALIYIL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 298, 31, 323, 36, false);
                    MALIYIL.Name = "MALIYIL";
                    MALIYIL.Visible = EvetHayirEnum.ehHayir;
                    MALIYIL.FieldType = ReportFieldTypeEnum.ftVariable;
                    MALIYIL.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MALIYIL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MALIYIL.TextFont.Name = "Arial";
                    MALIYIL.TextFont.Size = 8;
                    MALIYIL.TextFont.CharSet = 162;
                    MALIYIL.Value = @"{#MALIYIL#}";

                    HASTAPROTNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 298, 37, 323, 42, false);
                    HASTAPROTNO.Name = "HASTAPROTNO";
                    HASTAPROTNO.Visible = EvetHayirEnum.ehHayir;
                    HASTAPROTNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTAPROTNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HASTAPROTNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HASTAPROTNO.TextFont.Name = "Arial";
                    HASTAPROTNO.TextFont.Size = 8;
                    HASTAPROTNO.TextFont.CharSet = 162;
                    HASTAPROTNO.Value = @"{#HASTAPROTNO#}";

                    IHALETARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 298, 43, 323, 48, false);
                    IHALETARIHI.Name = "IHALETARIHI";
                    IHALETARIHI.Visible = EvetHayirEnum.ehHayir;
                    IHALETARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    IHALETARIHI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    IHALETARIHI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    IHALETARIHI.TextFont.Name = "Arial";
                    IHALETARIHI.TextFont.Size = 8;
                    IHALETARIHI.TextFont.CharSet = 162;
                    IHALETARIHI.Value = @"{#IHALETARIHI#}";

                    IHALENO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 298, 49, 323, 54, false);
                    IHALENO.Name = "IHALENO";
                    IHALENO.Visible = EvetHayirEnum.ehHayir;
                    IHALENO.FieldType = ReportFieldTypeEnum.ftVariable;
                    IHALENO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    IHALENO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    IHALENO.TextFont.Name = "Arial";
                    IHALENO.TextFont.Size = 8;
                    IHALENO.TextFont.CharSet = 162;
                    IHALENO.Value = @"{#IHALENO#}";

                    SAYMANLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 298, 55, 323, 60, false);
                    SAYMANLIK.Name = "SAYMANLIK";
                    SAYMANLIK.Visible = EvetHayirEnum.ehHayir;
                    SAYMANLIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    SAYMANLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SAYMANLIK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SAYMANLIK.ObjectDefName = "PaymentAccountancy";
                    SAYMANLIK.DataMember = "NAME";
                    SAYMANLIK.TextFont.Name = "Arial";
                    SAYMANLIK.TextFont.Size = 8;
                    SAYMANLIK.TextFont.CharSet = 162;
                    SAYMANLIK.Value = @"{#SAYMANLIK#}";

                    BUTCEHARCAMAKALEMI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 298, 61, 323, 66, false);
                    BUTCEHARCAMAKALEMI.Name = "BUTCEHARCAMAKALEMI";
                    BUTCEHARCAMAKALEMI.Visible = EvetHayirEnum.ehHayir;
                    BUTCEHARCAMAKALEMI.FieldType = ReportFieldTypeEnum.ftVariable;
                    BUTCEHARCAMAKALEMI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BUTCEHARCAMAKALEMI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BUTCEHARCAMAKALEMI.TextFont.Name = "Arial";
                    BUTCEHARCAMAKALEMI.TextFont.Size = 8;
                    BUTCEHARCAMAKALEMI.TextFont.CharSet = 162;
                    BUTCEHARCAMAKALEMI.Value = @"{#BUTCEHARCAMAKALEMI#}";

                    ADBILIMDALIBASKSERVISSORUM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 298, 67, 323, 72, false);
                    ADBILIMDALIBASKSERVISSORUM.Name = "ADBILIMDALIBASKSERVISSORUM";
                    ADBILIMDALIBASKSERVISSORUM.Visible = EvetHayirEnum.ehHayir;
                    ADBILIMDALIBASKSERVISSORUM.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADBILIMDALIBASKSERVISSORUM.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ADBILIMDALIBASKSERVISSORUM.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ADBILIMDALIBASKSERVISSORUM.TextFont.Name = "Arial";
                    ADBILIMDALIBASKSERVISSORUM.TextFont.Size = 8;
                    ADBILIMDALIBASKSERVISSORUM.TextFont.CharSet = 162;
                    ADBILIMDALIBASKSERVISSORUM.Value = @"{#ADBILIMDALIBASKSERVISSORUM#}";

                    KOORDINEEDEN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 298, 73, 323, 78, false);
                    KOORDINEEDEN.Name = "KOORDINEEDEN";
                    KOORDINEEDEN.Visible = EvetHayirEnum.ehHayir;
                    KOORDINEEDEN.FieldType = ReportFieldTypeEnum.ftVariable;
                    KOORDINEEDEN.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    KOORDINEEDEN.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    KOORDINEEDEN.TextFont.Name = "Arial";
                    KOORDINEEDEN.TextFont.Size = 8;
                    KOORDINEEDEN.TextFont.CharSet = 162;
                    KOORDINEEDEN.Value = @"{#KOORDINEEDEN#}";

                    HARCAMAYETKILISI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 298, 85, 323, 90, false);
                    HARCAMAYETKILISI.Name = "HARCAMAYETKILISI";
                    HARCAMAYETKILISI.Visible = EvetHayirEnum.ehHayir;
                    HARCAMAYETKILISI.FieldType = ReportFieldTypeEnum.ftVariable;
                    HARCAMAYETKILISI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HARCAMAYETKILISI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HARCAMAYETKILISI.TextFont.Name = "Arial";
                    HARCAMAYETKILISI.TextFont.Size = 8;
                    HARCAMAYETKILISI.TextFont.CharSet = 162;
                    HARCAMAYETKILISI.Value = @"{#HARCAMAYETKILISI#}";

                    HASTA = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 298, 91, 323, 96, false);
                    HASTA.Name = "HASTA";
                    HASTA.Visible = EvetHayirEnum.ehHayir;
                    HASTA.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTA.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HASTA.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HASTA.TextFont.Name = "Arial";
                    HASTA.TextFont.Size = 8;
                    HASTA.TextFont.CharSet = 162;
                    HASTA.Value = @"{#HASTA#}";

                    BUTCEMIDOSEMI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 298, 79, 323, 84, false);
                    BUTCEMIDOSEMI.Name = "BUTCEMIDOSEMI";
                    BUTCEMIDOSEMI.Visible = EvetHayirEnum.ehHayir;
                    BUTCEMIDOSEMI.FieldType = ReportFieldTypeEnum.ftVariable;
                    BUTCEMIDOSEMI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BUTCEMIDOSEMI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BUTCEMIDOSEMI.ObjectDefName = "ProcurementEnum";
                    BUTCEMIDOSEMI.DataMember = "DISPLAYTEXT";
                    BUTCEMIDOSEMI.TextFont.Name = "Arial";
                    BUTCEMIDOSEMI.TextFont.Size = 8;
                    BUTCEMIDOSEMI.TextFont.CharSet = 162;
                    BUTCEMIDOSEMI.Value = @"{#BUTCEMIDOSEMI#}";

                    GOREVLIPERSONEL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 298, 97, 323, 102, false);
                    GOREVLIPERSONEL.Name = "GOREVLIPERSONEL";
                    GOREVLIPERSONEL.Visible = EvetHayirEnum.ehHayir;
                    GOREVLIPERSONEL.FieldType = ReportFieldTypeEnum.ftVariable;
                    GOREVLIPERSONEL.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    GOREVLIPERSONEL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    GOREVLIPERSONEL.TextFont.Name = "Arial";
                    GOREVLIPERSONEL.TextFont.Size = 8;
                    GOREVLIPERSONEL.TextFont.CharSet = 162;
                    GOREVLIPERSONEL.Value = @"{#GOREVLIPERSONEL#}";

                    BUTCEDOSE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 23, 110, 27, false);
                    BUTCEDOSE.Name = "BUTCEDOSE";
                    BUTCEDOSE.DrawStyle = DrawStyleConstants.vbSolid;
                    BUTCEDOSE.FieldType = ReportFieldTypeEnum.ftVariable;
                    BUTCEDOSE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BUTCEDOSE.MultiLine = EvetHayirEnum.ehEvet;
                    BUTCEDOSE.TextFont.Name = "Arial";
                    BUTCEDOSE.TextFont.Size = 8;
                    BUTCEDOSE.TextFont.CharSet = 162;
                    BUTCEDOSE.Value = @"";

                    BUTDOS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 59, 287, 63, false);
                    BUTDOS.Name = "BUTDOS";
                    BUTDOS.DrawStyle = DrawStyleConstants.vbSolid;
                    BUTDOS.FieldType = ReportFieldTypeEnum.ftVariable;
                    BUTDOS.ObjectDefName = "ProcurementEnum";
                    BUTDOS.DataMember = "DISPLAYTEXT";
                    BUTDOS.TextFont.Name = "Arial";
                    BUTDOS.TextFont.Size = 8;
                    BUTDOS.TextFont.CharSet = 162;
                    BUTDOS.Value = @"{#BUTCEMIDOSEMI#}";

                    ISINTANIMI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 35, 287, 39, false);
                    ISINTANIMI.Name = "ISINTANIMI";
                    ISINTANIMI.DrawStyle = DrawStyleConstants.vbSolid;
                    ISINTANIMI.MultiLine = EvetHayirEnum.ehEvet;
                    ISINTANIMI.ExpandTabs = EvetHayirEnum.ehEvet;
                    ISINTANIMI.TextFont.Name = "Arial";
                    ISINTANIMI.TextFont.Size = 8;
                    ISINTANIMI.TextFont.CharSet = 162;
                    ISINTANIMI.Value = @"Tıbbi Sarf Malzeme ve İlaç Alımı
";

                    ISINNITELIGI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 39, 287, 43, false);
                    ISINNITELIGI.Name = "ISINNITELIGI";
                    ISINNITELIGI.DrawStyle = DrawStyleConstants.vbSolid;
                    ISINNITELIGI.FieldType = ReportFieldTypeEnum.ftVariable;
                    ISINNITELIGI.MultiLine = EvetHayirEnum.ehEvet;
                    ISINNITELIGI.ExpandTabs = EvetHayirEnum.ehEvet;
                    ISINNITELIGI.TextFont.Name = "Arial";
                    ISINNITELIGI.TextFont.Size = 8;
                    ISINNITELIGI.TextFont.CharSet = 162;
                    ISINNITELIGI.Value = @"";

                    NewField111211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 43, 160, 47, false);
                    NewField111211.Name = "NewField111211";
                    NewField111211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111211.TextFont.Name = "Arial";
                    NewField111211.TextFont.Size = 8;
                    NewField111211.TextFont.Bold = true;
                    NewField111211.TextFont.CharSet = 162;
                    NewField111211.Value = @"İşin Miktarı";

                    NewField21 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 43, 287, 47, false);
                    NewField21.Name = "NewField21";
                    NewField21.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField21.TextFont.Name = "Arial";
                    NewField21.TextFont.Size = 8;
                    NewField21.TextFont.CharSet = 162;
                    NewField21.Value = @"EK-B Malzeme Listesinde sunulmuştur.";

                    BUTCE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 59, 212, 63, false);
                    BUTCE.Name = "BUTCE";
                    BUTCE.DrawStyle = DrawStyleConstants.vbSolid;
                    BUTCE.FieldType = ReportFieldTypeEnum.ftVariable;
                    BUTCE.ObjectDefName = "ProcurementEnum";
                    BUTCE.DataMember = "DISPLAYTEXT";
                    BUTCE.TextFont.Name = "Arial";
                    BUTCE.TextFont.Size = 8;
                    BUTCE.TextFont.CharSet = 162;
                    BUTCE.Value = @"";

                    KOMISYON = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 298, 111, 323, 116, false);
                    KOMISYON.Name = "KOMISYON";
                    KOMISYON.Visible = EvetHayirEnum.ehHayir;
                    KOMISYON.FieldType = ReportFieldTypeEnum.ftVariable;
                    KOMISYON.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    KOMISYON.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    KOMISYON.Value = @"";

                    ASILBASKAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 298, 121, 323, 126, false);
                    ASILBASKAN.Name = "ASILBASKAN";
                    ASILBASKAN.Visible = EvetHayirEnum.ehHayir;
                    ASILBASKAN.FieldType = ReportFieldTypeEnum.ftVariable;
                    ASILBASKAN.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ASILBASKAN.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ASILBASKAN.Value = @"";

                    ASILUYE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 298, 127, 323, 132, false);
                    ASILUYE1.Name = "ASILUYE1";
                    ASILUYE1.Visible = EvetHayirEnum.ehHayir;
                    ASILUYE1.FieldType = ReportFieldTypeEnum.ftVariable;
                    ASILUYE1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ASILUYE1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ASILUYE1.Value = @"";

                    ASILUYE2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 298, 133, 323, 138, false);
                    ASILUYE2.Name = "ASILUYE2";
                    ASILUYE2.Visible = EvetHayirEnum.ehHayir;
                    ASILUYE2.FieldType = ReportFieldTypeEnum.ftVariable;
                    ASILUYE2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ASILUYE2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ASILUYE2.Value = @"";

                    YEDEKBASKAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 298, 139, 323, 144, false);
                    YEDEKBASKAN.Name = "YEDEKBASKAN";
                    YEDEKBASKAN.Visible = EvetHayirEnum.ehHayir;
                    YEDEKBASKAN.FieldType = ReportFieldTypeEnum.ftVariable;
                    YEDEKBASKAN.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    YEDEKBASKAN.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    YEDEKBASKAN.Value = @"";

                    YEDEKUYE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 298, 145, 323, 150, false);
                    YEDEKUYE1.Name = "YEDEKUYE1";
                    YEDEKUYE1.Visible = EvetHayirEnum.ehHayir;
                    YEDEKUYE1.FieldType = ReportFieldTypeEnum.ftVariable;
                    YEDEKUYE1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    YEDEKUYE1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    YEDEKUYE1.Value = @"";

                    YEDEKUYE2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 298, 151, 323, 156, false);
                    YEDEKUYE2.Name = "YEDEKUYE2";
                    YEDEKUYE2.Visible = EvetHayirEnum.ehHayir;
                    YEDEKUYE2.FieldType = ReportFieldTypeEnum.ftVariable;
                    YEDEKUYE2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    YEDEKUYE2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    YEDEKUYE2.Value = @"";

                    BUTDOS1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 23, 287, 27, false);
                    BUTDOS1.Name = "BUTDOS1";
                    BUTDOS1.DrawStyle = DrawStyleConstants.vbSolid;
                    BUTDOS1.FieldType = ReportFieldTypeEnum.ftVariable;
                    BUTDOS1.ObjectDefName = "ProcurementEnum";
                    BUTDOS1.DataMember = "DISPLAYTEXT";
                    BUTDOS1.TextFont.Name = "Arial";
                    BUTDOS1.TextFont.Size = 8;
                    BUTDOS1.TextFont.CharSet = 162;
                    BUTDOS1.Value = @"{#BUTCEMIDOSEMI#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DirectPurchaseAction.DirectPurchaseApprovalFormReportNQL_Class dataset_DirectPurchaseApprovalFormReportNQL = ParentGroup.rsGroup.GetCurrentRecord<DirectPurchaseAction.DirectPurchaseApprovalFormReportNQL_Class>(0);
                    NewField151.CalcValue = NewField151.Value;
                    Onay11.CalcValue = Onay11.Value;
                    ReportName1.CalcValue = ReportName1.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField121.CalcValue = NewField121.Value;
                    NewField131.CalcValue = NewField131.Value;
                    NewField141.CalcValue = NewField141.Value;
                    NewField1141.CalcValue = NewField1141.Value;
                    NewField1131.CalcValue = NewField1131.Value;
                    NewField1241.CalcValue = NewField1241.Value;
                    NewField1121.CalcValue = NewField1121.Value;
                    NewField11211.CalcValue = NewField11211.Value;
                    NewField12211.CalcValue = NewField12211.Value;
                    NewField111221.CalcValue = NewField111221.Value;
                    NewField121221.CalcValue = NewField121221.Value;
                    NewField1122121.CalcValue = NewField1122121.Value;
                    NewField1222121.CalcValue = NewField1222121.Value;
                    NewField11212221.CalcValue = NewField11212221.Value;
                    NewField1341.CalcValue = NewField1341.Value;
                    NewField112221211.CalcValue = NewField112221211.Value;
                    NewField122221211.CalcValue = NewField122221211.Value;
                    NewField132221211.CalcValue = NewField132221211.Value;
                    NewField142221211.CalcValue = NewField142221211.Value;
                    NewField152221211.CalcValue = NewField152221211.Value;
                    NewField1231.CalcValue = NewField1231.Value;
                    NewField1331.CalcValue = NewField1331.Value;
                    NewField1.CalcValue = NewField1.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField133.CalcValue = NewField133.Value;
                    NewField1332.CalcValue = NewField1332.Value;
                    NewField1333.CalcValue = NewField1333.Value;
                    NewField1334.CalcValue = NewField1334.Value;
                    NewField1335.CalcValue = NewField1335.Value;
                    NewField14331.CalcValue = NewField14331.Value;
                    TEXT.CalcValue = @"";
                    BELGETARIHSAYI.CalcValue = BELGETARIHSAYI.Value;
                    NewField2.CalcValue = NewField2.Value;
                    NewField15.CalcValue = NewField15.Value;
                    NewField16.CalcValue = NewField16.Value;
                    NewField17.CalcValue = NewField17.Value;
                    NewField18.CalcValue = NewField18.Value;
                    NewField19.CalcValue = NewField19.Value;
                    NewField20.CalcValue = NewField20.Value;
                    OBJECTID.CalcValue = (dataset_DirectPurchaseApprovalFormReportNQL != null ? Globals.ToStringCore(dataset_DirectPurchaseApprovalFormReportNQL.ObjectID) : "");
                    HASTAISIM.CalcValue = (dataset_DirectPurchaseApprovalFormReportNQL != null ? Globals.ToStringCore(dataset_DirectPurchaseApprovalFormReportNQL.Hastaadi) : "") + @" " + (dataset_DirectPurchaseApprovalFormReportNQL != null ? Globals.ToStringCore(dataset_DirectPurchaseApprovalFormReportNQL.Hastasoyadi) : "");
                    HASTATCNO.CalcValue = (dataset_DirectPurchaseApprovalFormReportNQL != null ? Globals.ToStringCore(dataset_DirectPurchaseApprovalFormReportNQL.Hastatcno) : "");
                    PATIENTSTATUS.CalcValue = (dataset_DirectPurchaseApprovalFormReportNQL != null ? Globals.ToStringCore(dataset_DirectPurchaseApprovalFormReportNQL.Patientstatus) : "");
                    PATIENTSTATUS.PostFieldValueCalculation();
                    UZMANLIK.CalcValue = (dataset_DirectPurchaseApprovalFormReportNQL != null ? Globals.ToStringCore(dataset_DirectPurchaseApprovalFormReportNQL.Uzmanlik) : "");
                    MALIYIL.CalcValue = (dataset_DirectPurchaseApprovalFormReportNQL != null ? Globals.ToStringCore(dataset_DirectPurchaseApprovalFormReportNQL.Maliyil) : "");
                    HASTAPROTNO.CalcValue = (dataset_DirectPurchaseApprovalFormReportNQL != null ? Globals.ToStringCore(dataset_DirectPurchaseApprovalFormReportNQL.Hastaprotno) : "");
                    IHALETARIHI.CalcValue = (dataset_DirectPurchaseApprovalFormReportNQL != null ? Globals.ToStringCore(dataset_DirectPurchaseApprovalFormReportNQL.Ihaletarihi) : "");
                    IHALENO.CalcValue = (dataset_DirectPurchaseApprovalFormReportNQL != null ? Globals.ToStringCore(dataset_DirectPurchaseApprovalFormReportNQL.Ihaleno) : "");
                    SAYMANLIK.CalcValue = (dataset_DirectPurchaseApprovalFormReportNQL != null ? Globals.ToStringCore(dataset_DirectPurchaseApprovalFormReportNQL.Saymanlik) : "");
                    SAYMANLIK.PostFieldValueCalculation();
                    BUTCEHARCAMAKALEMI.CalcValue = (dataset_DirectPurchaseApprovalFormReportNQL != null ? Globals.ToStringCore(dataset_DirectPurchaseApprovalFormReportNQL.Butceharcamakalemi) : "");
                    ADBILIMDALIBASKSERVISSORUM.CalcValue = (dataset_DirectPurchaseApprovalFormReportNQL != null ? Globals.ToStringCore(dataset_DirectPurchaseApprovalFormReportNQL.Adbilimdalibaskservissorum) : "");
                    KOORDINEEDEN.CalcValue = (dataset_DirectPurchaseApprovalFormReportNQL != null ? Globals.ToStringCore(dataset_DirectPurchaseApprovalFormReportNQL.Koordineeden) : "");
                    HARCAMAYETKILISI.CalcValue = (dataset_DirectPurchaseApprovalFormReportNQL != null ? Globals.ToStringCore(dataset_DirectPurchaseApprovalFormReportNQL.Harcamayetkilisi) : "");
                    HASTA.CalcValue = (dataset_DirectPurchaseApprovalFormReportNQL != null ? Globals.ToStringCore(dataset_DirectPurchaseApprovalFormReportNQL.Hasta) : "");
                    BUTCEMIDOSEMI.CalcValue = (dataset_DirectPurchaseApprovalFormReportNQL != null ? Globals.ToStringCore(dataset_DirectPurchaseApprovalFormReportNQL.Butcemidosemi) : "");
                    BUTCEMIDOSEMI.PostFieldValueCalculation();
                    GOREVLIPERSONEL.CalcValue = (dataset_DirectPurchaseApprovalFormReportNQL != null ? Globals.ToStringCore(dataset_DirectPurchaseApprovalFormReportNQL.Gorevlipersonel) : "");
                    BUTCEDOSE.CalcValue = @"";
                    BUTDOS.CalcValue = (dataset_DirectPurchaseApprovalFormReportNQL != null ? Globals.ToStringCore(dataset_DirectPurchaseApprovalFormReportNQL.Butcemidosemi) : "");
                    BUTDOS.PostFieldValueCalculation();
                    ISINTANIMI.CalcValue = ISINTANIMI.Value;
                    ISINNITELIGI.CalcValue = @"";
                    NewField111211.CalcValue = NewField111211.Value;
                    NewField21.CalcValue = NewField21.Value;
                    BUTCE.CalcValue = @"";
                    BUTCE.PostFieldValueCalculation();
                    KOMISYON.CalcValue = @"";
                    ASILBASKAN.CalcValue = @"";
                    ASILUYE1.CalcValue = @"";
                    ASILUYE2.CalcValue = @"";
                    YEDEKBASKAN.CalcValue = @"";
                    YEDEKUYE1.CalcValue = @"";
                    YEDEKUYE2.CalcValue = @"";
                    BUTDOS1.CalcValue = (dataset_DirectPurchaseApprovalFormReportNQL != null ? Globals.ToStringCore(dataset_DirectPurchaseApprovalFormReportNQL.Butcemidosemi) : "");
                    BUTDOS1.PostFieldValueCalculation();
                    XXXXXXBASLIK2.CalcValue = XXXXXXBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", ""); ;
                    XXXXXXBASLIK.CalcValue = XXXXXXBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "")+ " BAŞTABİPLİĞİ " + " " + this.UZMANLIK.CalcValue + " " + " HASTAYA ÖZGÜ / ACİL MALZEME";;
                    return new TTReportObject[] { NewField151,Onay11,ReportName1,NewField12,NewField121,NewField131,NewField141,NewField1141,NewField1131,NewField1241,NewField1121,NewField11211,NewField12211,NewField111221,NewField121221,NewField1122121,NewField1222121,NewField11212221,NewField1341,NewField112221211,NewField122221211,NewField132221211,NewField142221211,NewField152221211,NewField1231,NewField1331,NewField1,NewField13,NewField133,NewField1332,NewField1333,NewField1334,NewField1335,NewField14331,TEXT,BELGETARIHSAYI,NewField2,NewField15,NewField16,NewField17,NewField18,NewField19,NewField20,OBJECTID,HASTAISIM,HASTATCNO,PATIENTSTATUS,UZMANLIK,MALIYIL,HASTAPROTNO,IHALETARIHI,IHALENO,SAYMANLIK,BUTCEHARCAMAKALEMI,ADBILIMDALIBASKSERVISSORUM,KOORDINEEDEN,HARCAMAYETKILISI,HASTA,BUTCEMIDOSEMI,GOREVLIPERSONEL,BUTCEDOSE,BUTDOS,ISINTANIMI,ISINNITELIGI,NewField111211,NewField21,BUTCE,KOMISYON,ASILBASKAN,ASILUYE1,ASILUYE2,YEDEKBASKAN,YEDEKUYE1,YEDEKUYE2,BUTDOS1,XXXXXXBASLIK2,XXXXXXBASLIK};
                }
                public override void RunPreScript()
                {
#region PARTB HEADER_PreScript
                    //                                                            
//            TTObjectContext context = new TTObjectContext(true);
//            string objectID = ((OnayBelgesiRaporuIhale)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
//            PurchaseProject purchaseProject = (PurchaseProject)context.GetObject(new Guid(objectID), typeof(PurchaseProject));
//            if(purchaseProject.ApproveFormDescription != null)
//                this.ExplanationRTF.Value = purchaseProject.ApproveFormDescription.ToString();
#endregion PARTB HEADER_PreScript
                }

                public override void RunScript()
                {
#region PARTB HEADER_Script
                    //            if (Advanced.CalcValue == "False")
            //                AdvancedCondition.CalcValue = "AVANS VERİLMEYECEKTİR.";
            //
            //            if (PriceDifference.CalcValue == "False")
            //                PriceDifferenceCondition.CalcValue = "FİYAT FARKI VERİLMEYECEKTİR.";
            //            else
            //                PriceDifferenceCondition.CalcValue = "FİYAT FARKI VERİLECEKTİR.";

            
            
            //      *****KOMISYON KARISIK SEKILDE GELDIGI ICIN, ASIL BASKAN, ASIL UYELER, YEDEK BASKAN, YEDEK UYELER SEKLINDE AYRI AYRI YAZDIRMA TALEBI ILE DUZENLEME YAPILMISTIR***CKE
            //
            //            string objectID = this.OBJECTID.CalcValue;
            //            DirectPurchaseAction dpa = (DirectPurchaseAction)MyParentReport.ReportObjectContext.GetObject(new Guid(objectID), typeof(DirectPurchaseAction));
            //
            //            string komisyonUyeleri = string.Empty;
            //
            //            foreach (CommisionMember member in dpa.CommissionMembers)
            //            {
            //                if (member.ResUser.Title.HasValue)
            //                {
            //                    TTDataType dataType = TTObjectDefManager.Instance.DataTypes[typeof(UserTitleEnum).Name];
            //                    komisyonUyeleri += dataType.EnumValueDefs[(int)member.ResUser.Title.Value].DisplayText + " ";
            //                }
            //                if (member.ResUser.Rank != null)
            //                {
            //                    komisyonUyeleri += member.ResUser.Rank.ShortName + " ";
            //                    komisyonUyeleri += member.ResUser.Name + ", ";
            //                }
            //                else
            //                {
            //                    komisyonUyeleri += member.ResUser.Name + ", ";
            //                }
            //            }
            //
            //            komisyonUyeleri = komisyonUyeleri.Substring(0,komisyonUyeleri.Length-2);
            //            KOMISYON.CalcValue = komisyonUyeleri;
            
            
            string objectID = this.OBJECTID.CalcValue;
            DirectPurchaseAction dpa = (DirectPurchaseAction)MyParentReport.ReportObjectContext.GetObject(new Guid(objectID), typeof(DirectPurchaseAction));
            string asilBaskan = string.Empty;
            string asilUye1 = string.Empty;
            string asilUye2 = string.Empty;
            string yedekBaskan = string.Empty;
            string yedekUye1 = string.Empty;
            string yedekUye2 = string.Empty;
            
            List<CommisionMember> commisionPrimeMember = new List<CommisionMember>();
            List<CommisionMember> commisionBackupMember = new List<CommisionMember>();

            foreach (CommisionMember member in dpa.CommissionMembers)
            {
                if (member.MemberDuty.ToString() == DPACommisionMemberDutyEnum.Chief.ToString())
                {
                    if (member.PrimeBackup == true)
                    {
                        //ASILBASKAN Name-Surname, Rank, Title set ediliyor.
                        if (member.ResUser.Title.HasValue)
                        {
                            TTDataType dataType = TTObjectDefManager.Instance.DataTypes[typeof(UserTitleEnum).Name];
                            asilBaskan += dataType.EnumValueDefs[(int)member.ResUser.Title.Value].DisplayText + " ";
                        }
                        if (member.ResUser.Rank != null)
                        {
                            asilBaskan += member.ResUser.Rank.ShortName + " ";
                            asilBaskan += member.ResUser.Name + " ";
                        }
                        else
                        {
                            asilBaskan += member.ResUser.Name + " ";
                        }
                        ASILBASKAN.CalcValue = asilBaskan;
                    }
                    
                    else
                    {
                        //YEDEKBASKAN Name-Surname, Title, Rank set ediliyor.
                        if (member.ResUser.Title.HasValue)
                        {
                            TTDataType dataType = TTObjectDefManager.Instance.DataTypes[typeof(UserTitleEnum).Name];
                            yedekBaskan += dataType.EnumValueDefs[(int)member.ResUser.Title.Value].DisplayText + " ";
                        }
                        if (member.ResUser.Rank != null)
                        {
                            yedekBaskan += member.ResUser.Rank.ShortName + " ";
                            yedekBaskan += member.ResUser.Name + " ";
                        }
                        else
                        {
                            yedekBaskan += member.ResUser.Name + " ";
                        }
                        YEDEKBASKAN.CalcValue = yedekBaskan;
                    }
                }

                if (member.MemberDuty.ToString() == DPACommisionMemberDutyEnum.Member.ToString())
                {
                    if (member.PrimeBackup == true)
                    {
                        commisionPrimeMember.Add(member);
                    }
                    else
                    {
                        commisionBackupMember.Add(member);
                    }
                }
            }

            //ASILUYE1 Name-Surname, Title, Rank set ediliyor.
            if (commisionPrimeMember[0].ResUser.Title.HasValue)
            {
                TTDataType dataType = TTObjectDefManager.Instance.DataTypes[typeof(UserTitleEnum).Name];
                asilUye1 += dataType.EnumValueDefs[(int)commisionPrimeMember[0].ResUser.Title.Value].DisplayText + " ";
            }
            if (commisionPrimeMember[0].ResUser.Rank != null)
            {
                asilUye1 += commisionPrimeMember[0].ResUser.Rank.ShortName + " ";
                asilUye1 += commisionPrimeMember[0].ResUser.Name + " ";
            }
            else
            {
                asilUye1 += commisionPrimeMember[0].ResUser.Name + " ";
            }
            ASILUYE1.CalcValue = asilUye1;

            //ASILUYE2 Name-Surname, Title, Rank set ediliyor.
            if (commisionPrimeMember[1].ResUser.Title.HasValue)
            {
                TTDataType dataType = TTObjectDefManager.Instance.DataTypes[typeof(UserTitleEnum).Name];
                asilUye2 += dataType.EnumValueDefs[(int)commisionPrimeMember[1].ResUser.Title.Value].DisplayText + " ";
            }
            if (commisionPrimeMember[1].ResUser.Rank != null)
            {
                asilUye2 += commisionPrimeMember[1].ResUser.Rank.ShortName + " ";
                asilUye2 += commisionPrimeMember[1].ResUser.Name + " ";
            }
            else
            {
                asilUye2 += commisionPrimeMember[1].ResUser.Name + " ";
            }
            ASILUYE2.CalcValue = asilUye2;

            //YEDEKUYE1 Name-Surname, Title, Rank set ediliyor.
            if (commisionBackupMember[0].ResUser.Title.HasValue)
            {
                TTDataType dataType = TTObjectDefManager.Instance.DataTypes[typeof(UserTitleEnum).Name];
                yedekUye1 += dataType.EnumValueDefs[(int)commisionBackupMember[0].ResUser.Title.Value].DisplayText + " ";
            }
            if (commisionBackupMember[0].ResUser.Rank != null)
            {
                yedekUye1 += commisionBackupMember[0].ResUser.Rank.ShortName + " ";
                yedekUye1 += commisionBackupMember[0].ResUser.Name + " ";
            }
            else
            {
                yedekUye1 += commisionBackupMember[0].ResUser.Name + " ";
            }
            YEDEKUYE1.CalcValue = yedekUye1;

            //YEDEKUYE2 Name-Surname, Title, Rank set ediliyor.
            if (commisionBackupMember[1].ResUser.Title.HasValue)
            {
                TTDataType dataType = TTObjectDefManager.Instance.DataTypes[typeof(UserTitleEnum).Name];
                yedekUye2 += dataType.EnumValueDefs[(int)commisionBackupMember[1].ResUser.Title.Value].DisplayText + " ";
            }
            if (commisionBackupMember[1].ResUser.Rank != null)
            {
                yedekUye2 += commisionBackupMember[1].ResUser.Rank.ShortName + " ";
                yedekUye2 += commisionBackupMember[1].ResUser.Name + " ";
            }
            else
            {
                yedekUye2 += commisionBackupMember[1].ResUser.Name + " ";
            }
            YEDEKUYE2.CalcValue = yedekUye2;
            
            TTObjectContext octx = new TTObjectContext(true);
            string newobjectID = ((DirectPurchaseApprovalFormReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            DirectPurchaseAction newdpa = (DirectPurchaseAction)octx.GetObject(new Guid(newobjectID), typeof(DirectPurchaseAction));
            
            if (newdpa.DirectPurchaseActionType == DirectPurchaseActionTypeEnum.RadioPharmaceutical)
            {
                string Radyo = "İLGİ : ...../...../..... tarih ve ............... sayılı Hastaya Özgü Acil Malzeme İhtiyaç Talep Ve Görevlendirme Formu \n\n" +
                    "1. " + this.UZMANLIK.CalcValue + " işlemi yapılan " + this.PATIENTSTATUS.CalcValue + " " + this.HASTAISIM.CalcValue + " (" + this.HASTATCNO.CalcValue + ") isimli hasta için ihtiyaç duyulan malzemeler hastanın durumunun aciliyeti ve malzemenin depolanamayan radyoaktif malzeme olması nedeniyle doğrudan temin alım yöntemiyle alınmasına karar verilmiştir.\n" +
                    "2. " + this.UZMANLIK.CalcValue + " tarafından tedariği istenilen malzemeler özelliğinden dolayı stoklanamamaktadır.\n" +
                    "3.Söz konusu malzemeler kısa ömürlü stoklanamayan radyoaktif malzeme olduğundan 4734 Sayılı Kanunun 22'nci Maddesinin (f) bendi kapsamında gerçekleştirilecektir.\n" +
                    "4.İhtiyaç duyulan mal bir defada alınacağından sözleşme yapılmayacaktır ve teminat istenmeyecektir. \n" +
                    "5.İhtiyaç duyulan malzemelerden uygulama esnasında kullanılanların ödemesi yapılacaktır. Bu kapsamda yüklenici sadece kullanılan malzemeyi faturalandıracaktır. \n" +
                    "6.Bu alım usulünde; birim fiyat üzerinden kısmi teklif verilebilir, malın kabulünde kısmi kabul yapılabilecektir. \n" +
                    "7.İsteklilerde 4734 Sayılı Kamu İhale Kanunu Madde 10 İhaleye Katılımda Yeterlik Kuralları aranmayacaktır. \n" +
                    "8.Yüklenici tarafından; teklif edilen malzemeler için; İlaç ve Tıbbi Cihaz Ulusal Bilgi Bankası (TİTUBB) sistemine kayıtlı olduğunu belirten  'Tedarikçi Firma/Bayi Tanımlama Formu',  'Malzeme Tanımlama Formu' ve 'Sosyal Güvenlik Kurumundan Onaylıdır Formu' veya TİTUBB'dan alınan bu formların yerine geçebilecek güncel formlar verilecektir. Kapsam dışında olan malzemeler için kapsam dışı olduğunda dair Üretici / Tedarikçi firma beyanı alınacaktır.\n" +
                    "9.Yapılacak alımda bu amaçla tahsis edilen 03.2.6.02 'Tıbbi Malzeme ve İlaç Alımları' " + this.BUTCEMIDOSEMI.CalcValue + " ödeneği kullanılacaktır.\n" +
                    "10. " + this.SAYMANLIK.CalcValue + " tarafından  tahakkuka bağlanarak Maliye Bakanlığınca belirlenen serbest bırakma oranları dahilinde düzenlenerek ödenek gönderme belgelerine göre " + this.SAYMANLIK.CalcValue + " 03.2.6.02 'Tıbbi Malzeme ve İlaç Alımları' " + this.MALIYIL.CalcValue + " mali yılı bütçesinden ödemesi yapılacaktır.\n" +
                    "11. Alım, alım heyetindeki Asil Başkan; " + this.ASILBASKAN.CalcValue + ", Asil Üyeler; " + this.ASILUYE1.CalcValue + ", " + this.ASILUYE2.CalcValue + ", Yedek Başkan; " + this.YEDEKBASKAN.CalcValue + ", Yedek Üyeler; " + this.YEDEKUYE1.CalcValue + ", " + this.YEDEKUYE2.CalcValue + " tarafından görülerek ve beğenilerek yapılacaktır. Malın muayene ve kabul işlemleri de aynı alım heyeti tarafından yapılacaktır.\n\n" +
                    "Bütçe Koordine: \n\n" +
                    "EKİ: \n"+
                    "EK-A: Hastaya Özgü / Acil Malzeme İhtiyaç Talep ve Görevlendirme Formu \n" +
                    "EK-B: Malzeme Listesi ";
                
                this.TEXT.CalcValue = Radyo;
            }
            else if (newdpa.DirectPurchaseActionType == DirectPurchaseActionTypeEnum.Titubb)
            {
                string UBB = "İLGİ : ...../...../..... tarih ve ............... sayılı Hastaya Özgü Acil Malzeme İhtiyaç Talep Ve Görevlendirme Formu \n\n" +
                    "1. " + this.UZMANLIK.CalcValue + " işlemi yapılan " + this.PATIENTSTATUS.CalcValue + " " + this.HASTAISIM.CalcValue + " (" + this.HASTATCNO.CalcValue + ") isimli hasta için ihtiyaç duyulan malzemeler hastanın durumunun aciliyeti ve malzemenin depoda bulunmaması nedeniyle doğrudan temin alım yöntemiyle alınmasına karar verilmiştir.\n" +
                    "2. " + this.UZMANLIK.CalcValue + " tarafından tedariği istenilen malzemeler özelliğinden dolayı her vakada farklı ebatta olup kişiye özel kullanılması nedeniyle stoklanamamaktadır.\n" +
                    "3.Söz konusu malzemeler stoklanması ekonomik olmayan, hastaya göre ve hastaya özgü malzemeler olduğundan 4734 Sayılı Kanunun 22'nci Maddesinin (f) bendi kapsamında gerçekleştirilecektir.\n" +
                    "4.İhtiyaç duyulan mal bir defada alınacağından sözleşme yapılmayacaktır ve teminat istenmeyecektir. \n" +
                    "5.İhtiyaç duyulan malzemelerden uygulama esnasında kullanılanların ödemesi yapılacaktır. Bu kapsamda yüklenici sadece kullanılan malzemeyi faturalandıracaktır. \n" +
                    "6.Bu alım usulünde; birim fiyat üzerinden kısmi teklif verilebilir, malın kabulünde kısmi kabul yapılabilecektir. \n" +
                    "7.İsteklilerde 4734 Sayılı Kamu İhale Kanunu Madde 10 İhaleye Katılımda Yeterlik Kuralları aranmayacaktır. \n" +
                    "8.Yüklenici tarafından; teklif edilen malzemeler için; İlaç ve Tıbbi Cihaz Ulusal Bilgi Bankası (TİTUBB) sistemine kayıtlı olduğunu belirten  'Tedarikçi Firma/Bayi Tanımlama Formu',  'Malzeme Tanımlama Formu' ve 'Sosyal Güvenlik Kurumundan Onaylıdır Formu' verilecektir.\n" +
                    "9.Yapılacak alımda bu amaçla tahsis edilen 03.2.6.02 'Tıbbi Malzeme ve İlaç Alımları' " + this.BUTCEMIDOSEMI.CalcValue + " ödeneği kullanılacaktır.\n" +
                    "10. " + this.SAYMANLIK.CalcValue + " tarafından  tahakkuka bağlanarak Maliye Bakanlığınca belirlenen serbest bırakma oranları dahilinde düzenlenerek ödenek gönderme belgelerine göre " + this.SAYMANLIK.CalcValue + " 03.2.6.02 'Tıbbi Malzeme ve İlaç Alımları' " + this.MALIYIL.CalcValue + " mali yılı bütçesinden ödemesi yapılacaktır.\n" +
                    "11. Alım, alım heyetindeki Asil Başkan; " + this.ASILBASKAN.CalcValue + ", Asil Üyeler; " + this.ASILUYE1.CalcValue + ", " + this.ASILUYE2.CalcValue + ", Yedek Başkan; " + this.YEDEKBASKAN.CalcValue + ", Yedek Üyeler; " + this.YEDEKUYE1.CalcValue + ", " + this.YEDEKUYE2.CalcValue + " tarafından görülerek ve beğenilerek yapılacaktır. Malın muayene ve kabul işlemleri de aynı alım heyeti tarafından yapılacaktır.\n\n" +
                    "Bütçe Koordine: \n\n" +
                    "EKİ: \n"+
                    "EK-A: Hastaya Özgü / Acil Malzeme İhtiyaç Talep ve Görevlendirme Formu \n" +
                    "EK-B: Malzeme Listesi ";
                
                this.TEXT.CalcValue = UBB;
            }
            else
            {
                string UBB = "İLGİ : ...../...../..... tarih ve ............... sayılı Hastaya Özgü Acil Malzeme İhtiyaç Talep Ve Görevlendirme Formu \n\n" +
                    "1. " + this.UZMANLIK.CalcValue + " işlemi yapılan " + this.PATIENTSTATUS.CalcValue + " " + this.HASTAISIM.CalcValue + " (" + this.HASTATCNO.CalcValue + ") isimli hasta için ihtiyaç duyulan malzemeler hastanın durumunun aciliyeti ve malzemenin depoda bulunmaması nedeniyle doğrudan temin alım yöntemiyle alınmasına karar verilmiştir.\n" +
                    "2. " + this.UZMANLIK.CalcValue + " tarafından tedariği istenilen malzemeler özelliğinden dolayı her vakada farklı ebatta olup kişiye özel kullanılması nedeniyle stoklanamamaktadır.\n" +
                    "3.Söz konusu malzemeler stoklanması ekonomik olmayan, hastaya göre ve hastaya özgü malzemeler olduğundan 4734 Sayılı Kanunun 22'nci Maddesinin (f) bendi kapsamında gerçekleştirilecektir.\n" +
                    "4.İhtiyaç duyulan mal bir defada alınacağından sözleşme yapılmayacaktır ve teminat istenmeyecektir. \n" +
                    "5.İhtiyaç duyulan malzemelerden uygulama esnasında kullanılanların ödemesi yapılacaktır. Bu kapsamda yüklenici sadece kullanılan malzemeyi faturalandıracaktır. \n" +
                    "6.Bu alım usulünde; birim fiyat üzerinden kısmi teklif verilebilir, malın kabulünde kısmi kabul yapılabilecektir. \n" +
                    "7.İsteklilerde 4734 Sayılı Kamu İhale Kanunu Madde 10 İhaleye Katılımda Yeterlik Kuralları aranmayacaktır. \n" +
                    "8.Yüklenici tarafından; yüklenicinin İlaç ve Tıbbi Cihaz Ulusal Bilgi Bankası (TİTUBB) sistemine kayıtlı olduğunu belirten  'Tedarikçi Firma/Bayi Tanımlama Formu' ve malzemenin TITUBB kapsamı dışında olduğuna dair beyan verilecektir.\n" +
                    "9.Yapılacak alımda bu amaçla tahsis edilen 03.2.6.02 'Tıbbi Malzeme ve İlaç Alımları' " + this.BUTCEMIDOSEMI.CalcValue + " ödeneği kullanılacaktır.\n" +
                    "10. " + this.SAYMANLIK.CalcValue + " tarafından  tahakkuka bağlanarak Maliye Bakanlığınca belirlenen serbest bırakma oranları dahilinde düzenlenerek ödenek gönderme belgelerine göre " + this.SAYMANLIK.CalcValue + " 03.2.6.02 'Tıbbi Malzeme ve İlaç Alımları' " + this.MALIYIL.CalcValue + " mali yılı bütçesinden ödemesi yapılacaktır.\n" +
                    "11. Alım, alım heyetindeki Asil Başkan; " + this.ASILBASKAN.CalcValue + ", Asil Üyeler; " + this.ASILUYE1.CalcValue + ", " + this.ASILUYE2.CalcValue + ", Yedek Başkan; " + this.YEDEKBASKAN.CalcValue + ", Yedek Üyeler; " + this.YEDEKUYE1.CalcValue + ", " + this.YEDEKUYE2.CalcValue + " tarafından görülerek ve beğenilerek yapılacaktır. Malın muayene ve kabul işlemleri de aynı alım heyeti tarafından yapılacaktır.\n\n" +
                    "Bütçe Koordine: \n\n" +
                    "EKİ: \n"+
                    "EK-A: Hastaya Özgü / Acil Malzeme İhtiyaç Talep ve Görevlendirme Formu \n" +
                    "EK-B: Malzeme Listesi ";
                
                this.TEXT.CalcValue = UBB;
            }
            
            string b = "" + ((DirectPurchaseApprovalFormReport)ParentReport).counter + "  kalem " + this.UZMANLIK.CalcValue + " hastaya özgü tıbbi malzeme.";
            this.ISINNITELIGI.CalcValue = b;
            ((DirectPurchaseApprovalFormReport)ParentReport).counter = 0;
            
            if(dpa.Budget != null && string.IsNullOrEmpty(dpa.Budget.Code1) == false && string.IsNullOrEmpty(dpa.Budget.Code2) == false && string.IsNullOrEmpty(dpa.Budget.Code3) == false && string.IsNullOrEmpty(dpa.Budget.Code4) == false)
            {
                string butceCode = dpa.Budget.Code1 + "-" + dpa.Budget.Code2 + "-" + dpa.Budget.Code3 + "-" + dpa.Budget.Code4;
                BUTCE.CalcValue = butceCode;
                BUTCEDOSE.CalcValue = butceCode;
            }
#endregion PARTB HEADER_Script
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public DirectPurchaseApprovalFormReport MyParentReport
                {
                    get { return (DirectPurchaseApprovalFormReport)ParentReport; }
                }
                
                public TTReportField NewField1151;
                public TTReportField Onay111;
                public TTReportField NewField11321;
                public TTReportField NewField132;
                public TTReportField NewField1162;
                public TTReportField NewField11612;
                public TTReportField NewField11622;
                public TTReportField NewField112612;
                public TTReportField NewField112622;
                public TTReportField NewField1171;
                public TTReportField NewField11631;
                public TTReportField NewField111611;
                public TTReportField NewField112631;
                public TTReportField NewField1116211;
                public TTReportField NewField1126211;
                public TTReportShape NewLine12;
                public TTReportShape NewLine13;
                public TTReportShape NewLine121;
                public TTReportField NewField3;
                public TTReportField NewField14;
                public TTReportField NewField122321;
                public TTReportField NewField1226111;
                public TTReportField NewField12216111;
                public TTReportField NewField12226111;
                public TTReportField NewField122162111;
                public TTReportField NewField122262111;
                public TTReportField NewField1123211;
                public TTReportField NewField11116211;
                public TTReportField NewField111161211;
                public TTReportField NewField111162211;
                public TTReportField NewField1111261211;
                public TTReportField NewField1111262211;
                public TTReportField HARCAMAYET;
                public TTReportField KOORDINEAMIRI;
                public TTReportField KOORDINEAMIRIUNVAN;
                public TTReportField KOORDINEAMIRIRUTBE;
                public TTReportField LOJSMUDUNVAN;
                public TTReportField HARCAMAYETUNVAN;
                public TTReportField HARCAMAYETRUTBEIS;
                public TTReportField HARCAMAYETKILISIUNVAN;
                public TTReportField HARCAMAYETKILISIRUTBE; 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 44;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField1151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 199, 4, 287, 44, false);
                    NewField1151.Name = "NewField1151";
                    NewField1151.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1151.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1151.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1151.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1151.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1151.TextFont.Name = "Arial";
                    NewField1151.TextFont.Size = 8;
                    NewField1151.TextFont.CharSet = 162;
                    NewField1151.Value = @"Uygundur.
......../......../20....
Harcama Yetkilisi";

                    Onay111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 4, 199, 44, false);
                    Onay111.Name = "Onay111";
                    Onay111.DrawStyle = DrawStyleConstants.vbSolid;
                    Onay111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    Onay111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Onay111.MultiLine = EvetHayirEnum.ehEvet;
                    Onay111.WordBreak = EvetHayirEnum.ehEvet;
                    Onay111.TextFont.Name = "Arial";
                    Onay111.TextFont.Size = 8;
                    Onay111.TextFont.CharSet = 162;
                    Onay111.Value = @"Yukarıda belirtilen malın alınması için yeterli ödeneğin mevcut olduğunu, 4734 Sayılı Kanunun 22/F maddesi Doğrudan Temin Usulü ile alıma çıkılması hususunu onaylarınıza arz ederim.
......../......../20....";

                    NewField11321 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 0, 287, 4, false);
                    NewField11321.Name = "NewField11321";
                    NewField11321.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11321.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11321.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11321.TextFont.Name = "Arial";
                    NewField11321.TextFont.Size = 8;
                    NewField11321.TextFont.Bold = true;
                    NewField11321.TextFont.CharSet = 162;
                    NewField11321.Value = @"O   N   A   Y";

                    NewField132 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 111, 18, 122, 22, false);
                    NewField132.Name = "NewField132";
                    NewField132.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField132.TextFont.Name = "Arial";
                    NewField132.TextFont.Size = 8;
                    NewField132.TextFont.Bold = true;
                    NewField132.TextFont.CharSet = 162;
                    NewField132.Value = @"İmzası";

                    NewField1162 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 111, 30, 127, 34, false);
                    NewField1162.Name = "NewField1162";
                    NewField1162.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1162.TextFont.Name = "Arial";
                    NewField1162.TextFont.Size = 8;
                    NewField1162.TextFont.Bold = true;
                    NewField1162.TextFont.CharSet = 162;
                    NewField1162.Value = @"Adı SOYADI";

                    NewField11612 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 111, 34, 127, 38, false);
                    NewField11612.Name = "NewField11612";
                    NewField11612.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11612.TextFont.Name = "Arial";
                    NewField11612.TextFont.Size = 8;
                    NewField11612.TextFont.Bold = true;
                    NewField11612.TextFont.CharSet = 162;
                    NewField11612.Value = @"Ünvanı";

                    NewField11622 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 128, 30, 129, 34, false);
                    NewField11622.Name = "NewField11622";
                    NewField11622.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11622.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11622.TextFont.Name = "Arial";
                    NewField11622.TextFont.Size = 8;
                    NewField11622.TextFont.Bold = true;
                    NewField11622.TextFont.CharSet = 162;
                    NewField11622.Value = @":";

                    NewField112612 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 128, 18, 129, 22, false);
                    NewField112612.Name = "NewField112612";
                    NewField112612.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112612.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112612.TextFont.Name = "Arial";
                    NewField112612.TextFont.Size = 8;
                    NewField112612.TextFont.Bold = true;
                    NewField112612.TextFont.CharSet = 162;
                    NewField112612.Value = @":";

                    NewField112622 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 128, 34, 129, 38, false);
                    NewField112622.Name = "NewField112622";
                    NewField112622.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112622.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112622.TextFont.Name = "Arial";
                    NewField112622.TextFont.Size = 8;
                    NewField112622.TextFont.Bold = true;
                    NewField112622.TextFont.CharSet = 162;
                    NewField112622.Value = @":";

                    NewField1171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 200, 16, 211, 20, false);
                    NewField1171.Name = "NewField1171";
                    NewField1171.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1171.TextFont.Name = "Arial";
                    NewField1171.TextFont.Size = 8;
                    NewField1171.TextFont.Bold = true;
                    NewField1171.TextFont.CharSet = 162;
                    NewField1171.Value = @"İmzası";

                    NewField11631 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 200, 27, 216, 31, false);
                    NewField11631.Name = "NewField11631";
                    NewField11631.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11631.TextFont.Name = "Arial";
                    NewField11631.TextFont.Size = 8;
                    NewField11631.TextFont.Bold = true;
                    NewField11631.TextFont.CharSet = 162;
                    NewField11631.Value = @"Adı SOYADI";

                    NewField111611 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 200, 31, 216, 35, false);
                    NewField111611.Name = "NewField111611";
                    NewField111611.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111611.TextFont.Name = "Arial";
                    NewField111611.TextFont.Size = 8;
                    NewField111611.TextFont.Bold = true;
                    NewField111611.TextFont.CharSet = 162;
                    NewField111611.Value = @"Ünvanı";

                    NewField112631 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 27, 218, 31, false);
                    NewField112631.Name = "NewField112631";
                    NewField112631.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112631.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112631.TextFont.Name = "Arial";
                    NewField112631.TextFont.Size = 8;
                    NewField112631.TextFont.Bold = true;
                    NewField112631.TextFont.CharSet = 162;
                    NewField112631.Value = @":";

                    NewField1116211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 16, 218, 20, false);
                    NewField1116211.Name = "NewField1116211";
                    NewField1116211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1116211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1116211.TextFont.Name = "Arial";
                    NewField1116211.TextFont.Size = 8;
                    NewField1116211.TextFont.Bold = true;
                    NewField1116211.TextFont.CharSet = 162;
                    NewField1116211.Value = @":";

                    NewField1126211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 31, 218, 35, false);
                    NewField1126211.Name = "NewField1126211";
                    NewField1126211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1126211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1126211.TextFont.Name = "Arial";
                    NewField1126211.TextFont.Size = 8;
                    NewField1126211.TextFont.Bold = true;
                    NewField1126211.TextFont.CharSet = 162;
                    NewField1126211.Value = @":";

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 41, 110, 41, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine13 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 0, 10, 41, false);
                    NewLine13.Name = "NewLine13";
                    NewLine13.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 60, 0, 60, 41, false);
                    NewLine121.Name = "NewLine121";
                    NewLine121.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 0, 60, 44, false);
                    NewField3.Name = "NewField3";
                    NewField3.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField3.Value = @"";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 0, 110, 44, false);
                    NewField14.Name = "NewField14";
                    NewField14.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField14.Value = @"";

                    NewField122321 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 3, 72, 7, false);
                    NewField122321.Name = "NewField122321";
                    NewField122321.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField122321.TextFont.Name = "Arial";
                    NewField122321.TextFont.Size = 8;
                    NewField122321.TextFont.Bold = true;
                    NewField122321.TextFont.CharSet = 162;
                    NewField122321.Value = @"İmzası";

                    NewField1226111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 21, 77, 25, false);
                    NewField1226111.Name = "NewField1226111";
                    NewField1226111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1226111.TextFont.Name = "Arial";
                    NewField1226111.TextFont.Size = 8;
                    NewField1226111.TextFont.Bold = true;
                    NewField1226111.TextFont.CharSet = 162;
                    NewField1226111.Value = @"Adı SOYADI";

                    NewField12216111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 26, 77, 30, false);
                    NewField12216111.Name = "NewField12216111";
                    NewField12216111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12216111.TextFont.Name = "Arial";
                    NewField12216111.TextFont.Size = 8;
                    NewField12216111.TextFont.Bold = true;
                    NewField12216111.TextFont.CharSet = 162;
                    NewField12216111.Value = @"Ünvanı";

                    NewField12226111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 78, 21, 79, 25, false);
                    NewField12226111.Name = "NewField12226111";
                    NewField12226111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12226111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12226111.TextFont.Name = "Arial";
                    NewField12226111.TextFont.Size = 8;
                    NewField12226111.TextFont.Bold = true;
                    NewField12226111.TextFont.CharSet = 162;
                    NewField12226111.Value = @":";

                    NewField122162111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 78, 3, 79, 7, false);
                    NewField122162111.Name = "NewField122162111";
                    NewField122162111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField122162111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField122162111.TextFont.Name = "Arial";
                    NewField122162111.TextFont.Size = 8;
                    NewField122162111.TextFont.Bold = true;
                    NewField122162111.TextFont.CharSet = 162;
                    NewField122162111.Value = @":";

                    NewField122262111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 78, 26, 79, 30, false);
                    NewField122262111.Name = "NewField122262111";
                    NewField122262111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField122262111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField122262111.TextFont.Name = "Arial";
                    NewField122262111.TextFont.Size = 8;
                    NewField122262111.TextFont.Bold = true;
                    NewField122262111.TextFont.CharSet = 162;
                    NewField122262111.Value = @":";

                    NewField1123211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 3, 22, 7, false);
                    NewField1123211.Name = "NewField1123211";
                    NewField1123211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1123211.TextFont.Name = "Arial";
                    NewField1123211.TextFont.Size = 8;
                    NewField1123211.TextFont.Bold = true;
                    NewField1123211.TextFont.CharSet = 162;
                    NewField1123211.Value = @"İmzası";

                    NewField11116211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 21, 27, 25, false);
                    NewField11116211.Name = "NewField11116211";
                    NewField11116211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11116211.TextFont.Name = "Arial";
                    NewField11116211.TextFont.Size = 8;
                    NewField11116211.TextFont.Bold = true;
                    NewField11116211.TextFont.CharSet = 162;
                    NewField11116211.Value = @"Adı SOYADI";

                    NewField111161211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 26, 27, 30, false);
                    NewField111161211.Name = "NewField111161211";
                    NewField111161211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111161211.TextFont.Name = "Arial";
                    NewField111161211.TextFont.Size = 8;
                    NewField111161211.TextFont.Bold = true;
                    NewField111161211.TextFont.CharSet = 162;
                    NewField111161211.Value = @"Ünvanı";

                    NewField111162211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 28, 21, 29, 25, false);
                    NewField111162211.Name = "NewField111162211";
                    NewField111162211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111162211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111162211.TextFont.Name = "Arial";
                    NewField111162211.TextFont.Size = 8;
                    NewField111162211.TextFont.Bold = true;
                    NewField111162211.TextFont.CharSet = 162;
                    NewField111162211.Value = @":";

                    NewField1111261211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 28, 3, 29, 7, false);
                    NewField1111261211.Name = "NewField1111261211";
                    NewField1111261211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111261211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111261211.TextFont.Name = "Arial";
                    NewField1111261211.TextFont.Size = 8;
                    NewField1111261211.TextFont.Bold = true;
                    NewField1111261211.TextFont.CharSet = 162;
                    NewField1111261211.Value = @":";

                    NewField1111262211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 28, 26, 29, 30, false);
                    NewField1111262211.Name = "NewField1111262211";
                    NewField1111262211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111262211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111262211.TextFont.Name = "Arial";
                    NewField1111262211.TextFont.Size = 8;
                    NewField1111262211.TextFont.Bold = true;
                    NewField1111262211.TextFont.CharSet = 162;
                    NewField1111262211.Value = @":";

                    HARCAMAYET = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 27, 269, 31, false);
                    HARCAMAYET.Name = "HARCAMAYET";
                    HARCAMAYET.FieldType = ReportFieldTypeEnum.ftVariable;
                    HARCAMAYET.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HARCAMAYET.ObjectDefName = "ResUser";
                    HARCAMAYET.DataMember = "NAME";
                    HARCAMAYET.TextFont.Name = "Arial";
                    HARCAMAYET.TextFont.Size = 8;
                    HARCAMAYET.TextFont.CharSet = 162;
                    HARCAMAYET.Value = @"{#HARCAMAYETKILISI#}";

                    KOORDINEAMIRI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 130, 30, 179, 34, false);
                    KOORDINEAMIRI.Name = "KOORDINEAMIRI";
                    KOORDINEAMIRI.FieldType = ReportFieldTypeEnum.ftVariable;
                    KOORDINEAMIRI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    KOORDINEAMIRI.ObjectDefName = "ResUser";
                    KOORDINEAMIRI.DataMember = "NAME";
                    KOORDINEAMIRI.TextFont.Name = "Arial";
                    KOORDINEAMIRI.TextFont.Size = 8;
                    KOORDINEAMIRI.TextFont.CharSet = 162;
                    KOORDINEAMIRI.Value = @"{#KOORDINEAMIRI#}";

                    KOORDINEAMIRIUNVAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 301, 4, 316, 9, false);
                    KOORDINEAMIRIUNVAN.Name = "KOORDINEAMIRIUNVAN";
                    KOORDINEAMIRIUNVAN.Visible = EvetHayirEnum.ehHayir;
                    KOORDINEAMIRIUNVAN.FieldType = ReportFieldTypeEnum.ftVariable;
                    KOORDINEAMIRIUNVAN.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    KOORDINEAMIRIUNVAN.ExpandTabs = EvetHayirEnum.ehEvet;
                    KOORDINEAMIRIUNVAN.ObjectDefName = "UserTitleEnum";
                    KOORDINEAMIRIUNVAN.DataMember = "DISPLAYTEXT";
                    KOORDINEAMIRIUNVAN.TextFont.Name = "Arial";
                    KOORDINEAMIRIUNVAN.TextFont.Size = 8;
                    KOORDINEAMIRIUNVAN.TextFont.CharSet = 162;
                    KOORDINEAMIRIUNVAN.Value = @"{#KOORDINEAMIRIUNVAN#}";

                    KOORDINEAMIRIRUTBE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 301, 9, 316, 14, false);
                    KOORDINEAMIRIRUTBE.Name = "KOORDINEAMIRIRUTBE";
                    KOORDINEAMIRIRUTBE.Visible = EvetHayirEnum.ehHayir;
                    KOORDINEAMIRIRUTBE.FieldType = ReportFieldTypeEnum.ftVariable;
                    KOORDINEAMIRIRUTBE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    KOORDINEAMIRIRUTBE.ExpandTabs = EvetHayirEnum.ehEvet;
                    KOORDINEAMIRIRUTBE.ObjectDefName = "RankDefinitions";
                    KOORDINEAMIRIRUTBE.DataMember = "SHORTNAME";
                    KOORDINEAMIRIRUTBE.TextFont.Name = "Arial";
                    KOORDINEAMIRIRUTBE.TextFont.Size = 8;
                    KOORDINEAMIRIRUTBE.TextFont.CharSet = 162;
                    KOORDINEAMIRIRUTBE.Value = @"{#KOORDINEAMIRIRUTBE#}";

                    LOJSMUDUNVAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 130, 34, 179, 38, false);
                    LOJSMUDUNVAN.Name = "LOJSMUDUNVAN";
                    LOJSMUDUNVAN.FieldType = ReportFieldTypeEnum.ftVariable;
                    LOJSMUDUNVAN.TextFont.Name = "Arial";
                    LOJSMUDUNVAN.TextFont.Size = 8;
                    LOJSMUDUNVAN.TextFont.CharSet = 162;
                    LOJSMUDUNVAN.Value = @"";

                    HARCAMAYETUNVAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 31, 269, 35, false);
                    HARCAMAYETUNVAN.Name = "HARCAMAYETUNVAN";
                    HARCAMAYETUNVAN.FieldType = ReportFieldTypeEnum.ftVariable;
                    HARCAMAYETUNVAN.TextFont.Name = "Arial";
                    HARCAMAYETUNVAN.TextFont.Size = 8;
                    HARCAMAYETUNVAN.TextFont.CharSet = 162;
                    HARCAMAYETUNVAN.Value = @"";

                    HARCAMAYETRUTBEIS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 35, 282, 43, false);
                    HARCAMAYETRUTBEIS.Name = "HARCAMAYETRUTBEIS";
                    HARCAMAYETRUTBEIS.FieldType = ReportFieldTypeEnum.ftVariable;
                    HARCAMAYETRUTBEIS.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HARCAMAYETRUTBEIS.MultiLine = EvetHayirEnum.ehEvet;
                    HARCAMAYETRUTBEIS.WordBreak = EvetHayirEnum.ehEvet;
                    HARCAMAYETRUTBEIS.ExpandTabs = EvetHayirEnum.ehEvet;
                    HARCAMAYETRUTBEIS.TextFont.Name = "Arial";
                    HARCAMAYETRUTBEIS.TextFont.Size = 8;
                    HARCAMAYETRUTBEIS.TextFont.CharSet = 162;
                    HARCAMAYETRUTBEIS.Value = @"{#HARCAMAYETKILISIIS#}";

                    HARCAMAYETKILISIUNVAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 301, 15, 316, 20, false);
                    HARCAMAYETKILISIUNVAN.Name = "HARCAMAYETKILISIUNVAN";
                    HARCAMAYETKILISIUNVAN.Visible = EvetHayirEnum.ehHayir;
                    HARCAMAYETKILISIUNVAN.FieldType = ReportFieldTypeEnum.ftVariable;
                    HARCAMAYETKILISIUNVAN.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HARCAMAYETKILISIUNVAN.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HARCAMAYETKILISIUNVAN.ObjectDefName = "UserTitleEnum";
                    HARCAMAYETKILISIUNVAN.DataMember = "DISPLAYTEXT";
                    HARCAMAYETKILISIUNVAN.TextFont.Name = "Arial";
                    HARCAMAYETKILISIUNVAN.TextFont.Size = 8;
                    HARCAMAYETKILISIUNVAN.TextFont.CharSet = 162;
                    HARCAMAYETKILISIUNVAN.Value = @"{#HARCAMAYETKILISIUNVAN#}";

                    HARCAMAYETKILISIRUTBE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 301, 21, 316, 26, false);
                    HARCAMAYETKILISIRUTBE.Name = "HARCAMAYETKILISIRUTBE";
                    HARCAMAYETKILISIRUTBE.Visible = EvetHayirEnum.ehHayir;
                    HARCAMAYETKILISIRUTBE.FieldType = ReportFieldTypeEnum.ftVariable;
                    HARCAMAYETKILISIRUTBE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HARCAMAYETKILISIRUTBE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HARCAMAYETKILISIRUTBE.ObjectDefName = "RankDefinitions";
                    HARCAMAYETKILISIRUTBE.DataMember = "SHORTNAME";
                    HARCAMAYETKILISIRUTBE.TextFont.Name = "Arial";
                    HARCAMAYETKILISIRUTBE.TextFont.Size = 8;
                    HARCAMAYETKILISIRUTBE.TextFont.CharSet = 162;
                    HARCAMAYETKILISIRUTBE.Value = @"{#HARCAMAYETKILISIRUTBE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DirectPurchaseAction.DirectPurchaseApprovalFormReportNQL_Class dataset_DirectPurchaseApprovalFormReportNQL = ParentGroup.rsGroup.GetCurrentRecord<DirectPurchaseAction.DirectPurchaseApprovalFormReportNQL_Class>(0);
                    NewField1151.CalcValue = NewField1151.Value;
                    Onay111.CalcValue = Onay111.Value;
                    NewField11321.CalcValue = NewField11321.Value;
                    NewField132.CalcValue = NewField132.Value;
                    NewField1162.CalcValue = NewField1162.Value;
                    NewField11612.CalcValue = NewField11612.Value;
                    NewField11622.CalcValue = NewField11622.Value;
                    NewField112612.CalcValue = NewField112612.Value;
                    NewField112622.CalcValue = NewField112622.Value;
                    NewField1171.CalcValue = NewField1171.Value;
                    NewField11631.CalcValue = NewField11631.Value;
                    NewField111611.CalcValue = NewField111611.Value;
                    NewField112631.CalcValue = NewField112631.Value;
                    NewField1116211.CalcValue = NewField1116211.Value;
                    NewField1126211.CalcValue = NewField1126211.Value;
                    NewField3.CalcValue = NewField3.Value;
                    NewField14.CalcValue = NewField14.Value;
                    NewField122321.CalcValue = NewField122321.Value;
                    NewField1226111.CalcValue = NewField1226111.Value;
                    NewField12216111.CalcValue = NewField12216111.Value;
                    NewField12226111.CalcValue = NewField12226111.Value;
                    NewField122162111.CalcValue = NewField122162111.Value;
                    NewField122262111.CalcValue = NewField122262111.Value;
                    NewField1123211.CalcValue = NewField1123211.Value;
                    NewField11116211.CalcValue = NewField11116211.Value;
                    NewField111161211.CalcValue = NewField111161211.Value;
                    NewField111162211.CalcValue = NewField111162211.Value;
                    NewField1111261211.CalcValue = NewField1111261211.Value;
                    NewField1111262211.CalcValue = NewField1111262211.Value;
                    HARCAMAYET.CalcValue = (dataset_DirectPurchaseApprovalFormReportNQL != null ? Globals.ToStringCore(dataset_DirectPurchaseApprovalFormReportNQL.Harcamayetkilisi) : "");
                    HARCAMAYET.PostFieldValueCalculation();
                    KOORDINEAMIRI.CalcValue = (dataset_DirectPurchaseApprovalFormReportNQL != null ? Globals.ToStringCore(dataset_DirectPurchaseApprovalFormReportNQL.Koordineamiri) : "");
                    KOORDINEAMIRI.PostFieldValueCalculation();
                    KOORDINEAMIRIUNVAN.CalcValue = (dataset_DirectPurchaseApprovalFormReportNQL != null ? Globals.ToStringCore(dataset_DirectPurchaseApprovalFormReportNQL.Koordineamiriunvan) : "");
                    KOORDINEAMIRIUNVAN.PostFieldValueCalculation();
                    KOORDINEAMIRIRUTBE.CalcValue = (dataset_DirectPurchaseApprovalFormReportNQL != null ? Globals.ToStringCore(dataset_DirectPurchaseApprovalFormReportNQL.Koordineamirirutbe) : "");
                    KOORDINEAMIRIRUTBE.PostFieldValueCalculation();
                    LOJSMUDUNVAN.CalcValue = @"";
                    HARCAMAYETUNVAN.CalcValue = @"";
                    HARCAMAYETRUTBEIS.CalcValue = (dataset_DirectPurchaseApprovalFormReportNQL != null ? Globals.ToStringCore(dataset_DirectPurchaseApprovalFormReportNQL.Harcamayetkilisiis) : "");
                    HARCAMAYETKILISIUNVAN.CalcValue = (dataset_DirectPurchaseApprovalFormReportNQL != null ? Globals.ToStringCore(dataset_DirectPurchaseApprovalFormReportNQL.Harcamayetkilisiunvan) : "");
                    HARCAMAYETKILISIUNVAN.PostFieldValueCalculation();
                    HARCAMAYETKILISIRUTBE.CalcValue = (dataset_DirectPurchaseApprovalFormReportNQL != null ? Globals.ToStringCore(dataset_DirectPurchaseApprovalFormReportNQL.Harcamayetkilisirutbe) : "");
                    HARCAMAYETKILISIRUTBE.PostFieldValueCalculation();
                    return new TTReportObject[] { NewField1151,Onay111,NewField11321,NewField132,NewField1162,NewField11612,NewField11622,NewField112612,NewField112622,NewField1171,NewField11631,NewField111611,NewField112631,NewField1116211,NewField1126211,NewField3,NewField14,NewField122321,NewField1226111,NewField12216111,NewField12226111,NewField122162111,NewField122262111,NewField1123211,NewField11116211,NewField111161211,NewField111162211,NewField1111261211,NewField1111262211,HARCAMAYET,KOORDINEAMIRI,KOORDINEAMIRIUNVAN,KOORDINEAMIRIRUTBE,LOJSMUDUNVAN,HARCAMAYETUNVAN,HARCAMAYETRUTBEIS,HARCAMAYETKILISIUNVAN,HARCAMAYETKILISIRUTBE};
                }

                public override void RunScript()
                {
#region PARTB FOOTER_Script
                    string a = ""+ this.KOORDINEAMIRIUNVAN.CalcValue + " " + this.KOORDINEAMIRIRUTBE.CalcValue + "";
            this.LOJSMUDUNVAN.CalcValue = a;
            
            string b = "" + this.HARCAMAYETKILISIUNVAN.CalcValue + " " + this.HARCAMAYETKILISIRUTBE.CalcValue + "";
            this.HARCAMAYETUNVAN.CalcValue = b;
            
//            string objectID = ((OnayBelgesiRaporuIhale)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
//            TTObjectContext ctx = new TTObjectContext(true);
//            PurchaseProject pp = (PurchaseProject)ctx.GetObject(new Guid(objectID), typeof(PurchaseProject));
//            if (pp != null)
//                PROJECTNO.CalcValue = " Proje Nu. : " + pp.PurchaseProjectNO.ToString();
#endregion PARTB FOOTER_Script
                }
            }

        }

        public PARTBGroup PARTB;

        public partial class MAINGroup : TTReportGroup
        {
            public DirectPurchaseApprovalFormReport MyParentReport
            {
                get { return (DirectPurchaseApprovalFormReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
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
                public DirectPurchaseApprovalFormReport MyParentReport
                {
                    get { return (DirectPurchaseApprovalFormReport)ParentReport; }
                }
                 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 1;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public MAINGroup MAIN;

        public partial class MALZEMEGroup : TTReportGroup
        {
            public DirectPurchaseApprovalFormReport MyParentReport
            {
                get { return (DirectPurchaseApprovalFormReport)ParentReport; }
            }

            new public MALZEMEGroupBody Body()
            {
                return (MALZEMEGroupBody)_body;
            }
            public TTReportField SUTISIM { get {return Body().SUTISIM;} }
            public TTReportField MIKTAR { get {return Body().MIKTAR;} }
            public TTReportField OLCUBIRIMI { get {return Body().OLCUBIRIMI;} }
            public TTReportField SIRANO { get {return Body().SIRANO;} }
            public TTReportField UBBSUTISIM { get {return Body().UBBSUTISIM;} }
            public TTReportField RPCMATERIALNAME { get {return Body().RPCMATERIALNAME;} }
            public TTReportField CODELESSMATERIALNAME { get {return Body().CODELESSMATERIALNAME;} }
            public MALZEMEGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public MALZEMEGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<DirectPurchaseAction.DirectPurchaseApprovalFormInfotNQL_Class>("DirectPurchaseApprovalFormInfotNQL", DirectPurchaseAction.DirectPurchaseApprovalFormInfotNQL((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new MALZEMEGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class MALZEMEGroupBody : TTReportSection
            {
                public DirectPurchaseApprovalFormReport MyParentReport
                {
                    get { return (DirectPurchaseApprovalFormReport)ParentReport; }
                }
                
                public TTReportField SUTISIM;
                public TTReportField MIKTAR;
                public TTReportField OLCUBIRIMI;
                public TTReportField SIRANO;
                public TTReportField UBBSUTISIM;
                public TTReportField RPCMATERIALNAME;
                public TTReportField CODELESSMATERIALNAME; 
                public MALZEMEGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 5;
                    RepeatCount = 0;
                    
                    SUTISIM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 19, 0, 248, 5, false);
                    SUTISIM.Name = "SUTISIM";
                    SUTISIM.DrawStyle = DrawStyleConstants.vbSolid;
                    SUTISIM.FieldType = ReportFieldTypeEnum.ftVariable;
                    SUTISIM.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SUTISIM.MultiLine = EvetHayirEnum.ehEvet;
                    SUTISIM.WordBreak = EvetHayirEnum.ehEvet;
                    SUTISIM.ExpandTabs = EvetHayirEnum.ehEvet;
                    SUTISIM.TextFont.Name = "Arial";
                    SUTISIM.TextFont.CharSet = 162;
                    SUTISIM.Value = @"{#SUTISIM#}";

                    MIKTAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 248, 0, 262, 5, false);
                    MIKTAR.Name = "MIKTAR";
                    MIKTAR.DrawStyle = DrawStyleConstants.vbSolid;
                    MIKTAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    MIKTAR.HorzAlign = HorizontalAlignmentEnum.haRight;
                    MIKTAR.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MIKTAR.MultiLine = EvetHayirEnum.ehEvet;
                    MIKTAR.WordBreak = EvetHayirEnum.ehEvet;
                    MIKTAR.ExpandTabs = EvetHayirEnum.ehEvet;
                    MIKTAR.TextFont.Name = "Arial";
                    MIKTAR.TextFont.CharSet = 162;
                    MIKTAR.Value = @"{#MIKTAR#}";

                    OLCUBIRIMI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 262, 0, 287, 5, false);
                    OLCUBIRIMI.Name = "OLCUBIRIMI";
                    OLCUBIRIMI.DrawStyle = DrawStyleConstants.vbSolid;
                    OLCUBIRIMI.FieldType = ReportFieldTypeEnum.ftVariable;
                    OLCUBIRIMI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OLCUBIRIMI.MultiLine = EvetHayirEnum.ehEvet;
                    OLCUBIRIMI.WordBreak = EvetHayirEnum.ehEvet;
                    OLCUBIRIMI.ExpandTabs = EvetHayirEnum.ehEvet;
                    OLCUBIRIMI.ObjectDefName = "DistributionTypeDefinition";
                    OLCUBIRIMI.DataMember = "DISTRIBUTIONTYPE";
                    OLCUBIRIMI.TextFont.Name = "Arial";
                    OLCUBIRIMI.TextFont.CharSet = 162;
                    OLCUBIRIMI.Value = @"{#OLCUBIRIMI#}";

                    SIRANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 0, 19, 5, false);
                    SIRANO.Name = "SIRANO";
                    SIRANO.DrawStyle = DrawStyleConstants.vbSolid;
                    SIRANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SIRANO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SIRANO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SIRANO.MultiLine = EvetHayirEnum.ehEvet;
                    SIRANO.WordBreak = EvetHayirEnum.ehEvet;
                    SIRANO.ExpandTabs = EvetHayirEnum.ehEvet;
                    SIRANO.TextFont.Name = "Arial";
                    SIRANO.TextFont.CharSet = 162;
                    SIRANO.Value = @"{@counter@}";

                    UBBSUTISIM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 298, 1, 313, 5, false);
                    UBBSUTISIM.Name = "UBBSUTISIM";
                    UBBSUTISIM.Visible = EvetHayirEnum.ehHayir;
                    UBBSUTISIM.FieldType = ReportFieldTypeEnum.ftVariable;
                    UBBSUTISIM.TextFont.Name = "Arial";
                    UBBSUTISIM.TextFont.Size = 8;
                    UBBSUTISIM.TextFont.CharSet = 162;
                    UBBSUTISIM.Value = @"{#SUTISIM#}";

                    RPCMATERIALNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 314, 1, 329, 5, false);
                    RPCMATERIALNAME.Name = "RPCMATERIALNAME";
                    RPCMATERIALNAME.Visible = EvetHayirEnum.ehHayir;
                    RPCMATERIALNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    RPCMATERIALNAME.TextFont.Name = "Arial";
                    RPCMATERIALNAME.TextFont.Size = 8;
                    RPCMATERIALNAME.TextFont.CharSet = 162;
                    RPCMATERIALNAME.Value = @"{#RPCMATERIALNAME#}";

                    CODELESSMATERIALNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 329, 1, 359, 6, false);
                    CODELESSMATERIALNAME.Name = "CODELESSMATERIALNAME";
                    CODELESSMATERIALNAME.Visible = EvetHayirEnum.ehHayir;
                    CODELESSMATERIALNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    CODELESSMATERIALNAME.TextFont.Name = "Arial";
                    CODELESSMATERIALNAME.TextFont.Size = 8;
                    CODELESSMATERIALNAME.TextFont.CharSet = 162;
                    CODELESSMATERIALNAME.Value = @"{#CODELESSMATERIALNAME#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DirectPurchaseAction.DirectPurchaseApprovalFormInfotNQL_Class dataset_DirectPurchaseApprovalFormInfotNQL = ParentGroup.rsGroup.GetCurrentRecord<DirectPurchaseAction.DirectPurchaseApprovalFormInfotNQL_Class>(0);
                    SUTISIM.CalcValue = (dataset_DirectPurchaseApprovalFormInfotNQL != null ? Globals.ToStringCore(dataset_DirectPurchaseApprovalFormInfotNQL.Sutisim) : "");
                    MIKTAR.CalcValue = (dataset_DirectPurchaseApprovalFormInfotNQL != null ? Globals.ToStringCore(dataset_DirectPurchaseApprovalFormInfotNQL.Miktar) : "");
                    OLCUBIRIMI.CalcValue = (dataset_DirectPurchaseApprovalFormInfotNQL != null ? Globals.ToStringCore(dataset_DirectPurchaseApprovalFormInfotNQL.Olcubirimi) : "");
                    OLCUBIRIMI.PostFieldValueCalculation();
                    SIRANO.CalcValue = ParentGroup.Counter.ToString();
                    UBBSUTISIM.CalcValue = (dataset_DirectPurchaseApprovalFormInfotNQL != null ? Globals.ToStringCore(dataset_DirectPurchaseApprovalFormInfotNQL.Sutisim) : "");
                    RPCMATERIALNAME.CalcValue = (dataset_DirectPurchaseApprovalFormInfotNQL != null ? Globals.ToStringCore(dataset_DirectPurchaseApprovalFormInfotNQL.Rpcmaterialname) : "");
                    CODELESSMATERIALNAME.CalcValue = (dataset_DirectPurchaseApprovalFormInfotNQL != null ? Globals.ToStringCore(dataset_DirectPurchaseApprovalFormInfotNQL.Codelessmaterialname) : "");
                    return new TTReportObject[] { SUTISIM,MIKTAR,OLCUBIRIMI,SIRANO,UBBSUTISIM,RPCMATERIALNAME,CODELESSMATERIALNAME};
                }

                public override void RunScript()
                {
#region MALZEME BODY_Script
                    TTObjectContext octx = new TTObjectContext(true);
            string objectID = ((DirectPurchaseApprovalFormReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            DirectPurchaseAction dpa = (DirectPurchaseAction)octx.GetObject(new Guid(objectID), typeof(DirectPurchaseAction));
            
            if (dpa.DirectPurchaseActionType == DirectPurchaseActionTypeEnum.RadioPharmaceutical)
                this.SUTISIM.CalcValue = this.RPCMATERIALNAME.CalcValue;
            else if (dpa.DirectPurchaseActionType == DirectPurchaseActionTypeEnum.Codeless)
                this.SUTISIM.CalcValue = this.CODELESSMATERIALNAME.CalcValue;
            else
                this.SUTISIM.CalcValue = this.UBBSUTISIM.CalcValue;
#endregion MALZEME BODY_Script
                }
            }

        }

        public MALZEMEGroup MALZEME;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public DirectPurchaseApprovalFormReport()
        {
            PARTH = new PARTHGroup(this,"PARTH");
            PARTD = new PARTDGroup(this,"PARTD");
            PARTA = new PARTAGroup(PARTD,"PARTA");
            PARTB = new PARTBGroup(PARTA,"PARTB");
            MAIN = new MAINGroup(PARTB,"MAIN");
            MALZEME = new MALZEMEGroup(PARTD,"MALZEME");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "ObjectID", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("02201e8b-b96c-4551-b31b-4a1942f8b57e");
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "DIRECTPURCHASEAPPROVALFORMREPORT";
            Caption = "22F Onay Formu";
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

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
    /// Teslim Tesellüm Belgesi
    /// </summary>
    public partial class TeslimTesellumBelgesi : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
            public Guid? PTESLIMEDEN = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
            public Guid? PTESLIMEDEN2 = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
            public Guid? PUYE = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
            public Guid? PMUAKONT = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public TeslimTesellumBelgesi MyParentReport
            {
                get { return (TeslimTesellumBelgesi)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField ORDERNO { get {return Header().ORDERNO;} }
            public TTReportField NewField1113 { get {return Header().NewField1113;} }
            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField SENDERUNIT { get {return Header().SENDERUNIT;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField REPORTNAME { get {return Header().REPORTNAME;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportField RECEIVERUNIT { get {return Header().RECEIVERUNIT;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportField NewField13 { get {return Header().NewField13;} }
            public TTReportField NewField14 { get {return Header().NewField14;} }
            public TTReportField NewField15 { get {return Header().NewField15;} }
            public TTReportField NewField16 { get {return Header().NewField16;} }
            public TTReportField NewField17 { get {return Header().NewField17;} }
            public TTReportField NewField18 { get {return Header().NewField18;} }
            public TTReportShape NewLine2 { get {return Header().NewLine2;} }
            public TTReportShape NewLine12 { get {return Header().NewLine12;} }
            public TTReportField TESLIM { get {return Footer().TESLIM;} }
            public TTReportField TESLIM1 { get {return Footer().TESLIM1;} }
            public TTReportField NewField1111 { get {return Footer().NewField1111;} }
            public TTReportField NewField11111 { get {return Footer().NewField11111;} }
            public TTReportField NewField1112 { get {return Footer().NewField1112;} }
            public TTReportField NewField12111 { get {return Footer().NewField12111;} }
            public TTReportField NewField12112 { get {return Footer().NewField12112;} }
            public TTReportField NewField12113 { get {return Footer().NewField12113;} }
            public TTReportField NewField12114 { get {return Footer().NewField12114;} }
            public TTReportShape NewLine3 { get {return Footer().NewLine3;} }
            public TTReportField MUAKONT { get {return Footer().MUAKONT;} }
            public TTReportField TESLIMEDEN { get {return Footer().TESLIMEDEN;} }
            public TTReportField TESLIMEDEN2 { get {return Footer().TESLIMEDEN2;} }
            public TTReportField UYE { get {return Footer().UYE;} }
            public PARTAGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTAGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<MaintenanceOrder.GetMaintenanceOrderByObjectIDQuery_Class>("GetMaintenanceOrderByObjectIDQuery", MaintenanceOrder.GetMaintenanceOrderByObjectIDQuery((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTAGroupHeader(this);
                _footer = new PARTAGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class PARTAGroupHeader : TTReportSection
            {
                public TeslimTesellumBelgesi MyParentReport
                {
                    get { return (TeslimTesellumBelgesi)ParentReport; }
                }
                
                public TTReportField ORDERNO;
                public TTReportField NewField1113;
                public TTReportField NewField111;
                public TTReportField NewField12;
                public TTReportField SENDERUNIT;
                public TTReportField NewField1;
                public TTReportField REPORTNAME;
                public TTReportField NewField11;
                public TTReportField NewField121;
                public TTReportField RECEIVERUNIT;
                public TTReportShape NewLine1;
                public TTReportField NewField2;
                public TTReportField NewField13;
                public TTReportField NewField14;
                public TTReportField NewField15;
                public TTReportField NewField16;
                public TTReportField NewField17;
                public TTReportField NewField18;
                public TTReportShape NewLine2;
                public TTReportShape NewLine12; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 68;
                    IsAligned = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    ORDERNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 197, 47, 256, 52, false);
                    ORDERNO.Name = "ORDERNO";
                    ORDERNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    ORDERNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ORDERNO.TextFont.Name = "Arial";
                    ORDERNO.TextFont.CharSet = 162;
                    ORDERNO.Value = @"{#ORDERNO#}/{#REQUESTNO#}";

                    NewField1113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 168, 47, 196, 52, false);
                    NewField1113.Name = "NewField1113";
                    NewField1113.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1113.TextFont.Name = "Arial";
                    NewField1113.TextFont.Bold = true;
                    NewField1113.TextFont.CharSet = 162;
                    NewField1113.Value = @"SİPARİŞ KODU  :";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 168, 30, 196, 35, false);
                    NewField111.Name = "NewField111";
                    NewField111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111.TextFont.Name = "Arial";
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"ÖNCELİK KODU:";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 30, 36, 35, false);
                    NewField12.Name = "NewField12";
                    NewField12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12.TextFont.Name = "Arial";
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @":";

                    SENDERUNIT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 30, 167, 46, false);
                    SENDERUNIT.Name = "SENDERUNIT";
                    SENDERUNIT.FieldType = ReportFieldTypeEnum.ftExpression;
                    SENDERUNIT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SENDERUNIT.MultiLine = EvetHayirEnum.ehEvet;
                    SENDERUNIT.WordBreak = EvetHayirEnum.ehEvet;
                    SENDERUNIT.TextFont.Name = "Arial";
                    SENDERUNIT.TextFont.CharSet = 162;
                    SENDERUNIT.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """")";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 1, 30, 35, 35, false);
                    NewField1.Name = "NewField1";
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"GÖNDEREN BİRLİK";

                    REPORTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 25, 257, 30, false);
                    REPORTNAME.Name = "REPORTNAME";
                    REPORTNAME.DrawStyle = DrawStyleConstants.vbSolid;
                    REPORTNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REPORTNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REPORTNAME.TextFont.Name = "Arial";
                    REPORTNAME.TextFont.Size = 11;
                    REPORTNAME.TextFont.Bold = true;
                    REPORTNAME.TextFont.CharSet = 162;
                    REPORTNAME.Value = @"TESLİM TESELLÜM BELGESİ";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 1, 47, 35, 52, false);
                    NewField11.Name = "NewField11";
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Name = "Arial";
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"ALICI BİRLİK";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 47, 36, 52, false);
                    NewField121.Name = "NewField121";
                    NewField121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121.TextFont.Name = "Arial";
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @":";

                    RECEIVERUNIT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 47, 167, 62, false);
                    RECEIVERUNIT.Name = "RECEIVERUNIT";
                    RECEIVERUNIT.FieldType = ReportFieldTypeEnum.ftVariable;
                    RECEIVERUNIT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    RECEIVERUNIT.MultiLine = EvetHayirEnum.ehEvet;
                    RECEIVERUNIT.WordBreak = EvetHayirEnum.ehEvet;
                    RECEIVERUNIT.ObjectDefName = "ReferToUpperLevel";
                    RECEIVERUNIT.DataMember = "OWNERMILITARYUNIT.NAME";
                    RECEIVERUNIT.TextFont.Name = "Arial";
                    RECEIVERUNIT.TextFont.CharSet = 162;
                    RECEIVERUNIT.Value = @"{#RULOBJECTID#}";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 67, 257, 67, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 62, 21, 67, false);
                    NewField2.Name = "NewField2";
                    NewField2.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField2.TextFont.Name = "Arial";
                    NewField2.TextFont.Bold = true;
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @"SIRA NU.";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 62, 103, 67, false);
                    NewField13.Name = "NewField13";
                    NewField13.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField13.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField13.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField13.TextFont.Name = "Arial";
                    NewField13.TextFont.Bold = true;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @"MALZEMENİN CİNSİ";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 103, 62, 127, 67, false);
                    NewField14.Name = "NewField14";
                    NewField14.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField14.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField14.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField14.TextFont.Name = "Arial";
                    NewField14.TextFont.Bold = true;
                    NewField14.TextFont.CharSet = 162;
                    NewField14.Value = @"MİKTARI";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 127, 62, 155, 67, false);
                    NewField15.Name = "NewField15";
                    NewField15.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField15.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField15.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField15.TextFont.Name = "Arial";
                    NewField15.TextFont.Bold = true;
                    NewField15.TextFont.CharSet = 162;
                    NewField15.Value = @"EBATLARI (CM)";

                    NewField16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 62, 183, 67, false);
                    NewField16.Name = "NewField16";
                    NewField16.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField16.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField16.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField16.TextFont.Name = "Arial";
                    NewField16.TextFont.Bold = true;
                    NewField16.TextFont.CharSet = 162;
                    NewField16.Value = @"AĞIRLIK (KG)";

                    NewField17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 183, 62, 211, 67, false);
                    NewField17.Name = "NewField17";
                    NewField17.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField17.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField17.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField17.TextFont.Name = "Arial";
                    NewField17.TextFont.Bold = true;
                    NewField17.TextFont.CharSet = 162;
                    NewField17.Value = @"DEĞERİ (TL.)";

                    NewField18 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 211, 62, 257, 67, false);
                    NewField18.Name = "NewField18";
                    NewField18.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField18.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField18.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField18.TextFont.Name = "Arial";
                    NewField18.TextFont.Bold = true;
                    NewField18.TextFont.CharSet = 162;
                    NewField18.Value = @"AÇIKLAMALAR";

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 257, 30, 257, 67, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 30, 0, 67, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    MaintenanceOrder.GetMaintenanceOrderByObjectIDQuery_Class dataset_GetMaintenanceOrderByObjectIDQuery = ParentGroup.rsGroup.GetCurrentRecord<MaintenanceOrder.GetMaintenanceOrderByObjectIDQuery_Class>(0);
                    ORDERNO.CalcValue = (dataset_GetMaintenanceOrderByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderByObjectIDQuery.OrderNO) : "") + @"/" + (dataset_GetMaintenanceOrderByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderByObjectIDQuery.RequestNo) : "");
                    NewField1113.CalcValue = NewField1113.Value;
                    NewField111.CalcValue = NewField111.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField1.CalcValue = NewField1.Value;
                    REPORTNAME.CalcValue = REPORTNAME.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField121.CalcValue = NewField121.Value;
                    RECEIVERUNIT.CalcValue = (dataset_GetMaintenanceOrderByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderByObjectIDQuery.Rulobjectid) : "");
                    RECEIVERUNIT.PostFieldValueCalculation();
                    NewField2.CalcValue = NewField2.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField14.CalcValue = NewField14.Value;
                    NewField15.CalcValue = NewField15.Value;
                    NewField16.CalcValue = NewField16.Value;
                    NewField17.CalcValue = NewField17.Value;
                    NewField18.CalcValue = NewField18.Value;
                    SENDERUNIT.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "");
                    return new TTReportObject[] { ORDERNO,NewField1113,NewField111,NewField12,NewField1,REPORTNAME,NewField11,NewField121,RECEIVERUNIT,NewField2,NewField13,NewField14,NewField15,NewField16,NewField17,NewField18,SENDERUNIT};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public TeslimTesellumBelgesi MyParentReport
                {
                    get { return (TeslimTesellumBelgesi)ParentReport; }
                }
                
                public TTReportField TESLIM;
                public TTReportField TESLIM1;
                public TTReportField NewField1111;
                public TTReportField NewField11111;
                public TTReportField NewField1112;
                public TTReportField NewField12111;
                public TTReportField NewField12112;
                public TTReportField NewField12113;
                public TTReportField NewField12114;
                public TTReportShape NewLine3;
                public TTReportField MUAKONT;
                public TTReportField TESLIMEDEN;
                public TTReportField TESLIMEDEN2;
                public TTReportField UYE; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 83;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    TESLIM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), -1, 24, 256, 29, false);
                    TESLIM.Name = "TESLIM";
                    TESLIM.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TESLIM.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TESLIM.TextFont.Name = "Arial";
                    TESLIM.TextFont.Bold = true;
                    TESLIM.TextFont.CharSet = 162;
                    TESLIM.Value = @"YUKARIDAKİ MALZEMELER TAM VE SAĞLAM OLARAK TESLİM EDİLMİŞTİR.";

                    TESLIM1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), -1, 32, 256, 41, false);
                    TESLIM1.Name = "TESLIM1";
                    TESLIM1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TESLIM1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TESLIM1.TextFont.Name = "Arial";
                    TESLIM1.TextFont.Size = 14;
                    TESLIM1.TextFont.Bold = true;
                    TESLIM1.TextFont.CharSet = 162;
                    TESLIM1.Value = @"NOT : DİKKAT KIRILACAK HASSAS TIBBİ CİHAZ/MALZEMESİDİR! DİKKATLİ TAŞIYINIZ!";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 181, 1, 212, 6, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111.TextFont.Name = "Arial";
                    NewField1111.TextFont.Size = 8;
                    NewField1111.TextFont.Bold = true;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @"ÖLÇÜ ALINDIĞI TARİH";

                    NewField11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 216, 1, 255, 6, false);
                    NewField11111.Name = "NewField11111";
                    NewField11111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11111.TextFont.Name = "Arial";
                    NewField11111.TextFont.Size = 8;
                    NewField11111.TextFont.Bold = true;
                    NewField11111.TextFont.CharSet = 162;
                    NewField11111.Value = @"AMBALAJ YAPILDIĞI TARİH";

                    NewField1112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 46, 33, 51, false);
                    NewField1112.Name = "NewField1112";
                    NewField1112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1112.TextFont.Name = "Arial";
                    NewField1112.TextFont.Bold = true;
                    NewField1112.TextFont.CharSet = 162;
                    NewField1112.Value = @"TESLİM EDEN";

                    NewField12111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 147, 45, 175, 50, false);
                    NewField12111.Name = "NewField12111";
                    NewField12111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12111.TextFont.Name = "Arial";
                    NewField12111.TextFont.Bold = true;
                    NewField12111.TextFont.CharSet = 162;
                    NewField12111.Value = @"TESLİM EDEN";

                    NewField12112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 46, 72, 51, false);
                    NewField12112.Name = "NewField12112";
                    NewField12112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12112.TextFont.Name = "Arial";
                    NewField12112.TextFont.Bold = true;
                    NewField12112.TextFont.CharSet = 162;
                    NewField12112.Value = @"ÜYE";

                    NewField12113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 205, 46, 256, 51, false);
                    NewField12113.Name = "NewField12113";
                    NewField12113.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12113.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12113.TextFont.Name = "Arial";
                    NewField12113.TextFont.Bold = true;
                    NewField12113.TextFont.CharSet = 162;
                    NewField12113.Value = @"MUA.KONT. ve KLT.YNT.BL";

                    NewField12114 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 100, 46, 128, 51, false);
                    NewField12114.Name = "NewField12114";
                    NewField12114.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12114.TextFont.Name = "Arial";
                    NewField12114.TextFont.Bold = true;
                    NewField12114.TextFont.CharSet = 162;
                    NewField12114.Value = @"TESLİM ALAN";

                    NewLine3 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 0, 257, 0, false);
                    NewLine3.Name = "NewLine3";
                    NewLine3.DrawStyle = DrawStyleConstants.vbSolid;

                    MUAKONT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 205, 55, 256, 79, false);
                    MUAKONT.Name = "MUAKONT";
                    MUAKONT.FieldType = ReportFieldTypeEnum.ftVariable;
                    MUAKONT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MUAKONT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MUAKONT.MultiLine = EvetHayirEnum.ehEvet;
                    MUAKONT.WordBreak = EvetHayirEnum.ehEvet;
                    MUAKONT.TextFont.CharSet = 162;
                    MUAKONT.Value = @"";

                    TESLIMEDEN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), -1, 55, 35, 73, false);
                    TESLIMEDEN.Name = "TESLIMEDEN";
                    TESLIMEDEN.FieldType = ReportFieldTypeEnum.ftVariable;
                    TESLIMEDEN.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TESLIMEDEN.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TESLIMEDEN.MultiLine = EvetHayirEnum.ehEvet;
                    TESLIMEDEN.WordBreak = EvetHayirEnum.ehEvet;
                    TESLIMEDEN.TextFont.CharSet = 162;
                    TESLIMEDEN.Value = @"";

                    TESLIMEDEN2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 55, 186, 75, false);
                    TESLIMEDEN2.Name = "TESLIMEDEN2";
                    TESLIMEDEN2.FieldType = ReportFieldTypeEnum.ftVariable;
                    TESLIMEDEN2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TESLIMEDEN2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TESLIMEDEN2.MultiLine = EvetHayirEnum.ehEvet;
                    TESLIMEDEN2.WordBreak = EvetHayirEnum.ehEvet;
                    TESLIMEDEN2.TextFont.CharSet = 162;
                    TESLIMEDEN2.Value = @"";

                    UYE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 48, 55, 88, 73, false);
                    UYE.Name = "UYE";
                    UYE.FieldType = ReportFieldTypeEnum.ftVariable;
                    UYE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    UYE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    UYE.MultiLine = EvetHayirEnum.ehEvet;
                    UYE.WordBreak = EvetHayirEnum.ehEvet;
                    UYE.TextFont.CharSet = 162;
                    UYE.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    MaintenanceOrder.GetMaintenanceOrderByObjectIDQuery_Class dataset_GetMaintenanceOrderByObjectIDQuery = ParentGroup.rsGroup.GetCurrentRecord<MaintenanceOrder.GetMaintenanceOrderByObjectIDQuery_Class>(0);
                    TESLIM.CalcValue = TESLIM.Value;
                    TESLIM1.CalcValue = TESLIM1.Value;
                    NewField1111.CalcValue = NewField1111.Value;
                    NewField11111.CalcValue = NewField11111.Value;
                    NewField1112.CalcValue = NewField1112.Value;
                    NewField12111.CalcValue = NewField12111.Value;
                    NewField12112.CalcValue = NewField12112.Value;
                    NewField12113.CalcValue = NewField12113.Value;
                    NewField12114.CalcValue = NewField12114.Value;
                    MUAKONT.CalcValue = @"";
                    TESLIMEDEN.CalcValue = @"";
                    TESLIMEDEN2.CalcValue = @"";
                    UYE.CalcValue = @"";
                    return new TTReportObject[] { TESLIM,TESLIM1,NewField1111,NewField11111,NewField1112,NewField12111,NewField12112,NewField12113,NewField12114,MUAKONT,TESLIMEDEN,TESLIMEDEN2,UYE};
                }

                public override void RunScript()
                {
#region PARTA FOOTER_Script
                    if(this.MyParentReport.RuntimeParameters.PMUAKONT != System.Guid.Empty)
           {
                    if (this.MyParentReport.RuntimeParameters.PMUAKONT.HasValue)
                    {
                        ResUser muaKontR = (ResUser)this.ParentReport.ReportObjectContext.GetObject(this.MyParentReport.RuntimeParameters.PMUAKONT.Value, typeof(ResUser));

                        MUAKONT.CalcValue = "";
                        MUAKONT.CalcValue += "\r\n" + muaKontR.Name;
                        MUAKONT.CalcValue += (muaKontR.MilitaryClass != null) ? muaKontR.MilitaryClass.ShortName : "";
                        MUAKONT.CalcValue += (muaKontR.Rank != null) ? muaKontR.Rank.ShortName : "";
                        
                        MUAKONT.CalcValue += (muaKontR.EmploymentRecordID != null) ? "\r\n(" + muaKontR.EmploymentRecordID.ToString()+ ")":"";

                       // MUAKONT.CalcValue = muaKontR.Name;
                        
                    }
           }
           else
               MUAKONT.CalcValue = "";
           
           if(this.MyParentReport.RuntimeParameters.PTESLIMEDEN != System.Guid.Empty)
           {
                    if (this.MyParentReport.RuntimeParameters.PTESLIMEDEN.HasValue)
                    {
                        ResUser muaKontR = (ResUser)this.ParentReport.ReportObjectContext.GetObject(this.MyParentReport.RuntimeParameters.PTESLIMEDEN.Value, typeof(ResUser));
                        //TESLIMEDEN.CalcValue =  muaKontR.Name;

                        TESLIMEDEN.CalcValue = "";
                        TESLIMEDEN.CalcValue += "\r\n" + muaKontR.Name;
                        TESLIMEDEN.CalcValue += (muaKontR.MilitaryClass != null) ? muaKontR.MilitaryClass.ShortName : "";
                        TESLIMEDEN.CalcValue += (muaKontR.Rank != null) ? muaKontR.Rank.ShortName : "";
                        
                        TESLIMEDEN.CalcValue += (muaKontR.EmploymentRecordID != null) ? "\r\n(" + muaKontR.EmploymentRecordID.ToString() + ")" : "";
                    }
           }
           else
               TESLIMEDEN.CalcValue = "";
           
           if(this.MyParentReport.RuntimeParameters.PTESLIMEDEN2 != System.Guid.Empty)
           {
                    if (this.MyParentReport.RuntimeParameters.PTESLIMEDEN2.HasValue)
                    {
                        ResUser muaKontR = (ResUser)this.ParentReport.ReportObjectContext.GetObject(this.MyParentReport.RuntimeParameters.PTESLIMEDEN2.Value, typeof(ResUser));
                        //TESLIMEDEN2.CalcValue = muaKontR.Name;

                        TESLIMEDEN2.CalcValue = "";
                        TESLIMEDEN2.CalcValue += "\r\n" + muaKontR.Name;
                        TESLIMEDEN2.CalcValue += (muaKontR.MilitaryClass != null) ? muaKontR.MilitaryClass.ShortName : "";
                        TESLIMEDEN2.CalcValue += (muaKontR.Rank != null) ? muaKontR.Rank.ShortName : "";
                        
                        TESLIMEDEN2.CalcValue += (muaKontR.EmploymentRecordID != null) ? "\r\n(" + muaKontR.EmploymentRecordID.ToString() + ")" : "";
                    }
           }
           else
               TESLIMEDEN2.CalcValue= "";
           
           if(this.MyParentReport.RuntimeParameters.PUYE != System.Guid.Empty)
           {
                    if (this.MyParentReport.RuntimeParameters.PUYE.HasValue)
                    {
                        ResUser muaKontR = (ResUser)this.ParentReport.ReportObjectContext.GetObject(this.MyParentReport.RuntimeParameters.PUYE.Value, typeof(ResUser));
                       // UYE.CalcValue =  muaKontR.Name;

                        UYE.CalcValue = "";
                        UYE.CalcValue += "\r\n" + muaKontR.Name;
                        UYE.CalcValue += (muaKontR.MilitaryClass != null) ? muaKontR.MilitaryClass.ShortName : "";
                        UYE.CalcValue += (muaKontR.Rank != null) ? muaKontR.Rank.ShortName : "";
                        
                        UYE.CalcValue += (muaKontR.EmploymentRecordID != null) ? "\r\n(" + muaKontR.EmploymentRecordID.ToString() + ")" : "";
                       
                    }
           }
           else
                UYE.CalcValue ="";
#endregion PARTA FOOTER_Script
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class MAINGroup : TTReportGroup
        {
            public TeslimTesellumBelgesi MyParentReport
            {
                get { return (TeslimTesellumBelgesi)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField COUNT { get {return Body().COUNT;} }
            public TTReportField MATERIALNAME { get {return Body().MATERIALNAME;} }
            public TTReportField AMOUNT { get {return Body().AMOUNT;} }
            public TTReportField DIMENSIONS { get {return Body().DIMENSIONS;} }
            public TTReportField WEIGHT { get {return Body().WEIGHT;} }
            public TTReportField PRICE { get {return Body().PRICE;} }
            public TTReportField DESCRIPTION { get {return Body().DESCRIPTION;} }
            public TTReportShape NewLine1 { get {return Body().NewLine1;} }
            public TTReportShape NewLine11 { get {return Body().NewLine11;} }
            public TTReportShape NewLine12 { get {return Body().NewLine12;} }
            public TTReportShape NewLine13 { get {return Body().NewLine13;} }
            public TTReportShape NewLine14 { get {return Body().NewLine14;} }
            public TTReportShape NewLine15 { get {return Body().NewLine15;} }
            public TTReportShape NewLine16 { get {return Body().NewLine16;} }
            public TTReportShape NewLine17 { get {return Body().NewLine17;} }
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

                MaintenanceOrder.GetMaintenanceOrderByObjectIDQuery_Class dataSet_GetMaintenanceOrderByObjectIDQuery = ParentGroup.rsGroup.GetCurrentRecord<MaintenanceOrder.GetMaintenanceOrderByObjectIDQuery_Class>(0);    
                return new object[] {(dataSet_GetMaintenanceOrderByObjectIDQuery==null ? null : dataSet_GetMaintenanceOrderByObjectIDQuery.ObjectID)};
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
                public TeslimTesellumBelgesi MyParentReport
                {
                    get { return (TeslimTesellumBelgesi)ParentReport; }
                }
                
                public TTReportField COUNT;
                public TTReportField MATERIALNAME;
                public TTReportField AMOUNT;
                public TTReportField DIMENSIONS;
                public TTReportField WEIGHT;
                public TTReportField PRICE;
                public TTReportField DESCRIPTION;
                public TTReportShape NewLine1;
                public TTReportShape NewLine11;
                public TTReportShape NewLine12;
                public TTReportShape NewLine13;
                public TTReportShape NewLine14;
                public TTReportShape NewLine15;
                public TTReportShape NewLine16;
                public TTReportShape NewLine17; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 11;
                    RepeatCount = 0;
                    
                    COUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 21, 5, false);
                    COUNT.Name = "COUNT";
                    COUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    COUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    COUNT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    COUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    COUNT.TextFont.Name = "Arial";
                    COUNT.TextFont.CharSet = 162;
                    COUNT.Value = @"{@counter@}";

                    MATERIALNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 0, 103, 5, false);
                    MATERIALNAME.Name = "MATERIALNAME";
                    MATERIALNAME.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIALNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MATERIALNAME.TextFont.Name = "Arial";
                    MATERIALNAME.TextFont.CharSet = 162;
                    MATERIALNAME.Value = @"{#PARTA.FIXEDASSETNAME#}";

                    AMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 103, 0, 127, 5, false);
                    AMOUNT.Name = "AMOUNT";
                    AMOUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    AMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AMOUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AMOUNT.TextFont.Name = "Arial";
                    AMOUNT.TextFont.CharSet = 162;
                    AMOUNT.Value = @"{#PARTA.AMOUNT#} {#PARTA.DISTRIBUTIONTYPE#}";

                    DIMENSIONS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 127, 0, 155, 5, false);
                    DIMENSIONS.Name = "DIMENSIONS";
                    DIMENSIONS.DrawStyle = DrawStyleConstants.vbSolid;
                    DIMENSIONS.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIMENSIONS.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DIMENSIONS.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DIMENSIONS.TextFont.Name = "Arial";
                    DIMENSIONS.TextFont.CharSet = 162;
                    DIMENSIONS.Value = @"";

                    WEIGHT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 0, 183, 5, false);
                    WEIGHT.Name = "WEIGHT";
                    WEIGHT.DrawStyle = DrawStyleConstants.vbSolid;
                    WEIGHT.FieldType = ReportFieldTypeEnum.ftVariable;
                    WEIGHT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    WEIGHT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    WEIGHT.TextFont.Name = "Arial";
                    WEIGHT.TextFont.CharSet = 162;
                    WEIGHT.Value = @"";

                    PRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 183, 0, 211, 5, false);
                    PRICE.Name = "PRICE";
                    PRICE.DrawStyle = DrawStyleConstants.vbSolid;
                    PRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRICE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PRICE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PRICE.TextFont.Name = "Arial";
                    PRICE.TextFont.CharSet = 162;
                    PRICE.Value = @"";

                    DESCRIPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 211, 0, 257, 5, false);
                    DESCRIPTION.Name = "DESCRIPTION";
                    DESCRIPTION.DrawStyle = DrawStyleConstants.vbSolid;
                    DESCRIPTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTION.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DESCRIPTION.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DESCRIPTION.TextFont.Name = "Arial";
                    DESCRIPTION.TextFont.CharSet = 162;
                    DESCRIPTION.Value = @"";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 257, 0, 257, 5, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 211, 0, 211, 5, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 183, 0, 183, 5, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine12.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine13 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 155, 0, 155, 5, false);
                    NewLine13.Name = "NewLine13";
                    NewLine13.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine13.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine14 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 127, 0, 127, 5, false);
                    NewLine14.Name = "NewLine14";
                    NewLine14.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine14.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine15 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 103, 0, 103, 5, false);
                    NewLine15.Name = "NewLine15";
                    NewLine15.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine15.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine16 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 21, 0, 21, 5, false);
                    NewLine16.Name = "NewLine16";
                    NewLine16.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine16.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine17 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 0, 0, 5, false);
                    NewLine17.Name = "NewLine17";
                    NewLine17.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine17.ExtendTo = ExtendToEnum.extPageHeight;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    MaintenanceOrder.GetMaintenanceOrderByObjectIDQuery_Class dataset_GetMaintenanceOrderByObjectIDQuery = MyParentReport.PARTA.rsGroup.GetCurrentRecord<MaintenanceOrder.GetMaintenanceOrderByObjectIDQuery_Class>(0);
                    COUNT.CalcValue = ParentGroup.Counter.ToString();
                    MATERIALNAME.CalcValue = (dataset_GetMaintenanceOrderByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderByObjectIDQuery.Fixedassetname) : "");
                    AMOUNT.CalcValue = (dataset_GetMaintenanceOrderByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderByObjectIDQuery.Amount) : "") + @" " + (dataset_GetMaintenanceOrderByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderByObjectIDQuery.DistributionType) : "");
                    DIMENSIONS.CalcValue = @"";
                    WEIGHT.CalcValue = @"";
                    PRICE.CalcValue = @"";
                    DESCRIPTION.CalcValue = @"";
                    return new TTReportObject[] { COUNT,MATERIALNAME,AMOUNT,DIMENSIONS,WEIGHT,PRICE,DESCRIPTION};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public TeslimTesellumBelgesi()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            MAIN = new MAINGroup(PARTA,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter = Parameters.Add("PTESLIMEDEN", "00000000-0000-0000-0000-000000000000", "Teslim Eden", @"", false, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("f8fdd898-ea3c-45a4-abcd-d6362e52064c");
            reportParameter = Parameters.Add("PTESLIMEDEN2", "00000000-0000-0000-0000-000000000000", "Teslim Eden", @"", false, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("f8fdd898-ea3c-45a4-abcd-d6362e52064c");
            reportParameter = Parameters.Add("PUYE", "00000000-0000-0000-0000-000000000000", "Üye", @"", false, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("f8fdd898-ea3c-45a4-abcd-d6362e52064c");
            reportParameter = Parameters.Add("PMUAKONT", "00000000-0000-0000-0000-000000000000", "MUA. KONT. ve KLT. YNT. BL.", @"", false, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("f8fdd898-ea3c-45a4-abcd-d6362e52064c");
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            if (parameters.ContainsKey("PTESLIMEDEN"))
                _runtimeParameters.PTESLIMEDEN = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["PTESLIMEDEN"]);
            if (parameters.ContainsKey("PTESLIMEDEN2"))
                _runtimeParameters.PTESLIMEDEN2 = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["PTESLIMEDEN2"]);
            if (parameters.ContainsKey("PUYE"))
                _runtimeParameters.PUYE = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["PUYE"]);
            if (parameters.ContainsKey("PMUAKONT"))
                _runtimeParameters.PMUAKONT = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["PMUAKONT"]);
            Name = "TESLIMTESELLUMBELGESI";
            Caption = "Teslim Tesellüm Belgesi";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oeLandscape;
            UserMarginLeft = 25;
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
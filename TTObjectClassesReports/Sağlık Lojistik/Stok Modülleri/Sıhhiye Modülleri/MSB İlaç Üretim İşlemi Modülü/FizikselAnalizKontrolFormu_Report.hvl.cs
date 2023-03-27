
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
    /// Fiziksel Analiz Kontrol Formu
    /// </summary>
    public partial class FizikselAnalizKontrolFormu : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class PARTBGroup : TTReportGroup
        {
            public FizikselAnalizKontrolFormu MyParentReport
            {
                get { return (FizikselAnalizKontrolFormu)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField NewField8 { get {return Header().NewField8;} }
            public TTReportField XXXXXXBASLIK { get {return Header().XXXXXXBASLIK;} }
            public TTReportField XXXXXXLOGO { get {return Header().XXXXXXLOGO;} }
            public TTReportField NewField7 { get {return Header().NewField7;} }
            public TTReportField FORMBASLIGI { get {return Header().FORMBASLIGI;} }
            public TTReportField TRANSACTIONDATE { get {return Header().TRANSACTIONDATE;} }
            public TTReportField NewField19 { get {return Header().NewField19;} }
            public TTReportField NewField20 { get {return Header().NewField20;} }
            public TTReportField PRODUCEDMATERIALNAME { get {return Header().PRODUCEDMATERIALNAME;} }
            public TTReportField NewField192 { get {return Header().NewField192;} }
            public TTReportField NewField103 { get {return Header().NewField103;} }
            public TTReportField FORMBASLIGI1 { get {return Header().FORMBASLIGI1;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportShape NewRect1 { get {return Header().NewRect1;} }
            public TTReportShape NewRect11 { get {return Header().NewRect11;} }
            public TTReportField BANewField12 { get {return Header().BANewField12;} }
            public TTReportField NewField112 { get {return Header().NewField112;} }
            public TTReportField NewField1111 { get {return Header().NewField1111;} }
            public TTReportShape NewRect12 { get {return Header().NewRect12;} }
            public TTReportShape NewRect111 { get {return Header().NewRect111;} }
            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportField NewField1211 { get {return Header().NewField1211;} }
            public TTReportField NewField11111 { get {return Header().NewField11111;} }
            public TTReportShape NewRect121 { get {return Header().NewRect121;} }
            public TTReportShape NewRect1111 { get {return Header().NewRect1111;} }
            public TTReportField NewField1121 { get {return Header().NewField1121;} }
            public TTReportField NewField11121 { get {return Header().NewField11121;} }
            public TTReportField NewField111111 { get {return Header().NewField111111;} }
            public TTReportShape NewRect1121 { get {return Header().NewRect1121;} }
            public TTReportShape NewRect11111 { get {return Header().NewRect11111;} }
            public TTReportField NewField11211 { get {return Header().NewField11211;} }
            public TTReportField NewField112111 { get {return Header().NewField112111;} }
            public TTReportField NewField1111111 { get {return Header().NewField1111111;} }
            public TTReportShape NewRect11211 { get {return Header().NewRect11211;} }
            public TTReportShape NewRect111111 { get {return Header().NewRect111111;} }
            public TTReportField NewField111211 { get {return Header().NewField111211;} }
            public TTReportField NewField1111211 { get {return Header().NewField1111211;} }
            public TTReportField NewField11111111 { get {return Header().NewField11111111;} }
            public TTReportShape NewRect111211 { get {return Header().NewRect111211;} }
            public TTReportShape NewRect1111111 { get {return Header().NewRect1111111;} }
            public TTReportField FORMBASLIGI11 { get {return Header().FORMBASLIGI11;} }
            public TTReportField NewField13 { get {return Header().NewField13;} }
            public TTReportField NewField113 { get {return Header().NewField113;} }
            public TTReportField NewField1112 { get {return Header().NewField1112;} }
            public TTReportShape NewRect13 { get {return Header().NewRect13;} }
            public TTReportShape NewRect112 { get {return Header().NewRect112;} }
            public TTReportField NewField131 { get {return Header().NewField131;} }
            public TTReportField NewField1311 { get {return Header().NewField1311;} }
            public TTReportField NewField12111 { get {return Header().NewField12111;} }
            public TTReportShape NewRect131 { get {return Header().NewRect131;} }
            public TTReportShape NewRect1211 { get {return Header().NewRect1211;} }
            public TTReportField NewField1131 { get {return Header().NewField1131;} }
            public TTReportField NewField11131 { get {return Header().NewField11131;} }
            public TTReportField NewField111121 { get {return Header().NewField111121;} }
            public TTReportShape NewRect1131 { get {return Header().NewRect1131;} }
            public TTReportShape NewRect11121 { get {return Header().NewRect11121;} }
            public TTReportField NewField11311 { get {return Header().NewField11311;} }
            public TTReportField NewField113111 { get {return Header().NewField113111;} }
            public TTReportField NewField1121111 { get {return Header().NewField1121111;} }
            public TTReportShape NewRect11311 { get {return Header().NewRect11311;} }
            public TTReportShape NewRect112111 { get {return Header().NewRect112111;} }
            public TTReportField NewField111311 { get {return Header().NewField111311;} }
            public TTReportField NewField1111311 { get {return Header().NewField1111311;} }
            public TTReportField NewField11111211 { get {return Header().NewField11111211;} }
            public TTReportShape NewRect111311 { get {return Header().NewRect111311;} }
            public TTReportShape NewRect1111211 { get {return Header().NewRect1111211;} }
            public TTReportField NewField1113111 { get {return Header().NewField1113111;} }
            public TTReportField NewField11131111 { get {return Header().NewField11131111;} }
            public TTReportField NewField111211111 { get {return Header().NewField111211111;} }
            public TTReportShape NewRect1113111 { get {return Header().NewRect1113111;} }
            public TTReportShape NewRect11121111 { get {return Header().NewRect11121111;} }
            public TTReportField NewField11113111 { get {return Header().NewField11113111;} }
            public TTReportField NewField111113111 { get {return Header().NewField111113111;} }
            public TTReportField NewField1111112111 { get {return Header().NewField1111112111;} }
            public TTReportShape NewRect11113111 { get {return Header().NewRect11113111;} }
            public TTReportShape NewRect111112111 { get {return Header().NewRect111112111;} }
            public TTReportField IANewField12 { get {return Header().IANewField12;} }
            public TTReportField IANewField13 { get {return Header().IANewField13;} }
            public TTReportField IANewField14 { get {return Header().IANewField14;} }
            public TTReportShape IANewRect16 { get {return Header().IANewRect16;} }
            public TTReportShape IANewRect15 { get {return Header().IANewRect15;} }
            public TTReportField NewField1112111 { get {return Header().NewField1112111;} }
            public TTReportField NewField11121111 { get {return Header().NewField11121111;} }
            public TTReportField NewField111111111 { get {return Header().NewField111111111;} }
            public TTReportShape NewRect1112111 { get {return Header().NewRect1112111;} }
            public TTReportShape NewRect11111111 { get {return Header().NewRect11111111;} }
            public TTReportField NewField11112111 { get {return Header().NewField11112111;} }
            public TTReportField NewField111112111 { get {return Header().NewField111112111;} }
            public TTReportField NewField1111111111 { get {return Header().NewField1111111111;} }
            public TTReportShape NewRect11112111 { get {return Header().NewRect11112111;} }
            public TTReportShape NewRect111111111 { get {return Header().NewRect111111111;} }
            public TTReportField FORMBASLIGI111 { get {return Header().FORMBASLIGI111;} }
            public TTReportField TANewField17 { get {return Header().TANewField17;} }
            public TTReportField TANewField18 { get {return Header().TANewField18;} }
            public TTReportField TANewField19 { get {return Header().TANewField19;} }
            public TTReportShape NewRect21 { get {return Header().NewRect21;} }
            public TTReportShape NewRect20 { get {return Header().NewRect20;} }
            public TTReportField NewField122 { get {return Header().NewField122;} }
            public TTReportField NewField132 { get {return Header().NewField132;} }
            public TTReportField NewField141 { get {return Header().NewField141;} }
            public TTReportShape NewRect161 { get {return Header().NewRect161;} }
            public TTReportShape NewRect151 { get {return Header().NewRect151;} }
            public TTReportField REQUESTUSERDETAIL { get {return Footer().REQUESTUSERDETAIL;} }
            public TTReportField APPROVEDUSERDETAIL { get {return Footer().APPROVEDUSERDETAIL;} }
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
                public FizikselAnalizKontrolFormu MyParentReport
                {
                    get { return (FizikselAnalizKontrolFormu)ParentReport; }
                }
                
                public TTReportField NewField8;
                public TTReportField XXXXXXBASLIK;
                public TTReportField XXXXXXLOGO;
                public TTReportField NewField7;
                public TTReportField FORMBASLIGI;
                public TTReportField TRANSACTIONDATE;
                public TTReportField NewField19;
                public TTReportField NewField20;
                public TTReportField PRODUCEDMATERIALNAME;
                public TTReportField NewField192;
                public TTReportField NewField103;
                public TTReportField FORMBASLIGI1;
                public TTReportField NewField1;
                public TTReportField NewField11;
                public TTReportField NewField111;
                public TTReportShape NewRect1;
                public TTReportShape NewRect11;
                public TTReportField BANewField12;
                public TTReportField NewField112;
                public TTReportField NewField1111;
                public TTReportShape NewRect12;
                public TTReportShape NewRect111;
                public TTReportField NewField121;
                public TTReportField NewField1211;
                public TTReportField NewField11111;
                public TTReportShape NewRect121;
                public TTReportShape NewRect1111;
                public TTReportField NewField1121;
                public TTReportField NewField11121;
                public TTReportField NewField111111;
                public TTReportShape NewRect1121;
                public TTReportShape NewRect11111;
                public TTReportField NewField11211;
                public TTReportField NewField112111;
                public TTReportField NewField1111111;
                public TTReportShape NewRect11211;
                public TTReportShape NewRect111111;
                public TTReportField NewField111211;
                public TTReportField NewField1111211;
                public TTReportField NewField11111111;
                public TTReportShape NewRect111211;
                public TTReportShape NewRect1111111;
                public TTReportField FORMBASLIGI11;
                public TTReportField NewField13;
                public TTReportField NewField113;
                public TTReportField NewField1112;
                public TTReportShape NewRect13;
                public TTReportShape NewRect112;
                public TTReportField NewField131;
                public TTReportField NewField1311;
                public TTReportField NewField12111;
                public TTReportShape NewRect131;
                public TTReportShape NewRect1211;
                public TTReportField NewField1131;
                public TTReportField NewField11131;
                public TTReportField NewField111121;
                public TTReportShape NewRect1131;
                public TTReportShape NewRect11121;
                public TTReportField NewField11311;
                public TTReportField NewField113111;
                public TTReportField NewField1121111;
                public TTReportShape NewRect11311;
                public TTReportShape NewRect112111;
                public TTReportField NewField111311;
                public TTReportField NewField1111311;
                public TTReportField NewField11111211;
                public TTReportShape NewRect111311;
                public TTReportShape NewRect1111211;
                public TTReportField NewField1113111;
                public TTReportField NewField11131111;
                public TTReportField NewField111211111;
                public TTReportShape NewRect1113111;
                public TTReportShape NewRect11121111;
                public TTReportField NewField11113111;
                public TTReportField NewField111113111;
                public TTReportField NewField1111112111;
                public TTReportShape NewRect11113111;
                public TTReportShape NewRect111112111;
                public TTReportField IANewField12;
                public TTReportField IANewField13;
                public TTReportField IANewField14;
                public TTReportShape IANewRect16;
                public TTReportShape IANewRect15;
                public TTReportField NewField1112111;
                public TTReportField NewField11121111;
                public TTReportField NewField111111111;
                public TTReportShape NewRect1112111;
                public TTReportShape NewRect11111111;
                public TTReportField NewField11112111;
                public TTReportField NewField111112111;
                public TTReportField NewField1111111111;
                public TTReportShape NewRect11112111;
                public TTReportShape NewRect111111111;
                public TTReportField FORMBASLIGI111;
                public TTReportField TANewField17;
                public TTReportField TANewField18;
                public TTReportField TANewField19;
                public TTReportShape NewRect21;
                public TTReportShape NewRect20;
                public TTReportField NewField122;
                public TTReportField NewField132;
                public TTReportField NewField141;
                public TTReportShape NewRect161;
                public TTReportShape NewRect151; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 207;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 47, 61, 52, false);
                    NewField8.Name = "NewField8";
                    NewField8.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField8.TextFont.Name = "Arial";
                    NewField8.TextFont.Size = 11;
                    NewField8.TextFont.Bold = true;
                    NewField8.Value = @":";

                    XXXXXXBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 57, 10, 200, 33, false);
                    XXXXXXBASLIK.Name = "XXXXXXBASLIK";
                    XXXXXXBASLIK.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXBASLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.TextFont.Name = "Arial";
                    XXXXXXBASLIK.TextFont.Size = 12;
                    XXXXXXBASLIK.TextFont.Bold = true;
                    XXXXXXBASLIK.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + ""\r\n"" + TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    XXXXXXLOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 10, 56, 30, false);
                    XXXXXXLOGO.Name = "XXXXXXLOGO";
                    XXXXXXLOGO.TextFont.CharSet = 1;
                    XXXXXXLOGO.Value = @"";

                    NewField7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 47, 58, 52, false);
                    NewField7.Name = "NewField7";
                    NewField7.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField7.TextFont.Name = "Arial";
                    NewField7.TextFont.Size = 11;
                    NewField7.TextFont.Bold = true;
                    NewField7.Value = @"Kontrol Tarihi";

                    FORMBASLIGI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 34, 200, 40, false);
                    FORMBASLIGI.Name = "FORMBASLIGI";
                    FORMBASLIGI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    FORMBASLIGI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FORMBASLIGI.TextFont.Name = "Arial";
                    FORMBASLIGI.TextFont.Size = 12;
                    FORMBASLIGI.TextFont.Bold = true;
                    FORMBASLIGI.Value = @"FİZİKSEL ANALİZ KONTROL FORMU";

                    TRANSACTIONDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 47, 95, 52, false);
                    TRANSACTIONDATE.Name = "TRANSACTIONDATE";
                    TRANSACTIONDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TRANSACTIONDATE.TextFormat = @"dd/MM/yyyy";
                    TRANSACTIONDATE.ObjectDefName = "DrugProductionTest";
                    TRANSACTIONDATE.DataMember = "TRANSACTIONDATE";
                    TRANSACTIONDATE.TextFont.Name = "Arial";
                    TRANSACTIONDATE.TextFont.Size = 11;
                    TRANSACTIONDATE.Value = @"{@TTOBJECTID@}";

                    NewField19 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 53, 61, 58, false);
                    NewField19.Name = "NewField19";
                    NewField19.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField19.TextFont.Name = "Arial";
                    NewField19.TextFont.Size = 11;
                    NewField19.TextFont.Bold = true;
                    NewField19.Value = @":";

                    NewField20 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 53, 58, 58, false);
                    NewField20.Name = "NewField20";
                    NewField20.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField20.TextFont.Name = "Arial";
                    NewField20.TextFont.Size = 11;
                    NewField20.TextFont.Bold = true;
                    NewField20.Value = @"Kontrol Edilen Ürünler";

                    PRODUCEDMATERIALNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 53, 200, 58, false);
                    PRODUCEDMATERIALNAME.Name = "PRODUCEDMATERIALNAME";
                    PRODUCEDMATERIALNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRODUCEDMATERIALNAME.ObjectDefName = "DrugProductionTest";
                    PRODUCEDMATERIALNAME.DataMember = "DRUGPRODUCTIONPROCEDURE.PRODUCEDMATERIAL.MATERIAL.NAME";
                    PRODUCEDMATERIALNAME.TextFont.Name = "Arial";
                    PRODUCEDMATERIALNAME.TextFont.Size = 11;
                    PRODUCEDMATERIALNAME.Value = @"{@TTOBJECTID@}";

                    NewField192 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 59, 61, 64, false);
                    NewField192.Name = "NewField192";
                    NewField192.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField192.TextFont.Name = "Arial";
                    NewField192.TextFont.Size = 11;
                    NewField192.TextFont.Bold = true;
                    NewField192.Value = @":";

                    NewField103 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 59, 58, 64, false);
                    NewField103.Name = "NewField103";
                    NewField103.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField103.TextFont.Name = "Arial";
                    NewField103.TextFont.Size = 11;
                    NewField103.TextFont.Bold = true;
                    NewField103.Value = @"Aksaklık Görülen Ürün";

                    FORMBASLIGI1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 66, 200, 72, false);
                    FORMBASLIGI1.Name = "FORMBASLIGI1";
                    FORMBASLIGI1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    FORMBASLIGI1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FORMBASLIGI1.TextFont.Name = "Arial";
                    FORMBASLIGI1.TextFont.Size = 12;
                    FORMBASLIGI1.TextFont.Bold = true;
                    FORMBASLIGI1.Value = @"BİRİNCİL AMBALAJ";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 72, 130, 77, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1.TextFont.Name = "Arial Narrow";
                    NewField1.Value = @"Seri numarası okunaklı ve tam olarak yazılmış mı?";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 130, 72, 155, 77, false);
                    NewField11.Name = "NewField11";
                    NewField11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11.TextFont.Name = "Arial Narrow";
                    NewField11.Value = @"      Uygun";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 72, 200, 77, false);
                    NewField111.Name = "NewField111";
                    NewField111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111.TextFont.Name = "Arial Narrow";
                    NewField111.Value = @"      Uygun Değildir";

                    NewRect1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 131, 73, 134, 76, false);
                    NewRect1.Name = "NewRect1";
                    NewRect1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewRect11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 156, 73, 159, 76, false);
                    NewRect11.Name = "NewRect11";
                    NewRect11.DrawStyle = DrawStyleConstants.vbSolid;

                    BANewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 77, 130, 82, false);
                    BANewField12.Name = "BANewField12";
                    BANewField12.DrawStyle = DrawStyleConstants.vbSolid;
                    BANewField12.TextFont.Name = "Arial Narrow";
                    BANewField12.Value = @"Mamül madde okunaklı ve tam olarak yazılmış mı?";

                    NewField112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 130, 77, 155, 82, false);
                    NewField112.Name = "NewField112";
                    NewField112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112.TextFont.Name = "Arial Narrow";
                    NewField112.Value = @"      Uygun";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 77, 200, 82, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111.TextFont.Name = "Arial Narrow";
                    NewField1111.Value = @"      Uygun Değildir";

                    NewRect12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 131, 78, 134, 81, false);
                    NewRect12.Name = "NewRect12";
                    NewRect12.DrawStyle = DrawStyleConstants.vbSolid;

                    NewRect111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 156, 78, 159, 81, false);
                    NewRect111.Name = "NewRect111";
                    NewRect111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 82, 130, 87, false);
                    NewField121.Name = "NewField121";
                    NewField121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField121.TextFont.Name = "Arial Narrow";
                    NewField121.Value = @"Etkin madde ismi ve miktarı okunaklı ve tam yazılmış mı?";

                    NewField1211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 130, 82, 155, 87, false);
                    NewField1211.Name = "NewField1211";
                    NewField1211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1211.TextFont.Name = "Arial Narrow";
                    NewField1211.Value = @"      Uygun";

                    NewField11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 82, 200, 87, false);
                    NewField11111.Name = "NewField11111";
                    NewField11111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11111.TextFont.Name = "Arial Narrow";
                    NewField11111.Value = @"      Uygun Değildir";

                    NewRect121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 131, 83, 134, 86, false);
                    NewRect121.Name = "NewRect121";
                    NewRect121.DrawStyle = DrawStyleConstants.vbSolid;

                    NewRect1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 156, 83, 159, 86, false);
                    NewRect1111.Name = "NewRect1111";
                    NewRect1111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 87, 130, 92, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1121.TextFont.Name = "Arial Narrow";
                    NewField1121.Value = @"Primer ambalaj üzerinde fabrika adı var mı?";

                    NewField11121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 130, 87, 155, 92, false);
                    NewField11121.Name = "NewField11121";
                    NewField11121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11121.TextFont.Name = "Arial Narrow";
                    NewField11121.Value = @"      Uygun";

                    NewField111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 87, 200, 92, false);
                    NewField111111.Name = "NewField111111";
                    NewField111111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111111.TextFont.Name = "Arial Narrow";
                    NewField111111.Value = @"      Uygun Değildir";

                    NewRect1121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 131, 88, 134, 91, false);
                    NewRect1121.Name = "NewRect1121";
                    NewRect1121.DrawStyle = DrawStyleConstants.vbSolid;

                    NewRect11111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 156, 88, 159, 91, false);
                    NewRect11111.Name = "NewRect11111";
                    NewRect11111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField11211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 92, 130, 101, false);
                    NewField11211.Name = "NewField11211";
                    NewField11211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11211.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11211.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11211.TextFont.Name = "Arial Narrow";
                    NewField11211.Value = @"Ürün primer ambalajdan rahatlıkla çıkıyor mu? Çıkarken deforme (kırılma, kapak atma, ezilme vs.) oluyor mu?";

                    NewField112111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 130, 92, 155, 101, false);
                    NewField112111.Name = "NewField112111";
                    NewField112111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112111.TextFont.Name = "Arial Narrow";
                    NewField112111.Value = @"      Uygun";

                    NewField1111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 92, 200, 101, false);
                    NewField1111111.Name = "NewField1111111";
                    NewField1111111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111111.TextFont.Name = "Arial Narrow";
                    NewField1111111.Value = @"      Uygun Değildir";

                    NewRect11211 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 131, 95, 134, 98, false);
                    NewRect11211.Name = "NewRect11211";
                    NewRect11211.DrawStyle = DrawStyleConstants.vbSolid;

                    NewRect111111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 156, 95, 159, 98, false);
                    NewRect111111.Name = "NewRect111111";
                    NewRect111111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField111211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 101, 130, 110, false);
                    NewField111211.Name = "NewField111211";
                    NewField111211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111211.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111211.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111211.TextFont.Name = "Arial Narrow";
                    NewField111211.Value = @"Blisterleme sırasında primer ambalaj ve üzerinde, kırılma, çatlak, renk değişikliği, kapak atma ve hava boşluğu vs. var mı?";

                    NewField1111211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 130, 101, 155, 110, false);
                    NewField1111211.Name = "NewField1111211";
                    NewField1111211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111211.TextFont.Name = "Arial Narrow";
                    NewField1111211.Value = @"      Uygun";

                    NewField11111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 101, 200, 110, false);
                    NewField11111111.Name = "NewField11111111";
                    NewField11111111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11111111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11111111.TextFont.Name = "Arial Narrow";
                    NewField11111111.Value = @"      Uygun Değildir";

                    NewRect111211 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 131, 104, 134, 107, false);
                    NewRect111211.Name = "NewRect111211";
                    NewRect111211.DrawStyle = DrawStyleConstants.vbSolid;

                    NewRect1111111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 156, 104, 159, 107, false);
                    NewRect1111111.Name = "NewRect1111111";
                    NewRect1111111.DrawStyle = DrawStyleConstants.vbSolid;

                    FORMBASLIGI11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 114, 200, 120, false);
                    FORMBASLIGI11.Name = "FORMBASLIGI11";
                    FORMBASLIGI11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    FORMBASLIGI11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FORMBASLIGI11.TextFont.Name = "Arial";
                    FORMBASLIGI11.TextFont.Size = 12;
                    FORMBASLIGI11.TextFont.Bold = true;
                    FORMBASLIGI11.Value = @"İKİNCİL AMBALAJ";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 120, 130, 125, false);
                    NewField13.Name = "NewField13";
                    NewField13.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField13.TextFont.Name = "Arial Narrow";
                    NewField13.Value = @"Seri numarası ve Nato Stok numarası tam yazılmış mı? Okunaklı mı?";

                    NewField113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 130, 120, 155, 125, false);
                    NewField113.Name = "NewField113";
                    NewField113.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField113.TextFont.Name = "Arial Narrow";
                    NewField113.Value = @"      Uygun";

                    NewField1112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 120, 200, 125, false);
                    NewField1112.Name = "NewField1112";
                    NewField1112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1112.TextFont.Name = "Arial Narrow";
                    NewField1112.Value = @"      Uygun Değildir";

                    NewRect13 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 131, 121, 134, 124, false);
                    NewRect13.Name = "NewRect13";
                    NewRect13.DrawStyle = DrawStyleConstants.vbSolid;

                    NewRect112 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 156, 121, 159, 124, false);
                    NewRect112.Name = "NewRect112";
                    NewRect112.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 125, 130, 130, false);
                    NewField131.Name = "NewField131";
                    NewField131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField131.TextFont.Name = "Arial Narrow";
                    NewField131.Value = @"Mamül madde ismi yazılmış ve okunaklı mı?";

                    NewField1311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 130, 125, 155, 130, false);
                    NewField1311.Name = "NewField1311";
                    NewField1311.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1311.TextFont.Name = "Arial Narrow";
                    NewField1311.Value = @"      Uygun";

                    NewField12111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 125, 200, 130, false);
                    NewField12111.Name = "NewField12111";
                    NewField12111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12111.TextFont.Name = "Arial Narrow";
                    NewField12111.Value = @"      Uygun Değildir";

                    NewRect131 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 131, 126, 134, 129, false);
                    NewRect131.Name = "NewRect131";
                    NewRect131.DrawStyle = DrawStyleConstants.vbSolid;

                    NewRect1211 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 156, 126, 159, 129, false);
                    NewRect1211.Name = "NewRect1211";
                    NewRect1211.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField1131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 130, 130, 135, false);
                    NewField1131.Name = "NewField1131";
                    NewField1131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1131.TextFont.Name = "Arial Narrow";
                    NewField1131.Value = @"Etkin madde ismi ve miktarı yazılmış mı?";

                    NewField11131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 130, 130, 155, 135, false);
                    NewField11131.Name = "NewField11131";
                    NewField11131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11131.TextFont.Name = "Arial Narrow";
                    NewField11131.Value = @"      Uygun";

                    NewField111121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 130, 200, 135, false);
                    NewField111121.Name = "NewField111121";
                    NewField111121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111121.TextFont.Name = "Arial Narrow";
                    NewField111121.Value = @"      Uygun Değildir";

                    NewRect1131 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 131, 131, 134, 134, false);
                    NewRect1131.Name = "NewRect1131";
                    NewRect1131.DrawStyle = DrawStyleConstants.vbSolid;

                    NewRect11121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 156, 131, 159, 134, false);
                    NewRect11121.Name = "NewRect11121";
                    NewRect11121.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField11311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 135, 130, 140, false);
                    NewField11311.Name = "NewField11311";
                    NewField11311.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11311.TextFont.Name = "Arial Narrow";
                    NewField11311.Value = @"İmal tarihi ve son kullanma tarihi yazılmış mı? Okunaklı mı?";

                    NewField113111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 130, 135, 155, 140, false);
                    NewField113111.Name = "NewField113111";
                    NewField113111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField113111.TextFont.Name = "Arial Narrow";
                    NewField113111.Value = @"      Uygun";

                    NewField1121111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 135, 200, 140, false);
                    NewField1121111.Name = "NewField1121111";
                    NewField1121111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1121111.TextFont.Name = "Arial Narrow";
                    NewField1121111.Value = @"      Uygun Değildir";

                    NewRect11311 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 131, 136, 134, 139, false);
                    NewRect11311.Name = "NewRect11311";
                    NewRect11311.DrawStyle = DrawStyleConstants.vbSolid;

                    NewRect112111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 156, 136, 159, 139, false);
                    NewRect112111.Name = "NewRect112111";
                    NewRect112111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField111311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 140, 130, 145, false);
                    NewField111311.Name = "NewField111311";
                    NewField111311.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111311.TextFont.Name = "Arial Narrow";
                    NewField111311.Value = @"Üretim yeri ve adresi yazılmış mı?";

                    NewField1111311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 130, 140, 155, 145, false);
                    NewField1111311.Name = "NewField1111311";
                    NewField1111311.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111311.TextFont.Name = "Arial Narrow";
                    NewField1111311.Value = @"      Uygun";

                    NewField11111211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 140, 200, 145, false);
                    NewField11111211.Name = "NewField11111211";
                    NewField11111211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11111211.TextFont.Name = "Arial Narrow";
                    NewField11111211.Value = @"      Uygun Değildir";

                    NewRect111311 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 131, 141, 134, 144, false);
                    NewRect111311.Name = "NewRect111311";
                    NewRect111311.DrawStyle = DrawStyleConstants.vbSolid;

                    NewRect1111211 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 156, 141, 159, 144, false);
                    NewRect1111211.Name = "NewRect1111211";
                    NewRect1111211.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField1113111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 145, 130, 150, false);
                    NewField1113111.Name = "NewField1113111";
                    NewField1113111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1113111.TextFont.Name = "Arial Narrow";
                    NewField1113111.Value = @"Uyarılar ve ürün adedi belirtilmiş mi?";

                    NewField11131111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 130, 145, 155, 150, false);
                    NewField11131111.Name = "NewField11131111";
                    NewField11131111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11131111.TextFont.Name = "Arial Narrow";
                    NewField11131111.Value = @"      Uygun";

                    NewField111211111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 145, 200, 150, false);
                    NewField111211111.Name = "NewField111211111";
                    NewField111211111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111211111.TextFont.Name = "Arial Narrow";
                    NewField111211111.Value = @"      Uygun Değildir";

                    NewRect1113111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 131, 146, 134, 149, false);
                    NewRect1113111.Name = "NewRect1113111";
                    NewRect1113111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewRect11121111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 156, 146, 159, 149, false);
                    NewRect11121111.Name = "NewRect11121111";
                    NewRect11121111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField11113111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 150, 130, 155, false);
                    NewField11113111.Name = "NewField11113111";
                    NewField11113111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11113111.TextFont.Name = "Arial Narrow";
                    NewField11113111.Value = @"Sekonder ambalaj ve içerisinde ürüne ait prospektüs var mı?";

                    NewField111113111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 130, 150, 155, 155, false);
                    NewField111113111.Name = "NewField111113111";
                    NewField111113111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111113111.TextFont.Name = "Arial Narrow";
                    NewField111113111.Value = @"      Uygun";

                    NewField1111112111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 150, 200, 155, false);
                    NewField1111112111.Name = "NewField1111112111";
                    NewField1111112111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111112111.TextFont.Name = "Arial Narrow";
                    NewField1111112111.Value = @"      Uygun Değildir";

                    NewRect11113111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 131, 151, 134, 154, false);
                    NewRect11113111.Name = "NewRect11113111";
                    NewRect11113111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewRect111112111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 156, 151, 159, 154, false);
                    NewRect111112111.Name = "NewRect111112111";
                    NewRect111112111.DrawStyle = DrawStyleConstants.vbSolid;

                    IANewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 155, 130, 160, false);
                    IANewField12.Name = "IANewField12";
                    IANewField12.DrawStyle = DrawStyleConstants.vbSolid;
                    IANewField12.TextFont.Name = "Arial Narrow";
                    IANewField12.Value = @"Sekonder ambalajda deformasyon (yırtık, ezilme, renk kayıbı vs.) var mı?";

                    IANewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 130, 155, 155, 160, false);
                    IANewField13.Name = "IANewField13";
                    IANewField13.DrawStyle = DrawStyleConstants.vbSolid;
                    IANewField13.TextFont.Name = "Arial Narrow";
                    IANewField13.Value = @"      Uygun";

                    IANewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 155, 200, 160, false);
                    IANewField14.Name = "IANewField14";
                    IANewField14.DrawStyle = DrawStyleConstants.vbSolid;
                    IANewField14.TextFont.Name = "Arial Narrow";
                    IANewField14.Value = @"      Uygun Değildir";

                    IANewRect16 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 131, 156, 134, 159, false);
                    IANewRect16.Name = "IANewRect16";
                    IANewRect16.DrawStyle = DrawStyleConstants.vbSolid;

                    IANewRect15 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 156, 156, 159, 159, false);
                    IANewRect15.Name = "IANewRect15";
                    IANewRect15.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField1112111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 160, 130, 169, false);
                    NewField1112111.Name = "NewField1112111";
                    NewField1112111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1112111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1112111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1112111.TextFont.Name = "Arial Narrow";
                    NewField1112111.Value = @"Sekonder ambalaj ve primer ambalaj üzerindeki seri numaraları, ürün adı, etkin madde ve miktarı vs. bilgileri birbirini tutuyor mu?";

                    NewField11121111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 130, 160, 155, 169, false);
                    NewField11121111.Name = "NewField11121111";
                    NewField11121111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11121111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11121111.TextFont.Name = "Arial Narrow";
                    NewField11121111.Value = @"      Uygun";

                    NewField111111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 160, 200, 169, false);
                    NewField111111111.Name = "NewField111111111";
                    NewField111111111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111111111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111111111.TextFont.Name = "Arial Narrow";
                    NewField111111111.Value = @"      Uygun Değildir";

                    NewRect1112111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 131, 163, 134, 166, false);
                    NewRect1112111.Name = "NewRect1112111";
                    NewRect1112111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewRect11111111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 156, 163, 159, 166, false);
                    NewRect11111111.Name = "NewRect11111111";
                    NewRect11111111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField11112111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 169, 130, 178, false);
                    NewField11112111.Name = "NewField11112111";
                    NewField11112111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11112111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11112111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11112111.TextFont.Name = "Arial Narrow";
                    NewField11112111.Value = @"Sekonder ambalaj ve primer ambalaj renkleri ve ruhsat dosyasında belirtilen renklerle aynı mı?";

                    NewField111112111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 130, 169, 155, 178, false);
                    NewField111112111.Name = "NewField111112111";
                    NewField111112111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111112111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111112111.TextFont.Name = "Arial Narrow";
                    NewField111112111.Value = @"      Uygun";

                    NewField1111111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 169, 200, 178, false);
                    NewField1111111111.Name = "NewField1111111111";
                    NewField1111111111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111111111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111111111.TextFont.Name = "Arial Narrow";
                    NewField1111111111.Value = @"      Uygun Değildir";

                    NewRect11112111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 131, 172, 134, 175, false);
                    NewRect11112111.Name = "NewRect11112111";
                    NewRect11112111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewRect111111111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 156, 172, 159, 175, false);
                    NewRect111111111.Name = "NewRect111111111";
                    NewRect111111111.DrawStyle = DrawStyleConstants.vbSolid;

                    FORMBASLIGI111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 181, 200, 187, false);
                    FORMBASLIGI111.Name = "FORMBASLIGI111";
                    FORMBASLIGI111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    FORMBASLIGI111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FORMBASLIGI111.TextFont.Name = "Arial";
                    FORMBASLIGI111.TextFont.Size = 12;
                    FORMBASLIGI111.TextFont.Bold = true;
                    FORMBASLIGI111.Value = @"TRANSFER AMBALAJ";

                    TANewField17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 187, 130, 196, false);
                    TANewField17.Name = "TANewField17";
                    TANewField17.DrawStyle = DrawStyleConstants.vbSolid;
                    TANewField17.MultiLine = EvetHayirEnum.ehEvet;
                    TANewField17.WordBreak = EvetHayirEnum.ehEvet;
                    TANewField17.TextFont.Name = "Arial Narrow";
                    TANewField17.Value = @"Transfer ambalajında deformasyon (yırtık, ezilmes, renk kaybı vs.) var mı? Ürün seri ve Nato Stok numaraları birbirini tutuyor mu?";

                    TANewField18 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 130, 187, 155, 196, false);
                    TANewField18.Name = "TANewField18";
                    TANewField18.DrawStyle = DrawStyleConstants.vbSolid;
                    TANewField18.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TANewField18.TextFont.Name = "Arial Narrow";
                    TANewField18.Value = @"      Uygun";

                    TANewField19 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 187, 200, 196, false);
                    TANewField19.Name = "TANewField19";
                    TANewField19.DrawStyle = DrawStyleConstants.vbSolid;
                    TANewField19.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TANewField19.TextFont.Name = "Arial Narrow";
                    TANewField19.Value = @"      Uygun Değildir";

                    NewRect21 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 131, 190, 134, 193, false);
                    NewRect21.Name = "NewRect21";
                    NewRect21.DrawStyle = DrawStyleConstants.vbSolid;

                    NewRect20 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 156, 190, 159, 193, false);
                    NewRect20.Name = "NewRect20";
                    NewRect20.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 196, 130, 201, false);
                    NewField122.Name = "NewField122";
                    NewField122.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField122.TextFont.Name = "Arial Narrow";
                    NewField122.Value = @"Transfer ambalajında ürün etiketi ve tutanak var mı? Bilgileri doğru mu?";

                    NewField132 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 130, 196, 155, 201, false);
                    NewField132.Name = "NewField132";
                    NewField132.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField132.TextFont.Name = "Arial Narrow";
                    NewField132.Value = @"      Uygun";

                    NewField141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 196, 200, 201, false);
                    NewField141.Name = "NewField141";
                    NewField141.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField141.TextFont.Name = "Arial Narrow";
                    NewField141.Value = @"      Uygun Değildir";

                    NewRect161 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 131, 197, 134, 200, false);
                    NewRect161.Name = "NewRect161";
                    NewRect161.DrawStyle = DrawStyleConstants.vbSolid;

                    NewRect151 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 156, 197, 159, 200, false);
                    NewRect151.Name = "NewRect151";
                    NewRect151.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField8.CalcValue = NewField8.Value;
                    XXXXXXLOGO.CalcValue = XXXXXXLOGO.Value;
                    NewField7.CalcValue = NewField7.Value;
                    FORMBASLIGI.CalcValue = FORMBASLIGI.Value;
                    TRANSACTIONDATE.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    TRANSACTIONDATE.PostFieldValueCalculation();
                    NewField19.CalcValue = NewField19.Value;
                    NewField20.CalcValue = NewField20.Value;
                    PRODUCEDMATERIALNAME.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    PRODUCEDMATERIALNAME.PostFieldValueCalculation();
                    NewField192.CalcValue = NewField192.Value;
                    NewField103.CalcValue = NewField103.Value;
                    FORMBASLIGI1.CalcValue = FORMBASLIGI1.Value;
                    NewField1.CalcValue = NewField1.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField111.CalcValue = NewField111.Value;
                    BANewField12.CalcValue = BANewField12.Value;
                    NewField112.CalcValue = NewField112.Value;
                    NewField1111.CalcValue = NewField1111.Value;
                    NewField121.CalcValue = NewField121.Value;
                    NewField1211.CalcValue = NewField1211.Value;
                    NewField11111.CalcValue = NewField11111.Value;
                    NewField1121.CalcValue = NewField1121.Value;
                    NewField11121.CalcValue = NewField11121.Value;
                    NewField111111.CalcValue = NewField111111.Value;
                    NewField11211.CalcValue = NewField11211.Value;
                    NewField112111.CalcValue = NewField112111.Value;
                    NewField1111111.CalcValue = NewField1111111.Value;
                    NewField111211.CalcValue = NewField111211.Value;
                    NewField1111211.CalcValue = NewField1111211.Value;
                    NewField11111111.CalcValue = NewField11111111.Value;
                    FORMBASLIGI11.CalcValue = FORMBASLIGI11.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField113.CalcValue = NewField113.Value;
                    NewField1112.CalcValue = NewField1112.Value;
                    NewField131.CalcValue = NewField131.Value;
                    NewField1311.CalcValue = NewField1311.Value;
                    NewField12111.CalcValue = NewField12111.Value;
                    NewField1131.CalcValue = NewField1131.Value;
                    NewField11131.CalcValue = NewField11131.Value;
                    NewField111121.CalcValue = NewField111121.Value;
                    NewField11311.CalcValue = NewField11311.Value;
                    NewField113111.CalcValue = NewField113111.Value;
                    NewField1121111.CalcValue = NewField1121111.Value;
                    NewField111311.CalcValue = NewField111311.Value;
                    NewField1111311.CalcValue = NewField1111311.Value;
                    NewField11111211.CalcValue = NewField11111211.Value;
                    NewField1113111.CalcValue = NewField1113111.Value;
                    NewField11131111.CalcValue = NewField11131111.Value;
                    NewField111211111.CalcValue = NewField111211111.Value;
                    NewField11113111.CalcValue = NewField11113111.Value;
                    NewField111113111.CalcValue = NewField111113111.Value;
                    NewField1111112111.CalcValue = NewField1111112111.Value;
                    IANewField12.CalcValue = IANewField12.Value;
                    IANewField13.CalcValue = IANewField13.Value;
                    IANewField14.CalcValue = IANewField14.Value;
                    NewField1112111.CalcValue = NewField1112111.Value;
                    NewField11121111.CalcValue = NewField11121111.Value;
                    NewField111111111.CalcValue = NewField111111111.Value;
                    NewField11112111.CalcValue = NewField11112111.Value;
                    NewField111112111.CalcValue = NewField111112111.Value;
                    NewField1111111111.CalcValue = NewField1111111111.Value;
                    FORMBASLIGI111.CalcValue = FORMBASLIGI111.Value;
                    TANewField17.CalcValue = TANewField17.Value;
                    TANewField18.CalcValue = TANewField18.Value;
                    TANewField19.CalcValue = TANewField19.Value;
                    NewField122.CalcValue = NewField122.Value;
                    NewField132.CalcValue = NewField132.Value;
                    NewField141.CalcValue = NewField141.Value;
                    XXXXXXBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { NewField8,XXXXXXLOGO,NewField7,FORMBASLIGI,TRANSACTIONDATE,NewField19,NewField20,PRODUCEDMATERIALNAME,NewField192,NewField103,FORMBASLIGI1,NewField1,NewField11,NewField111,BANewField12,NewField112,NewField1111,NewField121,NewField1211,NewField11111,NewField1121,NewField11121,NewField111111,NewField11211,NewField112111,NewField1111111,NewField111211,NewField1111211,NewField11111111,FORMBASLIGI11,NewField13,NewField113,NewField1112,NewField131,NewField1311,NewField12111,NewField1131,NewField11131,NewField111121,NewField11311,NewField113111,NewField1121111,NewField111311,NewField1111311,NewField11111211,NewField1113111,NewField11131111,NewField111211111,NewField11113111,NewField111113111,NewField1111112111,IANewField12,IANewField13,IANewField14,NewField1112111,NewField11121111,NewField111111111,NewField11112111,NewField111112111,NewField1111111111,FORMBASLIGI111,TANewField17,TANewField18,TANewField19,NewField122,NewField132,NewField141,XXXXXXBASLIK};
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public FizikselAnalizKontrolFormu MyParentReport
                {
                    get { return (FizikselAnalizKontrolFormu)ParentReport; }
                }
                
                public TTReportField REQUESTUSERDETAIL;
                public TTReportField APPROVEDUSERDETAIL; 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 30;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    REQUESTUSERDETAIL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 4, 59, 26, false);
                    REQUESTUSERDETAIL.Name = "REQUESTUSERDETAIL";
                    REQUESTUSERDETAIL.TextFont.Name = "Arial";
                    REQUESTUSERDETAIL.TextFont.Size = 11;
                    REQUESTUSERDETAIL.Value = @"";

                    APPROVEDUSERDETAIL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 149, 4, 199, 26, false);
                    APPROVEDUSERDETAIL.Name = "APPROVEDUSERDETAIL";
                    APPROVEDUSERDETAIL.TextFont.Name = "Arial";
                    APPROVEDUSERDETAIL.TextFont.Size = 11;
                    APPROVEDUSERDETAIL.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    REQUESTUSERDETAIL.CalcValue = REQUESTUSERDETAIL.Value;
                    APPROVEDUSERDETAIL.CalcValue = APPROVEDUSERDETAIL.Value;
                    return new TTReportObject[] { REQUESTUSERDETAIL,APPROVEDUSERDETAIL};
                }
            }

        }

        public PARTBGroup PARTB;

        public partial class MAINGroup : TTReportGroup
        {
            public FizikselAnalizKontrolFormu MyParentReport
            {
                get { return (FizikselAnalizKontrolFormu)ParentReport; }
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
                public FizikselAnalizKontrolFormu MyParentReport
                {
                    get { return (FizikselAnalizKontrolFormu)ParentReport; }
                }
                 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 1;
                    IsVisible = EvetHayirEnum.ehHayir;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public FizikselAnalizKontrolFormu()
        {
            PARTB = new PARTBGroup(this,"PARTB");
            MAIN = new MAINGroup(PARTB,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "Object ID", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "FIZIKSELANALIZKONTROLFORMU";
            Caption = "Fiziksel Analiz Kontrol Formu";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oePortrait;
            UserMarginLeft = 5;
            UserMarginTop = 5;
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
            fd.TextFont.Name = "Courier New";
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
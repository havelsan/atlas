
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
    /// Ön Analiz Kontrol Formu
    /// </summary>
    public partial class OnAnalizKontrolFormu : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class PARTBGroup : TTReportGroup
        {
            public OnAnalizKontrolFormu MyParentReport
            {
                get { return (OnAnalizKontrolFormu)ParentReport; }
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
            public TTReportField NewField18 { get {return Header().NewField18;} }
            public TTReportField NewField17 { get {return Header().NewField17;} }
            public TTReportField TRANSACTIONDATE { get {return Header().TRANSACTIONDATE;} }
            public TTReportField STOCKACTIONID { get {return Header().STOCKACTIONID;} }
            public TTReportField FORMBASLIGI1 { get {return Header().FORMBASLIGI1;} }
            public TTReportField FORMBASLIGI11 { get {return Header().FORMBASLIGI11;} }
            public TTReportField NewField19 { get {return Header().NewField19;} }
            public TTReportField NewField20 { get {return Header().NewField20;} }
            public TTReportField PRODUCEDMATERIALNAME { get {return Header().PRODUCEDMATERIALNAME;} }
            public TTReportField NewField191 { get {return Header().NewField191;} }
            public TTReportField NewField102 { get {return Header().NewField102;} }
            public TTReportField SERIALNO { get {return Header().SERIALNO;} }
            public TTReportField NewField1191 { get {return Header().NewField1191;} }
            public TTReportField NewField1201 { get {return Header().NewField1201;} }
            public TTReportField PRODUCEDMATERIALAMOUNT { get {return Header().PRODUCEDMATERIALAMOUNT;} }
            public TTReportField NewField1192 { get {return Header().NewField1192;} }
            public TTReportField NewField1202 { get {return Header().NewField1202;} }
            public TTReportField NUMUNEMIKTARI { get {return Header().NUMUNEMIKTARI;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public TTReportField NewField12021 { get {return Header().NewField12021;} }
            public TTReportField NewField112021 { get {return Header().NewField112021;} }
            public TTReportField REQUESTUSERDETAIL { get {return Header().REQUESTUSERDETAIL;} }
            public TTReportField NewField112022 { get {return Footer().NewField112022;} }
            public TTReportShape NewLine11 { get {return Footer().NewLine11;} }
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
                public OnAnalizKontrolFormu MyParentReport
                {
                    get { return (OnAnalizKontrolFormu)ParentReport; }
                }
                
                public TTReportField NewField8;
                public TTReportField XXXXXXBASLIK;
                public TTReportField XXXXXXLOGO;
                public TTReportField NewField7;
                public TTReportField FORMBASLIGI;
                public TTReportField NewField18;
                public TTReportField NewField17;
                public TTReportField TRANSACTIONDATE;
                public TTReportField STOCKACTIONID;
                public TTReportField FORMBASLIGI1;
                public TTReportField FORMBASLIGI11;
                public TTReportField NewField19;
                public TTReportField NewField20;
                public TTReportField PRODUCEDMATERIALNAME;
                public TTReportField NewField191;
                public TTReportField NewField102;
                public TTReportField SERIALNO;
                public TTReportField NewField1191;
                public TTReportField NewField1201;
                public TTReportField PRODUCEDMATERIALAMOUNT;
                public TTReportField NewField1192;
                public TTReportField NewField1202;
                public TTReportField NUMUNEMIKTARI;
                public TTReportShape NewLine1;
                public TTReportField NewField12021;
                public TTReportField NewField112021;
                public TTReportField REQUESTUSERDETAIL; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 167;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 163, 52, 166, 57, false);
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

                    NewField7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 125, 52, 163, 57, false);
                    NewField7.Name = "NewField7";
                    NewField7.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField7.TextFont.Name = "Arial";
                    NewField7.TextFont.Size = 11;
                    NewField7.TextFont.Bold = true;
                    NewField7.Value = @"TARİH";

                    FORMBASLIGI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 34, 200, 40, false);
                    FORMBASLIGI.Name = "FORMBASLIGI";
                    FORMBASLIGI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    FORMBASLIGI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FORMBASLIGI.TextFont.Name = "Arial";
                    FORMBASLIGI.TextFont.Size = 12;
                    FORMBASLIGI.TextFont.Bold = true;
                    FORMBASLIGI.Value = @"ÖN ANALİZ / KONTROL FORMU";

                    NewField18 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 163, 58, 166, 63, false);
                    NewField18.Name = "NewField18";
                    NewField18.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField18.TextFont.Name = "Arial";
                    NewField18.TextFont.Size = 11;
                    NewField18.TextFont.Bold = true;
                    NewField18.Value = @":";

                    NewField17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 125, 58, 163, 63, false);
                    NewField17.Name = "NewField17";
                    NewField17.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField17.TextFont.Name = "Arial";
                    NewField17.TextFont.Size = 11;
                    NewField17.TextFont.Bold = true;
                    NewField17.Value = @"BELGE NO";

                    TRANSACTIONDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 166, 52, 200, 57, false);
                    TRANSACTIONDATE.Name = "TRANSACTIONDATE";
                    TRANSACTIONDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TRANSACTIONDATE.TextFormat = @"dd/MM/yyyy";
                    TRANSACTIONDATE.ObjectDefName = "DrugProductionTest";
                    TRANSACTIONDATE.DataMember = "DRUGPRODUCTIONPROCEDURE.TRANSACTIONDATE";
                    TRANSACTIONDATE.TextFont.Name = "Arial";
                    TRANSACTIONDATE.TextFont.Size = 11;
                    TRANSACTIONDATE.Value = @"{@TTOBJECTID@}";

                    STOCKACTIONID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 166, 58, 200, 63, false);
                    STOCKACTIONID.Name = "STOCKACTIONID";
                    STOCKACTIONID.FieldType = ReportFieldTypeEnum.ftVariable;
                    STOCKACTIONID.ObjectDefName = "DrugProductionTest";
                    STOCKACTIONID.DataMember = "DRUGPRODUCTIONPROCEDURE.STOCKACTIONID";
                    STOCKACTIONID.TextFont.Name = "Arial";
                    STOCKACTIONID.TextFont.Size = 11;
                    STOCKACTIONID.Value = @"{@TTOBJECTID@}";

                    FORMBASLIGI1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 75, 200, 81, false);
                    FORMBASLIGI1.Name = "FORMBASLIGI1";
                    FORMBASLIGI1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    FORMBASLIGI1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FORMBASLIGI1.TextFont.Name = "Arial";
                    FORMBASLIGI1.TextFont.Size = 11;
                    FORMBASLIGI1.TextFont.Bold = true;
                    FORMBASLIGI1.Value = @"KALİTE KONTROL VE ARGE LABORATUVAR ŞEFLİĞİ'NE";

                    FORMBASLIGI11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 87, 200, 102, false);
                    FORMBASLIGI11.Name = "FORMBASLIGI11";
                    FORMBASLIGI11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    FORMBASLIGI11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FORMBASLIGI11.MultiLine = EvetHayirEnum.ehEvet;
                    FORMBASLIGI11.WordBreak = EvetHayirEnum.ehEvet;
                    FORMBASLIGI11.TextFont.Name = "Arial";
                    FORMBASLIGI11.TextFont.Size = 11;
                    FORMBASLIGI11.Value = @"	Aşağıda belirtilen ürüne ait, istenilen Analiz/Kontrollerin yapılarak sonucunun bildirilmesini Arz / Rica ederim.";

                    NewField19 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 107, 61, 112, false);
                    NewField19.Name = "NewField19";
                    NewField19.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField19.TextFont.Name = "Arial";
                    NewField19.TextFont.Size = 11;
                    NewField19.TextFont.Bold = true;
                    NewField19.Value = @":";

                    NewField20 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 107, 58, 112, false);
                    NewField20.Name = "NewField20";
                    NewField20.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField20.TextFont.Name = "Arial";
                    NewField20.TextFont.Size = 11;
                    NewField20.TextFont.Bold = true;
                    NewField20.Value = @"ÜRÜNÜN ADI";

                    PRODUCEDMATERIALNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 107, 200, 112, false);
                    PRODUCEDMATERIALNAME.Name = "PRODUCEDMATERIALNAME";
                    PRODUCEDMATERIALNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRODUCEDMATERIALNAME.ObjectDefName = "DrugProductionTest";
                    PRODUCEDMATERIALNAME.DataMember = "DRUGPRODUCTIONPROCEDURE.PRODUCEDMATERIAL.MATERIAL.NAME";
                    PRODUCEDMATERIALNAME.TextFont.Name = "Arial";
                    PRODUCEDMATERIALNAME.TextFont.Size = 11;
                    PRODUCEDMATERIALNAME.Value = @"{@TTOBJECTID@}";

                    NewField191 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 113, 61, 118, false);
                    NewField191.Name = "NewField191";
                    NewField191.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField191.TextFont.Name = "Arial";
                    NewField191.TextFont.Size = 11;
                    NewField191.TextFont.Bold = true;
                    NewField191.Value = @":";

                    NewField102 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 113, 58, 118, false);
                    NewField102.Name = "NewField102";
                    NewField102.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField102.TextFont.Name = "Arial";
                    NewField102.TextFont.Size = 11;
                    NewField102.TextFont.Bold = true;
                    NewField102.Value = @"ÜRETİM SERİ NU.";

                    SERIALNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 113, 200, 118, false);
                    SERIALNO.Name = "SERIALNO";
                    SERIALNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SERIALNO.ObjectDefName = "DrugProductionTest";
                    SERIALNO.DataMember = "DRUGPRODUCTIONPROCEDURE.SERIALNO";
                    SERIALNO.TextFont.Name = "Arial";
                    SERIALNO.TextFont.Size = 11;
                    SERIALNO.Value = @"{@TTOBJECTID@}";

                    NewField1191 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 119, 61, 124, false);
                    NewField1191.Name = "NewField1191";
                    NewField1191.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField1191.TextFont.Name = "Arial";
                    NewField1191.TextFont.Size = 11;
                    NewField1191.TextFont.Bold = true;
                    NewField1191.Value = @":";

                    NewField1201 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 119, 58, 124, false);
                    NewField1201.Name = "NewField1201";
                    NewField1201.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField1201.TextFont.Name = "Arial";
                    NewField1201.TextFont.Size = 11;
                    NewField1201.TextFont.Bold = true;
                    NewField1201.Value = @"ÜRETİM MİKTARI";

                    PRODUCEDMATERIALAMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 119, 200, 124, false);
                    PRODUCEDMATERIALAMOUNT.Name = "PRODUCEDMATERIALAMOUNT";
                    PRODUCEDMATERIALAMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRODUCEDMATERIALAMOUNT.ObjectDefName = "DrugProductionTest";
                    PRODUCEDMATERIALAMOUNT.DataMember = "DRUGPRODUCTIONPROCEDURE.PRODUCEDMATERIALAMOUNT";
                    PRODUCEDMATERIALAMOUNT.TextFont.Name = "Arial";
                    PRODUCEDMATERIALAMOUNT.TextFont.Size = 11;
                    PRODUCEDMATERIALAMOUNT.Value = @"{@TTOBJECTID@}";

                    NewField1192 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 125, 61, 130, false);
                    NewField1192.Name = "NewField1192";
                    NewField1192.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField1192.TextFont.Name = "Arial";
                    NewField1192.TextFont.Size = 11;
                    NewField1192.TextFont.Bold = true;
                    NewField1192.Value = @":";

                    NewField1202 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 125, 58, 130, false);
                    NewField1202.Name = "NewField1202";
                    NewField1202.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField1202.TextFont.Name = "Arial";
                    NewField1202.TextFont.Size = 11;
                    NewField1202.TextFont.Bold = true;
                    NewField1202.Value = @"NUMUNE MİKTARI";

                    NUMUNEMIKTARI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 125, 200, 130, false);
                    NUMUNEMIKTARI.Name = "NUMUNEMIKTARI";
                    NUMUNEMIKTARI.FieldType = ReportFieldTypeEnum.ftVariable;
                    NUMUNEMIKTARI.ObjectDefName = "DrugProductionTest";
                    NUMUNEMIKTARI.DataMember = "SAMPLEAMOUNT";
                    NUMUNEMIKTARI.TextFont.Name = "Arial";
                    NUMUNEMIKTARI.TextFont.Size = 11;
                    NUMUNEMIKTARI.Value = @"{@TTOBJECTID@}";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 161, 200, 161, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1.DrawWidth = 2;

                    NewField12021 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 162, 64, 167, false);
                    NewField12021.Name = "NewField12021";
                    NewField12021.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField12021.TextFont.Name = "Arial";
                    NewField12021.TextFont.Size = 11;
                    NewField12021.TextFont.Bold = true;
                    NewField12021.TextFont.Underline = true;
                    NewField12021.Value = @"ANALİZ / KONTROL :";

                    NewField112021 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 132, 162, 180, 167, false);
                    NewField112021.Name = "NewField112021";
                    NewField112021.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField112021.TextFont.Name = "Arial";
                    NewField112021.TextFont.Size = 11;
                    NewField112021.TextFont.Bold = true;
                    NewField112021.TextFont.Underline = true;
                    NewField112021.Value = @"ANALİZ SONUÇLARI :";

                    REQUESTUSERDETAIL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 150, 135, 200, 157, false);
                    REQUESTUSERDETAIL.Name = "REQUESTUSERDETAIL";
                    REQUESTUSERDETAIL.TextFont.Name = "Arial";
                    REQUESTUSERDETAIL.TextFont.Size = 11;
                    REQUESTUSERDETAIL.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField8.CalcValue = NewField8.Value;
                    XXXXXXLOGO.CalcValue = XXXXXXLOGO.Value;
                    NewField7.CalcValue = NewField7.Value;
                    FORMBASLIGI.CalcValue = FORMBASLIGI.Value;
                    NewField18.CalcValue = NewField18.Value;
                    NewField17.CalcValue = NewField17.Value;
                    TRANSACTIONDATE.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    TRANSACTIONDATE.PostFieldValueCalculation();
                    STOCKACTIONID.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    STOCKACTIONID.PostFieldValueCalculation();
                    FORMBASLIGI1.CalcValue = FORMBASLIGI1.Value;
                    FORMBASLIGI11.CalcValue = FORMBASLIGI11.Value;
                    NewField19.CalcValue = NewField19.Value;
                    NewField20.CalcValue = NewField20.Value;
                    PRODUCEDMATERIALNAME.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    PRODUCEDMATERIALNAME.PostFieldValueCalculation();
                    NewField191.CalcValue = NewField191.Value;
                    NewField102.CalcValue = NewField102.Value;
                    SERIALNO.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    SERIALNO.PostFieldValueCalculation();
                    NewField1191.CalcValue = NewField1191.Value;
                    NewField1201.CalcValue = NewField1201.Value;
                    PRODUCEDMATERIALAMOUNT.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    PRODUCEDMATERIALAMOUNT.PostFieldValueCalculation();
                    NewField1192.CalcValue = NewField1192.Value;
                    NewField1202.CalcValue = NewField1202.Value;
                    NUMUNEMIKTARI.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    NUMUNEMIKTARI.PostFieldValueCalculation();
                    NewField12021.CalcValue = NewField12021.Value;
                    NewField112021.CalcValue = NewField112021.Value;
                    REQUESTUSERDETAIL.CalcValue = REQUESTUSERDETAIL.Value;
                    XXXXXXBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { NewField8,XXXXXXLOGO,NewField7,FORMBASLIGI,NewField18,NewField17,TRANSACTIONDATE,STOCKACTIONID,FORMBASLIGI1,FORMBASLIGI11,NewField19,NewField20,PRODUCEDMATERIALNAME,NewField191,NewField102,SERIALNO,NewField1191,NewField1201,PRODUCEDMATERIALAMOUNT,NewField1192,NewField1202,NUMUNEMIKTARI,NewField12021,NewField112021,REQUESTUSERDETAIL,XXXXXXBASLIK};
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public OnAnalizKontrolFormu MyParentReport
                {
                    get { return (OnAnalizKontrolFormu)ParentReport; }
                }
                
                public TTReportField NewField112022;
                public TTReportShape NewLine11; 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 30;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField112022 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 162, 0, 200, 5, false);
                    NewField112022.Name = "NewField112022";
                    NewField112022.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField112022.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField112022.TextFont.Name = "Arial";
                    NewField112022.TextFont.Size = 11;
                    NewField112022.TextFont.Bold = true;
                    NewField112022.Value = @"ONAY";

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 6, 200, 6, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11.DrawWidth = 2;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField112022.CalcValue = NewField112022.Value;
                    return new TTReportObject[] { NewField112022};
                }
            }

        }

        public PARTBGroup PARTB;

        public partial class MAINGroup : TTReportGroup
        {
            public OnAnalizKontrolFormu MyParentReport
            {
                get { return (OnAnalizKontrolFormu)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField TESTNAME { get {return Body().TESTNAME;} }
            public TTReportShape NewLine1 { get {return Body().NewLine1;} }
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
                list[0] = new TTReportNqlData<DrugProductionTestDetail.DrugTestDetailReportNQL_Class>("DrugTestDetailReportNQL", DrugProductionTestDetail.DrugTestDetailReportNQL((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public OnAnalizKontrolFormu MyParentReport
                {
                    get { return (OnAnalizKontrolFormu)ParentReport; }
                }
                
                public TTReportField TESTNAME;
                public TTReportShape NewLine1; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 6;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    TESTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 1, 90, 6, false);
                    TESTNAME.Name = "TESTNAME";
                    TESTNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    TESTNAME.TextFont.Name = "Arial";
                    TESTNAME.TextFont.Bold = true;
                    TESTNAME.Value = @"{#PRODUCTANALYSESTESTDEFINITION#}";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 132, 6, 200, 6, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbDot;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DrugProductionTestDetail.DrugTestDetailReportNQL_Class dataset_DrugTestDetailReportNQL = ParentGroup.rsGroup.GetCurrentRecord<DrugProductionTestDetail.DrugTestDetailReportNQL_Class>(0);
                    TESTNAME.CalcValue = (dataset_DrugTestDetailReportNQL != null ? Globals.ToStringCore(dataset_DrugTestDetailReportNQL.Productanalysestestdefinition) : "");
                    return new TTReportObject[] { TESTNAME};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public OnAnalizKontrolFormu()
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
            Name = "ONANALIZKONTROLFORMU";
            Caption = "Ön Analiz Kontrol Formu";
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
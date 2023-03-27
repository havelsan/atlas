
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
    /// HASTA TAAHHÜTNAMESİ
    /// </summary>
    public partial class OrthesisProsthesisPatientCommitReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["String50"].ConvertValue("");
        }

        public partial class HEADERPARTGroup : TTReportGroup
        {
            public OrthesisProsthesisPatientCommitReport MyParentReport
            {
                get { return (OrthesisProsthesisPatientCommitReport)ParentReport; }
            }

            new public HEADERPARTGroupHeader Header()
            {
                return (HEADERPARTGroupHeader)_header;
            }

            new public HEADERPARTGroupFooter Footer()
            {
                return (HEADERPARTGroupFooter)_footer;
            }

            public TTReportField XXXXXXBASLIK { get {return Header().XXXXXXBASLIK;} }
            public TTReportField UnderTaking { get {return Header().UnderTaking;} }
            public TTReportField lblKod1 { get {return Header().lblKod1;} }
            public TTReportField lblName1 { get {return Header().lblName1;} }
            public TTReportField lblSide1 { get {return Header().lblSide1;} }
            public TTReportField lblMiat1 { get {return Header().lblMiat1;} }
            public TTReportShape NewLine2 { get {return Header().NewLine2;} }
            public TTReportField NewField1 { get {return Footer().NewField1;} }
            public TTReportShape NewRect1 { get {return Footer().NewRect1;} }
            public TTReportField NewField2 { get {return Footer().NewField2;} }
            public TTReportShape NewRect11 { get {return Footer().NewRect11;} }
            public TTReportField NewField12 { get {return Footer().NewField12;} }
            public TTReportField NewField3 { get {return Footer().NewField3;} }
            public TTReportField NewField4 { get {return Footer().NewField4;} }
            public TTReportShape NewLine1 { get {return Footer().NewLine1;} }
            public TTReportField NewField5 { get {return Footer().NewField5;} }
            public TTReportField NewField6 { get {return Footer().NewField6;} }
            public TTReportField NewField14 { get {return Footer().NewField14;} }
            public TTReportShape NewLine11 { get {return Footer().NewLine11;} }
            public TTReportField NewField15 { get {return Footer().NewField15;} }
            public TTReportField NewField7 { get {return Footer().NewField7;} }
            public TTReportField HiddenPName { get {return Footer().HiddenPName;} }
            public TTReportField FULLNAME { get {return Footer().FULLNAME;} }
            public TTReportField TC { get {return Footer().TC;} }
            public TTReportField TELNO { get {return Footer().TELNO;} }
            public TTReportField ADRESS { get {return Footer().ADRESS;} }
            public TTReportField NewField8 { get {return Footer().NewField8;} }
            public TTReportField NewField9 { get {return Footer().NewField9;} }
            public TTReportField PAYERID { get {return Footer().PAYERID;} }
            public HEADERPARTGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public HEADERPARTGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<OrthesisProsthesisRequest.GetOrthesisRceptionReportInfo_Class>("GetOrthesisRceptionReportInfo", OrthesisProsthesisRequest.GetOrthesisRceptionReportInfo((string)TTObjectDefManager.Instance.DataTypes["String50"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new HEADERPARTGroupHeader(this);
                _footer = new HEADERPARTGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class HEADERPARTGroupHeader : TTReportSection
            {
                public OrthesisProsthesisPatientCommitReport MyParentReport
                {
                    get { return (OrthesisProsthesisPatientCommitReport)ParentReport; }
                }
                
                public TTReportField XXXXXXBASLIK;
                public TTReportField UnderTaking;
                public TTReportField lblKod1;
                public TTReportField lblName1;
                public TTReportField lblSide1;
                public TTReportField lblMiat1;
                public TTReportShape NewLine2; 
                public HEADERPARTGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 75;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    XXXXXXBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 28, 4, 195, 54, false);
                    XXXXXXBASLIK.Name = "XXXXXXBASLIK";
                    XXXXXXBASLIK.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXBASLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    XXXXXXBASLIK.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.TextFont.Name = "Arial";
                    XXXXXXBASLIK.TextFont.Size = 12;
                    XXXXXXBASLIK.TextFont.Bold = true;
                    XXXXXXBASLIK.TextFont.CharSet = 162;
                    XXXXXXBASLIK.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + ""\r\n"" + TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    UnderTaking = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 60, 141, 65, false);
                    UnderTaking.Name = "UnderTaking";
                    UnderTaking.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    UnderTaking.TextFont.Name = "Arial";
                    UnderTaking.TextFont.Size = 12;
                    UnderTaking.TextFont.Bold = true;
                    UnderTaking.TextFont.CharSet = 162;
                    UnderTaking.Value = @"HASTA TAAHHÜTNAMESİ";

                    lblKod1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 70, 36, 75, false);
                    lblKod1.Name = "lblKod1";
                    lblKod1.Value = @"KODU";

                    lblName1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 70, 137, 75, false);
                    lblName1.Name = "lblName1";
                    lblName1.Value = @"ADI";

                    lblSide1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 70, 165, 75, false);
                    lblSide1.Name = "lblSide1";
                    lblSide1.Value = @"Taraf";

                    lblMiat1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 169, 70, 209, 75, false);
                    lblMiat1.Name = "lblMiat1";
                    lblMiat1.Value = @"Miad Süresi";

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, 75, 209, 75, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    OrthesisProsthesisRequest.GetOrthesisRceptionReportInfo_Class dataset_GetOrthesisRceptionReportInfo = ParentGroup.rsGroup.GetCurrentRecord<OrthesisProsthesisRequest.GetOrthesisRceptionReportInfo_Class>(0);
                    UnderTaking.CalcValue = UnderTaking.Value;
                    lblKod1.CalcValue = lblKod1.Value;
                    lblName1.CalcValue = lblName1.Value;
                    lblSide1.CalcValue = lblSide1.Value;
                    lblMiat1.CalcValue = lblMiat1.Value;
                    XXXXXXBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { UnderTaking,lblKod1,lblName1,lblSide1,lblMiat1,XXXXXXBASLIK};
                }
            }
            public partial class HEADERPARTGroupFooter : TTReportSection
            {
                public OrthesisProsthesisPatientCommitReport MyParentReport
                {
                    get { return (OrthesisProsthesisPatientCommitReport)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportShape NewRect1;
                public TTReportField NewField2;
                public TTReportShape NewRect11;
                public TTReportField NewField12;
                public TTReportField NewField3;
                public TTReportField NewField4;
                public TTReportShape NewLine1;
                public TTReportField NewField5;
                public TTReportField NewField6;
                public TTReportField NewField14;
                public TTReportShape NewLine11;
                public TTReportField NewField15;
                public TTReportField NewField7;
                public TTReportField HiddenPName;
                public TTReportField FULLNAME;
                public TTReportField TC;
                public TTReportField TELNO;
                public TTReportField ADRESS;
                public TTReportField NewField8;
                public TTReportField NewField9;
                public TTReportField PAYERID; 
                public HEADERPARTGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 170;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 3, 209, 19, false);
                    NewField1.Name = "NewField1";
                    NewField1.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1.TextFont.Size = 11;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"Yukarıda bilgileri verilen,Gaziler Fizik Tedavi ve Rehabilitasyon Eğitim ve Araştırma XXXXXX Ortez Protez Uygulama ve Yapım Merkezinden talep ettiğim, cihazın ve bu cihaz ile aynı işlevsel özellikte ve aynı tıbbi sonucu verdiği kabul edilen cihazların daha önceden bedeli Sosyal Güvenlik Kurumu tarafından ödenmek suretiyle;";

                    NewRect1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 11, 20, 15, 24, false);
                    NewRect1.Name = "NewRect1";
                    NewRect1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 20, 41, 25, false);
                    NewField2.Name = "NewField2";
                    NewField2.Value = @"Temin etmedğimi";

                    NewRect11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 11, 25, 15, 29, false);
                    NewRect11.Name = "NewRect11";
                    NewRect11.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 25, 116, 30, false);
                    NewField12.Name = "NewField12";
                    NewField12.Value = @"Temin ettiğimi ancak SUT'ta belirlenmiş olan miat süresinin dolduğunu,";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 31, 209, 44, false);
                    NewField3.Name = "NewField3";
                    NewField3.MultiLine = EvetHayirEnum.ehEvet;
                    NewField3.WordBreak = EvetHayirEnum.ehEvet;
                    NewField3.TextFont.Size = 11;
                    NewField3.TextFont.CharSet = 162;
                    NewField3.Value = @"Aksi durumun tespiti halinde her türlü hukuki ve maddi sorumluluğun tarafıma ait olduğunu kabul ve beyan ederim.
Tarih .. / .. / ....";

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 47, 76, 52, false);
                    NewField4.Name = "NewField4";
                    NewField4.TextFont.Name = "Arial";
                    NewField4.TextFont.Bold = true;
                    NewField4.TextFont.CharSet = 162;
                    NewField4.Value = @"GENEL SAĞLIK SİGORTALISININ:";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, 52, 76, 52, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 54, 130, 64, false);
                    NewField5.Name = "NewField5";
                    NewField5.MultiLine = EvetHayirEnum.ehEvet;
                    NewField5.WordBreak = EvetHayirEnum.ehEvet;
                    NewField5.TextFont.Size = 11;
                    NewField5.TextFont.CharSet = 162;
                    NewField5.Value = @"T.C. Kimlik No
Adı Soyadı";

                    NewField6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 156, 47, 195, 52, false);
                    NewField6.Name = "NewField6";
                    NewField6.Value = @"Hasta Adı Soyadı";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 68, 76, 73, false);
                    NewField14.Name = "NewField14";
                    NewField14.TextFont.Name = "Arial";
                    NewField14.TextFont.Bold = true;
                    NewField14.TextFont.CharSet = 162;
                    NewField14.Value = @"HASTAYA AİT BİLGİLER:";

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, 73, 76, 73, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 74, 40, 101, false);
                    NewField15.Name = "NewField15";
                    NewField15.MultiLine = EvetHayirEnum.ehEvet;
                    NewField15.WordBreak = EvetHayirEnum.ehEvet;
                    NewField15.TextFont.Size = 11;
                    NewField15.TextFont.CharSet = 162;
                    NewField15.Value = @"T.C. Kimlik No
Hasta Adı Soyadı
Hasta Tel No
Hasta Adresi";

                    NewField7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 104, 209, 122, false);
                    NewField7.Name = "NewField7";
                    NewField7.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField7.MultiLine = EvetHayirEnum.ehEvet;
                    NewField7.WordBreak = EvetHayirEnum.ehEvet;
                    NewField7.Value = @"Bu taahhüttün yukarıda kimlik bilgileri bulunan {%HiddenPName%} tarafından yukarıda adı/adları geçen cihazın/cihazların teminine ilişkin Sosyal Güvenlik Kurumu tarafından ödenmek suretiyle karşılamadığına ilişkin beyanın gerçeğe aykırı olduğunun bu sözleşmeye taraf Kurum tarafından tespiti halinde geçerli olacağını hiçbir sebep veya nedenle amacı dışında hasta tarafından verilecek taahüttü kullanamayacağımızı kabul ve beyan ederiz.
(Tarih)... /... / ....";

                    HiddenPName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 225, 39, 250, 44, false);
                    HiddenPName.Name = "HiddenPName";
                    HiddenPName.Visible = EvetHayirEnum.ehHayir;
                    HiddenPName.FieldType = ReportFieldTypeEnum.ftVariable;
                    HiddenPName.Value = @"{#NAME#} {#SURNAME#}";

                    FULLNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 79, 131, 84, false);
                    FULLNAME.Name = "FULLNAME";
                    FULLNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    FULLNAME.Value = @"{%HiddenPName%}";

                    TC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 74, 130, 79, false);
                    TC.Name = "TC";
                    TC.FieldType = ReportFieldTypeEnum.ftVariable;
                    TC.Value = @"{#TCKIMLIKNO#}";

                    TELNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 84, 130, 89, false);
                    TELNO.Name = "TELNO";
                    TELNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    TELNO.Value = @"{#MOBILEPHONE#}";

                    ADRESS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 89, 130, 99, false);
                    ADRESS.Name = "ADRESS";
                    ADRESS.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADRESS.MultiLine = EvetHayirEnum.ehEvet;
                    ADRESS.WordBreak = EvetHayirEnum.ehEvet;
                    ADRESS.Value = @"{#HOMEADDRESS#}";

                    NewField8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 125, 209, 146, false);
                    NewField8.Name = "NewField8";
                    NewField8.MultiLine = EvetHayirEnum.ehEvet;
                    NewField8.WordBreak = EvetHayirEnum.ehEvet;
                    NewField8.Value = @"Telefon numarası: 0(312)291 2117
Adres : Gaziler Fizik Tedavi ve Rehabilitasyon Eğiyim ve Araştırma XXXXXX 06800 Lodumlu yolu Bilkent/XXXXXX

Merkez Sorumlu İmzası/Kaşe:
";

                    NewField9 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 154, 69, 169, false);
                    NewField9.Name = "NewField9";
                    NewField9.MultiLine = EvetHayirEnum.ehEvet;
                    NewField9.WordBreak = EvetHayirEnum.ehEvet;
                    NewField9.TextFont.Size = 9;
                    NewField9.TextFont.CharSet = 162;
                    NewField9.Value = @"Engin ASLAN
Gaziler fizik Tedavi ve Reh.E.A.H
Ortez-Protez Birim Sorumlusu";

                    PAYERID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 223, 24, 248, 29, false);
                    PAYERID.Name = "PAYERID";
                    PAYERID.Visible = EvetHayirEnum.ehHayir;
                    PAYERID.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAYERID.Value = @"{#PAYERID#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    OrthesisProsthesisRequest.GetOrthesisRceptionReportInfo_Class dataset_GetOrthesisRceptionReportInfo = ParentGroup.rsGroup.GetCurrentRecord<OrthesisProsthesisRequest.GetOrthesisRceptionReportInfo_Class>(0);
                    NewField1.CalcValue = NewField1.Value;
                    NewField2.CalcValue = NewField2.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField3.CalcValue = NewField3.Value;
                    NewField4.CalcValue = NewField4.Value;
                    NewField5.CalcValue = NewField5.Value;
                    NewField6.CalcValue = NewField6.Value;
                    NewField14.CalcValue = NewField14.Value;
                    NewField15.CalcValue = NewField15.Value;
                    HiddenPName.CalcValue = (dataset_GetOrthesisRceptionReportInfo != null ? Globals.ToStringCore(dataset_GetOrthesisRceptionReportInfo.Name) : "") + @" " + (dataset_GetOrthesisRceptionReportInfo != null ? Globals.ToStringCore(dataset_GetOrthesisRceptionReportInfo.Surname) : "");
                    NewField7.CalcValue = @"Bu taahhüttün yukarıda kimlik bilgileri bulunan " + MyParentReport.HEADERPART.HiddenPName.CalcValue + @" tarafından yukarıda adı/adları geçen cihazın/cihazların teminine ilişkin Sosyal Güvenlik Kurumu tarafından ödenmek suretiyle karşılamadığına ilişkin beyanın gerçeğe aykırı olduğunun bu sözleşmeye taraf Kurum tarafından tespiti halinde geçerli olacağını hiçbir sebep veya nedenle amacı dışında hasta tarafından verilecek taahüttü kullanamayacağımızı kabul ve beyan ederiz.
(Tarih)... /... / ....";
                    FULLNAME.CalcValue = MyParentReport.HEADERPART.HiddenPName.CalcValue;
                    TC.CalcValue = (dataset_GetOrthesisRceptionReportInfo != null ? Globals.ToStringCore(dataset_GetOrthesisRceptionReportInfo.Tckimlikno) : "");
                    TELNO.CalcValue = (dataset_GetOrthesisRceptionReportInfo != null ? Globals.ToStringCore(dataset_GetOrthesisRceptionReportInfo.MobilePhone) : "");
                    ADRESS.CalcValue = (dataset_GetOrthesisRceptionReportInfo != null ? Globals.ToStringCore(dataset_GetOrthesisRceptionReportInfo.HomeAddress) : "");
                    NewField8.CalcValue = NewField8.Value;
                    NewField9.CalcValue = NewField9.Value;
                    PAYERID.CalcValue = (dataset_GetOrthesisRceptionReportInfo != null ? Globals.ToStringCore(dataset_GetOrthesisRceptionReportInfo.Payerid) : "");
                    return new TTReportObject[] { NewField1,NewField2,NewField12,NewField3,NewField4,NewField5,NewField6,NewField14,NewField15,HiddenPName,NewField7,FULLNAME,TC,TELNO,ADRESS,NewField8,NewField9,PAYERID};
                }

                public override void RunScript()
                {
#region HEADERPART FOOTER_Script
                    if (this.PAYERID.CalcValue.Equals("d42701cb-8539-45ac-b8d5-cdf478d720fa"))
                    {
                        // FTR için kurum SGK (60/c1-c3-c9) ise görünmesin, istek no:44949
                        this.NewField7.Visible = TTReportTool.EvetHayirEnum.ehHayir;
                        this.NewField8.Visible = TTReportTool.EvetHayirEnum.ehHayir;
                        this.NewField9.Visible = TTReportTool.EvetHayirEnum.ehHayir;
                    }
                    else
                    {
                        this.NewField7.Visible = TTReportTool.EvetHayirEnum.ehEvet;
                        this.NewField8.Visible = TTReportTool.EvetHayirEnum.ehEvet;
                        this.NewField9.Visible = TTReportTool.EvetHayirEnum.ehEvet;
                    }
#endregion HEADERPART FOOTER_Script
                }
            }

        }

        public HEADERPARTGroup HEADERPART;

        public partial class MAINGroup : TTReportGroup
        {
            public OrthesisProsthesisPatientCommitReport MyParentReport
            {
                get { return (OrthesisProsthesisPatientCommitReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField Code { get {return Body().Code;} }
            public TTReportField Name { get {return Body().Name;} }
            public TTReportField Side { get {return Body().Side;} }
            public TTReportField Miad { get {return Body().Miad;} }
            public TTReportField ProcedureDefObJId { get {return Body().ProcedureDefObJId;} }
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
                list[0] = new TTReportNqlData<OrthesisProsthesisProcedure.GetOrthesisProsthesisProcedureByAction_Class>("GetOrthesisProsthesisProcedureByAction", OrthesisProsthesisProcedure.GetOrthesisProsthesisProcedureByAction((string)TTObjectDefManager.Instance.DataTypes["String50"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public OrthesisProsthesisPatientCommitReport MyParentReport
                {
                    get { return (OrthesisProsthesisPatientCommitReport)ParentReport; }
                }
                
                public TTReportField Code;
                public TTReportField Name;
                public TTReportField Side;
                public TTReportField Miad;
                public TTReportField ProcedureDefObJId; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 7;
                    RepeatCount = 0;
                    
                    Code = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 2, 36, 7, false);
                    Code.Name = "Code";
                    Code.FieldType = ReportFieldTypeEnum.ftVariable;
                    Code.MultiLine = EvetHayirEnum.ehEvet;
                    Code.NoClip = EvetHayirEnum.ehEvet;
                    Code.WordBreak = EvetHayirEnum.ehEvet;
                    Code.ExpandTabs = EvetHayirEnum.ehEvet;
                    Code.Value = @"{#PROCEDURECODE#}";

                    Name = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 2, 137, 7, false);
                    Name.Name = "Name";
                    Name.FieldType = ReportFieldTypeEnum.ftVariable;
                    Name.MultiLine = EvetHayirEnum.ehEvet;
                    Name.NoClip = EvetHayirEnum.ehEvet;
                    Name.WordBreak = EvetHayirEnum.ehEvet;
                    Name.ExpandTabs = EvetHayirEnum.ehEvet;
                    Name.Value = @"{#PROCEDURENAME#}";

                    Side = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 2, 165, 7, false);
                    Side.Name = "Side";
                    Side.FieldType = ReportFieldTypeEnum.ftVariable;
                    Side.MultiLine = EvetHayirEnum.ehEvet;
                    Side.NoClip = EvetHayirEnum.ehEvet;
                    Side.WordBreak = EvetHayirEnum.ehEvet;
                    Side.ExpandTabs = EvetHayirEnum.ehEvet;
                    Side.ObjectDefName = "SideEnum";
                    Side.DataMember = "DISPLAYTEXT";
                    Side.Value = @"{#SIDE#}";

                    Miad = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 169, 2, 209, 7, false);
                    Miad.Name = "Miad";
                    Miad.MultiLine = EvetHayirEnum.ehEvet;
                    Miad.NoClip = EvetHayirEnum.ehEvet;
                    Miad.WordBreak = EvetHayirEnum.ehEvet;
                    Miad.ExpandTabs = EvetHayirEnum.ehEvet;
                    Miad.Value = @"";

                    ProcedureDefObJId = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 219, 2, 244, 7, false);
                    ProcedureDefObJId.Name = "ProcedureDefObJId";
                    ProcedureDefObJId.Visible = EvetHayirEnum.ehHayir;
                    ProcedureDefObJId.FieldType = ReportFieldTypeEnum.ftVariable;
                    ProcedureDefObJId.Value = @"{#PROCEDUREDEFOBJECTID#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    OrthesisProsthesisProcedure.GetOrthesisProsthesisProcedureByAction_Class dataset_GetOrthesisProsthesisProcedureByAction = ParentGroup.rsGroup.GetCurrentRecord<OrthesisProsthesisProcedure.GetOrthesisProsthesisProcedureByAction_Class>(0);
                    Code.CalcValue = (dataset_GetOrthesisProsthesisProcedureByAction != null ? Globals.ToStringCore(dataset_GetOrthesisProsthesisProcedureByAction.Procedurecode) : "");
                    Name.CalcValue = (dataset_GetOrthesisProsthesisProcedureByAction != null ? Globals.ToStringCore(dataset_GetOrthesisProsthesisProcedureByAction.Procedurename) : "");
                    Side.CalcValue = (dataset_GetOrthesisProsthesisProcedureByAction != null ? Globals.ToStringCore(dataset_GetOrthesisProsthesisProcedureByAction.Side) : "");
                    Side.PostFieldValueCalculation();
                    Miad.CalcValue = Miad.Value;
                    ProcedureDefObJId.CalcValue = (dataset_GetOrthesisProsthesisProcedureByAction != null ? Globals.ToStringCore(dataset_GetOrthesisProsthesisProcedureByAction.Proceduredefobjectid) : "");
                    return new TTReportObject[] { Code,Name,Side,Miad,ProcedureDefObJId};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    TTObjectContext context = new TTObjectContext(true);
                    OrtesisProsthesisDefinition.GetOrtesisProsthesisDefinitions_Class[] p = OrtesisProsthesisDefinition.GetOrtesisProsthesisDefinitions(" WHERE OBJECTID='" + ProcedureDefObJId.CalcValue+"'").ToArray();
                    Miad.CalcValue = p[0].Warranty;
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

        public OrthesisProsthesisPatientCommitReport()
        {
            HEADERPART = new HEADERPARTGroup(this,"HEADERPART");
            MAIN = new MAINGroup(HEADERPART,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "TTOBJECTID", @"", true, true, false, new Guid("53c9e989-dad5-4f3f-b973-d0bda68f0942"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["String50"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "ORTHESISPROSTHESISPATIENTCOMMITREPORT";
            Caption = "HASTA TAAHHÜTNAMESİ";
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
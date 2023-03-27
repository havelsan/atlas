
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
    /// Doğum Raporu
    /// </summary>
    public partial class BirthReportReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class HEADERGroup : TTReportGroup
        {
            public BirthReportReport MyParentReport
            {
                get { return (BirthReportReport)ParentReport; }
            }

            new public HEADERGroupHeader Header()
            {
                return (HEADERGroupHeader)_header;
            }

            new public HEADERGroupFooter Footer()
            {
                return (HEADERGroupFooter)_footer;
            }

            public TTReportField NewField0 { get {return Footer().NewField0;} }
            public TTReportShape NewLine77 { get {return Footer().NewLine77;} }
            public HEADERGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public HEADERGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new HEADERGroupHeader(this);
                _footer = new HEADERGroupFooter(this);

            }

            public partial class HEADERGroupHeader : TTReportSection
            {
                public BirthReportReport MyParentReport
                {
                    get { return (BirthReportReport)ParentReport; }
                }
                 
                public HEADERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 1;
                    IsVisible = EvetHayirEnum.ehHayir;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }
            public partial class HEADERGroupFooter : TTReportSection
            {
                public BirthReportReport MyParentReport
                {
                    get { return (BirthReportReport)ParentReport; }
                }
                
                public TTReportField NewField0;
                public TTReportShape NewLine77; 
                public HEADERGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 21;
                    IsAligned = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField0 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 7, 33, 11, false);
                    NewField0.Name = "NewField0";
                    NewField0.Value = @"TASNİF DIŞI";

                    NewLine77 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 11, 33, 11, false);
                    NewLine77.Name = "NewLine77";
                    NewLine77.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField0.CalcValue = NewField0.Value;
                    return new TTReportObject[] { NewField0};
                }
            }

        }

        public HEADERGroup HEADER;

        public partial class NOTGroup : TTReportGroup
        {
            public BirthReportReport MyParentReport
            {
                get { return (BirthReportReport)ParentReport; }
            }

            new public NOTGroupHeader Header()
            {
                return (NOTGroupHeader)_header;
            }

            new public NOTGroupFooter Footer()
            {
                return (NOTGroupFooter)_footer;
            }

            public TTReportField HEADER { get {return Header().HEADER;} }
            public TTReportField ACTIONDATE { get {return Header().ACTIONDATE;} }
            public TTReportField SAG { get {return Header().SAG;} }
            public TTReportField KONU { get {return Header().KONU;} }
            public TTReportField NewField7 { get {return Header().NewField7;} }
            public TTReportField NewField10 { get {return Header().NewField10;} }
            public TTReportShape NewLine78 { get {return Header().NewLine78;} }
            public TTReportField BIRIMPROTOKOL { get {return Header().BIRIMPROTOKOL;} }
            public TTReportField ACTIONID { get {return Header().ACTIONID;} }
            public TTReportField BIRIMADI { get {return Header().BIRIMADI;} }
            public TTReportField ACTIONDATE2 { get {return Header().ACTIONDATE2;} }
            public TTReportField SITENAME { get {return Header().SITENAME;} }
            public TTReportField SITECITY { get {return Header().SITECITY;} }
            public TTReportField RAPORNO { get {return Header().RAPORNO;} }
            public TTReportField KURUM { get {return Header().KURUM;} }
            public TTReportField NewField1 { get {return Footer().NewField1;} }
            public TTReportField NewField2 { get {return Footer().NewField2;} }
            public TTReportField NewField3 { get {return Footer().NewField3;} }
            public TTReportField NewField4 { get {return Footer().NewField4;} }
            public TTReportField NewField5 { get {return Footer().NewField5;} }
            public TTReportField NewField6 { get {return Footer().NewField6;} }
            public TTReportField NewField77 { get {return Footer().NewField77;} }
            public TTReportField XXXXXXPROTNO { get {return Footer().XXXXXXPROTNO;} }
            public TTReportField PROTOKOLNO { get {return Footer().PROTOKOLNO;} }
            public TTReportField CINSIYET { get {return Footer().CINSIYET;} }
            public TTReportField AGIRLIK { get {return Footer().AGIRLIK;} }
            public TTReportField BOY { get {return Footer().BOY;} }
            public TTReportField NewField13 { get {return Footer().NewField13;} }
            public TTReportField NewField14 { get {return Footer().NewField14;} }
            public TTReportField NewField15 { get {return Footer().NewField15;} }
            public TTReportField NewField16 { get {return Footer().NewField16;} }
            public TTReportField NewField17 { get {return Footer().NewField17;} }
            public TTReportField NewField18 { get {return Footer().NewField18;} }
            public TTReportShape NewLine { get {return Footer().NewLine;} }
            public TTReportField BIRIM { get {return Footer().BIRIM;} }
            public TTReportField NewField33 { get {return Footer().NewField33;} }
            public TTReportField DOGUMTURU { get {return Footer().DOGUMTURU;} }
            public TTReportField NewField35 { get {return Footer().NewField35;} }
            public TTReportField HEADDOCTOR { get {return Footer().HEADDOCTOR;} }
            public TTReportField NewField34 { get {return Footer().NewField34;} }
            public TTReportField ESININADI { get {return Footer().ESININADI;} }
            public TTReportField NewField53 { get {return Footer().NewField53;} }
            public TTReportField NewField36 { get {return Footer().NewField36;} }
            public TTReportField DURUMU { get {return Footer().DURUMU;} }
            public TTReportField NewField54 { get {return Footer().NewField54;} }
            public TTReportField NewField38 { get {return Footer().NewField38;} }
            public TTReportField ANNEADI { get {return Footer().ANNEADI;} }
            public TTReportField NewField37 { get {return Footer().NewField37;} }
            public TTReportField NewField83 { get {return Footer().NewField83;} }
            public TTReportField DOGUMTARIHI { get {return Footer().DOGUMTARIHI;} }
            public TTReportField NewField73 { get {return Footer().NewField73;} }
            public TTReportField USERNAME { get {return Footer().USERNAME;} }
            public TTReportField SINRUT { get {return Footer().SINRUT;} }
            public TTReportField UZ { get {return Footer().UZ;} }
            public TTReportField DIPSIC { get {return Footer().DIPSIC;} }
            public TTReportField DIPSICLABEL { get {return Footer().DIPSICLABEL;} }
            public TTReportField SICILKULLAN { get {return Footer().SICILKULLAN;} }
            public TTReportField UNVANKULLAN { get {return Footer().UNVANKULLAN;} }
            public TTReportField UNVAN { get {return Footer().UNVAN;} }
            public TTReportField NewField177 { get {return Footer().NewField177;} }
            public TTReportField PROCEDUREDOCTOR { get {return Footer().PROCEDUREDOCTOR;} }
            public TTReportField NewField161 { get {return Footer().NewField161;} }
            public TTReportField DOGUMSAATI { get {return Footer().DOGUMSAATI;} }
            public NOTGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public NOTGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<BirthReport.GetBirtfReport_Class>("GetBirtfReport", BirthReport.GetBirtfReport((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new NOTGroupHeader(this);
                _footer = new NOTGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class NOTGroupHeader : TTReportSection
            {
                public BirthReportReport MyParentReport
                {
                    get { return (BirthReportReport)ParentReport; }
                }
                
                public TTReportField HEADER;
                public TTReportField ACTIONDATE;
                public TTReportField SAG;
                public TTReportField KONU;
                public TTReportField NewField7;
                public TTReportField NewField10;
                public TTReportShape NewLine78;
                public TTReportField BIRIMPROTOKOL;
                public TTReportField ACTIONID;
                public TTReportField BIRIMADI;
                public TTReportField ACTIONDATE2;
                public TTReportField SITENAME;
                public TTReportField SITECITY;
                public TTReportField RAPORNO;
                public TTReportField KURUM; 
                public NOTGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 65;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    HEADER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 5, 167, 17, false);
                    HEADER.Name = "HEADER";
                    HEADER.FieldType = ReportFieldTypeEnum.ftVariable;
                    HEADER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HEADER.MultiLine = EvetHayirEnum.ehEvet;
                    HEADER.NoClip = EvetHayirEnum.ehEvet;
                    HEADER.WordBreak = EvetHayirEnum.ehEvet;
                    HEADER.TextFont.Bold = true;
                    HEADER.Value = @"{%SITENAME%}
{%SITECITY%}
";

                    ACTIONDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 158, 29, 207, 33, false);
                    ACTIONDATE.Name = "ACTIONDATE";
                    ACTIONDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACTIONDATE.TextFormat = @"dd/MM/yyyy";
                    ACTIONDATE.Value = @"{#ACTIONDATE#}";

                    SAG = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 30, 148, 34, false);
                    SAG.Name = "SAG";
                    SAG.FieldType = ReportFieldTypeEnum.ftVariable;
                    SAG.Value = @"SAĞ:9322-{%BIRIMPROTOKOL%}-{%ACTIONDATE2%}/{%BIRIMADI%}-{%ACTIONID%}";

                    KONU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 34, 74, 39, false);
                    KONU.Name = "KONU";
                    KONU.FieldType = ReportFieldTypeEnum.ftVariable;
                    KONU.Value = @"KONU:Doğum Raporu - {%RAPORNO%}";

                    NewField7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 84, 56, 121, 60, false);
                    NewField7.Name = "NewField7";
                    NewField7.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField7.TextFont.Bold = true;
                    NewField7.Value = @"DOĞUM RAPORU";

                    NewField10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 9, 33, 13, false);
                    NewField10.Name = "NewField10";
                    NewField10.Value = @"TASNİF DIŞI";

                    NewLine78 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 13, 33, 13, false);
                    NewLine78.Name = "NewLine78";
                    NewLine78.DrawStyle = DrawStyleConstants.vbSolid;

                    BIRIMPROTOKOL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 164, 36, 189, 41, false);
                    BIRIMPROTOKOL.Name = "BIRIMPROTOKOL";
                    BIRIMPROTOKOL.Visible = EvetHayirEnum.ehHayir;
                    BIRIMPROTOKOL.FieldType = ReportFieldTypeEnum.ftVariable;
                    BIRIMPROTOKOL.Value = @"{#PROTOCOLNO#}";

                    ACTIONID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 164, 42, 189, 47, false);
                    ACTIONID.Name = "ACTIONID";
                    ACTIONID.Visible = EvetHayirEnum.ehHayir;
                    ACTIONID.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACTIONID.Value = @"{#ACTIONID#}";

                    BIRIMADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 164, 48, 189, 53, false);
                    BIRIMADI.Name = "BIRIMADI";
                    BIRIMADI.Visible = EvetHayirEnum.ehHayir;
                    BIRIMADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    BIRIMADI.Value = @"{#BIRIMADI#}";

                    ACTIONDATE2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 164, 53, 199, 57, false);
                    ACTIONDATE2.Name = "ACTIONDATE2";
                    ACTIONDATE2.Visible = EvetHayirEnum.ehHayir;
                    ACTIONDATE2.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACTIONDATE2.TextFormat = @"yy";
                    ACTIONDATE2.Value = @"{#ACTIONDATE#}";

                    SITENAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 178, 4, 203, 9, false);
                    SITENAME.Name = "SITENAME";
                    SITENAME.Visible = EvetHayirEnum.ehHayir;
                    SITENAME.FieldType = ReportFieldTypeEnum.ftExpression;
                    SITENAME.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", ""XXXXXX"")";

                    SITECITY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 179, 10, 204, 15, false);
                    SITECITY.Name = "SITECITY";
                    SITECITY.Visible = EvetHayirEnum.ehHayir;
                    SITECITY.FieldType = ReportFieldTypeEnum.ftExpression;
                    SITECITY.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", ""XXXXXX"")";

                    RAPORNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 164, 58, 199, 62, false);
                    RAPORNO.Name = "RAPORNO";
                    RAPORNO.Visible = EvetHayirEnum.ehHayir;
                    RAPORNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPORNO.TextFormat = @"yy";
                    RAPORNO.Value = @"{#REPORTNO#}";

                    KURUM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 172, 17, 197, 22, false);
                    KURUM.Name = "KURUM";
                    KURUM.Visible = EvetHayirEnum.ehHayir;
                    KURUM.FieldType = ReportFieldTypeEnum.ftExpression;
                    KURUM.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""RAPORKURUMU"", ""T.C. XXXXXX"")";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    BirthReport.GetBirtfReport_Class dataset_GetBirtfReport = ParentGroup.rsGroup.GetCurrentRecord<BirthReport.GetBirtfReport_Class>(0);
                    SITENAME.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "XXXXXX");
                    SITECITY.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "XXXXXX");
                    HEADER.CalcValue = MyParentReport.NOT.SITENAME.CalcValue + @"
" + MyParentReport.NOT.SITECITY.CalcValue + @"
";
                    ACTIONDATE.CalcValue = (dataset_GetBirtfReport != null ? Globals.ToStringCore(dataset_GetBirtfReport.ActionDate) : "");
                    BIRIMPROTOKOL.CalcValue = (dataset_GetBirtfReport != null ? Globals.ToStringCore(dataset_GetBirtfReport.ProtocolNo) : "");
                    ACTIONDATE2.CalcValue = (dataset_GetBirtfReport != null ? Globals.ToStringCore(dataset_GetBirtfReport.ActionDate) : "");
                    BIRIMADI.CalcValue = (dataset_GetBirtfReport != null ? Globals.ToStringCore(dataset_GetBirtfReport.Birimadi) : "");
                    ACTIONID.CalcValue = (dataset_GetBirtfReport != null ? Globals.ToStringCore(dataset_GetBirtfReport.Actionid) : "");
                    SAG.CalcValue = @"SAĞ:9322-" + MyParentReport.NOT.BIRIMPROTOKOL.CalcValue + @"-" + MyParentReport.NOT.ACTIONDATE2.FormattedValue + @"/" + MyParentReport.NOT.BIRIMADI.CalcValue + @"-" + MyParentReport.NOT.ACTIONID.CalcValue;
                    RAPORNO.CalcValue = (dataset_GetBirtfReport != null ? Globals.ToStringCore(dataset_GetBirtfReport.ReportNo) : "");
                    KONU.CalcValue = @"KONU:Doğum Raporu - " + MyParentReport.NOT.RAPORNO.FormattedValue;
                    NewField7.CalcValue = NewField7.Value;
                    NewField10.CalcValue = NewField10.Value;
                    KURUM.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("RAPORKURUMU", "T.C. XXXXXX");
                    return new TTReportObject[] { SITENAME,SITECITY,HEADER,ACTIONDATE,BIRIMPROTOKOL,ACTIONDATE2,BIRIMADI,ACTIONID,SAG,RAPORNO,KONU,NewField7,NewField10,KURUM};
                }
            }
            public partial class NOTGroupFooter : TTReportSection
            {
                public BirthReportReport MyParentReport
                {
                    get { return (BirthReportReport)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportField NewField2;
                public TTReportField NewField3;
                public TTReportField NewField4;
                public TTReportField NewField5;
                public TTReportField NewField6;
                public TTReportField NewField77;
                public TTReportField XXXXXXPROTNO;
                public TTReportField PROTOKOLNO;
                public TTReportField CINSIYET;
                public TTReportField AGIRLIK;
                public TTReportField BOY;
                public TTReportField NewField13;
                public TTReportField NewField14;
                public TTReportField NewField15;
                public TTReportField NewField16;
                public TTReportField NewField17;
                public TTReportField NewField18;
                public TTReportShape NewLine;
                public TTReportField BIRIM;
                public TTReportField NewField33;
                public TTReportField DOGUMTURU;
                public TTReportField NewField35;
                public TTReportField HEADDOCTOR;
                public TTReportField NewField34;
                public TTReportField ESININADI;
                public TTReportField NewField53;
                public TTReportField NewField36;
                public TTReportField DURUMU;
                public TTReportField NewField54;
                public TTReportField NewField38;
                public TTReportField ANNEADI;
                public TTReportField NewField37;
                public TTReportField NewField83;
                public TTReportField DOGUMTARIHI;
                public TTReportField NewField73;
                public TTReportField USERNAME;
                public TTReportField SINRUT;
                public TTReportField UZ;
                public TTReportField DIPSIC;
                public TTReportField DIPSICLABEL;
                public TTReportField SICILKULLAN;
                public TTReportField UNVANKULLAN;
                public TTReportField UNVAN;
                public TTReportField NewField177;
                public TTReportField PROCEDUREDOCTOR;
                public TTReportField NewField161;
                public TTReportField DOGUMSAATI; 
                public NOTGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 117;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 21, 91, 25, false);
                    NewField1.Name = "NewField1";
                    NewField1.Value = @"KİMLİĞİ                             :";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 27, 57, 31, false);
                    NewField2.Name = "NewField2";
                    NewField2.Value = @"Hastahane Protokol No";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 32, 57, 36, false);
                    NewField3.Name = "NewField3";
                    NewField3.Value = @"Birim Adı";

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 37, 57, 41, false);
                    NewField4.Name = "NewField4";
                    NewField4.Value = @"Protokol No";

                    NewField5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 67, 57, 71, false);
                    NewField5.Name = "NewField5";
                    NewField5.Value = @"Cinsiyeti";

                    NewField6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 72, 57, 76, false);
                    NewField6.Name = "NewField6";
                    NewField6.Value = @"Ağırlık(gr)";

                    NewField77 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 77, 57, 81, false);
                    NewField77.Name = "NewField77";
                    NewField77.Value = @"Boy(cm)";

                    XXXXXXPROTNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 27, 159, 31, false);
                    XXXXXXPROTNO.Name = "XXXXXXPROTNO";
                    XXXXXXPROTNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    XXXXXXPROTNO.Value = @"{#XXXXXXPROTNO#}";

                    PROTOKOLNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 37, 159, 41, false);
                    PROTOKOLNO.Name = "PROTOKOLNO";
                    PROTOKOLNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROTOKOLNO.Value = @"{#PROTOCOLNO#}";

                    CINSIYET = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 67, 159, 71, false);
                    CINSIYET.Name = "CINSIYET";
                    CINSIYET.FieldType = ReportFieldTypeEnum.ftVariable;
                    CINSIYET.ObjectDefName = "SexEnum";
                    CINSIYET.DataMember = "DISPLAYTEXT";
                    CINSIYET.Value = @"{#SEX#}";

                    AGIRLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 72, 159, 76, false);
                    AGIRLIK.Name = "AGIRLIK";
                    AGIRLIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    AGIRLIK.Value = @"{#WEIGHT#}";

                    BOY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 77, 159, 81, false);
                    BOY.Name = "BOY";
                    BOY.FieldType = ReportFieldTypeEnum.ftVariable;
                    BOY.Value = @"{#HEIGHT#}";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 57, 32, 59, 36, false);
                    NewField13.Name = "NewField13";
                    NewField13.Value = @":";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 57, 67, 59, 71, false);
                    NewField14.Name = "NewField14";
                    NewField14.Value = @":";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 57, 72, 59, 76, false);
                    NewField15.Name = "NewField15";
                    NewField15.Value = @":";

                    NewField16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 57, 77, 59, 81, false);
                    NewField16.Name = "NewField16";
                    NewField16.Value = @":";

                    NewField17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 57, 37, 59, 41, false);
                    NewField17.Name = "NewField17";
                    NewField17.Value = @":";

                    NewField18 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 57, 27, 59, 31, false);
                    NewField18.Name = "NewField18";
                    NewField18.Value = @":";

                    NewLine = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 12, 26, 90, 26, false);
                    NewLine.Name = "NewLine";
                    NewLine.DrawStyle = DrawStyleConstants.vbSolid;

                    BIRIM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 32, 159, 36, false);
                    BIRIM.Name = "BIRIM";
                    BIRIM.FieldType = ReportFieldTypeEnum.ftVariable;
                    BIRIM.Value = @"{#BIRIMADI#}";

                    NewField33 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 57, 57, 61, false);
                    NewField33.Name = "NewField33";
                    NewField33.Value = @"Doğum Türü";

                    DOGUMTURU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 57, 159, 61, false);
                    DOGUMTURU.Name = "DOGUMTURU";
                    DOGUMTURU.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOGUMTURU.Value = @"{#DOGUMSEKLI#}";

                    NewField35 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 57, 57, 59, 61, false);
                    NewField35.Name = "NewField35";
                    NewField35.Value = @":";

                    HEADDOCTOR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 96, 1, 121, 6, false);
                    HEADDOCTOR.Name = "HEADDOCTOR";
                    HEADDOCTOR.Visible = EvetHayirEnum.ehHayir;
                    HEADDOCTOR.FieldType = ReportFieldTypeEnum.ftExpression;
                    HEADDOCTOR.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HEADDOCTOR"", """")";

                    NewField34 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 42, 57, 46, false);
                    NewField34.Name = "NewField34";
                    NewField34.Value = @"Eşinin Adı";

                    ESININADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 42, 159, 46, false);
                    ESININADI.Name = "ESININADI";
                    ESININADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    ESININADI.Value = @"{#PARTNERNAME#}";

                    NewField53 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 57, 42, 59, 46, false);
                    NewField53.Name = "NewField53";
                    NewField53.Value = @":";

                    NewField36 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 62, 57, 66, false);
                    NewField36.Name = "NewField36";
                    NewField36.Value = @"Durumu";

                    DURUMU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 62, 159, 66, false);
                    DURUMU.Name = "DURUMU";
                    DURUMU.FieldType = ReportFieldTypeEnum.ftVariable;
                    DURUMU.ObjectDefName = "BirthReportBabyStatus";
                    DURUMU.DataMember = "DISPLAYTEXT";
                    DURUMU.Value = @"{#BABYSTATUS#}";

                    NewField54 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 57, 62, 59, 66, false);
                    NewField54.Name = "NewField54";
                    NewField54.Value = @":";

                    NewField38 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 47, 57, 51, false);
                    NewField38.Name = "NewField38";
                    NewField38.Value = @"Anne Adı";

                    ANNEADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 47, 159, 51, false);
                    ANNEADI.Name = "ANNEADI";
                    ANNEADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    ANNEADI.ObjectDefName = "patient";
                    ANNEADI.DataMember = "FullName";
                    ANNEADI.Value = @"{#ANNE#}";

                    NewField37 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 57, 47, 59, 51, false);
                    NewField37.Name = "NewField37";
                    NewField37.Value = @":";

                    NewField83 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 52, 57, 56, false);
                    NewField83.Name = "NewField83";
                    NewField83.Value = @"Doğum Tarihi";

                    DOGUMTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 52, 86, 56, false);
                    DOGUMTARIHI.Name = "DOGUMTARIHI";
                    DOGUMTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOGUMTARIHI.TextFormat = @"dd/MM/yyyy";
                    DOGUMTARIHI.Value = @"{#BABYBIRTHDATE#}";

                    NewField73 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 57, 52, 59, 56, false);
                    NewField73.Name = "NewField73";
                    NewField73.Value = @":";

                    USERNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 171, 104, 296, 108, false);
                    USERNAME.Name = "USERNAME";
                    USERNAME.Visible = EvetHayirEnum.ehHayir;
                    USERNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    USERNAME.Value = @"";

                    SINRUT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 171, 108, 296, 112, false);
                    SINRUT.Name = "SINRUT";
                    SINRUT.Visible = EvetHayirEnum.ehHayir;
                    SINRUT.FieldType = ReportFieldTypeEnum.ftVariable;
                    SINRUT.Value = @"";

                    UZ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 171, 116, 296, 120, false);
                    UZ.Name = "UZ";
                    UZ.Visible = EvetHayirEnum.ehHayir;
                    UZ.FieldType = ReportFieldTypeEnum.ftVariable;
                    UZ.MultiLine = EvetHayirEnum.ehEvet;
                    UZ.NoClip = EvetHayirEnum.ehEvet;
                    UZ.WordBreak = EvetHayirEnum.ehEvet;
                    UZ.Value = @"";

                    DIPSIC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 199, 112, 269, 116, false);
                    DIPSIC.Name = "DIPSIC";
                    DIPSIC.Visible = EvetHayirEnum.ehHayir;
                    DIPSIC.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIPSIC.Value = @"DIPSIC";

                    DIPSICLABEL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 171, 112, 198, 116, false);
                    DIPSICLABEL.Name = "DIPSICLABEL";
                    DIPSICLABEL.Visible = EvetHayirEnum.ehHayir;
                    DIPSICLABEL.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIPSICLABEL.Value = @"DIPLOMASICIL";

                    SICILKULLAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 171, 94, 198, 98, false);
                    SICILKULLAN.Name = "SICILKULLAN";
                    SICILKULLAN.Visible = EvetHayirEnum.ehHayir;
                    SICILKULLAN.FieldType = ReportFieldTypeEnum.ftExpression;
                    SICILKULLAN.TextFont.Name = "Arial Narrow";
                    SICILKULLAN.TextFont.Size = 9;
                    SICILKULLAN.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""SICILKULLAN"", """")";

                    UNVANKULLAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 171, 99, 197, 103, false);
                    UNVANKULLAN.Name = "UNVANKULLAN";
                    UNVANKULLAN.Visible = EvetHayirEnum.ehHayir;
                    UNVANKULLAN.FieldType = ReportFieldTypeEnum.ftExpression;
                    UNVANKULLAN.MultiLine = EvetHayirEnum.ehEvet;
                    UNVANKULLAN.NoClip = EvetHayirEnum.ehEvet;
                    UNVANKULLAN.WordBreak = EvetHayirEnum.ehEvet;
                    UNVANKULLAN.TextFont.Name = "Arial Narrow";
                    UNVANKULLAN.TextFont.Size = 9;
                    UNVANKULLAN.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""UNVANKULLAN"", """")";

                    UNVAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 172, 78, 198, 82, false);
                    UNVAN.Name = "UNVAN";
                    UNVAN.Visible = EvetHayirEnum.ehHayir;
                    UNVAN.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNVAN.MultiLine = EvetHayirEnum.ehEvet;
                    UNVAN.NoClip = EvetHayirEnum.ehEvet;
                    UNVAN.WordBreak = EvetHayirEnum.ehEvet;
                    UNVAN.TextFont.Name = "Arial Narrow";
                    UNVAN.TextFont.Size = 9;
                    UNVAN.Value = @"";

                    NewField177 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 86, 57, 90, false);
                    NewField177.Name = "NewField177";
                    NewField177.Value = @"Raporu Yazan Doktor";

                    PROCEDUREDOCTOR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 86, 159, 116, false);
                    PROCEDUREDOCTOR.Name = "PROCEDUREDOCTOR";
                    PROCEDUREDOCTOR.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROCEDUREDOCTOR.MultiLine = EvetHayirEnum.ehEvet;
                    PROCEDUREDOCTOR.NoClip = EvetHayirEnum.ehEvet;
                    PROCEDUREDOCTOR.WordBreak = EvetHayirEnum.ehEvet;
                    PROCEDUREDOCTOR.ExpandTabs = EvetHayirEnum.ehEvet;
                    PROCEDUREDOCTOR.Value = @"";

                    NewField161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 57, 86, 59, 90, false);
                    NewField161.Name = "NewField161";
                    NewField161.Value = @":";

                    DOGUMSAATI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 86, 52, 112, 56, false);
                    DOGUMSAATI.Name = "DOGUMSAATI";
                    DOGUMSAATI.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOGUMSAATI.TextFormat = @"Short Time";
                    DOGUMSAATI.Value = @"{#BIRTHTIME#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    BirthReport.GetBirtfReport_Class dataset_GetBirtfReport = ParentGroup.rsGroup.GetCurrentRecord<BirthReport.GetBirtfReport_Class>(0);
                    NewField1.CalcValue = NewField1.Value;
                    NewField2.CalcValue = NewField2.Value;
                    NewField3.CalcValue = NewField3.Value;
                    NewField4.CalcValue = NewField4.Value;
                    NewField5.CalcValue = NewField5.Value;
                    NewField6.CalcValue = NewField6.Value;
                    NewField77.CalcValue = NewField77.Value;
                    XXXXXXPROTNO.CalcValue = (dataset_GetBirtfReport != null ? Globals.ToStringCore(dataset_GetBirtfReport.XXXXXXprotno) : "");
                    PROTOKOLNO.CalcValue = (dataset_GetBirtfReport != null ? Globals.ToStringCore(dataset_GetBirtfReport.ProtocolNo) : "");
                    CINSIYET.CalcValue = (dataset_GetBirtfReport != null ? Globals.ToStringCore(dataset_GetBirtfReport.Sex) : "");
                    CINSIYET.PostFieldValueCalculation();
                    AGIRLIK.CalcValue = (dataset_GetBirtfReport != null ? Globals.ToStringCore(dataset_GetBirtfReport.Weight) : "");
                    BOY.CalcValue = (dataset_GetBirtfReport != null ? Globals.ToStringCore(dataset_GetBirtfReport.Height) : "");
                    NewField13.CalcValue = NewField13.Value;
                    NewField14.CalcValue = NewField14.Value;
                    NewField15.CalcValue = NewField15.Value;
                    NewField16.CalcValue = NewField16.Value;
                    NewField17.CalcValue = NewField17.Value;
                    NewField18.CalcValue = NewField18.Value;
                    BIRIM.CalcValue = (dataset_GetBirtfReport != null ? Globals.ToStringCore(dataset_GetBirtfReport.Birimadi) : "");
                    NewField33.CalcValue = NewField33.Value;
                    DOGUMTURU.CalcValue = (dataset_GetBirtfReport != null ? Globals.ToStringCore(dataset_GetBirtfReport.Dogumsekli) : "");
                    NewField35.CalcValue = NewField35.Value;
                    NewField34.CalcValue = NewField34.Value;
                    ESININADI.CalcValue = (dataset_GetBirtfReport != null ? Globals.ToStringCore(dataset_GetBirtfReport.PartnerName) : "");
                    NewField53.CalcValue = NewField53.Value;
                    NewField36.CalcValue = NewField36.Value;
                    DURUMU.CalcValue = (dataset_GetBirtfReport != null ? Globals.ToStringCore(dataset_GetBirtfReport.BabyStatus) : "");
                    DURUMU.PostFieldValueCalculation();
                    NewField54.CalcValue = NewField54.Value;
                    NewField38.CalcValue = NewField38.Value;
                    ANNEADI.CalcValue = (dataset_GetBirtfReport != null ? Globals.ToStringCore(dataset_GetBirtfReport.Anne) : "");
                    ANNEADI.PostFieldValueCalculation();
                    NewField37.CalcValue = NewField37.Value;
                    NewField83.CalcValue = NewField83.Value;
                    DOGUMTARIHI.CalcValue = (dataset_GetBirtfReport != null ? Globals.ToStringCore(dataset_GetBirtfReport.BabyBirthDate) : "");
                    NewField73.CalcValue = NewField73.Value;
                    USERNAME.CalcValue = @"";
                    SINRUT.CalcValue = @"";
                    UZ.CalcValue = @"";
                    DIPSIC.CalcValue = @"DIPSIC";
                    DIPSICLABEL.CalcValue = @"DIPLOMASICIL";
                    UNVAN.CalcValue = @"";
                    NewField177.CalcValue = NewField177.Value;
                    PROCEDUREDOCTOR.CalcValue = @"";
                    NewField161.CalcValue = NewField161.Value;
                    DOGUMSAATI.CalcValue = (dataset_GetBirtfReport != null ? Globals.ToStringCore(dataset_GetBirtfReport.BirthTime) : "");
                    HEADDOCTOR.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HEADDOCTOR", "");
                    SICILKULLAN.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("SICILKULLAN", "");
                    UNVANKULLAN.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("UNVANKULLAN", "");
                    return new TTReportObject[] { NewField1,NewField2,NewField3,NewField4,NewField5,NewField6,NewField77,XXXXXXPROTNO,PROTOKOLNO,CINSIYET,AGIRLIK,BOY,NewField13,NewField14,NewField15,NewField16,NewField17,NewField18,BIRIM,NewField33,DOGUMTURU,NewField35,NewField34,ESININADI,NewField53,NewField36,DURUMU,NewField54,NewField38,ANNEADI,NewField37,NewField83,DOGUMTARIHI,NewField73,USERNAME,SINRUT,UZ,DIPSIC,DIPSICLABEL,UNVAN,NewField177,PROCEDUREDOCTOR,NewField161,DOGUMSAATI,HEADDOCTOR,SICILKULLAN,UNVANKULLAN};
                }

                public override void RunScript()
                {
#region NOT FOOTER_Script
                    if(this.CINSIYET.CalcValue == "Kadın")
                this.CINSIYET.CalcValue= "Kız";
      
            string sObjectID = ((TTReportClasses.BirthReportReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            TTObjectContext context = new TTObjectContext(true);//yeni context oluşturduk
            BindingList<TTObjectClasses.BirthReport> actions = TTObjectClasses.BirthReport.GetBirthDateReportById(context, sObjectID);
            if(actions.Count > 0)
            {
                TTObjectClasses.BirthReport theObj = actions[0];
                if(theObj.ProcedureDoctor!=null)
                    this.PROCEDUREDOCTOR.CalcValue =theObj.ProcedureDoctor.SignatureBlock;
                
                // INC020214 EXTERNAL ID'li TASK GEREĞİNCE ONAY ALANLARI KALDIRILDI.
                /*
                if (TTObjectClasses.SystemParameter.GetParameterValue("REPORTAPPROVALPOSITION","HEADDOCTOR") == "IITABIP")
                {
                    this.ONAY.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("IITABIP","").ToString();
                    this.ONAYUNVAN.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("IITABIPUNVANI","").ToString();
                    this.ONAYUNVAN2.CalcValue = "II.Tabip";
                    
                }
                else
                {
                    this.ONAY.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HEADDOCTOR","").ToString();
                    this.ONAYUNVAN.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HEADDOCTORTITAL","").ToString();
                    this.ONAYUNVAN2.CalcValue = "Baştabip";
                }
*/
                //                if (theObj.ProcedureDoctor!=null)
                //                {
                //                    this.USERNAME.CalcValue = theObj.ProcedureDoctor.Name;
                //                    //                    if(theObj.ProcedureDoctor.MilitaryClass != null)
                //                    //                        this.SINIFONAYRUTBEONAY.CalcValue = theObj.ProcedureDoctor.MilitaryClass.Name;
                //                    //                    if(theObj.ProcedureDoctor.Rank != null)
                //                    //                        this.SINIFONAYRUTBEONAY.CalcValue += " " + theObj.ProcedureDoctor.Rank.Name;
                //                    //                    this.UZ.CalcValue = theObj.ProcedureDoctor.Title.ToString();
                //                    if(this.SICILKULLAN.CalcValue=="TRUE")
                //                    {
                //                        this.DIPSICLABEL.CalcValue= "SİCİL NO :";
                //                        this.DIPSIC.CalcValue= theObj.ProcedureDoctor.EmploymentRecordID;
                //                    }
                //                    else
                //                    {
                //                        this.DIPSICLABEL.CalcValue= "DİPLOMA NO :";
                //                        this.DIPSIC.CalcValue=theObj.ProcedureDoctor.DiplomaNo;
                //                    }
//
//
                //                    if(this.UNVANKULLAN.CalcValue!="TRUE")
                //                    {
                //                        if(theObj.ProcedureDoctor.MilitaryClass != null)
                //                            this.SINRUT.CalcValue = theObj.ProcedureDoctor.MilitaryClass.Name;
                //                        if(theObj.ProcedureDoctor.Rank != null)
                //                            this.SINRUT.CalcValue = this.SINRUT.CalcValue + " " + theObj.ProcedureDoctor.Rank.Name;
                //                    }
                //                    else
                //                    {
                //                        if(this.UNVAN.CalcValue=="")
                //                        {
                //                            if(theObj.ProcedureDoctor.MilitaryClass != null)
                //                                this.SINRUT.CalcValue = theObj.ProcedureDoctor.MilitaryClass.Name;
                //                            if(theObj.ProcedureDoctor.Rank != null)
                //                                this.SINRUT.CalcValue = this.SINRUT.CalcValue + " " + theObj.ProcedureDoctor.Rank.Name;
                //                        }
                //                        else
                //                        {
                //                            this.SINRUT.CalcValue=theObj.ProcedureDoctor.Title.ToString();
                //                            if(theObj.ProcedureDoctor.Rank != null)
                //                                this.SINRUT.CalcValue = this.SINRUT.CalcValue + " " + theObj.ProcedureDoctor.Rank.Name;
                //                        }
//
                //                    }
                //                    if (theObj.ProcedureDoctor.ResourceSpecialities  != null)
                //                    {
                //                        foreach(ResourceSpecialityGrid resSepeciality in theObj.ProcedureDoctor.ResourceSpecialities)
                //                        {
                //                            if(resSepeciality.Speciality != null && (resSepeciality.MainSpeciality==true ||  (resSepeciality.ObjectID  == null)))
                //                            {
                //                                this.UZ.CalcValue = resSepeciality.Speciality.Name;
                //                            }
                //                        }
                //                    }
                //                }
            }
#endregion NOT FOOTER_Script
                }
            }

        }

        public NOTGroup NOT;

        public partial class MAINGroup : TTReportGroup
        {
            public BirthReportReport MyParentReport
            {
                get { return (BirthReportReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportRTF Report { get {return Body().Report;} }
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
                public BirthReportReport MyParentReport
                {
                    get { return (BirthReportReport)ParentReport; }
                }
                
                public TTReportRTF Report; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 15;
                    RepeatCount = 0;
                    
                    Report = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 11, 3, 207, 12, false);
                    Report.Name = "Report";
                    Report.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Report.CalcValue = Report.Value;
                    return new TTReportObject[] { Report};
                }
                public override void RunPreScript()
                {
#region MAIN BODY_PreScript
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((BirthReportReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            BirthReport birthReport = (BirthReport)context.GetObject(new Guid(sObjectID),"BirthReport");
            this.Report.Value=birthReport.Report;
#endregion MAIN BODY_PreScript
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public BirthReportReport()
        {
            HEADER = new HEADERGroup(this,"HEADER");
            NOT = new NOTGroup(HEADER,"NOT");
            MAIN = new MAINGroup(NOT,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "Doğum Raporu", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "BIRTHREPORTREPORT";
            Caption = "Doğum Raporu";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            PaperSize = 999;
            p_PageWidth = 0;
            p_PageHeight = 0;
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
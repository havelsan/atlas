
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
    /// Geçici Adli Muayene Raporu
    /// </summary>
    public partial class TemporaryForensicReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["String50"].ConvertValue("");
        }

        public partial class HEADERGroup : TTReportGroup
        {
            public TemporaryForensicReport MyParentReport
            {
                get { return (TemporaryForensicReport)ParentReport; }
            }

            new public HEADERGroupHeader Header()
            {
                return (HEADERGroupHeader)_header;
            }

            new public HEADERGroupFooter Footer()
            {
                return (HEADERGroupFooter)_footer;
            }

            public TTReportField RAPORTIPI1 { get {return Header().RAPORTIPI1;} }
            public TTReportField EPISODE { get {return Header().EPISODE;} }
            public HEADERGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public HEADERGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<ForensicMedicalReport.GetForensicMedicalReport_Class>("GetForensicMedicalReport", ForensicMedicalReport.GetForensicMedicalReport((string)TTObjectDefManager.Instance.DataTypes["String50"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new HEADERGroupHeader(this);
                _footer = new HEADERGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class HEADERGroupHeader : TTReportSection
            {
                public TemporaryForensicReport MyParentReport
                {
                    get { return (TemporaryForensicReport)ParentReport; }
                }
                
                public TTReportField RAPORTIPI1;
                public TTReportField EPISODE; 
                public HEADERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 15;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    RAPORTIPI1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 9, 138, 15, false);
                    RAPORTIPI1.Name = "RAPORTIPI1";
                    RAPORTIPI1.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPORTIPI1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    RAPORTIPI1.TextFont.Size = 14;
                    RAPORTIPI1.TextFont.Bold = true;
                    RAPORTIPI1.TextFont.CharSet = 162;
                    RAPORTIPI1.Value = @"";

                    EPISODE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 7, 245, 12, false);
                    EPISODE.Name = "EPISODE";
                    EPISODE.Visible = EvetHayirEnum.ehHayir;
                    EPISODE.FieldType = ReportFieldTypeEnum.ftVariable;
                    EPISODE.TextFont.Name = "Courier New";
                    EPISODE.TextFont.CharSet = 162;
                    EPISODE.Value = @"{#EPISODE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ForensicMedicalReport.GetForensicMedicalReport_Class dataset_GetForensicMedicalReport = ParentGroup.rsGroup.GetCurrentRecord<ForensicMedicalReport.GetForensicMedicalReport_Class>(0);
                    RAPORTIPI1.CalcValue = @"";
                    EPISODE.CalcValue = (dataset_GetForensicMedicalReport != null ? Globals.ToStringCore(dataset_GetForensicMedicalReport.Episode) : "");
                    return new TTReportObject[] { RAPORTIPI1,EPISODE};
                }

                public override void RunScript()
                {
#region HEADER HEADER_Script
                    TTObjectContext tto = new TTObjectContext(true);
                    Guid reportid = new Guid(this.MyParentReport.RuntimeParameters.TTOBJECTID.ToString());
                    ForensicMedicalReport rapor = (ForensicMedicalReport)tto.GetObject(reportid, typeof(ForensicMedicalReport));
                    
                        /*if (rapor.ForensicMedicalReportType.HasValue)
                        {
                            if (rapor.ForensicMedicalReportType.Value==ForensicMedicalReportTypeEnum.Certain) 
                                this.RAPORTIPI1.CalcValue = "KAT-İ ADLİ MUAYENE RAPORU";
                           else
                               
                             this.RAPORTIPI1.CalcValue = "GEÇİCİ ADLİ MUAYENE RAPORU";
                            
                          
           } */
#endregion HEADER HEADER_Script
                }
            }
            public partial class HEADERGroupFooter : TTReportSection
            {
                public TemporaryForensicReport MyParentReport
                {
                    get { return (TemporaryForensicReport)ParentReport; }
                }
                 
                public HEADERGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public HEADERGroup HEADER;

        public partial class PARTAGroup : TTReportGroup
        {
            public TemporaryForensicReport MyParentReport
            {
                get { return (TemporaryForensicReport)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField HEADER { get {return Header().HEADER;} }
            public TTReportField RAPORNO { get {return Header().RAPORNO;} }
            public TTReportField RaporTarih11 { get {return Header().RaporTarih11;} }
            public TTReportField SAG1 { get {return Header().SAG1;} }
            public TTReportShape NewLine111 { get {return Header().NewLine111;} }
            public TTReportField RaporNo11 { get {return Header().RaporNo11;} }
            public TTReportField RAPORTARIHI { get {return Header().RAPORTARIHI;} }
            public TTReportField KURUM { get {return Header().KURUM;} }
            public TTReportField SITENAME { get {return Header().SITENAME;} }
            public TTReportField SITECITY { get {return Header().SITECITY;} }
            public TTReportField OBJECTID { get {return Header().OBJECTID;} }
            public TTReportField BIRIMPROTOKOL1 { get {return Header().BIRIMPROTOKOL1;} }
            public TTReportField BIRIMPROTOKOL { get {return Header().BIRIMPROTOKOL;} }
            public TTReportField ACTIONDATE { get {return Header().ACTIONDATE;} }
            public TTReportField BIRIMADI { get {return Header().BIRIMADI;} }
            public TTReportField ACTIONID { get {return Header().ACTIONID;} }
            public TTReportField NewField11631 { get {return Header().NewField11631;} }
            public TTReportField NewField1181 { get {return Footer().NewField1181;} }
            public TTReportField NewField1161 { get {return Footer().NewField1161;} }
            public TTReportField sayfaNo1 { get {return Footer().sayfaNo1;} }
            public TTReportField NewField1191 { get {return Footer().NewField1191;} }
            public TTReportShape NewLine11111 { get {return Footer().NewLine11111;} }
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
                public TemporaryForensicReport MyParentReport
                {
                    get { return (TemporaryForensicReport)ParentReport; }
                }
                
                public TTReportField HEADER;
                public TTReportField RAPORNO;
                public TTReportField RaporTarih11;
                public TTReportField SAG1;
                public TTReportShape NewLine111;
                public TTReportField RaporNo11;
                public TTReportField RAPORTARIHI;
                public TTReportField KURUM;
                public TTReportField SITENAME;
                public TTReportField SITECITY;
                public TTReportField OBJECTID;
                public TTReportField BIRIMPROTOKOL1;
                public TTReportField BIRIMPROTOKOL;
                public TTReportField ACTIONDATE;
                public TTReportField BIRIMADI;
                public TTReportField ACTIONID;
                public TTReportField NewField11631; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 54;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    HEADER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 3, 201, 23, false);
                    HEADER.Name = "HEADER";
                    HEADER.FieldType = ReportFieldTypeEnum.ftVariable;
                    HEADER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HEADER.MultiLine = EvetHayirEnum.ehEvet;
                    HEADER.NoClip = EvetHayirEnum.ehEvet;
                    HEADER.WordBreak = EvetHayirEnum.ehEvet;
                    HEADER.TextFont.Size = 11;
                    HEADER.TextFont.Bold = true;
                    HEADER.TextFont.CharSet = 162;
                    HEADER.Value = @"{%SITENAME%}
{%SITECITY%}
";

                    RAPORNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 169, 46, 201, 51, false);
                    RAPORNO.Name = "RAPORNO";
                    RAPORNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPORNO.TextFont.CharSet = 162;
                    RAPORNO.Value = @"{#HEADER.REPORTNO#}";

                    RaporTarih11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 46, 54, 51, false);
                    RaporTarih11.Name = "RaporTarih11";
                    RaporTarih11.TextFont.Bold = true;
                    RaporTarih11.TextFont.CharSet = 162;
                    RaporTarih11.Value = @"Rapor tanzim tarihi ve saati";

                    SAG1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 254, 45, 297, 49, false);
                    SAG1.Name = "SAG1";
                    SAG1.Visible = EvetHayirEnum.ehHayir;
                    SAG1.FieldType = ReportFieldTypeEnum.ftVariable;
                    SAG1.TextFont.Name = "Courier New";
                    SAG1.TextFont.CharSet = 162;
                    SAG1.Value = @"SAĞ:9067-{%BIRIMPROTOKOL%}-{%ACTIONDATE%}/{%BIRIMADI%}-{%ACTIONID%}";

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, 53, 201, 53, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;

                    RaporNo11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 46, 169, 51, false);
                    RaporNo11.Name = "RaporNo11";
                    RaporNo11.TextFont.Bold = true;
                    RaporNo11.TextFont.CharSet = 162;
                    RaporNo11.Value = @"Rapor No:";

                    RAPORTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 55, 46, 115, 51, false);
                    RAPORTARIHI.Name = "RAPORTARIHI";
                    RAPORTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPORTARIHI.TextFormat = @"dd/MM/yyyy";
                    RAPORTARIHI.TextFont.CharSet = 162;
                    RAPORTARIHI.Value = @"{#HEADER.ACTIONDATE#}";

                    KURUM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 23, 154, 31, false);
                    KURUM.Name = "KURUM";
                    KURUM.FieldType = ReportFieldTypeEnum.ftVariable;
                    KURUM.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    KURUM.NoClip = EvetHayirEnum.ehEvet;
                    KURUM.ObjectDefName = "PemissionDepartmentEnum";
                    KURUM.DataMember = "DISPLAYTEXT";
                    KURUM.TextFont.Size = 14;
                    KURUM.TextFont.Bold = true;
                    KURUM.TextFont.CharSet = 162;
                    KURUM.Value = @"{#HEADER.KURM#}";

                    SITENAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 20, 245, 25, false);
                    SITENAME.Name = "SITENAME";
                    SITENAME.Visible = EvetHayirEnum.ehHayir;
                    SITENAME.FieldType = ReportFieldTypeEnum.ftExpression;
                    SITENAME.TextFont.Name = "Courier New";
                    SITENAME.TextFont.CharSet = 162;
                    SITENAME.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """")";

                    SITECITY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 26, 245, 31, false);
                    SITECITY.Name = "SITECITY";
                    SITECITY.Visible = EvetHayirEnum.ehHayir;
                    SITECITY.FieldType = ReportFieldTypeEnum.ftExpression;
                    SITECITY.TextFont.Name = "Courier New";
                    SITECITY.TextFont.CharSet = 162;
                    SITECITY.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    OBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 221, 41, 246, 46, false);
                    OBJECTID.Name = "OBJECTID";
                    OBJECTID.Visible = EvetHayirEnum.ehHayir;
                    OBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBJECTID.Value = @"{#HEADER.OBJECTID#}";

                    BIRIMPROTOKOL1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 246, 33, 271, 38, false);
                    BIRIMPROTOKOL1.Name = "BIRIMPROTOKOL1";
                    BIRIMPROTOKOL1.Visible = EvetHayirEnum.ehHayir;
                    BIRIMPROTOKOL1.FieldType = ReportFieldTypeEnum.ftVariable;
                    BIRIMPROTOKOL1.TextFont.Name = "Courier New";
                    BIRIMPROTOKOL1.TextFont.CharSet = 162;
                    BIRIMPROTOKOL1.Value = @"{#HEADER.PROTOCOLNO#}";

                    BIRIMPROTOKOL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 247, 19, 272, 24, false);
                    BIRIMPROTOKOL.Name = "BIRIMPROTOKOL";
                    BIRIMPROTOKOL.Visible = EvetHayirEnum.ehHayir;
                    BIRIMPROTOKOL.FieldType = ReportFieldTypeEnum.ftVariable;
                    BIRIMPROTOKOL.TextFont.Name = "Courier New";
                    BIRIMPROTOKOL.TextFont.CharSet = 162;
                    BIRIMPROTOKOL.Value = @"{#HEADER.PROTOCOLNO#}";

                    ACTIONDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 219, 35, 244, 40, false);
                    ACTIONDATE.Name = "ACTIONDATE";
                    ACTIONDATE.Visible = EvetHayirEnum.ehHayir;
                    ACTIONDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACTIONDATE.TextFont.Name = "Courier New";
                    ACTIONDATE.TextFont.CharSet = 162;
                    ACTIONDATE.Value = @"{#HEADER.ACTIONDATE#}";

                    BIRIMADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 48, 245, 53, false);
                    BIRIMADI.Name = "BIRIMADI";
                    BIRIMADI.Visible = EvetHayirEnum.ehHayir;
                    BIRIMADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    BIRIMADI.TextFont.Name = "Courier New";
                    BIRIMADI.TextFont.CharSet = 162;
                    BIRIMADI.Value = @"{#HEADER.BIRIMADI#}";

                    ACTIONID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 247, 26, 272, 31, false);
                    ACTIONID.Name = "ACTIONID";
                    ACTIONID.Visible = EvetHayirEnum.ehHayir;
                    ACTIONID.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACTIONID.TextFont.Name = "Courier New";
                    ACTIONID.TextFont.CharSet = 162;
                    ACTIONID.Value = @"{#HEADER.ACTIONID#}";

                    NewField11631 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 46, 55, 51, false);
                    NewField11631.Name = "NewField11631";
                    NewField11631.TextFont.Bold = true;
                    NewField11631.TextFont.CharSet = 162;
                    NewField11631.Value = @":";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ForensicMedicalReport.GetForensicMedicalReport_Class dataset_GetForensicMedicalReport = MyParentReport.HEADER.rsGroup.GetCurrentRecord<ForensicMedicalReport.GetForensicMedicalReport_Class>(0);
                    SITENAME.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "");
                    SITECITY.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    HEADER.CalcValue = MyParentReport.PARTA.SITENAME.CalcValue + @"
" + MyParentReport.PARTA.SITECITY.CalcValue + @"
";
                    RAPORNO.CalcValue = (dataset_GetForensicMedicalReport != null ? Globals.ToStringCore(dataset_GetForensicMedicalReport.ReportNo) : "");
                    RaporTarih11.CalcValue = RaporTarih11.Value;
                    BIRIMPROTOKOL.CalcValue = (dataset_GetForensicMedicalReport != null ? Globals.ToStringCore(dataset_GetForensicMedicalReport.ProtocolNo) : "");
                    ACTIONDATE.CalcValue = (dataset_GetForensicMedicalReport != null ? Globals.ToStringCore(dataset_GetForensicMedicalReport.ActionDate) : "");
                    BIRIMADI.CalcValue = (dataset_GetForensicMedicalReport != null ? Globals.ToStringCore(dataset_GetForensicMedicalReport.Birimadi) : "");
                    ACTIONID.CalcValue = (dataset_GetForensicMedicalReport != null ? Globals.ToStringCore(dataset_GetForensicMedicalReport.Actionid) : "");
                    SAG1.CalcValue = @"SAĞ:9067-" + MyParentReport.PARTA.BIRIMPROTOKOL.CalcValue + @"-" + MyParentReport.PARTA.ACTIONDATE.CalcValue + @"/" + MyParentReport.PARTA.BIRIMADI.CalcValue + @"-" + MyParentReport.PARTA.ACTIONID.CalcValue;
                    RaporNo11.CalcValue = RaporNo11.Value;
                    RAPORTARIHI.CalcValue = (dataset_GetForensicMedicalReport != null ? Globals.ToStringCore(dataset_GetForensicMedicalReport.ActionDate) : "");
                    KURUM.CalcValue = (dataset_GetForensicMedicalReport != null ? Globals.ToStringCore(dataset_GetForensicMedicalReport.Kurm) : "");
                    KURUM.PostFieldValueCalculation();
                    OBJECTID.CalcValue = (dataset_GetForensicMedicalReport != null ? Globals.ToStringCore(dataset_GetForensicMedicalReport.ObjectID) : "");
                    BIRIMPROTOKOL1.CalcValue = (dataset_GetForensicMedicalReport != null ? Globals.ToStringCore(dataset_GetForensicMedicalReport.ProtocolNo) : "");
                    NewField11631.CalcValue = NewField11631.Value;
                    return new TTReportObject[] { SITENAME,SITECITY,HEADER,RAPORNO,RaporTarih11,BIRIMPROTOKOL,ACTIONDATE,BIRIMADI,ACTIONID,SAG1,RaporNo11,RAPORTARIHI,KURUM,OBJECTID,BIRIMPROTOKOL1,NewField11631};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public TemporaryForensicReport MyParentReport
                {
                    get { return (TemporaryForensicReport)ParentReport; }
                }
                
                public TTReportField NewField1181;
                public TTReportField NewField1161;
                public TTReportField sayfaNo1;
                public TTReportField NewField1191;
                public TTReportShape NewLine11111; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 11;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField1181 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 180, 3, 198, 7, false);
                    NewField1181.Name = "NewField1181";
                    NewField1181.TextFont.CharSet = 162;
                    NewField1181.Value = @"Sayfa -";

                    NewField1161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 3, 154, 9, false);
                    NewField1161.Name = "NewField1161";
                    NewField1161.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField1161.TextFont.CharSet = 162;
                    NewField1161.Value = @"Bu Rapor, EK FORMLAR DAHİL toplam {@pagecount@} sayfa olup, her bir sayfa üç surettir";

                    sayfaNo1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 196, 3, 203, 7, false);
                    sayfaNo1.Name = "sayfaNo1";
                    sayfaNo1.FieldType = ReportFieldTypeEnum.ftVariable;
                    sayfaNo1.TextFont.Name = "Courier New";
                    sayfaNo1.TextFont.CharSet = 162;
                    sayfaNo1.Value = @"{@pagenumber@}";

                    NewField1191 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 157, 3, 179, 8, false);
                    NewField1191.Name = "NewField1191";
                    NewField1191.TextFont.CharSet = 162;
                    NewField1191.Value = @"İmza";

                    NewLine11111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 1, 0, 174, 0, false);
                    NewLine11111.Name = "NewLine11111";
                    NewLine11111.ForeColor = System.Drawing.Color.White;
                    NewLine11111.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1181.CalcValue = NewField1181.Value;
                    NewField1161.CalcValue = @"Bu Rapor, EK FORMLAR DAHİL toplam " + ParentReport.ReportTotalPageCount + @" sayfa olup, her bir sayfa üç surettir";
                    sayfaNo1.CalcValue = ParentReport.CurrentPageNumber.ToString();
                    NewField1191.CalcValue = NewField1191.Value;
                    return new TTReportObject[] { NewField1181,NewField1161,sayfaNo1,NewField1191};
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class PARTBGroup : TTReportGroup
        {
            public TemporaryForensicReport MyParentReport
            {
                get { return (TemporaryForensicReport)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField NewField1641 { get {return Header().NewField1641;} }
            public TTReportField NewField1191 { get {return Header().NewField1191;} }
            public TTReportField RAPORTARIHNO { get {return Header().RAPORTARIHNO;} }
            public TTReportField NewField1211 { get {return Header().NewField1211;} }
            public TTReportField NewField1351 { get {return Header().NewField1351;} }
            public TTReportField NewField1361 { get {return Header().NewField1361;} }
            public TTReportField MAKAM { get {return Header().MAKAM;} }
            public TTReportField NewField1471 { get {return Header().NewField1471;} }
            public TTReportShape NewLine141 { get {return Header().NewLine141;} }
            public TTReportField NewField1571 { get {return Header().NewField1571;} }
            public TTReportField NewField1581 { get {return Header().NewField1581;} }
            public TTReportField NewField1591 { get {return Header().NewField1591;} }
            public TTReportField NewField1601 { get {return Header().NewField1601;} }
            public TTReportField NewField1611 { get {return Header().NewField1611;} }
            public TTReportShape NewLine161 { get {return Header().NewLine161;} }
            public TTReportField MuayeneNedeni { get {return Header().MuayeneNedeni;} }
            public TTReportField NewField1651 { get {return Header().NewField1651;} }
            public TTReportField TIBBIKIMLIK { get {return Header().TIBBIKIMLIK;} }
            public TTReportField NewField1671 { get {return Header().NewField1671;} }
            public TTReportField Aciklamalar { get {return Header().Aciklamalar;} }
            public TTReportField ResUser { get {return Header().ResUser;} }
            public TTReportField ResUserSicil { get {return Header().ResUserSicil;} }
            public TTReportField NewField1192 { get {return Header().NewField1192;} }
            public TTReportField BABAAD { get {return Header().BABAAD;} }
            public TTReportField NewField11211 { get {return Header().NewField11211;} }
            public TTReportField NewField11411 { get {return Header().NewField11411;} }
            public TTReportField NewField11511 { get {return Header().NewField11511;} }
            public TTReportField NewField11711 { get {return Header().NewField11711;} }
            public TTReportField NewField11811 { get {return Header().NewField11811;} }
            public TTReportField NewField11941 { get {return Header().NewField11941;} }
            public TTReportShape NewLine1151 { get {return Header().NewLine1151;} }
            public TTReportField NewField11151 { get {return Header().NewField11151;} }
            public TTReportField NewField11251 { get {return Header().NewField11251;} }
            public TTReportField CINSIYET { get {return Header().CINSIYET;} }
            public TTReportField NewField11451 { get {return Header().NewField11451;} }
            public TTReportField NewField11551 { get {return Header().NewField11551;} }
            public TTReportField MESLEK { get {return Header().MESLEK;} }
            public TTReportField NewField11861 { get {return Header().NewField11861;} }
            public TTReportField NewField11961 { get {return Header().NewField11961;} }
            public TTReportField KIMLIKNO { get {return Header().KIMLIKNO;} }
            public TTReportField UNIQUEREFNO { get {return Header().UNIQUEREFNO;} }
            public TTReportField FOREIGNUNIQUEREFNO { get {return Header().FOREIGNUNIQUEREFNO;} }
            public TTReportField PNAME { get {return Header().PNAME;} }
            public TTReportField SURNAME { get {return Header().SURNAME;} }
            public TTReportField DTARIH { get {return Header().DTARIH;} }
            public TTReportField ADSOYAD { get {return Header().ADSOYAD;} }
            public TTReportField DOKUMANENTDATE { get {return Header().DOKUMANENTDATE;} }
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
                public TemporaryForensicReport MyParentReport
                {
                    get { return (TemporaryForensicReport)ParentReport; }
                }
                
                public TTReportField NewField1641;
                public TTReportField NewField1191;
                public TTReportField RAPORTARIHNO;
                public TTReportField NewField1211;
                public TTReportField NewField1351;
                public TTReportField NewField1361;
                public TTReportField MAKAM;
                public TTReportField NewField1471;
                public TTReportShape NewLine141;
                public TTReportField NewField1571;
                public TTReportField NewField1581;
                public TTReportField NewField1591;
                public TTReportField NewField1601;
                public TTReportField NewField1611;
                public TTReportShape NewLine161;
                public TTReportField MuayeneNedeni;
                public TTReportField NewField1651;
                public TTReportField TIBBIKIMLIK;
                public TTReportField NewField1671;
                public TTReportField Aciklamalar;
                public TTReportField ResUser;
                public TTReportField ResUserSicil;
                public TTReportField NewField1192;
                public TTReportField BABAAD;
                public TTReportField NewField11211;
                public TTReportField NewField11411;
                public TTReportField NewField11511;
                public TTReportField NewField11711;
                public TTReportField NewField11811;
                public TTReportField NewField11941;
                public TTReportShape NewLine1151;
                public TTReportField NewField11151;
                public TTReportField NewField11251;
                public TTReportField CINSIYET;
                public TTReportField NewField11451;
                public TTReportField NewField11551;
                public TTReportField MESLEK;
                public TTReportField NewField11861;
                public TTReportField NewField11961;
                public TTReportField KIMLIKNO;
                public TTReportField UNIQUEREFNO;
                public TTReportField FOREIGNUNIQUEREFNO;
                public TTReportField PNAME;
                public TTReportField SURNAME;
                public TTReportField DTARIH;
                public TTReportField ADSOYAD;
                public TTReportField DOKUMANENTDATE; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 67;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1641 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 53, 81, 57, false);
                    NewField1641.Name = "NewField1641";
                    NewField1641.TextFont.Bold = true;
                    NewField1641.TextFont.CharSet = 162;
                    NewField1641.Value = @"MUAYENEYE EDİLENİN TIBBİ KİMLİĞİ";

                    NewField1191 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 18, 54, 22, false);
                    NewField1191.Name = "NewField1191";
                    NewField1191.TextFont.Bold = true;
                    NewField1191.TextFont.CharSet = 162;
                    NewField1191.Value = @"Resmi Yazı Tarihi,Protokol Nu.";

                    RAPORTARIHNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 55, 18, 115, 22, false);
                    RAPORTARIHNO.Name = "RAPORTARIHNO";
                    RAPORTARIHNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPORTARIHNO.TextFormat = @"dd mmmm yyyy";
                    RAPORTARIHNO.TextFont.CharSet = 162;
                    RAPORTARIHNO.Value = @"{%DOKUMANENTDATE%} - {#HEADER.PROTOCOLNO#}";

                    NewField1211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 18, 55, 22, false);
                    NewField1211.Name = "NewField1211";
                    NewField1211.TextFont.CharSet = 162;
                    NewField1211.Value = @":";

                    NewField1351 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 1, 54, 5, false);
                    NewField1351.Name = "NewField1351";
                    NewField1351.TextFont.Bold = true;
                    NewField1351.TextFont.CharSet = 162;
                    NewField1351.Value = @"Gönderen Makam";

                    NewField1361 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 1, 55, 5, false);
                    NewField1361.Name = "NewField1361";
                    NewField1361.TextFont.Bold = true;
                    NewField1361.TextFont.CharSet = 162;
                    NewField1361.Value = @":";

                    MAKAM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 7, 115, 16, false);
                    MAKAM.Name = "MAKAM";
                    MAKAM.FieldType = ReportFieldTypeEnum.ftVariable;
                    MAKAM.MultiLine = EvetHayirEnum.ehEvet;
                    MAKAM.WordBreak = EvetHayirEnum.ehEvet;
                    MAKAM.TextFont.CharSet = 162;
                    MAKAM.Value = @"{#HEADER.MAKAM#}";

                    NewField1471 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 23, 115, 27, false);
                    NewField1471.Name = "NewField1471";
                    NewField1471.TextFont.Bold = true;
                    NewField1471.TextFont.CharSet = 162;
                    NewField1471.Value = @"EŞLİK EDEN RESMİ GÖREVLİNİN";

                    NewLine141 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, 28, 115, 28, false);
                    NewLine141.Name = "NewLine141";
                    NewLine141.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField1571 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 29, 54, 33, false);
                    NewField1571.Name = "NewField1571";
                    NewField1571.TextFont.Bold = true;
                    NewField1571.TextFont.CharSet = 162;
                    NewField1571.Value = @"Adı Soyadı";

                    NewField1581 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 29, 55, 33, false);
                    NewField1581.Name = "NewField1581";
                    NewField1581.TextFont.Bold = true;
                    NewField1581.TextFont.CharSet = 162;
                    NewField1581.Value = @":";

                    NewField1591 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 33, 54, 37, false);
                    NewField1591.Name = "NewField1591";
                    NewField1591.TextFont.Bold = true;
                    NewField1591.TextFont.CharSet = 162;
                    NewField1591.Value = @"Sicil No";

                    NewField1601 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 33, 55, 37, false);
                    NewField1601.Name = "NewField1601";
                    NewField1601.TextFont.Bold = true;
                    NewField1601.TextFont.CharSet = 162;
                    NewField1601.Value = @":";

                    NewField1611 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 38, 115, 42, false);
                    NewField1611.Name = "NewField1611";
                    NewField1611.TextFont.Bold = true;
                    NewField1611.TextFont.CharSet = 162;
                    NewField1611.Value = @"MUAYENEYE GÖNDERİLME NEDENİ";

                    NewLine161 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, 43, 115, 43, false);
                    NewLine161.Name = "NewLine161";
                    NewLine161.DrawStyle = DrawStyleConstants.vbSolid;

                    MuayeneNedeni = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 44, 58, 52, false);
                    MuayeneNedeni.Name = "MuayeneNedeni";
                    MuayeneNedeni.FieldType = ReportFieldTypeEnum.ftVariable;
                    MuayeneNedeni.ObjectDefName = "ReasonExaminationTypeEnum";
                    MuayeneNedeni.DataMember = "DISPLAYTEXT";
                    MuayeneNedeni.TextFont.CharSet = 162;
                    MuayeneNedeni.Value = @"{#HEADER.MUAYENENEDENI#}";

                    NewField1651 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 53, 83, 57, false);
                    NewField1651.Name = "NewField1651";
                    NewField1651.TextFont.Name = "Courier New";
                    NewField1651.TextFont.Bold = true;
                    NewField1651.TextFont.CharSet = 162;
                    NewField1651.Value = @":";

                    TIBBIKIMLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 83, 52, 201, 65, false);
                    TIBBIKIMLIK.Name = "TIBBIKIMLIK";
                    TIBBIKIMLIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    TIBBIKIMLIK.MultiLine = EvetHayirEnum.ehEvet;
                    TIBBIKIMLIK.WordBreak = EvetHayirEnum.ehEvet;
                    TIBBIKIMLIK.TextFont.CharSet = 162;
                    TIBBIKIMLIK.Value = @"{#HEADER.TIBBIKIMLIK#}";

                    NewField1671 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 57, 81, 66, false);
                    NewField1671.Name = "NewField1671";
                    NewField1671.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1671.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1671.TextFont.Size = 9;
                    NewField1671.TextFont.CharSet = 162;
                    NewField1671.Value = @"Geçerli kimlik belgesi olmayanlar için doldurulacaktır";

                    Aciklamalar = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 44, 115, 52, false);
                    Aciklamalar.Name = "Aciklamalar";
                    Aciklamalar.FieldType = ReportFieldTypeEnum.ftVariable;
                    Aciklamalar.MultiLine = EvetHayirEnum.ehEvet;
                    Aciklamalar.WordBreak = EvetHayirEnum.ehEvet;
                    Aciklamalar.TextFont.CharSet = 162;
                    Aciklamalar.Value = @"{#HEADER.ACIKLAMA1#}";

                    ResUser = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 55, 29, 115, 33, false);
                    ResUser.Name = "ResUser";
                    ResUser.FieldType = ReportFieldTypeEnum.ftVariable;
                    ResUser.TextFont.CharSet = 162;
                    ResUser.Value = @"{#HEADER.NAME#}";

                    ResUserSicil = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 55, 33, 115, 37, false);
                    ResUserSicil.Name = "ResUserSicil";
                    ResUserSicil.FieldType = ReportFieldTypeEnum.ftVariable;
                    ResUserSicil.TextFont.CharSet = 162;
                    ResUserSicil.Value = @"{#HEADER.SICILNO#}";

                    NewField1192 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 120, 25, 165, 29, false);
                    NewField1192.Name = "NewField1192";
                    NewField1192.TextFont.Bold = true;
                    NewField1192.TextFont.CharSet = 162;
                    NewField1192.Value = @"Doğum Yeri ve Tarihi";

                    BABAAD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 20, 201, 24, false);
                    BABAAD.Name = "BABAAD";
                    BABAAD.FieldType = ReportFieldTypeEnum.ftVariable;
                    BABAAD.ObjectDefName = "Patient";
                    BABAAD.DataMember = "FATHERNAME";
                    BABAAD.TextFont.CharSet = 162;
                    BABAAD.Value = @"{#HEADER.PATIENTID#}";

                    NewField11211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 120, 15, 149, 19, false);
                    NewField11211.Name = "NewField11211";
                    NewField11211.TextFont.Bold = true;
                    NewField11211.TextFont.CharSet = 162;
                    NewField11211.Value = @"Adı Soyadı";

                    NewField11411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 149, 15, 151, 19, false);
                    NewField11411.Name = "NewField11411";
                    NewField11411.TextFont.Bold = true;
                    NewField11411.TextFont.CharSet = 162;
                    NewField11411.Value = @":";

                    NewField11511 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 120, 20, 149, 24, false);
                    NewField11511.Name = "NewField11511";
                    NewField11511.TextFont.Bold = true;
                    NewField11511.TextFont.CharSet = 162;
                    NewField11511.Value = @"Baba Adı";

                    NewField11711 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 149, 25, 151, 29, false);
                    NewField11711.Name = "NewField11711";
                    NewField11711.TextFont.Bold = true;
                    NewField11711.TextFont.CharSet = 162;
                    NewField11711.Value = @":";

                    NewField11811 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 149, 20, 151, 24, false);
                    NewField11811.Name = "NewField11811";
                    NewField11811.TextFont.Bold = true;
                    NewField11811.TextFont.CharSet = 162;
                    NewField11811.Value = @":";

                    NewField11941 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 120, 3, 201, 7, false);
                    NewField11941.Name = "NewField11941";
                    NewField11941.TextFont.Bold = true;
                    NewField11941.TextFont.CharSet = 162;
                    NewField11941.Value = @"MUAYENE EDİLENİN";

                    NewLine1151 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 120, 8, 201, 8, false);
                    NewLine1151.Name = "NewLine1151";
                    NewLine1151.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField11151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 120, 39, 149, 43, false);
                    NewField11151.Name = "NewField11151";
                    NewField11151.TextFont.Bold = true;
                    NewField11151.TextFont.CharSet = 162;
                    NewField11151.Value = @"Cinsiyeti";

                    NewField11251 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 149, 39, 151, 43, false);
                    NewField11251.Name = "NewField11251";
                    NewField11251.TextFont.Bold = true;
                    NewField11251.TextFont.CharSet = 162;
                    NewField11251.Value = @":";

                    CINSIYET = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 39, 201, 43, false);
                    CINSIYET.Name = "CINSIYET";
                    CINSIYET.FieldType = ReportFieldTypeEnum.ftVariable;
                    CINSIYET.ObjectDefName = "SexEnum";
                    CINSIYET.DataMember = "DISPLAYTEXT";
                    CINSIYET.TextFont.CharSet = 162;
                    CINSIYET.Value = @"{#HEADER.CINSIYET#}";

                    NewField11451 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 120, 44, 149, 48, false);
                    NewField11451.Name = "NewField11451";
                    NewField11451.TextFont.Bold = true;
                    NewField11451.TextFont.CharSet = 162;
                    NewField11451.Value = @"Mesleği";

                    NewField11551 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 149, 44, 151, 48, false);
                    NewField11551.Name = "NewField11551";
                    NewField11551.TextFont.CharSet = 162;
                    NewField11551.Value = @":";

                    MESLEK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 44, 201, 48, false);
                    MESLEK.Name = "MESLEK";
                    MESLEK.FieldType = ReportFieldTypeEnum.ftVariable;
                    MESLEK.TextFont.CharSet = 162;
                    MESLEK.Value = @"{%MESLEK%}";

                    NewField11861 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 120, 10, 149, 14, false);
                    NewField11861.Name = "NewField11861";
                    NewField11861.TextFont.Bold = true;
                    NewField11861.TextFont.CharSet = 162;
                    NewField11861.Value = @"Kimlik No";

                    NewField11961 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 149, 10, 151, 14, false);
                    NewField11961.Name = "NewField11961";
                    NewField11961.TextFont.Bold = true;
                    NewField11961.TextFont.CharSet = 162;
                    NewField11961.Value = @":";

                    KIMLIKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 10, 201, 14, false);
                    KIMLIKNO.Name = "KIMLIKNO";
                    KIMLIKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    KIMLIKNO.TextFont.CharSet = 162;
                    KIMLIKNO.Value = @"";

                    UNIQUEREFNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 238, 31, 263, 36, false);
                    UNIQUEREFNO.Name = "UNIQUEREFNO";
                    UNIQUEREFNO.Visible = EvetHayirEnum.ehHayir;
                    UNIQUEREFNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNIQUEREFNO.ObjectDefName = "Patient";
                    UNIQUEREFNO.DataMember = "UNIQUEREFNO";
                    UNIQUEREFNO.TextFont.Name = "Courier New";
                    UNIQUEREFNO.TextFont.CharSet = 162;
                    UNIQUEREFNO.Value = @"{#HEADER.PATIENTID#}";

                    FOREIGNUNIQUEREFNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 237, 26, 262, 31, false);
                    FOREIGNUNIQUEREFNO.Name = "FOREIGNUNIQUEREFNO";
                    FOREIGNUNIQUEREFNO.Visible = EvetHayirEnum.ehHayir;
                    FOREIGNUNIQUEREFNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    FOREIGNUNIQUEREFNO.ObjectDefName = "Patient";
                    FOREIGNUNIQUEREFNO.DataMember = "FOREIGNUNIQUEREFNO";
                    FOREIGNUNIQUEREFNO.TextFont.Name = "Courier New";
                    FOREIGNUNIQUEREFNO.TextFont.CharSet = 162;
                    FOREIGNUNIQUEREFNO.Value = @"{#HEADER.PATIENTID#}";

                    PNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 238, 8, 263, 13, false);
                    PNAME.Name = "PNAME";
                    PNAME.Visible = EvetHayirEnum.ehHayir;
                    PNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    PNAME.ObjectDefName = "Patient";
                    PNAME.DataMember = "NAME";
                    PNAME.TextFont.Name = "Courier New";
                    PNAME.TextFont.CharSet = 162;
                    PNAME.Value = @"{#HEADER.PATIENTID#}";

                    SURNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 237, 12, 262, 17, false);
                    SURNAME.Name = "SURNAME";
                    SURNAME.Visible = EvetHayirEnum.ehHayir;
                    SURNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    SURNAME.ObjectDefName = "Patient";
                    SURNAME.DataMember = "SURNAME";
                    SURNAME.TextFont.Name = "Courier New";
                    SURNAME.TextFont.CharSet = 162;
                    SURNAME.Value = @"{#HEADER.PATIENTID#}";

                    DTARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 237, 50, 262, 55, false);
                    DTARIH.Name = "DTARIH";
                    DTARIH.Visible = EvetHayirEnum.ehHayir;
                    DTARIH.FieldType = ReportFieldTypeEnum.ftVariable;
                    DTARIH.TextFormat = @"dd/MM/yyyy";
                    DTARIH.ObjectDefName = "Patient";
                    DTARIH.DataMember = "BIRTHDATE";
                    DTARIH.TextFont.Name = "Courier New";
                    DTARIH.TextFont.CharSet = 162;
                    DTARIH.Value = @"{#HEADER.PATIENTID#}";

                    ADSOYAD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 15, 201, 19, false);
                    ADSOYAD.Name = "ADSOYAD";
                    ADSOYAD.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADSOYAD.TextFont.CharSet = 162;
                    ADSOYAD.Value = @"{%PNAME%} {%SURNAME%}";

                    DOKUMANENTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 284, 8, 309, 13, false);
                    DOKUMANENTDATE.Name = "DOKUMANENTDATE";
                    DOKUMANENTDATE.Visible = EvetHayirEnum.ehHayir;
                    DOKUMANENTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOKUMANENTDATE.TextFormat = @"dd/MM/yyyy";
                    DOKUMANENTDATE.Value = @"{#HEADER.DOCUMENTDATE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ForensicMedicalReport.GetForensicMedicalReport_Class dataset_GetForensicMedicalReport = MyParentReport.HEADER.rsGroup.GetCurrentRecord<ForensicMedicalReport.GetForensicMedicalReport_Class>(0);
                    NewField1641.CalcValue = NewField1641.Value;
                    NewField1191.CalcValue = NewField1191.Value;
                    DOKUMANENTDATE.CalcValue = (dataset_GetForensicMedicalReport != null ? Globals.ToStringCore(dataset_GetForensicMedicalReport.DocumentDate) : "");
                    RAPORTARIHNO.CalcValue = MyParentReport.PARTB.DOKUMANENTDATE.FormattedValue + @" - " + (dataset_GetForensicMedicalReport != null ? Globals.ToStringCore(dataset_GetForensicMedicalReport.ProtocolNo) : "");
                    NewField1211.CalcValue = NewField1211.Value;
                    NewField1351.CalcValue = NewField1351.Value;
                    NewField1361.CalcValue = NewField1361.Value;
                    MAKAM.CalcValue = (dataset_GetForensicMedicalReport != null ? Globals.ToStringCore(dataset_GetForensicMedicalReport.Makam) : "");
                    NewField1471.CalcValue = NewField1471.Value;
                    NewField1571.CalcValue = NewField1571.Value;
                    NewField1581.CalcValue = NewField1581.Value;
                    NewField1591.CalcValue = NewField1591.Value;
                    NewField1601.CalcValue = NewField1601.Value;
                    NewField1611.CalcValue = NewField1611.Value;
                    MuayeneNedeni.CalcValue = (dataset_GetForensicMedicalReport != null ? Globals.ToStringCore(dataset_GetForensicMedicalReport.Muayenenedeni) : "");
                    MuayeneNedeni.PostFieldValueCalculation();
                    NewField1651.CalcValue = NewField1651.Value;
                    TIBBIKIMLIK.CalcValue = (dataset_GetForensicMedicalReport != null ? Globals.ToStringCore(dataset_GetForensicMedicalReport.Tibbikimlik) : "");
                    NewField1671.CalcValue = NewField1671.Value;
                    Aciklamalar.CalcValue = (dataset_GetForensicMedicalReport != null ? Globals.ToStringCore(dataset_GetForensicMedicalReport.Aciklama1) : "");
                    ResUser.CalcValue = (dataset_GetForensicMedicalReport != null ? Globals.ToStringCore(dataset_GetForensicMedicalReport.Name) : "");
                    ResUserSicil.CalcValue = (dataset_GetForensicMedicalReport != null ? Globals.ToStringCore(dataset_GetForensicMedicalReport.Sicilno) : "");
                    NewField1192.CalcValue = NewField1192.Value;
                    BABAAD.CalcValue = (dataset_GetForensicMedicalReport != null ? Globals.ToStringCore(dataset_GetForensicMedicalReport.Patientid) : "");
                    BABAAD.PostFieldValueCalculation();
                    NewField11211.CalcValue = NewField11211.Value;
                    NewField11411.CalcValue = NewField11411.Value;
                    NewField11511.CalcValue = NewField11511.Value;
                    NewField11711.CalcValue = NewField11711.Value;
                    NewField11811.CalcValue = NewField11811.Value;
                    NewField11941.CalcValue = NewField11941.Value;
                    NewField11151.CalcValue = NewField11151.Value;
                    NewField11251.CalcValue = NewField11251.Value;
                    CINSIYET.CalcValue = (dataset_GetForensicMedicalReport != null ? Globals.ToStringCore(dataset_GetForensicMedicalReport.Cinsiyet) : "");
                    CINSIYET.PostFieldValueCalculation();
                    NewField11451.CalcValue = NewField11451.Value;
                    NewField11551.CalcValue = NewField11551.Value;
                    MESLEK.CalcValue = MyParentReport.PARTB.MESLEK.CalcValue;
                    NewField11861.CalcValue = NewField11861.Value;
                    NewField11961.CalcValue = NewField11961.Value;
                    KIMLIKNO.CalcValue = @"";
                    UNIQUEREFNO.CalcValue = (dataset_GetForensicMedicalReport != null ? Globals.ToStringCore(dataset_GetForensicMedicalReport.Patientid) : "");
                    UNIQUEREFNO.PostFieldValueCalculation();
                    FOREIGNUNIQUEREFNO.CalcValue = (dataset_GetForensicMedicalReport != null ? Globals.ToStringCore(dataset_GetForensicMedicalReport.Patientid) : "");
                    FOREIGNUNIQUEREFNO.PostFieldValueCalculation();
                    PNAME.CalcValue = (dataset_GetForensicMedicalReport != null ? Globals.ToStringCore(dataset_GetForensicMedicalReport.Patientid) : "");
                    PNAME.PostFieldValueCalculation();
                    SURNAME.CalcValue = (dataset_GetForensicMedicalReport != null ? Globals.ToStringCore(dataset_GetForensicMedicalReport.Patientid) : "");
                    SURNAME.PostFieldValueCalculation();
                    DTARIH.CalcValue = (dataset_GetForensicMedicalReport != null ? Globals.ToStringCore(dataset_GetForensicMedicalReport.Patientid) : "");
                    DTARIH.PostFieldValueCalculation();
                    ADSOYAD.CalcValue = MyParentReport.PARTB.PNAME.CalcValue + @" " + MyParentReport.PARTB.SURNAME.CalcValue;
                    return new TTReportObject[] { NewField1641,NewField1191,DOKUMANENTDATE,RAPORTARIHNO,NewField1211,NewField1351,NewField1361,MAKAM,NewField1471,NewField1571,NewField1581,NewField1591,NewField1601,NewField1611,MuayeneNedeni,NewField1651,TIBBIKIMLIK,NewField1671,Aciklamalar,ResUser,ResUserSicil,NewField1192,BABAAD,NewField11211,NewField11411,NewField11511,NewField11711,NewField11811,NewField11941,NewField11151,NewField11251,CINSIYET,NewField11451,NewField11551,MESLEK,NewField11861,NewField11961,KIMLIKNO,UNIQUEREFNO,FOREIGNUNIQUEREFNO,PNAME,SURNAME,DTARIH,ADSOYAD};
                }

                public override void RunScript()
                {
#region PARTB HEADER_Script
                    //              if(this.FOREIGNUNIQUEREFNO.CalcValue != "")
//                this.KIMLIKNO.CalcValue = "(*)" + this.FOREIGNUNIQUEREFNO.CalcValue;
//            else
//                this.KIMLIKNO.CalcValue = this.UNIQUEREFNO.CalcValue;
//
#endregion PARTB HEADER_Script
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public TemporaryForensicReport MyParentReport
                {
                    get { return (TemporaryForensicReport)ParentReport; }
                }
                 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 2;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTBGroup PARTB;

        public partial class HEADER2Group : TTReportGroup
        {
            public TemporaryForensicReport MyParentReport
            {
                get { return (TemporaryForensicReport)ParentReport; }
            }

            new public HEADER2GroupHeader Header()
            {
                return (HEADER2GroupHeader)_header;
            }

            new public HEADER2GroupFooter Footer()
            {
                return (HEADER2GroupFooter)_footer;
            }

            public TTReportField ADISOYADI { get {return Header().ADISOYADI;} }
            public TTReportField NewField11133111 { get {return Header().NewField11133111;} }
            public TTReportField NewField11134111 { get {return Header().NewField11134111;} }
            public TTReportField NewField11145111 { get {return Header().NewField11145111;} }
            public TTReportField NewField11146111 { get {return Header().NewField11146111;} }
            public TTReportField REPORTDATE { get {return Header().REPORTDATE;} }
            public TTReportField REPORTNO { get {return Header().REPORTNO;} }
            public TTReportField NewField11139111 { get {return Header().NewField11139111;} }
            public TTReportField NewField117011 { get {return Header().NewField117011;} }
            public TTReportShape NewLine1121 { get {return Header().NewLine1121;} }
            public TTReportField RAPORTIPI2 { get {return Header().RAPORTIPI2;} }
            public HEADER2Group(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public HEADER2Group(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new HEADER2GroupHeader(this);
                _footer = new HEADER2GroupFooter(this);

            }

            public partial class HEADER2GroupHeader : TTReportSection
            {
                public TemporaryForensicReport MyParentReport
                {
                    get { return (TemporaryForensicReport)ParentReport; }
                }
                
                public TTReportField ADISOYADI;
                public TTReportField NewField11133111;
                public TTReportField NewField11134111;
                public TTReportField NewField11145111;
                public TTReportField NewField11146111;
                public TTReportField REPORTDATE;
                public TTReportField REPORTNO;
                public TTReportField NewField11139111;
                public TTReportField NewField117011;
                public TTReportShape NewLine1121;
                public TTReportField RAPORTIPI2; 
                public HEADER2GroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 35;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    ADISOYADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 25, 117, 29, false);
                    ADISOYADI.Name = "ADISOYADI";
                    ADISOYADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADISOYADI.TextFont.CharSet = 162;
                    ADISOYADI.Value = @"{%PARTB.PNAME%} {%PARTB.SURNAME%}";

                    NewField11133111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 25, 56, 29, false);
                    NewField11133111.Name = "NewField11133111";
                    NewField11133111.TextFont.Bold = true;
                    NewField11133111.TextFont.CharSet = 162;
                    NewField11133111.Value = @"Muayene Edilenin Adı Soyadı";

                    NewField11134111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 56, 25, 58, 29, false);
                    NewField11134111.Name = "NewField11134111";
                    NewField11134111.TextFont.Bold = true;
                    NewField11134111.TextFont.CharSet = 162;
                    NewField11134111.Value = @":";

                    NewField11145111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 138, 25, 165, 29, false);
                    NewField11145111.Name = "NewField11145111";
                    NewField11145111.TextFont.Bold = true;
                    NewField11145111.TextFont.CharSet = 162;
                    NewField11145111.Value = @"Rapor Tarihi ve No";

                    NewField11146111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 165, 25, 167, 29, false);
                    NewField11146111.Name = "NewField11146111";
                    NewField11146111.TextFont.Bold = true;
                    NewField11146111.TextFont.CharSet = 162;
                    NewField11146111.Value = @":";

                    REPORTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 167, 25, 185, 29, false);
                    REPORTDATE.Name = "REPORTDATE";
                    REPORTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    REPORTDATE.TextFormat = @"dd/MM/yyyy";
                    REPORTDATE.TextFont.CharSet = 162;
                    REPORTDATE.Value = @"{#HEADER.ACTIONDATE#}";

                    REPORTNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 189, 25, 201, 29, false);
                    REPORTNO.Name = "REPORTNO";
                    REPORTNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    REPORTNO.TextFont.CharSet = 162;
                    REPORTNO.Value = @"{#HEADER.REPORTNO#}";

                    NewField11139111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 186, 25, 188, 29, false);
                    NewField11139111.Name = "NewField11139111";
                    NewField11139111.TextFont.Bold = true;
                    NewField11139111.TextFont.CharSet = 162;
                    NewField11139111.Value = @"-";

                    NewField117011 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 237, 5, 347, 18, false);
                    NewField117011.Name = "NewField117011";
                    NewField117011.Visible = EvetHayirEnum.ehHayir;
                    NewField117011.TextColor = System.Drawing.Color.FromArgb(255,15,15,15);
                    NewField117011.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField117011.TextFont.Size = 14;
                    NewField117011.TextFont.Bold = true;
                    NewField117011.TextFont.CharSet = 162;
                    NewField117011.Value = @"ADLİ MUAYENE RAPORU";

                    NewLine1121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, 33, 201, 33, false);
                    NewLine1121.Name = "NewLine1121";
                    NewLine1121.ForeColor = System.Drawing.Color.White;
                    NewLine1121.DrawStyle = DrawStyleConstants.vbSolid;

                    RAPORTIPI2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 7, 138, 20, false);
                    RAPORTIPI2.Name = "RAPORTIPI2";
                    RAPORTIPI2.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPORTIPI2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    RAPORTIPI2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    RAPORTIPI2.TextFont.Size = 14;
                    RAPORTIPI2.TextFont.Bold = true;
                    RAPORTIPI2.TextFont.CharSet = 162;
                    RAPORTIPI2.Value = @"{%HEADER.RAPORTIPI1%}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ForensicMedicalReport.GetForensicMedicalReport_Class dataset_GetForensicMedicalReport = MyParentReport.HEADER.rsGroup.GetCurrentRecord<ForensicMedicalReport.GetForensicMedicalReport_Class>(0);
                    ADISOYADI.CalcValue = MyParentReport.PARTB.PNAME.CalcValue + @" " + MyParentReport.PARTB.SURNAME.CalcValue;
                    NewField11133111.CalcValue = NewField11133111.Value;
                    NewField11134111.CalcValue = NewField11134111.Value;
                    NewField11145111.CalcValue = NewField11145111.Value;
                    NewField11146111.CalcValue = NewField11146111.Value;
                    REPORTDATE.CalcValue = (dataset_GetForensicMedicalReport != null ? Globals.ToStringCore(dataset_GetForensicMedicalReport.ActionDate) : "");
                    REPORTNO.CalcValue = (dataset_GetForensicMedicalReport != null ? Globals.ToStringCore(dataset_GetForensicMedicalReport.ReportNo) : "");
                    NewField11139111.CalcValue = NewField11139111.Value;
                    NewField117011.CalcValue = NewField117011.Value;
                    RAPORTIPI2.CalcValue = MyParentReport.HEADER.RAPORTIPI1.CalcValue;
                    return new TTReportObject[] { ADISOYADI,NewField11133111,NewField11134111,NewField11145111,NewField11146111,REPORTDATE,REPORTNO,NewField11139111,NewField117011,RAPORTIPI2};
                }
                public override void RunPreScript()
                {
#region HEADER2 HEADER_PreScript
                    if (this.MyParentReport.CurrentPageNumber == 1)
                this.MyParentReport.HEADER2.Header().Visible =EvetHayirEnum.ehHayir;
            else
                this.MyParentReport.HEADER2.Header().Visible =EvetHayirEnum.ehEvet;
#endregion HEADER2 HEADER_PreScript
                }
            }
            public partial class HEADER2GroupFooter : TTReportSection
            {
                public TemporaryForensicReport MyParentReport
                {
                    get { return (TemporaryForensicReport)ParentReport; }
                }
                 
                public HEADER2GroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 2;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public HEADER2Group HEADER2;

        public partial class PARTCGroup : TTReportGroup
        {
            public TemporaryForensicReport MyParentReport
            {
                get { return (TemporaryForensicReport)ParentReport; }
            }

            new public PARTCGroupHeader Header()
            {
                return (PARTCGroupHeader)_header;
            }

            new public PARTCGroupFooter Footer()
            {
                return (PARTCGroupFooter)_footer;
            }

            public TTReportShape NewLine121 { get {return Header().NewLine121;} }
            public TTReportField NewField1761 { get {return Header().NewField1761;} }
            public TTReportField NewField1771 { get {return Header().NewField1771;} }
            public TTReportField REPORTIMAGE1 { get {return Footer().REPORTIMAGE1;} }
            public TTReportField NewField1114411 { get {return Footer().NewField1114411;} }
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
                public TemporaryForensicReport MyParentReport
                {
                    get { return (TemporaryForensicReport)ParentReport; }
                }
                
                public TTReportShape NewLine121;
                public TTReportField NewField1761;
                public TTReportField NewField1771; 
                public PARTCGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 9;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewLine121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, 1, 200, 1, false);
                    NewLine121.Name = "NewLine121";
                    NewLine121.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField1761 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 2, 61, 9, false);
                    NewField1761.Name = "NewField1761";
                    NewField1761.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1761.TextFont.Size = 11;
                    NewField1761.TextFont.Bold = true;
                    NewField1761.TextFont.CharSet = 162;
                    NewField1761.Value = @"MUAYENE KOŞULLARI";

                    NewField1771 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 63, 3, 201, 9, false);
                    NewField1771.Name = "NewField1771";
                    NewField1771.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1771.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1771.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1771.TextFont.Size = 9;
                    NewField1771.TextFont.CharSet = 162;
                    NewField1771.Value = @"Bu bölümü, gözaltı işlemi ve insan hakları ihlali iddiası nedeniyle muayeneye getirilen kişiler için mutlaka doldurunuz.";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1761.CalcValue = NewField1761.Value;
                    NewField1771.CalcValue = NewField1771.Value;
                    return new TTReportObject[] { NewField1761,NewField1771};
                }
            }
            public partial class PARTCGroupFooter : TTReportSection
            {
                public TemporaryForensicReport MyParentReport
                {
                    get { return (TemporaryForensicReport)ParentReport; }
                }
                
                public TTReportField REPORTIMAGE1;
                public TTReportField NewField1114411; 
                public PARTCGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 225;
                    RepeatCount = 0;
                    
                    REPORTIMAGE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 16, 202, 222, false);
                    REPORTIMAGE1.Name = "REPORTIMAGE1";
                    REPORTIMAGE1.DrawStyle = DrawStyleConstants.vbSolid;
                    REPORTIMAGE1.FieldType = ReportFieldTypeEnum.ftOLE;
                    REPORTIMAGE1.ExpandTabs = EvetHayirEnum.ehEvet;
                    REPORTIMAGE1.ObjectDefName = "ForensicMedicalReport";
                    REPORTIMAGE1.DataMember = "REPORTIMAGE";
                    REPORTIMAGE1.Value = @"{@TTOBJECTID@}";

                    NewField1114411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 8, 202, 14, false);
                    NewField1114411.Name = "NewField1114411";
                    NewField1114411.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1114411.TextFont.Bold = true;
                    NewField1114411.TextFont.CharSet = 162;
                    NewField1114411.Value = @"VÜCUT DİYAGRAMI";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    REPORTIMAGE1.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    NewField1114411.CalcValue = NewField1114411.Value;
                    return new TTReportObject[] { REPORTIMAGE1,NewField1114411};
                }
            }

        }

        public PARTCGroup PARTC;

        public partial class ENVIRONMENTGroup : TTReportGroup
        {
            public TemporaryForensicReport MyParentReport
            {
                get { return (TemporaryForensicReport)ParentReport; }
            }

            new public ENVIRONMENTGroupBody Body()
            {
                return (ENVIRONMENTGroupBody)_body;
            }
            public TTReportField Kıyafetler { get {return Body().Kıyafetler;} }
            public TTReportField NewField1781 { get {return Body().NewField1781;} }
            public TTReportField NewField1791 { get {return Body().NewField1791;} }
            public TTReportField NewField1701 { get {return Body().NewField1701;} }
            public TTReportField NewField1711 { get {return Body().NewField1711;} }
            public TTReportField NewField1021 { get {return Body().NewField1021;} }
            public TTReportField MuayenedeBulunanalar { get {return Body().MuayenedeBulunanalar;} }
            public TTReportField MuayenedeBulunanalar12 { get {return Body().MuayenedeBulunanalar12;} }
            public TTReportField UygunOrtam { get {return Body().UygunOrtam;} }
            public TTReportField NewField1721 { get {return Body().NewField1721;} }
            public TTReportShape NewLine171 { get {return Body().NewLine171;} }
            public TTReportField ORTAMACIKLAMASI { get {return Body().ORTAMACIKLAMASI;} }
            public TTReportField KIYAFETACIKLAMASI1 { get {return Body().KIYAFETACIKLAMASI1;} }
            public ENVIRONMENTGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public ENVIRONMENTGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new ENVIRONMENTGroupBody(this);
            }

            public partial class ENVIRONMENTGroupBody : TTReportSection
            {
                public TemporaryForensicReport MyParentReport
                {
                    get { return (TemporaryForensicReport)ParentReport; }
                }
                
                public TTReportField Kıyafetler;
                public TTReportField NewField1781;
                public TTReportField NewField1791;
                public TTReportField NewField1701;
                public TTReportField NewField1711;
                public TTReportField NewField1021;
                public TTReportField MuayenedeBulunanalar;
                public TTReportField MuayenedeBulunanalar12;
                public TTReportField UygunOrtam;
                public TTReportField NewField1721;
                public TTReportShape NewLine171;
                public TTReportField ORTAMACIKLAMASI;
                public TTReportField KIYAFETACIKLAMASI1; 
                public ENVIRONMENTGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 37;
                    RepeatCount = 0;
                    
                    Kıyafetler = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 22, 95, 27, false);
                    Kıyafetler.Name = "Kıyafetler";
                    Kıyafetler.FieldType = ReportFieldTypeEnum.ftVariable;
                    Kıyafetler.TextFont.CharSet = 162;
                    Kıyafetler.Value = @"";

                    NewField1781 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 1, 60, 5, false);
                    NewField1781.Name = "NewField1781";
                    NewField1781.TextFont.Bold = true;
                    NewField1781.TextFont.CharSet = 162;
                    NewField1781.Value = @"Uygun ortam sağlandı mı?";

                    NewField1791 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 14, 60, 19, false);
                    NewField1791.Name = "NewField1791";
                    NewField1791.TextFont.Bold = true;
                    NewField1791.TextFont.CharSet = 162;
                    NewField1791.Value = @"Muayene sırasında bulunan kişiler";

                    NewField1701 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 22, 60, 26, false);
                    NewField1701.Name = "NewField1701";
                    NewField1701.TextFont.Bold = true;
                    NewField1701.TextFont.CharSet = 162;
                    NewField1701.Value = @"Muayene edilenin giysileri";

                    NewField1711 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 14, 62, 18, false);
                    NewField1711.Name = "NewField1711";
                    NewField1711.TextFont.Bold = true;
                    NewField1711.TextFont.CharSet = 162;
                    NewField1711.Value = @":";

                    NewField1021 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 1, 62, 5, false);
                    NewField1021.Name = "NewField1021";
                    NewField1021.TextFont.Bold = true;
                    NewField1021.TextFont.CharSet = 162;
                    NewField1021.Value = @":";

                    MuayenedeBulunanalar = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 14, 95, 21, false);
                    MuayenedeBulunanalar.Name = "MuayenedeBulunanalar";
                    MuayenedeBulunanalar.FieldType = ReportFieldTypeEnum.ftVariable;
                    MuayenedeBulunanalar.TextFont.CharSet = 162;
                    MuayenedeBulunanalar.Value = @"";

                    MuayenedeBulunanalar12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 96, 14, 205, 21, false);
                    MuayenedeBulunanalar12.Name = "MuayenedeBulunanalar12";
                    MuayenedeBulunanalar12.FieldType = ReportFieldTypeEnum.ftVariable;
                    MuayenedeBulunanalar12.TextFont.CharSet = 162;
                    MuayenedeBulunanalar12.Value = @"";

                    UygunOrtam = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 0, 83, 5, false);
                    UygunOrtam.Name = "UygunOrtam";
                    UygunOrtam.FieldType = ReportFieldTypeEnum.ftVariable;
                    UygunOrtam.TextFont.CharSet = 162;
                    UygunOrtam.Value = @"";

                    NewField1721 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 22, 62, 26, false);
                    NewField1721.Name = "NewField1721";
                    NewField1721.TextFont.Bold = true;
                    NewField1721.TextFont.CharSet = 162;
                    NewField1721.Value = @":";

                    NewLine171 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 12, 36, 202, 36, false);
                    NewLine171.Name = "NewLine171";
                    NewLine171.DrawStyle = DrawStyleConstants.vbSolid;

                    ORTAMACIKLAMASI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 84, 0, 205, 13, false);
                    ORTAMACIKLAMASI.Name = "ORTAMACIKLAMASI";
                    ORTAMACIKLAMASI.FieldType = ReportFieldTypeEnum.ftVariable;
                    ORTAMACIKLAMASI.MultiLine = EvetHayirEnum.ehEvet;
                    ORTAMACIKLAMASI.WordBreak = EvetHayirEnum.ehEvet;
                    ORTAMACIKLAMASI.TextFont.CharSet = 162;
                    ORTAMACIKLAMASI.Value = @"{#HEADER.ORTAMACIKLAMASI#}";

                    KIYAFETACIKLAMASI1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 95, 22, 205, 35, false);
                    KIYAFETACIKLAMASI1.Name = "KIYAFETACIKLAMASI1";
                    KIYAFETACIKLAMASI1.FieldType = ReportFieldTypeEnum.ftVariable;
                    KIYAFETACIKLAMASI1.MultiLine = EvetHayirEnum.ehEvet;
                    KIYAFETACIKLAMASI1.WordBreak = EvetHayirEnum.ehEvet;
                    KIYAFETACIKLAMASI1.TextFont.CharSet = 162;
                    KIYAFETACIKLAMASI1.Value = @"{#HEADER.KIYAFETACIKLAMASI#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ForensicMedicalReport.GetForensicMedicalReport_Class dataset_GetForensicMedicalReport = MyParentReport.HEADER.rsGroup.GetCurrentRecord<ForensicMedicalReport.GetForensicMedicalReport_Class>(0);
                    Kıyafetler.CalcValue = @"";
                    NewField1781.CalcValue = NewField1781.Value;
                    NewField1791.CalcValue = NewField1791.Value;
                    NewField1701.CalcValue = NewField1701.Value;
                    NewField1711.CalcValue = NewField1711.Value;
                    NewField1021.CalcValue = NewField1021.Value;
                    MuayenedeBulunanalar.CalcValue = @"";
                    MuayenedeBulunanalar12.CalcValue = @"";
                    UygunOrtam.CalcValue = @"";
                    NewField1721.CalcValue = NewField1721.Value;
                    ORTAMACIKLAMASI.CalcValue = (dataset_GetForensicMedicalReport != null ? Globals.ToStringCore(dataset_GetForensicMedicalReport.Ortamaciklamasi) : "");
                    KIYAFETACIKLAMASI1.CalcValue = (dataset_GetForensicMedicalReport != null ? Globals.ToStringCore(dataset_GetForensicMedicalReport.Kiyafetaciklamasi) : "");
                    return new TTReportObject[] { Kıyafetler,NewField1781,NewField1791,NewField1701,NewField1711,NewField1021,MuayenedeBulunanalar,MuayenedeBulunanalar12,UygunOrtam,NewField1721,ORTAMACIKLAMASI,KIYAFETACIKLAMASI1};
                }
            }

        }

        public ENVIRONMENTGroup ENVIRONMENT;

        public partial class STORYGroup : TTReportGroup
        {
            public TemporaryForensicReport MyParentReport
            {
                get { return (TemporaryForensicReport)ParentReport; }
            }

            new public STORYGroupHeader Header()
            {
                return (STORYGroupHeader)_header;
            }

            new public STORYGroupFooter Footer()
            {
                return (STORYGroupFooter)_footer;
            }

            public TTReportField NewField1931 { get {return Header().NewField1931;} }
            public TTReportField NewField1951 { get {return Header().NewField1951;} }
            public TTReportField NewField1071 { get {return Header().NewField1071;} }
            public TTReportShape NewLine181 { get {return Header().NewLine181;} }
            public TTReportField NewField11021 { get {return Header().NewField11021;} }
            public TTReportField NewField11051 { get {return Header().NewField11051;} }
            public STORYGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public STORYGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new STORYGroupHeader(this);
                _footer = new STORYGroupFooter(this);

            }

            public partial class STORYGroupHeader : TTReportSection
            {
                public TemporaryForensicReport MyParentReport
                {
                    get { return (TemporaryForensicReport)ParentReport; }
                }
                
                public TTReportField NewField1931;
                public TTReportField NewField1951;
                public TTReportField NewField1071;
                public TTReportShape NewLine181;
                public TTReportField NewField11021;
                public TTReportField NewField11051; 
                public STORYGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 21;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1931 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 3, 85, 11, false);
                    NewField1931.Name = "NewField1931";
                    NewField1931.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1931.TextFont.Size = 11;
                    NewField1931.TextFont.Bold = true;
                    NewField1931.TextFont.CharSet = 162;
                    NewField1931.Value = @"MUAYENEYE ESAS OLAYLA İLGİLİ BİLGİLER";

                    NewField1951 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 87, 5, 201, 10, false);
                    NewField1951.Name = "NewField1951";
                    NewField1951.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1951.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1951.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1951.TextFont.Size = 9;
                    NewField1951.TextFont.CharSet = 162;
                    NewField1951.Value = @"Bu bölümdeki bilgileri, muayeneye getirilen kişinin ifadelerine göre doldurunuz.";

                    NewField1071 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 14, 81, 18, false);
                    NewField1071.Name = "NewField1071";
                    NewField1071.TextFont.Bold = true;
                    NewField1071.TextFont.CharSet = 162;
                    NewField1071.Value = @"OLAYIN ÖYKÜSÜ";

                    NewLine181 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, 19, 79, 19, false);
                    NewLine181.Name = "NewLine181";
                    NewLine181.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField11021 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 83, 14, 201, 18, false);
                    NewField11021.Name = "NewField11021";
                    NewField11021.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11021.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11021.TextFont.Size = 9;
                    NewField11021.TextFont.CharSet = 162;
                    NewField11021.Value = @"Tarih ve saat bilgilerini belirtmeyi unutmayınız";

                    NewField11051 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 14, 83, 18, false);
                    NewField11051.Name = "NewField11051";
                    NewField11051.TextFont.Bold = true;
                    NewField11051.TextFont.CharSet = 162;
                    NewField11051.Value = @":";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1931.CalcValue = NewField1931.Value;
                    NewField1951.CalcValue = NewField1951.Value;
                    NewField1071.CalcValue = NewField1071.Value;
                    NewField11021.CalcValue = NewField11021.Value;
                    NewField11051.CalcValue = NewField11051.Value;
                    return new TTReportObject[] { NewField1931,NewField1951,NewField1071,NewField11021,NewField11051};
                }
            }
            public partial class STORYGroupFooter : TTReportSection
            {
                public TemporaryForensicReport MyParentReport
                {
                    get { return (TemporaryForensicReport)ParentReport; }
                }
                 
                public STORYGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public STORYGroup STORY;

        public partial class STORYBODYGroup : TTReportGroup
        {
            public TemporaryForensicReport MyParentReport
            {
                get { return (TemporaryForensicReport)ParentReport; }
            }

            new public STORYBODYGroupBody Body()
            {
                return (STORYBODYGroupBody)_body;
            }
            public TTReportField OLAYOYKUSU { get {return Body().OLAYOYKUSU;} }
            public STORYBODYGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public STORYBODYGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new STORYBODYGroupBody(this);
            }

            public partial class STORYBODYGroupBody : TTReportSection
            {
                public TemporaryForensicReport MyParentReport
                {
                    get { return (TemporaryForensicReport)ParentReport; }
                }
                
                public TTReportField OLAYOYKUSU; 
                public STORYBODYGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 10;
                    RepeatCount = 0;
                    
                    OLAYOYKUSU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 1, 201, 9, false);
                    OLAYOYKUSU.Name = "OLAYOYKUSU";
                    OLAYOYKUSU.FieldType = ReportFieldTypeEnum.ftVariable;
                    OLAYOYKUSU.MultiLine = EvetHayirEnum.ehEvet;
                    OLAYOYKUSU.NoClip = EvetHayirEnum.ehEvet;
                    OLAYOYKUSU.WordBreak = EvetHayirEnum.ehEvet;
                    OLAYOYKUSU.ExpandTabs = EvetHayirEnum.ehEvet;
                    OLAYOYKUSU.TextFont.CharSet = 162;
                    OLAYOYKUSU.Value = @"{#HEADER.OLAYINOYKUSU#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ForensicMedicalReport.GetForensicMedicalReport_Class dataset_GetForensicMedicalReport = MyParentReport.HEADER.rsGroup.GetCurrentRecord<ForensicMedicalReport.GetForensicMedicalReport_Class>(0);
                    OLAYOYKUSU.CalcValue = (dataset_GetForensicMedicalReport != null ? Globals.ToStringCore(dataset_GetForensicMedicalReport.Olayinoykusu) : "");
                    return new TTReportObject[] { OLAYOYKUSU};
                }
            }

        }

        public STORYBODYGroup STORYBODY;

        public partial class COMPLAINTGroup : TTReportGroup
        {
            public TemporaryForensicReport MyParentReport
            {
                get { return (TemporaryForensicReport)ParentReport; }
            }

            new public COMPLAINTGroupHeader Header()
            {
                return (COMPLAINTGroupHeader)_header;
            }

            new public COMPLAINTGroupFooter Footer()
            {
                return (COMPLAINTGroupFooter)_footer;
            }

            public TTReportField NewField1091 { get {return Header().NewField1091;} }
            public TTReportShape NewLine191 { get {return Header().NewLine191;} }
            public TTReportField NewField11041 { get {return Header().NewField11041;} }
            public COMPLAINTGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public COMPLAINTGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new COMPLAINTGroupHeader(this);
                _footer = new COMPLAINTGroupFooter(this);

            }

            public partial class COMPLAINTGroupHeader : TTReportSection
            {
                public TemporaryForensicReport MyParentReport
                {
                    get { return (TemporaryForensicReport)ParentReport; }
                }
                
                public TTReportField NewField1091;
                public TTReportShape NewLine191;
                public TTReportField NewField11041; 
                public COMPLAINTGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 7;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1091 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 2, 81, 6, false);
                    NewField1091.Name = "NewField1091";
                    NewField1091.TextFont.Bold = true;
                    NewField1091.TextFont.CharSet = 162;
                    NewField1091.Value = @"MUAYENE EDİLENİN ŞİKAYETLERİ";

                    NewLine191 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, 7, 78, 7, false);
                    NewLine191.Name = "NewLine191";
                    NewLine191.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField11041 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 2, 83, 6, false);
                    NewField11041.Name = "NewField11041";
                    NewField11041.TextFont.Name = "Courier New";
                    NewField11041.TextFont.CharSet = 162;
                    NewField11041.Value = @":";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1091.CalcValue = NewField1091.Value;
                    NewField11041.CalcValue = NewField11041.Value;
                    return new TTReportObject[] { NewField1091,NewField11041};
                }
            }
            public partial class COMPLAINTGroupFooter : TTReportSection
            {
                public TemporaryForensicReport MyParentReport
                {
                    get { return (TemporaryForensicReport)ParentReport; }
                }
                 
                public COMPLAINTGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 2;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public COMPLAINTGroup COMPLAINT;

        public partial class COMPLAINTBODYGroup : TTReportGroup
        {
            public TemporaryForensicReport MyParentReport
            {
                get { return (TemporaryForensicReport)ParentReport; }
            }

            new public COMPLAINTBODYGroupBody Body()
            {
                return (COMPLAINTBODYGroupBody)_body;
            }
            public TTReportRTF SIKAYETLERI { get {return Body().SIKAYETLERI;} }
            public COMPLAINTBODYGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public COMPLAINTBODYGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new COMPLAINTBODYGroupBody(this);
            }

            public partial class COMPLAINTBODYGroupBody : TTReportSection
            {
                public TemporaryForensicReport MyParentReport
                {
                    get { return (TemporaryForensicReport)ParentReport; }
                }
                
                public TTReportRTF SIKAYETLERI; 
                public COMPLAINTBODYGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 6;
                    RepeatCount = 0;
                    
                    SIKAYETLERI = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 11, 1, 201, 6, false);
                    SIKAYETLERI.Name = "SIKAYETLERI";
                    SIKAYETLERI.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    SIKAYETLERI.CalcValue = SIKAYETLERI.Value;
                    return new TTReportObject[] { SIKAYETLERI};
                }
                public override void RunPreScript()
                {
#region COMPLAINTBODY BODY_PreScript
                    ForensicMedicalReport forenMedRep = (ForensicMedicalReport)this.MyParentReport.ReportObjectContext.GetObject(new Guid(this.MyParentReport.RuntimeParameters.TTOBJECTID.ToString()), typeof(ForensicMedicalReport));
                   if(forenMedRep.Episode.Complaint!=null)
                   {
                        this.SIKAYETLERI.Value=forenMedRep.Episode.Complaint.ToString();
                   }
                   else
                   {
                        this.SIKAYETLERI.Value="";
                   }
#endregion COMPLAINTBODY BODY_PreScript
                }
            }

        }

        public COMPLAINTBODYGroup COMPLAINTBODY;

        public partial class HISTORYGroup : TTReportGroup
        {
            public TemporaryForensicReport MyParentReport
            {
                get { return (TemporaryForensicReport)ParentReport; }
            }

            new public HISTORYGroupHeader Header()
            {
                return (HISTORYGroupHeader)_header;
            }

            new public HISTORYGroupFooter Footer()
            {
                return (HISTORYGroupFooter)_footer;
            }

            public TTReportField NewField11001 { get {return Header().NewField11001;} }
            public TTReportShape NewLine1101 { get {return Header().NewLine1101;} }
            public TTReportField NewField11031 { get {return Header().NewField11031;} }
            public HISTORYGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public HISTORYGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new HISTORYGroupHeader(this);
                _footer = new HISTORYGroupFooter(this);

            }

            public partial class HISTORYGroupHeader : TTReportSection
            {
                public TemporaryForensicReport MyParentReport
                {
                    get { return (TemporaryForensicReport)ParentReport; }
                }
                
                public TTReportField NewField11001;
                public TTReportShape NewLine1101;
                public TTReportField NewField11031; 
                public HISTORYGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 8;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField11001 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 2, 81, 6, false);
                    NewField11001.Name = "NewField11001";
                    NewField11001.TextFont.Bold = true;
                    NewField11001.TextFont.CharSet = 162;
                    NewField11001.Value = @"MUAYENE EDİLENİN TIBBİ ÖZGEÇMİŞİ";

                    NewLine1101 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, 7, 80, 7, false);
                    NewLine1101.Name = "NewLine1101";
                    NewLine1101.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField11031 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 2, 83, 6, false);
                    NewField11031.Name = "NewField11031";
                    NewField11031.TextFont.Name = "Courier New";
                    NewField11031.TextFont.CharSet = 162;
                    NewField11031.Value = @":";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField11001.CalcValue = NewField11001.Value;
                    NewField11031.CalcValue = NewField11031.Value;
                    return new TTReportObject[] { NewField11001,NewField11031};
                }
            }
            public partial class HISTORYGroupFooter : TTReportSection
            {
                public TemporaryForensicReport MyParentReport
                {
                    get { return (TemporaryForensicReport)ParentReport; }
                }
                 
                public HISTORYGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public HISTORYGroup HISTORY;

        public partial class HISTORYBODYGroup : TTReportGroup
        {
            public TemporaryForensicReport MyParentReport
            {
                get { return (TemporaryForensicReport)ParentReport; }
            }

            new public HISTORYBODYGroupBody Body()
            {
                return (HISTORYBODYGroupBody)_body;
            }
            public TTReportRTF TIBBIGECMIS { get {return Body().TIBBIGECMIS;} }
            public HISTORYBODYGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public HISTORYBODYGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new HISTORYBODYGroupBody(this);
            }

            public partial class HISTORYBODYGroupBody : TTReportSection
            {
                public TemporaryForensicReport MyParentReport
                {
                    get { return (TemporaryForensicReport)ParentReport; }
                }
                
                public TTReportRTF TIBBIGECMIS; 
                public HISTORYBODYGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 6;
                    RepeatCount = 0;
                    
                    TIBBIGECMIS = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 11, 0, 201, 4, false);
                    TIBBIGECMIS.Name = "TIBBIGECMIS";
                    TIBBIGECMIS.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    TIBBIGECMIS.CalcValue = TIBBIGECMIS.Value;
                    return new TTReportObject[] { TIBBIGECMIS};
                }
                public override void RunPreScript()
                {
#region HISTORYBODY BODY_PreScript
                    ForensicMedicalReport forenMedRep = (ForensicMedicalReport)this.MyParentReport.ReportObjectContext.GetObject(new Guid(this.MyParentReport.RuntimeParameters.TTOBJECTID.ToString()), typeof(ForensicMedicalReport));
                   if(forenMedRep.Episode.PatientHistory != null)
                   {
                       this.TIBBIGECMIS.Value = forenMedRep.Episode.PatientHistory.ToString();
                   }
                   else
                   {
                       this.TIBBIGECMIS.Value="";
                   }
#endregion HISTORYBODY BODY_PreScript
                }
            }

        }

        public HISTORYBODYGroup HISTORYBODY;

        public partial class NOTGroup : TTReportGroup
        {
            public TemporaryForensicReport MyParentReport
            {
                get { return (TemporaryForensicReport)ParentReport; }
            }

            new public NOTGroupHeader Header()
            {
                return (NOTGroupHeader)_header;
            }

            new public NOTGroupFooter Footer()
            {
                return (NOTGroupFooter)_footer;
            }

            public TTReportField KONU { get {return Header().KONU;} }
            public TTReportField NOTused { get {return Header().NOTused;} }
            public TTReportField EVRAKSAYISI { get {return Header().EVRAKSAYISI;} }
            public TTReportField NewField183 { get {return Header().NewField183;} }
            public TTReportField NewField102 { get {return Header().NewField102;} }
            public TTReportShape NewLine13 { get {return Header().NewLine13;} }
            public TTReportField EVRAKTARIHI { get {return Header().EVRAKTARIHI;} }
            public TTReportField KURUM { get {return Header().KURUM;} }
            public TTReportField KURUM1 { get {return Header().KURUM1;} }
            public TTReportField NewField151 { get {return Header().NewField151;} }
            public TTReportShape NewLine111 { get {return Header().NewLine111;} }
            public TTReportField NewField171 { get {return Header().NewField171;} }
            public NOTGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public NOTGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new NOTGroupHeader(this);
                _footer = new NOTGroupFooter(this);

            }

            public partial class NOTGroupHeader : TTReportSection
            {
                public TemporaryForensicReport MyParentReport
                {
                    get { return (TemporaryForensicReport)ParentReport; }
                }
                
                public TTReportField KONU;
                public TTReportField NOTused;
                public TTReportField EVRAKSAYISI;
                public TTReportField NewField183;
                public TTReportField NewField102;
                public TTReportShape NewLine13;
                public TTReportField EVRAKTARIHI;
                public TTReportField KURUM;
                public TTReportField KURUM1;
                public TTReportField NewField151;
                public TTReportShape NewLine111;
                public TTReportField NewField171; 
                public NOTGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 15;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    KONU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 277, 12, 313, 16, false);
                    KONU.Name = "KONU";
                    KONU.Visible = EvetHayirEnum.ehHayir;
                    KONU.FieldType = ReportFieldTypeEnum.ftVariable;
                    KONU.TextFont.Name = "Courier New";
                    KONU.TextFont.CharSet = 162;
                    KONU.Value = @"KONU:Geçici Raporu ({#HEADER.ACTIONID#}}";

                    NOTused = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 271, 4, 297, 9, false);
                    NOTused.Name = "NOTused";
                    NOTused.Visible = EvetHayirEnum.ehHayir;
                    NOTused.FieldType = ReportFieldTypeEnum.ftVariable;
                    NOTused.MultiLine = EvetHayirEnum.ehEvet;
                    NOTused.WordBreak = EvetHayirEnum.ehEvet;
                    NOTused.TextFont.Name = "Courier New";
                    NOTused.TextFont.CharSet = 162;
                    NOTused.Value = @"Muayeneye Gönderen Makam:{%PARTB.MAKAM%}'ın {%EVRAKTARIHI%} gün ve {%EVRAKSAYISI%} sayılı yazısı.";

                    EVRAKSAYISI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 242, 4, 266, 8, false);
                    EVRAKSAYISI.Name = "EVRAKSAYISI";
                    EVRAKSAYISI.Visible = EvetHayirEnum.ehHayir;
                    EVRAKSAYISI.FieldType = ReportFieldTypeEnum.ftVariable;
                    EVRAKSAYISI.TextFont.Name = "Courier New";
                    EVRAKSAYISI.TextFont.CharSet = 162;
                    EVRAKSAYISI.Value = @"{#HEADER.DOCUMENTNUMBER#}";

                    NewField183 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 308, 4, 363, 12, false);
                    NewField183.Name = "NewField183";
                    NewField183.Visible = EvetHayirEnum.ehHayir;
                    NewField183.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField183.MultiLine = EvetHayirEnum.ehEvet;
                    NewField183.NoClip = EvetHayirEnum.ehEvet;
                    NewField183.WordBreak = EvetHayirEnum.ehEvet;
                    NewField183.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField183.TextFont.Name = "Courier New";
                    NewField183.TextFont.CharSet = 162;
                    NewField183.Value = @"{%EVRAKTARIHI%} gün ve {%EVRAKSAYISI%} sayılı yazısı.";

                    NewField102 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 370, 4, 396, 8, false);
                    NewField102.Name = "NewField102";
                    NewField102.Visible = EvetHayirEnum.ehHayir;
                    NewField102.TextFont.Name = "Courier New";
                    NewField102.TextFont.CharSet = 162;
                    NewField102.Value = @"HİZMETE ÖZEL";

                    NewLine13 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 368, 10, 394, 10, false);
                    NewLine13.Name = "NewLine13";
                    NewLine13.Visible = EvetHayirEnum.ehHayir;
                    NewLine13.DrawStyle = DrawStyleConstants.vbSolid;

                    EVRAKTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 211, 12, 236, 17, false);
                    EVRAKTARIHI.Name = "EVRAKTARIHI";
                    EVRAKTARIHI.Visible = EvetHayirEnum.ehHayir;
                    EVRAKTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    EVRAKTARIHI.TextFont.Name = "Courier New";
                    EVRAKTARIHI.TextFont.CharSet = 162;
                    EVRAKTARIHI.Value = @"{#HEADER.DOCUMENTDATE#}";

                    KURUM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 250, 10, 275, 15, false);
                    KURUM.Name = "KURUM";
                    KURUM.Visible = EvetHayirEnum.ehHayir;
                    KURUM.FieldType = ReportFieldTypeEnum.ftExpression;
                    KURUM.TextFont.Name = "Courier New";
                    KURUM.TextFont.CharSet = 162;
                    KURUM.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""RAPORKURUMU"", ""T.C. XXXXXX"")";

                    KURUM1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 211, 5, 236, 10, false);
                    KURUM1.Name = "KURUM1";
                    KURUM1.Visible = EvetHayirEnum.ehHayir;
                    KURUM1.FieldType = ReportFieldTypeEnum.ftExpression;
                    KURUM1.TextFont.Name = "Courier New";
                    KURUM1.TextFont.CharSet = 162;
                    KURUM1.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""RAPORKURUMU"", ""T.C. XXXXXX"")";

                    NewField151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 6, 66, 14, false);
                    NewField151.Name = "NewField151";
                    NewField151.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField151.TextFont.Size = 11;
                    NewField151.TextFont.Bold = true;
                    NewField151.TextFont.CharSet = 162;
                    NewField151.Value = @"İSTENİLEN KONSÜLTASYONLAR";

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, 5, 201, 5, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 6, 201, 14, false);
                    NewField171.Name = "NewField171";
                    NewField171.MultiLine = EvetHayirEnum.ehEvet;
                    NewField171.WordBreak = EvetHayirEnum.ehEvet;
                    NewField171.TextFont.Size = 9;
                    NewField171.TextFont.CharSet = 162;
                    NewField171.Value = @"Konsültasyon istemlerinizi bu kısma yazınız; konsültasyon bulguları yazılmak üzere KONSÜLTASYON MUAYENE RAPORU formu ilave ediniz. Konsültasyon bulgularına, Raporun Sonuç kısmında özetle yer veriniz.";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ForensicMedicalReport.GetForensicMedicalReport_Class dataset_GetForensicMedicalReport = MyParentReport.HEADER.rsGroup.GetCurrentRecord<ForensicMedicalReport.GetForensicMedicalReport_Class>(0);
                    KONU.CalcValue = @"KONU:Geçici Raporu (" + (dataset_GetForensicMedicalReport != null ? Globals.ToStringCore(dataset_GetForensicMedicalReport.Actionid) : "") + @"}";
                    EVRAKTARIHI.CalcValue = (dataset_GetForensicMedicalReport != null ? Globals.ToStringCore(dataset_GetForensicMedicalReport.DocumentDate) : "");
                    EVRAKSAYISI.CalcValue = (dataset_GetForensicMedicalReport != null ? Globals.ToStringCore(dataset_GetForensicMedicalReport.DocumentNumber) : "");
                    NOTused.CalcValue = @"Muayeneye Gönderen Makam:" + MyParentReport.PARTB.MAKAM.CalcValue + @"'ın " + MyParentReport.NOT.EVRAKTARIHI.CalcValue + @" gün ve " + MyParentReport.NOT.EVRAKSAYISI.CalcValue + @" sayılı yazısı.";
                    NewField183.CalcValue = MyParentReport.NOT.EVRAKTARIHI.CalcValue + @" gün ve " + MyParentReport.NOT.EVRAKSAYISI.CalcValue + @" sayılı yazısı.";
                    NewField102.CalcValue = NewField102.Value;
                    NewField151.CalcValue = NewField151.Value;
                    NewField171.CalcValue = NewField171.Value;
                    KURUM.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("RAPORKURUMU", "T.C. XXXXXX");
                    KURUM1.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("RAPORKURUMU", "T.C. XXXXXX");
                    return new TTReportObject[] { KONU,EVRAKTARIHI,EVRAKSAYISI,NOTused,NewField183,NewField102,NewField151,NewField171,KURUM,KURUM1};
                }
                public override void RunPreScript()
                {
#region NOT HEADER_PreScript
                    //              TemporaryForensicReport parentReport = (TemporaryForensicReport)ParentReport;
//                   TTObjectContext context = parentReport.ReportObjectContext;
//                   
//            string siObjectID = ((TemporaryForensicReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
//            ForensicMedicalReport forensicMedicalReport = (ForensicMedicalReport)context.GetObject(new Guid(siObjectID),"ForensicMedicalReport");
//           
//                this.SIKAYETLERI.Value = forensicMedicalReport.Episode.Complaint.ToString();
#endregion NOT HEADER_PreScript
                }
            }
            public partial class NOTGroupFooter : TTReportSection
            {
                public TemporaryForensicReport MyParentReport
                {
                    get { return (TemporaryForensicReport)ParentReport; }
                }
                 
                public NOTGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 2;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public NOTGroup NOT;

        public partial class MAINGroup : TTReportGroup
        {
            public TemporaryForensicReport MyParentReport
            {
                get { return (TemporaryForensicReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField Konsultasyon { get {return Body().Konsultasyon;} }
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
                public TemporaryForensicReport MyParentReport
                {
                    get { return (TemporaryForensicReport)ParentReport; }
                }
                
                public TTReportField Konsultasyon; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 11;
                    RepeatCount = 0;
                    
                    Konsultasyon = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 2, 201, 10, false);
                    Konsultasyon.Name = "Konsultasyon";
                    Konsultasyon.FieldType = ReportFieldTypeEnum.ftVariable;
                    Konsultasyon.MultiLine = EvetHayirEnum.ehEvet;
                    Konsultasyon.NoClip = EvetHayirEnum.ehEvet;
                    Konsultasyon.WordBreak = EvetHayirEnum.ehEvet;
                    Konsultasyon.ExpandTabs = EvetHayirEnum.ehEvet;
                    Konsultasyon.TextFont.CharSet = 162;
                    Konsultasyon.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Konsultasyon.CalcValue = @"";
                    return new TTReportObject[] { Konsultasyon};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    TTObjectContext tto = this.MyParentReport.ReportObjectContext;
                    Guid reportid = new Guid(this.MyParentReport.RuntimeParameters.TTOBJECTID.ToString());
                    ForensicMedicalReport rapor = (ForensicMedicalReport)tto.GetObject(reportid, typeof(ForensicMedicalReport));
                     string  master ="";
                    //Episode episode = rapor.Episode;
                    Guid EPISODE = new Guid();
                 EPISODE = rapor.Episode.ObjectID;
                 IBindingList consultationList = ConsultationProcedure.GetConsultationProcedureByEpisode(tto,EPISODE);
                   foreach(ConsultationProcedure consultation in consultationList)
                     {
                
                        master = master + Environment.NewLine + (consultation.Consultation.MasterResource).ToString();
                       this.Konsultasyon.CalcValue = master;
                     }
#endregion MAIN BODY_Script
                }
            }

        }

        public MAINGroup MAIN;

        public partial class FINDINGSGroup : TTReportGroup
        {
            public TemporaryForensicReport MyParentReport
            {
                get { return (TemporaryForensicReport)ParentReport; }
            }

            new public FINDINGSGroupHeader Header()
            {
                return (FINDINGSGroupHeader)_header;
            }

            new public FINDINGSGroupFooter Footer()
            {
                return (FINDINGSGroupFooter)_footer;
            }

            public TTReportField NewField181 { get {return Header().NewField181;} }
            public TTReportField NewField1101 { get {return Header().NewField1101;} }
            public TTReportField NewField1111 { get {return Header().NewField1111;} }
            public TTReportField MUAYENETARIHI { get {return Header().MUAYENETARIHI;} }
            public TTReportField NewField1131 { get {return Header().NewField1131;} }
            public TTReportField NewField1141 { get {return Header().NewField1141;} }
            public TTReportField MUAYENESAATI { get {return Header().MUAYENESAATI;} }
            public TTReportField NewField1161 { get {return Header().NewField1161;} }
            public TTReportField NewField1171 { get {return Header().NewField1171;} }
            public TTReportField NewField1181 { get {return Header().NewField1181;} }
            public TTReportShape NewLine11011 { get {return Header().NewLine11011;} }
            public TTReportShape NewLine1121 { get {return Header().NewLine1121;} }
            public FINDINGSGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public FINDINGSGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new FINDINGSGroupHeader(this);
                _footer = new FINDINGSGroupFooter(this);

            }

            public partial class FINDINGSGroupHeader : TTReportSection
            {
                public TemporaryForensicReport MyParentReport
                {
                    get { return (TemporaryForensicReport)ParentReport; }
                }
                
                public TTReportField NewField181;
                public TTReportField NewField1101;
                public TTReportField NewField1111;
                public TTReportField MUAYENETARIHI;
                public TTReportField NewField1131;
                public TTReportField NewField1141;
                public TTReportField MUAYENESAATI;
                public TTReportField NewField1161;
                public TTReportField NewField1171;
                public TTReportField NewField1181;
                public TTReportShape NewLine11011;
                public TTReportShape NewLine1121; 
                public FINDINGSGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 38;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField181 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 3, 67, 11, false);
                    NewField181.Name = "NewField181";
                    NewField181.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField181.TextFont.Size = 11;
                    NewField181.TextFont.Bold = true;
                    NewField181.TextFont.CharSet = 162;
                    NewField181.Value = @"MUAYENE BULGULARI";

                    NewField1101 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 3, 202, 16, false);
                    NewField1101.Name = "NewField1101";
                    NewField1101.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1101.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1101.TextFont.Size = 9;
                    NewField1101.TextFont.CharSet = 162;
                    NewField1101.Value = @"Bu Bölümde, bütün kısımların doldurulması gerekmemektedir. Olaya, iddiaya, talebe ve muayene bulgularına göre gerekli görülenleri yapınız ve ilgili kısmı doldurunuz.";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 17, 56, 21, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.TextFont.Bold = true;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @"Muayene Tarihi";

                    MUAYENETARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 17, 86, 21, false);
                    MUAYENETARIHI.Name = "MUAYENETARIHI";
                    MUAYENETARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    MUAYENETARIHI.TextFormat = @"dd/MM/yyyy";
                    MUAYENETARIHI.TextFont.CharSet = 162;
                    MUAYENETARIHI.Value = @"{#HEADER.ACTIONDATE#}";

                    NewField1131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 56, 17, 58, 21, false);
                    NewField1131.Name = "NewField1131";
                    NewField1131.TextFont.Bold = true;
                    NewField1131.TextFont.CharSet = 162;
                    NewField1131.Value = @":";

                    NewField1141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 149, 18, 177, 22, false);
                    NewField1141.Name = "NewField1141";
                    NewField1141.TextFont.Bold = true;
                    NewField1141.TextFont.CharSet = 162;
                    NewField1141.Value = @"Muayene Saati";

                    MUAYENESAATI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 178, 18, 202, 22, false);
                    MUAYENESAATI.Name = "MUAYENESAATI";
                    MUAYENESAATI.FieldType = ReportFieldTypeEnum.ftVariable;
                    MUAYENESAATI.TextFormat = @"Short Time";
                    MUAYENESAATI.TextFont.CharSet = 162;
                    MUAYENESAATI.Value = @"{#HEADER.ACTIONDATE#}";

                    NewField1161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 176, 18, 178, 22, false);
                    NewField1161.Name = "NewField1161";
                    NewField1161.TextFont.Bold = true;
                    NewField1161.TextFont.CharSet = 162;
                    NewField1161.Value = @":";

                    NewField1171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 24, 67, 32, false);
                    NewField1171.Name = "NewField1171";
                    NewField1171.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1171.TextFont.Bold = true;
                    NewField1171.TextFont.CharSet = 162;
                    NewField1171.Value = @"LEZYON(LAR) İLE İLGİLİ BULGULAR";

                    NewField1181 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 24, 202, 37, false);
                    NewField1181.Name = "NewField1181";
                    NewField1181.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1181.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1181.TextFont.Size = 9;
                    NewField1181.TextFont.CharSet = 162;
                    NewField1181.Value = @"Olaya ve iddiaya göre muayene yaparak, varsa lezyon bulunan bölgeyi işaretleyiniz ve lezyonun özelliklerini tanımlayınız; ayrıca Rapora ilgili VÜCUT DİYAGRAMI formunu ekleyip üzerinde işaretleme yapınız. Lezyon yoksa saptanamadığını belirtiniz. Boş kalan kısımları çizerek iptal ediniz.";

                    NewLine11011 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, 32, 65, 32, false);
                    NewLine11011.Name = "NewLine11011";
                    NewLine11011.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, 1, 201, 1, false);
                    NewLine1121.Name = "NewLine1121";
                    NewLine1121.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ForensicMedicalReport.GetForensicMedicalReport_Class dataset_GetForensicMedicalReport = MyParentReport.HEADER.rsGroup.GetCurrentRecord<ForensicMedicalReport.GetForensicMedicalReport_Class>(0);
                    NewField181.CalcValue = NewField181.Value;
                    NewField1101.CalcValue = NewField1101.Value;
                    NewField1111.CalcValue = NewField1111.Value;
                    MUAYENETARIHI.CalcValue = (dataset_GetForensicMedicalReport != null ? Globals.ToStringCore(dataset_GetForensicMedicalReport.ActionDate) : "");
                    NewField1131.CalcValue = NewField1131.Value;
                    NewField1141.CalcValue = NewField1141.Value;
                    MUAYENESAATI.CalcValue = (dataset_GetForensicMedicalReport != null ? Globals.ToStringCore(dataset_GetForensicMedicalReport.ActionDate) : "");
                    NewField1161.CalcValue = NewField1161.Value;
                    NewField1171.CalcValue = NewField1171.Value;
                    NewField1181.CalcValue = NewField1181.Value;
                    return new TTReportObject[] { NewField181,NewField1101,NewField1111,MUAYENETARIHI,NewField1131,NewField1141,MUAYENESAATI,NewField1161,NewField1171,NewField1181};
                }
            }
            public partial class FINDINGSGroupFooter : TTReportSection
            {
                public TemporaryForensicReport MyParentReport
                {
                    get { return (TemporaryForensicReport)ParentReport; }
                }
                 
                public FINDINGSGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public FINDINGSGroup FINDINGS;

        public partial class FINDINGSBODYGroup : TTReportGroup
        {
            public TemporaryForensicReport MyParentReport
            {
                get { return (TemporaryForensicReport)ParentReport; }
            }

            new public FINDINGSBODYGroupBody Body()
            {
                return (FINDINGSBODYGroupBody)_body;
            }
            public TTReportField Bas { get {return Body().Bas;} }
            public TTReportField Gogus { get {return Body().Gogus;} }
            public TTReportField NewField1221 { get {return Body().NewField1221;} }
            public TTReportField Batin { get {return Body().Batin;} }
            public TTReportField NewField1241 { get {return Body().NewField1241;} }
            public TTReportField Sirt { get {return Body().Sirt;} }
            public TTReportField NewField1261 { get {return Body().NewField1261;} }
            public TTReportField NewField1361 { get {return Body().NewField1361;} }
            public TTReportField UstEkstremite { get {return Body().UstEkstremite;} }
            public TTReportField NewField1281 { get {return Body().NewField1281;} }
            public TTReportField AltEkstremite { get {return Body().AltEkstremite;} }
            public TTReportField NewField1301 { get {return Body().NewField1301;} }
            public TTReportField Genital { get {return Body().Genital;} }
            public TTReportField NewField1321 { get {return Body().NewField1321;} }
            public TTReportField LEZYONLAR { get {return Body().LEZYONLAR;} }
            public FINDINGSBODYGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public FINDINGSBODYGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new FINDINGSBODYGroupBody(this);
            }

            public partial class FINDINGSBODYGroupBody : TTReportSection
            {
                public TemporaryForensicReport MyParentReport
                {
                    get { return (TemporaryForensicReport)ParentReport; }
                }
                
                public TTReportField Bas;
                public TTReportField Gogus;
                public TTReportField NewField1221;
                public TTReportField Batin;
                public TTReportField NewField1241;
                public TTReportField Sirt;
                public TTReportField NewField1261;
                public TTReportField NewField1361;
                public TTReportField UstEkstremite;
                public TTReportField NewField1281;
                public TTReportField AltEkstremite;
                public TTReportField NewField1301;
                public TTReportField Genital;
                public TTReportField NewField1321;
                public TTReportField LEZYONLAR; 
                public FINDINGSBODYGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 16;
                    RepeatCount = 0;
                    
                    Bas = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 4, 15, 8, false);
                    Bas.Name = "Bas";
                    Bas.DrawStyle = DrawStyleConstants.vbSolid;
                    Bas.TextFont.CharSet = 162;
                    Bas.Value = @"";

                    Gogus = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 4, 42, 8, false);
                    Gogus.Name = "Gogus";
                    Gogus.DrawStyle = DrawStyleConstants.vbSolid;
                    Gogus.TextFont.CharSet = 162;
                    Gogus.Value = @"";

                    NewField1221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 43, 4, 65, 8, false);
                    NewField1221.Name = "NewField1221";
                    NewField1221.TextFont.CharSet = 162;
                    NewField1221.Value = @"Göğüs";

                    Batin = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 65, 4, 69, 8, false);
                    Batin.Name = "Batin";
                    Batin.DrawStyle = DrawStyleConstants.vbSolid;
                    Batin.TextFont.CharSet = 162;
                    Batin.Value = @"";

                    NewField1241 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 70, 4, 92, 8, false);
                    NewField1241.Name = "NewField1241";
                    NewField1241.TextFont.CharSet = 162;
                    NewField1241.Value = @"Batın";

                    Sirt = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 92, 4, 96, 8, false);
                    Sirt.Name = "Sirt";
                    Sirt.DrawStyle = DrawStyleConstants.vbSolid;
                    Sirt.TextFont.CharSet = 162;
                    Sirt.Value = @"";

                    NewField1261 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 97, 4, 119, 8, false);
                    NewField1261.Name = "NewField1261";
                    NewField1261.TextFont.CharSet = 162;
                    NewField1261.Value = @"Sırt-bel";

                    NewField1361 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 4, 37, 8, false);
                    NewField1361.Name = "NewField1361";
                    NewField1361.TextFont.CharSet = 162;
                    NewField1361.Value = @"Baş-boyun";

                    UstEkstremite = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 119, 4, 123, 8, false);
                    UstEkstremite.Name = "UstEkstremite";
                    UstEkstremite.DrawStyle = DrawStyleConstants.vbSolid;
                    UstEkstremite.TextFont.CharSet = 162;
                    UstEkstremite.Value = @"";

                    NewField1281 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 124, 4, 146, 8, false);
                    NewField1281.Name = "NewField1281";
                    NewField1281.TextFont.CharSet = 162;
                    NewField1281.Value = @"Üst ekstremite";

                    AltEkstremite = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 146, 4, 150, 8, false);
                    AltEkstremite.Name = "AltEkstremite";
                    AltEkstremite.DrawStyle = DrawStyleConstants.vbSolid;
                    AltEkstremite.TextFont.CharSet = 162;
                    AltEkstremite.Value = @"";

                    NewField1301 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 4, 173, 8, false);
                    NewField1301.Name = "NewField1301";
                    NewField1301.TextFont.CharSet = 162;
                    NewField1301.Value = @"Alt ekstremite";

                    Genital = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 173, 4, 177, 8, false);
                    Genital.Name = "Genital";
                    Genital.DrawStyle = DrawStyleConstants.vbSolid;
                    Genital.TextFont.CharSet = 162;
                    Genital.Value = @"";

                    NewField1321 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 178, 4, 202, 8, false);
                    NewField1321.Name = "NewField1321";
                    NewField1321.TextFont.CharSet = 162;
                    NewField1321.Value = @"Genital bölge";

                    LEZYONLAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 10, 202, 15, false);
                    LEZYONLAR.Name = "LEZYONLAR";
                    LEZYONLAR.MultiLine = EvetHayirEnum.ehEvet;
                    LEZYONLAR.NoClip = EvetHayirEnum.ehEvet;
                    LEZYONLAR.WordBreak = EvetHayirEnum.ehEvet;
                    LEZYONLAR.ExpandTabs = EvetHayirEnum.ehEvet;
                    LEZYONLAR.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Bas.CalcValue = Bas.Value;
                    Gogus.CalcValue = Gogus.Value;
                    NewField1221.CalcValue = NewField1221.Value;
                    Batin.CalcValue = Batin.Value;
                    NewField1241.CalcValue = NewField1241.Value;
                    Sirt.CalcValue = Sirt.Value;
                    NewField1261.CalcValue = NewField1261.Value;
                    NewField1361.CalcValue = NewField1361.Value;
                    UstEkstremite.CalcValue = UstEkstremite.Value;
                    NewField1281.CalcValue = NewField1281.Value;
                    AltEkstremite.CalcValue = AltEkstremite.Value;
                    NewField1301.CalcValue = NewField1301.Value;
                    Genital.CalcValue = Genital.Value;
                    NewField1321.CalcValue = NewField1321.Value;
                    LEZYONLAR.CalcValue = LEZYONLAR.Value;
                    return new TTReportObject[] { Bas,Gogus,NewField1221,Batin,NewField1241,Sirt,NewField1261,NewField1361,UstEkstremite,NewField1281,AltEkstremite,NewField1301,Genital,NewField1321,LEZYONLAR};
                }

                public override void RunScript()
                {
#region FINDINGSBODY BODY_Script
                    TTObjectContext tto = this.ParentReport.ReportObjectContext;
                    Guid reportid = new Guid(this.MyParentReport.RuntimeParameters.TTOBJECTID.ToString());
                    ForensicMedicalReport rapor = (ForensicMedicalReport)tto.GetObject(reportid, typeof(ForensicMedicalReport));
                    
                        if (rapor.Abdominal.HasValue)
                        {
                            if (rapor.Abdominal.Value) this.Batin.CalcValue = "X";
                        
                        }

                        if (rapor.HeadNeck.HasValue)
                        {
                            if (rapor.HeadNeck.Value) this.Bas.CalcValue = "X";
                        }

                        if (rapor.Chest.HasValue)
                        {
                            if (rapor.Chest.Value) this.Gogus.CalcValue = "X";
                        }

                        if (rapor.Back.HasValue)
                        {
                            if (rapor.Back.Value) this.Sirt.CalcValue = "X";
                        }

                        if (rapor.UpperExtrimity.HasValue)
                        {
                            if (rapor.UpperExtrimity.Value) this.UstEkstremite.CalcValue = "X";
                        }

                        if (rapor.LowerExtremity.HasValue)
                        {
                            if (rapor.LowerExtremity.Value) this.AltEkstremite.CalcValue = "X";
                        }

                        if (rapor.GenitalArea.HasValue)
                        {
                            if (rapor.GenitalArea.Value) this.Genital.CalcValue = "X";
                        }
                        
                 if(rapor.PropertiesOfLesions != null)
                   {
                       this.LEZYONLAR.CalcValue = rapor.PropertiesOfLesions.ToString();
                   }
                   else
                   {
                       this.LEZYONLAR.CalcValue="";
                   }
#endregion FINDINGSBODY BODY_Script
                }
            }

        }

        public FINDINGSBODYGroup FINDINGSBODY;

        public partial class SYSTEMEXAMINATIONGroup : TTReportGroup
        {
            public TemporaryForensicReport MyParentReport
            {
                get { return (TemporaryForensicReport)ParentReport; }
            }

            new public SYSTEMEXAMINATIONGroupHeader Header()
            {
                return (SYSTEMEXAMINATIONGroupHeader)_header;
            }

            new public SYSTEMEXAMINATIONGroupFooter Footer()
            {
                return (SYSTEMEXAMINATIONGroupFooter)_footer;
            }

            public TTReportField NewField1411 { get {return Header().NewField1411;} }
            public TTReportField NewField1421 { get {return Header().NewField1421;} }
            public TTReportShape NewLine111011 { get {return Header().NewLine111011;} }
            public SYSTEMEXAMINATIONGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public SYSTEMEXAMINATIONGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new SYSTEMEXAMINATIONGroupHeader(this);
                _footer = new SYSTEMEXAMINATIONGroupFooter(this);

            }

            public partial class SYSTEMEXAMINATIONGroupHeader : TTReportSection
            {
                public TemporaryForensicReport MyParentReport
                {
                    get { return (TemporaryForensicReport)ParentReport; }
                }
                
                public TTReportField NewField1411;
                public TTReportField NewField1421;
                public TTReportShape NewLine111011; 
                public SYSTEMEXAMINATIONGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 13;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 2, 67, 10, false);
                    NewField1411.Name = "NewField1411";
                    NewField1411.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1411.TextFont.Bold = true;
                    NewField1411.TextFont.CharSet = 162;
                    NewField1411.Value = @"SİSTEM MUAYENELERİ";

                    NewField1421 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 4, 202, 9, false);
                    NewField1421.Name = "NewField1421";
                    NewField1421.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1421.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1421.TextFont.Size = 9;
                    NewField1421.TextFont.CharSet = 162;
                    NewField1421.Value = @"Tespit edilen diğer bulgularla ilgili sistemi işaretleyiniz ve bulguları belirtiniz.";

                    NewLine111011 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, 10, 66, 10, false);
                    NewLine111011.Name = "NewLine111011";
                    NewLine111011.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1411.CalcValue = NewField1411.Value;
                    NewField1421.CalcValue = NewField1421.Value;
                    return new TTReportObject[] { NewField1411,NewField1421};
                }
            }
            public partial class SYSTEMEXAMINATIONGroupFooter : TTReportSection
            {
                public TemporaryForensicReport MyParentReport
                {
                    get { return (TemporaryForensicReport)ParentReport; }
                }
                 
                public SYSTEMEXAMINATIONGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public SYSTEMEXAMINATIONGroup SYSTEMEXAMINATION;

        public partial class SYSTEMEXAMINATIONBODYGroup : TTReportGroup
        {
            public TemporaryForensicReport MyParentReport
            {
                get { return (TemporaryForensicReport)ParentReport; }
            }

            new public SYSTEMEXAMINATIONBODYGroupBody Body()
            {
                return (SYSTEMEXAMINATIONBODYGroupBody)_body;
            }
            public TTReportField MerkeziSinirSis { get {return Body().MerkeziSinirSis;} }
            public TTReportField NewField1351 { get {return Body().NewField1351;} }
            public TTReportField SolunumSis { get {return Body().SolunumSis;} }
            public TTReportField NewField1371 { get {return Body().NewField1371;} }
            public TTReportField SindirimSis { get {return Body().SindirimSis;} }
            public TTReportField NewField1391 { get {return Body().NewField1391;} }
            public TTReportField UrogenitalSis { get {return Body().UrogenitalSis;} }
            public TTReportField NewField1521 { get {return Body().NewField1521;} }
            public TTReportField KasIskeletSis { get {return Body().KasIskeletSis;} }
            public TTReportField NewField1441 { get {return Body().NewField1441;} }
            public TTReportField DuyuOrganlarıSis { get {return Body().DuyuOrganlarıSis;} }
            public TTReportField NewField1561 { get {return Body().NewField1561;} }
            public TTReportField NewField1401 { get {return Body().NewField1401;} }
            public TTReportField KalpDamarSis { get {return Body().KalpDamarSis;} }
            public TTReportField NewField111 { get {return Body().NewField111;} }
            public TTReportField GeneralCondition11 { get {return Body().GeneralCondition11;} }
            public TTReportField NewField121 { get {return Body().NewField121;} }
            public TTReportField Solunum { get {return Body().Solunum;} }
            public TTReportField NewField161 { get {return Body().NewField161;} }
            public TTReportField Bilinci { get {return Body().Bilinci;} }
            public TTReportField NewField191 { get {return Body().NewField191;} }
            public TTReportField Pupiller { get {return Body().Pupiller;} }
            public TTReportField NewField102 { get {return Body().NewField102;} }
            public TTReportField Tansiyon { get {return Body().Tansiyon;} }
            public TTReportField NewField112 { get {return Body().NewField112;} }
            public TTReportField IsıkRefleksi { get {return Body().IsıkRefleksi;} }
            public TTReportField NewField122 { get {return Body().NewField122;} }
            public TTReportField Nabız { get {return Body().Nabız;} }
            public TTReportField NewField132 { get {return Body().NewField132;} }
            public TTReportField TendonReflex { get {return Body().TendonReflex;} }
            public TTReportField Bulgular { get {return Body().Bulgular;} }
            public TTReportField NewField1 { get {return Body().NewField1;} }
            public TTReportField NewField11 { get {return Body().NewField11;} }
            public TTReportField NewField12 { get {return Body().NewField12;} }
            public TTReportField NewField13 { get {return Body().NewField13;} }
            public TTReportField NewField14 { get {return Body().NewField14;} }
            public TTReportField NewField15 { get {return Body().NewField15;} }
            public TTReportField NewField123 { get {return Body().NewField123;} }
            public TTReportField NewField131 { get {return Body().NewField131;} }
            public SYSTEMEXAMINATIONBODYGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public SYSTEMEXAMINATIONBODYGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new SYSTEMEXAMINATIONBODYGroupBody(this);
            }

            public partial class SYSTEMEXAMINATIONBODYGroupBody : TTReportSection
            {
                public TemporaryForensicReport MyParentReport
                {
                    get { return (TemporaryForensicReport)ParentReport; }
                }
                
                public TTReportField MerkeziSinirSis;
                public TTReportField NewField1351;
                public TTReportField SolunumSis;
                public TTReportField NewField1371;
                public TTReportField SindirimSis;
                public TTReportField NewField1391;
                public TTReportField UrogenitalSis;
                public TTReportField NewField1521;
                public TTReportField KasIskeletSis;
                public TTReportField NewField1441;
                public TTReportField DuyuOrganlarıSis;
                public TTReportField NewField1561;
                public TTReportField NewField1401;
                public TTReportField KalpDamarSis;
                public TTReportField NewField111;
                public TTReportField GeneralCondition11;
                public TTReportField NewField121;
                public TTReportField Solunum;
                public TTReportField NewField161;
                public TTReportField Bilinci;
                public TTReportField NewField191;
                public TTReportField Pupiller;
                public TTReportField NewField102;
                public TTReportField Tansiyon;
                public TTReportField NewField112;
                public TTReportField IsıkRefleksi;
                public TTReportField NewField122;
                public TTReportField Nabız;
                public TTReportField NewField132;
                public TTReportField TendonReflex;
                public TTReportField Bulgular;
                public TTReportField NewField1;
                public TTReportField NewField11;
                public TTReportField NewField12;
                public TTReportField NewField13;
                public TTReportField NewField14;
                public TTReportField NewField15;
                public TTReportField NewField123;
                public TTReportField NewField131; 
                public SYSTEMEXAMINATIONBODYGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 51;
                    RepeatCount = 0;
                    
                    MerkeziSinirSis = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 2, 15, 6, false);
                    MerkeziSinirSis.Name = "MerkeziSinirSis";
                    MerkeziSinirSis.DrawStyle = DrawStyleConstants.vbSolid;
                    MerkeziSinirSis.TextFont.CharSet = 162;
                    MerkeziSinirSis.Value = @"";

                    NewField1351 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 63, 2, 97, 6, false);
                    NewField1351.Name = "NewField1351";
                    NewField1351.TextFont.CharSet = 162;
                    NewField1351.Value = @"Kalp Damar Sistemi";

                    SolunumSis = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 101, 2, 105, 6, false);
                    SolunumSis.Name = "SolunumSis";
                    SolunumSis.DrawStyle = DrawStyleConstants.vbSolid;
                    SolunumSis.TextFont.CharSet = 162;
                    SolunumSis.Value = @"";

                    NewField1371 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 2, 140, 6, false);
                    NewField1371.Name = "NewField1371";
                    NewField1371.TextFont.CharSet = 162;
                    NewField1371.Value = @"Solunum Sistemi";

                    SindirimSis = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 148, 2, 152, 6, false);
                    SindirimSis.Name = "SindirimSis";
                    SindirimSis.DrawStyle = DrawStyleConstants.vbSolid;
                    SindirimSis.TextFont.CharSet = 162;
                    SindirimSis.Value = @"";

                    NewField1391 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 153, 2, 187, 6, false);
                    NewField1391.Name = "NewField1391";
                    NewField1391.TextFont.CharSet = 162;
                    NewField1391.Value = @"Sindirim Sistemi";

                    UrogenitalSis = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 14, 15, 18, false);
                    UrogenitalSis.Name = "UrogenitalSis";
                    UrogenitalSis.DrawStyle = DrawStyleConstants.vbSolid;
                    UrogenitalSis.TextFont.CharSet = 162;
                    UrogenitalSis.Value = @"";

                    NewField1521 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 14, 50, 18, false);
                    NewField1521.Name = "NewField1521";
                    NewField1521.TextFont.CharSet = 162;
                    NewField1521.Value = @"Ürogenital Sistemi";

                    KasIskeletSis = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 14, 62, 18, false);
                    KasIskeletSis.Name = "KasIskeletSis";
                    KasIskeletSis.DrawStyle = DrawStyleConstants.vbSolid;
                    KasIskeletSis.TextFont.CharSet = 162;
                    KasIskeletSis.Value = @"";

                    NewField1441 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 63, 14, 99, 18, false);
                    NewField1441.Name = "NewField1441";
                    NewField1441.TextFont.CharSet = 162;
                    NewField1441.Value = @"Kas İskelet Sistemi";

                    DuyuOrganlarıSis = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 101, 14, 105, 18, false);
                    DuyuOrganlarıSis.Name = "DuyuOrganlarıSis";
                    DuyuOrganlarıSis.DrawStyle = DrawStyleConstants.vbSolid;
                    DuyuOrganlarıSis.TextFont.CharSet = 162;
                    DuyuOrganlarıSis.Value = @"";

                    NewField1561 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 14, 140, 18, false);
                    NewField1561.Name = "NewField1561";
                    NewField1561.TextFont.CharSet = 162;
                    NewField1561.Value = @"Duyu Organları";

                    NewField1401 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 2, 50, 6, false);
                    NewField1401.Name = "NewField1401";
                    NewField1401.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1401.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1401.TextFont.CharSet = 162;
                    NewField1401.Value = @"Merkezi Sinir Sistemi";

                    KalpDamarSis = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 2, 62, 6, false);
                    KalpDamarSis.Name = "KalpDamarSis";
                    KalpDamarSis.DrawStyle = DrawStyleConstants.vbSolid;
                    KalpDamarSis.TextFont.CharSet = 162;
                    KalpDamarSis.Value = @"";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 26, 32, 31, false);
                    NewField111.Name = "NewField111";
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"Genel Durum";

                    GeneralCondition11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 26, 55, 31, false);
                    GeneralCondition11.Name = "GeneralCondition11";
                    GeneralCondition11.FieldType = ReportFieldTypeEnum.ftVariable;
                    GeneralCondition11.ObjectDefName = "GeneralConditionOfPatientEnum";
                    GeneralCondition11.DataMember = "DISPLAYTEXT";
                    GeneralCondition11.TextFont.CharSet = 162;
                    GeneralCondition11.Value = @"{#HEADER.GENELDURUM#}";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 35, 32, 40, false);
                    NewField121.Name = "NewField121";
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"Solunum   ";

                    Solunum = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 35, 55, 40, false);
                    Solunum.Name = "Solunum";
                    Solunum.FieldType = ReportFieldTypeEnum.ftVariable;
                    Solunum.ObjectDefName = "RespitoryEnum";
                    Solunum.DataMember = "DISPLAYTEXT";
                    Solunum.TextFont.CharSet = 162;
                    Solunum.Value = @"{#HEADER.SOLUNUM#}";

                    NewField161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 56, 26, 72, 31, false);
                    NewField161.Name = "NewField161";
                    NewField161.TextFont.Bold = true;
                    NewField161.TextFont.CharSet = 162;
                    NewField161.Value = @"Bilinci";

                    Bilinci = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 26, 106, 31, false);
                    Bilinci.Name = "Bilinci";
                    Bilinci.FieldType = ReportFieldTypeEnum.ftVariable;
                    Bilinci.ObjectDefName = "AwarenessEnum";
                    Bilinci.DataMember = "DISPLAYTEXT";
                    Bilinci.TextFont.CharSet = 162;
                    Bilinci.Value = @"{#HEADER.BILINCI#}";

                    NewField191 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 56, 35, 72, 40, false);
                    NewField191.Name = "NewField191";
                    NewField191.TextFont.Bold = true;
                    NewField191.TextFont.CharSet = 162;
                    NewField191.Value = @"Pupiller";

                    Pupiller = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 35, 106, 40, false);
                    Pupiller.Name = "Pupiller";
                    Pupiller.FieldType = ReportFieldTypeEnum.ftVariable;
                    Pupiller.ObjectDefName = "PupilPropertiesEnum";
                    Pupiller.DataMember = "DISPLAYTEXT";
                    Pupiller.TextFont.CharSet = 162;
                    Pupiller.Value = @"{#HEADER.PUPILPROPERTIES#}";

                    NewField102 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 108, 26, 136, 31, false);
                    NewField102.Name = "NewField102";
                    NewField102.TextFont.Bold = true;
                    NewField102.TextFont.CharSet = 162;
                    NewField102.Value = @"Tansiyon arteryel";

                    Tansiyon = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 136, 26, 151, 31, false);
                    Tansiyon.Name = "Tansiyon";
                    Tansiyon.FieldType = ReportFieldTypeEnum.ftVariable;
                    Tansiyon.TextFont.CharSet = 162;
                    Tansiyon.Value = @"{#HEADER.ARTERIALBLOODPRESURE#}";

                    NewField112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 108, 35, 135, 40, false);
                    NewField112.Name = "NewField112";
                    NewField112.TextFont.Bold = true;
                    NewField112.TextFont.CharSet = 162;
                    NewField112.Value = @"Işık Refleksi ";

                    IsıkRefleksi = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 136, 35, 151, 40, false);
                    IsıkRefleksi.Name = "IsıkRefleksi";
                    IsıkRefleksi.FieldType = ReportFieldTypeEnum.ftVariable;
                    IsıkRefleksi.ObjectDefName = "LightReflexEnum";
                    IsıkRefleksi.DataMember = "DISPLAYTEXT";
                    IsıkRefleksi.TextFont.CharSet = 162;
                    IsıkRefleksi.Value = @"{#HEADER.LIGHTREFLEX#}";

                    NewField122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 26, 177, 31, false);
                    NewField122.Name = "NewField122";
                    NewField122.TextFont.Bold = true;
                    NewField122.TextFont.CharSet = 162;
                    NewField122.Value = @"Nabız  ";

                    Nabız = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 178, 26, 202, 31, false);
                    Nabız.Name = "Nabız";
                    Nabız.FieldType = ReportFieldTypeEnum.ftVariable;
                    Nabız.TextFont.CharSet = 162;
                    Nabız.Value = @"{#HEADER.PULSE#}";

                    NewField132 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 35, 177, 40, false);
                    NewField132.Name = "NewField132";
                    NewField132.TextFont.Bold = true;
                    NewField132.TextFont.CharSet = 162;
                    NewField132.Value = @"Tendon Refleksi";

                    TendonReflex = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 178, 35, 202, 40, false);
                    TendonReflex.Name = "TendonReflex";
                    TendonReflex.FieldType = ReportFieldTypeEnum.ftVariable;
                    TendonReflex.ObjectDefName = "TendonReflexesEnum";
                    TendonReflex.DataMember = "DISPLAYTEXT";
                    TendonReflex.TextFont.CharSet = 162;
                    TendonReflex.Value = @"{#HEADER.TENDONREFLEXES#}";

                    Bulgular = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 43, 202, 50, false);
                    Bulgular.Name = "Bulgular";
                    Bulgular.FieldType = ReportFieldTypeEnum.ftVariable;
                    Bulgular.MultiLine = EvetHayirEnum.ehEvet;
                    Bulgular.NoClip = EvetHayirEnum.ehEvet;
                    Bulgular.WordBreak = EvetHayirEnum.ehEvet;
                    Bulgular.ExpandTabs = EvetHayirEnum.ehEvet;
                    Bulgular.TextFont.CharSet = 162;
                    Bulgular.Value = @"{#HEADER.SISTEMBULGULARI#}";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 71, 26, 73, 31, false);
                    NewField1.Name = "NewField1";
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @":";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 71, 35, 73, 40, false);
                    NewField11.Name = "NewField11";
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @":";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 134, 35, 136, 40, false);
                    NewField12.Name = "NewField12";
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @":";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 134, 26, 136, 31, false);
                    NewField13.Name = "NewField13";
                    NewField13.TextFont.Bold = true;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @":";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 32, 35, 34, 40, false);
                    NewField14.Name = "NewField14";
                    NewField14.TextFont.Bold = true;
                    NewField14.TextFont.CharSet = 162;
                    NewField14.Value = @":";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 32, 26, 34, 31, false);
                    NewField15.Name = "NewField15";
                    NewField15.TextFont.Bold = true;
                    NewField15.TextFont.CharSet = 162;
                    NewField15.Value = @":";

                    NewField123 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 176, 35, 178, 40, false);
                    NewField123.Name = "NewField123";
                    NewField123.TextFont.Bold = true;
                    NewField123.TextFont.CharSet = 162;
                    NewField123.Value = @":";

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 176, 26, 178, 31, false);
                    NewField131.Name = "NewField131";
                    NewField131.TextFont.Bold = true;
                    NewField131.TextFont.CharSet = 162;
                    NewField131.Value = @":";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ForensicMedicalReport.GetForensicMedicalReport_Class dataset_GetForensicMedicalReport = MyParentReport.HEADER.rsGroup.GetCurrentRecord<ForensicMedicalReport.GetForensicMedicalReport_Class>(0);
                    MerkeziSinirSis.CalcValue = MerkeziSinirSis.Value;
                    NewField1351.CalcValue = NewField1351.Value;
                    SolunumSis.CalcValue = SolunumSis.Value;
                    NewField1371.CalcValue = NewField1371.Value;
                    SindirimSis.CalcValue = SindirimSis.Value;
                    NewField1391.CalcValue = NewField1391.Value;
                    UrogenitalSis.CalcValue = UrogenitalSis.Value;
                    NewField1521.CalcValue = NewField1521.Value;
                    KasIskeletSis.CalcValue = KasIskeletSis.Value;
                    NewField1441.CalcValue = NewField1441.Value;
                    DuyuOrganlarıSis.CalcValue = DuyuOrganlarıSis.Value;
                    NewField1561.CalcValue = NewField1561.Value;
                    NewField1401.CalcValue = NewField1401.Value;
                    KalpDamarSis.CalcValue = KalpDamarSis.Value;
                    NewField111.CalcValue = NewField111.Value;
                    GeneralCondition11.CalcValue = (dataset_GetForensicMedicalReport != null ? Globals.ToStringCore(dataset_GetForensicMedicalReport.Geneldurum) : "");
                    GeneralCondition11.PostFieldValueCalculation();
                    NewField121.CalcValue = NewField121.Value;
                    Solunum.CalcValue = (dataset_GetForensicMedicalReport != null ? Globals.ToStringCore(dataset_GetForensicMedicalReport.Solunum) : "");
                    Solunum.PostFieldValueCalculation();
                    NewField161.CalcValue = NewField161.Value;
                    Bilinci.CalcValue = (dataset_GetForensicMedicalReport != null ? Globals.ToStringCore(dataset_GetForensicMedicalReport.Bilinci) : "");
                    Bilinci.PostFieldValueCalculation();
                    NewField191.CalcValue = NewField191.Value;
                    Pupiller.CalcValue = (dataset_GetForensicMedicalReport != null ? Globals.ToStringCore(dataset_GetForensicMedicalReport.PupilProperties) : "");
                    Pupiller.PostFieldValueCalculation();
                    NewField102.CalcValue = NewField102.Value;
                    Tansiyon.CalcValue = (dataset_GetForensicMedicalReport != null ? Globals.ToStringCore(dataset_GetForensicMedicalReport.ArterialBloodPresure) : "");
                    NewField112.CalcValue = NewField112.Value;
                    IsıkRefleksi.CalcValue = (dataset_GetForensicMedicalReport != null ? Globals.ToStringCore(dataset_GetForensicMedicalReport.LightReflex) : "");
                    IsıkRefleksi.PostFieldValueCalculation();
                    NewField122.CalcValue = NewField122.Value;
                    Nabız.CalcValue = (dataset_GetForensicMedicalReport != null ? Globals.ToStringCore(dataset_GetForensicMedicalReport.Pulse) : "");
                    NewField132.CalcValue = NewField132.Value;
                    TendonReflex.CalcValue = (dataset_GetForensicMedicalReport != null ? Globals.ToStringCore(dataset_GetForensicMedicalReport.TendonReflexes) : "");
                    TendonReflex.PostFieldValueCalculation();
                    Bulgular.CalcValue = (dataset_GetForensicMedicalReport != null ? Globals.ToStringCore(dataset_GetForensicMedicalReport.Sistembulgulari) : "");
                    NewField1.CalcValue = NewField1.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField14.CalcValue = NewField14.Value;
                    NewField15.CalcValue = NewField15.Value;
                    NewField123.CalcValue = NewField123.Value;
                    NewField131.CalcValue = NewField131.Value;
                    return new TTReportObject[] { MerkeziSinirSis,NewField1351,SolunumSis,NewField1371,SindirimSis,NewField1391,UrogenitalSis,NewField1521,KasIskeletSis,NewField1441,DuyuOrganlarıSis,NewField1561,NewField1401,KalpDamarSis,NewField111,GeneralCondition11,NewField121,Solunum,NewField161,Bilinci,NewField191,Pupiller,NewField102,Tansiyon,NewField112,IsıkRefleksi,NewField122,Nabız,NewField132,TendonReflex,Bulgular,NewField1,NewField11,NewField12,NewField13,NewField14,NewField15,NewField123,NewField131};
                }

                public override void RunScript()
                {
#region SYSTEMEXAMINATIONBODY BODY_Script
                    TTObjectContext tto = this.ParentReport.ReportObjectContext;
                    Guid reportid = new Guid(this.MyParentReport.RuntimeParameters.TTOBJECTID.ToString());
                    ForensicMedicalReport rapor = (ForensicMedicalReport)tto.GetObject(reportid, typeof(ForensicMedicalReport));
                    
                     if (rapor.CentralNervousSystem.HasValue)
                        {
                            if (rapor.CentralNervousSystem.Value) this.MerkeziSinirSis.CalcValue = "X";
                        }
                        if (rapor.CardiovascularSystem.HasValue)
                        {
                            if (rapor.CardiovascularSystem.Value) this.KalpDamarSis.CalcValue = "X";
                        }
                        if (rapor.RespiratorySys.HasValue)
                        {
                            if (rapor.RespiratorySys.Value) this.SolunumSis.CalcValue = "X";
                        }
                        if (rapor.DigestiveSys.HasValue)
                        {
                            if (rapor.DigestiveSys.Value) this.SindirimSis.CalcValue = "X";
                        }
                        if (rapor.UrogenitalSys.HasValue)
                        {
                            if (rapor.UrogenitalSys.Value) this.UrogenitalSis.CalcValue = "X";
                        }
                        if (rapor.SkeletalSys.HasValue)
                        {
                            if (rapor.SkeletalSys.Value) this.KasIskeletSis.CalcValue = "X";
                        }
                        if (rapor.SensoryOrgansSys.HasValue)
                        {
                            if (rapor.SensoryOrgansSys.Value) this.DuyuOrganlarıSis.CalcValue = "X";
                        }
#endregion SYSTEMEXAMINATIONBODY BODY_Script
                }
            }

        }

        public SYSTEMEXAMINATIONBODYGroup SYSTEMEXAMINATIONBODY;

        public partial class PSYCHIATRYGroup : TTReportGroup
        {
            public TemporaryForensicReport MyParentReport
            {
                get { return (TemporaryForensicReport)ParentReport; }
            }

            new public PSYCHIATRYGroupHeader Header()
            {
                return (PSYCHIATRYGroupHeader)_header;
            }

            new public PSYCHIATRYGroupFooter Footer()
            {
                return (PSYCHIATRYGroupFooter)_footer;
            }

            public TTReportField NewField1471 { get {return Header().NewField1471;} }
            public TTReportField NewField1481 { get {return Header().NewField1481;} }
            public TTReportShape NewLine111011 { get {return Header().NewLine111011;} }
            public PSYCHIATRYGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PSYCHIATRYGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PSYCHIATRYGroupHeader(this);
                _footer = new PSYCHIATRYGroupFooter(this);

            }

            public partial class PSYCHIATRYGroupHeader : TTReportSection
            {
                public TemporaryForensicReport MyParentReport
                {
                    get { return (TemporaryForensicReport)ParentReport; }
                }
                
                public TTReportField NewField1471;
                public TTReportField NewField1481;
                public TTReportShape NewLine111011; 
                public PSYCHIATRYGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 11;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1471 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 0, 67, 8, false);
                    NewField1471.Name = "NewField1471";
                    NewField1471.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1471.TextFont.Bold = true;
                    NewField1471.TextFont.CharSet = 162;
                    NewField1471.Value = @"PSİKİYATRİK MUAYENE";

                    NewField1481 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 2, 202, 6, false);
                    NewField1481.Name = "NewField1481";
                    NewField1481.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1481.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1481.TextFont.Size = 9;
                    NewField1481.TextFont.CharSet = 162;
                    NewField1481.Value = @"Tespit edilen diğer bulgularla ilgili sistemi işaretleyiniz ve bulguları belirtiniz.";

                    NewLine111011 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, 7, 67, 7, false);
                    NewLine111011.Name = "NewLine111011";
                    NewLine111011.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1471.CalcValue = NewField1471.Value;
                    NewField1481.CalcValue = NewField1481.Value;
                    return new TTReportObject[] { NewField1471,NewField1481};
                }
            }
            public partial class PSYCHIATRYGroupFooter : TTReportSection
            {
                public TemporaryForensicReport MyParentReport
                {
                    get { return (TemporaryForensicReport)ParentReport; }
                }
                 
                public PSYCHIATRYGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PSYCHIATRYGroup PSYCHIATRY;

        public partial class PSYCHIATRYBODYGroup : TTReportGroup
        {
            public TemporaryForensicReport MyParentReport
            {
                get { return (TemporaryForensicReport)ParentReport; }
            }

            new public PSYCHIATRYBODYGroupBody Body()
            {
                return (PSYCHIATRYBODYGroupBody)_body;
            }
            public TTReportField NewField11 { get {return Body().NewField11;} }
            public TTReportField PsikoBulguYok { get {return Body().PsikoBulguYok;} }
            public TTReportField NewField13 { get {return Body().NewField13;} }
            public TTReportField PsikoMuayene { get {return Body().PsikoMuayene;} }
            public TTReportField NewField15 { get {return Body().NewField15;} }
            public TTReportField PsikiyatriKonsultasyon { get {return Body().PsikiyatriKonsultasyon;} }
            public TTReportField NewField17 { get {return Body().NewField17;} }
            public PSYCHIATRYBODYGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PSYCHIATRYBODYGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new PSYCHIATRYBODYGroupBody(this);
            }

            public partial class PSYCHIATRYBODYGroupBody : TTReportSection
            {
                public TemporaryForensicReport MyParentReport
                {
                    get { return (TemporaryForensicReport)ParentReport; }
                }
                
                public TTReportField NewField11;
                public TTReportField PsikoBulguYok;
                public TTReportField NewField13;
                public TTReportField PsikoMuayene;
                public TTReportField NewField15;
                public TTReportField PsikiyatriKonsultasyon;
                public TTReportField NewField17; 
                public PSYCHIATRYBODYGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    RepeatCount = 0;
                    
                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 10, 77, 15, false);
                    NewField11.Name = "NewField11";
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"Temel psikiyatrik muayene yapıldı";

                    PsikoBulguYok = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 83, 0, 88, 5, false);
                    PsikoBulguYok.Name = "PsikoBulguYok";
                    PsikoBulguYok.DrawStyle = DrawStyleConstants.vbSolid;
                    PsikoBulguYok.Value = @"";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 89, 1, 202, 6, false);
                    NewField13.Name = "NewField13";
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @"Belirgin bir psikopatolojik bulgu saptanmadı.";

                    PsikoMuayene = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 83, 9, 88, 14, false);
                    PsikoMuayene.Name = "PsikoMuayene";
                    PsikoMuayene.DrawStyle = DrawStyleConstants.vbSolid;
                    PsikoMuayene.Value = @"";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 89, 10, 202, 15, false);
                    NewField15.Name = "NewField15";
                    NewField15.TextFont.CharSet = 162;
                    NewField15.Value = @"Ayrıntılı psikiyatrik muayenye gerek duyuldu.";

                    PsikiyatriKonsultasyon = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 83, 19, 88, 24, false);
                    PsikiyatriKonsultasyon.Name = "PsikiyatriKonsultasyon";
                    PsikiyatriKonsultasyon.DrawStyle = DrawStyleConstants.vbSolid;
                    PsikiyatriKonsultasyon.Value = @"";

                    NewField17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 89, 20, 202, 25, false);
                    NewField17.Name = "NewField17";
                    NewField17.TextFont.CharSet = 162;
                    NewField17.Value = @"Psikiyatri konsültasyonu istendi.";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField11.CalcValue = NewField11.Value;
                    PsikoBulguYok.CalcValue = PsikoBulguYok.Value;
                    NewField13.CalcValue = NewField13.Value;
                    PsikoMuayene.CalcValue = PsikoMuayene.Value;
                    NewField15.CalcValue = NewField15.Value;
                    PsikiyatriKonsultasyon.CalcValue = PsikiyatriKonsultasyon.Value;
                    NewField17.CalcValue = NewField17.Value;
                    return new TTReportObject[] { NewField11,PsikoBulguYok,NewField13,PsikoMuayene,NewField15,PsikiyatriKonsultasyon,NewField17};
                }

                public override void RunScript()
                {
#region PSYCHIATRYBODY BODY_Script
                    TTObjectContext tto = this.ParentReport.ReportObjectContext;
                    Guid reportid = new Guid(this.MyParentReport.RuntimeParameters.TTOBJECTID.ToString());
                    ForensicMedicalReport rapor = (ForensicMedicalReport)tto.GetObject(reportid, typeof(ForensicMedicalReport));
                    
                     if (rapor.NoEvidancePsycho.HasValue)
                        {
                            if (rapor.NoEvidancePsycho.Value) this.PsikoBulguYok.CalcValue = "X";
                        }
                        if (rapor.PyschiatricExamination.HasValue)
                        {
                            if (rapor.PyschiatricExamination.Value) this.PsikoMuayene.CalcValue = "X";
                        }
                        if (rapor.PsychiatricConsultation.HasValue)
                        {
                            if (rapor.PsychiatricConsultation.Value) this.PsikiyatriKonsultasyon.CalcValue = "X";
                        }
#endregion PSYCHIATRYBODY BODY_Script
                }
            }

        }

        public PSYCHIATRYBODYGroup PSYCHIATRYBODY;

        public partial class TESTSGroup : TTReportGroup
        {
            public TemporaryForensicReport MyParentReport
            {
                get { return (TemporaryForensicReport)ParentReport; }
            }

            new public TESTSGroupHeader Header()
            {
                return (TESTSGroupHeader)_header;
            }

            new public TESTSGroupFooter Footer()
            {
                return (TESTSGroupFooter)_footer;
            }

            public TTReportField NewField11741 { get {return Header().NewField11741;} }
            public TTReportField NewField11841 { get {return Header().NewField11841;} }
            public TTReportShape NewLine1121 { get {return Header().NewLine1121;} }
            public TESTSGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public TESTSGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new TESTSGroupHeader(this);
                _footer = new TESTSGroupFooter(this);

            }

            public partial class TESTSGroupHeader : TTReportSection
            {
                public TemporaryForensicReport MyParentReport
                {
                    get { return (TemporaryForensicReport)ParentReport; }
                }
                
                public TTReportField NewField11741;
                public TTReportField NewField11841;
                public TTReportShape NewLine1121; 
                public TESTSGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 12;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField11741 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 2, 67, 10, false);
                    NewField11741.Name = "NewField11741";
                    NewField11741.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11741.TextFont.Size = 11;
                    NewField11741.TextFont.Bold = true;
                    NewField11741.TextFont.CharSet = 162;
                    NewField11741.Value = @"TETKİKLER";

                    NewField11841 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 4, 202, 8, false);
                    NewField11841.Name = "NewField11841";
                    NewField11841.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11841.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11841.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11841.TextFont.Size = 9;
                    NewField11841.TextFont.CharSet = 162;
                    NewField11841.Value = @"İstediğiniz tetkikleri işaretleyerek sonuçları yazınız.";

                    NewLine1121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, 1, 202, 1, false);
                    NewLine1121.Name = "NewLine1121";
                    NewLine1121.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField11741.CalcValue = NewField11741.Value;
                    NewField11841.CalcValue = NewField11841.Value;
                    return new TTReportObject[] { NewField11741,NewField11841};
                }
            }
            public partial class TESTSGroupFooter : TTReportSection
            {
                public TemporaryForensicReport MyParentReport
                {
                    get { return (TemporaryForensicReport)ParentReport; }
                }
                 
                public TESTSGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public TESTSGroup TESTS;

        public partial class TESTSBODYGroup : TTReportGroup
        {
            public TemporaryForensicReport MyParentReport
            {
                get { return (TemporaryForensicReport)ParentReport; }
            }

            new public TESTSBODYGroupBody Body()
            {
                return (TESTSBODYGroupBody)_body;
            }
            public TTReportRTF LabReport { get {return Body().LabReport;} }
            public TESTSBODYGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public TESTSBODYGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new TESTSBODYGroupBody(this);
            }

            public partial class TESTSBODYGroupBody : TTReportSection
            {
                public TemporaryForensicReport MyParentReport
                {
                    get { return (TemporaryForensicReport)ParentReport; }
                }
                
                public TTReportRTF LabReport; 
                public TESTSBODYGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 10;
                    RepeatCount = 0;
                    
                    LabReport = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 11, -1, 202, 8, false);
                    LabReport.Name = "LabReport";
                    LabReport.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    LabReport.CalcValue = LabReport.Value;
                    return new TTReportObject[] { LabReport};
                }
                public override void RunPreScript()
                {
#region TESTSBODY BODY_PreScript
                    TTObjectContext context = this.ParentReport.ReportObjectContext;
            string sObjectID = ((TemporaryForensicReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            ForensicMedicalReport forensicMedicalReport = (ForensicMedicalReport)context.GetObject(new Guid(sObjectID),"ForensicMedicalReport");
           
            if(forensicMedicalReport.LaboratoryProcedures != null)
                this.LabReport.Value = forensicMedicalReport.LaboratoryProcedures.ToString();
            
            /* Sonra bakılacak
            //Menüye(Tetkik İşlem Türüne) göre seçilmiş tetkiklerin isimlerini getirir
            string procedureDefNames="";
            List<ProcedureDefinition> procedureDefList = new List<ProcedureDefinition>();
            List<Guid> procedureDefGuidList = new List<Guid>();
            foreach(ForensicReportLabMenuGrid menu in forensicMedicalReport.LabMenus)
            {
                string objectDefName = menu.MenuDefinition.ObjectDefinitionName.ToUpperInvariant();
                TTObjectDef objDef=null;
                TTObjectDefManager.Instance.ObjectDefs.TryGetValue(objectDefName,out objDef) ;
                if (objDef!=null){
                    if (objDef.IsOfType(typeof(EpisodeAction).Name.ToUpperInvariant())){
                        foreach(TTObjectRelationSubtypeDef rSubType in objDef.AllChildRelationsSubtypeDefs){
                            if (rSubType.RelationDef.ParentObjectDef.IsOfType(typeof(EpisodeAction).Name.ToUpperInvariant()) && rSubType.RelationDef.ChildObjectDef.IsOfType(typeof(SubActionProcedure).Name.ToUpperInvariant()))
                            {
                                if(rSubType.ChildObjectDef.AllParentRelationDefs["ProcedureObject"].ParentObjectDef.Name.ToUpperInvariant()!="PROCEDUREDEFINITION"){
                                    procedureDefGuidList.Add(rSubType.ChildObjectDef.AllParentRelationDefs["ProcedureObject"].ParentObjectDef.ID);
                                    if(procedureDefNames!="")
                                    {
                                        procedureDefNames=procedureDefNames + "," ;
                                    }
                                    procedureDefNames = procedureDefNames + "'" + rSubType.ChildObjectDef.AllParentRelationDefs["ProcedureObject"].ParentObjectDef.Name.ToUpperInvariant() + "'";
                                }
                            }
                        }
                    }
                }
                
                BindingList<ProcedureDefinition.GetProcedureDefinitionListDefinition_Class> grids = ProcedureDefinition.GetProcedureDefinitionListDefinition(context," THIS.OBJECTDEFNAME IN(" + procedureDefNames + ")");
                foreach(ProcedureDefinition.GetProcedureDefinitionListDefinition_Class procedureDefinition in grids)
                {

                }
            }
            */
#endregion TESTSBODY BODY_PreScript
                }
            }

        }

        public TESTSBODYGroup TESTSBODY;

        public partial class CONSULTATIONREPORTSGroup : TTReportGroup
        {
            public TemporaryForensicReport MyParentReport
            {
                get { return (TemporaryForensicReport)ParentReport; }
            }

            new public CONSULTATIONREPORTSGroupHeader Header()
            {
                return (CONSULTATIONREPORTSGroupHeader)_header;
            }

            new public CONSULTATIONREPORTSGroupFooter Footer()
            {
                return (CONSULTATIONREPORTSGroupFooter)_footer;
            }

            public TTReportField NewField131 { get {return Header().NewField131;} }
            public TTReportField NewField151 { get {return Header().NewField151;} }
            public TTReportShape NewLine111211 { get {return Header().NewLine111211;} }
            public CONSULTATIONREPORTSGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public CONSULTATIONREPORTSGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new CONSULTATIONREPORTSGroupHeader(this);
                _footer = new CONSULTATIONREPORTSGroupFooter(this);

            }

            public partial class CONSULTATIONREPORTSGroupHeader : TTReportSection
            {
                public TemporaryForensicReport MyParentReport
                {
                    get { return (TemporaryForensicReport)ParentReport; }
                }
                
                public TTReportField NewField131;
                public TTReportField NewField151;
                public TTReportShape NewLine111211; 
                public CONSULTATIONREPORTSGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 20;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 1, 135, 9, false);
                    NewField131.Name = "NewField131";
                    NewField131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField131.TextFont.Size = 11;
                    NewField131.TextFont.Bold = true;
                    NewField131.TextFont.CharSet = 162;
                    NewField131.Value = @"EKLENEN KONSÜLTASYON RAPORLARI VE TIBBİ BELGE ÖRNEKLERİ";

                    NewField151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 9, 202, 17, false);
                    NewField151.Name = "NewField151";
                    NewField151.MultiLine = EvetHayirEnum.ehEvet;
                    NewField151.WordBreak = EvetHayirEnum.ehEvet;
                    NewField151.TextFont.Size = 9;
                    NewField151.TextFont.CharSet = 162;
                    NewField151.Value = @"Varsa Rapora eklenen Vücut Diyagramı, Konsültasyon Muayene Raporu, Psikiyatrik Muayene/Konsültasyon Raporu ve diğer tıbbî belge örneklerini belirtiniz.";

                    NewLine111211 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, 1, 202, 1, false);
                    NewLine111211.Name = "NewLine111211";
                    NewLine111211.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField131.CalcValue = NewField131.Value;
                    NewField151.CalcValue = NewField151.Value;
                    return new TTReportObject[] { NewField131,NewField151};
                }
            }
            public partial class CONSULTATIONREPORTSGroupFooter : TTReportSection
            {
                public TemporaryForensicReport MyParentReport
                {
                    get { return (TemporaryForensicReport)ParentReport; }
                }
                 
                public CONSULTATIONREPORTSGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public CONSULTATIONREPORTSGroup CONSULTATIONREPORTS;

        public partial class CONSULTATIONREPORTSBODYGroup : TTReportGroup
        {
            public TemporaryForensicReport MyParentReport
            {
                get { return (TemporaryForensicReport)ParentReport; }
            }

            new public CONSULTATIONREPORTSBODYGroupBody Body()
            {
                return (CONSULTATIONREPORTSBODYGroupBody)_body;
            }
            public TTReportShape NewLine1131 { get {return Body().NewLine1131;} }
            public TTReportField NewField1221 { get {return Body().NewField1221;} }
            public TTReportField DigerKonsultasyon { get {return Body().DigerKonsultasyon;} }
            public TTReportField NewField1101 { get {return Body().NewField1101;} }
            public TTReportField PsikiyatrikMuayeneKonsul { get {return Body().PsikiyatrikMuayeneKonsul;} }
            public TTReportField KonsultasyonRaporu { get {return Body().KonsultasyonRaporu;} }
            public TTReportField NewField1241 { get {return Body().NewField1241;} }
            public TTReportField VucutDiyagram { get {return Body().VucutDiyagram;} }
            public TTReportField NewField1161 { get {return Body().NewField1161;} }
            public TTReportField Aciklamalar12 { get {return Body().Aciklamalar12;} }
            public CONSULTATIONREPORTSBODYGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public CONSULTATIONREPORTSBODYGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new CONSULTATIONREPORTSBODYGroupBody(this);
            }

            public partial class CONSULTATIONREPORTSBODYGroupBody : TTReportSection
            {
                public TemporaryForensicReport MyParentReport
                {
                    get { return (TemporaryForensicReport)ParentReport; }
                }
                
                public TTReportShape NewLine1131;
                public TTReportField NewField1221;
                public TTReportField DigerKonsultasyon;
                public TTReportField NewField1101;
                public TTReportField PsikiyatrikMuayeneKonsul;
                public TTReportField KonsultasyonRaporu;
                public TTReportField NewField1241;
                public TTReportField VucutDiyagram;
                public TTReportField NewField1161;
                public TTReportField Aciklamalar12; 
                public CONSULTATIONREPORTSBODYGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 22;
                    RepeatCount = 0;
                    
                    NewLine1131 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, 21, 202, 21, false);
                    NewLine1131.Name = "NewLine1131";
                    NewLine1131.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField1221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 7, 115, 11, false);
                    NewField1221.Name = "NewField1221";
                    NewField1221.TextFont.CharSet = 162;
                    NewField1221.Value = @"Psikiyatrik muayene / konsültasyon Raporu (... Sayfa)";

                    DigerKonsultasyon = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 117, 2, 121, 6, false);
                    DigerKonsultasyon.Name = "DigerKonsultasyon";
                    DigerKonsultasyon.DrawStyle = DrawStyleConstants.vbSolid;
                    DigerKonsultasyon.TextFont.CharSet = 162;
                    DigerKonsultasyon.Value = @"";

                    NewField1101 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 122, 2, 202, 6, false);
                    NewField1101.Name = "NewField1101";
                    NewField1101.TextFont.CharSet = 162;
                    NewField1101.Value = @"Diğer Numaralandırarak sırayla belirtiniz";

                    PsikiyatrikMuayeneKonsul = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 7, 15, 11, false);
                    PsikiyatrikMuayeneKonsul.Name = "PsikiyatrikMuayeneKonsul";
                    PsikiyatrikMuayeneKonsul.DrawStyle = DrawStyleConstants.vbSolid;
                    PsikiyatrikMuayeneKonsul.TextFont.CharSet = 162;
                    PsikiyatrikMuayeneKonsul.Value = @"";

                    KonsultasyonRaporu = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 13, 15, 17, false);
                    KonsultasyonRaporu.Name = "KonsultasyonRaporu";
                    KonsultasyonRaporu.DrawStyle = DrawStyleConstants.vbSolid;
                    KonsultasyonRaporu.TextFont.CharSet = 162;
                    KonsultasyonRaporu.Value = @"";

                    NewField1241 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 13, 115, 17, false);
                    NewField1241.Name = "NewField1241";
                    NewField1241.TextFont.CharSet = 162;
                    NewField1241.Value = @"..................... Konsültasyon Raporu (... Sayfa)";

                    VucutDiyagram = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 1, 15, 5, false);
                    VucutDiyagram.Name = "VucutDiyagram";
                    VucutDiyagram.DrawStyle = DrawStyleConstants.vbSolid;
                    VucutDiyagram.TextFont.CharSet = 162;
                    VucutDiyagram.Value = @"";

                    NewField1161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 1, 45, 5, false);
                    NewField1161.Name = "NewField1161";
                    NewField1161.TextFont.CharSet = 162;
                    NewField1161.Value = @"Vücut Diyagramı";

                    Aciklamalar12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 117, 8, 202, 19, false);
                    Aciklamalar12.Name = "Aciklamalar12";
                    Aciklamalar12.FieldType = ReportFieldTypeEnum.ftVariable;
                    Aciklamalar12.TextFont.CharSet = 162;
                    Aciklamalar12.Value = @"{#HEADER.ATTACHES5#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ForensicMedicalReport.GetForensicMedicalReport_Class dataset_GetForensicMedicalReport = MyParentReport.HEADER.rsGroup.GetCurrentRecord<ForensicMedicalReport.GetForensicMedicalReport_Class>(0);
                    NewField1221.CalcValue = NewField1221.Value;
                    DigerKonsultasyon.CalcValue = DigerKonsultasyon.Value;
                    NewField1101.CalcValue = NewField1101.Value;
                    PsikiyatrikMuayeneKonsul.CalcValue = PsikiyatrikMuayeneKonsul.Value;
                    KonsultasyonRaporu.CalcValue = KonsultasyonRaporu.Value;
                    NewField1241.CalcValue = NewField1241.Value;
                    VucutDiyagram.CalcValue = VucutDiyagram.Value;
                    NewField1161.CalcValue = NewField1161.Value;
                    Aciklamalar12.CalcValue = (dataset_GetForensicMedicalReport != null ? Globals.ToStringCore(dataset_GetForensicMedicalReport.Attaches5) : "");
                    return new TTReportObject[] { NewField1221,DigerKonsultasyon,NewField1101,PsikiyatrikMuayeneKonsul,KonsultasyonRaporu,NewField1241,VucutDiyagram,NewField1161,Aciklamalar12};
                }

                public override void RunScript()
                {
#region CONSULTATIONREPORTSBODY BODY_Script
                    TTObjectContext tto = this.ParentReport.ReportObjectContext;
                    Guid reportid = new Guid(this.MyParentReport.RuntimeParameters.TTOBJECTID.ToString());
                    ForensicMedicalReport rapor = (ForensicMedicalReport)tto.GetObject(reportid, typeof(ForensicMedicalReport));
                   
                    if (rapor.Attaches1.HasValue)
                        {
                            if (rapor.Attaches1.Value) this.VucutDiyagram.CalcValue = "X";
                        }
                     if (rapor.Attaches2.HasValue)
                     {
                         if (rapor.Attaches2.Value) this.PsikiyatrikMuayeneKonsul.CalcValue = "X";
                     }
                     if (rapor.Attaches3.HasValue)
                     {
                         if (rapor.Attaches3.Value) this.KonsultasyonRaporu.CalcValue = "X";
                     }
                     if (rapor.Attaches4.HasValue)
                     {
                         if (rapor.Attaches4.Value) this.DigerKonsultasyon.CalcValue = "X";
                     }
#endregion CONSULTATIONREPORTSBODY BODY_Script
                }
            }

        }

        public CONSULTATIONREPORTSBODYGroup CONSULTATIONREPORTSBODY;

        public partial class RESULTGroup : TTReportGroup
        {
            public TemporaryForensicReport MyParentReport
            {
                get { return (TemporaryForensicReport)ParentReport; }
            }

            new public RESULTGroupHeader Header()
            {
                return (RESULTGroupHeader)_header;
            }

            new public RESULTGroupFooter Footer()
            {
                return (RESULTGroupFooter)_footer;
            }

            public TTReportField NewField161 { get {return Header().NewField161;} }
            public TTReportField NewField181 { get {return Header().NewField181;} }
            public TTReportShape NewLine11 { get {return Footer().NewLine11;} }
            public TTReportField SINRUT1 { get {return Footer().SINRUT1;} }
            public TTReportField NewField11321 { get {return Footer().NewField11321;} }
            public TTReportField NewField151 { get {return Footer().NewField151;} }
            public TTReportField NewField111111721 { get {return Footer().NewField111111721;} }
            public TTReportField TITLE_RANK_NAME_SURNAME { get {return Footer().TITLE_RANK_NAME_SURNAME;} }
            public TTReportField DIPLOMANO { get {return Footer().DIPLOMANO;} }
            public TTReportField NewField162 { get {return Footer().NewField162;} }
            public TTReportField DIPLOMAREGISTERNO { get {return Footer().DIPLOMAREGISTERNO;} }
            public TTReportField BASTABIB { get {return Footer().BASTABIB;} }
            public TTReportField NewField1 { get {return Footer().NewField1;} }
            public TTReportField BASTABIBID { get {return Footer().BASTABIBID;} }
            public TTReportField NewField153 { get {return Footer().NewField153;} }
            public TTReportField DIPLOMANO2 { get {return Footer().DIPLOMANO2;} }
            public TTReportField DTesNu { get {return Footer().DTesNu;} }
            public TTReportField DIPLOMAREGISTERNO2 { get {return Footer().DIPLOMAREGISTERNO2;} }
            public RESULTGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public RESULTGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new RESULTGroupHeader(this);
                _footer = new RESULTGroupFooter(this);

            }

            public partial class RESULTGroupHeader : TTReportSection
            {
                public TemporaryForensicReport MyParentReport
                {
                    get { return (TemporaryForensicReport)ParentReport; }
                }
                
                public TTReportField NewField161;
                public TTReportField NewField181; 
                public RESULTGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 16;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 1, 67, 9, false);
                    NewField161.Name = "NewField161";
                    NewField161.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField161.TextFont.Size = 11;
                    NewField161.TextFont.Bold = true;
                    NewField161.TextFont.CharSet = 162;
                    NewField161.Value = @"SONUÇ";

                    NewField181 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 1, 202, 14, false);
                    NewField181.Name = "NewField181";
                    NewField181.MultiLine = EvetHayirEnum.ehEvet;
                    NewField181.WordBreak = EvetHayirEnum.ehEvet;
                    NewField181.TextFont.Size = 9;
                    NewField181.TextFont.CharSet = 162;
                    NewField181.Value = @"Bu kısmı, Genelge ve Rehberde belirtilen hususları dikkate alarak doldurunuz. Tıbbî terimleri kısaltma yapmadan tam olarak yazınız. Boş kalan kısımları çizerek iptal ediniz. 
Talep edilmişse veya gerek görülmüşse, kişinin ALKOL MUAYENESİ sonucunu bu kısımda belirtiniz.";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField161.CalcValue = NewField161.Value;
                    NewField181.CalcValue = NewField181.Value;
                    return new TTReportObject[] { NewField161,NewField181};
                }
            }
            public partial class RESULTGroupFooter : TTReportSection
            {
                public TemporaryForensicReport MyParentReport
                {
                    get { return (TemporaryForensicReport)ParentReport; }
                }
                
                public TTReportShape NewLine11;
                public TTReportField SINRUT1;
                public TTReportField NewField11321;
                public TTReportField NewField151;
                public TTReportField NewField111111721;
                public TTReportField TITLE_RANK_NAME_SURNAME;
                public TTReportField DIPLOMANO;
                public TTReportField NewField162;
                public TTReportField DIPLOMAREGISTERNO;
                public TTReportField BASTABIB;
                public TTReportField NewField1;
                public TTReportField BASTABIBID;
                public TTReportField NewField153;
                public TTReportField DIPLOMANO2;
                public TTReportField DTesNu;
                public TTReportField DIPLOMAREGISTERNO2; 
                public RESULTGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 39;
                    RepeatCount = 0;
                    
                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 12, 1, 183, 2, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.ForeColor = System.Drawing.Color.White;
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                    SINRUT1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 12, 62, 16, false);
                    SINRUT1.Name = "SINRUT1";
                    SINRUT1.FieldType = ReportFieldTypeEnum.ftVariable;
                    SINRUT1.TextFont.CharSet = 162;
                    SINRUT1.Value = @"";

                    NewField11321 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 5, 203, 16, false);
                    NewField11321.Name = "NewField11321";
                    NewField11321.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11321.TextFont.Size = 11;
                    NewField11321.TextFont.Bold = true;
                    NewField11321.TextFont.CharSet = 162;
                    NewField11321.Value = @"MUAYENEYİ YAPAN VE RAPORU DÜZENLEYEN TABİP";

                    NewField151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 27, 66, 32, false);
                    NewField151.Name = "NewField151";
                    NewField151.MultiLine = EvetHayirEnum.ehEvet;
                    NewField151.TextFont.Size = 8;
                    NewField151.TextFont.Bold = true;
                    NewField151.TextFont.CharSet = 162;
                    NewField151.Value = @"D.Nu.      :";

                    NewField111111721 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 17, 66, 22, false);
                    NewField111111721.Name = "NewField111111721";
                    NewField111111721.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111111721.TextFont.Size = 8;
                    NewField111111721.TextFont.Bold = true;
                    NewField111111721.TextFont.CharSet = 162;
                    NewField111111721.Value = @"TABİP KAŞESİ (ISLAK İMZA)";

                    TITLE_RANK_NAME_SURNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 22, 66, 27, false);
                    TITLE_RANK_NAME_SURNAME.Name = "TITLE_RANK_NAME_SURNAME";
                    TITLE_RANK_NAME_SURNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    TITLE_RANK_NAME_SURNAME.TextFont.Size = 8;
                    TITLE_RANK_NAME_SURNAME.TextFont.CharSet = 162;
                    TITLE_RANK_NAME_SURNAME.Value = @"";

                    DIPLOMANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 27, 27, 66, 33, false);
                    DIPLOMANO.Name = "DIPLOMANO";
                    DIPLOMANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIPLOMANO.TextFont.Size = 8;
                    DIPLOMANO.TextFont.CharSet = 162;
                    DIPLOMANO.Value = @"{#HEADER.DIPNO#}";

                    NewField162 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 32, 66, 37, false);
                    NewField162.Name = "NewField162";
                    NewField162.TextFont.Size = 8;
                    NewField162.TextFont.Bold = true;
                    NewField162.TextFont.CharSet = 162;
                    NewField162.Value = @"D.Tes.Nu.:";

                    DIPLOMAREGISTERNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 27, 32, 66, 37, false);
                    DIPLOMAREGISTERNO.Name = "DIPLOMAREGISTERNO";
                    DIPLOMAREGISTERNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIPLOMAREGISTERNO.TextFont.Size = 8;
                    DIPLOMAREGISTERNO.TextFont.CharSet = 162;
                    DIPLOMAREGISTERNO.Value = @"{#HEADER.DIPREGNO#}";

                    BASTABIB = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 24, 281, 29, false);
                    BASTABIB.Name = "BASTABIB";
                    BASTABIB.Visible = EvetHayirEnum.ehHayir;
                    BASTABIB.Value = @"";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 138, 17, 202, 22, false);
                    NewField1.Name = "NewField1";
                    NewField1.TextFont.Size = 8;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"BAŞTABİP (ISLAK İMZA)";

                    BASTABIBID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 237, 17, 262, 22, false);
                    BASTABIBID.Name = "BASTABIBID";
                    BASTABIBID.Visible = EvetHayirEnum.ehHayir;
                    BASTABIBID.Value = @"";

                    NewField153 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 29, 272, 34, false);
                    NewField153.Name = "NewField153";
                    NewField153.Visible = EvetHayirEnum.ehHayir;
                    NewField153.MultiLine = EvetHayirEnum.ehEvet;
                    NewField153.TextFont.Size = 8;
                    NewField153.TextFont.Bold = true;
                    NewField153.TextFont.CharSet = 162;
                    NewField153.Value = @"D.Nu.      :";

                    DIPLOMANO2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 233, 29, 272, 35, false);
                    DIPLOMANO2.Name = "DIPLOMANO2";
                    DIPLOMANO2.Visible = EvetHayirEnum.ehHayir;
                    DIPLOMANO2.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIPLOMANO2.TextFont.Size = 8;
                    DIPLOMANO2.TextFont.CharSet = 162;
                    DIPLOMANO2.Value = @"";

                    DTesNu = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 34, 272, 39, false);
                    DTesNu.Name = "DTesNu";
                    DTesNu.Visible = EvetHayirEnum.ehHayir;
                    DTesNu.TextFont.Size = 8;
                    DTesNu.TextFont.Bold = true;
                    DTesNu.TextFont.CharSet = 162;
                    DTesNu.Value = @"D.Tes.Nu.:";

                    DIPLOMAREGISTERNO2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 233, 34, 272, 39, false);
                    DIPLOMAREGISTERNO2.Name = "DIPLOMAREGISTERNO2";
                    DIPLOMAREGISTERNO2.Visible = EvetHayirEnum.ehHayir;
                    DIPLOMAREGISTERNO2.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIPLOMAREGISTERNO2.TextFont.Size = 8;
                    DIPLOMAREGISTERNO2.TextFont.CharSet = 162;
                    DIPLOMAREGISTERNO2.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ForensicMedicalReport.GetForensicMedicalReport_Class dataset_GetForensicMedicalReport = MyParentReport.HEADER.rsGroup.GetCurrentRecord<ForensicMedicalReport.GetForensicMedicalReport_Class>(0);
                    SINRUT1.CalcValue = @"";
                    NewField11321.CalcValue = NewField11321.Value;
                    NewField151.CalcValue = NewField151.Value;
                    NewField111111721.CalcValue = NewField111111721.Value;
                    TITLE_RANK_NAME_SURNAME.CalcValue = @"";
                    DIPLOMANO.CalcValue = (dataset_GetForensicMedicalReport != null ? Globals.ToStringCore(dataset_GetForensicMedicalReport.Dipno) : "");
                    NewField162.CalcValue = NewField162.Value;
                    DIPLOMAREGISTERNO.CalcValue = (dataset_GetForensicMedicalReport != null ? Globals.ToStringCore(dataset_GetForensicMedicalReport.Dipregno) : "");
                    BASTABIB.CalcValue = BASTABIB.Value;
                    NewField1.CalcValue = NewField1.Value;
                    BASTABIBID.CalcValue = BASTABIBID.Value;
                    NewField153.CalcValue = NewField153.Value;
                    DIPLOMANO2.CalcValue = @"";
                    DTesNu.CalcValue = DTesNu.Value;
                    DIPLOMAREGISTERNO2.CalcValue = @"";
                    return new TTReportObject[] { SINRUT1,NewField11321,NewField151,NewField111111721,TITLE_RANK_NAME_SURNAME,DIPLOMANO,NewField162,DIPLOMAREGISTERNO,BASTABIB,NewField1,BASTABIBID,NewField153,DIPLOMANO2,DTesNu,DIPLOMAREGISTERNO2};
                }

                public override void RunScript()
                {
#region RESULT FOOTER_Script
                    TTObjectContext tto = this.ParentReport.ReportObjectContext;
                    ForensicMedicalReport rapor = (ForensicMedicalReport)tto.GetObject(new Guid(this.MyParentReport.RuntimeParameters.TTOBJECTID.ToString()), typeof(ForensicMedicalReport));
                    //this.TITLE_RANK_NAME_SURNAME.CalcValue = TTObjectClasses.Common.GetEnumValueDefOfEnumValue(rapor.ProcedureDoctor.Title.Value).DisplayText + " " + rapor.ProcedureDoctor.Rank.ToString() + " " + rapor.ProcedureDoctor.Name;
                    this.TITLE_RANK_NAME_SURNAME.CalcValue = "";
                    this.TITLE_RANK_NAME_SURNAME.CalcValue += ((rapor.ProcedureDoctor!= null && rapor.ProcedureDoctor.Title != null && rapor.ProcedureDoctor.Title.HasValue) ? TTObjectClasses.Common.GetEnumValueDefOfEnumValue(rapor.ProcedureDoctor.Title.Value) + " " : "");
                    this.TITLE_RANK_NAME_SURNAME.CalcValue += (rapor.ProcedureDoctor != null && rapor.ProcedureDoctor.Rank != null) ? rapor.ProcedureDoctor.Rank.Name + " " : "";
                    this.TITLE_RANK_NAME_SURNAME.CalcValue += (rapor.ProcedureDoctor != null && rapor.ProcedureDoctor.Name != null) ? rapor.ProcedureDoctor.Name : "";
                   //                    if (rapor.ForensicMedicalReportType != null && rapor.ForensicMedicalReportType.HasValue)
//                        {
//                            if (rapor.ForensicMedicalReportType.Value == ForensicMedicalReportTypeEnum.Certain)
//                             {
////                                string signatureBlock = "";
////
////                                signatureBlock += TTObjectClasses.SystemParameter.GetParameterValue("HEADDOCTORTITAL", "").ToString() + " " + "\n\r";
////                                signatureBlock += TTObjectClasses.SystemParameter.GetParameterValue("HEADDOCTOR", "").ToString() + "\n\r";
////                                this.BASTABIB.CalcValue = signatureBlock;
////                                this.BASTABIBID.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HEADDOCTOR_OBJECTID", "").ToString();
////                                IBindingList resUserList = ResUser.GetResUserByObjectID(tto, this.BASTABIBID.CalcValue);
////                                foreach (ResUser resUser in resUserList)
////                                {
////                                    this.DIPLOMANO2.CalcValue =(((ResUser)resUser).DiplomaNo != null) ? ((ResUser)resUser).DiplomaNo +" " :"";
////                                    this.DIPLOMAREGISTERNO2.CalcValue =  (((ResUser)resUser).DiplomaRegisterNo != null) ? ((ResUser)resUser).DiplomaRegisterNo +" ":"";
////                                }
//                            }
//                            else
//                            {
////                                this.BASTABIB.Visible = EvetHayirEnum.ehHayir;
////                                this.DIPLOMANO2.Visible = EvetHayirEnum.ehHayir;
////                                this.DIPLOMAREGISTERNO2.Visible = EvetHayirEnum.ehHayir;
//                                this.NewField1.Visible = EvetHayirEnum.ehHayir;
////                                this.NewField153.Visible = EvetHayirEnum.ehHayir;
////                                this.DTesNu.Visible = EvetHayirEnum.ehHayir;
//                            }
 
//                    }
                   
                   

//                this.SICILNO.CalcValue = "(" + pr.ProcedureDoctor.DiplomaRegisterNo + ")";
#endregion RESULT FOOTER_Script
                }
            }

        }

        public RESULTGroup RESULT;

        public partial class RESULTBODYGroup : TTReportGroup
        {
            public TemporaryForensicReport MyParentReport
            {
                get { return (TemporaryForensicReport)ParentReport; }
            }

            new public RESULTBODYGroupBody Body()
            {
                return (RESULTBODYGroupBody)_body;
            }
            public TTReportField NewField1281 { get {return Body().NewField1281;} }
            public TTReportField SevkeGereksiz { get {return Body().SevkeGereksiz;} }
            public TTReportField NewField1291 { get {return Body().NewField1291;} }
            public TTReportField SevkGerekli { get {return Body().SevkGerekli;} }
            public TTReportField NewField1311 { get {return Body().NewField1311;} }
            public TTReportField NewField1321 { get {return Body().NewField1321;} }
            public TTReportField SEVK { get {return Body().SEVK;} }
            public RESULTBODYGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public RESULTBODYGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new RESULTBODYGroupBody(this);
            }

            public partial class RESULTBODYGroupBody : TTReportSection
            {
                public TemporaryForensicReport MyParentReport
                {
                    get { return (TemporaryForensicReport)ParentReport; }
                }
                
                public TTReportField NewField1281;
                public TTReportField SevkeGereksiz;
                public TTReportField NewField1291;
                public TTReportField SevkGerekli;
                public TTReportField NewField1311;
                public TTReportField NewField1321;
                public TTReportField SEVK; 
                public RESULTBODYGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 20;
                    RepeatCount = 0;
                    
                    NewField1281 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 5, 77, 9, false);
                    NewField1281.Name = "NewField1281";
                    NewField1281.TextFont.CharSet = 162;
                    NewField1281.Value = @"Bir başka sağlık kuruluşuna sevkine";

                    SevkeGereksiz = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 79, 5, 83, 9, false);
                    SevkeGereksiz.Name = "SevkeGereksiz";
                    SevkeGereksiz.DrawStyle = DrawStyleConstants.vbSolid;
                    SevkeGereksiz.TextFont.CharSet = 162;
                    SevkeGereksiz.Value = @"";

                    NewField1291 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 84, 5, 114, 9, false);
                    NewField1291.Name = "NewField1291";
                    NewField1291.TextFont.CharSet = 162;
                    NewField1291.Value = @"Gerek görülmedi";

                    SevkGerekli = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 117, 5, 121, 9, false);
                    SevkGerekli.Name = "SevkGerekli";
                    SevkGerekli.DrawStyle = DrawStyleConstants.vbSolid;
                    SevkGerekli.TextFont.CharSet = 162;
                    SevkGerekli.Value = @"";

                    NewField1311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 122, 5, 147, 9, false);
                    NewField1311.Name = "NewField1311";
                    NewField1311.TextFont.CharSet = 162;
                    NewField1311.Value = @"Gerek görüldü";

                    NewField1321 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 147, 5, 202, 9, false);
                    NewField1321.Name = "NewField1321";
                    NewField1321.TextFont.Size = 9;
                    NewField1321.TextFont.CharSet = 162;
                    NewField1321.Value = @"(Gerekçesini aşağıda açıklayınız)";

                    SEVK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 11, 202, 18, false);
                    SEVK.Name = "SEVK";
                    SEVK.FieldType = ReportFieldTypeEnum.ftVariable;
                    SEVK.MultiLine = EvetHayirEnum.ehEvet;
                    SEVK.NoClip = EvetHayirEnum.ehEvet;
                    SEVK.WordBreak = EvetHayirEnum.ehEvet;
                    SEVK.ExpandTabs = EvetHayirEnum.ehEvet;
                    SEVK.Value = @"{#HEADER.SEVK#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ForensicMedicalReport.GetForensicMedicalReport_Class dataset_GetForensicMedicalReport = MyParentReport.HEADER.rsGroup.GetCurrentRecord<ForensicMedicalReport.GetForensicMedicalReport_Class>(0);
                    NewField1281.CalcValue = NewField1281.Value;
                    SevkeGereksiz.CalcValue = SevkeGereksiz.Value;
                    NewField1291.CalcValue = NewField1291.Value;
                    SevkGerekli.CalcValue = SevkGerekli.Value;
                    NewField1311.CalcValue = NewField1311.Value;
                    NewField1321.CalcValue = NewField1321.Value;
                    SEVK.CalcValue = (dataset_GetForensicMedicalReport != null ? Globals.ToStringCore(dataset_GetForensicMedicalReport.Sevk) : "");
                    return new TTReportObject[] { NewField1281,SevkeGereksiz,NewField1291,SevkGerekli,NewField1311,NewField1321,SEVK};
                }

                public override void RunScript()
                {
#region RESULTBODY BODY_Script
                    TTObjectContext tto = this.ParentReport.ReportObjectContext;
                    Guid reportid = new Guid(this.MyParentReport.RuntimeParameters.TTOBJECTID.ToString());
                    ForensicMedicalReport rapor = (ForensicMedicalReport)tto.GetObject(reportid, typeof(ForensicMedicalReport));
              if (rapor.NoNeed.HasValue)
                     {
                         if (rapor.NoNeed.Value) this.SevkeGereksiz.CalcValue = "X";
                     }
                      if (rapor.Need.HasValue)
                      {
                          if (rapor.Need.Value) this.SevkGerekli.CalcValue = "X";
                      }
#endregion RESULTBODY BODY_Script
                }
            }

        }

        public RESULTBODYGroup RESULTBODY;

        public partial class IMAGEGroup : TTReportGroup
        {
            public TemporaryForensicReport MyParentReport
            {
                get { return (TemporaryForensicReport)ParentReport; }
            }

            new public IMAGEGroupBody Body()
            {
                return (IMAGEGroupBody)_body;
            }
            public TTReportField NewField1114411 { get {return Body().NewField1114411;} }
            public TTReportRTF Report { get {return Body().Report;} }
            public TTReportShape NewLine1 { get {return Body().NewLine1;} }
            public IMAGEGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public IMAGEGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new IMAGEGroupBody(this);
            }

            public partial class IMAGEGroupBody : TTReportSection
            {
                public TemporaryForensicReport MyParentReport
                {
                    get { return (TemporaryForensicReport)ParentReport; }
                }
                
                public TTReportField NewField1114411;
                public TTReportRTF Report;
                public TTReportShape NewLine1; 
                public IMAGEGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 17;
                    RepeatCount = 0;
                    
                    NewField1114411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 1, 22, 7, false);
                    NewField1114411.Name = "NewField1114411";
                    NewField1114411.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1114411.TextFont.Bold = true;
                    NewField1114411.TextFont.CharSet = 162;
                    NewField1114411.Value = @"RAPOR";

                    Report = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 11, 8, 202, 17, false);
                    Report.Name = "Report";
                    Report.Value = @"";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, 7, 22, 7, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1114411.CalcValue = NewField1114411.Value;
                    Report.CalcValue = Report.Value;
                    return new TTReportObject[] { NewField1114411,Report};
                }
                public override void RunPreScript()
                {
#region IMAGE BODY_PreScript
                    TTObjectContext context = this.ParentReport.ReportObjectContext;
            string sObjectID = ((TemporaryForensicReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            ForensicMedicalReport forensicMedicalReport = (ForensicMedicalReport)context.GetObject(new Guid(sObjectID),"ForensicMedicalReport");
           
            if(forensicMedicalReport.Report!=null)
                this.Report.Value = forensicMedicalReport.Report.ToString();
#endregion IMAGE BODY_PreScript
                }
            }

        }

        public IMAGEGroup IMAGE;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public TemporaryForensicReport()
        {
            HEADER = new HEADERGroup(this,"HEADER");
            PARTA = new PARTAGroup(HEADER,"PARTA");
            PARTB = new PARTBGroup(PARTA,"PARTB");
            HEADER2 = new HEADER2Group(PARTB,"HEADER2");
            PARTC = new PARTCGroup(HEADER2,"PARTC");
            ENVIRONMENT = new ENVIRONMENTGroup(PARTC,"ENVIRONMENT");
            STORY = new STORYGroup(PARTC,"STORY");
            STORYBODY = new STORYBODYGroup(STORY,"STORYBODY");
            COMPLAINT = new COMPLAINTGroup(STORY,"COMPLAINT");
            COMPLAINTBODY = new COMPLAINTBODYGroup(COMPLAINT,"COMPLAINTBODY");
            HISTORY = new HISTORYGroup(COMPLAINT,"HISTORY");
            HISTORYBODY = new HISTORYBODYGroup(HISTORY,"HISTORYBODY");
            NOT = new NOTGroup(HISTORY,"NOT");
            MAIN = new MAINGroup(NOT,"MAIN");
            FINDINGS = new FINDINGSGroup(NOT,"FINDINGS");
            FINDINGSBODY = new FINDINGSBODYGroup(FINDINGS,"FINDINGSBODY");
            SYSTEMEXAMINATION = new SYSTEMEXAMINATIONGroup(FINDINGS,"SYSTEMEXAMINATION");
            SYSTEMEXAMINATIONBODY = new SYSTEMEXAMINATIONBODYGroup(SYSTEMEXAMINATION,"SYSTEMEXAMINATIONBODY");
            PSYCHIATRY = new PSYCHIATRYGroup(SYSTEMEXAMINATION,"PSYCHIATRY");
            PSYCHIATRYBODY = new PSYCHIATRYBODYGroup(PSYCHIATRY,"PSYCHIATRYBODY");
            TESTS = new TESTSGroup(PSYCHIATRY,"TESTS");
            TESTSBODY = new TESTSBODYGroup(TESTS,"TESTSBODY");
            CONSULTATIONREPORTS = new CONSULTATIONREPORTSGroup(TESTS,"CONSULTATIONREPORTS");
            CONSULTATIONREPORTSBODY = new CONSULTATIONREPORTSBODYGroup(CONSULTATIONREPORTS,"CONSULTATIONREPORTSBODY");
            RESULT = new RESULTGroup(CONSULTATIONREPORTS,"RESULT");
            RESULTBODY = new RESULTBODYGroup(RESULT,"RESULTBODY");
            IMAGE = new IMAGEGroup(RESULT,"IMAGE");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "ID", @"", true, false, false, new Guid("53c9e989-dad5-4f3f-b973-d0bda68f0942"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["String50"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "TEMPORARYFORENSICREPORT";
            Caption = "Adli Muayene Raporu";
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
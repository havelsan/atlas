
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
    /// Gün Sonu Poliklinik Raporları
    /// </summary>
    public partial class EndOfDayPoliclinicReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public Guid? POLICLINIC = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class ParentGroup : TTReportGroup
        {
            public EndOfDayPoliclinicReport MyParentReport
            {
                get { return (EndOfDayPoliclinicReport)ParentReport; }
            }

            new public ParentGroupHeader Header()
            {
                return (ParentGroupHeader)_header;
            }

            new public ParentGroupFooter Footer()
            {
                return (ParentGroupFooter)_footer;
            }

            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField XXXXXXBASLIK1 { get {return Header().XXXXXXBASLIK1;} }
            public TTReportField NewField16 { get {return Header().NewField16;} }
            public TTReportField LOGO1 { get {return Header().LOGO1;} }
            public ParentGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public ParentGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new ParentGroupHeader(this);
                _footer = new ParentGroupFooter(this);

            }

            public partial class ParentGroupHeader : TTReportSection
            {
                public EndOfDayPoliclinicReport MyParentReport
                {
                    get { return (EndOfDayPoliclinicReport)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportField XXXXXXBASLIK1;
                public TTReportField NewField16;
                public TTReportField LOGO1; 
                public ParentGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 52;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 32, 176, 40, false);
                    NewField1.Name = "NewField1";
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.TextFont.Size = 15;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"GÜN SONU POLİKLİNİK RAPORU";

                    XXXXXXBASLIK1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 8, 176, 31, false);
                    XXXXXXBASLIK1.Name = "XXXXXXBASLIK1";
                    XXXXXXBASLIK1.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXBASLIK1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK1.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK1.NoClip = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK1.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK1.ExpandTabs = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK1.TextFont.Size = 11;
                    XXXXXXBASLIK1.TextFont.Bold = true;
                    XXXXXXBASLIK1.TextFont.CharSet = 162;
                    XXXXXXBASLIK1.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + ""\r\n"" + TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    NewField16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 44, 43, 50, false);
                    NewField16.Name = "NewField16";
                    NewField16.TextFont.Size = 11;
                    NewField16.TextFont.Bold = true;
                    NewField16.TextFont.Underline = true;
                    NewField16.TextFont.CharSet = 162;
                    NewField16.Value = @"HİZMETE ÖZEL";

                    LOGO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 8, 50, 28, false);
                    LOGO1.Name = "LOGO1";
                    LOGO1.TextFont.Name = "Courier New";
                    LOGO1.Value = @"LOGO";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1.CalcValue = NewField1.Value;
                    NewField16.CalcValue = NewField16.Value;
                    LOGO1.CalcValue = LOGO1.Value;
                    XXXXXXBASLIK1.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { NewField1,NewField16,LOGO1,XXXXXXBASLIK1};
                }
            }
            public partial class ParentGroupFooter : TTReportSection
            {
                public EndOfDayPoliclinicReport MyParentReport
                {
                    get { return (EndOfDayPoliclinicReport)ParentReport; }
                }
                 
                public ParentGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public ParentGroup Parent;

        public partial class HeaderGroup : TTReportGroup
        {
            public EndOfDayPoliclinicReport MyParentReport
            {
                get { return (EndOfDayPoliclinicReport)ParentReport; }
            }

            new public HeaderGroupHeader Header()
            {
                return (HeaderGroupHeader)_header;
            }

            new public HeaderGroupFooter Footer()
            {
                return (HeaderGroupFooter)_footer;
            }

            public TTReportField STARTDATE { get {return Header().STARTDATE;} }
            public TTReportField ENDDATE { get {return Header().ENDDATE;} }
            public TTReportField ACIKLAMA { get {return Header().ACIKLAMA;} }
            public TTReportField EPISODE { get {return Header().EPISODE;} }
            public TTReportField OBJECTID { get {return Header().OBJECTID;} }
            public HeaderGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public HeaderGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<EpisodeAction.GetEndOfDayPoliclinicReport_Class>("GetEndOfDayPoliclinicReport", EpisodeAction.GetEndOfDayPoliclinicReport((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.POLICLINIC)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new HeaderGroupHeader(this);
                _footer = new HeaderGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class HeaderGroupHeader : TTReportSection
            {
                public EndOfDayPoliclinicReport MyParentReport
                {
                    get { return (EndOfDayPoliclinicReport)ParentReport; }
                }
                
                public TTReportField STARTDATE;
                public TTReportField ENDDATE;
                public TTReportField ACIKLAMA;
                public TTReportField EPISODE;
                public TTReportField OBJECTID; 
                public HeaderGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 6;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    STARTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 221, 1, 237, 6, false);
                    STARTDATE.Name = "STARTDATE";
                    STARTDATE.Visible = EvetHayirEnum.ehHayir;
                    STARTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STARTDATE.TextFormat = @"dd/MM/yyyy";
                    STARTDATE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    STARTDATE.TextFont.Size = 9;
                    STARTDATE.TextFont.CharSet = 162;
                    STARTDATE.Value = @"{@STARTDATE@}";

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 242, 1, 258, 6, false);
                    ENDDATE.Name = "ENDDATE";
                    ENDDATE.Visible = EvetHayirEnum.ehHayir;
                    ENDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ENDDATE.TextFormat = @"dd/MM/yyyy";
                    ENDDATE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    ENDDATE.TextFont.Size = 9;
                    ENDDATE.TextFont.CharSet = 162;
                    ENDDATE.Value = @"{@ENDDATE@}";

                    ACIKLAMA = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 1, 176, 6, false);
                    ACIKLAMA.Name = "ACIKLAMA";
                    ACIKLAMA.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACIKLAMA.TextFormat = @"dd/MM/yyyy";
                    ACIKLAMA.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ACIKLAMA.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ACIKLAMA.TextFont.CharSet = 162;
                    ACIKLAMA.Value = @"{%STARTDATE%} - {%ENDDATE%} Arasındaki Muayeneler";

                    EPISODE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 261, 1, 277, 6, false);
                    EPISODE.Name = "EPISODE";
                    EPISODE.Visible = EvetHayirEnum.ehHayir;
                    EPISODE.FieldType = ReportFieldTypeEnum.ftVariable;
                    EPISODE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    EPISODE.TextFont.Size = 9;
                    EPISODE.TextFont.CharSet = 162;
                    EPISODE.Value = @"{#EPISODE#}";

                    OBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 280, 1, 296, 6, false);
                    OBJECTID.Name = "OBJECTID";
                    OBJECTID.Visible = EvetHayirEnum.ehHayir;
                    OBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBJECTID.HorzAlign = HorizontalAlignmentEnum.haRight;
                    OBJECTID.TextFont.Size = 9;
                    OBJECTID.TextFont.CharSet = 162;
                    OBJECTID.Value = @"{#OBJECTID#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    EpisodeAction.GetEndOfDayPoliclinicReport_Class dataset_GetEndOfDayPoliclinicReport = ParentGroup.rsGroup.GetCurrentRecord<EpisodeAction.GetEndOfDayPoliclinicReport_Class>(0);
                    STARTDATE.CalcValue = MyParentReport.RuntimeParameters.STARTDATE.ToString();
                    ENDDATE.CalcValue = MyParentReport.RuntimeParameters.ENDDATE.ToString();
                    ACIKLAMA.CalcValue = MyParentReport.Header.STARTDATE.FormattedValue + @" - " + MyParentReport.Header.ENDDATE.FormattedValue + @" Arasındaki Muayeneler";
                    EPISODE.CalcValue = (dataset_GetEndOfDayPoliclinicReport != null ? Globals.ToStringCore(dataset_GetEndOfDayPoliclinicReport.Episode) : "");
                    OBJECTID.CalcValue = (dataset_GetEndOfDayPoliclinicReport != null ? Globals.ToStringCore(dataset_GetEndOfDayPoliclinicReport.ObjectID) : "");
                    return new TTReportObject[] { STARTDATE,ENDDATE,ACIKLAMA,EPISODE,OBJECTID};
                }
            }
            public partial class HeaderGroupFooter : TTReportSection
            {
                public EndOfDayPoliclinicReport MyParentReport
                {
                    get { return (EndOfDayPoliclinicReport)ParentReport; }
                }
                 
                public HeaderGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    RepeatCount = 0;
                    
                }
                

                public override void RunScript()
                {
#region HEADER FOOTER_Script
                    //
#endregion HEADER FOOTER_Script
                }
            }

        }

        public HeaderGroup Header;

        public partial class MASTERRESOURCEGroup : TTReportGroup
        {
            public EndOfDayPoliclinicReport MyParentReport
            {
                get { return (EndOfDayPoliclinicReport)ParentReport; }
            }

            new public MASTERRESOURCEGroupHeader Header()
            {
                return (MASTERRESOURCEGroupHeader)_header;
            }

            new public MASTERRESOURCEGroupFooter Footer()
            {
                return (MASTERRESOURCEGroupFooter)_footer;
            }

            public TTReportField MASTERRESOURCE { get {return Header().MASTERRESOURCE;} }
            public TTReportField PATIENTID { get {return Header().PATIENTID;} }
            public MASTERRESOURCEGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public MASTERRESOURCEGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override object[] GetGroupByValues()
            {

                EpisodeAction.GetEndOfDayPoliclinicReport_Class dataSet_GetEndOfDayPoliclinicReport = ParentGroup.rsGroup.GetCurrentRecord<EpisodeAction.GetEndOfDayPoliclinicReport_Class>(0);    
                return new object[] {(dataSet_GetEndOfDayPoliclinicReport==null ? null : dataSet_GetEndOfDayPoliclinicReport.MasterResource)};
            }
            private void onConstruct()
            {
                _body = null;
                _header = new MASTERRESOURCEGroupHeader(this);
                _footer = new MASTERRESOURCEGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstParentRS;
            }

            public partial class MASTERRESOURCEGroupHeader : TTReportSection
            {
                public EndOfDayPoliclinicReport MyParentReport
                {
                    get { return (EndOfDayPoliclinicReport)ParentReport; }
                }
                
                public TTReportField MASTERRESOURCE;
                public TTReportField PATIENTID; 
                public MASTERRESOURCEGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 8;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    MASTERRESOURCE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 3, 176, 8, false);
                    MASTERRESOURCE.Name = "MASTERRESOURCE";
                    MASTERRESOURCE.FieldType = ReportFieldTypeEnum.ftVariable;
                    MASTERRESOURCE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MASTERRESOURCE.ObjectDefName = "Resource";
                    MASTERRESOURCE.DataMember = "NAME";
                    MASTERRESOURCE.TextFont.Size = 11;
                    MASTERRESOURCE.TextFont.Bold = true;
                    MASTERRESOURCE.TextFont.CharSet = 162;
                    MASTERRESOURCE.Value = @"{#Header.MASTERRESOURCE#}";

                    PATIENTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 223, 3, 239, 8, false);
                    PATIENTID.Name = "PATIENTID";
                    PATIENTID.Visible = EvetHayirEnum.ehHayir;
                    PATIENTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATIENTID.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PATIENTID.TextFont.Size = 9;
                    PATIENTID.TextFont.CharSet = 162;
                    PATIENTID.Value = @"{#Header.PATIENTID#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    EpisodeAction.GetEndOfDayPoliclinicReport_Class dataset_GetEndOfDayPoliclinicReport = MyParentReport.Header.rsGroup.GetCurrentRecord<EpisodeAction.GetEndOfDayPoliclinicReport_Class>(0);
                    MASTERRESOURCE.CalcValue = (dataset_GetEndOfDayPoliclinicReport != null ? Globals.ToStringCore(dataset_GetEndOfDayPoliclinicReport.MasterResource) : "");
                    MASTERRESOURCE.PostFieldValueCalculation();
                    PATIENTID.CalcValue = (dataset_GetEndOfDayPoliclinicReport != null ? Globals.ToStringCore(dataset_GetEndOfDayPoliclinicReport.Patientid) : "");
                    return new TTReportObject[] { MASTERRESOURCE,PATIENTID};
                }
            }
            public partial class MASTERRESOURCEGroupFooter : TTReportSection
            {
                public EndOfDayPoliclinicReport MyParentReport
                {
                    get { return (EndOfDayPoliclinicReport)ParentReport; }
                }
                 
                public MASTERRESOURCEGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public MASTERRESOURCEGroup MASTERRESOURCE;

        public partial class KlinikGroup : TTReportGroup
        {
            public EndOfDayPoliclinicReport MyParentReport
            {
                get { return (EndOfDayPoliclinicReport)ParentReport; }
            }

            new public KlinikGroupHeader Header()
            {
                return (KlinikGroupHeader)_header;
            }

            new public KlinikGroupFooter Footer()
            {
                return (KlinikGroupFooter)_footer;
            }

            public TTReportField LBLHASTAADISOYADI1 { get {return Header().LBLHASTAADISOYADI1;} }
            public TTReportField LBLHASTAADISOYADI1111 { get {return Header().LBLHASTAADISOYADI1111;} }
            public TTReportField LBLTC { get {return Header().LBLTC;} }
            public TTReportShape NewLine2 { get {return Header().NewLine2;} }
            public TTReportField LBLDOGTARIHI { get {return Header().LBLDOGTARIHI;} }
            public TTReportField LBLKUVVET { get {return Header().LBLKUVVET;} }
            public TTReportField LBLDOGYERI { get {return Header().LBLDOGYERI;} }
            public TTReportField LBLBIRLIK { get {return Header().LBLBIRLIK;} }
            public TTReportField LBLSINIFI { get {return Header().LBLSINIFI;} }
            public TTReportField Field { get {return Header().Field;} }
            public TTReportField Field1 { get {return Header().Field1;} }
            public TTReportField Field2 { get {return Header().Field2;} }
            public TTReportField Field3 { get {return Header().Field3;} }
            public TTReportField Field4 { get {return Header().Field4;} }
            public TTReportField Field5 { get {return Header().Field5;} }
            public TTReportField Field6 { get {return Header().Field6;} }
            public TTReportField Field7 { get {return Header().Field7;} }
            public TTReportField KIMLIKNO { get {return Header().KIMLIKNO;} }
            public TTReportField DOGTARIHI { get {return Header().DOGTARIHI;} }
            public TTReportField KUVVET { get {return Header().KUVVET;} }
            public TTReportField HASTAADISOYADI { get {return Header().HASTAADISOYADI;} }
            public TTReportField BIRLIK { get {return Header().BIRLIK;} }
            public TTReportField SINIFI { get {return Header().SINIFI;} }
            public TTReportField FOREIGNUNIQUEREFNO { get {return Header().FOREIGNUNIQUEREFNO;} }
            public TTReportField UNIQUEREFNO { get {return Header().UNIQUEREFNO;} }
            public TTReportShape NewLine1 { get {return Footer().NewLine1;} }
            public TTReportField TITLE_RANK_NAME_SURNAME { get {return Footer().TITLE_RANK_NAME_SURNAME;} }
            public TTReportField LBLTABIB11 { get {return Footer().LBLTABIB11;} }
            public TTReportField LBLSICILNO11 { get {return Footer().LBLSICILNO11;} }
            public TTReportField Field1121 { get {return Footer().Field1121;} }
            public TTReportField SICILNO { get {return Footer().SICILNO;} }
            public TTReportField EPISODEACTION { get {return Footer().EPISODEACTION;} }
            public TTReportField UZMANLIK { get {return Footer().UZMANLIK;} }
            public TTReportField TITLE { get {return Footer().TITLE;} }
            public TTReportField RANK_NAME_SURNAME { get {return Footer().RANK_NAME_SURNAME;} }
            public KlinikGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public KlinikGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override object[] GetGroupByValues()
            {

                EpisodeAction.GetEndOfDayPoliclinicReport_Class dataSet_GetEndOfDayPoliclinicReport = ParentGroup.rsGroup.GetCurrentRecord<EpisodeAction.GetEndOfDayPoliclinicReport_Class>(0);    
                return new object[] {(dataSet_GetEndOfDayPoliclinicReport==null ? null : dataSet_GetEndOfDayPoliclinicReport.MasterResource), (dataSet_GetEndOfDayPoliclinicReport==null ? null : dataSet_GetEndOfDayPoliclinicReport.Patientid)};
            }
            private void onConstruct()
            {
                _body = null;
                _header = new KlinikGroupHeader(this);
                _footer = new KlinikGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstParentRS;
            }

            public partial class KlinikGroupHeader : TTReportSection
            {
                public EndOfDayPoliclinicReport MyParentReport
                {
                    get { return (EndOfDayPoliclinicReport)ParentReport; }
                }
                
                public TTReportField LBLHASTAADISOYADI1;
                public TTReportField LBLHASTAADISOYADI1111;
                public TTReportField LBLTC;
                public TTReportShape NewLine2;
                public TTReportField LBLDOGTARIHI;
                public TTReportField LBLKUVVET;
                public TTReportField LBLDOGYERI;
                public TTReportField LBLBIRLIK;
                public TTReportField LBLSINIFI;
                public TTReportField Field;
                public TTReportField Field1;
                public TTReportField Field2;
                public TTReportField Field3;
                public TTReportField Field4;
                public TTReportField Field5;
                public TTReportField Field6;
                public TTReportField Field7;
                public TTReportField KIMLIKNO;
                public TTReportField DOGTARIHI;
                public TTReportField KUVVET;
                public TTReportField HASTAADISOYADI;
                public TTReportField BIRLIK;
                public TTReportField SINIFI;
                public TTReportField FOREIGNUNIQUEREFNO;
                public TTReportField UNIQUEREFNO; 
                public KlinikGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 20;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    LBLHASTAADISOYADI1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 80, 3, 106, 8, false);
                    LBLHASTAADISOYADI1.Name = "LBLHASTAADISOYADI1";
                    LBLHASTAADISOYADI1.TextFont.Size = 9;
                    LBLHASTAADISOYADI1.TextFont.Bold = true;
                    LBLHASTAADISOYADI1.TextFont.CharSet = 162;
                    LBLHASTAADISOYADI1.Value = @"Hasta Adı Soyadı ";

                    LBLHASTAADISOYADI1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 149, 3, 176, 8, false);
                    LBLHASTAADISOYADI1111.Name = "LBLHASTAADISOYADI1111";
                    LBLHASTAADISOYADI1111.TextFont.Size = 9;
                    LBLHASTAADISOYADI1111.TextFont.Bold = true;
                    LBLHASTAADISOYADI1111.TextFont.CharSet = 162;
                    LBLHASTAADISOYADI1111.Value = @"Hasta Grubu";

                    LBLTC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 3, 36, 8, false);
                    LBLTC.Name = "LBLTC";
                    LBLTC.TextFont.Size = 9;
                    LBLTC.TextFont.Bold = true;
                    LBLTC.TextFont.CharSet = 162;
                    LBLTC.Value = @"Kimlik Numarası";

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 2, 207, 2, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbSolid;

                    LBLDOGTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 9, 37, 14, false);
                    LBLDOGTARIHI.Name = "LBLDOGTARIHI";
                    LBLDOGTARIHI.TextFont.Size = 9;
                    LBLDOGTARIHI.TextFont.Bold = true;
                    LBLDOGTARIHI.TextFont.CharSet = 162;
                    LBLDOGTARIHI.Value = @"Doğum Tarihi";

                    LBLKUVVET = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 15, 36, 20, false);
                    LBLKUVVET.Name = "LBLKUVVET";
                    LBLKUVVET.TextFont.Size = 9;
                    LBLKUVVET.TextFont.Bold = true;
                    LBLKUVVET.TextFont.CharSet = 162;
                    LBLKUVVET.Value = @"Kuvvet";

                    LBLDOGYERI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 80, 9, 106, 14, false);
                    LBLDOGYERI.Name = "LBLDOGYERI";
                    LBLDOGYERI.TextFont.Size = 9;
                    LBLDOGYERI.TextFont.Bold = true;
                    LBLDOGYERI.TextFont.CharSet = 162;
                    LBLDOGYERI.Value = @"Doğum Yeri";

                    LBLBIRLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 80, 15, 106, 20, false);
                    LBLBIRLIK.Name = "LBLBIRLIK";
                    LBLBIRLIK.TextFont.Size = 9;
                    LBLBIRLIK.TextFont.Bold = true;
                    LBLBIRLIK.TextFont.CharSet = 162;
                    LBLBIRLIK.Value = @"Birlik";

                    LBLSINIFI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 149, 9, 175, 14, false);
                    LBLSINIFI.Name = "LBLSINIFI";
                    LBLSINIFI.TextFont.Size = 9;
                    LBLSINIFI.TextFont.Bold = true;
                    LBLSINIFI.TextFont.CharSet = 162;
                    LBLSINIFI.Value = @"Sinifi";

                    Field = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 3, 38, 8, false);
                    Field.Name = "Field";
                    Field.TextFont.Size = 9;
                    Field.TextFont.Bold = true;
                    Field.TextFont.CharSet = 162;
                    Field.Value = @":";

                    Field1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 9, 38, 14, false);
                    Field1.Name = "Field1";
                    Field1.TextFont.Size = 9;
                    Field1.TextFont.Bold = true;
                    Field1.TextFont.CharSet = 162;
                    Field1.Value = @":";

                    Field2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 15, 38, 20, false);
                    Field2.Name = "Field2";
                    Field2.TextFont.Size = 9;
                    Field2.TextFont.Bold = true;
                    Field2.TextFont.CharSet = 162;
                    Field2.Value = @":";

                    Field3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 3, 108, 8, false);
                    Field3.Name = "Field3";
                    Field3.TextFont.Size = 9;
                    Field3.TextFont.Bold = true;
                    Field3.TextFont.CharSet = 162;
                    Field3.Value = @":";

                    Field4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 9, 108, 14, false);
                    Field4.Name = "Field4";
                    Field4.TextFont.Size = 9;
                    Field4.TextFont.Bold = true;
                    Field4.TextFont.CharSet = 162;
                    Field4.Value = @":";

                    Field5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 15, 108, 20, false);
                    Field5.Name = "Field5";
                    Field5.TextFont.Size = 9;
                    Field5.TextFont.Bold = true;
                    Field5.TextFont.CharSet = 162;
                    Field5.Value = @":";

                    Field6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 175, 3, 177, 8, false);
                    Field6.Name = "Field6";
                    Field6.TextFont.Size = 9;
                    Field6.TextFont.Bold = true;
                    Field6.TextFont.CharSet = 162;
                    Field6.Value = @":";

                    Field7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 175, 9, 177, 14, false);
                    Field7.Name = "Field7";
                    Field7.TextFont.Size = 9;
                    Field7.TextFont.Bold = true;
                    Field7.TextFont.CharSet = 162;
                    Field7.Value = @":";

                    KIMLIKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 3, 77, 8, false);
                    KIMLIKNO.Name = "KIMLIKNO";
                    KIMLIKNO.TextFont.Size = 9;
                    KIMLIKNO.TextFont.CharSet = 162;
                    KIMLIKNO.Value = @"";

                    DOGTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 9, 77, 14, false);
                    DOGTARIHI.Name = "DOGTARIHI";
                    DOGTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOGTARIHI.TextFormat = @"dd/MM/yyyy";
                    DOGTARIHI.ObjectDefName = "Patient";
                    DOGTARIHI.DataMember = "BIRTHDATE";
                    DOGTARIHI.TextFont.Size = 9;
                    DOGTARIHI.TextFont.CharSet = 162;
                    DOGTARIHI.Value = @"{#Header.PATIENTID#}";

                    KUVVET = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 15, 79, 20, false);
                    KUVVET.Name = "KUVVET";
                    KUVVET.FieldType = ReportFieldTypeEnum.ftVariable;
                    KUVVET.TextFont.Size = 9;
                    KUVVET.TextFont.CharSet = 162;
                    KUVVET.Value = @"";

                    HASTAADISOYADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 108, 3, 148, 8, false);
                    HASTAADISOYADI.Name = "HASTAADISOYADI";
                    HASTAADISOYADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTAADISOYADI.TextFont.Size = 9;
                    HASTAADISOYADI.TextFont.CharSet = 162;
                    HASTAADISOYADI.Value = @"{#Header.HASTAADI#} {#Header.HASTASOYADI#}";

                    BIRLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 108, 15, 207, 20, false);
                    BIRLIK.Name = "BIRLIK";
                    BIRLIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    BIRLIK.TextFont.Size = 9;
                    BIRLIK.TextFont.CharSet = 162;
                    BIRLIK.Value = @"";

                    SINIFI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 177, 9, 207, 14, false);
                    SINIFI.Name = "SINIFI";
                    SINIFI.FieldType = ReportFieldTypeEnum.ftVariable;
                    SINIFI.TextFont.Size = 9;
                    SINIFI.TextFont.CharSet = 162;
                    SINIFI.Value = @"";

                    FOREIGNUNIQUEREFNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 10, 256, 15, false);
                    FOREIGNUNIQUEREFNO.Name = "FOREIGNUNIQUEREFNO";
                    FOREIGNUNIQUEREFNO.Visible = EvetHayirEnum.ehHayir;
                    FOREIGNUNIQUEREFNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    FOREIGNUNIQUEREFNO.ObjectDefName = "Patient";
                    FOREIGNUNIQUEREFNO.DataMember = "FOREIGNUNIQUEREFNO";
                    FOREIGNUNIQUEREFNO.TextFont.Size = 9;
                    FOREIGNUNIQUEREFNO.TextFont.CharSet = 162;
                    FOREIGNUNIQUEREFNO.Value = @"{#Header.PATIENTID#}";

                    UNIQUEREFNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 3, 256, 8, false);
                    UNIQUEREFNO.Name = "UNIQUEREFNO";
                    UNIQUEREFNO.Visible = EvetHayirEnum.ehHayir;
                    UNIQUEREFNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNIQUEREFNO.TextFont.Size = 9;
                    UNIQUEREFNO.TextFont.CharSet = 162;
                    UNIQUEREFNO.Value = @"{#Header.TCNO#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    EpisodeAction.GetEndOfDayPoliclinicReport_Class dataset_GetEndOfDayPoliclinicReport = MyParentReport.Header.rsGroup.GetCurrentRecord<EpisodeAction.GetEndOfDayPoliclinicReport_Class>(0);
                    LBLHASTAADISOYADI1.CalcValue = LBLHASTAADISOYADI1.Value;
                    LBLHASTAADISOYADI1111.CalcValue = LBLHASTAADISOYADI1111.Value;
                    LBLTC.CalcValue = LBLTC.Value;
                    LBLDOGTARIHI.CalcValue = LBLDOGTARIHI.Value;
                    LBLKUVVET.CalcValue = LBLKUVVET.Value;
                    LBLDOGYERI.CalcValue = LBLDOGYERI.Value;
                    LBLBIRLIK.CalcValue = LBLBIRLIK.Value;
                    LBLSINIFI.CalcValue = LBLSINIFI.Value;
                    Field.CalcValue = Field.Value;
                    Field1.CalcValue = Field1.Value;
                    Field2.CalcValue = Field2.Value;
                    Field3.CalcValue = Field3.Value;
                    Field4.CalcValue = Field4.Value;
                    Field5.CalcValue = Field5.Value;
                    Field6.CalcValue = Field6.Value;
                    Field7.CalcValue = Field7.Value;
                    KIMLIKNO.CalcValue = KIMLIKNO.Value;
                    DOGTARIHI.CalcValue = (dataset_GetEndOfDayPoliclinicReport != null ? Globals.ToStringCore(dataset_GetEndOfDayPoliclinicReport.Patientid) : "");
                    DOGTARIHI.PostFieldValueCalculation();
                    KUVVET.CalcValue = @"";
                    HASTAADISOYADI.CalcValue = (dataset_GetEndOfDayPoliclinicReport != null ? Globals.ToStringCore(dataset_GetEndOfDayPoliclinicReport.Hastaadi) : "") + @" " + (dataset_GetEndOfDayPoliclinicReport != null ? Globals.ToStringCore(dataset_GetEndOfDayPoliclinicReport.Hastasoyadi) : "");
                    BIRLIK.CalcValue = @"";
                    SINIFI.CalcValue = @"";
                    FOREIGNUNIQUEREFNO.CalcValue = (dataset_GetEndOfDayPoliclinicReport != null ? Globals.ToStringCore(dataset_GetEndOfDayPoliclinicReport.Patientid) : "");
                    FOREIGNUNIQUEREFNO.PostFieldValueCalculation();
                    UNIQUEREFNO.CalcValue = (dataset_GetEndOfDayPoliclinicReport != null ? Globals.ToStringCore(dataset_GetEndOfDayPoliclinicReport.Tcno) : "");
                    return new TTReportObject[] { LBLHASTAADISOYADI1,LBLHASTAADISOYADI1111,LBLTC,LBLDOGTARIHI,LBLKUVVET,LBLDOGYERI,LBLBIRLIK,LBLSINIFI,Field,Field1,Field2,Field3,Field4,Field5,Field6,Field7,KIMLIKNO,DOGTARIHI,KUVVET,HASTAADISOYADI,BIRLIK,SINIFI,FOREIGNUNIQUEREFNO,UNIQUEREFNO};
                }

                public override void RunScript()
                {
#region KLINIK HEADER_Script
                    //                                    
//                    
//
//
//                    if(this.FOREIGNUNIQUEREFNO.CalcValue != "")
//                this.KIMLIKNO.CalcValue = "(*)" + this.FOREIGNUNIQUEREFNO.CalcValue;
//           else
//                this.KIMLIKNO.CalcValue = this.UNIQUEREFNO.CalcValue;
#endregion KLINIK HEADER_Script
                }
            }
            public partial class KlinikGroupFooter : TTReportSection
            {
                public EndOfDayPoliclinicReport MyParentReport
                {
                    get { return (EndOfDayPoliclinicReport)ParentReport; }
                }
                
                public TTReportShape NewLine1;
                public TTReportField TITLE_RANK_NAME_SURNAME;
                public TTReportField LBLTABIB11;
                public TTReportField LBLSICILNO11;
                public TTReportField Field1121;
                public TTReportField SICILNO;
                public TTReportField EPISODEACTION;
                public TTReportField UZMANLIK;
                public TTReportField TITLE;
                public TTReportField RANK_NAME_SURNAME; 
                public KlinikGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 29;
                    RepeatCount = 0;
                    
                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 2, 208, 2, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    TITLE_RANK_NAME_SURNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 10, 92, 15, false);
                    TITLE_RANK_NAME_SURNAME.Name = "TITLE_RANK_NAME_SURNAME";
                    TITLE_RANK_NAME_SURNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    TITLE_RANK_NAME_SURNAME.TextFont.Size = 8;
                    TITLE_RANK_NAME_SURNAME.TextFont.CharSet = 162;
                    TITLE_RANK_NAME_SURNAME.Value = @"";

                    LBLTABIB11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 4, 65, 9, false);
                    LBLTABIB11.Name = "LBLTABIB11";
                    LBLTABIB11.TextFont.Size = 9;
                    LBLTABIB11.TextFont.Bold = true;
                    LBLTABIB11.TextFont.CharSet = 162;
                    LBLTABIB11.Value = @"Muayene Eden Tabip";

                    LBLSICILNO11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 16, 36, 21, false);
                    LBLSICILNO11.Name = "LBLSICILNO11";
                    LBLSICILNO11.TextFont.Size = 9;
                    LBLSICILNO11.TextFont.Bold = true;
                    LBLSICILNO11.TextFont.CharSet = 162;
                    LBLSICILNO11.Value = @"SİCİL NUMARASI";

                    Field1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 16, 38, 21, false);
                    Field1121.Name = "Field1121";
                    Field1121.TextFont.Size = 9;
                    Field1121.TextFont.Bold = true;
                    Field1121.TextFont.CharSet = 162;
                    Field1121.Value = @":";

                    SICILNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 16, 65, 21, false);
                    SICILNO.Name = "SICILNO";
                    SICILNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SICILNO.Value = @"{#Header.SICILNO#}";

                    EPISODEACTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 230, 17, 255, 22, false);
                    EPISODEACTION.Name = "EPISODEACTION";
                    EPISODEACTION.Visible = EvetHayirEnum.ehHayir;
                    EPISODEACTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    EPISODEACTION.Value = @"{#Header.OBJECTID#}";

                    UZMANLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 22, 92, 27, false);
                    UZMANLIK.Name = "UZMANLIK";
                    UZMANLIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    UZMANLIK.Value = @"";

                    TITLE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 3, 122, 8, false);
                    TITLE.Name = "TITLE";
                    TITLE.Visible = EvetHayirEnum.ehHayir;
                    TITLE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TITLE.ObjectDefName = "UserTitleEnum";
                    TITLE.DataMember = "DISPLAYTEXT";
                    TITLE.TextFont.Size = 8;
                    TITLE.TextFont.CharSet = 162;
                    TITLE.Value = @"{#Header.DOCTITLE#}";

                    RANK_NAME_SURNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 111, 11, 166, 16, false);
                    RANK_NAME_SURNAME.Name = "RANK_NAME_SURNAME";
                    RANK_NAME_SURNAME.Visible = EvetHayirEnum.ehHayir;
                    RANK_NAME_SURNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    RANK_NAME_SURNAME.TextFont.Size = 8;
                    RANK_NAME_SURNAME.TextFont.CharSet = 162;
                    RANK_NAME_SURNAME.Value = @"{#Header.DOCRANK#} {#Header.DOCNAME#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    EpisodeAction.GetEndOfDayPoliclinicReport_Class dataset_GetEndOfDayPoliclinicReport = MyParentReport.Header.rsGroup.GetCurrentRecord<EpisodeAction.GetEndOfDayPoliclinicReport_Class>(0);
                    TITLE_RANK_NAME_SURNAME.CalcValue = @"";
                    LBLTABIB11.CalcValue = LBLTABIB11.Value;
                    LBLSICILNO11.CalcValue = LBLSICILNO11.Value;
                    Field1121.CalcValue = Field1121.Value;
                    SICILNO.CalcValue = (dataset_GetEndOfDayPoliclinicReport != null ? Globals.ToStringCore(dataset_GetEndOfDayPoliclinicReport.Sicilno) : "");
                    EPISODEACTION.CalcValue = (dataset_GetEndOfDayPoliclinicReport != null ? Globals.ToStringCore(dataset_GetEndOfDayPoliclinicReport.ObjectID) : "");
                    UZMANLIK.CalcValue = @"";
                    TITLE.CalcValue = (dataset_GetEndOfDayPoliclinicReport != null ? Globals.ToStringCore(dataset_GetEndOfDayPoliclinicReport.Doctitle) : "");
                    TITLE.PostFieldValueCalculation();
                    RANK_NAME_SURNAME.CalcValue = (dataset_GetEndOfDayPoliclinicReport != null ? Globals.ToStringCore(dataset_GetEndOfDayPoliclinicReport.Docrank) : "") + @" " + (dataset_GetEndOfDayPoliclinicReport != null ? Globals.ToStringCore(dataset_GetEndOfDayPoliclinicReport.Docname) : "");
                    return new TTReportObject[] { TITLE_RANK_NAME_SURNAME,LBLTABIB11,LBLSICILNO11,Field1121,SICILNO,EPISODEACTION,UZMANLIK,TITLE,RANK_NAME_SURNAME};
                }

                public override void RunScript()
                {
#region KLINIK FOOTER_Script
                    if (this.TITLE.CalcValue != null)
                        this.TITLE_RANK_NAME_SURNAME.CalcValue = this.TITLE.CalcValue + " " + this.RANK_NAME_SURNAME.CalcValue;
                      else
                          this.TITLE_RANK_NAME_SURNAME.CalcValue=this.RANK_NAME_SURNAME.CalcValue;
                      
                      EpisodeAction episodeAction = (EpisodeAction)this.ParentReport.ReportObjectContext.GetObject(new Guid(this.EPISODEACTION.CalcValue), typeof(EpisodeAction));
                      string specialtyText = "";
                    if(episodeAction.ProcedureDoctor!= null)
                    {
                        if(episodeAction.ProcedureDoctor.ResourceSpecialities!=null&&episodeAction.ProcedureDoctor.ResourceSpecialities.Count>0)
                         foreach (ResourceSpecialityGrid specialty in episodeAction.ProcedureDoctor.ResourceSpecialities)
                            {
                                if (specialty.MainSpeciality!=null)
                                {
                                    if (specialty.MainSpeciality.Value)
                                    {
                                        this.UZMANLIK.CalcValue += specialty.Speciality.Name;
                                        this.UZMANLIK.CalcValue += (!specialty.Speciality.Name.Contains("Uzm") && !specialty.Speciality.Name.Contains("UZM")) ? "Uzm.\r\n" : "\r\n";
                                    }
                                    else
                                        specialtyText += specialty.Speciality.Name;
                                    specialtyText += (specialty.Speciality.Name.Contains("Uzm") == false && specialty.Speciality.Name.Contains("UZM") == false) ? "Uzm.\r\n" : "\r\n"; 
                                }
                            }
                         this.UZMANLIK.CalcValue = specialtyText;
                    }
                    else this.UZMANLIK.CalcValue +="";
#endregion KLINIK FOOTER_Script
                }
            }

        }

        public KlinikGroup Klinik;

        public partial class OdaGrubuGroup : TTReportGroup
        {
            public EndOfDayPoliclinicReport MyParentReport
            {
                get { return (EndOfDayPoliclinicReport)ParentReport; }
            }

            new public OdaGrubuGroupHeader Header()
            {
                return (OdaGrubuGroupHeader)_header;
            }

            new public OdaGrubuGroupFooter Footer()
            {
                return (OdaGrubuGroupFooter)_footer;
            }

            public TTReportShape NewLine12 { get {return Header().NewLine12;} }
            public TTReportField NewField1191 { get {return Header().NewField1191;} }
            public TTReportField LBLTIBBIPROTOKOLNO11 { get {return Header().LBLTIBBIPROTOKOLNO11;} }
            public TTReportField LBLBIRIMROTOKOLNO111 { get {return Header().LBLBIRIMROTOKOLNO111;} }
            public TTReportField LBLGIDECEGIXXXXXX { get {return Header().LBLGIDECEGIXXXXXX;} }
            public OdaGrubuGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public OdaGrubuGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new OdaGrubuGroupHeader(this);
                _footer = new OdaGrubuGroupFooter(this);

            }

            public partial class OdaGrubuGroupHeader : TTReportSection
            {
                public EndOfDayPoliclinicReport MyParentReport
                {
                    get { return (EndOfDayPoliclinicReport)ParentReport; }
                }
                
                public TTReportShape NewLine12;
                public TTReportField NewField1191;
                public TTReportField LBLTIBBIPROTOKOLNO11;
                public TTReportField LBLBIRIMROTOKOLNO111;
                public TTReportField LBLGIDECEGIXXXXXX; 
                public OdaGrubuGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 8;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 1, 207, 1, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField1191 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 3, 40, 8, false);
                    NewField1191.Name = "NewField1191";
                    NewField1191.TextFont.Size = 9;
                    NewField1191.TextFont.Bold = true;
                    NewField1191.TextFont.CharSet = 162;
                    NewField1191.Value = @"İşlem Tarihi";

                    LBLTIBBIPROTOKOLNO11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 3, 75, 8, false);
                    LBLTIBBIPROTOKOLNO11.Name = "LBLTIBBIPROTOKOLNO11";
                    LBLTIBBIPROTOKOLNO11.TextFont.Size = 9;
                    LBLTIBBIPROTOKOLNO11.TextFont.Bold = true;
                    LBLTIBBIPROTOKOLNO11.TextFont.CharSet = 162;
                    LBLTIBBIPROTOKOLNO11.Value = @"XXXXXX Pr.Nu.";

                    LBLBIRIMROTOKOLNO111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 3, 111, 8, false);
                    LBLBIRIMROTOKOLNO111.Name = "LBLBIRIMROTOKOLNO111";
                    LBLBIRIMROTOKOLNO111.TextFont.Size = 9;
                    LBLBIRIMROTOKOLNO111.TextFont.Bold = true;
                    LBLBIRIMROTOKOLNO111.TextFont.CharSet = 162;
                    LBLBIRIMROTOKOLNO111.Value = @"Birim Pr.Nu.";

                    LBLGIDECEGIXXXXXX = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 118, 3, 168, 8, false);
                    LBLGIDECEGIXXXXXX.Name = "LBLGIDECEGIXXXXXX";
                    LBLGIDECEGIXXXXXX.TextFont.Size = 9;
                    LBLGIDECEGIXXXXXX.TextFont.Bold = true;
                    LBLGIDECEGIXXXXXX.TextFont.CharSet = 162;
                    LBLGIDECEGIXXXXXX.Value = @"Gideceği XXXXXX";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1191.CalcValue = NewField1191.Value;
                    LBLTIBBIPROTOKOLNO11.CalcValue = LBLTIBBIPROTOKOLNO11.Value;
                    LBLBIRIMROTOKOLNO111.CalcValue = LBLBIRIMROTOKOLNO111.Value;
                    LBLGIDECEGIXXXXXX.CalcValue = LBLGIDECEGIXXXXXX.Value;
                    return new TTReportObject[] { NewField1191,LBLTIBBIPROTOKOLNO11,LBLBIRIMROTOKOLNO111,LBLGIDECEGIXXXXXX};
                }
            }
            public partial class OdaGrubuGroupFooter : TTReportSection
            {
                public EndOfDayPoliclinicReport MyParentReport
                {
                    get { return (EndOfDayPoliclinicReport)ParentReport; }
                }
                 
                public OdaGrubuGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public OdaGrubuGroup OdaGrubu;

        public partial class MAINGroup : TTReportGroup
        {
            public EndOfDayPoliclinicReport MyParentReport
            {
                get { return (EndOfDayPoliclinicReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField RDATE { get {return Body().RDATE;} }
            public TTReportField BPROTOKOLNO { get {return Body().BPROTOKOLNO;} }
            public TTReportField GIDECEGIHAST { get {return Body().GIDECEGIHAST;} }
            public TTReportField HPROTOKOLNO { get {return Body().HPROTOKOLNO;} }
            public TTReportField EPISODE1 { get {return Body().EPISODE1;} }
            public TTReportField EPISODEACTION { get {return Body().EPISODEACTION;} }
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
                public EndOfDayPoliclinicReport MyParentReport
                {
                    get { return (EndOfDayPoliclinicReport)ParentReport; }
                }
                
                public TTReportField RDATE;
                public TTReportField BPROTOKOLNO;
                public TTReportField GIDECEGIHAST;
                public TTReportField HPROTOKOLNO;
                public TTReportField EPISODE1;
                public TTReportField EPISODEACTION; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 6;
                    RepeatCount = 0;
                    
                    RDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 1, 40, 6, false);
                    RDATE.Name = "RDATE";
                    RDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    RDATE.TextFormat = @"dd/MM/yyyy";
                    RDATE.TextFont.Size = 9;
                    RDATE.TextFont.CharSet = 162;
                    RDATE.Value = @"{#Header.ACTIONDATE#}";

                    BPROTOKOLNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 1, 111, 6, false);
                    BPROTOKOLNO.Name = "BPROTOKOLNO";
                    BPROTOKOLNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    BPROTOKOLNO.TextFont.Size = 9;
                    BPROTOKOLNO.TextFont.CharSet = 162;
                    BPROTOKOLNO.Value = @"";

                    GIDECEGIHAST = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 118, 1, 207, 6, false);
                    GIDECEGIHAST.Name = "GIDECEGIHAST";
                    GIDECEGIHAST.FieldType = ReportFieldTypeEnum.ftVariable;
                    GIDECEGIHAST.TextFont.Size = 9;
                    GIDECEGIHAST.TextFont.CharSet = 162;
                    GIDECEGIHAST.Value = @"";

                    HPROTOKOLNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 1, 75, 6, false);
                    HPROTOKOLNO.Name = "HPROTOKOLNO";
                    HPROTOKOLNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    HPROTOKOLNO.TextFont.Size = 9;
                    HPROTOKOLNO.TextFont.CharSet = 162;
                    HPROTOKOLNO.Value = @"{#Header.HPROTOCOLNO#}";

                    EPISODE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 219, 1, 239, 6, false);
                    EPISODE1.Name = "EPISODE1";
                    EPISODE1.Visible = EvetHayirEnum.ehHayir;
                    EPISODE1.FieldType = ReportFieldTypeEnum.ftVariable;
                    EPISODE1.TextFont.Size = 9;
                    EPISODE1.TextFont.Bold = true;
                    EPISODE1.TextFont.CharSet = 162;
                    EPISODE1.Value = @"{#Header.EPISODE#}";

                    EPISODEACTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 241, 1, 288, 6, false);
                    EPISODEACTION.Name = "EPISODEACTION";
                    EPISODEACTION.Visible = EvetHayirEnum.ehHayir;
                    EPISODEACTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    EPISODEACTION.Value = @"{#Header.OBJECTID#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    EpisodeAction.GetEndOfDayPoliclinicReport_Class dataset_GetEndOfDayPoliclinicReport = MyParentReport.Header.rsGroup.GetCurrentRecord<EpisodeAction.GetEndOfDayPoliclinicReport_Class>(0);
                    RDATE.CalcValue = (dataset_GetEndOfDayPoliclinicReport != null ? Globals.ToStringCore(dataset_GetEndOfDayPoliclinicReport.ActionDate) : "");
                    BPROTOKOLNO.CalcValue = @"";
                    GIDECEGIHAST.CalcValue = @"";
                    HPROTOKOLNO.CalcValue = (dataset_GetEndOfDayPoliclinicReport != null ? Globals.ToStringCore(dataset_GetEndOfDayPoliclinicReport.Hprotocolno) : "");
                    EPISODE1.CalcValue = (dataset_GetEndOfDayPoliclinicReport != null ? Globals.ToStringCore(dataset_GetEndOfDayPoliclinicReport.Episode) : "");
                    EPISODEACTION.CalcValue = (dataset_GetEndOfDayPoliclinicReport != null ? Globals.ToStringCore(dataset_GetEndOfDayPoliclinicReport.ObjectID) : "");
                    return new TTReportObject[] { RDATE,BPROTOKOLNO,GIDECEGIHAST,HPROTOKOLNO,EPISODE1,EPISODEACTION};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    string episodeObjectID = this.EPISODE1.CalcValue;
                          

           if (Globals.IsGuid(episodeObjectID))
           {
              Episode episode = (Episode)this.ParentReport.ReportObjectContext.GetObject(new Guid(episodeObjectID), typeof(Episode) );
             
              string protocolNo = "";
              string gidecegiXXXXXX = "";

              foreach (TreatmentDischarge treatmentDischarge in episode.TreatmentDischarges)
              {
//                  if (treatmentDischarge.CurrentStateDefID != TreatmentDischarge.States.Cancelled && treatmentDischarge.HospitalSendingTo != null)
//                  {
//                      if (gidecegiXXXXXX.Length > 0) gidecegiXXXXXX += ", ";
//                      gidecegiXXXXXX += treatmentDischarge.HospitalSendingTo.Name;
//                  }
              }
               
              GIDECEGIHAST.CalcValue = gidecegiXXXXXX;
              
                EpisodeAction episodeAction = (EpisodeAction)this.ParentReport.ReportObjectContext.GetObject(new Guid(this.EPISODEACTION.CalcValue), typeof(EpisodeAction));
               this.BPROTOKOLNO.CalcValue = (episodeAction is PatientExamination) ? ((PatientExamination)episodeAction).ProtocolNo.ToString() : (episodeAction is EmergencyIntervention) ? ((EmergencyIntervention)episodeAction).ProtocolNo.ToString() : "";
           }
#endregion MAIN BODY_Script
                }
            }

        }

        public MAINGroup MAIN;

        public partial class ONTANIGroup : TTReportGroup
        {
            public EndOfDayPoliclinicReport MyParentReport
            {
                get { return (EndOfDayPoliclinicReport)ParentReport; }
            }

            new public ONTANIGroupBody Body()
            {
                return (ONTANIGroupBody)_body;
            }
            public TTReportField ONTANI { get {return Body().ONTANI;} }
            public TTReportField LBLONTANI { get {return Body().LBLONTANI;} }
            public TTReportField Field1121 { get {return Body().Field1121;} }
            public TTReportField EPISODE { get {return Body().EPISODE;} }
            public ONTANIGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public ONTANIGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new ONTANIGroupBody(this);
            }

            public partial class ONTANIGroupBody : TTReportSection
            {
                public EndOfDayPoliclinicReport MyParentReport
                {
                    get { return (EndOfDayPoliclinicReport)ParentReport; }
                }
                
                public TTReportField ONTANI;
                public TTReportField LBLONTANI;
                public TTReportField Field1121;
                public TTReportField EPISODE; 
                public ONTANIGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 8;
                    RepeatCount = 0;
                    
                    ONTANI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 2, 208, 7, false);
                    ONTANI.Name = "ONTANI";
                    ONTANI.FieldType = ReportFieldTypeEnum.ftVariable;
                    ONTANI.MultiLine = EvetHayirEnum.ehEvet;
                    ONTANI.NoClip = EvetHayirEnum.ehEvet;
                    ONTANI.WordBreak = EvetHayirEnum.ehEvet;
                    ONTANI.ExpandTabs = EvetHayirEnum.ehEvet;
                    ONTANI.TextFont.Size = 9;
                    ONTANI.TextFont.CharSet = 162;
                    ONTANI.Value = @"";

                    LBLONTANI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 2, 36, 7, false);
                    LBLONTANI.Name = "LBLONTANI";
                    LBLONTANI.TextFont.Size = 9;
                    LBLONTANI.TextFont.Bold = true;
                    LBLONTANI.TextFont.CharSet = 162;
                    LBLONTANI.Value = @"Öntanı";

                    Field1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 2, 38, 7, false);
                    Field1121.Name = "Field1121";
                    Field1121.TextFont.Size = 9;
                    Field1121.TextFont.Bold = true;
                    Field1121.TextFont.CharSet = 162;
                    Field1121.Value = @":";

                    EPISODE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 219, 1, 244, 6, false);
                    EPISODE.Name = "EPISODE";
                    EPISODE.Visible = EvetHayirEnum.ehHayir;
                    EPISODE.FieldType = ReportFieldTypeEnum.ftVariable;
                    EPISODE.Value = @"{#Header.EPISODE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    EpisodeAction.GetEndOfDayPoliclinicReport_Class dataset_GetEndOfDayPoliclinicReport = MyParentReport.Header.rsGroup.GetCurrentRecord<EpisodeAction.GetEndOfDayPoliclinicReport_Class>(0);
                    ONTANI.CalcValue = @"";
                    LBLONTANI.CalcValue = LBLONTANI.Value;
                    Field1121.CalcValue = Field1121.Value;
                    EPISODE.CalcValue = (dataset_GetEndOfDayPoliclinicReport != null ? Globals.ToStringCore(dataset_GetEndOfDayPoliclinicReport.Episode) : "");
                    return new TTReportObject[] { ONTANI,LBLONTANI,Field1121,EPISODE};
                }

                public override void RunScript()
                {
#region ONTANI BODY_Script
                    string ontani = "";
              string episodeObjectID = this.EPISODE.CalcValue;
                    if (Globals.IsGuid(episodeObjectID))
                    {
                       
                        Episode episode = (Episode)this.MyParentReport.ReportObjectContext.GetObject(new Guid(episodeObjectID), typeof(Episode));
                        if (episode != null && episode.PreDiagnosis.Count > 0)
                        {
                           
                           
                            foreach (DiagnosisGrid diagnosis in episode.PreDiagnosis)
                            {

                                if (diagnosis.Diagnose != null)
                                {
                                    if (ontani.Length > 0) ontani += ", ";
                                    ontani += diagnosis.Diagnose.Code + "-" + diagnosis.Diagnose.Name;                                    
                                }
                              
                            }
                        }

                        this.ONTANI.CalcValue = ontani;
                    }
#endregion ONTANI BODY_Script
                }
            }

        }

        public ONTANIGroup ONTANI;

        public partial class TANIGroup : TTReportGroup
        {
            public EndOfDayPoliclinicReport MyParentReport
            {
                get { return (EndOfDayPoliclinicReport)ParentReport; }
            }

            new public TANIGroupBody Body()
            {
                return (TANIGroupBody)_body;
            }
            public TTReportField TANI { get {return Body().TANI;} }
            public TTReportField LBLTANI { get {return Body().LBLTANI;} }
            public TTReportField Field121 { get {return Body().Field121;} }
            public TTReportField EPISODE { get {return Body().EPISODE;} }
            public TANIGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public TANIGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new TANIGroupBody(this);
            }

            public partial class TANIGroupBody : TTReportSection
            {
                public EndOfDayPoliclinicReport MyParentReport
                {
                    get { return (EndOfDayPoliclinicReport)ParentReport; }
                }
                
                public TTReportField TANI;
                public TTReportField LBLTANI;
                public TTReportField Field121;
                public TTReportField EPISODE; 
                public TANIGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 8;
                    RepeatCount = 0;
                    
                    TANI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 2, 207, 7, false);
                    TANI.Name = "TANI";
                    TANI.FieldType = ReportFieldTypeEnum.ftVariable;
                    TANI.MultiLine = EvetHayirEnum.ehEvet;
                    TANI.NoClip = EvetHayirEnum.ehEvet;
                    TANI.WordBreak = EvetHayirEnum.ehEvet;
                    TANI.ExpandTabs = EvetHayirEnum.ehEvet;
                    TANI.TextFont.Size = 9;
                    TANI.TextFont.CharSet = 162;
                    TANI.Value = @"";

                    LBLTANI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 2, 36, 7, false);
                    LBLTANI.Name = "LBLTANI";
                    LBLTANI.TextFont.Size = 9;
                    LBLTANI.TextFont.Bold = true;
                    LBLTANI.TextFont.CharSet = 162;
                    LBLTANI.Value = @"Tanı";

                    Field121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 2, 38, 7, false);
                    Field121.Name = "Field121";
                    Field121.TextFont.Size = 9;
                    Field121.TextFont.Bold = true;
                    Field121.TextFont.CharSet = 162;
                    Field121.Value = @":";

                    EPISODE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 1, 245, 6, false);
                    EPISODE.Name = "EPISODE";
                    EPISODE.Visible = EvetHayirEnum.ehHayir;
                    EPISODE.FieldType = ReportFieldTypeEnum.ftVariable;
                    EPISODE.Value = @"{#Header.EPISODE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    EpisodeAction.GetEndOfDayPoliclinicReport_Class dataset_GetEndOfDayPoliclinicReport = MyParentReport.Header.rsGroup.GetCurrentRecord<EpisodeAction.GetEndOfDayPoliclinicReport_Class>(0);
                    TANI.CalcValue = @"";
                    LBLTANI.CalcValue = LBLTANI.Value;
                    Field121.CalcValue = Field121.Value;
                    EPISODE.CalcValue = (dataset_GetEndOfDayPoliclinicReport != null ? Globals.ToStringCore(dataset_GetEndOfDayPoliclinicReport.Episode) : "");
                    return new TTReportObject[] { TANI,LBLTANI,Field121,EPISODE};
                }

                public override void RunScript()
                {
#region TANI BODY_Script
                    string episodeObjectID = this.EPISODE.CalcValue;
                    if (Globals.IsGuid(episodeObjectID))
                    {
                        
                        Episode episode = (Episode)this.MyParentReport.ReportObjectContext.GetObject(new Guid(episodeObjectID), typeof(Episode));
                        
                        string tani = "";


                        if (episode != null && episode.Diagnosis.Count > 0)
                        {
                           
                           
                            foreach (DiagnosisGrid diagnosis in episode.SecDiagnosis)
                            {
                                if (diagnosis.Diagnose != null)
                                {
                                    if (tani.Length > 0) tani += ", ";
                                    tani += diagnosis.Diagnose.Code + "-" + diagnosis.Diagnose.Name;
                                }
                              
                            }
                        }

                        this.TANI.CalcValue = tani;
                    }
#endregion TANI BODY_Script
                }
            }

        }

        public TANIGroup TANI;

        public partial class KARARGroup : TTReportGroup
        {
            public EndOfDayPoliclinicReport MyParentReport
            {
                get { return (EndOfDayPoliclinicReport)ParentReport; }
            }

            new public KARARGroupBody Body()
            {
                return (KARARGroupBody)_body;
            }
            public TTReportField KARAR { get {return Body().KARAR;} }
            public TTReportField LBLKARAR { get {return Body().LBLKARAR;} }
            public TTReportField Field1221 { get {return Body().Field1221;} }
            public TTReportField EPISODE { get {return Body().EPISODE;} }
            public KARARGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public KARARGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new KARARGroupBody(this);
            }

            public partial class KARARGroupBody : TTReportSection
            {
                public EndOfDayPoliclinicReport MyParentReport
                {
                    get { return (EndOfDayPoliclinicReport)ParentReport; }
                }
                
                public TTReportField KARAR;
                public TTReportField LBLKARAR;
                public TTReportField Field1221;
                public TTReportField EPISODE; 
                public KARARGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 8;
                    RepeatCount = 0;
                    
                    KARAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 1, 207, 6, false);
                    KARAR.Name = "KARAR";
                    KARAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    KARAR.MultiLine = EvetHayirEnum.ehEvet;
                    KARAR.NoClip = EvetHayirEnum.ehEvet;
                    KARAR.WordBreak = EvetHayirEnum.ehEvet;
                    KARAR.ExpandTabs = EvetHayirEnum.ehEvet;
                    KARAR.TextFont.Size = 9;
                    KARAR.TextFont.CharSet = 162;
                    KARAR.Value = @"Karar";

                    LBLKARAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 1, 36, 6, false);
                    LBLKARAR.Name = "LBLKARAR";
                    LBLKARAR.TextFont.Size = 9;
                    LBLKARAR.TextFont.Bold = true;
                    LBLKARAR.TextFont.CharSet = 162;
                    LBLKARAR.Value = @"Karar";

                    Field1221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 1, 38, 6, false);
                    Field1221.Name = "Field1221";
                    Field1221.TextFont.Size = 9;
                    Field1221.TextFont.Bold = true;
                    Field1221.TextFont.CharSet = 162;
                    Field1221.Value = @":";

                    EPISODE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 219, 2, 244, 7, false);
                    EPISODE.Name = "EPISODE";
                    EPISODE.Visible = EvetHayirEnum.ehHayir;
                    EPISODE.FieldType = ReportFieldTypeEnum.ftVariable;
                    EPISODE.Value = @"{#Header.EPISODE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    EpisodeAction.GetEndOfDayPoliclinicReport_Class dataset_GetEndOfDayPoliclinicReport = MyParentReport.Header.rsGroup.GetCurrentRecord<EpisodeAction.GetEndOfDayPoliclinicReport_Class>(0);
                    KARAR.CalcValue = @"Karar";
                    LBLKARAR.CalcValue = LBLKARAR.Value;
                    Field1221.CalcValue = Field1221.Value;
                    EPISODE.CalcValue = (dataset_GetEndOfDayPoliclinicReport != null ? Globals.ToStringCore(dataset_GetEndOfDayPoliclinicReport.Episode) : "");
                    return new TTReportObject[] { KARAR,LBLKARAR,Field1221,EPISODE};
                }

                public override void RunScript()
                {
#region KARAR BODY_Script
                    string episodeObjectID = this.EPISODE.CalcValue;
                    if (Globals.IsGuid(episodeObjectID))
                    {
                        
                        Episode episode = (Episode)this.MyParentReport.ReportObjectContext.GetObject(new Guid(episodeObjectID), typeof(Episode));
                        string karar = "";
                        if (episode != null && episode.TreatmentDischarges.Count > 0)
                        {
                                foreach (TreatmentDischarge treatmentDischarge in episode.TreatmentDischarges)
                                {


                                    if (treatmentDischarge.CurrentStateDefID != TreatmentDischarge.States.Cancelled && treatmentDischarge.Conclusion != null)
                                    {
                                        if (karar.Length > 0) karar += ", ";
                                        karar += TTObjectClasses.Common.GetTextOfRTFString(treatmentDischarge.Conclusion.ToString());
                                    }
                                }
                        }
                        this.KARAR.CalcValue = karar;
                    }
#endregion KARAR BODY_Script
                }
            }

        }

        public KARARGroup KARAR;

        public partial class RECETEGroup : TTReportGroup
        {
            public EndOfDayPoliclinicReport MyParentReport
            {
                get { return (EndOfDayPoliclinicReport)ParentReport; }
            }

            new public RECETEGroupBody Body()
            {
                return (RECETEGroupBody)_body;
            }
            public TTReportField EPISODE { get {return Body().EPISODE;} }
            public TTReportField RECETE { get {return Body().RECETE;} }
            public RECETEGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public RECETEGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new RECETEGroupBody(this);
            }

            public partial class RECETEGroupBody : TTReportSection
            {
                public EndOfDayPoliclinicReport MyParentReport
                {
                    get { return (EndOfDayPoliclinicReport)ParentReport; }
                }
                
                public TTReportField EPISODE;
                public TTReportField RECETE; 
                public RECETEGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 7;
                    RepeatCount = 0;
                    
                    EPISODE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 1, 242, 6, false);
                    EPISODE.Name = "EPISODE";
                    EPISODE.Visible = EvetHayirEnum.ehHayir;
                    EPISODE.FieldType = ReportFieldTypeEnum.ftVariable;
                    EPISODE.TextFont.Size = 9;
                    EPISODE.TextFont.Bold = true;
                    EPISODE.TextFont.CharSet = 162;
                    EPISODE.Value = @"{#Header.EPISODE#}";

                    RECETE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 1, 207, 6, false);
                    RECETE.Name = "RECETE";
                    RECETE.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    EpisodeAction.GetEndOfDayPoliclinicReport_Class dataset_GetEndOfDayPoliclinicReport = MyParentReport.Header.rsGroup.GetCurrentRecord<EpisodeAction.GetEndOfDayPoliclinicReport_Class>(0);
                    EPISODE.CalcValue = (dataset_GetEndOfDayPoliclinicReport != null ? Globals.ToStringCore(dataset_GetEndOfDayPoliclinicReport.Episode) : "");
                    RECETE.CalcValue = RECETE.Value;
                    return new TTReportObject[] { EPISODE,RECETE};
                }

                public override void RunScript()
                {
#region RECETE BODY_Script
                    string episodeObjectID = this.EPISODE.CalcValue;
                    if (Globals.IsGuid(episodeObjectID))
                    {
                        //Episode episode = (Episode)this.ParentReport.ReportObjectContext.GetObject(new Guid(episodeObjectID), typeof(Episode) );
                        string recete = "";
                        TTObjectContext tto= this.ParentReport.ReportObjectContext;
                        IBindingList outPatientPreList = OutPatientPrescription.GetOutPatientPrescriptionByEpisodeIDs(tto,new Guid(episodeObjectID));
                        foreach(OutPatientPrescription outPatientPre in outPatientPreList)
                        {
                           foreach(OutPatientDrugOrder opdrgorder in outPatientPre.OutPatientDrugOrders)
                           
                               recete += opdrgorder.Material.Name + ",";
                        }
                       
                        this.RECETE.CalcValue =recete ;
                       
                      
                        
                    }
#endregion RECETE BODY_Script
                }
            }

        }

        public RECETEGroup RECETE;

        public partial class IslemGroup : TTReportGroup
        {
            public EndOfDayPoliclinicReport MyParentReport
            {
                get { return (EndOfDayPoliclinicReport)ParentReport; }
            }

            new public IslemGroupHeader Header()
            {
                return (IslemGroupHeader)_header;
            }

            new public IslemGroupFooter Footer()
            {
                return (IslemGroupFooter)_footer;
            }

            public TTReportField LBLISLEMNO { get {return Header().LBLISLEMNO;} }
            public TTReportField LBLISLEMTARIHI { get {return Header().LBLISLEMTARIHI;} }
            public TTReportField LBLISLEMADIMI { get {return Header().LBLISLEMADIMI;} }
            public TTReportField LBLISLEMACIKLAMASI { get {return Header().LBLISLEMACIKLAMASI;} }
            public IslemGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public IslemGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new IslemGroupHeader(this);
                _footer = new IslemGroupFooter(this);

            }

            public partial class IslemGroupHeader : TTReportSection
            {
                public EndOfDayPoliclinicReport MyParentReport
                {
                    get { return (EndOfDayPoliclinicReport)ParentReport; }
                }
                
                public TTReportField LBLISLEMNO;
                public TTReportField LBLISLEMTARIHI;
                public TTReportField LBLISLEMADIMI;
                public TTReportField LBLISLEMACIKLAMASI; 
                public IslemGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 6;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    LBLISLEMNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 1, 40, 6, false);
                    LBLISLEMNO.Name = "LBLISLEMNO";
                    LBLISLEMNO.TextFont.Size = 9;
                    LBLISLEMNO.TextFont.Bold = true;
                    LBLISLEMNO.TextFont.CharSet = 162;
                    LBLISLEMNO.Value = @"İşlem Nu.";

                    LBLISLEMTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 1, 75, 6, false);
                    LBLISLEMTARIHI.Name = "LBLISLEMTARIHI";
                    LBLISLEMTARIHI.TextFont.Size = 9;
                    LBLISLEMTARIHI.TextFont.Bold = true;
                    LBLISLEMTARIHI.TextFont.CharSet = 162;
                    LBLISLEMTARIHI.Value = @"İşlem Tarihi";

                    LBLISLEMADIMI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 1, 111, 6, false);
                    LBLISLEMADIMI.Name = "LBLISLEMADIMI";
                    LBLISLEMADIMI.TextFont.Size = 9;
                    LBLISLEMADIMI.TextFont.Bold = true;
                    LBLISLEMADIMI.TextFont.CharSet = 162;
                    LBLISLEMADIMI.Value = @"İşlem Adımı";

                    LBLISLEMACIKLAMASI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 118, 1, 168, 6, false);
                    LBLISLEMACIKLAMASI.Name = "LBLISLEMACIKLAMASI";
                    LBLISLEMACIKLAMASI.TextFont.Size = 9;
                    LBLISLEMACIKLAMASI.TextFont.Bold = true;
                    LBLISLEMACIKLAMASI.TextFont.CharSet = 162;
                    LBLISLEMACIKLAMASI.Value = @"İşlem Açıklaması";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    LBLISLEMNO.CalcValue = LBLISLEMNO.Value;
                    LBLISLEMTARIHI.CalcValue = LBLISLEMTARIHI.Value;
                    LBLISLEMADIMI.CalcValue = LBLISLEMADIMI.Value;
                    LBLISLEMACIKLAMASI.CalcValue = LBLISLEMACIKLAMASI.Value;
                    return new TTReportObject[] { LBLISLEMNO,LBLISLEMTARIHI,LBLISLEMADIMI,LBLISLEMACIKLAMASI};
                }
            }
            public partial class IslemGroupFooter : TTReportSection
            {
                public EndOfDayPoliclinicReport MyParentReport
                {
                    get { return (EndOfDayPoliclinicReport)ParentReport; }
                }
                 
                public IslemGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 2;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public IslemGroup Islem;

        public partial class IslemlerGroup : TTReportGroup
        {
            public EndOfDayPoliclinicReport MyParentReport
            {
                get { return (EndOfDayPoliclinicReport)ParentReport; }
            }

            new public IslemlerGroupBody Body()
            {
                return (IslemlerGroupBody)_body;
            }
            public TTReportField ISLEMNO { get {return Body().ISLEMNO;} }
            public TTReportField ISLEMADIMI { get {return Body().ISLEMADIMI;} }
            public TTReportField ISLEMACIKLAMASI { get {return Body().ISLEMACIKLAMASI;} }
            public TTReportField ISLEMTARIHI { get {return Body().ISLEMTARIHI;} }
            public TTReportField OBJDISPLAYTEXT { get {return Body().OBJDISPLAYTEXT;} }
            public TTReportField OBJDESCRIPTION { get {return Body().OBJDESCRIPTION;} }
            public TTReportField OBJECTNAME { get {return Body().OBJECTNAME;} }
            public IslemlerGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public IslemlerGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<EpisodeAction.GetEpisodeActionByObjectID_Class>("GetEpisodeActionByObjectID", EpisodeAction.GetEpisodeActionByObjectID((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.Klinik.EPISODEACTION.CalcValue)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new IslemlerGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class IslemlerGroupBody : TTReportSection
            {
                public EndOfDayPoliclinicReport MyParentReport
                {
                    get { return (EndOfDayPoliclinicReport)ParentReport; }
                }
                
                public TTReportField ISLEMNO;
                public TTReportField ISLEMADIMI;
                public TTReportField ISLEMACIKLAMASI;
                public TTReportField ISLEMTARIHI;
                public TTReportField OBJDISPLAYTEXT;
                public TTReportField OBJDESCRIPTION;
                public TTReportField OBJECTNAME; 
                public IslemlerGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 7;
                    RepeatCount = 0;
                    
                    ISLEMNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 0, 40, 5, false);
                    ISLEMNO.Name = "ISLEMNO";
                    ISLEMNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    ISLEMNO.TextFont.Size = 9;
                    ISLEMNO.TextFont.CharSet = 162;
                    ISLEMNO.Value = @"{#ACTIONID#}";

                    ISLEMADIMI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 0, 111, 5, false);
                    ISLEMADIMI.Name = "ISLEMADIMI";
                    ISLEMADIMI.FieldType = ReportFieldTypeEnum.ftVariable;
                    ISLEMADIMI.TextFont.Size = 9;
                    ISLEMADIMI.TextFont.CharSet = 162;
                    ISLEMADIMI.Value = @"{#CURSTATE#}";

                    ISLEMACIKLAMASI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 118, 0, 168, 5, false);
                    ISLEMACIKLAMASI.Name = "ISLEMACIKLAMASI";
                    ISLEMACIKLAMASI.FieldType = ReportFieldTypeEnum.ftVariable;
                    ISLEMACIKLAMASI.TextFont.Size = 9;
                    ISLEMACIKLAMASI.TextFont.CharSet = 162;
                    ISLEMACIKLAMASI.Value = @"";

                    ISLEMTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 0, 75, 5, false);
                    ISLEMTARIHI.Name = "ISLEMTARIHI";
                    ISLEMTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    ISLEMTARIHI.TextFormat = @"dd/MM/yyyy";
                    ISLEMTARIHI.Value = @"{#ACTIONDATE#}";

                    OBJDISPLAYTEXT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 0, 245, 5, false);
                    OBJDISPLAYTEXT.Name = "OBJDISPLAYTEXT";
                    OBJDISPLAYTEXT.Visible = EvetHayirEnum.ehHayir;
                    OBJDISPLAYTEXT.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBJDISPLAYTEXT.Value = @"{#OBJDISPLAYTEXT#}";

                    OBJDESCRIPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 248, 0, 273, 5, false);
                    OBJDESCRIPTION.Name = "OBJDESCRIPTION";
                    OBJDESCRIPTION.Visible = EvetHayirEnum.ehHayir;
                    OBJDESCRIPTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBJDESCRIPTION.Value = @"{#OBJDESCRIPTION#}";

                    OBJECTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 276, 0, 301, 5, false);
                    OBJECTNAME.Name = "OBJECTNAME";
                    OBJECTNAME.Visible = EvetHayirEnum.ehHayir;
                    OBJECTNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBJECTNAME.Value = @"{#OBJECTNAME#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    EpisodeAction.GetEpisodeActionByObjectID_Class dataset_GetEpisodeActionByObjectID = ParentGroup.rsGroup.GetCurrentRecord<EpisodeAction.GetEpisodeActionByObjectID_Class>(0);
                    ISLEMNO.CalcValue = (dataset_GetEpisodeActionByObjectID != null ? Globals.ToStringCore(dataset_GetEpisodeActionByObjectID.Actionid) : "");
                    ISLEMADIMI.CalcValue = (dataset_GetEpisodeActionByObjectID != null ? Globals.ToStringCore(dataset_GetEpisodeActionByObjectID.Curstate) : "");
                    ISLEMACIKLAMASI.CalcValue = @"";
                    ISLEMTARIHI.CalcValue = (dataset_GetEpisodeActionByObjectID != null ? Globals.ToStringCore(dataset_GetEpisodeActionByObjectID.ActionDate) : "");
                    OBJDISPLAYTEXT.CalcValue = (dataset_GetEpisodeActionByObjectID != null ? Globals.ToStringCore(dataset_GetEpisodeActionByObjectID.Objdisplaytext) : "");
                    OBJDESCRIPTION.CalcValue = (dataset_GetEpisodeActionByObjectID != null ? Globals.ToStringCore(dataset_GetEpisodeActionByObjectID.Objdescription) : "");
                    OBJECTNAME.CalcValue = (dataset_GetEpisodeActionByObjectID != null ? Globals.ToStringCore(dataset_GetEpisodeActionByObjectID.Objectname) : "");
                    return new TTReportObject[] { ISLEMNO,ISLEMADIMI,ISLEMACIKLAMASI,ISLEMTARIHI,OBJDISPLAYTEXT,OBJDESCRIPTION,OBJECTNAME};
                }

                public override void RunScript()
                {
#region ISLEMLER BODY_Script
                    if(this.OBJDISPLAYTEXT.CalcValue != null)
                    {
                        this.ISLEMACIKLAMASI.CalcValue = this.OBJDISPLAYTEXT.CalcValue;
                    }
                    else if (this.OBJDESCRIPTION.CalcValue != null)
                    {
                        this.ISLEMACIKLAMASI.CalcValue = this.OBJDESCRIPTION.CalcValue;
                    }
                    else if (this.OBJECTNAME.CalcValue != null)
                    {
                        this.ISLEMACIKLAMASI.CalcValue = this.OBJECTNAME.CalcValue;
                    }
                    else
                        this.ISLEMACIKLAMASI.CalcValue = "";
#endregion ISLEMLER BODY_Script
                }
            }

        }

        public IslemlerGroup Islemler;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public EndOfDayPoliclinicReport()
        {
            Parent = new ParentGroup(this,"Parent");
            Header = new HeaderGroup(Parent,"Header");
            MASTERRESOURCE = new MASTERRESOURCEGroup(Header,"MASTERRESOURCE");
            Klinik = new KlinikGroup(MASTERRESOURCE,"Klinik");
            OdaGrubu = new OdaGrubuGroup(Klinik,"OdaGrubu");
            MAIN = new MAINGroup(OdaGrubu,"MAIN");
            ONTANI = new ONTANIGroup(OdaGrubu,"ONTANI");
            TANI = new TANIGroup(OdaGrubu,"TANI");
            KARAR = new KARARGroup(OdaGrubu,"KARAR");
            RECETE = new RECETEGroup(OdaGrubu,"RECETE");
            Islem = new IslemGroup(OdaGrubu,"Islem");
            Islemler = new IslemlerGroup(Islem,"Islemler");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STARTDATE", "", "Başlangıç Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENDDATE", "", "Bitiş Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("POLICLINIC", "00000000-0000-0000-0000-000000000000", "Poliklinik", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("cf0f9ec0-906f-4eab-8752-4c8f8e1aec48");
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STARTDATE"))
                _runtimeParameters.STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTDATE"]);
            if (parameters.ContainsKey("ENDDATE"))
                _runtimeParameters.ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ENDDATE"]);
            if (parameters.ContainsKey("POLICLINIC"))
                _runtimeParameters.POLICLINIC = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["POLICLINIC"]);
            Name = "ENDOFDAYPOLICLINICREPORT";
            Caption = "Gün Sonu Poliklinik Raporları";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            PaperSize = 1;
            UserMarginTop = 10;
            p_PageWidth = 216;
            p_PageHeight = 279;
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
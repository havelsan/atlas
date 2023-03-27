
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
    /// Poliklinik Hizmet Detay Raporu
    /// </summary>
    public partial class PoliclinicExaminationDetailReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public Guid? POLICLINIC = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class HeaderGroup : TTReportGroup
        {
            public PoliclinicExaminationDetailReport MyParentReport
            {
                get { return (PoliclinicExaminationDetailReport)ParentReport; }
            }

            new public HeaderGroupHeader Header()
            {
                return (HeaderGroupHeader)_header;
            }

            new public HeaderGroupFooter Footer()
            {
                return (HeaderGroupFooter)_footer;
            }

            public TTReportField NewField { get {return Header().NewField;} }
            public TTReportField XXXXXXBASLIK { get {return Header().XXXXXXBASLIK;} }
            public TTReportField NewField6 { get {return Header().NewField6;} }
            public TTReportField LOGO { get {return Header().LOGO;} }
            public TTReportField NewField191 { get {return Header().NewField191;} }
            public TTReportField NewField1181 { get {return Header().NewField1181;} }
            public TTReportField RDATE { get {return Header().RDATE;} }
            public TTReportField ACIKLAMA { get {return Header().ACIKLAMA;} }
            public TTReportField STARTDATE { get {return Header().STARTDATE;} }
            public TTReportField ENDDATE { get {return Header().ENDDATE;} }
            public HeaderGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public HeaderGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new HeaderGroupHeader(this);
                _footer = new HeaderGroupFooter(this);

            }

            public partial class HeaderGroupHeader : TTReportSection
            {
                public PoliclinicExaminationDetailReport MyParentReport
                {
                    get { return (PoliclinicExaminationDetailReport)ParentReport; }
                }
                
                public TTReportField NewField;
                public TTReportField XXXXXXBASLIK;
                public TTReportField NewField6;
                public TTReportField LOGO;
                public TTReportField NewField191;
                public TTReportField NewField1181;
                public TTReportField RDATE;
                public TTReportField ACIKLAMA;
                public TTReportField STARTDATE;
                public TTReportField ENDDATE; 
                public HeaderGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 63;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 34, 176, 42, false);
                    NewField.Name = "NewField";
                    NewField.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField.TextFont.Size = 15;
                    NewField.TextFont.Bold = true;
                    NewField.TextFont.CharSet = 162;
                    NewField.Value = @"POLİKLİNİK HİZMETİ DETAY RAPORU";

                    XXXXXXBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 10, 176, 33, false);
                    XXXXXXBASLIK.Name = "XXXXXXBASLIK";
                    XXXXXXBASLIK.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXBASLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.NoClip = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.ExpandTabs = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.TextFont.Size = 11;
                    XXXXXXBASLIK.TextFont.Bold = true;
                    XXXXXXBASLIK.TextFont.CharSet = 162;
                    XXXXXXBASLIK.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + ""\r\n"" + TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    NewField6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 46, 43, 52, false);
                    NewField6.Name = "NewField6";
                    NewField6.TextFont.Size = 11;
                    NewField6.TextFont.Bold = true;
                    NewField6.TextFont.Underline = true;
                    NewField6.TextFont.CharSet = 162;
                    NewField6.Value = @"HİZMETE ÖZEL";

                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 10, 50, 30, false);
                    LOGO.Name = "LOGO";
                    LOGO.TextFont.Name = "Courier New";
                    LOGO.Value = @"LOGO";

                    NewField191 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 180, 57, 188, 62, false);
                    NewField191.Name = "NewField191";
                    NewField191.TextFont.Size = 9;
                    NewField191.TextFont.Bold = true;
                    NewField191.TextFont.CharSet = 162;
                    NewField191.Value = @"Tarih";

                    NewField1181 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 188, 57, 191, 62, false);
                    NewField1181.Name = "NewField1181";
                    NewField1181.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1181.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1181.TextFont.Bold = true;
                    NewField1181.TextFont.CharSet = 162;
                    NewField1181.Value = @":";

                    RDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 191, 57, 207, 62, false);
                    RDATE.Name = "RDATE";
                    RDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    RDATE.TextFormat = @"dd/MM/yyyy";
                    RDATE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    RDATE.TextFont.Size = 9;
                    RDATE.TextFont.CharSet = 162;
                    RDATE.Value = @"{@printdate@}";

                    ACIKLAMA = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 43, 176, 48, false);
                    ACIKLAMA.Name = "ACIKLAMA";
                    ACIKLAMA.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACIKLAMA.TextFormat = @"dd/MM/yyyy";
                    ACIKLAMA.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ACIKLAMA.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ACIKLAMA.TextFont.CharSet = 162;
                    ACIKLAMA.Value = @"{%STARTDATE%} - {%ENDDATE%} Arasındaki Muayeneler";

                    STARTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 223, 17, 239, 22, false);
                    STARTDATE.Name = "STARTDATE";
                    STARTDATE.Visible = EvetHayirEnum.ehHayir;
                    STARTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STARTDATE.TextFormat = @"dd/MM/yyyy";
                    STARTDATE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    STARTDATE.TextFont.Size = 9;
                    STARTDATE.TextFont.CharSet = 162;
                    STARTDATE.Value = @"{@STARTDATE@}";

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 223, 23, 239, 28, false);
                    ENDDATE.Name = "ENDDATE";
                    ENDDATE.Visible = EvetHayirEnum.ehHayir;
                    ENDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ENDDATE.TextFormat = @"dd/MM/yyyy";
                    ENDDATE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    ENDDATE.TextFont.Size = 9;
                    ENDDATE.TextFont.CharSet = 162;
                    ENDDATE.Value = @"{@ENDDATE@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField.CalcValue = NewField.Value;
                    NewField6.CalcValue = NewField6.Value;
                    LOGO.CalcValue = LOGO.Value;
                    NewField191.CalcValue = NewField191.Value;
                    NewField1181.CalcValue = NewField1181.Value;
                    RDATE.CalcValue = DateTime.Now.ToShortDateString();
                    STARTDATE.CalcValue = MyParentReport.RuntimeParameters.STARTDATE.ToString();
                    ENDDATE.CalcValue = MyParentReport.RuntimeParameters.ENDDATE.ToString();
                    ACIKLAMA.CalcValue = MyParentReport.Header.STARTDATE.FormattedValue + @" - " + MyParentReport.Header.ENDDATE.FormattedValue + @" Arasındaki Muayeneler";
                    XXXXXXBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { NewField,NewField6,LOGO,NewField191,NewField1181,RDATE,STARTDATE,ENDDATE,ACIKLAMA,XXXXXXBASLIK};
                }
            }
            public partial class HeaderGroupFooter : TTReportSection
            {
                public PoliclinicExaminationDetailReport MyParentReport
                {
                    get { return (PoliclinicExaminationDetailReport)ParentReport; }
                }
                 
                public HeaderGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    RepeatCount = 0;
                    
                }
                
            }

        }

        public HeaderGroup Header;

        public partial class KlinikGroup : TTReportGroup
        {
            public PoliclinicExaminationDetailReport MyParentReport
            {
                get { return (PoliclinicExaminationDetailReport)ParentReport; }
            }

            new public KlinikGroupHeader Header()
            {
                return (KlinikGroupHeader)_header;
            }

            new public KlinikGroupFooter Footer()
            {
                return (KlinikGroupFooter)_footer;
            }

            public TTReportField MASTERRESOURCE { get {return Header().MASTERRESOURCE;} }
            public TTReportField LBLTCNO1 { get {return Header().LBLTCNO1;} }
            public TTReportField LBLHASTAADISOYADI1 { get {return Header().LBLHASTAADISOYADI1;} }
            public TTReportField LBLTIBBIPROTOKOLNO1 { get {return Header().LBLTIBBIPROTOKOLNO1;} }
            public TTReportField LBLHASTAADISOYADI111 { get {return Header().LBLHASTAADISOYADI111;} }
            public TTReportField LBLHASTAADISOYADI1111 { get {return Header().LBLHASTAADISOYADI1111;} }
            public TTReportField LBLHASTAADISOYADI11111 { get {return Header().LBLHASTAADISOYADI11111;} }
            public TTReportField LBLSIRANO1 { get {return Header().LBLSIRANO1;} }
            public TTReportShape NewLine1 { get {return Footer().NewLine1;} }
            public KlinikGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public KlinikGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<EpisodeAction.GetPoliclinicExaminationDetail_Class>("GetPoliclinicExaminationDetail", EpisodeAction.GetPoliclinicExaminationDetail((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE),(Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.POLICLINIC)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new KlinikGroupHeader(this);
                _footer = new KlinikGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class KlinikGroupHeader : TTReportSection
            {
                public PoliclinicExaminationDetailReport MyParentReport
                {
                    get { return (PoliclinicExaminationDetailReport)ParentReport; }
                }
                
                public TTReportField MASTERRESOURCE;
                public TTReportField LBLTCNO1;
                public TTReportField LBLHASTAADISOYADI1;
                public TTReportField LBLTIBBIPROTOKOLNO1;
                public TTReportField LBLHASTAADISOYADI111;
                public TTReportField LBLHASTAADISOYADI1111;
                public TTReportField LBLHASTAADISOYADI11111;
                public TTReportField LBLSIRANO1; 
                public KlinikGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 13;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    MASTERRESOURCE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 1, 207, 6, false);
                    MASTERRESOURCE.Name = "MASTERRESOURCE";
                    MASTERRESOURCE.FieldType = ReportFieldTypeEnum.ftVariable;
                    MASTERRESOURCE.ObjectDefName = "Resource";
                    MASTERRESOURCE.DataMember = "NAME";
                    MASTERRESOURCE.TextFont.Size = 11;
                    MASTERRESOURCE.TextFont.Bold = true;
                    MASTERRESOURCE.TextFont.CharSet = 162;
                    MASTERRESOURCE.Value = @"{#MASTERRESOURCE#}";

                    LBLTCNO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 43, 8, 65, 13, false);
                    LBLTCNO1.Name = "LBLTCNO1";
                    LBLTCNO1.TextFont.Size = 9;
                    LBLTCNO1.TextFont.Bold = true;
                    LBLTCNO1.TextFont.CharSet = 162;
                    LBLTCNO1.Value = @"Kimlik No";

                    LBLHASTAADISOYADI1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 66, 8, 102, 13, false);
                    LBLHASTAADISOYADI1.Name = "LBLHASTAADISOYADI1";
                    LBLHASTAADISOYADI1.TextFont.Size = 9;
                    LBLHASTAADISOYADI1.TextFont.Bold = true;
                    LBLHASTAADISOYADI1.TextFont.CharSet = 162;
                    LBLHASTAADISOYADI1.Value = @"Hasta Adı Soyadı ";

                    LBLTIBBIPROTOKOLNO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 19, 8, 42, 13, false);
                    LBLTIBBIPROTOKOLNO1.Name = "LBLTIBBIPROTOKOLNO1";
                    LBLTIBBIPROTOKOLNO1.TextFont.Size = 9;
                    LBLTIBBIPROTOKOLNO1.TextFont.Bold = true;
                    LBLTIBBIPROTOKOLNO1.TextFont.CharSet = 162;
                    LBLTIBBIPROTOKOLNO1.Value = @"XXXXXX Pr.Nu.";

                    LBLHASTAADISOYADI111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 103, 8, 139, 13, false);
                    LBLHASTAADISOYADI111.Name = "LBLHASTAADISOYADI111";
                    LBLHASTAADISOYADI111.TextFont.Size = 9;
                    LBLHASTAADISOYADI111.TextFont.Bold = true;
                    LBLHASTAADISOYADI111.TextFont.CharSet = 162;
                    LBLHASTAADISOYADI111.Value = @"Sorumlu Doktor";

                    LBLHASTAADISOYADI1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 8, 163, 13, false);
                    LBLHASTAADISOYADI1111.Name = "LBLHASTAADISOYADI1111";
                    LBLHASTAADISOYADI1111.TextFont.Size = 9;
                    LBLHASTAADISOYADI1111.TextFont.Bold = true;
                    LBLHASTAADISOYADI1111.TextFont.CharSet = 162;
                    LBLHASTAADISOYADI1111.Value = @"Hasta Grubu";

                    LBLHASTAADISOYADI11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 164, 8, 207, 13, false);
                    LBLHASTAADISOYADI11111.Name = "LBLHASTAADISOYADI11111";
                    LBLHASTAADISOYADI11111.TextFont.Size = 9;
                    LBLHASTAADISOYADI11111.TextFont.Bold = true;
                    LBLHASTAADISOYADI11111.TextFont.CharSet = 162;
                    LBLHASTAADISOYADI11111.Value = @"Muayeneye Gönderen Makam";

                    LBLSIRANO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 8, 18, 13, false);
                    LBLSIRANO1.Name = "LBLSIRANO1";
                    LBLSIRANO1.TextFont.Size = 9;
                    LBLSIRANO1.TextFont.Bold = true;
                    LBLSIRANO1.TextFont.CharSet = 162;
                    LBLSIRANO1.Value = @"S. No";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    EpisodeAction.GetPoliclinicExaminationDetail_Class dataset_GetPoliclinicExaminationDetail = ParentGroup.rsGroup.GetCurrentRecord<EpisodeAction.GetPoliclinicExaminationDetail_Class>(0);
                    MASTERRESOURCE.CalcValue = (dataset_GetPoliclinicExaminationDetail != null ? Globals.ToStringCore(dataset_GetPoliclinicExaminationDetail.MasterResource) : "");
                    MASTERRESOURCE.PostFieldValueCalculation();
                    LBLTCNO1.CalcValue = LBLTCNO1.Value;
                    LBLHASTAADISOYADI1.CalcValue = LBLHASTAADISOYADI1.Value;
                    LBLTIBBIPROTOKOLNO1.CalcValue = LBLTIBBIPROTOKOLNO1.Value;
                    LBLHASTAADISOYADI111.CalcValue = LBLHASTAADISOYADI111.Value;
                    LBLHASTAADISOYADI1111.CalcValue = LBLHASTAADISOYADI1111.Value;
                    LBLHASTAADISOYADI11111.CalcValue = LBLHASTAADISOYADI11111.Value;
                    LBLSIRANO1.CalcValue = LBLSIRANO1.Value;
                    return new TTReportObject[] { MASTERRESOURCE,LBLTCNO1,LBLHASTAADISOYADI1,LBLTIBBIPROTOKOLNO1,LBLHASTAADISOYADI111,LBLHASTAADISOYADI1111,LBLHASTAADISOYADI11111,LBLSIRANO1};
                }
            }
            public partial class KlinikGroupFooter : TTReportSection
            {
                public PoliclinicExaminationDetailReport MyParentReport
                {
                    get { return (PoliclinicExaminationDetailReport)ParentReport; }
                }
                
                public TTReportShape NewLine1; 
                public KlinikGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 4;
                    RepeatCount = 0;
                    
                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 2, 208, 2, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    EpisodeAction.GetPoliclinicExaminationDetail_Class dataset_GetPoliclinicExaminationDetail = ParentGroup.rsGroup.GetCurrentRecord<EpisodeAction.GetPoliclinicExaminationDetail_Class>(0);
                    return new TTReportObject[] { };
                }
            }

        }

        public KlinikGroup Klinik;

        public partial class OdaGrubuGroup : TTReportGroup
        {
            public PoliclinicExaminationDetailReport MyParentReport
            {
                get { return (PoliclinicExaminationDetailReport)ParentReport; }
            }

            new public OdaGrubuGroupHeader Header()
            {
                return (OdaGrubuGroupHeader)_header;
            }

            new public OdaGrubuGroupFooter Footer()
            {
                return (OdaGrubuGroupFooter)_footer;
            }

            public TTReportField EPISODE { get {return Header().EPISODE;} }
            public TTReportField COUNTER { get {return Header().COUNTER;} }
            public OdaGrubuGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public OdaGrubuGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override object[] GetGroupByValues()
            {

                EpisodeAction.GetPoliclinicExaminationDetail_Class dataSet_GetPoliclinicExaminationDetail = ParentGroup.rsGroup.GetCurrentRecord<EpisodeAction.GetPoliclinicExaminationDetail_Class>(0);    
                return new object[] {(dataSet_GetPoliclinicExaminationDetail==null ? null : dataSet_GetPoliclinicExaminationDetail.MasterResource)};
            }
            private void onConstruct()
            {
                _body = null;
                _header = new OdaGrubuGroupHeader(this);
                _footer = new OdaGrubuGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstParentRS;
            }

            public partial class OdaGrubuGroupHeader : TTReportSection
            {
                public PoliclinicExaminationDetailReport MyParentReport
                {
                    get { return (PoliclinicExaminationDetailReport)ParentReport; }
                }
                
                public TTReportField EPISODE;
                public TTReportField COUNTER; 
                public OdaGrubuGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 1;
                    IsVisible = EvetHayirEnum.ehHayir;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    EPISODE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 219, 1, 239, 6, false);
                    EPISODE.Name = "EPISODE";
                    EPISODE.Visible = EvetHayirEnum.ehHayir;
                    EPISODE.FieldType = ReportFieldTypeEnum.ftVariable;
                    EPISODE.TextFont.Size = 9;
                    EPISODE.TextFont.Bold = true;
                    EPISODE.TextFont.CharSet = 162;
                    EPISODE.Value = @"{#Klinik.EPISODE#}";

                    COUNTER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 240, 1, 248, 6, false);
                    COUNTER.Name = "COUNTER";
                    COUNTER.FieldType = ReportFieldTypeEnum.ftVariable;
                    COUNTER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    COUNTER.TextFont.Size = 9;
                    COUNTER.TextFont.Bold = true;
                    COUNTER.TextFont.CharSet = 162;
                    COUNTER.Value = @"{@groupcounter@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    EpisodeAction.GetPoliclinicExaminationDetail_Class dataset_GetPoliclinicExaminationDetail = MyParentReport.Klinik.rsGroup.GetCurrentRecord<EpisodeAction.GetPoliclinicExaminationDetail_Class>(0);
                    EPISODE.CalcValue = (dataset_GetPoliclinicExaminationDetail != null ? Globals.ToStringCore(dataset_GetPoliclinicExaminationDetail.Episode) : "");
                    COUNTER.CalcValue = ParentGroup.GroupCounter.ToString();
                    return new TTReportObject[] { EPISODE,COUNTER};
                }
            }
            public partial class OdaGrubuGroupFooter : TTReportSection
            {
                public PoliclinicExaminationDetailReport MyParentReport
                {
                    get { return (PoliclinicExaminationDetailReport)ParentReport; }
                }
                 
                public OdaGrubuGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 2;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public OdaGrubuGroup OdaGrubu;

        public partial class MAINGroup : TTReportGroup
        {
            public PoliclinicExaminationDetailReport MyParentReport
            {
                get { return (PoliclinicExaminationDetailReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField HPROTOKOLNO { get {return Body().HPROTOKOLNO;} }
            public TTReportField KIMLIKNO { get {return Body().KIMLIKNO;} }
            public TTReportField HASTAADISOYADI { get {return Body().HASTAADISOYADI;} }
            public TTReportField HASTASOYADI { get {return Body().HASTASOYADI;} }
            public TTReportField HASTAADI { get {return Body().HASTAADI;} }
            public TTReportField TCNO { get {return Body().TCNO;} }
            public TTReportField FNO { get {return Body().FNO;} }
            public TTReportField PROCEDUREDOCTOR { get {return Body().PROCEDUREDOCTOR;} }
            public TTReportField PATIENTGROUP { get {return Body().PATIENTGROUP;} }
            public TTReportField SENDERCHAIR { get {return Body().SENDERCHAIR;} }
            public TTReportField COUNTER1 { get {return Body().COUNTER1;} }
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
                public PoliclinicExaminationDetailReport MyParentReport
                {
                    get { return (PoliclinicExaminationDetailReport)ParentReport; }
                }
                
                public TTReportField HPROTOKOLNO;
                public TTReportField KIMLIKNO;
                public TTReportField HASTAADISOYADI;
                public TTReportField HASTASOYADI;
                public TTReportField HASTAADI;
                public TTReportField TCNO;
                public TTReportField FNO;
                public TTReportField PROCEDUREDOCTOR;
                public TTReportField PATIENTGROUP;
                public TTReportField SENDERCHAIR;
                public TTReportField COUNTER1; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 7;
                    RepeatCount = 0;
                    
                    HPROTOKOLNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 19, 1, 42, 6, false);
                    HPROTOKOLNO.Name = "HPROTOKOLNO";
                    HPROTOKOLNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    HPROTOKOLNO.TextFont.Size = 9;
                    HPROTOKOLNO.TextFont.CharSet = 162;
                    HPROTOKOLNO.Value = @"{#Klinik.HPROTOCOLNO#}";

                    KIMLIKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 43, 1, 65, 6, false);
                    KIMLIKNO.Name = "KIMLIKNO";
                    KIMLIKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    KIMLIKNO.TextFont.Size = 9;
                    KIMLIKNO.TextFont.CharSet = 162;
                    KIMLIKNO.Value = @"";

                    HASTAADISOYADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 66, 1, 102, 6, false);
                    HASTAADISOYADI.Name = "HASTAADISOYADI";
                    HASTAADISOYADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTAADISOYADI.TextFont.Size = 9;
                    HASTAADISOYADI.TextFont.CharSet = 162;
                    HASTAADISOYADI.Value = @"{%HASTAADI%} {%HASTASOYADI%}";

                    HASTASOYADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 254, 2, 290, 7, false);
                    HASTASOYADI.Name = "HASTASOYADI";
                    HASTASOYADI.Visible = EvetHayirEnum.ehHayir;
                    HASTASOYADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTASOYADI.TextFont.Size = 9;
                    HASTASOYADI.TextFont.CharSet = 162;
                    HASTASOYADI.Value = @"{#Klinik.HASTASOYADI#}";

                    HASTAADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 218, 2, 254, 7, false);
                    HASTAADI.Name = "HASTAADI";
                    HASTAADI.Visible = EvetHayirEnum.ehHayir;
                    HASTAADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTAADI.TextFont.Size = 9;
                    HASTAADI.TextFont.CharSet = 162;
                    HASTAADI.Value = @"{#Klinik.HASTAADI#}";

                    TCNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 291, 2, 327, 7, false);
                    TCNO.Name = "TCNO";
                    TCNO.Visible = EvetHayirEnum.ehHayir;
                    TCNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    TCNO.TextFont.Size = 9;
                    TCNO.TextFont.CharSet = 162;
                    TCNO.Value = @"{#Klinik.TCNO#}";

                    FNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 328, 2, 364, 7, false);
                    FNO.Name = "FNO";
                    FNO.Visible = EvetHayirEnum.ehHayir;
                    FNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    FNO.TextFont.Size = 9;
                    FNO.TextFont.CharSet = 162;
                    FNO.Value = @"{#Klinik.FNO#}";

                    PROCEDUREDOCTOR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 103, 1, 139, 6, false);
                    PROCEDUREDOCTOR.Name = "PROCEDUREDOCTOR";
                    PROCEDUREDOCTOR.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROCEDUREDOCTOR.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PROCEDUREDOCTOR.TextFont.Size = 9;
                    PROCEDUREDOCTOR.TextFont.CharSet = 162;
                    PROCEDUREDOCTOR.Value = @"{#Klinik.PROCEDUREDOCTORNAME#}";

                    PATIENTGROUP = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 1, 163, 6, false);
                    PATIENTGROUP.Name = "PATIENTGROUP";
                    PATIENTGROUP.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATIENTGROUP.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PATIENTGROUP.ObjectDefName = "PatientGroupEnum";
                    PATIENTGROUP.DataMember = "DISPLAYTEXT";
                    PATIENTGROUP.TextFont.Size = 9;
                    PATIENTGROUP.TextFont.CharSet = 162;
                    PATIENTGROUP.Value = @"{#Klinik.PATIENTGROUP#}";

                    SENDERCHAIR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 164, 1, 207, 6, false);
                    SENDERCHAIR.Name = "SENDERCHAIR";
                    SENDERCHAIR.FieldType = ReportFieldTypeEnum.ftVariable;
                    SENDERCHAIR.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SENDERCHAIR.TextFont.Size = 9;
                    SENDERCHAIR.TextFont.CharSet = 162;
                    SENDERCHAIR.Value = @"";

                    COUNTER1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 1, 18, 6, false);
                    COUNTER1.Name = "COUNTER1";
                    COUNTER1.FieldType = ReportFieldTypeEnum.ftVariable;
                    COUNTER1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    COUNTER1.TextFont.Size = 9;
                    COUNTER1.TextFont.Bold = true;
                    COUNTER1.TextFont.CharSet = 162;
                    COUNTER1.Value = @"{%OdaGrubu.COUNTER%}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    EpisodeAction.GetPoliclinicExaminationDetail_Class dataset_GetPoliclinicExaminationDetail = MyParentReport.Klinik.rsGroup.GetCurrentRecord<EpisodeAction.GetPoliclinicExaminationDetail_Class>(0);
                    HPROTOKOLNO.CalcValue = (dataset_GetPoliclinicExaminationDetail != null ? Globals.ToStringCore(dataset_GetPoliclinicExaminationDetail.Hprotocolno) : "");
                    KIMLIKNO.CalcValue = @"";
                    HASTAADI.CalcValue = (dataset_GetPoliclinicExaminationDetail != null ? Globals.ToStringCore(dataset_GetPoliclinicExaminationDetail.Hastaadi) : "");
                    HASTASOYADI.CalcValue = (dataset_GetPoliclinicExaminationDetail != null ? Globals.ToStringCore(dataset_GetPoliclinicExaminationDetail.Hastasoyadi) : "");
                    HASTAADISOYADI.CalcValue = MyParentReport.MAIN.HASTAADI.CalcValue + @" " + MyParentReport.MAIN.HASTASOYADI.CalcValue;
                    TCNO.CalcValue = (dataset_GetPoliclinicExaminationDetail != null ? Globals.ToStringCore(dataset_GetPoliclinicExaminationDetail.Tcno) : "");
                    FNO.CalcValue = (dataset_GetPoliclinicExaminationDetail != null ? Globals.ToStringCore(dataset_GetPoliclinicExaminationDetail.Fno) : "");
                    PROCEDUREDOCTOR.CalcValue = (dataset_GetPoliclinicExaminationDetail != null ? Globals.ToStringCore(dataset_GetPoliclinicExaminationDetail.Proceduredoctorname) : "");
                    PATIENTGROUP.CalcValue = (dataset_GetPoliclinicExaminationDetail != null ? Globals.ToStringCore(dataset_GetPoliclinicExaminationDetail.Patientgroup) : "");
                    PATIENTGROUP.PostFieldValueCalculation();
                    SENDERCHAIR.CalcValue = @"";
                    COUNTER1.CalcValue = MyParentReport.OdaGrubu.COUNTER.CalcValue;
                    return new TTReportObject[] { HPROTOKOLNO,KIMLIKNO,HASTAADI,HASTASOYADI,HASTAADISOYADI,TCNO,FNO,PROCEDUREDOCTOR,PATIENTGROUP,SENDERCHAIR,COUNTER1};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    string tcno = this.TCNO.CalcValue;
            string fno = this.FNO.CalcValue;
            if(String.IsNullOrEmpty(fno) == false)
                this.KIMLIKNO.CalcValue = "(*)" + fno;
            else
                this.KIMLIKNO.CalcValue = tcno;
#endregion MAIN BODY_Script
                }
            }

        }

        public MAINGroup MAIN;

        public partial class TANIKARARGroup : TTReportGroup
        {
            public PoliclinicExaminationDetailReport MyParentReport
            {
                get { return (PoliclinicExaminationDetailReport)ParentReport; }
            }

            new public TANIKARARGroupBody Body()
            {
                return (TANIKARARGroupBody)_body;
            }
            public TTReportField TANIKARAR { get {return Body().TANIKARAR;} }
            public TTReportField EPISODE { get {return Body().EPISODE;} }
            public TANIKARARGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public TANIKARARGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override object[] GetGroupByValues()
            {

                EpisodeAction.GetPoliclinicExaminationDetail_Class dataSet_GetPoliclinicExaminationDetail = ParentGroup.rsGroup.GetCurrentRecord<EpisodeAction.GetPoliclinicExaminationDetail_Class>(0);    
                return new object[] {(dataSet_GetPoliclinicExaminationDetail==null ? null : dataSet_GetPoliclinicExaminationDetail.Episode)};
            }
            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new TANIKARARGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstParentRS;
            }

            public partial class TANIKARARGroupBody : TTReportSection
            {
                public PoliclinicExaminationDetailReport MyParentReport
                {
                    get { return (PoliclinicExaminationDetailReport)ParentReport; }
                }
                
                public TTReportField TANIKARAR;
                public TTReportField EPISODE; 
                public TANIKARARGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 6;
                    RepeatCount = 0;
                    
                    TANIKARAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 19, 1, 207, 6, false);
                    TANIKARAR.Name = "TANIKARAR";
                    TANIKARAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    TANIKARAR.MultiLine = EvetHayirEnum.ehEvet;
                    TANIKARAR.NoClip = EvetHayirEnum.ehEvet;
                    TANIKARAR.WordBreak = EvetHayirEnum.ehEvet;
                    TANIKARAR.ExpandTabs = EvetHayirEnum.ehEvet;
                    TANIKARAR.Value = @"";

                    EPISODE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 219, 1, 239, 6, false);
                    EPISODE.Name = "EPISODE";
                    EPISODE.Visible = EvetHayirEnum.ehHayir;
                    EPISODE.FieldType = ReportFieldTypeEnum.ftVariable;
                    EPISODE.TextFont.Size = 9;
                    EPISODE.TextFont.Bold = true;
                    EPISODE.TextFont.CharSet = 162;
                    EPISODE.Value = @"{#Klinik.EPISODE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    EpisodeAction.GetPoliclinicExaminationDetail_Class dataset_GetPoliclinicExaminationDetail = MyParentReport.Klinik.rsGroup.GetCurrentRecord<EpisodeAction.GetPoliclinicExaminationDetail_Class>(0);
                    TANIKARAR.CalcValue = @"";
                    EPISODE.CalcValue = (dataset_GetPoliclinicExaminationDetail != null ? Globals.ToStringCore(dataset_GetPoliclinicExaminationDetail.Episode) : "");
                    return new TTReportObject[] { TANIKARAR,EPISODE};
                }

                public override void RunScript()
                {
#region TANIKARAR BODY_Script
                    string episodeObjectID = this.EPISODE.CalcValue;
            if(Globals.IsGuid(episodeObjectID))
            {
                TTObjectContext context = new TTObjectContext(true);
                Episode episode = (Episode)context.GetObject(new Guid(episodeObjectID),"Episode");
                string taniKarar = String.Empty;
                if(episode.TreatmentDischarges.Count>0)
                {
                    taniKarar = "KARAR : \r\n";
                    foreach(TreatmentDischarge treatmentDischarge in episode.TreatmentDischarges)
                    {
                        taniKarar += TTObjectClasses.Common.GetTextOfRTFString(treatmentDischarge.Conclusion.ToString()) + "\r\n";
                    }
                }
                
                if(episode.SecDiagnosis.Count>0)
                {
                    taniKarar += "TANILAR : \r\n";
                    int cnt = 1;
                    foreach( DiagnosisGrid diagnosis in episode.SecDiagnosis)
                    {
                        taniKarar += cnt.ToString() + ". " + diagnosis.Diagnose.Code + "-" +  diagnosis.Diagnose.Name + "\r\n";
                        cnt++;
                    }
                }
                
                this.TANIKARAR.CalcValue = taniKarar;
            }
#endregion TANIKARAR BODY_Script
                }
            }

        }

        public TANIKARARGroup TANIKARAR;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public PoliclinicExaminationDetailReport()
        {
            Header = new HeaderGroup(this,"Header");
            Klinik = new KlinikGroup(Header,"Klinik");
            OdaGrubu = new OdaGrubuGroup(Klinik,"OdaGrubu");
            MAIN = new MAINGroup(OdaGrubu,"MAIN");
            TANIKARAR = new TANIKARARGroup(OdaGrubu,"TANIKARAR");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STARTDATE", "", "Başlangıç Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENDDATE", "", "Bitiş Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("POLICLINIC", "00000000-0000-0000-0000-000000000000", "Poliklinik", @"", false, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
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
            Name = "POLICLINICEXAMINATIONDETAILREPORT";
            Caption = "Poliklinik Hizmet Detay Raporu";
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

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
    /// Sağlık Kurulu Fihrist
    /// </summary>
    public partial class HealthCommitteeShortBook : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public HealthCommitteeTypeEnum? HEALTHCOMITEETYPE = (HealthCommitteeTypeEnum?)(int?)TTObjectDefManager.Instance.DataTypes["HealthCommitteeTypeEnum"].ConvertValue("");
            public int? HEALTHCOMITEETYPEFLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue("");
            public string UNIQUEREFNO = (string)TTObjectDefManager.Instance.DataTypes["String15"].ConvertValue("");
            public int? UNIQUEREFNOFLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue("");
        }

        public partial class PART2Group : TTReportGroup
        {
            public HealthCommitteeShortBook MyParentReport
            {
                get { return (HealthCommitteeShortBook)ParentReport; }
            }

            new public PART2GroupHeader Header()
            {
                return (PART2GroupHeader)_header;
            }

            new public PART2GroupFooter Footer()
            {
                return (PART2GroupFooter)_footer;
            }

            public TTReportField STARTDATE { get {return Header().STARTDATE;} }
            public TTReportField ENDDATE { get {return Header().ENDDATE;} }
            public PART2Group(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PART2Group(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PART2GroupHeader(this);
                _footer = new PART2GroupFooter(this);

            }

            public partial class PART2GroupHeader : TTReportSection
            {
                public HealthCommitteeShortBook MyParentReport
                {
                    get { return (HealthCommitteeShortBook)ParentReport; }
                }
                
                public TTReportField STARTDATE;
                public TTReportField ENDDATE; 
                public PART2GroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 9;
                    IsVisible = EvetHayirEnum.ehHayir;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    STARTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 28, 3, 55, 8, false);
                    STARTDATE.Name = "STARTDATE";
                    STARTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STARTDATE.TextFormat = @"Short Date";
                    STARTDATE.Value = @"{@STARTDATE@}";

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 57, 3, 81, 8, false);
                    ENDDATE.Name = "ENDDATE";
                    ENDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ENDDATE.TextFormat = @"Short Date";
                    ENDDATE.Value = @"{@ENDDATE@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    STARTDATE.CalcValue = MyParentReport.RuntimeParameters.STARTDATE.ToString();
                    ENDDATE.CalcValue = MyParentReport.RuntimeParameters.ENDDATE.ToString();
                    return new TTReportObject[] { STARTDATE,ENDDATE};
                }

                public override void RunScript()
                {
#region PART2 HEADER_Script
                    if (((HealthCommitteeShortBook)ParentReport).RuntimeParameters.UNIQUEREFNO == "")
                ((HealthCommitteeShortBook)ParentReport).RuntimeParameters.UNIQUEREFNOFLAG = 0;
            else
                ((HealthCommitteeShortBook)ParentReport).RuntimeParameters.UNIQUEREFNOFLAG = 1;
            
            ((HealthCommitteeShortBook)ParentReport).RuntimeParameters.STARTDATE = Convert.ToDateTime(STARTDATE.FormattedValue + " 00:00:00");
            ((HealthCommitteeShortBook)ParentReport).RuntimeParameters.ENDDATE = Convert.ToDateTime(ENDDATE.FormattedValue + " 23:59:59");
            
            ((HealthCommitteeShortBook)ParentReport).RuntimeParameters.HEALTHCOMITEETYPEFLAG = ((HealthCommitteeShortBook)ParentReport).RuntimeParameters.HEALTHCOMITEETYPE == null ? 0 : 1;
            
            // NQL de hata vermemesi için bu şekilde herhangi bir değere set ediliyor
            if(((HealthCommitteeShortBook)ParentReport).RuntimeParameters.HEALTHCOMITEETYPEFLAG == 0)
                ((HealthCommitteeShortBook)ParentReport).RuntimeParameters.HEALTHCOMITEETYPE = HealthCommitteeTypeEnum.NormalCommittee;
#endregion PART2 HEADER_Script
                }
            }
            public partial class PART2GroupFooter : TTReportSection
            {
                public HealthCommitteeShortBook MyParentReport
                {
                    get { return (HealthCommitteeShortBook)ParentReport; }
                }
                 
                public PART2GroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 3;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PART2Group PART2;

        public partial class PART1Group : TTReportGroup
        {
            public HealthCommitteeShortBook MyParentReport
            {
                get { return (HealthCommitteeShortBook)ParentReport; }
            }

            new public PART1GroupHeader Header()
            {
                return (PART1GroupHeader)_header;
            }

            new public PART1GroupFooter Footer()
            {
                return (PART1GroupFooter)_footer;
            }

            public TTReportField BASLIK { get {return Header().BASLIK;} }
            public TTReportField NewField13 { get {return Header().NewField13;} }
            public TTReportField STARTDATE { get {return Header().STARTDATE;} }
            public TTReportField NewField122 { get {return Header().NewField122;} }
            public TTReportField ENDDATE { get {return Header().ENDDATE;} }
            public TTReportField NewField1122 { get {return Header().NewField1122;} }
            public TTReportField NewField11211 { get {return Header().NewField11211;} }
            public TTReportField NewField111211 { get {return Header().NewField111211;} }
            public TTReportField NewField1111121111 { get {return Header().NewField1111121111;} }
            public TTReportField NewField1211121111 { get {return Header().NewField1211121111;} }
            public TTReportShape NewLine11 { get {return Header().NewLine11;} }
            public TTReportField NewField1221 { get {return Header().NewField1221;} }
            public TTReportField NewField11221 { get {return Header().NewField11221;} }
            public TTReportField NewField17 { get {return Header().NewField17;} }
            public TTReportField UNIQUEREFNOLBL1 { get {return Header().UNIQUEREFNOLBL1;} }
            public TTReportField UNIQUEREFNO { get {return Header().UNIQUEREFNO;} }
            public TTReportField UNIQUEREFNOLBL2 { get {return Header().UNIQUEREFNOLBL2;} }
            public TTReportField HCTYPELBL1 { get {return Header().HCTYPELBL1;} }
            public TTReportField HCTYPE { get {return Header().HCTYPE;} }
            public TTReportField HCTYPELBL2 { get {return Header().HCTYPELBL2;} }
            public PART1Group(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PART1Group(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PART1GroupHeader(this);
                _footer = new PART1GroupFooter(this);

            }

            public partial class PART1GroupHeader : TTReportSection
            {
                public HealthCommitteeShortBook MyParentReport
                {
                    get { return (HealthCommitteeShortBook)ParentReport; }
                }
                
                public TTReportField BASLIK;
                public TTReportField NewField13;
                public TTReportField STARTDATE;
                public TTReportField NewField122;
                public TTReportField ENDDATE;
                public TTReportField NewField1122;
                public TTReportField NewField11211;
                public TTReportField NewField111211;
                public TTReportField NewField1111121111;
                public TTReportField NewField1211121111;
                public TTReportShape NewLine11;
                public TTReportField NewField1221;
                public TTReportField NewField11221;
                public TTReportField NewField17;
                public TTReportField UNIQUEREFNOLBL1;
                public TTReportField UNIQUEREFNO;
                public TTReportField UNIQUEREFNOLBL2;
                public TTReportField HCTYPELBL1;
                public TTReportField HCTYPE;
                public TTReportField HCTYPELBL2; 
                public PART1GroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 51;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    BASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 15, 196, 22, false);
                    BASLIK.Name = "BASLIK";
                    BASLIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    BASLIK.CaseFormat = CaseFormatEnum.fcUpperCase;
                    BASLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BASLIK.MultiLine = EvetHayirEnum.ehEvet;
                    BASLIK.NoClip = EvetHayirEnum.ehEvet;
                    BASLIK.WordBreak = EvetHayirEnum.ehEvet;
                    BASLIK.ExpandTabs = EvetHayirEnum.ehEvet;
                    BASLIK.TextFont.Size = 12;
                    BASLIK.TextFont.Bold = true;
                    BASLIK.TextFont.CharSet = 162;
                    BASLIK.Value = @"";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 23, 34, 28, false);
                    NewField13.Name = "NewField13";
                    NewField13.TextFont.Bold = true;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @"Başlangıç Tarihi";

                    STARTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 23, 89, 28, false);
                    STARTDATE.Name = "STARTDATE";
                    STARTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STARTDATE.TextFormat = @"Short Date";
                    STARTDATE.Value = @"{@STARTDATE@}";

                    NewField122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 28, 34, 33, false);
                    NewField122.Name = "NewField122";
                    NewField122.TextFont.Bold = true;
                    NewField122.TextFont.CharSet = 162;
                    NewField122.Value = @"Bitiş Tarihi";

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 28, 89, 33, false);
                    ENDDATE.Name = "ENDDATE";
                    ENDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ENDDATE.TextFormat = @"Short Date";
                    ENDDATE.Value = @"{@ENDDATE@}";

                    NewField1122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 45, 22, 49, false);
                    NewField1122.Name = "NewField1122";
                    NewField1122.TextFont.Bold = true;
                    NewField1122.TextFont.CharSet = 162;
                    NewField1122.Value = @"Sıra No";

                    NewField11211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 148, 45, 173, 49, false);
                    NewField11211.Name = "NewField11211";
                    NewField11211.TextFont.Bold = true;
                    NewField11211.TextFont.CharSet = 162;
                    NewField11211.Value = @"Rapor Nu";

                    NewField111211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 175, 45, 196, 49, false);
                    NewField111211.Name = "NewField111211";
                    NewField111211.TextFont.Bold = true;
                    NewField111211.TextFont.CharSet = 162;
                    NewField111211.Value = @"Rapor Tarihi";

                    NewField1111121111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 24, 45, 90, 49, false);
                    NewField1111121111.Name = "NewField1111121111";
                    NewField1111121111.TextFont.Bold = true;
                    NewField1111121111.TextFont.CharSet = 162;
                    NewField1111121111.Value = @"Adı Soyadı";

                    NewField1211121111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 123, 45, 146, 49, false);
                    NewField1211121111.Name = "NewField1211121111";
                    NewField1211121111.TextFont.Bold = true;
                    NewField1211121111.TextFont.CharSet = 162;
                    NewField1211121111.Value = @"H.Protokol Nu";

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 50, 196, 50, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField1221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 28, 36, 33, false);
                    NewField1221.Name = "NewField1221";
                    NewField1221.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1221.TextFont.Bold = true;
                    NewField1221.TextFont.CharSet = 162;
                    NewField1221.Value = @":";

                    NewField11221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 23, 36, 28, false);
                    NewField11221.Name = "NewField11221";
                    NewField11221.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11221.TextFont.Bold = true;
                    NewField11221.TextFont.CharSet = 162;
                    NewField11221.Value = @":";

                    NewField17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 92, 45, 121, 49, false);
                    NewField17.Name = "NewField17";
                    NewField17.TextFont.Bold = true;
                    NewField17.TextFont.CharSet = 162;
                    NewField17.Value = @"TC Kimlik Nu";

                    UNIQUEREFNOLBL1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 38, 34, 43, false);
                    UNIQUEREFNOLBL1.Name = "UNIQUEREFNOLBL1";
                    UNIQUEREFNOLBL1.TextFont.Bold = true;
                    UNIQUEREFNOLBL1.TextFont.CharSet = 162;
                    UNIQUEREFNOLBL1.Value = @"TC Kimlik Nu";

                    UNIQUEREFNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 38, 89, 43, false);
                    UNIQUEREFNO.Name = "UNIQUEREFNO";
                    UNIQUEREFNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNIQUEREFNO.Value = @"{@UNIQUEREFNO@}";

                    UNIQUEREFNOLBL2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 38, 36, 43, false);
                    UNIQUEREFNOLBL2.Name = "UNIQUEREFNOLBL2";
                    UNIQUEREFNOLBL2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    UNIQUEREFNOLBL2.TextFont.Bold = true;
                    UNIQUEREFNOLBL2.TextFont.CharSet = 162;
                    UNIQUEREFNOLBL2.Value = @":";

                    HCTYPELBL1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 33, 34, 38, false);
                    HCTYPELBL1.Name = "HCTYPELBL1";
                    HCTYPELBL1.TextFont.Bold = true;
                    HCTYPELBL1.TextFont.CharSet = 162;
                    HCTYPELBL1.Value = @"Sağlık Kurulu Tipi";

                    HCTYPE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 33, 146, 38, false);
                    HCTYPE.Name = "HCTYPE";
                    HCTYPE.FieldType = ReportFieldTypeEnum.ftVariable;
                    HCTYPE.ObjectDefName = "HealthCommitteeTypeEnum";
                    HCTYPE.DataMember = "DISPLAYTEXT";
                    HCTYPE.Value = @"{@HEALTHCOMITEETYPE@}";

                    HCTYPELBL2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 33, 36, 38, false);
                    HCTYPELBL2.Name = "HCTYPELBL2";
                    HCTYPELBL2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HCTYPELBL2.TextFont.Bold = true;
                    HCTYPELBL2.TextFont.CharSet = 162;
                    HCTYPELBL2.Value = @":";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    BASLIK.CalcValue = @"";
                    NewField13.CalcValue = NewField13.Value;
                    STARTDATE.CalcValue = MyParentReport.RuntimeParameters.STARTDATE.ToString();
                    NewField122.CalcValue = NewField122.Value;
                    ENDDATE.CalcValue = MyParentReport.RuntimeParameters.ENDDATE.ToString();
                    NewField1122.CalcValue = NewField1122.Value;
                    NewField11211.CalcValue = NewField11211.Value;
                    NewField111211.CalcValue = NewField111211.Value;
                    NewField1111121111.CalcValue = NewField1111121111.Value;
                    NewField1211121111.CalcValue = NewField1211121111.Value;
                    NewField1221.CalcValue = NewField1221.Value;
                    NewField11221.CalcValue = NewField11221.Value;
                    NewField17.CalcValue = NewField17.Value;
                    UNIQUEREFNOLBL1.CalcValue = UNIQUEREFNOLBL1.Value;
                    UNIQUEREFNO.CalcValue = MyParentReport.RuntimeParameters.UNIQUEREFNO.ToString();
                    UNIQUEREFNOLBL2.CalcValue = UNIQUEREFNOLBL2.Value;
                    HCTYPELBL1.CalcValue = HCTYPELBL1.Value;
                    HCTYPE.CalcValue = MyParentReport.RuntimeParameters.HEALTHCOMITEETYPE.ToString();
                    HCTYPE.PostFieldValueCalculation();
                    HCTYPELBL2.CalcValue = HCTYPELBL2.Value;
                    return new TTReportObject[] { BASLIK,NewField13,STARTDATE,NewField122,ENDDATE,NewField1122,NewField11211,NewField111211,NewField1111121111,NewField1211121111,NewField1221,NewField11221,NewField17,UNIQUEREFNOLBL1,UNIQUEREFNO,UNIQUEREFNOLBL2,HCTYPELBL1,HCTYPE,HCTYPELBL2};
                }

                public override void RunScript()
                {
#region PART1 HEADER_Script
                    TTObjectContext context = new TTObjectContext(true);
            ResHospital hospital = TTObjectClasses.Common.GetCurrentHospital(context);
            
            BASLIK.CalcValue = hospital.Name + " SAĞLIK KURULU FİHRİSTİ";
            
            if (((HealthCommitteeShortBook)ParentReport).RuntimeParameters.UNIQUEREFNO == "")
            {
                UNIQUEREFNOLBL1.Visible = EvetHayirEnum.ehHayir;
                UNIQUEREFNOLBL2.Visible = EvetHayirEnum.ehHayir;
                UNIQUEREFNO.Visible = EvetHayirEnum.ehHayir;
            }
            else
            {
                UNIQUEREFNOLBL1.Visible = EvetHayirEnum.ehEvet;
                UNIQUEREFNOLBL2.Visible = EvetHayirEnum.ehEvet;
                UNIQUEREFNO.Visible = EvetHayirEnum.ehEvet;
            }
            
            if(((HealthCommitteeShortBook)ParentReport).RuntimeParameters.HEALTHCOMITEETYPEFLAG == 0)
            {
                HCTYPELBL1.Visible = EvetHayirEnum.ehHayir;
                HCTYPELBL2.Visible = EvetHayirEnum.ehHayir;
                HCTYPE.Visible = EvetHayirEnum.ehHayir;
            }
            else
            {
                HCTYPELBL1.Visible = EvetHayirEnum.ehEvet;
                HCTYPELBL2.Visible = EvetHayirEnum.ehEvet;
                HCTYPE.Visible = EvetHayirEnum.ehEvet;
            }
#endregion PART1 HEADER_Script
                }
            }
            public partial class PART1GroupFooter : TTReportSection
            {
                public HealthCommitteeShortBook MyParentReport
                {
                    get { return (HealthCommitteeShortBook)ParentReport; }
                }
                 
                public PART1GroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 11;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PART1Group PART1;

        public partial class MAINGroup : TTReportGroup
        {
            public HealthCommitteeShortBook MyParentReport
            {
                get { return (HealthCommitteeShortBook)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField SIRANO { get {return Body().SIRANO;} }
            public TTReportField ADISOYADI { get {return Body().ADISOYADI;} }
            public TTReportField TCKIMLIKNO { get {return Body().TCKIMLIKNO;} }
            public TTReportField HPROTOKOLNO { get {return Body().HPROTOKOLNO;} }
            public TTReportField RAPORNO { get {return Body().RAPORNO;} }
            public TTReportField RAPORTARIHI { get {return Body().RAPORTARIHI;} }
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
                list[0] = new TTReportNqlData<HealthCommittee.GetHCsByDateAndUniqueRefNo_Class>("GetHCsByDateAndUniqueRefNo", HealthCommittee.GetHCsByDateAndUniqueRefNo((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE),(string)TTObjectDefManager.Instance.DataTypes["String15"].ConvertValue(MyParentReport.RuntimeParameters.UNIQUEREFNO),(int)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(MyParentReport.RuntimeParameters.UNIQUEREFNOFLAG),(int)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(MyParentReport.RuntimeParameters.HEALTHCOMITEETYPEFLAG),((HealthCommitteeTypeEnum)TTObjectDefManager.Instance.DataTypes["HealthCommitteeTypeEnum"].EnumValueDefs[MyParentReport.RuntimeParameters.HEALTHCOMITEETYPE.ToString()].EnumValue)));
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
                public HealthCommitteeShortBook MyParentReport
                {
                    get { return (HealthCommitteeShortBook)ParentReport; }
                }
                
                public TTReportField SIRANO;
                public TTReportField ADISOYADI;
                public TTReportField TCKIMLIKNO;
                public TTReportField HPROTOKOLNO;
                public TTReportField RAPORNO;
                public TTReportField RAPORTARIHI; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 5;
                    RepeatCount = 0;
                    
                    SIRANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 0, 22, 5, false);
                    SIRANO.Name = "SIRANO";
                    SIRANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SIRANO.Value = @"{@groupcounter@}";

                    ADISOYADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 24, 0, 90, 5, false);
                    ADISOYADI.Name = "ADISOYADI";
                    ADISOYADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADISOYADI.MultiLine = EvetHayirEnum.ehEvet;
                    ADISOYADI.NoClip = EvetHayirEnum.ehEvet;
                    ADISOYADI.WordBreak = EvetHayirEnum.ehEvet;
                    ADISOYADI.ExpandTabs = EvetHayirEnum.ehEvet;
                    ADISOYADI.Value = @"{#NAME#} {#SURNAME#}";

                    TCKIMLIKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 92, 0, 121, 5, false);
                    TCKIMLIKNO.Name = "TCKIMLIKNO";
                    TCKIMLIKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    TCKIMLIKNO.Value = @"{#UNIQUEREFNO#}";

                    HPROTOKOLNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 123, 0, 146, 5, false);
                    HPROTOKOLNO.Name = "HPROTOKOLNO";
                    HPROTOKOLNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    HPROTOKOLNO.Value = @"{#HOSPITALPROTOCOLNO#}";

                    RAPORNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 148, 0, 173, 5, false);
                    RAPORNO.Name = "RAPORNO";
                    RAPORNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPORNO.Value = @"{#REPORTNO#}";

                    RAPORTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 175, 0, 196, 5, false);
                    RAPORTARIHI.Name = "RAPORTARIHI";
                    RAPORTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPORTARIHI.TextFormat = @"Short Date";
                    RAPORTARIHI.Value = @"{#REPORTDATE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    HealthCommittee.GetHCsByDateAndUniqueRefNo_Class dataset_GetHCsByDateAndUniqueRefNo = ParentGroup.rsGroup.GetCurrentRecord<HealthCommittee.GetHCsByDateAndUniqueRefNo_Class>(0);
                    SIRANO.CalcValue = ParentGroup.GroupCounter.ToString();
                    ADISOYADI.CalcValue = (dataset_GetHCsByDateAndUniqueRefNo != null ? Globals.ToStringCore(dataset_GetHCsByDateAndUniqueRefNo.Name) : "") + @" " + (dataset_GetHCsByDateAndUniqueRefNo != null ? Globals.ToStringCore(dataset_GetHCsByDateAndUniqueRefNo.Surname) : "");
                    TCKIMLIKNO.CalcValue = (dataset_GetHCsByDateAndUniqueRefNo != null ? Globals.ToStringCore(dataset_GetHCsByDateAndUniqueRefNo.UniqueRefNo) : "");
                    HPROTOKOLNO.CalcValue = (dataset_GetHCsByDateAndUniqueRefNo != null ? Globals.ToStringCore(dataset_GetHCsByDateAndUniqueRefNo.HospitalProtocolNo) : "");
                    RAPORNO.CalcValue = (dataset_GetHCsByDateAndUniqueRefNo != null ? Globals.ToStringCore(dataset_GetHCsByDateAndUniqueRefNo.ReportNo) : "");
                    RAPORTARIHI.CalcValue = (dataset_GetHCsByDateAndUniqueRefNo != null ? Globals.ToStringCore(dataset_GetHCsByDateAndUniqueRefNo.ReportDate) : "");
                    return new TTReportObject[] { SIRANO,ADISOYADI,TCKIMLIKNO,HPROTOKOLNO,RAPORNO,RAPORTARIHI};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public HealthCommitteeShortBook()
        {
            PART2 = new PART2Group(this,"PART2");
            PART1 = new PART1Group(PART2,"PART1");
            MAIN = new MAINGroup(PART1,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STARTDATE", "", "Başlangıç Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENDDATE", "", "Bitiş Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("HEALTHCOMITEETYPE", "", "Sağlık Kurulu Tipi", @"", false, true, false, new Guid("50df466d-66a6-4824-8225-2ba9fb6189dc"));
            reportParameter = Parameters.Add("HEALTHCOMITEETYPEFLAG", "", "Sağlık Kurulu Tipi Kontrol", @"", false, false, false, new Guid("e23a630a-eb08-4621-bc97-1fc8fc93ba28"));
            reportParameter = Parameters.Add("UNIQUEREFNO", "", "TC Kimlik No", @"", false, true, false, new Guid("286becbe-2627-4308-8246-33610e93c094"));
            reportParameter = Parameters.Add("UNIQUEREFNOFLAG", "", "TC Kimlik No Kontrol", @"", false, false, false, new Guid("e23a630a-eb08-4621-bc97-1fc8fc93ba28"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STARTDATE"))
                _runtimeParameters.STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTDATE"]);
            if (parameters.ContainsKey("ENDDATE"))
                _runtimeParameters.ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ENDDATE"]);
            if (parameters.ContainsKey("HEALTHCOMITEETYPE"))
                _runtimeParameters.HEALTHCOMITEETYPE = (HealthCommitteeTypeEnum?)(int?)TTObjectDefManager.Instance.DataTypes["HealthCommitteeTypeEnum"].ConvertValue(parameters["HEALTHCOMITEETYPE"]);
            if (parameters.ContainsKey("HEALTHCOMITEETYPEFLAG"))
                _runtimeParameters.HEALTHCOMITEETYPEFLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(parameters["HEALTHCOMITEETYPEFLAG"]);
            if (parameters.ContainsKey("UNIQUEREFNO"))
                _runtimeParameters.UNIQUEREFNO = (string)TTObjectDefManager.Instance.DataTypes["String15"].ConvertValue(parameters["UNIQUEREFNO"]);
            if (parameters.ContainsKey("UNIQUEREFNOFLAG"))
                _runtimeParameters.UNIQUEREFNOFLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(parameters["UNIQUEREFNOFLAG"]);
            Name = "HEALTHCOMMITTEESHORTBOOK";
            Caption = "Sağlık Kurulu Fihrist";
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
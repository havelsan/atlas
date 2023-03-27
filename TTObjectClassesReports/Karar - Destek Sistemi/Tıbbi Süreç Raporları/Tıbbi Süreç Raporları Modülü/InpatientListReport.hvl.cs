
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
    /// Yatan Hasta Listesi
    /// </summary>
    public partial class InpatientListReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? PHYSICALSTATECLINIC = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class InfoGroup : TTReportGroup
        {
            public InpatientListReport MyParentReport
            {
                get { return (InpatientListReport)ParentReport; }
            }

            new public InfoGroupHeader Header()
            {
                return (InfoGroupHeader)_header;
            }

            new public InfoGroupFooter Footer()
            {
                return (InfoGroupFooter)_footer;
            }

            public TTReportShape NewLine111111 { get {return Header().NewLine111111;} }
            public TTReportField CURRENTUSER1 { get {return Footer().CURRENTUSER1;} }
            public TTReportField PrintDate1 { get {return Footer().PrintDate1;} }
            public TTReportField PageNumber1 { get {return Footer().PageNumber1;} }
            public TTReportShape NewLine1111 { get {return Footer().NewLine1111;} }
            public TTReportShape NewLine11111 { get {return Footer().NewLine11111;} }
            public InfoGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public InfoGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new InfoGroupHeader(this);
                _footer = new InfoGroupFooter(this);

            }

            public partial class InfoGroupHeader : TTReportSection
            {
                public InpatientListReport MyParentReport
                {
                    get { return (InpatientListReport)ParentReport; }
                }
                
                public TTReportShape NewLine111111; 
                public InfoGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 10;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewLine111111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 25, 10, 281, 10, false);
                    NewLine111111.Name = "NewLine111111";
                    NewLine111111.ForeColor = System.Drawing.Color.White;
                    NewLine111111.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    return new TTReportObject[] { };
                }
            }
            public partial class InfoGroupFooter : TTReportSection
            {
                public InpatientListReport MyParentReport
                {
                    get { return (InpatientListReport)ParentReport; }
                }
                
                public TTReportField CURRENTUSER1;
                public TTReportField PrintDate1;
                public TTReportField PageNumber1;
                public TTReportShape NewLine1111;
                public TTReportShape NewLine11111; 
                public InfoGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 15;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    CURRENTUSER1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 98, 1, 212, 6, false);
                    CURRENTUSER1.Name = "CURRENTUSER1";
                    CURRENTUSER1.FieldType = ReportFieldTypeEnum.ftExpression;
                    CURRENTUSER1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CURRENTUSER1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CURRENTUSER1.TextFont.Name = "Arial";
                    CURRENTUSER1.TextFont.Size = 8;
                    CURRENTUSER1.TextFont.CharSet = 162;
                    CURRENTUSER1.Value = @"TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : """"";

                    PrintDate1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 1, 50, 6, false);
                    PrintDate1.Name = "PrintDate1";
                    PrintDate1.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate1.TextFormat = @"dd/MM/yyyy";
                    PrintDate1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PrintDate1.TextFont.Name = "Arial";
                    PrintDate1.TextFont.Size = 8;
                    PrintDate1.TextFont.CharSet = 162;
                    PrintDate1.Value = @"{@printdate@}";

                    PageNumber1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 256, 1, 281, 6, false);
                    PageNumber1.Name = "PageNumber1";
                    PageNumber1.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber1.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PageNumber1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PageNumber1.TextFont.Name = "Arial";
                    PageNumber1.TextFont.Size = 8;
                    PageNumber1.TextFont.CharSet = 162;
                    PageNumber1.Value = @"Sayfa Nu:{@pagenumber@}/{@pagecount@}";

                    NewLine1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 24, 1, 282, 1, false);
                    NewLine1111.Name = "NewLine1111";
                    NewLine1111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1111.DrawWidth = 2;

                    NewLine11111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 24, 14, 282, 14, false);
                    NewLine11111.Name = "NewLine11111";
                    NewLine11111.ForeColor = System.Drawing.Color.White;
                    NewLine11111.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PrintDate1.CalcValue = DateTime.Now.ToShortDateString();
                    PageNumber1.CalcValue = @"Sayfa Nu:" + ParentReport.CurrentPageNumber.ToString() + @"/" + ParentReport.ReportTotalPageCount;
                    CURRENTUSER1.CalcValue = TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : "";
                    return new TTReportObject[] { PrintDate1,PageNumber1,CURRENTUSER1};
                }
            }

        }

        public InfoGroup Info;

        public partial class HeaderGroup : TTReportGroup
        {
            public InpatientListReport MyParentReport
            {
                get { return (InpatientListReport)ParentReport; }
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
            public TTReportField LBLToplamYatanHastaSayısı { get {return Footer().LBLToplamYatanHastaSayısı;} }
            public TTReportField HASTASAYISI { get {return Footer().HASTASAYISI;} }
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
                public InpatientListReport MyParentReport
                {
                    get { return (InpatientListReport)ParentReport; }
                }
                
                public TTReportField NewField;
                public TTReportField XXXXXXBASLIK;
                public TTReportField NewField6;
                public TTReportField LOGO; 
                public HeaderGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 51;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 98, 29, 212, 37, false);
                    NewField.Name = "NewField";
                    NewField.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField.TextFont.Size = 15;
                    NewField.TextFont.Bold = true;
                    NewField.TextFont.CharSet = 162;
                    NewField.Value = @"YATAN HASTA LİSTESİ";

                    XXXXXXBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 98, 5, 212, 28, false);
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

                    NewField6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 301, 41, 334, 47, false);
                    NewField6.Name = "NewField6";
                    NewField6.Visible = EvetHayirEnum.ehHayir;
                    NewField6.TextFont.Size = 11;
                    NewField6.TextFont.Bold = true;
                    NewField6.TextFont.Underline = true;
                    NewField6.TextFont.CharSet = 162;
                    NewField6.Value = @"HİZMETE ÖZEL";

                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 5, 65, 25, false);
                    LOGO.Name = "LOGO";
                    LOGO.TextFont.Name = "Courier New";
                    LOGO.Value = @"LOGO";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField.CalcValue = NewField.Value;
                    NewField6.CalcValue = NewField6.Value;
                    LOGO.CalcValue = LOGO.Value;
                    XXXXXXBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { NewField,NewField6,LOGO,XXXXXXBASLIK};
                }
            }
            public partial class HeaderGroupFooter : TTReportSection
            {
                public InpatientListReport MyParentReport
                {
                    get { return (InpatientListReport)ParentReport; }
                }
                
                public TTReportField LBLToplamYatanHastaSayısı;
                public TTReportField HASTASAYISI; 
                public HeaderGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    RepeatCount = 0;
                    
                    LBLToplamYatanHastaSayısı = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 2, 60, 7, false);
                    LBLToplamYatanHastaSayısı.Name = "LBLToplamYatanHastaSayısı";
                    LBLToplamYatanHastaSayısı.TextFont.Size = 9;
                    LBLToplamYatanHastaSayısı.TextFont.Bold = true;
                    LBLToplamYatanHastaSayısı.TextFont.CharSet = 162;
                    LBLToplamYatanHastaSayısı.Value = @"Toplam Yatan Hasta Sayısı :";

                    HASTASAYISI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 2, 81, 7, false);
                    HASTASAYISI.Name = "HASTASAYISI";
                    HASTASAYISI.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTASAYISI.TextFont.Size = 9;
                    HASTASAYISI.TextFont.CharSet = 162;
                    HASTASAYISI.Value = @"{@sumof(TOPLAMHASTASAYISI1)@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    LBLToplamYatanHastaSayısı.CalcValue = LBLToplamYatanHastaSayısı.Value;
                    HASTASAYISI.CalcValue = ParentGroup.FieldSums["TOPLAMHASTASAYISI1"].Value.ToString();;
                    return new TTReportObject[] { LBLToplamYatanHastaSayısı,HASTASAYISI};
                }
            }

        }

        public HeaderGroup Header;

        public partial class KlinikGroup : TTReportGroup
        {
            public InpatientListReport MyParentReport
            {
                get { return (InpatientListReport)ParentReport; }
            }

            new public KlinikGroupHeader Header()
            {
                return (KlinikGroupHeader)_header;
            }

            new public KlinikGroupFooter Footer()
            {
                return (KlinikGroupFooter)_footer;
            }

            public TTReportField YATTIGIKLINIK { get {return Header().YATTIGIKLINIK;} }
            public TTReportShape NewLine1 { get {return Footer().NewLine1;} }
            public TTReportField TOPLAMHASTASAYISI1 { get {return Footer().TOPLAMHASTASAYISI1;} }
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
                list[0] = new TTReportNqlData<InPatientTreatmentClinicApplication.GetInpatientListReportNQL_Class>("GetInpatientListReportNQL", InPatientTreatmentClinicApplication.GetInpatientListReportNQL((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.PHYSICALSTATECLINIC)));
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
                public InpatientListReport MyParentReport
                {
                    get { return (InpatientListReport)ParentReport; }
                }
                
                public TTReportField YATTIGIKLINIK; 
                public KlinikGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 10;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    YATTIGIKLINIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 5, 283, 10, false);
                    YATTIGIKLINIK.Name = "YATTIGIKLINIK";
                    YATTIGIKLINIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    YATTIGIKLINIK.ObjectDefName = "ResWard";
                    YATTIGIKLINIK.DataMember = "NAME";
                    YATTIGIKLINIK.TextFont.Size = 11;
                    YATTIGIKLINIK.TextFont.Bold = true;
                    YATTIGIKLINIK.TextFont.CharSet = 162;
                    YATTIGIKLINIK.Value = @"{#YATTIGIKLINIK#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    InPatientTreatmentClinicApplication.GetInpatientListReportNQL_Class dataset_GetInpatientListReportNQL = ParentGroup.rsGroup.GetCurrentRecord<InPatientTreatmentClinicApplication.GetInpatientListReportNQL_Class>(0);
                    YATTIGIKLINIK.CalcValue = (dataset_GetInpatientListReportNQL != null ? Globals.ToStringCore(dataset_GetInpatientListReportNQL.Yattigiklinik) : "");
                    YATTIGIKLINIK.PostFieldValueCalculation();
                    return new TTReportObject[] { YATTIGIKLINIK};
                }
            }
            public partial class KlinikGroupFooter : TTReportSection
            {
                public InpatientListReport MyParentReport
                {
                    get { return (InpatientListReport)ParentReport; }
                }
                
                public TTReportShape NewLine1;
                public TTReportField TOPLAMHASTASAYISI1; 
                public KlinikGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 4;
                    RepeatCount = 0;
                    
                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 25, 2, 282, 2, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    TOPLAMHASTASAYISI1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 299, 0, 335, 5, false);
                    TOPLAMHASTASAYISI1.Name = "TOPLAMHASTASAYISI1";
                    TOPLAMHASTASAYISI1.Visible = EvetHayirEnum.ehHayir;
                    TOPLAMHASTASAYISI1.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOPLAMHASTASAYISI1.TextFont.Size = 9;
                    TOPLAMHASTASAYISI1.TextFont.CharSet = 162;
                    TOPLAMHASTASAYISI1.Value = @"{@sumof(TOPLAMHASTASAYISI)@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    InPatientTreatmentClinicApplication.GetInpatientListReportNQL_Class dataset_GetInpatientListReportNQL = ParentGroup.rsGroup.GetCurrentRecord<InPatientTreatmentClinicApplication.GetInpatientListReportNQL_Class>(0);
                    TOPLAMHASTASAYISI1.CalcValue = ParentGroup.FieldSums["TOPLAMHASTASAYISI"].Value.ToString();;
                    return new TTReportObject[] { TOPLAMHASTASAYISI1};
                }
            }

        }

        public KlinikGroup Klinik;

        public partial class OdaGrubuGroup : TTReportGroup
        {
            public InpatientListReport MyParentReport
            {
                get { return (InpatientListReport)ParentReport; }
            }

            new public OdaGrubuGroupHeader Header()
            {
                return (OdaGrubuGroupHeader)_header;
            }

            new public OdaGrubuGroupFooter Footer()
            {
                return (OdaGrubuGroupFooter)_footer;
            }

            public TTReportField ODAGRUBU { get {return Header().ODAGRUBU;} }
            public TTReportField LBLTCNO { get {return Header().LBLTCNO;} }
            public TTReportField LBLHASTAADISOYADI { get {return Header().LBLHASTAADISOYADI;} }
            public TTReportField LBLODA { get {return Header().LBLODA;} }
            public TTReportField LBLKLINIKYATISTARIHI { get {return Header().LBLKLINIKYATISTARIHI;} }
            public TTReportField LBLTIBBIPROTOKOLNO { get {return Header().LBLTIBBIPROTOKOLNO;} }
            public TTReportField LBLYATAK { get {return Header().LBLYATAK;} }
            public TTReportField LBLKLINIKYATISTARIHI1 { get {return Header().LBLKLINIKYATISTARIHI1;} }
            public TTReportField LBLSıra { get {return Header().LBLSıra;} }
            public TTReportField LBLSORUMLUDOKTOR { get {return Header().LBLSORUMLUDOKTOR;} }
            public TTReportField LBLSINIFRUTBE { get {return Header().LBLSINIFRUTBE;} }
            public TTReportField TOPLAMHASTASAYISI { get {return Footer().TOPLAMHASTASAYISI;} }
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

                InPatientTreatmentClinicApplication.GetInpatientListReportNQL_Class dataSet_GetInpatientListReportNQL = ParentGroup.rsGroup.GetCurrentRecord<InPatientTreatmentClinicApplication.GetInpatientListReportNQL_Class>(0);    
                return new object[] {(dataSet_GetInpatientListReportNQL==null ? null : dataSet_GetInpatientListReportNQL.Yattigiklinik)};
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
                public InpatientListReport MyParentReport
                {
                    get { return (InpatientListReport)ParentReport; }
                }
                
                public TTReportField ODAGRUBU;
                public TTReportField LBLTCNO;
                public TTReportField LBLHASTAADISOYADI;
                public TTReportField LBLODA;
                public TTReportField LBLKLINIKYATISTARIHI;
                public TTReportField LBLTIBBIPROTOKOLNO;
                public TTReportField LBLYATAK;
                public TTReportField LBLKLINIKYATISTARIHI1;
                public TTReportField LBLSıra;
                public TTReportField LBLSORUMLUDOKTOR;
                public TTReportField LBLSINIFRUTBE; 
                public OdaGrubuGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 14;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    ODAGRUBU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 30, 2, 283, 7, false);
                    ODAGRUBU.Name = "ODAGRUBU";
                    ODAGRUBU.FieldType = ReportFieldTypeEnum.ftVariable;
                    ODAGRUBU.ObjectDefName = "ResRoomGroup";
                    ODAGRUBU.DataMember = "NAME";
                    ODAGRUBU.TextFont.Size = 9;
                    ODAGRUBU.TextFont.Bold = true;
                    ODAGRUBU.TextFont.CharSet = 162;
                    ODAGRUBU.Value = @"{#Klinik.ODAGRUBU#}";

                    LBLTCNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 57, 8, 76, 13, false);
                    LBLTCNO.Name = "LBLTCNO";
                    LBLTCNO.TextFont.Size = 9;
                    LBLTCNO.TextFont.Bold = true;
                    LBLTCNO.TextFont.CharSet = 162;
                    LBLTCNO.Value = @"TC Kimlik No";

                    LBLHASTAADISOYADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 8, 141, 13, false);
                    LBLHASTAADISOYADI.Name = "LBLHASTAADISOYADI";
                    LBLHASTAADISOYADI.TextFont.Size = 9;
                    LBLHASTAADISOYADI.TextFont.Bold = true;
                    LBLHASTAADISOYADI.TextFont.CharSet = 162;
                    LBLHASTAADISOYADI.Value = @"Hasta Adı Soyadı ";

                    LBLODA = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 8, 156, 13, false);
                    LBLODA.Name = "LBLODA";
                    LBLODA.TextFont.Size = 9;
                    LBLODA.TextFont.Bold = true;
                    LBLODA.TextFont.CharSet = 162;
                    LBLODA.Value = @"Oda";

                    LBLKLINIKYATISTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 260, 8, 283, 13, false);
                    LBLKLINIKYATISTARIHI.Name = "LBLKLINIKYATISTARIHI";
                    LBLKLINIKYATISTARIHI.HorzAlign = HorizontalAlignmentEnum.haRight;
                    LBLKLINIKYATISTARIHI.TextFont.Size = 9;
                    LBLKLINIKYATISTARIHI.TextFont.Bold = true;
                    LBLKLINIKYATISTARIHI.TextFont.CharSet = 162;
                    LBLKLINIKYATISTARIHI.Value = @"Klinik Yatış Tarihi";

                    LBLTIBBIPROTOKOLNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 8, 57, 13, false);
                    LBLTIBBIPROTOKOLNO.Name = "LBLTIBBIPROTOKOLNO";
                    LBLTIBBIPROTOKOLNO.TextFont.Size = 9;
                    LBLTIBBIPROTOKOLNO.TextFont.Bold = true;
                    LBLTIBBIPROTOKOLNO.TextFont.CharSet = 162;
                    LBLTIBBIPROTOKOLNO.Value = @"Tıbbi Kayıt Pr.Nu.";

                    LBLYATAK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 157, 8, 172, 13, false);
                    LBLYATAK.Name = "LBLYATAK";
                    LBLYATAK.TextFont.Size = 9;
                    LBLYATAK.TextFont.Bold = true;
                    LBLYATAK.TextFont.CharSet = 162;
                    LBLYATAK.Value = @"Yatak";

                    LBLKLINIKYATISTARIHI1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 173, 8, 222, 13, false);
                    LBLKLINIKYATISTARIHI1.Name = "LBLKLINIKYATISTARIHI1";
                    LBLKLINIKYATISTARIHI1.TextFont.Size = 9;
                    LBLKLINIKYATISTARIHI1.TextFont.Bold = true;
                    LBLKLINIKYATISTARIHI1.TextFont.CharSet = 162;
                    LBLKLINIKYATISTARIHI1.Value = @"Tedavi Gördüğü Klinik";

                    LBLSıra = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 8, 33, 13, false);
                    LBLSıra.Name = "LBLSıra";
                    LBLSıra.TextFont.Size = 9;
                    LBLSıra.TextFont.Bold = true;
                    LBLSıra.TextFont.CharSet = 162;
                    LBLSıra.Value = @"Sıra";

                    LBLSORUMLUDOKTOR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 223, 8, 259, 13, false);
                    LBLSORUMLUDOKTOR.Name = "LBLSORUMLUDOKTOR";
                    LBLSORUMLUDOKTOR.TextFont.Size = 9;
                    LBLSORUMLUDOKTOR.TextFont.Bold = true;
                    LBLSORUMLUDOKTOR.TextFont.CharSet = 162;
                    LBLSORUMLUDOKTOR.Value = @"Sorumlu Doktor";

                    LBLSINIFRUTBE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 77, 8, 104, 13, false);
                    LBLSINIFRUTBE.Name = "LBLSINIFRUTBE";
                    LBLSINIFRUTBE.TextFont.Size = 9;
                    LBLSINIFRUTBE.TextFont.Bold = true;
                    LBLSINIFRUTBE.TextFont.CharSet = 162;
                    LBLSINIFRUTBE.Value = @"Sınıf Rütbe";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    InPatientTreatmentClinicApplication.GetInpatientListReportNQL_Class dataset_GetInpatientListReportNQL = MyParentReport.Klinik.rsGroup.GetCurrentRecord<InPatientTreatmentClinicApplication.GetInpatientListReportNQL_Class>(0);
                    ODAGRUBU.CalcValue = (dataset_GetInpatientListReportNQL != null ? Globals.ToStringCore(dataset_GetInpatientListReportNQL.Odagrubu) : "");
                    ODAGRUBU.PostFieldValueCalculation();
                    LBLTCNO.CalcValue = LBLTCNO.Value;
                    LBLHASTAADISOYADI.CalcValue = LBLHASTAADISOYADI.Value;
                    LBLODA.CalcValue = LBLODA.Value;
                    LBLKLINIKYATISTARIHI.CalcValue = LBLKLINIKYATISTARIHI.Value;
                    LBLTIBBIPROTOKOLNO.CalcValue = LBLTIBBIPROTOKOLNO.Value;
                    LBLYATAK.CalcValue = LBLYATAK.Value;
                    LBLKLINIKYATISTARIHI1.CalcValue = LBLKLINIKYATISTARIHI1.Value;
                    LBLSıra.CalcValue = LBLSıra.Value;
                    LBLSORUMLUDOKTOR.CalcValue = LBLSORUMLUDOKTOR.Value;
                    LBLSINIFRUTBE.CalcValue = LBLSINIFRUTBE.Value;
                    return new TTReportObject[] { ODAGRUBU,LBLTCNO,LBLHASTAADISOYADI,LBLODA,LBLKLINIKYATISTARIHI,LBLTIBBIPROTOKOLNO,LBLYATAK,LBLKLINIKYATISTARIHI1,LBLSıra,LBLSORUMLUDOKTOR,LBLSINIFRUTBE};
                }
            }
            public partial class OdaGrubuGroupFooter : TTReportSection
            {
                public InpatientListReport MyParentReport
                {
                    get { return (InpatientListReport)ParentReport; }
                }
                
                public TTReportField TOPLAMHASTASAYISI; 
                public OdaGrubuGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 6;
                    RepeatCount = 0;
                    
                    TOPLAMHASTASAYISI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 299, 1, 335, 6, false);
                    TOPLAMHASTASAYISI.Name = "TOPLAMHASTASAYISI";
                    TOPLAMHASTASAYISI.Visible = EvetHayirEnum.ehHayir;
                    TOPLAMHASTASAYISI.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOPLAMHASTASAYISI.TextFont.Size = 9;
                    TOPLAMHASTASAYISI.TextFont.CharSet = 162;
                    TOPLAMHASTASAYISI.Value = @"{@subgroupcount@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    InPatientTreatmentClinicApplication.GetInpatientListReportNQL_Class dataset_GetInpatientListReportNQL = MyParentReport.Klinik.rsGroup.GetCurrentRecord<InPatientTreatmentClinicApplication.GetInpatientListReportNQL_Class>(0);
                    TOPLAMHASTASAYISI.CalcValue = (ParentGroup.SubGroupCount - 1).ToString();
                    return new TTReportObject[] { TOPLAMHASTASAYISI};
                }
            }

        }

        public OdaGrubuGroup OdaGrubu;

        public partial class MAINGroup : TTReportGroup
        {
            public InpatientListReport MyParentReport
            {
                get { return (InpatientListReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField TIBBIPROTOKOLNO { get {return Body().TIBBIPROTOKOLNO;} }
            public TTReportField TCNO { get {return Body().TCNO;} }
            public TTReportField HASTAADISOYADI { get {return Body().HASTAADISOYADI;} }
            public TTReportField ODA { get {return Body().ODA;} }
            public TTReportField YATAK { get {return Body().YATAK;} }
            public TTReportField KLINIK { get {return Body().KLINIK;} }
            public TTReportField KLINIKYATISTARIHI { get {return Body().KLINIKYATISTARIHI;} }
            public TTReportField HASTASOYADI { get {return Body().HASTASOYADI;} }
            public TTReportField HASTAADI { get {return Body().HASTAADI;} }
            public TTReportField SIRA { get {return Body().SIRA;} }
            public TTReportField OBJECTID { get {return Body().OBJECTID;} }
            public TTReportField SORUMLUDOKTOR { get {return Body().SORUMLUDOKTOR;} }
            public TTReportField SINIFRUTBE { get {return Body().SINIFRUTBE;} }
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

                InPatientTreatmentClinicApplication.GetInpatientListReportNQL_Class dataSet_GetInpatientListReportNQL = ParentGroup.rsGroup.GetCurrentRecord<InPatientTreatmentClinicApplication.GetInpatientListReportNQL_Class>(0);    
                return new object[] {(dataSet_GetInpatientListReportNQL==null ? null : dataSet_GetInpatientListReportNQL.Odagrubu)};
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
                public InpatientListReport MyParentReport
                {
                    get { return (InpatientListReport)ParentReport; }
                }
                
                public TTReportField TIBBIPROTOKOLNO;
                public TTReportField TCNO;
                public TTReportField HASTAADISOYADI;
                public TTReportField ODA;
                public TTReportField YATAK;
                public TTReportField KLINIK;
                public TTReportField KLINIKYATISTARIHI;
                public TTReportField HASTASOYADI;
                public TTReportField HASTAADI;
                public TTReportField SIRA;
                public TTReportField OBJECTID;
                public TTReportField SORUMLUDOKTOR;
                public TTReportField SINIFRUTBE; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 11;
                    RepeatCount = 0;
                    
                    TIBBIPROTOKOLNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 1, 57, 6, false);
                    TIBBIPROTOKOLNO.Name = "TIBBIPROTOKOLNO";
                    TIBBIPROTOKOLNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    TIBBIPROTOKOLNO.TextFont.Size = 9;
                    TIBBIPROTOKOLNO.TextFont.CharSet = 162;
                    TIBBIPROTOKOLNO.Value = @"";

                    TCNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 1, 76, 6, false);
                    TCNO.Name = "TCNO";
                    TCNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    TCNO.TextFont.Size = 9;
                    TCNO.TextFont.CharSet = 162;
                    TCNO.Value = @"{#Klinik.TCNO#}";

                    HASTAADISOYADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 1, 141, 6, false);
                    HASTAADISOYADI.Name = "HASTAADISOYADI";
                    HASTAADISOYADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTAADISOYADI.TextFont.Size = 9;
                    HASTAADISOYADI.TextFont.CharSet = 162;
                    HASTAADISOYADI.Value = @"{%HASTAADI%} {%HASTASOYADI%}";

                    ODA = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 1, 156, 6, false);
                    ODA.Name = "ODA";
                    ODA.FieldType = ReportFieldTypeEnum.ftVariable;
                    ODA.ObjectDefName = "ResRoom";
                    ODA.DataMember = "NAME";
                    ODA.TextFont.Size = 9;
                    ODA.TextFont.CharSet = 162;
                    ODA.Value = @"{#Klinik.ODA#}";

                    YATAK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 157, 1, 172, 6, false);
                    YATAK.Name = "YATAK";
                    YATAK.FieldType = ReportFieldTypeEnum.ftVariable;
                    YATAK.ObjectDefName = "ResBed";
                    YATAK.DataMember = "NAME";
                    YATAK.TextFont.Size = 9;
                    YATAK.TextFont.CharSet = 162;
                    YATAK.Value = @"{#Klinik.YATAK#}";

                    KLINIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 173, 1, 222, 6, false);
                    KLINIK.Name = "KLINIK";
                    KLINIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    KLINIK.ObjectDefName = "ResWard";
                    KLINIK.DataMember = "NAME";
                    KLINIK.TextFont.Size = 9;
                    KLINIK.TextFont.CharSet = 162;
                    KLINIK.Value = @"{#Klinik.TEDAVIKLINIK#}";

                    KLINIKYATISTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 260, 1, 283, 6, false);
                    KLINIKYATISTARIHI.Name = "KLINIKYATISTARIHI";
                    KLINIKYATISTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    KLINIKYATISTARIHI.TextFormat = @"dd/MM/yyyy";
                    KLINIKYATISTARIHI.TextFont.Size = 9;
                    KLINIKYATISTARIHI.TextFont.CharSet = 162;
                    KLINIKYATISTARIHI.Value = @"{#Klinik.KLINIKYATISTARIHI#}";

                    HASTASOYADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 335, 1, 371, 6, false);
                    HASTASOYADI.Name = "HASTASOYADI";
                    HASTASOYADI.Visible = EvetHayirEnum.ehHayir;
                    HASTASOYADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTASOYADI.TextFont.Size = 9;
                    HASTASOYADI.TextFont.CharSet = 162;
                    HASTASOYADI.Value = @"{#Klinik.HASTASOYADI#}";

                    HASTAADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 299, 1, 335, 6, false);
                    HASTAADI.Name = "HASTAADI";
                    HASTAADI.Visible = EvetHayirEnum.ehHayir;
                    HASTAADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTAADI.TextFont.Size = 9;
                    HASTAADI.TextFont.CharSet = 162;
                    HASTAADI.Value = @"{#Klinik.HASTAADI#}";

                    SIRA = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 1, 33, 6, false);
                    SIRA.Name = "SIRA";
                    SIRA.FieldType = ReportFieldTypeEnum.ftVariable;
                    SIRA.TextFont.Size = 9;
                    SIRA.TextFont.CharSet = 162;
                    SIRA.Value = @"{@groupcounter@}";

                    OBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 371, 1, 407, 6, false);
                    OBJECTID.Name = "OBJECTID";
                    OBJECTID.Visible = EvetHayirEnum.ehHayir;
                    OBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBJECTID.TextFont.Size = 9;
                    OBJECTID.TextFont.CharSet = 162;
                    OBJECTID.Value = @"{#Klinik.OBJECTID#}";

                    SORUMLUDOKTOR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 223, 1, 259, 6, false);
                    SORUMLUDOKTOR.Name = "SORUMLUDOKTOR";
                    SORUMLUDOKTOR.FieldType = ReportFieldTypeEnum.ftVariable;
                    SORUMLUDOKTOR.TextFont.Size = 9;
                    SORUMLUDOKTOR.TextFont.CharSet = 162;
                    SORUMLUDOKTOR.Value = @"{#Klinik.SORUMLUDOKTOR#}";

                    SINIFRUTBE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 77, 1, 104, 6, false);
                    SINIFRUTBE.Name = "SINIFRUTBE";
                    SINIFRUTBE.FieldType = ReportFieldTypeEnum.ftVariable;
                    SINIFRUTBE.TextFont.Size = 9;
                    SINIFRUTBE.TextFont.CharSet = 162;
                    SINIFRUTBE.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    InPatientTreatmentClinicApplication.GetInpatientListReportNQL_Class dataset_GetInpatientListReportNQL = MyParentReport.Klinik.rsGroup.GetCurrentRecord<InPatientTreatmentClinicApplication.GetInpatientListReportNQL_Class>(0);
                    TIBBIPROTOKOLNO.CalcValue = @"";
                    TCNO.CalcValue = (dataset_GetInpatientListReportNQL != null ? Globals.ToStringCore(dataset_GetInpatientListReportNQL.Tcno) : "");
                    HASTAADI.CalcValue = (dataset_GetInpatientListReportNQL != null ? Globals.ToStringCore(dataset_GetInpatientListReportNQL.Hastaadi) : "");
                    HASTASOYADI.CalcValue = (dataset_GetInpatientListReportNQL != null ? Globals.ToStringCore(dataset_GetInpatientListReportNQL.Hastasoyadi) : "");
                    HASTAADISOYADI.CalcValue = MyParentReport.MAIN.HASTAADI.CalcValue + @" " + MyParentReport.MAIN.HASTASOYADI.CalcValue;
                    ODA.CalcValue = (dataset_GetInpatientListReportNQL != null ? Globals.ToStringCore(dataset_GetInpatientListReportNQL.Oda) : "");
                    ODA.PostFieldValueCalculation();
                    YATAK.CalcValue = (dataset_GetInpatientListReportNQL != null ? Globals.ToStringCore(dataset_GetInpatientListReportNQL.Yatak) : "");
                    YATAK.PostFieldValueCalculation();
                    KLINIK.CalcValue = (dataset_GetInpatientListReportNQL != null ? Globals.ToStringCore(dataset_GetInpatientListReportNQL.Tedaviklinik) : "");
                    KLINIK.PostFieldValueCalculation();
                    KLINIKYATISTARIHI.CalcValue = (dataset_GetInpatientListReportNQL != null ? Globals.ToStringCore(dataset_GetInpatientListReportNQL.Klinikyatistarihi) : "");
                    SIRA.CalcValue = ParentGroup.GroupCounter.ToString();
                    OBJECTID.CalcValue = (dataset_GetInpatientListReportNQL != null ? Globals.ToStringCore(dataset_GetInpatientListReportNQL.ObjectID) : "");
                    SORUMLUDOKTOR.CalcValue = (dataset_GetInpatientListReportNQL != null ? Globals.ToStringCore(dataset_GetInpatientListReportNQL.Sorumludoktor) : "");
                    SINIFRUTBE.CalcValue = @"";
                    return new TTReportObject[] { TIBBIPROTOKOLNO,TCNO,HASTAADI,HASTASOYADI,HASTAADISOYADI,ODA,YATAK,KLINIK,KLINIKYATISTARIHI,SIRA,OBJECTID,SORUMLUDOKTOR,SINIFRUTBE};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    //            TTObjectContext context = new TTObjectContext(true);
//            string objectid = this.OBJECTID.CalcValue;
//            InPatientTreatmentClinicApplication inPatientTreatmentClinicApplication = (InPatientTreatmentClinicApplication)context.GetObject(new Guid(objectid),"InPatientTreatmentClinicApplication");
//            if(inPatientTreatmentClinicApplication.BaseInpatientAdmission is InpatientAdmission)
//            {
//                if(((InpatientAdmission)inPatientTreatmentClinicApplication.BaseInpatientAdmission).QuarantineProtocolNo != null)
//                this.TIBBIPROTOKOLNO.CalcValue = ((InpatientAdmission)inPatientTreatmentClinicApplication.BaseInpatientAdmission).QuarantineProtocolNo.ToString();
//            }
//            
//            if (SINIFRUTBE.CalcValue==" ")
//            {
//                SINIFRUTBE.CalcValue = PGROUP.CalcValue;
//            }
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

        public InpatientListReport()
        {
            Info = new InfoGroup(this,"Info");
            Header = new HeaderGroup(Info,"Header");
            Klinik = new KlinikGroup(Header,"Klinik");
            OdaGrubu = new OdaGrubuGroup(Klinik,"OdaGrubu");
            MAIN = new MAINGroup(OdaGrubu,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("PHYSICALSTATECLINIC", "00000000-0000-0000-0000-000000000000", "Yattığı Klinik", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("20fdb56a-389f-46c9-8cd5-f604eddab75f");
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("PHYSICALSTATECLINIC"))
                _runtimeParameters.PHYSICALSTATECLINIC = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["PHYSICALSTATECLINIC"]);
            Name = "INPATIENTLISTREPORT";
            Caption = "Yatan Hasta Listesi";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oeLandscape;
            PaperSize = 10;
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
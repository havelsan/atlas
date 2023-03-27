
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
    /// Yatan ve Taburcu Hasta Listesi
    /// </summary>
    public partial class DischargedPatientListByDayReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? PHYSICALSTATECLINIC = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
            public int? INPATIENTDAYS = (int?)TTObjectDefManager.Instance.DataTypes["Integer_"].ConvertValue("");
        }

        public partial class InfoGroup : TTReportGroup
        {
            public DischargedPatientListByDayReport MyParentReport
            {
                get { return (DischargedPatientListByDayReport)ParentReport; }
            }

            new public InfoGroupHeader Header()
            {
                return (InfoGroupHeader)_header;
            }

            new public InfoGroupFooter Footer()
            {
                return (InfoGroupFooter)_footer;
            }

            public TTReportShape NewLine1 { get {return Footer().NewLine1;} }
            public TTReportField printdatE { get {return Footer().printdatE;} }
            public TTReportField CurrentUser { get {return Footer().CurrentUser;} }
            public TTReportShape NewLine2 { get {return Footer().NewLine2;} }
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
                public DischargedPatientListByDayReport MyParentReport
                {
                    get { return (DischargedPatientListByDayReport)ParentReport; }
                }
                 
                public InfoGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 7;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                }
                
            }
            public partial class InfoGroupFooter : TTReportSection
            {
                public DischargedPatientListByDayReport MyParentReport
                {
                    get { return (DischargedPatientListByDayReport)ParentReport; }
                }
                
                public TTReportShape NewLine1;
                public TTReportField printdatE;
                public TTReportField CurrentUser;
                public TTReportShape NewLine2; 
                public InfoGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 15;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 14, 1, 291, 1, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1.DrawWidth = 2;

                    printdatE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 1, 40, 6, false);
                    printdatE.Name = "printdatE";
                    printdatE.FieldType = ReportFieldTypeEnum.ftVariable;
                    printdatE.TextFont.Size = 9;
                    printdatE.TextFont.CharSet = 162;
                    printdatE.Value = @"{@printdate@}";

                    CurrentUser = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 135, 1, 215, 6, false);
                    CurrentUser.Name = "CurrentUser";
                    CurrentUser.FieldType = ReportFieldTypeEnum.ftExpression;
                    CurrentUser.TextFont.Size = 9;
                    CurrentUser.TextFont.CharSet = 162;
                    CurrentUser.Value = @"TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : """"";

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 14, 14, 291, 14, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.ForeColor = System.Drawing.Color.White;
                    NewLine2.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    printdatE.CalcValue = DateTime.Now.ToShortDateString();
                    CurrentUser.CalcValue = TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : "";
                    return new TTReportObject[] { printdatE,CurrentUser};
                }
            }

        }

        public InfoGroup Info;

        public partial class HeaderGroup : TTReportGroup
        {
            public DischargedPatientListByDayReport MyParentReport
            {
                get { return (DischargedPatientListByDayReport)ParentReport; }
            }

            new public HeaderGroupHeader Header()
            {
                return (HeaderGroupHeader)_header;
            }

            new public HeaderGroupFooter Footer()
            {
                return (HeaderGroupFooter)_footer;
            }

            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField XXXXXXBaslik { get {return Header().XXXXXXBaslik;} }
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
                public DischargedPatientListByDayReport MyParentReport
                {
                    get { return (DischargedPatientListByDayReport)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportField XXXXXXBaslik; 
                public HeaderGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 42;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 98, 29, 212, 37, false);
                    NewField1.Name = "NewField1";
                    NewField1.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.TextFont.Size = 15;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"{@INPATIENTDAYS@} GÜNDEN FAZLA YATAN HASTA LİSTESİ";

                    XXXXXXBaslik = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 79, 5, 230, 28, false);
                    XXXXXXBaslik.Name = "XXXXXXBaslik";
                    XXXXXXBaslik.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXBaslik.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBaslik.TextFont.Size = 11;
                    XXXXXXBaslik.TextFont.Bold = true;
                    XXXXXXBaslik.TextFont.CharSet = 162;
                    XXXXXXBaslik.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + ""\r\n"" + TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1.CalcValue = MyParentReport.RuntimeParameters.INPATIENTDAYS.ToString() + @" GÜNDEN FAZLA YATAN HASTA LİSTESİ";
                    XXXXXXBaslik.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { NewField1,XXXXXXBaslik};
                }
            }
            public partial class HeaderGroupFooter : TTReportSection
            {
                public DischargedPatientListByDayReport MyParentReport
                {
                    get { return (DischargedPatientListByDayReport)ParentReport; }
                }
                
                public TTReportField LBLToplamYatanHastaSayısı;
                public TTReportField HASTASAYISI; 
                public HeaderGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    RepeatCount = 0;
                    
                    LBLToplamYatanHastaSayısı = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 2, 49, 7, false);
                    LBLToplamYatanHastaSayısı.Name = "LBLToplamYatanHastaSayısı";
                    LBLToplamYatanHastaSayısı.TextFont.Size = 9;
                    LBLToplamYatanHastaSayısı.TextFont.Bold = true;
                    LBLToplamYatanHastaSayısı.TextFont.CharSet = 162;
                    LBLToplamYatanHastaSayısı.Value = @"Toplam Yatan Hasta Sayısı :";

                    HASTASAYISI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 2, 70, 7, false);
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
            public DischargedPatientListByDayReport MyParentReport
            {
                get { return (DischargedPatientListByDayReport)ParentReport; }
            }

            new public KlinikGroupHeader Header()
            {
                return (KlinikGroupHeader)_header;
            }

            new public KlinikGroupFooter Footer()
            {
                return (KlinikGroupFooter)_footer;
            }

            public TTReportField YattigiKlinik { get {return Header().YattigiKlinik;} }
            public TTReportField TOPLAMHASTASAYISI1 { get {return Footer().TOPLAMHASTASAYISI1;} }
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
                list[0] = new TTReportNqlData<InPatientTreatmentClinicApplication.GetpatientListReportByDaysNQL_Class>("GetpatientListReportByDaysNQL", InPatientTreatmentClinicApplication.GetpatientListReportByDaysNQL((int)TTObjectDefManager.Instance.DataTypes["Integer_"].ConvertValue(MyParentReport.RuntimeParameters.INPATIENTDAYS),(Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.PHYSICALSTATECLINIC)));
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
                public DischargedPatientListByDayReport MyParentReport
                {
                    get { return (DischargedPatientListByDayReport)ParentReport; }
                }
                
                public TTReportField YattigiKlinik; 
                public KlinikGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 10;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    YattigiKlinik = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 5, 291, 10, false);
                    YattigiKlinik.Name = "YattigiKlinik";
                    YattigiKlinik.FieldType = ReportFieldTypeEnum.ftVariable;
                    YattigiKlinik.ObjectDefName = "ResWard";
                    YattigiKlinik.DataMember = "NAME";
                    YattigiKlinik.TextFont.Size = 11;
                    YattigiKlinik.TextFont.Bold = true;
                    YattigiKlinik.TextFont.CharSet = 162;
                    YattigiKlinik.Value = @"{#YATTIGIKLINIK#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    InPatientTreatmentClinicApplication.GetpatientListReportByDaysNQL_Class dataset_GetpatientListReportByDaysNQL = ParentGroup.rsGroup.GetCurrentRecord<InPatientTreatmentClinicApplication.GetpatientListReportByDaysNQL_Class>(0);
                    YattigiKlinik.CalcValue = (dataset_GetpatientListReportByDaysNQL != null ? Globals.ToStringCore(dataset_GetpatientListReportByDaysNQL.Yattigiklinik) : "");
                    YattigiKlinik.PostFieldValueCalculation();
                    return new TTReportObject[] { YattigiKlinik};
                }
            }
            public partial class KlinikGroupFooter : TTReportSection
            {
                public DischargedPatientListByDayReport MyParentReport
                {
                    get { return (DischargedPatientListByDayReport)ParentReport; }
                }
                
                public TTReportField TOPLAMHASTASAYISI1;
                public TTReportShape NewLine1; 
                public KlinikGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 4;
                    RepeatCount = 0;
                    
                    TOPLAMHASTASAYISI1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 310, 0, 335, 5, false);
                    TOPLAMHASTASAYISI1.Name = "TOPLAMHASTASAYISI1";
                    TOPLAMHASTASAYISI1.Visible = EvetHayirEnum.ehHayir;
                    TOPLAMHASTASAYISI1.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOPLAMHASTASAYISI1.Value = @"{@sumof(TOPLAMHASTASAYISI)@}";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 14, 2, 291, 2, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    InPatientTreatmentClinicApplication.GetpatientListReportByDaysNQL_Class dataset_GetpatientListReportByDaysNQL = ParentGroup.rsGroup.GetCurrentRecord<InPatientTreatmentClinicApplication.GetpatientListReportByDaysNQL_Class>(0);
                    TOPLAMHASTASAYISI1.CalcValue = ParentGroup.FieldSums["TOPLAMHASTASAYISI"].Value.ToString();;
                    return new TTReportObject[] { TOPLAMHASTASAYISI1};
                }
            }

        }

        public KlinikGroup Klinik;

        public partial class OdaGrubuGroup : TTReportGroup
        {
            public DischargedPatientListByDayReport MyParentReport
            {
                get { return (DischargedPatientListByDayReport)ParentReport; }
            }

            new public OdaGrubuGroupHeader Header()
            {
                return (OdaGrubuGroupHeader)_header;
            }

            new public OdaGrubuGroupFooter Footer()
            {
                return (OdaGrubuGroupFooter)_footer;
            }

            public TTReportField OdaGrubu { get {return Header().OdaGrubu;} }
            public TTReportField LBLSıra { get {return Header().LBLSıra;} }
            public TTReportField LBLTIBBIPROTOKOLNO { get {return Header().LBLTIBBIPROTOKOLNO;} }
            public TTReportField LBLTCNO { get {return Header().LBLTCNO;} }
            public TTReportField LBLSINIFRUTBE { get {return Header().LBLSINIFRUTBE;} }
            public TTReportField LBLHASTAADISOYADI { get {return Header().LBLHASTAADISOYADI;} }
            public TTReportField LBLODA { get {return Header().LBLODA;} }
            public TTReportField LBLYATAK { get {return Header().LBLYATAK;} }
            public TTReportField LBLKLINIKYATISTARIHI1 { get {return Header().LBLKLINIKYATISTARIHI1;} }
            public TTReportField LBLSORUMLUDOKTOR { get {return Header().LBLSORUMLUDOKTOR;} }
            public TTReportField LBLKLINIKYATISTARIHI { get {return Header().LBLKLINIKYATISTARIHI;} }
            public TTReportField LBLKLINIKTABURCUTARIHI { get {return Header().LBLKLINIKTABURCUTARIHI;} }
            public TTReportField lblYatisGunSayisi { get {return Header().lblYatisGunSayisi;} }
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

                InPatientTreatmentClinicApplication.GetpatientListReportByDaysNQL_Class dataSet_GetpatientListReportByDaysNQL = ParentGroup.rsGroup.GetCurrentRecord<InPatientTreatmentClinicApplication.GetpatientListReportByDaysNQL_Class>(0);    
                return new object[] {(dataSet_GetpatientListReportByDaysNQL==null ? null : dataSet_GetpatientListReportByDaysNQL.Yattigiklinik)};
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
                public DischargedPatientListByDayReport MyParentReport
                {
                    get { return (DischargedPatientListByDayReport)ParentReport; }
                }
                
                public TTReportField OdaGrubu;
                public TTReportField LBLSıra;
                public TTReportField LBLTIBBIPROTOKOLNO;
                public TTReportField LBLTCNO;
                public TTReportField LBLSINIFRUTBE;
                public TTReportField LBLHASTAADISOYADI;
                public TTReportField LBLODA;
                public TTReportField LBLYATAK;
                public TTReportField LBLKLINIKYATISTARIHI1;
                public TTReportField LBLSORUMLUDOKTOR;
                public TTReportField LBLKLINIKYATISTARIHI;
                public TTReportField LBLKLINIKTABURCUTARIHI;
                public TTReportField lblYatisGunSayisi; 
                public OdaGrubuGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 15;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    OdaGrubu = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 19, 3, 291, 8, false);
                    OdaGrubu.Name = "OdaGrubu";
                    OdaGrubu.FieldType = ReportFieldTypeEnum.ftVariable;
                    OdaGrubu.ObjectDefName = "ResRoomGroup";
                    OdaGrubu.DataMember = "NAME";
                    OdaGrubu.TextFont.Size = 9;
                    OdaGrubu.TextFont.Bold = true;
                    OdaGrubu.TextFont.CharSet = 162;
                    OdaGrubu.Value = @"{#Klinik.ODAGRUBU#}";

                    LBLSıra = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 9, 22, 14, false);
                    LBLSıra.Name = "LBLSıra";
                    LBLSıra.TextFont.Size = 9;
                    LBLSıra.TextFont.Bold = true;
                    LBLSıra.TextFont.CharSet = 162;
                    LBLSıra.Value = @"Sıra";

                    LBLTIBBIPROTOKOLNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 23, 9, 46, 14, false);
                    LBLTIBBIPROTOKOLNO.Name = "LBLTIBBIPROTOKOLNO";
                    LBLTIBBIPROTOKOLNO.TextFont.Size = 9;
                    LBLTIBBIPROTOKOLNO.TextFont.Bold = true;
                    LBLTIBBIPROTOKOLNO.TextFont.CharSet = 162;
                    LBLTIBBIPROTOKOLNO.Value = @"Tıbbi Kayıt Pr. Nu.";

                    LBLTCNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 46, 9, 65, 14, false);
                    LBLTCNO.Name = "LBLTCNO";
                    LBLTCNO.TextFont.Size = 9;
                    LBLTCNO.TextFont.Bold = true;
                    LBLTCNO.TextFont.CharSet = 162;
                    LBLTCNO.Value = @"TC Kimlik Nu.";

                    LBLSINIFRUTBE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 66, 9, 87, 14, false);
                    LBLSINIFRUTBE.Name = "LBLSINIFRUTBE";
                    LBLSINIFRUTBE.TextFont.Size = 9;
                    LBLSINIFRUTBE.TextFont.Bold = true;
                    LBLSINIFRUTBE.TextFont.CharSet = 162;
                    LBLSINIFRUTBE.Value = @"Sınıf Rütbe";

                    LBLHASTAADISOYADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 88, 9, 124, 14, false);
                    LBLHASTAADISOYADI.Name = "LBLHASTAADISOYADI";
                    LBLHASTAADISOYADI.TextFont.Size = 9;
                    LBLHASTAADISOYADI.TextFont.Bold = true;
                    LBLHASTAADISOYADI.TextFont.CharSet = 162;
                    LBLHASTAADISOYADI.Value = @"Hasta Adı Soyadı";

                    LBLODA = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 125, 9, 139, 14, false);
                    LBLODA.Name = "LBLODA";
                    LBLODA.TextFont.Size = 9;
                    LBLODA.TextFont.Bold = true;
                    LBLODA.TextFont.CharSet = 162;
                    LBLODA.Value = @"Oda";

                    LBLYATAK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 9, 155, 14, false);
                    LBLYATAK.Name = "LBLYATAK";
                    LBLYATAK.TextFont.Size = 9;
                    LBLYATAK.TextFont.Bold = true;
                    LBLYATAK.TextFont.CharSet = 162;
                    LBLYATAK.Value = @"Yatak";

                    LBLKLINIKYATISTARIHI1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 156, 9, 205, 14, false);
                    LBLKLINIKYATISTARIHI1.Name = "LBLKLINIKYATISTARIHI1";
                    LBLKLINIKYATISTARIHI1.TextFont.Size = 9;
                    LBLKLINIKYATISTARIHI1.TextFont.Bold = true;
                    LBLKLINIKYATISTARIHI1.TextFont.CharSet = 162;
                    LBLKLINIKYATISTARIHI1.Value = @"Tedavi Gördüğü Klinik";

                    LBLSORUMLUDOKTOR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 206, 9, 236, 14, false);
                    LBLSORUMLUDOKTOR.Name = "LBLSORUMLUDOKTOR";
                    LBLSORUMLUDOKTOR.TextFont.Size = 9;
                    LBLSORUMLUDOKTOR.TextFont.Bold = true;
                    LBLSORUMLUDOKTOR.TextFont.CharSet = 162;
                    LBLSORUMLUDOKTOR.Value = @"Sorumlu Doktor";

                    LBLKLINIKYATISTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 237, 9, 255, 14, false);
                    LBLKLINIKYATISTARIHI.Name = "LBLKLINIKYATISTARIHI";
                    LBLKLINIKYATISTARIHI.TextFont.Size = 9;
                    LBLKLINIKYATISTARIHI.TextFont.Bold = true;
                    LBLKLINIKYATISTARIHI.TextFont.CharSet = 162;
                    LBLKLINIKYATISTARIHI.Value = @"Kln.Yatış Tar.";

                    LBLKLINIKTABURCUTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 256, 9, 277, 14, false);
                    LBLKLINIKTABURCUTARIHI.Name = "LBLKLINIKTABURCUTARIHI";
                    LBLKLINIKTABURCUTARIHI.TextFont.Size = 9;
                    LBLKLINIKTABURCUTARIHI.TextFont.Bold = true;
                    LBLKLINIKTABURCUTARIHI.TextFont.CharSet = 162;
                    LBLKLINIKTABURCUTARIHI.Value = @"Kln. Taburcu Tar.";

                    lblYatisGunSayisi = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 278, 9, 291, 14, false);
                    lblYatisGunSayisi.Name = "lblYatisGunSayisi";
                    lblYatisGunSayisi.TextFont.Size = 9;
                    lblYatisGunSayisi.TextFont.Bold = true;
                    lblYatisGunSayisi.TextFont.CharSet = 162;
                    lblYatisGunSayisi.Value = @"Yatış Gün";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    InPatientTreatmentClinicApplication.GetpatientListReportByDaysNQL_Class dataset_GetpatientListReportByDaysNQL = MyParentReport.Klinik.rsGroup.GetCurrentRecord<InPatientTreatmentClinicApplication.GetpatientListReportByDaysNQL_Class>(0);
                    OdaGrubu.CalcValue = (dataset_GetpatientListReportByDaysNQL != null ? Globals.ToStringCore(dataset_GetpatientListReportByDaysNQL.Odagrubu) : "");
                    OdaGrubu.PostFieldValueCalculation();
                    LBLSıra.CalcValue = LBLSıra.Value;
                    LBLTIBBIPROTOKOLNO.CalcValue = LBLTIBBIPROTOKOLNO.Value;
                    LBLTCNO.CalcValue = LBLTCNO.Value;
                    LBLSINIFRUTBE.CalcValue = LBLSINIFRUTBE.Value;
                    LBLHASTAADISOYADI.CalcValue = LBLHASTAADISOYADI.Value;
                    LBLODA.CalcValue = LBLODA.Value;
                    LBLYATAK.CalcValue = LBLYATAK.Value;
                    LBLKLINIKYATISTARIHI1.CalcValue = LBLKLINIKYATISTARIHI1.Value;
                    LBLSORUMLUDOKTOR.CalcValue = LBLSORUMLUDOKTOR.Value;
                    LBLKLINIKYATISTARIHI.CalcValue = LBLKLINIKYATISTARIHI.Value;
                    LBLKLINIKTABURCUTARIHI.CalcValue = LBLKLINIKTABURCUTARIHI.Value;
                    lblYatisGunSayisi.CalcValue = lblYatisGunSayisi.Value;
                    return new TTReportObject[] { OdaGrubu,LBLSıra,LBLTIBBIPROTOKOLNO,LBLTCNO,LBLSINIFRUTBE,LBLHASTAADISOYADI,LBLODA,LBLYATAK,LBLKLINIKYATISTARIHI1,LBLSORUMLUDOKTOR,LBLKLINIKYATISTARIHI,LBLKLINIKTABURCUTARIHI,lblYatisGunSayisi};
                }
            }
            public partial class OdaGrubuGroupFooter : TTReportSection
            {
                public DischargedPatientListByDayReport MyParentReport
                {
                    get { return (DischargedPatientListByDayReport)ParentReport; }
                }
                
                public TTReportField TOPLAMHASTASAYISI; 
                public OdaGrubuGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 6;
                    RepeatCount = 0;
                    
                    TOPLAMHASTASAYISI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 311, 0, 336, 5, false);
                    TOPLAMHASTASAYISI.Name = "TOPLAMHASTASAYISI";
                    TOPLAMHASTASAYISI.Visible = EvetHayirEnum.ehHayir;
                    TOPLAMHASTASAYISI.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOPLAMHASTASAYISI.Value = @"{@subgroupcount@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    InPatientTreatmentClinicApplication.GetpatientListReportByDaysNQL_Class dataset_GetpatientListReportByDaysNQL = MyParentReport.Klinik.rsGroup.GetCurrentRecord<InPatientTreatmentClinicApplication.GetpatientListReportByDaysNQL_Class>(0);
                    TOPLAMHASTASAYISI.CalcValue = (ParentGroup.SubGroupCount - 1).ToString();
                    return new TTReportObject[] { TOPLAMHASTASAYISI};
                }
            }

        }

        public OdaGrubuGroup OdaGrubu;

        public partial class MAINGroup : TTReportGroup
        {
            public DischargedPatientListByDayReport MyParentReport
            {
                get { return (DischargedPatientListByDayReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField Sira { get {return Body().Sira;} }
            public TTReportField TIBBIPROTOKOLNO { get {return Body().TIBBIPROTOKOLNO;} }
            public TTReportField TCNO { get {return Body().TCNO;} }
            public TTReportField SINIFRUTBE { get {return Body().SINIFRUTBE;} }
            public TTReportField HASTAADISOYADI { get {return Body().HASTAADISOYADI;} }
            public TTReportField ODA { get {return Body().ODA;} }
            public TTReportField YATAK { get {return Body().YATAK;} }
            public TTReportField KLINIK { get {return Body().KLINIK;} }
            public TTReportField SORUMLUDOKTOR { get {return Body().SORUMLUDOKTOR;} }
            public TTReportField KLINIKYATISTARIHI { get {return Body().KLINIKYATISTARIHI;} }
            public TTReportField KLINIKTABURCUTARIHI { get {return Body().KLINIKTABURCUTARIHI;} }
            public TTReportField YatisGunSayisi { get {return Body().YatisGunSayisi;} }
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

                InPatientTreatmentClinicApplication.GetpatientListReportByDaysNQL_Class dataSet_GetpatientListReportByDaysNQL = ParentGroup.rsGroup.GetCurrentRecord<InPatientTreatmentClinicApplication.GetpatientListReportByDaysNQL_Class>(0);    
                return new object[] {(dataSet_GetpatientListReportByDaysNQL==null ? null : dataSet_GetpatientListReportByDaysNQL.Odagrubu)};
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
                public DischargedPatientListByDayReport MyParentReport
                {
                    get { return (DischargedPatientListByDayReport)ParentReport; }
                }
                
                public TTReportField Sira;
                public TTReportField TIBBIPROTOKOLNO;
                public TTReportField TCNO;
                public TTReportField SINIFRUTBE;
                public TTReportField HASTAADISOYADI;
                public TTReportField ODA;
                public TTReportField YATAK;
                public TTReportField KLINIK;
                public TTReportField SORUMLUDOKTOR;
                public TTReportField KLINIKYATISTARIHI;
                public TTReportField KLINIKTABURCUTARIHI;
                public TTReportField YatisGunSayisi; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 11;
                    RepeatCount = 0;
                    
                    Sira = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 4, 22, 9, false);
                    Sira.Name = "Sira";
                    Sira.FieldType = ReportFieldTypeEnum.ftVariable;
                    Sira.TextFont.Size = 9;
                    Sira.TextFont.CharSet = 162;
                    Sira.Value = @"{@groupcounter@}";

                    TIBBIPROTOKOLNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 23, 4, 46, 9, false);
                    TIBBIPROTOKOLNO.Name = "TIBBIPROTOKOLNO";
                    TIBBIPROTOKOLNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    TIBBIPROTOKOLNO.TextFont.Size = 9;
                    TIBBIPROTOKOLNO.TextFont.CharSet = 162;
                    TIBBIPROTOKOLNO.Value = @"";

                    TCNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 4, 65, 9, false);
                    TCNO.Name = "TCNO";
                    TCNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    TCNO.TextFont.Size = 9;
                    TCNO.TextFont.CharSet = 162;
                    TCNO.Value = @"";

                    SINIFRUTBE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 66, 4, 87, 9, false);
                    SINIFRUTBE.Name = "SINIFRUTBE";
                    SINIFRUTBE.FieldType = ReportFieldTypeEnum.ftVariable;
                    SINIFRUTBE.TextFont.Size = 9;
                    SINIFRUTBE.TextFont.CharSet = 162;
                    SINIFRUTBE.Value = @"";

                    HASTAADISOYADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 88, 4, 124, 9, false);
                    HASTAADISOYADI.Name = "HASTAADISOYADI";
                    HASTAADISOYADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTAADISOYADI.TextFormat = @"dd/MM/yyyy";
                    HASTAADISOYADI.TextFont.Size = 9;
                    HASTAADISOYADI.TextFont.CharSet = 162;
                    HASTAADISOYADI.Value = @"";

                    ODA = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 125, 4, 139, 9, false);
                    ODA.Name = "ODA";
                    ODA.FieldType = ReportFieldTypeEnum.ftVariable;
                    ODA.TextFormat = @"dd/MM/yyyy";
                    ODA.TextFont.Size = 9;
                    ODA.TextFont.CharSet = 162;
                    ODA.Value = @"";

                    YATAK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 4, 155, 9, false);
                    YATAK.Name = "YATAK";
                    YATAK.FieldType = ReportFieldTypeEnum.ftVariable;
                    YATAK.TextFormat = @"dd/MM/yyyy";
                    YATAK.TextFont.Size = 9;
                    YATAK.TextFont.CharSet = 162;
                    YATAK.Value = @"";

                    KLINIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 156, 4, 205, 9, false);
                    KLINIK.Name = "KLINIK";
                    KLINIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    KLINIK.TextFormat = @"dd/MM/yyyy";
                    KLINIK.TextFont.Size = 9;
                    KLINIK.TextFont.CharSet = 162;
                    KLINIK.Value = @"";

                    SORUMLUDOKTOR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 206, 4, 236, 9, false);
                    SORUMLUDOKTOR.Name = "SORUMLUDOKTOR";
                    SORUMLUDOKTOR.FieldType = ReportFieldTypeEnum.ftVariable;
                    SORUMLUDOKTOR.TextFormat = @"dd/MM/yyyy";
                    SORUMLUDOKTOR.TextFont.Size = 9;
                    SORUMLUDOKTOR.TextFont.CharSet = 162;
                    SORUMLUDOKTOR.Value = @"";

                    KLINIKYATISTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 237, 4, 255, 9, false);
                    KLINIKYATISTARIHI.Name = "KLINIKYATISTARIHI";
                    KLINIKYATISTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    KLINIKYATISTARIHI.TextFormat = @"dd/MM/yyyy";
                    KLINIKYATISTARIHI.TextFont.Size = 9;
                    KLINIKYATISTARIHI.TextFont.CharSet = 162;
                    KLINIKYATISTARIHI.Value = @"";

                    KLINIKTABURCUTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 256, 4, 277, 9, false);
                    KLINIKTABURCUTARIHI.Name = "KLINIKTABURCUTARIHI";
                    KLINIKTABURCUTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    KLINIKTABURCUTARIHI.TextFormat = @"dd/MM/yyyy";
                    KLINIKTABURCUTARIHI.TextFont.Size = 9;
                    KLINIKTABURCUTARIHI.TextFont.CharSet = 162;
                    KLINIKTABURCUTARIHI.Value = @"";

                    YatisGunSayisi = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 278, 4, 291, 9, false);
                    YatisGunSayisi.Name = "YatisGunSayisi";
                    YatisGunSayisi.FieldType = ReportFieldTypeEnum.ftExpression;
                    YatisGunSayisi.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    InPatientTreatmentClinicApplication.GetpatientListReportByDaysNQL_Class dataset_GetpatientListReportByDaysNQL = MyParentReport.Klinik.rsGroup.GetCurrentRecord<InPatientTreatmentClinicApplication.GetpatientListReportByDaysNQL_Class>(0);
                    Sira.CalcValue = ParentGroup.GroupCounter.ToString();
                    TIBBIPROTOKOLNO.CalcValue = @"";
                    TCNO.CalcValue = @"";
                    SINIFRUTBE.CalcValue = @"";
                    HASTAADISOYADI.CalcValue = @"";
                    ODA.CalcValue = @"";
                    YATAK.CalcValue = @"";
                    KLINIK.CalcValue = @"";
                    SORUMLUDOKTOR.CalcValue = @"";
                    KLINIKYATISTARIHI.CalcValue = @"";
                    KLINIKTABURCUTARIHI.CalcValue = @"";
                    YatisGunSayisi.CalcValue = @"";
                    return new TTReportObject[] { Sira,TIBBIPROTOKOLNO,TCNO,SINIFRUTBE,HASTAADISOYADI,ODA,YATAK,KLINIK,SORUMLUDOKTOR,KLINIKYATISTARIHI,KLINIKTABURCUTARIHI,YatisGunSayisi};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    TTObjectContext context = new TTObjectContext(true);
            //  string objectid = this.OBJECTID.CalcValue;
            
            //  InPatientTreatmentClinicApplication inPatientTreatmentClinicApplication = (InPatientTreatmentClinicApplication)context.GetObject(new Guid(objectid),"InPatientTreatmentClinicApplication");
            
            BindingList<InPatientTreatmentClinicApplication.GetpatientListReportByDaysNQL_Class> inPatientTreatmentClinicApplication = InPatientTreatmentClinicApplication.GetpatientListReportByDaysNQL(Convert.ToInt32(((DischargedPatientListByDayReport)ParentReport).RuntimeParameters.INPATIENTDAYS),(((DischargedPatientListByDayReport)ParentReport).RuntimeParameters.PHYSICALSTATECLINIC).Value);
            foreach (InPatientTreatmentClinicApplication.GetpatientListReportByDaysNQL_Class item in inPatientTreatmentClinicApplication)
            {
                int yatisGunu = 0;
                if (item.Kliniktaburcutarihi == null)
                    yatisGunu = (DateTime.Now.Date - item.Klinikyatistarihi.Value.Date).Days;
                else
                    yatisGunu = (item.Kliniktaburcutarihi.Value.Date - item.Klinikyatistarihi.Value.Date).Days;

                if (yatisGunu > ((DischargedPatientListByDayReport)ParentReport).RuntimeParameters.INPATIENTDAYS)
                {
                    if (item.Protokolno != null)
                        this.TIBBIPROTOKOLNO.CalcValue = item.Protokolno.ToString();
                    if (item.Hastagrubu != null)
                    {
                        TTDataType dataType = TTObjectDefManager.Instance.DataTypes[typeof(PatientGroupEnum).Name];
                        SINIFRUTBE.CalcValue = dataType.EnumValueDefs[(int)item.Hastagrubu].DisplayText;
                    }
                    TCNO.CalcValue = item.Tcno.ToString();
                    HASTAADISOYADI.CalcValue = item.Hastaadi + " " + item.Hastasoyadi;
                    if(item.Oda != null)
                    {
                        ResRoom resRoom = (ResRoom)context.GetObject(new Guid(item.Oda.ToString()),"ResRoom");
                        ODA.CalcValue =resRoom.Name;
                    }
                    if(item.Yatak != null)
                    {
                        ResBed resBed= (ResBed)context.GetObject(new Guid(item.Yatak.ToString()),"ResBed");
                        YATAK.CalcValue = resBed.Name ;
                    }
                    KLINIK.CalcValue = item.Yattigiklinik;
                    SORUMLUDOKTOR.CalcValue = item.Sorumludoktor;
                    KLINIKYATISTARIHI.CalcValue = item.Klinikyatistarihi.ToString();
                    if (item .Kliniktaburcutarihi != null)
                        KLINIKTABURCUTARIHI.CalcValue = item.Kliniktaburcutarihi.ToString();
                    YatisGunSayisi.CalcValue = yatisGunu.ToString();
                }
            }
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

        public DischargedPatientListByDayReport()
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
            reportParameter = Parameters.Add("INPATIENTDAYS", "", "Yatış Gün Sayısı", @"", true, true, false, new Guid("356d7e0d-2f55-4f72-a85b-b1477416e9e1"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("PHYSICALSTATECLINIC"))
                _runtimeParameters.PHYSICALSTATECLINIC = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["PHYSICALSTATECLINIC"]);
            if (parameters.ContainsKey("INPATIENTDAYS"))
                _runtimeParameters.INPATIENTDAYS = (int?)TTObjectDefManager.Instance.DataTypes["Integer_"].ConvertValue(parameters["INPATIENTDAYS"]);
            Name = "DISCHARGEDPATIENTLISTBYDAYREPORT";
            Caption = "Yatan ve Taburcu Hasta Listesi";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oeLandscape;
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
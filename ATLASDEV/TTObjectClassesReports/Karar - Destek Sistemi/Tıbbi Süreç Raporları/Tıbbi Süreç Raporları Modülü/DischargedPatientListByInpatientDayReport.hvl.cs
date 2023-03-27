
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
    /// Yatış Gün Sayısına Göre Hasta Listesi
    /// </summary>
    public partial class DischargedPatientListByInpatientDayReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? PHYSICALSTATECLINIC = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
            public int? INPATIENTDAYS = (int?)TTObjectDefManager.Instance.DataTypes["Integer_"].ConvertValue("");
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
        }

        public partial class HeaderGroup : TTReportGroup
        {
            public DischargedPatientListByInpatientDayReport MyParentReport
            {
                get { return (DischargedPatientListByInpatientDayReport)ParentReport; }
            }

            new public HeaderGroupHeader Header()
            {
                return (HeaderGroupHeader)_header;
            }

            new public HeaderGroupFooter Footer()
            {
                return (HeaderGroupFooter)_footer;
            }

            public TTReportField XXXXXXBaslik1 { get {return Header().XXXXXXBaslik1;} }
            public TTReportField BASLIK { get {return Header().BASLIK;} }
            public TTReportField BaslangıcTarihi { get {return Header().BaslangıcTarihi;} }
            public TTReportShape NewLine12 { get {return Footer().NewLine12;} }
            public TTReportField LBLToplamYatanHastaSayısı { get {return Footer().LBLToplamYatanHastaSayısı;} }
            public TTReportField HASTASAYISI1 { get {return Footer().HASTASAYISI1;} }
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
                public DischargedPatientListByInpatientDayReport MyParentReport
                {
                    get { return (DischargedPatientListByInpatientDayReport)ParentReport; }
                }
                
                public TTReportField XXXXXXBaslik1;
                public TTReportField BASLIK;
                public TTReportField BaslangıcTarihi; 
                public HeaderGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 43;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    XXXXXXBaslik1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 79, 5, 230, 28, false);
                    XXXXXXBaslik1.Name = "XXXXXXBaslik1";
                    XXXXXXBaslik1.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXBaslik1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBaslik1.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBaslik1.NoClip = EvetHayirEnum.ehEvet;
                    XXXXXXBaslik1.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXBaslik1.ExpandTabs = EvetHayirEnum.ehEvet;
                    XXXXXXBaslik1.TextFont.Size = 11;
                    XXXXXXBaslik1.TextFont.Bold = true;
                    XXXXXXBaslik1.TextFont.CharSet = 162;
                    XXXXXXBaslik1.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + ""\r\n"" + TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    BASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 113, 30, 227, 38, false);
                    BASLIK.Name = "BASLIK";
                    BASLIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    BASLIK.TextFont.Size = 15;
                    BASLIK.TextFont.Bold = true;
                    BASLIK.TextFont.CharSet = 162;
                    BASLIK.Value = @"";

                    BaslangıcTarihi = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 89, 30, 114, 38, false);
                    BaslangıcTarihi.Name = "BaslangıcTarihi";
                    BaslangıcTarihi.FieldType = ReportFieldTypeEnum.ftVariable;
                    BaslangıcTarihi.TextFormat = @"dd/MM/yyyy";
                    BaslangıcTarihi.HorzAlign = HorizontalAlignmentEnum.haRight;
                    BaslangıcTarihi.TextFont.Size = 15;
                    BaslangıcTarihi.TextFont.Bold = true;
                    BaslangıcTarihi.TextFont.CharSet = 162;
                    BaslangıcTarihi.Value = @"{@STARTDATE@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    BASLIK.CalcValue = @"";
                    BaslangıcTarihi.CalcValue = MyParentReport.RuntimeParameters.STARTDATE.ToString();
                    XXXXXXBaslik1.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { BASLIK,BaslangıcTarihi,XXXXXXBaslik1};
                }
                public override void RunPreScript()
                {
#region HEADER HEADER_PreScript
                    //((DischargedPatientListByInpatientDayReport)ParentReport).RuntimeParameters.ENDDATE = Convert.ToDateTime(((DischargedPatientListByInpatientDayReport)ParentReport).RuntimeParameters.STARTDATE.ToString()).AddDays(Convert.ToInt32( ((DischargedPatientListByInpatientDayReport)ParentReport).RuntimeParameters.INPATIENTDAYS.ToString()));
            
          // ((DischargedPatientListByInpatientDayReport)ParentReport).RuntimeParameters.ENDDATE = Convert.ToDateTime(((DischargedPatientListByInpatientDayReport)ParentReport).RuntimeParameters.ENDDATE.ToString()).AddDays(1);
#endregion HEADER HEADER_PreScript
                }

                public override void RunScript()
                {
#region HEADER HEADER_Script
                    BASLIK.CalcValue = " - " + ((DischargedPatientListByInpatientDayReport)ParentReport).RuntimeParameters.INPATIENTDAYS.ToString() + " GÜNDEN FAZLA YATAN HASTA LİSTESİ" ;
#endregion HEADER HEADER_Script
                }
            }
            public partial class HeaderGroupFooter : TTReportSection
            {
                public DischargedPatientListByInpatientDayReport MyParentReport
                {
                    get { return (DischargedPatientListByInpatientDayReport)ParentReport; }
                }
                
                public TTReportShape NewLine12;
                public TTReportField LBLToplamYatanHastaSayısı;
                public TTReportField HASTASAYISI1; 
                public HeaderGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 8;
                    RepeatCount = 0;
                    
                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, 0, 280, 0, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;

                    LBLToplamYatanHastaSayısı = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 1, 43, 6, false);
                    LBLToplamYatanHastaSayısı.Name = "LBLToplamYatanHastaSayısı";
                    LBLToplamYatanHastaSayısı.TextFont.Size = 9;
                    LBLToplamYatanHastaSayısı.TextFont.Bold = true;
                    LBLToplamYatanHastaSayısı.TextFont.CharSet = 162;
                    LBLToplamYatanHastaSayısı.Value = @"Toplam Yatan Hasta Sayısı :";

                    HASTASAYISI1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 1, 64, 6, false);
                    HASTASAYISI1.Name = "HASTASAYISI1";
                    HASTASAYISI1.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTASAYISI1.TextFont.Size = 9;
                    HASTASAYISI1.TextFont.CharSet = 162;
                    HASTASAYISI1.Value = @"{@sumof(TOPLAMHASTASAYISI1)@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    LBLToplamYatanHastaSayısı.CalcValue = LBLToplamYatanHastaSayısı.Value;
                    HASTASAYISI1.CalcValue = ParentGroup.FieldSums["TOPLAMHASTASAYISI1"].Value.ToString();;
                    return new TTReportObject[] { LBLToplamYatanHastaSayısı,HASTASAYISI1};
                }
            }

        }

        public HeaderGroup Header;

        public partial class KlinikGroup : TTReportGroup
        {
            public DischargedPatientListByInpatientDayReport MyParentReport
            {
                get { return (DischargedPatientListByInpatientDayReport)ParentReport; }
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
            public TTReportShape NewLine11 { get {return Footer().NewLine11;} }
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
                list[0] = new TTReportNqlData<InPatientTreatmentClinicApplication.GetpatientListReportByInpatientDayNQL_Class>("GetpatientListReportByInpatientDayNQL", InPatientTreatmentClinicApplication.GetpatientListReportByInpatientDayNQL((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.PHYSICALSTATECLINIC),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(int)TTObjectDefManager.Instance.DataTypes["Integer_"].ConvertValue(MyParentReport.RuntimeParameters.INPATIENTDAYS)));
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
                public DischargedPatientListByInpatientDayReport MyParentReport
                {
                    get { return (DischargedPatientListByInpatientDayReport)ParentReport; }
                }
                
                public TTReportField YATTIGIKLINIK; 
                public KlinikGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 10;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    YATTIGIKLINIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 5, 289, 10, false);
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
                    InPatientTreatmentClinicApplication.GetpatientListReportByInpatientDayNQL_Class dataset_GetpatientListReportByInpatientDayNQL = ParentGroup.rsGroup.GetCurrentRecord<InPatientTreatmentClinicApplication.GetpatientListReportByInpatientDayNQL_Class>(0);
                    YATTIGIKLINIK.CalcValue = (dataset_GetpatientListReportByInpatientDayNQL != null ? Globals.ToStringCore(dataset_GetpatientListReportByInpatientDayNQL.Yattigiklinik) : "");
                    YATTIGIKLINIK.PostFieldValueCalculation();
                    return new TTReportObject[] { YATTIGIKLINIK};
                }
            }
            public partial class KlinikGroupFooter : TTReportSection
            {
                public DischargedPatientListByInpatientDayReport MyParentReport
                {
                    get { return (DischargedPatientListByInpatientDayReport)ParentReport; }
                }
                
                public TTReportShape NewLine11; 
                public KlinikGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 5;
                    RepeatCount = 0;
                    
                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 9, 2, 289, 2, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    InPatientTreatmentClinicApplication.GetpatientListReportByInpatientDayNQL_Class dataset_GetpatientListReportByInpatientDayNQL = ParentGroup.rsGroup.GetCurrentRecord<InPatientTreatmentClinicApplication.GetpatientListReportByInpatientDayNQL_Class>(0);
                    return new TTReportObject[] { };
                }
            }

        }

        public KlinikGroup Klinik;

        public partial class OdaGrupGroup : TTReportGroup
        {
            public DischargedPatientListByInpatientDayReport MyParentReport
            {
                get { return (DischargedPatientListByInpatientDayReport)ParentReport; }
            }

            new public OdaGrupGroupHeader Header()
            {
                return (OdaGrupGroupHeader)_header;
            }

            new public OdaGrupGroupFooter Footer()
            {
                return (OdaGrupGroupFooter)_footer;
            }

            public TTReportField ODAGRUBU { get {return Header().ODAGRUBU;} }
            public TTReportField LBLTCNO1 { get {return Header().LBLTCNO1;} }
            public TTReportField LBLHASTAADISOYADI1 { get {return Header().LBLHASTAADISOYADI1;} }
            public TTReportField LBLODA1 { get {return Header().LBLODA1;} }
            public TTReportField LBLKLINIKYATISTARIHI1 { get {return Header().LBLKLINIKYATISTARIHI1;} }
            public TTReportField LBLTIBBIPROTOKOLNO1 { get {return Header().LBLTIBBIPROTOKOLNO1;} }
            public TTReportField LBLYATAK1 { get {return Header().LBLYATAK1;} }
            public TTReportField LBLKLINIKYATISTARIHI11 { get {return Header().LBLKLINIKYATISTARIHI11;} }
            public TTReportField LBLSıra1 { get {return Header().LBLSıra1;} }
            public TTReportField LBLSORUMLUDOKTOR1 { get {return Header().LBLSORUMLUDOKTOR1;} }
            public TTReportField LBLSINIFRUTBE1 { get {return Header().LBLSINIFRUTBE1;} }
            public TTReportField lblYatisGun { get {return Header().lblYatisGun;} }
            public TTReportField LBLTABURCUTARIHI { get {return Header().LBLTABURCUTARIHI;} }
            public OdaGrupGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public OdaGrupGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override object[] GetGroupByValues()
            {

                InPatientTreatmentClinicApplication.GetpatientListReportByInpatientDayNQL_Class dataSet_GetpatientListReportByInpatientDayNQL = ParentGroup.rsGroup.GetCurrentRecord<InPatientTreatmentClinicApplication.GetpatientListReportByInpatientDayNQL_Class>(0);    
                return new object[] {(dataSet_GetpatientListReportByInpatientDayNQL==null ? null : dataSet_GetpatientListReportByInpatientDayNQL.Yattigiklinik)};
            }
            private void onConstruct()
            {
                _body = null;
                _header = new OdaGrupGroupHeader(this);
                _footer = new OdaGrupGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstParentRS;
            }

            public partial class OdaGrupGroupHeader : TTReportSection
            {
                public DischargedPatientListByInpatientDayReport MyParentReport
                {
                    get { return (DischargedPatientListByInpatientDayReport)ParentReport; }
                }
                
                public TTReportField ODAGRUBU;
                public TTReportField LBLTCNO1;
                public TTReportField LBLHASTAADISOYADI1;
                public TTReportField LBLODA1;
                public TTReportField LBLKLINIKYATISTARIHI1;
                public TTReportField LBLTIBBIPROTOKOLNO1;
                public TTReportField LBLYATAK1;
                public TTReportField LBLKLINIKYATISTARIHI11;
                public TTReportField LBLSıra1;
                public TTReportField LBLSORUMLUDOKTOR1;
                public TTReportField LBLSINIFRUTBE1;
                public TTReportField lblYatisGun;
                public TTReportField LBLTABURCUTARIHI; 
                public OdaGrupGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 11;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    ODAGRUBU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 0, 289, 5, false);
                    ODAGRUBU.Name = "ODAGRUBU";
                    ODAGRUBU.FieldType = ReportFieldTypeEnum.ftVariable;
                    ODAGRUBU.ObjectDefName = "ResRoomGroup";
                    ODAGRUBU.DataMember = "NAME";
                    ODAGRUBU.TextFont.Size = 9;
                    ODAGRUBU.TextFont.Bold = true;
                    ODAGRUBU.TextFont.CharSet = 162;
                    ODAGRUBU.Value = @"{#Klinik.ODAGRUBU#}";

                    LBLTCNO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 6, 60, 11, false);
                    LBLTCNO1.Name = "LBLTCNO1";
                    LBLTCNO1.TextFont.Size = 9;
                    LBLTCNO1.TextFont.Bold = true;
                    LBLTCNO1.TextFont.CharSet = 162;
                    LBLTCNO1.Value = @"TC Kimlik No";

                    LBLHASTAADISOYADI1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 89, 6, 125, 11, false);
                    LBLHASTAADISOYADI1.Name = "LBLHASTAADISOYADI1";
                    LBLHASTAADISOYADI1.TextFont.Size = 9;
                    LBLHASTAADISOYADI1.TextFont.Bold = true;
                    LBLHASTAADISOYADI1.TextFont.CharSet = 162;
                    LBLHASTAADISOYADI1.Value = @"Hasta Adı Soyadı ";

                    LBLODA1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 126, 6, 140, 11, false);
                    LBLODA1.Name = "LBLODA1";
                    LBLODA1.TextFont.Size = 9;
                    LBLODA1.TextFont.Bold = true;
                    LBLODA1.TextFont.CharSet = 162;
                    LBLODA1.Value = @"Oda";

                    LBLKLINIKYATISTARIHI1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 231, 6, 252, 11, false);
                    LBLKLINIKYATISTARIHI1.Name = "LBLKLINIKYATISTARIHI1";
                    LBLKLINIKYATISTARIHI1.TextFont.Size = 9;
                    LBLKLINIKYATISTARIHI1.TextFont.Bold = true;
                    LBLKLINIKYATISTARIHI1.TextFont.CharSet = 162;
                    LBLKLINIKYATISTARIHI1.Value = @"Klinik Yatış Tar.";

                    LBLTIBBIPROTOKOLNO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 6, 41, 11, false);
                    LBLTIBBIPROTOKOLNO1.Name = "LBLTIBBIPROTOKOLNO1";
                    LBLTIBBIPROTOKOLNO1.TextFont.Size = 9;
                    LBLTIBBIPROTOKOLNO1.TextFont.Bold = true;
                    LBLTIBBIPROTOKOLNO1.TextFont.CharSet = 162;
                    LBLTIBBIPROTOKOLNO1.Value = @"Tıbbi Kayıt Pr.Nu.";

                    LBLYATAK1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 141, 6, 156, 11, false);
                    LBLYATAK1.Name = "LBLYATAK1";
                    LBLYATAK1.TextFont.Size = 9;
                    LBLYATAK1.TextFont.Bold = true;
                    LBLYATAK1.TextFont.CharSet = 162;
                    LBLYATAK1.Value = @"Yatak";

                    LBLKLINIKYATISTARIHI11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 157, 6, 199, 11, false);
                    LBLKLINIKYATISTARIHI11.Name = "LBLKLINIKYATISTARIHI11";
                    LBLKLINIKYATISTARIHI11.TextFont.Size = 9;
                    LBLKLINIKYATISTARIHI11.TextFont.Bold = true;
                    LBLKLINIKYATISTARIHI11.TextFont.CharSet = 162;
                    LBLKLINIKYATISTARIHI11.Value = @"Tedavi Gördüğü Klinik";

                    LBLSıra1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 6, 17, 11, false);
                    LBLSıra1.Name = "LBLSıra1";
                    LBLSıra1.TextFont.Size = 9;
                    LBLSıra1.TextFont.Bold = true;
                    LBLSıra1.TextFont.CharSet = 162;
                    LBLSıra1.Value = @"Sıra";

                    LBLSORUMLUDOKTOR1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 200, 6, 230, 11, false);
                    LBLSORUMLUDOKTOR1.Name = "LBLSORUMLUDOKTOR1";
                    LBLSORUMLUDOKTOR1.TextFont.Size = 9;
                    LBLSORUMLUDOKTOR1.TextFont.Bold = true;
                    LBLSORUMLUDOKTOR1.TextFont.CharSet = 162;
                    LBLSORUMLUDOKTOR1.Value = @"Sorumlu Doktor";

                    LBLSINIFRUTBE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 6, 88, 11, false);
                    LBLSINIFRUTBE1.Name = "LBLSINIFRUTBE1";
                    LBLSINIFRUTBE1.TextFont.Size = 9;
                    LBLSINIFRUTBE1.TextFont.Bold = true;
                    LBLSINIFRUTBE1.TextFont.CharSet = 162;
                    LBLSINIFRUTBE1.Value = @"Sınıf Rütbe";

                    lblYatisGun = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 275, 6, 289, 11, false);
                    lblYatisGun.Name = "lblYatisGun";
                    lblYatisGun.TextFont.Size = 9;
                    lblYatisGun.TextFont.Bold = true;
                    lblYatisGun.TextFont.CharSet = 162;
                    lblYatisGun.Value = @"Yatış Gün";

                    LBLTABURCUTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 253, 6, 274, 11, false);
                    LBLTABURCUTARIHI.Name = "LBLTABURCUTARIHI";
                    LBLTABURCUTARIHI.TextFont.Size = 9;
                    LBLTABURCUTARIHI.TextFont.Bold = true;
                    LBLTABURCUTARIHI.TextFont.CharSet = 162;
                    LBLTABURCUTARIHI.Value = @"Taburcu Tar.";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    InPatientTreatmentClinicApplication.GetpatientListReportByInpatientDayNQL_Class dataset_GetpatientListReportByInpatientDayNQL = MyParentReport.Klinik.rsGroup.GetCurrentRecord<InPatientTreatmentClinicApplication.GetpatientListReportByInpatientDayNQL_Class>(0);
                    ODAGRUBU.CalcValue = (dataset_GetpatientListReportByInpatientDayNQL != null ? Globals.ToStringCore(dataset_GetpatientListReportByInpatientDayNQL.Odagrubu) : "");
                    ODAGRUBU.PostFieldValueCalculation();
                    LBLTCNO1.CalcValue = LBLTCNO1.Value;
                    LBLHASTAADISOYADI1.CalcValue = LBLHASTAADISOYADI1.Value;
                    LBLODA1.CalcValue = LBLODA1.Value;
                    LBLKLINIKYATISTARIHI1.CalcValue = LBLKLINIKYATISTARIHI1.Value;
                    LBLTIBBIPROTOKOLNO1.CalcValue = LBLTIBBIPROTOKOLNO1.Value;
                    LBLYATAK1.CalcValue = LBLYATAK1.Value;
                    LBLKLINIKYATISTARIHI11.CalcValue = LBLKLINIKYATISTARIHI11.Value;
                    LBLSıra1.CalcValue = LBLSıra1.Value;
                    LBLSORUMLUDOKTOR1.CalcValue = LBLSORUMLUDOKTOR1.Value;
                    LBLSINIFRUTBE1.CalcValue = LBLSINIFRUTBE1.Value;
                    lblYatisGun.CalcValue = lblYatisGun.Value;
                    LBLTABURCUTARIHI.CalcValue = LBLTABURCUTARIHI.Value;
                    return new TTReportObject[] { ODAGRUBU,LBLTCNO1,LBLHASTAADISOYADI1,LBLODA1,LBLKLINIKYATISTARIHI1,LBLTIBBIPROTOKOLNO1,LBLYATAK1,LBLKLINIKYATISTARIHI11,LBLSıra1,LBLSORUMLUDOKTOR1,LBLSINIFRUTBE1,lblYatisGun,LBLTABURCUTARIHI};
                }
            }
            public partial class OdaGrupGroupFooter : TTReportSection
            {
                public DischargedPatientListByInpatientDayReport MyParentReport
                {
                    get { return (DischargedPatientListByInpatientDayReport)ParentReport; }
                }
                 
                public OdaGrupGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 7;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public OdaGrupGroup OdaGrup;

        public partial class MAINGroup : TTReportGroup
        {
            public DischargedPatientListByInpatientDayReport MyParentReport
            {
                get { return (DischargedPatientListByInpatientDayReport)ParentReport; }
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
            public TTReportField YatisGun { get {return Body().YatisGun;} }
            public TTReportField TABURCUTARIHI { get {return Body().TABURCUTARIHI;} }
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

                InPatientTreatmentClinicApplication.GetpatientListReportByInpatientDayNQL_Class dataSet_GetpatientListReportByInpatientDayNQL = ParentGroup.rsGroup.GetCurrentRecord<InPatientTreatmentClinicApplication.GetpatientListReportByInpatientDayNQL_Class>(0);    
                return new object[] {(dataSet_GetpatientListReportByInpatientDayNQL==null ? null : dataSet_GetpatientListReportByInpatientDayNQL.Odagrubu)};
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
                public DischargedPatientListByInpatientDayReport MyParentReport
                {
                    get { return (DischargedPatientListByInpatientDayReport)ParentReport; }
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
                public TTReportField YatisGun;
                public TTReportField TABURCUTARIHI; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 8;
                    RepeatCount = 0;
                    
                    TIBBIPROTOKOLNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 3, 41, 8, false);
                    TIBBIPROTOKOLNO.Name = "TIBBIPROTOKOLNO";
                    TIBBIPROTOKOLNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    TIBBIPROTOKOLNO.TextFont.Size = 9;
                    TIBBIPROTOKOLNO.TextFont.CharSet = 162;
                    TIBBIPROTOKOLNO.Value = @"";

                    TCNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 42, 3, 60, 8, false);
                    TCNO.Name = "TCNO";
                    TCNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    TCNO.TextFont.Size = 9;
                    TCNO.TextFont.CharSet = 162;
                    TCNO.Value = @"{#Klinik.TCNO#}";

                    HASTAADISOYADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 89, 3, 125, 8, false);
                    HASTAADISOYADI.Name = "HASTAADISOYADI";
                    HASTAADISOYADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTAADISOYADI.TextFont.Size = 9;
                    HASTAADISOYADI.TextFont.CharSet = 162;
                    HASTAADISOYADI.Value = @"{%HASTAADI%} {%HASTASOYADI%}";

                    ODA = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 126, 3, 140, 8, false);
                    ODA.Name = "ODA";
                    ODA.FieldType = ReportFieldTypeEnum.ftVariable;
                    ODA.ObjectDefName = "ResRoom";
                    ODA.DataMember = "NAME";
                    ODA.TextFont.Size = 9;
                    ODA.TextFont.CharSet = 162;
                    ODA.Value = @"{#Klinik.ODA#}";

                    YATAK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 141, 3, 156, 8, false);
                    YATAK.Name = "YATAK";
                    YATAK.FieldType = ReportFieldTypeEnum.ftVariable;
                    YATAK.ObjectDefName = "ResBed";
                    YATAK.DataMember = "NAME";
                    YATAK.TextFont.Size = 9;
                    YATAK.TextFont.CharSet = 162;
                    YATAK.Value = @"{#Klinik.YATAK#}";

                    KLINIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 157, 3, 199, 8, false);
                    KLINIK.Name = "KLINIK";
                    KLINIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    KLINIK.ObjectDefName = "ResWard";
                    KLINIK.DataMember = "NAME";
                    KLINIK.TextFont.Size = 9;
                    KLINIK.TextFont.CharSet = 162;
                    KLINIK.Value = @"{#Klinik.TEDAVIKLINIK#}";

                    KLINIKYATISTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 231, 3, 252, 8, false);
                    KLINIKYATISTARIHI.Name = "KLINIKYATISTARIHI";
                    KLINIKYATISTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    KLINIKYATISTARIHI.TextFormat = @"dd/MM/yyyy";
                    KLINIKYATISTARIHI.TextFont.Size = 9;
                    KLINIKYATISTARIHI.TextFont.CharSet = 162;
                    KLINIKYATISTARIHI.Value = @"{#Klinik.KLINIKYATISTARIHI#}";

                    HASTASOYADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 348, 3, 384, 8, false);
                    HASTASOYADI.Name = "HASTASOYADI";
                    HASTASOYADI.Visible = EvetHayirEnum.ehHayir;
                    HASTASOYADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTASOYADI.TextFont.Size = 9;
                    HASTASOYADI.TextFont.CharSet = 162;
                    HASTASOYADI.Value = @"{#Klinik.HASTASOYADI#}";

                    HASTAADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 312, 3, 348, 8, false);
                    HASTAADI.Name = "HASTAADI";
                    HASTAADI.Visible = EvetHayirEnum.ehHayir;
                    HASTAADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTAADI.TextFont.Size = 9;
                    HASTAADI.TextFont.CharSet = 162;
                    HASTAADI.Value = @"{#Klinik.HASTAADI#}";

                    SIRA = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 3, 17, 8, false);
                    SIRA.Name = "SIRA";
                    SIRA.FieldType = ReportFieldTypeEnum.ftVariable;
                    SIRA.TextFont.Size = 9;
                    SIRA.TextFont.CharSet = 162;
                    SIRA.Value = @"{@groupcounter@}";

                    OBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 384, 3, 420, 8, false);
                    OBJECTID.Name = "OBJECTID";
                    OBJECTID.Visible = EvetHayirEnum.ehHayir;
                    OBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBJECTID.TextFont.Size = 9;
                    OBJECTID.TextFont.CharSet = 162;
                    OBJECTID.Value = @"{#Klinik.OBJECTID#}";

                    SORUMLUDOKTOR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 200, 3, 230, 8, false);
                    SORUMLUDOKTOR.Name = "SORUMLUDOKTOR";
                    SORUMLUDOKTOR.FieldType = ReportFieldTypeEnum.ftVariable;
                    SORUMLUDOKTOR.TextFont.Size = 9;
                    SORUMLUDOKTOR.TextFont.CharSet = 162;
                    SORUMLUDOKTOR.Value = @"{#Klinik.SORUMLUDOKTOR#}";

                    SINIFRUTBE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 3, 88, 8, false);
                    SINIFRUTBE.Name = "SINIFRUTBE";
                    SINIFRUTBE.FieldType = ReportFieldTypeEnum.ftVariable;
                    SINIFRUTBE.TextFont.Size = 9;
                    SINIFRUTBE.TextFont.CharSet = 162;
                    SINIFRUTBE.Value = @"";

                    YatisGun = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 275, 3, 289, 8, false);
                    YatisGun.Name = "YatisGun";
                    YatisGun.FieldType = ReportFieldTypeEnum.ftVariable;
                    YatisGun.Value = @"";

                    TABURCUTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 253, 3, 274, 8, false);
                    TABURCUTARIHI.Name = "TABURCUTARIHI";
                    TABURCUTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    TABURCUTARIHI.TextFormat = @"dd/MM/yyyy";
                    TABURCUTARIHI.TextFont.Size = 9;
                    TABURCUTARIHI.TextFont.CharSet = 162;
                    TABURCUTARIHI.Value = @"{#Klinik.KLINIKTABURCUTARIHI#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    InPatientTreatmentClinicApplication.GetpatientListReportByInpatientDayNQL_Class dataset_GetpatientListReportByInpatientDayNQL = MyParentReport.Klinik.rsGroup.GetCurrentRecord<InPatientTreatmentClinicApplication.GetpatientListReportByInpatientDayNQL_Class>(0);
                    TIBBIPROTOKOLNO.CalcValue = @"";
                    TCNO.CalcValue = (dataset_GetpatientListReportByInpatientDayNQL != null ? Globals.ToStringCore(dataset_GetpatientListReportByInpatientDayNQL.Tcno) : "");
                    HASTAADI.CalcValue = (dataset_GetpatientListReportByInpatientDayNQL != null ? Globals.ToStringCore(dataset_GetpatientListReportByInpatientDayNQL.Hastaadi) : "");
                    HASTASOYADI.CalcValue = (dataset_GetpatientListReportByInpatientDayNQL != null ? Globals.ToStringCore(dataset_GetpatientListReportByInpatientDayNQL.Hastasoyadi) : "");
                    HASTAADISOYADI.CalcValue = MyParentReport.MAIN.HASTAADI.CalcValue + @" " + MyParentReport.MAIN.HASTASOYADI.CalcValue;
                    ODA.CalcValue = (dataset_GetpatientListReportByInpatientDayNQL != null ? Globals.ToStringCore(dataset_GetpatientListReportByInpatientDayNQL.Oda) : "");
                    ODA.PostFieldValueCalculation();
                    YATAK.CalcValue = (dataset_GetpatientListReportByInpatientDayNQL != null ? Globals.ToStringCore(dataset_GetpatientListReportByInpatientDayNQL.Yatak) : "");
                    YATAK.PostFieldValueCalculation();
                    KLINIK.CalcValue = (dataset_GetpatientListReportByInpatientDayNQL != null ? Globals.ToStringCore(dataset_GetpatientListReportByInpatientDayNQL.Tedaviklinik) : "");
                    KLINIK.PostFieldValueCalculation();
                    KLINIKYATISTARIHI.CalcValue = (dataset_GetpatientListReportByInpatientDayNQL != null ? Globals.ToStringCore(dataset_GetpatientListReportByInpatientDayNQL.Klinikyatistarihi) : "");
                    SIRA.CalcValue = ParentGroup.GroupCounter.ToString();
                    OBJECTID.CalcValue = (dataset_GetpatientListReportByInpatientDayNQL != null ? Globals.ToStringCore(dataset_GetpatientListReportByInpatientDayNQL.ObjectID) : "");
                    SORUMLUDOKTOR.CalcValue = (dataset_GetpatientListReportByInpatientDayNQL != null ? Globals.ToStringCore(dataset_GetpatientListReportByInpatientDayNQL.Sorumludoktor) : "");
                    SINIFRUTBE.CalcValue = @"";
                    YatisGun.CalcValue = @"";
                    TABURCUTARIHI.CalcValue = (dataset_GetpatientListReportByInpatientDayNQL != null ? Globals.ToStringCore(dataset_GetpatientListReportByInpatientDayNQL.Kliniktaburcutarihi) : "");
                    return new TTReportObject[] { TIBBIPROTOKOLNO,TCNO,HASTAADI,HASTASOYADI,HASTAADISOYADI,ODA,YATAK,KLINIK,KLINIKYATISTARIHI,SIRA,OBJECTID,SORUMLUDOKTOR,SINIFRUTBE,YatisGun,TABURCUTARIHI};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    //                                                                                     TTObjectContext context = new TTObjectContext(true);
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
//            int yatisGunSayisi = Convert.ToInt32((((DischargedPatientListByInpatientDayReport)ParentReport).RuntimeParameters.INPATIENTDAYS).Value);
//            
//           
//             
//            if (string.IsNullOrEmpty(TABURCUTARIHI.CalcValue))
//                YatisGun.CalcValue =  (DateTime.Now.Date - Convert.ToDateTime(KLINIKYATISTARIHI.CalcValue).Date ).Days.ToString();
//                else
//                    YatisGun.CalcValue = (Convert.ToDateTime(TABURCUTARIHI.CalcValue).Date - Convert.ToDateTime(KLINIKYATISTARIHI.CalcValue).Date).Days.ToString();
//
//
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

        public DischargedPatientListByInpatientDayReport()
        {
            Header = new HeaderGroup(this,"Header");
            Klinik = new KlinikGroup(Header,"Klinik");
            OdaGrup = new OdaGrupGroup(Klinik,"OdaGrup");
            MAIN = new MAINGroup(OdaGrup,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("PHYSICALSTATECLINIC", "00000000-0000-0000-0000-000000000000", "Yattığı Klinik", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("20fdb56a-389f-46c9-8cd5-f604eddab75f");
            reportParameter = Parameters.Add("INPATIENTDAYS", "", "Yatış Gün Sayısı", @"", true, true, false, new Guid("356d7e0d-2f55-4f72-a85b-b1477416e9e1"));
            reportParameter = Parameters.Add("STARTDATE", "", "Başlangıç Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("PHYSICALSTATECLINIC"))
                _runtimeParameters.PHYSICALSTATECLINIC = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["PHYSICALSTATECLINIC"]);
            if (parameters.ContainsKey("INPATIENTDAYS"))
                _runtimeParameters.INPATIENTDAYS = (int?)TTObjectDefManager.Instance.DataTypes["Integer_"].ConvertValue(parameters["INPATIENTDAYS"]);
            if (parameters.ContainsKey("STARTDATE"))
                _runtimeParameters.STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTDATE"]);
            Name = "DISCHARGEDPATIENTLISTBYINPATIENTDAYREPORT";
            Caption = "Yatış Gün Sayısına Göre Hasta Listesi";
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
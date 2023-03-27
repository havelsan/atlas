
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
    /// Günlük Sağlık İstatistikleri(Yatan Hasta)
    /// </summary>
    public partial class DailyInPatientStatisticsReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public Guid? SELECTEDRESOURCE = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class MAINGroup : TTReportGroup
        {
            public DailyInPatientStatisticsReport MyParentReport
            {
                get { return (DailyInPatientStatisticsReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField BIRIM { get {return Body().BIRIM;} }
            public TTReportField SUBAY { get {return Body().SUBAY;} }
            public TTReportField ASTSUBAY { get {return Body().ASTSUBAY;} }
            public TTReportField SIVILMEMUR { get {return Body().SIVILMEMUR;} }
            public TTReportField UZMANERBAS { get {return Body().UZMANERBAS;} }
            public TTReportField ERERBAS { get {return Body().ERERBAS;} }
            public TTReportField OGRENCI { get {return Body().OGRENCI;} }
            public TTReportField EMEKLI { get {return Body().EMEKLI;} }
            public TTReportField SIVIL { get {return Body().SIVIL;} }
            public TTReportField HIZMETDISITOTAL { get {return Body().HIZMETDISITOTAL;} }
            public TTReportField UZMANJANDARMA { get {return Body().UZMANJANDARMA;} }
            public TTReportField DIGERHIZMETICI { get {return Body().DIGERHIZMETICI;} }
            public TTReportField DIGERHIZMETDISI { get {return Body().DIGERHIZMETDISI;} }
            public TTReportField XXXXXXIPERSONELAILE { get {return Body().XXXXXXIPERSONELAILE;} }
            public TTReportField XXXXXXIEMEKLIAILE { get {return Body().XXXXXXIEMEKLIAILE;} }
            public TTReportField GENELTOTAL { get {return Body().GENELTOTAL;} }
            public TTReportField HIZMETICITOTAL { get {return Body().HIZMETICITOTAL;} }
            public TTReportField GENERALAMIRAL { get {return Body().GENERALAMIRAL;} }
            public TTReportField YOGUNBAKIMYATANHASTA { get {return Body().YOGUNBAKIMYATANHASTA;} }
            public TTReportField YOGUNBAKIMYATAKSAYISI { get {return Body().YOGUNBAKIMYATAKSAYISI;} }
            public TTReportField YOGUNBAKIMBOSYATAK { get {return Body().YOGUNBAKIMBOSYATAK;} }
            public TTReportField KLINIKYATANHASTA { get {return Body().KLINIKYATANHASTA;} }
            public TTReportField KLINIKYATAKSAYISI { get {return Body().KLINIKYATAKSAYISI;} }
            public TTReportField KLINIKBOSYATAK { get {return Body().KLINIKBOSYATAK;} }
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
                list[0] = new TTReportNqlData<ResBed.GetAllResBedByResWard_Class>("GetAllResBedByResWard", ResBed.GetAllResBedByResWard((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.SELECTEDRESOURCE)));
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
                public DailyInPatientStatisticsReport MyParentReport
                {
                    get { return (DailyInPatientStatisticsReport)ParentReport; }
                }
                
                public TTReportField BIRIM;
                public TTReportField SUBAY;
                public TTReportField ASTSUBAY;
                public TTReportField SIVILMEMUR;
                public TTReportField UZMANERBAS;
                public TTReportField ERERBAS;
                public TTReportField OGRENCI;
                public TTReportField EMEKLI;
                public TTReportField SIVIL;
                public TTReportField HIZMETDISITOTAL;
                public TTReportField UZMANJANDARMA;
                public TTReportField DIGERHIZMETICI;
                public TTReportField DIGERHIZMETDISI;
                public TTReportField XXXXXXIPERSONELAILE;
                public TTReportField XXXXXXIEMEKLIAILE;
                public TTReportField GENELTOTAL;
                public TTReportField HIZMETICITOTAL;
                public TTReportField GENERALAMIRAL;
                public TTReportField YOGUNBAKIMYATANHASTA;
                public TTReportField YOGUNBAKIMYATAKSAYISI;
                public TTReportField YOGUNBAKIMBOSYATAK;
                public TTReportField KLINIKYATANHASTA;
                public TTReportField KLINIKYATAKSAYISI;
                public TTReportField KLINIKBOSYATAK; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 13;
                    RepeatCount = 0;
                    
                    BIRIM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 0, 53, 4, false);
                    BIRIM.Name = "BIRIM";
                    BIRIM.DrawStyle = DrawStyleConstants.vbSolid;
                    BIRIM.FieldType = ReportFieldTypeEnum.ftVariable;
                    BIRIM.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BIRIM.TextFont.Size = 8;
                    BIRIM.TextFont.Bold = true;
                    BIRIM.TextFont.CharSet = 162;
                    BIRIM.Value = @"{#WARDNAME#}";

                    SUBAY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 64, 0, 75, 4, false);
                    SUBAY.Name = "SUBAY";
                    SUBAY.DrawStyle = DrawStyleConstants.vbSolid;
                    SUBAY.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SUBAY.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SUBAY.TextFont.Size = 9;
                    SUBAY.TextFont.CharSet = 162;
                    SUBAY.Value = @"0";

                    ASTSUBAY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 75, 0, 86, 4, false);
                    ASTSUBAY.Name = "ASTSUBAY";
                    ASTSUBAY.DrawStyle = DrawStyleConstants.vbSolid;
                    ASTSUBAY.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ASTSUBAY.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ASTSUBAY.TextFont.Size = 9;
                    ASTSUBAY.TextFont.CharSet = 162;
                    ASTSUBAY.Value = @"0";

                    SIVILMEMUR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 86, 0, 97, 4, false);
                    SIVILMEMUR.Name = "SIVILMEMUR";
                    SIVILMEMUR.DrawStyle = DrawStyleConstants.vbSolid;
                    SIVILMEMUR.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SIVILMEMUR.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SIVILMEMUR.TextFont.Size = 9;
                    SIVILMEMUR.TextFont.CharSet = 162;
                    SIVILMEMUR.Value = @"0";

                    UZMANERBAS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 97, 0, 108, 4, false);
                    UZMANERBAS.Name = "UZMANERBAS";
                    UZMANERBAS.DrawStyle = DrawStyleConstants.vbSolid;
                    UZMANERBAS.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    UZMANERBAS.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    UZMANERBAS.TextFont.Size = 9;
                    UZMANERBAS.TextFont.CharSet = 162;
                    UZMANERBAS.Value = @"0";

                    ERERBAS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 119, 0, 130, 4, false);
                    ERERBAS.Name = "ERERBAS";
                    ERERBAS.DrawStyle = DrawStyleConstants.vbSolid;
                    ERERBAS.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ERERBAS.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ERERBAS.TextFont.Size = 9;
                    ERERBAS.TextFont.CharSet = 162;
                    ERERBAS.Value = @"0";

                    OGRENCI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 130, 0, 141, 4, false);
                    OGRENCI.Name = "OGRENCI";
                    OGRENCI.DrawStyle = DrawStyleConstants.vbSolid;
                    OGRENCI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    OGRENCI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OGRENCI.TextFont.Size = 9;
                    OGRENCI.TextFont.CharSet = 162;
                    OGRENCI.Value = @"0";

                    EMEKLI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 185, 0, 196, 4, false);
                    EMEKLI.Name = "EMEKLI";
                    EMEKLI.DrawStyle = DrawStyleConstants.vbSolid;
                    EMEKLI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    EMEKLI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    EMEKLI.TextFont.Size = 9;
                    EMEKLI.TextFont.CharSet = 162;
                    EMEKLI.Value = @"0";

                    SIVIL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 196, 0, 207, 4, false);
                    SIVIL.Name = "SIVIL";
                    SIVIL.DrawStyle = DrawStyleConstants.vbSolid;
                    SIVIL.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SIVIL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SIVIL.TextFont.Size = 9;
                    SIVIL.TextFont.CharSet = 162;
                    SIVIL.Value = @"0";

                    HIZMETDISITOTAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 218, 0, 229, 4, false);
                    HIZMETDISITOTAL.Name = "HIZMETDISITOTAL";
                    HIZMETDISITOTAL.DrawStyle = DrawStyleConstants.vbSolid;
                    HIZMETDISITOTAL.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HIZMETDISITOTAL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HIZMETDISITOTAL.TextFont.Size = 9;
                    HIZMETDISITOTAL.TextFont.Bold = true;
                    HIZMETDISITOTAL.TextFont.CharSet = 162;
                    HIZMETDISITOTAL.Value = @"0";

                    UZMANJANDARMA = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 108, 0, 119, 4, false);
                    UZMANJANDARMA.Name = "UZMANJANDARMA";
                    UZMANJANDARMA.DrawStyle = DrawStyleConstants.vbSolid;
                    UZMANJANDARMA.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    UZMANJANDARMA.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    UZMANJANDARMA.TextFont.Size = 9;
                    UZMANJANDARMA.TextFont.CharSet = 162;
                    UZMANJANDARMA.Value = @"0";

                    DIGERHIZMETICI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 141, 0, 152, 4, false);
                    DIGERHIZMETICI.Name = "DIGERHIZMETICI";
                    DIGERHIZMETICI.DrawStyle = DrawStyleConstants.vbSolid;
                    DIGERHIZMETICI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DIGERHIZMETICI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DIGERHIZMETICI.TextFont.Size = 9;
                    DIGERHIZMETICI.TextFont.CharSet = 162;
                    DIGERHIZMETICI.Value = @"0";

                    DIGERHIZMETDISI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 207, 0, 218, 4, false);
                    DIGERHIZMETDISI.Name = "DIGERHIZMETDISI";
                    DIGERHIZMETDISI.DrawStyle = DrawStyleConstants.vbSolid;
                    DIGERHIZMETDISI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DIGERHIZMETDISI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DIGERHIZMETDISI.TextFont.Size = 9;
                    DIGERHIZMETDISI.TextFont.CharSet = 162;
                    DIGERHIZMETDISI.Value = @"0";

                    XXXXXXIPERSONELAILE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 163, 0, 174, 4, false);
                    XXXXXXIPERSONELAILE.Name = "XXXXXXIPERSONELAILE";
                    XXXXXXIPERSONELAILE.DrawStyle = DrawStyleConstants.vbSolid;
                    XXXXXXIPERSONELAILE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXIPERSONELAILE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    XXXXXXIPERSONELAILE.TextFont.Size = 9;
                    XXXXXXIPERSONELAILE.TextFont.CharSet = 162;
                    XXXXXXIPERSONELAILE.Value = @"0";

                    XXXXXXIEMEKLIAILE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 174, 0, 185, 4, false);
                    XXXXXXIEMEKLIAILE.Name = "XXXXXXIEMEKLIAILE";
                    XXXXXXIEMEKLIAILE.DrawStyle = DrawStyleConstants.vbSolid;
                    XXXXXXIEMEKLIAILE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXIEMEKLIAILE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    XXXXXXIEMEKLIAILE.TextFont.Size = 9;
                    XXXXXXIEMEKLIAILE.TextFont.CharSet = 162;
                    XXXXXXIEMEKLIAILE.Value = @"0";

                    GENELTOTAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 229, 0, 240, 4, false);
                    GENELTOTAL.Name = "GENELTOTAL";
                    GENELTOTAL.DrawStyle = DrawStyleConstants.vbSolid;
                    GENELTOTAL.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    GENELTOTAL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    GENELTOTAL.TextFont.Size = 9;
                    GENELTOTAL.TextFont.Bold = true;
                    GENELTOTAL.TextFont.CharSet = 162;
                    GENELTOTAL.Value = @"0";

                    HIZMETICITOTAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 0, 163, 4, false);
                    HIZMETICITOTAL.Name = "HIZMETICITOTAL";
                    HIZMETICITOTAL.DrawStyle = DrawStyleConstants.vbSolid;
                    HIZMETICITOTAL.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HIZMETICITOTAL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HIZMETICITOTAL.TextFont.Size = 9;
                    HIZMETICITOTAL.TextFont.Bold = true;
                    HIZMETICITOTAL.TextFont.CharSet = 162;
                    HIZMETICITOTAL.Value = @"0";

                    GENERALAMIRAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 0, 64, 4, false);
                    GENERALAMIRAL.Name = "GENERALAMIRAL";
                    GENERALAMIRAL.DrawStyle = DrawStyleConstants.vbSolid;
                    GENERALAMIRAL.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    GENERALAMIRAL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    GENERALAMIRAL.TextFont.Size = 9;
                    GENERALAMIRAL.TextFont.CharSet = 162;
                    GENERALAMIRAL.Value = @"0";

                    YOGUNBAKIMYATANHASTA = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 249, 0, 257, 4, false);
                    YOGUNBAKIMYATANHASTA.Name = "YOGUNBAKIMYATANHASTA";
                    YOGUNBAKIMYATANHASTA.DrawStyle = DrawStyleConstants.vbSolid;
                    YOGUNBAKIMYATANHASTA.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    YOGUNBAKIMYATANHASTA.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    YOGUNBAKIMYATANHASTA.TextFont.Size = 9;
                    YOGUNBAKIMYATANHASTA.TextFont.CharSet = 162;
                    YOGUNBAKIMYATANHASTA.Value = @"0";

                    YOGUNBAKIMYATAKSAYISI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 240, 0, 249, 4, false);
                    YOGUNBAKIMYATAKSAYISI.Name = "YOGUNBAKIMYATAKSAYISI";
                    YOGUNBAKIMYATAKSAYISI.DrawStyle = DrawStyleConstants.vbSolid;
                    YOGUNBAKIMYATAKSAYISI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    YOGUNBAKIMYATAKSAYISI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    YOGUNBAKIMYATAKSAYISI.TextFont.Size = 9;
                    YOGUNBAKIMYATAKSAYISI.TextFont.CharSet = 162;
                    YOGUNBAKIMYATAKSAYISI.Value = @"0";

                    YOGUNBAKIMBOSYATAK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 257, 0, 266, 4, false);
                    YOGUNBAKIMBOSYATAK.Name = "YOGUNBAKIMBOSYATAK";
                    YOGUNBAKIMBOSYATAK.DrawStyle = DrawStyleConstants.vbSolid;
                    YOGUNBAKIMBOSYATAK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    YOGUNBAKIMBOSYATAK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    YOGUNBAKIMBOSYATAK.TextFont.Size = 9;
                    YOGUNBAKIMBOSYATAK.TextFont.CharSet = 162;
                    YOGUNBAKIMBOSYATAK.Value = @"0";

                    KLINIKYATANHASTA = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 275, 0, 283, 4, false);
                    KLINIKYATANHASTA.Name = "KLINIKYATANHASTA";
                    KLINIKYATANHASTA.DrawStyle = DrawStyleConstants.vbSolid;
                    KLINIKYATANHASTA.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    KLINIKYATANHASTA.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    KLINIKYATANHASTA.TextFont.Size = 9;
                    KLINIKYATANHASTA.TextFont.CharSet = 162;
                    KLINIKYATANHASTA.Value = @"0";

                    KLINIKYATAKSAYISI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 266, 0, 275, 4, false);
                    KLINIKYATAKSAYISI.Name = "KLINIKYATAKSAYISI";
                    KLINIKYATAKSAYISI.DrawStyle = DrawStyleConstants.vbSolid;
                    KLINIKYATAKSAYISI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    KLINIKYATAKSAYISI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    KLINIKYATAKSAYISI.TextFont.Size = 9;
                    KLINIKYATAKSAYISI.TextFont.CharSet = 162;
                    KLINIKYATAKSAYISI.Value = @"0";

                    KLINIKBOSYATAK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 283, 0, 292, 4, false);
                    KLINIKBOSYATAK.Name = "KLINIKBOSYATAK";
                    KLINIKBOSYATAK.DrawStyle = DrawStyleConstants.vbSolid;
                    KLINIKBOSYATAK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    KLINIKBOSYATAK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    KLINIKBOSYATAK.TextFont.Size = 9;
                    KLINIKBOSYATAK.TextFont.CharSet = 162;
                    KLINIKBOSYATAK.Value = @"0";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ResBed.GetAllResBedByResWard_Class dataset_GetAllResBedByResWard = ParentGroup.rsGroup.GetCurrentRecord<ResBed.GetAllResBedByResWard_Class>(0);
                    BIRIM.CalcValue = (dataset_GetAllResBedByResWard != null ? Globals.ToStringCore(dataset_GetAllResBedByResWard.Wardname) : "");
                    SUBAY.CalcValue = SUBAY.Value;
                    ASTSUBAY.CalcValue = ASTSUBAY.Value;
                    SIVILMEMUR.CalcValue = SIVILMEMUR.Value;
                    UZMANERBAS.CalcValue = UZMANERBAS.Value;
                    ERERBAS.CalcValue = ERERBAS.Value;
                    OGRENCI.CalcValue = OGRENCI.Value;
                    EMEKLI.CalcValue = EMEKLI.Value;
                    SIVIL.CalcValue = SIVIL.Value;
                    HIZMETDISITOTAL.CalcValue = HIZMETDISITOTAL.Value;
                    UZMANJANDARMA.CalcValue = UZMANJANDARMA.Value;
                    DIGERHIZMETICI.CalcValue = DIGERHIZMETICI.Value;
                    DIGERHIZMETDISI.CalcValue = DIGERHIZMETDISI.Value;
                    XXXXXXIPERSONELAILE.CalcValue = XXXXXXIPERSONELAILE.Value;
                    XXXXXXIEMEKLIAILE.CalcValue = XXXXXXIEMEKLIAILE.Value;
                    GENELTOTAL.CalcValue = GENELTOTAL.Value;
                    HIZMETICITOTAL.CalcValue = HIZMETICITOTAL.Value;
                    GENERALAMIRAL.CalcValue = GENERALAMIRAL.Value;
                    YOGUNBAKIMYATANHASTA.CalcValue = YOGUNBAKIMYATANHASTA.Value;
                    YOGUNBAKIMYATAKSAYISI.CalcValue = YOGUNBAKIMYATAKSAYISI.Value;
                    YOGUNBAKIMBOSYATAK.CalcValue = YOGUNBAKIMBOSYATAK.Value;
                    KLINIKYATANHASTA.CalcValue = KLINIKYATANHASTA.Value;
                    KLINIKYATAKSAYISI.CalcValue = KLINIKYATAKSAYISI.Value;
                    KLINIKBOSYATAK.CalcValue = KLINIKBOSYATAK.Value;
                    return new TTReportObject[] { BIRIM,SUBAY,ASTSUBAY,SIVILMEMUR,UZMANERBAS,ERERBAS,OGRENCI,EMEKLI,SIVIL,HIZMETDISITOTAL,UZMANJANDARMA,DIGERHIZMETICI,DIGERHIZMETDISI,XXXXXXIPERSONELAILE,XXXXXXIEMEKLIAILE,GENELTOTAL,HIZMETICITOTAL,GENERALAMIRAL,YOGUNBAKIMYATANHASTA,YOGUNBAKIMYATAKSAYISI,YOGUNBAKIMBOSYATAK,KLINIKYATANHASTA,KLINIKYATAKSAYISI,KLINIKBOSYATAK};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    //burayadüşmeli  
//                    if (string.IsNullOrEmpty(WARDOBJECTID.CalcValue) == false)
//                    {
//                        Guid wardObjectID = new Guid(WARDOBJECTID.CalcValue);
//                        ResWard ward = (ResWard)this.ParentReport.ReportObjectContext.GetObject(wardObjectID, typeof(ResWard));
//
//                        InPatientGroupTotal inPatientGroupTotal;
//                        if (this.MyParentReport.InPatientGroupTotals.TryGetValue(wardObjectID, out inPatientGroupTotal))
//                        {
//                            GENERALAMIRAL.CalcValue = inPatientGroupTotal.General.ToString();
//                            SUBAY.CalcValue = inPatientGroupTotal.Subay.ToString();
//                            ASTSUBAY.CalcValue = inPatientGroupTotal.Astsubay.ToString();
//                            SIVILMEMUR.CalcValue = inPatientGroupTotal.SivilMemur.ToString();
//                            UZMANERBAS.CalcValue = inPatientGroupTotal.UzmanErbas.ToString();
//                            UZMANJANDARMA.CalcValue = inPatientGroupTotal.UzmanJandarma.ToString();
//                            ERERBAS.CalcValue = inPatientGroupTotal.ErErbas.ToString();
//                            OGRENCI.CalcValue = inPatientGroupTotal.XXXXXXOgrenci.ToString();
//                            DIGERHIZMETICI.CalcValue = inPatientGroupTotal.HIDiger.ToString();
//                            HIZMETICITOTAL.CalcValue = inPatientGroupTotal.HIToplam.ToString();
//
//                            XXXXXXIPERSONELAILE.CalcValue = inPatientGroupTotal.PersonelAilesi.ToString();
//                            XXXXXXIEMEKLIAILE.CalcValue = inPatientGroupTotal.EmekliAilesi.ToString();
//                            EMEKLI.CalcValue = inPatientGroupTotal.Emekli.ToString();
//                            SIVIL.CalcValue = inPatientGroupTotal.Sivil.ToString();
//                            DIGERHIZMETDISI.CalcValue = inPatientGroupTotal.HDDiger.ToString();
//                            HIZMETDISITOTAL.CalcValue = inPatientGroupTotal.HDToplam.ToString();
//
//                            GENELTOTAL.CalcValue = inPatientGroupTotal.GenelToplam.ToString();
//
//                            if (ward is ResIntensiveCare)
//                            {
//                                YOGUNBAKIMYATAKSAYISI.CalcValue = inPatientGroupTotal.YatakSayisi.ToString();
//                                YOGUNBAKIMYATANHASTA.CalcValue = inPatientGroupTotal.DoluYatakSayisi.ToString();
//                                YOGUNBAKIMBOSYATAK.CalcValue = inPatientGroupTotal.BosYatakSayisi.ToString();
//                                KLINIKYATAKSAYISI.CalcValue = "0";
//                                KLINIKYATANHASTA.CalcValue = "0";
//                                KLINIKBOSYATAK.CalcValue = "0";
//                            }
//                            else
//                            {
//                                KLINIKYATAKSAYISI.CalcValue = inPatientGroupTotal.YatakSayisi.ToString();
//                                KLINIKYATANHASTA.CalcValue = inPatientGroupTotal.DoluYatakSayisi.ToString();
//                                KLINIKBOSYATAK.CalcValue = inPatientGroupTotal.BosYatakSayisi.ToString();
//                                YOGUNBAKIMYATAKSAYISI.CalcValue = "0";
//                                YOGUNBAKIMYATANHASTA.CalcValue = "0";
//                                YOGUNBAKIMBOSYATAK.CalcValue = "0";
//                            }
//
//                        }
//
//                    }
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

        public DailyInPatientStatisticsReport()
        {
            MAIN = new MAINGroup(this,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STARTDATE", "", "Başlangıç Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENDDATE", "", "Bitiş Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("SELECTEDRESOURCE", "00000000-0000-0000-0000-000000000000", "Bölüm", @"", false, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("20fdb56a-389f-46c9-8cd5-f604eddab75f");
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STARTDATE"))
                _runtimeParameters.STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTDATE"]);
            if (parameters.ContainsKey("ENDDATE"))
                _runtimeParameters.ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ENDDATE"]);
            if (parameters.ContainsKey("SELECTEDRESOURCE"))
                _runtimeParameters.SELECTEDRESOURCE = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["SELECTEDRESOURCE"]);
            Name = "DAILYINPATIENTSTATISTICSREPORT";
            Caption = "Günlük Sağlık İstatistikleri(Yatan Hasta)";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oeLandscape;
            UserMarginTop = 10;
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


        protected override void RunPreScript()
        {
#region DAILYINPATIENTSTATISTICSREPORT_PreScript
            //
//            InPatientGroupTotals = new Dictionary<Guid, InPatientGroupTotal>();
//
//            IList yataklar = ResBed.GetAllResBedByResWard(this.RuntimeParameters.SELECTEDRESOURCE.Value);
//            foreach (ResBed.GetAllResBedByResWard_Class yatak in yataklar)
//                InPatientGroupTotals.Add(yatak.Wardobjectid.Value, new InPatientGroupTotal(yatak.Wardobjectid.Value, Convert.ToInt32(yatak.Totalbed), this.ReportObjectContext));
//
//            
//          IList doluYataklar =InPatientTreatmentClinicApplication.GetInpatientBedsByResWard(this.RuntimeParameters.SELECTEDRESOURCE.Value);
//                
//                foreach (InPatientTreatmentClinicApplication.GetInpatientBedsByResWard_Class doluYatak in doluYataklar)
//                {
//                   InPatientGroupTotal inPatientGroupTotal;
//                    if (InPatientGroupTotals.TryGetValue(doluYatak.Wardobjectid.Value, out inPatientGroupTotal))
//                    {
//                        inPatientGroupTotal.SetFilledBed(doluYatak);
//                    }
//                }
//            
//            
//            
//            IList yatanhastalistesi = InPatientTreatmentClinicApplication.GetInpatientStatisticsByDate(this.RuntimeParameters.STARTDATE.Value, this.RuntimeParameters.ENDDATE.Value, this.RuntimeParameters.SELECTEDRESOURCE.Value);
//            foreach (InPatientTreatmentClinicApplication.GetInpatientStatisticsByDate_Class item in yatanhastalistesi)
//            {
//                if (item.PhysicalStateClinic.HasValue)
//                {
//                    InPatientGroupTotal inPatientGroupTotal;
//                    if (InPatientGroupTotals.TryGetValue(item.PhysicalStateClinic.Value, out inPatientGroupTotal))
//                    {
//                        TTObjectClasses.PatientGroupDefinition patientGroupDef = TTObjectClasses.Common.PatientGroupDefinitionByEnum(this.ReportObjectContext, (PatientGroupEnum)item.PatientGroup);
//                        string mainPatientGroup = TTObjectClasses.Common.GetEnumValueDefOfEnumValue(patientGroupDef.MainPatientGroup.MainPatientGroupEnum).Name;
//                        inPatientGroupTotal.CalculateValue(item, mainPatientGroup);
//                    }
//                }
//
//            }
//
#endregion DAILYINPATIENTSTATISTICSREPORT_PreScript
        }
    }
}
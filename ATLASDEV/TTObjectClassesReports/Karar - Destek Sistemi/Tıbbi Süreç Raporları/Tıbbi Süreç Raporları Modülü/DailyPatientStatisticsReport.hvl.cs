
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
    /// Günlük Sağlık İstatistikleri
    /// </summary>
    public partial class DailyPatientStatisticsReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
        }

        public partial class ACILGroup : TTReportGroup
        {
            public DailyPatientStatisticsReport MyParentReport
            {
                get { return (DailyPatientStatisticsReport)ParentReport; }
            }

            new public ACILGroupBody Body()
            {
                return (ACILGroupBody)_body;
            }
            public ACILGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public ACILGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new ACILGroupBody(this);
            }

            public partial class ACILGroupBody : TTReportSection
            {
                public DailyPatientStatisticsReport MyParentReport
                {
                    get { return (DailyPatientStatisticsReport)ParentReport; }
                }
                 
                public ACILGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 7;
                    IsVisible = EvetHayirEnum.ehHayir;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                

                public override void RunScript()
                {
#region ACIL BODY_Script
                    //                                                                        
//            TTObjectContext objectContext = new TTObjectContext(true);
//            TTReportTool.TTReportGroup g = ((DailyPatientStatisticsReport)ParentReport).Groups("GENEL");
//            TTReportTool.TTReportGroup pg = ((DailyPatientStatisticsReport)ParentReport).Groups("ACILMURACAAT");
//            string patientGroup = TTObjectDefManager.Instance.DataTypes["PatientGroupEnum"].EnumValueDefs[this.GRP.CalcValue].Name;
//            bool quotaUsed = false;
//            if(this.QUOTAUSED.CalcValue != "")
//                 quotaUsed = Convert.ToBoolean(this.QUOTAUSED.CalcValue);
//            TTDataDictionary.EnumValueDef pge = TTObjectDefManager.Instance.DataTypes["PatientGroupEnum"].EnumValueDefs[this.GRP.CalcValue];
//            TTObjectClasses.PatientGroupEnum patientGroupEnumValue = (TTObjectClasses.PatientGroupEnum) Convert.ToInt32(pge.Value);
//            TTObjectClasses.PatientGroupDefinition patientGroupDef = TTObjectClasses.Common.PatientGroupDefinitionByEnum(objectContext,patientGroupEnumValue);
//            string mainPatientGroup = TTObjectClasses.Common.GetEnumValueDefOfEnumValue(patientGroupDef.MainPatientGroup.MainPatientGroupEnum).Name;
//            switch(mainPatientGroup)
//            {
//                case "Cadet": //XXXXXX Ögrenci
//                    {
//                        pg.Fields("OGRENCI").Value = (Convert.ToInt32(pg.Fields("OGRENCI").Value) + Convert.ToInt32(this.COUNT.CalcValue)).ToString();
//                        g.Fields("OGRENCIACIL").Value = (Convert.ToInt32(g.Fields("OGRENCIACIL").Value) + Convert.ToInt32(this.COUNT.CalcValue)).ToString();
//                    }
//                    break;
//                case "MilitaryWorker"://XXXXXX işçi
//                case "Candidate"://Aday
//                    {
//                        pg.Fields("DIGERHIZMETICI").Value = (Convert.ToInt32(pg.Fields("DIGERHIZMETICI").Value) + Convert.ToInt32(this.COUNT.CalcValue)).ToString();
//                        g.Fields("DIGERHIZMETICIACIL").Value = (Convert.ToInt32(g.Fields("DIGERHIZMETICIACIL").Value) + Convert.ToInt32(this.COUNT.CalcValue)).ToString();
//                    }
//                    break;
//                case "Civilian"://Sivil
//                    {
//                        if(quotaUsed)
//                        {
//                            pg.Fields("KONTSIVIL").Value = (Convert.ToInt32(pg.Fields("KONTSIVIL").Value) + Convert.ToInt32(this.COUNT.CalcValue)).ToString();
//                            g.Fields("KONTSIVILACIL").Value = (Convert.ToInt32(g.Fields("KONTSIVILACIL").Value) + Convert.ToInt32(this.COUNT.CalcValue)).ToString();
//                        }
//                        else
//                        {
//                            pg.Fields("SIVIL").Value = (Convert.ToInt32(pg.Fields("SIVIL").Value) + Convert.ToInt32(this.COUNT.CalcValue)).ToString();
//                            g.Fields("SIVILACIL").Value = (Convert.ToInt32(g.Fields("SIVILACIL").Value) + Convert.ToInt32(this.COUNT.CalcValue)).ToString();
//                        }
//                    }
//                    break;
//                case "ExpertGendarme"://Uzman Jandarma
//                    {
//                        pg.Fields("UZMANJANDARMA").Value = (Convert.ToInt32(pg.Fields("UZMANJANDARMA").Value) + Convert.ToInt32(this.COUNT.CalcValue)).ToString();
//                        g.Fields("UZMANJANDARMAACIL").Value = (Convert.ToInt32(g.Fields("UZMANJANDARMAACIL").Value) + Convert.ToInt32(this.COUNT.CalcValue)).ToString();
//                    }
//                    break;
//                case "ExpertNonCom"://Uzman Erbaş
//                    {
//                        pg.Fields("UZMANERBAS").Value = (Convert.ToInt32(pg.Fields("UZMANERBAS").Value) + Convert.ToInt32(this.COUNT.CalcValue)).ToString();
//                        g.Fields("UZMANERBASACIL").Value = (Convert.ToInt32(g.Fields("UZMANERBASACIL").Value) + Convert.ToInt32(this.COUNT.CalcValue)).ToString();
//                    }
//                    break;
//                case "MilitaryCivilOfficial"://Sivil Memur
//                    {
//                        pg.Fields("SIVILMEMUR").Value = (Convert.ToInt32(pg.Fields("SIVILMEMUR").Value) + Convert.ToInt32(this.COUNT.CalcValue)).ToString();
//                        g.Fields("SIVILMEMURACIL").Value = (Convert.ToInt32(g.Fields("SIVILMEMURACIL").Value) + Convert.ToInt32(this.COUNT.CalcValue)).ToString();
//                    }
//                    break;
//                case "MilitaryPersonelFamily"://XXXXXX Personel Ailesi
//                    {
//                        pg.Fields("XXXXXXIPERSONELAILE").Value = (Convert.ToInt32(pg.Fields("XXXXXXIPERSONELAILE").Value) + Convert.ToInt32(this.COUNT.CalcValue)).ToString();
//                        g.Fields("XXXXXXIPERSONELAILEACIL").Value = (Convert.ToInt32(g.Fields("XXXXXXIPERSONELAILEACIL").Value) + Convert.ToInt32(this.COUNT.CalcValue)).ToString();
//                    }
//                    break;
//                case "NoncommissionedOfficer"://Astsubay
//                    {
//                        pg.Fields("ASTSUBAY").Value = (Convert.ToInt32(pg.Fields("ASTSUBAY").Value) + Convert.ToInt32(this.COUNT.CalcValue)).ToString();
//                        g.Fields("ASTSUBAYACIL").Value = (Convert.ToInt32(g.Fields("ASTSUBAYACIL").Value) + Convert.ToInt32(this.COUNT.CalcValue)).ToString();
//                    }
//                    break;
//                case "Officer"://Subay
//                    {
//                        if(patientGroupEnumValue == TTObjectClasses.PatientGroupEnum.GeneralAdmiral)
//                        {
//                            pg.Fields("GENERALAMIRAL").Value = (Convert.ToInt32(pg.Fields("GENERALAMIRAL").Value) + Convert.ToInt32(this.COUNT.CalcValue)).ToString();
//                            g.Fields("GENERALAMIRALACIL").Value = (Convert.ToInt32(g.Fields("GENERALAMIRALACIL").Value) + Convert.ToInt32(this.COUNT.CalcValue)).ToString();
//                        }
//                        else
//                        {
//                            pg.Fields("SUBAY").Value = (Convert.ToInt32(pg.Fields("SUBAY").Value) + Convert.ToInt32(this.COUNT.CalcValue)).ToString();
//                            g.Fields("SUBAYACIL").Value = (Convert.ToInt32(g.Fields("SUBAYACIL").Value) + Convert.ToInt32(this.COUNT.CalcValue)).ToString();
//                        }
//                    }
//                    break;
//                case "PrivateNonCom"://Er/Erbaş
//                    {
//                        pg.Fields("ERERBAS").Value = (Convert.ToInt32(pg.Fields("ERERBAS").Value) + Convert.ToInt32(this.COUNT.CalcValue)).ToString();
//                        g.Fields("ERERBASACIL").Value = (Convert.ToInt32(g.Fields("ERERBASACIL").Value) + Convert.ToInt32(this.COUNT.CalcValue)).ToString();
//                    }
//                    break;
//                case "Retired"://Emekli
//                    {
//                        pg.Fields("EMEKLI").Value = (Convert.ToInt32(pg.Fields("EMEKLI").Value) + Convert.ToInt32(this.COUNT.CalcValue)).ToString();
//                        g.Fields("EMEKLIACIL").Value = (Convert.ToInt32(g.Fields("EMEKLIACIL").Value) + Convert.ToInt32(this.COUNT.CalcValue)).ToString();
//                    }
//                    break;
//                case "RetiredFamily"://XXXXXX Emekli Ailesi
//                    {
//                        pg.Fields("XXXXXXIEMEKLIAILE").Value = (Convert.ToInt32(pg.Fields("XXXXXXIEMEKLIAILE").Value) + Convert.ToInt32(this.COUNT.CalcValue)).ToString();
//                        g.Fields("XXXXXXIEMEKLIAILEACIL").Value = (Convert.ToInt32(g.Fields("XXXXXXIEMEKLIAILEACIL").Value) + Convert.ToInt32(this.COUNT.CalcValue)).ToString();
//                    }
//                    break;
//                case "Visitor"://Misafir XXXXXX Personel
//                case "SpecialStatusBeneficiary"://Terhisli/Ayrılmış Hak Sahibi
//                    {
//                        pg.Fields("DIGERHIZMETDISI").Value = (Convert.ToInt32(pg.Fields("DIGERHIZMETDISI").Value) + Convert.ToInt32(this.COUNT.CalcValue)).ToString();
//                        g.Fields("DIGERHIZMETDISIACIL").Value = (Convert.ToInt32(g.Fields("DIGERHIZMETDISIACIL").Value) + Convert.ToInt32(this.COUNT.CalcValue)).ToString();
//                    }
//                    break;
//                default:
//                    break;
//            }
#endregion ACIL BODY_Script
                }
            }

        }

        public ACILGroup ACIL;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public DailyPatientStatisticsReport()
        {
            ACIL = new ACILGroup(this,"ACIL");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STARTDATE", "", "Başlangıç Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENDDATE", "", "Bitiş Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STARTDATE"))
                _runtimeParameters.STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTDATE"]);
            if (parameters.ContainsKey("ENDDATE"))
                _runtimeParameters.ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ENDDATE"]);
            Name = "DAILYPATIENTSTATISTICSREPORT";
            Caption = "Günlük Sağlık İstatistikleri";
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